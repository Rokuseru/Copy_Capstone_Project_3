using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;

namespace CapstoneProject_3.POS_System
{
    public partial class frmVoid : Form
    {
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        AuditTrail log = new AuditTrail();
        frmRefundDetails cd;
        public int admin = 0;
        public int tid = 0;
        public int pid = 0;
        public int userID = 0;
        public frmVoid(frmRefundDetails frm)
        {
            InitializeComponent();
            cd = frm;
        }
        //Methods
        public void updateSales()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"DELETE FROM tblSales WHERE TransactionID LIKE @tnumber";
                    command.Parameters.AddWithValue("@tnumber", cd.txtTransNo.Text);
                    command.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadVariables()
        {   
            //Transaction Number
            using (var connection = new SqlConnection(con))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"SELECT cartID FROM tblCart WHERE TransactionNo LIKE @tn";
                command.Parameters.AddWithValue("@tn", cd.txtTransNo.Text);
                command.ExecuteNonQuery();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tid = int.Parse(reader["cartID"].ToString());
                    }
                }
            }

            //Product ID
            using (var connection = new SqlConnection(con))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"SELECT productID from tblProduct WHERE ProductCode LIKE @pcode";
                command.Parameters.AddWithValue("@pcode", cd.txtPcode.Text);
                command.ExecuteNonQuery();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pid = int.Parse(reader["productID"].ToString());
                    }
                }
            }
            //User ID
            using (var connection = new SqlConnection(con))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"SELECT userID from tblUsers WHERE Name LIKE @name";
                command.Parameters.AddWithValue("@name", cd.txtCashier.Text);
                command.ExecuteNonQuery();

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        userID = int.Parse(reader["userID"].ToString());
                    }
                }
            }

        }
        public void saveToRecord()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"INSERT INTO tblCancelledOrders (transacID, pid, price, qty, total, stime,sdate, authorizedBy,cashier, reason, action)
                                            VALUES (@tid, @pid, @price, @qty, @total, @stime,@sdate, @admin,@user, @reason, @action)";
                    command.Parameters.AddWithValue("@tid", tid);
                    command.Parameters.AddWithValue("@pid", pid);
                    command.Parameters.AddWithValue("@price", double.Parse(cd.txtPrice.Text));
                    command.Parameters.AddWithValue("@qty", int.Parse(cd.txtQtyBot.Text));
                    command.Parameters.AddWithValue("@total", double.Parse(cd.txtTotal.Text));
                    command.Parameters.AddWithValue("@stime", DateTime.Now.ToString("H:mm:ss"));
                    command.Parameters.AddWithValue("@sdate", DateTime.Now.ToString("yyyyMMdd"));
                    command.Parameters.AddWithValue("@user", userID);
                    command.Parameters.AddWithValue("@admin", admin);
                    command.Parameters.AddWithValue("@reason", cd.txtReason.Text);
                    command.Parameters.AddWithValue("@action", cd.cbAction.Text);
                    command.ExecuteNonQuery();
                }
                //logs
                log.loadUserID(userID.ToString());
                log.insertAction("Refund", "Refunded the Amount of " + cd.txtPrice.Text + "to Transaction with Reference Code " + cd.txtTransNo.Text, this.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.Data);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public void updateCart()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"UPDATE tblCart SET qty = qty - @qty WHERE cartID LIKE @tid";
                    command.Parameters.AddWithValue("@tid", tid);
                    command.Parameters.AddWithValue("@qty", cd.txtQtyBot.Text);
                    command.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void returnToinventoryYes()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"UPDATE tblProduct SET quantity = quantity + @qty WHERE productID LIKE @pid";
                    command.Parameters.AddWithValue("@qty", int.Parse(cd.txtQtyBot.Text));
                    command.Parameters.AddWithValue("@pid", pid);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.Data);
            }
        }
        public void returnToinventoryNo()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"UPDATE tblProduct SET quantity = quantity - @qty WHERE productID LIKE @pid";
                    command.Parameters.AddWithValue("@qty", int.Parse(cd.txtQtyBot.Text));
                    command.Parameters.AddWithValue("@pid", pid);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.Data);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void btnGrant_Click(object sender, EventArgs e)
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT * FROM tblUsers WHERE username LIKE @uname AND password LIKE @pword";
                    command.Parameters.AddWithValue("@uname", txtUsername.Text);
                    command.Parameters.AddWithValue("@pword", txtPassword.Text);
                    command.ExecuteNonQuery();

                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        if (reader.HasRows)
                        {
                            admin = int.Parse(reader["userID"].ToString());
                            saveToRecord();
                            updateCart();
                            updateSales();
                            if (cd.cbAction.Text == "Yes")
                            {
                                returnToinventoryYes();
                                MessageBox.Show("Transaction Refunded.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Dispose();
                                cd.Dispose();
                                cd.refreshTable();
                            }
                            else
                            {
                                returnToinventoryNo();
                                MessageBox.Show("Transaction Refunded.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Dispose();
                                cd.Dispose();
                                cd.refreshTable();
                            }

                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.Data);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void frmVoid_Load(object sender, EventArgs e)
        {
            loadVariables();
        }
    }
}

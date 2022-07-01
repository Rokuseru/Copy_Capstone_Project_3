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
using System.Globalization;
using CapstoneProject_3.Notifications;

namespace CapstoneProject_3.POS_System
{
    public partial class frmQuantity : Form
    {
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        frmPOS ps;
        private int pid;
        private double price;
        private string transacno;
        private int qty; 
        private int userID = 0;
        Notification ntf = new Notification();

        public frmQuantity(frmPOS pOS)
        {
            InitializeComponent();
            ps = pOS;
        }
        public void productDetails(int pcode, Double price, String transacno, int qty)
        {
            this.pid = pcode;
            this.price = price;
            this.transacno = transacno;
            this.qty = qty;
        }
        public void loadUser()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT * FROM tblUsers WHERE Name LIKE @Name";
                    command.Parameters.AddWithValue("@Name", ps.lblUser.Text);
                    command.ExecuteNonQuery();
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        if (reader.HasRows)
                        {
                            userID = Convert.ToInt32(reader["userID"].ToString());
                        }
                    }
                }
                Console.WriteLine(userID);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.GetType());
                MessageBox.Show(ex.Message);
            }
        }
        private void addToCart()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"INSERT INTO tblCart (TransactionNo, productID, Price, qty, sDate, userID)
                                            VALUES (@transno, @pid, @price, @qty, @date, @cashier)";
                    command.Parameters.AddWithValue("@transno", transacno);
                    command.Parameters.AddWithValue("@pid", pid);
                    command.Parameters.AddWithValue("@price", price);
                    command.Parameters.AddWithValue("@qty", int.Parse(txtQty.Text));
                    command.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyyMMdd"));
                    command.Parameters.AddWithValue("cashier", userID);
                    command.ExecuteNonQuery();

                    ps.txtSearch.Clear();
                    ps.txtSearch.Focus();

                    ntf.notificationMessage(ps.panelNotif1, ps.labelNotif1, ps.iconNotif1, "Added to Cart");
                    ntf.notificationTimer(ps.timer1, ps.panelNotif1);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                ntf.exceptionMessage(ps.panelNotif1, ps.labelNotif1, ps.iconNotif1, ex);
                ntf.notificationTimer(ps.timer1, ps.panelNotif1);
            }
        }
        private void addToCartQuantity()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"UPDATE tblCart SET qty = qty + @qty WHERE TransactionNo LIKE @trNo";
                    command.Parameters.AddWithValue("@qty", int.Parse(txtQty.Text));
                    command.Parameters.AddWithValue("@trNo", ps.lblTransNo.Text);
                    command.ExecuteNonQuery();
                    ps.txtSearch.Clear();
                    ps.txtSearch.Focus();

                    ntf.notificationMessage(ps.panelNotif1, ps.labelNotif1, ps.iconNotif1, "Added to Cart");
                    ntf.notificationTimer(ps.timer1, ps.panelNotif1);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.GetType());
                MessageBox.Show(ex.Message);
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //If String Error It's this line of code
        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            int _currentCartQty = 0;
            if ((e.KeyChar == 13) && (txtQty.Text != String.Empty))
            {
                bool found = false;

                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT * FROM tblCart WHERE TransactionNo = @trano";
                    command.Parameters.AddWithValue("trano", ps.lblTransNo.Text);
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        if (reader.HasRows)
                        {
                            found = true;
                            _currentCartQty = Convert.ToInt32(int.Parse(reader["qty"].ToString()));
                        }
                        else
                        {
                            found = false;
                        }
                    }
                    //Add to Cart with Validation
                    if (qty < (Convert.ToInt32(int.Parse(txtQty.Text)) + _currentCartQty))
                    {
                        MessageBox.Show("Unable To Add. Only " + qty + " Left On Hand.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtQty.Clear();
                    }
                    else
                    {
                        if (found == true)
                        {
                            addToCartQuantity();
                            ps.loadCart();
                        }
                        else
                        {
                            addToCart();
                            ps.loadCart();
                        }
                    }
                }       
            }
        }

        private void frmQuantity_Load(object sender, EventArgs e)
        {
            loadUser();
        }
    }
}

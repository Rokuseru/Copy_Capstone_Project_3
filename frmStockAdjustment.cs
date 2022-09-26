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
using CapstoneProject_3.Notifications;

namespace CapstoneProject_3
{
    public partial class frmStockAdjustment : Form
    {
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        showToast toast = new showToast();
        AuditTrail log = new AuditTrail();
        private int userID = 0;
        private int _qty = 0;
        private int pid = 0;
        MainForm frm;
        public frmStockAdjustment(MainForm form)
        {
            InitializeComponent();
            frm = form;
            generateRefCode();
        }
        public void clear()
        {
            txtDescription.Clear();
            txtProductCode.Clear();
            txtQty.Clear();
            txtRefNo.Clear();
            txtRemarks.Clear();
            cbCommand.Text = " ";
        }

        public void getuserID()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT * FROM tblUsers WHERE Name = @name";
                    command.Parameters.AddWithValue("@name", txtUser.Text);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userID = int.Parse(reader["userID"].ToString());
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void generateRefCode()
        {
            try
            {
                string sql = @"SELECT MAX(referenceCode) FROM tblPurchaseOrder";

                using (var connection = new SqlConnection(con))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    var refid = cmd.ExecuteScalar() as string;

                    if (refid == null)
                    {
                        txtRefNo.Text = "SA-000001";
                    }
                    else
                    {
                        int intval = int.Parse(refid.Substring(3, 6));
                        intval++;
                        txtRefNo.Text = String.Format("SA-{0:000000}", intval);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void generateRefNo()
        {
            try
            {
                string referencecode = "#ADJ000";
                string referenceno;
                int count;

                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT TOP 1 RefNumber FROM tblStockEntry
                                            WHERE RefNumber
                                            LIKE '" + txtRefNo.Text + "%' ORDER BY stockEntryID DESC";
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        if (reader.HasRows)
                        {
                            referenceno = reader[0].ToString();
                            count = int.Parse(referenceno.Substring(4, 4));
                            txtRefNo.Text = referencecode + (count + 1);
                        }
                        else
                        {
                            referenceno = referencecode + "1";
                            txtRefNo.Text = referenceno;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadProducts()
        {
            dataGridView.Rows.Clear();
            try
            {
                int i = 0;
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT p.productID,p.ProductCode, p.Description, b.Brand, c.Category, SUM(qty) AS qty, i.price, i.BatchNo, i.date FROM tblInventory AS i
                                            INNER JOIN tblProduct AS p ON i.productID = p.productID
                                            INNER JOIN tblBrand AS b ON p.BrandID = b.brandID
                                            INNER JOIN tblCategory AS c ON p.CategoryID = c.categoryID
                                            WHERE i.status = 'Available'
											GROUP BY p.productID, p.ProductCode, p.Description, b.Brand, c.Category, i.price, i.BatchNo, i.date
											ORDER BY BatchNo ASC, date ASC";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            i += 1;
                            dataGridView.Rows.Add(i, reader["productID"].ToString(), reader["ProductCode"].ToString(), reader["Description"].ToString(), reader["Brand"].ToString(), reader["Category"].ToString(), reader["qty"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void getProductID()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT * FROM tblProduct WHERE ProductCode LIKE @pcode";
                    command.Parameters.AddWithValue("@pcode", txtProductCode.Text);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            pid = int.Parse(reader["productID"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //This will remove
        public void removeFromInventory()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"UPDATE tblProduct SET quantity = (quantity - @qty) WHERE ProductCode LIKE @pcode";
                    command.Parameters.AddWithValue("@qty", int.Parse(txtQty.Text));
                    command.Parameters.AddWithValue("@pcode", txtProductCode.Text);
                    command.ExecuteNonQuery();
                }
                //logs
                log.loadUserID(frm.lblUser.Text);
                log.insertAction("Stock Adjustment", "Product: " + txtDescription.Text +" Removed QTY: " + txtQty.Text + " with Reference: " + txtRefNo.Text, this.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //This will add
        public void addToInventory()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"UPDATE tblProduct SET quantity = (quantity + @qty) WHERE ProductCode LIKE @pcode";
                    command.Parameters.AddWithValue("@qty", int.Parse(txtQty.Text));
                    command.Parameters.AddWithValue("@pcode", txtProductCode.Text);
                    command.ExecuteNonQuery();
                }
                //logs
                log.loadUserID(frm.lblUser.Text);
                log.insertAction("Stock Adjustment", "Product: " + txtDescription.Text + " Added QTY: " + txtQty.Text + " with Reference: " + txtRefNo.Text, this.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Source);
            }
        }
        public void insertToAdjustmentTable()
        {
            using (var connection = new SqlConnection(con))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"INSERT INTO tblAdjustment (RefCode, productID, qty, action, remarks, aDate, adjustedBy) 
                                        VALUES (@rcode, @pid, @qty, @action, @remarks, @aDate, @adjustedBy)";
                command.Parameters.AddWithValue("@rcode", txtRefNo.Text);
                command.Parameters.AddWithValue("@pid", pid);
                command.Parameters.AddWithValue("@qty", int.Parse(txtQty.Text));
                command.Parameters.AddWithValue("@action", cbCommand.Text);
                command.Parameters.AddWithValue("@remarks", txtRemarks.Text);
                command.Parameters.AddWithValue("aDate", DateTime.Now.ToString("yyyy-dd-MM"));
                command.Parameters.AddWithValue("@adjustedBy", userID);
                command.ExecuteNonQuery();
            }
        }

        private void frmStockAdjustment_Load(object sender, EventArgs e)
        {
            loadProducts();
            txtUser.Text =  frm.nameOfUser;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colname = dataGridView.Columns[e.ColumnIndex].Name;

            if(colname == "select")
            {
                txtProductCode.Text = dataGridView.Rows[e.RowIndex].Cells["pcode"].Value.ToString();
                txtDescription.Text = dataGridView.Rows[e.RowIndex].Cells["desc"].Value.ToString();
                _qty = int.Parse(dataGridView.Rows[e.RowIndex].Cells["qty"].Value.ToString());

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                getProductID();
                getuserID();
                if (string.IsNullOrWhiteSpace(txtRefNo.Text))
                {
                    MessageBox.Show("Reference Code is Empty. Please Generate A Reference Code to Continue.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnGenerateRef.Focus();
                }
                else
                {
                    if (int.Parse(txtQty.Text) > _qty)
                    {
                        MessageBox.Show("New Quantiy Should Not be Greater Than Adjustment Quantity.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        if (cbCommand.Text == "Remove From Inventory")
                        {
                            removeFromInventory();
                        }
                        else if (cbCommand.Text == "Add To Invendory")
                        {
                            addToInventory();
                        }
                        else
                        {
                            MessageBox.Show("Command is Empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            cbCommand.Focus();
                        }
                        insertToAdjustmentTable();
                        clear();
                        loadProducts();
                    }
                   
                }
                //Remove From Inventory
                //Add To Invendory
            }   
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Source);
            }
        }

        private void btnGenerateRef_Click(object sender, EventArgs e)
        {
            generateRefNo();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridView.Rows.Clear();
            try
            {
                int i = 0;
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT p.productID,p.ProductCode, p.Description, b.Brand, c.Category, SUM(qty) AS qty, i.price, i.BatchNo, i.date FROM tblInventory AS i
                                            INNER JOIN tblProduct AS p ON i.productID = p.productID
                                            INNER JOIN tblBrand AS b ON p.BrandID = b.brandID
                                            INNER JOIN tblCategory AS c ON p.CategoryID = c.categoryID
                                            WHERE p.Description = '%" +txtSearch.Text+ "%' AND i.status = 'Available' GROUP BY p.productID, p.ProductCode, p.Description, b.Brand, c.Category, i.price, i.BatchNo, i.date ORDER BY BatchNo ASC, date ASC";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            i += 1;
                            dataGridView.Rows.Add(i, reader["productID"].ToString(), reader["ProductCode"].ToString(), reader["Description"].ToString(), reader["Brand"].ToString(), reader["Category"].ToString(), reader["qty"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

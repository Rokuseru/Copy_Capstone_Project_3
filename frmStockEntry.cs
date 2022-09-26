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
    public partial class frmStockEntry : Form
    {
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        showToast toast = new showToast();
        AuditTrail log = new AuditTrail();
        MainForm mf;
        public string vendorID;
        public frmStockEntry(MainForm main)
        {
            InitializeComponent();
            mf = main;
            generateBatchNo();
            generateRefCode();
        }
        public void clear()
        {
            txtRefNo.Clear();
            txtStockInBy.Clear();
            cbVendor.SelectedIndex = -1;
            dataGridViewStockEntry.Rows.Clear();
        }
        public void loadVendor()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT vendorID, Vendor FROM tblVendor";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cbVendor.Items.Add(reader["Vendor"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void generateBatchNo()
        {
            try
            {
                string sql = @"SELECT MAX(BatchNo) FROM tblInventory";

                using (var connection = new SqlConnection(con))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    var refid = cmd.ExecuteScalar() as string;

                    if (refid == null)
                    {
                        txtBatchNo.Text = "BT-000001";
                    }
                    else
                    {
                        int intval = int.Parse(refid.Substring(3, 6));
                        intval++;
                        txtBatchNo.Text = String.Format("BT-{0:000000}", intval);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void generateRefCode()
        {
            try
            {
                string sql = @"SELECT MAX(RefNumber) FROM tblStockEntry";

                using (var connection = new SqlConnection(con))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    var refid = cmd.ExecuteScalar() as string;

                    if (refid == null)
                    {
                        txtRefNo.Text = "SE-000001";
                    }
                    else
                    {
                        int intval = int.Parse(refid.Substring(3, 6));
                        intval++;
                        txtRefNo.Text = String.Format("SE-{0:000000}", intval);
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
            try
            {
                int i = 0;
                dataGridViewStockEntry.Rows.Clear();

                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT stockEntryID, RefNumber, p.productID ,p.Description, RecievedBy, StockInDate, v.Vendor, qty, StockInDate FROM tblStockEntry
                                            INNER JOIN tblProduct AS p 
                                            ON tblStockEntry.productID = p.productID
                                            INNER JOIN tblVendor AS v
                                            ON tblStockEntry.vendorID = v.vendorID
                                            WHERE Status = 'Pending'";
                    using (var reader = command.ExecuteReader())
                    {
                        i += 1;
                        while (reader.Read())
                        {
                            dataGridViewStockEntry.Rows.Add(i, reader["stockEntryID"].ToString(), reader["productID"].ToString(),reader["RefNumber"].ToString(), reader["Description"].ToString(), reader["RecievedBy"].ToString(),
                           reader["Vendor"].ToString(), reader["qty"].ToString(), 0,Convert.ToDateTime(reader["StockInDate"].ToString()).ToString("yyyy-MM-dd"));
                        }
                       
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void saveQty()
        {
            try
            {
                if (dataGridViewStockEntry.Rows.Count > 0)
                {
                    if (MessageBox.Show("Save to Records and Update Stock?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        for (int i = 0; i < dataGridViewStockEntry.Rows.Count; i++)
                        {
                            //For tblProduct
                            //using (var connection = new SqlConnection(con))
                            //using (var command = new SqlCommand())
                            //{
                            //    connection.Open();
                            //    command.Connection = connection;
                            //    command.CommandText = @"UPDATE tblProduct SET quantity=quantity + @qty  WHERE productID LIKE @pid";
                            //    command.Parameters.AddWithValue("@pid", int.Parse(dataGridViewStockEntry.Rows[i].Cells["pid"].Value.ToString()));
                            //    command.Parameters.AddWithValue("@qty", int.Parse(dataGridViewStockEntry.Rows[i].Cells["qty"].Value.ToString()));
                            //    command.ExecuteNonQuery();
                            //    Console.WriteLine(int.Parse(dataGridViewStockEntry.Rows[i].Cells["pid"].Value.ToString()));
                            //}
                            //tblInventory
                            using (var connection = new SqlConnection(con))
                            using (var command = new SqlCommand())
                            {
                                connection.Open();
                                command.Connection = connection;
                                command.CommandText = @"INSERT INTO tblInventory (productID, BatchNo, price, qty, date)
                                                        VALUES (@pid, @bno, @price, @qty, @date)";
                                command.Parameters.AddWithValue("@pid", int.Parse(dataGridViewStockEntry.Rows[i].Cells["pid"].Value.ToString()));
                                command.Parameters.AddWithValue("@bno", txtBatchNo.Text);
                                command.Parameters.AddWithValue("@price", int.Parse(dataGridViewStockEntry.Rows[i].Cells["cPrice"].Value.ToString()));
                                command.Parameters.AddWithValue("@qty", int.Parse(dataGridViewStockEntry.Rows[i].Cells["qty"].Value.ToString()));
                                command.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));
                                command.ExecuteNonQuery();
                            }

                            //for tblStockEntry
                            using (var connection = new SqlConnection(con))
                            using (var command = new SqlCommand())
                            {
                                connection.Open();
                                command.Connection = connection;
                                command.CommandText = @"UPDATE tblStockEntry SET qty = " + int.Parse(dataGridViewStockEntry.Rows[i].Cells["qty"].Value.ToString()) + ", BatchNo = @bno, Status='Done'WHERE stockEntryID LIKE @id";
                                command.Parameters.AddWithValue("id", dataGridViewStockEntry.Rows[i].Cells[1].Value.ToString());
                                command.Parameters.AddWithValue("@bno", txtBatchNo.Text);
                                command.ExecuteNonQuery();
                            }
                        }
                        //Logs
                        log.loadUserID(mf.lblUser.Text);
                        log.insertAction("Stock Entry", "Stock Updated with Reference Code: " + txtRefNo.Text, "Stock Entry Module");

                        toast.showToastNotifInPanel(new ToastNotification("Stock In Successful", Color.FromArgb(16, 172, 132), FontAwesome.Sharp.IconChar.CheckCircle), panel2);
                        clear();
                    }
                    generateBatchNo();
                    generateRefCode();
                }
            } 
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void saveToInventory()
        {
            try
            {
                for (int i = 0; i < dataGridViewStockEntry.Rows.Count; i++)
                {
                    using (var connection = new SqlConnection(con))
                    using (var command = new SqlCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = @"INSERT INTO tblInventory (productID, BatchNo, price, qty, date)
                                            VALUES (@pid, @bno, @price, @qty, @date)";
                        command.Parameters.AddWithValue("@pid", int.Parse(dataGridViewStockEntry.Rows[i].Cells["pid"].Value.ToString()));
                        command.Parameters.AddWithValue("@bno", txtBatchNo.Text);
                        command.Parameters.AddWithValue("@price", int.Parse(dataGridViewStockEntry.Rows[i].Cells["cPrice"].Value.ToString()));
                        command.Parameters.AddWithValue("@qty", int.Parse(dataGridViewStockEntry.Rows[i].Cells["qty"].Value.ToString()));
                        command.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));
                        command.ExecuteNonQuery();
                    } 
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmStockEntry_Load(object sender, EventArgs e)
        {
            this.txtStockInBy.Text = mf.lblUser.Text;
            loadVendor();
        }
        private void btnProductList_Click(object sender, EventArgs e)
        {
            frmSearchProducts productList = new frmSearchProducts(this);
            productList.ShowDialog();
        }
        private void cbVendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT vendorID FROM tblVendor WHERE Vendor='" + cbVendor.SelectedItem + "'";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            vendorID = reader["vendorID"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadProducts();
        }
        private void dataGridViewStockEntry_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colname = dataGridViewStockEntry.Columns[e.ColumnIndex].Name;

            try
            {
                if (colname == "Delete")
                {
                    if (MessageBox.Show("Remove Item?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        using (var connection = new SqlConnection(con))
                        using (var command = new SqlCommand())
                        {
                            connection.Open();
                            command.Connection = connection;
                            command.CommandText = @"DELETE FROM tblStockEntry WHERE stockEntryID = @seid";
                            command.Parameters.AddWithValue("@seid", dataGridViewStockEntry.Rows[e.RowIndex].Cells[1].Value.ToString());
                            command.ExecuteNonQuery();

                            MessageBox.Show("Deleted Successfully", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadProducts();
                        }
                    }
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            saveQty();
        }
        private void btnInventoryCount_Click(object sender, EventArgs e)
        {
            frmInventoryCount count = new frmInventoryCount();
            count.loadProductQTY();
            count.ShowDialog();
        }
    }
}

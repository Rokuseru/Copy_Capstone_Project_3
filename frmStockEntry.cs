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
        Notification ntf = new Notification();
        public string vendorID;
        public frmStockEntry()
        {
            InitializeComponent();
        }
        public void clear()
        {
            txtRefNo.Clear();
            txtStockInBy.Clear();
            cbVendor.SelectedIndex = -1;
            dtStockInDate.Value = DateTime.Now;
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
                ntf.exceptionMessage(panelNotif1, labelNotif1, iconNotif1, ex);
                ntf.notificationTimer(timer1, panelNotif1);
            }
        }
        public void generateRefNo()
        {
            try
            {
                string referencecode = "#STC000";
                string referenceno;
                int count;

                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT TOP 1 RefNumber FROM tblStockEntry
                                            WHERE RefNumber
                                            LIKE '" + txtRefNo.Text+"%' ORDER BY stockEntryID DESC";
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
                ntf.exceptionMessage(panelNotif1, labelNotif1, iconNotif1, ex);
                ntf.notificationTimer(timer1, panelNotif1);
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
                    command.CommandText = @"SELECT stockEntryID, RefNumber, p.Description, RecievedBy, StockInDate, v.Vendor, qty, StockInDate FROM tblStockEntry
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
                            dataGridViewStockEntry.Rows.Add(i, reader["stockEntryID"].ToString(), reader["RefNumber"].ToString(), reader["Description"].ToString(), reader["RecievedBy"].ToString(),
                           reader["Vendor"].ToString(), reader["qty"].ToString(), reader["StockInDate"].ToString());
                        }
                       
                    }
                }
            }
            catch (Exception ex)
            {
                ntf.exceptionMessage(panelNotif1, labelNotif1, iconNotif1, ex);
                ntf.notificationTimer(timer1, panelNotif1);
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
                            using (var connection = new SqlConnection(con))
                            using (var command = new SqlCommand())
                            {
                                connection.Open();
                                command.Connection = connection;
                                command.CommandText = @"UPDATE tblProduct SET quantity=quantity +" + int.Parse(dataGridViewStockEntry.Rows[i].Cells[6].Value.ToString()) +" WHERE Description LIKE @pdesc";
                                command.Parameters.AddWithValue("@pdesc", dataGridViewStockEntry.Rows[i].Cells[3].Value.ToString());
                                command.ExecuteNonQuery();
                            }
                            //for tblStockEntry
                            using (var connection = new SqlConnection(con))
                            using (var command = new SqlCommand())
                            {
                                connection.Open();
                                command.Connection = connection;
                                command.CommandText = @"UPDATE tblStockEntry SET qty = "+ int.Parse(dataGridViewStockEntry.Rows[i].Cells[6].Value.ToString()) + ", Status='Done'WHERE stockEntryID LIKE @id";
                                command.Parameters.AddWithValue("id", dataGridViewStockEntry.Rows[i].Cells[1].Value.ToString());
                                command.ExecuteNonQuery();
                            }
                        }
                        ntf.notificationMessage(panelNotif1, labelNotif1, iconNotif1, "Stock In Successfully");
                        clear();
                    }
                    else
                    {
                        ntf.cancelMessage(panelNotif1, labelNotif1, iconNotif1);
                        ntf.notificationTimer(timer1, panelNotif1);
                    }
                }
            } 
            catch(Exception ex)
            {
                ntf.exceptionMessage(panelNotif1, labelNotif1, iconNotif1, ex);
                ntf.notificationTimer(timer1, panelNotif1);
            }
        }
        public void loadHistory()
        {
            try
            {
                dtgHistory.Rows.Clear();
                int i = 0;

                string dateB = dtFrom.Value.ToString("yyyy-MM-dd");
                string dateT = dtTo.Value.ToString("yyyy-MM-dd");

                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT * FROM viewStockIn WHERE StockInDate BETWEEN @dateb AND @datet AND Status LIKE 'Done'";
                    command.Parameters.AddWithValue("@dateb", dateB);
                    command.Parameters.AddWithValue("@datet", dateT);
                    using (var reader = command.ExecuteReader())
                    {
                        i += 1;
                        while (reader.Read())
                        {
                            dtgHistory.Rows.Add(i, reader["stockEntryID"].ToString(), reader["RefNumber"].ToString(), reader["Description"].ToString(), reader["RecievedBy"].ToString(),
                           reader["Vendor"].ToString(), reader["qty"].ToString(), reader["StockInDate"].ToString());
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                ntf.exceptionMessage(panelNotif1, labelNotif1, iconNotif1, ex);
                ntf.notificationTimer(timer1, panelNotif1);
            }
        }

        private void frmStockEntry_Load(object sender, EventArgs e)
        {
            loadVendor();
            loadHistory();
        }

        private void btnRefNo_Click(object sender, EventArgs e)
        {
            generateRefNo();
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
                ntf.exceptionMessage(panelNotif1, labelNotif1, iconNotif1, ex);
                ntf.notificationTimer(timer1, panelNotif1);
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
                else
                {

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

        private void dtFrom_ValueChanged(object sender, EventArgs e)
        {
            loadHistory();
        }

        private void dtTo_ValueChanged(object sender, EventArgs e)
        {
            loadHistory();
        }
    }
}

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
    public partial class frmSearchProducts : Form
    {
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        Notification ntf = new Notification();
        frmStockEntry stockEntry;
        public frmSearchProducts(frmStockEntry entry)
        {
            InitializeComponent();
            stockEntry = entry;
        }
        public void searchProducts()
        {
            try
            {
                dataGridView.Rows.Clear();
                int i = 0;

                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT productID, ProductCode, Description, b.Brand, c.Category FROM tblProduct
                                            INNER JOIN tblBrand AS b
                                            ON tblProduct.BrandID = b.brandID
                                            INNER JOIN tblCategory AS c
                                            ON tblProduct.CategoryID = c.categoryID 
											WHERE Description LIKE '%"+txtSearch.Text+"%' OR ProductCode LIKE '%"+txtSearch.Text+"%' ORDER BY Description DESC";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            i += 1;
                            dataGridView.Rows.Add(i, reader["productID"].ToString(), reader["ProductCode"].ToString(), reader["Description"].ToString(), reader["Brand"].ToString(), reader["Category"].ToString());
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
            try
            {
                dataGridView.Rows.Clear();

                int i = 0;

                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT productID, ProductCode, Description, b.Brand, c.Category FROM tblProduct
                                            INNER JOIN tblBrand AS b
                                            ON tblProduct.BrandID = b.brandID
                                            INNER JOIN tblCategory AS c
                                            ON tblProduct.CategoryID = c.categoryID 
                                            ORDER BY Description ASC";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            i += 1;
                            dataGridView.Rows.Add(i, reader["productID"].ToString(), reader["ProductCode"].ToString(), reader["Description"].ToString(), reader["Brand"].ToString(), reader["Category"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmSearchProducts_Load(object sender, EventArgs e)
        {
            loadProducts();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colname = dataGridView.Columns[e.ColumnIndex].Name;

            try
            {
                if (colname == "add")
                {
                    if (String.IsNullOrWhiteSpace(stockEntry.txtRefNo.Text) || String.IsNullOrWhiteSpace(stockEntry.txtStockInBy.Text)
                        || stockEntry.cbVendor.SelectedIndex == -1)
                    {
                        ntf.errorMessage(panelNotif1, labelNotif1, iconNotif1, "A Field Is Empty");
                        ntf.notificationTimer(timer1, panelNotif1);
                    }
                    else
                    {
                        if (MessageBox.Show("Add Item?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            using (var connection = new SqlConnection(con))
                            using (var command = new SqlCommand())
                            {
                                connection.Open();
                                command.Connection = connection;
                                command.CommandText = @"INSERT INTO tblStockEntry (RefNumber, productID, vendorID, RecievedBy, StockInDate) 
                                                VALUES (@refnumber, @productID, @supplierID, @RecievedBy, @date)";
                                command.Parameters.AddWithValue("@refnumber", stockEntry.txtRefNo.Text);
                                command.Parameters.AddWithValue("@productID", dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString());
                                command.Parameters.AddWithValue("@supplierID", stockEntry.vendorID);
                                command.Parameters.AddWithValue("@RecievedBy", stockEntry.txtStockInBy.Text);
                                command.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));
                                command.ExecuteNonQuery();

                                stockEntry.loadProducts();
                            }
                        }
                        else
                        {
                            ntf.cancelMessage(panelNotif1, labelNotif1, iconNotif1);
                            ntf.notificationTimer(timer1, panelNotif1);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchProducts();
        }
    }
}

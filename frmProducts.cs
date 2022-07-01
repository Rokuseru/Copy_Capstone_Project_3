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
    public partial class frmProducts : Form
    {
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        Notification ntf = new Notification();
        public string bid;
        public string cid;
        public frmProducts()
        {
            InitializeComponent();
        }
        public void clear()
        {
            txtBarcode.Clear();
            txtPrice.Clear();
            txtProdCode.Clear();
            txtProdDesc.Clear();
            cbBrand.SelectedIndex = -1;
            cbCategory.SelectedIndex = -1;
            txtReorder.Clear();
        }
        //Load Product and category to combo box
        public void loadBrand()
        {
            try
            {
                string cmd = "SELECT Brand, brandID FROM tblBrand";

                using (SqlConnection connection = new SqlConnection(con))
                using (SqlCommand command = new SqlCommand(cmd, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        cbBrand.Items.Add(reader["Brand"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ntf.exceptionMessage(panelNotif1, labelNotif1, iconNotif1, ex);
                ntf.notificationTimer(timer1, panelNotif1);
            }
        }
        public void loadCategory()
        {
            try
            {
                string cmd = "SELECT Category, categoryID FROM tblCategory";

                using (SqlConnection connection = new SqlConnection(con))
                using (SqlCommand command = new SqlCommand(cmd, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        cbCategory.Items.Add(reader["Category"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                ntf.exceptionMessage(panelNotif1, labelNotif1, iconNotif1, ex);
                ntf.notificationTimer(timer1, panelNotif1);
            }
        }
        //Load Products Into Table
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
                    command.CommandText = @"SELECT productID, ProductCode, Barcode, Description, b.Brand, c.Category, Price,reorder FROM tblProduct
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
                            dataGridView.Rows.Add(i, reader["productID"].ToString(), reader["ProductCode"].ToString(), reader["Barcode"].ToString(), reader["Description"].ToString(), reader["Brand"].ToString(), reader["Category"].ToString(), reader["Price"].ToString(), reader["reorder"].ToString());
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
        public void insertProduct()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = @"INSERT INTO tblProduct (ProductCode, Barcode, Description, BrandID, CategoryID, Price, reorder) 
                                            VALUES (@pcode, @bcode, @desc, @brandID, @catID, @price, @reorder)";
                        command.Parameters.AddWithValue("@pcode", txtProdCode.Text);
                        command.Parameters.AddWithValue("@bcode", txtBarcode.Text);
                        command.Parameters.AddWithValue("@desc", txtProdDesc.Text);
                        command.Parameters.AddWithValue("@brandID", bid);
                        command.Parameters.AddWithValue("@catID", cid);
                        command.Parameters.AddWithValue("@price", txtPrice.Text);
                        command.Parameters.AddWithValue("@reorder", txtReorder.Text);
                        command.ExecuteNonQuery();
                }
                }
                catch (Exception ex)
                {
                ntf.exceptionMessage(panelNotif1, labelNotif1, iconNotif1, ex);
                ntf.notificationTimer(timer1, panelNotif1);
            }      
        }

        public void updateProduct()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"UPDATE tblProduct SET Description=@desc, Price=@price, BrandID=@bid, CategoryID=@cid, reorder=@reorder WHERE productID LIKE @pid";
                    command.Parameters.AddWithValue("@pid", dataGridView.CurrentRow.Cells[1].Value.ToString());
                    command.Parameters.AddWithValue("@desc", txtProdDesc.Text);
                    command.Parameters.AddWithValue("@price", txtPrice.Text);
                    command.Parameters.AddWithValue("@bid", bid);
                    command.Parameters.AddWithValue("@cid", cid);
                    command.Parameters.AddWithValue("@reorder",txtReorder.Text);
                    command.ExecuteReader();
                }
                ntf.notificationMessage(panelNotif1, labelNotif1, iconNotif1, "Updated Sucessfully");
                ntf.notificationTimer(timer1, panelNotif1);
                ntf.notificationMessage(panelNotif2, labelNotif2, iconNotif2, "Updated Sucessfully");
                ntf.notificationTimer(timer1, panelNotif2);

                loadProducts();
            }
            catch (Exception ex)
            {
                ntf.exceptionMessage(panelNotif1, labelNotif1, iconNotif1, ex);
                ntf.notificationTimer(timer1, panelNotif1);
                ntf.exceptionMessage(panelNotif2, labelNotif2, iconNotif2, ex);
                ntf.notificationTimer(timer1, panelNotif2);
            }
        }
        public void searchProduct()
        {
            dataGridView.Rows.Clear();
            int i = 0;

            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT productID, ProductCode, Barcode, Description, b.Brand, c.Category, Price FROM tblProduct
                                            INNER JOIN tblBrand AS b
                                            ON tblProduct.BrandID = b.brandID
                                            INNER JOIN tblCategory AS c
                                            ON tblProduct.CategoryID = c.categoryID
                                            WHERE Description LIKE '" + txtSearch.Text + "%' OR ProductCode LIKE '" + txtSearch.Text + "%'";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            i += 1;
                            dataGridView.Rows.Add(i, reader["productID"].ToString(), reader["ProductCode"].ToString(), reader["Barcode"].ToString(), reader["Description"].ToString(), reader["Brand"].ToString(), reader["Category"].ToString(), reader["Price"].ToString());
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
        private void frmProducts_Load(object sender, EventArgs e)
        {
            tabControl.TabPages.Remove(tabManage);
            loadProducts();
            loadBrand();
            loadCategory();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnBack2_Click(object sender, EventArgs e)
        {
            tabControl.TabPages.Remove(tabManage);
            tabControl.TabPages.Add(tabProductList);
            clear();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            tabControl.TabPages.Remove(tabProductList);
            tabControl.TabPages.Add(tabManage);

            btnSaveUpdate.Enabled = false;
            btnSave.Enabled = true;

            txtBarcode.Enabled = true;
            txtProdCode.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtBarcode.Text) || String.IsNullOrWhiteSpace(txtPrice.Text) || String.IsNullOrWhiteSpace(txtProdCode.Text) ||
                String.IsNullOrWhiteSpace(txtProdDesc.Text))
            {
                MessageBox.Show("A Field Is Empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (MessageBox.Show("Add this Product?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(con))
                        {
                            connection.Open();
                            DataSet ds = new DataSet();
                            SqlCommand cmd = new SqlCommand(@"SELECT * FROM tblProduct WHERE Description=@product OR Barcode=@bCode", connection);
                            cmd.Parameters.AddWithValue("@product", txtProdDesc.Text);
                            cmd.Parameters.AddWithValue("@bCode", txtBarcode.Text);
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            adapter.Fill(ds);

                            int i = ds.Tables[0].Rows.Count;
                            if (i > 0)
                            {
                                ntf.errorMessage(panelNotif1, labelNotif1, iconNotif1, "Product Already Exists");
                                ntf.notificationTimer(timer1, panelNotif1);
                                ntf.errorMessage(panelNotif2, labelNotif2, iconNotif2, "Product Already Exists");
                                ntf.notificationTimer(timer1, panelNotif2);
                                return;
                            }
                            else
                            {
                                insertProduct();
                                ntf.notificationMessage(panelNotif1, labelNotif1, iconNotif1, "Product Added Successfully");
                                ntf.notificationTimer(timer1, panelNotif1);
                                ntf.notificationMessage(panelNotif2, labelNotif2, iconNotif2, "Product Added Successfully");
                                ntf.notificationTimer(timer1, panelNotif2);
                                clear();
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        ntf.exceptionMessage(panelNotif1, labelNotif1, iconNotif1, ex);
                        ntf.notificationTimer(timer1, panelNotif1);
                    }
                }
                else
                {
                    ntf.cancelMessage(panelNotif1, labelNotif1, iconNotif1);
                    ntf.notificationTimer(timer1, panelNotif1);
                    ntf.cancelMessage(panelNotif2, labelNotif2, iconNotif2);
                    ntf.notificationTimer(timer1, panelNotif2);
                }
            }
        }

        private void cbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(con))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(@"SELECT BrandID FROM tblBrand WHERE Brand= '" + cbBrand.SelectedItem + "'", connection);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        bid = dr["BrandID"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                ntf.exceptionMessage(panelNotif1, labelNotif1, iconNotif1, ex);
                ntf.notificationTimer(timer1, panelNotif1);
            }
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(con))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(@"SELECT CategoryID FROM tblCategory WHERE Category= '" + cbCategory.SelectedItem + "'", connection);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        cid = dr["CategoryID"].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                ntf.exceptionMessage(panelNotif1, labelNotif1, iconNotif1, ex);
                ntf.notificationTimer(timer1, panelNotif1);
            }     
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure to Delete this Product?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (var connection = new SqlConnection(con))
                    using (var command = new SqlCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = @"DELETE FROM tblProduct WHERE productID=@id";
                        command.Parameters.AddWithValue("@id", dataGridView.CurrentRow.Cells[1].Value.ToString());
                        command.ExecuteReader();
                    }
                    loadProducts();

                    ntf.notificationMessage(panelNotif1, labelNotif1, iconNotif1, "Deleted Successfully");
                    ntf.notificationTimer(timer1, panelNotif1);
                }
                catch (Exception ex)
                {
                    ntf.exceptionMessage(panelNotif1, labelNotif1, iconNotif1, ex);
                    ntf.notificationTimer(timer1, panelNotif1);
                }
            }
            else
            {
                ntf.cancelMessage(panelNotif1, labelNotif1, iconNotif1);
                ntf.notificationTimer(timer1, panelNotif1);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            txtProdCode.Text = dataGridView.SelectedRows[0].Cells[2].Value.ToString();
            txtBarcode.Text = dataGridView.SelectedRows[0].Cells[3].Value.ToString();
            txtProdDesc.Text = dataGridView.SelectedRows[0].Cells[4].Value.ToString();
            cbBrand.Text = dataGridView.SelectedRows[0].Cells[5].Value.ToString();
            cbCategory.Text = dataGridView.SelectedRows[0].Cells[6].Value.ToString();
            txtPrice.Text = dataGridView.SelectedRows[0].Cells[7].Value.ToString();
            txtReorder.Text = dataGridView.SelectedRows[0].Cells[8].Value.ToString();

            txtProdCode.Enabled = false;
            txtBarcode.Enabled = false;

            tabControl.TabPages.Remove(tabProductList);
            tabControl.TabPages.Add(tabManage);

            btnSave.Enabled = false;
            btnSaveUpdate.Enabled = true;
        }

        private void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Update Brand?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                updateProduct();
                ntf.notificationMessage(panelNotif2, labelNotif2, iconNotif2, "Updated Successfully");
                ntf.notificationTimer(timer1, panelNotif2);
                ntf.notificationMessage(panelNotif1, labelNotif1, iconNotif1, "Updated Successfully");
                ntf.notificationTimer(timer1, panelNotif1);
                clear();
            }
            else
            {
                ntf.cancelMessage(panelNotif1, labelNotif1, iconNotif1);
                ntf.notificationTimer(timer1, panelNotif1);
                ntf.cancelMessage(panelNotif2, labelNotif2, iconNotif2);
                ntf.notificationTimer(timer1, panelNotif2);
                clear();
                tabControl.TabPages.Add(tabProductList);
                tabControl.TabPages.Remove(tabManage);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
            ntf.cancelMessage(panelNotif1, labelNotif1, iconNotif1);
            ntf.notificationTimer(timer1, panelNotif1);
            tabControl.TabPages.Add(tabProductList);
            tabControl.TabPages.Remove(tabManage);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchProduct();
        }
    }
}

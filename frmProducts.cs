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
using System.Net.NetworkInformation;

namespace CapstoneProject_3
{
    public partial class frmProducts : Form
    {
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        showToast toast = new showToast();
        AuditTrail log = new AuditTrail();
        MainForm main;
        public string bid;
        public string cid;
        public string vid;
        public frmProducts(MainForm m)
        {
            main = m;
            InitializeComponent();
        }

        public void clear()
        {
            txtVendorPrice.Clear();
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
                string cmd = "SELECT Brand, brandID FROM tblBrand WHERE status = 'Active'";

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
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadCategory()
        {
            try
            {
                string cmd = "SELECT Category, categoryID FROM tblCategory WHERE status = 'Active'";

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
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void loadVendors()
        {
            try
            {
                string cmd = "SELECT * FROM tblVendor WHERE status = 'Active'";

                using (SqlConnection connection = new SqlConnection(con))
                using (SqlCommand command = new SqlCommand(cmd, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        cbVendor.Items.Add(reader["Vendor"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    command.CommandText = @"SELECT productID, ProductCode, Description, b.Brand, c.Category, u.Vendor, reorder, tblProduct.status FROM tblProduct
                                            INNER JOIN tblBrand AS b
                                            ON tblProduct.BrandID = b.brandID
                                            INNER JOIN tblCategory AS c
                                            ON tblProduct.CategoryID = c.categoryID
                                            INNER JOIN tblVendor AS u ON tblProduct.vendorID = u.vendorID
                                            WHERE tblProduct.status = 'Active'
                                            ORDER BY Description ASC";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            i += 1;
                            dataGridView.Rows.Add(i, reader["productID"].ToString(), reader["ProductCode"].ToString(), reader["Description"].ToString(), reader["Brand"].ToString(), reader["Category"].ToString(), 
                                                reader["Vendor"].ToString(), reader["reorder"].ToString(), reader["status"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    command.CommandText = @"INSERT INTO tblProduct (ProductCode, Description, BrandID, CategoryID, vendorID,VendorPrice, reorder) 
                                            VALUES (@pcode, @desc, @brandID, @catID, @vid,@vprice, @reorder)";
                    command.Parameters.AddWithValue("@pcode", txtProdCode.Text);
                    command.Parameters.AddWithValue("@desc", txtProdDesc.Text);
                    command.Parameters.AddWithValue("@brandID", bid);
                    command.Parameters.AddWithValue("@catID", cid);
                    command.Parameters.AddWithValue("@vprice", txtVendorPrice.Text);
                    command.Parameters.AddWithValue("@reorder", txtReorder.Text);
                    command.Parameters.AddWithValue("@vid", vid);
                    command.ExecuteNonQuery();
                }
                //Logs
                log.loadUserID(main.lblUser.Text);
                log.insertAction("Add Product", "Added New Product: " + txtProdDesc.Text + "with Product Code: " + txtProdCode.Text, "Product Module");
            }
                catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }      
        }
        private void enableProduct()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"UPDATE tblProduct SET status = 'Active' WHERE productID = @pid";
                    command.Parameters.AddWithValue("@pid", int.Parse(dataGridViewInactive.CurrentRow.Cells["pid"].Value.ToString()));
                    command.ExecuteNonQuery();
                }
                //Logs
                log.loadUserID(main.lblUser.Text);
                log.insertAction("Activate Product", "Enabled the Product: " + dataGridView.CurrentRow.Cells["Column4"].Value.ToString() , "Product Module");
                //Toast notification
                toast.showToastNotif(new ToastNotification("Product Enabled Successfully.", Color.FromArgb(21, 101, 192), FontAwesome.Sharp.IconChar.CheckCircle), tabProductList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void disableProduct()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"UPDATE tblProduct SET status = 'Disabled' WHERE productID = @pid";
                    command.Parameters.AddWithValue("@pid", int.Parse(dataGridView.CurrentRow.Cells["Column1"].Value.ToString()));
                    command.ExecuteNonQuery();
                }
                //Logs
                log.loadUserID(main.lblUser.Text);
                log.insertAction("Disable Product", "Disabled the Product: " + dataGridView.CurrentRow.Cells["Column4"].Value.ToString(), "Product Module");
                //Toast notification
                toast.showToastNotif(new ToastNotification("Product Disabled Successfully.", Color.FromArgb(21, 101, 192), FontAwesome.Sharp.IconChar.CheckCircle), tabProductList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void loadDisabledProduct()
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
                    command.CommandText = @"SELECT productID, ProductCode, Description, b.Brand, c.Category, u.Vendor, reorder, tblProduct.status FROM tblProduct
                                            INNER JOIN tblBrand AS b
                                            ON tblProduct.BrandID = b.brandID
                                            INNER JOIN tblCategory AS c
                                            ON tblProduct.CategoryID = c.categoryID
                                            INNER JOIN tblVendor AS u ON tblProduct.vendorID = u.vendorID
                                            WHERE tblProduct.status = 'Disabled'
                                            ORDER BY Description ASC";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            i += 1;
                            dataGridViewInactive.Rows.Add(i, reader["productID"].ToString(), reader["ProductCode"].ToString(), reader["Description"].ToString(), reader["Brand"].ToString(), reader["Category"].ToString(),
                                                reader["Vendor"].ToString(), reader["reorder"].ToString(), reader["status"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    command.CommandText = @"UPDATE tblProduct SET Description=@desc, VendorPrice = @vprice, BrandID=@bid, CategoryID=@cid, vendorID = @vid,reorder=@reorder WHERE productID LIKE @pid";
                    command.Parameters.AddWithValue("@pid", dataGridView.CurrentRow.Cells[1].Value.ToString());
                    command.Parameters.AddWithValue("@desc", txtProdDesc.Text);
                    command.Parameters.AddWithValue("@vprice", txtVendorPrice.Text);
                    command.Parameters.AddWithValue("@bid", bid);
                    command.Parameters.AddWithValue("@cid", cid);
                    command.Parameters.AddWithValue("@reorder",txtReorder.Text);
                    command.Parameters.AddWithValue("@vid", vid);
                    command.ExecuteReader();
                }
                //Logs
                log.loadUserID(main.lblUser.Text);
                log.insertAction("Edit Product", "Updated the Product" + dataGridView.CurrentRow.Cells[4].Value.ToString(), this.Text);

                toast.showToastNotif(new ToastNotification("Deleted Sucessfully", Color.FromArgb(21, 101, 192), FontAwesome.Sharp.IconChar.CheckCircle), tabManage);
                loadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    command.CommandText = @"SELECT productID, ProductCode Description, b.Brand, c.Category, Price FROM tblProduct
                                            INNER JOIN tblBrand AS b
                                            ON tblProduct.BrandID = b.brandID
                                            INNER JOIN tblCategory AS c
                                            ON tblProduct.CategoryID = c.categoryID
                                            WHERE Description LIKE '" + txtSearch.Text + "%' OR ProductCode LIKE '" + txtSearch.Text + "%' AND status = 'Active'";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            i += 1;
                            dataGridView.Rows.Add(i, reader["productID"].ToString(), reader["ProductCode"].ToString(), reader["Description"].ToString(), reader["Brand"].ToString(), reader["Category"].ToString(), reader["Price"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void generateProductCode()
        {
            try
            {
                string sql = @"SELECT MAX(ProductCode) FROM tblProduct";

                using (var connection = new SqlConnection(con))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    var refid = cmd.ExecuteScalar() as string;

                    if (refid == null)
                    {
                        txtProdCode.Text = "P00001";
                    }
                    else
                    {
                        int intval = int.Parse(refid.Substring(1, 5));
                        intval++;
                        txtProdCode.Text = String.Format("P{0:00000}", intval);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmProducts_Load(object sender, EventArgs e)
        {
            tabControl.TabPages.Remove(tabManage);
            loadDisabledProduct();
            loadProducts();
            loadBrand();
            loadCategory();
            loadVendors();
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
            generateProductCode();

            btnSaveUpdate.Enabled = false;
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtVendorPrice.Text) || String.IsNullOrWhiteSpace(txtProdCode.Text) ||
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
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            adapter.Fill(ds);

                            int i = ds.Tables[0].Rows.Count;
                            if (i > 0)
                            {
                                toast.showToastNotif(new ToastNotification("Product Already Exists.", Color.FromArgb(198, 40, 40), FontAwesome.Sharp.IconChar.ExclamationCircle), tabManage);
                                return;
                            }
                            else
                            {
                                insertProduct();
                                toast.showToastNotif(new ToastNotification("Product Added Successfully.", Color.FromArgb(16, 172, 132), FontAwesome.Sharp.IconChar.CheckCircle), tabManage);
                                clear();
                            }

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    toast.showToastNotif(new ToastNotification("Operation Cancelled.", Color.FromArgb(21, 101, 192), FontAwesome.Sharp.IconChar.Ban), tabProductList);
                    toast.showToastNotif(new ToastNotification("Operation Cancelled.", Color.FromArgb(21, 101, 192), FontAwesome.Sharp.IconChar.Ban), tabManage);
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
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    //Logs
                    log.loadUserID(main.lblUser.Text);
                    log.insertAction("Delete", "Deleted the Product: " + dataGridView.CurrentRow.Cells[4].Value.ToString(), this.Text);

                    loadProducts();
                    toast.showToastNotif(new ToastNotification("Product Deleted Sucessfully", Color.FromArgb(16, 172, 132), FontAwesome.Sharp.IconChar.CheckCircle), tabProductList);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                toast.showToastNotif(new ToastNotification("Operation Cancelled.", Color.FromArgb(21, 101, 192), FontAwesome.Sharp.IconChar.Ban), tabProductList);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            txtProdCode.Text = dataGridView.SelectedRows[0].Cells[2].Value.ToString();
            txtProdDesc.Text = dataGridView.SelectedRows[0].Cells[4].Value.ToString();
            cbBrand.Text = dataGridView.SelectedRows[0].Cells[5].Value.ToString();
            cbCategory.Text = dataGridView.SelectedRows[0].Cells[6].Value.ToString();
            txtVendorPrice.Text = dataGridView.SelectedRows[0].Cells[7].Value.ToString();
            txtReorder.Text = dataGridView.SelectedRows[0].Cells[8].Value.ToString();
            cbVendor.Text = dataGridView.SelectedRows[0].Cells["Column8"].Value.ToString();

            txtProdCode.Enabled = false;

            tabControl.TabPages.Remove(tabProductList);
            tabControl.TabPages.Add(tabManage);

            btnSave.Enabled = false;
            btnSaveUpdate.Enabled = true;
        }

        private void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Update Product?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                updateProduct();
                clear();
            }
            else
            {
                clear();
                tabControl.TabPages.Add(tabProductList);
                tabControl.TabPages.Remove(tabManage);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
            tabControl.TabPages.Add(tabProductList);
            tabControl.TabPages.Remove(tabManage);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchProduct();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colname = dataGridView.Columns[e.ColumnIndex].Name;

            if(colname == "disable")
            {
                if (MessageBox.Show("Disable this Product?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    disableProduct();
                    loadDisabledProduct();
                    loadProducts();
                }
            }
        }

        private void dataGridViewInactive_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colname = dataGridViewInactive.Columns[e.ColumnIndex].Name;

            if (colname == "enable")
            {
                if (MessageBox.Show("Activate this Product?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    enableProduct();
                    loadProducts();
                    loadDisabledProduct();
                }
            }
        }

        private void cbVendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(con))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(@"SELECT vendorID FROM tblVendor WHERE Vendor = '" + cbVendor.SelectedItem + "'", connection);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        vid = dr["vendorID"].ToString();
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

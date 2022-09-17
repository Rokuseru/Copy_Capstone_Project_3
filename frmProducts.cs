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
        showToast toast = new showToast();
        AuditTrail log = new AuditTrail();
        MainForm main;
        public string bid;
        public string cid;
        public frmProducts(MainForm m)
        {
            main = m;
            InitializeComponent();
        }

        public void clear()
        {
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
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    command.CommandText = @"SELECT productID, ProductCode, Description, b.Brand, c.Category, Price,reorder FROM tblProduct
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
                            dataGridView.Rows.Add(i, reader["productID"].ToString(), reader["ProductCode"].ToString(), reader["Description"].ToString(), reader["Brand"].ToString(), reader["Category"].ToString(), reader["Price"].ToString(), reader["reorder"].ToString());
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
                        command.CommandText = @"INSERT INTO tblProduct (ProductCode, Description, BrandID, CategoryID, Price, reorder) 
                                            VALUES (@pcode, @desc, @brandID, @catID, @price, @reorder)";
                        command.Parameters.AddWithValue("@pcode", txtProdCode.Text);
                        command.Parameters.AddWithValue("@desc", txtProdDesc.Text);
                        command.Parameters.AddWithValue("@brandID", bid);
                        command.Parameters.AddWithValue("@catID", cid);
                        command.Parameters.AddWithValue("@price", txtPrice.Text);
                        command.Parameters.AddWithValue("@reorder", txtReorder.Text);
                        command.ExecuteNonQuery();
                }
                //Logs
                log.loadUserID(main.lblUser.Text);
                log.insertAction("Add Product", "Added New Product: " + txtProdDesc.Text + "with Product Code: " + txtProdCode.Text, this.Text);
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
                    command.CommandText = @"UPDATE tblProduct SET Description=@desc, Price=@price, BrandID=@bid, CategoryID=@cid, reorder=@reorder WHERE productID LIKE @pid";
                    command.Parameters.AddWithValue("@pid", dataGridView.CurrentRow.Cells[1].Value.ToString());
                    command.Parameters.AddWithValue("@desc", txtProdDesc.Text);
                    command.Parameters.AddWithValue("@price", txtPrice.Text);
                    command.Parameters.AddWithValue("@bid", bid);
                    command.Parameters.AddWithValue("@cid", cid);
                    command.Parameters.AddWithValue("@reorder",txtReorder.Text);
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
            generateProductCode();

            btnSaveUpdate.Enabled = false;
            btnSave.Enabled = true;

            txtProdCode.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtPrice.Text) || String.IsNullOrWhiteSpace(txtProdCode.Text) ||
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
            txtPrice.Text = dataGridView.SelectedRows[0].Cells[7].Value.ToString();
            txtReorder.Text = dataGridView.SelectedRows[0].Cells[8].Value.ToString();

            txtProdCode.Enabled = false;

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
                clear();
            }
            else
            {
                clear();
                tabControl.TabPages.Add(tabProductList);
                tabControl.TabPages.Remove(tabManage);
                toast.showToastNotif(new ToastNotification("Operation Cancelled.", Color.FromArgb(21, 101, 192), FontAwesome.Sharp.IconChar.Ban), tabProductList);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
            toast.showToastNotif(new ToastNotification("Operation Cancelled.", Color.FromArgb(21, 101, 192), FontAwesome.Sharp.IconChar.Ban), tabProductList);
            tabControl.TabPages.Add(tabProductList);
            tabControl.TabPages.Remove(tabManage);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchProduct();
        }
    }
}

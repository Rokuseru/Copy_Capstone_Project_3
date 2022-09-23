using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using CapstoneProject_3.Notifications;

namespace CapstoneProject_3
{
    public partial class frmCategory : Form
    {
        showToast toast = new showToast();
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        AuditTrail log = new AuditTrail();
        MainForm main;
        public frmCategory( MainForm m)
        {
            main = m;
            InitializeComponent();
        }
        //Insert Category
        public void insertCategory()
        {
            if (MessageBox.Show("Are You Sure to Save Category?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (var connection = new SqlConnection(con))
                    using (var command = new SqlCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = @"INSERT INTO tblCategory (Category) VALUES (@category)";
                        command.Parameters.AddWithValue("@category", txtCategoryName.Text);
                        command.ExecuteNonQuery();
                    }
                    //Logs
                    log.loadUserID(main.lblUser.Text);
                    log.insertAction("Add Category", "Added New Category: "+txtCategoryName.Text, "Category Module");
                    //Toast Notification
                    toast.showToastNotif(new ToastNotification("Category Added Sucessfully.", Color.FromArgb(16, 172, 132), FontAwesome.Sharp.IconChar.CheckCircle), tabManage);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                txtCategoryName.Clear();
                toast.showToastNotif(new ToastNotification("Operation Cancelled.", Color.FromArgb(198, 40, 40), FontAwesome.Sharp.IconChar.ExclamationCircle), tabManage);
                toast.showToastNotif(new ToastNotification("Operation Cancelled.", Color.FromArgb(198, 40, 40), FontAwesome.Sharp.IconChar.ExclamationCircle), tabCategoryList);
            }
        }
        //Update Category
        public void updateCategory()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"UPDATE tblCategory SET Category = @category WHERE categoryID LIKE @id";
                    command.Parameters.AddWithValue("@id", dataGridView.CurrentRow.Cells[1].Value.ToString());
                    command.Parameters.AddWithValue("@category", txtCategoryName.Text);
                    command.ExecuteReader();
                }
                //Logs
                log.loadUserID(main.lblUser.Text);
                log.insertAction("Edit Category", "Updated the Category: " + txtCategoryName.Text, "Category Module");

                toast.showToastNotif(new ToastNotification("Category Updated Sucessfully.", Color.FromArgb(16, 172, 132), FontAwesome.Sharp.IconChar.CheckCircle), tabManage);
                loadAllCategory();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void loadAllCategory()
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
                    command.CommandText = @"SELECT * FROM tblCategory WHERE status = 'Active' ORDER BY Category ASC";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            i += 1;
                            dataGridView.Rows.Add(i, reader["categoryID"].ToString(), reader["Category"].ToString(), reader["status"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void searchCategory()
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
                    command.CommandText = @"SELECT * FROM tblCategory WHERE Category LIKE '%" + txtSearch.Text + "%' AND status = 'Active' ORDER BY Category ASC";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            i += 1;
                            dataGridView.Rows.Add(i, reader["categoryID"].ToString(), reader["Category"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void searchInactiveCategory()
        {
            dataGridViewInactive.Rows.Clear();
            int i = 0;

            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT * FROM tblCategory WHERE Category LIKE '%" + txtSearchInnactive.Text + "%' AND status = 'Disabled' ORDER BY Category ASC";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            i += 1;
                            dataGridViewInactive.Rows.Add(i, reader["categoryID"].ToString(), reader["Category"].ToString(), reader["status"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void disableCategory()
        {
            try
            {
                var con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;           
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"UPDATE tblCategory SET status = 'Disabled' WHERE categoryID = @cid";
                    command.Parameters.AddWithValue("@cid", int.Parse(dataGridView.CurrentRow.Cells["cid"].Value.ToString()));
                    command.ExecuteReader();
                }
                //Audit Trail
                log.loadUserID(main.lblUser.Text);
                log.insertAction("Deactivate Category", "Deactivated the Category: " + this.txtCategoryName.Text, "Category Module");
                //Toast notification
                toast.showToastNotif(new ToastNotification("Category Disabled Successfully.", Color.FromArgb(21, 101, 192), FontAwesome.Sharp.IconChar.CheckCircle), tabCategoryList);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void enableCategory()
        {
            try
            {
                var con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"UPDATE tblCategory SET status = 'Active' WHERE categoryID = @cid";
                    command.Parameters.AddWithValue("@cid", int.Parse(dataGridViewInactive.CurrentRow.Cells["catID"].Value.ToString()));
                    command.ExecuteReader();
                }
                //Audit Trail
                log.loadUserID(main.lblUser.Text);
                log.insertAction("Activate Category", "Enabled the Category: " + dataGridViewInactive.CurrentRow.Cells["dataGridViewTextBoxColumn3"].Value.ToString(), "Category Module");
                //Toast notification
                toast.showToastNotif(new ToastNotification("Category Enabled Successfully.", Color.FromArgb(21, 101, 192), FontAwesome.Sharp.IconChar.CheckCircle), tabCategoryList);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void loadDisabledCategory()
        {
            try
            {
                dataGridViewInactive.Rows.Clear();
                int i = 0;
                var con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT * FROM tblCategory WHERE status = 'Disabled'";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            i += 1;
                            dataGridViewInactive.Rows.Add(i, reader["categoryID"].ToString(), reader["Category"].ToString(), reader["status"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmCategory_Load(object sender, EventArgs e)
        {
            tabControl.TabPages.Remove(tabManage);
            loadAllCategory();
            loadDisabledCategory();
        }
        private void btnAddNew_Click(object sender, EventArgs e)
        {
            tabControl.TabPages.Remove(tabCategoryList);
            tabControl.TabPages.Add(tabManage);
            txtCategoryId.Text = "This Field Is Autogenerated";
            btnSaveUpdate.Enabled = false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtCategoryName.Text == "")
            {
                MessageBox.Show("Category Name Cannot Be Empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(con))
                    {
                        conn.Open();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand(@"SELECT * FROM tblCategory WHERE Category=@category", conn);
                        cmd.Parameters.AddWithValue("@category", txtCategoryName.Text);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(ds);
                        int i = ds.Tables[0].Rows.Count;

                        if (i > 0)
                        {
                            toast.showToastNotif(new ToastNotification("Category Already Exists.", Color.FromArgb(198, 40, 40), FontAwesome.Sharp.IconChar.ExclamationCircle), tabManage);
                            return;
                        }
                        else
                        {
                            insertCategory();
                            loadAllCategory();
                            txtCategoryName.Clear();
                            btnSaveUpdate.Enabled = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            tabControl.TabPages.Remove(tabManage);
            tabControl.TabPages.Add(tabCategoryList);
            btnSave.Enabled = true;
            btnSaveUpdate.Enabled = true;
            loadAllCategory();
        }
        private void btnBack2_Click(object sender, EventArgs e)
        {
            tabControl.TabPages.Add(tabCategoryList);
            tabControl.TabPages.Remove(tabManage);
            loadAllCategory();
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            txtCategoryId.Text = dataGridView.SelectedRows[0].Cells[1].Value.ToString();
            txtCategoryName.Text = dataGridView.SelectedRows[0].Cells[2].Value.ToString();
            tabControl.TabPages.Remove(tabCategoryList);
            tabControl.TabPages.Add(tabManage);
            btnSave.Enabled = false;
        }
        private void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Update Category", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                updateCategory();
                txtCategoryName.Clear();
            }
            else
            {
                txtCategoryName.Clear();
                tabControl.TabPages.Add(tabCategoryList);
                tabControl.TabPages.Remove(tabManage);
                loadAllCategory();
                toast.showToastNotif(new ToastNotification("Operation Cancelled.", Color.FromArgb(198, 40, 40), FontAwesome.Sharp.IconChar.ExclamationCircle), tabCategoryList);
            }
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchCategory();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colname = dataGridView.Columns[e.ColumnIndex].Name;
            if (colname == "deactivate")
            {
                if (MessageBox.Show("Deactivate Category?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    disableCategory();
                    loadDisabledCategory();
                    loadAllCategory();
                }
                else
                {
                    return;
                }
            }
        }

        private void dataGridViewInactive_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colname = dataGridViewInactive.Columns[e.ColumnIndex].Name;
            if (colname == "activate")
            {
                if (MessageBox.Show("Activate Category?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    enableCategory();
                    loadDisabledCategory();
                    loadAllCategory();
                }
            }
        }

        private void txtSearchInnactive_TextChanged(object sender, EventArgs e)
        {
            searchInactiveCategory();
        }
    }
}

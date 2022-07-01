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
        Notification ntf = new Notification(); 
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        public frmCategory()
        {
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
                    ntf.notificationMessage(panelNotif1, labelNotif1, iconNotif1, "Category Added Successfully");
                    ntf.notificationTimer(timer1, panelNotif1);

                }
                catch (Exception ex)
                {
                    ntf.exceptionMessage(panelNotif1, labelNotif1, iconNotif1, ex);
                    ntf.notificationTimer(timer1, panelNotif1);
                    ntf.exceptionMessage(panelNotif2, labelNotif2, iconNotif2, ex);
                    ntf.notificationTimer(timer1, panelNotif2);
                }
            }
            else
            {
                txtCategoryName.Clear();
                ntf.cancelMessage(panelNotif1, labelNotif1, iconNotif1);
                ntf.notificationTimer(timer1, panelNotif1);
                ntf.cancelMessage(panelNotif2, labelNotif2, iconNotif2);
                ntf.notificationTimer(timer1, panelNotif2);
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
                ntf.notificationMessage(panelNotif1, labelNotif1, iconNotif1, "Updated Sucessfully");
                ntf.notificationTimer(timer1, panelNotif1);
                ntf.notificationMessage(panelNotif2, labelNotif2, iconNotif2, "Updated Sucessfully");
                ntf.notificationTimer(timer1, panelNotif2);
                loadAllCategory();
            }
            catch (Exception ex)
            {
                ntf.exceptionMessage(panelNotif1, labelNotif1, iconNotif1, ex);
                ntf.notificationTimer(timer1, panelNotif1);
                ntf.exceptionMessage(panelNotif2, labelNotif2, iconNotif2, ex);
                ntf.notificationTimer(timer1, panelNotif2);
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
                    command.CommandText = @"SELECT * FROM tblCategory ORDER BY Category ASC";
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
                ntf.exceptionMessage(panelNotif1, labelNotif1, iconNotif1, ex);
                ntf.notificationTimer(timer1, panelNotif1);
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
                    command.CommandText = @"SELECT * FROM tblCategory WHERE Category LIKE '" + txtSearch.Text + "%' ORDER BY Category ASC";
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
                ntf.exceptionMessage(panelNotif1, labelNotif1, iconNotif1, ex);
                ntf.notificationTimer(timer1, panelNotif1);
            }
        }
        public void deleteCategory()
        {
            if (MessageBox.Show("Are You Sure to Remove This Category?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
                    using (var connection = new SqlConnection(con))
                    using (var command = new SqlCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = @"DELETE FROM tblCategory Where categoryID=@id";
                        command.Parameters.AddWithValue("@id", dataGridView.CurrentRow.Cells[1].Value.ToString());
                        command.ExecuteReader();
                    }
                    ntf.notificationMessage(panelNotif1, labelNotif1, iconNotif1, "Deleted Successfully");
                    ntf.notificationTimer(timer1, panelNotif1);

                    loadAllCategory();
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
                return;
            }
        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            tabControl.TabPages.Remove(tabManage);
            loadAllCategory();
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
                            ntf.errorMessage(panelNotif2, labelNotif2, iconNotif2, "Category Already Exists");
                            ntf.notificationTimer(timer1, panelNotif2);
                            return;
                        }
                        else
                        {
                            insertCategory();
                            loadAllCategory();
                            tabControl.TabPages.Remove(tabManage);
                            tabControl.TabPages.Add(tabCategoryList);
                            txtCategoryName.Clear();
                            btnSaveUpdate.Enabled = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ntf.exceptionMessage(panelNotif1, labelNotif1, iconNotif1, ex);
                    ntf.notificationTimer(timer1, panelNotif1);
                    ntf.exceptionMessage(panelNotif2, labelNotif2, iconNotif2, ex);
                    ntf.notificationTimer(timer1, panelNotif2);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ntf.cancelMessage(panelNotif1, labelNotif1, iconNotif1);
            ntf.notificationTimer(timer1, panelNotif1);
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
                ntf.cancelMessage(panelNotif1, labelNotif1, iconNotif1);
                ntf.notificationTimer(timer1, panelNotif1);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchCategory();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            deleteCategory();
        }
    }
}

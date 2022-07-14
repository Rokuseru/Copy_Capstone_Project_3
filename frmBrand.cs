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
    public partial class frmBrand : Form
    {
        showToast toast = new showToast();
        public frmBrand()
        {
            InitializeComponent();
        }
        //Connection and command
        public void loadAllBrands()
        {
            try
            {
                dataGridView.Rows.Clear();

                var con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
                int i = 0;

                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT * FROM tblBrand ORDER BY Brand ASC";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            i += 1;
                            dataGridView.Rows.Add(i, reader["brandID"].ToString(), reader["Brand"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void searchBrand()
        {
            dataGridView.Rows.Clear();
            var con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
            int i = 0;

            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT * FROM tblBrand WHERE Brand LIKE '" + txtSearch.Text + "%' ORDER BY Brand ASC";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            i += 1;
                            dataGridView.Rows.Add(i, reader["brandID"].ToString(), reader["Brand"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void insertBrand()
        {
            string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;

            if (MessageBox.Show("Are You Sure to Save Brand?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (var connection = new SqlConnection(con))
                    using (var command = new SqlCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = @"INSERT INTO tblBrand (Brand) VALUES (@brand)";
                        command.Parameters.AddWithValue("@brand", txtBrandName.Text);
                        command.ExecuteNonQuery();
                    }
                    toast.showToastNotif(new ToastNotification("Brand Added Successfully", Color.FromArgb(16, 172, 132), FontAwesome.Sharp.IconChar.CheckCircle), tabManage);
                    txtBrandName.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                toast.showToastNotif(new ToastNotification("Operation Cancelled", Color.FromArgb(198, 40, 40), FontAwesome.Sharp.IconChar.WindowClose), tabBrandList);
                txtBrandName.Clear();
            }
        }
        public void updateBrand()
        {
            var con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
            if (MessageBox.Show("Update Brand?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (var connection = new SqlConnection(con))
                    using (var command = new SqlCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = @"UPDATE tblBrand SET Brand = @brand WHERE brandID LIKE @id";
                        command.Parameters.AddWithValue("@id", dataGridView.CurrentRow.Cells[1].Value.ToString());
                        command.Parameters.AddWithValue("@brand", txtBrandName.Text);
                        command.ExecuteReader();
                    }
                    toast.showToastNotif(new ToastNotification("Brand Updated Successfully", Color.FromArgb(21, 101, 192), FontAwesome.Sharp.IconChar.CheckCircle), tabManage);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                txtBrandName.Clear();
                tabControl.TabPages.Add(tabBrandList);
                tabControl.TabPages.Remove(tabManage);
                loadAllBrands();
                toast.showToastNotif(new ToastNotification("Operation Cancelled", Color.FromArgb(198, 40, 40), FontAwesome.Sharp.IconChar.WindowClose), tabManage);
            }
        }
        private void frmBrand_Load(object sender, EventArgs e)
        {
            tabControl.TabPages.Remove(tabManage);
            loadAllBrands();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            tabControl.TabPages.Remove(tabBrandList);
            tabControl.TabPages.Add(tabManage);
            txtBrandID.Text = "This Field Is Autogenerated";
            btnSaveUpdate.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            tabControl.TabPages.Remove(tabManage);
            tabControl.TabPages.Add(tabBrandList);
            toast.showToastNotif(new ToastNotification("Operation Cancelled", Color.FromArgb(198, 40, 40), FontAwesome.Sharp.IconChar.WindowClose), tabBrandList);
            btnSave.Enabled = true;
            btnSaveUpdate.Enabled = true;
            loadAllBrands();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;

            if (txtBrandName.Text == "")
            {
                MessageBox.Show("Brand Name Cannot Be Empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(con))
                    {
                        conn.Open();
                        DataSet ds = new DataSet();
                        SqlCommand cmd = new SqlCommand(@"SELECT * FROM tblBrand WHERE Brand=@brand", conn);
                        cmd.Parameters.AddWithValue("@brand", txtBrandName.Text);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(ds);
                        int i = ds.Tables[0].Rows.Count;

                        if (i > 0)
                        {
                            MessageBox.Show("Failed to Add Brand. Brand Already Exists.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
                        else
                        {
                            insertBrand();
                            loadAllBrands();
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

        private void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            updateBrand();
            loadAllBrands();
            tabControl.TabPages.Remove(tabManage);
            tabControl.TabPages.Add(tabBrandList);
            txtBrandName.Clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            txtBrandID.Text = dataGridView.SelectedRows[0].Cells[1].Value.ToString();
            txtBrandName.Text = dataGridView.SelectedRows[0].Cells[2].Value.ToString();
            tabControl.TabPages.Remove(tabBrandList);
            tabControl.TabPages.Add(tabManage);
            btnSave.Enabled = false;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchBrand();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure to Remove This Brand?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    var con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
                    using (var connection = new SqlConnection(con))
                    using (var command = new SqlCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = @"DELETE FROM tblBrand Where brandID=@id";
                        command.Parameters.AddWithValue("@id", dataGridView.CurrentRow.Cells[1].Value.ToString());
                        command.ExecuteReader();
                    }
                    loadAllBrands();
                    toast.showToastNotif(new ToastNotification("Deleted Sucessfully", Color.FromArgb(16, 172, 132), FontAwesome.Sharp.IconChar.CheckCircle), tabBrandList);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                return;
            }
        }
    }
}

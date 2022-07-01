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
    public partial class frmVendor : Form
    {
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        Notification ntf = new Notification();
        public frmVendor()
        {
            InitializeComponent();
        }
        public void clear()
        {
            txtAddress.Clear();
            txtConPerson.Clear();
            txtContactNo.Clear();
            txtEmail.Clear();
            txtVendor.Clear();
        }
        public void searchVendor()
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
                    command.CommandText = @"SELECT vendorID, Vendor, Address, ContactPerson, contactNumber,Email 
                                            FROM tblVendor
                                            WHERE Vendor LIKE '"+txtSearch.Text+"%'";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            i += 1;
                            dataGridView.Rows.Add(i, reader["vendorID"].ToString(), reader["Vendor"].ToString(), reader["Address"].ToString(),
                                reader["ContactPerson"].ToString(), reader["contactNumber"].ToString(), reader["Email"].ToString());
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
        public void insertVendor()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(con))
                using (SqlCommand command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"INSERT INTO tblVendor (Vendor, contactNumber, Address, ContactPerson, Email)
                                        VALUES (@vendor, @cnumber, @address, @cperson, @email)";
                    command.Parameters.AddWithValue("@vendor", txtVendor.Text);
                    command.Parameters.AddWithValue("@cnumber", txtContactNo.Text);
                    command.Parameters.AddWithValue("@address", txtAddress.Text);
                    command.Parameters.AddWithValue("@cperson", txtConPerson.Text);
                    command.Parameters.AddWithValue("@email", txtEmail.Text);
                    command.ExecuteNonQuery();
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
        public void updateVendor()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"UPDATE tblVendor SET ContactPerson=@cperson, Address=@address, contactNumber=@cnumber,
                                            Email=@email WHERE vendorID LIKE @vid";
                    command.Parameters.AddWithValue("@vid", dataGridView.CurrentRow.Cells[1].Value.ToString());
                    command.Parameters.AddWithValue("@cperson", txtConPerson.Text);
                    command.Parameters.AddWithValue("@address", txtAddress.Text);
                    command.Parameters.AddWithValue("@cnumber", txtContactNo.Text);
                    command.Parameters.AddWithValue("@email", txtEmail.Text);
                    command.ExecuteNonQuery();
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
        public void loadVendor()
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
                    command.CommandText = @"SELECT vendorID, Vendor, Address, ContactPerson, contactNumber,Email 
                                            FROM tblVendor
                                            ORDER BY Vendor ASC";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            i += 1;
                            dataGridView.Rows.Add(i, reader["vendorID"].ToString(), reader["Vendor"].ToString(), reader["Address"].ToString(),
                                reader["ContactPerson"].ToString(), reader["contactNumber"].ToString(), reader["Email"].ToString());
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

        private void frmVendor_Load(object sender, EventArgs e)
        {
            tabControl.TabPages.Remove(tabManage);
            loadVendor();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
            ntf.notificationMessage(panelNotif1, labelNotif1, iconNotif1, "Operation Cancelled");
            ntf.notificationTimer(timer1, panelNotif1);
            tabControl.TabPages.Add(tabVendorList);
            tabControl.TabPages.Remove(tabManage);
        }

        private void btnBack2_Click(object sender, EventArgs e)
        {
            tabControl.TabPages.Remove(tabManage);
            tabControl.TabPages.Add(tabVendorList);
            clear();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            tabControl.TabPages.Remove(tabVendorList);
            tabControl.TabPages.Add(tabManage);

            txtVendor.Enabled = true;

            btnSaveUpdate.Enabled = false;
            btnSave.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtAddress.Text) || String.IsNullOrWhiteSpace(txtConPerson.Text) || String.IsNullOrWhiteSpace(txtContactNo.Text) ||
                String.IsNullOrWhiteSpace(txtEmail.Text) || String.IsNullOrWhiteSpace(txtVendor.Text))
            {
                ntf.errorMessage(panelNotif2, labelNotif2, iconNotif2, "A Field Is Empty");
                ntf.notificationTimer(timer1, panelNotif2);
            }
            else
            {
                if (MessageBox.Show("Add this Vendor?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(con))
                        {
                            connection.Open();
                            DataSet ds = new DataSet();
                            SqlCommand cmd = new SqlCommand(@"SELECT * FROM tblVendor WHERE Vendor=@vendor", connection);
                            cmd.Parameters.AddWithValue("@vendor", txtVendor.Text);
                            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                            adapter.Fill(ds);

                            int i = ds.Tables[0].Rows.Count;
                            if (i > 0)
                            {
                                ntf.errorMessage(panelNotif2, labelNotif2, iconNotif2, "Vendor Already Exists");
                                ntf.notificationTimer(timer1, panelNotif2);
                                return;
                            }
                            else
                            {
                                insertVendor();
                                ntf.notificationMessage(panelNotif1, labelNotif1, iconNotif1, "Vendor Added Successfully");
                                ntf.notificationTimer(timer1, panelNotif1);
                                ntf.notificationMessage(panelNotif2, labelNotif2, iconNotif2, "Vendor Added Successfully");
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            txtVendor.Text = dataGridView.SelectedRows[0].Cells[2].Value.ToString();
            txtConPerson.Text = dataGridView.SelectedRows[0].Cells[4].Value.ToString();
            txtAddress.Text = dataGridView.SelectedRows[0].Cells[3].Value.ToString();
            txtContactNo.Text = dataGridView.SelectedRows[0].Cells[5].Value.ToString();
            txtEmail.Text = dataGridView.SelectedRows[0].Cells[6].Value.ToString();

            txtVendor.Enabled = false;

            tabControl.TabPages.Remove(tabVendorList);
            tabControl.TabPages.Add(tabManage);

            btnSave.Enabled = false;
            btnSaveUpdate.Enabled = true;
        }

        private void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Update Vendor?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                updateVendor();
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
                tabControl.TabPages.Add(tabVendorList);
                tabControl.TabPages.Remove(tabManage);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure to Delete this Vendor?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    using (var connection = new SqlConnection(con))
                    using (var command = new SqlCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = @"DELETE FROM tblVendor WHERE vendorID=@id";
                        command.Parameters.AddWithValue("@id", dataGridView.CurrentRow.Cells[1].Value.ToString());
                        command.ExecuteReader();
                    }
                    loadVendor();
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
    }
}

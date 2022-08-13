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
        showToast toast = new showToast();
        AuditTrail log = new AuditTrail();
        MainForm main;
        public frmVendor(MainForm m)
        {
            main = m;
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
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                //logs
                log.loadUserID(main.lblUser.Text);
                log.insertAction("Add Vendor", "Added New Vendor : " +txtVendor.Text, this.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                //logs
                log.loadUserID(main.lblUser.Text);
                log.insertAction("Edit Vendor", txtVendor.Text, this.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            toast.showToastNotif(new ToastNotification("Operation Cancelled.", Color.FromArgb(21, 101, 192), FontAwesome.Sharp.IconChar.Ban), tabVendorList);
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
                toast.showToastNotif(new ToastNotification("A Field is Empty.", Color.FromArgb(198, 40, 40), FontAwesome.Sharp.IconChar.ExclamationCircle), tabManage);
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
                                toast.showToastNotif(new ToastNotification("Vendor Already Exists.", Color.FromArgb(21, 101, 192), FontAwesome.Sharp.IconChar.Ban), tabManage);
                                return;
                            }
                            else
                            {
                                insertVendor();
                                toast.showToastNotif(new ToastNotification("Vendor Added Successfully", Color.FromArgb(16, 172, 132), FontAwesome.Sharp.IconChar.CheckCircle), tabManage);
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
                    toast.showToastNotif(new ToastNotification("Operation Cancelled.", Color.FromArgb(21, 101, 192), FontAwesome.Sharp.IconChar.Ban), tabManage);
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
                toast.showToastNotif(new ToastNotification("Vendor Updated Successfully", Color.FromArgb(16, 172, 132), FontAwesome.Sharp.IconChar.CheckCircle), tabManage);
                clear();
        }
            else
            {
                clear();
                tabControl.TabPages.Add(tabVendorList);
                tabControl.TabPages.Remove(tabManage);
                toast.showToastNotif(new ToastNotification("Operation Cancelled.", Color.FromArgb(21, 101, 192), FontAwesome.Sharp.IconChar.Ban), tabVendorList);
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
                    //logs
                    log.loadUserID(main.lblUser.Text);
                    log.insertAction("Delete", "Deleted Vendor: " +dataGridView.CurrentRow.Cells[2].Value.ToString(), this.Text);
                    loadVendor();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                toast.showToastNotif(new ToastNotification("Operation Cancelled.", Color.FromArgb(21, 101, 192), FontAwesome.Sharp.IconChar.Ban), tabVendorList);
            }
        }
    }
}

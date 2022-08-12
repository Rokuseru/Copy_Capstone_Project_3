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
    public partial class frmAccounts : Form
    {
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        showToast toast = new showToast();
        private int uid = 0;
        private string pw = " ";
        AuditTrail trail = new AuditTrail();
        public frmAccounts()
        {
            InitializeComponent();
        }
        public void clear()
        {
            txtConfirmPw.Clear();
            txtFname.Clear();
            txtUname.Clear();
            txtConfirmPw.Clear();
            cbRole.SelectedIndex = -1;
        }
        public void clearTab2()
        {
            cbUsers2.Text = " ";
            txtOldPassword.Clear();
            txtPassword2.Clear();
            txtConfPassword2.Clear();
        }
        public void addUser()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"INSERT INTO tblUsers (Name, lastName, username, password, role) 
                                                VALUES (@Name, @username, @password, @role)";
                    command.Parameters.AddWithValue("@Name", txtFname.Text);
                    command.Parameters.AddWithValue("@username", txtUname.Text);
                    command.Parameters.AddWithValue("@password", txtPassword.Text);
                    command.Parameters.AddWithValue("@role", cbRole.Text);
                    command.ExecuteNonQuery();

                    toast.showToastNotif(new ToastNotification("User Added Successfully.", Color.FromArgb(21, 101, 192), FontAwesome.Sharp.IconChar.CheckCircle), tabAdd);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void loadUser()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT userID, Name FROM tblusers";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cbUsers2.Items.Add(reader["Name"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loaduserID()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT * FROM tblusers WHERE Name LIKE @name";
                    command.Parameters.AddWithValue("@name", cbUsers2.Text);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read()) 
                        { 
                            uid = int.Parse(reader["userID"].ToString());
                            pw = reader["password"].ToString();
                        }
                    }              
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void updatePassword()
        {
            try
            {
                if (txtOldPassword.Text != pw)
                {
                    toast.showToastNotif(new ToastNotification("Old Password is Incorrect.", Color.FromArgb(198, 40, 40), FontAwesome.Sharp.IconChar.WindowClose), tabUpdate);
                }
                else if (txtPassword2.Text != txtConfPassword2.Text)
                {
                    toast.showToastNotif(new ToastNotification("Passwords Does Not Match.", Color.FromArgb(198, 40, 40), FontAwesome.Sharp.IconChar.WindowClose), tabUpdate);
                }
                else if (txtConfPassword2.Text == " " || txtConfPassword2.Text == " ")
                {
                    toast.showToastNotif(new ToastNotification("A Field is Empty.", Color.FromArgb(198, 40, 40), FontAwesome.Sharp.IconChar.WindowClose), tabUpdate);
                }
                else
                {
                    using (var connection = new SqlConnection(con))
                    using (var command = new SqlCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = @"UPDATE tblUsers SET password = @password WHERE userID LIKE @uid";
                        command.Parameters.Add("@password", SqlDbType.VarChar);
                        command.Parameters.Add("@uid", SqlDbType.Int);
                        command.Parameters["@password"].Value = txtConfPassword2.Text;
                        command.Parameters["@uid"].Value = uid;
                        command.ExecuteNonQuery();

                        toast.showToastNotif(new ToastNotification("Password Updated Successfully.", Color.FromArgb(198, 40, 40), FontAwesome.Sharp.IconChar.WindowClose), tabUpdate);
                        clearTab2();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        public void loadUsers()
        {
            int i = 0;
            dataGridView.Rows.Clear();
            using (var connection = new SqlConnection(con))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"SELECT userID, Name, role, status FROM tblUsers WHERE status = 'Active'";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        i++;
                        dataGridView.Rows.Add(i, reader["userID"].ToString(), reader["Name"].ToString(), reader["role"].ToString(), reader["status"].ToString());
                    }
                }
            }
        }
        public void disableUser()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"UPDATE tblUsers SET status = 'Disabled' WHERE userID LIKE @uid";
                    command.Parameters.Add("@uid", SqlDbType.Int);
                    command.Parameters["@uid"].Value = int.Parse(dataGridView.Rows[0].Cells["userID"].Value.ToString());
                    command.ExecuteNonQuery();

                    toast.showToastNotif(new ToastNotification("User Disabled Successfully.", Color.FromArgb(21, 101, 192), FontAwesome.Sharp.IconChar.CheckCircle), tabManage);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAccounts_Load(object sender, EventArgs e)
        {
            loadUsers();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            clear();
            this.Dispose();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPassword.Text != txtConfirmPw.Text)
                {
                    toast.showToastNotif(new ToastNotification("Password Does Not Match.", Color.FromArgb(198, 40, 40), FontAwesome.Sharp.IconChar.WindowClose), tabAdd);
                }
                else
                {
                    addUser();
                    clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbUsers2_SelectedIndexChanged(object sender, EventArgs e)
        {
            loaduserID();
        }

        private void btnSaveUpdate_Click(object sender, EventArgs e)
        {
            updatePassword();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colname = dataGridView.Columns[e.ColumnIndex].Name;

            if (colname == "disable")
            {
                if (MessageBox.Show("Disable User?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
                {
                    disableUser();
                }
                else
                {
                    return;
                }
            }
        }
    }
}

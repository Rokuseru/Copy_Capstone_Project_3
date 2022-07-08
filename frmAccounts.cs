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
        Notification ntf = new Notification();
        private int uid = 0;
        private string pw = " ";
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

                    ntf.notificationMessage(panelNotif1, labelNotif1, iconNotif1, "User Added.");
                    ntf.notificationTimer(timer1, panelNotif1);
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
                MessageBox.Show(ex.Message);
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
                MessageBox.Show(ex.Message);
            }
        }
        public void updatePassword()
        {
            try
            {
                if (txtOldPassword.Text != pw)
                {
                    ntf.errorMessage(panelNotif2, labelNotif2, iconNotif2, "Old Password Incorrect!");
                    ntf.notificationTimer(timer1, panelNotif2);
                }
                else if (txtPassword2.Text != txtConfPassword2.Text)
                {
                    ntf.errorMessage(panelNotif2, labelNotif2, iconNotif2, "Passwords Does Not Match!");
                    ntf.notificationTimer(timer1, panelNotif2);
                }
                else if (txtConfPassword2.Text == " " || txtConfPassword2.Text == " ")
                {
                    ntf.errorMessage(panelNotif2, labelNotif2, iconNotif2, "A Field Is Empty!");
                    ntf.notificationTimer(timer1, panelNotif2);
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

                        ntf.notificationMessage(panelNotif2, labelNotif2, iconNotif2, "Updated Sucessfully");
                        ntf.notificationTimer(timer1, panelNotif2);
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
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    ntf.errorMessage(panelNotif1, labelNotif1, iconNotif1, "Password Did Not Match.");
                    ntf.notificationTimer(timer1, panelNotif1);
                }
                else
                {
                    addUser();
                    ntf.notificationMessage(panelNotif1, labelNotif1, iconNotif1, "User Added Sucessfully");
                    ntf.notificationTimer(timer1, panelNotif1);
                    clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    ntf.notificationMessage(notifPanel3, lblNotif3, notifIcon3, "User Disabled Sucessfully");
                    ntf.notificationTimer(timer1, notifPanel3);
                }
                else
                {
                    return;
                }
            }
        }
    }
}

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
        AuditTrail log = new AuditTrail();
        MainForm main;
        public frmAccounts(MainForm m)
        {
            InitializeComponent();
            main = m;
            tab.TabPages.Remove(tabManageUsers);
        }
        private void initiatePositons()
        {
            txtPassword.Location = new Point(249, 205);
            txtConfirmPw.Location = new Point(249, 236);
            lblPassword.Location = new Point(125, 208);
            lblCpassword.Location = new Point(125, 239);
            btnAddNew.Location = new Point(282, 277);
            btnSaveUpdate.Location = new Point(403, 277);
            btnCancel.Location = new Point(529, 277);
            lblOldPassword.Visible = false;
            txtOldPassword.Visible = false;
        }
        private void newPositions()
        {
            txtPassword.Location = new Point(this.txtPassword.Location.X, this.txtPassword.Location.Y);
            lblPassword.Location = new Point(125, 239);
            txtConfirmPw.Location = new Point(249, 267);
            lblCpassword.Location = new Point(125, 270);
            btnAddNew.Location = new Point(282, 308);
            btnSaveUpdate.Location = new Point(403, 308);
            btnCancel.Location = new Point(529, 308);
            lblOldPassword.Visible = true;
            txtOldPassword.Visible = true;
        }
        public void clear()
        {
            txtConfirmPw.Clear();
            txtFname.Clear();
            txtUname.Clear();
            txtConfirmPw.Clear();
            txtEmail.Clear();
            txtEmailPassword.Clear();
            cbRole.SelectedIndex = -1;
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
                    command.CommandText = @"INSERT INTO tblUsers (Name, username, password, email, emailPassword,role) 
                                                VALUES (@Name, @username, @password, @email, @emailpw, @role)";
                    command.Parameters.AddWithValue("@Name", txtFname.Text);
                    command.Parameters.AddWithValue("@username", txtUname.Text);
                    command.Parameters.AddWithValue("@password", txtPassword.Text);
                    command.Parameters.AddWithValue("@role", cbRole.Text);
                    command.Parameters.AddWithValue("@email", txtEmail.Text);
                    command.Parameters.AddWithValue("@emailpw", txtEmailPassword.Text);
                    command.ExecuteNonQuery();

                    toast.showToastNotif(new ToastNotification("User Added Successfully.", Color.FromArgb(21, 101, 192), FontAwesome.Sharp.IconChar.CheckCircle), tabManageUsers);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    command.Parameters.AddWithValue("@name", txtFname.Text);
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
        public void updateUser()
        {
            try
            {
                if (txtOldPassword.Text != pw)
                {
                    toast.showToastNotif(new ToastNotification("Old Password is Incorrect.", Color.FromArgb(198, 40, 40), FontAwesome.Sharp.IconChar.WindowClose), tabManageUsers);
                }
                else if (txtPassword.Text != txtConfirmPw.Text)
                {
                    toast.showToastNotif(new ToastNotification("Passwords Does Not Match.", Color.FromArgb(198, 40, 40), FontAwesome.Sharp.IconChar.WindowClose), tabManageUsers);
                }
                else if (txtConfirmPw.Text == " " || txtConfirmPw.Text == " ")
                {
                    toast.showToastNotif(new ToastNotification("A Field is Empty.", Color.FromArgb(198, 40, 40), FontAwesome.Sharp.IconChar.WindowClose), tabManageUsers);
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
                        command.Parameters["@password"].Value = txtConfirmPw.Text;
                        command.Parameters["@uid"].Value = uid;
                        command.ExecuteNonQuery();

                        toast.showToastNotif(new ToastNotification("Password Updated Successfully.", Color.FromArgb(198, 40, 40), FontAwesome.Sharp.IconChar.WindowClose), tabManageUsers);
                        clear();
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
                command.CommandText = @"SELECT userID, Name, email,role, status FROM tblUsers WHERE status = 'Active'";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        i++;
                        dataGridView.Rows.Add(i, reader["userID"].ToString(), reader["Name"].ToString(), reader["email"].ToString(), reader["role"].ToString(), reader["status"].ToString());
                    }
                }
            }
        }
        private void searchUser()
        {
            try
            {
                int i = 0;
                dataGridView.Rows.Clear();

                using (var connecion = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connecion.Open();
                    command.Connection = connecion;
                    command.CommandText = @"SELECT userID, Name, email,role, status FROM tblUsers WHERE status = 'Active' AND Name LIKE '%"+txtSearch.Text+"%'";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            i++;
                            dataGridView.Rows.Add(i, reader["userID"].ToString(), reader["Name"].ToString(), reader["email"].ToString(), reader["role"].ToString(), reader["status"].ToString());
                        }
                    }

                }
            }
            catch (Exception ex)
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
                    toast.showToastNotif(new ToastNotification("Password Does Not Match.", Color.FromArgb(198, 40, 40), FontAwesome.Sharp.IconChar.WindowClose), tabManageUsers);
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
        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colname = dataGridView.Columns[e.ColumnIndex].Name;

            if (colname == "disable")
            {
                if (MessageBox.Show("Disable User?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
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
                            command.Parameters["@uid"].Value = int.Parse(dataGridView.CurrentRow.Cells["userID"].Value.ToString());
                            command.ExecuteNonQuery();

                            log.loadUserID(main.lblUser.Text);
                            log.insertAction("Deactivate User", "Deactivated User: " + this.dataGridView.CurrentRow.Cells["name"].Value.ToString(), "Account Module");

                            toast.showToastNotif(new ToastNotification("User Disabled Successfully.", Color.FromArgb(21, 101, 192), FontAwesome.Sharp.IconChar.CheckCircle), tabUserList);
                        }
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

        private void tab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tab.SelectedTab == tab.TabPages["tabUserList"])
            {
                loadUsers();
            }
            else if (tab.SelectedTab == tab.TabPages["tabUserList"])
            {
                //loadUser();
            }
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            initiatePositons();
            tab.TabPages.Remove(tabUserList);
            tab.TabPages.Add(tabManageUsers);
        }
        //Button cancel
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            initiatePositons();
            tab.TabPages.Remove(tabManageUsers);
            tab.TabPages.Add(tabUserList);
        }

        private void btnSaveUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdateUser_Click(object sender, EventArgs e)
        {
            tab.TabPages.Remove(tabUserList);
            tab.TabPages.Add(tabManageUsers);
            newPositions();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchUser();
        }
    }
}

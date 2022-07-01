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
        private void btnBack_Click(object sender, EventArgs e)
        {
            clear();
            this.Dispose();
        }

        private void frmAccounts_Load(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            clear();
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
                    clear();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

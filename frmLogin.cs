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
using CapstoneProject_3.POS_System;

namespace CapstoneProject_3
{
    public partial class frmLogin : Form
    {
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        public bool found = false;
        AuditTrail log = new AuditTrail();
        public frmLogin()
        {
            InitializeComponent();
            KeyPreview = true;
        }

        public void clear()
        {
            txtPassword.Clear();
            txtUsername.Clear();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
            Application.Exit();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimizeWindow_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string _username = " ";
            string _role = " ";
            string _Name = " ";
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT * from tblUsers WHERE username = @username AND password = @password";
                    command.Parameters.AddWithValue("@username", txtUsername.Text);
                    command.Parameters.AddWithValue("@password", txtPassword.Text);
                    command.ExecuteNonQuery();
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        if (reader.HasRows)
                        {
                             found = true;
                            _username = reader["username"].ToString();
                            _role = reader["role"].ToString();
                            _Name = reader["Name"].ToString();
                        }
                        else
                        {
                            found = false;
                        }

                        if (found == true)
                        {
                            if (_role == "Admin")
                            {
                                MainForm admin = new MainForm();
                                MessageBox.Show("Login Sucessful. Welcome, " + _Name + "!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                clear();
                                admin.lblRole.Text = _role;
                                admin.lblUser.Text = _Name;
                                this.Hide();
                                admin.ShowDialog();
                                //Logs
                                log.loadUserID(_Name);
                                log.insertAction("Login", "Admin", this.Text);
                            }
                            else if (_role == "Cashier")
                            {
                                frmPOS pos = new frmPOS();
                                MessageBox.Show("Login Sucessful. Welcome, " + _Name + "!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                clear();
                                pos.lblUser.Text = _Name;
                                pos.lblRole.Text = _role + " | ";
                                this.Hide();
                                pos.ShowDialog();
                                //Logs
                                log.loadUserID(_Name);
                                log.insertAction("Login", "Cashier", this.Text);
                            }
                            else
                            {
                                MessageBox.Show("Login Failed. User Not Found!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Login Failed. User Not Found!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }
    }
}

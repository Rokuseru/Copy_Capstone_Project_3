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

namespace CapstoneProject_3.POS_System
{
    public partial class frmZReport : Form
    {
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        public frmZReport()
        {
            InitializeComponent();
        }
        private void loadUsers()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT * FROM tblUsers WHERE status = 'Active'";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cbUsers.Items.Add(reader["Name"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmZReport_Load(object sender, EventArgs e)
        {
            loadUsers();
        }
    }
}

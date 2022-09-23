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
    public partial class frmAuthorization : Form
    {
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        AuditTrail log = new AuditTrail();
        frmPOS fpos;
        public frmAuthorization(frmPOS fpos)
        {
            InitializeComponent();
            this.fpos = fpos;
        }

        private void btnGrant_Click(object sender, EventArgs e)
        {
            try
            {
                frmDiscount disc = new frmDiscount(fpos);

                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT * FROM tblUsers WHERE username LIKE @uname AND password LIKE @pword AND status = 'Active'";
                    command.Parameters.AddWithValue("@uname",txtUsername.Text);
                    command.Parameters.AddWithValue("@pword", txtPassword.Text);

                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        if (reader.HasRows)
                        {
                            disc.addDiscount();
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Source);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}

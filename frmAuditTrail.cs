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

namespace CapstoneProject_3
{
    public partial class frmAuditTrail : Form
    {
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        public frmAuditTrail()
        {
            InitializeComponent();
        }
        private void loadAuditTrail()
        {
            try
            {
                dataGridView.Rows.Clear();

                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT action, u.Name, value, module, date, time FROM tblAuditTrail AS a
                                            INNER JOIN tblUsers AS u ON a.userID = u.userID";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dataGridView.Rows.Add(reader["action"].ToString(), reader["value"].ToString(), reader["Name"].ToString(), reader["module"].ToString(),
                                Convert.ToDateTime(reader["date"].ToString()).ToString("ddd, MMM, yyyy"), Convert.ToDateTime(reader["time"].ToString()).ToString("hh:mm:ss tt"));
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmAuditTrail_Load(object sender, EventArgs e)
        {
            loadAuditTrail();
        }
    }
}

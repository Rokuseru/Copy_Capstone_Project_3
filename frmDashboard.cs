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
using System.Globalization;

namespace CapstoneProject_3
{
    public partial class frmDashboard : Form
    {
        CultureInfo culture = CultureInfo.GetCultureInfo("en-PH");
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        public double dailySales = 0;
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            loadDailySales();
            lblDailySales.Text = dailySales.ToString("C", culture);

        }
        public void loadDailySales()
        {
            try
            {
                string dateFrom = DateTime.Now.ToString("yyyy-MM-dd");

                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT ISNULL(SUM(Total),0) AS TOTAL_SALES FROM tblCart
                                            WHERE sDate LIKE @dateFrom";
                    command.Parameters.AddWithValue("@dateFrom", dateFrom);
                    dailySales = double.Parse(command.ExecuteScalar().ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.Source);
            }
        }
    }
}

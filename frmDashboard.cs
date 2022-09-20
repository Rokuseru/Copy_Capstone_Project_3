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
using System.Windows.Forms.DataVisualization.Charting;

namespace CapstoneProject_3
{
    public partial class frmDashboard : Form
    {
        CultureInfo culture = CultureInfo.GetCultureInfo("en-PH");
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        private double dailySales = 0;
        private int productLine = 0;
        private int stockOnHand = 0;
        private int criticalStock = 0;
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            loadDailySales();
            loadProductLine();
            loadStockOnhand();
            loadCriticalStock();
            loadYearlyChart();
            loadTopSellingChart();
            lblDailySales.Text = dailySales.ToString("C", culture);
            lblProductLine.Text = productLine.ToString();
            lblStockOnHand.Text = stockOnHand.ToString();
            lblCriticalStock.Text = criticalStock.ToString();

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
        public void loadProductLine()
        {
            using (var connection = new SqlConnection(con))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"SELECT COUNT(*) AS product_Count FROM tblProduct";
                productLine = int.Parse(command.ExecuteScalar().ToString());
            }
        }
        public void loadStockOnhand()
        {
            using (var connection = new SqlConnection(con))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"SELECT ISNULL(SUM(quantity),0) AS Stock_On_Hand FROM tblProduct";
                stockOnHand = int.Parse(command.ExecuteScalar().ToString());
            }
        }
        public void loadCriticalStock()
        {
            using (var connection = new SqlConnection(con))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"SELECT COUNT(*) AS Critical_Stock FROM viewCriticalStock WHERE quantity < reorder";
                criticalStock = int.Parse(command.ExecuteScalar().ToString());
            }
        }
        public void loadYearlyChart()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    SqlCommand cmd = new SqlCommand(@"SELECT YEAR(sDate) AS Yearly_Sales, ISNULL(SUM(Total), 0.00) AS Total_Sales FROM tblCart WHERE status LIKE 'Sold' GROUP BY YEAR(sDate)", connection);
                    adapter.SelectCommand = cmd;
                    DataSet ds = new DataSet();

                    adapter.Fill(ds);

                    this.chart1.DataSource = ds.Tables[0];
                    //X-Value
                    this.chart1.Series[0].XValueMember = "Yearly_Sales";
                    //Y-Value
                    this.chart1.Series[0].YValueMembers = "Total_Sales";
                    //Chart Properties
                    this.chart1.Series[0].IsValueShownAsLabel = true;
                 
                    this.chart1.DataBind();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Source, ex.GetType());
            }
        }
        public void loadTopSellingChart()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    SqlCommand cmd = new SqlCommand(@"SELECT Description, SUM(qty) AS qty, ISNULL(SUM(Total), 0.00) AS Total FROM viewSoldItems
                                                      WHERE Status LIKE 'Sold'
                                                     GROUP BY Description
                                                     ORDER BY qty DESC", connection);
                    adapter.SelectCommand = cmd;
                    DataSet ds = new DataSet();

                    adapter.Fill(ds);
                    this.chart2.DataSource = ds.Tables[0];
                    //X-Value
                    this.chart2.Series[0].XValueMember = "Description";
                    //Y-Value
                    this.chart2.Series[0].YValueMembers = "qty";
                    //Chart Properties
                    this.chart2.Series[0].IsValueShownAsLabel = true;
                    this.chart2.Series[0].ChartType = SeriesChartType.Doughnut;
                    this.chart2.DataBind();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

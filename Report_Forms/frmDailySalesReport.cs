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
using Microsoft.Reporting.WinForms;
using CapstoneProject_3.Datasets;
using CapstoneProject_3.POS_System;

namespace CapstoneProject_3.Report_Forms
{
    public partial class frmDailySalesReport : Form
    {
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        frmDailySales fds;
        public frmDailySalesReport(frmDailySales ds)
        {
            InitializeComponent();
            fds = ds;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmDailySalesReport_Load(object sender, EventArgs e)
        { 
            this.reportViewer1.RefreshReport();
        }
        public void loadReport()
        {
            try
            {         
                reportViewer1.ProcessingMode = ProcessingMode.Local;
                this.reportViewer1.LocalReport.ReportPath = @"C:\Users\Roxelle\source\repos\Capstone\CapstoneProject_3\Datasets\rwDailySalesReport.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();

                ReportDataSource rds;

                using (var connection = new SqlConnection(con))
                {
                    connection.Open();
                    DataSetDailySalesReport ds = new DataSetDailySalesReport();
                    //Sql Command
                    SqlCommand cmd = new SqlCommand(@"SELECT c.cartID, c.TransactionNo, p.Description, p.ProductCode, c.Price, c.qty, c.discount, c.Total 
                                            FROM tblCart AS c
                                            INNER JOIN tblProduct AS p ON c.productID = p.productID
                                            WHERE Status LIKE 'Sold'
                                            AND sDate BETWEEN @dateFrom AND @dateTo", connection);
                    cmd.Parameters.AddWithValue("@dateFrom", fds.dateFrom.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@dateTo", fds.dateTo.Value.ToString("yyyy-MM-dd"));

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds.Tables["dtDailySalesReport"]);
      
                    rds = new ReportDataSource("DataSetDailySalesReport", ds.Tables["dtDailySalesReport"]);
                    reportViewer1.LocalReport.DataSources.Add(rds);
                    reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                    reportViewer1.ZoomMode = ZoomMode.Percent;
                    reportViewer1.ZoomPercent = 80;

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

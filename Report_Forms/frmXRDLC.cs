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
    public partial class frmXRDLC : Form
    {
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        frmXReport xReport;
        public frmXRDLC(frmXReport x)
        {
            InitializeComponent();
            xReport = x;
        }
        public void loadXReportRDLC()
        {
            try
            {
                reportViewer.ProcessingMode = ProcessingMode.Local;
                this.reportViewer.LocalReport.ReportPath = @"C:\Users\Roxelle\source\repos\Capstone\CapstoneProject_3\Datasets\rwZReport.rdlc";
                this.reportViewer.LocalReport.DataSources.Clear();

                ReportDataSource rds;

                using (var connection = new SqlConnection(con))
                {
                    connection.Open();
                    DataSetXZReport report = new DataSetXZReport();
                    SqlCommand cmd = new SqlCommand(@"SELECT COUNT(TransactionID) AS Transactions, u.Name, s.Method, sum(s.Discount) AS DISCOUNT, sum(s.Total_Sales) AS sales, s.date FROM tblSales AS s
                                                 INNER JOIN tblUsers AS u ON s.userID = u.userID
                                                 WHERE u.userID LIKE @uid
                                                 AND DATE LIKE @date
                                                 AND time BETWEEN @timeIn AND @timeOut
                                                 GROUP BY u.Name, Method, date", connection);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@uid", xReport.userID);
                    cmd.Parameters.AddWithValue("@timeIn", xReport.timeIn);
                    cmd.Parameters.AddWithValue("@timeOut", xReport.timeOut);

                    DataSetXZReport z = new DataSetXZReport();
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(z.Tables["dtXReport"]);

                    //Parameters
                    ReportParameter pDate = new ReportParameter("pDate", DateTime.Now.ToString("yyyy-MM-dd"));
                    ReportParameter pUser = new ReportParameter("pUser", xReport.cbUsers.Text);
                    ReportParameter pOpenedOn = new ReportParameter("pOpenedOn", xReport.lblOpenedOn.Text);
                    ReportParameter pSoldProducts = new ReportParameter("pSoldProducts", xReport.lblSoldItems.Text);
                    ReportParameter pTransactions = new ReportParameter("pTransactions", xReport.lblSoldItems.Text);
                    ReportParameter pTotalSales = new ReportParameter("pTotalSales", xReport.lblSoldItems.Text);

                    //Set the paramters
                    reportViewer.LocalReport.SetParameters(pDate);
                    reportViewer.LocalReport.SetParameters(pUser);
                    reportViewer.LocalReport.SetParameters(pOpenedOn);
                    reportViewer.LocalReport.SetParameters(pSoldProducts);
                    reportViewer.LocalReport.SetParameters(pTransactions);
                    reportViewer.LocalReport.SetParameters(pTotalSales);

                    rds = new ReportDataSource("rwXReport", z.Tables["dtXReport"]);
                    reportViewer.LocalReport.DataSources.Add(rds);
                    reportViewer.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                    reportViewer.ZoomMode = ZoomMode.Percent;
                    reportViewer.ZoomPercent = 80;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Source);
                MessageBox.Show(ex.Message);
            }

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}

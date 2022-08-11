using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using CapstoneProject_3.Datasets;
using CapstoneProject_3.POS_System;
using System.Data.SqlClient;


namespace CapstoneProject_3.Report_Forms
{
    public partial class frmZRDLC : Form
    {
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        frmZReport zReport;
        public frmZRDLC(frmZReport z)
        {
            InitializeComponent();
            zReport = z;
        }

        private void frmXandYRDLC_Load(object sender, EventArgs e)
        {

            this.reportViewer.RefreshReport();
        }
        public void loadZReport()
        {
            try
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
                                                 WHERE DATE LIKE @date
                                                 AND time BETWEEN @timeIn AND @timeOut
                                                 GROUP BY u.Name, Method, date", connection);
                        cmd.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));
                        cmd.Parameters.AddWithValue("@timeIn", zReport.timeIn);
                        cmd.Parameters.AddWithValue("@timeOut", zReport.timeOut);

                        DataSetXZReport z = new DataSetXZReport();
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(z.Tables["dtZReport"]);

                        //Parameters
                        ReportParameter pDate = new ReportParameter("pDate", DateTime.Now.ToString("yyyy-MM-dd"));
                        ReportParameter pUser = new ReportParameter("pUser", zReport.cbUsers.Text);
                        ReportParameter pSoldProducts = new ReportParameter("pSoldProducts", zReport.lblSoldItems.Text);
                        ReportParameter pTransactions = new ReportParameter("pTransactions", zReport.lblTransactions.Text);
                        ReportParameter pTotalSales = new ReportParameter("pTotalSales", zReport.lblTotalSales.Text);
                        ReportParameter pCash = new ReportParameter("pCash", zReport.txtCash.Text);
                        ReportParameter pOthers = new ReportParameter("pOthers", zReport.txtOthers.Text);
                        ReportParameter pRefund = new ReportParameter("pRefund", zReport.txtRefund.Text);
                        ReportParameter pDiscount = new ReportParameter("pDiscount", zReport.txtDiscount.Text);
                        ReportParameter pTax = new ReportParameter("pTax", zReport.txtTax.Text);

                        //Set the paramters
                        reportViewer.LocalReport.SetParameters(pDate);
                        reportViewer.LocalReport.SetParameters(pUser);
                        reportViewer.LocalReport.SetParameters(pSoldProducts);
                        reportViewer.LocalReport.SetParameters(pTotalSales);
                        reportViewer.LocalReport.SetParameters(pTransactions);
                        reportViewer.LocalReport.SetParameters(pCash);
                        reportViewer.LocalReport.SetParameters(pOthers);
                        reportViewer.LocalReport.SetParameters(pRefund);
                        reportViewer.LocalReport.SetParameters(pDiscount);
                        reportViewer.LocalReport.SetParameters(pTax);

                        rds = new ReportDataSource("rwZReport", z.Tables["dtZReport"]);
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
                }         
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}

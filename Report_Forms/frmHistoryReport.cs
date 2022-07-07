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

namespace CapstoneProject_3.Report_Forms
{
    public partial class frmHistoryReport : Form
    {
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        frmHistory his;
        public frmHistoryReport(frmHistory hs)
        {
            InitializeComponent();
            his = hs;
        }
        public void loadStockIn()
        {
            try
            {
                ReportDataSource ds;
                his = new frmHistory();

                reportViewer1.ProcessingMode = ProcessingMode.Local;
                this.reportViewer1.LocalReport.ReportPath = @"C:\Users\Roxelle\source\repos\Capstone\CapstoneProject_3\Datasets\rwStockIn.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();

                using (var connection = new SqlConnection(con))
                {
                    connection.Open();
                    DataSetReports stockIn = new DataSetReports();
                    SqlCommand cmd = new SqlCommand(@"SELECT se.RefNumber,p.ProductCode ,p.Description, v.Vendor, RecievedBy,qty,StockInDate FROM tblStockEntry AS se
                                                      INNER JOIN tblProduct AS p ON se.productID = p.productID
                                                      INNER JOIN tblVendor AS v ON v.vendorID = se.vendorID
                                                      WHERE Status like 'Done'", connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(stockIn.Tables["dtStockIn"]);

                    //Parameters
                    ReportParameter pDate = new ReportParameter("pDate", "DATE FROM: " + his.dateFrom4.Value.ToString("yyyy-MM-dd") + " TO: " + his.dateTo4.Value.ToString("yyyy-MM-dd"));
                    reportViewer1.LocalReport.SetParameters(pDate);

                    ds = new ReportDataSource("rwStockIn", stockIn.Tables["dtStockIn"]);
                    reportViewer1.LocalReport.DataSources.Add(ds);
                    reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                    reportViewer1.ZoomMode = ZoomMode.Percent;
                    reportViewer1.ZoomPercent = 80;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}

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
    public partial class frmTopSellingReport : Form
    {
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        frmRecords rec;
        public frmTopSellingReport(frmRecords records)
        {
            InitializeComponent();
            rec = records;
        }
        public void loadTopTenReport()
        {
            try
            {
                ReportDataSource ds;

                reportViewer1.ProcessingMode = ProcessingMode.Local;
                this.reportViewer1.LocalReport.ReportPath = @"C:\Users\Roxelle\source\repos\Capstone\CapstoneProject_3\Datasets\rwTopTenSelling.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();

                using (var connection = new SqlConnection(con))
                {
                    connection.Open();
                    DataSetReports topSelling = new DataSetReports();

                    //Command
                    SqlCommand cmd = new SqlCommand(@"SELECT TOP 10 ProductCode, Description, SUM(qty) AS qty FROM viewSoldItems 
                                            WHERE sDate Between @dFrom AND @dTo
                                            AND Status LIKE 'Sold' 
                                            GROUP BY Description,ProductCode
                                            ORDER BY qty DESC", connection);
                    cmd.Parameters.AddWithValue("@dFrom", rec.dateFrom.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@dTo", rec.dateTo.Value.ToString("yyyy-MM-dd"));

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(topSelling.Tables["dtTopSelling"]);

                    ReportParameter pDate = new ReportParameter("pDate", "DATE FROM: " + rec.dateFrom.Value.ToString("yyyy-MM-dd") + " TO: " + rec.dateTo.Value.ToString("yyyy-MM-dd"));
                    reportViewer1.LocalReport.SetParameters(pDate);

                    ds = new ReportDataSource("rwTopTenSelling", topSelling.Tables["dtTopSelling"]);
                    reportViewer1.LocalReport.DataSources.Add(ds);
                    reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                    reportViewer1.ZoomMode = ZoomMode.Percent;
                    reportViewer1.ZoomPercent = 100;
                }
            }
            catch (Exception ex)
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

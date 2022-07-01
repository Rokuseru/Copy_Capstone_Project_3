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
using System.Data.SqlClient;
using CapstoneProject_3.Datasets;

namespace CapstoneProject_3.Report_Forms
{
    public partial class frmInventoryReport : Form
    {
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        public frmInventoryReport()
        {
            InitializeComponent();
        }

        private void frmInventoryReport_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
        public void loadInventoryReport()
        {
            try
            {
                ReportDataSource ds;

                reportViewer1.ProcessingMode = ProcessingMode.Local;
                this.reportViewer1.LocalReport.ReportPath = @"C:\Users\Roxelle\source\repos\Capstone\CapstoneProject_3\Datasets\rwInventoryReport.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();

                using (var connection = new SqlConnection(con))
                {
                    connection.Open();
                    DataSetReports invReports = new DataSetReports();

                    //Command
                    SqlCommand cmd = new SqlCommand(@"SELECT p.ProductCode, p.Barcode, p.Description, b.Brand, c.Category, p.Price, p.reorder, p.quantity FROM tblProduct AS p
                                                      INNER JOIN tblBrand AS b ON p.brandID = b.brandID
                                                      INNER JOIN tblCategory AS c ON p.categoryID = c.categoryID", connection);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(invReports.Tables["dtInventory"]);

                    ds = new ReportDataSource("rwInventoryReport", invReports.Tables["dtInventory"]);
                    reportViewer1.LocalReport.DataSources.Add(ds);
                    reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                    reportViewer1.ZoomMode = ZoomMode.Percent;
                    reportViewer1.ZoomPercent = 80;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

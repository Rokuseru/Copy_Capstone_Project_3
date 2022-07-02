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
        frmRecords rec;
        public frmInventoryReport(frmRecords records)
        {
            InitializeComponent();
            rec = records;
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
                            
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Top Ten Sold
        public void loadTopTen()
        {
            try
            {
                ReportDataSource ds;

                this.reportViewer1.ProcessingMode = ProcessingMode.Local;
                this.reportViewer1.LocalReport.ReportPath = @"C:\Users\Roxelle\source\repos\Capstone\CapstoneProject_3\Datasets\rwTopTenSelling.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();

                using (var connection = new SqlConnection(con))
                {
                    connection.Open();
                    DataSetReports top = new DataSetReports();

                    SqlCommand cmd = new SqlCommand(@"SELECT TOP 10 ProductCode, Description, SUM(qty) AS qty FROM viewSoldItems 
                                            WHERE sDate Between @dFrom AND @dTo
                                            AND Status LIKE 'Sold' 
                                            GROUP BY Description,ProductCode
                                            ORDER BY qty DESC", connection);
                    cmd.Parameters.AddWithValue("@dFrom", rec.dateFrom.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@dTo", rec.dateTo.Value.ToString("yyyy-MM-dd"));

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(top.Tables["dtTopSelling"]);

                    //Parameters
                    ReportParameter pDate = new ReportParameter("pDate", "DATE FROM: " + rec.dateFrom.Value.ToString("yyyy-MM-dd") + " TO: " + rec.dateTo.Value.ToString("yyyy-MM-dd"));
                    reportViewer1.LocalReport.SetParameters(pDate);

                    ds = new ReportDataSource("rwTopTenSelling", top.Tables["dtTopSelling"]);
                    reportViewer1.LocalReport.DataSources.Add(ds);
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
        //Sold Items
        public void loadSoldItems()
        {
            try
            {
                ReportDataSource ds;

                reportViewer1.ProcessingMode = ProcessingMode.Local;
                this.reportViewer1.LocalReport.ReportPath = @"C:\Users\Roxelle\source\repos\Capstone\CapstoneProject_3\Datasets\rwSoldItems.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();

                using (var connection = new SqlConnection(con))
                {
                    connection.Open();
                    DataSetReports sold = new DataSetReports();

                    SqlCommand cmd = new SqlCommand(@"SELECT p.ProductCode , p.Description, c.Price, SUM(c.qty) AS total_qty, SUM(c.discount) AS total_discount, SUM(c.Total) AS total FROM tblCart AS c
                                            INNER JOIN tblProduct AS p
                                            ON p.productID = c.productID
                                            WHERE sDate BETWEEN @dFrom AND @dTo
                                            AND STATUS LIKE 'Sold'
                                            GROUP BY ProductCode, Description, c.Price", connection);
                    cmd.Parameters.AddWithValue("@dFrom", rec.dateFrom2.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@dTo", rec.dateTo2.Value.ToString("yyyy-MM-dd"));

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(sold.Tables["dtSoldItems"]);

                    //Parameters
                    ReportParameter pDate = new ReportParameter("pDate", "DATE FROM: " + rec.dateFrom2.Value.ToString("yyyy-MM-dd") + " TO: " + rec.dateTo2.Value.ToString("yyyy-MM-dd"));
                    reportViewer1.LocalReport.SetParameters(pDate);


                    ds = new ReportDataSource("rwSoldItems", sold.Tables["dtSoldItems"]);
                    reportViewer1.LocalReport.DataSources.Add(ds);
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
        //Low Stock Items
        public void loadCriticalStock()
        {
            try
            {
                ReportDataSource ds;

                reportViewer1.ProcessingMode = ProcessingMode.Local;
                this.reportViewer1.LocalReport.ReportPath = @"C:\Users\Roxelle\source\repos\Capstone\CapstoneProject_3\Datasets\rwCriticalStock.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();

                using (var connection = new SqlConnection(con))
                {
                    connection.Open();
                    DataSetReports critical = new DataSetReports();
                    SqlCommand cmd = new SqlCommand(@"SELECT ProductCode,Description,Brand,Category,Price, quantity from viewCriticalStock
                                                      WHERE quantity <= reorder", connection);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(critical.Tables["dtCriticalStock"]);

                    ds = new ReportDataSource("rwCriticalStock", critical.Tables["dtCriticalStock"]);
                    reportViewer1.LocalReport.DataSources.Add(ds);
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

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
        public void loadRefunds()
        {
            try
            {
                ReportDataSource ds;
                his = new frmHistory();

                reportViewer1.ProcessingMode = ProcessingMode.Local;
                this.reportViewer1.LocalReport.ReportPath = @"C:\Users\Roxelle\source\repos\Capstone\CapstoneProject_3\Datasets\rwRefunds.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();

                using (var connection = new SqlConnection(con))
                {
                    connection.Open();
                    DataSetReports refunds = new DataSetReports();
                    SqlCommand cmd = new SqlCommand(@"SELECT TransactionNo, ProductCode, Description, price, qty, total, sdate, Store_Owner, Cashier, reason 
                                                      FROM viewRefunded", connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(refunds.Tables["dtRefunded"]);

                    //Parameters
                    ReportParameter pDate = new ReportParameter("pDate", "DATE FROM: " + his.dateFrom3.Value.ToString("yyyy-MM-dd") + " TO: " + his.dateTo3.Value.ToString("yyyy-MM-dd"));
                    reportViewer1.LocalReport.SetParameters(pDate);

                    ds = new ReportDataSource("rwRefunds", refunds.Tables["dtRefunded"]);
                    reportViewer1.LocalReport.DataSources.Add(ds);
                    reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                    reportViewer1.ZoomMode = ZoomMode.Percent;
                    reportViewer1.ZoomPercent = 80;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        public void loadHistoryPrice()
        {
            try
            {
                ReportDataSource ds;
                his = new frmHistory();

                reportViewer1.ProcessingMode = ProcessingMode.Local;
                this.reportViewer1.LocalReport.ReportPath = @"C:\Users\Roxelle\source\repos\Capstone\CapstoneProject_3\Datasets\rwPriceHistory.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();

                using (var connection = new SqlConnection(con))
                {
                    connection.Open();
                    DataSetReports priceHistory = new DataSetReports();
                    SqlCommand cmd = new SqlCommand(@"SELECT p.ProductCode, p.Description, price.salesPrice, price.date FROM tblPrice AS price
                                                      INNER JOIN tblProduct AS p ON price.productID=p.productID", connection);
                    //cmd.Parameters.AddWithValue("@dateFrom", his.dateFrom2.Value.ToString("yyyy-MM-dd"));
                    //cmd.Parameters.AddWithValue("@dateTo", his.dateTo2.Value.ToString("yyyy-MM-dd"));

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(priceHistory.Tables["dtPriceHistory"]);

                    //Report Parameters
                    ReportParameter pDate = new ReportParameter("pDate", "DATE FROM: " + his.dateFrom2.Value.ToString("yyyy-MM-dd") + " TO: " + his.dateTo2.Value.ToString("yyyy-MM-dd"));
                    reportViewer1.LocalReport.SetParameters(pDate);

                    ds = new ReportDataSource("rwPriceHistory", priceHistory.Tables["dtPriceHistory"]);
                    reportViewer1.LocalReport.DataSources.Add(ds);
                    reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                    reportViewer1.ZoomMode = ZoomMode.Percent;
                    reportViewer1.ZoomPercent = 80;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadSalesHistory()
        {
            try
            {
                ReportDataSource ds;
                his = new frmHistory();

                reportViewer1.ProcessingMode = ProcessingMode.Local;
                this.reportViewer1.LocalReport.ReportPath = @"C:\Users\Roxelle\source\repos\Capstone\CapstoneProject_3\Datasets\rwSalesHistory.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();

                DataSetReports salesHistory = new DataSetReports();

                if (his.cbUsers.Text == "All Users")
                {
                    using (var connection = new SqlConnection(con))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand(@"SELECT c.cartID, c.TransactionNo, p.Description, p.ProductCode, c.Price, c.qty, c.discount, c.Total 
                                                      FROM tblCart AS c
                                                      INNER JOIN tblProduct AS p ON c.productID = p.productID
                                                      WHERE Status LIKE 'Sold' AND sDate BETWEEN '"+ his.dateFrom2.Value.ToString("yyyy-MM-dd") +"' AND '"+ his.dateTo2.Value.ToString("yyyy-MM-dd") + "'", connection);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(salesHistory.Tables["dtSalesHistory"]);

                        //Report Parameters
                        ReportParameter pDate = new ReportParameter("pDate", "DATE FROM: " + his.dateFrom2.Value.ToString("yyyy-MM-dd") + " TO: " + his.dateTo2.Value.ToString("yyyy-MM-dd"));
                        ReportParameter pCashier = new ReportParameter(his.cbUsers.Text);
                        reportViewer1.LocalReport.SetParameters(pDate);
                        reportViewer1.LocalReport.SetParameters(pCashier);

                        ds = new ReportDataSource("rwSalesHistory", salesHistory.Tables["dtSalesHistory"]);
                        reportViewer1.LocalReport.DataSources.Add(ds);
                        reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                        reportViewer1.ZoomMode = ZoomMode.Percent;
                        reportViewer1.ZoomPercent = 80;
                    }
                }
                else
                {
                    using (var connection = new SqlConnection(con))
                    {
                        connection.Open();
                        SqlCommand cmd = new SqlCommand(@"SELECT c.cartID, c.TransactionNo, p.Description, p.ProductCode, c.Price, c.qty, c.discount, c.Total 
                                                      FROM tblCart AS c
                                                      INNER JOIN tblProduct AS p ON c.productID = p.productID
                                                      WHERE Status LIKE 'Sold' 
                                                      AND sDate BETWEEN '"+his.dateFrom2.Value.ToString("yyyy-MM-dd")+"' and '"+his.dateTo2.Value.ToString("yyyy-MM-dd")+"' AND userID LIKE '"+his.uid+"'", connection);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(salesHistory.Tables["dtSalesHistory"]);

                        //Report Parameters
                        ReportParameter pDate = new ReportParameter("pDate", "DATE FROM: " + his.dateFrom2.Value.ToString("yyyy-MM-dd") + " TO: " + his.dateTo2.Value.ToString("yyyy-MM-dd"));
                        ReportParameter pCashier = new ReportParameter(his.cbUsers.Text);
                        reportViewer1.LocalReport.SetParameters(pDate);
                        reportViewer1.LocalReport.SetParameters(pCashier);

                        ds = new ReportDataSource("rwSalesHistory", salesHistory.Tables["dtSalesHistory"]);
                        reportViewer1.LocalReport.DataSources.Add(ds);
                        reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                        reportViewer1.ZoomMode = ZoomMode.Percent;
                        reportViewer1.ZoomPercent = 80;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}

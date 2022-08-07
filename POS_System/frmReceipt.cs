using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapstoneProject_3.Datasets;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;

namespace CapstoneProject_3.POS_System
{
    public partial class frmReceipt : Form
    {
        frmPOS fpos;
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        string store = "Andres Delegencia Store";
        string address = "Pilar, Capiz, Philippines";
        public frmReceipt(frmPOS pos)
        {
            fpos = pos;
            InitializeComponent();
        }
        //Methods
        public void loadReport()
        {
            ReportDataSource rds;

            try
            {
                reportViewer1.ProcessingMode = ProcessingMode.Local;
                this.reportViewer1.LocalReport.ReportPath = @"C:\Users\Roxelle\source\repos\Capstone\CapstoneProject_3\Datasets\rwReceipt.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();

                using (var connection = new SqlConnection(con))
                {
                    connection.Open();
                    DataSetReceipt ds = new DataSetReceipt();
                    SqlCommand cmd = new SqlCommand(@"SELECT c.cartID, c.TransactionNo, p.productID, c.Price, c.qty, c.discount, c.Total, c.sDate, c.Status, p.Description, u.Name
                                                      FROM tblCart AS c
                                                      INNER JOIN tblProduct AS p ON p.productID = c.productID 
                                                      INNER JOIN tblUsers AS u ON u.userID = c.userID
                                                      WHERE TransactionNo LIKE @tnum", connection);
                    cmd.Parameters.AddWithValue("@tnum", fpos.lblTransNo.Text);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(ds.Tables["dtReceipt"]);

                    //Parameters-
                    ReportParameter pTotal = new ReportParameter("pTotal", fpos.lblTotal.Text);
                    ReportParameter pAddress = new ReportParameter("pAddress", address);
                    ReportParameter pStore = new ReportParameter("pStore", store);
                    ReportParameter pDiscount = new ReportParameter("pDiscount", fpos.lblDiscount.Text);
                    ReportParameter pCash = new ReportParameter("pCash", fpos.lblCash.Text); 
                    ReportParameter pChange = new ReportParameter("pChange", fpos.lblChange.Text); 
                    ReportParameter pTransacNo = new ReportParameter("pTransacNo", fpos.lblTransNo.Text);
                    ReportParameter pCashier = new ReportParameter("pCashier", fpos.lblUser.Text);
                    ReportParameter pVAT = new ReportParameter("pVAT", fpos.lblVat.Text);
                    ReportParameter pVatable = new ReportParameter("pVatable", fpos.lblVatable.Text);
                    ReportParameter pQty = new ReportParameter("pQty", fpos.lblTotalQty.Text);

                    reportViewer1.LocalReport.SetParameters(pTotal);
                    reportViewer1.LocalReport.SetParameters(pAddress);
                    reportViewer1.LocalReport.SetParameters(pStore);
                    reportViewer1.LocalReport.SetParameters(pDiscount);
                    reportViewer1.LocalReport.SetParameters(pCash); 
                    reportViewer1.LocalReport.SetParameters(pChange); 
                    reportViewer1.LocalReport.SetParameters(pTransacNo);
                    reportViewer1.LocalReport.SetParameters(pCashier);
                    reportViewer1.LocalReport.SetParameters(pVAT);
                    reportViewer1.LocalReport.SetParameters(pVatable);
                    reportViewer1.LocalReport.SetParameters(pQty);
                    //Parameters-

                    rds = new ReportDataSource("DataSetReceipt", ds.Tables["dtReceipt"]);
                    reportViewer1.LocalReport.DataSources.Add(rds);
                    reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                    reportViewer1.ZoomMode = ZoomMode.Percent;
                    reportViewer1.ZoomPercent = 100;
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

        private void frmReceipt_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}

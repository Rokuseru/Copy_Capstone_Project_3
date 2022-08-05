using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CapstoneProject_3.Datasets;
using System.IO;
using System.Net;

namespace CapstoneProject_3
{
    public partial class frmPurchaseOrderReportViewer : Form
    {
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        frmPurchaseOrder purchaseOrder;
        private string _sender = "";
        private string _reciever = "";
        public frmPurchaseOrderReportViewer(frmPurchaseOrder po)
        {
            purchaseOrder = po;
            InitializeComponent();
           
        }
        private void frmPurchaseOrderReportViewer_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
            try
            {
                ReportDataSource rds;

                reportViewer1.ProcessingMode = ProcessingMode.Local;
                this.reportViewer1.LocalReport.ReportPath = @"C:\Users\Roxelle\source\repos\Capstone\CapstoneProject_3\Datasets\rwPurchaseOrder.rdlc";
                this.reportViewer1.LocalReport.DataSources.Clear();

                using (var connection = new SqlConnection(con))
                {
                    connection.Open();
                    DataSetPurchaseOrder po = new DataSetPurchaseOrder();
                    SqlCommand cmd = new SqlCommand(@"SELECT Description, price, qty,total FROM viewPurchaseOrder
                                                      WHERE referenceCode LIKE @refCode", connection);
                    cmd.Parameters.AddWithValue("@refCode", purchaseOrder.txtReferenceCode.Text);

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    adapter.Fill(po.Tables["dtPurchaseOrder"]);

                    //report Parameters
                    ReportParameter pRefCode = new ReportParameter("pRefCode", purchaseOrder.txtReferenceCode.Text);
                    ReportParameter pOrderDate = new ReportParameter("pOrderDate", purchaseOrder.dtpOrderDate.Value.ToString("yyyy-MM-dd"));
                    ReportParameter pDeliveryDate = new ReportParameter("pDeliveryDate", purchaseOrder.dtpDeliveryDate.Value.ToString("yyyy-MM-dd"));
                    ReportParameter pDiscount = new ReportParameter("pDiscount", purchaseOrder.txtDiscPhp.Text);
                    ReportParameter pPendingPayment = new ReportParameter("pPendingPayment", purchaseOrder.txtPaymentDue.Text);
                    ReportParameter pBillTo = new ReportParameter("pBillTo", purchaseOrder.cbOrderBy.Text);

                    reportViewer1.LocalReport.SetParameters(pRefCode);
                    reportViewer1.LocalReport.SetParameters(pOrderDate);
                    reportViewer1.LocalReport.SetParameters(pDeliveryDate);
                    reportViewer1.LocalReport.SetParameters(pDiscount);
                    reportViewer1.LocalReport.SetParameters(pPendingPayment);
                    reportViewer1.LocalReport.SetParameters(pBillTo);

                    rds = new ReportDataSource("rwPurchaseOrder", po.Tables["dtPurchaseOrder"]);
                    reportViewer1.LocalReport.DataSources.Add(rds);
                }

            }catch(Exception)
            {

            }
        }

        private string exportReportToPDF(string reportName)
        {
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;
            byte[] bytes = reportViewer1.LocalReport.Render("PDF", null, out mimeType, out encoding, 
                                                             out filenameExtension, out streamids, out warnings);
            string filename = Path.Combine(Path.GetTempPath(), reportName);

            using (var fs = new FileStream(filename, System.IO.FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
                fs.Close();
            }
            return filename;
        }

        //public void loadPurchaseOrder()
        //{
        //    try
        //    {
        //        ReportDataSource rds;

        //        reportViewer1.ProcessingMode = ProcessingMode.Local;
        //        this.reportViewer1.LocalReport.ReportPath = @"C:\Users\Roxelle\source\repos\Capstone\CapstoneProject_3\Datasets\rwPurchaseOrder.rdlc";
        //        this.reportViewer1.LocalReport.DataSources.Clear();

        //        using (var connection = new SqlConnection(con))
        //        {
        //            connection.Open();
        //            DataSetPurchaseOrder po = new DataSetPurchaseOrder();
        //            SqlCommand cmd = new SqlCommand(@"SELECT Description, price, qty,total FROM viewPurchaseOrder
        //                                              WHERE referenceCode LIKE @refCode", connection);
        //            cmd.Parameters.AddWithValue("@refCode", purchaseOrder.txtReferenceCode.Text);

        //            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        //            adapter.Fill(po.Tables["dtPurchaseOrder"]);

        //            //report Parameters
        //            ReportParameter pRefCode = new ReportParameter("pRefCode", purchaseOrder.txtReferenceCode.Text);
        //            ReportParameter pOrderDate = new ReportParameter("pOrderDate", purchaseOrder.dtpOrderDate.Value.ToString("yyyy-MM-dd"));
        //            ReportParameter pDeliveryDate = new ReportParameter("pDeliveryDate", purchaseOrder.dtpDeliveryDate.Value.ToString("yyyy-MM-dd"));
        //            ReportParameter pDiscount = new ReportParameter("pDiscount", purchaseOrder.txtDiscPhp.Text);
        //            ReportParameter pPendingPayment = new ReportParameter("pPendingPayment", purchaseOrder.txtPaymentDue.Text);
        //            ReportParameter pBillTo = new ReportParameter("pBillTo", purchaseOrder.cbOrderBy.Text);

        //            reportViewer1.LocalReport.SetParameters(pRefCode);
        //            reportViewer1.LocalReport.SetParameters(pOrderDate);
        //            reportViewer1.LocalReport.SetParameters(pDeliveryDate);
        //            reportViewer1.LocalReport.SetParameters(pDiscount);
        //            reportViewer1.LocalReport.SetParameters(pPendingPayment);
        //            reportViewer1.LocalReport.SetParameters(pBillTo);

        //            rds = new ReportDataSource("rwPurchaseOrder", po.Tables["dtPurchaseOrder"]);
        //            reportViewer1.LocalReport.DataSources.Add(rds);
        //            reportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
        //            reportViewer1.ZoomMode = ZoomMode.Percent;
        //            reportViewer1.ZoomPercent = 80;
        //        }
        //    }
        //    catch (Exception)
        //    {

        //    }
        //}
        protected void Email(Object sender, EventArgs e)
        {
            try
            {
                using (MailMessage mm = new MailMessage("roxsyle7@gmail.com", _reciever))
                {
                    mm.Subject = "Test";
                    mm.Body = "Test";
                    mm.Attachments.Add(new Attachment("Invoice.pdf"));
                    mm.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    NetworkCredential credential = new NetworkCredential();
                    credential.UserName = "roxsyle7@gmail.com";
                    credential.Password = "rcmb0803";
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = credential;
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.Send(mm);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Source);
            }
        }

    }
}

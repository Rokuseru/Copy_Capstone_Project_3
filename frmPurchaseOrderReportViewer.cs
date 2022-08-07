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
        private string _sender = "roxsyle7@gmail.con";
        private string _reciever = "barceroxellecleve@gmail.com";
        public frmPurchaseOrderReportViewer(frmPurchaseOrder po)
        {
            purchaseOrder = po;
            InitializeComponent();
           
        }
        private void frmPurchaseOrderReportViewer_Load(object sender, EventArgs e)
        {
            this.reportViewer.RefreshReport();         
        }
        public void loadPurchaseOrder()
        {
            try
            {
                ReportDataSource rds;

                reportViewer.ProcessingMode = ProcessingMode.Local;
                this.reportViewer.LocalReport.ReportPath = @"C:\Users\Roxelle\source\repos\Capstone\CapstoneProject_3\Datasets\rwPurchaseOrder.rdlc";
                this.reportViewer.LocalReport.DataSources.Clear();

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

                    reportViewer.LocalReport.SetParameters(pRefCode);
                    reportViewer.LocalReport.SetParameters(pOrderDate);
                    reportViewer.LocalReport.SetParameters(pDeliveryDate);
                    reportViewer.LocalReport.SetParameters(pDiscount);
                    reportViewer.LocalReport.SetParameters(pPendingPayment);
                    reportViewer.LocalReport.SetParameters(pBillTo);

                    rds = new ReportDataSource("rwPurchaseOrder", po.Tables["dtPurchaseOrder"]);
                    reportViewer.LocalReport.DataSources.Add(rds);
                    reportViewer.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout);
                    reportViewer.ZoomMode = ZoomMode.Percent;
                    reportViewer.ZoomPercent = 80;

                    convertRdlcToPdf();
                }
            }
            catch (Exception)
            {

            }
        }
        public void convertRdlcToPdf()
        {
            string deviceInfo = "<DeviceInfo>" +
                    "  <OutputFormat>PDF</OutputFormat>" +
                    "  <PageWidth>8.27in</PageWidth>" +
                    "  <PageHeight>11.69in</PageHeight>" +
                    "  <MarginTop>0.25in</MarginTop>" +
                    "  <MarginLeft>0.4in</MarginLeft>" +
                    "  <MarginRight>0in</MarginRight>" +
                    "  <MarginBottom>0.25in</MarginBottom>" +
                    "  <EmbedFonts>None</EmbedFonts>" +
                    "</DeviceInfo>";

            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;

            byte[] bytes = reportViewer.LocalReport.Render("PDF", deviceInfo, out mimeType, out encoding, out filenameExtension,
                                                             out streamids, out warnings);
            using (FileStream fs = new FileStream("output.pdf", FileMode.Create))
            {
                fs.Write(bytes, 0, bytes.Length);
            }
        }
        public void sendMailWithAttachment()
        {
            using (SmtpClient client = new SmtpClient())
            {
                var cred = new NetworkCredential(_sender, "rcmb0803");
                using (MailMessage message = new MailMessage())
                {
                    MailAddress address = new MailAddress("roxsyle7@gmail.com");

                    client.Host = "smtp.gmail.com";
                    client.UseDefaultCredentials = false;
                    client.Credentials = cred;
                    client.EnableSsl = false;
                    client.Port = 587;

                    //Message
                    message.From = new MailAddress(_sender);
                    message.Subject = "Purchase Order";
                    message.Body = "Please See Attatched File for the purchase order.";
                    message.To.Add(_reciever);
                    message.Priority = MailPriority.High;
                    //Message attachment
                    System.Net.Mail.Attachment attachment;
                    attachment = new System.Net.Mail.Attachment("output.pdf");
                    message.Attachments.Add(attachment);

                    try
                    {
                        client.Send(message);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Not Sent", "Error");
                        Console.WriteLine(ex.Message);
                        Console.WriteLine(ex.StackTrace);
                        Console.WriteLine(ex.Source);
                    }
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnSendToVendor_Click(object sender, EventArgs e)
        {
            sendMailWithAttachment();
            //try
            //{
            //    MailMessage mail = new MailMessage();
            //    SmtpClient smtp = new SmtpClient();
            //    mail.From = new MailAddress(_sender);
            //    mail.To.Add(_reciever);
            //    mail.Subject = "Purchase Order";
            //    mail.Body = "Please See Attatched File for the purchase order.";

            //    //Attatch File
            //    System.Net.Mail.Attachment attachment;
            //    attachment = new System.Net.Mail.Attachment("output.pdf");
            //    mail.Attachments.Add(attachment);

            //    smtp.UseDefaultCredentials = false;
            //    NetworkCredential cred = new System.Net.NetworkCredential(_sender, "rcmb0803","bvainvjmpxsdcdac");
            //    smtp.Credentials = cred;
            //    smtp.EnableSsl = true;
            //    smtp.Port = 587;
            //    smtp.Host = "smtp.gmail.com";
               
            //    smtp.Send(mail);
            //    MessageBox.Show("Sent");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Not Sent");
            //    Console.WriteLine(ex.Message);
            //    Console.WriteLine(ex.StackTrace);
            //    Console.WriteLine(ex.Source);
            //}
        }
    }
}

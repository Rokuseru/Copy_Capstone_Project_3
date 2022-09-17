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
using System.Runtime.InteropServices;

namespace CapstoneProject_3.Report_Forms
{
    public partial class frmInventoryReport : Form
    {
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        frmRecords rec;
        frmHistory his;
        //Fields
        private int borderSize = 2;
        private Size formSize; //Keep form size when it is minimized and restored.
                               //Since the form is resized
                               //because it takes into account the size of the title bar and borders.
        public frmInventoryReport(frmRecords records)
        {
            InitializeComponent();
            rec = records;
            this.Padding = new Padding(borderSize);//Border size
            this.BackColor = Color.FromArgb(30, 39, 46);//Border color
        }
        //Form Properties
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);


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
                    SqlCommand cmd = new SqlCommand(@"SELECT p.ProductCode, p.Description, b.Brand, c.Category, p.Price, p.reorder, p.quantity FROM tblProduct AS p
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

                    if (rec.cbSortBy.Text == "Sort By Quantity")
                    {
                        DataSetReports top = new DataSetReports();
                        SqlCommand cmd = new SqlCommand(@"SELECT TOP 10 ProductCode, Description, ISNULL(SUM(qty),0) AS qty, ISNULL(SUM(Total),0.00) AS Total FROM viewSoldItems 
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
                    }else if (rec.cbSortBy.Text == "Sort By Total Amount")
                    {
                        DataSetReports top = new DataSetReports();
                        SqlCommand cmd = new SqlCommand(@"SELECT TOP 10 ProductCode, Description, ISNULL(SUM(qty),0) AS qty, ISNULL(SUM(Total),0.00) AS Total FROM viewSoldItems 
                                            WHERE sDate Between @dFrom AND @dTo
                                            AND Status LIKE 'Sold' 
                                            GROUP BY Description,ProductCode
                                            ORDER BY Total DESC", connection);
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
        
        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        protected override void WndProc(ref Message m)
        {
            const int WM_NCCALCSIZE = 0x0083;//Standar Title Bar - Snap Window
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MINIMIZE = 0xF020; //Minimize form (Before)
            const int SC_RESTORE = 0xF120; //Restore form (Before)
            const int WM_NCHITTEST = 0x0084;//Win32, Mouse Input Notification: Determine what part of the window corresponds to a point, allows to resize the form.
            const int resizeAreaSize = 10;
            #region Form Resize
            // Resize/WM_NCHITTEST values
            const int HTCLIENT = 1; //Represents the client area of the window
            const int HTLEFT = 10;  //Left border of a window, allows resize horizontally to the left
            const int HTRIGHT = 11; //Right border of a window, allows resize horizontally to the right
            const int HTTOP = 12;   //Upper-horizontal border of a window, allows resize vertically up
            const int HTTOPLEFT = 13;//Upper-left corner of a window border, allows resize diagonally to the left
            const int HTTOPRIGHT = 14;//Upper-right corner of a window border, allows resize diagonally to the right
            const int HTBOTTOM = 15; //Lower-horizontal border of a window, allows resize vertically down
            const int HTBOTTOMLEFT = 16;//Lower-left corner of a window border, allows resize diagonally to the left
            const int HTBOTTOMRIGHT = 17;//Lower-right corner of a window border, allows resize diagonally to the right

            if (m.Msg == WM_NCHITTEST)
            { //If the windows m is WM_NCHITTEST
                base.WndProc(ref m);
                if (this.WindowState == FormWindowState.Normal)//Resize the form if it is in normal state
                {
                    if ((int)m.Result == HTCLIENT)//If the result of the m (mouse pointer) is in the client area of the window
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32()); //Gets screen point coordinates(X and Y coordinate of the pointer)                           
                        Point clientPoint = this.PointToClient(screenPoint); //Computes the location of the screen point into client coordinates                          
                        if (clientPoint.Y <= resizeAreaSize)//If the pointer is at the top of the form (within the resize area- X coordinate)
                        {
                            if (clientPoint.X <= resizeAreaSize) //If the pointer is at the coordinate X=0 or less than the resizing area(X=10) in 
                                m.Result = (IntPtr)HTTOPLEFT; //Resize diagonally to the left
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize))//If the pointer is at the coordinate X=11 or less than the width of the form(X=Form.Width-resizeArea)
                                m.Result = (IntPtr)HTTOP; //Resize vertically up
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTTOPRIGHT;
                        }
                        else if (clientPoint.Y <= (this.Size.Height - resizeAreaSize)) //If the pointer is inside the form at the Y coordinate(discounting the resize area size)
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize horizontally to the left
                                m.Result = (IntPtr)HTLEFT;
                            else if (clientPoint.X > (this.Width - resizeAreaSize))//Resize horizontally to the right
                                m.Result = (IntPtr)HTRIGHT;
                        }
                        else
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize diagonally to the left
                                m.Result = (IntPtr)HTBOTTOMLEFT;
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize)) //Resize vertically down
                                m.Result = (IntPtr)HTBOTTOM;
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTBOTTOMRIGHT;
                        }
                    }
                }
                return;
            }
            #endregion
            //Remove border and keep snap window
            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                return;
            }
            //Keep form size when it is minimized and restored. Since the form is resized because it takes into account the size of the title bar and borders.
            if (m.Msg == WM_SYSCOMMAND)
            {
                int wParam = (m.WParam.ToInt32() & 0xFFF0);
                if (wParam == SC_MINIMIZE)  //Before
                    formSize = this.ClientSize;
                if (wParam == SC_RESTORE)// Restored form(Before)
                    this.Size = formSize;
            }

            base.WndProc(ref m);
        }
    }
}

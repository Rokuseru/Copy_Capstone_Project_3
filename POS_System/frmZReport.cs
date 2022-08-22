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
using System.Globalization;
using CapstoneProject_3.Report_Forms;
using System.Runtime.InteropServices;

namespace CapstoneProject_3.POS_System
{
    public partial class frmZReport : Form
    {
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        CultureInfo culture = CultureInfo.GetCultureInfo("en-PH");
        public string timeOut = "";
        public string timeIn = "";
        //Fields
        private int borderSize = 1;
        public frmZReport()
        {
            InitializeComponent();
            loadUsers();
            this.Padding = new Padding(borderSize);//Border size
            this.BackColor = Color.FromArgb(53, 59, 72);//Border color
            this.panel2.BackColor = Color.White;
        }
        //Form Properties
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void loadUsers()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT * FROM tblUsers WHERE status = 'Active'";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cbUsers.Items.Add(reader["Name"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void loadRefunded()
        {
            try
            {
                double refunded = 0;
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT sdate, SUM(total) AS Refunds FROM tblCancelledOrders
                                           WHERE sdate LIKE @date
                                           AND stime BETWEEN @timein AND @timeout
										   group by sdate";
                    command.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@timein", timeIn);
                    command.Parameters.AddWithValue("@timeout", timeOut);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            refunded = double.Parse(reader["Refunds"].ToString());
                        }
                        txtRefund.Text = refunded.ToString("C", culture);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Edit this code here to add Other Payment method
        private void loadTransactions()
        {
            try
            {
                double tax = 0;
                double discount = 0;
                double cash = 0;
                double others = 0;
                int qty = 0;

                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT Method, SUM(Tendered) AS TenderedCash, SUM(tax) AS Tax, SUM(Discount) AS Discount, SUM(qty) AS TotalQty,SUM(Total_Sales) AS TotalSales FROM tblSales
                                            WHERE date LIKE @date
                                            AND time BETWEEN @timeIn AND @timeOut
                                            GROUP BY Method";
                    command.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@timeIn", timeIn);
                    command.Parameters.AddWithValue("@timeOut", timeOut);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cash = double.Parse(reader["TenderedCash"].ToString());
                            qty = int.Parse(reader["TotalQty"].ToString());
                            tax = double.Parse(reader["tax"].ToString());
                            discount = double.Parse(reader["Discount"].ToString());
                        }
                        txtCash.Text = cash.ToString("C", culture);
                        lblSoldItems.Text = qty.ToString();
                        txtOthers.Text = others.ToString("C", culture);
                        txtDiscount.Text = discount.ToString("C", culture);
                        txtTax.Text = tax.ToString("C", culture);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmZReport_Load(object sender, EventArgs e)
        {
            loadTransactions();
            loadRefunded();
            cbUsers.Text = "All Users";
        }
        private void LoadTime()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT * FROM tblAttendance";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            timeIn = reader["Time_In"].ToString();
                            timeOut = reader["Time_Out"].ToString();
                        }
                        Console.WriteLine(timeIn);
                        Console.WriteLine(timeOut);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadZReport()
        {
            try
            {
                LoadTime();
                string transactions = "0";
                double  total = 0;
                string date = "";
                using (var connection = new SqlConnection(con))
                {
                    using (var command = new SqlCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = @"SELECT COUNT(TransactionID) AS Transactions, u.Name, s.Method, sum(s.Discount) AS DISCOUNT, sum(s.Total_Sales) AS sales, s.date FROM tblSales AS s
                                                 INNER JOIN tblUsers AS u ON s.userID = u.userID
                                                 WHERE DATE LIKE @date
                                                 AND time BETWEEN @timeIn AND @timeOut
                                                 GROUP BY u.Name, Method, date";
                        command.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@timeIn", timeIn);
                        command.Parameters.AddWithValue("@timeOut", timeOut);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                transactions = reader["Transactions"].ToString();
                                total = double.Parse(reader["sales"].ToString());
                                date = Convert.ToDateTime(reader["date"].ToString()).ToString("ddd, MMM, dd, yyyy");
                            }
                            Console.WriteLine(date);
                            lblTotalSales.Text = total.ToString("C", culture); ;
                            lblTransactions.Text = transactions.ToString();
                            lblOpenedOn.Text = date + " At " + Convert.ToDateTime(timeIn).ToString("hh:mm:ss tt");

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmZRDLC zx = new frmZRDLC(this);
            zx.loadZReport();
            zx.ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}

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
    public partial class frmXReport : Form
    {
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        CultureInfo culture = CultureInfo.GetCultureInfo("en-PH");
        public int userID = 0;
        public string timeIn = "";
        public string timeOut = "";

        frmPOS pos;
        //Fields
        private int borderSize = 1;
        public frmXReport(frmPOS fpos)
        {
            InitializeComponent();
            pos = fpos;
            this.Padding = new Padding(borderSize);//Border size
            this.BackColor = Color.FromArgb(53, 59, 72);//Border color
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
        private void loadUserId()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT * FROM tblUsers 
                                            WHERE Name LIKE @user";
                    command.Parameters.AddWithValue("@user", cbUsers.Text);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userID = int.Parse(reader["userID"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    command.CommandText = @"SELECT * FROM tblAttendance WHERE userID LIKE @uid";
                    command.Parameters.AddWithValue("@uid", userID);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            timeIn =reader["Time_In"].ToString();
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
        private void loadSoldQty()
        {
            try
            {
                int soldProducts = 0;
                using (var connection = new SqlConnection(con))
                {
                    using (var command = new SqlCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = @"SELECT SUM(qty) AS Products_Sold FROM tblCart
                                                 WHERE userID LIKE @user
                                                 AND sDate LIKE @date
                                                 AND sTime BETWEEN @timeIn AND @timeOut";
                        command.Parameters.AddWithValue("@user", userID);
                        command.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@timeIn", timeIn);
                        command.Parameters.AddWithValue("@timeOut", timeOut);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                soldProducts = int.Parse(reader["Products_Sold"].ToString());
                            }
                            lblSoldItems.Text = soldProducts.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Source);
            }
        }
        public void loadXReport()
        {
            try
            {
                LoadTime();
                loadSoldQty();
                double _total = 0;
                string _date = "";
                string _transactions = "0";
                using (var connection = new SqlConnection(con))
                {
                    using (var command1 = new SqlCommand())
                    {
                        connection.Open();
                        command1.Connection = connection;
                        command1.CommandText = @"SELECT COUNT(TransactionID) AS Transactions, u.Name, s.Method, sum(s.Discount) AS DISCOUNT, sum(s.Total_Sales) AS sales, s.date FROM tblSales AS s
                                                 INNER JOIN tblUsers AS u ON s.userID = u.userID
                                                 WHERE u.userID LIKE @uid
                                                 AND DATE LIKE @date
                                                 AND time BETWEEN @timeIn AND @timeOut
                                                 GROUP BY u.Name, Method, date";
                        command1.Parameters.AddWithValue("@uid", userID);
                        command1.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));
                        command1.Parameters.AddWithValue("@timeIn", timeIn);
                        command1.Parameters.AddWithValue("@timeOut", timeOut);

                        using (var reader = command1.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                _transactions = reader["Transactions"].ToString();
                                _total = Double.Parse(reader["sales"].ToString());
                                _date = Convert.ToDateTime(reader["date"].ToString()).ToString("ddd, MMM, dd, yyyy");
                            }
                            lblTotalSales.Text = _total.ToString("C", culture);
                            lblTransactions.Text = _transactions.ToString();
                            lblOpenedOn.Text = _date + " At " + Convert.ToDateTime(timeIn).ToString("hh:mm:ss tt");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Source);
            }
        }
        private void cbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadUserId();
            loadXReport();
        }

        private void frmXReport_Load(object sender, EventArgs e)
        {
            cbUsers.Text = pos.lblUser.Text;
            loadUserId();
            loadUsers();
            loadXReport();
            loadSoldQty();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmXRDLC xreport = new frmXRDLC(this);
            xreport.loadXReportRDLC();
            xreport.ShowDialog();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}

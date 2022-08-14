using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SqlClient;
using CapstoneProject_3.Report_Forms;

namespace CapstoneProject_3
{
    public partial class frmHistory : Form
    {
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        CultureInfo culture = CultureInfo.GetCultureInfo("en-PH");
        public string uid;
        public frmHistory()
        {
            InitializeComponent();
        }
        //Methods
        public void loadRecord()
        {
            dataGridView.Rows.Clear();

            if (cbUsers.Text == "All Users")
            {
                try
                {
                    int i = 0;
                    double totalSales = 0;
                    using (var connection = new SqlConnection(con))
                    using (var command = new SqlCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = @"SELECT c.cartID, c.TransactionNo, p.Description, p.ProductCode, c.Price, c.qty, c.discount, c.Total 
                                            FROM tblCart AS c
                                            INNER JOIN tblProduct AS p ON c.productID = p.productID
                                            WHERE Status LIKE 'Sold'
                                            AND sDate BETWEEN @dateFrom AND @dateTo";
                        command.Parameters.AddWithValue("@dateFrom", dateFrom.Value.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@dateTo", dateTo.Value.ToString("yyyy-MM-dd"));
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                i += 1;
                                totalSales += double.Parse(reader["Total"].ToString());
                                dataGridView.Rows.Add(i, reader["cartID"].ToString(), reader["TransactionNo"].ToString(), reader["ProductCode"].ToString(), reader["Description"].ToString(),
                                                    reader["Price"].ToString(), reader["qty"].ToString(), reader["discount"].ToString(), reader["Total"].ToString());
                            }
                        }
                        lblTotalSales.Text = totalSales.ToString("C", culture);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                try
                {
                    int i = 0;
                    double totalSales = 0;
                    using (var connection = new SqlConnection(con))
                    using (var command = new SqlCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = @"SELECT c.cartID, c.TransactionNo, p.Description, p.ProductCode, c.Price, c.qty, c.discount, c.Total 
                                            FROM tblCart AS c
                                            INNER JOIN tblProduct AS p ON c.productID = p.productID
                                            WHERE Status LIKE 'Sold'
                                            AND sDate BETWEEN @dateFrom AND @dateTo
                                            AND userID LIKE @uid";
                        command.Parameters.AddWithValue("@dateFrom", dateFrom.Value.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@dateTo", dateTo.Value.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@uid", uid);
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                i += 1;
                                totalSales += double.Parse(reader["Total"].ToString());
                                dataGridView.Rows.Add(i, reader["cartID"].ToString(), reader["TransactionNo"].ToString(), reader["ProductCode"].ToString(), reader["Description"].ToString(),
                                                    reader["Price"].ToString(), reader["qty"].ToString(), reader["discount"].ToString(), reader["Total"].ToString());
                            }
                        }
                        lblTotalSales.Text = totalSales.ToString("C", culture);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        public void loadUsers()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT * FROM tblUsers";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cbUsers.Items.Add(reader["Name"].ToString());
                        }
                        cbUsers.Items.Add("All Users");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void loadRefunded()
        {
            dataGridView.Rows.Clear();
            int i = 0;
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT * FROM viewRefunded WHERE sdate BETWEEN @dateFrom AND @dateTo";
                    command.Parameters.AddWithValue("@dateFrom", dateFrom3.Value.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@dateTo", dateTo3.Value.ToString("yyyy-MM-dd"));
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            i++;
                            dataGridView3.Rows.Add(i, reader["TransactionNo"].ToString(), reader["ProductCode"].ToString(), reader["Description"].ToString(), reader["price"].ToString(),
                                reader["qty"].ToString(), reader["total"].ToString(), Convert.ToDateTime(reader["sdate"]).ToString("yyyy/MM/dd"), reader["Store_Owner"].ToString(), reader["cashier"].ToString(), reader["reason"].ToString());
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        public void loadStockInHistory()
        {
            try
            {
                dataGridView4.Rows.Clear();
                int i = 0;

                string dateB = dateFrom4.Value.ToString("yyyy-MM-dd");
                string dateT = dateTo4.Value.ToString("yyyy-MM-dd");

                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT * FROM viewStockIn WHERE StockInDate BETWEEN @dateb AND @datet AND Status LIKE 'Done'";
                    command.Parameters.AddWithValue("@dateb", dateB);
                    command.Parameters.AddWithValue("@datet", dateT);
                    using (var reader = command.ExecuteReader())
                    {
                        i += 1;
                        while (reader.Read())
                        {
                            dataGridView4.Rows.Add(i, reader["stockEntryID"].ToString(), reader["RefNumber"].ToString(), reader["Description"].ToString(), reader["RecievedBy"].ToString(),
                           reader["Vendor"].ToString(), reader["qty"].ToString(), Convert.ToDateTime(reader["StockInDate"]).ToString("yyyy/MM/dd"));
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        public void loadPriceHistory()
        {
            try
            {
                btnPrintPriceHistory.Rows.Clear();
                int i = 0;

                string dateF = dateFrom2.Value.ToString("yyyy-MM-dd");
                string dateT = dateTo2.Value.ToString("yyyy-MM-dd");

                using (var connection = new SqlConnection(con))
                using (var command =  new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT p.ProductCode, p.Description, price.salesPrice, price.date FROM tblPrice AS price
                                            INNER JOIN tblProduct AS p ON price.productID=p.productID
                                            WHERE date BETWEEN @dateFrom2 AND @dateTo2
                                            ORDER BY date DESC";
                    command.Parameters.AddWithValue("@dateFrom2", dateF);
                    command.Parameters.AddWithValue("@dateTo2", dateT);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            i++;
                            btnPrintPriceHistory.Rows.Add(i, reader["ProductCode"].ToString(), reader["Description"].ToString(), reader["salesPrice"].ToString(), Convert.ToDateTime(reader["date"]).ToString("yyyy/MM/dd"));
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadStockHistory()
        {
            try
            {
                dataGridViewStockHistory.Rows.Clear();
                int i = 0;
                using (var connection = new SqlConnection(con))
                using (var commamnd = new SqlCommand())
                {
                    connection.Open();
                    commamnd.Connection = connection;
                    commamnd.CommandText = @"SELECT p.Description , h.qty, h.date, h.time FROM tblStockHistory AS h
                                             JOIN tblProduct AS p ON h.productID = p.productID
                                             WHERE date BETWEEN @dateFrom AND @dateTo
                                             AND time BETWEEN @timeFrom AND @timeTo";
                    commamnd.Parameters.AddWithValue("@dateFrom", dateFrom5.Value.ToString("yyyy-MM-dd"));
                    commamnd.Parameters.AddWithValue("@dateTo", dateTo5.Value.ToString("yyyy-MM-dd"));
                    commamnd.Parameters.AddWithValue("@timeFrom", timeFrom.Value.ToString("HH:mm:ss.ffffff"));
                    commamnd.Parameters.AddWithValue("@timeTo", timeTo.Value.ToString("HH:mm:ss.ffffff"));

                    using (var reader = commamnd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            i += 1;
                            dataGridViewStockHistory.Rows.Add(i,reader["Description"].ToString(), reader["qty"].ToString(), Convert.ToDateTime(reader["date"].ToString()).ToString("yyyy-MM-dd"), Convert.ToDateTime(reader["time"].ToString()).ToString("hh:mm:ss tt"));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmSalesHistory_Load(object sender, EventArgs e)
        {
            dateTo.Value = DateTime.Today;
            dateTo3.Value = DateTime.Today;
            dateTo4.Value = DateTime.Today;
            dateTo5.Value = DateTime.Today;
            timeTo.Value = DateTime.Now;
            loadRecord();
            loadUsers();
        }

        private void dateFrom_ValueChanged(object sender, EventArgs e)
        {
            loadRecord();
        }

        private void dateTo_ValueChanged(object sender, EventArgs e)
        {
            loadRecord();
        }

        private void cbUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (var connection = new SqlConnection(con))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(@"SELECT userID FROM tblUsers WHERE Name = '"+cbUsers.SelectedItem+"'",connection);
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        uid = dr["userID"].ToString();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            loadRecord();
        }

        private void tabControlHistory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlHistory.SelectedTab == tabControlHistory.TabPages["tabRefundHistory"])
            {
                loadRefunded();
            }
            else if (tabControlHistory.SelectedTab == tabControlHistory.TabPages["tabSalesHistory"])
            {
                loadRecord();
            }
            else if (tabControlHistory.SelectedTab == tabControlHistory.TabPages["tabStockInHistory"])
            {
                loadStockInHistory();
            }
            else if (tabControlHistory.SelectedTab == tabControlHistory.TabPages["tabPriceHistory"])
            {
                loadPriceHistory();
            }
            else if (tabControlHistory.SelectedTab == tabControlHistory.TabPages["tabStockHistory"])
            {
                loadStockHistory();
            }
            else
            {
                return;
            }
        }

        private void btnPrintStockInHistory_Click(object sender, EventArgs e)
        {
            frmHistoryReport history = new frmHistoryReport(this);
            history.loadStockIn();
            history.ShowDialog();
        }

        private void dateTo4_ValueChanged(object sender, EventArgs e)
        {
            loadStockInHistory();
        }

        private void dateFrom4_ValueChanged(object sender, EventArgs e)
        {
            loadStockInHistory();
        }

        private void btnPrintRefund_Click(object sender, EventArgs e)
        {
            frmHistoryReport history = new frmHistoryReport(this);
            history.loadRefunds();
            history.ShowDialog();
        }

        private void btnPriceHistory_Click(object sender, EventArgs e)
        {
            frmHistoryReport history = new frmHistoryReport(this);
            history.loadHistoryPrice();
            history.ShowDialog();
        }

        private void dateFrom2_ValueChanged(object sender, EventArgs e)
        {
            loadPriceHistory();
        }

        private void dateTo2_ValueChanged(object sender, EventArgs e)
        {
            loadPriceHistory();
        }

        private void btnPrintSalesHistory_Click(object sender, EventArgs e)
        {
            frmHistoryReport history = new frmHistoryReport(this);
            history.loadSalesHistory();
            history.ShowDialog();
        }

        private void dateFrom5_ValueChanged(object sender, EventArgs e)
        {
            loadStockHistory();
        }

        private void dateTo5_ValueChanged(object sender, EventArgs e)
        {
            loadStockHistory();
        }

        private void timeFrom_ValueChanged(object sender, EventArgs e)
        {
            loadStockHistory();
        }

        private void timeTo_ValueChanged(object sender, EventArgs e)
        {
            loadStockHistory();
        }
    }
}

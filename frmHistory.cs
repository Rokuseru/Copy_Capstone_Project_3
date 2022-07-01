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

        private void frmSalesHistory_Load(object sender, EventArgs e)
        {
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
    }
}

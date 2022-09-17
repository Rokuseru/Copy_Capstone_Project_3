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
using Microsoft.Reporting.WinForms;

namespace CapstoneProject_3
{
    public partial class frmRecords : Form
    {
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        CultureInfo culture = CultureInfo.GetCultureInfo("en-PH");
        public frmRecords()
        {
            InitializeComponent();
        }
        //Methods
        //For Top Selling Tab
        public void loadTopTen()
        {
            int i = 0;
            dataGridView.Rows.Clear();
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    if (cbSortBy.Text == "Sort By Quantity")
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = @"SELECT TOP 10 ProductCode, Description, SUM(qty) AS qty, ISNULL(SUM(Total),0.00) AS Total FROM viewSoldItems 
                                            WHERE sDate Between @dFrom AND @dTo
                                            AND Status LIKE 'Sold' 
                                            GROUP BY Description,ProductCode
                                            ORDER BY qty DESC";
                        command.Parameters.AddWithValue("@dFrom", dateFrom.Value.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@dTo", dateTo.Value.ToString("yyyy-MM-dd"));
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                i++;
                                dataGridView.Rows.Add(i, reader["ProductCode"].ToString(), reader["Description"].ToString(), reader["qty"].ToString(), double.Parse(reader["Total"].ToString()).ToString("C", culture));
                            }
                        } 
                    }else if(cbSortBy.Text == "Sort By Total Amount")
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = @"SELECT TOP 10 ProductCode, Description, SUM(qty) AS qty, ISNULL(SUM(Total),0.00) AS Total FROM viewSoldItems 
                                            WHERE sDate Between @dFrom AND @dTo
                                            AND Status LIKE 'Sold' 
                                            GROUP BY Description,ProductCode
                                            ORDER BY Total DESC";
                        command.Parameters.AddWithValue("@dFrom", dateFrom.Value.ToString("yyyy-MM-dd"));
                        command.Parameters.AddWithValue("@dTo", dateTo.Value.ToString("yyyy-MM-dd"));
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                i++;
                                dataGridView.Rows.Add(i, reader["ProductCode"].ToString(), reader["Description"].ToString(), reader["qty"].ToString(), double.Parse(reader["Total"].ToString()).ToString("C", culture));
                            }
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //For Sold Items Tab
        public void loadSoldItems()
        {
            int n = 0;
            dataGridView2.Rows.Clear();
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT p.ProductCode , p.Description, c.Price, SUM(c.qty) AS total_qty, SUM(c.discount) AS total_discount, SUM(c.Total) AS total FROM tblCart AS c
                                            INNER JOIN tblProduct AS p
                                            ON p.productID = c.productID
                                            WHERE sDate BETWEEN @dFrom AND @dTo
                                            AND STATUS LIKE 'Sold'
                                            GROUP BY ProductCode, Description, c.Price";
                    command.Parameters.AddWithValue("@dFrom", dateFrom2.Value.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@dTo", dateTo2.Value.ToString("yyyy-MM-dd"));
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            n++;
                            dataGridView2.Rows.Add(n, reader["ProductCode"].ToString(), reader["Description"].ToString(), reader["Price"].ToString()
                                , reader["total_qty"].ToString(), reader["total_discount"].ToString(), reader["total"].ToString());
                        }
                    }

                    //Calculate Total
                    double sum = 0;
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        sum += Convert.ToDouble(dataGridView2.Rows[i].Cells["total"].Value);
                    }
                    lblTotal.Text = sum.ToString("C", culture);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Critical Stock Tab
        public void loadCriticalStock()
        {       
            try
            {
                dataGridView3.Rows.Clear();
                int i = 0;
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT * FROM viewCriticalStock WHERE quantity <= reorder";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            i++;
                            dataGridView3.Rows.Add(i, reader["productID"].ToString(), reader["ProductCode"].ToString(), reader["Description"].ToString(),
                                reader["Brand"].ToString(), reader["Category"].ToString(), reader["Price"].ToString(), reader["reorder"].ToString(), reader["quantity"].ToString());
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Inventory Tab
        public void loadInventory()
        {
            
            try
            {
                dataGridView4.Rows.Clear();
                int i = 0;

                using(var connection = new SqlConnection(con))
                using(var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT p.productID, p.ProductCode, p.Description, b.Brand, c.Category, p.Price, p.reorder, p.quantity FROM tblProduct AS p
                                            INNER JOIN tblBrand AS b ON p.brandID = b.brandID
                                            INNER JOIN tblCategory AS c ON p.categoryID = c.categoryID";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            i++;
                            dataGridView4.Rows.Add(i, reader["productID"].ToString(), reader["ProductCode"].ToString(), reader["Description"].ToString()
                                , reader["Brand"].ToString(), reader["Category"].ToString(), reader["Price"].ToString(), reader["reorder"].ToString(), reader["quantity"].ToString());
                        }
                    }
                }
            }
            catch(Exception ex)
            {
               MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void dateFrom_ValueChanged(object sender, EventArgs e)
        {
            loadTopTen();
        }

        private void dateTo_ValueChanged(object sender, EventArgs e)
        {
            loadTopTen();
        }

        private void dateFrom2_ValueChanged(object sender, EventArgs e)
        {
            loadSoldItems();
        }

        private void dateTo2_ValueChanged(object sender, EventArgs e)
        {
            loadSoldItems();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmInventoryReport frm = new frmInventoryReport(this);
            frm.loadInventoryReport();
            frm.ShowDialog();
        }

        private void tabControlRecords_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControlRecords.SelectedTab == tabControlRecords.TabPages["tabTopSelling"])
            {
                loadTopTen();
            }
            else if (tabControlRecords.SelectedTab == tabControlRecords.TabPages["tabSoldItems"])
            {
                loadSoldItems();
            }
            else if (tabControlRecords.SelectedTab == tabControlRecords.TabPages["tabCriticalStock"])
            {
                loadCriticalStock();
            }
            else if (tabControlRecords.SelectedTab == tabControlRecords.TabPages["tabInventoryCount"])
            {
                loadInventory();
            }
            else
            {
                return;
            }
        }

        private void btnTopSelling_Click(object sender, EventArgs e)
        {
            frmInventoryReport topselling = new frmInventoryReport(this);
            topselling.loadTopTen();
            topselling.ShowDialog();
        }

        private void btnPrintSoldItems_Click(object sender, EventArgs e)
        {
            frmInventoryReport soldItems = new frmInventoryReport(this);
            soldItems.loadSoldItems();
            soldItems.ShowDialog();
        }

        private void btnPrintCriticalStock_Click(object sender, EventArgs e)
        {
            frmInventoryReport criticalStock = new frmInventoryReport(this);
            criticalStock.loadCriticalStock();
            criticalStock.ShowDialog();
        }

        private void cbSortBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadTopTen();
        }

        private void frmRecords_Load(object sender, EventArgs e)
        {
            cbSortBy.SelectedText = "Sort By Quantity";
        }
    }
}

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

namespace CapstoneProject_3
{
    public partial class frmStockAdjustment : Form
    {
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        private int userID = 0;
        MainForm frm;
        public frmStockAdjustment(MainForm form)
        {
            InitializeComponent();
            frm = form;
        }
        public void getuserID()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT * FROM tblUsers WHERE Name = @name";
                    command.Parameters.AddWithValue("@name", txtUser.Text);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userID = int.Parse(reader["userID"].ToString());
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Source);
            }
        }
        public void generateRefNo()
        {
            try
            {
                string referencecode = "#ADJ000";
                string referenceno;
                int count;

                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT TOP 1 RefNumber FROM tblStockEntry
                                            WHERE RefNumber
                                            LIKE '" + txtRefNo.Text + "%' ORDER BY stockEntryID DESC";
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        if (reader.HasRows)
                        {
                            referenceno = reader[0].ToString();
                            count = int.Parse(referenceno.Substring(4, 4));
                            txtRefNo.Text = referencecode + (count + 1);
                        }
                        else
                        {
                            referenceno = referencecode + "1";
                            txtRefNo.Text = referenceno;
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
        public void loadProducts()
        {
            dataGridView.Rows.Clear();
            try
            {
                int i = 0;
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT productID, ProductCode, Description, b.Brand, c.Category, Price, quantity FROM tblProduct
                                            INNER JOIN tblBrand AS b
                                            ON tblProduct.BrandID = b.brandID
                                            INNER JOIN tblCategory AS c
                                            ON tblProduct.CategoryID = c.categoryID 
                                            ORDER BY Description ASC";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            i += 1;
                            dataGridView.Rows.Add(i, reader["productID"].ToString(), reader["ProductCode"].ToString(), reader["Description"].ToString(), reader["Brand"].ToString(), reader["Category"].ToString(), reader["Price"].ToString(), reader["quantity"].ToString());
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
        private void frmStockAdjustment_Load(object sender, EventArgs e)
        {
            getuserID();
            loadProducts();
            txtUser.Text =  frm.nameOfUser;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colname = dataGridView.Columns[e.ColumnIndex].Name;

        }
    }
}

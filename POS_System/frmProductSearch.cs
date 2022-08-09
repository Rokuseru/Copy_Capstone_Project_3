﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CapstoneProject_3.Notifications;

namespace CapstoneProject_3.POS_System
{
    public partial class frmProductSearch : Form
    {
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        frmPOS fpos;
        Notification ntf = new Notification();
        public frmProductSearch(frmPOS pos)
        {
            InitializeComponent();
            fpos = pos;
        }
        public void loadProduct()
        {
            try
            {
                dataGridView.Rows.Clear();
                int i = 0;

                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT p.productID, p.ProductCode, p.Barcode, p.Description, b.Brand, c.Category, p.quantity, p.Price FROM tblProduct AS p
                                            INNER JOIN tblBrand AS b ON p.BrandID = b.brandID
                                            INNER JOIN tblCategory AS c ON p.CategoryID = c.categoryID";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            i += 1;
                            dataGridView.Rows.Add(i, reader["productID"].ToString(), reader["ProductCode"].ToString(), reader["Barcode"].ToString(), reader["Description"].ToString(),
                                reader["Brand"].ToString(), reader["Category"].ToString(), reader["quantity"].ToString(), reader["Price"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void searchProduct()
        {
            try
            {
                dataGridView.Rows.Clear();
                int i = 0;
                
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT p.productID, p.ProductCode, p.Barcode, p.Description, b.Brand, c.Category, p.quantity, p.Price FROM tblProduct AS p
                                            INNER JOIN tblBrand AS b ON p.BrandID = b.brandID
                                            INNER JOIN tblCategory AS c ON p.CategoryID = c.categoryID
                                            WHERE Description LIKE '%"+txtSearch.Text+"%' OR Barcode LIKE '%"+txtSearch.Text+"%'";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            i += 1;
                            dataGridView.Rows.Add(i, reader["productID"].ToString(), reader["ProductCode"].ToString(), reader["Barcode"].ToString(), reader["Description"].ToString(),
                                reader["Brand"].ToString(), reader["Category"].ToString(), reader["quantity"].ToString(), reader["Price"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmProductSearch_Load(object sender, EventArgs e)
        {
            loadProduct();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            searchProduct();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colname = dataGridView.Columns[e.ColumnIndex].Name;

            if (colname == "Select")
            {
                frmQuantity qty = new frmQuantity(fpos);
                qty.productDetails(int.Parse(dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString()),double.Parse(dataGridView.Rows[e.RowIndex].Cells[8].Value.ToString()), fpos.lblTransNo.Text, int.Parse(dataGridView.Rows[e.RowIndex].Cells["qty"].Value.ToString()));
                qty.txtQty.Focus();
                qty.ShowDialog();
            }
        }
    }
}

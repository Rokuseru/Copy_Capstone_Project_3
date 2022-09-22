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
using CapstoneProject_3.Notifications;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace CapstoneProject_3.POS_System
{
    public partial class frmProductSearch : Form
    {
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        frmPOS fpos;
        Notification ntf = new Notification();
        //private int quantity = 0;
        //Fields
        private int borderSize = 1;
        public frmProductSearch(frmPOS pos)
        {
            InitializeComponent();
            fpos = pos;
            this.Padding = new Padding(borderSize);//Border size
            this.BackColor = Color.FromArgb(53, 59, 72);//Border color
        }
        //Form Properties
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
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
                    command.CommandText = @"SELECT i.productID, p.ProductCode, p.Description,b.Brand, c.Category, SUM(qty)AS qty,i.price FROM tblInventory AS i
                                            INNER JOIN tblProduct AS p ON i.productID = p.productID
                                            INNER JOIN tblBrand AS b ON p.BrandID = b.brandID
                                            INNER JOIN tblCategory AS c ON p.CategoryID = c.categoryID
                                            WHERE i.status = 'Available'
                                            GROUP BY i.productID, p.ProductCode, p.Description, b.Brand, c.Category, i.price
                                            ORDER BY p.Description ASC";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            i += 1;
                            dataGridView.Rows.Add(i, reader["productID"].ToString(), reader["ProductCode"].ToString(), reader["Description"].ToString(), reader["Brand"].ToString(), reader["Category"].ToString(), 
                                reader["qty"].ToString(), double.Parse(reader["price"].ToString()));
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
                    command.CommandText = @"SELECT p.productID,p.ProductCode, p.Description, b.Brand, c.Category, SUM(i.qty) AS qty, i.price, i.BatchNo, i.date FROM tblInventory AS i
                                            INNER JOIN tblProduct AS p ON i.productID = p.productID
                                            INNER JOIN tblBrand AS b ON p.BrandID = b.brandID
                                            INNER JOIN tblCategory AS c ON p.CategoryID = c.categoryID
                                            WHERE i.status = 'Available'
											GROUP BY p.productID, p.ProductCode, p.Description, b.Brand, c.Category, i.price, i.BatchNo, i.date
											ORDER BY BatchNo ASC, date ASC
                                            AND Description LIKE '%" + txtSearch.Text+"%'";
                    command.Parameters.AddWithValue("@bnum", fpos.prodBatch);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            i += 1;
                            dataGridView.Rows.Add(i, reader["productID"].ToString(), reader["ProductCode"].ToString(), reader["Description"].ToString(), reader["Brand"].ToString(), reader["Category"].ToString(),
                               reader["qty"].ToString(), reader["price"].ToString(), reader["BatchNo"].ToString(), Convert.ToDateTime(reader["date"].ToString()).ToString("yyyy-MM-dd"));
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
                qty.productDetails(int.Parse(dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString()),double.Parse(dataGridView.Rows[e.RowIndex].Cells["price"].Value.ToString()), fpos.lblTransNo.Text, int.Parse(dataGridView.Rows[e.RowIndex].Cells["qty"].Value.ToString()));
                qty.txtQty.Focus();
                qty.ShowDialog();
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}

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
using System.Runtime.InteropServices;

namespace CapstoneProject_3
{
    public partial class frmPOProducts : Form
    {
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        private int borderSize = 2;
        frmPurchaseOrder po;
        public frmPOProducts(frmPurchaseOrder purchaseOrder)
        {
            po = purchaseOrder;
            this.Padding = new Padding(borderSize);//Border size
            this.BackColor = Color.FromArgb(170, 166, 157);//Border color
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void loadProducts()
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
                    command.CommandText = @"SELECT p.productID, p.Description, b.Brand, p.VendorPrice FROM tblProduct AS p
                                            INNER JOIN tblBrand AS b ON p.BrandID = b.brandID 
                                            ORDER BY Description DESC";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            i += 1;
                            dataGridView.Rows.Add(i, reader["productID"].ToString(), reader["Description"].ToString(), reader["Brand"].ToString(), reader["VendorPrice"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmPOProducts_Load(object sender, EventArgs e)
        {
            loadProducts();
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

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colname = dataGridView.Columns[e.ColumnIndex].Name;

            try
            {
                if (colname == "add")
                {
                    if (MessageBox.Show("Add Item?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        using (var connection = new SqlConnection(con))
                        using (var command = new SqlCommand())
                        {
                            connection.Open();
                            command.Connection = connection;
                            command.CommandText = @"INSERT INTO tblPurchaseOrder (referenceCode, vendorID, userID, productID, price)
                                                    VALUES (@refCode, @vendorID, @userID, @productID, @price)";
                            command.Parameters.AddWithValue("@refCode", po.txtReferenceCode.Text);
                            command.Parameters.AddWithValue("@vendorID", po.vendorID);
                            command.Parameters.AddWithValue("@userID", po.userID);
                            command.Parameters.AddWithValue("@productID", int.Parse(dataGridView.Rows[e.RowIndex].Cells["pid"].Value.ToString()));
                            command.Parameters.AddWithValue("@price", double.Parse(dataGridView.Rows[e.RowIndex].Cells["price"].Value.ToString()));
                            command.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

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
using System.Globalization;
using CapstoneProject_3.Report_Forms;

namespace CapstoneProject_3.POS_System
{
    public partial class frmDailySales : Form
    {
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        CultureInfo culture = CultureInfo.GetCultureInfo("en-PH");
        frmPOS fpos;
        //Fields
        private int borderSize = 1;
        public frmDailySales(frmPOS pos)
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
        public void loadRecord()
        {
            dataGridView.Rows.Clear();
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
                    command.Parameters.AddWithValue("dateFrom", dateFrom.Value.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("dateTo", dateTo.Value.ToString("yyyy-MM-dd"));
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

        private void frmDailySales_Load(object sender, EventArgs e)
        {
            dateFrom.Value = DateTime.Now;
            dateTo.Value = DateTime.Now;
            loadRecord();
        }

        private void btnMinimizeWindow_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void dateTo_ValueChanged(object sender, EventArgs e)
        {
            loadRecord();
        }

        private void dateFrom_ValueChanged(object sender, EventArgs e)
        {
            loadRecord();
        }

        private void btnSve_Click(object sender, EventArgs e)
        {
            frmDailySalesReport dsr = new frmDailySalesReport(this);
            dsr.loadReport();
            dsr.ShowDialog();
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colname = dataGridView.Columns[e.ColumnIndex].Name;
            if (colname == "cancel")
            {
                frmRefundDetails cdeets = new frmRefundDetails(this);
                cdeets.txtDescription.Text = dataGridView.Rows[e.RowIndex].Cells["desc"].Value.ToString();
                cdeets.txtPcode.Text = dataGridView.Rows[e.RowIndex].Cells["pcode"].Value.ToString();
                cdeets.txtPrice.Text = dataGridView.Rows[e.RowIndex].Cells["prodPrice"].Value.ToString();
                cdeets.txtTotal.Text = dataGridView.Rows[e.RowIndex].Cells["TotalPrice"].Value.ToString();
                cdeets.txtQty.Text = dataGridView.Rows[e.RowIndex].Cells["qty"].Value.ToString();
                cdeets.txtTransNo.Text = dataGridView.Rows[e.RowIndex].Cells["invoiceNo"].Value.ToString();
                cdeets.txtDiscount.Text = dataGridView.Rows[e.RowIndex].Cells["discount"].Value.ToString();
                cdeets.txtCashier.Text = fpos.lblUser.Text;
                cdeets.cbAction.Text = "Yes";
                cdeets.ShowDialog();
            }

        }

        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}

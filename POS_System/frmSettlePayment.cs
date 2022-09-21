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
using CapstoneProject_3.Notifications;
using System.Runtime.InteropServices;

namespace CapstoneProject_3.POS_System
{
    public partial class frmSettlePayment : Form
    {
        frmPOS fpos;
        public double payment;
        int uid = 0;
        AuditTrail log = new AuditTrail();
        CultureInfo culture = CultureInfo.GetCultureInfo("en-PH");
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;

        //Fields
        private int borderSize = 1;
        public frmSettlePayment(frmPOS pos)
        {
            InitializeComponent();
            fpos = pos;
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
        //Methods
        //Clear pos labels
        public void clear()
        {
            fpos.lblChange.Text = "₱0.00";
            fpos.lblDiscount.Text = "₱0.00";
            fpos.lblSubTotal.Text = "₱0.00";
            fpos.lblTopTotal.Text = "₱0.00";
            fpos.lblVatable.Text = "0.00";
            fpos.lblVat.Text = "0.00";
        }
        public void getUserID()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT * FROM tblUsers WHERE Name LIKE @name";
                    command.Parameters.AddWithValue("@name", fpos.lblUser.Text);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            uid = int.Parse(reader["userID"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void updateStockAndCart()
        {

            try
            {
                //Inventory Table
                for (int items = 0; items < fpos.dataGridView.Rows.Count; items++)
                {
                    using (var connection = new SqlConnection(con))
                    using (var command = new SqlCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = @"UPDATE tblInventory SET qty = qty - @quantity WHERE productID = @pid AND BatchNo = @bno";
                        command.Parameters.AddWithValue("@quantity", int.Parse(fpos.dataGridView.Rows[items].Cells["qty"].Value.ToString()));
                        command.Parameters.AddWithValue("@pid", int.Parse(fpos.dataGridView.Rows[items].Cells["pid"].Value.ToString()));
                        command.Parameters.AddWithValue("@bno", fpos.prodBatch);
                        command.ExecuteNonQuery();
                    }
                }
                //Table Cart 
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"UPDATE tblCart SET Status = 'Sold' WHERE TransactionNo LIKE @trNo";
                    command.Parameters.AddWithValue("@trNo", fpos.lblTransNo.Text);
                    command.ExecuteNonQuery();
                }
                frmReceipt receipt = new frmReceipt(fpos);
                receipt.loadReport();
                receipt.ShowDialog();

                fpos.getTransNumber();
                fpos.loadCart();
                this.Dispose();
            }
            catch (Exception ex)
            {     
                MessageBox.Show(ex.Message);
            }
        }
        private void insertToSalesTable()
        {
            try
            {
                getUserID();
                double discount = Convert.ToDouble(Decimal.Parse(fpos.lblDiscount.Text, NumberStyles.Currency));
                double totalSales = Convert.ToDouble(Decimal.Parse(fpos.lblTopTotal.Text, NumberStyles.Currency));
                double tendered = Convert.ToDouble(Decimal.Parse(fpos.lblCash.Text, NumberStyles.Currency));
                double tax = Convert.ToDouble(Decimal.Parse(fpos.lblVat.Text, NumberStyles.Currency));
                int qty = Convert.ToInt32(int.Parse(fpos.lblTotalQty.Text));

                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"INSERT INTO tblSales (TransactionID, userID, Method,Tendered, tax, Discount, qty, Total_Sales, date, time) 
                                            VALUES (@tnumber, @uid, @Method, @tendered, @tax,@Discount, @qty,@totSales, @date, @time)";
                    command.Parameters.AddWithValue("@tnumber", fpos.lblTransNo.Text);
                    command.Parameters.AddWithValue("@uid", uid);
                    command.Parameters.AddWithValue("@Method", "Cash");
                    command.Parameters.AddWithValue("@Discount", discount);
                    command.Parameters.AddWithValue("@qty", qty);
                    command.Parameters.AddWithValue("@totSales", totalSales);
                    command.Parameters.AddWithValue("@tax", tax);
                    command.Parameters.AddWithValue("@date", Convert.ToDateTime(fpos.lblDate.Text));
                    command.Parameters.AddWithValue("@time", DateTime.Now.ToString("HH:mm:ss"));
                    command.Parameters.AddWithValue("@tendered", tendered);
                    command.ExecuteNonQuery();
                }
                //logs
                log.loadUserID(fpos.lblUser.Text);
                log.insertAction("Transaction Successful", "Reference Code " + fpos.lblTransNo.Text + "with a Total Sales of " + totalSales.ToString(), this.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Events
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtPayment_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(txtPayment.Text))
                {
                    txtPayment.Text = "0";
                }
                else
                {
                    //Variables
                    var culture = CultureInfo.GetCultureInfo("en-PH");

                    double bill = Convert.ToDouble(Decimal.Parse(txtBill.Text, NumberStyles.Currency));
                    double cash = Double.Parse(txtPayment.Text);
                    double change = cash - bill;

                    txtChange.Text = change.ToString("C", culture);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn20_Click(object sender, EventArgs e)
        {
            int i = 20;
            int s = Convert.ToInt32(int.Parse(txtPayment.Text).ToString());

            i = i + s;

            txtPayment.Text = i.ToString();
            txtPayment.Focus();
        }

        private void btn50_Click(object sender, EventArgs e)
        {
            int i = 50;
            int s = Convert.ToInt32(int.Parse(txtPayment.Text).ToString());

            i = i + s;

            txtPayment.Text = i.ToString();
            txtPayment.Focus();
        }

        private void btn100_Click(object sender, EventArgs e)
        {
            int i = 100;
            int s = Convert.ToInt32(int.Parse(txtPayment.Text).ToString());

            i = i + s;

            txtPayment.Text = i.ToString();
            txtPayment.Focus();
        }

        private void btn200_Click(object sender, EventArgs e)
        {
            int i = 200;
            int s = Convert.ToInt32(int.Parse(txtPayment.Text).ToString());

            i = i + s;

            txtPayment.Text = i.ToString();
            txtPayment.Focus();
        }

        private void btn500_Click(object sender, EventArgs e)
        {
            int i = 500;
            int s = Convert.ToInt32(int.Parse(txtPayment.Text).ToString());

            i = i + s;

            txtPayment.Text = i.ToString();
            txtPayment.Focus();
        }

        private void btn1000_Click(object sender, EventArgs e)
        {
            int i = 1000;
            int s = Convert.ToInt32(int.Parse(txtPayment.Text).ToString());

            i = i + s;

            txtPayment.Text = i.ToString();
            txtPayment.Focus();
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            int i = 5;
            int s = Convert.ToInt32(int.Parse(txtPayment.Text).ToString());

            i = i + s;

            txtPayment.Text = i.ToString();
            txtPayment.Focus();
        }

        private void btn10_Click(object sender, EventArgs e)
        {
            int i = 10;
            int s = Convert.ToInt32(int.Parse(txtPayment.Text).ToString());

            i = i + s;

            txtPayment.Text = i.ToString();
            txtPayment.Focus();
        }

        private void btnBspace_Click(object sender, EventArgs e)
        {
            txtPayment.Text = txtPayment.Text.Remove(txtPayment.Text.Length - 1, 1);
        }

        private void btnSettle_Click(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(Decimal.Parse(txtChange.Text, NumberStyles.Currency)) < 0)
                {
                    MessageBox.Show("Insufficient Payment", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    payment = double.Parse(txtPayment.Text);
                    fpos.lblChange.Text = txtChange.Text;
                    fpos.lblCash.Text = payment.ToString("C", culture); ;
                    insertToSalesTable();
                    updateStockAndCart();
                    clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}

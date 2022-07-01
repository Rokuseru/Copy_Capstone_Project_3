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

namespace CapstoneProject_3.POS_System
{
    public partial class frmSettlePayment : Form
    {
        frmPOS fpos;
        public double payment;
        CultureInfo culture = CultureInfo.GetCultureInfo("en-PH");
        Notification ntf = new Notification();
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        public frmSettlePayment(frmPOS pos)
        {
            InitializeComponent();
            fpos = pos;
        }
        //Methods
        //Clear pos labels
        public void clear()
        {
            fpos.lblChange.Text = "₱0.00";
            fpos.lblDiscount.Text = "₱0.00";
            fpos.lblTotal.Text = "₱0.00";
            fpos.lblTopTotal.Text = "₱0.00";
            fpos.lblVatable.Text = "0.00";
            fpos.lblVat.Text = "0.00";
            fpos.btnAddDisc.Enabled = false;
            fpos.btnSettle.Enabled = false;
        }

        public void updateStockAndCart()
        {

            try
            {
                for (int i = 0; i < fpos.dataGridView.Rows.Count; i++)
                {
                    //Table Products
                    using (var connection = new SqlConnection(con))
                    using (var command = new SqlCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = @"UPDATE tblProduct SET quantity = quantity - @qty WHERE productID = @pid";
                        command.Parameters.AddWithValue("@qty", int.Parse(fpos.dataGridView.Rows[i].Cells["qty"].Value.ToString()));
                        command.Parameters.AddWithValue("@pid", int.Parse(fpos.dataGridView.Rows[i].Cells["pid"].Value.ToString()));
                        command.ExecuteNonQuery();
                    }

                    //Table Cart
                    using (var connection = new SqlConnection(con))
                    using (var command = new SqlCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = @"UPDATE tblCart SET Status = 'Sold' WHERE cartID = @cid";
                        command.Parameters.AddWithValue("@cid", int.Parse(fpos.dataGridView.Rows[i].Cells[1].Value.ToString()));
                        command.ExecuteNonQuery();
                    }
                    frmReceipt receipt = new frmReceipt(fpos);
                    receipt.loadReport();
                    receipt.ShowDialog();

                    fpos.getTransNumber();
                    fpos.loadCart();
                    this.Dispose();
                    ntf.notificationMessage(fpos.panelNotif1, fpos.labelNotif1, fpos.iconNotif1, "Transaction Successful. Payment Recieved.");
                    ntf.notificationTimer(fpos.timer1, fpos.panelNotif1);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                    updateStockAndCart();
                    clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } 
        }
    }
}

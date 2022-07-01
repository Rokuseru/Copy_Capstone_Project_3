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

namespace CapstoneProject_3.POS_System
{
    public partial class frmDiscount : Form
    {
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        frmPOS fpos;
        double disc;
        public frmDiscount(frmPOS pos)
        {
            InitializeComponent();
            fpos = pos;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void txtDiscount_TextChanged(object sender, EventArgs e)
        {
            var culture = CultureInfo.GetCultureInfo("en-PH");
            try
            {
                if (String.IsNullOrWhiteSpace(txtDiscount.Text))
                {
                    txtDiscount.Text = "0";
                }
                else
                {
                    //Variables
                    double price = Convert.ToDouble(Decimal.Parse(txtPrice.Text, NumberStyles.Currency));
                    double discountInput = Convert.ToDouble(Decimal.Parse(txtDiscount.Text, NumberStyles.Currency));

                    //Convert Whole number to Percentage
                    disc = discountInput / 100;

                    //Compute Discount
                    double discount = disc * price;

                    //Display Discount
                    txtDiscAmount.Text = discount.ToString("C", culture);
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == 46)
            {
            }
            else if (e.KeyChar == 8)
            {

            }
            else if ((e.KeyChar < 48) || (e.KeyChar > 57))
            {
                e.Handled = true;
            }
        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {
            try
            {
               using (var connection = new SqlConnection(con))
               using (var command = new SqlCommand())
               {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"UPDATE tblCart SET discount = @disc WHERE cartID LIKE @id";
                    command.Parameters.AddWithValue("@disc", Convert.ToDouble(Decimal.Parse(txtDiscAmount.Text, NumberStyles.Currency)));
                    command.Parameters.AddWithValue("@id", int.Parse(lblID.Text));
                    command.ExecuteNonQuery();

                    fpos.loadCart();

                    txtDiscount.Clear();
                    this.Close();
               }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

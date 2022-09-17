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

namespace CapstoneProject_3
{
    public partial class frmPurchaseOrder : Form
    {
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        public int vendorID = 0;
        public int userID = 0;
        CultureInfo culture = CultureInfo.GetCultureInfo("en-PH");

        double disc = 0;
        public frmPurchaseOrder()
        {
            InitializeComponent();
            txtDiscPercent.Text = "0";
        }
        private void generateRefCode()
        {
            try
            {
                string sql = @"SELECT MAX(referenceCode) FROM tblPurchaseOrder";

                using (var connection = new SqlConnection(con))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sql, connection);
                    var refid = cmd.ExecuteScalar() as string;

                    if (refid == null)
                    {
                        txtReferenceCode.Text = "PO-000001";
                    }
                    else
                    {
                        int intval = int.Parse(refid.Substring(3, 6));
                        intval++;
                        txtReferenceCode.Text = String.Format("PO-{0:000000}", intval);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void loadVendor()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT * FROM tblVendor";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cbVendor.Items.Add(reader["Vendor"].ToString());
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void loadUser()
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
                            cbOrderBy.Items.Add(reader["Name"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void frmPurchaseOrder_Load(object sender, EventArgs e)
        {
            metroTabControl.SelectedTab = tabPageCreate;
            loadVendor();
            loadUser();
            generateRefCode();
        }
        public void loadPO()
        {
            try
            {
                int i = 0;
                double total = 0;
                dataGridView.Rows.Clear();

                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT po.purchaseOrderID,p.productID AS Product_ID,p2.Description AS Product_desc, po.referenceCode, po.price, po.qty, po.total 
                                            FROM tblPurchaseOrder AS po
                                            INNER JOIN tblProduct AS p ON po.productID = p.productID
                                            INNER JOIN tblProduct AS p2 ON po.productID = p2.productID
                                            WHERE referenceCode LIKE @refcode 
                                            ORDER BY Product_desc DESC";
                    command.Parameters.AddWithValue("@refcode", txtReferenceCode.Text);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            i += 1;
                            dataGridView.Rows.Add(i, reader["purchaseOrderID"].ToString(), reader["Product_ID"].ToString(), reader["referenceCode"].ToString(), reader["Product_desc"].ToString(), reader["price"].ToString(),
                                                    reader["qty"].ToString(), reader["total"].ToString());
                            total += double.Parse(reader["total"].ToString()); 
                        }
                        txtBeforeDisc.Text = total.ToString("C", culture);
                        calculateDiscount();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void calculateDiscount()
        {
            try
            {
                if (String.IsNullOrWhiteSpace(txtDiscPercent.Text))
                {
                    txtPaymentDue.Text = txtBeforeDisc.Text;
                    txtDiscPhp.Clear();
                }
                else
                {
                    //Variables
                    double withoutDiscount = Convert.ToDouble(Decimal.Parse(txtBeforeDisc.Text, NumberStyles.Currency));
                    double discountInput = Convert.ToDouble(Decimal.Parse(txtDiscPercent.Text));

                    //Whole number to percent
                    disc = discountInput / 100;

                    //Compute Discount
                    double discount = disc * withoutDiscount;
                    double discounted = withoutDiscount - discount;

                    //Display Ammount
                    txtDiscPhp.Text = discount.ToString("C", culture);
                    txtPaymentDue.Text = discounted.ToString("C", culture);
                }                
            }
            catch (Exception)
            {
                txtDiscPhp.Clear();
            }
        }
        private void setDate()
        {
            try
            {
                double due = Convert.ToDouble(Decimal.Parse(txtPaymentDue.Text, NumberStyles.Currency));

                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"UPDATE tblPurchaseOrder SET oDate = @orderDate, oDeliveryDate = @deliveryDate, paymentDue = @due WHERE referenceCode LIKE @refCode";
                    command.Parameters.AddWithValue("@orderDate", dtpOrderDate.Value.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@deliveryDate", dtpDeliveryDate.Value.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@refCode", txtReferenceCode.Text);
                    command.Parameters.AddWithValue("@due", due);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void loadPendingOrders()
        {
            try
            {
                int i = 0;
                dataGridViewPending.Rows.Clear();

                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT referenceCode, SUM(qty) AS Total_Items, oDate, oDeliveryDate, paymentDue FROM tblPurchaseOrder
                                            WHERE Status = 'Pending'
                                            GROUP BY referenceCode,oDate, oDeliveryDate, paymentDue";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            i += 1;
                            dataGridViewPending.Rows.Add(i, reader["referenceCode"].ToString(), reader["Total_Items"].ToString(), Convert.ToDateTime(reader["oDate"]).ToString("yyyy-MM-dd"), Convert.ToDateTime(reader["oDeliveryDate"]).ToString("yyyy-MM-dd"), reader["paymentDue"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine(ex.StackTrace, ex.Message, ex.InnerException);
            }
        }
        private void txtDiscPercent_TextChanged_1(object sender, EventArgs e)
        {
            calculateDiscount();
        }
        private void btnRefNo_Click(object sender, EventArgs e)
        {
            generateRefCode();
        }

        private void linkAddProducts_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPOProducts products = new frmPOProducts(this);
            products.ShowDialog();
        }

        private void cbVendor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT * FROM tblVendor 
                                            WHERE Vendor LIKE @vendor";
                    command.Parameters.AddWithValue("@vendor", cbVendor.Text);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            vendorID = int.Parse(reader["vendorID"].ToString());
                            txtContactPerson.Text = reader["ContactPerson"].ToString();
                            txtEmail.Text = reader["Email"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbOrderBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT * FROM tblUsers 
                                            WHERE Name LIKE @user";
                    command.Parameters.AddWithValue("@user", cbOrderBy.Text);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            userID = int.Parse(reader["userID"].ToString());
                            txtSenderEmail.Text = reader["email"].ToString();
                            txtSenderPassword.Text = reader["emailPassword"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void metroTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroTabControl.SelectedTab == metroTabControl.TabPages["tabPagePending"])
            {
                loadPendingOrders();
            }
        }
        private void btnCreatePo_Click(object sender, EventArgs e)
        {
            setDate();
            frmPurchaseOrderReportViewer pov = new frmPurchaseOrderReportViewer(this);
            pov.loadPurchaseOrder();
            pov.ShowDialog();
        }
    }
}

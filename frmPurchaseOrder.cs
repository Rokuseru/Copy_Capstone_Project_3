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
        public frmPurchaseOrder()
        {
            InitializeComponent();


            MainForm form = new MainForm();
            cbOrderBy.Text = form.lblUser.Text;
        }
        private void generateRefCode()
        {
            try
            {
                string referencecode = "#PCO000";
                string referenceno;
                int count;

                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT TOP 1 referenceCode FROM tblPurchaseOrder
                                            WHERE referenceCode 
                                            LIKE '"+txtReferenceCode.Text+"%' ORDER BY purchaseOrderID DESC";
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        if (reader.HasRows)
                        {
                            referenceno = reader[0].ToString();
                            count = int.Parse(referenceno.Substring(4, 4));
                            txtReferenceCode.Text = referencecode + (count + 1);
                        }
                        else
                        {
                            referenceno = referencecode + "1";
                            txtReferenceCode.Text = referenceno;
                        }
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
            catch(Exception ex)
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
            loadVendor();
            loadUser();
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
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkAddProducts_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPOProducts products = new frmPOProducts(this);
            products.ShowDialog();
        }

        private void btnRefNo_Click(object sender, EventArgs e)
        {
            generateRefCode();
        }
        private void setDate()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"UPDATE tblPurchaseOrder SET oDate = @orderDate, oDeliveryDate = @deliveryDate WHERE referenceCode LIKE @refCode";
                    command.Parameters.AddWithValue("@orderDate", dtpOrderDate.Value.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@deliveryDate", dtpDeliveryDate.Value.ToString("yyyy-MM-dd"));
                    command.Parameters.AddWithValue("@refCode", txtReferenceCode.Text);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void saveQty()
        {
            try
            {

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnCreatePo_Click(object sender, EventArgs e)
        {
            setDate();
        }
    }
}

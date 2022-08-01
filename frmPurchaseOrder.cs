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
    public partial class frmPurchaseOrder : Form
    {
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        public int vendorID = 0;
        public int userID = 0;
        public frmPurchaseOrder()
        {
            InitializeComponent();
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
                                            LIKE '"+txtReferenceCode.Text+"&' ORDER BY purchaseOrderID DESC";
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
        private void loadPO()
        {

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
        //private void createPurchaseOrder()
        //{

        //}
    }
}

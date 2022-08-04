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
    public partial class frmPurchaseOrderQuantity : Form
    {
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        private int _vid = 0;
        //private int _qty = 0;
        private int productID = 0;
        private int userID = 0;
        private double _price = 0;
        private string _refCode = " ";

        frmPurchaseOrder po;
        public frmPurchaseOrderQuantity(frmPurchaseOrder pa)
        {
            InitializeComponent();
            po = pa;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void productDetails(int vid, int pid, int uid, double price, string refCode)
        {
            this.productID = pid;
            this.userID = uid;
            this._price = price;
            this._refCode = refCode;
            this._vid = vid;
        }
        private void addToOrders()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"INSERT INTO tblPurchaseOrder (referenceCode, vendorID, userID, productID, price, qty)
                                                    VALUES (@refCode, @vendorID, @userID, @productID, @price, @qty)";
                    command.Parameters.AddWithValue("@refCode", _refCode);
                    command.Parameters.AddWithValue("@vendorID", _vid);
                    command.Parameters.AddWithValue("@userID", userID);
                    command.Parameters.AddWithValue("@productID", productID);
                    command.Parameters.AddWithValue("@price", _price);
                    command.Parameters.AddWithValue("@qty", txtQty.Text);
                    command.ExecuteNonQuery();

                    txtQty.Clear();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void addToOrderQty()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"UPDATE tblPurchaseOrder SET qty = qty + @qty WHERE productID LIKE @pid AND referenceCode LIKE @refCode";
                    command.Parameters.AddWithValue("@qty", int.Parse(txtQty.Text));
                    command.Parameters.AddWithValue("@pid", productID);
                    command.Parameters.AddWithValue("@refCode", _refCode);
                    command.ExecuteNonQuery();
                    txtQty.Clear();

                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if ((e.KeyChar == 13) && (txtQty.Text != String.Empty))
                {
                    bool found = false;

                    //Validate
                    using (var connection = new SqlConnection(con))
                    using (var command = new SqlCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = @"SELECT * FROM tblPurchaseOrder WHERE productID = @pid AND referenceCode = @refcode";
                        command.Parameters.AddWithValue("@pid", productID);
                        command.Parameters.AddWithValue(@"refcode", _refCode);

                        using (var reader = command.ExecuteReader())
                        {
                            reader.Read();
                            if (reader.HasRows)
                            {
                                found = true;
                            }
                            else
                            {
                                found = false;
                            }
                        }
                    }
                    //Insert with Validation
                    if (found == false)
                    {
                        addToOrders();
                        po.loadPO();
                    }
                    else
                    {
                        addToOrderQty();
                        po.loadPO();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

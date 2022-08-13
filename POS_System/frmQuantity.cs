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
using CapstoneProject_3.Notifications;
using System.Runtime.InteropServices;

namespace CapstoneProject_3.POS_System
{
    public partial class frmQuantity : Form
    {
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        frmPOS ps;
        private int pid;
        private double price;
        private string transacno;
        private int qty; 
        public int userID = 0;

        //Fields
        private int borderSize = 1;
        public frmQuantity(frmPOS pOS)
        {
            InitializeComponent();
            ps = pOS;
            this.Padding = new Padding(borderSize);//Border size
            this.BackColor = Color.FromArgb(53, 59, 72);//Border color
        }
        //Form Properties
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        public void productDetails(int pcode, Double price, String transacno, int qty)
        {
            this.pid = pcode;
            this.price = price;
            this.transacno = transacno;
            this.qty = qty;
        }
        public void loadUser()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT * FROM tblUsers WHERE Name LIKE @Name";
                    command.Parameters.AddWithValue("@Name", ps.lblUser.Text);
                    command.ExecuteNonQuery();
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        if (reader.HasRows)
                        {
                            userID = Convert.ToInt32(reader["userID"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.GetType());
                MessageBox.Show(ex.Message);
            }
        }
        private void addToCart()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"INSERT INTO tblCart (TransactionNo, productID, Price, qty, sDate, sTime, userID)
                                            VALUES (@transno, @pid, @price, @qty, @date,@time, @cashier)";
                    command.Parameters.AddWithValue("@transno", transacno);
                    command.Parameters.AddWithValue("@pid", pid);
                    command.Parameters.AddWithValue("@price", price);
                    command.Parameters.AddWithValue("@qty", int.Parse(txtQty.Text));
                    command.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyyMMdd"));
                    command.Parameters.AddWithValue("@time", DateTime.Now.ToString("hh:mm:ss"));
                    command.Parameters.AddWithValue("cashier", userID);
                    command.ExecuteNonQuery();

                    ps.txtSearch.Clear();
                    ps.txtSearch.Focus();

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void addToCartQuantity()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"UPDATE tblCart SET qty = qty + @qty WHERE productID LIKE @pid AND STATUS LIKE 'Pending'";
                    command.Parameters.AddWithValue("@qty", int.Parse(txtQty.Text));
                    command.Parameters.AddWithValue("@pid", pid);
                    command.ExecuteNonQuery();
                    ps.txtSearch.Clear();
                    ps.txtSearch.Focus();

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Source);
                Console.WriteLine(ex.GetType());
                MessageBox.Show(ex.Message);
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //If String Error It's this line of code
        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            int _currentCartQty = 0;
            if ((e.KeyChar == 13) && (txtQty.Text != String.Empty))
            {
                bool found = false;

                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT * FROM tblCart WHERE productID = @pid AND Status LIKE 'Pending' AND TransactionNo LIKE @transNo";
                    command.Parameters.AddWithValue("@pid", pid);
                    command.Parameters.AddWithValue("@transNo", transacno);
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        if (reader.HasRows)
                        {
                            found = true;
                            _currentCartQty = Convert.ToInt32(int.Parse(reader["qty"].ToString()));
                        }
                        else
                        {
                            found = false;
                        }
                    }
                    //Add to Cart with Validation
                    if (qty < (Convert.ToInt32(int.Parse(txtQty.Text)) + _currentCartQty))
                    {
                        MessageBox.Show("Unable To Add. Only " + qty + " Left On Hand.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtQty.Clear();
                    }
                    else
                    {
                        if (found == false)
                        {
                            addToCart();
                            ps.loadCart();
                        }
                        else
                        {
                            addToCartQuantity();
                            ps.loadCart();
                        }
                    }
                    Console.WriteLine(found);
                }       
            }
        }

        private void frmQuantity_Load(object sender, EventArgs e)
        {
            loadUser();
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}

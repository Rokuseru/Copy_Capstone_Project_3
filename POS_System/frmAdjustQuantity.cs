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
using CapstoneProject_3.Notifications;
using System.Runtime.InteropServices;

namespace CapstoneProject_3.POS_System
{
    public partial class frmAdjustQuantity : Form
    {
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        Notification ntf = new Notification();
        AuditTrail log = new AuditTrail();
        frmPOS ps;
        private int _qty;
        private int pid;

        //Fields
        private int borderSize = 1;
        public frmAdjustQuantity(frmPOS pOS)
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

        public void productDetails(int pcode)
        {
            this.pid = pcode;
        }
        public void loadCurrentQty()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT * FROM tblProduct WHERE ProductCode LIKE @pcode";
                    command.Parameters.AddWithValue("@pcode", ps.dataGridView.SelectedRows[0].Cells["pcode"].Value.ToString());
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _qty = int.Parse(reader["quantity"].ToString());
                        }
                        Console.WriteLine(_qty);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Error");
            }
        }
        public void adjustQty()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"UPDATE tblCart SET qty = @qty WHERE productID LIKE @pid";
                    command.Parameters.AddWithValue("@qty", int.Parse(txtQty.Text));
                    command.Parameters.AddWithValue("@pid", pid);
                    command.ExecuteNonQuery();

                    this.Dispose();
                }
                //logs
                log.loadUserID(ps.lblUser.Text);
                log.insertAction("Ajust Quantity", txtQty.Text, this.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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
                    command.CommandText = @"SELECT * FROM tblCart WHERE productID = @pid AND Status LIKE 'Pending'";
                    command.Parameters.AddWithValue("@pid", pid);
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
                    if (_qty < (Convert.ToInt32(int.Parse(txtQty.Text)) + _currentCartQty))
                    {
                        MessageBox.Show("Unable To Add. Only " + _qty + " Left On Hand.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtQty.Clear();
                    }
                    else
                    {
                        if (found == true)
                        {
                            adjustQty();
                            ps.loadCart();
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void frmAdjustQuantity_Load(object sender, EventArgs e)
        {
            loadCurrentQty();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
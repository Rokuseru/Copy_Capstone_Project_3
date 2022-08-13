using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using System.Data.SqlClient;
using System.Globalization;
using CapstoneProject_3.Notifications;

namespace CapstoneProject_3.POS_System
{
    public partial class frmPOS : Form
    {
        string id;
        public double price;
        public double taxVat;
        public int uid = 0;
        CultureInfo culture = CultureInfo.GetCultureInfo("en-PH");
        AuditTrail log = new AuditTrail();
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        //Fields
        private int borderSize = 2;
        private Size formSize; //Keep form size when it is minimized and restored.
                               //Since the form is resized
                               //because it takes into account the size of the title bar and borders.
        showToast toast = new showToast();
        public frmPOS()
        {
            InitializeComponent();
            KeyPreview = true;
            this.Padding = new Padding(borderSize);//Border size
            this.BackColor = Color.FromArgb(170, 166, 157);//Border color
        }
        //Form Properties
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        //Overridden methods
        protected override void WndProc(ref Message m)
        {
            const int WM_NCCALCSIZE = 0x0083;//Standar Title Bar - Snap Window
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MINIMIZE = 0xF020; //Minimize form (Before)
            const int SC_RESTORE = 0xF120; //Restore form (Before)
            const int WM_NCHITTEST = 0x0084;//Win32, Mouse Input Notification: Determine what part of the window corresponds to a point, allows to resize the form.
            const int resizeAreaSize = 10;
            #region Form Resize
            // Resize/WM_NCHITTEST values
            const int HTCLIENT = 1; //Represents the client area of the window
            const int HTLEFT = 10;  //Left border of a window, allows resize horizontally to the left
            const int HTRIGHT = 11; //Right border of a window, allows resize horizontally to the right
            const int HTTOP = 12;   //Upper-horizontal border of a window, allows resize vertically up
            const int HTTOPLEFT = 13;//Upper-left corner of a window border, allows resize diagonally to the left
            const int HTTOPRIGHT = 14;//Upper-right corner of a window border, allows resize diagonally to the right
            const int HTBOTTOM = 15; //Lower-horizontal border of a window, allows resize vertically down
            const int HTBOTTOMLEFT = 16;//Lower-left corner of a window border, allows resize diagonally to the left
            const int HTBOTTOMRIGHT = 17;//Lower-right corner of a window border, allows resize diagonally to the right

            if (m.Msg == WM_NCHITTEST)
            { //If the windows m is WM_NCHITTEST
                base.WndProc(ref m);
                if (this.WindowState == FormWindowState.Normal)//Resize the form if it is in normal state
                {
                    if ((int)m.Result == HTCLIENT)//If the result of the m (mouse pointer) is in the client area of the window
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32()); //Gets screen point coordinates(X and Y coordinate of the pointer)                           
                        Point clientPoint = this.PointToClient(screenPoint); //Computes the location of the screen point into client coordinates                          
                        if (clientPoint.Y <= resizeAreaSize)//If the pointer is at the top of the form (within the resize area- X coordinate)
                        {
                            if (clientPoint.X <= resizeAreaSize) //If the pointer is at the coordinate X=0 or less than the resizing area(X=10) in 
                                m.Result = (IntPtr)HTTOPLEFT; //Resize diagonally to the left
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize))//If the pointer is at the coordinate X=11 or less than the width of the form(X=Form.Width-resizeArea)
                                m.Result = (IntPtr)HTTOP; //Resize vertically up
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTTOPRIGHT;
                        }
                        else if (clientPoint.Y <= (this.Size.Height - resizeAreaSize)) //If the pointer is inside the form at the Y coordinate(discounting the resize area size)
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize horizontally to the left
                                m.Result = (IntPtr)HTLEFT;
                            else if (clientPoint.X > (this.Width - resizeAreaSize))//Resize horizontally to the right
                                m.Result = (IntPtr)HTRIGHT;
                        }
                        else
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize diagonally to the left
                                m.Result = (IntPtr)HTBOTTOMLEFT;
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize)) //Resize vertically down
                                m.Result = (IntPtr)HTBOTTOM;
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTBOTTOMRIGHT;
                        }
                    }
                }
                return;
            }
            #endregion
            //Remove border and keep snap window
            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                return;
            }
            //Keep form size when it is minimized and restored. Since the form is resized because it takes into account the size of the title bar and borders.
            if (m.Msg == WM_SYSCOMMAND)
            {
                int wParam = (m.WParam.ToInt32() & 0xFFF0);
                if (wParam == SC_MINIMIZE)  //Before
                    formSize = this.ClientSize;
                if (wParam == SC_RESTORE)// Restored form(Before)
                    this.Size = formSize;
            }

            base.WndProc(ref m);
        }

        private void frmPOS_Resize(object sender, EventArgs e)
        {
            AdjustForm();
        }

        private void AdjustForm()
        {
            switch (this.WindowState)
            {
                case FormWindowState.Maximized: //Maximized form (After)
                    this.Padding = new Padding(8, 8, 8, 8);
                    break;
                case FormWindowState.Normal: //Restored form (After)
                    if (this.Padding.Top != borderSize)
                        this.Padding = new Padding(borderSize);
                    break;
            }
        }
        public void getTransNumber()
        {
            try
            {
                string date = DateTime.Now.ToString("#"+"yyMMdd");
                string transacno;
                int count;

                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT TOP 1 TransactionNo FROM tblCart 
                                            WHERE TransactionNo 
                                            LIKE '" + date + "%' ORDER BY cartID DESC";
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        if (reader.HasRows)
                        {
                            transacno = reader[0].ToString();
                            count = int.Parse(transacno.Substring(7, 4));
                            lblTransNo.Text = date + (count + 1);
                        }
                        else
                        {
                            transacno = date + "1001";
                            lblTransNo.Text = transacno;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void searchProducts()
        {
            try
            {
                frmQuantity frmQty = new frmQuantity(this);
                frmProductSearch frm = new frmProductSearch(this);

                int qty;
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT * FROM tblProduct WHERE Description LIKE '"+txtSearch.Text+"'";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            qty = int.Parse(reader["quantity"].ToString());
                            frmQty.productDetails(int.Parse(reader["productID"].ToString()), double.Parse(reader["Price"].ToString()), lblTransNo.Text, qty);
                            frmQty.ShowDialog();
                            frmQty.txtQty.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void loadVat()
        {
            using (var connection = new SqlConnection(con))
            using (var command = new SqlCommand())
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = @"SELECT * FROM tblTax WHERE taxID like 1";
                
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        taxVat = Double.Parse(reader["taxVat"].ToString());
                    }
                }
            }
        }
        public void loadCart()
        {
            try
            {
                dataGridView.Rows.Clear();
                int i = 0;
                double total = 0;
                double discount = 0;
                int qty = 0;

                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"select * from viewCart WHERE Status LIKE 'Pending' AND TransactionNo LIKE @tnumber";
                    command.Parameters.AddWithValue("@tnumber", lblTransNo.Text);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            i += 1;
                            total += Double.Parse(reader["Total"].ToString());
                            discount += Double.Parse(reader["discount"].ToString());
                            qty += int.Parse(reader["qty"].ToString());
                            dataGridView.Rows.Add(i, reader["cartID"].ToString(), reader["productID"].ToString(), reader["productCode"].ToString(), reader["Description"].ToString(), reader["Price"].ToString(),
                                reader["qty"].ToString(), reader["discount"].ToString(), Double.Parse(reader["Total"].ToString()).ToString("#,#00.00"));
                        }
                        lblSubTotal.Text = total.ToString("C", culture);
                        lblTopTotal.Text = total.ToString("C", culture);
                        lblDiscount.Text = discount.ToString("C", culture);
                        lblTotalQty.Text = qty.ToString();
                        loadVat();
                        computeCartSales();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void deleteFromCart()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"DELETE FROM tblCart WHERE cartID LIKE @cid";
                    command.Parameters.AddWithValue("@cid", dataGridView.CurrentRow.Cells["cartID"].Value.ToString());
                    command.ExecuteNonQuery();

                    toast.showToastNotifInPanel(new ToastNotification("Deleted Sucessfully", Color.FromArgb(16, 172, 132), FontAwesome.Sharp.IconChar.CheckCircle), panelBottom);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void computeCartSales()
        {

            frmSettlePayment spayment = new frmSettlePayment(this);
            loadVat();
            //Variables
            double sales = Convert.ToDouble(Decimal.Parse(lblSubTotal.Text, NumberStyles.Currency));
            double discount = Convert.ToDouble(Decimal.Parse(lblDiscount.Text, NumberStyles.Currency));
            double vat = taxVat;
            double vatable = Convert.ToDouble(Decimal.Parse(lblSubTotal.Text, NumberStyles.Currency));
            double cash = double.Parse(spayment.txtPayment.Text);
            //Compute
            double vatAmount = vatable * vat;
            double total = sales + vatAmount;

            lblTopTotal.Text = total.ToString("C", culture);
            lblCash.Text = cash.ToString("C", culture);
            lblVat.Text = vatAmount.ToString("C", culture);
            lblVatable.Text = vatable.ToString("C", culture);
        }
        private void loadSearch()
        {
            var itemCollection = new AutoCompleteStringCollection();

            using (var connection = new SqlConnection(con))
            {
                connection.Open();
                var command = new SqlCommand(@"SELECT * FROM tblProduct WHERE Description LIKE '%" + txtSearch.Text + "%'", connection);
                SqlDataReader dr = command.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        itemCollection.Add(dr["Description"].ToString());
                    }
                }
                txtSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                txtSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;
                txtSearch.AutoCompleteCustomSource = itemCollection;
            }
        }
        public void reset()
        {
            dataGridView.Rows.Clear();
            btnAddDisc.Enabled = false;
            btnSearchProd.Enabled = false;
            btnSettle.Enabled = false;
        }
        private void checkTimeIn()
        {
            try
            {
                loadUsers();
                bool found;
                string timeIn = "";

                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT * FROM tblAttendance WHERE userID LIKE @uid AND aDate LIKE @date";
                    command.Parameters.AddWithValue("@uid", uid);
                    command.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));

                    //Validate
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            timeIn = DateTime.Parse(reader["Time_In"].ToString()).ToString("hh:mm:ss");
                        }
                        if (reader.HasRows)
                        {
                            found = true;
                        }
                        else
                        {
                            found = false;
                        }
                    }
                    if (found == true)
                    {
                        MessageBox.Show("Timed-In Already", "Reminder", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Please Time-In First", "Reminder", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnNewTrans_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count > 0)
            {
                toast.showToastNotifInPanel(new ToastNotification("Category Already Exists.", Color.FromArgb(198, 40, 40), FontAwesome.Sharp.IconChar.ExclamationCircle), panelBottom);
            }
            else
            {
                getTransNumber();
            }
        }
       
        private void btnLogout_Click(object sender, EventArgs e)
        {
            //Check If User Has Timed Out
            try
            {
                loadUsers();
                bool found;
                string timeIn = "";
                string timeOut = "";

                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT * FROM tblAttendance WHERE userID LIKE @uid AND aDate LIKE @date";
                    command.Parameters.AddWithValue("@uid", uid);
                    command.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            timeIn = DateTime.Parse(reader["Time_In"].ToString()).ToString("hh:mm:ss");
                            timeOut = reader["Time_Out"].ToString();
                        }
                        if (reader.HasRows)
                        {
                            found = true;
                        }
                        else
                        {
                            found = false;
                        }
                        Console.WriteLine(timeOut);
                        Console.WriteLine(timeIn);
                        Console.WriteLine(found);
                    }
                    if (String.IsNullOrWhiteSpace(timeOut))
                    {
                        MessageBox.Show("Please Time-Out Before Loggin Out");
                    }
                    else
                    {
                        if (MessageBox.Show("Log Out Application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            if (this.lblRole.Text == "Admin")
                            {
                                MainForm main = new MainForm();
                                //logs
                                log.loadUserID(lblUser.Text);
                                log.insertAction("Logout", "User: " + lblUser.Text + "Role: " + lblRole.Text, this.Text);
                                main.Show();
                                this.Close();
                            }
                            else
                            {
                                frmLogin login = new frmLogin();
                                //logs
                                log.loadUserID(lblUser.Text);
                                log.insertAction("Logout", "User: " + lblUser.Text + "Role: " + lblRole.Text, this.Text);
                                login.Show();
                                this.Close();
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            } 
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnSearchProd_Click(object sender, EventArgs e)
        {
            frmProductSearch psearch = new frmProductSearch(this);
            psearch.ShowDialog();

            if (dataGridView.Rows.Count > 0)
            {
                btnAddDisc.Enabled = true;
                btnSettle.Enabled = true;
            }
            else
            {
                btnAddDisc.Enabled = false;
                btnSettle.Enabled = false;
            }
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colname = dataGridView.Columns[e.ColumnIndex].Name;

            //Remove from cart
            if (colname == "remove")
            {
                if (MessageBox.Show("Remove from Cart?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)==DialogResult.OK)
                {
                    deleteFromCart();
                    loadCart();
                }
                else
                {
                    toast.showToastNotifInPanel(new ToastNotification("Operation Cancelled.", Color.FromArgb(21, 101, 192), FontAwesome.Sharp.IconChar.Ban), panelBottom);
                }
            }
            //Adjust Quantity
            else if (colname == "adjustQty")
            {
                frmAdjustQuantity adj = new frmAdjustQuantity(this);
                adj.productDetails(int.Parse(dataGridView.Rows[e.RowIndex].Cells["pid"].Value.ToString()));
                adj.txtQty.Focus();
                adj.ShowDialog();
            }
        }

        private void btnAddDisc_Click(object sender, EventArgs e)
        {
            frmDiscount disc = new frmDiscount(this);
            disc.txtDiscount.Focus();
            disc.lblID.Text = id;
            disc.txtPrice.Text = price.ToString("C", culture);                                       
            disc.ShowDialog();
        }

        private void dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            int i = dataGridView.CurrentRow.Index;
            id = dataGridView[1, i].Value.ToString();
            price = double.Parse(dataGridView["TotalPrice", i].Value.ToString());
        }

        private void btnSettle_Click(object sender, EventArgs e)
        {
            frmSettlePayment payment = new frmSettlePayment(this);
            payment.txtBill.Text = lblTopTotal.Text;
            payment.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
            lblDate.Text = DateTime.Now.ToString("dddd ,yyyy, MMMM, dd");
        }

        private void frmPOS_Load(object sender, EventArgs e)
        {        
            loadSearch();
            timer1.Start();
            checkTimeIn();
            if (dataGridView.Rows.Count == 0 || dataGridView == null)
            {
                btnAddDisc.Enabled = false;
                btnSettle.Enabled = false;
            }
            else
            {
                btnAddDisc.Enabled = true;
                btnSettle.Enabled = true;
            }
        }

        private void btnDailySales_Click(object sender, EventArgs e)
        {
            frmDailySales dailySales = new frmDailySales(this);
            dailySales.ShowDialog();
        }

        private void frmPOS_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F1)
            {
                btnNewTrans_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F2)
            {
                btnSearchProd_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F3)
            {
                btnAddDisc_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F4)
            {
                btnSettle_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F5)
            {
                //btnCancel_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F6)
            {
                btnDailySales_Click(sender, e);
            }
            else if (e.KeyCode == Keys.F10)
            {
                btnLogout_Click(sender, e);
            }
            else
            {
                return;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Cancel Current Transaction?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
            {
                reset();
                cancelSales();
                lblTotalQty.Text = "0";
                lblChange.Text = "₱0.00";
                lblDiscount.Text = "₱0.00";
                lblSubTotal.Text = "₱0.00";
                lblTopTotal.Text = "₱0.00";
                lblVatable.Text = "0.00";
                lblVat.Text = "0.00";
            }
            else
            {
                return;
            }
        }
        private void cancelSales()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"DELETE FROM tblCart WHERE TransactionNo LIKE @tno";
                    command.Parameters.AddWithValue("tno", lblTransNo.Text);
                    command.ExecuteNonQuery();
                }
                //logs
                log.loadUserID(lblUser.Text);
                log.insertAction("Transaction Cancelled", "Cancelled Transaction with Transaction Number: "+lblTransNo.Text, this.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //For the Attendance Methods---
        private void loadUsers()
        {
            try
            {
                //Load user ID
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT * FROM tblUsers WHERE Name LIKE @name";
                    command.Parameters.AddWithValue("@name", lblUser.Text);
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
                MessageBox.Show(ex.Message, "Error");
            }
        }
        private void timeIn()
        {
            loadUsers();
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"INSERT INTO tblAttendance (userID, aDate, Time_In)
                                            VALUES (@uid, @date, @timeIn)";
                    command.Parameters.AddWithValue("@uid", uid);
                    command.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyyMMdd"));
                    command.Parameters.AddWithValue("@timeIn", DateTime.Now.ToString("hh:mm:ss"));
                    command.ExecuteNonQuery();
                }
                //logs
                log.loadUserID(lblUser.Text);
                log.insertAction("Time-In", "User Time-in At " + DateTime.Now.ToString("hh:mm:ss") + " on " + DateTime.Now.ToString("yyyy-MM-dd"), this.Text);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }
        public void timeOut()
        {
            try
            {
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"UPDATE tblAttendance SET Time_Out = @out WHERE userID = @uid AND aDate = @date";
                    command.Parameters.AddWithValue("@out", DateTime.Now.ToString("HH:mm:ss"));
                    command.Parameters.AddWithValue("@uid", uid);
                    command.Parameters.AddWithValue("@date", DateTime.Now.ToString("yyyy-MM-dd"));
                    command.ExecuteNonQuery();
                }
                //logs
                log.loadUserID(lblUser.Text);
                log.insertAction("Time-Out", "User Time-out At " + DateTime.Now.ToString("hh:mm:ss") + " on " + DateTime.Now.ToString("yyyy-MM-dd"), this.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnTimeIn_Click(object sender, EventArgs e)
        {
            timeIn();
        }

        private void btnTimeOut_Click(object sender, EventArgs e)
        {
            timeOut();
            frmXandZReports xz = new frmXandZReports(this);
            xz.ShowDialog();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                searchProducts();
            }
        }
    }
}

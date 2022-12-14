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
using Tulpep.NotificationWindow;
using System.Globalization;
using CapstoneProject_3.POS_System;

namespace CapstoneProject_3
{
    public partial class MainForm : Form
    {
        public string nameOfUser = " ";
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        AuditTrail log = new AuditTrail();
        //Fields
        private int borderSize = 2;
        private Size formSize; //Keep form size when it is minimized and restored.
                               //Since the form is resized
                               //because it takes into account the size of the title bar and borders.
        private Form currentChildForm;
        private IconButton currentBtn;
        public MainForm()
        {
            InitializeComponent();
            //CollapseMenu();
            lblRole.Visible = true;
            lblUser.Visible = true;
            CollapseAllDropDown();
            this.Padding = new Padding(borderSize);//Border size
            this.BackColor = Color.FromArgb(170, 166, 157);//Border color
            notificationCriticalItems();
            collapseDropDownHeight(btnContainer1);
            collapseDropDownHeight(btnContainer2);
            CollapseDropDownForRecords();
            CollapseDropDownForSU();
            this.WindowState = FormWindowState.Maximized;
        }
        private void ActivateButton(object senderBtn)
        {
            if (senderBtn != null)
            {
                DisableButton();
                //Button
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(247, 241, 227);
                currentBtn.ForeColor = Color.FromArgb(30, 39, 46);
                currentBtn.IconColor = Color.FromArgb(30, 39, 46);
            }
            else
            {
                DisableButton();
            }
        }
        private void DisableButton()
        {
            if (currentBtn != null)
            {
                currentBtn.BackColor = Color.FromArgb(30, 39, 46);
                currentBtn.ForeColor = Color.FromArgb(247, 241, 227);
                currentBtn.IconColor = Color.FromArgb(247, 241, 227);
            }
        }
        private void Reset()
        {
            DisableButton();
            panelDesktop.Controls.Clear();
        }
        //Form Properties
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
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

        private void MainForm_Resize(object sender, EventArgs e)
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

        private void btnMinimizeWindow_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                formSize = this.ClientSize;
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.Size = formSize;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            btnLogout_Click(sender, e);
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            CollapseMenu();
            CollapseAllDropDown();
        }

        private void CollapseMenu()
        {
            if (this.panelMenu.Width > 200) //Collapse menu
            {
                panelMenu.Width = 100;
                pictureBox1.Visible = false;
                btnMenu.Dock = DockStyle.Top;
                foreach (IconButton menuButton in panelMenu.Controls.OfType<IconButton>())
                {
                    menuButton.Text = "";
                    menuButton.ImageAlign = ContentAlignment.MiddleCenter;
                    menuButton.Padding = new Padding(0);
                    panelImageContainer.Height = 94;
                    lblRole.Visible = false;
                    lblUser.Visible = false;
                }
            }
            else
            { //Expand menu
                panelMenu.Width = 210;
                pictureBox1.Visible = true;
                btnMenu.Dock = DockStyle.None;
                foreach (IconButton menuButton in panelMenu.Controls.OfType<IconButton>())
                {
                    menuButton.Text = menuButton.Tag.ToString();
                    menuButton.ImageAlign = ContentAlignment.MiddleLeft;
                    menuButton.Padding = new Padding(10, 0, 0, 0);
                    panelImageContainer.Height = 130;
                    lblRole.Visible = true;
                    lblUser.Visible = true;
                }
            }
        }
        private void CollapseAllDropDown()
        {
            CollapseDropDownWidth(btnContainer1);
            CollapseDropDownWidth(btnContainer2);
            CollapseDropDownWidth(btnContainer3);
            CollapseDropDownWidth(btnContainer4);
        }
        private void collapseDropDownHeight(Panel btnContainer)
        {
            if (btnContainer.Height > 100)//Collapse
            {
                btnContainer.Visible = false;
                btnContainer.Height = 43;

                foreach(IconButton button in btnContainer.Controls.OfType<IconButton>())
                {
                    button.Visible = false;
                }
            }
            else
            {
                btnContainer.Visible = true;
                btnContainer.Height = 140;
                foreach (IconButton button in btnContainer.Controls.OfType<IconButton>())
                {
                    button.Visible = true;
                    button.ImageAlign = ContentAlignment.MiddleLeft;
                    button.TextAlign = ContentAlignment.MiddleLeft;
                    button.Padding = new Padding(25, 0, 0, 0);
                }
            }
        }
        private void CollapseDropDownWidth(Panel btnContainer)
        {
            if (this.panelMenu.Width < 150) //Collapse menu
            {
                btnContainer.Width = 100;
                foreach (IconButton menuButton in btnContainer.Controls.OfType<IconButton>())
                {
                    menuButton.Text = "";
                    menuButton.ImageAlign = ContentAlignment.MiddleCenter;
                    menuButton.Padding = new Padding(0);
                }
            }
            else
            { //Expand menu
                btnContainer.Width = 210;
                foreach (IconButton menuButton in btnContainer.Controls.OfType<IconButton>())
                {
                    menuButton.Text = menuButton.Tag.ToString();
                    menuButton.ImageAlign = ContentAlignment.MiddleLeft;
                    menuButton.Padding = new Padding(25, 0, 0, 0);
                }
            }
        }
        private void OpenChildForm(Form childForm)
        {
            //open only form
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            //End
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelDesktop.Controls.Add(childForm);
            panelDesktop.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblCurrentChildForm.Text = childForm.Text;
        }       
        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Log Out Application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)==DialogResult.Yes)
            {
                frmLogin login = new frmLogin();
                //Logs
                log.loadUserID(lblUser.Text);
                log.insertAction("Logout", "User: " + lblUser.Text + " Role: " + lblRole.Text, this.Text);
                this.Close();
                login.Show();
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Reset();
        }
        public void notificationCriticalItems()
        {
            try
            {
                string critical = " ";
                int i = 0;

                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT * FROM viewCriticalStock";
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            i++;
                            critical += i + ". " + reader["Description"].ToString() + Environment.NewLine;
                        }
                    }
                    PopupNotifier popup = new PopupNotifier();
                    popup.Image = Properties.Resources.icons8_exclamation_30;
                    popup.TitleText = "Critical Items";
                    popup.ContentText = critical;
                    popup.Popup();

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }
        public void loadName()
        {
            nameOfUser = lblUser.Text;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            OpenChildForm(new frmDashboard());
            loadName();
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new frmDashboard());
        }
      
        private void btnPOS_Click_1(object sender, EventArgs e)
        {
            frmPOS pos = new frmPOS();
            pos.lblRole.Text = lblRole.Text;
            pos.lblUser.Text = lblUser.Text;
            this.Hide();
            pos.Show();
        }

        private void btnDropDownProducts_Click(object sender, EventArgs e)
        {
            if (btnContainer1.Height > 100)//Collapse
            {
                btnContainer1.Visible = false;
                btnContainer1.Height = 43;

                foreach (IconButton button in btnContainer1.Controls.OfType<IconButton>())
                {
                    button.Visible = false;
                }
            }
            else
            {
                btnContainer1.Visible = true;
                btnContainer1.Height = 184;
                foreach (IconButton button in btnContainer1.Controls.OfType<IconButton>())
                {
                    button.Visible = true;
                    button.ImageAlign = ContentAlignment.MiddleLeft;
                    button.TextAlign = ContentAlignment.MiddleLeft;
                    button.Padding = new Padding(25, 0, 0, 0);
                }
            }
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            if (btnContainer2.Height > 100)//Collapse
            {
                btnContainer2.Visible = false;
                btnContainer2.Height = 43;

                foreach (IconButton button in btnContainer2.Controls.OfType<IconButton>())
                {
                    button.Visible = false;
                }
            }
            else
            {
                btnContainer2.Visible = true;
                btnContainer2.Height = 175;
                foreach (IconButton button in btnContainer2.Controls.OfType<IconButton>())
                {
                    button.Visible = true;
                    button.ImageAlign = ContentAlignment.MiddleLeft;
                    button.TextAlign = ContentAlignment.MiddleLeft;
                    button.Padding = new Padding(25, 0, 0, 0);
                }
            }
        }

        private void CollapseDropDownForSU()
        {
            if (this.btnContainer3.Height > 50)//Collapse
            {
                this.btnContainer3.Visible = false;
                this.btnContainer3.Height = 43;

                foreach (IconButton button in this.btnContainer3.Controls.OfType<IconButton>())
                {
                    button.Visible = false;
                }
            }
            else
            {
                this.btnContainer3.Visible = true;
                this.btnContainer3.Height = 93;
                foreach (IconButton button in this.btnContainer3.Controls.OfType<IconButton>())
                {
                    button.Visible = true;
                    button.ImageAlign = ContentAlignment.MiddleLeft;
                    button.TextAlign = ContentAlignment.MiddleLeft;
                    button.Padding = new Padding(25, 0, 0, 0);
                }
            }
        }
        private void btnSuppliersAndUsers_Click(object sender, EventArgs e)
        {
            if (this.btnContainer3.Height > 50)//Collapse
            {
                this.btnContainer3.Visible = false;
                this.btnContainer3.Height = 43;

                foreach (IconButton button in this.btnContainer3.Controls.OfType<IconButton>())
                {
                    button.Visible = false;
                }
            }
            else
            {
                this.btnContainer3.Visible = true;
                this.btnContainer3.Height = 51;
                foreach (IconButton button in this.btnContainer3.Controls.OfType<IconButton>())
                {
                    button.Visible = true;
                    button.ImageAlign = ContentAlignment.MiddleLeft;
                    button.TextAlign = ContentAlignment.MiddleLeft;
                    button.Padding = new Padding(25, 0, 0, 0);
                }
            }
        }
        private void CollapseDropDownForRecords()
        {
            if (this.btnContainer4.Height > 50)//Collapse
            {
                this.btnContainer4.Visible = false;
                this.btnContainer4.Height = 43;

                foreach (IconButton button in this.btnContainer4.Controls.OfType<IconButton>())
                {
                    button.Visible = false;
                }
            }
            else
            {
                this.btnContainer4.Visible = true;
                this.btnContainer4.Height = 143;
                foreach (IconButton button in this.btnContainer4.Controls.OfType<IconButton>())
                {
                    button.Visible = true;
                    button.ImageAlign = ContentAlignment.MiddleLeft;
                    button.TextAlign = ContentAlignment.MiddleLeft;
                    button.Padding = new Padding(25, 0, 0, 0);
                }
            }
        }
        private void btnRecords_Click(object sender, EventArgs e)
        {
            CollapseDropDownForRecords();
        }

        private void btnBrand_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new frmBrand(this));
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new frmCategory(this));
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new frmProducts(this));
        }

        private void btnPurchaseOrder_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new frmPurchaseOrder());
        }

        private void btnStockIn_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new frmStockEntry(this));
        }

        private void btnStockAdjustment_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new frmStockAdjustment(this));
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new frmAccounts(this));
        }

        private void btnVendor_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new frmVendor(this));
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new frmHistory());
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new frmRecords());
        }

        private void btnActivityLog_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new frmAuditTrail());
        }

        private void btnWarehouse_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new frmInventory());
        }
    }
}
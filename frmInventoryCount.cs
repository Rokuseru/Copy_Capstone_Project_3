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
using System.Runtime.InteropServices;

namespace CapstoneProject_3
{
    public partial class frmInventoryCount : Form
    {
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        //Fields
        private int borderSize = 1;
        private Size formSize; //Keep form size when it is minimized and restored.
                               //Since the form is resized
                               //because it takes into account the size of the title bar and borders.
        public frmInventoryCount()
        {
            InitializeComponent();
            this.Padding = new Padding(borderSize);//Border size
            this.BackColor = Color.FromArgb(53, 59, 72);//Border color
            this.panel1.BackColor = Color.White;
        }
        //Form Properties
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
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
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
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
        public void loadProductQTY()
        {
            try
            {
                dataGridView.Rows.Clear();
                int i = 0;
                int n = 0;
                int qty = 0;

                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT productID, Description, quantity FROM tblProduct";

                    using (var reader = command.ExecuteReader())
                    {
                       while (reader.Read())
                        {
                            i += 1;
                            qty += int.Parse(reader["quantity"].ToString());
                            dataGridView.Rows.Add(i, reader["productID"].ToString(), reader["Description"].ToString(), reader["quantity"].ToString());
                        }
                        lblSystemItems.Text = qty.ToString();
                    }
                }

                int q = 0;
                using (var connection = new SqlConnection(con))
                using (var command = new SqlCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.CommandText = @"SELECT productID, Description FROM tblProduct";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            n += 1;
                            dataGridViewStore.Rows.Add(n, reader["productID"].ToString(), reader["Description"].ToString(), q);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }      
        private void checkQty()
        {
            int storeQty = 0;
            for (int i = 0;i < this.dataGridView.Rows.Count; i++)
            {
                storeQty += Convert.ToInt32(dataGridViewStore.Rows[i].Cells["quantity"].Value);
            }
            lblStoreItems.Text = storeQty.ToString();
            
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
        private void btnCompare_Click(object sender, EventArgs e)
        {
            compare();
        }
        private void dataGridViewStore_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            checkQty();
        }  
        private void compare()
        {
            DataTable src1 = new DataTable();
            DataTable src2 = new DataTable();

            foreach (DataGridViewColumn col in dataGridView.Columns)
            {
                src1.Columns.Add(col.Name);
            }
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                DataRow dr = src1.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dr[cell.ColumnIndex] = cell.Value;
                }
                src1.Rows.Add(dr);
            }
            //Store
            foreach (DataGridViewColumn col in dataGridViewStore.Columns)
            {
                src2.Columns.Add(col.Name);
            }
            foreach (DataGridViewRow row in dataGridViewStore.Rows)
            {
                DataRow dr = src2.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dr[cell.ColumnIndex] = cell.Value;
                }
                src2.Rows.Add(dr);
            }

            for (int i = 0; i < src1.Rows.Count; i++)
            {
                var row1 = src1.Rows[i].ItemArray;
                var row2 = src2.Rows[i].ItemArray;

                for (int j = 0; j < row1.Length; j++)
                {
                    if (row1[j].ToString().Equals(row2[j].ToString()))
                    {
                        dataGridView.Rows[i].Cells[j].Style.BackColor = Color.FromArgb(52, 152, 219);
                        dataGridViewStore.Rows[i].Cells[j].Style.BackColor = Color.FromArgb(52, 152, 219);
                    }
                    else if (!row1[j].ToString().Equals(row2[j].ToString()))
                    {
                        dataGridView.Rows[i].Cells[j].Style.BackColor = Color.FromArgb(231, 76, 60);
                        dataGridViewStore.Rows[i].Cells[j].Style.BackColor = Color.FromArgb(231, 76, 60);
                    }
                }
            }
        }
        private void lblStoreItems_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int store = int.Parse(lblSystemItems.Text);
                int system = int.Parse(lblStoreItems.Text);

                int diff = store - system;

                if (diff == 0)
                {
                    lblDifference.Text = "Item(s) From Store and System Matched.";
                }
                else
                {
                    lblDifference.Text = diff.ToString();
                }
            }
            catch (Exception)
            {
               
            }
        }
        private void frmInventoryCount_Resize(object sender, EventArgs e)
        {
            AdjustForm();
        }

        private void frmInventoryCount_Load(object sender, EventArgs e)
        {
            dataGridView.CurrentCell = null;
            dataGridViewStore.CurrentCell = null;
        }
    }
}

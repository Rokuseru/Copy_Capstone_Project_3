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

namespace CapstoneProject_3.POS_System
{
    public partial class frmXandZReports : Form
    {
        frmPOS pos;
        //Fields
        private int borderSize = 1;
        public frmXandZReports(frmPOS p)
        {
            InitializeComponent();
            pos = p;
            this.Padding = new Padding(borderSize);//Border size
            this.BackColor = Color.FromArgb(53, 59, 72);//Border color
            this.panel2.BackColor = Color.White;
        }
        //Form Properties
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnZReport_Click(object sender, EventArgs e)
        {
            frmZReport z = new frmZReport();
            z.loadZReport();
            z.ShowDialog();
        }

        private void btnXReport_Click(object sender, EventArgs e)
        {
            frmXReport x = new frmXReport(pos);
            x.loadXReport();
            x.ShowDialog();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}

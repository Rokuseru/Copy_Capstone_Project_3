using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapstoneProject_3.POS_System
{
    public partial class frmXandZReports : Form
    {
        frmPOS pos;
        public frmXandZReports(frmPOS p)
        {
            InitializeComponent();
            pos = p;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnZReport_Click(object sender, EventArgs e)
        {
            frmZReport z = new frmZReport();
            z.ShowDialog();
        }

        private void btnXReport_Click(object sender, EventArgs e)
        {
            frmXReport x = new frmXReport(pos);
            x.ShowDialog();
        }
    }
}

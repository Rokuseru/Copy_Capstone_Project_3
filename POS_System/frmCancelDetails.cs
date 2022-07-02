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

namespace CapstoneProject_3.POS_System
{
    public partial class frmRefundDetails : Form
    {
        private string con = System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
        frmDailySales ds;
        public frmRefundDetails(frmDailySales fds)
        {
            ds = fds;
            InitializeComponent();
        }
        public void refreshTable()
        {
            ds.loadRecord();
        }

        private void btnMinimizeWindow_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnCancelSales_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbAction.Text == string.Empty || txtQty.Text == string.Empty 
                    || String.IsNullOrWhiteSpace(txtReason.Text))
                {
                    MessageBox.Show("A Field Is Empty.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (int.Parse(txtQty.Text) <= int.Parse(txtQty.Text))
                    {
                        frmVoid frmVoid = new frmVoid(this);
                        frmVoid.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace CapstoneProject_3.Notifications
{
    public partial class ToastNotification : Form
    {
        public ToastNotification(String message, Color bgColor, IconChar icon)
        {
            InitializeComponent();
            BackColor = bgColor;
            lblMessage.Text = message;
            notificationIcon.IconChar = icon;
            notificationIcon.BackColor = bgColor;
        }

        private void ToastNotification_Load(object sender, EventArgs e)
        {
            notificationTimer.Start();
        }

        private void notificationTimer_Tick(object sender, EventArgs e)
        {
            Close();
        }
    }
}

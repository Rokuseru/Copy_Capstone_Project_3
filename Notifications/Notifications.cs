using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace CapstoneProject_3.Notifications
{
    public class Notification
    {
        public void notificationMessage(Panel panelName, Label label, IconPictureBox icon, String message)
        {
            panelName.BackColor = Color.FromArgb(16, 172, 132);
            panelName.Visible = true;
            icon.IconChar = IconChar.CheckCircle;
            icon.BackColor = Color.FromArgb(16, 172, 132); ;
            label.Text = message;
        }
        public void cancelMessage(Panel panelName, Label label, IconPictureBox icon)
        {
            panelName.BackColor = Color.FromArgb(46, 134, 222);
            panelName.Visible = true;
            icon.BackColor = Color.FromArgb(46, 134, 222);
            label.Text = "Operation Cancelled";
            icon.IconChar = IconChar.Slash;
        }
        public void errorMessage(Panel panelName, Label label, IconPictureBox icon, String msg)
        {
            panelName.BackColor = Color.FromArgb(238, 82, 83);
            panelName.Visible = true;
            icon.IconChar = IconChar.ExclamationCircle;
            icon.BackColor = Color.FromArgb(238, 82, 83);
            label.Text = msg;
        }
        public void exceptionMessage(Panel panelName, Label label, IconPictureBox icon, Exception ex)
        {
            panelName.BackColor = Color.FromArgb(238, 82, 83);
            panelName.Visible = true;
            icon.BackColor = Color.FromArgb(238, 82, 83);
            icon.IconChar = IconChar.ExclamationCircle;
            label.Text = ex.Message;
        }

        public void notificationTimer(Timer timer, Panel panel)
        {
            var t = new Timer();
            t.Interval = 2000;
            t.Tick += (s, r) =>
            {
                panel.Visible = false;
                t.Stop();
            };
            t.Start();
        }
    }
}

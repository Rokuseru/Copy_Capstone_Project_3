using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using MetroFramework.Controls;

namespace CapstoneProject_3.Notifications
{
    class showToast
    {
        public void showToastNotif(Form toastForm, MetroTabPage tabPage)
        {
            toastForm.TopLevel = false;
            tabPage.Controls.Add(toastForm);
            toastForm.FormBorderStyle = FormBorderStyle.None;
            toastForm.Dock = DockStyle.Bottom;
            toastForm.Show();
        }
        public void showToastNotifInPanel(Form toastForm, Panel panel)
        {
            toastForm.TopLevel = false;
            panel.Controls.Add(toastForm);
            toastForm.FormBorderStyle = FormBorderStyle.None;
            toastForm.Dock = DockStyle.Bottom;
            toastForm.Show();
        }
    }
}

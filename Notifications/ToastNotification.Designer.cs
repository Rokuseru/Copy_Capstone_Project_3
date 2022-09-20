
namespace CapstoneProject_3.Notifications
{
    partial class ToastNotification
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.notificationIcon = new FontAwesome.Sharp.IconPictureBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.notificationTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.notificationIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // notificationIcon
            // 
            this.notificationIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.notificationIcon.Dock = System.Windows.Forms.DockStyle.Left;
            this.notificationIcon.IconChar = FontAwesome.Sharp.IconChar.MoneyCheckAlt;
            this.notificationIcon.IconColor = System.Drawing.Color.White;
            this.notificationIcon.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.notificationIcon.IconSize = 29;
            this.notificationIcon.Location = new System.Drawing.Point(0, 0);
            this.notificationIcon.Name = "notificationIcon";
            this.notificationIcon.Size = new System.Drawing.Size(29, 29);
            this.notificationIcon.TabIndex = 0;
            this.notificationIcon.TabStop = false;
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.White;
            this.lblMessage.Location = new System.Drawing.Point(45, 3);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(667, 23);
            this.lblMessage.TabIndex = 1;
            this.lblMessage.Text = "Message for notification";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // notificationTimer
            // 
            this.notificationTimer.Interval = 5000;
            this.notificationTimer.Tick += new System.EventHandler(this.notificationTimer_Tick);
            // 
            // ToastNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(887, 29);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.notificationIcon);
            this.Name = "ToastNotification";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "ToastNotification";
            this.Load += new System.EventHandler(this.ToastNotification_Load);
            ((System.ComponentModel.ISupportInitialize)(this.notificationIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconPictureBox notificationIcon;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Timer notificationTimer;
    }
}
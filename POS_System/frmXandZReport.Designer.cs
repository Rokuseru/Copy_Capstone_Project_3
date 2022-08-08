
namespace CapstoneProject_3.POS_System
{
    partial class frmXandZReport
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnExit = new FontAwesome.Sharp.IconButton();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.lblTopTotal = new System.Windows.Forms.Label();
            this.cbSelectReport = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOpened = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbUsers = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnPrint = new RJCodeAdvance.RJControls.RJButton();
            this.panel1.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(562, 45);
            this.panel1.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(14, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 21);
            this.label4.TabIndex = 15;
            this.label4.Text = "X and Z Report";
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(28)))), ((int)(((byte)(31)))));
            this.btnExit.IconChar = FontAwesome.Sharp.IconChar.WindowClose;
            this.btnExit.IconColor = System.Drawing.Color.White;
            this.btnExit.IconFont = FontAwesome.Sharp.IconFont.Regular;
            this.btnExit.IconSize = 25;
            this.btnExit.Location = new System.Drawing.Point(515, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(47, 45);
            this.btnExit.TabIndex = 7;
            this.btnExit.Tag = "";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = false;
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.btnPrint);
            this.MainPanel.Controls.Add(this.textBox3);
            this.MainPanel.Controls.Add(this.label6);
            this.MainPanel.Controls.Add(this.textBox2);
            this.MainPanel.Controls.Add(this.label5);
            this.MainPanel.Controls.Add(this.textBox1);
            this.MainPanel.Controls.Add(this.label3);
            this.MainPanel.Controls.Add(this.cbUsers);
            this.MainPanel.Controls.Add(this.label2);
            this.MainPanel.Controls.Add(this.txtOpened);
            this.MainPanel.Controls.Add(this.label1);
            this.MainPanel.Controls.Add(this.cbSelectReport);
            this.MainPanel.Controls.Add(this.lblTopTotal);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 45);
            this.MainPanel.Margin = new System.Windows.Forms.Padding(10);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Padding = new System.Windows.Forms.Padding(10);
            this.MainPanel.Size = new System.Drawing.Size(562, 225);
            this.MainPanel.TabIndex = 14;
            // 
            // lblTopTotal
            // 
            this.lblTopTotal.AutoSize = true;
            this.lblTopTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTopTotal.ForeColor = System.Drawing.Color.Black;
            this.lblTopTotal.Location = new System.Drawing.Point(12, 11);
            this.lblTopTotal.Name = "lblTopTotal";
            this.lblTopTotal.Size = new System.Drawing.Size(50, 21);
            this.lblTopTotal.TabIndex = 3;
            this.lblTopTotal.Text = "Show";
            // 
            // cbSelectReport
            // 
            this.cbSelectReport.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSelectReport.FormattingEnabled = true;
            this.cbSelectReport.Items.AddRange(new object[] {
            "X Report",
            "Z Report"});
            this.cbSelectReport.Location = new System.Drawing.Point(120, 11);
            this.cbSelectReport.Name = "cbSelectReport";
            this.cbSelectReport.Size = new System.Drawing.Size(140, 25);
            this.cbSelectReport.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(12, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "Opened On";
            // 
            // txtOpened
            // 
            this.txtOpened.Location = new System.Drawing.Point(120, 55);
            this.txtOpened.Name = "txtOpened";
            this.txtOpened.Size = new System.Drawing.Size(140, 23);
            this.txtOpened.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(268, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "By";
            // 
            // cbUsers
            // 
            this.cbUsers.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbUsers.FormattingEnabled = true;
            this.cbUsers.Items.AddRange(new object[] {
            "X Report",
            "Z Report"});
            this.cbUsers.Location = new System.Drawing.Point(302, 53);
            this.cbUsers.Name = "cbUsers";
            this.cbUsers.Size = new System.Drawing.Size(251, 25);
            this.cbUsers.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(5, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 21);
            this.label3.TabIndex = 9;
            this.label3.Text = "Transactions";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(120, 93);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(140, 23);
            this.textBox1.TabIndex = 10;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(120, 122);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(140, 23);
            this.textBox2.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(7, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 21);
            this.label5.TabIndex = 11;
            this.label5.Text = "Item(s) Sold";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(120, 151);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(140, 23);
            this.textBox3.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(7, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 21);
            this.label6.TabIndex = 13;
            this.label6.Text = "Total";
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnPrint.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnPrint.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnPrint.BorderRadius = 5;
            this.btnPrint.BorderSize = 0;
            this.btnPrint.FlatAppearance.BorderSize = 0;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Location = new System.Drawing.Point(120, 185);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(118, 28);
            this.btnPrint.TabIndex = 15;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextColor = System.Drawing.Color.White;
            this.btnPrint.UseVisualStyleBackColor = false;
            // 
            // frmXandZReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 270);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmXandZReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmXandZReport";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.MainPanel.ResumeLayout(false);
            this.MainPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private FontAwesome.Sharp.IconButton btnExit;
        private System.Windows.Forms.Panel MainPanel;
        private RJCodeAdvance.RJControls.RJButton btnPrint;
        private System.Windows.Forms.TextBox textBox3;
        public System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2;
        public System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbUsers;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOpened;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSelectReport;
        public System.Windows.Forms.Label lblTopTotal;
    }
}

namespace CapstoneProject_3.POS_System
{
    partial class frmXandZReports
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
            this.btnXReport = new RJCodeAdvance.RJControls.RJButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.btnExit = new FontAwesome.Sharp.IconButton();
            this.btnZReport = new RJCodeAdvance.RJControls.RJButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnXReport
            // 
            this.btnXReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnXReport.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnXReport.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnXReport.BorderRadius = 5;
            this.btnXReport.BorderSize = 0;
            this.btnXReport.FlatAppearance.BorderSize = 0;
            this.btnXReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXReport.ForeColor = System.Drawing.Color.White;
            this.btnXReport.Location = new System.Drawing.Point(13, 46);
            this.btnXReport.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnXReport.Name = "btnXReport";
            this.btnXReport.Size = new System.Drawing.Size(122, 76);
            this.btnXReport.TabIndex = 17;
            this.btnXReport.Text = "X Report";
            this.btnXReport.TextColor = System.Drawing.Color.White;
            this.btnXReport.UseVisualStyleBackColor = false;
            this.btnXReport.Click += new System.EventHandler(this.btnXReport_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btnExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(279, 38);
            this.panel1.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(13, 9);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(122, 21);
            this.label4.TabIndex = 15;
            this.label4.Text = "X And Z Report";
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
            this.btnExit.Location = new System.Drawing.Point(241, 0);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(38, 38);
            this.btnExit.TabIndex = 7;
            this.btnExit.Tag = "";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnZReport
            // 
            this.btnZReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnZReport.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnZReport.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnZReport.BorderRadius = 5;
            this.btnZReport.BorderSize = 0;
            this.btnZReport.FlatAppearance.BorderSize = 0;
            this.btnZReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnZReport.ForeColor = System.Drawing.Color.White;
            this.btnZReport.Location = new System.Drawing.Point(143, 46);
            this.btnZReport.Margin = new System.Windows.Forms.Padding(4);
            this.btnZReport.Name = "btnZReport";
            this.btnZReport.Size = new System.Drawing.Size(122, 76);
            this.btnZReport.TabIndex = 19;
            this.btnZReport.Text = "Z Report";
            this.btnZReport.TextColor = System.Drawing.Color.White;
            this.btnZReport.UseVisualStyleBackColor = false;
            this.btnZReport.Click += new System.EventHandler(this.btnZReport_Click);
            // 
            // frmXandZReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 136);
            this.Controls.Add(this.btnZReport);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnXReport);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmXandZReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmXandZReports";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private RJCodeAdvance.RJControls.RJButton btnXReport;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private FontAwesome.Sharp.IconButton btnExit;
        private RJCodeAdvance.RJControls.RJButton btnZReport;
    }
}
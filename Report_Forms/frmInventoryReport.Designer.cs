
namespace CapstoneProject_3.Report_Forms
{
    partial class frmInventoryReport
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
            this.panelTop = new System.Windows.Forms.Panel();
            this.btnExit = new FontAwesome.Sharp.IconButton();
            this.btnMaximize = new FontAwesome.Sharp.IconButton();
            this.btnMinimizeWindow = new FontAwesome.Sharp.IconButton();
            this.lblCurrentChildForm = new System.Windows.Forms.Label();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(52)))));
            this.panelTop.Controls.Add(this.btnExit);
            this.panelTop.Controls.Add(this.btnMaximize);
            this.panelTop.Controls.Add(this.btnMinimizeWindow);
            this.panelTop.Controls.Add(this.lblCurrentChildForm);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panelTop.Size = new System.Drawing.Size(997, 41);
            this.panelTop.TabIndex = 3;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(52)))));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(241)))), ((int)(((byte)(227)))));
            this.btnExit.IconChar = FontAwesome.Sharp.IconChar.WindowClose;
            this.btnExit.IconColor = System.Drawing.Color.White;
            this.btnExit.IconFont = FontAwesome.Sharp.IconFont.Regular;
            this.btnExit.IconSize = 20;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExit.Location = new System.Drawing.Point(950, 6);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(47, 29);
            this.btnExit.TabIndex = 9;
            this.btnExit.Tag = "";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = false;
            // 
            // btnMaximize
            // 
            this.btnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(52)))));
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximize.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaximize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.btnMaximize.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            this.btnMaximize.IconColor = System.Drawing.Color.White;
            this.btnMaximize.IconFont = FontAwesome.Sharp.IconFont.Regular;
            this.btnMaximize.IconSize = 20;
            this.btnMaximize.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMaximize.Location = new System.Drawing.Point(905, 6);
            this.btnMaximize.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(47, 29);
            this.btnMaximize.TabIndex = 8;
            this.btnMaximize.Tag = "";
            this.btnMaximize.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMaximize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMaximize.UseVisualStyleBackColor = false;
            // 
            // btnMinimizeWindow
            // 
            this.btnMinimizeWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizeWindow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(52)))));
            this.btnMinimizeWindow.FlatAppearance.BorderSize = 0;
            this.btnMinimizeWindow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizeWindow.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimizeWindow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.btnMinimizeWindow.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.btnMinimizeWindow.IconColor = System.Drawing.Color.White;
            this.btnMinimizeWindow.IconFont = FontAwesome.Sharp.IconFont.Regular;
            this.btnMinimizeWindow.IconSize = 20;
            this.btnMinimizeWindow.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMinimizeWindow.Location = new System.Drawing.Point(862, 6);
            this.btnMinimizeWindow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMinimizeWindow.Name = "btnMinimizeWindow";
            this.btnMinimizeWindow.Size = new System.Drawing.Size(47, 29);
            this.btnMinimizeWindow.TabIndex = 7;
            this.btnMinimizeWindow.Tag = "";
            this.btnMinimizeWindow.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMinimizeWindow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMinimizeWindow.UseVisualStyleBackColor = false;
            // 
            // lblCurrentChildForm
            // 
            this.lblCurrentChildForm.AutoSize = true;
            this.lblCurrentChildForm.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentChildForm.ForeColor = System.Drawing.Color.White;
            this.lblCurrentChildForm.Location = new System.Drawing.Point(3, 8);
            this.lblCurrentChildForm.Name = "lblCurrentChildForm";
            this.lblCurrentChildForm.Size = new System.Drawing.Size(131, 25);
            this.lblCurrentChildForm.TabIndex = 1;
            this.lblCurrentChildForm.Text = "Print Preview";
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 41);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(997, 453);
            this.reportViewer1.TabIndex = 4;
            // 
            // frmInventoryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 494);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panelTop);
            this.Name = "frmInventoryReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmInventoryReport_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private FontAwesome.Sharp.IconButton btnExit;
        private FontAwesome.Sharp.IconButton btnMaximize;
        private FontAwesome.Sharp.IconButton btnMinimizeWindow;
        private System.Windows.Forms.Label lblCurrentChildForm;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}
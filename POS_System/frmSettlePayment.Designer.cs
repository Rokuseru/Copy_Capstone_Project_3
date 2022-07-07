
namespace CapstoneProject_3.POS_System
{
    partial class frmSettlePayment
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
            this.txtChange = new System.Windows.Forms.TextBox();
            this.txtPayment = new System.Windows.Forms.TextBox();
            this.txtBill = new System.Windows.Forms.TextBox();
            this.btnSettle = new RJCodeAdvance.RJControls.RJButton();
            this.btn100 = new RJCodeAdvance.RJControls.RJButton();
            this.btn200 = new RJCodeAdvance.RJControls.RJButton();
            this.btn50 = new RJCodeAdvance.RJControls.RJButton();
            this.btn500 = new RJCodeAdvance.RJControls.RJButton();
            this.btn20 = new RJCodeAdvance.RJControls.RJButton();
            this.btn1000 = new RJCodeAdvance.RJControls.RJButton();
            this.btn5 = new RJCodeAdvance.RJControls.RJButton();
            this.btn10 = new RJCodeAdvance.RJControls.RJButton();
            this.btnBspace = new RJCodeAdvance.RJControls.RJButton();
            this.panel1.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(316, 39);
            this.panel1.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 21);
            this.label4.TabIndex = 15;
            this.label4.Text = "Settle Payment";
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
            this.btnExit.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(229)))), ((int)(((byte)(245)))));
            this.btnExit.IconFont = FontAwesome.Sharp.IconFont.Regular;
            this.btnExit.IconSize = 25;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExit.Location = new System.Drawing.Point(276, 0);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(40, 30);
            this.btnExit.TabIndex = 7;
            this.btnExit.Tag = "";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // txtChange
            // 
            this.txtChange.Enabled = false;
            this.txtChange.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChange.Location = new System.Drawing.Point(12, 113);
            this.txtChange.Multiline = true;
            this.txtChange.Name = "txtChange";
            this.txtChange.Size = new System.Drawing.Size(291, 28);
            this.txtChange.TabIndex = 20;
            this.txtChange.Text = "0";
            this.txtChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPayment
            // 
            this.txtPayment.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtPayment.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPayment.Location = new System.Drawing.Point(12, 79);
            this.txtPayment.Multiline = true;
            this.txtPayment.Name = "txtPayment";
            this.txtPayment.Size = new System.Drawing.Size(291, 28);
            this.txtPayment.TabIndex = 19;
            this.txtPayment.Text = "0";
            this.txtPayment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtPayment.TextChanged += new System.EventHandler(this.txtPayment_TextChanged);
            // 
            // txtBill
            // 
            this.txtBill.Enabled = false;
            this.txtBill.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBill.Location = new System.Drawing.Point(12, 45);
            this.txtBill.Multiline = true;
            this.txtBill.Name = "txtBill";
            this.txtBill.Size = new System.Drawing.Size(291, 28);
            this.txtBill.TabIndex = 18;
            this.txtBill.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSettle
            // 
            this.btnSettle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnSettle.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnSettle.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnSettle.BorderRadius = 5;
            this.btnSettle.BorderSize = 0;
            this.btnSettle.FlatAppearance.BorderSize = 0;
            this.btnSettle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSettle.ForeColor = System.Drawing.Color.White;
            this.btnSettle.Location = new System.Drawing.Point(12, 288);
            this.btnSettle.Name = "btnSettle";
            this.btnSettle.Size = new System.Drawing.Size(291, 32);
            this.btnSettle.TabIndex = 21;
            this.btnSettle.Text = "Pay";
            this.btnSettle.TextColor = System.Drawing.Color.White;
            this.btnSettle.UseVisualStyleBackColor = false;
            this.btnSettle.Click += new System.EventHandler(this.btnSettle_Click);
            // 
            // btn100
            // 
            this.btn100.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btn100.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btn100.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btn100.BorderRadius = 5;
            this.btn100.BorderSize = 0;
            this.btn100.FlatAppearance.BorderSize = 0;
            this.btn100.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn100.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn100.ForeColor = System.Drawing.Color.White;
            this.btn100.Location = new System.Drawing.Point(210, 192);
            this.btn100.Name = "btn100";
            this.btn100.Size = new System.Drawing.Size(93, 42);
            this.btn100.TabIndex = 22;
            this.btn100.Text = "100";
            this.btn100.TextColor = System.Drawing.Color.White;
            this.btn100.UseVisualStyleBackColor = false;
            this.btn100.Click += new System.EventHandler(this.btn100_Click);
            // 
            // btn200
            // 
            this.btn200.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btn200.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btn200.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btn200.BorderRadius = 5;
            this.btn200.BorderSize = 0;
            this.btn200.FlatAppearance.BorderSize = 0;
            this.btn200.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn200.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn200.ForeColor = System.Drawing.Color.White;
            this.btn200.Location = new System.Drawing.Point(12, 240);
            this.btn200.Name = "btn200";
            this.btn200.Size = new System.Drawing.Size(93, 42);
            this.btn200.TabIndex = 23;
            this.btn200.Text = "200";
            this.btn200.TextColor = System.Drawing.Color.White;
            this.btn200.UseVisualStyleBackColor = false;
            this.btn200.Click += new System.EventHandler(this.btn200_Click);
            // 
            // btn50
            // 
            this.btn50.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btn50.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btn50.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btn50.BorderRadius = 5;
            this.btn50.BorderSize = 0;
            this.btn50.FlatAppearance.BorderSize = 0;
            this.btn50.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn50.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn50.ForeColor = System.Drawing.Color.White;
            this.btn50.Location = new System.Drawing.Point(111, 192);
            this.btn50.Name = "btn50";
            this.btn50.Size = new System.Drawing.Size(93, 42);
            this.btn50.TabIndex = 24;
            this.btn50.Text = "50";
            this.btn50.TextColor = System.Drawing.Color.White;
            this.btn50.UseVisualStyleBackColor = false;
            this.btn50.Click += new System.EventHandler(this.btn50_Click);
            // 
            // btn500
            // 
            this.btn500.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btn500.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btn500.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btn500.BorderRadius = 5;
            this.btn500.BorderSize = 0;
            this.btn500.FlatAppearance.BorderSize = 0;
            this.btn500.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn500.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn500.ForeColor = System.Drawing.Color.White;
            this.btn500.Location = new System.Drawing.Point(111, 240);
            this.btn500.Name = "btn500";
            this.btn500.Size = new System.Drawing.Size(93, 42);
            this.btn500.TabIndex = 27;
            this.btn500.Text = "500";
            this.btn500.TextColor = System.Drawing.Color.White;
            this.btn500.UseVisualStyleBackColor = false;
            this.btn500.Click += new System.EventHandler(this.btn500_Click);
            // 
            // btn20
            // 
            this.btn20.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btn20.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btn20.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btn20.BorderRadius = 5;
            this.btn20.BorderSize = 0;
            this.btn20.FlatAppearance.BorderSize = 0;
            this.btn20.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn20.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn20.ForeColor = System.Drawing.Color.White;
            this.btn20.Location = new System.Drawing.Point(12, 192);
            this.btn20.Name = "btn20";
            this.btn20.Size = new System.Drawing.Size(93, 42);
            this.btn20.TabIndex = 26;
            this.btn20.Text = "20";
            this.btn20.TextColor = System.Drawing.Color.White;
            this.btn20.UseVisualStyleBackColor = false;
            this.btn20.Click += new System.EventHandler(this.btn20_Click);
            // 
            // btn1000
            // 
            this.btn1000.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btn1000.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btn1000.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btn1000.BorderRadius = 5;
            this.btn1000.BorderSize = 0;
            this.btn1000.FlatAppearance.BorderSize = 0;
            this.btn1000.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn1000.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn1000.ForeColor = System.Drawing.Color.White;
            this.btn1000.Location = new System.Drawing.Point(210, 240);
            this.btn1000.Name = "btn1000";
            this.btn1000.Size = new System.Drawing.Size(93, 42);
            this.btn1000.TabIndex = 25;
            this.btn1000.Text = "1000";
            this.btn1000.TextColor = System.Drawing.Color.White;
            this.btn1000.UseVisualStyleBackColor = false;
            this.btn1000.Click += new System.EventHandler(this.btn1000_Click);
            // 
            // btn5
            // 
            this.btn5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btn5.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btn5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btn5.BorderRadius = 5;
            this.btn5.BorderSize = 0;
            this.btn5.FlatAppearance.BorderSize = 0;
            this.btn5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn5.ForeColor = System.Drawing.Color.White;
            this.btn5.Location = new System.Drawing.Point(12, 147);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(93, 42);
            this.btn5.TabIndex = 30;
            this.btn5.Text = "5";
            this.btn5.TextColor = System.Drawing.Color.White;
            this.btn5.UseVisualStyleBackColor = false;
            this.btn5.Click += new System.EventHandler(this.btn5_Click);
            // 
            // btn10
            // 
            this.btn10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btn10.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btn10.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btn10.BorderRadius = 5;
            this.btn10.BorderSize = 0;
            this.btn10.FlatAppearance.BorderSize = 0;
            this.btn10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn10.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn10.ForeColor = System.Drawing.Color.White;
            this.btn10.Location = new System.Drawing.Point(111, 147);
            this.btn10.Name = "btn10";
            this.btn10.Size = new System.Drawing.Size(93, 42);
            this.btn10.TabIndex = 29;
            this.btn10.Text = "10";
            this.btn10.TextColor = System.Drawing.Color.White;
            this.btn10.UseVisualStyleBackColor = false;
            this.btn10.Click += new System.EventHandler(this.btn10_Click);
            // 
            // btnBspace
            // 
            this.btnBspace.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnBspace.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnBspace.BackgroundImage = global::CapstoneProject_3.Properties.Resources.icons8_left_arrow_50;
            this.btnBspace.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBspace.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnBspace.BorderRadius = 5;
            this.btnBspace.BorderSize = 0;
            this.btnBspace.FlatAppearance.BorderSize = 0;
            this.btnBspace.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBspace.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBspace.ForeColor = System.Drawing.Color.White;
            this.btnBspace.Location = new System.Drawing.Point(210, 147);
            this.btnBspace.Name = "btnBspace";
            this.btnBspace.Size = new System.Drawing.Size(93, 42);
            this.btnBspace.TabIndex = 28;
            this.btnBspace.TextColor = System.Drawing.Color.White;
            this.btnBspace.UseVisualStyleBackColor = false;
            this.btnBspace.Click += new System.EventHandler(this.btnBspace_Click);
            // 
            // frmSettlePayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(316, 333);
            this.ControlBox = false;
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn10);
            this.Controls.Add(this.btnBspace);
            this.Controls.Add(this.btn500);
            this.Controls.Add(this.btn20);
            this.Controls.Add(this.btn1000);
            this.Controls.Add(this.btn50);
            this.Controls.Add(this.btn200);
            this.Controls.Add(this.btn100);
            this.Controls.Add(this.btnSettle);
            this.Controls.Add(this.txtChange);
            this.Controls.Add(this.txtPayment);
            this.Controls.Add(this.txtBill);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmSettlePayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private FontAwesome.Sharp.IconButton btnExit;
        public System.Windows.Forms.TextBox txtChange;
        public System.Windows.Forms.TextBox txtPayment;
        public System.Windows.Forms.TextBox txtBill;
        private RJCodeAdvance.RJControls.RJButton btnSettle;
        private RJCodeAdvance.RJControls.RJButton btn100;
        private RJCodeAdvance.RJControls.RJButton btn200;
        private RJCodeAdvance.RJControls.RJButton btn50;
        private RJCodeAdvance.RJControls.RJButton btn500;
        private RJCodeAdvance.RJControls.RJButton btn20;
        private RJCodeAdvance.RJControls.RJButton btn1000;
        private RJCodeAdvance.RJControls.RJButton btn5;
        private RJCodeAdvance.RJControls.RJButton btn10;
        private RJCodeAdvance.RJControls.RJButton btnBspace;
    }
}
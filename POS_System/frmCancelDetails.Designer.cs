
namespace CapstoneProject_3.POS_System
{
    partial class frmCancelDetails
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
            this.lblCurrentChildForm = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTransNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPcode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.txtQtyBot = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCashier = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtReason = new System.Windows.Forms.TextBox();
            this.cbAction = new System.Windows.Forms.ComboBox();
            this.btnCancelSales = new RJCodeAdvance.RJControls.RJButton();
            this.btnExit = new FontAwesome.Sharp.IconButton();
            this.btnMinimizeWindow = new FontAwesome.Sharp.IconButton();
            this.label13 = new System.Windows.Forms.Label();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.panelTop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(52)))));
            this.panelTop.Controls.Add(this.btnExit);
            this.panelTop.Controls.Add(this.btnMinimizeWindow);
            this.panelTop.Controls.Add(this.lblCurrentChildForm);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panelTop.Name = "panelTop";
            this.panelTop.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.panelTop.Size = new System.Drawing.Size(777, 41);
            this.panelTop.TabIndex = 3;
            // 
            // lblCurrentChildForm
            // 
            this.lblCurrentChildForm.AutoSize = true;
            this.lblCurrentChildForm.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentChildForm.ForeColor = System.Drawing.Color.White;
            this.lblCurrentChildForm.Location = new System.Drawing.Point(3, 9);
            this.lblCurrentChildForm.Name = "lblCurrentChildForm";
            this.lblCurrentChildForm.Size = new System.Drawing.Size(134, 25);
            this.lblCurrentChildForm.TabIndex = 1;
            this.lblCurrentChildForm.Text = "Cancel Details";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 17);
            this.label5.TabIndex = 21;
            this.label5.Text = "Transaction No.";
            // 
            // txtTransNo
            // 
            this.txtTransNo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTransNo.Enabled = false;
            this.txtTransNo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransNo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtTransNo.Location = new System.Drawing.Point(126, 38);
            this.txtTransNo.Name = "txtTransNo";
            this.txtTransNo.Size = new System.Drawing.Size(318, 25);
            this.txtTransNo.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 17);
            this.label3.TabIndex = 19;
            this.label3.Text = "Product Code";
            // 
            // txtPcode
            // 
            this.txtPcode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPcode.Enabled = false;
            this.txtPcode.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPcode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPcode.Location = new System.Drawing.Point(126, 74);
            this.txtPcode.Name = "txtPcode";
            this.txtPcode.Size = new System.Drawing.Size(318, 25);
            this.txtPcode.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDescription.Enabled = false;
            this.txtDescription.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtDescription.Location = new System.Drawing.Point(126, 110);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(318, 93);
            this.txtDescription.TabIndex = 24;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(462, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 17);
            this.label2.TabIndex = 23;
            this.label2.Text = "Price";
            // 
            // txtPrice
            // 
            this.txtPrice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPrice.Enabled = false;
            this.txtPrice.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrice.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPrice.Location = new System.Drawing.Point(540, 38);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(202, 25);
            this.txtPrice.TabIndex = 22;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.txtDiscount);
            this.panel1.Controls.Add(this.txtTotal);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtQty);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtPrice);
            this.panel1.Controls.Add(this.txtPcode);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtTransNo);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtDescription);
            this.panel1.Location = new System.Drawing.Point(12, 48);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(754, 218);
            this.panel1.TabIndex = 30;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(17, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 21);
            this.label7.TabIndex = 26;
            this.label7.Text = "ITEM";
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTotal.Enabled = false;
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtTotal.Location = new System.Drawing.Point(540, 145);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(202, 25);
            this.txtTotal.TabIndex = 27;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(462, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 17);
            this.label8.TabIndex = 30;
            this.label8.Text = "Quantity";
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(462, 148);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 17);
            this.label9.TabIndex = 28;
            this.label9.Text = "Total";
            // 
            // txtQty
            // 
            this.txtQty.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtQty.Enabled = false;
            this.txtQty.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQty.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtQty.Location = new System.Drawing.Point(540, 75);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(202, 25);
            this.txtQty.TabIndex = 29;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.btnCancelSales);
            this.panel2.Controls.Add(this.cbAction);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.txtReason);
            this.panel2.Controls.Add(this.txtQtyBot);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.txtCashier);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Location = new System.Drawing.Point(12, 272);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(754, 214);
            this.panel2.TabIndex = 31;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(10, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(129, 21);
            this.label10.TabIndex = 34;
            this.label10.Text = "CANCEL ITEM(S)";
            // 
            // txtQtyBot
            // 
            this.txtQtyBot.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtQtyBot.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQtyBot.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtQtyBot.Location = new System.Drawing.Point(145, 87);
            this.txtQtyBot.Name = "txtQtyBot";
            this.txtQtyBot.Size = new System.Drawing.Size(241, 25);
            this.txtQtyBot.TabIndex = 37;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(19, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 17);
            this.label4.TabIndex = 40;
            this.label4.Text = "Add to Inventory?";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(19, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 17);
            this.label6.TabIndex = 38;
            this.label6.Text = "Quantity";
            // 
            // txtCashier
            // 
            this.txtCashier.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCashier.Enabled = false;
            this.txtCashier.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCashier.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtCashier.Location = new System.Drawing.Point(145, 54);
            this.txtCashier.Name = "txtCashier";
            this.txtCashier.Size = new System.Drawing.Size(241, 25);
            this.txtCashier.TabIndex = 35;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(19, 54);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 17);
            this.label11.TabIndex = 36;
            this.label11.Text = "Cashier";
            // 
            // label12
            // 
            this.label12.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(393, 57);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 17);
            this.label12.TabIndex = 44;
            this.label12.Text = "Reason(s)";
            // 
            // txtReason
            // 
            this.txtReason.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtReason.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReason.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtReason.Location = new System.Drawing.Point(465, 54);
            this.txtReason.Multiline = true;
            this.txtReason.Name = "txtReason";
            this.txtReason.Size = new System.Drawing.Size(277, 93);
            this.txtReason.TabIndex = 43;
            // 
            // cbAction
            // 
            this.cbAction.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbAction.FormattingEnabled = true;
            this.cbAction.Items.AddRange(new object[] {
            "Yes",
            "No"});
            this.cbAction.Location = new System.Drawing.Point(145, 122);
            this.cbAction.Name = "cbAction";
            this.cbAction.Size = new System.Drawing.Size(73, 25);
            this.cbAction.TabIndex = 45;
            // 
            // btnCancelSales
            // 
            this.btnCancelSales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelSales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnCancelSales.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnCancelSales.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnCancelSales.BorderRadius = 5;
            this.btnCancelSales.BorderSize = 0;
            this.btnCancelSales.FlatAppearance.BorderSize = 0;
            this.btnCancelSales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelSales.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelSales.ForeColor = System.Drawing.Color.White;
            this.btnCancelSales.Location = new System.Drawing.Point(608, 162);
            this.btnCancelSales.Name = "btnCancelSales";
            this.btnCancelSales.Size = new System.Drawing.Size(134, 32);
            this.btnCancelSales.TabIndex = 46;
            this.btnCancelSales.Text = "Cancel Order";
            this.btnCancelSales.TextColor = System.Drawing.Color.White;
            this.btnCancelSales.UseVisualStyleBackColor = false;
            this.btnCancelSales.Click += new System.EventHandler(this.btnCancelSales_Click);
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
            this.btnExit.Location = new System.Drawing.Point(730, 6);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(47, 29);
            this.btnExit.TabIndex = 9;
            this.btnExit.Tag = "";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
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
            this.btnMinimizeWindow.Location = new System.Drawing.Point(677, 4);
            this.btnMinimizeWindow.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnMinimizeWindow.Name = "btnMinimizeWindow";
            this.btnMinimizeWindow.Size = new System.Drawing.Size(47, 29);
            this.btnMinimizeWindow.TabIndex = 7;
            this.btnMinimizeWindow.Tag = "";
            this.btnMinimizeWindow.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMinimizeWindow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMinimizeWindow.UseVisualStyleBackColor = false;
            this.btnMinimizeWindow.Click += new System.EventHandler(this.btnMinimizeWindow_Click);
            // 
            // label13
            // 
            this.label13.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(462, 115);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(61, 17);
            this.label13.TabIndex = 32;
            this.label13.Text = "Discount";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDiscount.Enabled = false;
            this.txtDiscount.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscount.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtDiscount.Location = new System.Drawing.Point(540, 112);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(202, 25);
            this.txtDiscount.TabIndex = 31;
            // 
            // frmCancelDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(777, 500);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmCancelDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private FontAwesome.Sharp.IconButton btnExit;
        private FontAwesome.Sharp.IconButton btnMinimizeWindow;
        private System.Windows.Forms.Label lblCurrentChildForm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.ComboBox cbAction;
        public System.Windows.Forms.TextBox txtReason;
        public System.Windows.Forms.TextBox txtQtyBot;
        public System.Windows.Forms.TextBox txtCashier;
        public RJCodeAdvance.RJControls.RJButton btnCancelSales;
        public System.Windows.Forms.TextBox txtTransNo;
        public System.Windows.Forms.TextBox txtPcode;
        public System.Windows.Forms.TextBox txtDescription;
        public System.Windows.Forms.TextBox txtPrice;
        public System.Windows.Forms.TextBox txtTotal;
        public System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.TextBox txtDiscount;
    }
}
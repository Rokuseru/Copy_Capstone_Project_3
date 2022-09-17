
namespace CapstoneProject_3
{
    partial class frmPurchaseOrder
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.metroTabControl = new MetroFramework.Controls.MetroTabControl();
            this.tabPageCreate = new MetroFramework.Controls.MetroTabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.linkAddProducts = new System.Windows.Forms.LinkLabel();
            this.txtDiscPhp = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lbluserID = new System.Windows.Forms.Label();
            this.txtBeforeDisc = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDiscPercent = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPaymentDue = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRefNo = new FontAwesome.Sharp.IconButton();
            this.txtReferenceCode = new System.Windows.Forms.TextBox();
            this.cbOrderBy = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.dt = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpOrderDate = new System.Windows.Forms.DateTimePicker();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtContactPerson = new System.Windows.Forms.TextBox();
            this.cbVendor = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancel = new RJCodeAdvance.RJControls.RJButton();
            this.btnCreatePo = new RJCodeAdvance.RJControls.RJButton();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.poID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPagePending = new MetroFramework.Controls.MetroTabPage();
            this.dataGridViewPending = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label14 = new System.Windows.Forms.Label();
            this.txtSenderEmail = new System.Windows.Forms.TextBox();
            this.txtSenderPassword = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.metroTabControl.SuspendLayout();
            this.tabPageCreate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.tabPagePending.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPending)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.metroTabControl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(988, 554);
            this.panel1.TabIndex = 0;
            // 
            // metroTabControl
            // 
            this.metroTabControl.Controls.Add(this.tabPageCreate);
            this.metroTabControl.Controls.Add(this.tabPagePending);
            this.metroTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.metroTabControl.FontWeight = MetroFramework.MetroTabControlWeight.Regular;
            this.metroTabControl.Location = new System.Drawing.Point(0, 0);
            this.metroTabControl.Name = "metroTabControl";
            this.metroTabControl.SelectedIndex = 0;
            this.metroTabControl.Size = new System.Drawing.Size(988, 554);
            this.metroTabControl.TabIndex = 0;
            this.metroTabControl.UseSelectable = true;
            this.metroTabControl.SelectedIndexChanged += new System.EventHandler(this.metroTabControl_SelectedIndexChanged);
            // 
            // tabPageCreate
            // 
            this.tabPageCreate.BackColor = System.Drawing.Color.White;
            this.tabPageCreate.Controls.Add(this.txtSenderPassword);
            this.tabPageCreate.Controls.Add(this.txtSenderEmail);
            this.tabPageCreate.Controls.Add(this.label14);
            this.tabPageCreate.Controls.Add(this.label13);
            this.tabPageCreate.Controls.Add(this.linkAddProducts);
            this.tabPageCreate.Controls.Add(this.txtDiscPhp);
            this.tabPageCreate.Controls.Add(this.label12);
            this.tabPageCreate.Controls.Add(this.lbluserID);
            this.tabPageCreate.Controls.Add(this.txtBeforeDisc);
            this.tabPageCreate.Controls.Add(this.label11);
            this.tabPageCreate.Controls.Add(this.txtDiscPercent);
            this.tabPageCreate.Controls.Add(this.label1);
            this.tabPageCreate.Controls.Add(this.txtPaymentDue);
            this.tabPageCreate.Controls.Add(this.label9);
            this.tabPageCreate.Controls.Add(this.label2);
            this.tabPageCreate.Controls.Add(this.btnRefNo);
            this.tabPageCreate.Controls.Add(this.txtReferenceCode);
            this.tabPageCreate.Controls.Add(this.cbOrderBy);
            this.tabPageCreate.Controls.Add(this.label10);
            this.tabPageCreate.Controls.Add(this.dtpDeliveryDate);
            this.tabPageCreate.Controls.Add(this.dt);
            this.tabPageCreate.Controls.Add(this.label8);
            this.tabPageCreate.Controls.Add(this.dtpOrderDate);
            this.tabPageCreate.Controls.Add(this.txtEmail);
            this.tabPageCreate.Controls.Add(this.txtContactPerson);
            this.tabPageCreate.Controls.Add(this.cbVendor);
            this.tabPageCreate.Controls.Add(this.label7);
            this.tabPageCreate.Controls.Add(this.label6);
            this.tabPageCreate.Controls.Add(this.label5);
            this.tabPageCreate.Controls.Add(this.btnCancel);
            this.tabPageCreate.Controls.Add(this.btnCreatePo);
            this.tabPageCreate.Controls.Add(this.txtRemarks);
            this.tabPageCreate.Controls.Add(this.label4);
            this.tabPageCreate.Controls.Add(this.label3);
            this.tabPageCreate.Controls.Add(this.dataGridView);
            this.tabPageCreate.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPageCreate.HorizontalScrollbarBarColor = true;
            this.tabPageCreate.HorizontalScrollbarHighlightOnWheel = false;
            this.tabPageCreate.HorizontalScrollbarSize = 9;
            this.tabPageCreate.Location = new System.Drawing.Point(4, 38);
            this.tabPageCreate.Name = "tabPageCreate";
            this.tabPageCreate.Size = new System.Drawing.Size(980, 512);
            this.tabPageCreate.TabIndex = 0;
            this.tabPageCreate.Text = "Create Purchase Order";
            this.tabPageCreate.VerticalScrollbarBarColor = true;
            this.tabPageCreate.VerticalScrollbarHighlightOnWheel = false;
            this.tabPageCreate.VerticalScrollbarSize = 9;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(844, 406);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(30, 15);
            this.label13.TabIndex = 94;
            this.label13.Text = "PHP";
            // 
            // linkAddProducts
            // 
            this.linkAddProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkAddProducts.AutoSize = true;
            this.linkAddProducts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkAddProducts.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.linkAddProducts.Location = new System.Drawing.Point(864, 105);
            this.linkAddProducts.Name = "linkAddProducts";
            this.linkAddProducts.Size = new System.Drawing.Size(102, 17);
            this.linkAddProducts.TabIndex = 93;
            this.linkAddProducts.TabStop = true;
            this.linkAddProducts.Text = "Select Products";
            this.linkAddProducts.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAddProducts_LinkClicked);
            // 
            // txtDiscPhp
            // 
            this.txtDiscPhp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiscPhp.Enabled = false;
            this.txtDiscPhp.Location = new System.Drawing.Point(874, 400);
            this.txtDiscPhp.Name = "txtDiscPhp";
            this.txtDiscPhp.Size = new System.Drawing.Size(96, 25);
            this.txtDiscPhp.TabIndex = 92;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(731, 372);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(22, 20);
            this.label12.TabIndex = 91;
            this.label12.Text = "%";
            // 
            // lbluserID
            // 
            this.lbluserID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbluserID.AutoSize = true;
            this.lbluserID.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbluserID.Location = new System.Drawing.Point(844, 375);
            this.lbluserID.Name = "lbluserID";
            this.lbluserID.Size = new System.Drawing.Size(62, 17);
            this.lbluserID.TabIndex = 90;
            this.lbluserID.Text = "Order By";
            this.lbluserID.Visible = false;
            // 
            // txtBeforeDisc
            // 
            this.txtBeforeDisc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBeforeDisc.Enabled = false;
            this.txtBeforeDisc.Location = new System.Drawing.Point(732, 341);
            this.txtBeforeDisc.Name = "txtBeforeDisc";
            this.txtBeforeDisc.Size = new System.Drawing.Size(240, 25);
            this.txtBeforeDisc.TabIndex = 89;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(591, 343);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(132, 17);
            this.label11.TabIndex = 88;
            this.label11.Text = "Due Before Discount";
            // 
            // txtDiscPercent
            // 
            this.txtDiscPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiscPercent.Location = new System.Drawing.Point(756, 370);
            this.txtDiscPercent.Name = "txtDiscPercent";
            this.txtDiscPercent.Size = new System.Drawing.Size(84, 25);
            this.txtDiscPercent.TabIndex = 87;
            this.txtDiscPercent.TextChanged += new System.EventHandler(this.txtDiscPercent_TextChanged_1);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(591, 371);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 86;
            this.label1.Text = "Discount";
            // 
            // txtPaymentDue
            // 
            this.txtPaymentDue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPaymentDue.Enabled = false;
            this.txtPaymentDue.Location = new System.Drawing.Point(732, 401);
            this.txtPaymentDue.Name = "txtPaymentDue";
            this.txtPaymentDue.Size = new System.Drawing.Size(108, 25);
            this.txtPaymentDue.TabIndex = 85;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(591, 400);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 17);
            this.label9.TabIndex = 84;
            this.label9.Text = "Payment Due";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(648, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 17);
            this.label2.TabIndex = 83;
            this.label2.Text = "Reference Code";
            // 
            // btnRefNo
            // 
            this.btnRefNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefNo.FlatAppearance.BorderSize = 0;
            this.btnRefNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefNo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(28)))), ((int)(((byte)(31)))));
            this.btnRefNo.IconChar = FontAwesome.Sharp.IconChar.Random;
            this.btnRefNo.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(28)))), ((int)(((byte)(31)))));
            this.btnRefNo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRefNo.IconSize = 29;
            this.btnRefNo.Location = new System.Drawing.Point(616, 8);
            this.btnRefNo.Name = "btnRefNo";
            this.btnRefNo.Size = new System.Drawing.Size(26, 26);
            this.btnRefNo.TabIndex = 82;
            this.btnRefNo.UseVisualStyleBackColor = true;
            this.btnRefNo.Click += new System.EventHandler(this.btnRefNo_Click);
            // 
            // txtReferenceCode
            // 
            this.txtReferenceCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReferenceCode.Location = new System.Drawing.Point(756, 8);
            this.txtReferenceCode.Name = "txtReferenceCode";
            this.txtReferenceCode.Size = new System.Drawing.Size(210, 25);
            this.txtReferenceCode.TabIndex = 81;
            // 
            // cbOrderBy
            // 
            this.cbOrderBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbOrderBy.FormattingEnabled = true;
            this.cbOrderBy.Location = new System.Drawing.Point(80, 343);
            this.cbOrderBy.Name = "cbOrderBy";
            this.cbOrderBy.Size = new System.Drawing.Size(210, 25);
            this.cbOrderBy.TabIndex = 80;
            this.cbOrderBy.SelectedIndexChanged += new System.EventHandler(this.cbOrderBy_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 345);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 17);
            this.label10.TabIndex = 79;
            this.label10.Text = "Order By";
            // 
            // dtpDeliveryDate
            // 
            this.dtpDeliveryDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDeliveryDate.Location = new System.Drawing.Point(756, 67);
            this.dtpDeliveryDate.Name = "dtpDeliveryDate";
            this.dtpDeliveryDate.Size = new System.Drawing.Size(210, 25);
            this.dtpDeliveryDate.TabIndex = 78;
            // 
            // dt
            // 
            this.dt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dt.AutoSize = true;
            this.dt.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt.Location = new System.Drawing.Point(648, 71);
            this.dt.Name = "dt";
            this.dt.Size = new System.Drawing.Size(89, 17);
            this.dt.TabIndex = 77;
            this.dt.Text = "Delivery Date";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(648, 41);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 17);
            this.label8.TabIndex = 76;
            this.label8.Text = "Order Date";
            // 
            // dtpOrderDate
            // 
            this.dtpOrderDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpOrderDate.Location = new System.Drawing.Point(756, 37);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.Size = new System.Drawing.Size(210, 25);
            this.dtpOrderDate.TabIndex = 75;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(118, 64);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(219, 25);
            this.txtEmail.TabIndex = 74;
            // 
            // txtContactPerson
            // 
            this.txtContactPerson.Location = new System.Drawing.Point(118, 35);
            this.txtContactPerson.Name = "txtContactPerson";
            this.txtContactPerson.Size = new System.Drawing.Size(219, 25);
            this.txtContactPerson.TabIndex = 73;
            // 
            // cbVendor
            // 
            this.cbVendor.FormattingEnabled = true;
            this.cbVendor.Location = new System.Drawing.Point(118, 6);
            this.cbVendor.Name = "cbVendor";
            this.cbVendor.Size = new System.Drawing.Size(219, 25);
            this.cbVendor.TabIndex = 72;
            this.cbVendor.SelectedIndexChanged += new System.EventHandler(this.cbVendor_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 17);
            this.label7.TabIndex = 71;
            this.label7.Text = "Email";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 17);
            this.label6.TabIndex = 70;
            this.label6.Text = "Contact Person";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 17);
            this.label5.TabIndex = 69;
            this.label5.Text = "Vendor";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCancel.BackgroundColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnCancel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnCancel.BorderRadius = 5;
            this.btnCancel.BorderSize = 0;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(180, 479);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 28);
            this.btnCancel.TabIndex = 68;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextColor = System.Drawing.Color.White;
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnCreatePo
            // 
            this.btnCreatePo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCreatePo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnCreatePo.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnCreatePo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnCreatePo.BorderRadius = 5;
            this.btnCreatePo.BorderSize = 0;
            this.btnCreatePo.FlatAppearance.BorderSize = 0;
            this.btnCreatePo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreatePo.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreatePo.ForeColor = System.Drawing.Color.White;
            this.btnCreatePo.Location = new System.Drawing.Point(10, 479);
            this.btnCreatePo.Name = "btnCreatePo";
            this.btnCreatePo.Size = new System.Drawing.Size(164, 28);
            this.btnCreatePo.TabIndex = 67;
            this.btnCreatePo.Text = "Create Purchase Order";
            this.btnCreatePo.TextColor = System.Drawing.Color.White;
            this.btnCreatePo.UseVisualStyleBackColor = false;
            this.btnCreatePo.Click += new System.EventHandler(this.btnCreatePo_Click);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtRemarks.Location = new System.Drawing.Point(80, 405);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(347, 68);
            this.txtRemarks.TabIndex = 66;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 410);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 24);
            this.label4.TabIndex = 65;
            this.label4.Text = "Remarks";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 20);
            this.label3.TabIndex = 64;
            this.label3.Text = "Items";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle25.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(239)))), ((int)(((byte)(249)))));
            this.dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle25;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle26.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(57)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle26.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(57)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle26;
            this.dataGridView.ColumnHeadersHeight = 40;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.poID,
            this.pid,
            this.refcode,
            this.Column2,
            this.Column4,
            this.Column5,
            this.total});
            this.dataGridView.EnableHeadersVisualStyles = false;
            this.dataGridView.GridColor = System.Drawing.Color.Black;
            this.dataGridView.Location = new System.Drawing.Point(12, 125);
            this.dataGridView.Name = "dataGridView";
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle27.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(151)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle27.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(151)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle27;
            this.dataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle28;
            this.dataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(960, 210);
            this.dataGridView.TabIndex = 63;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.HeaderText = "#";
            this.Column3.Name = "Column3";
            this.Column3.Width = 39;
            // 
            // poID
            // 
            this.poID.HeaderText = "poID";
            this.poID.Name = "poID";
            this.poID.Visible = false;
            // 
            // pid
            // 
            this.pid.HeaderText = "productID";
            this.pid.Name = "pid";
            this.pid.Visible = false;
            // 
            // refcode
            // 
            this.refcode.HeaderText = "referenceCode";
            this.refcode.Name = "refcode";
            this.refcode.Visible = false;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column2.HeaderText = "Description";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column4.HeaderText = "Price";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 60;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column5.HeaderText = "QTY (Carton/Pack)";
            this.Column5.Name = "Column5";
            this.Column5.Width = 129;
            // 
            // total
            // 
            this.total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.total.HeaderText = "Total";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.Width = 60;
            // 
            // tabPagePending
            // 
            this.tabPagePending.BackColor = System.Drawing.Color.White;
            this.tabPagePending.Controls.Add(this.dataGridViewPending);
            this.tabPagePending.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPagePending.HorizontalScrollbarBarColor = true;
            this.tabPagePending.HorizontalScrollbarHighlightOnWheel = false;
            this.tabPagePending.HorizontalScrollbarSize = 10;
            this.tabPagePending.Location = new System.Drawing.Point(4, 38);
            this.tabPagePending.Name = "tabPagePending";
            this.tabPagePending.Size = new System.Drawing.Size(980, 475);
            this.tabPagePending.TabIndex = 1;
            this.tabPagePending.Text = "Pending Orders";
            this.tabPagePending.VerticalScrollbarBarColor = true;
            this.tabPagePending.VerticalScrollbarHighlightOnWheel = false;
            this.tabPagePending.VerticalScrollbarSize = 10;
            // 
            // dataGridViewPending
            // 
            this.dataGridViewPending.AllowUserToAddRows = false;
            this.dataGridViewPending.AllowUserToDeleteRows = false;
            this.dataGridViewPending.AllowUserToResizeColumns = false;
            this.dataGridViewPending.AllowUserToResizeRows = false;
            dataGridViewCellStyle29.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(239)))), ((int)(((byte)(249)))));
            this.dataGridViewPending.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle29;
            this.dataGridViewPending.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewPending.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewPending.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle30.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(57)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle30.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle30.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle30.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(57)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle30.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPending.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle30;
            this.dataGridViewPending.ColumnHeadersHeight = 35;
            this.dataGridViewPending.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewPending.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn7,
            this.Column6,
            this.Column1,
            this.dataGridViewTextBoxColumn8});
            this.dataGridViewPending.EnableHeadersVisualStyles = false;
            this.dataGridViewPending.GridColor = System.Drawing.Color.Black;
            this.dataGridViewPending.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewPending.Name = "dataGridViewPending";
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle31.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(151)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle31.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle31.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle31.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(151)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle31.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle31.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewPending.RowHeadersDefaultCellStyle = dataGridViewCellStyle31;
            this.dataGridViewPending.RowHeadersVisible = false;
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewPending.RowsDefaultCellStyle = dataGridViewCellStyle32;
            this.dataGridViewPending.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewPending.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPending.Size = new System.Drawing.Size(974, 464);
            this.dataGridViewPending.TabIndex = 64;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.HeaderText = "#";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 39;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.HeaderText = "Reference Code";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn7.HeaderText = "Total Item(s)";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.Width = 106;
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column6.HeaderText = "Ordered On";
            this.Column6.Name = "Column6";
            this.Column6.Width = 103;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "Delivery Date";
            this.Column1.Name = "Column1";
            this.Column1.Width = 112;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn8.HeaderText = "Pending Payment";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 139;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(13, 375);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 17);
            this.label14.TabIndex = 95;
            this.label14.Text = "Email";
            // 
            // txtSenderEmail
            // 
            this.txtSenderEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSenderEmail.Location = new System.Drawing.Point(80, 374);
            this.txtSenderEmail.Name = "txtSenderEmail";
            this.txtSenderEmail.Size = new System.Drawing.Size(186, 25);
            this.txtSenderEmail.TabIndex = 96;
            // 
            // txtSenderPassword
            // 
            this.txtSenderPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSenderPassword.AutoSize = true;
            this.txtSenderPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSenderPassword.Location = new System.Drawing.Point(272, 378);
            this.txtSenderPassword.Name = "txtSenderPassword";
            this.txtSenderPassword.Size = new System.Drawing.Size(66, 17);
            this.txtSenderPassword.TabIndex = 98;
            this.txtSenderPassword.Text = "Password";
            // 
            // frmPurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(988, 554);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmPurchaseOrder";
            this.Tag = "Purchase Order/PO";
            this.Text = "Purchase Order/PO";
            this.Load += new System.EventHandler(this.frmPurchaseOrder_Load);
            this.panel1.ResumeLayout(false);
            this.metroTabControl.ResumeLayout(false);
            this.tabPageCreate.ResumeLayout(false);
            this.tabPageCreate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.tabPagePending.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPending)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroTabControl metroTabControl;
        private MetroFramework.Controls.MetroTabPage tabPageCreate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.LinkLabel linkAddProducts;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lbluserID;
        private System.Windows.Forms.TextBox txtBeforeDisc;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDiscPercent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        public FontAwesome.Sharp.IconButton btnRefNo;
        public System.Windows.Forms.TextBox txtReferenceCode;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label dt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private RJCodeAdvance.RJControls.RJButton btnCancel;
        private RJCodeAdvance.RJControls.RJButton btnCreatePo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.DataGridView dataGridView;
        private MetroFramework.Controls.MetroTabPage tabPagePending;
        public System.Windows.Forms.DataGridView dataGridViewPending;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn poID;
        private System.Windows.Forms.DataGridViewTextBoxColumn pid;
        private System.Windows.Forms.DataGridViewTextBoxColumn refcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        public System.Windows.Forms.TextBox txtDiscPhp;
        public System.Windows.Forms.TextBox txtPaymentDue;
        public System.Windows.Forms.ComboBox cbOrderBy;
        public System.Windows.Forms.DateTimePicker dtpDeliveryDate;
        public System.Windows.Forms.DateTimePicker dtpOrderDate;
        public System.Windows.Forms.TextBox txtEmail;
        public System.Windows.Forms.TextBox txtContactPerson;
        public System.Windows.Forms.ComboBox cbVendor;
        public System.Windows.Forms.TextBox txtSenderEmail;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.TextBox txtRemarks;
        public System.Windows.Forms.Label txtSenderPassword;
    }
}
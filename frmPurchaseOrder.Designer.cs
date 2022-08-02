
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.linkAddProducts = new System.Windows.Forms.LinkLabel();
            this.discPercent = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lbluserID = new System.Windows.Forms.Label();
            this.txtBeforeDisc = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtDiscPHP = new System.Windows.Forms.TextBox();
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
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.linkAddProducts);
            this.panel1.Controls.Add(this.discPercent);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.lbluserID);
            this.panel1.Controls.Add(this.txtBeforeDisc);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtDiscPHP);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtPaymentDue);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnRefNo);
            this.panel1.Controls.Add(this.txtReferenceCode);
            this.panel1.Controls.Add(this.cbOrderBy);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.dtpDeliveryDate);
            this.panel1.Controls.Add(this.dt);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.dtpOrderDate);
            this.panel1.Controls.Add(this.txtEmail);
            this.panel1.Controls.Add(this.txtContactPerson);
            this.panel1.Controls.Add(this.cbVendor);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnCreatePo);
            this.panel1.Controls.Add(this.txtRemarks);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.dataGridView);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(10);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(15);
            this.panel1.Size = new System.Drawing.Size(988, 492);
            this.panel1.TabIndex = 0;
            // 
            // linkAddProducts
            // 
            this.linkAddProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkAddProducts.AutoSize = true;
            this.linkAddProducts.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkAddProducts.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.linkAddProducts.Location = new System.Drawing.Point(870, 120);
            this.linkAddProducts.Name = "linkAddProducts";
            this.linkAddProducts.Size = new System.Drawing.Size(102, 17);
            this.linkAddProducts.TabIndex = 61;
            this.linkAddProducts.TabStop = true;
            this.linkAddProducts.Text = "Select Products";
            this.linkAddProducts.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkAddProducts_LinkClicked);
            // 
            // discPercent
            // 
            this.discPercent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.discPercent.Location = new System.Drawing.Point(874, 380);
            this.discPercent.Name = "discPercent";
            this.discPercent.Size = new System.Drawing.Size(104, 23);
            this.discPercent.TabIndex = 60;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(846, 382);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(22, 20);
            this.label12.TabIndex = 59;
            this.label12.Text = "%";
            // 
            // lbluserID
            // 
            this.lbluserID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbluserID.AutoSize = true;
            this.lbluserID.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbluserID.Location = new System.Drawing.Point(338, 353);
            this.lbluserID.Name = "lbluserID";
            this.lbluserID.Size = new System.Drawing.Size(62, 17);
            this.lbluserID.TabIndex = 58;
            this.lbluserID.Text = "Order By";
            this.lbluserID.Visible = false;
            // 
            // txtBeforeDisc
            // 
            this.txtBeforeDisc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBeforeDisc.Location = new System.Drawing.Point(736, 351);
            this.txtBeforeDisc.Name = "txtBeforeDisc";
            this.txtBeforeDisc.Size = new System.Drawing.Size(240, 23);
            this.txtBeforeDisc.TabIndex = 57;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(595, 353);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(132, 17);
            this.label11.TabIndex = 56;
            this.label11.Text = "Due Before Discount";
            // 
            // txtDiscPHP
            // 
            this.txtDiscPHP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDiscPHP.Location = new System.Drawing.Point(736, 380);
            this.txtDiscPHP.Name = "txtDiscPHP";
            this.txtDiscPHP.Size = new System.Drawing.Size(105, 23);
            this.txtDiscPHP.TabIndex = 55;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(595, 381);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 17);
            this.label1.TabIndex = 54;
            this.label1.Text = "Discount";
            // 
            // txtPaymentDue
            // 
            this.txtPaymentDue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPaymentDue.Location = new System.Drawing.Point(736, 409);
            this.txtPaymentDue.Name = "txtPaymentDue";
            this.txtPaymentDue.Size = new System.Drawing.Size(240, 23);
            this.txtPaymentDue.TabIndex = 53;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(595, 410);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 17);
            this.label9.TabIndex = 52;
            this.label9.Text = "Payment Due";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(654, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 17);
            this.label2.TabIndex = 51;
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
            this.btnRefNo.Location = new System.Drawing.Point(622, 14);
            this.btnRefNo.Name = "btnRefNo";
            this.btnRefNo.Size = new System.Drawing.Size(26, 26);
            this.btnRefNo.TabIndex = 50;
            this.btnRefNo.UseVisualStyleBackColor = true;
            this.btnRefNo.Click += new System.EventHandler(this.btnRefNo_Click);
            // 
            // txtReferenceCode
            // 
            this.txtReferenceCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReferenceCode.Location = new System.Drawing.Point(762, 14);
            this.txtReferenceCode.Name = "txtReferenceCode";
            this.txtReferenceCode.Size = new System.Drawing.Size(210, 23);
            this.txtReferenceCode.TabIndex = 37;
            // 
            // cbOrderBy
            // 
            this.cbOrderBy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cbOrderBy.FormattingEnabled = true;
            this.cbOrderBy.Location = new System.Drawing.Point(86, 351);
            this.cbOrderBy.Name = "cbOrderBy";
            this.cbOrderBy.Size = new System.Drawing.Size(246, 23);
            this.cbOrderBy.TabIndex = 35;
            this.cbOrderBy.SelectedIndexChanged += new System.EventHandler(this.cbOrderBy_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(18, 353);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 17);
            this.label10.TabIndex = 34;
            this.label10.Text = "Order By";
            // 
            // dtpDeliveryDate
            // 
            this.dtpDeliveryDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDeliveryDate.Location = new System.Drawing.Point(762, 73);
            this.dtpDeliveryDate.Name = "dtpDeliveryDate";
            this.dtpDeliveryDate.Size = new System.Drawing.Size(210, 23);
            this.dtpDeliveryDate.TabIndex = 32;
            // 
            // dt
            // 
            this.dt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dt.AutoSize = true;
            this.dt.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt.Location = new System.Drawing.Point(654, 77);
            this.dt.Name = "dt";
            this.dt.Size = new System.Drawing.Size(89, 17);
            this.dt.TabIndex = 31;
            this.dt.Text = "Delivery Date";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(654, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 17);
            this.label8.TabIndex = 30;
            this.label8.Text = "Order Date";
            // 
            // dtpOrderDate
            // 
            this.dtpOrderDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpOrderDate.Location = new System.Drawing.Point(762, 43);
            this.dtpOrderDate.Name = "dtpOrderDate";
            this.dtpOrderDate.Size = new System.Drawing.Size(210, 23);
            this.dtpOrderDate.TabIndex = 29;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(124, 70);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(219, 23);
            this.txtEmail.TabIndex = 28;
            // 
            // txtContactPerson
            // 
            this.txtContactPerson.Location = new System.Drawing.Point(124, 41);
            this.txtContactPerson.Name = "txtContactPerson";
            this.txtContactPerson.Size = new System.Drawing.Size(219, 23);
            this.txtContactPerson.TabIndex = 27;
            // 
            // cbVendor
            // 
            this.cbVendor.FormattingEnabled = true;
            this.cbVendor.Location = new System.Drawing.Point(124, 12);
            this.cbVendor.Name = "cbVendor";
            this.cbVendor.Size = new System.Drawing.Size(219, 23);
            this.cbVendor.TabIndex = 25;
            this.cbVendor.SelectedIndexChanged += new System.EventHandler(this.cbVendor_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(18, 71);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 17);
            this.label7.TabIndex = 24;
            this.label7.Text = "Email";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 17);
            this.label6.TabIndex = 23;
            this.label6.Text = "Contact Person";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 17);
            this.label5.TabIndex = 22;
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
            this.btnCancel.Location = new System.Drawing.Point(124, 454);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(102, 28);
            this.btnCancel.TabIndex = 19;
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
            this.btnCreatePo.Location = new System.Drawing.Point(16, 454);
            this.btnCreatePo.Name = "btnCreatePo";
            this.btnCreatePo.Size = new System.Drawing.Size(102, 28);
            this.btnCreatePo.TabIndex = 18;
            this.btnCreatePo.Text = "Create PO";
            this.btnCreatePo.TextColor = System.Drawing.Color.White;
            this.btnCreatePo.UseVisualStyleBackColor = false;
            this.btnCreatePo.Click += new System.EventHandler(this.btnCreatePo_Click);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtRemarks.Location = new System.Drawing.Point(86, 380);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(432, 68);
            this.txtRemarks.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(18, 385);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 24);
            this.label4.TabIndex = 15;
            this.label4.Text = "Remarks";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 24);
            this.label3.TabIndex = 14;
            this.label3.Text = "Items";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(239)))), ((int)(((byte)(249)))));
            this.dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(57)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(57)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
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
            this.dataGridView.Location = new System.Drawing.Point(16, 145);
            this.dataGridView.Name = "dataGridView";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(151)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(151)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(960, 200);
            this.dataGridView.TabIndex = 13;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.HeaderText = "#";
            this.Column3.Name = "Column3";
            this.Column3.Width = 37;
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
            this.Column4.Width = 56;
            // 
            // Column5
            // 
            this.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column5.HeaderText = "QTY (Carton)";
            this.Column5.Name = "Column5";
            this.Column5.Width = 90;
            // 
            // total
            // 
            this.total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.total.HeaderText = "Total";
            this.total.Name = "total";
            this.total.ReadOnly = true;
            this.total.Width = 56;
            // 
            // frmPurchaseOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(988, 492);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmPurchaseOrder";
            this.Tag = "Purchase Order/PO";
            this.Text = "Purchase Order/PO";
            this.Load += new System.EventHandler(this.frmPurchaseOrder_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DateTimePicker dtpDeliveryDate;
        private System.Windows.Forms.Label dt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpOrderDate;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtContactPerson;
        private System.Windows.Forms.ComboBox cbVendor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private RJCodeAdvance.RJControls.RJButton btnCancel;
        private RJCodeAdvance.RJControls.RJButton btnCreatePo;
        private System.Windows.Forms.ComboBox cbOrderBy;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPaymentDue;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label2;
        public FontAwesome.Sharp.IconButton btnRefNo;
        private System.Windows.Forms.TextBox txtBeforeDisc;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtDiscPHP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbluserID;
        private System.Windows.Forms.TextBox discPercent;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.LinkLabel linkAddProducts;
        public System.Windows.Forms.TextBox txtReferenceCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn poID;
        private System.Windows.Forms.DataGridViewTextBoxColumn pid;
        private System.Windows.Forms.DataGridViewTextBoxColumn refcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
    }
}
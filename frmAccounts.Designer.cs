
namespace CapstoneProject_3
{
    partial class frmAccounts
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tab = new MetroFramework.Controls.MetroTabControl();
            this.tabAdd = new MetroFramework.Controls.MetroTabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.txtConfirmPw = new System.Windows.Forms.TextBox();
            this.txtFname = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUname = new System.Windows.Forms.TextBox();
            this.btnUpdate = new RJCodeAdvance.RJControls.RJButton();
            this.label7 = new System.Windows.Forms.Label();
            this.cbRole = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBack = new FontAwesome.Sharp.IconButton();
            this.btnAddNew = new RJCodeAdvance.RJControls.RJButton();
            this.tabUpdate = new MetroFramework.Controls.MetroTabPage();
            this.cbUsers2 = new System.Windows.Forms.ComboBox();
            this.txtOldPassword = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConfPassword2 = new System.Windows.Forms.TextBox();
            this.txtPassword2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSaveUpdate = new RJCodeAdvance.RJControls.RJButton();
            this.btnCancel = new RJCodeAdvance.RJControls.RJButton();
            this.btnBack2 = new FontAwesome.Sharp.IconButton();
            this.tabManage = new MetroFramework.Controls.MetroTabPage();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.role = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.disable = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.tab.SuspendLayout();
            this.tabAdd.SuspendLayout();
            this.tabUpdate.SuspendLayout();
            this.tabManage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 1);
            this.panel1.TabIndex = 1;
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabAdd);
            this.tab.Controls.Add(this.tabUpdate);
            this.tab.Controls.Add(this.tabManage);
            this.tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab.FontWeight = MetroFramework.MetroTabControlWeight.Regular;
            this.tab.Location = new System.Drawing.Point(0, 1);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 2;
            this.tab.Size = new System.Drawing.Size(800, 449);
            this.tab.TabIndex = 2;
            this.tab.UseSelectable = true;
            // 
            // tabAdd
            // 
            this.tabAdd.BackColor = System.Drawing.Color.White;
            this.tabAdd.Controls.Add(this.label8);
            this.tabAdd.Controls.Add(this.txtConfirmPw);
            this.tabAdd.Controls.Add(this.txtFname);
            this.tabAdd.Controls.Add(this.txtPassword);
            this.tabAdd.Controls.Add(this.txtUname);
            this.tabAdd.Controls.Add(this.btnUpdate);
            this.tabAdd.Controls.Add(this.label7);
            this.tabAdd.Controls.Add(this.cbRole);
            this.tabAdd.Controls.Add(this.label5);
            this.tabAdd.Controls.Add(this.label4);
            this.tabAdd.Controls.Add(this.label3);
            this.tabAdd.Controls.Add(this.btnBack);
            this.tabAdd.Controls.Add(this.btnAddNew);
            this.tabAdd.HorizontalScrollbarBarColor = true;
            this.tabAdd.HorizontalScrollbarHighlightOnWheel = false;
            this.tabAdd.HorizontalScrollbarSize = 10;
            this.tabAdd.Location = new System.Drawing.Point(4, 38);
            this.tabAdd.Name = "tabAdd";
            this.tabAdd.Size = new System.Drawing.Size(792, 407);
            this.tabAdd.TabIndex = 0;
            this.tabAdd.Text = "Add User";
            this.tabAdd.VerticalScrollbarBarColor = true;
            this.tabAdd.VerticalScrollbarHighlightOnWheel = false;
            this.tabAdd.VerticalScrollbarSize = 10;
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(93, 201);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 17);
            this.label8.TabIndex = 37;
            this.label8.Text = "Confirm Password";
            // 
            // txtConfirmPw
            // 
            this.txtConfirmPw.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtConfirmPw.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPw.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtConfirmPw.Location = new System.Drawing.Point(217, 198);
            this.txtConfirmPw.Name = "txtConfirmPw";
            this.txtConfirmPw.PasswordChar = '*';
            this.txtConfirmPw.Size = new System.Drawing.Size(433, 25);
            this.txtConfirmPw.TabIndex = 36;
            // 
            // txtFname
            // 
            this.txtFname.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtFname.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFname.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtFname.Location = new System.Drawing.Point(217, 74);
            this.txtFname.Name = "txtFname";
            this.txtFname.Size = new System.Drawing.Size(433, 25);
            this.txtFname.TabIndex = 32;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPassword.Location = new System.Drawing.Point(217, 167);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(433, 25);
            this.txtPassword.TabIndex = 30;
            // 
            // txtUname
            // 
            this.txtUname.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUname.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUname.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtUname.Location = new System.Drawing.Point(217, 105);
            this.txtUname.Name = "txtUname";
            this.txtUname.Size = new System.Drawing.Size(433, 25);
            this.txtUname.TabIndex = 28;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnUpdate.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnUpdate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnUpdate.BorderRadius = 5;
            this.btnUpdate.BorderSize = 0;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(447, 244);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(115, 32);
            this.btnUpdate.TabIndex = 26;
            this.btnUpdate.Text = "Cancel";
            this.btnUpdate.TextColor = System.Drawing.Color.White;
            this.btnUpdate.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(93, 139);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 17);
            this.label7.TabIndex = 35;
            this.label7.Text = "Role";
            // 
            // cbRole
            // 
            this.cbRole.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbRole.FormattingEnabled = true;
            this.cbRole.Items.AddRange(new object[] {
            "Admin",
            "Cashier"});
            this.cbRole.Location = new System.Drawing.Point(217, 136);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(433, 21);
            this.cbRole.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(93, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 33;
            this.label5.Text = "Name";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(93, 170);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 17);
            this.label4.TabIndex = 31;
            this.label4.Text = "Password";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(93, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 29;
            this.label3.Text = "Username";
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.FlatAppearance.BorderSize = 0;
            this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft;
            this.btnBack.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(28)))), ((int)(((byte)(31)))));
            this.btnBack.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBack.IconSize = 35;
            this.btnBack.Location = new System.Drawing.Point(743, 366);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(46, 39);
            this.btnBack.TabIndex = 25;
            this.btnBack.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnAddNew
            // 
            this.btnAddNew.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnAddNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnAddNew.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnAddNew.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnAddNew.BorderRadius = 5;
            this.btnAddNew.BorderSize = 0;
            this.btnAddNew.FlatAppearance.BorderSize = 0;
            this.btnAddNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNew.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNew.ForeColor = System.Drawing.Color.White;
            this.btnAddNew.Location = new System.Drawing.Point(304, 244);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(115, 32);
            this.btnAddNew.TabIndex = 24;
            this.btnAddNew.Text = "Save";
            this.btnAddNew.TextColor = System.Drawing.Color.White;
            this.btnAddNew.UseVisualStyleBackColor = false;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // tabUpdate
            // 
            this.tabUpdate.BackColor = System.Drawing.Color.White;
            this.tabUpdate.Controls.Add(this.cbUsers2);
            this.tabUpdate.Controls.Add(this.txtOldPassword);
            this.tabUpdate.Controls.Add(this.label9);
            this.tabUpdate.Controls.Add(this.label1);
            this.tabUpdate.Controls.Add(this.txtConfPassword2);
            this.tabUpdate.Controls.Add(this.txtPassword2);
            this.tabUpdate.Controls.Add(this.label2);
            this.tabUpdate.Controls.Add(this.label6);
            this.tabUpdate.Controls.Add(this.btnSaveUpdate);
            this.tabUpdate.Controls.Add(this.btnCancel);
            this.tabUpdate.Controls.Add(this.btnBack2);
            this.tabUpdate.HorizontalScrollbarBarColor = true;
            this.tabUpdate.HorizontalScrollbarHighlightOnWheel = false;
            this.tabUpdate.HorizontalScrollbarSize = 10;
            this.tabUpdate.Location = new System.Drawing.Point(4, 38);
            this.tabUpdate.Name = "tabUpdate";
            this.tabUpdate.Size = new System.Drawing.Size(792, 407);
            this.tabUpdate.TabIndex = 1;
            this.tabUpdate.Text = "Update User";
            this.tabUpdate.VerticalScrollbarBarColor = true;
            this.tabUpdate.VerticalScrollbarHighlightOnWheel = false;
            this.tabUpdate.VerticalScrollbarSize = 10;
            // 
            // cbUsers2
            // 
            this.cbUsers2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbUsers2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbUsers2.FormattingEnabled = true;
            this.cbUsers2.Location = new System.Drawing.Point(232, 92);
            this.cbUsers2.Name = "cbUsers2";
            this.cbUsers2.Size = new System.Drawing.Size(433, 23);
            this.cbUsers2.TabIndex = 44;
            this.cbUsers2.SelectedIndexChanged += new System.EventHandler(this.cbUsers2_SelectedIndexChanged);
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtOldPassword.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldPassword.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtOldPassword.Location = new System.Drawing.Point(232, 123);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.PasswordChar = '*';
            this.txtOldPassword.Size = new System.Drawing.Size(433, 25);
            this.txtOldPassword.TabIndex = 42;
            this.txtOldPassword.UseSystemPasswordChar = true;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(108, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(91, 17);
            this.label9.TabIndex = 43;
            this.label9.Text = "Old Password";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(108, 188);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 17);
            this.label1.TabIndex = 41;
            this.label1.Text = "Confirm Password";
            // 
            // txtConfPassword2
            // 
            this.txtConfPassword2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtConfPassword2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfPassword2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtConfPassword2.Location = new System.Drawing.Point(232, 185);
            this.txtConfPassword2.Name = "txtConfPassword2";
            this.txtConfPassword2.PasswordChar = '*';
            this.txtConfPassword2.Size = new System.Drawing.Size(433, 25);
            this.txtConfPassword2.TabIndex = 40;
            this.txtConfPassword2.UseSystemPasswordChar = true;
            // 
            // txtPassword2
            // 
            this.txtPassword2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPassword2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPassword2.Location = new System.Drawing.Point(232, 154);
            this.txtPassword2.Name = "txtPassword2";
            this.txtPassword2.PasswordChar = '*';
            this.txtPassword2.Size = new System.Drawing.Size(433, 25);
            this.txtPassword2.TabIndex = 38;
            this.txtPassword2.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(108, 157);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 39;
            this.label2.Text = "Password";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(108, 95);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 17);
            this.label6.TabIndex = 37;
            this.label6.Text = "User";
            // 
            // btnSaveUpdate
            // 
            this.btnSaveUpdate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSaveUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnSaveUpdate.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnSaveUpdate.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnSaveUpdate.BorderRadius = 5;
            this.btnSaveUpdate.BorderSize = 0;
            this.btnSaveUpdate.FlatAppearance.BorderSize = 0;
            this.btnSaveUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveUpdate.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveUpdate.ForeColor = System.Drawing.Color.White;
            this.btnSaveUpdate.Location = new System.Drawing.Point(326, 231);
            this.btnSaveUpdate.Name = "btnSaveUpdate";
            this.btnSaveUpdate.Size = new System.Drawing.Size(120, 32);
            this.btnSaveUpdate.TabIndex = 35;
            this.btnSaveUpdate.Text = "Update";
            this.btnSaveUpdate.TextColor = System.Drawing.Color.White;
            this.btnSaveUpdate.UseVisualStyleBackColor = false;
            this.btnSaveUpdate.Click += new System.EventHandler(this.btnSaveUpdate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnCancel.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnCancel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnCancel.BorderRadius = 5;
            this.btnCancel.BorderSize = 0;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(455, 231);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 32);
            this.btnCancel.TabIndex = 33;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextColor = System.Drawing.Color.White;
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnBack2
            // 
            this.btnBack2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack2.FlatAppearance.BorderSize = 0;
            this.btnBack2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBack2.IconChar = FontAwesome.Sharp.IconChar.ArrowLeft;
            this.btnBack2.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(28)))), ((int)(((byte)(31)))));
            this.btnBack2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBack2.IconSize = 35;
            this.btnBack2.Location = new System.Drawing.Point(740, 364);
            this.btnBack2.Name = "btnBack2";
            this.btnBack2.Size = new System.Drawing.Size(46, 39);
            this.btnBack2.TabIndex = 34;
            this.btnBack2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBack2.UseVisualStyleBackColor = true;
            // 
            // tabManage
            // 
            this.tabManage.BackColor = System.Drawing.Color.White;
            this.tabManage.Controls.Add(this.dataGridView);
            this.tabManage.HorizontalScrollbarBarColor = true;
            this.tabManage.HorizontalScrollbarHighlightOnWheel = false;
            this.tabManage.HorizontalScrollbarSize = 10;
            this.tabManage.Location = new System.Drawing.Point(4, 38);
            this.tabManage.Name = "tabManage";
            this.tabManage.Padding = new System.Windows.Forms.Padding(0, 20, 0, 20);
            this.tabManage.Size = new System.Drawing.Size(792, 407);
            this.tabManage.TabIndex = 2;
            this.tabManage.Text = "Manage Users";
            this.tabManage.VerticalScrollbarBarColor = true;
            this.tabManage.VerticalScrollbarHighlightOnWheel = false;
            this.tabManage.VerticalScrollbarSize = 10;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            this.dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(57)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(57)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView.ColumnHeadersHeight = 40;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.userID,
            this.name,
            this.role,
            this.status,
            this.disable});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(161)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.EnableHeadersVisualStyles = false;
            this.dataGridView.Location = new System.Drawing.Point(0, 20);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(151)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(151)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(792, 367);
            this.dataGridView.TabIndex = 16;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.HeaderText = "#";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 37;
            // 
            // userID
            // 
            this.userID.HeaderText = "userID";
            this.userID.Name = "userID";
            this.userID.ReadOnly = true;
            this.userID.Visible = false;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.name.DefaultCellStyle = dataGridViewCellStyle3;
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // role
            // 
            this.role.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.role.HeaderText = "Role";
            this.role.Name = "role";
            this.role.ReadOnly = true;
            this.role.Width = 52;
            // 
            // status
            // 
            this.status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Width = 60;
            // 
            // disable
            // 
            this.disable.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.disable.HeaderText = "";
            this.disable.Image = global::CapstoneProject_3.Properties.Resources.icons8_user_minus_50;
            this.disable.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.disable.Name = "disable";
            this.disable.ReadOnly = true;
            this.disable.Width = 5;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::CapstoneProject_3.Properties.Resources.icons8_user_minus_50;
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            // 
            // frmAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tab);
            this.Controls.Add(this.panel1);
            this.Name = "frmAccounts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmAccounts_Load);
            this.tab.ResumeLayout(false);
            this.tabAdd.ResumeLayout(false);
            this.tabAdd.PerformLayout();
            this.tabUpdate.ResumeLayout(false);
            this.tabUpdate.PerformLayout();
            this.tabManage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroTabControl tab;
        private MetroFramework.Controls.MetroTabPage tabAdd;
        private MetroFramework.Controls.MetroTabPage tabUpdate;
        private MetroFramework.Controls.MetroTabPage tabManage;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtConfirmPw;
        private System.Windows.Forms.TextBox txtFname;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUname;
        private RJCodeAdvance.RJControls.RJButton btnUpdate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbRole;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconButton btnBack;
        private RJCodeAdvance.RJControls.RJButton btnAddNew;
        private System.Windows.Forms.ComboBox cbUsers2;
        private System.Windows.Forms.TextBox txtOldPassword;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConfPassword2;
        private System.Windows.Forms.TextBox txtPassword2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private RJCodeAdvance.RJControls.RJButton btnSaveUpdate;
        private RJCodeAdvance.RJControls.RJButton btnCancel;
        private FontAwesome.Sharp.IconButton btnBack2;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn userID;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn role;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewImageColumn disable;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
    }
}
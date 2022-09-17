﻿
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tab = new MetroFramework.Controls.MetroTabControl();
            this.tabManageUsers = new MetroFramework.Controls.MetroTabPage();
            this.btnSaveUpdate = new RJCodeAdvance.RJControls.RJButton();
            this.txtEmailPassword = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblCpassword = new System.Windows.Forms.Label();
            this.txtConfirmPw = new System.Windows.Forms.TextBox();
            this.txtFname = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUname = new System.Windows.Forms.TextBox();
            this.btnCancel = new RJCodeAdvance.RJControls.RJButton();
            this.label7 = new System.Windows.Forms.Label();
            this.cbRole = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBack = new FontAwesome.Sharp.IconButton();
            this.btnAddNew = new RJCodeAdvance.RJControls.RJButton();
            this.tabUserList = new MetroFramework.Controls.MetroTabPage();
            this.btnDelete = new RJCodeAdvance.RJControls.RJButton();
            this.btnUpdateUser = new RJCodeAdvance.RJControls.RJButton();
            this.btnAddNewUser = new RJCodeAdvance.RJControls.RJButton();
            this.btnSearch = new FontAwesome.Sharp.IconButton();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.role = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.disable = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtOldPassword = new System.Windows.Forms.TextBox();
            this.lblOldPassword = new System.Windows.Forms.Label();
            this.tab.SuspendLayout();
            this.tabManageUsers.SuspendLayout();
            this.tabUserList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(864, 1);
            this.panel1.TabIndex = 1;
            // 
            // tab
            // 
            this.tab.Controls.Add(this.tabManageUsers);
            this.tab.Controls.Add(this.tabUserList);
            this.tab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tab.FontWeight = MetroFramework.MetroTabControlWeight.Regular;
            this.tab.Location = new System.Drawing.Point(0, 1);
            this.tab.Name = "tab";
            this.tab.SelectedIndex = 0;
            this.tab.Size = new System.Drawing.Size(864, 449);
            this.tab.TabIndex = 2;
            this.tab.UseSelectable = true;
            this.tab.SelectedIndexChanged += new System.EventHandler(this.tab_SelectedIndexChanged);
            // 
            // tabManageUsers
            // 
            this.tabManageUsers.BackColor = System.Drawing.Color.White;
            this.tabManageUsers.Controls.Add(this.txtOldPassword);
            this.tabManageUsers.Controls.Add(this.lblOldPassword);
            this.tabManageUsers.Controls.Add(this.btnSaveUpdate);
            this.tabManageUsers.Controls.Add(this.txtEmailPassword);
            this.tabManageUsers.Controls.Add(this.label11);
            this.tabManageUsers.Controls.Add(this.txtEmail);
            this.tabManageUsers.Controls.Add(this.label10);
            this.tabManageUsers.Controls.Add(this.lblCpassword);
            this.tabManageUsers.Controls.Add(this.txtConfirmPw);
            this.tabManageUsers.Controls.Add(this.txtFname);
            this.tabManageUsers.Controls.Add(this.txtPassword);
            this.tabManageUsers.Controls.Add(this.txtUname);
            this.tabManageUsers.Controls.Add(this.btnCancel);
            this.tabManageUsers.Controls.Add(this.label7);
            this.tabManageUsers.Controls.Add(this.cbRole);
            this.tabManageUsers.Controls.Add(this.label5);
            this.tabManageUsers.Controls.Add(this.lblPassword);
            this.tabManageUsers.Controls.Add(this.label3);
            this.tabManageUsers.Controls.Add(this.btnBack);
            this.tabManageUsers.Controls.Add(this.btnAddNew);
            this.tabManageUsers.HorizontalScrollbarBarColor = true;
            this.tabManageUsers.HorizontalScrollbarHighlightOnWheel = false;
            this.tabManageUsers.HorizontalScrollbarSize = 10;
            this.tabManageUsers.Location = new System.Drawing.Point(4, 38);
            this.tabManageUsers.Name = "tabManageUsers";
            this.tabManageUsers.Size = new System.Drawing.Size(856, 407);
            this.tabManageUsers.TabIndex = 0;
            this.tabManageUsers.Text = "Manage Users";
            this.tabManageUsers.VerticalScrollbarBarColor = true;
            this.tabManageUsers.VerticalScrollbarHighlightOnWheel = false;
            this.tabManageUsers.VerticalScrollbarSize = 10;
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
            this.btnSaveUpdate.Location = new System.Drawing.Point(403, 308);
            this.btnSaveUpdate.Name = "btnSaveUpdate";
            this.btnSaveUpdate.Size = new System.Drawing.Size(120, 32);
            this.btnSaveUpdate.TabIndex = 42;
            this.btnSaveUpdate.Text = "Update";
            this.btnSaveUpdate.TextColor = System.Drawing.Color.White;
            this.btnSaveUpdate.UseVisualStyleBackColor = false;
            this.btnSaveUpdate.Click += new System.EventHandler(this.btnSaveUpdate_Click);
            // 
            // txtEmailPassword
            // 
            this.txtEmailPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEmailPassword.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmailPassword.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtEmailPassword.Location = new System.Drawing.Point(249, 174);
            this.txtEmailPassword.Name = "txtEmailPassword";
            this.txtEmailPassword.PasswordChar = '*';
            this.txtEmailPassword.Size = new System.Drawing.Size(433, 25);
            this.txtEmailPassword.TabIndex = 40;
            // 
            // label11
            // 
            this.label11.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(125, 177);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 17);
            this.label11.TabIndex = 41;
            this.label11.Text = "Email Password";
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtEmail.Location = new System.Drawing.Point(249, 143);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(433, 25);
            this.txtEmail.TabIndex = 38;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(125, 146);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 17);
            this.label10.TabIndex = 39;
            this.label10.Text = "Email";
            // 
            // lblCpassword
            // 
            this.lblCpassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCpassword.AutoSize = true;
            this.lblCpassword.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCpassword.Location = new System.Drawing.Point(125, 270);
            this.lblCpassword.Name = "lblCpassword";
            this.lblCpassword.Size = new System.Drawing.Size(118, 17);
            this.lblCpassword.TabIndex = 37;
            this.lblCpassword.Text = "Confirm Password";
            // 
            // txtConfirmPw
            // 
            this.txtConfirmPw.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtConfirmPw.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPw.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtConfirmPw.Location = new System.Drawing.Point(249, 267);
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
            this.txtFname.Location = new System.Drawing.Point(249, 54);
            this.txtFname.Name = "txtFname";
            this.txtFname.Size = new System.Drawing.Size(433, 25);
            this.txtFname.TabIndex = 32;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPassword.Location = new System.Drawing.Point(249, 236);
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
            this.txtUname.Location = new System.Drawing.Point(249, 85);
            this.txtUname.Name = "txtUname";
            this.txtUname.Size = new System.Drawing.Size(433, 25);
            this.txtUname.TabIndex = 28;
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
            this.btnCancel.Location = new System.Drawing.Point(529, 308);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(115, 32);
            this.btnCancel.TabIndex = 26;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextColor = System.Drawing.Color.White;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(125, 119);
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
            this.cbRole.Location = new System.Drawing.Point(249, 116);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(433, 21);
            this.cbRole.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(125, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 33;
            this.label5.Text = "Name";
            // 
            // lblPassword
            // 
            this.lblPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPassword.Location = new System.Drawing.Point(125, 239);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(66, 17);
            this.lblPassword.TabIndex = 31;
            this.lblPassword.Text = "Password";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(125, 88);
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
            this.btnBack.Location = new System.Drawing.Point(818, 369);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(35, 35);
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
            this.btnAddNew.Location = new System.Drawing.Point(282, 308);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(115, 32);
            this.btnAddNew.TabIndex = 24;
            this.btnAddNew.Text = "Save";
            this.btnAddNew.TextColor = System.Drawing.Color.White;
            this.btnAddNew.UseVisualStyleBackColor = false;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // tabUserList
            // 
            this.tabUserList.BackColor = System.Drawing.Color.White;
            this.tabUserList.Controls.Add(this.btnDelete);
            this.tabUserList.Controls.Add(this.btnUpdateUser);
            this.tabUserList.Controls.Add(this.btnAddNewUser);
            this.tabUserList.Controls.Add(this.btnSearch);
            this.tabUserList.Controls.Add(this.txtSearch);
            this.tabUserList.Controls.Add(this.dataGridView);
            this.tabUserList.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabUserList.HorizontalScrollbarBarColor = true;
            this.tabUserList.HorizontalScrollbarHighlightOnWheel = false;
            this.tabUserList.HorizontalScrollbarSize = 10;
            this.tabUserList.Location = new System.Drawing.Point(4, 38);
            this.tabUserList.Name = "tabUserList";
            this.tabUserList.Padding = new System.Windows.Forms.Padding(0, 20, 0, 20);
            this.tabUserList.Size = new System.Drawing.Size(856, 407);
            this.tabUserList.TabIndex = 2;
            this.tabUserList.Text = "User List";
            this.tabUserList.VerticalScrollbarBarColor = true;
            this.tabUserList.VerticalScrollbarHighlightOnWheel = false;
            this.tabUserList.VerticalScrollbarSize = 10;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnDelete.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnDelete.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(198)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.btnDelete.BorderRadius = 5;
            this.btnDelete.BorderSize = 0;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(734, 121);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(119, 32);
            this.btnDelete.TabIndex = 24;
            this.btnDelete.Text = "Delete";
            this.btnDelete.TextColor = System.Drawing.Color.White;
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnUpdateUser
            // 
            this.btnUpdateUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdateUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnUpdateUser.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnUpdateUser.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnUpdateUser.BorderRadius = 5;
            this.btnUpdateUser.BorderSize = 0;
            this.btnUpdateUser.FlatAppearance.BorderSize = 0;
            this.btnUpdateUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdateUser.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateUser.ForeColor = System.Drawing.Color.White;
            this.btnUpdateUser.Location = new System.Drawing.Point(734, 83);
            this.btnUpdateUser.Name = "btnUpdateUser";
            this.btnUpdateUser.Size = new System.Drawing.Size(119, 32);
            this.btnUpdateUser.TabIndex = 23;
            this.btnUpdateUser.Text = "Update";
            this.btnUpdateUser.TextColor = System.Drawing.Color.White;
            this.btnUpdateUser.UseVisualStyleBackColor = false;
            this.btnUpdateUser.Click += new System.EventHandler(this.btnUpdateUser_Click);
            // 
            // btnAddNewUser
            // 
            this.btnAddNewUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNewUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnAddNewUser.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnAddNewUser.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnAddNewUser.BorderRadius = 5;
            this.btnAddNewUser.BorderSize = 0;
            this.btnAddNewUser.FlatAppearance.BorderSize = 0;
            this.btnAddNewUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewUser.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNewUser.ForeColor = System.Drawing.Color.White;
            this.btnAddNewUser.Location = new System.Drawing.Point(734, 45);
            this.btnAddNewUser.Name = "btnAddNewUser";
            this.btnAddNewUser.Size = new System.Drawing.Size(119, 32);
            this.btnAddNewUser.TabIndex = 22;
            this.btnAddNewUser.Text = "Add New";
            this.btnAddNewUser.TextColor = System.Drawing.Color.White;
            this.btnAddNewUser.UseVisualStyleBackColor = false;
            this.btnAddNewUser.Click += new System.EventHandler(this.btnAddNewUser_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Enabled = false;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(28)))), ((int)(((byte)(31)))));
            this.btnSearch.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnSearch.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(28)))), ((int)(((byte)(31)))));
            this.btnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSearch.IconSize = 25;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnSearch.Location = new System.Drawing.Point(11, 8);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(83, 31);
            this.btnSearch.TabIndex = 21;
            this.btnSearch.Text = "Search";
            this.btnSearch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(100, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(628, 25);
            this.txtSearch.TabIndex = 20;
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.White;
            this.dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(57)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(57)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView.ColumnHeadersHeight = 40;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.userID,
            this.name,
            this.Column1,
            this.role,
            this.status,
            this.disable});
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(161)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridView.EnableHeadersVisualStyles = false;
            this.dataGridView.Location = new System.Drawing.Point(19, 45);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(151)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(151)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(709, 354);
            this.dataGridView.TabIndex = 16;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_CellContentClick);
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.HeaderText = "#";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 39;
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
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.name.DefaultCellStyle = dataGridViewCellStyle9;
            this.name.HeaderText = "Name";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column1.HeaderText = "Email";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 63;
            // 
            // role
            // 
            this.role.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.role.HeaderText = "Role";
            this.role.Name = "role";
            this.role.ReadOnly = true;
            this.role.Width = 57;
            // 
            // status
            // 
            this.status.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            this.status.Width = 69;
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
            // txtOldPassword
            // 
            this.txtOldPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtOldPassword.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOldPassword.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtOldPassword.Location = new System.Drawing.Point(249, 205);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.PasswordChar = '*';
            this.txtOldPassword.Size = new System.Drawing.Size(433, 25);
            this.txtOldPassword.TabIndex = 43;
            // 
            // lblOldPassword
            // 
            this.lblOldPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblOldPassword.AutoSize = true;
            this.lblOldPassword.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOldPassword.Location = new System.Drawing.Point(125, 208);
            this.lblOldPassword.Name = "lblOldPassword";
            this.lblOldPassword.Size = new System.Drawing.Size(91, 17);
            this.lblOldPassword.TabIndex = 44;
            this.lblOldPassword.Text = "Old Password";
            // 
            // frmAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 450);
            this.Controls.Add(this.tab);
            this.Controls.Add(this.panel1);
            this.Name = "frmAccounts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "Accounts Module";
            this.Text = "Accounts Module";
            this.Load += new System.EventHandler(this.frmAccounts_Load);
            this.tab.ResumeLayout(false);
            this.tabManageUsers.ResumeLayout(false);
            this.tabManageUsers.PerformLayout();
            this.tabUserList.ResumeLayout(false);
            this.tabUserList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private MetroFramework.Controls.MetroTabControl tab;
        private MetroFramework.Controls.MetroTabPage tabManageUsers;
        private MetroFramework.Controls.MetroTabPage tabUserList;
        private System.Windows.Forms.Label lblCpassword;
        private System.Windows.Forms.TextBox txtConfirmPw;
        private System.Windows.Forms.TextBox txtFname;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUname;
        private RJCodeAdvance.RJControls.RJButton btnCancel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbRole;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label label3;
        private FontAwesome.Sharp.IconButton btnBack;
        private RJCodeAdvance.RJControls.RJButton btnAddNew;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn userID;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn role;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewImageColumn disable;
        private System.Windows.Forms.TextBox txtEmailPassword;
        private System.Windows.Forms.Label label11;
        private FontAwesome.Sharp.IconButton btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private RJCodeAdvance.RJControls.RJButton btnUpdateUser;
        private RJCodeAdvance.RJControls.RJButton btnAddNewUser;
        private RJCodeAdvance.RJControls.RJButton btnDelete;
        private RJCodeAdvance.RJControls.RJButton btnSaveUpdate;
        private System.Windows.Forms.TextBox txtOldPassword;
        private System.Windows.Forms.Label lblOldPassword;
    }
}
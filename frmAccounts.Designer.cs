
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabCreateUser = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.txtConfirmPw = new System.Windows.Forms.TextBox();
            this.btnUpdate = new RJCodeAdvance.RJControls.RJButton();
            this.label7 = new System.Windows.Forms.Label();
            this.cbRole = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtFname = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUname = new System.Windows.Forms.TextBox();
            this.panelNotif1 = new System.Windows.Forms.Panel();
            this.labelNotif1 = new System.Windows.Forms.Label();
            this.iconNotif1 = new FontAwesome.Sharp.IconPictureBox();
            this.btnBack = new FontAwesome.Sharp.IconButton();
            this.btnAddNew = new RJCodeAdvance.RJControls.RJButton();
            this.tabManage = new System.Windows.Forms.TabPage();
            this.panelNotif2 = new System.Windows.Forms.Panel();
            this.labelNotif2 = new System.Windows.Forms.Label();
            this.iconNotif2 = new FontAwesome.Sharp.IconPictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSaveUpdate = new RJCodeAdvance.RJControls.RJButton();
            this.btnBack2 = new FontAwesome.Sharp.IconButton();
            this.btnCancel = new RJCodeAdvance.RJControls.RJButton();
            this.btnSave = new RJCodeAdvance.RJControls.RJButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tabDeleteUser = new System.Windows.Forms.TabPage();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tabControl.SuspendLayout();
            this.tabCreateUser.SuspendLayout();
            this.panelNotif1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconNotif1)).BeginInit();
            this.tabManage.SuspendLayout();
            this.panelNotif2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconNotif2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(221)))), ((int)(((byte)(225)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 10);
            this.panel1.TabIndex = 1;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabCreateUser);
            this.tabControl.Controls.Add(this.tabManage);
            this.tabControl.Controls.Add(this.tabDeleteUser);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(0, 10);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 440);
            this.tabControl.TabIndex = 2;
            // 
            // tabCreateUser
            // 
            this.tabCreateUser.BackColor = System.Drawing.Color.White;
            this.tabCreateUser.Controls.Add(this.label8);
            this.tabCreateUser.Controls.Add(this.txtConfirmPw);
            this.tabCreateUser.Controls.Add(this.btnUpdate);
            this.tabCreateUser.Controls.Add(this.label7);
            this.tabCreateUser.Controls.Add(this.cbRole);
            this.tabCreateUser.Controls.Add(this.label5);
            this.tabCreateUser.Controls.Add(this.txtFname);
            this.tabCreateUser.Controls.Add(this.label4);
            this.tabCreateUser.Controls.Add(this.txtPassword);
            this.tabCreateUser.Controls.Add(this.label3);
            this.tabCreateUser.Controls.Add(this.txtUname);
            this.tabCreateUser.Controls.Add(this.panelNotif1);
            this.tabCreateUser.Controls.Add(this.btnBack);
            this.tabCreateUser.Controls.Add(this.btnAddNew);
            this.tabCreateUser.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabCreateUser.Location = new System.Drawing.Point(4, 26);
            this.tabCreateUser.Name = "tabCreateUser";
            this.tabCreateUser.Padding = new System.Windows.Forms.Padding(3);
            this.tabCreateUser.Size = new System.Drawing.Size(792, 410);
            this.tabCreateUser.TabIndex = 0;
            this.tabCreateUser.Text = "Create User";
            // 
            // label8
            // 
            this.label8.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(93, 234);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(118, 17);
            this.label8.TabIndex = 23;
            this.label8.Text = "Confirm Password";
            // 
            // txtConfirmPw
            // 
            this.txtConfirmPw.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtConfirmPw.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmPw.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtConfirmPw.Location = new System.Drawing.Point(217, 226);
            this.txtConfirmPw.Name = "txtConfirmPw";
            this.txtConfirmPw.PasswordChar = '*';
            this.txtConfirmPw.Size = new System.Drawing.Size(433, 25);
            this.txtConfirmPw.TabIndex = 22;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUpdate.BackColor = System.Drawing.Color.SteelBlue;
            this.btnUpdate.BackgroundColor = System.Drawing.Color.SteelBlue;
            this.btnUpdate.BorderColor = System.Drawing.Color.SteelBlue;
            this.btnUpdate.BorderRadius = 5;
            this.btnUpdate.BorderSize = 0;
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(459, 286);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(115, 32);
            this.btnUpdate.TabIndex = 9;
            this.btnUpdate.Text = "Cancel";
            this.btnUpdate.TextColor = System.Drawing.Color.White;
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(93, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 17);
            this.label7.TabIndex = 21;
            this.label7.Text = "Role";
            // 
            // cbRole
            // 
            this.cbRole.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbRole.FormattingEnabled = true;
            this.cbRole.Items.AddRange(new object[] {
            "Admin",
            "Cashier"});
            this.cbRole.Location = new System.Drawing.Point(217, 148);
            this.cbRole.Name = "cbRole";
            this.cbRole.Size = new System.Drawing.Size(433, 25);
            this.cbRole.TabIndex = 20;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(93, 67);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 17;
            this.label5.Text = "Name";
            // 
            // txtFname
            // 
            this.txtFname.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtFname.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFname.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtFname.Location = new System.Drawing.Point(217, 64);
            this.txtFname.Name = "txtFname";
            this.txtFname.Size = new System.Drawing.Size(433, 25);
            this.txtFname.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(93, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtPassword.Location = new System.Drawing.Point(217, 187);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(433, 25);
            this.txtPassword.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(93, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Username";
            // 
            // txtUname
            // 
            this.txtUname.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUname.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUname.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtUname.Location = new System.Drawing.Point(217, 109);
            this.txtUname.Name = "txtUname";
            this.txtUname.Size = new System.Drawing.Size(433, 25);
            this.txtUname.TabIndex = 12;
            // 
            // panelNotif1
            // 
            this.panelNotif1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelNotif1.Controls.Add(this.labelNotif1);
            this.panelNotif1.Controls.Add(this.iconNotif1);
            this.panelNotif1.Location = new System.Drawing.Point(-12, 379);
            this.panelNotif1.Name = "panelNotif1";
            this.panelNotif1.Size = new System.Drawing.Size(808, 29);
            this.panelNotif1.TabIndex = 11;
            this.panelNotif1.Visible = false;
            // 
            // labelNotif1
            // 
            this.labelNotif1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelNotif1.AutoSize = true;
            this.labelNotif1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNotif1.ForeColor = System.Drawing.SystemColors.Info;
            this.labelNotif1.Location = new System.Drawing.Point(45, 6);
            this.labelNotif1.Name = "labelNotif1";
            this.labelNotif1.Size = new System.Drawing.Size(43, 17);
            this.labelNotif1.TabIndex = 1;
            this.labelNotif1.Text = "label3";
            // 
            // iconNotif1
            // 
            this.iconNotif1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(241)))), ((int)(((byte)(227)))));
            this.iconNotif1.ForeColor = System.Drawing.SystemColors.Info;
            this.iconNotif1.IconChar = FontAwesome.Sharp.IconChar.Bell;
            this.iconNotif1.IconColor = System.Drawing.SystemColors.Info;
            this.iconNotif1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconNotif1.IconSize = 26;
            this.iconNotif1.Location = new System.Drawing.Point(14, 3);
            this.iconNotif1.Name = "iconNotif1";
            this.iconNotif1.Size = new System.Drawing.Size(32, 26);
            this.iconNotif1.TabIndex = 0;
            this.iconNotif1.TabStop = false;
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
            this.btnBack.Location = new System.Drawing.Point(685, 350);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(46, 39);
            this.btnBack.TabIndex = 6;
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
            this.btnAddNew.Location = new System.Drawing.Point(285, 286);
            this.btnAddNew.Name = "btnAddNew";
            this.btnAddNew.Size = new System.Drawing.Size(115, 32);
            this.btnAddNew.TabIndex = 1;
            this.btnAddNew.Text = "Save";
            this.btnAddNew.TextColor = System.Drawing.Color.White;
            this.btnAddNew.UseVisualStyleBackColor = false;
            this.btnAddNew.Click += new System.EventHandler(this.btnAddNew_Click);
            // 
            // tabManage
            // 
            this.tabManage.BackColor = System.Drawing.Color.White;
            this.tabManage.Controls.Add(this.panelNotif2);
            this.tabManage.Controls.Add(this.label2);
            this.tabManage.Controls.Add(this.btnSaveUpdate);
            this.tabManage.Controls.Add(this.btnBack2);
            this.tabManage.Controls.Add(this.btnCancel);
            this.tabManage.Controls.Add(this.btnSave);
            this.tabManage.Controls.Add(this.label1);
            this.tabManage.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabManage.Location = new System.Drawing.Point(4, 26);
            this.tabManage.Name = "tabManage";
            this.tabManage.Padding = new System.Windows.Forms.Padding(3);
            this.tabManage.Size = new System.Drawing.Size(792, 410);
            this.tabManage.TabIndex = 1;
            this.tabManage.Text = "Change Password";
            // 
            // panelNotif2
            // 
            this.panelNotif2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelNotif2.Controls.Add(this.labelNotif2);
            this.panelNotif2.Controls.Add(this.iconNotif2);
            this.panelNotif2.Location = new System.Drawing.Point(-12, 379);
            this.panelNotif2.Name = "panelNotif2";
            this.panelNotif2.Size = new System.Drawing.Size(808, 29);
            this.panelNotif2.TabIndex = 13;
            this.panelNotif2.Visible = false;
            // 
            // labelNotif2
            // 
            this.labelNotif2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelNotif2.AutoSize = true;
            this.labelNotif2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNotif2.ForeColor = System.Drawing.SystemColors.Info;
            this.labelNotif2.Location = new System.Drawing.Point(45, 6);
            this.labelNotif2.Name = "labelNotif2";
            this.labelNotif2.Size = new System.Drawing.Size(43, 17);
            this.labelNotif2.TabIndex = 1;
            this.labelNotif2.Text = "label3";
            // 
            // iconNotif2
            // 
            this.iconNotif2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(241)))), ((int)(((byte)(227)))));
            this.iconNotif2.ForeColor = System.Drawing.SystemColors.Info;
            this.iconNotif2.IconChar = FontAwesome.Sharp.IconChar.Bell;
            this.iconNotif2.IconColor = System.Drawing.SystemColors.Info;
            this.iconNotif2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconNotif2.IconSize = 26;
            this.iconNotif2.Location = new System.Drawing.Point(14, 3);
            this.iconNotif2.Name = "iconNotif2";
            this.iconNotif2.Size = new System.Drawing.Size(32, 26);
            this.iconNotif2.TabIndex = 0;
            this.iconNotif2.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(210, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Brand ID";
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
            this.btnSaveUpdate.Location = new System.Drawing.Point(343, 238);
            this.btnSaveUpdate.Name = "btnSaveUpdate";
            this.btnSaveUpdate.Size = new System.Drawing.Size(120, 32);
            this.btnSaveUpdate.TabIndex = 10;
            this.btnSaveUpdate.Text = "Update";
            this.btnSaveUpdate.TextColor = System.Drawing.Color.White;
            this.btnSaveUpdate.UseVisualStyleBackColor = false;
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
            this.btnBack2.Location = new System.Drawing.Point(729, 363);
            this.btnBack2.Name = "btnBack2";
            this.btnBack2.Size = new System.Drawing.Size(46, 39);
            this.btnBack2.TabIndex = 9;
            this.btnBack2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnBack2.UseVisualStyleBackColor = true;
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
            this.btnCancel.Location = new System.Drawing.Point(472, 238);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 32);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextColor = System.Drawing.Color.White;
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnSave.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnSave.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnSave.BorderRadius = 5;
            this.btnSave.BorderSize = 0;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(213, 238);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 32);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(210, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Brand Name";
            // 
            // tabDeleteUser
            // 
            this.tabDeleteUser.Location = new System.Drawing.Point(4, 26);
            this.tabDeleteUser.Name = "tabDeleteUser";
            this.tabDeleteUser.Padding = new System.Windows.Forms.Padding(3);
            this.tabDeleteUser.Size = new System.Drawing.Size(792, 410);
            this.tabDeleteUser.TabIndex = 2;
            this.tabDeleteUser.Text = "Delete User";
            this.tabDeleteUser.UseVisualStyleBackColor = true;
            // 
            // frmAccounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.panel1);
            this.Name = "frmAccounts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmAccounts_Load);
            this.tabControl.ResumeLayout(false);
            this.tabCreateUser.ResumeLayout(false);
            this.tabCreateUser.PerformLayout();
            this.panelNotif1.ResumeLayout(false);
            this.panelNotif1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconNotif1)).EndInit();
            this.tabManage.ResumeLayout(false);
            this.tabManage.PerformLayout();
            this.panelNotif2.ResumeLayout(false);
            this.panelNotif2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.iconNotif2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabCreateUser;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtConfirmPw;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbRole;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtFname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUname;
        private System.Windows.Forms.Panel panelNotif1;
        private System.Windows.Forms.Label labelNotif1;
        private FontAwesome.Sharp.IconPictureBox iconNotif1;
        private RJCodeAdvance.RJControls.RJButton btnUpdate;
        private FontAwesome.Sharp.IconButton btnBack;
        private RJCodeAdvance.RJControls.RJButton btnAddNew;
        private System.Windows.Forms.TabPage tabManage;
        private System.Windows.Forms.Panel panelNotif2;
        private System.Windows.Forms.Label labelNotif2;
        private FontAwesome.Sharp.IconPictureBox iconNotif2;
        private System.Windows.Forms.Label label2;
        private RJCodeAdvance.RJControls.RJButton btnSaveUpdate;
        private FontAwesome.Sharp.IconButton btnBack2;
        private RJCodeAdvance.RJControls.RJButton btnCancel;
        private RJCodeAdvance.RJControls.RJButton btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabDeleteUser;
        private System.Windows.Forms.Timer timer1;
    }
}
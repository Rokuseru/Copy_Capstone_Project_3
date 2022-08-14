
namespace CapstoneProject_3
{
    partial class frmInventoryCount
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelTitleBar = new System.Windows.Forms.Panel();
            this.btnExit = new FontAwesome.Sharp.IconButton();
            this.btnMaximize = new FontAwesome.Sharp.IconButton();
            this.btnMinimizeWindow = new FontAwesome.Sharp.IconButton();
            this.lblCurrentChildForm = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCompare = new RJCodeAdvance.RJControls.RJButton();
            this.dataGridViewStore = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSystemItems = new System.Windows.Forms.Label();
            this.lblStoreItems = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panelTitleBar.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTitleBar
            // 
            this.panelTitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.panelTitleBar.Controls.Add(this.btnExit);
            this.panelTitleBar.Controls.Add(this.btnMaximize);
            this.panelTitleBar.Controls.Add(this.btnMinimizeWindow);
            this.panelTitleBar.Controls.Add(this.lblCurrentChildForm);
            this.panelTitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitleBar.Location = new System.Drawing.Point(0, 0);
            this.panelTitleBar.Margin = new System.Windows.Forms.Padding(4);
            this.panelTitleBar.Name = "panelTitleBar";
            this.panelTitleBar.Size = new System.Drawing.Size(743, 37);
            this.panelTitleBar.TabIndex = 2;
            this.panelTitleBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelTitleBar_MouseDown);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(241)))), ((int)(((byte)(227)))));
            this.btnExit.IconChar = FontAwesome.Sharp.IconChar.WindowClose;
            this.btnExit.IconColor = System.Drawing.Color.White;
            this.btnExit.IconFont = FontAwesome.Sharp.IconFont.Regular;
            this.btnExit.IconSize = 20;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnExit.Location = new System.Drawing.Point(690, 0);
            this.btnExit.Margin = new System.Windows.Forms.Padding(4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(53, 29);
            this.btnExit.TabIndex = 6;
            this.btnExit.Tag = "";
            this.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnMaximize
            // 
            this.btnMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMaximize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnMaximize.FlatAppearance.BorderSize = 0;
            this.btnMaximize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMaximize.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMaximize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.btnMaximize.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            this.btnMaximize.IconColor = System.Drawing.Color.White;
            this.btnMaximize.IconFont = FontAwesome.Sharp.IconFont.Regular;
            this.btnMaximize.IconSize = 20;
            this.btnMaximize.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMaximize.Location = new System.Drawing.Point(638, 0);
            this.btnMaximize.Margin = new System.Windows.Forms.Padding(4);
            this.btnMaximize.Name = "btnMaximize";
            this.btnMaximize.Size = new System.Drawing.Size(53, 29);
            this.btnMaximize.TabIndex = 5;
            this.btnMaximize.Tag = "";
            this.btnMaximize.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMaximize.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMaximize.UseVisualStyleBackColor = false;
            // 
            // btnMinimizeWindow
            // 
            this.btnMinimizeWindow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMinimizeWindow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnMinimizeWindow.FlatAppearance.BorderSize = 0;
            this.btnMinimizeWindow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimizeWindow.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMinimizeWindow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(218)))), ((int)(((byte)(226)))));
            this.btnMinimizeWindow.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            this.btnMinimizeWindow.IconColor = System.Drawing.Color.White;
            this.btnMinimizeWindow.IconFont = FontAwesome.Sharp.IconFont.Regular;
            this.btnMinimizeWindow.IconSize = 20;
            this.btnMinimizeWindow.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnMinimizeWindow.Location = new System.Drawing.Point(589, 0);
            this.btnMinimizeWindow.Margin = new System.Windows.Forms.Padding(4);
            this.btnMinimizeWindow.Name = "btnMinimizeWindow";
            this.btnMinimizeWindow.Size = new System.Drawing.Size(53, 29);
            this.btnMinimizeWindow.TabIndex = 4;
            this.btnMinimizeWindow.Tag = "";
            this.btnMinimizeWindow.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnMinimizeWindow.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMinimizeWindow.UseVisualStyleBackColor = false;
            // 
            // lblCurrentChildForm
            // 
            this.lblCurrentChildForm.AutoSize = true;
            this.lblCurrentChildForm.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentChildForm.ForeColor = System.Drawing.Color.White;
            this.lblCurrentChildForm.Location = new System.Drawing.Point(4, 8);
            this.lblCurrentChildForm.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrentChildForm.Name = "lblCurrentChildForm";
            this.lblCurrentChildForm.Size = new System.Drawing.Size(129, 21);
            this.lblCurrentChildForm.TabIndex = 0;
            this.lblCurrentChildForm.Text = "Inventory Count";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblStoreItems);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lblSystemItems);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnCompare);
            this.panel1.Controls.Add(this.dataGridViewStore);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dataGridView);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 37);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(8);
            this.panel1.Size = new System.Drawing.Size(743, 482);
            this.panel1.TabIndex = 3;
            // 
            // btnCompare
            // 
            this.btnCompare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCompare.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnCompare.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnCompare.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(101)))), ((int)(((byte)(192)))));
            this.btnCompare.BorderRadius = 5;
            this.btnCompare.BorderSize = 0;
            this.btnCompare.FlatAppearance.BorderSize = 0;
            this.btnCompare.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompare.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompare.ForeColor = System.Drawing.Color.White;
            this.btnCompare.Location = new System.Drawing.Point(634, 436);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(97, 30);
            this.btnCompare.TabIndex = 53;
            this.btnCompare.Text = "Compare";
            this.btnCompare.TextColor = System.Drawing.Color.White;
            this.btnCompare.UseVisualStyleBackColor = false;
            this.btnCompare.Click += new System.EventHandler(this.btnCompare_Click);
            // 
            // dataGridViewStore
            // 
            this.dataGridViewStore.AllowUserToAddRows = false;
            this.dataGridViewStore.AllowUserToDeleteRows = false;
            this.dataGridViewStore.AllowUserToResizeColumns = false;
            this.dataGridViewStore.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(239)))), ((int)(((byte)(249)))));
            this.dataGridViewStore.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewStore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewStore.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewStore.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(57)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(57)))), ((int)(((byte)(82)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewStore.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewStore.ColumnHeadersHeight = 40;
            this.dataGridViewStore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewStore.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.quantity});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewStore.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewStore.EnableHeadersVisualStyles = false;
            this.dataGridViewStore.GridColor = System.Drawing.Color.Black;
            this.dataGridViewStore.Location = new System.Drawing.Point(7, 232);
            this.dataGridViewStore.Name = "dataGridViewStore";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(151)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(151)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewStore.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewStore.RowHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridViewStore.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewStore.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dataGridViewStore.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStore.Size = new System.Drawing.Size(724, 181);
            this.dataGridViewStore.TabIndex = 41;
            this.dataGridViewStore.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStore_CellValueChanged);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.HeaderText = "#";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 39;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.HeaderText = "id";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Visible = false;
            this.dataGridViewTextBoxColumn2.Width = 44;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn3.HeaderText = "Desciption";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // quantity
            // 
            this.quantity.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.quantity.DefaultCellStyle = dataGridViewCellStyle3;
            this.quantity.HeaderText = "QTY";
            this.quantity.Name = "quantity";
            this.quantity.Width = 55;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 212);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 17);
            this.label2.TabIndex = 40;
            this.label2.Text = "Current Item(s) In the Store";
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(239)))), ((int)(((byte)(249)))));
            this.dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
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
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column3,
            this.pid,
            this.desc,
            this.qty});
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView.EnableHeadersVisualStyles = false;
            this.dataGridView.GridColor = System.Drawing.Color.Black;
            this.dataGridView.Location = new System.Drawing.Point(8, 28);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(151)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(151)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridView.RowHeadersVisible = false;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(724, 181);
            this.dataGridView.TabIndex = 39;
            // 
            // Column3
            // 
            this.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column3.HeaderText = "#";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 39;
            // 
            // pid
            // 
            this.pid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.pid.HeaderText = "id";
            this.pid.Name = "pid";
            this.pid.ReadOnly = true;
            this.pid.Visible = false;
            this.pid.Width = 44;
            // 
            // desc
            // 
            this.desc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.desc.HeaderText = "Desciption";
            this.desc.Name = "desc";
            this.desc.ReadOnly = true;
            // 
            // qty
            // 
            this.qty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.qty.HeaderText = "QTY";
            this.qty.Name = "qty";
            this.qty.ReadOnly = true;
            this.qty.Width = 55;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(188, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Current Item(s) In the System";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 418);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(174, 17);
            this.label3.TabIndex = 54;
            this.label3.Text = "Total Item(s) In the System:";
            // 
            // lblSystemItems
            // 
            this.lblSystemItems.AutoSize = true;
            this.lblSystemItems.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSystemItems.Location = new System.Drawing.Point(184, 416);
            this.lblSystemItems.Name = "lblSystemItems";
            this.lblSystemItems.Size = new System.Drawing.Size(37, 20);
            this.lblSystemItems.TabIndex = 55;
            this.lblSystemItems.Text = "0.00";
            // 
            // lblStoreItems
            // 
            this.lblStoreItems.AutoSize = true;
            this.lblStoreItems.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStoreItems.Location = new System.Drawing.Point(184, 436);
            this.lblStoreItems.Name = "lblStoreItems";
            this.lblStoreItems.Size = new System.Drawing.Size(37, 20);
            this.lblStoreItems.TabIndex = 57;
            this.lblStoreItems.Text = "0.00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 438);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(162, 17);
            this.label6.TabIndex = 56;
            this.label6.Text = "Total Item(s) In the Store:";
            // 
            // frmInventoryCount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(743, 519);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelTitleBar);
            this.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmInventoryCount";
            this.Text = "frmInventoryCount";
            this.panelTitleBar.ResumeLayout(false);
            this.panelTitleBar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTitleBar;
        private FontAwesome.Sharp.IconButton btnExit;
        private FontAwesome.Sharp.IconButton btnMaximize;
        private FontAwesome.Sharp.IconButton btnMinimizeWindow;
        private System.Windows.Forms.Label lblCurrentChildForm;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridView dataGridViewStore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn pid;
        private System.Windows.Forms.DataGridViewTextBoxColumn desc;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private RJCodeAdvance.RJControls.RJButton btnCompare;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantity;
        private System.Windows.Forms.Label lblStoreItems;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblSystemItems;
        private System.Windows.Forms.Label label3;
    }
}
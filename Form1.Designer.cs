namespace WindowsErrorChecker
{
    partial class Form1
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
            this.Title = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtcpu = new System.Windows.Forms.TextBox();
            this.txtgpu = new System.Windows.Forms.TextBox();
            this.txtram = new System.Windows.Forms.TextBox();
            this.txtdisk = new System.Windows.Forms.TextBox();
            this.loading = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.CPU = new System.Windows.Forms.Button();
            this.GPU = new System.Windows.Forms.Button();
            this.RAM = new System.Windows.Forms.Button();
            this.DISK = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.linkLabel4 = new System.Windows.Forms.LinkLabel();
            this.linkLabel5 = new System.Windows.Forms.LinkLabel();
            this.linkLabel6 = new System.Windows.Forms.LinkLabel();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Title
            // 
            this.Title.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Title.AutoSize = true;
            this.Title.BackColor = System.Drawing.Color.Transparent;
            this.Title.Font = new System.Drawing.Font("Sitka Display", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.ForeColor = System.Drawing.Color.White;
            this.Title.Location = new System.Drawing.Point(106, 9);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(345, 47);
            this.Title.TabIndex = 6;
            this.Title.Text = "Windows Error Checker";
            this.Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(36)))), ((int)(((byte)(44)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Sitka Text", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(231, 347);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 40);
            this.button1.TabIndex = 7;
            this.button1.Text = "SCAN";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.button1_MouseDown);
            // 
            // txtcpu
            // 
            this.txtcpu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtcpu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(40)))), ((int)(((byte)(49)))));
            this.txtcpu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtcpu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtcpu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtcpu.Location = new System.Drawing.Point(1, 120);
            this.txtcpu.Multiline = true;
            this.txtcpu.Name = "txtcpu";
            this.txtcpu.ReadOnly = true;
            this.txtcpu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtcpu.Size = new System.Drawing.Size(560, 205);
            this.txtcpu.TabIndex = 9;
            // 
            // txtgpu
            // 
            this.txtgpu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtgpu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(40)))), ((int)(((byte)(49)))));
            this.txtgpu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtgpu.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtgpu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtgpu.Location = new System.Drawing.Point(1, 120);
            this.txtgpu.Multiline = true;
            this.txtgpu.Name = "txtgpu";
            this.txtgpu.ReadOnly = true;
            this.txtgpu.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtgpu.Size = new System.Drawing.Size(560, 205);
            this.txtgpu.TabIndex = 10;
            // 
            // txtram
            // 
            this.txtram.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtram.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(40)))), ((int)(((byte)(49)))));
            this.txtram.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtram.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtram.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtram.Location = new System.Drawing.Point(1, 120);
            this.txtram.Multiline = true;
            this.txtram.Name = "txtram";
            this.txtram.ReadOnly = true;
            this.txtram.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtram.Size = new System.Drawing.Size(560, 205);
            this.txtram.TabIndex = 11;
            // 
            // txtdisk
            // 
            this.txtdisk.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtdisk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(40)))), ((int)(((byte)(49)))));
            this.txtdisk.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtdisk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtdisk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtdisk.Location = new System.Drawing.Point(1, 120);
            this.txtdisk.Multiline = true;
            this.txtdisk.Name = "txtdisk";
            this.txtdisk.ReadOnly = true;
            this.txtdisk.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtdisk.Size = new System.Drawing.Size(560, 205);
            this.txtdisk.TabIndex = 12;
            // 
            // loading
            // 
            this.loading.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.loading.AutoSize = true;
            this.loading.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loading.ForeColor = System.Drawing.Color.White;
            this.loading.Location = new System.Drawing.Point(451, 369);
            this.loading.Name = "loading";
            this.loading.Size = new System.Drawing.Size(107, 18);
            this.loading.TabIndex = 9;
            this.loading.Text = "Loading........";
            this.loading.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.CPU, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.GPU, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.RAM, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.DISK, 3, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 76);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(560, 41);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // CPU
            // 
            this.CPU.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(70)))));
            this.CPU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CPU.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CPU.Font = new System.Drawing.Font("Sitka Text", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CPU.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.CPU.Location = new System.Drawing.Point(3, 3);
            this.CPU.Name = "CPU";
            this.CPU.Size = new System.Drawing.Size(134, 35);
            this.CPU.TabIndex = 14;
            this.CPU.Text = "CPU";
            this.CPU.UseVisualStyleBackColor = false;
            this.CPU.Click += new System.EventHandler(this.CPU_Click);
            this.CPU.Leave += new System.EventHandler(this.CPU_Leave);
            // 
            // GPU
            // 
            this.GPU.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(70)))));
            this.GPU.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GPU.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.GPU.Font = new System.Drawing.Font("Sitka Text", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GPU.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.GPU.Location = new System.Drawing.Point(143, 3);
            this.GPU.Name = "GPU";
            this.GPU.Size = new System.Drawing.Size(134, 35);
            this.GPU.TabIndex = 15;
            this.GPU.Text = "GPU";
            this.GPU.UseVisualStyleBackColor = false;
            this.GPU.Click += new System.EventHandler(this.GPU_Click);
            this.GPU.Leave += new System.EventHandler(this.GPU_Leave);
            // 
            // RAM
            // 
            this.RAM.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(70)))));
            this.RAM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RAM.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RAM.Font = new System.Drawing.Font("Sitka Text", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RAM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.RAM.Location = new System.Drawing.Point(283, 3);
            this.RAM.Name = "RAM";
            this.RAM.Size = new System.Drawing.Size(134, 35);
            this.RAM.TabIndex = 16;
            this.RAM.Text = "RAM";
            this.RAM.UseVisualStyleBackColor = false;
            this.RAM.Click += new System.EventHandler(this.RAM_Click);
            this.RAM.Leave += new System.EventHandler(this.RAM_Leave);
            // 
            // DISK
            // 
            this.DISK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(70)))));
            this.DISK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DISK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.DISK.Font = new System.Drawing.Font("Sitka Text", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DISK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.DISK.Location = new System.Drawing.Point(423, 3);
            this.DISK.Name = "DISK";
            this.DISK.Size = new System.Drawing.Size(134, 35);
            this.DISK.TabIndex = 17;
            this.DISK.Text = "DISK";
            this.DISK.UseVisualStyleBackColor = false;
            this.DISK.Click += new System.EventHandler(this.DISK_Click);
            this.DISK.Leave += new System.EventHandler(this.DISK_Leave);
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.linkLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.linkLabel1.Font = new System.Drawing.Font("Segoe MDL2 Assets", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.ForeColor = System.Drawing.Color.Red;
            this.linkLabel1.LinkArea = new System.Windows.Forms.LinkArea(0, 2);
            this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel1.LinkColor = System.Drawing.Color.Red;
            this.linkLabel1.Location = new System.Drawing.Point(89, 0);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(15, 13);
            this.linkLabel1.TabIndex = 14;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "✕\n";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.Red;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.linkLabel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel2.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.linkLabel2.Font = new System.Drawing.Font("Segoe MDL2 Assets", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.ForeColor = System.Drawing.Color.Gold;
            this.linkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel2.LinkColor = System.Drawing.Color.Gainsboro;
            this.linkLabel2.Location = new System.Drawing.Point(61, 0);
            this.linkLabel2.Margin = new System.Windows.Forms.Padding(0);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(16, 13);
            this.linkLabel2.TabIndex = 15;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "☐";
            this.linkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabel2.VisitedLinkColor = System.Drawing.Color.Red;
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // linkLabel3
            // 
            this.linkLabel3.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.linkLabel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel3.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.linkLabel3.Font = new System.Drawing.Font("Segoe MDL2 Assets", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel3.ForeColor = System.Drawing.Color.Red;
            this.linkLabel3.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel3.LinkColor = System.Drawing.Color.Gainsboro;
            this.linkLabel3.Location = new System.Drawing.Point(32, 0);
            this.linkLabel3.Margin = new System.Windows.Forms.Padding(0);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(17, 13);
            this.linkLabel3.TabIndex = 16;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "—";
            this.linkLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabel3.VisitedLinkColor = System.Drawing.Color.Red;
            this.linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel3_LinkClicked);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.linkLabel5);
            this.flowLayoutPanel1.Controls.Add(this.linkLabel1);
            this.flowLayoutPanel1.Controls.Add(this.linkLabel6);
            this.flowLayoutPanel1.Controls.Add(this.linkLabel2);
            this.flowLayoutPanel1.Controls.Add(this.linkLabel4);
            this.flowLayoutPanel1.Controls.Add(this.linkLabel3);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(445, 9);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.flowLayoutPanel1.Size = new System.Drawing.Size(116, 31);
            this.flowLayoutPanel1.TabIndex = 17;
            // 
            // linkLabel4
            // 
            this.linkLabel4.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.linkLabel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel4.AutoSize = true;
            this.linkLabel4.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel4.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.linkLabel4.Font = new System.Drawing.Font("Segoe MDL2 Assets", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel4.ForeColor = System.Drawing.Color.Red;
            this.linkLabel4.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel4.LinkColor = System.Drawing.Color.Gainsboro;
            this.linkLabel4.Location = new System.Drawing.Point(49, 0);
            this.linkLabel4.Margin = new System.Windows.Forms.Padding(0);
            this.linkLabel4.Name = "linkLabel4";
            this.linkLabel4.Size = new System.Drawing.Size(12, 13);
            this.linkLabel4.TabIndex = 17;
            this.linkLabel4.TabStop = true;
            this.linkLabel4.Text = " ";
            this.linkLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabel4.VisitedLinkColor = System.Drawing.Color.Red;
            // 
            // linkLabel5
            // 
            this.linkLabel5.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.linkLabel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel5.AutoSize = true;
            this.linkLabel5.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel5.Font = new System.Drawing.Font("Segoe MDL2 Assets", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel5.ForeColor = System.Drawing.Color.Red;
            this.linkLabel5.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel5.LinkColor = System.Drawing.Color.Gainsboro;
            this.linkLabel5.Location = new System.Drawing.Point(104, 0);
            this.linkLabel5.Margin = new System.Windows.Forms.Padding(0);
            this.linkLabel5.Name = "linkLabel5";
            this.linkLabel5.Size = new System.Drawing.Size(12, 13);
            this.linkLabel5.TabIndex = 18;
            this.linkLabel5.TabStop = true;
            this.linkLabel5.Text = " ";
            this.linkLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabel5.VisitedLinkColor = System.Drawing.Color.Red;
            // 
            // linkLabel6
            // 
            this.linkLabel6.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(174)))), ((int)(((byte)(219)))));
            this.linkLabel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabel6.AutoSize = true;
            this.linkLabel6.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel6.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.linkLabel6.Font = new System.Drawing.Font("Segoe MDL2 Assets", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel6.ForeColor = System.Drawing.Color.Red;
            this.linkLabel6.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.linkLabel6.LinkColor = System.Drawing.Color.Gainsboro;
            this.linkLabel6.Location = new System.Drawing.Point(77, 0);
            this.linkLabel6.Margin = new System.Windows.Forms.Padding(0);
            this.linkLabel6.Name = "linkLabel6";
            this.linkLabel6.Size = new System.Drawing.Size(12, 13);
            this.linkLabel6.TabIndex = 19;
            this.linkLabel6.TabStop = true;
            this.linkLabel6.Text = " ";
            this.linkLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkLabel6.VisitedLinkColor = System.Drawing.Color.Red;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(39)))));
            this.ClientSize = new System.Drawing.Size(561, 408);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.txtcpu);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.loading);
            this.Controls.Add(this.txtdisk);
            this.Controls.Add(this.txtram);
            this.Controls.Add(this.txtgpu);
            this.Controls.Add(this.Title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(400, 300);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtcpu;
        private System.Windows.Forms.TextBox txtgpu;
        private System.Windows.Forms.TextBox txtram;
        private System.Windows.Forms.TextBox txtdisk;
        private System.Windows.Forms.Label loading;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button CPU;
        private System.Windows.Forms.Button GPU;
        private System.Windows.Forms.Button RAM;
        private System.Windows.Forms.Button DISK;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.LinkLabel linkLabel4;
        private System.Windows.Forms.LinkLabel linkLabel5;
        private System.Windows.Forms.LinkLabel linkLabel6;
    }
}


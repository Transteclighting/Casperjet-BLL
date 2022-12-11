namespace CJ.Win.CAC
{
    partial class frmCACProjects
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCACProjects));
            this.label1 = new System.Windows.Forms.Label();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.colTotalAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProjectName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCustomerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwCACProject = new System.Windows.Forms.ListView();
            this.colCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEndDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTotalComplete = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInvAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSalesPerson = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTechPerson = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRemarks = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnGo = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCollectionSchedule = new System.Windows.Forms.Button();
            this.btnCollection = new System.Windows.Forms.Button();
            this.btnProjectTask = new System.Windows.Forms.Button();
            this.btnProjectProgress = new System.Windows.Forms.Button();
            this.btnInvoice = new System.Windows.Forms.Button();
            this.btnPending = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.btnHandOver = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.btnOtherSales = new System.Windows.Forms.Button();
            this.btnPayment = new System.Windows.Forms.Button();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ctlEmployee2 = new CJ.Win.ctlEmployee();
            this.ctlEmployee1 = new CJ.Win.ctlEmployee();
            this.ctlCustomer1 = new CJ.Win.Control.ctlCustomer();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(226, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "To Date:";
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkAll.Location = new System.Drawing.Point(22, 0);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(182, 19);
            this.chkAll.TabIndex = 0;
            this.chkAll.Text = "Enable/Disable Data Range";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.chkAll);
            this.groupBox2.Controls.Add(this.dtFromDate);
            this.groupBox2.Controls.Add(this.dtToDate);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.groupBox2.Location = new System.Drawing.Point(25, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(430, 51);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "    ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "From Date:";
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(90, 22);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(130, 20);
            this.dtFromDate.TabIndex = 2;
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(293, 22);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(130, 20);
            this.dtToDate.TabIndex = 4;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label10.Location = new System.Drawing.Point(551, 69);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 15);
            this.label10.TabIndex = 1;
            this.label10.Text = "Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(598, 65);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(157, 23);
            this.cmbStatus.TabIndex = 2;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnUpdate.Location = new System.Drawing.Point(807, 219);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(132, 25);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "Edit";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label5.Location = new System.Drawing.Point(26, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 15);
            this.label5.TabIndex = 3;
            this.label5.Text = "Customer:";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Enabled = false;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnAdd.Location = new System.Drawing.Point(805, 189);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(134, 25);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // colTotalAmount
            // 
            this.colTotalAmount.Text = "Project Total Value";
            this.colTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colTotalAmount.Width = 120;
            // 
            // colDate
            // 
            this.colDate.Text = "Start Date";
            this.colDate.Width = 100;
            // 
            // colProjectName
            // 
            this.colProjectName.Text = "Project Name";
            this.colProjectName.Width = 150;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Text = "Customer Name";
            this.colCustomerName.Width = 150;
            // 
            // lvwCACProject
            // 
            this.lvwCACProject.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwCACProject.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCode,
            this.colProjectName,
            this.colCustomerName,
            this.colDate,
            this.colEndDate,
            this.colTotalAmount,
            this.colTotalComplete,
            this.colInvAmount,
            this.colStatus,
            this.colSalesPerson,
            this.colTechPerson,
            this.colRemarks});
            this.lvwCACProject.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lvwCACProject.FullRowSelect = true;
            this.lvwCACProject.GridLines = true;
            this.lvwCACProject.HideSelection = false;
            this.lvwCACProject.Location = new System.Drawing.Point(14, 188);
            this.lvwCACProject.MultiSelect = false;
            this.lvwCACProject.Name = "lvwCACProject";
            this.lvwCACProject.Size = new System.Drawing.Size(785, 422);
            this.lvwCACProject.TabIndex = 6;
            this.lvwCACProject.UseCompatibleStateImageBehavior = false;
            this.lvwCACProject.View = System.Windows.Forms.View.Details;
            // 
            // colCode
            // 
            this.colCode.Text = "Project Code";
            this.colCode.Width = 120;
            // 
            // colEndDate
            // 
            this.colEndDate.Text = "End Date";
            this.colEndDate.Width = 100;
            // 
            // colTotalComplete
            // 
            this.colTotalComplete.Text = "Task Complete Value";
            this.colTotalComplete.Width = 120;
            // 
            // colInvAmount
            // 
            this.colInvAmount.Text = "Total Inv Amount";
            this.colInvAmount.Width = 120;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 100;
            // 
            // colSalesPerson
            // 
            this.colSalesPerson.Text = "Sales Person";
            this.colSalesPerson.Width = 150;
            // 
            // colTechPerson
            // 
            this.colTechPerson.Text = "Tech Person";
            this.colTechPerson.Width = 150;
            // 
            // colRemarks
            // 
            this.colRemarks.Text = "Remarks";
            this.colRemarks.Width = 250;
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnGo.Location = new System.Drawing.Point(701, 154);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(98, 28);
            this.btnGo.TabIndex = 5;
            this.btnGo.Text = "Get Data";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnClose.Location = new System.Drawing.Point(807, 585);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(132, 25);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCollectionSchedule
            // 
            this.btnCollectionSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCollectionSchedule.Enabled = false;
            this.btnCollectionSchedule.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnCollectionSchedule.Location = new System.Drawing.Point(807, 374);
            this.btnCollectionSchedule.Name = "btnCollectionSchedule";
            this.btnCollectionSchedule.Size = new System.Drawing.Size(132, 25);
            this.btnCollectionSchedule.TabIndex = 11;
            this.btnCollectionSchedule.Text = "Collection Schedule";
            this.btnCollectionSchedule.UseVisualStyleBackColor = true;
            this.btnCollectionSchedule.Click += new System.EventHandler(this.btnCollectionSchedule_Click);
            // 
            // btnCollection
            // 
            this.btnCollection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCollection.Enabled = false;
            this.btnCollection.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnCollection.Location = new System.Drawing.Point(807, 405);
            this.btnCollection.Name = "btnCollection";
            this.btnCollection.Size = new System.Drawing.Size(132, 25);
            this.btnCollection.TabIndex = 12;
            this.btnCollection.Text = "Collection";
            this.btnCollection.UseVisualStyleBackColor = true;
            this.btnCollection.Click += new System.EventHandler(this.btnCollection_Click);
            // 
            // btnProjectTask
            // 
            this.btnProjectTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProjectTask.Enabled = false;
            this.btnProjectTask.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnProjectTask.Location = new System.Drawing.Point(807, 250);
            this.btnProjectTask.Name = "btnProjectTask";
            this.btnProjectTask.Size = new System.Drawing.Size(132, 25);
            this.btnProjectTask.TabIndex = 9;
            this.btnProjectTask.Text = "Project Task";
            this.btnProjectTask.UseVisualStyleBackColor = true;
            this.btnProjectTask.Click += new System.EventHandler(this.btnProjectTask_Click);
            // 
            // btnProjectProgress
            // 
            this.btnProjectProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProjectProgress.Enabled = false;
            this.btnProjectProgress.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnProjectProgress.Location = new System.Drawing.Point(807, 281);
            this.btnProjectProgress.Name = "btnProjectProgress";
            this.btnProjectProgress.Size = new System.Drawing.Size(132, 25);
            this.btnProjectProgress.TabIndex = 10;
            this.btnProjectProgress.Text = "Project Progress";
            this.btnProjectProgress.UseVisualStyleBackColor = true;
            this.btnProjectProgress.Click += new System.EventHandler(this.btnProjectProgress_Click);
            // 
            // btnInvoice
            // 
            this.btnInvoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInvoice.Enabled = false;
            this.btnInvoice.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnInvoice.Location = new System.Drawing.Point(807, 312);
            this.btnInvoice.Name = "btnInvoice";
            this.btnInvoice.Size = new System.Drawing.Size(132, 25);
            this.btnInvoice.TabIndex = 13;
            this.btnInvoice.Text = "Invoice";
            this.btnInvoice.UseVisualStyleBackColor = true;
            this.btnInvoice.Click += new System.EventHandler(this.btnInvoice_Click);
            // 
            // btnPending
            // 
            this.btnPending.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPending.Enabled = false;
            this.btnPending.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnPending.Location = new System.Drawing.Point(807, 467);
            this.btnPending.Name = "btnPending";
            this.btnPending.Size = new System.Drawing.Size(132, 25);
            this.btnPending.TabIndex = 14;
            this.btnPending.Text = "Pending";
            this.btnPending.UseVisualStyleBackColor = true;
            this.btnPending.Click += new System.EventHandler(this.btnPending_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Enabled = false;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnCancel.Location = new System.Drawing.Point(807, 498);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(132, 25);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.LightCoral;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(190, 613);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(53, 15);
            this.label12.TabIndex = 51;
            this.label12.Text = "Pending";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.SandyBrown;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(63, 613);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 15);
            this.label3.TabIndex = 49;
            this.label3.Text = "Running";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.LightGreen;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(14, 613);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 15);
            this.label6.TabIndex = 48;
            this.label6.Text = "Create";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.White;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(124, 613);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 15);
            this.label11.TabIndex = 50;
            this.label11.Text = "Complete";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Gray;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(250, 613);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 52;
            this.label2.Text = "Cancel";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(96, 65);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(149, 23);
            this.txtCode.TabIndex = 54;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft JhengHei UI", 8.25F);
            this.label7.Location = new System.Drawing.Point(17, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 14);
            this.label7.TabIndex = 53;
            this.label7.Text = "Project Code:";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label35.Location = new System.Drawing.Point(15, 159);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(78, 15);
            this.label35.TabIndex = 57;
            this.label35.Text = "Tech Person:";
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label34.Location = new System.Drawing.Point(13, 128);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(80, 15);
            this.label34.TabIndex = 55;
            this.label34.Text = "Sales Person:";
            // 
            // btnHandOver
            // 
            this.btnHandOver.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHandOver.Enabled = false;
            this.btnHandOver.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnHandOver.Location = new System.Drawing.Point(807, 529);
            this.btnHandOver.Name = "btnHandOver";
            this.btnHandOver.Size = new System.Drawing.Size(132, 25);
            this.btnHandOver.TabIndex = 59;
            this.btnHandOver.Text = "HandOver";
            this.btnHandOver.UseVisualStyleBackColor = true;
            this.btnHandOver.Click += new System.EventHandler(this.btnHandOver_Click);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.DarkKhaki;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(301, 613);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 15);
            this.label8.TabIndex = 60;
            this.label8.Text = "Handover";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOtherSales
            // 
            this.btnOtherSales.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOtherSales.Enabled = false;
            this.btnOtherSales.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnOtherSales.Location = new System.Drawing.Point(807, 343);
            this.btnOtherSales.Name = "btnOtherSales";
            this.btnOtherSales.Size = new System.Drawing.Size(132, 25);
            this.btnOtherSales.TabIndex = 61;
            this.btnOtherSales.Text = "Other Sales";
            this.btnOtherSales.UseVisualStyleBackColor = true;
            this.btnOtherSales.Click += new System.EventHandler(this.btnOtherSales_Click);
            // 
            // btnPayment
            // 
            this.btnPayment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPayment.Enabled = false;
            this.btnPayment.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnPayment.Location = new System.Drawing.Point(807, 436);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(132, 25);
            this.btnPayment.TabIndex = 62;
            this.btnPayment.Text = "Payment";
            this.btnPayment.UseVisualStyleBackColor = true;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(330, 65);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(215, 23);
            this.txtProjectName.TabIndex = 64;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft JhengHei UI", 8.25F);
            this.label9.Location = new System.Drawing.Point(251, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(80, 14);
            this.label9.TabIndex = 63;
            this.label9.Text = "Project Name:";
            // 
            // ctlEmployee2
            // 
            this.ctlEmployee2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctlEmployee2.Location = new System.Drawing.Point(96, 157);
            this.ctlEmployee2.Name = "ctlEmployee2";
            this.ctlEmployee2.Size = new System.Drawing.Size(456, 25);
            this.ctlEmployee2.TabIndex = 58;
            // 
            // ctlEmployee1
            // 
            this.ctlEmployee1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctlEmployee1.Location = new System.Drawing.Point(96, 128);
            this.ctlEmployee1.Name = "ctlEmployee1";
            this.ctlEmployee1.Size = new System.Drawing.Size(456, 25);
            this.ctlEmployee1.TabIndex = 56;
            // 
            // ctlCustomer1
            // 
            this.ctlCustomer1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ctlCustomer1.Location = new System.Drawing.Point(96, 97);
            this.ctlCustomer1.Name = "ctlCustomer1";
            this.ctlCustomer1.Size = new System.Drawing.Size(456, 25);
            this.ctlCustomer1.TabIndex = 4;
            // 
            // frmCACProjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 634);
            this.Controls.Add(this.txtProjectName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnPayment);
            this.Controls.Add(this.btnOtherSales);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnHandOver);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.ctlEmployee2);
            this.Controls.Add(this.ctlEmployee1);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPending);
            this.Controls.Add(this.btnInvoice);
            this.Controls.Add(this.ctlCustomer1);
            this.Controls.Add(this.btnProjectProgress);
            this.Controls.Add(this.btnProjectTask);
            this.Controls.Add(this.btnCollection);
            this.Controls.Add(this.btnCollectionSchedule);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lvwCACProject);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCACProjects";
            this.Text = "CAC Projects";
            this.Load += new System.EventHandler(this.frmCACProjects_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ColumnHeader colTotalAmount;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colProjectName;
        private System.Windows.Forms.ColumnHeader colCustomerName;
        private System.Windows.Forms.ListView lvwCACProject;
        private System.Windows.Forms.ColumnHeader colRemarks;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColumnHeader colEndDate;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.Button btnCollectionSchedule;
        private System.Windows.Forms.Button btnCollection;
        private System.Windows.Forms.Button btnProjectTask;
        private System.Windows.Forms.Button btnProjectProgress;
        private Control.ctlCustomer ctlCustomer1;
        private System.Windows.Forms.Button btnInvoice;
        private System.Windows.Forms.Button btnPending;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader colCode;
        private System.Windows.Forms.ColumnHeader colTotalComplete;
        private System.Windows.Forms.ColumnHeader colInvAmount;
        private System.Windows.Forms.ColumnHeader colSalesPerson;
        private System.Windows.Forms.ColumnHeader colTechPerson;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label label34;
        private ctlEmployee ctlEmployee2;
        private ctlEmployee ctlEmployee1;
        private System.Windows.Forms.Button btnHandOver;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnOtherSales;
        private System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.Label label9;
    }
}
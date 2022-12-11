namespace CJ.Win
{
    partial class frmTPBills
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
            this.btnProcess = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctlInterService1 = new CJ.Win.ctlInterService();
            this.btnGet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtBillMonthYear = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.lvwTPBills = new System.Windows.Forms.ListView();
            this.colInterServiceName = new System.Windows.Forms.ColumnHeader();
            this.colBillMonth = new System.Windows.Forms.ColumnHeader();
            this.colBillYear = new System.Windows.Forms.ColumnHeader();
            this.colServiceCharge = new System.Windows.Forms.ColumnHeader();
            this.colInstallationCharge = new System.Windows.Forms.ColumnHeader();
            this.colMaterialCharge = new System.Windows.Forms.ColumnHeader();
            this.colGasCharge = new System.Windows.Forms.ColumnHeader();
            this.colOtherCharge = new System.Windows.Forms.ColumnHeader();
            this.colStatus = new System.Windows.Forms.ColumnHeader();
            this.colCreatedBy = new System.Windows.Forms.ColumnHeader();
            this.colCreateDate = new System.Windows.Forms.ColumnHeader();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess.Location = new System.Drawing.Point(881, 73);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(89, 27);
            this.btnProcess.TabIndex = 5;
            this.btnProcess.Text = "&Process";
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(881, 101);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(89, 27);
            this.btnPrint.TabIndex = 6;
            this.btnPrint.Text = "&Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnView
            // 
            this.btnView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnView.Location = new System.Drawing.Point(881, 129);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(89, 27);
            this.btnView.TabIndex = 7;
            this.btnView.Text = "&View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Location = new System.Drawing.Point(881, 157);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(89, 27);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "&Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(881, 445);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 27);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctlInterService1
            // 
            this.ctlInterService1.Location = new System.Drawing.Point(78, 14);
            this.ctlInterService1.Name = "ctlInterService1";
            this.ctlInterService1.Size = new System.Drawing.Size(438, 25);
            this.ctlInterService1.TabIndex = 1;
            // 
            // btnGet
            // 
            this.btnGet.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnGet.Location = new System.Drawing.Point(535, 33);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(85, 27);
            this.btnGet.TabIndex = 4;
            this.btnGet.Text = "Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inter Service";
            // 
            // dtBillMonthYear
            // 
            this.dtBillMonthYear.CustomFormat = "MMM-yyyy";
            this.dtBillMonthYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtBillMonthYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtBillMonthYear.Location = new System.Drawing.Point(78, 39);
            this.dtBillMonthYear.Name = "dtBillMonthYear";
            this.dtBillMonthYear.ShowUpDown = true;
            this.dtBillMonthYear.Size = new System.Drawing.Size(100, 21);
            this.dtBillMonthYear.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Bill Month";
            // 
            // lvwTPBills
            // 
            this.lvwTPBills.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwTPBills.CheckBoxes = true;
            this.lvwTPBills.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colInterServiceName,
            this.colBillMonth,
            this.colBillYear,
            this.colServiceCharge,
            this.colInstallationCharge,
            this.colMaterialCharge,
            this.colGasCharge,
            this.colOtherCharge,
            this.colStatus,
            this.colCreatedBy,
            this.colCreateDate});
            this.lvwTPBills.GridLines = true;
            this.lvwTPBills.Location = new System.Drawing.Point(11, 73);
            this.lvwTPBills.MultiSelect = false;
            this.lvwTPBills.Name = "lvwTPBills";
            this.lvwTPBills.Size = new System.Drawing.Size(864, 399);
            this.lvwTPBills.TabIndex = 10;
            this.lvwTPBills.UseCompatibleStateImageBehavior = false;
            this.lvwTPBills.View = System.Windows.Forms.View.Details;
            // 
            // colInterServiceName
            // 
            this.colInterServiceName.Text = "      Interservice Name";
            this.colInterServiceName.Width = 143;
            // 
            // colBillMonth
            // 
            this.colBillMonth.Text = "Bill Month";
            this.colBillMonth.Width = 61;
            // 
            // colBillYear
            // 
            this.colBillYear.Text = "Bill Year";
            // 
            // colServiceCharge
            // 
            this.colServiceCharge.Text = "Service Charge";
            this.colServiceCharge.Width = 98;
            // 
            // colInstallationCharge
            // 
            this.colInstallationCharge.Text = "Installation Charge";
            this.colInstallationCharge.Width = 98;
            // 
            // colMaterialCharge
            // 
            this.colMaterialCharge.Text = "Material Charge";
            // 
            // colGasCharge
            // 
            this.colGasCharge.Text = "Gas Charge";
            this.colGasCharge.Width = 85;
            // 
            // colOtherCharge
            // 
            this.colOtherCharge.Text = "Other Charge";
            this.colOtherCharge.Width = 76;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.Text = "Created By";
            // 
            // colCreateDate
            // 
            this.colCreateDate.Text = "Create Date";
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.Location = new System.Drawing.Point(18, 80);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(15, 14);
            this.chkAll.TabIndex = 11;
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // frmTPBills
            // 
            this.AcceptButton = this.btnGet;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnGet;
            this.ClientSize = new System.Drawing.Size(978, 484);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.lvwTPBills);
            this.Controls.Add(this.dtBillMonthYear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.ctlInterService1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnProcess);
            this.Name = "frmTPBills";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TP Bills";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnView;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnClose;
        private ctlInterService ctlInterService1;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtBillMonthYear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lvwTPBills;
        private System.Windows.Forms.ColumnHeader colInterServiceName;
        private System.Windows.Forms.ColumnHeader colBillMonth;
        private System.Windows.Forms.ColumnHeader colBillYear;
        private System.Windows.Forms.ColumnHeader colServiceCharge;
        private System.Windows.Forms.ColumnHeader colInstallationCharge;
        private System.Windows.Forms.ColumnHeader colMaterialCharge;
        private System.Windows.Forms.ColumnHeader colGasCharge;
        private System.Windows.Forms.ColumnHeader colOtherCharge;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ColumnHeader colCreatedBy;
        private System.Windows.Forms.ColumnHeader colCreateDate;
        private System.Windows.Forms.CheckBox chkAll;
    }
}
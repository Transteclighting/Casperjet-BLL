namespace CJ.Win.Admin
{
    partial class frmVehicleOperationsAdmin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVehicleOperationsAdmin));
            this.lblDate = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFrmDate = new System.Windows.Forms.DateTimePicker();
            this.lvwVehicleOperationAdmin = new System.Windows.Forms.ListView();
            this.colTranDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVehicleNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colVehicleName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRegistrationNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBU = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCompany = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTripC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTripS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTripU = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEndReading = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colKMRun = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colInvoiceAmount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnGetdata = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btVichel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVehicleCode = new System.Windows.Forms.TextBox();
            this.txtVehicleDetails = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(43, 16);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(37, 16);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "From";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(243, 13);
            this.dtToDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(115, 23);
            this.dtToDate.TabIndex = 3;
            // 
            // dtFrmDate
            // 
            this.dtFrmDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFrmDate.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFrmDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFrmDate.Location = new System.Drawing.Point(84, 13);
            this.dtFrmDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtFrmDate.Name = "dtFrmDate";
            this.dtFrmDate.Size = new System.Drawing.Size(115, 23);
            this.dtFrmDate.TabIndex = 1;
            // 
            // lvwVehicleOperationAdmin
            // 
            this.lvwVehicleOperationAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwVehicleOperationAdmin.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTranDate,
            this.colVehicleNo,
            this.colVehicleName,
            this.colRegistrationNo,
            this.colBU,
            this.colCompany,
            this.colTripC,
            this.colTripS,
            this.colTripU,
            this.colEndReading,
            this.colKMRun,
            this.colInvoiceAmount});
            this.lvwVehicleOperationAdmin.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwVehicleOperationAdmin.FullRowSelect = true;
            this.lvwVehicleOperationAdmin.GridLines = true;
            this.lvwVehicleOperationAdmin.HideSelection = false;
            this.lvwVehicleOperationAdmin.Location = new System.Drawing.Point(12, 103);
            this.lvwVehicleOperationAdmin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvwVehicleOperationAdmin.MultiSelect = false;
            this.lvwVehicleOperationAdmin.Name = "lvwVehicleOperationAdmin";
            this.lvwVehicleOperationAdmin.Size = new System.Drawing.Size(728, 402);
            this.lvwVehicleOperationAdmin.TabIndex = 11;
            this.lvwVehicleOperationAdmin.UseCompatibleStateImageBehavior = false;
            this.lvwVehicleOperationAdmin.View = System.Windows.Forms.View.Details;
            // 
            // colTranDate
            // 
            this.colTranDate.Text = "Tran Date";
            this.colTranDate.Width = 97;
            // 
            // colVehicleNo
            // 
            this.colVehicleNo.Text = "Vehicle No";
            this.colVehicleNo.Width = 78;
            // 
            // colVehicleName
            // 
            this.colVehicleName.Text = "Vehicle Name";
            this.colVehicleName.Width = 148;
            // 
            // colRegistrationNo
            // 
            this.colRegistrationNo.Text = "RegistrationNo";
            this.colRegistrationNo.Width = 143;
            // 
            // colBU
            // 
            this.colBU.Text = "Business Unit";
            this.colBU.Width = 123;
            // 
            // colCompany
            // 
            this.colCompany.Text = "Company";
            this.colCompany.Width = 75;
            // 
            // colTripC
            // 
            this.colTripC.Text = "TripC";
            this.colTripC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colTripS
            // 
            this.colTripS.Text = "TripS";
            this.colTripS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colTripU
            // 
            this.colTripU.Text = "TripU";
            this.colTripU.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colEndReading
            // 
            this.colEndReading.Text = "End Reading";
            this.colEndReading.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colKMRun
            // 
            this.colKMRun.Text = "KM Run";
            this.colKMRun.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colInvoiceAmount
            // 
            this.colInvoiceAmount.Text = "Invoice Amount";
            this.colInvoiceAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Enabled = false;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(748, 103);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 25);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Enabled = false;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(748, 136);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(85, 25);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click_1);
            // 
            // btnGetdata
            // 
            this.btnGetdata.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetdata.Location = new System.Drawing.Point(408, 70);
            this.btnGetdata.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGetdata.Name = "btnGetdata";
            this.btnGetdata.Size = new System.Drawing.Size(85, 25);
            this.btnGetdata.TabIndex = 10;
            this.btnGetdata.Text = "Get Data";
            this.btnGetdata.UseVisualStyleBackColor = true;
            this.btnGetdata.Click += new System.EventHandler(this.btnGetdata_Click);
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReport.Enabled = false;
            this.btnReport.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReport.Location = new System.Drawing.Point(748, 169);
            this.btnReport.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(85, 25);
            this.btnReport.TabIndex = 14;
            this.btnReport.Text = "Report";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(748, 480);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 25);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btVichel
            // 
            this.btVichel.Location = new System.Drawing.Point(200, 43);
            this.btVichel.Name = "btVichel";
            this.btVichel.Size = new System.Drawing.Size(32, 23);
            this.btVichel.TabIndex = 6;
            this.btVichel.Text = "...";
            this.btVichel.UseVisualStyleBackColor = true;
            this.btVichel.Click += new System.EventHandler(this.btVichel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Vehicle:";
            // 
            // txtVehicleCode
            // 
            this.txtVehicleCode.Location = new System.Drawing.Point(84, 43);
            this.txtVehicleCode.Name = "txtVehicleCode";
            this.txtVehicleCode.Size = new System.Drawing.Size(110, 23);
            this.txtVehicleCode.TabIndex = 5;
            this.txtVehicleCode.TextChanged += new System.EventHandler(this.txtVehicleCode_TextChanged);
            // 
            // txtVehicleDetails
            // 
            this.txtVehicleDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVehicleDetails.Location = new System.Drawing.Point(238, 44);
            this.txtVehicleDetails.Name = "txtVehicleDetails";
            this.txtVehicleDetails.Size = new System.Drawing.Size(255, 21);
            this.txtVehicleDetails.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(216, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "To";
            // 
            // cmbCompany
            // 
            this.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(84, 72);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(155, 24);
            this.cmbCompany.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Company:";
            // 
            // frmVehicleOperationsAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 518);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbCompany);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btVichel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtVehicleCode);
            this.Controls.Add(this.txtVehicleDetails);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnGetdata);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lvwVehicleOperationAdmin);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.dtFrmDate);
            this.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmVehicleOperationsAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vehicle Operations Admin";
            this.Load += new System.EventHandler(this.frmVehicleOperationsAdmin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFrmDate;
        private System.Windows.Forms.ListView lvwVehicleOperationAdmin;
        private System.Windows.Forms.ColumnHeader colTranDate;
        private System.Windows.Forms.ColumnHeader colVehicleNo;
        private System.Windows.Forms.ColumnHeader colRegistrationNo;
        private System.Windows.Forms.ColumnHeader colBU;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnGetdata;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btVichel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVehicleCode;
        private System.Windows.Forms.TextBox txtVehicleDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader colTripC;
        private System.Windows.Forms.ColumnHeader colTripS;
        private System.Windows.Forms.ColumnHeader colTripU;
        private System.Windows.Forms.ColumnHeader colEndReading;
        private System.Windows.Forms.ColumnHeader colKMRun;
        private System.Windows.Forms.ColumnHeader colInvoiceAmount;
        private System.Windows.Forms.ColumnHeader colCompany;
        private System.Windows.Forms.ColumnHeader colVehicleName;
    }
}
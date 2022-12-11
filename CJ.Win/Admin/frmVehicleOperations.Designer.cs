namespace CJ.Win.Admin
{
    partial class frmVehicleOperations
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVehicleOperations));
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btndelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.btnGO = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.btVichel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVehicleCode = new System.Windows.Forms.TextBox();
            this.txtVehicleDetails = new System.Windows.Forms.TextBox();
            this.lvwVehicleOperation = new System.Windows.Forms.ListView();
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
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Font = new System.Drawing.Font("Microsoft JhengHei", 9F);
            this.btnPrint.Location = new System.Drawing.Point(648, 174);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(85, 25);
            this.btnPrint.TabIndex = 14;
            this.btnPrint.Tag = "";
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click_1);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft JhengHei", 9F);
            this.btnClose.Location = new System.Drawing.Point(648, 473);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 25);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btndelete
            // 
            this.btndelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btndelete.Font = new System.Drawing.Font("Microsoft JhengHei", 9F);
            this.btndelete.Location = new System.Drawing.Point(648, 141);
            this.btndelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btndelete.Name = "btndelete";
            this.btndelete.Size = new System.Drawing.Size(85, 25);
            this.btndelete.TabIndex = 13;
            this.btndelete.Tag = "M1.20";
            this.btndelete.Text = "Delete";
            this.btndelete.UseVisualStyleBackColor = true;
            this.btndelete.Click += new System.EventHandler(this.btndelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft JhengHei", 9F);
            this.btnAdd.Location = new System.Drawing.Point(648, 108);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(85, 25);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft JhengHei", 9F);
            this.lblTo.Location = new System.Drawing.Point(233, 18);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(23, 16);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "To";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft JhengHei", 9F);
            this.lblDate.Location = new System.Drawing.Point(38, 18);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(37, 16);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "From";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft JhengHei", 9F);
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(270, 14);
            this.dtToDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(114, 23);
            this.dtToDate.TabIndex = 3;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft JhengHei", 9F);
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(82, 13);
            this.dtFromDate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(120, 23);
            this.dtFromDate.TabIndex = 1;
            // 
            // btnGO
            // 
            this.btnGO.Font = new System.Drawing.Font("Microsoft JhengHei", 9F);
            this.btnGO.Location = new System.Drawing.Point(406, 75);
            this.btnGO.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnGO.Name = "btnGO";
            this.btnGO.Size = new System.Drawing.Size(85, 25);
            this.btnGO.TabIndex = 10;
            this.btnGO.Text = "Get Data";
            this.btnGO.UseVisualStyleBackColor = true;
            this.btnGO.Click += new System.EventHandler(this.btnGO_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Company:";
            // 
            // cmbCompany
            // 
            this.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(82, 72);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(155, 24);
            this.cmbCompany.TabIndex = 9;
            // 
            // btVichel
            // 
            this.btVichel.Location = new System.Drawing.Point(198, 43);
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
            this.label2.Location = new System.Drawing.Point(24, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Vehicle:";
            // 
            // txtVehicleCode
            // 
            this.txtVehicleCode.Location = new System.Drawing.Point(82, 43);
            this.txtVehicleCode.Name = "txtVehicleCode";
            this.txtVehicleCode.Size = new System.Drawing.Size(110, 23);
            this.txtVehicleCode.TabIndex = 5;
            this.txtVehicleCode.TextChanged += new System.EventHandler(this.txtVehicleCode_TextChanged);
            // 
            // txtVehicleDetails
            // 
            this.txtVehicleDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVehicleDetails.Location = new System.Drawing.Point(236, 44);
            this.txtVehicleDetails.Name = "txtVehicleDetails";
            this.txtVehicleDetails.Size = new System.Drawing.Size(255, 21);
            this.txtVehicleDetails.TabIndex = 7;
            // 
            // lvwVehicleOperation
            // 
            this.lvwVehicleOperation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwVehicleOperation.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
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
            this.lvwVehicleOperation.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwVehicleOperation.FullRowSelect = true;
            this.lvwVehicleOperation.GridLines = true;
            this.lvwVehicleOperation.HideSelection = false;
            this.lvwVehicleOperation.Location = new System.Drawing.Point(12, 108);
            this.lvwVehicleOperation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvwVehicleOperation.MultiSelect = false;
            this.lvwVehicleOperation.Name = "lvwVehicleOperation";
            this.lvwVehicleOperation.Size = new System.Drawing.Size(627, 390);
            this.lvwVehicleOperation.TabIndex = 16;
            this.lvwVehicleOperation.UseCompatibleStateImageBehavior = false;
            this.lvwVehicleOperation.View = System.Windows.Forms.View.Details;
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
            this.colVehicleName.Width = 150;
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
            // frmVehicleOperations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 511);
            this.Controls.Add(this.lvwVehicleOperation);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbCompany);
            this.Controls.Add(this.btVichel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtVehicleCode);
            this.Controls.Add(this.txtVehicleDetails);
            this.Controls.Add(this.btnGO);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btndelete);
            this.Controls.Add(this.btnAdd);
            this.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmVehicleOperations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vehicle Operations";
            this.Load += new System.EventHandler(this.frmVehicleOperations_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btndelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Button btnGO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.Button btVichel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVehicleCode;
        private System.Windows.Forms.TextBox txtVehicleDetails;
        private System.Windows.Forms.ListView lvwVehicleOperation;
        private System.Windows.Forms.ColumnHeader colTranDate;
        private System.Windows.Forms.ColumnHeader colVehicleNo;
        private System.Windows.Forms.ColumnHeader colVehicleName;
        private System.Windows.Forms.ColumnHeader colRegistrationNo;
        private System.Windows.Forms.ColumnHeader colBU;
        private System.Windows.Forms.ColumnHeader colCompany;
        private System.Windows.Forms.ColumnHeader colTripC;
        private System.Windows.Forms.ColumnHeader colTripS;
        private System.Windows.Forms.ColumnHeader colTripU;
        private System.Windows.Forms.ColumnHeader colEndReading;
        private System.Windows.Forms.ColumnHeader colKMRun;
        private System.Windows.Forms.ColumnHeader colInvoiceAmount;
    }
}
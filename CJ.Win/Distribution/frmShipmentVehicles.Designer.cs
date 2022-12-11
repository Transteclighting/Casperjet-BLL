namespace CJ.Win.Distribution
{
    partial class frmShipmentVehicles
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
            this.lvwOrderList = new System.Windows.Forms.ListView();
            this.colCompany = new System.Windows.Forms.ColumnHeader();
            this.colChannel = new System.Windows.Forms.ColumnHeader();
            this.colType = new System.Windows.Forms.ColumnHeader();
            this.colTranNo = new System.Windows.Forms.ColumnHeader();
            this.colTranDate = new System.Windows.Forms.ColumnHeader();
            this.colDestination = new System.Windows.Forms.ColumnHeader();
            this.colTranStatus = new System.Windows.Forms.ColumnHeader();
            this.colTranAmount = new System.Windows.Forms.ColumnHeader();
            this.colCost = new System.Windows.Forms.ColumnHeader();
            this.colShipDate = new System.Windows.Forms.ColumnHeader();
            this.colShipment = new System.Windows.Forms.ColumnHeader();
            this.colRoute = new System.Windows.Forms.ColumnHeader();
            this.colVehicle = new System.Windows.Forms.ColumnHeader();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblDate = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblSummary = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboCompany = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDeliveryDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cboRoute = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbShipment = new System.Windows.Forms.ComboBox();
            this.txtTranNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.colDistrictName = new System.Windows.Forms.ColumnHeader();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbDistrict = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lvwOrderList
            // 
            this.lvwOrderList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwOrderList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCompany,
            this.colChannel,
            this.colType,
            this.colTranNo,
            this.colTranDate,
            this.colDestination,
            this.colTranStatus,
            this.colTranAmount,
            this.colCost,
            this.colShipDate,
            this.colShipment,
            this.colRoute,
            this.colDistrictName,
            this.colVehicle});
            this.lvwOrderList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwOrderList.FullRowSelect = true;
            this.lvwOrderList.GridLines = true;
            this.lvwOrderList.HideSelection = false;
            this.lvwOrderList.Location = new System.Drawing.Point(12, 91);
            this.lvwOrderList.MultiSelect = false;
            this.lvwOrderList.Name = "lvwOrderList";
            this.lvwOrderList.Size = new System.Drawing.Size(945, 390);
            this.lvwOrderList.TabIndex = 21;
            this.lvwOrderList.UseCompatibleStateImageBehavior = false;
            this.lvwOrderList.View = System.Windows.Forms.View.Details;
            this.lvwOrderList.SelectedIndexChanged += new System.EventHandler(this.lvwOrderList_SelectedIndexChanged);
            this.lvwOrderList.DoubleClick += new System.EventHandler(this.lvwOrderList_DoubleClick);
            this.lvwOrderList.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvwOrderList_KeyDown);
            // 
            // colCompany
            // 
            this.colCompany.Text = "Company";
            this.colCompany.Width = 65;
            // 
            // colChannel
            // 
            this.colChannel.Text = "Channel";
            this.colChannel.Width = 81;
            // 
            // colType
            // 
            this.colType.Text = "Type";
            // 
            // colTranNo
            // 
            this.colTranNo.Text = "Tran No";
            this.colTranNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colTranNo.Width = 86;
            // 
            // colTranDate
            // 
            this.colTranDate.Text = "Tran Date";
            this.colTranDate.Width = 102;
            // 
            // colDestination
            // 
            this.colDestination.Text = "Destination Details";
            this.colDestination.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colDestination.Width = 139;
            // 
            // colTranStatus
            // 
            this.colTranStatus.Text = "TranStatus";
            this.colTranStatus.Width = 74;
            // 
            // colTranAmount
            // 
            this.colTranAmount.Text = "Tran Amount";
            this.colTranAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colTranAmount.Width = 86;
            // 
            // colCost
            // 
            this.colCost.Text = "F. Cost";
            this.colCost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colShipDate
            // 
            this.colShipDate.Text = "Shipment Date";
            this.colShipDate.Width = 95;
            // 
            // colShipment
            // 
            this.colShipment.Text = "Shipment";
            this.colShipment.Width = 92;
            // 
            // colRoute
            // 
            this.colRoute.Text = "Route";
            // 
            // colVehicle
            // 
            this.colVehicle.Text = "Vehicle No";
            this.colVehicle.Width = 100;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(858, 490);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(99, 25);
            this.btnClose.TabIndex = 23;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnGo
            // 
            this.btnGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.Location = new System.Drawing.Point(886, 44);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(67, 29);
            this.btnGo.TabIndex = 20;
            this.btnGo.Text = "Search";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(377, 14);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(22, 13);
            this.lblTo.TabIndex = 4;
            this.lblTo.Text = "To";
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(209, 15);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(34, 13);
            this.lblDate.TabIndex = 2;
            this.lblDate.Text = "From";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(451, 12);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(126, 20);
            this.dtToDate.TabIndex = 5;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(249, 12);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(111, 20);
            this.dtFromDate.TabIndex = 3;
            // 
            // lblSummary
            // 
            this.lblSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSummary.Location = new System.Drawing.Point(12, 496);
            this.lblSummary.Name = "lblSummary";
            this.lblSummary.Size = new System.Drawing.Size(670, 22);
            this.lblSummary.TabIndex = 22;
            this.lblSummary.Text = "Summary:?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Company";
            // 
            // cboCompany
            // 
            this.cboCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboCompany.FormattingEnabled = true;
            this.cboCompany.Items.AddRange(new object[] {
            "ALL",
            "TEL",
            "TML",
            "BLL"});
            this.cboCompany.Location = new System.Drawing.Point(78, 11);
            this.cboCompany.Name = "cboCompany";
            this.cboCompany.Size = new System.Drawing.Size(122, 21);
            this.cboCompany.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Tran Type";
            // 
            // cboType
            // 
            this.cboType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboType.FormattingEnabled = true;
            this.cboType.Items.AddRange(new object[] {
            "ALL",
            "Invoice",
            "Chalan"});
            this.cboType.Location = new System.Drawing.Point(78, 47);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(122, 21);
            this.cboType.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(206, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Status";
            // 
            // cboStatus
            // 
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Items.AddRange(new object[] {
            "ALL",
            "Delivered",
            "Processing",
            "Undelivered",
            "Pending",
            "Nothing"});
            this.cboStatus.Location = new System.Drawing.Point(249, 47);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(111, 21);
            this.cboStatus.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(366, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Delivery Date";
            // 
            // dtpDeliveryDate
            // 
            this.dtpDeliveryDate.Checked = false;
            this.dtpDeliveryDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpDeliveryDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDeliveryDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDeliveryDate.Location = new System.Drawing.Point(454, 48);
            this.dtpDeliveryDate.Name = "dtpDeliveryDate";
            this.dtpDeliveryDate.ShowCheckBox = true;
            this.dtpDeliveryDate.Size = new System.Drawing.Size(122, 20);
            this.dtpDeliveryDate.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(761, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Route";
            // 
            // cboRoute
            // 
            this.cboRoute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboRoute.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboRoute.FormattingEnabled = true;
            this.cboRoute.Location = new System.Drawing.Point(808, 46);
            this.cboRoute.Name = "cboRoute";
            this.cboRoute.Size = new System.Drawing.Size(65, 21);
            this.cboRoute.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(582, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Shipment";
            // 
            // cmbShipment
            // 
            this.cmbShipment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbShipment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbShipment.FormattingEnabled = true;
            this.cmbShipment.Location = new System.Drawing.Point(644, 46);
            this.cmbShipment.Name = "cmbShipment";
            this.cmbShipment.Size = new System.Drawing.Size(110, 21);
            this.cmbShipment.TabIndex = 17;
            // 
            // txtTranNo
            // 
            this.txtTranNo.Location = new System.Drawing.Point(645, 10);
            this.txtTranNo.Name = "txtTranNo";
            this.txtTranNo.Size = new System.Drawing.Size(109, 20);
            this.txtTranNo.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(592, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Tran No";
            // 
            // colDistrictName
            // 
            this.colDistrictName.Text = "District Name";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(760, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "District";
            // 
            // cmbDistrict
            // 
            this.cmbDistrict.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDistrict.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDistrict.FormattingEnabled = true;
            this.cmbDistrict.Location = new System.Drawing.Point(808, 8);
            this.cmbDistrict.Name = "cmbDistrict";
            this.cmbDistrict.Size = new System.Drawing.Size(145, 21);
            this.cmbDistrict.TabIndex = 9;
            // 
            // frmShipmentVehicles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 525);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbDistrict);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtTranNo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbShipment);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboRoute);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpDeliveryDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboCompany);
            this.Controls.Add(this.lblSummary);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lvwOrderList);
            this.Name = "frmShipmentVehicles";
            this.Text = "Delivery Shipment (Vehicle)";
            this.Load += new System.EventHandler(this.frmShipmentVehicles_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwOrderList;
        private System.Windows.Forms.ColumnHeader colCompany;
        private System.Windows.Forms.ColumnHeader colTranNo;
        private System.Windows.Forms.ColumnHeader colDestination;
        private System.Windows.Forms.ColumnHeader colShipment;
        private System.Windows.Forms.ColumnHeader colVehicle;
        private System.Windows.Forms.ColumnHeader colType;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColumnHeader colTranDate;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.ColumnHeader colTranStatus;
        private System.Windows.Forms.ColumnHeader colChannel;
        private System.Windows.Forms.ColumnHeader colCost;
        private System.Windows.Forms.Label lblSummary;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboCompany;
        private System.Windows.Forms.ColumnHeader colTranAmount;
        private System.Windows.Forms.ColumnHeader colShipDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDeliveryDate;
        private System.Windows.Forms.ColumnHeader colRoute;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboRoute;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbShipment;
        private System.Windows.Forms.TextBox txtTranNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ColumnHeader colDistrictName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbDistrict;
    }
}
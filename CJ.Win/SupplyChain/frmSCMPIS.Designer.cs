namespace CJ.Win.SupplyChain
{
    partial class frmSCMPIS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSCMPIS));
            this.lvwOrder = new System.Windows.Forms.ListView();
            this.colOrderNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPONo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colOrderPlaceDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCompany = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSupplier = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.txtOrderNo = new System.Windows.Forms.TextBox();
            this.btnGetData = new System.Windows.Forms.Button();
            this.cmbSupplier = new System.Windows.Forms.ComboBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblPSINo = new System.Windows.Forms.Label();
            this.txtPSINo = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.dtFromdate = new System.Windows.Forms.DateTimePicker();
            this.dtTodate = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.btnPIReceived = new System.Windows.Forms.Button();
            this.btnStatusUpdate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwOrder
            // 
            this.lvwOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colOrderNo,
            this.colPONo,
            this.colOrderPlaceDate,
            this.colCompany,
            this.colSupplier,
            this.colStatus});
            this.lvwOrder.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lvwOrder.FullRowSelect = true;
            this.lvwOrder.GridLines = true;
            this.lvwOrder.HideSelection = false;
            this.lvwOrder.Location = new System.Drawing.Point(12, 169);
            this.lvwOrder.MultiSelect = false;
            this.lvwOrder.Name = "lvwOrder";
            this.lvwOrder.Size = new System.Drawing.Size(745, 333);
            this.lvwOrder.TabIndex = 12;
            this.lvwOrder.UseCompatibleStateImageBehavior = false;
            this.lvwOrder.View = System.Windows.Forms.View.Details;
            // 
            // colOrderNo
            // 
            this.colOrderNo.Text = "Order#";
            this.colOrderNo.Width = 103;
            // 
            // colPONo
            // 
            this.colPONo.Text = "PSI#";
            this.colPONo.Width = 100;
            // 
            // colOrderPlaceDate
            // 
            this.colOrderPlaceDate.Text = "Order Place Date";
            this.colOrderPlaceDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colOrderPlaceDate.Width = 99;
            // 
            // colCompany
            // 
            this.colCompany.Text = "Company";
            this.colCompany.Width = 205;
            // 
            // colSupplier
            // 
            this.colSupplier.Text = "Supplier";
            this.colSupplier.Width = 200;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 100;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label1.Location = new System.Drawing.Point(314, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Order No";
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtOrderNo.Location = new System.Drawing.Point(379, 78);
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.Size = new System.Drawing.Size(205, 23);
            this.txtOrderNo.TabIndex = 4;
            // 
            // btnGetData
            // 
            this.btnGetData.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnGetData.Location = new System.Drawing.Point(590, 132);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(87, 31);
            this.btnGetData.TabIndex = 11;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // cmbSupplier
            // 
            this.cmbSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupplier.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.cmbSupplier.FormattingEnabled = true;
            this.cmbSupplier.Location = new System.Drawing.Point(76, 107);
            this.cmbSupplier.Name = "cmbSupplier";
            this.cmbSupplier.Size = new System.Drawing.Size(222, 23);
            this.cmbSupplier.TabIndex = 6;
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lblSupplier.Location = new System.Drawing.Point(16, 111);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(54, 15);
            this.lblSupplier.TabIndex = 5;
            this.lblSupplier.Text = "Supplier";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(378, 107);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(206, 23);
            this.cmbStatus.TabIndex = 8;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lblStatus.Location = new System.Drawing.Point(329, 111);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(41, 15);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Status";
            // 
            // cmbCompany
            // 
            this.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompany.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(76, 136);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(508, 23);
            this.cmbCompany.TabIndex = 10;
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lblCompany.Location = new System.Drawing.Point(9, 140);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(62, 15);
            this.lblCompany.TabIndex = 9;
            this.lblCompany.Text = "Company";
            // 
            // lblPSINo
            // 
            this.lblPSINo.AutoSize = true;
            this.lblPSINo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lblPSINo.Location = new System.Drawing.Point(21, 82);
            this.lblPSINo.Name = "lblPSINo";
            this.lblPSINo.Size = new System.Drawing.Size(45, 15);
            this.lblPSINo.TabIndex = 1;
            this.lblPSINo.Text = "PSI No";
            // 
            // txtPSINo
            // 
            this.txtPSINo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtPSINo.Location = new System.Drawing.Point(76, 78);
            this.txtPSINo.Name = "txtPSINo";
            this.txtPSINo.Size = new System.Drawing.Size(222, 23);
            this.txtPSINo.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkAll);
            this.groupBox2.Controls.Add(this.dtFromdate);
            this.groupBox2.Controls.Add(this.dtTodate);
            this.groupBox2.Controls.Add(this.lblTo);
            this.groupBox2.Controls.Add(this.lblFrom);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.groupBox2.Location = new System.Drawing.Point(27, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(322, 61);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "    ";
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
            // dtFromdate
            // 
            this.dtFromdate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromdate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.dtFromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromdate.Location = new System.Drawing.Point(49, 26);
            this.dtFromdate.Name = "dtFromdate";
            this.dtFromdate.Size = new System.Drawing.Size(115, 23);
            this.dtFromdate.TabIndex = 2;
            // 
            // dtTodate
            // 
            this.dtTodate.CustomFormat = "dd-MMM-yyyy";
            this.dtTodate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.dtTodate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTodate.Location = new System.Drawing.Point(198, 26);
            this.dtTodate.Name = "dtTodate";
            this.dtTodate.Size = new System.Drawing.Size(114, 23);
            this.dtTodate.TabIndex = 4;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lblTo.Location = new System.Drawing.Point(170, 31);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(22, 15);
            this.lblTo.TabIndex = 3;
            this.lblTo.Text = "To";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lblFrom.Location = new System.Drawing.Point(8, 31);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(36, 15);
            this.lblFrom.TabIndex = 1;
            this.lblFrom.Text = "From";
            // 
            // btnPIReceived
            // 
            this.btnPIReceived.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPIReceived.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnPIReceived.Location = new System.Drawing.Point(768, 169);
            this.btnPIReceived.Name = "btnPIReceived";
            this.btnPIReceived.Size = new System.Drawing.Size(97, 31);
            this.btnPIReceived.TabIndex = 13;
            this.btnPIReceived.Text = "PI Received";
            this.btnPIReceived.UseVisualStyleBackColor = true;
            this.btnPIReceived.Click += new System.EventHandler(this.btnPIReceived_Click);
            // 
            // btnStatusUpdate
            // 
            this.btnStatusUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStatusUpdate.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnStatusUpdate.Location = new System.Drawing.Point(768, 207);
            this.btnStatusUpdate.Name = "btnStatusUpdate";
            this.btnStatusUpdate.Size = new System.Drawing.Size(97, 31);
            this.btnStatusUpdate.TabIndex = 14;
            this.btnStatusUpdate.Text = "Status Update";
            this.btnStatusUpdate.UseVisualStyleBackColor = true;
            this.btnStatusUpdate.Click += new System.EventHandler(this.btnStatusUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnClose.Location = new System.Drawing.Point(768, 471);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(97, 31);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Silver;
            this.label15.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label15.Location = new System.Drawing.Point(712, 511);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 15);
            this.label15.TabIndex = 33;
            this.label15.Text = "Billing";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Green;
            this.label14.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label14.Location = new System.Drawing.Point(616, 511);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(87, 15);
            this.label14.TabIndex = 32;
            this.label14.Text = "ReadyForGRD";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Cyan;
            this.label13.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label13.Location = new System.Drawing.Point(555, 511);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(51, 15);
            this.label13.TabIndex = 31;
            this.label13.Text = "Release";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Yellow;
            this.label11.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label11.Location = new System.Drawing.Point(432, 511);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(106, 15);
            this.label11.TabIndex = 30;
            this.label11.Text = "CustomClearance";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Magenta;
            this.label10.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label10.Location = new System.Drawing.Point(366, 511);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(61, 15);
            this.label10.TabIndex = 29;
            this.label10.Text = "Shipment";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.LightGreen;
            this.label9.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label9.Location = new System.Drawing.Point(289, 511);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 15);
            this.label9.TabIndex = 28;
            this.label9.Text = "LCOpening";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.LightSkyBlue;
            this.label8.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label8.Location = new System.Drawing.Point(198, 511);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 15);
            this.label8.TabIndex = 27;
            this.label8.Text = "LCProcessing";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.LightPink;
            this.label7.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label7.Location = new System.Drawing.Point(124, 511);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 15);
            this.label7.TabIndex = 26;
            this.label7.Text = "PIReceive";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.GreenYellow;
            this.label6.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label6.Location = new System.Drawing.Point(47, 511);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 15);
            this.label6.TabIndex = 25;
            this.label6.Text = "OrderPlace";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label12.Location = new System.Drawing.Point(12, 511);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(24, 15);
            this.label12.TabIndex = 34;
            this.label12.Text = "PSI";
            // 
            // frmSCMPIS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 539);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnStatusUpdate);
            this.Controls.Add(this.btnPIReceived);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOrderNo);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.cmbSupplier);
            this.Controls.Add(this.lblSupplier);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbCompany);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.lblPSINo);
            this.Controls.Add(this.txtPSINo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lvwOrder);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSCMPIS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PIS";
            this.Load += new System.EventHandler(this.frmSCMPIS_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwOrder;
        private System.Windows.Forms.ColumnHeader colOrderNo;
        private System.Windows.Forms.ColumnHeader colPONo;
        private System.Windows.Forms.ColumnHeader colOrderPlaceDate;
        private System.Windows.Forms.ColumnHeader colCompany;
        private System.Windows.Forms.ColumnHeader colSupplier;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOrderNo;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.ComboBox cmbSupplier;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblPSINo;
        private System.Windows.Forms.TextBox txtPSINo;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.DateTimePicker dtFromdate;
        private System.Windows.Forms.DateTimePicker dtTodate;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Button btnPIReceived;
        private System.Windows.Forms.Button btnStatusUpdate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label12;
    }
}
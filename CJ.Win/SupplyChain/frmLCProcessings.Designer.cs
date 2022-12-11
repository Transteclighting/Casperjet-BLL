namespace CJ.Win.SupplyChain
{
    partial class frmLCProcessings
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
            this.lvwLCProcess = new System.Windows.Forms.ListView();
            this.colPONo = new System.Windows.Forms.ColumnHeader();
            this.colPODate = new System.Windows.Forms.ColumnHeader();
            this.colLCProcessingDate = new System.Windows.Forms.ColumnHeader();
            this.colStatus = new System.Windows.Forms.ColumnHeader();
            this.colLCID = new System.Windows.Forms.ColumnHeader();
            this.colLCNO = new System.Windows.Forms.ColumnHeader();
            this.lblSupplierName = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.lblExpGRDWeek = new System.Windows.Forms.Label();
            this.lblPONo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblweek = new System.Windows.Forms.Label();
            this.lblPO = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.lblPINO = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPIReceiveDate = new System.Windows.Forms.Label();
            this.lblPIRec = new System.Windows.Forms.Label();
            this.btnLCProcessing = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnLCOpen = new System.Windows.Forms.Button();
            this.btnNonLC = new System.Windows.Forms.Button();
            this.btnShipment = new System.Windows.Forms.Button();
            this.lblPOID = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvwLCProcess
            // 
            this.lvwLCProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwLCProcess.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPONo,
            this.colPODate,
            this.colLCProcessingDate,
            this.colStatus,
            this.colLCID,
            this.colLCNO});
            this.lvwLCProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwLCProcess.FullRowSelect = true;
            this.lvwLCProcess.GridLines = true;
            this.lvwLCProcess.HideSelection = false;
            this.lvwLCProcess.Location = new System.Drawing.Point(12, 63);
            this.lvwLCProcess.MultiSelect = false;
            this.lvwLCProcess.Name = "lvwLCProcess";
            this.lvwLCProcess.Size = new System.Drawing.Size(620, 310);
            this.lvwLCProcess.TabIndex = 9;
            this.lvwLCProcess.UseCompatibleStateImageBehavior = false;
            this.lvwLCProcess.View = System.Windows.Forms.View.Details;
            // 
            // colPONo
            // 
            this.colPONo.Text = "PONo";
            this.colPONo.Width = 102;
            // 
            // colPODate
            // 
            this.colPODate.Text = "PODate";
            this.colPODate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colPODate.Width = 97;
            // 
            // colLCProcessingDate
            // 
            this.colLCProcessingDate.Text = "LCProcessingDate";
            this.colLCProcessingDate.Width = 195;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 113;
            // 
            // colLCID
            // 
            this.colLCID.Text = "LCID";
            // 
            // colLCNO
            // 
            this.colLCNO.Text = "LCNO";
            // 
            // lblSupplierName
            // 
            this.lblSupplierName.AutoSize = true;
            this.lblSupplierName.Font = new System.Drawing.Font("Book Antiqua", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupplierName.ForeColor = System.Drawing.Color.Blue;
            this.lblSupplierName.Location = new System.Drawing.Point(387, 9);
            this.lblSupplierName.Name = "lblSupplierName";
            this.lblSupplierName.Size = new System.Drawing.Size(13, 17);
            this.lblSupplierName.TabIndex = 11;
            this.lblSupplierName.Text = "?";
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("Book Antiqua", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyName.ForeColor = System.Drawing.Color.Blue;
            this.lblCompanyName.Location = new System.Drawing.Point(110, 9);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(13, 17);
            this.lblCompanyName.TabIndex = 6;
            this.lblCompanyName.Text = "?";
            // 
            // lblExpGRDWeek
            // 
            this.lblExpGRDWeek.AutoSize = true;
            this.lblExpGRDWeek.Font = new System.Drawing.Font("Book Antiqua", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpGRDWeek.ForeColor = System.Drawing.Color.Blue;
            this.lblExpGRDWeek.Location = new System.Drawing.Point(387, 35);
            this.lblExpGRDWeek.Name = "lblExpGRDWeek";
            this.lblExpGRDWeek.Size = new System.Drawing.Size(13, 17);
            this.lblExpGRDWeek.TabIndex = 13;
            this.lblExpGRDWeek.Text = "?";
            // 
            // lblPONo
            // 
            this.lblPONo.AutoSize = true;
            this.lblPONo.Font = new System.Drawing.Font("Book Antiqua", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPONo.ForeColor = System.Drawing.Color.Blue;
            this.lblPONo.Location = new System.Drawing.Point(110, 35);
            this.lblPONo.Name = "lblPONo";
            this.lblPONo.Size = new System.Drawing.Size(13, 17);
            this.lblPONo.TabIndex = 8;
            this.lblPONo.Text = "?";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Book Antiqua", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(287, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Supplier Name:";
            // 
            // lblweek
            // 
            this.lblweek.AutoSize = true;
            this.lblweek.Font = new System.Drawing.Font("Book Antiqua", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblweek.Location = new System.Drawing.Point(287, 35);
            this.lblweek.Name = "lblweek";
            this.lblweek.Size = new System.Drawing.Size(94, 17);
            this.lblweek.TabIndex = 12;
            this.lblweek.Text = "Exp.GRDWeek:";
            // 
            // lblPO
            // 
            this.lblPO.AutoSize = true;
            this.lblPO.Font = new System.Drawing.Font("Book Antiqua", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPO.Location = new System.Drawing.Point(56, 35);
            this.lblPO.Name = "lblPO";
            this.lblPO.Size = new System.Drawing.Size(48, 17);
            this.lblPO.TabIndex = 7;
            this.lblPO.Text = "PO No:";
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Book Antiqua", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompany.Location = new System.Drawing.Point(3, 9);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(101, 17);
            this.lblCompany.TabIndex = 5;
            this.lblCompany.Text = "Company Name:";
            // 
            // lblPINO
            // 
            this.lblPINO.AutoSize = true;
            this.lblPINO.Font = new System.Drawing.Font("Book Antiqua", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPINO.ForeColor = System.Drawing.Color.Blue;
            this.lblPINO.Location = new System.Drawing.Point(595, 9);
            this.lblPINO.Name = "lblPINO";
            this.lblPINO.Size = new System.Drawing.Size(13, 17);
            this.lblPINO.TabIndex = 16;
            this.lblPINO.Text = "?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Book Antiqua", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(549, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "PINo:";
            // 
            // lblPIReceiveDate
            // 
            this.lblPIReceiveDate.AutoSize = true;
            this.lblPIReceiveDate.Font = new System.Drawing.Font("Book Antiqua", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPIReceiveDate.ForeColor = System.Drawing.Color.Blue;
            this.lblPIReceiveDate.Location = new System.Drawing.Point(595, 35);
            this.lblPIReceiveDate.Name = "lblPIReceiveDate";
            this.lblPIReceiveDate.Size = new System.Drawing.Size(13, 17);
            this.lblPIReceiveDate.TabIndex = 19;
            this.lblPIReceiveDate.Text = "?";
            // 
            // lblPIRec
            // 
            this.lblPIRec.AutoSize = true;
            this.lblPIRec.Font = new System.Drawing.Font("Book Antiqua", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPIRec.Location = new System.Drawing.Point(495, 35);
            this.lblPIRec.Name = "lblPIRec";
            this.lblPIRec.Size = new System.Drawing.Size(95, 17);
            this.lblPIRec.TabIndex = 14;
            this.lblPIRec.Text = "PI ReceiveDate:";
            // 
            // btnLCProcessing
            // 
            this.btnLCProcessing.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLCProcessing.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLCProcessing.Location = new System.Drawing.Point(638, 63);
            this.btnLCProcessing.Name = "btnLCProcessing";
            this.btnLCProcessing.Size = new System.Drawing.Size(106, 28);
            this.btnLCProcessing.TabIndex = 0;
            this.btnLCProcessing.Text = "LC Prcessing";
            this.btnLCProcessing.UseVisualStyleBackColor = true;
            this.btnLCProcessing.Click += new System.EventHandler(this.btnLCProcessing_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(645, 346);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(99, 27);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnLCOpen
            // 
            this.btnLCOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLCOpen.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLCOpen.Location = new System.Drawing.Point(638, 97);
            this.btnLCOpen.Name = "btnLCOpen";
            this.btnLCOpen.Size = new System.Drawing.Size(106, 28);
            this.btnLCOpen.TabIndex = 1;
            this.btnLCOpen.Text = "LC Open";
            this.btnLCOpen.UseVisualStyleBackColor = true;
            this.btnLCOpen.Click += new System.EventHandler(this.btnLCOpen_Click);
            // 
            // btnNonLC
            // 
            this.btnNonLC.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNonLC.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNonLC.Location = new System.Drawing.Point(638, 131);
            this.btnNonLC.Name = "btnNonLC";
            this.btnNonLC.Size = new System.Drawing.Size(106, 28);
            this.btnNonLC.TabIndex = 2;
            this.btnNonLC.Text = "Non LC";
            this.btnNonLC.UseVisualStyleBackColor = true;
            this.btnNonLC.Click += new System.EventHandler(this.btnNonLC_Click);
            // 
            // btnShipment
            // 
            this.btnShipment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShipment.Font = new System.Drawing.Font("Bookman Old Style", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShipment.Location = new System.Drawing.Point(638, 165);
            this.btnShipment.Name = "btnShipment";
            this.btnShipment.Size = new System.Drawing.Size(106, 28);
            this.btnShipment.TabIndex = 3;
            this.btnShipment.Text = "Shipment";
            this.btnShipment.UseVisualStyleBackColor = true;
            this.btnShipment.Click += new System.EventHandler(this.btnShipment_Click);
            // 
            // lblPOID
            // 
            this.lblPOID.AutoSize = true;
            this.lblPOID.Font = new System.Drawing.Font("Book Antiqua", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPOID.ForeColor = System.Drawing.Color.Blue;
            this.lblPOID.Location = new System.Drawing.Point(669, 9);
            this.lblPOID.Name = "lblPOID";
            this.lblPOID.Size = new System.Drawing.Size(13, 17);
            this.lblPOID.TabIndex = 18;
            this.lblPOID.Text = "?";
            this.lblPOID.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Book Antiqua", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(623, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 17);
            this.label4.TabIndex = 17;
            this.label4.Text = "POID:";
            this.label4.Visible = false;
            // 
            // frmLCProcessings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 385);
            this.Controls.Add(this.lblPOID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnShipment);
            this.Controls.Add(this.btnNonLC);
            this.Controls.Add(this.btnLCOpen);
            this.Controls.Add(this.btnLCProcessing);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblPIReceiveDate);
            this.Controls.Add(this.lblPIRec);
            this.Controls.Add(this.lblPINO);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblSupplierName);
            this.Controls.Add(this.lblCompanyName);
            this.Controls.Add(this.lblExpGRDWeek);
            this.Controls.Add(this.lblPONo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblweek);
            this.Controls.Add(this.lblPO);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.lvwLCProcess);
            this.Name = "frmLCProcessings";
            this.Text = "frmLCProcessings";
            this.Load += new System.EventHandler(this.frmLCProcessings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwLCProcess;
        private System.Windows.Forms.ColumnHeader colPONo;
        private System.Windows.Forms.ColumnHeader colPODate;
        private System.Windows.Forms.ColumnHeader colLCProcessingDate;
        private System.Windows.Forms.Label lblSupplierName;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Label lblExpGRDWeek;
        private System.Windows.Forms.Label lblPONo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblweek;
        private System.Windows.Forms.Label lblPO;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.Label lblPINO;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblPIReceiveDate;
        private System.Windows.Forms.Label lblPIRec;
        private System.Windows.Forms.Button btnLCProcessing;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnLCOpen;
        private System.Windows.Forms.Button btnNonLC;
        private System.Windows.Forms.Button btnShipment;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.Label lblPOID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader colLCID;
        private System.Windows.Forms.ColumnHeader colLCNO;
    }
}
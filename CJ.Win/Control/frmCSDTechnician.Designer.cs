namespace CJ.Win.Control
{
    partial class frmCSDTechnician
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
            this.tcTechnicianType = new System.Windows.Forms.TabControl();
            this.tbOwnTechnician = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbWorkshopLocation = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOwnTechNameSearch = new System.Windows.Forms.TextBox();
            this.txtOwnTechCodeSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGetOwnTech = new System.Windows.Forms.Button();
            this.lvwOwnTech = new System.Windows.Forms.ListView();
            this.colOwnTechCode = new System.Windows.Forms.ColumnHeader();
            this.colOwnTechName = new System.Windows.Forms.ColumnHeader();
            this.colOwnTechWorkshopType = new System.Windows.Forms.ColumnHeader();
            this.colWorkshopLocation = new System.Windows.Forms.ColumnHeader();
            this.tbThirdPartyTech = new System.Windows.Forms.TabPage();
            this.btnViewJobsInHand = new System.Windows.Forms.Button();
            this.ctlInterService1 = new CJ.Win.ctlInterService();
            this.lblThirdPartyName = new System.Windows.Forms.Label();
            this.lblTechName = new System.Windows.Forms.Label();
            this.txtTechName = new System.Windows.Forms.TextBox();
            this.txtTechCode = new System.Windows.Forms.TextBox();
            this.lblTechCode = new System.Windows.Forms.Label();
            this.btnGetThirdPartyTech = new System.Windows.Forms.Button();
            this.lvwThirdParty = new System.Windows.Forms.ListView();
            this.colTechCode = new System.Windows.Forms.ColumnHeader();
            this.colTechnicianName = new System.Windows.Forms.ColumnHeader();
            this.colThirdPartyID = new System.Windows.Forms.ColumnHeader();
            this.colWorkshopType = new System.Windows.Forms.ColumnHeader();
            this.colAddress = new System.Windows.Forms.ColumnHeader();
            this.colPhone = new System.Windows.Forms.ColumnHeader();
            this.colMobile = new System.Windows.Forms.ColumnHeader();
            this.colThana = new System.Windows.Forms.ColumnHeader();
            this.colDistrictName = new System.Windows.Forms.ColumnHeader();
            this.tcTechnicianType.SuspendLayout();
            this.tbOwnTechnician.SuspendLayout();
            this.tbThirdPartyTech.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcTechnicianType
            // 
            this.tcTechnicianType.Controls.Add(this.tbOwnTechnician);
            this.tcTechnicianType.Controls.Add(this.tbThirdPartyTech);
            this.tcTechnicianType.Location = new System.Drawing.Point(0, 4);
            this.tcTechnicianType.Name = "tcTechnicianType";
            this.tcTechnicianType.SelectedIndex = 0;
            this.tcTechnicianType.Size = new System.Drawing.Size(1024, 471);
            this.tcTechnicianType.TabIndex = 0;
            // 
            // tbOwnTechnician
            // 
            this.tbOwnTechnician.Controls.Add(this.label3);
            this.tbOwnTechnician.Controls.Add(this.cmbWorkshopLocation);
            this.tbOwnTechnician.Controls.Add(this.button1);
            this.tbOwnTechnician.Controls.Add(this.label1);
            this.tbOwnTechnician.Controls.Add(this.txtOwnTechNameSearch);
            this.tbOwnTechnician.Controls.Add(this.txtOwnTechCodeSearch);
            this.tbOwnTechnician.Controls.Add(this.label2);
            this.tbOwnTechnician.Controls.Add(this.btnGetOwnTech);
            this.tbOwnTechnician.Controls.Add(this.lvwOwnTech);
            this.tbOwnTechnician.Location = new System.Drawing.Point(4, 22);
            this.tbOwnTechnician.Name = "tbOwnTechnician";
            this.tbOwnTechnician.Padding = new System.Windows.Forms.Padding(3);
            this.tbOwnTechnician.Size = new System.Drawing.Size(1016, 445);
            this.tbOwnTechnician.TabIndex = 0;
            this.tbOwnTechnician.Text = "Own Technician";
            this.tbOwnTechnician.UseVisualStyleBackColor = true;
            this.tbOwnTechnician.Click += new System.EventHandler(this.tbOwnTechnician_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(249, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Workshop Location";
            // 
            // cmbWorkshopLocation
            // 
            this.cmbWorkshopLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorkshopLocation.FormattingEnabled = true;
            this.cmbWorkshopLocation.Location = new System.Drawing.Point(350, 9);
            this.cmbWorkshopLocation.Name = "cmbWorkshopLocation";
            this.cmbWorkshopLocation.Size = new System.Drawing.Size(151, 21);
            this.cmbWorkshopLocation.TabIndex = 20;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(507, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 26);
            this.button1.TabIndex = 14;
            this.button1.Text = "View Jobs In Hand";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Tech Name";
            // 
            // txtOwnTechNameSearch
            // 
            this.txtOwnTechNameSearch.Location = new System.Drawing.Point(76, 31);
            this.txtOwnTechNameSearch.Name = "txtOwnTechNameSearch";
            this.txtOwnTechNameSearch.Size = new System.Drawing.Size(166, 20);
            this.txtOwnTechNameSearch.TabIndex = 13;
            // 
            // txtOwnTechCodeSearch
            // 
            this.txtOwnTechCodeSearch.Location = new System.Drawing.Point(76, 6);
            this.txtOwnTechCodeSearch.Name = "txtOwnTechCodeSearch";
            this.txtOwnTechCodeSearch.Size = new System.Drawing.Size(166, 20);
            this.txtOwnTechCodeSearch.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Tech Code";
            // 
            // btnGetOwnTech
            // 
            this.btnGetOwnTech.Location = new System.Drawing.Point(507, 5);
            this.btnGetOwnTech.Name = "btnGetOwnTech";
            this.btnGetOwnTech.Size = new System.Drawing.Size(117, 26);
            this.btnGetOwnTech.TabIndex = 9;
            this.btnGetOwnTech.Text = "Get";
            this.btnGetOwnTech.UseVisualStyleBackColor = true;
            this.btnGetOwnTech.Click += new System.EventHandler(this.btnGetOwnTech_Click);
            // 
            // lvwOwnTech
            // 
            this.lvwOwnTech.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwOwnTech.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colOwnTechCode,
            this.colOwnTechName,
            this.colOwnTechWorkshopType,
            this.colWorkshopLocation});
            this.lvwOwnTech.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwOwnTech.FullRowSelect = true;
            this.lvwOwnTech.GridLines = true;
            this.lvwOwnTech.HideSelection = false;
            this.lvwOwnTech.Location = new System.Drawing.Point(3, 67);
            this.lvwOwnTech.MultiSelect = false;
            this.lvwOwnTech.Name = "lvwOwnTech";
            this.lvwOwnTech.Size = new System.Drawing.Size(1006, 376);
            this.lvwOwnTech.TabIndex = 8;
            this.lvwOwnTech.UseCompatibleStateImageBehavior = false;
            this.lvwOwnTech.View = System.Windows.Forms.View.Details;
            this.lvwOwnTech.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvwOwnTech_MouseDoubleClick);
            // 
            // colOwnTechCode
            // 
            this.colOwnTechCode.Text = "Code";
            this.colOwnTechCode.Width = 190;
            // 
            // colOwnTechName
            // 
            this.colOwnTechName.Text = "Technician Name";
            this.colOwnTechName.Width = 221;
            // 
            // colOwnTechWorkshopType
            // 
            this.colOwnTechWorkshopType.Text = "Workshop Type";
            this.colOwnTechWorkshopType.Width = 193;
            // 
            // colWorkshopLocation
            // 
            this.colWorkshopLocation.Text = "Workshop Location";
            this.colWorkshopLocation.Width = 225;
            // 
            // tbThirdPartyTech
            // 
            this.tbThirdPartyTech.Controls.Add(this.btnViewJobsInHand);
            this.tbThirdPartyTech.Controls.Add(this.ctlInterService1);
            this.tbThirdPartyTech.Controls.Add(this.lblThirdPartyName);
            this.tbThirdPartyTech.Controls.Add(this.lblTechName);
            this.tbThirdPartyTech.Controls.Add(this.txtTechName);
            this.tbThirdPartyTech.Controls.Add(this.txtTechCode);
            this.tbThirdPartyTech.Controls.Add(this.lblTechCode);
            this.tbThirdPartyTech.Controls.Add(this.btnGetThirdPartyTech);
            this.tbThirdPartyTech.Controls.Add(this.lvwThirdParty);
            this.tbThirdPartyTech.Location = new System.Drawing.Point(4, 22);
            this.tbThirdPartyTech.Name = "tbThirdPartyTech";
            this.tbThirdPartyTech.Padding = new System.Windows.Forms.Padding(3);
            this.tbThirdPartyTech.Size = new System.Drawing.Size(1016, 445);
            this.tbThirdPartyTech.TabIndex = 1;
            this.tbThirdPartyTech.Text = "Third Party Tech";
            this.tbThirdPartyTech.UseVisualStyleBackColor = true;
            // 
            // btnViewJobsInHand
            // 
            this.btnViewJobsInHand.Location = new System.Drawing.Point(700, 35);
            this.btnViewJobsInHand.Name = "btnViewJobsInHand";
            this.btnViewJobsInHand.Size = new System.Drawing.Size(117, 26);
            this.btnViewJobsInHand.TabIndex = 8;
            this.btnViewJobsInHand.Text = "View Jobs In Hand";
            this.btnViewJobsInHand.UseVisualStyleBackColor = true;
            this.btnViewJobsInHand.Click += new System.EventHandler(this.btnViewJobsInHand_Click);
            // 
            // ctlInterService1
            // 
            this.ctlInterService1.Location = new System.Drawing.Point(310, 12);
            this.ctlInterService1.Name = "ctlInterService1";
            this.ctlInterService1.Size = new System.Drawing.Size(382, 25);
            this.ctlInterService1.TabIndex = 5;
            // 
            // lblThirdPartyName
            // 
            this.lblThirdPartyName.AutoSize = true;
            this.lblThirdPartyName.Location = new System.Drawing.Point(249, 15);
            this.lblThirdPartyName.Name = "lblThirdPartyName";
            this.lblThirdPartyName.Size = new System.Drawing.Size(58, 13);
            this.lblThirdPartyName.TabIndex = 4;
            this.lblThirdPartyName.Text = "Third Party";
            // 
            // lblTechName
            // 
            this.lblTechName.AutoSize = true;
            this.lblTechName.Location = new System.Drawing.Point(13, 42);
            this.lblTechName.Name = "lblTechName";
            this.lblTechName.Size = new System.Drawing.Size(63, 13);
            this.lblTechName.TabIndex = 2;
            this.lblTechName.Text = "Tech Name";
            // 
            // txtTechName
            // 
            this.txtTechName.Location = new System.Drawing.Point(78, 39);
            this.txtTechName.Name = "txtTechName";
            this.txtTechName.Size = new System.Drawing.Size(165, 20);
            this.txtTechName.TabIndex = 3;
            // 
            // txtTechCode
            // 
            this.txtTechCode.Location = new System.Drawing.Point(78, 13);
            this.txtTechCode.Name = "txtTechCode";
            this.txtTechCode.Size = new System.Drawing.Size(165, 20);
            this.txtTechCode.TabIndex = 1;
            // 
            // lblTechCode
            // 
            this.lblTechCode.AutoSize = true;
            this.lblTechCode.Location = new System.Drawing.Point(14, 16);
            this.lblTechCode.Name = "lblTechCode";
            this.lblTechCode.Size = new System.Drawing.Size(60, 13);
            this.lblTechCode.TabIndex = 0;
            this.lblTechCode.Text = "Tech Code";
            // 
            // btnGetThirdPartyTech
            // 
            this.btnGetThirdPartyTech.Location = new System.Drawing.Point(700, 9);
            this.btnGetThirdPartyTech.Name = "btnGetThirdPartyTech";
            this.btnGetThirdPartyTech.Size = new System.Drawing.Size(117, 26);
            this.btnGetThirdPartyTech.TabIndex = 6;
            this.btnGetThirdPartyTech.Text = "Get";
            this.btnGetThirdPartyTech.UseVisualStyleBackColor = true;
            this.btnGetThirdPartyTech.Click += new System.EventHandler(this.btnGetThirdPartyTech_Click);
            // 
            // lvwThirdParty
            // 
            this.lvwThirdParty.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwThirdParty.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTechCode,
            this.colTechnicianName,
            this.colThirdPartyID,
            this.colWorkshopType,
            this.colAddress,
            this.colPhone,
            this.colMobile,
            this.colThana,
            this.colDistrictName});
            this.lvwThirdParty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwThirdParty.FullRowSelect = true;
            this.lvwThirdParty.GridLines = true;
            this.lvwThirdParty.HideSelection = false;
            this.lvwThirdParty.Location = new System.Drawing.Point(4, 66);
            this.lvwThirdParty.MultiSelect = false;
            this.lvwThirdParty.Name = "lvwThirdParty";
            this.lvwThirdParty.Size = new System.Drawing.Size(1009, 373);
            this.lvwThirdParty.TabIndex = 7;
            this.lvwThirdParty.UseCompatibleStateImageBehavior = false;
            this.lvwThirdParty.View = System.Windows.Forms.View.Details;
            this.lvwThirdParty.DoubleClick += new System.EventHandler(this.lvwThirdParty_DoubleClick);
            // 
            // colTechCode
            // 
            this.colTechCode.Text = "Code";
            // 
            // colTechnicianName
            // 
            this.colTechnicianName.Text = "Tech. Name";
            this.colTechnicianName.Width = 172;
            // 
            // colThirdPartyID
            // 
            this.colThirdPartyID.Text = "Third Party Name";
            this.colThirdPartyID.Width = 160;
            // 
            // colWorkshopType
            // 
            this.colWorkshopType.Text = "WorkshopType";
            this.colWorkshopType.Width = 84;
            // 
            // colAddress
            // 
            this.colAddress.Text = "Address";
            this.colAddress.Width = 192;
            // 
            // colPhone
            // 
            this.colPhone.Text = "Phone";
            this.colPhone.Width = 74;
            // 
            // colMobile
            // 
            this.colMobile.Text = "Mobile";
            this.colMobile.Width = 88;
            // 
            // colThana
            // 
            this.colThana.Text = "Thana";
            this.colThana.Width = 84;
            // 
            // colDistrictName
            // 
            this.colDistrictName.Text = "District";
            this.colDistrictName.Width = 84;
            // 
            // frmCSDTechnician
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 478);
            this.Controls.Add(this.tcTechnicianType);
            this.Name = "frmCSDTechnician";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSD Technician";
            this.Load += new System.EventHandler(this.frmCSDTechnician_Load);
            this.tcTechnicianType.ResumeLayout(false);
            this.tbOwnTechnician.ResumeLayout(false);
            this.tbOwnTechnician.PerformLayout();
            this.tbThirdPartyTech.ResumeLayout(false);
            this.tbThirdPartyTech.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcTechnicianType;
        private System.Windows.Forms.TabPage tbOwnTechnician;
        private System.Windows.Forms.Button btnGetOwnTech;
        private System.Windows.Forms.ListView lvwOwnTech;
        private System.Windows.Forms.ColumnHeader colOwnTechCode;
        private System.Windows.Forms.ColumnHeader colOwnTechName;
        private System.Windows.Forms.ColumnHeader colOwnTechWorkshopType;
        private System.Windows.Forms.TabPage tbThirdPartyTech;
        private ctlInterService ctlInterService1;
        private System.Windows.Forms.Label lblThirdPartyName;
        private System.Windows.Forms.Label lblTechName;
        private System.Windows.Forms.TextBox txtTechName;
        private System.Windows.Forms.TextBox txtTechCode;
        private System.Windows.Forms.Label lblTechCode;
        private System.Windows.Forms.Button btnGetThirdPartyTech;
        private System.Windows.Forms.ListView lvwThirdParty;
        private System.Windows.Forms.ColumnHeader colTechCode;
        private System.Windows.Forms.ColumnHeader colTechnicianName;
        private System.Windows.Forms.ColumnHeader colThirdPartyID;
        private System.Windows.Forms.ColumnHeader colWorkshopType;
        private System.Windows.Forms.ColumnHeader colAddress;
        private System.Windows.Forms.ColumnHeader colPhone;
        private System.Windows.Forms.ColumnHeader colMobile;
        private System.Windows.Forms.ColumnHeader colThana;
        private System.Windows.Forms.ColumnHeader colDistrictName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOwnTechNameSearch;
        private System.Windows.Forms.TextBox txtOwnTechCodeSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnViewJobsInHand;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColumnHeader colWorkshopLocation;
        private System.Windows.Forms.ComboBox cmbWorkshopLocation;
        private System.Windows.Forms.Label label3;

    }
}
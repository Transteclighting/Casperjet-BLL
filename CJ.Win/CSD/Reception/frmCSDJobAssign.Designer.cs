namespace CJ.Win.CSD.Reception
{
    partial class frmCSDJobAssign
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
            this.btnViewJob_OwnTech = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOwnTechNameSearch = new System.Windows.Forms.TextBox();
            this.txtOwnTechCodeSearch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGetOwnTech = new System.Windows.Forms.Button();
            this.lvwOwnTech = new System.Windows.Forms.ListView();
            this.colOwnTechCode = new System.Windows.Forms.ColumnHeader();
            this.colOwnTechName = new System.Windows.Forms.ColumnHeader();
            this.colOwnTechWorkshopType = new System.Windows.Forms.ColumnHeader();
            this.colWorkshopLoctionName = new System.Windows.Forms.ColumnHeader();
            this.tbThirdPartyTech = new System.Windows.Forms.TabPage();
            this.btnViewJobsInHand = new System.Windows.Forms.Button();
            this.lblThirdPartyName = new System.Windows.Forms.Label();
            this.lblTechName = new System.Windows.Forms.Label();
            this.txtTechName = new System.Windows.Forms.TextBox();
            this.txtTechCode = new System.Windows.Forms.TextBox();
            this.lblTechCode = new System.Windows.Forms.Label();
            this.btnGetThirdPartyTech = new System.Windows.Forms.Button();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.rdoSuggested = new System.Windows.Forms.RadioButton();
            this.ctlInterService1 = new CJ.Win.ctlInterService();
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
            this.tcTechnicianType.Location = new System.Drawing.Point(-1, 0);
            this.tcTechnicianType.Name = "tcTechnicianType";
            this.tcTechnicianType.SelectedIndex = 0;
            this.tcTechnicianType.Size = new System.Drawing.Size(1024, 450);
            this.tcTechnicianType.TabIndex = 0;
            // 
            // tbOwnTechnician
            // 
            this.tbOwnTechnician.Controls.Add(this.label3);
            this.tbOwnTechnician.Controls.Add(this.cmbWorkshopLocation);
            this.tbOwnTechnician.Controls.Add(this.btnViewJob_OwnTech);
            this.tbOwnTechnician.Controls.Add(this.label1);
            this.tbOwnTechnician.Controls.Add(this.txtOwnTechNameSearch);
            this.tbOwnTechnician.Controls.Add(this.txtOwnTechCodeSearch);
            this.tbOwnTechnician.Controls.Add(this.label2);
            this.tbOwnTechnician.Controls.Add(this.btnGetOwnTech);
            this.tbOwnTechnician.Controls.Add(this.lvwOwnTech);
            this.tbOwnTechnician.Location = new System.Drawing.Point(4, 22);
            this.tbOwnTechnician.Name = "tbOwnTechnician";
            this.tbOwnTechnician.Padding = new System.Windows.Forms.Padding(3);
            this.tbOwnTechnician.Size = new System.Drawing.Size(1016, 424);
            this.tbOwnTechnician.TabIndex = 0;
            this.tbOwnTechnician.Text = "Own Technician";
            this.tbOwnTechnician.UseVisualStyleBackColor = true;
            this.tbOwnTechnician.Click += new System.EventHandler(this.tbOwnTechnician_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(242, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Workshop Location";
            // 
            // cmbWorkshopLocation
            // 
            this.cmbWorkshopLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorkshopLocation.FormattingEnabled = true;
            this.cmbWorkshopLocation.Location = new System.Drawing.Point(343, 6);
            this.cmbWorkshopLocation.Name = "cmbWorkshopLocation";
            this.cmbWorkshopLocation.Size = new System.Drawing.Size(151, 21);
            this.cmbWorkshopLocation.TabIndex = 22;
            // 
            // btnViewJob_OwnTech
            // 
            this.btnViewJob_OwnTech.Location = new System.Drawing.Point(612, 7);
            this.btnViewJob_OwnTech.Name = "btnViewJob_OwnTech";
            this.btnViewJob_OwnTech.Size = new System.Drawing.Size(105, 26);
            this.btnViewJob_OwnTech.TabIndex = 18;
            this.btnViewJob_OwnTech.Text = "&View Jobs In Hand";
            this.btnViewJob_OwnTech.UseVisualStyleBackColor = true;
            this.btnViewJob_OwnTech.Click += new System.EventHandler(this.btnViewJob_OwnTech_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Tech Name";
            // 
            // txtOwnTechNameSearch
            // 
            this.txtOwnTechNameSearch.Location = new System.Drawing.Point(71, 31);
            this.txtOwnTechNameSearch.Name = "txtOwnTechNameSearch";
            this.txtOwnTechNameSearch.Size = new System.Drawing.Size(166, 20);
            this.txtOwnTechNameSearch.TabIndex = 17;
            // 
            // txtOwnTechCodeSearch
            // 
            this.txtOwnTechCodeSearch.Location = new System.Drawing.Point(71, 6);
            this.txtOwnTechCodeSearch.Name = "txtOwnTechCodeSearch";
            this.txtOwnTechCodeSearch.Size = new System.Drawing.Size(166, 20);
            this.txtOwnTechCodeSearch.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Tech Code";
            // 
            // btnGetOwnTech
            // 
            this.btnGetOwnTech.Location = new System.Drawing.Point(501, 7);
            this.btnGetOwnTech.Name = "btnGetOwnTech";
            this.btnGetOwnTech.Size = new System.Drawing.Size(105, 26);
            this.btnGetOwnTech.TabIndex = 0;
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
            this.colWorkshopLoctionName});
            this.lvwOwnTech.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwOwnTech.FullRowSelect = true;
            this.lvwOwnTech.GridLines = true;
            this.lvwOwnTech.HideSelection = false;
            this.lvwOwnTech.Location = new System.Drawing.Point(8, 65);
            this.lvwOwnTech.MultiSelect = false;
            this.lvwOwnTech.Name = "lvwOwnTech";
            this.lvwOwnTech.Size = new System.Drawing.Size(1002, 351);
            this.lvwOwnTech.TabIndex = 2;
            this.lvwOwnTech.UseCompatibleStateImageBehavior = false;
            this.lvwOwnTech.View = System.Windows.Forms.View.Details;
            this.lvwOwnTech.SelectedIndexChanged += new System.EventHandler(this.lvwOwnTech_SelectedIndexChanged);
            this.lvwOwnTech.DoubleClick += new System.EventHandler(this.lvwOwnTech_DoubleClick);
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
            // colWorkshopLoctionName
            // 
            this.colWorkshopLoctionName.Text = "Workshop Location ";
            this.colWorkshopLoctionName.Width = 200;
            // 
            // tbThirdPartyTech
            // 
            this.tbThirdPartyTech.Controls.Add(this.btnViewJobsInHand);
            this.tbThirdPartyTech.Controls.Add(this.lblThirdPartyName);
            this.tbThirdPartyTech.Controls.Add(this.lblTechName);
            this.tbThirdPartyTech.Controls.Add(this.txtTechName);
            this.tbThirdPartyTech.Controls.Add(this.txtTechCode);
            this.tbThirdPartyTech.Controls.Add(this.lblTechCode);
            this.tbThirdPartyTech.Controls.Add(this.btnGetThirdPartyTech);
            this.tbThirdPartyTech.Controls.Add(this.rdoAll);
            this.tbThirdPartyTech.Controls.Add(this.rdoSuggested);
            this.tbThirdPartyTech.Controls.Add(this.ctlInterService1);
            this.tbThirdPartyTech.Controls.Add(this.lvwThirdParty);
            this.tbThirdPartyTech.Location = new System.Drawing.Point(4, 22);
            this.tbThirdPartyTech.Name = "tbThirdPartyTech";
            this.tbThirdPartyTech.Padding = new System.Windows.Forms.Padding(3);
            this.tbThirdPartyTech.Size = new System.Drawing.Size(1016, 424);
            this.tbThirdPartyTech.TabIndex = 1;
            this.tbThirdPartyTech.Text = "Third Party Tech";
            this.tbThirdPartyTech.UseVisualStyleBackColor = true;
            this.tbThirdPartyTech.Click += new System.EventHandler(this.tbThirdPartyTech_Click);
            // 
            // btnViewJobsInHand
            // 
            this.btnViewJobsInHand.Location = new System.Drawing.Point(698, 44);
            this.btnViewJobsInHand.Name = "btnViewJobsInHand";
            this.btnViewJobsInHand.Size = new System.Drawing.Size(105, 26);
            this.btnViewJobsInHand.TabIndex = 10;
            this.btnViewJobsInHand.Text = "&View Jobs In Hand";
            this.btnViewJobsInHand.UseVisualStyleBackColor = true;
            this.btnViewJobsInHand.Click += new System.EventHandler(this.btnViewJobsInHand_Click);
            // 
            // lblThirdPartyName
            // 
            this.lblThirdPartyName.AutoSize = true;
            this.lblThirdPartyName.Location = new System.Drawing.Point(245, 35);
            this.lblThirdPartyName.Name = "lblThirdPartyName";
            this.lblThirdPartyName.Size = new System.Drawing.Size(58, 13);
            this.lblThirdPartyName.TabIndex = 4;
            this.lblThirdPartyName.Text = "Third Party";
            // 
            // lblTechName
            // 
            this.lblTechName.AutoSize = true;
            this.lblTechName.Location = new System.Drawing.Point(5, 60);
            this.lblTechName.Name = "lblTechName";
            this.lblTechName.Size = new System.Drawing.Size(63, 13);
            this.lblTechName.TabIndex = 6;
            this.lblTechName.Text = "Tech Name";
            // 
            // txtTechName
            // 
            this.txtTechName.Location = new System.Drawing.Point(70, 57);
            this.txtTechName.Name = "txtTechName";
            this.txtTechName.Size = new System.Drawing.Size(165, 20);
            this.txtTechName.TabIndex = 7;
            // 
            // txtTechCode
            // 
            this.txtTechCode.Location = new System.Drawing.Point(70, 32);
            this.txtTechCode.Name = "txtTechCode";
            this.txtTechCode.Size = new System.Drawing.Size(165, 20);
            this.txtTechCode.TabIndex = 3;
            // 
            // lblTechCode
            // 
            this.lblTechCode.AutoSize = true;
            this.lblTechCode.Location = new System.Drawing.Point(6, 35);
            this.lblTechCode.Name = "lblTechCode";
            this.lblTechCode.Size = new System.Drawing.Size(60, 13);
            this.lblTechCode.TabIndex = 2;
            this.lblTechCode.Text = "Tech Code";
            // 
            // btnGetThirdPartyTech
            // 
            this.btnGetThirdPartyTech.Location = new System.Drawing.Point(698, 14);
            this.btnGetThirdPartyTech.Name = "btnGetThirdPartyTech";
            this.btnGetThirdPartyTech.Size = new System.Drawing.Size(105, 26);
            this.btnGetThirdPartyTech.TabIndex = 8;
            this.btnGetThirdPartyTech.Text = "Get";
            this.btnGetThirdPartyTech.UseVisualStyleBackColor = true;
            this.btnGetThirdPartyTech.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Location = new System.Drawing.Point(83, 10);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(36, 17);
            this.rdoAll.TabIndex = 1;
            this.rdoAll.TabStop = true;
            this.rdoAll.Text = "All";
            this.rdoAll.UseVisualStyleBackColor = true;
            // 
            // rdoSuggested
            // 
            this.rdoSuggested.AutoSize = true;
            this.rdoSuggested.Location = new System.Drawing.Point(12, 9);
            this.rdoSuggested.Name = "rdoSuggested";
            this.rdoSuggested.Size = new System.Drawing.Size(70, 17);
            this.rdoSuggested.TabIndex = 0;
            this.rdoSuggested.TabStop = true;
            this.rdoSuggested.Text = "Suggsted";
            this.rdoSuggested.UseVisualStyleBackColor = true;
            // 
            // ctlInterService1
            // 
            this.ctlInterService1.Location = new System.Drawing.Point(307, 32);
            this.ctlInterService1.Name = "ctlInterService1";
            this.ctlInterService1.Size = new System.Drawing.Size(382, 25);
            this.ctlInterService1.TabIndex = 5;
            this.ctlInterService1.Load += new System.EventHandler(this.ctlInterService1_Load);
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
            this.lvwThirdParty.Location = new System.Drawing.Point(4, 87);
            this.lvwThirdParty.MultiSelect = false;
            this.lvwThirdParty.Name = "lvwThirdParty";
            this.lvwThirdParty.Size = new System.Drawing.Size(1009, 329);
            this.lvwThirdParty.TabIndex = 9;
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
            // frmCSDJobAssign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 448);
            this.Controls.Add(this.tcTechnicianType);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCSDJobAssign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CSD Job Assign";
            this.Load += new System.EventHandler(this.frmCSDJobAssign_Load);
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
        private System.Windows.Forms.TabPage tbThirdPartyTech;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.RadioButton rdoSuggested;
        private System.Windows.Forms.ListView lvwThirdParty;
        private System.Windows.Forms.ColumnHeader colTechnicianName;
        private System.Windows.Forms.ColumnHeader colThirdPartyID;
        private System.Windows.Forms.ColumnHeader colAddress;
        private System.Windows.Forms.ColumnHeader colPhone;
        private System.Windows.Forms.ColumnHeader colMobile;
        private System.Windows.Forms.Button btnGetThirdPartyTech;
        private System.Windows.Forms.ColumnHeader colThana;
        private System.Windows.Forms.ColumnHeader colDistrictName;
        private System.Windows.Forms.ColumnHeader colWorkshopType;
        private System.Windows.Forms.ListView lvwOwnTech;
        private System.Windows.Forms.ColumnHeader colOwnTechCode;
        private System.Windows.Forms.ColumnHeader colOwnTechName;
        private System.Windows.Forms.ColumnHeader colOwnTechWorkshopType;
        private System.Windows.Forms.Button btnGetOwnTech;
        private System.Windows.Forms.TextBox txtTechName;
        private System.Windows.Forms.TextBox txtTechCode;
        private System.Windows.Forms.Label lblTechCode;
        private System.Windows.Forms.Label lblThirdPartyName;
        private System.Windows.Forms.Label lblTechName;
        private System.Windows.Forms.ColumnHeader colTechCode;
        private ctlInterService ctlInterService1;
        private System.Windows.Forms.Button btnViewJobsInHand;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOwnTechNameSearch;
        private System.Windows.Forms.TextBox txtOwnTechCodeSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnViewJob_OwnTech;
        private System.Windows.Forms.ColumnHeader colWorkshopLoctionName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbWorkshopLocation;
    }
}
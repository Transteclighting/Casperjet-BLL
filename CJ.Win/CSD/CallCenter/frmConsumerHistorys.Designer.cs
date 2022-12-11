namespace CJ.Win.CSD.CallCenter
{
    partial class frmConsumerHistorys
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsumerHistorys));
            this.label4 = new System.Windows.Forms.Label();
            this.txtMobileNo = new System.Windows.Forms.TextBox();
            this.lvwConsumerDetails = new System.Windows.Forms.ListView();
            this.colConsumerCode = new System.Windows.Forms.ColumnHeader();
            this.colConsumerName = new System.Windows.Forms.ColumnHeader();
            this.colMobile = new System.Windows.Forms.ColumnHeader();
            this.colAlternativeNo = new System.Windows.Forms.ColumnHeader();
            this.colTelephoneNo = new System.Windows.Forms.ColumnHeader();
            this.colAddress = new System.Windows.Forms.ColumnHeader();
            this.colEmail = new System.Windows.Forms.ColumnHeader();
            this.colIsVerified = new System.Windows.Forms.ColumnHeader();
            this.btnGetHistory = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnGetData = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Mobile No";
            // 
            // txtMobileNo
            // 
            this.txtMobileNo.Location = new System.Drawing.Point(71, 12);
            this.txtMobileNo.Name = "txtMobileNo";
            this.txtMobileNo.Size = new System.Drawing.Size(195, 20);
            this.txtMobileNo.TabIndex = 6;
            // 
            // lvwConsumerDetails
            // 
            this.lvwConsumerDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwConsumerDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colConsumerCode,
            this.colConsumerName,
            this.colMobile,
            this.colAlternativeNo,
            this.colTelephoneNo,
            this.colAddress,
            this.colEmail,
            this.colIsVerified});
            this.lvwConsumerDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwConsumerDetails.FullRowSelect = true;
            this.lvwConsumerDetails.GridLines = true;
            this.lvwConsumerDetails.HideSelection = false;
            this.lvwConsumerDetails.Location = new System.Drawing.Point(15, 39);
            this.lvwConsumerDetails.MultiSelect = false;
            this.lvwConsumerDetails.Name = "lvwConsumerDetails";
            this.lvwConsumerDetails.Size = new System.Drawing.Size(791, 387);
            this.lvwConsumerDetails.TabIndex = 16;
            this.lvwConsumerDetails.UseCompatibleStateImageBehavior = false;
            this.lvwConsumerDetails.View = System.Windows.Forms.View.Details;
            // 
            // colConsumerCode
            // 
            this.colConsumerCode.Text = "Consumer Code";
            this.colConsumerCode.Width = 99;
            // 
            // colConsumerName
            // 
            this.colConsumerName.Text = "Consumer Name";
            this.colConsumerName.Width = 136;
            // 
            // colMobile
            // 
            this.colMobile.Text = "Mobile No";
            this.colMobile.Width = 102;
            // 
            // colAlternativeNo
            // 
            this.colAlternativeNo.Text = "Alternative Cell No";
            this.colAlternativeNo.Width = 101;
            // 
            // colTelephoneNo
            // 
            this.colTelephoneNo.Text = "Telephone No";
            this.colTelephoneNo.Width = 93;
            // 
            // colAddress
            // 
            this.colAddress.Text = "Address";
            this.colAddress.Width = 284;
            // 
            // colEmail
            // 
            this.colEmail.Text = "Email";
            this.colEmail.Width = 132;
            // 
            // colIsVerified
            // 
            this.colIsVerified.Text = "Is Verified";
            // 
            // btnGetHistory
            // 
            this.btnGetHistory.Location = new System.Drawing.Point(815, 39);
            this.btnGetHistory.Name = "btnGetHistory";
            this.btnGetHistory.Size = new System.Drawing.Size(75, 23);
            this.btnGetHistory.TabIndex = 17;
            this.btnGetHistory.Text = "Get History";
            this.btnGetHistory.UseVisualStyleBackColor = true;
            this.btnGetHistory.Click += new System.EventHandler(this.btnGetHistory_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(810, 403);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnGetData
            // 
            this.btnGetData.Location = new System.Drawing.Point(272, 10);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(75, 23);
            this.btnGetData.TabIndex = 15;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.LightPink;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(68, 433);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(62, 13);
            this.label18.TabIndex = 145;
            this.label18.Text = "Not Verified";
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.White;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(12, 433);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(42, 13);
            this.label20.TabIndex = 144;
            this.label20.Text = "Verified";
            // 
            // frmConsumerHistorys
            // 
            this.AcceptButton = this.btnGetData;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 451);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnGetHistory);
            this.Controls.Add(this.lvwConsumerDetails);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMobileNo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConsumerHistorys";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consumer Detail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtMobileNo;
        private System.Windows.Forms.ListView lvwConsumerDetails;
        private System.Windows.Forms.ColumnHeader colConsumerCode;
        private System.Windows.Forms.ColumnHeader colConsumerName;
        private System.Windows.Forms.ColumnHeader colMobile;
        private System.Windows.Forms.ColumnHeader colAlternativeNo;
        private System.Windows.Forms.ColumnHeader colAddress;
        private System.Windows.Forms.ColumnHeader colEmail;
        private System.Windows.Forms.ColumnHeader colTelephoneNo;
        private System.Windows.Forms.Button btnGetHistory;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.ColumnHeader colIsVerified;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
    }
}
namespace CJ.Win
{
    partial class frmSMSIndenting
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btSMSIndentingReport = new System.Windows.Forms.Button();
            this.lblReceivdate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btClose = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.lbMobileno = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lbcustomercode = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbcustomeraddress = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbcustomername = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btReport = new System.Windows.Forms.Button();
            this.btMakeOrder = new System.Windows.Forms.Button();
            this.btShowIndent = new System.Windows.Forms.Button();
            this.cbSMSId = new System.Windows.Forms.ComboBox();
            this.lbMno = new System.Windows.Forms.Label();
            this.lvOrderDetails = new System.Windows.Forms.ListView();
            this.colproductcode = new System.Windows.Forms.ColumnHeader();
            this.colproductname = new System.Windows.Forms.ColumnHeader();
            this.colquntity = new System.Windows.Forms.ColumnHeader();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btSave = new System.Windows.Forms.Button();
            this.btRefresh = new System.Windows.Forms.Button();
            this.lvwSMSIndenting = new System.Windows.Forms.ListView();
            this.colSMSId = new System.Windows.Forms.ColumnHeader();
            this.colReceiveDate = new System.Windows.Forms.ColumnHeader();
            this.colSMS = new System.Windows.Forms.ColumnHeader();
            this.colMessageType = new System.Windows.Forms.ColumnHeader();
            this.colMobile = new System.Windows.Forms.ColumnHeader();
            this.colStatus = new System.Windows.Forms.ColumnHeader();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Silver;
            this.groupBox1.Controls.Add(this.btSMSIndentingReport);
            this.groupBox1.Controls.Add(this.lblReceivdate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btClose);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lbMobileno);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.lbcustomercode);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lbcustomeraddress);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lbcustomername);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btReport);
            this.groupBox1.Controls.Add(this.btMakeOrder);
            this.groupBox1.Controls.Add(this.btShowIndent);
            this.groupBox1.Controls.Add(this.cbSMSId);
            this.groupBox1.Controls.Add(this.lbMno);
            this.groupBox1.Controls.Add(this.lvOrderDetails);
            this.groupBox1.Location = new System.Drawing.Point(476, 1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(515, 473);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btSMSIndentingReport
            // 
            this.btSMSIndentingReport.Location = new System.Drawing.Point(110, 433);
            this.btSMSIndentingReport.Name = "btSMSIndentingReport";
            this.btSMSIndentingReport.Size = new System.Drawing.Size(89, 23);
            this.btSMSIndentingReport.TabIndex = 49;
            this.btSMSIndentingReport.Text = "Print Indent";
            this.btSMSIndentingReport.UseVisualStyleBackColor = true;
            this.btSMSIndentingReport.Click += new System.EventHandler(this.btSMSIndentingReport_Click);
            // 
            // lblReceivdate
            // 
            this.lblReceivdate.AutoSize = true;
            this.lblReceivdate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceivdate.Location = new System.Drawing.Point(156, 389);
            this.lblReceivdate.Name = "lblReceivdate";
            this.lblReceivdate.Size = new System.Drawing.Size(28, 16);
            this.lblReceivdate.TabIndex = 48;
            this.lblReceivdate.Text = ".....";
            this.lblReceivdate.Click += new System.EventHandler(this.lblReceivdate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(55, 388);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 47;
            this.label2.Text = "Rec. Date :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(378, 437);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(77, 23);
            this.btClose.TabIndex = 46;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(171, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(109, 20);
            this.label10.TabIndex = 45;
            this.label10.Text = "Oder Details";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // lbMobileno
            // 
            this.lbMobileno.AutoSize = true;
            this.lbMobileno.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMobileno.Location = new System.Drawing.Point(156, 366);
            this.lbMobileno.Name = "lbMobileno";
            this.lbMobileno.Size = new System.Drawing.Size(28, 16);
            this.lbMobileno.TabIndex = 44;
            this.lbMobileno.Text = ".....";
            this.lbMobileno.Click += new System.EventHandler(this.lbMobileno_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(55, 366);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 16);
            this.label8.TabIndex = 43;
            this.label8.Text = "Mobile No :";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // lbcustomercode
            // 
            this.lbcustomercode.AutoSize = true;
            this.lbcustomercode.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbcustomercode.Location = new System.Drawing.Point(156, 295);
            this.lbcustomercode.Name = "lbcustomercode";
            this.lbcustomercode.Size = new System.Drawing.Size(28, 16);
            this.lbcustomercode.TabIndex = 42;
            this.lbcustomercode.Text = ".....";
            this.lbcustomercode.Click += new System.EventHandler(this.lbcustomercode_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(30, 293);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 16);
            this.label6.TabIndex = 41;
            this.label6.Text = "CustomerCode:";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // lbcustomeraddress
            // 
            this.lbcustomeraddress.AutoSize = true;
            this.lbcustomeraddress.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbcustomeraddress.Location = new System.Drawing.Point(156, 343);
            this.lbcustomeraddress.Name = "lbcustomeraddress";
            this.lbcustomeraddress.Size = new System.Drawing.Size(28, 16);
            this.lbcustomeraddress.TabIndex = 40;
            this.lbcustomeraddress.Text = ".....";
            this.lbcustomeraddress.Click += new System.EventHandler(this.lbcustomeraddress_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 343);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 16);
            this.label4.TabIndex = 39;
            this.label4.Text = "Customer Address: ";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // lbcustomername
            // 
            this.lbcustomername.AutoSize = true;
            this.lbcustomername.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbcustomername.Location = new System.Drawing.Point(156, 317);
            this.lbcustomername.Name = "lbcustomername";
            this.lbcustomername.Size = new System.Drawing.Size(28, 16);
            this.lbcustomername.TabIndex = 38;
            this.lbcustomername.Text = ".....";
            this.lbcustomername.Click += new System.EventHandler(this.lbcustomername_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 317);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 16);
            this.label1.TabIndex = 37;
            this.label1.Text = "Customer Name: ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btReport
            // 
            this.btReport.Location = new System.Drawing.Point(9, 433);
            this.btReport.Name = "btReport";
            this.btReport.Size = new System.Drawing.Size(95, 23);
            this.btReport.TabIndex = 36;
            this.btReport.Text = "Search Indent";
            this.btReport.UseVisualStyleBackColor = true;
            this.btReport.Click += new System.EventHandler(this.btReport_Click);
            // 
            // btMakeOrder
            // 
            this.btMakeOrder.Location = new System.Drawing.Point(291, 437);
            this.btMakeOrder.Name = "btMakeOrder";
            this.btMakeOrder.Size = new System.Drawing.Size(77, 23);
            this.btMakeOrder.TabIndex = 35;
            this.btMakeOrder.Text = "Make Order";
            this.btMakeOrder.UseVisualStyleBackColor = true;
            this.btMakeOrder.Click += new System.EventHandler(this.btMakeOrder_Click);
            // 
            // btShowIndent
            // 
            this.btShowIndent.Location = new System.Drawing.Point(98, 11);
            this.btShowIndent.Name = "btShowIndent";
            this.btShowIndent.Size = new System.Drawing.Size(83, 23);
            this.btShowIndent.TabIndex = 34;
            this.btShowIndent.Text = "Show Indent";
            this.btShowIndent.UseVisualStyleBackColor = true;
            this.btShowIndent.Click += new System.EventHandler(this.btShowIndent_Click);
            // 
            // cbSMSId
            // 
            this.cbSMSId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSMSId.FormattingEnabled = true;
            this.cbSMSId.Location = new System.Drawing.Point(291, 13);
            this.cbSMSId.Name = "cbSMSId";
            this.cbSMSId.Size = new System.Drawing.Size(106, 21);
            this.cbSMSId.TabIndex = 33;
            this.cbSMSId.SelectedIndexChanged += new System.EventHandler(this.cbSMSId_SelectedIndexChanged);
            // 
            // lbMno
            // 
            this.lbMno.AutoSize = true;
            this.lbMno.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMno.Location = new System.Drawing.Point(192, 14);
            this.lbMno.Name = "lbMno";
            this.lbMno.Size = new System.Drawing.Size(93, 16);
            this.lbMno.TabIndex = 32;
            this.lbMno.Text = "Messsage No";
            this.lbMno.Click += new System.EventHandler(this.lbMno_Click);
            // 
            // lvOrderDetails
            // 
            this.lvOrderDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvOrderDetails.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colproductcode,
            this.colproductname,
            this.colquntity});
            this.lvOrderDetails.FullRowSelect = true;
            this.lvOrderDetails.GridLines = true;
            this.lvOrderDetails.Location = new System.Drawing.Point(6, 67);
            this.lvOrderDetails.Name = "lvOrderDetails";
            this.lvOrderDetails.Size = new System.Drawing.Size(426, 228);
            this.lvOrderDetails.TabIndex = 31;
            this.lvOrderDetails.UseCompatibleStateImageBehavior = false;
            this.lvOrderDetails.View = System.Windows.Forms.View.Details;
            this.lvOrderDetails.SelectedIndexChanged += new System.EventHandler(this.lvOrderDetails_SelectedIndexChanged);
            // 
            // colproductcode
            // 
            this.colproductcode.Text = "Product Code";
            this.colproductcode.Width = 100;
            // 
            // colproductname
            // 
            this.colproductname.Text = "Product Name";
            this.colproductname.Width = 255;
            // 
            // colquntity
            // 
            this.colquntity.Text = "Quntity";
            this.colquntity.Width = 80;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Silver;
            this.groupBox2.Controls.Add(this.btSave);
            this.groupBox2.Controls.Add(this.btRefresh);
            this.groupBox2.Controls.Add(this.lvwSMSIndenting);
            this.groupBox2.Location = new System.Drawing.Point(12, 1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(458, 462);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(222, 433);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 6;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click_1);
            // 
            // btRefresh
            // 
            this.btRefresh.Location = new System.Drawing.Point(118, 433);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(75, 23);
            this.btRefresh.TabIndex = 5;
            this.btRefresh.Text = "Refresh";
            this.btRefresh.UseVisualStyleBackColor = true;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click_1);
            // 
            // lvwSMSIndenting
            // 
            this.lvwSMSIndenting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwSMSIndenting.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSMSId,
            this.colReceiveDate,
            this.colSMS,
            this.colMessageType,
            this.colMobile,
            this.colStatus});
            this.lvwSMSIndenting.FullRowSelect = true;
            this.lvwSMSIndenting.GridLines = true;
            this.lvwSMSIndenting.Location = new System.Drawing.Point(6, 13);
            this.lvwSMSIndenting.Name = "lvwSMSIndenting";
            this.lvwSMSIndenting.Size = new System.Drawing.Size(446, 368);
            this.lvwSMSIndenting.TabIndex = 4;
            this.lvwSMSIndenting.UseCompatibleStateImageBehavior = false;
            this.lvwSMSIndenting.View = System.Windows.Forms.View.Details;
            this.lvwSMSIndenting.SelectedIndexChanged += new System.EventHandler(this.lvwSMSIndenting_SelectedIndexChanged);
            // 
            // colSMSId
            // 
            this.colSMSId.Text = "SMSmessage ID";
            this.colSMSId.Width = 100;
            // 
            // colReceiveDate
            // 
            this.colReceiveDate.Text = "Receive Date";
            this.colReceiveDate.Width = 100;
            // 
            // colSMS
            // 
            this.colSMS.Text = "SMS Text";
            this.colSMS.Width = 255;
            // 
            // colMessageType
            // 
            this.colMessageType.Text = "Message Type";
            this.colMessageType.Width = 80;
            // 
            // colMobile
            // 
            this.colMobile.Text = "Mobile No";
            this.colMobile.Width = 150;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 100;
            // 
            // frmSMSIndenting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 473);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmSMSIndenting";
            this.Text = "SMS Indenting";
            this.Load += new System.EventHandler(this.frmSMSIndenting_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbMobileno;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbcustomercode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbcustomeraddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbcustomername;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btReport;
        private System.Windows.Forms.Button btMakeOrder;
        private System.Windows.Forms.Button btShowIndent;
        private System.Windows.Forms.ComboBox cbSMSId;
        private System.Windows.Forms.Label lbMno;
        private System.Windows.Forms.ListView lvOrderDetails;
        private System.Windows.Forms.ColumnHeader colproductcode;
        private System.Windows.Forms.ColumnHeader colproductname;
        private System.Windows.Forms.ColumnHeader colquntity;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btRefresh;
        private System.Windows.Forms.ListView lvwSMSIndenting;
        private System.Windows.Forms.ColumnHeader colSMSId;
        private System.Windows.Forms.ColumnHeader colReceiveDate;
        private System.Windows.Forms.ColumnHeader colSMS;
        private System.Windows.Forms.ColumnHeader colMessageType;
        private System.Windows.Forms.ColumnHeader colMobile;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Label lblReceivdate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btSMSIndentingReport;
    }
}
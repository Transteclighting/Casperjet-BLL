namespace CJ.Win
{
    partial class frmISVPartsRequisitionHistory
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabRequisitionIssue = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lvwPending = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.lvwIssue = new System.Windows.Forms.ListView();
            this.colPartCode = new System.Windows.Forms.ColumnHeader();
            this.colPartName = new System.Windows.Forms.ColumnHeader();
            this.colQty = new System.Windows.Forms.ColumnHeader();
            this.colJobNo = new System.Windows.Forms.ColumnHeader();
            this.colProductName = new System.Windows.Forms.ColumnHeader();
            this.colIssueFrom = new System.Windows.Forms.ColumnHeader();
            this.colLoanNo = new System.Windows.Forms.ColumnHeader();
            this.tabCommunication = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPrepareDate = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblReceiveDate = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblSerialNo = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblReportNo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblInterService = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRequisitionID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lvwCommu = new System.Windows.Forms.ListView();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.lvwSend = new System.Windows.Forms.ListView();
            this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader17 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader18 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader19 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader20 = new System.Windows.Forms.ColumnHeader();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabRequisitionIssue.SuspendLayout();
            this.tabCommunication.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabRequisitionIssue);
            this.tabControl1.Controls.Add(this.tabCommunication);
            this.tabControl1.Location = new System.Drawing.Point(20, 70);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(685, 356);
            this.tabControl1.TabIndex = 0;
            // 
            // tabRequisitionIssue
            // 
            this.tabRequisitionIssue.BackColor = System.Drawing.Color.Silver;
            this.tabRequisitionIssue.Controls.Add(this.label8);
            this.tabRequisitionIssue.Controls.Add(this.label2);
            this.tabRequisitionIssue.Controls.Add(this.lvwPending);
            this.tabRequisitionIssue.Controls.Add(this.lvwIssue);
            this.tabRequisitionIssue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabRequisitionIssue.Location = new System.Drawing.Point(4, 22);
            this.tabRequisitionIssue.Name = "tabRequisitionIssue";
            this.tabRequisitionIssue.Padding = new System.Windows.Forms.Padding(3);
            this.tabRequisitionIssue.Size = new System.Drawing.Size(677, 330);
            this.tabRequisitionIssue.TabIndex = 0;
            this.tabRequisitionIssue.Text = "Requisition/Issue";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(6, 163);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(665, 13);
            this.label8.TabIndex = 221;
            this.label8.Text = "Pending";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Thistle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(6, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(665, 13);
            this.label2.TabIndex = 220;
            this.label2.Text = "Issue";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lvwPending
            // 
            this.lvwPending.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwPending.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lvwPending.FullRowSelect = true;
            this.lvwPending.GridLines = true;
            this.lvwPending.Location = new System.Drawing.Point(3, 178);
            this.lvwPending.MultiSelect = false;
            this.lvwPending.Name = "lvwPending";
            this.lvwPending.Size = new System.Drawing.Size(668, 146);
            this.lvwPending.TabIndex = 209;
            this.lvwPending.UseCompatibleStateImageBehavior = false;
            this.lvwPending.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Part Code";
            this.columnHeader1.Width = 86;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Part Name";
            this.columnHeader2.Width = 151;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Qty";
            this.columnHeader3.Width = 38;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Job No";
            this.columnHeader4.Width = 77;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Product Name";
            this.columnHeader5.Width = 151;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Status";
            this.columnHeader6.Width = 80;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "EDD";
            this.columnHeader7.Width = 78;
            // 
            // lvwIssue
            // 
            this.lvwIssue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwIssue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPartCode,
            this.colPartName,
            this.colQty,
            this.colJobNo,
            this.colProductName,
            this.colIssueFrom,
            this.colLoanNo});
            this.lvwIssue.FullRowSelect = true;
            this.lvwIssue.GridLines = true;
            this.lvwIssue.Location = new System.Drawing.Point(3, 22);
            this.lvwIssue.MultiSelect = false;
            this.lvwIssue.Name = "lvwIssue";
            this.lvwIssue.Size = new System.Drawing.Size(668, 129);
            this.lvwIssue.TabIndex = 208;
            this.lvwIssue.UseCompatibleStateImageBehavior = false;
            this.lvwIssue.View = System.Windows.Forms.View.Details;
            // 
            // colPartCode
            // 
            this.colPartCode.Text = "Part Code";
            this.colPartCode.Width = 86;
            // 
            // colPartName
            // 
            this.colPartName.Text = "Part Name";
            this.colPartName.Width = 151;
            // 
            // colQty
            // 
            this.colQty.Text = "Qty";
            this.colQty.Width = 38;
            // 
            // colJobNo
            // 
            this.colJobNo.Text = "Job No";
            this.colJobNo.Width = 77;
            // 
            // colProductName
            // 
            this.colProductName.Text = "Product Name";
            this.colProductName.Width = 151;
            // 
            // colIssueFrom
            // 
            this.colIssueFrom.Text = "Issue From";
            this.colIssueFrom.Width = 71;
            // 
            // colLoanNo
            // 
            this.colLoanNo.Text = "Loan Code";
            this.colLoanNo.Width = 78;
            // 
            // tabCommunication
            // 
            this.tabCommunication.BackColor = System.Drawing.Color.Bisque;
            this.tabCommunication.Controls.Add(this.label10);
            this.tabCommunication.Controls.Add(this.label9);
            this.tabCommunication.Controls.Add(this.lvwSend);
            this.tabCommunication.Controls.Add(this.lvwCommu);
            this.tabCommunication.Location = new System.Drawing.Point(4, 22);
            this.tabCommunication.Name = "tabCommunication";
            this.tabCommunication.Padding = new System.Windows.Forms.Padding(3);
            this.tabCommunication.Size = new System.Drawing.Size(677, 330);
            this.tabCommunication.TabIndex = 1;
            this.tabCommunication.Text = "Communication/Delivery";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPrepareDate);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.lblReceiveDate);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lblSerialNo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblReportNo);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.lblInterService);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblRequisitionID);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(711, 53);
            this.groupBox1.TabIndex = 221;
            this.groupBox1.TabStop = false;
            // 
            // lblPrepareDate
            // 
            this.lblPrepareDate.AutoSize = true;
            this.lblPrepareDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrepareDate.Location = new System.Drawing.Point(604, 35);
            this.lblPrepareDate.Name = "lblPrepareDate";
            this.lblPrepareDate.Size = new System.Drawing.Size(14, 13);
            this.lblPrepareDate.TabIndex = 219;
            this.lblPrepareDate.Text = "?";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(506, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 13);
            this.label7.TabIndex = 218;
            this.label7.Text = "Prepare Date :";
            // 
            // lblReceiveDate
            // 
            this.lblReceiveDate.AutoSize = true;
            this.lblReceiveDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiveDate.Location = new System.Drawing.Point(604, 11);
            this.lblReceiveDate.Name = "lblReceiveDate";
            this.lblReceiveDate.Size = new System.Drawing.Size(14, 13);
            this.lblReceiveDate.TabIndex = 217;
            this.lblReceiveDate.Text = "?";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(506, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 13);
            this.label6.TabIndex = 216;
            this.label6.Text = "Receive Date :";
            // 
            // lblSerialNo
            // 
            this.lblSerialNo.AutoSize = true;
            this.lblSerialNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerialNo.Location = new System.Drawing.Point(424, 11);
            this.lblSerialNo.Name = "lblSerialNo";
            this.lblSerialNo.Size = new System.Drawing.Size(14, 13);
            this.lblSerialNo.TabIndex = 215;
            this.lblSerialNo.Text = "?";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(354, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 214;
            this.label5.Text = "Serial No :";
            // 
            // lblReportNo
            // 
            this.lblReportNo.AutoSize = true;
            this.lblReportNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReportNo.Location = new System.Drawing.Point(276, 11);
            this.lblReportNo.Name = "lblReportNo";
            this.lblReportNo.Size = new System.Drawing.Size(14, 13);
            this.lblReportNo.TabIndex = 213;
            this.lblReportNo.Text = "?";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(198, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 13);
            this.label4.TabIndex = 212;
            this.label4.Text = "Report No :";
            // 
            // lblInterService
            // 
            this.lblInterService.AutoSize = true;
            this.lblInterService.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInterService.Location = new System.Drawing.Point(113, 35);
            this.lblInterService.Name = "lblInterService";
            this.lblInterService.Size = new System.Drawing.Size(14, 13);
            this.lblInterService.TabIndex = 211;
            this.lblInterService.Text = "?";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 210;
            this.label3.Text = "Inter Service :";
            // 
            // lblRequisitionID
            // 
            this.lblRequisitionID.AutoSize = true;
            this.lblRequisitionID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRequisitionID.Location = new System.Drawing.Point(113, 11);
            this.lblRequisitionID.Name = "lblRequisitionID";
            this.lblRequisitionID.Size = new System.Drawing.Size(14, 13);
            this.lblRequisitionID.TabIndex = 209;
            this.lblRequisitionID.Text = "?";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 208;
            this.label1.Text = "Requisition ID :";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(609, 432);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 27);
            this.btnClose.TabIndex = 222;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // lvwCommu
            // 
            this.lvwCommu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwCommu.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader8,
            this.columnHeader9});
            this.lvwCommu.FullRowSelect = true;
            this.lvwCommu.GridLines = true;
            this.lvwCommu.Location = new System.Drawing.Point(3, 25);
            this.lvwCommu.MultiSelect = false;
            this.lvwCommu.Name = "lvwCommu";
            this.lvwCommu.Size = new System.Drawing.Size(668, 129);
            this.lvwCommu.TabIndex = 209;
            this.lvwCommu.UseCompatibleStateImageBehavior = false;
            this.lvwCommu.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Communication Date";
            this.columnHeader8.Width = 178;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Communicated By";
            this.columnHeader9.Width = 151;
            // 
            // lvwSend
            // 
            this.lvwSend.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwSend.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader20});
            this.lvwSend.FullRowSelect = true;
            this.lvwSend.GridLines = true;
            this.lvwSend.Location = new System.Drawing.Point(3, 180);
            this.lvwSend.MultiSelect = false;
            this.lvwSend.Name = "lvwSend";
            this.lvwSend.Size = new System.Drawing.Size(668, 129);
            this.lvwSend.TabIndex = 211;
            this.lvwSend.UseCompatibleStateImageBehavior = false;
            this.lvwSend.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "Date";
            this.columnHeader15.Width = 89;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "Mode of Delivery";
            this.columnHeader16.Width = 97;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "Courier Name";
            this.columnHeader17.Width = 183;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "Consignment No";
            this.columnHeader18.Width = 99;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "Received By";
            this.columnHeader19.Width = 85;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "Remarks";
            this.columnHeader20.Width = 110;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Green;
            this.label9.Location = new System.Drawing.Point(5, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(665, 13);
            this.label9.TabIndex = 221;
            this.label9.Text = "Communication";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.DarkSalmon;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Blue;
            this.label10.Location = new System.Drawing.Point(6, 164);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(665, 13);
            this.label10.TabIndex = 222;
            this.label10.Text = "Delivery";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmISVPartsRequisitionHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 464);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmISVPartsRequisitionHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmISVPartsRequisitionHistory";
            this.Load += new System.EventHandler(this.frmISVPartsRequisitionHistory_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabRequisitionIssue.ResumeLayout(false);
            this.tabCommunication.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabRequisitionIssue;
        private System.Windows.Forms.TabPage tabCommunication;
        private System.Windows.Forms.ListView lvwPending;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ListView lvwIssue;
        private System.Windows.Forms.ColumnHeader colPartCode;
        private System.Windows.Forms.ColumnHeader colPartName;
        private System.Windows.Forms.ColumnHeader colQty;
        private System.Windows.Forms.ColumnHeader colJobNo;
        private System.Windows.Forms.ColumnHeader colProductName;
        private System.Windows.Forms.ColumnHeader colIssueFrom;
        private System.Windows.Forms.ColumnHeader colLoanNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblPrepareDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblReceiveDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblSerialNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblReportNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblInterService;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRequisitionID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListView lvwCommu;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListView lvwSend;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private System.Windows.Forms.ColumnHeader columnHeader18;
        private System.Windows.Forms.ColumnHeader columnHeader19;
        private System.Windows.Forms.ColumnHeader columnHeader20;
    }
}
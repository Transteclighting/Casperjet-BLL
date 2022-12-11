namespace CJ.Win.DMS
{
    partial class frmDMSReplaceClaim
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
            this.cmbClaimNo = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dvwReplacement = new System.Windows.Forms.DataGridView();
            this.ProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubClaimNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProductName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnProcess = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSubClaimNo = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.TxtCartonQty = new System.Windows.Forms.TextBox();
            this.lblCartonQty = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtRemarks = new System.Windows.Forms.TextBox();
            this.btnVerified = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnVeifiedPrint = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnload = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctlCustomer1 = new CJ.Win.Control.ctlCustomer();
            ((System.ComponentModel.ISupportInitialize)(this.dvwReplacement)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbClaimNo
            // 
            this.cmbClaimNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbClaimNo.FormattingEnabled = true;
            this.cmbClaimNo.Location = new System.Drawing.Point(176, 66);
            this.cmbClaimNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbClaimNo.Name = "cmbClaimNo";
            this.cmbClaimNo.Size = new System.Drawing.Size(202, 28);
            this.cmbClaimNo.TabIndex = 86;
            this.cmbClaimNo.SelectedIndexChanged += new System.EventHandler(this.cmbClaimNo_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 70);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 85;
            this.label4.Text = "ClaimNo";
            // 
            // dvwReplacement
            // 
            this.dvwReplacement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvwReplacement.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProductID,
            this.SubClaimNo,
            this.ProductCode,
            this.ProductName,
            this.Qty});
            this.dvwReplacement.Location = new System.Drawing.Point(18, 142);
            this.dvwReplacement.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dvwReplacement.Name = "dvwReplacement";
            this.dvwReplacement.Size = new System.Drawing.Size(1126, 629);
            this.dvwReplacement.TabIndex = 88;
            // 
            // ProductID
            // 
            this.ProductID.HeaderText = "ProductID";
            this.ProductID.Name = "ProductID";
            this.ProductID.Visible = false;
            // 
            // SubClaimNo
            // 
            this.SubClaimNo.HeaderText = "SubClaimNo";
            this.SubClaimNo.Name = "SubClaimNo";
            this.SubClaimNo.Visible = false;
            // 
            // ProductCode
            // 
            this.ProductCode.HeaderText = "Product Code";
            this.ProductCode.Name = "ProductCode";
            this.ProductCode.Width = 70;
            // 
            // ProductName
            // 
            this.ProductName.HeaderText = "Product Name";
            this.ProductName.Name = "ProductName";
            this.ProductName.Width = 200;
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Quantity";
            this.Qty.Name = "Qty";
            this.Qty.Width = 80;
            // 
            // btnProcess
            // 
            this.btnProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnProcess.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcess.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnProcess.Location = new System.Drawing.Point(1145, 142);
            this.btnProcess.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(142, 43);
            this.btnProcess.TabIndex = 89;
            this.btnProcess.Text = "Save";
            this.btnProcess.UseVisualStyleBackColor = false;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 107);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 20);
            this.label1.TabIndex = 90;
            this.label1.Text = "Sub ClaimNo";
            // 
            // cmbSubClaimNo
            // 
            this.cmbSubClaimNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubClaimNo.FormattingEnabled = true;
            this.cmbSubClaimNo.Location = new System.Drawing.Point(176, 107);
            this.cmbSubClaimNo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbSubClaimNo.Name = "cmbSubClaimNo";
            this.cmbSubClaimNo.Size = new System.Drawing.Size(202, 28);
            this.cmbSubClaimNo.TabIndex = 91;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(970, 55);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 35);
            this.button1.TabIndex = 92;
            this.button1.Text = "Get Data";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // TxtCartonQty
            // 
            this.TxtCartonQty.Location = new System.Drawing.Point(502, 66);
            this.TxtCartonQty.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TxtCartonQty.Name = "TxtCartonQty";
            this.TxtCartonQty.Size = new System.Drawing.Size(229, 26);
            this.TxtCartonQty.TabIndex = 93;
            this.TxtCartonQty.Visible = false;
            // 
            // lblCartonQty
            // 
            this.lblCartonQty.AutoSize = true;
            this.lblCartonQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCartonQty.Location = new System.Drawing.Point(387, 66);
            this.lblCartonQty.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCartonQty.Name = "lblCartonQty";
            this.lblCartonQty.Size = new System.Drawing.Size(94, 20);
            this.lblCartonQty.TabIndex = 94;
            this.lblCartonQty.Text = "CartonQty";
            this.lblCartonQty.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(387, 107);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 20);
            this.label2.TabIndex = 95;
            this.label2.Text = "Remarks";
            // 
            // TxtRemarks
            // 
            this.TxtRemarks.Location = new System.Drawing.Point(502, 107);
            this.TxtRemarks.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TxtRemarks.Name = "TxtRemarks";
            this.TxtRemarks.Size = new System.Drawing.Size(640, 26);
            this.TxtRemarks.TabIndex = 96;
            // 
            // btnVerified
            // 
            this.btnVerified.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVerified.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnVerified.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerified.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnVerified.Location = new System.Drawing.Point(1145, 268);
            this.btnVerified.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnVerified.Name = "btnVerified";
            this.btnVerified.Size = new System.Drawing.Size(142, 54);
            this.btnVerified.TabIndex = 97;
            this.btnVerified.Text = "Verified";
            this.btnVerified.UseVisualStyleBackColor = false;
            this.btnVerified.Visible = false;
            this.btnVerified.Click += new System.EventHandler(this.btnVerified_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnPrint.Location = new System.Drawing.Point(1145, 428);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(142, 51);
            this.btnPrint.TabIndex = 98;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Visible = false;
            this.btnPrint.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnVeifiedPrint
            // 
            this.btnVeifiedPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnVeifiedPrint.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnVeifiedPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVeifiedPrint.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnVeifiedPrint.Location = new System.Drawing.Point(1145, 349);
            this.btnVeifiedPrint.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnVeifiedPrint.Name = "btnVeifiedPrint";
            this.btnVeifiedPrint.Size = new System.Drawing.Size(142, 55);
            this.btnVeifiedPrint.TabIndex = 99;
            this.btnVeifiedPrint.Text = "Print";
            this.btnVeifiedPrint.UseVisualStyleBackColor = false;
            this.btnVeifiedPrint.Visible = false;
            this.btnVeifiedPrint.Click += new System.EventHandler(this.btnVeifiedPrint_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.lblTo);
            this.groupBox1.Controls.Add(this.dtToDate);
            this.groupBox1.Controls.Add(this.dtFromDate);
            this.groupBox1.Location = new System.Drawing.Point(806, -5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(466, 51);
            this.groupBox1.TabIndex = 100;
            this.groupBox1.TabStop = false;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(4, 18);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 20);
            this.label10.TabIndex = 0;
            this.label10.Text = "Entry Date";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(261, 20);
            this.lblTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(30, 20);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "To";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(296, 15);
            this.dtToDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(146, 26);
            this.dtToDate.TabIndex = 3;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(108, 15);
            this.dtFromDate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(150, 26);
            this.dtFromDate.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(30, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 20);
            this.label3.TabIndex = 102;
            this.label3.Text = "Customer Code";
            // 
            // btnload
            // 
            this.btnload.Location = new System.Drawing.Point(806, 55);
            this.btnload.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnload.Name = "btnload";
            this.btnload.Size = new System.Drawing.Size(94, 35);
            this.btnload.TabIndex = 104;
            this.btnload.Text = "Load Data";
            this.btnload.UseVisualStyleBackColor = true;
            this.btnload.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnClose.Location = new System.Drawing.Point(1145, 203);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(142, 45);
            this.btnClose.TabIndex = 105;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctlCustomer1
            // 
            this.ctlCustomer1.Location = new System.Drawing.Point(177, 8);
            this.ctlCustomer1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.ctlCustomer1.Name = "ctlCustomer1";
            this.ctlCustomer1.Size = new System.Drawing.Size(621, 50);
            this.ctlCustomer1.TabIndex = 103;
            // 
            // frmDMSReplaceClaim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1289, 812);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnload);
            this.Controls.Add(this.ctlCustomer1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnVeifiedPrint);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnVerified);
            this.Controls.Add(this.TxtRemarks);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblCartonQty);
            this.Controls.Add(this.TxtCartonQty);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbSubClaimNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.dvwReplacement);
            this.Controls.Add(this.cmbClaimNo);
            this.Controls.Add(this.label4);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmDMSReplaceClaim";
            this.Text = "frmDMSReplaceClaim";
            this.Load += new System.EventHandler(this.frmDMSReplaceClaim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dvwReplacement)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbClaimNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dvwReplacement;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSubClaimNo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox TxtCartonQty;
        private System.Windows.Forms.Label lblCartonQty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtRemarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubClaimNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProductName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.Button btnVerified;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnVeifiedPrint;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label3;
        private CJ.Win.Control.ctlCustomer ctlCustomer1;
        private System.Windows.Forms.Button btnload;
        private System.Windows.Forms.Button btnClose;
    }
}
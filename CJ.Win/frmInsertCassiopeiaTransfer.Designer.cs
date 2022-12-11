namespace CJ.Win
{
    partial class frmInsertCassiopeiaTransfer
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
            this.btnInsertCassiopeiaTransfer = new System.Windows.Forms.Button();
            this.btnGet = new System.Windows.Forms.Button();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.TranNo = new System.Windows.Forms.ColumnHeader();
            this.TranDate = new System.Windows.Forms.ColumnHeader();
            this.lvwSRTran = new System.Windows.Forms.ListView();
            this.TranType = new System.Windows.Forms.ColumnHeader();
            this.Remarks = new System.Windows.Forms.ColumnHeader();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // btnInsertCassiopeiaTransfer
            // 
            this.btnInsertCassiopeiaTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInsertCassiopeiaTransfer.Location = new System.Drawing.Point(536, 66);
            this.btnInsertCassiopeiaTransfer.Name = "btnInsertCassiopeiaTransfer";
            this.btnInsertCassiopeiaTransfer.Size = new System.Drawing.Size(149, 37);
            this.btnInsertCassiopeiaTransfer.TabIndex = 59;
            this.btnInsertCassiopeiaTransfer.Text = "Insert Cassiopeia Transfer";
            this.btnInsertCassiopeiaTransfer.UseVisualStyleBackColor = true;
            this.btnInsertCassiopeiaTransfer.Click += new System.EventHandler(this.btnInsertCassiopeiaTransfer_Click);
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(384, 11);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(75, 23);
            this.btnGet.TabIndex = 58;
            this.btnGet.Text = "Get Data";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "dd-MMM-yyyy";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(214, 11);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(132, 20);
            this.dtpTo.TabIndex = 57;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(188, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 56;
            this.label5.Text = "To";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 55;
            this.label4.Text = "From";
            // 
            // lblSCount
            // 
            this.lblSCount.AutoSize = true;
            this.lblSCount.Location = new System.Drawing.Point(126, 50);
            this.lblSCount.Name = "lblSCount";
            this.lblSCount.Size = new System.Drawing.Size(35, 13);
            this.lblSCount.TabIndex = 54;
            this.lblSCount.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 53;
            this.label2.Text = "Cassiopeia Tran";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(536, 501);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(149, 27);
            this.btnClose.TabIndex = 51;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // TranNo
            // 
            this.TranNo.Text = "Tran No";
            this.TranNo.Width = 99;
            // 
            // TranDate
            // 
            this.TranDate.Text = "Tran Date";
            this.TranDate.Width = 96;
            // 
            // lvwSRTran
            // 
            this.lvwSRTran.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwSRTran.CheckBoxes = true;
            this.lvwSRTran.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TranNo,
            this.TranDate,
            this.TranType,
            this.Remarks});
            this.lvwSRTran.FullRowSelect = true;
            this.lvwSRTran.GridLines = true;
            this.lvwSRTran.HideSelection = false;
            this.lvwSRTran.Location = new System.Drawing.Point(12, 66);
            this.lvwSRTran.Name = "lvwSRTran";
            this.lvwSRTran.Size = new System.Drawing.Size(518, 462);
            this.lvwSRTran.TabIndex = 52;
            this.lvwSRTran.UseCompatibleStateImageBehavior = false;
            this.lvwSRTran.View = System.Windows.Forms.View.Details;
            // 
            // TranType
            // 
            this.TranType.Text = "Tran Type";
            this.TranType.Width = 102;
            // 
            // Remarks
            // 
            this.Remarks.Text = "Remarks";
            this.Remarks.Width = 200;
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd-MMM-yyyy";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(48, 11);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(132, 20);
            this.dtpFrom.TabIndex = 61;
            // 
            // frmInsertCassiopeiaTransfer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 538);
            this.Controls.Add(this.btnInsertCassiopeiaTransfer);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.dtpTo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblSCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lvwSRTran);
            this.Controls.Add(this.dtpFrom);
            this.Name = "frmInsertCassiopeiaTransfer";
            this.Text = "frmInsertCassiopeiaTransfer";
            this.Load += new System.EventHandler(this.frmInsertCassiopeiaTransfer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInsertCassiopeiaTransfer;
        private System.Windows.Forms.Button btnGet;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColumnHeader TranNo;
        private System.Windows.Forms.ColumnHeader TranDate;
        private System.Windows.Forms.ListView lvwSRTran;
        private System.Windows.Forms.ColumnHeader TranType;
        private System.Windows.Forms.ColumnHeader Remarks;
        private System.Windows.Forms.DateTimePicker dtpFrom;
    }
}
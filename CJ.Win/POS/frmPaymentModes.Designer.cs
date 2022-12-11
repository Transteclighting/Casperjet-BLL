namespace CJ.Win.POS
{
    partial class frmPaymentModes
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
            this.lvwPaymentMode = new System.Windows.Forms.ListView();
            this.colPaymentID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPaymentName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIsReceivableItem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIsFinancialInstitution = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBankName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIsActive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIsMandatoryInstrumentNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIsEligableforAdvance = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btAdd = new System.Windows.Forms.Button();
            this.btEdit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.colPaymentModeType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lvwPaymentMode
            // 
            this.lvwPaymentMode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwPaymentMode.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPaymentID,
            this.colPaymentName,
            this.colIsReceivableItem,
            this.colIsFinancialInstitution,
            this.colBankName,
            this.colIsActive,
            this.colIsMandatoryInstrumentNo,
            this.colIsEligableforAdvance,
            this.colPaymentModeType});
            this.lvwPaymentMode.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwPaymentMode.FullRowSelect = true;
            this.lvwPaymentMode.GridLines = true;
            this.lvwPaymentMode.HideSelection = false;
            this.lvwPaymentMode.Location = new System.Drawing.Point(14, 14);
            this.lvwPaymentMode.MultiSelect = false;
            this.lvwPaymentMode.Name = "lvwPaymentMode";
            this.lvwPaymentMode.Size = new System.Drawing.Size(385, 346);
            this.lvwPaymentMode.TabIndex = 179;
            this.lvwPaymentMode.UseCompatibleStateImageBehavior = false;
            this.lvwPaymentMode.View = System.Windows.Forms.View.Details;
            this.lvwPaymentMode.DoubleClick += new System.EventHandler(this.double_Click);
            // 
            // colPaymentID
            // 
            this.colPaymentID.Text = "Payment ID";
            this.colPaymentID.Width = 80;
            // 
            // colPaymentName
            // 
            this.colPaymentName.Text = "Payment Name";
            this.colPaymentName.Width = 180;
            // 
            // colIsReceivableItem
            // 
            this.colIsReceivableItem.Text = "Is Receivable Item";
            this.colIsReceivableItem.Width = 68;
            // 
            // colIsFinancialInstitution
            // 
            this.colIsFinancialInstitution.Text = "Is Financial Institution";
            // 
            // colBankName
            // 
            this.colBankName.Text = "Bank Name";
            // 
            // colIsActive
            // 
            this.colIsActive.Text = "Is Active";
            // 
            // colIsMandatoryInstrumentNo
            // 
            this.colIsMandatoryInstrumentNo.Text = "Is Mandatory Instrument#";
            // 
            // colIsEligableforAdvance
            // 
            this.colIsEligableforAdvance.Text = "Is Eligable for Advance";
            // 
            // btAdd
            // 
            this.btAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAdd.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAdd.Location = new System.Drawing.Point(407, 14);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(100, 31);
            this.btAdd.TabIndex = 188;
            this.btAdd.Text = "Add";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btEdit
            // 
            this.btEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btEdit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEdit.Location = new System.Drawing.Point(407, 52);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(100, 31);
            this.btEdit.TabIndex = 189;
            this.btEdit.Text = "Edit";
            this.btEdit.UseVisualStyleBackColor = true;
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(407, 329);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 31);
            this.btnClose.TabIndex = 187;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // colPaymentModeType
            // 
            this.colPaymentModeType.Text = "Payment Mode Type";
            // 
            // frmPaymentModes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 374);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.btEdit);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lvwPaymentMode);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmPaymentModes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Payment Mode";
            this.Load += new System.EventHandler(this.frmPaymentMode_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwPaymentMode;
        private System.Windows.Forms.ColumnHeader colPaymentID;
        private System.Windows.Forms.ColumnHeader colPaymentName;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btEdit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColumnHeader colIsActive;
        private System.Windows.Forms.ColumnHeader colIsReceivableItem;
        private System.Windows.Forms.ColumnHeader colIsFinancialInstitution;
        private System.Windows.Forms.ColumnHeader colBankName;
        private System.Windows.Forms.ColumnHeader colIsMandatoryInstrumentNo;
        private System.Windows.Forms.ColumnHeader colIsEligableforAdvance;
        private System.Windows.Forms.ColumnHeader colPaymentModeType;
    }
}
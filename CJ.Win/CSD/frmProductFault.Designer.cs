namespace CJ.Win.CSD
{
    partial class frmProductFault
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtFaultDescription = new System.Windows.Forms.TextBox();
            this.rdoMainFault = new System.Windows.Forms.RadioButton();
            this.rdoSubFault = new System.Windows.Forms.RadioButton();
            this.lblParentFault = new System.Windows.Forms.Label();
            this.cmbParentFault = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Fault Description";
            // 
            // txtFaultDescription
            // 
            this.txtFaultDescription.Location = new System.Drawing.Point(96, 66);
            this.txtFaultDescription.Name = "txtFaultDescription";
            this.txtFaultDescription.Size = new System.Drawing.Size(234, 20);
            this.txtFaultDescription.TabIndex = 4;
            // 
            // rdoMainFault
            // 
            this.rdoMainFault.AutoSize = true;
            this.rdoMainFault.Location = new System.Drawing.Point(96, 12);
            this.rdoMainFault.Name = "rdoMainFault";
            this.rdoMainFault.Size = new System.Drawing.Size(82, 17);
            this.rdoMainFault.TabIndex = 1;
            this.rdoMainFault.TabStop = true;
            this.rdoMainFault.Text = "Parent Fault";
            this.rdoMainFault.UseVisualStyleBackColor = true;
            this.rdoMainFault.CheckedChanged += new System.EventHandler(this.rdoMainFault_CheckedChanged);
            // 
            // rdoSubFault
            // 
            this.rdoSubFault.AutoSize = true;
            this.rdoSubFault.Location = new System.Drawing.Point(188, 12);
            this.rdoSubFault.Name = "rdoSubFault";
            this.rdoSubFault.Size = new System.Drawing.Size(70, 17);
            this.rdoSubFault.TabIndex = 2;
            this.rdoSubFault.TabStop = true;
            this.rdoSubFault.Text = "Sub Fault";
            this.rdoSubFault.UseVisualStyleBackColor = true;
            // 
            // lblParentFault
            // 
            this.lblParentFault.AutoSize = true;
            this.lblParentFault.Location = new System.Drawing.Point(28, 43);
            this.lblParentFault.Name = "lblParentFault";
            this.lblParentFault.Size = new System.Drawing.Size(64, 13);
            this.lblParentFault.TabIndex = 5;
            this.lblParentFault.Text = "Parent Fault";
            // 
            // cmbParentFault
            // 
            this.cmbParentFault.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParentFault.FormattingEnabled = true;
            this.cmbParentFault.Location = new System.Drawing.Point(96, 39);
            this.cmbParentFault.Name = "cmbParentFault";
            this.cmbParentFault.Size = new System.Drawing.Size(233, 21);
            this.cmbParentFault.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(169, 94);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(76, 27);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(250, 94);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(76, 27);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Fault Type";
            // 
            // frmProductFault
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 137);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbParentFault);
            this.Controls.Add(this.lblParentFault);
            this.Controls.Add(this.rdoSubFault);
            this.Controls.Add(this.rdoMainFault);
            this.Controls.Add(this.txtFaultDescription);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProductFault";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Product Fault";
            this.Load += new System.EventHandler(this.frmProductFault_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFaultDescription;
        private System.Windows.Forms.RadioButton rdoMainFault;
        private System.Windows.Forms.RadioButton rdoSubFault;
        private System.Windows.Forms.Label lblParentFault;
        private System.Windows.Forms.ComboBox cmbParentFault;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label2;
    }
}
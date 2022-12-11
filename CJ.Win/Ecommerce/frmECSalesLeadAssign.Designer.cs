namespace CJ.Win.Ecommerce
{
    partial class frmECSalesLeadAssign
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
            this.btClose = new System.Windows.Forms.Button();
            this.btnAssign = new System.Windows.Forms.Button();
            this.btnStatusUpdate = new System.Windows.Forms.Button();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStat = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.cmbOutlet = new System.Windows.Forms.ComboBox();
            this.txtInvoiceNo = new System.Windows.Forms.TextBox();
            this.lblInvoiceNo = new System.Windows.Forms.Label();
            this.lblLeasID = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.rdoTD = new System.Windows.Forms.RadioButton();
            this.rdoCorp = new System.Windows.Forms.RadioButton();
            this.rdoProject = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.Location = new System.Drawing.Point(439, 109);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(80, 27);
            this.btClose.TabIndex = 179;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btnAssign
            // 
            this.btnAssign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAssign.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAssign.Location = new System.Drawing.Point(356, 108);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(80, 27);
            this.btnAssign.TabIndex = 181;
            this.btnAssign.Text = "Assign";
            this.btnAssign.UseVisualStyleBackColor = true;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // btnStatusUpdate
            // 
            this.btnStatusUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStatusUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStatusUpdate.Location = new System.Drawing.Point(356, 108);
            this.btnStatusUpdate.Name = "btnStatusUpdate";
            this.btnStatusUpdate.Size = new System.Drawing.Size(80, 27);
            this.btnStatusUpdate.TabIndex = 182;
            this.btnStatusUpdate.Text = "Save";
            this.btnStatusUpdate.UseVisualStyleBackColor = true;
            this.btnStatusUpdate.Click += new System.EventHandler(this.btnStatusUpdate_Click);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(69, 82);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(450, 20);
            this.txtRemarks.TabIndex = 184;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 183;
            this.label2.Text = "Remarks";
            // 
            // lblStat
            // 
            this.lblStat.AutoSize = true;
            this.lblStat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStat.Location = new System.Drawing.Point(18, 60);
            this.lblStat.Name = "lblStat";
            this.lblStat.Size = new System.Drawing.Size(51, 13);
            this.lblStat.TabIndex = 186;
            this.lblStat.Text = "Status :";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(69, 55);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(167, 21);
            this.cmbStatus.TabIndex = 185;
            // 
            // cmbOutlet
            // 
            this.cmbOutlet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOutlet.FormattingEnabled = true;
            this.cmbOutlet.Location = new System.Drawing.Point(68, 55);
            this.cmbOutlet.Name = "cmbOutlet";
            this.cmbOutlet.Size = new System.Drawing.Size(450, 21);
            this.cmbOutlet.TabIndex = 187;
            // 
            // txtInvoiceNo
            // 
            this.txtInvoiceNo.Location = new System.Drawing.Point(364, 55);
            this.txtInvoiceNo.Name = "txtInvoiceNo";
            this.txtInvoiceNo.Size = new System.Drawing.Size(155, 20);
            this.txtInvoiceNo.TabIndex = 188;
            // 
            // lblInvoiceNo
            // 
            this.lblInvoiceNo.AutoSize = true;
            this.lblInvoiceNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvoiceNo.Location = new System.Drawing.Point(295, 57);
            this.lblInvoiceNo.Name = "lblInvoiceNo";
            this.lblInvoiceNo.Size = new System.Drawing.Size(69, 13);
            this.lblInvoiceNo.TabIndex = 189;
            this.lblInvoiceNo.Text = "Invoice No";
            // 
            // lblLeasID
            // 
            this.lblLeasID.AutoSize = true;
            this.lblLeasID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeasID.Location = new System.Drawing.Point(66, 9);
            this.lblLeasID.Name = "lblLeasID";
            this.lblLeasID.Size = new System.Drawing.Size(47, 13);
            this.lblLeasID.TabIndex = 190;
            this.lblLeasID.Text = "LeasID";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(313, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(39, 13);
            this.lblName.TabIndex = 191;
            this.lblName.Text = "Name";
            // 
            // rdoTD
            // 
            this.rdoTD.AutoSize = true;
            this.rdoTD.Location = new System.Drawing.Point(3, 9);
            this.rdoTD.Name = "rdoTD";
            this.rdoTD.Size = new System.Drawing.Size(104, 17);
            this.rdoTD.TabIndex = 192;
            this.rdoTD.TabStop = true;
            this.rdoTD.Text = "Transcom Digital";
            this.rdoTD.UseVisualStyleBackColor = true;
            this.rdoTD.CheckedChanged += new System.EventHandler(this.rdoTD_CheckedChanged);
            // 
            // rdoCorp
            // 
            this.rdoCorp.AutoSize = true;
            this.rdoCorp.Location = new System.Drawing.Point(134, 9);
            this.rdoCorp.Name = "rdoCorp";
            this.rdoCorp.Size = new System.Drawing.Size(71, 17);
            this.rdoCorp.TabIndex = 193;
            this.rdoCorp.TabStop = true;
            this.rdoCorp.Text = "Corporate";
            this.rdoCorp.UseVisualStyleBackColor = true;
            this.rdoCorp.CheckedChanged += new System.EventHandler(this.rdoCorp_CheckedChanged);
            // 
            // rdoProject
            // 
            this.rdoProject.AutoSize = true;
            this.rdoProject.Location = new System.Drawing.Point(267, 9);
            this.rdoProject.Name = "rdoProject";
            this.rdoProject.Size = new System.Drawing.Size(58, 17);
            this.rdoProject.TabIndex = 194;
            this.rdoProject.TabStop = true;
            this.rdoProject.Text = "Project";
            this.rdoProject.UseVisualStyleBackColor = true;
            this.rdoProject.CheckedChanged += new System.EventHandler(this.rdoProject_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoProject);
            this.groupBox1.Controls.Add(this.rdoCorp);
            this.groupBox1.Controls.Add(this.rdoTD);
            this.groupBox1.Location = new System.Drawing.Point(68, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(354, 30);
            this.groupBox1.TabIndex = 195;
            this.groupBox1.TabStop = false;
            // 
            // frmECSalesLeadAssign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(530, 141);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblLeasID);
            this.Controls.Add(this.lblInvoiceNo);
            this.Controls.Add(this.txtInvoiceNo);
            this.Controls.Add(this.cmbOutlet);
            this.Controls.Add(this.lblStat);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnStatusUpdate);
            this.Controls.Add(this.btnAssign);
            this.Controls.Add(this.btClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmECSalesLeadAssign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmECSalesLeadAssign";
            this.Load += new System.EventHandler(this.frmECSalesLeadAssign_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.Button btnStatusUpdate;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStat;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.ComboBox cmbOutlet;
        private System.Windows.Forms.TextBox txtInvoiceNo;
        private System.Windows.Forms.Label lblInvoiceNo;
        private System.Windows.Forms.Label lblLeasID;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.RadioButton rdoTD;
        private System.Windows.Forms.RadioButton rdoCorp;
        private System.Windows.Forms.RadioButton rdoProject;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
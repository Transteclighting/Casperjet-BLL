namespace CJ.Win.CSD.Reception
{
    partial class frmCSDGetPass
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
            this.lblJob = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoInterService = new System.Windows.Forms.RadioButton();
            this.rdoDealer = new System.Windows.Forms.RadioButton();
            this.rdoOutlet = new System.Windows.Forms.RadioButton();
            this.rdoCustomer = new System.Windows.Forms.RadioButton();
            this.lblSenTo = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnPrint = new System.Windows.Forms.Button();
            this.txtJobNo = new System.Windows.Forms.TextBox();
            this.ctlInterService1 = new CJ.Win.ctlInterService();
            this.ctlCustomer1 = new CJ.Win.Control.ctlCustomer();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblJob
            // 
            this.lblJob.AutoSize = true;
            this.lblJob.Location = new System.Drawing.Point(8, 9);
            this.lblJob.Name = "lblJob";
            this.lblJob.Size = new System.Drawing.Size(41, 13);
            this.lblJob.TabIndex = 4;
            this.lblJob.Text = "Job No";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoInterService);
            this.groupBox1.Controls.Add(this.rdoDealer);
            this.groupBox1.Controls.Add(this.rdoOutlet);
            this.groupBox1.Controls.Add(this.rdoCustomer);
            this.groupBox1.Location = new System.Drawing.Point(12, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 52);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sent To";
            // 
            // rdoInterService
            // 
            this.rdoInterService.AutoSize = true;
            this.rdoInterService.Location = new System.Drawing.Point(210, 22);
            this.rdoInterService.Name = "rdoInterService";
            this.rdoInterService.Size = new System.Drawing.Size(85, 17);
            this.rdoInterService.TabIndex = 4;
            this.rdoInterService.Text = "Inter Service";
            this.rdoInterService.UseVisualStyleBackColor = true;
            this.rdoInterService.CheckedChanged += new System.EventHandler(this.rdoInterService_CheckedChanged);
            // 
            // rdoDealer
            // 
            this.rdoDealer.AutoSize = true;
            this.rdoDealer.Location = new System.Drawing.Point(148, 22);
            this.rdoDealer.Name = "rdoDealer";
            this.rdoDealer.Size = new System.Drawing.Size(56, 17);
            this.rdoDealer.TabIndex = 3;
            this.rdoDealer.Text = "Dealer";
            this.rdoDealer.UseVisualStyleBackColor = true;
            this.rdoDealer.CheckedChanged += new System.EventHandler(this.rdoDealer_CheckedChanged);
            // 
            // rdoOutlet
            // 
            this.rdoOutlet.AutoSize = true;
            this.rdoOutlet.Location = new System.Drawing.Point(89, 22);
            this.rdoOutlet.Name = "rdoOutlet";
            this.rdoOutlet.Size = new System.Drawing.Size(53, 17);
            this.rdoOutlet.TabIndex = 2;
            this.rdoOutlet.Text = "Outlet";
            this.rdoOutlet.UseVisualStyleBackColor = true;
            this.rdoOutlet.CheckedChanged += new System.EventHandler(this.rdoOutlet_CheckedChanged);
            // 
            // rdoCustomer
            // 
            this.rdoCustomer.AutoSize = true;
            this.rdoCustomer.Checked = true;
            this.rdoCustomer.Location = new System.Drawing.Point(14, 22);
            this.rdoCustomer.Name = "rdoCustomer";
            this.rdoCustomer.Size = new System.Drawing.Size(69, 17);
            this.rdoCustomer.TabIndex = 1;
            this.rdoCustomer.TabStop = true;
            this.rdoCustomer.Text = "Customer";
            this.rdoCustomer.UseVisualStyleBackColor = true;
            this.rdoCustomer.CheckedChanged += new System.EventHandler(this.rdoCustomer_CheckedChanged);
            // 
            // lblSenTo
            // 
            this.lblSenTo.AutoSize = true;
            this.lblSenTo.Location = new System.Drawing.Point(10, 96);
            this.lblSenTo.Name = "lblSenTo";
            this.lblSenTo.Size = new System.Drawing.Size(13, 13);
            this.lblSenTo.TabIndex = 7;
            this.lblSenTo.Text = "?";
            this.lblSenTo.Visible = false;
            // 
            // txtRemarks
            // 
            this.txtRemarks.AcceptsReturn = true;
            this.txtRemarks.AcceptsTab = true;
            this.txtRemarks.Location = new System.Drawing.Point(76, 125);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(425, 20);
            this.txtRemarks.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Remarks";
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(415, 155);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(86, 27);
            this.btnPrint.TabIndex = 41;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // txtJobNo
            // 
            this.txtJobNo.AcceptsReturn = true;
            this.txtJobNo.AcceptsTab = true;
            this.txtJobNo.Location = new System.Drawing.Point(55, 7);
            this.txtJobNo.Name = "txtJobNo";
            this.txtJobNo.ReadOnly = true;
            this.txtJobNo.Size = new System.Drawing.Size(268, 20);
            this.txtJobNo.TabIndex = 42;
            // 
            // ctlInterService1
            // 
            this.ctlInterService1.Location = new System.Drawing.Point(76, 91);
            this.ctlInterService1.Name = "ctlInterService1";
            this.ctlInterService1.Size = new System.Drawing.Size(432, 25);
            this.ctlInterService1.TabIndex = 10;
            this.ctlInterService1.Visible = false;
            // 
            // ctlCustomer1
            // 
            this.ctlCustomer1.Location = new System.Drawing.Point(70, 90);
            this.ctlCustomer1.Name = "ctlCustomer1";
            this.ctlCustomer1.Size = new System.Drawing.Size(438, 29);
            this.ctlCustomer1.TabIndex = 8;
            this.ctlCustomer1.Visible = false;
            // 
            // frmCSDGetPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 190);
            this.Controls.Add(this.txtJobNo);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ctlInterService1);
            this.Controls.Add(this.ctlCustomer1);
            this.Controls.Add(this.lblSenTo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblJob);
            this.Name = "frmCSDGetPass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCSDGetPass";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblJob;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoCustomer;
        private System.Windows.Forms.RadioButton rdoInterService;
        private System.Windows.Forms.RadioButton rdoDealer;
        private System.Windows.Forms.RadioButton rdoOutlet;
        private System.Windows.Forms.Label lblSenTo;
        private CJ.Win.Control.ctlCustomer ctlCustomer1;
        private ctlInterService ctlInterService1;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.TextBox txtJobNo;
    }
}
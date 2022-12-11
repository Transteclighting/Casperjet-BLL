namespace CJ.Win.Ecommerce
{
    partial class frmECSalesLeadHappyCall
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbDissatisfy = new System.Windows.Forms.RadioButton();
            this.rdbModerate = new System.Windows.Forms.RadioButton();
            this.rdbSatisfy = new System.Windows.Forms.RadioButton();
            this.lblHappyCallDetails = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtHappyDetails = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblLeasID = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(404, 163);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(78, 28);
            this.btnCancel.TabIndex = 142;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbDissatisfy);
            this.groupBox1.Controls.Add(this.rdbModerate);
            this.groupBox1.Controls.Add(this.rdbSatisfy);
            this.groupBox1.Location = new System.Drawing.Point(20, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 37);
            this.groupBox1.TabIndex = 141;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Status";
            // 
            // rdbDissatisfy
            // 
            this.rdbDissatisfy.AutoSize = true;
            this.rdbDissatisfy.Location = new System.Drawing.Point(256, 13);
            this.rdbDissatisfy.Name = "rdbDissatisfy";
            this.rdbDissatisfy.Size = new System.Drawing.Size(69, 17);
            this.rdbDissatisfy.TabIndex = 117;
            this.rdbDissatisfy.Text = "Dissatisfy";
            this.rdbDissatisfy.UseVisualStyleBackColor = true;
            // 
            // rdbModerate
            // 
            this.rdbModerate.AutoSize = true;
            this.rdbModerate.Location = new System.Drawing.Point(138, 13);
            this.rdbModerate.Name = "rdbModerate";
            this.rdbModerate.Size = new System.Drawing.Size(70, 17);
            this.rdbModerate.TabIndex = 116;
            this.rdbModerate.Text = "Moderate";
            this.rdbModerate.UseVisualStyleBackColor = true;
            // 
            // rdbSatisfy
            // 
            this.rdbSatisfy.AutoSize = true;
            this.rdbSatisfy.Checked = true;
            this.rdbSatisfy.Location = new System.Drawing.Point(32, 13);
            this.rdbSatisfy.Name = "rdbSatisfy";
            this.rdbSatisfy.Size = new System.Drawing.Size(56, 17);
            this.rdbSatisfy.TabIndex = 115;
            this.rdbSatisfy.TabStop = true;
            this.rdbSatisfy.Text = "Satisfy";
            this.rdbSatisfy.UseVisualStyleBackColor = true;
            // 
            // lblHappyCallDetails
            // 
            this.lblHappyCallDetails.AutoSize = true;
            this.lblHappyCallDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHappyCallDetails.Location = new System.Drawing.Point(21, 82);
            this.lblHappyCallDetails.Name = "lblHappyCallDetails";
            this.lblHappyCallDetails.Size = new System.Drawing.Size(64, 13);
            this.lblHappyCallDetails.TabIndex = 140;
            this.lblHappyCallDetails.Text = "Comments";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(320, 163);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(78, 28);
            this.btnSave.TabIndex = 139;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtHappyDetails
            // 
            this.txtHappyDetails.Location = new System.Drawing.Point(19, 102);
            this.txtHappyDetails.Multiline = true;
            this.txtHappyDetails.Name = "txtHappyDetails";
            this.txtHappyDetails.Size = new System.Drawing.Size(464, 55);
            this.txtHappyDetails.TabIndex = 138;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(271, 10);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(39, 13);
            this.lblName.TabIndex = 193;
            this.lblName.Text = "Name";
            // 
            // lblLeasID
            // 
            this.lblLeasID.AutoSize = true;
            this.lblLeasID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeasID.Location = new System.Drawing.Point(24, 10);
            this.lblLeasID.Name = "lblLeasID";
            this.lblLeasID.Size = new System.Drawing.Size(47, 13);
            this.lblLeasID.TabIndex = 192;
            this.lblLeasID.Text = "LeasID";
            // 
            // frmECSalesLeadHappyCall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 203);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblLeasID);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblHappyCallDetails);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtHappyDetails);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmECSalesLeadHappyCall";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Lead Happy Call";
            this.Load += new System.EventHandler(this.frmECSalesLeadHappyCall_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbDissatisfy;
        private System.Windows.Forms.RadioButton rdbModerate;
        private System.Windows.Forms.RadioButton rdbSatisfy;
        private System.Windows.Forms.Label lblHappyCallDetails;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtHappyDetails;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblLeasID;
    }
}
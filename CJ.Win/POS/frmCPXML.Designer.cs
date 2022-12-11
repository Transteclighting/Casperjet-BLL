namespace CJ.Win.POS
{
    partial class frmCPXML
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tvwShowroom = new System.Windows.Forms.TreeView();
            this.lbTotal = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoLeadTarget = new System.Windows.Forms.RadioButton();
            this.rdoMAGWeekTarget = new System.Windows.Forms.RadioButton();
            this.rdoCP = new System.Windows.Forms.RadioButton();
            this.rdoBankDiscount = new System.Windows.Forms.RadioButton();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tvwShowroom);
            this.groupBox3.Controls.Add(this.lbTotal);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.groupBox3.ForeColor = System.Drawing.Color.Black;
            this.groupBox3.Location = new System.Drawing.Point(12, 74);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(457, 228);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Outlet";
            // 
            // tvwShowroom
            // 
            this.tvwShowroom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvwShowroom.CheckBoxes = true;
            this.tvwShowroom.Location = new System.Drawing.Point(9, 19);
            this.tvwShowroom.Name = "tvwShowroom";
            this.tvwShowroom.Size = new System.Drawing.Size(441, 201);
            this.tvwShowroom.TabIndex = 22;
            this.tvwShowroom.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvwShowroom_AfterCheck);
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Location = new System.Drawing.Point(80, 15);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(0, 15);
            this.lbTotal.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnSave.Location = new System.Drawing.Point(313, 308);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 27);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnClose.Location = new System.Drawing.Point(394, 308);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 27);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(66, 12);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(305, 20);
            this.txtDescription.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Description";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoBankDiscount);
            this.groupBox1.Controls.Add(this.rdoLeadTarget);
            this.groupBox1.Controls.Add(this.rdoMAGWeekTarget);
            this.groupBox1.Controls.Add(this.rdoCP);
            this.groupBox1.Location = new System.Drawing.Point(12, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(460, 35);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Type";
            // 
            // rdoLeadTarget
            // 
            this.rdoLeadTarget.AutoSize = true;
            this.rdoLeadTarget.Location = new System.Drawing.Point(258, 12);
            this.rdoLeadTarget.Name = "rdoLeadTarget";
            this.rdoLeadTarget.Size = new System.Drawing.Size(83, 17);
            this.rdoLeadTarget.TabIndex = 2;
            this.rdoLeadTarget.TabStop = true;
            this.rdoLeadTarget.Text = "Lead Target";
            this.rdoLeadTarget.UseVisualStyleBackColor = true;
            // 
            // rdoMAGWeekTarget
            // 
            this.rdoMAGWeekTarget.AutoSize = true;
            this.rdoMAGWeekTarget.Location = new System.Drawing.Point(113, 12);
            this.rdoMAGWeekTarget.Name = "rdoMAGWeekTarget";
            this.rdoMAGWeekTarget.Size = new System.Drawing.Size(115, 17);
            this.rdoMAGWeekTarget.TabIndex = 1;
            this.rdoMAGWeekTarget.TabStop = true;
            this.rdoMAGWeekTarget.Text = "MAG Week Target";
            this.rdoMAGWeekTarget.UseVisualStyleBackColor = true;
            // 
            // rdoCP
            // 
            this.rdoCP.AutoSize = true;
            this.rdoCP.Checked = true;
            this.rdoCP.Location = new System.Drawing.Point(24, 12);
            this.rdoCP.Name = "rdoCP";
            this.rdoCP.Size = new System.Drawing.Size(58, 17);
            this.rdoCP.TabIndex = 0;
            this.rdoCP.TabStop = true;
            this.rdoCP.Text = "CP/TP";
            this.rdoCP.UseVisualStyleBackColor = true;
            // 
            // rdoBankDiscount
            // 
            this.rdoBankDiscount.AutoSize = true;
            this.rdoBankDiscount.Location = new System.Drawing.Point(362, 12);
            this.rdoBankDiscount.Name = "rdoBankDiscount";
            this.rdoBankDiscount.Size = new System.Drawing.Size(95, 17);
            this.rdoBankDiscount.TabIndex = 3;
            this.rdoBankDiscount.TabStop = true;
            this.rdoBankDiscount.Text = "Bank Discount";
            this.rdoBankDiscount.UseVisualStyleBackColor = true;
            // 
            // frmCPXML
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 347);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupBox3);
            this.Name = "frmCPXML";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CP/TP XML";
            this.Load += new System.EventHandler(this.frmCPXML_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TreeView tvwShowroom;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoLeadTarget;
        private System.Windows.Forms.RadioButton rdoMAGWeekTarget;
        private System.Windows.Forms.RadioButton rdoCP;
        private System.Windows.Forms.RadioButton rdoBankDiscount;
    }
}
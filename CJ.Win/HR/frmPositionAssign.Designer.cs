namespace CJ.Win.HR
{
    partial class frmPositionAssign
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
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.lblEffectiveDate = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAssign = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSelectedNode = new System.Windows.Forms.Label();
            this.lblabc = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.ctlEmployee1 = new CJ.Win.ctlEmployee();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Employee";
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(98, 89);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(132, 20);
            this.dtFromDate.TabIndex = 2;
            // 
            // lblEffectiveDate
            // 
            this.lblEffectiveDate.AutoSize = true;
            this.lblEffectiveDate.Location = new System.Drawing.Point(21, 91);
            this.lblEffectiveDate.Name = "lblEffectiveDate";
            this.lblEffectiveDate.Size = new System.Drawing.Size(75, 13);
            this.lblEffectiveDate.TabIndex = 3;
            this.lblEffectiveDate.Text = "Effective Date";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(98, 118);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(457, 20);
            this.txtRemarks.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Remarks";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(480, 151);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 28);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAssign
            // 
            this.btnAssign.Location = new System.Drawing.Point(399, 151);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(75, 28);
            this.btnAssign.TabIndex = 7;
            this.btnAssign.Text = "Assign";
            this.btnAssign.UseVisualStyleBackColor = true;
            this.btnAssign.Click += new System.EventHandler(this.btnAssign_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Selected Node";
            // 
            // lblSelectedNode
            // 
            this.lblSelectedNode.AutoSize = true;
            this.lblSelectedNode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelectedNode.ForeColor = System.Drawing.Color.Blue;
            this.lblSelectedNode.Location = new System.Drawing.Point(95, 33);
            this.lblSelectedNode.Name = "lblSelectedNode";
            this.lblSelectedNode.Size = new System.Drawing.Size(21, 13);
            this.lblSelectedNode.TabIndex = 9;
            this.lblSelectedNode.Text = "??";
            // 
            // lblabc
            // 
            this.lblabc.AutoSize = true;
            this.lblabc.Location = new System.Drawing.Point(38, 13);
            this.lblabc.Name = "lblabc";
            this.lblabc.Size = new System.Drawing.Size(51, 13);
            this.lblabc.TabIndex = 10;
            this.lblabc.Text = "Company";
            // 
            // lblCompany
            // 
            this.lblCompany.AutoSize = true;
            this.lblCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompany.ForeColor = System.Drawing.Color.Blue;
            this.lblCompany.Location = new System.Drawing.Point(95, 14);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(21, 13);
            this.lblCompany.TabIndex = 11;
            this.lblCompany.Text = "??";
            // 
            // ctlEmployee1
            // 
            this.ctlEmployee1.Location = new System.Drawing.Point(98, 58);
            this.ctlEmployee1.Name = "ctlEmployee1";
            this.ctlEmployee1.Size = new System.Drawing.Size(464, 25);
            this.ctlEmployee1.TabIndex = 0;
            // 
            // frmPositionAssign
            // 
            this.AcceptButton = this.btnAssign;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 185);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.lblabc);
            this.Controls.Add(this.lblSelectedNode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnAssign);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.lblEffectiveDate);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ctlEmployee1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmPositionAssign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Position Assign";
            this.Load += new System.EventHandler(this.frmPositionAssign_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ctlEmployee ctlEmployee1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label lblEffectiveDate;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAssign;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSelectedNode;
        private System.Windows.Forms.Label lblabc;
        private System.Windows.Forms.Label lblCompany;
    }
}
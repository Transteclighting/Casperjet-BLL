namespace CJ.Win
{
    partial class frmSmartSMSMessageForGroup
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
            this.txtSMSMessage = new System.Windows.Forms.TextBox();
            this.lvwSMSGroup = new System.Windows.Forms.ListView();
            this.colSMSGroupName = new System.Windows.Forms.ColumnHeader();
            this.dtpSubmitDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Message";
            // 
            // txtSMSMessage
            // 
            this.txtSMSMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSMSMessage.Location = new System.Drawing.Point(12, 43);
            this.txtSMSMessage.MaxLength = 640;
            this.txtSMSMessage.Multiline = true;
            this.txtSMSMessage.Name = "txtSMSMessage";
            this.txtSMSMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtSMSMessage.Size = new System.Drawing.Size(511, 161);
            this.txtSMSMessage.TabIndex = 13;
            // 
            // lvwSMSGroup
            // 
            this.lvwSMSGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lvwSMSGroup.CheckBoxes = true;
            this.lvwSMSGroup.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSMSGroupName});
            this.lvwSMSGroup.FullRowSelect = true;
            this.lvwSMSGroup.GridLines = true;
            this.lvwSMSGroup.HideSelection = false;
            this.lvwSMSGroup.Location = new System.Drawing.Point(15, 210);
            this.lvwSMSGroup.Name = "lvwSMSGroup";
            this.lvwSMSGroup.Size = new System.Drawing.Size(303, 137);
            this.lvwSMSGroup.TabIndex = 3;
            this.lvwSMSGroup.UseCompatibleStateImageBehavior = false;
            this.lvwSMSGroup.View = System.Windows.Forms.View.Details;
            // 
            // colSMSGroupName
            // 
            this.colSMSGroupName.Text = "Name";
            this.colSMSGroupName.Width = 282;
            // 
            // dtpSubmitDate
            // 
            this.dtpSubmitDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpSubmitDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpSubmitDate.Location = new System.Drawing.Point(422, 220);
            this.dtpSubmitDate.Name = "dtpSubmitDate";
            this.dtpSubmitDate.Size = new System.Drawing.Size(101, 20);
            this.dtpSubmitDate.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(330, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Submission Date";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmit.Location = new System.Drawing.Point(448, 324);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 7;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // frmSmartSMSMessageForGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 366);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.dtpSubmitDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lvwSMSGroup);
            this.Controls.Add(this.txtSMSMessage);
            this.Controls.Add(this.label1);
            this.Name = "frmSmartSMSMessageForGroup";
            this.Text = "Smart SMS Message For Group";
            this.Load += new System.EventHandler(this.frmSmartSMSMessageForGroup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSMSMessage;
        private System.Windows.Forms.ListView lvwSMSGroup;
        private System.Windows.Forms.ColumnHeader colSMSGroupName;
        private System.Windows.Forms.DateTimePicker dtpSubmitDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSubmit;
    }
}
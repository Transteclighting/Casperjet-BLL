namespace TEL.SMS.UI.Win
{
    partial class frmSMSGroupPerson
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSMSGroupPerson));
            this.txtSMSGroupName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lvwPersonsSelected = new System.Windows.Forms.ListView();
            this.colPersonCode = new System.Windows.Forms.ColumnHeader();
            this.colPersonName = new System.Windows.Forms.ColumnHeader();
            this.colMobileNo = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lvwPersonsAvailable = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPersonNameLike = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtSMSGroupName
            // 
            this.txtSMSGroupName.Enabled = false;
            this.txtSMSGroupName.Location = new System.Drawing.Point(86, 5);
            this.txtSMSGroupName.Name = "txtSMSGroupName";
            this.txtSMSGroupName.Size = new System.Drawing.Size(314, 20);
            this.txtSMSGroupName.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 16);
            this.label2.TabIndex = 22;
            this.label2.Text = "Group Name";
            // 
            // lvwPersonsSelected
            // 
            this.lvwPersonsSelected.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwPersonsSelected.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPersonCode,
            this.colPersonName,
            this.colMobileNo});
            this.lvwPersonsSelected.FullRowSelect = true;
            this.lvwPersonsSelected.GridLines = true;
            this.lvwPersonsSelected.HideSelection = false;
            this.lvwPersonsSelected.Location = new System.Drawing.Point(459, 85);
            this.lvwPersonsSelected.Name = "lvwPersonsSelected";
            this.lvwPersonsSelected.Size = new System.Drawing.Size(411, 492);
            this.lvwPersonsSelected.TabIndex = 25;
            this.lvwPersonsSelected.UseCompatibleStateImageBehavior = false;
            this.lvwPersonsSelected.View = System.Windows.Forms.View.Details;
            // 
            // colPersonCode
            // 
            this.colPersonCode.Text = "Code";
            this.colPersonCode.Width = 62;
            // 
            // colPersonName
            // 
            this.colPersonName.Text = "Name";
            this.colPersonName.Width = 215;
            // 
            // colMobileNo
            // 
            this.colMobileNo.Text = "Mobile No";
            this.colMobileNo.Width = 111;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Persons Available";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(406, 188);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(47, 23);
            this.btnAdd.TabIndex = 28;
            this.btnAdd.Text = ">";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(406, 232);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(47, 23);
            this.btnRemove.TabIndex = 29;
            this.btnRemove.Text = "<";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lvwPersonsAvailable
            // 
            this.lvwPersonsAvailable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lvwPersonsAvailable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvwPersonsAvailable.FullRowSelect = true;
            this.lvwPersonsAvailable.GridLines = true;
            this.lvwPersonsAvailable.HideSelection = false;
            this.lvwPersonsAvailable.Location = new System.Drawing.Point(12, 85);
            this.lvwPersonsAvailable.Name = "lvwPersonsAvailable";
            this.lvwPersonsAvailable.Size = new System.Drawing.Size(388, 492);
            this.lvwPersonsAvailable.TabIndex = 30;
            this.lvwPersonsAvailable.UseCompatibleStateImageBehavior = false;
            this.lvwPersonsAvailable.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Code";
            this.columnHeader1.Width = 62;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 193;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Mobile No";
            this.columnHeader3.Width = 111;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(456, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Persons Selected";
            // 
            // txtPersonNameLike
            // 
            this.txtPersonNameLike.Location = new System.Drawing.Point(115, 60);
            this.txtPersonNameLike.Name = "txtPersonNameLike";
            this.txtPersonNameLike.Size = new System.Drawing.Size(285, 20);
            this.txtPersonNameLike.TabIndex = 32;
            this.txtPersonNameLike.TextChanged += new System.EventHandler(this.txtPersonNameLike_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 13);
            this.label4.TabIndex = 33;
            this.label4.Text = "Person Name Like";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(456, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(94, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Person Name Like";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(557, 60);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(313, 20);
            this.txtName.TabIndex = 35;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // frmSMSGroupPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 589);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPersonNameLike);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lvwPersonsAvailable);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvwPersonsSelected);
            this.Controls.Add(this.txtSMSGroupName);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSMSGroupPerson";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SMS Group";
            this.Load += new System.EventHandler(this.frmSMSGroupPerson_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSMSGroupName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvwPersonsSelected;
        private System.Windows.Forms.ColumnHeader colPersonCode;
        private System.Windows.Forms.ColumnHeader colPersonName;
        private System.Windows.Forms.ColumnHeader colMobileNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ListView lvwPersonsAvailable;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPersonNameLike;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtName;
    }
}
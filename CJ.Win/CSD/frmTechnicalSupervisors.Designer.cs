namespace CJ.Win
{
    partial class frmTechnicalSupervisors
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
            this.lvwTechnicalSupervisors = new System.Windows.Forms.ListView();
            this.colSupervisorID = new System.Windows.Forms.ColumnHeader();
            this.colEmplNo = new System.Windows.Forms.ColumnHeader();
            this.colSupervisorName = new System.Windows.Forms.ColumnHeader();
            this.colDesignation = new System.Windows.Forms.ColumnHeader();
            this.colCategoryName = new System.Windows.Forms.ColumnHeader();
            this.colISActive = new System.Windows.Forms.ColumnHeader();
            this.colusername = new System.Windows.Forms.ColumnHeader();
            this.colEntryDate = new System.Windows.Forms.ColumnHeader();
            this.lblSupervisorName = new System.Windows.Forms.Label();
            this.txtEmplCode = new System.Windows.Forms.TextBox();
            this.lblSupervisorCode = new System.Windows.Forms.Label();
            this.txtSupervisorID = new System.Windows.Forms.TextBox();
            this.txtEmplName = new System.Windows.Forms.TextBox();
            this.lblSupervisorID = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblComplainStatus = new System.Windows.Forms.Label();
            this.cmbIsActive = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMapping = new System.Windows.Forms.Button();
            this.colMobileNo = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lvwTechnicalSupervisors
            // 
            this.lvwTechnicalSupervisors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwTechnicalSupervisors.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSupervisorID,
            this.colEmplNo,
            this.colSupervisorName,
            this.colDesignation,
            this.colMobileNo,
            this.colCategoryName,
            this.colISActive,
            this.colusername,
            this.colEntryDate});
            this.lvwTechnicalSupervisors.FullRowSelect = true;
            this.lvwTechnicalSupervisors.GridLines = true;
            this.lvwTechnicalSupervisors.Location = new System.Drawing.Point(-2, 104);
            this.lvwTechnicalSupervisors.MultiSelect = false;
            this.lvwTechnicalSupervisors.Name = "lvwTechnicalSupervisors";
            this.lvwTechnicalSupervisors.Size = new System.Drawing.Size(603, 261);
            this.lvwTechnicalSupervisors.TabIndex = 1;
            this.lvwTechnicalSupervisors.UseCompatibleStateImageBehavior = false;
            this.lvwTechnicalSupervisors.View = System.Windows.Forms.View.Details;
            this.lvwTechnicalSupervisors.DoubleClick += new System.EventHandler(this.lvwDoubleClick_Click);
            // 
            // colSupervisorID
            // 
            this.colSupervisorID.Text = "Supervisor ID";
            this.colSupervisorID.Width = 81;
            // 
            // colEmplNo
            // 
            this.colEmplNo.Text = "Empl. No";
            this.colEmplNo.Width = 58;
            // 
            // colSupervisorName
            // 
            this.colSupervisorName.Text = "Supervisor Name";
            this.colSupervisorName.Width = 178;
            // 
            // colDesignation
            // 
            this.colDesignation.Text = "Designation";
            this.colDesignation.Width = 160;
            // 
            // colCategoryName
            // 
            this.colCategoryName.Text = "Category";
            this.colCategoryName.Width = 98;
            // 
            // colISActive
            // 
            this.colISActive.Text = "Is Active";
            this.colISActive.Width = 59;
            // 
            // colusername
            // 
            this.colusername.Text = "Entered   by";
            this.colusername.Width = 81;
            // 
            // colEntryDate
            // 
            this.colEntryDate.Text = "Entry Date";
            this.colEntryDate.Width = 100;
            // 
            // lblSupervisorName
            // 
            this.lblSupervisorName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupervisorName.Location = new System.Drawing.Point(34, 75);
            this.lblSupervisorName.Name = "lblSupervisorName";
            this.lblSupervisorName.Size = new System.Drawing.Size(103, 16);
            this.lblSupervisorName.TabIndex = 151;
            this.lblSupervisorName.Text = "Supervisor Name";
            // 
            // txtEmplCode
            // 
            this.txtEmplCode.Location = new System.Drawing.Point(139, 46);
            this.txtEmplCode.Name = "txtEmplCode";
            this.txtEmplCode.Size = new System.Drawing.Size(88, 20);
            this.txtEmplCode.TabIndex = 150;
            // 
            // lblSupervisorCode
            // 
            this.lblSupervisorCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupervisorCode.Location = new System.Drawing.Point(77, 48);
            this.lblSupervisorCode.Name = "lblSupervisorCode";
            this.lblSupervisorCode.Size = new System.Drawing.Size(60, 13);
            this.lblSupervisorCode.TabIndex = 149;
            this.lblSupervisorCode.Text = "Empl. No";
            // 
            // txtSupervisorID
            // 
            this.txtSupervisorID.Location = new System.Drawing.Point(139, 20);
            this.txtSupervisorID.Name = "txtSupervisorID";
            this.txtSupervisorID.Size = new System.Drawing.Size(88, 20);
            this.txtSupervisorID.TabIndex = 148;
            // 
            // txtEmplName
            // 
            this.txtEmplName.Location = new System.Drawing.Point(139, 72);
            this.txtEmplName.Name = "txtEmplName";
            this.txtEmplName.Size = new System.Drawing.Size(290, 20);
            this.txtEmplName.TabIndex = 152;
            // 
            // lblSupervisorID
            // 
            this.lblSupervisorID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSupervisorID.Location = new System.Drawing.Point(53, 21);
            this.lblSupervisorID.Name = "lblSupervisorID";
            this.lblSupervisorID.Size = new System.Drawing.Size(85, 13);
            this.lblSupervisorID.TabIndex = 147;
            this.lblSupervisorID.Text = "Supervisor ID";
            // 
            // btnGo
            // 
            this.btnGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.Location = new System.Drawing.Point(447, 66);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(68, 27);
            this.btnGo.TabIndex = 156;
            this.btnGo.Text = "&Get Data";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(610, 129);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(84, 27);
            this.btnEdit.TabIndex = 154;
            this.btnEdit.Tag = "";
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(610, 338);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 27);
            this.btnClose.TabIndex = 155;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Location = new System.Drawing.Point(610, 85);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(84, 27);
            this.btnNew.TabIndex = 153;
            this.btnNew.Text = "&New";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.DarkGray;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(526, 372);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 157;
            this.label2.Text = "InActive";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(308, 18);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(121, 21);
            this.cmbCategory.TabIndex = 162;
            // 
            // lblComplainStatus
            // 
            this.lblComplainStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComplainStatus.Location = new System.Drawing.Point(250, 21);
            this.lblComplainStatus.Name = "lblComplainStatus";
            this.lblComplainStatus.Size = new System.Drawing.Size(57, 15);
            this.lblComplainStatus.TabIndex = 163;
            this.lblComplainStatus.Text = "Category";
            // 
            // cmbIsActive
            // 
            this.cmbIsActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIsActive.FormattingEnabled = true;
            this.cmbIsActive.Location = new System.Drawing.Point(308, 44);
            this.cmbIsActive.Name = "cmbIsActive";
            this.cmbIsActive.Size = new System.Drawing.Size(121, 21);
            this.cmbIsActive.TabIndex = 164;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(243, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 165;
            this.label1.Text = "Is Active?";
            // 
            // btnMapping
            // 
            this.btnMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMapping.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMapping.Location = new System.Drawing.Point(610, 173);
            this.btnMapping.Name = "btnMapping";
            this.btnMapping.Size = new System.Drawing.Size(84, 27);
            this.btnMapping.TabIndex = 166;
            this.btnMapping.Tag = "";
            this.btnMapping.Text = "Mapping";
            this.btnMapping.UseVisualStyleBackColor = true;
            this.btnMapping.Click += new System.EventHandler(this.Mapping_Click);
            // 
            // colMobileNo
            // 
            this.colMobileNo.Text = "Mobile No";
            this.colMobileNo.Width = 110;
            // 
            // frmTechnicalSupervisors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 400);
            this.Controls.Add(this.btnMapping);
            this.Controls.Add(this.cmbIsActive);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblComplainStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.lblSupervisorName);
            this.Controls.Add(this.txtEmplCode);
            this.Controls.Add(this.lblSupervisorCode);
            this.Controls.Add(this.txtSupervisorID);
            this.Controls.Add(this.txtEmplName);
            this.Controls.Add(this.lblSupervisorID);
            this.Controls.Add(this.lvwTechnicalSupervisors);
            this.Name = "frmTechnicalSupervisors";
            this.Text = "Technical Supervisors";
            this.Load += new System.EventHandler(this.frmTechnicalSupervisors_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwTechnicalSupervisors;
        private System.Windows.Forms.ColumnHeader colSupervisorID;
        private System.Windows.Forms.ColumnHeader colSupervisorName;
        private System.Windows.Forms.ColumnHeader colCategoryName;
        private System.Windows.Forms.ColumnHeader colISActive;
        private System.Windows.Forms.Label lblSupervisorName;
        private System.Windows.Forms.TextBox txtEmplCode;
        private System.Windows.Forms.Label lblSupervisorCode;
        private System.Windows.Forms.TextBox txtSupervisorID;
        private System.Windows.Forms.TextBox txtEmplName;
        private System.Windows.Forms.Label lblSupervisorID;
        private System.Windows.Forms.ColumnHeader colusername;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.ColumnHeader colDesignation;
        private System.Windows.Forms.ColumnHeader colEntryDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader colEmplNo;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblComplainStatus;
        private System.Windows.Forms.ComboBox cmbIsActive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMapping;
        private System.Windows.Forms.ColumnHeader colMobileNo;
    }
}
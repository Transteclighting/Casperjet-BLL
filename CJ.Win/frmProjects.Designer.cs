namespace CJ.Win
{
    partial class frmProjects
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProjects));
            this.btnAddNewProject = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lvwProjectList = new System.Windows.Forms.ListView();
            this.colProjectNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProjectName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCreateDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProjectManager = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDepartment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colComments = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label4 = new System.Windows.Forms.Label();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.btnGetData = new System.Windows.Forms.Button();
            this.lblProjectNo = new System.Windows.Forms.Label();
            this.txtProjectNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.cmbConcernDepartment = new System.Windows.Forms.ComboBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAddNewProject
            // 
            this.btnAddNewProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNewProject.Location = new System.Drawing.Point(673, 67);
            this.btnAddNewProject.Name = "btnAddNewProject";
            this.btnAddNewProject.Size = new System.Drawing.Size(84, 25);
            this.btnAddNewProject.TabIndex = 0;
            this.btnAddNewProject.Text = "Add Project";
            this.btnAddNewProject.UseVisualStyleBackColor = true;
            this.btnAddNewProject.Click += new System.EventHandler(this.btnAddNewProject_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(673, 98);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(84, 25);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Edit Project";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // lvwProjectList
            // 
            this.lvwProjectList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwProjectList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colProjectNo,
            this.colProjectName,
            this.colCreateDate,
            this.colProjectManager,
            this.colDepartment,
            this.colComments});
            this.lvwProjectList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lvwProjectList.FullRowSelect = true;
            this.lvwProjectList.GridLines = true;
            this.lvwProjectList.HideSelection = false;
            this.lvwProjectList.Location = new System.Drawing.Point(12, 67);
            this.lvwProjectList.MultiSelect = false;
            this.lvwProjectList.Name = "lvwProjectList";
            this.lvwProjectList.Size = new System.Drawing.Size(654, 343);
            this.lvwProjectList.TabIndex = 88;
            this.lvwProjectList.UseCompatibleStateImageBehavior = false;
            this.lvwProjectList.View = System.Windows.Forms.View.Details;
            // 
            // colProjectNo
            // 
            this.colProjectNo.Text = "Project No";
            this.colProjectNo.Width = 80;
            // 
            // colProjectName
            // 
            this.colProjectName.Text = "Project Name";
            this.colProjectName.Width = 155;
            // 
            // colCreateDate
            // 
            this.colCreateDate.Text = "Create Date";
            this.colCreateDate.Width = 89;
            // 
            // colProjectManager
            // 
            this.colProjectManager.Text = "Project Manager";
            this.colProjectManager.Width = 133;
            // 
            // colDepartment
            // 
            this.colDepartment.Text = "Concern Department";
            this.colDepartment.Width = 145;
            // 
            // colComments
            // 
            this.colComments.Text = "Comments";
            this.colComments.Width = 306;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 116;
            this.label4.Text = "Project Name:";
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(101, 39);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(442, 20);
            this.txtProjectName.TabIndex = 111;
            // 
            // btnGetData
            // 
            this.btnGetData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetData.Location = new System.Drawing.Point(549, 37);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(76, 25);
            this.btnGetData.TabIndex = 113;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // lblProjectNo
            // 
            this.lblProjectNo.AutoSize = true;
            this.lblProjectNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjectNo.Location = new System.Drawing.Point(28, 15);
            this.lblProjectNo.Name = "lblProjectNo";
            this.lblProjectNo.Size = new System.Drawing.Size(71, 13);
            this.lblProjectNo.TabIndex = 115;
            this.lblProjectNo.Text = "Project No:";
            // 
            // txtProjectNo
            // 
            this.txtProjectNo.Location = new System.Drawing.Point(101, 12);
            this.txtProjectNo.Name = "txtProjectNo";
            this.txtProjectNo.Size = new System.Drawing.Size(160, 20);
            this.txtProjectNo.TabIndex = 110;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(269, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 114;
            this.label2.Text = "Department";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(673, 385);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 25);
            this.btnClose.TabIndex = 117;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // cmbConcernDepartment
            // 
            this.cmbConcernDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConcernDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbConcernDepartment.FormattingEnabled = true;
            this.cmbConcernDepartment.Location = new System.Drawing.Point(344, 12);
            this.cmbConcernDepartment.Name = "cmbConcernDepartment";
            this.cmbConcernDepartment.Size = new System.Drawing.Size(199, 21);
            this.cmbConcernDepartment.TabIndex = 125;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(673, 129);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(84, 25);
            this.btnPrint.TabIndex = 126;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click_1);
            // 
            // frmProjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 422);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.cmbConcernDepartment);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtProjectName);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.lblProjectNo);
            this.Controls.Add(this.txtProjectNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lvwProjectList);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAddNewProject);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProjects";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmProjects";
            this.Load += new System.EventHandler(this.frmProjects_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAddNewProject;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.ListView lvwProjectList;
        private System.Windows.Forms.ColumnHeader colProjectNo;
        private System.Windows.Forms.ColumnHeader colProjectName;
        private System.Windows.Forms.ColumnHeader colCreateDate;
        private System.Windows.Forms.ColumnHeader colProjectManager;
        private System.Windows.Forms.ColumnHeader colDepartment;
        private System.Windows.Forms.ColumnHeader colComments;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.Label lblProjectNo;
        private System.Windows.Forms.TextBox txtProjectNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cmbConcernDepartment;
        private System.Windows.Forms.Button btnPrint;
    }
}
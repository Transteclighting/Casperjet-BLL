namespace CJ.Win
{
    partial class frmProjectDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProjectDetails));
            this.btnClose = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.btnGetData = new System.Windows.Forms.Button();
            this.lblProjectNo = new System.Windows.Forms.Label();
            this.txtProjectNo = new System.Windows.Forms.TextBox();
            this.lvwProjectList = new System.Windows.Forms.ListView();
            this.colProjectNo = new System.Windows.Forms.ColumnHeader();
            this.colProjectName = new System.Windows.Forms.ColumnHeader();
            this.colProjectManager = new System.Windows.Forms.ColumnHeader();
            this.colSubProjectName = new System.Windows.Forms.ColumnHeader();
            this.colProjectType = new System.Windows.Forms.ColumnHeader();
            this.colPriority = new System.Windows.Forms.ColumnHeader();
            this.colConcernDepartment = new System.Windows.Forms.ColumnHeader();
            this.colProjectSize = new System.Windows.Forms.ColumnHeader();
            this.colStartDate = new System.Windows.Forms.ColumnHeader();
            this.colEndDate = new System.Windows.Forms.ColumnHeader();
            this.colKeyPerson = new System.Windows.Forms.ColumnHeader();
            this.colResourceType = new System.Windows.Forms.ColumnHeader();
            this.colCompany = new System.Windows.Forms.ColumnHeader();
            this.colWorkPercent = new System.Windows.Forms.ColumnHeader();
            this.colRemarks = new System.Windows.Forms.ColumnHeader();
            this.btnAddNewProject = new System.Windows.Forms.Button();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtSubProject = new System.Windows.Forms.TextBox();
            this.cmbConcernDepartment = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(596, 384);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 25);
            this.btnClose.TabIndex = 135;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 134;
            this.label4.Text = "Project Name:";
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(101, 66);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(373, 20);
            this.txtProjectName.TabIndex = 129;
            // 
            // btnGetData
            // 
            this.btnGetData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetData.Location = new System.Drawing.Point(480, 86);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(76, 25);
            this.btnGetData.TabIndex = 131;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // lblProjectNo
            // 
            this.lblProjectNo.AutoSize = true;
            this.lblProjectNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProjectNo.Location = new System.Drawing.Point(28, 16);
            this.lblProjectNo.Name = "lblProjectNo";
            this.lblProjectNo.Size = new System.Drawing.Size(71, 13);
            this.lblProjectNo.TabIndex = 133;
            this.lblProjectNo.Text = "Project No:";
            // 
            // txtProjectNo
            // 
            this.txtProjectNo.Location = new System.Drawing.Point(101, 13);
            this.txtProjectNo.Name = "txtProjectNo";
            this.txtProjectNo.Size = new System.Drawing.Size(199, 20);
            this.txtProjectNo.TabIndex = 128;
            // 
            // lvwProjectList
            // 
            this.lvwProjectList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwProjectList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colProjectNo,
            this.colProjectName,
            this.colProjectManager,
            this.colSubProjectName,
            this.colProjectType,
            this.colPriority,
            this.colConcernDepartment,
            this.colProjectSize,
            this.colStartDate,
            this.colEndDate,
            this.colKeyPerson,
            this.colResourceType,
            this.colCompany,
            this.colWorkPercent,
            this.colRemarks});
            this.lvwProjectList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lvwProjectList.FullRowSelect = true;
            this.lvwProjectList.GridLines = true;
            this.lvwProjectList.HideSelection = false;
            this.lvwProjectList.Location = new System.Drawing.Point(12, 118);
            this.lvwProjectList.MultiSelect = false;
            this.lvwProjectList.Name = "lvwProjectList";
            this.lvwProjectList.Size = new System.Drawing.Size(576, 291);
            this.lvwProjectList.TabIndex = 127;
            this.lvwProjectList.UseCompatibleStateImageBehavior = false;
            this.lvwProjectList.View = System.Windows.Forms.View.Details;
            // 
            // colProjectNo
            // 
            this.colProjectNo.Text = "Project No";
            this.colProjectNo.Width = 72;
            // 
            // colProjectName
            // 
            this.colProjectName.Text = "Project Name";
            this.colProjectName.Width = 108;
            // 
            // colProjectManager
            // 
            this.colProjectManager.Text = "Project Manager";
            this.colProjectManager.Width = 101;
            // 
            // colSubProjectName
            // 
            this.colSubProjectName.Text = "Sub Project Name";
            this.colSubProjectName.Width = 119;
            // 
            // colProjectType
            // 
            this.colProjectType.Text = "Project Type";
            this.colProjectType.Width = 74;
            // 
            // colPriority
            // 
            this.colPriority.Text = "Priority";
            this.colPriority.Width = 66;
            // 
            // colConcernDepartment
            // 
            this.colConcernDepartment.Text = "Concern Department";
            this.colConcernDepartment.Width = 111;
            // 
            // colProjectSize
            // 
            this.colProjectSize.Text = "Project Size";
            this.colProjectSize.Width = 68;
            // 
            // colStartDate
            // 
            this.colStartDate.Text = "Start Date";
            this.colStartDate.Width = 86;
            // 
            // colEndDate
            // 
            this.colEndDate.Text = "End Date";
            this.colEndDate.Width = 82;
            // 
            // colKeyPerson
            // 
            this.colKeyPerson.Text = "Key Person";
            this.colKeyPerson.Width = 91;
            // 
            // colResourceType
            // 
            this.colResourceType.Text = "Resource Type";
            this.colResourceType.Width = 77;
            // 
            // colCompany
            // 
            this.colCompany.Text = "Company";
            this.colCompany.Width = 76;
            // 
            // colWorkPercent
            // 
            this.colWorkPercent.Text = "Work Percent";
            this.colWorkPercent.Width = 74;
            // 
            // colRemarks
            // 
            this.colRemarks.Text = "Remarks";
            // 
            // btnAddNewProject
            // 
            this.btnAddNewProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNewProject.Location = new System.Drawing.Point(596, 118);
            this.btnAddNewProject.Name = "btnAddNewProject";
            this.btnAddNewProject.Size = new System.Drawing.Size(92, 25);
            this.btnAddNewProject.TabIndex = 124;
            this.btnAddNewProject.Text = "Add Sub-Project";
            this.btnAddNewProject.UseVisualStyleBackColor = true;
            this.btnAddNewProject.Click += new System.EventHandler(this.btnAddNewProject_Click);
            // 
            // btnAddTask
            // 
            this.btnAddTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddTask.Location = new System.Drawing.Point(596, 180);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(92, 25);
            this.btnAddTask.TabIndex = 124;
            this.btnAddTask.Text = "Add Task";
            this.btnAddTask.UseVisualStyleBackColor = true;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(22, 95);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 143;
            this.label7.Text = "Sub-Project:";
            // 
            // txtSubProject
            // 
            this.txtSubProject.Location = new System.Drawing.Point(101, 92);
            this.txtSubProject.Name = "txtSubProject";
            this.txtSubProject.Size = new System.Drawing.Size(373, 20);
            this.txtSubProject.TabIndex = 142;
            // 
            // cmbConcernDepartment
            // 
            this.cmbConcernDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConcernDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbConcernDepartment.FormattingEnabled = true;
            this.cmbConcernDepartment.Location = new System.Drawing.Point(101, 39);
            this.cmbConcernDepartment.Name = "cmbConcernDepartment";
            this.cmbConcernDepartment.Size = new System.Drawing.Size(199, 21);
            this.cmbConcernDepartment.TabIndex = 145;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 144;
            this.label2.Text = "Department";
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(596, 149);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(92, 25);
            this.btnEdit.TabIndex = 146;
            this.btnEdit.Text = "Edit Sub-Project";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // frmProjectDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(694, 421);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.cmbConcernDepartment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtSubProject);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtProjectName);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.lblProjectNo);
            this.Controls.Add(this.txtProjectNo);
            this.Controls.Add(this.lvwProjectList);
            this.Controls.Add(this.btnAddTask);
            this.Controls.Add(this.btnAddNewProject);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProjectDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmProjectDetails";
            this.Load += new System.EventHandler(this.frmProjectDetails_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.Label lblProjectNo;
        private System.Windows.Forms.TextBox txtProjectNo;
        private System.Windows.Forms.ListView lvwProjectList;
        private System.Windows.Forms.ColumnHeader colProjectNo;
        private System.Windows.Forms.ColumnHeader colProjectName;
        private System.Windows.Forms.ColumnHeader colProjectManager;
        private System.Windows.Forms.Button btnAddNewProject;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.ColumnHeader colSubProjectName;
        private System.Windows.Forms.ColumnHeader colProjectType;
        private System.Windows.Forms.ColumnHeader colPriority;
        private System.Windows.Forms.ColumnHeader colConcernDepartment;
        private System.Windows.Forms.ColumnHeader colProjectSize;
        private System.Windows.Forms.ColumnHeader colStartDate;
        private System.Windows.Forms.ColumnHeader colEndDate;
        private System.Windows.Forms.ColumnHeader colKeyPerson;
        private System.Windows.Forms.ColumnHeader colResourceType;
        private System.Windows.Forms.ColumnHeader colCompany;
        private System.Windows.Forms.ColumnHeader colWorkPercent;
        private System.Windows.Forms.ColumnHeader colRemarks;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtSubProject;
        private System.Windows.Forms.ComboBox cmbConcernDepartment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnEdit;
    }
}
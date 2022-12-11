namespace CJ.Win.HR
{
    partial class frmBEILEmployeeDistSets
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBEILEmployeeDistSets));
            this.lvwBEILEmployeeDistSet = new System.Windows.Forms.ListView();
            this.colEmpName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEmpDeptCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDistSet = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDistSetDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtDistSet = new System.Windows.Forms.TextBox();
            this.lblDistSet = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.ctlEmployee1 = new CJ.Win.ctlEmployee();
            this.SuspendLayout();
            // 
            // lvwBEILEmployeeDistSet
            // 
            this.lvwBEILEmployeeDistSet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwBEILEmployeeDistSet.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colEmpName,
            this.colEmpDeptCode,
            this.colDistSet,
            this.colDistSetDesc});
            this.lvwBEILEmployeeDistSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwBEILEmployeeDistSet.FullRowSelect = true;
            this.lvwBEILEmployeeDistSet.GridLines = true;
            this.lvwBEILEmployeeDistSet.HideSelection = false;
            this.lvwBEILEmployeeDistSet.Location = new System.Drawing.Point(10, 70);
            this.lvwBEILEmployeeDistSet.MultiSelect = false;
            this.lvwBEILEmployeeDistSet.Name = "lvwBEILEmployeeDistSet";
            this.lvwBEILEmployeeDistSet.Size = new System.Drawing.Size(594, 211);
            this.lvwBEILEmployeeDistSet.TabIndex = 5;
            this.lvwBEILEmployeeDistSet.UseCompatibleStateImageBehavior = false;
            this.lvwBEILEmployeeDistSet.View = System.Windows.Forms.View.Details;
            this.lvwBEILEmployeeDistSet.DoubleClick += new System.EventHandler(this.double_Click);
            // 
            // colEmpName
            // 
            this.colEmpName.Text = "Employee Name";
            this.colEmpName.Width = 159;
            // 
            // colEmpDeptCode
            // 
            this.colEmpDeptCode.Text = "Employee Dept";
            this.colEmpDeptCode.Width = 117;
            // 
            // colDistSet
            // 
            this.colDistSet.Text = "Distribution Set";
            this.colDistSet.Width = 117;
            // 
            // colDistSetDesc
            // 
            this.colDistSetDesc.Text = "Dist Set Description";
            this.colDistSetDesc.Width = 172;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(284, 39);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(68, 25);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtDistSet
            // 
            this.txtDistSet.Location = new System.Drawing.Point(114, 42);
            this.txtDistSet.Name = "txtDistSet";
            this.txtDistSet.Size = new System.Drawing.Size(164, 20);
            this.txtDistSet.TabIndex = 3;
            // 
            // lblDistSet
            // 
            this.lblDistSet.AutoSize = true;
            this.lblDistSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistSet.Location = new System.Drawing.Point(18, 43);
            this.lblDistSet.Name = "lblDistSet";
            this.lblDistSet.Size = new System.Drawing.Size(90, 15);
            this.lblDistSet.TabIndex = 2;
            this.lblDistSet.Text = "Distribution Set";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(610, 253);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(68, 28);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(610, 108);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(68, 27);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(610, 70);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(68, 27);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Employee Name";
            // 
            // ctlEmployee1
            // 
            this.ctlEmployee1.Location = new System.Drawing.Point(114, 11);
            this.ctlEmployee1.Name = "ctlEmployee1";
            this.ctlEmployee1.Size = new System.Drawing.Size(499, 25);
            this.ctlEmployee1.TabIndex = 1;
            // 
            // frmBEILEmployeeDistSets
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 293);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ctlEmployee1);
            this.Controls.Add(this.lvwBEILEmployeeDistSet);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtDistSet);
            this.Controls.Add(this.lblDistSet);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBEILEmployeeDistSets";
            this.Text = "BEIL Employee Dist Sets";
            this.Load += new System.EventHandler(this.frmBEILEmployeeDistSets_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwBEILEmployeeDistSet;
        private System.Windows.Forms.ColumnHeader colEmpName;
        private System.Windows.Forms.ColumnHeader colEmpDeptCode;
        private System.Windows.Forms.ColumnHeader colDistSet;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtDistSet;
        private System.Windows.Forms.Label lblDistSet;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ColumnHeader colDistSetDesc;
        private System.Windows.Forms.Label label5;
        private ctlEmployee ctlEmployee1;
    }
}
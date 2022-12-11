namespace CJ.POS
{
    partial class frmDayPlans
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
            this.lvwDayPlans = new System.Windows.Forms.ListView();
            this.colPlanNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEmployee = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.dtFromdate = new System.Windows.Forms.DateTimePicker();
            this.dtTodate = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtPlanNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbEmpoyee = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwDayPlans
            // 
            this.lvwDayPlans.AllowColumnReorder = true;
            this.lvwDayPlans.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwDayPlans.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPlanNo,
            this.colEmployee,
            this.colLocation,
            this.colStatus});
            this.lvwDayPlans.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwDayPlans.FullRowSelect = true;
            this.lvwDayPlans.GridLines = true;
            this.lvwDayPlans.HideSelection = false;
            this.lvwDayPlans.Location = new System.Drawing.Point(12, 134);
            this.lvwDayPlans.Name = "lvwDayPlans";
            this.lvwDayPlans.Size = new System.Drawing.Size(535, 186);
            this.lvwDayPlans.TabIndex = 15;
            this.lvwDayPlans.UseCompatibleStateImageBehavior = false;
            this.lvwDayPlans.View = System.Windows.Forms.View.Details;
            // 
            // colPlanNo
            // 
            this.colPlanNo.Text = "Plan No";
            this.colPlanNo.Width = 120;
            // 
            // colEmployee
            // 
            this.colEmployee.Text = "Employee";
            this.colEmployee.Width = 196;
            // 
            // colLocation
            // 
            this.colLocation.Text = "Location";
            this.colLocation.Width = 153;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 87;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Enabled = false;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(553, 169);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(90, 30);
            this.btnEdit.TabIndex = 18;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(553, 134);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 30);
            this.btnAdd.TabIndex = 17;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkAll);
            this.groupBox2.Controls.Add(this.dtFromdate);
            this.groupBox2.Controls.Add(this.dtTodate);
            this.groupBox2.Controls.Add(this.lblTo);
            this.groupBox2.Controls.Add(this.lblFrom);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(379, 58);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "    ";
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.chkAll.Location = new System.Drawing.Point(14, 0);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(160, 17);
            this.chkAll.TabIndex = 0;
            this.chkAll.Text = "Enable/Disable Data Range";
            this.chkAll.UseVisualStyleBackColor = true;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // dtFromdate
            // 
            this.dtFromdate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromdate.Location = new System.Drawing.Point(51, 28);
            this.dtFromdate.Name = "dtFromdate";
            this.dtFromdate.Size = new System.Drawing.Size(122, 21);
            this.dtFromdate.TabIndex = 2;
            // 
            // dtTodate
            // 
            this.dtTodate.CustomFormat = "dd-MMM-yyyy";
            this.dtTodate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTodate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTodate.Location = new System.Drawing.Point(235, 28);
            this.dtTodate.Name = "dtTodate";
            this.dtTodate.Size = new System.Drawing.Size(121, 21);
            this.dtTodate.TabIndex = 4;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Location = new System.Drawing.Point(205, 31);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(21, 15);
            this.lblTo.TabIndex = 3;
            this.lblTo.Text = "To";
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Location = new System.Drawing.Point(10, 30);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(36, 15);
            this.lblFrom.TabIndex = 1;
            this.lblFrom.Text = "From";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnSearch.Location = new System.Drawing.Point(304, 99);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(87, 29);
            this.btnSearch.TabIndex = 24;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.Location = new System.Drawing.Point(15, 77);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(51, 15);
            this.lblCode.TabIndex = 20;
            this.lblCode.Text = "Plan No";
            // 
            // txtPlanNo
            // 
            this.txtPlanNo.Location = new System.Drawing.Point(97, 76);
            this.txtPlanNo.Name = "txtPlanNo";
            this.txtPlanNo.Size = new System.Drawing.Size(201, 20);
            this.txtPlanNo.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 67;
            this.label1.Text = "Employee";
            // 
            // cmbEmpoyee
            // 
            this.cmbEmpoyee.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpoyee.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEmpoyee.FormattingEnabled = true;
            this.cmbEmpoyee.Location = new System.Drawing.Point(97, 102);
            this.cmbEmpoyee.Name = "cmbEmpoyee";
            this.cmbEmpoyee.Size = new System.Drawing.Size(201, 23);
            this.cmbEmpoyee.TabIndex = 66;
            // 
            // frmDayPlans
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 358);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbEmpoyee);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.txtPlanNo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lvwDayPlans);
            this.Name = "frmDayPlans";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDayPlans";
            this.Load += new System.EventHandler(this.frmDayPlans_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwDayPlans;
        private System.Windows.Forms.ColumnHeader colPlanNo;
        private System.Windows.Forms.ColumnHeader colEmployee;
        private System.Windows.Forms.ColumnHeader colLocation;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.DateTimePicker dtFromdate;
        private System.Windows.Forms.DateTimePicker dtTodate;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtPlanNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbEmpoyee;
    }
}
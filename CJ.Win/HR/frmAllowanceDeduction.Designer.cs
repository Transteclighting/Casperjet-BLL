namespace CJ.Win.HR
{
    partial class frmAllowanceDeduction
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
            this.lvwAllowDedu = new System.Windows.Forms.ListView();
            this.colCode = new System.Windows.Forms.ColumnHeader();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colAllowDed = new System.Windows.Forms.ColumnHeader();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lvwAllDedGrade = new System.Windows.Forms.ListView();
            this.AllDedname = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.btnGradeAdd = new System.Windows.Forms.Button();
            this.btnGradeEdit = new System.Windows.Forms.Button();
            this.btnGradeDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvwAllowDedu
            // 
            this.lvwAllowDedu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwAllowDedu.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCode,
            this.colName,
            this.colAllowDed});
            this.lvwAllowDedu.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwAllowDedu.FullRowSelect = true;
            this.lvwAllowDedu.GridLines = true;
            this.lvwAllowDedu.HideSelection = false;
            this.lvwAllowDedu.Location = new System.Drawing.Point(12, 11);
            this.lvwAllowDedu.MultiSelect = false;
            this.lvwAllowDedu.Name = "lvwAllowDedu";
            this.lvwAllowDedu.Size = new System.Drawing.Size(489, 230);
            this.lvwAllowDedu.TabIndex = 1;
            this.lvwAllowDedu.UseCompatibleStateImageBehavior = false;
            this.lvwAllowDedu.View = System.Windows.Forms.View.Details;
            //this.lvwAllowDedu.SelectedIndexChanged += new System.EventHandler(this.lvwAllowDedu_SelectedIndexChanged);
            // 
            // colCode
            // 
            this.colCode.Text = "Code";
            this.colCode.Width = 100;
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 150;
            // 
            // colAllowDed
            // 
            this.colAllowDed.Text = "AllowanceDeduction";
            this.colAllowDed.Width = 150;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(507, 92);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(83, 23);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(507, 121);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(83, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(507, 63);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(83, 23);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click_1);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(507, 34);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lvwAllDedGrade
            // 
            this.lvwAllDedGrade.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwAllDedGrade.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AllDedname,
            this.columnHeader2});
            this.lvwAllDedGrade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwAllDedGrade.FullRowSelect = true;
            this.lvwAllDedGrade.GridLines = true;
            this.lvwAllDedGrade.HideSelection = false;
            this.lvwAllDedGrade.Location = new System.Drawing.Point(12, 329);
            this.lvwAllDedGrade.MultiSelect = false;
            this.lvwAllDedGrade.Name = "lvwAllDedGrade";
            this.lvwAllDedGrade.Size = new System.Drawing.Size(489, 196);
            this.lvwAllDedGrade.TabIndex = 8;
            this.lvwAllDedGrade.UseCompatibleStateImageBehavior = false;
            this.lvwAllDedGrade.View = System.Windows.Forms.View.Details;
            ///this.lvwAllDedGrade.SelectedIndexChanged += new System.EventHandler(this.lvwAllDedGrade_SelectedIndexChanged);
            // 
            // AllDedname
            // 
            this.AllDedname.Text = "AllowanceDeductionName ";
            this.AllDedname.Width = 250;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "GradeName";
            this.columnHeader2.Width = 150;
            // 
            // btnGradeAdd
            // 
            this.btnGradeAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGradeAdd.Location = new System.Drawing.Point(507, 333);
            this.btnGradeAdd.Name = "btnGradeAdd";
            this.btnGradeAdd.Size = new System.Drawing.Size(75, 23);
            this.btnGradeAdd.TabIndex = 9;
            this.btnGradeAdd.Text = "GradeAdd";
            this.btnGradeAdd.UseVisualStyleBackColor = true;
            this.btnGradeAdd.Click += new System.EventHandler(this.btnGradeAdd_Click);
            // 
            // btnGradeEdit
            // 
            this.btnGradeEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGradeEdit.Location = new System.Drawing.Point(507, 371);
            this.btnGradeEdit.Name = "btnGradeEdit";
            this.btnGradeEdit.Size = new System.Drawing.Size(75, 23);
            this.btnGradeEdit.TabIndex = 10;
            this.btnGradeEdit.Text = "Edit";
            this.btnGradeEdit.UseVisualStyleBackColor = true;
            this.btnGradeEdit.Click += new System.EventHandler(this.btnGradeEdit_Click);
            // 
            // btnGradeDelete
            // 
            this.btnGradeDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGradeDelete.Location = new System.Drawing.Point(507, 400);
            this.btnGradeDelete.Name = "btnGradeDelete";
            this.btnGradeDelete.Size = new System.Drawing.Size(75, 23);
            this.btnGradeDelete.TabIndex = 11;
            this.btnGradeDelete.Text = "Delete";
            this.btnGradeDelete.UseVisualStyleBackColor = true;
            this.btnGradeDelete.Click += new System.EventHandler(this.btnGradeDelete_Click);
            // 
            // frmAllowanceDeduction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 537);
            this.Controls.Add(this.btnGradeDelete);
            this.Controls.Add(this.btnGradeEdit);
            this.Controls.Add(this.btnGradeAdd);
            this.Controls.Add(this.lvwAllDedGrade);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.lvwAllowDedu);
            this.Name = "frmAllowanceDeduction";
            this.Text = "frmAllowanceDeduction";
            this.Load += new System.EventHandler(this.frmAllowanceDeduction_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwAllowDedu;
        private System.Windows.Forms.ColumnHeader colCode;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ColumnHeader colAllowDed;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView lvwAllDedGrade;
        private System.Windows.Forms.ColumnHeader AllDedname;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnGradeAdd;
        private System.Windows.Forms.Button btnGradeEdit;
        private System.Windows.Forms.Button btnGradeDelete;
    }
}
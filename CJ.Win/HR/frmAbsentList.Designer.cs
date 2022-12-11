namespace CJ.Win.HR
{
    partial class frmAbsentList
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
            this.lvwAttendDatas = new System.Windows.Forms.ListView();
            this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAbsentDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDesigantion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDepartment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCompany = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // lvwAttendDatas
            // 
            this.lvwAttendDatas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwAttendDatas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colName,
            this.colDesigantion,
            this.colDepartment,
            this.colCompany,
            this.colAbsentDate});
            this.lvwAttendDatas.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwAttendDatas.FullRowSelect = true;
            this.lvwAttendDatas.GridLines = true;
            this.lvwAttendDatas.HideSelection = false;
            this.lvwAttendDatas.Location = new System.Drawing.Point(21, 13);
            this.lvwAttendDatas.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvwAttendDatas.MultiSelect = false;
            this.lvwAttendDatas.Name = "lvwAttendDatas";
            this.lvwAttendDatas.Size = new System.Drawing.Size(806, 407);
            this.lvwAttendDatas.TabIndex = 10;
            this.lvwAttendDatas.UseCompatibleStateImageBehavior = false;
            this.lvwAttendDatas.View = System.Windows.Forms.View.Details;
            // 
            // colID
            // 
            this.colID.Text = "Employee Code";
            this.colID.Width = 581;
            // 
            // colName
            // 
            this.colName.Text = "Employee Name";
            this.colName.Width = 143;
            // 
            // colAbsentDate
            // 
            this.colAbsentDate.Text = "Absent Date";
            this.colAbsentDate.Width = 133;
            // 
            // colDesigantion
            // 
            this.colDesigantion.Text = "Designation";
            this.colDesigantion.Width = 134;
            // 
            // colDepartment
            // 
            this.colDepartment.Text = "Department";
            this.colDepartment.Width = 170;
            // 
            // colCompany
            // 
            this.colCompany.Text = "Company";
            this.colCompany.Width = 130;
            // 
            // frmAbsentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(839, 433);
            this.Controls.Add(this.lvwAttendDatas);
            this.Name = "frmAbsentList";
            this.Text = "frmAbsentList";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwAttendDatas;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colDesigantion;
        private System.Windows.Forms.ColumnHeader colDepartment;
        private System.Windows.Forms.ColumnHeader colCompany;
        private System.Windows.Forms.ColumnHeader colAbsentDate;
    }
}
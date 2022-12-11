namespace CJ.Win.HR
{
    partial class frmHRShiftMappings
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.lvwShiftMapping = new System.Windows.Forms.ListView();
            this.colDate = new System.Windows.Forms.ColumnHeader();
            this.colShiftName = new System.Windows.Forms.ColumnHeader();
            this.colRelayName = new System.Windows.Forms.ColumnHeader();
            this.colCreatedBy = new System.Windows.Forms.ColumnHeader();
            this.lblShift = new System.Windows.Forms.Label();
            this.cmbHRShift = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtShiftMappingMonth = new System.Windows.Forms.DateTimePicker();
            this.btnGet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(621, 40);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(83, 25);
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lvwShiftMapping
            // 
            this.lvwShiftMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwShiftMapping.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDate,
            this.colShiftName,
            this.colRelayName,
            this.colCreatedBy});
            this.lvwShiftMapping.FullRowSelect = true;
            this.lvwShiftMapping.GridLines = true;
            this.lvwShiftMapping.Location = new System.Drawing.Point(12, 40);
            this.lvwShiftMapping.Name = "lvwShiftMapping";
            this.lvwShiftMapping.Size = new System.Drawing.Size(604, 314);
            this.lvwShiftMapping.TabIndex = 5;
            this.lvwShiftMapping.UseCompatibleStateImageBehavior = false;
            this.lvwShiftMapping.View = System.Windows.Forms.View.Details;
            // 
            // colDate
            // 
            this.colDate.Text = "Date";
            this.colDate.Width = 75;
            // 
            // colShiftName
            // 
            this.colShiftName.Text = "Shift Name";
            this.colShiftName.Width = 157;
            // 
            // colRelayName
            // 
            this.colRelayName.Text = "Relay Name";
            this.colRelayName.Width = 185;
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.Text = "Created By";
            this.colCreatedBy.Width = 179;
            // 
            // lblShift
            // 
            this.lblShift.AutoSize = true;
            this.lblShift.Location = new System.Drawing.Point(157, 16);
            this.lblShift.Name = "lblShift";
            this.lblShift.Size = new System.Drawing.Size(28, 13);
            this.lblShift.TabIndex = 2;
            this.lblShift.Text = "Shift";
            // 
            // cmbHRShift
            // 
            this.cmbHRShift.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHRShift.FormattingEnabled = true;
            this.cmbHRShift.Location = new System.Drawing.Point(186, 12);
            this.cmbHRShift.Name = "cmbHRShift";
            this.cmbHRShift.Size = new System.Drawing.Size(166, 21);
            this.cmbHRShift.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Month";
            // 
            // dtShiftMappingMonth
            // 
            this.dtShiftMappingMonth.CustomFormat = "MMM-yyyy";
            this.dtShiftMappingMonth.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtShiftMappingMonth.Location = new System.Drawing.Point(49, 12);
            this.dtShiftMappingMonth.Name = "dtShiftMappingMonth";
            this.dtShiftMappingMonth.Size = new System.Drawing.Size(101, 20);
            this.dtShiftMappingMonth.TabIndex = 1;
            // 
            // btnGet
            // 
            this.btnGet.Location = new System.Drawing.Point(513, 9);
            this.btnGet.Name = "btnGet";
            this.btnGet.Size = new System.Drawing.Size(83, 25);
            this.btnGet.TabIndex = 4;
            this.btnGet.Text = "Get";
            this.btnGet.UseVisualStyleBackColor = true;
            this.btnGet.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // frmHRShiftMappings
            // 
            this.AcceptButton = this.btnGet;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 365);
            this.Controls.Add(this.btnGet);
            this.Controls.Add(this.lblShift);
            this.Controls.Add(this.cmbHRShift);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtShiftMappingMonth);
            this.Controls.Add(this.lvwShiftMapping);
            this.Controls.Add(this.btnAdd);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHRShiftMappings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Shift Mapping";
            this.Load += new System.EventHandler(this.frmHRShiftMapping_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView lvwShiftMapping;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colShiftName;
        private System.Windows.Forms.ColumnHeader colRelayName;
        private System.Windows.Forms.ColumnHeader colCreatedBy;
        private System.Windows.Forms.Label lblShift;
        private System.Windows.Forms.ComboBox cmbHRShift;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtShiftMappingMonth;
        private System.Windows.Forms.Button btnGet;
    }
}
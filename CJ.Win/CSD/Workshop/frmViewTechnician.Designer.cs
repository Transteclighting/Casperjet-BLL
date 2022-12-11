namespace CJ.Win.CSD.Workshop
{
    partial class frmViewTechnician
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
            this.lvwTechnicians = new System.Windows.Forms.ListView();
            this.colCode = new System.Windows.Forms.ColumnHeader();
            this.colTechnicianName = new System.Windows.Forms.ColumnHeader();
            this.colWorkshop = new System.Windows.Forms.ColumnHeader();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbWorkshop = new System.Windows.Forms.ComboBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvwTechnicians
            // 
            this.lvwTechnicians.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCode,
            this.colTechnicianName,
            this.colWorkshop});
            this.lvwTechnicians.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwTechnicians.FullRowSelect = true;
            this.lvwTechnicians.GridLines = true;
            this.lvwTechnicians.HideSelection = false;
            this.lvwTechnicians.Location = new System.Drawing.Point(10, 42);
            this.lvwTechnicians.MultiSelect = false;
            this.lvwTechnicians.Name = "lvwTechnicians";
            this.lvwTechnicians.Size = new System.Drawing.Size(298, 336);
            this.lvwTechnicians.TabIndex = 19;
            this.lvwTechnicians.UseCompatibleStateImageBehavior = false;
            this.lvwTechnicians.View = System.Windows.Forms.View.Details;
            this.lvwTechnicians.DoubleClick += new System.EventHandler(this.lvwTechnicians_DoubleClick);
            this.lvwTechnicians.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvwTechnicians_KeyPress);
            // 
            // colCode
            // 
            this.colCode.Text = "Code";
            this.colCode.Width = 50;
            // 
            // colTechnicianName
            // 
            this.colTechnicianName.Text = "Technician Name";
            this.colTechnicianName.Width = 127;
            // 
            // colWorkshop
            // 
            this.colWorkshop.Text = "Workshop";
            this.colWorkshop.Width = 100;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(28, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Workshop";
            // 
            // cmbWorkshop
            // 
            this.cmbWorkshop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorkshop.FormattingEnabled = true;
            this.cmbWorkshop.Location = new System.Drawing.Point(94, 8);
            this.cmbWorkshop.Name = "cmbWorkshop";
            this.cmbWorkshop.Size = new System.Drawing.Size(143, 21);
            this.cmbWorkshop.TabIndex = 21;
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.Location = new System.Drawing.Point(243, 8);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(67, 23);
            this.btnGo.TabIndex = 22;
            this.btnGo.Text = "&Get Data";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // frmViewTechnician
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 390);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbWorkshop);
            this.Controls.Add(this.lvwTechnicians);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmViewTechnician";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Technicians";
            this.Load += new System.EventHandler(this.frmViewTechnician_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwTechnicians;
        private System.Windows.Forms.ColumnHeader colTechnicianName;
        private System.Windows.Forms.ColumnHeader colCode;
        private System.Windows.Forms.ColumnHeader colWorkshop;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbWorkshop;
        private System.Windows.Forms.Button btnGo;
    }
}
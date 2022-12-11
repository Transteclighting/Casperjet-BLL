namespace CJ.Win
{
    partial class frmSearchThana
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
            this.txtDistrict = new System.Windows.Forms.TextBox();
            this.lblContactNo = new System.Windows.Forms.Label();
            this.txtThana = new System.Windows.Forms.TextBox();
            this.lblThana = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lvwThanaSearch = new System.Windows.Forms.ListView();
            this.colThanaCode = new System.Windows.Forms.ColumnHeader();
            this.colThanaName = new System.Windows.Forms.ColumnHeader();
            this.colDistrictCode = new System.Windows.Forms.ColumnHeader();
            this.colDistrictName = new System.Windows.Forms.ColumnHeader();
            this.txtThanaCode = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtDistrict
            // 
            this.txtDistrict.Location = new System.Drawing.Point(418, 18);
            this.txtDistrict.Name = "txtDistrict";
            this.txtDistrict.Size = new System.Drawing.Size(124, 20);
            this.txtDistrict.TabIndex = 171;
            this.txtDistrict.TextChanged += new System.EventHandler(this.txtDistrict_TextChanged);
            // 
            // lblContactNo
            // 
            this.lblContactNo.AutoSize = true;
            this.lblContactNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContactNo.Location = new System.Drawing.Point(368, 21);
            this.lblContactNo.Name = "lblContactNo";
            this.lblContactNo.Size = new System.Drawing.Size(47, 13);
            this.lblContactNo.TabIndex = 170;
            this.lblContactNo.Text = "District";
            // 
            // txtThana
            // 
            this.txtThana.Location = new System.Drawing.Point(213, 18);
            this.txtThana.Name = "txtThana";
            this.txtThana.Size = new System.Drawing.Size(137, 20);
            this.txtThana.TabIndex = 169;
            this.txtThana.TextChanged += new System.EventHandler(this.txtThana_TextChanged);
            // 
            // lblThana
            // 
            this.lblThana.AutoSize = true;
            this.lblThana.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThana.Location = new System.Drawing.Point(168, 21);
            this.lblThana.Name = "lblThana";
            this.lblThana.Size = new System.Drawing.Size(43, 13);
            this.lblThana.TabIndex = 168;
            this.lblThana.Text = "Thana";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(437, 300);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 27);
            this.btnClose.TabIndex = 166;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lvwThanaSearch
            // 
            this.lvwThanaSearch.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colThanaCode,
            this.colThanaName,
            this.colDistrictCode,
            this.colDistrictName});
            this.lvwThanaSearch.FullRowSelect = true;
            this.lvwThanaSearch.GridLines = true;
            this.lvwThanaSearch.Location = new System.Drawing.Point(22, 49);
            this.lvwThanaSearch.Name = "lvwThanaSearch";
            this.lvwThanaSearch.Size = new System.Drawing.Size(520, 243);
            this.lvwThanaSearch.TabIndex = 165;
            this.lvwThanaSearch.UseCompatibleStateImageBehavior = false;
            this.lvwThanaSearch.View = System.Windows.Forms.View.Details;
            this.lvwThanaSearch.DoubleClick += new System.EventHandler(this.lvwThanaSearch_DoubleClick);
            this.lvwThanaSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvwThanaSearch_KeyPress);
            // 
            // colThanaCode
            // 
            this.colThanaCode.Text = "Thana Code";
            this.colThanaCode.Width = 76;
            // 
            // colThanaName
            // 
            this.colThanaName.Text = "Thana Name";
            this.colThanaName.Width = 176;
            // 
            // colDistrictCode
            // 
            this.colDistrictCode.Text = "District Code";
            this.colDistrictCode.Width = 77;
            // 
            // colDistrictName
            // 
            this.colDistrictName.Text = "District Name";
            this.colDistrictName.Width = 175;
            // 
            // txtThanaCode
            // 
            this.txtThanaCode.Location = new System.Drawing.Point(92, 18);
            this.txtThanaCode.Name = "txtThanaCode";
            this.txtThanaCode.Size = new System.Drawing.Size(68, 20);
            this.txtThanaCode.TabIndex = 175;
            this.txtThanaCode.TextChanged += new System.EventHandler(this.txtThanaCode_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 174;
            this.label1.Text = "Thana Code";
            // 
            // frmSearchThana
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 339);
            this.Controls.Add(this.txtThanaCode);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDistrict);
            this.Controls.Add(this.lblContactNo);
            this.Controls.Add(this.txtThana);
            this.Controls.Add(this.lblThana);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lvwThanaSearch);
            this.Name = "frmSearchThana";
            this.Text = "Thana Search";
            this.Load += new System.EventHandler(this.frmThanSearch_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDistrict;
        private System.Windows.Forms.Label lblContactNo;
        private System.Windows.Forms.TextBox txtThana;
        private System.Windows.Forms.Label lblThana;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListView lvwThanaSearch;
        private System.Windows.Forms.ColumnHeader colThanaCode;
        private System.Windows.Forms.ColumnHeader colThanaName;
        private System.Windows.Forms.ColumnHeader colDistrictCode;
        private System.Windows.Forms.ColumnHeader colDistrictName;
        private System.Windows.Forms.TextBox txtThanaCode;
        private System.Windows.Forms.Label label1;
    }
}
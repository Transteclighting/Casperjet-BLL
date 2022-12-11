namespace CJ.Win
{
    partial class frmSparePartSearch
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
            this.txtBrand = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtModel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGetData = new System.Windows.Forms.Button();
            this.lblJobNo = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblSPName = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.lvwSPSearch = new System.Windows.Forms.ListView();
            this.colSPCode = new System.Windows.Forms.ColumnHeader();
            this.colSPName = new System.Windows.Forms.ColumnHeader();
            this.colModelNo = new System.Windows.Forms.ColumnHeader();
            this.colBrand = new System.Windows.Forms.ColumnHeader();
            this.colBin = new System.Windows.Forms.ColumnHeader();
            this.txtLocationCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtBrand
            // 
            this.txtBrand.Location = new System.Drawing.Point(315, 36);
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.Size = new System.Drawing.Size(154, 20);
            this.txtBrand.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(273, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Brand";
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(315, 12);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(154, 20);
            this.txtModel.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(272, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Model";
            // 
            // btnGetData
            // 
            this.btnGetData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetData.Location = new System.Drawing.Point(415, 66);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(105, 31);
            this.btnGetData.TabIndex = 10;
            this.btnGetData.Text = "GetData";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // lblJobNo
            // 
            this.lblJobNo.AutoSize = true;
            this.lblJobNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobNo.Location = new System.Drawing.Point(36, 15);
            this.lblJobNo.Name = "lblJobNo";
            this.lblJobNo.Size = new System.Drawing.Size(73, 13);
            this.lblJobNo.TabIndex = 0;
            this.lblJobNo.Text = "Spare Code";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(111, 35);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(141, 20);
            this.txtName.TabIndex = 3;
            // 
            // lblSPName
            // 
            this.lblSPName.AutoSize = true;
            this.lblSPName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSPName.Location = new System.Drawing.Point(33, 38);
            this.lblSPName.Name = "lblSPName";
            this.lblSPName.Size = new System.Drawing.Size(76, 13);
            this.lblSPName.TabIndex = 2;
            this.lblSPName.Text = "Spare Name";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(111, 12);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(141, 20);
            this.txtCode.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(435, 272);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 27);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lvwSPSearch
            // 
            this.lvwSPSearch.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSPCode,
            this.colSPName,
            this.colModelNo,
            this.colBrand,
            this.colBin});
            this.lvwSPSearch.FullRowSelect = true;
            this.lvwSPSearch.GridLines = true;
            this.lvwSPSearch.Location = new System.Drawing.Point(6, 103);
            this.lvwSPSearch.Name = "lvwSPSearch";
            this.lvwSPSearch.Size = new System.Drawing.Size(540, 156);
            this.lvwSPSearch.TabIndex = 11;
            this.lvwSPSearch.UseCompatibleStateImageBehavior = false;
            this.lvwSPSearch.View = System.Windows.Forms.View.Details;
            this.lvwSPSearch.DoubleClick += new System.EventHandler(this.lvwSPSearch_DoubleClick);
            this.lvwSPSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvwSPSearch_KeyPress);
            // 
            // colSPCode
            // 
            this.colSPCode.Text = "SP Code";
            this.colSPCode.Width = 102;
            // 
            // colSPName
            // 
            this.colSPName.Text = "SP Name";
            this.colSPName.Width = 168;
            // 
            // colModelNo
            // 
            this.colModelNo.Text = "Model";
            this.colModelNo.Width = 82;
            // 
            // colBrand
            // 
            this.colBrand.Text = "Brand";
            this.colBrand.Width = 95;
            // 
            // colBin
            // 
            this.colBin.Text = "Location Code";
            this.colBin.Width = 84;
            // 
            // txtLocationCode
            // 
            this.txtLocationCode.Location = new System.Drawing.Point(111, 59);
            this.txtLocationCode.Name = "txtLocationCode";
            this.txtLocationCode.Size = new System.Drawing.Size(141, 20);
            this.txtLocationCode.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(20, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Location Code";
            // 
            // frmSparePartSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(558, 311);
            this.Controls.Add(this.txtLocationCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBrand);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtModel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.lblJobNo);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblSPName);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lvwSPSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmSparePartSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spare Part Search";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBrand;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtModel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.Label lblJobNo;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblSPName;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListView lvwSPSearch;
        private System.Windows.Forms.ColumnHeader colSPCode;
        private System.Windows.Forms.ColumnHeader colSPName;
        private System.Windows.Forms.ColumnHeader colModelNo;
        private System.Windows.Forms.ColumnHeader colBrand;
        private System.Windows.Forms.ColumnHeader colBin;
        private System.Windows.Forms.TextBox txtLocationCode;
        private System.Windows.Forms.Label label3;
    }
}
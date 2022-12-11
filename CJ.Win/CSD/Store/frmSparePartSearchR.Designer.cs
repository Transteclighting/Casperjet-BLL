namespace CJ.Win
{
    partial class frmSparePartSearchR
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
            this.txtLocationCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
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
            this.lvwSPSearchR = new System.Windows.Forms.ListView();
            this.colSPCode = new System.Windows.Forms.ColumnHeader();
            this.colSPName = new System.Windows.Forms.ColumnHeader();
            this.colModelNo = new System.Windows.Forms.ColumnHeader();
            this.colBrand = new System.Windows.Forms.ColumnHeader();
            this.colBin = new System.Windows.Forms.ColumnHeader();
            this.colCurrentStock = new System.Windows.Forms.ColumnHeader();
            this.colRSP = new System.Windows.Forms.ColumnHeader();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbStore = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // txtLocationCode
            // 
            this.txtLocationCode.Location = new System.Drawing.Point(101, 34);
            this.txtLocationCode.Name = "txtLocationCode";
            this.txtLocationCode.Size = new System.Drawing.Size(141, 20);
            this.txtLocationCode.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Location Code";
            // 
            // txtBrand
            // 
            this.txtBrand.Location = new System.Drawing.Point(304, 34);
            this.txtBrand.Name = "txtBrand";
            this.txtBrand.Size = new System.Drawing.Size(154, 20);
            this.txtBrand.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(262, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Brand";
            // 
            // txtModel
            // 
            this.txtModel.Location = new System.Drawing.Point(304, 12);
            this.txtModel.Name = "txtModel";
            this.txtModel.Size = new System.Drawing.Size(154, 20);
            this.txtModel.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(261, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Model";
            // 
            // btnGetData
            // 
            this.btnGetData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGetData.Location = new System.Drawing.Point(464, 74);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(82, 27);
            this.btnGetData.TabIndex = 12;
            this.btnGetData.Text = "GetData";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // lblJobNo
            // 
            this.lblJobNo.AutoSize = true;
            this.lblJobNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobNo.Location = new System.Drawing.Point(26, 15);
            this.lblJobNo.Name = "lblJobNo";
            this.lblJobNo.Size = new System.Drawing.Size(73, 13);
            this.lblJobNo.TabIndex = 0;
            this.lblJobNo.Text = "Spare Code";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(101, 57);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(357, 20);
            this.txtName.TabIndex = 9;
            // 
            // lblSPName
            // 
            this.lblSPName.AutoSize = true;
            this.lblSPName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSPName.Location = new System.Drawing.Point(23, 60);
            this.lblSPName.Name = "lblSPName";
            this.lblSPName.Size = new System.Drawing.Size(76, 13);
            this.lblSPName.TabIndex = 8;
            this.lblSPName.Text = "Spare Name";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(101, 12);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(141, 20);
            this.txtCode.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(643, 453);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(105, 27);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lvwSPSearchR
            // 
            this.lvwSPSearchR.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSPCode,
            this.colSPName,
            this.colModelNo,
            this.colBrand,
            this.colBin,
            this.colCurrentStock,
            this.colRSP});
            this.lvwSPSearchR.FullRowSelect = true;
            this.lvwSPSearchR.GridLines = true;
            this.lvwSPSearchR.Location = new System.Drawing.Point(13, 109);
            this.lvwSPSearchR.Name = "lvwSPSearchR";
            this.lvwSPSearchR.Size = new System.Drawing.Size(735, 338);
            this.lvwSPSearchR.TabIndex = 13;
            this.lvwSPSearchR.UseCompatibleStateImageBehavior = false;
            this.lvwSPSearchR.View = System.Windows.Forms.View.Details;
            this.lvwSPSearchR.DoubleClick += new System.EventHandler(this.lvwSPSearchR_DoubleClick);
            this.lvwSPSearchR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvwSPSearchR_KeyPress);
            // 
            // colSPCode
            // 
            this.colSPCode.Text = "Part Code";
            this.colSPCode.Width = 102;
            // 
            // colSPName
            // 
            this.colSPName.Text = "Part Name";
            this.colSPName.Width = 182;
            // 
            // colModelNo
            // 
            this.colModelNo.Text = "Model";
            this.colModelNo.Width = 113;
            // 
            // colBrand
            // 
            this.colBrand.Text = "Brand";
            this.colBrand.Width = 100;
            // 
            // colBin
            // 
            this.colBin.Text = "Location Code";
            this.colBin.Width = 92;
            // 
            // colCurrentStock
            // 
            this.colCurrentStock.Text = "Stock";
            this.colCurrentStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colCurrentStock.Width = 63;
            // 
            // colRSP
            // 
            this.colRSP.Text = "RSP";
            this.colRSP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colRSP.Width = 78;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(60, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Store";
            // 
            // cmbStore
            // 
            this.cmbStore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStore.FormattingEnabled = true;
            this.cmbStore.Location = new System.Drawing.Point(101, 80);
            this.cmbStore.Name = "cmbStore";
            this.cmbStore.Size = new System.Drawing.Size(357, 21);
            this.cmbStore.TabIndex = 11;
            // 
            // frmSparePartSearchR
            // 
            this.AcceptButton = this.btnGetData;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 486);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbStore);
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
            this.Controls.Add(this.lvwSPSearchR);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSparePartSearchR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spare Part Search";
            this.Load += new System.EventHandler(this.frmSparePartSearchR_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLocationCode;
        private System.Windows.Forms.Label label3;
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
        private System.Windows.Forms.ListView lvwSPSearchR;
        private System.Windows.Forms.ColumnHeader colSPCode;
        private System.Windows.Forms.ColumnHeader colSPName;
        private System.Windows.Forms.ColumnHeader colModelNo;
        private System.Windows.Forms.ColumnHeader colBrand;
        private System.Windows.Forms.ColumnHeader colBin;
        private System.Windows.Forms.ColumnHeader colCurrentStock;
        private System.Windows.Forms.ColumnHeader colRSP;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbStore;
    }
}
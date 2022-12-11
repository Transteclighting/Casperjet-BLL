namespace CJ.Win.ERP
{
    partial class frmMapERPWareHouses
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMapERPWareHouses));
            this.lvwERPWarehouse = new System.Windows.Forms.ListView();
            this.colWareHouseDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colWareHouseERPCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colWareHouseCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtWHCode = new System.Windows.Forms.TextBox();
            this.txtWHERPCode = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtWHDesc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvwERPWarehouse
            // 
            this.lvwERPWarehouse.AllowColumnReorder = true;
            this.lvwERPWarehouse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwERPWarehouse.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colWareHouseDesc,
            this.colWareHouseERPCode,
            this.colWareHouseCode});
            this.lvwERPWarehouse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwERPWarehouse.FullRowSelect = true;
            this.lvwERPWarehouse.GridLines = true;
            this.lvwERPWarehouse.HideSelection = false;
            this.lvwERPWarehouse.Location = new System.Drawing.Point(12, 88);
            this.lvwERPWarehouse.Name = "lvwERPWarehouse";
            this.lvwERPWarehouse.Size = new System.Drawing.Size(455, 210);
            this.lvwERPWarehouse.TabIndex = 7;
            this.lvwERPWarehouse.UseCompatibleStateImageBehavior = false;
            this.lvwERPWarehouse.View = System.Windows.Forms.View.Details;
            this.lvwERPWarehouse.DoubleClick += new System.EventHandler(this.double_Click);
            // 
            // colWareHouseDesc
            // 
            this.colWareHouseDesc.Text = "Warehouse Description";
            this.colWareHouseDesc.Width = 156;
            // 
            // colWareHouseERPCode
            // 
            this.colWareHouseERPCode.Text = "Warehouse ERP Code";
            this.colWareHouseERPCode.Width = 142;
            // 
            // colWareHouseCode
            // 
            this.colWareHouseCode.Text = "Warehouse Casper Code";
            this.colWareHouseCode.Width = 153;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(375, 52);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(92, 30);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(473, 268);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 30);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(473, 124);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(92, 30);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(473, 88);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(92, 30);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtWHCode
            // 
            this.txtWHCode.Location = new System.Drawing.Point(160, 61);
            this.txtWHCode.Name = "txtWHCode";
            this.txtWHCode.Size = new System.Drawing.Size(206, 20);
            this.txtWHCode.TabIndex = 5;
            this.txtWHCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWHCode_KeyPress);
            // 
            // txtWHERPCode
            // 
            this.txtWHERPCode.Location = new System.Drawing.Point(160, 35);
            this.txtWHERPCode.Name = "txtWHERPCode";
            this.txtWHERPCode.Size = new System.Drawing.Size(206, 20);
            this.txtWHERPCode.TabIndex = 3;
            this.txtWHERPCode.TextChanged += new System.EventHandler(this.txtWHERPCode_TextChanged);
            this.txtWHERPCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWHERPCode_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(17, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "WareHouse Description";
            // 
            // txtWHDesc
            // 
            this.txtWHDesc.Location = new System.Drawing.Point(160, 9);
            this.txtWHDesc.Name = "txtWHDesc";
            this.txtWHDesc.Size = new System.Drawing.Size(206, 20);
            this.txtWHDesc.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(10, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Warehouse Casper Code";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Warehouse ERP Code";
            // 
            // frmMapERPWareHouses
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(574, 310);
            this.Controls.Add(this.txtWHCode);
            this.Controls.Add(this.txtWHERPCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtWHDesc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lvwERPWarehouse);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMapERPWareHouses";
            this.Text = "Map ERP WareHouses";
            this.Load += new System.EventHandler(this.frmMapERPWareHouses_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lvwERPWarehouse;
        private System.Windows.Forms.ColumnHeader colWareHouseDesc;
        private System.Windows.Forms.ColumnHeader colWareHouseERPCode;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ColumnHeader colWareHouseCode;
        private System.Windows.Forms.TextBox txtWHCode;
        private System.Windows.Forms.TextBox txtWHERPCode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtWHDesc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
    }
}
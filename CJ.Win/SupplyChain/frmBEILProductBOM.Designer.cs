namespace CJ.Win.SupplyChain
{
    partial class frmBEILProductBOM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBEILProductBOM));
            this.lvwBEILProductBOMList2 = new System.Windows.Forms.ListView();
            this.colGroupID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGroupName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFMTComp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDescrption = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colQty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colUnit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCostAllocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblCode = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFMTComp = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCostAllocation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtQty = new System.Windows.Forms.TextBox();
            this.cmbBOMGroup = new System.Windows.Forms.ComboBox();
            this.ctlProduct1 = new CJ.Control.ctlProduct();
            this.linkDelete = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lvwBEILProductBOMList2
            // 
            this.lvwBEILProductBOMList2.AllowColumnReorder = true;
            this.lvwBEILProductBOMList2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwBEILProductBOMList2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colGroupID,
            this.colGroupName,
            this.colFMTComp,
            this.colDescrption,
            this.colQty,
            this.colUnit,
            this.colCostAllocation});
            this.lvwBEILProductBOMList2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwBEILProductBOMList2.FullRowSelect = true;
            this.lvwBEILProductBOMList2.GridLines = true;
            this.lvwBEILProductBOMList2.HideSelection = false;
            this.lvwBEILProductBOMList2.Location = new System.Drawing.Point(12, 166);
            this.lvwBEILProductBOMList2.Name = "lvwBEILProductBOMList2";
            this.lvwBEILProductBOMList2.Size = new System.Drawing.Size(621, 201);
            this.lvwBEILProductBOMList2.TabIndex = 14;
            this.lvwBEILProductBOMList2.UseCompatibleStateImageBehavior = false;
            this.lvwBEILProductBOMList2.View = System.Windows.Forms.View.Details;
            this.lvwBEILProductBOMList2.DoubleClick += new System.EventHandler(this.double_Click);
            // 
            // colGroupID
            // 
            this.colGroupID.Text = "Group ID";
            this.colGroupID.Width = 64;
            // 
            // colGroupName
            // 
            this.colGroupName.Text = "Group Name";
            this.colGroupName.Width = 95;
            // 
            // colFMTComp
            // 
            this.colFMTComp.Text = "FMT Comp";
            this.colFMTComp.Width = 94;
            // 
            // colDescrption
            // 
            this.colDescrption.Text = "Description";
            this.colDescrption.Width = 138;
            // 
            // colQty
            // 
            this.colQty.Text = "Qty";
            this.colQty.Width = 57;
            // 
            // colUnit
            // 
            this.colUnit.Text = "Unit";
            this.colUnit.Width = 51;
            // 
            // colCostAllocation
            // 
            this.colCostAllocation.Text = "Cost Allocation(%)";
            this.colCostAllocation.Width = 111;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(59, 13);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(49, 15);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "Product";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(541, 373);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 30);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(443, 373);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 31);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(67, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Group";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(338, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "FMT Comp";
            // 
            // txtFMTComp
            // 
            this.txtFMTComp.Location = new System.Drawing.Point(412, 45);
            this.txtFMTComp.Name = "txtFMTComp";
            this.txtFMTComp.Size = new System.Drawing.Size(221, 21);
            this.txtFMTComp.TabIndex = 5;
            this.txtFMTComp.TextChanged += new System.EventHandler(this.txtFMTComp_TextChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(541, 129);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(92, 31);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(412, 103);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Cost Allocation(%)";
            // 
            // txtCostAllocation
            // 
            this.txtCostAllocation.Location = new System.Drawing.Point(521, 102);
            this.txtCostAllocation.Name = "txtCostAllocation";
            this.txtCostAllocation.Size = new System.Drawing.Size(112, 21);
            this.txtCostAllocation.TabIndex = 12;
            this.txtCostAllocation.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Double_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.Location = new System.Drawing.Point(39, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Description";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(114, 75);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(519, 21);
            this.txtDesc.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label5.Location = new System.Drawing.Point(256, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 15);
            this.label5.TabIndex = 44;
            this.label5.Text = "Unit";
            // 
            // txtUnit
            // 
            this.txtUnit.Location = new System.Drawing.Point(291, 102);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.Size = new System.Drawing.Size(115, 21);
            this.txtUnit.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label6.Location = new System.Drawing.Point(82, 102);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(24, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "Qty";
            // 
            // txtQty
            // 
            this.txtQty.Location = new System.Drawing.Point(114, 102);
            this.txtQty.Name = "txtQty";
            this.txtQty.Size = new System.Drawing.Size(124, 21);
            this.txtQty.TabIndex = 9;
            this.txtQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IntegerOnly_KeyPress);
            // 
            // cmbBOMGroup
            // 
            this.cmbBOMGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBOMGroup.FormattingEnabled = true;
            this.cmbBOMGroup.Location = new System.Drawing.Point(114, 43);
            this.cmbBOMGroup.Name = "cmbBOMGroup";
            this.cmbBOMGroup.Size = new System.Drawing.Size(204, 23);
            this.cmbBOMGroup.TabIndex = 3;
            // 
            // ctlProduct1
            // 
            this.ctlProduct1.Location = new System.Drawing.Point(114, 12);
            this.ctlProduct1.Name = "ctlProduct1";
            this.ctlProduct1.Size = new System.Drawing.Size(519, 25);
            this.ctlProduct1.TabIndex = 45;
            this.ctlProduct1.ChangeSelection += new System.EventHandler(this.ctlProduct1_ChangeSelection);
            // 
            // linkDelete
            // 
            this.linkDelete.AutoSize = true;
            this.linkDelete.Location = new System.Drawing.Point(13, 147);
            this.linkDelete.Name = "linkDelete";
            this.linkDelete.Size = new System.Drawing.Size(43, 15);
            this.linkDelete.TabIndex = 46;
            this.linkDelete.TabStop = true;
            this.linkDelete.Text = "Delete";
            this.linkDelete.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkDelete_LinkClicked);
            // 
            // frmBEILProductBOM
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(652, 418);
            this.Controls.Add(this.linkDelete);
            this.Controls.Add(this.ctlProduct1);
            this.Controls.Add(this.cmbBOMGroup);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtQty);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCostAllocation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFMTComp);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lvwBEILProductBOMList2);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmBEILProductBOM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BEIL Product BOM";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwBEILProductBOMList2;
        private System.Windows.Forms.ColumnHeader colDescrption;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFMTComp;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ColumnHeader colQty;
        private System.Windows.Forms.ColumnHeader colUnit;
        private System.Windows.Forms.ColumnHeader colCostAllocation;
        private System.Windows.Forms.ColumnHeader colFMTComp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCostAllocation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUnit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtQty;
        private System.Windows.Forms.ComboBox cmbBOMGroup;
        private CJ.Control.ctlProduct ctlProduct1;
        private System.Windows.Forms.ColumnHeader colGroupID;
        private System.Windows.Forms.ColumnHeader colGroupName;
        private System.Windows.Forms.LinkLabel linkDelete;
    }
}
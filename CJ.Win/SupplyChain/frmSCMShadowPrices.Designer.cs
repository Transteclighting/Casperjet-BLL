namespace CJ.Win.SupplyChain
{
    partial class frmSCMShadowPrices
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
            this.ctlProduct1 = new CJ.Control.ctlProduct();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lvwPriceList = new System.Windows.Forms.ListView();
            this.Code = new System.Windows.Forms.ColumnHeader();
            this.Name = new System.Windows.Forms.ColumnHeader();
            this.AG = new System.Windows.Forms.ColumnHeader();
            this.ASG = new System.Windows.Forms.ColumnHeader();
            this.MAG = new System.Windows.Forms.ColumnHeader();
            this.PG = new System.Windows.Forms.ColumnHeader();
            this.colPrice = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGetdata = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctlProduct1
            // 
            this.ctlProduct1.Location = new System.Drawing.Point(62, 12);
            this.ctlProduct1.Name = "ctlProduct1";
            this.ctlProduct1.Size = new System.Drawing.Size(424, 24);
            this.ctlProduct1.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(635, 42);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(635, 349);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lvwPriceList
            // 
            this.lvwPriceList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwPriceList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Code,
            this.Name,
            this.AG,
            this.ASG,
            this.MAG,
            this.PG,
            this.colPrice});
            this.lvwPriceList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwPriceList.FullRowSelect = true;
            this.lvwPriceList.GridLines = true;
            this.lvwPriceList.HideSelection = false;
            this.lvwPriceList.Location = new System.Drawing.Point(12, 42);
            this.lvwPriceList.MultiSelect = false;
            this.lvwPriceList.Name = "lvwPriceList";
            this.lvwPriceList.Size = new System.Drawing.Size(617, 330);
            this.lvwPriceList.TabIndex = 55;
            this.lvwPriceList.UseCompatibleStateImageBehavior = false;
            this.lvwPriceList.View = System.Windows.Forms.View.Details;
            // 
            // Code
            // 
            this.Code.Text = "Product Code";
            this.Code.Width = 98;
            // 
            // Name
            // 
            this.Name.Text = "Product Name";
            this.Name.Width = 206;
            // 
            // AG
            // 
            this.AG.Text = "AG";
            this.AG.Width = 101;
            // 
            // ASG
            // 
            this.ASG.Text = "ASG";
            this.ASG.Width = 101;
            // 
            // MAG
            // 
            this.MAG.Text = "MAG";
            this.MAG.Width = 98;
            // 
            // PG
            // 
            this.PG.Text = "PG";
            this.PG.Width = 47;
            // 
            // colPrice
            // 
            this.colPrice.Text = "Shadow Price";
            this.colPrice.Width = 92;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 56;
            this.label1.Text = "Product";
            // 
            // btnGetdata
            // 
            this.btnGetdata.Location = new System.Drawing.Point(492, 13);
            this.btnGetdata.Name = "btnGetdata";
            this.btnGetdata.Size = new System.Drawing.Size(75, 23);
            this.btnGetdata.TabIndex = 57;
            this.btnGetdata.Text = "Get Data";
            this.btnGetdata.UseVisualStyleBackColor = true;
            this.btnGetdata.Click += new System.EventHandler(this.btnGetdata_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(635, 71);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 58;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(635, 100);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 59;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // frmSCMShadowPrices
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 384);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnGetdata);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvwPriceList);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.ctlProduct1);
            //this.Name = "frmSCMShadowPrices";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmSCMShadowPrices";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CJ.Control.ctlProduct ctlProduct1;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListView lvwPriceList;
        private System.Windows.Forms.ColumnHeader Code;
        private System.Windows.Forms.ColumnHeader Name;
        private System.Windows.Forms.ColumnHeader AG;
        private System.Windows.Forms.ColumnHeader ASG;
        private System.Windows.Forms.ColumnHeader MAG;
        private System.Windows.Forms.ColumnHeader PG;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGetdata;
        private System.Windows.Forms.ColumnHeader colPrice;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
    }
}
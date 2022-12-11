namespace CJ.POS.RT
{
    partial class frmAvailableBarcode
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAvailableBarcode));
            this.lvBarcode = new System.Windows.Forms.ListView();
            this.colAvailableBarcode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIsVatPaidProduct = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSaleAfter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colIsDefective = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.btSelect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnValidateBarcode = new System.Windows.Forms.Button();
            this.txtIMEIList = new System.Windows.Forms.RichTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.colIsTransitStock = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvBarcode
            // 
            this.lvBarcode.CheckBoxes = true;
            this.lvBarcode.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAvailableBarcode,
            this.colIsVatPaidProduct,
            this.colSaleAfter,
            this.colIsDefective,
            this.colIsTransitStock});
            this.lvBarcode.FullRowSelect = true;
            this.lvBarcode.GridLines = true;
            this.lvBarcode.HideSelection = false;
            this.lvBarcode.Location = new System.Drawing.Point(12, 81);
            this.lvBarcode.MultiSelect = false;
            this.lvBarcode.Name = "lvBarcode";
            this.lvBarcode.Size = new System.Drawing.Size(434, 267);
            this.lvBarcode.TabIndex = 2;
            this.lvBarcode.UseCompatibleStateImageBehavior = false;
            this.lvBarcode.View = System.Windows.Forms.View.Details;
            this.lvBarcode.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvBarcode_ItemChecked);
            // 
            // colAvailableBarcode
            // 
            this.colAvailableBarcode.Text = "Barcode";
            this.colAvailableBarcode.Width = 194;
            // 
            // colIsVatPaidProduct
            // 
            this.colIsVatPaidProduct.Text = "Is Vat Paid";
            this.colIsVatPaidProduct.Width = 75;
            // 
            // colSaleAfter
            // 
            this.colSaleAfter.Text = "Sale After";
            this.colSaleAfter.Width = 76;
            // 
            // colIsDefective
            // 
            this.colIsDefective.Text = "Is Defective";
            this.colIsDefective.Width = 76;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(9, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // btSelect
            // 
            this.btSelect.Location = new System.Drawing.Point(357, 355);
            this.btSelect.Name = "btSelect";
            this.btSelect.Size = new System.Drawing.Size(87, 29);
            this.btSelect.TabIndex = 3;
            this.btSelect.Text = "Ok";
            this.btSelect.UseVisualStyleBackColor = true;
            this.btSelect.Click += new System.EventHandler(this.btSelect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(9, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // btnValidateBarcode
            // 
            this.btnValidateBarcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnValidateBarcode.Location = new System.Drawing.Point(452, 197);
            this.btnValidateBarcode.Name = "btnValidateBarcode";
            this.btnValidateBarcode.Size = new System.Drawing.Size(32, 33);
            this.btnValidateBarcode.TabIndex = 42;
            this.btnValidateBarcode.Text = "<<";
            this.btnValidateBarcode.UseVisualStyleBackColor = true;
            this.btnValidateBarcode.Click += new System.EventHandler(this.btnValidateBarcode_Click);
            // 
            // txtIMEIList
            // 
            this.txtIMEIList.Location = new System.Drawing.Point(0, 18);
            this.txtIMEIList.Name = "txtIMEIList";
            this.txtIMEIList.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.txtIMEIList.Size = new System.Drawing.Size(178, 267);
            this.txtIMEIList.TabIndex = 43;
            this.txtIMEIList.Text = "";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtIMEIList);
            this.groupBox2.Location = new System.Drawing.Point(490, 63);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(179, 286);
            this.groupBox2.TabIndex = 44;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Barcode";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(577, 362);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 16);
            this.label3.TabIndex = 48;
            this.label3.Text = "Wrong Barcode";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Red;
            this.panel1.Location = new System.Drawing.Point(546, 365);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(25, 11);
            this.panel1.TabIndex = 47;
            // 
            // colIsTransitStock
            // 
            this.colIsTransitStock.Text = "Is Transit";
            // 
            // frmAvailableBarcode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(681, 388);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnValidateBarcode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btSelect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvBarcode);
            this.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmAvailableBarcode";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Available Barcode";
            this.Load += new System.EventHandler(this.frmAvailableBarcode_Load);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvBarcode;
        private System.Windows.Forms.ColumnHeader colAvailableBarcode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btSelect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader colIsVatPaidProduct;
        private System.Windows.Forms.ColumnHeader colSaleAfter;
        private System.Windows.Forms.ColumnHeader colIsDefective;
        private System.Windows.Forms.Button btnValidateBarcode;
        private System.Windows.Forms.RichTextBox txtIMEIList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColumnHeader colIsTransitStock;
    }
}
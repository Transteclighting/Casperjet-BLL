namespace CJ.Win
{
    partial class frmProductPortfolios
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
            this.lvwProductPortfolio = new System.Windows.Forms.ListView();
            this.colProductID = new System.Windows.Forms.ColumnHeader();
            this.colProductName = new System.Windows.Forms.ColumnHeader();
            this.colASGName = new System.Windows.Forms.ColumnHeader();
            this.colIsActive = new System.Windows.Forms.ColumnHeader();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnIsActive = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtProductID = new System.Windows.Forms.TextBox();
            this.txtASG = new System.Windows.Forms.TextBox();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lvwProductPortfolio
            // 
            this.lvwProductPortfolio.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colProductID,
            this.colProductName,
            this.colASGName,
            this.colIsActive});
            this.lvwProductPortfolio.FullRowSelect = true;
            this.lvwProductPortfolio.GridLines = true;
            this.lvwProductPortfolio.Location = new System.Drawing.Point(13, 103);
            this.lvwProductPortfolio.MultiSelect = false;
            this.lvwProductPortfolio.Name = "lvwProductPortfolio";
            this.lvwProductPortfolio.Size = new System.Drawing.Size(492, 378);
            this.lvwProductPortfolio.TabIndex = 217;
            this.lvwProductPortfolio.UseCompatibleStateImageBehavior = false;
            this.lvwProductPortfolio.View = System.Windows.Forms.View.Details;
            this.lvwProductPortfolio.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvwProductPortfolio_MouseDoubleClick);
            this.lvwProductPortfolio.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lvwProductPortfolio_MouseClick);
            // 
            // colProductID
            // 
            this.colProductID.Text = "Product ID";
            this.colProductID.Width = 88;
            // 
            // colProductName
            // 
            this.colProductName.Text = "Product Name";
            this.colProductName.Width = 228;
            // 
            // colASGName
            // 
            this.colASGName.Text = "ASG Name";
            this.colASGName.Width = 108;
            // 
            // colIsActive
            // 
            this.colIsActive.Text = "IsActive";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(516, 106);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 218;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(516, 135);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 219;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnIsActive
            // 
            this.btnIsActive.Location = new System.Drawing.Point(516, 164);
            this.btnIsActive.Name = "btnIsActive";
            this.btnIsActive.Size = new System.Drawing.Size(75, 23);
            this.btnIsActive.TabIndex = 220;
            this.btnIsActive.Text = "IsActive";
            this.btnIsActive.UseVisualStyleBackColor = true;
            this.btnIsActive.Click += new System.EventHandler(this.btnIsActive_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 221;
            this.label1.Text = "Product Id";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 222;
            this.label2.Text = "Product Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 223;
            this.label3.Text = "ASG";
            // 
            // txtProductID
            // 
            this.txtProductID.Location = new System.Drawing.Point(105, 21);
            this.txtProductID.Name = "txtProductID";
            this.txtProductID.Size = new System.Drawing.Size(202, 20);
            this.txtProductID.TabIndex = 224;
            this.txtProductID.TextChanged += new System.EventHandler(this.txtProductID_TextChanged);
            // 
            // txtASG
            // 
            this.txtASG.Location = new System.Drawing.Point(105, 71);
            this.txtASG.Name = "txtASG";
            this.txtASG.Size = new System.Drawing.Size(202, 20);
            this.txtASG.TabIndex = 225;
            this.txtASG.TextChanged += new System.EventHandler(this.txtASG_TextChanged);
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(105, 46);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(202, 20);
            this.txtProductName.TabIndex = 226;
            this.txtProductName.TextChanged += new System.EventHandler(this.txtProductName_TextChanged);
            // 
            // frmProductPortfolios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 496);
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.txtASG);
            this.Controls.Add(this.txtProductID);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnIsActive);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lvwProductPortfolio);
            this.Name = "frmProductPortfolios";
            this.Text = "fromProductPortfolio";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwProductPortfolio;
        private System.Windows.Forms.ColumnHeader colProductID;
        private System.Windows.Forms.ColumnHeader colProductName;
        private System.Windows.Forms.ColumnHeader colASGName;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnIsActive;
        private System.Windows.Forms.ColumnHeader colIsActive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtProductID;
        private System.Windows.Forms.TextBox txtASG;
        private System.Windows.Forms.TextBox txtProductName;
    }
}
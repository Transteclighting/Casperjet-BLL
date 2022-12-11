namespace CJ.Win.Promotion
{
    partial class frmConsumerPromotionDiscountContributors
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsumerPromotionDiscountContributors));
            this.lvwDiscountSharingType = new System.Windows.Forms.ListView();
            this.colDiscountSharingType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCreateUser = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCreateDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCloseDiscountSharingType = new System.Windows.Forms.Button();
            this.btnAddDiscountSharingType = new System.Windows.Forms.Button();
            this.txtDiscountContributorName = new System.Windows.Forms.TextBox();
            this.lblDistSet = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvwDiscountSharingType
            // 
            this.lvwDiscountSharingType.AllowColumnReorder = true;
            this.lvwDiscountSharingType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwDiscountSharingType.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDiscountSharingType,
            this.colCreateUser,
            this.colCreateDate});
            this.lvwDiscountSharingType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwDiscountSharingType.FullRowSelect = true;
            this.lvwDiscountSharingType.GridLines = true;
            this.lvwDiscountSharingType.HideSelection = false;
            this.lvwDiscountSharingType.Location = new System.Drawing.Point(14, 51);
            this.lvwDiscountSharingType.Name = "lvwDiscountSharingType";
            this.lvwDiscountSharingType.Size = new System.Drawing.Size(479, 202);
            this.lvwDiscountSharingType.TabIndex = 3;
            this.lvwDiscountSharingType.UseCompatibleStateImageBehavior = false;
            this.lvwDiscountSharingType.View = System.Windows.Forms.View.Details;
            // 
            // colDiscountSharingType
            // 
            this.colDiscountSharingType.Text = "Discount Contributor Name";
            this.colDiscountSharingType.Width = 163;
            // 
            // colCreateUser
            // 
            this.colCreateUser.Text = "Create User";
            this.colCreateUser.Width = 127;
            // 
            // colCreateDate
            // 
            this.colCreateDate.Text = "Create Date";
            this.colCreateDate.Width = 104;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(607, 167);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(12, 32);
            this.btnClose.TabIndex = 44;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(607, 59);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(12, 32);
            this.btnAdd.TabIndex = 43;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(421, 10);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(92, 33);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCloseDiscountSharingType
            // 
            this.btnCloseDiscountSharingType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseDiscountSharingType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseDiscountSharingType.Location = new System.Drawing.Point(499, 220);
            this.btnCloseDiscountSharingType.Name = "btnCloseDiscountSharingType";
            this.btnCloseDiscountSharingType.Size = new System.Drawing.Size(92, 33);
            this.btnCloseDiscountSharingType.TabIndex = 5;
            this.btnCloseDiscountSharingType.Text = "Close";
            this.btnCloseDiscountSharingType.UseVisualStyleBackColor = true;
            this.btnCloseDiscountSharingType.Click += new System.EventHandler(this.btnCloseDiscountSharingType_Click);
            // 
            // btnAddDiscountSharingType
            // 
            this.btnAddDiscountSharingType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddDiscountSharingType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddDiscountSharingType.Location = new System.Drawing.Point(499, 51);
            this.btnAddDiscountSharingType.Name = "btnAddDiscountSharingType";
            this.btnAddDiscountSharingType.Size = new System.Drawing.Size(92, 33);
            this.btnAddDiscountSharingType.TabIndex = 4;
            this.btnAddDiscountSharingType.Text = "&Add";
            this.btnAddDiscountSharingType.UseVisualStyleBackColor = true;
            this.btnAddDiscountSharingType.Click += new System.EventHandler(this.btnAddDiscountSharingType_Click);
            // 
            // txtDiscountContributorName
            // 
            this.txtDiscountContributorName.Location = new System.Drawing.Point(173, 16);
            this.txtDiscountContributorName.Name = "txtDiscountContributorName";
            this.txtDiscountContributorName.Size = new System.Drawing.Size(242, 21);
            this.txtDiscountContributorName.TabIndex = 1;
            // 
            // lblDistSet
            // 
            this.lblDistSet.AutoSize = true;
            this.lblDistSet.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDistSet.Location = new System.Drawing.Point(12, 19);
            this.lblDistSet.Name = "lblDistSet";
            this.lblDistSet.Size = new System.Drawing.Size(155, 15);
            this.lblDistSet.TabIndex = 0;
            this.lblDistSet.Text = "Discount Contributor Name";
            // 
            // frmConsumerPromotionDiscountContributors
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(603, 268);
            this.Controls.Add(this.txtDiscountContributorName);
            this.Controls.Add(this.lblDistSet);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnCloseDiscountSharingType);
            this.Controls.Add(this.btnAddDiscountSharingType);
            this.Controls.Add(this.lvwDiscountSharingType);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdd);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConsumerPromotionDiscountContributors";
            this.Text = "Consumer Promotion Discount Contributors";
            this.Load += new System.EventHandler(this.frmConsumerPromotionDiscountContributors_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwDiscountSharingType;
        private System.Windows.Forms.ColumnHeader colDiscountSharingType;
        private System.Windows.Forms.ColumnHeader colCreateUser;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCloseDiscountSharingType;
        private System.Windows.Forms.Button btnAddDiscountSharingType;
        private System.Windows.Forms.TextBox txtDiscountContributorName;
        private System.Windows.Forms.Label lblDistSet;
        private System.Windows.Forms.ColumnHeader colCreateDate;
    }
}
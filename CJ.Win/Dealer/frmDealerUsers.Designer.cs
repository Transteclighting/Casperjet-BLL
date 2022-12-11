namespace CJ.Win.Dealer
{
    partial class frmDealerUsers
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
            this.lvwDealerUsers = new System.Windows.Forms.ListView();
            this.colUserID = new System.Windows.Forms.ColumnHeader();
            this.colUserName = new System.Windows.Forms.ColumnHeader();
            this.colCreatedBy = new System.Windows.Forms.ColumnHeader();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClos = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvwDealerUsers
            // 
            this.lvwDealerUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwDealerUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colUserID,
            this.colUserName,
            this.colCreatedBy});
            this.lvwDealerUsers.FullRowSelect = true;
            this.lvwDealerUsers.GridLines = true;
            this.lvwDealerUsers.Location = new System.Drawing.Point(12, 12);
            this.lvwDealerUsers.MultiSelect = false;
            this.lvwDealerUsers.Name = "lvwDealerUsers";
            this.lvwDealerUsers.Size = new System.Drawing.Size(716, 379);
            this.lvwDealerUsers.TabIndex = 1;
            this.lvwDealerUsers.UseCompatibleStateImageBehavior = false;
            this.lvwDealerUsers.View = System.Windows.Forms.View.Details;
            // 
            // colUserID
            // 
            this.colUserID.Text = "User ID";
            this.colUserID.Width = 96;
            // 
            // colUserName
            // 
            this.colUserName.Text = "User Name";
            this.colUserName.Width = 339;
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.Text = "Created By";
            this.colCreatedBy.Width = 273;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(730, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(94, 26);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(730, 40);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(94, 26);
            this.btnEdit.TabIndex = 3;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(730, 662);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnClos
            // 
            this.btnClos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClos.Location = new System.Drawing.Point(730, 365);
            this.btnClos.Name = "btnClos";
            this.btnClos.Size = new System.Drawing.Size(94, 26);
            this.btnClos.TabIndex = 4;
            this.btnClos.Text = "CLose";
            this.btnClos.UseVisualStyleBackColor = true;
            this.btnClos.Click += new System.EventHandler(this.btnClos_Click_1);
            // 
            // frmDealerUsers
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 412);
            this.Controls.Add(this.btnClos);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lvwDealerUsers);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDealerUsers";
            this.Text = "Dealer Users";
            this.Load += new System.EventHandler(this.frmDealerUsers_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwDealerUsers;
        private System.Windows.Forms.ColumnHeader colUserID;
        private System.Windows.Forms.ColumnHeader colUserName;
        private System.Windows.Forms.ColumnHeader colCreatedBy;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClos;
    }
}
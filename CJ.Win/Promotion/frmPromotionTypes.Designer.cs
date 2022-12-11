namespace CJ.Win.Promotion
{
    partial class frmPromotionTypes
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
            this.btAdd = new System.Windows.Forms.Button();
            this.btEdit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lvwSPType = new System.Windows.Forms.ListView();
            this.colSPTypeID = new System.Windows.Forms.ColumnHeader();
            this.colSPTypeName = new System.Windows.Forms.ColumnHeader();
            this.colIsActive = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // btAdd
            // 
            this.btAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAdd.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAdd.Location = new System.Drawing.Point(380, 12);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(86, 27);
            this.btAdd.TabIndex = 192;
            this.btAdd.Text = "Add";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btEdit
            // 
            this.btEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btEdit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEdit.Location = new System.Drawing.Point(380, 45);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(86, 27);
            this.btEdit.TabIndex = 193;
            this.btEdit.Text = "Edit";
            this.btEdit.UseVisualStyleBackColor = true;
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(380, 271);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 27);
            this.btnClose.TabIndex = 191;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lvwSPType
            // 
            this.lvwSPType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwSPType.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colSPTypeID,
            this.colSPTypeName,
            this.colIsActive});
            this.lvwSPType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwSPType.FullRowSelect = true;
            this.lvwSPType.GridLines = true;
            this.lvwSPType.HideSelection = false;
            this.lvwSPType.Location = new System.Drawing.Point(12, 12);
            this.lvwSPType.MultiSelect = false;
            this.lvwSPType.Name = "lvwSPType";
            this.lvwSPType.Size = new System.Drawing.Size(362, 286);
            this.lvwSPType.TabIndex = 190;
            this.lvwSPType.UseCompatibleStateImageBehavior = false;
            this.lvwSPType.View = System.Windows.Forms.View.Details;
            this.lvwSPType.DoubleClick += new System.EventHandler(this.double_Click);
            // 
            // colSPTypeID
            // 
            this.colSPTypeID.Text = "SP Type ID";
            this.colSPTypeID.Width = 80;
            // 
            // colSPTypeName
            // 
            this.colSPTypeName.Text = "SP Type Name";
            this.colSPTypeName.Width = 180;
            // 
            // colIsActive
            // 
            this.colIsActive.Text = "Is Active";
            this.colIsActive.Width = 75;
            // 
            // frmPromotionTypes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 310);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.btEdit);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lvwSPType);
            this.Name = "frmPromotionTypes";
            this.Text = "frmPromotionTypes";
            this.Load += new System.EventHandler(this.frmPromotionTypes_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btEdit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListView lvwSPType;
        private System.Windows.Forms.ColumnHeader colSPTypeID;
        private System.Windows.Forms.ColumnHeader colSPTypeName;
        private System.Windows.Forms.ColumnHeader colIsActive;
    }
}
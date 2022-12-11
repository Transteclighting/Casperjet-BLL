namespace CJ.Win.CLP
{
    partial class frmCLPEligibilities
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
            this.btDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lvwEligibilityList = new System.Windows.Forms.ListView();
            this.colEffectDate = new System.Windows.Forms.ColumnHeader();
            this.colAmont = new System.Windows.Forms.ColumnHeader();
            this.colCreatedDate = new System.Windows.Forms.ColumnHeader();
            this.btClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDelete.Location = new System.Drawing.Point(333, 38);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(109, 27);
            this.btDelete.TabIndex = 94;
            this.btDelete.Tag = "M1.15";
            this.btDelete.Text = "Delete";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(333, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(109, 27);
            this.btnAdd.TabIndex = 91;
            this.btnAdd.Text = "Add ";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lvwEligibilityList
            // 
            this.lvwEligibilityList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwEligibilityList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colEffectDate,
            this.colAmont,
            this.colCreatedDate});
            this.lvwEligibilityList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwEligibilityList.FullRowSelect = true;
            this.lvwEligibilityList.GridLines = true;
            this.lvwEligibilityList.HideSelection = false;
            this.lvwEligibilityList.Location = new System.Drawing.Point(3, 4);
            this.lvwEligibilityList.MultiSelect = false;
            this.lvwEligibilityList.Name = "lvwEligibilityList";
            this.lvwEligibilityList.Size = new System.Drawing.Size(324, 449);
            this.lvwEligibilityList.TabIndex = 93;
            this.lvwEligibilityList.UseCompatibleStateImageBehavior = false;
            this.lvwEligibilityList.View = System.Windows.Forms.View.Details;
            // 
            // colEffectDate
            // 
            this.colEffectDate.Text = "Effect Date";
            this.colEffectDate.Width = 100;
            // 
            // colAmont
            // 
            this.colAmont.Text = "Eligibility Amount";
            this.colAmont.Width = 120;
            // 
            // colCreatedDate
            // 
            this.colCreatedDate.Text = "Created Date";
            this.colCreatedDate.Width = 100;
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.Location = new System.Drawing.Point(333, 426);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(109, 27);
            this.btClose.TabIndex = 95;
            this.btClose.Tag = "M1.15";
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // frmCLPEligibilities
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 456);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lvwEligibilityList);
            this.Name = "frmCLPEligibilities";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmCLPEligibilities_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView lvwEligibilityList;
        private System.Windows.Forms.ColumnHeader colEffectDate;
        private System.Windows.Forms.ColumnHeader colAmont;
        private System.Windows.Forms.ColumnHeader colCreatedDate;
        private System.Windows.Forms.Button btClose;
    }
}
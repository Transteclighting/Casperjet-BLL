namespace CJ.Win.CLP
{
    partial class frmCLPPointList
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
            this.lvwPointList = new System.Windows.Forms.ListView();
            this.colEffectDate = new System.Windows.Forms.ColumnHeader();
            this.colDes = new System.Windows.Forms.ColumnHeader();
            this.colCreatedDate = new System.Windows.Forms.ColumnHeader();
            this.btDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvwPointList
            // 
            this.lvwPointList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwPointList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colEffectDate,
            this.colDes,
            this.colCreatedDate});
            this.lvwPointList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwPointList.FullRowSelect = true;
            this.lvwPointList.GridLines = true;
            this.lvwPointList.HideSelection = false;
            this.lvwPointList.Location = new System.Drawing.Point(4, 3);
            this.lvwPointList.MultiSelect = false;
            this.lvwPointList.Name = "lvwPointList";
            this.lvwPointList.Size = new System.Drawing.Size(506, 485);
            this.lvwPointList.TabIndex = 97;
            this.lvwPointList.UseCompatibleStateImageBehavior = false;
            this.lvwPointList.View = System.Windows.Forms.View.Details;
            // 
            // colEffectDate
            // 
            this.colEffectDate.Text = "Effect Date";
            this.colEffectDate.Width = 100;
            // 
            // colDes
            // 
            this.colDes.Text = "Description";
            this.colDes.Width = 300;
            // 
            // colCreatedDate
            // 
            this.colCreatedDate.Text = "Created Date";
            this.colCreatedDate.Width = 100;
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDelete.Location = new System.Drawing.Point(516, 36);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(109, 27);
            this.btDelete.TabIndex = 101;
            this.btDelete.Tag = "M1.15";
            this.btDelete.Text = "Delete";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(516, 3);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(109, 27);
            this.btnAdd.TabIndex = 99;
            this.btnAdd.Text = "Add ";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btClose
            // 
            this.btClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btClose.Location = new System.Drawing.Point(515, 461);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(109, 27);
            this.btClose.TabIndex = 102;
            this.btClose.Tag = "M1.15";
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // frmCLPPointList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 491);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lvwPointList);
            this.Name = "frmCLPPointList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmCLPPointList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwPointList;
        private System.Windows.Forms.ColumnHeader colEffectDate;
        private System.Windows.Forms.ColumnHeader colDes;
        private System.Windows.Forms.ColumnHeader colCreatedDate;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btClose;
    }
}
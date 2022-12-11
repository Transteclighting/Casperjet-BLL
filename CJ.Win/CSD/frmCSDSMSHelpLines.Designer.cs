namespace CJ.Win.CSD
{
    partial class frmCSDSMSHelpLines
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
            this.lvwCSDSMSHelpLines = new System.Windows.Forms.ListView();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colHelpline = new System.Windows.Forms.ColumnHeader();
            this.colServiceTime = new System.Windows.Forms.ColumnHeader();
            this.btnCSDSMSHelpLineUpdate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvwCSDSMSHelpLines
            // 
            this.lvwCSDSMSHelpLines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwCSDSMSHelpLines.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colHelpline,
            this.colServiceTime});
            this.lvwCSDSMSHelpLines.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwCSDSMSHelpLines.FullRowSelect = true;
            this.lvwCSDSMSHelpLines.GridLines = true;
            this.lvwCSDSMSHelpLines.HideSelection = false;
            this.lvwCSDSMSHelpLines.Location = new System.Drawing.Point(12, 12);
            this.lvwCSDSMSHelpLines.MultiSelect = false;
            this.lvwCSDSMSHelpLines.Name = "lvwCSDSMSHelpLines";
            this.lvwCSDSMSHelpLines.Size = new System.Drawing.Size(543, 297);
            this.lvwCSDSMSHelpLines.TabIndex = 1;
            this.lvwCSDSMSHelpLines.UseCompatibleStateImageBehavior = false;
            this.lvwCSDSMSHelpLines.View = System.Windows.Forms.View.Details;
            this.lvwCSDSMSHelpLines.DoubleClick += new System.EventHandler(this.lvwCSDSMSHelpLines_DoubleClick);
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 292;
            // 
            // colHelpline
            // 
            this.colHelpline.Text = "Helpline";
            this.colHelpline.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colHelpline.Width = 95;
            // 
            // colServiceTime
            // 
            this.colServiceTime.Text = "Service Time";
            this.colServiceTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colServiceTime.Width = 126;
            // 
            // btnCSDSMSHelpLineUpdate
            // 
            this.btnCSDSMSHelpLineUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCSDSMSHelpLineUpdate.Location = new System.Drawing.Point(563, 11);
            this.btnCSDSMSHelpLineUpdate.Name = "btnCSDSMSHelpLineUpdate";
            this.btnCSDSMSHelpLineUpdate.Size = new System.Drawing.Size(87, 26);
            this.btnCSDSMSHelpLineUpdate.TabIndex = 2;
            this.btnCSDSMSHelpLineUpdate.Text = "Update";
            this.btnCSDSMSHelpLineUpdate.UseVisualStyleBackColor = true;
            this.btnCSDSMSHelpLineUpdate.Click += new System.EventHandler(this.btnCSDSMSHelpLineUpdate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(563, 283);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 26);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmCSDSMSHelpLines
            // 
            this.ClientSize = new System.Drawing.Size(660, 321);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnCSDSMSHelpLineUpdate);
            this.Controls.Add(this.lvwCSDSMSHelpLines);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //this.Name = "frmCSDSMSHelpLines";
            this.Load += new System.EventHandler(this.frmCSDSMSHelpLines_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwDepartments;
        private System.Windows.Forms.ColumnHeader Name;
        private System.Windows.Forms.ColumnHeader Helpline;
        private System.Windows.Forms.ColumnHeader ServiceTime;
        private System.Windows.Forms.Button csdHelpLineUpdateButton;

    }
}
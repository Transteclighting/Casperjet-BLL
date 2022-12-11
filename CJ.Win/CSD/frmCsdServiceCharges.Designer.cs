namespace CJ.Win.CSD
{
    partial class frmCsdServiceCharges
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
            this.lvwCSDServiceCharges = new System.Windows.Forms.ListView();
            this.colProductCode = new System.Windows.Forms.ColumnHeader();
            this.colProductName = new System.Windows.Forms.ColumnHeader();
            this.colServiceCharge = new System.Windows.Forms.ColumnHeader();
            this.colInspectionChatrge = new System.Windows.Forms.ColumnHeader();
            this.colInstallationCharge = new System.Windows.Forms.ColumnHeader();
            this.colReInstallationCharge = new System.Windows.Forms.ColumnHeader();
            this.colDismantlingCharge = new System.Windows.Forms.ColumnHeader();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctlProducts1 = new CJ.Win.Control.ctlProducts();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvwCSDServiceCharges
            // 
            this.lvwCSDServiceCharges.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwCSDServiceCharges.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colProductCode,
            this.colProductName,
            this.colServiceCharge,
            this.colInspectionChatrge,
            this.colInstallationCharge,
            this.colReInstallationCharge,
            this.colDismantlingCharge});
            this.lvwCSDServiceCharges.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwCSDServiceCharges.FullRowSelect = true;
            this.lvwCSDServiceCharges.GridLines = true;
            this.lvwCSDServiceCharges.HideSelection = false;
            this.lvwCSDServiceCharges.Location = new System.Drawing.Point(12, 54);
            this.lvwCSDServiceCharges.MultiSelect = false;
            this.lvwCSDServiceCharges.Name = "lvwCSDServiceCharges";
            this.lvwCSDServiceCharges.Size = new System.Drawing.Size(637, 325);
            this.lvwCSDServiceCharges.TabIndex = 3;
            this.lvwCSDServiceCharges.UseCompatibleStateImageBehavior = false;
            this.lvwCSDServiceCharges.View = System.Windows.Forms.View.Details;
            // 
            // colProductCode
            // 
            this.colProductCode.Text = "Product Code";
            this.colProductCode.Width = 122;
            // 
            // colProductName
            // 
            this.colProductName.Text = "Product Name";
            this.colProductName.Width = 200;
            // 
            // colServiceCharge
            // 
            this.colServiceCharge.Text = "Service Charge";
            this.colServiceCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colServiceCharge.Width = 200;
            // 
            // colInspectionChatrge
            // 
            this.colInspectionChatrge.Text = "Inspection Chatrge";
            this.colInspectionChatrge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colInspectionChatrge.Width = 100;
            // 
            // colInstallationCharge
            // 
            this.colInstallationCharge.Text = "Installation Charge";
            this.colInstallationCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colInstallationCharge.Width = 100;
            // 
            // colReInstallationCharge
            // 
            this.colReInstallationCharge.Text = "ReInstallation Charge";
            this.colReInstallationCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colReInstallationCharge.Width = 100;
            // 
            // colDismantlingCharge
            // 
            this.colDismantlingCharge.Text = "Dismantling Charge";
            this.colDismantlingCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colDismantlingCharge.Width = 100;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(654, 83);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(101, 28);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(654, 54);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(101, 28);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "&Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(654, 351);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(101, 28);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctlProducts1
            // 
            this.ctlProducts1.Location = new System.Drawing.Point(62, 12);
            this.ctlProducts1.Name = "ctlProducts1";
            this.ctlProducts1.Size = new System.Drawing.Size(451, 25);
            this.ctlProducts1.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Product";
            // 
            // btnGo
            // 
            this.btnGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.Location = new System.Drawing.Point(519, 9);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(79, 28);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Get Data";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // frmCsdServiceCharges
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 391);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ctlProducts1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lvwCSDServiceCharges);
            this.Name = "frmCsdServiceCharges";
            this.Text = "Service Charges Mapping";
            this.Load += new System.EventHandler(this.frmCsdServiceCharges_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwCSDServiceCharges;
        private System.Windows.Forms.ColumnHeader colProductCode;
        private System.Windows.Forms.ColumnHeader colProductName;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColumnHeader colServiceCharge;
        private System.Windows.Forms.ColumnHeader colInspectionChatrge;
        private System.Windows.Forms.ColumnHeader colInstallationCharge;
        private System.Windows.Forms.ColumnHeader colReInstallationCharge;
        private System.Windows.Forms.ColumnHeader colDismantlingCharge;
        private CJ.Win.Control.ctlProducts ctlProducts1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGo;
    }
}
namespace CJ.Win.HR
{
    partial class frmHRProductionMachineMappings
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.lvwProductionMachine = new System.Windows.Forms.ListView();
            this.colMachineCode = new System.Windows.Forms.ColumnHeader();
            this.colMachineName = new System.Windows.Forms.ColumnHeader();
            this.colMachineType = new System.Windows.Forms.ColumnHeader();
            this.colShiftName = new System.Windows.Forms.ColumnHeader();
            this.colCreatedBy = new System.Windows.Forms.ColumnHeader();
            this.btnEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(688, 27);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(81, 26);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lvwProductionMachine
            // 
            this.lvwProductionMachine.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwProductionMachine.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colMachineCode,
            this.colMachineName,
            this.colMachineType,
            this.colShiftName,
            this.colCreatedBy});
            this.lvwProductionMachine.FullRowSelect = true;
            this.lvwProductionMachine.GridLines = true;
            this.lvwProductionMachine.Location = new System.Drawing.Point(12, 27);
            this.lvwProductionMachine.Name = "lvwProductionMachine";
            this.lvwProductionMachine.Size = new System.Drawing.Size(674, 299);
            this.lvwProductionMachine.TabIndex = 4;
            this.lvwProductionMachine.UseCompatibleStateImageBehavior = false;
            this.lvwProductionMachine.View = System.Windows.Forms.View.Details;
            // 
            // colMachineCode
            // 
            this.colMachineCode.Text = "Machine Code";
            this.colMachineCode.Width = 114;
            // 
            // colMachineName
            // 
            this.colMachineName.Text = "Machine Name";
            this.colMachineName.Width = 110;
            // 
            // colMachineType
            // 
            this.colMachineType.Text = "Machine Type";
            this.colMachineType.Width = 119;
            // 
            // colShiftName
            // 
            this.colShiftName.Text = "Shift Name";
            this.colShiftName.Width = 92;
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.Text = "CreatedBy";
            this.colCreatedBy.Width = 206;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(688, 55);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(81, 26);
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // frmHRProductionMachineMappings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 338);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.lvwProductionMachine);
            this.Controls.Add(this.btnAdd);
            this.Name = "frmHRProductionMachineMappings";
            this.Text = "Production Machine Mappings";
            this.Load += new System.EventHandler(this.frmHRProductionMachineMappings_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView lvwProductionMachine;
        private System.Windows.Forms.ColumnHeader colMachineName;
        private System.Windows.Forms.ColumnHeader colMachineType;
        private System.Windows.Forms.ColumnHeader colMachineCode;
        private System.Windows.Forms.ColumnHeader colShiftName;
        private System.Windows.Forms.ColumnHeader colCreatedBy;
        private System.Windows.Forms.Button btnEdit;
    }
}
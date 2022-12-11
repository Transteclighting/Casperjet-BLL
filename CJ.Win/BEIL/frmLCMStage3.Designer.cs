namespace CJ.Win.BEIL
{
    partial class frmLCMStage3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLCMStage3));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvLCMComponent = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtChassisSerial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtManualSerial = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLCMComponent)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(777, 410);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(858, 410);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvLCMComponent
            // 
            this.dgvLCMComponent.AllowUserToAddRows = false;
            this.dgvLCMComponent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLCMComponent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLCMComponent.Location = new System.Drawing.Point(12, 32);
            this.dgvLCMComponent.Name = "dgvLCMComponent";
            this.dgvLCMComponent.Size = new System.Drawing.Size(921, 368);
            this.dgvLCMComponent.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chassis Serial";
            // 
            // txtChassisSerial
            // 
            this.txtChassisSerial.Location = new System.Drawing.Point(87, 6);
            this.txtChassisSerial.Name = "txtChassisSerial";
            this.txtChassisSerial.Size = new System.Drawing.Size(381, 20);
            this.txtChassisSerial.TabIndex = 1;
            this.txtChassisSerial.TextChanged += new System.EventHandler(this.txtChassisSerial_TextChanged);
            this.txtChassisSerial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChassisSerial_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(477, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Manual Serial";
            // 
            // txtManualSerial
            // 
            this.txtManualSerial.Location = new System.Drawing.Point(552, 6);
            this.txtManualSerial.Name = "txtManualSerial";
            this.txtManualSerial.Size = new System.Drawing.Size(381, 20);
            this.txtManualSerial.TabIndex = 3;
            this.txtManualSerial.TextChanged += new System.EventHandler(this.txtManualSerial_TextChanged);
            this.txtManualSerial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtManualSerial_KeyDown);
            // 
            // frmLCMStage3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(940, 441);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtManualSerial);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvLCMComponent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtChassisSerial);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLCMStage3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLCMStage3";
            this.Load += new System.EventHandler(this.frmLCMStage3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLCMComponent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvLCMComponent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtChassisSerial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtManualSerial;
    }
}
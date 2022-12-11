namespace CJ.Win.BEIL
{
    partial class frmLCMStage2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLCMStage2));
            this.label1 = new System.Windows.Forms.Label();
            this.txtChassisSerial = new System.Windows.Forms.TextBox();
            this.dgvLCMComponent = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOpenCell = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTcon = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtManualSerial = new System.Windows.Forms.TextBox();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtComponentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCreateDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtSerial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtComponentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLCMComponent)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "ChassisSerial";
            // 
            // txtChassisSerial
            // 
            this.txtChassisSerial.Location = new System.Drawing.Point(92, 7);
            this.txtChassisSerial.Name = "txtChassisSerial";
            this.txtChassisSerial.Size = new System.Drawing.Size(381, 20);
            this.txtChassisSerial.TabIndex = 0;
            this.txtChassisSerial.TextChanged += new System.EventHandler(this.txtChassisSerial_TextChanged);
            this.txtChassisSerial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChassisSerial_KeyDown);
            // 
            // dgvLCMComponent
            // 
            this.dgvLCMComponent.AllowUserToAddRows = false;
            this.dgvLCMComponent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLCMComponent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtComponentName,
            this.txtCreateDate,
            this.txtSerial,
            this.txtComponentID});
            this.dgvLCMComponent.Location = new System.Drawing.Point(11, 86);
            this.dgvLCMComponent.Name = "dgvLCMComponent";
            this.dgvLCMComponent.Size = new System.Drawing.Size(543, 224);
            this.dgvLCMComponent.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Opencell Serial";
            // 
            // txtOpenCell
            // 
            this.txtOpenCell.Location = new System.Drawing.Point(92, 33);
            this.txtOpenCell.Name = "txtOpenCell";
            this.txtOpenCell.Size = new System.Drawing.Size(381, 20);
            this.txtOpenCell.TabIndex = 1;
            this.txtOpenCell.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtOpenCell_KeyDown);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(479, 57);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(479, 316);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "T-Con";
            // 
            // txtTcon
            // 
            this.txtTcon.Location = new System.Drawing.Point(92, 59);
            this.txtTcon.Name = "txtTcon";
            this.txtTcon.Size = new System.Drawing.Size(381, 20);
            this.txtTcon.TabIndex = 2;
            this.txtTcon.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTcon_KeyDown);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Manual Serial";
            this.label5.Visible = false;
            // 
            // txtManualSerial
            // 
            this.txtManualSerial.Location = new System.Drawing.Point(92, 76);
            this.txtManualSerial.Name = "txtManualSerial";
            this.txtManualSerial.Size = new System.Drawing.Size(381, 20);
            this.txtManualSerial.TabIndex = 8;
            this.txtManualSerial.Visible = false;
            this.txtManualSerial.TextChanged += new System.EventHandler(this.txtManualSerial_TextChanged);
            this.txtManualSerial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtManualSerial_KeyDown);
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn1.HeaderText = "Component Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 180;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Create Date";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 120;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn3.HeaderText = "Serial";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 190;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "ComponentID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // txtComponentName
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtComponentName.DefaultCellStyle = dataGridViewCellStyle1;
            this.txtComponentName.HeaderText = "Component Name";
            this.txtComponentName.Name = "txtComponentName";
            this.txtComponentName.Width = 180;
            // 
            // txtCreateDate
            // 
            this.txtCreateDate.HeaderText = "Create Date";
            this.txtCreateDate.Name = "txtCreateDate";
            this.txtCreateDate.Width = 120;
            // 
            // txtSerial
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtSerial.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtSerial.HeaderText = "Serial";
            this.txtSerial.Name = "txtSerial";
            this.txtSerial.Width = 190;
            // 
            // txtComponentID
            // 
            this.txtComponentID.HeaderText = "ComponentID";
            this.txtComponentID.Name = "txtComponentID";
            this.txtComponentID.Visible = false;
            // 
            // frmLCMStage2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 348);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtManualSerial);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTcon);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOpenCell);
            this.Controls.Add(this.dgvLCMComponent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtChassisSerial);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmLCMStage2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLCMComponentLEDBar";
            this.Load += new System.EventHandler(this.frmLCMComponentLEDBar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLCMComponent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtChassisSerial;
        private System.Windows.Forms.DataGridView dgvLCMComponent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOpenCell;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtComponentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCreateDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtSerial;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtComponentID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTcon;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtManualSerial;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
    }
}
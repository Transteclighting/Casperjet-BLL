namespace CJ.Win.BEIL
{
    partial class frmLCMStage1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLCMStage1));
            this.btnClose = new System.Windows.Forms.Button();
            this.txtLEDBarSerial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblOpenCell = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.txtChassisSerial = new System.Windows.Forms.TextBox();
            this.cmbAG = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtManualSerial = new System.Windows.Forms.TextBox();
            this.lblTCon = new System.Windows.Forms.Label();
            this.txtLEDBarSerial2 = new System.Windows.Forms.TextBox();
            this.lblLED03 = new System.Windows.Forms.Label();
            this.txtLEDBarSerial3 = new System.Windows.Forms.TextBox();
            this.lblBrand = new System.Windows.Forms.Label();
            this.cmbBrand = new System.Windows.Forms.ComboBox();
            this.btnPicker = new System.Windows.Forms.Button();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(427, 176);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtLEDBarSerial
            // 
            this.txtLEDBarSerial.Location = new System.Drawing.Point(94, 98);
            this.txtLEDBarSerial.Name = "txtLEDBarSerial";
            this.txtLEDBarSerial.Size = new System.Drawing.Size(408, 20);
            this.txtLEDBarSerial.TabIndex = 7;
            this.txtLEDBarSerial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLEDBarSerial_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "ChassisSerial";
            // 
            // lblOpenCell
            // 
            this.lblOpenCell.AutoSize = true;
            this.lblOpenCell.Location = new System.Drawing.Point(5, 101);
            this.lblOpenCell.Name = "lblOpenCell";
            this.lblOpenCell.Size = new System.Drawing.Size(78, 13);
            this.lblOpenCell.TabIndex = 6;
            this.lblOpenCell.Text = "LED Bar SL 01";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(346, 176);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Remarks";
            this.label3.Visible = false;
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(87, 217);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(499, 62);
            this.txtRemarks.TabIndex = 13;
            this.txtRemarks.Visible = false;
            this.txtRemarks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRemarks_KeyDown);
            // 
            // txtChassisSerial
            // 
            this.txtChassisSerial.Location = new System.Drawing.Point(94, 72);
            this.txtChassisSerial.Name = "txtChassisSerial";
            this.txtChassisSerial.Size = new System.Drawing.Size(408, 20);
            this.txtChassisSerial.TabIndex = 5;
            this.txtChassisSerial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtChassisSerial_KeyDown);
            // 
            // cmbAG
            // 
            this.cmbAG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAG.FormattingEnabled = true;
            this.cmbAG.Location = new System.Drawing.Point(94, 12);
            this.cmbAG.Name = "cmbAG";
            this.cmbAG.Size = new System.Drawing.Size(181, 21);
            this.cmbAG.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "AG Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Manual Serial";
            this.label5.Visible = false;
            // 
            // txtManualSerial
            // 
            this.txtManualSerial.Location = new System.Drawing.Point(94, 73);
            this.txtManualSerial.Name = "txtManualSerial";
            this.txtManualSerial.Size = new System.Drawing.Size(408, 20);
            this.txtManualSerial.TabIndex = 3;
            this.txtManualSerial.Visible = false;
            this.txtManualSerial.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtManualSerial_KeyDown);
            // 
            // lblTCon
            // 
            this.lblTCon.AutoSize = true;
            this.lblTCon.Location = new System.Drawing.Point(5, 127);
            this.lblTCon.Name = "lblTCon";
            this.lblTCon.Size = new System.Drawing.Size(78, 13);
            this.lblTCon.TabIndex = 8;
            this.lblTCon.Text = "LED Bar SL 02";
            // 
            // txtLEDBarSerial2
            // 
            this.txtLEDBarSerial2.Location = new System.Drawing.Point(94, 124);
            this.txtLEDBarSerial2.Name = "txtLEDBarSerial2";
            this.txtLEDBarSerial2.Size = new System.Drawing.Size(408, 20);
            this.txtLEDBarSerial2.TabIndex = 9;
            this.txtLEDBarSerial2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLEDBarSerial2_KeyDown);
            // 
            // lblLED03
            // 
            this.lblLED03.AutoSize = true;
            this.lblLED03.Location = new System.Drawing.Point(5, 153);
            this.lblLED03.Name = "lblLED03";
            this.lblLED03.Size = new System.Drawing.Size(78, 13);
            this.lblLED03.TabIndex = 10;
            this.lblLED03.Text = "LED Bar SL 03";
            // 
            // txtLEDBarSerial3
            // 
            this.txtLEDBarSerial3.Location = new System.Drawing.Point(94, 150);
            this.txtLEDBarSerial3.Name = "txtLEDBarSerial3";
            this.txtLEDBarSerial3.Size = new System.Drawing.Size(408, 20);
            this.txtLEDBarSerial3.TabIndex = 11;
            this.txtLEDBarSerial3.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.txtLEDBarSerial3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLEDBarSerial3_KeyDown);
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Location = new System.Drawing.Point(349, 15);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(35, 13);
            this.lblBrand.TabIndex = 16;
            this.lblBrand.Text = "Brand";
            // 
            // cmbBrand
            // 
            this.cmbBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Location = new System.Drawing.Point(390, 12);
            this.cmbBrand.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(111, 21);
            this.cmbBrand.TabIndex = 17;
            this.cmbBrand.SelectedIndexChanged += new System.EventHandler(this.cmbBrand_SelectedIndexChanged);
            // 
            // btnPicker
            // 
            this.btnPicker.Location = new System.Drawing.Point(198, 44);
            this.btnPicker.Name = "btnPicker";
            this.btnPicker.Size = new System.Drawing.Size(31, 22);
            this.btnPicker.TabIndex = 241;
            this.btnPicker.Text = "?";
            this.btnPicker.UseVisualStyleBackColor = true;
            this.btnPicker.Click += new System.EventHandler(this.btnPicker_Click);
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.SystemColors.Control;
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(233, 44);
            this.txtName.Multiline = true;
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(269, 20);
            this.txtName.TabIndex = 242;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(94, 44);
            this.txtCode.Multiline = true;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(100, 20);
            this.txtCode.TabIndex = 240;
            this.txtCode.TextChanged += new System.EventHandler(this.txtCode_TextChanged);
            this.txtCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCode_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 15);
            this.label2.TabIndex = 239;
            this.label2.Text = "Product Name:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmLCMStage1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(689, 240);
            this.Controls.Add(this.btnPicker);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.cmbBrand);
            this.Controls.Add(this.lblLED03);
            this.Controls.Add(this.txtLEDBarSerial3);
            this.Controls.Add(this.lblTCon);
            this.Controls.Add(this.txtLEDBarSerial2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtManualSerial);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbAG);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblOpenCell);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLEDBarSerial);
            this.Controls.Add(this.txtChassisSerial);
            this.Controls.Add(this.btnClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmLCMStage1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLCMComponent";
            this.Load += new System.EventHandler(this.frmLCMStage1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtLEDBarSerial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblOpenCell;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.TextBox txtChassisSerial;
        private System.Windows.Forms.ComboBox cmbAG;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtManualSerial;
        private System.Windows.Forms.Label lblTCon;
        private System.Windows.Forms.TextBox txtLEDBarSerial2;
        private System.Windows.Forms.Label lblLED03;
        private System.Windows.Forms.TextBox txtLEDBarSerial3;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.ComboBox cmbBrand;
        private System.Windows.Forms.Button btnPicker;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label label2;
    }
}
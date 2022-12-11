namespace CJ.Win.ERP
{
    partial class frmMapERPWareHouse
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMapERPWareHouse));
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbAG = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtChassisSerial = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtWHERPCode = new System.Windows.Forms.TextBox();
            this.txtWHCode = new System.Windows.Forms.TextBox();
            this.txtWHDesc = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(19, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Warehouse ERP Code";
            //this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-8, -276);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 41;
            this.label4.Text = "AG Name";
            // 
            // cmbAG
            // 
            this.cmbAG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAG.FormattingEnabled = true;
            this.cmbAG.Location = new System.Drawing.Point(68, -279);
            this.cmbAG.Name = "cmbAG";
            this.cmbAG.Size = new System.Drawing.Size(244, 23);
            this.cmbAG.TabIndex = 42;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(221, 93);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(78, 30);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-34, -239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 15);
            this.label1.TabIndex = 39;
            this.label1.Text = "Chassis Serial";
            // 
            // txtChassisSerial
            // 
            this.txtChassisSerial.Location = new System.Drawing.Point(68, -243);
            this.txtChassisSerial.Name = "txtChassisSerial";
            this.txtChassisSerial.Size = new System.Drawing.Size(647, 21);
            this.txtChassisSerial.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Warehouse Casper Code";
            //this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // txtWHERPCode
            // 
            this.txtWHERPCode.Location = new System.Drawing.Point(155, 39);
            this.txtWHERPCode.Name = "txtWHERPCode";
            this.txtWHERPCode.Size = new System.Drawing.Size(228, 21);
            this.txtWHERPCode.TabIndex = 3;
            //this.txtWHERPCode.TextChanged += new System.EventHandler(this.txtWHERPCode_TextChanged);
            this.txtWHERPCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWHERPCode_KeyPress);
            // 
            // txtWHCode
            // 
            this.txtWHCode.Location = new System.Drawing.Point(155, 66);
            this.txtWHCode.Name = "txtWHCode";
            this.txtWHCode.Size = new System.Drawing.Size(228, 21);
            this.txtWHCode.TabIndex = 5;
            //this.txtWHCode.TextChanged += new System.EventHandler(this.txtWHCode_TextChanged);
            this.txtWHCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtWHCode_KeyPress);
            // 
            // txtWHDesc
            // 
            this.txtWHDesc.Location = new System.Drawing.Point(155, 12);
            this.txtWHDesc.Name = "txtWHDesc";
            this.txtWHDesc.Size = new System.Drawing.Size(228, 21);
            this.txtWHDesc.TabIndex = 1;
            //this.txtWHDesc.TextChanged += new System.EventHandler(this.txtWHDesc_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label3.Location = new System.Drawing.Point(12, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Warehouse Description";
            //this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // txtClose
            // 
            this.txtClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClose.Location = new System.Drawing.Point(305, 93);
            this.txtClose.Name = "txtClose";
            this.txtClose.Size = new System.Drawing.Size(78, 30);
            this.txtClose.TabIndex = 7;
            this.txtClose.Text = "Close";
            this.txtClose.UseVisualStyleBackColor = true;
            this.txtClose.Click += new System.EventHandler(this.txtClose_Click);
            // 
            // frmMapERPWareHouse
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 132);
            this.Controls.Add(this.txtClose);
            this.Controls.Add(this.txtWHCode);
            this.Controls.Add(this.txtWHERPCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtWHDesc);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbAG);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtChassisSerial);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMapERPWareHouse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Map ERP WareHouse";
            this.Load += new System.EventHandler(this.frmMapERPWareHouse_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbAG;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtChassisSerial;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtWHERPCode;
        private System.Windows.Forms.TextBox txtWHCode;
        private System.Windows.Forms.TextBox txtWHDesc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button txtClose;
    }
}
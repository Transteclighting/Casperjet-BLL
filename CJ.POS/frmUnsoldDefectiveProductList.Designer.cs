namespace CJ.POS
{
    partial class frmUnsoldDefectiveProductList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUnsoldDefectiveProductList));
            this.txtProductSerial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDefectiveNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.cmbstatus = new System.Windows.Forms.ComboBox();
            this.cmbDefectiveType = new System.Windows.Forms.ComboBox();
            this.cmbStockStatus = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkIsCurrentDefective = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // txtProductSerial
            // 
            this.txtProductSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductSerial.Location = new System.Drawing.Point(113, 39);
            this.txtProductSerial.Name = "txtProductSerial";
            this.txtProductSerial.Size = new System.Drawing.Size(280, 21);
            this.txtProductSerial.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Product Serial :  ";
            // 
            // txtDefectiveNo
            // 
            this.txtDefectiveNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDefectiveNo.Location = new System.Drawing.Point(113, 12);
            this.txtDefectiveNo.Name = "txtDefectiveNo";
            this.txtDefectiveNo.Size = new System.Drawing.Size(280, 21);
            this.txtDefectiveNo.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 15);
            this.label5.TabIndex = 8;
            this.label5.Text = "DefectiveNo :  ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Status :  ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Defective Type :  ";
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(292, 182);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(101, 31);
            this.btnClose.TabIndex = 26;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Location = new System.Drawing.Point(185, 182);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(101, 31);
            this.btnPreview.TabIndex = 25;
            this.btnPreview.Text = "Preview ";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // cmbstatus
            // 
            this.cmbstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbstatus.FormattingEnabled = true;
            this.cmbstatus.Location = new System.Drawing.Point(113, 95);
            this.cmbstatus.Name = "cmbstatus";
            this.cmbstatus.Size = new System.Drawing.Size(279, 23);
            this.cmbstatus.TabIndex = 27;
            // 
            // cmbDefectiveType
            // 
            this.cmbDefectiveType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDefectiveType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbDefectiveType.FormattingEnabled = true;
            this.cmbDefectiveType.Location = new System.Drawing.Point(113, 66);
            this.cmbDefectiveType.Name = "cmbDefectiveType";
            this.cmbDefectiveType.Size = new System.Drawing.Size(279, 23);
            this.cmbDefectiveType.TabIndex = 28;
            // 
            // cmbStockStatus
            // 
            this.cmbStockStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStockStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbStockStatus.FormattingEnabled = true;
            this.cmbStockStatus.Location = new System.Drawing.Point(113, 124);
            this.cmbStockStatus.Name = "cmbStockStatus";
            this.cmbStockStatus.Size = new System.Drawing.Size(279, 23);
            this.cmbStockStatus.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 15);
            this.label4.TabIndex = 29;
            this.label4.Text = "Stock Status:";
            // 
            // chkIsCurrentDefective
            // 
            this.chkIsCurrentDefective.AutoSize = true;
            this.chkIsCurrentDefective.Location = new System.Drawing.Point(113, 157);
            this.chkIsCurrentDefective.Name = "chkIsCurrentDefective";
            this.chkIsCurrentDefective.Size = new System.Drawing.Size(131, 19);
            this.chkIsCurrentDefective.TabIndex = 31;
            this.chkIsCurrentDefective.Text = "Is Current Defective";
            this.chkIsCurrentDefective.UseVisualStyleBackColor = true;
            this.chkIsCurrentDefective.CheckedChanged += new System.EventHandler(this.chkIsCurrentDefective_CheckedChanged);
            // 
            // frmUnsoldDefectiveProductList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 222);
            this.Controls.Add(this.chkIsCurrentDefective);
            this.Controls.Add(this.cmbStockStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbDefectiveType);
            this.Controls.Add(this.cmbstatus);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtProductSerial);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDefectiveNo);
            this.Controls.Add(this.label5);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmUnsoldDefectiveProductList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Unsold Defective Product List";
            this.Load += new System.EventHandler(this.frmUnsoldDefectiveProductList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtProductSerial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDefectiveNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.ComboBox cmbstatus;
        private System.Windows.Forms.ComboBox cmbDefectiveType;
        private System.Windows.Forms.ComboBox cmbStockStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkIsCurrentDefective;
    }
}
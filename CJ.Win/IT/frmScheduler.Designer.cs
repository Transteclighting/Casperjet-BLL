namespace CJ.Win.IT
{
    partial class frmScheduler
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
            this.txtIMEI = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAssetVal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtComPer = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEmpPer = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTotalIns = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDeduct = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtstart = new System.Windows.Forms.DateTimePicker();
            this.dtAssign = new System.Windows.Forms.DateTimePicker();
            this.txtdsrcode = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAssetNo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lbldsr = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtIMEI
            // 
            this.txtIMEI.Location = new System.Drawing.Point(143, 83);
            this.txtIMEI.Name = "txtIMEI";
            this.txtIMEI.ReadOnly = true;
            this.txtIMEI.Size = new System.Drawing.Size(253, 20);
            this.txtIMEI.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "IMEI No";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Assign Date";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(122, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Asset Value";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAssetVal
            // 
            this.txtAssetVal.Location = new System.Drawing.Point(143, 138);
            this.txtAssetVal.Name = "txtAssetVal";
            this.txtAssetVal.Size = new System.Drawing.Size(253, 20);
            this.txtAssetVal.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 20);
            this.label6.TabIndex = 11;
            this.label6.Text = "Company Share(tk)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtComPer
            // 
            this.txtComPer.Location = new System.Drawing.Point(143, 166);
            this.txtComPer.Name = "txtComPer";
            this.txtComPer.Size = new System.Drawing.Size(253, 20);
            this.txtComPer.TabIndex = 5;
            this.txtComPer.TextChanged += new System.EventHandler(this.txtComPer_TextChanged);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 194);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "User Share (TK)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtEmpPer
            // 
            this.txtEmpPer.Location = new System.Drawing.Point(143, 194);
            this.txtEmpPer.Name = "txtEmpPer";
            this.txtEmpPer.Size = new System.Drawing.Size(253, 20);
            this.txtEmpPer.TabIndex = 6;
            this.txtEmpPer.TextChanged += new System.EventHandler(this.txtEmpPer_TextChanged);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(15, 221);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(122, 20);
            this.label8.TabIndex = 15;
            this.label8.Text = "Total Installment";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTotalIns
            // 
            this.txtTotalIns.Location = new System.Drawing.Point(143, 221);
            this.txtTotalIns.Name = "txtTotalIns";
            this.txtTotalIns.Size = new System.Drawing.Size(253, 20);
            this.txtTotalIns.TabIndex = 7;
            this.txtTotalIns.TextChanged += new System.EventHandler(this.txtTotalIns_TextChanged);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(15, 249);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 20);
            this.label9.TabIndex = 17;
            this.label9.Text = "Per Installment";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDeduct
            // 
            this.txtDeduct.Location = new System.Drawing.Point(143, 248);
            this.txtDeduct.Name = "txtDeduct";
            this.txtDeduct.Size = new System.Drawing.Size(253, 20);
            this.txtDeduct.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 278);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "Start From";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtstart
            // 
            this.dtstart.CustomFormat = "MMM-yyyy";
            this.dtstart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtstart.Location = new System.Drawing.Point(144, 277);
            this.dtstart.Name = "dtstart";
            this.dtstart.Size = new System.Drawing.Size(252, 20);
            this.dtstart.TabIndex = 9;
            // 
            // dtAssign
            // 
            this.dtAssign.CustomFormat = "dd-MM-yyyy";
            this.dtAssign.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtAssign.Location = new System.Drawing.Point(144, 111);
            this.dtAssign.Name = "dtAssign";
            this.dtAssign.Size = new System.Drawing.Size(252, 20);
            this.dtAssign.TabIndex = 3;
            // 
            // txtdsrcode
            // 
            this.txtdsrcode.Location = new System.Drawing.Point(93, 23);
            this.txtdsrcode.Name = "txtdsrcode";
            this.txtdsrcode.Size = new System.Drawing.Size(73, 20);
            this.txtdsrcode.TabIndex = 1;
            this.txtdsrcode.TextChanged += new System.EventHandler(this.txtdsrcode_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.txtRemarks);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtAssetNo);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.lbldsr);
            this.groupBox1.Controls.Add(this.txtIMEI);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtdsrcode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtAssign);
            this.groupBox1.Controls.Add(this.dtstart);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtAssetVal);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtDeduct);
            this.groupBox1.Controls.Add(this.txtComPer);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtTotalIns);
            this.groupBox1.Controls.Add(this.txtEmpPer);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(421, 435);
            this.groupBox1.TabIndex = 26;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create Schedule";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(296, 387);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 28);
            this.button2.TabIndex = 31;
            this.button2.Text = "Deduct List";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(144, 311);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(252, 57);
            this.txtRemarks.TabIndex = 30;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(15, 311);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(122, 57);
            this.label11.TabIndex = 29;
            this.label11.Text = "Remarks";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtAssetNo
            // 
            this.txtAssetNo.Location = new System.Drawing.Point(143, 52);
            this.txtAssetNo.Name = "txtAssetNo";
            this.txtAssetNo.ReadOnly = true;
            this.txtAssetNo.Size = new System.Drawing.Size(253, 20);
            this.txtAssetNo.TabIndex = 28;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(15, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(122, 20);
            this.label10.TabIndex = 27;
            this.label10.Text = "Asset No";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 20);
            this.label4.TabIndex = 26;
            this.label4.Text = "DSR Code";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(144, 387);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 10;
            this.button1.Text = "Create Shcedule";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbldsr
            // 
            this.lbldsr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbldsr.Font = new System.Drawing.Font("Trebuchet MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldsr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lbldsr.Location = new System.Drawing.Point(172, 23);
            this.lbldsr.Name = "lbldsr";
            this.lbldsr.Size = new System.Drawing.Size(224, 20);
            this.lbldsr.TabIndex = 25;
            this.lbldsr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // frmScheduler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 459);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmScheduler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Deduction Scheduler";
            this.Load += new System.EventHandler(this.frmScheduler_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtIMEI;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtAssetVal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtComPer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEmpPer;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTotalIns;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDeduct;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtstart;
        private System.Windows.Forms.DateTimePicker dtAssign;
        private System.Windows.Forms.TextBox txtdsrcode;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbldsr;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAssetNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button2;
    }
}
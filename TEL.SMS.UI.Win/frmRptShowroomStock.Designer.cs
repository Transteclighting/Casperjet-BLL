namespace TEL.SMS.UI.Win
{
    partial class frmRptShowroomStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRptShowroomStock));
            this.btnPrint = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cboShowroom = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(189, 64);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Showroom";
            // 
            // cboShowroom
            // 
            this.cboShowroom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboShowroom.FormattingEnabled = true;
            this.cboShowroom.Location = new System.Drawing.Point(84, 23);
            this.cboShowroom.Name = "cboShowroom";
            this.cboShowroom.Size = new System.Drawing.Size(180, 21);
            this.cboShowroom.TabIndex = 1;
            this.cboShowroom.SelectedIndexChanged += new System.EventHandler(this.cboShowroom_SelectedIndexChanged);
            // 
            // frmRptShowroomStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 99);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboShowroom);
            this.Controls.Add(this.btnPrint);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRptShowroomStock";
            this.Text = "Showroom Stock Report";
            this.Load += new System.EventHandler(this.frmRptShowroomStock_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboShowroom;
    }
}
namespace CJ.POS.RT
{
    partial class frmSalesTrandReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSalesTrandReport));
            this.btnPreview = new System.Windows.Forms.Button();
            this.dtSalesYear = new System.Windows.Forms.DateTimePicker();
            this.lblYear = new System.Windows.Forms.Label();
            this.dtWeek = new System.Windows.Forms.DateTimePicker();
            this.lblWeek = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPreview
            // 
            this.btnPreview.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnPreview.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnPreview.Location = new System.Drawing.Point(15, 60);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(406, 45);
            this.btnPreview.TabIndex = 0;
            this.btnPreview.Text = "Preview ";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // dtSalesYear
            // 
            this.dtSalesYear.CustomFormat = "yyyy";
            this.dtSalesYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtSalesYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtSalesYear.Location = new System.Drawing.Point(201, 18);
            this.dtSalesYear.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dtSalesYear.Name = "dtSalesYear";
            this.dtSalesYear.ShowUpDown = true;
            this.dtSalesYear.Size = new System.Drawing.Size(87, 21);
            this.dtSalesYear.TabIndex = 21;
            this.dtSalesYear.Value = new System.DateTime(2016, 2, 11, 0, 0, 0, 0);
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYear.Location = new System.Drawing.Point(114, 20);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(66, 15);
            this.lblYear.TabIndex = 20;
            this.lblYear.Text = "Sales Year";
            // 
            // dtWeek
            // 
            this.dtWeek.CustomFormat = "MMM-yyyy";
            this.dtWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtWeek.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtWeek.Location = new System.Drawing.Point(201, 18);
            this.dtWeek.MinDate = new System.DateTime(2015, 1, 1, 0, 0, 0, 0);
            this.dtWeek.Name = "dtWeek";
            this.dtWeek.ShowUpDown = true;
            this.dtWeek.Size = new System.Drawing.Size(132, 21);
            this.dtWeek.TabIndex = 23;
            this.dtWeek.Value = new System.DateTime(2016, 2, 11, 0, 0, 0, 0);
            // 
            // lblWeek
            // 
            this.lblWeek.AutoSize = true;
            this.lblWeek.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeek.Location = new System.Drawing.Point(107, 20);
            this.lblWeek.Name = "lblWeek";
            this.lblWeek.Size = new System.Drawing.Size(70, 15);
            this.lblWeek.TabIndex = 22;
            this.lblWeek.Text = "Month/Year";
            // 
            // frmSalesTrandReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 117);
            this.Controls.Add(this.dtWeek);
            this.Controls.Add(this.lblWeek);
            this.Controls.Add(this.dtSalesYear);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.btnPreview);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmSalesTrandReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sales Trand Report";
            this.Load += new System.EventHandler(this.frmSalesTrandReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.DateTimePicker dtSalesYear;
        private System.Windows.Forms.Label lblYear;
        private System.Windows.Forms.DateTimePicker dtWeek;
        private System.Windows.Forms.Label lblWeek;
    }
}
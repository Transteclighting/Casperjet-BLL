namespace CJ.Control
{
    partial class ctlClaims
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnPicker = new System.Windows.Forms.Button();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lbText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPicker
            // 
            this.btnPicker.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPicker.Location = new System.Drawing.Point(145, 1);
            this.btnPicker.Name = "btnPicker";
            this.btnPicker.Size = new System.Drawing.Size(24, 20);
            this.btnPicker.TabIndex = 18;
            this.btnPicker.Text = "...";
            this.btnPicker.Click += new System.EventHandler(this.btnPicker_Click);
            // 
            // txtCode
            // 
            this.txtCode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCode.Location = new System.Drawing.Point(7, 1);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(134, 20);
            this.txtCode.TabIndex = 17;
            this.txtCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCode.TextChanged += new System.EventHandler(this.txtCode_TextChanged);
            // 
            // lbText
            // 
            this.lbText.AutoSize = true;
            this.lbText.Location = new System.Drawing.Point(181, 5);
            this.lbText.Name = "lbText";
            this.lbText.Size = new System.Drawing.Size(0, 13);
            this.lbText.TabIndex = 19;
            // 
            // ctlClaims
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbText);
            this.Controls.Add(this.btnPicker);
            this.Controls.Add(this.txtCode);
            this.Name = "ctlClaims";
            this.Size = new System.Drawing.Size(261, 23);
            this.Resize += new System.EventHandler(this.ctlClaims_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPicker;
        public System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lbText;
    }
}

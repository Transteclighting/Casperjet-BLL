namespace CJ.Win
{
    partial class ctlThana
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
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.btnPicker = new System.Windows.Forms.Button();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtDescription1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(113, 3);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(190, 20);
            this.txtDescription.TabIndex = 26;
            this.txtDescription.TabStop = false;
            // 
            // btnPicker
            // 
            this.btnPicker.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnPicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPicker.Location = new System.Drawing.Point(83, 3);
            this.btnPicker.Name = "btnPicker";
            this.btnPicker.Size = new System.Drawing.Size(24, 20);
            this.btnPicker.TabIndex = 25;
            this.btnPicker.Text = "...";
            // 
            // txtCode
            // 
            this.txtCode.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtCode.Location = new System.Drawing.Point(4, 3);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(73, 20);
            this.txtCode.TabIndex = 24;
            this.txtCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtDescription1
            // 
            this.txtDescription1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtDescription1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription1.Location = new System.Drawing.Point(308, 3);
            this.txtDescription1.Name = "txtDescription1";
            this.txtDescription1.ReadOnly = true;
            this.txtDescription1.Size = new System.Drawing.Size(189, 20);
            this.txtDescription1.TabIndex = 27;
            this.txtDescription1.TabStop = false;
            // 
            // ctlThana
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtDescription1);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnPicker);
            this.Controls.Add(this.txtCode);
            this.Name = "ctlThana";
            this.Size = new System.Drawing.Size(504, 28);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Button btnPicker;
        public System.Windows.Forms.TextBox txtCode;
        public System.Windows.Forms.TextBox txtDescription1;
    }
}

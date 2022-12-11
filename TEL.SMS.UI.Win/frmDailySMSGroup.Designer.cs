namespace CJ.Win
{
	partial class frmDailySMSGroup
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
            this.cmbDailySMSGroup = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbDailySMSGroup
            // 
            this.cmbDailySMSGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDailySMSGroup.FormattingEnabled = true;
            this.cmbDailySMSGroup.Location = new System.Drawing.Point(89, 12);
            this.cmbDailySMSGroup.Name = "cmbDailySMSGroup";
            this.cmbDailySMSGroup.Size = new System.Drawing.Size(283, 21);
            this.cmbDailySMSGroup.TabIndex = 12;
            this.cmbDailySMSGroup.SelectedIndexChanged += new System.EventHandler(this.cmbDailySMSGroup_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(288, 39);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 26);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 24);
            this.label2.TabIndex = 23;
            this.label2.Text = "Group Name";
            // 
            // frmDailySMSGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(391, 84);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cmbDailySMSGroup);
            this.Name = "frmDailySMSGroup";
            this.Text = "Daily SMS Group";
            this.Load += new System.EventHandler(this.frmDailySMSGroup_Load);
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.ComboBox cmbDailySMSGroup;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label2;

    }
}
namespace TEL.SMS.UI.Win
{
    partial class frmSMSGroup
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSMSGroup));
            this.btnSave = new System.Windows.Forms.Button();
            this.txtSMSGroupName = new System.Windows.Forms.TextBox();
            this.errMobileSIM = new System.Windows.Forms.ErrorProvider(this.components);
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errMobileSIM)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(338, 31);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(80, 24);
            this.btnSave.TabIndex = 24;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtSMSGroupName
            // 
            this.txtSMSGroupName.Location = new System.Drawing.Point(58, 5);
            this.txtSMSGroupName.Name = "txtSMSGroupName";
            this.txtSMSGroupName.Size = new System.Drawing.Size(360, 20);
            this.txtSMSGroupName.TabIndex = 23;
            this.txtSMSGroupName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSMSGroupName_KeyPress);
            this.txtSMSGroupName.TextChanged += new System.EventHandler(this.txtSMSGroupName_TextChanged);
            // 
            // errMobileSIM
            // 
            this.errMobileSIM.ContainerControl = this;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 22;
            this.label2.Text = "Name";
            // 
            // frmSMSGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 64);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtSMSGroupName);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSMSGroup";
            this.Text = "SMS Group";
            this.Load += new System.EventHandler(this.frmSMSGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errMobileSIM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtSMSGroupName;
        private System.Windows.Forms.ErrorProvider errMobileSIM;
        private System.Windows.Forms.Label label2;
    }
}
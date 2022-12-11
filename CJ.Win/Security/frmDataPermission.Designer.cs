namespace CJ.Win.Security
{
    partial class frmDataPermission
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
            this.tvwDataPermission = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.UserNam = new System.Windows.Forms.Label();
            this.lbUserFullName = new System.Windows.Forms.Label();
            this.lbUserName = new System.Windows.Forms.Label();
            this.btSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tvwDataPermission
            // 
            this.tvwDataPermission.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tvwDataPermission.CheckBoxes = true;
            this.tvwDataPermission.Location = new System.Drawing.Point(12, 51);
            this.tvwDataPermission.Name = "tvwDataPermission";
            this.tvwDataPermission.Size = new System.Drawing.Size(400, 336);
            this.tvwDataPermission.TabIndex = 21;
            this.tvwDataPermission.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvwDataPermission_AfterCheck);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(14, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "User Full Name :";
            // 
            // UserNam
            // 
            this.UserNam.Location = new System.Drawing.Point(31, 24);
            this.UserNam.Name = "UserNam";
            this.UserNam.Size = new System.Drawing.Size(74, 20);
            this.UserNam.TabIndex = 22;
            this.UserNam.Text = "User Name :";
            // 
            // lbUserFullName
            // 
            this.lbUserFullName.Location = new System.Drawing.Point(108, 4);
            this.lbUserFullName.Name = "lbUserFullName";
            this.lbUserFullName.Size = new System.Drawing.Size(301, 18);
            this.lbUserFullName.TabIndex = 24;
            this.lbUserFullName.Text = "?";
            // 
            // lbUserName
            // 
            this.lbUserName.Location = new System.Drawing.Point(107, 22);
            this.lbUserName.Name = "lbUserName";
            this.lbUserName.Size = new System.Drawing.Size(298, 20);
            this.lbUserName.TabIndex = 25;
            this.lbUserName.Text = "?";
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(175, 393);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 26;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // frmDataPermission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(451, 428);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.lbUserName);
            this.Controls.Add(this.lbUserFullName);
            this.Controls.Add(this.tvwDataPermission);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.UserNam);
            this.Name = "frmDataPermission";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmDataPermission_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvwDataPermission;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label UserNam;
        private System.Windows.Forms.Label lbUserFullName;
        private System.Windows.Forms.Label lbUserName;
        private System.Windows.Forms.Button btSave;
    }
}
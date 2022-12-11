namespace CJ.Win.CAC
{
    partial class frmCACProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCACProduct));
            this.txtProductModel = new System.Windows.Forms.TextBox();
            this.lblProductModel = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.lblProductDescription = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.cmbProductGroup = new System.Windows.Forms.ComboBox();
            this.label52 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.cmbMAG = new System.Windows.Forms.ComboBox();
            this.chkIsActivate = new System.Windows.Forms.CheckBox();
            this.cmbBrand = new System.Windows.Forms.ComboBox();
            this.label54 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.cmbASG = new System.Windows.Forms.ComboBox();
            this.cmbAG = new System.Windows.Forms.ComboBox();
            this.label56 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtProductModel
            // 
            this.txtProductModel.Location = new System.Drawing.Point(84, 75);
            this.txtProductModel.Name = "txtProductModel";
            this.txtProductModel.Size = new System.Drawing.Size(430, 20);
            this.txtProductModel.TabIndex = 5;
            // 
            // lblProductModel
            // 
            this.lblProductModel.AutoSize = true;
            this.lblProductModel.Location = new System.Drawing.Point(5, 78);
            this.lblProductModel.Name = "lblProductModel";
            this.lblProductModel.Size = new System.Drawing.Size(76, 13);
            this.lblProductModel.TabIndex = 4;
            this.lblProductModel.Text = "Product Model";
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSave.Location = new System.Drawing.Point(351, 183);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(84, 38);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(430, 29);
            this.txtDesc.TabIndex = 3;
            // 
            // lblProductDescription
            // 
            this.lblProductDescription.AutoSize = true;
            this.lblProductDescription.Location = new System.Drawing.Point(21, 43);
            this.lblProductDescription.Name = "lblProductDescription";
            this.lblProductDescription.Size = new System.Drawing.Size(60, 13);
            this.lblProductDescription.TabIndex = 2;
            this.lblProductDescription.Text = "Description";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(84, 12);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(430, 20);
            this.txtName.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(6, 15);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(75, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Product Name";
            // 
            // cmbProductGroup
            // 
            this.cmbProductGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProductGroup.FormattingEnabled = true;
            this.cmbProductGroup.Location = new System.Drawing.Point(84, 101);
            this.cmbProductGroup.Name = "cmbProductGroup";
            this.cmbProductGroup.Size = new System.Drawing.Size(190, 21);
            this.cmbProductGroup.TabIndex = 7;
            this.cmbProductGroup.SelectedIndexChanged += new System.EventHandler(this.cmbProductGroup_SelectedIndexChanged);
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(59, 101);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(22, 13);
            this.label52.TabIndex = 6;
            this.label52.Text = "PG";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(46, 158);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(35, 13);
            this.label53.TabIndex = 14;
            this.label53.Text = "Brand";
            // 
            // cmbMAG
            // 
            this.cmbMAG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMAG.FormattingEnabled = true;
            this.cmbMAG.Location = new System.Drawing.Point(324, 101);
            this.cmbMAG.Name = "cmbMAG";
            this.cmbMAG.Size = new System.Drawing.Size(190, 21);
            this.cmbMAG.TabIndex = 9;
            this.cmbMAG.SelectedIndexChanged += new System.EventHandler(this.cmbMAG_SelectedIndexChanged);
            // 
            // chkIsActivate
            // 
            this.chkIsActivate.AutoSize = true;
            this.chkIsActivate.Checked = true;
            this.chkIsActivate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActivate.Location = new System.Drawing.Point(324, 155);
            this.chkIsActivate.Name = "chkIsActivate";
            this.chkIsActivate.Size = new System.Drawing.Size(56, 17);
            this.chkIsActivate.TabIndex = 16;
            this.chkIsActivate.Text = "Active";
            this.chkIsActivate.UseVisualStyleBackColor = true;
            // 
            // cmbBrand
            // 
            this.cmbBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Location = new System.Drawing.Point(84, 155);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(190, 21);
            this.cmbBrand.TabIndex = 15;
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(290, 104);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(31, 13);
            this.label54.TabIndex = 8;
            this.label54.Text = "MAG";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(299, 128);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(22, 13);
            this.label55.TabIndex = 12;
            this.label55.Text = "AG";
            // 
            // cmbASG
            // 
            this.cmbASG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbASG.FormattingEnabled = true;
            this.cmbASG.Location = new System.Drawing.Point(84, 128);
            this.cmbASG.Name = "cmbASG";
            this.cmbASG.Size = new System.Drawing.Size(190, 21);
            this.cmbASG.TabIndex = 11;
            this.cmbASG.SelectedIndexChanged += new System.EventHandler(this.cmbASG_SelectedIndexChanged);
            // 
            // cmbAG
            // 
            this.cmbAG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAG.FormattingEnabled = true;
            this.cmbAG.Location = new System.Drawing.Point(324, 128);
            this.cmbAG.Name = "cmbAG";
            this.cmbAG.Size = new System.Drawing.Size(190, 21);
            this.cmbAG.TabIndex = 13;
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Location = new System.Drawing.Point(52, 128);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(29, 13);
            this.label56.TabIndex = 10;
            this.label56.Text = "ASG";
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(439, 183);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // frmCACProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 214);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cmbProductGroup);
            this.Controls.Add(this.label52);
            this.Controls.Add(this.label53);
            this.Controls.Add(this.cmbMAG);
            this.Controls.Add(this.chkIsActivate);
            this.Controls.Add(this.cmbBrand);
            this.Controls.Add(this.label54);
            this.Controls.Add(this.label55);
            this.Controls.Add(this.cmbASG);
            this.Controls.Add(this.cmbAG);
            this.Controls.Add(this.label56);
            this.Controls.Add(this.txtProductModel);
            this.Controls.Add(this.lblProductModel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDesc);
            this.Controls.Add(this.lblProductDescription);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCACProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCACProduct";
            this.Load += new System.EventHandler(this.frmCACProduct_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtProductModel;
        private System.Windows.Forms.Label lblProductModel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label lblProductDescription;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.ComboBox cmbProductGroup;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.ComboBox cmbMAG;
        private System.Windows.Forms.CheckBox chkIsActivate;
        private System.Windows.Forms.ComboBox cmbBrand;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.ComboBox cmbASG;
        private System.Windows.Forms.ComboBox cmbAG;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Button btnClose;
    }
}
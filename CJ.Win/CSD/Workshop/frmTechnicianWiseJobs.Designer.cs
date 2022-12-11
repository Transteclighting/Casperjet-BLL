namespace CJ.Win.CSD.Workshop
{
    partial class frmTechnicianWiseJobs
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbWorkshop = new System.Windows.Forms.ComboBox();
            this.cmbTechnician = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbSupervisor = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rdoAll = new System.Windows.Forms.RadioButton();
            this.rdoOwn = new System.Windows.Forms.RadioButton();
            this.rdoThirdparty = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnView = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Workshop";
            // 
            // cmbWorkshop
            // 
            this.cmbWorkshop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorkshop.FormattingEnabled = true;
            this.cmbWorkshop.Location = new System.Drawing.Point(66, 10);
            this.cmbWorkshop.Name = "cmbWorkshop";
            this.cmbWorkshop.Size = new System.Drawing.Size(253, 21);
            this.cmbWorkshop.TabIndex = 1;
            // 
            // cmbTechnician
            // 
            this.cmbTechnician.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTechnician.FormattingEnabled = true;
            this.cmbTechnician.Location = new System.Drawing.Point(66, 60);
            this.cmbTechnician.Name = "cmbTechnician";
            this.cmbTechnician.Size = new System.Drawing.Size(253, 21);
            this.cmbTechnician.TabIndex = 5;
            this.cmbTechnician.SelectedIndexChanged += new System.EventHandler(this.cmbTechnician_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Technician";
            // 
            // cmbSupervisor
            // 
            this.cmbSupervisor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSupervisor.FormattingEnabled = true;
            this.cmbSupervisor.Location = new System.Drawing.Point(66, 35);
            this.cmbSupervisor.Name = "cmbSupervisor";
            this.cmbSupervisor.Size = new System.Drawing.Size(253, 21);
            this.cmbSupervisor.TabIndex = 3;
            this.cmbSupervisor.SelectedIndexChanged += new System.EventHandler(this.cmbSupervisor_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 38);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Supervisor";
            // 
            // rdoAll
            // 
            this.rdoAll.AutoSize = true;
            this.rdoAll.Location = new System.Drawing.Point(16, 20);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Size = new System.Drawing.Size(36, 17);
            this.rdoAll.TabIndex = 0;
            this.rdoAll.TabStop = true;
            this.rdoAll.Text = "All";
            this.rdoAll.UseVisualStyleBackColor = true;
            // 
            // rdoOwn
            // 
            this.rdoOwn.AutoSize = true;
            this.rdoOwn.Location = new System.Drawing.Point(114, 20);
            this.rdoOwn.Name = "rdoOwn";
            this.rdoOwn.Size = new System.Drawing.Size(47, 17);
            this.rdoOwn.TabIndex = 1;
            this.rdoOwn.TabStop = true;
            this.rdoOwn.Text = "Own";
            this.rdoOwn.UseVisualStyleBackColor = true;
            // 
            // rdoThirdparty
            // 
            this.rdoThirdparty.AutoSize = true;
            this.rdoThirdparty.Location = new System.Drawing.Point(226, 20);
            this.rdoThirdparty.Name = "rdoThirdparty";
            this.rdoThirdparty.Size = new System.Drawing.Size(76, 17);
            this.rdoThirdparty.TabIndex = 2;
            this.rdoThirdparty.TabStop = true;
            this.rdoThirdparty.Text = "Third Party";
            this.rdoThirdparty.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoThirdparty);
            this.groupBox1.Controls.Add(this.rdoAll);
            this.groupBox1.Controls.Add(this.rdoOwn);
            this.groupBox1.Location = new System.Drawing.Point(10, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(309, 50);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tehnician Type";
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(240, 143);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(79, 27);
            this.btnView.TabIndex = 7;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // frmTechnicianWiseJobs
            // 
            this.AcceptButton = this.btnView;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 181);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cmbSupervisor);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbTechnician);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbWorkshop);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "frmTechnicianWiseJobs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Technician Wise Jobs";
            this.Load += new System.EventHandler(this.frmTechnicianWiseJobs_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbWorkshop;
        private System.Windows.Forms.ComboBox cmbTechnician;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbSupervisor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdoAll;
        private System.Windows.Forms.RadioButton rdoOwn;
        private System.Windows.Forms.RadioButton rdoThirdparty;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnView;
    }
}
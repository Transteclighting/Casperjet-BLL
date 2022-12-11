namespace CJ.Win.HR.Recruitment
{
    partial class frmHRCVs
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.lvwCV = new System.Windows.Forms.ListView();
            this.colCVNo = new System.Windows.Forms.ColumnHeader();
            this.colCandidateName = new System.Windows.Forms.ColumnHeader();
            this.colContactNo = new System.Windows.Forms.ColumnHeader();
            this.colEmail = new System.Windows.Forms.ColumnHeader();
            this.colForPosition = new System.Windows.Forms.ColumnHeader();
            this.colSource = new System.Windows.Forms.ColumnHeader();
            this.colStatus = new System.Windows.Forms.ColumnHeader();
            this.txtCVNo = new System.Windows.Forms.TextBox();
            this.btnGetData = new System.Windows.Forms.Button();
            this.txtCandidateName = new System.Windows.Forms.TextBox();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Close = new System.Windows.Forms.Button();
            this.btnShowCV = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(689, 69);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lvwCV
            // 
            this.lvwCV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwCV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCVNo,
            this.colCandidateName,
            this.colContactNo,
            this.colEmail,
            this.colForPosition,
            this.colSource,
            this.colStatus});
            this.lvwCV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lvwCV.FullRowSelect = true;
            this.lvwCV.GridLines = true;
            this.lvwCV.HideSelection = false;
            this.lvwCV.Location = new System.Drawing.Point(7, 69);
            this.lvwCV.MultiSelect = false;
            this.lvwCV.Name = "lvwCV";
            this.lvwCV.Size = new System.Drawing.Size(671, 344);
            this.lvwCV.TabIndex = 85;
            this.lvwCV.UseCompatibleStateImageBehavior = false;
            this.lvwCV.View = System.Windows.Forms.View.Details;
            // 
            // colCVNo
            // 
            this.colCVNo.Text = "CV #";
            this.colCVNo.Width = 101;
            // 
            // colCandidateName
            // 
            this.colCandidateName.Text = "Candidate Name";
            this.colCandidateName.Width = 182;
            // 
            // colContactNo
            // 
            this.colContactNo.Text = "Contact No";
            this.colContactNo.Width = 106;
            // 
            // colEmail
            // 
            this.colEmail.Text = "Email";
            this.colEmail.Width = 91;
            // 
            // colForPosition
            // 
            this.colForPosition.Text = "For Position";
            this.colForPosition.Width = 174;
            // 
            // colSource
            // 
            this.colSource.Text = "Source";
            this.colSource.Width = 112;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 88;
            // 
            // txtCVNo
            // 
            this.txtCVNo.Location = new System.Drawing.Point(93, 16);
            this.txtCVNo.Name = "txtCVNo";
            this.txtCVNo.Size = new System.Drawing.Size(195, 20);
            this.txtCVNo.TabIndex = 87;
            // 
            // btnGetData
            // 
            this.btnGetData.Location = new System.Drawing.Point(569, 40);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(75, 23);
            this.btnGetData.TabIndex = 88;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // txtCandidateName
            // 
            this.txtCandidateName.Location = new System.Drawing.Point(93, 42);
            this.txtCandidateName.Name = "txtCandidateName";
            this.txtCandidateName.Size = new System.Drawing.Size(470, 20);
            this.txtCandidateName.TabIndex = 89;
            // 
            // txtContactNo
            // 
            this.txtContactNo.Location = new System.Drawing.Point(370, 14);
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(193, 20);
            this.txtContactNo.TabIndex = 90;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(306, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 91;
            this.label1.Text = "Contact No";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 92;
            this.label2.Text = "Candidate Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(62, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 93;
            this.label3.Text = "CV#";
            // 
            // Close
            // 
            this.Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Close.Location = new System.Drawing.Point(689, 390);
            this.Close.Name = "Close";
            this.Close.Size = new System.Drawing.Size(75, 23);
            this.Close.TabIndex = 94;
            this.Close.Text = "Close";
            this.Close.UseVisualStyleBackColor = true;
            // 
            // btnShowCV
            // 
            this.btnShowCV.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowCV.Location = new System.Drawing.Point(689, 98);
            this.btnShowCV.Name = "btnShowCV";
            this.btnShowCV.Size = new System.Drawing.Size(75, 23);
            this.btnShowCV.TabIndex = 95;
            this.btnShowCV.Text = "Show CV";
            this.btnShowCV.UseVisualStyleBackColor = true;
            this.btnShowCV.Click += new System.EventHandler(this.btnShowCV_Click);
            // 
            // frmHRCVs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 425);
            this.Controls.Add(this.btnShowCV);
            this.Controls.Add(this.Close);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtContactNo);
            this.Controls.Add(this.txtCandidateName);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.txtCVNo);
            this.Controls.Add(this.lvwCV);
            this.Controls.Add(this.btnAdd);
            this.Name = "frmHRCVs";
            this.Text = "frmHRCVs";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView lvwCV;
        private System.Windows.Forms.TextBox txtCVNo;
        private System.Windows.Forms.ColumnHeader colCVNo;
        private System.Windows.Forms.ColumnHeader colCandidateName;
        private System.Windows.Forms.ColumnHeader colContactNo;
        private System.Windows.Forms.ColumnHeader colEmail;
        private System.Windows.Forms.ColumnHeader colForPosition;
        private System.Windows.Forms.ColumnHeader colSource;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.TextBox txtCandidateName;
        private System.Windows.Forms.TextBox txtContactNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Close;
        private System.Windows.Forms.Button btnShowCV;
    }
}
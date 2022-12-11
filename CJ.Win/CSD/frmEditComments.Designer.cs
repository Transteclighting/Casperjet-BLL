namespace CJ.Win
{
    partial class frmEditComments
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
            this.chkCrossReplacement = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dtTecMgrCommentDate = new System.Windows.Forms.DateTimePicker();
            this.txtTecMgrComment = new System.Windows.Forms.TextBox();
            this.cmbTecMgrReason = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dtHeadCommentDate = new System.Windows.Forms.DateTimePicker();
            this.txtHeadComment = new System.Windows.Forms.TextBox();
            this.cmbHeadReason = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblHeadComment = new System.Windows.Forms.Label();
            this.lblHeadReason = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dtMgrCommentDate = new System.Windows.Forms.DateTimePicker();
            this.txtMgrComment = new System.Windows.Forms.TextBox();
            this.cmbMgrReason = new System.Windows.Forms.ComboBox();
            this.lblMgrDate = new System.Windows.Forms.Label();
            this.lblMgrComment = new System.Windows.Forms.Label();
            this.lblMgrReason = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtCommentDate = new System.Windows.Forms.DateTimePicker();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.cmbReason = new System.Windows.Forms.ComboBox();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblComment = new System.Windows.Forms.Label();
            this.lblReason = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblJobID = new System.Windows.Forms.Label();
            this.lblJobTitle = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.ctlProduct1 = new CJ.Win.ctlProduct();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkCrossReplacement
            // 
            this.chkCrossReplacement.AutoSize = true;
            this.chkCrossReplacement.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCrossReplacement.Location = new System.Drawing.Point(43, 348);
            this.chkCrossReplacement.Name = "chkCrossReplacement";
            this.chkCrossReplacement.Size = new System.Drawing.Size(152, 17);
            this.chkCrossReplacement.TabIndex = 156;
            this.chkCrossReplacement.Text = "IsCross Replacement?";
            this.chkCrossReplacement.UseVisualStyleBackColor = true;
            this.chkCrossReplacement.CheckedChanged += new System.EventHandler(this.chkCrossReplacement_CheckedChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dtTecMgrCommentDate);
            this.groupBox4.Controls.Add(this.txtTecMgrComment);
            this.groupBox4.Controls.Add(this.cmbTecMgrReason);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(435, 71);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(381, 131);
            this.groupBox4.TabIndex = 152;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Technical Manager";
            // 
            // dtTecMgrCommentDate
            // 
            this.dtTecMgrCommentDate.CustomFormat = "dd-MMM-yyyy";
            this.dtTecMgrCommentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtTecMgrCommentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTecMgrCommentDate.Location = new System.Drawing.Point(74, 91);
            this.dtTecMgrCommentDate.Name = "dtTecMgrCommentDate";
            this.dtTecMgrCommentDate.Size = new System.Drawing.Size(109, 20);
            this.dtTecMgrCommentDate.TabIndex = 142;
            // 
            // txtTecMgrComment
            // 
            this.txtTecMgrComment.Location = new System.Drawing.Point(74, 46);
            this.txtTecMgrComment.Multiline = true;
            this.txtTecMgrComment.Name = "txtTecMgrComment";
            this.txtTecMgrComment.Size = new System.Drawing.Size(276, 41);
            this.txtTecMgrComment.TabIndex = 141;
            // 
            // cmbTecMgrReason
            // 
            this.cmbTecMgrReason.FormattingEnabled = true;
            this.cmbTecMgrReason.Location = new System.Drawing.Point(74, 20);
            this.cmbTecMgrReason.Name = "cmbTecMgrReason";
            this.cmbTecMgrReason.Size = new System.Drawing.Size(201, 21);
            this.cmbTecMgrReason.TabIndex = 140;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(31, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 139;
            this.label5.Text = "Date";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 13);
            this.label6.TabIndex = 138;
            this.label6.Text = "Comments";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 13);
            this.label7.TabIndex = 137;
            this.label7.Text = "Reason";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dtHeadCommentDate);
            this.groupBox3.Controls.Add(this.txtHeadComment);
            this.groupBox3.Controls.Add(this.cmbHeadReason);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.lblHeadComment);
            this.groupBox3.Controls.Add(this.lblHeadReason);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(435, 208);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(390, 135);
            this.groupBox3.TabIndex = 154;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Head Of Service";
            // 
            // dtHeadCommentDate
            // 
            this.dtHeadCommentDate.CustomFormat = "dd-MMM-yyyy";
            this.dtHeadCommentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtHeadCommentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtHeadCommentDate.Location = new System.Drawing.Point(73, 92);
            this.dtHeadCommentDate.Name = "dtHeadCommentDate";
            this.dtHeadCommentDate.Size = new System.Drawing.Size(109, 20);
            this.dtHeadCommentDate.TabIndex = 142;
            // 
            // txtHeadComment
            // 
            this.txtHeadComment.Location = new System.Drawing.Point(73, 45);
            this.txtHeadComment.Multiline = true;
            this.txtHeadComment.Name = "txtHeadComment";
            this.txtHeadComment.Size = new System.Drawing.Size(276, 41);
            this.txtHeadComment.TabIndex = 141;
            // 
            // cmbHeadReason
            // 
            this.cmbHeadReason.FormattingEnabled = true;
            this.cmbHeadReason.Location = new System.Drawing.Point(73, 19);
            this.cmbHeadReason.Name = "cmbHeadReason";
            this.cmbHeadReason.Size = new System.Drawing.Size(201, 21);
            this.cmbHeadReason.TabIndex = 140;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(30, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 139;
            this.label4.Text = "Date";
            // 
            // lblHeadComment
            // 
            this.lblHeadComment.AutoSize = true;
            this.lblHeadComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeadComment.Location = new System.Drawing.Point(6, 59);
            this.lblHeadComment.Name = "lblHeadComment";
            this.lblHeadComment.Size = new System.Drawing.Size(64, 13);
            this.lblHeadComment.TabIndex = 138;
            this.lblHeadComment.Text = "Comments";
            // 
            // lblHeadReason
            // 
            this.lblHeadReason.AutoSize = true;
            this.lblHeadReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeadReason.Location = new System.Drawing.Point(14, 19);
            this.lblHeadReason.Name = "lblHeadReason";
            this.lblHeadReason.Size = new System.Drawing.Size(50, 13);
            this.lblHeadReason.TabIndex = 137;
            this.lblHeadReason.Text = "Reason";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dtMgrCommentDate);
            this.groupBox2.Controls.Add(this.txtMgrComment);
            this.groupBox2.Controls.Add(this.cmbMgrReason);
            this.groupBox2.Controls.Add(this.lblMgrDate);
            this.groupBox2.Controls.Add(this.lblMgrComment);
            this.groupBox2.Controls.Add(this.lblMgrReason);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(40, 213);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(381, 130);
            this.groupBox2.TabIndex = 153;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Customer Service Manager";
            // 
            // dtMgrCommentDate
            // 
            this.dtMgrCommentDate.CustomFormat = "dd-MMM-yyyy";
            this.dtMgrCommentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtMgrCommentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtMgrCommentDate.Location = new System.Drawing.Point(74, 97);
            this.dtMgrCommentDate.Name = "dtMgrCommentDate";
            this.dtMgrCommentDate.Size = new System.Drawing.Size(109, 20);
            this.dtMgrCommentDate.TabIndex = 142;
            // 
            // txtMgrComment
            // 
            this.txtMgrComment.Location = new System.Drawing.Point(74, 50);
            this.txtMgrComment.Multiline = true;
            this.txtMgrComment.Name = "txtMgrComment";
            this.txtMgrComment.Size = new System.Drawing.Size(276, 41);
            this.txtMgrComment.TabIndex = 141;
            // 
            // cmbMgrReason
            // 
            this.cmbMgrReason.FormattingEnabled = true;
            this.cmbMgrReason.Location = new System.Drawing.Point(74, 22);
            this.cmbMgrReason.Name = "cmbMgrReason";
            this.cmbMgrReason.Size = new System.Drawing.Size(201, 21);
            this.cmbMgrReason.TabIndex = 140;
            // 
            // lblMgrDate
            // 
            this.lblMgrDate.AutoSize = true;
            this.lblMgrDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMgrDate.Location = new System.Drawing.Point(31, 102);
            this.lblMgrDate.Name = "lblMgrDate";
            this.lblMgrDate.Size = new System.Drawing.Size(34, 13);
            this.lblMgrDate.TabIndex = 139;
            this.lblMgrDate.Text = "Date";
            // 
            // lblMgrComment
            // 
            this.lblMgrComment.AutoSize = true;
            this.lblMgrComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMgrComment.Location = new System.Drawing.Point(7, 64);
            this.lblMgrComment.Name = "lblMgrComment";
            this.lblMgrComment.Size = new System.Drawing.Size(64, 13);
            this.lblMgrComment.TabIndex = 138;
            this.lblMgrComment.Text = "Comments";
            // 
            // lblMgrReason
            // 
            this.lblMgrReason.AutoSize = true;
            this.lblMgrReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMgrReason.Location = new System.Drawing.Point(15, 24);
            this.lblMgrReason.Name = "lblMgrReason";
            this.lblMgrReason.Size = new System.Drawing.Size(50, 13);
            this.lblMgrReason.TabIndex = 137;
            this.lblMgrReason.Text = "Reason";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtCommentDate);
            this.groupBox1.Controls.Add(this.txtComment);
            this.groupBox1.Controls.Add(this.cmbReason);
            this.groupBox1.Controls.Add(this.lblDate);
            this.groupBox1.Controls.Add(this.lblComment);
            this.groupBox1.Controls.Add(this.lblReason);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(40, 71);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(389, 131);
            this.groupBox1.TabIndex = 151;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Technical Supervisor";
            // 
            // dtCommentDate
            // 
            this.dtCommentDate.CustomFormat = "dd-MMM-yyyy";
            this.dtCommentDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtCommentDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtCommentDate.Location = new System.Drawing.Point(73, 96);
            this.dtCommentDate.Name = "dtCommentDate";
            this.dtCommentDate.Size = new System.Drawing.Size(109, 20);
            this.dtCommentDate.TabIndex = 142;
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(73, 49);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(276, 41);
            this.txtComment.TabIndex = 141;
            // 
            // cmbReason
            // 
            this.cmbReason.FormattingEnabled = true;
            this.cmbReason.Location = new System.Drawing.Point(73, 23);
            this.cmbReason.Name = "cmbReason";
            this.cmbReason.Size = new System.Drawing.Size(201, 21);
            this.cmbReason.TabIndex = 140;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.Location = new System.Drawing.Point(30, 101);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(34, 13);
            this.lblDate.TabIndex = 139;
            this.lblDate.Text = "Date";
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComment.Location = new System.Drawing.Point(6, 63);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(64, 13);
            this.lblComment.TabIndex = 138;
            this.lblComment.Text = "Comments";
            // 
            // lblReason
            // 
            this.lblReason.AutoSize = true;
            this.lblReason.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReason.Location = new System.Drawing.Point(14, 23);
            this.lblReason.Name = "lblReason";
            this.lblReason.Size = new System.Drawing.Size(50, 13);
            this.lblReason.TabIndex = 137;
            this.lblReason.Text = "Reason";
            // 
            // lblProduct
            // 
            this.lblProduct.AutoSize = true;
            this.lblProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProduct.Location = new System.Drawing.Point(37, 375);
            this.lblProduct.Name = "lblProduct";
            this.lblProduct.Size = new System.Drawing.Size(51, 13);
            this.lblProduct.TabIndex = 158;
            this.lblProduct.Text = "Product";
            // 
            // lblJobID
            // 
            this.lblJobID.AutoSize = true;
            this.lblJobID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobID.Location = new System.Drawing.Point(40, 32);
            this.lblJobID.Name = "lblJobID";
            this.lblJobID.Size = new System.Drawing.Size(60, 13);
            this.lblJobID.TabIndex = 143;
            this.lblJobID.Text = "Job Code";
            // 
            // lblJobTitle
            // 
            this.lblJobTitle.AutoSize = true;
            this.lblJobTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJobTitle.Location = new System.Drawing.Point(115, 32);
            this.lblJobTitle.Name = "lblJobTitle";
            this.lblJobTitle.Size = new System.Drawing.Size(56, 13);
            this.lblJobTitle.TabIndex = 159;
            this.lblJobTitle.Text = "Job Title";
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(631, 401);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 160;
            this.btnEdit.Text = "Save";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(722, 401);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 161;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ctlProduct1
            // 
            this.ctlProduct1.Location = new System.Drawing.Point(94, 369);
            this.ctlProduct1.Name = "ctlProduct1";
            this.ctlProduct1.Size = new System.Drawing.Size(437, 25);
            this.ctlProduct1.TabIndex = 155;
            // 
            // frmEditComments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 436);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.lblJobTitle);
            this.Controls.Add(this.lblJobID);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.chkCrossReplacement);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.ctlProduct1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmEditComments";
            this.Text = "Edit Comments";
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkCrossReplacement;
        private ctlProduct ctlProduct1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DateTimePicker dtTecMgrCommentDate;
        private System.Windows.Forms.TextBox txtTecMgrComment;
        private System.Windows.Forms.ComboBox cmbTecMgrReason;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker dtHeadCommentDate;
        private System.Windows.Forms.TextBox txtHeadComment;
        private System.Windows.Forms.ComboBox cmbHeadReason;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblHeadComment;
        private System.Windows.Forms.Label lblHeadReason;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DateTimePicker dtMgrCommentDate;
        private System.Windows.Forms.TextBox txtMgrComment;
        private System.Windows.Forms.ComboBox cmbMgrReason;
        private System.Windows.Forms.Label lblMgrDate;
        private System.Windows.Forms.Label lblMgrComment;
        private System.Windows.Forms.Label lblMgrReason;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtCommentDate;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.ComboBox cmbReason;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.Label lblReason;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblJobID;
        private System.Windows.Forms.Label lblJobTitle;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClose;
    }
}
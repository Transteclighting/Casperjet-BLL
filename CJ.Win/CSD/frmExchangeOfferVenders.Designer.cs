namespace CJ.Win.CSD
{
    partial class frmExchangeOfferVenders
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExchangeOfferVenders));
            this.lvwExchangeOfferVenders = new System.Windows.Forms.ListView();
            this.colVenderCode = new System.Windows.Forms.ColumnHeader();
            this.colVenderName = new System.Windows.Forms.ColumnHeader();
            this.colParentCustomer = new System.Windows.Forms.ColumnHeader();
            this.colRemarks = new System.Windows.Forms.ColumnHeader();
            this.colIsactive = new System.Windows.Forms.ColumnHeader();
            this.btnGetData = new System.Windows.Forms.Button();
            this.Name = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtParentVender = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtParentCustomer = new System.Windows.Forms.TextBox();
            this.colParentVender = new System.Windows.Forms.ColumnHeader();
            this.colBalance = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lvwExchangeOfferVenders
            // 
            this.lvwExchangeOfferVenders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwExchangeOfferVenders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colVenderCode,
            this.colVenderName,
            this.colParentVender,
            this.colParentCustomer,
            this.colBalance,
            this.colRemarks,
            this.colIsactive});
            this.lvwExchangeOfferVenders.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lvwExchangeOfferVenders.FullRowSelect = true;
            this.lvwExchangeOfferVenders.GridLines = true;
            this.lvwExchangeOfferVenders.HideSelection = false;
            this.lvwExchangeOfferVenders.Location = new System.Drawing.Point(12, 115);
            this.lvwExchangeOfferVenders.MultiSelect = false;
            this.lvwExchangeOfferVenders.Name = "lvwExchangeOfferVenders";
            this.lvwExchangeOfferVenders.Size = new System.Drawing.Size(620, 245);
            this.lvwExchangeOfferVenders.TabIndex = 7;
            this.lvwExchangeOfferVenders.UseCompatibleStateImageBehavior = false;
            this.lvwExchangeOfferVenders.View = System.Windows.Forms.View.Details;
            // 
            // colVenderCode
            // 
            this.colVenderCode.Text = "Vender Code";
            this.colVenderCode.Width = 84;
            // 
            // colVenderName
            // 
            this.colVenderName.Text = "Vender Name";
            this.colVenderName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colVenderName.Width = 89;
            // 
            // colParentCustomer
            // 
            this.colParentCustomer.Text = "Parent Customer Name";
            this.colParentCustomer.Width = 125;
            // 
            // colRemarks
            // 
            this.colRemarks.Text = "Remarks";
            this.colRemarks.Width = 147;
            // 
            // colIsactive
            // 
            this.colIsactive.Text = "Is Active";
            this.colIsactive.Width = 62;
            // 
            // btnGetData
            // 
            this.btnGetData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetData.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnGetData.Location = new System.Drawing.Point(543, 82);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(89, 27);
            this.btnGetData.TabIndex = 6;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // Name
            // 
            this.Name.AutoSize = true;
            this.Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name.Location = new System.Drawing.Point(50, 40);
            this.Name.Name = "Name";
            this.Name.Size = new System.Drawing.Size(72, 13);
            this.Name.TabIndex = 4;
            this.Name.Text = "Vender Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(124, 37);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(385, 20);
            this.txtName.TabIndex = 5;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(284, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Contact No";
            // 
            // txtContactNo
            // 
            this.txtContactNo.Location = new System.Drawing.Point(348, 11);
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(161, 20);
            this.txtContactNo.TabIndex = 3;
            this.txtContactNo.TextChanged += new System.EventHandler(this.txtContactNo_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(53, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vender Code";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(124, 11);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(155, 20);
            this.txtCode.TabIndex = 1;
            this.txtCode.TextChanged += new System.EventHandler(this.txtCode_TextChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAdd.Location = new System.Drawing.Point(642, 115);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 25);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnEdit.Location = new System.Drawing.Point(642, 146);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(80, 25);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnClose.Location = new System.Drawing.Point(642, 335);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 25);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Parent Vender Name";
            // 
            // txtParentVender
            // 
            this.txtParentVender.Location = new System.Drawing.Point(124, 63);
            this.txtParentVender.Name = "txtParentVender";
            this.txtParentVender.Size = new System.Drawing.Size(385, 20);
            this.txtParentVender.TabIndex = 12;
            this.txtParentVender.TextChanged += new System.EventHandler(this.txtParentVender_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Parent Customer Name";
            // 
            // txtParentCustomer
            // 
            this.txtParentCustomer.Location = new System.Drawing.Point(124, 89);
            this.txtParentCustomer.Name = "txtParentCustomer";
            this.txtParentCustomer.Size = new System.Drawing.Size(385, 20);
            this.txtParentCustomer.TabIndex = 14;
            this.txtParentCustomer.TextChanged += new System.EventHandler(this.txtParentCustomer_TextChanged);
            // 
            // colParentVender
            // 
            this.colParentVender.Text = "Parent Vender Name";
            this.colParentVender.Width = 112;
            // 
            // colBalance
            // 
            this.colBalance.Text = "Balance";
            this.colBalance.Width = 85;
            // 
            // frmExchangeOfferVenders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 372);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtParentCustomer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtParentVender);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.Name);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtContactNo);
            this.Controls.Add(this.lvwExchangeOfferVenders);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            //this.Name = "frmExchangeOfferVenders";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmExchangeOfferVenders";
            this.Load += new System.EventHandler(this.frmExchangeOfferVenders_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwExchangeOfferVenders;
        private System.Windows.Forms.ColumnHeader colVenderCode;
        private System.Windows.Forms.ColumnHeader colVenderName;
        private System.Windows.Forms.ColumnHeader colIsactive;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.Label Name;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtContactNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColumnHeader colRemarks;
        private System.Windows.Forms.ColumnHeader colParentCustomer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtParentVender;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtParentCustomer;
        private System.Windows.Forms.ColumnHeader colParentVender;
        private System.Windows.Forms.ColumnHeader colBalance;
    }
}
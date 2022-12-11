namespace CJ.Win.CSD
{
    partial class frmExchangeOfferVenderParnets
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGetData = new System.Windows.Forms.Button();
            this.colIsactive = new System.Windows.Forms.ColumnHeader();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.colRemarks = new System.Windows.Forms.ColumnHeader();
            this.colVenderCode = new System.Windows.Forms.ColumnHeader();
            this.Name = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.colAddress = new System.Windows.Forms.ColumnHeader();
            this.label5 = new System.Windows.Forms.Label();
            this.colVenderName = new System.Windows.Forms.ColumnHeader();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.colContactPerson = new System.Windows.Forms.ColumnHeader();
            this.lvwExchangeOfferVenders = new System.Windows.Forms.ListView();
            this.colContactNo = new System.Windows.Forms.ColumnHeader();
            this.colEmail = new System.Windows.Forms.ColumnHeader();
            this.colParentBalance = new System.Windows.Forms.ColumnHeader();
            this.colChildBalance = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnClose.Location = new System.Drawing.Point(667, 345);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(80, 25);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnEdit.Location = new System.Drawing.Point(667, 104);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(80, 25);
            this.btnEdit.TabIndex = 20;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Vender Code";
            // 
            // btnGetData
            // 
            this.btnGetData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetData.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnGetData.Location = new System.Drawing.Point(542, 40);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(89, 27);
            this.btnGetData.TabIndex = 17;
            this.btnGetData.Text = "Get Data";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.btnGetData_Click);
            // 
            // colIsactive
            // 
            this.colIsactive.DisplayIndex = 6;
            this.colIsactive.Text = "Is Active";
            this.colIsactive.Width = 120;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnAdd.Location = new System.Drawing.Point(667, 73);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(80, 25);
            this.btnAdd.TabIndex = 19;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(90, 18);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(178, 20);
            this.txtCode.TabIndex = 12;
            this.txtCode.TextChanged += new System.EventHandler(this.txtCode_TextChanged);
            // 
            // colRemarks
            // 
            this.colRemarks.DisplayIndex = 5;
            this.colRemarks.Text = "Remarks";
            this.colRemarks.Width = 96;
            // 
            // colVenderCode
            // 
            this.colVenderCode.Text = "Vender Code";
            this.colVenderCode.Width = 84;
            // 
            // Name
            // 
            this.Name.AutoSize = true;
            this.Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name.Location = new System.Drawing.Point(12, 47);
            this.Name.Name = "Name";
            this.Name.Size = new System.Drawing.Size(72, 13);
            this.Name.TabIndex = 15;
            this.Name.Text = "Vender Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(90, 44);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(446, 20);
            this.txtName.TabIndex = 16;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // colAddress
            // 
            this.colAddress.Text = "Address";
            this.colAddress.Width = 139;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(281, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Contact No";
            // 
            // colVenderName
            // 
            this.colVenderName.Text = "Vender Name";
            this.colVenderName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colVenderName.Width = 141;
            // 
            // txtContactNo
            // 
            this.txtContactNo.Location = new System.Drawing.Point(347, 18);
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(189, 20);
            this.txtContactNo.TabIndex = 14;
            this.txtContactNo.TextChanged += new System.EventHandler(this.txtContactNo_TextChanged);
            // 
            // colContactPerson
            // 
            this.colContactPerson.Text = "Contact Person";
            this.colContactPerson.Width = 113;
            // 
            // lvwExchangeOfferVenders
            // 
            this.lvwExchangeOfferVenders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwExchangeOfferVenders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colVenderCode,
            this.colVenderName,
            this.colContactPerson,
            this.colContactNo,
            this.colAddress,
            this.colEmail,
            this.colParentBalance,
            this.colChildBalance,
            this.colRemarks,
            this.colIsactive});
            this.lvwExchangeOfferVenders.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lvwExchangeOfferVenders.FullRowSelect = true;
            this.lvwExchangeOfferVenders.GridLines = true;
            this.lvwExchangeOfferVenders.HideSelection = false;
            this.lvwExchangeOfferVenders.Location = new System.Drawing.Point(12, 73);
            this.lvwExchangeOfferVenders.MultiSelect = false;
            this.lvwExchangeOfferVenders.Name = "lvwExchangeOfferVenders";
            this.lvwExchangeOfferVenders.Size = new System.Drawing.Size(649, 297);
            this.lvwExchangeOfferVenders.TabIndex = 18;
            this.lvwExchangeOfferVenders.UseCompatibleStateImageBehavior = false;
            this.lvwExchangeOfferVenders.View = System.Windows.Forms.View.Details;
            this.lvwExchangeOfferVenders.DoubleClick += new System.EventHandler(this.lvwExchangeOfferVenders_DoubleClick);
            // 
            // colContactNo
            // 
            this.colContactNo.Text = "Contact No";
            this.colContactNo.Width = 97;
            // 
            // colEmail
            // 
            this.colEmail.Text = "Email";
            // 
            // colParentBalance
            // 
            this.colParentBalance.Text = "Parent Vender Balance";
            // 
            // colChildBalance
            // 
            this.colChildBalance.Text = "Child Venders Balance";
            // 
            // frmExchangeOfferVenderParnets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 382);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGetData);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.Name);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtContactNo);
            this.Controls.Add(this.lvwExchangeOfferVenders);
            //this.Name = "frmExchangeOfferVenderParnets";
            this.Text = "frmExchangeOfferVenderParnets";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.ColumnHeader colIsactive;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.ColumnHeader colRemarks;
        private System.Windows.Forms.ColumnHeader colVenderCode;
        private System.Windows.Forms.Label Name;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ColumnHeader colAddress;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ColumnHeader colVenderName;
        private System.Windows.Forms.TextBox txtContactNo;
        private System.Windows.Forms.ColumnHeader colContactPerson;
        private System.Windows.Forms.ListView lvwExchangeOfferVenders;
        private System.Windows.Forms.ColumnHeader colContactNo;
        private System.Windows.Forms.ColumnHeader colEmail;
        private System.Windows.Forms.ColumnHeader colParentBalance;
        private System.Windows.Forms.ColumnHeader colChildBalance;
    }
}
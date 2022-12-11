namespace CJ.POS
{
    partial class frmConsumers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsumers));
            this.btEdit = new System.Windows.Forms.Button();
            this.lvwConsumers = new System.Windows.Forms.ListView();
            this.colCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNmae = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colContactNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colPhone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEmail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAddress = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSalesTye = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCustomerCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCustomerName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCustCode = new System.Windows.Forms.TextBox();
            this.txtConsumerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btGo = new System.Windows.Forms.Button();
            this.cmbSalesType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtContactNo = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnAddRetailConsumer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btEdit
            // 
            this.btEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btEdit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btEdit.Font = new System.Drawing.Font("Microsoft JhengHei", 9F);
            this.btEdit.Location = new System.Drawing.Point(939, 134);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(88, 29);
            this.btEdit.TabIndex = 11;
            this.btEdit.Text = "Edit";
            this.btEdit.UseVisualStyleBackColor = true;
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // lvwConsumers
            // 
            this.lvwConsumers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwConsumers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCode,
            this.colNmae,
            this.colContactNo,
            this.colPhone,
            this.colEmail,
            this.colAddress,
            this.colSalesTye,
            this.colCustomerCode,
            this.colCustomerName});
            this.lvwConsumers.Font = new System.Drawing.Font("Microsoft JhengHei", 9F);
            this.lvwConsumers.FullRowSelect = true;
            this.lvwConsumers.GridLines = true;
            this.lvwConsumers.HideSelection = false;
            this.lvwConsumers.Location = new System.Drawing.Point(12, 99);
            this.lvwConsumers.MultiSelect = false;
            this.lvwConsumers.Name = "lvwConsumers";
            this.lvwConsumers.Size = new System.Drawing.Size(921, 426);
            this.lvwConsumers.TabIndex = 9;
            this.lvwConsumers.UseCompatibleStateImageBehavior = false;
            this.lvwConsumers.View = System.Windows.Forms.View.Details;
            // 
            // colCode
            // 
            this.colCode.Text = "Consumer Code";
            this.colCode.Width = 120;
            // 
            // colNmae
            // 
            this.colNmae.Text = "Consumer Name";
            this.colNmae.Width = 159;
            // 
            // colContactNo
            // 
            this.colContactNo.Text = "Mobile#";
            this.colContactNo.Width = 127;
            // 
            // colPhone
            // 
            this.colPhone.Text = "Phone#";
            this.colPhone.Width = 122;
            // 
            // colEmail
            // 
            this.colEmail.Text = "Email";
            this.colEmail.Width = 160;
            // 
            // colAddress
            // 
            this.colAddress.Text = "Address";
            this.colAddress.Width = 210;
            // 
            // colSalesTye
            // 
            this.colSalesTye.Text = "SalesTye";
            this.colSalesTye.Width = 86;
            // 
            // colCustomerCode
            // 
            this.colCustomerCode.Text = "CustomerCode";
            this.colCustomerCode.Width = 102;
            // 
            // colCustomerName
            // 
            this.colCustomerName.Text = "CustomerName";
            this.colCustomerName.Width = 249;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft JhengHei", 9F);
            this.btnClose.Location = new System.Drawing.Point(939, 496);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 29);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei", 9F);
            this.label3.Location = new System.Drawing.Point(16, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Consumer Code";
            // 
            // txtCustCode
            // 
            this.txtCustCode.Font = new System.Drawing.Font("Microsoft JhengHei", 9F);
            this.txtCustCode.Location = new System.Drawing.Point(119, 12);
            this.txtCustCode.Name = "txtCustCode";
            this.txtCustCode.Size = new System.Drawing.Size(187, 23);
            this.txtCustCode.TabIndex = 1;
            // 
            // txtConsumerName
            // 
            this.txtConsumerName.Font = new System.Drawing.Font("Microsoft JhengHei", 9F);
            this.txtConsumerName.Location = new System.Drawing.Point(119, 70);
            this.txtConsumerName.Name = "txtConsumerName";
            this.txtConsumerName.Size = new System.Drawing.Size(439, 23);
            this.txtConsumerName.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei", 9F);
            this.label1.Location = new System.Drawing.Point(12, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Consumer Name";
            // 
            // btGo
            // 
            this.btGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btGo.Font = new System.Drawing.Font("Microsoft JhengHei", 9F);
            this.btGo.Location = new System.Drawing.Point(564, 64);
            this.btGo.Name = "btGo";
            this.btGo.Size = new System.Drawing.Size(88, 29);
            this.btGo.TabIndex = 8;
            this.btGo.Text = "Get Data";
            this.btGo.UseVisualStyleBackColor = true;
            this.btGo.Click += new System.EventHandler(this.btGo_Click);
            // 
            // cmbSalesType
            // 
            this.cmbSalesType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSalesType.Font = new System.Drawing.Font("Microsoft JhengHei", 9F);
            this.cmbSalesType.FormattingEnabled = true;
            this.cmbSalesType.Location = new System.Drawing.Point(381, 42);
            this.cmbSalesType.Name = "cmbSalesType";
            this.cmbSalesType.Size = new System.Drawing.Size(173, 24);
            this.cmbSalesType.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei", 9F);
            this.label4.Location = new System.Drawing.Point(309, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Sales Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei", 9F);
            this.label2.Location = new System.Drawing.Point(42, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Contact No";
            // 
            // txtContactNo
            // 
            this.txtContactNo.Font = new System.Drawing.Font("Microsoft JhengHei", 9F);
            this.txtContactNo.Location = new System.Drawing.Point(119, 41);
            this.txtContactNo.Name = "txtContactNo";
            this.txtContactNo.Size = new System.Drawing.Size(187, 23);
            this.txtContactNo.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Font = new System.Drawing.Font("Microsoft JhengHei", 9F);
            this.button1.Location = new System.Drawing.Point(939, 169);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 29);
            this.button1.TabIndex = 12;
            this.button1.Text = "Detail";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAddRetailConsumer
            // 
            this.btnAddRetailConsumer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRetailConsumer.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAddRetailConsumer.Font = new System.Drawing.Font("Microsoft JhengHei", 9F);
            this.btnAddRetailConsumer.Location = new System.Drawing.Point(939, 99);
            this.btnAddRetailConsumer.Name = "btnAddRetailConsumer";
            this.btnAddRetailConsumer.Size = new System.Drawing.Size(88, 29);
            this.btnAddRetailConsumer.TabIndex = 10;
            this.btnAddRetailConsumer.Text = "Add";
            this.btnAddRetailConsumer.UseVisualStyleBackColor = true;
            this.btnAddRetailConsumer.Click += new System.EventHandler(this.btnAddRetailConsumer_Click);
            // 
            // frmConsumers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 537);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtContactNo);
            this.Controls.Add(this.cmbSalesType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btGo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCustCode);
            this.Controls.Add(this.txtConsumerName);
            this.Controls.Add(this.btnAddRetailConsumer);
            this.Controls.Add(this.btEdit);
            this.Controls.Add(this.lvwConsumers);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmConsumers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reatil Consumers";
            this.Load += new System.EventHandler(this.frmConsumers_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btEdit;
        private System.Windows.Forms.ListView lvwConsumers;
        private System.Windows.Forms.ColumnHeader colCode;
        private System.Windows.Forms.ColumnHeader colNmae;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColumnHeader colContactNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCustCode;
        private System.Windows.Forms.TextBox txtConsumerName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btGo;
        private System.Windows.Forms.ComboBox cmbSalesType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtContactNo;
        private System.Windows.Forms.ColumnHeader colAddress;
        private System.Windows.Forms.ColumnHeader colCustomerCode;
        private System.Windows.Forms.ColumnHeader colSalesTye;
        private System.Windows.Forms.ColumnHeader colCustomerName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnAddRetailConsumer;
        private System.Windows.Forms.ColumnHeader colPhone;
        private System.Windows.Forms.ColumnHeader colEmail;
    }
}
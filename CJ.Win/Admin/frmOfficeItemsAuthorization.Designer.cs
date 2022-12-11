namespace CJ.Win.Admin
{
    partial class frmOfficeItemsAuthorization
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOfficeItemsAuthorization));
            this.dgvStationaryItem = new System.Windows.Forms.DataGridView();
            this.txtProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFindProduct = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtArticleDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtAuthorizeQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblEmployeeName = new System.Windows.Forms.Label();
            this.lblEmployee = new System.Windows.Forms.Label();
            this.lblcompany = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblTranType = new System.Windows.Forms.Label();
            this.lblTran = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblShowroom = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnRejected = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtReqQty = new System.Windows.Forms.TextBox();
            this.txtAuthQty = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStationaryItem)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvStationaryItem
            // 
            this.dgvStationaryItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStationaryItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtProductCode,
            this.btnFindProduct,
            this.txtArticleDetails,
            this.txtQuantity,
            this.txtAuthorizeQty,
            this.ColProductID});
            this.dgvStationaryItem.Location = new System.Drawing.Point(12, 63);
            this.dgvStationaryItem.Name = "dgvStationaryItem";
            this.dgvStationaryItem.Size = new System.Drawing.Size(740, 160);
            this.dgvStationaryItem.TabIndex = 0;
            this.dgvStationaryItem.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStationaryItem_CellValueChanged);
            this.dgvStationaryItem.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvStationaryItem_RowsRemoved);
            this.dgvStationaryItem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStationaryItem_CellContentClick);
            // 
            // txtProductCode
            // 
            this.txtProductCode.HeaderText = "Code";
            this.txtProductCode.Name = "txtProductCode";
            this.txtProductCode.Width = 80;
            // 
            // btnFindProduct
            // 
            this.btnFindProduct.HeaderText = "?";
            this.btnFindProduct.Name = "btnFindProduct";
            this.btnFindProduct.Width = 35;
            // 
            // txtArticleDetails
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtArticleDetails.DefaultCellStyle = dataGridViewCellStyle1;
            this.txtArticleDetails.HeaderText = "Article Details";
            this.txtArticleDetails.Name = "txtArticleDetails";
            this.txtArticleDetails.ReadOnly = true;
            this.txtArticleDetails.Width = 240;
            // 
            // txtQuantity
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtQuantity.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtQuantity.HeaderText = "ReqQty";
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.ReadOnly = true;
            this.txtQuantity.Width = 80;
            // 
            // txtAuthorizeQty
            // 
            this.txtAuthorizeQty.HeaderText = "AuthorizeQty";
            this.txtAuthorizeQty.Name = "txtAuthorizeQty";
            // 
            // ColProductID
            // 
            this.ColProductID.HeaderText = "ArticleID";
            this.ColProductID.Name = "ColProductID";
            this.ColProductID.ReadOnly = true;
            this.ColProductID.Visible = false;
            // 
            // lblEmployeeName
            // 
            this.lblEmployeeName.AutoSize = true;
            this.lblEmployeeName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployeeName.Location = new System.Drawing.Point(365, 10);
            this.lblEmployeeName.Name = "lblEmployeeName";
            this.lblEmployeeName.Size = new System.Drawing.Size(16, 13);
            this.lblEmployeeName.TabIndex = 9;
            this.lblEmployeeName.Text = "? ";
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployee.Location = new System.Drawing.Point(267, 10);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(102, 13);
            this.lblEmployee.TabIndex = 8;
            this.lblEmployee.Text = "Empoyee Name: ";
            // 
            // lblcompany
            // 
            this.lblcompany.AutoSize = true;
            this.lblcompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcompany.Location = new System.Drawing.Point(82, 10);
            this.lblcompany.Name = "lblcompany";
            this.lblcompany.Size = new System.Drawing.Size(13, 13);
            this.lblcompany.TabIndex = 5;
            this.lblcompany.Text = "?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Company: ";
            // 
            // lblTranType
            // 
            this.lblTranType.AutoSize = true;
            this.lblTranType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTranType.Location = new System.Drawing.Point(81, 36);
            this.lblTranType.Name = "lblTranType";
            this.lblTranType.Size = new System.Drawing.Size(13, 13);
            this.lblTranType.TabIndex = 7;
            this.lblTranType.Text = "?";
            // 
            // lblTran
            // 
            this.lblTran.AutoSize = true;
            this.lblTran.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTran.Location = new System.Drawing.Point(14, 36);
            this.lblTran.Name = "lblTran";
            this.lblTran.Size = new System.Drawing.Size(73, 13);
            this.lblTran.TabIndex = 6;
            this.lblTran.Text = "Tran Type: ";
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartment.Location = new System.Drawing.Point(364, 36);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(16, 13);
            this.lblDepartment.TabIndex = 11;
            this.lblDepartment.Text = "? ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(289, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Department: ";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(596, 10);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(16, 13);
            this.lblStatus.TabIndex = 13;
            this.lblStatus.Text = "? ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(550, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Status: ";
            // 
            // lblShowroom
            // 
            this.lblShowroom.AutoSize = true;
            this.lblShowroom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShowroom.Location = new System.Drawing.Point(595, 36);
            this.lblShowroom.Name = "lblShowroom";
            this.lblShowroom.Size = new System.Drawing.Size(13, 13);
            this.lblShowroom.TabIndex = 15;
            this.lblShowroom.Text = "?";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(497, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "From Showroom: ";
            // 
            // btnApprove
            // 
            this.btnApprove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApprove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnApprove.Location = new System.Drawing.Point(596, 236);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(75, 23);
            this.btnApprove.TabIndex = 1;
            this.btnApprove.Text = "Approve";
            this.btnApprove.UseVisualStyleBackColor = true;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnRejected
            // 
            this.btnRejected.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRejected.ForeColor = System.Drawing.Color.Red;
            this.btnRejected.Location = new System.Drawing.Point(11, 236);
            this.btnRejected.Name = "btnRejected";
            this.btnRejected.Size = new System.Drawing.Size(75, 23);
            this.btnRejected.TabIndex = 3;
            this.btnRejected.Text = "Rejected";
            this.btnRejected.UseVisualStyleBackColor = true;
            this.btnRejected.Click += new System.EventHandler(this.btnRejected_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.ForeColor = System.Drawing.Color.Black;
            this.btnClose.Location = new System.Drawing.Point(677, 237);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtReqQty
            // 
            this.txtReqQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtReqQty.Location = new System.Drawing.Point(409, 238);
            this.txtReqQty.Name = "txtReqQty";
            this.txtReqQty.ReadOnly = true;
            this.txtReqQty.Size = new System.Drawing.Size(84, 20);
            this.txtReqQty.TabIndex = 147;
            this.txtReqQty.Text = "0";
            this.txtReqQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtAuthQty
            // 
            this.txtAuthQty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtAuthQty.Location = new System.Drawing.Point(493, 238);
            this.txtAuthQty.Name = "txtAuthQty";
            this.txtAuthQty.ReadOnly = true;
            this.txtAuthQty.Size = new System.Drawing.Size(91, 20);
            this.txtAuthQty.TabIndex = 145;
            this.txtAuthQty.Text = "0";
            this.txtAuthQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // frmOfficeItemsAuthorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(764, 270);
            this.Controls.Add(this.txtReqQty);
            this.Controls.Add(this.txtAuthQty);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRejected);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.lblShowroom);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lblDepartment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblEmployeeName);
            this.Controls.Add(this.lblEmployee);
            this.Controls.Add(this.lblcompany);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblTranType);
            this.Controls.Add(this.lblTran);
            this.Controls.Add(this.dgvStationaryItem);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmOfficeItemsAuthorization";
            this.Text = "frmOfficeItemsAuthorization";
            this.Load += new System.EventHandler(this.frmOfficeItemsAuthorization_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStationaryItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvStationaryItem;
        private System.Windows.Forms.Label lblEmployeeName;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.Label lblcompany;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTranType;
        private System.Windows.Forms.Label lblTran;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblShowroom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnRejected;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtReqQty;
        private System.Windows.Forms.TextBox txtAuthQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductCode;
        private System.Windows.Forms.DataGridViewButtonColumn btnFindProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtArticleDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtAuthorizeQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProductID;
    }
}
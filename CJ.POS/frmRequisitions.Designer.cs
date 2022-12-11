namespace CJ.POS
{
    partial class frmRequisitions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRequisitions));
            this.label5 = new System.Windows.Forms.Label();
            this.txtRequisitionNo = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lvwOrderList = new System.Windows.Forms.ListView();
            this.colRequisitionNo = new System.Windows.Forms.ColumnHeader();
            this.colWH = new System.Windows.Forms.ColumnHeader();
            this.colDate = new System.Windows.Forms.ColumnHeader();
            this.colRS = new System.Windows.Forms.ColumnHeader();
            this.colTWH = new System.Windows.Forms.ColumnHeader();
            this.colRRemarks = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.btnEdit = new System.Windows.Forms.Button();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btGetData = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.btConfirm = new System.Windows.Forms.Button();
            this.btTransfer = new System.Windows.Forms.Button();
            this.btGoodsReceived = new System.Windows.Forms.Button();
            this.btRetrun = new System.Windows.Forms.Button();
            this.btPrint = new System.Windows.Forms.Button();
            this.btAuthorizePrint = new System.Windows.Forms.Button();
            this.btRCancel = new System.Windows.Forms.Button();
            this.btAuthorizeClancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Requisition No";
            // 
            // txtRequisitionNo
            // 
            this.txtRequisitionNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRequisitionNo.Location = new System.Drawing.Point(99, 29);
            this.txtRequisitionNo.Name = "txtRequisitionNo";
            this.txtRequisitionNo.Size = new System.Drawing.Size(168, 20);
            this.txtRequisitionNo.TabIndex = 5;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(744, 58);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(131, 27);
            this.btnAdd.TabIndex = 20;
            this.btnAdd.Text = "Add ";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lvwOrderList
            // 
            this.lvwOrderList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwOrderList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRequisitionNo,
            this.colWH,
            this.colDate,
            this.colRS,
            this.colTWH,
            this.colRRemarks});
            this.lvwOrderList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwOrderList.FullRowSelect = true;
            this.lvwOrderList.GridLines = true;
            this.lvwOrderList.HideSelection = false;
            this.lvwOrderList.Location = new System.Drawing.Point(7, 58);
            this.lvwOrderList.MultiSelect = false;
            this.lvwOrderList.Name = "lvwOrderList";
            this.lvwOrderList.Size = new System.Drawing.Size(731, 392);
            this.lvwOrderList.TabIndex = 9;
            this.lvwOrderList.UseCompatibleStateImageBehavior = false;
            this.lvwOrderList.View = System.Windows.Forms.View.Details;
            this.lvwOrderList.SelectedIndexChanged += new System.EventHandler(this.lvwOrderList_SelectedIndexChanged);
            // 
            // colRequisitionNo
            // 
            this.colRequisitionNo.Text = "Requisition No";
            this.colRequisitionNo.Width = 150;
            // 
            // colWH
            // 
            this.colWH.Text = "Outlet/Branch Name";
            this.colWH.Width = 200;
            // 
            // colDate
            // 
            this.colDate.Text = "Requisition Date";
            this.colDate.Width = 120;
            // 
            // colRS
            // 
            this.colRS.Text = "Status";
            this.colRS.Width = 120;
            // 
            // colTWH
            // 
            this.colTWH.Text = "HO/Branch Name";
            this.colTWH.Width = 200;
            // 
            // colRRemarks
            // 
            this.colRRemarks.Text = "Remarks";
            this.colRRemarks.Width = 250;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(196, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "To";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(222, 4);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(144, 20);
            this.dtToDate.TabIndex = 3;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(744, 90);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(131, 27);
            this.btnEdit.TabIndex = 11;
            this.btnEdit.Tag = "M1.15";
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(46, 3);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(144, 20);
            this.dtFromDate.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(9, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "From";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(744, 423);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(131, 27);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(395, 30);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(167, 21);
            this.cmbStatus.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(282, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Requisition Status";
            // 
            // btGetData
            // 
            this.btGetData.Location = new System.Drawing.Point(568, 29);
            this.btGetData.Name = "btGetData";
            this.btGetData.Size = new System.Drawing.Size(75, 23);
            this.btGetData.TabIndex = 8;
            this.btGetData.Text = "Get Data";
            this.btGetData.UseVisualStyleBackColor = true;
            this.btGetData.Click += new System.EventHandler(this.btGetData_Click);
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDelete.Location = new System.Drawing.Point(744, 123);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(131, 27);
            this.btDelete.TabIndex = 13;
            this.btDelete.Tag = "M1.15";
            this.btDelete.Text = "Delete";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btConfirm
            // 
            this.btConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btConfirm.Location = new System.Drawing.Point(744, 58);
            this.btConfirm.Name = "btConfirm";
            this.btConfirm.Size = new System.Drawing.Size(131, 44);
            this.btConfirm.TabIndex = 19;
            this.btConfirm.Tag = "M1.15";
            this.btConfirm.Text = "Requisition Authorize";
            this.btConfirm.UseVisualStyleBackColor = true;
            this.btConfirm.Visible = false;
            this.btConfirm.Click += new System.EventHandler(this.btConfirm_Click);
            // 
            // btTransfer
            // 
            this.btTransfer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btTransfer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btTransfer.Location = new System.Drawing.Point(744, 58);
            this.btTransfer.Name = "btTransfer";
            this.btTransfer.Size = new System.Drawing.Size(131, 44);
            this.btTransfer.TabIndex = 18;
            this.btTransfer.Tag = "M1.15";
            this.btTransfer.Text = "Goods Transfer";
            this.btTransfer.UseVisualStyleBackColor = true;
            this.btTransfer.Visible = false;
            this.btTransfer.Click += new System.EventHandler(this.btTransfer_Click);
            // 
            // btGoodsReceived
            // 
            this.btGoodsReceived.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btGoodsReceived.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btGoodsReceived.Location = new System.Drawing.Point(744, 58);
            this.btGoodsReceived.Name = "btGoodsReceived";
            this.btGoodsReceived.Size = new System.Drawing.Size(131, 44);
            this.btGoodsReceived.TabIndex = 10;
            this.btGoodsReceived.Tag = "M1.15";
            this.btGoodsReceived.Text = "Goods Received";
            this.btGoodsReceived.UseVisualStyleBackColor = true;
            this.btGoodsReceived.Visible = false;
            this.btGoodsReceived.Click += new System.EventHandler(this.btGoodsReceived_Click);
            // 
            // btRetrun
            // 
            this.btRetrun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRetrun.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRetrun.Location = new System.Drawing.Point(744, 58);
            this.btRetrun.Name = "btRetrun";
            this.btRetrun.Size = new System.Drawing.Size(131, 44);
            this.btRetrun.TabIndex = 9;
            this.btRetrun.Tag = "M1.58";
            this.btRetrun.Text = "Goods Retrun";
            this.btRetrun.UseVisualStyleBackColor = true;
            this.btRetrun.Click += new System.EventHandler(this.btRetrun_Click);
            // 
            // btPrint
            // 
            this.btPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPrint.Location = new System.Drawing.Point(744, 155);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(131, 27);
            this.btPrint.TabIndex = 15;
            this.btPrint.Tag = "M1.15";
            this.btPrint.Text = "Print ";
            this.btPrint.UseVisualStyleBackColor = true;
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // btAuthorizePrint
            // 
            this.btAuthorizePrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAuthorizePrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAuthorizePrint.Location = new System.Drawing.Point(744, 199);
            this.btAuthorizePrint.Name = "btAuthorizePrint";
            this.btAuthorizePrint.Size = new System.Drawing.Size(131, 27);
            this.btAuthorizePrint.TabIndex = 16;
            this.btAuthorizePrint.Tag = "M1.15";
            this.btAuthorizePrint.Text = "Print ";
            this.btAuthorizePrint.UseVisualStyleBackColor = true;
            this.btAuthorizePrint.Click += new System.EventHandler(this.btAuthorizePrint_Click);
            // 
            // btRCancel
            // 
            this.btRCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btRCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btRCancel.Location = new System.Drawing.Point(744, 106);
            this.btRCancel.Name = "btRCancel";
            this.btRCancel.Size = new System.Drawing.Size(131, 44);
            this.btRCancel.TabIndex = 12;
            this.btRCancel.Tag = "M1.58";
            this.btRCancel.Text = "Requisition Cancel";
            this.btRCancel.UseVisualStyleBackColor = true;
            this.btRCancel.Click += new System.EventHandler(this.btRCancel_Click);
            // 
            // btAuthorizeClancel
            // 
            this.btAuthorizeClancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAuthorizeClancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAuthorizeClancel.Location = new System.Drawing.Point(744, 152);
            this.btAuthorizeClancel.Name = "btAuthorizeClancel";
            this.btAuthorizeClancel.Size = new System.Drawing.Size(131, 44);
            this.btAuthorizeClancel.TabIndex = 14;
            this.btAuthorizeClancel.Tag = "M1.58";
            this.btAuthorizeClancel.Text = " Cancel Authorization";
            this.btAuthorizeClancel.UseVisualStyleBackColor = true;
            this.btAuthorizeClancel.Click += new System.EventHandler(this.btAuthorizeClancel_Click);
            // 
            // frmRequisitions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 454);
            this.Controls.Add(this.btAuthorizeClancel);
            this.Controls.Add(this.btRCancel);
            this.Controls.Add(this.btAuthorizePrint);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.btRetrun);
            this.Controls.Add(this.btGoodsReceived);
            this.Controls.Add(this.btTransfer);
            this.Controls.Add(this.btConfirm);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btGetData);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRequisitionNo);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lvwOrderList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmRequisitions";
            this.Load += new System.EventHandler(this.frmRequisitions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRequisitionNo;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView lvwOrderList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ColumnHeader colRequisitionNo;
        private System.Windows.Forms.Button btGetData;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btConfirm;
        private System.Windows.Forms.Button btTransfer;
        private System.Windows.Forms.Button btGoodsReceived;
        private System.Windows.Forms.Button btRetrun;
        private System.Windows.Forms.Button btPrint;
        private System.Windows.Forms.Button btAuthorizePrint;
        private System.Windows.Forms.ColumnHeader colWH;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colRS;
        private System.Windows.Forms.ColumnHeader colTWH;
        private System.Windows.Forms.Button btRCancel;
        private System.Windows.Forms.ColumnHeader colRRemarks;
        private System.Windows.Forms.Button btAuthorizeClancel;
    }
}
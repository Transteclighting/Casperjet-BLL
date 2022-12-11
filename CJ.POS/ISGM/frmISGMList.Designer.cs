namespace CJ.POS.ISGM
{
    partial class frmISGMList
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
            this.btGetData = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtISGMNo = new System.Windows.Forms.TextBox();
            this.colISGMNo = new System.Windows.Forms.ColumnHeader();
            this.lvwOrderList = new System.Windows.Forms.ListView();
            this.colISGMDate = new System.Windows.Forms.ColumnHeader();
            this.colFromWH = new System.Windows.Forms.ColumnHeader();
            this.colToWH = new System.Windows.Forms.ColumnHeader();
            this.colStatus = new System.Windows.Forms.ColumnHeader();
            this.colTransferstatus = new System.Windows.Forms.ColumnHeader();
            this.colRemarks = new System.Windows.Forms.ColumnHeader();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.btEdit = new System.Windows.Forms.Button();
            this.btDelete = new System.Windows.Forms.Button();
            this.btSynch = new System.Windows.Forms.Button();
            this.btAuthorize = new System.Windows.Forms.Button();
            this.btAuthorizeCancel = new System.Windows.Forms.Button();
            this.btPrint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btGetData
            // 
            this.btGetData.Location = new System.Drawing.Point(563, 28);
            this.btGetData.Name = "btGetData";
            this.btGetData.Size = new System.Drawing.Size(75, 23);
            this.btGetData.TabIndex = 8;
            this.btGetData.Text = "Get Data";
            this.btGetData.UseVisualStyleBackColor = true;
            this.btGetData.Click += new System.EventHandler(this.btGetData_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(309, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "ISGM Status";
            // 
            // cmbStatus
            // 
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Location = new System.Drawing.Point(390, 29);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(167, 21);
            this.cmbStatus.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(33, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "ISGM No";
            // 
            // txtISGMNo
            // 
            this.txtISGMNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtISGMNo.Location = new System.Drawing.Point(94, 28);
            this.txtISGMNo.Name = "txtISGMNo";
            this.txtISGMNo.Size = new System.Drawing.Size(168, 20);
            this.txtISGMNo.TabIndex = 5;
            // 
            // colISGMNo
            // 
            this.colISGMNo.Text = "ISGM No";
            this.colISGMNo.Width = 150;
            // 
            // lvwOrderList
            // 
            this.lvwOrderList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwOrderList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colISGMNo,
            this.colISGMDate,
            this.colFromWH,
            this.colToWH,
            this.colStatus,
            this.colTransferstatus,
            this.colRemarks});
            this.lvwOrderList.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwOrderList.FullRowSelect = true;
            this.lvwOrderList.GridLines = true;
            this.lvwOrderList.HideSelection = false;
            this.lvwOrderList.Location = new System.Drawing.Point(3, 57);
            this.lvwOrderList.MultiSelect = false;
            this.lvwOrderList.Name = "lvwOrderList";
            this.lvwOrderList.Size = new System.Drawing.Size(711, 406);
            this.lvwOrderList.TabIndex = 9;
            this.lvwOrderList.UseCompatibleStateImageBehavior = false;
            this.lvwOrderList.View = System.Windows.Forms.View.Details;
            // 
            // colISGMDate
            // 
            this.colISGMDate.Text = "ISGM Date";
            this.colISGMDate.Width = 90;
            // 
            // colFromWH
            // 
            this.colFromWH.Text = "From Outlet/Branch";
            this.colFromWH.Width = 200;
            // 
            // colToWH
            // 
            this.colToWH.Text = "To Outlet/Branch";
            this.colToWH.Width = 200;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 100;
            // 
            // colTransferstatus
            // 
            this.colTransferstatus.DisplayIndex = 6;
            this.colTransferstatus.Text = "Transfer Status";
            this.colTransferstatus.Width = 180;
            // 
            // colRemarks
            // 
            this.colRemarks.DisplayIndex = 5;
            this.colRemarks.Text = "Remarks";
            this.colRemarks.Width = 200;
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(217, 3);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(144, 20);
            this.dtToDate.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(191, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "To";
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(41, 2);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(144, 20);
            this.dtFromDate.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(4, 5);
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
            this.btnClose.Location = new System.Drawing.Point(719, 436);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(131, 27);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btAdd
            // 
            this.btAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAdd.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAdd.Location = new System.Drawing.Point(719, 57);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(131, 27);
            this.btAdd.TabIndex = 11;
            this.btAdd.Text = "Add";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btEdit
            // 
            this.btEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btEdit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btEdit.Location = new System.Drawing.Point(720, 90);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(131, 27);
            this.btEdit.TabIndex = 12;
            this.btEdit.Text = "Edit";
            this.btEdit.UseVisualStyleBackColor = true;
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // btDelete
            // 
            this.btDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btDelete.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btDelete.Location = new System.Drawing.Point(720, 123);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(131, 27);
            this.btDelete.TabIndex = 14;
            this.btDelete.Text = "Delete";
            this.btDelete.UseVisualStyleBackColor = true;
            this.btDelete.Click += new System.EventHandler(this.btDelete_Click);
            // 
            // btSynch
            // 
            this.btSynch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btSynch.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btSynch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSynch.Location = new System.Drawing.Point(720, 156);
            this.btSynch.Name = "btSynch";
            this.btSynch.Size = new System.Drawing.Size(131, 27);
            this.btSynch.TabIndex = 17;
            this.btSynch.Text = "Synchronize";
            this.btSynch.UseVisualStyleBackColor = true;
            this.btSynch.Click += new System.EventHandler(this.btSynch_Click);
            // 
            // btAuthorize
            // 
            this.btAuthorize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAuthorize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAuthorize.Location = new System.Drawing.Point(719, 56);
            this.btAuthorize.Name = "btAuthorize";
            this.btAuthorize.Size = new System.Drawing.Size(131, 44);
            this.btAuthorize.TabIndex = 10;
            this.btAuthorize.Tag = "M1.58";
            this.btAuthorize.Text = "Authorize";
            this.btAuthorize.UseVisualStyleBackColor = true;
            this.btAuthorize.Click += new System.EventHandler(this.btAuthorize_Click);
            // 
            // btAuthorizeCancel
            // 
            this.btAuthorizeCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btAuthorizeCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btAuthorizeCancel.Location = new System.Drawing.Point(720, 104);
            this.btAuthorizeCancel.Name = "btAuthorizeCancel";
            this.btAuthorizeCancel.Size = new System.Drawing.Size(131, 44);
            this.btAuthorizeCancel.TabIndex = 13;
            this.btAuthorizeCancel.Tag = "M1.58";
            this.btAuthorizeCancel.Text = "Authorize Cancel";
            this.btAuthorizeCancel.UseVisualStyleBackColor = true;
            this.btAuthorizeCancel.Click += new System.EventHandler(this.btAuthorizeCancel_Click);
            // 
            // btPrint
            // 
            this.btPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPrint.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btPrint.Location = new System.Drawing.Point(720, 156);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(131, 27);
            this.btPrint.TabIndex = 15;
            this.btPrint.Text = "Print";
            this.btPrint.UseVisualStyleBackColor = true;
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // frmISGMList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 464);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.btAuthorizeCancel);
            this.Controls.Add(this.btAuthorize);
            this.Controls.Add(this.btSynch);
            this.Controls.Add(this.btDelete);
            this.Controls.Add(this.btEdit);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.btGetData);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtISGMNo);
            this.Controls.Add(this.lvwOrderList);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnClose);
            this.Name = "frmISGMList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Good Transfer List";
            this.Load += new System.EventHandler(this.frmISGMList_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btGetData;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbStatus;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtISGMNo;
        private System.Windows.Forms.ColumnHeader colISGMNo;
        private System.Windows.Forms.ListView lvwOrderList;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColumnHeader colISGMDate;
        private System.Windows.Forms.ColumnHeader colFromWH;
        private System.Windows.Forms.ColumnHeader colToWH;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ColumnHeader colRemarks;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btEdit;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.Button btSynch;
        private System.Windows.Forms.ColumnHeader colTransferstatus;
        private System.Windows.Forms.Button btAuthorize;
        private System.Windows.Forms.Button btAuthorizeCancel;
        private System.Windows.Forms.Button btPrint;
    }
}
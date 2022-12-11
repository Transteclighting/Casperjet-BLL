namespace CJ.Win.Admin
{
    partial class frmVehicleMaintenanceAdmin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVehicleMaintenanceAdmin));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtInvoiceAmount = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.btVichel = new System.Windows.Forms.Button();
            this.txtRegNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtKmRun = new System.Windows.Forms.TextBox();
            this.ckbActive = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.txtEndReading = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTripU = new System.Windows.Forms.TextBox();
            this.txtTripS = new System.Windows.Forms.TextBox();
            this.txtTripC = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVehicleCode = new System.Windows.Forms.TextBox();
            this.txtVehicleDetails = new System.Windows.Forms.TextBox();
            this.dgvExpanseAdmin = new System.Windows.Forms.DataGridView();
            this.LblRemarks = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.txtExpAmount = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.aSPNETDBDataSet = new CJ.Win.ASPNETDBDataSet();
            this.aSPNETDBDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FuelType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CashQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CashAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreditQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreditAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ExpenseTypeID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpanseAdmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aSPNETDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aSPNETDBDataSetBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtInvoiceAmount);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.btVichel);
            this.groupBox2.Controls.Add(this.txtRegNo);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtKmRun);
            this.groupBox2.Controls.Add(this.ckbActive);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.txtEndReading);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtTripU);
            this.groupBox2.Controls.Add(this.txtTripS);
            this.groupBox2.Controls.Add(this.txtTripC);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtVehicleCode);
            this.groupBox2.Controls.Add(this.txtVehicleDetails);
            this.groupBox2.Location = new System.Drawing.Point(12, 13);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(700, 177);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Vehicle Details";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(454, 115);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 16);
            this.label12.TabIndex = 17;
            this.label12.Text = "Invoice Amount";
            // 
            // txtInvoiceAmount
            // 
            this.txtInvoiceAmount.Location = new System.Drawing.Point(554, 111);
            this.txtInvoiceAmount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtInvoiceAmount.Name = "txtInvoiceAmount";
            this.txtInvoiceAmount.Size = new System.Drawing.Size(132, 23);
            this.txtInvoiceAmount.TabIndex = 18;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(263, 52);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 16);
            this.label11.TabIndex = 5;
            this.label11.Text = "Reg. No";
            // 
            // btVichel
            // 
            this.btVichel.Location = new System.Drawing.Point(232, 20);
            this.btVichel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btVichel.Name = "btVichel";
            this.btVichel.Size = new System.Drawing.Size(37, 25);
            this.btVichel.TabIndex = 2;
            this.btVichel.Text = "...";
            this.btVichel.UseVisualStyleBackColor = true;
            this.btVichel.Click += new System.EventHandler(this.btVichel_Click);
            // 
            // txtRegNo
            // 
            this.txtRegNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegNo.Location = new System.Drawing.Point(323, 49);
            this.txtRegNo.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRegNo.Name = "txtRegNo";
            this.txtRegNo.Size = new System.Drawing.Size(363, 21);
            this.txtRegNo.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(275, 23);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 16);
            this.label9.TabIndex = 3;
            this.label9.Text = "Name";
            // 
            // txtKmRun
            // 
            this.txtKmRun.Location = new System.Drawing.Point(323, 109);
            this.txtKmRun.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtKmRun.Name = "txtKmRun";
            this.txtKmRun.Size = new System.Drawing.Size(128, 23);
            this.txtKmRun.TabIndex = 16;
            // 
            // ckbActive
            // 
            this.ckbActive.AutoSize = true;
            this.ckbActive.Location = new System.Drawing.Point(323, 140);
            this.ckbActive.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ckbActive.Name = "ckbActive";
            this.ckbActive.Size = new System.Drawing.Size(100, 20);
            this.ckbActive.TabIndex = 21;
            this.ckbActive.Text = "Active Today";
            this.ckbActive.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "Date";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(266, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "KM Run";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(101, 142);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(129, 23);
            this.dateTimePicker1.TabIndex = 20;
            // 
            // txtEndReading
            // 
            this.txtEndReading.Location = new System.Drawing.Point(101, 111);
            this.txtEndReading.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtEndReading.Name = "txtEndReading";
            this.txtEndReading.Size = new System.Drawing.Size(128, 23);
            this.txtEndReading.TabIndex = 14;
            this.txtEndReading.TextChanged += new System.EventHandler(this.txtEndReading_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "End Reading";
            // 
            // txtTripU
            // 
            this.txtTripU.Location = new System.Drawing.Point(554, 74);
            this.txtTripU.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTripU.Name = "txtTripU";
            this.txtTripU.Size = new System.Drawing.Size(132, 23);
            this.txtTripU.TabIndex = 12;
            // 
            // txtTripS
            // 
            this.txtTripS.Location = new System.Drawing.Point(323, 78);
            this.txtTripS.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTripS.Name = "txtTripS";
            this.txtTripS.Size = new System.Drawing.Size(128, 23);
            this.txtTripS.TabIndex = 10;
            // 
            // txtTripC
            // 
            this.txtTripC.Location = new System.Drawing.Point(101, 78);
            this.txtTripC.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTripC.Name = "txtTripC";
            this.txtTripC.Size = new System.Drawing.Size(128, 23);
            this.txtTripC.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(507, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 16);
            this.label5.TabIndex = 11;
            this.label5.Text = "Trip U";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(278, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Trip S";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Trip C";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Vehicle Code";
            // 
            // txtVehicleCode
            // 
            this.txtVehicleCode.Location = new System.Drawing.Point(101, 21);
            this.txtVehicleCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtVehicleCode.Name = "txtVehicleCode";
            this.txtVehicleCode.Size = new System.Drawing.Size(128, 23);
            this.txtVehicleCode.TabIndex = 1;
            this.txtVehicleCode.TextChanged += new System.EventHandler(this.txtVehicleCode_TextChanged);
            // 
            // txtVehicleDetails
            // 
            this.txtVehicleDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVehicleDetails.Location = new System.Drawing.Point(323, 20);
            this.txtVehicleDetails.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtVehicleDetails.Name = "txtVehicleDetails";
            this.txtVehicleDetails.Size = new System.Drawing.Size(363, 21);
            this.txtVehicleDetails.TabIndex = 4;
            // 
            // dgvExpanseAdmin
            // 
            this.dgvExpanseAdmin.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvExpanseAdmin.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FuelType,
            this.UnitPrice,
            this.CashQty,
            this.CashAmount,
            this.CreditQty,
            this.CreditAmount,
            this.ExpenseTypeID});
            this.dgvExpanseAdmin.Location = new System.Drawing.Point(12, 212);
            this.dgvExpanseAdmin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvExpanseAdmin.Name = "dgvExpanseAdmin";
            this.dgvExpanseAdmin.Size = new System.Drawing.Size(700, 279);
            this.dgvExpanseAdmin.TabIndex = 1;
            this.dgvExpanseAdmin.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExpanseAdmin_CellContentClick);
            this.dgvExpanseAdmin.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvExpanseAdmin_CellValueChanged);
            // 
            // LblRemarks
            // 
            this.LblRemarks.AutoSize = true;
            this.LblRemarks.Location = new System.Drawing.Point(9, 507);
            this.LblRemarks.Name = "LblRemarks";
            this.LblRemarks.Size = new System.Drawing.Size(56, 16);
            this.LblRemarks.TabIndex = 2;
            this.LblRemarks.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Font = new System.Drawing.Font("Microsoft JhengHei", 9F);
            this.txtRemarks.Location = new System.Drawing.Point(71, 503);
            this.txtRemarks.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(443, 23);
            this.txtRemarks.TabIndex = 3;
            // 
            // txtExpAmount
            // 
            this.txtExpAmount.Font = new System.Drawing.Font("Microsoft JhengHei", 9F);
            this.txtExpAmount.Location = new System.Drawing.Point(582, 504);
            this.txtExpAmount.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtExpAmount.Name = "txtExpAmount";
            this.txtExpAmount.Size = new System.Drawing.Size(130, 23);
            this.txtExpAmount.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(520, 506);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 16);
            this.label8.TabIndex = 4;
            this.label8.Text = "Total Tk.";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(521, 535);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 28);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(625, 535);
            this.btnCancle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(87, 28);
            this.btnCancle.TabIndex = 7;
            this.btnCancle.Text = "Close";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // aSPNETDBDataSet
            // 
            this.aSPNETDBDataSet.DataSetName = "ASPNETDBDataSet";
            this.aSPNETDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // aSPNETDBDataSetBindingSource
            // 
            this.aSPNETDBDataSetBindingSource.DataSource = this.aSPNETDBDataSet;
            this.aSPNETDBDataSetBindingSource.Position = 0;
            // 
            // FuelType
            // 
            this.FuelType.HeaderText = "Expense Type";
            this.FuelType.Name = "FuelType";
            this.FuelType.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FuelType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.FuelType.Width = 125;
            // 
            // UnitPrice
            // 
            this.UnitPrice.HeaderText = "Unit Price";
            this.UnitPrice.Name = "UnitPrice";
            // 
            // CashQty
            // 
            this.CashQty.HeaderText = "Cash Qty";
            this.CashQty.Name = "CashQty";
            // 
            // CashAmount
            // 
            this.CashAmount.HeaderText = "Cash Amount";
            this.CashAmount.Name = "CashAmount";
            this.CashAmount.Width = 116;
            // 
            // CreditQty
            // 
            this.CreditQty.HeaderText = "Credit Qty";
            this.CreditQty.Name = "CreditQty";
            // 
            // CreditAmount
            // 
            this.CreditAmount.HeaderText = "Credit Amount";
            this.CreditAmount.Name = "CreditAmount";
            this.CreditAmount.Width = 116;
            // 
            // ExpenseTypeID
            // 
            this.ExpenseTypeID.HeaderText = "ExpenseTypeID";
            this.ExpenseTypeID.Name = "ExpenseTypeID";
            this.ExpenseTypeID.Visible = false;
            // 
            // frmVehicleMaintenanceAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 572);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.LblRemarks);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.txtExpAmount);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgvExpanseAdmin);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmVehicleMaintenanceAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vehicle Operation Admin";
            this.Load += new System.EventHandler(this.frmVehicleMaintenanceAdmin_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvExpanseAdmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aSPNETDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aSPNETDBDataSetBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtInvoiceAmount;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btVichel;
        private System.Windows.Forms.TextBox txtRegNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtKmRun;
        private System.Windows.Forms.CheckBox ckbActive;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox txtEndReading;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTripU;
        private System.Windows.Forms.TextBox txtTripS;
        private System.Windows.Forms.TextBox txtTripC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVehicleCode;
        private System.Windows.Forms.TextBox txtVehicleDetails;
        private System.Windows.Forms.DataGridView dgvExpanseAdmin;
        private System.Windows.Forms.Label LblRemarks;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.TextBox txtExpAmount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancle;
        private ASPNETDBDataSet aSPNETDBDataSet;
        private System.Windows.Forms.BindingSource aSPNETDBDataSetBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn FuelType;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn CashQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn CashAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreditQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreditAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ExpenseTypeID;
    }
}
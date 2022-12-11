namespace CJ.Win.BEIL
{
    partial class frmProductActual
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblActualQty = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblQCPassQty = new System.Windows.Forms.Label();
            this.lblQCFailQty = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLotQty = new System.Windows.Forms.Label();
            this.lblPlanQty = new System.Windows.Forms.Label();
            this.lblActualableQty = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lblReceiveDate = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblLotNo = new System.Windows.Forms.Label();
            this.lblProductCode = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblProductName = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtQCFail = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.dgvPlan = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtQCPass = new System.Windows.Forms.TextBox();
            this.txtActualQty = new System.Windows.Forms.TextBox();
            this.txtPlan = new System.Windows.Forms.TextBox();
            this.txtPlanDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPlanManDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtManhour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPlanQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColActualDate = new RSMS.BaseItems.DateTimePickerColumn();
            this.ColManDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColActualManhoure = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPerviousActualQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActualQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColQCPass = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColQCFail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColActualRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColLotPlanID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlan)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblActualQty);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lblQCPassQty);
            this.groupBox2.Controls.Add(this.lblQCFailQty);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.lblLotQty);
            this.groupBox2.Controls.Add(this.lblPlanQty);
            this.groupBox2.Controls.Add(this.lblActualableQty);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.lblReceiveDate);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.lblLotNo);
            this.groupBox2.Controls.Add(this.lblProductCode);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.lblProductName);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Location = new System.Drawing.Point(12, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(890, 128);
            this.groupBox2.TabIndex = 184;
            this.groupBox2.TabStop = false;
            // 
            // lblActualQty
            // 
            this.lblActualQty.AutoSize = true;
            this.lblActualQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualQty.ForeColor = System.Drawing.Color.Black;
            this.lblActualQty.Location = new System.Drawing.Point(86, 104);
            this.lblActualQty.Name = "lblActualQty";
            this.lblActualQty.Size = new System.Drawing.Size(13, 13);
            this.lblActualQty.TabIndex = 188;
            this.lblActualQty.Text = "?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(21, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 187;
            this.label2.Text = "Actual Qty:";
            // 
            // lblQCPassQty
            // 
            this.lblQCPassQty.AutoSize = true;
            this.lblQCPassQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQCPassQty.Location = new System.Drawing.Point(370, 104);
            this.lblQCPassQty.Name = "lblQCPassQty";
            this.lblQCPassQty.Size = new System.Drawing.Size(13, 13);
            this.lblQCPassQty.TabIndex = 186;
            this.lblQCPassQty.Text = "?";
            // 
            // lblQCFailQty
            // 
            this.lblQCFailQty.AutoSize = true;
            this.lblQCFailQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQCFailQty.ForeColor = System.Drawing.Color.Black;
            this.lblQCFailQty.Location = new System.Drawing.Point(553, 104);
            this.lblQCFailQty.Name = "lblQCFailQty";
            this.lblQCFailQty.Size = new System.Drawing.Size(13, 13);
            this.lblQCFailQty.TabIndex = 185;
            this.lblQCFailQty.Text = "?";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(303, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 183;
            this.label3.Text = "QC Pass Qty:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(489, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 184;
            this.label4.Text = "QC Fail Qty:";
            // 
            // lblLotQty
            // 
            this.lblLotQty.AutoSize = true;
            this.lblLotQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotQty.Location = new System.Drawing.Point(370, 83);
            this.lblLotQty.Name = "lblLotQty";
            this.lblLotQty.Size = new System.Drawing.Size(13, 13);
            this.lblLotQty.TabIndex = 182;
            this.lblLotQty.Text = "?";
            // 
            // lblPlanQty
            // 
            this.lblPlanQty.AutoSize = true;
            this.lblPlanQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlanQty.Location = new System.Drawing.Point(553, 82);
            this.lblPlanQty.Name = "lblPlanQty";
            this.lblPlanQty.Size = new System.Drawing.Size(13, 13);
            this.lblPlanQty.TabIndex = 181;
            this.lblPlanQty.Text = "?";
            // 
            // lblActualableQty
            // 
            this.lblActualableQty.AutoSize = true;
            this.lblActualableQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualableQty.ForeColor = System.Drawing.Color.Red;
            this.lblActualableQty.Location = new System.Drawing.Point(759, 104);
            this.lblActualableQty.Name = "lblActualableQty";
            this.lblActualableQty.Size = new System.Drawing.Size(13, 13);
            this.lblActualableQty.TabIndex = 181;
            this.lblActualableQty.Text = "?";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(502, 82);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(50, 13);
            this.label24.TabIndex = 180;
            this.label24.Text = "Plan Qty:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(329, 82);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(44, 13);
            this.label12.TabIndex = 35;
            this.label12.Text = "Lot Qty:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(674, 104);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(79, 13);
            this.label22.TabIndex = 180;
            this.label22.Text = "Actualable Qty:";
            // 
            // lblReceiveDate
            // 
            this.lblReceiveDate.AutoSize = true;
            this.lblReceiveDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiveDate.Location = new System.Drawing.Point(87, 82);
            this.lblReceiveDate.Name = "lblReceiveDate";
            this.lblReceiveDate.Size = new System.Drawing.Size(13, 13);
            this.lblReceiveDate.TabIndex = 24;
            this.lblReceiveDate.Text = "?";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(8, 82);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 13);
            this.label13.TabIndex = 23;
            this.label13.Text = "Receive Date: ";
            // 
            // lblLotNo
            // 
            this.lblLotNo.AutoSize = true;
            this.lblLotNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotNo.Location = new System.Drawing.Point(88, 59);
            this.lblLotNo.Name = "lblLotNo";
            this.lblLotNo.Size = new System.Drawing.Size(13, 13);
            this.lblLotNo.TabIndex = 21;
            this.lblLotNo.Text = "?";
            // 
            // lblProductCode
            // 
            this.lblProductCode.AutoSize = true;
            this.lblProductCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductCode.Location = new System.Drawing.Point(88, 16);
            this.lblProductCode.Name = "lblProductCode";
            this.lblProductCode.Size = new System.Drawing.Size(16, 13);
            this.lblProductCode.TabIndex = 20;
            this.lblProductCode.Text = "? ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(42, 57);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 13);
            this.label14.TabIndex = 19;
            this.label14.Text = "Lot No:";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(88, 36);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(13, 13);
            this.lblProductName.TabIndex = 18;
            this.lblProductName.Text = "?";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(15, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "ProductCode:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(10, 36);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(81, 13);
            this.label20.TabIndex = 10;
            this.label20.Text = "Product Name: ";
            // 
            // txtQCFail
            // 
            this.txtQCFail.Location = new System.Drawing.Point(694, 340);
            this.txtQCFail.Name = "txtQCFail";
            this.txtQCFail.ReadOnly = true;
            this.txtQCFail.Size = new System.Drawing.Size(62, 20);
            this.txtQCFail.TabIndex = 186;
            this.txtQCFail.Text = "0";
            this.txtQCFail.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(746, 369);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 28);
            this.btnSave.TabIndex = 188;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // dgvPlan
            // 
            this.dgvPlan.AllowUserToAddRows = false;
            this.dgvPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtPlanDate,
            this.ColPlanManDay,
            this.txtManhour,
            this.txtPlanQty,
            this.ColActualDate,
            this.ColManDay,
            this.ColActualManhoure,
            this.ColPerviousActualQty,
            this.colActualQty,
            this.ColQCPass,
            this.ColQCFail,
            this.ColActualRemarks,
            this.ColLotPlanID});
            this.dgvPlan.Location = new System.Drawing.Point(10, 150);
            this.dgvPlan.Name = "dgvPlan";
            this.dgvPlan.Size = new System.Drawing.Size(892, 184);
            this.dgvPlan.TabIndex = 185;
            this.dgvPlan.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlan_CellValueChanged);
            this.dgvPlan.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvPlan_RowsRemoved);
            this.dgvPlan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlan_CellContentClick);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(827, 369);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 28);
            this.btnClose.TabIndex = 187;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtQCPass
            // 
            this.txtQCPass.Location = new System.Drawing.Point(631, 340);
            this.txtQCPass.Name = "txtQCPass";
            this.txtQCPass.ReadOnly = true;
            this.txtQCPass.Size = new System.Drawing.Size(57, 20);
            this.txtQCPass.TabIndex = 189;
            this.txtQCPass.Text = "0";
            this.txtQCPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtActualQty
            // 
            this.txtActualQty.Location = new System.Drawing.Point(566, 340);
            this.txtActualQty.Name = "txtActualQty";
            this.txtActualQty.ReadOnly = true;
            this.txtActualQty.Size = new System.Drawing.Size(59, 20);
            this.txtActualQty.TabIndex = 190;
            this.txtActualQty.Text = "0";
            this.txtActualQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPlan
            // 
            this.txtPlan.Location = new System.Drawing.Point(250, 340);
            this.txtPlan.Name = "txtPlan";
            this.txtPlan.ReadOnly = true;
            this.txtPlan.Size = new System.Drawing.Size(57, 20);
            this.txtPlan.TabIndex = 191;
            this.txtPlan.Text = "0";
            this.txtPlan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPlanDate
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Silver;
            this.txtPlanDate.DefaultCellStyle = dataGridViewCellStyle1;
            this.txtPlanDate.HeaderText = "Plan Date";
            this.txtPlanDate.Name = "txtPlanDate";
            this.txtPlanDate.ReadOnly = true;
            this.txtPlanDate.Width = 80;
            // 
            // ColPlanManDay
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
            this.ColPlanManDay.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColPlanManDay.HeaderText = "Plan Man Day";
            this.ColPlanManDay.Name = "ColPlanManDay";
            this.ColPlanManDay.ReadOnly = true;
            this.ColPlanManDay.Width = 60;
            // 
            // txtManhour
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Silver;
            this.txtManhour.DefaultCellStyle = dataGridViewCellStyle3;
            this.txtManhour.HeaderText = "Manhour";
            this.txtManhour.Name = "txtManhour";
            this.txtManhour.ReadOnly = true;
            this.txtManhour.Width = 60;
            // 
            // txtPlanQty
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.Silver;
            this.txtPlanQty.DefaultCellStyle = dataGridViewCellStyle4;
            this.txtPlanQty.HeaderText = "Plan Qty";
            this.txtPlanQty.Name = "txtPlanQty";
            this.txtPlanQty.ReadOnly = true;
            this.txtPlanQty.Width = 60;
            // 
            // ColActualDate
            // 
            dataGridViewCellStyle5.Format = "M";
            dataGridViewCellStyle5.NullValue = null;
            this.ColActualDate.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColActualDate.HeaderText = "Actual Date";
            this.ColActualDate.Name = "ColActualDate";
            this.ColActualDate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColActualDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColActualDate.Width = 80;
            // 
            // ColManDay
            // 
            this.ColManDay.HeaderText = "Actual Man Day";
            this.ColManDay.Name = "ColManDay";
            this.ColManDay.Width = 60;
            // 
            // ColActualManhoure
            // 
            this.ColActualManhoure.HeaderText = "Actual Manhoure";
            this.ColActualManhoure.Name = "ColActualManhoure";
            this.ColActualManhoure.Width = 60;
            // 
            // ColPerviousActualQty
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Silver;
            this.ColPerviousActualQty.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColPerviousActualQty.HeaderText = "Pervious Actual Qty";
            this.ColPerviousActualQty.Name = "ColPerviousActualQty";
            this.ColPerviousActualQty.ReadOnly = true;
            this.ColPerviousActualQty.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColPerviousActualQty.Width = 60;
            // 
            // colActualQty
            // 
            this.colActualQty.HeaderText = "Actual Qty";
            this.colActualQty.Name = "colActualQty";
            this.colActualQty.Width = 60;
            // 
            // ColQCPass
            // 
            this.ColQCPass.HeaderText = "QC Pass";
            this.ColQCPass.Name = "ColQCPass";
            this.ColQCPass.Width = 60;
            // 
            // ColQCFail
            // 
            this.ColQCFail.HeaderText = "QC Fail";
            this.ColQCFail.Name = "ColQCFail";
            this.ColQCFail.Width = 60;
            // 
            // ColActualRemarks
            // 
            this.ColActualRemarks.HeaderText = "ActualRemarks";
            this.ColActualRemarks.Name = "ColActualRemarks";
            this.ColActualRemarks.Width = 160;
            // 
            // ColLotPlanID
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.Silver;
            this.ColLotPlanID.DefaultCellStyle = dataGridViewCellStyle7;
            this.ColLotPlanID.HeaderText = "LotPlanID";
            this.ColLotPlanID.Name = "ColLotPlanID";
            this.ColLotPlanID.Visible = false;
            this.ColLotPlanID.Width = 60;
            // 
            // frmProductActual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 404);
            this.Controls.Add(this.txtPlan);
            this.Controls.Add(this.txtActualQty);
            this.Controls.Add(this.txtQCPass);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtQCFail);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvPlan);
            this.Controls.Add(this.btnClose);
            this.Name = "frmProductActual";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmProductActual";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblLotQty;
        private System.Windows.Forms.Label lblPlanQty;
        private System.Windows.Forms.Label lblActualableQty;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label lblReceiveDate;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblLotNo;
        private System.Windows.Forms.Label lblProductCode;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblProductName;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtQCFail;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvPlan;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtQCPass;
        private System.Windows.Forms.TextBox txtActualQty;
        private System.Windows.Forms.Label lblQCPassQty;
        private System.Windows.Forms.Label lblQCFailQty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblActualQty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPlan;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtPlanDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPlanManDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtManhour;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtPlanQty;
        private RSMS.BaseItems.DateTimePickerColumn ColActualDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColManDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColActualManhoure;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPerviousActualQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActualQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColQCPass;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColQCFail;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColActualRemarks;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColLotPlanID;
    }
}
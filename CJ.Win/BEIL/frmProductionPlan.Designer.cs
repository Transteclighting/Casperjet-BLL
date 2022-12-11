namespace CJ.Win.BEIL
{
    partial class frmProductionPlan
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblLotQty = new System.Windows.Forms.Label();
            this.lblPlanQty = new System.Windows.Forms.Label();
            this.lblPlanableQty = new System.Windows.Forms.Label();
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
            this.dgvPlan = new System.Windows.Forms.DataGridView();
            this.txtPlanDate = new RSMS.BaseItems.DateTimePickerColumn();
            this.ColManDay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtManhour = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPlanQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRemarks = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTotalQty = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlan)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblLotQty);
            this.groupBox2.Controls.Add(this.lblPlanQty);
            this.groupBox2.Controls.Add(this.lblPlanableQty);
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
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(443, 129);
            this.groupBox2.TabIndex = 179;
            this.groupBox2.TabStop = false;
            // 
            // lblLotQty
            // 
            this.lblLotQty.AutoSize = true;
            this.lblLotQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotQty.Location = new System.Drawing.Point(325, 84);
            this.lblLotQty.Name = "lblLotQty";
            this.lblLotQty.Size = new System.Drawing.Size(13, 13);
            this.lblLotQty.TabIndex = 182;
            this.lblLotQty.Text = "?";
            // 
            // lblPlanQty
            // 
            this.lblPlanQty.AutoSize = true;
            this.lblPlanQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlanQty.Location = new System.Drawing.Point(84, 106);
            this.lblPlanQty.Name = "lblPlanQty";
            this.lblPlanQty.Size = new System.Drawing.Size(13, 13);
            this.lblPlanQty.TabIndex = 181;
            this.lblPlanQty.Text = "?";
            // 
            // lblPlanableQty
            // 
            this.lblPlanableQty.AutoSize = true;
            this.lblPlanableQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlanableQty.ForeColor = System.Drawing.Color.Red;
            this.lblPlanableQty.Location = new System.Drawing.Point(325, 106);
            this.lblPlanableQty.Name = "lblPlanableQty";
            this.lblPlanableQty.Size = new System.Drawing.Size(13, 13);
            this.lblPlanableQty.TabIndex = 181;
            this.lblPlanableQty.Text = "?";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(30, 106);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(50, 13);
            this.label24.TabIndex = 180;
            this.label24.Text = "Plan Qty:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(284, 84);
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
            this.label22.Location = new System.Drawing.Point(258, 106);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(70, 13);
            this.label22.TabIndex = 180;
            this.label22.Text = "Planable Qty:";
            // 
            // lblReceiveDate
            // 
            this.lblReceiveDate.AutoSize = true;
            this.lblReceiveDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReceiveDate.Location = new System.Drawing.Point(84, 84);
            this.lblReceiveDate.Name = "lblReceiveDate";
            this.lblReceiveDate.Size = new System.Drawing.Size(13, 13);
            this.lblReceiveDate.TabIndex = 24;
            this.lblReceiveDate.Text = "?";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(4, 84);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 13);
            this.label13.TabIndex = 23;
            this.label13.Text = "Receive Date: ";
            // 
            // lblLotNo
            // 
            this.lblLotNo.AutoSize = true;
            this.lblLotNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotNo.Location = new System.Drawing.Point(84, 61);
            this.lblLotNo.Name = "lblLotNo";
            this.lblLotNo.Size = new System.Drawing.Size(13, 13);
            this.lblLotNo.TabIndex = 21;
            this.lblLotNo.Text = "?";
            // 
            // lblProductCode
            // 
            this.lblProductCode.AutoSize = true;
            this.lblProductCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductCode.Location = new System.Drawing.Point(84, 18);
            this.lblProductCode.Name = "lblProductCode";
            this.lblProductCode.Size = new System.Drawing.Size(16, 13);
            this.lblProductCode.TabIndex = 20;
            this.lblProductCode.Text = "? ";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(38, 59);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 13);
            this.label14.TabIndex = 19;
            this.label14.Text = "Lot No:";
            // 
            // lblProductName
            // 
            this.lblProductName.AutoSize = true;
            this.lblProductName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProductName.Location = new System.Drawing.Point(84, 38);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(13, 13);
            this.lblProductName.TabIndex = 18;
            this.lblProductName.Text = "?";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(11, 18);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "ProductCode:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(6, 38);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(81, 13);
            this.label20.TabIndex = 10;
            this.label20.Text = "Product Name: ";
            // 
            // dgvPlan
            // 
            this.dgvPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlan.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtPlanDate,
            this.ColManDay,
            this.txtManhour,
            this.txtPlanQty,
            this.ColRemarks});
            this.dgvPlan.Location = new System.Drawing.Point(12, 147);
            this.dgvPlan.Name = "dgvPlan";
            this.dgvPlan.Size = new System.Drawing.Size(443, 162);
            this.dgvPlan.TabIndex = 180;
            this.dgvPlan.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPlan_CellValueChanged);
            this.dgvPlan.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvPlan_RowsRemoved);
            this.dgvPlan.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrderQty_CellContentClick);
            // 
            // txtPlanDate
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Format = "d";
            dataGridViewCellStyle4.NullValue = null;
            this.txtPlanDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.txtPlanDate.HeaderText = "Plan Date";
            this.txtPlanDate.Name = "txtPlanDate";
            this.txtPlanDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.txtPlanDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.txtPlanDate.Width = 60;
            // 
            // ColManDay
            // 
            this.ColManDay.HeaderText = "ManDay";
            this.ColManDay.Name = "ColManDay";
            this.ColManDay.Width = 60;
            // 
            // txtManhour
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            this.txtManhour.DefaultCellStyle = dataGridViewCellStyle5;
            this.txtManhour.HeaderText = "Manhour";
            this.txtManhour.Name = "txtManhour";
            this.txtManhour.Width = 60;
            // 
            // txtPlanQty
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            this.txtPlanQty.DefaultCellStyle = dataGridViewCellStyle6;
            this.txtPlanQty.HeaderText = "Plan Qty";
            this.txtPlanQty.Name = "txtPlanQty";
            this.txtPlanQty.Width = 60;
            // 
            // ColRemarks
            // 
            this.ColRemarks.HeaderText = "Remarks";
            this.ColRemarks.Name = "ColRemarks";
            this.ColRemarks.Width = 160;
            // 
            // txtTotalQty
            // 
            this.txtTotalQty.Location = new System.Drawing.Point(376, 315);
            this.txtTotalQty.Name = "txtTotalQty";
            this.txtTotalQty.ReadOnly = true;
            this.txtTotalQty.Size = new System.Drawing.Size(79, 20);
            this.txtTotalQty.TabIndex = 181;
            this.txtTotalQty.Text = "0";
            this.txtTotalQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(299, 341);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 183;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(380, 341);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 25);
            this.btnClose.TabIndex = 182;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // frmProductionPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 375);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtTotalQty);
            this.Controls.Add(this.dgvPlan);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmProductionPlan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmProductionPlan";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblPlanQty;
        private System.Windows.Forms.Label lblPlanableQty;
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
        private System.Windows.Forms.Label lblLotQty;
        private System.Windows.Forms.DataGridView dgvPlan;
        private System.Windows.Forms.TextBox txtTotalQty;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private RSMS.BaseItems.DateTimePickerColumn txtPlanDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColManDay;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtManhour;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtPlanQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRemarks;
    }
}
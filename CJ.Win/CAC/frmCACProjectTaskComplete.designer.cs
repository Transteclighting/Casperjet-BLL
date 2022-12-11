namespace CJ.Win.CAC
{
    partial class frmCACProjectTaskComplete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCACProjectTaskComplete));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.dgvTaskComplete = new System.Windows.Forms.DataGridView();
            this.txtTaskName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDate = new CJ.Win.Control.CalenderControl();
            this.EndDate = new CJ.Win.Control.CalenderControl();
            this.txtWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtWeightPercent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCompleteWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtProgressWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTaskID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTotalCompleteWeight = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calenderControl1 = new CJ.Win.Control.CalenderControl();
            this.calenderControl2 = new CJ.Win.Control.CalenderControl();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaskComplete)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnSave.Location = new System.Drawing.Point(590, 298);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnClose.Location = new System.Drawing.Point(671, 298);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dgvTaskComplete
            // 
            this.dgvTaskComplete.AllowUserToAddRows = false;
            this.dgvTaskComplete.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTaskComplete.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTaskComplete.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTaskComplete.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtTaskName,
            this.StartDate,
            this.EndDate,
            this.txtWeight,
            this.txtWeightPercent,
            this.txtCompleteWeight,
            this.txtProgressWeight,
            this.txtTaskID,
            this.ID});
            this.dgvTaskComplete.Location = new System.Drawing.Point(12, 37);
            this.dgvTaskComplete.Name = "dgvTaskComplete";
            this.dgvTaskComplete.Size = new System.Drawing.Size(734, 226);
            this.dgvTaskComplete.TabIndex = 0;
            this.dgvTaskComplete.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTaskComplete_CellValueChanged);
            this.dgvTaskComplete.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvTaskComplete_RowsRemoved);
            // 
            // txtTaskName
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTaskName.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtTaskName.HeaderText = "Task Name";
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.ReadOnly = true;
            this.txtTaskName.Width = 200;
            // 
            // StartDate
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.StartDate.DefaultCellStyle = dataGridViewCellStyle3;
            this.StartDate.HeaderText = "StartDate";
            this.StartDate.Name = "StartDate";
            this.StartDate.ReadOnly = true;
            this.StartDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.StartDate.Width = 85;
            // 
            // EndDate
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.EndDate.DefaultCellStyle = dataGridViewCellStyle4;
            this.EndDate.HeaderText = "EndDate";
            this.EndDate.Name = "EndDate";
            this.EndDate.ReadOnly = true;
            this.EndDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.EndDate.Width = 85;
            // 
            // txtWeight
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtWeight.DefaultCellStyle = dataGridViewCellStyle5;
            this.txtWeight.HeaderText = "Weight";
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.ReadOnly = true;
            this.txtWeight.Width = 80;
            // 
            // txtWeightPercent
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtWeightPercent.DefaultCellStyle = dataGridViewCellStyle6;
            this.txtWeightPercent.HeaderText = "Complete Weight";
            this.txtWeightPercent.Name = "txtWeightPercent";
            this.txtWeightPercent.ReadOnly = true;
            this.txtWeightPercent.Width = 80;
            // 
            // txtCompleteWeight
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtCompleteWeight.DefaultCellStyle = dataGridViewCellStyle7;
            this.txtCompleteWeight.HeaderText = "Complete Percent";
            this.txtCompleteWeight.Name = "txtCompleteWeight";
            this.txtCompleteWeight.ReadOnly = true;
            this.txtCompleteWeight.Width = 80;
            // 
            // txtProgressWeight
            // 
            this.txtProgressWeight.HeaderText = "Progress Weight";
            this.txtProgressWeight.Name = "txtProgressWeight";
            this.txtProgressWeight.Width = 80;
            // 
            // txtTaskID
            // 
            this.txtTaskID.HeaderText = "TaskID";
            this.txtTaskID.Name = "txtTaskID";
            this.txtTaskID.ReadOnly = true;
            this.txtTaskID.Visible = false;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // txtTotalCompleteWeight
            // 
            this.txtTotalCompleteWeight.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtTotalCompleteWeight.Location = new System.Drawing.Point(668, 269);
            this.txtTotalCompleteWeight.Name = "txtTotalCompleteWeight";
            this.txtTotalCompleteWeight.ReadOnly = true;
            this.txtTotalCompleteWeight.Size = new System.Drawing.Size(78, 23);
            this.txtTotalCompleteWeight.TabIndex = 2;
            this.txtTotalCompleteWeight.Text = "0.00";
            this.txtTotalCompleteWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label29.Location = new System.Drawing.Point(572, 272);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(90, 15);
            this.label29.TabIndex = 1;
            this.label29.Text = "Total Progress:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lblName.Location = new System.Drawing.Point(258, 11);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(13, 15);
            this.lblName.TabIndex = 73;
            this.lblName.Text = "?";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label6.Location = new System.Drawing.Point(173, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 15);
            this.label6.TabIndex = 72;
            this.label6.Text = "Project Name:";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lblCode.Location = new System.Drawing.Point(93, 11);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(13, 15);
            this.lblCode.TabIndex = 71;
            this.lblCode.Text = "?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label2.Location = new System.Drawing.Point(12, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 15);
            this.label2.TabIndex = 70;
            this.label2.Text = "Project Code:";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Task Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Weight";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn2.Width = 70;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Complete Percent";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dataGridViewTextBoxColumn3.Width = 120;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "ProgressWeight";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 70;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "TaskID";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "ID";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Visible = false;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "TaskID";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Visible = false;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "ID";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Visible = false;
            // 
            // calenderControl1
            // 
            this.calenderControl1.HeaderText = "StartDate";
            this.calenderControl1.Name = "calenderControl1";
            this.calenderControl1.ReadOnly = true;
            this.calenderControl1.Width = 120;
            // 
            // calenderControl2
            // 
            this.calenderControl2.HeaderText = "EndDate";
            this.calenderControl2.Name = "calenderControl2";
            this.calenderControl2.ReadOnly = true;
            this.calenderControl2.Width = 120;
            // 
            // frmCACProjectTaskComplete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(758, 327);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvTaskComplete);
            this.Controls.Add(this.txtTotalCompleteWeight);
            this.Controls.Add(this.label29);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCACProjectTaskComplete";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CAC Project Task Complete";
            this.Load += new System.EventHandler(this.frmCACProjectTaskComplete_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaskComplete)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView dgvTaskComplete;
        private System.Windows.Forms.TextBox txtTotalCompleteWeight;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private Control.CalenderControl calenderControl1;
        private Control.CalenderControl calenderControl2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTaskName;
        private Control.CalenderControl StartDate;
        private Control.CalenderControl EndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtWeightPercent;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtCompleteWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProgressWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTaskID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
    }
}
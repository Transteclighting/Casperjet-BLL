namespace CJ.Win.CAC
{
    partial class frmCACProjectTaskWeight
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCACProjectTaskWeight));
            this.cmbTask = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.txtTaskWeight = new System.Windows.Forms.TextBox();
            this.dgvTask = new System.Windows.Forms.DataGridView();
            this.txtTotalWeight = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calenderControl1 = new CJ.Win.Control.CalenderControl();
            this.calenderControl2 = new CJ.Win.Control.CalenderControl();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTaskName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StartDate = new CJ.Win.Control.CalenderControl();
            this.EndDate = new CJ.Win.Control.CalenderControl();
            this.txtWeight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTaskID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTask)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbTask
            // 
            this.cmbTask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTask.FormattingEnabled = true;
            this.cmbTask.Location = new System.Drawing.Point(29, -57);
            this.cmbTask.Name = "cmbTask";
            this.cmbTask.Size = new System.Drawing.Size(189, 21);
            this.cmbTask.TabIndex = 201;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(-1, -54);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(31, 13);
            this.label23.TabIndex = 197;
            this.label23.Text = "Task";
            // 
            // btnAddTask
            // 
            this.btnAddTask.Location = new System.Drawing.Point(330, -59);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(68, 23);
            this.btnAddTask.TabIndex = 200;
            this.btnAddTask.Text = "Add to List";
            this.btnAddTask.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(221, -54);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(41, 13);
            this.label24.TabIndex = 198;
            this.label24.Text = "Weight";
            // 
            // txtTaskWeight
            // 
            this.txtTaskWeight.Location = new System.Drawing.Point(264, -57);
            this.txtTaskWeight.Name = "txtTaskWeight";
            this.txtTaskWeight.Size = new System.Drawing.Size(60, 20);
            this.txtTaskWeight.TabIndex = 199;
            // 
            // dgvTask
            // 
            this.dgvTask.AllowUserToAddRows = false;
            this.dgvTask.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTask.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTask.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTask.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtTaskName,
            this.StartDate,
            this.EndDate,
            this.txtWeight,
            this.txtTaskID});
            this.dgvTask.Location = new System.Drawing.Point(12, 35);
            this.dgvTask.Name = "dgvTask";
            this.dgvTask.Size = new System.Drawing.Size(549, 240);
            this.dgvTask.TabIndex = 5;
            this.dgvTask.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTask_CellValueChanged);
            this.dgvTask.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvTask_RowsRemoved);
            // 
            // txtTotalWeight
            // 
            this.txtTotalWeight.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.txtTotalWeight.Location = new System.Drawing.Point(483, 281);
            this.txtTotalWeight.Name = "txtTotalWeight";
            this.txtTotalWeight.ReadOnly = true;
            this.txtTotalWeight.Size = new System.Drawing.Size(78, 23);
            this.txtTotalWeight.TabIndex = 7;
            this.txtTotalWeight.Text = "0.00";
            this.txtTotalWeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label29.Location = new System.Drawing.Point(438, 284);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(39, 15);
            this.label29.TabIndex = 6;
            this.label29.Text = "Total:";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnSave.Location = new System.Drawing.Point(405, 310);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.btnClose.Location = new System.Drawing.Point(486, 310);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lblName.Location = new System.Drawing.Point(258, 11);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(13, 15);
            this.lblName.TabIndex = 205;
            this.lblName.Text = "?";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label6.Location = new System.Drawing.Point(173, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 15);
            this.label6.TabIndex = 204;
            this.label6.Text = "Project Name:";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.lblCode.Location = new System.Drawing.Point(93, 11);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(13, 15);
            this.lblCode.TabIndex = 203;
            this.lblCode.Text = "?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.label2.Location = new System.Drawing.Point(12, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 15);
            this.label2.TabIndex = 202;
            this.label2.Text = "Project Code:";
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn1.HeaderText = "Task Name";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 290;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Weight";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 70;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "TaskID";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // calenderControl1
            // 
            this.calenderControl1.HeaderText = "StartDate";
            this.calenderControl1.Name = "calenderControl1";
            // 
            // calenderControl2
            // 
            this.calenderControl2.HeaderText = "EndDate";
            this.calenderControl2.Name = "calenderControl2";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "TaskID";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.HeaderText = "ProjectID";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Visible = false;
            // 
            // txtTaskName
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            this.txtTaskName.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtTaskName.HeaderText = "Task Name";
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.ReadOnly = true;
            this.txtTaskName.Width = 250;
            // 
            // StartDate
            // 
            this.StartDate.HeaderText = "StartDate";
            this.StartDate.Name = "StartDate";
            this.StartDate.Width = 85;
            // 
            // EndDate
            // 
            this.EndDate.HeaderText = "EndDate";
            this.EndDate.Name = "EndDate";
            this.EndDate.Width = 85;
            // 
            // txtWeight
            // 
            this.txtWeight.HeaderText = "Weight";
            this.txtWeight.Name = "txtWeight";
            this.txtWeight.Width = 90;
            // 
            // txtTaskID
            // 
            this.txtTaskID.HeaderText = "TaskID";
            this.txtTaskID.Name = "txtTaskID";
            this.txtTaskID.ReadOnly = true;
            this.txtTaskID.Visible = false;
            // 
            // frmCACProjectTaskWeight
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 339);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cmbTask);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.btnAddTask);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.txtTaskWeight);
            this.Controls.Add(this.dgvTask);
            this.Controls.Add(this.txtTotalWeight);
            this.Controls.Add(this.label29);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCACProjectTaskWeight";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CAC Project Task Weight";
            this.Load += new System.EventHandler(this.frmCACProjectTaskWeight_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTask)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbTask;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtTaskWeight;
        private System.Windows.Forms.DataGridView dgvTask;
        private System.Windows.Forms.TextBox txtTotalWeight;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label label2;
        private Control.CalenderControl calenderControl1;
        private Control.CalenderControl calenderControl2;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTaskName;
        private Control.CalenderControl StartDate;
        private Control.CalenderControl EndDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtWeight;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTaskID;
    }
}
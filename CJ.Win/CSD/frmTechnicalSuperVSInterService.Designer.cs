namespace CJ.Win
{
    partial class frmTechnicalSuperVSInterService
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
            this.lvwInterServiceUnMapping = new System.Windows.Forms.ListView();
            this.colInterServiceCode = new System.Windows.Forms.ColumnHeader();
            this.colInterServiceName = new System.Windows.Forms.ColumnHeader();
            this.colAddress = new System.Windows.Forms.ColumnHeader();
            this.colISActive = new System.Windows.Forms.ColumnHeader();
            this.lvwMapping = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.lblTotalMapping = new System.Windows.Forms.Label();
            this.lblTotalAll = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDesignation = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSupervisorID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSupervisorName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtISVCode = new System.Windows.Forms.TextBox();
            this.cmbIsActive = new System.Windows.Forms.ComboBox();
            this.txtISVName = new System.Windows.Forms.TextBox();
            this.lblPaidJobID = new System.Windows.Forms.Label();
            this.lblComplainerName = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblContactNo = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtISVCode1 = new System.Windows.Forms.TextBox();
            this.cmbIsActive1 = new System.Windows.Forms.ComboBox();
            this.txtISVName1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtAddress1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwInterServiceUnMapping
            // 
            this.lvwInterServiceUnMapping.AccessibleDescription = "InterServiceName";
            this.lvwInterServiceUnMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwInterServiceUnMapping.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colInterServiceCode,
            this.colInterServiceName,
            this.colAddress,
            this.colISActive});
            this.lvwInterServiceUnMapping.FullRowSelect = true;
            this.lvwInterServiceUnMapping.GridLines = true;
            this.lvwInterServiceUnMapping.Location = new System.Drawing.Point(-2, 146);
            this.lvwInterServiceUnMapping.MultiSelect = false;
            this.lvwInterServiceUnMapping.Name = "lvwInterServiceUnMapping";
            this.lvwInterServiceUnMapping.Size = new System.Drawing.Size(362, 288);
            this.lvwInterServiceUnMapping.TabIndex = 2;
            this.lvwInterServiceUnMapping.UseCompatibleStateImageBehavior = false;
            this.lvwInterServiceUnMapping.View = System.Windows.Forms.View.Details;
            // 
            // colInterServiceCode
            // 
            this.colInterServiceCode.Text = "ISV Code";
            this.colInterServiceCode.Width = 63;
            // 
            // colInterServiceName
            // 
            this.colInterServiceName.Text = "Inter Service Name";
            this.colInterServiceName.Width = 211;
            // 
            // colAddress
            // 
            this.colAddress.Text = "Address";
            this.colAddress.Width = 178;
            // 
            // colISActive
            // 
            this.colISActive.Text = "Is Active";
            this.colISActive.Width = 59;
            // 
            // lvwMapping
            // 
            this.lvwMapping.AccessibleDescription = "InterServiceName";
            this.lvwMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwMapping.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvwMapping.FullRowSelect = true;
            this.lvwMapping.GridLines = true;
            this.lvwMapping.Location = new System.Drawing.Point(428, 146);
            this.lvwMapping.MultiSelect = false;
            this.lvwMapping.Name = "lvwMapping";
            this.lvwMapping.Size = new System.Drawing.Size(350, 288);
            this.lvwMapping.TabIndex = 3;
            this.lvwMapping.UseCompatibleStateImageBehavior = false;
            this.lvwMapping.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ISV Code";
            this.columnHeader1.Width = 63;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Inter Service Name";
            this.columnHeader2.Width = 211;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Address";
            this.columnHeader3.Width = 178;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Is Active";
            this.columnHeader4.Width = 59;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(694, 444);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 27);
            this.btnClose.TabIndex = 156;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.Green;
            this.btnUpdate.Location = new System.Drawing.Point(369, 233);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(47, 27);
            this.btnUpdate.TabIndex = 157;
            this.btnUpdate.Text = "=>";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ForeColor = System.Drawing.Color.Red;
            this.btnDelete.Location = new System.Drawing.Point(368, 317);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(47, 27);
            this.btnDelete.TabIndex = 158;
            this.btnDelete.Text = "<=";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // lblTotalMapping
            // 
            this.lblTotalMapping.AutoSize = true;
            this.lblTotalMapping.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalMapping.Location = new System.Drawing.Point(445, 444);
            this.lblTotalMapping.Name = "lblTotalMapping";
            this.lblTotalMapping.Size = new System.Drawing.Size(19, 20);
            this.lblTotalMapping.TabIndex = 159;
            this.lblTotalMapping.Text = "?";
            // 
            // lblTotalAll
            // 
            this.lblTotalAll.AutoSize = true;
            this.lblTotalAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalAll.Location = new System.Drawing.Point(28, 444);
            this.lblTotalAll.Name = "lblTotalAll";
            this.lblTotalAll.Size = new System.Drawing.Size(19, 20);
            this.lblTotalAll.TabIndex = 160;
            this.lblTotalAll.Text = "?";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.lblDesignation);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.lblSupervisorID);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.lblSupervisorName);
            this.groupBox3.Location = new System.Drawing.Point(12, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(762, 46);
            this.groupBox3.TabIndex = 161;
            this.groupBox3.TabStop = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(491, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 20);
            this.label3.TabIndex = 152;
            this.label3.Text = "Designation";
            // 
            // lblDesignation
            // 
            this.lblDesignation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDesignation.Location = new System.Drawing.Point(587, 14);
            this.lblDesignation.Name = "lblDesignation";
            this.lblDesignation.Size = new System.Drawing.Size(162, 20);
            this.lblDesignation.TabIndex = 151;
            this.lblDesignation.Text = "?";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(11, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 19);
            this.label5.TabIndex = 150;
            this.label5.Text = "Supervisor ID";
            // 
            // lblSupervisorID
            // 
            this.lblSupervisorID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSupervisorID.Location = new System.Drawing.Point(101, 15);
            this.lblSupervisorID.Name = "lblSupervisorID";
            this.lblSupervisorID.Size = new System.Drawing.Size(53, 19);
            this.lblSupervisorID.TabIndex = 149;
            this.lblSupervisorID.Text = "?";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(185, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 20);
            this.label2.TabIndex = 148;
            this.label2.Text = "Supervisor Name";
            // 
            // lblSupervisorName
            // 
            this.lblSupervisorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSupervisorName.Location = new System.Drawing.Point(289, 14);
            this.lblSupervisorName.Name = "lblSupervisorName";
            this.lblSupervisorName.Size = new System.Drawing.Size(172, 20);
            this.lblSupervisorName.TabIndex = 146;
            this.lblSupervisorName.Text = "?";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 198;
            this.label1.Text = "Is Active?";
            // 
            // txtISVCode
            // 
            this.txtISVCode.Location = new System.Drawing.Point(74, 71);
            this.txtISVCode.Name = "txtISVCode";
            this.txtISVCode.Size = new System.Drawing.Size(62, 20);
            this.txtISVCode.TabIndex = 192;
            this.txtISVCode.TextChanged += new System.EventHandler(this.txtISVCode_TextChanged);
            // 
            // cmbIsActive
            // 
            this.cmbIsActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIsActive.FormattingEnabled = true;
            this.cmbIsActive.Location = new System.Drawing.Point(74, 97);
            this.cmbIsActive.Name = "cmbIsActive";
            this.cmbIsActive.Size = new System.Drawing.Size(62, 21);
            this.cmbIsActive.TabIndex = 197;
            this.cmbIsActive.SelectedIndexChanged += new System.EventHandler(this.cmbIsActive_SelectedIndexChanged);
            // 
            // txtISVName
            // 
            this.txtISVName.Location = new System.Drawing.Point(215, 72);
            this.txtISVName.Name = "txtISVName";
            this.txtISVName.Size = new System.Drawing.Size(134, 20);
            this.txtISVName.TabIndex = 194;
            this.txtISVName.TextChanged += new System.EventHandler(this.txtISVName_TextChanged);
            // 
            // lblPaidJobID
            // 
            this.lblPaidJobID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPaidJobID.Location = new System.Drawing.Point(13, 74);
            this.lblPaidJobID.Name = "lblPaidJobID";
            this.lblPaidJobID.Size = new System.Drawing.Size(60, 13);
            this.lblPaidJobID.TabIndex = 191;
            this.lblPaidJobID.Text = "ISV Code";
            // 
            // lblComplainerName
            // 
            this.lblComplainerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComplainerName.Location = new System.Drawing.Point(151, 75);
            this.lblComplainerName.Name = "lblComplainerName";
            this.lblComplainerName.Size = new System.Drawing.Size(63, 13);
            this.lblComplainerName.TabIndex = 193;
            this.lblComplainerName.Text = "ISV Name";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(215, 97);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(134, 20);
            this.txtAddress.TabIndex = 196;
            this.txtAddress.TextChanged += new System.EventHandler(this.txtAddress_TextChanged);
            // 
            // lblContactNo
            // 
            this.lblContactNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContactNo.Location = new System.Drawing.Point(162, 100);
            this.lblContactNo.Name = "lblContactNo";
            this.lblContactNo.Size = new System.Drawing.Size(52, 13);
            this.lblContactNo.TabIndex = 195;
            this.lblContactNo.Text = "Address";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(8, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(348, 71);
            this.groupBox1.TabIndex = 199;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Un Mapping Inter Service Search";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(80, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(177, 13);
            this.label4.TabIndex = 200;
            this.label4.Text = "Un Mapping Inter Service List";
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.LightSeaGreen;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(518, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(159, 13);
            this.label6.TabIndex = 210;
            this.label6.Text = "Mapping Inter Service List";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(431, 100);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 208;
            this.label7.Text = "Is Active?";
            // 
            // txtISVCode1
            // 
            this.txtISVCode1.Location = new System.Drawing.Point(496, 71);
            this.txtISVCode1.Name = "txtISVCode1";
            this.txtISVCode1.Size = new System.Drawing.Size(62, 20);
            this.txtISVCode1.TabIndex = 202;
            this.txtISVCode1.TextChanged += new System.EventHandler(this.txtISVCode1_TextChanged);
            // 
            // cmbIsActive1
            // 
            this.cmbIsActive1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbIsActive1.FormattingEnabled = true;
            this.cmbIsActive1.Location = new System.Drawing.Point(496, 97);
            this.cmbIsActive1.Name = "cmbIsActive1";
            this.cmbIsActive1.Size = new System.Drawing.Size(62, 21);
            this.cmbIsActive1.TabIndex = 207;
            this.cmbIsActive1.SelectedIndexChanged += new System.EventHandler(this.cmbIsActive1_SelectedIndexChanged);
            // 
            // txtISVName1
            // 
            this.txtISVName1.Location = new System.Drawing.Point(637, 72);
            this.txtISVName1.Name = "txtISVName1";
            this.txtISVName1.Size = new System.Drawing.Size(134, 20);
            this.txtISVName1.TabIndex = 204;
            this.txtISVName1.TextChanged += new System.EventHandler(this.txtISVName1_TextChanged);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(435, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 13);
            this.label8.TabIndex = 201;
            this.label8.Text = "ISV Code";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(573, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 203;
            this.label9.Text = "ISV Name";
            // 
            // txtAddress1
            // 
            this.txtAddress1.Location = new System.Drawing.Point(637, 97);
            this.txtAddress1.Name = "txtAddress1";
            this.txtAddress1.Size = new System.Drawing.Size(134, 20);
            this.txtAddress1.TabIndex = 206;
            this.txtAddress1.TextChanged += new System.EventHandler(this.txtAddress1_TextChanged);
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(584, 100);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 205;
            this.label10.Text = "Address";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(430, 50);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(348, 71);
            this.groupBox2.TabIndex = 209;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Mapping Inter Service Search";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.BackColor = System.Drawing.Color.DarkGray;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(366, 416);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(54, 17);
            this.label11.TabIndex = 211;
            this.label11.Text = "InActive";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmTechnicalSuperVSInterService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 475);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtISVCode1);
            this.Controls.Add(this.cmbIsActive1);
            this.Controls.Add(this.txtISVName1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtAddress1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtISVCode);
            this.Controls.Add(this.cmbIsActive);
            this.Controls.Add(this.txtISVName);
            this.Controls.Add(this.lblPaidJobID);
            this.Controls.Add(this.lblComplainerName);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblContactNo);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.lblTotalAll);
            this.Controls.Add(this.lblTotalMapping);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lvwMapping);
            this.Controls.Add(this.lvwInterServiceUnMapping);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmTechnicalSuperVSInterService";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Technical Super-VS-Inter Service";
            this.Load += new System.EventHandler(this.frmTechnicalSuperVSInterService_Load);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwInterServiceUnMapping;
        private System.Windows.Forms.ColumnHeader colInterServiceCode;
        private System.Windows.Forms.ColumnHeader colInterServiceName;
        private System.Windows.Forms.ColumnHeader colAddress;
        private System.Windows.Forms.ColumnHeader colISActive;
        private System.Windows.Forms.ListView lvwMapping;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblTotalMapping;
        private System.Windows.Forms.Label lblTotalAll;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDesignation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSupervisorID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblSupervisorName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtISVCode;
        private System.Windows.Forms.ComboBox cmbIsActive;
        private System.Windows.Forms.TextBox txtISVName;
        private System.Windows.Forms.Label lblPaidJobID;
        private System.Windows.Forms.Label lblComplainerName;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblContactNo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtISVCode1;
        private System.Windows.Forms.ComboBox cmbIsActive1;
        private System.Windows.Forms.TextBox txtISVName1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtAddress1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label11;
    }
}
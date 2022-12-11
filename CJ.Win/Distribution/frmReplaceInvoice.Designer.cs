namespace CJ.Win.Distribution
{
    partial class frmReplaceInvoice
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbBranchNmae = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblCreditLimit = new System.Windows.Forms.Label();
            this.lblOD = new System.Windows.Forms.Label();
            this.captionlblCreditLimit = new System.Windows.Forms.Label();
            this.CaptionlblOD = new System.Windows.Forms.Label();
            this.lblCustomerBal = new System.Windows.Forms.Label();
            this.captionlblCurrBal = new System.Windows.Forms.Label();
            this.lblDP = new System.Windows.Forms.Label();
            this.CaptionlblDP = new System.Windows.Forms.Label();
            this.lblAPO = new System.Windows.Forms.Label();
            this.CaptionAPO = new System.Windows.Forms.Label();
            this.lblTerritory = new System.Windows.Forms.Label();
            this.lblArea = new System.Windows.Forms.Label();
            this.lblCustomerTypeDescription = new System.Windows.Forms.Label();
            this.lblchannel = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDeliveryAdd = new System.Windows.Forms.TextBox();
            this.cmbSalesPerson = new System.Windows.Forms.ComboBox();
            this.dtInvoiceDate = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbWarehouse = new System.Windows.Forms.ComboBox();
            this.lblOrderNo = new System.Windows.Forms.Label();
            this.txtOrderNo = new System.Windows.Forms.TextBox();
            this.dgvLineItem = new System.Windows.Forms.DataGridView();
            this.txtProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFindProduct = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtProductDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btClose = new System.Windows.Forms.Button();
            this.btSave = new System.Windows.Forms.Button();
            this.rdbClaim = new System.Windows.Forms.RadioButton();
            this.rdbBreakage = new System.Windows.Forms.RadioButton();
            this.Total = new System.Windows.Forms.Label();
            this.txtTotalTk = new System.Windows.Forms.TextBox();
            this.rdoTradePromotion = new System.Windows.Forms.RadioButton();
            this.ctlCustomer1 = new CJ.Win.Control.ctlCustomer();
            this.txtDBComm = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNetAmount = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbBranchNmae);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.lblCreditLimit);
            this.groupBox1.Controls.Add(this.lblOD);
            this.groupBox1.Controls.Add(this.captionlblCreditLimit);
            this.groupBox1.Controls.Add(this.CaptionlblOD);
            this.groupBox1.Controls.Add(this.lblCustomerBal);
            this.groupBox1.Controls.Add(this.captionlblCurrBal);
            this.groupBox1.Controls.Add(this.lblDP);
            this.groupBox1.Controls.Add(this.CaptionlblDP);
            this.groupBox1.Controls.Add(this.lblAPO);
            this.groupBox1.Controls.Add(this.CaptionAPO);
            this.groupBox1.Controls.Add(this.lblTerritory);
            this.groupBox1.Controls.Add(this.lblArea);
            this.groupBox1.Controls.Add(this.lblCustomerTypeDescription);
            this.groupBox1.Controls.Add(this.lblchannel);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(465, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(419, 175);
            this.groupBox1.TabIndex = 160;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer Detail Information";
            // 
            // lbBranchNmae
            // 
            this.lbBranchNmae.AutoSize = true;
            this.lbBranchNmae.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBranchNmae.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lbBranchNmae.Location = new System.Drawing.Point(146, 76);
            this.lbBranchNmae.Name = "lbBranchNmae";
            this.lbBranchNmae.Size = new System.Drawing.Size(83, 13);
            this.lbBranchNmae.TabIndex = 103;
            this.lbBranchNmae.Text = "Branch Name";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(97, 76);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(51, 13);
            this.label16.TabIndex = 102;
            this.label16.Text = "Branch:";
            // 
            // lblCreditLimit
            // 
            this.lblCreditLimit.AutoSize = true;
            this.lblCreditLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreditLimit.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblCreditLimit.Location = new System.Drawing.Point(146, 153);
            this.lblCreditLimit.Name = "lblCreditLimit";
            this.lblCreditLimit.Size = new System.Drawing.Size(70, 13);
            this.lblCreditLimit.TabIndex = 101;
            this.lblCreditLimit.Text = "Credit Limit";
            // 
            // lblOD
            // 
            this.lblOD.AutoSize = true;
            this.lblOD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOD.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblOD.Location = new System.Drawing.Point(146, 124);
            this.lblOD.Name = "lblOD";
            this.lblOD.Size = new System.Drawing.Size(92, 13);
            this.lblOD.TabIndex = 56;
            this.lblOD.Text = "Other Discount";
            // 
            // captionlblCreditLimit
            // 
            this.captionlblCreditLimit.AutoSize = true;
            this.captionlblCreditLimit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.captionlblCreditLimit.Location = new System.Drawing.Point(70, 153);
            this.captionlblCreditLimit.Name = "captionlblCreditLimit";
            this.captionlblCreditLimit.Size = new System.Drawing.Size(78, 13);
            this.captionlblCreditLimit.TabIndex = 100;
            this.captionlblCreditLimit.Text = "Credit Limit :";
            // 
            // CaptionlblOD
            // 
            this.CaptionlblOD.AutoSize = true;
            this.CaptionlblOD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaptionlblOD.Location = new System.Drawing.Point(49, 123);
            this.CaptionlblOD.Name = "CaptionlblOD";
            this.CaptionlblOD.Size = new System.Drawing.Size(100, 13);
            this.CaptionlblOD.TabIndex = 55;
            this.CaptionlblOD.Text = "Other Discount :";
            // 
            // lblCustomerBal
            // 
            this.lblCustomerBal.AutoSize = true;
            this.lblCustomerBal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerBal.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblCustomerBal.Location = new System.Drawing.Point(146, 137);
            this.lblCustomerBal.Name = "lblCustomerBal";
            this.lblCustomerBal.Size = new System.Drawing.Size(109, 13);
            this.lblCustomerBal.TabIndex = 99;
            this.lblCustomerBal.Text = "Customer Balance";
            // 
            // captionlblCurrBal
            // 
            this.captionlblCurrBal.AutoSize = true;
            this.captionlblCurrBal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.captionlblCurrBal.Location = new System.Drawing.Point(31, 137);
            this.captionlblCurrBal.Name = "captionlblCurrBal";
            this.captionlblCurrBal.Size = new System.Drawing.Size(117, 13);
            this.captionlblCurrBal.TabIndex = 98;
            this.captionlblCurrBal.Text = "Customer Balance :";
            // 
            // lblDP
            // 
            this.lblDP.AutoSize = true;
            this.lblDP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDP.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblDP.Location = new System.Drawing.Point(146, 109);
            this.lblDP.Name = "lblDP";
            this.lblDP.Size = new System.Drawing.Size(70, 13);
            this.lblDP.TabIndex = 54;
            this.lblDP.Text = "Discount %";
            // 
            // CaptionlblDP
            // 
            this.CaptionlblDP.AutoSize = true;
            this.CaptionlblDP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaptionlblDP.Location = new System.Drawing.Point(15, 108);
            this.CaptionlblDP.Name = "CaptionlblDP";
            this.CaptionlblDP.Size = new System.Drawing.Size(134, 13);
            this.CaptionlblDP.TabIndex = 53;
            this.CaptionlblDP.Text = "Discount Percentage :";
            // 
            // lblAPO
            // 
            this.lblAPO.AutoSize = true;
            this.lblAPO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAPO.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblAPO.Location = new System.Drawing.Point(146, 94);
            this.lblAPO.Name = "lblAPO";
            this.lblAPO.Size = new System.Drawing.Size(77, 13);
            this.lblAPO.TabIndex = 52;
            this.lblAPO.Text = "Price Option";
            // 
            // CaptionAPO
            // 
            this.CaptionAPO.AutoSize = true;
            this.CaptionAPO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CaptionAPO.Location = new System.Drawing.Point(1, 94);
            this.CaptionAPO.Name = "CaptionAPO";
            this.CaptionAPO.Size = new System.Drawing.Size(152, 13);
            this.CaptionAPO.TabIndex = 51;
            this.CaptionAPO.Text = "Applicable Price Option : ";
            // 
            // lblTerritory
            // 
            this.lblTerritory.AutoSize = true;
            this.lblTerritory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTerritory.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblTerritory.Location = new System.Drawing.Point(146, 59);
            this.lblTerritory.Name = "lblTerritory";
            this.lblTerritory.Size = new System.Drawing.Size(122, 13);
            this.lblTerritory.TabIndex = 50;
            this.lblTerritory.Text = "Territory Description";
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblArea.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblArea.Location = new System.Drawing.Point(147, 44);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(101, 13);
            this.lblArea.TabIndex = 49;
            this.lblArea.Text = "Area Description";
            // 
            // lblCustomerTypeDescription
            // 
            this.lblCustomerTypeDescription.AutoSize = true;
            this.lblCustomerTypeDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustomerTypeDescription.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblCustomerTypeDescription.Location = new System.Drawing.Point(147, 28);
            this.lblCustomerTypeDescription.Name = "lblCustomerTypeDescription";
            this.lblCustomerTypeDescription.Size = new System.Drawing.Size(159, 13);
            this.lblCustomerTypeDescription.TabIndex = 48;
            this.lblCustomerTypeDescription.Text = "Customer Type Description";
            // 
            // lblchannel
            // 
            this.lblchannel.AutoSize = true;
            this.lblchannel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblchannel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblchannel.Location = new System.Drawing.Point(148, 14);
            this.lblchannel.Name = "lblchannel";
            this.lblchannel.Size = new System.Drawing.Size(121, 13);
            this.lblchannel.TabIndex = 47;
            this.lblchannel.Text = "Channel Description";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(87, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 13);
            this.label10.TabIndex = 46;
            this.label10.Text = "Territory :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(108, 44);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 45;
            this.label6.Text = "Area :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(50, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "Customer Type :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(88, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 43;
            this.label5.Text = "Channel :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(44, 161);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(52, 13);
            this.label9.TabIndex = 159;
            this.label9.Text = "Remarks:";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemarks.Location = new System.Drawing.Point(99, 158);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(360, 68);
            this.txtRemarks.TabIndex = 151;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 158;
            this.label3.Text = "Delivery Address:";
            // 
            // txtDeliveryAdd
            // 
            this.txtDeliveryAdd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeliveryAdd.Location = new System.Drawing.Point(100, 57);
            this.txtDeliveryAdd.Multiline = true;
            this.txtDeliveryAdd.Name = "txtDeliveryAdd";
            this.txtDeliveryAdd.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDeliveryAdd.Size = new System.Drawing.Size(359, 42);
            this.txtDeliveryAdd.TabIndex = 146;
            // 
            // cmbSalesPerson
            // 
            this.cmbSalesPerson.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSalesPerson.FormattingEnabled = true;
            this.cmbSalesPerson.Location = new System.Drawing.Point(100, 103);
            this.cmbSalesPerson.Name = "cmbSalesPerson";
            this.cmbSalesPerson.Size = new System.Drawing.Size(359, 21);
            this.cmbSalesPerson.TabIndex = 147;
            // 
            // dtInvoiceDate
            // 
            this.dtInvoiceDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtInvoiceDate.CustomFormat = "dd-MMM-yyyy";
            this.dtInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtInvoiceDate.Location = new System.Drawing.Point(304, 4);
            this.dtInvoiceDate.Name = "dtInvoiceDate";
            this.dtInvoiceDate.Size = new System.Drawing.Size(99, 20);
            this.dtInvoiceDate.TabIndex = 145;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 31);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 156;
            this.label7.Text = "Customer Code:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 106);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(93, 13);
            this.label8.TabIndex = 157;
            this.label8.Text = "Sales Person Info:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 133);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 155;
            this.label4.Text = "Warehouse Detail:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 154;
            this.label2.Text = "Invoice Date";
            // 
            // cmbWarehouse
            // 
            this.cmbWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWarehouse.FormattingEnabled = true;
            this.cmbWarehouse.Location = new System.Drawing.Point(99, 130);
            this.cmbWarehouse.Name = "cmbWarehouse";
            this.cmbWarehouse.Size = new System.Drawing.Size(360, 21);
            this.cmbWarehouse.TabIndex = 148;
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.AutoSize = true;
            this.lblOrderNo.Location = new System.Drawing.Point(53, 7);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(44, 13);
            this.lblOrderNo.TabIndex = 153;
            this.lblOrderNo.Text = "Ref No:";
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrderNo.Location = new System.Drawing.Point(100, 3);
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.Size = new System.Drawing.Size(119, 20);
            this.txtOrderNo.TabIndex = 144;
            // 
            // dgvLineItem
            // 
            this.dgvLineItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLineItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvLineItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLineItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtProductCode,
            this.btnFindProduct,
            this.txtProductDetails,
            this.txtUnitPrice,
            this.txtQuantity,
            this.txtTotalPrice,
            this.CurrentStock,
            this.ColProductID});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLineItem.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvLineItem.Location = new System.Drawing.Point(9, 232);
            this.dgvLineItem.Name = "dgvLineItem";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLineItem.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvLineItem.Size = new System.Drawing.Size(875, 200);
            this.dgvLineItem.TabIndex = 167;
            this.dgvLineItem.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLineItem_CellValueChanged);
            this.dgvLineItem.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgvLineItem_RowsRemoved);
            this.dgvLineItem.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLineItem_CellContentClick);
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
            // txtProductDetails
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtProductDetails.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtProductDetails.HeaderText = "Product Details";
            this.txtProductDetails.Name = "txtProductDetails";
            this.txtProductDetails.ReadOnly = true;
            this.txtProductDetails.Width = 240;
            // 
            // txtUnitPrice
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtUnitPrice.DefaultCellStyle = dataGridViewCellStyle3;
            this.txtUnitPrice.HeaderText = "Unit Price";
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.ReadOnly = true;
            this.txtUnitPrice.Width = 80;
            // 
            // txtQuantity
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            this.txtQuantity.DefaultCellStyle = dataGridViewCellStyle4;
            this.txtQuantity.HeaderText = "Quantity";
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Width = 80;
            // 
            // txtTotalPrice
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtTotalPrice.DefaultCellStyle = dataGridViewCellStyle5;
            this.txtTotalPrice.HeaderText = "Total Price";
            this.txtTotalPrice.Name = "txtTotalPrice";
            this.txtTotalPrice.ReadOnly = true;
            // 
            // CurrentStock
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CurrentStock.DefaultCellStyle = dataGridViewCellStyle6;
            this.CurrentStock.HeaderText = "Current Stock";
            this.CurrentStock.Name = "CurrentStock";
            this.CurrentStock.ReadOnly = true;
            // 
            // ColProductID
            // 
            this.ColProductID.HeaderText = "ProductID";
            this.ColProductID.Name = "ColProductID";
            this.ColProductID.ReadOnly = true;
            this.ColProductID.Visible = false;
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(811, 507);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(75, 23);
            this.btClose.TabIndex = 168;
            this.btClose.Text = "&Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(730, 507);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(75, 23);
            this.btSave.TabIndex = 169;
            this.btSave.Text = "&Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // rdbClaim
            // 
            this.rdbClaim.AutoSize = true;
            this.rdbClaim.Checked = true;
            this.rdbClaim.Location = new System.Drawing.Point(479, 7);
            this.rdbClaim.Name = "rdbClaim";
            this.rdbClaim.Size = new System.Drawing.Size(116, 17);
            this.rdbClaim.TabIndex = 170;
            this.rdbClaim.TabStop = true;
            this.rdbClaim.Text = "Claim Replacement";
            this.rdbClaim.UseVisualStyleBackColor = true;
            this.rdbClaim.CheckedChanged += new System.EventHandler(this.rdbClaim_CheckedChanged);
            // 
            // rdbBreakage
            // 
            this.rdbBreakage.AutoSize = true;
            this.rdbBreakage.Location = new System.Drawing.Point(749, 6);
            this.rdbBreakage.Name = "rdbBreakage";
            this.rdbBreakage.Size = new System.Drawing.Size(137, 17);
            this.rdbBreakage.TabIndex = 171;
            this.rdbBreakage.Text = "Breakage Replacement";
            this.rdbBreakage.UseVisualStyleBackColor = true;
            this.rdbBreakage.CheckedChanged += new System.EventHandler(this.rdbBreakage_CheckedChanged);
            // 
            // Total
            // 
            this.Total.AutoSize = true;
            this.Total.Location = new System.Drawing.Point(738, 438);
            this.Total.Name = "Total";
            this.Total.Size = new System.Drawing.Size(50, 13);
            this.Total.TabIndex = 172;
            this.Total.Text = "Total Tk.";
            // 
            // txtTotalTk
            // 
            this.txtTotalTk.Location = new System.Drawing.Point(799, 435);
            this.txtTotalTk.Name = "txtTotalTk";
            this.txtTotalTk.Size = new System.Drawing.Size(80, 20);
            this.txtTotalTk.TabIndex = 173;
            // 
            // rdoTradePromotion
            // 
            this.rdoTradePromotion.AutoSize = true;
            this.rdoTradePromotion.Location = new System.Drawing.Point(613, 8);
            this.rdoTradePromotion.Name = "rdoTradePromotion";
            this.rdoTradePromotion.Size = new System.Drawing.Size(103, 17);
            this.rdoTradePromotion.TabIndex = 174;
            this.rdoTradePromotion.Text = "Trade Promotion";
            this.rdoTradePromotion.UseVisualStyleBackColor = true;
            this.rdoTradePromotion.CheckedChanged += new System.EventHandler(this.rdoTradePromotion_CheckedChanged);
            // 
            // ctlCustomer1
            // 
            this.ctlCustomer1.Location = new System.Drawing.Point(100, 28);
            this.ctlCustomer1.Name = "ctlCustomer1";
            this.ctlCustomer1.Size = new System.Drawing.Size(438, 25);
            this.ctlCustomer1.TabIndex = 166;
            this.ctlCustomer1.ChangeSelection += new System.EventHandler(this.ctlCustomer1_ChangeSelection);
            // 
            // txtDBComm
            // 
            this.txtDBComm.Location = new System.Drawing.Point(799, 458);
            this.txtDBComm.Name = "txtDBComm";
            this.txtDBComm.Size = new System.Drawing.Size(80, 20);
            this.txtDBComm.TabIndex = 176;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(764, 462);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(22, 13);
            this.label11.TabIndex = 175;
            this.label11.Text = "DP";
            // 
            // txtNetAmount
            // 
            this.txtNetAmount.Location = new System.Drawing.Point(798, 482);
            this.txtNetAmount.Name = "txtNetAmount";
            this.txtNetAmount.Size = new System.Drawing.Size(80, 20);
            this.txtNetAmount.TabIndex = 177;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(722, 485);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(66, 13);
            this.label12.TabIndex = 178;
            this.label12.Text = "Net Amount:";
            // 
            // frmReplaceInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 542);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtNetAmount);
            this.Controls.Add(this.txtDBComm);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.rdoTradePromotion);
            this.Controls.Add(this.txtTotalTk);
            this.Controls.Add(this.Total);
            this.Controls.Add(this.rdbBreakage);
            this.Controls.Add(this.rdbClaim);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.dgvLineItem);
            this.Controls.Add(this.ctlCustomer1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDeliveryAdd);
            this.Controls.Add(this.cmbSalesPerson);
            this.Controls.Add(this.dtInvoiceDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbWarehouse);
            this.Controls.Add(this.lblOrderNo);
            this.Controls.Add(this.txtOrderNo);
            this.Name = "frmReplaceInvoice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Replace Invoice";
            this.Load += new System.EventHandler(this.frmReplaceInvoice_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CJ.Win.Control.ctlCustomer ctlCustomer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbBranchNmae;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblCreditLimit;
        private System.Windows.Forms.Label lblOD;
        private System.Windows.Forms.Label captionlblCreditLimit;
        private System.Windows.Forms.Label CaptionlblOD;
        private System.Windows.Forms.Label lblCustomerBal;
        private System.Windows.Forms.Label captionlblCurrBal;
        private System.Windows.Forms.Label lblDP;
        private System.Windows.Forms.Label CaptionlblDP;
        private System.Windows.Forms.Label lblAPO;
        private System.Windows.Forms.Label CaptionAPO;
        private System.Windows.Forms.Label lblTerritory;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.Label lblCustomerTypeDescription;
        private System.Windows.Forms.Label lblchannel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDeliveryAdd;
        private System.Windows.Forms.ComboBox cmbSalesPerson;
        private System.Windows.Forms.DateTimePicker dtInvoiceDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbWarehouse;
        private System.Windows.Forms.Label lblOrderNo;
        private System.Windows.Forms.TextBox txtOrderNo;
        private System.Windows.Forms.DataGridView dgvLineItem;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductCode;
        private System.Windows.Forms.DataGridViewButtonColumn btnFindProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtTotalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProductID;
        private System.Windows.Forms.RadioButton rdbClaim;
        private System.Windows.Forms.RadioButton rdbBreakage;
        private System.Windows.Forms.Label Total;
        private System.Windows.Forms.TextBox txtTotalTk;
        private System.Windows.Forms.RadioButton rdoTradePromotion;
        private System.Windows.Forms.TextBox txtDBComm;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtNetAmount;
        private System.Windows.Forms.Label label12;
    }
}
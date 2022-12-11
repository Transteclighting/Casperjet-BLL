namespace CJ.Win.Distribution
{
    partial class frmOrderFromCustomer
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.chkOrderType = new System.Windows.Forms.CheckBox();
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
            this.label7 = new System.Windows.Forms.Label();
            this.dgvLineItem = new System.Windows.Forms.DataGridView();
            this.txtProductCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnFindProduct = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtProductDetails = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtUnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtOrderQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colRevQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNOrderQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtQuantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColGrossTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentStock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColProductID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtNetPay = new System.Windows.Forms.TextBox();
            this.txtTradeDiscount = new System.Windows.Forms.TextBox();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.ctlCustomer1 = new CJ.Win.Control.ctlCustomer();
            this.btnCancle = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).BeginInit();
            this.SuspendLayout();
            // 
            // chkOrderType
            // 
            this.chkOrderType.AutoSize = true;
            this.chkOrderType.Location = new System.Drawing.Point(107, 151);
            this.chkOrderType.Name = "chkOrderType";
            this.chkOrderType.Size = new System.Drawing.Size(79, 17);
            this.chkOrderType.TabIndex = 152;
            this.chkOrderType.Text = "Cash Order";
            this.chkOrderType.UseVisualStyleBackColor = true;
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
            this.groupBox1.Location = new System.Drawing.Point(473, 3);
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
            this.label9.Location = new System.Drawing.Point(56, 187);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 159;
            this.label9.Text = "Remarks";
            // 
            // txtRemarks
            // 
            this.txtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRemarks.Location = new System.Drawing.Point(107, 184);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(753, 20);
            this.txtRemarks.TabIndex = 151;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 13);
            this.label3.TabIndex = 158;
            this.label3.Text = "Delivery Address:";
            // 
            // txtDeliveryAdd
            // 
            this.txtDeliveryAdd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDeliveryAdd.Location = new System.Drawing.Point(108, 34);
            this.txtDeliveryAdd.Multiline = true;
            this.txtDeliveryAdd.Name = "txtDeliveryAdd";
            this.txtDeliveryAdd.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDeliveryAdd.Size = new System.Drawing.Size(359, 37);
            this.txtDeliveryAdd.TabIndex = 146;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 13);
            this.label7.TabIndex = 156;
            this.label7.Text = "Customer Code:";
            // 
            // dgvLineItem
            // 
            this.dgvLineItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvLineItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLineItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtProductCode,
            this.btnFindProduct,
            this.txtProductDetails,
            this.txtUnitPrice,
            this.txtOrderQty,
            this.colRevQty,
            this.txtNOrderQty,
            this.txtQuantity,
            this.ColGrossTotal,
            this.CurrentStock,
            this.ColProductID});
            this.dgvLineItem.Location = new System.Drawing.Point(10, 210);
            this.dgvLineItem.Name = "dgvLineItem";
            this.dgvLineItem.Size = new System.Drawing.Size(877, 206);
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
            this.btnFindProduct.Width = 30;
            // 
            // txtProductDetails
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtProductDetails.DefaultCellStyle = dataGridViewCellStyle1;
            this.txtProductDetails.HeaderText = "Product Details";
            this.txtProductDetails.Name = "txtProductDetails";
            this.txtProductDetails.ReadOnly = true;
            this.txtProductDetails.Width = 240;
            // 
            // txtUnitPrice
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtUnitPrice.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtUnitPrice.HeaderText = "Unit Price";
            this.txtUnitPrice.Name = "txtUnitPrice";
            this.txtUnitPrice.ReadOnly = true;
            this.txtUnitPrice.Width = 80;
            // 
            // txtOrderQty
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtOrderQty.DefaultCellStyle = dataGridViewCellStyle3;
            this.txtOrderQty.HeaderText = "Qty (Cust)";
            this.txtOrderQty.Name = "txtOrderQty";
            this.txtOrderQty.ReadOnly = true;
            this.txtOrderQty.Width = 50;
            // 
            // colRevQty
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.colRevQty.DefaultCellStyle = dataGridViewCellStyle4;
            this.colRevQty.HeaderText = "Qty (AM)";
            this.colRevQty.Name = "colRevQty";
            this.colRevQty.ReadOnly = true;
            this.colRevQty.Width = 50;
            // 
            // txtNOrderQty
            // 
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.txtNOrderQty.DefaultCellStyle = dataGridViewCellStyle5;
            this.txtNOrderQty.HeaderText = "Qty (Nat)";
            this.txtNOrderQty.Name = "txtNOrderQty";
            this.txtNOrderQty.Width = 50;
            // 
            // txtQuantity
            // 
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            this.txtQuantity.DefaultCellStyle = dataGridViewCellStyle6;
            this.txtQuantity.HeaderText = "Qty";
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Width = 80;
            // 
            // ColGrossTotal
            // 
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ColGrossTotal.DefaultCellStyle = dataGridViewCellStyle7;
            this.ColGrossTotal.HeaderText = "Total";
            this.ColGrossTotal.Name = "ColGrossTotal";
            this.ColGrossTotal.ReadOnly = true;
            this.ColGrossTotal.Width = 90;
            // 
            // CurrentStock
            // 
            dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.CurrentStock.DefaultCellStyle = dataGridViewCellStyle8;
            this.CurrentStock.HeaderText = "Current Stock";
            this.CurrentStock.Name = "CurrentStock";
            this.CurrentStock.ReadOnly = true;
            this.CurrentStock.Width = 80;
            // 
            // ColProductID
            // 
            this.ColProductID.HeaderText = "ProductID";
            this.ColProductID.Name = "ColProductID";
            this.ColProductID.ReadOnly = true;
            this.ColProductID.Visible = false;
            // 
            // txtNetPay
            // 
            this.txtNetPay.Location = new System.Drawing.Point(771, 467);
            this.txtNetPay.Name = "txtNetPay";
            this.txtNetPay.ReadOnly = true;
            this.txtNetPay.Size = new System.Drawing.Size(114, 20);
            this.txtNetPay.TabIndex = 173;
            this.txtNetPay.Text = "0.00";
            this.txtNetPay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTradeDiscount
            // 
            this.txtTradeDiscount.BackColor = System.Drawing.SystemColors.Window;
            this.txtTradeDiscount.Location = new System.Drawing.Point(771, 443);
            this.txtTradeDiscount.Name = "txtTradeDiscount";
            this.txtTradeDiscount.Size = new System.Drawing.Size(114, 20);
            this.txtTradeDiscount.TabIndex = 172;
            this.txtTradeDiscount.Text = "0.00";
            this.txtTradeDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtTradeDiscount.TextChanged += new System.EventHandler(this.txtTradeDiscount_TextChanged);
            // 
            // txtTotalAmount
            // 
            this.txtTotalAmount.Location = new System.Drawing.Point(771, 420);
            this.txtTotalAmount.Name = "txtTotalAmount";
            this.txtTotalAmount.ReadOnly = true;
            this.txtTotalAmount.Size = new System.Drawing.Size(114, 20);
            this.txtTotalAmount.TabIndex = 171;
            this.txtTotalAmount.Text = "0.00";
            this.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(691, 470);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(79, 13);
            this.label22.TabIndex = 170;
            this.label22.Text = "Amount to Pay:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(687, 446);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(83, 13);
            this.label23.TabIndex = 169;
            this.label23.Text = "Trade Discount:";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(735, 423);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(34, 13);
            this.label24.TabIndex = 168;
            this.label24.Text = "Total:";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Location = new System.Drawing.Point(812, 490);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 26);
            this.btnSave.TabIndex = 174;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ctlCustomer1
            // 
            this.ctlCustomer1.Enabled = false;
            this.ctlCustomer1.Location = new System.Drawing.Point(108, 9);
            this.ctlCustomer1.Name = "ctlCustomer1";
            this.ctlCustomer1.Size = new System.Drawing.Size(359, 25);
            this.ctlCustomer1.TabIndex = 166;
            // 
            // btnCancle
            // 
            this.btnCancle.Location = new System.Drawing.Point(12, 484);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(67, 23);
            this.btnCancle.TabIndex = 175;
            this.btnCancle.Text = "Cancel";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // frmOrderFromCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 519);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtNetPay);
            this.Controls.Add(this.txtTradeDiscount);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.dgvLineItem);
            this.Controls.Add(this.ctlCustomer1);
            this.Controls.Add(this.chkOrderType);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtRemarks);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtDeliveryAdd);
            this.Controls.Add(this.label7);
            this.Name = "frmOrderFromCustomer";
            this.Text = "Order From Customer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLineItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CJ.Win.Control.ctlCustomer ctlCustomer1;
        private System.Windows.Forms.CheckBox chkOrderType;
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
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgvLineItem;
        private System.Windows.Forms.TextBox txtNetPay;
        private System.Windows.Forms.TextBox txtTradeDiscount;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductCode;
        private System.Windows.Forms.DataGridViewButtonColumn btnFindProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtProductDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtUnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtOrderQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRevQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtNOrderQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtQuantity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColGrossTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentStock;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColProductID;
        private System.Windows.Forms.Button btnCancle;
    }
}
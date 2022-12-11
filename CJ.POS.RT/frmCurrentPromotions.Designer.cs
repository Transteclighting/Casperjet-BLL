namespace CJ.POS.RT
{
    partial class frmCurrentPromotions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCurrentPromotions));
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPromoName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPromoNo = new System.Windows.Forms.TextBox();
            this.colIsActive = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvwCurrentPromotionList = new System.Windows.Forms.ListView();
            this.colPromotionNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.coldescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStartDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEndDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnClose = new System.Windows.Forms.Button();
            this.btPrint = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label4.Location = new System.Drawing.Point(63, 353);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 15);
            this.label4.TabIndex = 119;
            this.label4.Text = "Approved";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.MistyRose;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label3.Location = new System.Drawing.Point(13, 353);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 15);
            this.label3.TabIndex = 118;
            this.label3.Text = "Create";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label2.Location = new System.Drawing.Point(14, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 15);
            this.label2.TabIndex = 109;
            this.label2.Text = "Promotion Name:";
            // 
            // txtPromoName
            // 
            this.txtPromoName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtPromoName.Location = new System.Drawing.Point(123, 39);
            this.txtPromoName.Name = "txtPromoName";
            this.txtPromoName.Size = new System.Drawing.Size(345, 21);
            this.txtPromoName.TabIndex = 110;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.label1.Location = new System.Drawing.Point(32, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 15);
            this.label1.TabIndex = 103;
            this.label1.Text = "Promotion No:";
            // 
            // txtPromoNo
            // 
            this.txtPromoNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.txtPromoNo.Location = new System.Drawing.Point(123, 12);
            this.txtPromoNo.Name = "txtPromoNo";
            this.txtPromoNo.Size = new System.Drawing.Size(192, 21);
            this.txtPromoNo.TabIndex = 104;
            // 
            // colIsActive
            // 
            this.colIsActive.Text = "IsActive";
            this.colIsActive.Width = 70;
            // 
            // lvwCurrentPromotionList
            // 
            this.lvwCurrentPromotionList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwCurrentPromotionList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPromotionNo,
            this.coldescription,
            this.colStartDate,
            this.colEndDate,
            this.colIsActive,
            this.colStatus,
            this.colType});
            this.lvwCurrentPromotionList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.lvwCurrentPromotionList.FullRowSelect = true;
            this.lvwCurrentPromotionList.GridLines = true;
            this.lvwCurrentPromotionList.HideSelection = false;
            this.lvwCurrentPromotionList.Location = new System.Drawing.Point(12, 71);
            this.lvwCurrentPromotionList.MultiSelect = false;
            this.lvwCurrentPromotionList.Name = "lvwCurrentPromotionList";
            this.lvwCurrentPromotionList.Size = new System.Drawing.Size(732, 279);
            this.lvwCurrentPromotionList.TabIndex = 112;
            this.lvwCurrentPromotionList.UseCompatibleStateImageBehavior = false;
            this.lvwCurrentPromotionList.View = System.Windows.Forms.View.Details;
            // 
            // colPromotionNo
            // 
            this.colPromotionNo.Text = "Promotion No";
            this.colPromotionNo.Width = 108;
            // 
            // coldescription
            // 
            this.coldescription.Text = "Promotion Name";
            this.coldescription.Width = 189;
            // 
            // colStartDate
            // 
            this.colStartDate.Text = "Start Date";
            this.colStartDate.Width = 104;
            // 
            // colEndDate
            // 
            this.colEndDate.Text = "End Date";
            this.colEndDate.Width = 108;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 71;
            // 
            // colType
            // 
            this.colType.Text = "Type";
            this.colType.Width = 69;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnClose.Location = new System.Drawing.Point(750, 323);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(83, 27);
            this.btnClose.TabIndex = 114;
            this.btnClose.Tag = "M1.15";
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btPrint
            // 
            this.btPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btPrint.Location = new System.Drawing.Point(750, 71);
            this.btPrint.Name = "btPrint";
            this.btPrint.Size = new System.Drawing.Size(83, 27);
            this.btPrint.TabIndex = 116;
            this.btPrint.Tag = "M1.15";
            this.btPrint.Text = "Print";
            this.btPrint.UseVisualStyleBackColor = true;
            this.btPrint.Click += new System.EventHandler(this.btPrint_Click);
            // 
            // btnGo
            // 
            this.btnGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.btnGo.Location = new System.Drawing.Point(474, 36);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 26);
            this.btnGo.TabIndex = 111;
            this.btnGo.Text = "Get Data";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // frmCurrentPromotions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 379);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPromoName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPromoNo);
            this.Controls.Add(this.lvwCurrentPromotionList);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btPrint);
            this.Controls.Add(this.btnGo);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmCurrentPromotions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Current Promotions";
            this.Load += new System.EventHandler(this.frmCurrentPromotions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPromoName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPromoNo;
        private System.Windows.Forms.ColumnHeader colIsActive;
        private System.Windows.Forms.ListView lvwCurrentPromotionList;
        private System.Windows.Forms.ColumnHeader colPromotionNo;
        private System.Windows.Forms.ColumnHeader coldescription;
        private System.Windows.Forms.ColumnHeader colStartDate;
        private System.Windows.Forms.ColumnHeader colEndDate;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btPrint;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.ColumnHeader colType;
    }
}
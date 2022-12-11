namespace CJ.Win.Retail
{
    partial class frmOutletDisplayPosition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmOutletDisplayPosition));
            this.cmbOutlet = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtPositionName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chkIsActive = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtProductModel = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbRackName = new System.Windows.Forms.ComboBox();
            this.btnAddRack = new System.Windows.Forms.Button();
            this.dtSaleAfter = new System.Windows.Forms.DateTimePicker();
            this.cbSetSaleAfter = new System.Windows.Forms.CheckBox();
            this.ctlProduct1 = new CJ.Control.ctlProduct();
            this.cbOpenForAll = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cmbOutlet
            // 
            this.cmbOutlet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOutlet.FormattingEnabled = true;
            this.cmbOutlet.Location = new System.Drawing.Point(113, 12);
            this.cmbOutlet.Name = "cmbOutlet";
            this.cmbOutlet.Size = new System.Drawing.Size(418, 23);
            this.cmbOutlet.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(444, 202);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 27);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtPositionName
            // 
            this.txtPositionName.Location = new System.Drawing.Point(113, 130);
            this.txtPositionName.Name = "txtPositionName";
            this.txtPositionName.Size = new System.Drawing.Size(418, 23);
            this.txtPositionName.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Outlet Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 133);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Position Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Product Detail:";
            // 
            // chkIsActive
            // 
            this.chkIsActive.AutoSize = true;
            this.chkIsActive.Checked = true;
            this.chkIsActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsActive.Location = new System.Drawing.Point(113, 210);
            this.chkIsActive.Name = "chkIsActive";
            this.chkIsActive.Size = new System.Drawing.Size(76, 19);
            this.chkIsActive.TabIndex = 10;
            this.chkIsActive.Text = "Is Active";
            this.chkIsActive.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(349, 202);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 27);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Product Model:";
            // 
            // txtProductModel
            // 
            this.txtProductModel.Location = new System.Drawing.Point(113, 101);
            this.txtProductModel.Name = "txtProductModel";
            this.txtProductModel.ReadOnly = true;
            this.txtProductModel.Size = new System.Drawing.Size(418, 23);
            this.txtProductModel.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Rack Name:";
            // 
            // cmbRackName
            // 
            this.cmbRackName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRackName.FormattingEnabled = true;
            this.cmbRackName.Location = new System.Drawing.Point(113, 41);
            this.cmbRackName.Name = "cmbRackName";
            this.cmbRackName.Size = new System.Drawing.Size(370, 23);
            this.cmbRackName.TabIndex = 3;
            // 
            // btnAddRack
            // 
            this.btnAddRack.Location = new System.Drawing.Point(489, 40);
            this.btnAddRack.Name = "btnAddRack";
            this.btnAddRack.Size = new System.Drawing.Size(42, 27);
            this.btnAddRack.TabIndex = 13;
            this.btnAddRack.Text = "......";
            this.btnAddRack.UseVisualStyleBackColor = true;
            this.btnAddRack.Click += new System.EventHandler(this.btnAddRack_Click);
            // 
            // dtSaleAfter
            // 
            this.dtSaleAfter.CustomFormat = "dd-MMM-yyyy";
            this.dtSaleAfter.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.dtSaleAfter.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtSaleAfter.Location = new System.Drawing.Point(255, 159);
            this.dtSaleAfter.Name = "dtSaleAfter";
            this.dtSaleAfter.Size = new System.Drawing.Size(122, 23);
            this.dtSaleAfter.TabIndex = 15;
            this.dtSaleAfter.Visible = false;
            this.dtSaleAfter.ValueChanged += new System.EventHandler(this.dtAfterSale_ValueChanged);
            // 
            // cbSetSaleAfter
            // 
            this.cbSetSaleAfter.AutoSize = true;
            this.cbSetSaleAfter.Location = new System.Drawing.Point(113, 163);
            this.cbSetSaleAfter.Name = "cbSetSaleAfter";
            this.cbSetSaleAfter.Size = new System.Drawing.Size(136, 19);
            this.cbSetSaleAfter.TabIndex = 16;
            this.cbSetSaleAfter.Text = "Set Sale After Date";
            this.cbSetSaleAfter.UseVisualStyleBackColor = true;
            this.cbSetSaleAfter.CheckedChanged += new System.EventHandler(this.cbSetSaleAfter_CheckedChanged);
            // 
            // ctlProduct1
            // 
            this.ctlProduct1.Location = new System.Drawing.Point(113, 70);
            this.ctlProduct1.Name = "ctlProduct1";
            this.ctlProduct1.Size = new System.Drawing.Size(424, 25);
            this.ctlProduct1.TabIndex = 5;
            this.ctlProduct1.ChangeSelection += new System.EventHandler(this.ctlProduct1_ChangeSelection);
            // 
            // cbOpenForAll
            // 
            this.cbOpenForAll.AutoSize = true;
            this.cbOpenForAll.Location = new System.Drawing.Point(113, 185);
            this.cbOpenForAll.Name = "cbOpenForAll";
            this.cbOpenForAll.Size = new System.Drawing.Size(142, 19);
            this.cbOpenForAll.TabIndex = 17;
            this.cbOpenForAll.Text = "Open for all Models";
            this.cbOpenForAll.UseVisualStyleBackColor = true;
            this.cbOpenForAll.CheckedChanged += new System.EventHandler(this.cbOpenForAll_CheckedChanged);
            // 
            // frmOutletDisplayPosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(544, 241);
            this.Controls.Add(this.cbOpenForAll);
            this.Controls.Add(this.cbSetSaleAfter);
            this.Controls.Add(this.dtSaleAfter);
            this.Controls.Add(this.btnAddRack);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbRackName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtProductModel);
            this.Controls.Add(this.ctlProduct1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkIsActive);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPositionName);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cmbOutlet);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Bold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmOutletDisplayPosition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmOutletDisplayPosition";
            this.Load += new System.EventHandler(this.frmOutletDisplayPosition_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbOutlet;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtPositionName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkIsActive;
        private System.Windows.Forms.Button btnSave;
        private CJ.Control.ctlProduct ctlProduct1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtProductModel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbRackName;
        private System.Windows.Forms.Button btnAddRack;
        private System.Windows.Forms.DateTimePicker dtSaleAfter;
        private System.Windows.Forms.CheckBox cbSetSaleAfter;
        private System.Windows.Forms.CheckBox cbOpenForAll;
    }
}
namespace CJ.Win.Duty
{
    partial class frmStockPositionVAT
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmStockPositionVAT));
            this.btnPreview = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbWarehouseParent = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbWarehouse = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dtToDate = new System.Windows.Forms.DateTimePicker();
            this.dtFromDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.ctlProduct1 = new CJ.Control.ctlProduct();
            this.cmbPG = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbMAG = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbASG = new System.Windows.Forms.ComboBox();
            this.cmbAG = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.lblBrand = new System.Windows.Forms.Label();
            this.cmbBrand = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbReportType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnPreview
            // 
            this.btnPreview.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPreview.Location = new System.Drawing.Point(373, 225);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(87, 25);
            this.btnPreview.TabIndex = 0;
            this.btnPreview.Text = "Preview...";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(2, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Parent Warehouse:";
            // 
            // cmbWarehouseParent
            // 
            this.cmbWarehouseParent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWarehouseParent.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbWarehouseParent.FormattingEnabled = true;
            this.cmbWarehouseParent.Location = new System.Drawing.Point(120, 41);
            this.cmbWarehouseParent.Name = "cmbWarehouseParent";
            this.cmbWarehouseParent.Size = new System.Drawing.Size(340, 24);
            this.cmbWarehouseParent.TabIndex = 5;
            this.cmbWarehouseParent.SelectedIndexChanged += new System.EventHandler(this.cmbWarehouseParent_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(42, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Warehouse:";
            // 
            // cmbWarehouse
            // 
            this.cmbWarehouse.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWarehouse.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbWarehouse.FormattingEnabled = true;
            this.cmbWarehouse.Location = new System.Drawing.Point(120, 70);
            this.cmbWarehouse.Name = "cmbWarehouse";
            this.cmbWarehouse.Size = new System.Drawing.Size(340, 24);
            this.cmbWarehouse.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(246, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "To";
            // 
            // dtToDate
            // 
            this.dtToDate.CustomFormat = "dd-MMM-yyyy";
            this.dtToDate.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDate.Location = new System.Drawing.Point(273, 12);
            this.dtToDate.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtToDate.Name = "dtToDate";
            this.dtToDate.Size = new System.Drawing.Size(106, 23);
            this.dtToDate.TabIndex = 3;
            // 
            // dtFromDate
            // 
            this.dtFromDate.CustomFormat = "dd-MMM-yyyy";
            this.dtFromDate.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDate.Location = new System.Drawing.Point(120, 12);
            this.dtFromDate.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtFromDate.Name = "dtFromDate";
            this.dtFromDate.Size = new System.Drawing.Size(105, 23);
            this.dtFromDate.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(46, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "From Date:";
            // 
            // ctlProduct1
            // 
            this.ctlProduct1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ctlProduct1.Location = new System.Drawing.Point(120, 194);
            this.ctlProduct1.Name = "ctlProduct1";
            this.ctlProduct1.Size = new System.Drawing.Size(347, 25);
            this.ctlProduct1.TabIndex = 22;
            // 
            // cmbPG
            // 
            this.cmbPG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPG.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbPG.FormattingEnabled = true;
            this.cmbPG.Location = new System.Drawing.Point(120, 133);
            this.cmbPG.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbPG.Name = "cmbPG";
            this.cmbPG.Size = new System.Drawing.Size(148, 24);
            this.cmbPG.TabIndex = 14;
            this.cmbPG.SelectedIndexChanged += new System.EventHandler(this.cmbPG_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(92, 136);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 16);
            this.label10.TabIndex = 13;
            this.label10.Text = "PG";
            // 
            // cmbMAG
            // 
            this.cmbMAG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMAG.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMAG.FormattingEnabled = true;
            this.cmbMAG.Location = new System.Drawing.Point(120, 161);
            this.cmbMAG.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbMAG.Name = "cmbMAG";
            this.cmbMAG.Size = new System.Drawing.Size(148, 24);
            this.cmbMAG.TabIndex = 18;
            this.cmbMAG.SelectedIndexChanged += new System.EventHandler(this.cmbMAG_SelectedIndexChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(79, 165);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 16);
            this.label12.TabIndex = 17;
            this.label12.Text = "MAG";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(283, 167);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(25, 16);
            this.label13.TabIndex = 19;
            this.label13.Text = "AG";
            // 
            // cmbASG
            // 
            this.cmbASG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbASG.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbASG.FormattingEnabled = true;
            this.cmbASG.Location = new System.Drawing.Point(312, 133);
            this.cmbASG.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbASG.Name = "cmbASG";
            this.cmbASG.Size = new System.Drawing.Size(148, 24);
            this.cmbASG.TabIndex = 16;
            this.cmbASG.SelectedIndexChanged += new System.EventHandler(this.cmbASG_SelectedIndexChanged);
            // 
            // cmbAG
            // 
            this.cmbAG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAG.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAG.FormattingEnabled = true;
            this.cmbAG.Location = new System.Drawing.Point(312, 163);
            this.cmbAG.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbAG.Name = "cmbAG";
            this.cmbAG.Size = new System.Drawing.Size(148, 24);
            this.cmbAG.TabIndex = 20;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(276, 136);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(32, 16);
            this.label14.TabIndex = 15;
            this.label14.Text = "ASG";
            // 
            // lblBrand
            // 
            this.lblBrand.AutoSize = true;
            this.lblBrand.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrand.Location = new System.Drawing.Point(75, 105);
            this.lblBrand.Name = "lblBrand";
            this.lblBrand.Size = new System.Drawing.Size(41, 16);
            this.lblBrand.TabIndex = 8;
            this.lblBrand.Text = "Brand";
            // 
            // cmbBrand
            // 
            this.cmbBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBrand.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbBrand.FormattingEnabled = true;
            this.cmbBrand.Location = new System.Drawing.Point(120, 101);
            this.cmbBrand.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbBrand.Name = "cmbBrand";
            this.cmbBrand.Size = new System.Drawing.Size(148, 24);
            this.cmbBrand.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(269, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Type:";
            // 
            // cmbReportType
            // 
            this.cmbReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbReportType.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbReportType.FormattingEnabled = true;
            this.cmbReportType.Items.AddRange(new object[] {
            "Excluded Inter Tran",
            "Included Inter Tran"});
            this.cmbReportType.Location = new System.Drawing.Point(312, 101);
            this.cmbReportType.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbReportType.Name = "cmbReportType";
            this.cmbReportType.Size = new System.Drawing.Size(148, 24);
            this.cmbReportType.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft JhengHei", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(62, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 16);
            this.label6.TabIndex = 21;
            this.label6.Text = "Product:";
            // 
            // frmStockPositionVAT
            // 
            this.AcceptButton = this.btnPreview;
            this.ClientSize = new System.Drawing.Size(469, 255);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbReportType);
            this.Controls.Add(this.lblBrand);
            this.Controls.Add(this.cmbBrand);
            this.Controls.Add(this.cmbPG);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbMAG);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cmbASG);
            this.Controls.Add(this.cmbAG);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.ctlProduct1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtToDate);
            this.Controls.Add(this.dtFromDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbWarehouseParent);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbWarehouse);
            this.Controls.Add(this.btnPreview);
            this.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmStockPositionVAT";
            this.Text = "Stock Position";
            this.Load += new System.EventHandler(this.frmStockPositionVAT_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbWarehouseParent;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbWarehouse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtToDate;
        private System.Windows.Forms.DateTimePicker dtFromDate;
        private System.Windows.Forms.Label label3;
        private CJ.Control.ctlProduct ctlProduct1;
        private System.Windows.Forms.ComboBox cmbPG;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbMAG;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbASG;
        private System.Windows.Forms.ComboBox cmbAG;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblBrand;
        private System.Windows.Forms.ComboBox cmbBrand;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbReportType;
        private System.Windows.Forms.Label label6;

        #endregion

        //private System.Windows.Forms.Label label4;
        //private System.Windows.Forms.ComboBox cmbWarehouseParent;
        //private System.Windows.Forms.Label label5;
        //private System.Windows.Forms.ComboBox cmbWarehouse;
        //private System.Windows.Forms.Button btnPreview;
        //private System.Windows.Forms.Label label1;
        //private System.Windows.Forms.DateTimePicker dtToDate;
        //private System.Windows.Forms.DateTimePicker dtFromDate;
        //private System.Windows.Forms.Label label3;
        //private System.Windows.Forms.ComboBox cmbPG;
        //private System.Windows.Forms.Label label10;
        //private System.Windows.Forms.ComboBox cmbMAG;
        //private System.Windows.Forms.Label label12;
        //private System.Windows.Forms.Label label13;
        //private System.Windows.Forms.ComboBox cmbASG;
        //private System.Windows.Forms.ComboBox cmbAG;
        //private System.Windows.Forms.Label label14;
        //private System.Windows.Forms.Label lblBrand;
        //private System.Windows.Forms.ComboBox cmbBrand;
        //private CJ.Control.ctlProduct ctlProduct1;
        //private System.Windows.Forms.Label lblProduct;
        //private System.Windows.Forms.Label label2;
    }
}
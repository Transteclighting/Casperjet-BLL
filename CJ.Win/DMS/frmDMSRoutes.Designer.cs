namespace CJ.Win.DMS
{
    partial class frmDMSRoutes
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.lvwRoutes = new System.Windows.Forms.ListView();
            this.colCustomer = new System.Windows.Forms.ColumnHeader();
            this.colRoute = new System.Windows.Forms.ColumnHeader();
            this.colRouteType = new System.Windows.Forms.ColumnHeader();
            this.colDsr = new System.Windows.Forms.ColumnHeader();
            this.colDesignation = new System.Windows.Forms.ColumnHeader();
            this.colDeliveryDay = new System.Windows.Forms.ColumnHeader();
            this.colOrder = new System.Windows.Forms.ColumnHeader();
            this.colVisitDay = new System.Windows.Forms.ColumnHeader();
            this.colVisitF = new System.Windows.Forms.ColumnHeader();
            this.colGEO = new System.Windows.Forms.ColumnHeader();
            this.colRAName = new System.Windows.Forms.ColumnHeader();
            this.colRAPh = new System.Windows.Forms.ColumnHeader();
            this.colDriverName = new System.Windows.Forms.ColumnHeader();
            this.colDriverPh = new System.Windows.Forms.ColumnHeader();
            this.colVehicl = new System.Windows.Forms.ColumnHeader();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.lblOrderNo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(789, 90);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(77, 27);
            this.btnAdd.TabIndex = 66;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lvwRoutes
            // 
            this.lvwRoutes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwRoutes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colCustomer,
            this.colRoute,
            this.colRouteType,
            this.colDsr,
            this.colDesignation,
            this.colDeliveryDay,
            this.colOrder,
            this.colVisitDay,
            this.colVisitF,
            this.colGEO,
            this.colRAName,
            this.colRAPh,
            this.colDriverName,
            this.colDriverPh,
            this.colVehicl});
            this.lvwRoutes.FullRowSelect = true;
            this.lvwRoutes.GridLines = true;
            this.lvwRoutes.Location = new System.Drawing.Point(12, 38);
            this.lvwRoutes.Name = "lvwRoutes";
            this.lvwRoutes.Size = new System.Drawing.Size(771, 358);
            this.lvwRoutes.TabIndex = 67;
            this.lvwRoutes.UseCompatibleStateImageBehavior = false;
            this.lvwRoutes.View = System.Windows.Forms.View.Details;
            this.lvwRoutes.DoubleClick += new System.EventHandler(this.lvwRoutes_DoubleClick);
            // 
            // colCustomer
            // 
            this.colCustomer.Text = "Customer Name";
            this.colCustomer.Width = 150;
            // 
            // colRoute
            // 
            this.colRoute.Text = "Route Name";
            this.colRoute.Width = 150;
            // 
            // colRouteType
            // 
            this.colRouteType.Text = "Route Type";
            this.colRouteType.Width = 100;
            // 
            // colDsr
            // 
            this.colDsr.Text = "DSR Name";
            this.colDsr.Width = 150;
            // 
            // colDesignation
            // 
            this.colDesignation.Text = "Designation";
            this.colDesignation.Width = 80;
            // 
            // colDeliveryDay
            // 
            this.colDeliveryDay.Text = "Delivery Day";
            this.colDeliveryDay.Width = 99;
            // 
            // colOrder
            // 
            this.colOrder.Text = "Order Type";
            this.colOrder.Width = 100;
            // 
            // colVisitDay
            // 
            this.colVisitDay.Text = "Visit Day";
            this.colVisitDay.Width = 100;
            // 
            // colVisitF
            // 
            this.colVisitF.Text = "Visit Frequency";
            this.colVisitF.Width = 100;
            // 
            // colGEO
            // 
            this.colGEO.Text = "Geo Type";
            this.colGEO.Width = 100;
            // 
            // colRAName
            // 
            this.colRAName.Text = "RA Name";
            this.colRAName.Width = 150;
            // 
            // colRAPh
            // 
            this.colRAPh.Text = "RA PH No.";
            this.colRAPh.Width = 100;
            // 
            // colDriverName
            // 
            this.colDriverName.Text = "Driver Name";
            this.colDriverName.Width = 150;
            // 
            // colDriverPh
            // 
            this.colDriverPh.Text = "Driver PH No.";
            this.colDriverPh.Width = 100;
            // 
            // colVehicl
            // 
            this.colVehicl.Text = "Vehicle No.";
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(789, 134);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(77, 27);
            this.btnEdit.TabIndex = 68;
            this.btnEdit.Text = "Update";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(789, 360);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(77, 27);
            this.btnClose.TabIndex = 69;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCustomerName.Location = new System.Drawing.Point(120, 12);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(250, 20);
            this.txtCustomerName.TabIndex = 71;
            this.txtCustomerName.TextChanged += new System.EventHandler(this.txtCustomerName_TextChanged);
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.AutoSize = true;
            this.lblOrderNo.Location = new System.Drawing.Point(9, 15);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(105, 13);
            this.lblOrderNo.TabIndex = 70;
            this.lblOrderNo.Text = "Customer Name Like";
            // 
            // frmDMSRoutes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 408);
            this.Controls.Add(this.txtCustomerName);
            this.Controls.Add(this.lblOrderNo);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.lvwRoutes);
            this.Controls.Add(this.btnAdd);
            this.Name = "frmDMSRoutes";
            this.Text = "Routes Details";
            this.Load += new System.EventHandler(this.frmDMSRoutes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView lvwRoutes;
        private System.Windows.Forms.ColumnHeader colRoute;
        private System.Windows.Forms.ColumnHeader colDesignation;
        private System.Windows.Forms.ColumnHeader colDeliveryDay;
        private System.Windows.Forms.ColumnHeader colOrder;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColumnHeader colVisitDay;
        private System.Windows.Forms.ColumnHeader colCustomer;
        private System.Windows.Forms.ColumnHeader colRouteType;
        private System.Windows.Forms.ColumnHeader colDsr;
        private System.Windows.Forms.ColumnHeader colVisitF;
        private System.Windows.Forms.ColumnHeader colGEO;
        private System.Windows.Forms.ColumnHeader colRAName;
        private System.Windows.Forms.ColumnHeader colRAPh;
        private System.Windows.Forms.ColumnHeader colDriverName;
        private System.Windows.Forms.ColumnHeader colDriverPh;
        private System.Windows.Forms.ColumnHeader colVehicl;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Label lblOrderNo;
    }
}
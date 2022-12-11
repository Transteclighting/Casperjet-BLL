namespace CJ.Win.HR
{
    partial class frmPositionManagement
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPositionManagement));
            this.assignToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbCompany = new System.Windows.Forms.ComboBox();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeviewImage = new System.Windows.Forms.ImageList(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.treeview = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unassignToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.markAsVacantToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jobSpecificationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jobDescriptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.manpowerRequisitionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageListDrag = new System.Windows.Forms.ImageList(this.components);
            this.btnRefresh = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lvwItem = new System.Windows.Forms.ListView();
            this.colPositionCode = new System.Windows.Forms.ColumnHeader();
            this.colPositionName = new System.Windows.Forms.ColumnHeader();
            this.colStatus = new System.Windows.Forms.ColumnHeader();
            this.colDepartment = new System.Windows.Forms.ColumnHeader();
            this.colAreaName = new System.Windows.Forms.ColumnHeader();
            this.colTerritoryName = new System.Windows.Forms.ColumnHeader();
            this.colCustomer = new System.Windows.Forms.ColumnHeader();
            this.cmbCompanyList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRefreshList = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // assignToolStripMenuItem
            // 
            this.assignToolStripMenuItem.Name = "assignToolStripMenuItem";
            this.assignToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.assignToolStripMenuItem.Text = "Assign/Reassign";
            this.assignToolStripMenuItem.Click += new System.EventHandler(this.assignToolStripMenuItem_Click);
            // 
            // cmbCompany
            // 
            this.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompany.FormattingEnabled = true;
            this.cmbCompany.Location = new System.Drawing.Point(60, 7);
            this.cmbCompany.Name = "cmbCompany";
            this.cmbCompany.Size = new System.Drawing.Size(270, 21);
            this.cmbCompany.TabIndex = 25;
            this.cmbCompany.SelectedIndexChanged += new System.EventHandler(this.cmbCompany_SelectedIndexChanged);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click_1);
            // 
            // treeviewImage
            // 
            this.treeviewImage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeviewImage.ImageStream")));
            this.treeviewImage.TransparentColor = System.Drawing.Color.Transparent;
            this.treeviewImage.Images.SetKeyName(0, "Admin.gif");
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(179, 22);
            this.toolStripMenuItem2.Text = "Edit";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // treeview
            // 
            this.treeview.AllowDrop = true;
            this.treeview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.treeview.ContextMenuStrip = this.contextMenuStrip1;
            this.treeview.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeview.Indent = 19;
            this.treeview.Location = new System.Drawing.Point(6, 37);
            this.treeview.Name = "treeview";
            this.treeview.ShowNodeToolTips = true;
            this.treeview.Size = new System.Drawing.Size(540, 275);
            this.treeview.TabIndex = 24;
            this.treeview.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.treeview_GiveFeedback);
            this.treeview.DragLeave += new System.EventHandler(this.treeview_DragLeave);
            this.treeview.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeview_DragDrop);
            this.treeview.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeview_AfterSelect);
            this.treeview.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeview_DragEnter);
            this.treeview.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeview_ItemDrag);
            this.treeview.DragOver += new System.Windows.Forms.DragEventHandler(this.treeview_DragOver);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.toolStripMenuItem2,
            this.assignToolStripMenuItem,
            this.unassignToolStripMenuItem,
            this.markAsVacantToolStripMenuItem,
            this.jobSpecificationToolStripMenuItem,
            this.jobDescriptionToolStripMenuItem,
            this.historyToolStripMenuItem,
            this.toolStripSeparator1,
            this.deleteToolStripMenuItem,
            this.manpowerRequisitionToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(180, 252);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // unassignToolStripMenuItem
            // 
            this.unassignToolStripMenuItem.Name = "unassignToolStripMenuItem";
            this.unassignToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.unassignToolStripMenuItem.Text = "Unassign";
            this.unassignToolStripMenuItem.Click += new System.EventHandler(this.unassignToolStripMenuItem_Click);
            // 
            // markAsVacantToolStripMenuItem
            // 
            this.markAsVacantToolStripMenuItem.Name = "markAsVacantToolStripMenuItem";
            this.markAsVacantToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.markAsVacantToolStripMenuItem.Text = "Mark as Vacant";
            this.markAsVacantToolStripMenuItem.Click += new System.EventHandler(this.markAsVacantToolStripMenuItem_Click);
            // 
            // jobSpecificationToolStripMenuItem
            // 
            this.jobSpecificationToolStripMenuItem.Name = "jobSpecificationToolStripMenuItem";
            this.jobSpecificationToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.jobSpecificationToolStripMenuItem.Text = "Job Specification";
            this.jobSpecificationToolStripMenuItem.Click += new System.EventHandler(this.jobSpecificationToolStripMenuItem_Click);
            // 
            // jobDescriptionToolStripMenuItem
            // 
            this.jobDescriptionToolStripMenuItem.Name = "jobDescriptionToolStripMenuItem";
            this.jobDescriptionToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.jobDescriptionToolStripMenuItem.Text = "Job Description";
            this.jobDescriptionToolStripMenuItem.Click += new System.EventHandler(this.jobDescriptionToolStripMenuItem_Click);
            // 
            // historyToolStripMenuItem
            // 
            this.historyToolStripMenuItem.Name = "historyToolStripMenuItem";
            this.historyToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.historyToolStripMenuItem.Text = "History";
            this.historyToolStripMenuItem.Click += new System.EventHandler(this.historyToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(176, 6);
            // 
            // manpowerRequisitionToolStripMenuItem
            // 
            this.manpowerRequisitionToolStripMenuItem.Name = "manpowerRequisitionToolStripMenuItem";
            this.manpowerRequisitionToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.manpowerRequisitionToolStripMenuItem.Text = "Manpower Requisition";
            this.manpowerRequisitionToolStripMenuItem.Click += new System.EventHandler(this.manpowerRequisitionToolStripMenuItem_Click);
            // 
            // imageListDrag
            // 
            this.imageListDrag.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageListDrag.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListDrag.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(336, 6);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 26;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "d.png");
            this.imageList1.Images.SetKeyName(1, "e.png");
            this.imageList1.Images.SetKeyName(2, "f.png");
            this.imageList1.Images.SetKeyName(3, "a.png");
            this.imageList1.Images.SetKeyName(4, "b.png");
            this.imageList1.Images.SetKeyName(5, "c.png");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Company";
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(15, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(560, 344);
            this.tabControl1.TabIndex = 28;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.treeview);
            this.tabPage1.Controls.Add(this.cmbCompany);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btnRefresh);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(552, 318);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tree View";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lvwItem);
            this.tabPage2.Controls.Add(this.cmbCompanyList);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Controls.Add(this.btnRefreshList);
            this.tabPage2.Location = new System.Drawing.Point(4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(552, 318);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "List View";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lvwItem
            // 
            this.lvwItem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colPositionCode,
            this.colPositionName,
            this.colStatus,
            this.colDepartment,
            this.colAreaName,
            this.colTerritoryName,
            this.colCustomer});
            this.lvwItem.FullRowSelect = true;
            this.lvwItem.GridLines = true;
            this.lvwItem.Location = new System.Drawing.Point(10, 38);
            this.lvwItem.MultiSelect = false;
            this.lvwItem.Name = "lvwItem";
            this.lvwItem.Size = new System.Drawing.Size(536, 274);
            this.lvwItem.TabIndex = 31;
            this.lvwItem.UseCompatibleStateImageBehavior = false;
            this.lvwItem.View = System.Windows.Forms.View.Details;
            // 
            // colPositionCode
            // 
            this.colPositionCode.Text = "Position Code";
            this.colPositionCode.Width = 82;
            // 
            // colPositionName
            // 
            this.colPositionName.Text = "Position Name";
            this.colPositionName.Width = 113;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 75;
            // 
            // colDepartment
            // 
            this.colDepartment.Text = "Department";
            this.colDepartment.Width = 97;
            // 
            // colAreaName
            // 
            this.colAreaName.Text = "Area Name";
            this.colAreaName.Width = 88;
            // 
            // colTerritoryName
            // 
            this.colTerritoryName.Text = "Territory Name";
            this.colTerritoryName.Width = 77;
            // 
            // colCustomer
            // 
            this.colCustomer.Text = "Customer";
            // 
            // cmbCompanyList
            // 
            this.cmbCompanyList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCompanyList.FormattingEnabled = true;
            this.cmbCompanyList.Location = new System.Drawing.Point(59, 6);
            this.cmbCompanyList.Name = "cmbCompanyList";
            this.cmbCompanyList.Size = new System.Drawing.Size(270, 21);
            this.cmbCompanyList.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Company";
            // 
            // btnRefreshList
            // 
            this.btnRefreshList.Location = new System.Drawing.Point(335, 5);
            this.btnRefreshList.Name = "btnRefreshList";
            this.btnRefreshList.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshList.TabIndex = 29;
            this.btnRefreshList.Text = "Refresh";
            this.btnRefreshList.UseVisualStyleBackColor = true;
            this.btnRefreshList.Click += new System.EventHandler(this.btnRefreshList_Click);
            // 
            // frmPositionManagement
            // 
            this.AcceptButton = this.btnRefresh;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 378);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmPositionManagement";
            this.Text = "Position Management";
            this.Load += new System.EventHandler(this.frmPositionManagement_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem assignToolStripMenuItem;
        private System.Windows.Forms.ComboBox cmbCompany;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ImageList treeviewImage;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.TreeView treeview;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ImageList imageListDrag;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem markAsVacantToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unassignToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cmbCompanyList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRefreshList;
        private System.Windows.Forms.ListView lvwItem;
        private System.Windows.Forms.ColumnHeader colPositionCode;
        private System.Windows.Forms.ColumnHeader colPositionName;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ColumnHeader colDepartment;
        private System.Windows.Forms.ColumnHeader colAreaName;
        private System.Windows.Forms.ColumnHeader colTerritoryName;
        private System.Windows.Forms.ColumnHeader colCustomer;
        private System.Windows.Forms.ToolStripMenuItem jobSpecificationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jobDescriptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manpowerRequisitionToolStripMenuItem;
    }
}
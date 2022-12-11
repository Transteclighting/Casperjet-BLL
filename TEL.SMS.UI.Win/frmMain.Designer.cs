namespace TEL.SMS.UI.Win
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.mnuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.activiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PersonsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sMSGroupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.requestForGroupSMSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.requestForIndividualSMSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.requestForManySMSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listOfMessagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateProductInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.receivingMessagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sMSUsageReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.warrantyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.warrantyActivationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.warrantyRegisterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.warrantyRegisterReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iTProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invoicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showroomStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marketVisitReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aLLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stMain = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelUserGroup = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnuMain.SuspendLayout();
            this.stMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuMain
            // 
            this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.activiesToolStripMenuItem,
            this.adminToolStripMenuItem,
            this.warrantyToolStripMenuItem,
            this.iTProductToolStripMenuItem,
            this.reportToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.mnuMain.Location = new System.Drawing.Point(0, 0);
            this.mnuMain.Name = "mnuMain";
            this.mnuMain.Size = new System.Drawing.Size(680, 24);
            this.mnuMain.TabIndex = 1;
            this.mnuMain.Text = "menuStrip1";
            this.mnuMain.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.mnuMain_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // activiesToolStripMenuItem
            // 
            this.activiesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PersonsToolStripMenuItem,
            this.sMSGroupsToolStripMenuItem,
            this.requestForGroupSMSToolStripMenuItem,
            this.requestForIndividualSMSToolStripMenuItem,
            this.requestForManySMSToolStripMenuItem,
            this.listOfMessagesToolStripMenuItem});
            this.activiesToolStripMenuItem.Name = "activiesToolStripMenuItem";
            this.activiesToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.activiesToolStripMenuItem.Text = "Activies";
            // 
            // PersonsToolStripMenuItem
            // 
            this.PersonsToolStripMenuItem.Name = "PersonsToolStripMenuItem";
            this.PersonsToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.PersonsToolStripMenuItem.Text = "Persons";
            this.PersonsToolStripMenuItem.Click += new System.EventHandler(this.PersonsToolStripMenuItem_Click);
            // 
            // sMSGroupsToolStripMenuItem
            // 
            this.sMSGroupsToolStripMenuItem.Name = "sMSGroupsToolStripMenuItem";
            this.sMSGroupsToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.sMSGroupsToolStripMenuItem.Text = "SMSGroups";
            this.sMSGroupsToolStripMenuItem.Click += new System.EventHandler(this.sMSGroupsToolStripMenuItem_Click);
            // 
            // requestForGroupSMSToolStripMenuItem
            // 
            this.requestForGroupSMSToolStripMenuItem.Name = "requestForGroupSMSToolStripMenuItem";
            this.requestForGroupSMSToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.requestForGroupSMSToolStripMenuItem.Text = "Request for Group SMS";
            this.requestForGroupSMSToolStripMenuItem.Click += new System.EventHandler(this.requestForGroupSMSToolStripMenuItem_Click);
            // 
            // requestForIndividualSMSToolStripMenuItem
            // 
            this.requestForIndividualSMSToolStripMenuItem.Name = "requestForIndividualSMSToolStripMenuItem";
            this.requestForIndividualSMSToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.requestForIndividualSMSToolStripMenuItem.Text = "Request for Individual SMS";
            this.requestForIndividualSMSToolStripMenuItem.Click += new System.EventHandler(this.requestForIndividualSMSToolStripMenuItem_Click);
            // 
            // requestForManySMSToolStripMenuItem
            // 
            this.requestForManySMSToolStripMenuItem.Name = "requestForManySMSToolStripMenuItem";
            this.requestForManySMSToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.requestForManySMSToolStripMenuItem.Text = "Request for Many SMS";
            this.requestForManySMSToolStripMenuItem.Click += new System.EventHandler(this.requestForManySMSToolStripMenuItem_Click);
            // 
            // listOfMessagesToolStripMenuItem
            // 
            this.listOfMessagesToolStripMenuItem.Name = "listOfMessagesToolStripMenuItem";
            this.listOfMessagesToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.listOfMessagesToolStripMenuItem.Text = "List of Messages";
            this.listOfMessagesToolStripMenuItem.Click += new System.EventHandler(this.listOfMessagesToolStripMenuItem_Click);
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.updateProductInfoToolStripMenuItem,
            this.receivingMessagesToolStripMenuItem,
            this.sMSUsageReportToolStripMenuItem});
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.adminToolStripMenuItem.Text = "Admin";
            // 
            // updateProductInfoToolStripMenuItem
            // 
            this.updateProductInfoToolStripMenuItem.Name = "updateProductInfoToolStripMenuItem";
            this.updateProductInfoToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.updateProductInfoToolStripMenuItem.Text = "Update Product Info";
            this.updateProductInfoToolStripMenuItem.Click += new System.EventHandler(this.updateProductInfoToolStripMenuItem_Click);
            // 
            // receivingMessagesToolStripMenuItem
            // 
            this.receivingMessagesToolStripMenuItem.Name = "receivingMessagesToolStripMenuItem";
            this.receivingMessagesToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.receivingMessagesToolStripMenuItem.Text = "Receiving Messages";
            this.receivingMessagesToolStripMenuItem.Click += new System.EventHandler(this.receivingMessagesToolStripMenuItem_Click);
            // 
            // sMSUsageReportToolStripMenuItem
            // 
            this.sMSUsageReportToolStripMenuItem.Name = "sMSUsageReportToolStripMenuItem";
            this.sMSUsageReportToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.sMSUsageReportToolStripMenuItem.Text = "SMS Usage Report";
            this.sMSUsageReportToolStripMenuItem.Click += new System.EventHandler(this.sMSUsageReportToolStripMenuItem_Click);
            // 
            // warrantyToolStripMenuItem
            // 
            this.warrantyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.warrantyActivationToolStripMenuItem,
            this.warrantyRegisterToolStripMenuItem,
            this.warrantyRegisterReportToolStripMenuItem});
            this.warrantyToolStripMenuItem.Name = "warrantyToolStripMenuItem";
            this.warrantyToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.warrantyToolStripMenuItem.Text = "Warranty";
            // 
            // warrantyActivationToolStripMenuItem
            // 
            this.warrantyActivationToolStripMenuItem.Name = "warrantyActivationToolStripMenuItem";
            this.warrantyActivationToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.warrantyActivationToolStripMenuItem.Text = "Warranty Activation";
            this.warrantyActivationToolStripMenuItem.Click += new System.EventHandler(this.warrantyActivationToolStripMenuItem_Click);
            // 
            // warrantyRegisterToolStripMenuItem
            // 
            this.warrantyRegisterToolStripMenuItem.Name = "warrantyRegisterToolStripMenuItem";
            this.warrantyRegisterToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.warrantyRegisterToolStripMenuItem.Text = "Warranty Register";
            this.warrantyRegisterToolStripMenuItem.Click += new System.EventHandler(this.warrantyRegisterToolStripMenuItem_Click);
            // 
            // warrantyRegisterReportToolStripMenuItem
            // 
            this.warrantyRegisterReportToolStripMenuItem.Name = "warrantyRegisterReportToolStripMenuItem";
            this.warrantyRegisterReportToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.warrantyRegisterReportToolStripMenuItem.Text = "Warranty Register Report";
            this.warrantyRegisterReportToolStripMenuItem.Click += new System.EventHandler(this.warrantyRegisterReportToolStripMenuItem_Click);
            // 
            // iTProductToolStripMenuItem
            // 
            this.iTProductToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.invoicesToolStripMenuItem});
            this.iTProductToolStripMenuItem.Name = "iTProductToolStripMenuItem";
            this.iTProductToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.iTProductToolStripMenuItem.Text = "IT Product";
            this.iTProductToolStripMenuItem.Click += new System.EventHandler(this.iTProductToolStripMenuItem_Click);
            // 
            // invoicesToolStripMenuItem
            // 
            this.invoicesToolStripMenuItem.Name = "invoicesToolStripMenuItem";
            this.invoicesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.invoicesToolStripMenuItem.Text = "Invoices";
            this.invoicesToolStripMenuItem.Click += new System.EventHandler(this.invoicesToolStripMenuItem_Click);
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stockReportToolStripMenuItem,
            this.marketVisitReportToolStripMenuItem});
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.reportToolStripMenuItem.Text = "Report";
            // 
            // stockReportToolStripMenuItem
            // 
            this.stockReportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showroomStockToolStripMenuItem});
            this.stockReportToolStripMenuItem.Name = "stockReportToolStripMenuItem";
            this.stockReportToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.stockReportToolStripMenuItem.Text = "Stock Report";
            this.stockReportToolStripMenuItem.Click += new System.EventHandler(this.stockReportToolStripMenuItem_Click);
            // 
            // showroomStockToolStripMenuItem
            // 
            this.showroomStockToolStripMenuItem.Name = "showroomStockToolStripMenuItem";
            this.showroomStockToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.showroomStockToolStripMenuItem.Text = "Showroom Stock";
            this.showroomStockToolStripMenuItem.Click += new System.EventHandler(this.showroomStockToolStripMenuItem_Click);
            // 
            // marketVisitReportToolStripMenuItem
            // 
            this.marketVisitReportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aLLToolStripMenuItem});
            this.marketVisitReportToolStripMenuItem.Name = "marketVisitReportToolStripMenuItem";
            this.marketVisitReportToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.marketVisitReportToolStripMenuItem.Text = "Market Visit Report";
            // 
            // aLLToolStripMenuItem
            // 
            this.aLLToolStripMenuItem.Name = "aLLToolStripMenuItem";
            this.aLLToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.aLLToolStripMenuItem.Text = "ALL";
            this.aLLToolStripMenuItem.Click += new System.EventHandler(this.aLLToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // stMain
            // 
            this.stMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelUser,
            this.toolStripStatusLabelUserGroup});
            this.stMain.Location = new System.Drawing.Point(0, 443);
            this.stMain.Name = "stMain";
            this.stMain.Size = new System.Drawing.Size(680, 22);
            this.stMain.TabIndex = 3;
            this.stMain.Text = "statusStrip1";
            // 
            // toolStripStatusLabelUser
            // 
            this.toolStripStatusLabelUser.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabelUser.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabelUser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabelUser.Name = "toolStripStatusLabelUser";
            this.toolStripStatusLabelUser.Size = new System.Drawing.Size(33, 17);
            this.toolStripStatusLabelUser.Text = "User";
            // 
            // toolStripStatusLabelUserGroup
            // 
            this.toolStripStatusLabelUserGroup.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabelUserGroup.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.toolStripStatusLabelUserGroup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabelUserGroup.Name = "toolStripStatusLabelUserGroup";
            this.toolStripStatusLabelUserGroup.Size = new System.Drawing.Size(62, 17);
            this.toolStripStatusLabelUserGroup.Text = "UserGroup";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 465);
            this.Controls.Add(this.stMain);
            this.Controls.Add(this.mnuMain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuMain;
            this.Name = "frmMain";
            this.Text = "TEL SMS Client System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.mnuMain.ResumeLayout(false);
            this.mnuMain.PerformLayout();
            this.stMain.ResumeLayout(false);
            this.stMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem activiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PersonsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sMSGroupsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem requestForGroupSMSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem requestForIndividualSMSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listOfMessagesToolStripMenuItem;
        private System.Windows.Forms.StatusStrip stMain;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelUser;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelUserGroup;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateProductInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem receivingMessagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem warrantyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem warrantyActivationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem warrantyRegisterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stockReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showroomStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sMSUsageReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem warrantyRegisterReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem requestForManySMSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iTProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invoicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marketVisitReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aLLToolStripMenuItem;
    }
}


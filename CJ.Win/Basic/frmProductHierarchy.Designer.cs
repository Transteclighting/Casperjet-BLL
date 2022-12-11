namespace CJ.Win
{
    partial class frmProductHierarchy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProductHierarchy));
            this.cboActiveInactive = new System.Windows.Forms.ComboBox();
            this.treeview = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.suspendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeviewImage = new System.Windows.Forms.ImageList(this.components);
            this.imageListDrag = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboActiveInactive
            // 
            this.cboActiveInactive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboActiveInactive.FormattingEnabled = true;
            this.cboActiveInactive.Location = new System.Drawing.Point(12, 12);
            this.cboActiveInactive.Name = "cboActiveInactive";
            this.cboActiveInactive.Size = new System.Drawing.Size(150, 21);
            this.cboActiveInactive.TabIndex = 23;
            this.cboActiveInactive.SelectedIndexChanged += new System.EventHandler(this.cboActiveInactive_SelectedIndexChanged);
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
            this.treeview.Location = new System.Drawing.Point(12, 39);
            this.treeview.Name = "treeview";
            this.treeview.ShowNodeToolTips = true;
            this.treeview.Size = new System.Drawing.Size(592, 427);
            this.treeview.TabIndex = 22;
            this.treeview.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.treeview_GiveFeedback);
            this.treeview.DragLeave += new System.EventHandler(this.treeview_DragLeave);
            this.treeview.DragDrop += new System.Windows.Forms.DragEventHandler(this.treeview_DragDrop);
            this.treeview.DragEnter += new System.Windows.Forms.DragEventHandler(this.treeview_DragEnter);
            this.treeview.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.treeview_ItemDrag);
            this.treeview.DragOver += new System.Windows.Forms.DragEventHandler(this.treeview_DragOver);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.toolStripMenuItem2,
            this.deleteToolStripMenuItem,
            this.suspendToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(120, 92);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(119, 22);
            this.toolStripMenuItem2.Text = "Update";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // suspendToolStripMenuItem
            // 
            this.suspendToolStripMenuItem.Name = "suspendToolStripMenuItem";
            this.suspendToolStripMenuItem.Size = new System.Drawing.Size(119, 22);
            this.suspendToolStripMenuItem.Text = "Suspend";
            // 
            // treeviewImage
            // 
            this.treeviewImage.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeviewImage.ImageStream")));
            this.treeviewImage.TransparentColor = System.Drawing.Color.Transparent;
            this.treeviewImage.Images.SetKeyName(0, "Admin.gif");
            // 
            // imageListDrag
            // 
            this.imageListDrag.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageListDrag.ImageSize = new System.Drawing.Size(16, 16);
            this.imageListDrag.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // frmProductHierarchy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 478);
            this.Controls.Add(this.cboActiveInactive);
            this.Controls.Add(this.treeview);
            this.Name = "frmProductHierarchy";
            this.Text = "Product Hierarchy";
            this.Load += new System.EventHandler(this.frmProductHierarchy_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cboActiveInactive;
        private System.Windows.Forms.TreeView treeview;
        private System.Windows.Forms.ImageList treeviewImage;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem suspendToolStripMenuItem;
        private System.Windows.Forms.ImageList imageListDrag;
    }
}
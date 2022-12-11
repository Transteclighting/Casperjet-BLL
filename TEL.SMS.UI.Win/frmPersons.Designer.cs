namespace TEL.SMS.UI.Win
{
    partial class frmPersons
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPersons));
            this.lvwPerson = new System.Windows.Forms.ListView();
            this.PersonCode = new System.Windows.Forms.ColumnHeader();
            this.PersonName = new System.Windows.Forms.ColumnHeader();
            this.MobileNo = new System.Windows.Forms.ColumnHeader();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewPersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyPersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deletePersonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.txtBtnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPersonNameLike = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMobliNoLike = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvwPerson
            // 
            this.lvwPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwPerson.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PersonCode,
            this.PersonName,
            this.MobileNo});
            this.lvwPerson.ContextMenuStrip = this.contextMenuStrip1;
            this.lvwPerson.FullRowSelect = true;
            this.lvwPerson.GridLines = true;
            this.lvwPerson.HideSelection = false;
            this.lvwPerson.Location = new System.Drawing.Point(12, 45);
            this.lvwPerson.Name = "lvwPerson";
            this.lvwPerson.Size = new System.Drawing.Size(629, 472);
            this.lvwPerson.TabIndex = 24;
            this.lvwPerson.UseCompatibleStateImageBehavior = false;
            this.lvwPerson.View = System.Windows.Forms.View.Details;
            this.lvwPerson.DoubleClick += new System.EventHandler(this.lvwPerson_DoubleClick);
            this.lvwPerson.SelectedIndexChanged += new System.EventHandler(this.lvwPerson_SelectedIndexChanged);
            this.lvwPerson.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvwPerson_ColumnClick);
            // 
            // PersonCode
            // 
            this.PersonCode.Text = "Person Code";
            this.PersonCode.Width = 82;
            // 
            // PersonName
            // 
            this.PersonName.Text = "Person  Name";
            this.PersonName.Width = 304;
            // 
            // MobileNo
            // 
            this.MobileNo.Text = "Mobile No";
            this.MobileNo.Width = 111;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewPersonToolStripMenuItem,
            this.modifyPersonToolStripMenuItem,
            this.deletePersonToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(164, 70);
            // 
            // addNewPersonToolStripMenuItem
            // 
            this.addNewPersonToolStripMenuItem.Name = "addNewPersonToolStripMenuItem";
            this.addNewPersonToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.addNewPersonToolStripMenuItem.Text = "Add new Person";
            this.addNewPersonToolStripMenuItem.Click += new System.EventHandler(this.addNewPersonToolStripMenuItem_Click);
            // 
            // modifyPersonToolStripMenuItem
            // 
            this.modifyPersonToolStripMenuItem.Name = "modifyPersonToolStripMenuItem";
            this.modifyPersonToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.modifyPersonToolStripMenuItem.Text = "Modify Person";
            this.modifyPersonToolStripMenuItem.Click += new System.EventHandler(this.modifyPersonToolStripMenuItem_Click);
            // 
            // deletePersonToolStripMenuItem
            // 
            this.deletePersonToolStripMenuItem.Name = "deletePersonToolStripMenuItem";
            this.deletePersonToolStripMenuItem.Size = new System.Drawing.Size(163, 22);
            this.deletePersonToolStripMenuItem.Text = "Delete Person";
            this.deletePersonToolStripMenuItem.Click += new System.EventHandler(this.deletePersonToolStripMenuItem_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(647, 45);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(95, 27);
            this.btnAdd.TabIndex = 25;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(647, 78);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(95, 27);
            this.btnEdit.TabIndex = 26;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Location = new System.Drawing.Point(647, 111);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(95, 27);
            this.btnDelete.TabIndex = 27;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // txtBtnClose
            // 
            this.txtBtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBtnClose.Location = new System.Drawing.Point(647, 485);
            this.txtBtnClose.Name = "txtBtnClose";
            this.txtBtnClose.Size = new System.Drawing.Size(95, 27);
            this.txtBtnClose.TabIndex = 28;
            this.txtBtnClose.Text = "Close";
            this.txtBtnClose.UseVisualStyleBackColor = true;
            this.txtBtnClose.Click += new System.EventHandler(this.txtBtnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Person Name Like";
            // 
            // txtPersonNameLike
            // 
            this.txtPersonNameLike.Location = new System.Drawing.Point(97, 13);
            this.txtPersonNameLike.Name = "txtPersonNameLike";
            this.txtPersonNameLike.Size = new System.Drawing.Size(238, 20);
            this.txtPersonNameLike.TabIndex = 31;
            this.txtPersonNameLike.TextChanged += new System.EventHandler(this.txtPersonNameLike_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(340, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Person Mobile No like";
            // 
            // txtMobliNoLike
            // 
            this.txtMobliNoLike.Location = new System.Drawing.Point(456, 16);
            this.txtMobliNoLike.Name = "txtMobliNoLike";
            this.txtMobliNoLike.Size = new System.Drawing.Size(185, 20);
            this.txtMobliNoLike.TabIndex = 33;
            this.txtMobliNoLike.TextChanged += new System.EventHandler(this.txtMobliNoLike_TextChanged);
            // 
            // frmPersons
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 529);
            this.Controls.Add(this.txtMobliNoLike);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPersonNameLike);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBtnClose);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lvwPerson);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPersons";
            this.Text = "Persons";
            this.Load += new System.EventHandler(this.frmPersons_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwPerson;
        private System.Windows.Forms.ColumnHeader PersonCode;
        private System.Windows.Forms.ColumnHeader PersonName;
        private System.Windows.Forms.ColumnHeader MobileNo;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button txtBtnClose;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addNewPersonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyPersonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deletePersonToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPersonNameLike;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMobliNoLike;
    }
}
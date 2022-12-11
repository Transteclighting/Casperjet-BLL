// <summary>
// Compamy: Transcom Electronics Limited
// Author: Arif Khan
// Date: May 4, 2014
// Time :  4:55 PM
// Description: Forms for Product Hierarchy.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using CJ.Class;
using System.Configuration;


namespace CJ.Win
{
    public partial class frmProductHierarchy : Form
    {
        private TreeNode dragNode = null;
        // Temporary drop node for selection
        private TreeNode tempDropNode = null;

        private Timer timer = new Timer();
        
        private ProductGroups _oProductGroups;
        private DataTable _oProductGroupTable;

        public frmProductHierarchy()
        {
            InitializeComponent();
        }

        private void frmProductHierarchy_Load(object sender, EventArgs e)
        {
            
            cboActiveInactive.Items.Add("<Active Product>");
            cboActiveInactive.Items.Add("<Inctive Product>");
            cboActiveInactive.Items.Add("<All Product>");
            cboActiveInactive.SelectedIndex = 0;
        }

        private void cboActiveInactive_SelectedIndexChanged(object sender, EventArgs e)
        {
            _oProductGroups = new ProductGroups();
            _oProductGroups.RefreshProductHierarchy(Dictionary.ActiveOrInActiveStatus.ACTIVE);
            _oProductGroupTable = _oProductGroups.ToDataTable();
            //foreach (ProductGroup oProductGroup in oProductGroups)
            //{
            //    TreeNode oNode = new TreeNode();
            //    oNode.Text = oProductGroup.PdtGroupName;
            //    treeview.Nodes.Add(oNode);
            //}

            this.treeview.Nodes.Clear();
            this.addTreeNodes(null);          
        }



        private void addTreeNodes(TreeNode oParentNode)
        {
            DataRow[] oChildNodes;
            string sChild = "";

            if (oParentNode == null)
                oChildNodes = this.getSubMenuTree(null);
            else
            {
                DataRow oItemRow = (DataRow)oParentNode.Tag;
                oChildNodes = this.getSubMenuTree(oItemRow[0].ToString());
            }
            foreach (DataRow oItem in oChildNodes)
            {
                TreeNode oNode = new TreeNode();
                oNode.Tag = oItem;
                DataRow[] oItemRow = this.getSubMenuTree(oItem[0].ToString());

                if (oItem.IsNull(3) == false)
                {
                    if (Convert.ToInt16(oItem[3]) == (short)Dictionary.ProductGroupType.ProductGroup)
                    {
                        oNode.ToolTipText = "ProductGroup";
                        sChild = "MAG";
                    }
                    else if (Convert.ToInt16(oItem[3]) == (short)Dictionary.ProductGroupType.MAG)
                    {
                        oNode.ToolTipText = "MAG";
                        sChild = "ASG";
                    }
                    else if (Convert.ToInt16(oItem[3]) == (short)Dictionary.ProductGroupType.ASG)
                    {
                        oNode.ToolTipText = "ASG";
                        sChild = "AG";
                    }
                    else if (Convert.ToInt16(oItem[3]) == (short)Dictionary.ProductGroupType.AG)
                    {
                        oNode.ToolTipText = "AG";
                        sChild = "Product";
                    }
                }
                else
                {
                    oNode.ToolTipText = "Product";
                }

                if (oItemRow.Length > 0)
                {
                    //if (oItem.IsNull(3) == false)
                    //{
                    oNode.Text = (string)oItem[2] + " [" + (string)oItem[1] + "]" + " ( Total " + sChild + " : " + oItemRow.Length + ")";
                    //}
                }
                else
                {
                    oNode.Text = (string)oItem[2] + " [" + (string)oItem[1] + "]";
                }
                if (oParentNode == null)
                {
                    treeview.Nodes.Add(oNode);
                }
                else
                {
                    oParentNode.Nodes.Add(oNode);
                }
                addTreeNodes(oNode);
            }
        }

        private DataRow[] getSubMenuTree(string pKey)
        {


            if (pKey == null)
                return _oProductGroupTable.Select("ParentID=0");
            else
                return _oProductGroupTable.Select("ParentId = '" + pKey + "'");
        }

        private void treeview_ItemDrag(object sender, ItemDragEventArgs e)
        {
            // Get drag node and select it
            this.dragNode = (TreeNode)e.Item;
            this.treeview.SelectedNode = this.dragNode;
            DataRow oItemRow = (DataRow)dragNode.Tag;
            if (oItemRow[3].Equals(5) == false)
            {
                MessageBox.Show("You can not drag this node.Please choose a Product", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            // Reset image list used for drag image
            this.imageListDrag.Images.Clear();
            this.imageListDrag.ImageSize = new Size(250, 16);
            //this.imageListDrag.ImageSize = new Size(this.dragNode.Bounds.Size.Width + this.treeview.Indent, this.dragNode.Bounds.Height);

            // Create new bitmap
            // This bitmap will contain the tree node image to be dragged
            Bitmap bmp = new Bitmap(this.dragNode.Bounds.Width + this.treeview.Indent, this.dragNode.Bounds.Height);

            // Get graphics from bitmap
            Graphics gfx = Graphics.FromImage(bmp);

            // Draw node icon into the bitmap
            gfx.DrawImage(this.treeviewImage.Images[0], 0, 0);

            // Draw node label into bitmap
            gfx.DrawString(this.dragNode.Text,
                this.treeview.Font,
                new SolidBrush(this.treeview.ForeColor),
                (float)this.treeview.Indent, 1.0f);

            // Add bitmap to imagelist
            this.imageListDrag.Images.Add(bmp);

            // Get mouse position in client coordinates
            Point p = this.treeview.PointToClient(System.Windows.Forms.Control.MousePosition);

            // Compute delta between mouse position and node bounds
            int dx = p.X + this.treeview.Indent - this.dragNode.Bounds.Left;
            int dy = p.Y - this.dragNode.Bounds.Top;

            // Begin dragging image
            if (DragHelper.ImageList_BeginDrag(this.imageListDrag.Handle, 0, dx, dy))
            {
                // Begin dragging
                this.treeview.DoDragDrop(bmp, DragDropEffects.Move);
                // End dragging image
                DragHelper.ImageList_EndDrag();
            }
        }

        private void treeview_DragOver(object sender, DragEventArgs e)
        {
            // Compute drag position and move image
            Point formP = this.PointToClient(new Point(e.X, e.Y));
            DragHelper.ImageList_DragMove(formP.X - this.treeview.Left, formP.Y - this.treeview.Top);

            // Get actual drop node
            TreeNode dropNode = this.treeview.GetNodeAt(this.treeview.PointToClient(new Point(e.X, e.Y)));
            if (dropNode == null)
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            e.Effect = DragDropEffects.Move;

            // if mouse is on a new node select it
            if (this.tempDropNode != dropNode)
            {
                DragHelper.ImageList_DragShowNolock(false);
                this.treeview.SelectedNode = dropNode;
                DragHelper.ImageList_DragShowNolock(true);
                tempDropNode = dropNode;
            }

            // Avoid that drop node is child of drag node 
            TreeNode tmpNode = dropNode;
            while (tmpNode.Parent != null)
            {
                if (tmpNode.Parent == this.dragNode) e.Effect = DragDropEffects.None;
                tmpNode = tmpNode.Parent;
            }
        }

        private void treeview_DragDrop(object sender, DragEventArgs e)
        {
            // Unlock updates
            DragHelper.ImageList_DragLeave(this.treeview.Handle);
            //this.dragNode = (TreeNode)e.Item;
            // Get drop node
            TreeNode dropNode = this.treeview.GetNodeAt(this.treeview.PointToClient(new Point(e.X, e.Y)));
            DataRow oItemDropRow = (DataRow)dropNode.Tag;
            DataRow oItemDragRow = (DataRow)dragNode.Tag;
            if (oItemDropRow[3].Equals(null) == false)
            {
                if (Convert.ToInt16(oItemDropRow[3]) != (short)Dictionary.ProductGroupType.AG)
                {
                    MessageBox.Show("You can not drop it at this node. Please try to drop it on AG", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (this.dragNode != dropNode)
                    {
                        // Remove drag node from parent
                        if (this.dragNode.Parent == null)
                        {
                            this.treeview.Nodes.Remove(this.dragNode);
                        }
                        else
                        {
                            this.dragNode.Parent.Nodes.Remove(this.dragNode);
                        }

                        // Add drag node to drop node
                        dropNode.Nodes.Add(this.dragNode);
                        dropNode.ExpandAll();

                        // Set drag node to null
                        this.dragNode = null;

                        // Disable scroll timer
                        this.timer.Enabled = false;
                    }
                    //updateProdutGroupId(oItemDragRow, oItemDropRow);

                }
            }
 
        }

        private void treeview_DragEnter(object sender, DragEventArgs e)
        {
            DragHelper.ImageList_DragEnter(this.treeview.Handle, e.X - this.treeview.Left,e.Y - this.treeview.Top);

            // Enable timer for scrolling dragged item
            this.timer.Enabled = true;
        }

        private void treeview_DragLeave(object sender, EventArgs e)
        {
            DragHelper.ImageList_DragLeave(this.treeview.Handle);

            // Disable timer for scrolling dragged item
            this.timer.Enabled = false;
        }

        private void treeview_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            if (e.Effect == DragDropEffects.Move)
            {
                // Show pointer cursor while dragging
                e.UseDefaultCursors = false;
                this.treeview.Cursor = Cursors.Default;
            }
            else e.UseDefaultCursors = true;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            // get node at mouse position
            Point pt = PointToClient(System.Windows.Forms.Control.MousePosition);
            TreeNode node = this.treeview.GetNodeAt(pt);

            if (node == null) return;

            // if mouse is near to the top, scroll up
            if (pt.Y < 30)
            {
                // set actual node to the upper one
                if (node.PrevVisibleNode != null)
                {
                    node = node.PrevVisibleNode;

                    // hide drag image
                    DragHelper.ImageList_DragShowNolock(false);
                    // scroll and refresh
                    node.EnsureVisible();
                    this.treeview.Refresh();
                    // show drag image
                    DragHelper.ImageList_DragShowNolock(true);

                }
            }
            // if mouse is near to the bottom, scroll down
            else if (pt.Y > this.treeview.Size.Height - 30)
            {
                if (node.NextVisibleNode != null)
                {
                    node = node.NextVisibleNode;

                    DragHelper.ImageList_DragShowNolock(false);
                    node.EnsureVisible();
                    this.treeview.Refresh();
                    DragHelper.ImageList_DragShowNolock(true);
                }
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

    }

    public class DragHelper
    {
        [DllImport("comctl32.dll")]
        public static extern bool InitCommonControls();

        [DllImport("comctl32.dll", CharSet = CharSet.Auto)]
        public static extern bool ImageList_BeginDrag(IntPtr himlTrack, int
            iTrack, int dxHotspot, int dyHotspot);

        [DllImport("comctl32.dll", CharSet = CharSet.Auto)]
        public static extern bool ImageList_DragMove(int x, int y);

        [DllImport("comctl32.dll", CharSet = CharSet.Auto)]
        public static extern void ImageList_EndDrag();

        [DllImport("comctl32.dll", CharSet = CharSet.Auto)]
        public static extern bool ImageList_DragEnter(IntPtr hwndLock, int x, int y);

        [DllImport("comctl32.dll", CharSet = CharSet.Auto)]
        public static extern bool ImageList_DragLeave(IntPtr hwndLock);

        [DllImport("comctl32.dll", CharSet = CharSet.Auto)]
        public static extern bool ImageList_DragShowNolock(bool fShow);

        static DragHelper()
        {
            InitCommonControls();
        }
    }
}
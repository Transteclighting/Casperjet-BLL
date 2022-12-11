// <summary>
// Compamy: Transcom Electronics Limited
// Author: A. Hakim
// Date: Nov 2, 2016
// Time :  5:55 PM
// Description: Forms for Position Hierarchy.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using CJ.Class;
using CJ.Class.HR;


namespace CJ.Win.HR
{
    public partial class frmPositionManagement : Form
    {

        private TreeNode dragNode = null;

        // Temporary drop node for selection
        private TreeNode tempDropNode = null;
        // Timer for scrolling
        private Timer timer = new Timer();
        DSPosition oDSPosition;
        HRPosition _oHRPosition;
        int nSelectedNodeIndex;
        Companys _oCompanys;
        int nCompanyID;
        DataTable _oProductGroupTable;

        public frmPositionManagement()
        {
            InitializeComponent();
        }

        private void frmPositionManagement_Load(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            this.Cursor = Cursors.WaitCursor;
            LoanCombo();
            _oProductGroupTable = new DataTable();
            oDSPosition = GetData(oDSPosition);
            _oProductGroupTable = oDSPosition.Tables["Position"];

            addTreeNodes(null);
            this.Cursor = Cursors.Default;
        }

        private void LoanCombo()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            //Company
            _oCompanys = new Companys();
            _oCompanys.Refresh(Utility.UserId);
            cmbCompany.Items.Clear();
            if (_oCompanys.Count == 0)
            {
                cmbCompany.Items.Add("No Permission!!");
            }
            foreach (Company oCompany in _oCompanys)
            {
                cmbCompany.Items.Add(oCompany.CompanyCode + " - " + oCompany.CompanyName);
            }
            cmbCompany.SelectedIndex = 0;

            //Company

            cmbCompanyList.Items.Clear();
            if (_oCompanys.Count == 0)
            {
                cmbCompanyList.Items.Add("No Permission!!");
            }
            foreach (Company oCompany in _oCompanys)
            {
                cmbCompanyList.Items.Add(oCompany.CompanyCode + " - " + oCompany.CompanyName);
            }
            cmbCompanyList.SelectedIndex = 0;
        }
        private void addTreeNodes(TreeNode oParentNode)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

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

                if (oItemRow.Length > 0)
                {
                    //if (oItem.IsNull(3) == false)
                    //{
                    oNode.Text = (string)oItem[1] + " [" + (string)oItem[2] + "]" + " [ Sub " + sChild + " : " + oItemRow.Length + "] Employee:" + (string)oItem[17] + "-" + (string)oItem[18] + " | " + (string)oItem[19];
                    //}
                }
                else
                {
                    oNode.Text = (string)oItem[1] + " [" + (string)oItem[2] + "] Employee:" + (string)oItem[17] + "-" + (string)oItem[18] + " | " + (string)oItem[19];
                }
                treeview.ImageList = imageList1;
                if (oParentNode == null)
                {
                    //oNode.ImageIndex = 1;
                    //oNode.SelectedImageIndex = 1;
                    treeview.Nodes.Add(oNode);
                    
                }
                else
                {
                   
                    //oNode.ImageIndex = 0;
                    //oNode.SelectedImageIndex = 0;
                    oParentNode.Nodes.Add(oNode);
                    
                }
                if ((int)oItem[12] == 0)
                {
                    oNode.ImageIndex = 2;
                    oNode.SelectedImageIndex = 2;
                }
                else
                {
                    if ((int)oItem[13] == 0)
                    {
                        oNode.ImageIndex = 0;
                        oNode.SelectedImageIndex = 0;
                    }
                    else
                    {
                        oNode.ImageIndex = 1;
                        oNode.SelectedImageIndex = 1;
                    }
                }
                addTreeNodes(oNode);
            }
        }
        private DataRow[] getSubMenuTree(string pKey)
        {
            //DataTable _oProductGroupTable = new DataTable();
            ////oDSPosition = GetData(oDSPosition);

            //_oProductGroupTable = oDSPosition.Tables["Position"];
            if (pKey == null)
                return _oProductGroupTable.Select("ParentID = 0 ");
            else
                return _oProductGroupTable.Select("ParentID = '" + pKey + "'");
        }

        public DSPosition GetData(DSPosition oDSPosition)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            OleDbCommand cmd = DBController.Instance.GetCommand();
            oDSPosition = new DSPosition();
            try
            {
                cmd.CommandText = " Select PositionID, PositionCode, PositionName, a.CompanyID, a.DepartmentID, BaseStationType, " +
                                  " RoleType, Role, Sort, IsNull(ParentID,0) as ParentID, IsNull(MarketGroupType,-1) as MarketGroupType,  " +
                                  " IsNull(MarketGroupID,-1) as MarketGroupID, IsNull(EmployeeCode,'Vacant') as EmployeeCode,  " +
                                  " IsNull(EmployeeName,'Vacant') as EmployeeName, IsNull(DesignationName,'Vacant') as DesignationName, " +
                                  " IsNull(a.EmployeeID,0) as EmployeeID, IsNull(MarkAsVacant,0) as MarkAsVacant, " +
                                  " CreateUserID, CreateDate, IsNull(Remarks,'') as Remarks from dbo.t_HRPosition a " +
                                  " Left Outer JOIN v_EmployeeDetails b ON a.EmployeeID=b.EmployeeID Where a.CompanyID = " + nCompanyID + " ";

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DSPosition.PositionRow oPositionRow = oDSPosition.Position.NewPositionRow();

                    oPositionRow.PositionID = (int)reader["PositionID"];
                    oPositionRow.PositionCode = (string)reader["PositionCode"];
                    oPositionRow.PositionName = (string)reader["PositionName"];
                    oPositionRow.CompanyID = (int)reader["CompanyID"];
                    oPositionRow.DepartmentID = (int)reader["DepartmentID"];
                    oPositionRow.BaseStationType = (int)reader["BaseStationType"];
                    oPositionRow.RoleType = (int)reader["RoleType"];
                    oPositionRow.Role = (int)reader["Role"];
                    oPositionRow.Sort = (int)reader["Sort"];
                    oPositionRow.ParentID = (int)reader["ParentID"];
                    oPositionRow.MarketGroupType = (int)reader["MarketGroupType"];
                    oPositionRow.MarketGroupID = (int)reader["MarketGroupID"];
                    oPositionRow.EmployeeID = (int)reader["EmployeeID"];
                    oPositionRow.MarkAsVacant = (int)reader["MarkAsVacant"];
                    oPositionRow.CreateUserID = (int)reader["CreateUserID"];
                    oPositionRow.CreateDate = Convert.ToDateTime(reader["CreateDate"]);
                    oPositionRow.Remarks = (string)reader["Remarks"];

                    oPositionRow.EmployeeCode = (string)reader["EmployeeCode"];
                    oPositionRow.EmployeeName = (string)reader["EmployeeName"];
                    oPositionRow.DesignationName = (string)reader["DesignationName"];

                    oDSPosition.Position.AddPositionRow(oPositionRow);
                    oDSPosition.AcceptChanges();
                }

                reader.Close();
               
            }
            catch (Exception ex)
            {
               throw (ex);
            }
            //DBController.Instance.CloseConnection();
            return oDSPosition;
        }

        private void treeview_ItemDrag(object sender, ItemDragEventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            // Get drag node and select it
            this.dragNode = (TreeNode)e.Item;
            this.treeview.SelectedNode = this.dragNode;
            DataRow oItemRow = (DataRow)dragNode.Tag;
            //if (oItemRow[3].Equals(5) == false)
            //{
            //    MessageBox.Show("You can not drag this node.Please choose a Product", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //}

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
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
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
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            // Unlock updates
            DragHelper.ImageList_DragLeave(this.treeview.Handle);
            //this.dragNode = (TreeNode)e.Item;
            // Get drop node
            TreeNode dropNode = this.treeview.GetNodeAt(this.treeview.PointToClient(new Point(e.X, e.Y)));
            //DataRow oItemDropRow = (DataRow)dropNode.Tag;
            //DataRow oItemDragRow = (DataRow)dragNode.Tag;
            DSPosition.PositionRow oItemDropRow = (DSPosition.PositionRow)dropNode.Tag;
            DSPosition.PositionRow oItemDragRow = (DSPosition.PositionRow)dragNode.Tag;

            if (oItemDropRow[3].Equals(null) == false)
            {
                if (oItemDropRow.CompanyID != oItemDragRow.CompanyID)
                {
                    MessageBox.Show("Please drop the node within the company", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    Update(oItemDragRow, oItemDropRow);

                }
            }

        }

        private void treeview_DragEnter(object sender, DragEventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            DragHelper.ImageList_DragEnter(this.treeview.Handle, e.X - this.treeview.Left, e.Y - this.treeview.Top);

            // Enable timer for scrolling dragged item
            this.timer.Enabled = true;
        }

        private void treeview_DragLeave(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
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
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
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

        private void Update(DSPosition.PositionRow oItemDragRow, DSPosition.PositionRow oItemDropRow)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            DataSet oDSRequest;
            DataSet oDSResponse;
            //DSError oDSError;

            DSPosition oDSSinglePosition;
            oDSSinglePosition = new DSPosition();
            DSPosition.PositionRow oRow = oDSSinglePosition.Position.NewPositionRow();
            oRow.PositionCode = oItemDragRow.PositionCode;
            oRow.PositionID = oItemDropRow.PositionID;
            oDSSinglePosition.Position.AddPositionRow(oRow);

            _oHRPosition = new HRPosition();

            _oHRPosition.ParentID = oItemDropRow.PositionID;
            _oHRPosition.PositionID = oItemDragRow.PositionID;

            try
            {
                //DBController.Instance.OpenNewConnection;
                DBController.Instance.BeginNewTransaction();
                _oHRPosition.Update();

                DBController.Instance.CommitTran();
            }
            catch
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

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            TreeNode tn = treeview.SelectedNode;

            if (tn == null)
            {
                MessageBox.Show("Please Select a Tree");
                return;
            }
            //else
            //{
            //    MessageBox.Show("Add");
            //}

            TreeNode selectednode = this.treeview.SelectedNode;
            DSPosition.PositionRow oSeletedItem = (DSPosition.PositionRow)selectednode.Tag;

            int nPositionID = oSeletedItem.PositionID;

            frmPosition oForm = new frmPosition(oSeletedItem.PositionID, oSeletedItem.CompanyID, oSeletedItem.PositionCode, oSeletedItem.PositionName, true);
            oForm.ShowDialog();
            if (oForm._bFlag)
            {
                Reload();
            }

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            TreeNode tn = treeview.SelectedNode;

            if (tn == null)
            {
                MessageBox.Show("Please Select a Tree");
                return;
            }
            //else
            //{
            //    MessageBox.Show("Add");
            //}

            TreeNode selectednode = this.treeview.SelectedNode;
            DSPosition.PositionRow oSeletedItem = (DSPosition.PositionRow)selectednode.Tag;

            int nPositionID = oSeletedItem.PositionID;

            frmPosition oForm = new frmPosition(oSeletedItem.PositionID, oSeletedItem.CompanyID, oSeletedItem.PositionCode, oSeletedItem.PositionName, false);
            oForm.EditMode(oSeletedItem);
            if (oForm._bFlag)
            {
                Reload();
            }
        }

        private void deleteToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            _oHRPosition = new HRPosition();
            TreeNode selectednode = this.treeview.SelectedNode;
            DSPosition.PositionRow oSeletedItem = (DSPosition.PositionRow)selectednode.Tag;
            if (_oHRPosition.CheckChild(oSeletedItem.PositionID))
            {
                MessageBox.Show("Only Child position can be deleted.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (_oHRPosition.CheckAssign(oSeletedItem.PositionID))
            {
                MessageBox.Show("Please unassign the Position before delete.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult oResult = MessageBox.Show("Are you sure you want to delete the Position: " + oSeletedItem.PositionCode + " [" + oSeletedItem.PositionName + "] ? ", "Confirm Ticket Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {
                DBController.Instance.BeginNewTransaction();
                _oHRPosition.PositionID = oSeletedItem.PositionID;
                _oHRPosition.Delete();
                DBController.Instance.CommitTran();
                MessageBox.Show("The position has deleted successfully", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Reload();
            }
        }

        private void assignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            TreeNode selectednode = this.treeview.SelectedNode;
            DSPosition.PositionRow oSeletedItem = (DSPosition.PositionRow)selectednode.Tag;

            int nPositionID = oSeletedItem.PositionID;

            frmPositionAssign oForm = new frmPositionAssign(oSeletedItem.PositionID, oSeletedItem.CompanyID, oSeletedItem.PositionCode, oSeletedItem.PositionName, true);
            oForm.ShowDialog();
            if (oForm._bFlag)
            {
                Reload();
            }
        }

        private void unassignToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            TreeNode selectednode = this.treeview.SelectedNode;
            DSPosition.PositionRow oSeletedItem = (DSPosition.PositionRow)selectednode.Tag;

            int nPositionID = oSeletedItem.PositionID;

            frmPositionUnassign oForm = new frmPositionUnassign(oSeletedItem.PositionID, oSeletedItem.CompanyID, oSeletedItem.PositionCode, oSeletedItem.PositionName, oSeletedItem.EmployeeID, true);
            oForm.ShowDialog();
            if (oForm._bFlag)
            {
                Reload();
            }
        }

        private void treeview_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //nSelectedNodeIndex = e.Node.Index;
            //nSelectedNodeIndex = treeview.SelectedNode.Index;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            this.Cursor = Cursors.WaitCursor;
            Reload();
            this.Cursor = Cursors.Default;
        }

        private void Reload()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            treeview.Nodes.Clear();
            //treeview.Nodes[nSelectedNodeIndex].Expand();
            _oProductGroupTable = new DataTable();
            oDSPosition = GetData(oDSPosition);
            _oProductGroupTable = oDSPosition.Tables["Position"];
            addTreeNodes(null);
        }

        private void markAsVacantToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            TreeNode selectednode = this.treeview.SelectedNode;
            DSPosition.PositionRow oSeletedItem = (DSPosition.PositionRow)selectednode.Tag;

            int nPositionID = oSeletedItem.PositionID;

            frmPositionUnassign oForm = new frmPositionUnassign(oSeletedItem.PositionID, oSeletedItem.CompanyID, oSeletedItem.PositionCode, oSeletedItem.PositionName, oSeletedItem.EmployeeID, false);
            oForm.ShowDialog();
            if (oForm._bFlag)
            {
                Reload();
            }
        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            TreeNode selectednode = this.treeview.SelectedNode;
            DSPosition.PositionRow oSeletedItem = (DSPosition.PositionRow)selectednode.Tag;

            int nPositionID = oSeletedItem.PositionID;

            frmPositionHistory oForm = new frmPositionHistory(oSeletedItem.PositionID, oSeletedItem.CompanyID, oSeletedItem.PositionCode, oSeletedItem.PositionName);
            oForm.ShowDialog();
        }

        private void cmbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_oCompanys.Count != 0)
            {
                nCompanyID = _oCompanys[cmbCompany.SelectedIndex].CompanyID;
            }
            //addTreeNodes(null);
        }

        private void btnRefreshList_Click(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            DataLoadControlList();
        }

        private void DataLoadControlList()
        {
            HRPositions oHRPositions = new HRPositions();
            lvwItem.Items.Clear();
            int nCompanyID = 0;
            string sDatabase = "";
            if (_oCompanys.Count > 0)
            {
                nCompanyID = _oCompanys[cmbCompanyList.SelectedIndex].CompanyID;
                if (nCompanyID == (int)Dictionary.CompanyID.TEL)
                {
                    sDatabase = "TELSysDB";
                }
                else if (nCompanyID == (int)Dictionary.CompanyID.BLL)
                {
                    sDatabase = "BLLSysDB";
                }
                else if (nCompanyID == (int)Dictionary.CompanyID.BEIL)
                {
                    sDatabase = "BEILSysDB";
                }
                else if (nCompanyID == (int)Dictionary.CompanyID.TML)
                {
                    sDatabase = "TMLSysDB";
                }


            }
            //DBController.Instance.OpenNewConnection();
            oHRPositions.GetPositionList(sDatabase, nCompanyID);
            this.Text = "Total " + "[" + oHRPositions.Count + "]";
            foreach (HRPosition oHRPosition in oHRPositions)
            {
                ListViewItem oItem = lvwItem.Items.Add(oHRPosition.PositionCode);
                oItem.SubItems.Add(oHRPosition.PositionName);
                oItem.SubItems.Add(oHRPosition.Status);
                oItem.SubItems.Add(oHRPosition.AreaName);
                oItem.SubItems.Add(oHRPosition.TerritoryName);
                oItem.SubItems.Add(oHRPosition.CustomerName);
                //oItem.SubItems.Add(oAttendData.PunchDate.ToString("dd-MMM-yyyy"));
                //oItem.SubItems.Add(oAttendData.PunchTime.ToString("HH:mm tt"));
                //oItem.SubItems.Add(oAttendData.StationNo);
                //if (oAttendData.IsSystem) oItem.SubItems.Add("System");
                //else oItem.SubItems.Add("Manual");
                //oItem.SubItems.Add(oAttendData.UserID.ToString());
                oItem.Tag = oHRPosition;
            }
        }

        private void jobSpecificationToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void jobDescriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void manpowerRequisitionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManpowerRequisitions oFrom = new frmManpowerRequisitions();
            oFrom.ShowDialog();
        }


    }
}
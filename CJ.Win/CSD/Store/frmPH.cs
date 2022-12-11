
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.CSD;
using CJ.Class;
using CJ.Class.ANDROID;

namespace CJ.Win
{
    public partial class frmPH : Form
    {
        //SPMainCats _oSPMainCats;
        public frmPH()
        {
            InitializeComponent();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {

            frmSparePart oForm = new frmSparePart();
            oForm.ShowDialog();
            //DataLoadControl();
        }
        private void LoadCombo()
        {
            //_oSPMainCats = new SPMainCats();
            //_oSPMainCats.RefreshForFilter();
            //cmbMainCategory.Items.Clear();

            //foreach (SPMainCat oSPMainCat in _oSPMainCats)
            //{
            //    cmbMainCategory.Items.Add(oSPMainCat.Name);
            //}
            //if (_oSPMainCats.Count >0)
            //    cmbMainCategory.SelectedIndex = _oSPMainCats.Count - 1; 
      
        }
        private void frmSpareParts_Load(object sender, EventArgs e)
        {

            cboActiveInactive.Items.Add("<Active Product>");
            cboActiveInactive.Items.Add("<Inctive Product>");
            cboActiveInactive.Items.Add("<All Product>");
            cboActiveInactive.SelectedIndex = 0;
            //DataLoadControl();


            //TreeNode node;
            
            //node =tvwPH.Nodes.Add("Fruits");
            //node.Nodes.Add("Apple");
            //node.Nodes.Add("Peach");


            //node = tvwPH.Nodes.Add("Vegetables");
            //node.Nodes.Add("Tomato");
            //node.Nodes.Add("Eggplant");


        }

        private void treeFood_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            if (e.Action == TreeViewAction.ByMouse)
            {
                MessageBox.Show(e.Node.FullPath);
            }
        }

        //private void DataLoadControl()
        //{

        //    PHs oPHs = new PHs();

        //    tvwPH.Nodes.Clear();
        //    DBController.Instance.OpenNewConnection();

        //    oPHs.Refresh();//txtPartCode.Text, txtPartName.Text
        //    //this.Text = "Total " + "[" + oSparePartsRs.Count + "]";
        //    foreach (PH oPH in oPHs)
        //    {
        //        //foreach (HierarchyTrees.HTree hTree in hierarchyTrees)
        //        //{
        //            //Filter the collection HierarchyTrees based on 
        //            //Iteration as per object Htree Parent ID 
        //        PH parentNode = new PH();
        //            (delegate(PH emp)
        //           { return emp.ParentID == oPH.ParentID; });
        //            //If parent node has child then populate the leaf node.
        //            if (parentNode != null)
        //            {
        //                foreach (TreeNode tn in tvwPH.Nodes)
        //                {
        //                    //If single child then match Node ID with Parent ID
        //                    if (tn.parent.Value == parentNode.ParentID.ToString())
        //                    {
        //                        tn.Nodes.Add(new TreeNode
        //                        (oPH.PdtGroupName.ToString(), oPH.ParentID.ToString()));
        //                    }

        //                    //If Node has multiple child ,
        //                    //recursively traverse through end child or leaf node.
        //                    if (tn.ChildNodes.Count > 0)
        //                    {
        //                        foreach (TreeNode ctn in tn.ChildNodes)
        //                        {
        //                            RecursiveChild(ctn, parentNode.ParentID.ToString(), hTree);
        //                        }
        //                    }
        //                }
        //            }
        //            //Else add all Node at first level 
        //            else
        //            {
        //                tvwPH.Nodes.Add(new TreeNode
        //                (oPH.PdtGroupName, oPH.ParentID.ToString()));
        //            }
        //        }
        //        tvwPH.ExpandAll();
        //    //}
        //}

//        using System;
//using System.Drawing;
//using System.Windows.Forms;

//namespace WindowsFormsApplication1
//{
//    public partial class Form1 : Form
//    {
//        public Form1()
//        {
//            InitializeComponent();
//        }

//        private void Form1_Load(object sender, EventArgs e)
//        {
//            TreeNode tNode ;
//            tNode = treeView1.Nodes.Add("Websites");

//            treeView1.Nodes[0].Nodes.Add("Net-informations.com");
//            treeView1.Nodes[0].Nodes[0].Nodes.Add("CLR");

//            treeView1.Nodes[0].Nodes.Add("Vb.net-informations.com");
//            treeView1.Nodes[0].Nodes[1].Nodes.Add("String Tutorial");
//            treeView1.Nodes[0].Nodes[1].Nodes.Add("Excel Tutorial");

//            treeView1.Nodes[0].Nodes.Add("Csharp.net-informations.com");
//            treeView1.Nodes[0].Nodes[2].Nodes.Add("ADO.NET");
//            treeView1.Nodes[0].Nodes[2].Nodes[0].Nodes.Add("Dataset");
//        }

//        private void button1_Click(object sender, EventArgs e)
//        {
//            MessageBox.Show(treeView1.SelectedNode.FullPath.ToString ());
//        }
//    }
//}




        //        //TreeNode oItem = tvwPH.Nodes.Add(oPH.PdtGroupName.ToString());
        //        //TreeNode node;





        //        //node = tvwPH.Nodes.Add(oPH.PdtGroupName);
                
        //        //node.Nodes.Add(oPH.PdtGroupCode);
        //        //node.Nodes.Add(oPH.PdtGroupType.ToString());
        //        //tvwPH.ExpandAll();

        //        //DataTable dtbParent = new DataTable();
        //        //dtbParent = oPH.PdtGroupID;
        //        foreach (DataRow drowParent in tvwPH.Rows)
        //        {
        //            TreeNode parentNode = new TreeNode();
        //            parentNode.Text = drowParent["Name"].ToString();
        //            parentNode.Tag = drowParent["ParentUID"].ToString();
        //            tvwPH.Nodes.Add(parentNode);
        //        }

        //        //DataTable childTable = new DataTable();
        //        //childTable = oPH.PdtGroupID;

        //        //treeTopLevel = treeView1.Nodes.Add("Top Level");

        //        foreach (TreeNode parentNode in tvwPH.Nodes)
        //        {
        //            int intParentUID = Convert.ToInt32(parentNode.Tag);
        //            DataRow[] dRowChildren = childTable.Select("ParentUID = " + intParentUID);
        //            foreach (DataRow dRowChild in dRowChildren)
        //            {
        //                TreeNode childNode = new TreeNode();
        //                childNode.Text = dRowChild["Name"].ToString();
        //                parentNode.Nodes.Add(childNode);
        //            }
        //        }


        //        //tvwPH.DataSource = dataSet.Tables[0];
        //        //tvwPH.KeyMember = "DepartmentId";
        //        //tvwPH.DisplayMember = "Name";
        //        //tvwPH.ValueMember = "DepartmentId";
        //        //tvwPH.ParentMember = "DepartmentIdParent";





        //        ////////////////////
                
        //        //DSProductGroup.ProductGroupRow oProductGroupRow = oDSProductGroup.ProductGroup.NewProductGroupRow();
        //        //if (oPOProductGroupRow.IsPdtGroupIdNull() == false)
        //        //{
        //        //    oProductGroupRow.PdtGroupId = oPOProductGroupRow.PdtGroupId;
        //        //}
        //        //if (oPOProductGroupRow.IsPdtGroupCodeNull() == false)
        //        //{
        //        //    oProductGroupRow.PdtGroupCode = oPOProductGroupRow.PdtGroupCode;
        //        //}
        //        //if (oPOProductGroupRow.IsPdtGroupNameNull() == false)
        //        //{
        //        //    oProductGroupRow.PdtGroupName = oPOProductGroupRow.PdtGroupName;
        //        //}
        //        //if (oPOProductGroupRow.IsPdtGroupTypeNull() == false)
        //        //{
        //        //    oProductGroupRow.PdtGroupType = oPOProductGroupRow.PdtGroupType;
        //        //}
        //        //if (oPOProductGroupRow.IsParentIdNull() == false)
        //        //{
        //        //    oProductGroupRow.ParentId = oPOProductGroupRow.ParentId;
        //        //}
        //        //if (oProductGroupRow.IsPosNull() == false)
        //        //{
        //        //    oProductGroupRow.Pos = oPOProductGroupRow.Pos;
        //        //}
        //        //if (oPOProductGroupRow.IsIsActiveNull() == false)
        //        //{
        //        //    oProductGroupRow.IsActive = oPOProductGroupRow.IsActive;
        //        //}
        //        //if (oPOProductGroupRow.IsProductIDNull() == false)
        //        //{
        //        //    oProductGroupRow.ProductID = oPOProductGroupRow.ProductID;
        //        //}
        //        //else
        //        //{
        //        //    oProductGroupRow.ProductID = Convert.ToInt64(null);
        //        //}
        //        //if (oPOProductGroupRow.IsProductCodeNull() == false)
        //        //{
        //        //    oProductGroupRow.ProductCode = oPOProductGroupRow.ProductCode;
        //        //}
        //        //if (oPOProductGroupRow.IsProductNameNull() == false)
        //        //{
        //        //    oProductGroupRow.ProductName = oPOProductGroupRow.ProductName;
        //        //}
        //        //else
        //        //{
        //        //    oProductGroupRow.ProductName = Convert.ToString(null);
        //        //}



        //        //oItem.SubItems.Add(oSparePartsR.Name.ToString());
        //        //oItem.SubItems.Add(oSparePartsR.SalePrice.ToString());
        //        //oItem.SubItems.Add(oSparePartsR.SparePartLocation.LocationName.ToString());
        //        //oItem.SubItems.Add(oSparePartsR.SPSubCat.Name.ToString());
        //        //oItem.SubItems.Add(oSparePartsR.MainCatName.ToString());
        //        //oItem.SubItems.Add(oSparePartsR.ModelNo.ToString());
        //        //oItem.SubItems.Add(oSparePartsR.ProductDetailASG.ASGName.ToString());
        //        //oItem.SubItems.Add(oSparePartsR.ProductDetailBrand.BrandDesc.ToString());
        //        //if (oSparePartsR.IsActive == (int)Dictionary.InquiryCommunicationStatus.True)
        //        //{
        //        //    oItem.SubItems.Add("True");
        //        //}
        //        //else
        //        //{
        //        //    oItem.SubItems.Add("False");
        //        //}


        //        //node.Tag = oPH;
        //    }
        //}

        //private void PopulateTreeView1()
        //{
        //    PHs oPHs = new PHs();

        //    tvwPH.Nodes.Clear();
        //    DBController.Instance.OpenNewConnection();

        //    oPHs.Refresh();//txtPartCode.Text, txtPartName.Text
           
        //    MySqlConnection conn = new MySqlConnection(connString);
        //    DataSet ds = new DataSet();
        //    conn.Open();
        //    MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM tblNavigator ORDER BY ParentUID, displayorder", conn);
        //    adapter.Fill(ds);
        //    conn.Close();

        //    TreeNode treeTopLevel;

        //    //DataTable dtbParent = new DataTable();
        //    //dtbParent = ds.Tables[0];
        //    foreach (DataRow drowParent in dtbParent.Rows)
        //    {
        //        TreeNode parentNode = new TreeNode();
        //        parentNode.Text = drowParent["Name"].ToString();
        //        parentNode.Tag = drowParent["ParentUID"].ToString();
        //        treeView1.Nodes.Add(parentNode);
        //    }

        //    DataTable childTable = new DataTable();
        //    childTable = ds.Tables[0];

        //    //treeTopLevel = treeView1.Nodes.Add("Top Level");

        //    foreach (TreeNode parentNode in treeView1.Nodes)
        //    {
        //        int intParentUID = Convert.ToInt32(parentNode.Tag);
        //        DataRow[] dRowChildren = childTable.Select("ParentUID = " + intParentUID);
        //        foreach (DataRow dRowChild in dRowChildren)
        //        {
        //            TreeNode childNode = new TreeNode();
        //            childNode.Text = dRowChild["Name"].ToString();
        //            parentNode.Nodes.Add(childNode);
        //        }
        //    }
        //}
//        public class HierarchyTrees : List<HierarchyTrees.HTree>
//        {
//            public class HTree
//            {
//                private string m_NodeDescription;
//                private int m_UnderParent;
//                private int m_LevelDepth;
//                private int m_NodeID;

//                public int NodeID
//                {
//                    get { return m_NodeID; }
//                    set { m_NodeID = value; }
//                }

//                public string NodeDescription
//                {
//                    get { return m_NodeDescription; }
//                    set { m_NodeDescription = value; }
//                }
//                public int UnderParent
//                {
//                    get { return m_UnderParent; }
//                    set { m_UnderParent = value; }
//                }
//                public int LevelDepth
//                {
//                    get { return m_LevelDepth; }
//                    set { m_LevelDepth = value; }
//                }
//            }
//        } 
//        private void PopulateTreeview()
//        {
//            this.tvHierarchyView.Nodes.Clear();
//            HierarchyTrees hierarchyTrees = new HierarchyTrees();
//            HierarchyTrees.HTree objHTree = null;
//            using (SqlConnection connection = new SqlConnection
//            (@"Persist Security Info=False;Integrated Security=SSPI;
//     database=FamilyTree;server=[Local]"))
//            {
//                connection.Open();
//                using (SqlCommand command =
//                new SqlCommand("SSP_GET_HIERARCHY", connection))
//                {
//                    command.CommandType = System.Data.CommandType.StoredProcedure;
//                    SqlDataReader reader = command.ExecuteReader
//                    (System.Data.CommandBehavior.CloseConnection);
//                    while (reader.Read())
//                    {
//                        objHTree = new HierarchyTrees.HTree();

//                        objHTree.LevelDepth = int.Parse(reader["LEVEL_DEPTH"].ToString());
//                        objHTree.NodeID = int.Parse(reader["NODE_ID"].ToString());
//                        objHTree.UnderParent = int.Parse(reader["UNDER_PARENT"].ToString());
//                        objHTree.NodeDescription = reader["NODE_DESCRIPTION"].ToString();
//                        hierarchyTrees.Add(objHTree);
//                    }
//                }
//            }
//            //Iterate through Collections.
//            foreach (HierarchyTrees.HTree hTree in hierarchyTrees)
//            {
//                //Filter the collection HierarchyTrees based on 
//                //Iteration as per object Htree Parent ID 
//                HierarchyTrees.HTree parentNode = hierarchyTrees.Find
//                (delegate(HierarchyTrees.HTree emp)
//               { return emp.NodeID == hTree.UnderParent; });
//                //If parent node has child then populate the leaf node.
//                if (parentNode != null)
//                {
//                    foreach (TreeNode tn in tvHierarchyView.Nodes)
//                    {
//                        //If single child then match Node ID with Parent ID
//                        if (tn.Value == parentNode.NodeID.ToString())
//                        {
//                            tn.ChildNodes.Add(new TreeNode
//                            (hTree.NodeDescription.ToString(), hTree.NodeID.ToString()));
//                        }

//                        //If Node has multiple child ,
//                        //recursively traverse through end child or leaf node.
//                        if (tn.ChildNodes.Count > 0)
//                        {
//                            foreach (TreeNode ctn in tn.ChildNodes)
//                            {
//                                RecursiveChild(ctn, parentNode.NodeID.ToString(), hTree);
//                            }
//                        }
//                    }
//                }
//                //Else add all Node at first level 
//                else
//                {
//                    tvHierarchyView.Nodes.Add(new TreeNode
//                    (hTree.NodeDescription, hTree.NodeID.ToString()));
//                }
//            }
//            tvHierarchyView.ExpandAll();
//        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnProdpriceTML_Click(object sender, EventArgs e)
        {
            TML oTML = new TML();

            dgvProductPrice.DataSource = oTML.GetPerformance().Performance;
            dgvProductPrice.Refresh();
        }

        
    }
}
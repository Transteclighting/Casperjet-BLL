using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;



namespace CJ.POS.RT
{
    public partial class frmProductSearch : Form
    {
        public CJ.Class.POS.DSProduct oDSSelectedProduct;  

        CJ.Class.POS.DSProduct oDSProduct;
        CJ.Class.POS.DSProduct oDSFilterProduct;
        CJ.Class.POS.DSProductGroups oDSProductGroups; 
        CJ.Class.POS.DSProductGroups oDSProductGroupsMAG;
        CJ.Class.POS.DSProductGroups oDSProductGroupsASG;
        CJ.Class.POS.DSProductGroups oDSProductGroupsAG;
        CJ.Class.POS.DSBrand oDSBrand;

        CJ.Class.POS.SystemInfo oSystemInfo;
        CJ.Class.ProductDetails _oProductDetails;
        CJ.Class.ProductGroups oProductGroups;
        CJ.Class.Brands oBrands;
        CJ.Class.Web.UI.Class.WUIUtility _oWUIUtility;

       
        int _nCountPG=0;


        public frmProductSearch(int nWarehouseID)
        {            
            InitializeComponent();
          
        }
        private void LoadCombos()
        {
                 
        
            try
            {
                //oDSProductGroups = oService.GetAllProductGroup(oDSProductGroups);
               // oDSBrand = oService.GetProductBarnd(oDSBrand);   
 
                oDSProduct = new CJ.Class.POS.DSProduct();
                oDSProductGroups = new CJ.Class.POS.DSProductGroups();
                oDSBrand = new CJ.Class.POS.DSBrand();  

                oProductGroups = new CJ.Class.ProductGroups();
                oBrands = new CJ.Class.Brands();
                _oProductDetails = new CJ.Class.ProductDetails();

                CJ.Class.DBController.Instance.OpenNewConnection();
                oDSProduct = _oProductDetails.POSGetProductDetail(oDSProduct);
                oDSProductGroups = oProductGroups.POSGetAllProductGroup(oDSProductGroups);
                oDSBrand = oBrands.POSGetBrand(oDSBrand);
                CJ.Class.DBController.Instance.CloseConnection();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //PG
            if (oDSProductGroups.PGGroup.Rows.Count > 0)
            {
                cboPG.ValueMember = "PdtGroupId";
                cboPG.DisplayMember = "PdtGroupName";
                cboPG.DataSource = oDSProductGroups.PGGroup;                
                cboPG.SelectedIndex = oDSProductGroups.PGGroup.Rows.Count - 1;
            }  
            
            //Brand
            if (oDSBrand.Brand.Rows.Count > 0)
            {
                cboBrand.ValueMember = "BrandID";
                cboBrand.DisplayMember = "BrandDesc";
                cboBrand.DataSource = oDSBrand.Brand;
                cboBrand.SelectedIndex = oDSBrand.Brand.Rows.Count - 1;
            }  
           

        }
        private void refreshListBySearch()
        {
            string sClause = "";

            if (int.Parse(cboPG.SelectedValue.ToString()) != -1 && cboPG.Text!="")
            {
                if (sClause.Trim().Length == 0)
                {
                    sClause = "PGID ='" + int.Parse(cboPG.SelectedValue.ToString()) + "'";
                
                }
                else
                {
                    sClause = sClause + " AND PGID = '" + int.Parse(cboPG.SelectedValue.ToString()) + "' ";
                 
                }
            }
            if ( cboMAG.Text != "")
            {
                if (int.Parse(cboMAG.SelectedValue.ToString()) != -1)
                {
                    if (sClause.Trim().Length == 0)
                    {
                        sClause = " MAGID = '" + int.Parse(cboMAG.SelectedValue.ToString()) + "' ";

                    }
                    else
                    {
                        sClause = sClause + " AND MAGID = '" + int.Parse(cboMAG.SelectedValue.ToString()) + "' ";

                    }
                }
            }

            if ( cboASG.Text != "")
            {
                if (int.Parse(cboASG.SelectedValue.ToString()) != -1)
                {
                    if (sClause.Trim().Length == 0)
                    {
                        sClause = " ASGID = '" + int.Parse(cboASG.SelectedValue.ToString()) + "'";

                    }
                    else
                    {
                        sClause = sClause + " AND ASGID = '" + int.Parse(cboASG.SelectedValue.ToString()) + "' ";

                    }
                }
            }

            if ( cboAG.Text != "")
            {
                if (int.Parse(cboAG.SelectedValue.ToString()) != -1)
                {
                    if (sClause.Trim().Length == 0)
                    {
                        sClause = "AGID ='" + int.Parse(cboAG.SelectedValue.ToString()) + "' ";

                    }
                    else
                    {
                        sClause = sClause + " AND AGID = '" + int.Parse(cboAG.SelectedValue.ToString()) + "' ";

                    }
                }
            }

            if (int.Parse(cboBrand.SelectedValue.ToString()) != -1)
            {
                if (sClause.Trim().Length == 0)
                {
                    sClause = " BrandID = '" + int.Parse(cboBrand.SelectedValue.ToString()) + "' ";
                    
                }
                else
                {
                    sClause = sClause + " AND BrandID = '" + int.Parse(cboBrand.SelectedValue.ToString()) + "' ";
                   
                }
            }

            if (txtCode.Text != "")
            {
                if (sClause.Trim().Length == 0)
                {
                    sClause = "ProductCode = '" + txtCode.Text + "' ";
                    
                }
                else
                {
                    sClause = sClause + " AND ProductCode = '" + txtCode.Text + "' ";
                  
                }
            }

            if (txtName.Text != "")
            {
                if (sClause.Trim().Length == 0)
                {
                    sClause = "ProductName Like '%" + txtName.Text + "%' ";
                   
                }
                else
                {
                    sClause = sClause + " AND ProductName Like '" + txtName.Text + "' ";
                   
                }
            }

            DataRow[] oDR = oDSProduct.Product.Select(sClause);
            oDSFilterProduct = new  CJ.Class.POS.DSProduct();
            oDSFilterProduct.Merge(oDR);
            oDSFilterProduct.AcceptChanges();

            lvwProduct.Items.Clear();
            oSystemInfo = new CJ.Class.POS.SystemInfo();
            CJ.Class.DBController.Instance.OpenNewConnection();
            oSystemInfo.Refresh();
            CJ.Class.DBController.Instance.CloseConnection();
            foreach (CJ.Class.POS.DSProduct.ProductRow oProductRow in oDSFilterProduct.Product)
            {
                ListViewItem oItem = lvwProduct.Items.Add(oProductRow.ProductCode);
                oItem.SubItems.Add((oProductRow.ProductName).ToString());
                oItem.SubItems.Add((oProductRow.ProductDesc).ToString());

                _oWUIUtility = new CJ.Class.Web.UI.Class.WUIUtility();
                CJ.Class.DBController.Instance.OpenNewConnection();
                _oWUIUtility.GetPOSStock(oSystemInfo.WarehouseID, int.Parse(oProductRow.ProductID.ToString()));
                CJ.Class.DBController.Instance.CloseConnection();
                oItem.SubItems.Add((_oWUIUtility.CurrentStock).ToString());

                oItem.Tag = oProductRow;
            }

            this.Text = "Products " + lvwProduct.Items.Count.ToString();

            if (lvwProduct.Items.Count > 0)
            {
                lvwProduct.Items[0].Selected = true;
                lvwProduct.Focus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvwProduct_DoubleClick(object sender, EventArgs e)
        {
            returnSelectedProduct();
            this.Close();
        }

        private void lvwProduct_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lvwProduct.Sorting == SortOrder.Ascending)
            {
                lvwProduct.Sorting = SortOrder.Descending;
            }
            else
            {
                lvwProduct.Sorting = SortOrder.Ascending;
            }
            lvwProduct.Sort();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {            
              refreshListBySearch();
          
        }

        private void returnSelectedProduct()
        {
           
            foreach (ListViewItem oItem in lvwProduct.SelectedItems)
            {
                CJ.Class.POS.DSProduct.ProductRow oProductRow = (CJ.Class.POS.DSProduct.ProductRow)lvwProduct.SelectedItems[0].Tag;
                oDSSelectedProduct = new  CJ.Class.POS.DSProduct();

                CJ.Class.POS.DSProduct.ProductRow oSelectedProductRow = oDSSelectedProduct.Product.NewProductRow();

                oSelectedProductRow.ProductName = oProductRow.ProductName;
                oSelectedProductRow.ProductCode = oProductRow.ProductCode;
                oSelectedProductRow.ProductDesc = oProductRow.ProductDesc;
                oSelectedProductRow.ProductID = oProductRow.ProductID;

                oDSSelectedProduct.Product.AddProductRow(oSelectedProductRow);
                oDSSelectedProduct.AcceptChanges();
            }

        }
        private void lvwProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                returnSelectedProduct();
                this.Close();
            }
        }
        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSearchProduct_Load(object sender, EventArgs e)
        {
            LoadCombos();
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            oDSSelectedProduct = new  CJ.Class.POS.DSProduct();

            for (int i = 0; i < lvwProduct.Items.Count; i++)
            {               
                if (lvwProduct.Items[i].Checked == true)
                {
                    CJ.Class.POS.DSProduct.ProductRow oProductRow = (CJ.Class.POS.DSProduct.ProductRow)lvwProduct.Items[i].Tag;                     

                    CJ.Class.POS.DSProduct.ProductRow oSelectedProductRow = oDSSelectedProduct.Product.NewProductRow();

                    oSelectedProductRow.ProductName = oProductRow.ProductName;
                    oSelectedProductRow.ProductCode = oProductRow.ProductCode;
                    oSelectedProductRow.ProductDesc = oProductRow.ProductDesc;
                    oSelectedProductRow.ProductID = oProductRow.ProductID;

                    oDSSelectedProduct.Product.AddProductRow(oSelectedProductRow);
                    oDSSelectedProduct.AcceptChanges();
                }
            }
            this.Close();
            
        }

        private void btSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lvwProduct.Items.Count; i++)
            {
                ListViewItem itm = lvwProduct.Items[i];
                lvwProduct.Items[i].Checked = true;
                
            }
        }

        private void cboPG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_nCountPG > 0)
            {
                if (int.Parse(cboPG.SelectedValue.ToString()) != -1)
                {
                    oDSProductGroupsMAG = new  CJ.Class.POS.DSProductGroups();
                    DataRow[] oDR = oDSProductGroups.MAGGroup.Select("ParentId ='" + int.Parse(cboPG.SelectedValue.ToString()) + "' or PdtGroupId= -1");
                    oDSProductGroupsMAG.Merge(oDR);
                    oDSProductGroupsMAG.AcceptChanges();

                    //MAG
                    if (oDSProductGroupsMAG.MAGGroup.Rows.Count > 0)
                    {
                        cboMAG.ValueMember = "PdtGroupId";
                        cboMAG.DisplayMember = "PdtGroupName";
                        cboMAG.DataSource = oDSProductGroupsMAG.MAGGroup;
                        cboMAG.SelectedIndex = 0;
                    }
                }
            }
            _nCountPG++;
        }

        private void cboMAG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.Parse(cboMAG.SelectedValue.ToString()) != -1)
            {
                oDSProductGroupsASG = new  CJ.Class.POS.DSProductGroups();
                DataRow[] oDR = oDSProductGroups.ASGGroup.Select(" ParentId = '" + int.Parse(cboMAG.SelectedValue.ToString()) + "'or PdtGroupId= -1 ");
                oDSProductGroupsASG.Merge(oDR);
                oDSProductGroupsASG.AcceptChanges();

                //ASG
                if (oDSProductGroupsASG.ASGGroup.Rows.Count > 0)
                {
                    cboASG.ValueMember = "PdtGroupId";
                    cboASG.DisplayMember = "PdtGroupName";
                    cboASG.DataSource = oDSProductGroupsASG.ASGGroup;
                    cboASG.SelectedIndex = 0;
                }
            }
           
        }

        private void cboASG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (int.Parse(cboASG.SelectedValue.ToString()) != -1)
            {
                oDSProductGroupsAG = new  CJ.Class.POS.DSProductGroups();
                DataRow[] oDR = oDSProductGroups.AGGroup.Select(" ParentId = '" + int.Parse(cboASG.SelectedValue.ToString()) + "' or PdtGroupId= -1");
                oDSProductGroupsAG.Merge(oDR);
                oDSProductGroupsAG.AcceptChanges();

                //AG
                if (oDSProductGroupsAG.AGGroup.Rows.Count > 0)
                {
                    cboAG.ValueMember = "PdtGroupId";
                    cboAG.DisplayMember = "PdtGroupName";
                    cboAG.DataSource = oDSProductGroupsAG.AGGroup;
                    cboAG.SelectedIndex = 0;
                }

            }
        }

    }
}
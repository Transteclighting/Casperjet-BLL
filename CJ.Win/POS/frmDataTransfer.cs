// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Apr 20, 2011
// Time :  07:44 PM
// Description: Class for Data Transfer.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.DataTransfer;
using CJ.Class.Promotion;
using CJ.Class.Warranty;
using CJ.Class.POS;
using CJ.Class.BasicData;

namespace CJ.Win.POS
{
    public partial class frmDataTransfer : Form
    {
        Warehouses _oWarehouses;
        DataTransfer _oDataTransfer;

        Brands oBrands;
        ProductGroups oProductGroups;
        Products oProducts;
        Employees oEmployees;
        Warehouses oWarehouses;
        SPromotions oSPromotions;
        Warranties oWarranties;
        ProductDetails oProductDetails;
        Showrooms _oShowrooms;
        DataTran _oDataTran;
        Users oUsers;
        int nCount = 0;

        public frmDataTransfer()
        {
            InitializeComponent();
        }

        private void frmDataTransfer_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadOutlet();
        }
        public void LoadData()
        {
            cmbTableName.SelectedIndex = 0;

            foreach (int GetEnum in Enum.GetValues(typeof(CJ.Class.Dictionary.DataTransferType)))
            {
                cmbTransferType.Items.Add(Enum.GetName(typeof(CJ.Class.Dictionary.DataTransferType), GetEnum));
            }
            cmbTransferType.SelectedIndex = 0;

        }
        private void LoadOutlet()
        {
            DBController.Instance.OpenNewConnection();
            _oShowrooms = new Showrooms();
            _oShowrooms.GetShowroomByName(txtOutlet.Text, "");
            DBController.Instance.CloseConnection();
            lvwOutlet.Items.Clear();
            foreach (Showroom oShowroom in _oShowrooms)
            {
                ListViewItem lstItem = lvwOutlet.Items.Add(oShowroom.WarehouseID.ToString());
                lstItem.SubItems.Add(oShowroom.ShowroomName + "[" + oShowroom.ShowroomCode + "]");
                lstItem.Tag = oShowroom;
            }
        }
        private void cmbTableName_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBController.Instance.OpenNewConnection();
            if (cmbTableName.Text == "t_Brand")
            {
                oBrands = new Brands();
                oBrands.GetAllBrand(Dictionary.BrandLevel.MasterBrand);

                lvwDataList.Items.Clear();
                foreach (Brand oBrand in oBrands)
                {
                    ListViewItem lstItem = lvwDataList.Items.Add(oBrand.BrandID.ToString());
                    lstItem.SubItems.Add(oBrand.BrandDesc);
                    lstItem.Tag = oBrand;
                }
            }
            else if (cmbTableName.Text == "t_ProductGroup")
            {
                oProductGroups = new ProductGroups();
                oProductGroups.GetAllProductGroup();

                lvwDataList.Items.Clear();
                foreach (ProductGroup oProductGroup in oProductGroups)
                {
                    ListViewItem lstItem = lvwDataList.Items.Add(oProductGroup.PdtGroupID.ToString());
                    lstItem.SubItems.Add(oProductGroup.PdtGroupName);
                    lstItem.Tag = oProductGroup;
                }
            }
            else if (cmbTableName.Text == "v_productDetails")
            {
                oProducts = new Products();
                oProducts.Refresh();

                lvwDataList.Items.Clear();
                foreach (Product oProduct in oProducts)
                {
                    ListViewItem lstItem = lvwDataList.Items.Add(oProduct.ProductID.ToString());
                    lstItem.SubItems.Add(oProduct.ProductName);
                    lstItem.Tag = oProduct;
                }
            }
            else if (cmbTableName.Text == "v_EmployeeDetails")
            {
                oEmployees = new Employees();
                oEmployees.Refresh();

                lvwDataList.Items.Clear();
                foreach (Employee oEmployee in oEmployees)
                {
                    ListViewItem lstItem = lvwDataList.Items.Add(oEmployee.EmployeeID.ToString());
                    lstItem.SubItems.Add(oEmployee.EmployeeName);
                    lstItem.Tag = oEmployee;
                }
            }

            else if (cmbTableName.Text == "t_Showroom")
            {
                _oShowrooms = new Showrooms();
                _oShowrooms.GetAllShowroom();

                lvwDataList.Items.Clear();
                foreach (Showroom oShowroom in _oShowrooms)
                {
                    ListViewItem lstItem = lvwDataList.Items.Add(oShowroom.ShowroomID.ToString());
                    lstItem.SubItems.Add(oShowroom.ShowroomName + "[" + oShowroom.ShowroomCode + "]");
                    lstItem.Tag = oShowroom;
                }
            }
            else if (cmbTableName.Text == "t_SalesPromo")
            {
                oSPromotions = new SPromotions();
                oSPromotions.GetPromotiom();

                lvwDataList.Items.Clear();
                foreach (SPromotion oSPromotion in oSPromotions)
                {
                    ListViewItem lstItem = lvwDataList.Items.Add(oSPromotion.SalesPromotionID.ToString());
                    lstItem.SubItems.Add(oSPromotion.SalesPromotionName);
                    lstItem.Tag = oSPromotion;
                }
            }
            else if (cmbTableName.Text == "t_WarrantyParam")
            {
                WarrantyParams oWarrantyParams = new WarrantyParams();
                oWarrantyParams.Refresh();

                lvwDataList.Items.Clear();
                foreach (WarrantyParam oWarrantyParam in oWarrantyParams)
                {
                    ListViewItem lstItem = lvwDataList.Items.Add(oWarrantyParam.WarrantyParamID.ToString());
                    lstItem.SubItems.Add(oWarrantyParam.ProductID.ToString());
                    lstItem.Tag = oWarrantyParam;
                }
            }
            else if (cmbTableName.Text == "t_FinishedGoodsPrice")
            {
                oProductDetails = new ProductDetails();
                oProductDetails.GetPriceInfo();

                lvwDataList.Items.Clear();
                foreach (ProductDetail oProductDetail in oProductDetails)
                {
                    ListViewItem lstItem = lvwDataList.Items.Add(oProductDetail.PriceID.ToString());
                    lstItem.SubItems.Add("");
                    lstItem.Tag = oProductDetail;
                }
            }
            else if (cmbTableName.Text == "t_user")
            {
                oUsers = new Users();
                oUsers.GetData(txtDescription.Text, "", 0);

                lvwDataList.Items.Clear();
                foreach (User oUser in oUsers)
                {
                    ListViewItem lstItem = lvwDataList.Items.Add(oUser.UserId.ToString());
                    lstItem.SubItems.Add(oUser.Username);
                    lstItem.Tag = oUser;
                }
            }
            DBController.Instance.CloseConnection();
        }
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                Save();
                this.Close();
            }
            
        }
        private bool UIValidation()
        {
            nCount = 0;
            for (int i = 0; i < lvwDataList.Items.Count; i++)
            {
                ListViewItem itm = lvwDataList.Items[i];
                if (lvwDataList.Items[i].Checked == true)
                {
                    nCount++;
                }
            }
            if (nCount == 0)
            {
                MessageBox.Show("You have to checked at least a Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            nCount = 0;
            for (int h = 0; h < lvwOutlet.Items.Count; h++)
            {
                ListViewItem item = lvwOutlet.Items[h];

                if (lvwOutlet.Items[h].Checked == true)
                {
                    nCount++;
                }
            }
            if (nCount == 0)
            {
                MessageBox.Show("You have to checked at least a Outlet", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }
        private void Save()
        {
            try
            {
                DBController.Instance.BeginNewTransaction();
                int nTransferType = 0;
                nTransferType = GetTransferType();
                for (int i = 0; i < lvwDataList.Items.Count; i++)
                {
                    ListViewItem itm = lvwDataList.Items[i];
                    if (lvwDataList.Items[i].Checked == true)
                    {
                        if (cmbTableName.Text == "t_Brand")
                        {
                            Brand oBrand = (Brand)lvwDataList.Items[i].Tag;
                            InsertData("t_Brand", oBrand.BrandID, nTransferType);
                        }
                        else if (cmbTableName.Text == "t_ProductGroup")
                        {
                            ProductGroup oProductGroup = (ProductGroup)lvwDataList.Items[i].Tag;
                            InsertData("t_ProductGroup", oProductGroup.PdtGroupID, nTransferType);
                        }
                        else if (cmbTableName.Text == "v_productDetails")
                        {
                            Product oProduct = (Product)lvwDataList.Items[i].Tag;
                            InsertData("t_Product", oProduct.ProductID, nTransferType);
                        }
                        else if (cmbTableName.Text == "v_EmployeeDetails")
                        {
                            Employee oEmployee = (Employee)lvwDataList.Items[i].Tag;
                            InsertData("v_EmployeeDetails", oEmployee.EmployeeID, nTransferType);
                        }
                        //else if (cmbTableName.Text == "t_Warehouse")
                        //{
                        //    Warehouse oWarehouse = (Warehouse)lvwDataList.Items[i].Tag;
                        //    InsertData("t_Warehouse", oWarehouse.WarehouseID, nTransferType);
                        //}
                        else if (cmbTableName.Text == "t_Showroom")
                        {
                            Showroom oShowroom = (Showroom)lvwDataList.Items[i].Tag;
                            InsertData("t_Showroom", oShowroom.ShowroomID, nTransferType);
                        }
                        else if (cmbTableName.Text == "t_SalesPromotion")
                        {
                            SPromotion oSPromotion = (SPromotion)lvwDataList.Items[i].Tag;
                            InsertData("t_SalesPromotion", oSPromotion.SalesPromotionID, nTransferType);
                        }
                        else if (cmbTableName.Text == "t_WarrantyParam")
                        {

                            WarrantyParam oWarrantyParam = (WarrantyParam)lvwDataList.Items[i].Tag;
                            InsertData("t_WarrantyParam", oWarrantyParam.WarrantyParamID, nTransferType);
                        }
                        else if (cmbTableName.Text == "t_FinishedGoodsPrice")
                        {
                            ProductDetail oProductDetail = (ProductDetail)lvwDataList.Items[i].Tag;
                            InsertData("t_FinishedGoodsPrice", oProductDetail.PriceID, nTransferType);
                        }
                        else if (cmbTableName.Text == "t_user")
                        {
                            User oUser = (User)lvwDataList.Items[i].Tag;
                            InsertData("t_user", oUser.UserId, nTransferType);
                        }
                    }
                }
                DBController.Instance.CommitTransaction();
                MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }
        private void InsertData(string sTableName, int nDataID,int nTransferType)
        {
            for (int h = 0; h < lvwOutlet.Items.Count; h++)
            {
                ListViewItem item = lvwOutlet.Items[h];

                if (lvwOutlet.Items[h].Checked == true)
                {
                    Showroom oShowroom = (Showroom)lvwOutlet.Items[h].Tag;
                    _oDataTran = new DataTran();

                    _oDataTran.TableName = sTableName;
                    _oDataTran.DataID = nDataID;
                    _oDataTran.WarehouseID = oShowroom.WarehouseID;
                    _oDataTran.TransferType = nTransferType;
                    _oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                    _oDataTran.BatchNo = 0;
                    _oDataTran.AddForTDPOS();

                }
            }
        
        }
        private int GetTransferType()
        {
            int nTransferType = 0;
            if (cmbTransferType.Text == "Add")
                nTransferType = (int)Dictionary.DataTransferType.Add;
            if (cmbTransferType.Text == "Edit")
                nTransferType = (int)Dictionary.DataTransferType.Edit;
            if (cmbTransferType.Text == "Delete")
                nTransferType = (int)Dictionary.DataTransferType.Delete;

            return nTransferType;
        }
        private void chkData_CheckedChanged(object sender, EventArgs e)
        {
            if (chkData.Checked == true)
            {
                for (int i = 0; i < lvwDataList.Items.Count; i++)
                {
                    ListViewItem itm = lvwDataList.Items[i];

                    lvwDataList.Items[i].Checked = true;

                }
            }
            else
            {
                for (int i = 0; i < lvwDataList.Items.Count; i++)
                {
                    ListViewItem itm = lvwDataList.Items[i];

                    lvwDataList.Items[i].Checked = false;

                }
            }
        }
        private void chkOutlet_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOutlet.Checked == true)
            {
                for (int i = 0; i < lvwOutlet.Items.Count; i++)
                {
                    ListViewItem itm = lvwOutlet.Items[i];

                    lvwOutlet.Items[i].Checked = true;

                }
            }
            else
            {
                for (int i = 0; i < lvwOutlet.Items.Count; i++)
                {
                    ListViewItem itm = lvwOutlet.Items[i];

                    lvwOutlet.Items[i].Checked = false;

                }
            }
        }
        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            cmbTableName_SelectedIndexChanged(null, null);
            //(lvwDataList.DataSource as DataTable).DefaultView.RowFilter = string.Format("Product_Code like '%{0}%' OR Product_Name like '%{0}%' OR AG like '%{0}%' OR ASG like '%{0}%' OR MAG like '%{0}%' OR PG like '%{0}%' OR Brand like '%{0}%' OR ProductSerialNo like '%{0}%'", txtSearch.Text);
        }
        private void txtOutlet_TextChanged(object sender, EventArgs e)
        {
            LoadOutlet();
        }
    }
}
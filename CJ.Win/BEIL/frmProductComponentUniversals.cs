using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CJ.Class;
using CJ.Report;

namespace CJ.Win.BEIL
{
    public partial class frmProductComponentUniversals : Form
    {
        private ProductGroups _oPG;
        private ProductGroups _oMAG;
        private ProductGroups _oASG;
        private ProductGroups _oAG;
        private ProductGroups _oComponents;
        private Brands _oBrands;
        ProductComponents oProductComponents;
        int _ProductionType = 0;
        int _IsIndoorItem = 0;
        public frmProductComponentUniversals(int nProductionType, int nIsIndoorItem)
        {
            InitializeComponent();
            _ProductionType = nProductionType;
            _IsIndoorItem = nIsIndoorItem;

            if(nProductionType==1)
            {
                btnPrint.Visible = false;
            }
            else
            {
                btnPrint.Visible = true;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmProductComponentUniversal oForm = new frmProductComponentUniversal(1,_ProductionType,_IsIndoorItem);
            oForm.ShowDialog();
            if (oForm._IsTrue == true)
                DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwProductComponentUniversals.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ProductComponent oProductComponent = (ProductComponent)lvwProductComponentUniversals.SelectedItems[0].Tag;
            frmProductComponentUniversal oForm = new frmProductComponentUniversal(2, _ProductionType, _IsIndoorItem);
            oForm.ShowDialog(oProductComponent);
            if (oForm._IsTrue == true)
                DataLoadControl();

        }
        private void LoadCombo()
        {

            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            dtFromDate.Value = DateTime.Now.Date;
            dtToDate.Value = DateTime.Now.Date;
            _oBrands = new Brands();
            _oBrands.GetAllBrand(Dictionary.BrandLevel.MasterBrand);
            cmbBrand.Items.Clear();
            cmbBrand.Items.Add("<All>");
            foreach (Brand oBrand in _oBrands)
            {
                cmbBrand.Items.Add(oBrand.BrandDesc);
            }
            cmbBrand.SelectedIndex = 0;

            //PG
            _oPG = new ProductGroups();
            _oPG.GETPG();
            cboPG.Items.Clear();
            cboPG.Items.Add("<All>");
            foreach (ProductGroup oProductGroup in _oPG)
            {
                cboPG.Items.Add(oProductGroup.PdtGroupName);
            }
            cboPG.SelectedIndex = 0;

            //MAG
            _oMAG = new ProductGroups();
            _oMAG.GETMAG();
            cboMAG.Items.Clear();
            cboMAG.Items.Add("<All>");
            foreach (ProductGroup oProductGroup in _oMAG)
            {
                cboMAG.Items.Add(oProductGroup.PdtGroupName);
            }
            cboMAG.SelectedIndex = 0;

            //ASG
            _oASG = new ProductGroups();
            _oASG.GETASG();
            cboASG.Items.Clear();
            cboASG.Items.Add("<All>");
            foreach (ProductGroup oProductGroup in _oASG)
            {
                cboASG.Items.Add(oProductGroup.PdtGroupName);
            }
            cboASG.SelectedIndex = 0;

            //AG
            _oAG = new ProductGroups();
            _oAG.GETAG();
            cboAG.Items.Clear();
            cboAG.Items.Add("<All>");
            foreach (ProductGroup oProductGroup in _oAG)
            {
                cboAG.Items.Add(oProductGroup.PdtGroupName);
            }
            cboAG.SelectedIndex = 0;

            //Component Name
            _oComponents = new ProductGroups();
            _oComponents.GetProductComponent();
            cmbComponentName.Items.Clear();
            cmbComponentName.Items.Add("<All>");
            foreach (ProductGroup oProductGroup in _oComponents)
            {
                cmbComponentName.Items.Add(oProductGroup.ComponentName);
            }
            cmbComponentName.SelectedIndex = 0;
        }
        private void DataLoadControl()
        {
            oProductComponents = new ProductComponents();
            lvwProductComponentUniversals.Items.Clear();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            bool IsCheck = false;
            if (chkAll.Checked == true)
            {
                IsCheck = true;
            }
            else
            {
                IsCheck = false;
            }

            int nBrand = 0;
            if (cmbBrand.SelectedIndex == 0)
            {
                nBrand = -1;
            }
            else
            {
                nBrand = _oBrands[cmbBrand.SelectedIndex - 1].BrandID;
            }

            int nAG = 0;
            if (cboAG.SelectedIndex == 0)
            {
                nAG = -1;
            }
            else
            {
                nAG = _oAG[cboAG.SelectedIndex - 1].PdtGroupID;
            }

            int nASG = 0;
            if (cboASG.SelectedIndex == 0)
            {
                nASG = -1;
            }
            else
            {
                nASG = _oASG[cboASG.SelectedIndex - 1].PdtGroupID;
            }

            int nMAG = 0;
            if (cboMAG.SelectedIndex == 0)
            {
                nMAG = -1;
            }
            else
            {
                nMAG = _oMAG[cboMAG.SelectedIndex - 1].PdtGroupID;
            }

            int nPG = 0;
            if (cboPG.SelectedIndex == 0)
            {
                nPG = -1;
            }
            else
            {
                nPG = _oPG[cboPG.SelectedIndex - 1].PdtGroupID;
            }
            int nComponentID = 0;
            if (cmbComponentName.SelectedIndex == 0)
            {
                nComponentID = -1;
            }
            else
            {
                nComponentID = _oComponents[cmbComponentName.SelectedIndex - 1].ComponentID;
            }
            oProductComponents.GetProductComponentUniversal(dtFromDate.Value.Date, dtToDate.Value.Date, nPG, nMAG, nASG, nAG, nBrand, nComponentID, txtSerialNo.Text.Trim(), ctlProduct1.txtCode.Text.Trim(), IsCheck, _IsIndoorItem, _ProductionType);
            string[] all = new string[oProductComponents.Count];
            int i = 0;
            foreach (ProductComponent oProductComponent in oProductComponents)
            {
                ListViewItem oItem = lvwProductComponentUniversals.Items.Add(oProductComponent.SetID.ToString());
                oItem.SubItems.Add(oProductComponent.ProductCode.ToString());
                oItem.SubItems.Add(oProductComponent.ProductName.ToString());
                oItem.SubItems.Add(oProductComponent.ProductModel.ToString());
                oItem.SubItems.Add(oProductComponent.AGName.ToString());
                oItem.SubItems.Add(oProductComponent.ASGName.ToString());
                oItem.SubItems.Add(oProductComponent.MAGName.ToString());
                oItem.SubItems.Add(oProductComponent.PGName.ToString());
                oItem.SubItems.Add(oProductComponent.BrandDesc.ToString());
                oItem.SubItems.Add(oProductComponent.ComponentName.ToString());
                oItem.SubItems.Add(oProductComponent.ProductSerial.ToString());
                oItem.SubItems.Add(oProductComponent.CreateDate.ToString("dd-MMM-yyyy hh:mm tt"));
                oItem.SubItems.Add(oProductComponent.CreateUser.ToString());
                all[i] = oProductComponent.SetID.ToString();
                i++;
                oItem.Tag = oProductComponent;
            }
            int distinctCount = all.Distinct().Count();
            if (_ProductionType == (int)Dictionary.ProductionType.CBU)
            {
                this.Text = "Product Component Serial Universal-(CBU) " + "[Total Component:" + oProductComponents.Count + ",Total Set:" + distinctCount + " ]";
            }
            else
            {
                this.Text = "Product Component Serial Universal-(SKD) " + "[Total Component:" + oProductComponents.Count + ",Total Set:" + distinctCount + " ]";
            }



        }
        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                dtFromDate.Enabled = false;
                dtToDate.Enabled = false;
            }
            else
            {
                dtFromDate.Enabled = true;
                dtToDate.Enabled = true;
            }
        }

        private void frmProductComponentUniversals_Load(object sender, EventArgs e)
        {
            if (_ProductionType == (int)Dictionary.ProductionType.CBU)
            {
                this.Text = "Product Component Serial Universal (CBU)";
            }
            else
            {
                this.Text = "Product Component Serial Universal (SKD)";
            }
            LoadCombo();
        }
        string sType = "";
        int nREF = 22;
        int nFRZ = 811;
        int nFPTV = 791;
        int nHTV = 792;
        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (_IsIndoorItem == 1)
            {
                rptProductComponentACIndoorNew doc = new rptProductComponentACIndoorNew();
                ProductComponent oProductComponent = (ProductComponent)lvwProductComponentUniversals.SelectedItems[0].Tag;

                oProductComponents.RefreshComponent(oProductComponent.ProductCode, oProductComponent.SetID, _ProductionType, _IsIndoorItem, oProductComponent.LocationID);
                doc.SetDataSource(oProductComponents);
                doc.SetParameterValue("Product", oProductComponent.ProductName);

                frmPrintPreview oForm = new frmPrintPreview();
                oForm.ShowDialog(doc);
            }
            else
            {
                ProductComponent oProductComponent = (ProductComponent)lvwProductComponentUniversals.SelectedItems[0].Tag;
                ProductDetail oProductDetail = new ProductDetail();
                oProductDetail.Refresh(oProductComponent.ProductID);
                if (oProductDetail.MAGID == nREF || oProductDetail.MAGID == nFRZ)
                {
                    sType = "REF";
                }
                else if (oProductDetail.MAGID == nFPTV || oProductDetail.MAGID == nHTV)
                {
                    sType = "TV";
                }
                else
                {
                    sType = "AC";
                }

                if (sType == "REF")
                {
                    rptProductComponentRefNew doc = new rptProductComponentRefNew();
                    
                    oProductComponents.RefreshComponent(oProductComponent.ProductCode, oProductComponent.SetID, _ProductionType, _IsIndoorItem, oProductComponent.LocationID);
                    doc.SetDataSource(oProductComponents);
                    doc.SetParameterValue("Product", oProductComponent.ProductName);

                    frmPrintPreview oForm = new frmPrintPreview();
                    oForm.ShowDialog(doc);
                }
                else if (sType == "AC")
                {
                    rptProductComponentACNew doc = new rptProductComponentACNew();
                    
                    oProductComponents.RefreshComponent(oProductComponent.ProductCode, oProductComponent.SetID, _ProductionType, _IsIndoorItem, oProductComponent.LocationID);
                    doc.SetDataSource(oProductComponents);
                    doc.SetParameterValue("Product", oProductComponent.ProductName);

                    frmPrintPreview oForm = new frmPrintPreview();
                    oForm.ShowDialog(doc);
                }
                else
                {
                    rptProductComponentNew doc = new rptProductComponentNew();
                    
                    oProductComponents.RefreshComponent(oProductComponent.ProductCode, oProductComponent.SetID, _ProductionType, _IsIndoorItem, oProductComponent.LocationID);
                    doc.SetDataSource(oProductComponents);
                    doc.SetParameterValue("Product", oProductComponent.ProductName);

                    frmPrintPreview oForm = new frmPrintPreview();
                    oForm.ShowDialog(doc);
                }
            }
        }

        private void btnPrintHeader_Click(object sender, EventArgs e)
        {
            if (_IsIndoorItem == 1)
            {
                rptProductComponentACIndoorNewHeader doc = new rptProductComponentACIndoorNewHeader();
                ProductComponent oProductComponent = (ProductComponent)lvwProductComponentUniversals.SelectedItems[0].Tag;

                oProductComponents.RefreshComponent(oProductComponent.ProductCode, oProductComponent.SetID, _ProductionType, _IsIndoorItem, oProductComponent.LocationID);
                doc.SetDataSource(oProductComponents);
                doc.SetParameterValue("Product", oProductComponent.ProductName);

                frmPrintPreview oForm = new frmPrintPreview();
                oForm.ShowDialog(doc);
            }
            else
            {
                ProductComponent oProductComponent = (ProductComponent)lvwProductComponentUniversals.SelectedItems[0].Tag;
                ProductDetail oProductDetail = new ProductDetail();
                oProductDetail.Refresh(oProductComponent.ProductID);
                if (oProductDetail.MAGID == nREF || oProductDetail.MAGID == nFRZ)
                {
                    sType = "REF";
                }
                else if (oProductDetail.MAGID == nFPTV || oProductDetail.MAGID == nHTV)
                {
                    sType = "TV";
                }
                else
                {
                    sType = "AC";
                }

                if (sType == "REF")
                {
                    rptProductComponentRefNewHeader doc = new rptProductComponentRefNewHeader();

                    oProductComponents.RefreshComponent(oProductComponent.ProductCode, oProductComponent.SetID, _ProductionType, _IsIndoorItem, oProductComponent.LocationID);
                    doc.SetDataSource(oProductComponents);
                    doc.SetParameterValue("Product", oProductComponent.ProductName);

                    frmPrintPreview oForm = new frmPrintPreview();
                    oForm.ShowDialog(doc);
                }
                else if (sType == "AC")
                {
                    rptProductComponentACNewHeader doc = new rptProductComponentACNewHeader();

                    oProductComponents.RefreshComponent(oProductComponent.ProductCode, oProductComponent.SetID, _ProductionType, _IsIndoorItem, oProductComponent.LocationID);
                    doc.SetDataSource(oProductComponents);
                    doc.SetParameterValue("Product", oProductComponent.ProductName);

                    frmPrintPreview oForm = new frmPrintPreview();
                    oForm.ShowDialog(doc);
                }
                else
                {
                    rptProductComponentNewHeader doc = new rptProductComponentNewHeader();

                    oProductComponents.RefreshComponent(oProductComponent.ProductCode, oProductComponent.SetID, _ProductionType, _IsIndoorItem, oProductComponent.LocationID);
                    doc.SetDataSource(oProductComponents);
                    doc.SetParameterValue("Product", oProductComponent.ProductName);

                    frmPrintPreview oForm = new frmPrintPreview();
                    oForm.ShowDialog(doc);
                }
            }
        }
    }
}

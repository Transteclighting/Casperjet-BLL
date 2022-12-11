using System;
using System.Linq;
using System.Windows.Forms;
using CJ.Class;
using CJ.Report;
using System.Drawing;

namespace CJ.Factory
{
    public partial class frmProductComponentUniversals : Form
    {
        public event System.EventHandler ChangeSelection;
        public event KeyPressEventHandler ChangeFocus;
        SerarchProduct oSerarchProductOld;

        SerarchProduct oSerarchProduct;
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

            if(nProductionType== (int)Dictionary.ProductionType.Repair)
            {
                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnPrint.Visible = false;
                btnPrintHeader.Visible = false;
                btnDefective.Text = "Repair";
                btnDefective.Visible = true;

                cbIsDefective.Checked = true;
                cbIsDefective.Enabled = false;
            }
            else
            {
                cbIsDefective.Checked = false;
                cbIsDefective.Enabled = false;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
                frmProductComponentUniversal oForm = new frmProductComponentUniversal(1, _ProductionType, _IsIndoorItem);
                if (_ProductionType == 3)
                {
                    oForm.ShowDialog(_ProductionType);
                }
                else
                {
                    oForm.ShowDialog();
                }
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
           
            int nID = 0;
            ProductComponent oComponent = new ProductComponent();
            nID = oComponent.GetDefectiveSetID(oProductComponent.SetID);
            if (nID != 0)
            {
                MessageBox.Show("Defective Declared, Please Repair First", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }            

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
            _oBrands.GetAllBrandFactory();
            cmbBrand.Items.Clear();
            cmbBrand.Items.Add("<All>");
            foreach (Brand oBrand in _oBrands)
            {
                cmbBrand.Items.Add(oBrand.BrandDesc);
            }
            cmbBrand.SelectedIndex = 0;

            //PG
            _oPG = new ProductGroups();
            _oPG.GEProductGroupFactory("PGName","PGID");
            cboPG.Items.Clear();
            cboPG.Items.Add("<All>");
            foreach (ProductGroup oProductGroup in _oPG)
            {
                cboPG.Items.Add(oProductGroup.PdtGroupName);
            }
            cboPG.SelectedIndex = 0;

            //MAG
            _oMAG = new ProductGroups();
            _oMAG.GEProductGroupFactory("MAGName", "MAGID");
            cboMAG.Items.Clear();
            cboMAG.Items.Add("<All>");
            foreach (ProductGroup oProductGroup in _oMAG)
            {
                cboMAG.Items.Add(oProductGroup.PdtGroupName);
            }
            cboMAG.SelectedIndex = 0;

            //ASG
            _oASG = new ProductGroups();
            _oASG.GEProductGroupFactory("ASGName", "ASGID");
            cboASG.Items.Clear();
            cboASG.Items.Add("<All>");
            foreach (ProductGroup oProductGroup in _oASG)
            {
                cboASG.Items.Add(oProductGroup.PdtGroupName);
            }
            cboASG.SelectedIndex = 0;

            //AG
            _oAG = new ProductGroups();
            _oAG.GEProductGroupFactory("AGName", "AGID");
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

            int nIsDefective = 0;
            if (!cbIsDefective.Checked)
            {
                nIsDefective = -1;
            }
            else
            {
                nIsDefective = 1;
            }

            if(_ProductionType==(int)Dictionary.LCMStatus.Stage_4)
            {
                _ProductionType = 3;
            }

            oProductComponents.GetProductComponentUniversalFactory(dtFromDate.Value.Date, dtToDate.Value.Date, nPG, nMAG, nASG, nAG, nBrand, nComponentID, txtSerialNo.Text.Trim(), txtCode.Text.Trim(), IsCheck, _IsIndoorItem, _ProductionType, nIsDefective,-1);
            string[] all = new string[oProductComponents.Count];
            string[] allFG = new string[oProductComponents.Count];
            int i = 0;
            foreach (ProductComponent oProductComponent in oProductComponents)
            {
                //if (oProductComponent.ComponentID != 7 && _ProductionType!=3)
                
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
                if(oProductComponent.ComponentID==7 && oProductComponent.ProductSerial!="")
                {
                    allFG[i] = oProductComponent.SetID.ToString();
                }
                
                i++;
                oItem.Tag = oProductComponent;
                
                //else if(_ProductionType==3)
                //{
                //    ListViewItem oItem = lvwProductComponentUniversals.Items.Add(oProductComponent.SetID.ToString());
                //    oItem.SubItems.Add(oProductComponent.ProductCode.ToString());
                //    oItem.SubItems.Add(oProductComponent.ProductName.ToString());
                //    oItem.SubItems.Add(oProductComponent.ProductModel.ToString());
                //    oItem.SubItems.Add(oProductComponent.AGName.ToString());
                //    oItem.SubItems.Add(oProductComponent.ASGName.ToString());
                //    oItem.SubItems.Add(oProductComponent.MAGName.ToString());
                //    oItem.SubItems.Add(oProductComponent.PGName.ToString());
                //    oItem.SubItems.Add(oProductComponent.BrandDesc.ToString());
                //    oItem.SubItems.Add(oProductComponent.ComponentName.ToString());
                //    oItem.SubItems.Add(oProductComponent.ProductSerial.ToString());
                //    oItem.SubItems.Add(oProductComponent.CreateDate.ToString("dd-MMM-yyyy hh:mm tt"));
                //    oItem.SubItems.Add(oProductComponent.CreateUser.ToString());
                //    all[i] = oProductComponent.SetID.ToString();
                //    i++;
                //    oItem.Tag = oProductComponent;
                //}
            }
            int distinctCount = all.Distinct().Count();
            int distinctFGCount = 0;
            allFG = allFG.Where(s => !String.IsNullOrEmpty(s)).ToArray();
            if (distinctCount == 0)
            {
                distinctFGCount = 0;//allFG.Distinct().Count();
            }
            else
            {
                distinctFGCount = allFG.Distinct().Count();
            }

            

            //if (_ProductionType == (int)Dictionary.ProductionType.CBU)
            //{
            //    this.Text = "Product Component Serial Universal-(CBU) " + "[Total Component:" + oProductComponents.Count + ",Total Set:" + distinctCount + " ]";
            //}
            //else
            //{
            //    this.Text = "Product Component Serial Universal-(SKD) " + "[Total Component:" + oProductComponents.Count + ",Total Set:" + distinctCount + " ]";
            //}

            if (_ProductionType == (int)Dictionary.ProductionType.CBU)
            {
                this.Text = "Product Component Serial Universal (CBU)" + "[Total Component:" + oProductComponents.Count + ",Total Set:" + distinctCount + " ]";
                btnPrint.Visible = false;
                btnPrintHeader.Visible = false;
            }
            else if (_ProductionType == (int)Dictionary.ProductionType.FG)
            {
                this.Text = "Product Component Serial Universal FG (SKD)" + "[Total Component:" + oProductComponents.Count + ",Total Set:" + distinctCount + ",Total WIP:" + (distinctCount- distinctFGCount) + ",Total FG:" + distinctFGCount + " ]";
                btnPrint.Visible = false;
                btnPrintHeader.Visible = false;
                btnDefective.Visible = true;
            }
            else if (_ProductionType == (int)Dictionary.ProductionType.SKD && _IsIndoorItem == 1)
            {
                this.Text = "Product Component Serial Universal AC Indoor (SKD)" + "[Total Component:" + oProductComponents.Count + ",Total Set:" + distinctCount + " ]";
            }
            else if (_ProductionType == (int)Dictionary.ProductionType.SKD && _IsIndoorItem == 0)
            {
                this.Text = "Product Component Serial Universal (SKD)" + "[Total Component:" + oProductComponents.Count + ",Total Set:" + distinctCount + " ]";
            }


            if (_ProductionType == 3)
            {
                SetListViewRowColour();
            }
        }
        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
            
        }
        private void SetListViewRowColour()
        {
            if (lvwProductComponentUniversals.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwProductComponentUniversals.Items)
                {
                    if (oItem.SubItems[9].Text == "FG Serial" && oItem.SubItems[10].Text == "")
                    {
                        oItem.BackColor = Color.SandyBrown;
                    }
                    else if (oItem.SubItems[9].Text == "FG Serial" && oItem.SubItems[10].Text != "")
                    {
                        oItem.BackColor = Color.White;
                    }
                }
            }
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
                btnPrint.Visible = false;
                btnPrintHeader.Visible = false;
            }
            else if (_ProductionType == (int)Dictionary.ProductionType.FG)
            {
                this.Text = "Product Component Serial Universal FG (SKD)";
                btnPrint.Visible = false;
                btnPrintHeader.Visible = false;
                btnDefective.Visible = true;
            }
            else if(_ProductionType == (int)Dictionary.ProductionType.SKD && _IsIndoorItem==1)
            {
                this.Text = "Product Component Serial Universal AC Indoor (SKD)";
            }
            else if (_ProductionType == (int)Dictionary.ProductionType.SKD && _IsIndoorItem == 0)
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

                oProductComponents.RefreshComponentFactoryPrint(oProductComponent.ProductCode, oProductComponent.SetID, _ProductionType, _IsIndoorItem, oProductComponent.LocationID);
                doc.SetDataSource(oProductComponents);
                doc.SetParameterValue("Product", oProductComponent.ProductName);

                frmPrintPreview oForm = new frmPrintPreview();
                oForm.ShowDialog(doc);
            }
            else
            {
                ProductComponent oProductComponent = (ProductComponent)lvwProductComponentUniversals.SelectedItems[0].Tag;
                ProductDetail oProductDetail = new ProductDetail();
                oProductDetail.RefreshForFactory(oProductComponent.ProductID);
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
                    
                    oProductComponents.RefreshComponentFactoryPrint(oProductComponent.ProductCode, oProductComponent.SetID, _ProductionType, _IsIndoorItem, oProductComponent.LocationID);
                    doc.SetDataSource(oProductComponents);
                    doc.SetParameterValue("Product", oProductComponent.ProductName);

                    frmPrintPreview oForm = new frmPrintPreview();
                    oForm.ShowDialog(doc);
                }
                else if (sType == "AC")
                {
                    rptProductComponentACNew doc = new rptProductComponentACNew();
                    
                    oProductComponents.RefreshComponentFactoryPrint(oProductComponent.ProductCode, oProductComponent.SetID, _ProductionType, _IsIndoorItem, oProductComponent.LocationID);
                    doc.SetDataSource(oProductComponents);
                    doc.SetParameterValue("Product", oProductComponent.ProductName);

                    frmPrintPreview oForm = new frmPrintPreview();
                    oForm.ShowDialog(doc);
                }
                else
                {
                    rptProductComponentNew doc = new rptProductComponentNew();

                    oProductComponents.RefreshComponentFactoryPrint(oProductComponent.ProductCode, oProductComponent.SetID, _ProductionType, _IsIndoorItem, oProductComponent.LocationID);
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

                oProductComponents.RefreshComponentFactoryPrint(oProductComponent.ProductCode, oProductComponent.SetID, _ProductionType, _IsIndoorItem, oProductComponent.LocationID);
                doc.SetDataSource(oProductComponents);
                doc.SetParameterValue("Product", oProductComponent.ProductName);

                frmPrintPreview oForm = new frmPrintPreview();
                oForm.ShowDialog(doc);
            }
            else
            {
                ProductComponent oProductComponent = (ProductComponent)lvwProductComponentUniversals.SelectedItems[0].Tag;
                ProductDetail oProductDetail = new ProductDetail();
                oProductDetail.RefreshForFactory(oProductComponent.ProductID);
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

                    oProductComponents.RefreshComponentFactoryPrint(oProductComponent.ProductCode, oProductComponent.SetID, _ProductionType, _IsIndoorItem, oProductComponent.LocationID);
                    doc.SetDataSource(oProductComponents);
                    doc.SetParameterValue("Product", oProductComponent.ProductName);

                    frmPrintPreview oForm = new frmPrintPreview();
                    oForm.ShowDialog(doc);
                }
                else if (sType == "AC")
                {
                    rptProductComponentACNewHeader doc = new rptProductComponentACNewHeader();

                    oProductComponents.RefreshComponentFactoryPrint(oProductComponent.ProductCode, oProductComponent.SetID, _ProductionType, _IsIndoorItem, oProductComponent.LocationID);
                    doc.SetDataSource(oProductComponents);
                    doc.SetParameterValue("Product", oProductComponent.ProductName);

                    frmPrintPreview oForm = new frmPrintPreview();
                    oForm.ShowDialog(doc);
                }
                else
                {
                    rptProductComponentNewHeader doc = new rptProductComponentNewHeader();

                    oProductComponents.RefreshComponentFactoryPrint(oProductComponent.ProductCode, oProductComponent.SetID, _ProductionType, _IsIndoorItem, oProductComponent.LocationID);
                    doc.SetDataSource(oProductComponents);
                    doc.SetParameterValue("Product", oProductComponent.ProductName);

                    frmPrintPreview oForm = new frmPrintPreview();
                    oForm.ShowDialog(doc);
                }
            }
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            oSerarchProduct = new SerarchProduct();

            txtCode.ForeColor = System.Drawing.Color.Red;
            txtName.Text = "";

            if (txtCode.Text.Length >= 1 && txtCode.Text.Length <= 25)
            {
                oSerarchProduct.ProductCode = txtCode.Text;

                DBController.Instance.OpenNewConnection();
                oSerarchProduct.RefreshByProductCodeFactory();

                if (oSerarchProduct.ProductName == null)
                {
                    oSerarchProduct = null;
                    AppLogger.LogFatal("There is no data.");
                    return;
                }
                else
                {
                    txtName.Text = oSerarchProduct.ProductName.ToString();
                    txtCode.SelectionStart = 0;
                    txtCode.SelectionLength = txtCode.Text.Length;
                    txtCode.ForeColor = System.Drawing.Color.Empty;
                }
            }
            if (ChangeSelection != null)
                ChangeSelection(this, e);
        }

        private void btnPicker_Click(object sender, EventArgs e)
        {
            oSerarchProductOld = new SerarchProduct();
            oSerarchProductOld = oSerarchProduct;

            oSerarchProduct = new SerarchProduct();
            CJ.Factory.frmProductSearch frmProductSearch = new CJ.Factory.frmProductSearch();
            frmProductSearch.ShowDialog(oSerarchProduct);

            if (oSerarchProduct.ProductCode != null)
            {
                string sCode = oSerarchProduct.ProductCode;
                txtCode.Text = "";
                txtCode.Text = sCode.ToString();
            }
            else
            {
                oSerarchProduct = oSerarchProductOld;
            }
        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ChangeFocus != null)
            {
                ChangeFocus(sender, e);
            }
        }

        private void btnDefective_Click(object sender, EventArgs e)
        {
            if (btnDefective.Text == "Repair")
            {
                if (lvwProductComponentUniversals.SelectedItems.Count == 0)
                {
                    frmSKDDefective oForm = new frmSKDDefective((int)Dictionary.LCMStatus.Stage_4);
                    oForm.Show();
                }
                else
                {

                    ProductComponent oProductComponent = (ProductComponent)lvwProductComponentUniversals.SelectedItems[0].Tag;

                    frmSKDDefective oFrom = new frmSKDDefective((int)Dictionary.LCMStatus.Stage_4);
                    oFrom.ShowDialog(oProductComponent);
                    
                }
            }
            else
            {
                frmSKDDefective oForm = new frmSKDDefective((int)Dictionary.LCMStatus.Stage_3);
                if (lvwProductComponentUniversals.SelectedItems.Count == 0)
                {
                    MessageBox.Show("Please select a row to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                ProductComponent oProductComponent = (ProductComponent)lvwProductComponentUniversals.SelectedItems[0].Tag;
                if (oProductComponent.ComponentName == "FG Serial" && oProductComponent.ProductSerial == "")
                {

                    int nID = 0;
                    ProductComponent oComponent = new ProductComponent();
                    nID = oComponent.GetDefectiveSetID(oProductComponent.SetID);
                    if (nID != 0)
                    {
                        //MessageBox.Show("Already Defective Declared", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        
                        DialogResult dialogResult = MessageBox.Show("Already Defective Declared, Do You want to EDIT?", "Defective", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            //do something
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            return;
                        }
                    }

                    

                    oForm.ShowDialog(oProductComponent);
                }
                else
                {
                    MessageBox.Show("Please select Empty FG Serial", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            DataLoadControl();
        }

        //private void lvwProductComponentUniversals_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    ProductComponent oProductComponent = (ProductComponent)lvwProductComponentUniversals.SelectedItems[0].Tag;
        //    if (oProductComponent.ComponentName == "FG Serial" && oProductComponent.ProductSerial == "")
        //    {
        //        btnDefective.Enabled = true;
        //    }
        //    else
        //    {
        //        btnDefective.Enabled = false;
        //    }
        //}
    }
}

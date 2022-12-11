using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;


namespace CJ.Win.BEIL
{
    public partial class frmLCMStage1 : Form
    {
        LCMComponent oLCMComponent;
        LCMComponentItem oLCMComponentItem;
        ProductGroups _AG;
        Brands _oBrands;
        SerarchProduct oSerarchProduct;
        public event System.EventHandler ChangeSelection;
        public event KeyPressEventHandler ChangeFocus;
        SerarchProduct oSerarchProductOld;
        public frmLCMStage1()
        {
            InitializeComponent();
            LoadCombos();
        }

        public void ShowDialog(LCMComponent oLCMComponent)
        {
            cmbAG.SelectedIndex = _AG.GetIndex(oLCMComponent.AGID)+1;
            txtChassisSerial.Text = oLCMComponent.ChassisSerial;
            LCMComponentItems oLCMComponentItems = new LCMComponentItems();
            
            DBController.Instance.OpenNewConnection();
            oLCMComponentItems.Refresh(oLCMComponent.ID);
            DBController.Instance.CloseConnection();
            foreach (LCMComponentItem oItem in oLCMComponentItems)
            {
                if (oItem.ComponentID == (int)Dictionary.LCMComponent.LED_Bar)
                {
                    txtLEDBarSerial.Text = oItem.SerialNo;
                }
            }

            this.Tag = oLCMComponent;

            this.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                if (this.Tag == null)
                {
                    Save();
                    txtManualSerial.Text = "";
                    txtChassisSerial.Text = "";
                    txtLEDBarSerial.Text = "";
                    txtRemarks.Text = "";
                    txtLEDBarSerial2.Text = "";
                    txtLEDBarSerial3.Text = "";
                    txtChassisSerial.Focus();
                }
                else
                {
                    Update();
                    this.Close();
                }
                //cmbAG.SelectedIndex = 0;
            }
            
        }

        private void Save()
        {
            oLCMComponent = new LCMComponent();
            oLCMComponent.ManualSerial = txtManualSerial.Text;
            oLCMComponent.ChassisSerial = txtChassisSerial.Text;
            oLCMComponent.CreateDate = DateTime.Now;
            oLCMComponent.CreateUserID = Utility.UserId;
            oLCMComponent.Remarks = txtRemarks.Text;
            oLCMComponent.Status = (int)Dictionary.LCMStatus.Stage_1;
            oLCMComponent.AGID = _AG[cmbAG.SelectedIndex - 1].PdtGroupID;
            oLCMComponent.BrandID = _oBrands[cmbBrand.SelectedIndex].BrandID;

            if (txtName.Text.Trim() != "")
            {
                oLCMComponent.ProductID = oSerarchProduct.ProductID;
            }
            else
            {                
                oLCMComponent.ProductID = 0;
            }

            try
            {
                DBController.Instance.BeginNewTransaction();
                oLCMComponent.Add();
                InsertLCMComponentItem(oLCMComponent.ID, oLCMComponent.BrandID);

                DBController.Instance.CommitTransaction();
                MessageBox.Show("Successfully Add Component Serial", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }

        private void Update()
        {
            LCMComponent oLCMComponent = (LCMComponent)this.Tag;
            oLCMComponent.ManualSerial = txtManualSerial.Text;
            oLCMComponent.ChassisSerial = txtChassisSerial.Text;
            oLCMComponent.UpdateDate = DateTime.Now;
            oLCMComponent.UpdateUserID = Utility.UserId;
            oLCMComponent.Remarks = txtRemarks.Text;
            oLCMComponent.Status = (int)Dictionary.LCMStatus.Stage_1;
            oLCMComponent.AGID = _AG[cmbAG.SelectedIndex - 1].PdtGroupID;
            oLCMComponent.BrandID = _oBrands[cmbBrand.SelectedIndex].BrandID;

            if (txtName.Text.Trim() != "")
            {
                oLCMComponent.ProductID = oSerarchProduct.ProductID;
            }
            else
            {
                oLCMComponent.ProductID = 0;
            }

            try
            {
                DBController.Instance.BeginNewTransaction();
                oLCMComponent.Edit();
                oLCMComponentItem = new LCMComponentItem();
                oLCMComponentItem.ID = oLCMComponent.ID;
                oLCMComponentItem.Delete();

                InsertLCMComponentItem(oLCMComponent.ID, oLCMComponent.BrandID);

                DBController.Instance.CommitTransaction();
                MessageBox.Show("Successfully Add Component Serial", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }

        private void InsertLCMComponentItem(int nID, int nBrandID)
        {

            string stxtChassisSerial = txtChassisSerial.Text;
            string sLEDBarSerial = txtLEDBarSerial.Text;
            oLCMComponentItem = new LCMComponentItem();
            if (nBrandID == 38)
            {
                for (int i = 1; i <= 4; i++)
                {
                    oLCMComponentItem.ID = nID;
                    if (i == 1)
                    {
                        oLCMComponentItem.ComponentID = (int)Dictionary.LCMComponent.Chassis;
                        oLCMComponentItem.SerialNo = txtChassisSerial.Text;
                        oLCMComponentItem.CreateDate = DateTime.Now;
                        oLCMComponentItem.CreateUserID = Utility.UserId;
                        oLCMComponentItem.Status = 1;
                        oLCMComponentItem.Add();
                    }
                    else if (i == 2)
                    {
                        oLCMComponentItem.ComponentID = (int)Dictionary.LCMComponent.LED_Bar;
                        oLCMComponentItem.SerialNo = txtLEDBarSerial.Text;
                        oLCMComponentItem.CreateDate = DateTime.Now;
                        oLCMComponentItem.CreateUserID = Utility.UserId;
                        oLCMComponentItem.Status = 1;
                        oLCMComponentItem.Add();
                    }
                    else if (i == 3)
                    {
                        if (txtLEDBarSerial2.Text != "")
                        {
                            oLCMComponentItem.ComponentID = (int)Dictionary.LCMComponent.LED_Bar;
                            oLCMComponentItem.SerialNo = txtLEDBarSerial2.Text;
                            oLCMComponentItem.CreateDate = DateTime.Now;
                            oLCMComponentItem.CreateUserID = Utility.UserId;
                            oLCMComponentItem.Status = 1;
                            oLCMComponentItem.Add();
                        }
                    }
                    else if (i == 4)
                    {
                        if (txtLEDBarSerial3.Text != "")
                        {
                            oLCMComponentItem.ComponentID = (int)Dictionary.LCMComponent.LED_Bar;
                            oLCMComponentItem.SerialNo = txtLEDBarSerial3.Text;
                            oLCMComponentItem.CreateDate = DateTime.Now;
                            oLCMComponentItem.CreateUserID = Utility.UserId;
                            oLCMComponentItem.Status = 1;
                            oLCMComponentItem.Add();
                        }
                    }
                }
            }
            else
            {
                for (int i = 1; i <= 3; i++)
                {
                    oLCMComponentItem.ID = nID;
                    if (i == 1)
                    {
                        oLCMComponentItem.ComponentID = (int)Dictionary.LCMComponent.Chassis;
                        oLCMComponentItem.SerialNo = txtChassisSerial.Text;
                        oLCMComponentItem.CreateDate = DateTime.Now;
                        oLCMComponentItem.CreateUserID = Utility.UserId;
                        oLCMComponentItem.Status = 1;
                        oLCMComponentItem.Add();
                    }
                    else if (i == 2)
                    {
                        oLCMComponentItem.ComponentID = (int)Dictionary.LCMComponent.Opencell;
                        oLCMComponentItem.SerialNo = txtLEDBarSerial.Text;
                        oLCMComponentItem.CreateDate = DateTime.Now;
                        oLCMComponentItem.CreateUserID = Utility.UserId;
                        oLCMComponentItem.Status = 1;
                        oLCMComponentItem.Add();
                    }
                    else if (i == 3)
                    {
                        if (txtLEDBarSerial2.Text != "")
                        {
                            oLCMComponentItem.ComponentID = (int)Dictionary.LCMComponent.TCon;
                            oLCMComponentItem.SerialNo = txtLEDBarSerial2.Text;
                            oLCMComponentItem.CreateDate = DateTime.Now;
                            oLCMComponentItem.CreateUserID = Utility.UserId;
                            oLCMComponentItem.Status = 1;
                            oLCMComponentItem.Add();
                        }
                    }
                  
                }
            }
        }
        private bool validateUIInput()
        {
            
            if (txtChassisSerial.Text == "")
            {
                MessageBox.Show("Please enter chassis serial", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtChassisSerial.Focus();
                return false;
            }
            if (txtLEDBarSerial.Text == "")
            {
                MessageBox.Show("Please enter led bar serial", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLEDBarSerial.Focus();
                return false;
            }

            if (txtName.Text.Trim() == "")
            {
                if (cmbAG.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select an AGName", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbAG.Focus();
                    return false;
                }
                
            }


            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadCombos()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            //Load AG in combo
            _AG = new ProductGroups();
            _AG.GetHTVAG();
            cmbAG.Items.Clear();
            cmbAG.Items.Add("<Select AG>");
            foreach (ProductGroup oProductGroup in _AG)
            {
                cmbAG.Items.Add(oProductGroup.PdtGroupName);
            }
            cmbAG.SelectedIndex = 0;


            //Load Brand in combo
            _oBrands = new Brands();
            _oBrands.RefreshForLCM();

            //Removing the [ALL] in the Brand Object ??!!
            //_oBrands.RemoveAt(_oBrands.Count - 1);
            //
            cmbBrand.Items.Clear();
            //cmbBrand.Items.Add("<All>");
            foreach (Brand oBrand in _oBrands)
            {
               cmbBrand.Items.Add(oBrand.BrandDesc);
            }
            cmbBrand.SelectedIndex = 0;
        }

        private void frmLCMStage1_Load(object sender, EventArgs e)
        {
            this.Text = "Stage-1";
        }

        private void txtChassisSerial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtLEDBarSerial.Focus();
            }
        }

        private void txtLEDBarSerial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtLEDBarSerial2.Focus();
            }
        }

        private void txtRemarks_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
            }
        }

        private void txtManualSerial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtChassisSerial.Focus();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLEDBarSerial2_KeyDown(object sender, KeyEventArgs e)
        {
            if (cmbBrand.SelectedIndex == 0)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    txtLEDBarSerial3.Focus();
                }
            }
            else
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnSave.Focus();
                }
            }
        }

        private void txtLEDBarSerial3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
            }
        }

        private void cmbBrand_SelectedIndexChanged(object sender, EventArgs e)
        {
           if(_oBrands[cmbBrand.SelectedIndex].BrandDesc=="Transtec")
            {
                lblOpenCell.Text = "Open Cell";
                lblOpenCell.AutoSize = false;
                lblOpenCell.TextAlign = ContentAlignment.MiddleRight;
                lblTCon.Text = "TCon";
                lblTCon.AutoSize = false;
                lblTCon.TextAlign = ContentAlignment.MiddleRight;
                lblLED03.Visible = false;
                txtLEDBarSerial3.Visible = false;
            }
           else
            {
                lblOpenCell.Text = "LED Bar SL 01";
                lblTCon.Text = "LED Bar SL 02";
                lblLED03.Visible = true;
                lblLED03.Text = "LED Bar SL 03";
                txtLEDBarSerial3.Visible = true;
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
                oSerarchProduct.RefreshByProductCode();

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

                    if (oSerarchProduct.BrandID == 19)
                    {
                        cmbBrand.SelectedIndex = 0;
                    }
                    else if (oSerarchProduct.BrandID == 4)
                    {
                        cmbBrand.SelectedIndex = 1;
                    }

                    cmbAG.SelectedIndex = _AG.GetIndex(oSerarchProduct.AGID)+1;

                    cmbBrand.Enabled = false;
                    cmbAG.Enabled = false;
                }
            }
            else
            {
                cmbBrand.Enabled = true;
                cmbBrand.SelectedIndex = 0;
                cmbAG.Enabled = true;
                cmbAG.SelectedIndex = 0;
            }
            if (ChangeSelection != null)
                ChangeSelection(this, e);

        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ChangeFocus != null)
            {
                ChangeFocus(sender, e);
            }
        }

        private void btnPicker_Click(object sender, EventArgs e)
        {
            oSerarchProductOld = new SerarchProduct();
            oSerarchProductOld = oSerarchProduct;

            oSerarchProduct = new SerarchProduct();
            CJ.Control.frmProductSearch frmProductSearch = new CJ.Control.frmProductSearch();
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
    }
}
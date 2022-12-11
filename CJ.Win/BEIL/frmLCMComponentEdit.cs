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
    public partial class frmLCMComponentEdit : Form
    {
        LCMComponent oLCMComponent;
        
        int nID = 0;
        ProductGroups _AG;
        Brands _oBrands;
        public frmLCMComponentEdit()
        {
            InitializeComponent();
            LoadCombos();
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
        public void ShowDialog(LCMComponent oLCMComponent)
        {
            cmbAG.SelectedIndex = _AG.GetIndex(oLCMComponent.AGID) + 1;
            if (oLCMComponent.BrandID == 38)
            {
                cmbBrand.SelectedIndex = 0;
            }
            else if (oLCMComponent.BrandID == 23)
            {
                cmbBrand.SelectedIndex = 1;
            }
            txtChassisSerial.Text = oLCMComponent.ChassisSerial;
            if (oLCMComponent.ProductID != 0)
            {
                Product oProduct = new Product();
                oProduct.ProductID = oLCMComponent.ProductID;
                oProduct.RefreshByID();
                ctlProduct1.txtCode.Text = oProduct.ProductCode;
            }
            //LCMComponentItems oLCMComponentItems = new LCMComponentItems();

            //DBController.Instance.OpenNewConnection();
            //oLCMComponentItems.Refresh(oLCMComponent.ID);
            //DBController.Instance.CloseConnection();
            ////foreach (LCMComponentItem oItem in oLCMComponentItems)
            ////{
            ////    if (oItem.ComponentID == (int)Dictionary.LCMComponent.LED_Bar)
            ////    {
            ////        txtLEDBarSerial.Text = oItem.SerialNo;
            ////    }
            ////}

            this.Tag = oLCMComponent;

            this.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                //txtManualSerial.Text = "";
                //txtChassisSerial.Text = "";
                //txtLEDBarSerial.Text = "";
                //txtRemarks.Text = "";
                //txtLEDBarSerial2.Text = "";
                //txtLEDBarSerial3.Text = "";
                //txtChassisSerial.Focus();

                //cmbAG.SelectedIndex = 0;
                this.Close();
            }
        }

        private void Save()
        {
            LCMComponent oLCMComponent = (LCMComponent)this.Tag;
            
            oLCMComponent.ChassisSerial = dgvLCMComponent.Rows[0].Cells[2].Value.ToString();
            oLCMComponent.UpdateDate = DateTime.Now;
            oLCMComponent.UpdateUserID = Utility.UserId;
            //oLCMComponent.Status = (int)Dictionary.LCMStatus.Stage_2;
            oLCMComponent.AGID = _AG[cmbAG.SelectedIndex - 1].PdtGroupID;
            oLCMComponent.BrandID = _oBrands[cmbBrand.SelectedIndex].BrandID;
            try
            {
                oLCMComponent.ProductID = ctlProduct1.SelectedSerarchProduct.ProductID;
            }
            catch
            {
                oLCMComponent.ProductID = 0;
            }
            try
            {
                DBController.Instance.BeginNewTransaction();
                oLCMComponent.Edit();
                //oLCMComponent = new LCMComponent();
                //oLCMComponent.ManualSerial = txtManualSerial.Text;
                //oLCMComponent.ChassisSerial = txtChassisSerial.Text;
                //oLCMComponent.CreateDate = DateTime.Now;
                //oLCMComponent.CreateUserID = Utility.UserId;
                //oLCMComponent.Remarks = txtRemarks.Text;
                //oLCMComponent.Status = (int)Dictionary.LCMStatus.Stage_1;
                //oLCMComponent.AGID = _AG[cmbAG.SelectedIndex - 1].PdtGroupID;

                //try
                //{
                //    DBController.Instance.BeginNewTransaction();
                //    oLCMComponent.Add();

                //    string stxtChassisSerial = txtChassisSerial.Text;
                //    string sLEDBarSerial = txtLEDBarSerial.Text;
                //    oLCMComponentItem = new LCMComponentItem();
                LCMComponentItem oLCMComponentItem =new LCMComponentItem();
                oLCMComponentItem.ID = oLCMComponent.ID;
                oLCMComponentItem.Delete();
                for (int i = 0; i < dgvLCMComponent.Rows.Count; i++)
                {
                    //if (i == 1)
                    //{
                    oLCMComponentItem.ComponentID = Convert.ToInt32(dgvLCMComponent.Rows[i].Cells[3].Value);
                    oLCMComponentItem.SerialNo = dgvLCMComponent.Rows[i].Cells[2].Value.ToString();
                    oLCMComponentItem.CreateDate = DateTime.Now;
                    oLCMComponentItem.CreateUserID = Utility.UserId;
                    oLCMComponentItem.Status = 1;
                    oLCMComponentItem.Add();
                    //}
                    //else if (i == 2)
                    //{
                    //    oLCMComponentItem.ComponentID = (int)Dictionary.LCMComponent.LED_Bar;
                    //    oLCMComponentItem.SerialNo = dgvLCMComponent.Rows[i].Cells[2].Value.ToString(); 
                    //    oLCMComponentItem.CreateDate = DateTime.Now;
                    //    oLCMComponentItem.CreateUserID = Utility.UserId;
                    //    oLCMComponentItem.Status = 1;
                    //    oLCMComponentItem.Add();
                    //}
                    //else if (i == 3)
                    //{
                    //    if (txtLEDBarSerial2.Text != "")
                    //    {
                    //        oLCMComponentItem.ComponentID = (int)Dictionary.LCMComponent.LED_Bar;
                    //        oLCMComponentItem.SerialNo = txtLEDBarSerial2.Text;
                    //        oLCMComponentItem.CreateDate = DateTime.Now;
                    //        oLCMComponentItem.CreateUserID = Utility.UserId;
                    //        oLCMComponentItem.Status = 1;
                    //        oLCMComponentItem.Add();
                    //    }
                    //}
                    //else if (i == 4)
                    //{
                    //    if (txtLEDBarSerial3.Text != "")
                    //    {
                    //        oLCMComponentItem.ComponentID = (int)Dictionary.LCMComponent.LED_Bar;
                    //        oLCMComponentItem.SerialNo = txtLEDBarSerial3.Text;
                    //        oLCMComponentItem.CreateDate = DateTime.Now;
                    //        oLCMComponentItem.CreateUserID = Utility.UserId;
                    //        oLCMComponentItem.Status = 1;
                    //        oLCMComponentItem.Add();
                    //    }
                    //}



                    //    }
                }

                DBController.Instance.CommitTransaction();
                MessageBox.Show("Successfully Add Component Serial", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
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
         
            if (cmbAG.SelectedIndex == 0)
            {
                MessageBox.Show("Please select an agname", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbAG.Focus();
                return false;
            }


            return true;
        }

        //private void LoadCombos()
        //{
        //    //DBController.Instance.OpenNewConnection();
        //    ////Load AG in combo
        //    //_AG = new ProductGroups();
        //    //_AG.GetHTVAG();
        //    //cmbAG.Items.Clear();
        //    //cmbAG.Items.Add("<Select AG>");
        //    //foreach (ProductGroup oProductGroup in _AG)
        //    //{
        //    //    cmbAG.Items.Add(oProductGroup.PdtGroupName);
        //    //}
        //    //cmbAG.SelectedIndex = 0;
        //}

       

        private void txtChassisSerial_TextChanged(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            oLCMComponent = new LCMComponent();
            //nID = oLCMComponent.Refresh(txtChassisSerial.Text.Trim(), (int)Dictionary.LCMStatus.Stage_2, 1);
            nID = oLCMComponent.Refresh(txtChassisSerial.Text.Trim(), 1);

            if (nID == 0)
            {

            }
            else
            {
                oLCMComponent.GetComponent(txtChassisSerial.Text.Trim());
                dgvLCMComponent.Rows.Clear();
                foreach (LCMComponentItem oLCMComponentItem in oLCMComponent)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvLCMComponent);
                    oRow.Cells[0].Value = oLCMComponentItem.ComponentName.ToString();
                    oRow.Cells[1].Value = Convert.ToDateTime(oLCMComponentItem.CreateDate).ToString();
                    oRow.Cells[2].Value = oLCMComponentItem.SerialNo.ToString();
                    oRow.Cells[3].Value = oLCMComponentItem.ComponentID.ToString();
                    dgvLCMComponent.Rows.Add(oRow);
                }
                txtChassisSerial.Enabled = false;
                //txtOpenCell.Focus();
            }
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
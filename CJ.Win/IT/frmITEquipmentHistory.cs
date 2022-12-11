// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: June 08,2011
// Time : 12.00 PM
// Description: form for IT Equipment History Managenet
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

using CJ.Class;
using CJ.Report;
using CJ.Class.Report;
using CJ.Class.IT;


namespace CJ.Win.IT
{
    public partial class frmITEquipmentHistory : Form
    {
        public ITAsset oITAsset=null;
        Suppliers _oSuppliers;
        ITEquipmentTran _oITEquipmentTran;      
        Companys oCompanys;       
        Departments oDepartments;       
        int _nAssetID;

        public frmITEquipmentHistory()
        {
            InitializeComponent();
        }

        private void frmEquipmentHistoryList_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
                LoadCombos();
        }
        public void ShowDialog(ITAsset oITAsset)
        {
            this.Tag = oITAsset;
            txtAssetNo.Text = oITAsset.AssetNo;
            LoadCombos();
            ReloadData();
            this.ShowDialog();
        }
        private void LoadCombos()
        {           
           //Department
            oDepartments = new Departments();
            oDepartments.Refresh();
            cbDepartment.Items.Clear();
            foreach (Department oDepartment in oDepartments)
            {
                cbDepartment.Items.Add(oDepartment.DepartmentName);
            }
           
            //Company
            oCompanys = new Companys();
            oCompanys.Refresh();
            cbCompany.Items.Clear();
            foreach (Company oCompany in oCompanys)
            {
                cbCompany.Items.Add(oCompany.CompanyName);
            }               
           //IT Equipment Stock Name.
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ITEquipmentStock)))
            {
                cbStoreName.Items.Add(Enum.GetName(typeof(Dictionary.ITEquipmentStock), GetEnum));
            }
            cbStoreName.SelectedIndex = 1;
         

            //IT Equipment Tran Type.
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ITEquipmentTranType)))
            {
                cbTranType.Items.Add(Enum.GetName(typeof(Dictionary.ITEquipmentTranType), GetEnum));
            }
            cbTranType.SelectedIndex = 1;
          
        }
        public void RefreshData()
        {
            ITEquipmentTranList oIITEquipmentTranList = new ITEquipmentTranList();
            lvwITEquipmentHistoryList.Items.Clear();

            if (Utility.CompanyInfo == "BLL")
            {
                oIITEquipmentTranList.Refreshfor_BLLTAB(_nAssetID);
            }
            else
            {
                oIITEquipmentTranList.Refresh(_nAssetID);
            }
         
            foreach (ITEquipmentTran oITEquipmentTran in oIITEquipmentTranList)
            {
                ListViewItem oItem = lvwITEquipmentHistoryList.Items.Add(oITEquipmentTran.TranDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.ITEquipmentTranType), oITEquipmentTran.TranType));
                if (oITEquipmentTran.EmployeeID > -1)
                    oItem.SubItems.Add(oITEquipmentTran.Employee.EmployeeName);
                else oItem.SubItems.Add("NA");
                if (oITEquipmentTran.FromStoreID == -1)
                    oItem.SubItems.Add("System Stock");
                else oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.ITEquipmentStock), oITEquipmentTran.FromStoreID));

                if (oITEquipmentTran.ToStoreID == -1)
                    oItem.SubItems.Add("System Stock");
                else oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.ITEquipmentStock), oITEquipmentTran.ToStoreID));
                oItem.SubItems.Add(oITEquipmentTran.Company.CompanyName);                   
                oItem.SubItems.Add(oITEquipmentTran.Remarks);                     

                oItem.Tag = oITEquipmentTran;
            }
        }
        public void ReloadData()
        {
            oITAsset = new ITAsset();            
            oITAsset.RefreshByAssetNo(txtAssetNo.Text);          
            ShowData(oITAsset);
           
        }
        private void txtAssetNo_TextChanged(object sender, EventArgs e)
        {
           
        }
        private void txtAssetNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {                
                ReloadData();              
            }
        }   
        private void btSearch_Click(object sender, EventArgs e)
        {         
            frmITEquipments oForm = new frmITEquipments();
            oForm._bIsSearch = true;
            oForm.ShowDialog();
            if (oForm._sAsset != "")
            {
                txtAssetNo.Text = oForm._sAsset;
                ReloadData();                
            }
           
        }
        public void ShowData(ITAsset oITAsset)
        {
            _oSuppliers = new Suppliers();
            _oSuppliers.GetSupplierName((int)Dictionary.SupplierType.IT);
            foreach (Supplier oSupplier in _oSuppliers)
            {
                cbSupplier.Items.Add(oSupplier.SupplierName);
            }
            if (_oSuppliers.Count > 0)
            cbSupplier.SelectedIndex = 0;

            cbCurCompany.Items.Clear();
            foreach (Company oCompany in oCompanys)
            {
                cbCurCompany.Items.Add(oCompany.CompanyName);
            }
            cbCurCompany.SelectedIndex = 0;

            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ITEquipmentStock)))
            {
                cbCurStoreName.Items.Add(Enum.GetName(typeof(Dictionary.ITEquipmentStock), GetEnum));
            }
            cbCurStoreName.SelectedIndex = 0;

            _nAssetID = oITAsset.ITAssetID;
            cbSupplier.SelectedIndex = _oSuppliers.GetIndexByID(oITAsset.SupplierID);
            cbCurCompany.SelectedIndex = oCompanys.GetIndex(oITAsset.CompanyID);

            if (oITAsset.StoreID != -1)
            {
                cbCurStoreName.Visible = true;
                cbCurStoreName.SelectedIndex = oITAsset.StoreID;
            }
            else cbCurStoreName.Visible = false;

            txtAssetNo.Text = oITAsset.AssetNo;
            txtSerial.Text = oITAsset.SerialNo;
            txtBrand.Text = oITAsset.ITEquipment.Brand;
            txtModelNo.Text = oITAsset.ITEquipment.ModelNo;
            txtProductNo.Text = oITAsset.ITEquipment.ProductNo;

            if (oITAsset.PurchaseDate!=null)
            dtPurchaseDate.Value = Convert.ToDateTime(oITAsset.PurchaseDate.ToString());
            txtAssetRemarks.Text = oITAsset.ITEquipment.Remarks;

            RefreshData();
        }
        private void ctlNewEmployee_ChangeSelection(object sender, EventArgs e)
        {
            DBController.Instance.OpenNewConnection();
            Employee oEmployee = ctlNewEmployee.SelectedEmployee;
            oEmployee.ReadDB = true;
            cbCompany.Text = oEmployee.Company.CompanyName;
            cbDepartment.Text = oEmployee.Department.DepartmentName;
          
        }
        private void btnAdd_Click_1(object sender, EventArgs e)
        {     
            if (ValidInput())
            {
                if(Utility.CompanyInfo=="BLL")
                {
                    Save_ForBLL_TAB();
                }
                else
                {
                    Save();
                }
                
            }
        }

        public void Save()
        {
            _oITEquipmentTran = new ITEquipmentTran();

            Company oCompany = oCompanys[cbCompany.SelectedIndex];


            _oITEquipmentTran.TranType = cbTranType.SelectedIndex;
            _oITEquipmentTran.TranDate = dtpTranDate.Value.Date;
            _oITEquipmentTran.TypeID = oITAsset.ITEquipment.TypeID;
            _oITEquipmentTran.EquipmentID = oITAsset.EquipmentID;
            _oITEquipmentTran.ITAssetID = oITAsset.ITAssetID;

            if (ctlNewEmployee.SelectedEmployee != null || ctlNewEmployee.txtCode.Text !="")
                _oITEquipmentTran.EmployeeID = ctlNewEmployee.SelectedEmployee.EmployeeID;
            else _oITEquipmentTran.EmployeeID = -1;

            if (cbDepartment.Text != "")
            {
                Department oDepartment = oDepartments[cbDepartment.SelectedIndex];
                _oITEquipmentTran.DepartmentID = oDepartment.DepartmentID;
            }
            else _oITEquipmentTran.DepartmentID = -1;

            _oITEquipmentTran.CompanyID = oCompany.CompanyID;
            _oITEquipmentTran.FromStoreID = oITAsset.StoreID;
            _oITEquipmentTran.ToStoreID = cbStoreName.SelectedIndex;
            _oITEquipmentTran.Remarks = txtTranRemarks.Text;

            if (cbTranType.SelectedIndex == 3)
            {                
                _oITEquipmentTran.ToStoreID = -1;
            }          
            if (cbTranType.SelectedIndex == 7)
            {                
                _oITEquipmentTran.ToStoreID = -1;
            }
            try
            {
                DBController.Instance.BeginNewTransaction();
                _oITEquipmentTran.Insert();
                DBController.Instance.CommitTransaction();
                MessageBox.Show("You Have Successfully Save The Transaction", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DBController.Instance.OpenNewConnection();
                ReloadData();
                Clear();
                RefreshData();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
            
        }

        public void Save_ForBLL_TAB()
        {
            _oITEquipmentTran = new ITEquipmentTran();

            Company oCompany = oCompanys[cbCompany.SelectedIndex];


            _oITEquipmentTran.TranType = cbTranType.SelectedIndex;
            _oITEquipmentTran.TranDate = dtpTranDate.Value.Date;
            _oITEquipmentTran.TypeID = oITAsset.ITEquipment.TypeID;
            _oITEquipmentTran.EquipmentID = oITAsset.EquipmentID;
            _oITEquipmentTran.ITAssetID = oITAsset.ITAssetID;

            if (ctlNewEmployee.SelectedEmployee != null || ctlNewEmployee.txtCode.Text != "")
                _oITEquipmentTran.EmployeeID = Convert.ToInt32( ctlNewEmployee.txtCode.Text);
            else _oITEquipmentTran.EmployeeID = -1;

            if (cbDepartment.Text != "")
            {
                Department oDepartment = oDepartments[cbDepartment.SelectedIndex];
                _oITEquipmentTran.DepartmentID = oDepartment.DepartmentID;
            }
            else _oITEquipmentTran.DepartmentID = -1;

            _oITEquipmentTran.CompanyID = oCompany.CompanyID;
            _oITEquipmentTran.FromStoreID = oITAsset.StoreID;
            _oITEquipmentTran.ToStoreID = cbStoreName.SelectedIndex;
            _oITEquipmentTran.Remarks = txtTranRemarks.Text;

            if (cbTranType.SelectedIndex == 3)
            {
                _oITEquipmentTran.ToStoreID = -1;
            }
            if (cbTranType.SelectedIndex == 7)
            {
                _oITEquipmentTran.ToStoreID = -1;
            }
            try
            {
                DBController.Instance.BeginNewTransaction();
                _oITEquipmentTran.Insert();
                DBController.Instance.CommitTransaction();
                MessageBox.Show("You Have Successfully Save The Transaction", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DBController.Instance.OpenNewConnection();
                ReloadData();
                Clear();
                RefreshData();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }

        }
        public bool ValidInput()
        {
            
            if (oITAsset == null)
            {
                MessageBox.Show("Please Select a Equipment", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtModelNo.Focus();
                return false;
            }
            if (cbTranType.Text == "" || cbTranType.Text == "Purchase")
            {
                MessageBox.Show("Please Select a Valid Transaction Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbTranType.Focus();
                return false;
            }

            #region Input Information Validation

            ITAsset oITAss = new ITAsset();
            oITAss.RefreshByAssetNo(txtAssetNo.Text);
            if (cbTranType.SelectedIndex == (int)Dictionary.ITEquipmentTranType.Assign_To_User && oITAss.StoreID!=(int)Dictionary.ITEquipmentStock.MIS)

            {
                MessageBox.Show("First you have to return MIS", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbTranType.Focus();
                return false;
            }
            if (cbTranType.SelectedIndex == (int)Dictionary.ITEquipmentTranType.Defect && oITAss.StoreID!=(int)Dictionary.ITEquipmentStock.MIS)

            {
                MessageBox.Show("First you have to return MIS", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbTranType.Focus();
                return false;
            }
            if (cbTranType.SelectedIndex == (int)Dictionary.ITEquipmentTranType.Return_Supplier && oITAss.StoreID!=(int)Dictionary.ITEquipmentStock.MIS)

            {
                MessageBox.Show("First you have to return MIS", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbTranType.Focus();
                return false;
            }
            if (cbTranType.SelectedIndex == (int)Dictionary.ITEquipmentTranType.Repair && oITAss.StoreID != (int)Dictionary.ITEquipmentStock.MIS)

            {
                MessageBox.Show("First you have to return MIS", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbTranType.Focus();
                return false;
            }
            if (cbTranType.SelectedIndex == (int)Dictionary.ITEquipmentTranType.Purchase && oITAss.StoreID!=(int)Dictionary.ITEquipmentSystemStock.System)

            {
                MessageBox.Show("Only System Stock can be Purchased", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbTranType.Focus();
                return false;
            }

            if (cbTranType.SelectedIndex == (int)Dictionary.ITEquipmentTranType.Get_back_Supplier && oITAss.StoreID != (int)Dictionary.ITEquipmentStock.Repair)

            {
                MessageBox.Show("Only Repair stock can be Get back to MIS", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbTranType.Focus();
                return false;
            }
            if (cbTranType.SelectedIndex == (int)Dictionary.ITEquipmentTranType.Return_MIS && oITAss.StoreID == (int)Dictionary.ITEquipmentStock.MIS)

            {
                MessageBox.Show("Only Outside stock can be return to MIS", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbTranType.Focus();
                return false;
            }
            if (cbTranType.SelectedIndex == (int)Dictionary.ITEquipmentTranType.Discard && oITAss.StoreID != (int)Dictionary.ITEquipmentStock.MIS)

            {
                MessageBox.Show("Only Outside stock can be return to MIS", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbTranType.Focus();
                return false;
            }

            #endregion
            if (cbStoreName.Text == "" )
            {
                MessageBox.Show("Please Select a Store Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbStoreName.Focus();
                return false;
            }
            

            if (cbTranType.SelectedIndex == (int)Dictionary.ITEquipmentTranType.Assign_To_User)
            {

                if (radioButton1.Checked == true)
                {
                    if (ctlNewEmployee.SelectedEmployee == null)
                    {
                        MessageBox.Show("Please Select a Employee", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ctlNewEmployee.Focus();
                        return false;
                    }
                    if (cbDepartment.Text == "")
                    {
                        MessageBox.Show("Please Select a Department", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cbDepartment.Focus();
                        return false;
                    }
                    if (cbCompany.Text == "")
                    {
                        MessageBox.Show("Please Select a Comapny", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cbCompany.Focus();
                        return false;
                    }
                }
                if (radioButton2.Checked == true)
                {

                    if (cbDepartment.Text == "")
                    {
                        MessageBox.Show("Please Select a Department", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cbDepartment.Focus();
                        return false;
                    }
                    if (cbCompany.Text == "")
                    {
                        MessageBox.Show("Please Select a Comapny", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cbCompany.Focus();
                        return false;
                    }
                }
                if (radioButton3.Checked == true)
                {
                    if (cbCompany.Text == "")
                    {
                        MessageBox.Show("Please Select a Comapny", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cbCompany.Focus();
                        return false;
                    }
                }

                if (cbCompany.Text == "")
                {
                    MessageBox.Show("Please Select a Comapny", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbCompany.Focus();
                    return false;
                }
            }
            else
            { 
            }

                bool _bFlag = false;

                ITEquipmentValidTrans oITEquipmentValidTrans = new ITEquipmentValidTrans();
                oITEquipmentValidTrans.add();
                foreach (ITEquipmentValidTran oITEquipmentValidTran in oITEquipmentValidTrans)
                {
                    if (cbTranType.SelectedIndex == 3 || cbTranType.SelectedIndex == 7 || cbTranType.SelectedIndex == 8)
                    {
                        if (oITEquipmentValidTran._nTranType == cbTranType.SelectedIndex && oITEquipmentValidTran._nToStock == -1 && oITEquipmentValidTran._nFromStock == oITAsset.StoreID)
                        {
                            _bFlag = true;
                            break;
                        }
                    }
                    else
                    {
                        if (oITEquipmentValidTran._nTranType == cbTranType.SelectedIndex && oITEquipmentValidTran._nToStock == cbStoreName.SelectedIndex && oITEquipmentValidTran._nFromStock == oITAsset.StoreID)
                        {
                            _bFlag = true;
                            break;
                        }
                    }
                    
                }

                if (_bFlag == false)
                {
                    MessageBox.Show("Please Select a Valid Transaction.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return false;
                }
            
            return true;
        }

        //private void lvwITEquipmentHistoryList_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Delete)
        //    {
        //        if (lvwITEquipmentHistoryList.SelectedItems.Count == 0)
        //        {
        //            MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }
        //        if (oITAsset == null)
        //        {
        //            MessageBox.Show("Please Select a Equipment ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            txtModelNo.Focus();
        //            return ;
        //        }
        //        ITEquipmentTran oITEquipmentTran = (ITEquipmentTran)lvwITEquipmentHistoryList.SelectedItems[0].Tag;               
        //        int nMaxTranID = oITEquipmentTran.MaxTranID();
             
        //        if (oITEquipmentTran.TranID == nMaxTranID)
        //        {
        //            try
        //            {

        //                DBController.Instance.BeginNewTransaction();
        //                oITEquipmentTran.Delete();                        
        //                nMaxTranID = oITEquipmentTran.MaxTranID();
        //                oITEquipmentTran.TranID = nMaxTranID;
        //                oITEquipmentTran.Refresh();
        //                oITEquipmentTran.UpdateITAsset();

        //                DBController.Instance.CommitTransaction();
        //                MessageBox.Show("You Have Successfully Deleted.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                DBController.Instance.OpenNewConnection();
        //                ReloadData(); 
                       
        //            }
        //            catch (Exception ex)
        //            {
        //                DBController.Instance.RollbackTransaction();
        //                MessageBox.Show(ex.Message, "Error!!!");
        //            }
                   
        //        }
        //        else MessageBox.Show("Please Maintain Transaction order for delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
               
        //    }

        //}

        private void cbTranType_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbTranType.SelectedIndex == (int)Dictionary.ITEquipmentTranType.Return_Supplier || cbTranType.SelectedIndex == 4 || cbTranType.SelectedIndex == 7)
                radioButton3.Checked = true;

           else if (cbTranType.SelectedIndex == 5 || cbTranType.SelectedIndex == 6 )
                radioButton2.Checked = true;

            else radioButton1.Checked = true;


            if (cbTranType.SelectedIndex == 1)
                cbStoreName.SelectedIndex = 1;
            if (cbTranType.SelectedIndex == 2 || cbTranType.SelectedIndex == 4)
                cbStoreName.SelectedIndex = 0;
            if (cbTranType.SelectedIndex == 5)
                cbStoreName.SelectedIndex = 2;
            if (cbTranType.SelectedIndex == 6)
                cbStoreName.SelectedIndex = 3;

            if (cbTranType.SelectedIndex == 3 || cbTranType.SelectedIndex == 7 || cbTranType.SelectedIndex == 8)
                cbStoreName.Enabled = false;
            else cbStoreName.Enabled = true;


        }

        public void Clear()
        {
            cbTranType.SelectedIndex = 1;
            cbStoreName.SelectedIndex = 0;           
            ctlNewEmployee.txtCode.Text = "";
            ctlNewEmployee.txtDescription.Text = "";
            cbDepartment.Text = "";
            cbCompany.Text = "";
        }

        private void btnDeleteHistory_Click(object sender, EventArgs e)
        {
            if (lvwITEquipmentHistoryList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row to Delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ITEquipmentTran _oITEqptTran = (ITEquipmentTran)lvwITEquipmentHistoryList.SelectedItems[0].Tag;
            string sTranType = "";
            if (_oITEqptTran.TranType == (int)Dictionary.ITEquipmentTranType.Assign_To_User)
                sTranType = "Assign_To_User";
            else if (_oITEqptTran.TranType == (int)Dictionary.ITEquipmentTranType.Return_MIS)
                sTranType = "Return_MIS";
            else if (_oITEqptTran.TranType == (int)Dictionary.ITEquipmentTranType.Return_Supplier)
                sTranType = "Return_Supplier";
            else if (_oITEqptTran.TranType == (int)Dictionary.ITEquipmentTranType.Get_back_Supplier)
                sTranType = "Get_back_Supplier";
            else if (_oITEqptTran.TranType == (int)Dictionary.ITEquipmentTranType.Defect)
                sTranType = "Defect";
            else if (_oITEqptTran.TranType == (int)Dictionary.ITEquipmentTranType.Repair)
                sTranType = "Repair";
            else if (_oITEqptTran.TranType == (int)Dictionary.ITEquipmentTranType.Purchase)
                sTranType = "Purchase";
            else sTranType = "Discard";
            int nMaxTranID = _oITEqptTran.MaxTranID();
            if (_oITEqptTran.FromStoreID != (int)Dictionary.ITEquipmentSystemStock.System)
            {
                if (_oITEqptTran.TranID == nMaxTranID)
                {
                    DialogResult oResult = MessageBox.Show("Are you sure you want to delete History: " + sTranType + "(" + _oITEqptTran.TranDate.ToString("dd-MMM-yyyy") + ")" + " ? ", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (oResult == DialogResult.Yes)
                    {

                        try
                        {
                            DBController.Instance.BeginNewTransaction();
                            _oITEquipmentTran = new ITEquipmentTran();
                            _oITEquipmentTran.TranID = _oITEqptTran.TranID;
                            _oITEquipmentTran.Delete();
                            nMaxTranID = _oITEqptTran.MaxTranID();
                            _oITEqptTran.TranID = nMaxTranID;
                            _oITEqptTran.Refresh();
                            _oITEqptTran.UpdateITAsset();
                            DBController.Instance.CommitTransaction();
                            MessageBox.Show("You Have Successfully Deleted.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            DBController.Instance.OpenNewConnection();
                            RefreshData();
                        }
                        catch (Exception ex)
                        {
                            DBController.Instance.RollbackTransaction();
                            MessageBox.Show(ex.Message, "Error!!!");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please Maintain Transaction order for delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                MessageBox.Show("System Stock is not eligible to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void ctlNewEmployee_Load(object sender, EventArgs e)
        {

        }
    }
}
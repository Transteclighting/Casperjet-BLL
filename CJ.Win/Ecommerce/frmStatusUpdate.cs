using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Win.Security;

namespace CJ.Win.Ecommerce
{
    public partial class frmStatusUpdate : Form
    {
        ProductDetail _oProductDetail;
        Warehouse oWarehouse;
        Utilities _oUtilitys;
        int nCurrentStatus = 0;

        public frmStatusUpdate()
        {
            InitializeComponent();
        }

        private void frmStatusUpdate_Load(object sender, EventArgs e)
        {
            updateSecurity();      
           
        }
        public void ShowDialog(ECOrder oECOrder)
        {
            this.Tag = oECOrder;
          
            lbOrderNo.Text = oECOrder.OrderNo;
            lbOrderDate.Text=oECOrder.OrderDate.ToString("dd-MMM-yyyy");         
            lbCustomer.Text = oECOrder.CustomerName;        
            lbMail.Text = oECOrder.CustomerMailID;
            lbMobile.Text = oECOrder.CustomerMobileNo;
            oWarehouse = new Warehouse();
            oWarehouse.WarehouseID = oECOrder.DeliveryWHID;
            oWarehouse.Reresh();
            lbWarehouse.Text = oWarehouse.WarehouseName;
            nCurrentStatus = oECOrder.OrderStatus;
            
            this.ShowDialog();
        }
        private bool validateUIInput()
        {
            #region Order Master Information Validation
            if (txtRemarks.Text == "")
            {
                MessageBox.Show("Please enter remarks.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRemarks.Focus();
                return false;
            }
            
            #endregion       

            return true;
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                if (this.Tag != null)
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        ECOrder oECOrder = (ECOrder)(this.Tag);
                        if (cmbSatus.Text == "Stock_to_be_Available_Within_2WD")
                        {
                            oECOrder.DesiredStockAvailableDate = dtDate.Value.Date;
                            oECOrder.UserID = Utility.UserId;
                            oECOrder.Date = DateTime.Now;
                            oECOrder.Remarks = txtRemarks.Text;
                            oECOrder.OrderStatus = (int)Dictionary.ECOrderStatus.Stock_to_be_Available_Within_2WD;

                            oECOrder.UpdateStockAvailableDate();
                        }
                        else
                        {
                            oECOrder.UserID = Utility.UserId;
                            oECOrder.Date = DateTime.Now;
                            oECOrder.Remarks = txtRemarks.Text;
                            oECOrder.OrderStatus = GetStatus();
                           // if (CheckStatus(oECOrder))
                                oECOrder.UpdateStatus();
                            //else
                            //{
                            //    MessageBox.Show("Invalid Status,Please Input Valid Status", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);                              
                            //    return;
                            //}
                        }
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Success fully Update  Order -" + oECOrder.OrderNo, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show("Error... " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void updateSecurity()
        {
            //Users oUsers = new Users();
            //Permission oPermission = new Permission();
            //DSPermission _oDsPermission = oPermission.getPermissionList();        

            //DataRow[] oPermitedRow = _oDsPermission.Permission.Select("MenuType >= '" + (short)Dictionary.MenuType.Buttton + "'");

            //foreach (DataRow oRow in oPermitedRow)
            //{
            //    string sPermissionKey = oUsers.checkOtherPermission(oRow["PermissionKey"].ToString(), Utility.UserId);
            //    if (sPermissionKey != null)
            //    {
            //        if ("M1.62" == sPermissionKey)
            //        {
            //            _oUtilitys = new Utilities();
            //            cmbSatus.Items.Clear();
            //            _oUtilitys.GetECOrderStatus();
            //            foreach (Utility oUtility in _oUtilitys)
            //            {
            //                if (oUtility.SatusId == (int)Dictionary.ECOrderStatus.Happy_Call || oUtility.SatusId == (int)Dictionary.ECOrderStatus.Cancel)
            //                    cmbSatus.Items.Add(oUtility.Satus);
            //            }
            //            cmbSatus.SelectedIndex = 0;
            //        }
            //        if ("M1.63" == sPermissionKey)
            //        {
            //            _oUtilitys = new Utilities();
            //            cmbSatus.Items.Clear();
            //            _oUtilitys.GetECOrderStatus();
            //            foreach (Utility oUtility in _oUtilitys)
            //            {
            //                if (oUtility.SatusId == (int)Dictionary.ECOrderStatus.Stock_to_be_Available_Within_2WD || oUtility.SatusId == (int)Dictionary.ECOrderStatus.Stock_No_Longer_Available)
            //                    cmbSatus.Items.Add(oUtility.Satus);
            //            }
            //            cmbSatus.SelectedIndex = 0;
            //        }
            //        if ("M1.64" == sPermissionKey)
            //        {
            //            _oUtilitys = new Utilities();
            //            cmbSatus.Items.Clear();
            //            _oUtilitys.GetECOrderStatus();
            //            foreach (Utility oUtility in _oUtilitys)
            //            {
            //                if (oUtility.SatusId == (int)Dictionary.ECOrderStatus.Confirm_Payment || oUtility.SatusId == (int)Dictionary.ECOrderStatus.Confirm_Stock_Outlet || oUtility.SatusId == (int)Dictionary.ECOrderStatus.UnAvailable_Stock_Outlet || oUtility.SatusId == (int)Dictionary.ECOrderStatus.Product_Delivered)
            //                    cmbSatus.Items.Add(oUtility.Satus);
            //            }
            //            cmbSatus.SelectedIndex = 0;
            //        }
            //        if ("M1.65" == sPermissionKey)
            //        {
                        _oUtilitys = new Utilities();
                        cmbSatus.Items.Clear();
                        _oUtilitys.GetECOrderStatus();
                        foreach (Utility oUtility in _oUtilitys)
                        {
                            cmbSatus.Items.Add(oUtility.Satus);
                        }
                        cmbSatus.SelectedIndex = 0;
                    //}


            //    }
            //}

        }
        public int GetStatus()
        {
            if (cmbSatus.Text == "Confirm_Payment")
                return (int)Dictionary.ECOrderStatus.Confirm_Payment;
            else if (cmbSatus.Text == "Stock_to_be_Available_Within_2WD")
                return (int)Dictionary.ECOrderStatus.Stock_to_be_Available_Within_2WD;
            else if (cmbSatus.Text == "Confirm_Stock_Outlet")
                return (int)Dictionary.ECOrderStatus.Confirm_Stock_Outlet;
            else if (cmbSatus.Text == "Happy_Call")
                return (int)Dictionary.ECOrderStatus.Happy_Call;
            else if (cmbSatus.Text == "Product_Delivered")
                return (int)Dictionary.ECOrderStatus.Product_Delivered;
            else if (cmbSatus.Text == "Stock_No_Longer_Available")
                return (int)Dictionary.ECOrderStatus.Stock_No_Longer_Available;
            else if (cmbSatus.Text == "UnAvailable_Stock_Outlet")
                return (int)Dictionary.ECOrderStatus.UnAvailable_Stock_Outlet;
            else if (cmbSatus.Text == "Stock_to_be_Available_later")
                return (int)Dictionary.ECOrderStatus.Stock_to_be_Available_later;
            else if (cmbSatus.Text == "Order_Confirmation_from_Customer")
                return (int)Dictionary.ECOrderStatus.Order_Confirmation_from_Customer;
            else if (cmbSatus.Text == "Pick_Up_DD_Extended")
                return (int)Dictionary.ECOrderStatus.Pick_Up_DD_Extended;
            else if (cmbSatus.Text == "Cancel")
                return (int)Dictionary.ECOrderStatus.Cancel;
            return 0;
        }
        public bool CheckStatus(ECOrder oECOrder)
        {
            int nCount = 0;
            if (nCurrentStatus == (int)Dictionary.ECOrderStatus.Submitted)
            {
                if (oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Confirm_Stock_Outlet || oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.UnAvailable_Stock_Outlet || oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Cancel)
                {
                    nCount++;
                }
            }
            if (nCurrentStatus == (int)Dictionary.ECOrderStatus.Confirm_Stock_Outlet)
            {
                if (oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Confirm_Payment || oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Cancel)
                {
                    nCount++;
                }
            }
            if (nCurrentStatus == (int)Dictionary.ECOrderStatus.Confirm_Payment)
            {
                if (oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Product_Delivered || oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Cancel)
                {
                    nCount++;
                }
            }
            if (nCurrentStatus == (int)Dictionary.ECOrderStatus.Product_Delivered)
            {
                if (oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Happy_Call )
                {
                    nCount++;
                }
            }
            if (nCurrentStatus == (int)Dictionary.ECOrderStatus.UnAvailable_Stock_Outlet)
            {
                if (oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Stock_to_be_Available_Within_2WD || oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Stock_No_Longer_Available || oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Cancel)
                {
                    nCount++;
                }
            }
            if (nCurrentStatus == (int)Dictionary.ECOrderStatus.Stock_to_be_Available_Within_2WD)
            {
                if (oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Confirm_Stock_Outlet ||oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Cancel)
                {
                    nCount++;
                }
            }
            if (nCurrentStatus == (int)Dictionary.ECOrderStatus.Stock_No_Longer_Available)
            {
                if (oECOrder.OrderStatus == (int)Dictionary.ECOrderStatus.Cancel)
                {
                    nCount++;
                }
            }
            if (nCount == 0)
                return false;
            else return true;
        }
        private void cmbSatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSatus.Text == "Stock_to_be_Available_Within_2WD")
            {
                lbDate.Visible = true;
                dtDate.Visible = true;
            }
            else
            {
                lbDate.Visible = false;
                dtDate.Visible = false;
            }
        }
    }
}
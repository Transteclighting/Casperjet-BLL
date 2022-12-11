using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.POS.TELWEBSERVER;
using CJ.POS.Security;
using CJ.Class;
using CJ.Report;
using CJ.Report.POS;


namespace CJ.POS
{
    public partial class frmRequisitions : Form
    {
        DSDataRange oDSDataRange;
        DSRequisition oDSRequisition;
        DSRequisition oDSRequisitionItem;
        CJ.POS.TELWEBSERVER.DSPermission oDSPermission;

        DSProductTransaction oDSProductTransaction;
      
        Service oService;
        int _nUIControl=-1;

        public frmRequisitions(int nUIControl)
        {
            InitializeComponent();
            _nUIControl = nUIControl;
        }
        private void frmRequisitions_Load(object sender, EventArgs e)
        {           
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ProductRequisitionStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.ProductRequisitionStatus), GetEnum));
            }       
          
            if (_nUIControl == (int)Dictionary.ProductRequisitionStatus.Authorized)
            {
                btDelete.Visible = false;
                btnAdd.Visible = false;
                btnEdit.Visible = false;              
                btPrint.Visible = false;
                btAuthorizePrint.Visible = true;
                cmbStatus.SelectedIndex = (int)Dictionary.ProductRequisitionStatus.Submitted;
            }
            else if (_nUIControl == (int)Dictionary.ProductRequisitionStatus.Transfer_Out)
            {               
                btDelete.Visible = false;
                btnAdd.Visible = false;
                btnEdit.Visible = false;               
                btPrint.Visible = true;
                btAuthorizePrint.Visible = false;
                cmbStatus.SelectedIndex = (int)Dictionary.ProductRequisitionStatus.Authorized;
            }
            else if (_nUIControl == (int)Dictionary.ProductRequisitionStatus.Transfer_Received)
            {
              
                btDelete.Visible = false;
                btnAdd.Visible = false;
                btnEdit.Visible = false;              
                btPrint.Visible = false;
                btAuthorizePrint.Visible = false;
                cmbStatus.SelectedIndex = (int)Dictionary.ProductRequisitionStatus.Transfer_Out;
            }
            else if (_nUIControl == (int)Dictionary.ProductRequisitionStatus.Submitted)
            {
              
                btDelete.Visible = true;
                btnAdd.Visible = true;
                btnEdit.Visible = true;               
                btPrint.Visible = false;
                btAuthorizePrint.Visible = false;
                cmbStatus.SelectedIndex = (int)Dictionary.ProductRequisitionStatus.ALL;
            }
            else
            {              
                btDelete.Visible = false;
                btnAdd.Visible = false;
                btnEdit.Visible = false;               
                btPrint.Visible = false;
                btAuthorizePrint.Visible = false;
            }

            try
            {
                oService = new Service();
                oDSPermission = new CJ.POS.TELWEBSERVER.DSPermission();
                try
                {
                    oDSPermission = oService.GetAllPermission(oDSPermission, Utility.UserId);
                }
                catch
                {
                    MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            catch
            {
                MessageBox.Show(" Please check your internet connection ...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btTransfer.Visible = false;
            btPrint.Visible = false;
            btGoodsReceived.Visible = false;
            btConfirm.Visible = false;
            btRCancel.Visible = false;
            btAuthorizeClancel.Visible = false;
            btRetrun.Visible = false;

            foreach (CJ.POS.TELWEBSERVER.DSPermission.PermissionRow oPermissionRow in oDSPermission.Permission)
            {
            
                if (oPermissionRow.PermissionKey == "M1.57")
                {
                    if (_nUIControl == (int)Dictionary.ProductRequisitionStatus.Transfer_Out)
                    {
                        cmbStatus.SelectedIndex = (int)Dictionary.ProductRequisitionStatus.Authorized;
                        btTransfer.Visible = true;
                        btPrint.Visible = true;
                    }
                }
                else if (oPermissionRow.PermissionKey == "M1.58")
                {
                    if (_nUIControl == -1)
                    {
                        cmbStatus.SelectedIndex = (int)Dictionary.ProductRequisitionStatus.Transfer_Out;
                        btRetrun.Visible = true;
                    }                    
                }             
                else if (oPermissionRow.PermissionKey == "M1.59")
                {
                    if (_nUIControl == (int)Dictionary.ProductRequisitionStatus.Transfer_Received)
                    {
                        cmbStatus.SelectedIndex = (int)Dictionary.ProductRequisitionStatus.Transfer_Out;
                        btGoodsReceived.Visible = true;
                    }
                }
                else if (oPermissionRow.PermissionKey == "M1.60")
                {
                    if (_nUIControl == (int)Dictionary.ProductRequisitionStatus.Authorized)
                    {
                        cmbStatus.SelectedIndex = (int)Dictionary.ProductRequisitionStatus.Submitted;
                        btConfirm.Visible = true;
                        btRCancel.Visible = true;
                        btAuthorizeClancel.Visible = true;
                    }
                }
            }           

            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmRequisiton oFrom = new frmRequisiton();         
            oFrom.ShowDialog();
            LoadData();
        }
        private void btGetData_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            oDSRequisition = new DSRequisition();
            DSRequisition.RequisitionRow oSelectedRequisitionRow = (DSRequisition.RequisitionRow)lvwOrderList.SelectedItems[0].Tag;

            DSRequisition.RequisitionRow oRequisitionRow = oDSRequisition.Requisition.NewRequisitionRow();

            oRequisitionRow.RequisitionID = oSelectedRequisitionRow.RequisitionID.ToString();
            oRequisitionRow.RequisitionNo = oSelectedRequisitionRow.RequisitionNo.ToString();
            oRequisitionRow.RequisitionDate = oSelectedRequisitionRow.RequisitionDate;
            oRequisitionRow.FromWHID = oSelectedRequisitionRow.FromWHID.ToString();
            oRequisitionRow.ToWHID = oSelectedRequisitionRow.ToWHID.ToString();
            oRequisitionRow.CreateUserID = oSelectedRequisitionRow.CreateUserID.ToString();
            oRequisitionRow.CreateDate = oSelectedRequisitionRow.CreateDate;
            oRequisitionRow.AuthorizeUserID = oSelectedRequisitionRow.AuthorizeUserID.ToString();
            oRequisitionRow.AuthorizeDate = oSelectedRequisitionRow.AuthorizeDate.ToString();
            oRequisitionRow.Status = oSelectedRequisitionRow.Status.ToString();
            oRequisitionRow.Remarks = oSelectedRequisitionRow.Remarks;
            oRequisitionRow.StockTranID = oSelectedRequisitionRow.StockTranID.ToString();

            oDSRequisition.Requisition.AddRequisitionRow(oRequisitionRow);
            oDSRequisition.AcceptChanges();

            if (int.Parse(oDSRequisition.Requisition[0].Status) == (int)Dictionary.ProductRequisitionStatus.Submitted)
            {
                frmRequisiton oFrom = new frmRequisiton();
                oFrom.ShowDialog(oDSRequisition);
                LoadData();
            }
            else MessageBox.Show("Only Submitted requisition can be Updated.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
           
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void LoadData()
        {
              int nStatus=-1;
              oDSDataRange = new DSDataRange();
            oDSRequisition = new DSRequisition();
            oService = new Service();

            if ((int)(Dictionary.ProductRequisitionStatus)cmbStatus.SelectedIndex != 5)
                nStatus = (int)(Dictionary.ProductRequisitionStatus)cmbStatus.SelectedIndex;
            else nStatus = -1;

            DSDataRange.DataRangeRow oDataRangeRow = oDSDataRange.DataRange.NewDataRangeRow();
            oDataRangeRow.FromDate = dtFromDate.Value.Date;
            oDataRangeRow.ToDate = dtToDate.Value.Date;
            oDataRangeRow.UserID = Utility.UserId.ToString();
            oDSDataRange.DataRange.AddDataRangeRow(oDataRangeRow);
            oDSDataRange.AcceptChanges();


            DSRequisition.RequisitionRow oRequisitionRow = oDSRequisition.Requisition.NewRequisitionRow();
            oRequisitionRow.RequisitionID = "-1";
            oRequisitionRow.Status = nStatus.ToString();
            oRequisitionRow.RequisitionNo = txtRequisitionNo.Text;
            oDSRequisition.Requisition.AddRequisitionRow(oRequisitionRow);
            oDSRequisition.AcceptChanges();

            try
            {
                if (_nUIControl != (int)Dictionary.ProductRequisitionStatus.Submitted)
                {
                    if (_nUIControl != (int)Dictionary.ProductRequisitionStatus.Authorized)
                        oDSRequisition = oService.RequisitionRefresh(oDSRequisition, oDSDataRange, true, true);
                    else oDSRequisition = oService.RequisitionRefresh(oDSRequisition, oDSDataRange, true, false);
                }
                else
                {                   
                    oDSRequisition = oService.RequisitionRefresh(oDSRequisition, oDSDataRange, false, false);
                }
            }
            catch
            {
                MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            lvwOrderList.Items.Clear();
            if (oDSRequisition.Requisition.Count > 0)
            {
                foreach (DSRequisition.RequisitionRow _oRequisitionRow in oDSRequisition.Requisition)
                {
                    ListViewItem lstItem = lvwOrderList.Items.Add(_oRequisitionRow.RequisitionNo);
                    lstItem.SubItems.Add(_oRequisitionRow.FromWHName);
                    lstItem.SubItems.Add((Convert.ToDateTime(_oRequisitionRow.RequisitionDate)).ToString("dd-MMM-yyyy"));
                    if (int.Parse(_oRequisitionRow.Status) == (int)Dictionary.ProductRequisitionStatus.Submitted)
                    {
                        lstItem.SubItems.Add("Submitted");
                    }
                    if (int.Parse(_oRequisitionRow.Status) == (int)Dictionary.ProductRequisitionStatus.Authorized)
                    {
                        lstItem.SubItems.Add("Authorized");
                    }
                    if (int.Parse(_oRequisitionRow.Status) == (int)Dictionary.ProductRequisitionStatus.Transfer_Out)
                    {
                        lstItem.SubItems.Add("Transfer Out");
                    }
                    if (int.Parse(_oRequisitionRow.Status) == (int)Dictionary.ProductRequisitionStatus.Transfer_Received)
                    {
                        lstItem.SubItems.Add("Transfer Received");
                    }
                    if (int.Parse(_oRequisitionRow.Status) == (int)Dictionary.ProductRequisitionStatus.Cancel)
                    {
                        lstItem.SubItems.Add("Cancel");
                    }
                    lstItem.SubItems.Add(_oRequisitionRow.ToWHName);
                    lstItem.SubItems.Add(_oRequisitionRow.Remarks);

                    lstItem.Tag = _oRequisitionRow;
                }
                this.Text = "Requisition " + "[" + oDSRequisition.Requisition.Count + "]";
            }
            else this.Text = "Requisition " + "[" + 0 + "]";

        }

        private void lvwOrderList_SelectedIndexChanged(object sender, EventArgs e)
        {
           

        }
        private void btDelete_Click(object sender, EventArgs e)
        {
            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
       
            oDSRequisition = new DSRequisition();
            DSRequisition.RequisitionRow oSelectedRequisitionRow = (DSRequisition.RequisitionRow)lvwOrderList.SelectedItems[0].Tag;

            DSRequisition.RequisitionRow oRequisitionRow = oDSRequisition.Requisition.NewRequisitionRow();

            oRequisitionRow.RequisitionID = oSelectedRequisitionRow.RequisitionID.ToString();
            oRequisitionRow.RequisitionNo = oSelectedRequisitionRow.RequisitionNo.ToString();
            oRequisitionRow.RequisitionDate = oSelectedRequisitionRow.RequisitionDate;
            oRequisitionRow.FromWHID = oSelectedRequisitionRow.FromWHID.ToString();
            oRequisitionRow.ToWHID = oSelectedRequisitionRow.ToWHID.ToString();
            oRequisitionRow.CreateUserID = oSelectedRequisitionRow.CreateUserID.ToString();
            oRequisitionRow.CreateDate = oSelectedRequisitionRow.CreateDate;
            oRequisitionRow.AuthorizeUserID = oSelectedRequisitionRow.AuthorizeUserID.ToString();
            oRequisitionRow.AuthorizeDate = oSelectedRequisitionRow.AuthorizeDate.ToString();
            oRequisitionRow.Status = oSelectedRequisitionRow.Status.ToString();
            oRequisitionRow.Remarks = oSelectedRequisitionRow.Remarks;
            oRequisitionRow.StockTranID = oSelectedRequisitionRow.StockTranID.ToString();

            oDSRequisition.Requisition.AddRequisitionRow(oRequisitionRow);
            oDSRequisition.AcceptChanges();


            if (int.Parse(oDSRequisition.Requisition[0].Status) == (int)Dictionary.ProductRequisitionStatus.Submitted)
            {
                oService = new Service();
                try
                {
                    oDSRequisition = oService.DeleteRequisition(oDSRequisition);
                }
                catch
                {
                    MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (oDSRequisition.Requisition[0].Result == "1")
                    MessageBox.Show("You Have Successfully Delete Requisition, Requisition No - " + oDSRequisition.Requisition[0].RequisitionNo, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show(oDSRequisition.Requisition[0].Result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                LoadData();
            }
            else MessageBox.Show("Only Submitted requisition can be Delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
          


        }

        private void btConfirm_Click(object sender, EventArgs e)
        {
            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            oDSRequisition = new DSRequisition();
            DSRequisition.RequisitionRow oSelectedRequisitionRow = (DSRequisition.RequisitionRow)lvwOrderList.SelectedItems[0].Tag;

            DSRequisition.RequisitionRow oRequisitionRow = oDSRequisition.Requisition.NewRequisitionRow();

            oRequisitionRow.RequisitionID = oSelectedRequisitionRow.RequisitionID.ToString();
            oRequisitionRow.RequisitionNo = oSelectedRequisitionRow.RequisitionNo.ToString();
            oRequisitionRow.RequisitionDate = oSelectedRequisitionRow.RequisitionDate;
            oRequisitionRow.FromWHID = oSelectedRequisitionRow.FromWHID.ToString();
            oRequisitionRow.ToWHID = oSelectedRequisitionRow.ToWHID.ToString();
            oRequisitionRow.CreateUserID = oSelectedRequisitionRow.CreateUserID.ToString();
            oRequisitionRow.CreateDate = oSelectedRequisitionRow.CreateDate;
            oRequisitionRow.AuthorizeUserID = oSelectedRequisitionRow.AuthorizeUserID.ToString();
            oRequisitionRow.AuthorizeDate = oSelectedRequisitionRow.AuthorizeDate.ToString();
            oRequisitionRow.Status = oSelectedRequisitionRow.Status.ToString();
            oRequisitionRow.Remarks = oSelectedRequisitionRow.Remarks;
            oRequisitionRow.StockTranID = oSelectedRequisitionRow.StockTranID.ToString();

            oDSRequisition.Requisition.AddRequisitionRow(oRequisitionRow);
            oDSRequisition.AcceptChanges();

            if (int.Parse(oDSRequisition.Requisition[0].Status) == (int)Dictionary.ProductRequisitionStatus.Submitted)
            {
                frmRequisitionAuthorize oFrom = new frmRequisitionAuthorize();
                oFrom.ShowDialog(oDSRequisition);
                LoadData();
            }
            else MessageBox.Show("Only Submitted requisition can be Authorized.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                
          
        }
        private void btRCancel_Click(object sender, EventArgs e)
        {
            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            oDSRequisition = new DSRequisition();
            oDSRequisition.RequisitionItem.Clear();
            DSRequisition.RequisitionRow oSelectedRequisitionRow = (DSRequisition.RequisitionRow)lvwOrderList.SelectedItems[0].Tag;

            DSRequisition.RequisitionRow oRequisitionRow = oDSRequisition.Requisition.NewRequisitionRow();

            oRequisitionRow.RequisitionID = oSelectedRequisitionRow.RequisitionID.ToString();
            oRequisitionRow.RequisitionNo = oSelectedRequisitionRow.RequisitionNo.ToString();
            oRequisitionRow.RequisitionDate = oSelectedRequisitionRow.RequisitionDate;
            oRequisitionRow.FromWHID = oSelectedRequisitionRow.FromWHID.ToString();
            oRequisitionRow.ToWHID = oSelectedRequisitionRow.ToWHID.ToString();
            oRequisitionRow.CreateUserID = oSelectedRequisitionRow.CreateUserID.ToString();
            oRequisitionRow.CreateDate = oSelectedRequisitionRow.CreateDate;
            oRequisitionRow.AuthorizeUserID = oSelectedRequisitionRow.AuthorizeUserID.ToString();
            oRequisitionRow.AuthorizeDate = oSelectedRequisitionRow.AuthorizeDate.ToString();
            oRequisitionRow.Status = oSelectedRequisitionRow.Status.ToString();
            oRequisitionRow.Remarks = oSelectedRequisitionRow.Remarks;
            oRequisitionRow.StockTranID = oSelectedRequisitionRow.StockTranID.ToString();

            oDSRequisition.Requisition.AddRequisitionRow(oRequisitionRow);
            oDSRequisition.AcceptChanges();

            if (int.Parse(oDSRequisition.Requisition[0].Status) == (int)Dictionary.ProductRequisitionStatus.Submitted)
            {
                oService = new Service();
                try
                {
                    oDSRequisition.Requisition[0].Status = Convert.ToString((int)Dictionary.ProductRequisitionStatus.Cancel);
                    oDSRequisition = oService.RequisitionAuthorize(oDSRequisition, Utility.UserId);

                    if (oDSRequisition.Requisition[0].Result == "1")
                    {
                         MessageBox.Show("You Have Successfully Cancel This Requisition, Requisition No - " + oDSRequisition.Requisition[0].RequisitionNo, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show(oDSRequisition.Requisition[0].Result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch
                {
                    MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }  
                LoadData();
            }
            else MessageBox.Show("Only Submitted requisition can be Cancel.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        private void btAuthorizeClancel_Click(object sender, EventArgs e)
        {
            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            oDSRequisition = new DSRequisition();
            oDSRequisition.RequisitionItem.Clear();
            DSRequisition.RequisitionRow oSelectedRequisitionRow = (DSRequisition.RequisitionRow)lvwOrderList.SelectedItems[0].Tag;

            DSRequisition.RequisitionRow oRequisitionRow = oDSRequisition.Requisition.NewRequisitionRow();

            oRequisitionRow.RequisitionID = oSelectedRequisitionRow.RequisitionID.ToString();
            oRequisitionRow.RequisitionNo = oSelectedRequisitionRow.RequisitionNo.ToString();
            oRequisitionRow.RequisitionDate = oSelectedRequisitionRow.RequisitionDate;
            oRequisitionRow.FromWHID = oSelectedRequisitionRow.FromWHID.ToString();
            oRequisitionRow.ToWHID = oSelectedRequisitionRow.ToWHID.ToString();
            oRequisitionRow.CreateUserID = oSelectedRequisitionRow.CreateUserID.ToString();
            oRequisitionRow.CreateDate = oSelectedRequisitionRow.CreateDate;
            oRequisitionRow.AuthorizeUserID = oSelectedRequisitionRow.AuthorizeUserID.ToString();
            oRequisitionRow.AuthorizeDate = oSelectedRequisitionRow.AuthorizeDate.ToString();
            oRequisitionRow.Status = oSelectedRequisitionRow.Status.ToString();
            oRequisitionRow.Remarks = oSelectedRequisitionRow.Remarks;
            oRequisitionRow.StockTranID = oSelectedRequisitionRow.StockTranID.ToString();

            oDSRequisition.Requisition.AddRequisitionRow(oRequisitionRow);
            oDSRequisition.AcceptChanges();

            if (int.Parse(oDSRequisition.Requisition[0].Status) == (int)Dictionary.ProductRequisitionStatus.Authorized)
            {
                oService = new Service();
                try
                {
                    oDSRequisition.Requisition[0].Status = Convert.ToString((int)Dictionary.ProductRequisitionStatus.Submitted);
                    oDSRequisition = oService.RequisitionAuthorize(oDSRequisition, Utility.UserId);

                    if (oDSRequisition.Requisition[0].Result == "1")
                    {
                        MessageBox.Show("You Have Successfully Cancel This Requisition, Requisition No - " + oDSRequisition.Requisition[0].RequisitionNo, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show(oDSRequisition.Requisition[0].Result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch
                {
                    MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                LoadData();
            }
            else MessageBox.Show("Only Authorized requisition can be Cancel.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        
        } 

        private void btTransfer_Click(object sender, EventArgs e)
        {
            int nRequisitionID = 0;
            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            oDSRequisition = new DSRequisition();
            DSRequisition.RequisitionRow oSelectedRequisitionRow = (DSRequisition.RequisitionRow)lvwOrderList.SelectedItems[0].Tag;

            DSRequisition.RequisitionRow oRequisitionRow = oDSRequisition.Requisition.NewRequisitionRow();

            oRequisitionRow.RequisitionID = oSelectedRequisitionRow.RequisitionID.ToString();
            nRequisitionID = int.Parse(oRequisitionRow.RequisitionID);
            oRequisitionRow.RequisitionNo = oSelectedRequisitionRow.RequisitionNo.ToString();
            oRequisitionRow.RequisitionDate = oSelectedRequisitionRow.RequisitionDate;
            oRequisitionRow.FromWHID = oSelectedRequisitionRow.FromWHID.ToString();
            oRequisitionRow.ToWHID = oSelectedRequisitionRow.ToWHID.ToString();
            oRequisitionRow.CreateUserID = oSelectedRequisitionRow.CreateUserID.ToString();
            oRequisitionRow.CreateDate = oSelectedRequisitionRow.CreateDate;
            oRequisitionRow.AuthorizeUserID = oSelectedRequisitionRow.AuthorizeUserID.ToString();
            oRequisitionRow.AuthorizeDate = oSelectedRequisitionRow.AuthorizeDate.ToString();
            oRequisitionRow.Status = oSelectedRequisitionRow.Status.ToString();
            oRequisitionRow.Remarks = oSelectedRequisitionRow.Remarks;
            oRequisitionRow.StockTranID = oSelectedRequisitionRow.StockTranID.ToString();

            oDSRequisition.Requisition.AddRequisitionRow(oRequisitionRow);
            oDSRequisition.AcceptChanges();


            if (int.Parse(oDSRequisition.Requisition[0].Status) == (int)Dictionary.ProductRequisitionStatus.Authorized)
            {
                frmRequisitionTransfer oFrom = new frmRequisitionTransfer();
                oFrom.ShowDialog(oDSRequisition);
                LoadData();              
            }
            else MessageBox.Show("Only Authorized requisition can be Transfered.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
             
        }

        private void btGoodsReceived_Click(object sender, EventArgs e)
        {
            int nRequisitionID = 0;
            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            oDSRequisition = new DSRequisition();
            DSRequisition.RequisitionRow oSelectedRequisitionRow = (DSRequisition.RequisitionRow)lvwOrderList.SelectedItems[0].Tag;

            DSRequisition.RequisitionRow oRequisitionRow = oDSRequisition.Requisition.NewRequisitionRow();

            oRequisitionRow.RequisitionID = oSelectedRequisitionRow.RequisitionID.ToString();
            nRequisitionID = int.Parse(oRequisitionRow.RequisitionID);
            oRequisitionRow.RequisitionNo = oSelectedRequisitionRow.RequisitionNo.ToString();
            oRequisitionRow.RequisitionDate = oSelectedRequisitionRow.RequisitionDate;
            oRequisitionRow.FromWHID = oSelectedRequisitionRow.FromWHID.ToString();
            oRequisitionRow.ToWHID = oSelectedRequisitionRow.ToWHID.ToString();
            oRequisitionRow.CreateUserID = oSelectedRequisitionRow.CreateUserID.ToString();
            oRequisitionRow.CreateDate = oSelectedRequisitionRow.CreateDate;
            oRequisitionRow.AuthorizeUserID = oSelectedRequisitionRow.AuthorizeUserID.ToString();
            oRequisitionRow.AuthorizeDate = oSelectedRequisitionRow.AuthorizeDate.ToString();
            oRequisitionRow.Status = oSelectedRequisitionRow.Status.ToString();
            oRequisitionRow.Remarks = oSelectedRequisitionRow.Remarks;
            oRequisitionRow.StockTranID = oSelectedRequisitionRow.StockTranID.ToString();          

            oDSRequisition.Requisition.AddRequisitionRow(oRequisitionRow);
            oDSRequisition.AcceptChanges();

            if (int.Parse(oDSRequisition.Requisition[0].Status) == (int)Dictionary.ProductRequisitionStatus.Transfer_Out)
            {
                oDSRequisitionItem = new DSRequisition();

                oService = new Service();
                try
                {
                    oDSRequisitionItem = oService.RequisitionRefreshItem(oDSRequisitionItem, nRequisitionID);
                    oDSRequisition = oService.GoodsReceived(oDSRequisition, oDSRequisitionItem, Utility.UserId);
                }
                catch
                {
                    MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (oDSRequisition.Requisition[0].Result == "1")
                {
                    MessageBox.Show("You Have Successfully Goods Received, Requisition No - " + oDSRequisition.Requisition[0].RequisitionNo, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbStatus.SelectedIndex = (int)Dictionary.ProductRequisitionStatus.ALL;
                    LoadData();
                }
                else
                    MessageBox.Show(oDSRequisition.Requisition[0].Result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            else MessageBox.Show("Only Transfer Out requisition can be Received.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btRetrun_Click(object sender, EventArgs e)
        {
            int nRequisitionID = 0;
            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            oDSRequisition = new DSRequisition();
            DSRequisition.RequisitionRow oSelectedRequisitionRow = (DSRequisition.RequisitionRow)lvwOrderList.SelectedItems[0].Tag;

            DSRequisition.RequisitionRow oRequisitionRow = oDSRequisition.Requisition.NewRequisitionRow();

            oRequisitionRow.RequisitionID = oSelectedRequisitionRow.RequisitionID.ToString();
            nRequisitionID = int.Parse(oRequisitionRow.RequisitionID);
            oRequisitionRow.RequisitionNo = oSelectedRequisitionRow.RequisitionNo.ToString();
            oRequisitionRow.RequisitionDate = oSelectedRequisitionRow.RequisitionDate;
            oRequisitionRow.FromWHID = oSelectedRequisitionRow.FromWHID.ToString();
            oRequisitionRow.ToWHID = oSelectedRequisitionRow.ToWHID.ToString();
            oRequisitionRow.CreateUserID = oSelectedRequisitionRow.CreateUserID.ToString();
            oRequisitionRow.CreateDate = oSelectedRequisitionRow.CreateDate;
            oRequisitionRow.AuthorizeUserID = oSelectedRequisitionRow.AuthorizeUserID.ToString();
            oRequisitionRow.AuthorizeDate = oSelectedRequisitionRow.AuthorizeDate.ToString();
            oRequisitionRow.Status = oSelectedRequisitionRow.Status.ToString();
            oRequisitionRow.Remarks = oSelectedRequisitionRow.Remarks;
            oRequisitionRow.StockTranID = oSelectedRequisitionRow.StockTranID.ToString();

            oDSRequisition.Requisition.AddRequisitionRow(oRequisitionRow);
            oDSRequisition.AcceptChanges();

            if (int.Parse(oDSRequisition.Requisition[0].Status) == (int)Dictionary.ProductRequisitionStatus.Transfer_Out || int.Parse(oDSRequisition.Requisition[0].Status) == (int)Dictionary.ProductRequisitionStatus.Transfer_Received)
            {
                oDSRequisitionItem = new DSRequisition();

                oService = new Service();
                try
                {
                    oDSRequisition = oService.GoodsRetrun(oDSRequisition);
                }
                catch
                {
                    MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (oDSRequisition.Requisition[0].Result == "1")
                {
                    MessageBox.Show("You Have Successfully Goods Retrun, Requisition No - " + oDSRequisition.Requisition[0].RequisitionNo, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                else
                    MessageBox.Show(oDSRequisition.Requisition[0].Result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);


            }
            else MessageBox.Show("Transfer Out and Received requisition can be Retrun.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
       
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            int nRequisitionID = 0;
            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            oDSRequisition = new DSRequisition();
            DSRequisition.RequisitionRow oSelectedRequisitionRow = (DSRequisition.RequisitionRow)lvwOrderList.SelectedItems[0].Tag;

            DSRequisition.RequisitionRow oRequisitionRow = oDSRequisition.Requisition.NewRequisitionRow();

            oRequisitionRow.RequisitionID = oSelectedRequisitionRow.RequisitionID.ToString();
            nRequisitionID = int.Parse(oRequisitionRow.RequisitionID);
            oRequisitionRow.RequisitionNo = oSelectedRequisitionRow.RequisitionNo.ToString();
            oRequisitionRow.RequisitionDate = oSelectedRequisitionRow.RequisitionDate;
            oRequisitionRow.FromWHID = oSelectedRequisitionRow.FromWHID.ToString();
            oRequisitionRow.ToWHID = oSelectedRequisitionRow.ToWHID.ToString();
            oRequisitionRow.CreateUserID = oSelectedRequisitionRow.CreateUserID.ToString();
            oRequisitionRow.CreateDate = oSelectedRequisitionRow.CreateDate;
            oRequisitionRow.AuthorizeUserID = oSelectedRequisitionRow.AuthorizeUserID.ToString();
            oRequisitionRow.AuthorizeDate = oSelectedRequisitionRow.AuthorizeDate.ToString();
            oRequisitionRow.Status = oSelectedRequisitionRow.Status.ToString();
            oRequisitionRow.Remarks = oSelectedRequisitionRow.Remarks;
            oRequisitionRow.StockTranID = oSelectedRequisitionRow.StockTranID.ToString();

            oDSRequisition.Requisition.AddRequisitionRow(oRequisitionRow);
            oDSRequisition.AcceptChanges();

            if (int.Parse(oDSRequisition.Requisition[0].Status) == (int)Dictionary.ProductRequisitionStatus.Transfer_Out || int.Parse(oDSRequisition.Requisition[0].Status) == (int)Dictionary.ProductRequisitionStatus.Transfer_Received)
            {
                oDSProductTransaction = new DSProductTransaction();

                oService = new Service();
                try
                {
                    oDSProductTransaction = oService.GetProductTransaction(oDSProductTransaction, int.Parse(oDSRequisition.Requisition[0].StockTranID), Utility.EmployeeID);
                }
                catch
                {
                    MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                rptGoodsTransferNoteAutoNote doc;
                doc = new rptGoodsTransferNoteAutoNote();
                //oDSUser = BOUtility.CurrentUser;

                frmPrintPreview frmView;
                frmView = new frmPrintPreview();              
                doc.SetDataSource(oDSProductTransaction);              
                frmView.ShowDialog(doc);
              
                rptGoodsTransferBarcode doc1;
                doc1 = new rptGoodsTransferBarcode();
              
                frmView = new frmPrintPreview();
                doc1.SetDataSource(oDSProductTransaction);
                frmView.ShowDialog(doc1);

                foreach (DSProductTransaction.DutyTranRow oDutyTranRow in oDSProductTransaction.DutyTran)
                {
                    if (oDutyTranRow.ChallanTypeID == (int)Dictionary.ChallanType.VAT_11)
                    {
                        CJ.Class.Duty.DutyTran oDutyTran = new CJ.Class.Duty.DutyTran();
                        foreach (DSProductTransaction.DutyTranDetailRow oDutyTranDetailRow in oDSProductTransaction.DutyTranDetail)
                        {
                            if (oDutyTranDetailRow.DutyTranID == oDutyTranRow.DutyTranID)
                            {
                                CJ.Class.Duty.DutyTranDetail oDutyTranDetail = new CJ.Class.Duty.DutyTranDetail();

                                oDutyTranDetail.ProductID = oDutyTranDetailRow.ProductID;
                                oDutyTranDetail.ProductName = oDutyTranDetailRow.ProductName;
                                oDutyTranDetail.Qty = oDutyTranDetailRow.Qty;
                                oDutyTranDetail.DutyPrice = oDutyTranDetailRow.DutyPrice;
                                oDutyTranDetail.DutyRate = oDutyTranDetailRow.DutyRate;

                                oDutyTran.Add(oDutyTranDetail);
                            }
                        }
                        if (oDutyTran.Count > 0)
                        {
                            CrystalDecisions.CrystalReports.Engine.ReportClass VatChallan11doc = ReportFactory.GetReport(typeof(rptTransferVatChallan11));
                            VatChallan11doc.SetDataSource(oDutyTran);

                            VatChallan11doc.SetParameterValue("CustomerName", oDutyTranRow.WarehouseName);
                            VatChallan11doc.SetParameterValue("CustomerAddress", oDutyTranRow.WarehouseAddress);
                            VatChallan11doc.SetParameterValue("InvoiceNo", oDutyTranRow.DutyTranNo);
                            VatChallan11doc.SetParameterValue("VatchalanNo", oDutyTranRow.DutyTranNo);
                            VatChallan11doc.SetParameterValue("DaliveryDate", oDutyTranRow.DutyTranDate.ToString("dd-MMM-yyyy"));
                            VatChallan11doc.SetParameterValue("DaliveryTime", oDutyTranRow.DutyTranDate.ToShortTimeString());

                            VatChallan11doc.SetParameterValue("Copy", "1st Copy");
                            VatChallan11doc.PrintToPrinter(1, true, 1, 1);
                            VatChallan11doc.SetParameterValue("Copy", "2nd Copy");
                            VatChallan11doc.PrintToPrinter(1, true, 1, 1);
                            VatChallan11doc.SetParameterValue("Copy", "3rd Copy");
                            VatChallan11doc.PrintToPrinter(1, true, 1, 1);
                        }
                    }
                    if (oDutyTranRow.ChallanTypeID == (int)Dictionary.ChallanType.VAT_11_KA)
                    {
                        CJ.Class.Duty.DutyTran oDutyTran = new CJ.Class.Duty.DutyTran();
                        foreach (DSProductTransaction.DutyTranDetailRow oDutyTranDetailRow in oDSProductTransaction.DutyTranDetail)
                        {
                            if (oDutyTranDetailRow.DutyTranID == oDutyTranRow.DutyTranID)
                            {
                                CJ.Class.Duty.DutyTranDetail oDutyTranDetail = new CJ.Class.Duty.DutyTranDetail();

                                oDutyTranDetail.ProductID = oDutyTranDetailRow.ProductID;
                                oDutyTranDetail.ProductName = oDutyTranDetailRow.ProductName;
                                oDutyTranDetail.Qty = oDutyTranDetailRow.Qty;
                                oDutyTranDetail.DutyPrice = oDutyTranDetailRow.DutyPrice;
                                oDutyTranDetail.DutyRate = oDutyTranDetailRow.DutyRate;

                                oDutyTran.Add(oDutyTranDetail);
                            }
                        }
                        if (oDutyTran.Count > 0)
                        {
                            CrystalDecisions.CrystalReports.Engine.ReportClass VatChallan11KAdoc = ReportFactory.GetReport(typeof(rptTransferVatChallan11KA));
                            VatChallan11KAdoc.SetDataSource(oDutyTran);

                            VatChallan11KAdoc.SetParameterValue("CustomerName", oDutyTranRow.WarehouseName);
                            VatChallan11KAdoc.SetParameterValue("CustomerAddress", oDutyTranRow.WarehouseAddress);
                            VatChallan11KAdoc.SetParameterValue("InvoiceNo", oDutyTranRow.DutyTranNo);
                            VatChallan11KAdoc.SetParameterValue("VatchalanNo", oDutyTranRow.DutyTranNo);
                            VatChallan11KAdoc.SetParameterValue("DaliveryDate", oDutyTranRow.DutyTranDate.ToString("dd-MMM-yyyy"));
                            VatChallan11KAdoc.SetParameterValue("DaliveryTime", oDutyTranRow.DutyTranDate.ToShortTimeString());

                            VatChallan11KAdoc.SetParameterValue("Copy", "1st Copy");
                            VatChallan11KAdoc.PrintToPrinter(1, true, 1, 1);
                            VatChallan11KAdoc.SetParameterValue("Copy", "2nd Copy");
                            VatChallan11KAdoc.PrintToPrinter(1, true, 1, 1);
                            VatChallan11KAdoc.SetParameterValue("Copy", "3rd Copy");
                            VatChallan11KAdoc.PrintToPrinter(1, true, 1, 1);
                        }
                    }
                }

            }
            else MessageBox.Show("Transfer Out and Received requisition can be Print.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btAuthorizePrint_Click(object sender, EventArgs e)
        {            
            if (lvwOrderList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            oDSRequisition = new DSRequisition();
            DSRequisition.RequisitionRow oSelectedRequisitionRow = (DSRequisition.RequisitionRow)lvwOrderList.SelectedItems[0].Tag;

            DSRequisition.RequisitionRow oRequisitionRow = oDSRequisition.Requisition.NewRequisitionRow();
            oRequisitionRow.RequisitionID = oSelectedRequisitionRow.RequisitionID.ToString();
            oRequisitionRow.Status = oSelectedRequisitionRow.Status.ToString();
            oDSRequisition.Requisition.AddRequisitionRow(oRequisitionRow);
            oDSRequisition.AcceptChanges();

            if (int.Parse(oDSRequisition.Requisition[0].Status) == (int)Dictionary.ProductRequisitionStatus.Authorized || int.Parse(oDSRequisition.Requisition[0].Status) == (int)Dictionary.ProductRequisitionStatus.Transfer_Out || int.Parse(oDSRequisition.Requisition[0].Status) == (int)Dictionary.ProductRequisitionStatus.Transfer_Received)
            {               

                oService = new Service();
                try
                {
                    oDSRequisition = oService.AuthorizePrint(oDSRequisition);
                }
                catch
                {
                    MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                rptRequisitionAuthorize doc;
                doc = new rptRequisitionAuthorize();
                //oDSUser = BOUtility.CurrentUser;

                frmPrintPreview frmView;
                frmView = new frmPrintPreview();
                doc.SetDataSource(oDSRequisition);
                frmView.ShowDialog(doc);
            }
            else MessageBox.Show("Only Authoriez requisition can be Print.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
   
        }

               
        
    }

}
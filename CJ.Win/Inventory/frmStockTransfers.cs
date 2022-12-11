using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.Duty;
using CJ.Class.HR;
using CJ.Class.POS;
using CJ.Report.POS;
using CJ.Report;
using CJ.Win.Security;
using CJ.Class.Library;
using CJ.Class.Web.UI.Class;
using CJ.Win.Distribution;
using CJ.Class.Report;

namespace CJ.Win.Inventory
{
    public partial class frmStockTransfers : Form
    {
        ProductTransactions oProductTransactions;
        Warehouses oFromWarehouses;
        Warehouses oToWarehouses;
        Warehouse oWarehouse;
        Channel oChannel;
        DutyTranList oDutyTranList;
        DutyTran oDutyTran;
        DutyAccount oDutyAccount;
        ProductStock _oProductStock;
        ProductDetail _oProductDetail;
        DSProductTransaction oDSProductTransaction;
        TELLib oLib;
        ProductStockTranTypes _oProductStockTranTypes;
        DutyTran oDutyTranVAT11;
        DutyTran oDutyTranVAT11KA;


        int nFromParentWarehouse;
        int nToParentWarehouse;

        double _DutyLocalBalance = 0;
        double _DutyImportBalance = 0;
        int _nType = 0;


        public frmStockTransfers(int nType)
        {
            InitializeComponent();
            _nType = nType;
        }

        private void frmStockTransfers_Load(object sender, EventArgs e)
        {
            if (_nType == 2)
            {
                rdoStockIn.Checked = true;
            }

            LoadCmb();
            LoadData();
            updateSecurity();
            btnBarcode.Visible = false;
            if (_nType == 1)
            {
                btnAddAdjestment.Visible = false;
                btAdd.Visible = true;
                rdoStockIn.Visible = false;
                rdoStockOut.Visible = false;
                cmbTransferType.Visible = false;
                lblTransSide.Visible = false;
                lblTransferType.Visible = false;

            }
            else if (_nType == 2)
            {
                btnAddAdjestment.Visible = true;
                btAdd.Visible = false;
                rdoStockIn.Visible = true;
                rdoStockOut.Visible = true;
                cmbTransferType.Visible = true;
                lblTransSide.Visible = true;
                lblTransferType.Visible = true;

            }
            else if (_nType == 3)
            {
                btnAddAdjestment.Visible = false;
                btAdd.Visible = true;
                rdoStockIn.Visible = false;
                rdoStockOut.Visible = false;
                cmbTransferType.Visible = false;
                lblTransSide.Visible = false;
                lblTransferType.Visible = false;
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadcmbTransferType()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            int nTranSide = 0;
            if (rdoStockIn.Checked == true)
            {
                nTranSide = (int) Dictionary.TranSide.IN;
            }
            else
            {
                nTranSide = (int) Dictionary.TranSide.OUT;
            }

            cmbTransferType.Items.Clear();
            _oProductStockTranTypes = new ProductStockTranTypes();
            _oProductStockTranTypes.GetStockTranTypeByTranSide(nTranSide);
            cmbTransferType.Items.Add("<All>");
            foreach (ProductStockTranType oProductStockTranType in _oProductStockTranTypes)
            {
                cmbTransferType.Items.Add(oProductStockTranType.TranTypeName);
            }

            cmbTransferType.SelectedIndex = 0;
        }

        public void LoadCmb()
        {
            DBController.Instance.OpenNewConnection();
            cmbFromWH.Items.Clear();
            oFromWarehouses = new Warehouses();
            oFromWarehouses.GetAllWarehouseNew();
            foreach (Warehouse oWarehouse in oFromWarehouses)
            {
                cmbFromWH.Items.Add(oWarehouse.WarehouseDetail);
            }

            cmbFromWH.SelectedIndex = oFromWarehouses.Count - 1;

            cmbToWH.Items.Clear();
            oToWarehouses = new Warehouses();
            oToWarehouses.GetAllWarehouseNew();
            foreach (Warehouse oWarehouse in oToWarehouses)
            {
                cmbToWH.Items.Add(oWarehouse.WarehouseDetail);
            }

            cmbToWH.SelectedIndex = oToWarehouses.Count - 1;
        }

        public void LoadData()
        {
            DBController.Instance.OpenNewConnection();
            int nTranTypeID = -1;
            int nTranSide = -1;
            if (_nType == 2)
            {
                if (cmbTransferType.SelectedIndex != 0)
                {
                    nTranTypeID = _oProductStockTranTypes[cmbTransferType.SelectedIndex - 1].TranTypeID;
                }

                if (rdoStockIn.Checked == true)
                {
                    nTranSide = (int) Dictionary.TranSide.IN;
                }
                else
                {
                    nTranSide = (int) Dictionary.TranSide.OUT;
                }
            }

            oProductTransactions = new ProductTransactions();
            oProductTransactions.GetTransaction(dtFromDate.Value.Date, dtToDate.Value.Date, txtTranNo.Text,
                oFromWarehouses[cmbFromWH.SelectedIndex].WarehouseID, oToWarehouses[cmbToWH.SelectedIndex].WarehouseID,
                _nType, nTranTypeID, nTranSide);

            lvwStockList.Items.Clear();
            foreach (ProductTransaction oProductTransaction in oProductTransactions)
            {
                ListViewItem lstItem = lvwStockList.Items.Add(oProductTransaction.TranNo);
                lstItem.SubItems.Add(oProductTransaction.TranDate.ToString("dd-MMM-yyyy"));
                lstItem.SubItems.Add(oProductTransaction.FromWHName);
                lstItem.SubItems.Add(oProductTransaction.ToWHName);
                lstItem.SubItems.Add(oProductTransaction.TransactionSide);
                lstItem.SubItems.Add(oProductTransaction.TranTypeName);
                lstItem.SubItems.Add(oProductTransaction.Remarks);
                lstItem.Tag = oProductTransaction;
            }

            this.Text = "Total Transfer  " + "[" + oProductTransactions.Count + "]";
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            frmStockTransfer ofrmStockTransfer = new frmStockTransfer(_nType); ///Transfer
            ofrmStockTransfer.ShowDialog();
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (lvwStockList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProductTransaction oProductTransaction = (ProductTransaction) lvwStockList.SelectedItems[0].Tag;
            DialogResult oResult =
                MessageBox.Show("Are you sure you want to delete transaction: " + oProductTransaction.TranNo + " ? ",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                oProductTransaction.RefreshItem();
                _DutyLocalBalance = 0;
                _DutyImportBalance = 0;
                oDutyTranList = new DutyTranList();
                oDutyTranList.GetTranID(oProductTransaction.TranID.ToString(), oProductTransaction.TranNo,
                    oProductTransaction.FromWHID);

                try
                {
                    DBController.Instance.BeginNewTransaction();

                    ProductTransactionDetail oProductTransactionDetail = new ProductTransactionDetail();
                    oProductTransactionDetail.TranID = oProductTransaction.TranID;
                    oProductTransactionDetail.Delete();
                    oProductTransaction.Delete();

                    foreach (DutyTran oDutyTran in oDutyTranList)
                    {
                        foreach (DutyTranDetail _oDutyTranDetail in oDutyTran)
                        {
                            if (oDutyTran.ChallanTypeID == (int) Dictionary.ChallanType.VAT_11_KA)
                                _DutyLocalBalance = _DutyLocalBalance + _oDutyTranDetail.DutyPrice *
                                    _oDutyTranDetail.Qty * _oDutyTranDetail.DutyRate;
                            if (oDutyTran.ChallanTypeID == (int) Dictionary.ChallanType.VAT_11)
                                _DutyImportBalance = _DutyImportBalance + _oDutyTranDetail.DutyPrice *
                                    _oDutyTranDetail.Qty * _oDutyTranDetail.DutyRate;

                        }

                        DutyTranDetail oDutyTranDetail = new DutyTranDetail();
                        oDutyTranDetail.DutyTranID = oDutyTran.DutyTranID;
                        oDutyTranDetail.Delete();
                        oDutyTran.Delete();
                    }

                    oDutyAccount = new DutyAccount();
                    oDutyAccount.DutyAccountTypeID = (int) Dictionary.SupplyType.LOCAL;
                    oDutyAccount.Balance = _DutyLocalBalance;
                    oDutyAccount.UpdateBalance(false);

                    oDutyAccount = new DutyAccount();
                    oDutyAccount.DutyAccountTypeID = (int) Dictionary.SupplyType.IMPORTED;
                    oDutyAccount.Balance = _DutyImportBalance;
                    oDutyAccount.UpdateBalance(false);

                    foreach (ProductTransactionDetail oItem in oProductTransaction)
                    {
                        _oProductStock = new ProductStock();
                        _oProductStock.WarehouseID = oProductTransaction.FromWHID;
                        _oProductStock.ChannelID = oProductTransaction.FromChannelID;
                        _oProductStock.Quantity = oItem.Qty;
                        _oProductStock.ProductID = oItem.ProductID;
                        _oProductStock.UpdateCurrentStock(true);
                        if (_oProductStock.Flag == false)
                        {
                            DBController.Instance.RollbackTransaction();
                            MessageBox.Show("Stock error... ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        _oProductStock = new ProductStock();
                        _oProductStock.WarehouseID = oProductTransaction.ToWHID;
                        _oProductStock.ChannelID = oProductTransaction.ToChannelID;
                        _oProductStock.Quantity = oItem.Qty;
                        _oProductStock.ProductID = oItem.ProductID;
                        _oProductStock.UpdateCurrentStock(false);
                        if (_oProductStock.Flag == false)
                        {
                            DBController.Instance.RollbackTransaction();
                            MessageBox.Show("Stock error... ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Delete this transaction- " + oProductTransaction.TranNo,
                        "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error... " + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
        }

        private void btnPrintTransaction_Click(object sender, EventArgs e)
        {
            if (lvwStockList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProductTransaction oProductTransaction = (ProductTransaction) lvwStockList.SelectedItems[0].Tag;
            oDSProductTransaction = new DSProductTransaction();
            oDSProductTransaction = oProductTransaction.ProductStockTransferReport(oDSProductTransaction);

            rptGoodsTransferNoteAutoNote doc;
            doc = new rptGoodsTransferNoteAutoNote();
            doc.SetDataSource(oDSProductTransaction);
            rptProductTransaction orptProductTransaction = new rptProductTransaction();
            doc.SetParameterValue("NoOfBarcode", orptProductTransaction.CountTranBarcode(oProductTransaction.TranID));

            doc.PrintToPrinter(1, true, 1, 4);
            // btPrintVAT_Click(null,null);


        }

        private void updateSecurity()
        {
            Users oUsers = new Users();
            Permission oPermission = new Permission();
            DSPermission _oDsPermission = oPermission.getPermissionList();
            btnPrintTransaction.Enabled = true;

            DataRow[] oPermitedRow =
                _oDsPermission.Permission.Select("MenuType >= '" + (short) Dictionary.MenuType.Buttton + "'");

            foreach (DataRow oRow in oPermitedRow)
            {
                string sPermissionKey = oUsers.checkOtherPermission(oRow["PermissionKey"].ToString(), Utility.UserId);
                if (sPermissionKey != null)
                {
                    if ("M1.20" == sPermissionKey)
                    {
                        btndelete.Enabled = true;
                    }

                }
            }

        }

        private void btPrintVAT_Click(object sender, EventArgs e)
        {
            DBController.Instance.OpenNewConnection();
            if (lvwStockList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProductTransaction oProductTransaction = (ProductTransaction) lvwStockList.SelectedItems[0].Tag;
            ShipmentVehicle oShipmentVehicle = new ShipmentVehicle();
            bool _IsVehicleAssign = oShipmentVehicle.IsVehicleAssign(oProductTransaction.TranID, "Challan");
            if (_IsVehicleAssign != true)
            {
                MessageBox.Show("Please assign vehicle first.", "Warning", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (lvwStockList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            oDutyTranList = new DutyTranList();
            oDutyTranList.GetTranID(oProductTransaction.TranID.ToString(), oProductTransaction.TranNo,
                oProductTransaction.FromWHID);
            SystemInfo oInfo = new SystemInfo();
            oInfo.RefreshHO();

            foreach (DutyTran oDutyTran in oDutyTranList)
            {
                int nTotal = 0;
                oDutyTran.GetVATReport();
                SystemInfo oSystemInfo = new SystemInfo();
                oSystemInfo.RefreshHO();
                if (oDutyTran.ChallanTypeID == (int) Dictionary.ChallanType.VAT_11)
                {
                    CrystalDecisions.CrystalReports.Engine.ReportClass doc =
                        ReportFactory.GetReport(typeof(rptTransferVatChallan11));
                    doc.SetDataSource(oDutyTran);



                    //doc.SetParameterValue("CustomerName", oWarehouse.WarehouseName);
                    //doc.SetParameterValue("CustomerAddress", oJobLocation.Description);
                    //doc.SetParameterValue("InvoiceNo", oProductTransaction.TranNo);
                    //doc.SetParameterValue("VatchalanNo", oDutyTran.DutyTranNo);
                    //doc.SetParameterValue("DaliveryDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                    //doc.SetParameterValue("DaliveryDateInWord", DateTimeConversion.DateTimeToText(oDutyTran.DutyTranDate, true, false));
                    //doc.SetParameterValue("DaliveryTime", oDutyTran.DutyTranDate.ToShortTimeString());
                    //doc.SetParameterValue("VATRegistrationNo", oSystemInfo.VATRegistrationNo);
                    //doc.SetParameterValue("ActualDeliveryDateTime", oDutyTran.DutyTranDate);
                    //string sdateTimeInWord = DateTimeConversion.DateTimeToText(oDutyTran.DutyTranDate, true, false);
                    //doc.SetParameterValue("DateTimeInWord", sdateTimeInWord.ToString());
                    //ShipmentVehicle oVehicle = new ShipmentVehicle();
                    //oVehicle.GetVehicleNo(oProductTransaction.TranID, oDutyTran.DutyTranID);
                    //doc.SetParameterValue("VehicleNo", oVehicle.VehicleNo);
                    //if (Utility.CompanyInfo == "BLL")
                    //{
                    //    doc.SetParameterValue("IsBLL", true);
                    //}
                    //else
                    //{
                    //    doc.SetParameterValue("IsBLL", false);
                    //}

                    //doc.SetParameterValue("16(1)", "[ wewa-16 (1) `ªóe¨ ]");
                    //foreach (DutyTranDetail oDutyTranDetail in oDutyTran)
                    //{
                    //    nTotal = nTotal + oDutyTranDetail.Qty;
                    //}
                    //oLib = new TELLib();
                    //doc.SetParameterValue("TotalText", oLib.changeNumericToWords(nTotal) + " Pcs");

                    //doc.SetParameterValue("Copy", "cÖ_g Kwc");
                    //doc.PrintToPrinter(1, true, 1, 1);
                    //doc.SetParameterValue("Copy", "wØZxq Kwc");
                    //doc.PrintToPrinter(1, true, 1, 1);
                    //doc.SetParameterValue("Copy", "Z…Zxq Kwc");
                    //doc.PrintToPrinter(1, true, 1, 1);

                    ///////////////////////
                    oWarehouse = new Warehouse();
                    oWarehouse.WarehouseID = oProductTransaction.ToWHID;
                    oWarehouse.Reresh();
                    JobLocation oJobLocation = new JobLocation();
                    oJobLocation.JobLocationID = oWarehouse.LocationID;
                    oJobLocation.Refresh();
                    doc.SetParameterValue("WarehouseAddress", oInfo.Address);
                    doc.SetParameterValue("CustomerName", oWarehouse.WarehouseName);
                    doc.SetParameterValue("CustomerAddress", oJobLocation.Description);
                    doc.SetParameterValue("DeliveryAddress", oJobLocation.Description);
                    doc.SetParameterValue("TAXNo", "");
                    doc.SetParameterValue("CustomerAddress", oJobLocation.Description);
                    doc.SetParameterValue("InvoiceNo", oProductTransaction.TranNo);
                    doc.SetParameterValue("VatchalanNo", oDutyTran.DutyTranNo);
                    doc.SetParameterValue("DaliveryDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                    doc.SetParameterValue("DaliveryTime", oDutyTran.DutyTranDate.ToShortTimeString());
                    doc.SetParameterValue("DaliveryDateInWord",
                        DateTimeConversion.DateTimeToText(oDutyTran.DutyTranDate, true, false));
                    doc.SetParameterValue("VATRegistrationNo", oSystemInfo.VATRegistrationNo);
                    doc.SetParameterValue("ActualDeliveryDateTime", oDutyTran.DutyTranDate);
                    string sdateTimeInWord = DateTimeConversion.DateTimeToText(oDutyTran.DutyTranDate, true, false);
                    doc.SetParameterValue("DateTimeInWord", sdateTimeInWord.ToString());
                    ShipmentVehicle oVehicle = new ShipmentVehicle();
                    oVehicle.GetVehicleNo(oProductTransaction.TranID, oDutyTran.DutyTranID);
                    doc.SetParameterValue("VehicleNo", oVehicle.VehicleNo);


                    doc.SetParameterValue("16(1)", "[ wewa-16 (1) `ªóe¨ ]");
                    if (Utility.CompanyInfo == "BLL")
                    {
                        doc.SetParameterValue("IsBLL", true);
                    }
                    else
                    {
                        doc.SetParameterValue("IsBLL", false);
                    }

                    foreach (DutyTranDetail oDutyTranDetail in oDutyTran)
                    {
                        nTotal = nTotal + oDutyTranDetail.Qty;
                    }

                    TELLib oLib = new TELLib();
                    doc.SetParameterValue("TotalText", oLib.changeNumericToWords(nTotal) + " Pcs");

                    doc.SetParameterValue("Copy", "cÖ_g Kwc");
                    doc.PrintToPrinter(1, true, 1, 1);
                    doc.SetParameterValue("Copy", "wØZxq Kwc");
                    doc.PrintToPrinter(1, true, 1, 1);
                    doc.SetParameterValue("Copy", "Z…Zxq Kwc");
                    doc.PrintToPrinter(1, true, 1, 1);

                }

                if (oDutyTran.ChallanTypeID == (int) Dictionary.ChallanType.VAT_11_KA)
                {
                    CrystalDecisions.CrystalReports.Engine.ReportClass doc =
                        ReportFactory.GetReport(typeof(rptTransferVatChallan11KA));
                    doc.SetDataSource(oDutyTran);

                    oWarehouse = new Warehouse();
                    oWarehouse.WarehouseID = oProductTransaction.ToWHID;
                    oWarehouse.Reresh();
                    JobLocation oJobLocation = new JobLocation();
                    oJobLocation.JobLocationID = oWarehouse.LocationID;
                    oJobLocation.Refresh();
                    doc.SetParameterValue("WarehouseAddress", oInfo.Address);
                    doc.SetParameterValue("CustomerName", oWarehouse.WarehouseName);
                    doc.SetParameterValue("CustomerAddress", oJobLocation.Description);
                    doc.SetParameterValue("InvoiceNo", oProductTransaction.TranNo);
                    doc.SetParameterValue("VatchalanNo", oDutyTran.DutyTranNo);
                    doc.SetParameterValue("DaliveryDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                    doc.SetParameterValue("DaliveryTime", oDutyTran.DutyTranDate.ToShortTimeString());
                    doc.SetParameterValue("VATRegistrationNo", oSystemInfo.VATRegistrationNo);
                    ShipmentVehicle oVehicle = new ShipmentVehicle();
                    oVehicle.GetVehicleNo(oProductTransaction.TranID, oDutyTran.DutyTranID);
                    doc.SetParameterValue("VehicleNo", oVehicle.VehicleNo);

                    doc.SetParameterValue("Copy", "1st Copy");
                    doc.PrintToPrinter(1, true, 1, 1);
                    doc.SetParameterValue("Copy", "2nd Copy");
                    doc.PrintToPrinter(1, true, 1, 1);
                    doc.SetParameterValue("Copy", "3rd Copy");
                    doc.PrintToPrinter(1, true, 1, 1);
                }

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btProcessVAT_Click(object sender, EventArgs e)
        {
            if (lvwStockList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProductTransaction oProductTransaction = (ProductTransaction) lvwStockList.SelectedItems[0].Tag;
            oDutyTranList = new DutyTranList();
            //////////
            oWarehouse = new Warehouse();
            oWarehouse.WarehouseID = oProductTransaction.FromWHID;
            oWarehouse.Reresh();
            nFromParentWarehouse = oWarehouse.WarehouseParentID;

            oWarehouse = new Warehouse();
            oWarehouse.WarehouseID = oProductTransaction.ToWHID;
            oWarehouse.Reresh();
            nToParentWarehouse = oWarehouse.WarehouseParentID;

            if (nFromParentWarehouse == Utility.HOID &&
                (nToParentWarehouse == Utility.HOID || nToParentWarehouse == Utility.TDEPSEzeeBuy))
            {
                MessageBox.Show("No Need to VAT process", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                /////////
                oDutyTranList.GetTranID(oProductTransaction.TranID.ToString(), oProductTransaction.TranNo,
                    oProductTransaction.FromWHID);
                if (oDutyTranList.Count == 0)
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        _DutyImportBalance = 0;
                        _DutyLocalBalance = 0;

                        oDutyTranVAT11KA = GetDataForVAT11KA(oDutyTranVAT11KA, oProductTransaction);
                        oDutyTranVAT11 = GetDataForVAT11(oDutyTranVAT11, oProductTransaction);

                        if (oDutyTranVAT11.Count > 0)
                        {
                            oDutyTranVAT11.Insert();
                        }

                        if (oDutyTranVAT11KA.Count > 0)
                        {
                            oDutyTranVAT11KA.Insert();
                        }

                        oDutyAccount = new DutyAccount();
                        oDutyAccount.DutyAccountTypeID = (int) Dictionary.SupplyType.LOCAL;
                        oDutyAccount.Balance = _DutyLocalBalance;
                        oDutyAccount.UpdateBalance(true);

                        oDutyAccount = new DutyAccount();
                        oDutyAccount.DutyAccountTypeID = (int) Dictionary.SupplyType.IMPORTED;
                        oDutyAccount.Balance = _DutyImportBalance;
                        oDutyAccount.UpdateBalance(true);

                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("You Have Successfully VAT Process.", "Save", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        LoadData();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show("error... " + ex.ToString(), "Error", MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("This Transaction already process", "Warning", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
            }

        }

        ///
        //  For VAT 11 KA
        ///
        public DutyTran GetDataForVAT11KA(DutyTran oDutyTranVAT11KA, ProductTransaction oProductTransaction)
        {
            oDutyTranVAT11KA = new DutyTran();
            oProductTransaction.RefreshItem();

            oDutyTranVAT11KA.DutyTranDate = DateTime.Now;
            oDutyTranVAT11KA.WHID = oProductTransaction.FromWHID;
            oDutyTranVAT11KA.ChallanTypeID = (int) Dictionary.ChallanType.VAT_11_KA;
            oDutyTranVAT11KA.DutyTypeID = (int) Dictionary.DutyType.VAT;
            oDutyTranVAT11KA.DocumentNo = oProductTransaction.TranNo;
            oDutyTranVAT11KA.RefID = oProductTransaction.TranID;
            oDutyTranVAT11KA.DutyTranTypeID = (int) Dictionary.DutyTranType.TRANSFER;
            oDutyTranVAT11KA.Remarks = oProductTransaction.Remarks;
            oDutyTranVAT11KA.DutyAccountID = (int) Dictionary.SupplyType.LOCAL;

            foreach (ProductTransactionDetail oItem in oProductTransaction)
            {
                _oProductDetail = new ProductDetail();
                _oProductDetail.ProductID = oItem.ProductID;
                _oProductDetail.Refresh();
                if (_oProductDetail.SupplyType == (int) Dictionary.SupplyType.LOCAL)
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();

                    oDutyTranDetail.ProductID = oItem.ProductID;
                    oDutyTranDetail.Qty = (int) oItem.Qty;


                    CustomerDetail oCustomerDetail = new CustomerDetail();
                    oProductTransaction = new ProductTransaction();
                    oCustomerDetail.RefreshChannel(oProductTransaction.FromChannelID);

                    if (oCustomerDetail.ChannelType == (int) Dictionary.ChannelType.DISTRIBUTION)
                    {
                        oDutyTranDetail.DutyPrice = Math.Round(_oProductDetail.NSP / (1 + _oProductDetail.Vat), 2,
                            MidpointRounding.AwayFromZero);
                        oDutyTranDetail.DutyRate = _oProductDetail.Vat;
                    }
                    else
                    {
                        TPVATProduct _oTPVATProduct = new TPVATProduct();
                        if (_oTPVATProduct.IsProductExists(oItem.ProductID))
                        {
                            oDutyTranDetail.DutyPrice = _oTPVATProduct.TradePrice;
                        }
                        else
                        {
                            oDutyTranDetail.DutyPrice = Math.Round(_oProductDetail.RSP / (1 + _oProductDetail.Vat), 2,
                                MidpointRounding.AwayFromZero);
                        }

                        oDutyTranDetail.DutyRate = _oProductDetail.Vat;
                    }

                    _DutyLocalBalance = _DutyLocalBalance +
                                        oDutyTranDetail.DutyPrice * oDutyTranDetail.Qty * oDutyTranDetail.DutyRate;

                    oDutyTranVAT11KA.Add(oDutyTranDetail);
                }
            }

            oDutyTranVAT11KA.Amount = _DutyLocalBalance;

            return oDutyTranVAT11KA;
        }

        ///
        //  For VAT 11 
        ///
        public DutyTran GetDataForVAT11(DutyTran oDutyTranVAT11, ProductTransaction oProductTransaction)
        {
            oDutyTranVAT11 = new DutyTran();
            oProductTransaction.RefreshItem();

            oDutyTranVAT11.DutyTranDate = DateTime.Now;
            oDutyTranVAT11.WHID = oProductTransaction.FromWHID;
            oDutyTranVAT11.ChallanTypeID = (int) Dictionary.ChallanType.VAT_11;
            oDutyTranVAT11.DutyTypeID = (int) Dictionary.DutyType.VAT;
            oDutyTranVAT11.DocumentNo = oProductTransaction.TranNo;
            oDutyTranVAT11.RefID = oProductTransaction.TranID;
            oDutyTranVAT11.DutyTranTypeID = (int) Dictionary.DutyTranType.TRANSFER;
            oDutyTranVAT11.Remarks = oProductTransaction.Remarks;
            oDutyTranVAT11.DutyAccountID = (int) Dictionary.SupplyType.IMPORTED;

            foreach (ProductTransactionDetail oItem in oProductTransaction)
            {
                _oProductDetail = new ProductDetail();
                _oProductDetail.ProductID = oItem.ProductID;
                _oProductDetail.Refresh();
                if (_oProductDetail.SupplyType == (int) Dictionary.SupplyType.IMPORTED)
                {
                    DutyTranDetail oDutyTranDetail = new DutyTranDetail();

                    oDutyTranDetail.ProductID = oItem.ProductID;
                    oDutyTranDetail.Qty = (int) oItem.Qty;


                    CustomerDetail oCustomerDetail = new CustomerDetail();
                    oProductTransaction = new ProductTransaction();
                    oCustomerDetail.ChannelID = oProductTransaction.FromChannelID;
                    oCustomerDetail.RefreshChannel(oProductTransaction.FromChannelID);

                    if (oCustomerDetail.ChannelType == (int) Dictionary.ChannelType.DISTRIBUTION)
                    {
                        oDutyTranDetail.DutyPrice = Math.Round(_oProductDetail.NSP / (1 + _oProductDetail.Vat), 2,
                            MidpointRounding.AwayFromZero);
                        oDutyTranDetail.DutyRate = _oProductDetail.Vat;
                    }
                    else
                    {
                        TPVATProduct _oTPVATProduct = new TPVATProduct();
                        if (_oTPVATProduct.IsProductExists(oItem.ProductID))
                        {
                            oDutyTranDetail.DutyPrice = _oTPVATProduct.TradePrice;
                        }
                        else
                        {
                            oDutyTranDetail.DutyPrice = Math.Round(_oProductDetail.RSP / (1 + _oProductDetail.Vat), 2,
                                MidpointRounding.AwayFromZero);
                        }

                        oDutyTranDetail.DutyRate = _oProductDetail.Vat;
                    }

                    _DutyImportBalance = _DutyImportBalance +
                                         oDutyTranDetail.DutyPrice * oDutyTranDetail.Qty * oDutyTranDetail.DutyRate;

                    oDutyTranVAT11.Add(oDutyTranDetail);
                }
            }

            oDutyTranVAT11.Amount = _DutyImportBalance;

            return oDutyTranVAT11;
        }

        private void btnBarcode_Click(object sender, EventArgs e)
        {
            if (lvwStockList.SelectedItems.Count != 0)
            {
                ProductTransaction _oProductTransaction = (ProductTransaction) lvwStockList.SelectedItems[0].Tag;

                ProductTransferProductSerial oProductTransferProductSerial = new ProductTransferProductSerial();
                oProductTransferProductSerial.TranID = _oProductTransaction.TranID;

                oProductTransferProductSerial.RefreshByTranID(_oProductTransaction.TranID);

                frmProductTransferProductSerial oForm = new frmProductTransferProductSerial();

                oForm.ShowDialog(oProductTransferProductSerial);

            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnTransferSerial_Click(object sender, EventArgs e)
        {
            frmTransactionalSerialUploader oForm = new frmTransactionalSerialUploader();
            oForm.ShowDialog();

        }

        private void btnAddAdjestment_Click(object sender, EventArgs e)
        {
            frmStockTransfer ofrmStockTransfer = new frmStockTransfer(_nType); ///Adjestment
            ofrmStockTransfer.ShowDialog();
            LoadData();
        }

        private void rdoStockIn_CheckedChanged(object sender, EventArgs e)
        {
            LoadcmbTransferType();
        }

        private void rdoStockOut_CheckedChanged(object sender, EventArgs e)
        {
            LoadcmbTransferType();
        }

        private void PrintVat()
        {
            if (lvwStockList.SelectedItems.Count == 0)
            {
                MessageBox.Show(@"Please Select a Row.", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SystemInfo oSystemInfo = new SystemInfo();
            oSystemInfo.RefreshHO();

            ProductTransaction oProductTransaction = (ProductTransaction) lvwStockList.SelectedItems[0].Tag;
            DutyTranList oDutyTranList = new DutyTranList();
            oDutyTranList.GetDutyTranHO(oProductTransaction.TranNo, (int) Dictionary.StockRequisitionType.Requisition,
                "No");
            // int nRequisitionType = _oPOSRequisition.RequisitionType;

            foreach (DutyTran oDutyTran in oDutyTranList)
            {

                if (!DBController.Instance.CheckConnection())
                {
                    DBController.Instance.OpenNewConnection();
                }

                DutyTran oIsVatExempted = new DutyTran();
                if (oIsVatExempted.CheckVatExemptedTransferHo(oDutyTran.DutyTranID, oDutyTran.WHID))
                {
                    POSRequisition oPosRequisition = new POSRequisition();
                    oPosRequisition.RefreshStockRequisitionNewByTranID(oDutyTran.RefID, oDutyTran.DutyTranID,
                        (int) Dictionary.StockRequisitionType.Requisition, "HO", "No", oDutyTran.DutyTranNo);
                    if (oSystemInfo.IsNewVat == 1 && oDutyTran.DutyTranDate.Date >=
                        Convert.ToDateTime(oSystemInfo.NewVatActivationDate))
                    {
                        CrystalDecisions.CrystalReports.Engine.ReportClass oReport =
                            ReportFactory.GetReport(typeof(rptNewMushak65_Exempted));

                        oReport.SetDataSource(oPosRequisition);
                        oReport.SetParameterValue("CentralRegisteredPersonAddress", oSystemInfo.CentralRegisteredPersonAddress);
                        oReport.SetParameterValue("RegisteredpersonBIN", oSystemInfo.VATRegistrationNo);
                        oReport.SetParameterValue("ChallanNo", oDutyTran.DutyTranNo);
                        oReport.SetParameterValue("ChallanDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                        oReport.SetParameterValue("ChallanTime", oDutyTran.DutyTranDate.ToShortTimeString());
                        oReport.SetParameterValue("FromWHName", oPosRequisition.FromWHName);
                        oReport.SetParameterValue("FromWHAddress", oPosRequisition.FromWHAddress);
                        oReport.SetParameterValue("ToWHName", oPosRequisition.ToWHName);
                        oReport.SetParameterValue("ToWHAddress", oPosRequisition.ToWHAddress);
                        oReport.SetParameterValue("VehicleNumber", oDutyTran.VehicleDetail.ToString());
                        //oReport.PrintToPrinter(3, true, 1, 1);
                        frmPrintPreview oFrom = new frmPrintPreview();

                        oFrom.ShowDialog(oReport);
                        this.Cursor = Cursors.Default;

                    }
                    else
                    {
                        CrystalDecisions.CrystalReports.Engine.ReportClass oReport =
                            ReportFactory.GetReport(typeof(rptMushak65_Exempted));
                        oReport.SetDataSource(oPosRequisition);
                        oReport.SetParameterValue("RegisteredpersonBIN", oSystemInfo.VATRegistrationNo);
                        oReport.SetParameterValue("ChallanNo", oDutyTran.DutyTranNo);
                        oReport.SetParameterValue("ChallanDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                        oReport.SetParameterValue("ChallanTime", oDutyTran.DutyTranDate.ToShortTimeString());
                        oReport.SetParameterValue("FromWHName", oPosRequisition.FromWHName);
                        oReport.SetParameterValue("FromWHAddress", oPosRequisition.FromWHAddress);
                        oReport.SetParameterValue("ToWHName", oPosRequisition.ToWHName);
                        oReport.SetParameterValue("ToWHAddress", oPosRequisition.ToWHAddress);
                        // oReport.PrintToPrinter(3, true, 1, 1);
                        frmPrintPreview oFrom = new frmPrintPreview();

                        oFrom.ShowDialog(oReport);
                        this.Cursor = Cursors.Default;

                    }
                }
                else
                {
                    POSRequisition oPosRequisition = new POSRequisition();
                    oPosRequisition.RefreshStockRequisitionNewByTranID(oDutyTran.RefID, oDutyTran.DutyTranID,
                        (int) Dictionary.StockRequisitionType.Requisition, "HO", "No", oDutyTran.DutyTranNo);
                    if (oSystemInfo.IsNewVat == 1 && oDutyTran.DutyTranDate.Date >=
                        Convert.ToDateTime(oSystemInfo.NewVatActivationDate))
                    {
                        CrystalDecisions.CrystalReports.Engine.ReportClass oReport =
                            ReportFactory.GetReport(typeof(rptNewMushak65));
                        oReport.SetDataSource(oPosRequisition);
                        oReport.SetParameterValue("CentralRegisteredPersonAddress", oSystemInfo.CentralRegisteredPersonAddress);
                        oReport.SetParameterValue("RegisteredpersonBIN", oSystemInfo.VATRegistrationNo);
                        oReport.SetParameterValue("ChallanNo", oDutyTran.DutyTranNo);
                        oReport.SetParameterValue("ChallanDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                        oReport.SetParameterValue("ChallanTime", oDutyTran.DutyTranDate.ToShortTimeString());
                        oReport.SetParameterValue("FromWHName", oPosRequisition.FromWHName);
                        oReport.SetParameterValue("FromWHAddress", oPosRequisition.FromWHAddress);
                        oReport.SetParameterValue("ToWHName", oPosRequisition.ToWHName);
                        oReport.SetParameterValue("ToWHAddress", oPosRequisition.ToWHAddress);
                        oReport.SetParameterValue("VehicleNumber", oDutyTran.VehicleDetail.ToString());
                        //oReport.PrintToPrinter(3, true, 1, 1);
                        frmPrintPreview oFrom = new frmPrintPreview();

                        oFrom.ShowDialog(oReport);
                        this.Cursor = Cursors.Default;
                    }
                    else
                    {
                        CrystalDecisions.CrystalReports.Engine.ReportClass oReport =
                            ReportFactory.GetReport(typeof(rptMushak65));
                        oReport.SetDataSource(oPosRequisition);
                        oReport.SetParameterValue("RegisteredpersonBIN", oSystemInfo.VATRegistrationNo);
                        oReport.SetParameterValue("ChallanNo", oDutyTran.DutyTranNo);
                        oReport.SetParameterValue("ChallanDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
                        oReport.SetParameterValue("ChallanTime", oDutyTran.DutyTranDate.ToShortTimeString());
                        oReport.SetParameterValue("FromWHName", oPosRequisition.FromWHName);
                        oReport.SetParameterValue("FromWHAddress", oPosRequisition.FromWHAddress);
                        oReport.SetParameterValue("ToWHName", oPosRequisition.ToWHName);
                        oReport.SetParameterValue("ToWHAddress", oPosRequisition.ToWHAddress);
                        //oReport.PrintToPrinter(3, true, 1, 1);
                        frmPrintPreview oFrom = new frmPrintPreview();

                        oFrom.ShowDialog(oReport);

                    }

                }
            }

        }

        private void btnVATPrint_Click(object sender, EventArgs e)
        {
            //if (lvwStockList.SelectedItems.Count == 0)
            //{
            //    MessageBox.Show("Please Select a Row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //this.Cursor = Cursors.WaitCursor;
            //ProductTransaction oProductTransaction = (ProductTransaction)lvwStockList.SelectedItems[0].Tag;
            //DutyTranList oDutyTranList = new DutyTranList();
            //oDutyTranList.GetDutyTranHO(oProductTransaction.TranNo, (int)Dictionary.StockRequisitionType.Requisition, "No");
            //int nRequisitionType = (int)Dictionary.StockRequisitionType.Requisition;
            //foreach (DutyTran oDutyTran in oDutyTranList)
            //{
            //    if (!DBController.Instance.CheckConnection())
            //    {
            //        DBController.Instance.OpenNewConnection();
            //    }

            //    DutyTran oIsVatExempted = new DutyTran();
            //    if (oIsVatExempted.CheckVatExemptedTransferHo(oDutyTran.DutyTranID, oDutyTran.WHID))
            //    {
            //        POSRequisition _oPOSRequisition = new POSRequisition();
            //        _oPOSRequisition.RefreshStockTransferNewByTranID(oDutyTran.RefID, oDutyTran.DutyTranID, nRequisitionType);
            //        CrystalDecisions.CrystalReports.Engine.ReportClass oReport = ReportFactory.GetReport(typeof(rptNewMushak65_Exempted));
            //        oReport.SetDataSource(_oPOSRequisition);

            //        oReport.SetParameterValue("ChallanNo", oDutyTran.DutyTranNo);
            //        oReport.SetParameterValue("ChallanDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
            //        oReport.SetParameterValue("ChallanTime", oDutyTran.DutyTranDate.ToShortTimeString());
            //        oReport.SetParameterValue("FromWHName", _oPOSRequisition.FromWHName);
            //        oReport.SetParameterValue("FromWHAddress", _oPOSRequisition.FromWHAddress);
            //        oReport.SetParameterValue("ToWHName", _oPOSRequisition.ToWHName);
            //        oReport.SetParameterValue("ToWHAddress", _oPOSRequisition.ToWHAddress);
            //        oReport.SetParameterValue("VehicleNumber", oDutyTran.VehicleDetail);
            //        oReport.PrintToPrinter(1, true, 1, 1);
            //    }
            //    else
            //    {

            //        POSRequisition _oPOSRequisition = new POSRequisition();
            //        _oPOSRequisition.RefreshStockTransferNewByTranID(oDutyTran.RefID, oDutyTran.DutyTranID, nRequisitionType);
            //        CrystalDecisions.CrystalReports.Engine.ReportClass oReport = ReportFactory.GetReport(typeof(rptNewMushak65));
            //        oReport.SetDataSource(_oPOSRequisition);

            //        oReport.SetParameterValue("ChallanNo", oDutyTran.DutyTranNo);
            //        oReport.SetParameterValue("ChallanDate", oDutyTran.DutyTranDate.ToString("dd-MMM-yyyy"));
            //        oReport.SetParameterValue("ChallanTime", oDutyTran.DutyTranDate.ToShortTimeString());
            //        oReport.SetParameterValue("FromWHName", _oPOSRequisition.FromWHName);
            //        oReport.SetParameterValue("FromWHAddress", _oPOSRequisition.FromWHAddress);
            //        oReport.SetParameterValue("ToWHName", _oPOSRequisition.ToWHName);
            //        oReport.SetParameterValue("ToWHAddress", _oPOSRequisition.ToWHAddress);
            //        oReport.SetParameterValue("VehicleNumber", oDutyTran.VehicleDetail);
            //        oReport.PrintToPrinter(1, true, 1, 1);
            //    }
            //}


            this.Cursor = Cursors.WaitCursor;
            PrintVat();
            this.Cursor = Cursors.Default;
        }
    }
}
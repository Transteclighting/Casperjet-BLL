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
using CJ.Class.Duty;
using CJ.Class.POS;

namespace CJ.Win.Duty
{
    public partial class frmVATLedger : Form
    {
        Warehouses oWarehouses;
        Warehouses oParentWarehouses;
        int _nType = 0;
        //Showrooms _oShowrooms;
        public frmVATLedger(int nType)
        {
            InitializeComponent();
            _nType = nType;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            if (_nType == 1)
                Report();
            //Address should be in

            else if (_nType == 2)
            {
                //Address should be in
                ReportForOutlet();
            }
            else
            {
                ReportForOutletNew();

            }

            DBController.Instance.CloseConnection();
            this.Cursor = Cursors.Default;
        }
        private void Report()
        {

            DutyTran _oDutyTran = new DutyTran();
            _oDutyTran.GetTranNo(ctlProduct1.txtCode.Text.Trim(), ctlProduct1.txtDescription.Text.Trim(), dtFromDate.Value.Date, dtToDate.Value.Date, cmbVAT.Text.Trim());

            DSDutyTranISGM oDSDutyTranOpeningStockRow = new DSDutyTranISGM();
            foreach (DutyTranDetail oItem in _oDutyTran)
            {
                DSDutyTranISGM.DutyTranOpeningStockRow oDutyTranOpeningStockRow = oDSDutyTranOpeningStockRow.DutyTranOpeningStock.NewDutyTranOpeningStockRow();
                oDutyTranOpeningStockRow.ProductID = oItem.ProductID;
                oDutyTranOpeningStockRow.Type = oItem.Type;
                if (oItem.Type == "Invoice")
                {
                    oDutyTranOpeningStockRow.InvoiceNo = oItem.TranNo;
                    oDutyTranOpeningStockRow.InvoiceDate = oItem.TranDate;

                }
                else
                {
                    oDutyTranOpeningStockRow.GRDNo = oItem.TranNo;
                    oDutyTranOpeningStockRow.GrdDate = oItem.TranDate;
                }
                oDutyTranOpeningStockRow.SupplierDetail = oItem.SupplierDetail;
                oDutyTranOpeningStockRow.DutyTranDate = oItem.TranDate;
                oDSDutyTranOpeningStockRow.DutyTranOpeningStock.AddDutyTranOpeningStockRow(oDutyTranOpeningStockRow);
                oDSDutyTranOpeningStockRow.AcceptChanges();
            }

            DutyTran _oDutyTranItem = new DutyTran();
            _oDutyTranItem.GetVATLedger(ctlProduct1.txtCode.Text.Trim(), ctlProduct1.txtDescription.Text.Trim(), dtFromDate.Value.Date, dtToDate.Value.Date, oDSDutyTranOpeningStockRow, cmbVAT.Text.Trim(), oParentWarehouses[cmbWarehouseParent.SelectedIndex - 1].WarehouseParentID);

            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptVATLedger));
            doc.SetDataSource(_oDutyTranItem);

            doc.SetParameterValue("UserName", Utility.Username);
           // doc.SetParameterValue("CompanyName", Utility.CompanyName);
            doc.SetParameterValue("ProductCode", ctlProduct1.txtCode.Text.Trim());
            doc.SetParameterValue("ProductName", ctlProduct1.txtDescription.Text.Trim());
            doc.SetParameterValue("FromDate", dtFromDate.Value.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("ToDate", dtToDate.Value.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("Address", "Sadar Road,Mohakhali,Dhaka-1206");
            //doc.SetParameterValue("PrintDate", Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy"));

            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
        }

        private void ReportForOutlet()
        {
            //int nWHID = _oShowrooms[cmbWarehouse.SelectedIndex - 1].WarehouseID;
            int nWHID = oWarehouses[cmbWarehouse.SelectedIndex - 1].WarehouseID;
            DutyTran _oDutyTran = new DutyTran();
            _oDutyTran.GetTranNoOutletHO(nWHID, ctlProduct1.txtCode.Text.Trim(), ctlProduct1.txtDescription.Text.Trim(), dtFromDate.Value.Date, dtToDate.Value.Date, cmbVAT.Text.Trim());

            DSDutyTranISGM oDSDutyTranOpeningStockRow = new DSDutyTranISGM();
            foreach (DutyTranDetail oItem in _oDutyTran)
            {
                DSDutyTranISGM.DutyTranOpeningStockRow oDutyTranOpeningStockRow = oDSDutyTranOpeningStockRow.DutyTranOpeningStock.NewDutyTranOpeningStockRow();
                oDutyTranOpeningStockRow.ProductID = oItem.ProductID;
                oDutyTranOpeningStockRow.Type = oItem.Type;
                if (oItem.Type == "Invoice")
                {
                    oDutyTranOpeningStockRow.InvoiceNo = oItem.TranNo;
                    oDutyTranOpeningStockRow.InvoiceDate = oItem.TranDate;

                }
                else
                {
                    oDutyTranOpeningStockRow.GRDNo = oItem.TranNo;
                    oDutyTranOpeningStockRow.GrdDate = oItem.TranDate;
                }
                oDutyTranOpeningStockRow.SupplierDetail = oItem.SupplierDetail;
                oDutyTranOpeningStockRow.DutyTranDate = oItem.TranDate;
                oDSDutyTranOpeningStockRow.DutyTranOpeningStock.AddDutyTranOpeningStockRow(oDutyTranOpeningStockRow);
                oDSDutyTranOpeningStockRow.AcceptChanges();
            }


            DutyTran _oDutyTranItem = new DutyTran();
            _oDutyTranItem.GetVATLedgerOutletHO(ctlProduct1.txtCode.Text.Trim(), ctlProduct1.txtDescription.Text.Trim(), dtFromDate.Value.Date, dtToDate.Value.Date, oDSDutyTranOpeningStockRow, cmbVAT.Text.Trim(), nWHID);

            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptVATLedger));
            doc.SetDataSource(_oDutyTranItem);

            doc.SetParameterValue("UserName", Utility.Username);
            // doc.SetParameterValue("CompanyName", Utility.CompanyName);
            doc.SetParameterValue("ProductCode", ctlProduct1.txtCode.Text.Trim());
            doc.SetParameterValue("ProductName", ctlProduct1.txtDescription.Text.Trim());
            doc.SetParameterValue("FromDate", dtFromDate.Value.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("ToDate", dtToDate.Value.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("Address", oWarehouses[cmbWarehouse.SelectedIndex - 1].WarehouseName + "-" + oWarehouses[cmbWarehouse.SelectedIndex - 1].Address);
            //doc.SetParameterValue("PrintDate", Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy"));

            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
        }

        private void ReportForOutletNew()
        {
            if (cmbWarehouseParent.SelectedIndex == 0)
            {
                MessageBox.Show("Please select warehouse parent first", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (ctlProduct1.txtDescription.Text == "")
            {
                MessageBox.Show("Please select a product first", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DutyTran _oDutyTran = new DutyTran();
            if (cmbWarehouseParent.SelectedIndex != 0)
            {
                if (cmbWarehouse.SelectedIndex == 0)
                {
                    _oDutyTran.GetTranNoforHodata(ctlProduct1.SelectedSerarchProduct.ProductID, dtFromDate.Value.Date, dtToDate.Value.Date, oParentWarehouses[cmbWarehouseParent.SelectedIndex - 1].WarehouseParentID);
                }

                else if (oParentWarehouses[cmbWarehouseParent.SelectedIndex - 1].WarehouseParentID == 7)
                {
                    _oDutyTran.GetTranNoOutletHONew(oWarehouses[cmbWarehouse.SelectedIndex - 1].WarehouseID, ctlProduct1.SelectedSerarchProduct.ProductID, dtFromDate.Value.Date, dtToDate.Value.Date);
                }
                else
                {
                    _oDutyTran.GetTranNofoHOParentdata(ctlProduct1.SelectedSerarchProduct.ProductID, dtFromDate.Value.Date, dtToDate.Value.Date, oWarehouses[cmbWarehouse.SelectedIndex - 1].WarehouseID);
                }
            }

           
            //if (_oShowrooms[cmbWarehouse.SelectedIndex - 1].WarehouseID == -1)
            //{
            //    _oDutyTran.GetTranNoforHodata(ctlProduct1.SelectedSerarchProduct.ProductID, dtFromDate.Value.Date, dtToDate.Value.Date,Utility.WarehouseParentID);

            //}
            //else if (_oShowrooms[cmbWarehouse.SelectedIndex - 1].WarehouseParentID == 6)
            //{
            //    _oDutyTran.GetTranNofoHOParentdata(ctlProduct1.SelectedSerarchProduct.ProductID, dtFromDate.Value.Date, dtToDate.Value.Date, _oShowrooms[cmbWarehouse.SelectedIndex - 1].WarehouseID);
            //}
            //else
            //{
            //    int nWHID = _oShowrooms[cmbWarehouse.SelectedIndex - 1].WarehouseID;
            //    _oDutyTran.GetTranNoOutletHONew(nWHID, ctlProduct1.SelectedSerarchProduct.ProductID, dtFromDate.Value.Date, dtToDate.Value.Date);
            //}

            

            if (_oDutyTran.Count == 0)
            {
                MessageBox.Show("There is no data", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DSDutyTranISGM oDSDutyTranOpeningStockRow = new DSDutyTranISGM();
            foreach (DutyTranDetail oItem in _oDutyTran)
            {
                DSDutyTranISGM.VATLedgerNewRow oDutyTranOpeningStockRow = oDSDutyTranOpeningStockRow.VATLedgerNew.NewVATLedgerNewRow();
                oDutyTranOpeningStockRow.ProductID = oItem.ProductID;
                oDutyTranOpeningStockRow.TranType = oItem.Type;
                oDutyTranOpeningStockRow.TranNo = oItem.TranNo;
                oDutyTranOpeningStockRow.TranDate = oItem.TranDate;
                oDutyTranOpeningStockRow.ConsumerName = oItem.ConsumerName;
                oDutyTranOpeningStockRow.NationalID = oItem.NationalID;
                oDutyTranOpeningStockRow.Address = oItem.Address;

                oDSDutyTranOpeningStockRow.VATLedgerNew.AddVATLedgerNewRow(oDutyTranOpeningStockRow);
                oDSDutyTranOpeningStockRow.AcceptChanges();
            }
            
            DutyTran _oDutyTranItem = new DutyTran();
            if (cmbWarehouseParent.SelectedIndex != 0)
            {
                if (cmbWarehouse.SelectedIndex == 0)
                {
                    _oDutyTranItem.GetVATLedgerHadeOffice(ctlProduct1.SelectedSerarchProduct.ProductID, dtFromDate.Value.Date, dtToDate.Value.Date, oDSDutyTranOpeningStockRow, oParentWarehouses[cmbWarehouseParent.SelectedIndex - 1].WarehouseParentID);
                }

                else if (oParentWarehouses[cmbWarehouseParent.SelectedIndex - 1].WarehouseParentID == 7)
                {

                    _oDutyTranItem.GetVATLedgerOutletHONew(ctlProduct1.SelectedSerarchProduct.ProductID, dtFromDate.Value.Date, dtToDate.Value.Date, oDSDutyTranOpeningStockRow, oWarehouses[cmbWarehouse.SelectedIndex - 1].WarehouseID);
                }
                else
                {
                    _oDutyTranItem.GetVATLedgerHadeOfficeParent(ctlProduct1.SelectedSerarchProduct.ProductID, dtFromDate.Value.Date, dtToDate.Value.Date, oDSDutyTranOpeningStockRow, oWarehouses[cmbWarehouse.SelectedIndex - 1].WarehouseID);
                }
            }

            //DutyTran _oDutyTranItem = new DutyTran();
            //if (_oShowrooms[cmbWarehouse.SelectedIndex - 1].WarehouseID == -1)
            //{
            //    _oDutyTranItem.GetVATLedgerHadeOffice(ctlProduct1.SelectedSerarchProduct.ProductID, dtFromDate.Value.Date, dtToDate.Value.Date, oDSDutyTranOpeningStockRow);
            //}
            //else if (_oShowrooms[cmbWarehouse.SelectedIndex - 1].WarehouseParentID == 6)
            //{
            //    _oDutyTranItem.GetVATLedgerHadeOfficeParent(ctlProduct1.SelectedSerarchProduct.ProductID, dtFromDate.Value.Date, dtToDate.Value.Date, oDSDutyTranOpeningStockRow, _oShowrooms[cmbWarehouse.SelectedIndex - 1].WarehouseID);
            //}
            //else
            //{
            //    _oDutyTranItem.GetVATLedgerOutletHONew(ctlProduct1.SelectedSerarchProduct.ProductID, dtFromDate.Value.Date, dtToDate.Value.Date, oDSDutyTranOpeningStockRow, _oShowrooms[cmbWarehouse.SelectedIndex - 1].WarehouseID);
            //}

            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptVATLedgerNew));
            doc.SetDataSource(_oDutyTranItem);

            doc.SetParameterValue("UserName", Utility.Username);
            doc.SetParameterValue("ProductCode", ctlProduct1.txtCode.Text.Trim());
            doc.SetParameterValue("ProductName", ctlProduct1.txtDescription.Text.Trim());
            doc.SetParameterValue("FromDate", dtFromDate.Value.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("ToDate", dtToDate.Value.ToString("dd-MMM-yyyy"));

            if (cmbWarehouseParent.SelectedIndex != 0)
            {
                if (cmbWarehouse.SelectedIndex > 0)
                {
                    doc.SetParameterValue("Address", oWarehouses[cmbWarehouse.SelectedIndex - 1].WarehouseName + "-" + oWarehouses[cmbWarehouse.SelectedIndex - 1].Address);
                }

                else
                {
                    doc.SetParameterValue("Address", oParentWarehouses[cmbWarehouseParent.SelectedIndex - 1].Address);
                }

            }
            else
            {
                doc.SetParameterValue("Address", "");
            }

            //try
            //{
            //    doc.SetParameterValue("Address", oWarehouses[cmbWarehouse.SelectedIndex - 1].WarehouseName + "-" + oWarehouses[cmbWarehouse.SelectedIndex - 1].Address);
            //}
            //catch
            //{
            //    doc.SetParameterValue("Address", oParentWarehouses[cmbWarehouseParent.SelectedIndex - 1].WarehouseParentName);
            //}


            //if (cmbWarehouse.Text == "Central Warehouse[CW]")
            //{
            //    doc.SetParameterValue("Address", "[Central Warehouse] Sadar Road, Mohakhali, Dhaka-1206");
            //}
            //else if (cmbWarehouse.Text == "Ecommerce Transcom Digital[ETD]" || cmbWarehouse.Text == "Government Sales Outlet[GOS]")
            //{
            //    doc.SetParameterValue("Address", "[" + _oShowrooms[cmbWarehouse.SelectedIndex - 1].ShowroomCode + "] " + "Sadar Road, Mohakhali, Dhaka-1206");
            //}
            //else if(cmbWarehouse.Text == "Distribution E&A Warehouse[13]" || cmbWarehouse.Text == "Project CAC&E[15]")
            //{
            //    doc.SetParameterValue("Address", "[" + _oShowrooms[cmbWarehouse.SelectedIndex - 1].ShowroomName + "] " + "Sadar Road, Mohakhali, Dhaka-1206");
            //}
            //else
            //{
            //    doc.SetParameterValue("Address", "[" + _oShowrooms[cmbWarehouse.SelectedIndex - 1].ShowroomCode + "] " + _oShowrooms[cmbWarehouse.SelectedIndex - 1].ShowroomAddress);
            //}
            ////doc.SetParameterValue("PrintDate", Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy"));

            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
        }
        
        private void LoadComboForParentWH()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            cmbWarehouseParent.Items.Clear();
            oParentWarehouses = new Warehouses();
            oParentWarehouses.GetWarehouseParents();
            cmbWarehouseParent.Items.Add("-- Select --");
            foreach (Warehouse oParentWarehouse in oParentWarehouses)
            {
                cmbWarehouseParent.Items.Add(oParentWarehouse.WarehouseParentName);
            }
            cmbWarehouseParent.SelectedIndex = 0;
        }
        private void LoadCombo(int nWarehouseParentID)
        {
            cmbWarehouse.Items.Clear();
            oWarehouses = new Warehouses();
            oWarehouses.GetStockByParent(nWarehouseParentID);
            cmbWarehouse.Items.Add("-- All --");
            foreach (Warehouse oWarehouse in oWarehouses)
            {
                cmbWarehouse.Items.Add(oWarehouse.WarehouseName);
            }
            cmbWarehouse.SelectedIndex = 0;
        }

        private void frmVATLedger_Load(object sender, EventArgs e)
        {
            cmbVAT.SelectedIndex = 0;
            if (_nType == 1)
            {
                cmbWarehouseParent.Visible = true;
                label4.Visible = true;

                cmbWarehouse.Visible = false;
                label5.Visible = false;

                LoadComboForParentWH();

            }
            else if (_nType == 2)
            {
                cmbWarehouse.Visible = true;
                label5.Visible = true;
                cmbWarehouseParent.Visible = true;
                label4.Visible = true;
                LoadComboForParentWH();
                //cmbWarehouse.Items.Clear();
                //cmbWarehouse.Items.Add("<All>");
            }
            else
            {
                dtFromDate.MinDate = Convert.ToDateTime("01-Jul-2019");
                dtToDate.MinDate = Convert.ToDateTime("01-Jul-2019");
                cmbWarehouse.Visible = true;
                label5.Visible = true;
                cmbWarehouseParent.Visible = true;
                label4.Visible = true;
                cmbVAT.Visible = false;
                label2.Visible = false;

                LoadComboForParentWH();
                //cmbWarehouse.Items.Clear();
                //cmbWarehouse.Items.Add("<All>");
            }
        }

        private void cmbWarehouseParent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            if (cmbWarehouseParent.SelectedIndex == 0)
            {
                oWarehouses = null;
                cmbWarehouse.Items.Clear();
                cmbWarehouse.Items.Add("<All>");
                cmbWarehouse.SelectedIndex = 0;
                return;
            }
            else
            {
                LoadCombo(oParentWarehouses[cmbWarehouseParent.SelectedIndex - 1].WarehouseParentID);
            }
        }


       
    }
}

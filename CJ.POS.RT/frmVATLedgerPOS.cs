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
using CJ.Class.Library;

namespace CJ.POS.RT
{
    public partial class frmVATLedgerPOS : Form
    {
        //SystemInfo oSystemInfo;
        TELLib _oTELLib;

        public frmVATLedgerPOS()
        {
            InitializeComponent();
        }
        private void ReportForOutletNewRT()
        {

            if (ctlProduct1.txtDescription.Text == "")
            {
                MessageBox.Show("Please select a product first", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DutyTran _oDutyTran = new DutyTran();



            _oDutyTran.GetTranNofoHOParentdata(ctlProduct1.SelectedSerarchProduct.ProductID, dtFromDate.Value.Date, dtToDate.Value.Date, Utility.WarehouseID);




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



            _oDutyTranItem.GetVATLedgerOutletHONew(ctlProduct1.SelectedSerarchProduct.ProductID, dtFromDate.Value.Date, dtToDate.Value.Date, oDSDutyTranOpeningStockRow, Utility.WarehouseID);



            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptVATLedgerNew));
            doc.SetDataSource(_oDutyTranItem);

            doc.SetParameterValue("UserName", Utility.Username);
            doc.SetParameterValue("ProductCode", ctlProduct1.txtCode.Text.Trim());
            doc.SetParameterValue("ProductName", ctlProduct1.txtDescription.Text.Trim());
            doc.SetParameterValue("FromDate", dtFromDate.Value.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("ToDate", dtToDate.Value.ToString("dd-MMM-yyyy"));

            doc.SetParameterValue("Address", Utility.WarehouseAddress);


            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
        }
        private void btnPreview_Click(object sender, EventArgs e)
        {

            if (cmbReportNo.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a report#", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            if (cmbReportNo.Text == "Mushak - 6.2.1")
            {
                ReportForOutletNewRT();
            }
            else
            {
                Report();
            }
            DBController.Instance.CloseConnection();
            this.Cursor = Cursors.Default;
        }

        private void Report()
        {


            DutyTran _oDutyTran = new DutyTran();
            _oDutyTran.GetTranNoPOSRT(ctlProduct1.txtCode.Text.Trim(), ctlProduct1.txtDescription.Text.Trim(), dtFromDate.Value.Date, dtToDate.Value.Date, cmbVAT.Text.Trim());

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
            _oDutyTranItem.GetVATLedgerPOSRT(ctlProduct1.txtCode.Text.Trim(), ctlProduct1.txtDescription.Text.Trim(), dtFromDate.Value.Date, dtToDate.Value.Date, oDSDutyTranOpeningStockRow, cmbVAT.Text.Trim(), Utility.WarehouseID);

            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptVATLedger));
            doc.SetDataSource(_oDutyTranItem);

            doc.SetParameterValue("UserName", Utility.Username);
            // doc.SetParameterValue("CompanyName", Utility.CompanyName);
            if (ctlProduct1.txtDescription.Text != "")
            {
                doc.SetParameterValue("ProductCode", ctlProduct1.txtCode.Text.Trim());
                doc.SetParameterValue("ProductName", ctlProduct1.txtDescription.Text.Trim());
            }
            else
            {
                doc.SetParameterValue("ProductCode", "ALL");
                doc.SetParameterValue("ProductName", "");
            }
            doc.SetParameterValue("FromDate", dtFromDate.Value.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("ToDate", dtToDate.Value.ToString("dd-MMM-yyyy"));
            //doc.SetParameterValue("PrintDate", Convert.ToDateTime(oSystemInfo.OperationDate).ToString("dd-MMM-yyyy"));

            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
        }


        private void frmVATLedgerPOS_Load(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            cmbReportNo.SelectedIndex = 0;
            cmbVAT.SelectedIndex = 0;
            //oSystemInfo = new SystemInfo();
            //oSystemInfo.Refresh();
            _oTELLib = new TELLib();
            dtFromDate.Value = Convert.ToDateTime(_oTELLib.ServerDateTime());
            dtToDate.Value = Convert.ToDateTime(_oTELLib.ServerDateTime());
        }
    }
}

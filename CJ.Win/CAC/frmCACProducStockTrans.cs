using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Report;
using CJ.Class.Report;

namespace CJ.Win.CAC
{
    public partial class frmCACProducStockTrans : Form
    {
        StockTran oStockTran;
        StockTrans oStockTrans;
        int _nType = 0;
        public frmCACProducStockTrans(int nType)
        {
            InitializeComponent();
            _nType = nType;
        }

        private void frmCACProducStockTrans_Load(object sender, EventArgs e)
        {
            //this.Text = "Goods Receive";
            if (_nType == (int)Dictionary.TransectionSide.CREDIT)
            {
                btnGRD.Visible = true;
                btnStockOut.Visible = false;
            }
            else
            {

                btnGRD.Visible = false;
                btnStockOut.Visible = true;
            }
            DataLoadControl();
        }

        private void btnStockOut_Click(object sender, EventArgs e)
        {

            frmCACChallan oForm = new frmCACChallan();
            oForm.ShowDialog();

        }

        private void btnGRD_Click(object sender, EventArgs e)
        {
            frmCACProducStockTran oForm = new frmCACProducStockTran((int)Dictionary.CACProductStockTranType.GOODS_RECEIVE);
            oForm.ShowDialog();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void DataLoadControl()
        {
            StockTrans oStockTrans = new StockTrans();
            lvwStockList.Items.Clear();

            DBController.Instance.OpenNewConnection();
            oStockTrans.RefreshForCAC(dtFromDate.Value.Date, dtToDate.Value.Date, _nType, txtTranNo.Text.Trim());
            this.Text = "Total " + "[" + oStockTrans.Count + "]";

            foreach (StockTran oStockTran in oStockTrans)
            {
                ListViewItem oItem = lvwStockList.Items.Add(oStockTran.TranNo);
                oItem.SubItems.Add(Convert.ToDateTime(oStockTran.TranDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oStockTran.CACCustomerName);
                oItem.SubItems.Add(oStockTran.Remarks);
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.CACProductStockTranStatus), oStockTran.Status));
                oItem.Tag = oStockTran;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
           
            if (lvwStockList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select Item to Print", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            StockTran oStockTran = (StockTran)lvwStockList.SelectedItems[0].Tag;
            StockTrans oStockTrans = new StockTrans();
            oStockTrans.PrintForCAC(oStockTran.TranID, _nType);
            rptCACChallan oReport = new rptCACChallan();

            List<CacStockChallan> aList = new List<CacStockChallan>();

            foreach (StockTran aStockTran in oStockTrans)
            {
                var aTran = new CacStockChallan
                {
                    ProductCode = aStockTran.CACProductCode,
                    ProductName = aStockTran.CACProductName,
                    Model = aStockTran.CACProductModel,
                    DeliveryAddress = aStockTran.DeliveryAddress,
                    ContactPerson = aStockTran.ContactPerson,
                    ContactNo = aStockTran.ContactNo,
                    DeliveryDate = aStockTran.DeliveryDate,
                    CustomerAddress = aStockTran.Customeraddress,
                    CustomerName = aStockTran.CACCustomerName,
                    LCNo = aStockTran.LCNo,
                    RefNo = aStockTran.RefNo,
                    Transide = aStockTran.Transide,
                    Qty = aStockTran.CACQty
                };
                aList.Add(aTran);
            }
            oReport.SetDataSource(aList);
            //oReport.SetDataSource(oStockTrans);
            oReport.SetParameterValue("TranNo", oStockTran.TranNo);
            oReport.SetParameterValue("TranDate", oStockTran.TranDate);
            oReport.SetParameterValue("Remarks", oStockTran.Remarks);
            oReport.SetParameterValue("UserName", Utility.Username);
            frmPrintPreview oFrom = new frmPrintPreview();
            oFrom.ShowDialog(oReport);
            this.Cursor = Cursors.Default;


        }
    }
}
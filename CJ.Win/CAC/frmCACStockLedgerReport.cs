using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Report;

namespace CJ.Win.CAC
{
    public partial class frmCACStockLedgerReport : Form
    {
       Products _oProducts;
       StockTrans _oStockTrans;
       StockTran oStockTran;
       int _nUIControl = 0;
        public frmCACStockLedgerReport(int nUIControl)
        {
            InitializeComponent();
            _nUIControl = nUIControl;
        }

        private void frmCACStockLedgerReport_Load(object sender, EventArgs e)
        {
            if (_nUIControl == 2)
            {
                lblTo.Visible = false;
                dtToDate.Visible = false;
                this.Text = "CAC Stock Position Report";
            }
        }      
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (ValidateUIControl())
            {
                if (_nUIControl == 1)
                {
                    ViewCACStockLedger();
                }
                else if (_nUIControl == 2)
                {
                    ViewCACStockPosition();
                }

            }
        }
        private bool ValidateUIControl()
        {
            if (_nUIControl == 1 && txtCode.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please Enter CAC Code First", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }
            return true;
        }
        private void ViewCACStockPosition()
        {
            this.Cursor = Cursors.WaitCursor;
            StockTrans oStockTrans = new StockTrans();
            int nProductID = -1;
            if (txtCode.Text.Trim() != string.Empty)
            {
                oStockTran = new StockTran();
                oStockTran.CACProductCode = txtCode.Text.Trim();
                oStockTran.RefreshByCACProductCode();
                nProductID = oStockTran.ProductID;
            }

            oStockTrans.PrintForCACStockPosition(nProductID,dtFromDate.Value.Date, dtToDate.Value.Date);

            rptCACStockLedger oReport = new rptCACStockLedger();
            List<CacStockLedger> aList = new List<CacStockLedger>();
            foreach (StockTran aStockTran in oStockTrans)
            {
                var aTran = new CacStockLedger
                {
                    CACProductCode = aStockTran.CACProductCode,
                    CACProductName = aStockTran.CACProductName,
                    OpeningStock = aStockTran.OpeningStock,
                    GRDQty = aStockTran.GRDQty,
                    IssueQty = aStockTran.IssueQty,
                    ClosingStock = aStockTran.ClosingStock
                };
                aList.Add(aTran);
            }
            oReport.SetDataSource(aList);
            //oReport.SetDataSource(oStockTrans);
            oReport.SetParameterValue("FromDate", dtFromDate.Value.Date.ToString("dd-MMM-yyyy"));
            oReport.SetParameterValue("ToDate", dtToDate.Value.Date.ToString("dd-MMM-yyyy"));
            oReport.SetParameterValue("PrintUser", Utility.Username);
            frmPrintPreview oFrom = new frmPrintPreview();
            oFrom.ShowDialog(oReport);
            this.Cursor = Cursors.Default;
        }

        private void ViewCACStockLedger()
        {
            this.Cursor = Cursors.WaitCursor;
            
            StockTrans oStockTrans = new StockTrans();
            int nProductID = 0;
            if (txtCode.Text.Trim() != string.Empty)
            {
                oStockTran = new StockTran();
                oStockTran.CACProductCode = txtCode.Text.Trim();
                oStockTran.RefreshByCACProductCode();
                nProductID = oStockTran.ProductID;
            }

            int nOpeningStock;

            nOpeningStock = oStockTrans.PrintForCACStockLedgerProductWise(nProductID, dtFromDate.Value.Date, dtToDate.Value.Date);

            rptCACStockLedgerProductWise doc = new rptCACStockLedgerProductWise();
            List<CacStockLedgerProductWise> aList = new List<CacStockLedgerProductWise>();
            foreach (StockTran aStockTran in oStockTrans)
            {
                var aTran = new CacStockLedgerProductWise
                {
                    ProductID = aStockTran.ProductID,
                    ProductCode = aStockTran.CACProductCode,
                    ProductName = aStockTran.CACProductName,
                    TranNo = aStockTran.TranNo,
                    TranDate= aStockTran.TranDate,
                    TranTypeID = aStockTran.TranTypeID,
                    GRDQty = aStockTran.GRDQty,
                    IssueQty = aStockTran.IssueQty,
                    Balance = aStockTran.Balance
                };
                aList.Add(aTran);
            }
            doc.SetDataSource(aList);
            doc.SetParameterValue("ProductCode", txtCode.Text);
            doc.SetParameterValue("FromDate", dtFromDate.Value.Date.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("ToDate", dtToDate.Value.Date.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("OpeningStock", nOpeningStock);
            doc.SetParameterValue("ClosingStock", nOpeningStock);
            if (oStockTrans.Count > 0)
            {
                foreach (StockTran oStockTran in oStockTrans)
                {
                    doc.SetParameterValue("ClosingStock", oStockTran.ClosingStock);
                    doc.SetParameterValue("OpeningStock", oStockTran.OpeningStock);
                }
            }
            doc.SetParameterValue("PrintUser", Utility.Username);
            frmPrintPreview frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
            this.Cursor = Cursors.Default;
        }
    }
}





















































































































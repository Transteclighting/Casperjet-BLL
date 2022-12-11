using CJ.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CJ.Win
{
    public partial class frmBarcodeSystemBE : Form
    {
        public bool _IsTrue = false;
        string _TranNo;
        DateTime _TranDate;
        int _TranID = 0;
        int _nToWHID = 0;
        public int _TotalGereratedQty = 0;
        public frmBarcodeSystemBE(string _sTranNo, DateTime _dTranDate, int _nTranID, int _ToWHID)
        {
            InitializeComponent();
            _TranID = _nTranID;
            lblTranDate.Text = _dTranDate.ToString("dd-MMM-yyyy");
            lblTRanNo.Text = _sTranNo.ToString();
            _nToWHID = _ToWHID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void GetProductIds(int nTranId, string sTranNo)
        {
            ProductBarcodes oProductBarcodes = new ProductBarcodes();

            //if (!DBController.Instance.CheckConnection())
            //{
            //    DBController.Instance.OpenNewConnection();
            //}

            oProductBarcodes.GetProductInfo(nTranId);
            int _Count = 0;
            foreach (ProductBarcode oProductBarcode in oProductBarcodes)
            {
                oProductBarcode.TranNo = lblTRanNo.Text;
                oProductBarcode.BENo = txtBENo.Text;
                oProductBarcode.BEDate = dtBEDate.Value.Date;
                try
                {
                    if (oProductBarcode.Qty > 0)
                    {
                      ///  DBController.Instance.BeginNewTransaction();
                        if (Utility.CompanyInfo == "TML")
                        {
                            oProductBarcode.AddTML(1);
                            _TotalGereratedQty = _TotalGereratedQty + Convert.ToInt32(oProductBarcode.Qty);
                        }
                        else
                        {
                            oProductBarcode.AddinGRD(1, nTranId, _nToWHID, lblTRanNo.Text);
                            _TotalGereratedQty = _TotalGereratedQty + Convert.ToInt32(oProductBarcode.Qty);
                        }

                        ///DBController.Instance.CommitTran();
                    }
                }
                catch (Exception ex)
                {
                    _TotalGereratedQty = 0;
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                GetProductIds(_TranID, lblTRanNo.Text);
                this.Cursor = Cursors.Default;
                MessageBox.Show("You Have Successfully Save The Data. This Transaction No : " + lblTRanNo.Text, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _IsTrue = true;
                this.Close();
            }
            catch (Exception ex)
            {
                _IsTrue = false;
                MessageBox.Show(ex.Message);
            }


        }
    }
}

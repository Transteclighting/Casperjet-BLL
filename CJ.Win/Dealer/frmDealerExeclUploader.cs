using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Library;
using CJ.Class.Accounts;
using System.Data.OleDb;
using System.Threading;


using CJ.Class;

namespace CJ.Win
{
    public partial class frmDealerExeclUploader : Form
    {
        Companys _oCompanys;
        private DataTable _oDT;
        private int nArrayLen = 0;
        private string[] sProductBarcodeArr = null;
        DMSProductStockTran _DMSProductStockTran;
        //MobileNumberAssign _oMobileNumberAssign;

        public frmDealerExeclUploader()
        {
            InitializeComponent();
        }

        private void frmMobileBillExeclUploader_Load(object sender, EventArgs e)
        {
            DateTime _Date = Convert.ToDateTime("01-" + dtTranDate.Value.Month + "-" + dtTranDate.Value.Year);
            dtTranDate.Value = _Date;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                this.Cursor = Cursors.WaitCursor;
                Save();
                this.Cursor = Cursors.Default;
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            bool IsSelected = false;
            this.openFileDialogData.FileName = "";
            this.openFileDialogData.Multiselect = false;
            this.openFileDialogData.Filter = "";
            this.openFileDialogData.Filter = "Excel 2007+ Sheet(*.xlsx)|*.xlsx|Excel Sheet(*.xls)|*.xls";
            if (this.openFileDialogData.ShowDialog() == DialogResult.OK)
            {
                this.txtXLFilePath.Text = this.openFileDialogData.FileName.ToString();
                this.Text = this.openFileDialogData.DefaultExt.ToString();
                IsSelected = true;
            }

            if (IsSelected)
            {
                LoadSheets();
            }
            //GetTotalAmount();
        }

        private void LoadSheets()
        {
            OleDbConnection oConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txtXLFilePath.Text + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;\"");
            oConn.Open();

            OleDbDataAdapter oDataAdapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", oConn);

            DataSet oDS = new DataSet();
            _oDT = new DataTable();
            oDataAdapter.Fill(_oDT);
            dgvDealerStock.DataSource = _oDT.DefaultView;
            this.Text = "Load From XL [" + _oDT.Rows.Count + "]";

            dgvDealerStock.ReadOnly = true;
            btnProcess.Enabled = true;
        }

        //public void GetTotalAmount()
        //{
        //    txtTotalAmount.Text = "0.00";
        //    TELLib oTELLib = new TELLib();
        //    double _Amount = 0;
        //    lblAmountInWord.Text = "";
        //    DataGridViewRow oDGVRow;

        //    foreach (DataGridViewRow oRow in dgvDealerStock.Rows)
        //    {

        //        if (oRow.Cells[2].Value != null)
        //        {

        //            double _Amt;
        //            try
        //            {
        //                _Amt = Convert.ToDouble(oRow.Cells[2].Value.ToString());
        //            }
        //            catch
        //            {
        //                _Amt = 0;
        //            }
        //            _Amount = _Amount + _Amt;
        //        }
        //    }
        //    txtTotalAmount.Text = oTELLib.TakaFormat(_Amount);
        //    lblAmountInWord.Text = oTELLib.TakaWords(_Amount);
        //}
        private bool validateUIInput()
        {
            if (dgvDealerStock.Rows.Count == 0)
            {
                MessageBox.Show("No Data To Save Bill", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (txtTranNo.Text.Trim() == "")
            {
                MessageBox.Show("Please write a Tran No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private void Save()
        {
            string _CustomerCode = "";
            DBController.Instance.OpenNewConnection();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            //MobileNumberAssign oMobileNumberAssign = new MobileNumberAssign();
            try
            {
                DBController.Instance.BeginNewTransaction();
                foreach (DataGridViewRow oItemRow in dgvDealerStock.Rows)
                {

                    DealerOutlet oDO = new DealerOutlet();
                    string sCustomerCode = Convert.ToString(oItemRow.Cells[0].Value.ToString());
                    oDO.CustomerCode = sCustomerCode.Trim();
                    oDO.Refresh();

                    //_oMobileNumberAssign = new MobileNumberAssign(); 
                    if (_CustomerCode == "")
                    {
                        _CustomerCode = sCustomerCode;
                        _DMSProductStockTran = new DMSProductStockTran();
                        _DMSProductStockTran.ToCustomerID = oDO.CustomerID;
                        _DMSProductStockTran.TranDate = dtTranDate.Value;


                        string sProductCode = "";
                        if (oDO.CustomerID != 0)
                        {

                            DMSProductStockTranItem oDMSProductStockTranItem = new DMSProductStockTranItem();
                            sProductCode = oItemRow.Cells[1].Value.ToString();

                            Product oProduct = new Product();
                            //DBController.Instance.OpenNewConnection();
                            oProduct.ProductCode = sProductCode;
                            oProduct.Refresh();

                            if (oProduct.Flag != true)
                            {

                                oDMSProductStockTranItem.Qty = Convert.ToInt32(oItemRow.Cells[2].Value.ToString());
                                oDMSProductStockTranItem.CostPrice = oProduct.CostPrice;
                                oDMSProductStockTranItem.SalesPrice = oProduct.NSP;
                                oDMSProductStockTranItem.ProductID = oProduct.ProductID;

                            }



                            char[] splitchar = { ',' };
                            string sProductBarcode = oItemRow.Cells[3].Value.ToString();
                            sProductBarcodeArr = sProductBarcode.Split(splitchar);
                            nArrayLen = sProductBarcodeArr.Length;

                            for (int i = 0; i < nArrayLen; i++)
                            {
                                DMSProductStockSerial oDMSProductStockSerial = new DMSProductStockSerial();
                                oDMSProductStockSerial.ProductID = oDMSProductStockTranItem.ProductID;
                                oDMSProductStockSerial.ProductSerial = sProductBarcodeArr[i];

                                oDMSProductStockTranItem.Add(oDMSProductStockSerial);
                            }



                            _DMSProductStockTran.Add(oDMSProductStockTranItem);
                        }

                    }
                    else if (_CustomerCode == sCustomerCode.Trim())
                    {
                        //_DMSProductStockTran = new DMSProductStockTran();
                        //_DMSProductStockTran.ToCustomerID = oDO.CustomerID;
                        //_DMSProductStockTran.TranDate = dtTranDate.Value;



                        string sProductCode = "";
                        if (oDO.CustomerID != 0)
                        {

                            DMSProductStockTranItem oDMSProductStockTranItem = new DMSProductStockTranItem();
                            sProductCode = oItemRow.Cells[1].Value.ToString();

                            Product oProduct = new Product();
                            //DBController.Instance.OpenNewConnection();
                            oProduct.ProductCode = sProductCode;
                            oProduct.Refresh();

                            if (oProduct.Flag != true)
                            {

                                oDMSProductStockTranItem.Qty = Convert.ToInt32(oItemRow.Cells[2].Value.ToString());
                                oDMSProductStockTranItem.CostPrice = oProduct.CostPrice;
                                oDMSProductStockTranItem.SalesPrice = oProduct.NSP;
                                oDMSProductStockTranItem.ProductID = oProduct.ProductID;

                            }




                            char[] splitchar = { ',' };
                            string sProductBarcode = oItemRow.Cells[3].Value.ToString();
                            sProductBarcodeArr = sProductBarcode.Split(splitchar);
                            nArrayLen = sProductBarcodeArr.Length;

                            for (int i = 0; i < nArrayLen; i++)
                            {
                                DMSProductStockSerial oDMSProductStockSerial = new DMSProductStockSerial();
                                oDMSProductStockSerial.ProductID = oDMSProductStockTranItem.ProductID;
                                oDMSProductStockSerial.ProductSerial = sProductBarcodeArr[i].Trim();

                                oDMSProductStockTranItem.Add(oDMSProductStockSerial);
                            }



                            _DMSProductStockTran.Add(oDMSProductStockTranItem);
                        }

                    }
                    else
                    {
                        _DMSProductStockTran.TranNo = txtTranNo.Text.Trim();
                        _DMSProductStockTran.Insert();                        
                        _CustomerCode = "";
                    }


                }
                if (dgvDealerStock.Rows.Count > 0)
                {
                    _DMSProductStockTran.TranNo = txtTranNo.Text.Trim();
                    _DMSProductStockTran.Insert();

                    DBController.Instance.CommitTransaction();
                }
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }


        private void btnProcess_Click(object sender, EventArgs e)
        {
            //ProcessBills();
        }


        //public void ProcessBills()
        //{
        //    DBController.Instance.OpenNewConnection();
        //    MobileBill oMobileBill = new MobileBill();
        //    MobileNumber _oMobileNumber = new MobileNumber(); 
        //    foreach (DataGridViewRow oItemRow in dgvDealerStock.Rows)
        //    {
        //        //_oMobileNumberAssign = new MobileNumberAssign();
        //        string sMobileNo = Convert.ToString(oItemRow.Cells[1].Value.ToString());
        //        _oMobileNumber.MobileNo = sMobileNo;
        //        _oMobileNumber.GetMobileDetails();
        //        oMobileBill.MobileID = _oMobileNumber.ID;

        //        //if (!_oMobileNumberAssign.IsMobileBillSavedForMonth(oMobileBill.MobileID, dtBillMonth.Value.Month, dtBillMonth.Value.Year))
        //        //{
        //        //    oItemRow.DefaultCellStyle.BackColor = Color.FromArgb(255, 228, 196);
        //        //}
        //        //else
        //        //{
        //        //    oItemRow.DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);
        //        //}
        //    }
        //}



    }
}
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
using CJ.Class.POS;
using CJ.Class.Library;
using CJ.Class.CSD;

namespace CJ.POS
{
    public partial class frmSmartWarranty : Form
    {
        SalesInvoice oSalesInvoice;
        int _PaymentModeID = 0;
        double _Amount = 0;
        int _BankID = 0;
        int _CardType = 0;
        int _POSMachineID = 0;
        int _CardCategory = 0;
        string _sApprovalNo = "";
        string _sInstrumentNo = "";
        DateTime _dtInstrumentDate = DateTime.Now.Date;
        string _sProductDetail = "";
        string _sBarcode = "";
        DateTime _dtStartDate;
        DateTime _dtEndDate;
        int _SmartWarrantyID = 0;
        int _SmartWarrantyTenure = 0;
        ExtendedWarranty oExtendedWarranty;
        SystemInfo oSystemInfo;
        public bool _isTrue = false;
        public frmSmartWarranty()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool validateUIInput()
        {


            #region Order Details Information Validation
            if (dgvLineItem.Rows.Count == 0)
            {
                MessageBox.Show("Please input valid invoice# ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count)
                {
                    try
                    {
                        double temp = Convert.ToDouble(oItemRow.Cells[6].Value.ToString());
                    }
                    catch
                    {
                        MessageBox.Show("Please input valid amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                }
            }
            #endregion

            return true;
        }
        public bool SendSMS(string sMobileNo, string sCertificateNo, int nSmartWarrantyTenure)
        {
            SMSMaker _oSMSMaker = new SMSMaker();
            //sMobileNo = "01730340633";
            string sText = "Thank you for enrolling Care Pack campaign. Your code is "+ sCertificateNo + ". This campaign will be available for next "+ nSmartWarrantyTenure + " months from the date of your product purchase.";
            return _oSMSMaker.IntegrateWithAPI(1, sMobileNo, sText);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                DBController.Instance.BeginNewTransaction();
                try
                {
                    foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                    {
                        if (oItemRow.Index < dgvLineItem.Rows.Count)
                        {
                            oExtendedWarranty = new ExtendedWarranty();
                            oExtendedWarranty.WarehouseID = oSystemInfo.WarehouseID;
                            oExtendedWarranty.SmartWarrantyID = int.Parse(oItemRow.Cells[21].Value.ToString());
                            oExtendedWarranty.ConsumerID = int.Parse(oItemRow.Cells[20].Value.ToString());
                            oExtendedWarranty.IssueDate = DateTime.Now.Date;
                            oExtendedWarranty.ProductID = int.Parse(oItemRow.Cells[19].Value.ToString());
                            oExtendedWarranty.ProductSerialNo = (oItemRow.Cells[1].Value.ToString());
                            oExtendedWarranty.InvoiceNo = lblInvoiceNo.Text;
                            oExtendedWarranty.InvoiceDate = Convert.ToDateTime(lblInvoiceDate.Text);
                            oExtendedWarranty.ExtendedWarrantyStartDate = Convert.ToDateTime(oItemRow.Cells[3].Value.ToString());
                            oExtendedWarranty.ExtendedWarrantyEndDate = Convert.ToDateTime(oItemRow.Cells[4].Value.ToString());
                            oExtendedWarranty.PaymentModeID = int.Parse(oItemRow.Cells[14].Value.ToString());
                            oExtendedWarranty.Amount = Convert.ToDouble(oItemRow.Cells[6].Value.ToString());
                            try
                            {
                                oExtendedWarranty.BankID = int.Parse(oItemRow.Cells[15].Value.ToString());
                            }
                            catch
                            {
                                oExtendedWarranty.BankID = -1;
                            }
                            try
                            {
                                oExtendedWarranty.CardType = int.Parse(oItemRow.Cells[16].Value.ToString());
                            }
                            catch
                            {
                                oExtendedWarranty.CardType = -1;
                            }
                            try
                            {
                                oExtendedWarranty.POSMachineID = int.Parse(oItemRow.Cells[17].Value.ToString());
                            }
                            catch
                            {
                                oExtendedWarranty.POSMachineID = -1;
                            }
                            try
                            {
                                oExtendedWarranty.InstrumentNo = (oItemRow.Cells[12].Value.ToString());
                            }
                            catch
                            {
                                oExtendedWarranty.InstrumentNo = "";
                            }
                            try
                            {
                                oExtendedWarranty.InstrumentDate = Convert.ToDateTime(oItemRow.Cells[13].Value.ToString());
                            }
                            catch
                            {
                                oExtendedWarranty.InstrumentDate = DateTime.Now.Date;
                            }
                            try
                            {
                                oExtendedWarranty.CardCategory = int.Parse(oItemRow.Cells[18].Value.ToString());
                            }
                            catch
                            {
                                oExtendedWarranty.CardCategory = -1;
                            }
                            try
                            {
                                oExtendedWarranty.ApprovalNo = (oItemRow.Cells[11].Value.ToString());
                            }
                            catch
                            {
                                oExtendedWarranty.ApprovalNo = "";
                            }
                            oExtendedWarranty.CreateDate = DateTime.Now;
                            oExtendedWarranty.CreateUserID = Utility.UserId;
                            oExtendedWarranty.Add(oSystemInfo.Shortcode);

                            DataTran oDataTran = new DataTran();
                            oDataTran.TableName = "t_ExtendedWarranty";
                            oDataTran.DataID = Convert.ToInt32(oExtendedWarranty.ID);
                            oDataTran.WarehouseID = oSystemInfo.WarehouseID;
                            oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                            oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                            oDataTran.BatchNo = 0;
                            if (oDataTran.CheckData() == false)
                            {
                                oDataTran.AddForTDPOS();
                            }
                            SendSMS(lblMobile.Text, oExtendedWarranty.CertificateNo, int.Parse(oItemRow.Cells[24].Value.ToString()));

                        }
                    }
                    

                    DBController.Instance.CommitTran();
                    _isTrue = true;
                    MessageBox.Show("Add Successfully" + "", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

        }

        private void txtRefInvoiceNo_TextChanged(object sender, EventArgs e)
        {
            oSalesInvoice = new SalesInvoice();
            txtRefInvoiceNo.ForeColor = System.Drawing.Color.Red;

            if (txtRefInvoiceNo.Text.Length == 13)
            {

                if (!DBController.Instance.CheckConnection())
                {
                    DBController.Instance.OpenNewConnection();
                }
                //SystemInfo oSystemInfo = new SystemInfo();
                //oSystemInfo.Refresh();
                oSalesInvoice.RefreshForRetailInvoiceByNo(txtRefInvoiceNo.Text.Trim(), Convert.ToDateTime(oSystemInfo.OperationDate));
                if (oSalesInvoice.InvoiceNo == null)
                {
                    oSalesInvoice = null;
                    AppLogger.LogFatal("There is no Data.");
                    return;
                }
                else
                {

                    lblInvoiceNo.Text = oSalesInvoice.InvoiceNo;
                    lblInvoiceDate.Text = Convert.ToDateTime(oSalesInvoice.InvoiceDate).ToString("dd-MMM-yyyy");
                    lblConsumerName.Text = oSalesInvoice.ConsumerName;
                    lblMobile.Text = oSalesInvoice.MobileNo;
                    lblShowroomName.Text = oSystemInfo.WarehouseName;
                    oSalesInvoice.RefreshSalesInvoiceForSmartWarranty(oSalesInvoice.InvoiceNo, Convert.ToDateTime(oSalesInvoice.InvoiceDate));//

                    dgvLineItem.Rows.Clear();
                    foreach (SalesInvoiceItem oSalesInvoiceItem in oSalesInvoice)
                    {

                        DataGridViewRow oRow = new DataGridViewRow();
                        oRow.CreateCells(dgvLineItem);
                        oRow.Cells[0].Value = oSalesInvoiceItem.ProductName.ToString();
                        oRow.Cells[1].Value = oSalesInvoiceItem.ProductSerial.ToString();

                        oRow.Cells[19].Value = oSalesInvoiceItem.ProductID.ToString();
                        oRow.Cells[20].Value = oSalesInvoiceItem.SundryCustomerID.ToString();
                        oRow.Cells[22].Value = oSalesInvoiceItem.SpecialComponentWarranty.ToString();
                        oRow.Cells[23].Value = oSalesInvoiceItem.WarrantyExpiryDate.ToString();

                        dgvLineItem.Rows.Add(oRow);

                    }

                    txtRefInvoiceNo.ForeColor = System.Drawing.Color.Empty;
                    txtRefInvoiceNo.Enabled = false;
                }
            }



        }

        private void dgvLineItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2)
            {
                //DSInvoicePayment _oDSInvoicePaymentExptProductSingle = new DSInvoicePayment();
                //DSInvoicePayment oDSInvoicePaymentExptProductSingle = new DSInvoicePayment();
                //_oDSInvoicePaymentExptProductSingle = MargePaymentExptProduct(_oDSInvoicePaymentExptProductSingle, _nProductID);
                //oDSInvoicePaymentExptProductSingle.Merge(_oDSInvoicePaymentExptProductSingle);
                //oDSInvoicePaymentExptProductSingle.Merge(oDSInvoicePaymentExptProduct);
                //oDSInvoicePaymentExptProductSingle.AcceptChanges();

                _sProductDetail = (dgvLineItem.Rows[e.RowIndex].Cells[0].Value.ToString());
                _sBarcode = (dgvLineItem.Rows[e.RowIndex].Cells[1].Value.ToString());
                try
                {
                    _dtStartDate = Convert.ToDateTime(dgvLineItem.Rows[e.RowIndex].Cells[3].Value.ToString());
                }
                catch
                {
                    _dtStartDate = DateTime.Now.Date;
                }
                try
                {
                    _dtEndDate = Convert.ToDateTime(dgvLineItem.Rows[e.RowIndex].Cells[4].Value.ToString());
                }
                catch
                {
                    _dtEndDate = DateTime.Now.Date;
                }


                try
                {
                    _PaymentModeID = int.Parse(dgvLineItem.Rows[e.RowIndex].Cells[14].Value.ToString());
                }
                catch
                {
                    _PaymentModeID = -1;
                }
                try
                {
                    _Amount = Convert.ToDouble(dgvLineItem.Rows[e.RowIndex].Cells[6].Value.ToString());
                }
                catch
                {
                    _Amount = 0;

                }
                try
                {
                    _BankID = int.Parse(dgvLineItem.Rows[e.RowIndex].Cells[15].Value.ToString());
                }
                catch
                {
                    _BankID = -1;
                }
                try
                {
                    _CardType = int.Parse(dgvLineItem.Rows[e.RowIndex].Cells[16].Value.ToString());
                }
                catch
                {
                    _CardType = -1;
                }
                try
                {
                    _POSMachineID = int.Parse(dgvLineItem.Rows[e.RowIndex].Cells[17].Value.ToString());
                }
                catch
                {
                    _POSMachineID = -1;
                }
                try
                {
                    _CardCategory = int.Parse(dgvLineItem.Rows[e.RowIndex].Cells[18].Value.ToString());
                }
                catch
                {
                    _CardCategory = -1;
                }
                try
                {
                    _sApprovalNo = (dgvLineItem.Rows[e.RowIndex].Cells[11].Value.ToString());
                }
                catch
                {
                    _sApprovalNo = "";
                }

                try
                {
                    _sInstrumentNo = (dgvLineItem.Rows[e.RowIndex].Cells[12].Value.ToString());
                }
                catch
                {
                    _sInstrumentNo = "";
                }
                try
                {
                    _dtInstrumentDate = Convert.ToDateTime(dgvLineItem.Rows[e.RowIndex].Cells[13].Value.ToString());
                }
                catch
                {
                    _dtInstrumentDate = DateTime.Now.Date;
                }



                try
                {
                    _SmartWarrantyID = int.Parse(dgvLineItem.Rows[e.RowIndex].Cells[21].Value.ToString());
                }
                catch
                {
                    _SmartWarrantyID = -1;
                }


                try
                {
                    _SmartWarrantyTenure = int.Parse(dgvLineItem.Rows[e.RowIndex].Cells[24].Value.ToString());
                }
                catch
                {
                    _SmartWarrantyTenure = -1;
                }
                frmSmartWarrantyPayment oForm = new frmSmartWarrantyPayment(_PaymentModeID, _Amount, _BankID, _CardType, _POSMachineID, _CardCategory, _sApprovalNo,
                                                                            _sInstrumentNo, _dtInstrumentDate, _sProductDetail, _sBarcode, _dtStartDate, _dtEndDate, int.Parse(dgvLineItem.Rows[e.RowIndex].Cells[19].Value.ToString()), Convert.ToDateTime(dgvLineItem.Rows[e.RowIndex].Cells[23].Value.ToString()), (dgvLineItem.Rows[e.RowIndex].Cells[1].Value.ToString()), _SmartWarrantyID, _SmartWarrantyTenure);
                oForm.ShowDialog();

                if (oForm._IsTrue == true)
                {

                    dgvLineItem.Rows[e.RowIndex].Cells[3].Value = oForm.dtStartDate;
                    dgvLineItem.Rows[e.RowIndex].Cells[4].Value = oForm.dtEndDate;
                    dgvLineItem.Rows[e.RowIndex].Cells[5].Value = oForm.sPaymentModeName.ToString();
                    dgvLineItem.Rows[e.RowIndex].Cells[6].Value = oForm.nAmount;
                    dgvLineItem.Rows[e.RowIndex].Cells[14].Value = Convert.ToInt32(oForm.nPaymentModeID).ToString();
                    dgvLineItem.Rows[e.RowIndex].Cells[21].Value = Convert.ToInt32(oForm.nSmartWarrantyID).ToString();
                    dgvLineItem.Rows[e.RowIndex].Cells[24].Value = Convert.ToInt32(oForm.nSmartWarrantyTenure).ToString();
                    if (oForm.nPaymentModeID == (int)Dictionary.PaymentMode.Credit_Card)
                    {
                        dgvLineItem.Rows[e.RowIndex].Cells[7].Value = oForm.sBankName.ToString();
                        dgvLineItem.Rows[e.RowIndex].Cells[8].Value = oForm.sCardTypeName.ToString();
                        dgvLineItem.Rows[e.RowIndex].Cells[9].Value = oForm.sPOSMachineName.ToString();
                        dgvLineItem.Rows[e.RowIndex].Cells[10].Value = oForm.sCardCategoryName.ToString();
                        dgvLineItem.Rows[e.RowIndex].Cells[11].Value = oForm.sApprovalNo.ToString();
                        dgvLineItem.Rows[e.RowIndex].Cells[12].Value = oForm.sInstrumentNo.ToString();
                        dgvLineItem.Rows[e.RowIndex].Cells[13].Value = Convert.ToDateTime(oForm.dInstrumentDate).ToString("dd-MMM-yyyy");
                        dgvLineItem.Rows[e.RowIndex].Cells[15].Value = Convert.ToInt32(oForm.nBankID).ToString();
                        dgvLineItem.Rows[e.RowIndex].Cells[16].Value = Convert.ToInt32(oForm.nCardType).ToString();
                        dgvLineItem.Rows[e.RowIndex].Cells[17].Value = Convert.ToInt32(oForm.nPOSMachineID).ToString();
                        dgvLineItem.Rows[e.RowIndex].Cells[18].Value = Convert.ToInt32(oForm.nCardCategory).ToString();
                    }
                    else
                    {
                        dgvLineItem.Rows[e.RowIndex].Cells[7].Value = "";
                        dgvLineItem.Rows[e.RowIndex].Cells[8].Value = "";
                        dgvLineItem.Rows[e.RowIndex].Cells[9].Value = "";
                        dgvLineItem.Rows[e.RowIndex].Cells[10].Value = "";
                        dgvLineItem.Rows[e.RowIndex].Cells[11].Value = "";
                        dgvLineItem.Rows[e.RowIndex].Cells[12].Value = "";
                        dgvLineItem.Rows[e.RowIndex].Cells[13].Value = DateTime.Now.Date.ToString("dd-MMM-yyyy");

                        dgvLineItem.Rows[e.RowIndex].Cells[15].Value = -1;
                        dgvLineItem.Rows[e.RowIndex].Cells[16].Value = -1;
                        dgvLineItem.Rows[e.RowIndex].Cells[17].Value = -1;
                        dgvLineItem.Rows[e.RowIndex].Cells[18].Value = -1;

                    }
                }

            }
        }

        private void frmSmartWarranty_Load(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            oSystemInfo = new SystemInfo();
            oSystemInfo.Refresh();
        }
    }
}

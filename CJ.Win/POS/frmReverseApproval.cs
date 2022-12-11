using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;
using CJ.Class.Library;

namespace CJ.Win.POS
{
    public partial class frmReverseApproval : Form
    {
        InvoiceReverse _oInvoiceReverse;
        int nReverseID = 0;
        int nWarehouseID = 0;
        int _nType = 0;
        double _Amt = 0;
        double _DisAmt = 0;
        long nInvoiceID = 0;
        TELLib _oTELLib;
        SalesInvoice oSalesInvoice;
        RetailSalesInvoice _oRetailSalesInvoice;

        public frmReverseApproval(int nType)
        {
            InitializeComponent();
            _nType = nType;
        }
        public void ShowDialog(InvoiceReverse oInvoiceReverse)
        {
            this.Tag = oInvoiceReverse;
            nReverseID = oInvoiceReverse.ReverseID;
            nWarehouseID = oInvoiceReverse.WarehouseID;

            nWarehouseID = oInvoiceReverse.WarehouseID;
            txtRefInvoiceNo.Text = oInvoiceReverse.InvoiceNo;

            txtReason.Text = oInvoiceReverse.Reason;
            txtRecommend.Text = oInvoiceReverse.Recommend;
            txtApprovedCommends.Text = oInvoiceReverse.ApprovedCommand;
            if (_nType == (int)Dictionary.ReverseStatus.Recommended)
            {
                lblApprovedComments.Enabled = false;
                txtApprovedCommends.Enabled = false;
                btnApproved.Text = "Recommended";
            }
            else if (_nType == (int)Dictionary.ReverseStatus.Approved)
            {
                lblApprovedComments.Enabled = true;
                txtApprovedCommends.Enabled = true;
                btnApproved.Text = "Approved";
            }
            else if (_nType == (int)Dictionary.ReverseStatus.Reject)
            {
                lblRecommends.Enabled = false;
                txtRecommend.Enabled = false;
                lblApprovedComments.Enabled = false;
                txtApprovedCommends.Enabled = false;
                btnApproved.Text = "Reject";
            }
            
            this.ShowDialog();
        }

        private void LoadCombo()
        {
            //Is Repairable
            cmbStockType.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.StockType)))
            {
                cmbStockType.Items.Add(Enum.GetName(typeof(Dictionary.StockType), GetEnum));
            }

            //Defective Type
            cmbDefectiveType.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.POSUnsoldDefectiveProductType)))
            {
                cmbDefectiveType.Items.Add(Enum.GetName(typeof(Dictionary.POSUnsoldDefectiveProductType), GetEnum));
            }
        }

        //private void txtRefInvoiceNo_TextChanged(object sender, EventArgs e)
        //{

        //    _oInvoiceReverse = new InvoiceReverse();
        //    txtRefInvoiceNo.ForeColor = System.Drawing.Color.Red;

        //    if (txtRefInvoiceNo.Text.Length == 13)
        //    {
        //        DBController.Instance.OpenNewConnection();
        //        _oInvoiceReverse.RefreshByInvoiceNoHO(txtRefInvoiceNo.Text.Trim());
        //        if (_oInvoiceReverse.InvoiceNo == null)
        //        {
        //            _oInvoiceReverse = null;
        //            AppLogger.LogFatal("There is no Data.");
        //            return;
        //        }
        //        else
        //        {
        //            nInvoiceID = 0;
        //            nInvoiceID = _oInvoiceReverse.InvoiceID;
        //            lblInvoiceNo.Text = _oInvoiceReverse.InvoiceNo;
        //            lblInvoiceDate.Text = Convert.ToDateTime(_oInvoiceReverse.InvoiceDate).ToString("dd-MMM-yyyy");
        //            lblConsumerName.Text = _oInvoiceReverse.ConsumerName;
        //            lblConsumerAddress.Text = _oInvoiceReverse.ConsumerAddress;
        //            lblMobile.Text = _oInvoiceReverse.MobileNo;
        //            lblEmail.Text = _oInvoiceReverse.Email;
        //            _Amt = 0;
        //            _DisAmt = 0;
        //            _oTELLib = new TELLib();
        //            lblInvoiceAmount.Text = _oTELLib.TakaFormat(_oInvoiceReverse.InvoiceAmount);
        //            oSalesInvoice = new SalesInvoice();
        //            oSalesInvoice.InvoiceID = nInvoiceID;
        //            oSalesInvoice.RefreshSalesInvoiceItemForDataSending();

        //            dgvLineItem.Rows.Clear();
        //            foreach (SalesInvoiceItem oSalesInvoiceItem in oSalesInvoice)
        //            {
        //                DataGridViewRow oRow = new DataGridViewRow();
        //                oRow.CreateCells(dgvLineItem);
        //                oRow.Cells[0].Value = oSalesInvoiceItem.ProductCode.ToString();
        //                oRow.Cells[1].Value = oSalesInvoiceItem.ProductName.ToString();
        //                oRow.Cells[2].Value = _oTELLib.TakaFormat(oSalesInvoiceItem.UnitPrice).ToString();
        //                oRow.Cells[3].Value = _oTELLib.TakaFormat(oSalesInvoiceItem.PromotionalDiscount).ToString();
        //                oRow.Cells[4].Value = oSalesInvoiceItem.Quantity.ToString();
        //                oRow.Cells[5].Value = oSalesInvoiceItem.FreeQty.ToString();

        //                dgvLineItem.Rows.Add(oRow);
        //                _Amt = _Amt + oSalesInvoiceItem.UnitPrice * oSalesInvoiceItem.Quantity;
        //                _DisAmt = _DisAmt + oSalesInvoiceItem.PromotionalDiscount;
        //            }
        //            lblRetailSalesAmt.Text = _oTELLib.TakaFormat(_Amt);
        //            lblDiscount.Text = _oTELLib.TakaFormat(oSalesInvoice.Discount + _DisAmt);

        //            _oRetailSalesInvoice = new RetailSalesInvoice();
        //            _oRetailSalesInvoice.InvoiceID = oSalesInvoice.InvoiceID;
        //            _oRetailSalesInvoice.GetSalesInvoiceCharge();

        //            lblInstallChange.Text = _oTELLib.TakaFormat(_oRetailSalesInvoice.InstallationCharge);
        //            lblFreightCharge.Text = _oTELLib.TakaFormat(_oRetailSalesInvoice.FreightCharge);
        //            lblOthersCharge.Text = _oTELLib.TakaFormat(_oRetailSalesInvoice.OtherCharge);


        //            txtRefInvoiceNo.ForeColor = System.Drawing.Color.Empty;
        //            txtRefInvoiceNo.Enabled = false;
        //        }
        //    }
        //    else
        //    {
        //        lblInvoiceNo.Text = "";
        //        lblInvoiceDate.Text = "";
        //        lblConsumerName.Text = "";
        //        lblConsumerAddress.Text = "";
        //        lblMobile.Text = "";
        //        lblEmail.Text = "";
        //        dgvLineItem.Rows.Clear();
        //        lblInstallChange.Text = "";
        //        lblFreightCharge.Text = "";
        //        lblOthersCharge.Text = "";
        //        lblRetailSalesAmt.Text = "";
        //        lblDiscount.Text = "";
        //        lblInvoiceAmount.Text = "";

        //    }
        //}

        private void txtRefInvoiceNo_TextChanged(object sender, EventArgs e)
        {

            _oInvoiceReverse = new InvoiceReverse();
            txtRefInvoiceNo.ForeColor = System.Drawing.Color.Red;

            if (txtRefInvoiceNo.Text.Length == 13)
            {
                DBController.Instance.OpenNewConnection();
                _oInvoiceReverse.RefreshByInvoiceNoHO(txtRefInvoiceNo.Text.Trim());
                if (_oInvoiceReverse.InvoiceNo == null)
                {
                    _oInvoiceReverse = null;
                    AppLogger.LogFatal("There is no Data.");
                    return;
                }
                else
                {
                    nInvoiceID = 0;
                    nInvoiceID = _oInvoiceReverse.InvoiceID;
                    lblInvoiceNo.Text = _oInvoiceReverse.InvoiceNo;
                    lblInvoiceDate.Text = Convert.ToDateTime(_oInvoiceReverse.InvoiceDate).ToString("dd-MMM-yyyy");
                    lblConsumerName.Text = _oInvoiceReverse.ConsumerName;
                    lblConsumerAddress.Text = _oInvoiceReverse.ConsumerAddress;
                    lblMobile.Text = _oInvoiceReverse.MobileNo;
                    lblEmail.Text = _oInvoiceReverse.Email;
                    _Amt = 0;
                    _DisAmt = 0;
                    _oTELLib = new TELLib();
                    lblInvoiceAmount.Text = _oTELLib.TakaFormat(_oInvoiceReverse.InvoiceAmount);
                    oSalesInvoice = new SalesInvoice();
                    oSalesInvoice.InvoiceID = nInvoiceID;
                    oSalesInvoice.RefreshSalesInvoiceItemForDataSending2(nReverseID,nWarehouseID);//

                    dgvLineItem1.Rows.Clear();
                    foreach (SalesInvoiceItem oSalesInvoiceItem in oSalesInvoice)
                    {
                        DataGridViewRow oRow = new DataGridViewRow();
                        oRow.CreateCells(dgvLineItem1);


                        oRow.Cells[0].Value = oSalesInvoiceItem.ProductName.ToString();
                        oRow.Cells[1].Value = oSalesInvoiceItem.ProductSerial.ToString();
                        oRow.Cells[2].Value = Enum.GetName(typeof(Dictionary.StockType), oSalesInvoiceItem.StockType);
                        oRow.Cells[3].Value = Enum.GetName(typeof(Dictionary.POSUnsoldDefectiveProductType), oSalesInvoiceItem.DefectiveType);
                        oRow.Cells[4].Value = oSalesInvoiceItem.FaultDescription;
                        oRow.Cells[5].Value = oSalesInvoiceItem.FaultRemarks;
                        oRow.Cells[6].Value = oSalesInvoiceItem.Reason;
                        oRow.Cells[7].Value = oSalesInvoiceItem.JobNo;
                        oRow.Cells[8].Value = oSalesInvoiceItem.ProductID.ToString();

                        if (oSalesInvoiceItem.StockType == 1)
                        {
                            oRow.Cells[3].Style.BackColor = System.Drawing.Color.LightGray;
                            oRow.Cells[4].Style.BackColor = System.Drawing.Color.LightGray;
                            oRow.Cells[5].Style.BackColor = System.Drawing.Color.LightGray;
                            oRow.Cells[6].Style.BackColor = System.Drawing.Color.LightGray;
                            oRow.Cells[7].Style.BackColor = System.Drawing.Color.LightGray;
                        }

                        dgvLineItem1.Rows.Add(oRow);

                        _Amt = _Amt + oSalesInvoiceItem.UnitPrice * oSalesInvoiceItem.Quantity;
                        _DisAmt = _DisAmt + oSalesInvoiceItem.PromotionalDiscount;
                    }
                    lblRetailSalesAmt.Text = _oTELLib.TakaFormat(_Amt);
                    lblDiscount.Text = _oTELLib.TakaFormat(oSalesInvoice.Discount + _DisAmt);

                    _oRetailSalesInvoice = new RetailSalesInvoice();
                    _oRetailSalesInvoice.InvoiceID = oSalesInvoice.InvoiceID;
                    _oRetailSalesInvoice.GetSalesInvoiceCharge();

                    lblInstallChange.Text = _oTELLib.TakaFormat(_oRetailSalesInvoice.InstallationCharge);
                    lblFreightCharge.Text = _oTELLib.TakaFormat(_oRetailSalesInvoice.FreightCharge);
                    lblOthersCharge.Text = _oTELLib.TakaFormat(_oRetailSalesInvoice.OtherCharge);


                    txtRefInvoiceNo.ForeColor = System.Drawing.Color.Empty;
                    txtRefInvoiceNo.Enabled = false;
                }
            }
            else
            {
                lblInvoiceNo.Text = "";
                lblInvoiceDate.Text = "";
                lblConsumerName.Text = "";
                lblConsumerAddress.Text = "";
                lblMobile.Text = "";
                lblEmail.Text = "";
                dgvLineItem1.Rows.Clear();
                lblInstallChange.Text = "";
                lblFreightCharge.Text = "";
                lblOthersCharge.Text = "";
                lblRetailSalesAmt.Text = "";
                lblDiscount.Text = "";
                lblInvoiceAmount.Text = "";

            }
        }
        public bool UIValidation()
        {
            if (_nType == (int)Dictionary.ReverseStatus.Recommended)
            {
                if (txtRecommend.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Recommend", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRecommend.Focus();
                    return false;
                }
            }
            else if (_nType == (int)Dictionary.ReverseStatus.Approved)
            {
                if (txtApprovedCommends.Text.Trim() == "")
                {
                    MessageBox.Show("Please Enter Approved Comments", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtApprovedCommends.Focus();
                    return false;
                }
            }

            return true;
        }

        private void btnApproved_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                _oInvoiceReverse = new InvoiceReverse();

                _oInvoiceReverse.ReverseID = nReverseID;
                _oInvoiceReverse.WarehouseID = nWarehouseID;
                _oInvoiceReverse.InvoiceNo = lblInvoiceNo.Text;
                _oInvoiceReverse.Recommend = txtRecommend.Text;
                _oInvoiceReverse.RecommendBy = Utility.UserId;
                _oInvoiceReverse.RecommendDate = DateTime.Now;
                _oInvoiceReverse.ApprovedCommand = txtApprovedCommends.Text;
                _oInvoiceReverse.ApprovedUserID = Utility.UserId;
                _oInvoiceReverse.ApprovedDate = DateTime.Now;
                if (_nType == (int)Dictionary.ReverseStatus.Recommended)
                {
                    _oInvoiceReverse.Status = (int)Dictionary.ReverseStatus.Recommended;
                }
                else if (_nType == (int)Dictionary.ReverseStatus.Approved)
                {
                    _oInvoiceReverse.Status = (int)Dictionary.ReverseStatus.Approved;
                    foreach (DataGridViewRow oItemRow in dgvLineItem1.Rows)
                    {
                        if (oItemRow.Index < dgvLineItem1.Rows.Count)
                        {
                            if (oItemRow.Cells[2].Value.ToString() == Dictionary.StockType.Used.ToString())
                            {
                                UnsoldDefectiveProduct oUnsoldDefectiveProduct = new UnsoldDefectiveProduct();
                                if (!DBController.Instance.CheckConnection())
                                {
                                    DBController.Instance.OpenNewConnection();
                                }
                               
                               
                                oUnsoldDefectiveProduct.WarehouseID = nWarehouseID;
                                oUnsoldDefectiveProduct.ProductID = int.Parse(oItemRow.Cells[8].Value.ToString());
                                oUnsoldDefectiveProduct.BarcodeSL = oItemRow.Cells[1].Value.ToString();
                                oUnsoldDefectiveProduct.OriginalSL = oItemRow.Cells[1].Value.ToString();
                                if(oItemRow.Cells[3].Value.ToString()=="Functional")
                                    oUnsoldDefectiveProduct.DefectiveType = 2;
                                else
                                    oUnsoldDefectiveProduct.DefectiveType = 1;
                                oUnsoldDefectiveProduct.Fault = oItemRow.Cells[4].Value.ToString();
                                oUnsoldDefectiveProduct.Reason = oItemRow.Cells[6].Value.ToString();
                                oUnsoldDefectiveProduct.Remarks = oItemRow.Cells[5].Value.ToString();
                                oUnsoldDefectiveProduct.Status = (int)Dictionary.POSUnsouldDefectiveProductStatusNew.Create;
                                oUnsoldDefectiveProduct.CreateUserID = Utility.UserId;
                                oUnsoldDefectiveProduct.CreateDate = DateTime.Now;
                                oUnsoldDefectiveProduct.RefTranNo = lblInvoiceNo.Text;
                                oUnsoldDefectiveProduct.RefTranDate = Convert.ToDateTime(lblInvoiceDate.Text);
                                oUnsoldDefectiveProduct.JobNo = oItemRow.Cells[7].Value.ToString();

                                oUnsoldDefectiveProduct.ProposeDicAmount = 0;


                                try
                                {
                                    DBController.Instance.BeginNewTransaction();
                                    oUnsoldDefectiveProduct.InsertDefectiveProductForReverseInvoice(nWarehouseID);

                                    DBController.Instance.CommitTran();
                                    MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.Close();

                                }
                                catch (Exception ex)
                                {
                                    DBController.Instance.RollbackTransaction();
                                    MessageBox.Show(ex.Message, "Error!!!");
                                }
                            }
                        }
                    }
                }
                else if (_nType == (int)Dictionary.ReverseStatus.Reject)
                {
                    _oInvoiceReverse.Status = (int)Dictionary.ReverseStatus.Reject;
                }
                try
                {
                    DBController.Instance.BeginNewTransaction();

                    if (_nType == (int)Dictionary.ReverseStatus.Recommended)
                    {

                        _oInvoiceReverse.UpdateRecommendStatus();
                    }
                    else if (_nType == (int)Dictionary.ReverseStatus.Approved)
                    {
                        _oInvoiceReverse.UpdateApprovedStatus();
                    }
                    else if (_nType == (int)Dictionary.ReverseStatus.Reject)
                    {
                        _oInvoiceReverse.UpdateRejectStatus();
                    }

                    if (_oInvoiceReverse.Status == (int)Dictionary.ReverseStatus.Approved || _oInvoiceReverse.Status == (int)Dictionary.ReverseStatus.Reject)
                    {
                        DataTran oDataTran = new DataTran();
                        oDataTran.TableName = "t_InvoiceReverse";
                        oDataTran.DataID = Convert.ToInt32(_oInvoiceReverse.ReverseID);
                        oDataTran.WarehouseID = nWarehouseID;
                        oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                        oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                        oDataTran.BatchNo = 0;

                        if (oDataTran.CheckData() == false)
                        {
                            oDataTran.AddForTDPOS();
                        }
                    }

                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Save Successfully ", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmReverseApproval_Load(object sender, EventArgs e)
        {
            LoadCombo();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Library;
using CJ.Class.POS;


namespace CJ.POS
{
    public partial class frmExchangeOfferMoneyReceipt : Form
    {
        TELLib _oTELLib;
        SystemInfo _oSystemInfo;
        int nJobID = 0;
        int nMoneyReceiptID = 0;
        string sMRNo = "";
        ExchangeOfferMR _oExchangeOfferMR;
        ExchangeOfferVenderTran _oExchangeOfferVenderTran;
        int nVenderID = 0;

        public frmExchangeOfferMoneyReceipt()
        {
            InitializeComponent();
        }
        public void ShowDialog(ExchangeOfferJob oExchangeOfferJob)
        {
            this.Tag = oExchangeOfferJob;
            nJobID = oExchangeOfferJob.JobID;
            nVenderID = oExchangeOfferJob.AssignedVenderID;
            lblJobNo.Text = oExchangeOfferJob.JobNo;
            lblContactMode.Text = oExchangeOfferJob.ContactModeName;
            lblCustomerName.Text = oExchangeOfferJob.CustomerName;
            lblContactDate.Text = oExchangeOfferJob.ContactDate.ToString("dd-MMM-yyyy");
            lblAddress.Text = oExchangeOfferJob.Address;
            lblContactNo.Text = oExchangeOfferJob.ContactNo;
            lblEmail.Text = oExchangeOfferJob.Email;
            lblVenderName.Text = oExchangeOfferJob.VenderName;
            lblAssignDate.Text = oExchangeOfferJob.AssignDate.ToString("dd-MMM-yyyy");

            _oTELLib = new TELLib();
            txtBalance.Text = _oTELLib.TakaFormat(oExchangeOfferJob.Balance);

            //oExchangeOfferJob.GetExchengedItem(nJobID);

            //foreach (ExchangeOfferJobDetail oExchangeOfferJobDetail in oExchangeOfferJob)
            //{
            //    DataGridViewRow oRow = new DataGridViewRow();
            //    oRow.CreateCells(dgvExchangedProduct);
            //    oRow.Cells[0].Value = oExchangeOfferJobDetail.ProductTypeName.ToString();
            //    oRow.Cells[1].Value = oExchangeOfferJobDetail.ProductDetail.ToString();
            //    oRow.Cells[2].Value = oExchangeOfferJobDetail.ProductSize.ToString();
            //    oRow.Cells[3].Value = oExchangeOfferJobDetail.BrandName.ToString();
            //    oRow.Cells[4].Value = oExchangeOfferJobDetail.HaveRemort.ToString();
            //    oRow.Cells[5].Value = oExchangeOfferJobDetail.ConditionName.ToString();
            //    oRow.Cells[6].Value = oExchangeOfferJobDetail.Quantity.ToString();
            //    dgvExchangedProduct.Rows.Add(oRow);

            //}

            this.ShowDialog();
        }
        private bool validateUIInput()
        {
            double _Balance = 0;
            double _Amount = 0;
            _Balance = Convert.ToDouble(txtBalance.Text);
            _Amount = Convert.ToDouble(txtAmount.Text);

            if (_Amount > _Balance)
            {
                MessageBox.Show("Insufficient Balance", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return false;
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();

        }
        private void Save()
        {
            if (validateUIInput())
            {
                if (this.Tag != null)
                {
                    _oExchangeOfferVenderTran = new ExchangeOfferVenderTran();
                    _oExchangeOfferMR = new ExchangeOfferMR();
                    _oExchangeOfferMR.JobID = nJobID;
                    DBController.Instance.OpenNewConnection();
                    _oSystemInfo = new SystemInfo();
                    _oSystemInfo.Refresh();
                    _oExchangeOfferMR.CreateWHID = _oSystemInfo.WarehouseID;
                    _oExchangeOfferMR.Amount = Convert.ToDouble(txtAmount.Text);
                    _oExchangeOfferMR.Remarks = txtRemarks.Text;
                    _oExchangeOfferMR.CreateUserID = Utility.UserId;
                    _oExchangeOfferMR.CreateDate = DateTime.Now.Date;
                    _oExchangeOfferMR.Status = (int)Dictionary.ExchangeOfferMRStatus.Active;

                    
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        _oExchangeOfferMR.Add();

                        SystemInfo oSystemInfo = new SystemInfo();
                        oSystemInfo.Refresh();
                        DataTran oDataTran = new DataTran();
                        oDataTran.TableName = "t_ExchangeOfferMR";
                        oDataTran.DataID = Convert.ToInt32(_oExchangeOfferMR.MoneyReceiptID);
                        oDataTran.WarehouseID = oSystemInfo.WarehouseID;
                        oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                        oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                        oDataTran.BatchNo = 0;

                        if (oDataTran.CheckData() == false)
                        {
                            oDataTran.AddForTDPOS();
                        }

                        _oExchangeOfferVenderTran.VenderTranNo = _oExchangeOfferMR.MoneyReceiptNo;
                        _oExchangeOfferVenderTran.VenderTranDate = _oExchangeOfferMR.CreateDate;
                        _oExchangeOfferVenderTran.TranSide = (int)Dictionary.TransectionSide.DEBIT;
                        _oExchangeOfferVenderTran.Type = (int)Dictionary.ExchangeOfferDepositType.Money_Receipt;
                        _oExchangeOfferVenderTran.FromVenderID = nVenderID;
                        _oExchangeOfferVenderTran.ToVenderID = -1;
                        _oExchangeOfferVenderTran.Amount = Convert.ToDouble(txtAmount.Text);
                        _oExchangeOfferVenderTran.Remarks = _oExchangeOfferMR.Remarks;
                        _oExchangeOfferVenderTran.CreateDate = DateTime.Now.Date;
                        _oExchangeOfferVenderTran.CreateUserID = Utility.UserId;
                        _oExchangeOfferVenderTran.AddFromMR();

                        ExchangeOfferVender _oExchangeOfferVender = new ExchangeOfferVender();
                        _oExchangeOfferVender.VenderID = nVenderID;
                        _oExchangeOfferVender.Balance = Convert.ToDouble(txtAmount.Text);
                        _oExchangeOfferVender.UpdateChildBalanceByType((int)Dictionary.ExchangeOfferDepositType.Money_Receipt);


                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Save Successfully. MR No: " + _oExchangeOfferMR.MoneyReceiptNo, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                }


                else
                {
                    _oExchangeOfferMR = new ExchangeOfferMR();
                    _oExchangeOfferMR.MoneyReceiptID = nMoneyReceiptID;
                    _oExchangeOfferMR.JobID = nJobID;
                    _oExchangeOfferMR.Amount = Convert.ToDouble(txtAmount.Text);
                    _oExchangeOfferMR.Remarks = txtRemarks.Text;
                    _oExchangeOfferMR.UpdateUserID = Utility.UserId;
                    _oExchangeOfferMR.UpdateDate = DateTime.Now.Date;
                    _oExchangeOfferMR.Status = (int)Dictionary.ExchangeOfferMRStatus.Active;

                    try
                    {

                        DBController.Instance.BeginNewTransaction();
                        _oExchangeOfferMR.Edit();
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Update Successfully. MR No: " + sMRNo, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
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

namespace CJ.Win.CSD
{
    public partial class frmExchangeOfferMoneyReceiptTransfer : Form
    {
        Showrooms _oShowrooms;
        TELLib _oTELLib;
        int nMRID = 0;
        int nCreateWHID = 0;
        int nJobID = 0;
        ExchangeOfferMR _oExchangeOfferMR;
        string sMRNo = "";

        public frmExchangeOfferMoneyReceiptTransfer()
        {
            InitializeComponent();
        }

        private void frmExchangeOfferMoneyReceiptTransfer_Load(object sender, EventArgs e)
        {
            LoadCombo();
        }
        public void ShowDialog(ExchangeOfferMR oExchangeOfferMR)
        {
            this.Tag = oExchangeOfferMR;

            nMRID = oExchangeOfferMR.MoneyReceiptID;
            nCreateWHID = oExchangeOfferMR.CreateWHID;
            sMRNo = oExchangeOfferMR.MoneyReceiptNo;
            nJobID = oExchangeOfferMR.JobID;
            lblMoneyReceiptNo.Text = oExchangeOfferMR.MoneyReceiptNo;
            lblCreateWH.Text = oExchangeOfferMR.CreateWHName;
            lblCreateDate.Text = oExchangeOfferMR.CreateDate.ToString("dd-MMM-yyyy");
            _oTELLib = new TELLib();
            lblAmount.Text = _oTELLib.TakaFormat(oExchangeOfferMR.Amount);
            lblRemarks.Text = oExchangeOfferMR.Remarks;

            this.ShowDialog();
        }
        private void LoadCombo()
        {
            DBController.Instance.OpenNewConnection();
            _oShowrooms = new Showrooms();
            _oShowrooms.Refresh();
            cmbOutlet.Items.Add("-- Select --");
            foreach (Showroom oShowroom in _oShowrooms)
            {
                cmbOutlet.Items.Add(oShowroom.ShowroomName + "[" + oShowroom.ShowroomCode + "]");
            }
            cmbOutlet.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool validateUIInput()
        {
            
            if (cmbOutlet.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select an Outlet.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbOutlet.Focus();
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
                _oExchangeOfferMR = new ExchangeOfferMR();
                _oExchangeOfferMR.MoneyReceiptID = nMRID;
                _oExchangeOfferMR.JobID = nJobID;
                _oExchangeOfferMR.CreateWHID = nCreateWHID;
                _oExchangeOfferMR.TransferWHID = _oShowrooms[cmbOutlet.SelectedIndex - 1].WarehouseID;
                _oExchangeOfferMR.TransferUserID = Utility.UserId;
                _oExchangeOfferMR.TransferDate = DateTime.Now.Date;
                _oExchangeOfferMR.Status = (int)Dictionary.ExchangeOfferMRStatus.Transfered;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oExchangeOfferMR.TransferMR();

                    DataTran oDataTran = new DataTran();
                    oDataTran.TableName = "t_ExchangeOfferMR";
                    oDataTran.DataID = nMRID;
                    oDataTran.WarehouseID = nCreateWHID;
                    oDataTran.TransferType = (int)Dictionary.DataTransferType.Edit;
                    oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                    oDataTran.BatchNo = 0;

                    if (oDataTran.CheckDataByWHID() == false)
                    {
                        oDataTran.AddForTDPOS();
                    }

                    DataTran oDTran = new DataTran();
                    oDTran.TableName = "t_ExchangeOfferMR";
                    oDTran.DataID = nMRID;
                    oDTran.WarehouseID = _oShowrooms[cmbOutlet.SelectedIndex - 1].WarehouseID;
                    oDTran.TransferType = (int)Dictionary.DataTransferType.Add;
                    oDTran.IsDownload = (int)Dictionary.IsDownload.No;
                    oDTran.BatchNo = 0;

                    if (oDTran.CheckDataByWHID() == false)
                    {
                        oDTran.AddForTDPOS();
                    }


                    DataTran oEOJob = new DataTran();
                    oEOJob.TableName = "t_ExchangeOfferJob";
                    oEOJob.DataID = nJobID;
                    oEOJob.WarehouseID = _oShowrooms[cmbOutlet.SelectedIndex - 1].WarehouseID;
                    oEOJob.TransferType = (int)Dictionary.DataTransferType.Add;
                    oEOJob.IsDownload = (int)Dictionary.IsDownload.No;
                    oEOJob.BatchNo = 0;

                    if (oEOJob.CheckDataByWHID() == false)
                    {
                        oEOJob.AddForTDPOS();
                    }
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Transfer Successfully. MR No: " + sMRNo, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
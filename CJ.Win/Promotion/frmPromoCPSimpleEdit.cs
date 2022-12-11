using CJ.Class;
using CJ.Class.Promotion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CJ.Win.Promotion
{
    public partial class frmPromoCPSimpleEdit : Form
    {
        int nConsumerPromoID;
        string sWarehouseList = "";
        public bool _IsTrue = false;
        int _nStatus=0;

        public frmPromoCPSimpleEdit(ConsumerPromotion oConsumerPromotion)
        {
            InitializeComponent();
            nConsumerPromoID = oConsumerPromotion.ConsumerPromoID;
            sWarehouseList = oConsumerPromotion.CPSimpleWarehouse;
            txtPromoNo.Text = oConsumerPromotion.ConsumerPromoNo;
            txtPromoName.Text = oConsumerPromotion.ConsumerPromoName;
            dtFromDate.Value = oConsumerPromotion.FromDate;
            dtToDate.Value = oConsumerPromotion.ToDate;
            if (oConsumerPromotion.IsActive == (int)Dictionary.IsActive.Active)
            {
                chkIsActive.Checked = true;
            }
            else
            {
                chkIsActive.Checked = false;
            }

            _nStatus= oConsumerPromotion.Status;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (dtToDate.Value.Date < dtFromDate.Value.Date)
            {
                MessageBox.Show("To date must be greater than or equal of from date", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ConsumerPromotion oConsumerPromotion = new ConsumerPromotion();
            oConsumerPromotion.ConsumerPromoName = txtPromoName.Text;
            oConsumerPromotion.ConsumerPromoID = nConsumerPromoID;
            oConsumerPromotion.FromDate = dtFromDate.Value.Date;
            oConsumerPromotion.ToDate = dtToDate.Value.Date;
            if (chkIsActive.Checked)
            {
                oConsumerPromotion.IsActive = (int)Dictionary.YesOrNoStatus.YES;
            }
            else
            {
                oConsumerPromotion.IsActive = (int)Dictionary.YesOrNoStatus.NO;
            }

            oConsumerPromotion.UpdateUserID = Utility.UserId;
            oConsumerPromotion.UpdateDate = DateTime.Now;

            try
            {
                DBController.Instance.BeginNewTransaction();

                oConsumerPromotion.UpdateDateCPSimple();

                if (_nStatus == (int)Dictionary.SalesPromStatus.Approved)
                {
                    SPWarehouses oShowrooms = new SPWarehouses();
                    oShowrooms.GetPromoCPandSimpleWarehouse(sWarehouseList);

                    foreach (SPWarehouse oShowroom in oShowrooms)
                    {
                        CJ.Class.POS.DataTran oDataTran = new CJ.Class.POS.DataTran();
                        oDataTran.TableName = "t_PromoCPSimple";
                        oDataTran.DataID = Convert.ToInt32(oConsumerPromotion.ConsumerPromoID);
                        oDataTran.WarehouseID = oShowroom.WarehouseID;
                        oDataTran.TransferType = (int)Dictionary.DataTransferType.Edit;
                        oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                        oDataTran.BatchNo = 0;
                        if (oDataTran.CheckDataByWHID() == false)
                        {
                            oDataTran.AddForTDPOS();
                        }
                    }
                }

                DBController.Instance.CommitTransaction();
                _IsTrue = true;
                MessageBox.Show("You have successfully update the transaction: " + txtPromoNo.Text, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

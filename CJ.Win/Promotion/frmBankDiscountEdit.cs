using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Admin;
using CJ.Class.Promotion;
using System.Collections.Generic;
using CJ.Class.POS;
using CJ.Class.Library;

namespace CJ.Win.Promotion
{
    public partial class frmBankDiscountEdit : Form
    {

        Banks oBanks;
        ProductGroups oProductGroups;
        Brands oBrands;
        int _nStatus = 0;
        DateTime _dFromDate;
        DateTime _dToDate;
        ProductGroups _oPG;
        ProductGroups _oMAG;
        ProductGroups _oASG;
        ProductGroups _oAG;
        public bool _bActionSave = false;

        public frmBankDiscountEdit(int nStatus)
        {
                _nStatus = nStatus;
                InitializeComponent();
        }

        public void ShowDialog(PromoDiscountBank oDiscountBank)
        {
            this.Tag = oDiscountBank;

            PromoDiscountBanks _oDiscountBanks = new PromoDiscountBanks();

            int agId = oDiscountBank.AGID;

            _oDiscountBanks.GetParent(agId);

            foreach (PromoDiscountBank oDiscountBnk in _oDiscountBanks)
            {
                lblPG.Text = oDiscountBnk.PGName;
                lblMAG.Text = oDiscountBnk.MAGName;
                lblASG.Text = oDiscountBnk.ASGName;
                lblAG.Text = oDiscountBnk.AGName;
            }

            lblBankName.Text = oDiscountBank.BankName;
            lblBrand.Text = oDiscountBank.Brand;
            txtDiscountPercentage.Text = oDiscountBank.DiscountPercent.ToString();
            dtFromDate.Value = oDiscountBank.FromDate;
            dtToDate.Value = oDiscountBank.ToDate;
            if (oDiscountBank.IsActive == (int)Dictionary.YesOrNoStatus.YES)
            {
                chkIsActive.Checked = true;
            }
            else
            {
                chkIsActive.Checked = false;
            }
            //txtDiscount.Enabled = false;
            this.ShowDialog();
        }

        private void Save()
        {
            PromoDiscountBank oDiscountBank = (PromoDiscountBank)this.Tag;
            oDiscountBank.FromDate = dtFromDate.Value.Date;
            oDiscountBank.ToDate = dtToDate.Value.Date;
            if (chkIsActive.Checked)
            {
                oDiscountBank.IsActive = (int)Dictionary.YesOrNoStatus.YES;
            }
            else
            {
                oDiscountBank.IsActive = (int)Dictionary.YesOrNoStatus.NO;
            }
            if (_nStatus == (int)Dictionary.BankDiscountStatus.Create)
            {
                oDiscountBank.Status = (int)Dictionary.BankDiscountStatus.Create;
            }
            else if (_nStatus == (int)Dictionary.BankDiscountStatus.Approved)
            {
                oDiscountBank.Status = (int)Dictionary.BankDiscountStatus.Approved;
            }
            oDiscountBank.CreateUserID= Utility.UserId;
            oDiscountBank.CreateDate = DateTime.Now.Date;
            oDiscountBank.UpdateUserID= Utility.UserId;
            oDiscountBank.UpdateDate = DateTime.Now.Date;

            try
            {
                DBController.Instance.BeginNewTransaction();
                oDiscountBank.EditBybankDiscount();
                Showrooms oShowrooms = new Showrooms();
                oShowrooms.Refresh();
                foreach (Showroom oShowroom in oShowrooms)
                {
                    DataTran oDataTran = new DataTran();
                    oDataTran.TableName = "t_PromoDiscountBank";
                    oDataTran.DataID = Convert.ToInt32(oDiscountBank.BankDiscountID);
                    oDataTran.WarehouseID = oShowroom.WarehouseID;
                    oDataTran.TransferType = (int)Dictionary.DataTransferType.Edit;
                    oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                    oDataTran.BatchNo = 0;
                    if (oDataTran.CheckDataByWHID() == false)
                    {
                        oDataTran.AddForTDPOS();
                    }
                }

                //if (_dFromDate.Date == dtFromDate.Value.Date)
                //{
                //    oDiscountBank.EditBybankDiscount();
                //    Showrooms oShowrooms = new Showrooms();
                //    oShowrooms.Refresh();
                //    foreach (Showroom oShowroom in oShowrooms)
                //    {
                //        DataTran oDataTran = new DataTran();
                //        oDataTran.TableName = "t_PromoDiscountBank";
                //        oDataTran.DataID = Convert.ToInt32(oDiscountBank.BankDiscountID);
                //        oDataTran.WarehouseID = oShowroom.WarehouseID;
                //        oDataTran.TransferType = (int)Dictionary.DataTransferType.Edit;
                //        oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                //        oDataTran.BatchNo = 0;
                //        if (oDataTran.CheckData() == false)
                //        {
                //            oDataTran.AddForTDPOS();
                //        }
                //    }
                //}
                //else
                //{
                //    oDiscountBank.UpdateIsActive();
                //    Showrooms oShowrooms = new Showrooms();
                //    oShowrooms.Refresh();
                //    foreach (Showroom oShowroom in oShowrooms)
                //    {
                //        DataTran oDataTran = new DataTran();
                //        oDataTran.TableName = "t_PromoDiscountBank";
                //        oDataTran.DataID = Convert.ToInt32(oDiscountBank.BankDiscountID);
                //        oDataTran.WarehouseID = oShowroom.WarehouseID;
                //        oDataTran.TransferType = (int)Dictionary.DataTransferType.Edit;
                //        oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                //        oDataTran.BatchNo = 0;
                //        if (oDataTran.CheckData() == false)
                //        {
                //            oDataTran.AddForTDPOS();
                //        }
                //    }
                //    oDiscountBank.Add();
                //    foreach (Showroom oShowroom in oShowrooms)
                //    {
                //        DataTran oDataTran = new DataTran();
                //        oDataTran.TableName = "t_PromoDiscountBank";
                //        oDataTran.DataID = Convert.ToInt32(oDiscountBank.BankDiscountID);
                //        oDataTran.WarehouseID = oShowroom.WarehouseID;
                //        oDataTran.TransferType = (int)Dictionary.DataTransferType.Edit;
                //        oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                //        oDataTran.BatchNo = 0;
                //        if (oDataTran.CheckData() == false)
                //        {
                //            oDataTran.AddForTDPOS();
                //        }
                //    }
                //}

                DBController.Instance.CommitTransaction();
                MessageBox.Show("You have successfully update the transaction: " + oDiscountBank.BankDiscountID, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            _bActionSave = true;
            this.Close();
        }

        private void frmBankDiscountEdit_Load(object sender, EventArgs e)
        {

        }

        private void txtDiscountPercentage_TextChanged(object sender, EventArgs e)
        {
            if (txtDiscountPercentage.Text.Trim() != "")
            {
                try
                {
                    double temp = Convert.ToDouble(txtDiscountPercentage.Text);

                }
                catch
                {
                    MessageBox.Show("Please input valid discount percentage ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiscountPercentage.Text = "";
                }

            }
        }
    }
}

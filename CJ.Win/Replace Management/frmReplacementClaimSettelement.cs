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
using CJ.Class.Report;
using CJ.Report;
using CJ.Report.DMS;
using CJ.Win.Security;

namespace CJ.Win.Replace_Management
{
    public partial class frmReplacementClaimSettelement : Form
    {
        ClaimSettlements oClaimSettlements = new ClaimSettlements();
        bool IsCheck = false;
       // int _nUIControl = 0;

        public frmReplacementClaimSettelement()
        {
            InitializeComponent();
           // _nUIControl = nUIControl;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                IsCheck = true;
                this.Close();
            }
        }

        private bool validateUIInput()
        {
            #region Input Information Validation


            for (int i = 0; i < lvwReplaceClaim.Items.Count; i++)
            {
                ListViewItem item = lvwReplaceClaim.Items[i];
                if (lvwReplaceClaim.Items[i].Checked == true)
                {
                    lvwReplaceClaim.Items[i].Selected = true;
                }

                //checkDuplicateValue = oClaimSettlements.CheckDuplicateData();

                //if (checkDuplicateValue == "Yes")
                //{
                //    MessageBox.Show("MAG Brand already exists", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    cmbBrand.Focus();
                //    return false;
                //}
            }


            //if (colClaimMonth.ListView.ToString() < DateTime.Today.Date)
            //{
            //    MessageBox.Show("Can't update backward date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    dtEffectiveDate.Focus();
            //    return false;
            //}


            //PromoDiscountMAGBrand oPromoDiscountMAGBrand = new PromoDiscountMAGBrand();


            //for (int i = 0; i < lvwMAG.Items.Count; i++)
            //{
            //    ListViewItem item = lvwMAG.Items[i];
            //    if (lvwMAG.Items[i].Checked == true)
            //    {
            //        oPromoDiscountMAGBrand.MAGID = Convert.ToInt32(item.SubItems[0].Text.ToString());
            //        oPromoDiscountMAGBrand.BrandID = oBrands[cmbBrand.SelectedIndex - 1].BrandID;
            //    }

            //    checkDuplicateValue = oPromoDiscountMAGBrand.CheckDuplicateData();

            //    if (checkDuplicateValue == "Yes")
            //    {
            //        MessageBox.Show("MAG Brand already exists", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        cmbBrand.Focus();
            //        return false;
            //    }

            //}

            #endregion

            return true;
        }

        //private void Save()
        //{
        //    ClaimSettlement _oClaimSettlement = (ClaimSettlement)lvwReplaceClaim.SelectedItems[0].Tag;
        //    ClaimSettlement oDClaimSettlement = new ClaimSettlement();
        //    string date = dateTimePicker1.Text;
        //    date = "01-" + date;
        //    dateTimePicker1.Value = DateTime.Parse(date);
        //    if (dateTimePicker1.Value > DateTime.Now)
        //    {
        //        MessageBox.Show("Date can not be taken", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }
        //    if (DateTime.Now.Year == dateTimePicker1.Value.Year)
        //    {
        //        if ((DateTime.Now.Month - dateTimePicker1.Value.Month) > 2)
        //        {
        //            MessageBox.Show("Date can not be taken", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }
        //    }
        //    if ((DateTime.Now.Year - dateTimePicker1.Value.Year) > 1)
        //    {
        //        MessageBox.Show("Date can not be taken", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }
        //    int flag = 0;
        //    if ((DateTime.Now.Year - dateTimePicker1.Value.Year) == 1)
        //    {
        //        if (DateTime.Now.Month == 1)
        //        {
        //            if ((DateTime.Now.Month - dateTimePicker1.Value.Month) == -11 || (DateTime.Now.Month - dateTimePicker1.Value.Month) == -10)
        //            {
        //                flag = 1;
        //            }
        //        }
        //        else if (DateTime.Now.Month == 2)
        //        {
        //            if ((DateTime.Now.Month - dateTimePicker1.Value.Month) == -10 || (DateTime.Now.Month - dateTimePicker1.Value.Month) == 1)
        //            {
        //                flag = 1;
        //            }
        //        }
        //        if (flag == 0)
        //        {
        //            MessageBox.Show("Date can not be taken", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //            return;
        //        }
        //    }


        //    oDClaimSettlement.ClaimDate = DateTime.Parse(date);
        //    oDClaimSettlement.TranID = _oClaimSettlement.TranID;
        //    try
        //    {
        //        oDClaimSettlement.editDate();
        //        MessageBox.Show("Date has edited successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        btnGetData.PerformClick();
        //        return;
        //    }
        //    int index = lvwReplaceClaim.SelectedItems[0].Index;
        //    btnGetData.PerformClick();
        //    lvwReplaceClaim.SelectedItems.Clear();
        //    lvwReplaceClaim.Items[index].Selected = true;
        //    //pnlDate.Hide();


        //    //if (this.Tag == null)
        //    //{


        //    //    ClaimSettlement oClaimSettlement = new ClaimSettlement();



        //    //    for (int i = 0; i < lvwReplaceClaim.Items.Count; i++)
        //    //    {
        //    //        ListViewItem item = lvwReplaceClaim.Items[i];
        //    //        if (lvwReplaceClaim.Items[i].Checked == true)
        //    //        {
        //    //            oPromoDiscountMAGBrand.MAGID = Convert.ToInt32(item.SubItems[0].Text.ToString());

        //    //            oClaimSettlement.RegionName=
        //    //            oPromoDiscountMAGBrand.BrandID = oBrands[cmbBrand.SelectedIndex - 1].BrandID;
        //    //            oPromoDiscountMAGBrand.EffectiveDate = dtEffectiveDate.Value.Date;
        //    //            oPromoDiscountMAGBrand.Remarks = txtRemarks.Text.ToString();

        //    //            oPromoDiscountMAGBrand.DiscountPercent = Convert.ToDouble(txtDiscount.Text.ToString());
        //    //            if (chkIsActive.Checked)
        //    //            {
        //    //                oPromoDiscountMAGBrand.IsActive = (int)Dictionary.YesOrNoStatus.YES;
        //    //            }
        //    //            else
        //    //            {
        //    //                oPromoDiscountMAGBrand.IsActive = (int)Dictionary.YesOrNoStatus.NO;
        //    //            }
        //    //            if (_nStatus == (int)Dictionary.BankDiscountStatus.Create)
        //    //            {
        //    //                oPromoDiscountMAGBrand.Status = (int)Dictionary.BankDiscountStatus.Create;
        //    //            }
        //    //            else
        //    //            {
        //    //                oPromoDiscountMAGBrand.Status = (int)Dictionary.BankDiscountStatus.Approved;
        //    //            }
        //    //            oPromoDiscountMAGBrand.CreateUserID = Utility.UserId;
        //    //            oPromoDiscountMAGBrand.CreateDate = DateTime.Now;

        //    //            try
        //    //            {
        //    //                DBController.Instance.BeginNewTransaction();

        //    //                oPromoDiscountMAGBrand.UpdateIsActiveForDuplicate((int)Dictionary.YesOrNoStatus.NO);

        //    //                oPromoDiscountMAGBrand.Add();
        //    //                Showrooms oShowrooms = new Showrooms();
        //    //                oShowrooms.Refresh();
        //    //                foreach (Showroom oShowroom in oShowrooms)
        //    //                {
        //    //                    DataTran oDataTran = new DataTran();
        //    //                    oDataTran.TableName = "t_PromoDiscountMAGBrand";
        //    //                    oDataTran.DataID = Convert.ToInt32(oPromoDiscountMAGBrand.DiscountID);
        //    //                    oDataTran.WarehouseID = oShowroom.WarehouseID;
        //    //                    oDataTran.TransferType = (int)Dictionary.DataTransferType.Edit;
        //    //                    oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
        //    //                    oDataTran.BatchNo = 0;
        //    //                    if (oDataTran.CheckDataByWHID() == false)
        //    //                    {
        //    //                        oDataTran.AddForTDPOS();
        //    //                    }

        //    //                }
        //    //                DBController.Instance.CommitTransaction();
        //    //            }
        //    //            catch (Exception ex)
        //    //            {
        //    //                DBController.Instance.RollbackTransaction();
        //    //                MessageBox.Show(ex.Message, "Error!!!");
        //    //            }


        //    //        }
        //    //    }

        //    //    MessageBox.Show("Your data has been updated successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    //}

        //    //else
        //    //{
        //    //    PromoDiscountMAGBrand oPromoDiscountMAGBrand = (PromoDiscountMAGBrand)this.Tag;
        //    //    // oDiscountBank.AGID = _oAG[cmbAG.SelectedIndex].PdtGroupID;
        //    //    oPromoDiscountMAGBrand.BrandID = oBrands[cmbBrand.SelectedIndex - 1].BrandID;
        //    //    oPromoDiscountMAGBrand.EffectiveDate = dtEffectiveDate.Value;
        //    //    oPromoDiscountMAGBrand.DiscountPercent = Convert.ToDouble(txtDiscount.Text.ToString());
        //    //    oPromoDiscountMAGBrand.Remarks = txtRemarks.Text.ToString();

        //    //    if (chkIsActive.Checked)
        //    //    {
        //    //        oPromoDiscountMAGBrand.IsActive = (int)Dictionary.YesOrNoStatus.YES;
        //    //    }
        //    //    else
        //    //    {
        //    //        oPromoDiscountMAGBrand.IsActive = (int)Dictionary.YesOrNoStatus.NO;
        //    //    }
        //    //    if (_nStatus == (int)Dictionary.BankDiscountStatus.Create)
        //    //    {
        //    //        oPromoDiscountMAGBrand.Status = (int)Dictionary.BankDiscountStatus.Create;
        //    //    }
        //    //    else if (_nStatus == (int)Dictionary.BankDiscountStatus.Approved)
        //    //    {
        //    //        oPromoDiscountMAGBrand.Status = (int)Dictionary.BankDiscountStatus.Approved;
        //    //    }
        //    //    oPromoDiscountMAGBrand.CreateUserID = Utility.UserId;
        //    //    oPromoDiscountMAGBrand.CreateDate = DateTime.Now;
        //    //    oPromoDiscountMAGBrand.UpdateUserID = Utility.UserId;
        //    //    oPromoDiscountMAGBrand.UpdateDate = DateTime.Now;

        //    //    try
        //    //    {
        //    //        DBController.Instance.BeginNewTransaction();

        //    //        if (_dEffectiveDate.Date == dtEffectiveDate.Value.Date)
        //    //        {
        //    //            oPromoDiscountMAGBrand.EditByMAGBrandWiseDiscount();
        //    //        }
        //    //        else
        //    //        {
        //    //            oPromoDiscountMAGBrand.UpdateIsActiveForDuplicate((int)Dictionary.YesOrNoStatus.NO);
        //    //            oPromoDiscountMAGBrand.Add();
        //    //        }

        //    //        DBController.Instance.CommitTransaction();
        //    //        MessageBox.Show("You have successfully updated the transaction : " + oPromoDiscountMAGBrand.DiscountID, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //    //    }
        //    //    catch (Exception ex)
        //    //    {
        //    //        DBController.Instance.RollbackTransaction();
        //    //        MessageBox.Show(ex.Message, "Error!!!");
        //    //    }
        //    //}

        //}

        private void Save()
        {


            for (int i = 0; i < lvwReplaceClaim.Items.Count; i++)
            {
                ListViewItem itm = lvwReplaceClaim.Items[i];
                if (lvwReplaceClaim.Items[i].Checked == true)
                {

                    ClaimSettlement oClaimSettlement = (ClaimSettlement)lvwReplaceClaim.Items[i].Tag;

                    oClaimSettlement.AddClaimDate();

                    //if (oClaimSettlement.ClaimDateCheck())
                    //{

                    //}
                }
                

            }
            MessageBox.Show("You Have Successfully Claim Data Updated. ", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

            DataLoadControl();
        }

       



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
           
            DataLoadControl();

        }

        private void DataLoadControl()
        {


            oClaimSettlements = new ClaimSettlements();
            lvwReplaceClaim.Items.Clear();

            DBController.Instance.OpenNewConnection();

            oClaimSettlements.RefreshReplacement(dtFromDate.Value.Date, dtToDate.Value.Date, IsCheck);
            this.Text = "Total  " + "[" + oClaimSettlements.Count + "]";

            foreach (ClaimSettlement oClaimSettlement in oClaimSettlements)
            {
                ListViewItem oItem = lvwReplaceClaim.Items.Add(oClaimSettlement.RegionName);
                oItem.SubItems.Add(oClaimSettlement.AreaName);
                oItem.SubItems.Add(oClaimSettlement.TerritoryName);
                oItem.SubItems.Add(oClaimSettlement.CustomerCode);
                oItem.SubItems.Add(oClaimSettlement.CustomerName);
                oItem.SubItems.Add(oClaimSettlement.CustomerTypeName);
                if (oClaimSettlement.ClaimDate != default(DateTime))
                    oItem.SubItems.Add(oClaimSettlement.ClaimDate.ToString("dd-MMM-yyyy"));
                else
                    oItem.SubItems.Add("-");
                //oItem.SubItems.Add(oClaimSettlement.ClaimDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oClaimSettlement.SettlementDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oClaimSettlement.SettlementType);
                oItem.SubItems.Add(oClaimSettlement.InvoiceAmount.ToString());
                oItem.SubItems.Add(oClaimSettlement.Remarks);
                oItem.SubItems.Add(oClaimSettlement.CustomerID.ToString());
                oItem.SubItems.Add(oClaimSettlement.InvoiceID.ToString());

                oItem.Tag = oClaimSettlement;
            }
           
        }

        private void btnChkAll_Click(object sender, EventArgs e)
        {
            int nCount = 0;
            if (btnChkAll.Text == "Checked All")
            {
                for (int i = 0; i < lvwReplaceClaim.Items.Count; i++)
                {

                    ListViewItem itm = lvwReplaceClaim.Items[i];
                    lvwReplaceClaim.Items[i].Checked = true;
                    nCount++;
                }
                if (nCount > 0)
                {
                    btnChkAll.Text = "Unchecked All";
                }
            }
            else
            {
                for (int i = 0; i < lvwReplaceClaim.Items.Count; i++)
                {
                    ListViewItem itm = lvwReplaceClaim.Items[i];
                    lvwReplaceClaim.Items[i].Checked = false;
                    nCount++;
                }
                if (nCount > 0)
                {
                    btnChkAll.Text = "Checked All";
                }
            }
        }

        private void btnChkAll_Click_1(object sender, EventArgs e)
        {
            int nCount = 0;
            if (btnChkAll.Text == "Checked All")
            {
                for (int i = 0; i < lvwReplaceClaim.Items.Count; i++)
                {

                    ListViewItem itm = lvwReplaceClaim.Items[i];
                    lvwReplaceClaim.Items[i].Checked = true;
                    nCount++;
                }
                if (nCount > 0)
                {
                    btnChkAll.Text = "Unchecked All";
                }
            }
            else
            {
                for (int i = 0; i < lvwReplaceClaim.Items.Count; i++)
                {
                    ListViewItem itm = lvwReplaceClaim.Items[i];
                    lvwReplaceClaim.Items[i].Checked = false;
                    nCount++;
                }
                if (nCount > 0)
                {
                    btnChkAll.Text = "Checked All";
                }
            }
        }

        private void frmReplacementClaimSettelement_Load(object sender, EventArgs e)
        {

        }

        private void lvwReplaceClaim_SelectedIndexChanged(object sender, EventArgs e)
        {
           // pnlDate.show();
        }
    }
}

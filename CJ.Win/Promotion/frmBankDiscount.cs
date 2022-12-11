using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Promotion;
using System.Collections.Generic;
using CJ.Class.POS;
using CJ.Class.Library;

namespace CJ.Win.Promotion 
{
    public partial class frmBankDiscount : Form
    {
        TELLib _oTELLib;
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
        DSPromotionContribution _oDSPromotionContribution = new DSPromotionContribution();
        public bool _bActionSave = false;

        PaymentModes _oPaymentModes;

        public frmBankDiscount(int nStatus)
        {
            _nStatus = nStatus;
            InitializeComponent();
        }

        private void frmBankDiscount_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                LoadCombos();
            }
        }
        private void LoadCombos()
        {

            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }


            //Load PG in combo
            _oPG = new ProductGroups();
            _oPG.Refresh(Dictionary.ProductGroupType.ProductGroup);
            cmbPG.Items.Clear();
            cmbPG.Items.Add("--ALL--");
            foreach (ProductGroup oProductGroup in _oPG)
            {
                cmbPG.Items.Add(oProductGroup.PdtGroupName);
            }
            cmbPG.SelectedIndex =0;

            //Load Banks
            oBanks = new Banks();
            oBanks.Refresh();
            cmbBank.Items.Clear();
            cmbBank.Items.Add("--ALL--");
            foreach (Bank oBank in oBanks)
            {
                cmbBank.Items.Add(oBank.Name);
            }
            cmbBank.SelectedIndex = 0;

            //Credit Card Type
            cmbCreditCardType.Items.Clear();
            cmbCreditCardType.Items.Add("--ALL--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CreditCardType)))
            {
                cmbCreditCardType.Items.Add(Enum.GetName(typeof(Dictionary.CreditCardType), GetEnum));
            }
            cmbCreditCardType.SelectedIndex = 0;


            oBrands = new Brands();
            oBrands.GetMasterBrand();
            cmbBrand.Items.Clear();
            cmbBrand.Items.Add("--ALL--");
            foreach (Brand oBrand in oBrands)
            {
                cmbBrand.Items.Add(oBrand.BrandDesc);
            }
            cmbBrand.SelectedIndex = 0;



            //Payment Mode
            _oPaymentModes = new PaymentModes();
            _oPaymentModes.Refresh();
            cmbPaymentMode.Items.Clear();
            foreach (PaymentMode oPaymentMode in _oPaymentModes)
            {
                cmbPaymentMode.Items.Add(oPaymentMode.PaymentModeName);
            }
            cmbPaymentMode.SelectedIndex = 0;
        }

        private bool validateUIInput()
        {
            #region Input Information Validation

            if (cmbPG.SelectedIndex == 0)
            {
                MessageBox.Show("Please select PG", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPG.Focus();
                return false;
            }

            if (cmbMAG.SelectedIndex == 0)
            {
                MessageBox.Show("Please select MAG", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMAG.Focus();
                return false;
            }

            if (cmbASG.SelectedIndex == 0)
            {
                MessageBox.Show("Please select ASG", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbASG.Focus();
                return false;
            }

            if (_oPaymentModes[cmbPaymentMode.SelectedIndex].PaymentModeID == 2 || _oPaymentModes[cmbPaymentMode.SelectedIndex].IsFinancialInstitution == 1)
            {
                if (cmbBank.SelectedIndex == 0)
                {
                    MessageBox.Show("Please select Bank", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbBank.Focus();
                    return false;
                }
            }

            if (cmbBrand.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Brand", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbBrand.Focus();
                return false;
            }


            if (txtDiscount.Text == "")
            {
                MessageBox.Show("Please enter Discount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiscount.Focus();
                return false;
            }
            if (dtFromDate.Value.Date < DateTime.Today.Date)
            {
                MessageBox.Show("Can't update backward date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtFromDate.Focus();
                return false;
            }


            for (int i = 0; i < lvwAG.Items.Count; i++)
            {
                ListViewItem item = lvwAG.Items[i];
                if (lvwAG.Items[i].Checked == true)
                {
                    lvwAG.Items[i].Selected = true;
                }
            }

            if (lvwAG.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row to save.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            int number;
            if (int.TryParse(txtDiscount.Text, out number))
            {
                if (number <= 100 && number > 0)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Discount must be between 1 to 100", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtDiscount.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Invalid Discount !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiscount.Focus();
                return false;
            }

            if(Convert.ToInt32(txtDiscount.Text.Trim()) != Convert.ToInt32(txtContribution.Text.Trim()))
            {
                MessageBox.Show("Discount and Contribution must be same.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContribution.Focus();
                return false;
            }
                      

            #endregion

            return true;
        }

        private void Save()
        {
            if (this.Tag == null)
            {
                PromoDiscountBank oDiscountBank = new PromoDiscountBank();

                for (int i = 0; i < lvwAG.Items.Count; i++)
                {
                    ListViewItem item = lvwAG.Items[i];
                    if (lvwAG.Items[i].Checked == true)
                    {
                        oDiscountBank.AGID = Convert.ToInt32(item.SubItems[0].Text.ToString());
                        if (_oPaymentModes[cmbPaymentMode.SelectedIndex].PaymentModeID == 2 || _oPaymentModes[cmbPaymentMode.SelectedIndex].IsFinancialInstitution == 1)
                        {
                            oDiscountBank.BankID = oBanks[cmbBank.SelectedIndex - 1].BankID;
                        }
                        else
                        {
                            oDiscountBank.BankID = -1;
                        }
                        oDiscountBank.BrandID = oBrands[cmbBrand.SelectedIndex - 1].BrandID;
                        oDiscountBank.FromDate = dtFromDate.Value.Date;
                        oDiscountBank.ToDate = dtToDate.Value.Date;
                        oDiscountBank.DiscountPercent = Convert.ToDouble(txtDiscount.Text.ToString());
                        oDiscountBank.IsActive = (int)Dictionary.YesOrNoStatus.YES;

                        if (_nStatus == (int)Dictionary.BankDiscountStatus.Create)
                        {
                            oDiscountBank.Status = (int)Dictionary.BankDiscountStatus.Create;
                        }
                        else
                        {
                            oDiscountBank.Status = (int)Dictionary.BankDiscountStatus.Approved;
                        }
                        oDiscountBank.CreateUserID = Utility.UserId;
                        oDiscountBank.CreateDate = DateTime.Now.Date;
                        oDiscountBank.PaymentModeID = _oPaymentModes[cmbPaymentMode.SelectedIndex].PaymentModeID;
                        oDiscountBank.MaxDiscountAmount = Convert.ToDouble(txtMaxDisc.Text.Trim());
                        if(_oPaymentModes[cmbPaymentMode.SelectedIndex].PaymentModeID==2 || _oPaymentModes[cmbPaymentMode.SelectedIndex].IsFinancialInstitution==1)
                        {
                            oDiscountBank.IsBankDiscount = 1;
                        }
                        else
                        {
                            oDiscountBank.IsBankDiscount = 0;
                        }

                        if (oDiscountBank.IsBankDiscount == 1)
                        {
                            oDiscountBank.CardType = cmbCreditCardType.SelectedIndex;
                        }
                        else
                        {
                            oDiscountBank.CardType = -1;
                        }

                        if(txtContribution.Text.Trim()=="")
                        {
                            oDiscountBank.Contribution = 0;
                        }
                        else
                        {
                            oDiscountBank.Contribution = Convert.ToDouble(txtContribution.Text);
                        }

                        if (chkIsEMIMandatory.Checked)
                        {
                            oDiscountBank.IsEMIMandatory = (int)Dictionary.YesOrNoStatus.YES;
                        }
                        else
                        {
                            oDiscountBank.IsEMIMandatory = (int)Dictionary.YesOrNoStatus.NO;
                        }
                        try
                        {
                            DBController.Instance.BeginNewTransaction();
                            oDiscountBank.Add(_oDSPromotionContribution);
                            //oDiscountBank.IsActive = (int)Dictionary.YesOrNoStatus.NO;
                            //oDiscountBank.UpdateBankDiscount();

                            Showrooms oShowrooms = new Showrooms();
                            oShowrooms.Refresh();
                            foreach (Showroom oShowroom in oShowrooms)
                            {
                                DataTran oDataTran = new DataTran();
                                oDataTran.TableName = "t_PromoDiscountBank";
                                oDataTran.DataID = Convert.ToInt32(oDiscountBank.BankDiscountID);
                                oDataTran.WarehouseID = oShowroom.WarehouseID;
                                oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                                oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                                oDataTran.BatchNo = 0;
                                if (oDataTran.CheckDataByWHID() == false)
                                {
                                    oDataTran.AddForTDPOS();
                                }
                            }
                            DBController.Instance.CommitTransaction();
                        }
                        catch (Exception ex)
                        {
                            DBController.Instance.RollbackTransaction();
                            MessageBox.Show(ex.Message, "Error!!!");
                        }


                    }
                }

                MessageBox.Show("Your data has been updated successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                PromoDiscountBank oDiscountBank = (PromoDiscountBank)this.Tag;
                oDiscountBank.BankID = oBanks[cmbBank.SelectedIndex - 1].BankID;
               // oDiscountBank.AGID = _oAG[cmbAG.SelectedIndex].PdtGroupID;
                oDiscountBank.BrandID = oBrands[cmbBrand.SelectedIndex - 1].BrandID;
                oDiscountBank.FromDate = dtFromDate.Value;
                oDiscountBank.ToDate = dtToDate.Value;
                oDiscountBank.DiscountPercent = Convert.ToDouble(txtDiscount.Text.ToString());
                oDiscountBank.IsActive = (int)Dictionary.YesOrNoStatus.YES;
                if (chkIsEMIMandatory.Checked)
                {
                    oDiscountBank.IsEMIMandatory = (int)Dictionary.YesOrNoStatus.YES;
                }
                else
                {
                    oDiscountBank.IsEMIMandatory = (int)Dictionary.YesOrNoStatus.NO;
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
                oDiscountBank.CreateDate = DateTime.Now;
                oDiscountBank.UpdateUserID= Utility.UserId;
                oDiscountBank.UpdateDate = DateTime.Now;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    if (_dFromDate.Date == dtFromDate.Value.Date)
                    {
                        oDiscountBank.EditBybankDiscount();
                    }
                    else
                    {
                        oDiscountBank.UpdateIsActive();
                        oDiscountBank.Add(_oDSPromotionContribution);
                    }

                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You have successfully update the transaction : " + oDiscountBank.BankDiscountID, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                _bActionSave = true;
                this.Close();
            }
        }

        private void cmbPG_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMAG.Items.Clear();
            cmbMAG.Items.Add("--ALL--");

            if (cmbPG.SelectedIndex > 0)
            {
                //Load MAG
                _oMAG = new ProductGroups();
                _oMAG.Refresh(_oPG[cmbPG.SelectedIndex-1].PdtGroupID);

                foreach (ProductGroup oMAG in _oMAG)
                {
                    cmbMAG.Items.Add(oMAG.PdtGroupName);
                }
            }
            cmbMAG.SelectedIndex = 0;
        }

        private void cmbMAG_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbASG.Items.Clear();
            cmbASG.Items.Add("--ALL--");

            if (cmbMAG.SelectedIndex > 0)
            {
                //Load ASG
                _oASG = new ProductGroups();
                _oASG.Refresh(_oMAG[cmbMAG.SelectedIndex-1].PdtGroupID);
                foreach (ProductGroup oASG in _oASG)
                {
                    cmbASG.Items.Add(oASG.PdtGroupName);
                }
            }

            cmbASG.SelectedIndex = 0;
        }

        private void cmbASG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbASG.SelectedIndex > 0)
            {
                //Load AG
                _oAG = new ProductGroups();
                _oAG.Refresh(_oASG[cmbASG.SelectedIndex - 1].PdtGroupID);
                lvwAG.Items.Clear();
                foreach (ProductGroup oAG in _oAG)
                {
                    ListViewItem oItem = lvwAG.Items.Add(oAG.PdtGroupID.ToString());
                    oItem.SubItems.Add(oAG.PdtGroupName.ToString());
                    oItem.Tag = oAG;
                }
            }

            else {
                lvwAG.Items.Clear();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int NumberOfClick = 1;

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            switch (NumberOfClick)
            {
                case 1:
                    for (int i = 0; i < lvwAG.Items.Count; i++)
                    {
                        ListViewItem itm = lvwAG.Items[i];
                        lvwAG.Items[i].Checked = true;
                    }
                    ++NumberOfClick;
                    btnSelectAll.Text = "Uncheck All";
                    break;
                case 2:
                    for (int i = 0; i < lvwAG.Items.Count; i++)
                    {
                        ListViewItem itm = lvwAG.Items[i];
                        lvwAG.Items[i].Checked = false;
                    }
                    --NumberOfClick;
                    btnSelectAll.Text = "Check All";
                    break;
            }
        }

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {

            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            //{
            //    e.Handled = true;
            //}

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            //// only allow one decimal point
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
        }

        private void cmbPaymentMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(_oPaymentModes[cmbPaymentMode.SelectedIndex].PaymentModeID == 2)
            {
                cmbBank.Enabled = true;
            }
            else if(_oPaymentModes[cmbPaymentMode.SelectedIndex].IsFinancialInstitution == 1)
            {
                cmbBank.Enabled = true;
            }
            else
            {
                cmbBank.SelectedIndex = 0;
                cmbBank.Enabled = false;
            }
        }

        private void txtMaxDisc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void cmbBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmbBank.SelectedIndex>0)
            {
                cmbCreditCardType.Enabled = true;
            }
            else
            {
                cmbCreditCardType.Enabled = false;
            }
        }

        private void lblContribution_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmConsumerPromotionDiscountContribution oForm = new frmConsumerPromotionDiscountContribution();
            oForm.ShowDialog();
            _oDSPromotionContribution = oForm._oDSPromotionContribution;
            _oTELLib = new TELLib();
            txtContribution.Text = _oTELLib.TakaFormat(oForm._ContributionTotal);
        }
    }
}

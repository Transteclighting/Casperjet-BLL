using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;
using CJ.Class.Admin;
using CJ.Class.Accounts;

namespace CJ.Win.Accounts
{
    public partial class frmSalesInvoiceDiscountType : Form
    {
        int nDiscountTypeId = 0;
        string _sSalesType = "";
        private int nArrayLen = 0;
        private string[] sChannelArr = null;
        public bool _bFalg = false;

        public frmSalesInvoiceDiscountType()
        {
            InitializeComponent();
        }

        public bool ValidateUIInput()
        {
            if (txtDiscountTypeName.Text == "")
            {
                MessageBox.Show("Please enter description", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiscountTypeName.Focus();
                return false;
            }
            int nCount = 0;
            if (chkRetail.Checked == true)
            {
                nCount++;
            }
            if (chkB2B.Checked == true)
            {
                nCount++;
            }
            if (chkB2C.Checked == true)
            {
                nCount++;
            }
            if (chkHPA.Checked == true)
            {
                nCount++;
            }
            if (chkDealer.Checked == true)
            {
                nCount++;
            }
            if (chkeStore.Checked == true)
            {
                nCount++;
            }
            if (nCount == 0)
            {
                MessageBox.Show("Please select at least one channel", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiscountTypeName.Focus();
                return false;
            }

            return true;
        }

        private void LoadCombo()
        {
            cmbType.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.DiscountChargeType)))
            {
                if (GetEnum == (int)Dictionary.DiscountChargeType.Discount || GetEnum == (int)Dictionary.DiscountChargeType.Charge)
                {
                    cmbType.Items.Add(Enum.GetName(typeof(Dictionary.DiscountChargeType), GetEnum));
                }
            }
            cmbType.SelectedIndex = 0;
        }
        private void Save()
        {
            if (this.Tag == null)
            {
                SalesInvoiceDiscountType oSalesInvoiceDiscountType = new SalesInvoiceDiscountType();

                oSalesInvoiceDiscountType.DiscountTypeName = txtDiscountTypeName.Text;
                oSalesInvoiceDiscountType.Type = cmbType.SelectedIndex;
                if (chkIsActive.Checked == true)
                {
                    oSalesInvoiceDiscountType.IsActive = (int)Dictionary.IsActive.Active;

                }
                else
                {
                    oSalesInvoiceDiscountType.IsActive = (int)Dictionary.IsActive.InActive;
                }

                if (chkRetail.Checked == true)
                {
                    if (_sSalesType == "")
                    {
                        _sSalesType = ((int)Dictionary.SalesType.Retail).ToString();
                    }
                    else
                    {
                        _sSalesType = _sSalesType + "," + ((int)Dictionary.SalesType.Retail).ToString();
                    }
                }
                if (chkB2B.Checked == true)
                {
                    if (_sSalesType == "")
                    {
                        _sSalesType = ((int)Dictionary.SalesType.B2B).ToString();
                    }
                    else
                    {
                        _sSalesType = _sSalesType + "," + ((int)Dictionary.SalesType.B2B).ToString();
                    }
                }
                if (chkB2C.Checked == true)
                {
                    if (_sSalesType == "")
                    {
                        _sSalesType = ((int)Dictionary.SalesType.B2C).ToString();
                    }
                    else
                    {
                        _sSalesType = _sSalesType + "," + ((int)Dictionary.SalesType.B2C).ToString();
                    }
                }
                if (chkHPA.Checked == true)
                {
                    if (_sSalesType == "")
                    {
                        _sSalesType = ((int)Dictionary.SalesType.HPA).ToString();
                    }
                    else
                    {
                        _sSalesType = _sSalesType + "," + ((int)Dictionary.SalesType.HPA).ToString();
                    }
                }
                if (chkDealer.Checked == true)
                {
                    if (_sSalesType == "")
                    {
                        _sSalesType = ((int)Dictionary.SalesType.Dealer).ToString();
                    }
                    else
                    {
                        _sSalesType = _sSalesType + "," + ((int)Dictionary.SalesType.Dealer).ToString();
                    }
                }
                if (chkeStore.Checked == true)
                {
                    if (_sSalesType == "")
                    {
                        _sSalesType = ((int)Dictionary.SalesType.eStore).ToString();
                    }
                    else
                    {
                        _sSalesType = _sSalesType + "," + ((int)Dictionary.SalesType.eStore).ToString();
                    }
                }

                oSalesInvoiceDiscountType.SalesType = _sSalesType.ToString();
                oSalesInvoiceDiscountType.IsSystem = (int)Dictionary.YesOrNoStatus.NO;
                oSalesInvoiceDiscountType.CreateDate = DateTime.Now.Date;
                oSalesInvoiceDiscountType.CreateUserID = Utility.UserId;
                if (chkIsMandatoryInstrumentNo.Checked)
                {
                    oSalesInvoiceDiscountType.IsMandatoryInstrumentNo = 1;
                }
                else
                {
                    oSalesInvoiceDiscountType.IsMandatoryInstrumentNo = 0;
                }
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oSalesInvoiceDiscountType.Add();
                    Showrooms oShowrooms = new Showrooms();
                    oShowrooms.Refresh();
                    foreach (Showroom oShowroom in oShowrooms)
                    {
                        DataTran oDataTran = new DataTran();
                        oDataTran.TableName = "t_SalesInvoiceDiscountType";
                        oDataTran.DataID = Convert.ToInt32(oSalesInvoiceDiscountType.DiscountTypeID);
                        oDataTran.WarehouseID = oShowroom.WarehouseID;
                        oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                        oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                        oDataTran.BatchNo = 0;
                        if (oDataTran.CheckDataByWHID() == false)
                        {
                            oDataTran.AddForTDPOS();
                        }
                    }
                    _bFalg = true;
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Sales Invoice Discount Type : " + oSalesInvoiceDiscountType.DiscountTypeName, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                SalesInvoiceDiscountType oSalesInvoiceDiscountType = (SalesInvoiceDiscountType)this.Tag;
                oSalesInvoiceDiscountType.DiscountTypeID = nDiscountTypeId;
                oSalesInvoiceDiscountType.DiscountTypeName = txtDiscountTypeName.Text;
                oSalesInvoiceDiscountType.Type = cmbType.SelectedIndex;
                if (chkIsActive.Checked == true)
                {
                    oSalesInvoiceDiscountType.IsActive = (int)Dictionary.IsActive.Active;

                }
                else
                {
                    oSalesInvoiceDiscountType.IsActive = (int)Dictionary.IsActive.InActive;
                }

                if (chkRetail.Checked == true)
                {
                    if (_sSalesType == "")
                    {
                        _sSalesType = ((int)Dictionary.SalesType.Retail).ToString();
                    }
                    else
                    {
                        _sSalesType = _sSalesType + "," + ((int)Dictionary.SalesType.Retail).ToString();
                    }
                }
                if (chkB2B.Checked == true)
                {
                    if (_sSalesType == "")
                    {
                        _sSalesType = ((int)Dictionary.SalesType.B2B).ToString();
                    }
                    else
                    {
                        _sSalesType = _sSalesType + "," + ((int)Dictionary.SalesType.B2B).ToString();
                    }
                }
                if (chkB2C.Checked == true)
                {
                    if (_sSalesType == "")
                    {
                        _sSalesType = ((int)Dictionary.SalesType.B2C).ToString();
                    }
                    else
                    {
                        _sSalesType = _sSalesType + "," + ((int)Dictionary.SalesType.B2C).ToString();
                    }
                }
                if (chkHPA.Checked == true)
                {
                    if (_sSalesType == "")
                    {
                        _sSalesType = ((int)Dictionary.SalesType.HPA).ToString();
                    }
                    else
                    {
                        _sSalesType = _sSalesType + "," + ((int)Dictionary.SalesType.HPA).ToString();
                    }
                }
                if (chkDealer.Checked == true)
                {
                    if (_sSalesType == "")
                    {
                        _sSalesType = ((int)Dictionary.SalesType.Dealer).ToString();
                    }
                    else
                    {
                        _sSalesType = _sSalesType + "," + ((int)Dictionary.SalesType.Dealer).ToString();
                    }
                }
                if (chkeStore.Checked == true)
                {
                    if (_sSalesType == "")
                    {
                        _sSalesType = ((int)Dictionary.SalesType.eStore).ToString();
                    }
                    else
                    {
                        _sSalesType = _sSalesType + "," + ((int)Dictionary.SalesType.eStore).ToString();
                    }
                }

                oSalesInvoiceDiscountType.SalesType = _sSalesType.ToString();
                oSalesInvoiceDiscountType.IsSystem = (int)Dictionary.YesOrNoStatus.NO;

                if (chkIsMandatoryInstrumentNo.Checked)
                {
                    oSalesInvoiceDiscountType.IsMandatoryInstrumentNo = 1;
                }
                else
                {
                    oSalesInvoiceDiscountType.IsMandatoryInstrumentNo = 0;
                }

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oSalesInvoiceDiscountType.Edit();
                    Showrooms oShowrooms = new Showrooms();
                    oShowrooms.Refresh();
                    foreach (Showroom oShowroom in oShowrooms)
                    {
                        DataTran oDataTran = new DataTran();
                        oDataTran.TableName = "t_SalesInvoiceDiscountType";
                        oDataTran.DataID = Convert.ToInt32(nDiscountTypeId);
                        oDataTran.WarehouseID = oShowroom.WarehouseID;
                        oDataTran.TransferType = (int)Dictionary.DataTransferType.Edit;
                        oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                        oDataTran.BatchNo = 0;
                        if (oDataTran.CheckDataByWHID() == false)
                        {
                            oDataTran.AddForTDPOS();
                        }
                    }
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update The Sales Invoice Discount Type : " + oSalesInvoiceDiscountType.DiscountTypeName, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }


        public void ShowDialog(SalesInvoiceDiscountType oSalesInvoiceDiscountType)
        {
            this.Tag = oSalesInvoiceDiscountType;
            this.Text = "Edit Discount/Charge Type";
            LoadCombo();
            nDiscountTypeId = oSalesInvoiceDiscountType.DiscountTypeID;
            txtDiscountTypeName.Text = oSalesInvoiceDiscountType.DiscountTypeName;
            txtDiscountTypeName.Enabled = false;
            cmbType.Enabled = false;
            groupBox1.Enabled = false;
            cmbType.SelectedIndex = oSalesInvoiceDiscountType.Type;

            if (oSalesInvoiceDiscountType.IsMandatoryInstrumentNo == (int)Dictionary.YesOrNoStatus.YES)
            {
                chkIsMandatoryInstrumentNo.Checked = true;
            }
            else
            {
                chkIsMandatoryInstrumentNo.Checked = false;
            }


            char[] splitchar = { ',' };
            sChannelArr = oSalesInvoiceDiscountType.SalesType.Split(splitchar);
            nArrayLen = sChannelArr.Length;
            
            for (int i = 0; i < nArrayLen; i++)
            {
                if (Convert.ToInt32(sChannelArr[i]) == (int)Dictionary.SalesType.Retail)
                {
                    chkRetail.Checked = true;
                }
                else if (Convert.ToInt32(sChannelArr[i]) == (int)Dictionary.SalesType.B2C)
                {
                    chkB2C.Checked = true;
                }
                else if (Convert.ToInt32(sChannelArr[i]) == (int)Dictionary.SalesType.B2B)
                {
                    chkB2B.Checked = true;
                }
                else if (Convert.ToInt32(sChannelArr[i]) == (int)Dictionary.SalesType.HPA)
                {
                    chkHPA.Checked = true;
                }
                else if (Convert.ToInt32(sChannelArr[i]) == (int)Dictionary.SalesType.Dealer)
                {
                    chkDealer.Checked = true;
                }
                else if (Convert.ToInt32(sChannelArr[i]) == (int)Dictionary.SalesType.eStore)
                {
                    chkeStore.Checked = true;
                }
            }
            if (oSalesInvoiceDiscountType.IsActive == (int)Dictionary.IsActive.Active)
            {
                chkIsActive.Checked = true;
            }
            else
            {
                chkIsActive.Checked = false;
            }

            this.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateUIInput())
            {
                Save();
                this.Close();
            }

        }

        private void frmSalesInvoiceDiscountType_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                LoadCombo();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}



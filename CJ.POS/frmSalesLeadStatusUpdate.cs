using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Admin;
using CJ.Class.POS;
using CJ.Class.Library;
using CJ.Class.BasicData;

namespace CJ.POS
{
    public partial class frmSalesLeadStatusUpdate : Form
    {
        int nLeadID = 0;
        string sLeadNo = "";
        Brand _oBrand;
        ProductGroup _oMAG;
        SalesLead _oSalesLead;
        int nWarehouseID = 0;
        DateTime dtExpExcuDate;
        public bool _IsTrue = false;
        public frmSalesLeadStatusUpdate()
        {
            InitializeComponent();
        }
        public void ShowDialog(SalesLead oSalesLead)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            this.Tag = oSalesLead;
            nWarehouseID = oSalesLead.WarehouseID;
            dtExpExcuDate = oSalesLead.ExpExecuteDate;

            nLeadID = 0;
            nLeadID = oSalesLead.LeadID;
            sLeadNo = "";
            sLeadNo = oSalesLead.LeadNo;
            lblLeadNo.Text = sLeadNo;
            lblCompany.Text = oSalesLead.CompanyName;
            lblName.Text = oSalesLead.Name;
            lblAddress.Text = oSalesLead.Address;
            lblContactNo.Text = oSalesLead.ContactNo;
            lblEmail.Text = oSalesLead.Email;
            lblProfession.Text = oSalesLead.Profession;
            lblAGE.Text = oSalesLead.AgeLevel;
            //lblIncomLevel.Text = oSalesLead.IncomLevel;
            lblSpecificModel.Text = oSalesLead.ModelName;
            lblLeadAmount.Text = oSalesLead.LeadAmount.ToString();
            //lblRemarks.Text = oSalesLead.Remarks;
            lblLeadDate.Text = oSalesLead.LeadDate.ToString("dd-MMM-yyyy");
            lblFollowUpDate.Text = oSalesLead.NextFollowUpDate.ToString("dd-MMM-yyyy");
            lblExpExecuteDate.Text = oSalesLead.ExpExecuteDate.ToString("dd-MMM-yyyy");

            DataLoadControl();
            _oBrand = new Brand();
            _oBrand.BrandID = oSalesLead.BrandID;
            _oBrand.Refresh();
            lblBrand.Text = _oBrand.BrandDesc;
            lblCustomerType.Text = Enum.GetName(typeof(Dictionary.CustomerTypeSalesLead), oSalesLead.CustomerType);
            _oMAG = new ProductGroup();
            _oMAG.PdtGroupID = oSalesLead.MAGID;
            _oMAG.Refresh();
            lblMAG.Text = _oMAG.PdtGroupName;
            this.ShowDialog();
        }

        private void DataLoadControl()
        {

            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            SalesLeads _oSalesLeads = new SalesLeads();
            _oSalesLeads.GetLeadHistory(lblLeadNo.Text);
            foreach (SalesLead oSalesLead in _oSalesLeads)
            {
                ListViewItem oItem = lvwSalesLeadHistory.Items.Add(oSalesLead.CreateDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.SalesLeadStatusPOS), oSalesLead.Status));
                oItem.SubItems.Add(oSalesLead.Remarks.ToString());
                oItem.Tag = oSalesLead;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _IsTrue = false;
            this.Close();
        }

        private void LoadCombos()
        {
            //Status 
            cmbStatus.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SalesLeadStatusUpdatePOS)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.SalesLeadStatusUpdatePOS), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;
        }

        private bool UIValidation()
        {
            #region ValidInput
            if (txtReason.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Status Update Remarks", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtReason.Focus();
                return false;
            }
            #endregion
            return true;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oSalesLead = new SalesLead();
                    _oSalesLead.LeadID = nLeadID;
                    _oSalesLead.Reason = txtReason.Text;
                    _oSalesLead.CancelDate = DateTime.Now.Date;

                    if (cmbStatus.SelectedIndex == 0)
                    {
                        _oSalesLead.Status = (int)Dictionary.SalesLeadStatusUpdatePOS.Cancel;
                    }
                    else if (cmbStatus.SelectedIndex == 1)
                    {
                        _oSalesLead.Status = (int)Dictionary.SalesLeadStatusUpdatePOS.In_Progress;
                    }
                    else if (cmbStatus.SelectedIndex == 2)
                    {
                        _oSalesLead.Status = (int)Dictionary.SalesLeadStatusUpdatePOS.No_Answer;
                    }
                    else if (cmbStatus.SelectedIndex == 3)
                    {
                        _oSalesLead.Status = (int)Dictionary.SalesLeadStatusUpdatePOS.Follow_Up;
                    }
                    else
                    {
                        _oSalesLead.Status = (int)Dictionary.SalesLeadStatusUpdatePOS.Product_Not_Available;
                    }

                    _oSalesLead.UpdateStatus();
                    _oSalesLead.LeadNo = sLeadNo;
                    _oSalesLead.WarehouseID = nWarehouseID;
                    _oSalesLead.Remarks = txtReason.Text;
                    _oSalesLead.ExpExecuteDate = dtExpExcuDate.Date;
                    _oSalesLead.AddHistory();
                    _IsTrue = true;
                    DBController.Instance.CommitTransaction();

                    MessageBox.Show("Successfully Update Status LeadNo# " + sLeadNo, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void frmSalesLeadStatusUpdate_Load(object sender, EventArgs e)
        {
            LoadCombos();
        }

      
    }
}
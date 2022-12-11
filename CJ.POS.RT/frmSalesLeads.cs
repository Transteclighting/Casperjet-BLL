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

namespace CJ.POS.RT
{
    public partial class frmSalesLeads : Form
    {
        SalesLeads _oSalesLeads;
        bool IsCheck = false;
        bool IsCheckExp = false;
        bool IsNextFollowUp = false;
        Employees oEmployees;
        Brands _oBrands;


        ProductGroups _oPG;
        ProductGroups _oMAG;
        ProductGroups _oASG;
        ProductGroups _oAG;

        public frmSalesLeads()
        {
            InitializeComponent();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmSalesLead oForm = new frmSalesLead(1, "", "", "", "", "", -1, -1);
            oForm.ShowDialog();
            if (oForm._IsTrue == true)
                DataLoadControl();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwSalesLead.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Item to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SalesLead oSalesLead = (SalesLead)lvwSalesLead.SelectedItems[0].Tag;
            if (oSalesLead.Status == (int)Dictionary.SalesLeadStatusPOS.Cancel || oSalesLead.Status == (int)Dictionary.SalesLeadStatusPOS.Sales_Executed)
            {
                MessageBox.Show("Only Create status can be Edit", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                frmSalesLead oForm = new frmSalesLead(1, "", "", "", "", "", -1, -1);
                oForm.ShowDialog(oSalesLead);
                if (oForm._IsTrue == true)
                    DataLoadControl();

            }
        }
        private void DataLoadControl()
        {
            this.Cursor = Cursors.WaitCursor;
            _oSalesLeads = new SalesLeads();
            lvwSalesLead.Items.Clear();
            int nCustomerType = 0;
            if (cmbCustType.SelectedIndex == 0)
            {
                nCustomerType = -1;
            }
            else
            {
                nCustomerType = cmbCustType.SelectedIndex;
            }

            int nStatus = 0;
            if (cmbStatus.SelectedIndex == 0)
            {
                nStatus = -1;
            }
            else
            {
                nStatus = cmbStatus.SelectedIndex;
            }

            int nSalesPersonID = 0;
            if (cmbSalesPerson.SelectedIndex == 0)
            {
                nSalesPersonID = -1;
            }
            else
            {
                nSalesPersonID = oEmployees[cmbSalesPerson.SelectedIndex - 1].EmployeeID;
            }


            int nBrandID = 0;
            if (cmbBrand.SelectedIndex == 0)
            {
                nBrandID = -1;
            }
            else
            {
                nBrandID = _oBrands[cmbBrand.SelectedIndex - 1].BrandID;
            }
            int nLeadSource = 0;
            if (cmbLeadSource.SelectedIndex == 0)
            {
                nLeadSource = -1;
            }
            else
            {
                nLeadSource = cmbLeadSource.SelectedIndex - 1;
            }

            int nPGID = -1;
            if (cmbPG.SelectedIndex > 0) nPGID = _oPG[cmbPG.SelectedIndex - 1].PdtGroupID;

            int nMAGID = -1;
            if (cmbMAG.SelectedIndex > 0) nMAGID = _oMAG[cmbMAG.SelectedIndex - 1].PdtGroupID;

            int nASGID = -1;
            if (cmbASG.SelectedIndex > 0) nASGID = _oASG[cmbASG.SelectedIndex - 1].PdtGroupID;

            int nAGID = -1;
            if (cmbAG.SelectedIndex > 0) nAGID = _oAG[cmbAG.SelectedIndex - 1].PdtGroupID;


            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            _oSalesLeads.RefreshforRT(dtFromDate.Value.Date, dtToDate.Value.Date, dtExpFromDate.Value.Date, dtExpToDate.Value.Date, nCustomerType, nStatus, txtCompany.Text.Trim(), txtName.Text.Trim(), txtContactNo.Text.Trim(), txtLeadNo.Text.Trim(), IsCheck, IsCheckExp, nSalesPersonID, nLeadSource, nMAGID, nBrandID, IsNextFollowUp, dtNextFollowUpFromDate.Value.Date, dtNextFollowUpToDate.Value.Date, nASGID, nAGID, nPGID, txtProductName.Text, txtModelName.Text);
            DBController.Instance.CloseConnection();
            double _LeadAmount = 0;
            double _LeadQty = 0;
            int _nSalesQty = 0;
            double _InvoiceAmount = 0;
            TELLib oTELLib = new TELLib();
            foreach (SalesLead oSalesLead in _oSalesLeads)
            {
                ListViewItem oItem = lvwSalesLead.Items.Add(oSalesLead.LeadNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oSalesLead.LeadDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(Convert.ToDateTime(oSalesLead.ExpExecuteDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(Convert.ToDateTime(oSalesLead.NextFollowUpDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.CustomerTypeSalesLead), oSalesLead.CustomerType));
                oItem.SubItems.Add(oSalesLead.SalesPerson.ToString());
                oItem.SubItems.Add(oSalesLead.Name.ToString());
                oItem.SubItems.Add(oSalesLead.ContactNo.ToString());
                oItem.SubItems.Add(oSalesLead.Address.ToString());
                oItem.SubItems.Add(oSalesLead.CompanyName.ToString());
                oItem.SubItems.Add("[" + oSalesLead.ProductCode + "] " + oSalesLead.ProductName);
                oItem.SubItems.Add(oSalesLead.ModelName.ToString());
                oItem.SubItems.Add(oSalesLead.AGName.ToString());
                oItem.SubItems.Add(oSalesLead.ASGName.ToString());
                oItem.SubItems.Add(oSalesLead.MAGName.ToString());
                oItem.SubItems.Add(oSalesLead.PGName.ToString());
                oItem.SubItems.Add(oSalesLead.BrandDesc.ToString());
                oItem.SubItems.Add(Convert.ToInt32(oSalesLead.Qty).ToString());
                oItem.SubItems.Add(Convert.ToDouble(oSalesLead.LeadAmount).ToString());
                oItem.SubItems.Add(oSalesLead.InvoiceNo.ToString());
                oItem.SubItems.Add(oSalesLead.SalesQty.ToString());
                oItem.SubItems.Add(oSalesLead.InvoiceAmount.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.Terminal), oSalesLead.Terminal));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.SalesLeadStatusPOS), oSalesLead.Status));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.LeadSource), oSalesLead.LeadSource));
                oItem.SubItems.Add(oSalesLead.ActivationName.ToString());
                oItem.SubItems.Add(oSalesLead.ThanaName.ToString());
                oItem.SubItems.Add(oSalesLead.DistrictName.ToString());
                _LeadAmount = _LeadAmount + oSalesLead.LeadAmount;
                _LeadQty = _LeadQty + oSalesLead.Qty;
                _nSalesQty = _nSalesQty + oSalesLead.SalesQty;
                _InvoiceAmount = _InvoiceAmount + oSalesLead.InvoiceAmount;

                oItem.Tag = oSalesLead;
            }
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            PlanMAGWeekQtyTarget oLeadTgt = new PlanMAGWeekQtyTarget();
            oLeadTgt.GetTargetForPOS(nSalesPersonID);
            lblCurrentMonthTGTValue.Text = "Current Month Target Value: " + oTELLib.TakaFormat(oLeadTgt.TargetValue) + "/=";
            lblCurrentMonthTGTQty.Text = "Current Month Target Quantity: " + oLeadTgt.TargetQty.ToString() + " Pcs";
            SetListViewRowColour();
            lblLeadAmount.Text = "Lead Qty: " + _LeadQty.ToString() + " Pcs" + " || " + "Lead Amt: " + oTELLib.TakaFormat(_LeadAmount) + "/=";
            lblTotalLeadQty.Text = "Invoice Qty: " + _nSalesQty.ToString() + " Pcs" + " || " + "Invoice Amt.: " + oTELLib.TakaFormat(_InvoiceAmount) + "/=";

            this.Text = "Sales Leads [" + _oSalesLeads.Count + "]";
            this.Cursor = Cursors.Default;
        }
        private void LoadCombos()
        {
            chkAll.Checked = true;

            TELLib _oTELLib = new TELLib();
            dtFromDate.Value = _oTELLib.ServerDateTime().Date;
            dtToDate.Value = dtFromDate.Value;

            dtExpFromDate.Value = dtFromDate.Value;
            dtExpToDate.Value = dtFromDate.Value;

            dtNextFollowUpFromDate.Value= dtFromDate.Value;
            dtNextFollowUpToDate.Value= dtFromDate.Value;


            //Customer Type 
            cmbCustType.Items.Clear();
            cmbCustType.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CustomerTypeSalesLead)))
            {
                cmbCustType.Items.Add(Enum.GetName(typeof(Dictionary.CustomerTypeSalesLead), GetEnum));
            }
            cmbCustType.SelectedIndex = 0;

            //Status 
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SalesLeadStatusPOS)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.SalesLeadStatusPOS), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;



            //Sales Person
            oEmployees = new Employees();
            cmbSalesPerson.Items.Clear();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            oEmployees.GetShowroomSalesPersonRT();
            cmbSalesPerson.Items.Add("<All>");
            foreach (Employee oEmployee in oEmployees)
            {
                cmbSalesPerson.Items.Add(oEmployee.EmployeeName);
            }
            if (oEmployees.Count > 0)
                cmbSalesPerson.SelectedIndex = 0;


            //Lead Source
            cmbLeadSource.Items.Clear();
            cmbLeadSource.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.LeadSource)))
            {
                cmbLeadSource.Items.Add(Enum.GetName(typeof(Dictionary.LeadSource), GetEnum));
            }
            cmbLeadSource.SelectedIndex = 0;

            //Load PG in combo
            _oPG = new ProductGroups();
            _oPG.Refresh(Dictionary.ProductGroupType.ProductGroup);
            cmbPG.Items.Clear();
            cmbPG.Items.Add("<All>");
            foreach (ProductGroup oProductGroup in _oPG)
            {
                cmbPG.Items.Add(oProductGroup.PdtGroupName);
            }
            cmbPG.SelectedIndex = 0;

            //Brand 
            _oBrands = new Brands();
            _oBrands.Refresh(Dictionary.BrandLevel.MasterBrand);
            cmbBrand.Items.Clear();
            cmbBrand.Items.Add("<All>");
            foreach (Brand oBrand in _oBrands)
            {
                cmbBrand.Items.Add(oBrand.BrandDesc);
            }
            cmbBrand.SelectedIndex = 0;


        }
        private void SetListViewRowColour()
        {
            if (lvwSalesLead.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwSalesLead.Items)
                {
                    if (oItem.SubItems[23].Text == "Create")
                    {
                        oItem.BackColor = Color.Transparent;
                    }
                    else if (oItem.SubItems[23].Text == "Sales_Executed")
                    {
                        oItem.BackColor = Color.LightGreen;

                    }
                    else if (oItem.SubItems[23].Text == "Send_To_HO")
                    {
                        oItem.BackColor = Color.SandyBrown;

                    }
                    else if (oItem.SubItems[23].Text == "In_Progress")
                    {
                        oItem.BackColor = Color.LightYellow;

                    }
                    else if (oItem.SubItems[23].Text == "No_Answer")
                    {
                        oItem.BackColor = Color.Orange;

                    }
                    else if (oItem.SubItems[23].Text == "Follow_Up")
                    {
                        oItem.BackColor = Color.LightBlue;

                    }
                    else if (oItem.SubItems[23].Text == "Product_Not_Available")
                    {
                        oItem.BackColor = Color.LightCoral;

                    }
                    else
                    {
                        oItem.BackColor = Color.Gray;
                    }

                }
            }
        }
        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();

        }
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                dtFromDate.Enabled = false;
                dtToDate.Enabled = false;
                IsCheck = true;
            }
            else
            {
                dtFromDate.Enabled = true;
                dtToDate.Enabled = true;
                IsCheck = false;
            }
        }
        private void frmSalesLeads_Load(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            LoadCombos();
            DataLoadControl();
        }
        private void btnStatusUpdate_Click(object sender, EventArgs e)
        {
            if (lvwSalesLead.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Lead to Update Status.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SalesLead oSalesLead = (SalesLead)lvwSalesLead.SelectedItems[0].Tag;
            if (oSalesLead.Status == (int)Dictionary.SalesLeadStatusPOS.Cancel)
            {
                MessageBox.Show("Sales lead already canceled", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (oSalesLead.Status == (int)Dictionary.SalesLeadStatusPOS.Sales_Executed)
            {
                MessageBox.Show("Sales lead already executed", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                frmSalesLeadStatusUpdate oForm = new frmSalesLeadStatusUpdate();
                oForm.ShowDialog(oSalesLead);
                if (oForm._IsTrue == true)
                    DataLoadControl();

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvwSalesLead_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click( sender, e);
        }

        private void ChkExpDt_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkExpDt.Checked == true)
            {
                dtExpFromDate.Enabled = false;
                dtExpToDate.Enabled = false;
                IsCheckExp = true;
            }
            else
            {
                dtExpFromDate.Enabled = true;
                dtExpToDate.Enabled = true;
                IsCheckExp = false;
            }
        }

        private void chkdtNextFollowUpFromDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkdtNextFollowUpFromDate.Checked == true)
            {
                dtNextFollowUpFromDate.Enabled = false;
                dtNextFollowUpToDate.Enabled = false;
                IsNextFollowUp = true;
            }
            else
            {
                dtNextFollowUpFromDate.Enabled = true;
                dtNextFollowUpToDate.Enabled = true;
                IsNextFollowUp = false;
            }
        }

        private void cmbPG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            if (cmbPG.SelectedIndex == 0)
            {
                _oMAG = null;
                cmbMAG.Items.Clear();
                cmbMAG.Items.Add("<All>");
                cmbMAG.SelectedIndex = 0;
                return;
            }
            int nParentID = _oPG[cmbPG.SelectedIndex - 1].PdtGroupID;
            //Load MAG in combo
            _oMAG = new ProductGroups();
            _oMAG.Refresh(nParentID);
            cmbMAG.Items.Clear();
            cmbMAG.Items.Add("<All>");
            foreach (ProductGroup oProductGroup in _oMAG)
            {
                cmbMAG.Items.Add(oProductGroup.PdtGroupName);
            }
            cmbMAG.SelectedIndex = 0;
        }

        private void cmbMAG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            if (cmbMAG.SelectedIndex == 0)
            {
                _oASG = null;
                cmbASG.Items.Clear();
                cmbASG.Items.Add("<All>");
                cmbASG.SelectedIndex = 0;
                return;
            }

            int nParentID = _oMAG[cmbMAG.SelectedIndex - 1].PdtGroupID;
            //Load ASG in combo
            _oASG = new ProductGroups();
            _oASG.Refresh(nParentID);
            cmbASG.Items.Clear();
            cmbASG.Items.Add("<All>");
            foreach (ProductGroup oProductGroup in _oASG)
            {
                cmbASG.Items.Add(oProductGroup.PdtGroupName);
            }

            cmbASG.SelectedIndex = 0;
        }

        private void cmbASG_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            if (cmbASG.SelectedIndex == 0)
            {
                _oAG = null;
                cmbAG.Items.Clear();
                cmbAG.Items.Add("<All>");
                cmbAG.SelectedIndex = 0;
                return;
            }

            int nParentID = _oASG[cmbASG.SelectedIndex - 1].PdtGroupID;
            //Load AG in combo
            _oAG = new ProductGroups();
            _oAG.Refresh(nParentID);
            cmbAG.Items.Clear();
            cmbAG.Items.Add("<All>");
            foreach (ProductGroup oProductGroup in _oAG)
            {
                cmbAG.Items.Add(oProductGroup.PdtGroupName);
            }
            cmbAG.SelectedIndex = 0;
        }
    }
}
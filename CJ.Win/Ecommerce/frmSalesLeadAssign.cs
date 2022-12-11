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

namespace CJ.Win.Ecommerce
{
    public partial class frmSalesLeadAssign : Form
    {
        int nLeadID = 0;
        string sLeadNo = "";
        Brand _oBrand;
        ProductGroup _oMAG;
        SalesLead _oSalesLead;
        DateTime dtExpExcuDate;
        Showrooms _oShowrooms;
        Employees oEmployees;
        string sRemarks = "";
        public frmSalesLeadAssign()
        {
            InitializeComponent();
        }
        public void ShowDialog(SalesLead oSalesLead)
        {
            DBController.Instance.OpenNewConnection();
            this.Tag = oSalesLead;
            sRemarks = oSalesLead.Remarks;
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
            lblSpecificModel.Text = oSalesLead.ModelName;
            lblLeadAmount.Text = oSalesLead.LeadAmount.ToString();
            lblLeadQty.Text = oSalesLead.Qty.ToString();
            lblLeadDate.Text = oSalesLead.LeadDate.ToString("dd-MMM-yyyy");
            lblFollowUpDate.Text = oSalesLead.NextFollowUpDate.ToString("dd-MMM-yyyy");
            lblExpExecuteDate.Text = oSalesLead.ExpExecuteDate.ToString("dd-MMM-yyyy");

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

        private void LoadCombos()
        {
            DBController.Instance.OpenNewConnection();
            //Showrooms 
            _oShowrooms = new Showrooms();
            _oShowrooms.Refresh();
            cmbOutlet.Items.Clear();
            cmbOutlet.Items.Add("<All>");
            foreach (Showroom oShowroom in _oShowrooms)
            {
                cmbOutlet.Items.Add(oShowroom.ShowroomCode);
            }
            cmbOutlet.SelectedIndex = 0;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool UIValidation()
        {
            #region ValidInput
            if (cmbOutlet.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select a Outlet", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbOutlet.Focus();
                return false;
            }
            if (cmbSalesPerson.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select a Sales Person", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSalesPerson.Focus();
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
                    _oSalesLead.WarehouseID = _oShowrooms[cmbOutlet.SelectedIndex - 1].WarehouseID;
                    _oSalesLead.SalesPersonID = oEmployees[cmbSalesPerson.SelectedIndex - 1].EmployeeID;
                    _oSalesLead.AssignOutlet();

                    _oSalesLead.LeadNo = sLeadNo;
                    _oSalesLead.WarehouseID = _oShowrooms[cmbOutlet.SelectedIndex - 1].WarehouseID;
                    _oSalesLead.Remarks = sRemarks;
                    _oSalesLead.ExpExecuteDate = dtExpExcuDate.Date;
                    _oSalesLead.Status = (int)Dictionary.SalesLeadStatusPOS.Create;
                    _oSalesLead.AddHistory();
                    DBController.Instance.CommitTransaction();

                    MessageBox.Show("Successfully Assigned. LeadNo# " + sLeadNo, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cmbOutlet_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOutlet.SelectedIndex != 0)
            {
                //Sales Person
                oEmployees = new Employees();
                cmbSalesPerson.Items.Clear();
                oEmployees.GetSalesPersonJobLocationWiseHO(_oShowrooms[cmbOutlet.SelectedIndex - 1].ShowroomCode);
                cmbSalesPerson.Items.Add("<Select Sales Person>");
                foreach (Employee oEmployee in oEmployees)
                {
                    cmbSalesPerson.Items.Add(oEmployee.EmployeeName + ' ' + "[" + oEmployee.Category + "]");
                }
                if (oEmployees.Count > 0)
                    cmbSalesPerson.SelectedIndex = 0;

            }
        }

        private void frmSalesLeadAssign_Load(object sender, EventArgs e)
        {
            LoadCombos();
        }

    }
}
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
using CJ.Class.POS;

namespace CJ.POS
{
    public partial class frmDayPlanDetail : Form
    {
        public DateTime _dPlanDate;
        public DateTime _dTimeFrom;
        public DateTime _dTimeTo;
        public int _nPlanToId;
        public int _nPurposeId;
        public int _nActionStatusId;
        public string _sAddress;
        public int _nCustomerId;
        public string _sRemarks;
        private DayPlans _oDPs1;
        private DayPlans _oDPs2;

        public string _sPlanTo;
        public string _sPurpose;
        public string _sActionStatus;
        public string _sCustomer;

        public frmDayPlanDetail()
        {
            InitializeComponent();
        }

        //private void UILoad(int nUIControl)
        //{
        //    if (nUIControl == (int)Dictionary.SalesType.Retail)
        //    {

        //    }
        //    else if (nUIControl == (int)Dictionary.SalesType.B2C)
        //    {

        //    }
        //    else if (nUIControl == (int)Dictionary.SalesType.B2B)
        //    {

        //    }

        //}

        public void LoadCombo()
        {
            _oDPs1 = new DayPlans();
            cmbVisitPlanType.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oDPs1.GetVisitPlanType();
            cmbVisitPlanType.Items.Add("<Select Visit Plan>");
            foreach (DayPlan oVisitPlanType in _oDPs1)
            {
                cmbVisitPlanType.Items.Add(oVisitPlanType.PlanDescription);
            }
            if (_oDPs1.Count > 0)
                cmbVisitPlanType.SelectedIndex = 0;

            _oDPs2 = new DayPlans();
            cmbDayPlanPurpose.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oDPs2.GetDayPlanPurpose();
            cmbDayPlanPurpose.Items.Add("<Select Day Plan Purpose>");
            foreach (DayPlan oVisitPlanType in _oDPs2)
            {
                cmbDayPlanPurpose.Items.Add(oVisitPlanType.PlanDescription);
            }
            if (_oDPs2.Count > 0)
                cmbDayPlanPurpose.SelectedIndex = 0;
            
        }

        private void frmDayPlanDetail_Load(object sender, EventArgs e)
        {
            LoadCombo();
        }

        private bool ValidateUI()
        {
            if(cmbVisitPlanType.SelectedIndex==0)
            {
                MessageBox.Show("Please Select Visit Plan", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbVisitPlanType.Focus();
                return false;
            }
            if (cmbDayPlanPurpose.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Plan Purpose", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDayPlanPurpose.Focus();
                return false;
            }
            if(ctlCustomer1.txtCode.Text=="")
            {
                MessageBox.Show("Please Select Customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlCustomer1.txtCode.Focus();
                return false;
            }

            return true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidateUI())
            {
                _nPlanToId = _oDPs1[cmbVisitPlanType.SelectedIndex - 1].VisitPlanId;
                _nPurposeId = _oDPs2[cmbDayPlanPurpose.SelectedIndex - 1].VisitPlanId;
                _nCustomerId = ctlCustomer1.SelectedCustomer.CustomerID;
                _nActionStatusId = 1;
                _sRemarks = txtRemarks.Text;
                _dPlanDate = dtPlanDate.Value;
                _dTimeFrom = dtTimeFrom.Value;
                _dTimeTo = dtTimeTo.Value;
                _sCustomer = ctlCustomer1.SelectedCustomer.CustomerName;
                
                _sAddress = txtAddress.Text;
                _sPlanTo = _oDPs1[cmbVisitPlanType.SelectedIndex - 1].PlanDescription;
                _sPurpose = _oDPs2[cmbDayPlanPurpose.SelectedIndex - 1].PlanDescription;
                _sActionStatus = "Create";
                this.Close();
            }
        }


        private void ctlCustomer1_ChangeSelection(object sender, EventArgs e)
        {
            txtAddress.Text = ctlCustomer1.SelectedCustomer.CustomerAddress;
        }
    }
}

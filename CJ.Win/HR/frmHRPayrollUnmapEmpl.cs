using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.HR;

namespace CJ.Win.HR
{
    public partial class frmHRPayrollUnmapEmpl : Form
    {
        HRPayrolls _oHRPayrolls;
        int _nPayrollID;
        int _nCompanyID;

        public frmHRPayrollUnmapEmpl(int nPayrollID, int nCompanyID)
        {
            InitializeComponent();
            _nPayrollID = nPayrollID;
            _nCompanyID = nCompanyID;
        }

        private void frmHRPayrollUnmapEmpl_Load(object sender, EventArgs e)
        {
            lblComment.Text = "Please map below Employee before sending to Accpac";
            DataLoadControl();
        }

        private void DataLoadControl()
        {
            _oHRPayrolls = new HRPayrolls();

            lvwList.Items.Clear();
            DBController.Instance.OpenNewConnection();


            _oHRPayrolls.GetUnmapEmployee(_nPayrollID, _nCompanyID);

            this.Text = "Upmap Employee with Accpac | Total: " + "[" + _oHRPayrolls.Count + "]";
            foreach (HRPayroll oHRPayroll in _oHRPayrolls)
            {
                ListViewItem oItem = lvwList.Items.Add(oHRPayroll.EmployeeCode);
                oItem.SubItems.Add(oHRPayroll.EmployeeName);
                oItem.SubItems.Add(oHRPayroll.DesignationName);
                oItem.SubItems.Add(oHRPayroll.DepartmrntName);

                oItem.Tag = oHRPayroll;
            }

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
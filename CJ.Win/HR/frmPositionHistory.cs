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
    public partial class frmPositionHistory : Form
    {
        HRPositionAssignHistorys _oHRPositionAssignHistorys;
        Company _oCompany;
        int nPositionID;
        int nCompanyID;
        string sPositionCode;
        string sPositionName;

        public frmPositionHistory(int PositionID, int CompanyID, string PositionCode, string PositionName)
        {
            nPositionID = PositionID;
            nCompanyID = CompanyID;
            sPositionCode = PositionCode;
            sPositionName = PositionName;

            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPositionHistory_Load(object sender, EventArgs e)
        {
            lblSelectedNode.Text = sPositionName + " [" + sPositionCode + "]";
            _oCompany = new Company();
            _oCompany.CompanyID = nCompanyID;
            _oCompany.Refresh();
            lblCompany.Text = _oCompany.CompanyName + " [" + _oCompany.CompanyCode + "]";

            DataLoadControl();
        }

        private void DataLoadControl()
        {
            _oHRPositionAssignHistorys = new HRPositionAssignHistorys();
            lvwItem.Items.Clear();
            //DBController.Instance.OpenNewConnection();
            _oHRPositionAssignHistorys.Refresh(nPositionID);
            foreach (HRPositionAssignHistory oHRPositionAssignHistory in _oHRPositionAssignHistorys)
            {
                ListViewItem oItem = lvwItem.Items.Add(oHRPositionAssignHistory.EmployeeCode + "-" + oHRPositionAssignHistory.EmployeeName);
                oItem.SubItems.Add(oHRPositionAssignHistory.DesignationName);
                oItem.SubItems.Add(oHRPositionAssignHistory.FromDate.ToString("dd-MMM-yyyy"));
                try
                {
                    DateTime temp = Convert.ToDateTime(oHRPositionAssignHistory.ToDate);
                    oItem.SubItems.Add(temp.ToString("dd-MMM-yyyy"));
                }
                catch
                {
                    oItem.SubItems.Add(oHRPositionAssignHistory.ToDate.ToString());
                }
                oItem.SubItems.Add(oHRPositionAssignHistory.Remarks);
            }
        }

        private void lvwItem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
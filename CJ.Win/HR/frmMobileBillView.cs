using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.HR;
using CJ.Class.Library;

namespace CJ.Win.HR
{
    public partial class frmMobileBillView : Form
    {
        private MobileBills _oMobileBill;
        private MobileNumberAssign oMobileNumberAssign;
        TELLib _oTELLib;
        public frmMobileBillView()
        {
            InitializeComponent();
        }
        public void ShowDialog(MobileNumberAssign oMobileNumberAssign)
        {
            this.Tag = oMobileNumberAssign;
            lblMobileNo.Text = oMobileNumberAssign.MobileNumber;
            this.ShowDialog();
        }
        private void frmMobileBillView_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void DataLoadControl()
        {
            _oTELLib=new TELLib();
            double nTotalBill = 0;
            MobileNumberAssign oMobileNumberAssign = (MobileNumberAssign)this.Tag;
            _oMobileBill = new MobileBills();
            lvwMobileBillView.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oMobileBill.GetData(oMobileNumberAssign.MobileID);
            foreach (MobileBill oMobileBill in _oMobileBill)
            {
                ListViewItem oItem = lvwMobileBillView.Items.Add(oMobileBill.EmployeeCode);
                oItem.SubItems.Add(oMobileBill.UserName);
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.MobileUserType),oMobileBill.UserTypeID));
                oItem.SubItems.Add(oMobileBill.CompanyCode);
                oItem.SubItems.Add(oMobileBill.DepartmentName);
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.MobileCreaditLimitType), oMobileBill.CreaditLimitType));
                oItem.SubItems.Add(oMobileBill.CreaditLimit.ToString());
                oItem.SubItems.Add(oMobileBill.DatapacLimit.ToString());
                oItem.SubItems.Add(oMobileBill.Datapac);
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.MonthShortName), oMobileBill.TMonth));
                oItem.SubItems.Add(oMobileBill.TYear.ToString());
                oItem.SubItems.Add(oMobileBill.TotalLimit.ToString());
                oItem.SubItems.Add(_oTELLib.TakaFormat(oMobileBill.BillAmount));
                oItem.SubItems.Add(oMobileBill.DeductFromSalary.ToString());                            
                nTotalBill += oMobileBill.BillAmount;
                oItem.Tag = oMobileBill;
            }
            lblTotalBill.Text =  "Total Bill: " + _oTELLib.TakaFormat(nTotalBill);;
             
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
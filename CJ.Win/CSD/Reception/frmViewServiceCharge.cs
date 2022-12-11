using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;

namespace CJ.Win.CSD.Reception
{
    public partial class frmViewServiceCharge : Form
    {
        CSDServiceCharge _oCSDServiceCharge;
        CSDServiceChargeCustomers _oCSDServiceChargeCustomers;
        CSDServiceChargeProduct _oCSDServiceChargeProduct;
        int _nProductID;
        public frmViewServiceCharge()
        {
            InitializeComponent();
        }
        public void ShowDialog(int nProductID)
        {
            _nProductID = nProductID;
            this.ShowDialog();
        }
        private void frmViewServiceCharge_Load(object sender, EventArgs e)
        {
            ViewCharges();
        }
        private void ViewCharges()
        {
            _oCSDServiceCharge = new CSDServiceCharge();
            _oCSDServiceChargeProduct = new CSDServiceChargeProduct();
            _oCSDServiceCharge.ServiceChargeID = _oCSDServiceChargeProduct.GetServiceChargeID(_nProductID);
            _oCSDServiceCharge.Refresh();


            _oCSDServiceChargeCustomers = new CSDServiceChargeCustomers();
            _oCSDServiceChargeCustomers.RefreshBySCID(_oCSDServiceCharge.ServiceChargeID);
            foreach (CSDServiceChargeCustomer oCSDServiceChargeCustomer in _oCSDServiceChargeCustomers)
            {
                if (oCSDServiceChargeCustomer.ChargeType == (int)Dictionary.CSDServiceChargeType.Service_Charge)
                {
                    txtServiceTotalCharge.Text = oCSDServiceChargeCustomer.Amount.ToString();
                }
                else if (oCSDServiceChargeCustomer.ChargeType == (int)Dictionary.CSDServiceChargeType.Inspection_Charge)
                {
                    txtInspectionTotalCharge.Text = oCSDServiceChargeCustomer.Amount.ToString();
                }
                else if (oCSDServiceChargeCustomer.ChargeType == (int)Dictionary.CSDServiceChargeType.Installation_Charge)
                {
                    txtInstallationTotalCharge.Text = oCSDServiceChargeCustomer.Amount.ToString();
                }
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
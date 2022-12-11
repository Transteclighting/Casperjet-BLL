using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.IT;
using CJ.Report;

namespace CJ.Win.EPS
{
    public partial class frmEMICalculation : Form
    {
        EMICalculationDetail _oEMICalculationDetail;
        DateTime dtDate;

        public frmEMICalculation()
        {
            InitializeComponent();
        }

        private void btShowEMI_Click(object sender, EventArgs e)
        {
            int NPer=0;
            double PV=0;
            double Rate=0;

            dgvEMI.Rows.Clear();
            try
            {
             NPer=int.Parse(txtInstallmentNo.Text);         
             PV=Convert.ToDouble(txtPV.Text);
             Rate=Convert.ToDouble(txtInteresrRate.Text);
            }
            catch
            {
                MessageBox.Show("Please entart valied data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (dtStartDate.Value.Day > 15)
                dtDate = dtStartDate.Value.Date.AddMonths(1);
            else dtDate = dtStartDate.Value.Date;

            _oEMICalculationDetail = new EMICalculationDetail();
            _oEMICalculationDetail.Result(Rate, NPer, PV, dtDate);           

            int i = 0;
            foreach (EMICalculation oEMICalculation in _oEMICalculationDetail)
            {
                dgvEMI.Rows.Add();
                dgvEMI[0, i].Value = oEMICalculation.InstallmentNo;
                dgvEMI[1, i].Value = oEMICalculation.BalancePrincipal;
                dgvEMI[2, i].Value = oEMICalculation.PrincipalPayable;
                dgvEMI[3, i].Value = oEMICalculation.InterestPayable;
                dgvEMI[4, i].Value = oEMICalculation.ClosingBalance;
                dgvEMI[5, i].Value = oEMICalculation.PaymentDate;
                i++;
            }

        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            if (_oEMICalculationDetail != null)
            {
                if (_oEMICalculationDetail.Count > 0)
                {
                    crtEMICalculation oReport = new crtEMICalculation();
                    oReport.SetDataSource(_oEMICalculationDetail);
                    oReport.SetParameterValue("User Name", Utility.Username);
                    oReport.SetParameterValue("PV", txtPV.Text);
                    oReport.SetParameterValue("installno",txtInstallmentNo.Text);
                    oReport.SetParameterValue("rate", txtInteresrRate.Text);
                    oReport.SetParameterValue("CompanyName", Utility.CompanyName);
                    oReport.SetParameterValue("Report_Name", "Equal Monthly Installment [EMI]");

                    frmPrintPreview oFrom = new frmPrintPreview();
                    oFrom.ShowDialog(oReport);

                }

            }
            else MessageBox.Show("Please first click show buttom", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
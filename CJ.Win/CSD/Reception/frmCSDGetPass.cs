using System;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;
using CJ.Class.HR;
using CJ.Report;
using CJ.Report.CSD;

namespace CJ.Win.CSD.Reception
{
    public partial class frmCSDGetPass : Form
    {
        public frmCSDGetPass()
        {
            InitializeComponent();
        }
        public void ShowDialog(CSDJob oCSDJob)
        {
            this.Tag = oCSDJob;
            txtJobNo.Text = oCSDJob.JobNo;
            this.ShowDialog();
        }
        private void rdoCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoCustomer.Checked)
            {
                ctlCustomer1.Visible = false;
                ctlInterService1.Visible = false;
                lblSenTo.Visible = false;
            }


        }

        private void rdoOutlet_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoOutlet.Checked)
            {
                lblSenTo.Visible = true;
                lblSenTo.Text = "Outlet";
                ctlCustomer1.Visible = true;
            }
            else
            {
                ctlCustomer1.Visible = false;
            }
        }

        private void rdoDealer_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoDealer.Checked)
            {
                lblSenTo.Visible = true;
                lblSenTo.Text = "Dealer";
                ctlCustomer1.Visible = true;
                
            }
            else
            {
                ctlCustomer1.Visible = false;
            }
        }

        private void rdoInterService_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoInterService.Checked)
            {
                lblSenTo.Visible = true;
                lblSenTo.Text = "Inter Service";
                ctlInterService1.Visible = true;
            }
            else
            {
                ctlInterService1.Visible = false;
                
            }
        }

        private bool ValidateUiInput()
        {
            #region Input Information Validation
            if (rdoDealer.Checked)
            {
                if (ctlCustomer1.SelectedCustomer == null || ctlCustomer1.txtCode.Text == "")
                {
                    MessageBox.Show("Please Select a Customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ctlCustomer1.Focus();
                    return false;
                }
            }

            else if (rdoOutlet.Checked)
            {
                if (ctlCustomer1.SelectedCustomer == null || ctlCustomer1.txtCode.Text == "")
                {
                    MessageBox.Show("Please Select a Customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ctlCustomer1.Focus();
                    return false;
                }
            }
            else if(rdoInterService.Checked)
            {
            if (ctlInterService1.SelectedInterService == null || ctlInterService1.txtCode.Text == "")
            {
                MessageBox.Show("Please Select a Inter Service", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlInterService1.Focus();
                return false;
            }
            }

            #endregion

            return true;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (ValidateUiInput())
            {
                Print();
            }
        }

        private void Print()
        {
           
            this.Cursor = Cursors.WaitCursor;
            CSDJob oCsdJob = (CSDJob) Tag;

            rptGatePass oReport = new rptGatePass();
            rptGatePassDetail oDoc = new rptGatePassDetail();

            if (rdoDealer.Checked || rdoOutlet.Checked)
            {
                oReport.SetParameterValue("Name", ctlCustomer1.SelectedCustomer.CustomerName);
                oReport.SetParameterValue("Address", ctlCustomer1.SelectedCustomer.CustomerAddress);
                oDoc.SetParameterValue("Name", ctlCustomer1.SelectedCustomer.CustomerName);
                oDoc.SetParameterValue("Address", ctlCustomer1.SelectedCustomer.CustomerAddress);
                oDoc.SetParameterValue("Tel", ctlCustomer1.SelectedCustomer.CustomerTelephone ?? string.Empty);
                oDoc.SetParameterValue("Mobile", ctlCustomer1.SelectedCustomer.CellPhoneNo ?? string.Empty);
            }
            else if (rdoInterService.Checked)
            {
                oReport.SetParameterValue("Name", ctlInterService1.SelectedInterService.Name);
                oReport.SetParameterValue("Address", ctlInterService1.SelectedInterService.Address);
                oDoc.SetParameterValue("Name", ctlInterService1.SelectedInterService.Name);
                oDoc.SetParameterValue("Address", ctlInterService1.SelectedInterService.Address);
                oDoc.SetParameterValue("Tel", ctlInterService1.SelectedInterService.Phone ?? string.Empty);
                oDoc.SetParameterValue("Mobile", ctlInterService1.SelectedInterService.Mobile ?? string.Empty);
            }
            else
            {
                oReport.SetParameterValue("Name", oCsdJob.CustomerName);
                oReport.SetParameterValue("Address", oCsdJob.CustomerAddress);
                oDoc.SetParameterValue("Name", oCsdJob.CustomerName);
                oDoc.SetParameterValue("Address", oCsdJob.CustomerAddress);
                oDoc.SetParameterValue("Tel", oCsdJob.TelePhone ?? string.Empty);
                oDoc.SetParameterValue("Mobile", oCsdJob.MobileNo ?? string.Empty);
            }


            oReport.SetParameterValue("Job", oCsdJob.JobNo);
            oReport.SetParameterValue("Goods", oCsdJob.ProductName);
            oDoc.SetParameterValue("Job", oCsdJob.JobNo);
            oDoc.SetParameterValue("Goods", oCsdJob.ProductName);
            oDoc.SetParameterValue("Remarks", txtRemarks.Text);

            if (oCsdJob.JobCreateLocation > 0)
            {
                var aJobLocation = new JobLocation
                {
                    JobLocationID = oCsdJob.JobCreateLocation == 139 ? Utility.JobLocation : oCsdJob.JobCreateLocation
                };
                aJobLocation.Refresh();
                oDoc.SetParameterValue("ServiceCenterName", aJobLocation.JobLocationName);
                oDoc.SetParameterValue("ServiceCenterAddress", aJobLocation.Description);

                oReport.SetParameterValue("ServiceCenterName", aJobLocation.JobLocationName);
                oReport.SetParameterValue("ServiceCenterAddress", aJobLocation.Description);
            }
            else
            {
                oDoc.SetParameterValue("ServiceCenterName", "Customer Service Department");
                oDoc.SetParameterValue("ServiceCenterAddress", "Sadar Road, Mohakhali, Dhaka-1206");

                oReport.SetParameterValue("ServiceCenterName", "Customer Service Department");
                oReport.SetParameterValue("ServiceCenterAddress", "Sadar Road, Mohakhali, Dhaka-1206");
            }


            frmPrintPreview oFrom = new frmPrintPreview();
            oFrom.ShowDialog(oReport);
            oFrom.ShowDialog(oDoc);
            Cursor = Cursors.Default;
        }

     
    }
}
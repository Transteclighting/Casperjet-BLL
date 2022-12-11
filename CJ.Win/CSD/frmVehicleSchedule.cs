using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.CSD;
using CJ.Class;

namespace CJ.Win
{
    public partial class frmVehicleSchedule : Form
    {
        public VehicleSchedule _oVehicleSchedule;

        public VehicleScheduleHistory oVehicleScheduleHistory;
    
        public frmVehicleSchedule()
        {
            InitializeComponent();
        }

        public void ShowDialog(VehicleSchedule oVehicleSchedule)
        {
            this.Tag = oVehicleSchedule;

            txtLocation.Text = oVehicleSchedule.Location.ToString();
            txtRemarks.Text = oVehicleSchedule.Remarks.ToString();
            if (oVehicleSchedule.IsNoJob == 1)
            {
                chkJobNoAvailable.Checked = true;
                ctlProduct2.txtCode.Text = oVehicleSchedule.ProductCode.ToString();
                txtCustomerName.Text = oVehicleSchedule.CustomerName.ToString();
                txtAddress.Text = oVehicleSchedule.Address.ToString();
                txtContactNo.Text = oVehicleSchedule.ContactNo.ToString();
                ctlCSDJob1.txtCode.Text = null;
            }
            if (oVehicleSchedule.IsNoJob == 0)
            {
                chkJobNoAvailable.Checked = false;
                ctlCSDJob1.txtCode.Text = oVehicleSchedule.JobNo.ToString();
                ctlProduct2.txtCode.Text = null;
                txtCustomerName.Text = null;
                txtAddress.Text = null;
                txtContactNo.Text = null;
            }
            if (oVehicleSchedule.JobType == 1)
            {
                rdoFullWarranty.Checked = true;
                rdoPaid.Checked = false;
                rdoServiceWarranty.Checked = false;
            }
            if (oVehicleSchedule.JobType == 2)
            {
                rdoFullWarranty.Checked = false;
                rdoPaid.Checked = true;
                rdoServiceWarranty.Checked = false;
            }
            if (oVehicleSchedule.JobType == 3)
            {
                rdoFullWarranty.Checked = false;
                rdoPaid.Checked = false;
                rdoServiceWarranty.Checked = true;
            }
            if (oVehicleSchedule.ReqType == 1)
            {
                rdoPickUp.Checked = true;
                rdoDrop.Checked = false;
            }
            if (oVehicleSchedule.ReqType == 2)
            {
                rdoPickUp.Checked = false;
                rdoDrop.Checked = true;
            }
            if (oVehicleSchedule.ContactForDateTime == 0)
            {
                grpEDD.Enabled = true;

                dtExpectedDate.Value = Convert.ToDateTime(oVehicleSchedule.ExpectedDate.ToString());
                dtForm.Value = Convert.ToDateTime(oVehicleSchedule.ExpectedTimeFrom.ToString());
                dtTo.Value = Convert.ToDateTime(oVehicleSchedule.ExpectedTimeTo.ToString());

                chkContactCustomer.Checked = false;
            }
            if (oVehicleSchedule.ContactForDateTime == 1)
            {
                grpEDD.Enabled = false;
                
                chkContactCustomer.Checked = true;
            }

            this.ShowDialog();
        }

        private bool validateUIInput()
        {
            
            #region Input Information Validation
            if (this.Tag == null)
            {
                if (chkJobNoAvailable.Checked == false)
                {
                    if (ctlCSDJob1.SelectedJob == null || ctlCSDJob1.txtCode.Text == "")
                    {
                        MessageBox.Show("Please Select a Job Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ctlCSDJob1.Focus();
                        return false;
                    }
                }
                else
                {
                    if (txtCustomerName.Text == "")
                    {
                        MessageBox.Show("Please enter Customer Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCustomerName.Focus();
                        return false;
                    }
                    if (txtAddress.Text == "")
                    {
                        MessageBox.Show("Please enter Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtAddress.Focus();
                        return false;
                    }
                    if (txtContactNo.Text == "")
                    {
                        MessageBox.Show("Please enter Contact No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtContactNo.Focus();
                        return false;
                    }
                    if (ctlProduct2.SelectedSerarchProduct == null || ctlProduct2.txtCode.Text == "")
                    {
                        MessageBox.Show("Please Select a Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ctlProduct2.Focus();
                        return false;
                    }

                }
            
            }
            else
            {
                VehicleSchedule oVehicleSchedule = (VehicleSchedule)this.Tag;
                if (oVehicleSchedule.IsNoJob == 0)
                {
                    if (ctlCSDJob1.SelectedJob == null || ctlCSDJob1.txtCode.Text == "")
                    {
                        MessageBox.Show("Please Select a Job Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ctlCSDJob1.Focus();
                        return false;
                    }
                }
                else

                {
                    if (txtCustomerName.Text == "")
                    {
                        MessageBox.Show("Please enter Customer Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCustomerName.Focus();
                        return false;
                    }
                    if (txtAddress.Text == "")
                    {
                        MessageBox.Show("Please enter Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtAddress.Focus();
                        return false;
                    }
                    if (txtContactNo.Text == "")
                    {
                        MessageBox.Show("Please enter Contact No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtContactNo.Focus();
                        return false;
                    }
                    if (ctlProduct2.SelectedSerarchProduct == null || ctlProduct2.txtCode.Text == "")
                    {
                        MessageBox.Show("Please Select a Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ctlProduct2.Focus();
                        return false;
                    }

                }

            }

            if (txtLocation.Text == "")
            {
                MessageBox.Show("Please enter Area", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtLocation.Focus();
                return false;
            }

            #endregion

            return true;
        }

        private void Save()
        {
            if (this.Tag == null)
            {
                VehicleSchedule oVehicleSchedule=new VehicleSchedule();

                if (chkJobNoAvailable.Checked==false)
                {
                    oVehicleSchedule.IsNoJob = (int)Dictionary.InquiryCommunicationStatus.False;
                    oVehicleSchedule.JobID = ctlCSDJob1.SelectedJob.JobID;
                    oVehicleSchedule.CustomerName = null;
                    oVehicleSchedule.Address = null;
                    oVehicleSchedule.ContactNo = null;
                    oVehicleSchedule.JobType = 0;
                    oVehicleSchedule.ProductID = 0;
                    oVehicleSchedule.Type = 2;
 
                }
                if (chkJobNoAvailable.Checked == true)
                {
                    oVehicleSchedule.IsNoJob = (int)Dictionary.InquiryCommunicationStatus.True;
                    oVehicleSchedule.JobID = 0;
                    oVehicleSchedule.CustomerName = txtCustomerName.Text;
                    oVehicleSchedule.Address = txtAddress.Text;
                    oVehicleSchedule.ContactNo = txtContactNo.Text;
                    oVehicleSchedule.ProductID = ctlProduct2.SelectedSerarchProduct.ProductID;
                    if (rdoFullWarranty.Checked == true)
                    {
                        oVehicleSchedule.JobType = (int)Dictionary.CSDJobType.FullWarranty;
                    }
                    else if (rdoPaid.Checked == true)
                    {
                        oVehicleSchedule.JobType = (int)Dictionary.CSDJobType.Paid;
                    }
                    else oVehicleSchedule.JobType = (int)Dictionary.CSDJobType.ServiceWarranty;
                    oVehicleSchedule.Type = 3;
                }
                oVehicleSchedule.Location =txtLocation.Text;
                if (rdoPickUp.Checked == true)
                { 
                oVehicleSchedule.ReqType=(int)Dictionary.VehicleRequisitionType.PickUp;
                }
                else oVehicleSchedule.ReqType=(int)Dictionary.VehicleRequisitionType.Drop;

                if (chkContactCustomer.Checked == true)
                {
                    oVehicleSchedule.ExpectedDate = null;
                    oVehicleSchedule.ExpectedTimeFrom = null;
                    oVehicleSchedule.ExpectedTimeTo = null;
                    oVehicleSchedule.ContactForDateTime = (int)Dictionary.InquiryCommunicationStatus.True;

                }
                else
                {
                    oVehicleSchedule.ExpectedDate = dtExpectedDate.Value;
                    oVehicleSchedule.ExpectedTimeFrom = dtForm.Value;
                    oVehicleSchedule.ExpectedTimeTo = dtTo.Value;
                    oVehicleSchedule.ContactForDateTime = (int)Dictionary.InquiryCommunicationStatus.False;
                }
                oVehicleSchedule.Remarks =txtRemarks.Text;
                oVehicleSchedule.JobLocationId = Utility.JobLocation;


                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oVehicleSchedule.Add();

                    oVehicleScheduleHistory = new VehicleScheduleHistory();

                    oVehicleScheduleHistory.VRID = oVehicleSchedule.VRID;
                    oVehicleScheduleHistory.Remarks = txtRemarks.Text;
                    oVehicleScheduleHistory.Status = (int)Dictionary.VehicleRequisitionStatus.Requisition;
                    if (chkContactCustomer.Checked == false)
                    {
                        oVehicleScheduleHistory.Dates = oVehicleSchedule.ExpectedDate.ToString();
                        oVehicleScheduleHistory.TimeFrom = oVehicleSchedule.ExpectedTimeFrom.ToString();
                        oVehicleScheduleHistory.TimeTo = oVehicleSchedule.ExpectedTimeTo.ToString();
                    }
                    else
                    {
                        oVehicleScheduleHistory.Dates = null;
                        oVehicleScheduleHistory.TimeFrom = null;
                        oVehicleScheduleHistory.TimeTo = null;
                    }
                    oVehicleScheduleHistory.AddVehicleScheduleHistory();

                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Requisition Create Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Refresh();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                VehicleSchedule oVehicleSchedule = (VehicleSchedule)this.Tag;

                if (chkJobNoAvailable.Checked == false)
                {
                    oVehicleSchedule.IsNoJob = (int)Dictionary.InquiryCommunicationStatus.False;
                    oVehicleSchedule.JobID = ctlCSDJob1.SelectedJob.JobID;
                    oVehicleSchedule.CustomerName = null;
                    oVehicleSchedule.Address = null;
                    oVehicleSchedule.ContactNo = null;
                    oVehicleSchedule.JobType = 0;
                    oVehicleSchedule.ProductID = 0;
                }
                else
                {
                    oVehicleSchedule.IsNoJob = (int)Dictionary.InquiryCommunicationStatus.True;
                    oVehicleSchedule.JobID = 0;
                    oVehicleSchedule.CustomerName = txtCustomerName.Text;
                    oVehicleSchedule.Address = txtAddress.Text;
                    oVehicleSchedule.ContactNo = txtContactNo.Text;
                    oVehicleSchedule.ProductID = ctlProduct2.SelectedSerarchProduct.ProductID;
                    if (rdoFullWarranty.Checked == true)
                    {
                        oVehicleSchedule.JobType = (int)Dictionary.CSDJobType.FullWarranty;
                    }
                    else if (rdoPaid.Checked == true)
                    {
                        oVehicleSchedule.JobType = (int)Dictionary.CSDJobType.Paid;
                    }
                    else oVehicleSchedule.JobType = (int)Dictionary.CSDJobType.ServiceWarranty;

                }
                oVehicleSchedule.Location = txtLocation.Text;
                if (rdoPickUp.Checked == true)
                {
                    oVehicleSchedule.ReqType = (int)Dictionary.VehicleRequisitionType.PickUp;
                }
                else oVehicleSchedule.ReqType = (int)Dictionary.VehicleRequisitionType.Drop;

                if (chkContactCustomer.Checked == true)
                {
                    oVehicleSchedule.ExpectedDate = null;
                    oVehicleSchedule.ExpectedTimeFrom = null;
                    oVehicleSchedule.ExpectedTimeTo = null;
                    oVehicleSchedule.ContactForDateTime = (int)Dictionary.InquiryCommunicationStatus.True;
                }
                else
                {
                    oVehicleSchedule.ExpectedDate = dtExpectedDate.Value;
                    oVehicleSchedule.ExpectedTimeFrom = dtForm.Value;
                    oVehicleSchedule.ExpectedTimeTo = dtTo.Value;
                    oVehicleSchedule.ContactForDateTime = (int)Dictionary.InquiryCommunicationStatus.False;
                }
                oVehicleSchedule.Remarks = txtRemarks.Text;


                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oVehicleSchedule.Edit();

                    oVehicleScheduleHistory = new VehicleScheduleHistory();

                    oVehicleScheduleHistory.VRID = oVehicleSchedule.VRID;
                    oVehicleScheduleHistory.Status = (int)Dictionary.VehicleRequisitionStatus.Requisition;
                    oVehicleScheduleHistory.Remarks = txtRemarks.Text;
                    if (oVehicleSchedule.ContactForDateTime == 0)
                    {
                        oVehicleScheduleHistory.Dates = oVehicleSchedule.ExpectedDate.ToString();
                        oVehicleScheduleHistory.TimeFrom = oVehicleSchedule.ExpectedTimeFrom.ToString();
                        oVehicleScheduleHistory.TimeTo = oVehicleSchedule.ExpectedTimeTo.ToString();
                    }
                    else
                    {
                        oVehicleScheduleHistory.Dates = null;
                        oVehicleScheduleHistory.TimeFrom = null;
                        oVehicleScheduleHistory.TimeTo = null;
                    }

                    oVehicleScheduleHistory.UpdateHistoryRemarks();

                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Requisition Update Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Refresh();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkJobNoAvailable_CheckedChanged(object sender, EventArgs e)
        {
            if (chkJobNoAvailable.Checked == true)
            {
                grpJobNo.Enabled = false;
                grpCustomerDetail.Enabled = true;
                rdoFullWarranty.Checked = true;
            }
            else
            {
                grpJobNo.Enabled = true;
                grpCustomerDetail.Enabled = false;
            }
        }

        private void frmVehicleSchedule_Load(object sender, EventArgs e)
        {

            if (this.Tag == null)
            {
                chkContactCustomer.Checked = false;
                chkJobNoAvailable.Checked = false;
                grpJobNo.Enabled = true;
                grpCustomerDetail.Enabled = false;
                rdoPickUp.Checked = true;
            }
            else
            {
                VehicleSchedule oVehicleSchedule = (VehicleSchedule)this.Tag;
                if (oVehicleSchedule.IsNoJob == 0)
                {
                    chkJobNoAvailable.Checked = false;
                    grpCustomerDetail.Enabled = false;
                    grpJobNo.Enabled = true;
                }
                if (oVehicleSchedule.IsNoJob == 1)
                {
                    chkJobNoAvailable.Checked = true;
                    grpCustomerDetail.Enabled = true;
                    grpJobNo.Enabled = false;
                }
                if (oVehicleSchedule.ContactForDateTime == 0)
                {
                    grpEDD.Enabled = true;
                    chkContactCustomer.Checked = false;
                }
                if (oVehicleSchedule.ContactForDateTime == 1)
                {
                    grpEDD.Enabled = false;
                    chkContactCustomer.Checked = true;
                }

            }


        }

        private void chkContactCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (chkContactCustomer.Checked == true)
            {
                grpEDD.Enabled = false;
            }
            else
            {
                grpEDD.Enabled = true;
            }
        }
    

    }
}
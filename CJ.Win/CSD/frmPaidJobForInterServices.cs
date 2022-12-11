using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.CSD;
using CJ.Class;
using CJ.Class.Report;
using CJ.Class.Library;
using CJ.Win.Security;
using CJ.Report;
using CJ.Report.CSD;

namespace CJ.Win
{
    public partial class frmPaidJobForInterServices : Form
    {
        private int _nStatus;
        Utilities _oUtilitys;
        PaidJobForInterServices oPaidJobForInterServices;
        public PaidJobForInterService oPaidJobForInterService;
        public PaidJobForInterServiceHistory oPaidJobForInterServiceHistory;
        public InterService oInterService;
        public ChannelFromCassandra oChannelFromCassandra;
        public Product oProduct;

        public frmPaidJobForInterServices()
        {
            InitializeComponent();
        }
        private void frmPaidJobForInterServices_Load(object sender, EventArgs e)
        {
            getStatus();
            DataLoadControl();
        }
        private void getStatus()
        {
            //Paid Job Status
            _oUtilitys = new Utilities();
            cmbStatus.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oUtilitys.GetPaidJobStatus();
            foreach (Utility oUtility in _oUtilitys)
            {
                cmbStatus.Items.Add(oUtility.Satus);
            }
            cmbStatus.SelectedIndex = cmbStatus.Items.Count - 1;


            cmbCommunication.Items.Add("All");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.InquiryCommunicationStatus)))
            {
                cmbCommunication.Items.Add(Enum.GetName(typeof(Dictionary.InquiryCommunicationStatus), GetEnum));
            }
            cmbCommunication.SelectedIndex = cmbCommunication.Items.Count - 3;

        }

        private void DataLoadControl()
        {
            PaidJobForInterServices oPaidJobForInterServices = new PaidJobForInterServices();

           lvwPaidJobForInterServices.Items.Clear();
            DBController.Instance.OpenNewConnection();


            oPaidJobForInterServices = new PaidJobForInterServices();

            {
                if (All.Checked == false)
                {

                    if (ctlInterService1.SelectedInterService != null)
                    {
                        oPaidJobForInterServices.Refresh(dtFromDate.Value.Date, dtToDate.Value.Date, txtPaidJobNo.Text, txtName.Text, txtContactNo.Text, txtLocation.Text, _oUtilitys[cmbStatus.SelectedIndex].SatusId, ctlInterService1.SelectedInterService.InterServiceID, txtProductCode.Text, txtProductName.Text, cmbCommunication.SelectedIndex - 1);
                    }
                    else
                    {
                        oPaidJobForInterServices.Refresh(dtFromDate.Value.Date, dtToDate.Value.Date, txtPaidJobNo.Text, txtName.Text, txtContactNo.Text, txtLocation.Text, _oUtilitys[cmbStatus.SelectedIndex].SatusId, 0, txtProductCode.Text, txtProductName.Text, cmbCommunication.SelectedIndex - 1);
                    }
                }
                else
                    if (ctlInterService1.SelectedInterService != null)
                    {
                        oPaidJobForInterServices.RefreshAll(txtPaidJobNo.Text, txtName.Text, txtContactNo.Text, txtLocation.Text, _oUtilitys[cmbStatus.SelectedIndex].SatusId, ctlInterService1.SelectedInterService.InterServiceID, txtProductCode.Text, txtProductName.Text, cmbCommunication.SelectedIndex - 1);
                    }
                    else
                    {
                        oPaidJobForInterServices.RefreshAll(txtPaidJobNo.Text, txtName.Text, txtContactNo.Text, txtLocation.Text, _oUtilitys[cmbStatus.SelectedIndex].SatusId, 0, txtProductCode.Text, txtProductName.Text, cmbCommunication.SelectedIndex - 1);
                    }
                
            }
            this.Text = "Total " + "[" + oPaidJobForInterServices.Count + "]";
            foreach (PaidJobForInterService oPaidJobForInterService in oPaidJobForInterServices)
            {
                ListViewItem oItem = lvwPaidJobForInterServices.Items.Add(oPaidJobForInterService.PaidJobID.ToString());
                if (oPaidJobForInterService.Status == (int)Dictionary.ISPaidJobStatus.Assign)
                {
                    oItem.SubItems.Add("Assign");
                }
                else if (oPaidJobForInterService.Status == (int)Dictionary.ISPaidJobStatus.Cancel)
                {
                    oItem.SubItems.Add("Cancel");
                }
                else if (oPaidJobForInterService.Status == (int)Dictionary.ISPaidJobStatus.ConvertToCSDJob)
                {
                    oItem.SubItems.Add("ConvertToCSDJob");
                }
                else if (oPaidJobForInterService.Status == (int)Dictionary.ISPaidJobStatus.ServiceProvided)
                {
                    oItem.SubItems.Add("ServiceProvided");
                }
                else if (oPaidJobForInterService.Status == (int)Dictionary.ISPaidJobStatus.Pending)
                {
                    oItem.SubItems.Add("Pending");
                }
                else if (oPaidJobForInterService.Status == (int)Dictionary.ISPaidJobStatus.Receive)
                {
                    oItem.SubItems.Add("Receive");
                }
                else if (oPaidJobForInterService.Status == (int)Dictionary.ISPaidJobStatus.WorkInProgress)
                {
                    oItem.SubItems.Add("WorkInProgress");
                }
                oItem.SubItems.Add(oPaidJobForInterService.CreateDate.ToString());
                oItem.SubItems.Add(oPaidJobForInterService.CustomerName);
                oItem.SubItems.Add(oPaidJobForInterService.ContactNo.ToString());
                oItem.SubItems.Add(oPaidJobForInterService.Product.ProductCode);
                oItem.SubItems.Add(oPaidJobForInterService.Product.ProductName);
                oItem.SubItems.Add(oPaidJobForInterService.ProductFaultFromCassandra.Description);
                oItem.SubItems.Add(oPaidJobForInterService.ExpectedDateOnly.ToString());
                oItem.SubItems.Add(oPaidJobForInterService.ExpectedTime.ToString());
                oItem.SubItems.Add(oPaidJobForInterService.ScheduleDateOnly.ToString());
                oItem.SubItems.Add(oPaidJobForInterService.ScheduleTime.ToString());
                oItem.SubItems.Add(oPaidJobForInterService.EDDIfPendingg.ToString());
                oItem.SubItems.Add(oPaidJobForInterService.DeliveryDatee.ToString());
                oItem.SubItems.Add(oPaidJobForInterService.ISCode.ToString());
                oItem.SubItems.Add(oPaidJobForInterService.AssignTo.ToString());
                oItem.SubItems.Add(oPaidJobForInterService.Address);
                oItem.SubItems.Add(oPaidJobForInterService.Location.ToString());
                oItem.SubItems.Add(oPaidJobForInterService.UserName.ToString());
                 if (oPaidJobForInterService.CommunicationStatus == (int)Dictionary.InquiryCommunicationStatus.False)
                {
                    oItem.SubItems.Add("False");
                }
                else if (oPaidJobForInterService.CommunicationStatus == (int)Dictionary.InquiryCommunicationStatus.True)
                {
                    oItem.SubItems.Add("True");
                }
                oItem.SubItems.Add(oPaidJobForInterService.ConvertedJobNo.ToString());
                oItem.SubItems.Add(oPaidJobForInterService.ReceiveRemarks.ToString());
                oItem.SubItems.Add(oPaidJobForInterService.ScheduleRemarks.ToString());
                oItem.SubItems.Add(oPaidJobForInterService.CommuRemarks.ToString());


                oItem.Tag = oPaidJobForInterService;
            }
            setListViewRowColour();
        }

        private void setListViewRowColour()
        {
            if (lvwPaidJobForInterServices.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwPaidJobForInterServices.Items)
                {
                    if (oItem.SubItems[1].Text == Dictionary.ISPaidJobStatus.Assign.ToString())
                    {
                        oItem.BackColor = Color.DarkSeaGreen;
                    }
                    else if (oItem.SubItems[1].Text == Dictionary.ISPaidJobStatus.Cancel.ToString())
                    {
                        oItem.BackColor = Color.DarkGray;
                    }
                    else if (oItem.SubItems[1].Text == Dictionary.ISPaidJobStatus.ConvertToCSDJob.ToString())
                    {
                        oItem.BackColor = Color.LightSkyBlue;
                    }
                    else if (oItem.SubItems[1].Text == Dictionary.ISPaidJobStatus.Pending.ToString())
                    {
                        oItem.BackColor = Color.LightSalmon;
                    }
                    else if (oItem.SubItems[1].Text == Dictionary.ISPaidJobStatus.Receive.ToString())
                    {
                        oItem.BackColor = Color.White;
                    }
                    else if (oItem.SubItems[1].Text == Dictionary.ISPaidJobStatus.ServiceProvided.ToString())
                    {
                        oItem.BackColor = Color.DarkKhaki;
                    }
                    else if (oItem.SubItems[1].Text == Dictionary.ISPaidJobStatus.WorkInProgress.ToString())
                    {
                        oItem.BackColor = Color.LightSteelBlue;
                    }
                    
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmPaidJobForInterService oForm = new frmPaidJobForInterService();
            oForm.ShowDialog();
            DataLoadControl();
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (lvwPaidJobForInterServices.SelectedItems.Count != 0)
            {
                PaidJobForInterService oPaidJobForInterService = (PaidJobForInterService)lvwPaidJobForInterServices.SelectedItems[0].Tag;

                if (oPaidJobForInterService.Status == (int)Dictionary.ISPaidJobStatus.Receive || 
                    oPaidJobForInterService.Status == (int)Dictionary.ISPaidJobStatus.Assign)
                {
                    frmPaidJobForInterServiceAssign oForm = new frmPaidJobForInterServiceAssign();
                    oForm.ShowDialog(oPaidJobForInterService);
                    DataLoadControl();
                }
                else
                {
                    MessageBox.Show("The Status is not eligible to perform the Option", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Refresh();
                }
            }

            else
            {
                MessageBox.Show("Please Select a Row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Refresh();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (lvwPaidJobForInterServices.SelectedItems.Count != 0)
            {
                PaidJobForInterService oPaidJobForInterService = (PaidJobForInterService)lvwPaidJobForInterServices.SelectedItems[0].Tag;
                if (oPaidJobForInterService.Status == (int)Dictionary.ISPaidJobStatus.Assign ||
                    oPaidJobForInterService.Status == (int)Dictionary.ISPaidJobStatus.Cancel ||
                    oPaidJobForInterService.Status == (int)Dictionary.ISPaidJobStatus.Pending ||
                    oPaidJobForInterService.Status == (int)Dictionary.ISPaidJobStatus.Receive||
                    oPaidJobForInterService.Status == (int)Dictionary.ISPaidJobStatus.WorkInProgress)
                {
                    frmPaidJobforInterServiceCancel oForm = new frmPaidJobforInterServiceCancel();
                    oForm.ShowDialog(oPaidJobForInterService);
                    DataLoadControl();
                }
                else
                {
                    MessageBox.Show("The Status is not eligible to perform the Option", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Refresh();
                }
            }

            else
            {
                MessageBox.Show("Please Select a Row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Refresh();
            }

        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DataLoadControl();
            this.Cursor = Cursors.Default;
        }

        private void All_CheckedChanged(object sender, EventArgs e)
        {

            if (All.Checked == true)
            {
                dtFromDate.Enabled = false;
                dtToDate.Enabled = false;
            }
            else
            {
                dtFromDate.Enabled = true;
                dtToDate.Enabled = true;
            }

        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            if (lvwPaidJobForInterServices.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row to View/Print History.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            PaidJobForInterService oPaidJobForInterService = (PaidJobForInterService)lvwPaidJobForInterServices.SelectedItems[0].Tag;

            frmPaidJobForInterServiceHistory oForm = new frmPaidJobForInterServiceHistory();
            oForm.ShowDialog(oPaidJobForInterService);
            DataLoadControl();
        }

        private void btnServiceProvided_Click(object sender, EventArgs e)
        {
            if (lvwPaidJobForInterServices.SelectedItems.Count != 0)
            {
                PaidJobForInterService oPaidJobForInterService = (PaidJobForInterService)lvwPaidJobForInterServices.SelectedItems[0].Tag;

                if (oPaidJobForInterService.Status == (int)Dictionary.ISPaidJobStatus.WorkInProgress ||
                    oPaidJobForInterService.Status == (int)Dictionary.ISPaidJobStatus.Pending ||
                    oPaidJobForInterService.Status == (int)Dictionary.ISPaidJobStatus.Assign ||
                    oPaidJobForInterService.Status == (int)Dictionary.ISPaidJobStatus.ServiceProvided)
                {
                    frmPaidJobForInterServiceProvided oForm = new frmPaidJobForInterServiceProvided();
                    oForm.ShowDialog(oPaidJobForInterService);
                    DataLoadControl();
                }
                else
                {
                    MessageBox.Show("The Status is not eligible to perform the Option", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Refresh();
                }
            }

            else
            {
                MessageBox.Show("Please Select a Row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Refresh();
            }
        }

        private void btnPending_Click(object sender, EventArgs e)
        {
            if (lvwPaidJobForInterServices.SelectedItems.Count != 0)
            {
                PaidJobForInterService oPaidJobForInterService = (PaidJobForInterService)lvwPaidJobForInterServices.SelectedItems[0].Tag;
                if (oPaidJobForInterService.Status == (int)Dictionary.ISPaidJobStatus.WorkInProgress ||
                    oPaidJobForInterService.Status == (int)Dictionary.ISPaidJobStatus.Pending ||
                    oPaidJobForInterService.Status == (int)Dictionary.ISPaidJobStatus.Assign)
                {
                    frmPaidJobForInterServicePending oForm = new frmPaidJobForInterServicePending();
                    oForm.ShowDialog(oPaidJobForInterService);
                    DataLoadControl();
                }
                else
                {
                    MessageBox.Show("The Status is not eligible to perform the Option", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Refresh();
                }
            }

            else
            {
                MessageBox.Show("Please Select a Row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Refresh();
            }

        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            if (lvwPaidJobForInterServices.SelectedItems.Count != 0)
            {
                PaidJobForInterService oPaidJobForInterService = (PaidJobForInterService)lvwPaidJobForInterServices.SelectedItems[0].Tag;
                if (oPaidJobForInterService.Status == (int)Dictionary.ISPaidJobStatus.Assign ||
                    oPaidJobForInterService.Status == (int)Dictionary.ISPaidJobStatus.ConvertToCSDJob ||
                    oPaidJobForInterService.Status == (int)Dictionary.ISPaidJobStatus.Pending ||
                    oPaidJobForInterService.Status == (int)Dictionary.ISPaidJobStatus.Receive ||
                    oPaidJobForInterService.Status == (int)Dictionary.ISPaidJobStatus.WorkInProgress)
                {
                    frmPaidJobForInterServiceConvert oForm = new frmPaidJobForInterServiceConvert();
                    oForm.ShowDialog(oPaidJobForInterService);
                    DataLoadControl();
                }
                else
                {
                    MessageBox.Show("The Status is not eligible to perform the Option", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Refresh();
                }
            }

            else
            {
                MessageBox.Show("Please Select a Row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Refresh();
            }
        }

        private void btnWIP_Click(object sender, EventArgs e)
        {
            if (lvwPaidJobForInterServices.SelectedItems.Count != 0)
            {
                PaidJobForInterService oPaidJobForInterService = (PaidJobForInterService)lvwPaidJobForInterServices.SelectedItems[0].Tag;
                if (oPaidJobForInterService.Status == (int)Dictionary.ISPaidJobStatus.WorkInProgress || 
                    oPaidJobForInterService.Status == (int)Dictionary.ISPaidJobStatus.Pending ||
                    oPaidJobForInterService.Status == (int)Dictionary.ISPaidJobStatus.Assign)
                    
                {
                    frmPaidJobForInterServiceWIP oForm = new frmPaidJobForInterServiceWIP();
                    oForm.ShowDialog(oPaidJobForInterService);
                    DataLoadControl();
                }
                else
                {
                    MessageBox.Show("The Status is not eligible to perform the Option", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Refresh();
                }
            }

            else
            {
                MessageBox.Show("Please Select a Row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Refresh();
            }
        }

        private void btnCommunication_Click(object sender, EventArgs e)
        {
            if (lvwPaidJobForInterServices.SelectedItems.Count != 0)
            {
                PaidJobForInterService oPaidJobForInterService = (PaidJobForInterService)lvwPaidJobForInterServices.SelectedItems[0].Tag;

                if (oPaidJobForInterService.Status == (int)Dictionary.ISPaidJobStatus.Assign)
                {
                    frmPaidJobForInterServiceCommunication oForm = new frmPaidJobForInterServiceCommunication();
                    oForm.ShowDialog(oPaidJobForInterService);
                    DataLoadControl();
                }
                else
                {
                    MessageBox.Show("The Status is not eligible to perform the Option", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Refresh();
                }
            }

            else
            {
                MessageBox.Show("Please Select a Row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Refresh();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwPaidJobForInterServices.SelectedItems.Count != 0)
            {
                PaidJobForInterService oPaidJobForInterService = (PaidJobForInterService)lvwPaidJobForInterServices.SelectedItems[0].Tag;


                frmPaidJobForInterService oForm = new frmPaidJobForInterService();
                oForm.FormBorderStyle = FormBorderStyle.FixedSingle;
                oForm.MaximizeBox = false;
                oForm.Text = "Edit Job";
                oForm.ShowDialog(oPaidJobForInterService);
                DataLoadControl();
          
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }
        }

        private void lvwPaidJobForInterServices_DoubleClick(object sender, EventArgs e)
        {
            if (lvwPaidJobForInterServices.SelectedItems.Count != 0)
            {
                PaidJobForInterService oPaidJobForInterService = (PaidJobForInterService)lvwPaidJobForInterServices.SelectedItems[0].Tag;


                frmPaidJobForInterService oForm = new frmPaidJobForInterService();
                oForm.FormBorderStyle = FormBorderStyle.FixedSingle;
                oForm.MaximizeBox = false;
                oForm.Text = "Edit Job";
                oForm.ShowDialog(oPaidJobForInterService);
                DataLoadControl();

            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }
        }

        private void btnSchedulePrint_Click(object sender, EventArgs e)
        {
            frmPaidJobforInterServiceScheduleView oForm = new frmPaidJobforInterServiceScheduleView();
            oForm.ShowDialog();
        }
                     
    }
}
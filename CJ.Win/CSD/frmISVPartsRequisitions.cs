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
    public partial class frmISVPartsRequisitions : Form
    {
       
        public frmISVPartsRequisitions()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmISVPartsRequisition oForm = new frmISVPartsRequisition();
            oForm.ShowDialog();
            DataLoadControl();
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {

            if (lvwISVPartsRequisition.SelectedItems.Count != 0)
            {
                SparePartsTransaction _oSparePartsTransaction = (SparePartsTransaction)lvwISVPartsRequisition.SelectedItems[0].Tag;
                

                frmISVPartsRequisitionIssue oForm = new frmISVPartsRequisitionIssue();

                oForm.FormBorderStyle = FormBorderStyle.FixedSingle;
                oForm.MaximizeBox = false;
                //oForm.Text = "Parts Issue Requisition";
                oForm.ShowDialog(_oSparePartsTransaction);
                DataLoadControl();

            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }
        }

        private void getStatus()
        {
            //Paid Job Status
         
            cmbStatus.Items.Add("All");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ISVRequisitionStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.ISVRequisitionStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = cmbStatus.Items.Count - 7;

        }

        private void DataLoadControl()
        {
            SparePartsTransactions oSparePartsTransactions = new SparePartsTransactions();



            lvwISVPartsRequisition.Items.Clear();
            DBController.Instance.OpenNewConnection();


            oSparePartsTransactions = new SparePartsTransactions();

            {
                if (All.Checked == false)
                {

                if (ctlInterService1.SelectedInterService != null)
                {
                    oSparePartsTransactions.Refresh(dtFromDate.Value.Date, dtToDate.Value.Date, txtRequisitionID.Text, ctlInterService1.SelectedInterService.InterServiceID, cmbStatus.SelectedIndex - 1, txtSerialNo.Text, txtReportNo.Text, txtContactNo.Text, txtReceiveBy.Text);//
                }
                else
                {
                    oSparePartsTransactions.Refresh(dtFromDate.Value.Date, dtToDate.Value.Date, txtRequisitionID.Text, 0, cmbStatus.SelectedIndex - 1, txtSerialNo.Text, txtReportNo.Text, txtContactNo.Text, txtReceiveBy.Text);//, 
                }
            }
            else
                if (ctlInterService1.SelectedInterService != null)
                {
                    oSparePartsTransactions.RefreshAll(txtRequisitionID.Text, ctlInterService1.SelectedInterService.InterServiceID, cmbStatus.SelectedIndex - 1, txtSerialNo.Text, txtReportNo.Text, txtContactNo.Text, txtReceiveBy.Text);//
                }
                else
                {
                    oSparePartsTransactions.RefreshAll(txtRequisitionID.Text, 0, cmbStatus.SelectedIndex - 1, txtSerialNo.Text, txtReportNo.Text, txtContactNo.Text, txtReceiveBy.Text);//, 
                }

            }
            this.Text = "Total " + "[" + oSparePartsTransactions.Count + "]";

            foreach (SparePartsTransaction oSparePartsTransaction in oSparePartsTransactions)
            {
                ListViewItem oItem = lvwISVPartsRequisition.Items.Add(oSparePartsTransaction.ISVRequisitionID.ToString());
                oItem.SubItems.Add(oSparePartsTransaction.StatusName.ToString());
                oItem.SubItems.Add(oSparePartsTransaction.CreateDate.ToString());
                oItem.SubItems.Add(oSparePartsTransaction.InterService.Code.ToString());
                oItem.SubItems.Add(oSparePartsTransaction.InterService.Name.ToString());
                oItem.SubItems.Add(oSparePartsTransaction.InterService.Mobile.ToString());
                oItem.SubItems.Add(oSparePartsTransaction.ReportNo.ToString());
                oItem.SubItems.Add(oSparePartsTransaction.SerialNo.ToString());
                oItem.SubItems.Add(oSparePartsTransaction.PrepareDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oSparePartsTransaction.User.Username.ToString());

                oItem.Tag = oSparePartsTransaction;
            }
            setListViewRowColour();
        }

        private void setListViewRowColour()
        {
            if (lvwISVPartsRequisition.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwISVPartsRequisition.Items)
                {
                    if (oItem.SubItems[1].Text == Dictionary.ISVRequisitionStatus.Cancel.ToString())
                    {
                        oItem.BackColor = Color.DarkGray;
                    }
                    else if (oItem.SubItems[1].Text == Dictionary.ISVRequisitionStatus.Full_Issue.ToString())
                    {
                        oItem.BackColor = Color.DarkSeaGreen;
                    }
                    else if (oItem.SubItems[1].Text == Dictionary.ISVRequisitionStatus.Partial_Issue.ToString())
                    {
                        oItem.BackColor = Color.Plum;
                    }
                    else if (oItem.SubItems[1].Text == Dictionary.ISVRequisitionStatus.Receive.ToString())
                    {
                        oItem.BackColor = Color.White;
                    }
                    else if (oItem.SubItems[1].Text == Dictionary.ISVRequisitionStatus.Suspend.ToString())
                    {
                        oItem.BackColor = Color.LightSalmon;
                    }
                    else if (oItem.SubItems[1].Text == Dictionary.ISVRequisitionStatus.Pending.ToString())
                    {
                        oItem.BackColor = Color.IndianRed;
                    }
                }
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DataLoadControl();
            this.Cursor = Cursors.Default;
        }

        private void lvwISVPartsRequisition_DoubleClick(object sender, EventArgs e)
        {
            if (lvwISVPartsRequisition.SelectedItems.Count != 0)
            {
                if (btnEdit.Enabled == true)
                {
                    SparePartsTransaction oSparePartsTransaction = (SparePartsTransaction)lvwISVPartsRequisition.SelectedItems[0].Tag;


                    frmISVPartsRequisition oForm = new frmISVPartsRequisition();

                    oForm.FormBorderStyle = FormBorderStyle.FixedSingle;
                    oForm.MaximizeBox = false;
                    oForm.Text = "Edit Requisition";
                    oForm.ShowDialog(oSparePartsTransaction);
                    DataLoadControl();
                }
                else
                {
                    MessageBox.Show("You have no permission to edit requisition", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }
        }

        private void frmISVPartsRequisitions_Load(object sender, EventArgs e)
        {
            DataLoadControl();
            getStatus();
            updateSecurity();
        }
        private void updateSecurity()
        {
            Users oUsers = new Users();
            Permission oPermission = new Permission();
            DSPermission _oDsPermission = oPermission.getPermissionList();

            DataRow[] oPermitedRow = _oDsPermission.Permission.Select("MenuType >= '" + (short)Dictionary.MenuType.Buttton + "'");
            foreach (DataRow oRow in oPermitedRow)
            {
                string sPermissionKey = oUsers.checkOtherPermission(oRow["PermissionKey"].ToString(), Utility.UserId);
                if (sPermissionKey != null)
                {
                    if ("M34.11.1" == sPermissionKey)
                    {
                        btnNew.Enabled = true;
                    }
                    if ("M34.11.2" == sPermissionKey)
                    {
                        btnIssue.Enabled = true;
                    }
                    if ("M34.11.3" == sPermissionKey)
                    {
                        btnCommunication.Enabled = true;
                    }
                    if ("M34.11.4" == sPermissionKey)
                    {
                        btnDelivery.Enabled = true;
                    }
                    if ("M34.11.5" == sPermissionKey)
                    {
                        btnEdit.Enabled = true;
                    }
                    if ("M34.11.6" == sPermissionKey)
                    {
                        btnCancel.Enabled = true;
                    }
                    if ("M34.11.7" == sPermissionKey)
                    {
                        btnHistory.Enabled = true;
                    }

                }
            }

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

        private void btnDelivery_Click(object sender, EventArgs e)
        {

            if (lvwISVPartsRequisition.SelectedItems.Count != 0)
            {
                SparePartsTransaction oSparePartsTransaction = (SparePartsTransaction)lvwISVPartsRequisition.SelectedItems[0].Tag;

                if (oSparePartsTransaction.StatusCode == (int)Dictionary.ISVRequisitionStatus.Full_Issue ||
                    oSparePartsTransaction.StatusCode == (int)Dictionary.ISVRequisitionStatus.Partial_Issue)
                    //oSparePartsTransaction.Status != (int)Dictionary.ISVRequisitionStatus.Cancel)
                    
                {
                    frmISVPartsRequisitionSend oForm = new frmISVPartsRequisitionSend();
                    oForm.ShowDialog(oSparePartsTransaction);
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

            if (lvwISVPartsRequisition.SelectedItems.Count != 0)
            {
                SparePartsTransaction oSparePartsTransaction = (SparePartsTransaction)lvwISVPartsRequisition.SelectedItems[0].Tag;

                if (oSparePartsTransaction.StatusCode == (int)Dictionary.ISVRequisitionStatus.Pending ||
                    oSparePartsTransaction.StatusCode == (int)Dictionary.ISVRequisitionStatus.Receive ||
                    oSparePartsTransaction.StatusCode == (int)Dictionary.ISVRequisitionStatus.Suspend)
                {

                    frmISVPartsRequisitionCancel oForm = new frmISVPartsRequisitionCancel();
                    oForm.ShowDialog(oSparePartsTransaction);
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
            frmISVPartsRequisitionCommunication oForm = new frmISVPartsRequisitionCommunication();
            oForm.ShowDialog();
            oForm.Refresh();
            oForm.DataLoadControl();
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            if (lvwISVPartsRequisition.SelectedItems.Count != 0)
            {
                SparePartsTransaction oSparePartsTransaction = (SparePartsTransaction)lvwISVPartsRequisition.SelectedItems[0].Tag;


                    frmISVPartsRequisitionHistory oForm = new frmISVPartsRequisitionHistory();
                    oForm.ShowDialog(oSparePartsTransaction);
                    DataLoadControl();
               
            }

            else
            {
                MessageBox.Show("Please Select a Row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Refresh();
            }
        }

        private void btnProactive_Click(object sender, EventArgs e)
        {
            frmISVPartsRequisitionProActive oForm = new frmISVPartsRequisitionProActive();
            oForm.ShowDialog();
            oForm.Refresh();
            //oForm.DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwISVPartsRequisition.SelectedItems.Count != 0)
            {
                SparePartsTransaction oSparePartsTransaction = (SparePartsTransaction)lvwISVPartsRequisition.SelectedItems[0].Tag;


                frmISVPartsRequisition oForm = new frmISVPartsRequisition();

                oForm.FormBorderStyle = FormBorderStyle.FixedSingle;
                oForm.MaximizeBox = false;
                oForm.Text = "Edit Requisition";
                oForm.ShowDialog(oSparePartsTransaction);
                DataLoadControl();

            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }

        }
    }
}
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
    public partial class frmComplains : Form
    {

        private int _nComplainStatus;
        Utilities _oUtilitys;
        Complains _oComplains;
        TELLib oTELLib;

        public frmComplains()
        {
            InitializeComponent();
        }

        private void LoadCombos()
        {
            // Source
            cmbComplainSource.Items.Add("All");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ComplainerType)))
            {
                cmbComplainSource.Items.Add(Enum.GetName(typeof(Dictionary.ComplainerType), GetEnum));
            }
            cmbComplainSource.SelectedIndex = 0;

        }

        private void frmComplain_Load(object sender, EventArgs e)
        {
            updateSecurity();
            getComplainStatus();
            LoadCombos();
            DataLoadControl();
            DataLoadControlProActive();
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
                    if ("M34.2.1" == sPermissionKey)
                    {
                        btnNew.Enabled = true;
                    }
                    if ("M34.2.2" == sPermissionKey)
                    {
                        btnEdit.Enabled = true;
                    }
                    if ("M34.2.3" == sPermissionKey)
                    {
                        btnAssign.Enabled = true;
                    }
                    if ("M34.2.4" == sPermissionKey)
                    {
                        btnAction.Enabled = true;
                    }
                    if ("M34.2.5" == sPermissionKey)
                    {
                        btnHappyCall.Enabled = true;
                    }
                    if ("M34.2.6" == sPermissionKey)
                    {
                        btnCancel.Enabled = true;
                    }
                    if ("M34.2.7" == sPermissionKey)
                    {
                        btnPrintComplain.Enabled = true;
                    }

                }
            }

        }

        private void DataLoadControl()
        {
            //Utility oUtility = _oUtilitys[cmbComplainStatus.SelectedIndex];
            //_nComplainStatus = oUtility.SatusId;

            Complains oComplains = new Complains();

            lvwComplains.Items.Clear();
            DBController.Instance.OpenNewConnection();
            {
                if (All.Checked == false)
                {
                    oComplains.Refresh(dtFromDate.Value.Date, dtToDate.Value.Date, txtComplainerName.Text, txtContactNo.Text, txtComplainNo.Text, _oUtilitys[cmbComplainStatus.SelectedIndex].SatusId, txtAssignto.Text, txtRefJob.Text, txtReceiveBy.Text, cmbComplainSource.SelectedIndex-1);//
                }
                else
                {
                    oComplains.RefreshAll(txtComplainerName.Text, txtContactNo.Text, txtComplainNo.Text, _oUtilitys[cmbComplainStatus.SelectedIndex].SatusId, txtAssignto.Text, txtRefJob.Text, txtReceiveBy.Text, cmbComplainSource.SelectedIndex - 1);

                }
            }

            //oServiceJobs.btnShow(txtJobNo.Text);
            this.Text = "ComplainID " + "[" + oComplains.Count + "]";
            foreach (Complain oComplain in oComplains)
            {
                ListViewItem oItem = lvwComplains.Items.Add(oComplain.ComplainID.ToString());
                oItem.SubItems.Add(oComplain.CreateDate.ToString());
                oItem.SubItems.Add(oComplain.Complainer);
                oItem.SubItems.Add(oComplain.ContactNo);
                oItem.SubItems.Add(oComplain.ReferanceJobNo.ToString());
                oItem.SubItems.Add(oComplain.ComplainDetails);
                //oItem.SubItems.Add(oComplain.ComplainAgainstWhom);
                //oItem.SubItems.Add(oComplain.AssignEmployeeID);


                if (oComplain.ComplainStatus == (int)Dictionary.ComplainStatus.Receive)
                {
                    oItem.SubItems.Add("Receive");
                }
                else if (oComplain.ComplainStatus == (int)Dictionary.ComplainStatus.Assign)
                {
                    oItem.SubItems.Add("Assign");
                }
                else if (oComplain.ComplainStatus == (int)Dictionary.ComplainStatus.Solved)
                {
                    oItem.SubItems.Add("Solved");
                }
                else if (oComplain.ComplainStatus == (int)Dictionary.ComplainStatus.UnderProcess)
                {
                    oItem.SubItems.Add("UnderProcess");
                }
                else if (oComplain.ComplainStatus == (int)Dictionary.ComplainStatus.MgtActionReq)
                {
                    oItem.SubItems.Add("MgtActionReq");
                }
                else if (oComplain.ComplainStatus == (int)Dictionary.ComplainStatus.HappyCall)
                {
                    oItem.SubItems.Add("HappyCall");
                }
                else
                {
                    oItem.SubItems.Add("Cancel");
                }
                if (oComplain.AssignEmployeeID > 0)
                    oItem.SubItems.Add(oComplain.Employee.EmployeeName.ToString());
                else oItem.SubItems.Add("Not Assign");

                if (oComplain.FurtherActionReqID == (int)Dictionary.ComplainFurtherActionRequired.True)
                {
                    oItem.SubItems.Add("True");
                }
                if (oComplain.FurtherActionReqID == (int)Dictionary.ComplainFurtherActionRequired.False)
                {
                    oItem.SubItems.Add("False");
                }
                oItem.SubItems.Add(oComplain.User.Username.ToString());

                oItem.Tag = oComplain;
            }
            setListViewRowColour();
        }

        private void DataLoadControlProActive()
        {
            //Utility oUtility = _oUtilitys[cmbComplainStatus.SelectedIndex];
            //_nComplainStatus = oUtility.SatusId;

            Complains oComplains = new Complains();

            lvwProActiveList.Items.Clear();
            DBController.Instance.OpenNewConnection();
            //oComplains.Refresh(dtFromDate.Value.Date, dtToDate.Value.Date, txtComplainerName.Text, txtContactNo.Text, txtComplainNo.Text, _oUtilitys[cmbComplainStatus.SelectedIndex].SatusId, txtAssignto.Text.Trim());//
            oComplains.RefreshProactive();
            //oServiceJobs.btnShow(txtJobNo.Text);
            //this.Text = "ComplainID " + "[" + oComplains.Count + "]";
            foreach (Complain oComplain in oComplains)
            {
                ListViewItem oItem = lvwProActiveList.Items.Add(oComplain.ComplainID.ToString());
                oItem.SubItems.Add(oComplain.Employee.EmployeeName.ToString());

                oItem.Tag = oComplain;
            }
        }

        private void getComplainStatus()
        {
            _oUtilitys = new Utilities();
            cmbComplainStatus.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oUtilitys.GetComplainStatus();
            foreach (Utility oUtility in _oUtilitys)
            {
                cmbComplainStatus.Items.Add(oUtility.Satus);
            }
            cmbComplainStatus.SelectedIndex = cmbComplainStatus.Items.Count - 1;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmComplain oForm = new frmComplain();
            oForm.ShowDialog();
            DataLoadControl();
        }

        private void btnAssign_Click(object sender, EventArgs e)
        {
            if (lvwComplains.SelectedItems.Count != 0)
            {
                Complain oComplain = (Complain)lvwComplains.SelectedItems[0].Tag;

                if (oComplain.ComplainStatus != (int)Dictionary.ComplainStatus.Solved)
                {
                    if (oComplain.ComplainStatus != (int)Dictionary.ComplainStatus.UnderProcess)
                    {
                        if (oComplain.ComplainStatus != (int)Dictionary.ComplainStatus.MgtActionReq)
                        {
                            if (oComplain.ComplainStatus != (int)Dictionary.ComplainStatus.HappyCall)
                            {
                                if (oComplain.ComplainStatus != (int)Dictionary.ComplainStatus.Cancel)
                                {
                                    frmComplainAssign oForm = new frmComplainAssign();
                                    oForm.ShowDialog(oComplain);
                                    DataLoadControl();
                                }
                                else
                                {
                                    MessageBox.Show("Sorry, The Option is not Eligible for the Status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    this.Refresh();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Sorry, The Option is not Eligible for the Status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Refresh();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Sorry, The Option is not Eligible for the Status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Refresh();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sorry, The Option is not Eligible for the Status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Refresh();
                    }
                }
                else
                {
                    MessageBox.Show("Sorry, The Option is not Eligible for the Status", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            if (lvwComplains.SelectedItems.Count != 0)
            {
                Complain oComplain = (Complain)lvwComplains.SelectedItems[0].Tag;

                if (oComplain.ComplainStatus != (int)Dictionary.ComplainStatus.Receive)
                {
                    if (oComplain.ComplainStatus != (int)Dictionary.ComplainStatus.HappyCall)
                    {
                        if (oComplain.ComplainStatus != (int)Dictionary.ComplainStatus.Cancel)
                        {
                            frmComplainAction oForm = new frmComplainAction();
                            oForm.ShowDialog(oComplain);
                            DataLoadControl();
                            DataLoadControlProActive();
                        }
                        else
                        {
                            MessageBox.Show("Please Assing First & then make the Action", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Refresh();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Assing First & then make the Action", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Refresh();
                    }
                }
                else
                {
                    MessageBox.Show("PleaseAssing First & then make the Action", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }
        }

        //private void btnClear_Click(object sender, EventArgs e)
        //{
        //    txtAssignto.Text = "";
        //    txtComplainerName.Text = "";
        //    txtComplainNo.Text = "";
        //    txtContactNo.Text = "";
        //    txtAssignto.Text = "";
        //    //cmbActionStatus.SelectedIndex = "All";
        //    //cmbComplainStatus.SelectedIndex = (int)Dictionary.ComplainStatus.All;
        //    dtFromDate.Value = DateTime.Today;
        //    DataLoadControl();
        //}

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwComplains.SelectedItems.Count != 0)
            {
                Complain oComplain = (Complain)lvwComplains.SelectedItems[0].Tag;

                //if (oComplain.ComplainStatus != (int)Dictionary.ComplainStatus.Cancel)
                //{
                //    if (oComplain.ComplainStatus != (int)Dictionary.ComplainStatus.HappyCall)
                //    {
                //        if (oComplain.ComplainStatus != (int)Dictionary.ComplainStatus.Action)
                //        {
                frmComplain oForm = new frmComplain();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.Text = "Edit Complain";
                oForm.ShowDialog(oComplain);
                DataLoadControl();
                //            }
                //            else
                //            {
                //                MessageBox.Show("Sorry, This Job is not eligible for Edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //                this.Refresh();
                //            }
                //        }
                //        else
                //        {
                //            MessageBox.Show("Sorry, This Job is not eligible for Edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //            this.Refresh();
                //        }
                //    }
                //    else
                //    {
                //        MessageBox.Show("Sorry, This Job is not eligible for Edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        this.Refresh();
                //    }
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }

        }

        private void lvwComplains_DoubleClick(object sender, EventArgs e)
        {
            if (lvwComplains.SelectedItems.Count != 0)
            {
                Complain oComplain = (Complain)lvwComplains.SelectedItems[0].Tag;

                if (oComplain.ComplainStatus != (int)Dictionary.ComplainStatus.Cancel)
                {
                    if (oComplain.ComplainStatus != (int)Dictionary.ComplainStatus.HappyCall)
                    {
                        if (oComplain.ComplainStatus != (int)Dictionary.ComplainStatus.Solved)
                        {
                            if (oComplain.ComplainStatus != (int)Dictionary.ComplainStatus.UnderProcess)
                            {
                                if (oComplain.ComplainStatus != (int)Dictionary.ComplainStatus.MgtActionReq)
                                {
                                    frmComplain oForm = new frmComplain();
                                    oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                                    oForm.MaximizeBox = false;
                                    oForm.Text = "Edit Complain";
                                    oForm.ShowDialog(oComplain);
                                    DataLoadControl();
                                }
                                else
                                {
                                    MessageBox.Show("Sorry, This Job is not eligible for Edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    this.Refresh();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Sorry, This Job is not eligible for Edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Refresh();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Sorry, This Job is not eligible for Edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Refresh();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sorry, This Job is not eligible for Edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Refresh();
                    }
                }
                else
                {
                    MessageBox.Show("Sorry, This Job is not eligible for Edit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }

        }

        private void setListViewRowColour()
        {
            if (lvwComplains.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwComplains.Items)
                {
                    if (oItem.SubItems[6].Text == Dictionary.ComplainStatus.Receive.ToString())
                    {
                        oItem.BackColor = Color.Red;
                    }
                    else if (oItem.SubItems[6].Text == Dictionary.ComplainStatus.Assign.ToString())
                    {
                        oItem.BackColor = Color.LightSalmon;
                    }
                    else if (oItem.SubItems[6].Text == Dictionary.ComplainStatus.Solved.ToString())
                    {
                        oItem.BackColor = Color.Plum;
                    }
                    else if (oItem.SubItems[6].Text == Dictionary.ComplainStatus.UnderProcess.ToString())
                    {
                        oItem.BackColor = Color.SteelBlue;
                    }
                    else if (oItem.SubItems[6].Text == Dictionary.ComplainStatus.MgtActionReq.ToString())
                    {
                        oItem.BackColor = Color.PowderBlue;
                    }
                    else if (oItem.SubItems[6].Text == Dictionary.ComplainStatus.HappyCall.ToString())
                    {
                        oItem.BackColor = Color.DarkSeaGreen;
                    }
                    else
                    {
                        oItem.BackColor = Color.DarkGray;

                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwComplains.SelectedItems.Count != 0)
            {
                Complain oComplain = (Complain)lvwComplains.SelectedItems[0].Tag;
                //if (oComplain.ComplainStatus != (int)Dictionary.ComplainStatus.Cancel)
                DialogResult oResult = MessageBox.Show("Are you sure You want to delete the Complain: " + oComplain.ComplainID + " ? ", "Confirm Complain Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oResult == DialogResult.Yes)
                //if (MessageBox.Show("Do you want to Delete Complain?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        oComplain.Delete();
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show(" Successfully Delete The Complain No : " + oComplain.ComplainID, "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataLoadControl();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                    //DataLoadControl();
                }
                else
                {
                    DataLoadControl();
                    //MessageBox.Show("Please Change Status as CANCELED and Then Delete it.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                }
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }

        }

        private void btnHappyCall_Click(object sender, EventArgs e)
        {
            if (lvwComplains.SelectedItems.Count != 0)
            {
                Complain oComplain = (Complain)lvwComplains.SelectedItems[0].Tag;

                if (oComplain.ComplainStatus != (int)Dictionary.ComplainStatus.Receive)
                {
                    if (oComplain.ComplainStatus != (int)Dictionary.ComplainStatus.Cancel)
                    {
                        if (oComplain.ComplainStatus != (int)Dictionary.ComplainStatus.MgtActionReq)
                        {
                            if (oComplain.ComplainStatus != (int)Dictionary.ComplainStatus.UnderProcess)
                            {
                                if (oComplain.ComplainStatus != (int)Dictionary.ComplainStatus.Assign)
                                {
                                    frmComplainHappyCall oForm = new frmComplainHappyCall();
                                    oForm.ShowDialog(oComplain);
                                    DataLoadControl();
                                }
                                else
                                {
                                    MessageBox.Show("Only Solve Complain Should make Happy Call", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    this.Refresh();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Only Solve Complain Should make Happy Call", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                this.Refresh();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Only Solve Complain Should make Happy Call", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.Refresh();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Only Solve Complain Should make Happy Call", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Refresh();
                    }
                }
                else
                {
                    MessageBox.Show("Only Solve Complain Should make Happy Call", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Refresh();
                }
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (lvwComplains.SelectedItems.Count != 0)
            {
                Complain oComplain = (Complain)lvwComplains.SelectedItems[0].Tag;

                if (oComplain.ComplainStatus != (int)Dictionary.ComplainStatus.HappyCall)
                {
                    if (oComplain.ComplainStatus != (int)Dictionary.ComplainStatus.Solved)
                    {
                        if (oComplain.ComplainStatus != (int)Dictionary.ComplainStatus.UnderProcess)
                        {
                            if (oComplain.ComplainStatus != (int)Dictionary.ComplainStatus.MgtActionReq)
                            {
                                if (oComplain.ComplainStatus != (int)Dictionary.ComplainStatus.Cancel)
                                {

                                    DialogResult oResult = MessageBox.Show("Are you sure You want to Cancel the Complain: " + oComplain.ComplainID + " ? ", "Confirm Complain Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (oResult == DialogResult.Yes)
                                    {
                                        try
                                        {
                                            DBController.Instance.BeginNewTransaction();
                                            oComplain.CancelComplain();
                                            DBController.Instance.CommitTransaction();
                                            MessageBox.Show(" Successfully Cancel The Complain No : " + oComplain.ComplainID, "Cancel", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            DataLoadControl();
                                        }
                                        catch (Exception ex)
                                        {
                                            DBController.Instance.RollbackTransaction();
                                            MessageBox.Show(ex.Message, "Error!!!");
                                        }
                                        this.Refresh();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Sorry, you can not Cancel the Complain", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        this.Refresh();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Sorry, you can not Cancel the Complain", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    this.Refresh();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Sorry, you can not Cancel the Complain", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                this.Refresh();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Sorry, you can not Cancel the Complain", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            this.Refresh();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sorry, you can not Cancel the Complain", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        this.Refresh();
                    }
                }

                else
                {
                    MessageBox.Show("Please Select a Row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.Refresh();
                }

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DataLoadControl();
            DataLoadControlProActive();
            this.Cursor = Cursors.Default;
        }

        //private void lvwProActiveList_DoubleClick(object sender, EventArgs e)
        //{
        //    //if (lvwProActiveList.SelectedItems.Count != 0)
        //    //{
        //    Complain oComplain = (Complain)lvwProActiveList.SelectedItems[0].Tag;
        //    {
        //        frmComplain oForm = new frmComplain();
        //        oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
        //        oForm.MaximizeBox = false;
        //        oForm.Text = "Edit Complain";
        //        oForm.ShowDialog(oComplain);
        //        DataLoadControl();
        //        DataLoadControlProActive();
        //        this.Refresh();
        //    }
        //    //}
        //    //else
        //    //{
        //    //    MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    //    this.Refresh();
        //    //}
        //}

        //private void dtFromDate_ValueChanged(object sender, EventArgs e)
        //{      
        //    if (dtFromDate.Value > dtToDate.Value)

        //     MessageBox.Show("From Date must be equal or less then To Date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //     //dtFromDate.Value = DateTime.Today;
        //    DataLoadControl();

        //}

        //private void dtToDate_ValueChanged(object sender, EventArgs e)
        //{
        //    if (dtToDate.Value < dtFromDate.Value)

        //        MessageBox.Show("From Date must be equal or less then To Date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //    //dtFromDate.Value = DateTime.Today;
        //    if (dtToDate.Value > dtFromDate.Value)

        //        MessageBox.Show("From Date must be equal or less then To Date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        //    DataLoadControl();
        //}

        //private void txtComplainerName_TextChanged(object sender, EventArgs e)
        //{
        //    DataLoadControl();
        //}

        //private void txtComplainNo_TextChanged(object sender, EventArgs e)
        //{
        //    DataLoadControl();
        //}

        //private void txtContactNo_TextChanged(object sender, EventArgs e)
        //{
        //    DataLoadControl();
        //}

        //private void cmbComplainStatus_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    DataLoadControl();
        //}

        //private void txtAssignto_TextChanged(object sender, EventArgs e)
        //{
        //    DataLoadControl();
        //}

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

        private void btnPrintComplain_Click(object sender, EventArgs e)
        {
            if (lvwComplains.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Complain to print.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            Complain oComplain = (Complain)lvwComplains.SelectedItems[0].Tag;


            rptComplainDetail oReport = new rptComplainDetail();

            oReport.SetParameterValue("ComplainNo", oComplain.ComplainID);
            oReport.SetParameterValue("Name", oComplain.Complainer);
            oReport.SetParameterValue("ContactNo", oComplain.ContactNo);
            oReport.SetParameterValue("ComDetl", oComplain.ComplainDetails);
            oReport.SetParameterValue("JobNo", oComplain.ReferanceJobNo.ToString());
            oReport.SetParameterValue("OccurredDate", oComplain.DateOccurred.ToString());
            oReport.SetParameterValue("Action", oComplain.ActionDetails.ToString());
            oReport.SetParameterValue("AD", oComplain.ActionDate.ToString());
            oReport.SetParameterValue("CRD", oComplain.CreateDate.ToString());
            oReport.SetParameterValue("CReceive", oComplain.User.Username);
            oReport.SetParameterValue("Assig", oComplain.Employee.EmployeeName.ToString());
            oReport.SetParameterValue("HCUser", oComplain.HappyCallUserName.ToString());
            oReport.SetParameterValue("HCallDetail", oComplain.HappyCallDetails.ToString());
            oReport.SetParameterValue("HCallDate", oComplain.HappyCallDate);
            oReport.SetParameterValue("AgainstWhom", oComplain.ComplainAgainstWhom);
            oReport.SetParameterValue("AssignDa", oComplain.AssignDate.ToString());
            oReport.SetParameterValue("AssignEnDa", oComplain.UpdateDate.ToString());
            oReport.SetParameterValue("PrintUserName", Utility.Username.ToString());
            oReport.SetParameterValue("ActionStat", oComplain.StatusName.ToString());

             if (oComplain.Quality == 1)
            {
                oReport.SetParameterValue("IsCat", true);
            }
            else oReport.SetParameterValue("IsCat", false);

            if (oComplain.Dealings == 1)
            {
                oReport.SetParameterValue("IsCatDel", true);
            }
            else oReport.SetParameterValue("IsCatDel", false);

            if (oComplain.Performance == 1)
            {
                oReport.SetParameterValue("IsCatPer", true);
            }
            else oReport.SetParameterValue("IsCatPer", false);

            if (oComplain.Price == 1)
            {
                oReport.SetParameterValue("IsCatPrice", true);
            }
            else oReport.SetParameterValue("IsCatPrice", false);

            if (oComplain.Commitment == 1)
            {
                oReport.SetParameterValue("IsCatCom", true);
            }
            else oReport.SetParameterValue("IsCatCom", false);

            if (oComplain.Skill == 1)
            {
                oReport.SetParameterValue("IsCatSki", true);
            }
            else oReport.SetParameterValue("IsCatSki", false);

            if (oComplain.Bill == 1)
            {
                oReport.SetParameterValue("IsCatBill", true);
            }
            else oReport.SetParameterValue("IsCatBill", false);

            if (oComplain.ComplainCatID == 1)
            {
                oReport.SetParameterValue("IsComCat", true);
            }
            else oReport.SetParameterValue("IsComCat", false);
            //////////////////////////////////////////////
            if (oComplain.ComplainCatID == 1&& oComplain.Dealing==1)
            {
                oReport.SetParameterValue("IsDeali", true);
            }
            else oReport.SetParameterValue("IsDeali", false);

            if (oComplain.ComplainCatID == 1 && oComplain.HomeDelivery == 1)
            {
                oReport.SetParameterValue("IsHDeli", true);
            }
            else oReport.SetParameterValue("IsHDeli", false);

            if (oComplain.ComplainCatID == 1 && oComplain.DemoInstall == 1)
            {
                oReport.SetParameterValue("IsDemo", true);
            }
            else oReport.SetParameterValue("IsDemo", false);

            if (oComplain.ComplainCatID == 1 && oComplain.Product == 1)
            {
                oReport.SetParameterValue("IsPro", true);
            }
            else oReport.SetParameterValue("IsPro", false);
            ///////////////////////////////////////////////////
            if (oComplain.ComplainCatID == 2 && oComplain.HomeCall == 1)
            {
                oReport.SetParameterValue("IsHCall", true);
            }
            else oReport.SetParameterValue("IsHCall", false);

            if (oComplain.ComplainCatID == 2 && oComplain.WalkIn == 1)
            {
                oReport.SetParameterValue("IsWIn", true);
            }
            else oReport.SetParameterValue("IsWIn", false);

            if (oComplain.ComplainCatID == 2 && oComplain.Installation == 1)
            {
                oReport.SetParameterValue("IsIns", true);
            }
            else oReport.SetParameterValue("IsIns", false);

            if (oComplain.ComplainCatID == 2 && oComplain.Others == 1)
            {
                oReport.SetParameterValue("IsOth", true);
            }
            else oReport.SetParameterValue("IsOth", false);

            //if (orptSalesInvoice.Flag == true)
            //    if(
            //    doc.SetParameterValue("IsVisible", true);
            //else doc.SetParameterValue("IsVisible", false);
            
         
            //oReport.SetParameterValue("IW", oTELLib.TakaWords(oComplain.ComplainID));

            //if (oComplain.ComplainCatID == (int)Dictionary.ComplainCetagory.BeforeSale)
            //{
            //    oReport.SetParameterValue("ComDetl", Enabled, false);
                
            //}
            //else oReport.SetParameterValue("ComDetl", Enabled, true);

            //------------------------------Salar Command Onek Jhamela Korese -----------------------------
            if (oComplain.ComplainStatus == (int)Dictionary.ComplainStatus.Receive)
            {
                oReport.SetParameterValue("Stat", "Receive");
            }
            if (oComplain.ComplainStatus == (int)Dictionary.ComplainStatus.Assign)
            {
                oReport.SetParameterValue("Stat", "Assign");
            }
            if (oComplain.ComplainStatus == (int)Dictionary.ComplainStatus.Solved)
            {
                oReport.SetParameterValue("Stat", "Solved");
            }
            if (oComplain.ComplainStatus == (int)Dictionary.ComplainStatus.UnderProcess)
            {
                oReport.SetParameterValue("Stat", "UnderProcess");
            }
            if (oComplain.ComplainStatus == (int)Dictionary.ComplainStatus.MgtActionReq)
            {
                oReport.SetParameterValue("Stat", "MgtActionReq");
            }
            if (oComplain.ComplainStatus == (int)Dictionary.ComplainStatus.HappyCall)
            {
                oReport.SetParameterValue("Stat", "HappyCall");
            }
            if (oComplain.ComplainStatus == (int)Dictionary.ComplainStatus.Cancel)
            {
                oReport.SetParameterValue("Stat", "Cancel");
            }
            //-----------------------------------------------------------

            if (oComplain.ComplainerTypeID == (int)Dictionary.ComplainerType.Customer)
            {
                oReport.SetParameterValue("RSource", "Customer");
            }
            if (oComplain.ComplainerTypeID == (int)Dictionary.ComplainerType.CustomerReference)
            {
                oReport.SetParameterValue("RSource", "CustomerReference");
            }
            if (oComplain.ComplainerTypeID == (int)Dictionary.ComplainerType.Dealer)
            {
                oReport.SetParameterValue("RSource", "Dealer");
            }
            if (oComplain.ComplainerTypeID == (int)Dictionary.ComplainerType.TranscomDigital)
            {
                oReport.SetParameterValue("RSource", "TranscomDigital");
            }
            //-----------------------------------------------------------
            if (oComplain.SourceID == (int)Dictionary.Source.DuringHappyCall)
            {
                oReport.SetParameterValue("RType", "DuringHappyCall");
            }
            if (oComplain.SourceID == (int)Dictionary.Source.DuringInBoundCall)
            {
                oReport.SetParameterValue("RType", "DuringInBoundCall");
            }
            if (oComplain.SourceID == (int)Dictionary.Source.DuringOutBoundCall)
            {
                oReport.SetParameterValue("RType", "DuringOutBoundCall");
            }
            //-----------------------------------------------------------
            if (oComplain.ComplainAgainstID == (int)Dictionary.AgainstWhom.CallCenterAgent)
            {
                oReport.SetParameterValue("RAgainstWhom", "CallCenterAgent");
            }
            if (oComplain.ComplainAgainstID == (int)Dictionary.AgainstWhom.FrontDeskAgent)
            {
                oReport.SetParameterValue("RAgainstWhom", "FrontDeskAgent");
            }
            if (oComplain.ComplainAgainstID == (int)Dictionary.AgainstWhom.InterService)
            {
                oReport.SetParameterValue("RAgainstWhom", "InterService");
            }
            if (oComplain.ComplainAgainstID == (int)Dictionary.AgainstWhom.Management)
            {
                oReport.SetParameterValue("RAgainstWhom", "Management");
            }
            if (oComplain.ComplainAgainstID == (int)Dictionary.AgainstWhom.Sales_Personnel)
            {
                oReport.SetParameterValue("RAgainstWhom", "Sales_Personnel");
            }
            if (oComplain.ComplainAgainstID == (int)Dictionary.AgainstWhom.ServiceExecutive_TD)
            {
                oReport.SetParameterValue("RAgainstWhom", "ServiceExecutive_TD");
            }
            if (oComplain.ComplainAgainstID == (int)Dictionary.AgainstWhom.Technician)
            {
                oReport.SetParameterValue("RAgainstWhom", "Technician");
            }
            if (oComplain.ComplainAgainstID == (int)Dictionary.AgainstWhom.ZonalSupervisor)
            {
                oReport.SetParameterValue("RAgainstWhom", "ZonalSupervisor");
            }
            //-----------------------------------------------------------
            if (oComplain.ComplainCatID == (int)Dictionary.ComplainCetagory.AfterSale)
            {
                oReport.SetParameterValue("RComCat", "AfterSale");
            }
            if (oComplain.ComplainCatID == (int)Dictionary.ComplainCetagory.BeforeSale)
            {
                oReport.SetParameterValue("RComCat", "BeforeSale");
            }
            //-----------------------------------------------------------
            if (oComplain.FurtherActionReqID == (int)Dictionary.ComplainFurtherActionRequired.False)
            {
                oReport.SetParameterValue("RRepeated", "False");
            }
            if (oComplain.FurtherActionReqID == (int)Dictionary.ComplainFurtherActionRequired.True)
            {
                oReport.SetParameterValue("RRepeated", "True");
            }
            //-----------------------------------------------------------
            if (oComplain.HappyCallStatusID == (int)Dictionary.ComplainHappyCall.Dissatisfy)
            {
                oReport.SetParameterValue("RHappyStat", "Dissatisfy");
            }
            if (oComplain.HappyCallStatusID == (int)Dictionary.ComplainHappyCall.Moderate)
            {
                oReport.SetParameterValue("RHappyStat", "Moderate");
            }
            if (oComplain.HappyCallStatusID == (int)Dictionary.ComplainHappyCall.Satisfy)
            {
                oReport.SetParameterValue("RHappyStat", "Satisfy");
            }
            if (oComplain.HappyCallStatusID == -1)
            {
                oReport.SetParameterValue("RHappyStat", " ");
            }
       
            frmPrintPreview oForm = new frmPrintPreview();
            oForm.ShowDialog(oReport);
        }

    }

}


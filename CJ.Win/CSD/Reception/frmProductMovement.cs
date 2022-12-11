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
    public partial class frmProductMovement : Form
    {
        CSDJobs _oCSDJobs;
        ProductChallan _oProductChallan;
        ProductChallans _oProductChallans;
        bool IsCheck = true;
        int nChallanID = 0;
        string sChallanNo = "";
        int nCountMapChallanItem = 0;

        int _nUIControl = 0;

        public frmProductMovement(int nUIControl)
        {
            InitializeComponent();
            _nUIControl = nUIControl;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMap_Click(object sender, EventArgs e)
        {
            if (UIControl(1))
            {
                int nCount = 0;
                _oProductChallan = new ProductChallan();

                try
                {
                    DBController.Instance.BeginNewTransaction();////Added By Sajib
                    for (int i = 0; i < lvwUnMapJob.Items.Count; i++)
                    {
                        ListViewItem itm = lvwUnMapJob.Items[i];
                        if (lvwUnMapJob.Items[i].Checked == true)
                        {
                            //if (nCount == 0)
                            //{
                            //    DBController.Instance.BeginNewTransaction();
                            //}

                            CSDJob oCSDJob = (CSDJob)lvwUnMapJob.Items[i].Tag;
                            
                            //if (_nUIControl == 1)
                            //{
                            //    oCSDJob.ProductMovementStatus = (int)Dictionary.ProductMovementStatus.Send_to_Workshop;
                            //    oCSDJob.ProductLocation = (int)Dictionary.ProductLocation.Send_to_Workshop;
                            //}
                            //else if (_nUIControl == 2)
                            //{
                            //    oCSDJob.ProductMovementStatus = (int)Dictionary.ProductMovementStatus.Send_to_Front;
                            //    oCSDJob.ProductLocation = (int)Dictionary.ProductLocation.Send_to_FrontDesk;
                            //}
                            oCSDJob.ProductMovementStatus = (int)Dictionary.ProductMovementStatus.Create;

                            oCSDJob.UpdateProductMovement();
                            if (this.Tag == null)
                            {
                                if (lblChallanNo.Text == "")
                                {
                                    _oProductChallan = GetData(_oProductChallan, nCount, oCSDJob.JobID);

                                }
                                else
                                {
                                    ProductChallanAdd(oCSDJob.JobID, nChallanID);
                                }
                            }
                            else
                            {
                                ProductChallanAdd(oCSDJob.JobID, nChallanID);
                            }
                            nCount++;
                        }
                    }
                    if (nCount > 0)
                    {
                        if (this.Tag == null)
                        {
                            if (lblChallanNo.Text == "")
                            {
                                _oProductChallan.Insert();
                                lblChallanNo.Text = _oProductChallan.ChallanNo;
                                nChallanID = _oProductChallan.ChallanID;
                            }
                        }
                        else
                        {
                            lblChallanNo.Text = sChallanNo;

                        }
                        txtRemarks.Enabled = true;
                        //DBController.Instance.CommitTran();
                    }
                    DBController.Instance.CommitTran();//Added By Sajib
                }
                catch
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error Inserting Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                if (this.Tag == null)
                {
                    DataLoadControl();
                    DataLoadControl(nChallanID);
                }
                else
                {
                    DataLoadControl();
                    DataLoadControl(nChallanID);
                }
            }
            
        }

        private void ProductChallanAdd(int nJobID, int nChallanID)
        {
            ProductChallanItem oItem = new ProductChallanItem();
            oItem.JobID = nJobID;
            oItem.Insert(nChallanID);
        }

        private ProductChallan GetData (ProductChallan oProductChallan, int nCount, int nJobID)
        {
            if (nCount == 0)
            {
                string Prefix = "";
                if (_nUIControl == (int)Dictionary.ChallanCreateFrom.FrontDesk)
                {
                    oProductChallan.ChallanCreateFrom = (int)Dictionary.ChallanCreateFrom.FrontDesk;
                    Prefix = "F";
                }
                else if (_nUIControl == (int)Dictionary.ChallanCreateFrom.Workshop)
                {
                    oProductChallan.ChallanCreateFrom = (int)Dictionary.ChallanCreateFrom.Workshop;
                    Prefix = "W";
                }

                DateTime dt = DateTime.Now;

                string sdt = dt.ToString("yyyy-MMM-dd HH:mm tt");

                oProductChallan.ChallanNo = Prefix + "-" + sdt;
                oProductChallan.Status = (int)Dictionary.ProductMovementStatus.Create;
                oProductChallan.Remarks = "";
                oProductChallan.CreateUserID = Utility.UserId;
                oProductChallan.CreateDate = DateTime.Now;
                oProductChallan.UpdateUserID = Utility.UserId;
                oProductChallan.UpdateDate = DateTime.Now;
            }

            ProductChallanItem oProductChallanItem = new ProductChallanItem();
            oProductChallanItem.JobID = nJobID;

            oProductChallan.Add(oProductChallanItem);

            return oProductChallan;
        }

        private void btnUnmap_Click(object sender, EventArgs e)
        {
            if (UIControl(2))
            {
                int nCount = 0;
                int nChallanID = 0;
                CSDJob oCSDJob = new CSDJob();
                try
                {
                    for (int i = 0; i < lvwMapJob.Items.Count; i++)
                    {
                        ListViewItem itm = lvwMapJob.Items[i];
                        if (lvwMapJob.Items[i].Checked == true)
                        {
                            if (nCount == 0)
                            {
                                DBController.Instance.BeginNewTransaction();
                            }

                            ProductChallan oProductChallan = (ProductChallan)lvwMapJob.Items[i].Tag;

                            oProductChallan.DeleteChallanItem(oProductChallan.ChallanID, oProductChallan.JobID);
                            nChallanID = oProductChallan.ChallanID;

                            oCSDJob.JobID = oProductChallan.JobID;


                            if (_nUIControl == (int)Dictionary.ChallanCreateFrom.FrontDesk)
                            {
                                oCSDJob.ProductMovementStatus = (int)Dictionary.ProductMovementStatus.None;
                                oCSDJob.ProductLocation = (int)Dictionary.ProductLocation.At_FrontDesk;
                                oCSDJob.UpdateProductMovement();
                            }
                            else if (_nUIControl == (int)Dictionary.ChallanCreateFrom.Workshop)
                            {
                                oCSDJob.ProductMovementStatus = (int)Dictionary.ProductMovementStatus.Receive_at_Workshop;
                                oCSDJob.ProductLocation = (int)Dictionary.ProductLocation.At_Workshop;
                                oCSDJob.UpdateProductMovement();
                            }

                            nCount++;
                        }
                    }
                    if (nCount > 0)
                    {
                        DBController.Instance.CommitTran();
                    }
                }
                catch
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error Updating Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                DataLoadControl();
                DataLoadControl(nChallanID);
            }
        }

        public void ShowDialog(ProductChallan oProductChallan)
        {

            DataLoadControl(oProductChallan.ChallanID);

            nChallanID = oProductChallan.ChallanID;
            sChallanNo = oProductChallan.ChallanNo;
            lblChallanNo.Text = oProductChallan.ChallanNo;
            txtRemarks.Text = oProductChallan.Remarks;
            this.Tag = oProductChallan;
            this.ShowDialog();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                dtFromDate.Enabled = false;
                dtToDate.Enabled = false;
                IsCheck = true;
            }
            else
            {
                dtFromDate.Enabled = true;
                dtToDate.Enabled = true;
                IsCheck = false;
            }
        }

        private void frmProductMovement_Load(object sender, EventArgs e)
        {
            //LoadCombo();
            if (this.Tag == null)
            {
                lblChallanNo.Text = "";
                txtRemarks.Enabled = false;
            }
            chkAll.Checked = true;
            DataLoadControl();
        }

        private void DataLoadControl()
        {
            _oCSDJobs = new CSDJobs();
            lvwUnMapJob.Items.Clear();

            DBController.Instance.OpenNewConnection();
            {
                _oCSDJobs.GetUnSendJob(dtFromDate.Value.Date, dtToDate.Value.Date, IsCheck, txtJobNo.Text.Trim(), cmbASG.SelectedIndex, _nUIControl);//
            }
            lblTotalUnmap.Text = "Total " + "[" + _oCSDJobs.Count + "]";
            foreach (CSDJob oCSDJob in _oCSDJobs)
            {
                ListViewItem oItem = lvwUnMapJob.Items.Add(oCSDJob.JobNo);
                oItem.SubItems.Add(oCSDJob.ProductName);
                oItem.SubItems.Add(oCSDJob.ASGName);

                oItem.Tag = oCSDJob;
            }

        }

        private void DataLoadControl(int nChallanID)
        {
            _oProductChallans = new ProductChallans();
            lvwMapJob.Items.Clear();

            {
                _oProductChallans.RefreshByChallan(nChallanID);
            }
            lblTotalMap.Text = "Total " + "[" + _oProductChallans.Count + "]";
            foreach (ProductChallan oProductChallan in _oProductChallans)
            {
                ListViewItem oItem = lvwMapJob.Items.Add(oProductChallan.JobNo);
                oItem.SubItems.Add(oProductChallan.ProductName);
                oItem.SubItems.Add(oProductChallan.ASGName);

                oItem.Tag = oProductChallan;
            }
            nCountMapChallanItem = _oProductChallans.Count;

        }

        private void CheckedAll_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckedAll.Checked == true)
            {
                for (int i = 0; i < lvwUnMapJob.Items.Count; i++)
                {
                    ListViewItem itm = lvwUnMapJob.Items[i];

                    lvwUnMapJob.Items[i].Checked = true;

                }
            }
            else
            {
                for (int i = 0; i < lvwUnMapJob.Items.Count; i++)
                {
                    ListViewItem itm = lvwUnMapJob.Items[i];

                    lvwUnMapJob.Items[i].Checked = false;

                }
            }
        }

        private void lvwUnMapJob_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lvwUnMapJob.Sorting == SortOrder.Ascending)
            {
                lvwUnMapJob.Sorting = SortOrder.Descending;
            }
            else
            {
                lvwUnMapJob.Sorting = SortOrder.Ascending;
            }
            lvwUnMapJob.Sort();
        }

        private void CheckedMapAll_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckedMapAll.Checked == true)
            {
                for (int i = 0; i < lvwMapJob.Items.Count; i++)
                {
                    ListViewItem itm = lvwMapJob.Items[i];

                    lvwMapJob.Items[i].Checked = true;

                }
            }
            else
            {
                for (int i = 0; i < lvwMapJob.Items.Count; i++)
                {
                    ListViewItem itm = lvwMapJob.Items[i];

                    lvwMapJob.Items[i].Checked = false;

                }
            }
        }

        private void txtRemarks_TextChanged(object sender, EventArgs e)
        {
            ProductChallan oProductChallan = new ProductChallan();
            oProductChallan.ChallanID = nChallanID;
            oProductChallan.Remarks = txtRemarks.Text.Trim();
            oProductChallan.UpdateRemarks();
        }

        private bool UIControl(int nEntryMode)
        {
            int nCount = 0;
            if (nEntryMode == 1)//1=Insert
            {

                for (int i = 0; i < lvwUnMapJob.Items.Count; i++)
                {
                    ListViewItem itm = lvwUnMapJob.Items[i];
                    if (lvwUnMapJob.Items[i].Checked == true)
                    {
                        nCount++;
                    }
                }
                if (nCount == 0)
                {
                    MessageBox.Show("Please Checked at least a Job to make Challan", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

            }
            else
            {
                for (int i = 0; i < lvwMapJob.Items.Count; i++)
                {
                    ListViewItem itm = lvwMapJob.Items[i];
                    if (lvwMapJob.Items[i].Checked == true)
                    {
                        nCount++;
                    }
                }
                if (nCount == 0)
                {
                    MessageBox.Show("Please Checked at least a Job to remove from the Challan", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    if (nCountMapChallanItem == nCount)
                    {
                        MessageBox.Show("You couldn't remove all Job in the Challan\n You can delete the challan", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }

            return true;
        }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Win.Ecommerce;


namespace CJ.Win.Ecommerce
{
    public partial class frmPotentialCustomerFollowups : Form
    {
        PotentialCustomers _oPotentialCustomers;
        PotentialCustomers _oPotentialCustomers2;
        bool IsCheck = false;
        bool IsCheck1 = false;
        bool IsCheck2 = false;
        ProductGroups _oMAG;
        int _isHVACLead = 0;

        public frmPotentialCustomerFollowups()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadCombo()
        {
            dtFromDate.Value = DateTime.Today;
            dtToDate.Value = DateTime.Today;

            //Source
            cmbSource.Items.Clear();
            cmbSource.Items.Add("--All--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.PotentialCustomerSource)))
            {
                cmbSource.Items.Add(Enum.GetName(typeof(Dictionary.PotentialCustomerSource), GetEnum));
            }
            cmbSource.SelectedIndex = 0;


            //IsCall
            cmbIsCall.Items.Clear();
            cmbIsCall.Items.Add("--All--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.YesOrNoStatus)))
            {
                cmbIsCall.Items.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), GetEnum));
            }
            cmbIsCall.SelectedIndex = 0;

            //Status
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("--All--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.OutboundStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.OutboundStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;

            //Source 2
            cmbSource2.Items.Clear();
            cmbSource2.Items.Add("--All--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.PotentialCustomerSource)))
            {
                cmbSource2.Items.Add(Enum.GetName(typeof(Dictionary.PotentialCustomerSource), GetEnum));
            }
            cmbSource2.SelectedIndex = 0;

            //MAG 
            _oMAG = new ProductGroups();
            _oMAG.Refresh(Dictionary.ProductGroupType.MAG);
            cmbMAG.Items.Clear();
            cmbMAG.Items.Add("<All>");
            foreach (ProductGroup oProductGroup in _oMAG)
            {
                cmbMAG.Items.Add(oProductGroup.PdtGroupName);
            }
            cmbMAG.SelectedIndex = 0;


        }
        private void SetListViewRowColour()
        {


            if (lvwCustomerList.Items.Count > 0)
            {

                foreach (ListViewItem oItem in lvwCustomerList.Items)
                {
                    if (oItem.SubItems[8].Text == "NO")
                    {
                        oItem.BackColor = Color.LightCoral;
                    }
                    else
                    {
                        oItem.BackColor = Color.Transparent;
                    }

                }
            }
        }
        private void SetListViewRowColour1()
        {

            if (lvwCustomerList1.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwCustomerList1.Items)
                {
                    if (oItem.SubItems[0].Text == "Potential")
                    {
                        oItem.BackColor = Color.Yellow;
                    }
                    else if (oItem.SubItems[0].Text == "Invalid_Number")
                    {
                        oItem.BackColor = Color.Silver;
                    }
                    else if (oItem.SubItems[0].Text == "Switched_Off")
                    {
                        oItem.BackColor = Color.LightBlue;
                    }
                    else if (oItem.SubItems[0].Text == "Not_Answer")
                    {
                        oItem.BackColor = Color.PeachPuff;
                    }
                    else if (oItem.SubItems[0].Text == "Not_Sure")
                    {
                        oItem.BackColor = Color.Plum;
                    }
                    else if (oItem.SubItems[0].Text == "Not_Interested")
                    {
                        oItem.BackColor = Color.LightCyan;
                    }
                    else if (oItem.SubItems[0].Text == "Visited_To_Outlet_But_Not_Purchased")
                    {
                        oItem.BackColor = Color.PaleGreen;
                    }
                    else if (oItem.SubItems[0].Text == "Call_Later")
                    {
                        oItem.BackColor = Color.LightYellow;
                    }
                    else if (oItem.SubItems[0].Text == "Interested")
                    {
                        oItem.BackColor = Color.GreenYellow;
                    }
                    else if (oItem.SubItems[0].Text == "Bought_From_Other_Brand")
                    {
                        oItem.BackColor = Color.Salmon;
                    }
                    else
                    {
                        oItem.BackColor = Color.ForestGreen;
                    }

                }
            }
        }

        private void DataLoadControl1()
        {
            _oPotentialCustomers = new PotentialCustomers();
            lvwCustomerList.Items.Clear();
            this.Cursor = Cursors.WaitCursor;

            int nIsCall = 0;
            if (cmbIsCall.SelectedIndex == 0)
            {
                nIsCall = -1;
            }
            else
            {
                nIsCall = cmbIsCall.SelectedIndex;
            }
            int nSource = 0;
            if (cmbSource.SelectedIndex == 0)
            {
                nSource = -1;
            }
            else
            {
                nSource = cmbSource.SelectedIndex;
            }

            DBController.Instance.OpenNewConnection();
            _oPotentialCustomers.GetCustomerList(dtFromDate.Value.Date, dtToDate.Value.Date, nSource, nIsCall, txtEmail.Text.Trim(), txtCustomerName.Text.Trim(), txtMobileNo.Text.Trim(), txtTelephone.Text.Trim(), txtAddress.Text.Trim(), IsCheck);
            foreach (PotentialCustomer oPotentialCustomer in _oPotentialCustomers)
            {
                ListViewItem oItem = lvwCustomerList.Items.Add(Enum.GetName(typeof(Dictionary.PotentialCustomerSource), oPotentialCustomer.Source));
                oItem.SubItems.Add(oPotentialCustomer.ShowroomCode.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oPotentialCustomer.CreateDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oPotentialCustomer.Name.ToString());
                oItem.SubItems.Add(oPotentialCustomer.MobileNo.ToString());
                oItem.SubItems.Add(oPotentialCustomer.TelephoneNo.ToString());
                oItem.SubItems.Add(oPotentialCustomer.Email.ToString());
                oItem.SubItems.Add(oPotentialCustomer.Address.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), oPotentialCustomer.IsCall));

                oItem.Tag = oPotentialCustomer;
            }
            this.Cursor = Cursors.Default;
            SetListViewRowColour();
            this.Text = "Customer List [" + _oPotentialCustomers.Count + "]";
        }
        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl1();
        }
        private void frmPotentialCustomerFollowups_Load(object sender, EventArgs e)
        {
            LoadCombo();
            this.Text = "CRM";
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lvwCustomerList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a data.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            PotentialCustomer oPotentialCustomer = (PotentialCustomer)lvwCustomerList.SelectedItems[0].Tag;
            if (oPotentialCustomer.IsCall == 0)
            {
                frmPotentialCustomerFollowup oForm = new frmPotentialCustomerFollowup();
                oForm.ShowDialog(oPotentialCustomer);
                if (oForm.IsTrue == true)
                {
                    DataLoadControl1();
                }
            }
            else
            {
                MessageBox.Show("Already contacted in this mobile number.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }

        private void btnGetData1_Click(object sender, EventArgs e)
        {
            DataLoadControlFollowUp();
        }

        private void DataLoadControlFollowUp()
        {
            _oPotentialCustomers = new PotentialCustomers();
            lvwCustomerList1.Items.Clear();
            this.Cursor = Cursors.WaitCursor;

            int nStatus = 0;
            if (cmbStatus.SelectedIndex == 0)
            {
                nStatus = -1;
            }
            else
            {
                nStatus = cmbStatus.SelectedIndex;
            }


            DBController.Instance.OpenNewConnection();
            _oPotentialCustomers.GetFollowUpdata(dtFromDate1.Value.Date, dtToDate1.Value.Date, nStatus, txtEmail1.Text.Trim(), txtCustomerName1.Text.Trim(), txtMobile1.Text.Trim(), txtAddress1.Text.Trim(), IsCheck1);
            foreach (PotentialCustomer oPotentialCustomer in _oPotentialCustomers)
            {
                ListViewItem oItem = lvwCustomerList1.Items.Add(Enum.GetName(typeof(Dictionary.OutboundStatus), oPotentialCustomer.Status));
                oItem.SubItems.Add(Convert.ToDateTime(oPotentialCustomer.NextFollowupDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oPotentialCustomer.Name.ToString());
                oItem.SubItems.Add(oPotentialCustomer.MobileNo.ToString());
                oItem.SubItems.Add(oPotentialCustomer.Address.ToString());
                oItem.SubItems.Add(oPotentialCustomer.Email.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oPotentialCustomer.CreateDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oPotentialCustomer.Remarks.ToString());

                oItem.Tag = oPotentialCustomer;
            }
            this.Cursor = Cursors.Default;
            SetListViewRowColour1();
            this.Text = "Customer List [" + _oPotentialCustomers.Count + "]";
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked == true)
            {
                dtFromDate1.Enabled = false;
                dtToDate1.Enabled = false;
                IsCheck1 = true;
            }
            else
            {
                dtFromDate1.Enabled = true;
                dtToDate1.Enabled = true;
                IsCheck1 = false;
            }
        }

        private void btnClose1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertToLead_Click(object sender, EventArgs e)
        {
            if (lvwCustomerList1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            PotentialCustomer oPotentialCustomer = (PotentialCustomer)lvwCustomerList1.SelectedItems[0].Tag;
            SalesLead oSalesLead = new SalesLead();
            oSalesLead.Name = oPotentialCustomer.Name;
            oSalesLead.Address = oPotentialCustomer.Address;
            oSalesLead.ContactNo = oPotentialCustomer.MobileNo;
            oSalesLead.Email = oPotentialCustomer.Email;
            oSalesLead.OutboundCallID = oPotentialCustomer.OutboundCallID;
            frmECSalesLead oform = new frmECSalesLead(2, _isHVACLead);
            oform.ShowDialog(oSalesLead);
            DataLoadControlFollowUp();
        }

        private void btnStatusUpdate_Click(object sender, EventArgs e)
        {
            if (lvwCustomerList1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            PotentialCustomer oPotentialCustomer = (PotentialCustomer)lvwCustomerList1.SelectedItems[0].Tag;
            frmOutboundCallStatusUpdate oform = new frmOutboundCallStatusUpdate();
            oform.ShowDialog(oPotentialCustomer);
            DataLoadControlFollowUp();
        }

        private void btnClose2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            frmPotentialCustomerEntry oForm = new frmPotentialCustomerEntry();
            oForm.ShowDialog();
        }

        private void btnGetData2_Click(object sender, EventArgs e)
        {
            DataLoadControl2();
        }

        private void DataLoadControl2()
        {
            _oPotentialCustomers2 = new PotentialCustomers();
            lvwPotentialCustomer.Items.Clear();
            this.Cursor = Cursors.WaitCursor;

            int nSource = 0;
            if (cmbSource2.SelectedIndex == 0)
            {
                nSource = -1;
            }
            else
            {
                nSource = cmbSource2.SelectedIndex;
            }

            int nMAG = 0;
            if (cmbMAG.SelectedIndex == 0)
            {
                nMAG = -1;
            }
            else
            {
                nMAG = _oMAG[cmbMAG.SelectedIndex - 1].PdtGroupID;
            }

            DBController.Instance.OpenNewConnection();
            _oPotentialCustomers2.GetHOPotentialCustomer(dtFromDate2.Value.Date, dtToDate2.Value.Date, txtCustomerName2.Text.Trim(), txtContactNo2.Text.Trim(), nMAG, nSource, IsCheck2);

            foreach (PotentialCustomer oPotentialCustomer2 in _oPotentialCustomers2)
            {
                ListViewItem oItem = lvwPotentialCustomer.Items.Add(Enum.GetName(typeof(Dictionary.PotentialCustomerSource), oPotentialCustomer2.Source));

                oItem.SubItems.Add(oPotentialCustomer2.Name.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oPotentialCustomer2.VisitDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oPotentialCustomer2.MobileNo.ToString());
                oItem.SubItems.Add(oPotentialCustomer2.TelephoneNo.ToString());
                oItem.SubItems.Add(oPotentialCustomer2.Designation.ToString());
                oItem.SubItems.Add(oPotentialCustomer2.CompanyName.ToString());
                oItem.SubItems.Add(oPotentialCustomer2.Address.ToString());
                oItem.SubItems.Add(oPotentialCustomer2.Email.ToString());
                oItem.SubItems.Add(oPotentialCustomer2.MAGName.ToString());
                oItem.SubItems.Add(oPotentialCustomer2.Remarks.ToString());

                oItem.Tag = oPotentialCustomer2;
            }
            this.Cursor = Cursors.Default;
            //SetListViewRowColour1();
            this.Text = "Customer List [" + _oPotentialCustomers2.Count + "]";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                dtFromDate2.Enabled = false;
                dtToDate2.Enabled = false;
                IsCheck2 = true;
            }
            else
            {
                dtFromDate2.Enabled = true;
                dtToDate2.Enabled = true;
                IsCheck2 = false;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwPotentialCustomer.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a data.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            PotentialCustomer oPotentialCustomer = (PotentialCustomer)lvwPotentialCustomer.SelectedItems[0].Tag;
            frmPotentialCustomerEntry oForm = new frmPotentialCustomerEntry();
            oForm.ShowDialog(oPotentialCustomer);
            if (oForm.IsTrue == true)
            {
                DataLoadControl2();
            }



        }



    }
}
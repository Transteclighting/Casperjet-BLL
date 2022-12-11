// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Feb 26,2012
// Time : 12.00 PM
// Description: Inquiry Entry form for Call Center
// Modify Person And Date:
// </summary>


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
    public partial class frmInquiry : Form
    {
        Districts _oDistricts;
        Utilities oInquiryCategoryBeforeSale;
        Utilities oInquiryCategoryAfterSale;
        Utilities oGetInquiryResponse;
        Utilities oGetInquiryReferOutlet;
        //Utilities oGetInquirySalesNoExecuted;
        //Districts oDistricts;
   

        InquiryCategory oInquiryCategory;
        InquiryCategories oInquiryCategories;
        InquiryResponses oInquiryResponses;
        InquiryResponse oInquiryResponse;
        InquiryReferOutlet oInquiryReferOutlet;
        InquiryReferOutlets oInquiryReferOutlets;
        Customers _oCustomers;


        public frmInquiry()
        {
            InitializeComponent();
        }

        private void LoadCombos()
        {
            //InquiryType
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.InquiryType)))
            {
                cmbInquiryType.Items.Add(Enum.GetName(typeof(Dictionary.InquiryType), GetEnum));
            }
            cmbInquiryType.SelectedIndex = (int)Dictionary.InquiryType.Customer;

            _oDistricts = new Districts();
            _oDistricts.Refresh();
            foreach (District oDistrict in _oDistricts)
            {
                cmbDistrict.Items.Add(oDistrict.GeoLocationName);
            }
            if (_oDistricts.Count > 0)
            cmbDistrict.SelectedIndex =_oDistricts.Count - 1;

        _oCustomers = new Customers();
        _oCustomers.GetTDOutlet();
        foreach (Customer oCustomer in _oCustomers)
        {
            cmbOutlet.Items.Add(oCustomer.CustomerName);
        }
        cmbOutlet.Items.Add("No Refer");
        cmbOutlet.SelectedIndex = _oCustomers.Count;

        if (this.Tag == null)
        {
            rdbBeforeSale_CheckedChanged(null, null);
        }       

            lvwSerponseType.Items.Clear();
            oGetInquiryResponse = new Utilities();
            oGetInquiryResponse.GetInquiryResponse();
            foreach (Utility oUtility in oGetInquiryResponse)
            {
                ListViewItem oItem = lvwSerponseType.Items.Add(oUtility.Satus);
                oItem.Tag = oUtility;
            }

            lvwReferOutlet.Items.Clear();
            oGetInquiryReferOutlet = new Utilities();
            oGetInquiryReferOutlet.GetInquiryReferOutlet();
            foreach (Utility oUtility in oGetInquiryReferOutlet)
            {
                ListViewItem oItem = lvwReferOutlet.Items.Add(oUtility.Satus);
                oItem.Tag = oUtility;
            }
        }

        private void frmInquiry_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                
                rdbBeforeSale.Checked = true;
                rdoInBoundCall.Visible = false;
                rdoOutBoundCall.Visible = false;
                rdoNone.Visible = false;
                groupBox5.Visible = false;
                rdoNo.Checked = true;
                lblWEBTrackNo.Visible = false;
                txtWEBTrackNo.Visible = false;
                LoadCombos();
            }
            else
            {
                rdoInBoundCall.Visible = true;
                rdoOutBoundCall.Visible = true;
                rdoNone.Visible = true;
                groupBox5.Visible = true;
            }
        }

        public void ShowDialog(Inquiry oInquiry)
        {
            this.Tag = oInquiry;
            LoadCombos();

            if (oInquiry.IsWEBQuery == (int)Dictionary.IsWEBQuery.No)
            {
                rdoNo.Checked = true;
                lblWEBTrackNo.Visible = false;
                txtWEBTrackNo.Visible = false;
            }
            else
            {
                rdoYes.Checked = true;
                txtWEBTrackNo.Text = oInquiry.WEBTrackNo;
                lblWEBTrackNo.Visible = true;
                txtWEBTrackNo.Visible = true;

            }
            cmbInquiryType.SelectedIndex = oInquiry.InqType;
            txtInqName.Text = oInquiry.InqName;
            txtContactNo.Text = oInquiry.ContactNo;
            txtOutletName.Text = oInquiry.ReferedOutletName.ToString();
            txtLocation.Text = oInquiry.Location.ToString();
            cmbDistrict.SelectedIndex = _oDistricts.GetIndex(oInquiry.DistrictID);
            if (oInquiry.CustomerID == 0)
            {
                cmbOutlet.SelectedIndex = _oCustomers.Count;
            }
            else
            {
                cmbOutlet.SelectedIndex = _oCustomers.GetIndex(oInquiry.CustomerID);
            }
            txtRecvRemarks.Text = oInquiry.RecvRemarks;

            if (oInquiry.InquiryCatID == (int)Dictionary.ComplainCetagory.BeforeSale)
            {
                rdbAfterSale.Checked = false;
                rdbBeforeSale.Checked = true;
                rdbBeforeSale_CheckedChanged(null, null);
            }
            if (oInquiry.InquiryCatID == (int)Dictionary.ComplainCetagory.AfterSale)
            {
                rdbAfterSale.Checked = true;
                rdbBeforeSale.Checked = false;
                rdbAfterSale_CheckedChanged(null, null);
            }
            if (oInquiry.Solve == (int)Dictionary.Solve.InBoundCall)
            {
                rdoInBoundCall.Checked = true;
                rdoOutBoundCall.Checked = false;
                rdoNone.Checked = false;
            }
            else if (oInquiry.Solve == (int)Dictionary.Solve.OutBoundCall)
            {
                rdoInBoundCall.Checked = false;
                rdoOutBoundCall.Checked = true;
                rdoNone.Checked = false;
            }
            else
            {
                rdoNone.Checked = true;
            }

            oInquiryCategories = new InquiryCategories();
            oInquiryCategories.Refresh(oInquiry.InquiryID);
            for (int i = 0; i < lvwInqCatDetail.Items.Count; i++)
            {
                ListViewItem itm = lvwInqCatDetail.Items[i];
                Utility oUtility = (Utility)lvwInqCatDetail.Items[i].Tag;
                foreach (InquiryCategory oInquiryCategory in oInquiryCategories)
                {
                   if (oInquiryCategory.TypeID == (int)Dictionary.InquiryLvwTypes.InquiryCategory)
                   if (oInquiryCategory.TypeDetailID == oUtility.SatusId)
                        lvwInqCatDetail.Items[i].Checked = true;

                }
            }
            oInquiryResponses = new InquiryResponses();
            oInquiryResponses.Refresh(oInquiry.InquiryID);
            for (int i = 0; i < lvwSerponseType.Items.Count; i++)
            {
                ListViewItem itm = lvwSerponseType.Items[i];
                Utility oUtility = (Utility)lvwSerponseType.Items[i].Tag;
                foreach (InquiryResponse oInquiryResponse in oInquiryResponses)
                {
                   if(oInquiryResponse.TypeID == (int)Dictionary.InquiryLvwTypes.InqueryResponse)
                   if (oInquiryResponse.TypeDetailID == oUtility.SatusId)
                        lvwSerponseType.Items[i].Checked = true;

                }
            }
            oInquiryReferOutlets = new InquiryReferOutlets();
            oInquiryReferOutlets.Refresh(oInquiry.InquiryID);
            for (int i = 0; i < lvwReferOutlet.Items.Count; i++)
            {
                ListViewItem itm = lvwReferOutlet.Items[i];
                Utility oUtility = (Utility)lvwReferOutlet.Items[i].Tag;
                foreach (InquiryReferOutlet oInquiryReferOutlet in oInquiryReferOutlets)
                {
                    if (oInquiryReferOutlet.TypeID == (int)Dictionary.InquiryLvwTypes.InqueryReferOutlet)
                        if (oInquiryReferOutlet.TypeDetailID == oUtility.SatusId)
                            lvwReferOutlet.Items[i].Checked = true;

                }
            }

            this.ShowDialog();
        }

        private bool validateUIInput()
        {
            #region Input Information Validation


            if (txtInqName.Text == "")
            {
                MessageBox.Show("Please enter Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInqName.Focus();
                return false;
            }
            if (rdoYes.Checked == true)
            {
                if (txtWEBTrackNo.Text.Trim() == "")
                {
                    MessageBox.Show("Please enter Web Track No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtWEBTrackNo.Focus();
                    return false;
                }
            }


            #endregion

            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                this.Close();
            }
        }
        private void Save()
        {
            if (this.Tag == null)
            {
                Inquiry oInquiry = new Inquiry();

                if (rdoNo.Checked == true)
                {
                    oInquiry.IsWEBQuery = (int)Dictionary.IsWEBQuery.No;
                }
                else
                {
                    oInquiry.IsWEBQuery = (int)Dictionary.IsWEBQuery.Yes;
                }
                oInquiry.WEBTrackNo = txtWEBTrackNo.Text;
                oInquiry.InqType = cmbInquiryType.SelectedIndex;
                oInquiry.InqName = txtInqName.Text;
                oInquiry.ContactNo = txtContactNo.Text;
                if (cmbOutlet.Text == "No Refer")
                {
                    oInquiry.CustomerID = 0;
                }
                else
                {
                    oInquiry.CustomerID = _oCustomers[cmbOutlet.SelectedIndex].CustomerID;
                }
                oInquiry.ReferedOutletName = txtOutletName.Text;
                oInquiry.DistrictID = _oDistricts[cmbDistrict.SelectedIndex].GeoLocationID;
                oInquiry.Location = txtLocation.Text;
                oInquiry.RecvRemarks = txtRecvRemarks.Text;
                oInquiry.CommuStatus = (int)Dictionary.InquiryCommunicationStatus.False;
                if (rdbBeforeSale.Checked == true)
                {
                    oInquiry.InquiryCatID = (int)Dictionary.ComplainCetagory.BeforeSale;
                }
                else
                {
                    oInquiry.InquiryCatID = (int)Dictionary.ComplainCetagory.AfterSale;
                }
                if (rdoOutBoundCall.Checked == true)
                {
                    oInquiry.Solve = (int)Dictionary.Solve.OutBoundCall;
                }
                else if (rdoInBoundCall.Checked == true)
                {
                    oInquiry.Solve = (int)Dictionary.Solve.InBoundCall;
                }
                else
                {
                    oInquiry.Solve = (int)Dictionary.Solve.None;
                }
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oInquiry.Add();
                    for (int i = 0; i < lvwInqCatDetail.Items.Count; i++)
                    {
                        ListViewItem itm = lvwInqCatDetail.Items[i];
                        if (lvwInqCatDetail.Items[i].Checked == true)
                        {
                            Utility oUtility = (Utility)lvwInqCatDetail.Items[i].Tag;
                            oInquiryCategory = new InquiryCategory();
                            oInquiryCategory.InquiryID = oInquiry.InquiryID;
                            oInquiryCategory.TypeID = (int)Dictionary.InquiryLvwTypes.InquiryCategory;
                            oInquiryCategory.TypeDetailID = oUtility.SatusId;
                            oInquiryCategory.AddInquiryCategory();

                        }
                    }
                    for (int i = 0; i < lvwSerponseType.Items.Count; i++)
                    {
                        ListViewItem itm = lvwSerponseType.Items[i];
                        if (lvwSerponseType.Items[i].Checked == true)
                        {
                            Utility oUtility = (Utility)lvwSerponseType.Items[i].Tag;
                            oInquiryResponse = new InquiryResponse();
                            oInquiryResponse.InquiryID = oInquiry.InquiryID;
                            oInquiryResponse.TypeID = (int)Dictionary.InquiryLvwTypes.InqueryResponse;
                            oInquiryResponse.TypeDetailID = oUtility.SatusId;
                            oInquiryResponse.AddInquiryResponse();
                        }
                    }
                    for (int i = 0; i < lvwReferOutlet.Items.Count; i++)
                    {
                        ListViewItem itm = lvwReferOutlet.Items[i];
                        if (lvwReferOutlet.Items[i].Checked == true)
                        {
                            Utility oUtility = (Utility)lvwReferOutlet.Items[i].Tag;
                            oInquiryReferOutlet = new InquiryReferOutlet();
                            oInquiryReferOutlet.InquiryID = oInquiry.InquiryID;
                            oInquiryReferOutlet.TypeID = (int)Dictionary.InquiryLvwTypes.InqueryReferOutlet;
                            oInquiryReferOutlet.TypeDetailID = oUtility.SatusId;
                            oInquiryReferOutlet.AddInquiryReferOutlet();
                        }
                    }
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                Inquiry oInquiry = (Inquiry)this.Tag;
                {
                    if (rdoNo.Checked == true)
                    {
                        oInquiry.IsWEBQuery = (int)Dictionary.IsWEBQuery.No;
                    }
                    else
                    {
                        oInquiry.IsWEBQuery = (int)Dictionary.IsWEBQuery.Yes;
                    }
                    oInquiry.WEBTrackNo = txtWEBTrackNo.Text;
                    oInquiry.InqType = cmbInquiryType.SelectedIndex;
                    oInquiry.InqName = txtInqName.Text;
                    oInquiry.ContactNo = txtContactNo.Text;
                    if (cmbOutlet.Text == "No Refer")
                    {
                        oInquiry.CustomerID = 0;
                    }
                    else
                    {
                        oInquiry.CustomerID = _oCustomers[cmbOutlet.SelectedIndex].CustomerID;
                    }
                    oInquiry.ReferedOutletName = txtOutletName.Text;
                    oInquiry.DistrictID = _oDistricts[cmbDistrict.SelectedIndex].GeoLocationID;
                    oInquiry.Location = txtLocation.Text;
                    oInquiry.RecvRemarks = txtRecvRemarks.Text;
                    oInquiry.CommuStatus = (int)Dictionary.InquiryCommunicationStatus.False;
                    if (rdbBeforeSale.Checked == true)
                    {
                        oInquiry.InquiryCatID = (int)Dictionary.ComplainCetagory.BeforeSale;
                    }
                    else
                    {
                        oInquiry.InquiryCatID = (int)Dictionary.ComplainCetagory.AfterSale;
                    } 
                    if (rdoOutBoundCall.Checked == true)
                    {
                        oInquiry.Solve = (int)Dictionary.Solve.OutBoundCall;
                    }
                    else if (rdoInBoundCall.Checked == true)
                    {
                        oInquiry.Solve = (int)Dictionary.Solve.InBoundCall;
                    }
                    else
                    {
                        oInquiry.Solve = (int)Dictionary.Solve.None;
                    }
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        oInquiry.EditInquiry();

                        oInquiryCategory = new InquiryCategory();
                        oInquiryCategory.InquiryID = oInquiry.InquiryID;
                        oInquiryCategory.TypeID = (int)Dictionary.InquiryLvwTypes.InquiryCategory;
                        oInquiryCategory.DeleteInquiryCategory();

                        oInquiryResponse = new InquiryResponse();
                        oInquiryResponse.InquiryID = oInquiry.InquiryID;
                        oInquiryResponse.TypeID = (int)Dictionary.InquiryLvwTypes.InqueryResponse;
                        oInquiryResponse.DeleteInquiryResponse();

                        oInquiryReferOutlet = new InquiryReferOutlet();
                        oInquiryReferOutlet.InquiryID = oInquiry.InquiryID;
                        oInquiryReferOutlet.TypeID = (int)Dictionary.InquiryLvwTypes.InqueryReferOutlet;
                        oInquiryReferOutlet.DeleteInquiryReferOutlet();

                        for (int i = 0; i < lvwInqCatDetail.Items.Count; i++)
                        {
                            ListViewItem itm = lvwInqCatDetail.Items[i];
                            if (lvwInqCatDetail.Items[i].Checked == true)
                            {
                                Utility oUtility = (Utility)lvwInqCatDetail.Items[i].Tag;
                                oInquiryCategory = new InquiryCategory();
                                oInquiryCategory.InquiryID = oInquiry.InquiryID;
                                oInquiryCategory.TypeID = (int)Dictionary.InquiryLvwTypes.InquiryCategory;
                                oInquiryCategory.TypeDetailID = oUtility.SatusId;
                                oInquiryCategory.AddInquiryCategory();

                            }
                        }

                        for (int i = 0; i < lvwSerponseType.Items.Count; i++)
                        {
                            ListViewItem itm = lvwSerponseType.Items[i];
                            if (lvwSerponseType.Items[i].Checked == true)
                            {
                                Utility oUtility = (Utility)lvwSerponseType.Items[i].Tag;
                                oInquiryResponse = new InquiryResponse();
                                oInquiryResponse.InquiryID = oInquiry.InquiryID;
                                oInquiryResponse.TypeID = (int)Dictionary.InquiryLvwTypes.InqueryResponse;
                                oInquiryResponse.TypeDetailID = oUtility.SatusId;
                                oInquiryResponse.AddInquiryResponse();
                            }
                        }
                        for (int i = 0; i < lvwReferOutlet.Items.Count; i++)
                        {
                            ListViewItem itm = lvwReferOutlet.Items[i];
                            if (lvwReferOutlet.Items[i].Checked == true)
                            {
                                Utility oUtility = (Utility)lvwReferOutlet.Items[i].Tag;
                                oInquiryReferOutlet = new InquiryReferOutlet();
                                oInquiryReferOutlet.InquiryID = oInquiry.InquiryID;
                                oInquiryReferOutlet.TypeID = (int)Dictionary.InquiryLvwTypes.InqueryReferOutlet;
                                oInquiryReferOutlet.TypeDetailID = oUtility.SatusId;
                                oInquiryReferOutlet.AddInquiryReferOutlet();
                            }
                        }
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Update Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Refresh();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                }

            }
        }

        private void rdbBeforeSale_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbBeforeSale.Checked == true)
            {
                lvwInqCatDetail.Items.Clear();
                oInquiryCategoryBeforeSale = new Utilities();
                oInquiryCategoryBeforeSale.GetInquiryCategoryBeforeSale();
                foreach (Utility oUtility in oInquiryCategoryBeforeSale)
                {
                    ListViewItem oItem = lvwInqCatDetail.Items.Add(oUtility.Satus);
                    oItem.Tag = oUtility;
                }
            }
        }

        private void rdbAfterSale_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbAfterSale.Checked == true)
            {
                lvwInqCatDetail.Items.Clear();
                oInquiryCategoryAfterSale = new Utilities();
                oInquiryCategoryAfterSale.GetInquiryCategoryAfterSale();
                foreach (Utility oUtility in oInquiryCategoryAfterSale)
                {
                    ListViewItem oItem = lvwInqCatDetail.Items.Add(oUtility.Satus);
                    oItem.Tag = oUtility;
                }
            }
        }

        private void rdoNo_CheckedChanged(object sender, EventArgs e)
        {
            lblWEBTrackNo.Visible = false;
            txtWEBTrackNo.Visible = false;
        }

        private void rdoYes_CheckedChanged(object sender, EventArgs e)
        {
            lblWEBTrackNo.Visible = true;
            txtWEBTrackNo.Visible = true;
        }

    }
}
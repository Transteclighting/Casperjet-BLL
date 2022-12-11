// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Feb 26,2012
// Time : 12.00 PM
// Description: Complain Entry form for Call Center
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
    public partial class frmComplain : Form
    {
        ComplainCategory oComplainCategory;
        Utilities oComplainCategoryBeforeSale;
        Utilities oComplainCategoryAfterSale;
        ComplainCategories oComplainCategories;
        ComplainTypes oComplainTypes;
        ComplainType oComplainType;
        Utilities oGetComplainType;
        
        public frmComplain()
        {
            InitializeComponent();
        }

        private void LoadCombos()
        {

            //ComplainerType
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ComplainerType)))
            {
                cmbComplainType.Items.Add(Enum.GetName(typeof(Dictionary.ComplainerType), GetEnum));
            }
            cmbComplainType.SelectedIndex = (int)Dictionary.ComplainerType.Customer;

            //Source
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.Source)))
            {
                cmbSource.Items.Add(Enum.GetName(typeof(Dictionary.Source), GetEnum));
            }
            cmbSource.SelectedIndex = (int)Dictionary.Source.DuringInBoundCall;

            //ComplainType
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ComplainType)))
            {
                lvwComplainType.Items.Add(Enum.GetName(typeof(Dictionary.ComplainType), GetEnum));
            }
            ////ComplainCategoryBeforeSale

            //if (rdoBeforeSale.Checked == true)
            //{
            //foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ComplainCat_BeforeSale)))
            //    {
            //    lvwComCatDetail.Items.Add(Enum.GetName(typeof(Dictionary.ComplainCat_BeforeSale), GetEnum));
 
            //    }
            //}  
            
            //else
            ////ComplainCategoryAfterSale
            //{
            //foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ComplainCat_AfterSale)))
            //    {
            //    lvwComCatDetail.Items.Add(Enum.GetName(typeof(Dictionary.ComplainCat_AfterSale), GetEnum));
            //    }
            //}

            //lvwComplainType.SelectedIndices = (int)Dictionary.ComplainType.Quality;

            if (this.Tag == null)
                rdoAfterSale_CheckedChanged(null, null);

            //ComplainerAgainstWhom
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.AgainstWhom)))
            {
                cmbComplainAgainst.Items.Add(Enum.GetName(typeof(Dictionary.AgainstWhom), GetEnum));
            }

            cmbComplainAgainst.SelectedIndex = (int)Dictionary.AgainstWhom.Technician;

            lvwComplainType.Items.Clear();
            oGetComplainType = new Utilities();
            oGetComplainType.GetComplainType();
            foreach (Utility oUtility in oGetComplainType)
            {
                ListViewItem oItem = lvwComplainType.Items.Add(oUtility.Satus);
                oItem.Tag = oUtility;
            }
        }

        private void frmComplain_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
                LoadCombos();
        }
        public void ShowDialog(Complain oComplain)
        {
            this.Tag = oComplain;
            LoadCombos();
            txtComplainerName.Text = oComplain.Complainer;
            txtContactNo.Text=oComplain.ContactNo;
            cmbComplainType.SelectedIndex = oComplain.ComplainerTypeID;
            cmbSource.SelectedIndex = oComplain.SourceID;
            cmbComplainAgainst.SelectedIndex = oComplain.ComplainAgainstID;
            txtComplainAgainstWhom.Text=oComplain.ComplainAgainstWhom.ToString();
            txtComplainDetails.Text=oComplain.ComplainDetails;
            txtReferanceJobNo.Text=oComplain.ReferanceJobNo.ToString();
            dtDateOccurred.Value = Convert.ToDateTime(oComplain.DateOccurred.ToString());

            if (oComplain.ComplainCatID == 2)
            {
                rdoBeforeSale.Checked = false;
                rdoAfterSale.Checked = true;
                rdoAfterSale_CheckedChanged(null, null);
            }
            else
            {
                rdoAfterSale.Checked = false;
                rdoBeforeSale.Checked = true;
            }

            oComplainCategories = new ComplainCategories();
            oComplainCategories.Refresh(oComplain.ComplainID);
            for (int i = 0; i < lvwComCatDetail.Items.Count; i++)
            {
                ListViewItem itm = lvwComCatDetail.Items[i];
                Utility oUtility = (Utility)lvwComCatDetail.Items[i].Tag;
                foreach (ComplainCategory oComplainCategory in oComplainCategories)
                {
                    if (oComplainCategory.ComplainSubCatID == oUtility.SatusId)
                        lvwComCatDetail.Items[i].Checked = true;
                    
                }
            }
            oComplainTypes = new ComplainTypes();
            oComplainTypes.Refresh(oComplain.ComplainID);
            for (int i = 0; i < lvwComplainType.Items.Count; i++)
            {
                ListViewItem itm = lvwComplainType.Items[i];
                Utility oUtility = (Utility)lvwComplainType.Items[i].Tag;
                foreach (ComplainType oComplainType in oComplainTypes)
                {
                    if (oComplainType.ComplainTypeID == oUtility.SatusId)
                        lvwComplainType.Items[i].Checked = true;

                }
            }

            this.ShowDialog();
        }

        //private void frmComplain_Load(object sender, EventArgs e)
        //{
        //    if (this.Tag == null)
        //    {
        //        this.Text = "Add New Complain";            
        //    }
        //    else this.Text = "Edit Complain";
            
        //}
        private bool validateUIInput()
        {
            #region Input Information Validation
          
            if (txtComplainerName.Text == "")
            {
                MessageBox.Show("Please enter Complainer Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtComplainerName.Focus();
                return false;
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
                Complain oComplain = new Complain();
                oComplain.Complainer = txtComplainerName.Text;
                oComplain.ContactNo = txtContactNo.Text;
                oComplain.ComplainerTypeID = cmbComplainType.SelectedIndex;
                oComplain.SourceID = cmbSource.SelectedIndex;
                oComplain.ComplainAgainstID = cmbComplainAgainst.SelectedIndex;
                oComplain.ComplainAgainstWhom = txtComplainAgainstWhom.Text;
                oComplain.ComplainDetails = txtComplainDetails.Text;
                oComplain.ReferanceJobNo = txtReferanceJobNo.Text;
                oComplain.DateOccurred = dtDateOccurred.Value.Date;
                oComplain.ComplainStatus = (int)Dictionary.ComplainStatus.Receive;
                oComplain.AssignEmployeeID = 0;
                //oComplain.HappyCallStatusID = -1;
                if (rdoAfterSale.Checked == true)
                    oComplain.ComplainCatID = (int)Dictionary.ComplainCetagory.AfterSale;
                else oComplain.ComplainCatID = (int)Dictionary.ComplainCetagory.BeforeSale;

                
              try
                {
                    DBController.Instance.BeginNewTransaction();
                    oComplain.Add();
                    for (int i = 0; i < lvwComCatDetail.Items.Count; i++)
                    {
                        ListViewItem itm = lvwComCatDetail.Items[i];
                        if (lvwComCatDetail.Items[i].Checked == true)
                        {
                            Utility oUtility = (Utility)lvwComCatDetail.Items[i].Tag;
                            oComplainCategory = new ComplainCategory();
                            oComplainCategory.ComplainID = oComplain.ComplainID;
                            oComplainCategory.ComplainSubCatID = oUtility.SatusId;
                            oComplainCategory.AddtComplainCategory();                               

                        }
                    }
                    for (int i = 0; i < lvwComplainType.Items.Count; i++)
                    {
                        ListViewItem itm = lvwComplainType.Items[i];
                        if (lvwComplainType.Items[i].Checked == true)
                        {
                            Utility oUtility = (Utility)lvwComplainType.Items[i].Tag;
                            oComplainType = new ComplainType();
                            oComplainType.ComplainID = oComplain.ComplainID;
                            oComplainType.ComplainTypeID = oUtility.SatusId;
                            oComplainType.AddComplainType();

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
                Complain oComplain = (Complain)this.Tag;
                //if (oComplain.ComplainStatus != (int)Dictionary.ComplainStatus.Action)
                {
                    oComplain.Complainer = txtComplainerName.Text;
                    oComplain.ContactNo = txtContactNo.Text;
                    oComplain.ComplainerTypeID = cmbComplainType.SelectedIndex;
                    oComplain.SourceID = cmbSource.SelectedIndex;
                    oComplain.ComplainAgainstID = cmbComplainAgainst.SelectedIndex;
                    oComplain.ComplainAgainstWhom = txtComplainAgainstWhom.Text;
                    oComplain.ComplainDetails = txtComplainDetails.Text;
                    oComplain.ReferanceJobNo = txtReferanceJobNo.Text;
                    oComplain.DateOccurred = dtDateOccurred.Value.Date;
                    if (rdoAfterSale.Checked == true)
                        oComplain.ComplainCatID = (int)Dictionary.ComplainCetagory.AfterSale;
                    else oComplain.ComplainCatID = (int)Dictionary.ComplainCetagory.BeforeSale;

                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        oComplain.EditComplain();

                        oComplainCategory = new ComplainCategory();
                        oComplainCategory.ComplainID = oComplain.ComplainID;
                        oComplainCategory.DeleteComplainCategory();

                        oComplainType = new ComplainType();
                        oComplainType.ComplainID = oComplain.ComplainID;
                        oComplainType.DeleteComplainType();

                        for (int i = 0; i < lvwComCatDetail.Items.Count; i++)
                        {
                            ListViewItem itm = lvwComCatDetail.Items[i];
                            if (lvwComCatDetail.Items[i].Checked == true)
                            {
                                Utility oUtility = (Utility)lvwComCatDetail.Items[i].Tag;
                                oComplainType = new ComplainType();
                                oComplainCategory.ComplainID = oComplain.ComplainID;
                                oComplainCategory.ComplainSubCatID = oUtility.SatusId;
                                oComplainCategory.AddtComplainCategory();
                                
                            }
                        }

                        for (int i = 0; i < lvwComplainType.Items.Count; i++)
                        {
                            ListViewItem itm = lvwComplainType.Items[i];
                            if (lvwComplainType.Items[i].Checked == true)
                            {
                                Utility oUtility = (Utility)lvwComplainType.Items[i].Tag;
                                oComplainType = new ComplainType();
                                oComplainType.ComplainID = oComplain.ComplainID;
                                oComplainType.ComplainTypeID = oUtility.SatusId;
                                oComplainType.AddComplainType();
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
                //else
                //{
                //    MessageBox.Show("Please enter Complainer Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //}
            }
        }

        //private void rdoAfterSale_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (rdoAfterSale.Checked == true)
        //    {
        //        lvwComCatDetail.Items.Clear();
        //        foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ComplainCat_AfterSale)))
        //        {
        //            lvwComCatDetail.Items.Add(Enum.GetName(typeof(Dictionary.ComplainCat_AfterSale), GetEnum));
        //        }
        //    }
        //}

        private void rdoBeforeSale_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoBeforeSale.Checked == true)
            {
                lvwComCatDetail.Items.Clear();
                oComplainCategoryBeforeSale = new Utilities();
                oComplainCategoryBeforeSale.GetComplainCategoryBeforeSale();
                foreach (Utility oUtility in oComplainCategoryBeforeSale)
                {
                    ListViewItem oItem = lvwComCatDetail.Items.Add(oUtility.Satus);
                    oItem.Tag = oUtility;
                }
            }
        }

        private void rdoAfterSale_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoAfterSale.Checked == true)
            {
                lvwComCatDetail.Items.Clear();
                oComplainCategoryAfterSale = new Utilities();
                oComplainCategoryAfterSale.GetComplainCategoryAfterSale();
                foreach (Utility oUtility in oComplainCategoryAfterSale)
                {
                    ListViewItem oItem = lvwComCatDetail.Items.Add(oUtility.Satus);
                    oItem.Tag = oUtility;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }       
    }
}
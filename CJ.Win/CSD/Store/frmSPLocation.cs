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
    public partial class frmSPLocation : Form
    {
        public bool isAnyActivityDone = false;

        public frmSPLocation()
        {
            InitializeComponent();
        }
        private void LoadCombos()
        {
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.InquiryCommunicationStatus)))
            {
                cmbIsActive.Items.Add(Enum.GetName(typeof(Dictionary.InquiryCommunicationStatus), GetEnum));
            }
            cmbIsActive.SelectedIndex = (int)Dictionary.InquiryCommunicationStatus.True;
        }
        public void ShowDialog(SparePartLocation oSparePartLocation)
        {
            this.Tag = oSparePartLocation;
            LoadCombos();

            txtLocationName.Text = oSparePartLocation.LocationName;
            txtDescription.Text = oSparePartLocation.Description;
            cmbIsActive.SelectedIndex = oSparePartLocation.IsActive;
            txtLocationName.Enabled = false;
            this.ShowDialog();
        }
        private bool validateUIInput()
        {
            #region Input Information Validation

            if (txtLocationName.Text == "" || txtLocationName.Text == null)
            {
                MessageBox.Show("Please enter Location Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            isAnyActivityDone = true;
            if (this.Tag == null)
            {

                SparePartLocation oSparePartLocation = new SparePartLocation();

                oSparePartLocation.LocationName =txtLocationName.Text;
                oSparePartLocation.Description = txtDescription.Text;
                oSparePartLocation.IsActive = cmbIsActive.SelectedIndex;
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    if (oSparePartLocation.CheckLocationName())
                    {
                        MessageBox.Show("Duplicate Entry", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                    else
                    {
                        oSparePartLocation.Add();

                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Refresh();  
                    }

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                SparePartLocation oSparePartLocation = (SparePartLocation)this.Tag;
                
                {

                    oSparePartLocation.LocationName = txtLocationName.Text;
                    oSparePartLocation.Description = txtDescription.Text;
                    oSparePartLocation.IsActive = cmbIsActive.SelectedIndex;

                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        //if (oSparePartLocation.CheckLocationName())
                        //{
                        //    DBController.Instance.CommitTransaction();
                        //    MessageBox.Show("Duplicate Entry", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        //    return;
                        //}
                        //else
                        //{
                            oSparePartLocation.Edit();

                            DBController.Instance.CommitTransaction();
                            MessageBox.Show("Update Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Refresh();
                        //}
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }

                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSPLocation_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                LoadCombos();
            }
            else
            { 
            }
        }


    }
        
}
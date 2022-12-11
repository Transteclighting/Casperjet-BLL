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
    public partial class frmWorkshopLocation : Form
    {
        public frmWorkshopLocation()
        {
            InitializeComponent();
        }
      
        private bool validateUIInput()
        {
            #region Input Information Validation

            if (txtWSLocationName.Text.Trim() == "" || txtWSLocationName.Text == null)
            {
                MessageBox.Show("Please enter Workshop Location Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        public void ShowDialog(WorkshopLocation oWorkshopLocation)
        {
            this.Tag = oWorkshopLocation;
            txtWSLocationName.Text = oWorkshopLocation.Name;
            this.ShowDialog();
        }
        private void Save()
        {
            if (this.Tag == null)
            {


                WorkshopLocation oWorkshopLocation = new WorkshopLocation();

                oWorkshopLocation.Name = txtWSLocationName.Text;
                
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    if (oWorkshopLocation.CheckWSLocationName())
                    {
                        oWorkshopLocation.Add();

                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Refresh(); 
                    }
                    else
                    {

                        MessageBox.Show("Duplicate Entry", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
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
                WorkshopLocation oWorkshopLocation = (WorkshopLocation)this.Tag;

                {
                    oWorkshopLocation.Name = txtWSLocationName.Text;

                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        if (oWorkshopLocation.CheckWSLocationName())
                        {
                            oWorkshopLocation.Edit();

                            DBController.Instance.CommitTransaction();
                            MessageBox.Show("Update Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Refresh();
                        }
                        else
                        {

                            DBController.Instance.CommitTransaction();
                            MessageBox.Show("Duplicate Entry", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            return;
                        }
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

    }
        
}
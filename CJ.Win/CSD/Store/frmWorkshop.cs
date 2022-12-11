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
    public partial class frmWorkshop : Form
    {
        //WorkshopLocations _oWorkshopLocations;
        public frmWorkshop()
        {
            InitializeComponent();
        }
        private void LoadCombos()
        {

            //Is Active
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.InquiryCommunicationStatus)))
            {
                cmbIsActive.Items.Add(Enum.GetName(typeof(Dictionary.InquiryCommunicationStatus), GetEnum));
            }
            cmbIsActive.SelectedIndex = (int)Dictionary.InquiryCommunicationStatus.True;
        }
        public void ShowDialog(Workshop oWorkshop)
        {
            this.Tag = oWorkshop;
            LoadCombos();

            txtWorkshopName.Text = oWorkshop.Name;
            cmbIsActive.SelectedIndex = oWorkshop.IsActive;

            this.ShowDialog();
        }
        private bool validateUIInput()
        {
            #region Input Information Validation

            if (txtWorkshopName.Text.Trim() == "" || txtWorkshopName.Text == null)
            {
                MessageBox.Show("Please enter Workshop Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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


                Workshop oWorkshop = new Workshop();
                oWorkshop.Name =txtWorkshopName.Text;
                oWorkshop.IsActive = cmbIsActive.SelectedIndex;
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    if (oWorkshop.CheckWorkshop())
                    {
                        oWorkshop.Add();
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Refresh();  
                    }
                    else
                    {

                        MessageBox.Show("Duplicate Entry", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        //return;
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
                Workshop oWorkshop = (Workshop)this.Tag;
                
                {

                    oWorkshop.Name = txtWorkshopName.Text;
                    oWorkshop.IsActive = cmbIsActive.SelectedIndex;

                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        if (oWorkshop.CheckWorkshop())
                        {
                            oWorkshop.Edit();
                            DBController.Instance.CommitTransaction();
                            MessageBox.Show("Update Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Refresh();  
                        }
                        else
                        {

                            DBController.Instance.CommitTransaction();
                            MessageBox.Show("Duplicate Entry", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            //return;
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
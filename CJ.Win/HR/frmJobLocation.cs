using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.HR;

namespace CJ.Win
{
    public partial class frmJobLocation : Form
    {
        JobLocations _oJobLocations;
        public bool _isSet = false;
        public frmJobLocation()
        {
            InitializeComponent();
        }


        public void ShowDialog(JobLocation oJobLocation)
        {
            this.Tag = oJobLocation;
            LoadCombos();

            txtCode.Text = oJobLocation.JobLocationCode;
            txtName.Text = oJobLocation.JobLocationName;
            txtSort.Text = oJobLocation.Sort.ToString();
            txtDescription.Text = oJobLocation.Description;
            cmbType.SelectedIndex = _oJobLocations.GetIndexType(oJobLocation.TypeID) + 1;
            if (oJobLocation.IsActive == (int)Dictionary.YesNAStatus.Yes)
            {
                chkIsActive.Checked = true;
            }
            else
            {
                chkIsActive.Checked = false;
            }

            this.ShowDialog();
        }


        private void frmJobLocation_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add New JobLocation";
                LoadCombos();
            }

            else 
            {
                this.Text = "Edit JobLocation";
            }
        }

        private void LoadCombos()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            //Location
            _oJobLocations = new JobLocations();
            _oJobLocations.JobLocationType();
            cmbType.Items.Clear();
            cmbType.Items.Add("---Select Type---");
            foreach (JobLocation oJobLocation in _oJobLocations)
            {
                cmbType.Items.Add(oJobLocation.TypeName);
            }
            cmbType.SelectedIndex = 0;
           

        }
        private bool validateUIInput()
        {
            #region Input Information Validation


            if (txtCode.Text == "")
            {
                MessageBox.Show("Please enter Code of JobLocation", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }

            if (txtName.Text == "")
            {
                MessageBox.Show("Please enter Name if JobLocation", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            if (txtDescription.Text == "")
            {
                MessageBox.Show("Please enter description", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Focus();
                return false;
            }
            if (cmbType.SelectedIndex == 0)
            {
                MessageBox.Show("Please select job location type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCode.Focus();
                return false;
            }
            if (txtSort.Text == "")
            {
                MessageBox.Show("Please enter Sort", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSort.Focus();
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
                _isSet = true;
                //btnClear_Click(sender, e);
                this.Close();
            }
        }


        private void Save()
        {
            if (this.Tag == null)
            {
                JobLocation oJobLocation = new JobLocation();
                oJobLocation.JobLocationCode = txtCode.Text;
                oJobLocation.JobLocationName = txtName.Text;
                oJobLocation.Description = txtDescription.Text;
                oJobLocation.Sort = Convert.ToInt32(txtSort.Text);
                oJobLocation.TypeID = _oJobLocations[cmbType.SelectedIndex - 1].TypeID;

                if (chkIsActive.Checked == true)
                {
                    oJobLocation.IsActive = (int)Dictionary.YesOrNoStatus.YES;

                }
                else
                {
                    oJobLocation.IsActive = (int)Dictionary.YesOrNoStatus.NO;
                }
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oJobLocation.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction : " + oJobLocation.JobLocationCode, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                JobLocation oJobLocation = (JobLocation)this.Tag;
                oJobLocation.JobLocationCode = txtCode.Text;
                oJobLocation.JobLocationName = txtName.Text;
                oJobLocation.Description = txtDescription.Text;
                oJobLocation.Sort = Convert.ToInt32(txtSort.Text);
                oJobLocation.TypeID = _oJobLocations[cmbType.SelectedIndex - 1].TypeID;
                if (chkIsActive.Checked == true)
                {
                    oJobLocation.IsActive = (int)Dictionary.YesOrNoStatus.YES;

                }
                else
                {
                    oJobLocation.IsActive = (int)Dictionary.YesOrNoStatus.NO;
                }

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oJobLocation.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update The JobLocation : " + oJobLocation.JobLocationCode, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtSort_TextChanged(object sender, EventArgs e)
        {
            if (txtSort.Text.Trim() != "")
            {
                try
                {
                    int temp = Convert.ToInt32(txtSort.Text);

                }
                catch
                {
                    MessageBox.Show("Please input valid sort ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSort.Text = "";
                }

            }
        }
    }
}
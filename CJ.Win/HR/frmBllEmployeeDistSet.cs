using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Admin;
using CJ.Class.HR;
using System; 
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CJ.Win.HR
{
    public partial class frmBllEmployeeDistSet : Form
    {

        MapERPHREmployeeDistributionSets _oBlldistributionSets;
        //Companys _oCompanys;
        Company oCompany;
        public bool _bActionSave = false;
        private string checkDuplicateValue;


        public frmBllEmployeeDistSet()
        {
            InitializeComponent();
        }

        private void frmBllEmployeeDistSet_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                LoadCombos();

            }
        }



        private void LoadCombos()
        {
            oCompany = new Company();
            oCompany.CompanyID = (int)Dictionary.CompanyID.BLL; 
            oCompany.Refresh();
            cmbCompany.Items.Clear();
            cmbCompany.Items.Add(oCompany.CompanyName);
            cmbCompany.SelectedIndex = 0;

        }

        public void ShowDialog(MapERPHREmployeeDistributionSet oMapERPHREmployeeDistributionSet)
        {
            this.Tag = oMapERPHREmployeeDistributionSet;
            LoadCombos();
            ctlEmployee1.txtCode.Text = oMapERPHREmployeeDistributionSet.EmployeeCode;
            cmbCompany.SelectedIndex = (int)Dictionary.CompanyID.BLL;
            txtDset.Text = oMapERPHREmployeeDistributionSet.DistributionSet;

            this.ShowDialog();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                Save();
                _bActionSave = true;
                this.Close();
            }
        }

        private bool UIValidation()
        {
            if (string.IsNullOrEmpty(ctlEmployee1.txtCode.Text))
            {
                MessageBox.Show("Please select an Employee", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlEmployee1.txtCode.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtDset.Text))
            {
                MessageBox.Show("Please insert distribution set", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDset.Focus();
                return false;
            }

            MapERPHREmployeeDistributionSet oMapERPHREmployeeDistributionSet = new MapERPHREmployeeDistributionSet();
            oMapERPHREmployeeDistributionSet.EmployeeCode = ctlEmployee1.txtCode.Text;
            checkDuplicateValue = oMapERPHREmployeeDistributionSet.CheckDuplicateData();

            if (checkDuplicateValue == "Yes" && this.Tag == null)
            {
                MessageBox.Show("Employee already exists", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlEmployee1.txtCode.Focus();
                return false;
            }


            return true;
        }

        private void Save()
        {
            if (this.Tag == null)
            {
                MapERPHREmployeeDistributionSet oMapERPHREmployeeDistributionSet = new MapERPHREmployeeDistributionSet();
                oMapERPHREmployeeDistributionSet.CompanyID = (int)Dictionary.CompanyID.BLL;
                oMapERPHREmployeeDistributionSet.DistributionSet = txtDset.Text;
                oMapERPHREmployeeDistributionSet.EmployeeCode = ctlEmployee1.txtCode.Text;
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oMapERPHREmployeeDistributionSet.AddByDistributionSet();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Your data has been saved successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                MapERPHREmployeeDistributionSet oMapERPHREmployeeDistributionSet = (MapERPHREmployeeDistributionSet)this.Tag;
                oMapERPHREmployeeDistributionSet.CompanyID = (int)Dictionary.CompanyID.BLL;
                oMapERPHREmployeeDistributionSet.DistributionSet = txtDset.Text;
                oMapERPHREmployeeDistributionSet.EmployeeCode = ctlEmployee1.txtCode.Text;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oMapERPHREmployeeDistributionSet.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Your data has been updated successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
    }
}

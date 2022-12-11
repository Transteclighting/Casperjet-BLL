using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CJ.Class.BasicData;
using CJ.Class;

namespace CJ.Win.Basic
{
    public partial class frmOutletRent : Form
    {
        public bool _Istrue = false;
        OutletRent _oOutletRent;
        OutletRents _oOutletRents;
        OutletRentHistory _oOutletRentHistory;
        Showrooms _oShowrooms;
        OutletRentAreaTypes _oOutletRentAreaTypes;
        string sAreaType = "";
        int nID = 0;
        public frmOutletRent()
        {
            InitializeComponent();
        }
        public void ShowDialog(OutletRent oOutletRent)
        {
            this.Tag = oOutletRent;
            LoadCombo();
            nID = oOutletRent.ID;
            sAreaType = oOutletRent.AreaType;
            cmbCode.Text= oOutletRent.ShowroomCode;
            //cmbCode.SelectedIndex = _oShowrooms.GetIndex(oOutletRent.LocationID) + 1;
            cmbType.Text = oOutletRent.AreaType;
            txtArea.Text =oOutletRent.Area.ToString();
            dtStartDate.Value = oOutletRent.AgreementStartDate;
            dtEndDate.Value = oOutletRent.AgreemntTenureEndDate;
            txtRent.Text = oOutletRent.Rent.ToString();
            txtTenur.Text = oOutletRent.AgreementTenure.ToString();
            txtVat.Text = oOutletRent.VAT.ToString();
            txtTax.Text= oOutletRent.TAX.ToString();
            txtTotalRent.Text = oOutletRent.TotalRent.ToString();
            dtRenualDate.Value = oOutletRent.NextRenualDate;
            txtRenualEffect.Text = oOutletRent.RenualEffect.ToString();
            if (oOutletRent.IsActive == 1)
            {
                chkActive.Checked = true;
            }
            else
            {
                chkActive.Checked = false;
            }

            this.ShowDialog();
        }
        private void frmOutletRent_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                LoadCombo();               
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
            }
        }        
        private void LoadCombo()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            cmbCode.Items.Add("--<All>--");
            _oShowrooms = new Showrooms();
            _oShowrooms.GetShowroomByJobLocation();
            foreach (Showroom oShowroom in _oShowrooms)
            {
                cmbCode.Items.Add(oShowroom.ShowroomName);
            }
            cmbCode.SelectedIndex = 0;
            LoadType();
        }
        private void LoadType()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            
            _oOutletRentAreaTypes = new OutletRentAreaTypes();
            _oOutletRentAreaTypes.Refresh();
            cmbType.Items.Clear();
            cmbType.Items.Add("--<All>--");
            foreach (OutletRentAreaType oOutletRentAreaType in _oOutletRentAreaTypes)
            {
                cmbType.Items.Add(oOutletRentAreaType.AreaType);
            }
            cmbType.SelectedIndex = 0;
        }
        public OutletRent GetUIData(OutletRent oOutletRent)
        {
            //_oOutletRent.ShowroomCode = cmbCode.Text;
            _oOutletRent.LocationID = _oShowrooms[cmbCode.SelectedIndex - 1].LocationID;
            _oOutletRent.Rent = Convert.ToDouble(txtRent.Text);
            _oOutletRent.RenualEffect = Convert.ToDouble(txtRenualEffect.Text);
            _oOutletRent.Area =Convert.ToInt32(txtArea.Text);
            _oOutletRent.AreaType = cmbType.Text;
            _oOutletRent.AgreementTenure= Convert.ToInt32(txtTenur.Text);
            _oOutletRent.AgreementStartDate = dtStartDate.Value;
            _oOutletRent.AgreemntTenureEndDate = dtEndDate.Value;
            _oOutletRent.NextRenualDate = dtRenualDate.Value;           
            _oOutletRent.TAX = Convert.ToDouble(txtTax.Text);
            _oOutletRent.VAT = Convert.ToDouble(txtVat.Text);           
            _oOutletRent.TotalRent= Convert.ToDouble(txtTotalRent.Text); 
            if (chkActive.Checked == true)
                { 
                _oOutletRent.IsActive = (int)Dictionary.YesOrNoStatus.YES;
                } 
            else
            {
                _oOutletRent.IsActive = (int)Dictionary.YesOrNoStatus.NO;
            }           
            return _oOutletRent;
        }
        private void ADDHistory(OutletRent oOutletRent)
        {
            _oOutletRentHistory = new OutletRentHistory();
            _oOutletRentHistory.LocationName = cmbCode.Text;
            _oOutletRentHistory.AreaType = oOutletRent.AreaType;
            _oOutletRentHistory.Area = oOutletRent.Area;
            _oOutletRentHistory.AgreementStartDate = oOutletRent.AgreementStartDate;
            _oOutletRentHistory.CreateBy = Utility.UserId;
            _oOutletRentHistory.CreateDate = DateTime.Now;
            _oOutletRentHistory.AgreementTenure = oOutletRent.AgreementTenure;
            _oOutletRentHistory.AgreementTenureEndDate = oOutletRent.AgreemntTenureEndDate;
            _oOutletRentHistory.NextRenualDate= oOutletRent.NextRenualDate;
            _oOutletRentHistory.Rent = oOutletRent.Rent;
            _oOutletRentHistory.Vat= oOutletRent.VAT;
            _oOutletRentHistory.Tax = oOutletRent.TAX;
            _oOutletRentHistory.TotalRent = oOutletRent.TotalRent;
            _oOutletRentHistory.Add();

        }
        private void Save()
        {
            if (this.Tag != null)
            {
                if (validateUIInput())
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        _oOutletRent = (OutletRent)this.Tag;
                        _oOutletRent = GetUIData(_oOutletRent);
                        //_oOutletRent.UpdateRent(_oOutletRent.ShowroomCode, sAreaType,nID)
                        _oOutletRent.UpdateByTranscomRent(nID);
                        ADDHistory(_oOutletRent);
                        DBController.Instance.CommitTran();
                        MessageBox.Show("Success fully Update# " , "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show("Error... " + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else
            {
                if (validateUIInput())
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        _oOutletRent = new OutletRent();
                        _oOutletRent = GetUIData(_oOutletRent);
                        _oOutletRent.Add();
                        ADDHistory(_oOutletRent);
                        DBController.Instance.CommitTran();
                        MessageBox.Show("Successfully Add# " , "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                    }
                }
            }
        }

        private bool validateUIInput()
        {
            
            if (cmbCode.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Show Room Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCode.Focus();
                return false;
            }
            if (cmbType.Text.Trim() == "--<All>--")
            {
                MessageBox.Show("Please Input Area Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbType.Focus();
                return false;
            }
            if (txtArea.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Area", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtArea.Focus();
                return false;
            }            
            if (txtRent.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Rent", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRent.Focus();
                return false;
            }
            if (txtTenur.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Tenur", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenur.Focus();
                return false;
            }
            if (txtVat.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Vat", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVat.Focus();
                return false;
            }
            if (txtTax.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Tax", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTax.Focus();
                return false;
            }
            if (txtRenualEffect.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Renual Effect", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRenualEffect.Focus();
                return false;
            }
            return true;
        }

        private void txtTotalRent_TextChanged(object sender, EventArgs e)
        {               
        }

        private void txtRent_TextChanged(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtRent.Text) || string.IsNullOrEmpty(txtVat.Text))

            {                
                txtTotalRent.Text = (Convert.ToDouble(txtRent.Text) + Convert.ToDouble(txtVat.Text)).ToString();
            }
        }

        private void txtVat_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtRent.Text) || string.IsNullOrEmpty(txtVat.Text))

            {
                txtTotalRent.Text = (Convert.ToDouble(txtRent.Text) + Convert.ToDouble(txtVat.Text)).ToString();
            }
        }

        private void txtTax_TextChanged(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(txtRent.Text) || string.IsNullOrEmpty(txtVat.Text) || string.IsNullOrEmpty(txtTax.Text))

            //{
            //    txtTotalRent.Text = (Convert.ToDouble(txtRent.Text) + Convert.ToDouble(txtVat.Text) + Convert.ToDouble(txtTax.Text)).ToString();
            //}
        }

        private void btnAddType_Click(object sender, EventArgs e)
        {
            frmOutletRentAreaType ofrmOutletRentAreaType = new frmOutletRentAreaType();
            ofrmOutletRentAreaType.ShowDialog();
            if (ofrmOutletRentAreaType._Istrue == true)
            {
                LoadType();
            }
        }
        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
           //LoadType();
        }
    }
}

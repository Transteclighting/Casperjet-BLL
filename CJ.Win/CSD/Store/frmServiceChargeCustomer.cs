using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;



namespace CJ.Win.CSD.Store
{
    public partial class frmServiceChargeCustomer : Form
    {
        int _nServiceChargeID = 0;
        private CSDServiceCharges oCSDServiceCharges;
        public frmServiceChargeCustomer()
        {
            InitializeComponent();
        }

        private void frmServiceChargeCustomer_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        public void ShowDialog(CSDServiceCharge oCSDServiceCharge)
        {
            _nServiceChargeID = oCSDServiceCharge.ServiceChargeID;
            txtOwnTechHomeCall.Text = oCSDServiceCharge.OwnTechHomeCall.ToString();
            txtOwnTechWalkIn.Text = oCSDServiceCharge.OwnTechWalkIn.ToString();
            txtOwnTechInstallation.Text = oCSDServiceCharge.OwnTechInstallation.ToString();

            txtThirdPartyHomeCall.Text = oCSDServiceCharge.ThirdPartyHomeCall.ToString();
            txtThirdPartyInstallation.Text = oCSDServiceCharge.ThirdPartyInstallation.ToString();
            txtThirdPartyWalkIn.Text = oCSDServiceCharge.ThirdPartyWalkIn.ToString();

            this.Tag = oCSDServiceCharge;
            this.ShowDialog();
        }
        private void DataLoadControl()
        {
            //dgvServiceChargeCustomer.Rows.Clear();
            //int nServiceChargLen = Enum.GetNames(typeof(Dictionary.CSDServiceChargeType)).Length;
            //for (int i = 1; i <= nServiceChargLen; i++)
            //{
            //    int n = dgvServiceChargeCustomer.Rows.Add();
            //    dgvServiceChargeCustomer.Rows[n].Cells[0].Value = i;
            //    dgvServiceChargeCustomer.Rows[n].Cells[1].Value = Enum.GetName(typeof(Dictionary.CSDServiceChargeType), i);
            //}

            CSDServiceCharges oCSDServiceCharges = new CSDServiceCharges();
            oCSDServiceCharges.RefreshByServiceCharge(_nServiceChargeID);
            if (oCSDServiceCharges.Count > 0)
            {
                foreach (CSDServiceCharge oItem in oCSDServiceCharges)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvServiceChargeCustomer);
                    oRow.Cells[0].Value = oItem.ServiceChargeID.ToString();
                    oRow.Cells[1].Value = oItem.ChargeType.ToString();
                    oRow.Cells[2].Value = oItem.Amount.ToString();
                    dgvServiceChargeCustomer.Rows.Add(oRow);
                }
            }
            else
            {
                foreach (string _name in Enum.GetNames(typeof(Dictionary.CSDServiceChargeType)))
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvServiceChargeCustomer);
                    oRow.Cells[0].Value = _nServiceChargeID.ToString();
                    oRow.Cells[1].Value = _name.ToString();
                    oRow.Cells[2].Value = "0";
                    dgvServiceChargeCustomer.Rows.Add(oRow);
                }
            }
           
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
            if (this.Tag != null)
            {
                CSDServiceCharge oCSDServiceCharge = (CSDServiceCharge)this.Tag;
                oCSDServiceCharge.OwnTechWalkIn = double.Parse(txtOwnTechWalkIn.Text.ToString().Trim());
                oCSDServiceCharge.OwnTechHomeCall = double.Parse(txtOwnTechHomeCall.Text.ToString().Trim());
                oCSDServiceCharge.OwnTechInstallation = double.Parse(txtOwnTechInstallation.Text.ToString().Trim());
                oCSDServiceCharge.ThirdPartyWalkIn = double.Parse(txtThirdPartyHomeCall.Text.ToString().Trim());
                oCSDServiceCharge.ThirdPartyHomeCall = double.Parse(txtThirdPartyHomeCall.Text.ToString().Trim());
                oCSDServiceCharge.ThirdPartyInstallation = double.Parse(txtThirdPartyInstallation.Text.ToString().Trim());
                oCSDServiceCharge.UpdateUserID = Utility.UserId;
                oCSDServiceCharge.UpdateDate = DateTime.Now;

                try
                {
                    DBController.Instance.OpenNewConnection();
                    DBController.Instance.BeginNewTransaction();                    
                    oCSDServiceCharge.Edit();
                    CSDServiceChargeCustomer oCSDServiceChargeCustomer= new CSDServiceChargeCustomer();
                    if (oCSDServiceChargeCustomer.IsServiceChargeSaved(oCSDServiceCharge.ServiceChargeID))
                    {
                        EditServiceChargeCustomer(oCSDServiceCharge.ServiceChargeID);
                    }
                    else
                    {
                        AddServiceChargeCustomer(oCSDServiceCharge.ServiceChargeID);
                    }
                    
                    DBController.Instance.CommitTransaction();
                    DBController.Instance.CloseConnection();
                    MessageBox.Show("You Have Successfully Updated Service Charge Customer.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
        }
        private void AddServiceChargeCustomer(int nServiceChargeID)
        {
            CSDServiceChargeCustomer oCSDServiceChargeCustomer;
            foreach (DataGridViewRow oItemRow in dgvServiceChargeCustomer.Rows)
            {
                if (oItemRow.Index < dgvServiceChargeCustomer.Rows.Count)
                {
                    oCSDServiceChargeCustomer = new CSDServiceChargeCustomer();
                    oCSDServiceChargeCustomer.ServiceChargeID = nServiceChargeID;
                    oCSDServiceChargeCustomer.ChargeType = (int)(Dictionary.CSDServiceChargeType)Enum.Parse(typeof(Dictionary.CSDServiceChargeType), oItemRow.Cells[1].Value.ToString());
                    oCSDServiceChargeCustomer.Amount = double.Parse(oItemRow.Cells[2].Value.ToString().Trim());
                    oCSDServiceChargeCustomer.Add();                    
                }
            }
        }

        private void EditServiceChargeCustomer(int nServiceChargeID)
        {
            CSDServiceChargeCustomer oCSDServiceChargeCustomer;
            foreach (DataGridViewRow oItemRow in dgvServiceChargeCustomer.Rows)
            {
                if (oItemRow.Index < dgvServiceChargeCustomer.Rows.Count)
                {
                    oCSDServiceChargeCustomer = new CSDServiceChargeCustomer();
                    oCSDServiceChargeCustomer.ServiceChargeID = nServiceChargeID;
                    oCSDServiceChargeCustomer.ChargeType = (int)(Dictionary.CSDServiceChargeType)Enum.Parse(typeof(Dictionary.CSDServiceChargeType), oItemRow.Cells[1].Value.ToString());
                    //oCSDServiceChargeCustomer.ChargeType = int.Parse(oItemRow.Cells[1].Value.ToString());
                    oCSDServiceChargeCustomer.Amount = double.Parse(oItemRow.Cells[2].Value.ToString().Trim());
                    oCSDServiceChargeCustomer.Edit(); //CSDServiceChargeType
                }
            }
        }

        private bool validateUIInput()
        {
            #region Input Information Validation
            if (txtOwnTechHomeCall.Text == String.Empty)
            {
                MessageBox.Show("Please Enter Own Technician Home Call", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOwnTechHomeCall.Focus();
                return false;
            }

            if (txtOwnTechWalkIn.Text == String.Empty)
            {
                MessageBox.Show("Please Enter Own Technician Walk In", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOwnTechWalkIn.Focus();
                return false;
            }

            if (txtOwnTechInstallation.Text == String.Empty)
            {
                MessageBox.Show("Please Enter Own Technician Installation", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOwnTechInstallation.Focus();
                return false;
            }



            if (txtThirdPartyHomeCall.Text == String.Empty)
            {
                MessageBox.Show("Please Enter Third Party Home Call", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtThirdPartyHomeCall.Focus();
                return false;
            }

            if (txtThirdPartyWalkIn.Text == String.Empty)
            {
                MessageBox.Show("Please Enter Third Party Walk In", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOwnTechWalkIn.Focus();
                return false;
            }

            if (txtThirdPartyInstallation.Text == String.Empty)
            {
                MessageBox.Show("Please Enter Third Party Installation", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtThirdPartyInstallation.Focus();
                return false;
            }



            foreach (DataGridViewRow oItemRow in dgvServiceChargeCustomer.Rows)
            {
                if (oItemRow.Index < dgvServiceChargeCustomer.Rows.Count)
                {
                    if (oItemRow.Cells[2].Value == null)
                    {
                        MessageBox.Show("Please Enter All Customer Service Charge Amount.", "Warnng", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;

                    }
                }
            }

            return true;
            #endregion
        }


    }
}
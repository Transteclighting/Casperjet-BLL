using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Admin;
using CJ.Class.Accounts;
using CJ.Class.POS;

namespace CJ.Win.Accounts
{
    public partial class frmEMITenure : Form
    {

        private string checkDuplicateValue;
        public bool _bActionSave = false;

        public frmEMITenure()
        {
            InitializeComponent();
        }

        public void ShowDialog(EMITenure oEMITenure)
        {
            this.Tag = oEMITenure;
            txtEMITenure.Text = oEMITenure.Tenure.ToString();
            //txtEMITenure.Enabled = false;

            btnSave.Text = "Approve";

            this.ShowDialog();
        }


        private void Save()
        {
            if (this.Tag == null)
            {
                btnSave.Text = "Add";

                EMITenure oEMITenure = new EMITenure();
                oEMITenure.Tenure = Int32.Parse(txtEMITenure.Text);
                oEMITenure.Status = (int)Dictionary.EMITenureStatus.Create;
                oEMITenure.CreateDate = DateTime.Now.Date;
                oEMITenure.CreateUserID = Utility.UserId;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oEMITenure.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You have successfully saved the EMI Tenure Month: " + oEMITenure.Tenure, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {

                EMITenure oEMITenure = (EMITenure)this.Tag;
                oEMITenure.Status = (int)Dictionary.EMITenureStatus.Approved;

                oEMITenure.Tenure = Int32.Parse(txtEMITenure.Text);

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oEMITenure.Edit();
                    Showrooms oShowrooms = new Showrooms();
                    oShowrooms.Refresh();
                    foreach (Showroom oShowroom in oShowrooms)
                    {
                        DataTran oDataTran = new DataTran();
                        oDataTran.TableName = "t_EMITenure";
                        oDataTran.DataID = Convert.ToInt32(oEMITenure.EMITenureID);
                        oDataTran.WarehouseID = oShowroom.WarehouseID;
                        oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                        oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                        oDataTran.BatchNo = 0;
                        if (oDataTran.CheckDataByWHID() == false)
                        {
                            oDataTran.AddForTDPOS();
                        }
                    }
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You have successfully approved the EMI Tenure Month", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

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
            if (string.IsNullOrEmpty(txtEMITenure.Text))
            {
                MessageBox.Show("Please insert an EMI Tenure", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEMITenure.Focus();
                return false;
            }

            int number;
            if (int.TryParse(txtEMITenure.Text, out number))
            {
                if (number <= 0)
                {
                    MessageBox.Show("EMI Tenure Month can't be zero", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtEMITenure.Focus();
                    return false;
                }
            }


            EMITenure oEMITenure = new EMITenure();
            oEMITenure.Tenure = Int32.Parse(txtEMITenure.Text);
            checkDuplicateValue = oEMITenure.CheckDuplicateData();

            if (checkDuplicateValue == "Yes" && this.Tag == null)
            {
                MessageBox.Show("EMI Tenure Month already exists", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEMITenure.Focus();
                return false;
            }

            
            return true;

        }

        private void txtEMITenure_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            //    (e.KeyChar != '.'))
            //{
            //    e.Handled = true;
            //}

            //// only allow one decimal point
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
        }

        private void frmEMITenure_Load(object sender, EventArgs e)
        {

        }
    }
}

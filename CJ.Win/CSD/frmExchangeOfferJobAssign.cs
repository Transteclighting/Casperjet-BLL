using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;

namespace CJ.Win.CSD
{
    public partial class frmExchangeOfferJobAssign : Form
    {
        ExchangeOfferVenders _oExchangeOfferVenders;
        int nJobID = 0;
        ExchangeOfferJob _oExchangeOfferJob;
        int _nType = 0;
        int nAssignVenderID = 0;

        public frmExchangeOfferJobAssign(int nType)
        {
            InitializeComponent();
            _nType = nType;
        }
        public void ShowDialog(ExchangeOfferJob oExchangeOfferJob)
        {
            this.Tag = oExchangeOfferJob;
            DBController.Instance.OpenNewConnection();
            if (_nType == (int)Dictionary.ExchangeOfferStatus.Assign)
            {
                LoadCombos();
                lblVenderName.Visible = true;
                lblAssignDate.Visible = true;
                cmbVenderName.Visible = true;
                dtAssignDate.Visible = true;
                dtVisitDate.Visible = true;
                label8lblExpvisitDate.Visible = true;
                txtCancelNote.Visible = false;
                lblCancelNote.Visible = false;
                btnSave.Text = "Assign";
                btnSave.ForeColor = Color.Green;
            }
            else if (_nType == (int)Dictionary.ExchangeOfferStatus.Cancel)
            {
                lblVenderName.Visible = false;
                lblAssignDate.Visible = false;
                cmbVenderName.Visible = false;
                dtAssignDate.Visible = false;
                dtVisitDate.Visible = false;
                label8lblExpvisitDate.Visible = false;
                txtCancelNote.Visible = true;
                lblCancelNote.Visible = true;
                btnSave.Text = "Cancel";
                btnSave.ForeColor = Color.Red;
            }

            nJobID = oExchangeOfferJob.JobID;
            nAssignVenderID = oExchangeOfferJob.AssignedVenderID;
            lblJobNo.Text = oExchangeOfferJob.JobNo;
            lblContactMode.Text = oExchangeOfferJob.ContactModeName;
            lblCustomerName.Text = oExchangeOfferJob.CustomerName;
            lblContactDate.Text = oExchangeOfferJob.ContactDate.ToString("dd-MMM-yyyy");
            lblAddress.Text = oExchangeOfferJob.Address;
            lblContactNo.Text = oExchangeOfferJob.ContactNo;
            lblEmail.Text = oExchangeOfferJob.Email;
            oExchangeOfferJob.GetExchengedItem(nJobID);


            foreach (ExchangeOfferJobDetail oExchangeOfferJobDetail in oExchangeOfferJob)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvExchangedProduct);
                oRow.Cells[0].Value = oExchangeOfferJobDetail.ProductTypeName.ToString();
                oRow.Cells[1].Value = oExchangeOfferJobDetail.ProductDetail.ToString();
                oRow.Cells[2].Value = oExchangeOfferJobDetail.ProductSize.ToString();
                oRow.Cells[3].Value = oExchangeOfferJobDetail.BrandName.ToString();
                oRow.Cells[4].Value = oExchangeOfferJobDetail.HaveRemort.ToString();
                oRow.Cells[5].Value = oExchangeOfferJobDetail.ConditionName.ToString();
                oRow.Cells[6].Value = oExchangeOfferJobDetail.Quantity.ToString();
                dgvExchangedProduct.Rows.Add(oRow);

            }
            
            this.ShowDialog();
        }

        private bool UIValidation()
        {

            if (_nType == (int)Dictionary.ExchangeOfferStatus.Assign)
            {
                if (cmbVenderName.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select a Vender", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbVenderName.Focus();
                    return false;
                }
            }
            else if (_nType == (int)Dictionary.ExchangeOfferStatus.Cancel)
            {
                if (txtCancelNote.Text == "")
                {
                    MessageBox.Show("Please Enter Cancel Reason", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCancelNote.Focus();
                    return false;
                }
            }

            return true;
        }

        public void LoadCombos()
        {
            DBController.Instance.OpenNewConnection();
            /************Vender****************/
            _oExchangeOfferVenders = new ExchangeOfferVenders();
            _oExchangeOfferVenders.RefreshforCombo();
            cmbVenderName.Items.Clear();
            cmbVenderName.Items.Add("--Select Vender Name--");
            foreach (ExchangeOfferVender oExchangeOfferVender in _oExchangeOfferVenders)
            {
                cmbVenderName.Items.Add(oExchangeOfferVender.Name);
            }
            cmbVenderName.SelectedIndex = 0;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                _oExchangeOfferJob = new ExchangeOfferJob();
                _oExchangeOfferJob.JobID = nJobID;

                if (_nType == (int)Dictionary.ExchangeOfferStatus.Assign)
                {
                    _oExchangeOfferJob.Status = (int)Dictionary.ExchangeOfferStatus.Assign;
                    _oExchangeOfferJob.AssignedVenderID = _oExchangeOfferVenders[cmbVenderName.SelectedIndex - 1].VenderID;
                    _oExchangeOfferJob.ParentCustomerID = _oExchangeOfferVenders[cmbVenderName.SelectedIndex - 1].ParentCustomerID;
                    _oExchangeOfferJob.AssignDate = dtAssignDate.Value.Date;
                    _oExchangeOfferJob.ExpectedVisitDate = dtVisitDate.Value.Date;
                    _oExchangeOfferJob.ExpectedVisitDate = dtVisitDate.Value.Date;
                }
                else if (_nType == (int)Dictionary.ExchangeOfferStatus.Cancel)
                {
                    _oExchangeOfferJob.CancelDate = DateTime.Now.Date;
                    _oExchangeOfferJob.CancelNote = txtCancelNote.Text;
                    _oExchangeOfferJob.Status = (int)Dictionary.ExchangeOfferStatus.Cancel;
                }

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    if (_nType == (int)Dictionary.ExchangeOfferStatus.Assign)
                    {
                        _oExchangeOfferJob.AssignJob();
                    }
                    else if (_nType == (int)Dictionary.ExchangeOfferStatus.Cancel)
                    {
                        _oExchangeOfferJob.CancelJob();
                    }

                    DataTran oDataTran = new DataTran();
                    oDataTran.TableName = "t_ExchangeOfferJob";
                    oDataTran.DataID = Convert.ToInt32(_oExchangeOfferJob.JobID);
                    if (_nType == (int)Dictionary.ExchangeOfferStatus.Assign)
                    {
                        oDataTran.WarehouseID = _oExchangeOfferVenders[cmbVenderName.SelectedIndex - 1].WarehouseID;
                        oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                    }
                    else if (_nType == (int)Dictionary.ExchangeOfferStatus.Cancel)
                    {
                        ExchangeOfferVender oVender = new ExchangeOfferVender();
                        oVender.GetWHID(nJobID);
                        oDataTran.WarehouseID = oVender.WarehouseID;
                        oDataTran.TransferType = (int)Dictionary.DataTransferType.Edit;
                    }
                    oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                    oDataTran.BatchNo = 0;

                    if (oDataTran.CheckData() == false)
                    {
                        oDataTran.AddForTDPOS();
                    }


                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Save Successfully ", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

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

        private void frmExchangeOfferJobAssign_Load(object sender, EventArgs e)
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.Accounts
{
    public partial class frmOutletExpenses : Form
    {
        Showrooms _oShowrooms;
        Showroom _oShowroom;
        int nID = 0;
        int nWHID = 0;
        public frmOutletExpenses()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void ShowDialog(Showroom oShowroom)
        {
            this.Tag = oShowroom;
            LoadCombo();
            nWHID = 0;
            nWHID = oShowroom.WarehouseID;
            int nOutletIndex = 0;
            nOutletIndex = _oShowrooms.GetIndexWHID(nWHID);
            cmbOutlet.SelectedIndex = nOutletIndex + 1;
            cmbOutlet.Enabled = false;

            oShowroom.GetOutletExpensesForEdit(nWHID);
            {
                txtMSpace.Text = oShowroom.Space.ToString();
                txtMRatePerSqFeet.Text = oShowroom.RatePerSquareFeet.ToString();
                txtMVAT.Text = oShowroom.Vat.ToString();
                txtMAdvance.Text = oShowroom.AdvanceAmount.ToString();
                dtMAgreementStartDate.Value = oShowroom.AgreementStartDate.Date;
                dtUpcomingRenewalDate.Value = oShowroom.AgreementUpcomingRenewalDate.Date;
            }
            Showrooms oExItem = new Showrooms();
            oExItem.GetOutletExpenseForEdit(nWHID);

            foreach (Showroom oShowroomItem in oExItem)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLineItem);
                oRow.Cells[0].Value = oShowroomItem.OutletName.ToString();
                oRow.Cells[1].Value = oShowroomItem.Space.ToString();
                oRow.Cells[2].Value = oShowroomItem.RatePerSquareFeet.ToString();
                oRow.Cells[3].Value = oShowroomItem.Vat.ToString();
                oRow.Cells[4].Value = oShowroomItem.AdvanceAmount.ToString();
                oRow.Cells[5].Value = oShowroomItem.AgreementStartDate;
                oRow.Cells[6].Value = oShowroomItem.AgreementUpcomingRenewalDate;

                dgvLineItem.Rows.Add(oRow);

            }
            this.ShowDialog();
        }

        private void LoadCombo()
        {
            _oShowrooms = new Showrooms();
            _oShowrooms.Refresh();
            cmbOutlet.Items.Add("-- Select --");
            foreach (Showroom oShowroom in _oShowrooms)
            {
                cmbOutlet.Items.Add(oShowroom.ShowroomName + "[" + oShowroom.ShowroomCode + "]");
            }
            cmbOutlet.SelectedIndex = 0;
        }

        private bool validateUIInput()
        {
            #region Order Master Information Validation
            if (cmbOutlet.Text == "-- Select --")
            {
                MessageBox.Show("Please Select a Outlet", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (this.Tag == null)
            {
                DBController.Instance.OpenNewConnection();
                Showroom _oShowroomExpenses = new Showroom();
                int nCount = _oShowroomExpenses.GetExpensesData(_oShowrooms[cmbOutlet.SelectedIndex - 1].WarehouseID);
                if (nCount != 0)
                {
                    MessageBox.Show("Showroom expenses already set. Please select another showroom", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            #endregion

            #region Order Details Information Validation
            if (dgvLineItem.Rows.Count == 1)
            {
                ///return false;
            }
            else
            {
                foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                {
                    if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                    {
                        if (oItemRow.Cells[0].Value == "")
                        {
                            MessageBox.Show("Please enter sub warehouse name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                        if (oItemRow.Cells[1].Value == "")
                        {
                            MessageBox.Show("Please enter space value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                        if (Convert.ToDouble(oItemRow.Cells[1].Value) == 0)
                        {
                            MessageBox.Show("Space value must be > 0", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        if (oItemRow.Cells[2].Value == "")
                        {
                            MessageBox.Show("Please enter space rate", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                        if (Convert.ToDouble(oItemRow.Cells[2].Value) == 0)
                        {
                            MessageBox.Show("Space rate must be > 0", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        if (oItemRow.Cells[3].Value == "")
                        {
                            MessageBox.Show("Please enter vat amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                        if (Convert.ToDouble(oItemRow.Cells[3].Value) == 0)
                        {
                            MessageBox.Show("Vat amount must be > 0", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        if (oItemRow.Cells[4].Value == "")
                        {
                            MessageBox.Show("Please enter advance amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                        if (Convert.ToDouble(oItemRow.Cells[4].Value) == 0)
                        {
                            MessageBox.Show("Advance amount must be > 0", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                    }
                }
            }
            #endregion

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            //if (this.Tag != null)
            //{
            //    if (validateUIInput())
            //    {
            //        try
            //        {
            //            DBController.Instance.BeginNewTransaction();

            //            _oShowroom = new Showroom();
            //            _oShowroom.ID = nID;
            //            _oShowroom.OutletName = cmbOutlet.Text;
            //            _oShowroom.Type = (int)Dictionary.ShowroomWHType.MainWH;
            //            _oShowroom.WarehouseID = _oShowrooms[cmbOutlet.SelectedIndex - 1].WarehouseID;
            //            _oShowroom.Space = Convert.ToDouble(txtMSpace.Text);
            //            _oShowroom.Vat = Convert.ToDouble(txtMVAT.Text);
            //            _oShowroom.RatePerSquareFeet = Convert.ToDouble(txtMRatePerSqFeet.Text);
            //            _oShowroom.AdvanceAmount = Convert.ToDouble(txtMAdvance.Text);
            //            _oShowroom.AgreementStartDate = dtMAgreementStartDate.Value.Date;
            //            _oShowroom.AgreementUpcomingRenewalDate = dtUpcomingRenewalDate.Value.Date;
            //            _oShowroom.UpdateDate = DateTime.Now.Date;
            //            _oShowroom.UpdateUserID = Utility.UserId;
            //            _oShowroom.EditOutletExpenses();

            //            _oShowroom.Type = (int)Dictionary.ShowroomWHType.SubWH;
            //            _oShowroom.DeleteOutletExpence();
            //            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            //            {
            //                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
            //                {

            //                    Showroom _oShowroomItem = new Showroom();
            //                    _oShowroom.OutletName = oItemRow.Cells[0].Value.ToString();
            //                    _oShowroom.Space = Convert.ToDouble(oItemRow.Cells[1].Value.ToString());
            //                    _oShowroom.RatePerSquareFeet = Convert.ToDouble(oItemRow.Cells[2].Value.ToString());
            //                    _oShowroom.Vat = Convert.ToDouble(oItemRow.Cells[3].Value.ToString());
            //                    _oShowroom.AdvanceAmount = Convert.ToDouble(oItemRow.Cells[4].Value.ToString());
            //                    _oShowroom.AgreementStartDate = Convert.ToDateTime(oItemRow.Cells[5].Value.ToString());
            //                    _oShowroom.AgreementUpcomingRenewalDate = Convert.ToDateTime(oItemRow.Cells[6].Value.ToString());
            //                    _oShowroom.Type = (int)Dictionary.ShowroomWHType.MainWH;
            //                    _oShowroom.WarehouseID = _oShowrooms[cmbOutlet.SelectedIndex - 1].WarehouseID;
            //                    _oShowroom.CreateDate = DateTime.Now.Date;
            //                    _oShowroom.CreateUserID = Utility.UserId;
            //                    _oShowroom.AddOutletExpenses();

            //                }
            //            }

            //            DBController.Instance.CommitTran();
            //            MessageBox.Show("Successfully Update Showroom Expenses. Showroom:" + cmbOutlet.Text.ToString(), "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //            this.Close();
            //        }
            //        catch (Exception ex)
            //        {
            //            DBController.Instance.RollbackTransaction();
            //            MessageBox.Show("Error... " + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        }
            //    }

            //}

                if (validateUIInput())
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        _oShowroom = new Showroom();
                        _oShowroom.OutletName = cmbOutlet.Text;
                        _oShowroom.Type = (int)Dictionary.ShowroomWHType.MainWH;
                        _oShowroom.WarehouseID = _oShowrooms[cmbOutlet.SelectedIndex - 1].WarehouseID;
                        _oShowroom.Space = Convert.ToDouble(txtMSpace.Text);
                        _oShowroom.Vat = Convert.ToDouble(txtMVAT.Text);
                        _oShowroom.RatePerSquareFeet = Convert.ToDouble(txtMRatePerSqFeet.Text);
                        _oShowroom.AdvanceAmount = Convert.ToDouble(txtMAdvance.Text);
                        _oShowroom.AgreementStartDate = dtMAgreementStartDate.Value.Date;
                        _oShowroom.AgreementUpcomingRenewalDate = dtUpcomingRenewalDate.Value.Date;
                        _oShowroom.CreateDate = DateTime.Now.Date;
                        _oShowroom.CreateUserID = Utility.UserId;
                        _oShowroom.DeleteOutletExpence();
                        _oShowroom.AddOutletExpenses();

                        foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                        {
                            if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                            {

                                Showroom _oShowroomItem = new Showroom();
                                _oShowroom.OutletName = oItemRow.Cells[0].Value.ToString();
                                _oShowroom.Space = Convert.ToDouble(oItemRow.Cells[1].Value.ToString());
                                _oShowroom.RatePerSquareFeet = Convert.ToDouble(oItemRow.Cells[2].Value.ToString());
                                _oShowroom.Vat = Convert.ToDouble(oItemRow.Cells[3].Value.ToString());
                                _oShowroom.AdvanceAmount = Convert.ToDouble(oItemRow.Cells[4].Value.ToString());
                                _oShowroom.AgreementStartDate = Convert.ToDateTime(oItemRow.Cells[5].Value.ToString());
                                _oShowroom.AgreementUpcomingRenewalDate = Convert.ToDateTime(oItemRow.Cells[6].Value.ToString());
                                _oShowroom.Type = (int)Dictionary.ShowroomWHType.SubWH;
                                _oShowroom.WarehouseID = _oShowrooms[cmbOutlet.SelectedIndex - 1].WarehouseID;
                                _oShowroom.CreateDate = DateTime.Now.Date;
                                _oShowroom.CreateUserID = Utility.UserId;
                                _oShowroom.AddOutletExpenses();

                            }
                        }
                        DBController.Instance.CommitTran();
                        MessageBox.Show("Success fully Add Showroom Expenses. Showroom:" + cmbOutlet.Text.ToString(), "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();


                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }


            

        }

        private void frmOutletExpenses_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add Outlet Expenses";
                LoadCombo();

            }
            else
            {
                this.Text = "Edit Outlet Expenses";
            }
        }


    }
}
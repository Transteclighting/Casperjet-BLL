using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.CAC
{
    public partial class frmCACProjectOtherPayment : Form
    {
        CACProjectOtherPayment oCACProjectOtherPayment;
        CACProjectDetail oCACProjectDetail;
        CACProjects oCACProjects;
        Suppliers oSuppliers;
        int nProjectID = 0;
        int _nStatus = 0;
        int nID= 0;
        int nSupplierID = 0;
        double nTotalAmount = 0;
        public bool IsTrue = false;
        public frmCACProjectOtherPayment()
        {
            InitializeComponent();
        }
        public void ShowDialog(CACProject oCACProject)
        {
            this.Tag = oCACProject;
            LoadCombo();
            nProjectID = oCACProject.ProjectID;
            lblCode.Text = oCACProject.ProjectCode;
            lblName.Text = oCACProject.ProjectName;

            this.ShowDialog();
        }
        private void frmCACProjectOtherPayment_Load(object sender, EventArgs e)
        {
            LoadCombo();
        }
        private void LoadCombo()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }            
            cmbInstrument.Items.Clear();
            //cmbInstrument.Items.Add("-- All--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.InstrumentType)))
            {
                cmbInstrument.Items.Add(Enum.GetName(typeof(Dictionary.InstrumentType), GetEnum));
            }
            cmbInstrument.SelectedIndex = 0;

            oCACProjects= new CACProjects();
            oCACProjects.RefreshByCACProjectDetailsSupplier(nProjectID);
            cmbSupplier.Items.Clear();
            cmbSupplier.Items.Add("-- All--");
            foreach (CACProjectDetail oCACProjectDetail in oCACProjects)
            {
                cmbSupplier.Items.Add(oCACProjectDetail.SupplierName);
            }
            cmbSupplier.SelectedIndex = 0;
        }
        private void AddSupplierList()
        {
            DataGridViewRow oRow = new DataGridViewRow();
            oRow.CreateCells(dgvOtherPayment);
            oRow.Cells[0].Value = cmbSupplier.Text;
            oRow.Cells[1].Value = dtDate.Value;
            oRow.Cells[2].Value = txtPAmount.Text;
            oRow.Cells[3].Value = txtAmount.Text;
            oRow.Cells[4].Value = txtTotal.Text;
            oRow.Cells[5].Value = nSupplierID;
            oRow.Cells[6].Value = cmbInstrument.SelectedIndex;
            oRow.Cells[7].Value = nID;
            dgvOtherPayment.Rows.Add(oRow);
        }
        private void Clear()
        {
            cmbSupplier.SelectedIndex = 0;
            cmbInstrument.SelectedIndex = 0;
            txtAmount.Text = "";
            txtTotal.Text = "";
            txtPAmount.Text= "";

        }
        private void GetTotalAmount()
        {
            double nTotal = 0;
            double nAmount = 0;
            double nPreviousAmount = 0;
            nAmount = Convert.ToDouble(txtAmount.Text);
            nPreviousAmount = Convert.ToDouble(txtPAmount.Text);
            nTotal = nAmount + nPreviousAmount;
            txtTotal.Text = nTotal.ToString();
        }
        private void btnAddToList_Click(object sender, EventArgs e)
        {
            if (CheckUIGridViewSupplierWise())
            {
                AddSupplierList();
                Clear();
                GetTotal();
            }
        }
        private bool CheckUIGridViewSupplierWise()
        {

            if (cmbSupplier.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Supplier", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbSupplier.Focus();
                return false;
            }
            if (cmbInstrument.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select Instrument", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbInstrument.Focus();
                return false;
            }
            if (txtAmount.Text.Trim() == "")
            {
                MessageBox.Show("Please Input Value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return false;
            }            
            try
            {
                Convert.ToInt32(txtAmount.Text.Trim());
            }
            catch
            {
                MessageBox.Show("Please Enter Valid Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return false;
            }
            return true;
        }
        private void ADDCACProjectOtherPayment(CACProjectOtherPayment CACProjectOtherPayment)
        {
            foreach (DataGridViewRow oItemRow in dgvOtherPayment.Rows)
            {
                if (oItemRow.Index < dgvOtherPayment.Rows.Count)
                {
                    CACProjectOtherPayment = new CACProjectOtherPayment();
                    CACProjectOtherPayment.ProjectID = nProjectID;
                    CACProjectOtherPayment.SupplierID = int.Parse(oItemRow.Cells[5].Value.ToString());
                    CACProjectOtherPayment.InstrumentType = int.Parse(oItemRow.Cells[6].Value.ToString());
                    CACProjectOtherPayment.CreateDate = dtDate.Value;
                    CACProjectOtherPayment.PaymentAmount = int.Parse(oItemRow.Cells[3].Value.ToString());
                    CACProjectOtherPayment.Add();

                }
            }

        }
        private bool UIvalidation()
        {
            #region Transaction Details Information Validation
            if (dgvOtherPayment.Rows.Count == 0)
            {
                return false;
            }
            foreach (DataGridViewRow oItemRow in dgvOtherPayment.Rows)
            {
                if (oItemRow.Index < dgvOtherPayment.Rows.Count)
                {
                    if (nTotalAmount < int.Parse(oItemRow.Cells[4].Value.ToString()))
                    {
                        MessageBox.Show("Given amount not grater than supplier amount ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }

            //if (nTotalAmount <Convert.ToDouble(txtTotal.Text))
            //{
            //    MessageBox.Show("Given amount not grater than supplier amount ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}

            #endregion
            return true;
        }
        private void Save()
        {
            if (UIvalidation())
            {
                CACProjectOtherPayment oCACProjectOtherPayment = new CACProjectOtherPayment();
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    //oCACProjectOtherPayment.DeleteByOtherPayment(nProjectID);
                    ADDCACProjectOtherPayment(oCACProjectOtherPayment);
                    foreach (DataGridViewRow oItemRow in dgvOtherPayment.Rows)
                    {
                        if (oItemRow.Index < dgvOtherPayment.Rows.Count)
                        {
                            CACProjectDetail oCACProjectDetail = new CACProjectDetail();
                            oCACProjectDetail.ID = int.Parse(oItemRow.Cells[7].Value.ToString());
                            oCACProjectDetail.ProjectID = nProjectID;
                            oCACProjectDetail.OtherPayment= int.Parse(oItemRow.Cells[3].Value.ToString());
                            oCACProjectDetail.UpdateByOtherPayment(nProjectID, nID);
                        }
                    }
                    CACProject oCACProject = new CACProject();
                    oCACProject.TotalOtherPayment = Convert.ToDouble(txtTotalAmount.Text);
                    oCACProject.UpdateByOtherPaymentwise(nProjectID);
                    DBController.Instance.CommitTransaction();
                    this.Close();

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

                MessageBox.Show("Saved successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            IsTrue = true;
        }
        private void GetTotal()
        {
            txtTotalAmount.Text = "0.00";

            foreach (DataGridViewRow oRow in dgvOtherPayment.Rows)
            {
                if (oRow.Cells[4].Value != null)
                {

                    txtTotalAmount.Text = Convert.ToDouble(Convert.ToDouble(txtTotalAmount.Text) + Convert.ToDouble(oRow.Cells[4].Value.ToString())).ToString();

                }
            }

        }
        private void refreshRow(int nRowIndex, int nColumnIndex)
        {

            if (nColumnIndex == 4)
            {
                if (dgvOtherPayment.Rows[nRowIndex].Cells[4].Value.ToString() != null)
                {
                    try
                    {
                        dgvOtherPayment.Rows[nRowIndex].Cells[4].Value = Convert.ToDouble(dgvOtherPayment.Rows[nRowIndex].Cells[4].Value.ToString());

                    }
                    catch
                    {
                        //MessageBox.Show("");

                    }
                }
                GetTotal();
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtAmount_TextChanged(object sender, EventArgs e)
        {
            if (txtPAmount.Text.Trim() != string.Empty && txtAmount.Text.Trim() != string.Empty)
            {
                GetTotalAmount();
            }
            else
            {
                txtAmount.Text = "";
            }
        }

        private void cmbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSupplier.SelectedIndex > 0)
            {
                oCACProjects = new CACProjects();
                oCACProjects.RefreshByCACProjectOtherPayment(nProjectID,cmbSupplier.Text);
                foreach (CACProjectDetail oCACProjectDetail in oCACProjects)
                {
                    txtPAmount.Text = oCACProjectDetail.OtherPayment.ToString();
                    nID = oCACProjectDetail.ID;
                    nSupplierID = Convert.ToInt32(oCACProjectDetail.SupplierID);
                    nTotalAmount = oCACProjectDetail.Amount;
                }
                //cmbSupplier.SelectedIndex = 0;
            }
        }

        private void dgvOtherPayment_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            {
                refreshRow(e.RowIndex, e.ColumnIndex);
            }
        }

        private void dgvOtherPayment_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            GetTotal();
        }
    }
}

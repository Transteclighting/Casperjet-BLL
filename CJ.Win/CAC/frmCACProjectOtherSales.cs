using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class frmCACProjectOtherSales : Form
    {
        CACProjectInvoiceWise oCACProjectInvoiceWise;
        CACProjectInvoiceWises oCACProjectInvoiceWises;
        CACProjectDetail oCACProjectDetail;
        int nProjectID = 0;
        int _nStatus = 0;
        public bool IsTrue = false;
        double dTotal = 0.0;
        public frmCACProjectOtherSales()
        {
            InitializeComponent();
        }
        public void ShowDialog(CACProject oCACProject)
        {
            this.Tag = oCACProject;
            nProjectID = oCACProject.ProjectID;
            lblCode.Text = oCACProject.ProjectCode;
            lblName.Text = oCACProject.ProjectName;
            CACProjects oCACProjects = new CACProjects();
            oCACProjects.RefreshByCACProjectDetailsSupplier(oCACProject.ProjectID);
            foreach (CACProjectDetail oItem in oCACProjects)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvSupplier);
                oRow.Cells[0].Value = oItem.SupplierName.ToString();
                oRow.Cells[1].Value = oItem.Amount.ToString();
                oRow.Cells[2].Value = oItem.OtherSales.ToString();
                oRow.Cells[3].Value = int.Parse(oRow.Cells[1].Value.ToString()) - int.Parse(oRow.Cells[2].Value.ToString());
                oRow.Cells[4].Value = oItem.SupplierID.ToString();
                oRow.Cells[5].Value = oItem.ID.ToString();
                dTotal += Convert.ToDouble(oRow.Cells[2].Value.ToString());
                dgvSupplier.Rows.Add(oRow);
            }
            this.ShowDialog();
        }
        private void frmCACProjectOtherSales_Load(object sender, EventArgs e)
        {
           GetTotal();
            LoadCombo();
        }
        private void LoadCombo()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            oCACProjectInvoiceWises = new CACProjectInvoiceWises();
            oCACProjectInvoiceWises.Refresh(nProjectID);
            cmbInvoiceMap.Items.Clear();
            cmbInvoiceMap.Items.Add("-- All--");
            foreach (CACProjectInvoiceWise oCACProjectInvoiceWise in oCACProjectInvoiceWises)
            {
                cmbInvoiceMap.Items.Add(oCACProjectInvoiceWise.InvoiceNo);
            }
            cmbInvoiceMap.SelectedIndex = 0;
        }
        private void ADDCACProjectOtherSales(CACProjectInvoiceWise oCACProjectInvoiceWise)
        {
            foreach (DataGridViewRow oItemRow in dgvSupplier.Rows)
            {
                if (oItemRow.Index < dgvSupplier.Rows.Count)
                {
                    oCACProjectInvoiceWise = new CACProjectInvoiceWise();
                    oCACProjectInvoiceWise.ProjectID = nProjectID;
                    oCACProjectInvoiceWise.SupplierID = int.Parse(oItemRow.Cells[4].Value.ToString());
                    oCACProjectInvoiceWise.InvoiceDate = dtDate.Value;
                    oCACProjectInvoiceWise.Amount = int.Parse(oItemRow.Cells[3].Value.ToString());
                    oCACProjectInvoiceWise.Type = (int)Dictionary.CACProjectInvoiceType.Others;
                    oCACProjectInvoiceWise.MappingInvoiceNo = cmbInvoiceMap.Text;
                    oCACProjectInvoiceWise.Remarks = txtRemarks.Text;
                    oCACProjectInvoiceWise.Add();

                }
            }

        }
        private bool UIvalidation()
        {
            #region Transaction Details Information Validation
            if (cmbInvoiceMap.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Invoice", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbInvoiceMap.Focus();
                return false;
            }            
            if (dgvSupplier.Rows.Count == 0)
            {
                return false;
            }
            foreach (DataGridViewRow oItemRow in dgvSupplier.Rows)
            {
                if (int.Parse(oItemRow.Cells[1].Value.ToString()) < int.Parse(oItemRow.Cells[3].Value.ToString()))
                {
                    MessageBox.Show("Given amount not grater than supplier amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (int.Parse(oItemRow.Cells[1].Value.ToString()) < int.Parse(oItemRow.Cells[2].Value.ToString())+ int.Parse(oItemRow.Cells[3].Value.ToString()))
                {
                    MessageBox.Show("Given amount not grater than supplier amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            if (Convert.ToDouble(txtTotalAmount.Text.Trim()) == 0 || Convert.ToDouble(txtTotalAmount.Text.Trim()) < 0)
            {
                MessageBox.Show("Can't give Zero/Negative value ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTotalAmount.Focus();
                return false;
            }
            #endregion
            return true;
        }
        private void Save()
        {
            if (UIvalidation())
            {
                CACProjectInvoiceWise oCACProjectInvoiceWise = new CACProjectInvoiceWise();
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    //oCACProjectInvoiceWise.DeleteByOtherSales(nProjectID);
                    ADDCACProjectOtherSales(oCACProjectInvoiceWise);                    
                    foreach (DataGridViewRow oItemRow in dgvSupplier.Rows)
                    {

                        if (oItemRow.Index < dgvSupplier.Rows.Count)
                        {
                            CACProjectDetail oCACProjectDetail = new CACProjectDetail();
                            oCACProjectDetail.ID = int.Parse(oItemRow.Cells[5].Value.ToString());
                            oCACProjectDetail.ProjectID = nProjectID;
                            oCACProjectDetail.OtherSales = int.Parse(oItemRow.Cells[3].Value.ToString());
                            oCACProjectDetail.UpdateBySupplier(nProjectID, oCACProjectInvoiceWise.ID);
                        }
                    }
                    CACProject oCACProject = new CACProject();
                    oCACProject.InvoiceAmount = Convert.ToDouble(txtTotalAmount.Text);
                    oCACProject.UpdateByInvoiceWise(nProjectID);
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

            foreach (DataGridViewRow oRow in dgvSupplier.Rows)
            {
                if (oRow.Cells[3].Value != null)
                {

                    txtTotalAmount.Text = Convert.ToDouble(Convert.ToDouble(txtTotalAmount.Text) + Convert.ToDouble(oRow.Cells[3].Value.ToString())).ToString();

                }
            }

        }
        private void refreshRow(int nRowIndex, int nColumnIndex)
        {

            if (nColumnIndex == 3)
            {
                if (dgvSupplier.Rows[nRowIndex].Cells[3].Value.ToString() != null)
                {
                    try
                    {
                        dgvSupplier.Rows[nRowIndex].Cells[3].Value = Convert.ToDouble(dgvSupplier.Rows[nRowIndex].Cells[3].Value.ToString());

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
        private void dgvSupplier_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            {
                refreshRow(e.RowIndex, e.ColumnIndex);
            }
        }

        private void dgvSupplier_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            GetTotal();
        }       
    }
}

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
    public partial class frmCACProjectCollectionSchedule : Form
    {

        CACProjectCollectionSchedule oCACProjectCollectionSchedule;

        int nProjectID = 0;
        double ntotalAmount = 0;

        public bool _bActionSave = false;


        public frmCACProjectCollectionSchedule()
        {
            InitializeComponent();
        }

        private void frmCACProjectCollectionSchedule_Load(object sender, EventArgs e)
        {

        }

        public void ShowDialog(CACProject oCACProject)
        {
            this.Tag = oCACProject;
            nProjectID = oCACProject.ProjectID;
            ntotalAmount = oCACProject.TotalAmount;
            this.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            _bActionSave = true;
        }



        private void Save()
        {
            if (validation())
            {
                if (ntotalAmount == Convert.ToDouble(Convert.ToDouble(txtPaymentMethodTotalAmt.Text)))
                {

                    CACProjectCollectionSchedule oCACProjectCollectionSchedule = new CACProjectCollectionSchedule();

                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        ADDCACPaymetMethods(oCACProjectCollectionSchedule);
                        DBController.Instance.CommitTransaction();
                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }

                    MessageBox.Show("Your data has been saved successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else
                {
                    MessageBox.Show("Total Amount Does not Match! Please make it exact first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
        }                                               
        private void ADDCACPaymetMethods(CACProjectCollectionSchedule _oCACProjectCollectionSchedule)
        {
            foreach (DataGridViewRow oItemRow in dgvPaymentMethod.Rows)
            {
                if (oItemRow.Index < dgvPaymentMethod.Rows.Count)
                {
                    _oCACProjectCollectionSchedule = new CACProjectCollectionSchedule();
                    _oCACProjectCollectionSchedule.ProjectID = nProjectID;
                    _oCACProjectCollectionSchedule.PaymentDate = Convert.ToDateTime(oItemRow.Cells[0].Value.ToString());
                    _oCACProjectCollectionSchedule.Description = oItemRow.Cells[1].Value.ToString();
                    _oCACProjectCollectionSchedule.CompletePercentage = int.Parse(oItemRow.Cells[2].Value.ToString());
                    _oCACProjectCollectionSchedule.Amount = int.Parse(oItemRow.Cells[3].Value.ToString());
                    _oCACProjectCollectionSchedule.CreateUserID = Utility.UserId;
                    _oCACProjectCollectionSchedule.CreateDate = DateTime.Now;
                    _oCACProjectCollectionSchedule.Add();

                }
            }

        }

        private void btnAddtolist_Click(object sender, EventArgs e)
        {
            if (CheckUIGridViewPaymentMethod())
            {
                AddProductList();
                ClearForPaymentMethod();
                GetTotal();
            }
        }


        private void GetTotal()
        {
            txtPaymentMethodTotalAmt.Text = "0.00";

            foreach (DataGridViewRow oRow in dgvPaymentMethod.Rows)
            {
                if (oRow.Cells[3].Value != null)
                {

                    txtPaymentMethodTotalAmt.Text = Convert.ToDouble(Convert.ToDouble(txtPaymentMethodTotalAmt.Text) + Convert.ToDouble(oRow.Cells[3].Value.ToString())).ToString();

                }
            }

        }

        private void ClearForPaymentMethod()
        {
            txtPaymentDescription.Text = "";
            txtCompletePer.Text = "";
            txtPaymentMethodValue.Text = "";
            dtDate.Value = DateTime.Now;
        }

        private void AddProductList()
        {
            DataGridViewRow oRow = new DataGridViewRow();
            oRow.CreateCells(dgvPaymentMethod);
            oRow.Cells[0].Value = dtDate.Value.Date;
            oRow.Cells[1].Value = txtPaymentDescription.Text.ToString();
            oRow.Cells[2].Value = txtCompletePer.Text;
            oRow.Cells[3].Value = txtPaymentMethodValue.Text.ToString();
            dgvPaymentMethod.Rows.Add(oRow);
        }


        private bool CheckUIGridViewPaymentMethod()
        {
            if (txtPaymentDescription.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Description", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPaymentDescription.Focus();
                return false;
            }
            if (txtCompletePer.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Complete Percentage", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCompletePer.Focus();
                return false;
            }


            if (txtPaymentMethodValue.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Valid Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPaymentMethodValue.Focus();
                return false;
            }

            return true;
        }



        private bool validation()
        {
            if (Convert.ToDouble(txtPaymentMethodTotalAmt.Text.Trim()) <= 0)
            {
                MessageBox.Show("Please Add Payment Details to the List First", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPaymentMethodTotalAmt.Focus();
                return false;
            }
            //if (ntotalAmount!= Convert.ToDouble(txtPaymentMethodTotalAmt.Text.Trim()))
            //{
            //    MessageBox.Show("Total Amount Does not Match! Please make it exact first", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtPaymentMethodTotalAmt.Focus();
            //    return false;
            //}

            return true;
        }

        private void txtCompletePer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtPaymentMethodValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void dgvPaymentMethod_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            GetTotal(); 
        }

        private void txtPaymentMethodTotalAmt_TextChanged(object sender, EventArgs e)
        {


        }

        private void frmCACProjectCollectionSchedule_Load_1(object sender, EventArgs e)
        {

        }
    }
}

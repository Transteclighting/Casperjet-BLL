using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using CJ.Class;
using CJ.Class.POS;
using CJ.Class.Library;

namespace CJ.Win.Ecommerce
{
    public partial class frmSalesLeadMgtQuestions : Form
    {

        SalesLead _oSalesLead;
        SalesLeadMgtQuestionStatuss oSalesLeadMgtQuestionStatuss;
        SalesLeadMgtQuestionStatuss _oSalesLeadMgtQuestionStatuss;
        SalesLeadManagementQCQuestion _oSalesLeadMgtQCQuestion;
        public bool _IsTrue = false;

        int salesLeadID = 0;
        int isValidLead = 0;

        public frmSalesLeadMgtQuestions()
        {
            InitializeComponent();
        }


        public void ShowDialog(SalesLead oSalesLead)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            this.Tag = oSalesLead;

                lblProductCode.Text = oSalesLead.ProductCode;
                lblProductName.Text = oSalesLead.ProductName;
                lblActivation.Text = oSalesLead.ActivationName;
                lblLeadSource.Text = Enum.GetName(typeof(Dictionary.LeadSource), oSalesLead.LeadSource);

                lblLeadNo.Text = oSalesLead.LeadNo;
                salesLeadID = oSalesLead.LeadID;
                lblLeadDate.Text = oSalesLead.LeadDate.Date.ToString();
                lblLeadType.Text = Enum.GetName(typeof(Dictionary.CustomerTypeSalesLead), oSalesLead.CustomerType);
                lblCompanyName.Text = oSalesLead.CompanyName.ToString();
                lblName.Text = oSalesLead.Name.ToString();
                lblCompanyName.Text = oSalesLead.CompanyName.ToString();
                txtContact.Text = oSalesLead.ContactNo.ToString();
                lblAddress.Text = oSalesLead.Address.ToString();
                lblLeadAmt.Text = oSalesLead.LeadAmount.ToString();
                lblLeadQty.Text = oSalesLead.Qty.ToString();
                lblOutlet.Text = oSalesLead.ShowroomCode.ToString();
                lblAssigendPerson.Text = oSalesLead.SalesPerson.ToString();
                lblInvoiceNo.Text = oSalesLead.InvoiceNo.ToString();

            this.ShowDialog();

        }


        private void frmSalesLeadMgtQuestions_Load(object sender, EventArgs e)
        {
            SalesLeadMgtQCQuestions _oQuestion = new SalesLeadMgtQCQuestions();
            _oQuestion.GetQuestions();
            foreach (SalesLeadManagementQCQuestion oSalesLeadMgtQCQuestion in _oQuestion)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLineItem);
                oRow.Cells[0].Value = oSalesLeadMgtQCQuestion.Question.ToString();
                oRow.Cells[1].Value = oSalesLeadMgtQCQuestion.QuestionID.ToString();
                dgvLineItem.Rows.Add(oRow);
            }

            Utilities oSalesLeadMark = new Utilities();
            oSalesLeadMark.SalesLeadMark();
            DataGridViewComboBoxColumn ColumnItem3 = new DataGridViewComboBoxColumn();
            ColumnItem3.DataPropertyName = "Mark";
            ColumnItem3.HeaderText = "Mark";
            ColumnItem3.Width = 120;
            ColumnItem3.DataSource = oSalesLeadMark;
            ColumnItem3.ValueMember = "SatusId";
            ColumnItem3.DisplayMember = "Satus";
            dgvLineItem.Columns.Add(ColumnItem3);

            DataGridViewTextBoxColumn ColumnItem4 = new DataGridViewTextBoxColumn();
            ColumnItem4.DataPropertyName = "Remarks";
            ColumnItem4.HeaderText = "Remarks";
            ColumnItem4.Width = 420;
            dgvLineItem.Columns.Add(ColumnItem4);

            LoadCombo();
        }

        private void LoadCombo()
        {
            DBController.Instance.OpenNewConnection();

            oSalesLeadMgtQuestionStatuss = new SalesLeadMgtQuestionStatuss();

            oSalesLeadMgtQuestionStatuss.GetLeadStatus();
            cmbLeadStatus.Items.Clear();
            cmbLeadStatus.Items.Add("<Select Lead Status>");
            foreach (SalesLeadMgtQuestionStatus oSalesLeadMgtQuestionStatus in oSalesLeadMgtQuestionStatuss)
            {
                cmbLeadStatus.Items.Add(oSalesLeadMgtQuestionStatus.Name);
            }
            cmbLeadStatus.SelectedIndex = 0;

        }

        public bool ValidateUIInput()
        {
            if (cmbLeadStatus.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Lead Status", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbReason.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select a Reason", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    if (oItemRow.Cells[2].Value == null)
                    {
                        MessageBox.Show("Please Input Mark", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateUIInput())
            {

                _IsTrue = true;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oSalesLeadMgtQCQuestion = new SalesLeadManagementQCQuestion();

                    SalesLeadMgtQC _oSalesLeadMgtQC = new SalesLeadMgtQC();

                    _oSalesLeadMgtQC.LeadID = salesLeadID;

                    _oSalesLeadMgtQC.Status = oSalesLeadMgtQuestionStatuss[cmbLeadStatus.SelectedIndex - 1].ID;

                    //_oSalesLeadMgtQC.Status = cmbLeadStatus.SelectedIndex -1;

                    //isValidLead = cmbLeadStatus.SelectedIndex - 1;
                    isValidLead = oSalesLeadMgtQuestionStatuss[cmbLeadStatus.SelectedIndex - 1].ID;

                    if (isValidLead < 2)

                        _oSalesLeadMgtQC.IsValidLead = 1;
                    else
                        _oSalesLeadMgtQC.IsValidLead = 0;


                    _oSalesLeadMgtQC.Reason = _oSalesLeadMgtQuestionStatuss[cmbReason.SelectedIndex - 1].ID;


                    foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                    {
                        if (oItemRow.Index < dgvLineItem.Rows.Count)
                        {
                            SalesLeadManagementQC oSalesLeadManagementQC = new SalesLeadManagementQC();

                            oSalesLeadManagementQC.QuestionID = Convert.ToInt32(oItemRow.Cells[1].Value.ToString());


                            try
                            {
                                oSalesLeadManagementQC.Mark = Convert.ToInt32(oItemRow.Cells[2].Value.ToString());
                            }
                            catch
                            {
                                oSalesLeadManagementQC.Mark = 0;
                            }

                            try
                            {
                                oSalesLeadManagementQC.Remarks = oItemRow.Cells[3].Value.ToString();
                            }
                            catch
                            {
                                oSalesLeadManagementQC.Remarks = "";
                            }


                            _oSalesLeadMgtQC.Add(oSalesLeadManagementQC);

                        }
                    }

                    _oSalesLeadMgtQC.UpdateLeadQCData();

                    DBController.Instance.CommitTransaction();

                    MessageBox.Show("You Have Successfully Added Data", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void cmbLeadStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            int leadStatus = 0;
            cmbReason.Items.Clear();
            cmbReason.Items.Add("Select a Reason");
            leadStatus = cmbLeadStatus.SelectedIndex;
            if (leadStatus > 0)
            {
                 _oSalesLeadMgtQuestionStatuss = new SalesLeadMgtQuestionStatuss();

                _oSalesLeadMgtQuestionStatuss.GetLeadReason(oSalesLeadMgtQuestionStatuss[cmbLeadStatus.SelectedIndex - 1].ID);

                foreach (SalesLeadMgtQuestionStatus oSalesLeadMgtQuestionStatus in _oSalesLeadMgtQuestionStatuss)
                {
                    cmbReason.Items.Add(oSalesLeadMgtQuestionStatus.Name);
                }
            }
            cmbReason.SelectedIndex = 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class.CSD;
using CJ.Class;
using System.Collections;

namespace CJ.Win.CSD.Reception
{
    public partial class frmMAGWiseQuestioner : Form
    {

        public DSInvoiceCalls _oDSInvoiceCalls;
        int _nMAGID = 0;
        int _nProductID = 0;
        string _sProductSerial = "";
        public string _sMarks = "";

        public frmMAGWiseQuestioner()
        {
            InitializeComponent();
        }

        public void ShowDialog(DSInvoiceCalls oDSInvoiceCalls, int nMAGID, int nProductID, string sProductName, string sMAGName, string sProductSerial,int nSalesType)
        {
            _oDSInvoiceCalls = new DSInvoiceCalls();
            _oDSInvoiceCalls = oDSInvoiceCalls;

            this.Text = "Questioner";
            _nProductID = nProductID;
            _nMAGID = nMAGID;
            _sProductSerial = sProductSerial;
            lblProductName.Text = sProductName;
            lblMAGNAme.Text = sMAGName;
            lblBarcode.Text = _sProductSerial;

            CJ.Class.DBController.Instance.OpenNewConnection();
            CSDCustomerSatisfaction _oQuestion = new CSDCustomerSatisfaction();
            _oQuestion.GetQuestionsByMAG(nMAGID, nSalesType);
            foreach (CSDCustomerSatisfactionDetail oCSDCustomerSatisfactionDetail in _oQuestion)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLineItem);
                oRow.Cells[0].Value = oCSDCustomerSatisfactionDetail.Questions.ToString();
                oRow.Cells[1].Value = oCSDCustomerSatisfactionDetail.ID.ToString();

                ArrayList StingList = new ArrayList();
                CSDCustomerSatisfaction _oMark = new CSDCustomerSatisfaction();
                _oMark.GetMarklistbyQuestionsID(oCSDCustomerSatisfactionDetail.ID);
                foreach (CSDCustomerSatisfactionDetail oMark in _oMark)
                {
                    StingList.Add(oMark.Description);
                }
                var CellSample = new DataGridViewComboBoxCell();
                CellSample.DataSource = StingList;


                oRow.Cells[2] = CellSample;
                dgvLineItem.Rows.Add(oRow);
            }

            //Utilities oCSDMark = new Utilities();
            //oCSDMark.CSDMark();
            //DataGridViewComboBoxColumn ColumnItem3 = new DataGridViewComboBoxColumn();
            //ColumnItem3.DataPropertyName = "Mark";
            //ColumnItem3.HeaderText = "Mark";
            //ColumnItem3.Width = 120;
            //ColumnItem3.DataSource = oCSDMark;
            //ColumnItem3.ValueMember = "SatusId";
            //ColumnItem3.DisplayMember = "Satus";
            //dgvLineItem.Columns.Add(ColumnItem3);




            this.ShowDialog();
        }


        private void CreateCustomComboBoxDataSouce(int row, string texst, int[] data) //row index        ,and two parameters
        {
            dgvLineItem.Rows.Add(texst);
            DataGridViewComboBoxCell comboCell = dgvLineItem[1, row] as DataGridViewComboBoxCell;
            comboCell.DataSource = new BindingSource(data, null);
        }
        private bool validateUIInput()
        {
            #region ValidInput
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    if (oItemRow.Cells[2].Value == null)
                    {
                        MessageBox.Show("Please Input Question Mark", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    } 
                }
            }
            #endregion

            return true;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                this.Close();
            }
            
        }
        private void Save()
        {
            int nBOMQty = 0;
            _oDSInvoiceCalls.Clear();
            _sMarks = "";

            DSInvoiceCalls oDSInvoiceCalls = new DSInvoiceCalls();
            CSDCustomerSatisfaction _oMarkList = new CSDCustomerSatisfaction();
            _oMarkList.GetMarklist();
            foreach (CSDCustomerSatisfactionDetail oMark in _oMarkList)
            {
                DSInvoiceCalls.CustomerSatisfactionMarkRow oCustomerSatisfactionMarkRow = oDSInvoiceCalls.CustomerSatisfactionMark.NewCustomerSatisfactionMarkRow();
                oCustomerSatisfactionMarkRow.ID = oMark.ID;
                oCustomerSatisfactionMarkRow.Mark = oMark.Mark;
                oCustomerSatisfactionMarkRow.QuestionID = oMark.QuestionID;
                oCustomerSatisfactionMarkRow.Description = oMark.Description;
                oDSInvoiceCalls.CustomerSatisfactionMark.AddCustomerSatisfactionMarkRow(oCustomerSatisfactionMarkRow);
                oDSInvoiceCalls.AcceptChanges();
            }
            
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count)
                {
                    DSInvoiceCalls.InvoiceCallsRow oRow = _oDSInvoiceCalls.InvoiceCalls.NewInvoiceCallsRow();
                    oRow.QuestionID = int.Parse(oItemRow.Cells[1].Value.ToString());
                    //oRow.Marks = int.Parse(oItemRow.Cells[2].Value.ToString());



                    DSInvoiceCalls oDSInvoiceCallsList = new DSInvoiceCalls();
                    DataRow[] oDRMarklist = oDSInvoiceCalls.CustomerSatisfactionMark.Select(" QuestionID= '" + oRow.QuestionID + "' and Description= '" + oItemRow.Cells[2].Value.ToString() + "'");
                    oDSInvoiceCallsList.Merge(oDRMarklist);
                    oDSInvoiceCallsList.AcceptChanges();
                    foreach (DSInvoiceCalls.CustomerSatisfactionMarkRow _oCustomerSatisfactionMarkRow in oDSInvoiceCallsList.CustomerSatisfactionMark)
                    {
                        oRow.Marks = _oCustomerSatisfactionMarkRow.Mark;
                        oRow.MarksID = _oCustomerSatisfactionMarkRow.ID;
                    }



                    oRow.MAGID = _nMAGID;
                    oRow.ProductID = _nProductID;
                    oRow.ProductSerial = _sProductSerial;
                    _oDSInvoiceCalls.InvoiceCalls.AddInvoiceCallsRow(oRow);
                    _oDSInvoiceCalls.AcceptChanges();

                    if (_sMarks != "")
                    {
                        _sMarks = _sMarks + " | ";
                    }
                    _sMarks = _sMarks + oItemRow.Cells[0].Value.ToString() + "-" + oItemRow.Cells[2].Value.ToString();
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmMAGWiseQuestioner_Load(object sender, EventArgs e)
        {

        }
    }
}
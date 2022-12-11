using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Library;
using System.Data.OleDb;
using System.Threading;


using CJ.Class.HR;

namespace CJ.Win.HR
{
    public partial class frmMobileBillExeclUploader : Form
    {
        Companys _oCompanys;
        private DataTable _oDT;
        MobileNumberAssign _oMobileNumberAssign;

        public frmMobileBillExeclUploader()
        {
            InitializeComponent();
        }

        private void frmMobileBillExeclUploader_Load(object sender, EventArgs e)
        {
            dtBillMonth.Value = Convert.ToDateTime("01-" + dtBillMonth.Value.Month + "-" + dtBillMonth.Value.Year);
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Cursor = Cursors.WaitCursor;
                Save();
                Cursor = Cursors.Default;
                Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            bool isSelected = false;
            openFileDialogData.FileName = "";
            openFileDialogData.Multiselect = false;
            openFileDialogData.Filter = "";
            //this.openFileDialogData.Filter = "Text File(*.txt;)|*.txt;| File(*.TXT;)|*.TXT;|All Files(*.*;)|*.*";
            openFileDialogData.Filter = "Excel 2007+ Sheet(*.xlsx)|*.xlsx|Excel Sheet(*.xls)|*.xls";
            if (openFileDialogData.ShowDialog() == DialogResult.OK)
            {
                txtXLFilePath.Text = this.openFileDialogData.FileName.ToString();
                Text = this.openFileDialogData.DefaultExt.ToString();
                isSelected = true;
            }

            if (isSelected)
            {
                LoadSheets();
            }
            GetTotalAmount();
        }

        private void LoadSheets()
        {
            OleDbConnection oConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txtXLFilePath.Text + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;\"");
            oConn.Open();

            OleDbDataAdapter oDataAdapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", oConn);

            DataSet oDS = new DataSet();
            _oDT = new DataTable();
            oDataAdapter.Fill(_oDT);
            dgvMobileBills.DataSource = _oDT.DefaultView;
            this.Text = "Load From XL [" + _oDT.Rows.Count + "]";

            dgvMobileBills.ReadOnly = true;
            btnProcess.Enabled = true;
        }

        public void GetTotalAmount()
        {
            txtTotalAmount.Text = "0.00";
            TELLib oTELLib = new TELLib();
            double _Amount = 0;
            lblAmountInWord.Text = "";
            DataGridViewRow oDGVRow;

            foreach (DataGridViewRow oRow in dgvMobileBills.Rows)
            {

                if (oRow.Cells[2].Value != null)
                {

                    double _Amt;
                    try
                    {
                        _Amt = Convert.ToDouble(oRow.Cells[2].Value.ToString());
                    }
                    catch
                    {
                        _Amt = 0;
                    }
                    _Amount = _Amount + _Amt;
                }
            }
            txtTotalAmount.Text = oTELLib.TakaFormat(_Amount);
            lblAmountInWord.Text = oTELLib.TakaWords(_Amount);
        }
        private bool validateUIInput()
        {
            if (dgvMobileBills.Rows.Count == 0)
            {
                MessageBox.Show("No Data To Save Bill", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;


        }
        private void Save()
        {
            DBController.Instance.OpenNewConnection();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            MobileNumberAssign oMobileNumberAssign = new MobileNumberAssign();
            foreach (DataGridViewRow oItemRow in dgvMobileBills.Rows)
            {
                DBController.Instance.OpenNewConnection();
                if (oItemRow.Index < dgvMobileBills.Rows.Count)
                {
                    try
                    {
                        MobileBill oMobileBill = new MobileBill();
                        MobileNumber _oMobileNumber = new MobileNumber();                        
                        _oMobileNumberAssign = new MobileNumberAssign(); 
                       
                        string sMobileNo = Convert.ToString(oItemRow.Cells[1].Value.ToString());
                        _oMobileNumber.MobileNo = sMobileNo.Trim();
                        _oMobileNumber.GetMobileDetails();
                        oMobileBill.MobileID = _oMobileNumber.ID; 
                        if (oMobileBill.MobileID != 0)
                        {
                            oMobileBill.DatapacID = _oMobileNumber.DatapacID;
                            if (oMobileBill.DatapacID != null)
                            {
                                MobileDatapac _oMobileDatapac = new MobileDatapac();
                                _oMobileDatapac.DatapacID = _oMobileNumber.DatapacID;
                                _oMobileDatapac.Refresh();
                                oMobileBill.DatapacLimit = _oMobileDatapac.PackageAmount;
                            }

                            

                            oMobileBill.AssignID = _oMobileNumberAssign.GetAssignID(oMobileBill.MobileID);
                            _oMobileNumberAssign.ID = oMobileBill.AssignID;
                            _oMobileNumberAssign.Refresh();

                            var anEmployee = new Employee
                            {
                                EmployeeID = _oMobileNumberAssign.EmployeeID
                            };
                            anEmployee.Refresh();
                            oMobileBill.EmpLocationId = anEmployee.LocationID;


                            oMobileBill.BillAmount = Convert.ToDouble(oItemRow.Cells[2].Value);
                            oMobileBill.OperatorInvoiceNumber = oItemRow.Cells[3].Value.ToString();
                            oMobileBill.CreaditLimitType = _oMobileNumberAssign.CreditLimitType;
                            oMobileBill.CreaditLimit = _oMobileNumberAssign.CreditLimit;                            
                            oMobileBill.TMonth = dtBillMonth.Value.Month;
                            string billMonth = Thread.CurrentThread.CurrentCulture.DateTimeFormat.MonthNames[dtBillMonth.Value.Month - 1];
                            oMobileBill.TYear = dtBillMonth.Value.Year;
                            if (oMobileBill.CreaditLimitType == (int)Dictionary.MobileCreaditLimitType.Actual)
                            {
                                oMobileBill.DeductFromSalary = 0;
                                oMobileBill.ApproveStatus = (int)Dictionary.MobileDeductApproveStatus.NotApplicable;
                            }
                            else
                            {
                                if (oMobileBill.BillAmount > (oMobileBill.CreaditLimit + oMobileBill.DatapacLimit))
                                {
                                    oMobileBill.DeductFromSalary = oMobileBill.BillAmount - (oMobileBill.CreaditLimit + oMobileBill.DatapacLimit);
                                    oMobileBill.ApproveStatus = (int)Dictionary.MobileDeductApproveStatus.Pending;
                                }
                                else
                                {
                                    oMobileBill.DeductFromSalary = 0;
                                    oMobileBill.ApproveStatus = (int)Dictionary.MobileDeductApproveStatus.NotApplicable;
                                }

                            }
                            if (oMobileNumberAssign.IsMobileBillSavedForMonth(oMobileBill.MobileID, dtBillMonth.Value.Month, dtBillMonth.Value.Year))
                            {
                                DBController.Instance.BeginNewTransaction();
                                oMobileBill.Add();
                                DBController.Instance.CommitTransaction();
                            }
                            else
                            {
                                if (oItemRow.Index == dgvMobileBills.Rows.Count - 1)
                                {
                                    MessageBox.Show("You Have Successfully Save The Bill ,Month of " + billMonth + " " + oMobileBill.TYear, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    break;
                                }
                                continue;
                            }


                            if (oItemRow.Index == dgvMobileBills.Rows.Count - 1)
                            {
                                MessageBox.Show("You Have Successfully Save The Bill ,Month of " + billMonth + " " + oMobileBill.TYear, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        throw (ex);
                    }
                }
            }

         }

        
        private void btnProcess_Click(object sender, EventArgs e)
        {
            ProcessBills();
        }
        private void dtBillMonth_ValueChanged(object sender, EventArgs e)
        {
            ProcessBills();
        }

        public void ProcessBills()
        {
            DBController.Instance.OpenNewConnection();
            MobileBill oMobileBill = new MobileBill();
            MobileNumber _oMobileNumber = new MobileNumber(); 
            foreach (DataGridViewRow oItemRow in dgvMobileBills.Rows)
            {
                _oMobileNumberAssign = new MobileNumberAssign();
                string sMobileNo = Convert.ToString(oItemRow.Cells[1].Value.ToString());
                _oMobileNumber.MobileNo = sMobileNo;
                _oMobileNumber.GetMobileDetails();
                oMobileBill.MobileID = _oMobileNumber.ID;//_oMobileNumberAssign.GetMobileID(sMobileNo);
                //oMobileBill.AssignID = _oMobileNumberAssign.GetAssignID(_oMobileNumber.ID);
                //oMobileBill.DatapacID = _oMobileNumber.DatapacID;
                oItemRow.DefaultCellStyle.BackColor = !_oMobileNumberAssign.IsMobileBillSavedForMonth(oMobileBill.MobileID, dtBillMonth.Value.Month, dtBillMonth.Value.Year) ? Color.FromArgb(255, 228, 196) : Color.FromArgb(255, 255, 255);
            }
        }

      

    }
}
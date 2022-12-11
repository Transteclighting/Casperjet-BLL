using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.DMS;
using System.Data.OleDb;

namespace CJ.Win.DMS
{
    public partial class frmDMSDSR : Form
    {
        private Customers oCustomers;
        private Customer _oCustomer;
        DMSDSR _oDMSDSR;
        DMSDSRs _oDMSDSRs;
        DMSDSRs oDMSDSRs;
        public static bool isUpdated = false;

        public frmDMSDSR()
        {
            InitializeComponent();
        }

        public void ShowDialog(DMSDSR oDMSDSR)
        {
            DBController.Instance.BeginNewTransaction();
            this.Tag = oDMSDSR;
            LoadCombos();
            _oCustomer = new Customer();
            _oCustomer.RefreshByID(oDMSDSR.CustomerID);
            ctlCustomerID.txtCode.Text = _oCustomer.CustomerCode;
            txtDSRCode.Text = oDMSDSR.DSRCode.ToString();
            txtDSRName.Text = oDMSDSR.DSRName;
            txtShortName.Text = oDMSDSR.ShortName;
            txtDSRPhNo.Text = oDMSDSR.DSRMobile;
           // txtDesignation.Text = oDMSDSR.Designation;
            dateTimeJoiningDt.Text = oDMSDSR.JoiningDate.ToString();
            txtFixedSalary.Text = oDMSDSR.FixedSalary.ToString();
            txtvariableSalary.Text = oDMSDSR.VariableSalary.ToString();
            txtDailyTADA.Text = oDMSDSR.DailyTADA.ToString();
            txtDailySpcAllowance.Text = oDMSDSR.DailySpcAllowance.ToString();
            txtOthersAllowance.Text = oDMSDSR.OthersAllowance.ToString();
            txtMobileBill.Text = oDMSDSR.MobileBill.ToString();
            txtBkashAcc.Text = oDMSDSR.BkashAccountNo;
            txtDBBLAccNo.Text = oDMSDSR.DBBLAccNo;
            txtDBBLMobNo.Text = oDMSDSR.DBBLMobNo;
            txtGrade.Text = oDMSDSR.Grade;
            txtPosition.Text = oDMSDSR.Position;
            dtdob.Text = oDMSDSR.DOB.ToString();

            if (oDMSDSR.IsCurrent == 1)
            {
                cbxIsCurrent.Checked = true;
            }
            else cbxIsCurrent.Checked = false;

            if (oDMSDSR.ResignDate !=null)
            {
                cbxisresigned.Checked = true;
                dtresigndate.Text = oDMSDSR.ResignDate.ToString();
            }
            else cbxisresigned.Checked = false;


            if (oDMSDSR.IsHeldUp == 1)
            {
                cbxIsheldUp.Checked = true;
            }
            else cbxIsheldUp.Checked = false;

            cmbDesignation.Text = oDMSDSR.Designation;
            cmbEmployeeType.Text = oDMSDSR.EmployeeType;
            cmbPaymentMode.Text = oDMSDSR.PaymentMode;
            cmbPaymentType.Text = oDMSDSR.PaymentType;
            cmbTownType.Text = oDMSDSR.TownType;
            cmbAccountType.Text = oDMSDSR.AccountType;
            

            this.ShowDialog();

 
        }

        private void LoadCombos()
        {
            //Designation
            cmbDesignation.Items.Clear();
            cmbDesignation.Items.Add("--Select Designation--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.DesignationDSR)))
            {
                cmbDesignation.Items.Add(Enum.GetName(typeof(Dictionary.DesignationDSR), GetEnum));
            }
            cmbDesignation.SelectedIndex = 0;

            //EmployeeType
            cmbEmployeeType.Items.Clear();
            cmbEmployeeType.Items.Add("--Select Employee Type--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.EmployeeType)))
            {
                cmbEmployeeType.Items.Add(Enum.GetName(typeof(Dictionary.EmployeeType), GetEnum));
            }
            cmbEmployeeType.SelectedIndex = 0;

            //PaymentMode
            cmbPaymentMode.Items.Clear();
            cmbPaymentMode.Items.Add("--Select Payment Mode--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SAPaymentMode)))
            {
                cmbPaymentMode.Items.Add(Enum.GetName(typeof(Dictionary.SAPaymentMode), GetEnum));
            }
            cmbPaymentMode.SelectedIndex = 0;

            //PaymentType
            cmbPaymentType.Items.Clear();
            cmbPaymentType.Items.Add("--Select Payment Type--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.PaymentType)))
            {
                cmbPaymentType.Items.Add(Enum.GetName(typeof(Dictionary.PaymentType), GetEnum));
            }
            cmbPaymentType.SelectedIndex = 0;

            //TownType
            cmbTownType.Items.Clear();
            cmbTownType.Items.Add("--Select Town Type--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.OrderTakerTownType)))
            {
                cmbTownType.Items.Add(Enum.GetName(typeof(Dictionary.OrderTakerTownType), GetEnum));
            }
            cmbTownType.SelectedIndex = 0;

            //AccountType
            cmbAccountType.Items.Clear();
            cmbAccountType.Items.Add("--Select Account Type--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.OrderTakerAccountType)))
            {
                cmbAccountType.Items.Add(Enum.GetName(typeof(Dictionary.OrderTakerAccountType), GetEnum));
            }
            cmbAccountType.SelectedIndex = 0;



        }

        private void frmDMSDSR_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                LoadCombos();
            }
        }

        private void ctlCustomer1_Load(object sender, EventArgs e)
        {
            if (ctlCustomerID.SelectedCustomer != null && ctlCustomerID.txtCode.Text != "")
            {
                _oCustomer = new Customer();
                _oCustomer.CustomerID = ctlCustomerID.SelectedCustomer.CustomerID;
                _oCustomer.refresh();

            }
        }


        private void SETUI(Customer _oCustomer)
        {
            _oDMSDSRs = new DMSDSRs();

            //_oDMSDSRs.Refresh(_oCustomer.CustomerID);
            _oDMSDSRs.RefreshBYDSRName(_oCustomer.CustomerID);

            oDMSDSRs = new DMSDSRs();
            oDMSDSRs = _oDMSDSRs;
        }

        private bool validateUIInput()
        {
            #region Input Information Validation
            if (txtDSRCode.Text == "")
            {
                MessageBox.Show("Please Write DSR Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDSRCode.Focus();
                return false;
            }
            if (txtDSRName.Text == "")
            {
                MessageBox.Show("Please Write DSR Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDSRName.Focus();
                return false;
            }
            if (txtShortName.Text == "")
            {
                MessageBox.Show("Please Write DSR Short Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDSRName.Focus();
                return false;
            }
            if (txtDSRPhNo.Text == "")
            {
                MessageBox.Show("Please Write DSR Phone No.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDSRPhNo.Focus();
                return false;
            }
            if (cmbDesignation.Text.Trim() == "--Select Designation--")
            {
                MessageBox.Show("Please Select Designation", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDesignation.Focus();
                return false;
            }
            if (cmbEmployeeType.Text == "--Select Employee Type--")
            {
                MessageBox.Show("Please Select Employee Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEmployeeType.Focus();
                return false;
            }
            if (cmbPaymentMode.Text == "--Select Payment Mode--")
            {
                MessageBox.Show("Please Select Payment Mode", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPaymentMode.Focus();
                return false;
            }
            if (cmbPaymentType.Text == "--Select Payment Type--")
            {
                MessageBox.Show("Please Select Payment Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPaymentType.Focus();
                return false;
            }
            //if (dateTimeJoiningDt.Text == "--Select Joining Date--")
            //{
            //    MessageBox.Show("Please Select Geo Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    cmbGeotype.Focus();
            //    return false;
            //}

            if (cmbPaymentType.Text == "--Select Town Type--")
            {
                MessageBox.Show("Please Select Town Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPaymentType.Focus();
                return false;
            }

            if (cmbPaymentType.Text == "--Select Account Type--")
            {
                MessageBox.Show("Please Select Account Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbPaymentType.Focus();
                return false;
            }

            if (txtFixedSalary.Text == "")
            {
                MessageBox.Show("Please Write Fixed Salary", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFixedSalary.Focus();
                return false;
            }
            if (txtDailyTADA.Text == "")
            {
                MessageBox.Show("Please Write Daily TADA ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDailyTADA.Focus();
                return false;
            }
            if (txtDailySpcAllowance.Text == "")
            {
                MessageBox.Show("Please Write Daily Spc Allowance ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDailySpcAllowance.Focus();
                return false;
            }

            if (txtOthersAllowance.Text == "")
            {
                MessageBox.Show("Please Write Others Allowance ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOthersAllowance.Focus();
                return false;
            }
            if (txtMobileBill.Text == "")
            {
                MessageBox.Show("Please Write Mobile Bill ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMobileBill.Focus();
                return false;
            }
            if (txtBkashAcc.Text == "")
            {
                MessageBox.Show("Please Write Bkash Account No.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBkashAcc.Focus();
                return false;
            }

            if (txtDBBLAccNo.Text == "")
            {
                MessageBox.Show("Please Write DBBL Account No.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBkashAcc.Focus();
                return false;
            }

            if (txtDBBLMobNo.Text == "")
            {
                MessageBox.Show("Please Write DBBL Mobile No.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBkashAcc.Focus();
                return false;
            }

            #endregion

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Company com = new Company();
            frmDMSDSR.isUpdated = true; 
            if (validateUIInput())
            {
                Save();
                //if(com.CompanyID== 82943)
                //{
                //    insertintoEmployeeTable();
                //}
                this.Close();
            }
            //this.Close();
        }

        private void Save()
        {
            if (this.Tag == null)
            {
                DMSDSR oDMSDSR = new DMSDSR();
                oDMSDSR.CustomerID = ctlCustomerID.SelectedCustomer.CustomerID;
                oDMSDSR.DSRCode = Convert.ToInt32(txtDSRCode.Text);
                oDMSDSR.DSRName = txtDSRName.Text;
                oDMSDSR.ShortName = txtShortName.Text;
                oDMSDSR.DSRMobile = txtDSRPhNo.Text;
                oDMSDSR.Designation = cmbDesignation.Text;
                oDMSDSR.EmployeeType=cmbEmployeeType.Text;
                oDMSDSR.PaymentMode=cmbPaymentMode.Text;
                oDMSDSR.PaymentType=cmbPaymentType.Text;
                oDMSDSR.TownType = cmbTownType.Text;
                oDMSDSR.AccountType = cmbAccountType.Text;
                oDMSDSR.JoiningDate=Convert.ToDateTime(dateTimeJoiningDt.Text);
                oDMSDSR.DOB=Convert.ToDateTime(dtdob.Text);
                oDMSDSR.TownType = cmbTownType.Text;
                oDMSDSR.AccountType = cmbAccountType.Text;
                oDMSDSR.FixedSalary = Convert.ToDouble(txtFixedSalary.Text);
                oDMSDSR.VariableSalary = Convert.ToDouble(txtvariableSalary.Text);
                oDMSDSR.DailyTADA = Convert.ToDouble(txtDailyTADA.Text);
                oDMSDSR.DailySpcAllowance = Convert.ToDouble(txtDailySpcAllowance.Text);
                oDMSDSR.OthersAllowance = Convert.ToDouble(txtOthersAllowance.Text);
                oDMSDSR.MobileBill = Convert.ToDouble(txtMobileBill.Text);
                oDMSDSR.BkashAccountNo=txtBkashAcc.Text;
                oDMSDSR.DBBLAccNo = txtDBBLAccNo.Text;
                oDMSDSR.DBBLMobNo = txtDBBLMobNo.Text;
                oDMSDSR.Grade = txtGrade.Text;
                oDMSDSR.Position = txtPosition.Text;


                  if (cbxIsCurrent.Checked == true)
                    {
                    oDMSDSR.IsCurrent = 1;
                    }
                 else oDMSDSR.IsCurrent = 0;

                if(cbxIsheldUp.Checked==true)
                {
                    oDMSDSR.IsHeldUp = 1;
                }
                else oDMSDSR.IsHeldUp = 0;


                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oDMSDSR.AddDSRDetails();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The SAName : " + oDMSDSR.DSRName, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                Customer oCustomer = new Customer();
                
                DMSDSR oDMSDSR = (DMSDSR)this.Tag;
                //oCustomer.RefreshByID();

                oDMSDSR.CustomerID = ctlCustomerID.SelectedCustomer.CustomerID;
                oDMSDSR.DSRCode = Convert.ToInt32(txtDSRCode.Text);
                oDMSDSR.DSRName = txtDSRName.Text;
                oDMSDSR.ShortName = txtShortName.Text;
                oDMSDSR.DSRMobile = txtDSRPhNo.Text;
                oDMSDSR.Designation = cmbDesignation.Text;
                oDMSDSR.EmployeeType=cmbEmployeeType.Text;
                oDMSDSR.PaymentMode=cmbPaymentMode.Text;
                oDMSDSR.PaymentType=cmbPaymentType.Text;
                oDMSDSR.DOB=Convert.ToDateTime(dtdob.Text);
                oDMSDSR.JoiningDate=Convert.ToDateTime(dateTimeJoiningDt.Text);
                oDMSDSR.TownType = cmbTownType.Text;
                oDMSDSR.AccountType = cmbAccountType.Text;
                oDMSDSR.FixedSalary = Convert.ToDouble(txtFixedSalary.Text);
                oDMSDSR.VariableSalary = Convert.ToDouble(txtvariableSalary.Text);
                oDMSDSR.DailyTADA = Convert.ToDouble(txtDailyTADA.Text);
                oDMSDSR.DailySpcAllowance = Convert.ToDouble(txtDailySpcAllowance.Text);
                oDMSDSR.OthersAllowance = Convert.ToDouble(txtOthersAllowance.Text);
                oDMSDSR.MobileBill = Convert.ToDouble(txtMobileBill.Text);
                oDMSDSR.BkashAccountNo=txtBkashAcc.Text;
                oDMSDSR.DBBLAccNo = txtDBBLAccNo.Text;
                oDMSDSR.DBBLMobNo = txtDBBLMobNo.Text;
                oDMSDSR.Grade = txtGrade.Text;
                oDMSDSR.Position = txtPosition.Text;
              


                if (cbxIsCurrent.Checked == true)
                {
                    oDMSDSR.IsCurrent = 1;
                }
                else oDMSDSR.IsCurrent = 0;

                if(cbxIsheldUp.Checked==true)
                {
                    oDMSDSR.IsHeldUp = 1;
                }
                else oDMSDSR.IsHeldUp = 0;

                if (cbxisresigned.Checked == true)
                {
                   oDMSDSR.ResignDate = Convert.ToDateTime(dtresigndate.Text); 
                }
            

                

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oDMSDSR.EditDSRDetails();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update The DSRName : " + oDMSDSR.DSRName, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }

        private void insertintoEmployeeTable()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string SQL = "insert into t_employee  (EmployeeID,EmployeeCode,Employeename,CompanyId,Cardno,DepartmentID,LocationID,ShiftID,EmployeeType,EmployeeCategory,EmpStatus,PaymentMode,BasicSalary,Ispayrollemployee) " +
            " values('" + getMaxemployeeid() + "', '" + txtDSRCode.Text + "','" + txtDSRName.Text + "','" + 82943 + "','" + txtDSRCode.Text + "','" + 82984 + "','" + 0 + "' ," + 3 + "," + 0 + ",'X', '"+1+"', '"+1+"','" +Convert.ToDecimal( txtFixedSalary.Text) + "','"+1+"')";
            cmd.CommandText = SQL;
            cmd.CommandType = CommandType.Text;
            cmd.ExecuteNonQuery();
        }

        private int getMaxemployeeid()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sql = "select max(employeeid)+1 from t_employee";
            cmd.CommandText = sql;
            cmd.CommandType = CommandType.Text;
            int id =Convert.ToInt32(cmd.ExecuteScalar());

            return id;
        }


        private void btnClosed_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void cbxIsCurrent_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void cbxisresigned_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
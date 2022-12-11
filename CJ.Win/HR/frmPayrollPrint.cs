using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.HR;
using CJ.Report;
using CJ.Report.HR;
using CJ.Class.Library;

namespace CJ.Win.HR
{
    public partial class frmPayrollPrint : Form
    {
        TELLib _oTElLib;
        HRPayroll _oHRPayroll;
        HRPayrollSetting _oHRPayrollSetting;
        Company _oCompany;

        public frmPayrollPrint()
        {
            InitializeComponent();
        }

        private void frmPayrollPrint_Load(object sender, EventArgs e)
        {
            if (_oHRPayroll.CompanyID == (int)Dictionary.CompanyID.TEL)
            {
                chkTDStaff.Visible = true;
            }
            else if (_oHRPayroll.CompanyID == (int)Dictionary.CompanyID.BEIL)
            {
                chkTDStaff.Visible = false;
            }
            else
            {
                chkTDStaff.Visible = false;
                rdoEmployeeWise.Enabled = false;
            }
            rdoDepartmentWise.Checked = true;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            bool _bSalaryTyep = false;

            _oHRPayrollSetting = new HRPayrollSetting();

            _bSalaryTyep = _oHRPayrollSetting.CheckSalaryType(_oHRPayroll.PayrollID, (int)Dictionary.PayrollSettings.FullSalary);
            if (rdoPayroll.Checked == true)
            {
                if (_oHRPayroll.Type == (int)Dictionary.PayrollType.Officer)
                {
                    PayrollPrint(_oHRPayroll, _bSalaryTyep);
                }
                else if (_oHRPayroll.Type == (int)Dictionary.PayrollType.Supervisor)
                {
                    PayrollPrintSupervisor(_oHRPayroll, _bSalaryTyep);
                }
            }
            else if (rdoCashPart.Checked == true)
            {
                if (_oHRPayroll.Type == (int)Dictionary.PayrollType.Staff)
                {
                    PayrollPrintStaff(_oHRPayroll, _bSalaryTyep);
                }
                else if (_oHRPayroll.Type == (int)Dictionary.PayrollType.Officer)
                {
                    PayrollPrintOfficerCashPart(_oHRPayroll, _bSalaryTyep);
                }

            }
            else if (rdoPaySlip.Checked == true)
            {
                if (_oHRPayroll.Type == (int)Dictionary.PayrollType.Officer)
                {
                    PaySlipPrint(_oHRPayroll, _bSalaryTyep);
                }
                else
                {

                    PaySlipStaff_Sup_Print(_oHRPayroll, _bSalaryTyep);
                }
            }
            else if (rdoAtaGlance.Checked == true)
            {
                PayrollPrintAtaGlance(_oHRPayroll, _bSalaryTyep);
            }
            else if (rbLunch.Checked == true)
            {
                PayrollPrintOfficerCashPart_new(_oHRPayroll, _bSalaryTyep);
            }
            else if (rbCar.Checked == true)
            {
                PayrollPrintOfficerCashPart_new(_oHRPayroll, _bSalaryTyep);
            }
            else if (rbServant.Checked == true)
            {
                PayrollPrintOfficerCashPart_new(_oHRPayroll, _bSalaryTyep);
            }
            else if (rbDriver.Checked == true)
            {
                PayrollPrintOfficerCashPart_new(_oHRPayroll, _bSalaryTyep);
            }

            else if (rdoPaySlipFactory.Checked == true)
            {
                //if ( == "")
                //{
                //    MessageBox.Show("Please select an Employee", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                //    return false;
                //}
                

                if (_oHRPayroll.Type == (int)Dictionary.PayrollType.Officer)
                {
                    PrintForFactory(_oHRPayroll, _bSalaryTyep);
                }
                else
                {

                    PrintForFactory(_oHRPayroll, _bSalaryTyep);
                }
            }
           
        }

        private void PrintForFactory(HRPayroll oHRPayroll, bool _bSalaryTyep)
        {
            var firstDayOfMonth = new DateTime(_oHRPayroll.TYear, _oHRPayroll.TMonth, 1);
            var lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

            _oTElLib = new TELLib();
            this.Cursor = Cursors.WaitCursor;
            EmployeeAllowances _oEmployeeAllowances = new EmployeeAllowances();
            _oEmployeeAllowances.RefreshPayrollIDFactory(oHRPayroll.PayrollID, oHRPayroll.TMonth, oHRPayroll.TYear, oHRPayroll.CompanyID, _bSalaryTyep, false, rdoDepartmentWise.Checked);
            rptPayRegisterAndPaySlip doc;
            doc = new rptPayRegisterAndPaySlip();
            doc.SetDataSource(_oEmployeeAllowances);
            string _sType = Enum.GetName(typeof(Dictionary.PayrollType), oHRPayroll.Type);
            //doc.SetParameterValue("Type", _sType);
            //string _sMonth = Enum.GetName(typeof(Dictionary.MonthShortName), oHRPayroll.TMonth);
            doc.SetParameterValue("FDate", firstDayOfMonth);
            doc.SetParameterValue("TDate", lastDayOfMonth.ToString());
            //doc.SetParameterValue("User", Utility.UserFullname);
            doc.SetParameterValue("Company", oHRPayroll.CompanyName);
            doc.SetParameterValue("CompanyAddress", "House No. 22, Road No. 4, Block-F, Banani, Dhaka -1213");
            //doc.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperEnvelope10;
            //doc.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)GetPapersizeID;
            //int x = (8 * 4);
            //doc.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)x;
            //doc.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;


            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);

            this.Cursor = Cursors.Default;
        }

        public void ShowDialog(HRPayroll oHRPayroll)
        {
            _oHRPayroll = new HRPayroll();
            this.Tag = oHRPayroll;
            _oHRPayroll = oHRPayroll;

            lblPayrollNo.Text = "Payroll#: " + _oHRPayroll.Code;
            lblType.Text = "Type: " + Enum.GetName(typeof(Dictionary.PayrollType), _oHRPayroll.Type);
            lblPayrollMonth.Text = "Month: " + Enum.GetName(typeof(Dictionary.MonthShortName), _oHRPayroll.TMonth) + "-" + _oHRPayroll.TYear.ToString();
            lblDescription.Text = "Desc.: " + _oHRPayroll.Description;

            if (_oHRPayroll.Type == (int)Dictionary.PayrollType.Staff)
            {
                rdoAtaGlance.Enabled = false;
                rdoPayroll.Enabled = false;
                rdoCashPart.Checked = true;
            }
            else if (_oHRPayroll.Type == (int)Dictionary.PayrollType.Supervisor)
            {
                rdoAtaGlance.Enabled = false;
                rdoPayroll.Enabled = true;
                rdoPayroll.Checked = true;
                rdoCashPart.Enabled = false;
            }
            else if (_oHRPayroll.Type == (int)Dictionary.PayrollType.Officer)
            {
                rdoPayroll.Checked = true;
                rdoAtaGlance.Enabled = true;
                rdoPayroll.Enabled = true;
                rdoCashPart.Enabled = true;
            }

            if(_oHRPayroll.Type == (int)Dictionary.PayrollType.Officer && _oHRPayroll.CompanyID == (int)Dictionary.CompanyID.BLL)
            {
                //gbCashPart.Visible = true;
                rbLunch.Visible = true;
                rbCar.Visible = true;
                rbDriver.Visible = true;
                rbServant.Visible = true;


                rdoPayroll.Checked = true;
                rdoAtaGlance.Enabled = true;
                rdoPayroll.Enabled = true;
                rdoCashPart.Visible= false;
            }

            this.ShowDialog();
        }

        private void PayrollPrint(HRPayroll oHRPayroll, bool _bSalaryTyep)
        {
            _oTElLib = new TELLib();
            this.Cursor = Cursors.WaitCursor;
            EmployeeAllowances _oEmployeeAllowances = new EmployeeAllowances();
            _oEmployeeAllowances.RefreshPayrollID(oHRPayroll.PayrollID, oHRPayroll.TMonth, oHRPayroll.TYear, oHRPayroll.CompanyID, _bSalaryTyep, false, rdoDepartmentWise.Checked);

            if (oHRPayroll.CompanyID == (int)Dictionary.CompanyID.TEL)
            {
                if (rdoDepartmentWise.Checked == true)
                {
                    rptPayrollOfficerBankPart_TEL doc;
                    doc = new rptPayrollOfficerBankPart_TEL();

                    doc.SetDataSource(_oEmployeeAllowances);
                    string _sType = Enum.GetName(typeof(Dictionary.PayrollType), oHRPayroll.Type);
                    doc.SetParameterValue("Type", _sType);
                    string _sMonth = Enum.GetName(typeof(Dictionary.MonthShortName), oHRPayroll.TMonth);
                    doc.SetParameterValue("Month", _sMonth + " - " + oHRPayroll.TYear.ToString());
                    doc.SetParameterValue("User", Utility.UserFullname);
                    doc.SetParameterValue("Company", oHRPayroll.CompanyName);

                    double _Amount = TotalAmountTEL(_oEmployeeAllowances, "OfficerBank");
                    doc.SetParameterValue("AmountInWord", _oTElLib.TakaWords(_Amount));

                    frmPrintPreview frmView;
                    frmView = new frmPrintPreview();
                    frmView.ShowDialog(doc);
                }
                else
                {
                    CJ.Report.HR.rptPayrollOfficerBankPart_TEL_E doc;
                    doc = new CJ.Report.HR.rptPayrollOfficerBankPart_TEL_E();

                    doc.SetDataSource(_oEmployeeAllowances);
                    string _sType = Enum.GetName(typeof(Dictionary.PayrollType), oHRPayroll.Type);
                    doc.SetParameterValue("Type", _sType);
                    string _sMonth = Enum.GetName(typeof(Dictionary.MonthShortName), oHRPayroll.TMonth);
                    doc.SetParameterValue("Month", _sMonth + " - " + oHRPayroll.TYear.ToString());
                    doc.SetParameterValue("User", Utility.UserFullname);
                    doc.SetParameterValue("Company", oHRPayroll.CompanyName);

                    double _Amount = TotalAmountTEL(_oEmployeeAllowances, "OfficerBank");
                    doc.SetParameterValue("AmountInWord", _oTElLib.TakaWords(_Amount));

                    frmPrintPreview frmView;
                    frmView = new frmPrintPreview();
                    frmView.ShowDialog(doc);
                }
            }
            else if (oHRPayroll.CompanyID == (int)Dictionary.CompanyID.BEIL)
            {
                if (rdoDepartmentWise.Checked == true)
                {
                    rptPayrollOfficerBankPart_BEIL doc;
                    doc = new rptPayrollOfficerBankPart_BEIL();

                    doc.SetDataSource(_oEmployeeAllowances);
                    string _sType = Enum.GetName(typeof(Dictionary.PayrollType), oHRPayroll.Type);
                    doc.SetParameterValue("Type", _sType);
                    string _sMonth = Enum.GetName(typeof(Dictionary.MonthShortName), oHRPayroll.TMonth);
                    doc.SetParameterValue("Month", _sMonth + " - " + oHRPayroll.TYear.ToString());
                    doc.SetParameterValue("User", Utility.UserFullname);
                    doc.SetParameterValue("Company", oHRPayroll.CompanyName);

                    double _Amount = TotalAmount(_oEmployeeAllowances, "OfficerBank");
                    doc.SetParameterValue("AmountInWord", _oTElLib.TakaWords(_Amount));

                    frmPrintPreview frmView;
                    frmView = new frmPrintPreview();
                    frmView.ShowDialog(doc);
                }
                else
                {
                    CJ.Report.HR.rptPayrollOfficerBankPart_BEIL_E doc;
                    doc = new CJ.Report.HR.rptPayrollOfficerBankPart_BEIL_E();

                    doc.SetDataSource(_oEmployeeAllowances);
                    string _sType = Enum.GetName(typeof(Dictionary.PayrollType), oHRPayroll.Type);
                    doc.SetParameterValue("Type", _sType);
                    string _sMonth = Enum.GetName(typeof(Dictionary.MonthShortName), oHRPayroll.TMonth);
                    doc.SetParameterValue("Month", _sMonth + " - " + oHRPayroll.TYear.ToString());
                    doc.SetParameterValue("User", Utility.UserFullname);
                    doc.SetParameterValue("Company", oHRPayroll.CompanyName);

                    double _Amount = TotalAmount(_oEmployeeAllowances, "OfficerBank");
                    doc.SetParameterValue("AmountInWord", _oTElLib.TakaWords(_Amount));

                    frmPrintPreview frmView;
                    frmView = new frmPrintPreview();
                    frmView.ShowDialog(doc);
                }
            }
            else
            {
                rptPayrollOfficerBankPart_new doc;
                doc = new rptPayrollOfficerBankPart_new();

                doc.SetDataSource(_oEmployeeAllowances);
                string _sType = Enum.GetName(typeof(Dictionary.PayrollType), oHRPayroll.Type);
                doc.SetParameterValue("Type", _sType);
                string _sMonth = Enum.GetName(typeof(Dictionary.MonthShortName), oHRPayroll.TMonth);
                doc.SetParameterValue("Month", _sMonth + " - " + oHRPayroll.TYear.ToString());
                doc.SetParameterValue("User", Utility.UserFullname);
                doc.SetParameterValue("Company", oHRPayroll.CompanyName);

                double _Amount = TotalAmount_New(_oEmployeeAllowances, "OfficerBank");
                doc.SetParameterValue("AmountInWord", _oTElLib.TakaWords(_Amount));

                frmPrintPreview frmView;
                frmView = new frmPrintPreview();
                frmView.ShowDialog(doc);
            }



            this.Cursor = Cursors.Default;
        }

        private void PayrollPrintAtaGlance(HRPayroll oHRPayroll, bool _bSalaryTyep)
        {
            _oTElLib = new TELLib();
            this.Cursor = Cursors.WaitCursor;
            EmployeeAllowances _oEmployeeAllowances = new EmployeeAllowances();
            _oEmployeeAllowances.RefreshPayrollID(oHRPayroll.PayrollID, oHRPayroll.TMonth, oHRPayroll.TYear, oHRPayroll.CompanyID, _bSalaryTyep, false, rdoDepartmentWise.Checked);
            rptPayroll doc;
            doc = new rptPayroll();
            doc.SetDataSource(_oEmployeeAllowances);
            string _sType = Enum.GetName(typeof(Dictionary.PayrollType), oHRPayroll.Type);
            doc.SetParameterValue("Type", _sType);
            string _sMonth = Enum.GetName(typeof(Dictionary.MonthShortName), oHRPayroll.TMonth);
            doc.SetParameterValue("Month", _sMonth + " - " + oHRPayroll.TYear.ToString());
            doc.SetParameterValue("User", Utility.UserFullname);
            doc.SetParameterValue("Company", oHRPayroll.CompanyName);

            //double _Amount = 4473620;
            //doc.SetParameterValue("AmountInWord", _oTElLib.TakaWords(_Amount));

            // double _Amount = 4473620;
            doc.SetParameterValue("AmountInWord", "");

            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);

            this.Cursor = Cursors.Default;
        }

        private void PayrollPrintStaff(HRPayroll oHRPayroll, bool _bSalaryTyep)
        {
            _oTElLib = new TELLib();
            this.Cursor = Cursors.WaitCursor;
            EmployeeAllowances _oEmployeeAllowances = new EmployeeAllowances();
            _oEmployeeAllowances.RefreshPayrollID(oHRPayroll.PayrollID, oHRPayroll.TMonth, oHRPayroll.TYear, oHRPayroll.CompanyID, _bSalaryTyep, false, rdoDepartmentWise.Checked);
            if (oHRPayroll.CompanyID == (int)Dictionary.CompanyID.TEL)
            {
                if (chkTDStaff.Checked == true)
                {
                    //rptPayrollSupervisor_TEL doc;
                    //doc = new rptPayrollSupervisor_TEL();
                    rptPayrollTDStaff_TEL doc;
                    doc = new rptPayrollTDStaff_TEL();

                    doc.SetDataSource(_oEmployeeAllowances);
                    string _sType = Enum.GetName(typeof(Dictionary.PayrollType), oHRPayroll.Type);
                    doc.SetParameterValue("Type", _sType);
                    string _sMonth = Enum.GetName(typeof(Dictionary.MonthShortName), oHRPayroll.TMonth);
                    doc.SetParameterValue("Month", _sMonth + " - " + oHRPayroll.TYear.ToString());
                    doc.SetParameterValue("User", Utility.UserFullname);
                    doc.SetParameterValue("Company", oHRPayroll.CompanyName);

                    double _Amount = TotalAmount(_oEmployeeAllowances, "Supervisor/Staff");
                    doc.SetParameterValue("AmountInWord", _oTElLib.TakaWords(_Amount));

                    frmPrintPreview frmView;
                    frmView = new frmPrintPreview();
                    frmView.ShowDialog(doc);
                }
                else
                {
                    if (rdoDepartmentWise.Checked == true)
                    {
                        rptPayrollStaff_TEL doc;
                        doc = new rptPayrollStaff_TEL();
                        doc.SetDataSource(_oEmployeeAllowances);
                        string _sType = Enum.GetName(typeof(Dictionary.PayrollType), oHRPayroll.Type);
                        doc.SetParameterValue("Type", _sType);
                        string _sMonth = Enum.GetName(typeof(Dictionary.MonthShortName), oHRPayroll.TMonth);
                        doc.SetParameterValue("Month", _sMonth + " - " + oHRPayroll.TYear.ToString());
                        doc.SetParameterValue("User", Utility.UserFullname);
                        doc.SetParameterValue("Company", oHRPayroll.CompanyName);

                        double _Amount = TotalAmount(_oEmployeeAllowances, "Supervisor/Staff");
                        doc.SetParameterValue("AmountInWord", _oTElLib.TakaWords(_Amount));

                        frmPrintPreview frmView;
                        frmView = new frmPrintPreview();
                        frmView.ShowDialog(doc);
                    }
                    else
                    {
                        rptPayrollStaff_TEL_E doc;
                        doc = new rptPayrollStaff_TEL_E();
                        doc.SetDataSource(_oEmployeeAllowances);
                        string _sType = Enum.GetName(typeof(Dictionary.PayrollType), oHRPayroll.Type);
                        doc.SetParameterValue("Type", _sType);
                        string _sMonth = Enum.GetName(typeof(Dictionary.MonthShortName), oHRPayroll.TMonth);
                        doc.SetParameterValue("Month", _sMonth + " - " + oHRPayroll.TYear.ToString());
                        doc.SetParameterValue("User", Utility.UserFullname);
                        doc.SetParameterValue("Company", oHRPayroll.CompanyName);

                        double _Amount = TotalAmount(_oEmployeeAllowances, "Supervisor/Staff");
                        doc.SetParameterValue("AmountInWord", _oTElLib.TakaWords(_Amount));

                        frmPrintPreview frmView;
                        frmView = new frmPrintPreview();
                        frmView.ShowDialog(doc);
                    }
                }
            }
            else if (oHRPayroll.CompanyID == (int)Dictionary.CompanyID.BEIL)
            {
                if (rdoDepartmentWise.Checked == true)
                {
                    rptPayrollStaff_BEIL doc;
                    doc = new rptPayrollStaff_BEIL();
                    doc.SetDataSource(_oEmployeeAllowances);
                    string _sType = Enum.GetName(typeof(Dictionary.PayrollType), oHRPayroll.Type);
                    doc.SetParameterValue("Type", _sType);
                    string _sMonth = Enum.GetName(typeof(Dictionary.MonthShortName), oHRPayroll.TMonth);
                    doc.SetParameterValue("Month", _sMonth + " - " + oHRPayroll.TYear.ToString());
                    doc.SetParameterValue("User", Utility.UserFullname);
                    doc.SetParameterValue("Company", oHRPayroll.CompanyName);

                    double _Amount = TotalAmount(_oEmployeeAllowances, "Supervisor/Staff");
                    doc.SetParameterValue("AmountInWord", _oTElLib.TakaWords(_Amount));

                    frmPrintPreview frmView;
                    frmView = new frmPrintPreview();
                    frmView.ShowDialog(doc);
                }
                else
                {
                    rptPayrollStaff_BEIL_E doc;
                    doc = new rptPayrollStaff_BEIL_E();
                    doc.SetDataSource(_oEmployeeAllowances);
                    string _sType = Enum.GetName(typeof(Dictionary.PayrollType), oHRPayroll.Type);
                    doc.SetParameterValue("Type", _sType);
                    string _sMonth = Enum.GetName(typeof(Dictionary.MonthShortName), oHRPayroll.TMonth);
                    doc.SetParameterValue("Month", _sMonth + " - " + oHRPayroll.TYear.ToString());
                    doc.SetParameterValue("User", Utility.UserFullname);
                    doc.SetParameterValue("Company", oHRPayroll.CompanyName);

                    double _Amount = TotalAmount(_oEmployeeAllowances, "Supervisor/Staff");
                    doc.SetParameterValue("AmountInWord", _oTElLib.TakaWords(_Amount));

                    frmPrintPreview frmView;
                    frmView = new frmPrintPreview();
                    frmView.ShowDialog(doc);
                }
            }
            else
            {
                rptPayrollStaff doc;
                doc = new rptPayrollStaff();
                doc.SetDataSource(_oEmployeeAllowances);
                string _sType = Enum.GetName(typeof(Dictionary.PayrollType), oHRPayroll.Type);
                doc.SetParameterValue("Type", _sType);
                string _sMonth = Enum.GetName(typeof(Dictionary.MonthShortName), oHRPayroll.TMonth);
                doc.SetParameterValue("Month", _sMonth + " - " + oHRPayroll.TYear.ToString());
                doc.SetParameterValue("User", Utility.UserFullname);
                doc.SetParameterValue("Company", oHRPayroll.CompanyName);

                double _Amount = TotalAmount(_oEmployeeAllowances, "Supervisor/Staff");
                doc.SetParameterValue("AmountInWord", _oTElLib.TakaWords(_Amount));

                frmPrintPreview frmView;
                frmView = new frmPrintPreview();
                frmView.ShowDialog(doc);
            }
            this.Cursor = Cursors.Default;
        }

        private void PayrollPrintSupervisor(HRPayroll oHRPayroll, bool _bSalaryTyep)
        {
            _oTElLib = new TELLib();
            this.Cursor = Cursors.WaitCursor;
            EmployeeAllowances _oEmployeeAllowances = new EmployeeAllowances();
            _oEmployeeAllowances.RefreshPayrollID(oHRPayroll.PayrollID, oHRPayroll.TMonth, oHRPayroll.TYear, oHRPayroll.CompanyID, _bSalaryTyep, false, rdoDepartmentWise.Checked);

            if (oHRPayroll.CompanyID == (int)Dictionary.CompanyID.TEL)
            {
                if (rdoDepartmentWise.Checked == true)
                {
                    rptPayrollStaff_TEL doc;
                    doc = new rptPayrollStaff_TEL();
                    doc.SetDataSource(_oEmployeeAllowances);
                    string _sType = Enum.GetName(typeof(Dictionary.PayrollType), oHRPayroll.Type);
                    doc.SetParameterValue("Type", _sType);
                    string _sMonth = Enum.GetName(typeof(Dictionary.MonthShortName), oHRPayroll.TMonth);
                    doc.SetParameterValue("Month", _sMonth + " - " + oHRPayroll.TYear.ToString());
                    doc.SetParameterValue("User", Utility.UserFullname);
                    doc.SetParameterValue("Company", oHRPayroll.CompanyName);

                    double _Amount = TotalAmount(_oEmployeeAllowances, "Supervisor/Staff");
                    doc.SetParameterValue("AmountInWord", _oTElLib.TakaWords(_Amount));

                    frmPrintPreview frmView;
                    frmView = new frmPrintPreview();
                    frmView.ShowDialog(doc);
                }
                else
                {
                    rptPayrollStaff_TEL_E doc;
                    doc = new rptPayrollStaff_TEL_E();
                    doc.SetDataSource(_oEmployeeAllowances);
                    string _sType = Enum.GetName(typeof(Dictionary.PayrollType), oHRPayroll.Type);
                    doc.SetParameterValue("Type", _sType);
                    string _sMonth = Enum.GetName(typeof(Dictionary.MonthShortName), oHRPayroll.TMonth);
                    doc.SetParameterValue("Month", _sMonth + " - " + oHRPayroll.TYear.ToString());
                    doc.SetParameterValue("User", Utility.UserFullname);
                    doc.SetParameterValue("Company", oHRPayroll.CompanyName);

                    double _Amount = TotalAmount(_oEmployeeAllowances, "Supervisor/Staff");
                    doc.SetParameterValue("AmountInWord", _oTElLib.TakaWords(_Amount));

                    frmPrintPreview frmView;
                    frmView = new frmPrintPreview();
                    frmView.ShowDialog(doc);
                }
            }
            else if (oHRPayroll.CompanyID == (int)Dictionary.CompanyID.BEIL)
            {
                if (rdoDepartmentWise.Checked == true)
                {
                    rptPayrollSupervisor_BEIL doc;
                    doc = new rptPayrollSupervisor_BEIL();
                    doc.SetDataSource(_oEmployeeAllowances);
                    string _sType = Enum.GetName(typeof(Dictionary.PayrollType), oHRPayroll.Type);
                    doc.SetParameterValue("Type", _sType);
                    string _sMonth = Enum.GetName(typeof(Dictionary.MonthShortName), oHRPayroll.TMonth);
                    doc.SetParameterValue("Month", _sMonth + " - " + oHRPayroll.TYear.ToString());
                    doc.SetParameterValue("User", Utility.UserFullname);
                    doc.SetParameterValue("Company", oHRPayroll.CompanyName);

                    double _Amount = TotalAmount(_oEmployeeAllowances, "Supervisor/Staff");
                    doc.SetParameterValue("AmountInWord", _oTElLib.TakaWords(_Amount));

                    frmPrintPreview frmView;
                    frmView = new frmPrintPreview();
                    frmView.ShowDialog(doc);
                }
                else
                {
                    rptPayrollStaff_BEIL_E doc;
                    doc = new rptPayrollStaff_BEIL_E();
                    doc.SetDataSource(_oEmployeeAllowances);
                    string _sType = Enum.GetName(typeof(Dictionary.PayrollType), oHRPayroll.Type);
                    doc.SetParameterValue("Type", _sType);
                    string _sMonth = Enum.GetName(typeof(Dictionary.MonthShortName), oHRPayroll.TMonth);
                    doc.SetParameterValue("Month", _sMonth + " - " + oHRPayroll.TYear.ToString());
                    doc.SetParameterValue("User", Utility.UserFullname);
                    doc.SetParameterValue("Company", oHRPayroll.CompanyName);

                    double _Amount = TotalAmount(_oEmployeeAllowances, "Supervisor/Staff");
                    doc.SetParameterValue("AmountInWord", _oTElLib.TakaWords(_Amount));

                    frmPrintPreview frmView;
                    frmView = new frmPrintPreview();
                    frmView.ShowDialog(doc);
                }
            }
            else
            {
                rptPayrollSupervisor doc;
                doc = new rptPayrollSupervisor();
                doc.SetDataSource(_oEmployeeAllowances);
                string _sType = Enum.GetName(typeof(Dictionary.PayrollType), oHRPayroll.Type);
                doc.SetParameterValue("Type", _sType);
                string _sMonth = Enum.GetName(typeof(Dictionary.MonthShortName), oHRPayroll.TMonth);
                doc.SetParameterValue("Month", _sMonth + " - " + oHRPayroll.TYear.ToString());
                doc.SetParameterValue("User", Utility.UserFullname);
                doc.SetParameterValue("Company", oHRPayroll.CompanyName);

                double _Amount = TotalAmount(_oEmployeeAllowances, "Supervisor/Staff");
                doc.SetParameterValue("AmountInWord", _oTElLib.TakaWords(_Amount));

                frmPrintPreview frmView;
                frmView = new frmPrintPreview();
                frmView.ShowDialog(doc);
            }
            this.Cursor = Cursors.Default;
        }

        private void PaySlipPrint(HRPayroll oHRPayroll, bool _bSalaryTyep)
        {
            _oTElLib = new TELLib();
            this.Cursor = Cursors.WaitCursor;
            EmployeeAllowances _oEmployeeAllowances = new EmployeeAllowances();
            _oEmployeeAllowances.RefreshPayrollID(oHRPayroll.PayrollID, oHRPayroll.TMonth, oHRPayroll.TYear, oHRPayroll.CompanyID, _bSalaryTyep, false, rdoDepartmentWise.Checked);
            rptPaySlip doc;
            doc = new rptPaySlip();
            doc.SetDataSource(_oEmployeeAllowances);
            string _sType = Enum.GetName(typeof(Dictionary.PayrollType), oHRPayroll.Type);
            //doc.SetParameterValue("Type", _sType);
            //string _sMonth = Enum.GetName(typeof(Dictionary.MonthShortName), oHRPayroll.TMonth);
            //doc.SetParameterValue("Month", _sMonth + " - " + oHRPayroll.TYear.ToString());
            //doc.SetParameterValue("User", Utility.UserFullname);
            doc.SetParameterValue("Company", oHRPayroll.CompanyName);
            _oCompany = new Company();
            _oCompany.CompanyID = oHRPayroll.CompanyID;
            _oCompany.Refresh();
            doc.SetParameterValue("CompanyAddress", _oCompany.Address + ". Tel: " + _oCompany.Telephone + ", Fax: " + _oCompany.FAX + ", E-mail: " + _oCompany.Email);
            //doc.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperEnvelope10;
            //doc.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)GetPapersizeID;
            //int x = (8 * 4);
            //doc.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)x;
            //doc.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;


            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);

            this.Cursor = Cursors.Default;
        }

        private void PaySlipStaff_Sup_Print(HRPayroll oHRPayroll, bool _bSalaryTyep)
        {
            _oTElLib = new TELLib();
            this.Cursor = Cursors.WaitCursor;
            EmployeeAllowances _oEmployeeAllowances = new EmployeeAllowances();
            _oEmployeeAllowances.RefreshPayrollID(oHRPayroll.PayrollID, oHRPayroll.TMonth, oHRPayroll.TYear, oHRPayroll.CompanyID, _bSalaryTyep, false, rdoDepartmentWise.Checked);

            if (oHRPayroll.CompanyID == (int)Dictionary.CompanyID.BEIL)
            {
                rptPaySlipStaffSup_BEIL doc;
                doc = new rptPaySlipStaffSup_BEIL();
                doc.SetDataSource(_oEmployeeAllowances);
                string _sType = Enum.GetName(typeof(Dictionary.PayrollType), oHRPayroll.Type);
                doc.SetParameterValue("Type", _sType);
                string _sMonth = Enum.GetName(typeof(Dictionary.MonthShortName), oHRPayroll.TMonth);
                doc.SetParameterValue("Month", _sMonth + " - " + oHRPayroll.TYear.ToString());
                doc.SetParameterValue("User", Utility.UserFullname);
                doc.SetParameterValue("Company", oHRPayroll.CompanyName);
                _oCompany = new Company();
                _oCompany.CompanyID = oHRPayroll.CompanyID;
                _oCompany.Refresh();
                doc.SetParameterValue("CompanyAddress", _oCompany.Address + ". Tel: " + _oCompany.Telephone + ", Fax: " + _oCompany.FAX + ", E-mail: " + _oCompany.Email);

                frmPrintPreview frmView;
                frmView = new frmPrintPreview();
                frmView.ShowDialog(doc);
            }
            else
            {
                rptPaySlipStaffSup doc;
                doc = new rptPaySlipStaffSup();
                doc.SetDataSource(_oEmployeeAllowances);
                string _sType = Enum.GetName(typeof(Dictionary.PayrollType), oHRPayroll.Type);
                doc.SetParameterValue("Type", _sType);
                string _sMonth = Enum.GetName(typeof(Dictionary.MonthShortName), oHRPayroll.TMonth);
                doc.SetParameterValue("Month", _sMonth + " - " + oHRPayroll.TYear.ToString());
                doc.SetParameterValue("User", Utility.UserFullname);
                doc.SetParameterValue("Company", oHRPayroll.CompanyName);
                _oCompany = new Company();
                _oCompany.CompanyID = oHRPayroll.CompanyID;
                _oCompany.Refresh();
                doc.SetParameterValue("CompanyAddress", _oCompany.Address + ". Tel: " + _oCompany.Telephone + ", Fax: " + _oCompany.FAX + ", E-mail: " + _oCompany.Email);
                //doc.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperEnvelope10;
                //doc.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)GetPapersizeID;
                //int x = (8 * 4);
                //doc.PrintOptions.PaperSize = (CrystalDecisions.Shared.PaperSize)x;
                //doc.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape;


                frmPrintPreview frmView;
                frmView = new frmPrintPreview();
                frmView.ShowDialog(doc);
            }

            this.Cursor = Cursors.Default;
        }

        private void PayrollPrintOfficerCashPart(HRPayroll oHRPayroll, bool _bSalaryTyep)
        {
            _oTElLib = new TELLib();
            this.Cursor = Cursors.WaitCursor;
            EmployeeAllowances _oEmployeeAllowances = new EmployeeAllowances();
            _oEmployeeAllowances.RefreshPayrollID(oHRPayroll.PayrollID, oHRPayroll.TMonth, oHRPayroll.TYear, oHRPayroll.CompanyID, _bSalaryTyep, true, rdoDepartmentWise.Checked);
            //rptPayrollOfficerCashPartWithDept doc;
            //doc = new rptPayrollOfficerCashPartWithDept();
            if (oHRPayroll.CompanyID == (int)Dictionary.CompanyID.TEL)
            {
                if (rdoDepartmentWise.Checked == true)
                {
                    rptPayrollOfficerCashPartlegal_TEL doc;
                    doc = new rptPayrollOfficerCashPartlegal_TEL();
                    doc.SetDataSource(_oEmployeeAllowances);
                    string _sType = Enum.GetName(typeof(Dictionary.PayrollType), oHRPayroll.Type);
                    doc.SetParameterValue("Type", _sType);
                    string _sMonth = Enum.GetName(typeof(Dictionary.MonthShortName), oHRPayroll.TMonth);
                    doc.SetParameterValue("Month", _sMonth + " - " + oHRPayroll.TYear.ToString());
                    doc.SetParameterValue("User", Utility.UserFullname);
                    doc.SetParameterValue("Company", oHRPayroll.CompanyName);

                    double _Amount = TotalAmountTEL(_oEmployeeAllowances, "OfficerCash");
                    doc.SetParameterValue("AmountInWord", _oTElLib.TakaWords(_Amount));

                    frmPrintPreview frmView;
                    frmView = new frmPrintPreview();
                    frmView.ShowDialog(doc);
                }
                else
                {
                    rptPayrollOfficerCashPartlegal_TEL_E doc;
                    doc = new rptPayrollOfficerCashPartlegal_TEL_E();
                    doc.SetDataSource(_oEmployeeAllowances);
                    string _sType = Enum.GetName(typeof(Dictionary.PayrollType), oHRPayroll.Type);
                    doc.SetParameterValue("Type", _sType);
                    string _sMonth = Enum.GetName(typeof(Dictionary.MonthShortName), oHRPayroll.TMonth);
                    doc.SetParameterValue("Month", _sMonth + " - " + oHRPayroll.TYear.ToString());
                    doc.SetParameterValue("User", Utility.UserFullname);
                    doc.SetParameterValue("Company", oHRPayroll.CompanyName);

                    double _Amount = TotalAmountTEL(_oEmployeeAllowances, "OfficerCash");
                    doc.SetParameterValue("AmountInWord", _oTElLib.TakaWords(_Amount));

                    frmPrintPreview frmView;
                    frmView = new frmPrintPreview();
                    frmView.ShowDialog(doc);
                }
            }
            else if (oHRPayroll.CompanyID == (int)Dictionary.CompanyID.BEIL)
            {
                if (rdoDepartmentWise.Checked == true)
                {
                    rptPayrollOfficerCashPartlegal_BEIL doc;
                    doc = new rptPayrollOfficerCashPartlegal_BEIL();
                    doc.SetDataSource(_oEmployeeAllowances);
                    string _sType = Enum.GetName(typeof(Dictionary.PayrollType), oHRPayroll.Type);
                    doc.SetParameterValue("Type", _sType);
                    string _sMonth = Enum.GetName(typeof(Dictionary.MonthShortName), oHRPayroll.TMonth);
                    doc.SetParameterValue("Month", _sMonth + " - " + oHRPayroll.TYear.ToString());
                    doc.SetParameterValue("User", Utility.UserFullname);
                    doc.SetParameterValue("Company", oHRPayroll.CompanyName);

                    double _Amount = TotalAmount(_oEmployeeAllowances, "OfficerCash");
                    doc.SetParameterValue("AmountInWord", _oTElLib.TakaWords(_Amount));

                    frmPrintPreview frmView;
                    frmView = new frmPrintPreview();
                    frmView.ShowDialog(doc);
                }
                else
                {
                    rptPayrollOfficerCashPartlegal_BEIL_E doc;
                    doc = new rptPayrollOfficerCashPartlegal_BEIL_E();
                    doc.SetDataSource(_oEmployeeAllowances);
                    string _sType = Enum.GetName(typeof(Dictionary.PayrollType), oHRPayroll.Type);
                    doc.SetParameterValue("Type", _sType);
                    string _sMonth = Enum.GetName(typeof(Dictionary.MonthShortName), oHRPayroll.TMonth);
                    doc.SetParameterValue("Month", _sMonth + " - " + oHRPayroll.TYear.ToString());
                    doc.SetParameterValue("User", Utility.UserFullname);
                    doc.SetParameterValue("Company", oHRPayroll.CompanyName);

                    double _Amount = TotalAmount(_oEmployeeAllowances, "OfficerCash");
                    doc.SetParameterValue("AmountInWord", _oTElLib.TakaWords(_Amount));

                    frmPrintPreview frmView;
                    frmView = new frmPrintPreview();
                    frmView.ShowDialog(doc);
                }
            }

             if (oHRPayroll.CompanyCode == "GAL")//
            {
                if (rdoDepartmentWise.Checked == true)
                {
                    rptPayrollOfficerCashPartlegal_TEL doc;
                    doc = new rptPayrollOfficerCashPartlegal_TEL();
                    doc.SetDataSource(_oEmployeeAllowances);
                    string _sType = Enum.GetName(typeof(Dictionary.PayrollType), oHRPayroll.Type);
                    doc.SetParameterValue("Type", _sType);
                    string _sMonth = Enum.GetName(typeof(Dictionary.MonthShortName), oHRPayroll.TMonth);
                    doc.SetParameterValue("Month", _sMonth + " - " + oHRPayroll.TYear.ToString());
                    doc.SetParameterValue("User", Utility.UserFullname);
                    doc.SetParameterValue("Company", oHRPayroll.CompanyName);

                    double _Amount = TotalAmountTEL(_oEmployeeAllowances, "OfficerCash");
                    doc.SetParameterValue("AmountInWord", _oTElLib.TakaWords(_Amount));

                    frmPrintPreview frmView;
                    frmView = new frmPrintPreview();
                    frmView.ShowDialog(doc);
                }
                else
                {
                    rptPayrollOfficerCashPartlegal_TEL_E doc;
                    doc = new rptPayrollOfficerCashPartlegal_TEL_E();
                    doc.SetDataSource(_oEmployeeAllowances);
                    string _sType = Enum.GetName(typeof(Dictionary.PayrollType), oHRPayroll.Type);
                    doc.SetParameterValue("Type", _sType);
                    string _sMonth = Enum.GetName(typeof(Dictionary.MonthShortName), oHRPayroll.TMonth);
                    doc.SetParameterValue("Month", _sMonth + " - " + oHRPayroll.TYear.ToString());
                    doc.SetParameterValue("User", Utility.UserFullname);
                    doc.SetParameterValue("Company", oHRPayroll.CompanyName);

                    double _Amount = TotalAmountTEL(_oEmployeeAllowances, "OfficerCash");
                    doc.SetParameterValue("AmountInWord", _oTElLib.TakaWords(_Amount));

                    frmPrintPreview frmView;
                    frmView = new frmPrintPreview();
                    frmView.ShowDialog(doc);
                }
            }
            this.Cursor = Cursors.Default;
        }


        private void PayrollPrintOfficerCashPart_new(HRPayroll oHRPayroll, bool _bSalaryTyep)
        {
            _oTElLib = new TELLib();
            this.Cursor = Cursors.WaitCursor;
            EmployeeAllowances _oEmployeeAllowances = new EmployeeAllowances();
            _oEmployeeAllowances.RefreshPayrollID(oHRPayroll.PayrollID, oHRPayroll.TMonth, oHRPayroll.TYear, oHRPayroll.CompanyID, _bSalaryTyep, true, rdoDepartmentWise.Checked);
            
                //rptPayrollOfficerCashPartlegal doc;
                //doc = new rptPayrollOfficerCashPartlegal();
                if (rbLunch.Checked == true)
                {
                    rptLunchOfficer doc;
                    doc = new rptLunchOfficer();
                    doc.SetDataSource(_oEmployeeAllowances);
                    string _sType = Enum.GetName(typeof(Dictionary.PayrollType), oHRPayroll.Type);
                    doc.SetParameterValue("Type", _sType);
                    string _sMonth = Enum.GetName(typeof(Dictionary.MonthShortName), oHRPayroll.TMonth);
                    doc.SetParameterValue("Month", _sMonth + " - " + oHRPayroll.TYear.ToString());
                    doc.SetParameterValue("User", Utility.UserFullname);
                    doc.SetParameterValue("Company", oHRPayroll.CompanyName);

                    double _Amount = TotalAmount_New(_oEmployeeAllowances, "OfficerLunch");
                    doc.SetParameterValue("AmountInWord", _oTElLib.TakaWords(_Amount));

                    frmPrintPreview frmView;
                    frmView = new frmPrintPreview();
                    frmView.ShowDialog(doc);
                
            }
            else if(rbCar.Checked==true)
            {
                rptCarOfficer doc;
                doc = new rptCarOfficer();
                doc.SetDataSource(_oEmployeeAllowances);
                string _sType = Enum.GetName(typeof(Dictionary.PayrollType), oHRPayroll.Type);
                doc.SetParameterValue("Type", _sType);
                string _sMonth = Enum.GetName(typeof(Dictionary.MonthShortName), oHRPayroll.TMonth);
                doc.SetParameterValue("Month", _sMonth + " - " + oHRPayroll.TYear.ToString());
                doc.SetParameterValue("User", Utility.UserFullname);
                doc.SetParameterValue("Company", oHRPayroll.CompanyName);

                double _Amount = TotalAmount_New(_oEmployeeAllowances, "OfficerCar");
                doc.SetParameterValue("AmountInWord", _oTElLib.TakaWords(_Amount));

                frmPrintPreview frmView;
                frmView = new frmPrintPreview();
                frmView.ShowDialog(doc);

            }
            else if (rbServant.Checked == true)
            {
                rptServantOfficer doc;
                doc = new rptServantOfficer();
                doc.SetDataSource(_oEmployeeAllowances);
                string _sType = Enum.GetName(typeof(Dictionary.PayrollType), oHRPayroll.Type);
                doc.SetParameterValue("Type", _sType);
                string _sMonth = Enum.GetName(typeof(Dictionary.MonthShortName), oHRPayroll.TMonth);
                doc.SetParameterValue("Month", _sMonth + " - " + oHRPayroll.TYear.ToString());
                doc.SetParameterValue("User", Utility.UserFullname);
                doc.SetParameterValue("Company", oHRPayroll.CompanyName);

                double _Amount = TotalAmount_New(_oEmployeeAllowances, "OfficerServant");
                doc.SetParameterValue("AmountInWord", _oTElLib.TakaWords(_Amount));

                frmPrintPreview frmView;
                frmView = new frmPrintPreview();
                frmView.ShowDialog(doc);

            }
            else if (rbDriver.Checked == true)
            {
                rptDriverOfficer doc;
                doc = new rptDriverOfficer();
                doc.SetDataSource(_oEmployeeAllowances);
                string _sType = Enum.GetName(typeof(Dictionary.PayrollType), oHRPayroll.Type);
                doc.SetParameterValue("Type", _sType);
                string _sMonth = Enum.GetName(typeof(Dictionary.MonthShortName), oHRPayroll.TMonth);
                doc.SetParameterValue("Month", _sMonth + " - " + oHRPayroll.TYear.ToString());
                doc.SetParameterValue("User", Utility.UserFullname);
                doc.SetParameterValue("Company", oHRPayroll.CompanyName);

                double _Amount = TotalAmount_New(_oEmployeeAllowances, "OfficerDriver");
                doc.SetParameterValue("AmountInWord", _oTElLib.TakaWords(_Amount));

                frmPrintPreview frmView;
                frmView = new frmPrintPreview();
                frmView.ShowDialog(doc);

            }
            this.Cursor = Cursors.Default;
        }

        private double TotalAmount(EmployeeAllowances _oEmployeeAllowances, string sType)
        {
            double _Amount = 0;

            foreach (EmployeeAllowance oHRPayrollAllow in _oEmployeeAllowances)
            {
                if (sType == "OfficerCash")
                {
                    _Amount = _Amount + oHRPayrollAllow.HouseMaintenance + oHRPayrollAllow.UtilityExpense + oHRPayrollAllow.Lunch + oHRPayrollAllow.DriverExpense + oHRPayrollAllow.ServentExpense;
                }
                else if (sType == "OfficerBank")
                {
                    _Amount = _Amount + (oHRPayrollAllow.BasicSalary + oHRPayrollAllow.ConsolidateSalary + oHRPayrollAllow.HouseRent + oHRPayrollAllow.MedicalAllowanceforStaff + oHRPayrollAllow.CarAllowance + oHRPayrollAllow.Conveyance + oHRPayrollAllow.EntertainmentAllowance + oHRPayrollAllow.FestivalBonus + oHRPayrollAllow.SpecialAllowance + oHRPayrollAllow.OtherExpense) - (oHRPayrollAllow.PF + oHRPayrollAllow.PFLoanPrincipal + oHRPayrollAllow.PFLoanInterest + oHRPayrollAllow.ArticleLoanTV + oHRPayrollAllow.ArticleLoanRef + oHRPayrollAllow.ArticleLoanAC + oHRPayrollAllow.EmergencyLoan + oHRPayrollAllow.EPSLoan + oHRPayrollAllow.AdvanceSalary + oHRPayrollAllow.AITSalary + oHRPayrollAllow.MobileBill + oHRPayrollAllow.OtherDeduction);
                }
                else if (sType == "Supervisor/Staff")
                {
                    _Amount = _Amount + (oHRPayrollAllow.BasicSalary + oHRPayrollAllow.ConsolidateSalary + oHRPayrollAllow.HouseRent + oHRPayrollAllow.MedicalAllowanceforStaff + oHRPayrollAllow.EntertainmentAllowance + oHRPayrollAllow.Conveyance + oHRPayrollAllow.SpecialAllowance + oHRPayrollAllow.RotatingShift + oHRPayrollAllow.NonRotatingShift + oHRPayrollAllow.LFA + oHRPayrollAllow.FestivalBonus + oHRPayrollAllow.OverTime + oHRPayrollAllow.Lunch + oHRPayrollAllow.NightShiftAllowance + oHRPayrollAllow.ChildEducationAllowance + oHRPayrollAllow.OtherExpense + oHRPayrollAllow.HouseMaintenance +
                    oHRPayrollAllow.UtilityExpense + oHRPayrollAllow.DriverExpense + oHRPayrollAllow.ServentExpense + oHRPayrollAllow.CarAllowance + oHRPayrollAllow.CanteenExpense) - (oHRPayrollAllow.PF + oHRPayrollAllow.PFLoanPrincipal + oHRPayrollAllow.PFLoanInterest + oHRPayrollAllow.ArticleLoanTV + oHRPayrollAllow.ArticleLoanRef + oHRPayrollAllow.ArticleLoanAC + oHRPayrollAllow.EmergencyLoan + oHRPayrollAllow.EPSLoan + oHRPayrollAllow.BuildingLoanPrincipal + oHRPayrollAllow.BuildingLoanInterest + oHRPayrollAllow.AdvanceSalary + oHRPayrollAllow.AITSalary + oHRPayrollAllow.MobileBill + oHRPayrollAllow.OtherDeduction);

                }

            }

            return _Amount;
        }
        private double TotalAmountTEL(EmployeeAllowances _oEmployeeAllowances, string sType)
        {
            double _Amount = 0;

            foreach (EmployeeAllowance oHRPayrollAllow in _oEmployeeAllowances)
            {
                if (sType == "OfficerCash")
                {
                    _Amount = _Amount + oHRPayrollAllow.HouseMaintenance + oHRPayrollAllow.UtilityExpense + oHRPayrollAllow.Lunch + oHRPayrollAllow.DriverExpense + oHRPayrollAllow.ServentExpense + oHRPayrollAllow.CarAllowance + oHRPayrollAllow.OtherExpense;
                }
                else if (sType == "OfficerBank")
                {
                    _Amount = _Amount + (oHRPayrollAllow.BasicSalary + oHRPayrollAllow.ConsolidateSalary + oHRPayrollAllow.HouseRent + oHRPayrollAllow.MedicalAllowanceforStaff + oHRPayrollAllow.Conveyance + oHRPayrollAllow.EntertainmentAllowance + oHRPayrollAllow.FestivalBonus + oHRPayrollAllow.SpecialAllowance) - (oHRPayrollAllow.PF + oHRPayrollAllow.PFLoanPrincipal + oHRPayrollAllow.PFLoanInterest + oHRPayrollAllow.ArticleLoanTV + oHRPayrollAllow.ArticleLoanRef + oHRPayrollAllow.ArticleLoanAC + oHRPayrollAllow.EmergencyLoan + oHRPayrollAllow.EPSLoan + oHRPayrollAllow.AdvanceSalary + oHRPayrollAllow.AITSalary + oHRPayrollAllow.MobileBill + oHRPayrollAllow.OtherDeduction);
                }
                else if (sType == "Supervisor/Staff")
                {
                    _Amount = _Amount + (oHRPayrollAllow.BasicSalary + oHRPayrollAllow.ConsolidateSalary + oHRPayrollAllow.HouseRent + oHRPayrollAllow.MedicalAllowanceforStaff + oHRPayrollAllow.EntertainmentAllowance + oHRPayrollAllow.Conveyance + oHRPayrollAllow.SpecialAllowance + oHRPayrollAllow.RotatingShift + oHRPayrollAllow.NonRotatingShift + oHRPayrollAllow.LFA + oHRPayrollAllow.FestivalBonus + oHRPayrollAllow.OverTime + oHRPayrollAllow.Lunch + oHRPayrollAllow.NightShiftAllowance + oHRPayrollAllow.ChildEducationAllowance + oHRPayrollAllow.OtherExpense + oHRPayrollAllow.HouseMaintenance +
                    oHRPayrollAllow.UtilityExpense + oHRPayrollAllow.DriverExpense + oHRPayrollAllow.ServentExpense + oHRPayrollAllow.CarAllowance + oHRPayrollAllow.CanteenExpense) - (oHRPayrollAllow.PF + oHRPayrollAllow.PFLoanPrincipal + oHRPayrollAllow.PFLoanInterest + oHRPayrollAllow.ArticleLoanTV + oHRPayrollAllow.ArticleLoanRef + oHRPayrollAllow.ArticleLoanAC + oHRPayrollAllow.EmergencyLoan + oHRPayrollAllow.EPSLoan + oHRPayrollAllow.BuildingLoanPrincipal + oHRPayrollAllow.BuildingLoanInterest + oHRPayrollAllow.AdvanceSalary + oHRPayrollAllow.AITSalary + oHRPayrollAllow.MobileBill + oHRPayrollAllow.OtherDeduction);

                }

            }

            return _Amount;
        }
        private double TotalAmount_New(EmployeeAllowances _oEmployeeAllowances, string sType)
        {
            double _Amount = 0;

            foreach (EmployeeAllowance oHRPayrollAllow in _oEmployeeAllowances)
            {
                if (sType == "OfficerLunch")
                {
                    _Amount = _Amount + oHRPayrollAllow.Lunch;
                }
                else if (sType == "OfficerCar")
                {
                    _Amount = _Amount + oHRPayrollAllow.CarAllowance;
                }
                else if (sType == "OfficerDriver")
                {
                    _Amount = _Amount + oHRPayrollAllow.DriverExpense;
                }
                else if (sType == "OfficerServant")
                {
                    _Amount = _Amount + oHRPayrollAllow.ServentExpense;
                }
                else if (sType == "OfficerBank")
                {
                    _Amount = _Amount + (oHRPayrollAllow.BasicSalary + oHRPayrollAllow.ConsolidateSalary + oHRPayrollAllow.HouseRent + oHRPayrollAllow.MedicalAllowanceforStaff + oHRPayrollAllow.HouseMaintenance + oHRPayrollAllow.UtilityExpense + oHRPayrollAllow.Conveyance + oHRPayrollAllow.EntertainmentAllowance + oHRPayrollAllow.FestivalBonus + oHRPayrollAllow.SpecialAllowance + oHRPayrollAllow.OtherExpense) - (oHRPayrollAllow.PF + oHRPayrollAllow.PFLoanPrincipal + oHRPayrollAllow.PFLoanInterest + oHRPayrollAllow.ArticleLoanTV + oHRPayrollAllow.ArticleLoanRef + oHRPayrollAllow.ArticleLoanAC + oHRPayrollAllow.EmergencyLoan + oHRPayrollAllow.EPSLoan + oHRPayrollAllow.AdvanceSalary + oHRPayrollAllow.AITSalary + oHRPayrollAllow.MobileBill + oHRPayrollAllow.OtherDeduction);
                }
                else if (sType == "Supervisor/Staff")
                {
                    _Amount = _Amount + (oHRPayrollAllow.BasicSalary + oHRPayrollAllow.ConsolidateSalary + oHRPayrollAllow.HouseRent + oHRPayrollAllow.MedicalAllowanceforStaff + oHRPayrollAllow.EntertainmentAllowance + oHRPayrollAllow.Conveyance + oHRPayrollAllow.SpecialAllowance + oHRPayrollAllow.RotatingShift + oHRPayrollAllow.NonRotatingShift + oHRPayrollAllow.LFA + oHRPayrollAllow.FestivalBonus + oHRPayrollAllow.OverTime + oHRPayrollAllow.Lunch + oHRPayrollAllow.NightShiftAllowance + oHRPayrollAllow.ChildEducationAllowance + oHRPayrollAllow.OtherExpense + oHRPayrollAllow.HouseMaintenance +
                    oHRPayrollAllow.UtilityExpense + oHRPayrollAllow.DriverExpense + oHRPayrollAllow.ServentExpense + oHRPayrollAllow.CarAllowance + oHRPayrollAllow.CanteenExpense) - (oHRPayrollAllow.PF + oHRPayrollAllow.PFLoanPrincipal + oHRPayrollAllow.PFLoanInterest + oHRPayrollAllow.ArticleLoanTV + oHRPayrollAllow.ArticleLoanRef + oHRPayrollAllow.ArticleLoanAC + oHRPayrollAllow.EmergencyLoan + oHRPayrollAllow.EPSLoan + oHRPayrollAllow.BuildingLoanPrincipal + oHRPayrollAllow.BuildingLoanInterest + oHRPayrollAllow.AdvanceSalary + oHRPayrollAllow.AITSalary + oHRPayrollAllow.MobileBill + oHRPayrollAllow.OtherDeduction);

                }

            }

            return _Amount;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;

namespace CJ.Win
{
    public partial class frmOutletCommissionProcess : Form
    {
        DSOutletCommission oDSOutletCommissionManager;
        DSOutletCommission oDSOutletCommissionExecutive;

        public frmOutletCommissionProcess()
        {
            InitializeComponent();
        }

        private void frmOutletCommissionProcess_Load(object sender, EventArgs e)
        {
            dtCommitionDate.Value = DateTime.Now.Date;
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                pbProcess.Visible = true;
                pbProcess.Minimum = 0;
                pbProcess.Maximum = 1;
                pbProcess.Step = 2;
                pbProcess.Value = 0;

                OutletCommission oOutletCommission = new OutletCommission();
                DBController.Instance.OpenNewConnection();
                try
                {
                    int nYear = Convert.ToInt32(dtCommitionDate.Value.Year);
                    int nMonth = Convert.ToInt32(dtCommitionDate.Value.Month);
                    double _ExeTotalAmt = 0;
                    double _MgrTotalAmt = 0;
                    double _SATotalAmt = 0;

                    _ExeTotalAmt = oOutletCommission.GetExecutiveCommission(nMonth, nYear);
                    oOutletCommission.YearNo = nYear;
                    oOutletCommission.MonthNo = nMonth;
                    oOutletCommission.TotalAmount = _ExeTotalAmt;
                    oOutletCommission.Type = Convert.ToInt32(Dictionary.OutletEmployeeType.Executive);
                    oOutletCommission.CreateUserID = Utility.UserId;
                    oOutletCommission.CreateDate = DateTime.Now;
                    oOutletCommission.Remarks = txtRemarks.Text;
                    oOutletCommission.Status = (int)Dictionary.CommissionStatus.Create;

                   


                    OutletCommission oOCManager = new OutletCommission();
                    _MgrTotalAmt = oOCManager.GetManagerCommission(nMonth, nYear);
                    oOCManager.YearNo = nYear;
                    oOCManager.MonthNo = nMonth;
                    oOCManager.TotalAmount = _MgrTotalAmt;
                    oOCManager.Type = Convert.ToInt32(Dictionary.OutletEmployeeType.Manager);
                    oOCManager.CreateUserID = Utility.UserId;
                    oOCManager.CreateDate = DateTime.Now;
                    oOCManager.Remarks = txtRemarks.Text;
                    oOCManager.Status = (int)Dictionary.CommissionStatus.Create; 

                    


                    OutletCommission oOCShopAssistant = new OutletCommission();
                    _SATotalAmt =oOCShopAssistant.GetAssistCommission(nMonth, nYear);
                    oOCShopAssistant.YearNo = nYear;
                    oOCShopAssistant.MonthNo = nMonth;
                    oOCShopAssistant.TotalAmount = _SATotalAmt;
                    oOCShopAssistant.Type = Convert.ToInt32(Dictionary.OutletEmployeeType.ShopAssistant);
                    oOCShopAssistant.CreateUserID = Utility.UserId;
                    oOCShopAssistant.CreateDate = DateTime.Now;
                    oOCShopAssistant.Remarks = txtRemarks.Text;
                    oOCShopAssistant.Status = (int)Dictionary.CommissionStatus.Create;


                    oDSOutletCommissionManager = SetByInvoiceDeductionManager(nYear, nMonth);
                    oDSOutletCommissionExecutive = SetByInvoiceDeductionSE(nYear, nMonth);



                    DBController.Instance.BeginNewTransaction();
                    oOutletCommission.Add();

                    OutletCommission oOCExecutive = new OutletCommission();
                    oOCExecutive.GetCommDetail(nYear, nMonth, oOutletCommission.Type);

                    foreach (OutletCommissionDetail oOCD in oOCExecutive)
                    {
                          
                     double  AdditionCommOtherExecutive =  oOCD.GetAdditionCommOtherExecutive(oOCD.LocationID, nYear, nMonth, oOCD.EMPProductGroup);
                     oOCD.UpdateAdditionCommOtherExecutive(AdditionCommOtherExecutive, oOCD.ID, oOCD.EmployeeID);

                     //double _ByInvoiceAmount = GetByInvoiceDeductionExe(oDSOutletCommissionExecutive, oOCD.EmployeeID, oOCD.EMPProductGroup, oOCD.AchSlab, oOCD.MinCommPercent);
                     //oOCD.UpdateByInvoiceExecutive(_ByInvoiceAmount, oOCD.ID, oOCD.EmployeeID);

                    }

 
                    oOCManager.Add();

                    oOCShopAssistant.Add();


                    DBController.Instance.CommitTran();

                    pbProcess.PerformStep();
                    MessageBox.Show("Success!");
                    pbProcess.Visible = false;
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(" Error" + ex);
                }


            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show("Error" + ex);
            }
        }
        private void GetByInvoiceDeductionManager()
        { 
        

        }
        private double GetByInvoiceDeductionExe(DSOutletCommission oDSOutletCommission, int nSalesPersonID, string sProductGroup, double _AchSlab, double _MinSlab)
        {
            double _Value = 0;

            DSOutletCommission oDSFilteredData = new DSOutletCommission();
            DataRow[] oDRExe = oDSOutletCommission.Commission.Select(" SalesPersonID= '" + nSalesPersonID + "'");
            oDSFilteredData.Merge(oDRExe);
            oDSFilteredData.AcceptChanges();
            
            foreach (DSOutletCommission.CommissionRow oCommissionRow in oDSFilteredData.Commission)
            {
                string _sProductGroup = oCommissionRow.PGName;
                int nDiscountReasonID = oCommissionRow.DiscountReasonID;
                double _DeductPercent = oCommissionRow.DeductPercent;
                double _Amount = oCommissionRow.Amount;

                if (_sProductGroup == sProductGroup)
                {
                    if (nDiscountReasonID > 0)
                    {
                        _Value = _Value + (_Amount * _AchSlab / 2) / 100 * (_DeductPercent / 100);
                    }
                    else
                    {
                        _Value = _Value +  (_Amount * _AchSlab) / 100 * (_DeductPercent / 100);
                    }

                }
                else
                {
                    if (nDiscountReasonID > 0)
                    {
                        _Value = _Value + (_Amount * _MinSlab / 2) / 100 * (_DeductPercent / 100);
                    }
                    else
                    {
                        _Value = _Value +  (_Amount * _MinSlab) / 100 * (_DeductPercent / 100);
                    }

                }

            }


            return _Value;
        }
        private DSOutletCommission SetByInvoiceDeductionManager(int nYear, int nMonth)
        {
            OutletCommission oOC = new OutletCommission();
            oOC.GetDeductDataManager(nYear, nMonth);
            oDSOutletCommissionManager = new DSOutletCommission();
            foreach (OutletCommissionDetail oOCD in oOC)
            {
                DSOutletCommission.CommissionRow oCommissionRow = oDSOutletCommissionManager.Commission.NewCommissionRow();

                oCommissionRow.LocationID = oOCD.LocationID;
                oCommissionRow.PGName = oOCD.ProductGroup;
                oCommissionRow.DiscountReasonID = oOCD.DiscountReasonID;
                oCommissionRow.DeductPercent = oOCD.DeductPercent;
                oCommissionRow.Amount = oOCD.NetSale;

                oDSOutletCommissionManager.Commission.AddCommissionRow(oCommissionRow);
                oDSOutletCommissionManager.AcceptChanges();

            }
            return oDSOutletCommissionManager;
        }
        private DSOutletCommission SetByInvoiceDeductionSE(int nYear, int nMonth)
        {
            OutletCommission oOC = new OutletCommission();
            oOC.GetDeductDataSE(nYear, nMonth);
            oDSOutletCommissionExecutive = new DSOutletCommission();
            foreach (OutletCommissionDetail oOCD in oOC)
            {
                DSOutletCommission.CommissionRow oCommissionRow = oDSOutletCommissionExecutive.Commission.NewCommissionRow();

                oCommissionRow.SalesPersonID = oOCD.EmployeeID;
                oCommissionRow.PGName = oOCD.ProductGroup;
                oCommissionRow.DiscountReasonID = oOCD.DiscountReasonID;
                oCommissionRow.DeductPercent = oOCD.DeductPercent;
                oCommissionRow.Amount = oOCD.NetSale;

                oDSOutletCommissionExecutive.Commission.AddCommissionRow(oCommissionRow);
                oDSOutletCommissionExecutive.AcceptChanges();

            }
            return oDSOutletCommissionExecutive;
        }
    }
}
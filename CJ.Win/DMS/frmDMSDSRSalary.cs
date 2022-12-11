using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.DMS;
using CJ.Class.Report;
using CJ.Report;

namespace CJ.Win.DMS
{
    public partial class frmDMSDSRSalary : Form
    {
        public string ReportType = "";

        DMSDSR oDMSDSR;
        DMSDSRs oDMSDSRs;
        public frmDMSDSRSalary()
        {    
            InitializeComponent();
        }

        public void ShowDialog(DMSDSR oDMSDSR)
        {
            if (rdoAll.Checked = true)
            {
               // PrintType = -1;
                rdoAll.Checked = true;
                rdoPayable.Checked = false;
                rdoHeldup.Checked = false;
            }
            if (rdoPayable.Checked = true)
            {
               // PrintType = 0;
                rdoPayable.Checked = true;
                rdoAll.Checked = false;
                rdoHeldup.Checked = false;
            }
            if (rdoHeldup.Checked = true)
            {
                //PrintType = 1;
                rdoPayable.Checked = true;
                rdoAll.Checked = false;
                rdoHeldup.Checked = false;
            }
        
        }
        private void btnProcess_Click(object sender, EventArgs e)
        {       

            if (validateUIInput())
            {
                DeleteProcessData();
                InsertProcessData();
                LoadData();
            }

        }
        private bool validateUIInput()
        {
            DMSDSR oDMSDSR = new DMSDSR();
            int nYear = Convert.ToInt32(dtSalaryDate.Value.Year);
            int nMonth = Convert.ToInt32(dtSalaryDate.Value.Month);
            DateTime SelectDate = Convert.ToDateTime(dtSalaryDate.Value);
            DateTime CurrentDate = Convert.ToDateTime(DateTime.Today);
            //if (SelectDate > CurrentDate)
            //{
            //    MessageBox.Show(" Advance Salary Can not Process", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;              
            //}

            DBController.Instance.BeginNewTransaction();
            oDMSDSR.CheckSalaryData(nMonth, nYear);
            if (oDMSDSR.DataCount > 0)
            {
                MessageBox.Show(" Salary Already Confirm ! Can't Process", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        
        }
        public void DeleteProcessData()
        {
            oDMSDSR = new DMSDSR();
            int nYear = Convert.ToInt32(dtSalaryDate.Value.Year);
            int nMonth = Convert.ToInt32(dtSalaryDate.Value.Month);
            try
            {
                DBController.Instance.BeginNewTransaction();
                oDMSDSR.DeleteDSRSalary(nMonth, nYear);
                DBController.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }
        public void DeleteProcessData_BasicDetails()
        {
            oDMSDSR = new DMSDSR();
            int nYear = Convert.ToInt32(dtSalaryDate.Value.Year);
            int nMonth = Convert.ToInt32(dtSalaryDate.Value.Month);
            try
            {
                DBController.Instance.BeginNewTransaction();
                oDMSDSR.DeleteDSRSalary_BasicDetails(nMonth, nYear);
                DBController.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }

        public void LoadData()
        {
            pbProcess.Visible = true;
            pbProcess.Minimum = 0;
            pbProcess.Maximum = 1;
            pbProcess.Step = 2;
            pbProcess.Value = 0;

            int nYear = Convert.ToInt32(dtSalaryDate.Value.Year);
            int nMonth = Convert.ToInt32(dtSalaryDate.Value.Month);
            lblYear.Visible = false;
            string TMonth=(dtSalaryDate.Value.ToString("MMM-yyyy"));             
            DBController.Instance.OpenNewConnection();
            oDMSDSRs.RefreshSalary(nMonth, nYear);
            foreach (DMSDSR oDMSDSR in oDMSDSRs)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvDSRSalary);
                oRow.Cells[0].Value = oDMSDSR.TranID;
                oRow.Cells[1].Value = oDMSDSR.DSRID;
                oRow.Cells[2].Value = oDMSDSR.AreaName.ToString();
                oRow.Cells[3].Value = oDMSDSR.CustomerName.ToString();
                oRow.Cells[4].Value = oDMSDSR.DSRCode;
                oRow.Cells[5].Value = oDMSDSR.DSRName.ToString();
                oRow.Cells[6].Value = oDMSDSR.Month;
                oRow.Cells[7].Value = oDMSDSR.Year;
                oRow.Cells[8].Value = oDMSDSR.PaymentMode.ToString();
                oRow.Cells[9].Value = oDMSDSR.PaymentType.ToString();
                oRow.Cells[10].Value = oDMSDSR.WorkingDayActual;
                oRow.Cells[11].Value = oDMSDSR.Ach;
                oRow.Cells[12].Value = oDMSDSR.FixedSalary.ToString();
                oRow.Cells[13].Value = oDMSDSR.VariableSalary.ToString();
                oRow.Cells[14].Value = oDMSDSR.TADA.ToString();
                oRow.Cells[15].Value = oDMSDSR.Others.ToString();
                oRow.Cells[16].Value = oDMSDSR.MobileBill.ToString();
                oRow.Cells[17].Value = oDMSDSR.Deduction.ToString();
                oRow.Cells[18].Value = oDMSDSR.CalculatedSalary.ToString();
                oRow.Cells[19].Value = oDMSDSR.Netpayable.ToString();
                if (oDMSDSR.Status == (int)Dictionary.DSRSalaryStatus.Create)
                {
                    oRow.Cells[20].Value = "Created";
                }
                else oRow.Cells[20].Value = "Approved";                     
                oRow.Cells[21].Value = oDMSDSR.Remarks.ToString();
                oRow.Cells[23].Value = oDMSDSR.Allowance.ToString();
                //oRow.Cells[22].Value = (oDMSDSR.DailyTADA).ToString();
                //if ((oDMSDSR.TotalAllowance / oDMSDSR.WorkingDay) > 0)
                //{
                //    oRow.Cells[23].Value = (oDMSDSR.TotalAllowance / oDMSDSR.WorkingDay);
                //}
                //else oRow.Cells[23].Value = 0;
                //oRow.Cells[24].Value = (oDMSDSR.Others).ToString();
                dgvDSRSalary.Rows.Add(oRow);
                pbProcess.PerformStep();

               dgvDSRSalary.BackgroundColor = Color.LightBlue;              

               
            }
            MessageBox.Show("Data Process Successfully");
            pbProcess.Visible = false;
           

            
        
        }
        public void InsertProcessData()
        {

            oDMSDSRs = new DMSDSRs();
            dgvDSRSalary.Rows.Clear();

            int nYear = Convert.ToInt32(dtSalaryDate.Value.Year);
            int nMonth = Convert.ToInt32(dtSalaryDate.Value.Month);
            DateTime dStartDate = Convert.ToDateTime(dtSalaryDate.Value);
            DateTime dEndDate=Convert.ToDateTime(dtSalaryDate.Value.AddMonths(1));
            DBController.Instance.OpenNewConnection();
            oDMSDSRs.RefreshDSRSalary(nMonth, nYear, dStartDate, dEndDate);
           
            foreach (DMSDSR oDMSDSR in oDMSDSRs)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oDMSDSR.AddDSRSalary();
                    DBController.Instance.CommitTransaction();

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            
            }

                                       
        
        }

        public void InsertBasicProcessData()
        {

            oDMSDSRs = new DMSDSRs();
            dgvDSRSalary.Rows.Clear();

            int nYear = Convert.ToInt32(dtSalaryDate.Value.Year);
            int nMonth = Convert.ToInt32(dtSalaryDate.Value.Month);
            DateTime dStartDate = Convert.ToDateTime(dtSalaryDate.Value);
            DateTime dEndDate = Convert.ToDateTime(dtSalaryDate.Value.AddMonths(1));

            DBController.Instance.OpenNewConnection();
            oDMSDSRs.RefreshDSRBasicSalary(nMonth, nYear, dStartDate, dEndDate);

            foreach (DMSDSR oDMSDSR in oDMSDSRs)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oDMSDSR.AddDSRBasicSalary();
                    oDMSDSR.AddDSRBasicSalaryDetails();
                    DBController.Instance.CommitTransaction();

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }



        }
        public void UpdateProcessData()
        {

           oDMSDSR = new DMSDSR();

            foreach (DataGridViewRow oItemRow in dgvDSRSalary.Rows)
            {

                if (oItemRow.Index < dgvDSRSalary.Rows.Count - 1)
                {                   

                   oDMSDSR.Netpayable = Convert.ToDouble(oItemRow.Cells[19].Value.ToString());
                   oDMSDSR.TranID = Convert.ToInt32(oItemRow.Cells[0].Value.ToString().Trim());
                   oDMSDSR.DSRID = Convert.ToInt32(oItemRow.Cells[1].Value.ToString().Trim());
                   oDMSDSR.Status = (int)Dictionary.DSRSalaryStatus.Approved;
                   oDMSDSR.WorkingDayActual = Convert.ToInt16(oItemRow.Cells[10].Value.ToString().Trim());

                   try
                   {
                       oDMSDSR.Deduction = Convert.ToDouble(oItemRow.Cells[17].Value.ToString());
                   }
                   catch (Exception ex)
                   {
                       oDMSDSR.Deduction = 0;
                   }
                   
                   try
                   {
                       oDMSDSR.Remarks = Convert.ToString(oItemRow.Cells[21].Value.ToString());
                   }
                   catch (Exception ex)
                   {
                       oDMSDSR.Remarks = "";
                   }

                   try
                   {
                       oDMSDSR.TotalTADA = Convert.ToDouble(oItemRow.Cells[13].Value.ToString());
                   }
                   catch (Exception ex)
                   {
                       oDMSDSR.TotalTADA = 0;
                   }

                   try
                   {
                       oDMSDSR.TotalAllowance = Convert.ToDouble(oItemRow.Cells[14].Value.ToString());
                   }
                   catch (Exception ex)
                   {
                       oDMSDSR.TotalAllowance = 0;
                   }

                   try
                   {
                       oDMSDSR.TotalOthers = Convert.ToDouble(oItemRow.Cells[15].Value.ToString());
                   }
                   catch (Exception ex)
                   {
                       oDMSDSR.TotalOthers = 0;
                   }

                   try
                   {                        
                        DBController.Instance.BeginNewTransaction();
                        oDMSDSR.UpdateSalary();
                        DBController.Instance.CommitTransaction();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }


                }

            }

        }

        private void dgvDSRSalary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            refreshRow(e.RowIndex, e.ColumnIndex);

        }
        private void refreshRow(int nRowIndex, int nColumnIndex)
        {
            if (nColumnIndex == 10)
            {


                if (dgvDSRSalary.Rows[nRowIndex].Cells[nColumnIndex].Value != null)
                {
                    dgvDSRSalary.Rows[nRowIndex].Cells[nColumnIndex + 3].Value= ((Convert.ToDouble(dgvDSRSalary.Rows[nRowIndex].Cells[nColumnIndex + 12].Value.ToString()) * Convert.ToDouble(dgvDSRSalary.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString())));
                    dgvDSRSalary.Rows[nRowIndex].Cells[nColumnIndex + 4].Value = ((Convert.ToDouble(dgvDSRSalary.Rows[nRowIndex].Cells[nColumnIndex + 13].Value.ToString()) * Convert.ToDouble(dgvDSRSalary.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString())));
                    dgvDSRSalary.Rows[nRowIndex].Cells[nColumnIndex + 5].Value = ((Convert.ToDouble(dgvDSRSalary.Rows[nRowIndex].Cells[nColumnIndex + 14].Value.ToString()) * Convert.ToDouble(dgvDSRSalary.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString())));
                    dgvDSRSalary.Rows[nRowIndex].Cells[nColumnIndex + 9].Value = (Convert.ToDouble(dgvDSRSalary.Rows[nRowIndex].Cells[nColumnIndex + 2].Value.ToString()) + Convert.ToDouble(dgvDSRSalary.Rows[nRowIndex].Cells[nColumnIndex + 6].Value.ToString()) - Convert.ToDouble(dgvDSRSalary.Rows[nRowIndex].Cells[nColumnIndex + 7].Value.ToString()) + ((Convert.ToDouble(dgvDSRSalary.Rows[nRowIndex].Cells[nColumnIndex + 3].Value.ToString()) + Convert.ToDouble(dgvDSRSalary.Rows[nRowIndex].Cells[nColumnIndex + 4].Value.ToString()) + Convert.ToDouble(dgvDSRSalary.Rows[nRowIndex].Cells[nColumnIndex + 5].Value.ToString())) ));
                                       
                }
            }

            else if (nColumnIndex == 17)
            {
                if (dgvDSRSalary.Rows[nRowIndex].Cells[nColumnIndex].Value != null)
                {
                    dgvDSRSalary.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = (Convert.ToDouble(dgvDSRSalary.Rows[nRowIndex].Cells[nColumnIndex - 5].Value.ToString()) + Convert.ToDouble(dgvDSRSalary.Rows[nRowIndex].Cells[nColumnIndex - 1].Value.ToString()) - Convert.ToDouble(dgvDSRSalary.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString()) + ((Convert.ToDouble(dgvDSRSalary.Rows[nRowIndex].Cells[nColumnIndex - 4].Value.ToString()) + Convert.ToDouble(dgvDSRSalary.Rows[nRowIndex].Cells[nColumnIndex -3].Value.ToString()) + Convert.ToDouble(dgvDSRSalary.Rows[nRowIndex].Cells[nColumnIndex - 2].Value.ToString())) ));
                   
                }
            }

            
            
        }

        private void dgvDSRSalary_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            refreshRow(e.RowIndex, e.ColumnIndex);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            
            UpdateProcessData();
            dgvDSRSalary.Rows.Clear();
            LoadData();
        }

       
        public void Report( string ReportType)
        {

            int nYear = Convert.ToInt32(dtSalaryDate.Value.Year);
            int nMonth = Convert.ToInt32(dtSalaryDate.Value.Month);
            int PrintType = 0;
            string SalaryType = "";
            
            oDMSDSRs = new DMSDSRs();

            if (rdoAll.Checked == true)
            {
                PrintType = -1;
                SalaryType = "All";
            }
            if (rdoPayable.Checked ==true)
            {
                PrintType = 0;
                SalaryType = "Payable";
            }
            if (rdoHeldup.Checked == true)
            {
                PrintType = 1;
                SalaryType = "Held Up";
            }
          
            DBController.Instance.OpenNewConnection(); 
            oDMSDSRs.PrintSalary(nMonth, nYear, PrintType,ReportType);
            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(CJ.Report.DMS.rptDMSDSRSalary));
            doc.SetDataSource(oDMSDSRs);

            doc.SetParameterValue("Company", "Bangladesh Lamps Limited");
            doc.SetParameterValue("ReportName", "Order Taker (Fixed Salary/ TA & DA)");
            doc.SetParameterValue("Month", dtSalaryDate.Value.ToString("MMM-yyyy"));
            doc.SetParameterValue("SalaryType", SalaryType);
            doc.SetParameterValue("Preview",false);
            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);                        
           
           
                    
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {      
            
          Report(ReportType);           

        }       

        private void frmDMSDSRSalary_Load(object sender, EventArgs e)
        {
            rdoAll.Checked = true;         
            

        }

        private void btnPrint_Click_1(object sender, EventArgs e)
        {
            Report(ReportType);

        }

        private void btnConfirm_Click_1(object sender, EventArgs e)
        {
            UpdateProcessData();
            dgvDSRSalary.Rows.Clear();
            LoadData();

        }

        private void btnProcess_Click_1(object sender, EventArgs e)
        {
            ReportType = "Total";
            if (validateUIInput())
            {
                DeleteProcessData();
                InsertProcessData();
                LoadData();
            }

        }

        private void btnBasicSalary_Click(object sender, EventArgs e)
        {
            ReportType = "Basic";
            int nYear = Convert.ToInt32(dtSalaryDate.Value.Year);
            int nMonth = Convert.ToInt32(dtSalaryDate.Value.Month);
            //if (nYear == Convert.ToInt32(DateTime.Today.Year) && (nMonth == Convert.ToInt32(DateTime.Today.Month) || nMonth == Convert.ToInt32(DateTime.Today.AddMonths(-1).Month)))
            //{
                if (validateUIInput())
                {
                    DeleteProcessData();
                    DeleteProcessData_BasicDetails();
                    InsertBasicProcessData();
                    LoadData();
                }
            //}
            //else
            //{
            //    MessageBox.Show("You can not Process Salary Previous then " + DateTime.Today.AddMonths(-1).ToString("MMM-yyyy"));
            //}

}

        private void rdoHeldup_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dtSalaryDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int nYear = Convert.ToInt32(dtSalaryDate.Value.Year);
            int nMonth = Convert.ToInt32(dtSalaryDate.Value.Month);
            int PrintType = 0;
            string SalaryType = "";

            oDMSDSRs = new DMSDSRs();

            if (rdoAll.Checked == true)
            {
                PrintType = -1;
                SalaryType = "All";
            }
            if (rdoPayable.Checked == true)
            {
                PrintType = 0;
                SalaryType = "Payable";
            }
            if (rdoHeldup.Checked == true)
            {
                PrintType = 1;
                SalaryType = "Held Up";
            }

            DBController.Instance.OpenNewConnection();

            oDMSDSRs.PrintSalary(nMonth, nYear, PrintType,ReportType);

            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(CJ.Report.DMS.rptDMSDSRSalary));
            doc.SetDataSource(oDMSDSRs);

            doc.SetParameterValue("Company", "Bangladesh Lamps Limited");
            doc.SetParameterValue("ReportName", "Order Taker (Fixed Salary/ TA & DA)");
            doc.SetParameterValue("Month", dtSalaryDate.Value.ToString("MMM-yyyy"));
            doc.SetParameterValue("SalaryType", SalaryType);
            doc.SetParameterValue("Preview", true);

            frmPrintPreview frmView;
            frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);


            UpdateProcessData();
            dgvDSRSalary.Rows.Clear();
            LoadData();

        }
    }
}
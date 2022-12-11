using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;
using CJ.Report;
using CJ.Report.CSD; 

namespace CJ.Win.CSD.Store    
{
    public partial class frmCSDMaterialConsumerReportDetail : Form
    {
        CSDMaterialConsumerReportDetails _oCSDMaterialConsumerReportDetails;    
        public frmCSDMaterialConsumerReportDetail() 
        {
            InitializeComponent();
        }

        private void CSDMaterialConsumerReportDetail_Load(object sender, EventArgs e)
        {

        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            ViewConsumptionReport();
        }

        private void ViewConsumptionReport()
        {
            this.Cursor = Cursors.WaitCursor;
           _oCSDMaterialConsumerReportDetails = new CSDMaterialConsumerReportDetails();
            _oCSDMaterialConsumerReportDetails.RefreshByAmount(dtFromDate.Value);
            rptCSDMaterialConsumerReportDetail doc = new rptCSDMaterialConsumerReportDetail();
            

            String CM_Name = dtFromDate.Value.ToString("MMM-yyyy");
            DateTime _PrevMonth = dtFromDate.Value.AddMonths(-1);
            String PM_Name = _PrevMonth.Date.ToString("MMM-yyyy");

            //DateTime _CunYear = dtFromDate.Value.AddMonths(6);
            //String CM_Year = _CunYear.Date.ToString("yyyy");
            String CM_Year = dtFromDate.Value.ToString("yyyy"); 
            DateTime _PrevYear = dtFromDate.Value.AddMonths(-6);
            String PM_Year = _PrevYear.Date.ToString("yyyy");

                doc.SetParameterValue("PM_Name",PM_Name);
                doc.SetParameterValue("CM_Name", CM_Name);

                doc.SetParameterValue("PM_Year", PM_Year); 
                doc.SetParameterValue("CM_Year", CM_Year);
                
                doc.SetParameterValue("PM_OpeningStock", 0);
                doc.SetParameterValue("CM_OpeningStock", 0);

                doc.SetParameterValue("PM_1", 0);
                doc.SetParameterValue("CM_1", 0);
                doc.SetParameterValue("PM_2", 0);
                doc.SetParameterValue("CM_2", 0);

                doc.SetParameterValue("PM_3", 0);
                doc.SetParameterValue("CM_3", 0);

                doc.SetParameterValue("PM_4", 0);
                doc.SetParameterValue("CM_4", 0);

                doc.SetParameterValue("PM_5", 0);
                doc.SetParameterValue("CM_5", 0);

                doc.SetParameterValue("PM_6", 0);
                doc.SetParameterValue("CM_6", 0);

                doc.SetParameterValue("PM_7", 0);
                doc.SetParameterValue("CM_7", 0);

                doc.SetParameterValue("PM_8", 0);
                doc.SetParameterValue("CM_8", 0);

                doc.SetParameterValue("PM_9", 0);
                doc.SetParameterValue("CM_9", 0);

                doc.SetParameterValue("PM_10", 0);
                doc.SetParameterValue("CM_10", 0);

                doc.SetParameterValue("PM_11", 0);
                doc.SetParameterValue("CM_11", 0);

                doc.SetParameterValue("PM_12", 0);
                doc.SetParameterValue("CM_12", 0);

                doc.SetParameterValue("PM_13", 0);
                doc.SetParameterValue("CM_13", 0);

                doc.SetParameterValue("PM_14", 0);
                doc.SetParameterValue("CM_14", 0);

                doc.SetParameterValue("PM_15", 0);
                doc.SetParameterValue("CM_15", 0);

                doc.SetParameterValue("PM_16", 0);
                doc.SetParameterValue("CM_16", 0);

            foreach (CSDMaterialConsumerReportDetail _oCSDMaterialDetail in _oCSDMaterialConsumerReportDetails)
            {
                if (_oCSDMaterialDetail.CategoryID == 1)
                {
                    doc.SetParameterValue("PM_1", _oCSDMaterialDetail.PrevMonthAmt);
                    doc.SetParameterValue("CM_1", _oCSDMaterialDetail.CurrMonthAmt);
                }
                else if (_oCSDMaterialDetail.CategoryID == 2)
                {
                    doc.SetParameterValue("PM_2", _oCSDMaterialDetail.PrevMonthAmt);
                    doc.SetParameterValue("CM_2", _oCSDMaterialDetail.CurrMonthAmt);
                }
                else if (_oCSDMaterialDetail.CategoryID == 3)
                {
                    doc.SetParameterValue("PM_3", _oCSDMaterialDetail.PrevMonthAmt);
                    doc.SetParameterValue("CM_3", _oCSDMaterialDetail.CurrMonthAmt);
                }

                else if (_oCSDMaterialDetail.CategoryID == 4)
                {
                    doc.SetParameterValue("PM_4", _oCSDMaterialDetail.PrevMonthAmt);
                    doc.SetParameterValue("CM_4", _oCSDMaterialDetail.CurrMonthAmt);
                }
                else if (_oCSDMaterialDetail.CategoryID == 5)
                {
                    doc.SetParameterValue("PM_5", _oCSDMaterialDetail.PrevMonthAmt);
                    doc.SetParameterValue("CM_5", _oCSDMaterialDetail.CurrMonthAmt);
                }
                else if (_oCSDMaterialDetail.CategoryID == 6)
                {
                    doc.SetParameterValue("PM_6", _oCSDMaterialDetail.PrevMonthAmt);
                    doc.SetParameterValue("CM_6", _oCSDMaterialDetail.CurrMonthAmt);
                }
                else if (_oCSDMaterialDetail.CategoryID == 7)
                {
                    doc.SetParameterValue("PM_7", _oCSDMaterialDetail.PrevMonthAmt);
                    doc.SetParameterValue("CM_7", _oCSDMaterialDetail.CurrMonthAmt);
                }
                else if (_oCSDMaterialDetail.CategoryID == 8)
                {
                    doc.SetParameterValue("PM_8", _oCSDMaterialDetail.PrevMonthAmt);
                    doc.SetParameterValue("CM_8", _oCSDMaterialDetail.CurrMonthAmt);
                }
                else if (_oCSDMaterialDetail.CategoryID == 9)
                {
                    doc.SetParameterValue("PM_9", _oCSDMaterialDetail.PrevMonthAmt);
                    doc.SetParameterValue("CM_9", _oCSDMaterialDetail.CurrMonthAmt);
                }
                else if (_oCSDMaterialDetail.CategoryID == 10)
                {
                    doc.SetParameterValue("PM_10", _oCSDMaterialDetail.PrevMonthAmt);
                    doc.SetParameterValue("CM_10", _oCSDMaterialDetail.CurrMonthAmt);
                }
                else if (_oCSDMaterialDetail.CategoryID == 11)
                {
                    doc.SetParameterValue("PM_11", _oCSDMaterialDetail.PrevMonthAmt);
                    doc.SetParameterValue("CM_11", _oCSDMaterialDetail.CurrMonthAmt);
                }
                else if (_oCSDMaterialDetail.CategoryID == 12)
                {
                    doc.SetParameterValue("PM_12", _oCSDMaterialDetail.PrevMonthAmt);
                    doc.SetParameterValue("CM_12", _oCSDMaterialDetail.CurrMonthAmt);
                }
                else if (_oCSDMaterialDetail.CategoryID == 13)
                {
                    doc.SetParameterValue("PM_13", _oCSDMaterialDetail.PrevMonthAmt);
                    doc.SetParameterValue("CM_13", _oCSDMaterialDetail.CurrMonthAmt);
                }
                else if (_oCSDMaterialDetail.CategoryID == 14)
                {
                    doc.SetParameterValue("PM_14", _oCSDMaterialDetail.PrevMonthAmt);
                    doc.SetParameterValue("CM_14", _oCSDMaterialDetail.CurrMonthAmt);
                }
                else if (_oCSDMaterialDetail.CategoryID == 15)
                {
                    doc.SetParameterValue("PM_15", _oCSDMaterialDetail.PrevMonthAmt);
                    doc.SetParameterValue("CM_15", _oCSDMaterialDetail.CurrMonthAmt);
                }
                else if (_oCSDMaterialDetail.CategoryID == 16)
                {
                    doc.SetParameterValue("PM_16", _oCSDMaterialDetail.PrevMonthAmt);
                    doc.SetParameterValue("CM_16", _oCSDMaterialDetail.CurrMonthAmt);
                }
                
                else if (_oCSDMaterialDetail.CategoryID == 17)
                {
                    doc.SetParameterValue("PM_OpeningStock", _oCSDMaterialDetail.PrevMonthAmt);
                    doc.SetParameterValue("CM_OpeningStock", _oCSDMaterialDetail.CurrMonthAmt);
                }
                doc.SetParameterValue("PrintUser", Utility.Username);
            }
            frmPrintPreview frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);

            this.Cursor = Cursors.Default;

        }

    }
}
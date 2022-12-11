using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TEL.SMS.BO.BE;
using TEL.SMS.BO.DA;
using TEL.SMS.UI;
using TEL.SMS.Reports;


namespace TEL.SMS.UI.Win
{
    public partial class frmRptWarrantyReg : Form
    {
        private DSRptWarrantyAct _oDSRptWarrantyAct;
        private bool _bControlsInitialized;
        public frmRptWarrantyReg()
        {
            InitializeComponent();
        }

        private void frmRptWarrantyReg_Load(object sender, EventArgs e)
        {
            _bControlsInitialized = false;
            dtpToDate.Value = DateTime.Today;
            dtpFromDate.Value = DateTime.Today.AddDays(-15);
            rbtAll.Checked = true;
            _bControlsInitialized = true;
        }
        private void getData()
        {

            int nRegType = 0;
            if (!_bControlsInitialized) return;
            //Get All Warranty Register Data.
            _oDSRptWarrantyAct = new DSRptWarrantyAct();
            //_oDSSMSUserUsage = new DSSMSUserUsage();
            //_oDSSMSGroupMessage = new DSSMSGroupMessage();

            DAWarrantyRegister oDAWarrantyRegister = new DAWarrantyRegister();

            if (rbtAll.Checked)
            {
                nRegType = (int)DataType.DataTypeAll;
            }
            else if (rbtSMS.Checked)
            {
                nRegType = (int)DataType.DataTypeSMS;
            }
            else if (rbtManual.Checked)
            {
                nRegType = (int)DataType.DataTypeManual;
            }
            else if (rptWarrentyDetail.Checked)
            {
                nRegType = (int)DataType.DataTypeShowRoomDetail;
            }
            else if (rptWarrentySummary.Checked)
            {
                nRegType = (int)DataType.DataTypeShowRoomSummary;
            }

            DBController.Instance.OpenNewConnection();

            //oDAWarrantyRegister.GetWarrantyRegisterByRegMode(_oDSRptWarrantyAct, dtpFromDate.Value, dtpToDate.Value, nRegType);
            oDAWarrantyRegister.GetWarrantyRegisterByRegMode(_oDSRptWarrantyAct, dtpFromDate.Value, dtpToDate.Value, nRegType);
            DBController.Instance.CloseConnection();
            foreach (DSRptWarrantyAct.RptWarrantyActRow oDSWarrentyAct in _oDSRptWarrantyAct.RptWarrantyAct)
            {
                if (oDSWarrentyAct.IsProductIDNull() == false)
                {
                    oDSWarrentyAct.ProductDesc = GetProductName(oDSWarrentyAct.ProductID.ToString());
                }
            }
            //foreach (DSRptWarrantyAct.RptWarrantyActRow oDSWarrentyAct in _oDSRptWarrantyAct.RptWarrantyAct)
            //{
            //    oDSWarrentyAct.ShowroomName = GetShowroomName(oDSWarrentyAct.CustomerCode.ToString()); 
            //}
            _oDSRptWarrantyAct.AcceptChanges();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.getData();
            if (rbtAll.Checked == true)
            {
                rptWarrantyRegister oReport = new rptWarrantyRegister();

                oReport.SetDataSource(_oDSRptWarrantyAct);
                frmReportViewer oReportViewer = new frmReportViewer();
                oReport.SetParameterValue("St_Date", dtpFromDate.Value);
                oReport.SetParameterValue("End_Date", dtpToDate.Value);
                oReportViewer.ShowDialog(oReport);
            }
            else if (rbtSMS.Checked == true)
            {
                rptWarrantyRegister oReport = new rptWarrantyRegister();

                oReport.SetDataSource(_oDSRptWarrantyAct);
                frmReportViewer oReportViewer = new frmReportViewer();
                oReport.SetParameterValue("St_Date", dtpFromDate.Value);
                oReport.SetParameterValue("End_Date", dtpToDate.Value);
                oReportViewer.ShowDialog(oReport);
            }
            else if (rbtManual.Checked == true)
            {
                rptWarrantyRegister oReport = new rptWarrantyRegister();

                oReport.SetDataSource(_oDSRptWarrantyAct);
                frmReportViewer oReportViewer = new frmReportViewer();
                oReport.SetParameterValue("St_Date", dtpFromDate.Value);
                oReport.SetParameterValue("End_Date", dtpToDate.Value);
                oReportViewer.ShowDialog(oReport);
            }
            else if (rptWarrentyDetail.Checked == true)
            {
                rptWarrantyRegisterforShowroom oReport = new rptWarrantyRegisterforShowroom();
                oReport.SetDataSource(_oDSRptWarrantyAct);
                frmReportViewer oReportViewer = new frmReportViewer();
                oReport.SetParameterValue("St_Date", dtpFromDate.Value);
                oReport.SetParameterValue("End_Date", dtpToDate.Value);
                oReportViewer.ShowDialog(oReport);
            }
            else if (rptWarrentySummary.Checked == true)
            {                
                rptWarrantyRegisterforShowroomSummary oReport = new rptWarrantyRegisterforShowroomSummary();
                oReport.SetDataSource(_oDSRptWarrantyAct);
                frmReportViewer oReportViewer = new frmReportViewer();
                oReport.SetParameterValue("St_Date", dtpFromDate.Value);
                oReport.SetParameterValue("End_Date", dtpToDate.Value);
                oReportViewer.ShowDialog(oReport);
            }    
        }
        private string GetProductName(string sCode)
        {
            DSProduct oDSProduct = new DSProduct();
            DAProduct oDAProduct = new DAProduct();

            DBController.Instance.OpenNewConnection();
            oDAProduct.GetProduct(oDSProduct, sCode);
            DBController.Instance.CloseConnection();

            if (oDSProduct.Product.Count > 0)
            {
                return oDSProduct.Product[0].ProductDescription;
            }
            else
            {
                return "";
            }

        }

        private void rptWarrentyDetail_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
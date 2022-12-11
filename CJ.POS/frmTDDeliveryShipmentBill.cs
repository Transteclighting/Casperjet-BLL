using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;
using CJ.POS;
using CJ.Report;
using CJ.Report.POS;
using CJ.Class.Report;

namespace CJ.POS
{
    public partial class frmTDDeliveryShipmentBill : Form
    {
        SystemInfo oSystemInfo;
        TDDeliveryShipments _oTDDeliveryShipments;
        TDDeliveryShipment oTDDeliveryShipment;
        //TDDeliveryShipmentItem oTDDeliveryShipmentItem;


        private string[] sItemArr = null;
        private int nArrayLen = 0;
        string sSalesType = "";

        public frmTDDeliveryShipmentBill()
        {
            InitializeComponent();
        }
        public void LoadCombos()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            dtFromDate.Value = DateTime.Today;
            dtToDate.Value = DateTime.Today;

            checkedComboBoxSalesType.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SalesType)))
            {
                checkedComboBoxSalesType.Items.Add(Enum.GetName(typeof(Dictionary.SalesType), GetEnum));
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            ViewMonthlyBill();
        }

        private void ViewMonthlyBill()
        {
            this.Cursor = Cursors.WaitCursor;
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            TDDeliveryShipments oTDDeliveryShipments = new TDDeliveryShipments();
            oTDDeliveryShipments.GetTDMonthlyShipmentBill(txtInvoiceNo.Text, dtFromDate.Value.Date, dtToDate.Value.Date, sSalesType.Trim()); 

            rptTDShipmentBill oReport = new rptTDShipmentBill();
           
            oReport.SetDataSource(oTDDeliveryShipments);
            oReport.SetParameterValue("FromDate", dtFromDate.Value.Date.ToString("dd-MMM-yyyy"));
            oReport.SetParameterValue("ToDate", dtToDate.Value.Date.ToString("dd-MMM-yyyy"));
            oReport.SetParameterValue("CompanyName", Utility.CompanyName);
            oSystemInfo = new SystemInfo();
            oSystemInfo.Refresh();
            oReport.SetParameterValue("Outlet", oSystemInfo.WarehouseName + "[" + oSystemInfo.WarehouseCode + "]");
            oReport.SetParameterValue("ReportName", "TD Shipment Bill");
            oReport.SetParameterValue("UserName", Utility.Username);
            if (checkedComboBoxSalesType.Text != "")
                oReport.SetParameterValue("SalesType", checkedComboBoxSalesType.Text);
            else oReport.SetParameterValue("SalesType", "All");
            frmPrintPreview oFrom = new frmPrintPreview();
            oFrom.ShowDialog(oReport);
            this.Cursor = Cursors.Default;
        }

        private void frmTDDeliveryShipmentBill_Load(object sender, EventArgs e)
        {
            LoadCombos();
        }

        private void checkedComboBoxSalesType_DropDownClosed(object sender, EventArgs e)
        {
            sSalesType = "";
            char[] splitchar = { ',' };
            string sSalesTypeData = checkedComboBoxSalesType.Text.ToString();
            sItemArr = sSalesTypeData.Split(splitchar);
            nArrayLen = sItemArr.Length;
            if (checkedComboBoxSalesType.Text != "")
                for (int i = 0; i < nArrayLen; i++)
                {
                    //if (sSalesType != "")
                    //    sSalesType = sSalesType + "," + "'" + sItemArr[i] + "'";
                    //else sSalesType = "'" + sItemArr[i] + "'";
                    if (sSalesType == "")
                    {
                        sSalesType = "'" + sItemArr[i].Trim() + "'";
                    }
                    else
                    {
                        sSalesType = sSalesType.Trim() + ",'" + sItemArr[i].Trim() + "'";
                    }
                    sSalesType = sSalesType.Trim();
                }
        }
    }
}

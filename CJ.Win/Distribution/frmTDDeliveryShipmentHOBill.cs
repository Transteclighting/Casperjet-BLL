using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CJ.Class;
using CJ.Report;
using CJ.Report.POS;

namespace CJ.Win.Distribution
{
    public partial class frmTDDeliveryShipmentHOBill : Form
    {
        Showrooms oShowrooms;
        private string[] sItemArr = null;
        private int nArrayLen = 0;
        string sSalesType = "";
        public frmTDDeliveryShipmentHOBill()
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

            /*********Select Showroom***********/
            oShowrooms = new Showrooms();
            cmbShowroom.Items.Clear();
            cmbShowroom.Items.Add("<All>");
            oShowrooms.GetAllShowroom();
            foreach (Showroom oShowroom in oShowrooms)
            {
                cmbShowroom.Items.Add(oShowroom.ShowroomCode);
            }
            cmbShowroom.SelectedIndex = 0;

            //cmbSalesType.Items.Clear();
            //cmbSalesType.Items.Add("<All>");
            //foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SalesType)))
            //{
            //    cmbSalesType.Items.Add(Enum.GetName(typeof(Dictionary.SalesType), GetEnum));
            //}
            //cmbSalesType.SelectedIndex = 0;


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

            int nWHID = 0;
            if (cmbShowroom.SelectedIndex == 0)
            {
                nWHID = -1;
            }
            else
            {
                nWHID = oShowrooms[cmbShowroom.SelectedIndex - 1].WarehouseID;
            }
            
            TDDeliveryShipments oTDDeliveryShipments = new TDDeliveryShipments();
            oTDDeliveryShipments.GetTDMonthlyShipmentBillHO(txtInvoiceNo.Text, dtFromDate.Value.Date, dtToDate.Value.Date, nWHID, sSalesType.Trim());
            
            if (oTDDeliveryShipments.Count == 0)
            {
                MessageBox.Show("There is no data", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Cursor = Cursors.Default;
                return;
            }

            rptTDShipmentBill oReport = new rptTDShipmentBill();
            oReport.SetDataSource(oTDDeliveryShipments);
            oReport.SetParameterValue("FromDate", dtFromDate.Value.Date.ToString("dd-MMM-yyyy"));
            oReport.SetParameterValue("ToDate", dtToDate.Value.Date.ToString("dd-MMM-yyyy"));
            oReport.SetParameterValue("CompanyName", Utility.CompanyName);
            oReport.SetParameterValue("Outlet", "Outlet:" + cmbShowroom.Text + "");
            oReport.SetParameterValue("ReportName", "TD Shipment Bill");
            oReport.SetParameterValue("UserName", Utility.Username);
            if (checkedComboBoxSalesType.Text != "")
                oReport.SetParameterValue("SalesType", checkedComboBoxSalesType.Text);
            else oReport.SetParameterValue("SalesType", "All");

            frmPrintPreview oFrom = new frmPrintPreview();
            oFrom.ShowDialog(oReport);

            this.Cursor = Cursors.Default;
        }

        private void frmTDDeliveryShipmentHOBill_Load(object sender, EventArgs e)
        {
            LoadCombos();
        }

        private void checkedComboBoxSalesType_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            
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

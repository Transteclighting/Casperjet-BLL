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

namespace CJ.Win.Distribution
{
    public partial class frmReprintDeliveryGatePass : Form
    {
        public frmReprintDeliveryGatePass()
        {
            InitializeComponent();
        }
        private void PrintGatePass(string sGatePassNo, string sVehicleNo, string sDeliveryPerson, string sChallanNo, string sVendoreName, DateTime dtDeliveryDate,string sVehicleCapacity, string sDeliveryPersonContactNo)
        {
            rptVehicleGatepass doc;
            doc = new rptVehicleGatepass();

            doc.SetParameterValue("GatePassNo", sGatePassNo);
            doc.SetParameterValue("VehicleNo", sVehicleNo);
            doc.SetParameterValue("DeliveryPerson", sDeliveryPerson);
            doc.SetParameterValue("ChallanNo", sChallanNo);
            doc.SetParameterValue("VendoreName", sVendoreName);
            doc.SetParameterValue("DeliveryDate", dtDeliveryDate.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("PrintedBy", Utility.Username);
            doc.SetParameterValue("VehicleCapacity", sVehicleCapacity);
            doc.SetParameterValue("DeliveryPersonContactNo", sDeliveryPersonContactNo);

            doc.PrintToPrinter(1, true, 1, 1);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            ShipmentVehicles oItems = new ShipmentVehicles();
            oItems.GetGatePassDataNo(txtGatePassNo.Text);
            if (oItems.Count == 0)
            {
                MessageBox.Show(@"Invalid Gate Pass #", @"Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Cursor = Cursors.Default;
                return;
            }
            string sTranNo = "";
            string sGatePassNo = "";
            string sVehicleNo = "";
            string sDeliveryPerson = "";
            string sVendoreName = "";
            DateTime _dtDate = DateTime.Now.Date;
            string sVehicleCapacity = "";
            string sDeliveryPersonContactNo = "";
            foreach (ShipmentVehicle oItem in oItems)
            {
                if (sTranNo == "")
                {
                    sTranNo = oItem.TranNo;
                }
                else
                {
                    if (!sTranNo.Contains(oItem.TranNo))
                        sTranNo = sTranNo + ", " + oItem.TranNo;
                }
                sGatePassNo = oItem.GatePassNo;
                sVehicleNo = oItem.VehicleNo;
                sDeliveryPerson = oItem.DeliveryPerson;
                sVendoreName = oItem.VendorName;
                _dtDate = oItem.CreateDate;
                sVehicleCapacity = oItem.VehicleCapacity;
                sDeliveryPersonContactNo = oItem.DeliveryPersonContactNo;
            }
            PrintGatePass(sGatePassNo, sVehicleNo, sDeliveryPerson, sTranNo, sVendoreName, _dtDate, sVehicleCapacity, sDeliveryPersonContactNo);
            this.Cursor = Cursors.Default;
            DBController.Instance.CloseConnection();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.SupplyChain;
using CJ.Class.BasicData;
using CJ.Class.Library;
using CJ.Class.CSD;

namespace CJ.Win.SupplyChain
{
    public partial class frmReadyForGRD : Form
    {
        SCMShipment _oSCMShipment;
        SCMShipments _oSCMShipments;
        int nShipmentID = 0;
        string sShipmentNo = "";
        int nExGRDWeek = 0;
        int nExGRDYear = 0;

        public frmReadyForGRD()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void ShowDialog(SCMShipment oSCMShipment)
        {
            DBController.Instance.OpenNewConnection();
            nShipmentID = 0;
            nShipmentID = oSCMShipment.ShipmentID;
            sShipmentNo = "";
            sShipmentNo = oSCMShipment.ShipmentNo;
            nExGRDWeek = 0;
            nExGRDWeek = oSCMShipment.ExpectedHOArrivalWeek;
            nExGRDYear = 0;
            nExGRDYear = oSCMShipment.ExpectedHOArrivalYear;
            lblCompany.Text = oSCMShipment.CompanyName;
            lblSupplier.Text = oSCMShipment.SupplierName;
            lblShipmentNo.Text = sShipmentNo;
            lblLCNO.Text = oSCMShipment.LCNo;
            lblInvoiceNo.Text = oSCMShipment.InvoiceNo;
            lblOrderNo.Text = oSCMShipment.OrderNo;

            //SCMShipments _SCMShipments = new SCMShipments();
            //_SCMShipments.GETText(nShipmentID, oSCMShipment.CompanyName);
            //txtMessageText.Clear();
            //string sText = "";
            //foreach (SCMShipment oItem in _SCMShipments)
            //{
            //    if (sText == "")
            //    {
            //        sText = oItem.Text;
            //    }
            //    else
            //    {
            //        sText = sText + "\r\n" + oItem.Text;
            //        txtMessageText.Text = sText;
            //    }

            //}

            this.Text = "SCM Ready For GRD";

            this.Tag = oSCMShipment;

            this.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _oSCMShipment = new SCMShipment();
            _oSCMShipment.ReadyForGRDDate = dtReadyForGRDDate.Value.Date;
            _oSCMShipment.Status = (int)Dictionary.SCMStatus.ReadyForGRD;
  

            try
            {
                DBController.Instance.BeginNewTransaction();
                _oSCMShipment.UpdateReadyForGRD(nShipmentID, nExGRDWeek, nExGRDYear, txtRemarks.Text.Trim());
                DBController.Instance.CommitTransaction();


                //SCMShipments _SCMShipments = new SCMShipments();
                //DBController.Instance.OpenNewConnection();
                //_SCMShipments.GETSMSMobileNo(24);
                //foreach (SCMShipment oItem in _SCMShipments)
                //{
                //    SMSMaker _oSMSMaker = new SMSMaker();
                //    bool IsSend = _oSMSMaker.IntegrateWithAPI(1, oItem.MobileNo, txtMessageText.Text);
                //}

                MessageBox.Show("Successfully Ready For GRD ShipmentNo # " + sShipmentNo, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void frmReadyForGRD_Load(object sender, EventArgs e)
        {

        }
    }
}
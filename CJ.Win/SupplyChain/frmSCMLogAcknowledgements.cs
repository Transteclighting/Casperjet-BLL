using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;


namespace CJ.Win.SupplyChain
{
    public partial class frmSCMLogAcknowledgements : Form
    {
        public frmSCMLogAcknowledgements()
        {
            InitializeComponent();
        }

        public void ShowDialog(SCMShipment oSCMShipment)
        {
            DBController.Instance.OpenNewConnection();
            txtShipmentNo.Text = oSCMShipment.ShipmentNo;
            txtShipmentDate.Text = Convert.ToDateTime(oSCMShipment.ShipmentDate).ToString("dd-MMM-yyyy");
            txtInvoiceNo.Text = oSCMShipment.InvoiceNo;
            txtInvoiceDate.Text = Convert.ToDateTime(oSCMShipment.InvoiceDate).ToString("dd-MMM-yyyy");
            txtCompany.Text = oSCMShipment.CompanyName;
            txtSupplyer.Text = oSCMShipment.SupplierName;
            txtLCNo.Text = oSCMShipment.LCNo;
            txtLCDate.Text = Convert.ToDateTime(oSCMShipment.LCDate).ToString("dd-MMM-yyyy");
            txtPINo.Text = oSCMShipment.PINo;
            txtPIDate.Text = Convert.ToDateTime(oSCMShipment.PIReceiveDate).ToString("dd-MMM-yyyy");
            txtOrderNo.Text = oSCMShipment.OrderNo;
            txtOrderDate.Text = Convert.ToDateTime(oSCMShipment.OrderPlaceDate).ToString("dd-MMM-yyyy");
            txtPSINo.Text = oSCMShipment.PSINo;
            txtPSIDate.Text = Convert.ToDateTime(oSCMShipment.PSIDate).ToString("dd-MMM-yyyy");

            oSCMShipment.GetItems(oSCMShipment.ShipmentID);
            dgvLineItem.Rows.Clear();
            foreach (SCMShipmentItem oSCMShipmentItem in oSCMShipment)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLineItem);
                oRow.Cells[0].Value = oSCMShipmentItem.ProductCode.ToString();
                oRow.Cells[1].Value = oSCMShipmentItem.ProductName.ToString();
                oRow.Cells[2].Value = oSCMShipmentItem.ShipmentQty.ToString();
                oRow.Cells[3].Value = oSCMShipmentItem.ProductID.ToString();
                dgvLineItem.Rows.Add(oRow);

            }

            this.Text = "SCM Ready For GRD";

            this.Tag = oSCMShipment;

            this.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
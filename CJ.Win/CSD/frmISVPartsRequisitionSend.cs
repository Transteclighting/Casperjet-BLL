using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.CSD;
using CJ.Class;

namespace CJ.Win
{
    public partial class frmISVPartsRequisitionSend : Form
    {
        CourierFromCassandras _oCourierFromCassandras;

        public frmISVPartsRequisitionSend()
        {
            InitializeComponent();
        }

        private void LoadCombos()
        {
            //District
            _oCourierFromCassandras = new CourierFromCassandras();

            _oCourierFromCassandras.Refresh();
            //cmbDistrict.Items.Clear();
            foreach (CourierFromCassandra oCourierFromCassandra in _oCourierFromCassandras)
            {
                cmbCourierName.Items.Add(oCourierFromCassandra.CourierServiceName);
            }
            if (_oCourierFromCassandras.Count > 0)
                cmbCourierName.SelectedIndex = _oCourierFromCassandras.Count - 1;
        }

        private void frmISVPartsRequisitionSend_Load(object sender, EventArgs e)
        {
            LoadCombos();
            rdbByCourier.Checked = true;
            txtReceivedby.Enabled = false;
            
        }
        public void ShowDialog(SparePartsTransaction oSparePartsTransaction)
        {

            this.Tag = oSparePartsTransaction;

            lblReportNo.Text = oSparePartsTransaction.ReportNo.ToString();
            lblSerialNo.Text = oSparePartsTransaction.SerialNo.ToString();
            lblRequisitionID.Text = oSparePartsTransaction.ISVRequisitionID.ToString();
            lblInterService.Text = oSparePartsTransaction.InterService.Name.ToString();
            
            this.ShowDialog();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                this.Close();
            }
        }
        private bool validateUIInput()
        {
            #region Input Information Validation
            if (rdbByCourier.Checked == true)
            {
                if (txtConsignmentNo.Text == "")
                {
                    MessageBox.Show("Please enter Consignment No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtConsignmentNo.Focus();
                    return false;
                }
            }
            if (rdbHand2Hand.Checked == true)
            {
                if (txtReceivedby.Text == "")
                {
                    MessageBox.Show("Please enter Receiver Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtReceivedby.Focus();
                    return false;
                }
            }
            if (dtDeliveryDate.Value.Date > DateTime.Today.Date)
            {
                MessageBox.Show("Dalivery date must be less or equal current date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtDeliveryDate.Focus();
                return false;
            }

            #endregion

            return true;
        }
        private void Save()
        {
            SparePartsTransaction oSparePartsTransaction = (SparePartsTransaction)this.Tag;

            if (rdbByCourier.Checked == true)
            {
                
                oSparePartsTransaction.SparePartsSend.ModeOfSend = (int)Dictionary.ISVRequisitionDeliveryMode.ByCourier;
                oSparePartsTransaction.SparePartsSend.ConsignmentNo = txtConsignmentNo.Text;
                oSparePartsTransaction.SparePartsSend.CourierID = _oCourierFromCassandras[cmbCourierName.SelectedIndex].CourierServiceID;
                oSparePartsTransaction.SparePartsSend.BookingDate = dtDeliveryDate.Value.Date;
                oSparePartsTransaction.SparePartsSend.ReceiveBy = "";
            }
            if (rdbHand2Hand.Checked == true)
            {
                oSparePartsTransaction.SparePartsSend.ModeOfSend = (int)Dictionary.ISVRequisitionDeliveryMode.HandToHand;
                oSparePartsTransaction.SparePartsSend.ConsignmentNo = "";
                oSparePartsTransaction.SparePartsSend.CourierID = 0;
                oSparePartsTransaction.SparePartsSend.BookingDate = dtDeliveryDate.Value.Date;
                oSparePartsTransaction.SparePartsSend.ReceiveBy = txtReceivedby.Text;
            }
            oSparePartsTransaction.SparePartsSend.ISVRequisitionID = oSparePartsTransaction.ISVRequisitionID;
            oSparePartsTransaction.SparePartsSend.Remarks = txtRemarks.Text;


            try
            {
                DBController.Instance.BeginNewTransaction();
                oSparePartsTransaction.SparePartsSend.AddRequisitionItemSend();
                
                DBController.Instance.CommitTransaction();
                MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }

        }

        private void rdbByCourier_CheckedChanged(object sender, EventArgs e)
        {
            txtReceivedby.Enabled = false;
            txtConsignmentNo.Enabled = true;
            cmbCourierName.Enabled = true;

        }

        private void rdbHand2Hand_CheckedChanged(object sender, EventArgs e)
        {
            txtConsignmentNo.Enabled = false;
            cmbCourierName.Enabled = false;
            txtReceivedby.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
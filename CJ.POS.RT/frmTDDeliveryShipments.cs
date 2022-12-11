using System;
using System.Drawing;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Library;

namespace CJ.POS.RT
{
    public partial class frmTDDeliveryShipments : Form
    {
        TDDeliveryShipments _oTDDeliveryShipments;
        bool IsCheck = false;
        public frmTDDeliveryShipments()
        {
            InitializeComponent();
        }

        private void btnAddShipment_Click(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            if (lvwTDShipment.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an invoice to processing delivery.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TDDeliveryShipment oTDDeliveryShipment = (TDDeliveryShipment)lvwTDShipment.SelectedItems[0].Tag;
            if (oTDDeliveryShipment.Status == (int)Dictionary.TDDeliveryShipmentStatus.Undelivered || oTDDeliveryShipment.Status == (int)Dictionary.TDDeliveryShipmentStatus.Processing_Delivery)
            {
                if (oTDDeliveryShipment.IsHODeliveryRT(oTDDeliveryShipment.ShipmentID))
                {
                    frmTDDeliveryShipment oForm = new frmTDDeliveryShipment(oTDDeliveryShipment.Status);
                    oForm.ShowDialog(oTDDeliveryShipment);
                    if (oForm._ISLoad == true)
                    {
                        DataLoadControl();
                    }
                }
                else
                {
                    MessageBox.Show("HO logistics team will enshure this delivery.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Only undelivered status can be processing delivery.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }
        private void LoadCombos()
        {
            TELLib oLib = new TELLib();
            dtFromDate.Value = oLib.ServerDateTime().Date;
            dtToDate.Value = dtFromDate.Value;

            /************Channel****************/
            cmbChannel.Items.Clear();
            cmbChannel.Items.Add("<All>");
            //Sales Type
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SalesType)))
            {
                cmbChannel.Items.Add(Enum.GetName(typeof(Dictionary.SalesType), GetEnum));
            }
            cmbChannel.SelectedIndex = 0;


            /************Status****************/
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("<All>");
            //Status
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.TDDeliveryShipmentStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.TDDeliveryShipmentStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;


            /************IS HO Shipment****************/
            cmbIsHOShipment.Items.Clear();
            cmbIsHOShipment.Items.Add("<All>");
            //IsHOShipment
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.YesOrNoStatus)))
            {
                cmbIsHOShipment.Items.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), GetEnum));
            }
            cmbIsHOShipment.SelectedIndex = 0;

        }


        private void SetListViewRowColour()
        {
            if (lvwTDShipment.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwTDShipment.Items)
                {
                    if (oItem.SubItems[15].Text == "Undelivered")
                    {
                        oItem.BackColor = Color.LightCoral;
                    }
                    else if (oItem.SubItems[15].Text == "Processing_Delivery")
                    {
                        oItem.BackColor = Color.LightCyan;
                    }
                    else if (oItem.SubItems[15].Text == "Delivered")
                    {
                        oItem.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        oItem.BackColor = Color.Transparent;
                    }

                }
            }
        }

        private void DataLoadControl()
        {
            _oTDDeliveryShipments = new TDDeliveryShipments();
            lvwTDShipment.Items.Clear();

            int nSalesType = 0;
            if (cmbChannel.SelectedIndex == 0)
            {
                nSalesType = -1;
            }
            else
            {
                nSalesType = cmbChannel.SelectedIndex;
            }
            
            int IsHOShipment = 0;
            if (cmbIsHOShipment.SelectedIndex == 0)
            {
                IsHOShipment = -1;
            }
            else
            {
                IsHOShipment = cmbIsHOShipment.SelectedIndex - 1;
            }
            int nStatus = 0;
            if (cmbStatus.SelectedIndex == 0)
            {
                nStatus = -1;
            }
            else
            {
                nStatus = cmbStatus.SelectedIndex - 1;
            }
            this.Cursor = Cursors.WaitCursor;
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            _oTDDeliveryShipments.GetTDShipmentDataPOSRT(dtFromDate.Value.Date, dtToDate.Value.Date, nStatus, txtInvoiceNo.Text.Trim(), txtMobileNo.Text.Trim(), txtCustomerName.Text.Trim(), txtAddress.Text.Trim(), IsHOShipment, nSalesType, IsCheck);
            DBController.Instance.CloseConnection();

            foreach (TDDeliveryShipment oTDDeliveryShipment in _oTDDeliveryShipments)
            {
                ListViewItem oItem = lvwTDShipment.Items.Add(oTDDeliveryShipment.ShipmentID.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oTDDeliveryShipment.CreateDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.SalesType), oTDDeliveryShipment.SalesType));
                oItem.SubItems.Add(oTDDeliveryShipment.InvoiceNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oTDDeliveryShipment.InvoiceDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oTDDeliveryShipment.ShowroomCode.ToString());
                oItem.SubItems.Add(oTDDeliveryShipment.ConsumerName.ToString());
                oItem.SubItems.Add(oTDDeliveryShipment.CellNo.ToString());
                oItem.SubItems.Add(oTDDeliveryShipment.Address.ToString());
                oItem.SubItems.Add(oTDDeliveryShipment.ThanaName.ToString());
                oItem.SubItems.Add(oTDDeliveryShipment.DistrictName.ToString());
                oItem.SubItems.Add(oTDDeliveryShipment.TerritoryName.ToString());
                oItem.SubItems.Add(oTDDeliveryShipment.AreaName.ToString());
                TELLib _oTELLib = new TELLib();
                oItem.SubItems.Add(_oTELLib.TakaFormat(oTDDeliveryShipment.InvoiceAmount).ToString());
                oItem.SubItems.Add(_oTELLib.TakaFormat(oTDDeliveryShipment.Discount).ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.TDDeliveryShipmentStatus), oTDDeliveryShipment.Status));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), oTDDeliveryShipment.IsHOShipment));
                oItem.SubItems.Add(_oTELLib.TakaFormat(oTDDeliveryShipment.FreightCost).ToString());
                oItem.SubItems.Add(_oTELLib.TakaFormat(oTDDeliveryShipment.LiftingCost).ToString());
                oItem.SubItems.Add(_oTELLib.TakaFormat(oTDDeliveryShipment.ApprovedFreightCost).ToString());
                oItem.SubItems.Add(_oTELLib.TakaFormat(oTDDeliveryShipment.ApprovedLiftingCost).ToString());
                oItem.Tag = oTDDeliveryShipment;
            }
            SetListViewRowColour();
            this.Text = "TD Delivery Shipment [" + _oTDDeliveryShipments.Count + "]";
            this.Cursor = Cursors.Default;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                dtFromDate.Enabled = false;
                dtToDate.Enabled = false;
                IsCheck = true;
            }
            else
            {
                dtFromDate.Enabled = true;
                dtToDate.Enabled = true;
                IsCheck = false;
            }
        }

        private void frmTDDeliveryShipments_Load(object sender, EventArgs e)
        {
            LoadCombos();
            DataLoadControl();
        }

        private void btnDeliveryInvoice_Click(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            if (lvwTDShipment.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an invoice to delivery.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            TDDeliveryShipment oTDDeliveryShipment = (TDDeliveryShipment)lvwTDShipment.SelectedItems[0].Tag;
            if (oTDDeliveryShipment.Status == (int)Dictionary.TDDeliveryShipmentStatus.Processing_Delivery)
            {
                if (oTDDeliveryShipment.IsHODeliveryRT(oTDDeliveryShipment.ShipmentID))
                {
                    frmTDDeliveryShipment oForm = new frmTDDeliveryShipment((int)Dictionary.TDDeliveryShipmentStatus.Delivered);
                    oForm.ShowDialog(oTDDeliveryShipment);
                    if (oForm._ISLoad == true)
                    {
                        DataLoadControl();
                    }
                }
                else
                {
                    MessageBox.Show("HO logistics team will enshure this delivery.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Only processing delivery status can be delivered.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmTDDeliveryShipmentBill oFrom = new frmTDDeliveryShipmentBill();
            oFrom.ShowDialog();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }
    }
}
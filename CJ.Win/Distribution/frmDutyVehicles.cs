using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Library;

namespace CJ.Win.Distribution
{
    public partial class frmDutyVehicles : Form
    {
        bool IsCheck = false;
        ShipmentVehicles _oShipmentVehicles;
        ShipmentVehicles _oLogShipmentVehicles;
        ShipmentVehicle _oShipmentVehicle;

        public frmDutyVehicles()
        {
            InitializeComponent();
        }

        private void frmDutyVehicles_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void DataLoadControl()
        {

            _oShipmentVehicles = new ShipmentVehicles();
            lvwDutyVehicle.Items.Clear();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            _oShipmentVehicles.GetDutyvehicleData(dtFromDate.Value.Date, dtToDate.Value.Date, txtTranNo.Text.Trim(), IsCheck);
            DBController.Instance.CloseConnection();

            foreach (ShipmentVehicle oShipmentVehicle in _oShipmentVehicles)
            {
                ListViewItem oItem = lvwDutyVehicle.Items.Add(oShipmentVehicle.TType.ToString());
                oItem.SubItems.Add(oShipmentVehicle.TranNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oShipmentVehicle.TranDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oShipmentVehicle.DutyTranNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oShipmentVehicle.DutyTranDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oShipmentVehicle.FromWHName.ToString());
                oItem.SubItems.Add(oShipmentVehicle.ToWHName.ToString());

                oItem.Tag = oShipmentVehicle;
            }
            this.Text = "Duty vehicle [" + _oShipmentVehicles.Count + "]";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int nCount = 0;
            for (int i = 0; i < lvwDutyVehicle.Items.Count; i++)
            {
                ListViewItem itm = lvwDutyVehicle.Items[i];
                if (lvwDutyVehicle.Items[i].Checked == true)
                {
                    nCount++;
                }
            }
            if (nCount == 0)
            {
                MessageBox.Show("Please Checked at least one Item", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            else
            {
                DBController.Instance.OpenNewConnection();
                _oLogShipmentVehicles = new ShipmentVehicles();
                for (int i = 0; i < lvwDutyVehicle.Items.Count; i++)
                {
                    if (lvwDutyVehicle.Items[i].Checked == true)
                    {
                        _oShipmentVehicle = new ShipmentVehicle();
                        _oShipmentVehicle = (ShipmentVehicle)lvwDutyVehicle.Items[i].Tag;
                        _oLogShipmentVehicles.Add(_oShipmentVehicle);
                    }
                }
                frmDutyVehicle oForm = new frmDutyVehicle();
                oForm.ShowDialog(_oLogShipmentVehicles);
                if (oForm._IsTrue == true)
                {
                    DataLoadControl();
                }
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            //frmDutyVehicle oForm = new frmDutyVehicle();
            //oForm.ShowDialog();

        }

        private void btSelectAll_Click(object sender, EventArgs e)
        {
            int nCount = 0;
            if (btSelectAll.Text == "Checked All")
            {
                for (int i = 0; i < lvwDutyVehicle.Items.Count; i++)
                {

                    ListViewItem itm = lvwDutyVehicle.Items[i];
                    lvwDutyVehicle.Items[i].Checked = true;
                    nCount++;
                }
                if (nCount > 0)
                {
                    btSelectAll.Text = "Unchecked All";
                }
            }
            else
            {
                for (int i = 0; i < lvwDutyVehicle.Items.Count; i++)
                {
                    ListViewItem itm = lvwDutyVehicle.Items[i];
                    lvwDutyVehicle.Items[i].Checked = false;
                    nCount++;
                }
                if (nCount > 0)
                {
                    btSelectAll.Text = "Checked All";
                }
            }

        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
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

        private void btnPrintGatePass_Click(object sender, EventArgs e)
        {
            frmReprintDeliveryGatePass ofrmReprintDeliveryGatePass = new frmReprintDeliveryGatePass();
            ofrmReprintDeliveryGatePass.ShowDialog();
        }
    }
}
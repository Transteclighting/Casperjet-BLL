using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.BEIL
{
    public partial class frmProductionLotDeliverys : Form
    {
        ProductionLotDeliverys _oProductionLotDeliverys;
        bool IsCheck;
        public frmProductionLotDeliverys()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmProductionLotDelivery oFrom = new frmProductionLotDelivery();
            oFrom.ShowDialog();
            DataLoadControl();
        }
        private void LoadCombos()
        {
            dtFromdate.Value = DateTime.Today;
            dtTodate.Value = DateTime.Today;

            //Status
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("--All Status--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ProductionLotDeliveryStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.ProductionLotDeliveryStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;
        }

        private void DataLoadControl()
        {
            _oProductionLotDeliverys = new ProductionLotDeliverys();
            lvwProductionLot.Items.Clear();

            int nStatus = 0;
            if (cmbStatus.SelectedIndex == 0)
            {
                nStatus = -1;
            }
            else
            {
                nStatus = cmbStatus.SelectedIndex;
            }
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            _oProductionLotDeliverys.Refresh(dtFromdate.Value.Date, dtTodate.Value.Date, nStatus, txtChallanNo.Text.Trim(), txtCustomerName.Text.Trim(), IsCheck);
            DBController.Instance.CloseConnection();

            foreach (ProductionLotDelivery oProductionLotDelivery in _oProductionLotDeliverys)
            {
                ListViewItem oItem = lvwProductionLot.Items.Add(oProductionLotDelivery.ChallanNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oProductionLotDelivery.ChallanDate).ToString("dd-MMM-yyyy"));             
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.ProductionLotType), oProductionLotDelivery.ChallanType));
                oItem.SubItems.Add(oProductionLotDelivery.CustomerName.ToString());
                oItem.SubItems.Add(Convert.ToDouble(oProductionLotDelivery.ChallanAmount).ToString());
                oItem.SubItems.Add(Convert.ToDouble(oProductionLotDelivery.Discount).ToString());
                oItem.SubItems.Add(Convert.ToInt32(oProductionLotDelivery.ChallanQty).ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.ProductionLotDeliveryStatus), oProductionLotDelivery.Status));

                oItem.Tag = oProductionLotDelivery;
            }
            //SetListViewRowColour();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void frmProductionLotDeliverys_Load(object sender, EventArgs e)
        {
            LoadCombos();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                dtFromdate.Enabled = false;
                dtTodate.Enabled = false;
                IsCheck = true;
            }
            else
            {
                dtFromdate.Enabled = true;
                dtTodate.Enabled = true;
                IsCheck = false;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwProductionLot.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Item to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProductionLotDelivery oProductionLotDelivery = (ProductionLotDelivery)lvwProductionLot.SelectedItems[0].Tag;
            if (oProductionLotDelivery.Status == (int)Dictionary.ProductionLotDeliveryStatus.Create)
            {
                frmProductionLotDelivery oForm = new frmProductionLotDelivery();
                oForm.ShowDialog(oProductionLotDelivery);
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Only Create Status Can be Edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;            
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
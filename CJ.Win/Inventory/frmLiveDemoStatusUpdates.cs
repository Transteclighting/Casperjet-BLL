using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Plan;
using System.Data.OleDb;

namespace CJ.Win.Inventory
{
    public partial class frmLiveDemoStatusUpdates : Form
    {
        LiveDemos _oLiveDemos;
        int nWarehouseID = 0;
        int nInvStatus = 0;
        int nProductID= 0;
        Showrooms _oShowrooms;

        public frmLiveDemoStatusUpdates()
        {
            InitializeComponent();
        }

        private void LoadCombos()
        {

            _oShowrooms = new Showrooms();
            DBController.Instance.OpenNewConnection();
            _oShowrooms.GetAllShowroom();

            cmbToWH.Items.Clear();
            cmbToWH.Items.Add("<All>");
            foreach (Showroom oShowroom in _oShowrooms)
            {
                cmbToWH.Items.Add("[" + oShowroom.WarehouseID + "]" + oShowroom.ShowroomCode);
            }
            cmbToWH.SelectedIndex = 0;

            //Status
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("<All>");

            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.LiveDemoInvStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.LiveDemoInvStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;

        }
        private void btGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void DataLoadControl()
        {
            _oLiveDemos = new LiveDemos();
            lvwItemList.Items.Clear();


            nWarehouseID = 0;
            if (cmbToWH.SelectedIndex == 0)
            {
                nWarehouseID = -1;
            }
            else
            {
                nWarehouseID = _oShowrooms[cmbToWH.SelectedIndex - 1].WarehouseID;
            }

            nInvStatus = 0;
            if (cmbStatus.SelectedIndex == 0)
            {
                nInvStatus = -1;
            }
            else
            {
                nInvStatus = cmbStatus.SelectedIndex;
            }

            nProductID = 0;
            if (ctlProduct1.txtCode.Text == "")
            {
                nProductID = -1;
            }
            else
            {
                nProductID = ctlProduct1.SelectedSerarchProduct.ProductID;
            }

            DBController.Instance.OpenNewConnection();
            _oLiveDemos.RefreshForStatusUpdate(nInvStatus, nProductID, txtTranNo.Text.Trim(), txtRefTranNo.Text.Trim(), nWarehouseID);
            DBController.Instance.CloseConnection();

            foreach (LiveDemo oLiveDemo in _oLiveDemos)
            {
                ListViewItem oItem = lvwItemList.Items.Add(oLiveDemo.TranNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oLiveDemo.TranDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oLiveDemo.ShowroomCode.ToString());
                oItem.SubItems.Add(oLiveDemo.ProductCode.ToString());
                oItem.SubItems.Add(oLiveDemo.ProductName.ToString());
                oItem.SubItems.Add(oLiveDemo.ProductSerialNo.ToString());
                oItem.SubItems.Add(oLiveDemo.RefTranNo.ToString());
                oItem.SubItems.Add(oLiveDemo.InvoiceNo.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.LiveDemoInvStatus), oLiveDemo.InvStatus));
                oItem.SubItems.Add(oLiveDemo.Remarks.ToString());


                oItem.Tag = oLiveDemo;
            }
            setListViewRowColour();
        }
        private void setListViewRowColour()
        {
            if (lvwItemList.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwItemList.Items)
                {
                    if (oItem.SubItems[8].Text == "Sold")
                    {
                        oItem.BackColor = Color.Magenta;
                    }
                    
                    else
                    {
                        oItem.BackColor = Color.Transparent;
                    }

                }
            }
        }

        private void btnStatusUpdate_Click(object sender, EventArgs e)
        {
            if (lvwItemList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row to Update Status.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LiveDemo oLiveDemo = (LiveDemo)lvwItemList.SelectedItems[0].Tag;
            if (oLiveDemo.Status == (int)Dictionary.LiveDemoStatus.Stock)
            {
                frmLiveDemoStatusUpdate oForm = new frmLiveDemoStatusUpdate();
                oForm.ShowDialog(oLiveDemo);
                DataLoadControl();

            }
            else
            {
                MessageBox.Show("Only Stock Status Can be Update", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLiveDemoStatusUpdate_Load(object sender, EventArgs e)
        {
            LoadCombos();
        }
    }
}
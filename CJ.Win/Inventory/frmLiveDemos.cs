using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class.POS;
using CJ.Class;
using CJ.Report;
using CJ.Report.POS;

namespace CJ.Win.Inventory
{
    public partial class frmLiveDemos : Form
    {
        Showrooms _oShowrooms;
        LiveDemo _oLiveDemo;
        LiveDemos _oLiveDemos;
        int nWarehouseID = 0;
        int nStatus = 0;
        int nProductID = 0;

        public frmLiveDemos()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.LiveDemoStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.LiveDemoStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmLiveDemo oForm = new frmLiveDemo();
            oForm.ShowDialog();
            DataLoadControl();
        }

        private void btnStatusUpdate_Click(object sender, EventArgs e)
        {
            frmLiveDemoStatusUpdates oForm = new frmLiveDemoStatusUpdates();
            oForm.ShowDialog();

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

            nStatus = 0;
            if (cmbStatus.SelectedIndex == 0)
            {
                nStatus = -1;
            }
            else
            {
                nStatus = cmbStatus.SelectedIndex;
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
            _oLiveDemos.Refresh(nStatus, nProductID, txtTranNo.Text.Trim(),txtRefTranNo.Text.Trim(),nWarehouseID);
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
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.LiveDemoStatus), oLiveDemo.Status));
                oItem.SubItems.Add(oLiveDemo.Remarks.ToString());


                oItem.Tag = oLiveDemo;
            }
        }

        private void frmLiveDemos_Load(object sender, EventArgs e)
        {
            LoadCombos();

        }
    }
}
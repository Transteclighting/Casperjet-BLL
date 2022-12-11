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
    public partial class frmBEILGRDs : Form
    {
        SCMBOMStockTrans _oSCMBOMStockTrans;
        bool IsCheck;

        public frmBEILGRDs()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmBEILGRD oForm = new frmBEILGRD();
            oForm.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void DataLoadControl()
        {
            _oSCMBOMStockTrans = new SCMBOMStockTrans();
            lvwStockList.Items.Clear();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            _oSCMBOMStockTrans.GetData(dtFromdate.Value.Date, dtTodate.Value.Date, txtTranNo.Text.Trim(), txtShipmentNo.Text.Trim(), IsCheck);

            foreach (SCMBOMStockTran oSCMBOMStockTran in _oSCMBOMStockTrans)
            {
                ListViewItem lstItem = lvwStockList.Items.Add(oSCMBOMStockTran.TranNo.ToString());
                lstItem.SubItems.Add(oSCMBOMStockTran.TranDate.ToString("dd-MMM-yyyy"));
                lstItem.SubItems.Add(oSCMBOMStockTran.ShipmentNo.ToString());
                lstItem.SubItems.Add(oSCMBOMStockTran.ShipmentDate.ToString("dd-MMM-yyyy"));
                lstItem.SubItems.Add(oSCMBOMStockTran.PINo.ToString());
                lstItem.SubItems.Add(oSCMBOMStockTran.LCNo.ToString());
                lstItem.SubItems.Add(oSCMBOMStockTran.LCDate.ToString("dd-MMM-yyyy"));
                lstItem.SubItems.Add(oSCMBOMStockTran.Remarks);

                lstItem.Tag = oSCMBOMStockTran;
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            DataLoadControl();
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
    }
}
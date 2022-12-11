using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.POS;
using CJ.Class;

namespace CJ.Win.POS
{
    public partial class frmTDOutlets : Form
    {
        SystemInfoList oSystemInfoList;

        public frmTDOutlets()
        {
            InitializeComponent();
        }

        private void frmTDOutlets_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            DBController.Instance.OpenNewConnection();
            oSystemInfoList = new SystemInfoList();
            oSystemInfoList.Refresh();
            lvwOutlets.Items.Clear();

            foreach (SystemInfo oSystemInfo in oSystemInfoList)
            {
                ListViewItem lstItem = lvwOutlets.Items.Add(oSystemInfo.WarehouseName);
                lstItem.SubItems.Add(oSystemInfo.Shortcode);
                lstItem.SubItems.Add(oSystemInfo.WarehouseAddress);
                lstItem.SubItems.Add(oSystemInfo.WarehouseCellNo);
                lstItem.SubItems.Add(oSystemInfo.WarehousePhoneNo);

                lstItem.Tag = oSystemInfo;
            }
            this.Text = "Outlets" + "[" + oSystemInfoList.Count + "]";

        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            frmTDOutlet ofrmTDOutlet = new frmTDOutlet();
            ofrmTDOutlet.ShowDialog();
            LoadData();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (lvwOutlets.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SystemInfo oSystemInfo = (SystemInfo)lvwOutlets.SelectedItems[0].Tag;
            frmTDOutlet ofrmTDOutlet = new frmTDOutlet();
            ofrmTDOutlet.ShowDialog(oSystemInfo);
            LoadData();

        }
       
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CJ.Class.BasicData;
using CJ.Class;

namespace CJ.Win.Basic
{
    public partial class frmOutletMarketInfos : Form
    {
        OutletMarketInfo oOutletMarketInfo;
        OutletMarketInfos oOutletMarketInfos;
        public frmOutletMarketInfos()
        {
            InitializeComponent();
        }

        private void frmOutletMarketInfos_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            lvwData.Items.Clear();
            DBController.Instance.OpenNewConnection();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            oOutletMarketInfos = new OutletMarketInfos();
            oOutletMarketInfos.Refresh();

            foreach (OutletMarketInfo oOutletMarketInfo in oOutletMarketInfos)
            {
                ListViewItem oItem = lvwData.Items.Add(oOutletMarketInfo.Description);
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.OutletMarketType), oOutletMarketInfo.MarketType));
                oItem.Tag = oOutletMarketInfo;
            }
            this.Text = " Total " + "[" + oOutletMarketInfos.Count + "]";
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmOutletMarketInfo oForm = new frmOutletMarketInfo();
            oForm.ShowDialog();
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwData.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a item to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            oOutletMarketInfo = (OutletMarketInfo)lvwData.SelectedItems[0].Tag;
            frmOutletMarketInfo oForm = new frmOutletMarketInfo();
            oForm.ShowDialog(oOutletMarketInfo);
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwData.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a item to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            oOutletMarketInfo = (OutletMarketInfo)lvwData.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete: " + oOutletMarketInfo.ID + " ? ", "Confirm OutletMarketInfo Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oOutletMarketInfo.Delete();
                    DBController.Instance.CommitTransaction();
                    LoadData();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.BasicData;

namespace CJ.Win.Basic 
{
    public partial class frmOutletSiteInfos : Form
    {
        OutletSiteInfos _oOutletSiteInfos;
        bool IsCheck = false;
        Showrooms oShowrooms;
        public frmOutletSiteInfos()
        {
            InitializeComponent();
        }

        private void frmOutletSiteInfos_Load(object sender, EventArgs e)
        {
            LoadCombo();
        }
        private void LoadCombo()
        {
            oShowrooms = new Showrooms();
            oShowrooms.Refresh();
            cmbShowroom.Items.Clear();
            cmbShowroom.Items.Add("<All>");
            foreach (Showroom oShowroom in oShowrooms)
            {
                cmbShowroom.Items.Add(oShowroom.ShowroomCode);
            }
            cmbShowroom.SelectedIndex = 0;            
        }
        public void LoadData()
        {

            lvwData.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oOutletSiteInfos = new OutletSiteInfos();

            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            //int nIsActive = 0;
            //if (cmbIsActive.SelectedIndex == 0)
            //{
            //    nIsActive = -1;
            //}
            //else
            //{
            //    nIsActive = cmbIsActive.SelectedIndex - 1;
            //}
            _oOutletSiteInfos.RefreshBySiteInfo(dtFromdate.Value.Date, dtTodate.Value.Date, cmbShowroom.Text, IsCheck);
            foreach (OutletSiteInfo _oOutletSiteInfo in _oOutletSiteInfos)
            {
                ListViewItem oItem = lvwData.Items.Add(_oOutletSiteInfo.OutletCode.ToString());
                oItem.SubItems.Add(_oOutletSiteInfo.SiteName.ToString());
                oItem.SubItems.Add(_oOutletSiteInfo.EntryDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(_oOutletSiteInfo.OwnersName.ToString());
                oItem.SubItems.Add(_oOutletSiteInfo.OwnersAddress.ToString());
                oItem.SubItems.Add(_oOutletSiteInfo.MobileNo.ToString());
                //oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), _oOutletFeasibility.IsActive));
                oItem.Tag = _oOutletSiteInfo;
            }
            this.Text = "Total" + "[" + _oOutletSiteInfos.Count + "]";
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {

            frmOutletSiteInfo oForm = new frmOutletSiteInfo();
            oForm.ShowDialog();
            if (oForm._Istrue == true) ;
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwData.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OutletSiteInfo oOutletSiteInfo = (OutletSiteInfo)lvwData.SelectedItems[0].Tag;
            frmOutletSiteInfo oForm = new frmOutletSiteInfo();
            oForm.ShowDialog(oOutletSiteInfo);
            if (oForm._Istrue == true) ;
            LoadData();
            //if (oOutletFeasibility.Status != (int)Dictionary.OutletFeasibilityStatus.Approve)
            //{
            //    frmOutletFeasibility oForm = new frmOutletFeasibility((int)Dictionary.OutletFeasibilityStatus.Create);
            //    oForm.ShowDialog(oOutletFeasibility);
            //    if (oForm._Istrue == true) ;
            //    LoadData();
            //}
            //else
            //{
            //    MessageBox.Show("After approved can't be update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalesProjection_Click(object sender, EventArgs e)
        {
            if (lvwData.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OutletSiteInfo oOutletSiteInfo = (OutletSiteInfo)lvwData.SelectedItems[0].Tag;
            frmOutletFeasibilitys oForm = new frmOutletFeasibilitys();
            oForm.ShowDialog(oOutletSiteInfo);
            if (oForm._Istrue == true) ;
            LoadData();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            LoadData();
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

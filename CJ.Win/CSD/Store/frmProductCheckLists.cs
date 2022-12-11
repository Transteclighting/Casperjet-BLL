using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;

namespace CJ.Win.CSD.Store
{
    public partial class frmProductCheckLists : Form
    {
        CSDProductCheckLists _oCSDProductCheckLists;
        CSDProductTypes _oCSDProductTypes;
        public frmProductCheckLists()
        {
            InitializeComponent();
        }

        private void frmProductCheckLists_Load(object sender, EventArgs e)
        {
            LoadCombos();
            DataLoadControl();
        }
        private void LoadCombos()
        {
            //Product Type
            _oCSDProductTypes = new CSDProductTypes();
            _oCSDProductTypes.RefreshForCombo();
            cmbProductType.Items.Add("ALL");
            foreach (CSDProductType oCSDProductType in _oCSDProductTypes)
            {
                cmbProductType.Items.Add(oCSDProductType.ProductTypeName);
            }
            cmbProductType.SelectedIndex = 0;
        }
            

        private void DataLoadControl()
        {
            int nProductType = -1;
            if (cmbProductType.SelectedIndex != 0)
            {
                 nProductType = _oCSDProductTypes[cmbProductType.SelectedIndex - 1].ProductTypeID;
            }            
            string sChecklistName = txtChecklistName.Text.Trim();

            DBController.Instance.OpenNewConnection();
            _oCSDProductCheckLists = new CSDProductCheckLists();            
            DBController.Instance.OpenNewConnection();
            _oCSDProductCheckLists.GedData(nProductType, sChecklistName);
            this.Text = "CSD Product Check List | Total: " + "[" + _oCSDProductCheckLists.Count + "]";
            lvwProductChecklist.Items.Clear();

            foreach (CSDProductCheckList oCSDProductCheckList in _oCSDProductCheckLists)
            {
                ListViewItem oItem = lvwProductChecklist.Items.Add(oCSDProductCheckList.ProductTypeName.ToString());
                oItem.SubItems.Add(oCSDProductCheckList.Description.ToString());
                oItem.SubItems.Add(oCSDProductCheckList.CreatedBy.ToString());
                oItem.SubItems.Add(oCSDProductCheckList.CreateDate.ToShortDateString());
                oItem.Tag = oCSDProductCheckList;
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmProductCheckList oFrom = new frmProductCheckList();
            oFrom.ShowDialog();
            DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwProductChecklist.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select A Row To Edit", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CSDProductCheckList oCSDProductCheckList = (CSDProductCheckList)lvwProductChecklist.SelectedItems[0].Tag;
            frmProductCheckList oFrom = new frmProductCheckList();
            oFrom.ShowDialog(oCSDProductCheckList);
            DataLoadControl();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }


    }
}
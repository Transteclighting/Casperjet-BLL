using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Admin;
using CJ.Class.POS;


namespace CJ.POS.RT
{
    public partial class frmOfficeItemSarch : Form
    {
        public string sCode;
        public string sArticlesName;
        public string sCategoryName;
        public int sId;
        OfficeItem _oOfficeItem;
        OfficeItems _oOfficeItems;
        OfficeItems oOfficeItems;

        public frmOfficeItemSarch()
        {
            InitializeComponent();
        }

        private void returnSelectedItem()
        {
            foreach (ListViewItem oItem in lvwProduct.SelectedItems)
            {
                _oOfficeItem = (OfficeItem)lvwProduct.SelectedItems[0].Tag;

                sId = _oOfficeItem.ID;
                sCode = _oOfficeItem.Code;
                sCategoryName = _oOfficeItem.CategoryName;
                sArticlesName = _oOfficeItem.ArticlesName;

            }

        }
        private void LoadCombos()
        {
            cmbCategory.Items.Clear();
            cmbCategory.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.OfficeItemType)))
            {
                cmbCategory.Items.Add(Enum.GetName(typeof(Dictionary.OfficeItemType), GetEnum));
            }
            cmbCategory.SelectedIndex = 0;

        }

        private void refreshListBySearch()
        {
            oOfficeItems = new OfficeItems();
            lvwProduct.Items.Clear();
            DBController.Instance.OpenNewConnection();

            oOfficeItems.RefreshBySearch(cmbCategory.SelectedIndex, txtCode.Text.Trim(), txtName.Text.Trim());

            foreach (OfficeItem oOfficeItem in oOfficeItems)
            {
                ListViewItem oItem = lvwProduct.Items.Add(oOfficeItem.Code);
                oItem.SubItems.Add((oOfficeItem.ArticlesName).ToString());
                oItem.SubItems.Add((oOfficeItem.CategoryName).ToString());
                oItem.Tag = oOfficeItem;
            }

            this.Text = "OfficeItems" + lvwProduct.Items.Count.ToString();

            if (lvwProduct.Items.Count > 0)
            {
                lvwProduct.Items[0].Selected = true;
                lvwProduct.Focus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvwProduct_DoubleClick(object sender, EventArgs e)
        {
            returnSelectedItem();
            this.Close();

        }

        private void lvwProduct_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lvwProduct.Sorting == SortOrder.Ascending)
            {
                lvwProduct.Sorting = SortOrder.Descending;
            }
            else
            {
                lvwProduct.Sorting = SortOrder.Ascending;
            }
            lvwProduct.Sort();
        }

        private void lvwProduct_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                returnSelectedItem();
                this.Close();
            }
        }

        private void GetData()
        {
            _oOfficeItems = new OfficeItems();

            for (int i = 0; i < lvwProduct.Items.Count; i++)
            {
                ListViewItem itm = lvwProduct.Items[i];
                if (lvwProduct.Items[i].Checked == true)
                {
                    OfficeItem oOfficeItem = (OfficeItem)lvwProduct.Items[i].Tag;
                    _oOfficeItems.Add(oOfficeItem);

                }
            }
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            refreshListBySearch();
        }

        private void frmOfficeItemSarch_Load_1(object sender, EventArgs e)
        {
            LoadCombos();

        }
    }
}
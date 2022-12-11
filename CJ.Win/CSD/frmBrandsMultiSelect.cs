using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;

namespace CJ.Win.CSD
{
    public partial class frmBrandsMultiSelect : Form
    {
        Brands _oBrands;
        public string _sSelectedBrandID = "";
        public int _nCount = 0;
        public frmBrandsMultiSelect()
        {
            InitializeComponent();
        }

        private void frmBrandsMultiSelect_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void DataLoadControl()
        {
            _oBrands = new Brands();
            lvwItem.Items.Clear();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            _oBrands.GetMasterBrand();
            foreach (Brand oBrand in _oBrands)
            {
                ListViewItem oItem = lvwItem.Items.Add(oBrand.BrandDesc);
                oItem.Tag = oBrand;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lvwItem.Items.Count; i++)
            {
                ListViewItem itm = lvwItem.Items[i];
                if (lvwItem.Items[i].Checked == true)
                {
                    _nCount++;
                    Brand _oBrand = (Brand)lvwItem.Items[i].Tag;
                    if (_sSelectedBrandID != "")
                    {
                        _sSelectedBrandID = _sSelectedBrandID + "," + _oBrand.BrandID.ToString();
                    }
                    else
                    {
                        _sSelectedBrandID = _oBrand.BrandID.ToString();
                    }

                }
            }

        }

        private void ckbSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbSelect.Checked == true)
            {
                for (int i = 0; i < lvwItem.Items.Count; i++)
                {
                    ListViewItem itm = lvwItem.Items[i];

                    lvwItem.Items[i].Checked = true;

                }
            }
            else
            {
                for (int i = 0; i < lvwItem.Items.Count; i++)
                {
                    ListViewItem itm = lvwItem.Items[i];

                    lvwItem.Items[i].Checked = false;

                }
            }

        }
    }
}

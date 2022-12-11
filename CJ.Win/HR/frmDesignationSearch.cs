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

namespace CJ.Win.HR
{
    public partial class frmDesignationSearch : Form
    {

        Designations _oDesignations;
        public string _sSelectedDesignationID = "";
        public int _nCount = 0;

        public frmDesignationSearch()
        {
            InitializeComponent();
        }

        private void btnSet_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lvwItem.Items.Count; i++)
            {
                ListViewItem itm = lvwItem.Items[i];
                if (lvwItem.Items[i].Checked == true)
                {
                    _nCount++;
                    Designation _oDesignation = (Designation)lvwItem.Items[i].Tag;
                    if (_sSelectedDesignationID != "")
                    {
                        _sSelectedDesignationID = _sSelectedDesignationID + "," + _oDesignation.DesignationID.ToString();
                    }
                    else
                    {
                        _sSelectedDesignationID = _oDesignation.DesignationID.ToString();
                    }

                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void frmDesignationSearch_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void DataLoadControl()
        {
            _oDesignations = new Designations();
            lvwItem.Items.Clear();
            _oDesignations.Refresh();
            //this.Text = "Department " + "[" + _oDepartments.Count + "]";
            foreach (Designation oDesignation in _oDesignations)
            {
                ListViewItem oItem = lvwItem.Items.Add(oDesignation.DesignationName + " [" + oDesignation.DesignationCode + "]");
                oItem.Tag = oDesignation;
            }
        }
    }
}

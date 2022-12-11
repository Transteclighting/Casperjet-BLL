using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.HR;

namespace CJ.Win.HR
{
    public partial class frmDepartmentsMultiSelect : Form
    {
        Departments _oDepartments;
        public string _sSelectedDepartmentID = "";
        public int _nCount = 0;
        public frmDepartmentsMultiSelect()
        {
            InitializeComponent();
        }

        private void frmDepartmentsMultiSelect_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void DataLoadControl()
        {
            _oDepartments = new Departments();
            lvwItem.Items.Clear();
            _oDepartments.GetDepartmentAll();
            //this.Text = "Department " + "[" + _oDepartments.Count + "]";
            foreach (Department oDepartment in _oDepartments)
            {
                ListViewItem oItem = lvwItem.Items.Add(oDepartment.DepartmentName + " ["+oDepartment.DepartmentCode+"]");
                oItem.Tag = oDepartment;
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
                    Department _oDepartment = (Department)lvwItem.Items[i].Tag;
                    if (_sSelectedDepartmentID != "")
                    {
                        _sSelectedDepartmentID = _sSelectedDepartmentID + "," + _oDepartment.DepartmentID.ToString();
                    }
                    else
                    {
                        _sSelectedDepartmentID = _oDepartment.DepartmentID.ToString();
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
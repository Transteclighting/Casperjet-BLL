using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.CAC
{
    public partial class frmCACProjectTasks : Form
    {
        public bool _Istrue = false;
        CACProjectTasks oCACProjectTasks;
        public frmCACProjectTasks()
        {
            InitializeComponent();
        }
        public void LoadData()
        {

            lvwTasks.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oCACProjectTasks = new CACProjectTasks();

            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }


            oCACProjectTasks.Refresh();

            foreach (CACProjectTask _oCACProjectTask in oCACProjectTasks)
            {
                ListViewItem oItem = lvwTasks.Items.Add(_oCACProjectTask.TaskName);
                //oItem.SubItems.Add(_oCACProjectTask.CreateDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), _oCACProjectTask.IsActive));
                oItem.Tag = _oCACProjectTask;
            }
            this.Text = "Total" + "[" + oCACProjectTasks.Count + "]";
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
                frmCACProjectTask ofrmCACProjectTask = new frmCACProjectTask();
                ofrmCACProjectTask.ShowDialog();
                if (ofrmCACProjectTask._Istrue == true)
                LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwTasks.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Item to Edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CACProjectTask oCACProjectTask = (CACProjectTask)lvwTasks.SelectedItems[0].Tag;
            frmCACProjectTask oForm = new frmCACProjectTask();
            oForm.ShowDialog(oCACProjectTask);
            if (oForm._Istrue == true)
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCACProjectTasks_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}

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
    public partial class frmHRProductionMachines : Form
    {
        private HRProductionMachines _oHRProductionMachines;
        public frmHRProductionMachines()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmHRProductionMachine _ofrmHRProductionMachine = new frmHRProductionMachine();
            _ofrmHRProductionMachine.ShowDialog();
            DataLoadControl();

        }

        private void frmHRProductionMachines_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void DataLoadControl()
        { 
            DBController.Instance.OpenNewConnection();
            DBController.Instance.BeginNewTransaction();
            _oHRProductionMachines = new HRProductionMachines();
            _oHRProductionMachines.Refresh();
            DBController.Instance.CommitTransaction();
            this.Text = "Totat Production Machine " + "[" + _oHRProductionMachines.Count + "]";
            lvwProductionMachine.Items.Clear();
            foreach (HRProductionMachine oHRProductionMachine in _oHRProductionMachines)
            {
                ListViewItem oItem = lvwProductionMachine.Items.Add(oHRProductionMachine.MachineCode);
                oItem.SubItems.Add(oHRProductionMachine.Name);
                oItem.SubItems.Add(oHRProductionMachine.MachineType);
                oItem.SubItems.Add(oHRProductionMachine.Remarks);
                oItem.Tag = oHRProductionMachine;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwProductionMachine.SelectedItems.Count != 0)
            {
                HRProductionMachine _oHRProductionMachine = (HRProductionMachine)lvwProductionMachine.SelectedItems[0].Tag;
                frmHRProductionMachine _ofrmHRProductionMachine = new frmHRProductionMachine();
                _ofrmHRProductionMachine.ShowDialog(_oHRProductionMachine);
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Please Select A Row To Update/Edit Production Machine", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
        }
        
    }
}
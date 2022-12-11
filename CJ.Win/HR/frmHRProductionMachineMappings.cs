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
    public partial class frmHRProductionMachineMappings : Form
    {
        HRProductionMachineMaps _oHRProductionMachineMaps;
        public frmHRProductionMachineMappings()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmHRProductionMachineMapping _ofrmHRProductionMachineMapping = new frmHRProductionMachineMapping();
            _ofrmHRProductionMachineMapping.ShowDialog();
            DataLoadControl();
        }

        private void frmHRProductionMachineMappings_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void DataLoadControl()
        {
            DBController.Instance.OpenNewConnection();            
            _oHRProductionMachineMaps = new HRProductionMachineMaps();
            _oHRProductionMachineMaps.Refresh();
            lvwProductionMachine.Items.Clear();
            foreach (HRProductionMachineMap oHRProductionMachineMap in _oHRProductionMachineMaps)
            {
                ListViewItem oItem = lvwProductionMachine.Items.Add(oHRProductionMachineMap.MachineCode);
                oItem.SubItems.Add(oHRProductionMachineMap.MachineName);
                oItem.SubItems.Add(oHRProductionMachineMap.MachineType);
                oItem.SubItems.Add(oHRProductionMachineMap.ShiftName);
                oItem.SubItems.Add(oHRProductionMachineMap.CreatedBy);
                oItem.Tag = oHRProductionMachineMap;
            }

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwProductionMachine.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select A Row To Edit Production Machine Mapping.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            HRProductionMachineMap oHRProductionMachineMap = (HRProductionMachineMap)lvwProductionMachine.SelectedItems[0].Tag;
            frmHRProductionMachineMapping oForm = new frmHRProductionMachineMapping();
            oForm.ShowDialog(oHRProductionMachineMap);
            DataLoadControl();
        }
    }
}
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
    public partial class frmHRProductionMachineMapping : Form
    {
        Shifts _oShifts;
        HRProductionMachineMap _oHRProductionMachineMap;
        HRProductionMachines _oHRProductionMachines;
        public frmHRProductionMachineMapping()
        {
            InitializeComponent();
        }


        private bool UIInputValidation()
        {
            if (cmbHRShift.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Shift First.","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }
            if (cmbProductionMachine.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Machine First", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        public void ShowDialog(HRProductionMachineMap _oHRProductionMachineMap)
        {
            this.Tag = _oHRProductionMachineMap;
            btnSave.Text = "Edit";
            this.ShowDialog();
        }
        private void frmHRProductionMachineMapping_Load(object sender, EventArgs e)
        {
            LoadCombos();
        }
        private void LoadCombos()
        {
            DBController.Instance.OpenNewConnection();
            //Production Machine
            _oHRProductionMachines = new HRProductionMachines();
            _oHRProductionMachines.Refresh();
            cmbProductionMachine.Items.Clear();
            cmbProductionMachine.Items.Add("--Select Machine--");
            foreach (HRProductionMachine oHRProductionMachine in _oHRProductionMachines)
            {
                cmbProductionMachine.Items.Add(oHRProductionMachine.Name);
            }
            cmbProductionMachine.SelectedIndex = 0;

            //HR Shift
            _oShifts = new Shifts();
            _oShifts.Refresh();
            cmbHRShift.Items.Clear();
            cmbHRShift.Items.Add("--Select Shift--");
            foreach (Shift oShift in _oShifts)
            {
                cmbHRShift.Items.Add(oShift.ShiftName);
            }
            cmbHRShift.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UIInputValidation())
            {
                SaveProductionMachineMapping();
                this.Close();
            }
        }
        private void SaveProductionMachineMapping()
        {
            _oHRProductionMachineMap = new HRProductionMachineMap();
            if (this.Tag == null)
            {
                DBController.Instance.OpenNewConnection();
                DBController.Instance.BeginNewTransaction();                               
                _oHRProductionMachineMap.MachineID = _oHRProductionMachines[cmbProductionMachine.SelectedIndex-1].MachineID;
                _oHRProductionMachineMap.ShiftID = _oShifts[cmbHRShift.SelectedIndex - 1].ShiftID;
                _oHRProductionMachineMap.CreateDate = DateTime.Now;
                _oHRProductionMachineMap.CreateUserID = Utility.UserId;
                try
                {
                    _oHRProductionMachineMap.Add();
                    DBController.Instance.CommitTransaction();
                    DBController.Instance.CloseConnection();
                    MessageBox.Show("Successfully Added Production Machine Mapping", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
            else
            {
                DBController.Instance.OpenNewConnection();
                DBController.Instance.BeginNewTransaction();
                HRProductionMachineMap oHRProductionMachineMap = (HRProductionMachineMap)this.Tag;
                _oHRProductionMachineMap.ID = oHRProductionMachineMap.ID;
                _oHRProductionMachineMap.UpdateDate = DateTime.Now;
                _oHRProductionMachineMap.UpdateUserID = Utility.UserId;
                _oHRProductionMachineMap.MachineID = _oHRProductionMachines[cmbProductionMachine.SelectedIndex - 1].MachineID;
                _oHRProductionMachineMap.ShiftID = _oShifts[cmbHRShift.SelectedIndex - 1].ShiftID;
                try
                {
                    _oHRProductionMachineMap.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Successfully Edit Production Machine Mapping", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }                
            } 
        }
    }
}
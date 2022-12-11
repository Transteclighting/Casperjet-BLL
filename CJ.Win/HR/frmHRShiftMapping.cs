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
    public partial class frmHRShiftMappings : Form
    {
        HRShiftMappings _oHRShiftMappings;
        Shifts _oShifts;
        
        public frmHRShiftMappings()
        {
            InitializeComponent();
        }
        private void frmHRShiftMapping_Load(object sender, EventArgs e)
        {
            LoadCombos();
        }
        private void LoadCombos()
        {
            DBController.Instance.OpenNewConnection();
            //HR Shift
            _oShifts = new Shifts();
            _oShifts.Refresh();
            cmbHRShift.Items.Clear();
            cmbHRShift.Items.Add("Select Shift");
            foreach (Shift oShift in _oShifts)
            {
                cmbHRShift.Items.Add(oShift.ShiftName);
            }
            cmbHRShift.SelectedIndex = 0;       
            
        }
        private void DataLoadControl()
        {
            int _nShiftID=-1;
            if (cmbHRShift.SelectedIndex != 0)
            {
                _nShiftID = _oShifts[cmbHRShift.SelectedIndex - 1].ShiftID;
            }
            int _nTMonth = dtShiftMappingMonth.Value.Month;
            int _nTYear = dtShiftMappingMonth.Value.Year;

            lvwShiftMapping.Items.Clear();
            _oHRShiftMappings = new HRShiftMappings();
            DBController.Instance.OpenNewConnection();
            _oHRShiftMappings.Refresh(_nShiftID, _nTMonth, _nTYear);
            foreach (HRShiftMapping oHRShiftMapping in _oHRShiftMappings)
            {
                ListViewItem oItem = lvwShiftMapping.Items.Add(oHRShiftMapping.Date.ToString("dd-MM-yyyy"));
                oItem.SubItems.Add(oHRShiftMapping.ShiftName);
                oItem.SubItems.Add(oHRShiftMapping.RelayName);
                oItem.SubItems.Add(oHRShiftMapping.CreateUserName);
                oItem.Tag = oHRShiftMapping;
            }            
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmHRShiftMapingAdd _ofrmHRShiftMapingAdd = new frmHRShiftMapingAdd();
            _ofrmHRShiftMapingAdd.ShowDialog();
            DataLoadControl();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        
    }
}
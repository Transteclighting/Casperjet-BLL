using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.HR;
using CJ.Class.Library;


namespace CJ.Win.HR
{
    public partial class frmHRShiftMapingAdd : Form
    {
        Shifts _oShifts;
        HRRelays _oHRRelays;
        TELLib _oTELLib;
        HRShiftMapping _oHRShiftMapping;
        public frmHRShiftMapingAdd()
        {
            InitializeComponent();
        }

        private void frmHRShiftMapingAdd_Load(object sender, EventArgs e)
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
 
            //HR Relay
            _oHRRelays = new HRRelays();
            _oHRRelays.Refresh();            
            DataGridViewComboBoxColumn ColumnRelay = new DataGridViewComboBoxColumn();
            ColumnRelay.DataPropertyName = "cmbHRRealy";
            ColumnRelay.HeaderText = "Relay Name";
            ColumnRelay.Width = 150;            
            ColumnRelay.DataSource = _oHRRelays;
            ColumnRelay.ValueMember = "RelayID";
            ColumnRelay.DisplayMember = "RelayName";
            dgvHRShiftMapping.Columns.Add(ColumnRelay);
            
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void DataLoadControl()
        {
            _oTELLib = new TELLib();
            DateTime _Date = dtShiftMappingMonth.Value.Date;
            DateTime _FirstDate = _oTELLib.FirstDayofMonth(_Date);
            DateTime _LastDate = _oTELLib.LastDayofMonth(_Date);
            int nLastDay = _LastDate.Day;
            dgvHRShiftMapping.Rows.Clear();
            dgvHRShiftMapping.Refresh();
            for (int i = 0; i < nLastDay; i++)
            {
                DateTime _InsertDate = _FirstDate.AddDays(i);
                int n = dgvHRShiftMapping.Rows.Add();
                dgvHRShiftMapping.Rows[n].Cells[0].Value = _InsertDate.ToString("dd-MMM-yyyy");
            }
        }

        private void dgvHRShiftMapping_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateUIControl() && GridViewValidation())
            {
                this.Cursor = Cursors.WaitCursor;
                SaveShiftMapping();
                this.Cursor = Cursors.Default;
                this.Close();
            }
           
        }
        private bool ValidateUIControl()
        {
            if (cmbHRShift.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Shift First", "Save", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                return true;
            }
        }
        private bool GridViewValidation()
        {
            int _nNoOfInValidRows=0;
            foreach (DataGridViewRow oItemRow in dgvHRShiftMapping.Rows)
            {
                if (oItemRow.Index < dgvHRShiftMapping.Rows.Count)
                {
                    string _sRelayName = Convert.ToString((oItemRow.Cells[1] as DataGridViewComboBoxCell).FormattedValue.ToString());
                    if (_sRelayName == String.Empty)
                    {
                        this.dgvHRShiftMapping.Rows[oItemRow.Index].DefaultCellStyle.BackColor = System.Drawing.Color.Pink;
                        _nNoOfInValidRows++;
                    }
                }
            }
            if (_nNoOfInValidRows == 0)
            {
                return true;
            }
            else
            {
                MessageBox.Show("Please Select Relay Name For Every Date","Save",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return false;
            }
        }
        private void SaveShiftMapping()
        {
            foreach (DataGridViewRow oItemRow in dgvHRShiftMapping.Rows)
            {
                if (oItemRow.Index < dgvHRShiftMapping.Rows.Count)
                {
                    _oHRShiftMapping = new HRShiftMapping();
                    _oHRShiftMapping.Date = Convert.ToDateTime(oItemRow.Cells[0].Value);

                    string _sRelayName = Convert.ToString((oItemRow.Cells[1] as DataGridViewComboBoxCell).FormattedValue.ToString());
                    if (_sRelayName != String.Empty)
                    {
                        _oHRShiftMapping.RelayID = int.Parse(oItemRow.Cells[1].Value.ToString());
                    }
                    else
                    {
                        if (oItemRow.Index == dgvHRShiftMapping.Rows.Count - 1)
                        {
                            MessageBox.Show("You Have Successfully Save Shift Mapping", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                        continue;
                    }
                    
                    if (cmbHRShift.SelectedIndex != 0)
                    {
                        _oHRShiftMapping.ShiftID = _oShifts[cmbHRShift.SelectedIndex - 1].ShiftID;
                    }               
                    _oHRShiftMapping.CreateUserID = Utility.UserId;
                    _oHRShiftMapping.CreateDate = DateTime.Now;

                    try
                    {
                        DBController.Instance.OpenNewConnection();
                        DBController.Instance.BeginNewTransaction();
                        _oHRShiftMapping.Add();
                        DBController.Instance.CommitTransaction();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                    if (oItemRow.Index == dgvHRShiftMapping.Rows.Count - 1)
                    {
                        MessageBox.Show("You Have Successfully Save Shift Mapping", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }
                }
                
            }
            
        
        }
    }
}
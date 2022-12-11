using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CJ.Class.BasicData;
using CJ.Class;

namespace CJ.Win.Basic
{
    public partial class frmOutletFeasibilityQuarter : Form
    {
        OutletFeasibilityQuarter oOutletFeasibilityQuarter;
        OutletFeasibilityQuarters _oOutletFeasibilityQuarters;
        OutletFeasibility oOutletFeasibility;
        int _nOutletFeasibilityID = 0;
        DateTime _dtDate;
        public frmOutletFeasibilityQuarter()
        {
            InitializeComponent();
        }
        public void ShowDialog(int nOutletFeasibility,DateTime _Date)
        {
            DBController.Instance.OpenNewConnection();
            this.Tag = oOutletFeasibility;
            _nOutletFeasibilityID = nOutletFeasibility;
            _dtDate = _Date;

            _oOutletFeasibilityQuarters = new OutletFeasibilityQuarters();
            //_oOutletFeasibilityQuarters.Refresh(nOutletFeasibility);

            //if (_oOutletFeasibilityQuarters.Count != 0)
            //{
                _oOutletFeasibilityQuarters.RefreshByQuarter(_dtDate);
            //}

            foreach (OutletFeasibilityQuarter oItem in _oOutletFeasibilityQuarters) 
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvData);
                oRow.Cells[0].Value = oItem.Quarter;
                oRow.Cells[1].Value = oItem.FromDate;
                oRow.Cells[2].Value = oItem.ToDate;
                oRow.Cells[3].Value = oItem.QuarterPercent;
                dgvData.Rows.Add(oRow);
            }
            this.ShowDialog();
        }
        private void frmOutletFeasibilityQuarter_Load(object sender, EventArgs e)
        {
             
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateUI()
        {
            foreach (DataGridViewRow oRow in dgvData.Rows)
            {

                if (oRow.Cells[3].Value == null)
                {
                    MessageBox.Show("Please Input Quantity, ASP, GM% Properly.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return false;
                }
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateUI())
            {
                Save();
            }
        }
        private void Save()
        {
            try
            {
                DBController.Instance.BeginNewTransaction();                
                oOutletFeasibilityQuarter = new OutletFeasibilityQuarter();
                oOutletFeasibilityQuarter.Delete(_nOutletFeasibilityID);
                //int dtDate = Convert.ToInt32((dtToDate.Value.Date - dtFromDate.Value.Date).TotalDays);
                //if (dtDate == 90|| dtDate < 90)
                //{
                //    oOutletFeasibilityQuarter.Quarter = "Q1";
                //}
                //oOutletFeasibilityQuarter.Add();
                foreach (DataGridViewRow oItemRow in dgvData.Rows)
                {
                    if (oItemRow.Index < dgvData.Rows.Count)
                    {
                        OutletFeasibilityQuarter _oOutletFeasibilityQuarter = new OutletFeasibilityQuarter();
                        _oOutletFeasibilityQuarter.OutletFeasibilityID = _nOutletFeasibilityID;
                        _oOutletFeasibilityQuarter.Quarter= oItemRow.Cells[0].Value.ToString();
                        _oOutletFeasibilityQuarter.FromDate = Convert.ToDateTime(oItemRow.Cells[1].Value.ToString());
                        _oOutletFeasibilityQuarter.ToDate= Convert.ToDateTime(oItemRow.Cells[2].Value.ToString());
                        _oOutletFeasibilityQuarter.QuarterPercent = Convert.ToDouble(oItemRow.Cells[3].Value.ToString());
                        _oOutletFeasibilityQuarter.Add();
                    }
                }
                DBController.Instance.CommitTran();
                MessageBox.Show("Successfully Add Item # ", "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

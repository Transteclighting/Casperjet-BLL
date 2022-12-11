using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.BEIL
{
    public partial class frmProductionLots : Form
    {
        ProductionLots _oProductionLots;
        bool IsCheck = false;

        public frmProductionLots()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmProductionLot oFrom = new frmProductionLot();
            oFrom.ShowDialog();
            DataLoadControl();
        }
        private void LoadCombos()
        {

            dtFromdate.Value = DateTime.Today;
            dtTodate.Value = DateTime.Today;


            //Lot Type
            cmbLotType.Items.Clear();
            cmbLotType.Items.Add("--All Lot Type--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ProductionLotType)))
            {
                cmbLotType.Items.Add(Enum.GetName(typeof(Dictionary.ProductionLotType), GetEnum));
            }
            cmbLotType.SelectedIndex = 0;

            //Work Type
            cmbWorkType.Items.Clear();
            cmbWorkType.Items.Add("--All Work Type--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ProductionWorkType)))
            {
                cmbWorkType.Items.Add(Enum.GetName(typeof(Dictionary.ProductionWorkType), GetEnum));
            }
            cmbWorkType.SelectedIndex = 0;

            //Status
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("--All Status--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ProductionStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.ProductionStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;
        }
        private void SetListViewRowColour()
        {
            if (lvwProductionLot.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwProductionLot.Items)
                {
                    if (oItem.SubItems[5].Text == "Create")
                    {
                        oItem.BackColor = Color.Transparent;
                    }
                    else if (oItem.SubItems[5].Text == "Plan")
                    {
                        oItem.BackColor = Color.Pink;
                    }
                    else if (oItem.SubItems[5].Text == "PartialPlan")
                    {
                        oItem.BackColor = Color.LightPink;
                    }
                    else if (oItem.SubItems[5].Text == "Actual")
                    {
                        oItem.BackColor = Color.Green;
                    }
                    else if (oItem.SubItems[5].Text == "PartialActual")
                    {
                        oItem.BackColor = Color.LightGreen;
                    }

                    else
                    {
                        oItem.BackColor = Color.Silver;
                    }

                }
            }
        }
        private void DataLoadControl()
        {
            _oProductionLots = new ProductionLots();
            lvwProductionLot.Items.Clear();

            int nStatus = 0;
            if (cmbStatus.SelectedIndex == 0)
            {
                nStatus = -1;
            }
            else
            {
                nStatus = cmbStatus.SelectedIndex;
            }


            int nLotType = 0;
            if (cmbLotType.SelectedIndex == 0)
            {
                nLotType = -1;
            }
            else
            {
                nLotType = cmbLotType.SelectedIndex;
            }


            int nWorkType = 0;
            if (cmbWorkType.SelectedIndex == 0)
            {
                nWorkType = -1;
            }
            else
            {
                nWorkType = cmbWorkType.SelectedIndex;
            }
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            _oProductionLots.RefreshLot(dtFromdate.Value.Date, dtTodate.Value.Date, nStatus, nLotType, nWorkType, txtLotNo.Text.Trim(), txtRefNo.Text.Trim(), IsCheck);
            DBController.Instance.CloseConnection();

            foreach (ProductionLot oProductionLot in _oProductionLots)
            {
                ListViewItem oItem = lvwProductionLot.Items.Add(oProductionLot.LotNo.ToString());
                oItem.SubItems.Add(oProductionLot.RefNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oProductionLot.ReceiveDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.ProductionLotType), oProductionLot.LotType));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.ProductionWorkType), oProductionLot.WorkType));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.ProductionStatus), oProductionLot.Status));

                oItem.Tag = oProductionLot;
            }
            SetListViewRowColour();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                dtFromdate.Enabled = false;
                dtTodate.Enabled = false;
                IsCheck = true;
            }
            else
            {
                dtFromdate.Enabled = true;
                dtTodate.Enabled = true;
                IsCheck = false;
            }
        }

        private void frmProductionLots_Load(object sender, EventArgs e)
        {
            LoadCombos();
            DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwProductionLot.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Item to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ProductionLot oProductionLot = (ProductionLot)lvwProductionLot.SelectedItems[0].Tag;
            if (oProductionLot.Status == (int)Dictionary.ProductionStatus.Create)
            {
                frmProductionLot oForm = new frmProductionLot();
                oForm.ShowDialog(oProductionLot);
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Only Create Status Can be Edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            frmProductionSummaryFilter oFrom = new frmProductionSummaryFilter();
            oFrom.ShowDialog();
        }
    }
}
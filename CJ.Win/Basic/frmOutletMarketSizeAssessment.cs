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
    public partial class frmOutletMarketSizeAssessment : Form
    {
        OutletMarketSizeAssessment oOutletMarketSizeAssessment;
        OutletMarketInfos oOutletMarketInfos;
        public frmOutletMarketSizeAssessment()
        {
            InitializeComponent();
        }

        private void frmOutletMarketSizeAssessment_Load(object sender, EventArgs e)
        {
            LoadCombo();
            //LoadMarketTypeDesc();
        }
        private void LoadCombo()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            cmbMarketType.Items.Clear();
            cmbMarketType.Items.Add("---Select All---");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.OutletMarketType)))
            {
                cmbMarketType.Items.Add(Enum.GetName(typeof(Dictionary.OutletMarketType), GetEnum));
            }
            cmbMarketType.SelectedIndex = 0;

        }
        private bool ValidateUI()
        {            
            if (cmbMarketType.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Market Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMarketType.Focus();
                return false;
            }
            return true;
        }
        private void Save()
        {
            if (this.Tag == null)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    OutletMarketSizeAssessment _oOutletMarketSizeAssessment = new OutletMarketSizeAssessment();
                    //_oOutletMarketSizeAssessment.DeleteByInvoiceWise(_nProjectID);               
                    foreach (DataGridViewRow oItemRow in dgvData.Rows)
                    {
                        if (oItemRow.Index < dgvData.Rows.Count)
                        {
                            OutletMarketSizeAssessment oOutletMarketSizeAssessment = new OutletMarketSizeAssessment();

                            //oOutletMarketSizeAssessment.ProjectID = _nProjectID;
                            oOutletMarketSizeAssessment.MarketType =Convert.ToInt32(oItemRow.Cells[0].Value.ToString());
                            oOutletMarketSizeAssessment.Description = oItemRow.Cells[1].Value.ToString();
                            oOutletMarketSizeAssessment.ShopSize = Convert.ToInt32(oItemRow.Cells[2].Value.ToString());
                            oOutletMarketSizeAssessment.AvgSale = Convert.ToInt32(oItemRow.Cells[3].Value.ToString());
                            oOutletMarketSizeAssessment.LEDQty = Convert.ToInt32(oItemRow.Cells[4].Value.ToString());
                            oOutletMarketSizeAssessment.REFQty = Convert.ToInt32(oItemRow.Cells[5].Value.ToString());
                            oOutletMarketSizeAssessment.ACQty = Convert.ToInt32(oItemRow.Cells[6].Value.ToString());
                            oOutletMarketSizeAssessment.Add();
                        }
                    }
                
                DBController.Instance.CommitTran();
                MessageBox.Show("Success fully Save ", "Submit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show("Error... " + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateUI())
            {
                this.Cursor = Cursors.WaitCursor;
                Save();
                this.Cursor = Cursors.Default;
                this.Close();
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void cmbMarketType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nMarketType = 0;
            if (cmbMarketType.SelectedIndex == 0)
            {
                nMarketType = -1;
            }
            else
            {
                nMarketType = cmbMarketType.SelectedIndex;
            }
            if (this.Tag == null)
            {
                oOutletMarketInfos = new OutletMarketInfos();
                oOutletMarketInfos.RefreshByType(cmbMarketType.SelectedIndex);
                dgvData.Rows.Clear();
                foreach (OutletMarketInfo oOutletMarketInfo in oOutletMarketInfos)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvData);
                    oRow.Cells[0].Value = oOutletMarketInfo.MarketType;
                    oRow.Cells[1].Value = oOutletMarketInfo.Description;
                    dgvData.Rows.Add(oRow);

                }
            }
        }
    }
}

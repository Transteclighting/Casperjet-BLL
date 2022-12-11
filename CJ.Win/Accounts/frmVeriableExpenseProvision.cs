using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CJ.Class.Accounts;
using CJ.Class;

namespace CJ.Win.Accounts
{
    public partial class frmVeriableExpenseProvision : Form
    {
        string sBusinessType = "";
        DateTime firstDay;
        DateTime lastDay;
        public frmVeriableExpenseProvision()
        {
            InitializeComponent();
        }

        private void frmVeriableExpenseProvision_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DBController.Instance.BeginNewTransaction();
                for (int i = 0; i < dgvTELMCAnalysisSettings.Rows.Count - 1; i++)
                {
                    if (Convert.ToInt32(dgvTELMCAnalysisSettings.Rows[i].Cells[3].Value) == 0)
                    {
                        VeriableExpenseProvision oVeriableExpenseProvision = new VeriableExpenseProvision();
                        oVeriableExpenseProvision.SalesType = Convert.ToInt32(dgvTELMCAnalysisSettings.Rows[i].Cells[1].Value);
                        oVeriableExpenseProvision.ValuePercentage = Convert.ToDouble(dgvTELMCAnalysisSettings.Rows[i].Cells[2].Value);
                        oVeriableExpenseProvision.Description = dgvTELMCAnalysisSettings.Rows[i].Cells[0].Value.ToString();
                        oVeriableExpenseProvision.FromDate = firstDay;
                        oVeriableExpenseProvision.ToDate = lastDay;
                        oVeriableExpenseProvision.Add(sBusinessType);
                    }
                    else
                    {
                        VeriableExpenseProvision oVeriableExpenseProvision = new VeriableExpenseProvision();
                        oVeriableExpenseProvision.ID = Convert.ToInt32(dgvTELMCAnalysisSettings.Rows[i].Cells[3].Value);
                        oVeriableExpenseProvision.ValuePercentage = Convert.ToDouble(dgvTELMCAnalysisSettings.Rows[i].Cells[2].Value);

                        oVeriableExpenseProvision.Edit(sBusinessType, dtMonth.Value.Month, dtMonth.Value.Year);
                    }
                }
                DBController.Instance.CommitTransaction();
                MessageBox.Show("You have successfully Saved", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }

        private void LoadData()
        {
            firstDay = new DateTime(dtMonth.Value.Year, dtMonth.Value.Month, 1);
            lastDay = new DateTime(dtMonth.Value.Year, dtMonth.Value.Month, DateTime.DaysInMonth(dtMonth.Value.Year, dtMonth.Value.Month));

            dgvTELMCAnalysisSettings.Rows.Clear();
            if (rbTel.Checked==true)
            {
                sBusinessType = "TEL";
            }
            else if(rbHO.Checked == true)
            {
                sBusinessType = "HO";
            }
            else if (rbTML.Checked == true)
            {
                sBusinessType = "TML";
            }
            DBController.Instance.OpenNewConnection();
            VeriableExpenseProvisions oVeriableExpenseProvisions = new VeriableExpenseProvisions();
            oVeriableExpenseProvisions.Refresh(sBusinessType, dtMonth.Value.Month, dtMonth.Value.Year);
            DBController.Instance.CloseConnection();
            foreach (VeriableExpenseProvision oVeriableExpenseProvision in oVeriableExpenseProvisions)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvTELMCAnalysisSettings);
                oRow.Cells[0].Value = oVeriableExpenseProvision.Description.ToString();
                oRow.Cells[1].Value = oVeriableExpenseProvision.SalesType.ToString();
                oRow.Cells[2].Value = oVeriableExpenseProvision.ValuePercentage.ToString();
                oRow.Cells[3].Value = oVeriableExpenseProvision.ID.ToString();
                dgvTELMCAnalysisSettings.Rows.Add(oRow);

            }
        }

        private void dtMonth_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void rbTel_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }
        
        private void rbHO_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void rbTML_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}

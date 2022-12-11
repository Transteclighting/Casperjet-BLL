using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Library;

namespace CJ.Win
{
    public partial class frmOutletCommissionProcessNew : Form
    {
        public frmOutletCommissionProcessNew()
        {
            InitializeComponent();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                pbProcess.Visible = true;
                pbProcess.Minimum = 0;
                pbProcess.Maximum = 1;
                pbProcess.Step = 2;
                pbProcess.Value = 0;

                OutletCommission oOutletCommission = new OutletCommission();
                DBController.Instance.OpenNewConnection();
                try
                {
                    DBController.Instance.BeginNewTransaction();

                    int nYear = Convert.ToInt32(dtCommitionDate.Value.Year);
                    int nMonth = Convert.ToInt32(dtCommitionDate.Value.Month);
                    oOutletCommission.InsertOutletCommissionSalesData(nMonth, nYear);
                    oOutletCommission.MonthNo = nMonth;
                    oOutletCommission.YearNo = nYear;
                    oOutletCommission.TotalAmount = 0;
                    oOutletCommission.Type = -1;
                    oOutletCommission.CreateUserID = Utility.UserId;
                    oOutletCommission.CreateDate = DateTime.Now;
                    oOutletCommission.Remarks = txtRemarks.Text;
                    oOutletCommission.Status = (int)Dictionary.CommissionStatus.Create;
                    oOutletCommission.Add();
                    oOutletCommission.GetCommissionDetail(nMonth, nYear, dtCommitionDate.Value.Date, oOutletCommission.ID);
                    oOutletCommission.UpdateTotalCommissionAmount(oOutletCommission.ID);
                    DBController.Instance.CommitTran();

                    pbProcess.PerformStep();
                    MessageBox.Show("Variable commission successfully added. ID: " + oOutletCommission.ID.ToString(), "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    pbProcess.Visible = false;
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(" Error" + ex);
                }


            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show("Error" + ex);
            }
        }

        private void frmOutletCommissionProcessNew_Load(object sender, EventArgs e)
        {
            dtCommitionDate.Value = DateTime.Now.Date;
        }
    }
}

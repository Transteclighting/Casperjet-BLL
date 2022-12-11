using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.BasicData;
using CJ.Class.Library;

namespace CJ.Win.BEIL
{
    public partial class frmProductActual : Form
    {
        
        ProductDetail _oProductDetail;
        TELLib _oTELLib;
        ProductionLot _oProductionLot;
        int nLotPlanID = 0;
        int nLotID = 0;
        int nLotType = 0;
        string sLotNo = "";
        int nPlanQty = 0;
        int nReceiveQty = 0;
        ProductionPlan _oProductionPlan;
        ProductionLotItemActual _oProductionLotItemActual;
        int nProductID = 0;

        public frmProductActual()
        {
            InitializeComponent();
        }
        public void ShowDialog(ProductionLot oProductionLot)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            this.Tag = oProductionLot;
            //nLotPlanID = 0;
            //nLotPlanID= oProductionLot.lotpla
            nLotID = 0;
            nLotID = oProductionLot.LotID;

            nLotType = 0;
            nLotType = oProductionLot.LotType;

            nProductID = 0;
            nProductID = oProductionLot.ProductID;
            sLotNo = "";
            sLotNo = oProductionLot.LotNo;
            nPlanQty = 0;
            nReceiveQty = 0;
            nProductID = 0;
            nProductID = oProductionLot.ProductID;
            nReceiveQty = oProductionLot.ReceiveQty;
            nPlanQty = oProductionLot.PlanQty;
            lblProductCode.Text = oProductionLot.ProductCode;
            lblProductName.Text = oProductionLot.ProductName;
            lblLotNo.Text = sLotNo;
            lblReceiveDate.Text = oProductionLot.ReceiveDate.ToString("dd-MMM-yyyy");
            lblLotQty.Text = oProductionLot.ReceiveQty.ToString();
            lblPlanQty.Text = oProductionLot.PlanQty.ToString();

            lblActualQty.Text = oProductionLot.ActualQty.ToString();
            lblQCPassQty.Text = oProductionLot.QCPassQty.ToString();
            lblQCFailQty.Text = oProductionLot.QCFailQty.ToString();
            lblActualableQty.Text = Convert.ToInt32((oProductionLot.PlanQty) - (oProductionLot.ActualQty)).ToString();

            oProductionLot.GetActualItem(nLotID, nProductID);

            foreach (ProductionLotItem oProductionLotItem in oProductionLot)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvPlan);
                oRow.Cells[0].Value = oProductionLotItem.PlanDate.ToString("dd-MMM-yyyy");
                oRow.Cells[1].Value = oProductionLotItem.PlanManDay.ToString();
                oRow.Cells[2].Value = oProductionLotItem.PlanManHour.ToString();
                oRow.Cells[3].Value = oProductionLotItem.PlanQty.ToString();
                oRow.Cells[4].Value = oProductionLotItem.PlanDate.Date;
                oRow.Cells[5].Value = 0;
                oRow.Cells[6].Value = 0;
                oRow.Cells[7].Value = oProductionLotItem.ActualQty.ToString();
                oRow.Cells[8].Value = 0;
                oRow.Cells[9].Value = 0;
                oRow.Cells[10].Value = 0;
                oRow.Cells[11].Value = "";
                oRow.Cells[12].Value = oProductionLotItem.LotPlanID.ToString();
                dgvPlan.Rows.Add(oRow);
            }
            GetTotalPOQty();

            this.ShowDialog();
        }
        public void GetTotalPOQty()
        {
            txtPlan.Text = "0";
            txtActualQty.Text = "0";
            txtQCPass.Text = "0";
            txtQCFail.Text = "0";

            _oTELLib = new TELLib();

            foreach (DataGridViewRow oRow in dgvPlan.Rows)
            {
                if (oRow.Cells[3].Value != null)
                {
                    txtPlan.Text = Convert.ToDouble(Convert.ToDouble(txtPlan.Text) + Convert.ToDouble(oRow.Cells[3].Value.ToString())).ToString();
                }
                if (oRow.Cells[8].Value != null)
                {
                    txtActualQty.Text = Convert.ToDouble(Convert.ToDouble(txtActualQty.Text) + Convert.ToDouble(oRow.Cells[8].Value.ToString())).ToString();
                }
                if (oRow.Cells[9].Value != null)
                {
                    txtQCPass.Text = Convert.ToDouble(Convert.ToDouble(txtQCPass.Text) + Convert.ToDouble(oRow.Cells[9].Value.ToString())).ToString();
                }
                if (oRow.Cells[10].Value != null)
                {
                    txtQCFail.Text = Convert.ToDouble(Convert.ToDouble(txtQCFail.Text) + Convert.ToDouble(oRow.Cells[10].Value.ToString())).ToString();
                }
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (UIValidation())
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    foreach (DataGridViewRow oItemRow in dgvPlan.Rows)
                    {
                        if (oItemRow.Index < dgvPlan.Rows.Count)
                        {
                            _oProductionLotItemActual = new ProductionLotItemActual();
                            _oProductionLotItemActual.LotPlanID = Convert.ToInt32(oItemRow.Cells[12].Value.ToString());

                            _oProductionLotItemActual.ActualDate = Convert.ToDateTime(oItemRow.Cells[4].Value.ToString());
                            _oProductionLotItemActual.ActualManDay = int.Parse(oItemRow.Cells[5].Value.ToString());
                            _oProductionLotItemActual.ActualManHour = int.Parse(oItemRow.Cells[6].Value.ToString());
                            _oProductionLotItemActual.ActualQty = int.Parse(oItemRow.Cells[8].Value.ToString());
                            _oProductionLotItemActual.QCPassQty = int.Parse(oItemRow.Cells[9].Value.ToString());
                            _oProductionLotItemActual.QCFailQty = int.Parse(oItemRow.Cells[10].Value.ToString());
                            _oProductionLotItemActual.ProductID = nProductID;
                            _oProductionLotItemActual.RejectQty = 0;
                            if (oItemRow.Cells[11].Value != null)
                            {
                                _oProductionLotItemActual.ActualRemarks = (oItemRow.Cells[11].Value.ToString());
                            }

                            _oProductionLotItemActual.CreateDate = DateTime.Now.Date;
                            _oProductionLotItemActual.CreateUserID = Utility.UserId;
                            _oProductionLotItemActual.LotType = nLotType;
                            _oProductionLotItemActual.Add();

                        }
                    }
                    _oProductionLot = new ProductionLot();
                    _oProductionLot.GetLotStatus(nLotID);
                    _oProductionLot.UpdateStatus();

                    DBController.Instance.CommitTran();
                    MessageBox.Show("Success fully Add Actual Qty. LotNo # " + sLotNo, "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

        }
        private void dgvPlan_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            GetTotalPOQty();
        }
        private bool UIValidation()
        {

            #region Transaction Details Information Validation

            if (dgvPlan.Rows.Count == 0)
            {
                MessageBox.Show("Please Input Production Actual ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            foreach (DataGridViewRow oItemRow in dgvPlan.Rows)
            {
                if (oItemRow.Index < dgvPlan.Rows.Count)
                {
                    if (oItemRow.Cells[4].Value != null)
                    {
                        try
                        {
                            DateTime tmp = Convert.ToDateTime(oItemRow.Cells[4].Value);
                        }
                        catch
                        {
                            MessageBox.Show("Please Input valid Date like: 01-Jan-2050 ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    if (oItemRow.Cells[5].Value == null || oItemRow.Cells[5].Value == "")
                    {
                        MessageBox.Show("Please Input ManDay ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[6].Value == null || oItemRow.Cells[6].Value == "")
                    {
                        MessageBox.Show("Please Input ManHoure ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    if (oItemRow.Cells[8].Value == null || oItemRow.Cells[8].Value == "")
                    {
                        MessageBox.Show("Please Input Actual Qty ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[9].Value == null || oItemRow.Cells[9].Value == "")
                    {
                        MessageBox.Show("Please Input QC Pass Qty ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[10].Value == null || oItemRow.Cells[10].Value == "")
                    {
                        MessageBox.Show("Please Input QC Fail Qty ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

                int nPlanQty = 0;
                nPlanQty = Convert.ToInt32(oItemRow.Cells[3].Value);

                int nPrvActualQty = 0;
                nPrvActualQty = Convert.ToInt32(oItemRow.Cells[7].Value);

                int nActualQty = 0;
                nActualQty = Convert.ToInt32(oItemRow.Cells[8].Value);
                int nQCPass = 0;
                nQCPass = Convert.ToInt32(oItemRow.Cells[9].Value);
                int nQCFail = 0;
                nQCFail = Convert.ToInt32(oItemRow.Cells[10].Value);


                int nActQty = 0;
                nActQty = Convert.ToInt32(txtActualQty.Text);
                int nPlnQty = 0;
                nPlnQty = Convert.ToInt32(lblPlanQty.Text);

                if (nPlnQty>=nActQty)
                {
                    oItemRow.DefaultCellStyle.ForeColor = Color.Black;
                }
                else
                {
                    oItemRow.DefaultCellStyle.ForeColor = Color.Red;
                    MessageBox.Show("Actual Qty must be less or equal Plan Qty", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                if (nActualQty == (nQCPass + nQCFail))
                {
                    oItemRow.DefaultCellStyle.ForeColor = Color.Black;
                }
                else
                {
                    oItemRow.DefaultCellStyle.ForeColor = Color.Red;
                    MessageBox.Show("(QCPass + QCFail) Qty must be equal Actual Qty", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

            }
            #endregion

            return true;

        }
        private void dgvPlan_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            GetTotalPOQty();

        }
        private void dgvPlan_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            GetTotalPOQty();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
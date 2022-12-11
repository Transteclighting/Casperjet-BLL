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
    public partial class frmProductionPlan : Form
    {
        ProductDetail _oProductDetail;
        TELLib _oTELLib;
        ProductionLot _oProductionLot;
        int nLotID = 0;
        string sLotNo = "";
        int nPlanQty = 0;
        int nReceiveQty = 0;
        ProductionPlan _oProductionPlan;
        int nProductID = 0;

        public frmProductionPlan()
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
            nLotID = 0;
            nLotID = oProductionLot.LotID;
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
            lblPlanableQty.Text = Convert.ToInt32((oProductionLot.ReceiveQty) - (oProductionLot.PlanQty)).ToString();
            oProductionLot.GetPlan(nLotID, nProductID);
            foreach (ProductionLotItem oProductionLotItem in oProductionLot)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvPlan);
                oRow.Cells[0].Value = oProductionLotItem.PlanDate.Date;
                oRow.Cells[1].Value = oProductionLotItem.PlanManDay.ToString();
                oRow.Cells[2].Value = oProductionLotItem.PlanManHour.ToString();
                oRow.Cells[3].Value = oProductionLotItem.PlanQty.ToString();
                oRow.Cells[4].Value = oProductionLotItem.PlanRemarks.ToString();
                dgvPlan.Rows.Add(oRow);
            }

            GetTotalPOQty();
            this.ShowDialog();
        }
        public void GetTotalPOQty()
        {
            txtTotalQty.Text = "0";
            _oTELLib = new TELLib();

            foreach (DataGridViewRow oRow in dgvPlan.Rows)
            {
                if (oRow.Cells[3].Value != null)
                {
                    txtTotalQty.Text = Convert.ToDouble(Convert.ToDouble(txtTotalQty.Text) + Convert.ToDouble(oRow.Cells[3].Value.ToString())).ToString();
                }
            }

        }

        private void dgvOrderQty_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            GetTotalPOQty();
        }
        private bool UIValidation()
        {

            #region Transaction Details Information Validation

            if (dgvPlan.Rows.Count == 1)
            {
                MessageBox.Show("Please Input Production Plan ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            foreach (DataGridViewRow oItemRow in dgvPlan.Rows)
            {
                if (oItemRow.Index < dgvPlan.Rows.Count - 1)
                {
                    if (oItemRow.Cells[0].Value != null)
                    {
                        try
                        {
                            DateTime tmp = Convert.ToDateTime(oItemRow.Cells[0].Value);
                        }
                        catch
                        {
                            MessageBox.Show("Please Input valid Date like: 01-Jan-2050 ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    if (oItemRow.Cells[1].Value == null || oItemRow.Cells[1].Value == "")
                    {
                        MessageBox.Show("Please Input ManDay ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    if (oItemRow.Cells[2].Value == null || oItemRow.Cells[2].Value == "")
                    {
                        MessageBox.Show("Please Input ManHoure", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[3].Value == null || oItemRow.Cells[3].Value == "")
                    {
                        MessageBox.Show("Please Input Plan Qty ", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }



                //int nPrevPlanQty = 0;
                int nGPlanQty = 0;
                int nLotQty = 0;
                //nPrevPlanQty = nPlanQty;
                nGPlanQty = Convert.ToInt32(txtTotalQty.Text);
                nLotQty = nReceiveQty;

                if (nLotQty >=  nGPlanQty)
                {
                    oItemRow.DefaultCellStyle.ForeColor = Color.Black;
                }
                else
                {
                    oItemRow.DefaultCellStyle.ForeColor = Color.Red;
                    MessageBox.Show("PlanQty Qty must be less or equal Lot Qty", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

            }
            #endregion

            return true;

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.Tag != null)
            {

                if (UIValidation())
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        _oProductionPlan = new ProductionPlan();
                        _oProductionPlan.Delete(nLotID, nProductID);
                        foreach (DataGridViewRow oItemRow in dgvPlan.Rows)
                        {
                            if (oItemRow.Index < dgvPlan.Rows.Count - 1)
                            {
                                
                                _oProductionPlan.LotID = nLotID;
                                _oProductionPlan.ProductID = nProductID;
                                _oProductionPlan.CreateDate = DateTime.Now.Date;
                                _oProductionPlan.CreateUserID = Utility.UserId;
                                _oProductionPlan.PlanDate = Convert.ToDateTime(oItemRow.Cells[0].Value.ToString());
                                _oProductionPlan.PlanManDay = int.Parse(oItemRow.Cells[1].Value.ToString());
                                _oProductionPlan.PlanManHour = int.Parse(oItemRow.Cells[2].Value.ToString());
                                _oProductionPlan.PlanQty = int.Parse(oItemRow.Cells[3].Value.ToString());
                                if (oItemRow.Cells[4].Value != null)
                                {
                                    _oProductionPlan.PlanRemarks = (oItemRow.Cells[4].Value.ToString());
                                }
                                else 
                                {
                                    _oProductionPlan.PlanRemarks = "";
                                }
                                _oProductionPlan.Add();

                            }
                        }
                        _oProductionLot = new ProductionLot();
                        _oProductionLot.GetLotStatus(nLotID);
                        _oProductionLot.UpdateStatus();


                        DBController.Instance.CommitTran();
                        MessageBox.Show("Success fully Add Plan. LotNo # " + sLotNo, "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }

            }

            else
            {
                if (UIValidation())
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        foreach (DataGridViewRow oItemRow in dgvPlan.Rows)
                        {
                            if (oItemRow.Index < dgvPlan.Rows.Count - 1)
                            {
                                _oProductionPlan = new ProductionPlan();
                                _oProductionPlan.LotID = nLotID;
                                _oProductionPlan.ProductID = nProductID;
                                _oProductionPlan.CreateDate = DateTime.Now.Date;
                                _oProductionPlan.CreateUserID = Utility.UserId;
                                _oProductionPlan.PlanDate = Convert.ToDateTime(oItemRow.Cells[0].Value.ToString());
                                _oProductionPlan.PlanManDay = int.Parse(oItemRow.Cells[1].Value.ToString());
                                _oProductionPlan.PlanManHour = int.Parse(oItemRow.Cells[2].Value.ToString());
                                _oProductionPlan.PlanQty = int.Parse(oItemRow.Cells[3].Value.ToString());
                                if (oItemRow.Cells[4].Value != null)
                                {
                                    _oProductionPlan.PlanRemarks = (oItemRow.Cells[4].Value.ToString());
                                }
                                _oProductionPlan.Add();

                            }
                        }
                        _oProductionLot = new ProductionLot();
                        _oProductionLot.GetLotStatus(nLotID);
                        _oProductionLot.UpdateStatus();


                        DBController.Instance.CommitTran();
                        MessageBox.Show("Success fully Add Plan. LotNo # " + sLotNo, "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
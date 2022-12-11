using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class.POS;
using CJ.Class;

namespace CJ.POS
{
    public partial class frmOutletProjection : Form
    {
        int _nType = 0;
        int nWarehouseID = 0;
        frmMain ofrmMain;
        int nProjectionID = 0;

        public frmOutletProjection(int nType, object _oFrmMain)
        {
            InitializeComponent();
            _nType = nType;
            ofrmMain = (frmMain)_oFrmMain;

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DBController.Instance.OpenNewConnection();
            RetailSalesInvoice oGetID = new RetailSalesInvoice();
            nProjectionID = oGetID.GetProjectionID(dtProjectionDate.Value.Date);
            if (nProjectionID == 0)
            {
                RetailSalesInvoice oMaxID = new RetailSalesInvoice();
                oMaxID.MaxProjectionID();
                nProjectionID = oMaxID.ProjectionID;
            }
            try
            {
                DBController.Instance.BeginNewTransaction();
                RetailSalesInvoice oDeletItem = new RetailSalesInvoice();
                oDeletItem.ProjectionDate = dtProjectionDate.Value.Date;
                oDeletItem.WarehouseID = nWarehouseID;
                oDeletItem.DeleteProjectionData();

                foreach (DataGridViewRow oItemRow in dgvValue.Rows)
                {
                    if (oItemRow.Index < dgvValue.Rows.Count)
                    {

                        RetailSalesInvoice _oItem = new RetailSalesInvoice();

                        _oItem.ProjectionID = nProjectionID;
                        _oItem.WarehouseID = nWarehouseID;
                        _oItem.ProjectionDate = dtProjectionDate.Value.Date;
                        _oItem.DataType = (int)Dictionary.DeailyProjectionType.Sales_Value;
                        _oItem.DataID = int.Parse(oItemRow.Cells[4].Value.ToString());
                        _oItem.Projection = Convert.ToDouble(oItemRow.Cells[1].Value.ToString());
                        _oItem.Actual = Convert.ToDouble(oItemRow.Cells[2].Value.ToString());
                        _oItem.CreateDate = DateTime.Now.Date;
                        _oItem.CreateUserID = Utility.UserId;

                        _oItem.InsertProjection();

                    }
                }

                foreach (DataGridViewRow oItemRow in dsvQty.Rows)
                {
                    if (oItemRow.Index < dsvQty.Rows.Count)
                    {

                        RetailSalesInvoice _oItem = new RetailSalesInvoice();

                        _oItem.ProjectionID = nProjectionID;
                        _oItem.WarehouseID = nWarehouseID;
                        _oItem.ProjectionDate = dtProjectionDate.Value.Date;
                        _oItem.DataType = (int)Dictionary.DeailyProjectionType.Sales_Qty;
                        _oItem.DataID = int.Parse(oItemRow.Cells[4].Value.ToString());
                        _oItem.Projection = Convert.ToDouble(oItemRow.Cells[1].Value.ToString());
                        _oItem.Actual = Convert.ToDouble(oItemRow.Cells[2].Value.ToString());
                        _oItem.CreateDate = DateTime.Now.Date;
                        _oItem.CreateUserID = Utility.UserId;

                        _oItem.InsertProjection();

                    }
                }

                foreach (DataGridViewRow oItemRow in dsvOther.Rows)
                {
                    if (oItemRow.Index < dsvOther.Rows.Count)
                    {

                        RetailSalesInvoice _oItem = new RetailSalesInvoice();

                        _oItem.ProjectionID = nProjectionID;
                        _oItem.WarehouseID = nWarehouseID;
                        _oItem.ProjectionDate = dtProjectionDate.Value.Date;
                        _oItem.DataType = (int)Dictionary.DeailyProjectionType.Other;
                        _oItem.DataID = int.Parse(oItemRow.Cells[4].Value.ToString());
                        _oItem.Projection = Convert.ToDouble(oItemRow.Cells[1].Value.ToString());
                        _oItem.Actual = Convert.ToDouble(oItemRow.Cells[2].Value.ToString());
                        _oItem.CreateDate = DateTime.Now.Date;
                        _oItem.CreateUserID = Utility.UserId;

                        _oItem.InsertProjection();

                    }
                }

                DataTran oDataTran = new DataTran();
                oDataTran.TableName = "t_OutletDailyProjection";
                oDataTran.DataID = Convert.ToInt32(nProjectionID);
                oDataTran.WarehouseID = nWarehouseID;
                oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                oDataTran.BatchNo = 0;

                if (oDataTran.CheckData() == false)
                {
                    oDataTran.AddForTDPOS();
                }

                DBController.Instance.CommitTran();
                MessageBox.Show("Save Successfully. ID # " + nProjectionID.ToString(), "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                if (_nType == 1)
                {
                    frmDayStart ofrmDayStart = new frmDayStart(ofrmMain);
                    ofrmDayStart.ShowDialog();
                }
                else if (_nType == 2)
                {
                    frmMain oFrom = new frmMain();
                    frmDayEnd ofrmDayEnd = new frmDayEnd(ofrmMain);
                    //ofrmDayEnd.MdiParent = this;
                    ofrmDayEnd.ShowDialog();
                }

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }
        private void GetDate()
        {
            RetailSalesInvoices oProjections = new RetailSalesInvoices();
            DBController.Instance.OpenNewConnection();
            oProjections.GetDailyProjection(dtProjectionDate.Value.Date, (int)Dictionary.DeailyProjectionType.Sales_Value);
            DBController.Instance.CloseConnection();
            dgvValue.Rows.Clear();
            foreach (RetailSalesInvoice oRetailSalesInvoice in oProjections)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvValue);
                oRow.Cells[0].Value = oRetailSalesInvoice.DataName.ToString();
                oRow.Cells[1].Value = oRetailSalesInvoice.Projection.ToString();
                oRow.Cells[2].Value = oRetailSalesInvoice.Actual.ToString();
                oRow.Cells[3].Value = oRetailSalesInvoice.Achievement.ToString();
                oRow.Cells[4].Value = oRetailSalesInvoice.DataID.ToString();
                if (_nType == 1)
                {
                    oRow.Cells[1].ReadOnly = false;
                }
                else
                {
                    oRow.Cells[1].ReadOnly = true;
                }
                dgvValue.Rows.Add(oRow);

            }

            RetailSalesInvoices oQtyProjections = new RetailSalesInvoices();
            DBController.Instance.OpenNewConnection();
            oQtyProjections.GetDailyProjection(dtProjectionDate.Value.Date, (int)Dictionary.DeailyProjectionType.Sales_Qty);
            DBController.Instance.CloseConnection();
            dsvQty.Rows.Clear();
            foreach (RetailSalesInvoice oQty in oQtyProjections)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dsvQty);
                oRow.Cells[0].Value = oQty.DataName.ToString();
                oRow.Cells[1].Value = oQty.Projection.ToString();
                oRow.Cells[2].Value = oQty.Actual.ToString();
                oRow.Cells[3].Value = oQty.Achievement.ToString();
                oRow.Cells[4].Value = oQty.DataID.ToString();

                if (_nType == 1)
                {
                    oRow.Cells[1].ReadOnly = false;
                }
                else
                {
                    oRow.Cells[1].ReadOnly = true;
                }
                
                dsvQty.Rows.Add(oRow);

            }

            RetailSalesInvoices oOtherProjections = new RetailSalesInvoices();
            DBController.Instance.OpenNewConnection();
            oOtherProjections.GetDailyProjection(dtProjectionDate.Value.Date, (int)Dictionary.DeailyProjectionType.Other);
            DBController.Instance.CloseConnection();
            dsvOther.Rows.Clear();
            foreach (RetailSalesInvoice oOther in oOtherProjections)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dsvOther);
                oRow.Cells[0].Value = oOther.DataName.ToString();
                oRow.Cells[1].Value = oOther.Projection.ToString();
                oRow.Cells[2].Value = oOther.Actual.ToString();
                oRow.Cells[3].Value = oOther.Achievement.ToString();
                oRow.Cells[4].Value = oOther.DataID.ToString();

                if (_nType == 1)
                {
                    oRow.Cells[1].ReadOnly = false;
                }
                else
                {
                    oRow.Cells[1].ReadOnly = true;
                }

                dsvOther.Rows.Add(oRow);

            }
        }

        private void dtProjectionDate_ValueChanged(object sender, EventArgs e)
        {
            GetDate();
        }

        private void frmOutletProjection_Load(object sender, EventArgs e)
        {

            DBController.Instance.OpenNewConnection();
            SystemInfo oSystemInfo = new SystemInfo();
            oSystemInfo.Refresh();
            nWarehouseID = oSystemInfo.WarehouseID;
            try
            {
                dtProjectionDate.Value = Convert.ToDateTime(oSystemInfo.OperationDate);
            }
            catch
            {
                dtProjectionDate.Value = Convert.ToDateTime(oSystemInfo.NextOperationDate);
            }
            if (_nType == 1)
            {
                dtProjectionDate.Enabled = false;
                dgvValue.Columns[2].Visible = false;
                dgvValue.Columns[3].Visible = false;
                dsvQty.Columns[2].Visible = false;
                dsvQty.Columns[3].Visible = false;
                dsvOther.Columns[2].Visible = false;
                dsvOther.Columns[3].Visible = false;
                

            }
            else if (_nType == 2)
            {
                dtProjectionDate.Enabled = false;
            }
            else if (_nType == 3)
            {
                dtProjectionDate.Enabled = true;
                btnSave.Enabled = false;
            }
            GetDate();
        }

        private void refreshRow(int nRowIndex, int nColumnIndex)
        {
            double _Projection = 0;
            double _Actual = 0;
            double _Ach = 0;
            try
            {
                _Projection = Convert.ToDouble(dsvOther.Rows[nRowIndex].Cells[1].Value);
            }
            catch
            {
                _Projection = 0;
            }
            try
            {
                _Actual = Convert.ToDouble(dsvOther.Rows[nRowIndex].Cells[2].Value);
            }
            catch
            {
                _Actual = 0;
            }
            if (_Projection > 0)
            {
                try
                {
                    _Ach = _Actual / _Projection * 100;
                }
                catch
                {
                    _Ach = 0;
                }
            }
            else
            {
                _Ach = 0;
            }
            dsvOther.Rows[nRowIndex].Cells[3].Value = _Ach.ToString();

        }

        private void dsvOther_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            refreshRow(e.RowIndex, e.ColumnIndex);
        }
    }
}
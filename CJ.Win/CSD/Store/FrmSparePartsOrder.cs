using System;
using System.Drawing;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD.Store;

namespace CJ.Win.CSD.Store
{
    public partial class FrmSparePartsOrder : Form
    {
        private SparePartsRs _oSparePartsRs;
        private CsdSparePartOrder _oCsdSparePartOrder;
        private CsdSparePartOrderItem _oCsdSparePartOrderItem ;
        private CsdSparePartOrderItems _oCsdSparePartOrderItems;
        private Brands _oBrands;
        ProductGroups _oProductGroupsMag;

        public bool IsThereAnyActivity;

        private ProductGroups _oProductGroups;
        
        public FrmSparePartsOrder()
        {
            InitializeComponent();
        }


        public void ShowDialog(CsdSparePartOrder oCsdSparePartOrder)
        {
            dgvOrder.Size = new Size(895, 377);
            dgvOrder.Location = new Point(12, 12);
            Text = oCsdSparePartOrder.OrderNo;

            Tag = oCsdSparePartOrder;
            LoadExistingOrder(oCsdSparePartOrder.OrderID);
            gbProcess.Visible = false;
            ShowDialog();

        }

        private void LoadExistingOrder(int orderId)
        {
            _oCsdSparePartOrderItems = new CsdSparePartOrderItems();
            _oCsdSparePartOrderItems.Refresh(orderId);

            foreach (CsdSparePartOrderItem aCsdSparePartOrderItem in _oCsdSparePartOrderItems)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvOrder);
                oRow.Cells[0].Value = aCsdSparePartOrderItem.SparePartID;
                oRow.Cells[1].Value = aCsdSparePartOrderItem.SpCode;
                oRow.Cells[2].Value = aCsdSparePartOrderItem.SpName;
                oRow.Cells[3].Value = aCsdSparePartOrderItem.CostPrice;
                oRow.Cells[4].Value = aCsdSparePartOrderItem.SalePrice;
                oRow.Cells[5].Value = aCsdSparePartOrderItem.Consumtion;
                oRow.Cells[6].Value = aCsdSparePartOrderItem.Stock;
                oRow.Cells[7].Value = aCsdSparePartOrderItem.ReorderLevel;
                oRow.Cells[8].Value = aCsdSparePartOrderItem.ForecastQty;
                oRow.Cells[9].Value = aCsdSparePartOrderItem.Qty;
                
                dgvOrder.Rows.Add(oRow);
            }

        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            DataLoad();
        }

        private void LoadCombo()
        {
            _oBrands = new Brands();
            _oBrands.Refresh(Dictionary.BrandLevel.MasterBrand);
            cmbBrand.Items.Clear();
            cmbBrand.Items.Add("-- Select Brand --");
            foreach (Brand oBrand in _oBrands)
            {
                cmbBrand.Items.Add(oBrand.BrandDesc);
            }
            cmbBrand.SelectedIndex = 0;

            _oProductGroups = new ProductGroups();
            _oProductGroups.GETPG();
            cmbPG.Items.Clear();
            cmbPG.Items.Add("-- Select PG --");
            foreach (ProductGroup oProductGroup in _oProductGroups)
            {
                cmbPG.Items.Add(oProductGroup.PdtGroupName);
            }
            cmbPG.SelectedIndex = 0;

            //cmbMag.Items.Clear();
            //cmbMag.Items.Add("-- Select MAG --");
            //cmbMag.SelectedIndex = 0;

        }

        private void DataLoad()
        {

            if(cmbPG.SelectedIndex == 0)
            {
                MessageBox.Show(@"Please select PG", @"Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int magId = -1;
            if (cmbMag.SelectedIndex > 0)
            {
                magId = _oProductGroupsMag[cmbMag.SelectedIndex - 1].PdtGroupID;
            }
            

            Cursor = Cursors.WaitCursor;

            string spCode = txtSpCode.Text;
            string spName = txtSpName.Text;
            
            DBController.Instance.CheckConnection();
            int brandId = -1;
            if (cmbBrand.SelectedIndex > 0)
            {
                brandId = _oBrands[cmbBrand.SelectedIndex - 1].BrandID;
            }

            int pgId = -1;
            if (cmbPG.SelectedIndex > 0)
            {
                pgId = _oProductGroups[cmbPG.SelectedIndex - 1].PdtGroupID;
            }


            _oSparePartsRs = new SparePartsRs();
            _oSparePartsRs.GetSpForOrder(spCode,spName,brandId, pgId, magId,dtFromDate.Value,dtToDate.Value);

            Text = @"Total " + "[" + _oSparePartsRs.Count + "]";
            dgvOrder.Rows.Clear();

            foreach (SparePartsR oSparePartsR in _oSparePartsRs)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvOrder);
                oRow.Cells[0].Value = oSparePartsR.SparePartID;
                oRow.Cells[1].Value = oSparePartsR.Code;
                oRow.Cells[2].Value = oSparePartsR.Name;
                oRow.Cells[3].Value = oSparePartsR.CostPrice;
                oRow.Cells[4].Value = oSparePartsR.SalePrice;
                oRow.Cells[5].Value = oSparePartsR.ConsumeQty;
                oRow.Cells[6].Value = oSparePartsR.CurrentStock;
                oRow.Cells[7].Value = oSparePartsR.ReorderLevel;
                
                if (oSparePartsR.ReorderLevel > oSparePartsR.CurrentStock)
                {
                    if (oSparePartsR.ConsumeQty > oSparePartsR.ReorderLevel)
                    {
                        if (oSparePartsR.CurrentStock > 0)
                        {
                            oRow.Cells[8].Value = oRow.Cells[9].Value= oSparePartsR.ConsumeQty - oSparePartsR.CurrentStock;
                        }
                        else
                        {
                            oRow.Cells[9].Value = oRow.Cells[8].Value = oSparePartsR.ConsumeQty;
                        }
                    }
                    else
                    {
                        oRow.Cells[8].Value= oRow.Cells[9].Value = oSparePartsR.ReorderLevel - oSparePartsR.CurrentStock;
                    }
                }
                else if (oSparePartsR.ReorderLevel < oSparePartsR.ConsumeQty &&
                         oSparePartsR.ConsumeQty > oSparePartsR.CurrentStock)
                {
                    oRow.Cells[8].Value = oRow.Cells[9].Value = oSparePartsR.ConsumeQty;
                }
                else
                {
                    oRow.Cells[8].Value = oRow.Cells[9].Value = 0;
                }
                
               dgvOrder.Rows.Add(oRow);
            }
            Cursor = Cursors.Default;
        }

        private void FrmSparePartsOrder_Load(object sender, EventArgs e)
        {
            LoadCombo();
            cmbMag.Enabled = false;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            Cursor = Cursors.WaitCursor;
            try
            {
                DBController.Instance.CheckConnection();
                
                if (Tag == null)
                {
                    _oCsdSparePartOrder = new CsdSparePartOrder
                    {
                        OrderDate = DateTime.Now,
                        OrderBy = Utility.UserId,
                        Status = (int) Dictionary.SpOrderStatus.Create,
                        Description = txtDescription.Text,
                        Remarks = txtRemarks.Text,
                        ConsumptionDateFrom = dtFromDate.Value,
                        ConsumptionDateTo =   dtToDate.Value
                    };
                    _oCsdSparePartOrder.Add();
                }
                else
                {
                    var csdSparePartOrder = (CsdSparePartOrder)Tag;

                    _oCsdSparePartOrder = new CsdSparePartOrder
                    {
                       OrderID = csdSparePartOrder.OrderID,
                       UpdateDate = DateTime.Now,
                       UpdateUserId = Utility.UserId,
                       Status = csdSparePartOrder.Status,
                       Remarks = txtRemarks.Text
                    };
                    _oCsdSparePartOrder.Edit();

                    _oCsdSparePartOrderItem = new CsdSparePartOrderItem
                    {
                        OrderID = csdSparePartOrder.OrderID
                    };
                    _oCsdSparePartOrderItem.Delete();
                }


                foreach (DataGridViewRow oItemRow in dgvOrder.Rows)
                {
                    if (oItemRow.Index < dgvOrder.Rows.Count)
                    {
                        if (oItemRow.Cells[9].Value == null || Convert.ToInt32(oItemRow.Cells[9].Value) <= 0)
                        {
                            continue;
                        }
                        
                        _oCsdSparePartOrderItem = new CsdSparePartOrderItem
                        {
                            SparePartID = Convert.ToInt32(oItemRow.Cells[0].Value),
                            OrderID = _oCsdSparePartOrder.OrderID,
                            CostPrice = Convert.ToDouble(oItemRow.Cells[3].Value),
                            SalePrice = Convert.ToDouble(oItemRow.Cells[4].Value),
                            Consumtion = Convert.ToInt32(oItemRow.Cells[5].Value),
                            Stock = Convert.ToInt32(oItemRow.Cells[6].Value),
                            ReorderLevel = Convert.ToInt32(oItemRow.Cells[7].Value),
                            ForecastQty = Convert.ToInt32(oItemRow.Cells[8].Value),
                            Qty = Convert.ToInt32(oItemRow.Cells[9].Value)
                        };
                        _oCsdSparePartOrderItem.Add();
                    }
                }
                
                DBController.Instance.CommitTran();
                IsThereAnyActivity = true;
                Close();
                MessageBox.Show(@"Save Successfully Order", @"Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }


            Cursor = Cursors.Default;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void chkIsDateCheck_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void cmbPG_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMag.Enabled = cmbPG.SelectedIndex > 0;
           

            if (cmbPG.SelectedIndex > 0)
            {
                _oProductGroupsMag = new ProductGroups();
                _oProductGroupsMag.Refresh(_oProductGroups[cmbPG.SelectedIndex - 1].PdtGroupID);

                cmbMag.Items.Clear();
                cmbMag.Items.Add("-- Select MAG --");
                foreach (ProductGroup oProductGroup in _oProductGroupsMag)
                {
                    cmbMag.Items.Add(oProductGroup.PdtGroupName);
                }
                cmbMag.SelectedIndex = 0;
            }
            else
            {
                cmbMag.Items.Clear();
                cmbMag.Items.Add("-- Select MAG --");
                cmbMag.SelectedIndex = 0;
            }
        }
    }
}

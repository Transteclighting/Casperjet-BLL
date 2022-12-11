using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.POS.TELWEBSERVER;
using CJ.Class;

namespace CJ.POS
{
    public partial class frmRequisiton : Form
    {
        Service oSerivce;
        DSWarehouse oDSFromWarehouse;
        DSWarehouse oDSToWarehouse;
        DSProduct oDSProduct;
        DSStock oDSStock;
        DSRequisition oDSRequisition;
        DSRequisition oDSRequisitionItem;

        CJ.Class.Web.UI.Class.WUIUtility _oWUIUtility;
        CJ.Class.ProductDetail _oProductDetail;
        CJ.Class.POS.SystemInfo oSystemInfo;

        public frmRequisiton()
        {
            InitializeComponent();
        }
        private void frmRequisiton_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add Requisition";
                try
                {
                    Loadcmb();
                }
                catch
                {
                    MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else this.Text = "Update Requisition";
            oSerivce = new Service();

            try
            {
                //oDSProduct = new DSProduct();
                //oDSProduct = oSerivce.GetAllProduct(oDSProduct);
            }
            catch
            {
                MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        
        }
        public void Loadcmb()
        {
            cmbFromWarehouse.Items.Clear();
            oDSFromWarehouse = new DSWarehouse();
            oSerivce = new Service();
            DSWarehouse.WarehouseRow oWarehouseRow = oDSFromWarehouse.Warehouse.NewWarehouseRow();
            //oWarehouseRow.UserID = Utility.UserId.ToString();
            oDSFromWarehouse.Warehouse.AddWarehouseRow(oWarehouseRow);
            oDSFromWarehouse.AcceptChanges();

            oDSFromWarehouse = oSerivce.FromWarehouse(oDSFromWarehouse);

            if (oDSFromWarehouse != null)
            {
                cmbFromWarehouse.ValueMember = "WarehouseID";
                cmbFromWarehouse.DisplayMember = "WarehouseName";
                cmbFromWarehouse.DataSource = oDSFromWarehouse.Warehouse;

            }
            oSystemInfo = new CJ.Class.POS.SystemInfo();
            CJ.Class.DBController.Instance.OpenNewConnection();
            oSystemInfo.Refresh();
            CJ.Class.DBController.Instance.CloseConnection();
            if (oSystemInfo.OperationDate != null)
                dtRequisitionDate.Value = Convert.ToDateTime(oSystemInfo.OperationDate.ToString()).Date;
            else
            {
                MessageBox.Show("Please Start Operation Date ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }
        public void ShowDialog(DSRequisition oDSRequisition)
        {
            int nRequisitionID = 0;
            cmbFromWarehouse.Enabled = false;
            cmbToWarehouse.Enabled = false;
            Loadcmb();

            dtRequisitionDate.Value = Convert.ToDateTime(oDSRequisition.Requisition[0].RequisitionDate);
            cmbFromWarehouse.SelectedValue = int.Parse(oDSRequisition.Requisition[0].FromWHID);
            cmbToWarehouse.SelectedValue = int.Parse(oDSRequisition.Requisition[0].ToWHID);
            txtRemarks.Text = oDSRequisition.Requisition[0].Remarks;

            nRequisitionID = int.Parse(oDSRequisition.Requisition[0].RequisitionID);

            this.Tag = oDSRequisition;      

            oDSRequisitionItem = new DSRequisition();
            oSerivce = new Service();
            try
            {
                oDSRequisitionItem = oSerivce.RequisitionRefreshItem(oDSRequisitionItem, nRequisitionID);
            }
            catch
            {
                MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (DSRequisition.RequisitionItemRow oRequisitionItemRow in oDSRequisitionItem.RequisitionItem)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLineItem);

                oRow.Cells[0].Value = oRequisitionItemRow.ProductCode;
                oRow.Cells[2].Value = oRequisitionItemRow.ProductName;            
                oRow.Cells[5].Value = oRequisitionItemRow.RequisitingQty;
                oRow.Cells[6].Value = oRequisitionItemRow.ProductID;
          
                try
                {
                    //oDSStock = oSerivce.GetCurrentStock(oDSStock, int.Parse(cmbFromWarehouse.SelectedValue.ToString()), int.Parse(oRequisitionItemRow.ProductID),false);
                    _oWUIUtility = new CJ.Class.Web.UI.Class.WUIUtility();
                    CJ.Class.DBController.Instance.OpenNewConnection();
                    _oWUIUtility.GetPOSStock(int.Parse(cmbFromWarehouse.SelectedValue.ToString()), int.Parse(oRequisitionItemRow.ProductID));
                    CJ.Class.DBController.Instance.CloseConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                oRow.Cells[3].Value = _oWUIUtility.CurrentStock;   
              
                try
                {
                    //oDSStock = oSerivce.GetCurrentStock(oDSStock, int.Parse(cmbToWarehouse.SelectedValue.ToString()), int.Parse(oRequisitionItemRow.ProductID),false);
                    _oWUIUtility = new CJ.Class.Web.UI.Class.WUIUtility();
                    CJ.Class.DBController.Instance.OpenNewConnection();
                    _oWUIUtility.GetPOSStock(int.Parse(cmbToWarehouse.SelectedValue.ToString()), int.Parse(oRequisitionItemRow.ProductID));
                    CJ.Class.DBController.Instance.CloseConnection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                oRow.Cells[4].Value = _oWUIUtility.CurrentStock;   

                dgvLineItem.Rows.Add(oRow);
            }
          
            this.ShowDialog();
        }
        private void cmbFromWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
          
            oDSToWarehouse = new DSWarehouse();
            oSerivce = new Service();
            try
            {
                oDSToWarehouse = oSerivce.ToWarehouse(oDSToWarehouse, cmbFromWarehouse.SelectedValue.ToString());
            }
            catch
            {
                MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            if (oDSToWarehouse != null)
            {
                cmbToWarehouse.ValueMember = "WarehouseID";
                cmbToWarehouse.DisplayMember = "WarehouseName";
                cmbToWarehouse.DataSource = oDSToWarehouse.Warehouse;

            }
        }
        private void dgvLineItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int nRowIndex = 0;
            oSerivce = new Service();
            if (e.ColumnIndex == 1)
            {
                if (cmbFromWarehouse.SelectedValue == null)
                {
                    MessageBox.Show("Please select from warehouse.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (cmbToWarehouse.SelectedValue == null)
                {
                    MessageBox.Show("Please select requiest warehouse.","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                cmbFromWarehouse.Enabled = false;
                cmbToWarehouse.Enabled = false;

                frmProductSearch oForm = new frmProductSearch(int.Parse(cmbFromWarehouse.SelectedValue.ToString()));
                oForm.ShowDialog();
                if (oForm.oDSSelectedProduct != null)
                {
                    foreach (CJ.Class.POS.DSProduct.ProductRow oProductRow in oForm.oDSSelectedProduct.Product)
                    {
                        DataGridViewRow oRow = new DataGridViewRow();
                        oRow.CreateCells(dgvLineItem);
                        oRow.Cells[0].Value = oProductRow.ProductCode;
                        oRow.Cells[2].Value = oProductRow.ProductName;
                        oRow.Cells[6].Value = oProductRow.ProductID;
                     
                        try
                        {
                            _oWUIUtility = new CJ.Class.Web.UI.Class.WUIUtility();
                            CJ.Class.DBController.Instance.OpenNewConnection();
                            _oWUIUtility.GetPOSStock(int.Parse(cmbFromWarehouse.SelectedValue.ToString()), int.Parse(oRow.Cells[6].Value.ToString()));
                            CJ.Class.DBController.Instance.CloseConnection();
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("Error..."+ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        oRow.Cells[3].Value = _oWUIUtility.CurrentStock;                     
                     
                        try
                        {
                            //oDSStock = oSerivce.GetCurrentStock(oDSStock, int.Parse(cmbToWarehouse.SelectedValue.ToString()), int.Parse(oRow.Cells[6].Value.ToString()),false);
                            _oWUIUtility = new CJ.Class.Web.UI.Class.WUIUtility();
                            CJ.Class.DBController.Instance.OpenNewConnection();
                            _oWUIUtility.GetPOSStock(int.Parse(cmbToWarehouse.SelectedValue.ToString()), int.Parse(oRow.Cells[6].Value.ToString()));
                            CJ.Class.DBController.Instance.CloseConnection();
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        oRow.Cells[4].Value = _oWUIUtility.CurrentStock;   
                      
                       
                        nRowIndex = dgvLineItem.Rows.Add(oRow);

                        if (checkDuplicateLineItem(dgvLineItem.Rows[nRowIndex].Cells[0].Value.ToString()) > 1)
                        {
                            MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dgvLineItem.Rows.RemoveAt(nRowIndex);
                            return;
                        }
                        else
                        {
                            dgvLineItem.Rows[e.RowIndex].Cells[0].ReadOnly = true;
                          
                        }

                    }
                }
            }
           
        }
        private void dgvLineItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            {
                if (cmbFromWarehouse.SelectedValue == null)
                {
                    MessageBox.Show("Please select from warehouse.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (cmbToWarehouse.SelectedValue == null)
                {
                    MessageBox.Show("Please select requiest warehouse.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                cmbFromWarehouse.Enabled = false;
                cmbToWarehouse.Enabled = false;
                if (e.ColumnIndex == 0)
                    refreshRow(e.RowIndex, e.ColumnIndex);
                else if (e.ColumnIndex == 5)
                {
                    CJ.Class.DBController.Instance.OpenNewConnection();
                    _oProductDetail.ProductCode = dgvLineItem.Rows[e.RowIndex].Cells[0].Value.ToString();
                    _oProductDetail.RefreshByCode();
                    CJ.Class.DBController.Instance.CloseConnection();

                    try
                    {
                        dgvLineItem.Rows[e.RowIndex].Cells[7].Value = Convert.ToString(Convert.ToDouble(dgvLineItem.Rows[e.RowIndex].Cells[5].Value.ToString()) * Convert.ToDouble(_oProductDetail.RSP));
                    }
                    catch
                    {
                        MessageBox.Show("Please Cheak Requisition Qty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvLineItem.Rows[e.RowIndex].Cells[5].Value = 0;

                    }
                }
            }
        }
        private void refreshRow(int nRowIndex, int nColumnIndex)
        {
            string sProductCode = "";         

            if (nColumnIndex == 0 && dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString() != "")
            {
                if (checkDuplicateLineItem(dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString()) > 1)
                {
                    MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dgvLineItem.Rows.RemoveAt(nRowIndex);
                    return;
                }
                try
                {
                    sProductCode = dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].Value.ToString();

                    _oProductDetail = new ProductDetail();
                    try
                    {
                        //oDSProduct = oSerivce.GetProductDetail(oDSProduct, sProductCode);
                        CJ.Class.DBController.Instance.OpenNewConnection();
                        _oProductDetail.ProductCode = sProductCode;
                        _oProductDetail.RefreshByCode();
                        CJ.Class.DBController.Instance.CloseConnection();
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (_oProductDetail.Flag==true)
                    {
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 2].Value = _oProductDetail.ProductName;
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 6].Value = _oProductDetail.ProductID;                       
                      
                        try
                        {
                            //oDSStock = oSerivce.GetCurrentStock(oDSStock, int.Parse(cmbFromWarehouse.SelectedValue.ToString()), int.Parse(oDSProduct.Product[0].ProductID.ToString()),false);
                            _oWUIUtility = new CJ.Class.Web.UI.Class.WUIUtility();
                            CJ.Class.DBController.Instance.OpenNewConnection();
                            _oWUIUtility.GetPOSStock(int.Parse(cmbFromWarehouse.SelectedValue.ToString()), _oProductDetail.ProductID);
                            CJ.Class.DBController.Instance.CloseConnection();
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("Error..."+ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dgvLineItem.Rows.RemoveAt(nRowIndex);
                            return;
                        }
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 3].Value = _oWUIUtility.CurrentStock;
                   
                        try
                        {
                            //oDSStock = oSerivce.GetCurrentStock(oDSStock, int.Parse(cmbToWarehouse.SelectedValue.ToString()), _oProductDetail.ProductID, false);
                            _oWUIUtility = new CJ.Class.Web.UI.Class.WUIUtility();
                            CJ.Class.DBController.Instance.OpenNewConnection();
                            _oWUIUtility.GetPOSStock(int.Parse(cmbToWarehouse.SelectedValue.ToString()), _oProductDetail.ProductID);
                            CJ.Class.DBController.Instance.CloseConnection();
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dgvLineItem.Rows.RemoveAt(nRowIndex);
                            return;
                        }
                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex + 4].Value = _oWUIUtility.CurrentStock;

                        dgvLineItem.Rows[nRowIndex].Cells[nColumnIndex].ReadOnly = true;

                    }
                    else
                    {
                        MessageBox.Show("Product Not Found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvLineItem.Rows.RemoveAt(nRowIndex);
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalied Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }       
            
        }
 
        private int checkDuplicateLineItem(string ItemCode)
        {
            int ItemCounter = 0;
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    if (oItemRow.Cells[0].Value == null)
                    {
                        continue;
                    }
                    if (oItemRow.Cells[0].Value.ToString().Trim() == ItemCode)
                    {
                        ItemCounter++;
                    }
                }
            }
            return ItemCounter;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();              
                this.Close();
            }
            else MessageBox.Show("Please cheak input", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool validateUIInput()
        {
            #region Master Information Validation

            if (cmbFromWarehouse.SelectedValue == null)           
            {               
                return false;
            }
            if (cmbToWarehouse.SelectedValue == null)
            {
                return false ;
            }

            #endregion

            #region Details Information Validation
            if (dgvLineItem.Rows.Count == 1)
            {
                return false;
            }
            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    if (oItemRow.Cells[6].Value == null)
                    {
                        return false;
                    }
                    if (oItemRow.Cells[6].Value.ToString().Trim() == "")
                    {
                        return false;
                    }
                    if (oItemRow.Cells[5].Value == null)
                    {
                        return false;
                    }
                    if (oItemRow.Cells[5].Value.ToString().Trim() == "")
                    {
                        return false;
                    }
                    try
                    {
                        double temp = Convert.ToDouble(oItemRow.Cells[5].Value.ToString());
                    }
                    catch
                    {
                        return false;
                    }
                   
                }
            }
            #endregion
            return true;
        }
        public void Save()
        {
            if (this.Tag == null)
            {
                oDSRequisition = new DSRequisition();
                oDSRequisition = GetUIData(oDSRequisition);
                oSerivce = new Service();

                try
                {
                    oDSRequisition = oSerivce.InsertRequisition(oDSRequisition);

                    if (oDSRequisition.Requisition[0].Result == "1")
                        MessageBox.Show("You Have Successfully Save Requisition, Requisition No - " + oDSRequisition.Requisition[0].RequisitionNo, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show(oDSRequisition.Requisition[0].Result, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch
                {
                    MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                oDSRequisition = (DSRequisition)this.Tag;

                oDSRequisition.Requisition[0].RequisitionDate = dtRequisitionDate.Value;
                oDSRequisition.Requisition[0].Remarks = txtRemarks.Text;

                oDSRequisition.RequisitionItem.Clear();

                foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
                {
                    if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                    {
                        DSRequisition.RequisitionItemRow oRequisitionItemRow = oDSRequisition.RequisitionItem.NewRequisitionItemRow();

                        oRequisitionItemRow.RequisitionID = "-1";
                        oRequisitionItemRow.ProductID = oItemRow.Cells[6].Value.ToString().Trim();
                        oRequisitionItemRow.RequisitingQty = int.Parse(oItemRow.Cells[5].Value.ToString().Trim());

                        oDSRequisition.RequisitionItem.AddRequisitionItemRow(oRequisitionItemRow);
                        oDSRequisition.AcceptChanges();
                    }
                }
                oSerivce = new Service();
                try
                {
                    oDSRequisition = oSerivce.UpdateRequisition(oDSRequisition);

                    if (oDSRequisition.Requisition[0].Result == "1")
                        MessageBox.Show("You Have Successfully Update Requisition, Requisition No - " + oDSRequisition.Requisition[0].RequisitionNo, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Erorr....Please Check in input", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch
                {
                    MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
               
        }       
        
        public DSRequisition GetUIData(DSRequisition oDSRequisition)
        {
            DSRequisition.RequisitionRow oRequisitionRow = oDSRequisition.Requisition.NewRequisitionRow();

            oRequisitionRow.RequisitionID = "-1";
            oRequisitionRow.RequisitionDate = dtRequisitionDate.Value;
            oRequisitionRow.FromWHID = cmbFromWarehouse.SelectedValue.ToString();
            oRequisitionRow.ToWHID = cmbToWarehouse.SelectedValue.ToString();
            oRequisitionRow.CreateUserID = Utility.UserId.ToString();
            oRequisitionRow.CreateDate = DateTime.Today.Date;
            oRequisitionRow.Remarks = txtRemarks.Text;

            oDSRequisition.Requisition.AddRequisitionRow(oRequisitionRow);
            oDSRequisition.AcceptChanges();

              //Loop for Grid View

            foreach (DataGridViewRow oItemRow in dgvLineItem.Rows)
            {
                if (oItemRow.Index < dgvLineItem.Rows.Count - 1)
                {
                    DSRequisition.RequisitionItemRow oRequisitionItemRow = oDSRequisition.RequisitionItem.NewRequisitionItemRow();

                    oRequisitionItemRow.RequisitionID = "-1"; 
                    oRequisitionItemRow.ProductID = oItemRow.Cells[6].Value.ToString().Trim(); 
                    oRequisitionItemRow.RequisitingQty =int.Parse( oItemRow.Cells[5].Value.ToString().Trim());            

                    oDSRequisition.RequisitionItem.AddRequisitionItemRow(oRequisitionItemRow);
                    oDSRequisition.AcceptChanges();
                }
            }
            return oDSRequisition;
        }
     
      
    }
}
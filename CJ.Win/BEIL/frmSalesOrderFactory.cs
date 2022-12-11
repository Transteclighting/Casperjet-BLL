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
using CJ.Class.BEIL;

namespace CJ.Win.BEIL 
{
    public partial class frmSalesOrderFactory : Form
    {
        SalesOrderFactory oSalesOrderFactory;
        SalesOrderFactorys oSalesOrderFactorys;
        Customers _oCustomers;
        ProductDetail _oProductDetail;
        ProductDetails _oProductDetails;
        int nCustomerID = 0;
        int _nStatus = 0;
        public frmSalesOrderFactory(int nStatus)
        {
            _nStatus = nStatus;
            InitializeComponent();
        }

        private void frmSalesOrderFactory_Load(object sender, EventArgs e)
        {
            if (this.Tag == null || this.Tag == " ")
            {
                LoadCombo();
            }

        }
        private void LoadCombo()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            _oCustomers = new Customers();
            _oCustomers.GetBEILCustomer();
            cmbCust.Items.Clear();
            cmbCust.Items.Add("<All Customer>");
            foreach (Customer oCustomer in _oCustomers)
            {
                cmbCust.Items.Add(oCustomer.CustomerName);
            }
            cmbCust.SelectedIndex = 0;


        }
        private bool validateUIInput()
        {
            if (cmbCustomer.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select a Customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbCustomer.Focus();
                return false;
            }
            //if (txtRemks.Text.Trim() == "")
            //{
            //    MessageBox.Show("Please Input Remarks", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtRemks.Focus();
            //    return false;
            //}

            return true;
        }
        public SalesOrderFactory GetUIData(SalesOrderFactory oSalesOrderFactory)
        {                                
            oSalesOrderFactory.CustomerID = _oCustomers[cmbCust.SelectedIndex - 1].CustomerID;
            oSalesOrderFactory.OrderDate = DateTime.Now;
            oSalesOrderFactory.OrderValue = Convert.ToDouble(txtAmnt.Text.ToString());
            oSalesOrderFactory.CreateUserID = Utility.UserId;
            oSalesOrderFactory.CreateDate = DateTime.Now;
            oSalesOrderFactory.UpdateUserID = Utility.UserId;
            oSalesOrderFactory.UpdateDate = DateTime.Now;
            oSalesOrderFactory.Remarks = txtRemks.Text;
            if (_nStatus == (int)Dictionary.SalesOrderFactoryStatus.Create)
            {
                oSalesOrderFactory.Status = (int)Dictionary.SalesOrderFactoryStatus.Create;
            }
            else if (_nStatus == (int)Dictionary.SalesOrderFactoryStatus.Partial_Delivery)
            {
                oSalesOrderFactory.Status = (int)Dictionary.SalesOrderFactoryStatus.Partial_Delivery;
            }
            else if (_nStatus == (int)Dictionary.SalesOrderFactoryStatus.Delivered)
            {
                oSalesOrderFactory.Status = (int)Dictionary.SalesOrderFactoryStatus.Delivered;
            }
            else
            {
                oSalesOrderFactory.Status = (int)Dictionary.SalesOrderFactoryStatus.Cancel;
            }

            // Details
            foreach (DataGridViewRow oItemRow in dgvSalesOrder.Rows)
            {
                if (oItemRow.Index < dgvSalesOrder.Rows.Count)
                {

                    SalesOrderFactoryDetail oSalesOrderFactoryDetail = new SalesOrderFactoryDetail();

                    
                    oSalesOrderFactoryDetail.OrderQty = int.Parse(oItemRow.Cells[2].Value.ToString());
                    oSalesOrderFactoryDetail.DeliveryQty = 0;
                    oSalesOrderFactoryDetail.RSP = Convert.ToDouble(oItemRow.Cells[3].Value.ToString());
                    oSalesOrderFactoryDetail.CostPrice = Convert.ToDouble(oItemRow.Cells[4].Value.ToString());
                    oSalesOrderFactoryDetail.ProductID = int.Parse(oItemRow.Cells[5].Value.ToString());
                   
                    oSalesOrderFactory.Add(oSalesOrderFactoryDetail);

                }
            }
            return oSalesOrderFactory;
        }
        private void Clear()
        {
            ctlProduct3.txtCode.Text= "";
            txtQanty.Text= "";

        }
        private void refreshRow(int nRowIndex, int nColumnIndex)
        {
            //int Qty = Convert.ToInt32(dgvSalesOrder.Rows[nRowIndex].Cells[2].Value.ToString());
            //dgvSalesOrder.Rows[nRowIndex].Cells[6].Value = Convert.ToDouble(dgvSalesOrder.Rows[nRowIndex].Cells[3].Value.ToString()) * Qty;
            //GetTotal();
        }
        private void GetTotal()
        {
            txtAmnt.Text = "0.00";
            double nTotal = 0;
            foreach (DataGridViewRow oRow in dgvSalesOrder.Rows)
            {
                if (oRow.Cells[2].Value != null)
                {
                    //txtAmnt.Text = Convert.ToDouble(Convert.ToDouble(txtAmnt.Text) + Convert.ToDouble(oRow.Cells[3].Value.ToString())).ToString(); 
                    nTotal += Convert.ToDouble(oRow.Cells[2].Value.ToString())* Convert.ToDouble(oRow.Cells[3].Value.ToString());

                }
                txtAmnt.Text = nTotal.ToString();
            }
        }
        private void Save()
        {
            if (this.Tag != null)
            {
                if (validateUIInput())
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        SalesOrderFactory oSalesOrderFactory = (SalesOrderFactory)this.Tag;
                        oSalesOrderFactory = GetUIData(oSalesOrderFactory);
                       // oSalesOrderFactory.Edit(_nStatus);
                        //if (_nStatus == (int)Dictionary.SalesOrderFactoryStatus.PO_WO)
                        //{
                        //    ADDSalesOrderFactoryHistory(oSalesOrderFactory);
                        //}
                        DBController.Instance.CommitTran();
                        MessageBox.Show("Success fully Update SalesOrderFactory # " + oSalesOrderFactory.OrderNumber.ToString(), "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show("Error... " + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else
            {


                if (validateUIInput())
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        oSalesOrderFactory = new SalesOrderFactory();
                        oSalesOrderFactory = GetUIData(oSalesOrderFactory);
                        oSalesOrderFactory.Status = (int)Dictionary.SalesOrderFactoryStatus.Create;
                        oSalesOrderFactory.Add();                       
                        DBController.Instance.CommitTran();
                        MessageBox.Show("Successfully Add SalesOrderFactory # " + oSalesOrderFactory.OrderNumber.ToString(), "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        private void AddOrderList()
        {
            _oProductDetail = new ProductDetail();
            _oProductDetail.RefreshBySalesFactory(ctlProduct3.txtCode.Text);           
            DataGridViewRow oRow = new DataGridViewRow();
            oRow.CreateCells(dgvSalesOrder);
            oRow.Cells[0].Value = _oProductDetail.ProductCode;
            oRow.Cells[1].Value = _oProductDetail.ProductName;
            oRow.Cells[2].Value = txtQanty.Text;
            oRow.Cells[3].Value = _oProductDetail.RSP.ToString();
            oRow.Cells[4].Value = _oProductDetail.CostPrice.ToString();
            oRow.Cells[5].Value = _oProductDetail.ProductID.ToString();
            dgvSalesOrder.Rows.Add(oRow);

        }
        private void btnAddlist_Click(object sender, EventArgs e)
        {           
            if (CheckDuplicate())
            {
                AddOrderList();
                Clear();
            }
            else
            {
                MessageBox.Show("Duplicate Product can't be added");
            }
            GetTotal();
        }
        private bool CheckDuplicate()
        {

            foreach (DataGridViewRow oItemRow in dgvSalesOrder.Rows)
            {
                if (oItemRow.Index < dgvSalesOrder.Rows.Count)
                {
                    if (ctlProduct3.txtCode.Text == oItemRow.Cells[0].Value.ToString())
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                Clear();

            }
        }

        private void btnCancl_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvSalesOrder_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            GetTotal();
        }

        private void dgvSalesOrder_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            {
                refreshRow(e.RowIndex, e.ColumnIndex);
            }
            GetTotal();
        }
    }
}

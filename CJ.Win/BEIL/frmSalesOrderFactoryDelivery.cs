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
    public partial class frmSalesOrderFactoryDelivery : Form
    {
        SalesOrderFactory oSalesOrderFactory;
        SalesOrderFactoryDetail _oSalesOrderFactoryDetail;
        SalesOrderFactoryDeliverys _oSalesOrderFactoryDeliverys;
        SalesOrderFactoryDelivery _oSalesOrderFactoryDelivery;
        Customers _oCustomers;
        int _nStatus = 0;
        int _nOrderId = 0;
        int _nId = 0;
        int Sum = 0;
        public frmSalesOrderFactoryDelivery(int nStatus)
        {
            _nStatus = nStatus;
            InitializeComponent();
        }
        public void ShowDialog(SalesOrderFactory oSalesOrderFactory)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            //this.Tag = oSalesOrderFactory;
            _nOrderId = oSalesOrderFactory.OrderID;
            txtOrderNo.Text = oSalesOrderFactory.OrderNumber;
            LoadCombo();
            cmbCustomer.SelectedIndex= _oCustomers.GetIndex(oSalesOrderFactory.CustomerID)+1;
            SalesOrderFactoryDeliverys _oSalesOrderFactoryDeliverys = new SalesOrderFactoryDeliverys();
            _oSalesOrderFactoryDeliverys.RefreshBySalesOrderDetails(_nOrderId);
            foreach (SalesOrderFactoryDelivery oSalesOrderFactoryDelivery in _oSalesOrderFactoryDeliverys)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvSalesOrderDelivery);
                oRow.Cells[0].Value = oSalesOrderFactoryDelivery.ProductCode;
                oRow.Cells[1].Value = oSalesOrderFactoryDelivery.Productname;
                oRow.Cells[2].Value = oSalesOrderFactoryDelivery.OrderQty;
                oRow.Cells[3].Value = oSalesOrderFactoryDelivery.DeliveryQty;
                oRow.Cells[4].Value = int.Parse(oRow.Cells[2].Value.ToString())- int.Parse(oRow.Cells[3].Value.ToString());               
                oRow.Cells[5].Value = oSalesOrderFactoryDelivery.ProductID;
                oRow.Cells[6].Value = oSalesOrderFactoryDelivery.ID;
                dgvSalesOrderDelivery.Rows.Add(oRow);
            }
            GetTotal();
            this.ShowDialog();
        }
        private void LoadCombo()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            _oCustomers = new Customers();
            _oCustomers.GetBEILCustomer();
            cmbCustomer.Items.Clear();
            cmbCustomer.Items.Add("<All Customer>");
            foreach (Customer oCustomer in _oCustomers)
            {
                cmbCustomer.Items.Add(oCustomer.CustomerName);
            }
            cmbCustomer.SelectedIndex = 0;


        }
        private void frmSalesOrderFactoryDelivery_Load(object sender, EventArgs e)
        {
            if (_nStatus == (int)Dictionary.SalesOrderFactoryStatus.Create || _nStatus == (int)Dictionary.SalesOrderFactoryStatus.Partial_Delivery)
            {
                btnSave.Text = "Save";
            }
            else if (_nStatus == (int)Dictionary.SalesOrderFactoryStatus.Cancel)
            {
                btnSave.Text = "Cancel";
            }
        }
        private bool validateUIInput()
        {
            #region Transaction Details Information Validation

            foreach (DataGridViewRow oItemRow in dgvSalesOrderDelivery.Rows)
            {
                if (oItemRow.Index < dgvSalesOrderDelivery.Rows.Count - 1)
                {
                    //if (oItemRow.Cells[3].Value == null)
                    //{
                    //    MessageBox.Show("Please Input Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    return false;
                    //}
                    if (int.Parse(oItemRow.Cells[2].Value.ToString()) < int.Parse(oItemRow.Cells[4].Value.ToString())|| int.Parse(oItemRow.Cells[4].Value.ToString()) <=0)
                    {
                        MessageBox.Show("Delivery Qty not grater than Order Qty/Zero Qty/Negative Qty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }                   
                }
            }
            #endregion

            return true;
        }
        private void Save()
        {
            if (this.Tag == null)
            {
                try
            {
                DBController.Instance.BeginNewTransaction();
                foreach (DataGridViewRow oItemRow in dgvSalesOrderDelivery.Rows)
                {
                    if (oItemRow.Index < dgvSalesOrderDelivery.Rows.Count)
                    {
                        SalesOrderFactoryDelivery oSalesOrderFactoryDelivery = new SalesOrderFactoryDelivery();

                        oSalesOrderFactoryDelivery.OrderID = _nOrderId;
                        oSalesOrderFactoryDelivery.ProductID = int.Parse(oItemRow.Cells[5].Value.ToString());
                        oSalesOrderFactoryDelivery.DeliveryQty = int.Parse(oItemRow.Cells[4].Value.ToString());
                        oSalesOrderFactoryDelivery.Deliverydate = DateTime.Now;
                        oSalesOrderFactoryDelivery.CreateUserID = Utility.UserId;
                        oSalesOrderFactoryDelivery.CreateDate = DateTime.Now;
                        oSalesOrderFactoryDelivery.Remarks = txtRemarks.Text;
                        oSalesOrderFactoryDelivery.Add();
                        }
                    }
                    
                        foreach (DataGridViewRow oItemRow in dgvSalesOrderDelivery.Rows)
                        {

                            if (oItemRow.Index < dgvSalesOrderDelivery.Rows.Count)
                            {                        
                            SalesOrderFactoryDetail oSalesOrderFactoryDetail = new SalesOrderFactoryDetail();
                            oSalesOrderFactoryDetail.ID = int.Parse(oItemRow.Cells[6].Value.ToString());
                            oSalesOrderFactoryDetail.OrderID = _nOrderId;
                            oSalesOrderFactoryDetail.DeliveryQty = int.Parse(oItemRow.Cells[4].Value.ToString());
                            oSalesOrderFactoryDetail.UpdateByDeliveryWise(_nOrderId, oSalesOrderFactoryDetail.ID);
                        }
                    }

                    oSalesOrderFactory = new SalesOrderFactory();
                oSalesOrderFactory.UpdateUserID = Utility.UserId;
                oSalesOrderFactory.UpdateDate = DateTime.Now;

                    foreach (DataGridViewRow oItemRow in dgvSalesOrderDelivery.Rows)
                    {
                        if (oItemRow.Index < dgvSalesOrderDelivery.Rows.Count)
                        {
                            if (int.Parse(oItemRow.Cells[2].Value.ToString())!= int.Parse(oItemRow.Cells[3].Value.ToString())+ int.Parse(oItemRow.Cells[4].Value.ToString()))
                            {
                                _nStatus = (int)Dictionary.SalesOrderFactoryStatus.Partial_Delivery;
                            }
                            else if (int.Parse(oItemRow.Cells[2].Value.ToString()) == int.Parse(oItemRow.Cells[3].Value.ToString()) + int.Parse(oItemRow.Cells[4].Value.ToString()))
                            {
                                _nStatus = (int)Dictionary.SalesOrderFactoryStatus.Delivered;
                            }
                        }                       
                    }                   
                    oSalesOrderFactory.EditByStatus(_nOrderId, _nStatus);
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
        private void refreshRow(int nRowIndex, int nColumnIndex)
        {
            GetTotal();
        }
        private void GetTotal()
        {
            txtOrdertotal.Text= "0.00";
            txtdeliveredTotal.Text = "0.00";
            double nTotal = 0;
            foreach (DataGridViewRow oRow in dgvSalesOrderDelivery.Rows)
            {
                if (oRow.Cells[4].Value != null)
                {
                    txtOrdertotal.Text = Convert.ToDouble(Convert.ToDouble(txtOrdertotal.Text) + Convert.ToDouble(oRow.Cells[2].Value.ToString())).ToString();
                    txtdeliveredTotal.Text = Convert.ToDouble(Convert.ToDouble(txtdeliveredTotal.Text) + Convert.ToDouble(oRow.Cells[4].Value.ToString())).ToString();

                }

            }
        }
        private void dgvSalesOrderDelivery_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            //{
            //    refreshRow(e.RowIndex, e.ColumnIndex);
            //}
            //GetTotal();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

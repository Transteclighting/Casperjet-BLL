using System;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD.Store;
using CJ.Report;
using CJ.Report.CSD;
using CJ.Report.POS;
using CJ.Win.HR;

namespace CJ.Win.CSD.Store
{
    public partial class FrmSparePartsOrders : Form
    {
        private CsdSparePartOrders _oCsdSparePartOrders;
        private CsdSparePartOrderItems _orderItems;
        public FrmSparePartsOrders()
        {
            InitializeComponent();
        }

        private void dtFromDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FrmSparePartsOrder oFrm = new FrmSparePartsOrder();
            oFrm.ShowDialog();
            if (oFrm.IsThereAnyActivity)
            {
                DataLoadControl();
            }
        }

        private void FrmSparePartsOrders_Load(object sender, EventArgs e)
        {
            chkIsDateCheck.Checked = dtFromDate.Enabled = dtToDate.Enabled = true;
            DataLoadControl();
        }

        private void DataLoadControl()
        {
            Cursor = Cursors.WaitCursor;
            string orderNo = txtOrderNo.Text;

            lvwSpOrders.Items.Clear();
            _oCsdSparePartOrders = new CsdSparePartOrders();
            _oCsdSparePartOrders.Refresh(orderNo,chkIsDateCheck.Checked,dtFromDate.Value.Date,dtToDate.Value.Date);
            Text = @"Total " + "[" + _oCsdSparePartOrders.Count + "]";


            foreach (CsdSparePartOrder oCsdSparePartOrder in _oCsdSparePartOrders)
            {
                ListViewItem oItem = lvwSpOrders.Items.Add(oCsdSparePartOrder.OrderNo);
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.SpOrderStatus), oCsdSparePartOrder.Status));
                oItem.SubItems.Add(oCsdSparePartOrder.OrderDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oCsdSparePartOrder.OrderUserName);
                oItem.SubItems.Add(oCsdSparePartOrder.ConsumptionDateFrom.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oCsdSparePartOrder.ConsumptionDateTo.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oCsdSparePartOrder.Description);
                oItem.SubItems.Add(oCsdSparePartOrder.Remarks);

                oItem.Tag = oCsdSparePartOrder;
            }
            Cursor = Cursors.Default;
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwSpOrders.SelectedItems.Count == 0)
            {
                MessageBox.Show(@"Please select an item to edit", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CsdSparePartOrder oCsdSparePartOrder = (CsdSparePartOrder)lvwSpOrders.SelectedItems[0].Tag;
            if (oCsdSparePartOrder.Status != 1)
            {
                MessageBox.Show(@"You can't edit this item", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            FrmSparePartsOrder oFrmSparePartsOrder = new FrmSparePartsOrder();
            oFrmSparePartsOrder.ShowDialog(oCsdSparePartOrder);

            if (oFrmSparePartsOrder.IsThereAnyActivity)
            {
                DataLoadControl();
            }

        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            ApproveOrder();
        }

        private void ApproveOrder()
        {
            if (lvwSpOrders.SelectedItems.Count == 0)
            {
                MessageBox.Show(@"Please select an item to approve", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CsdSparePartOrder oCsdSparePartOrder = (CsdSparePartOrder)lvwSpOrders.SelectedItems[0].Tag;
            if (oCsdSparePartOrder.Status != 1)
            {
                MessageBox.Show(@"You can't approve this item", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult oResult = MessageBox.Show(@"Are you sure to approve this order: " + oCsdSparePartOrder.OrderNo + " ? ", @"Approve Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {
                Cursor = Cursors.WaitCursor;
                try
                {
                    DBController.Instance.CheckConnection();

                    oCsdSparePartOrder.Status = (int)Dictionary.SpOrderStatus.Approve;
                    oCsdSparePartOrder.UpdateDate = DateTime.Now;
                    oCsdSparePartOrder.UpdateUserId = Utility.UserId;
                    oCsdSparePartOrder.Edit();

                    DBController.Instance.CommitTran();
                    
                    DataLoadControl();
                    MessageBox.Show(@"Successfully approve order", @"Approve", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
                Cursor = Cursors.Default;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteOrder();
        }

        private void DeleteOrder()
        {
            if (lvwSpOrders.SelectedItems.Count == 0)
            {
                MessageBox.Show(@"Please select an item to approve", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CsdSparePartOrder oCsdSparePartOrder = (CsdSparePartOrder)lvwSpOrders.SelectedItems[0].Tag;
            if (oCsdSparePartOrder.Status != 1)
            {
                MessageBox.Show(@"You can't delete this item", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult oResult = MessageBox.Show(@"Are you sure to delete this order: " + oCsdSparePartOrder.OrderNo + " ? ", @"Approve Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {
                Cursor = Cursors.WaitCursor;
                try
                {
                    DBController.Instance.CheckConnection();
                    CsdSparePartOrderItem oOrderItem = new CsdSparePartOrderItem
                    {
                        OrderID = oCsdSparePartOrder.OrderID
                    };
                    oOrderItem.Delete();

                    oCsdSparePartOrder.Delete();

                    DBController.Instance.CommitTran();
                    MessageBox.Show(@"Successfully Approve Order", @"Approve", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataLoadControl();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
                Cursor = Cursors.Default;
            }
        }

        private void chkIsDateCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsDateCheck.Checked)
            {
                dtFromDate.Enabled = dtToDate.Enabled = true;
            }
            else
            {
                dtFromDate.Enabled = dtToDate.Enabled = false;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Print();
        }

        private void Print()
        {
            if (lvwSpOrders.SelectedItems.Count == 0)
            {
                MessageBox.Show(@"Please select an item to print", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Cursor = Cursors.WaitCursor;
            var oCsdSparePartOrder = (CsdSparePartOrder) lvwSpOrders.SelectedItems[0].Tag;
            _orderItems = new CsdSparePartOrderItems();
            _orderItems.Refresh(oCsdSparePartOrder.OrderID);

            var doc = new rptSparePartsOrder();
            doc.SetDataSource(_orderItems);
            doc.SetParameterValue("PrintUser", Utility.Username);
            doc.SetParameterValue("ConsumptionDate", oCsdSparePartOrder.ConsumptionDateFrom.ToString("dd-MMM-yyyy") + " To " + oCsdSparePartOrder.ConsumptionDateTo.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("OrderDate", oCsdSparePartOrder.OrderDate.ToString("dd-MMM-yyyy"));
            doc.SetParameterValue("OrderNo", oCsdSparePartOrder.OrderNo);
            doc.SetParameterValue("Description", oCsdSparePartOrder.Description);


            var frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);

            Cursor = Cursors.Default;
        }
    }
}

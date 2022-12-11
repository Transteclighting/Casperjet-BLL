using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Library;
using CJ.Class.POS;

namespace CJ.Win.Ecommerce
{
    public partial class frmECommerceLeadAssign : Form
    {
        TELLib _oTELLib;
        int nEComOrderID = 0;
        Employees oEmployees;
        Banks oBanks;
        string sShowroomcode = "";
        EcommerceOrder _oEcommerceOrder;
        int nWarehouseID = 0;
        int nPaymentType = 0;
        public frmECommerceLeadAssign()
        {
            InitializeComponent();
        }

        public void LoadCombos(string sOutlet)
        {
            DBController.Instance.OpenNewConnection();

            //Sales Person
            oEmployees = new Employees();
            cmbEmpoyee.Items.Clear();
            oEmployees.GetSalesPersonJobLocationWise(sOutlet);
            cmbEmpoyee.Items.Add("<Select Sales Person>");
            foreach (Employee oEmployee in oEmployees)
            {
                cmbEmpoyee.Items.Add(oEmployee.EmployeeName);
            }
            if (oEmployees.Count > 0)
                cmbEmpoyee.SelectedIndex = 0;

            //Bank 
            oBanks = new Banks();
            cmbBank.Items.Clear();
            oBanks.Refresh();
            cmbBank.Items.Add("<Select Bank>");
            foreach (Bank oBank in oBanks)
            {
                cmbBank.Items.Add(oBank.Name);
            }
            if (oBanks.Count > 0)
                cmbBank.SelectedIndex = 0;

            //Card Category
            cmbCardCategory.Items.Clear();
            cmbCardCategory.Items.Add("<Select Card Category>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CreditCardCategory)))
            {
                cmbCardCategory.Items.Add(Enum.GetName(typeof(Dictionary.CreditCardCategory), GetEnum));
            }
            cmbCardCategory.SelectedIndex = 0;

            //Card Type
            cmbCardType.Items.Clear();
            cmbCardType.Items.Add("<Select Card Category>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CreditCardType)))
            {
                cmbCardType.Items.Add(Enum.GetName(typeof(Dictionary.CreditCardType), GetEnum));
            }
            cmbCardType.SelectedIndex = 0;

            //Is EMI
            cmbIsEMI.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.IsEMI)))
            {
                cmbIsEMI.Items.Add(Enum.GetName(typeof(Dictionary.IsEMI), GetEnum));
            }
            cmbIsEMI.SelectedIndex = 0;

        }
        public void ShowDialog(EcommerceOrder oEcommerceOrder)
        {
            this.Tag = oEcommerceOrder;
            DBController.Instance.OpenNewConnection();
            sShowroomcode = oEcommerceOrder.Outlet;
            _oTELLib = new TELLib();
            LoadCombos(sShowroomcode);
            nEComOrderID = 0;
            nEComOrderID = oEcommerceOrder.EComOrderID;
            Showroom oShowroom = new Showroom();
            oShowroom.GetShowroomByCode(sShowroomcode);
            nWarehouseID = oShowroom.WarehouseID;
            lblOrderNo.Text = oEcommerceOrder.OrderNo;
            lblOrderDate.Text = Convert.ToDateTime(oEcommerceOrder.OrderDate).ToString("dd-MMM-yyyy");
            lblOrderType.Text = "WEB Order";
            lblAmount.Text = _oTELLib.TakaFormat(oEcommerceOrder.Amount);
            lblDiscount.Text = _oTELLib.TakaFormat(oEcommerceOrder.Discount);
            lblDeliveryCharge.Text = _oTELLib.TakaFormat(oEcommerceOrder.DeliveryCharge);
            lblCopunNo.Text = oEcommerceOrder.CopunNo;
            lbkCardType.Text = oEcommerceOrder.CardType; 
            lblCardCategory.Text = oEcommerceOrder.CardCategory;
            lblPaymentType.Text = Enum.GetName(typeof(Dictionary.ECommercePaymentType), oEcommerceOrder.PaymentType);
            lblIsEMI.Text = oEcommerceOrder.IsEMI.ToString();
            lblNoOfIns.Text = oEcommerceOrder.NoOfInstallment.ToString();
            lblApprovalNo.Text = oEcommerceOrder.ApprovalNo;
            lblInstrumentNo.Text = oEcommerceOrder.InstrumentNo;
            lblBankName.Text = oEcommerceOrder.BankName;
            nPaymentType = oEcommerceOrder.PaymentType;
            if (oEcommerceOrder.PaymentType == (int)Dictionary.ECommercePaymentType.Cash_On_Delivery)
            {
                cmbBank.Enabled = false;
                cmbCardCategory.Enabled = false;
                cmbCardType.Enabled = false;
                txtApprovalNo.Enabled = false;
                txtInstrumentNo.Enabled = false;
                txtNoofInstallment.Enabled = false;
                cmbIsEMI.Enabled = false;
            }
            else
            {
                cmbBank.Enabled = true;
                cmbCardCategory.Enabled = true;
                cmbCardType.Enabled = true;
                txtApprovalNo.Enabled = true;
                txtInstrumentNo.Enabled = true;
                txtNoofInstallment.Enabled = true;
                cmbIsEMI.Enabled = true;
            }
            lblConsumerName.Text = oEcommerceOrder.ConsumerName;
            lblAddress.Text = oEcommerceOrder.Addrress;
            lblDeliveryAddress.Text = oEcommerceOrder.DeliveryAddress;
            lblEmail.Text = oEcommerceOrder.Email;
            lblContactNo.Text = oEcommerceOrder.ContactNo;
            lblOutletName.Text = oEcommerceOrder.Outlet;
            txtRemarks.Text = oEcommerceOrder.Remarks;

            oEcommerceOrder.GetItemForHO(oEcommerceOrder.EComOrderID);
            this.Text = "Lead Assign";

            foreach (EcommerceOrderDetail oEcommerceOrderDetail in oEcommerceOrder)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLineItem);
                oRow.Cells[0].Value = oEcommerceOrderDetail.ProductCode.ToString();
                oRow.Cells[1].Value = oEcommerceOrderDetail.ProductName.ToString();
                oRow.Cells[2].Value = oEcommerceOrderDetail.IsFreeQtyName.ToString();
                oRow.Cells[3].Value = oEcommerceOrderDetail.UnitPrice.ToString();
                oRow.Cells[4].Value = oEcommerceOrderDetail.DiscountAmount.ToString();
                oRow.Cells[5].Value = oEcommerceOrderDetail.Quantity.ToString();
                oRow.Cells[6].Value = oEcommerceOrderDetail.ProductID.ToString();
                dgvLineItem.Rows.Add(oRow);

            }
            this.ShowDialog();
        }
        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool validateUIInput()
        {
            if (cmbEmpoyee.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select a Sales Person.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEmpoyee.Focus();
                return false;
            }
            if (nPaymentType == (int)Dictionary.ECommercePaymentType.PrePaid)
            {
                if (cmbBank.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select a Bank.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cmbBank.Focus();
                    return false;
                }
            }
            return true;
        }


        private void btSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                _oEcommerceOrder = new EcommerceOrder();
                _oEcommerceOrder.EComOrderID = nEComOrderID;
                _oEcommerceOrder.Status = (int)Dictionary.ECommerceOrderStatus.Assigned;
                _oEcommerceOrder.SalesPersonID = oEmployees[cmbEmpoyee.SelectedIndex - 1].EmployeeID;

                if (cmbBank.SelectedIndex != 0)
                {
                    _oEcommerceOrder.BankID = oBanks[cmbBank.SelectedIndex - 1].BankID;
                }
                else
                {
                    _oEcommerceOrder.BankID = -1;
                }


                if (cmbCardCategory.SelectedIndex != 0)
                {
                    _oEcommerceOrder.CardCategoryID = cmbCardCategory.SelectedIndex - 1;
                }
                else
                {
                    _oEcommerceOrder.CardCategoryID = -1;
                }
                if (cmbCardType.SelectedIndex != 0)
                {
                    _oEcommerceOrder.CardTypeID = cmbCardType.SelectedIndex - 1;
                }
                else
                {
                    _oEcommerceOrder.CardTypeID = -1;
                }
                _oEcommerceOrder.ApprovalNo = txtApprovalNo.Text;
                _oEcommerceOrder.InstrumentNo = txtInstrumentNo.Text;
                try
                {
                    _oEcommerceOrder.NoOfInstallment = Convert.ToInt32(txtNoofInstallment.Text);
                }
                catch
                {
                    _oEcommerceOrder.NoOfInstallment = 0;
                }
                _oEcommerceOrder.IsEMI = cmbIsEMI.SelectedIndex;
                _oEcommerceOrder.Remarks = txtRemarks.Text;


                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oEcommerceOrder.UpdateHO();
                    DataTran _oDataTran = new DataTran();
                    _oDataTran.TableName = "t_SalesInvoiceEcommerce";
                    _oDataTran.DataID = nEComOrderID;
                    _oDataTran.WarehouseID = nWarehouseID;
                    _oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                    _oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                    _oDataTran.BatchNo = 0;
                    _oDataTran.CreateDate = DateTime.Now.Date;
                    if (_oDataTran.CheckData() == false)
                    {
                        _oDataTran.AddForTDPOS();
                    }

                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
        }

    }
}
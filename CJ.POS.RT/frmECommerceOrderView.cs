using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Library;

namespace CJ.POS.RT
{

    public partial class frmECommerceOrderView : Form
    {
        TELLib _oTELLib;

        public frmECommerceOrderView()
        {
            InitializeComponent();
        }
        public void ShowDialog(EcommerceOrder oEcommerceOrder)
        {
            this.Tag = oEcommerceOrder;
            DBController.Instance.OpenNewConnection();
            _oTELLib = new TELLib();
            lblOrderNo.Text = oEcommerceOrder.OrderNo;
            lblOrderDate.Text = Convert.ToDateTime(oEcommerceOrder.OrderDate).ToString("dd-MMM-yyyy");
            lblPaymentType.Text = Enum.GetName(typeof(Dictionary.ECommerceOrderStatus), oEcommerceOrder.PaymentType);
            lblAmount.Text = _oTELLib.TakaFormat(oEcommerceOrder.Amount);
            lblDiscount.Text = _oTELLib.TakaFormat(oEcommerceOrder.Discount);
            lblDeliveryCharge.Text = _oTELLib.TakaFormat(oEcommerceOrder.DeliveryCharge);
            lblCopunNo.Text = oEcommerceOrder.CopunNo;

            lblConsumerName.Text = oEcommerceOrder.ConsumerName;
            lblAddress.Text = oEcommerceOrder.Addrress;
            lblDeliveryAddress.Text = oEcommerceOrder.DeliveryAddress;
            lblContactNo.Text = oEcommerceOrder.ContactNo;
            lblEmail.Text = oEcommerceOrder.Email;
            lblOutletName.Text = oEcommerceOrder.Outlet;
            txtRemarks.Text = oEcommerceOrder.Remarks;
            lbkCardType.Text = oEcommerceOrder.CardType;
            lblCardCategory.Text = oEcommerceOrder.CardCategory;
            lblIsEMI.Text = oEcommerceOrder.IsEMI.ToString();
            lblNoOfIns.Text = oEcommerceOrder.NoOfInstallment.ToString();
            lblApprovalNo.Text = oEcommerceOrder.ApprovalNo;
            lblInstrumentNo.Text = oEcommerceOrder.InstrumentNo;
            lblBankName.Text = oEcommerceOrder.BankName;
            lblOrderType.Text = "WEB Order";
            Employee oEmployee = new Employee();
            oEmployee.EmployeeID = oEcommerceOrder.SalesPersonID;
            oEmployee.RefreshForPOS();
            lblSalesPerson.Text = oEmployee.EmployeeName;
            Showroom oShowroom = new Showroom();
            oShowroom.ShowroomCode = oEcommerceOrder.Outlet;
            oShowroom.GetWHIDByCode();

            oEcommerceOrder.GetItem(oShowroom.WarehouseID, oEcommerceOrder.EComOrderID);
            this.Text = "E-Commerce Order";

            foreach (EcommerceOrderDetail oEcommerceOrderDetail in oEcommerceOrder)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLineItem);
                oRow.Cells[0].Value = oEcommerceOrderDetail.ProductCode.ToString();
                oRow.Cells[1].Value = oEcommerceOrderDetail.ProductName.ToString();
                oRow.Cells[2].Value = oEcommerceOrderDetail.IsFreeQtyName.ToString();
                oRow.Cells[3].Value = oEcommerceOrderDetail.CurrentStock.ToString();
                oRow.Cells[4].Value = oEcommerceOrderDetail.UnitPrice.ToString();
                oRow.Cells[5].Value = oEcommerceOrderDetail.DiscountAmount.ToString();
                oRow.Cells[6].Value = oEcommerceOrderDetail.Quantity.ToString();
                dgvLineItem.Rows.Add(oRow);
            }
            this.ShowDialog();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CJ.Win.Ecommerce
{
    public partial class frmEcomLeadAssign : Form
    {
        public frmEcomLeadAssign()
        {
            InitializeComponent();
        }

        private void frmEcomLeadAssign_Load(object sender, EventArgs e)
        {

        }

        private void btSave_Click(object sender, EventArgs e)
        {

        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        //public void ShowDialog(EcommerceOrder oEcommerceOrder)
        //{
        //    this.Tag = oEcommerceOrder;
        //    DBController.Instance.OpenNewConnection();
        //    sShowroomcode = oEcommerceOrder.Outlet;
        //    _oTELLib = new TELLib();
        //    LoadCombos(sShowroomcode);
        //    nEComOrderID = 0;
        //    nEComOrderID = oEcommerceOrder.EComOrderID;
        //    Showroom oShowroom = new Showroom();
        //    oShowroom.GetShowroomByCode(sShowroomcode);
        //    nWarehouseID = oShowroom.WarehouseID;
        //    lblOrderNo.Text = oEcommerceOrder.OrderNo;
        //    lblOrderDate.Text = Convert.ToDateTime(oEcommerceOrder.OrderDate).ToString("dd-MMM-yyyy");
        //    lblOrderType.Text = "WEB Order";
        //    lblAmount.Text = _oTELLib.TakaFormat(oEcommerceOrder.Amount);
        //    lblDiscount.Text = _oTELLib.TakaFormat(oEcommerceOrder.Discount);
        //    lblDeliveryCharge.Text = _oTELLib.TakaFormat(oEcommerceOrder.DeliveryCharge);
        //    lblCopunNo.Text = oEcommerceOrder.CopunNo;
        //    lbkCardType.Text = oEcommerceOrder.CardType;
        //    lblCardCategory.Text = oEcommerceOrder.CardCategory;
        //    lblPaymentType.Text = Enum.GetName(typeof(Dictionary.ECommercePaymentType), oEcommerceOrder.PaymentType);
        //    lblIsEMI.Text = oEcommerceOrder.IsEMI.ToString();
        //    lblNoOfIns.Text = oEcommerceOrder.NoOfInstallment.ToString();
        //    lblApprovalNo.Text = oEcommerceOrder.ApprovalNo;
        //    lblInstrumentNo.Text = oEcommerceOrder.InstrumentNo;
        //    lblBankName.Text = oEcommerceOrder.BankName;
        //    nPaymentType = oEcommerceOrder.PaymentType;
        //    if (oEcommerceOrder.PaymentType == (int)Dictionary.ECommercePaymentType.Cash_On_Delivery)
        //    {
        //        cmbBank.Enabled = false;
        //        cmbCardCategory.Enabled = false;
        //        cmbCardType.Enabled = false;
        //        txtApprovalNo.Enabled = false;
        //        txtInstrumentNo.Enabled = false;
        //        txtNoofInstallment.Enabled = false;
        //        cmbIsEMI.Enabled = false;
        //    }
        //    else
        //    {
        //        cmbBank.Enabled = true;
        //        cmbCardCategory.Enabled = true;
        //        cmbCardType.Enabled = true;
        //        txtApprovalNo.Enabled = true;
        //        txtInstrumentNo.Enabled = true;
        //        txtNoofInstallment.Enabled = true;
        //        cmbIsEMI.Enabled = true;
        //    }
        //    lblConsumerName.Text = oEcommerceOrder.ConsumerName;
        //    lblAddress.Text = oEcommerceOrder.Addrress;
        //    lblDeliveryAddress.Text = oEcommerceOrder.DeliveryAddress;
        //    lblEmail.Text = oEcommerceOrder.Email;
        //    lblContactNo.Text = oEcommerceOrder.ContactNo;
        //    lblOutletName.Text = oEcommerceOrder.Outlet;
        //    txtRemarks.Text = oEcommerceOrder.Remarks;

        //    oEcommerceOrder.GetItemForHO(oEcommerceOrder.EComOrderID);
        //    this.Text = "Lead Assign";

        //    foreach (EcommerceOrderDetail oEcommerceOrderDetail in oEcommerceOrder)
        //    {
        //        DataGridViewRow oRow = new DataGridViewRow();
        //        oRow.CreateCells(dgvLineItem);
        //        oRow.Cells[0].Value = oEcommerceOrderDetail.ProductCode.ToString();
        //        oRow.Cells[1].Value = oEcommerceOrderDetail.ProductName.ToString();
        //        oRow.Cells[2].Value = oEcommerceOrderDetail.IsFreeQtyName.ToString();
        //        oRow.Cells[3].Value = oEcommerceOrderDetail.UnitPrice.ToString();
        //        oRow.Cells[4].Value = oEcommerceOrderDetail.DiscountAmount.ToString();
        //        oRow.Cells[5].Value = oEcommerceOrderDetail.Quantity.ToString();
        //        oRow.Cells[6].Value = oEcommerceOrderDetail.ProductID.ToString();
        //        dgvLineItem.Rows.Add(oRow);

        //    }
        //    this.ShowDialog();
        //}

    }
}

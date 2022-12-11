using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;
using CJ.Class.Warranty;
using ZAM.QRCode.Codec;
using ZAM.QRCode.Codec.Data;
using ZAM.QRCode.Codec.Util;
using System.IO;
using CJ.Report;
using CJ.Report.POS;
using CJ.Class.Library;
using CJ.Class.POS;
using CJ.POS;
using CJ.POS.Invoice;

namespace CJ.POS
{
    public partial class frmECommerceOrders : Form
    {
        EcommerceOrders _oEcommerceOrders;
        EcommerceOrder _oEComOrder;
        bool IsCheck = false;
        Image iImage;
        string SL = "";
        public frmECommerceOrders()
        {
            InitializeComponent();
        }

        private void LoadCombo()
        {
            dtFromDate.Value = DateTime.Today;
            dtToDate.Value = DateTime.Today;

            //Status
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("--All--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ECommerceOrderStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.ECommerceOrderStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;

        }
        private void DataLoadControl()
        {
            _oEcommerceOrders = new EcommerceOrders();
            lvwECommerceOrder.Items.Clear();
            this.Cursor = Cursors.WaitCursor;

            int nStatus = 0;
            if (cmbStatus.SelectedIndex == 0)
            {
                nStatus = -1;
            }
            else
            {
                nStatus = cmbStatus.SelectedIndex;
            }

            DBController.Instance.OpenNewConnection();
            _oEcommerceOrders.GetEcommerceLead(dtFromDate.Value.Date, dtToDate.Value.Date, txtOrderNo.Text.Trim(), txtConsumerName.Text.Trim(), txtContactNo.Text.Trim(), txtAddress.Text.Trim(), nStatus, IsCheck);

            foreach (EcommerceOrder oEcommerceOrder in _oEcommerceOrders)
            {
                ListViewItem oItem = lvwECommerceOrder.Items.Add(oEcommerceOrder.OrderNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oEcommerceOrder.OrderDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oEcommerceOrder.Outlet.ToString());
                oItem.SubItems.Add(oEcommerceOrder.ConsumerName.ToString());
                oItem.SubItems.Add(oEcommerceOrder.ContactNo.ToString());
                oItem.SubItems.Add(oEcommerceOrder.Addrress.ToString());
                oItem.SubItems.Add(Convert.ToDouble(oEcommerceOrder.Amount).ToString());
                oItem.SubItems.Add(Convert.ToDouble(oEcommerceOrder.Discount).ToString());
                //oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.ECommercePaymentType), oEcommerceOrder.PaymentType));
                oItem.SubItems.Add(oEcommerceOrder.RefInvoiceNo.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.ECommerceOrderStatus), oEcommerceOrder.Status));

                oItem.Tag = oEcommerceOrder;
            }
            this.Cursor = Cursors.Default;
            this.Text = "E-Commerce Leads [" + _oEcommerceOrders.Count + "]";
        }
        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                dtFromDate.Enabled = false;
                dtToDate.Enabled = false;
                IsCheck = true;
            }
            else
            {
                dtFromDate.Enabled = true;
                dtToDate.Enabled = true;
                IsCheck = false;
            }
        }

        private void frmECommerceOrders_Load(object sender, EventArgs e)
        {
            LoadCombo();
            DataLoadControl();
        }
        private void CloseAllWindow()
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
            //home(false);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lvwECommerceOrder.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Data.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            EcommerceOrder oEcommerceOrder = (EcommerceOrder)lvwECommerceOrder.SelectedItems[0].Tag;
            if (oEcommerceOrder.Status == (int)Dictionary.ECommerceOrderStatus.Assigned)
            {
                //if (oEcommerceOrder.LeadType == 1)
                //{
                //    frmECommerceOrder oForm = new frmECommerceOrder(1);
                //    oForm.ShowDialog(oEcommerceOrder);
                //    DataLoadControl();
                //}
                //else
                //{
                //frmRetailInvoice ofrmRetailInvoice = new frmRetailInvoice((int)Dictionary.POSInvoiceUIControl.eStore, oEcommerceOrder.OrderNo);
                frmInvoice oInvoice = new frmInvoice((int)Dictionary.SalesType.eStore, oEcommerceOrder.OrderNo, "", "",-1);
                oInvoice.ShowDialog();
                //}


                //CloseAllWindow();
                //this.Cursor = Cursors.WaitCursor;
                //frmInvoice o = new frmInvoice((int)Dictionary.SalesType.eStore, oEcommerceOrder.OrderNo);
                //o.MdiParent = this;
                //o.MaximizeBox = true;
                //o.StartPosition = FormStartPosition.CenterScreen;
                //o.FormBorderStyle = FormBorderStyle.FixedDialog;
                //o.WindowState = FormWindowState.Maximized;
                ////o.Icon = o.MdiParent.Icon;
                //o.Show();
                ////home(false);
                //this.Cursor = Cursors.Default;

            }
            else
            {
                MessageBox.Show("Only Assigned status can be Invoiced", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnWarrantyCardPrint_Click(object sender, EventArgs e)
        {
            if (lvwECommerceOrder.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            EcommerceOrder _oEcommerceOrder = (EcommerceOrder)lvwECommerceOrder.SelectedItems[0].Tag;
            SystemInfo oSystemInfo = new SystemInfo();
            oSystemInfo.Refresh();
            WarrantyCategory oWarrantyCategory = new WarrantyCategory();
            oWarrantyCategory.GetDataForEcmOrder(_oEcommerceOrder.EComOrderID, oSystemInfo.WarehouseID);

            foreach (WarrantyParameter oWP in oWarrantyCategory)
            {
                PrintWarrantyCardForBulk(oWP.ProductID, oWP.WarrantyCardNo, oWP.ProductSerialNo, _oEcommerceOrder);
            }
            this.Cursor = Cursors.Default;
        }
        private void QRCodeGen(WarrantyParam oWarrantyParam, EcommerceOrder _oEcommerceOrder, string sBarcode, string sProductCode, string sProductName, int nParentCustID)
        {
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            try
            {
                qrCodeEncoder.QRCodeScale = 4;
                qrCodeEncoder.QRCodeVersion = 15;
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;

                String data = "" +
                "\n" + _oEcommerceOrder.OrderNo +
                "\n" + _oEcommerceOrder.OrderDate.ToString();

                data = data + "\n" + _oEcommerceOrder.ConsumerName +
                    "\n" + _oEcommerceOrder.Addrress +
                    "\n" + _oEcommerceOrder.ContactNo +
                    "\n" + _oEcommerceOrder.Email;

                data = data + "\n" + sProductCode +
                "\n" + sProductName +
                "\n" + sBarcode +
                "\n" + oWarrantyParam.ServiceWarranty +
                "\n" + oWarrantyParam.PartsWarranty +
                "\n" + oWarrantyParam.SpecialComponentWarranty +
                "\n" + nParentCustID;

                data = data + "\n" + Convert.ToString(Utility.RetailChannelID);

                iImage = qrCodeEncoder.Encode(data);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
        public void PrintWarrantyCardForBulk(int nProductID, string sWarrantyCardNo, string sBarcode, EcommerceOrder _oEcommerceOrder)
        {
            SystemInfo oSystemInfo = new SystemInfo();
            oSystemInfo.Refresh();
            WarrantyParam oWarrantyParam = new WarrantyParam();
            if (oWarrantyParam.GetWarranty(nProductID, Convert.ToDateTime(oSystemInfo.OperationDate)))
            {
                //RetailConsumer oRetailConsumer = new RetailConsumer();
                //oRetailConsumer.ConsumerID = int.Parse(_oEcommerceOrder.SundryCustomerID.ToString());
                //oRetailConsumer.CustomerID = _oSalesInvoice.CustomerID;
                //oRetailConsumer.RefreshForPOS();

                ProductDetail oProductDetail = new ProductDetail();
                oProductDetail.Refresh(nProductID);

                Employee oEmployee = new Employee();
                oEmployee.EmployeeID = _oEcommerceOrder.SalesPersonID;
                oEmployee.RefreshForPOS();
                QRCodeGen(oWarrantyParam, _oEcommerceOrder, sBarcode, oProductDetail.ProductCode, oProductDetail.ProductName, oSystemInfo.CustomerID);

                DSQRCode oDSQRCode = new DSQRCode();
                byte[] pImage = imageToByteArray(iImage);
                oDSQRCode.QRCode.AddQRCodeRow(pImage);
                oDSQRCode.AcceptChanges();

                rptWarrantyCard doc;
                doc = new rptWarrantyCard();
                doc.SetDataSource(oDSQRCode);
                doc.SetParameterValue("WarrantyCardNo", sWarrantyCardNo);

                doc.SetParameterValue("Service", oWarrantyParam.ServiceWarranty);
                doc.SetParameterValue("Spare", oWarrantyParam.PartsWarranty);
                doc.SetParameterValue("Special", oWarrantyParam.SpecialComponentWarranty);

                //if (oRetailConsumer.SalesType != (int)Dictionary.SalesType.Dealer)
                //{
                doc.SetParameterValue("Name", _oEcommerceOrder.ConsumerName);
                doc.SetParameterValue("Address", _oEcommerceOrder.Addrress);
                doc.SetParameterValue("Telephone", _oEcommerceOrder.ContactNo);
                doc.SetParameterValue("Mobile", _oEcommerceOrder.ContactNo);
                doc.SetParameterValue("Email", _oEcommerceOrder.Email);
                doc.SetParameterValue("DealerName", "");
                doc.SetParameterValue("IsDealer", false);
                doc.SetParameterValue("InvoiceDate", Convert.ToDateTime(_oEcommerceOrder.OrderDate).ToString("dd-MMM-yyyy"));
                //}
                //else
                //{
                //    doc.SetParameterValue("Name", "");
                //    doc.SetParameterValue("Address", "");
                //    doc.SetParameterValue("Telephone", "");
                //    doc.SetParameterValue("Mobile", "");
                //    doc.SetParameterValue("Email", "");
                //    doc.SetParameterValue("DealerName", _oEcommerceOrder.ConsumerName + "/" + Convert.ToDateTime(_oEcommerceOrder.OrderDate).ToString("yyyyMMdd"));
                //    doc.SetParameterValue("IsDealer", true);
                //    doc.SetParameterValue("InvoiceDate", "");
                //}

                doc.SetParameterValue("ProductName", oProductDetail.ProductName);
                doc.SetParameterValue("BrandName", oProductDetail.BrandDesc);
                doc.SetParameterValue("ProductCode", oProductDetail.ProductCode);

                doc.SetParameterValue("InvoiceNo", _oEcommerceOrder.OrderNo.ToString());
                doc.SetParameterValue("OutletName", "[" + oSystemInfo.Shortcode + "]" + "-" + oSystemInfo.WarehouseName);
                doc.SetParameterValue("Employee", oEmployee.EmployeeName);

                doc.SetParameterValue("Barcode", sBarcode);

                frmPrintPreviewWithoutExport frmView;
                frmView = new frmPrintPreviewWithoutExport();
                frmView.ShowDialog(doc);
            }
        }

        private void btnInvoicePrint_Click(object sender, EventArgs e)
        {
            if (lvwECommerceOrder.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            EcommerceOrder _EcommerceOrder = (EcommerceOrder)lvwECommerceOrder.SelectedItems[0].Tag;
            InvoiceWiseBarcode(_EcommerceOrder.EComOrderID);
            PrintRetailInvoice(_EcommerceOrder.EComOrderID);
            this.Cursor = Cursors.Default;
        }
        public void InvoiceWiseBarcode(int nOrderID)
        {
            SL = "";
            EcommerceOrderDetail _oEcommerceOrderDetail = new EcommerceOrderDetail();

            _oEcommerceOrders = new EcommerceOrders();
            _oEcommerceOrders.GetProductByEComOrder(nOrderID);

            foreach (EcommerceOrderDetail SIPS in _oEcommerceOrders)
            {
                //IsSL = true;
                string PCode = "";

                EcommerceOrders _oSIPSs = new EcommerceOrders();
                _oSIPSs.GetBarcodeByEComOrderNProduct(SIPS.EcomOrderID, SIPS.ProductID);

                foreach (EcommerceOrderDetail SIPSs in _oSIPSs)
                {
                    //IsSL = false;
                    if (PCode == "")
                    {
                        PCode = "<" + SIPSs.ProductCode + ">";
                    }
                    else
                    {
                        PCode = " ";
                    }
                    if (SL != "")
                    {
                        SL = SL + ",";
                    }
                    SL = SL + PCode + SIPSs.ProductSerialNo;
                }
            }
        }
        public void PrintRetailInvoice(int nOrderID)
        {
            SystemInfo oSystemInfo = new SystemInfo();
            _oEComOrder = new EcommerceOrder();
            DBController.Instance.OpenNewConnection();
            oSystemInfo.Refresh();
            _oEComOrder.RefreshECOMOrder(nOrderID);

            CrystalDecisions.CrystalReports.Engine.ReportClass oReport = ReportFactory.GetReport(typeof(rptECommerceInvoice));
            oReport.SetDataSource(_oEComOrder);

            oReport.SetParameterValue("InvoiceTitle", "Invoice (E-Commerce)");
            oReport.SetParameterValue("HC", oSystemInfo.HCMobileNo + ", e-mail:" + oSystemInfo.HCEmail);
            oReport.SetParameterValue("Mobile", oSystemInfo.WarehouseCellNo + ", e-mail:" + oSystemInfo.WarehouseEmail);
            oReport.SetParameterValue("Address", oSystemInfo.WarehouseAddress + ", Outlet Phone No:" + oSystemInfo.WarehousePhoneNo);
            oReport.SetParameterValue("Outlet", oSystemInfo.WarehouseName);
            oReport.SetParameterValue("CustomerPhoneNo", _oEComOrder.ContactNo);
            oReport.SetParameterValue("InvoiceNo", _oEComOrder.OrderNo.ToString());
            oReport.SetParameterValue("InvoiceDate", _oEComOrder.OrderDate.ToString("dd-MMM-yyyy"));
            oReport.SetParameterValue("W/H", "[" + oSystemInfo.Shortcode + "]" + "-" + oSystemInfo.WarehouseName);
            oReport.SetParameterValue("DeliveryW/H", "[" + oSystemInfo.Shortcode + "]" + "-" + oSystemInfo.WarehouseName);
            oReport.SetParameterValue("CustomerName", _oEComOrder.ConsumerName);
            oReport.SetParameterValue("CustomerAddress", _oEComOrder.Addrress);
            oReport.SetParameterValue("CustomerCellNo", _oEComOrder.ContactNo);
            TELLib _oTELLib = new TELLib();
            oReport.SetParameterValue("AmountInWord", _oTELLib.TakaWords(_oEComOrder.Amount));
            oReport.SetParameterValue("InvoiceAmount", _oEComOrder.Amount);
            oReport.SetParameterValue("SPDiscount", _oEComOrder.Discount);
            oReport.SetParameterValue("SDiscount", 0);
            oReport.SetParameterValue("FCharge", _oEComOrder.DeliveryCharge);
            oReport.SetParameterValue("ICharge", 0);
            oReport.SetParameterValue("OCharge", 0);
            oReport.SetParameterValue("Discount", _oEComOrder.Discount);
            oReport.SetParameterValue("Charge", _oEComOrder.DeliveryCharge);
            oReport.SetParameterValue("smsDiscount", 0);
            oReport.SetParameterValue("Barcode", SL);
            oReport.SetParameterValue("Remarks", _oEComOrder.Remarks);
            oReport.SetParameterValue("EmployeeName", _oEComOrder.EmployeeName + " [" + _oEComOrder.EmployeeCode + "]");
            oReport.SetParameterValue("FooterPrintCaption", "Printed By : " + Utility.Username);

            frmPrintPreviewWithoutExport frmView;
            frmView = new frmPrintPreviewWithoutExport();
            //frmPrintPreview frmView;
            //frmView = new frmPrintPreview();
            frmView.ShowDialog(oReport);
        }

        private void btnInvoiced_Click(object sender, EventArgs e)
        {

        }

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            if (lvwECommerceOrder.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Data.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            EcommerceOrder oEcommerceOrder = (EcommerceOrder)lvwECommerceOrder.SelectedItems[0].Tag;
            if (oEcommerceOrder.Status == (int)Dictionary.ECommerceOrderStatus.Invoiced)
            {
                frmECommerceOrder oForm = new frmECommerceOrder(2);
                oForm.ShowDialog(oEcommerceOrder);
                DataLoadControl();

            }
            else
            {
                MessageBox.Show("Only Invoiced status can be Edited", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btnViewOrder_Click(object sender, EventArgs e)
        {
            if (lvwECommerceOrder.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Data.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            EcommerceOrder oEcommerceOrder = (EcommerceOrder)lvwECommerceOrder.SelectedItems[0].Tag;
            if (oEcommerceOrder.LeadType == 1)
            {
                frmECommerceOrderView oForm = new frmECommerceOrderView();
                oForm.ShowDialog(oEcommerceOrder);
            }
            else
            {
                //frmRetailInvoice ofrmRetailInvoice = new frmRetailInvoice((int)Dictionary.POSInvoiceUIControl.eStore, oEcommerceOrder.OrderNo);
                //ofrmRetailInvoice.ShowDialog();
            }

        }



    }
}
using CJ.Class;
using CJ.Class.POS;
using CJ.Class.Warranty;
using CJ.QRCode.Codec;
using CJ.Report;
using CJ.Report.POS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CJ.Win.Distribution
{
    public partial class frmPrintWarrantyCard : Form
    {
        Image iImage;
        DataTable dt = new DataTable();
        long _nInvoiceID = 0;
        WarrantyParameter oWarrantyParameter;
        RetailConsumer oRetailConsumer;
        RetailSalesInvoice oRetailSalesInvoice;
        SalesInvoiceInfo _oSalesInvoiceInfo;
        int nChannelID = 0;
        string sOutletName = "";
        string sOutletCode = "";
        public frmPrintWarrantyCard(SalesInvoiceInfo oSalesInvoiceInfo, RetailConsumer oRetailConsumerPOS)
        {
            InitializeComponent();
            _oSalesInvoiceInfo = new SalesInvoiceInfo();
            _oSalesInvoiceInfo = oSalesInvoiceInfo;
            _nInvoiceID = _oSalesInvoiceInfo.InvoiceID;
            oRetailConsumer = new RetailConsumer();
            oRetailConsumer = oRetailConsumerPOS;

            Showroom oShowroom = new Showroom();
            oShowroom.WarehouseID = _oSalesInvoiceInfo.WarehouseID;
            oShowroom.GetShowroomID();
            nChannelID = oShowroom.ChannelID;
            sOutletName = oShowroom.ShowroomName;
            sOutletCode = oShowroom.ShowroomCode;

        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            (dgvWarranty.DataSource as DataTable).DefaultView.RowFilter = string.Format("Product_Code like '%{0}%' OR Product_Name like '%{0}%' OR AG like '%{0}%' OR ASG like '%{0}%' OR MAG like '%{0}%' OR PG like '%{0}%' OR Brand like '%{0}%' OR ProductSerialNo like '%{0}%'", txtSearch.Text);
        }

        private DataTable GetDataTable(string query, CommandType commandType)
        {
            using (SqlConnection con = new SqlConnection(CJ.Class.Utility.DBConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.CommandType = commandType;
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            return dt;
                        }
                    }
                }
            }
        }

        private void DataLoadControl(long nInvoiceID)
        {
            string sQuery = @"Select ProductCode as Product_Code, ProductName as Product_Name, AGName as AG, ASGName as ASG, MAGName as MAG,
                            PGName as PG, BrandDesc as Brand, ProductSerialNo
                            From t_SalesInvoiceProductSerial a,v_ProductDetails b
                            where a.ProductID = b.ProductID and InvoiceID = " + nInvoiceID + "";
            try
            {
                dgvWarranty.DataSource = GetDataTable(sQuery, CommandType.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void frmPrintWarrantyCard_Load(object sender, EventArgs e)
        {

            DataLoadControl(_nInvoiceID);

        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                foreach (DataGridViewRow row in dgvWarranty.Rows)
                    ((DataGridViewCheckBoxCell)row.Cells["ChkBox"]).Value = checkBox1.Checked;
                dgvWarranty.RefreshEdit();
            }
            else
            {
                foreach (DataGridViewRow row in dgvWarranty.Rows)
                    ((DataGridViewCheckBoxCell)row.Cells["ChkBox"]).Value = false;
                dgvWarranty.RefreshEdit();
            }
        }

        public void PrintWarrantyCardForBulk(int nProductID, string sWarrantyCardNo, string sBarcode, int nWarehouseID, int nWarrantyParameterID, string sExtendedWarrantyDescription,string sProductCode, string sProductName, string sMAG, string sBrand)
        {

            WarrantyParam oWarrantyParam = new WarrantyParam();
            if (oWarrantyParam.GetWarrantyParamByID(nWarrantyParameterID))
            {



                QRCodeGen(oWarrantyParam, oRetailConsumer, _oSalesInvoiceInfo, sBarcode, sProductCode, sProductName, nChannelID);

                DSQRCode oDSQRCode = new DSQRCode();
                byte[] pImage = imageToByteArray(iImage);
                oDSQRCode.QRCode.AddQRCodeRow(pImage);
                oDSQRCode.AcceptChanges();


                rptWarrantyCard doc;
                doc = new rptWarrantyCard();
                doc.SetDataSource(oDSQRCode);
                doc.SetParameterValue("WarrantyCardNo", sWarrantyCardNo);
                doc.SetParameterValue("ExtendedWarranty", sExtendedWarrantyDescription);
                doc.SetParameterValue("Service", oWarrantyParam.ServiceWarranty);
                doc.SetParameterValue("Spare", oWarrantyParam.PartsWarranty);
                doc.SetParameterValue("Special", oWarrantyParam.SpecialComponentWarranty);

                if (oRetailConsumer.SalesType != 5)
                {
                    doc.SetParameterValue("Name", oRetailConsumer.ConsumerName);
                    doc.SetParameterValue("Address", oRetailConsumer.Address);
                    doc.SetParameterValue("Telephone", oRetailConsumer.PhoneNo);
                    doc.SetParameterValue("Mobile", oRetailConsumer.CellNo);
                    doc.SetParameterValue("Email", oRetailConsumer.Email);
                    doc.SetParameterValue("DealerName", "");
                    doc.SetParameterValue("IsDealer", false);
                    doc.SetParameterValue("InvoiceDate", Convert.ToDateTime(_oSalesInvoiceInfo.InvoiceDate).ToString("dd-MMM-yyyy"));
                }
                else
                {
                    doc.SetParameterValue("Name", "");
                    doc.SetParameterValue("Address", "");
                    doc.SetParameterValue("Telephone", "");
                    doc.SetParameterValue("Mobile", "");
                    doc.SetParameterValue("Email", "");
                    doc.SetParameterValue("DealerName", oRetailConsumer.ConsumerName + "/" + Convert.ToDateTime(_oSalesInvoiceInfo.InvoiceDate).ToString("yyyyMMdd"));
                    doc.SetParameterValue("IsDealer", true);
                    doc.SetParameterValue("InvoiceDate", "");
                }
                doc.SetParameterValue("ProductName", sProductName);
                doc.SetParameterValue("BrandName", sBrand);
                doc.SetParameterValue("ProductCode", sProductCode);

                doc.SetParameterValue("InvoiceNo", _oSalesInvoiceInfo.InvoiceNo.ToString());

                doc.SetParameterValue("OutletName", "[" + sOutletCode + "]" + "-" + sOutletName);
                doc.SetParameterValue("Employee", _oSalesInvoiceInfo.SalesPersonName);

                doc.SetParameterValue("Barcode", sBarcode);
                if (sMAG == "FPTV") //FPTV
                {
                    doc.SetParameterValue("SpecialComponent", "Panel");
                }
                else if (sMAG == "HTV") //HTV
                {
                    doc.SetParameterValue("SpecialComponent", "Panel");
                }
                else if (sMAG == "REF") //REF
                {
                    doc.SetParameterValue("SpecialComponent", "Compressor");
                }
                else if (sMAG == "FRZ") //FRZ
                {
                    doc.SetParameterValue("SpecialComponent", "Compressor");
                }
                else if (sMAG == "LCAC") //LCAC
                {
                    doc.SetParameterValue("SpecialComponent", "Compressor");
                }
                else if (sMAG == "RAC") //RAC
                {
                    doc.SetParameterValue("SpecialComponent", "Compressor");
                }
                else if (sMAG == "CAC") //CAC
                {
                    doc.SetParameterValue("SpecialComponent", "Compressor");
                }
                else if (sMAG == "WM") //WM
                {
                    doc.SetParameterValue("SpecialComponent", "Motor");
                }
                else
                {
                    doc.SetParameterValue("SpecialComponent", "SpecialComponent");
                }

                frmPrintPreviewWithoutExport frmView;
                frmView = new frmPrintPreviewWithoutExport();
                frmView.ShowDialog(doc);
            }
        }
        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }
        private void QRCodeGen(WarrantyParam oWarrantyParam, RetailConsumer oRetailConsumer, SalesInvoiceInfo _oSalesInvoiceInfo, string sBarcode, string sProductCode, string sProductName, int nChannelID)
        {
            QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
            qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
            try
            {
                qrCodeEncoder.QRCodeScale = 4;
                qrCodeEncoder.QRCodeVersion = 15;
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;

                String data = oRetailConsumer.ConsumerCode +
                "\n" + _oSalesInvoiceInfo.InvoiceNo +
                "\n" + _oSalesInvoiceInfo.InvoiceDate.ToString() +
                "\n" + oRetailConsumer.ConsumerName +
                "\n" + oRetailConsumer.Address +
                "\n" + oRetailConsumer.CellNo +
                "\n" + oRetailConsumer.Email +
                "\n" + sProductCode +
                "\n" + sProductName +
                "\n" + sBarcode +
                "\n" + oWarrantyParam.ServiceWarranty +
                "\n" + oWarrantyParam.PartsWarranty +
                "\n" + oWarrantyParam.SpecialComponentWarranty +
                "\n" + oRetailConsumer.ParentCustomerID +
                "\n" + Convert.ToString(nChannelID);
                iImage = qrCodeEncoder.Encode(data);
            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }


        private void PrintPosWarrantyCard()
        {
            for (int i = 0; i <= dgvWarranty.RowCount - 1; i++)
            {
                if (Convert.ToBoolean(dgvWarranty.Rows[i].Cells["ChkBox"].Value) == true)
                {

                    this.Cursor = Cursors.WaitCursor;
                    string sProductCode = dgvWarranty.Rows[i].Cells[1].Value.ToString();
                    string sProductName = dgvWarranty.Rows[i].Cells[2].Value.ToString();
                    string sMAG = dgvWarranty.Rows[i].Cells[5].Value.ToString();
                    string sBrand = dgvWarranty.Rows[i].Cells[7].Value.ToString();
                    WarrantyCategory oWarrantyCategory = new WarrantyCategory();
                    oWarrantyCategory.RefreshByProductSerialNo(Convert.ToInt32(_nInvoiceID), dgvWarranty.Rows[i].Cells[8].Value.ToString());
                    if (oWarrantyCategory.Count > 0)
                    {
                        foreach (WarrantyParameter oWP in oWarrantyCategory)
                        {
                            PrintWarrantyCardForBulk(oWP.ProductID, oWP.WarrantyCardNo, oWP.ProductSerialNo, oWP.WarehouseID, oWP.WarrantyParameterID, oWP.ExtendedWarrantyDescription, sProductCode, sProductName, sMAG, sBrand);
                        }
                    }
                    this.Cursor = Cursors.Default;
                }
                else
                {
                    MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
        }
            

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintPosWarrantyCard();
        }
    }
}

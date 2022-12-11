using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Configuration;

using CJ.Class;
using CJ.Class.Report;
using CJ.Report;

namespace CJ.Win.Distribution
{
    public partial class frmSalesInvoiceProductSerial : Form
    {

        SalesInvoiceProductSerials _oSalesInvoiceProductSerials;
        SalesInvoiceProductSerial _oSalesInvoiceProductSerial;
        string sSplit = "";
        int RowIndex = 0;
        int CustInfo = 0;
        long nInvoiceID = 0;
        int _nWarehouseID = 0;

        public frmSalesInvoiceProductSerial()
        {
            InitializeComponent();
            if (Utility.CompanyInfo == "TEL")
            {
                this.Text = "Sales Invoice Product Serial";
                groupBox3.Text = "Barcode";
                dgvProductSerial.Columns[5].HeaderText = "Barcode";
            }
            else if (Utility.CompanyInfo == "TML")
            {
                this.Text = "Sales Invoice Product IMEI";
                groupBox3.Text = "IMEI";
                dgvProductSerial.Columns[5].HeaderText = "IMEI";
            }
        }
        public void ShowDialog(SalesInvoiceProductSerial oSalesInvoiceProductSerial)
        {
            this.Tag = oSalesInvoiceProductSerial;

            lblInvoiceNo.Text = oSalesInvoiceProductSerial.InvoiceNo;
            lblCustomerCode.Text = oSalesInvoiceProductSerial.CustomerCode;
            lblCustomerName.Text = oSalesInvoiceProductSerial.CustomerName;
            _nWarehouseID = oSalesInvoiceProductSerial.WarehouseID;
            RefreshData(oSalesInvoiceProductSerial.InvoiceID);
            nInvoiceID = 0;
            nInvoiceID = oSalesInvoiceProductSerial.InvoiceID;

            this.ShowDialog();
        }
        public void RefreshData(long nInvoiceID)
        {
            DBController.Instance.OpenNewConnection();

            _oSalesInvoiceProductSerials = new SalesInvoiceProductSerials();

            _oSalesInvoiceProductSerials.Refresh(nInvoiceID);

            
            foreach (SalesInvoiceProductSerial oSalesInvoiceProductSerial in _oSalesInvoiceProductSerials)
            {

                for (int i = 0; i < oSalesInvoiceProductSerial.Quantity; i++)
                {

                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvProductSerial);

                    oRow.Cells[0].Value = oSalesInvoiceProductSerial.InvoiceID;
                    oRow.Cells[1].Value = oSalesInvoiceProductSerial.ProductID;
                    oRow.Cells[2].Value = oSalesInvoiceProductSerial.ProductCode;
                    oRow.Cells[3].Value = oSalesInvoiceProductSerial.ProductName;
                    oRow.Cells[4].Value = i + 1;
                    
                    dgvProductSerial.Rows.Add(oRow);

                }
            }

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Save()
        {
            DBController.Instance.BeginNewTransaction();
            try
            {
                foreach (DataGridViewRow oItemRow in dgvProductSerial.Rows)
                {
                    if (oItemRow.Index < dgvProductSerial.Rows.Count)
                    {
                        _oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();

                        _oSalesInvoiceProductSerial.InvoiceID = Convert.ToInt64(oItemRow.Cells[0].Value.ToString());
                        _oSalesInvoiceProductSerial.ProductID = Convert.ToInt32(oItemRow.Cells[1].Value.ToString());
                        _oSalesInvoiceProductSerial.SerialNo = Convert.ToInt32(oItemRow.Cells[4].Value.ToString());
                        _oSalesInvoiceProductSerial.ProductSerialNo = oItemRow.Cells[5].Value.ToString().Trim();

                        if (Utility.CompanyInfo == "TEL")
                        {
                            _oSalesInvoiceProductSerial.DeleteFromHO();
                            _oSalesInvoiceProductSerial.Add();
                        }
                        else if (Utility.CompanyInfo == "TML")
                        {
                            _oSalesInvoiceProductSerial.DeleteFromHO();
                            _oSalesInvoiceProductSerial.AddIMEI();
                        }

                        //#region Warranty Card Auto Print
                        //if (Utility.CompanyInfo == "TEL")
                        //{
                        //    rptWarrantyCardPrints _orptWarrantyCardPrints = new rptWarrantyCardPrints();

                        //    WarrantyCardPrintParam(_oSalesInvoiceProductSerial.InvoiceID);
                        //    _orptWarrantyCardPrints.RefreshWarrantyCardPrint(_oSalesInvoiceProductSerial.InvoiceID, _oSalesInvoiceProductSerial.ProductID, _oSalesInvoiceProductSerial.ProductSerialNo, CustInfo);

                        //    foreach (rptWarrantyCardPrint orptWarrantyCardPrint in _orptWarrantyCardPrints)
                        //    {
                        //        rptWarrantyCard_Dealer doc = new rptWarrantyCard_Dealer();


                        //        string dateformat = "";
                        //        dateformat = orptWarrantyCardPrint.InvoiceDate.ToString("ddMMyy");

                        //        doc.SetParameterValue("CustomerName", orptWarrantyCardPrint.CustomerName.ToString());
                        //        doc.SetParameterValue("Address", orptWarrantyCardPrint.Address.ToString());
                        //        doc.SetParameterValue("Telephone", orptWarrantyCardPrint.Telephone.ToString());
                        //        doc.SetParameterValue("MobileNo", orptWarrantyCardPrint.MobileNo.ToString());
                        //        doc.SetParameterValue("Email", orptWarrantyCardPrint.Email.ToString());

                        //        if (CustInfo != (int)Dictionary.WarratnyCardCustInfo.NoCustomer)
                        //        {
                        //            doc.SetParameterValue("D1", dateformat.Substring(0, 1));
                        //            doc.SetParameterValue("D2", dateformat.Substring(1, 1));
                        //            doc.SetParameterValue("M1", dateformat.Substring(2, 1));
                        //            doc.SetParameterValue("M2", dateformat.Substring(3, 1));
                        //            doc.SetParameterValue("Y1", dateformat.Substring(4, 1));
                        //            doc.SetParameterValue("Y2", dateformat.Substring(5, 1));
                        //            doc.SetParameterValue("InvoiceNo1", orptWarrantyCardPrint.InvoiceNo.ToString());

                        //        }
                        //        else
                        //        {
                        //            doc.SetParameterValue("D1", "");
                        //            doc.SetParameterValue("D2", "");
                        //            doc.SetParameterValue("M1", "");
                        //            doc.SetParameterValue("M2", "");
                        //            doc.SetParameterValue("Y1", "");
                        //            doc.SetParameterValue("Y2", "");
                        //            doc.SetParameterValue("InvoiceNo1", "");
                        //        }
                        //        doc.SetParameterValue("ProductCode", orptWarrantyCardPrint.ProductCode.ToString());
                        //        doc.SetParameterValue("ProductName", orptWarrantyCardPrint.ProductName.ToString());
                        //        doc.SetParameterValue("DealerName", orptWarrantyCardPrint.DealerName.ToString());
                        //        doc.SetParameterValue("InvoiceNo", orptWarrantyCardPrint.InvoiceNo.ToString());
                        //        doc.SetParameterValue("InvoiceDate", Convert.ToDateTime(orptWarrantyCardPrint.InvoiceDate).ToString("yyyyMMdd"));
                        //        doc.SetParameterValue("Barcode", orptWarrantyCardPrint.Barcode.ToString());
                        //        doc.SetParameterValue("Service", orptWarrantyCardPrint.ServiceWarranty.ToString());
                        //        doc.SetParameterValue("Spare", orptWarrantyCardPrint.PartsWarranty.ToString());
                        //        doc.SetParameterValue("Special", orptWarrantyCardPrint.SpecialComponentWarranty.ToString());
                        //        doc.SetParameterValue("BrandName", orptWarrantyCardPrint.BrandName.ToString());

                        //        doc.PrintToPrinter(1, true, 1, 1);

                        //    }
                        //}
                        //#endregion

                    }

                }
                DBController.Instance.CommitTran();
                MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show("Error... " + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            
        }
        private void WarrantyCardPrintParam(long nInvoiceID)
        {
            string sCommaSplit = "";
            int ChannelID = 0;
            string value = ConfigurationManager.AppSettings["WithSundryCustInfo"];
            char[] delimiter = new char[] { ',' };
            string[] parts = value.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < parts.Length; i++)
            {
                sCommaSplit = parts[i].ToString();
                ChannelID = Convert.ToInt32(sCommaSplit.Trim());
                _oSalesInvoiceProductSerial.GetChannelByInvoiceID(nInvoiceID);
                if (ChannelID == _oSalesInvoiceProductSerial.ChannelID)
                {
                    CustInfo = (int)Dictionary.WarratnyCardCustInfo.SundryCustomer;
                }
            }
            string value1 = ConfigurationManager.AppSettings["WithCustInfo"];
            char[] delimiter1 = new char[] { ',' };
            string[] parts1 = value1.Split(delimiter1, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < parts1.Length; i++)
            {
                sCommaSplit = parts1[i].ToString();
                ChannelID = Convert.ToInt32(sCommaSplit.Trim());
                if (ChannelID == _oSalesInvoiceProductSerial.ChannelID)
                {
                    CustInfo = (int)Dictionary.WarratnyCardCustInfo.PrimaryCustomer;
                }
            }

            string value2 = ConfigurationManager.AppSettings["BlankCustInfo"];
            char[] delimiter2 = new char[] { ',' };
            string[] parts2 = value2.Split(delimiter2, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < parts2.Length; i++)
            {
                sCommaSplit = parts2[i].ToString();
                ChannelID = Convert.ToInt32(sCommaSplit.Trim());
                if (ChannelID == _oSalesInvoiceProductSerial.ChannelID)
                {
                    CustInfo = (int)Dictionary.WarratnyCardCustInfo.NoCustomer;
                }
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                this.Close();
            } 
        }
        public bool validateUIInput()
        {
            Regex rgBarcode = new Regex("^[0-9]*$");
            string Barcode = null;
            string ProductCode = null;
            int ProductID = 0;

            if (dgvProductSerial.Rows.Count > 0)
            {
                foreach (DataGridViewRow oItemRow in dgvProductSerial.Rows)
                {

                    if (oItemRow.Cells[5].Value == "" || oItemRow.Cells[5].Value == null)
                    {
                        if (Utility.CompanyInfo == "TML")
                        {
                            MessageBox.Show("Please Enter IMEI", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("Please Enter Barcode Serial", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        RowIndex = oItemRow.Index;
                        CellColor(true);
                        return false;
                    }
                    else
                    {
                        RowIndex = oItemRow.Index;
                        CellColor(false);
                    }

                    if (oItemRow.Index < dgvProductSerial.Rows.Count)
                    {
                        Barcode = oItemRow.Cells[5].Value.ToString().Trim();
                        ProductCode = oItemRow.Cells[2].Value.ToString().Trim();
                        ProductID = Convert.ToInt32(oItemRow.Cells[1].Value);
                    }

                    //if (rgBarcode.IsMatch(Barcode))
                    //{
                    //    RowIndex = oItemRow.Index;
                    //    CellColor(false);
                    //}
                    //else
                    //{
                    //    MessageBox.Show("Please Enter only numeric", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //    RowIndex = oItemRow.Index;
                    //    CellColor(true);
                    //    return false;
                    //}
                    if (Utility.CompanyInfo == "TML")
                    {
                        //if (Barcode.Length != 15)
                        //{
                        //    MessageBox.Show("IMEI Length must be Eight (15) digit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    RowIndex = oItemRow.Index;
                        //    CellColor(true);
                        //    return false;
                        //}
                        //else
                        //{
                        //    RowIndex = oItemRow.Index;
                        //    CellColor(false);
                        //}
                    }
                    else
                    {
                        //if (Barcode.Length != 8)
                        //{
                        //    MessageBox.Show("Barcode Length must be Eight (8) digit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    RowIndex = oItemRow.Index;
                        //    CellColor(true);
                        //    return false;
                        //}
                        //else
                        //{
                        //    RowIndex = oItemRow.Index;
                        //    CellColor(false);
                        //}
                    }

                    _oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();
                    _oSalesInvoiceProductSerial.ProductSerialNo = Barcode.Trim();
                    _oSalesInvoiceProductSerial.ProductCode = ProductCode.Trim();
                    _oSalesInvoiceProductSerial.ProductID = ProductID;

                    if (Utility.CompanyInfo == "TEL")
                    {
                        if (_oSalesInvoiceProductSerial.CheckProductSerial())
                        {
                            MessageBox.Show("The Barcode already Used", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            RowIndex = oItemRow.Index;
                            CellColor(true);
                            return false;
                        }
                        else
                        {
                            RowIndex = oItemRow.Index;
                            CellColor(false);
                        }
                        //if (_oSalesInvoiceProductSerial.CheckGeneratedBarcode())
                        //{
                        //    MessageBox.Show("Invalid Barcode", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    RowIndex = oItemRow.Index;
                        //    CellColor(true);
                        //    return false;
                        //}
                        //else
                        //{
                        //    RowIndex = oItemRow.Index;
                        //    CellColor(false);
                        //}
                    }
                    else if (Utility.CompanyInfo == "TML")
                    {
                        if (_oSalesInvoiceProductSerial.CheckProductSerial())
                        {
                            MessageBox.Show("The IMEI already Used", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            RowIndex = oItemRow.Index;
                            CellColor(true);
                            return false;
                        }
                        else
                        {
                            RowIndex = oItemRow.Index;
                            CellColor(false);
                        }
                        SalesInvoice oSI = new SalesInvoice();
                        oSI.GetWarehouseIDByInvoiceID(nInvoiceID);

                        if (oSI.WarehouseID == Convert.ToInt32(ConfigurationManager.AppSettings["CentralTMLWarehouse"].ToString()))
                        {

                            if (_oSalesInvoiceProductSerial.CheckIMEIfromGRD())
                            {
                                MessageBox.Show("Invalid IMEI", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                RowIndex = oItemRow.Index;
                                CellColor(true);
                                return false;
                            }
                            else
                            {
                                RowIndex = oItemRow.Index;
                                CellColor(false);
                            }
                        }
                        else
                        {

                            if (_oSalesInvoiceProductSerial.CheckIMEI())
                            {
                                MessageBox.Show("Invalid IMEI", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                RowIndex = oItemRow.Index;
                                CellColor(true);
                                return false;
                            }
                            else
                            {
                                RowIndex = oItemRow.Index;
                                CellColor(false);
                            }
                        }
                        
                    }

                }

            }
            else
            {
                MessageBox.Show("There is no product", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
        private int checkDuplicateLineItem(string ItemCode)
        {
            int ItemCounter = 0;
            foreach (DataGridViewRow oItemRow in dgvProductSerial.Rows)
            {
                if (oItemRow.Index < dgvProductSerial.Rows.Count - 1)
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
        private void CellColor(bool IsTrue)
        {
            foreach (DataGridViewRow oItemRow in dgvProductSerial.Rows)
            {
                if (IsTrue == true)
                {
                    DataGridViewCellStyle cs = dgvProductSerial.Rows[RowIndex].Cells[5].Style;
                    cs.ForeColor = Color.Red;
                    cs.Font = new Font("Arial", 10, FontStyle.Bold);
                    DataGridViewCellStyle cs1 = dgvProductSerial.Rows[RowIndex].Cells[4].Style;
                    cs1.ForeColor = Color.Red;
                    cs1.Font = new Font("Arial", 10, FontStyle.Bold);
                    DataGridViewCellStyle cs2 = dgvProductSerial.Rows[RowIndex].Cells[3].Style;
                    cs2.ForeColor = Color.Red;
                    cs2.Font = new Font("Arial", 10, FontStyle.Bold);
                    DataGridViewCellStyle cs3 = dgvProductSerial.Rows[RowIndex].Cells[2].Style;
                    cs3.ForeColor = Color.Red;
                    cs3.Font = new Font("Arial", 10, FontStyle.Bold);
                }
                else
                {
                    DataGridViewCellStyle cs = dgvProductSerial.Rows[RowIndex].Cells[5].Style;
                    cs.ForeColor = Color.Black;
                    cs.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                    DataGridViewCellStyle cs1 = dgvProductSerial.Rows[RowIndex].Cells[4].Style;
                    cs1.ForeColor = Color.Black;
                    cs1.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                    DataGridViewCellStyle cs2 = dgvProductSerial.Rows[RowIndex].Cells[3].Style;
                    cs2.ForeColor = Color.Black;
                    cs2.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                    DataGridViewCellStyle cs3 = dgvProductSerial.Rows[RowIndex].Cells[2].Style;
                    cs3.ForeColor = Color.Black;
                    cs3.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);
                }
            }
        
        }

        private void btnMove_Click(object sender, EventArgs e)
        {
            string value = txtBarcodeList.Text;
            char[] delimiter = new char[] { '\r', '\n' };
            string[] parts = value.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < parts.Length; i++)
            {
                sSplit = parts[i].ToString();

                _oSalesInvoiceProductSerial = new SalesInvoiceProductSerial();
                _oSalesInvoiceProductSerial.ProductSerialNo = sSplit.Trim();
                _oSalesInvoiceProductSerial.WarehouseID = _nWarehouseID;

                _oSalesInvoiceProductSerial.GetUnusedBarcodeHoNew();

                //if (Utility.CompanyInfo == "TEL")
                //{

                //}
                //else if (Utility.CompanyInfo == "TML")
                //{
                //    SalesInvoice oSI = new SalesInvoice();
                //    oSI.GetWarehouseIDByInvoiceID(nInvoiceID);

                //    if (oSI.WarehouseID == Convert.ToInt32(ConfigurationManager.AppSettings["CentralTMLWarehouse"].ToString()))
                //    {
                //        _oSalesInvoiceProductSerial.GetProductIDByIMEIFromGRDData();
                //    }
                //    else
                //    {
                //        _oSalesInvoiceProductSerial.GetProductIDByIMEI();
                //    }
                //}
                string xyz = "";

                if (dgvProductSerial.Rows.Count > 0)
                {
                    foreach (DataGridViewRow oItemRow in dgvProductSerial.Rows)
                    {
                        if (oItemRow.Cells[5].Value == null || oItemRow.Cells[5].Value.ToString().Trim() == "")
                        {
                            if ((oItemRow.Cells[2].Value.ToString().Trim() + xyz.Trim()) == _oSalesInvoiceProductSerial.ProductCode)
                            {
                                oItemRow.Cells[5].Value = sSplit.Trim();
                                xyz = sSplit.Trim();
                            }
                        }


                    }
                }

            }
            txtBarcodeList.Text = "";
        }
        
    }
}



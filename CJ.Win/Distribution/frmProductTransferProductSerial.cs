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
    public partial class frmProductTransferProductSerial : Form
    {

        //SalesInvoiceProductSerials _oSalesInvoiceProductSerials;
        //SalesInvoiceProductSerial _oSalesInvoiceProductSerial;
        ProductTransferProductSerial _oProductTransferProductSerial;
        ProductTransferProductSerials _oProductTransferProductSerials;
        string sSplit = "";
        int RowIndex = 0;
        int CustInfo = 0;
        int nTranID = 0;

        public frmProductTransferProductSerial()
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
        public void ShowDialog(ProductTransferProductSerial oProductTransferProductSerial)
        {
            this.Tag = oProductTransferProductSerial;

            lblInvoiceNo.Text = oProductTransferProductSerial.TranNo;
            lblCustomerCode.Text = oProductTransferProductSerial.FromWHName;
            lblCustomerName.Text = oProductTransferProductSerial.ToWHName;
            RefreshData(oProductTransferProductSerial.TranID);
            nTranID = 0;
            nTranID = oProductTransferProductSerial.TranID;
            this.ShowDialog();
        }
        public void RefreshData(int nTranID)
        {
            DBController.Instance.OpenNewConnection();


            _oProductTransferProductSerials = new ProductTransferProductSerials();

            _oProductTransferProductSerials.Refresh(nTranID);


            foreach (ProductTransferProductSerial oProductTransferProductSerial in _oProductTransferProductSerials)
            {

                for (int i = 0; i < oProductTransferProductSerial.Qty; i++)
                {

                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvProductSerial);

                    oRow.Cells[0].Value = oProductTransferProductSerial.TranID;
                    oRow.Cells[1].Value = oProductTransferProductSerial.ProductID;
                    oRow.Cells[2].Value = oProductTransferProductSerial.ProductCode;
                    oRow.Cells[3].Value = oProductTransferProductSerial.ProductName;
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
            foreach (DataGridViewRow oItemRow in dgvProductSerial.Rows)
            {
                if (oItemRow.Index < dgvProductSerial.Rows.Count)
                {

                    _oProductTransferProductSerial = new ProductTransferProductSerial();

                    _oProductTransferProductSerial.TranID = Convert.ToInt32(oItemRow.Cells[0].Value.ToString());
                    _oProductTransferProductSerial.ProductID = Convert.ToInt32(oItemRow.Cells[1].Value.ToString());
                    _oProductTransferProductSerial.SerialNo = Convert.ToInt32(oItemRow.Cells[4].Value.ToString());
                    _oProductTransferProductSerial.ProductSerialNo = oItemRow.Cells[5].Value.ToString().Trim();

                    DBController.Instance.BeginNewTransaction();

                    _oProductTransferProductSerial.InsertTML(_oProductTransferProductSerial.TranID);

                    DBController.Instance.CommitTran();

                }

            }

            MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //private void WarrantyCardPrintParam(long nInvoiceID)
        //{
        //    string sCommaSplit = "";
        //    int ChannelID = 0;
        //    string value = ConfigurationManager.AppSettings["WithSundryCustInfo"];
        //    char[] delimiter = new char[] { ',' };
        //    string[] parts = value.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
        //    for (int i = 0; i < parts.Length; i++)
        //    {
        //        sCommaSplit = parts[i].ToString();
        //        ChannelID = Convert.ToInt32(sCommaSplit.Trim());
        //        _oSalesInvoiceProductSerial.GetChannelByInvoiceID(nInvoiceID);
        //        if (ChannelID == _oSalesInvoiceProductSerial.ChannelID)
        //        {
        //            CustInfo = (int)Dictionary.WarratnyCardCustInfo.SundryCustomer;
        //        }
        //    }
        //    string value1 = ConfigurationManager.AppSettings["WithCustInfo"];
        //    char[] delimiter1 = new char[] { ',' };
        //    string[] parts1 = value1.Split(delimiter1, StringSplitOptions.RemoveEmptyEntries);
        //    for (int i = 0; i < parts1.Length; i++)
        //    {
        //        sCommaSplit = parts1[i].ToString();
        //        ChannelID = Convert.ToInt32(sCommaSplit.Trim());
        //        if (ChannelID == _oSalesInvoiceProductSerial.ChannelID)
        //        {
        //            CustInfo = (int)Dictionary.WarratnyCardCustInfo.PrimaryCustomer;
        //        }
        //    }

        //    string value2 = ConfigurationManager.AppSettings["BlankCustInfo"];
        //    char[] delimiter2 = new char[] { ',' };
        //    string[] parts2 = value2.Split(delimiter2, StringSplitOptions.RemoveEmptyEntries);
        //    for (int i = 0; i < parts2.Length; i++)
        //    {
        //        sCommaSplit = parts2[i].ToString();
        //        ChannelID = Convert.ToInt32(sCommaSplit.Trim());
        //        if (ChannelID == _oSalesInvoiceProductSerial.ChannelID)
        //        {
        //            CustInfo = (int)Dictionary.WarratnyCardCustInfo.NoCustomer;
        //        }
        //    }

        //}
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

                        MessageBox.Show("Please Enter Barcode/IMEI", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

                    if (rgBarcode.IsMatch(Barcode))
                    {
                        RowIndex = oItemRow.Index;
                        CellColor(false);
                    }
                    else
                    {
                        MessageBox.Show("Please Enter only numeric", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        RowIndex = oItemRow.Index;
                        CellColor(true);
                        return false;
                    }
                    //if (Utility.CompanyInfo == "TML")
                    //{
                    //    if (Barcode.Length != 15)
                    //    {
                    //        MessageBox.Show("IMEI Length must be Eight (15) digit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        RowIndex = oItemRow.Index;
                    //        CellColor(true);
                    //        return false;
                    //    }
                    //    else
                    //    {
                    //        RowIndex = oItemRow.Index;
                    //        CellColor(false);
                    //    }
                    //}
                    //else
                    //{
                    if (Barcode.Length < 8 && Barcode.Length > 15)
                        {
                            MessageBox.Show("Barcode Length must be >= 8 and <=15 digit", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            RowIndex = oItemRow.Index;
                            CellColor(true);
                            return false;
                        }
                        else
                        {
                            RowIndex = oItemRow.Index;
                            CellColor(false);
                        }
                    //}

                        _oProductTransferProductSerial = new ProductTransferProductSerial();
                        _oProductTransferProductSerial.ProductSerialNo = Barcode.Trim();
                        _oProductTransferProductSerial.ProductCode = ProductCode.Trim();
                        _oProductTransferProductSerial.ProductID = ProductID;

                    //if (Utility.CompanyInfo == "TEL")
                    //{
                    //    if (_oSalesInvoiceProductSerial.CheckProductSerial())
                    //    {
                    //        MessageBox.Show("The Barcode already Used", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        RowIndex = oItemRow.Index;
                    //        CellColor(true);
                    //        return false;
                    //    }
                    //    else
                    //    {
                    //        RowIndex = oItemRow.Index;
                    //        CellColor(false);
                    //    }
                    //    if (_oSalesInvoiceProductSerial.CheckGeneratedBarcode())
                    //    {
                    //        MessageBox.Show("Invalid Barcode", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //        RowIndex = oItemRow.Index;
                    //        CellColor(true);
                    //        return false;
                    //    }
                    //    else
                    //    {
                    //        RowIndex = oItemRow.Index;
                    //        CellColor(false);
                    //    }
                    //}

                        if (_oProductTransferProductSerial.CheckProductSerial())
                        {
                            MessageBox.Show("The Serial already Used", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            RowIndex = oItemRow.Index;
                            CellColor(true);
                            return false;
                        }
                        else
                        {
                            RowIndex = oItemRow.Index;
                            CellColor(false);
                        }
                        //SalesInvoice oSI = new SalesInvoice();
                        //oSI.GetWarehouseIDByInvoiceID(nInvoiceID);

                        //if (oSI.WarehouseID == Convert.ToInt32(ConfigurationManager.AppSettings["CentralTMLWarehouse"].ToString()))
                        //{

                        //    if (_oSalesInvoiceProductSerial.CheckIMEIfromGRD())
                        //    {
                        //        MessageBox.Show("Invalid IMEI", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //        RowIndex = oItemRow.Index;
                        //        CellColor(true);
                        //        return false;
                        //    }
                        //    else
                        //    {
                        //        RowIndex = oItemRow.Index;
                        //        CellColor(false);
                        //    }
                        //}
                        //else
                        //{

                        if (_oProductTransferProductSerial.CheckIMEI())
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
                        //}

                    

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


                _oProductTransferProductSerial = new ProductTransferProductSerial();
                _oProductTransferProductSerial.ProductSerialNo = sSplit.Trim();

                _oProductTransferProductSerial.GetProductIDByIMEI();

                string xyz = "";

                if (dgvProductSerial.Rows.Count > 0)
                {
                    foreach (DataGridViewRow oItemRow in dgvProductSerial.Rows)
                    {
                        if (oItemRow.Cells[5].Value == null || oItemRow.Cells[5].Value.ToString().Trim() == "")
                        {
                            if ((oItemRow.Cells[2].Value.ToString().Trim() + xyz.Trim()) == _oProductTransferProductSerial.ProductCode)
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



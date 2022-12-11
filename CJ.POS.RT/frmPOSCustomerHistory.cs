using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;

using CJ.Class.Library;
using CJ.Class.DataTransfer;

namespace CJ.POS.RT
{
    public partial class frmPOSCustomerHistory : Form
    {
        public string _sConsumerName = "";
        public string _sConsumerCode = "";
        public string _sMobileNo = "";
        public string _sTelephoneNo = "";
        public string _sEmail = "";
        public string _sAddress = "";
        public bool _IsSet = false;
        public int _IsValidEmail = 0;
        CJ.Class.POS.DSPosCustomerHostory _oDSPosCustomerHostoryAll = new CJ.Class.POS.DSPosCustomerHostory();

        public frmPOSCustomerHistory(string sMobileNo)
        {
            InitializeComponent();
            txtMobileNo.Text = sMobileNo.ToString();
            if (sMobileNo != "")
            {
                GetCustomerData();
            }
        }

        private void GetCustomerData()
        {
            this.Cursor = Cursors.WaitCursor;
            DataTransfer oDataTransfer = new DataTransfer();
            DSPosCustomerHostory oDSPosCustomerHostory = new DSPosCustomerHostory();
            CJ.Class.POS.DSPosCustomerHostory _oDSPosCustomerHostory = new CJ.Class.POS.DSPosCustomerHostory();
            oDSPosCustomerHostory = oDataTransfer.GetPosCustomerHistory(oDSPosCustomerHostory, txtMobileNo.Text.Trim());
            _oDSPosCustomerHostory.Merge(oDSPosCustomerHostory);
            _oDSPosCustomerHostory.AcceptChanges();

            _oDSPosCustomerHostoryAll = new Class.POS.DSPosCustomerHostory();
            _oDSPosCustomerHostoryAll.Merge(_oDSPosCustomerHostory);
            _oDSPosCustomerHostoryAll.AcceptChanges();
            GetCustomerHisory(_oDSPosCustomerHostory);
            this.Cursor = Cursors.Default;



        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtMobileNo.Text != "")
            {
                GetCustomerData();
            }
            else
            {
                MessageBox.Show("Please Enter Mobile#", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        public void LoadDataByDataSet(CJ.Class.POS.DSPosCustomerHostory oDSCusomerTran)
        {
            int nTotalQty = 0;
            double nTotalAmount = 0;

            dgvLineItem.Rows.Clear();
            foreach (CJ.Class.POS.DSPosCustomerHostory.ConsumerTranRow oConsumerTranRow in oDSCusomerTran.ConsumerTran)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLineItem);
                oRow.Cells[0].Value = oConsumerTranRow.TranType.ToString();
                oRow.Cells[1].Value = oConsumerTranRow.WHCode.ToString();
                oRow.Cells[2].Value = oConsumerTranRow.TranNo.ToString();
                oRow.Cells[3].Value = oConsumerTranRow.TranDate.ToString("dd-MMM-yyyy");
                oRow.Cells[4].Value = "[" + oConsumerTranRow.ProductCode.ToString() + "]" + " " +
                                      oConsumerTranRow.ProductName.ToString();
                oRow.Cells[5].Value = oConsumerTranRow.Qty.ToString();
                oRow.Cells[6].Value = oConsumerTranRow.Amount.ToString();
                oRow.Cells[7].Value = oConsumerTranRow.ConsumerName.ToString();
                oRow.Cells[8].Value = oConsumerTranRow.Address.ToString();
                oRow.Cells[9].Value = oConsumerTranRow.MobileNo.ToString();
                oRow.Cells[10].Value = oConsumerTranRow.PhoneNo.ToString();
                oRow.Cells[11].Value = oConsumerTranRow.Email.ToString();
                nTotalQty = nTotalQty + oConsumerTranRow.Qty;
                nTotalAmount = nTotalAmount + oConsumerTranRow.Amount;
                dgvLineItem.Rows.Add(oRow);

            }
            this.Text = "Customer History [" + dgvLineItem.Rows.Count + "]";
            TELLib oTELLib = new TELLib();
            lblGrandTotal.Text = "Total Quantity: " + nTotalQty.ToString() + "      Total Amount: " + oTELLib.TakaFormat(nTotalAmount) + "";
        }
        public void GetCustomerHisory(CJ.Class.POS.DSPosCustomerHostory oDSPosCustomerHostory)
        {
            /// Insert Office Item Tran
            CJ.Class.POS.DSPosCustomerHostory oDSCusomerTran;

            try
            {
                dgvLineItem.Rows.Clear();
                int nTotalQty = 0;
                double nTotalAmount = 0;
                foreach (CJ.Class.POS.DSPosCustomerHostory.ConsumerInfoRow oConsumerInfoRow in oDSPosCustomerHostory.ConsumerInfo)
                {
                    OfficeItemTran oOfficeItemTran = new OfficeItemTran();

                    txtConsumerCode.Text = oConsumerInfoRow.ConsumerCode;
                    txtConsumerName.Text = oConsumerInfoRow.ConsumerName;
                    txtAddress.Text = oConsumerInfoRow.Address;
                    txtEmail.Text = oConsumerInfoRow.Email;
                    txtTelephoneNo.Text = oConsumerInfoRow.PhoneNo;
                    txtConsumerName.Text = oConsumerInfoRow.ConsumerName;
                    _IsValidEmail = oConsumerInfoRow.IsVerifiedEmail;
                    DataRow[] oDR =
                        oDSPosCustomerHostory.ConsumerTran.Select("ConsumerID= " + oConsumerInfoRow.ConsumerID + "");
                    oDSCusomerTran = new CJ.Class.POS.DSPosCustomerHostory();
                    oDSCusomerTran.Merge(oDR);
                    oDSCusomerTran.ConsumerTran.AcceptChanges();

                    foreach (
                        CJ.Class.POS.DSPosCustomerHostory.ConsumerTranRow oConsumerTranRow in
                            oDSCusomerTran.ConsumerTran)
                    {
                        DataGridViewRow oRow = new DataGridViewRow();
                        oRow.CreateCells(dgvLineItem);


                        oRow.Cells[0].Value = oConsumerTranRow.TranType.ToString();
                        oRow.Cells[1].Value = oConsumerTranRow.WHCode.ToString();
                        oRow.Cells[2].Value = oConsumerTranRow.TranNo.ToString();
                        oRow.Cells[3].Value = oConsumerTranRow.TranDate.ToString("dd-MMM-yyyy");
                        oRow.Cells[4].Value = "[" + oConsumerTranRow.ProductCode.ToString() + "]" + " " +
                                              oConsumerTranRow.ProductName.ToString();
                        oRow.Cells[5].Value = oConsumerTranRow.Qty.ToString();
                        oRow.Cells[6].Value = oConsumerTranRow.Amount.ToString();
                        oRow.Cells[7].Value = oConsumerTranRow.ConsumerName.ToString();
                        oRow.Cells[8].Value = oConsumerTranRow.Address.ToString();
                        oRow.Cells[9].Value = oConsumerTranRow.MobileNo.ToString();
                        oRow.Cells[10].Value = oConsumerTranRow.PhoneNo.ToString();
                        oRow.Cells[11].Value = oConsumerTranRow.Email.ToString();
                        nTotalQty = nTotalQty + oConsumerTranRow.Qty;
                        nTotalAmount = nTotalAmount + oConsumerTranRow.Amount;
                        dgvLineItem.Rows.Add(oRow);

                    }

                }
                this.Text = "Customer History [" + dgvLineItem.Rows.Count + "]";
                TELLib oTELLib = new TELLib();
                lblGrandTotal.Text = "Total Quantity: " + nTotalQty.ToString() + "      Total Amount: " + oTELLib.TakaFormat(nTotalAmount) + "";
                if (dgvLineItem.Rows.Count == 0)
                {
                    txtConsumerCode.Text = "";
                    txtConsumerName.Text = "";
                    txtAddress.Text = "";
                    txtEmail.Text = "";
                    txtTelephoneNo.Text = "";
                    _IsValidEmail = 0;
                    MessageBox.Show("There is no data", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _sMobileNo = txtMobileNo.Text;
            _sConsumerCode = txtConsumerCode.Text;
            _sConsumerName = txtConsumerName.Text;
            _sAddress = txtAddress.Text;
            _sEmail = txtEmail.Text;
            _sTelephoneNo = txtTelephoneNo.Text;
            _IsSet = true;
            this.Close();
        }

        public void LoadDatafromDataSet()
        {
            this.Cursor = Cursors.WaitCursor;

            CJ.Class.POS.DSPosCustomerHostory _oDSPosCustomerHostoryTranType = new Class.POS.DSPosCustomerHostory();
            CJ.Class.POS.DSPosCustomerHostory _oDSPosCustomerHostoryTranCompany = new Class.POS.DSPosCustomerHostory();

            string sTranType = "";
            if (rdoTypeAll.Checked == true)
            {
                sTranType = "";
            }
            else if (rdoSales.Checked == true)
            {
                sTranType = "Sales";
            }
            else if (rdoService.Checked == true)
            {
                sTranType = "Service";
            }

            string sCompany = "";
            if (rdoCompanyAll.Checked == true)
            {
                sCompany = "";
            }
            else if (rdoElectronics.Checked == true)
            {
                sCompany = "TEL";
            }
            else if (rdoMobile.Checked == true)
            {
                sCompany = "TML";
            }

            if (rdoTypeAll.Checked == true)
            {
                _oDSPosCustomerHostoryTranType.Merge(_oDSPosCustomerHostoryAll);
                _oDSPosCustomerHostoryTranType.AcceptChanges();
            }
            else
            {
                DataRow[] oDRTD = _oDSPosCustomerHostoryAll.ConsumerTran.Select(" TranType= '" + sTranType + "'");
                _oDSPosCustomerHostoryTranType.Merge(oDRTD);
                _oDSPosCustomerHostoryTranType.AcceptChanges();

            }

            if (rdoCompanyAll.Checked == true)
            {
                _oDSPosCustomerHostoryTranCompany.Merge(_oDSPosCustomerHostoryTranType);
                _oDSPosCustomerHostoryTranCompany.AcceptChanges();
            }
            else
            {
                DataRow[] oDRTDCompany = _oDSPosCustomerHostoryTranType.ConsumerTran.Select(" Company= '" + sCompany + "'");
                _oDSPosCustomerHostoryTranCompany.Merge(oDRTDCompany);
                _oDSPosCustomerHostoryTranCompany.AcceptChanges();

            }
            LoadDataByDataSet(_oDSPosCustomerHostoryTranCompany);
            this.Cursor = Cursors.Default;
        }

        private void rdoTypeAll_CheckedChanged(object sender, EventArgs e)
        {
            LoadDatafromDataSet();
        }

        private void rdoSales_CheckedChanged(object sender, EventArgs e)
        {
            LoadDatafromDataSet();
        }

        private void rdoService_CheckedChanged(object sender, EventArgs e)
        {
            LoadDatafromDataSet();
        }

        private void rdoCompanyAll_CheckedChanged(object sender, EventArgs e)
        {
            LoadDatafromDataSet();
        }

        private void rdoElectronics_CheckedChanged(object sender, EventArgs e)
        {
            LoadDatafromDataSet();
        }

        private void rdoMobile_CheckedChanged(object sender, EventArgs e)
        {
            LoadDatafromDataSet();
        }

        private void frmPOSCustomerHistory_Load(object sender, EventArgs e)
        {

        }
    }
}

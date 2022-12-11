using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;

namespace CJ.Win.CSD
{
    public partial class frmGetInvoiceInfo : Form
    {
        CSDJobs _oCSDJobs;
        public string sProductCode;
        public string sProductSL;
        public string sInvoiceNo;
        public DateTime dInvoiceDate;
        public int nSalesPoint;
        public string sSalesPointCode;
        public string sCustomerName;
        public string sContactNo;
        public string sTelephone;
        public string sAddress;
        public string sEmail;
        public string sNationalID;
        public bool bIsExecuite = false;
        public bool bIsCassiopeia = false;

        private string _sInvoiceNo = "";

        public CSDJob _oCSDJob;
        public frmGetInvoiceInfo(string sInvoiceNo)
        {
            InitializeComponent();
            _sInvoiceNo = sInvoiceNo;
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            DataLoad();
            this.Cursor = Cursors.Default;
        }
        private void DataLoad()
        {
            
            lvwInvoiceSearch.Items.Clear();
            DBController.Instance.OpenNewConnection();
            {
                _oCSDJobs = new CSDJobs();
                if (!_oCSDJobs.GetInvoice(txtInvoiceNo.Text.Trim(), txtProductSL.Text.Trim(), txtMobileNo.Text.Trim(), txtTelephone.Text.Trim(), txtCustomerName.Text.Trim()))
                {
                    _oCSDJobs = new CSDJobs();
                    _oCSDJobs.GetCassiopeiaInvoice(txtInvoiceNo.Text.Trim(), txtProductSL.Text.Trim(), txtMobileNo.Text.Trim(), txtTelephone.Text.Trim(), txtCustomerName.Text.Trim());
                }
            }
            this.Text = "Total " + "[" + _oCSDJobs.Count + "]";
            foreach (CSDJob oCSDJob in _oCSDJobs)
            {
                ListViewItem oItem = lvwInvoiceSearch.Items.Add(oCSDJob.InvoiceNo);
                oItem.SubItems.Add(oCSDJob.CustomerName);
                oItem.SubItems.Add(oCSDJob.MobileNo);
                oItem.SubItems.Add(oCSDJob.ProductName);
                oItem.SubItems.Add(oCSDJob.ProductSerialNo);
                oItem.SubItems.Add(oCSDJob.TelePhone);
                oItem.SubItems.Add(oCSDJob.CustomerAddress);

                oItem.Tag = oCSDJob;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvwInvoiceSearch_DoubleClick(object sender, EventArgs e)
        {
            returnSelectedProduct();
            this.Close();
        }
        private void returnSelectedProduct()
        {
            foreach (ListViewItem oItem in lvwInvoiceSearch.SelectedItems)
            {
                _oCSDJob = (CSDJob)lvwInvoiceSearch.SelectedItems[0].Tag;
                sProductCode = _oCSDJob.ProductCode;
                sProductSL = _oCSDJob.ProductSerialNo;
                sInvoiceNo = _oCSDJob.InvoiceNo;
                dInvoiceDate = Convert.ToDateTime(_oCSDJob.InvoiceDate);
                sSalesPointCode = _oCSDJob.CustomerCode;
                nSalesPoint = _oCSDJob.SalesPointID;
                sCustomerName = _oCSDJob.CustomerName;
                sAddress = _oCSDJob.CustomerAddress;
                sContactNo = _oCSDJob.MobileNo;
                sTelephone = _oCSDJob.TelePhone;
                sEmail = _oCSDJob.Email;
                sNationalID = _oCSDJob.NationalID;

                bIsExecuite = true;
                
            }

        }

        private void lvwInvoiceSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                returnSelectedProduct();
                this.Close();
            }
        }

        private void lvwInvoiceSearch_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lvwInvoiceSearch.Sorting == SortOrder.Ascending)
            {
                lvwInvoiceSearch.Sorting = SortOrder.Descending;
            }
            else
            {
                lvwInvoiceSearch.Sorting = SortOrder.Ascending;
            }
            lvwInvoiceSearch.Sort();
        }

        private void frmGetInvoiceInfo_Load(object sender, EventArgs e)
        {
            txtInvoiceNo.Text = _sInvoiceNo;
        }
    }
}
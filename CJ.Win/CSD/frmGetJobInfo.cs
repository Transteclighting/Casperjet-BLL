using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class.CSD;
using CJ.Class;

namespace CJ.Win.CSD
{
    public partial class frmGetJobInfo : Form
    {
        CSDJobs _oCSDJobs;
        //public string sJobNo;
        //Hello World...
        public bool bIsCheckCJCSD = false;
        public string _sJobNo;
        public CSDJob _oCSDJob;
        public frmGetJobInfo(string sJobNo)
        {
            InitializeComponent();
            _sJobNo = sJobNo;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool validateUIInput()
        {
            bool _Flag = false;

            if (txtProductSL.Text.Trim() != "")
                {
                    _Flag = true;
                    return true;
                }
            else if (txtMobileNo.Text.Trim() != "")
            {
                _Flag = true;
                return true;
            }
            else if (txtCustomerName.Text.Trim() != "")
            {
                _Flag = true;
                return true;
            }
            else if (txtInvoiceNo.Text.Trim() != "")
            {
                _Flag = true;
                //break;
                return true;
            }
            else if (txtTelephone.Text.Trim() != "")
            {
                _Flag = true;
                return true;
            }
            else if (txtJobNo.Text.Trim() != "")
            {
                _Flag = true;
                return true;
            }
            else if (txtAddress.Text.Trim() != "")
            {
                _Flag = true;
                return true;
            }
            else if (txtGSPNJob.Text.Trim() != "")
            {
                _Flag = true;
                return true;
            }
            else if  (_Flag == false)
            {
                MessageBox.Show("Please Search by at least one field", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
           
            return true;
        }
        private void btnGetData_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (validateUIInput())
            {
                DataLoad();
            }
            this.Cursor = Cursors.Default;
        }
        private void DataLoad()
        {
            _oCSDJobs = new CSDJobs();
            lvwJobSearch.Items.Clear();
            DBController.Instance.OpenNewConnection();
            {

                if (!_oCSDJobs.GetJobs(txtProductSL.Text.Trim(), txtMobileNo.Text.Trim(), txtCustomerName.Text.Trim(), txtInvoiceNo.Text.Trim(), txtTelephone.Text.Trim(), txtJobNo.Text.Trim(), txtAddress.Text.Trim(),txtGSPNJob.Text.Trim()))
                {
                    if (txtInvoiceNo.Text == "" && txtGSPNJob.Text == "")
                    {
                        _oCSDJobs.GetCassandraJobs(txtProductSL.Text.Trim(), txtMobileNo.Text.Trim(), txtCustomerName.Text.Trim(), txtInvoiceNo.Text.Trim(), txtTelephone.Text.Trim(), txtJobNo.Text.Trim(), txtAddress.Text.Trim());
                    }
                    
                }

            }
            this.Text = "Total " + "[" + _oCSDJobs.Count + "]";
            foreach (CSDJob oCSDJob in _oCSDJobs)
            {
                ListViewItem oItem = lvwJobSearch.Items.Add(oCSDJob.JobNo.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.JobStatus),oCSDJob.Status));
                oItem.SubItems.Add(oCSDJob.CreateDate.ToShortDateString());
                oItem.SubItems.Add(oCSDJob.CustomerName);                
                oItem.SubItems.Add(oCSDJob.MobileNo);
                oItem.SubItems.Add(oCSDJob.ProductName);
                oItem.SubItems.Add(oCSDJob.ProductSerialNo);
                oItem.SubItems.Add(oCSDJob.InvoiceNo);
                oItem.SubItems.Add(oCSDJob.TelePhone);
                oItem.SubItems.Add(oCSDJob.CustomerAddress);
                //if (oCSDJob.GSPNJobNo != null)
                //{
                //    oItem.SubItems.Add(oCSDJob.GSPNJobNo);
                //}
                //else
                //{
                //    oItem.SubItems.Add(" ");
                //}
                oItem.SubItems.Add(oCSDJob.GSPNJobNo);
                oItem.Tag = oCSDJob;
            }
        }
        private void frmGetJobInfo_Load(object sender, EventArgs e)
        {
            txtJobNo.Text = _sJobNo;
        }

        private void lvwJobSearch_DoubleClick(object sender, EventArgs e)
        {
            returnSelectedProduct();
            this.Close();
        }
        private void returnSelectedProduct()
        {
            foreach (ListViewItem oItem in lvwJobSearch.SelectedItems)
            {
                _oCSDJob = (CSDJob)lvwJobSearch.SelectedItems[0].Tag;
                _sJobNo = _oCSDJob.JobNo;
            }

        }

        private void lvwJobSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                returnSelectedProduct();
                this.Close();
            }
        }

        private void lvwJobSearch_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (lvwJobSearch.Sorting == SortOrder.Ascending)
            {
                lvwJobSearch.Sorting = SortOrder.Descending;
            }
            else
            {
                lvwJobSearch.Sorting = SortOrder.Ascending;
            }
            lvwJobSearch.Sort();
        }

        private void rdoCJCSD_CheckedChanged(object sender, EventArgs e)
        {
            lblInvoiceNo.Enabled = true;
            txtInvoiceNo.Enabled = true;
        }

        private void rdoCassandra_CheckedChanged(object sender, EventArgs e)
        {
            lblInvoiceNo.Enabled = false;
            txtInvoiceNo.Text = "";
            txtInvoiceNo.Enabled = false;
        }

    }
}
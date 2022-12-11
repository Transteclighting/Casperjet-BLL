using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

using CJ.Class;
using CJ.Class.Distribution;

namespace CJ.Win.Distribution
{  
    public partial class frmCACInvoiceWiseCapacity : Form
    {
        DateTime _dtDate;
        long nInvoiceID = 0;
        CACInvoiceWiseCapacity oCACInvoiceWiseCapacity;
        public bool IsTrue = false;
        public frmCACInvoiceWiseCapacity()
        {
            InitializeComponent();
        }
        public void ShowDialog(CACInvoiceWiseCapacity oCACInvoiceWiseCapacity)
        {
            DBController.Instance.OpenNewConnection();
            this.Tag = oCACInvoiceWiseCapacity;
            nInvoiceID = oCACInvoiceWiseCapacity.InvoiceID;
            txtInvNo.Text = oCACInvoiceWiseCapacity.InvoiceNo;
            dtInvDate.Value = oCACInvoiceWiseCapacity.InvoiceDate;
            txtIndoorCapacity.Text = oCACInvoiceWiseCapacity.IndoorCapacity.ToString();
            txtOutdoorCapacity.Text = oCACInvoiceWiseCapacity.OutdoorCapacity.ToString();
            txtRemarks.Text = oCACInvoiceWiseCapacity.Remarks;
            txtCustomer.Text = oCACInvoiceWiseCapacity.CustomerName;
            txtAmount.Text = oCACInvoiceWiseCapacity.InvoiceAmount.ToString();
            this.ShowDialog();
        }
        private void btnGo_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            if (txtInvNo.Text == "")
            {
                MessageBox.Show("Please Enter Valid Invoice#", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInvNo.Focus();
            }
            else
            {
                SalesInvoice oSalesInvoice = new SalesInvoice();
                oSalesInvoice.GetByCACInvoiceNo(txtInvNo.Text);
                if (oSalesInvoice.CheckInvoiceNo(txtInvNo.Text) == false)
                {                   
                        _dtDate = Convert.ToDateTime(oSalesInvoice.InvoiceDate);
                        dtInvDate.Value = _dtDate;
                        nInvoiceID = oSalesInvoice.InvoiceID;
                    txtCustomer.Text = oSalesInvoice.CustomerName;
                    txtAmount.Text = oSalesInvoice.InvoiceAmount.ToString();                            
                }
                else
                {
                    MessageBox.Show("Please Input Valid Invoice#");
                }

            }

            this.Cursor = Cursors.Default;
        }

        private void frmCACInvoiceWiseCapacity_Load(object sender, EventArgs e)
        {

        }
        private bool validateUIInput()
        {
            if (txtInvNo.Text== string.Empty)
            {
                MessageBox.Show("Please Select Invoice", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtInvNo.Focus();
                return false;
            }           
            else if (txtIndoorCapacity.Text == string.Empty)
            {
                MessageBox.Show("Please input Capacity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIndoorCapacity.Focus();
                return false;
            }
            else if (txtOutdoorCapacity.Text == string.Empty)
            {
                MessageBox.Show("Please input Outdoor Capacity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOutdoorCapacity.Focus();
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                this.Close();
            }
        }
        private void Save()
        {
            if (this.Tag == null)
            {
                CACInvoiceWiseCapacity oCACInvoiceWiseCapacity = new CACInvoiceWiseCapacity();
                oCACInvoiceWiseCapacity.InvoiceID=Convert.ToInt32(nInvoiceID);
                oCACInvoiceWiseCapacity.InvoiceDate = dtInvDate.Value;
                oCACInvoiceWiseCapacity.IndoorCapacity=Convert.ToDouble(txtIndoorCapacity.Text);
                oCACInvoiceWiseCapacity.OutdoorCapacity = Convert.ToDouble(txtOutdoorCapacity.Text);
                oCACInvoiceWiseCapacity.CreateUser = Utility.UserId;
                oCACInvoiceWiseCapacity.CreateDate = DateTime.Now;
                oCACInvoiceWiseCapacity.Remarks = txtRemarks.Text;                
                try
                {
                    DBController.Instance.OpenNewConnection();
                    DBController.Instance.BeginNewTransaction();
                    oCACInvoiceWiseCapacity.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
            else
            {
                CACInvoiceWiseCapacity oCACInvoiceWiseCapacity = (CACInvoiceWiseCapacity)this.Tag;
                oCACInvoiceWiseCapacity.InvoiceID = Convert.ToInt32(nInvoiceID);
                oCACInvoiceWiseCapacity.InvoiceDate = dtInvDate.Value;
                oCACInvoiceWiseCapacity.IndoorCapacity = Convert.ToDouble(txtIndoorCapacity.Text);
                oCACInvoiceWiseCapacity.OutdoorCapacity = Convert.ToDouble(txtOutdoorCapacity.Text);
                oCACInvoiceWiseCapacity.CreateUser = Utility.UserId;
                oCACInvoiceWiseCapacity.CreateDate = DateTime.Now;
                oCACInvoiceWiseCapacity.Remarks = txtRemarks.Text;                
                try
                {
                    DBController.Instance.OpenNewConnection();
                    DBController.Instance.BeginNewTransaction();
                    oCACInvoiceWiseCapacity.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Edit", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

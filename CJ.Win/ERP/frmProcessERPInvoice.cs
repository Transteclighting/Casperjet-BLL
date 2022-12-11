using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.ERP;

namespace CJ.Win.ERP
{
    public partial class frmProcessERPInvoice : Form
    {
        ERPInvoiceProcess oERPInvoiceProcess;

        ProductCustomerList _oCustomers;
        ProductCustomerList _oProducts;
        ProductCustomerList _oWarehouses;
        public frmProcessERPInvoice()
        {
            InitializeComponent();
        }

        private void frmProcessERPInvoice_Load(object sender, EventArgs e)
        {

        }
        private bool ValidateUI()
        {
            DBController.Instance.OpenNewConnection();
            _oCustomers = new ProductCustomerList();
            _oProducts = new ProductCustomerList();
            _oWarehouses = new ProductCustomerList();
            DBController.Instance.OpenNewConnection();
            _oCustomers.GetCustomer(dtDate.Value.Date);
            _oProducts.GetProduct(dtDate.Value.Date);
            _oWarehouses.GetWarehouse(dtDate.Value.Date);
            if (_oCustomers.Count>0 || _oProducts.Count>0 || _oWarehouses.Count > 0)
            {
                frmUnMappedList oForm = new frmUnMappedList();
                oForm.ShowDialog(_oCustomers, _oProducts, _oWarehouses);
                return false;
            }
            
            return true;
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            if (ValidateUI())
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    DBController.Instance.BeginNewTransaction();


                    oERPInvoiceProcess = new ERPInvoiceProcess();
                    oERPInvoiceProcess.Date = dtDate.Value.Date;
                    oERPInvoiceProcess.Execute();

                    if (oERPInvoiceProcess.ERPInvoiceValidation(dtDate.Value.Date))
                    {
                        DBController.Instance.CommitTransaction();
                    }
                    else
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show("There is a mismatch on invoice item. Please process again", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                    }
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Sucecssful Save.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    Cursor.Current = Cursors.Default;
                    MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
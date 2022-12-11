using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Library;

namespace CJ.Win.SupplyChain
{
    public partial class frmSalesTrand : Form
    {
        int _nProductID = 0;
        public frmSalesTrand(int nProductID)
        {
            InitializeComponent();
            _nProductID = nProductID;
            GetData(nProductID);

        }


        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            //if (chkAll.Checked == true)
            //{

            //    dtFromDate.Enabled = true;
            //    dtToDate.Enabled = true;
            //}
            //else
            //{
            //    dtFromDate.Enabled = false;
            //    dtToDate.Enabled = false;
            //}
        
        }
        private void GetData(int nProductID)
        {
            
            TELLib oTELLib = new TELLib();
            
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            SalesInvoices oSalesData = new SalesInvoices();
            oSalesData.GetSalesDataForSCM(dtSalesYear.Value.Year, nProductID);
            dgvSalesTrand.Rows.Clear();
            foreach (SalesInvoice oSalesInvoice in oSalesData)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvSalesTrand);
                oRow.Cells[0].Value = oSalesInvoice.MonthName.ToString();
                oRow.Cells[1].Value = oSalesInvoice.RetailSalesQty.ToString();
                oRow.Cells[2].Value = oSalesInvoice.B2BSalesQty.ToString();
                oRow.Cells[3].Value = oSalesInvoice.DealerSalesQty.ToString();
                oRow.Cells[4].Value = (oSalesInvoice.RetailSalesQty + oSalesInvoice.B2BSalesQty + oSalesInvoice.DealerSalesQty);

                dgvSalesTrand.Rows.Add(oRow);
            }
        }

        private void btnGetdata_Click(object sender, EventArgs e)
        {
            GetData(_nProductID);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.Basic
{
    public partial class frmVATNoReset : Form
    {
        public frmVATNoReset()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult oResult = MessageBox.Show("Are you sure you want to reset vat challan no. ? ", "Confirm Ticket Reject", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    Warehouses oWarehouses = new Warehouses();
                    oWarehouses.GetWarehouseForVat();
                    DBController.Instance.BeginNewTransaction();
                    foreach (Warehouse oWarehouse in oWarehouses)
                    {
                        Warehouse oVat = new Warehouse();
                        oVat.WarehouseID = oWarehouse.WarehouseID;
                        oVat.ResetVatChallan();

                    }
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You have successfully reset vat challan no", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
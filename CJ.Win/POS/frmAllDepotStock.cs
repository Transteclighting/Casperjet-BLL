using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CJ.Class.POS;
using CJ.Class;

namespace CJ.Win.POS
{
    public partial class frmAllDepotStock : Form
    {
        int _nProductID = 0;

        ProductStocks _oProductStocks;
        public frmAllDepotStock(int nProductID, string sProductCode, string sProductName)
        {
            InitializeComponent();
            _nProductID = nProductID;
            lblProductCode.Text = sProductCode;
            lblProductName.Text = sProductName;
        }

        private void frmAllDepotStock_Load(object sender, EventArgs e)
        {
            _oProductStocks = new ProductStocks();
            _oProductStocks.GetDepotWiseStock(_nProductID);

            foreach (ProductStock oProductStock in _oProductStocks)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvDepotStock);
                oRow.Cells[0].Value = oProductStock.ShortCode;
                oRow.Cells[1].Value = oProductStock.BrandDesc;
                oRow.Cells[2].Value = oProductStock.OutletCurrentStock;

                dgvDepotStock.Rows.Add(oRow);
            }

        }
    }
}

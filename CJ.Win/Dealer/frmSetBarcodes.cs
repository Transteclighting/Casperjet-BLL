using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CJ.Win.Dealer
{
    public partial class frmSetBarcodes : Form
    {
        public string _sBarcode = "";
        public int _Qty = 0;
        public frmSetBarcodes()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvBarcodes.Rows.Count-1; i++)
            {
                if (_sBarcode == "")
                {
                    _sBarcode = dgvBarcodes.Rows[i].Cells[0].Value.ToString();
                }
                else
                {
                    _sBarcode = _sBarcode + "," + dgvBarcodes.Rows[i].Cells[0].Value.ToString();
                }
            }

            _Qty = dgvBarcodes.Rows.Count - 1;

            this.Close();
        }
    }
}

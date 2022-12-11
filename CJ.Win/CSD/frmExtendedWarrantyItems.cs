using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CJ.Win.CSD
{
    public partial class frmExtendedWarrantyItems : Form
    {
        public frmExtendedWarrantyItems()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmExtendedWarrantyItem ofrmExtendedWarrantyItem = new frmExtendedWarrantyItem();
            ofrmExtendedWarrantyItem.ShowDialog();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {

        }
    }
}

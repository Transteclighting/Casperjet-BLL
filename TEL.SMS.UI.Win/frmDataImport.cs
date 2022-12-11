using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TEL.SMS.BO.DA;

namespace TEL.SMS.UI.Win
{
    public partial class frmDataImport : Form
    {
        public frmDataImport()
        {
            InitializeComponent();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            DAProduct oDAProduct = new DAProduct();
            this.Cursor=Cursors.WaitCursor;
            //oDAProduct.ImportProductInfo(pbrDataImport,lblStatus);
            this.Cursor = Cursors.Default;
            this.Close();
            MessageBox.Show("Data Import is completed");


        

        }
    }
}
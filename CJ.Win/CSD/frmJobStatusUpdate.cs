using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CJ.Win.CSD
{
    public partial class frmJobStatusUpdate : Form
    {
        public object _Date;

        public frmJobStatusUpdate()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _Date = Convert.ToDateTime(dtDeliveryDate.Value.Date);
            this.Close();
        }

        private void frmJobStatusUpdate_Load(object sender, EventArgs e)
        {
            _Date = null;
        }
    }
}
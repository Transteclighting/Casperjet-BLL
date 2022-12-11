using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.HR.Recruitment
{
    public partial class frmHRCompany : Form
    {
        public frmHRCompany()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void frmHRCompany_Load(object sender, EventArgs e)
        {
            this.Text = "ADD New Company";
        }
    }
}
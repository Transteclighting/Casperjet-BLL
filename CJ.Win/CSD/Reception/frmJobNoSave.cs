using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;
using CJ.Report;
using CJ.Report.CSD;
using CJ.Class.Library;
using CJ.Win.Security;
using CJ.Win.CSD.CallCenter;

namespace CJ.Win.CSD.Reception
{
    public partial class frmJobNoSave : Form
    {
        CSDJob oCSDJob;
        public frmJobNoSave()
        {
            InitializeComponent();
        }

        public void ShowDialog(string sJobNo)
        {
            //oCSDJob = new CSDJob();
            //oCSDJob.GetJobByJobNo(txtJobNoSave.Text);           
            txtJobNoSave.Text = "Save Successfully. Job#  "  + sJobNo + "";
            this.ShowDialog();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

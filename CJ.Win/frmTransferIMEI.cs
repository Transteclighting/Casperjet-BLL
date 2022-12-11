using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;

namespace CJ.Win
{
    public partial class frmTransferIMEI : Form
    {
        TransferIMEI _oTransferIMEI;

        public frmTransferIMEI()
        {
            InitializeComponent();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                pbTransferIMEI.Visible = true;
                pbTransferIMEI.Minimum = 0;
                pbTransferIMEI.Maximum = 1;
                pbTransferIMEI.Step = 1;
                pbTransferIMEI.Value = 0;
               

                _oTransferIMEI = new TransferIMEI();

                DBController.Instance.BeginNewTransaction();
                _oTransferIMEI.Transfer();
                pbTransferIMEI.PerformStep();
                DBController.Instance.CommitTransaction();

                MessageBox.Show("You Have Successfully Process Data. ", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AppLogger.LogInfo("Win:You Have Successfully Process Data" + Utility.UserId);

                pbTransferIMEI.Visible = false;
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
                AppLogger.LogError("Win: Error for Process data - IMEI Transfer to TEL From TML" + ex);

            }
        }
    }
}
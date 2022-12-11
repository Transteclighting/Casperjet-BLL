using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using CJ.Class;
using CJ.Class.Report;
using CJ.Report;
using CJ.Class.HR;

namespace CJ.Win.HR
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
            DataLoad();
        }
        public void DataLoad()
        {
            DBController.Instance.OpenNewConnection();
            Setting oSetting = new Setting();
            oSetting.Refresh();
            if (oSetting.TimeOut != null)
                dtTimeOut.Value = Convert.ToDateTime(oSetting.TimeOut);           
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            Setting oSetting = new Setting();

            oSetting.TimeOut = dtTimeOut.Value;
         
            try
            {
                DBController.Instance.BeginNewTransaction();
                oSetting.Delete();
                oSetting.Add();
                DBController.Instance.CommitTransaction();
                MessageBox.Show("You Have Successfully Save The Stting.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
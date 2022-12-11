using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Plan;
using System.Data.OleDb;

namespace CJ.Win.Inventory
{
    public partial class frmLiveDemoStatusUpdate : Form
    {
        LiveDemo _oLiveDemo;

        int nID = 0;

        public frmLiveDemoStatusUpdate()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void ShowDialog(LiveDemo oLiveDemo)
        {

            nID = 0;
            nID = oLiveDemo.ID;
            lblShowroomCode.Text = oLiveDemo.ShowroomCode;
            lblProductCode.Text = oLiveDemo.ProductCode;
            lblProductName.Text = oLiveDemo.ProductName;
            lblTranNo.Text = oLiveDemo.TranNo;
            lblSerial.Text = oLiveDemo.ProductSerialNo;
            txtRefTranNo.Text = oLiveDemo.InvoiceNo;
            txtRemarks.Text = oLiveDemo.Remarks;
            this.Tag = oLiveDemo;


            this.Text = "Status Update";

            this.ShowDialog();
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DBController.Instance.BeginNewTransaction();
                _oLiveDemo = new LiveDemo();
                _oLiveDemo.ID = nID;
                _oLiveDemo.Status = (int)Dictionary.LiveDemoStatus.Sold;
                _oLiveDemo.RefTranNo = txtRefTranNo.Text;
                _oLiveDemo.Remarks = txtRemarks.Text;
                _oLiveDemo.UpdateStatus();

                DBController.Instance.CommitTransaction();

                MessageBox.Show("Update Successfull # " + _oLiveDemo.ID, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
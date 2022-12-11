// <summary>
// Compamy: Transcom Electronics Limited
// Author: Arif Khan
// Date: Apr 27, 2014
// Time :  3:33 PM
// Description: Form for SBUs.
// Modify Person And Date: 
// </summary>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Report;

namespace CJ.Win
{
    public partial class frmSBUs : Form
    {
        private SBUs _oSBUs;
        public frmSBUs()
        {
            InitializeComponent();
        }

        private void frmSBUs_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void DataLoadControl()
        {
            _oSBUs = new SBUs();
            lvwSBUs.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oSBUs.Refresh();
            this.Text = "SBU " + "[" + _oSBUs.Count + "]";
            foreach (SBU oSBU in _oSBUs)
            {
                ListViewItem oItem = lvwSBUs.Items.Add(oSBU.SBUCode);
                oItem.SubItems.Add(oSBU.SBUName);
                //oItem.SubItems.Add(oSBU.DivisionName);
                oItem.Tag = oSBU;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmSBU oForm = new frmSBU();
            oForm.ShowDialog();
            DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwSBUs.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an SBU to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SBU oSBU = (SBU)lvwSBUs.SelectedItems[0].Tag;
            frmSBU oForm = new frmSBU();
            oForm.ShowDialog(oSBU);
            DataLoadControl();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //DataSet oDS = _oSBUs.ToDataSet();
            //oDS.WriteXml("C:\\dept.xml");
            //DataRow[] oDR = oDS.Tables[0].Select("SBUCode='MIS'");

            //DataSet oDS1 = new DataSet();
            //oDS1.Merge(oDR);
            //oDS1.AcceptChanges();

            ////_oSBUs.FromDataSet(oDS1);

            //this.Text = "SBU " + "[" + _oSBUs.Count + "]";
            //lvwSBUs.Items.Clear();
            //foreach (SBU oSBU in _oSBUs)
            //{
            //    ListViewItem oItem = lvwSBUs.Items.Add(oSBU.SBUCode);
            //    oItem.SubItems.Add(oSBU.SBUName);
            //    oItem.Tag = oSBU;
            //}

            ////SBUs oSBUs = new SBUs();
            ////oSBUs.Refresh();
            ////rptSBUs oReport = new rptSBUs();
            ////oReport.SetDataSource(oSBUs);
            ////frmPrintPreview oFrom = new frmPrintPreview();

            ////oFrom.ShowDialog(oReport);
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (lvwSBUs.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an SBU to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SBU oSBU = (SBU)lvwSBUs.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete SBU: " + oSBU.SBUCode + " ? ", "Confirm SBU Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oSBU.Delete();
                    DBController.Instance.CommitTransaction();
                    DataLoadControl();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }


            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}
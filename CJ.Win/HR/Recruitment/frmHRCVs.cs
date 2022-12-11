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
   
    public partial class frmHRCVs : Form
    {
        HRCVs oHRCVs;

        public frmHRCVs()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //frmHRCV oForm = new frmHRCV();
            //oForm.ShowDialog();
        }
        public void DataLoadControl()
        {
            oHRCVs = new HRCVs();
            lvwCV.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oHRCVs.Refresh(txtCVNo.Text.Trim(), txtCandidateName.Text.Trim(), txtContactNo.Text.Trim());

            foreach (HRCV oHRCV in oHRCVs)
            {
                ListViewItem lstItem = lvwCV.Items.Add(oHRCV.CVNo.ToString());
                lstItem.SubItems.Add(oHRCV.CandidateName.ToString());
                lstItem.SubItems.Add(oHRCV.ContactNo.ToString());
                lstItem.SubItems.Add(oHRCV.Email.ToString());
                lstItem.SubItems.Add(oHRCV.PositionName.ToString());
                lstItem.SubItems.Add(oHRCV.SourceName.ToString());
                lstItem.SubItems.Add(Enum.GetName(typeof(Dictionary.HRCVStatus), oHRCV.Status));
                lstItem.Tag = oHRCV;
            }
        }
        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void btnShowCV_Click(object sender, EventArgs e)
        {
            if (lvwCV.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Item.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            HRCV oHRCV = (HRCV)lvwCV.SelectedItems[0].Tag;
            System.Diagnostics.Process.Start(oHRCV.UploadedCVPath);
        }
    }
}
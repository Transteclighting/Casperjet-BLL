using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;


namespace CJ.Win.CSD.Reception
{
    public partial class frmForcelyStatusUpdate : Form
    {
        CSDJobStatuss _oCSDJobStatuss;
        CSDJob _oCSDJob;
        public void ShowDialog(CSDJob oCSDJob)
        {
            this.Tag = oCSDJob;
            txtJobNo.Text = oCSDJob.JobNo;
            this.ShowDialog(); 
        }
        public frmForcelyStatusUpdate()
        {
            InitializeComponent();
        }

        private void frmForcelyStatusUpdate_Load(object sender, EventArgs e)
        {

        }
        private void LoadCombos()
        {
            _oCSDJobStatuss = new CSDJobStatuss();
            _oCSDJobStatuss.Refresh();
            cmbJobStatus.Items.Clear();
            foreach (CSDJobStatus oCSDJobStatus in _oCSDJobStatuss)
            {
                cmbJobStatus.Items.Add(oCSDJobStatus.StatusName);
            }
            CSDJob oCSDJob = (CSDJob)this.Tag;
            cmbJobStatus.SelectedIndex = _oCSDJobStatuss.GetIndex(oCSDJob.Status);

            cmbProductLocation.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ProductLocation)))
            {
                cmbProductLocation.Items.Add(Enum.GetName(typeof(Dictionary.ProductLocation), GetEnum));
            }
            cmbProductLocation.SelectedIndex = oCSDJob.ProductLocation - 1;

            cmbProductPhysicalLocation.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ProductPhysicalLocation)))
            {
                cmbProductPhysicalLocation.Items.Add(Enum.GetName(typeof(Dictionary.ProductPhysicalLocation), GetEnum));
            }
            cmbProductPhysicalLocation.SelectedIndex = oCSDJob.ProductPhysicalLocation - 1;

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _oCSDJob = new CSDJob();
            _oCSDJob.Status = _oCSDJobStatuss[cmbJobStatus.SelectedIndex].StatusID;
            _oCSDJob.ProductLocation = cmbProductLocation.SelectedIndex + 1;
            _oCSDJob.ProductPhysicalLocation = cmbProductPhysicalLocation.SelectedIndex + 1;
            try
            {
                DBController.Instance.OpenNewConnection();
                DBController.Instance.BeginNewTransaction();
                //_oCSDJob.UpdateStatusForcely();
                DBController.Instance.CommitTransaction();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }

    }
}
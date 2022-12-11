using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.Warranty;

namespace CJ.Win.Warranty
{
    public partial class frmWarrantyClaimDistributions : Form
    {

        //CSDJobsForWarrantys oCSDJobs;
        public frmWarrantyClaimDistributions()
        {
            InitializeComponent();
        }

        private void DataLoadControl()
        {
            CSDJobsForWarrantys oCSDJobs = new CSDJobsForWarrantys();

            lvwWarrantyClaimDistributions.Items.Clear();
            DBController.Instance.OpenNewConnection();

            //int nASGID = 0;
            //if (cmbServiceType.SelectedIndex > 0)
            //{
            //    nASGID = _oProductDetailsASG[cmbServiceType.SelectedIndex - 1].ASGID;
            //}
            //int nBrandID = 0;
            //if (cmbBrand.SelectedIndex > 0)
            //{
            //    nBrandID = _oProductDetailsBrand[cmbBrand.SelectedIndex - 1].BrandID;
            //}

            oCSDJobs.GetDataFromCSDJob(txtJobNo.Text, cmbJobType.SelectedIndex, cmbServiceType.SelectedIndex, cmbIsWD.SelectedIndex-1);

            this.Text = "Total " + "[" + oCSDJobs.Count + "]";
            foreach (CSDJobsForWarranty oCSDJob in oCSDJobs)
            {
                ListViewItem oItem = lvwWarrantyClaimDistributions.Items.Add(oCSDJob.JobNo);
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.CSDJobType), oCSDJob.JobType));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.CSDServiceType), oCSDJob.ServiceType));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.JobStatus), oCSDJob.Status));
                oItem.SubItems.Add(oCSDJob.DeliveryDate.ToString());
                oItem.SubItems.Add(oCSDJob.CustomerName.ToString());
                oItem.SubItems.Add(oCSDJob.CustomerAddress.ToString());
                oItem.SubItems.Add(oCSDJob.CreateDate.ToString());
                oItem.SubItems.Add(oCSDJob.SparePartsCharge.ToString());
                oItem.SubItems.Add(oCSDJob.ServiceCharge.ToString());
                oItem.SubItems.Add(oCSDJob.TransportationCharge.ToString());
                oItem.SubItems.Add(oCSDJob.OtherCharge.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.WarrantyClaimDistribution), oCSDJob.IsWarrantyDistribution));               

                oItem.Tag = oCSDJob;
            }
            setListViewRowColour();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmWarrantyClaimDistributions_Load(object sender, EventArgs e)
        {
            LoadCombos();
            DataLoadControl();
        }

        private void LoadCombos()
        {
            cmbJobType.Items.Add("All");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CSDJobType)))
            {
                cmbJobType.Items.Add(Enum.GetName(typeof(Dictionary.CSDJobType), GetEnum));
            }
            cmbJobType.SelectedIndex = 0;

            cmbServiceType.Items.Add("All");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CSDServiceType)))
            {
                cmbServiceType.Items.Add(Enum.GetName(typeof(Dictionary.CSDServiceType), GetEnum));
            }
            cmbServiceType.SelectedIndex = 0;

            cmbIsWD.Items.Add("All");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.WarrantyClaimDistribution)))
            {
                cmbIsWD.Items.Add(Enum.GetName(typeof(Dictionary.WarrantyClaimDistribution), GetEnum));
            }
            cmbIsWD.SelectedIndex = 0;

        }

        private void setListViewRowColour()
        {
            if (lvwWarrantyClaimDistributions.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwWarrantyClaimDistributions.Items)
                {
                    if (oItem.SubItems[12].Text == "No")
                    {
                        oItem.BackColor = Color.LightCoral;
                    }
                    else
                    {
                        oItem.BackColor = Color.White;

                    }
                }
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CSDJobsForWarrantys oCSDJobs;
            CSDJobsForWarranty oCSDJob;

            if (lvwWarrantyClaimDistributions.SelectedItems.Count != 0)
            {

                CSDJobsForWarranty oCSDJobsForWarranty = (CSDJobsForWarranty)lvwWarrantyClaimDistributions.SelectedItems[0].Tag;

                if (oCSDJobsForWarranty.IsWarrantyDistribution != (int)Dictionary.WarrantyClaimDistribution.Yes)
                {
                    oCSDJobs = new CSDJobsForWarrantys();

                    foreach (ListViewItem oItem in lvwWarrantyClaimDistributions.SelectedItems)
                    {
                        oCSDJob = (CSDJobsForWarranty)oItem.Tag;
                        oCSDJobs.Add(oCSDJob);
                    }

                    frmWarrantyClaimDistribution oForm = new frmWarrantyClaimDistribution();
                    oForm.ShowDialog(oCSDJobs);
                    if (oForm._IsTrue == true)
                        DataLoadControl();
                }

                else
                {
                    MessageBox.Show("This Job Already has Warranty Distribution.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }


            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

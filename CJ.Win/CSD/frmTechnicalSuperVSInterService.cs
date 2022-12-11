// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Jun 24,2012
// Time : 11.21 AM
// Description: Technical Supervisor VS Inter Service Mapping form
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.CSD;
using CJ.Class;
using CJ.Class.Report;
using CJ.Class.Library;
using CJ.Win.Security;
using CJ.Report;
using CJ.Report.CSD;


namespace CJ.Win
{
    public partial class frmTechnicalSuperVSInterService : Form
    {


        Utilities _oUtilitys;
        TechnicalSupervisors oTechnicalSupervisors;

        CSDMappings _oCSDMappings;
        public CSDMapping _oCSDMapping;
        public InterService oInterService;
        public TechnicalSupervisor _oTechnicalSupervisor;


        public frmTechnicalSuperVSInterService()
        {
            InitializeComponent();
        }

        private void LoadCombos()
        {

            //Get Is Active Status for Un Mapping ISV List
            cmbIsActive.Items.Add("All");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.InquiryCommunicationStatus)))
            {
                cmbIsActive.Items.Add(Enum.GetName(typeof(Dictionary.InquiryCommunicationStatus), GetEnum));
            }
            cmbIsActive.SelectedIndex = cmbIsActive.Items.Count - 3;

            //Get Is Active Status for Mapping ISV List
            cmbIsActive1.Items.Add("All");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.InquiryCommunicationStatus)))
            {
                cmbIsActive1.Items.Add(Enum.GetName(typeof(Dictionary.InquiryCommunicationStatus), GetEnum));
            }
            cmbIsActive1.SelectedIndex = cmbIsActive1.Items.Count - 3;

        }
        public void ShowDialog(TechnicalSupervisor oTechnicalSupervisor)
        {
            this.Tag = oTechnicalSupervisor;

            lblDesignation.Text = oTechnicalSupervisor.Employee.Designation.DesignationName;
            lblSupervisorID.Text = oTechnicalSupervisor.SupervisorID.ToString();
            lblSupervisorName.Text = oTechnicalSupervisor.Employee.EmployeeName;
            
            this.ShowDialog();
        }

        private void frmTechnicalSuperVSInterService_Load(object sender, EventArgs e)
        {

            LoadCombos();

            DataLoadControl();
            DataLoadControlAll();
            
        }

        private void DataLoadControl()
        {
            _oTechnicalSupervisor = (TechnicalSupervisor)this.Tag;
            CSDMappings oCSDMappings = new CSDMappings();
            DBController.Instance.OpenNewConnection();
            oCSDMappings.RefreshByID_TS_vs_IS(_oTechnicalSupervisor.SupervisorID,txtISVCode1.Text, txtISVName1.Text, txtAddress1.Text, cmbIsActive1.SelectedIndex - 1);
            lvwMapping.Items.Clear();         

            lblTotalMapping.Text = "Total " + "=" + oCSDMappings.Count + "";
            foreach (CSDMapping oCSDMapping in oCSDMappings)
            {
                ListViewItem oItem = lvwMapping.Items.Add(oCSDMapping.InterService.Code);
                oItem.SubItems.Add(oCSDMapping.InterService.Name);
                oItem.SubItems.Add(oCSDMapping.InterService.Address);
                oItem.SubItems.Add(oCSDMapping.InterService.IsActives);

                oItem.Tag = oCSDMapping;
            }
            setListViewRowColourMapping();
        }
        private void DataLoadControlAll()
        {

            CSDMappings oCSDMappings = new CSDMappings();
            DBController.Instance.OpenNewConnection();
            oCSDMappings.RefreshISVAll(txtISVCode.Text, txtISVName.Text, txtAddress.Text, cmbIsActive.SelectedIndex - 1);
            lvwInterServiceUnMapping.Items.Clear();
        
            lblTotalAll.Text = "Total " + "=" + oCSDMappings.Count + "";
            foreach (CSDMapping oCSDMapping in oCSDMappings)
            {
                ListViewItem oItem = lvwInterServiceUnMapping.Items.Add(oCSDMapping.InterService.Code);
                oItem.SubItems.Add(oCSDMapping.InterService.Name);
                oItem.SubItems.Add(oCSDMapping.InterService.Address);
                oItem.SubItems.Add(oCSDMapping.InterService.IsActives);

                oItem.Tag = oCSDMapping;
            }
            setListViewRowColour();
        }
        
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lvwInterServiceUnMapping.SelectedItems.Count != 0)
            {
                CSDMapping oCSDMapping = (CSDMapping)lvwInterServiceUnMapping.SelectedItems[0].Tag;

                oCSDMapping.MainID = _oTechnicalSupervisor.SupervisorID;
                oCSDMapping.SubID = oCSDMapping.ID;
            
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oCSDMapping.Add();
                    DBController.Instance.CommitTransaction();
                }
                catch(Exception ex)
                {
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Error..."+ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                this.Cursor = Cursors.WaitCursor;
                DataLoadControl();
                DataLoadControlAll();
                this.Cursor = Cursors.Default;
            }
            else
            {
                MessageBox.Show("Please Select a row from Un Mapping List.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }
            

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwMapping.SelectedItems.Count != 0)
            {
                CSDMapping oCSDMapping = (CSDMapping)lvwMapping.SelectedItems[0].Tag;


                //oCSDMapping.MainID = _oTechnicalSupervisor.SupervisorID;
                //oCSDMapping.SubID = _oTechnicalSupervisor.InterService.InterServiceID;

                oCSDMapping.DeleteTS_VS_IS();
                this.Cursor = Cursors.WaitCursor;
                DataLoadControl();
                DataLoadControlAll();
                this.Cursor = Cursors.Default;

            }
            else
            {
                MessageBox.Show("Please Select a row from Mapping List.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }
        }

        private void txtISVCode_TextChanged(object sender, EventArgs e)
        {
            DataLoadControlAll();
        }

        private void cmbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataLoadControlAll();
        }

        private void txtISVName_TextChanged(object sender, EventArgs e)
        {
            DataLoadControlAll();
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            DataLoadControlAll();
        }

        private void txtISVCode1_TextChanged(object sender, EventArgs e)
        {
           DataLoadControl();
        }

        private void txtISVName1_TextChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void cmbIsActive1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void txtAddress1_TextChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void setListViewRowColour()
        {
            if (lvwInterServiceUnMapping.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwInterServiceUnMapping.Items)
                {
                    if (oItem.SubItems[3].Text == Dictionary.InquiryCommunicationStatus.False.ToString())
                    {
                        oItem.BackColor = Color.DarkGray;
                    }

                    else
                    {
                        oItem.BackColor = Color.Transparent;

                    }
                }
            }
        }
        private void setListViewRowColourMapping()
        {
            if (lvwMapping.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwMapping.Items)
                {
                    if (oItem.SubItems[3].Text == Dictionary.InquiryCommunicationStatus.False.ToString())
                    {
                        oItem.BackColor = Color.DarkGray;
                    }

                    else
                    {
                        oItem.BackColor = Color.Transparent;

                    }
                }
            }
        }


    }

}



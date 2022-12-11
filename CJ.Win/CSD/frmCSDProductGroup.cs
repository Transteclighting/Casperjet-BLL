using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.CSD;

namespace CJ.Win.CSD
{
    public partial class frmCSDProductGroup : Form
    {
        private CSDProductGroup _oCSDProductGroup;
        CSDProductGroupTechCharges oCSDProductGroupTechCharges;
        
        CSDProductGroupServiceCharges oCSDProductGroupServiceCharges;

        public frmCSDProductGroup()
        {
            InitializeComponent();
        }

        private void frmCSDProductGroup_Load(object sender, EventArgs e)
        {
            _oCSDProductGroup = new CSDProductGroup();
            
            if(this.Tag==null)
                this.GridView();

          
           
        }

        public void ShowDialog(CSDProductGroup oCSDProductGroup)
        {
            this.Tag = oCSDProductGroup;
            //oCSDProductGroupTechCharges = new CSDProductGroupTechCharges();
            
            //oCSDProductGroupServiceCharges = new CSDProductGroupServiceCharges(); 
            txtName.Text = oCSDProductGroup.CSDProductGroupName;
        
            GridView();
            SetAmount(oCSDProductGroup.CSDProductGroupID);
            this.ShowDialog();

          

            
        }

        private bool IsValidate()
        {

            if (txtName.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Serviceable Product Group Name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return false;
            }
            foreach (DataGridViewRow oRow in dgvTechCharge.Rows)
            {
                try
                {
                    double val = Convert.ToDouble(oRow.Cells[6].Value);
                }
                catch
                {
                    MessageBox.Show("Please Input valid Technician Charge");
                    return false;
                }
            }
            foreach (DataGridViewRow oRow in dgvServiceCharge.Rows)
            {
                try
                {
                    double val = Convert.ToDouble(oRow.Cells[4].Value);
                }
                catch
                {
                    MessageBox.Show("Please Input valid Service Charge");
                    return false;
                }
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (IsValidate())
            {
                Save();
                this.Close();
            }
        }

        private void Save()
        {
            CSDProductGroupTechCharges oCSDProductGroupTechChagres = new CSDProductGroupTechCharges();
            CSDProductGroupServiceCharges oCSDProductGroupServiceCharges = new CSDProductGroupServiceCharges();

            if (this.Tag == null)
            {

                _oCSDProductGroup.CSDProductGroupName = txtName.Text;

                // Loop for TechCharge Grid View
                foreach (DataGridViewRow oItemRow in dgvTechCharge.Rows)
                {

                    CSDProductGroupTechCharge oItem = new CSDProductGroupTechCharge();

                    oItem.TechnicianCategory = Convert.ToInt32(oItemRow.Cells[1].Value);
                    oItem.ServiceType = Convert.ToInt32(oItemRow.Cells[3].Value);
                    oItem.ServiceStatus = Convert.ToInt32(oItemRow.Cells[5].Value);
                    oItem.ChargeAmount = Convert.ToDouble(oItemRow.Cells[6].Value);
                    oCSDProductGroupTechChagres.Add(oItem);
                }
                // Loop End

                // Loop for ServiceCharge Grid View

                foreach (DataGridViewRow oItemRow in dgvServiceCharge.Rows)
                {

                    CSDProductGroupServiceCharge oItem = new CSDProductGroupServiceCharge();
                    //oItem.CSDProductGroupID = ?
                    oItem.ChargeType = Convert.ToInt32(oItemRow.Cells[1].Value);
                    oItem.JobType = Convert.ToInt32(oItemRow.Cells[3].Value);
                    oItem.ChargeAmount = Convert.ToDouble(oItemRow.Cells[4].Value);
                    oCSDProductGroupServiceCharges.Add(oItem);
                }  
                 // Loop End
                    
                    
                 
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oCSDProductGroup.Add();


                    foreach (CSDProductGroupTechCharge oCSDProductGroupTechCharge in oCSDProductGroupTechChagres)
                    {
                        oCSDProductGroupTechCharge.CSDProductGroupID = _oCSDProductGroup.CSDProductGroupID;
                        oCSDProductGroupTechCharge.Add();
                    }

                    foreach (CSDProductGroupServiceCharge oCSDProductGroupServiceCharge in oCSDProductGroupServiceCharges)
                    {

                        oCSDProductGroupServiceCharge.CSDProductGroupID = _oCSDProductGroup.CSDProductGroupID;
                        oCSDProductGroupServiceCharge.Add();

                    }
                    

                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction : " + _oCSDProductGroup.CSDProductGroupID, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
            else
            {
                _oCSDProductGroup = (CSDProductGroup)this.Tag;
                _oCSDProductGroup.CSDProductGroupName = txtName.Text;
                _oCSDProductGroup.DeleteTechCharges();
                _oCSDProductGroup.DeleteServiceCharges();

                // Loop for TechCharge Grid View
                foreach (DataGridViewRow oItemRow in dgvTechCharge.Rows)
                {

                    CSDProductGroupTechCharge oItem = new CSDProductGroupTechCharge();

                    oItem.TechnicianCategory = Convert.ToInt32(oItemRow.Cells[1].Value);
                    oItem.ServiceType = Convert.ToInt32(oItemRow.Cells[3].Value);
                    oItem.ServiceStatus = Convert.ToInt32(oItemRow.Cells[5].Value);
                    oItem.ChargeAmount = Convert.ToDouble(oItemRow.Cells[6].Value);
                    oCSDProductGroupTechChagres.Add(oItem);
                }

                // Loop for Service Grid View
                foreach (DataGridViewRow oItemRow in dgvServiceCharge.Rows)
                {

                    CSDProductGroupServiceCharge oItem = new CSDProductGroupServiceCharge();
                    //oItem.CSDProductGroupID = ?
                    oItem.ChargeType = Convert.ToInt32(oItemRow.Cells[1].Value);
                    oItem.JobType = Convert.ToInt32(oItemRow.Cells[3].Value);
                    oItem.ChargeAmount = Convert.ToDouble(oItemRow.Cells[4].Value);
                    oCSDProductGroupServiceCharges.Add(oItem);
                }  

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oCSDProductGroup.Edit();

                   

                    foreach (CSDProductGroupTechCharge oCSDProductGroupTechCharge in oCSDProductGroupTechChagres)
                    {

                       
                        oCSDProductGroupTechCharge.CSDProductGroupID = _oCSDProductGroup.CSDProductGroupID;
                        oCSDProductGroupTechCharge.Edit();
                       
                        
                    }


                    foreach (CSDProductGroupServiceCharge oCSDProductGroupServiceCharge in oCSDProductGroupServiceCharges)
                    {
                        
                        oCSDProductGroupServiceCharge.CSDProductGroupID = _oCSDProductGroup.CSDProductGroupID;
                        oCSDProductGroupServiceCharge.Edit();

                    }
                    
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update The CSDProductGroup : " + _oCSDProductGroup.CSDProductGroupName, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
        
        public void GridView()
        {
            DataSet dataset1 = new DataSet();
            dataset1.ReadXml(@"F:\TechnicianCharge.xml");
            dgvTechCharge.DataSource = dataset1.Tables[0];
            this.dgvTechCharge.Columns["TechnicianCategory"].ReadOnly = true;
            this.dgvTechCharge.Columns["TechnicianCategoryID"].Visible = false;
            this.dgvTechCharge.Columns["ServiceType"].ReadOnly = true;
            this.dgvTechCharge.Columns["ServiceTypeID"].Visible = false;
            this.dgvTechCharge.Columns["ServiceStatus"].ReadOnly = true;
            this.dgvTechCharge.Columns["ServiceStatusID"].Visible = false;           
            this.dgvTechCharge.Columns["ChargeAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvTechCharge.AllowUserToAddRows = false;
            this.dgvTechCharge.AllowUserToDeleteRows = false;



            DataSet dataset2 = new DataSet();
            dataset2.ReadXml(@"F:\ServiceCharge.xml");
            dgvServiceCharge.DataSource = dataset2.Tables[0];
            this.dgvServiceCharge.Columns["ChargeType"].ReadOnly = true;
            this.dgvServiceCharge.Columns["ChargeTypeID"].Visible = false;
            this.dgvServiceCharge.Columns["JobType"].ReadOnly = true;
            this.dgvServiceCharge.Columns["JobTypeID"].Visible = false;           
            this.dgvServiceCharge.Columns["ChargeAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            this.dgvServiceCharge.AllowUserToAddRows = false;
            this.dgvServiceCharge.AllowUserToDeleteRows = false;
            
            
            
        }
        private void SetAmount(int nCSDProductGroupID)
        {
            CSDProductGroupTechCharges oCSDProductGroupTechCharges = new CSDProductGroupTechCharges();
            oCSDProductGroupTechCharges.Refresh(nCSDProductGroupID);
           

            foreach (CSDProductGroupTechCharge oCSDProductGroupTechCharge in oCSDProductGroupTechCharges)
            {               
                foreach (DataGridViewRow oItemRow in dgvTechCharge.Rows)
                {
                    CSDProductGroupTechCharge oItem = new CSDProductGroupTechCharge();

                    if (oCSDProductGroupTechCharge.TechnicianCategory == Convert.ToInt32(oItemRow.Cells[1].Value)
                        && oCSDProductGroupTechCharge.ServiceType == Convert.ToInt32(oItemRow.Cells[3].Value)
                        && oCSDProductGroupTechCharge.ServiceStatus == Convert.ToInt32(oItemRow.Cells[5].Value))
                    {
                        oItemRow.Cells[6].Value = Convert.ToDouble(oCSDProductGroupTechCharge.ChargeAmount).ToString();
                    }
                }
            }



            CSDProductGroupServiceCharges oCSDProductGroupServiceCharges = new CSDProductGroupServiceCharges();
            oCSDProductGroupServiceCharges.Refresh(nCSDProductGroupID);

            foreach (CSDProductGroupServiceCharge oCSDProductGroupServiceCharge in oCSDProductGroupServiceCharges)
            {
                foreach (DataGridViewRow oItemRow in dgvServiceCharge.Rows)
                {
                    CSDProductGroupServiceCharge oItem = new CSDProductGroupServiceCharge();

                    if (oCSDProductGroupServiceCharge.ChargeType == Convert.ToInt32(oItemRow.Cells[1].Value)
                        && oCSDProductGroupServiceCharge.JobType == Convert.ToInt32(oItemRow.Cells[3].Value))
                    {
                        oItemRow.Cells[4].Value = Convert.ToDouble(oCSDProductGroupServiceCharge.ChargeAmount).ToString();
                    }
 
                }
            }
        }
 
    }
}
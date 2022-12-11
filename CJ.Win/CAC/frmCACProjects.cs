using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Win.Security;

namespace CJ.Win.CAC
{
    public partial class frmCACProjects : Form
    {
        bool IsCheck = false;
        CACProjects oCACProjects;
        public frmCACProjects()
        {
            InitializeComponent();
        }

        private void frmCACProjects_Load(object sender, EventArgs e)
        {
            LoadCombo();
            DataLoadControl(); 
            UpdateSecurity();
        }
        private void LoadCombo()
        {
            dtFromDate.Value = DateTime.Today;
            dtToDate.Value = DateTime.Today;

            cmbStatus.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CACProjectStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.CACProjectStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;
        }
        private void DataLoadControl()
        {
            this.Cursor = Cursors.WaitCursor;
            int nStatus = 0;
            if (cmbStatus.SelectedIndex == 0)
            {
                nStatus = -1;
            }
            else
            {
                nStatus = cmbStatus.SelectedIndex;
            }
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            oCACProjects = new CACProjects();
            lvwCACProject.Items.Clear();

            DBController.Instance.OpenNewConnection();
            oCACProjects.RefreshByCACProject(dtFromDate.Value.Date, dtToDate.Value.Date,txtCode.Text.Trim(), ctlCustomer1.txtCode.Text.Trim(), nStatus,ctlEmployee1.txtCode.Text.Trim(), ctlEmployee2.txtCode.Text.Trim(),txtProjectName.Text.Trim(), IsCheck);

            foreach (CACProject oCACProject in oCACProjects)
            {
                ListViewItem oItem = lvwCACProject.Items.Add(oCACProject.ProjectCode);
                oItem.SubItems.Add(oCACProject.ProjectName);
                oItem.SubItems.Add(oCACProject.CustomerName);
                oItem.SubItems.Add(Convert.ToDateTime(oCACProject.StartDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(Convert.ToDateTime(oCACProject.EndDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oCACProject.TotalAmount.ToString());
                oItem.SubItems.Add(oCACProject.CompleteTaskValue.ToString());
                oItem.SubItems.Add(oCACProject.InvoiceAmount.ToString());                
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.CACProjectStatus), oCACProject.Status));
                oItem.SubItems.Add(oCACProject.SalespersonName);
                oItem.SubItems.Add(oCACProject.TechPersonName);
                oItem.SubItems.Add(oCACProject.Remarks);

                oItem.Tag = oCACProject;
            }
            this.Text = " Total " + "[" + oCACProjects.Count + "]";
            this.Cursor = Cursors.Default;
            setListViewRowColour();
        }
        private void setListViewRowColour()
        {
            if (lvwCACProject.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwCACProject.Items)
                {
                    if (oItem.SubItems[8].Text == "Complete")
                    {
                        oItem.BackColor = Color.White;
                    }
                    else if (oItem.SubItems[8].Text == "Create")
                    {
                        oItem.BackColor = Color.LightGreen;
                    }
                    else if (oItem.SubItems[8].Text == "Running")
                    {
                        oItem.BackColor = Color.SandyBrown;
                    }
                    else if (oItem.SubItems[8].Text == "Cancel")
                    {
                        oItem.BackColor = Color.Gray;
                    }
                    else if (oItem.SubItems[8].Text == "Pending")
                    {
                        oItem.BackColor = Color.LightCoral;
                    }
                    else if (oItem.SubItems[8].Text == "Handover")
                    {
                        oItem.BackColor = Color.DarkKhaki;
                    }
                }
            }
        }
        private void UpdateSecurity()
        {
            Users oUsers = new Users();
            Permission oPermission = new Permission();
            DSPermission _oDsPermission = oPermission.getPermissionList();

            DataRow[] oPermitedRow = _oDsPermission.Permission.Select("MenuType >= '" + (short)Dictionary.MenuType.Buttton + "'");
            foreach (DataRow oRow in oPermitedRow)
            {
                string sPermissionKey = oUsers.checkOtherPermission(oRow["PermissionKey"].ToString(), Utility.UserId);
                if (sPermissionKey != null)
                {
                    if ("M44.3.1.1" == sPermissionKey)
                    {
                        btnAdd.Enabled = true;
                    }
                    if ("M44.3.1.2" == sPermissionKey)
                    {
                        btnUpdate.Enabled = true;
                    }
                    if ("M44.3.1.3" == sPermissionKey)
                    {
                        btnProjectTask.Enabled = true;
                    }
                    if ("M44.3.1.4" == sPermissionKey)
                    {
                        btnProjectProgress.Enabled = true;
                    }
                    if ("M44.3.1.5" == sPermissionKey)
                    {
                        btnCollectionSchedule.Enabled = true;
                    }
                    if ("M44.3.1.6" == sPermissionKey)
                    {
                        btnCollection.Enabled = true;
                    }
                    if ("M44.3.1.7" == sPermissionKey)
                    {
                        btnInvoice.Enabled = true;
                    }
                    if ("M44.3.1.8" == sPermissionKey)
                    {
                        btnPending.Enabled = true;
                    }
                    if ("M44.3.1.9" == sPermissionKey)
                    {
                        btnCancel.Enabled = true;
                    }
                    if ("M44.3.1.10" == sPermissionKey)
                    {
                        btnHandOver.Enabled = true;
                    }
                    if ("M44.3.1.11" == sPermissionKey)
                    {
                        btnOtherSales.Enabled = true;
                    }
                    if ("M44.3.1.12" == sPermissionKey)
                    {
                        btnPayment.Enabled = true;
                    }
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
              frmCACProject oForm = new frmCACProject((int)Dictionary.CACProjectStatus.Create);
              oForm.ShowDialog();
              if (oForm.IsTrue == true)
              DataLoadControl();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lvwCACProject.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Item to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (lvwCACProject.SelectedItems[0].SubItems[8].Text == "Handover")
            {
                MessageBox.Show("Handover Status Can't be update", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }            
            CACProject oCACProject = (CACProject)lvwCACProject.SelectedItems[0].Tag;
            frmCACProject oForm = new frmCACProject((int)Dictionary.CACProjectStatus.Create);
            oForm.ShowDialog(oCACProject);
            DataLoadControl();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                dtFromDate.Enabled = false;
                dtToDate.Enabled = false;
                IsCheck = true;
            }
            else
            {
                dtFromDate.Enabled = true;
                dtToDate.Enabled = true;
                IsCheck = false;
            }
        }

        private void btnCollectionSchedule_Click(object sender, EventArgs e)
        {
            if (lvwCACProject.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row First.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (lvwCACProject.SelectedItems[0].SubItems[8].Text == "Cancel")
            {
                MessageBox.Show("It's Cancel you can't add Collection Schedule", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (lvwCACProject.SelectedItems[0].SubItems[8].Text == "Handover")
            {
                MessageBox.Show("After Handover Can't be add Collection Schedule ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CACProject oCACProject = (CACProject)lvwCACProject.SelectedItems[0].Tag;
            frmCACProjectCollectionSchedule oForm = new frmCACProjectCollectionSchedule();
            oForm.ShowDialog(oCACProject);
            DataLoadControl();
        }

        private void btnCollection_Click(object sender, EventArgs e)
        {
            if (lvwCACProject.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row First.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (lvwCACProject.SelectedItems[0].SubItems[8].Text == "Cancel")
            {
                MessageBox.Show("It's Cancel you can't add Collection", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (lvwCACProject.SelectedItems[0].SubItems[8].Text == "Handover")
            {
                MessageBox.Show("After Handover Can't be Collection ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CACProject oCACProject = (CACProject)lvwCACProject.SelectedItems[0].Tag;
            frmCACProjectCollection oForm = new frmCACProjectCollection();
            oForm.ShowDialog(oCACProject);
            DataLoadControl();
        }

        private void btnProjectTask_Click(object sender, EventArgs e)
        {
            if (lvwCACProject.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Item for Task Weight.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (lvwCACProject.SelectedItems[0].SubItems[8].Text == "Cancel")
            {
                MessageBox.Show("It's Cancel you can't add task", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (lvwCACProject.SelectedItems[0].SubItems[8].Text == "Handover")
            {
                MessageBox.Show("After Handover Can't be add task ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CACProject oCACProject = (CACProject)lvwCACProject.SelectedItems[0].Tag;
            if (oCACProject.Status != ((int)Dictionary.CACProjectStatus.Complete))
            {
                frmCACProjectTaskWeight oForm = new frmCACProjectTaskWeight((int)Dictionary.CACProjectStatus.Running);
                oForm.ShowDialog(oCACProject);
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Only Create & Running status can be changed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void btnProjectProgress_Click(object sender, EventArgs e)
        {
            if (lvwCACProject.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Item for Task Complete Progress.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (lvwCACProject.SelectedItems[0].SubItems[8].Text == "Cancel")
            {
                MessageBox.Show("It's Cancel you can't add task progress", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (lvwCACProject.SelectedItems[0].SubItems[8].Text == "Handover")
            {
                MessageBox.Show("After Handover Can't be Progress ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CACProject oCACProject = (CACProject)lvwCACProject.SelectedItems[0].Tag;
            if (oCACProject.Status == ((int)Dictionary.CACProjectStatus.Running))
            {
                frmCACProjectTaskComplete oForm = new frmCACProjectTaskComplete((int)Dictionary.CACProjectStatus.Running);
                oForm.ShowDialog(oCACProject);
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Only Running status can be changed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnPending_Click(object sender, EventArgs e)
        {
            if (lvwCACProject.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Item to Pending.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (lvwCACProject.SelectedItems[0].SubItems[8].Text == "Cancel")
            {
                MessageBox.Show("Cancel Status Can't be Pending", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //else if (lvwCACProject.SelectedItems[0].SubItems[8].Text == "Running")
            //{
            //    MessageBox.Show("Running Status Can't be Pending", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            else if (lvwCACProject.SelectedItems[0].SubItems[8].Text == "Pending")
            {
                MessageBox.Show("Pending Status Can't be Pending", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (lvwCACProject.SelectedItems[0].SubItems[8].Text == "Complete")
            {
                MessageBox.Show("Complete Status Can't be Pending", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (lvwCACProject.SelectedItems[0].SubItems[8].Text == "Handover")
            {
                MessageBox.Show("After Handover Can't be Pending ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CACProject oCACProject = (CACProject)lvwCACProject.SelectedItems[0].Tag;
            if (oCACProject.Status != ((int)Dictionary.CACProjectStatus.Complete))
            {
                frmCACprojectStatus oForm = new frmCACprojectStatus((int)Dictionary.CACProjectStatus.Pending);
                oForm.ShowDialog(oCACProject.ProjectID,oCACProject.ProjectCode,oCACProject.ProjectName);
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Only Create status can be Pending.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
        private void btnInvoice_Click(object sender, EventArgs e)
        {
            if (lvwCACProject.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Item to add.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (lvwCACProject.SelectedItems[0].SubItems[8].Text == "Cancel")
            {
                MessageBox.Show("It's Cancel you can't Invoice", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (lvwCACProject.SelectedItems[0].SubItems[8].Text == "Handover")
            {
                MessageBox.Show("After Handover Can't be Invoice ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
                CACProject oCACProject = (CACProject)lvwCACProject.SelectedItems[0].Tag;           
                frmCACProjectInvoiceWise oForm = new frmCACProjectInvoiceWise();
                oForm.ShowDialog(oCACProject.ProjectID,oCACProject.ProjectCode,oCACProject.ProjectName,oCACProject.CustomerID);
                DataLoadControl();
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (lvwCACProject.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Item to Cancel.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (lvwCACProject.SelectedItems[0].SubItems[8].Text == "Cancel")
            {
                MessageBox.Show("Cancel Status Can't be Cancel", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            //else if (lvwCACProject.SelectedItems[0].SubItems[8].Text == "Running")
            //{
            //    MessageBox.Show("Running Status Can't be Cancel", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            else if (lvwCACProject.SelectedItems[0].SubItems[8].Text == "Pending")
            {
                MessageBox.Show("Pending Status Can't be Cancel", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (lvwCACProject.SelectedItems[0].SubItems[8].Text == "Complete")
            {
                MessageBox.Show("Complete Status Can't be Cancel", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (lvwCACProject.SelectedItems[0].SubItems[8].Text == "Handover")
            {
                MessageBox.Show("After Handover Can't be Cancel", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CACProject oCACProject = (CACProject)lvwCACProject.SelectedItems[0].Tag;
            if (oCACProject.Status != ((int)Dictionary.CACProjectStatus.Complete))
            {
                frmCACprojectStatus oForm = new frmCACprojectStatus((int)Dictionary.CACProjectStatus.Cancel);
                oForm.ShowDialog(oCACProject.ProjectID,oCACProject.ProjectCode,oCACProject.ProjectName);
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Only Create status can be Cancel.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnHandOver_Click(object sender, EventArgs e)
        {
            if (lvwCACProject.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Item to Handover.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }                                 
            if (lvwCACProject.SelectedItems[0].SubItems[8].Text == "Cancel")
            {
                MessageBox.Show("Cancel Status Can't be Handover", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (lvwCACProject.SelectedItems[0].SubItems[8].Text == "Handover")
            {
                MessageBox.Show("After Handover Can't be Handover", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }            
            CACProject oCACProject = (CACProject)lvwCACProject.SelectedItems[0].Tag;
            frmCACprojectStatus oForm = new frmCACprojectStatus((int)Dictionary.CACProjectStatus.Handover);
            oForm.ShowDialog(oCACProject.ProjectID, oCACProject.ProjectCode, oCACProject.ProjectName);
            DataLoadControl();
        }

        private void btnOtherSales_Click(object sender, EventArgs e)
        {
            if (lvwCACProject.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Item to add.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (lvwCACProject.SelectedItems[0].SubItems[8].Text == "Cancel")
            {
                MessageBox.Show("It's Cancel you can't Changed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (lvwCACProject.SelectedItems[0].SubItems[8].Text == "Handover")
            {
                MessageBox.Show("After Handover Can't be Changed ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CACProject oCACProject = (CACProject)lvwCACProject.SelectedItems[0].Tag;
            frmCACProjectOtherSales oForm = new frmCACProjectOtherSales();
            oForm.ShowDialog(oCACProject);
            DataLoadControl();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            if (lvwCACProject.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Item to add.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (lvwCACProject.SelectedItems[0].SubItems[8].Text == "Cancel")
            {
                MessageBox.Show("It's Cancel you can't Changed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (lvwCACProject.SelectedItems[0].SubItems[8].Text == "Handover")
            {
                MessageBox.Show("After Handover Can't be Changed ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CACProject oCACProject = (CACProject)lvwCACProject.SelectedItems[0].Tag;
            frmCACProjectOtherPayment oForm = new frmCACProjectOtherPayment();
            oForm.ShowDialog(oCACProject);
            DataLoadControl();
        }
    }
}

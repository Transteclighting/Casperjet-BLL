using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;
using CJ.Class.Library;
using CJ.Class.BasicData;

namespace CJ.POS.RT
{
    public partial class frmPotentialCustomers : Form
    {
        bool IsCheck = false;
        PotentialCustomers _oPotentialCustomers;

        public frmPotentialCustomers()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SetListViewRowColour()
        {
            if (lvwPotentialCustomer.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwPotentialCustomer.Items)
                {
                    if (oItem.SubItems[8].Text == "Create")
                    {
                        oItem.BackColor = Color.Transparent;
                    }
                    else if (oItem.SubItems[8].Text == "Convert_to_Lead")
                    {
                        oItem.BackColor = Color.LightGreen;
                    }
                    else
                    {
                        oItem.BackColor = Color.SandyBrown;

                    }

                }
            }
        }
        private void DataLoadControl()
        {
            _oPotentialCustomers = new PotentialCustomers();
            lvwPotentialCustomer.Items.Clear();

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

            _oPotentialCustomers.RefreshRT(dtFromDate.Value.Date, dtToDate.Value.Date, nStatus, txtCompany.Text.Trim(), txtName.Text.Trim(), txtContactNo.Text.Trim(), txtTelephone.Text.Trim(), IsCheck);
            DBController.Instance.CloseConnection();

            foreach (PotentialCustomer oPotentialCustomer in _oPotentialCustomers)
            {
                ListViewItem oItem = lvwPotentialCustomer.Items.Add(oPotentialCustomer.CompanyName.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oPotentialCustomer.VisitDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oPotentialCustomer.Name.ToString());
                oItem.SubItems.Add(oPotentialCustomer.Designation.ToString());
                oItem.SubItems.Add(oPotentialCustomer.Address.ToString());
                oItem.SubItems.Add(oPotentialCustomer.MobileNo.ToString());
                oItem.SubItems.Add(oPotentialCustomer.TelephoneNo.ToString());
                oItem.SubItems.Add(oPotentialCustomer.Email.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.PotentialCustomer), oPotentialCustomer.Status));
                oItem.SubItems.Add(oPotentialCustomer.Remarks.ToString());
                oItem.SubItems.Add(oPotentialCustomer.LeadNo.ToString());
                if (oPotentialCustomer.LeadDate != null)
                    oItem.SubItems.Add(oPotentialCustomer.LeadDate.ToString());
                else oItem.SubItems.Add("");
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.SalesLeadStatusPOS), oPotentialCustomer.LeadStatus));

                oItem.Tag = oPotentialCustomer;
            }
            SetListViewRowColour();
        }
        private void LoadCombos()
        {
            TELLib oLib = new TELLib();
            dtFromDate.Value = oLib.ServerDateTime().Date;
            dtToDate.Value = dtFromDate.Value;

            
            //Status 
            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.PotentialCustomer)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.PotentialCustomer), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;


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
        private void frmPotentialCustomers_Load(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            LoadCombos();
            DataLoadControl();
        }
        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmPotentialCustomer oFrom = new frmPotentialCustomer();
            oFrom.ShowDialog();
            if (oFrom._IsTrue == true)
                DataLoadControl();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwPotentialCustomer.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row to Update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            PotentialCustomer oPotentialCustomer = (PotentialCustomer)lvwPotentialCustomer.SelectedItems[0].Tag;
            if (oPotentialCustomer.Status == (int)Dictionary.PotentialCustomer.Create)
            {
                frmPotentialCustomer oForm = new frmPotentialCustomer();
                oForm.ShowDialog(oPotentialCustomer);
                if (oForm._IsTrue == true)
                    DataLoadControl();

            }
            else
            {
                MessageBox.Show("Only Create status can be  Update", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

        private void lvwPotentialCustomer_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lvwPotentialCustomer.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row to Update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            PotentialCustomer oPotentialCustomer = (PotentialCustomer)lvwPotentialCustomer.SelectedItems[0].Tag;
            frmSalesLead ofrmSalesLead = new frmSalesLead(2, oPotentialCustomer.Name, oPotentialCustomer.MobileNo, oPotentialCustomer.Email, oPotentialCustomer.CompanyName, oPotentialCustomer.Address, oPotentialCustomer.Outlet, oPotentialCustomer.ID);
            ofrmSalesLead.ShowDialog();
            if (ofrmSalesLead._IsTrue == true)
                DataLoadControl();
            
        }
    }
}
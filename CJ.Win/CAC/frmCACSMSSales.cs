using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
//using CJ.Report;
//using CJ.Class.Report;
using CJ.Win.Security;

namespace CJ.Win.CAC
{
    public partial class frmCACSMSSales : Form
    {
        CACSMSSales _oCACSMSSales;
        public frmCACSMSSales()
        {
            InitializeComponent();
        }

        private void frmCACSMSSales_Load(object sender, EventArgs e)
        {
            DataLoadControl();
            UpdateSecurity();
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
                    if ("M44.5.1" == sPermissionKey)
                    {
                        btnAdd.Enabled = true;
                    }
                    if ("M44.5.2" == sPermissionKey)
                    {
                        btnEdit.Enabled = true;
                    }
                    if ("M44.5.3" == sPermissionKey)
                    {
                        btnApproved.Enabled = true;
                    }
                    if ("M44.5.4" == sPermissionKey)
                    {
                        btnDelete.Enabled = true;
                    }                                        
                }
            }
        }
        private void DataLoadControl()
        {
            CACSMSSales oCACSMSSales = new CACSMSSales();
            lvwCACSMSSale.Items.Clear();
            int nBrandID = -1;
            //if (cmbBrand.SelectedIndex > 0 && cmbBrand.SelectedIndex < _oBrands.Count) nBrandID = _oBrands[cmbBrand.SelectedIndex].BrandID;

            DBController.Instance.OpenNewConnection();
            oCACSMSSales.RefreshBySMSsales();
            this.Text = "CAC CACSMSSales " + "[" + oCACSMSSales.Count + "]";

            foreach (CACSMSSale oCACSMSSale in oCACSMSSales)
            {
                ListViewItem oItem = lvwCACSMSSale.Items.Add(oCACSMSSale.CustomerName);
                oItem.SubItems.Add(Convert.ToDateTime(oCACSMSSale.EntryDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oCACSMSSale.Brand);
                oItem.SubItems.Add(oCACSMSSale.SMSValue.ToString());
                oItem.SubItems.Add(oCACSMSSale.CostValue.ToString());
                //oItem.SubItems.Add(Convert.ToDouble(oCACSMSSale.CPBDT).ToString());
                //oItem.SubItems.Add(Convert.ToDouble(oCACSMSSale.RSP).ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.CACSMSSale), oCACSMSSale.Status));
                oItem.Tag = oCACSMSSale;
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCACSMSSale oForm = new frmCACSMSSale();
            oForm.ShowDialog();
            DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwCACSMSSale.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (lvwCACSMSSale.SelectedItems[0].SubItems[5].Text == "Approved")
            {
                MessageBox.Show("It's Approved you can't Changed", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CACSMSSale oCACSMSSale = (CACSMSSale)lvwCACSMSSale.SelectedItems[0].Tag;
            frmCACSMSSale oForm = new frmCACSMSSale();
            oForm.ShowDialog(oCACSMSSale);
            DataLoadControl();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwCACSMSSale.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (lvwCACSMSSale.SelectedItems[0].SubItems[5].Text == "Approved")
            {
                MessageBox.Show("It's Approved you can't Delete", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _oCACSMSSales = new CACSMSSales();
            CACSMSSale oCACSMSSale = (CACSMSSale)lvwCACSMSSale.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete: " + oCACSMSSale.ID + " ? ", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oCACSMSSale.Delete();
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

        private void btnApproved_Click(object sender, EventArgs e)
        {
            if (lvwCACSMSSale.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Item to Approved.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CACSMSSale oCACSMSSale = (CACSMSSale)lvwCACSMSSale.SelectedItems[0].Tag;
            if (oCACSMSSale.Status == (int)Dictionary.CACSMSSale.Create)
            {
                oCACSMSSale.Approved(oCACSMSSale.ID);
                MessageBox.Show("Successfully Approved.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Only Create Status Can be Approved.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}

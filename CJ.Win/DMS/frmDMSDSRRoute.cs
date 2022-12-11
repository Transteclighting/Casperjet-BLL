using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.DMS;

namespace CJ.Win.DMS
{
    public partial class frmDMSDSRRoute : Form
    {
        DMSRoutes oDMSRoutes;
        DMSRoute _oDMSRoute;
        DMSDSRs _DMSNames, _ReplaceDMSNames;


        public frmDMSDSRRoute()
        {
            InitializeComponent();
        }

        private void ctlCustomer1_ChangeSelection(object sender, EventArgs e)
        {
            LoadCombos(ctlCustomer1.SelectedCustomer.CustomerID);
            LoadDataGridView();
        }
        private void LoadCombos(int nCustomerID)
        {
            _DMSNames = new DMSDSRs();
            cmbNewDSR.Items.Clear();
            cmbNewDSR.Items.Add("--Select DSR--");
            DBController.Instance.OpenNewConnection();
            _DMSNames.RefreshByCustomerID(nCustomerID);

            foreach (DMSDSR oDMSDSR in _DMSNames)
            {
                cmbNewDSR.Items.Add(oDMSDSR.DSRName);
            }
            cmbNewDSR.SelectedIndex = 0;

            _ReplaceDMSNames = new DMSDSRs();
            cmbReplaceDSR.Items.Clear();
            cmbReplaceDSR.Items.Add("--Select Replace DSR--");
            _ReplaceDMSNames.SelectDMSDSRByCustomerID(nCustomerID);
            foreach (DMSDSR oDMSDSR in _ReplaceDMSNames)
            {
                cmbReplaceDSR.Items.Add(oDMSDSR.DSRName);
            }
            cmbReplaceDSR.SelectedIndex = 0;

            DBController.Instance.CloseConnection();


        }

        private void rdoNewDSR_CheckedChanged(object sender, EventArgs e)
        {
            ToggleComboBox();
        }

        private void rdoReplaceDSR_CheckedChanged(object sender, EventArgs e)
        {
            ToggleComboBox();
        }

        private void ToggleComboBox()
        {
            if (rdoNewDSR.Checked == true)
            {
                lblReplaceDSR.Visible = false;
                cmbReplaceDSR.Visible = false;
            }
            else
            {
                lblReplaceDSR.Visible = true;
                cmbReplaceDSR.Visible = true;
            }
        }

        private void cmbNewDSR_SelectedIndexChanged(object sender, EventArgs e)
        {
            int searchDSRID = 0;
            if (cmbNewDSR.SelectedIndex != 0)
            {
                searchDSRID = _DMSNames[cmbNewDSR.SelectedIndex - 1].DSRID;
            }
            else
            {
                searchDSRID = -1;
            }
            

            dgvDMSRoute.Rows.Clear();

            oDMSRoutes = new DMSRoutes();
            DBController.Instance.OpenNewConnection();
            oDMSRoutes.RefreshByDSRID(searchDSRID);
            this.Text = "DMS CSR Route | Total: " + "[" + oDMSRoutes.Count + "]";

            foreach (DMSRoute oDMSRoute in oDMSRoutes)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvDMSRoute);
                oRow.Cells[0].Value = oDMSRoute.RouteCode.ToString();
                oRow.Cells[1].Value = oDMSRoute.RouteName.ToString();
                oRow.Cells[2].Value = oDMSRoute.DSRMobileNo.ToString();
                oRow.Cells[3].Value = oDMSRoute.Designation.ToString();
                oRow.Cells[5].Value = oDMSRoute.RouteID.ToString();
                oRow.Cells[4].Value = true;
                dgvDMSRoute.Rows.Add(oRow);
            }

        }

        private void LoadDataGridView()
        {
            dgvDMSRoute.Rows.Clear();

            oDMSRoutes = new DMSRoutes();
            DBController.Instance.OpenNewConnection();
            oDMSRoutes.RefreshByCustomerID(ctlCustomer1.SelectedCustomer.CustomerID);
            //oDMSRoutes.RefreshByDSRID(_DMSNames[cmbNewDSR.SelectedIndex - 1].DSRID);
            this.Text = "DMS CSR Route | Total: " + "[" + oDMSRoutes.Count + "]";

            foreach (DMSRoute oDMSRoute in oDMSRoutes)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvDMSRoute);
                oRow.Cells[0].Value = oDMSRoute.RouteCode.ToString();
                oRow.Cells[1].Value = oDMSRoute.RouteName.ToString();
                oRow.Cells[2].Value = oDMSRoute.DSRMobileNo.ToString();
                oRow.Cells[3].Value = oDMSRoute.Designation.ToString();
                oRow.Cells[5].Value = oDMSRoute.RouteID.ToString();
                oRow.Cells[4].Value = true;
                dgvDMSRoute.Rows.Add(oRow);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                this.Close();
            }

        }
        private bool validateUIInput()
        {
            if (cmbNewDSR.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select New DSR", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (rdoReplaceDSR.Checked == true)
            {
                if (cmbReplaceDSR.SelectedIndex == 0)
                {
                    MessageBox.Show("Please Select Replace DSR", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
        }
        public void Save()
        {
            InsertDMSDSR();
            if (rdoReplaceDSR.Checked == true && cmbReplaceDSR.SelectedIndex != 0)
            {
                DeleteDMSDSR();
            }
            UpdateDMSRoute();

        }

        private void InsertDMSDSR()
        {
            DMSDSR _oDMSDSR = new DMSDSR();
            _oDMSDSR.DistributorID = ctlCustomer1.SelectedCustomer.CustomerID;
            _oDMSDSR.DSRCode = _DMSNames[cmbNewDSR.SelectedIndex - 1].DSRCode;
            _oDMSDSR.DSRName = _DMSNames[cmbNewDSR.SelectedIndex - 1].DSRName;
            _oDMSDSR.DSRMobile = _DMSNames[cmbNewDSR.SelectedIndex - 1].DSRMobile;
            _oDMSDSR.Isactive = 1;
            DBController.Instance.BeginNewTransaction();
            _oDMSDSR.Add();
            DBController.Instance.CommitTran();
        }
        private void UpdateDMSRoute()
        {
            int countCheckedDSRRoute = 0;
            int countUncheckedDSRRoute = 0;
            DMSRoute oDMSRoute = new DMSRoute();
            DBController.Instance.OpenNewConnection();
            foreach (DataGridViewRow oItemRow in dgvDMSRoute.Rows)
            {

                if (Convert.ToBoolean(oItemRow.Cells[4].Value))
                {
                    oDMSRoute.RouteID = int.Parse(oItemRow.Cells[5].Value.ToString());
                    oDMSRoute.DSRID = _DMSNames[cmbNewDSR.SelectedIndex - 1].DSRID;
                    countCheckedDSRRoute++;

                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        oDMSRoute.EditDMSRouteByRouteIDAndDSRID(oDMSRoute.RouteID, oDMSRoute.DSRID);
                        DBController.Instance.CommitTran();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                }
                else
                {
                    countUncheckedDSRRoute++;
                }

            }

            if (countCheckedDSRRoute + countUncheckedDSRRoute == dgvDMSRoute.Rows.Count)
            {
                MessageBox.Show("You Have Successfully Update DSR Route", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteDMSDSR()
        {
            DMSDSR _oDMSDSR = new DMSDSR();
            _oDMSDSR.DSRID = _ReplaceDMSNames[cmbNewDSR.SelectedIndex - 1].DSRID;
            DBController.Instance.BeginNewTransaction();
            _oDMSDSR.Delete();
            DBController.Instance.CommitTran();
        }
        private void cmbReplaceDSR_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmDMSDSRRoute_Load(object sender, EventArgs e)
        {

        }

        private void ctlCustomer1_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDMSRoute_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



    }
}
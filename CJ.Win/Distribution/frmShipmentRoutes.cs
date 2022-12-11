using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.Distribution;

namespace CJ.Win.Distribution
{
    public partial class frmShipmentRoutes : Form
    {
        ShipmentMapRoutes _oShipmentMapRoutes;
        ShipmentMapRoute _oShipmentMapRoute;
        public frmShipmentRoutes()
        {
            InitializeComponent();
        }

        private void frmShipmentRoutes_Load(object sender, EventArgs e)
        {
            DataLoadControlUnMap();
            DataLoadControlMap();
        }

        private void DataLoadControlMap()
        {
            _oShipmentMapRoute = new ShipmentMapRoute();
            _oShipmentMapRoutes = new ShipmentMapRoutes();
            lvwRouteMapping.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oShipmentMapRoutes.RefreshMapRoute(txtCompanyU.Text,txtTTypeU.Text,txtCustomerIdU.Text,txtCustomerNameU.Text,txtRouteIdU.Text);
            lblTotalMapping.Text = "Total " + "=" + _oShipmentMapRoutes.Count + "";
            foreach (ShipmentMapRoute oShipmentMapRoute in _oShipmentMapRoutes)
            {
                ListViewItem oItem = lvwRouteMapping.Items.Add(oShipmentMapRoute.Comapany.ToString());
                oItem.SubItems.Add(oShipmentMapRoute.CustomerCode.ToString());
                oItem.SubItems.Add(oShipmentMapRoute.CustomerName.ToString());
                oItem.SubItems.Add(oShipmentMapRoute.TType.ToString());
                oItem.SubItems.Add(oShipmentMapRoute.RouteId.ToString());
                oItem.Tag = oShipmentMapRoute;
            }
        }

        private void DataLoadControlUnMap()
        {
            _oShipmentMapRoutes = new ShipmentMapRoutes();
            lvwRouteNonMapping.Items.Clear();
            DBController.Instance.OpenNewConnection();

            int nDestinationID = 0;
            //nDestinationID = Convert.ToInt32(txtDistributionId.Text);
            _oShipmentMapRoutes.NonMapRoute(txtCompany.Text,txtTType.Text,txtCustomerId.Text,txtCustomerName.Text);
            lblTotalAll.Text = "Total " + "=" + _oShipmentMapRoutes.Count + "";
            foreach (ShipmentMapRoute _oShipmentMapRoute in _oShipmentMapRoutes)
            {
                ListViewItem oItem = lvwRouteNonMapping.Items.Add(_oShipmentMapRoute.Comapany.ToString());
                oItem.SubItems.Add(_oShipmentMapRoute.TType.ToString());
                oItem.SubItems.Add(_oShipmentMapRoute.CustomerCode.ToString());
                oItem.SubItems.Add(_oShipmentMapRoute.CustomerName.ToString());
                //oItem.SubItems.Add(_oShipmentMapRoute.RouteId.ToString());
                oItem.Tag = _oShipmentMapRoute;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lvwRouteNonMapping.SelectedItems.Count != 0)
            {
                ShipmentMapRoute _oShipmentMapRoute = (ShipmentMapRoute)lvwRouteNonMapping.SelectedItems[0].Tag;
                frmShipmentRoute oForm = new frmShipmentRoute();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.MinimizeBox = false;
                oForm.Text = "Add Customer Mapping";
                oForm.ShowDialogNonMapRoute(_oShipmentMapRoute);
                DataLoadControlUnMap();
                DataLoadControlMap();
            }
            else
            {
                MessageBox.Show("Select a Item from Unmap portion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCompany_TextChanged(object sender, EventArgs e)
        {
            DataLoadControlUnMap();
        }

        private void txtCustomerId_TextChanged(object sender, EventArgs e)
        {
            DataLoadControlUnMap();
        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            DataLoadControlUnMap();
        }

        private void txtTType_TextChanged(object sender, EventArgs e)
        {
            DataLoadControlUnMap();
        }

        private void txtCompanyU_TextChanged(object sender, EventArgs e)
        {
            DataLoadControlMap();
        }

        private void txtTTypeU_TextChanged(object sender, EventArgs e)
        {
            DataLoadControlMap();
        }

        private void txtCustomerIdU_TextChanged(object sender, EventArgs e)
        {
            DataLoadControlMap();
        }

        private void txtCustomerNameU_TextChanged(object sender, EventArgs e)
        {
            DataLoadControlMap();
        }

        private void txtRouteIdU_TextChanged(object sender, EventArgs e)
        {
            DataLoadControlMap();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwRouteMapping.SelectedItems.Count != 0)
            {
                ShipmentMapRoute _oShipmentMapRoute = (ShipmentMapRoute)lvwRouteMapping.SelectedItems[0].Tag;

                if (MessageBox.Show("Do you want to Delete: " + _oShipmentMapRoute.RouteId + "?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    try
                    {
                        DBController.Instance.BeginNewTransaction();

                        _oShipmentMapRoute.ShipmentRouteID = _oShipmentMapRoute.ShipmentRouteID;
                        _oShipmentMapRoute.Delete();

                        DBController.Instance.CommitTran();
                        MessageBox.Show("You Have Successfully Delete The Transaction : " + _oShipmentMapRoute.RouteId, "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataLoadControlMap();
                        DataLoadControlUnMap();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }

                }
            }
            else
            {
                MessageBox.Show("Select a Item from Map portion.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
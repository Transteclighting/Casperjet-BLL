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
    public partial class frmDMSRoutes : Form
    {
        DMSRoutes _oDMSRoutes;
        DMSDSR oDMSDSR;
        Customer oCustomer;
        public frmDMSRoutes()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmDMSRoute ofrom = new frmDMSRoute();
            ofrom.ShowDialog();
            DataLoadControl();
        }

        private void frmDMSRoutes_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void DataLoadControl()
        {
            DMSRoutes oDMSRoutes = new DMSRoutes();
            lvwRoutes.Items.Clear();

            DBController.Instance.OpenNewConnection();
            oDMSRoutes.Refresh(txtCustomerName.Text);


            foreach (DMSRoute oDMSRoute in oDMSRoutes)
            {
                ListViewItem oItem = lvwRoutes.Items.Add(oDMSRoute.CustomerName);
                oItem.SubItems.Add(oDMSRoute.RouteName);
                oItem.SubItems.Add(oDMSRoute.RouteType);
                oItem.SubItems.Add(oDMSRoute.DsrName);
                oItem.SubItems.Add(oDMSRoute.Designation);
                oItem.SubItems.Add(oDMSRoute.DeliveryDay);
                oItem.SubItems.Add(oDMSRoute.OrderType);
                oItem.SubItems.Add(oDMSRoute.VisitDay);
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.VisitFrequency), oDMSRoute.VisitFrequency));
                oItem.SubItems.Add(oDMSRoute.GeoType);
                oItem.SubItems.Add(oDMSRoute.RAName);
                oItem.SubItems.Add(oDMSRoute.RAMobileNo);
                oItem.SubItems.Add(oDMSRoute.DriverName);
                oItem.SubItems.Add(oDMSRoute.DriverMobNo);
                oItem.SubItems.Add(oDMSRoute.VehicleNo);


                oItem.Tag = oDMSRoute;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

            if (lvwRoutes.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row to Edit");
                return;
            }

            DMSRoute oDMSRoute = (DMSRoute)lvwRoutes.SelectedItems[0].Tag;

            frmDMSRoute ofrom = new frmDMSRoute();
            ofrom.ShowDialog(oDMSRoute);
            DataLoadControl();
        }

        private void lvwRoutes_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }

    }
}
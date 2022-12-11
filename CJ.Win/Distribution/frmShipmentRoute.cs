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
    public partial class frmShipmentRoute : Form
    {
        ShipmentMapRoute _oShipmentMapRoute;
        public frmShipmentRoute()
        {
            InitializeComponent();
        }

        public void ShowDialogNonMap(ShipmentMapRoute _oShipmentMapRoute)
        {
 
        }

        public void ShowDialogNonMapRoute(ShipmentMapRoute oShipmentMapRoute)
        {
            this.Tag = oShipmentMapRoute;
            lblCompany.Text = oShipmentMapRoute.Comapany;
            lblCode.Text = oShipmentMapRoute.CustomerCode;
            lblName.Text = oShipmentMapRoute.CustomerName;
            lblTType.Text = oShipmentMapRoute.TType;
            lblDestinationID.Text = Convert.ToString(oShipmentMapRoute.DestinationId);
            this.MaximizeBox = true;
            this.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtRouteId.Text != null)
            {
                Save();
                this.Close();
            }
        }

        private void Save()
        {
            _oShipmentMapRoute = new ShipmentMapRoute();
            _oShipmentMapRoute.Comapany = lblCompany.Text;
            _oShipmentMapRoute.TType = lblTType.Text;
            _oShipmentMapRoute.DestinationId = Convert.ToInt32(lblDestinationID.Text);
            _oShipmentMapRoute.RouteId = Convert.ToInt32(txtRouteId.Text);
            _oShipmentMapRoute.Add();
        }
    }
}
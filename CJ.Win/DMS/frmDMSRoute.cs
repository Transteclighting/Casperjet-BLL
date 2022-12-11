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
    public partial class frmDMSRoute : Form
    {
        private Customers oCustomers;
        private Customer _oCustomer;
        DMSRoutes _oDMSRoutes;
        DMSRoutes oDMSRoutes;
        DMSDSRs _oDMSDSRs;
        DMSDSR _oDMSDSR;
        DMSRoute oDMSRoute;
        DMSOutlets _oDMSOutlets;
        DMSOutlet _oDMSOutlet;
        public frmDMSRoute()
        {
            InitializeComponent();
        }
        public void ShowDialog(DMSRoute oDMSRoute)
        {

            this.Tag = oDMSRoute;
            LoadCombos();
            ctlCustomer1.txtCode.Text = oDMSRoute.CustomerCode;
            txtRACode.Text = oDMSRoute.RACode.ToString();
            txtDriverName.Text = oDMSRoute.DriverName;
            txtRAName.Text = oDMSRoute.RAName;
            txtDriverCode.Text = oDMSRoute.DriverCode.ToString();
            txtRAMobileNo.Text = oDMSRoute.RAMobileNo;
            txtDriverPhNo.Text = oDMSRoute.DriverMobNo;
            txtDSRPhNo.Text = oDMSRoute.DSRMobileNo;
            txtVehicleNo.Text = oDMSRoute.VehicleNo;
            txtRouteName.Text = oDMSRoute.RouteName;

            if (oDMSRoute.IsActive == 1)
            {
                cbxIsActive.Checked = true;
            }
            else cbxIsActive.Checked = false;

            
            //cmbRouteName.Text = oDMSRoute.RouteName;
            cmbDSRName.Text = oDMSRoute.DsrName;
            cmbRouteType.Text = oDMSRoute.RouteType;
            cmbOrder.Text= oDMSRoute.OrderType;
            cmbGeotype.Text = oDMSRoute.GeoType;
            cmbDesignation.Text = oDMSRoute.Designation;
            cmbDay.Text = oDMSRoute.DeliveryDay;
            cmbVisitDay.Text = oDMSRoute.VisitDay;
            cmbOutlet.Text = oDMSRoute.OutletName;
            //int nVisitFrequency = 0;
            //nVisitFrequency = cmbVisitF.SelectedIndex-1;

            //nVisitFrequency = oDMSRoute.VisitFrequency;
            cmbVisitF.SelectedIndex = oDMSRoute.VisitFrequency;
            
            this.ShowDialog();
        }

        private void LoadCombos()
        {

            //DeliveryDay
            cmbDay.Items.Clear();
            cmbDay.Items.Add("--Select Delivery Day--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.DayID)))
            {
                cmbDay.Items.Add(Enum.GetName(typeof(Dictionary.DayID), GetEnum));
            }
            cmbDay.SelectedIndex = 0;
            //RouteType
            cmbRouteType.Items.Clear();
            cmbRouteType.Items.Add("--Select Route Type--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.RouteType)))
            {
                cmbRouteType.Items.Add(Enum.GetName(typeof(Dictionary.RouteType), GetEnum));
            }
            cmbRouteType.SelectedIndex = 0;

            //OrderType
            cmbOrder.Items.Clear();
            cmbOrder.Items.Add("--Select Order Type--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.DmsOrderType)))
            {
                cmbOrder.Items.Add(Enum.GetName(typeof(Dictionary.DmsOrderType), GetEnum));
            }
            cmbOrder.SelectedIndex = 0;

            //VisitD
            cmbVisitDay.Items.Clear();
            cmbVisitDay.Items.Add("--Select Visit Day--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.VisitdayID)))
            {
                cmbVisitDay.Items.Add(Enum.GetName(typeof(Dictionary.VisitdayID), GetEnum));
            }
            cmbVisitDay.SelectedIndex = 0;

            //Designation
            cmbDesignation.Items.Clear();
            cmbDesignation.Items.Add("--Select Designation--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.Designation)))
            {
                cmbDesignation.Items.Add(Enum.GetName(typeof(Dictionary.Designation), GetEnum));
            }
            cmbDesignation.SelectedIndex = 0;

            //Geotype
            cmbGeotype.Items.Clear();
            cmbGeotype.Items.Add("--Select Geo Type--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.GeoType)))
            {
                cmbGeotype.Items.Add(Enum.GetName(typeof(Dictionary.GeoType), GetEnum));
            }
            cmbGeotype.SelectedIndex = 0;

            //VisitF
            cmbVisitF.Items.Clear();
            cmbVisitF.Items.Add("--Select Visit Frequency--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.VisitFrequency)))
            {
                cmbVisitF.Items.Add(Enum.GetName(typeof(Dictionary.VisitFrequency), GetEnum));
            }
            cmbVisitF.SelectedIndex = 0;
        }

        private void cmbRouteName_SelectedIndexChanged(object sender, EventArgs e)
        {

            //if (cmbRouteName.SelectedIndex > 0)
            //{
            //    _oDMSRoutes = new DMSRoutes();
            //    _oDMSRoutes.RefreshRouteWise(oDMSRoutes[cmbRouteName.SelectedIndex - 1].RouteID);
            //    cmbDay.Items.Clear();

            //    if (_oDMSRoutes.Count > 0)
            //    {
            //        cmbDay.Items.Add("--Select Delivery Day--");
            //        foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.DayID)))
            //        {
            //            cmbDay.Items.Add(Enum.GetName(typeof(Dictionary.DayID), GetEnum));
            //        }
            //        cmbDay.SelectedIndex = 0;
            //    }

            //}
            //if (cmbRouteName.SelectedIndex > 0)
            //{
            //    _oDMSRoutes = new DMSRoutes();
            //    _oDMSRoutes.RefreshRouteWise(oDMSRoutes[cmbRouteName.SelectedIndex - 1].RouteID);
            //    cmbRouteType.Items.Clear();

            //    if (_oDMSRoutes.Count > 0)
            //    {
            //        cmbRouteType.Items.Add("--Select Route Type--");
            //        foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.RouteType)))
            //        {
            //            cmbRouteType.Items.Add(Enum.GetName(typeof(Dictionary.RouteType), GetEnum));
            //        }
            //        cmbRouteType.SelectedIndex = 0;
            //    }

            //}
            //if (cmbRouteName.SelectedIndex > 0)
            //{
            //    _oDMSRoutes = new DMSRoutes();
            //    _oDMSRoutes.RefreshRouteWise(oDMSRoutes[cmbRouteName.SelectedIndex - 1].RouteID);
            //    cmbOrder.Items.Clear();

            //    if (_oDMSRoutes.Count > 0)
            //    {
            //        cmbOrder.Items.Add("--Select Order Type--");
            //        foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.DmsOrderType)))
            //        {
            //            cmbOrder.Items.Add(Enum.GetName(typeof(Dictionary.DmsOrderType), GetEnum));
            //        }
            //        cmbOrder.SelectedIndex = 0;
            //    }

            //}
            //if (cmbRouteName.SelectedIndex > 0)
            //{
            //    _oDMSRoutes = new DMSRoutes();
            //    _oDMSRoutes.RefreshRouteWise(oDMSRoutes[cmbRouteName.SelectedIndex - 1].RouteID);
            //    cmbDesignation.Items.Clear();

            //    if (_oDMSRoutes.Count > 0)
            //    {
            //        cmbDesignation.Items.Add("--Select Designation--");
            //        foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.Designation)))
            //        {
            //            cmbDesignation.Items.Add(Enum.GetName(typeof(Dictionary.Designation), GetEnum));
            //        }
            //        cmbDesignation.SelectedIndex = 0;
            //    }

            //}
            
            //if (cmbRouteName.SelectedIndex > 0)
            //{
            //    _oDMSRoutes = new DMSRoutes();
            //    _oDMSRoutes.RefreshRouteWise(oDMSRoutes[cmbRouteName.SelectedIndex - 1].RouteID);
            //    cmbVisitDay.Items.Clear();

            //    if (_oDMSRoutes.Count > 0)
            //    {
            //        cmbVisitDay.Items.Add("--Select Visit Day--");
            //        foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.VisitdayID)))
            //        {
            //            cmbVisitDay.Items.Add(Enum.GetName(typeof(Dictionary.VisitdayID), GetEnum));
            //        }
            //        cmbVisitDay.SelectedIndex = 0;
            //    }

            //}
            //if (cmbRouteName.SelectedIndex > 0)
            //{
            //    _oDMSRoutes = new DMSRoutes();
            //    _oDMSRoutes.RefreshRouteWise(oDMSRoutes[cmbRouteName.SelectedIndex - 1].RouteID);
            //    cmbGeotype.Items.Clear();

            //    if (_oDMSRoutes.Count > 0)
            //    {
            //        cmbGeotype.Items.Add("--Select Geo Type--");
            //        foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.GeoType)))
            //        {
            //            cmbGeotype.Items.Add(Enum.GetName(typeof(Dictionary.GeoType), GetEnum));
            //        }
            //        cmbGeotype.SelectedIndex = 0;
            //    }

            //}
            //if (cmbRouteName.SelectedIndex > 0)
            //{
            //    _oDMSRoutes = new DMSRoutes();
            //    _oDMSRoutes.RefreshRouteWise(oDMSRoutes[cmbRouteName.SelectedIndex - 1].RouteID);
            //    cmbVisitF.Items.Clear();

            //    if (_oDMSRoutes.Count > 0)
            //    {
            //        cmbVisitF.Items.Add("--Select Visit Frequency--");
            //        foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.VisitFrequency)))
            //        {
            //            cmbVisitF.Items.Add(Enum.GetName(typeof(Dictionary.VisitFrequency), GetEnum));
            //        }
            //        cmbVisitF.SelectedIndex = 0;
            //    }

            //}
        }

        private void frmDMSRoute_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                LoadCombos();
            }
            
        }

        private void button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SETUI(Customer _oCustomer)
        {
            _oDMSRoutes = new DMSRoutes();
            _oDMSDSRs = new DMSDSRs();
            _oDMSOutlets = new DMSOutlets();
            

            _oDMSRoutes.RefreshBYRouteName(_oCustomer.CustomerID);
            _oDMSDSRs.Refresh(_oCustomer.CustomerID);
            _oDMSOutlets.Refresh(_oCustomer.CustomerID);
            //if (_oCustomer.CustomerID != null)
            //{
            //    cmbRouteName.Items.Clear();
            //    cmbRouteName.Items.Add("<All>");
            //    foreach (DMSRoute oDMSRoute in _oDMSRoutes)
            //    {
            //      cmbRouteName.Items.Add(oDMSRoute.RouteName);
            //    }
            //    cmbRouteName.SelectedIndex = 0;
                
            //}
        
            if (_oCustomer.CustomerID != null)
            {
                cmbDSRName.Items.Clear();
                cmbDSRName.Items.Add("<All>");
                foreach (DMSDSR oDMSDSR in _oDMSDSRs)
                {
                    cmbDSRName.Items.Add(oDMSDSR.DSRName);
                }
                cmbDSRName.SelectedIndex = 0;

            }
            if (_oCustomer.CustomerID != null)
            {
                cmbOutlet.Items.Clear();
                cmbOutlet.Items.Add("<All>");
                foreach (DMSOutlet oDMSOutlet in _oDMSOutlets)
                {
                    cmbOutlet.Items.Add(oDMSOutlet.OutletName);
                }
                cmbOutlet.SelectedIndex = 0;

            }
            oDMSRoutes = new DMSRoutes();
            oDMSRoutes = _oDMSRoutes;
        
        }
        private void ctlCustomer1_ChangeSelection(object sender, EventArgs e)
        {
            if (ctlCustomer1.SelectedCustomer != null && ctlCustomer1.txtCode.Text != "")
            {
                _oCustomer = new Customer();
                _oCustomer.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
                //oDMSRoute.DistributorID = ctlCustomer1.SelectedCustomer.CustomerID;
                _oCustomer.refresh();
                SETUI(_oCustomer);

            }
        }

        private bool validateUIInput()
        {
            #region Input Information Validation
            if (txtRouteName.Text == "")
            {
                MessageBox.Show("Please Write Route Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRouteName.Focus();
                return false;
            }
            if (cmbDSRName.Text == "<All>")
            {
                MessageBox.Show("Please Select DSR Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDSRName.Focus();
                return false;
            }
            if (cmbDay.Text == "--Select Delivery Day--")
            {
                MessageBox.Show("Please Select Day", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDay.Focus();
                return false;
            }
            if (cmbRouteType.Text == "--Select Route Type--")
            {
                MessageBox.Show("Please Select Route Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbRouteType.Focus();
                return false;
            }
            if (cmbOrder.Text == "--Select Order Type--")
            {
                MessageBox.Show("Please Select Order Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbOrder.Focus();
                return false;
            }
            if (cmbDesignation.Text == "--Select Designation--")
            {
                MessageBox.Show("Please Select Designation", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbDesignation.Focus();
                return false;
            }
            if (cmbVisitDay.Text == "--Select Visit Day--")
            {
                MessageBox.Show("Please Select Visit Day", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbVisitDay.Focus();
                return false;
            }
            if (cmbGeotype.Text == "--Select Geo Type--")
            {
                MessageBox.Show("Please Select Geo Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbGeotype.Focus();
                return false;
            }
            if (cmbVisitF.Text == "--Select Visit Frequency--")
            {
                MessageBox.Show("Please Select Visit Frequency", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbVisitF.Focus();
                return false;
            }
            if (txtDSRPhNo.Text == "")
            {
                MessageBox.Show("Please enter DSR Phone No. ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDSRPhNo.Focus();
                return false;
            }
            if (txtRACode.Text == "")
            {
                MessageBox.Show("Please enter Code ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRACode.Focus();
                return false;
            }

            if (txtRAName.Text == "")
            {
                MessageBox.Show("Please enter Name ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRAName.Focus();
                return false;
            }
            if (txtRAMobileNo.Text == "")
            {
                MessageBox.Show("Please enter RA Phone No. ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRAMobileNo.Focus();
                return false;
            }
            if (txtDriverCode.Text == "")
            {
                MessageBox.Show("Please enter Driver Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDriverCode.Focus();
                return false;
            }

            if (txtDriverName.Text == "")
            {
                MessageBox.Show("Please enter Driver Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDriverName.Focus();
                return false;
            }
            if (txtDriverPhNo.Text == "")
            {
                MessageBox.Show("Please enter Driver Phone No.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDriverPhNo.Focus();
                return false;
            }
            if (txtVehicleNo.Text == "")
            {
                MessageBox.Show("Please Enter Vehicle No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVehicleNo.Focus();
                return false;
            }

            #endregion

            return true;
        }

        private void Save()
        {
            if (this.Tag == null)
            {
                DMSRoute oDMSRoute = new DMSRoute();

                oDMSRoute.DistributorID = ctlCustomer1.SelectedCustomer.CustomerID;
                oDMSRoute.DSRMobileNo = txtDSRPhNo.Text; 
                oDMSRoute.RACode = Convert.ToInt32(txtRACode.Text);
                oDMSRoute.RAMobileNo = txtRAMobileNo.Text;
                oDMSRoute.RAName = txtRAName.Text;
                oDMSRoute.DriverCode = Convert.ToInt32(txtDriverCode.Text);
                oDMSRoute.DriverMobNo = txtDriverPhNo.Text;
                oDMSRoute.DriverName = txtDriverName.Text;
                oDMSRoute.VehicleNo = txtVehicleNo.Text;
                oDMSRoute.RouteName = txtRouteName.Text;
                oDMSRoute.DSRID = _oDMSDSRs[cmbDSRName.SelectedIndex - 1].DSRID;
                oDMSRoute.DeliveryDay = cmbDay.Text;
                oDMSRoute.DayID = cmbDay.SelectedIndex;
                oDMSRoute.Designation = cmbDesignation.Text;
                oDMSRoute.VisitDay = cmbVisitDay.Text;
                oDMSRoute.VisitFrequency =cmbVisitF.SelectedIndex;
                oDMSRoute.RouteType = cmbRouteType.Text;

                oDMSRoute.RouteTypeID = cmbRouteType.SelectedIndex;

                if(oDMSRoute.RouteTypeID==1)
                {
                 oDMSRoute.RouteType = "Non Cluster";
                }
                else if (oDMSRoute.RouteTypeID==2)
                {
                 oDMSRoute.RouteType = "Cluster";
                }
                else if (oDMSRoute.RouteTypeID==3)
                {
                 oDMSRoute.RouteType = "Institution";
                }
                else if (oDMSRoute.RouteTypeID == 4)
                {
                    oDMSRoute.RouteType = "Thana";
                }
                oDMSRoute.OrderType = cmbOrder.Text;
                oDMSRoute.GeoType = cmbGeotype.Text;
                

                if (cbxIsActive.Checked == true)
                {
                    oDMSRoute.IsActive = 1;
                }
                else oDMSRoute.IsActive = 0;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oDMSRoute.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction : " + oDMSRoute.RouteCode, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                DMSRoute oDMSRoute = (DMSRoute)this.Tag;

                oDMSRoute.DistributorID = ctlCustomer1.SelectedCustomer.CustomerID;
                oDMSRoute.DSRMobileNo = txtDSRPhNo.Text;
                oDMSRoute.RACode = Convert.ToInt32(txtRACode.Text);
                oDMSRoute.RAMobileNo = txtRAMobileNo.Text;
                oDMSRoute.RAName = txtRAName.Text;
                oDMSRoute.DriverCode = Convert.ToInt32(txtDriverCode.Text);
                oDMSRoute.DriverMobNo = txtDriverPhNo.Text;
                oDMSRoute.DriverName = txtDriverName.Text;
                oDMSRoute.VehicleNo = txtVehicleNo.Text;
                oDMSRoute.RouteName = txtRouteName.Text;


                oDMSRoute.DSRID = _oDMSDSRs[cmbDSRName.SelectedIndex - 1].DSRID;
                oDMSRoute.DeliveryDay = cmbDay.Text;
                oDMSRoute.DayID = cmbDay.SelectedIndex;
                oDMSRoute.Designation = cmbDesignation.Text;
                oDMSRoute.VisitDay = cmbVisitDay.Text;
                oDMSRoute.VisitFrequency = cmbVisitF.SelectedIndex;
                oDMSRoute.RouteType = cmbRouteType.Text;
                oDMSRoute.RouteTypeID = cmbRouteType.SelectedIndex;

                if (oDMSRoute.RouteTypeID == 1)
                {
                    oDMSRoute.RouteType = "Non Cluster";
                }
                else if (oDMSRoute.RouteTypeID == 2)
                {
                    oDMSRoute.RouteType = "Cluster";
                }
                else if (oDMSRoute.RouteTypeID == 3)
                {
                    oDMSRoute.RouteType = "Institution";
                }
                else if (oDMSRoute.RouteTypeID == 4)
                {
                    oDMSRoute.RouteType = "Thana";
                }
                oDMSRoute.OrderType = cmbOrder.Text;
                oDMSRoute.GeoType = cmbGeotype.Text;


                if (cbxIsActive.Checked == true)
                {
                    oDMSRoute.IsActive = 1;
                }
                else oDMSRoute.IsActive = 0;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oDMSRoute.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update The DMSRoute : " + oDMSRoute.RouteCode, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }



        private void btnSave_Click(object sender, EventArgs e)
        {

            if (validateUIInput())
            {
                Save();
                this.Close();
            }
            //this.Close();
        }

    }
}
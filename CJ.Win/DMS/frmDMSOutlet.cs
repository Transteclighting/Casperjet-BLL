using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Report;
using CJ.Class;
using CJ.Class.Report;
using CJ.Class.DMS;
using CJ.Report.DMS;

namespace CJ.Win.DMS
{
    public partial class frmDMSOutlet : Form
    {
        DMSUsers _oDMSUsers;
        DMSUser _oDMSUser;
        MarketGroups _oRegion;
        MarketGroups _oArea;
        MarketGroups _oTerritory;
        Brands _oBrands;
        ProductDetails _oASG;
        Products _oProducts;
        Customers _oCustomers;
        Customer _oCustomer;
        ElectricMarket _oElectricMarket;
        ElectricMarkets __oElectricMarkets;
        User oUser;
        Markets _oMarkets;
        public frmDMSOutlet()
        {
            InitializeComponent();
        }
        public void LoadCombo()
        {

            User oUser = new User();
            int nUserID = Utility.UserId;
            DBController.Instance.OpenNewConnection();
            MarketGroups oMarketGroups = new MarketGroups();
            oMarketGroups.GetArea(nUserID);
            cmbArea.Items.Clear();
            foreach (MarketGroup oMarketGroup in oMarketGroups)
            {
                cmbArea.Items.Add(oMarketGroup.MarketGroupDesc);

            }
            cmbArea.SelectedIndex = 0;
            LoadOutletType();



        }
        private void LoadOutletType()
        {

            cmbOutletType.Items.Add("--Select Outlet Type--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.OutletType)))
            {
                cmbOutletType.Items.Add(Enum.GetName(typeof(Dictionary.OutletType), GetEnum));
            }
            cmbOutletType.SelectedIndex = 0;
        }

        private void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            User oUser = new User();
            int nUserID = Utility.UserId;
            int nAreaID = 0;
            DBController.Instance.OpenNewConnection();
            MarketGroups oMarketGroups = new MarketGroups();
            oMarketGroups = new MarketGroups();
            oMarketGroups.GetArea(nUserID);
            if (cmbArea.Text != "All")
            {
                nAreaID = oMarketGroups[cmbArea.SelectedIndex].MarketGroupID;
            }
            else
            {
                nAreaID = -1;
            }
            oMarketGroups.DMSGetTerritory(nAreaID);
            cmbTerritory.Items.Clear();
            foreach (MarketGroup oMarketGroup in oMarketGroups)
            {
                cmbTerritory.Items.Add(oMarketGroup.MarketGroupDesc);

            }
            cmbTerritory.SelectedIndex = 0;
            DBController.Instance.CloseConnection();
        }

        private void cmbTerritory_SelectedIndexChanged(object sender, EventArgs e)
        {
            User oUser = new User();
            int nUserID = Utility.UserId;
            int nTerritoryID = 0;
            int nAreaID = 0;
            DBController.Instance.OpenNewConnection();
            MarketGroups oMarketGroups = new MarketGroups();
            ElectricMarkets oElectricMarkets = new ElectricMarkets();
            oMarketGroups.GetArea(nUserID);
            if (cmbArea.Text != "All")
            {
                nAreaID = oMarketGroups[cmbArea.SelectedIndex].MarketGroupID;
            }
            else
            {
                nAreaID = -1;
            }


            oMarketGroups = new MarketGroups();
            oMarketGroups.DMSGetTerritory(nAreaID);

            if (cmbTerritory.Text != "All")
            {
                nTerritoryID = oMarketGroups[cmbTerritory.SelectedIndex].MarketGroupID;
            }
            else
            {
                nTerritoryID = -1;
            }

            _oCustomers = new Customers();
            _oCustomers.GetCustomersTerritoryWise(nUserID, nTerritoryID);

            cmbCutomer.Items.Clear();
            foreach (Customer oCustomer in _oCustomers)
            {
                cmbCutomer.Items.Add(oCustomer.CustomerName);

            }
            cmbCutomer.SelectedIndex = -1;




            DBController.Instance.CloseConnection();
        }

        private void cmbCutomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            User oUser = new User();
            int nUserID = Utility.UserId;
            int nCustomerID = 0;
            int nTerritoryID = 0;
            int nAreaID = 0;
            string sCustomerCode = null;
            DBController.Instance.OpenNewConnection();

            MarketGroups oMarketGroups = new MarketGroups();


            oMarketGroups.GetArea(nUserID);
            if (cmbArea.Text != "All")
            {
                nAreaID = oMarketGroups[cmbArea.SelectedIndex].MarketGroupID;
            }
            else
            {
                nAreaID = -1;
            }

            oMarketGroups = new MarketGroups();
            oMarketGroups.DMSGetTerritory(nAreaID);
            if (cmbTerritory.Text != "All")
            {
                nTerritoryID = oMarketGroups[cmbTerritory.SelectedIndex].MarketGroupID;
            }
            else
            {
                nTerritoryID = -1;
            }

            Customers _oCustomers = new Customers();
            _oCustomers = new Customers();
            _oCustomers.GetCustomersTerritoryWise(nUserID, nTerritoryID);
            if (cmbCutomer.Text != "All")
            {
                nCustomerID = _oCustomers[cmbCutomer.SelectedIndex].CustomerID;
                sCustomerCode = _oCustomers[cmbCutomer.SelectedIndex].CustomerCode;
            }
            else
            {
                nCustomerID = -1;
            }
            _oCustomers.GetDistrict(nCustomerID);
            cmbDistrict.Items.Clear();
            foreach (Customer oCustomer in _oCustomers)
            {
                cmbDistrict.Items.Add(oCustomer.DistrictName);            

            }
            cmbDistrict.SelectedIndex = -1;


            //ElectricMarkets _oElectricMarkets = new ElectricMarkets();
            //_oElectricMarkets = new ElectricMarkets();
            //_oElectricMarkets.RefreshAll(nCustomerID);
            //cmbMarket.Items.Clear();
            //foreach (ElectricMarket oElectricMarket in _oElectricMarkets)
            //{

            //    cmbMarket.Items.Add(oElectricMarket.MarketName);

            //}
            //cmbMarket.SelectedIndex = -1;

            _oCustomer = new Customer();
            Markets _oMarkets = new Markets();
            _oMarkets.RefreshClusterMkt(nCustomerID);
            _oCustomer.CustomerID = nCustomerID;
            cmbMarket.Items.Clear();

            foreach (Market oMarket in _oMarkets)
            {

                cmbMarket.Items.Add(oMarket.MarketName);

            }
            
            //cmbMarket.SelectedIndex = -1;   Code by Rifat

            if (_oMarkets.Count > 0)
            {
                cmbMarket.SelectedIndex = _oMarkets.Count - 1;
            }
            
            DBController.Instance.CloseConnection();
        }

        private void frmDMSOutlet_Load(object sender, EventArgs e)
        {
            LoadCombo();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();   
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                MessageBox.Show("Outlet Save Successfully");
                 txtOutletName.Text="";

                 txtOutletName.Text = "";
                 txtAdress.Text = "";
                 txtOwner.Text = "";
                 txtTelephone.Text = "";
                 txtMobileNo1.Text = "";
                 txtMobileNo2.Text = "";
                 txtAgreedValue.Text = "";
                 txtTargetSlab.Text = "";
                 txtOptionID.Text=  "";
                 
            }         

        }

        private bool validateUIInput()
        {
            #region Input Information Validation

                       
            

            if (txtAdress.Text == "")
            {
                MessageBox.Show("Please enter Valid Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAdress.Focus();
                return false;
            }

            if (txtOutletName.Text == "")
            {
                MessageBox.Show("Please enter Outlet Name ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOutletName.Focus();
                return false;
            }

            if (txtOwner.Text == "")
            {
                MessageBox.Show("Please enter Owner Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOwner.Focus();
                return false;
            }

            if (txtMobileNo1.Text == "")
            {
                MessageBox.Show("Please enter Mobile No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMobileNo1.Focus();
                return false;
            }

            if (txtAgreedValue.Text == "")
            {
                MessageBox.Show("Please enter Agreed Value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAgreedValue.Focus();
                return false;
            }

            if (txtOptionID.Text == "")
            {
                MessageBox.Show("Please enter Option No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOptionID.Focus();
                return false;
            }

            

            if (cmbOutletType.SelectedIndex <=0 )
            {
                MessageBox.Show("Please Select Outlet Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbOutletType.Focus();
               
                return false;
            }

            




            #endregion

            return true;
        }

        private void Save()
        {
            DBController.Instance.OpenNewConnection();
            String sOutletCode;
            string sDistrictName;
            string sMarketName;
            string sOutletName;
            int nAreaID = 0;
            int nTerritoryID = 0;
            

            ElectricMarket oElectricMarket = new ElectricMarket();

            _oMarkets = new Markets();
            _oMarkets.RefreshClusterMkt(_oCustomer.CustomerID);
            _oCustomers = new Customers();
            _oCustomers.GetDistrict(_oCustomer.CustomerID);
            sDistrictName = _oCustomers[cmbDistrict.SelectedIndex].DistrictName.Substring(0, 3);
            //sMarketName = _oMarkets[cmbMarket.SelectedIndex].MarketName.Substring(0, 3);
            sMarketName =Convert.ToString( _oMarkets[cmbMarket.SelectedIndex].MarketID);
            sOutletCode = sDistrictName + "-" + sMarketName + "-";
            MarketGroups oMarketGroups = new MarketGroups();
            ElectricMarkets oElectricMarkets = new ElectricMarkets();
            int nUserID = Utility.UserId;
            oMarketGroups.GetArea(nUserID);
            if (cmbArea.Text != "All")
            {
                nAreaID = oMarketGroups[cmbArea.SelectedIndex].MarketGroupID;
            }
            else
            {
                nAreaID = -1;
            }


            oMarketGroups = new MarketGroups();
            oMarketGroups.DMSGetTerritory(nAreaID);

            if (cmbTerritory.Text != "All")
            {
                nTerritoryID = oMarketGroups[cmbTerritory.SelectedIndex].MarketGroupID;
            }
            else
            {
                nTerritoryID = -1;
            }

            _oCustomers = new Customers();
            _oCustomers.GetCustomersTerritoryWise(nUserID, nTerritoryID);



            oElectricMarket.CustomerID = _oCustomers[cmbCutomer.SelectedIndex].CustomerID;
            // oElectricMarket.DistrictID = _oCustomers[cmbDistrict.SelectedIndex].DistrictID;
            oElectricMarket.OutletName = txtOutletName.Text;
            oElectricMarket.OutletCode = sOutletCode;
            oElectricMarket.Address = txtAdress.Text;           
            oElectricMarket.Owner = txtOwner.Text;
            oElectricMarket.Telephone = txtTelephone.Text;
            oElectricMarket.Mobile1 = txtMobileNo1.Text;
            oElectricMarket.Mobile2 = txtMobileNo2.Text;
            oElectricMarket.MarketID = Convert.ToInt32(_oMarkets[cmbMarket.SelectedIndex].MarketID);
            
            oElectricMarket.RouteID = 0;
            oElectricMarket.Balance = 0;
            oElectricMarket.OutletCatagory = 2;       

            oElectricMarket.OutletSubCatagory = cmbOutletType.SelectedIndex;           
                      
            oElectricMarket.AgreedSlab =Convert.ToInt32(txtTargetSlab.Text);
            oElectricMarket.OptionID = Convert.ToInt16(txtOptionID.Text);
            oElectricMarket.AgreedValue = Convert.ToDouble(txtAgreedValue.Text);

            oElectricMarket.AddOutlet();

            DBController.Instance.CloseConnection();
        
        }

        private void txtTargetAmount_TextChanged(object sender, EventArgs e)
        {

        }
          

       

        

       

       
    }
}
using CJ.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CJ.Win.DMS
{
    public partial class frmOutletUpdate : Form
    {
        int OutletID;
        public frmOutletUpdate(int RetailID)
        {
            InitializeComponent();
            OutletID = RetailID;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {

        }
        private void frmOutletUpdate_Load(object sender, EventArgs e)
        {
            LoadCombo();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            txtRetailID.Text = OutletID.ToString();
            string str = ConfigurationManager.AppSettings["ConnectionString"];
            string Sql = @"select 
            a.DistrictName,a.ThanaName,MarketName,a.RouteID,RouteName	,a.CustomerID,CustomerName,RetailName,RetailAddress,ProprietorName,RetailType,
            RetailTypeID,RetailTypeShort,Mobile01,Mobile02,Mobile03,Latitude,Longitude,SlabOutlet,RetailGroupID	
            from t_DMSClusterOutlet a, v_CustomerDetails b ,t_DMSRoute c
            where a.CustomerID=b.CustomerID and a.RouteID=c.RouteID and a.IsActive=1 and RetailID= " + OutletID + "";

            cmd.CommandText = Sql;
            cmd.CommandType = CommandType.Text;
            IDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                txtOutletName.Text= reader["RetailName"].ToString();
                txtAdress.Text= reader["RetailAddress"].ToString();
                txtOwner.Text= reader["ProprietorName"].ToString();
                txtMobileNo1.Text= reader["Mobile01"].ToString();
                txtmobile2.Text= reader["Mobile02"].ToString();
                txtmobile3.Text= reader["Mobile03"].ToString();
                txtRetailtypeshort.Text= reader["RetailTypeShort"].ToString();
                cmbRetailType.Text= reader["RetailType"].ToString();
                cmbRetailType.SelectedValue= reader["RetailTypeID"].ToString();
                cmbdistric.Text= reader["DistrictName"].ToString();
                cmbThana.Text= reader["ThanaName"].ToString();
                txtMarket.Text= reader["MarketName"].ToString();
                cmbCustomer.Text = reader["CustomerName"].ToString();
                cmbBeat.SelectedText = reader["RouteName"].ToString();
                cmbBeat.SelectedValue = reader["RouteID"].ToString();
                cmbCustomer.SelectedValue = reader["CustomerID"].ToString();
                cmbGroupID.SelectedText = reader["RetailGroupID"].ToString();
                cmbSlab.SelectedText = reader["SlabOutlet"].ToString();


            }
        }
        private void LoadCombo()
        {
            loadRetailTypeandID();
            loadCustomer();
            loadRoute();
            loadDistrict();
            loadThana();
            loadMarket();
        }
        private void loadRetailTypeandID()
        {
            OleDbConnection conn = new OleDbConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            try
            {
                string query = "Select Distinct RetailTypeID,RetailType from t_DMSClusterOutlet order by RetailTypeID";
                OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
                conn.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "RType");
                cmbRetailType.DisplayMember = "RetailType";
                cmbRetailType.ValueMember = "RetailTypeID";
                cmbRetailType.DataSource = ds.Tables["RType"];
            }
            catch (Exception ex)
            {
                // write exception info to log or anything else
                MessageBox.Show(ex.ToString());
            }
        }
        private void loadRoute()
        {
            OleDbConnection conn = new OleDbConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            try
            {
                string query = "select RouteID,RouteName from t_DMSRoute";
                OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
                conn.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "Route");
                cmbBeat.DisplayMember = "RouteName";
                cmbBeat.ValueMember = "RouteID";
                cmbBeat.DataSource = ds.Tables["Route"];
            }
            catch (Exception ex)
            {
                // write exception info to log or anything else
                MessageBox.Show(ex.ToString());
            }
        }
        private void loadCustomer()
        {
            OleDbConnection conn = new OleDbConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            try
            {
                string query = "select distinct CustomerID,CustomerName from v_CustomerDetails where IsActive=1";
                OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
                conn.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "Customer");
                cmbCustomer.DisplayMember = "CustomerName";
                cmbCustomer.ValueMember = "CustomerID";
                cmbCustomer.DataSource = ds.Tables["Customer"];
            }
            catch (Exception ex)
            {
                // write exception info to log or anything else
                MessageBox.Show(ex.ToString());
            }
        }
        private void loadDistrict()
        {
            OleDbConnection conn = new OleDbConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            try
            {
                string query = "select Distinct DistrictName from t_DMSClusterOutlet order by DistrictName";
                OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
                conn.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "District");
                cmbdistric.DisplayMember = "DistrictName";
                cmbdistric.ValueMember = "DistrictName";
                cmbdistric.DataSource = ds.Tables["District"];
            }
            catch (Exception ex)
            {
                // write exception info to log or anything else
                MessageBox.Show(ex.ToString());
            }
        }
        private void loadThana()
        {
            OleDbConnection conn = new OleDbConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            try
            {
                string query = "select Distinct ThanaName from t_DMSClusterOutlet order by ThanaName";
                OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
                conn.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "Thana");
                cmbThana.DisplayMember = "ThanaName";
                cmbThana.ValueMember = "ThanaName";
                cmbThana.DataSource = ds.Tables["Thana"];
            }
            catch (Exception ex)
            {
                // write exception info to log or anything else
                MessageBox.Show(ex.ToString());
            }
        }
        private void loadMarket()
        {
            OleDbConnection conn = new OleDbConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            try
            {
                string query = "select Distinct ThanaName from t_DMSClusterOutlet order by ThanaName";
                OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
                conn.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "Market");
                cmbThana.DisplayMember = "ThanaName";
                cmbThana.ValueMember = "ThanaName";
                cmbThana.DataSource = ds.Tables["Market"];
            }
            catch (Exception ex)
            {
                // write exception info to log or anything else
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            // MessageBox.Show(cmbRetailType.SelectedValue.ToString(), cmbRetailType.Text);

            Update();
        }
        public void Update()
        {          
            int i = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = @"update t_DMSCLusterOutlet set 
                RetailName='"+txtOutletName.Text+ @"',
                RetailAddress='" + txtAdress.Text + @"',
                ProprietorName='" + txtOwner.Text + @"',             
                DistrictName='" + cmbdistric.Text + @"',             
                ThanaName='" + cmbThana.Text + @"',             
                MarketName='" + txtMarket.Text + @"',             
                CustomerID=" + cmbCustomer.SelectedValue + @",             
                RouteID=" + cmbBeat.SelectedValue + @",             
                SlabOutlet=" + cmbSlab.Text + @",             
                RetailGroupID=" + cmbGroupID.Text + @",             
                Mobile01='" + txtMobileNo1.Text + @"',
                Mobile02='" + txtmobile2.Text + @"',
                Mobile03='" + txtmobile3.Text + @"',
                RetailTypeShort='" + txtRetailtypeshort.Text + @"' ,
                RetailType='" + cmbRetailType.Text + @"' ,
                RetailTypeID=" + cmbRetailType.SelectedValue+ @" 
                where RetailID=" + Convert.ToInt32( txtRetailID.Text) + " ";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                i=cmd.ExecuteNonQuery();
                cmd.Dispose();
                MessageBox.Show("Data Updated Successfully", "Success !!");
                this.Close();
                
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        private void cmbRetailType_SelectedIndexChanged(object sender, EventArgs e)
        {

            int ID = Convert.ToInt32(cmbRetailType.SelectedValue);


            OleDbConnection conn = new OleDbConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                string query = "select distinct RetailTypeShort from t_DMSClusterOutlet where RetailTypeID="+ID+"";
                OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
                conn.Open();
                cmd.CommandText = query;
                cmd.CommandType = CommandType.Text;
                txtRetailtypeshort.Text = cmd.ExecuteScalar().ToString();
        
            }
            catch (Exception ex)
            {
                // write exception info to log or anything else
                MessageBox.Show(ex.ToString());
            }
        }
        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            int CustomerID = Convert.ToInt32(cmbCustomer.SelectedValue);

            OleDbConnection conn = new OleDbConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            try
            {
                string query = "select RouteID,RouteName from t_DMSRoute where DistributorID="+CustomerID+"";
                OleDbDataAdapter da = new OleDbDataAdapter(query, conn);
                conn.Open();
                DataSet ds = new DataSet();
                da.Fill(ds, "Route");
                cmbBeat.DisplayMember = "RouteName";
                cmbBeat.ValueMember = "RouteID";
                cmbBeat.DataSource = ds.Tables["Route"];
            }
            catch (Exception ex)
            {
                // write exception info to log or anything else
                MessageBox.Show(ex.ToString());
            }
        }
    }
}

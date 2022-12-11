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
using System.Configuration;
using System.Data.OleDb;

namespace CJ.Win.DMS
{
    public partial class frmDMSOutlets : Form
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
        ElectricMarket _oElectricMarket;
        ElectricMarkets __oElectricMarkets;
        User oUser;
        public frmDMSOutlets()
        {
            InitializeComponent();
        }

        private void frmDMSOutlets_Load(object sender, EventArgs e)
        {
          //  LoadData();
        }

       

     

   

        private void btnOutlet_Click(object sender, EventArgs e)
        {
            frmDMSOutlet ofrmDMSOutlet = new frmDMSOutlet();
            ofrmDMSOutlet.ShowDialog();
            

        }

   

        private void button2_Click(object sender, EventArgs e)
        {
            int RetailID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[7].Value);
            frmOutletUpdate fm = new frmOutletUpdate(RetailID);
            fm.ShowDialog();
         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if(textBox1.Text !="" && textBox2.Text =="")
            //{

            //}


            LoadData();
        }

        public void LoadData()
        {
            string str = ConfigurationManager.AppSettings["ConnectionString"];
            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbConnection con = new OleDbConnection(str);

            string Sql = @"select AreaID,AreaName,TerritoryID,TerritoryName,v.CustomerCode, v.CustomerName,c.RouteName,a.*
            from t_DMSClusterOutlet a, v_CustomerDetails v, t_DMSRoute c
            where a.CustomerID=v.CustomerID and a.RouteID=c.RouteID and a.IsActive=1";

            cmd.CommandText = Sql;
            cmd.CommandType = CommandType.Text;
            con.Open();
            OleDbDataAdapter adp = new OleDbDataAdapter(Sql, con);
            DataSet ds = new DataSet();

            adp.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmDataUploader up = new frmDataUploader();
            up.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text.Length == 8)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[4].Value.ToString().Contains(textBox1.Text.Trim()))
                    {
                        dataGridView1.CurrentRow.Selected = false;
                        dataGridView1.Rows[row.Index].Selected = true;
                        int index = row.Index;
                        dataGridView1.FirstDisplayedScrollingRowIndex = index;
                        break;
                    }
                }
            }
            else
            {
               
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if(textBox2.Text.Length>=4)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[7].Value.ToString().Contains(textBox2.Text.Trim()))
                    {
                        dataGridView1.CurrentRow.Selected = false;
                        dataGridView1.Rows[row.Index].Selected = true;
                        int index = row.Index;
                        dataGridView1.FirstDisplayedScrollingRowIndex = index;
                        break;
                    }
                }
            }
              
            
        
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
             frmDataUploader up = new frmDataUploader();
            up.ShowDialog();
        }
    }
}
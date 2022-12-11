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
    public partial class frmReordering : Form
    {
        ReOrderings oReOrderings;
        ReOrdering _oReOrdering;
        CustomerTypies oCustomerTypies;
        MarketGroups _oArea;
        MarketGroups _oTerritory;
        Users oUsers;
        User oUser;
        int _nUserID = 0;
        public frmReordering()
        {
            InitializeComponent();
        }

        private void frmReordering_Load(object sender, EventArgs e)
        {
            
            User oUser = new User();
            _nUserID = Utility.UserId;
           


            _oArea = new MarketGroups();
            _oArea.GetArea(_nUserID);
            cmbArea.Items.Clear();

            foreach (MarketGroup oMarketGroup in _oArea)
                {
                    cmbArea.Items.Add(oMarketGroup.MarketGroupDesc);
                    
                }
                cmbArea.SelectedIndex = _oArea.Count - 1;


             
                //oMarketGroups.GetTerritory(_nUserID);
                //cmbTerritory.Items.Clear();

                //foreach (MarketGroup oMarketGroup in oMarketGroups)
                //{
                //    cmbTerritory.Items.Add(oMarketGroup.MarketGroupDesc);

                //}
                //cmbTerritory.SelectedIndex = oMarketGroups.Count - 1;
            
        }
        private void DataLoadControl()
        {
            dvwReordering.Rows.Clear();
            pbreordering.Visible = false;

            ReOrderings oReOrderings = new ReOrderings();
            DBController.Instance.OpenNewConnection();
            int nAreaID = 0;
            
            MarketGroups oMarketGroups = new MarketGroups();
            oMarketGroups.GetArea(_nUserID);
            if (cmbArea.Text != "All")
            {
                nAreaID = oMarketGroups[cmbArea.SelectedIndex].MarketGroupID;
            }
            else
            {
                nAreaID = -1;
            }
            _oTerritory = new MarketGroups();
            _oTerritory.DMSGetTerritory(nAreaID);
            int nTerritoryID = 0;
            if (_oTerritory.Count > 0)
            {
                if (cmbTerritory.Text != "ALL")
                {
                    nTerritoryID = _oTerritory[cmbTerritory.SelectedIndex].MarketGroupID;
                }
                else
                {
                    nTerritoryID = -1;
                }
            }
            if (ctlCustomer1.SelectedCustomer != null)
            oReOrderings.GetReOrdering(ctlCustomer1.SelectedCustomer.CustomerID, nAreaID, nTerritoryID);
            else
            oReOrderings.GetReOrdering(-1, nAreaID, nTerritoryID);
            foreach (ReOrdering oReOrdering in oReOrderings)
            {

                DataGridViewRow oRow = new DataGridViewRow();

                oRow.CreateCells(dvwReordering);
                oRow.Cells[0].Value = oReOrdering.CustomerID;
                oRow.Cells[1].Value = oReOrdering.ProductID;
                oRow.Cells[2].Value = oReOrdering.CustomerCode.ToString();
                oRow.Cells[3].Value = oReOrdering.CustomerName.ToString();
                oRow.Cells[4].Value = oReOrdering.ASGName.ToString();
                oRow.Cells[5].Value = oReOrdering.BrandDesc.ToString();
                oRow.Cells[6].Value = oReOrdering.ProductCode.ToString();
                oRow.Cells[7].Value = oReOrdering.ProductName.ToString();
                oRow.Cells[8].Value = oReOrdering.CRStock;
                oRow.Cells[9].Value = oReOrdering.LWSalesQty;
                oRow.Cells[10].Value = oReOrdering.STFloorSTK;
                oRow.Cells[11].Value = oReOrdering.MOQ;
                oRow.Cells[12].Value = oReOrdering.ReqQty;
                dvwReordering.Rows.Add(oRow);
                
              
            }


        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                DBController.Instance.BeginNewTransaction();              
               

                // Data delete from Gride View

                int i = 0;
                foreach (DataGridViewRow row in dvwReordering.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        ReOrdering oReOrdering = new ReOrdering();
                        int nCustomerID = int.Parse(row.Cells[0].Value.ToString());
                        //int nProductID = int.Parse(row.Cells[1].Value.ToString());
                        //int nNormQty = int.Parse(row.Cells[12].Value.ToString());
                        oReOrdering.Delete(nCustomerID);
                        i = i + 1;
                    }
                }

               

                // Code for Progress Bar 
                pbreordering.Visible = true;
                pbreordering.Minimum = 0;
                pbreordering.Maximum = i;
                pbreordering.Step = 1;
                pbreordering.Value = 0;


                // Data Insertion from Gride View                
                
                foreach (DataGridViewRow row in dvwReordering.Rows)
                {                   
                    if (!row.IsNewRow)
                    {
                        ReOrdering oReOrdering = new ReOrdering();                              

                        int nCustomerID = int.Parse(row.Cells[0].Value.ToString());
                        int nProductID = int.Parse(row.Cells[1].Value.ToString());
                        int nNormQty = int.Parse(row.Cells[12].Value.ToString());
                        //oReOrdering.Delete(nCustomerID, nProductID);
                        oReOrdering.Insert(nCustomerID, nProductID, nNormQty);
                        pbreordering.PerformStep();                                         

                    }

                }

                // Update Sync bit in DMS user Table
                _oReOrdering = new ReOrdering();
              //  _oReOrdering.Update();

                DBController.Instance.CommitTransaction();
                MessageBox.Show(" You Have Successfully Save The Transaction ");
                dvwReordering.Rows.Clear();             
                             

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }

        private void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            _oTerritory = new MarketGroups();
            int nAreaID = 0;
            nAreaID = _oArea[cmbArea.SelectedIndex].MarketGroupID;
            DBController.Instance.OpenNewConnection();
            _oTerritory.DMSGetTerritory(nAreaID);
            int nTerritoryID = 0;
            cmbTerritory.Items.Clear();
            foreach (MarketGroup oMarketGroup in _oTerritory)
            {
                cmbTerritory.Items.Add(oMarketGroup.MarketGroupDesc);

            }
            cmbTerritory.SelectedIndex = _oTerritory.Count - 1;
            DBController.Instance.CloseConnection();
        }

        private void pbStockIn_Click(object sender, EventArgs e)
        {

        }

    }
}
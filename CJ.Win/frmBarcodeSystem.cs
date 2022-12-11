// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: February 20, 2011
// Time : 10:00 AM
// Description: Form for Generate Barcode Systematically
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Report;

namespace CJ.Win
{
    public partial class frmBarcodeSystem : Form
    {
        public frmBarcodeSystem()
        {
            InitializeComponent();
        }

        private void frmProductBarcode_Load(object sender, EventArgs e)
        {
            
        }
        private void btgetdata_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void DataLoadControl()
        {
            ProductBarcodes oProductBarcodes = new ProductBarcodes();
            lvwProductBarcode.Items.Clear();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            oProductBarcodes.GetData(dtfromdate.Value.Date, dttodate.Value.Date, txttranno.Text);
            
            
            foreach (ProductBarcode oProductBarcode in oProductBarcodes)
            {               
                ListViewItem oItem = lvwProductBarcode.Items.Add(oProductBarcode.TranNo);
                oItem.SubItems.Add((oProductBarcode.TranDate).ToString());
                oItem.SubItems.Add((oProductBarcode.TranNoStatus));
                oItem.Tag = oProductBarcode;
               
            }
            this.Text = "Products " + lvwProductBarcode.Items.Count.ToString();       
        }

        private void btGenaretBarcode_Click(object sender, EventArgs e)
        {
            if (lvwProductBarcode.SelectedItems.Count != 0)
            {


                ProductBarcodes oProductBarcodes = new ProductBarcodes();

                ProductBarcode oProductBarcode = (ProductBarcode)lvwProductBarcode.SelectedItems[0].Tag;
                if (!DBController.Instance.CheckConnection())
                {
                    DBController.Instance.OpenNewConnection();
                }

                oProductBarcodes.CheckTranNo(oProductBarcode.TranNo);
                if (oProductBarcodes.Flag == true)
                {
                    try
                    {
                        //GetProductIds(oProductBarcode.TranId, oProductBarcode.TranNo);
                        //this.Tag = oProductBarcode;
                        //MessageBox.Show("You Have Successfully Save The Data. This Transaction No : " + oProductBarcode.TranNo, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        frmBarcodeSystemBE oForm = new frmBarcodeSystemBE(oProductBarcode.TranNo, oProductBarcode.TranDate, oProductBarcode.TranId, Utility.CentralRetailWarehouse);
                        oForm.ShowDialog();
                        if (oForm._IsTrue == true)
                            DataLoadControl();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
                else
                {
                    MessageBox.Show("This Transaction Already Execute.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }
           
        }
        private void GetProductIds(int nTranId,string sTranNo)
        {
            ProductBarcodes oProductBarcodes = new ProductBarcodes();

            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            oProductBarcodes.GetProductInfo(nTranId);            
            
            foreach (ProductBarcode oProductBarcode in oProductBarcodes)
            {
                oProductBarcode.TranNo = sTranNo;               

                try
                {
                    if (oProductBarcode.Qty > 0)
                    {
                        DBController.Instance.BeginNewTransaction();
                        if (Utility.CompanyInfo == "TML")
                        {
                            oProductBarcode.AddTML(1);
                        }
                        else
                        {
                            oProductBarcode.Add(1);
                        }
                        
                        DBController.Instance.CommitTran();
                    }
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
               
            }          
          
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: March 02, 2011
// Time : 10:00 AM
// Description: Form for Print Generate Barcode 
// Modify Person And Date: Md. Abdul Hakim, 01-Aug-2013
// </summary>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

using CJ.Class;
using System.IO;
using CJ.Win.Security;

namespace CJ.Win
{
    public partial class frmBarcodePrint : Form
    {
        private int ncbCheck = -1, x = 5, y = 15;
        private string sBarcode = "";
        private string sProductcode = "";
        private string sProductname = "";
        private Image imBarcode;
        private Image imProductcode;

        bool IsChecked = false;

        public frmBarcodePrint()
        {
            InitializeComponent();
        }

        private void btgetdata_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void DataLoadControl()
        {          
            ProductBarcodes oProductBarcodes = new ProductBarcodes();
            lvwTranList.Items.Clear();
            DBController.Instance.BeginNewTransaction();
            if (chkAll.Checked == true)
            {
                IsChecked = true;
            }
            else
            {
                IsChecked = false;
            }
            oProductBarcodes.GetRefNos(dtformdate.Value, dttodate.Value, ncbCheck, txtrefno.Text, IsChecked);
            DBController.Instance.CommitTran();            
            foreach (ProductBarcode oProductBarcode in oProductBarcodes)
            {
                ListViewItem oItem = lvwTranList.Items.Add(oProductBarcode.TranNo);
                oItem.SubItems.Add((oProductBarcode.TranDate).ToString("dd-MMM-yyyy"));               
                oItem.Tag = oProductBarcode;
            }            
        }

        private void BacodeLoad()
        {
            if (lvwTranList.SelectedItems.Count != 0)
            {
                ProductBarcode oProductBarcode = (ProductBarcode)lvwTranList.SelectedItems[0].Tag;
                ProductBarcodes oBarcodes = new ProductBarcodes();
                lvwProductBarcode.Items.Clear();
                if (!DBController.Instance.CheckConnection())
                {
                    DBController.Instance.OpenNewConnection();
                }

                oBarcodes.GetAllBarcodeByGRD(oProductBarcode.TranNo, txtProductCode.Text.Trim());
                foreach (ProductBarcode oBarcode in oBarcodes)
                {
                    ListViewItem oItem = lvwProductBarcode.Items.Add(oBarcode.ProductSerialNo);
                    oItem.SubItems.Add(oBarcode.ProductCode);
                    oItem.SubItems.Add(oBarcode.ProductName);
                    oItem.SubItems.Add(oBarcode.PrintCount.ToString());
                    oItem.Tag = oBarcode;
                }
            }
        }

        private void dtformdate_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void dttodate_ValueChanged(object sender, EventArgs e)
        {
            
        }
        private void cbbarcodetype_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbarcodetype.Text == "System") ncbCheck = 1;
            else if (cbbarcodetype.Text == "Manual") ncbCheck = 0;
            else if (cbbarcodetype.Text == "All") ncbCheck = -1;            
            
        }
        private void lvwProductBarcode_Click(object sender, EventArgs e)
        {
          
        }
        public void ShowBarcode(ProductBarcodes oProductBarcodes)
        {            
            lvwProductBarcode.Items.Clear();
            btPrint.Enabled = false;
            foreach (ProductBarcode oProductBarcode in oProductBarcodes)
            {
                for (long i = 0; i < oProductBarcode.Qty; i++)
                {
                    ListViewItem oItem = lvwProductBarcode.Items.Add((oProductBarcode.InitialBarcode + i).ToString());
                    oItem.SubItems.Add((oProductBarcode.ProductCode).ToString());
                    oItem.SubItems.Add((oProductBarcode.ProductName).ToString());
                    oItem.Tag = oProductBarcode;
                }
            }
        }
        private void lvwTranList_Click(object sender, EventArgs e)
        {
            BacodeLoad();
            //if (lvwTranList.SelectedItems.Count != 0)
            //{
            //    ProductBarcodes oProductBarcodes = new ProductBarcodes();
            //    ProductBarcode oProductBarcode = (ProductBarcode)lvwTranList.SelectedItems[0].Tag;
            //    DBController.Instance.BeginNewTransaction();
            //    oProductBarcodes.GetBarcodeInfo(oProductBarcode.TranNo);
            //    DBController.Instance.CommitTran();                 
            //    ShowBarcode(oProductBarcodes);
            //}

        }     

        private void btCLose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lvwProductBarcode.Items.Count; i++)
            {
                if (lvwProductBarcode.Items[i].Checked == true)
                {

                    ListViewItem itm = lvwProductBarcode.Items[i];
                    if (updateSecurity())
                    {
                        PrintBarcode(itm.SubItems[0].Text.ToString(), itm.SubItems[1].Text.ToString(), itm.SubItems[2].Text.ToString());
                        ProductBarcode oUpdateProductBarcode = new ProductBarcode();
                        oUpdateProductBarcode.UpdatePrintCount(itm.SubItems[0].Text.ToString());
                    }
                    else
                    {
                        if (Convert.ToInt32(itm.SubItems[3].Text) == 0)
                        {
                            PrintBarcode(itm.SubItems[0].Text.ToString(), itm.SubItems[1].Text.ToString(), itm.SubItems[2].Text.ToString());
                            ProductBarcode oUpdateProductBarcode = new ProductBarcode();
                            oUpdateProductBarcode.UpdatePrintCount(itm.SubItems[0].Text.ToString());
                        }
                        else
                        {
                            MessageBox.Show("You do not have sufficient permissions to print this barcode (" + itm.SubItems[0].Text.ToString() + ").", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }

        }
        public void PrintBarcode(string Barcode,string ProductCode,string ProductName)
        {
            if (txtnumberofcopy.Text != "")
            {
                imBarcode = Image.FromStream(ProductBarcodePrint.CreateBarcode128b(Barcode));
                picBarcode.Image = imBarcode;
                sBarcode = Barcode;
                imProductcode = Image.FromStream(ProductBarcodePrint.CreateBarcode128b(ProductCode));
                picProductcode.Image = imProductcode;
                sProductcode = ProductCode;
                sProductname = ProductName;


                PrintDocument tmpprndoc = new PrintDocument();
                tmpprndoc.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
                for (int i = 0; i < Convert.ToInt16(txtnumberofcopy.Text); i++)
                {
                   tmpprndoc.Print();
                }
            }
            else MessageBox.Show("Please Please enter the number of copies.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            
            using (Graphics g = e.Graphics)
            {
                using (Font fnt = new Font("Arial Narrow", 8))
                {
                    g.DrawImage(imBarcode, x, y);
                    y = y + 26;
                    string caption = string.Format("S/N : " + sBarcode);
                    g.DrawString(caption, fnt, System.Drawing.Brushes.Black, x, y);
                    y = y + 12;
                    g.DrawImage(imProductcode, x, y);
                    y = y + 26;
                    caption = string.Format("Prod.Code :" + sProductcode);
                    g.DrawString(caption, fnt, System.Drawing.Brushes.Black, x, y);
                    y = y + 10;
                    caption = string.Format(sProductname);
                    g.DrawString(caption, fnt, System.Drawing.Brushes.Black, x, y);
                    x = 5; y = 15;                   
               }
            }
        }

        private void lvwProductBarcode_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            btPrint.Enabled = true;
        }

        private void txtnumberofcopy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar > 32 && e.KeyChar < 48) || (e.KeyChar > 57 && e.KeyChar < 256))
            {
                e.Handled = true;
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                dtformdate.Enabled = false;
                dttodate.Enabled = false;
            }
            else
            {
                dtformdate.Enabled = true;
                dttodate.Enabled = true;
            }
        }

        private bool updateSecurity()
        {
            Users oUsers = new Users();
            string sPermissionKey = oUsers.checkOtherPermission("M28.4", Utility.UserId);
            if (sPermissionKey == "M28.4")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        

        private void frmBarcodePrint_Load(object sender, EventArgs e)
        {

        }

        private void txtProductCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtrefno_TextChanged(object sender, EventArgs e)
        {

        }

        private void ckbSelect_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbSelect.Checked == true)
            {
                for (int i = 0; i < lvwProductBarcode.Items.Count; i++)
                {
                    ListViewItem itm = lvwProductBarcode.Items[i];

                    lvwProductBarcode.Items[i].Checked = true;

                }
            }
            else
            {
                for (int i = 0; i < lvwProductBarcode.Items.Count; i++)
                {
                    ListViewItem itm = lvwProductBarcode.Items[i];

                    lvwProductBarcode.Items[i].Checked = false;

                }
            }
        }

        private void txtProductCode_Leave(object sender, EventArgs e)
        {
            BacodeLoad();
        }

               
    }
}
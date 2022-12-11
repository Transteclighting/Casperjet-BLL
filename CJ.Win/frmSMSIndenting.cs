using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using CJ.Class;
using CJ.Class.Report;
using CJ.Report;

namespace CJ.Win
{
    public partial class frmSMSIndenting : Form
    {
        private int nArrayLen = 0;
        private string sSMStext = null;
        private string[] sSMStextArr = null;

        rptSMSIndenting _orptSMSIndenting;
        rptSMSIndentingItem _orptSMSIndentingItem;

        public frmSMSIndenting()
        {
            InitializeComponent();
        }

        private void frmSMSIndenting_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            SMSIndentings oSMSIndentings = new SMSIndentings();
            lvwSMSIndenting.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oSMSIndentings.Refresh();

            foreach (SMSIndenting oSMSIndenting in oSMSIndentings)
            {
                ListViewItem oItem = lvwSMSIndenting.Items.Add(oSMSIndenting.SMSmessageID.ToString());
                oItem.SubItems.Add((oSMSIndenting.ReceiveDate).ToString());
                oItem.SubItems.Add((oSMSIndenting.SMSText).ToString());
                oItem.SubItems.Add((oSMSIndenting.MessageType).ToString());
                oItem.SubItems.Add((oSMSIndenting.MobileNo.ToString()));
                oItem.SubItems.Add((oSMSIndenting.Status).ToString());
                oItem.Tag = oSMSIndenting;
            }            
          
        }

        private void btRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }     

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btShowIndent_Click(object sender, EventArgs e)
        {
            SMSIndentings oSMSIndentings = new SMSIndentings();
            

            cbSMSId.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oSMSIndentings.GetSMSinfo(0);
            

            foreach (SMSIndenting oSMSIndenting in oSMSIndentings)
            {
                cbSMSId.Items.Add(oSMSIndenting.SMSmessageID);
                cbSMSId.Tag = oSMSIndenting;
            }
        }

        private void cbSMSId_SelectedIndexChanged(object sender, EventArgs e)
        {
            Customers oCusomers = new Customers();
            Product oProduct = new Product();
            SMSIndentings oSMSIndentings = new SMSIndentings();  
         
            DBController.Instance.OpenNewConnection();
            oSMSIndentings.GetSMSinfo(int.Parse(cbSMSId.Text));

            foreach (SMSIndenting oSMSIndenting in oSMSIndentings)
            {
                sSMStext = oSMSIndenting.SMSText;
                lbMobileno.Text = oSMSIndenting.MobileNo;
                lblReceivdate.Text = oSMSIndenting.ReceiveDate.ToString();
            }

            char[] splitchar = { ' ' };
            sSMStextArr = sSMStext.Split(splitchar);
            nArrayLen = sSMStextArr.Length;
            int p = 0, k = 0;

            DBController.Instance.OpenNewConnection();

            oCusomers.GetCustomerInfoForSMSindenting(int.Parse( sSMStextArr[1].ToString()));
            foreach (Customer oCustomer in oCusomers)
            {
                lbcustomername.Text = oCustomer.CustomerName;
                lbcustomeraddress.Text = oCustomer.CustomerAddress;
                lbcustomercode.Text = oCustomer.CustomerCode;
               
            }
            lvOrderDetails.Items.Clear();
            for (int j = 0; j < (nArrayLen - 2) / 2; j++)
            {
                DBController.Instance.OpenNewConnection();

                ListViewItem oItem = lvOrderDetails.Items.Add(sSMStextArr[p + 2].ToString());
                oProduct.ProductCode = sSMStextArr[p + 2].ToString();
                oProduct.Refresh();
                oItem.SubItems.Add(oProduct.ProductName);
                oItem.SubItems.Add(sSMStextArr[k + 3].ToString());               

                p = p + 2;
                k = k + 2;

            }
        }

        private void btSave_Click_1(object sender, EventArgs e)
        {
            SMSIndenting oSMSIndenting;
            if (lvwSMSIndenting.Items.Count > 0)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();

                    for (int i = 0; i < lvwSMSIndenting.Items.Count; i++)
                    {
                        oSMSIndenting = new SMSIndenting();
                        ListViewItem itm = lvwSMSIndenting.Items[i];

                        oSMSIndenting.SMSmessageID = int.Parse(itm.SubItems[0].Text);
                        oSMSIndenting.ReceiveDate = Convert.ToDateTime(itm.SubItems[1].Text);
                        oSMSIndenting.SMSText = itm.SubItems[2].Text;
                        oSMSIndenting.MessageType = int.Parse(itm.SubItems[3].Text);
                        oSMSIndenting.MobileNo = itm.SubItems[4].Text;
                        oSMSIndenting.Status = int.Parse(itm.SubItems[5].Text);

                        oSMSIndenting.Add();
                    }
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Data.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
            else MessageBox.Show("No Data.","Error" ,MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btRefresh_Click_1(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btMakeOrder_Click(object sender, EventArgs e)
        {
            SMSIndenting oSMSIndenting = new SMSIndenting(); 
            try
            {
                DBController.Instance.BeginNewTransaction();
                oSMSIndenting.Update(int.Parse(cbSMSId.Text));
                DBController.Instance.CommitTransaction();
                MessageBox.Show("You Have Successfully Order.", "Order", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();                
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }

        private void btReport_Click(object sender, EventArgs e)
        {
            frmSMSIndentingReport oShow = new frmSMSIndentingReport();
            oShow.ShowDialog("BLL");
             
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lvOrderDetails_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btSMSIndentingReport_Click(object sender, EventArgs e)
        {
            _orptSMSIndenting = new rptSMSIndenting();

            if (cbSMSId.Text != "")
            {
                if (lvOrderDetails.Items.Count > 0)
                {
                    try
                    {

                        for (int i = 0; i < lvOrderDetails.Items.Count; i++)
                        {
                            _orptSMSIndentingItem = new rptSMSIndentingItem();
                            ListViewItem itm = lvOrderDetails.Items[i];

                            _orptSMSIndentingItem.ProductCode = itm.SubItems[0].Text;
                            _orptSMSIndentingItem.ProductName = itm.SubItems[1].Text;
                            _orptSMSIndentingItem.Qty = int.Parse(itm.SubItems[2].Text);

                            _orptSMSIndenting.Add(_orptSMSIndentingItem);
                        }

                    }
                    catch
                    {

                    }
                }
                rptSMSIndentings doc;
                doc = new rptSMSIndentings();
                doc.SetDataSource(_orptSMSIndenting);

                doc.SetParameterValue("CustomerCode", lbcustomercode.Text);
                doc.SetParameterValue("CustomerName", lbcustomername.Text);
                doc.SetParameterValue("CustomerAddress", lbcustomeraddress.Text);
                doc.SetParameterValue("SMSReceivedDate", lblReceivdate.Text);
                doc.SetParameterValue("MobileNumber", lbMobileno.Text);
                doc.SetParameterValue("SMSNumber", cbSMSId.Text);

                frmPrintPreview frmView;
                frmView = new frmPrintPreview();

                frmView.Text = "SMS Indenting";
                frmView.ShowDialog(doc);
            }
        }

        private void lvwSMSIndenting_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblReceivdate_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void lbMobileno_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void lbcustomercode_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void lbcustomeraddress_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lbcustomername_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lbMno_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        
    }
}
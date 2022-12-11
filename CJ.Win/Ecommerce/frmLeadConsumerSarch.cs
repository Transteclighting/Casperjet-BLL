using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.Ecommerce
{
    public partial class frmLeadConsumerSarch : Form
    {
        SalesLeads _oSalesLeads;
        private SalesLead oSalesLead;
        int _nType = 0;

        public frmLeadConsumerSarch(int nType)
        {
            InitializeComponent();
            _nType = nType;
        }

        private void DataLoadControl()
        {
            _oSalesLeads = new SalesLeads();
            lvwSalesLead.Items.Clear();

            DBController.Instance.OpenNewConnection();
            _oSalesLeads.Refresh(txtCompany.Text.Trim(), txtName.Text.Trim(), txtContactNo.Text.Trim(), _nType);
            DBController.Instance.CloseConnection();

            foreach (SalesLead oSalesLead in _oSalesLeads)
            {
                ListViewItem oItem = lvwSalesLead.Items.Add(oSalesLead.LeadNo.ToString());
                oItem.SubItems.Add(oSalesLead.CompanyName.ToString());
                oItem.SubItems.Add(oSalesLead.Name.ToString());
                oItem.SubItems.Add(oSalesLead.ContactNo.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.CustomerTypeSalesLead), oSalesLead.CustomerType));

                oItem.Tag = oSalesLead;
            }
            this.Text = "Lead Consumer List [" + _oSalesLeads.Count + "]";
        }

        private void lvwSalesLead_DoubleClick(object sender, EventArgs e)
        {
            SalesLead _oSalesLead = (SalesLead)lvwSalesLead.SelectedItems[0].Tag;

            oSalesLead.LeadNo = _oSalesLead.LeadNo;
            oSalesLead.Name = _oSalesLead.Name;
            this.Close();
        }

        private void lvwSalesLead_KeyPress(object sender, KeyPressEventArgs e)
        {
            SalesLead _oSalesLead = (SalesLead)lvwSalesLead.SelectedItems[0].Tag;

            oSalesLead.LeadNo = _oSalesLead.LeadNo;
            oSalesLead.Name = _oSalesLead.Name;
            this.Close();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        public bool ShowDialog(SalesLead _oSalesLeads)
        {
            oSalesLead = _oSalesLeads;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.ShowDialog();
            return true;
        }

        private void frmLeadConsumerSarch_Load(object sender, EventArgs e)
        {
            this.Text = "Lead Consumer List";
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class.POS;
using CJ.Class;


namespace CJ.POS.RT
{
    public partial class frmConsumers : Form
    {
        RetailConsumers oRetailConsumers;
        //SystemInfo oSystemInfo;
        ProductGroups _oMAGs;

        public frmConsumers()
        {
            InitializeComponent();
        }
        private void frmConsumers_Load(object sender, EventArgs e)
        {

            LoadCombo();

        }


        private void LoadCombo()
        {
            DBController.Instance.OpenNewConnection();

            //MAG
            _oMAGs = new ProductGroups();
            _oMAGs.GetProductGroup((int)Dictionary.ProductGroupType.MAG);
            cmbMAG.Items.Add("--All--");
            foreach (ProductGroup oProductGroup in _oMAGs)
            {
                cmbMAG.Items.Add(oProductGroup.PdtGroupName + "[" + oProductGroup.PdtGroupCode + "]");
            }
            cmbMAG.SelectedIndex = 0;

            //IsActive
            cmbSalesType.Items.Clear();
            cmbSalesType.Items.Add("--All--");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SalesType)))
            {
                cmbSalesType.Items.Add(Enum.GetName(typeof(Dictionary.SalesType), GetEnum));
            }
            cmbSalesType.SelectedIndex = 0;


        }
        public void DataLoad()
        {
            this.Cursor = Cursors.WaitCursor;

            int nMAG = 0;
            if (cmbMAG.SelectedIndex == 0)
            {
                nMAG = -1;
            }
            else
            {
                nMAG = _oMAGs[cmbMAG.SelectedIndex - 1].PdtGroupID;
            }

            int nSalesType = 0;
            if (cmbSalesType.SelectedIndex == 0)
            {
                nSalesType = -1;
            }
            else
            {
                //nSalesType = cmbSalesType.SelectedIndex;
                if (cmbSalesType.SelectedIndex + 1 != (int)Dictionary.SalesType.Dealer && cmbSalesType.SelectedIndex + 1 != (int)Dictionary.SalesType.B2B)
                {
                    MessageBox.Show("Dealer and B2B is not accessable");
                    return;
                }

                nSalesType = cmbSalesType.SelectedIndex;
            }

            oRetailConsumers = new  RetailConsumers();
            //oSystemInfo = new SystemInfo();

            lvwConsumers.Items.Clear();
            DBController.Instance.OpenNewConnection();

            //oSystemInfo.Refresh();
            oRetailConsumers.RefreshConsumerRT(txtCustCode.Text, txtConsumerName.Text, txtContactNo.Text, nMAG, nSalesType, Utility.WarehouseID);
            foreach (RetailConsumer oRetailConsumer in oRetailConsumers)
            {
                ListViewItem oItem = lvwConsumers.Items.Add(oRetailConsumer.ConsumerCode);
                oItem.SubItems.Add(oRetailConsumer.ConsumerName);
                oItem.SubItems.Add(oRetailConsumer.CellNo);
                oItem.SubItems.Add(oRetailConsumer.Address);
                oItem.SubItems.Add(oRetailConsumer.InvoiceNo);
                oItem.SubItems.Add(Convert.ToDateTime(oRetailConsumer.InvoiceDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oRetailConsumer.MAGName);
                oItem.SubItems.Add(oRetailConsumer.SalesTypeName);

                oItem.Tag = oRetailConsumer;
            }


            this.Cursor = Cursors.Default;
        }
        private void rdbUnRegistered_CheckedChanged(object sender, EventArgs e)
        {

            //if (rdbUnRegistered.Checked)
            //{
            //    rdbRegistered.Checked = false;
            //    DataLoad();
            //}
        }

        private void rdbRegistered_CheckedChanged(object sender, EventArgs e)
        {
            //if (rdbRegistered.Checked)
            //{
            //    rdbUnRegistered.Checked = false;
            //    DataLoad();
            //}
        }

        private void btRegister_Click(object sender, EventArgs e)
        {
            if (lvwConsumers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            RetailConsumer oRetailConsumer = (RetailConsumer)lvwConsumers.SelectedItems[0].Tag;

            if (oRetailConsumer.IsRegister == 0)
            {
                frmConsumer ofrm = new frmConsumer(1, Utility.CustomerID);
                ofrm.ShowDialog(oRetailConsumer);
                DataLoad();
            }
            else
            {
                MessageBox.Show("Only Unregistered Consumer Can Be Registered.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            DataLoad();
        }

        private void btGo_Click(object sender, EventArgs e)
        {
            DataLoad();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtCustCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (lvwConsumers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            RetailConsumer oRetailConsumer = (RetailConsumer)lvwConsumers.SelectedItems[0].Tag;
            frmConsumerDetail ofrm = new frmConsumerDetail();
            ofrm.ShowDialog(oRetailConsumer);
            DataLoad();

        }

       
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class.POS;
using CJ.Class;


namespace CJ.POS
{
    public partial class frmConsumers : Form
    {
        RetailConsumers oRetailConsumers;
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
            int nSalesType = 0;

            

            if (cmbSalesType.SelectedIndex == 0)
            {
                nSalesType = -1;
            }
            else
            {
                if (cmbSalesType.SelectedIndex + 1 != (int)Dictionary.SalesType.Dealer && cmbSalesType.SelectedIndex + 1 != (int)Dictionary.SalesType.B2B)
                {
                    MessageBox.Show("Dealer and B2B is not accessable");
                    return;
                }

                nSalesType = cmbSalesType.SelectedIndex;
            }

            oRetailConsumers = new RetailConsumers();
            lvwConsumers.Items.Clear();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            oRetailConsumers.RefreshConsumer(txtCustCode.Text, txtConsumerName.Text, txtContactNo.Text, nSalesType);
            foreach (RetailConsumer oRetailConsumer in oRetailConsumers)
            {
                ListViewItem oItem = lvwConsumers.Items.Add(oRetailConsumer.ConsumerCode);
                oItem.SubItems.Add(oRetailConsumer.ConsumerName);
                oItem.SubItems.Add(oRetailConsumer.CellNo);
                oItem.SubItems.Add(oRetailConsumer.PhoneNo);
                oItem.SubItems.Add(oRetailConsumer.Email);
                oItem.SubItems.Add(oRetailConsumer.Address);
                oItem.SubItems.Add(oRetailConsumer.SalesTypeName);
                oItem.SubItems.Add(oRetailConsumer.CustomerCode);
                oItem.SubItems.Add(oRetailConsumer.CustomerName);
                oItem.Tag = oRetailConsumer;
            }
            this.Text = "Reatil Consumers [" + oRetailConsumers.Count + "]";
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
            this.Cursor = Cursors.WaitCursor;
            DataLoad();
            this.Cursor = Cursors.Default;
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

        private void btnAddRetailConsumer_Click(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            frmConsumer ofrmConsumer = new frmConsumer(0, 0);
            ofrmConsumer.ShowDialog();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (lvwConsumers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            RetailConsumer oRetailConsumer = (RetailConsumer)lvwConsumers.SelectedItems[0].Tag;
            if (oRetailConsumer.IsRegister == 0)
            {
                frmConsumer ofrm = new frmConsumer(oRetailConsumer.SalesType, oRetailConsumer.CustomerID);
                ofrm.ShowDialog(oRetailConsumer);
                if (ofrm._IsTrue)
                    DataLoad();
            }
            else
            {
                MessageBox.Show("Only Unregistered Consumer Can Be Registered.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}
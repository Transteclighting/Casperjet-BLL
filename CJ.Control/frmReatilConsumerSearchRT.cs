using System;
using System.Windows.Forms;
using CJ.Class.POS;
using CJ.Class;

namespace CJ.Control
{
    public partial class frmReatilConsumerSearchRT : Form
    {
        private RetailConsumer oRetailConsumer;
        int _nSalesType = 0;
        public frmReatilConsumerSearchRT(int nSalesType)
        {
            InitializeComponent();
            _nSalesType = nSalesType;
        }
        public void LoadData()
        {
            RetailConsumers _oRetailConsumers = new RetailConsumers();
            lvwCustomer.Items.Clear();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            _oRetailConsumers.RefreshRT(txtCustCode.Text, txtName.Text, txtMobile.Text, txtPhone.Text, txtAddress.Text, txtEmail.Text, _nSalesType);
            foreach (RetailConsumer oRetailConsumer in _oRetailConsumers)
            {
                ListViewItem lstItem = lvwCustomer.Items.Add(oRetailConsumer.ConsumerCode.ToString());
                lstItem.SubItems.Add(oRetailConsumer.ConsumerName.ToString());
                lstItem.SubItems.Add(oRetailConsumer.CellNo.ToString());
                lstItem.SubItems.Add(oRetailConsumer.PhoneNo.ToString());
                lstItem.SubItems.Add(oRetailConsumer.Address.ToString());
                lstItem.SubItems.Add(oRetailConsumer.Email.ToString());
                lstItem.SubItems.Add(oRetailConsumer.RetailConsumerCode.ToString());
                lstItem.SubItems.Add(oRetailConsumer.RetailConsumerName.ToString());

                lstItem.Tag = oRetailConsumer;
            }
        }
        public bool ShowDialog(RetailConsumer _oRetailConsumer)
        {
            oRetailConsumer = _oRetailConsumer;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.ShowDialog();
            return true;
        }
        private void lvwCustomer_KeyPress(object sender, KeyPressEventArgs e)
        {
            RetailConsumer _oRetailConsumer = (RetailConsumer)lvwCustomer.SelectedItems[0].Tag;
            oRetailConsumer.ConsumerID = _oRetailConsumer.ConsumerID;
            oRetailConsumer.ConsumerCode = _oRetailConsumer.ConsumerCode;
            oRetailConsumer.ConsumerName = _oRetailConsumer.ConsumerName;
            oRetailConsumer.CellNo = _oRetailConsumer.CellNo;
            oRetailConsumer.PhoneNo = _oRetailConsumer.PhoneNo;
            oRetailConsumer.Email = _oRetailConsumer.Email;
            oRetailConsumer.RetailConsumerID = _oRetailConsumer.RetailConsumerID;
            oRetailConsumer.RetailConsumerCode = _oRetailConsumer.RetailConsumerCode;
            oRetailConsumer.RetailConsumerName = _oRetailConsumer.RetailConsumerName;
            this.Close();
        }

        private void lvwCustomer_DoubleClick_1(object sender, EventArgs e)
        {
            RetailConsumer _oRetailConsumer = (RetailConsumer)lvwCustomer.SelectedItems[0].Tag;
            oRetailConsumer.ConsumerID = _oRetailConsumer.ConsumerID;
            oRetailConsumer.ConsumerCode = _oRetailConsumer.ConsumerCode;
            oRetailConsumer.ConsumerName = _oRetailConsumer.ConsumerName;
            oRetailConsumer.CellNo = _oRetailConsumer.CellNo;
            oRetailConsumer.PhoneNo = _oRetailConsumer.PhoneNo;
            oRetailConsumer.Email = _oRetailConsumer.Email;
            oRetailConsumer.RetailConsumerID = _oRetailConsumer.RetailConsumerID;
            oRetailConsumer.RetailConsumerCode = _oRetailConsumer.RetailConsumerCode;
            oRetailConsumer.RetailConsumerName = _oRetailConsumer.RetailConsumerName;
            this.Close();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

    }
}
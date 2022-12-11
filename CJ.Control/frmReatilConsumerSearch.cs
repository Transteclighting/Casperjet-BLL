using System;
using System.Windows.Forms;
using CJ.Class.POS;
using CJ.Class;

namespace CJ.Control
{
    public partial class frmReatilConsumerSearch : Form
    {
        private RetailConsumer oRetailConsumer;
        int _nType = 0;
        int _nTerminal = 0;
        int _nWarehouseID = 0;
        public frmReatilConsumerSearch(int nType, int nTerminal,int nWarehouseID)
        {
            InitializeComponent();
            _nType = nType;
            _nTerminal = nTerminal;
            _nWarehouseID = nWarehouseID;
            if (_nType == (int)Dictionary.SalesType.Retail)
            {
                this.Text = "Reatil Consumer Search";
            }
            else if (_nType == (int)Dictionary.SalesType.B2C)
            {
                this.Text = "B2C Consumer Search";
            }
            else if (_nType == (int)Dictionary.SalesType.HPA)
            {
                this.Text = "HPA Consumer Search";
            }
            else if (_nType == (int)Dictionary.SalesType.eStore)
            {
                this.Text = "Reatil Consumer Search";
            }
        }

        public void LoadData()
        {
            RetailConsumers _oRetailConsumers = new RetailConsumers();
            lvwCustomer.Items.Clear();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            if (_nTerminal == (int)Dictionary.Terminal.Branch_Office)
            {
                if (_nType == -1)
                {
                    _oRetailConsumers.Refresh(txtCustCode.Text, txtFind.Text, txtContactNo.Text);
                }
                else
                {
                    _oRetailConsumers.RefreshConsumerByType(txtCustCode.Text, txtFind.Text, txtContactNo.Text, _nType);
                }
            }
            else
            {
                _oRetailConsumers.RefreshConsumerByTypeHO(txtCustCode.Text, txtFind.Text, txtContactNo.Text, _nType, _nWarehouseID);
            }
            foreach (RetailConsumer oRetailConsumer in _oRetailConsumers)
            {
                ListViewItem lstItem = lvwCustomer.Items.Add(oRetailConsumer.ConsumerCode.ToString());
                lstItem.SubItems.Add(oRetailConsumer.ConsumerName.ToString());
                lstItem.SubItems.Add(oRetailConsumer.CellNo.ToString());
                lstItem.SubItems.Add(Enum.GetName(typeof(Dictionary.SalesType), oRetailConsumer.SalesType));
                lstItem.SubItems.Add(oRetailConsumer.CustomerCode.ToString());
                lstItem.SubItems.Add(oRetailConsumer.CustomerName.ToString());
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

            oRetailConsumer.ConsumerCode = _oRetailConsumer.ConsumerCode;
            oRetailConsumer.ConsumerName = _oRetailConsumer.ConsumerName;
            oRetailConsumer.CustomerName = _oRetailConsumer.CustomerName;
            oRetailConsumer.CustomerCode = _oRetailConsumer.CustomerCode;
            this.Close();
        }

        private void lvwCustomer_DoubleClick_1(object sender, EventArgs e)
        {
            RetailConsumer _oRetailConsumer = (RetailConsumer)lvwCustomer.SelectedItems[0].Tag;

            oRetailConsumer.ConsumerCode = _oRetailConsumer.ConsumerCode;
            oRetailConsumer.ConsumerName = _oRetailConsumer.ConsumerName;
            oRetailConsumer.CustomerName = _oRetailConsumer.CustomerName;
            oRetailConsumer.CustomerCode = _oRetailConsumer.CustomerCode;
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

        private void frmReatilConsumerSearch_Load(object sender, EventArgs e)
        {

        }
    }
}
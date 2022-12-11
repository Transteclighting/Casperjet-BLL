using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class.POS;
using CJ.Class;


namespace CJ.Win.POS
{
    public partial class frmPaymentModes : Form
    {
        PaymentMode _oPaymentMode;
        PaymentModes _oPaymentModes;

        public frmPaymentModes()
        {
            InitializeComponent();
        }

        private void frmPaymentMode_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            DBController.Instance.OpenNewConnection();
            _oPaymentModes = new PaymentModes();
            _oPaymentModes.Refresh();
            lvwPaymentMode.Items.Clear();

            foreach (PaymentMode oPaymentMode in _oPaymentModes)
            {
                ListViewItem lstItem = lvwPaymentMode.Items.Add(oPaymentMode.PaymentModeID.ToString());
                lstItem.SubItems.Add(oPaymentMode.PaymentModeName.ToString());
                lstItem.SubItems.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), oPaymentMode.IsReceivableItem));
                lstItem.SubItems.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), oPaymentMode.IsFinancialInstitution));
                lstItem.SubItems.Add(oPaymentMode.BankName.ToString());
                lstItem.SubItems.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), oPaymentMode.IsActive));
                lstItem.SubItems.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), oPaymentMode.IsMandatoryInstrumentNo));
                lstItem.SubItems.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), oPaymentMode.IsEligableforAdvance));
                lstItem.SubItems.Add(Enum.GetName(typeof(Dictionary.PaymentModeType), oPaymentMode.PaymentModeType));
                lstItem.Tag = oPaymentMode;
            }
            this.Text = @"Total" + @"[" + _oPaymentModes.Count + @"]";

        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            frmPaymentMode oForm = new frmPaymentMode();
            oForm.ShowDialog();
            LoadData();
        }

        private void btEdit_Click(object sender, EventArgs e)
        {
            if (lvwPaymentMode.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PaymentMode oPaymentMode = (PaymentMode)lvwPaymentMode.SelectedItems[0].Tag;
            frmPaymentMode oForm = new frmPaymentMode();
            oForm.ShowDialog(oPaymentMode);
            LoadData();

        }
        private void double_Click(object sender, EventArgs e)
        {
            if (lvwPaymentMode.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            PaymentMode oPaymentMode = (PaymentMode)lvwPaymentMode.SelectedItems[0].Tag;
            frmPaymentMode oForm = new frmPaymentMode();
            oForm.ShowDialog(oPaymentMode);
            LoadData();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.CSD;
using CJ.Class;
using CJ.Class.Report;
using CJ.Win.Security;


namespace CJ.Win
{
    public partial class frmChannelSearchCSD : Form
    {
        private ChannelFromCassandra _oChannelFromCassandra;

        public frmChannelSearchCSD()
        {
            InitializeComponent();
        }

        private void frmChannelSearchCSD_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void DataLoadControl()
        {

            ChannelFromCassandras oChannelFromCassandras = new ChannelFromCassandras();

            lvwChannelSearch.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oChannelFromCassandras.Refresh(txtCode.Text,txtName.Text,txtChannel.Text,txtContactNo.Text,txtAddress.Text);
            this.Text = "Total = " + "[" + oChannelFromCassandras.Count + "]";
            foreach (ChannelFromCassandra oChannelFromCassandra in oChannelFromCassandras)
            {
                ListViewItem oItem = lvwChannelSearch.Items.Add(oChannelFromCassandra.Code.ToString());
                oItem.SubItems.Add(oChannelFromCassandra.Name);
                oItem.SubItems.Add(oChannelFromCassandra.Mobile);
                oItem.SubItems.Add(oChannelFromCassandra.Address);
                oItem.SubItems.Add(oChannelFromCassandra.Type);

                oItem.Tag = oChannelFromCassandra;
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtCode.Text = "";
            txtName.Text = "";
            txtChannel.Text = "";
            txtContactNo.Text = "";
            txtAddress.Text = "";
            DataLoadControl();
        }



        private void lvwChannelSearch_DoubleClick(object sender, EventArgs e)
        {

            ChannelFromCassandra oChannelFromCassandra = (ChannelFromCassandra)lvwChannelSearch.SelectedItems[0].Tag;

            _oChannelFromCassandra.Code = oChannelFromCassandra.Code;
            _oChannelFromCassandra.Name = oChannelFromCassandra.Name;
            this.Close();
        }

        private void lvwChannelSearch_KeyPress(object sender, KeyPressEventArgs e)
        {

            ChannelFromCassandra oChannelFromCassandra = (ChannelFromCassandra)lvwChannelSearch.SelectedItems[0].Tag;

            _oChannelFromCassandra.Code = oChannelFromCassandra.Code;
            _oChannelFromCassandra.Name = oChannelFromCassandra.Name;

            this.Close();
        }

        public bool ShowDialog(ChannelFromCassandra oChannelFromCassandra)
        {
            _oChannelFromCassandra = oChannelFromCassandra;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.ShowDialog();
            return true;
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void txtChannel_TextChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void txtContactNo_TextChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }

    }

}
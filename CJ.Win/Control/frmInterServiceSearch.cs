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
    public partial class frmInterServiceSearch : Form
    {
        private InterServiceR _oInterServiceR;

        public frmInterServiceSearch()
        {
            InitializeComponent();
        }
        private void frmInterServiceSearch_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void DataLoadControl()
        {

            InterServicesR oInterServicesR = new InterServicesR();

            lvwInterServiceSearch.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oInterServicesR.Refresh(txtCode.Text, txtName.Text, txtPhone.Text, txtMobile.Text, txtAddress.Text);
            this.Text = "Total = " + "[" + oInterServicesR.Count + "]";
            foreach (InterServiceR oInterServiceR in oInterServicesR)
            {
                ListViewItem oItem = lvwInterServiceSearch.Items.Add(oInterServiceR.Code.ToString());
                oItem.SubItems.Add(oInterServiceR.Name);
                oItem.SubItems.Add(oInterServiceR.Mobile);
                oItem.SubItems.Add(oInterServiceR.Phone);
                oItem.SubItems.Add(oInterServiceR.Address);

                oItem.Tag = oInterServiceR;
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
            txtPhone.Text = "";
            txtMobile.Text = "";
            txtAddress.Text = "";
            DataLoadControl();
        }

        private void lvwInterServiceSearch_DoubleClick(object sender, EventArgs e)
        {

            InterServiceR oInterServiceR = (InterServiceR)lvwInterServiceSearch.SelectedItems[0].Tag;

            _oInterServiceR.Code = oInterServiceR.Code;
            _oInterServiceR.Name = oInterServiceR.Name;
            this.Close();
        }

        private void lvwInterServiceSearch_KeyPress(object sender, KeyPressEventArgs e)
        {

            InterServiceR oInterServiceR = (InterServiceR)lvwInterServiceSearch.SelectedItems[0].Tag;

            _oInterServiceR.Code = oInterServiceR.Code;
            _oInterServiceR.Name = oInterServiceR.Name;
            this.Close();
        }

        public bool ShowDialog(InterServiceR oInterServiceR)
        {
            _oInterServiceR = oInterServiceR;
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

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void txtMobile_TextChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }
    }
}
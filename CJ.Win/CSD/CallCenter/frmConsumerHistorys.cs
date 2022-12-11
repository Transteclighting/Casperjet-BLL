using System;
using System.Drawing;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.CSD.CallCenter
{
    public partial class frmConsumerHistorys : Form
    {
        Customers _oConsumerDetails;


        private void SetListViewRowColour()
        {
            if (lvwConsumerDetails.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwConsumerDetails.Items)
                {
                    if (oItem.SubItems[7].Text == "Verified")
                    {
                        oItem.BackColor = Color.White;
                    }
                    else
                    {
                        oItem.BackColor = Color.LightPink;
                    }

                }
            }
        }

        public frmConsumerHistorys()
        {
            InitializeComponent();
            Cursor = Cursors.Default;
        }

        private void DataLoadControl()
        {
            try
            {

            Cursor = Cursors.WaitCursor;
            lvwConsumerDetails.Items.Clear();
            if (txtMobileNo.Text != "")
            {
                DBController.Instance.OpenNewConnection();
                _oConsumerDetails = new Customers();
                _oConsumerDetails.GetConsumerDetails(txtMobileNo.Text.Trim());
                DBController.Instance.CloseConnection();
                foreach (Customer oCustomerList in _oConsumerDetails)
                {
                    ListViewItem oItem = lvwConsumerDetails.Items.Add(oCustomerList.CustomerCode);
                    oItem.SubItems.Add(oCustomerList.CustomerName);
                    oItem.SubItems.Add(oCustomerList.MobileNo);
                    oItem.SubItems.Add(oCustomerList.AlternativeCellNo);
                    oItem.SubItems.Add(oCustomerList.CustomerTelephone);
                    oItem.SubItems.Add(oCustomerList.CustomerAddress);
                    oItem.SubItems.Add(oCustomerList.EmailAddress);
                    oItem.SubItems.Add(Enum.GetName(typeof (Dictionary.IsVerified), oCustomerList.IsVerified));
                    oItem.Tag = oCustomerList;
                }
                SetListViewRowColour();
                Text = @"Consumer Detail-" + _oConsumerDetails.Count + "";
            }
            else
            {
                MessageBox.Show(@"Please Enter Mobile Number First", @"Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            Cursor = Cursors.Default;
        }

    catch (Exception x)
            {
                MessageBox.Show(string.Format(@"An error occurred in your application. Please try after sometimes " + "\n" + "{0}", x), @"Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Cursor = Cursors.Default;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGetHistory_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (lvwConsumerDetails.SelectedItems.Count == 0)
            {
                MessageBox.Show(@"Please select a data to get history.", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Customer oCustomer = (Customer)lvwConsumerDetails.SelectedItems[0].Tag;
            frmConsumerHistory oForm = new frmConsumerHistory();
            oForm.ShowDialog(oCustomer);
            Cursor = Cursors.Default;
            //DataLoadControl();


        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

    }
}
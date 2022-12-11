using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.Dealer
{
    public partial class frmDealerUsers : Form
    {
        DealerUsers _oDealerUsers;
        public frmDealerUsers()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmDealerUser oForm = new frmDealerUser();
            oForm.ShowDialog();
            DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwDealerUsers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select A Row To Edit", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DealerUser oDealerUser = (DealerUser)lvwDealerUsers.SelectedItems[0].Tag;
            frmDealerUser oform = new frmDealerUser();
            oform.ShowDialog(oDealerUser);
            DataLoadControl();
        }
       
        private void btnClos_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDealerUsers_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void DataLoadControl()
        {
            DBController.Instance.OpenNewConnection();
            _oDealerUsers = new DealerUsers();
            DBController.Instance.OpenNewConnection();
            _oDealerUsers.GetData();
            this.Text = "Dealer User | Total: " + "[" + _oDealerUsers.Count + "]";
            lvwDealerUsers.Items.Clear();
            foreach (DealerUser oDealerUser in _oDealerUsers)
            {
                ListViewItem oItem = lvwDealerUsers.Items.Add(oDealerUser.UserID.ToString());
                oItem.SubItems.Add(oDealerUser.UserName.ToString());
                oItem.SubItems.Add(oDealerUser.CreatedBy.ToString());
                oItem.Tag = oDealerUser;
            }
        }

        private void btnClos_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
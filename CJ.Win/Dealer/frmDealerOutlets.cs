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
    public partial class frmDealerOutlets : Form
    {
        DealerOutlets _oDealerOutlets;
        public frmDealerOutlets()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmDealerOutlet oFrom = new frmDealerOutlet();
            oFrom.Show();
            DataLoadControl();
        }
        

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwDealerOutlet.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select A Row To Edit", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DealerOutlet oDealerOutlet = (DealerOutlet)lvwDealerOutlet.SelectedItems[0].Tag;
            frmDealerOutlet oform = new frmDealerOutlet();
            oform.ShowDialog(oDealerOutlet);
            DataLoadControl();
        }
        private void DataLoadControl()
        {
            DBController.Instance.OpenNewConnection();
            _oDealerOutlets = new DealerOutlets();
            DBController.Instance.OpenNewConnection();
            _oDealerOutlets.Getdata();
            this.Text = "Dealer Outlet | Total: " + "[" + _oDealerOutlets.Count + "]";
            lvwDealerOutlet.Items.Clear();
            foreach (DealerOutlet oDealerOutlet in _oDealerOutlets)
            {
                ListViewItem oItem = lvwDealerOutlet.Items.Add(oDealerOutlet.CustomerCode.ToString());
                oItem.SubItems.Add(oDealerOutlet.OutletName.ToString());
                oItem.SubItems.Add(oDealerOutlet.Address.ToString());
                oItem.SubItems.Add(oDealerOutlet.ContactPerson.ToString());
                oItem.SubItems.Add(oDealerOutlet.ContactNo.ToString());
                oItem.SubItems.Add(oDealerOutlet.Email.ToString());
                oItem.SubItems.Add(oDealerOutlet.CreatedBy.ToString());
                oItem.Tag = oDealerOutlet;
            }

        }

        private void frmDealerOutlets_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

       
    }
}
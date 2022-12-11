using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.BEIL;

namespace CJ.Win.BEIL
{
    public partial class frmSalesOrderFactorys : Form
    {
        SalesOrderFactorys oSalesOrderFactorys;
        Customers _oCustomers;
        bool IsCheck = false;
        public frmSalesOrderFactorys()
        {
            InitializeComponent();
        }

        private void frmSalesOrderFactorys_Load(object sender, EventArgs e)
        {
            LoadCombo();
        }
        private void LoadCombo()
        {
            //dtFromDate.Value = DateTime.Today;
            //dtToDate.Value = DateTime.Today;

            cmbStatus.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SalesOrderFactoryStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.SalesOrderFactoryStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;
        }
        private void DataLoadControl()
        {
            this.Cursor = Cursors.WaitCursor;           
            int nStatus = -1;
            if (cmbStatus.SelectedIndex != 0)
            {
                nStatus = cmbStatus.SelectedIndex;
            }
            oSalesOrderFactorys = new SalesOrderFactorys();
            lvwSalesOrderFactorys.Items.Clear();

            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            oSalesOrderFactorys.RefreshBySalesOrderFactory(dtFromDate.Value.Date, dtToDate.Value.Date, txtCustomer.Text.Trim(),nStatus, IsCheck);

            foreach (SalesOrderFactory oSalesOrderFactory in oSalesOrderFactorys)
            {
                ListViewItem oItem = lvwSalesOrderFactorys.Items.Add(oSalesOrderFactory.CustomerName);
                oItem.SubItems.Add(oSalesOrderFactory.OrderNumber);
                oItem.SubItems.Add(Convert.ToDateTime(oSalesOrderFactory.OrderDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oSalesOrderFactory.OrderValue.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.SalesOrderFactoryStatus), oSalesOrderFactory.Status));
                oItem.SubItems.Add(oSalesOrderFactory.Remarks);
                oItem.Tag = oSalesOrderFactory;
            }
            this.Text = " Total " + "[" + oSalesOrderFactorys.Count + "]";
            this.Cursor = Cursors.Default;
            setListViewRowColour();
        }

        private void setListViewRowColour()
        {
            if (lvwSalesOrderFactorys.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwSalesOrderFactorys.Items)
                {
                    if (oItem.SubItems[4].Text == "Delivered")
                    {
                        oItem.BackColor = Color.White;
                    }
                    else if (oItem.SubItems[4].Text == "Create")
                    {
                        oItem.BackColor = Color.LightGreen;
                    }
                    else if (oItem.SubItems[4].Text == "Partial_Delivery")
                    {
                        oItem.BackColor = Color.SandyBrown;
                    }
                    else if (oItem.SubItems[4].Text == "Cancel")
                    {
                        oItem.BackColor = Color.Orange;
                    }
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmSalesOrderFactory oForm = new frmSalesOrderFactory((int)Dictionary.SalesOrderFactoryStatus.Create);
            oForm.ShowDialog();
            DataLoadControl();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void btnDelivery_Click(object sender, EventArgs e)
        {
            if (lvwSalesOrderFactorys.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Item for delivery.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (lvwSalesOrderFactorys.SelectedItems[0].SubItems[4].Text == "Cancel")
            {
                MessageBox.Show("Cancel Status Can't be Delivery", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SalesOrderFactory oSalesOrderFactory = (SalesOrderFactory)lvwSalesOrderFactorys.SelectedItems[0].Tag;
            if (oSalesOrderFactory.Status != ((int)Dictionary.SalesOrderFactoryStatus.Delivered))
            {
                frmSalesOrderFactoryDelivery oForm = new frmSalesOrderFactoryDelivery((int)Dictionary.SalesOrderFactoryStatus.Partial_Delivery);
                oForm.ShowDialog(oSalesOrderFactory);
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Only Create & Pertial Delivery status can be Delivery.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                dtFromDate.Enabled = false;
                dtToDate.Enabled = false;
                IsCheck = true;
            }
            else
            {
                dtFromDate.Enabled = true;
                dtToDate.Enabled = true;
                IsCheck = false;
            }
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (lvwSalesOrderFactorys.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Item to Cancel.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (lvwSalesOrderFactorys.SelectedItems[0].SubItems[4].Text == "Cancel")
            {
                MessageBox.Show("Cancel Status Can't be Cancel", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (lvwSalesOrderFactorys.SelectedItems[0].SubItems[4].Text == "Partial_Delivery")
            {
                MessageBox.Show("Partial_Delivery Status Can't be Cancel", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SalesOrderFactory oSalesOrderFactory = (SalesOrderFactory)lvwSalesOrderFactorys.SelectedItems[0].Tag;
            if (oSalesOrderFactory.Status != ((int)Dictionary.SalesOrderFactoryStatus.Delivered))
            {
                frmSalesOrderFactoryDelivery oForm = new frmSalesOrderFactoryDelivery((int)Dictionary.SalesOrderFactoryStatus.Cancel);
                oForm.ShowDialog(oSalesOrderFactory);
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Only Create status can be Cancel.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}

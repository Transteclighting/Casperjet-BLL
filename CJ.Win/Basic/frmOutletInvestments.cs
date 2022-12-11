using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CJ.Class.BasicData;
using CJ.Class;

namespace CJ.Win.Basic
{
    public partial class frmOutletInvestments : Form
    {
        OutletInvestment oOutletInvestment;
        OutletInvestments oOutletInvestments;
        public frmOutletInvestments()
        {
            InitializeComponent();
        }

        private void frmOutletInvestments_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            lvwData.Items.Clear();
            DBController.Instance.OpenNewConnection();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            oOutletInvestments = new OutletInvestments();
            oOutletInvestments.Refresh();

            foreach (OutletInvestment oOutletInvestment in oOutletInvestments)
            {
                ListViewItem oItem = lvwData.Items.Add(oOutletInvestment.Description);
                oItem.SubItems.Add(oOutletInvestment.Amount.ToString());
                oItem.SubItems.Add(oOutletInvestment.Remarks);
                //oItem.SubItems.Add(Utility.Username);
                //oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), oOutletInvestment.IsActive));
                oItem.Tag = oOutletInvestment;
            }
            this.Text = " Total " + "[" + oOutletInvestments.Count + "]";
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmOutletInvestment oForm = new frmOutletInvestment();
            oForm.ShowDialog();
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwData.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a item to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            oOutletInvestment = (OutletInvestment)lvwData.SelectedItems[0].Tag;
            frmOutletInvestment oForm = new frmOutletInvestment();
            oForm.ShowDialog(oOutletInvestment);
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwData.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a item to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            oOutletInvestment = (OutletInvestment)lvwData.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete: " + oOutletInvestment.InvestmentID + " ? ", "Confirm OutletInvestment Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oOutletInvestment.Delete();
                    DBController.Instance.CommitTransaction();
                    LoadData();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

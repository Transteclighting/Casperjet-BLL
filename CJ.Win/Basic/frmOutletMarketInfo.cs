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
    public partial class frmOutletMarketInfo : Form
    {
        OutletMarketInfo oOutletMarketInfo;
        public frmOutletMarketInfo()
        {
            InitializeComponent();
        }
        public void ShowDialog(OutletMarketInfo oOutletMarketInfo)
        {
            this.Tag = oOutletMarketInfo;
            LoadCombo();
            txtDesc.Text = oOutletMarketInfo.Description;
            txtDesc.Text = oOutletMarketInfo.Description.ToString();
            cmbMarketType.SelectedIndex = oOutletMarketInfo.MarketType;
            this.ShowDialog();
        }
        private void frmOutletMarketInfo_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                LoadCombo();
            }
        }
        private void LoadCombo()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            cmbMarketType.Items.Clear();
            cmbMarketType.Items.Add("---Select All---");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.OutletMarketType)))
            {
                cmbMarketType.Items.Add(Enum.GetName(typeof(Dictionary.OutletMarketType), GetEnum));
            }
            cmbMarketType.SelectedIndex = 0;

        }
        private bool ValidateUI()
        {
            if (txtDesc.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Description", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDesc.Focus();
                return false;
            }
            if (cmbMarketType.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Market Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbMarketType.Focus();
                return false;
            }
            return true;
        }

        private void Save()
        {
            if (this.Tag == null)
            {
                oOutletMarketInfo = new OutletMarketInfo();
                oOutletMarketInfo.Description = txtDesc.Text;
                oOutletMarketInfo.MarketType = cmbMarketType.SelectedIndex;
                oOutletMarketInfo.CreateUser = Utility.UserId;
                oOutletMarketInfo.CreateDate = DateTime.Now;
                

                try
                {

                    DBController.Instance.BeginNewTransaction();
                    oOutletMarketInfo.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Transaction : " + oOutletMarketInfo.ID, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

            else
            {
                oOutletMarketInfo = (OutletMarketInfo)this.Tag;
                oOutletMarketInfo.Description = txtDesc.Text;
                oOutletMarketInfo.MarketType = cmbMarketType.SelectedIndex;
                //oOutletMarketInfo.CreateUser = Utility.UserId;
                //oOutletMarketInfo.CreateDate = DateTime.Now;
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oOutletMarketInfo.Edit();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update: " + oOutletMarketInfo.ID, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateUI())
            {
                Save();
            }
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

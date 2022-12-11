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
    public partial class frmOutletFeasibilityTypes : Form
    {
        OutletFeasibilityTypeDetails _oOutletFeasibilityTypeDetails;
        OutletFeasibilityType _oOutletFeasibilityType;
        public frmOutletFeasibilityTypes()
        {
            InitializeComponent();
        }

        private void frmOutletFeasibilityTypes_Load(object sender, EventArgs e)
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
            _oOutletFeasibilityTypeDetails = new OutletFeasibilityTypeDetails();
            _oOutletFeasibilityTypeDetails.Refresh();

            foreach (OutletFeasibilityType oOutletFeasibilityType in _oOutletFeasibilityTypeDetails)
            {
                ListViewItem oItem = lvwData.Items.Add(oOutletFeasibilityType.OutletFeasibilityTypeName);
                oItem.SubItems.Add(Utility.Username);
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), oOutletFeasibilityType.IsActive));
                oItem.Tag = oOutletFeasibilityType;
            }
            this.Text = " Total " + "[" + _oOutletFeasibilityTypeDetails.Count + "]";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmOutletFeasibilityType oForm = new frmOutletFeasibilityType();
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
            _oOutletFeasibilityType = (OutletFeasibilityType)lvwData.SelectedItems[0].Tag;
            frmOutletFeasibilityType oForm = new frmOutletFeasibilityType();
            oForm.ShowDialog(_oOutletFeasibilityType);
            LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwData.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a item to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _oOutletFeasibilityType = (OutletFeasibilityType)lvwData.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete OutletFeasibilityType: " + _oOutletFeasibilityType.OutletFeasibilityTypeID + " ? ", "Confirm OutletFeasibilityType Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oOutletFeasibilityType.Delete();
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
    }
}

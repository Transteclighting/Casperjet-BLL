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
using CJ.Class.SupplyChain;

namespace CJ.Win.SupplyChain
{
    public partial class frmBEILProductBOMs : Form
    {

        private BEILProductBOMs _oBEILProductBOMs;
        private BEILProductBOM _oBEILProductBOM;

        public frmBEILProductBOMs()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmBEILProductBOM oForm = new frmBEILProductBOM();
            oForm.ShowDialog();
            if (oForm._bActionSave)
                LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwBEILProdBOM.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            BEILProductBOM oBEILProductBOM = (BEILProductBOM)lvwBEILProdBOM.SelectedItems[0].Tag;

            frmBEILProductBOM ofrmBEILProductBOM = new frmBEILProductBOM();
            ofrmBEILProductBOM.ShowDialog(oBEILProductBOM);
            if (ofrmBEILProductBOM._bActionSave)
                LoadData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwBEILProdBOM.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BEILProductBOM oBEILProductBOM = (BEILProductBOM)lvwBEILProdBOM.SelectedItems[0].Tag;

            DialogResult oResult = MessageBox.Show("Are you sure you want to delete : " + oBEILProductBOM.ProductCode + " ? ", "Confirm To Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            BEILProductBOMDetail _oBEILProductBOMDetail = new BEILProductBOMDetail();

            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oBEILProductBOMDetail.Delete(oBEILProductBOM.BOMID);
                    oBEILProductBOM.Delete();
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

        private void LoadData()
        {
            _oBEILProductBOMs = new BEILProductBOMs();
            lvwBEILProdBOM.Items.Clear();
            DBController.Instance.OpenNewConnection();

            int nProductID = 0;
            if (ctlProduct1.txtDescription.Text == "")
            {
                nProductID = -1;
            }
            else
            {
                nProductID = ctlProduct1.SelectedSerarchProduct.ProductID;
            }


            _oBEILProductBOMs.Refresh(nProductID);

            foreach (BEILProductBOM oBEILProductBOM in _oBEILProductBOMs)
            {
                ListViewItem oItem = lvwBEILProdBOM.Items.Add(oBEILProductBOM.ProductCode.ToString());
                oItem.SubItems.Add(oBEILProductBOM.ProductName.ToString());
                oItem.Tag = oBEILProductBOM;
            }
            this.Text = "BEIL Product Bill of Materials-" + _oBEILProductBOMs.Count + "";

        }


        private void double_Click(object sender, EventArgs e)
        {
            if (lvwBEILProdBOM.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            BEILProductBOM oBEILProductBOM = (BEILProductBOM)lvwBEILProdBOM.SelectedItems[0].Tag;

            frmBEILProductBOM ofrmBEILProductBOM = new frmBEILProductBOM();
            ofrmBEILProductBOM.ShowDialog(oBEILProductBOM);
            if (ofrmBEILProductBOM._bActionSave)
                LoadData();
        }

        private void frmBEILProductBOMs_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}

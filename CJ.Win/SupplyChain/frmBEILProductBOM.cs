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
    public partial class frmBEILProductBOM : Form
    {
        public frmBEILProductBOM()
        {
            InitializeComponent();
        }

        private string checkDuplicateValue;

        BEILProductBOM _oBEILProductBOM;

        SCMBOMs _oSCMBOMs;


        public bool _bActionSave = false;
        int nID = 0;


        public void ShowDialog(BEILProductBOM oBEILProductBOM)
        {
            this.Tag = oBEILProductBOM;
            nID = oBEILProductBOM.BOMID;
            ctlProduct1.txtCode.Text = oBEILProductBOM.ProductCode;

            this.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                Save();
                _bActionSave = true;
                this.Close();
            }
        }

        private void Save()
        {
            if (this.Tag == null)
            {

                try
                {
                    BEILProductBOM oBEILProductBOM = new BEILProductBOM();
                    foreach (ListViewItem item in lvwBEILProductBOMList2.Items)
                    {
                        BEILProductBOMDetail oBEILProductBOMDetail = new BEILProductBOMDetail();

                        oBEILProductBOMDetail.BOMGroupID = Int32.Parse(item.SubItems[0].Text);
                        oBEILProductBOMDetail.FMTCOMP = item.SubItems[2].Text;
                        oBEILProductBOMDetail.COMPDESC = item.SubItems[3].Text;
                        oBEILProductBOMDetail.Qty = Int32.Parse(item.SubItems[4].Text);
                        oBEILProductBOMDetail.Unit = item.SubItems[5].Text;
                        oBEILProductBOMDetail.CostAllocationPercent = Double.Parse(item.SubItems[6].Text);
   
                        oBEILProductBOM.Add(oBEILProductBOMDetail);
                    }                    

                    oBEILProductBOM.ProductID = ctlProduct1.SelectedSerarchProduct.ProductID;
                    oBEILProductBOM.CreateDate = DateTime.Now.Date;
                    oBEILProductBOM.CreateUserID = Utility.UserId;

                    DBController.Instance.BeginNewTransaction();
                    oBEILProductBOM.Add();
                    DBController.Instance.CommitTran();

                    MessageBox.Show("Your data has been saved successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
            else
            {
                try
                {
                    BEILProductBOM oBEILProductBOM = new BEILProductBOM();

                    foreach (ListViewItem item in lvwBEILProductBOMList2.Items)
                    {
                        BEILProductBOMDetail oBEILProductBOMDetail = new BEILProductBOMDetail();
                        oBEILProductBOMDetail.BOMID = (nID);
                        oBEILProductBOMDetail.BOMGroupID = Int32.Parse(item.SubItems[0].Text);
                        oBEILProductBOMDetail.FMTCOMP = item.SubItems[2].Text;
                        oBEILProductBOMDetail.COMPDESC = item.SubItems[3].Text;
                        oBEILProductBOMDetail.Qty = Int32.Parse(item.SubItems[4].Text);
                        oBEILProductBOMDetail.Unit = item.SubItems[5].Text;
                        oBEILProductBOMDetail.CostAllocationPercent = Double.Parse(item.SubItems[6].Text);

                        oBEILProductBOM.Add(oBEILProductBOMDetail);
                    }

                    oBEILProductBOM.UpdateDate = DateTime.Now.Date;
                    oBEILProductBOM.UpdateUserID = Utility.UserId;
                    oBEILProductBOM.BOMID = nID;
                    DBController.Instance.BeginNewTransaction();
                    oBEILProductBOM.Edit();
                    DBController.Instance.CommitTran();

                    MessageBox.Show("Your data has been updated successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }



        private bool UIValidation()
        {
            if (ctlProduct1.txtCode.Text.Trim() == "")
            {
                MessageBox.Show("Please input a product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlProduct1.txtCode.Focus();
                return false;
            }

            if (lvwBEILProductBOMList2.Items.Count == 0)
            {
                MessageBox.Show("Please insert list data.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;

        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void double_Click(object sender, EventArgs e)
        {
            var selectedItem = lvwBEILProductBOMList2.SelectedItems[0];

            cmbBOMGroup.SelectedIndex = _oSCMBOMs.GetIndex(Int32.Parse(selectedItem.SubItems[0].Text) + 1);

            txtFMTComp.Text = selectedItem.SubItems[2].Text;
            txtDesc.Text = selectedItem.SubItems[4].Text;
            txtQty.Text = selectedItem.SubItems[4].Text;
            txtUnit.Text = selectedItem.SubItems[5].Text;
            txtCostAllocation.Text = selectedItem.SubItems[6].Text;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (UIValidationForList())
            {
                AddBOMDetailsList();
            }
        }

        private void AddBOMDetailsList()
        {
            ListViewItem oItemExist = lvwBEILProductBOMList2.FindItemWithText(txtFMTComp.Text.ToString());

            if (oItemExist == null)
            {
                ListViewItem oItem = lvwBEILProductBOMList2.Items.Add(_oSCMBOMs[cmbBOMGroup.SelectedIndex - 1].BOMID.ToString());
                oItem.SubItems.Add(_oSCMBOMs[cmbBOMGroup.SelectedIndex - 1].BOMDescription.ToString());
                oItem.SubItems.Add(txtFMTComp.Text);
                oItem.SubItems.Add(txtDesc.Text);
                oItem.SubItems.Add(txtQty.Text);
                oItem.SubItems.Add(txtUnit.Text);
                oItem.SubItems.Add(txtCostAllocation.Text);
            }

            else {

                MessageBox.Show("FMTComp already exists!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool UIValidationForList()
        {

            if (cmbBOMGroup.SelectedIndex == 0)
            {
                MessageBox.Show("Please select BOM Group", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbBOMGroup.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtFMTComp.Text))
            {
                MessageBox.Show("Please insert fmtComp", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFMTComp.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtDesc.Text))
            {
                MessageBox.Show("Please insert description", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDesc.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtQty.Text))
            {
                MessageBox.Show("Please insert quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQty.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtUnit.Text))
            {
                MessageBox.Show("Please insert unit", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUnit.Focus();
                return false;
            }

            if (string.IsNullOrEmpty(txtCostAllocation.Text))
            {
                MessageBox.Show("Please insert cost allocation percent", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCostAllocation.Focus();
                return false;
            }

            return true;

        }

        private void txtFMTComp_TextChanged(object sender, EventArgs e)
        {

        }

        private void ctlProduct1_ChangeSelection(object sender, EventArgs e)
        {
            _oBEILProductBOM = new BEILProductBOM();
            int nBOMID = _oBEILProductBOM.RefreshByProductID(ctlProduct1.SelectedSerarchProduct.ProductID);
            if (nBOMID != 0)
            {
                nID = nBOMID;
                this.Tag = "x";
                _oBEILProductBOM.GetBOMDetail();
                foreach (BEILProductBOMDetail oBomDetail in _oBEILProductBOM)
                {
                    ListViewItem oItem = lvwBEILProductBOMList2.Items.Add(oBomDetail.BOMGroupID.ToString());
                    oItem.SubItems.Add(oBomDetail.BOMGroupName);
                    oItem.SubItems.Add(oBomDetail.FMTCOMP);
                    oItem.SubItems.Add(oBomDetail.COMPDESC);
                    oItem.SubItems.Add(oBomDetail.Qty.ToString());
                    oItem.SubItems.Add(oBomDetail.Unit);
                    oItem.SubItems.Add(oBomDetail.CostAllocationPercent.ToString());
                }

            }
             _oSCMBOMs = new SCMBOMs();
            _oSCMBOMs.GetBOMList(ctlProduct1.SelectedSerarchProduct.ProductID);
            cmbBOMGroup.Items.Clear();
            cmbBOMGroup.Items.Add("--Select BOM Group--");
            foreach (SCMBOM __oSCMBOM in _oSCMBOMs)
            {
                cmbBOMGroup.Items.Add(__oSCMBOM.BOMDescription);
            }
            cmbBOMGroup.SelectedIndex = 0;

            ctlProduct1.Enabled = false;
        }

        //private void btnDelete_Click(object sender, EventArgs e)
        //{
        //    DialogResult oResult = MessageBox.Show("Are you sure you want to delete this item ? ", "Confirm To Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

        //    if (oResult == DialogResult.Yes)
        //    {
        //        try
        //        {
        //            foreach (ListViewItem eachItem in lvwBEILProductBOMList2.SelectedItems)
        //            {
        //                lvwBEILProductBOMList2.Items.Remove(eachItem);
        //            }

        //        }
        //        catch (Exception ex)
        //        {
        //            DBController.Instance.RollbackTransaction();
        //            MessageBox.Show(ex.Message, "Error!!!");
        //        }

        //    }



        //}

        private void IntegerOnly_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Double_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void linkDelete_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete this item ? ", "Confirm To Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (oResult == DialogResult.Yes)
            {
                try
                {
                    foreach (ListViewItem eachItem in lvwBEILProductBOMList2.SelectedItems)
                    {
                        lvwBEILProductBOMList2.Items.Remove(eachItem);
                    }

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

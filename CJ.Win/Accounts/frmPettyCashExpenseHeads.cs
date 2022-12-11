using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;

namespace CJ.Win.Accounts
{
    public partial class frmPettyCashExpenseHeads : Form
    {
        PettyCashExpenseHeads _oPettyCashExpenseHeads;
        public frmPettyCashExpenseHeads()
        {
            InitializeComponent();
        }

        private void frmPettyCashExpenseHeads_Load(object sender, EventArgs e)
        {
            LoadCombos();
            LoadData();
        }
        private void LoadCombos()
        {
            cmbIsActive.Items.Clear();
            cmbIsActive.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.YesOrNoStatus)))
            {
                cmbIsActive.Items.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), GetEnum));
            }
            cmbIsActive.SelectedIndex = 0;
        }
        private void LoadData()
        {
            _oPettyCashExpenseHeads = new PettyCashExpenseHeads();
            lvwPettyCashExpenseHead.Items.Clear();
            this.Cursor = Cursors.WaitCursor;
            
            int nIsActive= 0;
            if (cmbIsActive.SelectedIndex == 0)
            {
                nIsActive = -1;
            }
            else
            {
                nIsActive = cmbIsActive.SelectedIndex -1;
            }

            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            _oPettyCashExpenseHeads.Refresh(txtDescription.Text.Trim(),nIsActive);
            foreach (PettyCashExpenseHead oPettyCashExpenseHead in _oPettyCashExpenseHeads)
            {
                ListViewItem oItem = lvwPettyCashExpenseHead.Items.Add(oPettyCashExpenseHead.Description);                
                oItem.SubItems.Add(oPettyCashExpenseHead.CreateDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oPettyCashExpenseHead.UserName.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), oPettyCashExpenseHead.IsActive));
                oItem.Tag = oPettyCashExpenseHead;
            }
            this.Text = "Total Expense Head = " + _oPettyCashExpenseHeads.Count + "";
            this.Cursor = Cursors.Default;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmPettyCashExpenseHead oForm = new frmPettyCashExpenseHead();
            oForm.ShowDialog();
            if (oForm.IsTrue == true)
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwPettyCashExpenseHead.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Item to Edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            PettyCashExpenseHead oPettyCashExpenseHead = (PettyCashExpenseHead)lvwPettyCashExpenseHead.SelectedItems[0].Tag;
            frmPettyCashExpenseHead oForm = new frmPettyCashExpenseHead();
            oForm.ShowDialog(oPettyCashExpenseHead);
            if (oForm.IsTrue == true)
                LoadData();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}

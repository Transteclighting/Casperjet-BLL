using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.CSD;
using CJ.Class;

namespace CJ.Win
{
    public partial class frmSPTranTypes : Form
    {
        public frmSPTranTypes()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void DataLoadControl()
        {

            SPTranTypes oSPTranTypes = new SPTranTypes();
            
            lvwSPTranTypes.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oSPTranTypes.Refresh();

            this.Text = "Total " + "[" + oSPTranTypes.Count + "]";
            foreach (SPTranType oSPTranType in oSPTranTypes)
            {
                ListViewItem oItem = lvwSPTranTypes.Items.Add(oSPTranType.SPTranTypeID.ToString());
                oItem.SubItems.Add(oSPTranType.Name.ToString());
                if (oSPTranType.TranSide == (int)Dictionary.InOrOutStatus.IN)
                {
                    oItem.SubItems.Add("IN");
                }
                else
                {
                    oItem.SubItems.Add("OUT");
                }
                if (oSPTranType.IsSystem == (int)Dictionary.YesOrNoStatus.YES)
                {
                    oItem.SubItems.Add("YES");
                }
                else
                {
                    oItem.SubItems.Add("NO");
                }
                oItem.SubItems.Add(oSPTranType.User.Username.ToString());
                oItem.SubItems.Add(oSPTranType.CreateDate.ToString());

                oItem.Tag = oSPTranType;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmSPTranType oForm = new frmSPTranType();
            oForm.ShowDialog();
            DataLoadControl();
        
        }
        private void frmSPTranTypes_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwSPTranTypes.SelectedItems.Count != 0)
            {

                SPTranType oSPTranType = (SPTranType)lvwSPTranTypes.SelectedItems[0].Tag;

                frmSPTranType oForm = new frmSPTranType();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.Text = "Edit SP Tran Type";
                oForm.ShowDialog(oSPTranType);
                DataLoadControl();

            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }

        }

        private void lvwSPTranTypes_DoubleClick(object sender, EventArgs e)
        {
            if (lvwSPTranTypes.SelectedItems.Count != 0)
            {

                SPTranType oSPTranType = (SPTranType)lvwSPTranTypes.SelectedItems[0].Tag;

                frmSPTranType oForm = new frmSPTranType();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.Text = "Edit SP Tran Type";
                oForm.ShowDialog(oSPTranType);
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }
    
    }
}
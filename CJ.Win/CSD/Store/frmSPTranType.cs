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
    public partial class frmSPTranType : Form
    {
        public frmSPTranType()
        {
            InitializeComponent();
        }
        private void LoadCombos()
        {
            //SP Tran Side
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.InOrOutStatus)))
            {
                cmbTranSide.Items.Add(Enum.GetName(typeof(Dictionary.InOrOutStatus), GetEnum));
            }
            cmbTranSide.SelectedIndex = (int)Dictionary.InOrOutStatus.IN;

            //SP Is System
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.YesOrNoStatus)))
            {
                cmbIsSystem.Items.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), GetEnum));
            }
            cmbIsSystem.SelectedIndex = (int)Dictionary.YesOrNoStatus.YES;

        }
        public void ShowDialog(SPTranType oSPTranType)
        {
            this.Tag = oSPTranType;

            LoadCombos();
            txtSPTranTypeName.Text = oSPTranType.Name;
            cmbTranSide.SelectedIndex = oSPTranType.TranSide - 1;
            cmbIsSystem.SelectedIndex = oSPTranType.IsSystem;

            this.ShowDialog();
        }
        private bool validateUIInput()
        {
            #region Input Information Validation

            if (txtSPTranTypeName.Text.Trim() == "" || txtSPTranTypeName.Text == null)
            {
                MessageBox.Show("Please enter SP Tran Type Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSPTranTypeName.Focus();
                return false;
            }
            if (cmbTranSide.Text == "" || cmbTranSide.Text==null)
            {
                MessageBox.Show("Please Select SP Tran Side", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTranSide.Focus();
                return false;
            }
            if (cmbIsSystem.Text == "" || cmbIsSystem.Text == null)
            {
                MessageBox.Show("Please Select 'Is System'", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbIsSystem.Focus();
                return false;
            }
            #endregion

            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                this.Close();
            }
        }

        private void Save()
        {
            if (this.Tag == null)
            {
                SPTranType oSPTranType = new SPTranType();
                oSPTranType.Name = txtSPTranTypeName.Text;
                oSPTranType.TranSide = cmbTranSide.SelectedIndex + 1;
                oSPTranType.IsSystem = cmbIsSystem.SelectedIndex;
                 
                try
                {
                    DBController.Instance.BeginNewTransaction();

                        oSPTranType.Add();
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Refresh();  

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                SPTranType oSPTranType = (SPTranType)this.Tag;
                
                {
                    oSPTranType.Name = txtSPTranTypeName.Text;
                    oSPTranType.TranSide = cmbTranSide.SelectedIndex + 1;
                    oSPTranType.IsSystem = cmbIsSystem.SelectedIndex;
                    try
                    {
                        DBController.Instance.BeginNewTransaction();

                            oSPTranType.Edit();
                            DBController.Instance.CommitTransaction();
                            MessageBox.Show("Update Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Refresh();  
                      
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }

                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSPTranType_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                LoadCombos();
            }
            else
            {
            }
        }


    }

}

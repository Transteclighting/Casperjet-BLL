using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.BEIL
{
    public partial class frmLCMStage2 : Form
    {
        LCMComponent oLCMComponent;
        LCMComponentItem oLCMComponentItem;
        int nID = 0;
        public frmLCMStage2()
        {
            InitializeComponent();
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                btnSave.Enabled = false;
                txtChassisSerial.Enabled = true;
                txtChassisSerial.Focus();
                txtChassisSerial.SelectAll();
            }
        }
        private void Save()
        {
            oLCMComponent = new LCMComponent();
            oLCMComponentItem = new LCMComponentItem();

            oLCMComponent.ID = nID;
            oLCMComponent.UpdateDate = DateTime.Now;
            oLCMComponent.UpdateUserID = Utility.UserId;
            oLCMComponent.Status = (int)Dictionary.LCMStatus.Stage_2;

            try
            {
                DBController.Instance.BeginNewTransaction();
                oLCMComponent.UpdateStatus();

                oLCMComponentItem.ID = nID;
                oLCMComponentItem.ComponentID = (int)Dictionary.LCMComponent.Opencell;
                oLCMComponentItem.SerialNo = txtOpenCell.Text;
                oLCMComponentItem.CreateDate = DateTime.Now;
                oLCMComponentItem.CreateUserID = Utility.UserId;
                oLCMComponentItem.Status = 1;
                oLCMComponentItem.Add();

                if (txtTcon.Text != "")
                {
                    oLCMComponentItem.ID = nID;
                    oLCMComponentItem.ComponentID = (int)Dictionary.LCMComponent.TCon;
                    oLCMComponentItem.SerialNo = txtTcon.Text;
                    oLCMComponentItem.CreateDate = DateTime.Now;
                    oLCMComponentItem.CreateUserID = Utility.UserId;
                    oLCMComponentItem.Status = 1;
                    oLCMComponentItem.Add();
                }


                DBController.Instance.CommitTransaction();
                MessageBox.Show("Successfully Add Component Serial", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }
        private bool validateUIInput()
        {

            if (txtOpenCell.Text == "")
            {
                MessageBox.Show("Please enter opencell serial", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOpenCell.Focus();
                return false;
            }

            if (nID == 0)
            {
                MessageBox.Show("Please input valid chassis serial", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtChassisSerial.Focus();
                return false;
            }

            return true;
        }

        private void txtChassisSerial_TextChanged(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            txtManualSerial.Text = "";
            txtTcon.Text = "";
            txtOpenCell.Text = "";
            dgvLCMComponent.Rows.Clear();
            btnSave.Enabled = true;

            oLCMComponent = new LCMComponent();
            //nID = oLCMComponent.Refresh(txtChassisSerial.Text.Trim(), (int)Dictionary.LCMStatus.Stage_1, 1);
            nID = oLCMComponent.Refresh(txtChassisSerial.Text.Trim(), 1);

            if (oLCMComponent.Status == (int)Dictionary.LCMStatus.Stage_1)
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
            }

            if (nID == 0)
            {

            }
            else
            {
                oLCMComponent.GetComponent(txtChassisSerial.Text.Trim());
                dgvLCMComponent.Rows.Clear();
                foreach (LCMComponentItem oLCMComponentItem in oLCMComponent)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvLCMComponent);
                    oRow.Cells[0].Value = oLCMComponentItem.ComponentName.ToString();
                    oRow.Cells[1].Value = Convert.ToDateTime(oLCMComponentItem.CreateDate).ToString();
                    oRow.Cells[2].Value = oLCMComponentItem.SerialNo.ToString();
                    oRow.Cells[3].Value = oLCMComponentItem.ComponentID.ToString();
                    dgvLCMComponent.Rows.Add(oRow);
                }
                txtChassisSerial.Enabled = false;
                txtManualSerial.Enabled = false;
                //txtOpenCell.Focus();
                
            }
        }

        private void frmLCMComponentLEDBar_Load(object sender, EventArgs e)
        {
            this.Text = "Stage-2";
 
        }

        private void txtManualSerial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtChassisSerial.Focus();
            }
        }

        private void txtChassisSerial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtOpenCell.Focus();
            }
        }

        private void txtTcon_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
            }
            
        }

        private void txtOpenCell_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtOpenCell.Text.Trim() != "")
                {
                    txtTcon.Focus();
                }
            }
        }

        private void txtManualSerial_TextChanged(object sender, EventArgs e)
        {
            if (txtManualSerial.Text != "")
            {
                if (!DBController.Instance.CheckConnection())
                {
                    DBController.Instance.OpenNewConnection();
                }

                oLCMComponent = new LCMComponent();
                oLCMComponent.GetChassisSerial(txtManualSerial.Text.Trim());
                txtChassisSerial.Text = oLCMComponent.ChassisSerial;
            }

        }

       
    }
}
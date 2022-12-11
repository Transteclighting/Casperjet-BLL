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
    public partial class frmLCMStage3 : Form
    {
        int nID = 0;
        LCMComponent oLCMComponent;
        LCMComponentItem oLCMComponentItem;
        int _nType = 0;

        public frmLCMStage3(int nType)
        {
            InitializeComponent();
            _nType = nType;
        }


        public void ShowDialog(LCMComponent oLCMComponent)
        {
            this.Tag = oLCMComponent;
            LoaData();
            txtChassisSerial.Text = oLCMComponent.ChassisSerial;
            this.ShowDialog();
        }

        private void LoaData()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            if (_nType == (int)Dictionary.LCMStatus.Stage_4)
            {
                this.Text = "Stage-4";

                DataGridViewTextBoxColumn txtComponentName = new DataGridViewTextBoxColumn();
                txtComponentName.HeaderText = "Component Name";
                txtComponentName.Width = 100;
                txtComponentName.ReadOnly = true;
                //txtComponentName.DefaultCellStyle.BackColor = Color.DimGray;
                dgvLCMComponent.Columns.Add(txtComponentName);

                DataGridViewTextBoxColumn txtDate = new DataGridViewTextBoxColumn();
                txtDate.HeaderText = "Create Date";
                txtDate.Width = 120;
                txtDate.ReadOnly = true;
                //txtDate.DefaultCellStyle.BackColor = Color.DimGray;
                dgvLCMComponent.Columns.Add(txtDate);

                DataGridViewTextBoxColumn txtSerial = new DataGridViewTextBoxColumn();
                txtSerial.HeaderText = "Serial";
                txtSerial.Width = 130;
                txtSerial.ReadOnly = true;
                //txtSerial.DefaultCellStyle.BackColor = Color.DimGray;
                dgvLCMComponent.Columns.Add(txtSerial);

                DataGridViewTextBoxColumn txtComponentID = new DataGridViewTextBoxColumn();
                txtComponentID.HeaderText = "ComponentID";
                txtComponentID.Width = 100;
                txtComponentID.ReadOnly = true;
                txtComponentID.Visible = false;
                dgvLCMComponent.Columns.Add(txtComponentID);

                DataGridViewCheckBoxColumn CheckboxColumn = new DataGridViewCheckBoxColumn();
                CheckboxColumn.HeaderText = "Is Qc Pass";
                CheckboxColumn.Width = 50;
                CheckboxColumn.FalseValue = "0";
                CheckboxColumn.TrueValue = "1";
                CheckboxColumn.ReadOnly = true;
                dgvLCMComponent.Columns.Add(CheckboxColumn);

                DataGridViewTextBoxColumn txtRemarks = new DataGridViewTextBoxColumn();
                txtRemarks.HeaderText = "Remarks";
                txtRemarks.Width = 270;
                txtRemarks.ReadOnly = true;
                //txtRemarks.DefaultCellStyle.BackColor = Color.DimGray;
                dgvLCMComponent.Columns.Add(txtRemarks);

                Utilities oLCMQCStatus = new Utilities();
                oLCMQCStatus.GetLCMQCStatus();

                DataGridViewComboBoxColumn txtStatus = new DataGridViewComboBoxColumn();
                txtStatus.DataPropertyName = "Status";
                txtStatus.HeaderText = "Status";
                txtStatus.Width = 80;
                txtStatus.DataSource = oLCMQCStatus;
                txtStatus.ValueMember = "SatusId";
                txtStatus.DisplayMember = "Satus";
                dgvLCMComponent.Columns.Add(txtStatus);

                DataGridViewTextBoxColumn txtQcRemarks = new DataGridViewTextBoxColumn();
                txtQcRemarks.HeaderText = "Qc Remarks";
                txtQcRemarks.Width = 200;
                dgvLCMComponent.Columns.Add(txtQcRemarks);

                DataGridViewTextBoxColumn txtReplaceSl = new DataGridViewTextBoxColumn();
                txtReplaceSl.HeaderText = "Replace Serial";
                txtReplaceSl.Width = 120;
                dgvLCMComponent.Columns.Add(txtReplaceSl);


                LCMComponents oLCMDefect = new LCMComponents();
                oLCMDefect.RefreshDefect();

                DataGridViewComboBoxColumn ColumnItem = new DataGridViewComboBoxColumn();
                ColumnItem.DataPropertyName = "Symtom";
                ColumnItem.HeaderText = "Symtom";
                ColumnItem.Width = 120;
                ColumnItem.DataSource = oLCMDefect;
                ColumnItem.ValueMember = "DefectID";
                ColumnItem.DisplayMember = "DefectName";
                dgvLCMComponent.Columns.Add(ColumnItem);

                Utilities oLCMRootcause = new Utilities();
                oLCMRootcause.GetRootcause();

                DataGridViewComboBoxColumn ColumnItem1 = new DataGridViewComboBoxColumn();
                ColumnItem1.DataPropertyName = "RootCause";
                ColumnItem1.HeaderText = "Root Cause";
                ColumnItem1.Width = 80;
                ColumnItem1.DataSource = oLCMRootcause;
                ColumnItem1.ValueMember = "SatusId";
                ColumnItem1.DisplayMember = "Satus";
                dgvLCMComponent.Columns.Add(ColumnItem1);
            }
        }

        private void frmLCMStage3_Load(object sender, EventArgs e)
        {

            if (_nType == (int)Dictionary.LCMStatus.Stage_3)
            {
                this.Text = "Stage-3";

                DataGridViewTextBoxColumn txtComponentName = new DataGridViewTextBoxColumn();
                txtComponentName.HeaderText = "Component Name";
                txtComponentName.Width = 140;
                txtComponentName.ReadOnly = true;
                //txtComponentName.DefaultCellStyle.BackColor = Color.DimGray;
                dgvLCMComponent.Columns.Add(txtComponentName);

                DataGridViewTextBoxColumn txtDate = new DataGridViewTextBoxColumn();
                txtDate.HeaderText = "Create Date";
                txtDate.Width = 120;
                txtDate.ReadOnly = true;
                //txtDate.DefaultCellStyle.BackColor = Color.DimGray;
                dgvLCMComponent.Columns.Add(txtDate);

                DataGridViewTextBoxColumn txtSerial = new DataGridViewTextBoxColumn();
                txtSerial.HeaderText = "Serial";
                txtSerial.Width = 150;
                dgvLCMComponent.Columns.Add(txtSerial);

                DataGridViewTextBoxColumn txtComponentID = new DataGridViewTextBoxColumn();
                txtComponentID.HeaderText = "ComponentID";
                txtComponentID.Width = 100;
                txtComponentID.Visible = false;
                dgvLCMComponent.Columns.Add(txtComponentID);

                DataGridViewCheckBoxColumn CheckboxColumn = new DataGridViewCheckBoxColumn();
                CheckboxColumn.HeaderText = "Is Qc Pass";
                CheckboxColumn.Width = 50;
                CheckboxColumn.FalseValue = "0";
                CheckboxColumn.TrueValue = "1";
                dgvLCMComponent.Columns.Add(CheckboxColumn);

                DataGridViewTextBoxColumn txtRemarks = new DataGridViewTextBoxColumn();
                txtRemarks.HeaderText = "Remarks";
                txtRemarks.Width = 270;
                dgvLCMComponent.Columns.Add(txtRemarks);
            }
            //else if (_nType == (int)Dictionary.LCMStatus.Stage_4)
            //{
            //    this.Text = "Stage-4";

            //    DataGridViewTextBoxColumn txtComponentName = new DataGridViewTextBoxColumn();
            //    txtComponentName.HeaderText = "Component Name";
            //    txtComponentName.Width = 100;
            //    txtComponentName.ReadOnly = true;
            //    //txtComponentName.DefaultCellStyle.BackColor = Color.DimGray;
            //    dgvLCMComponent.Columns.Add(txtComponentName);

            //    DataGridViewTextBoxColumn txtDate = new DataGridViewTextBoxColumn();
            //    txtDate.HeaderText = "Create Date";
            //    txtDate.Width = 120;
            //    txtDate.ReadOnly = true;
            //    //txtDate.DefaultCellStyle.BackColor = Color.DimGray;
            //    dgvLCMComponent.Columns.Add(txtDate);

            //    DataGridViewTextBoxColumn txtSerial = new DataGridViewTextBoxColumn();
            //    txtSerial.HeaderText = "Serial";
            //    txtSerial.Width = 130;
            //    txtSerial.ReadOnly = true;
            //    //txtSerial.DefaultCellStyle.BackColor = Color.DimGray;
            //    dgvLCMComponent.Columns.Add(txtSerial);

            //    DataGridViewTextBoxColumn txtComponentID = new DataGridViewTextBoxColumn();
            //    txtComponentID.HeaderText = "ComponentID";
            //    txtComponentID.Width = 100;
            //    txtComponentID.ReadOnly = true;
            //    txtComponentID.Visible = false;
            //    dgvLCMComponent.Columns.Add(txtComponentID);

            //    DataGridViewCheckBoxColumn CheckboxColumn = new DataGridViewCheckBoxColumn();
            //    CheckboxColumn.HeaderText = "Is Qc Pass";
            //    CheckboxColumn.Width = 50;
            //    CheckboxColumn.FalseValue = "0";
            //    CheckboxColumn.TrueValue = "1";
            //    CheckboxColumn.ReadOnly = true;
            //    dgvLCMComponent.Columns.Add(CheckboxColumn);

            //    DataGridViewTextBoxColumn txtRemarks = new DataGridViewTextBoxColumn();
            //    txtRemarks.HeaderText = "Remarks";
            //    txtRemarks.Width = 270;
            //    txtRemarks.ReadOnly = true;
            //    //txtRemarks.DefaultCellStyle.BackColor = Color.DimGray;
            //    dgvLCMComponent.Columns.Add(txtRemarks);

            //    Utilities oLCMQCStatus = new Utilities();
            //    oLCMQCStatus.GetLCMQCStatus();

            //    DataGridViewComboBoxColumn txtStatus = new DataGridViewComboBoxColumn();
            //    txtStatus.DataPropertyName = "Status";
            //    txtStatus.HeaderText = "Status";
            //    txtStatus.Width = 80;
            //    txtStatus.DataSource = oLCMQCStatus;
            //    txtStatus.ValueMember = "SatusId";
            //    txtStatus.DisplayMember = "Satus";
            //    dgvLCMComponent.Columns.Add(txtStatus);

            //    DataGridViewTextBoxColumn txtQcRemarks = new DataGridViewTextBoxColumn();
            //    txtQcRemarks.HeaderText = "Qc Remarks";
            //    txtQcRemarks.Width = 270;
            //    dgvLCMComponent.Columns.Add(txtQcRemarks);


            //    DataGridViewTextBoxColumn txtReplaceSl = new DataGridViewTextBoxColumn();
            //    txtReplaceSl.HeaderText = "Replace Serial";
            //    txtReplaceSl.Width = 130;
            //    dgvLCMComponent.Columns.Add(txtReplaceSl);
            //}

        }

        private void txtChassisSerial_TextChanged(object sender, EventArgs e)
        {
            if (_nType == (int)Dictionary.LCMStatus.Stage_3)
            {
                if (!DBController.Instance.CheckConnection())
                {
                    DBController.Instance.OpenNewConnection();
                }

                oLCMComponent = new LCMComponent();
                //nID = oLCMComponent.Refresh(txtChassisSerial.Text.Trim(), (int)Dictionary.LCMStatus.Stage_2, 1);
                nID = oLCMComponent.Refresh(txtChassisSerial.Text.Trim(), 1);

                if (nID == 0)
                {
                    //MessageBox.Show("Invalid chassis serial", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //txtChassisSerial.Focus();
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
                        oRow.Cells[4].Value = 1;
                        dgvLCMComponent.Rows.Add(oRow);
                    }
                    txtChassisSerial.Enabled = false;
                    txtManualSerial.Enabled = false;
                }
            }
            else if (_nType == (int)Dictionary.LCMStatus.Stage_4)
            {
                if (!DBController.Instance.CheckConnection())
                {
                    DBController.Instance.OpenNewConnection();
                }

                oLCMComponent = new LCMComponent();
                //nID = oLCMComponent.Refresh(txtChassisSerial.Text.Trim(), (int)Dictionary.LCMStatus.Stage_3, 1);
                nID = oLCMComponent.Refresh(txtChassisSerial.Text.Trim(), 1);

                if (nID == 0)
                {
                    //MessageBox.Show("Invalid chassis serial", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //txtChassisSerial.Focus();
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
                        oRow.Cells[4].Value = oLCMComponentItem.Status;
                        if (oLCMComponentItem.Status == (int)Dictionary.YesOrNoStatus.YES)
                        {
                            oRow.Cells[4].ReadOnly = true;                         
                            oRow.Cells[6].ReadOnly = true;
                            oRow.Cells[7].ReadOnly = true;
                        }
                        else
                        {
                            oRow.Cells[0].Style.ForeColor = Color.Red;
                            oRow.Cells[1].Style.ForeColor = Color.Red;
                            oRow.Cells[2].Style.ForeColor = Color.Red;
                            oRow.Cells[3].Style.ForeColor = Color.Red;
                            oRow.Cells[4].Style.ForeColor = Color.Red;
                            oRow.Cells[5].Style.ForeColor = Color.Red;
                            oRow.Cells[6].Style.ForeColor = Color.Red;
                            oRow.Cells[7].Style.ForeColor = Color.Red;

                            oRow.Cells[4].ReadOnly = false;
                            oRow.Cells[6].ReadOnly = false;
                            oRow.Cells[6].Value = 1;
                            oRow.Cells[7].ReadOnly = false;
                        }
                        oRow.Cells[5].Value = oLCMComponentItem.Remarks;
                        dgvLCMComponent.Rows.Add(oRow);
                    }
                    txtChassisSerial.Enabled = false;
                    txtManualSerial.Enabled = false;
                }
            }

        }

        private bool validateUIInput()
        {

            if (txtChassisSerial.Text == "")
            {
                MessageBox.Show("Please enter chassis serial", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtChassisSerial.Focus();
                return false;
            }

            if (nID == 0)
            {
                MessageBox.Show("Please input valid chassis serial", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtChassisSerial.Focus();
                return false;
            }

            foreach (DataGridViewRow oItemRow in dgvLCMComponent.Rows)
            {
                if (oItemRow.Index < dgvLCMComponent.Rows.Count)
                {
                    if (oItemRow.Cells[0].Value == null)
                    {
                        MessageBox.Show("Please input valid component name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[0].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please input valid component name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[1].Value == null)
                    {
                        MessageBox.Show("Please input valid create date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[1].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please input valid create date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    if (oItemRow.Cells[2].Value == null)
                    {
                        MessageBox.Show("Please input valid Serial", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[2].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please input valid Serial", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[3].Value == null)
                    {
                        MessageBox.Show("Please input component name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[3].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please input component name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
            }

            if (_nType == (int)Dictionary.LCMStatus.Stage_4)
            {
                foreach (DataGridViewRow oItemRow in dgvLCMComponent.Rows)
                {
                    if (oItemRow.Index < dgvLCMComponent.Rows.Count)
                    {
                        int nStatus = 0;
                        try
                        {
                            nStatus = int.Parse(oItemRow.Cells[4].Value.ToString());
                        }
                        catch
                        {
                            nStatus = 0;
                        }

                        if (nStatus == (int)Dictionary.YesOrNoStatus.NO)
                        {
                            if (int.Parse(oItemRow.Cells[6].Value.ToString()) == (int)Dictionary.LCMQCStatus.Replaced)
                            {
                                if (oItemRow.Cells[8].Value == null)
                                {
                                    MessageBox.Show("Please input valid valid replace serial", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                                if (oItemRow.Cells[8].Value.ToString().Trim() == "")
                                {
                                    MessageBox.Show("Please input valid valid replace serial", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return false;
                                }
                            }
                            if (oItemRow.Cells[9].Value == null)
                            {
                                MessageBox.Show("Please Select Symtom", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                            if (oItemRow.Cells[10].Value == null)
                            {
                                MessageBox.Show("Please Select Rootcause", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }

                        }
                    }
                }
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {

                oLCMComponent = new LCMComponent();
                oLCMComponentItem = new LCMComponentItem();
                oLCMComponent.ID = nID;
                oLCMComponent.UpdateDate = DateTime.Now;
                oLCMComponent.UpdateUserID = Utility.UserId;
                if (_nType == (int)Dictionary.LCMStatus.Stage_3)
                {
                    oLCMComponent.Status = (int)Dictionary.LCMStatus.Stage_3;
                }
                else if (_nType == (int)Dictionary.LCMStatus.Stage_4)
                {
                    oLCMComponent.Status = (int)Dictionary.LCMStatus.Stage_4;
                }

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oLCMComponent.UpdateStatus();

                    oLCMComponentItem.ID = nID;
                    oLCMComponentItem.Delete();

                    if (_nType == (int)Dictionary.LCMStatus.Stage_3)
                    {
                        foreach (DataGridViewRow oItemRow in dgvLCMComponent.Rows)
                        {
                            if (oItemRow.Index < dgvLCMComponent.Rows.Count)
                            {
                                oLCMComponentItem.ID = nID;
                                oLCMComponentItem.ComponentID = int.Parse(oItemRow.Cells[3].Value.ToString());
                                oLCMComponentItem.SerialNo = oItemRow.Cells[2].Value.ToString();
                                oLCMComponentItem.CreateDate = Convert.ToDateTime(oItemRow.Cells[1].Value.ToString());
                                oLCMComponentItem.CreateUserID = Utility.UserId;
                                try
                                {
                                    oLCMComponentItem.Status = int.Parse(oItemRow.Cells[4].Value.ToString());
                                }
                                catch
                                {
                                    oLCMComponentItem.Status = 0;
                                }

                                try
                                {
                                    oLCMComponentItem.Remarks = oItemRow.Cells[5].Value.ToString();
                                }
                                catch
                                {
                                    oLCMComponentItem.Remarks = "";
                                }
                                oLCMComponentItem.Add();

                            }
                        }
                    }

                    else if (_nType == (int)Dictionary.LCMStatus.Stage_4)
                    {
                        foreach (DataGridViewRow oItemRow in dgvLCMComponent.Rows)
                        {
                            if (oItemRow.Index < dgvLCMComponent.Rows.Count)
                            {
                                oLCMComponentItem.ID = nID;
                                oLCMComponentItem.ComponentID = int.Parse(oItemRow.Cells[3].Value.ToString());
                                int nStatus = 0;
                                try
                                {
                                    nStatus = int.Parse(oItemRow.Cells[4].Value.ToString());
                                }
                                catch
                                {
                                    nStatus = 0;                           
                                }

                                if (nStatus == (int)Dictionary.YesOrNoStatus.YES)
                                {
                                    oLCMComponentItem.SerialNo = oItemRow.Cells[2].Value.ToString();
                                }
                                else
                                {
                                    int nQcStatus = int.Parse(oItemRow.Cells[6].Value.ToString());
                                    if (nQcStatus == (int)Dictionary.LCMQCStatus.Replaced)
                                    {
                                        oLCMComponentItem.SerialNo = oItemRow.Cells[8].Value.ToString();
                                    }
                                    else
                                    {
                                        oLCMComponentItem.SerialNo = oItemRow.Cells[2].Value.ToString();
                                    }
                                }
                                oLCMComponentItem.CreateDate = Convert.ToDateTime(oItemRow.Cells[1].Value.ToString());
                                oLCMComponentItem.CreateUserID = Utility.UserId;
                                oLCMComponentItem.Status = (int)Dictionary.YesOrNoStatus.YES;
                                try
                                {
                                    oLCMComponentItem.Remarks = oItemRow.Cells[5].Value.ToString();
                                }
                                catch
                                {
                                    oLCMComponentItem.Remarks = "";
                                }
                                oLCMComponentItem.Add();


                                if (nStatus == (int)Dictionary.YesOrNoStatus.NO)
                                {
                                    try
                                    {
                                        oLCMComponentItem.QcRemarks = oItemRow.Cells[7].Value.ToString();
                                    }
                                    catch
                                    {
                                        oLCMComponentItem.QcRemarks = "";
                                    }
                                    oLCMComponentItem.SerialNo = oItemRow.Cells[2].Value.ToString();
                                    oLCMComponentItem.QCStatus = int.Parse(oItemRow.Cells[6].Value.ToString());

                                    
                                    oLCMComponentItem.Symtom = int.Parse(oItemRow.Cells[9].Value.ToString());
                                    oLCMComponentItem.Rootcause = int.Parse(oItemRow.Cells[10].Value.ToString());


                                    oLCMComponentItem.AddDefectiveComponent();
                                }

                            }
                        }
                    }
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Successfully Add Component Serial", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (_nType == (int)Dictionary.LCMStatus.Stage_3)
                    {
                        txtChassisSerial.Text = "";
                        txtChassisSerial.Enabled = true;
                        dgvLCMComponent.Rows.Clear();
                        txtChassisSerial.Focus();
                    }
                    else
                    {
                        this.Close();
                    }
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

        private void txtManualSerial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
            }
        }

        private void txtChassisSerial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
            }
        }


    }
}
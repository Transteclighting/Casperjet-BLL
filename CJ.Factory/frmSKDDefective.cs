using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;

namespace CJ.Factory
{
    public partial class frmSKDDefective : Form
    {
        int _nID = 0;
        ProductComponent oProComp;
        ProductComponents oProductComponents;
        int _nType = 0;
        int _nIsIndoor = 0;
        int _nProductID = 0;
        int _nProductionType = 0;
        int _nLocationID = 0;

        public frmSKDDefective(int nType)
        {
            InitializeComponent();
            _nType = nType;

            if(nType == (int)Dictionary.LCMStatus.Stage_4)
            {
                LoaData();
                label1.Visible = true;
                txtSerialNo.Visible = true;
            }
        }

        ProductComponents _oProductComps = new ProductComponents();
        public void ShowDialog(ProductComponent oProductComponent)
        {
            
            _oProductComps.RefreshComponentForDefective(oProductComponent.ProductCode, oProductComponent.SetID,2,86);
            _nID = oProductComponent.SetID;

            this.Tag = oProductComponent;
            if (_nType == (int)Dictionary.LCMStatus.Stage_4)
            {
                LoadGridView(_nID);
            }
            _nIsIndoor = oProductComponent.IsIndoorItem;
            _nProductID = oProductComponent.ProductID;
            _nProductionType= oProductComponent.ProductionType;
            _nLocationID= oProductComponent.LocationID;

            //txtChassisSerial.Text = oProductComponent.ProductSerial;
            this.ShowDialog();
        }

        private void LoadGridView(int nSetID)
        {
            ProductComponents oComponents = new ProductComponents();
            oComponents.GetProductComponentUniversalFactory(DateTime.Today, DateTime.Today, -1, -1, -1, -1, -1, -1, "", "", true, -1, 2, -1,nSetID);

            if (_nType == (int)Dictionary.LCMStatus.Stage_4)
            {
                if (!DBController.Instance.CheckConnection())
                {
                    DBController.Instance.OpenNewConnection();
                }

                //oComponents = new ProductComponents();
                //nID = oComponents.Refresh(txtChassisSerial.Text.Trim(), 1);

                _nID = oComponents[0].SetID;

                int nID = 0;
                ProductComponent oID = new ProductComponent();
                nID = oID.GetDefectiveSetID(_nID);
                if (nID == 0)
                {
                    MessageBox.Show("Defective is not Declared for this Serial", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                lblProduct.Text = "[" + oComponents[0].ProductCode + "] " + oComponents[0].ProductName;
                _nProductID = oComponents[0].ProductID;
                _nIsIndoor = oComponents[0].IsIndoorItem;
                _nProductionType = oComponents[0].ProductionType;
                _nLocationID = oComponents[0].LocationID;

                oComponents.GetComponent(_nID);
                dgvLCMComponent.Rows.Clear();
                foreach (ProductComponent oComponent in oComponents)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvLCMComponent);
                    oRow.Cells[0].Value = oComponent.ComponentName.ToString();

                    oRow.Cells[1].Value = Convert.ToDateTime(oComponent.CreateDate).ToString();
                    oRow.Cells[2].Value = oComponent.BarcodeSerial.ToString();
                    oRow.Cells[3].Value = oComponent.ComponentID.ToString();
                    oRow.Cells[4].Value = oComponent.Status;
                    if (oComponent.Status == (int)Dictionary.YesOrNoStatus.YES)
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
                    oRow.Cells[5].Value = oComponent.Remarks;
                    dgvLCMComponent.Rows.Add(oRow);
                }
                txtSerialNo.Enabled = false;
            }
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


                ProductComponents oLCMDefect = new ProductComponents();
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

        private void frmSKDDefective_Load(object sender, EventArgs e)
        {
            //LoaData();

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


            if (_nType == (int)Dictionary.LCMStatus.Stage_3)
            {
                if (!DBController.Instance.CheckConnection())
                {
                    DBController.Instance.OpenNewConnection();
                }

                dgvLCMComponent.Rows.Clear();
                foreach (ProductComponent oPCom in _oProductComps)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvLCMComponent);
                    oRow.Cells[0].Value = oPCom.ComponentName.ToString();
                    oRow.Cells[1].Value = Convert.ToDateTime(oPCom.CreateDate).ToString();
                    oRow.Cells[2].Value = oPCom.ProductSerial.ToString();
                    oRow.Cells[3].Value = oPCom.ComponentID.ToString();
                    oRow.Cells[4].Value = oPCom.Status;//1;
                    oRow.Cells[5].Value = oPCom.Remarks.ToString();
                    dgvLCMComponent.Rows.Add(oRow);
                }
                txtSerialNo.Enabled = false;
                
                lblProduct.Text = "[" + _oProductComps[0].ProductCode + "] " + _oProductComps[0].ProductName;

            }

        }


        private bool validateUIInput()
        {

            //if (txtSerialNo.Text == "")
            //{
            //    MessageBox.Show("Please enter chassis serial", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtSerialNo.Focus();
            //    return false;
            //}

            //if (nID == 0)
            //{
            //    MessageBox.Show("Please input valid chassis serial", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtSerialNo.Focus();
            //    return false;
            //}

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

                    //if (oItemRow.Cells[2].Value == null)
                    //{
                    //    MessageBox.Show("Please input valid Serial", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    return false;
                    //}
                    //if (oItemRow.Cells[2].Value.ToString().Trim() == "" && oItemRow.Cells[3].Value.ToString().Trim() != "7")
                    //{
                    //    MessageBox.Show("Please input valid Serial", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //    return false;
                    //}
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

                oProComp = new ProductComponent();
                oProductComponents = new ProductComponents();
                oProComp.SetID = _nID;
                oProComp.UpdateDate = DateTime.Now;
                oProComp.UpdateUserID = Utility.UserId;
                //if (_nType == (int)Dictionary.LCMStatus.Stage_3)
                //{
                //    oProComp.Status = (int)Dictionary.LCMStatus.Stage_3;
                //}
                //else if (_nType == (int)Dictionary.LCMStatus.Stage_4)
                //{
                //    oProComp.Status = (int)Dictionary.LCMStatus.Stage_4;
                //}

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    //oProComp.UpdateStatus();

                    oProComp.SetID = _nID;
                    oProComp.DeleteDefect();

                    if (_nType == (int)Dictionary.LCMStatus.Stage_3)
                    {
                        foreach (DataGridViewRow oItemRow in dgvLCMComponent.Rows)
                        {
                            if (oItemRow.Index < dgvLCMComponent.Rows.Count)
                            {
                                oProComp.SetID = _nID;
                                oProComp.ComponentID = int.Parse(oItemRow.Cells[3].Value.ToString());
                                oProComp.BarcodeSerial = oItemRow.Cells[2].Value.ToString();
                                oProComp.CreateDate = Convert.ToDateTime(oItemRow.Cells[1].Value.ToString());
                                oProComp.CreateUserID = Utility.UserId;
                                try
                                {
                                    oProComp.Status = int.Parse(oItemRow.Cells[4].Value.ToString());
                                }
                                catch
                                {
                                    oProComp.Status = 0;
                                }

                                try
                                {
                                    oProComp.Remarks = oItemRow.Cells[5].Value.ToString();
                                }
                                catch
                                {
                                    oProComp.Remarks = "";
                                }

                                oProComp.ProductID = _nProductID;
                                oProComp.ProductionType = _nProductionType;
                                oProComp.LocationID = _nLocationID;
                                oProComp.IsIndoorItem = _nIsIndoor;

                                oProComp.AddDefect();

                            }
                        }
                    }

                    else if (_nType == (int)Dictionary.LCMStatus.Stage_4)
                    {
                        foreach (DataGridViewRow oItemRow in dgvLCMComponent.Rows)
                        {
                            if (oItemRow.Index < dgvLCMComponent.Rows.Count)
                            {
                                oProComp.SetID = _nID;
                                oProComp.ComponentID = int.Parse(oItemRow.Cells[3].Value.ToString());
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
                                    oProComp.BarcodeSerial = oItemRow.Cells[2].Value.ToString();
                                }
                                else
                                {
                                    int nQcStatus = int.Parse(oItemRow.Cells[6].Value.ToString());
                                    if (nQcStatus == (int)Dictionary.LCMQCStatus.Replaced)
                                    {
                                        oProComp.BarcodeSerial = oItemRow.Cells[8].Value.ToString();
                                    }
                                    else
                                    {
                                        oProComp.BarcodeSerial = oItemRow.Cells[2].Value.ToString();
                                    }
                                }
                                oProComp.CreateDate = Convert.ToDateTime(oItemRow.Cells[1].Value.ToString());
                                oProComp.CreateUserID = Utility.UserId;
                                oProComp.Status = (int)Dictionary.YesOrNoStatus.YES;
                                try
                                {
                                    oProComp.Remarks = oItemRow.Cells[5].Value.ToString();
                                }
                                catch
                                {
                                    oProComp.Remarks = "";
                                }

                                oProComp.ProductID = _nProductID;
                                oProComp.ProductionType = _nProductionType;
                                oProComp.LocationID = _nLocationID;
                                oProComp.IsIndoorItem = _nIsIndoor;

                                oProComp.AddDefect();


                                if (nStatus == (int)Dictionary.YesOrNoStatus.NO)
                                {
                                    try
                                    {
                                        oProComp.QcRemarks = oItemRow.Cells[7].Value.ToString();
                                    }
                                    catch
                                    {
                                        oProComp.QcRemarks = "";
                                    }
                                    oProComp.BarcodeSerial = oItemRow.Cells[2].Value.ToString();
                                    oProComp.QCStatus = int.Parse(oItemRow.Cells[6].Value.ToString());


                                    oProComp.Symtom = int.Parse(oItemRow.Cells[9].Value.ToString());
                                    oProComp.Rootcause = int.Parse(oItemRow.Cells[10].Value.ToString());
                                    oProComp.LocationID = _nLocationID;

                                    oProComp.AddDefectiveComponent();
                                }

                            }
                        }

                        DataTran oTran = new DataTran();
                        oTran.TableName = "t_SKDDefectiveComponent";
                        oTran.DataID = _nID;
                        oTran.WarehouseID = 86;//Utility.LocationID;
                        oTran.TransferType = (int)Dictionary.DataTransferType.Add;
                        oTran.IsDownload = (int)Dictionary.IsDownload.No;
                        oTran.BatchNo = 0;
                        if (oTran.CheckDataByLocationID() == false)
                        {
                            oTran.AddForFactory();
                        }
                    }

                    DataTran oDataTran = new DataTran();
                    oDataTran.TableName = "t_ProductComponentSerialUniversal";
                    oDataTran.DataID = _nID;
                    oDataTran.WarehouseID = 86;//Utility.LocationID;
                    oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                    oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                    oDataTran.BatchNo = 0;
                    if (oDataTran.CheckDataByLocationID() == false)
                    {
                        oDataTran.AddForFactory();
                    }

                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Successfully Add Component Serial", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (_nType == (int)Dictionary.LCMStatus.Stage_3)
                    {
                        txtSerialNo.Text = "";
                        txtSerialNo.Enabled = true;
                        dgvLCMComponent.Rows.Clear();
                        txtSerialNo.Focus();
                        _nID = 0;
                        btnSave.Enabled = false;
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

        private void txtSerialNo_TextChanged(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }


            btnSave.Enabled = true;
            //lblMessage.Visible = false;
            //dgvComponent.Focus();
            ProductComponents oComponents = new ProductComponents();
            _nID = oComponents.RefreshForProductComponentUniversal(txtSerialNo.Text.Trim());
            if (_nID == 0)
            {

            }
            else
            {
                oComponents.GetProductComponentUniversalFactory(DateTime.Today, DateTime.Today, -1, -1, -1, -1, -1, -1, txtSerialNo.Text.Trim(), "", true, -1, 2,-1,-1);

                if (_nType == (int)Dictionary.LCMStatus.Stage_4)
                {
                    if (!DBController.Instance.CheckConnection())
                    {
                        DBController.Instance.OpenNewConnection();
                    }

                    //oComponents = new ProductComponents();
                    //nID = oComponents.Refresh(txtChassisSerial.Text.Trim(), 1);

                    _nID = oComponents[0].SetID;

                    int nID = 0;
                    ProductComponent oID = new ProductComponent();
                    nID = oID.GetDefectiveSetID(_nID);
                    if (nID == 0)
                    {
                        MessageBox.Show("Defective is not Declared for this Serial", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    lblProduct.Text="["+ oComponents[0].ProductCode+"] "+ oComponents[0].ProductName;
                    _nProductID = oComponents[0].ProductID;
                    _nIsIndoor = oComponents[0].IsIndoorItem;
                    _nProductionType = oComponents[0].ProductionType;
                    _nLocationID = oComponents[0].LocationID;

                    oComponents.GetComponent(_nID);
                    dgvLCMComponent.Rows.Clear();
                        foreach (ProductComponent oComponent in oComponents)
                        {
                            DataGridViewRow oRow = new DataGridViewRow();
                            oRow.CreateCells(dgvLCMComponent);
                            oRow.Cells[0].Value = oComponent.ComponentName.ToString();

                            oRow.Cells[1].Value = Convert.ToDateTime(oComponent.CreateDate).ToString();
                            oRow.Cells[2].Value = oComponent.BarcodeSerial.ToString();
                            oRow.Cells[3].Value = oComponent.ComponentID.ToString();
                            oRow.Cells[4].Value = oComponent.Status;
                            if (oComponent.Status == (int)Dictionary.YesOrNoStatus.YES)
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
                            oRow.Cells[5].Value = oComponent.Remarks;
                            dgvLCMComponent.Rows.Add(oRow);
                        }
                        txtSerialNo.Enabled = false;
                    }
                

            }
        }
    }
}
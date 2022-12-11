using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;
using CJ.Class.Library;

namespace CJ.POS.RT
{
    public partial class frmInvoiceReverseApply : Form
    {
        public bool _IsTrue = false;
        long nInvoiceID = 0;
        TELLib _oTELLib;
        RetailSalesInvoice _oRetailSalesInvoice;
        SalesInvoice oSalesInvoice;
        InvoiceReverse _oInvoiceReverse;
        double _Amt = 0;
        double _DisAmt = 0;
        int nReverseID = 0;
        int nWarehouseID = 0;
        

        public frmInvoiceReverseApply()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public bool UIValidation()
        {
            if (txtReason.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Reverse Reason", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtReason.Focus();
                return false;
            }
            if (lblInvoiceNo.Text.Trim() == "")
            {
                MessageBox.Show("Please Select valid Invoice", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lblInvoiceNo.Focus();
                return false;
            }
            if (this.Tag == null)
            {

                if (lblInvoiceNo.Text.Trim() != "")
                {
                    if (!DBController.Instance.CheckConnection())
                    {
                        DBController.Instance.OpenNewConnection();
                    }

                    _oInvoiceReverse = new InvoiceReverse();
                    _oInvoiceReverse.GetDuplicateInvoice(lblInvoiceNo.Text.Trim());
                    if (_oInvoiceReverse.Count != 0)
                    {
                        MessageBox.Show("This Invoice Already Apply for Reverse", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblInvoiceNo.Focus();
                        return false;
                    }
                }
            }

            foreach (DataGridViewRow oItemRow in dgvLineItem1.Rows)
            {
                if (oItemRow.Index < dgvLineItem1.Rows.Count)
                {
                    if (oItemRow.Cells[0].Value == DBNull.Value)
                    {
                        MessageBox.Show("Please Fill the grid Properly for Reverse", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return false;
                    }
                    if (oItemRow.Cells[1].Value == null)
                    {
                        MessageBox.Show("Please Fill the grid Properly for Reverse", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return false;
                    }
                    if (oItemRow.Cells[2].Value == null)
                    {
                        MessageBox.Show("Please Fill the grid Properly for Reverse", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        return false;
                    }
                    if (oItemRow.Cells[2].Value.ToString() == Dictionary.StockType.Used.ToString())
                    {
                        if (oItemRow.Cells[3].Value == null)
                        {
                            MessageBox.Show("Please Fill the grid Properly for Reverse", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            return false;
                        }
                        if (oItemRow.Cells[4].Value == null)
                        {
                            MessageBox.Show("Please Fill the grid Properly for Reverse", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            return false;
                        }
                        if (oItemRow.Cells[5].Value == null)
                        {
                            MessageBox.Show("Please Fill the grid Properly for Reverse", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            return false;
                        }
                        if (oItemRow.Cells[6].Value == null)
                        {
                            MessageBox.Show("Please Fill the grid Properly for Reverse", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            return false;
                        }
                        if (oItemRow.Cells[7].Value == null)
                        {
                            MessageBox.Show("Please Fill the grid Properly for Reverse", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                            return false;
                        }
                    }
                        
                }
                
            }

            return true;
        }
        private void btnApplay_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                _oTELLib = new TELLib();
                DateTime _dtCurrentDate = _oTELLib.ServerDateTime().Date;
                if (this.Tag != null)
                {

                    _oInvoiceReverse = (InvoiceReverse)this.Tag;
                    _oInvoiceReverse.ReverseID = nReverseID;
                    _oInvoiceReverse.WarehouseID = nWarehouseID;
                    _oInvoiceReverse.InvoiceNo = lblInvoiceNo.Text;
                    _oInvoiceReverse.UpdateUserID = Utility.UserId;
                    _oInvoiceReverse.UpdateDate = _dtCurrentDate;
                    _oInvoiceReverse.Reason = txtReason.Text;
                    _oInvoiceReverse.Status = (int)Dictionary.ReverseStatus.Create;

                    try
                    {

                        DBController.Instance.BeginNewTransaction();


                        #region barcode from Invoice Item
                        // Details
                        foreach (DataGridViewRow oItemRow in dgvLineItem1.Rows)
                        {
                            if (oItemRow.Index < dgvLineItem1.Rows.Count)
                            {

                                InvoiceReverseDetail _oInvoiceReverseDetail = new InvoiceReverseDetail();


                                _oInvoiceReverseDetail.WarehouseID = Utility.WarehouseID;
                                _oInvoiceReverseDetail.ProductID = int.Parse(oItemRow.Cells[8].Value.ToString());
                                _oInvoiceReverseDetail.ProductSerial = oItemRow.Cells[1].Value.ToString();
                              
                                if (oItemRow.Cells[2].Value.ToString() == Dictionary.StockType.Used.ToString())
                                {
                                    _oInvoiceReverseDetail.StockType = (int)Dictionary.StockType.Used;
                                    if (oItemRow.Cells[3].Value.ToString() == Dictionary.POSUnsoldDefectiveProductType.Aesthetic.ToString())
                                    {
                                        _oInvoiceReverseDetail.DefectiveType = (int)Dictionary.POSUnsoldDefectiveProductType.Aesthetic;
                                    }
                                    else
                                    {
                                        _oInvoiceReverseDetail.DefectiveType = (int)Dictionary.POSUnsoldDefectiveProductType.Functional;
                                    }

                                    _oInvoiceReverseDetail.FaultDesc = oItemRow.Cells[4].Value.ToString();
                                    _oInvoiceReverseDetail.FaultRemarks = oItemRow.Cells[5].Value.ToString();
                                    _oInvoiceReverseDetail.Reason = oItemRow.Cells[6].Value.ToString();
                                    _oInvoiceReverseDetail.JobNo = oItemRow.Cells[7].Value.ToString();
                                }
                                else
                                {
                                    _oInvoiceReverseDetail.StockType = (int)Dictionary.StockType.Unused;
                                    _oInvoiceReverseDetail.DefectiveType = -1;
                                    _oInvoiceReverseDetail.FaultDesc = "";
                                    _oInvoiceReverseDetail.FaultRemarks = "";
                                    _oInvoiceReverseDetail.Reason = "";
                                    _oInvoiceReverseDetail.JobNo = "";
                                }

                               
                                _oInvoiceReverse.Add(_oInvoiceReverseDetail);

                            }
                        }

                        #endregion
                        _oInvoiceReverse.Edit();


                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Update Successfully ", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    _oInvoiceReverse = new InvoiceReverse();
                   
                    _oInvoiceReverse.WarehouseID = Utility.WarehouseID;
                    _oInvoiceReverse.InvoiceNo = lblInvoiceNo.Text;
                    _oInvoiceReverse.Reason = txtReason.Text;
                    _oInvoiceReverse.CreateUserID = Utility.UserId;
                    _oInvoiceReverse.CreateDate = _dtCurrentDate;
                    _oInvoiceReverse.Status = (int)Dictionary.ReverseStatus.Create;
                    try
                    {
                        DBController.Instance.BeginNewTransaction();


                        #region barcode from Invoice Item
                        // Details
                        foreach (DataGridViewRow oItemRow in dgvLineItem1.Rows)
                        {
                            if (oItemRow.Index < dgvLineItem1.Rows.Count)
                            {

                                InvoiceReverseDetail _oInvoiceReverseDetail = new InvoiceReverseDetail();

                                //_oInvoiceReverseDetail.ID = int.Parse(oItemRow.Cells[0].Value.ToString());
                                //_oInvoiceReverseDetail.ReverseID = oItemRow.Cells[3].Value.ToString();
                                
                                _oInvoiceReverseDetail.WarehouseID = Utility.WarehouseID;
                                _oInvoiceReverseDetail.ProductID = int.Parse(oItemRow.Cells[8].Value.ToString());
                                _oInvoiceReverseDetail.ProductSerial = oItemRow.Cells[1].Value.ToString();

                                if (oItemRow.Cells[2].Value.ToString() == Dictionary.StockType.Used.ToString())
                                {
                                    _oInvoiceReverseDetail.StockType = (int)Dictionary.StockType.Used;
                                    if (oItemRow.Cells[3].Value.ToString() == Dictionary.POSUnsoldDefectiveProductType.Aesthetic.ToString())
                                    {
                                        _oInvoiceReverseDetail.DefectiveType = (int)Dictionary.POSUnsoldDefectiveProductType.Aesthetic;
                                    }
                                    else
                                    {
                                        _oInvoiceReverseDetail.DefectiveType = (int)Dictionary.POSUnsoldDefectiveProductType.Functional;
                                    }

                                    _oInvoiceReverseDetail.FaultDesc = oItemRow.Cells[4].Value.ToString();
                                    _oInvoiceReverseDetail.FaultRemarks = oItemRow.Cells[5].Value.ToString();
                                    _oInvoiceReverseDetail.Reason = oItemRow.Cells[6].Value.ToString();
                                    _oInvoiceReverseDetail.JobNo = oItemRow.Cells[7].Value.ToString();
                                                                                                           

                                }
                                else
                                {
                                    _oInvoiceReverseDetail.StockType = (int)Dictionary.StockType.Unused;
                                    _oInvoiceReverseDetail.DefectiveType = -1;
                                    _oInvoiceReverseDetail.FaultDesc = "";
                                    _oInvoiceReverseDetail.FaultRemarks = "";
                                    _oInvoiceReverseDetail.Reason = "";
                                    _oInvoiceReverseDetail.JobNo = "";
                                }

                                _oInvoiceReverse.Add(_oInvoiceReverseDetail);

                            }
                        }

                        #endregion

                        _oInvoiceReverse.Add();
                        
                        

                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Save Successfully ", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }

                }
            }

        }
        public void ShowDialog(InvoiceReverse oInvoiceReverse)
        {
            this.Tag = oInvoiceReverse;
            nReverseID = oInvoiceReverse.ReverseID;
            nWarehouseID = oInvoiceReverse.WarehouseID;
            txtRefInvoiceNo.Text = oInvoiceReverse.InvoiceNo;
            txtReason.Text = oInvoiceReverse.Reason;

            this.ShowDialog();
        }

        private void LoadCombo()
        {
            //Is Repairable
            cmbStockType.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.StockType)))
            {
                cmbStockType.Items.Add(Enum.GetName(typeof(Dictionary.StockType), GetEnum));
            }

            //Defective Type
            cmbDefectiveType.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.POSUnsoldDefectiveProductType)))
            {
                cmbDefectiveType.Items.Add(Enum.GetName(typeof(Dictionary.POSUnsoldDefectiveProductType), GetEnum));
            }
        }
        private void txtRefInvoiceNo_TextChanged(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                _oInvoiceReverse = new InvoiceReverse();
                txtRefInvoiceNo.ForeColor = System.Drawing.Color.Red;

                if (txtRefInvoiceNo.Text.Length == 13)
                {
                    if (!DBController.Instance.CheckConnection())
                    {
                        DBController.Instance.OpenNewConnection();
                    }

                    _oInvoiceReverse.RefreshByInvoiceNo(txtRefInvoiceNo.Text.Trim());
                    if (_oInvoiceReverse.InvoiceNo == null)
                    {
                        _oInvoiceReverse = null;
                        AppLogger.LogFatal("There is no Data.");
                        return;
                    }
                    else
                    {
                        nInvoiceID = 0;
                        nInvoiceID = _oInvoiceReverse.InvoiceID;
                        lblInvoiceNo.Text = _oInvoiceReverse.InvoiceNo;
                        lblInvoiceDate.Text = Convert.ToDateTime(_oInvoiceReverse.InvoiceDate).ToString("dd-MMM-yyyy");
                        lblConsumerName.Text = _oInvoiceReverse.ConsumerName;
                        lblConsumerAddress.Text = _oInvoiceReverse.ConsumerAddress;
                        lblMobile.Text = _oInvoiceReverse.MobileNo;
                        lblEmail.Text = _oInvoiceReverse.Email;
                        _Amt = 0;
                        _DisAmt = 0;
                        _oTELLib = new TELLib();
                        lblInvoiceAmount.Text = _oTELLib.TakaFormat(_oInvoiceReverse.InvoiceAmount);
                        oSalesInvoice = new SalesInvoice();
                        oSalesInvoice.InvoiceID = nInvoiceID;
                        oSalesInvoice.RefreshSalesInvoiceItemForDataSending1();//

                        dgvLineItem.Rows.Clear();
                        foreach (SalesInvoiceItem oSalesInvoiceItem in oSalesInvoice)
                        {
                            DataGridViewRow oRow = new DataGridViewRow();
                            oRow.CreateCells(dgvLineItem1);
                            
                            oRow.Cells[0].Value = oSalesInvoiceItem.ProductName.ToString();
                            oRow.Cells[1].Value = oSalesInvoiceItem.ProductSerial.ToString();
                            oRow.Cells[8].Value = oSalesInvoiceItem.ProductID.ToString();

                            dgvLineItem1.Rows.Add(oRow);
                            _Amt = _Amt + oSalesInvoiceItem.UnitPrice * oSalesInvoiceItem.Quantity;
                            _DisAmt = _DisAmt + oSalesInvoiceItem.PromotionalDiscount;
                        }
                        lblRetailSalesAmt.Text = _oTELLib.TakaFormat(_Amt);
                        lblDiscount.Text = _oTELLib.TakaFormat(oSalesInvoice.Discount + _DisAmt);

                        _oRetailSalesInvoice = new RetailSalesInvoice();
                        _oRetailSalesInvoice.InvoiceID = oSalesInvoice.InvoiceID;
                        _oRetailSalesInvoice.GetSalesInvoiceCharge();

                        lblInstallChange.Text = _oTELLib.TakaFormat(_oRetailSalesInvoice.InstallationCharge);
                        lblFreightCharge.Text = _oTELLib.TakaFormat(_oRetailSalesInvoice.FreightCharge);
                        lblOthersCharge.Text = _oTELLib.TakaFormat(_oRetailSalesInvoice.OtherCharge);


                        txtRefInvoiceNo.ForeColor = System.Drawing.Color.Empty;
                        txtRefInvoiceNo.Enabled = false;
                    }
                }
                else
                {
                    lblInvoiceNo.Text = "";
                    lblInvoiceDate.Text = "";
                    lblConsumerName.Text = "";
                    lblConsumerAddress.Text = "";
                    lblMobile.Text = "";
                    lblEmail.Text = "";
                    dgvLineItem.Rows.Clear();
                    lblInstallChange.Text = "";
                    lblFreightCharge.Text = "";
                    lblOthersCharge.Text = "";
                    lblRetailSalesAmt.Text = "";
                    lblDiscount.Text = "";
                    lblInvoiceAmount.Text = "";

                }
            }
            else
            {
                _oInvoiceReverse = new InvoiceReverse();
                txtRefInvoiceNo.ForeColor = System.Drawing.Color.Red;
                if (txtRefInvoiceNo.Text.Length == 13)
                {
                    if (!DBController.Instance.CheckConnection())
                    {
                        DBController.Instance.OpenNewConnection();
                    }

                    _oInvoiceReverse.RefreshByInvoiceNo(txtRefInvoiceNo.Text.Trim());
                    if (_oInvoiceReverse.InvoiceNo == null)
                    {
                        _oInvoiceReverse = null;
                        AppLogger.LogFatal("There is no Data.");
                        return;
                    }
                    else
                    {
                        nInvoiceID = 0;
                        nInvoiceID = _oInvoiceReverse.InvoiceID;
                        lblInvoiceNo.Text = _oInvoiceReverse.InvoiceNo;
                        lblInvoiceDate.Text = Convert.ToDateTime(_oInvoiceReverse.InvoiceDate).ToString("dd-MMM-yyyy");
                        lblConsumerName.Text = _oInvoiceReverse.ConsumerName;
                        lblConsumerAddress.Text = _oInvoiceReverse.ConsumerAddress;
                        lblMobile.Text = _oInvoiceReverse.MobileNo;
                        lblEmail.Text = _oInvoiceReverse.Email;
                        _Amt = 0;
                        _DisAmt = 0;
                        _oTELLib = new TELLib();
                        lblInvoiceAmount.Text = _oTELLib.TakaFormat(_oInvoiceReverse.InvoiceAmount);
                        oSalesInvoice = new SalesInvoice();
                        oSalesInvoice.InvoiceID = nInvoiceID;
                        oSalesInvoice.RefreshSalesInvoiceItemForDataSending2(nReverseID,nWarehouseID);//

                        dgvLineItem.Rows.Clear();
                        foreach (SalesInvoiceItem oSalesInvoiceItem in oSalesInvoice)
                        {
                            DataGridViewRow oRow = new DataGridViewRow();
                            oRow.CreateCells(dgvLineItem1);
                            

                            oRow.Cells[0].Value = oSalesInvoiceItem.ProductName.ToString();
                            oRow.Cells[1].Value = oSalesInvoiceItem.ProductSerial.ToString();
                            oRow.Cells[2].Value = Enum.GetName(typeof(Dictionary.StockType), oSalesInvoiceItem.StockType);                            
                            oRow.Cells[3].Value = Enum.GetName(typeof(Dictionary.POSUnsoldDefectiveProductType), oSalesInvoiceItem.DefectiveType);
                            oRow.Cells[4].Value = oSalesInvoiceItem.FaultDescription;
                            oRow.Cells[5].Value = oSalesInvoiceItem.FaultRemarks;
                            oRow.Cells[6].Value = oSalesInvoiceItem.Reason;
                            oRow.Cells[7].Value = oSalesInvoiceItem.JobNo;
                            oRow.Cells[8].Value = oSalesInvoiceItem.ProductID.ToString();

                            if (oSalesInvoiceItem.StockType == 1)
                            {
                                oRow.Cells[3].ReadOnly = true;
                                oRow.Cells[4].ReadOnly = true;
                                oRow.Cells[5].ReadOnly = true;
                                oRow.Cells[6].ReadOnly = true;
                                oRow.Cells[7].ReadOnly = true;

                                oRow.Cells[3].Style.BackColor = System.Drawing.Color.LightGray;
                                oRow.Cells[4].Style.BackColor = System.Drawing.Color.LightGray;
                                oRow.Cells[5].Style.BackColor = System.Drawing.Color.LightGray;
                                oRow.Cells[6].Style.BackColor = System.Drawing.Color.LightGray;
                                oRow.Cells[7].Style.BackColor = System.Drawing.Color.LightGray;
                            }

                                dgvLineItem1.Rows.Add(oRow);

                            _Amt = _Amt + oSalesInvoiceItem.UnitPrice * oSalesInvoiceItem.Quantity;
                            _DisAmt = _DisAmt + oSalesInvoiceItem.PromotionalDiscount;
                        }
                        lblRetailSalesAmt.Text = _oTELLib.TakaFormat(_Amt);
                        lblDiscount.Text = _oTELLib.TakaFormat(oSalesInvoice.Discount + _DisAmt);

                        _oRetailSalesInvoice = new RetailSalesInvoice();
                        _oRetailSalesInvoice.InvoiceID = oSalesInvoice.InvoiceID;
                        _oRetailSalesInvoice.GetSalesInvoiceCharge();

                        lblInstallChange.Text = _oTELLib.TakaFormat(_oRetailSalesInvoice.InstallationCharge);
                        lblFreightCharge.Text = _oTELLib.TakaFormat(_oRetailSalesInvoice.FreightCharge);
                        lblOthersCharge.Text = _oTELLib.TakaFormat(_oRetailSalesInvoice.OtherCharge);


                        txtRefInvoiceNo.ForeColor = System.Drawing.Color.Empty;
                        txtRefInvoiceNo.Enabled = false;
                    }
                }
            }
        }

        private void frmInvoiceReverseApply_Load(object sender, EventArgs e)
        {
            LoadCombo();
        }

        private void dgvLineItem1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgvLineItem1.CurrentCell.ColumnIndex == 2 && e.Control is ComboBox)
            {
                ComboBox comboBox = e.Control as ComboBox;
                comboBox.SelectedIndexChanged -= LastColumnComboSelectionChanged;
                comboBox.SelectedIndexChanged += LastColumnComboSelectionChanged;
            }
        }

        private void LastColumnComboSelectionChanged(object sender, EventArgs e)
        {
            var currentcell = dgvLineItem1.CurrentCellAddress;
            var sendingCB = sender as DataGridViewComboBoxEditingControl;
            DataGridViewTextBoxCell cel = (DataGridViewTextBoxCell)dgvLineItem1.Rows[currentcell.Y].Cells[0];
            
            if(sendingCB.EditingControlFormattedValue.ToString() == "Unused")
            {
                dgvLineItem1.Rows[currentcell.Y].Cells[3].Value = "";
                dgvLineItem1.Rows[currentcell.Y].Cells[4].Value = "";
                dgvLineItem1.Rows[currentcell.Y].Cells[5].Value = "";

                dgvLineItem1.Rows[currentcell.Y].Cells[3].ReadOnly = true;
                dgvLineItem1.Rows[currentcell.Y].Cells[4].ReadOnly = true;
                dgvLineItem1.Rows[currentcell.Y].Cells[5].ReadOnly = true;
                dgvLineItem1.Rows[currentcell.Y].Cells[6].ReadOnly = true;
                dgvLineItem1.Rows[currentcell.Y].Cells[7].ReadOnly = true;

                dgvLineItem1.Rows[currentcell.Y].Cells[3].Style.BackColor = System.Drawing.Color.LightGray;
                dgvLineItem1.Rows[currentcell.Y].Cells[4].Style.BackColor = System.Drawing.Color.LightGray;
                dgvLineItem1.Rows[currentcell.Y].Cells[5].Style.BackColor = System.Drawing.Color.LightGray;
                dgvLineItem1.Rows[currentcell.Y].Cells[6].Style.BackColor = System.Drawing.Color.LightGray;
                dgvLineItem1.Rows[currentcell.Y].Cells[7].Style.BackColor = System.Drawing.Color.LightGray;
                //cmbDefectiveType.ReadOnly = true;
                //txtFaultDesc.ReadOnly = true;
                //txtFaultRemarks.ReadOnly = true;
            }
            else
            {
                dgvLineItem1.Rows[currentcell.Y].Cells[3].ReadOnly = false;
                dgvLineItem1.Rows[currentcell.Y].Cells[4].ReadOnly = false;
                dgvLineItem1.Rows[currentcell.Y].Cells[5].ReadOnly = false;
                dgvLineItem1.Rows[currentcell.Y].Cells[6].ReadOnly = false;
                dgvLineItem1.Rows[currentcell.Y].Cells[7].ReadOnly = false;

                dgvLineItem1.Rows[currentcell.Y].Cells[3].Value = "Aesthetic";
                dgvLineItem1.Rows[currentcell.Y].Cells[4].Style.BackColor = System.Drawing.Color.White;
                dgvLineItem1.Rows[currentcell.Y].Cells[5].Style.BackColor = System.Drawing.Color.White;
                dgvLineItem1.Rows[currentcell.Y].Cells[6].Style.BackColor = System.Drawing.Color.White;
                dgvLineItem1.Rows[currentcell.Y].Cells[7].Style.BackColor = System.Drawing.Color.White;
            }
        }
    }
}
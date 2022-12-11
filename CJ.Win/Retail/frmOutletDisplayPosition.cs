using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;

namespace CJ.Win.Retail
{
    public partial class frmOutletDisplayPosition : Form
    {
        Showrooms _oShowrooms;
        ProductGroups _oMAGs;
        OutletDisplayPosition _oOutletDisplayPosition;
        int nDisplayPositionID = 0;
        int nWHID = 0;
        string sPositionCode = "";
        public bool _Istrue = false;
        OutletDisplayPositions _oOutletDisplayPositionRack;
        string _ProductSerialNo = "";
        
        public frmOutletDisplayPosition()
        {
            InitializeComponent();

            //dtSaleAfter.MinDate = DateTime.Today.AddDays(-1);
        }
        public void ShowDialog(OutletDisplayPosition oOutletDisplayPosition)
        {
            this.Tag = oOutletDisplayPosition;
            LoadCombo();
            nDisplayPositionID = 0;
            nWHID = 0;
            sPositionCode = "";

            nDisplayPositionID = oOutletDisplayPosition.DisplayPositionID;
            nWHID = oOutletDisplayPosition.WHID;
            sPositionCode = oOutletDisplayPosition.PositionCode;
            ctlProduct1.txtCode.Text = oOutletDisplayPosition.ProductCode;
            txtPositionName.Text = oOutletDisplayPosition.PositionName;
            int nOutletIndex = 0;
            nOutletIndex = _oShowrooms.GetIndexWHID(oOutletDisplayPosition.WHID);
            cmbOutlet.SelectedIndex = nOutletIndex + 1;
            cmbOutlet.Enabled = false;

            int nRackIndex = 0;
            nRackIndex = _oOutletDisplayPositionRack.GetIndexRack(oOutletDisplayPosition.RackID);
            cmbRackName.SelectedIndex = nRackIndex + 1;

            if (oOutletDisplayPosition.IsActive == (int)Dictionary.IsActive.Active)
            {
                chkIsActive.Checked = true;
            }
            else
            {
                chkIsActive.Checked = false;
            }

            //txtSaleAfter.Text = Convert.ToDateTime(oOutletDisplayPosition.SaleAfter).ToString("dd-MMM-yyyy");
           
            if (oOutletDisplayPosition.SaleAfter != null)
            {
                dtSaleAfter.Visible = true;
                cbSetSaleAfter.Checked = true;
                dtSaleAfter.Value = Convert.ToDateTime(oOutletDisplayPosition.SaleAfter);
            }
            else
            {
                dtSaleAfter.Visible = false;
                cbSetSaleAfter.Checked = false;
                dtSaleAfter.Value = DateTime.Today;
            }
            if (oOutletDisplayPosition.ProductSerialNo == null)
            {
                _ProductSerialNo = "";
            }
            else
            {
                _ProductSerialNo = oOutletDisplayPosition.ProductSerialNo;
            }

            if (oOutletDisplayPosition.OpenForAll == true)
            {
                cbOpenForAll.Checked = true;
            }
            else
            {
                cbOpenForAll.Checked = false;
            }
            this.ShowDialog();
        }
        private void LoadCombo()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            _oShowrooms = new Showrooms();
            _oShowrooms.Refresh();
            cmbOutlet.Items.Clear();
            cmbOutlet.Items.Add("-- Select --");
            foreach (Showroom oShowroom in _oShowrooms)
            {
                cmbOutlet.Items.Add(oShowroom.ShowroomName + "[" + oShowroom.ShowroomCode + "]");
            }
            cmbOutlet.SelectedIndex = 0;
            LoadRack();
        }

        private void LoadRack()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            _oOutletDisplayPositionRack = new OutletDisplayPositions();
            _oOutletDisplayPositionRack.RefreshRack();
            cmbRackName.Items.Clear();
            cmbRackName.Items.Add("-- Select --");
            foreach (OutletDisplayPosition oOutletDisplayPositionRack in _oOutletDisplayPositionRack)
            {
                cmbRackName.Items.Add(oOutletDisplayPositionRack.RackName);
            }
            cmbRackName.SelectedIndex = 0;
        }
        private void frmOutletDisplayPosition_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                chkIsActive.Enabled = false;
                this.Text = "Add Display Position";
                LoadCombo();
            }
            else
            {
                this.Text = "Edit Display Position";
                chkIsActive.Enabled = true;
            }
        }
        private bool UIValidation()
        {
            #region ValidInput
            if (cmbOutlet.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Outlet", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbOutlet.Focus();
                return false;
            }
            if (ctlProduct1.txtDescription.Text == "")
            {
                MessageBox.Show("Please Select Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlProduct1.txtDescription.Focus();
                return false;
            }
            if (txtPositionName.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Display Position Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPositionName.Focus();
                return false;
            }

            if (txtProductModel.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Product Model", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductModel.Focus();
                return false;
            }
            if (cbSetSaleAfter.Checked == true)
            {
                if (Convert.ToDateTime(dtSaleAfter.Value) < DateTime.Today.AddDays(-1))
                {
                    MessageBox.Show("Sale After Date is not valid", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    dtSaleAfter.Focus();
                    return false;
                }
            }
            #endregion

            return true;

        }
        private void Save()
        {
            if (this.Tag == null)
            {
                _oOutletDisplayPosition = new OutletDisplayPosition();
                _oOutletDisplayPosition.PositionName = txtPositionName.Text;
                _oOutletDisplayPosition.MAGID = ctlProduct1.SelectedSerarchProduct.MAGID;
                _oOutletDisplayPosition.ProductID = ctlProduct1.SelectedSerarchProduct.ProductID;
                _oOutletDisplayPosition.WHID = _oShowrooms[cmbOutlet.SelectedIndex - 1].WarehouseID;
                _oOutletDisplayPosition.RackID = _oOutletDisplayPositionRack[cmbRackName.SelectedIndex - 1].RackID;
                if (chkIsActive.Checked == true)
                {
                    _oOutletDisplayPosition.IsActive = (int)Dictionary.IsActive.Active;
                }
                else
                {
                    _oOutletDisplayPosition.IsActive = (int)Dictionary.IsActive.InActive;
                }
                _oOutletDisplayPosition.Status = (int)Dictionary.DisplayPositionStatus.Blank;
                _oOutletDisplayPosition.CreateDate = DateTime.Now;
                _oOutletDisplayPosition.CreateUserID = Utility.UserId;
                //_oOutletDisplayPosition.SaleAfter = null;
                if (cbSetSaleAfter.Checked)
                {
                    _oOutletDisplayPosition.SaleAfter = dtSaleAfter.Value;
                }
                else
                {
                    _oOutletDisplayPosition.SaleAfter = null;
                }
                _oOutletDisplayPosition.OpenForAll = _bOpenForAll;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oOutletDisplayPosition.Add();

                    DataTran oDataTran = new DataTran();
                    oDataTran.TableName = "t_OutletDisplayPosition";
                    oDataTran.DataID = Convert.ToInt32(_oOutletDisplayPosition.DisplayPositionID);
                    oDataTran.WarehouseID = Convert.ToInt32(_oOutletDisplayPosition.WHID);
                    oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                    oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                    oDataTran.BatchNo = 0;
                    if (oDataTran.CheckData() == false)
                    {
                        oDataTran.AddForTDPOS();
                    }
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Add Display Position. Showroom Code : " + _oShowrooms[cmbOutlet.SelectedIndex - 1].ShowroomCode, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                _oOutletDisplayPosition = new OutletDisplayPosition();
                _oOutletDisplayPosition.DisplayPositionID = nDisplayPositionID;
                _oOutletDisplayPosition.PositionName = txtPositionName.Text;
                _oOutletDisplayPosition.MAGID = ctlProduct1.SelectedSerarchProduct.MAGID;
                _oOutletDisplayPosition.ProductID = ctlProduct1.SelectedSerarchProduct.ProductID;
                _oOutletDisplayPosition.WHID = _oShowrooms[cmbOutlet.SelectedIndex - 1].WarehouseID;
                _oOutletDisplayPosition.RackID = _oOutletDisplayPositionRack[cmbRackName.SelectedIndex - 1].RackID;
                if (chkIsActive.Checked == true)
                {
                    _oOutletDisplayPosition.IsActive = (int)Dictionary.IsActive.Active;
                }
                else
                {
                    _oOutletDisplayPosition.IsActive = (int)Dictionary.IsActive.InActive;
                }

                _oOutletDisplayPosition.Status = (int)Dictionary.DisplayPositionStatus.Blank;
                _oOutletDisplayPosition.UpdateDate = DateTime.Now;
                _oOutletDisplayPosition.UpdateUserID = Utility.UserId;

                if (cbSetSaleAfter.Checked)
                {
                    _oOutletDisplayPosition.SaleAfter = dtSaleAfter.Value;
                }
                else
                {
                    _oOutletDisplayPosition.SaleAfter = null;
                }

                _oOutletDisplayPosition.OpenForAll = _bOpenForAll;
                //if (_ProductSerialNo != "")
                //{
                //    _oOutletDisplayPosition.SaleAfter = dtAfterSale.Value;
                //}
                //else
                //{
                //    _oOutletDisplayPosition.SaleAfter = null;
                //}


                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oOutletDisplayPosition.Edit();
                    DataTran oDataTran = new DataTran();
                    oDataTran.TableName = "t_OutletDisplayPosition";
                    oDataTran.DataID = Convert.ToInt32(nDisplayPositionID);
                    oDataTran.WarehouseID = Convert.ToInt32(_oOutletDisplayPosition.WHID);
                    oDataTran.TransferType = (int)Dictionary.DataTransferType.Edit;
                    oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                    oDataTran.BatchNo = 0;
                    if (oDataTran.CheckData() == false)
                    {
                        oDataTran.AddForTDPOS();
                    }

                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Update Display Position. Showroom Code : " + _oShowrooms[cmbOutlet.SelectedIndex - 1].ShowroomCode, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                Save();
                _Istrue = true;
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            _Istrue = false;
            this.Close();
        }

        private void ctlProduct1_ChangeSelection(object sender, EventArgs e)
        {
            if (ctlProduct1.txtDescription.Text != "")
            {
                txtProductModel.Text = ctlProduct1.SelectedSerarchProduct.ProductModel;
            }
            else
            {
                txtProductModel.Text = "";
            }
        }

        private void btnAddRack_Click(object sender, EventArgs e)
        {
            frmOutletDisplayPositionRack ofrmOutletDisplayPositionRack = new frmOutletDisplayPositionRack();
            ofrmOutletDisplayPositionRack.ShowDialog();
            if (ofrmOutletDisplayPositionRack._Istrue == true)
            {
                LoadRack();
            }

        }

        private void dtAfterSale_ValueChanged(object sender, EventArgs e)
        {
            //txtSaleAfter.Text = dtAfterSale.Value.ToString("dd-MMM-yyyy");
        }

        private void cbSetSaleAfter_CheckedChanged(object sender, EventArgs e)
        {
            if(cbSetSaleAfter.Checked)
            {
                dtSaleAfter.Visible = true;
            }
            else
            {
                dtSaleAfter.Visible = false;
            }
        }

        private bool _bOpenForAll=false;
        private void cbOpenForAll_CheckedChanged(object sender, EventArgs e)
        {
            if(cbOpenForAll.Checked)
            {
                _bOpenForAll = true;
            }
            else
            {
                _bOpenForAll = false;
            }
        }
    }
}
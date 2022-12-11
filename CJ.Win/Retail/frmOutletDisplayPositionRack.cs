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
using CJ.Class.POS;

namespace CJ.Win.Retail
{
    public partial class frmOutletDisplayPositionRack : Form
    {
        OutletDisplayPosition _oOutletDisplayPosition;
        public bool _Istrue = false;
        int nRackID = 0;

        public frmOutletDisplayPositionRack()
        {
            InitializeComponent();
        }
        public void ShowDialog(OutletDisplayPosition oOutletDisplayPosition)
        {
            this.Tag = oOutletDisplayPosition;

            nRackID = oOutletDisplayPosition.RackID;
            txtRackName.Text = oOutletDisplayPosition.RackName;
            if (oOutletDisplayPosition.IsActive == (int)Dictionary.IsActive.Active)
            {
                chkIsActive.Checked = true;
            }
            else
            {
                chkIsActive.Checked = false;
            }

            this.ShowDialog();
        }
        private bool UIValidation()
        {
            #region ValidInput
            if (txtRackName.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Rack Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtRackName.Focus();
                return false;
            }
            #endregion

            return true;

        }
        private void Save()
        {
            if (this.Tag == null)
            {
                _oOutletDisplayPosition = new OutletDisplayPosition();
                _oOutletDisplayPosition.RackName = txtRackName.Text;

                if (chkIsActive.Checked == true)
                {
                    _oOutletDisplayPosition.IsActive = (int)Dictionary.IsActive.Active;
                }
                else
                {
                    _oOutletDisplayPosition.IsActive = (int)Dictionary.IsActive.InActive;
                }
                _oOutletDisplayPosition.CreateDate = DateTime.Now;
                _oOutletDisplayPosition.CreateUserID = Utility.UserId;


                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oOutletDisplayPosition.AddRack();
                    Showrooms oShowrooms = new Showrooms();
                    oShowrooms.Refresh();
                    foreach (Showroom oShowroom in oShowrooms)
                    {
                        DataTran oDataTran = new DataTran();
                        oDataTran.TableName = "t_OutletDisplayPositionRack";
                        oDataTran.DataID = Convert.ToInt32(_oOutletDisplayPosition.RackID);
                        oDataTran.WarehouseID = oShowroom.WarehouseID;
                        oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                        oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                        oDataTran.BatchNo = 0;
                        if (oDataTran.CheckDataByWHID() == false)
                        {
                            oDataTran.AddForTDPOS();
                        }
                    }
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Add Display Position Rack. Rack Name : " + txtRackName.Text, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                _oOutletDisplayPosition.RackID = nRackID;
                _oOutletDisplayPosition.RackName = txtRackName.Text;
                if (chkIsActive.Checked == true)
                {
                    _oOutletDisplayPosition.IsActive = (int)Dictionary.IsActive.Active;
                }
                else
                {
                    _oOutletDisplayPosition.IsActive = (int)Dictionary.IsActive.InActive;
                }
                _oOutletDisplayPosition.UpdateDate = DateTime.Now.Date;
                _oOutletDisplayPosition.UpdateUserID = Utility.UserId;


                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oOutletDisplayPosition.EditRack();
                    
                    Showrooms oShowrooms = new Showrooms();
                    oShowrooms.Refresh();
                    foreach (Showroom oShowroom in oShowrooms)
                    {
                        DataTran oDataTran = new DataTran();
                        oDataTran.TableName = "t_OutletDisplayPositionRack";
                        oDataTran.DataID = Convert.ToInt32(_oOutletDisplayPosition.RackID);
                        oDataTran.WarehouseID = oShowroom.WarehouseID;
                        oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                        oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                        oDataTran.BatchNo = 0;
                        if (oDataTran.CheckDataByWHID() == false)
                        {
                            oDataTran.AddForTDPOS();
                        }
                    }

                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Add Display Position Rack. Rack Name : " + txtRackName.Text, "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

        private void frmOutletDisplayPositionRack_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add Display Position Rack";
                chkIsActive.Visible = false;
            }
            else
            {
                this.Text = "Edit Display Position Rack";
                chkIsActive.Visible = true;
            }
        }
    }
}

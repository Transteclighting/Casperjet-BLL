using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Library;
using CJ.Class.Accounts;
using System.Data.OleDb;
using System.Threading;


using CJ.Class;
using CJ.Class.POS;

namespace CJ.Win
{
    public partial class frmOutletDisplayPositionExeclUploader : Form
    {
        Companys _oCompanys;
        private DataTable _oDT;
        private int nArrayLen = 0;
        private string[] sProductBarcodeArr = null;
        OutletDisplayPosition _OutletDisplayPosition;
        DataTran oDataTransfer;
        //MobileNumberAssign _oMobileNumberAssign;

        public frmOutletDisplayPositionExeclUploader()
        {
            InitializeComponent();
        }

        private void frmMobileBillExeclUploader_Load(object sender, EventArgs e)
        {
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                this.Cursor = Cursors.WaitCursor;
                Save();
                this.Cursor = Cursors.Default;
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            bool IsSelected = false;
            this.openFileDialogData.FileName = "";
            this.openFileDialogData.Multiselect = false;
            this.openFileDialogData.Filter = "";
            this.openFileDialogData.Filter = "Excel 2007+ Sheet(*.xlsx)|*.xlsx|Excel Sheet(*.xls)|*.xls";
            if (this.openFileDialogData.ShowDialog() == DialogResult.OK)
            {
                this.txtXLFilePath.Text = this.openFileDialogData.FileName.ToString();
                this.Text = this.openFileDialogData.DefaultExt.ToString();
                IsSelected = true;
            }

            if (IsSelected)
            {
                LoadSheets();
            }
            //GetTotalAmount();
        }

        private void LoadSheets()
        {
            OleDbConnection oConn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + txtXLFilePath.Text + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1;\"");
            oConn.Open();

            OleDbDataAdapter oDataAdapter = new OleDbDataAdapter("SELECT * FROM [Sheet1$]", oConn);

            DataSet oDS = new DataSet();
            _oDT = new DataTable();
            oDataAdapter.Fill(_oDT);
            dgvOutletDisplay.DataSource = _oDT.DefaultView;
            this.Text = "Load From XL [" + _oDT.Rows.Count + "]";

            dgvOutletDisplay.ReadOnly = true;
        }

       
        private bool validateUIInput()
        {
            if (dgvOutletDisplay.Rows.Count == 0)
            {
                MessageBox.Show("No Data To Save Display Position", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (rbAddNew.Checked == false && rbEdit.Checked==false)
            {
                MessageBox.Show("Please select Radio Button Add Or Edit", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private void Save()
        {
            if(rbAddNew.Checked==true)
            {
                string _DisplayPositionCode = "";
                DBController.Instance.OpenNewConnection();
                OleDbCommand cmd = DBController.Instance.GetCommand();

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    foreach (DataGridViewRow oItemRow in dgvOutletDisplay.Rows)
                    {
                        _OutletDisplayPosition = new OutletDisplayPosition();

                        Showroom oShowroom = new Showroom();
                        oShowroom.ShowroomCode = Convert.ToString(oItemRow.Cells[0].Value.ToString());
                        oShowroom.GetWHIDByCode();

                        OutletDisplayPosition oDPRack = new OutletDisplayPosition();
                        string sRack = Convert.ToString(oItemRow.Cells[3].Value.ToString());
                        oDPRack.RefreshRackNew(sRack);

                        Product oPro = new Product();
                        oPro.ProductCode = Convert.ToString(oItemRow.Cells[5].Value.ToString());
                        oPro.RefreshByCode();

                        _OutletDisplayPosition.PositionName = oItemRow.Cells[2].Value.ToString();
                        _OutletDisplayPosition.MAGID = oPro.MAGID;
                        _OutletDisplayPosition.ProductID = oPro.ProductID;
                        _OutletDisplayPosition.WHID = oShowroom.WarehouseID;
                        _OutletDisplayPosition.RackID = oDPRack.RackID;
                      
                        _OutletDisplayPosition.IsActive = (int)Dictionary.IsActive.Active;
                       
                        _OutletDisplayPosition.Status = (int)Dictionary.DisplayPositionStatus.Blank;
                        _OutletDisplayPosition.CreateDate = DateTime.Now;
                        _OutletDisplayPosition.CreateUserID = Utility.UserId;

                        try
                        {
                            _OutletDisplayPosition.SaleAfter = Convert.ToDateTime(oItemRow.Cells[6].Value.ToString());
                        }
                        catch
                        {
                            _OutletDisplayPosition.SaleAfter = null;
                        }

                        _OutletDisplayPosition.OpenForAll = Convert.ToBoolean(oItemRow.Cells[7].Value.ToString());
                        _OutletDisplayPosition.Add();


                        oDataTransfer = new DataTran();
                        oDataTransfer.TableName = "t_OutletDisplayPosition";
                        oDataTransfer.DataID = Convert.ToInt32(_OutletDisplayPosition.DisplayPositionID);
                        oDataTransfer.WarehouseID = oShowroom.WarehouseID;
                        oDataTransfer.TransferType = 1;
                        oDataTransfer.IsDownload = (int)Dictionary.IsDownload.No;
                        oDataTransfer.BatchNo = 0;

                        if (oDataTransfer.CheckData() == false)
                        {
                            oDataTransfer.AddForTDPOS();
                        }
                    }
                    if (dgvOutletDisplay.Rows.Count > 0)
                    {
                        MessageBox.Show("You Have Successfully Inserted Display Positions from Excel.", "Insert", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DBController.Instance.CommitTransaction();
                    }
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
            
            if(rbEdit.Checked==true)
            {
                string _DisplayPositionCode = "";
                DBController.Instance.OpenNewConnection();
                OleDbCommand cmd = DBController.Instance.GetCommand();

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    foreach (DataGridViewRow oItemRow in dgvOutletDisplay.Rows)
                    {
                        Showroom oShowroom = new Showroom();
                        oShowroom.ShowroomCode = Convert.ToString(oItemRow.Cells[0].Value.ToString());
                        oShowroom.GetWHIDByCode();

                        OutletDisplayPosition oDP = new OutletDisplayPosition();
                        string sDisplayPositionCode = Convert.ToString(oItemRow.Cells[1].Value.ToString());
                        oDP.PositionCode = sDisplayPositionCode.Trim();
                        oDP.WHID = oShowroom.WarehouseID;
                        oDP.RefreshPositionCode();

                        OutletDisplayPosition oDPRack = new OutletDisplayPosition();
                        string sRack = Convert.ToString(oItemRow.Cells[3].Value.ToString());
                        oDPRack.RefreshRackNew(sRack);

                        Product oPro = new Product();
                        oPro.ProductCode= Convert.ToString(oItemRow.Cells[5].Value.ToString());
                        oPro.RefreshByCode();

                        _OutletDisplayPosition = new OutletDisplayPosition();
                        _OutletDisplayPosition.DisplayPositionID = oDP.DisplayPositionID;
                        _OutletDisplayPosition.PositionCode = oDP.PositionCode;
                        _OutletDisplayPosition.PositionName = oItemRow.Cells[2].Value.ToString();
                        _OutletDisplayPosition.WHID = oShowroom.WarehouseID;
                        _OutletDisplayPosition.ProductID = oPro.ProductID;
                        _OutletDisplayPosition.MAGID = oPro.MAGID;
                        _OutletDisplayPosition.RackID = oDPRack.RackID;
                       
                        _OutletDisplayPosition.SaleAfter = Convert.ToDateTime(oItemRow.Cells[6].Value.ToString());
                        _OutletDisplayPosition.OpenForAll= Convert.ToBoolean(oItemRow.Cells[7].Value.ToString());
                        _OutletDisplayPosition.IsActive = Convert.ToInt32(oItemRow.Cells[8].Value.ToString());
                        _OutletDisplayPosition.UpdateUserID = Utility.UserId;
                        _OutletDisplayPosition.UpdateDate = DateTime.Now;

                        _OutletDisplayPosition.EditForExcel();


                        oDataTransfer = new DataTran();
                        oDataTransfer.TableName = "t_OutletDisplayPosition";
                        oDataTransfer.DataID = oDP.DisplayPositionID;
                        oDataTransfer.WarehouseID = oShowroom.WarehouseID;
                        oDataTransfer.TransferType = 2;
                        oDataTransfer.IsDownload = (int)Dictionary.IsDownload.No;
                        oDataTransfer.BatchNo = 0;

                        if (oDataTransfer.CheckData() == false)
                        {
                            oDataTransfer.AddForTDPOS();
                        }

                    }
                    if (dgvOutletDisplay.Rows.Count > 0)
                    {
                        MessageBox.Show("You Have Successfully Update Display Positions from Excel." , "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DBController.Instance.CommitTransaction();
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
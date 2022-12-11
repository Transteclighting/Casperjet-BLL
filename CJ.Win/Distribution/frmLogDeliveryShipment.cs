using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Distribution;
using CJ.Class.Library;

namespace CJ.Win.Distribution
{
    public partial class frmLogDeliveryShipment : Form
    {
        public bool _IsTrue = false;
        Vehicles _oVehicles;
        ShipmentVehicle _oShipmentVehicle;
        ShipmentVehicles _oShipmentVehicles;
        ShipmentVehicle _oEditShipmentVehicle;
        int nShipmentID = 0;
        int _nType = 0;
        string _sShipmentNo = "";

        DateTimePicker dtp = new DateTimePicker();
        Rectangle _Rectangle;

        public frmLogDeliveryShipment(int nType)
        {
            InitializeComponent();
            _nType = nType;
        }


        public void GetStockAmount(ShipmentVehicles oShipmentVehicles)
        {
            txtStockAmount.Text = "0.00";
            TELLib oTELLib = new TELLib();
            if (_nType == 1)
            {
                foreach (ShipmentVehicle oShipmentVehicle in oShipmentVehicles)
                {
                    txtStockAmount.Text = oTELLib.TakaFormat(Convert.ToDouble(Convert.ToDouble(txtStockAmount.Text) + Convert.ToDouble(oShipmentVehicle.TranAmount))).ToString();
                }
            }
        }


        public void ShowDialog(ShipmentVehicles oShipmentVehicles,string sGatePassNo)
        {
            this.Text = "Add New Shipment";
            txtGatePassNo.Text = sGatePassNo.ToString();
            if (_nType == 1)
            {
                dgvDeliveryShipment.Columns[13].ReadOnly = true;
                dgvDeliveryShipment.Columns[14].ReadOnly = true;
                dgvDeliveryShipment.Columns[15].ReadOnly = true;

                dgvDeliveryShipment.Columns[13].Visible = false;
                dgvDeliveryShipment.Columns[14].Visible = false;
                dgvDeliveryShipment.Columns[15].Visible = false;

            }
            else
            {
                dgvDeliveryShipment.Columns[13].ReadOnly = false;
                dgvDeliveryShipment.Columns[14].ReadOnly = false;
                dgvDeliveryShipment.Columns[15].ReadOnly = false;
                dgvDeliveryShipment.Columns[13].Visible = true;
                dgvDeliveryShipment.Columns[14].Visible = true;
                dgvDeliveryShipment.Columns[15].Visible = true;
            }
            //LoadCombos();
            _oShipmentVehicles = oShipmentVehicles;
            GetStockAmount(oShipmentVehicles);
            foreach (ShipmentVehicle oShipmentVehicle in oShipmentVehicles)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvDeliveryShipment);

                oRow.Cells[0].Value = oShipmentVehicle.Company.ToString();
                oRow.Cells[1].Value = Enum.GetName(typeof(Dictionary.LogDeliveryShipmentDeliveryMode), oShipmentVehicle.DeliveryMode);

                if (oShipmentVehicle.ParcelType == 0)
                {
                    oRow.Cells[2].Value = "N/A";
                }
                else
                {
                    oRow.Cells[2].Value = Enum.GetName(typeof(Dictionary.LogDeliveryShipmentParcelType), oShipmentVehicle.ParcelType);
                }
                oRow.Cells[3].Value = oShipmentVehicle.VendorName.ToString();
                oRow.Cells[4].Value = oShipmentVehicle.VehicleNo.ToString();
                oRow.Cells[5].Value = oShipmentVehicle.TType.ToString();
                oRow.Cells[6].Value = oShipmentVehicle.TranNo;
                oRow.Cells[7].Value = Convert.ToDateTime(oShipmentVehicle.TranDate).ToString("dd-MMM-yyyy");
                TELLib _oTELLib = new TELLib();
                oRow.Cells[8].Value = _oTELLib.TakaFormat(oShipmentVehicle.TranAmount).ToString();
                oRow.Cells[9].Value = "0.00";
                oRow.Cells[10].Value = "0.00";

                if (oShipmentVehicle.DeliveryMode == (int)Dictionary.LogDeliveryShipmentDeliveryMode.Parcel_Delivery)
                {
                    ArrayList StingList = new ArrayList();
                    Vehicles _oVendors = new Vehicles();
                    _oVendors.GetVendorByDeliveryMode((int)Dictionary.LogDeliveryShipmentVendorType.Parcel_Vendor, 2);
                    foreach (Vehicle oItem in _oVendors)
                    {
                        StingList.Add(oItem.VendorName);
                    }
                    var CellSample = new DataGridViewComboBoxCell();
                    CellSample.DataSource = StingList;
                    oRow.Cells[11] = CellSample;
                }
                else
                {
                    ArrayList StingList = new ArrayList();
                    StingList.Add("N/A");
                    var CellSample = new DataGridViewComboBoxCell();
                    CellSample.DataSource = StingList;
                    oRow.Cells[11] = CellSample;

                }


                oRow.Cells[12].Value = "0.00";
                oRow.Cells[13].Value = false;
                oRow.Cells[14].Style.BackColor = Color.LightGray;
                oRow.Cells[15].Style.BackColor = Color.LightGray;
                oRow.Cells[14].Value = Convert.ToDateTime(oShipmentVehicle.TranDate).ToString("dd-MMM-yyyy");
                oRow.Cells[15].Value = DateTime.Now.ToString("hh:mm tt");
                oRow.Cells[16].Value = "";
                oRow.Cells[17].Value = oShipmentVehicle.TranID.ToString();
                oRow.Cells[18].Value = oShipmentVehicle.VendorID.ToString();
                oRow.Cells[19].Value = oShipmentVehicle.VehicleID.ToString();
                oRow.Cells[20].Value = oShipmentVehicle.DeliveryMode.ToString();
                oRow.Cells[21].Value = oShipmentVehicle.ParcelType.ToString();
                oRow.Cells[22].Value = -1;
                oRow.Cells[23].Value = oShipmentVehicle.VehicleCapacity.ToString();
                dgvDeliveryShipment.Rows.Add(oRow);
            }

            GetTotal();
            this.ShowDialog();
        }

        public void ShowDialog(ShipmentVehicle oShipmentVehicle)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            this.Text = "Edit Shipment";
            //LoadCombos();
            if (_nType == 1)
            {
                dgvDeliveryShipment.Columns[13].ReadOnly = true;
                dgvDeliveryShipment.Columns[14].ReadOnly = true;
                dgvDeliveryShipment.Columns[15].ReadOnly = true;

                dgvDeliveryShipment.Columns[13].Visible = false;
                dgvDeliveryShipment.Columns[14].Visible = false;
                dgvDeliveryShipment.Columns[15].Visible = false;

            }
            else
            {
                dgvDeliveryShipment.Columns[13].ReadOnly = false;
                dgvDeliveryShipment.Columns[14].ReadOnly = false;
                dgvDeliveryShipment.Columns[15].ReadOnly = false;

                dgvDeliveryShipment.Columns[13].Visible = true;
                dgvDeliveryShipment.Columns[14].Visible = true;
                dgvDeliveryShipment.Columns[15].Visible = true;
            }
            dtShipmentDate.Value = oShipmentVehicle.ShipmentDate.Date;
            txtGatePassNo.Text = oShipmentVehicle.GatePassNo;
            txtFreghtAmount.Text = oShipmentVehicle.FreightCost.ToString();
            nShipmentID = oShipmentVehicle.ShipmentID;
            _sShipmentNo = oShipmentVehicle.ShipmentNo;
            oShipmentVehicle.GetShipmentData(oShipmentVehicle.ShipmentID);
            _oEditShipmentVehicle = oShipmentVehicle;
            foreach (LogDeliveryShipmentItem oItem in oShipmentVehicle)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvDeliveryShipment);
                oRow.Cells[0].Value = oItem.Company.ToString();
                oRow.Cells[1].Value = Enum.GetName(typeof(Dictionary.LogDeliveryShipmentDeliveryMode), oItem.DeliveryMode);

                if (oItem.ParcelType == 0)
                {
                    oRow.Cells[2].Value = "N/A";
                }
                else
                {
                    oRow.Cells[2].Value = Enum.GetName(typeof(Dictionary.LogDeliveryShipmentParcelType), oItem.ParcelType);
                }
                oRow.Cells[3].Value = oItem.VendorName.ToString();
                oRow.Cells[4].Value = oItem.VehicleNo.ToString();
                oRow.Cells[5].Value = oItem.TranType.ToString();
                oRow.Cells[6].Value = oItem.TranNo;
                oRow.Cells[7].Value = Convert.ToDateTime(oItem.TranDate).ToString("dd-MMM-yyyy");
                TELLib _oTELLib = new TELLib();
                oRow.Cells[8].Value = _oTELLib.TakaFormat(oItem.StockPrice).ToString();
                oRow.Cells[9].Value = _oTELLib.TakaFormat(oItem.FreightCost).ToString();
                oRow.Cells[10].Value = _oTELLib.TakaFormat(oItem.ParcelCost).ToString();

                if (oItem.DeliveryMode == (int)Dictionary.LogDeliveryShipmentDeliveryMode.Parcel_Delivery)
                {
                    ArrayList StingList = new ArrayList();
                    Vehicles _oVendors = new Vehicles();
                    _oVendors.GetVendorByDeliveryMode((int)Dictionary.LogDeliveryShipmentVendorType.Parcel_Vendor, 2);
                    foreach (Vehicle oItems in _oVendors)
                    {
                        StingList.Add(oItems.VendorName);
                    }
                    var CellSample = new DataGridViewComboBoxCell();
                    CellSample.DataSource = StingList;
                    oRow.Cells[11] = CellSample;
                }
                else
                {
                    ArrayList StingList = new ArrayList();
                    StingList.Add("N/A");
                    var CellSample = new DataGridViewComboBoxCell();
                    CellSample.DataSource = StingList;
                    oRow.Cells[11] = CellSample;

                }


                oRow.Cells[12].Value = _oTELLib.TakaFormat(oItem.LocalDeliveryCost).ToString();

                if (oItem.ReceiveDate != null)
                {

                    oRow.Cells[13].Value = true;
                    oRow.Cells[14].Style.BackColor = Color.White;
                    oRow.Cells[15].Style.BackColor = Color.White;
                    oRow.Cells[14].Value = Convert.ToDateTime(oItem.ReceiveDate).ToString("dd-MMM-yyyy");
                    oRow.Cells[15].Value = Convert.ToDateTime(oItem.ReceiveTime).ToString("hh:mm tt");
                }
                else
                {
                    oRow.Cells[13].Value = false;
                    oRow.Cells[14].Style.BackColor = Color.LightGray;
                    oRow.Cells[15].Style.BackColor = Color.LightGray;
                    oRow.Cells[14].Value = Convert.ToDateTime(oItem.TranDate).ToString("dd-MMM-yyyy");
                    oRow.Cells[15].Value = DateTime.Now.ToString("hh:mm tt");
                }

                oRow.Cells[16].Value = oItem.Remarks;
                oRow.Cells[17].Value = oItem.TranID.ToString();
                oRow.Cells[18].Value = oItem.VendorID.ToString();
                oRow.Cells[19].Value = oItem.VehicleID.ToString();
                oRow.Cells[20].Value = oItem.DeliveryMode.ToString();
                oRow.Cells[21].Value = oItem.ParcelType.ToString();
                oRow.Cells[22].Value = oItem.ParcelVendorID;
                oRow.Cells[23].Value = oItem.VehicleCapacity;


                //oRow.Cells[0].Value = oItem.Company.ToString();
                //oRow.Cells[1].Value = Enum.GetName(typeof(Dictionary.DeliveryShipmentVendor), oItem.VendorID);
                //oRow.Cells[2].Value = oItem.VehicleNo.ToString();
                //oRow.Cells[3].Value = oItem.TranType.ToString();
                //oRow.Cells[4].Value = oItem.TranNo.ToString();
                //oRow.Cells[5].Value = Convert.ToDateTime(oItem.TranDate).ToString("dd-MMM-yyyy");
                //TELLib _oTELLib = new TELLib();
                //oRow.Cells[6].Value = _oTELLib.TakaFormat(oItem.StockPrice).ToString();
                //oRow.Cells[7].Value = _oTELLib.TakaFormat(oItem.FreightCost).ToString();
                //oRow.Cells[8].Value = _oTELLib.TakaFormat(oItem.LocalDeliveryCost).ToString();
                //oRow.Cells[9].Value = oItem.TranID.ToString();
                //oRow.Cells[10].Value = oItem.VendorID.ToString();
                //oRow.Cells[11].Value = oItem.VehicleID.ToString();
                //oRow.Cells[12].Value = _oTELLib.TakaFormat(oItem.ParcelCost);
                //oRow.Cells[13].Value = oItem.ReceiveDate.ToString("dd-MMM-yyyy");
                //oRow.Cells[14].Value = oItem.ReceiveTime.ToString("hh:mm tt");
                //oRow.Cells[15].Value = oItem.Remarks.ToString();


                dgvDeliveryShipment.Rows.Add(oRow);
            }

            GetTotal();
            this.ShowDialog();
        }

        private bool validateUIInput()
        {
            if (txtGatePassNo.Text == "")
            {
                MessageBox.Show("Please enter Gate Pass No.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGatePassNo.Focus();
                return false;
            }
            double _FreightAmount = 0;
            try
            {
                _FreightAmount = Convert.ToDouble(txtFreghtAmount.Text.Trim().ToString());
            }
            catch
            {
                _FreightAmount = 0;
            }
            if (txtFreghtAmount.Text == "")
            {
                MessageBox.Show("Please enter freight cost.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFreghtAmount.Focus();
                return false;
            }
            if (_FreightAmount <= 0)
            {
                MessageBox.Show("Freight cost must be >0.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFreghtAmount.Focus();
                return false;
            }

            if (dgvDeliveryShipment.Rows.Count == 0)
            {
                MessageBox.Show("Please select valid delivery shipment data.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dgvDeliveryShipment.Focus();
                return false;
            }

            foreach (DataGridViewRow oItemRow in dgvDeliveryShipment.Rows)
            {
                if (oItemRow.Index < dgvDeliveryShipment.Rows.Count)
                {
                    if (_nType == 1)
                    {
                        if (Convert.ToInt32(oItemRow.Cells[20].Value) == (int)Dictionary.LogDeliveryShipmentDeliveryMode.Parcel_Delivery)
                        {
                            string sVendorP = "";
                            try
                            {
                                sVendorP = oItemRow.Cells[11].Value.ToString();
                            }
                            catch
                            {
                                sVendorP = "";
                            }
                            if (sVendorP == "")
                            {
                                MessageBox.Show("Please select parcel vendor.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                dgvDeliveryShipment.Focus();
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
            if (_nType == 2)
            {
                if (validateUIInput())
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();

                        _oShipmentVehicle = new ShipmentVehicle();
                        _oShipmentVehicle = GetUIData(_oShipmentVehicle);
                        _oShipmentVehicle.EditLogShipment(nShipmentID);

                        DBController.Instance.CommitTran();
                        MessageBox.Show("Successfully Update Log Shipment Data. Shipment # " + _sShipmentNo.ToString(), "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        _IsTrue = true;
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show("Error... " + ex, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
            else
            {


                if (validateUIInput())
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        _oShipmentVehicle = new ShipmentVehicle();
                        _oShipmentVehicle = GetUIData(_oShipmentVehicle);
                        _oShipmentVehicle.AddLogShipment();
                        DBController.Instance.CommitTran();
                        MessageBox.Show("Successfully Add Log Shipment Data. Shipment # " + _oShipmentVehicle.ShipmentNo.ToString(), "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                        _IsTrue = true;


                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
        }

        public ShipmentVehicle GetUIData(ShipmentVehicle _oShipmentVehicle)
        {
            _oShipmentVehicle.ShipmentDate = dtShipmentDate.Value.Date;
            _oShipmentVehicle.GatePassNo = txtGatePassNo.Text;
            _oShipmentVehicle.FreightCost = Convert.ToDouble(txtFreightAmount.Text);
            _oShipmentVehicle.LocalDeliveryCost = Convert.ToDouble(txtLocalDeliveryAmount.Text);
            _oShipmentVehicle.ParcelCost = Convert.ToDouble(txtPaecelAmount.Text);


            DSDeliveryShipment oDSDeliveryVendore = new DSDeliveryShipment();
            Vehicles _oVendores = new Vehicles();
            _oVendores.GetAllVendor();
            foreach (Vehicle oVehicle in _oVendores)
            {
                DSDeliveryShipment.VendorRow oVendorRow = oDSDeliveryVendore.Vendor.NewVendorRow();
                oVendorRow.VendorID = oVehicle.VendorID;
                oVendorRow.VendorName = oVehicle.VendorName;
                oVendorRow.VendorType = oVehicle.VendorType;
                oVendorRow.IsActive = oVehicle.IsActive;
                oVendorRow.DeliveryMode = oVehicle.DeliveryMode;

                oDSDeliveryVendore.Vendor.AddVendorRow(oVendorRow);
                oDSDeliveryVendore.AcceptChanges();
            }

            //Item Details
            foreach (DataGridViewRow oItemRow in dgvDeliveryShipment.Rows)
            {
                if (oItemRow.Index < dgvDeliveryShipment.Rows.Count)
                {
                    LogDeliveryShipmentItem _oLogDeliveryShipmentItem = new LogDeliveryShipmentItem();
                    _oLogDeliveryShipmentItem.Company = oItemRow.Cells[0].Value.ToString();
                    _oLogDeliveryShipmentItem.TranType = oItemRow.Cells[5].Value.ToString();
                    _oLogDeliveryShipmentItem.TranID = int.Parse(oItemRow.Cells[17].Value.ToString());
                    _oLogDeliveryShipmentItem.TranNo = oItemRow.Cells[6].Value.ToString();
                    _oLogDeliveryShipmentItem.TranDate = Convert.ToDateTime(oItemRow.Cells[7].Value.ToString()).Date;
                    _oLogDeliveryShipmentItem.StockPrice = Convert.ToDouble(oItemRow.Cells[8].Value.ToString());
                    _oLogDeliveryShipmentItem.VendorID = int.Parse(oItemRow.Cells[18].Value.ToString());
                    _oLogDeliveryShipmentItem.VehicleNo = oItemRow.Cells[4].Value.ToString();
                    _oLogDeliveryShipmentItem.VehicleID = int.Parse(oItemRow.Cells[19].Value.ToString());
                    try
                    {
                        _oLogDeliveryShipmentItem.FreightCost = Convert.ToDouble(oItemRow.Cells[9].Value.ToString());
                    }
                    catch
                    {
                        _oLogDeliveryShipmentItem.FreightCost = 0;
                    }

                    try
                    {
                        _oLogDeliveryShipmentItem.LocalDeliveryCost = Convert.ToDouble(oItemRow.Cells[12].Value.ToString());
                    }
                    catch
                    {
                        _oLogDeliveryShipmentItem.LocalDeliveryCost = 0;
                    }


                    try
                    {
                        _oLogDeliveryShipmentItem.ParcelCost = Convert.ToDouble(oItemRow.Cells[10].Value.ToString());
                    }
                    catch
                    {
                        _oLogDeliveryShipmentItem.ParcelCost = 0;
                    }
                    if ((bool)oItemRow.Cells[13].Value == true)
                    {
                        _oLogDeliveryShipmentItem.ReceiveDate = Convert.ToDateTime(oItemRow.Cells[14].Value.ToString());
                        _oLogDeliveryShipmentItem.ReceiveTime = Convert.ToDateTime(oItemRow.Cells[15].Value.ToString());

                    }
                    try
                    {
                        _oLogDeliveryShipmentItem.Remarks = oItemRow.Cells[16].Value.ToString();
                    }
                    catch
                    {
                        _oLogDeliveryShipmentItem.Remarks = "";
                    }
                    _oLogDeliveryShipmentItem.DeliveryMode = int.Parse(oItemRow.Cells[20].Value.ToString());
                    _oLogDeliveryShipmentItem.ParcelType = int.Parse(oItemRow.Cells[21].Value.ToString());

                    if (_nType == 1)
                    {
                        if (_oLogDeliveryShipmentItem.DeliveryMode == (int)Dictionary.LogDeliveryShipmentDeliveryMode.Parcel_Delivery)
                        {
                            DSDeliveryShipment oDSDeliveryVendoreList = new DSDeliveryShipment();
                            DataRow[] oDRVendorlist = oDSDeliveryVendore.Vendor.Select(" DeliveryMode= '" + _oLogDeliveryShipmentItem.DeliveryMode + "' and VendorName= '" + oItemRow.Cells[11].Value.ToString() + "'");
                            oDSDeliveryVendoreList.Merge(oDRVendorlist);
                            oDSDeliveryVendoreList.AcceptChanges();
                            foreach (DSDeliveryShipment.VendorRow _oVendorRow in oDSDeliveryVendoreList.Vendor)
                            {
                                _oLogDeliveryShipmentItem.ParcelVendorID = _oVendorRow.VendorID;

                            }
                        }
                        else
                        {
                            _oLogDeliveryShipmentItem.ParcelVendorID = -1;
                        }

                    }
                    else
                    {
                        string sVendorP = "";
                        try
                        {
                            sVendorP = oItemRow.Cells[11].Value.ToString();
                        }
                        catch
                        {
                            sVendorP = "";
                        }
                        if (sVendorP != "")
                        {
                            DSDeliveryShipment oDSDeliveryVendoreList = new DSDeliveryShipment();
                            DataRow[] oDRVendorlist = oDSDeliveryVendore.Vendor.Select(" DeliveryMode= '" + _oLogDeliveryShipmentItem.DeliveryMode + "' and VendorName= '" + oItemRow.Cells[11].Value.ToString() + "'");
                            oDSDeliveryVendoreList.Merge(oDRVendorlist);
                            oDSDeliveryVendoreList.AcceptChanges();
                            foreach (DSDeliveryShipment.VendorRow _oVendorRow in oDSDeliveryVendoreList.Vendor)
                            {
                                _oLogDeliveryShipmentItem.ParcelVendorID = _oVendorRow.VendorID;

                            }
                        }
                        else
                        {
                            _oLogDeliveryShipmentItem.ParcelVendorID = int.Parse(oItemRow.Cells[22].Value.ToString());
                        }
                    }

                    try
                    {
                        _oLogDeliveryShipmentItem.VehicleCapacity = oItemRow.Cells[23].Value.ToString();
                    }
                    catch
                    {
                        _oLogDeliveryShipmentItem.VehicleCapacity = "";
                    }
                    _oShipmentVehicle.Add(_oLogDeliveryShipmentItem);

                }
            }

            return _oShipmentVehicle;
        }

        private void txtFreghtAmount_Leave(object sender, EventArgs e)
        {
            dgvDeliveryShipment.Rows.Clear();
            if (_nType == 1)
            {
                foreach (ShipmentVehicle oShipmentVehicle in _oShipmentVehicles)
                {

                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvDeliveryShipment);
                    oRow.Cells[0].Value = oShipmentVehicle.Company.ToString();
                    oRow.Cells[1].Value = Enum.GetName(typeof(Dictionary.LogDeliveryShipmentDeliveryMode), oShipmentVehicle.DeliveryMode);
                    if (oShipmentVehicle.ParcelType == 0)
                    {
                        oRow.Cells[2].Value = "N/A";
                    }
                    else
                    {
                        oRow.Cells[2].Value = Enum.GetName(typeof(Dictionary.LogDeliveryShipmentParcelType), oShipmentVehicle.ParcelType);
                    }
                    oRow.Cells[3].Value = oShipmentVehicle.VendorName.ToString();
                    oRow.Cells[4].Value = oShipmentVehicle.VehicleNo.ToString();
                    oRow.Cells[5].Value = oShipmentVehicle.TType.ToString();
                    oRow.Cells[6].Value = oShipmentVehicle.TranNo;
                    oRow.Cells[7].Value = Convert.ToDateTime(oShipmentVehicle.TranDate).ToString("dd-MMM-yyyy");
                    TELLib _oTELLib = new TELLib();
                    oRow.Cells[8].Value = _oTELLib.TakaFormat(oShipmentVehicle.TranAmount).ToString();

                    double _FreightAmt = 0;
                    try
                    {
                        _FreightAmt = Convert.ToDouble(txtFreghtAmount.Text);
                    }
                    catch
                    {
                        _FreightAmt = 0;
                    }
                    double _RawFreightAmt = 0;

                    if (oShipmentVehicle.TranAmount > 1)
                    {
                        try
                        {
                            _RawFreightAmt = Convert.ToDouble(_FreightAmt / Convert.ToDouble(txtStockAmount.Text) * oShipmentVehicle.TranAmount);
                        }
                        catch
                        {
                            _RawFreightAmt = 0;
                        }
                    }
                    else
                    {
                        _RawFreightAmt = 0;
                    }

                    try
                    {
                        oRow.Cells[9].Value = _oTELLib.TakaFormat(_RawFreightAmt).ToString();
                    }
                    catch
                    {
                        oRow.Cells[9].Value = 0;
                    }


                    oRow.Cells[10].Value = "0.00";
                    if (oShipmentVehicle.DeliveryMode == (int)Dictionary.LogDeliveryShipmentDeliveryMode.Parcel_Delivery)
                    {
                        ArrayList StingList = new ArrayList();
                        Vehicles _oVendors = new Vehicles();
                        _oVendors.GetVendorByDeliveryMode((int)Dictionary.LogDeliveryShipmentVendorType.Parcel_Vendor, 2);
                        foreach (Vehicle oItem in _oVendors)
                        {
                            StingList.Add(oItem.VendorName);
                        }
                        var CellSample = new DataGridViewComboBoxCell();
                        CellSample.DataSource = StingList;
                        oRow.Cells[11] = CellSample;
                    }
                    else
                    {
                        ArrayList StingList = new ArrayList();
                        StingList.Add("N/A");
                        var CellSample = new DataGridViewComboBoxCell();
                        CellSample.DataSource = StingList;
                        oRow.Cells[11] = CellSample;

                    }

                    oRow.Cells[12].Value = "0.00";
                    oRow.Cells[13].Value = false;

                    oRow.Cells[14].Value = Convert.ToDateTime(oShipmentVehicle.TranDate).ToString("dd-MMM-yyyy");
                    oRow.Cells[15].Value = DateTime.Now.ToString("hh:mm tt");
                    oRow.Cells[16].Value = "";
                    oRow.Cells[17].Value = oShipmentVehicle.TranID.ToString();
                    oRow.Cells[18].Value = oShipmentVehicle.VendorID.ToString();
                    oRow.Cells[19].Value = oShipmentVehicle.VehicleID.ToString();
                    oRow.Cells[20].Value = oShipmentVehicle.DeliveryMode.ToString();
                    oRow.Cells[21].Value = oShipmentVehicle.ParcelType.ToString();
                    oRow.Cells[22].Value = -1;
                    oRow.Cells[23].Value = oShipmentVehicle.VehicleCapacity.ToString();
                    dgvDeliveryShipment.Rows.Add(oRow);
                }
            }
            else
            {
                txtStockAmount.Text = "0.00";
                TELLib oTELLib = new TELLib();
                foreach (LogDeliveryShipmentItem oItems in _oEditShipmentVehicle)
                {
                    txtStockAmount.Text = oTELLib.TakaFormat(Convert.ToDouble(Convert.ToDouble(txtStockAmount.Text) + Convert.ToDouble(oItems.StockPrice))).ToString();
                }
                foreach (LogDeliveryShipmentItem oItem in _oEditShipmentVehicle)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvDeliveryShipment);


                    oRow.Cells[0].Value = oItem.Company.ToString();
                    oRow.Cells[1].Value = Enum.GetName(typeof(Dictionary.LogDeliveryShipmentDeliveryMode), oItem.DeliveryMode);

                    if (oItem.ParcelType == 0)
                    {
                        oRow.Cells[2].Value = "N/A";
                    }
                    else
                    {
                        oRow.Cells[2].Value = Enum.GetName(typeof(Dictionary.LogDeliveryShipmentParcelType), oItem.ParcelType);
                    }
                    oRow.Cells[3].Value = oItem.VendorName.ToString();
                    oRow.Cells[4].Value = oItem.VehicleNo.ToString();
                    oRow.Cells[5].Value = oItem.TranType.ToString();
                    oRow.Cells[6].Value = oItem.TranNo;
                    oRow.Cells[7].Value = Convert.ToDateTime(oItem.TranDate).ToString("dd-MMM-yyyy");
                    TELLib _oTELLib = new TELLib();
                    oRow.Cells[8].Value = _oTELLib.TakaFormat(oItem.StockPrice).ToString();
                    //oRow.Cells[9].Value = _oTELLib.TakaFormat(oItem.FreightCost).ToString();

                    double _FreightAmt = 0;
                    try
                    {
                        _FreightAmt = Convert.ToDouble(txtFreghtAmount.Text);
                    }
                    catch
                    {
                        _FreightAmt = 0;
                    }
                    double _RawFreightAmt = 0;

                    if (oItem.StockPrice > 1)
                    {
                        try
                        {
                            _RawFreightAmt = Convert.ToDouble(_FreightAmt / Convert.ToDouble(txtStockAmount.Text) * oItem.StockPrice);
                        }
                        catch
                        {
                            _RawFreightAmt = 0;
                        }
                    }
                    else
                    {
                        _RawFreightAmt = 0;
                    }

                    try
                    {
                        oRow.Cells[9].Value = _oTELLib.TakaFormat(_RawFreightAmt).ToString();
                    }
                    catch
                    {
                        oRow.Cells[9].Value = 0;
                    }
                    oRow.Cells[10].Value = _oTELLib.TakaFormat(oItem.ParcelCost).ToString();

                    if (oItem.DeliveryMode == (int)Dictionary.LogDeliveryShipmentDeliveryMode.Parcel_Delivery)
                    {
                        ArrayList StingList = new ArrayList();
                        Vehicles _oVendors = new Vehicles();
                        _oVendors.GetVendorByDeliveryMode((int)Dictionary.LogDeliveryShipmentVendorType.Parcel_Vendor, 2);
                        foreach (Vehicle oItems in _oVendors)
                        {
                            StingList.Add(oItems.VendorName);
                        }
                        var CellSample = new DataGridViewComboBoxCell();
                        CellSample.DataSource = StingList;
                        oRow.Cells[11] = CellSample;
                    }
                    else
                    {
                        ArrayList StingList = new ArrayList();
                        StingList.Add("N/A");
                        var CellSample = new DataGridViewComboBoxCell();
                        CellSample.DataSource = StingList;
                        oRow.Cells[11] = CellSample;

                    }
                    oRow.Cells[12].Value = _oTELLib.TakaFormat(oItem.LocalDeliveryCost).ToString();
                    if (oItem.ReceiveDate != null)
                    {

                        oRow.Cells[13].Value = true;
                        oRow.Cells[14].Style.BackColor = Color.White;
                        oRow.Cells[15].Style.BackColor = Color.White;
                        oRow.Cells[14].Value = Convert.ToDateTime(oItem.ReceiveDate).ToString("dd-MMM-yyyy");
                        oRow.Cells[15].Value = Convert.ToDateTime(oItem.ReceiveTime).ToString("hh:mm tt");
                    }
                    else
                    {
                        oRow.Cells[13].Value = false;
                        oRow.Cells[14].Style.BackColor = Color.LightGray;
                        oRow.Cells[15].Style.BackColor = Color.LightGray;
                        oRow.Cells[14].Value = Convert.ToDateTime(oItem.TranDate).ToString("dd-MMM-yyyy");
                        oRow.Cells[15].Value = DateTime.Now.ToString("hh:mm tt");
                    }
                    oRow.Cells[16].Value = oItem.Remarks;
                    oRow.Cells[17].Value = oItem.TranID.ToString();
                    oRow.Cells[18].Value = oItem.VendorID.ToString();
                    oRow.Cells[19].Value = oItem.VehicleID.ToString();
                    oRow.Cells[20].Value = oItem.DeliveryMode.ToString();
                    oRow.Cells[21].Value = oItem.ParcelType.ToString();
                    oRow.Cells[22].Value = oItem.ParcelVendorID;
                    oRow.Cells[23].Value = oItem.VehicleCapacity.ToString();


                    //oRow.Cells[0].Value = oItem.Company.ToString();
                    //oRow.Cells[1].Value = Enum.GetName(typeof(Dictionary.DeliveryShipmentVendor), oItem.VendorID);
                    //oRow.Cells[2].Value = oItem.VehicleNo.ToString();
                    //oRow.Cells[3].Value = oItem.TranType.ToString();
                    //oRow.Cells[4].Value = oItem.TranNo.ToString();
                    //oRow.Cells[5].Value = Convert.ToDateTime(oItem.TranDate).ToString("dd-MMM-yyyy");
                    //TELLib _oTELLib = new TELLib();
                    //oRow.Cells[6].Value = _oTELLib.TakaFormat(oItem.StockPrice).ToString();

                    //double _FreightAmt = 0;
                    //try
                    //{
                    //    _FreightAmt = Convert.ToDouble(txtFreghtAmount.Text);
                    //}
                    //catch
                    //{
                    //    _FreightAmt = 0;
                    //}
                    //double _RawFreightAmt = 0;

                    //_RawFreightAmt = _FreightAmt / Convert.ToDouble(txtStockAmount.Text) * oItem.StockPrice;
                    //oRow.Cells[7].Value = _oTELLib.TakaFormat(_RawFreightAmt).ToString();
                    //oRow.Cells[8].Value = _oTELLib.TakaFormat(oItem.LocalDeliveryCost).ToString();
                    //oRow.Cells[9].Value = oItem.TranID.ToString();
                    //oRow.Cells[10].Value = oItem.VendorID.ToString();
                    //oRow.Cells[11].Value = oItem.VehicleID.ToString();

                    //oRow.Cells[12].Value = _oTELLib.TakaFormat(oItem.ParcelCost);
                    //oRow.Cells[13].Value = oItem.ReceiveDate.ToString("dd-MMM-yyyy");
                    //oRow.Cells[14].Value = oItem.ReceiveTime.ToString("hh:mm tt");
                    //oRow.Cells[15].Value = oItem.Remarks.ToString();

                    dgvDeliveryShipment.Rows.Add(oRow);
                }

            }
            GetTotal();
        }

        private void refreshRow(int nRowIndex, int nColumnIndex)
        {
            GetTotal();

        }

        public void GetTotal()
        {
            txtStockAmount.Text = "0.00";
            txtFreightAmount.Text = "0.00";
            txtLocalDeliveryAmount.Text = "0.00";
            txtPaecelAmount.Text = "0.00";

            TELLib _oTELLib = new TELLib();
            foreach (DataGridViewRow oRow in dgvDeliveryShipment.Rows)
            {
                if (oRow.Cells[8].Value != null)
                {
                    txtStockAmount.Text = Convert.ToDouble(Convert.ToDouble(txtStockAmount.Text) + Convert.ToDouble(oRow.Cells[8].Value.ToString())).ToString();

                }
                if (oRow.Cells[9].Value != null)
                {
                    txtFreightAmount.Text = Convert.ToDouble(Convert.ToDouble(txtFreightAmount.Text) + Convert.ToDouble(oRow.Cells[9].Value.ToString())).ToString();

                }
                if (oRow.Cells[12].Value != null)
                {
                    txtLocalDeliveryAmount.Text = Convert.ToDouble(Convert.ToDouble(txtLocalDeliveryAmount.Text) + Convert.ToDouble(oRow.Cells[12].Value.ToString())).ToString();

                }
                if (oRow.Cells[10].Value != null)
                {
                    txtPaecelAmount.Text = Convert.ToDouble(Convert.ToDouble(txtPaecelAmount.Text) + Convert.ToDouble(oRow.Cells[10].Value.ToString())).ToString();

                }
            }
            txtStockAmount.Text = _oTELLib.TakaFormat(Convert.ToDouble(txtStockAmount.Text));
            txtFreightAmount.Text = _oTELLib.TakaFormat(Convert.ToDouble(txtFreightAmount.Text));
            txtLocalDeliveryAmount.Text = _oTELLib.TakaFormat(Convert.ToDouble(txtLocalDeliveryAmount.Text));
            txtPaecelAmount.Text = _oTELLib.TakaFormat(Convert.ToDouble(txtPaecelAmount.Text));
        }

        private void dgvDeliveryShipment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            GetTotal();
            if (e.ColumnIndex == 13 && e.RowIndex >= 0)
            {
                this.dgvDeliveryShipment.CommitEdit(DataGridViewDataErrorContexts.Commit);

                //Check the value of cell
                if ((bool)this.dgvDeliveryShipment.CurrentCell.Value == true)
                {
                    this.dgvDeliveryShipment.Rows[e.RowIndex].Cells[14].ReadOnly = false;
                    this.dgvDeliveryShipment.Rows[e.RowIndex].Cells[15].ReadOnly = false;
                    this.dgvDeliveryShipment.Rows[e.RowIndex].Cells[14].Style.BackColor = Color.White;
                    this.dgvDeliveryShipment.Rows[e.RowIndex].Cells[15].Style.BackColor = Color.White;

                }
                else
                {
                    this.dgvDeliveryShipment.Rows[e.RowIndex].Cells[14].ReadOnly = true;
                    this.dgvDeliveryShipment.Rows[e.RowIndex].Cells[15].ReadOnly = true;
                    this.dgvDeliveryShipment.Rows[e.RowIndex].Cells[14].Style.BackColor = Color.LightGray;
                    this.dgvDeliveryShipment.Rows[e.RowIndex].Cells[15].Style.BackColor = Color.LightGray;

                }
            }

        }

        private void dgvDeliveryShipment_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            refreshRow(e.RowIndex, e.ColumnIndex);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;

namespace CJ.Win.Distribution
{
    public partial class frmTDDeliveryShipmentHO : Form
    {
        int _nType = 0;
        public bool _ISLoad = false;

        TDDeliveryShipment oTDDeliveryShipment;
        int nShipmentID = 0;
        int nWHID = 0;

        public frmTDDeliveryShipmentHO(int nType)
        {
            InitializeComponent();
            _nType = nType;
        }

        public void ShowDialog(TDDeliveryShipment oTDDeliveryShipment)
        {
            this.Tag = oTDDeliveryShipment;
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            nShipmentID = oTDDeliveryShipment.ShipmentID;
            nWHID = oTDDeliveryShipment.WHID;
            lblInvoiceNo.Text = oTDDeliveryShipment.InvoiceNo;
            lblInvoiceDate.Text = oTDDeliveryShipment.InvoiceDate.ToString("dd-MMM-yyyy");
            lblCustomer.Text = oTDDeliveryShipment.ConsumerName;
            lblAddress.Text = oTDDeliveryShipment.Address;
            lblMobileNo.Text = oTDDeliveryShipment.CellNo;
            lblThanaName.Text = oTDDeliveryShipment.ThanaName;
            lblDistrictName.Text = oTDDeliveryShipment.DistrictName;
            lblTerritoryName.Text = oTDDeliveryShipment.TerritoryName;
            lblAreaName.Text = oTDDeliveryShipment.AreaName;
            lblShowroom.Text = oTDDeliveryShipment.ShowroomCode;
            lblSalesType.Text = Enum.GetName(typeof(Dictionary.SalesType), oTDDeliveryShipment.SalesType);
            txtRemarksAll.Text = oTDDeliveryShipment.Remarks;

            TDDeliveryShipments oTDDeliveryShipments = new TDDeliveryShipments();
            oTDDeliveryShipments.RefreshForHo(oTDDeliveryShipment.ShipmentID, oTDDeliveryShipment.WHID);
            foreach (TDDeliveryShipmentItem oTDDeliveryShipmentItem in oTDDeliveryShipments)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvTDDeliveryShipment);
                oRow.Cells[0].Value = "[" + oTDDeliveryShipmentItem.ProductCode.ToString() + "] " + oTDDeliveryShipmentItem.ProductName.ToString();
                oRow.Cells[1].Value = oTDDeliveryShipmentItem.Qty.ToString();
                oRow.Cells[2].Value = Convert.ToDouble(oTDDeliveryShipmentItem.Qty * oTDDeliveryShipmentItem.UnitPrice).ToString();
                oRow.Cells[3].Value = oTDDeliveryShipmentItem.ShipmentDate.ToString("dd-MMM-yyyy");
                oRow.Cells[4].Value = Convert.ToDateTime(oTDDeliveryShipmentItem.ShipmentTime).ToString("hh:mm tt");

                if (oTDDeliveryShipmentItem.ShipingAddress != "")
                    oRow.Cells[5].Value = oTDDeliveryShipmentItem.ShipingAddress;
                else oRow.Cells[5].Value = lblAddress.Text;

                oRow.Cells[6].Value = oTDDeliveryShipmentItem.DistanceKM;
                oRow.Cells[7].Value = oTDDeliveryShipmentItem.FloorNo;

                if (oTDDeliveryShipmentItem.ContactNo != "")
                    oRow.Cells[8].Value = oTDDeliveryShipmentItem.ContactNo;
                else oRow.Cells[8].Value = lblMobileNo.Text;


                oRow.Cells[9].Value = oTDDeliveryShipmentItem.InstallationRequired;
                oRow.Cells[10].Value = Convert.ToDateTime(oTDDeliveryShipmentItem.ExpInstallationDate).ToString("dd-MMM-yyyy");
                oRow.Cells[11].Value = Convert.ToDateTime(oTDDeliveryShipmentItem.ExpInstallationTime).ToString("hh:mm tt");
                oRow.Cells[12].Value = oTDDeliveryShipmentItem.DeliveryMode;
                oRow.Cells[13].Value = oTDDeliveryShipmentItem.VehicleNo;
                oRow.Cells[14].Value = oTDDeliveryShipmentItem.FreightCost.ToString();
                oRow.Cells[15].Value = oTDDeliveryShipmentItem.LiftingCost.ToString();
                oRow.Cells[16].Value = Convert.ToDateTime(oTDDeliveryShipmentItem.HDCompletionDate).ToString("dd-MMM-yyyy");
                oRow.Cells[17].Value = Convert.ToDateTime(oTDDeliveryShipmentItem.HDCompletionTime).ToString("hh:mm tt");
                oRow.Cells[18].Value = oTDDeliveryShipmentItem.IsSafelyDelivered;
                oRow.Cells[19].Value = oTDDeliveryShipmentItem.Reason;
                oRow.Cells[20].Value = oTDDeliveryShipmentItem.ActionTaken;
                oRow.Cells[21].Value = oTDDeliveryShipmentItem.Remarks;
                oRow.Cells[22].Value = oTDDeliveryShipmentItem.ProductID.ToString();
                oRow.Cells[23].Value = oTDDeliveryShipmentItem.UnitPrice.ToString();
                oRow.Cells[24].Value = oTDDeliveryShipmentItem.LiftingCost.ToString();
                oRow.Cells[25].Value = oTDDeliveryShipmentItem.FreightCost.ToString();

                /////---------------------------------------
                //oRow.Cells[6].Value = oTDDeliveryShipmentItem.ContactNo;
                //oRow.Cells[7].Value = oTDDeliveryShipmentItem.InstallationRequired;
                //oRow.Cells[8].Value = Convert.ToDateTime(oTDDeliveryShipmentItem.ExpInstallationDate).ToString("dd-MMM-yyyy");
                //oRow.Cells[9].Value = Convert.ToDateTime(oTDDeliveryShipmentItem.ExpInstallationTime).ToString("hh:mm tt");
                //oRow.Cells[10].Value = oTDDeliveryShipmentItem.DeliveryMode;
                //oRow.Cells[11].Value = oTDDeliveryShipmentItem.VehicleNo;
                //oRow.Cells[12].Value = oTDDeliveryShipmentItem.FreightCost.ToString();
                //oRow.Cells[13].Value = oTDDeliveryShipmentItem.LiftingCost.ToString();
                //oRow.Cells[14].Value = Convert.ToDateTime(oTDDeliveryShipmentItem.HDCompletionDate).ToString("dd-MMM-yyyy");
                //oRow.Cells[15].Value = Convert.ToDateTime(oTDDeliveryShipmentItem.HDCompletionTime).ToString("hh:mm tt");
                //oRow.Cells[16].Value = oTDDeliveryShipmentItem.IsSafelyDelivered;
                //oRow.Cells[17].Value = oTDDeliveryShipmentItem.Reason;
                //oRow.Cells[18].Value = oTDDeliveryShipmentItem.ActionTaken;
                //oRow.Cells[19].Value = oTDDeliveryShipmentItem.Remarks;
                //oRow.Cells[20].Value = oTDDeliveryShipmentItem.ProductID.ToString();
                //oRow.Cells[21].Value = oTDDeliveryShipmentItem.UnitPrice.ToString();
                //oRow.Cells[22].Value = oTDDeliveryShipmentItem.LiftingCost.ToString();
                //oRow.Cells[23].Value = oTDDeliveryShipmentItem.FreightCost.ToString();
                

                dgvTDDeliveryShipment.Rows.Add(oRow);
            }

            if (_nType == (int)Dictionary.TDDeliveryShipmentStatus.Processing_Delivery)
            {
                this.Text = "Processing Delivery";

                //dgvTDDeliveryShipment.Columns[14].Visible = false;
                //dgvTDDeliveryShipment.Columns[15].Visible = false;
                //dgvTDDeliveryShipment.Columns[16].Visible = false;
                //dgvTDDeliveryShipment.Columns[17].Visible = false;
                //dgvTDDeliveryShipment.Columns[18].Visible = false;
                //dgvTDDeliveryShipment.Columns[19].Visible = false;


                dgvTDDeliveryShipment.Columns[16].Visible = false;
                dgvTDDeliveryShipment.Columns[17].Visible = false;
                dgvTDDeliveryShipment.Columns[18].Visible = false;
                dgvTDDeliveryShipment.Columns[19].Visible = false;
                dgvTDDeliveryShipment.Columns[20].Visible = false;
                dgvTDDeliveryShipment.Columns[21].Visible = false;
                dgvTDDeliveryShipment.Columns[24].Visible = false;
                dgvTDDeliveryShipment.Columns[25].Visible = false;
            }
            else if (_nType == (int)Dictionary.TDDeliveryShipmentStatus.Delivered)
            {
                this.Text = "Delivery Invoice";

                //dgvTDDeliveryShipment.Columns[14].Visible = true;
                //dgvTDDeliveryShipment.Columns[15].Visible = true;
                //dgvTDDeliveryShipment.Columns[16].Visible = true;
                //dgvTDDeliveryShipment.Columns[17].Visible = true;
                //dgvTDDeliveryShipment.Columns[18].Visible = true;
                //dgvTDDeliveryShipment.Columns[19].Visible = true;

                dgvTDDeliveryShipment.Columns[16].Visible = true;
                dgvTDDeliveryShipment.Columns[17].Visible = true;
                dgvTDDeliveryShipment.Columns[18].Visible = true;
                dgvTDDeliveryShipment.Columns[19].Visible = true;
                dgvTDDeliveryShipment.Columns[20].Visible = true;
                dgvTDDeliveryShipment.Columns[21].Visible = true;
                dgvTDDeliveryShipment.Columns[24].Visible = false;
                dgvTDDeliveryShipment.Columns[25].Visible = false;
            }
            else if (_nType == (int)Dictionary.TDDeliveryShipmentStatus.Bill_Approved)
            {
                this.Text = "Bill Approval";
                //dgvTDDeliveryShipment.Columns[7].Visible = false;
                //dgvTDDeliveryShipment.Columns[8].Visible = false;
                //dgvTDDeliveryShipment.Columns[9].Visible = false;
                //dgvTDDeliveryShipment.Columns[11].Visible = false;
                //dgvTDDeliveryShipment.Columns[12].Visible = false;
                //dgvTDDeliveryShipment.Columns[13].Visible = false;
                //dgvTDDeliveryShipment.Columns[14].Visible = false;
                //dgvTDDeliveryShipment.Columns[15].Visible = false;
                //dgvTDDeliveryShipment.Columns[16].Visible = false;
                //dgvTDDeliveryShipment.Columns[17].Visible = false;
                //dgvTDDeliveryShipment.Columns[18].Visible = false;
                //dgvTDDeliveryShipment.Columns[19].Visible = false;
                //dgvTDDeliveryShipment.Columns[22].Visible = true;
                //dgvTDDeliveryShipment.Columns[23].Visible = true;
                //dgvTDDeliveryShipment.Columns[0].ReadOnly = true;
                //dgvTDDeliveryShipment.Columns[1].ReadOnly = true;
                //dgvTDDeliveryShipment.Columns[2].ReadOnly = true;
                //dgvTDDeliveryShipment.Columns[3].ReadOnly = true;
                //dgvTDDeliveryShipment.Columns[4].ReadOnly = true;
                //dgvTDDeliveryShipment.Columns[5].ReadOnly = true;
                //dgvTDDeliveryShipment.Columns[6].ReadOnly = true;
                //dgvTDDeliveryShipment.Columns[7].ReadOnly = true;


                dgvTDDeliveryShipment.Columns[9].Visible = false;
                dgvTDDeliveryShipment.Columns[10].Visible = false;
                dgvTDDeliveryShipment.Columns[11].Visible = false;
                dgvTDDeliveryShipment.Columns[13].Visible = false;
                dgvTDDeliveryShipment.Columns[14].Visible = false;
                dgvTDDeliveryShipment.Columns[15].Visible = false;
                dgvTDDeliveryShipment.Columns[16].Visible = false;
                dgvTDDeliveryShipment.Columns[17].Visible = false;
                dgvTDDeliveryShipment.Columns[18].Visible = false;
                dgvTDDeliveryShipment.Columns[19].Visible = false;
                dgvTDDeliveryShipment.Columns[20].Visible = false;
                dgvTDDeliveryShipment.Columns[21].Visible = false;
                dgvTDDeliveryShipment.Columns[24].Visible = true;
                dgvTDDeliveryShipment.Columns[25].Visible = true;
                dgvTDDeliveryShipment.Columns[0].ReadOnly = true;
                dgvTDDeliveryShipment.Columns[1].ReadOnly = true;
                dgvTDDeliveryShipment.Columns[2].ReadOnly = true;
                dgvTDDeliveryShipment.Columns[3].ReadOnly = true;
                dgvTDDeliveryShipment.Columns[4].ReadOnly = true;
                dgvTDDeliveryShipment.Columns[5].ReadOnly = true;
                dgvTDDeliveryShipment.Columns[6].ReadOnly = true;
                dgvTDDeliveryShipment.Columns[7].ReadOnly = true;
            }

            this.ShowDialog();
        }

        private void frmTDDeliveryShipmentHO_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public TDDeliveryShipment GetData(TDDeliveryShipment _oTDDeliveryShipment)
        {
            _oTDDeliveryShipment.WHID = nWHID;
            _oTDDeliveryShipment.InvoiceNo = lblInvoiceNo.Text;
            _oTDDeliveryShipment.Remarks = txtRemarksAll.Text;
            _oTDDeliveryShipment.Status = _nType;
            _oTDDeliveryShipment.CreateDate = DateTime.Now;
            _oTDDeliveryShipment.CreateUserID = Utility.UserId;

            // Item Details
            foreach (DataGridViewRow oItemRow in dgvTDDeliveryShipment.Rows)
            {
                if (oItemRow.Index < dgvTDDeliveryShipment.Rows.Count)
                {
                    //TDDeliveryShipmentItem _oTDDeliveryShipmentItem = new TDDeliveryShipmentItem();
                    //_oTDDeliveryShipmentItem.ProductID = int.Parse(oItemRow.Cells[20].Value.ToString());
                    //_oTDDeliveryShipmentItem.UnitPrice = Convert.ToDouble(oItemRow.Cells[21].Value.ToString());
                    //_oTDDeliveryShipmentItem.Qty = int.Parse(oItemRow.Cells[1].Value.ToString());
                    //_oTDDeliveryShipmentItem.ShipmentDate = Convert.ToDateTime(oItemRow.Cells[3].Value.ToString());
                    //_oTDDeliveryShipmentItem.ShipmentTime = Convert.ToDateTime(oItemRow.Cells[4].Value.ToString());
                    //_oTDDeliveryShipmentItem.ShipingAddress = oItemRow.Cells[5].Value.ToString();
                    //_oTDDeliveryShipmentItem.ContactNo = oItemRow.Cells[6].Value.ToString();
                    //_oTDDeliveryShipmentItem.InstallationRequired = oItemRow.Cells[7].Value.ToString();
                    //_oTDDeliveryShipmentItem.ExpInstallationDate = Convert.ToDateTime(oItemRow.Cells[8].Value.ToString());
                    //_oTDDeliveryShipmentItem.ExpInstallationTime = Convert.ToDateTime(oItemRow.Cells[9].Value.ToString());
                    //_oTDDeliveryShipmentItem.DeliveryMode = oItemRow.Cells[10].Value.ToString();
                    //_oTDDeliveryShipmentItem.VehicleNo = oItemRow.Cells[11].Value.ToString();
                    //try
                    //{
                    //    _oTDDeliveryShipmentItem.FreightCost = Convert.ToDouble(oItemRow.Cells[12].Value.ToString());
                    //}
                    //catch
                    //{
                    //    _oTDDeliveryShipmentItem.FreightCost = 0;
                    //}
                    //try
                    //{
                    //    _oTDDeliveryShipmentItem.LiftingCost = Convert.ToDouble(oItemRow.Cells[13].Value.ToString());
                    //}
                    //catch
                    //{
                    //    _oTDDeliveryShipmentItem.LiftingCost = 0;
                    //}

                    ////if (_nType == (int)Dictionary.TDDeliveryShipmentStatus.Deliverded)

                    //_oTDDeliveryShipmentItem.HDCompletionDate = Convert.ToDateTime(oItemRow.Cells[14].Value.ToString());
                    //_oTDDeliveryShipmentItem.HDCompletionTime = Convert.ToDateTime(oItemRow.Cells[15].Value.ToString());
                    //_oTDDeliveryShipmentItem.IsSafelyDelivered = oItemRow.Cells[16].Value.ToString();
                    //try
                    //{
                    //    _oTDDeliveryShipmentItem.Reason = oItemRow.Cells[17].Value.ToString();
                    //}
                    //catch
                    //{
                    //    _oTDDeliveryShipmentItem.Reason = "";
                    //}
                    //try
                    //{
                    //    _oTDDeliveryShipmentItem.ActionTaken = oItemRow.Cells[18].Value.ToString();
                    //}
                    //catch
                    //{
                    //    _oTDDeliveryShipmentItem.ActionTaken = "";
                    //}
                    //try
                    //{
                    //    _oTDDeliveryShipmentItem.Remarks = oItemRow.Cells[19].Value.ToString();
                    //}
                    //catch
                    //{
                    //    _oTDDeliveryShipmentItem.Remarks = "";
                    //}
                    //try
                    //{
                    //    _oTDDeliveryShipmentItem.ApprovedLiftingCost = Convert.ToDouble(oItemRow.Cells[22].Value.ToString());
                    //}
                    //catch
                    //{
                    //    _oTDDeliveryShipmentItem.ApprovedLiftingCost = 0;
                    //}
                    //try
                    //{
                    //    _oTDDeliveryShipmentItem.ApprovedFreightCost = Convert.ToDouble(oItemRow.Cells[23].Value.ToString());
                    //}
                    //catch
                    //{
                    //    _oTDDeliveryShipmentItem.ApprovedFreightCost = 0;
                    //}

                    TDDeliveryShipmentItem _oTDDeliveryShipmentItem = new TDDeliveryShipmentItem();
                    _oTDDeliveryShipmentItem.ProductID = int.Parse(oItemRow.Cells[22].Value.ToString());
                    _oTDDeliveryShipmentItem.UnitPrice = Convert.ToDouble(oItemRow.Cells[23].Value.ToString());
                    _oTDDeliveryShipmentItem.Qty = int.Parse(oItemRow.Cells[1].Value.ToString());
                    _oTDDeliveryShipmentItem.ShipmentDate = Convert.ToDateTime(oItemRow.Cells[3].Value.ToString());
                    _oTDDeliveryShipmentItem.ShipmentTime = Convert.ToDateTime(oItemRow.Cells[4].Value.ToString());
                    _oTDDeliveryShipmentItem.ShipingAddress = oItemRow.Cells[5].Value.ToString();

                    try
                    {
                        _oTDDeliveryShipmentItem.DistanceKM = Convert.ToDouble(oItemRow.Cells[6].Value.ToString());
                    }
                    catch
                    {
                        _oTDDeliveryShipmentItem.DistanceKM = 0;
                    }
                    try
                    {
                        _oTDDeliveryShipmentItem.FloorNo = Convert.ToInt32(oItemRow.Cells[7].Value.ToString());
                    }
                    catch
                    {
                        _oTDDeliveryShipmentItem.FloorNo = 0;
                    }

                    _oTDDeliveryShipmentItem.ContactNo = oItemRow.Cells[8].Value.ToString();
                    _oTDDeliveryShipmentItem.InstallationRequired = oItemRow.Cells[9].Value.ToString();
                    _oTDDeliveryShipmentItem.ExpInstallationDate = Convert.ToDateTime(oItemRow.Cells[10].Value.ToString());
                    _oTDDeliveryShipmentItem.ExpInstallationTime = Convert.ToDateTime(oItemRow.Cells[11].Value.ToString());
                    _oTDDeliveryShipmentItem.DeliveryMode = oItemRow.Cells[12].Value.ToString();
                    _oTDDeliveryShipmentItem.VehicleNo = oItemRow.Cells[13].Value.ToString();
                    try
                    {
                        _oTDDeliveryShipmentItem.FreightCost = Convert.ToDouble(oItemRow.Cells[14].Value.ToString());
                    }
                    catch
                    {
                        _oTDDeliveryShipmentItem.FreightCost = 0;
                    }
                    try
                    {
                        _oTDDeliveryShipmentItem.LiftingCost = Convert.ToDouble(oItemRow.Cells[15].Value.ToString());
                    }
                    catch
                    {
                        _oTDDeliveryShipmentItem.LiftingCost = 0;
                    }

                    //if (_nType == (int)Dictionary.TDDeliveryShipmentStatus.Deliverded)

                    _oTDDeliveryShipmentItem.HDCompletionDate = Convert.ToDateTime(oItemRow.Cells[16].Value.ToString());
                    _oTDDeliveryShipmentItem.HDCompletionTime = Convert.ToDateTime(oItemRow.Cells[17].Value.ToString());
                    _oTDDeliveryShipmentItem.IsSafelyDelivered = oItemRow.Cells[18].Value.ToString();
                    try
                    {
                        _oTDDeliveryShipmentItem.Reason = oItemRow.Cells[19].Value.ToString();
                    }
                    catch
                    {
                        _oTDDeliveryShipmentItem.Reason = "";
                    }
                    try
                    {
                        _oTDDeliveryShipmentItem.ActionTaken = oItemRow.Cells[20].Value.ToString();
                    }
                    catch
                    {
                        _oTDDeliveryShipmentItem.ActionTaken = "";
                    }
                    try
                    {
                        _oTDDeliveryShipmentItem.Remarks = oItemRow.Cells[21].Value.ToString();
                    }
                    catch
                    {
                        _oTDDeliveryShipmentItem.Remarks = "";
                    }
                    try
                    {
                        _oTDDeliveryShipmentItem.ApprovedLiftingCost = Convert.ToDouble(oItemRow.Cells[24].Value.ToString());
                    }
                    catch
                    {
                        _oTDDeliveryShipmentItem.ApprovedLiftingCost = 0;
                    }
                    try
                    {
                        _oTDDeliveryShipmentItem.ApprovedFreightCost = Convert.ToDouble(oItemRow.Cells[25].Value.ToString());
                    }
                    catch
                    {
                        _oTDDeliveryShipmentItem.ApprovedFreightCost = 0;
                    }

                    _oTDDeliveryShipment.Add(_oTDDeliveryShipmentItem);

                }
            }

            return _oTDDeliveryShipment;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oTDDeliveryShipment = new TDDeliveryShipment();
                    oTDDeliveryShipment = GetData(oTDDeliveryShipment);
                    if (_nType == (int)Dictionary.TDDeliveryShipmentStatus.Bill_Approved)
                    {
                        oTDDeliveryShipment.BillApproved(nShipmentID, _nType);
                    }
                    else
                    {
                        oTDDeliveryShipment.Edit(nShipmentID, _nType);
                    }


                    DataTran oDataTran = new DataTran();
                    oDataTran.TableName = "t_TDDeliveryShipment";
                    oDataTran.DataID = Convert.ToInt32(nShipmentID);
                    oDataTran.WarehouseID = nWHID;
                    oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                    oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                    oDataTran.BatchNo = 0;
                    if (oDataTran.CheckDataByWHID() == false)
                    {
                        oDataTran.AddForTDPOS();
                    }

                    DBController.Instance.CommitTran();
                    MessageBox.Show("Success fully Add Shipment Data. Invoice no & Date: " + lblInvoiceNo.Text.ToString(), "Add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    _ISLoad = true;


                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("Error..." + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }

        }

        private bool validateUIInput()
        {
            #region Transaction Details Information Validation Old

            //if (dgvTDDeliveryShipment.Rows.Count == 0)
            //{
            //    MessageBox.Show("Please Input Valid Data ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return false;
            //}
            //foreach (DataGridViewRow oItemRow in dgvTDDeliveryShipment.Rows)
            //{
            //    if (oItemRow.Index < dgvTDDeliveryShipment.Rows.Count)
            //    {
            //        if (oItemRow.Cells[0].Value == null)
            //        {
            //            MessageBox.Show("Please Input Valid Product Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return false;
            //        }
            //        if (oItemRow.Cells[0].Value.ToString().Trim() == "")
            //        {
            //            MessageBox.Show("Please Input Valid Product Detail", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return false;
            //        }


            //        if (oItemRow.Cells[1].Value == null)
            //        {
            //            MessageBox.Show("Please Input Valid Qty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return false;
            //        }
            //        if (oItemRow.Cells[1].Value.ToString().Trim() == "")
            //        {
            //            MessageBox.Show("Please Input Valid Qty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return false;
            //        }

            //        if (oItemRow.Cells[2].Value == null)
            //        {
            //            MessageBox.Show("Please Input Valid Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return false;
            //        }
            //        if (oItemRow.Cells[2].Value.ToString().Trim() == "")
            //        {
            //            MessageBox.Show("Please Input Valid Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return false;
            //        }
            //        if (oItemRow.Cells[3].Value != null)
            //        {
            //            try
            //            {
            //                DateTime tmp = Convert.ToDateTime(oItemRow.Cells[3].Value);
            //            }
            //            catch
            //            {
            //                MessageBox.Show("Please input valid shipment Date like: 01-Jan-2050 ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                return false;
            //            }
            //        }
            //        if (oItemRow.Cells[5].Value.ToString().Trim() == "")
            //        {
            //            MessageBox.Show("Please Input shiping address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return false;
            //        }
            //        if (oItemRow.Cells[6].Value.ToString().Trim() == "")
            //        {
            //            MessageBox.Show("Please enter cell no", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return false;
            //        }
            //        else
            //        {
            //            if (oItemRow.Cells[6].Value.ToString().Trim().Length != 11)
            //            {
            //                MessageBox.Show("Please enter a valid cell no", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                return false;
            //            }
            //            Regex rgCell = new Regex("[0-9]");
            //            if (rgCell.IsMatch(oItemRow.Cells[6].Value.ToString()))
            //            {

            //            }
            //            else
            //            {
            //                MessageBox.Show("Please Input Valid Cell no ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                return false;
            //            }
            //        }

            //        string sInstallationRequir = oItemRow.Cells[7].Value.ToString();
            //        if (sInstallationRequir == "Yes")
            //        {
            //            if (oItemRow.Cells[8].Value != null)
            //            {
            //                try
            //                {
            //                    DateTime tmp = Convert.ToDateTime(oItemRow.Cells[8].Value);
            //                }
            //                catch
            //                {
            //                    MessageBox.Show("Please input valid exp.Installation Date like: 01-Jan-2050 ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                    return false;
            //                }

            //            }
            //        }
            //        string sDeliveryMode = oItemRow.Cells[10].Value.ToString();
            //        if (sDeliveryMode == "Company Vehicle")
            //        {
            //            if (oItemRow.Cells[11].Value == null)
            //            {
            //                MessageBox.Show("Please enter vehicle no", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                return false;
            //            }
            //            if (oItemRow.Cells[11].Value.ToString().Trim() == "")
            //            {
            //                MessageBox.Show("Please enter vehicle no", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                return false;
            //            }
            //        }


            //        if (_nType == (int)Dictionary.TDDeliveryShipmentStatus.Delivered)
            //        {
            //            string sIsSaflyDelivery = oItemRow.Cells[16].Value.ToString();
            //            if (sIsSaflyDelivery == "No")
            //            {
            //                if (oItemRow.Cells[17].Value.ToString().Trim() == "")
            //                {
            //                    MessageBox.Show("Please enter reason", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                    return false;
            //                }
            //                if (oItemRow.Cells[18].Value.ToString().Trim() == "")
            //                {
            //                    MessageBox.Show("Please enter action taken text", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                    return false;
            //                }
            //            }
            //        }

            //    }
            //}
            #endregion

            #region Transaction Details Information Validation

            if (dgvTDDeliveryShipment.Rows.Count == 0)
            {
                MessageBox.Show("Please Input Valid Data ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            foreach (DataGridViewRow oItemRow in dgvTDDeliveryShipment.Rows)
            {
                if (oItemRow.Index < dgvTDDeliveryShipment.Rows.Count)
                {
                    if (oItemRow.Cells[0].Value == null)
                    {
                        MessageBox.Show("Please Input Valid Product Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[0].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please Input Valid Product Detail", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }


                    if (oItemRow.Cells[1].Value == null)
                    {
                        MessageBox.Show("Please Input Valid Qty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[1].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please Input Valid Qty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                    if (oItemRow.Cells[2].Value == null)
                    {
                        MessageBox.Show("Please Input Valid Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[2].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please Input Valid Amount", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[3].Value != null)
                    {
                        try
                        {
                            DateTime tmp = Convert.ToDateTime(oItemRow.Cells[3].Value);
                        }
                        catch
                        {
                            MessageBox.Show("Please input valid shipment Date like: 01-Jan-2050 ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    if (oItemRow.Cells[5].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please Input shiping address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    if (oItemRow.Cells[8].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Please enter cell no", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                    else
                    {
                        if (oItemRow.Cells[8].Value.ToString().Trim().Length != 11)
                        {
                            MessageBox.Show("Please enter a valid cell no", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        Regex rgCell = new Regex("[0-9]");
                        if (rgCell.IsMatch(oItemRow.Cells[8].Value.ToString()))
                        {

                        }
                        else
                        {
                            MessageBox.Show("Please Input Valid Cell no ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }

                    string sInstallationRequir = oItemRow.Cells[9].Value.ToString();
                    if (sInstallationRequir == "Yes")
                    {
                        if (oItemRow.Cells[10].Value != null)
                        {
                            try
                            {
                                DateTime tmp = Convert.ToDateTime(oItemRow.Cells[10].Value);
                            }
                            catch
                            {
                                MessageBox.Show("Please input valid exp.Installation Date like: 01-Jan-2050 ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }

                        }
                    }
                    string sDeliveryMode = oItemRow.Cells[12].Value.ToString();
                    if (sDeliveryMode == "Company Vehicle")
                    {
                        if (oItemRow.Cells[13].Value == null)
                        {
                            MessageBox.Show("Please enter vehicle no", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                        if (oItemRow.Cells[13].Value.ToString().Trim() == "")
                        {
                            MessageBox.Show("Please enter vehicle no", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }


                    if (_nType == (int)Dictionary.TDDeliveryShipmentStatus.Delivered)
                    {
                        string sIsSaflyDelivery = oItemRow.Cells[18].Value.ToString();
                        if (sIsSaflyDelivery == "No")
                        {
                            if (oItemRow.Cells[19].Value.ToString().Trim() == "")
                            {
                                MessageBox.Show("Please enter reason", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                            if (oItemRow.Cells[20].Value.ToString().Trim() == "")
                            {
                                MessageBox.Show("Please enter action taken text", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                    }

                }
            }
            #endregion

            return true;
        }
    }
}

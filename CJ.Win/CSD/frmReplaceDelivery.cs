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
    public partial class frmReplaceDelivery : Form
    {
        CourierFromCassandras _oCourierFromCassandras;

        public ReplaceHistory oReplaceHistory;

        public frmReplaceDelivery()
        {
            InitializeComponent();
        }

        private void frmReplaceDelivery_Load(object sender, EventArgs e)
        {
            //if (this.Tag == null)
            //{
            rdbCentralWH.Checked = true;
            rdbWalkIn.Checked = true;
            cmbCourierName.Enabled = false;
            lblCourier.Enabled = false;
            lblConsignmentNo.Enabled = false;
            txtConsignmentNo.Enabled=false;

                LoadCombos();
            //}
        }
        public void ShowDialog(Replace oReplace)

        {
            
            this.Tag = oReplace;

            lblReplaceID.Text = oReplace.ReplaceID.ToString();
            lblJobNo.Text = oReplace.ReplaceJobFromCassandra.JobNo;
            lblCustomerName.Text = oReplace.ReplaceJobFromCassandra.CustomerName;
            lblContactNo.Text = oReplace.ReplaceJobFromCassandra.Mobile;

            txtConsignmentNo.Text = oReplace.ConsignmentNo.ToString();
            txtDeliveredby.Text = oReplace.Deliveredby.ToString();
            dtDeliveryDate.Value = Convert.ToDateTime(oReplace.DeliveryDate.ToString());
            //cmbCourierName.SelectedIndex = _oCourierFromCassandras.GetIndex(oReplace.CourierID);

            if (oReplace.FromWH == 0)
            {
                rdbCentralWH.Checked = true;
            }
            if (oReplace.FromWH == 1)
            {
                rdbShowroom.Checked = true;
            }

            if (oReplace.ModeofDelivery == 0)
            {
                rdbWalkIn.Checked = true;
                rdbHomeDelivery.Checked = false;
                rdbByCourier.Checked = false;
                rdbWHVehicle.Checked = false;

            }
            if (oReplace.ModeofDelivery == 1)
            {
                rdbHomeDelivery.Checked = true;
                rdbWalkIn.Checked = false;
                rdbByCourier.Checked = false;
                rdbWHVehicle.Checked = false;
            }
            if (oReplace.ModeofDelivery == 2)
            {
                rdbByCourier.Checked = true;
                rdbWalkIn.Checked = false;
                rdbWHVehicle.Checked = false;
                rdbHomeDelivery.Checked = false;
            }
            if (oReplace.ModeofDelivery == 3)
            {
                rdbWHVehicle.Checked = true;
                rdbByCourier.Checked = false;
                rdbWalkIn.Checked = false;
                rdbHomeDelivery.Checked = false;
            }
            txtDeliveryRemarks.Text = oReplace.DeliveryRemarks.ToString();


            this.ShowDialog();
        }
        private void LoadCombos()
        {
            //District
            _oCourierFromCassandras = new CourierFromCassandras();

            _oCourierFromCassandras.Refresh();
            //cmbDistrict.Items.Clear();
            foreach (CourierFromCassandra oCourierFromCassandra in _oCourierFromCassandras)
            {
               cmbCourierName.Items.Add(oCourierFromCassandra.CourierServiceName);
            }
            if (_oCourierFromCassandras.Count > 0)
                cmbCourierName.SelectedIndex = _oCourierFromCassandras.Count - 1;
        }
        //private bool validateUIInput()
        //{
        //    #region Input Information Validation



        //    if (txtCancelReason.Text == "")
        //    {
        //        MessageBox.Show("Please enter the Cancel Reason", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        txtCancelReason.Focus();
        //        return false;
        //    }


        //    #endregion

        //    return true;
        //}
        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (validateUIInput())
            {
                Save();
                this.Close();
            }
        }
        private void Save()
        {
            Replace oReplace = (Replace)this.Tag;
            oReplace.DeliveryDate = dtDeliveryDate.Value.Date;

            if (rdbCentralWH.Checked==true)
            {
                oReplace.FromWH = (int)Dictionary.ReplaceFromWH.CentralWH;
            }
            if (rdbShowroom.Checked == true)
            {
                oReplace.FromWH = (int)Dictionary.ReplaceFromWH.Showroom;
            }

            if (rdbWalkIn.Checked == true)
            {
                oReplace.ModeofDelivery = (int)Dictionary.ReplaceModeofDelivery.WalkIn;
            }
            if (rdbHomeDelivery.Checked == true)
            { 
                oReplace.ModeofDelivery = (int)Dictionary.ReplaceModeofDelivery.HomeDelivery;
            }
            if (rdbByCourier.Checked == true)
            {
                oReplace.ModeofDelivery = (int)Dictionary.ReplaceModeofDelivery.ByCourier;
            }
            if (rdbWHVehicle.Checked == true)
            {
                oReplace.ModeofDelivery = (int)Dictionary.ReplaceModeofDelivery.ByHW_Vehicle;
            }

            if (rdbByCourier.Checked == true)
            {
                oReplace.ConsignmentNo = txtConsignmentNo.Text;
                oReplace.CourierID = _oCourierFromCassandras[cmbCourierName.SelectedIndex].CourierServiceID;
            }
            else
            {
                oReplace.ConsignmentNo = "";
                oReplace.CourierID = 0;
            }

            oReplace.Deliveredby = txtDeliveredby.Text;
            oReplace.Status = (int)Dictionary.ReplaceStatusCriteria.Delivered;

            
            try
            {
                DBController.Instance.BeginNewTransaction();
                oReplace.DeliveryReplace();
                oReplace.UpdateDelNStatCassandra();
                {
                    oReplaceHistory = new ReplaceHistory();

                    oReplaceHistory.ReplaceID = oReplace.ReplaceID;
                    oReplaceHistory.Status = (int)Dictionary.ReplaceStatusCriteria.Delivered;
                    if (oReplaceHistory.CheckReplace())
                    {
                        oReplaceHistory.ReplaceID = oReplace.ReplaceID;
                        oReplaceHistory.Remarks = this.txtDeliveryRemarks.Text;
                        oReplaceHistory.Status = (int)Dictionary.ReplaceStatusCriteria.Delivered;
                        oReplaceHistory.UpdateReplaceHistoryRemarks();
                    }
                    else
                    {
                        oReplaceHistory.ReplaceID = oReplace.ReplaceID;
                        oReplaceHistory.Remarks = this.txtDeliveryRemarks.Text;
                        oReplaceHistory.Status = (int)Dictionary.ReplaceStatusCriteria.Delivered;
                        oReplaceHistory.AddReplaceHistory();
                    }

                }
                DBController.Instance.CommitTransaction();
                MessageBox.Show("Update Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }

        }

        private void rdbWalkIn_CheckedChanged(object sender, EventArgs e)
        {
            cmbCourierName.Enabled = false;
            lblCourier.Enabled = false;
            lblConsignmentNo.Enabled = false;
            txtConsignmentNo.Enabled = false;

        }

        private void rdbHomeDelivery_CheckedChanged(object sender, EventArgs e)
        {
            cmbCourierName.Enabled = false;
            lblCourier.Enabled = false;
            lblConsignmentNo.Enabled = false;
            txtConsignmentNo.Enabled = false;
        }

        private void rdbByCourier_CheckedChanged(object sender, EventArgs e)
        {
            cmbCourierName.Enabled = true;
            lblCourier.Enabled = true;
            lblConsignmentNo.Enabled = true;
            txtConsignmentNo.Enabled = true;
        }

        private void rdbWHVehicle_CheckedChanged(object sender, EventArgs e)
        {
            cmbCourierName.Enabled = false;
            lblCourier.Enabled = false;
            lblConsignmentNo.Enabled = false;
            txtConsignmentNo.Enabled = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

     }
}
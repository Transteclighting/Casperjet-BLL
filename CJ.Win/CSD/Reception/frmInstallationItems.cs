using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.CSD.Reception
{
    public partial class frmInstallationItems : Form
    {
        Showrooms oShowrooms;
        ProductGroups _oMAG;
        ProductGroups _oPG;
        TDDeliveryShipments _oTDDeliveryShipment;
        bool IsCheckIns = false;
        bool IsCheck = false;

        public frmInstallationItems()
        {
            InitializeComponent();
            this.Cursor = Cursors.Default;
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void LoadCombos()
        {
            DBController.Instance.OpenNewConnection();
            dtFromDate.Value = DateTime.Today;
            dtToDate.Value = DateTime.Today;
            dtExpInstallFromDate.Value = DateTime.Today;
            dtExpInstallToDate.Value = DateTime.Today;

            //Showrooms
            oShowrooms = new Showrooms();
            oShowrooms.GetAllShowroom();
            cmbWarehouse.Items.Clear();
            cmbWarehouse.Items.Add("<All>");
            foreach (Showroom oShowroom in oShowrooms)
            {
                cmbWarehouse.Items.Add('[' + oShowroom.ShowroomCode + ']' + ' ' + oShowroom.ShowroomName);
            }
            cmbWarehouse.SelectedIndex = 0;

            ////MAG
            _oMAG = new ProductGroups();
            cmbMAG.Items.Clear();
            cmbMAG.Items.Add("<All>");
            _oMAG.GetProductGroup((int)Dictionary.ProductGroupType.MAG);
            foreach (ProductGroup oProductGroup in _oMAG)
            {
                cmbMAG.Items.Add(oProductGroup.PdtGroupName);
            }
            cmbMAG.SelectedIndex = 0;


            ////MAG
            _oPG = new ProductGroups();
            cmbPG.Items.Clear();
            cmbPG.Items.Add("<All>");
            _oPG.GetProductGroup((int)Dictionary.ProductGroupType.ProductGroup);
            foreach (ProductGroup oPg in _oPG)
            {
                cmbPG.Items.Add(oPg.PdtGroupName);
            }
            cmbPG.SelectedIndex = 0;


        }
        //private void SetListViewRowColour()
        //{
        //    if (lvwCSDCustomerQuery.Items.Count > 0)
        //    {
        //        foreach (ListViewItem oItem in lvwCSDCustomerQuery.Items)
        //        {
        //            if (oItem.SubItems[10].Text == "Yes")
        //            {
        //                oItem.BackColor = Color.Transparent;
        //            }
        //            else
        //            {
        //                oItem.BackColor = Color.LightPink;
        //            }
        //        }
        //    }
        //}
        private void DataLoadControl()
        {
            try
            {

                this.Cursor = Cursors.WaitCursor;
                int nWarehouse = 0;
                if (cmbWarehouse.SelectedIndex == 0)
                {
                    nWarehouse = -1;
                }
                else
                {
                    nWarehouse = oShowrooms[cmbWarehouse.SelectedIndex - 1].WarehouseID;
                }

                int nMAG = 0;
                if (cmbMAG.SelectedIndex == 0)
                {
                    nMAG = -1;
                }
                else
                {
                    nMAG = _oMAG[cmbMAG.SelectedIndex - 1].PdtGroupID;
                }
                int nPG = 0;
                if (cmbPG.SelectedIndex == 0)
                {
                    nPG = -1;
                }
                else
                {
                    nPG = _oPG[cmbPG.SelectedIndex - 1].PdtGroupID;
                }

                _oTDDeliveryShipment = new TDDeliveryShipments();
                lvwCSDCustomerQuery.Items.Clear();
                DBController.Instance.OpenNewConnection();
                _oTDDeliveryShipment.GetInstallationItem(dtFromDate.Value.Date, dtToDate.Value.Date,
                    dtExpInstallFromDate.Value.Date, dtExpInstallToDate.Value.Date, IsCheck, IsCheckIns,
                    txtInvoiceNo.Text.Trim(), txtCustName.Text.Trim(), nWarehouse, txtMobile.Text.Trim(), nMAG, nPG);
                DBController.Instance.CloseConnection();

                foreach (TDDeliveryShipmentItem oTDDeliveryShipmentItem in _oTDDeliveryShipment)
                {
                    ListViewItem oItem = lvwCSDCustomerQuery.Items.Add(oTDDeliveryShipmentItem.ShowroomCode.ToString());

                    oItem.SubItems.Add(oTDDeliveryShipmentItem.InvoiceNo.ToString());
                    oItem.SubItems.Add(Convert.ToDateTime(oTDDeliveryShipmentItem.InvoiceDate).ToString("dd-MMM-yyyy"));
                    oItem.SubItems.Add(oTDDeliveryShipmentItem.ConsumerName.ToString());
                    oItem.SubItems.Add(oTDDeliveryShipmentItem.ShipingAddress.ToString());
                    oItem.SubItems.Add(oTDDeliveryShipmentItem.ContactNo.ToString());
                    oItem.SubItems.Add(oTDDeliveryShipmentItem.Email.ToString());
                    oItem.SubItems.Add(oTDDeliveryShipmentItem.ProductCode.ToString());
                    oItem.SubItems.Add(oTDDeliveryShipmentItem.ProductName.ToString());
                    oItem.SubItems.Add(oTDDeliveryShipmentItem.AGName.ToString());
                    oItem.SubItems.Add(oTDDeliveryShipmentItem.ASGName.ToString());
                    oItem.SubItems.Add(oTDDeliveryShipmentItem.MAGName.ToString());
                    oItem.SubItems.Add(oTDDeliveryShipmentItem.PGName.ToString());
                    oItem.SubItems.Add(oTDDeliveryShipmentItem.ProductSerialNo.ToString());
                    if (oTDDeliveryShipmentItem.ExpInstallationDate != null)
                    {
                        oItem.SubItems.Add(
                            Convert.ToDateTime(oTDDeliveryShipmentItem.ExpInstallationDate).ToString("dd-MMM-yyyy"));
                    }
                    else
                    {
                        oItem.SubItems.Add("");
                    }
                    if (oTDDeliveryShipmentItem.ExpInstallationTime != null)
                    {
                        oItem.SubItems.Add(
                            Convert.ToDateTime(oTDDeliveryShipmentItem.ExpInstallationTime).ToString("HH:mm:ss"));
                    }
                    else
                    {
                        oItem.SubItems.Add("");
                    }

                    oItem.SubItems.Add(oTDDeliveryShipmentItem.DeliveryMode.ToString());

                    if (oTDDeliveryShipmentItem.HDCompletionDate != null)
                    {
                        oItem.SubItems.Add(
                            Convert.ToDateTime(oTDDeliveryShipmentItem.HDCompletionDate).ToString("dd-MMM-yyyy"));
                    }
                    else
                    {
                        oItem.SubItems.Add("");
                    }
                    if (oTDDeliveryShipmentItem.HDCompletionTime != null)
                    {
                        oItem.SubItems.Add(
                            Convert.ToDateTime(oTDDeliveryShipmentItem.HDCompletionTime).ToString("HH:mm:ss"));
                    }
                    else
                    {
                        oItem.SubItems.Add("");
                    }

                    oItem.SubItems.Add(oTDDeliveryShipmentItem.IsSafelyDelivered.ToString());
                    oItem.SubItems.Add(oTDDeliveryShipmentItem.Reason.ToString());
                    oItem.SubItems.Add(oTDDeliveryShipmentItem.ActionTaken.ToString());
                    oItem.SubItems.Add(oTDDeliveryShipmentItem.JobNo.ToString());

                    if (oTDDeliveryShipmentItem.InstallationDate != null)
                    {

                        oItem.SubItems.Add(
                            Convert.ToDateTime(oTDDeliveryShipmentItem.InstallationDate).ToString("dd-MMM-yyyy"));
                    }
                    else
                    {
                        oItem.SubItems.Add("");
                    }
                    if (oTDDeliveryShipmentItem.InstallationTime != null)
                    {
                        oItem.SubItems.Add(
                            Convert.ToDateTime(oTDDeliveryShipmentItem.InstallationTime).ToString("HH:mm:ss"));
                    }
                    else
                    {
                        oItem.SubItems.Add("");
                    }
                    oItem.SubItems.Add(oTDDeliveryShipmentItem.IsProperlyInstalled.ToString());
                    oItem.SubItems.Add(oTDDeliveryShipmentItem.CSDReason.ToString());
                    oItem.SubItems.Add(oTDDeliveryShipmentItem.CSDRemarks.ToString());
                    oItem.SubItems.Add(oTDDeliveryShipmentItem.Remarks.ToString());
                    //oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.IsHappyCall), oTDDeliveryShipmentItem.IsHappyCall));

                    oItem.Tag = oTDDeliveryShipmentItem;
                }

                this.Text = @"Installation Required Invoice List [" + _oTDDeliveryShipment.Count + @"]";
                this.Cursor = Cursors.Default;

            }
            catch (Exception x)
            {
                MessageBox.Show(
                    string.Format(@"An error occurred in your application. Please try after sometimes " + "\n" + "{0}",
                        x), @"Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Cursor = Cursors.Default;
            }
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                dtFromDate.Enabled = false;
                dtToDate.Enabled = false;
                IsCheck = true;
            }
            else
            {
                dtFromDate.Enabled = true;
                dtToDate.Enabled = true;
                IsCheck = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                dtExpInstallFromDate.Enabled = false;
                dtExpInstallToDate.Enabled = false;
                IsCheckIns = true;
            }
            else
            {
                dtExpInstallFromDate.Enabled = true;
                dtExpInstallToDate.Enabled = true;
                IsCheckIns = false;
            }
        }

        private void frmInstallationItems_Load(object sender, EventArgs e)
        {
            LoadCombos();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
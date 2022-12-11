using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.SupplyChain;
using CJ.Class.BasicData;
using CJ.Class.Library;




namespace CJ.Win.SupplyChain
{
    public partial class frmOrderAndLCs : Form
    {
        Companys _oCompanys;
        Suppliers _oSuppliers;
        SCMOrders _oSCMOrders;
        bool IsCheck = false;

        public frmOrderAndLCs()
        {
            InitializeComponent();
        }

        private void btnOrderPlace_Click(object sender, EventArgs e)
        {
                frmSCMOrders oForm = new frmSCMOrders();
                oForm.ShowDialog();
                DataLoadControl();
        }

        private void LoadCombos()
        {
            dtFromdate.Value = DateTime.Today;
            dtTodate.Value = DateTime.Today;

            //Company
            _oCompanys = new Companys();
            _oCompanys.RefreshByCompany(Utility.CompanyInfo);
            cmbCompany.Items.Clear();
            cmbCompany.Items.Add("<All>");
            foreach (Company oCompany in _oCompanys)
            {
                cmbCompany.Items.Add(oCompany.CompanyName);
            }
            cmbCompany.SelectedIndex = 0;


            // Suppliers
            _oSuppliers = new Suppliers();
            _oSuppliers.GetSupplierBySupplierName();
            cmbSupplier.Items.Clear();
            cmbSupplier.Items.Add("<All>");
            foreach (Supplier oSupplier in _oSuppliers)
            {
                cmbSupplier.Items.Add(oSupplier.SupplierName);
            }
            cmbSupplier.SelectedIndex = 0;

            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("<All>");
            //SCM Status
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SCMStatus)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.SCMStatus), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;
        }
        private void SetListViewRowColour()
        {
            if (lvwOrder.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwOrder.Items)
                {
                    if (oItem.SubItems[5].Text == "PSI")
                    {
                        oItem.BackColor = Color.Transparent;
                    }
                    else if (oItem.SubItems[5].Text == "OrderPlace")
                    {
                        oItem.BackColor = Color.GreenYellow;

                    }
                    else if (oItem.SubItems[5].Text == "PIReceive")
                    {
                        oItem.BackColor = Color.LightPink;

                    }
                    else if (oItem.SubItems[5].Text == "LCProcessing")
                    {
                        oItem.BackColor = Color.LightSkyBlue;

                    }
                    else if (oItem.SubItems[5].Text == "LCOpening")
                    {
                        oItem.BackColor = Color.LightGreen;

                    }
                    else if (oItem.SubItems[5].Text == "Shipment")
                    {
                        oItem.BackColor = Color.Magenta;

                    }
                    else if (oItem.SubItems[5].Text == "CustomerClearance")
                    {
                        oItem.BackColor = Color.Yellow;

                    }
                    else if (oItem.SubItems[5].Text == "Release")
                    {
                        oItem.BackColor = Color.Cyan;

                    }
                    else if (oItem.SubItems[5].Text == "ReadyForGRD")
                    {
                        oItem.BackColor = Color.Green;

                    }
                    else
                    {
                        oItem.BackColor = Color.Silver;
                    }

                }
            }
        }
        private void DataLoadControl()
        {
            _oSCMOrders = new SCMOrders();
            lvwOrder.Items.Clear();

            int nCompany = 0;
            if (cmbCompany.SelectedIndex == 0)
            {
                nCompany = -1;
            }
            else
            {
                nCompany = _oCompanys[cmbCompany.SelectedIndex - 1].CompanyID;
            }

            int nSupplier = 0;

            if (cmbSupplier.SelectedIndex == 0)
            {
                nSupplier = -1;
            }
            else
            {
                nSupplier = _oSuppliers[cmbSupplier.SelectedIndex - 1].SupplierID;
            }

            int nStatus = 0;

            if (cmbStatus.SelectedIndex == 0)
            {
                nStatus = -1;
            }
            else
            {
                nStatus = cmbStatus.SelectedIndex ;
            }


            DBController.Instance.OpenNewConnection();
            _oSCMOrders.RefreshOrder(dtFromdate.Value.Date, dtTodate.Value.Date,nStatus,nCompany,txtPSINo.Text.Trim(), IsCheck, nSupplier,txtOrderNo.Text.Trim());
            DBController.Instance.CloseConnection();

            foreach (SCMOrder oSCMOrder in _oSCMOrders)
            {
                ListViewItem oItem = lvwOrder.Items.Add(oSCMOrder.OrderNo.ToString());
                oItem.SubItems.Add(oSCMOrder.PSINo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oSCMOrder.OrderPlaceDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oSCMOrder.CompanyName.ToString());
                oItem.SubItems.Add(oSCMOrder.SupplierName.ToString());
                oItem.SubItems.Add(oSCMOrder.StatusName.ToString());

                oItem.Tag = oSCMOrder;
            }
            this.Text = "Orders [" + _oSCMOrders.Count + "]";
            SetListViewRowColour();
        }
        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();

        }

        private void frmOrderAndLCs_Load(object sender, EventArgs e)
        {
            DBController.Instance.OpenNewConnection();
            LoadCombos();
            DataLoadControl();

        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                dtFromdate.Enabled = false;
                dtTodate.Enabled = false;
                IsCheck = true;
            }
            else
            {
                dtFromdate.Enabled = true;
                dtTodate.Enabled = true;
                IsCheck = false;
            }
        }

        //private void btnPIReceived_Click(object sender, EventArgs e)
        //{
        //    if (lvwOrder.SelectedItems.Count == 0)
        //    {
        //        MessageBox.Show("Please Select a PO to Order Place.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }
        //    SCMOrder oSCMOrder = (SCMOrder)lvwOrder.SelectedItems[0].Tag;
        //    if (oSCMOrder.Status == (int)Dictionary.SCMStatus.OrderPlace)
        //    {
        //        frmSCMPI oForm = new frmSCMPI();
        //        oForm.ShowDialog(oSCMOrder);
        //        DataLoadControl();

        //    }
        //    else
        //    {
        //        MessageBox.Show("Only PSI status can be Placed PINO & PIReceive Date", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }


        //}

        //private void btnLCProcess_Click(object sender, EventArgs e)
        //{
        //    //if (lvwOrder.SelectedItems.Count == 0)
        //    //{
        //    //    MessageBox.Show("Please Select a Order to LC Process.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    //    return;
        //    //}
        //    //SCMOrder oSCMOrder = (SCMOrder)lvwOrder.SelectedItems[0].Tag;
        //    //if (oSCMOrder.Status == (int)Dictionary.SCMStatus.LCProcessing)
        //    //{
        //    //    frmSCMLCOpen oForm = new frmSCMLCOpen();
        //    //    oForm.ShowDialog(oSCMOrder);
        //    //    DataLoadControl();

        //    //}
        //    //else
        //    //{
        //    //    MessageBox.Show("Only LCProcessing status can be LC Process", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    //    return;
        //    //}
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    //if (lvwOrder.SelectedItems.Count == 0)
        //    //{
        //    //    MessageBox.Show("Please Select a Order to NON LC Process.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    //    return;
        //    //}
        //    //SCMOrder oSCMOrder = (SCMOrder)lvwOrder.SelectedItems[0].Tag;
        //    //if (oSCMOrder.Status == (int)Dictionary.SCMStatus.PIReceive)
        //    //{
        //    //    frmNonLC oForm = new frmNonLC();
        //    //    oForm.ShowDialog(oSCMOrder);
        //    //    DataLoadControl();

        //    //}
        //    //else
        //    //{
        //    //    MessageBox.Show("Only PIReceive status can be NON LC Process", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    //    return;
        //    //}

        //}

        //private void btnLCProcessingDate_Click(object sender, EventArgs e)
        //{
        //    //if (lvwOrder.SelectedItems.Count == 0)
        //    //{
        //    //    MessageBox.Show("Please Select a PI to Set LC Processing Date.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    //    return;
        //    //}
        //    //SCMOrder oSCMOrder = (SCMOrder)lvwOrder.SelectedItems[0].Tag;
        //    //if (oSCMOrder.Status == (int)Dictionary.SCMStatus.PIReceive)
        //    //{
        //    //    frmLCProcessingDate oForm = new frmLCProcessingDate();
        //    //    oForm.ShowDialog(oSCMOrder);
        //    //    DataLoadControl();

        //    //}
        //    //else
        //    //{
        //    //    MessageBox.Show("Only PI status can be Set LC Processing Date", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    //    return;
        //    //}

        //}

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblSupplier_Click(object sender, EventArgs e)
        {

        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }

        private void cmbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblCompany_Click(object sender, EventArgs e)
        {

        }
    }
}
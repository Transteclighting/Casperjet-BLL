using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class.POS;
using CJ.Class;

namespace CJ.Win.Accounts
{
    public partial class frmEMIManagements : Form
    {
        bool IsCheck = false;
        Showrooms _oShowrooms;
        Banks _oBanks;
        RetailSalesInvoices _oRetailSalesInvoices;


        public frmEMIManagements()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadCombos()
        {
            dtFromDate.Value = DateTime.Today;
            dtToDate.Value = DateTime.Today;

            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("--All--");
            //Stationary Tran Type
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.EMIManagement)))
            {
                cmbStatus.Items.Add(Enum.GetName(typeof(Dictionary.EMIManagement), GetEnum));
            }
            cmbStatus.SelectedIndex = 0;

            //Showroom
            _oShowrooms = new Showrooms();
            _oShowrooms.Refresh();
            cmbShowroom.Items.Add("--All--");
            foreach (Showroom oShowroom in _oShowrooms)
            {
                cmbShowroom.Items.Add(oShowroom.ShowroomName + "[" + oShowroom.ShowroomCode + "]");
            }
            cmbShowroom.SelectedIndex = 0;

            //Bank
            _oBanks = new Banks();
            _oBanks.Refresh();
            cmbBank.Items.Add("--All--");
            foreach (Bank oBank in _oBanks)
            {
                cmbBank.Items.Add(oBank.Name + "[" + oBank.Code + "]");
            }
            cmbBank.SelectedIndex = 0;

        }
        private void SetListViewRowColour()
        {
            if (lvwEMIInfo.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwEMIInfo.Items)
                {
                    if (oItem.SubItems[12].Text == "Pending")
                    {
                        oItem.BackColor = Color.Salmon;
                    }
                    else
                    {
                        oItem.BackColor = Color.DarkSeaGreen;
                    }

                }
            }
        }
        private void DataLoadControl()
        {
            _oRetailSalesInvoices = new RetailSalesInvoices();
            lvwEMIInfo.Items.Clear();


            int nStatus = 0;
            if (cmbStatus.SelectedIndex == 0)
            {
                nStatus = -1;
            }
            else
            {
                nStatus = cmbStatus.SelectedIndex - 1;
            }

            int nBankID = 0;
            if (cmbBank.SelectedIndex == 0)
            {
                nBankID = -1;
            }
            else
            {
                nBankID = _oBanks[cmbBank.SelectedIndex - 1].BankID;
            }

            int nWarehouse = 0;
            if (cmbShowroom.SelectedIndex == 0)
            {
                nWarehouse = -1;
            }
            else
            {
                nWarehouse = _oShowrooms[cmbShowroom.SelectedIndex - 1].WarehouseID;
            }


            DBController.Instance.OpenNewConnection();
            _oRetailSalesInvoices.GetEMIData(dtFromDate.Value.Date, dtToDate.Value.Date, nWarehouse, nBankID, nStatus, txtTranNo.Text.Trim(), IsCheck);
            DBController.Instance.CloseConnection();

            foreach (RetailSalesInvoice oRetailSalesInvoice in _oRetailSalesInvoices)
            {
                ListViewItem oItem = lvwEMIInfo.Items.Add(oRetailSalesInvoice.ShowroomCode.ToString());
                oItem.SubItems.Add(oRetailSalesInvoice.InvoiceNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oRetailSalesInvoice.InvoiceDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(Convert.ToDouble(oRetailSalesInvoice.Amount).ToString());
                oItem.SubItems.Add(oRetailSalesInvoice.PaymentModeName.ToString());
                oItem.SubItems.Add(oRetailSalesInvoice.BankName.ToString());
                oItem.SubItems.Add(oRetailSalesInvoice.CardTypeName.ToString());
                oItem.SubItems.Add(oRetailSalesInvoice.POSMachineName.ToString());
                oItem.SubItems.Add(Convert.ToInt32(oRetailSalesInvoice.NoOfInstallment).ToString());
                oItem.SubItems.Add(oRetailSalesInvoice.InstrumentNo.ToString());
                oItem.SubItems.Add(Convert.ToDateTime(oRetailSalesInvoice.InstrumentDate).ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oRetailSalesInvoice.CardCategoryName.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.EMIManagement), oRetailSalesInvoice.Status));

                oItem.Tag = oRetailSalesInvoice;
            }
            SetListViewRowColour();
            this.Text = "EMI Management [" + _oRetailSalesInvoices.Count + "]";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (lvwEMIInfo.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Item to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            RetailSalesInvoice oRetailSalesInvoice = (RetailSalesInvoice)lvwEMIInfo.SelectedItems[0].Tag;
            if (oRetailSalesInvoice.Status == (int)Dictionary.EMIManagement.Pending)
            {
                frmEMIManagement oFrom = new frmEMIManagement();
                oFrom.ShowDialog(oRetailSalesInvoice);
                DataLoadControl();
            }
            else
            {
                MessageBox.Show("Only Pending Status Can be Update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();

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

        private void frmEMIManagements_Load(object sender, EventArgs e)
        {
            LoadCombos();
            DataLoadControl();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            if (lvwEMIInfo.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Item to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            RetailSalesInvoice oRetailSalesInvoice = (RetailSalesInvoice)lvwEMIInfo.SelectedItems[0].Tag;
            if (oRetailSalesInvoice.Status == (int)Dictionary.EMIManagement.Send_To_Bank)
            {
                DialogResult oResult = MessageBox.Show("Are you sure you want to delete: " + oRetailSalesInvoice.InvoiceNo + " ? ", "Confirm Ticket Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oResult == DialogResult.Yes)
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        oRetailSalesInvoice.DeleteEMIData();
                        DBController.Instance.CommitTransaction();
                        DataLoadControl();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }

                }
            }
            else
            {
                MessageBox.Show("Only Send To Bank Status Can be Delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }
    }
}
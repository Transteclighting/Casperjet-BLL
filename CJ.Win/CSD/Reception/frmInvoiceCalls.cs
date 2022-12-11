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
    public partial class frmInvoiceCalls : Form
    {
        CSDCustomerSatisfactions _oCSDCustomerSatisfactions;
        bool IsCheck = false;
        Showrooms oShowrooms; 


        public frmInvoiceCalls()
        {
            InitializeComponent();
            this.Cursor = Cursors.Default;
        }

        private void frmInvoiceCalls_Load(object sender, EventArgs e)
        {
            LoadCombos();
            DataLoadControl();
            
        }

        private void LoadCombos()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }


            dtFromDate.Value = DateTime.Today;
            dtToDate.Value = DateTime.Today;

            //Sales Type
            cmbSalesType.Items.Clear();
            cmbSalesType.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SalesType)))
            {
                cmbSalesType.Items.Add(Enum.GetName(typeof(Dictionary.SalesType), GetEnum));
            }
            cmbSalesType.SelectedIndex = 0;

            //IsHappyCall
            cmbIsHappyCall.Items.Clear();
            cmbIsHappyCall.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.IsHappyCall)))
            {
                cmbIsHappyCall.Items.Add(Enum.GetName(typeof(Dictionary.IsHappyCall), GetEnum));
            }
            cmbIsHappyCall.SelectedIndex = 0;

            cmbCallStatus.Items.Clear();
            cmbCallStatus.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CSDHappyCallStatus)))
            {
                cmbCallStatus.Items.Add(Enum.GetName(typeof(Dictionary.CSDHappyCallStatus), GetEnum));
            }
            cmbCallStatus.SelectedIndex = 0;

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


            cmbIsBanforever.Items.Clear();
            cmbIsBanforever.Items.Add("<All>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.YesOrNoStatus)))
            {
                cmbIsBanforever.Items.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), GetEnum));
            }
            cmbIsBanforever.SelectedIndex = 0;

        }
        private void SetListViewRowColour()
        {
            if (lvwCSDCustomerQuery.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwCSDCustomerQuery.Items) 
                {
                    if (oItem.SubItems[11].Text == @"Yes")
                    {
                        oItem.BackColor = Color.Transparent;
                    }
                    if (oItem.SubItems[11].Text == @"No")
                    {
                        oItem.BackColor = Color.LightPink;
                    }
                    //else
                    //{
                    //    oItem.BackColor = Color.LightPink;
                    //}
                }
            }
        }
        private void DataLoadControl()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                int nIsHappyCall = 0;
                if (cmbIsHappyCall.SelectedIndex == 0)
                {
                    nIsHappyCall = -1;
                }
                else
                {
                    nIsHappyCall = cmbIsHappyCall.SelectedIndex - 1;
                }
                int nWarehouse = 0;
                if (cmbWarehouse.SelectedIndex == 0)
                {
                    nWarehouse = -1;
                }
                else
                {
                    nWarehouse = oShowrooms[cmbWarehouse.SelectedIndex - 1].WarehouseID;
                }

                int nSalesType = 0;
                if (cmbSalesType.SelectedIndex == 0)
                {
                    nSalesType = -1;
                }
                else
                {
                    nSalesType = cmbSalesType.SelectedIndex;
                }

                int nIsBanforever = 0;
                if (cmbIsBanforever.SelectedIndex == 0)
                {
                    nIsBanforever = -1;
                }
                else
                {
                    nIsBanforever = cmbIsBanforever.SelectedIndex - 1;
                }
                //int nIsBanforever = -1;
                //if (cmbCallStatus.SelectedIndex != 0)
                //{
                //    nStatus = cmbCallStatus.SelectedIndex;
                //}
                _oCSDCustomerSatisfactions = new CSDCustomerSatisfactions();
                lvwCSDCustomerQuery.Items.Clear();
                if (!DBController.Instance.CheckConnection())
                {
                    DBController.Instance.OpenNewConnection();
                }

                _oCSDCustomerSatisfactions.GetDataByCustomerQuery(dtFromDate.Value.Date, dtToDate.Value.Date,
                    txtInvoiceNo.Text.Trim(), txtCustName.Text.Trim(), txtMobile.Text.Trim(), nIsHappyCall, nWarehouse,
                    IsCheck, nSalesType,cmbCallStatus.Text, nIsBanforever);
                DBController.Instance.CloseConnection();

                foreach (CSDCustomerSatisfaction oCsdCustomerSatisfaction in _oCSDCustomerSatisfactions)
                {
                    ListViewItem oItem = lvwCSDCustomerQuery.Items.Add(oCsdCustomerSatisfaction.InvoiceNo.ToString());
                    oItem.SubItems.Add(Convert.ToDateTime(oCsdCustomerSatisfaction.InvoiceDate).ToString("dd-MMM-yyyy"));
                    oItem.SubItems.Add(oCsdCustomerSatisfaction.JobNo.ToString());
                    oItem.SubItems.Add(oCsdCustomerSatisfaction.ShowroomCode.ToString());
                    oItem.SubItems.Add(oCsdCustomerSatisfaction.ConsumerName.ToString());
                    oItem.SubItems.Add(oCsdCustomerSatisfaction.Address.ToString());
                    oItem.SubItems.Add(oCsdCustomerSatisfaction.Mobile.ToString());
                    oItem.SubItems.Add(oCsdCustomerSatisfaction.Email.ToString());
                    oItem.SubItems.Add(oCsdCustomerSatisfaction.InvoiceAmount.ToString());
                    oItem.SubItems.Add(oCsdCustomerSatisfaction.Discount.ToString());
                    oItem.SubItems.Add(oCsdCustomerSatisfaction.InstallationRequired.ToString());
                    oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.IsHappyCall), oCsdCustomerSatisfaction.IsHappyCall));
                    oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.SalesType), oCsdCustomerSatisfaction.SalesType));
                    //oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.CSDHappyCallStatus), oCsdCustomerSatisfaction.Status));
                    oItem.SubItems.Add(oCsdCustomerSatisfaction.CallStatus.ToString());
                    oItem.SubItems.Add(oCsdCustomerSatisfaction.IsExchangeOffer.ToString());
                    oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), oCsdCustomerSatisfaction.IsBanforever));
                    oItem.Tag = oCsdCustomerSatisfaction;
                }
                SetListViewRowColour();
                this.Text = @"Invoice List [" + _oCSDCustomerSatisfactions.Count + @"]";
                this.Cursor = Cursors.Default;
            }
            catch (Exception x)
            {
                MessageBox.Show(string.Format(@"An error occurred in your application. Please try after sometimes " + "\n" + "{0}", x), @"Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Cursor = Cursors.Default;
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lvwCSDCustomerQuery.SelectedItems.Count == 0)
            {
                MessageBox.Show(@"Please Select an Item.", @"Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CSDCustomerSatisfaction oCsdCustomerSatisfaction = (CSDCustomerSatisfaction)lvwCSDCustomerQuery.SelectedItems[0].Tag;
            if (oCsdCustomerSatisfaction.IsBanforever == (int)Dictionary.YesOrNoStatus.NO)
            {
                if (oCsdCustomerSatisfaction.IsHappyCall == (int)Dictionary.YesOrNoStatus.NO|| oCsdCustomerSatisfaction.Status == (int)Dictionary.CSDHappyCallStatus.CallBack || oCsdCustomerSatisfaction.Status == (int)Dictionary.CSDHappyCallStatus.NoResponse || oCsdCustomerSatisfaction.Status == (int)Dictionary.CSDHappyCallStatus.NumBusy || oCsdCustomerSatisfaction.Status == (int)Dictionary.CSDHappyCallStatus.Switched_Off)
                {
                    frmInvoiceCallsCustomerWise oForm = new frmInvoiceCallsCustomerWise();
                    oForm.ShowDialog(oCsdCustomerSatisfaction);
                    if (oForm._IsLoad == true)
                    {
                        DataLoadControl();
                    }
                }
            }
            else
            {
                MessageBox.Show(@"Please select valid invoice no", @"Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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


    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Resources;


using CJ.Class;
using CJ.Class.DMS;
using CJ.Class.Library;
using System.Diagnostics;


namespace CJ.Win.DMS
{
    public partial class frmSaledateCorrection : Form
    {
        private DSPermission _oDSPermission;

        private int _nCallCountUp = 0;
        private int _nCallCountDn = 0;
        private bool _bSuspended;
        private bool _bFlag;
        int nUserId;
        int nDistributorID;

        static string sUsername;
        public frmSaledateCorrection()
        {
            InitializeComponent();
        }
        public void ShowDialog(DMSUser oDMSUser)
        {
            ctlCustomer1.txtCode.Text = oDMSUser.Customer.CustomerCode;
            dtFromDate.Text = oDMSUser.TranDate.ToString();
            lblsysdate.Text = oDMSUser.TranDate.ToString("dd-MMM-yyyy");
            this.Tag = oDMSUser;
            this.ShowDialog();
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {

            DateTime Updatedate = Convert.ToDateTime(dtFromDate.Text);
            DateTime TranDate = Convert.ToDateTime(lblsysdate.Text);
            DateTime ForwardDate = Convert.ToDateTime(lblsysdate.Text).AddDays(+5);
            DateTime BackwardDate = Convert.ToDateTime(lblsysdate.Text).AddDays(-5);
            DateTime TD = DateTime.Today;

            if ((Updatedate <= ForwardDate && Updatedate <= TD && Updatedate > TranDate) ||(Updatedate >= BackwardDate && Updatedate <= TD && Updatedate<TranDate) )
            {
               //  MessageBox.Show(Convert.ToDateTime(lblsysdate.Text).AddDays(+5).ToString());
                Save();
                EditTP();
                OutletSales();
                this.Close();
                //MessageBox.Show("You Have Successfully Save The Data. ", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(" Date Can not be Greater/Less Than 5 Days ","Warning !!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }        

        }
        private void Save()
        {

            if (this.Tag == null)
            {
                DMSUser oDMSUser = new DMSUser();
                MessageBox.Show("Invalid Date ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);   
            }
            else
            {

                DBController.Instance.OpenNewConnection();
                DMSUser oDMSUser = (DMSUser)this.Tag;

                oDMSUser.DistributorID = ctlCustomer1.SelectedCustomer.CustomerID;
                //oDMSUser.TranDate = dtFromDate.Value;
                //this.Tag = oDMSUser;

                try
                {

                    DBController.Instance.BeginNewTransaction();
                    oDMSUser.SalesTransactionData(dtFromDate.Value);
                    DBController.Instance.CommitTransaction();
                   
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");

                }

            }

        }
        private void EditTP()
        {
            
            if (this.Tag == null)
            {
                DMSUser oDMSUser = new DMSUser();

                MessageBox.Show("Invalid Date ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DBController.Instance.OpenNewConnection();
                DMSUser oDMSUser = (DMSUser)this.Tag;
                oDMSUser.DistributorID = ctlCustomer1.SelectedCustomer.CustomerID;
                //oDMSUser.TranDate = dtFromDate.Value;
                // Need to catch outlet ID
                //this.Tag = oDMSUser;
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oDMSUser.SalesTPTransactionData(dtFromDate.Value);
                    DBController.Instance.CommitTransaction();
                   
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");

                }

            }

        }
        private void OutletSales()
        {

            if (this.Tag == null)
            {
                DMSUser oDMSUser = new DMSUser();
                MessageBox.Show("Invalid Date ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DBController.Instance.OpenNewConnection();
                DMSUser oDMSUser = (DMSUser)this.Tag;
                oDMSUser.DistributorID = ctlCustomer1.SelectedCustomer.CustomerID;
                //oDMSUser.TranDate = dtFromDate.Value;
                //Need to catch outlet ID
                //this.Tag = oDMSUser;
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oDMSUser.OutletSalesTransactionData(dtFromDate.Value);
                    DBController.Instance.CommitTransaction();
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");

                }

            }

        }
        private void ctlCustomer1_Load_1(object sender, EventArgs e)
        {

        }
        private void frmSaledateCorrection_Load(object sender, EventArgs e)
        {

        }
    }
}
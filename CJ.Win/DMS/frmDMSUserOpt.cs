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
    public partial class frmDMSUserOpt : Form

    {
        private DSPermission _oDSPermission;

        private int _nCallCountUp = 0;
        private int _nCallCountDn = 0;
        private bool _bSuspended;
        private bool _bFlag;
        int nUserId;
        int nDistributorID;

        static string sUsername;
        public frmDMSUserOpt()
        {
            InitializeComponent();
        }


        public void ShowDialog(DMSUser oDMSUser)
        {


            ctlCustomer1.txtCode.Text = oDMSUser.Customer.CustomerCode;
            dtOptDate.Text = oDMSUser.NextOperationDate.ToString();

            this.Tag = oDMSUser;
            this.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            {
                Save();
                this.Close();
            }
        }

       

        private void Save()
        {

            DMSUser oDMSUser = new DMSUser();
            DMSUsers oDMSUsers = new DMSUsers();
            if (this.Tag != null)
            {

                DBController.Instance.OpenNewConnection();

                oDMSUser = new DMSUser();

                oDMSUser.DistributorID = ctlCustomer1.SelectedCustomer.CustomerID;
                oDMSUser.NextOperationDate = dtOptDate.Value;
                oDMSUser.OperationDate = dtOptDate.Value;
                oDMSUser.LastOperationDate = dtOptDate.Value.AddDays(-1);





                try
                {

                    DBController.Instance.BeginNewTransaction();

                    oDMSUser.SetOperationEndDate();

                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Save The Data. ", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");

                }
            }
            else
            {

                MessageBox.Show("Invalid Date ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void frmDMSUserOpt_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add a new User Information.";

            }
            else
            {
                this.Text = "Edit the User Information.";

            }

        }


    }
}

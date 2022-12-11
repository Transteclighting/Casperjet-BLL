using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.CAC
{
    public partial class frmCACProjectCollection : Form 
    {


        CACProjectCollection oCACProjectCollection;
        CACProjectCollections oCACProjectCollections;
        CACProjectCollectionSchedule oCACProjectCollectionSchedule;

        int nProjectID = 0;
        int nCustomerID = 0;
        double ntotalAmount = 0;


        public bool _bActionSave = false;
        public frmCACProjectCollection()
        {
            InitializeComponent();
        }

        private void CACProjectCollection_Load(object sender, EventArgs e)
        {
            LoadTranList();
        }

        public void ShowDialog(CACProject oCACProject)
        {
            this.Tag = oCACProject;
            nProjectID = oCACProject.ProjectID;
            txtProjectCode.Text = oCACProject.ProjectCode;
            txtProjectName.Text = oCACProject.ProjectName;
            nCustomerID = oCACProject.CustomerID;

            this.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validation())
            { 

                CACProjectCollection oCACProjectCollection = new CACProjectCollection();

                oCACProjectCollection.ProjectID = nProjectID;
                oCACProjectCollection.TranNo = txtCTNO.Text.ToString();
                oCACProjectCollection.Amount = Convert.ToDouble(txtAmount.Text.ToString());
                oCACProjectCollection.CreateUserID = Utility.UserId;
                oCACProjectCollection.CreateDate = DateTime.Now;

                try
                {
                    if (!DBController.Instance.CheckConnection())
                    {
                        DBController.Instance.OpenNewConnection();
                    }

                    DBController.Instance.BeginNewTransaction();
                    oCACProjectCollection.Add();
                    CACProject oCACProject = new CACProject();
                    oCACProject.TotalCollectionAmount = Convert.ToDouble(txtAmount.Text);
                    oCACProject.UpdateCollectionAmount(nProjectID);

                    CollectionDistribution();

                    DBController.Instance.CommitTran();

                    this.Close();

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

                MessageBox.Show("Your data has been saved successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }


        private void CollectionDistribution() {

            double totAmt = Convert.ToDouble(txtAmount.Text.ToString());

            CACProjectCollectionSchedules _oCACProjectCollectionSchedules = new CACProjectCollectionSchedules();

            _oCACProjectCollectionSchedules.GetDataBasedOnCollection(nProjectID);
            oCACProjectCollectionSchedule = new CACProjectCollectionSchedule();


            foreach (CACProjectCollectionSchedule _oCACProjectCollectionSchedule in _oCACProjectCollectionSchedules)
            {

                oCACProjectCollectionSchedule.ProjectID = _oCACProjectCollectionSchedule.ProjectID;
                oCACProjectCollectionSchedule.CollectionScheduleID = _oCACProjectCollectionSchedule.CollectionScheduleID;

                double _PayableAmount = _oCACProjectCollectionSchedule.Amount - _oCACProjectCollectionSchedule.Collection;

                if (totAmt > 0)
                {

                    if (_PayableAmount <= totAmt)
                    {
                        oCACProjectCollectionSchedule.IsFullCollect = (int)Dictionary.YesOrNoStatus.YES;
                        oCACProjectCollectionSchedule.Collection = _PayableAmount;
                        totAmt = totAmt - _PayableAmount;
                        oCACProjectCollectionSchedule.UpdateFromCollection();
                    }
                    else
                    {
                        oCACProjectCollectionSchedule.IsFullCollect = (int)Dictionary.YesOrNoStatus.NO;
                        oCACProjectCollectionSchedule.Collection = totAmt;
                        totAmt = 0;
                        oCACProjectCollectionSchedule.UpdateFromCollection();
                    }

                }
            }

            if (totAmt > 0)
            {
                MessageBox.Show("There is still collection amount exists", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        
        private bool validation()
        {
            if (Convert.ToDouble(txtAmount.Text.Trim()) <= 0)
            {
                MessageBox.Show("Please Fetch Collection Amount First", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return false;
            }

            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void LoadTranList()
        {
            this.Cursor = Cursors.WaitCursor;
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            oCACProjectCollections = new CACProjectCollections();
            lvwTransactionMap.Items.Clear();

            DBController.Instance.OpenNewConnection();
            oCACProjectCollections.RefreshByCollectionAmount(nProjectID);

            foreach (CACProjectCollection oCACProjectCollection in oCACProjectCollections)
            {
                ListViewItem oItem = lvwTransactionMap.Items.Add(oCACProjectCollection.TranNo);
                oItem.SubItems.Add(oCACProjectCollection.Amount.ToString());
                oItem.Tag = oCACProjectCollection;
            }
            grpTransactionMap.Text = " Total Transaction" + "-[" + oCACProjectCollections.Count + "]";
            this.Cursor = Cursors.Default;
            Total();
        }
        private void Total()
        {
            double value = 0;
            for (int i = 0; i < lvwTransactionMap.Items.Count; i++)
            {
                value += Convert.ToDouble(lvwTransactionMap.Items[i].SubItems[1].Text);
            }

            txtTotal.Text = value.ToString();
        }
        private void btnGet_Click(object sender, EventArgs e)
        {
            if (txtCTNO.Text == "")
            {
                MessageBox.Show("Please Enter CT No!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCTNO.Focus();
            }

            else {

                CACProjectCollection oCACProjectCollection = new CACProjectCollection();
                oCACProjectCollection.GetCACCProjectollectionAmount(txtCTNO.Text);
                oCACProjectCollection.TranNo = txtCTNO.Text.ToString();                                 
                if (nCustomerID == oCACProjectCollection.CustomerID)
                {
                    txtAmount.Text = oCACProjectCollection.Amount.ToString();
                    oCACProjectCollection.CustomerID = nCustomerID;
                }
                else
                {
                    MessageBox.Show("Please Input Valid Customer Tran#");
                }
            }
        }

    }
}

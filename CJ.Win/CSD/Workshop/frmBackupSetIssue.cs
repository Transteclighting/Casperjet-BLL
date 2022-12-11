using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;

namespace CJ.Win.CSD.Workshop
{
    public partial class frmBackupSetIssue : Form
    {
        CSDBackupProducts _oCSDBackupProducts; 
        CSDJob _oCSDJob;
        CSDBackupProductTran _oCSDBackupProductTran;
        CSDBackupProduct oCSDBackupProduct;
        bool bHaveBackupSet = false;
        public frmBackupSetIssue()
        {
            InitializeComponent();
        }
        public void ShowDialog(CSDBackupProduct oCSDBackupProduct)
        {
            txtBackupSetID.Text = oCSDBackupProduct.BackUpProductID.ToString();
            txtProductCode.Text = oCSDBackupProduct.ProductCode;
            txtProductName.Text = oCSDBackupProduct.ProductName;
            this.Tag = oCSDBackupProduct;
            this.ShowDialog();
        }
        private void frmBackupSetTran_Load(object sender, EventArgs e)
        {
             
        }
        private void DataLoadControl()
        {
            //int nProductID = -1;
            //if (ctlProducts1.txtDescription.Text != string.Empty)
            //{
            //    nProductID = ctlProducts1.SelectedSerarchProduct.ProductID;
            //}

            //DBController.Instance.OpenNewConnection();
            //_oCSDBackupProducts = new CSDBackupProducts();
            //lvwBackupSet.Items.Clear();
            //DBController.Instance.OpenNewConnection();
            //_oCSDBackupProducts.GetData(nProductID);
            //this.Text = "CSD Backup Product | Total: " + "[" + _oCSDBackupProducts.Count + "]";
            //foreach (CSDBackupProduct oCSDBackupProduct in _oCSDBackupProducts)
            //{
            //    ListViewItem oItem = lvwBackupSet.Items.Add(oCSDBackupProduct.BackUpProductID.ToString());
            //    oItem.SubItems.Add(oCSDBackupProduct.ProductCode);
            //    oItem.SubItems.Add(oCSDBackupProduct.ProductName);
            //    oItem.Tag = oCSDBackupProduct;
            //}
        }

        private void btnSearchBackupSet_Click(object sender, EventArgs e)
        {

        }

        //private void lvwBackupSet_DoubleClick(object sender, EventArgs e)
        //{
        //    CSDBackupProduct oCSDBackupProduct = (CSDBackupProduct)lvwBackupSet.SelectedItems[0].Tag;
        //    txtBackupSetID.Text = oCSDBackupProduct.BackUpProductID.ToString();
        //    txtProductCode.Text = oCSDBackupProduct.ProductCode;
        //    txtProductName.Text = oCSDBackupProduct.ProductName;

        //}
        private bool ValidateUIInput()
        {
            if (ctlCSDJob1.txtDescription.Text == string.Empty)
            {
                if (ctlCSDJob1.txtCode.Text != string.Empty)
                {
                    MessageBox.Show("Please Enter Valid Job No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Please Select Job/Enter Job No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return false;

            }
            
           
            if (txtBackupSetID.Text == string.Empty || txtProductCode.Text == string.Empty || txtProductName.Text == string.Empty)
            {
                MessageBox.Show("Please Select A Backup Product.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            
            return true;
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (ValidateUIInput())
            {
                IssueCSDBackupSet();
                if (!bHaveBackupSet)
                {
                    this.Close();
                }
                
            }
            
        }
        private void IssueCSDBackupSet()
        {
            DBController.Instance.OpenNewConnection();
            _oCSDJob = new CSDJob();
            _oCSDJob.JobID = ctlCSDJob1.SelectedJob.JobID;

            if (!_oCSDJob.HaveBackupProduct())
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        UpdateHaveBackupSetToYes();
                        AssignCSDBackupProduct();
                        AddCSDBackupProductTran();
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Successfully Issue a Backup Product for Job# " + ctlCSDJob1.SelectedJob.JobNo, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                }
                else
                {
                    MessageBox.Show("This Job has Already a Backup Product.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    bHaveBackupSet = true;  
                }

                       
        }
        private void AddCSDBackupProductTran()
        {
            _oCSDBackupProductTran = new CSDBackupProductTran();
            _oCSDBackupProductTran.BackupProductID = oCSDBackupProduct.BackUpProductID;
            _oCSDBackupProductTran.JobID = ctlCSDJob1.SelectedJob.JobID;
            _oCSDBackupProductTran.TranType = (int)Dictionary.CSDBackupProductTranType.Issue;
            _oCSDBackupProductTran.CreateUserID = Utility.UserId;
            _oCSDBackupProductTran.CreateDate = DateTime.Now;
            _oCSDBackupProductTran.Add();
        }
        private void UpdateHaveBackupSetToYes()
        {
            _oCSDJob = new CSDJob();
            _oCSDJob.JobID = ctlCSDJob1.SelectedJob.JobID;
            _oCSDJob.UpdateHaveBackupSetToYes();
        }
        private void AssignCSDBackupProduct()
        {
            oCSDBackupProduct = new CSDBackupProduct();
            oCSDBackupProduct.BackUpProductID = Convert.ToInt32(txtBackupSetID.Text);
            oCSDBackupProduct.JobID = ctlCSDJob1.SelectedJob.JobID;
            oCSDBackupProduct.AssignCSDBackupProduct();
        }

    }
}
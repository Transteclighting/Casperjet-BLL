using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;
using CJ.Report;
using CJ.Report.CSD;
using CJ.Win.CSD.Reception;

namespace CJ.Win.CSD.Workshop
{
    public partial class frmBackupSet : Form
    {
        CSDJob _oCSDJob;
        CSDBackupProduct _oCSDBackupProduct;
        CSDBackupProductTran _oCSDBackupProductTran;
        CSDBackupProducts _oCSDBackupProducts;
        ProductDetail _oProductDetail;
        public frmBackupSet()
        {
            InitializeComponent();
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            //if (ctlCSDJob1.txtDescription.Text !=string.Empty)
            //{
            //    if (HaveBackupSet())
            //    {
            //        MessageBox.Show("Job No:"+ctlCSDJob1.txtCode.Text+" Has Already a Backupset",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            //        return;
            //    }
                
            //}
           
             DataLoadControl();
                                 
        }
        private bool HaveBackupSet()
        {
            DBController.Instance.OpenNewConnection();
            _oCSDJob = new CSDJob();
            _oCSDJob.JobID = ctlCSDJob1.SelectedJob.JobID;
            return _oCSDJob.HaveBackupProduct();
        }
        private void DataLoadControl()
        {
            int nProductID = -1;
            if (ctlProduct1.txtDescription.Text != string.Empty)
            {
                nProductID = ctlProduct1.SelectedSerarchProduct.ProductID;
            }
            int nJobID = -1;
            if (ctlCSDJob1.txtDescription.Text != string.Empty)
            {
                nJobID = ctlCSDJob1.SelectedJob.JobID;
            }
            
            DBController.Instance.OpenNewConnection();
            _oCSDBackupProducts = new CSDBackupProducts();
            lvwBackupSet.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oCSDBackupProducts.GetData(nProductID, nJobID,chkUassignProduct.Checked);
            this.Text = "CSD Backup Product | Total: " + "[" + _oCSDBackupProducts.Count + "]";
            foreach (CSDBackupProduct CSDBackupProduct in _oCSDBackupProducts)
            {
                ListViewItem oItem = lvwBackupSet.Items.Add(CSDBackupProduct.BackUpProductID.ToString());
                oItem.SubItems.Add(CSDBackupProduct.ProductCode);
                oItem.SubItems.Add(CSDBackupProduct.BackupProductSerial);
                oItem.SubItems.Add(CSDBackupProduct.ProductName);
                oItem.SubItems.Add(CSDBackupProduct.JobNo);
                oItem.Tag = CSDBackupProduct;

            }
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            IssueBackupSet();
        }
        private void IssueBackupSet()
        {
            if (lvwBackupSet.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _oCSDBackupProduct = (CSDBackupProduct)lvwBackupSet.SelectedItems[0].Tag;
            if (_oCSDBackupProduct.JobID != 0)
            {
                MessageBox.Show("This Product Already is Issued for Job# " + _oCSDBackupProduct.JobNo, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            frmBackupSetIssue oForm = new frmBackupSetIssue();
            oForm.ShowDialog(_oCSDBackupProduct);
            DataLoadControl();
        }
        private void btnReturn_Click(object sender, EventArgs e)
        {
            ReturnBackupSet();
        }
        private void ReturnBackupSet()
        {
            if (lvwBackupSet.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CSDBackupProduct oCSDBackupProduct = (CSDBackupProduct)lvwBackupSet.SelectedItems[0].Tag;
            if (oCSDBackupProduct.JobID == 0)
            {
                MessageBox.Show("This Product is't Assign Yet.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            { 
                 DialogResult oResult = MessageBox.Show("Are You Sure to Return Backup Product From Job#:" + oCSDBackupProduct.JobNo, "Return Backup Product", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                 if (oResult == DialogResult.Yes)
                 {
                     try
                     {
                         _oCSDJob = new CSDJob();
                         _oCSDJob.JobID = oCSDBackupProduct.JobID;
                         _oCSDBackupProduct = new CSDBackupProduct();
                         _oCSDBackupProduct.BackUpProductID = oCSDBackupProduct.BackUpProductID;
                         _oCSDBackupProduct.JobID = 0;
                         _oCSDBackupProductTran = new CSDBackupProductTran();
                         _oCSDBackupProductTran.BackupProductID = oCSDBackupProduct.BackUpProductID;
                         _oCSDBackupProductTran.JobID = oCSDBackupProduct.JobID;
                         _oCSDBackupProductTran.TranType = (int)Dictionary.CSDBackupProductTranType.Return;
                         _oCSDBackupProductTran.CreateUserID = Utility.UserId;
                         _oCSDBackupProductTran.CreateDate = DateTime.Now;
   
                         DBController.Instance.OpenNewConnection();
                         DBController.Instance.BeginNewTransaction();
                         _oCSDJob.UpdateHaveBackupSetToNo();
                         _oCSDBackupProduct.AssignCSDBackupProduct();
                         _oCSDBackupProductTran.Add();
                         DBController.Instance.CommitTransaction();
                     }
                     catch (Exception ex)
                     {
                         DBController.Instance.RollbackTransaction();
                         MessageBox.Show(ex.Message, "Error!!!");
                     }


                 }
            }
            
            DataLoadControl();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintBackupProductFrm();
        }
        private void PrintBackupProductFrm()
        {            
            if (lvwBackupSet.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _oCSDBackupProduct = (CSDBackupProduct)lvwBackupSet.SelectedItems[0].Tag;
            if (_oCSDBackupProduct.JobID == 0)
            {
                MessageBox.Show("This Backup Product Is Unassigned", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            
            _oCSDJob = new CSDJob();
            _oCSDJob.JobID = _oCSDBackupProduct.JobID;
            _oCSDJob.Refresh();

            //_oProductDetail = new ProductDetail();
            //_oProductDetail.ProductID = _oCSDJob.ProductID;
            //_oProductDetail.Refresh();


            rptBackupProductSupportFrm doc = new rptBackupProductSupportFrm();
            doc.SetParameterValue("JobNo", _oCSDBackupProduct.JobNo);
            doc.SetParameterValue("BPName", _oCSDBackupProduct.ProductName);
            doc.SetParameterValue("BPSerial", _oCSDBackupProduct.BackupProductSerial);
            doc.SetParameterValue("BPModel", _oCSDBackupProduct.ProductModel);
            doc.SetParameterValue("BPBrand", _oCSDBackupProduct.BrandDesc);

            doc.SetParameterValue("CustomerName", _oCSDJob.CustomerName);
            doc.SetParameterValue("CustomerAddress", _oCSDJob.CustomerAddress);
            doc.SetParameterValue("CustomerMobile", _oCSDJob.MobileNo);
            doc.SetParameterValue("CustomerPhone", _oCSDJob.TelePhone);

            doc.SetParameterValue("CPName", _oCSDBackupProduct.ProductName);
            doc.SetParameterValue("CPSerial", _oCSDBackupProduct.BackupProductSerial);
            doc.SetParameterValue("CPModel", _oCSDBackupProduct.ProductModel);
            doc.SetParameterValue("CPBrand", _oCSDBackupProduct.BrandDesc);
            doc.SetParameterValue("PrintUser", Utility.Username);
           
            frmPrintPreview frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
            this.Cursor = Cursors.Default;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmBackupProducts ofrmBackupProducts = new frmBackupProducts();
            ofrmBackupProducts.ShowDialog();
            DataLoadControl();
        }
    }
}
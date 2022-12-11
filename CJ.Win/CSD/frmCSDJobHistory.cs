using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;

namespace CJ.Win.CSD
{
    public partial class frmCSDJobHistory : Form
    {
        CSDJob _oCSDJob;
        ProductDetail _oProductDetail;
        JobHistory _oJobHistory;
        JobHistorys _oJobHistorys;
        public frmCSDJobHistory()
        {
            InitializeComponent();
        }
        public void ShowDialog(CSDJob oCSDJob)
        {
            this.Tag = oCSDJob;
            _oProductDetail = new ProductDetail();
            _oProductDetail.ProductID = oCSDJob.ProductID;
            _oProductDetail.Refresh();

            txtName.Text = _oProductDetail.ProductName + " [" + _oProductDetail.ProductCode + "]";
            txtJobNumber.Text = oCSDJob.JobNo;
            txtModelNo.Text = oCSDJob.MobileNo;
            txtCustomerName.Text = oCSDJob.CustomerName;
            this.ShowDialog();            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCSDJobHistory_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void DataLoadControl()
        {
            CSDJob oCSDJob = (CSDJob)this.Tag;
            DBController.Instance.OpenNewConnection();
            _oJobHistorys = new JobHistorys();
            lvwJoHistory.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oJobHistorys.RefreshByID(oCSDJob.JobID);
            this.Text = "CSD Job History | Total: " + "[" + _oJobHistorys.Count + "]";
            foreach (JobHistory oJobHistory in _oJobHistorys)
            {
                ListViewItem oItem = lvwJoHistory.Items.Add(oJobHistory.CreateDate.ToShortDateString() +" "+oJobHistory.CreateDate.ToShortTimeString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.JobStatus), oJobHistory.StatusID));
                oItem.SubItems.Add(oJobHistory.SubStatusName);
                oItem.SubItems.Add(oJobHistory.UserName);
                oItem.SubItems.Add(oJobHistory.Remarks);
                oItem.Tag = oJobHistory;
            }
        }
    }
}
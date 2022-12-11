using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Duty;

namespace CJ.Win
{
    public partial class frmInsertCassiopeiaTransfer : Form
    {
        ProductStockTrans _oCasperTranList;
        ProductStockTrans _oSRTranList;
        ProductStockTrans _oSimilarTranList;
        DutyTran oDutyTranVAT11;
        DutyTran oDutyTranVAT11KA;      
        ProductDetail _oProductDetail;

        double _DutyBalance = 0;

        public frmInsertCassiopeiaTransfer()
        {
            InitializeComponent();
        }

        private void frmInsertCassiopeiaTransfer_Load(object sender, EventArgs e)
        {
            _oCasperTranList = new ProductStockTrans();
            _oSRTranList = new ProductStockTrans();
            _oSimilarTranList = new ProductStockTrans();
        }
        private void RefreshCassiList()
        {
            int nSRID = 0;
            ProductStockTrans oProductStockTrans = new ProductStockTrans();
            oProductStockTrans.RefreshSRTranList(dtpFrom.Value.AddDays(0), dtpTo.Value.AddDays(1));
            this.Tag = oProductStockTrans;
            lvwSRTran.Items.Clear();
            foreach (ProductStockTran oProductStockTran in oProductStockTrans)
            {
                ListViewItem lstItem = lvwSRTran.Items.Add(oProductStockTran.TranNo);
                lstItem.SubItems.Add(oProductStockTran.TranDate.ToString());
                lstItem.SubItems.Add(oProductStockTran.TranTypeName);
                lstItem.SubItems.Add(oProductStockTran.Remarks);
                //lstItem.SubItems.Add(oProductStockTran.Remarks);
                //lstItem.SubItems.Add(oProductStockTran.FromWarehouse);
                //lstItem.SubItems.Add(oProductStockTran.ToWarehouse);

                lstItem.Tag = oProductStockTran;
            }

            if (lvwSRTran.Items.Count > 0)
            {
                lvwSRTran.Items[0].Selected = true;
                lvwSRTran.Focus();
            }
            lblSCount.Text = "[ " + oProductStockTrans.Count.ToString() + " ]";
            _oSRTranList = oProductStockTrans;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void dtpFrom_ValueChanged(object sender, EventArgs e)
        {

        }
        private void dtpTo_ValueChanged(object sender, EventArgs e)
        {

        }
        private void btnGet_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            this.RefreshCassiList();
            this.Cursor = Cursors.Arrow;
        }
        private void btnInsertCassiopeiaTransfer_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            int nCassiTranID = 0;
            int nSRID = 0;
            ProductStockTran oCassi = new ProductStockTran();
            ProductStockTrans oSaveTran = new ProductStockTrans();
            for (int i = 0; i < lvwSRTran.SelectedItems.Count; i++)
            {
                oCassi = (ProductStockTran)lvwSRTran.SelectedItems[i].Tag;
                nCassiTranID = oCassi.TranID;
                nSRID = oCassi.SRID;
            }

            bool bResult = false;
            bResult = oSaveTran.InsertISGMIntoCasper(oCassi);
         

            if (bResult == true)// if success
            {
                MessageBox.Show("Product Tansfer Inserted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Cursor = Cursors.Arrow;
                return;
            }
            else// if failed
            {
                MessageBox.Show("Duplicate TranNo or Database Error.\nProduct Tansfer Insertion Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Cursor = Cursors.Arrow;
                return;
            }
            this.RefreshCassiList();
            this.Cursor = Cursors.Arrow;
            return;
        }
      
    }
}
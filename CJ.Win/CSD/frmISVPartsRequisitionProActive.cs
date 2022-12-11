using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.CSD;
using CJ.Class;
using CJ.Class.Report;
using CJ.Win.Security;
using CJ.Report.CSD;
using CJ.Report;

namespace CJ.Win
{
    public partial class frmISVPartsRequisitionProActive : Form
    {
        public frmISVPartsRequisitionProActive()
        {
            InitializeComponent();
        }

        private void DataLoadControl()
        {
            

            ISVSpareCommunications oISVSpareCommunications = new ISVSpareCommunications();

            oISVSpareCommunications.RefreshProActiveData();

            lvwProActive.Items.Clear();

            //foreach (SparePartsTransactionDetail _oSparePartsTransactionDetail in oSparePartsTransactions)

                foreach(ISVSpareCommunication oISVSpareCommunication in oISVSpareCommunications)
            {
                ListViewItem oItem = lvwProActive.Items.Add(oISVSpareCommunication.SparePartsTransactionDetail.ISVRequisitionID.ToString());
                oItem.SubItems.Add(oISVSpareCommunication.SpareParts.Code.ToString());
                oItem.SubItems.Add(oISVSpareCommunication.SpareParts.Name.ToString());
                oItem.SubItems.Add(oISVSpareCommunication.SparePartsTransactionDetail.ClaimQty.ToString());
                oItem.SubItems.Add(oISVSpareCommunication.ReplaceJobFromCassandra.JobNo.ToString());
                oItem.SubItems.Add(oISVSpareCommunication.SparePartsTransactionDetail.SubStatusName.ToString());
                oItem.SubItems.Add(oISVSpareCommunication.EDD.ToString());

                //oItem.Tag = _oSparePartsTransaction;
            }
            //setListViewRowColour();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmISVPartsRequisitionProActive_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }
    }
}
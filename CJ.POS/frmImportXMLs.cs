using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using CJ.Class;

namespace CJ.POS
{
    public partial class frmImportXMLs : Form
    {
        PromoXMLs _oPromoXMLs;
        bool IsCheck = false;
        public frmImportXMLs()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmImportXML oForm = new POS.frmImportXML();
            oForm.ShowDialog();
            DataLoadControl();
        }

        private void DataLoadControl()
        {
            _oPromoXMLs = new PromoXMLs();
            lvwItemList.Items.Clear();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            if (chkAll.Checked == true)
            {
                IsCheck = true;
            }
            else
            {
                IsCheck = false;
            }


            _oPromoXMLs.RefreshforPOS(dtFromDate.Value.Date, dtToDate.Value.Date, txtFileName.Text.Trim(), IsCheck);
            this.Text = "Total  " + "[" + _oPromoXMLs.Count + "]";

            foreach (PromoXML oPromoXML in _oPromoXMLs)
            {
                ListViewItem oItem = lvwItemList.Items.Add(oPromoXML.Id.ToString());
                oItem.SubItems.Add(oPromoXML.CreateDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oPromoXML.Type);
                oItem.SubItems.Add(oPromoXML.FileName);
                oItem.SubItems.Add(oPromoXML.Description);
                oItem.SubItems.Add(oPromoXML.UserFullName);

                oItem.Tag = oPromoXML;
            }

        }

        private void btGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void frmImportXMLs_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

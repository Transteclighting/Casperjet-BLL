using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TEL.SMS.BO.DA;
using TEL.SMS.BO.BE;
using System.Configuration;

namespace TEL.SMS.UI.Win
{
    public partial class frmRptShowroomStock : Form
    {
        DSShowroom _oDSShowroom = new DSShowroom();
        string _sXmlPath;
       
        public frmRptShowroomStock()
        {
            InitializeComponent();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //int a;
            //a = (int)cboShowroom.SelectedValue;
            DAProduct oDAProduct = new DAProduct();
            this.Cursor=Cursors.WaitCursor;
            
            this.Cursor = Cursors.Default;
            frmReportViewer oReportViewer = new frmReportViewer();
            ShowroomStockReport oReport = new ShowroomStockReport();
            oReport.SetParameterValue("WarehouseID", cboShowroom.SelectedValue);
            oReportViewer.ReportRefersh(oReport);
            oReportViewer.Show();

        }

        private void frmRptShowroomStock_Load(object sender, EventArgs e)
        {
            GetShowroom();
            cboShowroom.Items.Clear();
            //cboShowroom.Items.Add("<ALL Status>");

            //foreach (DSShowroom.ShowroomRow oShowroomRow in _oDSShowroom.Showroom)
            //{
            //    cboShowroom.Items.Add(oShowroomRow.SRName);
            //    //cboShowroom.Items.IndexOf(oShowroomRow.SRID);
            //    cboShowroom.SelectedValue = oShowroomRow.SRID;
            //    cboShowroom.va
            //    //cboShowroom.DisplayMember = _oDSShowroom.Showroom.Columns["SRName"].ToString(); 
            //}
            cboShowroom.DataSource = _oDSShowroom.Showroom ;
            cboShowroom.ValueMember = "SRID";
            //cboShowroom.ValueMember  = _oDSShowroom.Showroom.Columns["SRID"].ToString();
            cboShowroom.DisplayMember = _oDSShowroom.Showroom.Columns["SRName"].ToString(); 
        }
        void GetShowroom()
        {
            _sXmlPath = ConfigurationManager.AppSettings["SRList"];
            _oDSShowroom.ReadXml(_sXmlPath);
        }

        private void cboShowroom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TEL.BE;
using TEL.Common;
using TEL.BE.Reports;
using System.Text.RegularExpressions;
using TEL.Report;
using System.Configuration;
//using TEL.SMS.BO.DA;
using TEL.Library;

namespace TEL.SMS.UI.Win
{
    public partial class frmCollectionsThroughSMS : Form
    {
        DataSet _oDSCollectionData;
        DateTime _dStartDate;
        DateTime _dEndDate;

        public frmCollectionsThroughSMS()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            
            _dStartDate = new DateTime();
            _dEndDate = new DateTime();
            
            _dStartDate = dtFrom.Value;
            _dEndDate = dtTo.Value;

            loadData();

            dgvData.DataSource = _oDSCollectionData;
            dgvData.DataMember = _oDSCollectionData.Tables[0].TableName;
        }
        private void loadData()
        {
            string sQueryString;
            string sConnString;
            DateTime oEndDate;//add 1 day for Query

            oEndDate = new DateTime();
            oEndDate = _dEndDate;
            oEndDate = oEndDate.AddDays(1);
            _oDSCollectionData = new DataSet();
            //sConnString = ConfigurationSettings.AppSettings["ConnectionStringMDB"];
            sConnString = ConfigurationManager.AppSettings["ConnectionString"];
            //scc = ConfigurationManager.AppSettings
            //Getting Order Master Information

            sQueryString = "SELECT    t_Customer.CustomerCode, t_Customer.CustomerName , t_MobilePhone.PersonName , t_SMSDailyTargetSalesCollection.MobileNo," +
                            " t_SMSDailyTargetSalesCollection.Target, t_SMSDailyTargetSalesCollection.Sales, t_SMSDailyTargetSalesCollection.CollectionElectrical, " +
                            " t_SMSDailyTargetSalesCollection.CollectionGrocery, t_SMSDailyTargetSalesCollection.Date as CollectionDate " +
                            " FROM         t_SMSDailyTargetSalesCollection left outer join " +
                            " t_MobilePhone ON t_SMSDailyTargetSalesCollection.MobileNo = t_MobilePhone.MobileNo inner join " +
                            " t_Customer ON t_SMSDailyTargetSalesCollection.CustomerID = t_Customer.CustomerCode and  t_SMSDailyTargetSalesCollection.Date  between '" +  _dStartDate.ToShortDateString() + "' and '" + oEndDate.ToShortDateString()+ "'" ;

            OleDbConnection oConn = new OleDbConnection(sConnString);

            try
            {
                OleDbDataAdapter da = new OleDbDataAdapter(sQueryString, oConn);
                da.Fill(_oDSCollectionData);
                oConn.Close();
                this.Text = this.Text + "[Total Collection: " + _oDSCollectionData.Tables[0].Rows.Count.ToString() + "]";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }
        }
        private void showReport()
        {
            DSCollectionThroughSMS oDSCollectionThroughSMS;
            oDSCollectionThroughSMS = new DSCollectionThroughSMS();
            foreach (DataRow oRow in _oDSCollectionData.Tables[0].Rows)
            {
                DSCollectionThroughSMS.CollectionThroughSMSRow oCollRow = oDSCollectionThroughSMS.CollectionThroughSMS.NewCollectionThroughSMSRow();
                if(oRow["CustomerCode"] != null)
                {
                    oCollRow.CustomerCode = oRow["CustomerCode"].ToString();
                    oCollRow.CustomerName = oRow["CustomerName"].ToString();
                }
                if (oRow["PersonName"] != null)
                {
                    oCollRow.PersonName = oRow["PersonName"].ToString();
                }
                if (oRow["MobileNo"] != null)
                {
                    oCollRow.MobileNo = oRow["MobileNo"].ToString();
                }
                if (oRow["CollectionDate"] != null)
                {
                    oCollRow.CollectionDate = Convert.ToDateTime( oRow["CollectionDate"]);
                }
                if (oRow["Sales"] != null)
                {
                    oCollRow.Sales = Convert.ToDouble( oRow["Sales"]);
                }
                if (oRow["Target"] != null)
                {
                    oCollRow.Target = Convert.ToDouble( oRow["Target"]);
                }
                if (oRow["CollectionElectrical"] != null)
                {
                    oCollRow.CollectionElectrical = Convert.ToDouble( oRow["CollectionElectrical"]);
                }
                if (oRow["CollectionGrocery"] != null)
                {
                    oCollRow.CollectionGrocery = Convert.ToDouble( oRow["CollectionGrocery"]);
                }
                oDSCollectionThroughSMS.CollectionThroughSMS.AddCollectionThroughSMSRow(oCollRow);
            }
            oDSCollectionThroughSMS.AcceptChanges();

            rptDailyCollectionsThroughSMS oRptDailyCollectionsThroughSMS;
            oRptDailyCollectionsThroughSMS = new rptDailyCollectionsThroughSMS();
            oRptDailyCollectionsThroughSMS.SetDataSource(oDSCollectionThroughSMS);
            frmReportViewer oReportViewer = new frmReportViewer();
            oRptDailyCollectionsThroughSMS.SetParameterValue("StartDate", _dStartDate);
            oRptDailyCollectionsThroughSMS.SetParameterValue("EndDate", _dEndDate);
            oRptDailyCollectionsThroughSMS.SetParameterValue("ReportName", "Daily Collections Through SMS");
            oReportViewer.ShowDialog(oRptDailyCollectionsThroughSMS);
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {

            showReport();
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
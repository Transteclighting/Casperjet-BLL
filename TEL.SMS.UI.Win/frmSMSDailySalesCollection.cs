using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TEL.BE;
using TEL.BO;
using TEL.Common;
using TEL.BE.Reports;
using System.Text.RegularExpressions;
using TEL.Report;
using System.Configuration;
using TEL.Library;
using TEL.SMS.Reports;
using TEL.SMS.BO.BE;

namespace TEL.SMS.UI.Win 
{
    public partial class frmSMSDailySalesCollection : Form
    {
        DataSet _oDSCollectionData;
        DateTime _dStartDate;
        DateTime _dEndDate;
        DSUser _oDSUser;

        public frmSMSDailySalesCollection()
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
            sConnString = ConfigurationManager.AppSettings["ConnectionString"];

            sQueryString = "SELECT t_Customer.CustomerCode, t_Customer.CustomerName , t_MobilePhone.PersonName ," +
                           "t_SMSDailySalesCollectionExpense.TranDate, " +//  as CollectionDate 
                           "t_SMSDailySalesCollectionExpense.MobileNo, t_SMSDailySalesCollectionExpense.Sales, " +
                           "t_SMSDailySalesCollectionExpense.Collection, t_SMSDailySalesCollectionExpense.TradePromotion, " +
                           "t_SMSDailySalesCollectionExpense.SellingExpense, t_SMSDailySalesCollectionExpense.Replacement " +
                           "FROM t_SMSDailySalesCollectionExpense " +
                           "left outer join t_MobilePhone ON t_SMSDailySalesCollectionExpense.MobileNo = t_MobilePhone.MobileNo " +
                           "inner join t_Customer ON t_SMSDailySalesCollectionExpense.CustomerID = t_Customer.CustomerCode " +
                           "and t_SMSDailySalesCollectionExpense.TranDate  between '"+ _dStartDate.ToShortDateString() +
                           "'  and '" + oEndDate.ToShortDateString() + "' ORDER BY t_SMSDailySalesCollectionExpense.TranDate ASC";

            OleDbConnection oConn = new OleDbConnection(sConnString);
            string sCaption = string.Empty;
            string sText = "SMS Daily Sales Collection";
            string sFormText = string.Empty;
            try
            {
                OleDbDataAdapter da = new OleDbDataAdapter(sQueryString, oConn);
                _oDSCollectionData.Clear();
                da.Fill(_oDSCollectionData, "SMSDailySalesCollectionExpense");
                oConn.Close();
                sCaption = "  [Total Collection(s) by SMS: " + _oDSCollectionData.Tables[0].Rows.Count.ToString() + "]";
                sFormText = sText + sCaption;
                this.Text = sFormText;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An Error occured when trying to Load Data.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void showReport()
        {
            DSSMSDailySalesCollection oDSSMSDailySalesCollection;
            oDSSMSDailySalesCollection = new DSSMSDailySalesCollection();
            foreach (DataRow oRow in _oDSCollectionData.Tables[0].Rows)
            {
                DSSMSDailySalesCollection.SMSDailySalesCollectionRow oCollRow = oDSSMSDailySalesCollection.SMSDailySalesCollection.NewSMSDailySalesCollectionRow();
                if(oRow["CustomerCode"] != null)
                {
                    oCollRow.CustomerCode = oRow["CustomerCode"].ToString();
                    oCollRow.CustomerName = oRow["CustomerName"].ToString();
                }
                if (oRow["PersonName"] != null)
                {
                    oCollRow.PersonName = oRow["PersonName"].ToString();
                }
                if (oRow["TranDate"] != null)
                {
                    oCollRow.TranDate = Convert.ToDateTime(oRow["TranDate"]);
                }
                if (oRow["MobileNo"] != null)
                {
                    oCollRow.MobileNo = oRow["MobileNo"].ToString();
                }
                if (oRow["Sales"] != null)
                {
                    oCollRow.Sales = Convert.ToDouble( oRow["Sales"]);
                }
                if (oRow["Collection"] != null)
                {
                    oCollRow.Collection = Convert.ToDouble(oRow["Collection"]);
                }
                if (oRow["TradePromotion"] != null)
                {
                    oCollRow.TradePromotion = Convert.ToDouble(oRow["TradePromotion"]);
                }
                if (oRow["SellingExpense"] != null)
                {
                    oCollRow.SellingExpense = Convert.ToDouble(oRow["SellingExpense"]);
                }
                if (oRow["Replacement"].ToString() == "")
                {
                    oCollRow.Replacement = Convert.ToDouble(0);
                }
                else//if (oRow["Replacement"] != null)
                {
                    oCollRow.Replacement = Convert.ToDouble(oRow["Replacement"].ToString());
                }
                oDSSMSDailySalesCollection.SMSDailySalesCollection.AddSMSDailySalesCollectionRow(oCollRow);
            }
            oDSSMSDailySalesCollection.AcceptChanges();

            rptSMSDailySalesCollectionExpense oRptSMSDailySalesCollectionExpense;
            oRptSMSDailySalesCollectionExpense = new rptSMSDailySalesCollectionExpense();
            oRptSMSDailySalesCollectionExpense.SetDataSource(oDSSMSDailySalesCollection);
            
            frmReportViewer oReportViewer = new frmReportViewer();

            oRptSMSDailySalesCollectionExpense.SetParameterValue("StartDate", _dStartDate);
            oRptSMSDailySalesCollectionExpense.SetParameterValue("EndDate", _dEndDate);
            oRptSMSDailySalesCollectionExpense.SetParameterValue("PrintedBy", _oDSUser.User[0].UserName.ToString());
            oReportViewer.ShowDialog(oRptSMSDailySalesCollectionExpense);
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            showReport();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmSMSDailySalesCollection_Load(object sender, EventArgs e)
        {
            _oDSUser = new DSUser();
            _oDSUser = BOUtility.CurrentUser;
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
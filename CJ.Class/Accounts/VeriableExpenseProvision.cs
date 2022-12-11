using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.Accounts
{
    public class VeriableExpenseProvision
    {
        private int _nID;
        private string _sDescription;
        private int _nSalesType;
        private double _fValuePercentage;
        private DateTime _dFromDate;
        private DateTime _dToDate;


        // <summary>
        // Get set property for EMITenureID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for Tenure
        // </summary>
        public string Description
        {
            get { return _sDescription; }
            set { _sDescription = value; }
        }

        // <summary>
        // Get set property for Status
        // </summary>
        public int SalesType
        {
            get { return _nSalesType; }
            set { _nSalesType = value; }
        }

        // <summary>
        // Get set property for CreateUserID
        // </summary>
        public double ValuePercentage
        {
            get { return _fValuePercentage; }
            set { _fValuePercentage = value; }
        }

        // <summary>
        // Get set property for CreateDate
        // </summary>
        public DateTime FromDate
        {
            get { return _dFromDate; }
            set { _dFromDate = value; }
        }

        // <summary>
        // Get set property for ApproveUserID
        // </summary>
        public DateTime ToDate
        {
            get { return _dToDate; }
            set { _dToDate = value; }
        }

       

        public void Add(string sBusinessType)
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                if (sBusinessType == "TEL")
                {
                    sSql = "SELECT MAX([ID]) FROM [DWDB].[dbo].t_TELMCAnalysisSettings";
                }
                else if (sBusinessType == "HO")
                {
                    sSql = "SELECT MAX([ID]) FROM [DWDB].[dbo].t_TELMCAnalysisSettingsHO";
                }
                else if (sBusinessType == "TML")
                {
                    sSql = "SELECT MAX([ID]) FROM [DWDB].[dbo].t_TELMCAnalysisSettingsMobile";
                }
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxID = 1;
                }
                else
                {
                    nMaxID = Convert.ToInt32(maxID) + 1;
                }
                _nID = nMaxID;
                if (sBusinessType == "TEL")
                {
                    sSql = "INSERT INTO [DWDB].[dbo].t_TELMCAnalysisSettings (ID, Description, SalesType, ValuePercentage, FromDate, Todate) VALUES(?,?,?,?,?,?)";
                }
                else if (sBusinessType == "HO")
                {
                    sSql = "INSERT INTO [DWDB].[dbo].t_TELMCAnalysisSettingsHO (ID, Description, SalesType, ValuePercentage, FromDate, Todate) VALUES(?,?,?,?,?,?)";
                }
                else if (sBusinessType == "TML")
                {
                    sSql = "INSERT INTO [DWDB].[dbo].t_TELMCAnalysisSettingsMobile (ID, Description, SalesType, ValuePercentage, FromDate, Todate) VALUES(?,?,?,?,?,?)";
                }
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("Description", _sDescription);
                cmd.Parameters.AddWithValue("SalesType", _nSalesType);
                cmd.Parameters.AddWithValue("ValuePercentage", _fValuePercentage);
                cmd.Parameters.AddWithValue("FromDate", _dFromDate);
                cmd.Parameters.AddWithValue("Todate", _dToDate);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

      
        public void Edit(string sBusinessType, int nMonth, int nYear)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                if (sBusinessType == "TEL")
                {
                    sSql = "UPDATE [DWDB].[dbo].t_TELMCAnalysisSettings SET ValuePercentage = ? WHERE ID = ? and MONTH(FromDate)=" + nMonth + " and YEAR(FromDate)="+ nYear + "";
                }
                else if (sBusinessType == "HO")
                {
                    sSql = "UPDATE [DWDB].[dbo].t_TELMCAnalysisSettingsHO SET ValuePercentage = ? WHERE ID = ? and MONTH(FromDate)=" + nMonth + " and YEAR(FromDate)=" + nYear + "";
                }
                else if (sBusinessType == "TML")
                {
                    sSql = "UPDATE [DWDB].[dbo].t_TELMCAnalysisSettingsMobile SET ValuePercentage = ? WHERE ID = ? and MONTH(FromDate)=" + nMonth + " and YEAR(FromDate)=" + nYear + "";
                }
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                
                cmd.Parameters.AddWithValue("ValuePercentage", _fValuePercentage);
                cmd.Parameters.AddWithValue("ID", _nID);
                

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Delete(string sBusinessType)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                if (sBusinessType == "TEL")
                {
                    sSql = "delete from [DWDB].[dbo].t_TELMCAnalysisSettings WHERE ID = ?";
                }
                else if (sBusinessType == "HO")
                {
                    sSql = "delete from [DWDB].[dbo].t_TELMCAnalysisSettingsHO WHERE ID = ?";
                }
                else if (sBusinessType == "TML")
                {
                    sSql = "delete from [DWDB].[dbo].t_TELMCAnalysisSettingsMobile WHERE ID = ?";
                }
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
      
       
    }
    public class VeriableExpenseProvisions : CollectionBase
    {
        public VeriableExpenseProvision this[int i]
        {
            get { return (VeriableExpenseProvision)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(VeriableExpenseProvision oVeriableExpenseProvision)
        {
            InnerList.Add(oVeriableExpenseProvision);
        }
        public int GetIndex(int nID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ID == nID)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Refresh(string sBusinessType, int nMonth, int nYear)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbCommand cmd1 = DBController.Instance.GetCommand();

            string sSql = "";
            string sSql1 = "";

            if (sBusinessType == "TEL")
            {
                sSql = "select * from [DWDB].[dbo].t_TELMCAnalysisSettings WHERE MONTH(FromDate)=" + nMonth + " and YEAR(FromDate)=" + nYear + " order by ID";
                sSql1 = "select * from [DWDB].[dbo].t_TELMCAnalysisSettings WHERE MONTH(FromDate)=1 and YEAR(FromDate)=2020  order by ID";
            }
            else if (sBusinessType == "HO")
            {
                sSql = "select * from [DWDB].[dbo].t_TELMCAnalysisSettingsHO WHERE MONTH(FromDate)=" + nMonth + " and YEAR(FromDate)=" + nYear + "  order by ID";
                sSql1 = "select * from [DWDB].[dbo].t_TELMCAnalysisSettingsHO WHERE MONTH(FromDate)=1 and YEAR(FromDate)=2020  order by ID";
            }
            else if (sBusinessType == "TML")
            {
                sSql = "select * from [DWDB].[dbo].t_TELMCAnalysisSettingsMobile WHERE MONTH(FromDate)=" + nMonth + " and YEAR(FromDate)=" + nYear + "  order by ID";
                sSql1 = "select * from [DWDB].[dbo].t_TELMCAnalysisSettingsMobile WHERE MONTH(FromDate)=1 and YEAR(FromDate)=2020  order by ID";
            }

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                cmd1.CommandText = sSql1;
                cmd1.CommandType = CommandType.Text;
                IDataReader reader1 = cmd1.ExecuteReader();
                int nCount = 0;
               if(nCount==0)
               { 
                    while (reader.Read())
                    {
                        VeriableExpenseProvision oVeriableExpenseProvision = new VeriableExpenseProvision();
                        oVeriableExpenseProvision.ID = (int)reader["ID"];
                        oVeriableExpenseProvision.Description = (string)reader["Description"];
                        oVeriableExpenseProvision.SalesType = (int)reader["SalesType"];
                        oVeriableExpenseProvision.ValuePercentage = (double)reader["ValuePercentage"];
                        oVeriableExpenseProvision.FromDate = Convert.ToDateTime(reader["FromDate"].ToString());
                        oVeriableExpenseProvision.ToDate = Convert.ToDateTime(reader["ToDate"].ToString());
                        InnerList.Add(oVeriableExpenseProvision);
                        nCount = nCount + 1;
                    }

                    reader.Close();
                }
               
                if(nCount==0)
                {
                    while (reader1.Read())
                    {
                        VeriableExpenseProvision oVeriableExpenseProvision = new VeriableExpenseProvision();
                        oVeriableExpenseProvision.ID = 0;
                        oVeriableExpenseProvision.Description = (string)reader1["Description"];
                        oVeriableExpenseProvision.SalesType = (int)reader1["SalesType"];
                        oVeriableExpenseProvision.ValuePercentage = 0;
                        oVeriableExpenseProvision.FromDate = Convert.ToDateTime(reader1["FromDate"].ToString());
                        oVeriableExpenseProvision.ToDate = Convert.ToDateTime(reader1["ToDate"].ToString());
                        InnerList.Add(oVeriableExpenseProvision);
                    }
                    reader1.Close();
                }
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        
    }
}

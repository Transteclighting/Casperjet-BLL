// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: April 05, 2011
// Time :  10:00 AM
// Description: Class for SMDP Stock Management
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class
{
    public class TMLSMDPstock
    {
        private string _sBranchName;
        private string _sSMDPName;
        private string _sSMDPCode;
        private string _sModelNo;
        private int _nQty;
        private DateTime _dEntryDate;

        public string BranchName
        {
            get { return _sBranchName; }
            set { _sBranchName = value; }
        }
        public string SMDPName
        {
            get { return _sSMDPName; }
            set { _sSMDPName = value; }
        }
        public string SMDPCode
        {
            get { return _sSMDPCode; }
            set { _sSMDPCode = value; }
        }
        public string ModelNo
        {
            get { return _sModelNo; }
            set { _sModelNo = value; }
        }
        public int Qty
        {
            get { return _nQty; }
            set { _nQty = value; }
        }
        public DateTime EntryDate
        {
            get { return _dEntryDate; }
            set { _dEntryDate = value; }
        }

        public void Add()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd = DBController.Instance.GetCommand();
                cmd.CommandText = "INSERT INTO t_TMLSMDPStock(Branch,SMDPCode,SMDPName,ModelName,Qty,EntryDate) VALUES(?,?,?,?,?,?)";
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("Branch", _sBranchName);
                cmd.Parameters.AddWithValue("SMDPCode", _sSMDPCode);
                cmd.Parameters.AddWithValue("SMDPName", _sSMDPName);
                cmd.Parameters.AddWithValue("ModelName", _sModelNo);
                cmd.Parameters.AddWithValue("Qty", _nQty);
                cmd.Parameters.AddWithValue("EntryDate", _dEntryDate);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Delete(DateTime dDate, string sBranch, string sSMDPName)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = "Delete from t_TMLSMDPStock where EntryDate=? and Branch=? and SMDPName=?";
                cmd.Parameters.AddWithValue("EntryDate", dDate);
                cmd.Parameters.AddWithValue("Branch", sBranch);
                cmd.Parameters.AddWithValue("SMDPName", sSMDPName);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class TMLSMDPstocks : CollectionBase
    {
        public TMLSMDPstock this[int i]
        {
            get { return (TMLSMDPstock)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(TMLSMDPstock oTMLSMDPstock)
        {
            InnerList.Add(oTMLSMDPstock);
        }
      

        public TMLSMDPstocks GetSMDPStockInfo(DateTime dDate,string sBranch,string sSMDPName)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            sSql = "select * from t_TMLSMDPStock where EntryDate=? and Branch=? and SMDPName=?";
            cmd.Parameters.AddWithValue("EntryDate", dDate);
            cmd.Parameters.AddWithValue("Branch", sBranch);
            cmd.Parameters.AddWithValue("SMDPName", sSMDPName);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    TMLSMDPstock oTMLSMDPstock = new TMLSMDPstock();
                    oTMLSMDPstock.ModelNo = (string)reader["ModelName"];
                    oTMLSMDPstock.Qty = int.Parse( reader["Qty"].ToString());                    

                    InnerList.Add(oTMLSMDPstock);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);

            }
            return this;
        }
    }
}

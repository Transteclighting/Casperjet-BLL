// <summary>
// Company: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: Aug 23, 2016
// Time : 12:32 PM
// Description: Class for ExchangeOfferVenderTran.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class
{
    public class ExchangeOfferVenderTran
    {
        private int _nVenderTranID;
        private string _sVenderTranNo;
        private DateTime _dVenderTranDate;
        private int _nTranSide;
        private int _nVenderID;
        private double _Amount;
        private int _nInstrumentType;
        private string _sInstrumentNo;
        private DateTime _dInstrumentDate;
        private int _nBankID;
        private string _sBranchName;
        private string _sRemarks;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;
        private string _sVenderName;
        private int _nType;
        private int _nFromVenderID;
        private int _nToVenderID;
        private string _sFromVenderName;
        private string _sToVenderName;


        // <summary>
        // Get set property for FromVenderName
        // </summary>
        public string FromVenderName
        {
            get { return _sFromVenderName; }
            set { _sFromVenderName = value.Trim(); }
        }
        // <summary>
        // Get set property for ToVenderName
        // </summary>
        public string ToVenderName
        {
            get { return _sToVenderName; }
            set { _sToVenderName = value.Trim(); }
        }

        // <summary>
        // Get set property for FromVenderID
        // </summary>
        public int FromVenderID
        {
            get { return _nFromVenderID; }
            set { _nFromVenderID = value; }
        }
        // <summary>
        // Get set property for ToVenderID
        // </summary>
        public int ToVenderID
        {
            get { return _nToVenderID; }
            set { _nToVenderID = value; }
        }


        // <summary>
        // Get set property for VenderTranID
        // </summary>
        public int Type
        {
            get { return _nType; }
            set { _nType = value; }
        }

        // <summary>
        // Get set property for VenderTranID
        // </summary>
        public int TranSide
        {
            get { return _nTranSide; }
            set { _nTranSide = value; }
        }

        // <summary>
        // Get set property for VenderTranID
        // </summary>
        public int VenderTranID
        {
            get { return _nVenderTranID; }
            set { _nVenderTranID = value; }
        }

        // <summary>
        // Get set property for VenderTranNo
        // </summary>
        public string VenderTranNo
        {
            get { return _sVenderTranNo; }
            set { _sVenderTranNo = value.Trim(); }
        }

        // <summary>
        // Get set property for VenderName
        // </summary>
        public string VenderName
        {
            get { return _sVenderName; }
            set { _sVenderName = value.Trim(); }
        }

        // <summary>
        // Get set property for VenderTranDate
        // </summary>
        public DateTime VenderTranDate
        {
            get { return _dVenderTranDate; }
            set { _dVenderTranDate = value; }
        }

        // <summary>
        // Get set property for VenderID
        // </summary>
        public int VenderID
        {
            get { return _nVenderID; }
            set { _nVenderID = value; }
        }

        // <summary>
        // Get set property for Amount
        // </summary>
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }

        // <summary>
        // Get set property for InstrumentType
        // </summary>
        public int InstrumentType
        {
            get { return _nInstrumentType; }
            set { _nInstrumentType = value; }
        }

        // <summary>
        // Get set property for InstrumentNo
        // </summary>
        public string InstrumentNo
        {
            get { return _sInstrumentNo; }
            set { _sInstrumentNo = value.Trim(); }
        }

        // <summary>
        // Get set property for InstrumentDate
        // </summary>
        public DateTime InstrumentDate
        {
            get { return _dInstrumentDate; }
            set { _dInstrumentDate = value; }
        }

        // <summary>
        // Get set property for BankID
        // </summary>
        public int BankID
        {
            get { return _nBankID; }
            set { _nBankID = value; }
        }

        // <summary>
        // Get set property for BranchName
        // </summary>
        public string BranchName
        {
            get { return _sBranchName; }
            set { _sBranchName = value.Trim(); }
        }

        // <summary>
        // Get set property for Remarks
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }

        // <summary>
        // Get set property for CreateUserID
        // </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }

        // <summary>
        // Get set property for CreateDate
        // </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }

        // <summary>
        // Get set property for UpdateUserID
        // </summary>
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
        }

        // <summary>
        // Get set property for UpdateDate
        // </summary>
        public DateTime UpdateDate
        {
            get { return _dUpdateDate; }
            set { _dUpdateDate = value; }
        }

        public void Add()
        {
            int nMaxVenderTranID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([VenderTranID]) FROM t_ExchangeOfferVenderTran";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxVenderTranID = 1;
                }
                else
                {
                    nMaxVenderTranID = Convert.ToInt32(maxID) + 1;
                }
                _nVenderTranID = nMaxVenderTranID;

                string sCode = "";
                DateTime dToday = DateTime.Today;
                sCode = "EOT-" + dToday.Year + "-" + _nVenderTranID.ToString("0000");
                _sVenderTranNo = sCode;


                sSql = "INSERT INTO t_ExchangeOfferVenderTran (VenderTranID,VenderTranNo,VenderTranDate,TranSide,Type,  "+
                        "FromVenderID,ToVenderID,Amount,InstrumentType,InstrumentNo,InstrumentDate,BankID,BranchName,  "+
                        "Remarks,CreateUserID,CreateDate,UpdateUserID,UpdateDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("VenderTranID", _nVenderTranID);
                cmd.Parameters.AddWithValue("VenderTranNo", _sVenderTranNo);
                cmd.Parameters.AddWithValue("VenderTranDate", _dVenderTranDate);
                cmd.Parameters.AddWithValue("TranSide", _nTranSide);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.Parameters.AddWithValue("FromVenderID", _nFromVenderID);
                cmd.Parameters.AddWithValue("ToVenderID", _nToVenderID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("InstrumentType", _nInstrumentType);
                if (_nInstrumentType != (int)Dictionary.InstrumentType.CASH)
                {
                    cmd.Parameters.AddWithValue("InstrumentNo", _sInstrumentNo);
                    cmd.Parameters.AddWithValue("InstrumentDate", _dInstrumentDate);
                    cmd.Parameters.AddWithValue("BankID", _nBankID);
                    cmd.Parameters.AddWithValue("BranchName", _sBranchName);
                }
                else
                {
                    cmd.Parameters.AddWithValue("InstrumentNo", null);
                    cmd.Parameters.AddWithValue("InstrumentDate", null);
                    cmd.Parameters.AddWithValue("BankID", null);
                    cmd.Parameters.AddWithValue("BranchName", null);
                }

                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddFundTransfer()
        {
            int nMaxVenderTranID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([VenderTranID]) FROM t_ExchangeOfferVenderTran";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxVenderTranID = 1;
                }
                else
                {
                    nMaxVenderTranID = Convert.ToInt32(maxID) + 1;
                }
                _nVenderTranID = nMaxVenderTranID;

                string sCode = "";
                DateTime dToday = DateTime.Today;
                sCode = "EOT-" + dToday.Year + "-" + _nVenderTranID.ToString("0000");
                _sVenderTranNo = sCode;


                sSql = "INSERT INTO t_ExchangeOfferVenderTran (VenderTranID,VenderTranNo,VenderTranDate,TranSide,Type,  " +
                        "FromVenderID,ToVenderID,Amount,InstrumentType,InstrumentNo,InstrumentDate,BankID,BranchName,  " +
                        "Remarks,CreateUserID,CreateDate,UpdateUserID,UpdateDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("VenderTranID", _nVenderTranID);
                cmd.Parameters.AddWithValue("VenderTranNo", _sVenderTranNo);
                cmd.Parameters.AddWithValue("VenderTranDate", _dVenderTranDate);
                cmd.Parameters.AddWithValue("TranSide", _nTranSide);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.Parameters.AddWithValue("FromVenderID", _nFromVenderID);
                cmd.Parameters.AddWithValue("ToVenderID", _nToVenderID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("InstrumentType", null);
                cmd.Parameters.AddWithValue("InstrumentNo", null);
                cmd.Parameters.AddWithValue("InstrumentDate", null);
                cmd.Parameters.AddWithValue("BankID", null);
                cmd.Parameters.AddWithValue("BranchName", null);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void AddFromMR()
        {
            int nMaxVenderTranID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([VenderTranID]) FROM t_ExchangeOfferVenderTran";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxVenderTranID = 1;
                }
                else
                {
                    nMaxVenderTranID = Convert.ToInt32(maxID) + 1;
                }
                _nVenderTranID = nMaxVenderTranID;


                sSql = "INSERT INTO t_ExchangeOfferVenderTran (VenderTranID,VenderTranNo,VenderTranDate,TranSide,Type,  " +
                        "FromVenderID,ToVenderID,Amount,InstrumentType,InstrumentNo,InstrumentDate,BankID,BranchName,  " +
                        "Remarks,CreateUserID,CreateDate,UpdateUserID,UpdateDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("VenderTranID", _nVenderTranID);
                cmd.Parameters.AddWithValue("VenderTranNo", _sVenderTranNo);
                cmd.Parameters.AddWithValue("VenderTranDate", _dVenderTranDate);
                cmd.Parameters.AddWithValue("TranSide", _nTranSide);
                cmd.Parameters.AddWithValue("Type", _nType);
                cmd.Parameters.AddWithValue("FromVenderID", _nFromVenderID);
                cmd.Parameters.AddWithValue("ToVenderID", _nToVenderID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("InstrumentType", null);
                cmd.Parameters.AddWithValue("InstrumentNo", null);
                cmd.Parameters.AddWithValue("InstrumentDate", null);
                cmd.Parameters.AddWithValue("BankID", null);
                cmd.Parameters.AddWithValue("BranchName", null);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                cmd.Parameters.AddWithValue("UpdateDate", null);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Edit()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_ExchangeOfferVenderTran SET VenderTranNo = ?, VenderTranDate = ?, VenderID = ?, Amount = ?, InstrumentType = ?, InstrumentNo = ?, InstrumentDate = ?, BankID = ?, BranchName = ?, Remarks = ?, CreateUserID = ?, CreateDate = ?, UpdateUserID = ?, UpdateDate = ? WHERE VenderTranID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("VenderTranNo", _sVenderTranNo);
                cmd.Parameters.AddWithValue("VenderTranDate", _dVenderTranDate);
                cmd.Parameters.AddWithValue("VenderID", _nVenderID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("InstrumentType", _nInstrumentType);
                cmd.Parameters.AddWithValue("InstrumentNo", _sInstrumentNo);
                cmd.Parameters.AddWithValue("InstrumentDate", _dInstrumentDate);
                cmd.Parameters.AddWithValue("BankID", _nBankID);
                cmd.Parameters.AddWithValue("BranchName", _sBranchName);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);

                cmd.Parameters.AddWithValue("VenderTranID", _nVenderTranID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Delete()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_ExchangeOfferVenderTran WHERE [VenderTranID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("VenderTranID", _nVenderTranID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_ExchangeOfferVenderTran where VenderTranID =?";
                cmd.Parameters.AddWithValue("VenderTranID", _nVenderTranID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nVenderTranID = (int)reader["VenderTranID"];
                    _sVenderTranNo = (string)reader["VenderTranNo"];
                    _dVenderTranDate = Convert.ToDateTime(reader["VenderTranDate"].ToString());
                    _nVenderID = (int)reader["VenderID"];
                    _Amount = Convert.ToDouble(reader["Amount"].ToString());
                    _nInstrumentType = (int)reader["InstrumentType"];
                    _sInstrumentNo = (string)reader["InstrumentNo"];
                    _dInstrumentDate = Convert.ToDateTime(reader["InstrumentDate"].ToString());
                    _nBankID = (int)reader["BankID"];
                    _sBranchName = (string)reader["BranchName"];
                    _sRemarks = (string)reader["Remarks"];
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nUpdateUserID = (int)reader["UpdateUserID"];
                    _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void UpdateForWEB()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_ExchangeOfferVenderTran SET VenderTranDate = ?, FromVenderID = ?, ToVenderID = ?, Amount = ?,  Remarks = ?, UpdateUserID = ?, UpdateDate = ? WHERE VenderTranNo = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("VenderTranDate", _dVenderTranDate);
                cmd.Parameters.AddWithValue("FromVenderID", _nFromVenderID);
                cmd.Parameters.AddWithValue("ToVenderID", _nToVenderID);
                cmd.Parameters.AddWithValue("Amount", _Amount);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("UpdateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("UpdateDate", DateTime.Now.Date);

                cmd.Parameters.AddWithValue("VenderTranNo", _sVenderTranNo);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class ExchangeOfferVenderTrans : CollectionBase
    {
        public ExchangeOfferVenderTran this[int i]
        {
            get { return (ExchangeOfferVenderTran)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(ExchangeOfferVenderTran oExchangeOfferVenderTran)
        {
            InnerList.Add(oExchangeOfferVenderTran);
        }
        public int GetIndex(int nVenderTranID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].VenderTranID == nVenderTranID)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_ExchangeOfferVenderTran";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ExchangeOfferVenderTran oExchangeOfferVenderTran = new ExchangeOfferVenderTran();
                    oExchangeOfferVenderTran.VenderTranID = (int)reader["VenderTranID"];
                    oExchangeOfferVenderTran.VenderTranNo = (string)reader["VenderTranNo"];
                    oExchangeOfferVenderTran.VenderTranDate = Convert.ToDateTime(reader["VenderTranDate"].ToString());
                    oExchangeOfferVenderTran.VenderID = (int)reader["VenderID"];
                    oExchangeOfferVenderTran.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oExchangeOfferVenderTran.InstrumentType = (int)reader["InstrumentType"];
                    oExchangeOfferVenderTran.InstrumentNo = (string)reader["InstrumentNo"];
                    oExchangeOfferVenderTran.InstrumentDate = Convert.ToDateTime(reader["InstrumentDate"].ToString());
                    oExchangeOfferVenderTran.BankID = (int)reader["BankID"];
                    oExchangeOfferVenderTran.BranchName = (string)reader["BranchName"];
                    oExchangeOfferVenderTran.Remarks = (string)reader["Remarks"];
                    oExchangeOfferVenderTran.CreateUserID = (int)reader["CreateUserID"];
                    oExchangeOfferVenderTran.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oExchangeOfferVenderTran.UpdateUserID = (int)reader["UpdateUserID"];
                    oExchangeOfferVenderTran.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    InnerList.Add(oExchangeOfferVenderTran);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetVenderTran(DateTime dFromDate, DateTime dToDate, string sVenderTranNo, string sFromVender, string sToVender,bool IsCheck)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = "Select * From  "+
                    " (  "+
                    " Select VenderTranID,VenderTranNo,VenderTranDate,  "+
                    " TranSide,Type,FromVenderID,'System' as FromVenderName,  "+
                    " ToVenderID,ParentVenderName as ToVenderName,Amount, "+
                    " a.Remarks,a.CreateDate,a.CreateUserID  "+
                    " FROM t_ExchangeOfferVenderTran a,t_ExchangeOfferVenderParent b  "+
                    " where a.ToVenderID=b.ParentVenderID and Type=1  "+
                    " Union All  "+
                    " Select VenderTranID,VenderTranNo,VenderTranDate,  "+
                    " TranSide,Type,FromVenderID,ParentVenderName as FromVenderName,  "+
                    " ToVenderID,Name as ToVenderName,Amount,  "+
                    " a.Remarks,a.CreateDate,a.CreateUserID  "+
                    " FROM t_ExchangeOfferVenderTran a,t_ExchangeOfferVenderParent b,t_ExchangeOfferVender c  "+
                    " where a.FromVenderID=b.ParentVenderID and a.ToVenderID=c.VenderID and Type=2  "+
                    " Union All  "+
                    " Select VenderTranID,VenderTranNo,VenderTranDate,  "+
                    " TranSide,Type,FromVenderID,Name as FromVenderName,  "+
                    " ToVenderID,ParentVenderName as ToVenderName,Amount,  "+
                    " a.Remarks,a.CreateDate,a.CreateUserID  " +
                    " FROM t_ExchangeOfferVenderTran a,t_ExchangeOfferVenderParent b,t_ExchangeOfferVender c  "+
                    " where a.FromVenderID=c.VenderID and a.ToVenderID=b.ParentVenderID and Type=3  "+
                    " Union All  "+
                    " Select VenderTranID,VenderTranNo,VenderTranDate,  "+
                    " TranSide,Type,FromVenderID,Name as FromVenderName,  "+
                    " ToVenderID,'System' as ToVenderName,Amount,  "+
                    " a.Remarks,a.CreateDate,a.CreateUserID  " +
                    " FROM t_ExchangeOfferVenderTran a,t_ExchangeOfferVender b  "+
                    " where a.ToVenderID=b.VenderID and Type=4  "+
                    " )  " +
                    " Main where 1=1";

            }

            if (IsCheck == false)
            {
                sSql = sSql + " and VenderTranDate between '" + dFromDate + "' and '" + dToDate + "' and VenderTranDate<'" + dToDate + "' ";
            }

            //if (nVenderID != -1)
            //{
            //    sSql = sSql + " AND a.VenderID=" + nVenderID + "";
            //}
            if (sVenderTranNo != "")
            {
                sSql = sSql + " AND VenderTranNo like '%" + sVenderTranNo + "%'";
            }
            if (sFromVender != "")
            {
                sSql = sSql + " AND FromVenderName like '%" + sFromVender + "%'";
            }
            if (sToVender != "")
            {
                sSql = sSql + " AND ToVenderName like '%" + sToVender + "%'";
            }
            sSql = sSql + " Order by VenderTranID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ExchangeOfferVenderTran oExchangeOfferVenderTran = new ExchangeOfferVenderTran();
                    oExchangeOfferVenderTran.VenderTranID = (int)reader["VenderTranID"];
                    oExchangeOfferVenderTran.VenderTranNo = (string)reader["VenderTranNo"];
                    oExchangeOfferVenderTran.VenderTranDate = Convert.ToDateTime(reader["VenderTranDate"].ToString());
                    oExchangeOfferVenderTran.TranSide = (int)reader["TranSide"];
                    oExchangeOfferVenderTran.Type = (int)reader["Type"];
                    oExchangeOfferVenderTran.FromVenderID = (int)reader["FromVenderID"];
                    oExchangeOfferVenderTran.FromVenderName = (string)reader["FromVenderName"];
                    oExchangeOfferVenderTran.ToVenderID = (int)reader["ToVenderID"];
                    oExchangeOfferVenderTran.ToVenderName = (string)reader["ToVenderName"];
                    oExchangeOfferVenderTran.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    oExchangeOfferVenderTran.Remarks = (string)reader["Remarks"];
                    oExchangeOfferVenderTran.CreateUserID = (int)reader["CreateUserID"];
                    oExchangeOfferVenderTran.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    InnerList.Add(oExchangeOfferVenderTran);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
    }
}


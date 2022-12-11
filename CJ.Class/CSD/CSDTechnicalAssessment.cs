// <summary>
// Company: Transcom Electronics Limited
// Author: Kanij Fatema Sharme
// Date: Jan 22, 2020
// Time : 02:12 PM
// Description: Class for CSDTechnicalAssessment.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.CSD
{
    public class CSDTechnicalAssessment
    {
        private int _nAssessmentID;
        private int _nJobID;
        private string _sAccessories;
        private string _sFunctionalCondition;
        private string _sCarton;
        private string _sCorkSheet;
        private int _nMajorDent;
        private int _nMinorDent;
        private int _nMajorScratch;
        private int _nMinorScratch;
        private int _nBrokenIssue;
        private string _sProductCondition;
        private string _sStock;
        private int _nCreateBY;
        private DateTime _dCreateDate;
        private object _dAssessmentDate;
        private string _sRemarks;
        private int _nIsPartsUsed;
        private string _sPartsUsed;
        private string _MaDent;
        private string _MiDent;
        private string _MaScratch;
        private string _MiScratch;
        private string _AnyBrokenIssue;


        // <summary>
        // Get set property for AssessmentID
        // </summary>
        public int AssessmentID
        {
            get { return _nAssessmentID; }
            set { _nAssessmentID = value; }
        }

        // <summary>
        // Get set property for JobID
        // </summary>
        public int JobID
        {
            get { return _nJobID; }
            set { _nJobID = value; }
        }
        public object AssessmentDate
        {
            get { return _dAssessmentDate; }
            set { _dAssessmentDate = value; }
        }

        // <summary>
        // Get set property for Accessories
        // </summary>
        public string Accessories
        {
            get { return _sAccessories; }
            set { _sAccessories = value.Trim(); }
        }
        public string PartsUsed
        {
            get { return _sPartsUsed; }
            set { _sPartsUsed = value.Trim(); }
        }
        // <summary>
        // Get set property for FunctionalCondition
        // </summary>
        public string FunctionalCondition
        {
            get { return _sFunctionalCondition; }
            set { _sFunctionalCondition = value.Trim(); }
        }
        public string MaDent
        {
            get { return _MaDent; }
            set { _MaDent = value.Trim(); }
        }
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }
        public string MiDent
        {
            get { return _MiDent; }
            set { _MiDent = value.Trim(); }
        }
        public string MaScratch
        {
            get { return _MaScratch; }
            set { _MaScratch = value.Trim(); }
        }
        public string MiScratch
        {
            get { return _MiScratch; }
            set { _MiScratch = value.Trim(); }
        }
        public string AnyBrokenIssue
        {
            get { return _AnyBrokenIssue; }
            set { _AnyBrokenIssue = value.Trim(); }
        }
        // <summary>
        // Get set property for Carton
        // </summary>
        public string Carton
        {
            get { return _sCarton; }
            set { _sCarton = value.Trim(); }
        }

        // <summary>
        // Get set property for CorkSheet
        // </summary>
        public string CorkSheet
        {
            get { return _sCorkSheet; }
            set { _sCorkSheet = value.Trim(); }
        }

        // <summary>
        // Get set property for MajorDent
        // </summary>
        public int MajorDent
        {
            get { return _nMajorDent; }
            set { _nMajorDent = value; }
        }
        public int IsPartsUsed
        {
            get { return _nIsPartsUsed; }
            set { _nIsPartsUsed = value; }
        }
        // <summary>
        // Get set property for MinorDent
        // </summary>
        public int MinorDent
        {
            get { return _nMinorDent; }
            set { _nMinorDent = value; }
        }

        // <summary>
        // Get set property for MajorScratch
        // </summary>
        public int MajorScratch
        {
            get { return _nMajorScratch; }
            set { _nMajorScratch = value; }
        }

        // <summary>
        // Get set property for MinorScratch
        // </summary>
        public int MinorScratch
        {
            get { return _nMinorScratch; }
            set { _nMinorScratch = value; }
        }

        // <summary>
        // Get set property for BrokenIssue
        // </summary>
        public int BrokenIssue
        {
            get { return _nBrokenIssue; }
            set { _nBrokenIssue = value; }
        }

        // <summary>
        // Get set property for ProductCondition
        // </summary>
        public string ProductCondition
        {
            get { return _sProductCondition; }
            set { _sProductCondition = value.Trim(); }
        }

        // <summary>
        // Get set property for Stock
        // </summary>
        public string Stock
        {
            get { return _sStock; }
            set { _sStock = value.Trim(); }
        }

        // <summary>
        // Get set property for CreateBY
        // </summary>
        public int CreateBY
        {
            get { return _nCreateBY; }
            set { _nCreateBY = value; }
        }

        // <summary>
        // Get set property for CreateDate
        // </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }

        public void Add()
        {
            int nMaxAssessmentID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([AssessmentID]) FROM t_CSDTechnicalAssessment";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxAssessmentID = 1;
                }
                else
                {
                    nMaxAssessmentID = Convert.ToInt32(maxID) + 1;
                }
                _nAssessmentID = nMaxAssessmentID;
                sSql = "INSERT INTO t_CSDTechnicalAssessment (AssessmentID, JobID, Accessories, FunctionalCondition, Carton, CorkSheet, MajorDent, MinorDent, MajorScratch, MinorScratch, BrokenIssue, ProductCondition, Remarks, CreateBY, CreateDate,IsPartsused) VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("AssessmentID", _nAssessmentID);
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("Accessories", _sAccessories);
                cmd.Parameters.AddWithValue("FunctionalCondition", _sFunctionalCondition);
                cmd.Parameters.AddWithValue("Carton", _sCarton);
                cmd.Parameters.AddWithValue("CorkSheet", _sCorkSheet);
                cmd.Parameters.AddWithValue("MajorDent", _nMajorDent);
                cmd.Parameters.AddWithValue("MinorDent", _nMinorDent);
                cmd.Parameters.AddWithValue("MajorScratch", _nMajorScratch);
                cmd.Parameters.AddWithValue("MinorScratch", _nMinorScratch);
                cmd.Parameters.AddWithValue("BrokenIssue", _nBrokenIssue);
                cmd.Parameters.AddWithValue("ProductCondition", _sProductCondition);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateBY", _nCreateBY);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("IsPartsUsed", _nIsPartsUsed);

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
                sSql = "UPDATE t_CSDTechnicalAssessment SET JobID = ?, Accessories = ?, FunctionalCondition = ?, Carton = ?, CorkSheet = ?, MajorDent = ?, MinorDent = ?, MajorScratch = ?, MinorScratch = ?, BrokenIssue = ?, ProductCondition = ?, Stock = ?, CreateBY = ?, CreateDate = ? WHERE AssessmentID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.Parameters.AddWithValue("Accessories", _sAccessories);
                cmd.Parameters.AddWithValue("FunctionalCondition", _sFunctionalCondition);
                cmd.Parameters.AddWithValue("Carton", _sCarton);
                cmd.Parameters.AddWithValue("CorkSheet", _sCorkSheet);
                cmd.Parameters.AddWithValue("MajorDent", _nMajorDent);
                cmd.Parameters.AddWithValue("MinorDent", _nMinorDent);
                cmd.Parameters.AddWithValue("MajorScratch", _nMajorScratch);
                cmd.Parameters.AddWithValue("MinorScratch", _nMinorScratch);
                cmd.Parameters.AddWithValue("BrokenIssue", _nBrokenIssue);
                cmd.Parameters.AddWithValue("ProductCondition", _sProductCondition);
                cmd.Parameters.AddWithValue("Stock", _sStock);
                cmd.Parameters.AddWithValue("CreateBY", _nCreateBY);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);

                cmd.Parameters.AddWithValue("AssessmentID", _nAssessmentID);

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
                sSql = "DELETE FROM t_CSDTechnicalAssessment WHERE [AssessmentID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("AssessmentID", _nAssessmentID);
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
                cmd.CommandText = "SELECT * FROM t_CSDTechnicalAssessment where AssessmentID =?";
                cmd.Parameters.AddWithValue("AssessmentID", _nAssessmentID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nAssessmentID = (int)reader["AssessmentID"];
                    _nJobID = (int)reader["JobID"];
                    _sAccessories = (string)reader["Accessories"];
                    _sFunctionalCondition = (string)reader["FunctionalCondition"];
                    _sCarton = (string)reader["Carton"];
                    _sCorkSheet = (string)reader["CorkSheet"];
                    _nMajorDent = (int)reader["MajorDent"];
                    _nMinorDent = (int)reader["MinorDent"];
                    _nMajorScratch = (int)reader["MajorScratch"];
                    _nMinorScratch = (int)reader["MinorScratch"];
                    _nBrokenIssue = (int)reader["BrokenIssue"];
                    _sProductCondition = (string)reader["ProductCondition"];
                    _sStock = (string)reader["Stock"];
                    _nCreateBY = (int)reader["CreateBY"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public int RefreshTechnicalAssessment()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = @"Select a.*,b.CreateDate as AssessmentDate From
                                    (Select AssessmentID, a.JobID,JobNo,ProductCode,ProductName,ProductSerialNo,Brand,FaultCategory,FaultDesc,
                                    Accessories,FunctionalCondition,Carton,CorkSheet,case when MajorDent=1 then 'Yes' when MajorDent=2 then 'No' end as Majordent,
                                    case when MinorDent=1 then 'Yes' when MinorDent=2 then 'No' end as MinorDent,
                                    case when MajorScratch=1 then 'Yes' when MajorScratch=2 then 'No' end as MajorScratch,
                                    case when MinorScratch=1 then 'Yes' when MinorScratch=2 then 'No' end as MinorScratch,
                                    case when BrokenIssue=1 then 'Yes' when BrokenIssue=2 then 'No' end as BrokenIssue,
                                    a.Remarks,b.CreateDate CreateDate,DeliveryDate,StatusName,ProductCondition,
                                    case when IsPartsUsed=1 then 'Yes' when IsPartsUsed=2 then 'No' end as IsPartsUsed
                                    from t_CSDTechnicalAssessment a,v_CSDJobDetails b
                                    where a.JobID=b.JobID)A
                                    Left Outer Join
                                    (Select * from t_CSDJobHistory where StatusID=4
                                    and Remarks Not like'%Remote Status update%')B on A.JobID=B.JobID
                                    Where a.JobID=?";
                //cmd.Parameters.AddWithValue("AssessmentID", _nAssessmentID);
                cmd.Parameters.AddWithValue("JobID", _nJobID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nAssessmentID = (int)reader["AssessmentID"];
                    _nJobID = (int)reader["JobID"];
                    _sAccessories = (string)reader["Accessories"];
                    _sFunctionalCondition = (string)reader["FunctionalCondition"];
                    _sCarton = (string)reader["Carton"];
                    _sCorkSheet = (string)reader["CorkSheet"];
                    _MaDent = (string)reader["Majordent"];
                    _MiDent= (string)reader["MinorDent"];
                    _MaScratch = (string)reader["MajorScratch"];
                    _MiScratch = (string)reader["MinorScratch"];
                    _AnyBrokenIssue = (string)reader["BrokenIssue"];
                    _sProductCondition = (string)reader["ProductCondition"];
                    _sRemarks = (string)reader["Remarks"];
                    if (reader["IsPartsUsed"] != DBNull.Value)
                    {
                        _sPartsUsed = (string)reader["IsPartsUsed"];
                    }
                    else
                    {
                        _sPartsUsed = "";
                    }
                    if (reader["AssessmentDate"] != DBNull.Value)
                    {
                        _dAssessmentDate = Convert.ToDateTime(reader["AssessmentDate"].ToString());
                    }
                    else
                    {
                        _dAssessmentDate = "";
                    }
                    //_nCreateBY = (int)reader["CreateBY"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nCount;
        }        
    }
    public class CSDTechnicalAssessments : CollectionBase
    {
        public CSDTechnicalAssessment this[int i]
        {
            get { return (CSDTechnicalAssessment)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CSDTechnicalAssessment oCSDTechnicalAssessment)
        {
            InnerList.Add(oCSDTechnicalAssessment);
        }
        public int GetIndex(int nAssessmentID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].AssessmentID == nAssessmentID)
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
            string sSql = "SELECT * FROM t_CSDTechnicalAssessment";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDTechnicalAssessment oCSDTechnicalAssessment = new CSDTechnicalAssessment();
                    oCSDTechnicalAssessment.AssessmentID = (int)reader["AssessmentID"];
                    oCSDTechnicalAssessment.JobID = (int)reader["JobID"];
                    oCSDTechnicalAssessment.Accessories = (string)reader["Accessories"];
                    oCSDTechnicalAssessment.FunctionalCondition = (string)reader["FunctionalCondition"];
                    oCSDTechnicalAssessment.Carton = (string)reader["Carton"];
                    oCSDTechnicalAssessment.CorkSheet = (string)reader["CorkSheet"];
                    oCSDTechnicalAssessment.MajorDent = (int)reader["MajorDent"];
                    oCSDTechnicalAssessment.MinorDent = (int)reader["MinorDent"];
                    oCSDTechnicalAssessment.MajorScratch = (int)reader["MajorScratch"];
                    oCSDTechnicalAssessment.MinorScratch = (int)reader["MinorScratch"];
                    oCSDTechnicalAssessment.BrokenIssue = (int)reader["BrokenIssue"];
                    oCSDTechnicalAssessment.ProductCondition = (string)reader["ProductCondition"];
                    oCSDTechnicalAssessment.Stock = (string)reader["Stock"];
                    oCSDTechnicalAssessment.CreateBY = (int)reader["CreateBY"];
                    oCSDTechnicalAssessment.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    InnerList.Add(oCSDTechnicalAssessment);
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


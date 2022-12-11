using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class
{
    public class SalesLeadMgtQC : CollectionBase
    {
        public SalesLeadManagementQC this[int i]
        {
            get { return (SalesLeadManagementQC)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(SalesLeadManagementQC oSalesLeadManagementQC)
        {
            InnerList.Add(oSalesLeadManagementQC);
        }

        //public void Update(SalesLeadManagementQC oSalesLeadManagementQC)
        //{
        //    InnerList.Update(oSalesLeadManagementQC);
        //}

        private int _nQCID;
        private int _nLeadID;
        private DateTime _dCreateDate;
        private int _nCreateUserID;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;
        private int _nIsValidLead;
        private int _nStatus;
        private int _nReason;

        private string _sRemarks;
        private string duplicateVale;
        private string checkDuplicateValue;



        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }


        // <summary>
        // Get set property for QCID
        // </summary>
        public int QCID
        {
            get { return _nQCID; }
            set { _nQCID = value; }
        }

        // <summary>
        // Get set property for LeadID
        // </summary>
        public int LeadID
        {
            get { return _nLeadID; }
            set { _nLeadID = value; }
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
        // Get set property for CreateUserID
        // </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
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

        // <summary>
        // Get set property for Status
        // </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

        public int IsValidLead
        {
            get { return _nIsValidLead; }
            set { _nIsValidLead = value; }
        }

        public int Reason
        {
            get { return _nReason; }
            set { _nReason = value; }
        }


        public string CheckDuplicateData(int _nLeadID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            duplicateVale = "No";
            try
            {
                cmd.CommandText = "SELECT * FROM t_SalesLeadManagementQC where LeadID =?";
                cmd.Parameters.AddWithValue("LeadID", _nLeadID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    duplicateVale = "Yes";
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }

            return duplicateVale;
        }

        public void UpdateLeadQCData()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                sSql = "update t_SalesLeadManagement set IsValidLead = ?, LeadStatusID = ?, ReasonID = ?, IsVerified = ?,VerifiedBy=?,VerifiedDate=? where LeadID=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("IsValidLead", _nIsValidLead);
                cmd.Parameters.AddWithValue("LeadStatusID", _nStatus);
                cmd.Parameters.AddWithValue("ReasonID", _nReason);
                cmd.Parameters.AddWithValue("IsVerified", (int)Dictionary.YesNAStatus.Yes);
                cmd.Parameters.AddWithValue("VerifiedBy", Utility.UserId);
                cmd.Parameters.AddWithValue("VerifiedDate", DateTime.Now);
                cmd.Parameters.AddWithValue("LeadID", _nLeadID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();

                checkDuplicateValue = CheckDuplicateData(_nLeadID);

                if (checkDuplicateValue == "Yes")
                {
                    SalesLeadManagementQC salesLeadMgtQc = new SalesLeadManagementQC();

                    salesLeadMgtQc.DeleteSalesLeadQC(_nLeadID);

                    foreach (SalesLeadManagementQC oitem in this)
                    {
                        oitem.AddSalesLeadManagementQC(_nLeadID);
                    }
                }

                else
                {
                    foreach (SalesLeadManagementQC oitem in this)
                    {
                        oitem.AddSalesLeadManagementQC(_nLeadID);
                    }
                }

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }
    public class SalesLeadManagementQC
    {
        private int _nQCID;
        private int _nLeadID;
        private int _nQuestionID;
        private int _nMark;
        private int _nStatus;
        private DateTime _dCreateDate;
        private int _nCreateUserID;

        private string _sRemarks;



        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }


        // <summary>
        // Get set property for QCID
        // </summary>


        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }

        // <summary>
        // Get set property for CreateUserID
        // </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }
        public int QCID
        {
            get { return _nQCID; }
            set { _nQCID = value; }
        }

        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

        // <summary>
        // Get set property for LeadID
        // </summary>
        public int LeadID
        {
            get { return _nLeadID; }
            set { _nLeadID = value; }
        }

        // <summary>
        // Get set property for QuestionID
        // </summary>
        public int QuestionID
        {
            get { return _nQuestionID; }
            set { _nQuestionID = value; }
        }

        // <summary>
        // Get set property for Mark
        // </summary>
        public int Mark
        {
            get { return _nMark; }
            set { _nMark = value; }
        }

        public void AddSalesLeadManagementQC(int nLeadID)
        {
            int nMaxQCID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([QCID]) FROM t_SalesLeadManagementQC";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxQCID = 1;
                }
                else
                {
                    nMaxQCID = Convert.ToInt32(maxID) + 1;
                }
                _nQCID = nMaxQCID;
                sSql = "INSERT INTO t_SalesLeadManagementQC (QCID, LeadID, QuestionID, Mark, Remarks, CreateDate, CreateUserID) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("QCID", _nQCID);
                cmd.Parameters.AddWithValue("LeadID", nLeadID);
                cmd.Parameters.AddWithValue("QuestionID", _nQuestionID);
                cmd.Parameters.AddWithValue("Mark", _nMark);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void DeleteSalesLeadQC(int nLeadID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "DELETE FROM t_SalesLeadManagementQC WHERE [LeadID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("LeadID", nLeadID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void Add()
        {
            int nMaxQCID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([QCID]) FROM t_SalesLeadManagementQC";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxQCID = 1;
                }
                else
                {
                    nMaxQCID = Convert.ToInt32(maxID) + 1;
                }
                _nQCID = nMaxQCID;
                sSql = "INSERT INTO t_SalesLeadManagementQC (QCID, LeadID, QuestionID, Mark) VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("QCID", _nQCID);
                cmd.Parameters.AddWithValue("LeadID", _nLeadID);
                cmd.Parameters.AddWithValue("QuestionID", _nQuestionID);
                cmd.Parameters.AddWithValue("Mark", _nMark);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

    }

    public class SalesLeadMgtQuestionStatus
    {
        private int _nID;
        private int _nStatusLevel;
        private string _sName;
        private int _nParentID;


        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for StatusLevel
        // </summary>
        public int StatusLevel
        {
            get { return _nStatusLevel; }
            set { _nStatusLevel = value; }
        }

        // <summary>
        // Get set property for Name
        // </summary>
        public string Name
        {
            get { return _sName; }
            set { _sName = value.Trim(); }
        }

        // <summary>
        // Get set property for ParentID
        // </summary>
        public int ParentID
        {
            get { return _nParentID; }
            set { _nParentID = value; }
        }

    }
    public class SalesLeadMgtQuestionStatuss : CollectionBase
    {
        public SalesLeadMgtQuestionStatus this[int i]
        {
            get { return (SalesLeadMgtQuestionStatus)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(SalesLeadMgtQuestionStatus oSalesLeadMgtQuestionStatus)
        {
            InnerList.Add(oSalesLeadMgtQuestionStatus);
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

        public void GetLeadStatus()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select * From t_SalesLeadMgtQuestionStatus where ParentID is null";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesLeadMgtQuestionStatus oSalesLeadMgtQuestionStatus = new SalesLeadMgtQuestionStatus();
                    oSalesLeadMgtQuestionStatus.ID = (int)reader["ID"];
                    oSalesLeadMgtQuestionStatus.Name = (string)reader["Name"];
                    InnerList.Add(oSalesLeadMgtQuestionStatus);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetLeadReason(int leadStatusID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select * From t_SalesLeadMgtQuestionStatus where ParentID is not null and ParentID = ? order by ID";
            try
            {
                cmd.CommandText = sSql;
                cmd.Parameters.AddWithValue("ParentID", leadStatusID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesLeadMgtQuestionStatus oSalesLeadMgtQuestionStatus = new SalesLeadMgtQuestionStatus();
                    oSalesLeadMgtQuestionStatus.ID = (int)reader["ID"];
                    oSalesLeadMgtQuestionStatus.Name = (string)reader["Name"];
                    InnerList.Add(oSalesLeadMgtQuestionStatus);
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

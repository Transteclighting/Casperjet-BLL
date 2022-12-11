using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class
{
    public class SalesLeadManagementQCQuestion
    {
        private int _nQuestionID;
        private string _sQuestion;
        private DateTime _dCreateDate;
        private int _nCreateUserID;
        private int _nUpdateUserID;
        private DateTime _dUpdateDate;
        private int _nIsActive;
        private string _sRemarks;



        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
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
        // Get set property for Question
        // </summary>
        public string Question
        {
            get { return _sQuestion; }
            set { _sQuestion = value.Trim(); }
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
        // Get set property for IsActive
        // </summary>
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
        }

        public void Add()
        {
            int nMaxQuestionID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([QuestionID]) FROM t_SalesLeadManagementQCQuestion";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxQuestionID = 1;
                }
                else
                {
                    nMaxQuestionID = Convert.ToInt32(maxID) + 1;
                }
                _nQuestionID = nMaxQuestionID;
                sSql = "INSERT INTO t_SalesLeadManagementQCQuestion (QuestionID, Question, CreateDate, CreateUserID, UpdateUserID, UpdateDate, IsActive) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("QuestionID", _nQuestionID);
                cmd.Parameters.AddWithValue("Question", _sQuestion);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);

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
                sSql = "UPDATE t_SalesLeadManagementQCQuestion SET Question = ?, CreateDate = ?, CreateUserID = ?, UpdateUserID = ?, UpdateDate = ?, IsActive = ? WHERE QuestionID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("Question", _sQuestion);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("IsActive", _nIsActive);

                cmd.Parameters.AddWithValue("QuestionID", _nQuestionID);

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
                sSql = "DELETE FROM t_SalesLeadManagementQCQuestion WHERE [QuestionID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("QuestionID", _nQuestionID);
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
                cmd.CommandText = "SELECT * FROM t_SalesLeadManagementQCQuestion where QuestionID =?";
                cmd.Parameters.AddWithValue("QuestionID", _nQuestionID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nQuestionID = (int)reader["QuestionID"];
                    _sQuestion = (string)reader["Question"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _nUpdateUserID = (int)reader["UpdateUserID"];
                    _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    _nIsActive = (int)reader["IsActive"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class SalesLeadMgtQCQuestions : CollectionBase
    {
        public SalesLeadManagementQCQuestion this[int i]
        {
            get { return (SalesLeadManagementQCQuestion)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(SalesLeadManagementQCQuestion oSalesLeadMgtQCQuestion)
        {
            InnerList.Add(oSalesLeadMgtQCQuestion);
        }
        public int GetIndex(int nQuestionID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].QuestionID == nQuestionID)
                {
                    return i;
                }
            }
            return -1;
        }
        public void GetQuestions()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_SalesLeadManagementQCQuestion where IsActive=" + (int)Dictionary.IsActive.Active + " order by Sort" ;
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SalesLeadManagementQCQuestion oSalesLeadMgtQCQuestion = new SalesLeadManagementQCQuestion();
                    oSalesLeadMgtQCQuestion.QuestionID = (int)reader["QuestionID"];
                    oSalesLeadMgtQCQuestion.Question = (string)reader["Question"];
                    InnerList.Add(oSalesLeadMgtQCQuestion);
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








using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Configuration;
using System.Diagnostics;
using System.Text.RegularExpressions;


namespace CJ.Class
{
    public class DBController
    {

        // following two statics are for singleton (not for this class context)
        private static volatile DBController instance = null;
        private static object syncRoot = new Object();
        public static OleDbConnection _conn;
        public static OleDbTransaction _tran;

        public DBController()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static DBController Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new DBController();
                        }
                    }
                }
                return instance;
            }
        }

        public OleDbConnection getNewConnection()
        {
            string connStr;
            connStr = ConfigurationManager.AppSettings["ConnectionString"];
            //Debug.Assert(connStr.Length != 0, "Connection string is zero length");
            //string like = "Passs";

            // Define a regular expression and Find matches.
            //MatchCollection matches =  LikeExpressionToRegexPattern(like).Matches(text);
            //string s = Regex.Match(connStr, like).Value;

            //Result.
            //if (matches.Count > 0)
            //{
            //    //Yes
            //}
            //else
            //{
            //    //No
            //}
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = connStr;
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
               
                throw ex;
            }

            return conn;
        }

        /// <summary>
        /// opens a new connection ( not transaction )
        /// </summary>
        public bool OpenNewConnection()
        {
            try
            {

                OleDbConnection conn = getNewConnection();
                _conn = conn;
                return true;
            }
            catch (Exception e)
            {
                throw e;
                AppLogger.LogFatal("Databse connection close or permisssion problem");
                return false;
            }
        }

        /// <summary>
        /// close the connection (not a transaction )
        /// </summary>
        /// <param name="connectionID"></param>
        /// <returns>returns false if failes, else returns true</returns>
        public bool CloseConnection()
        {
            if (_conn == null)
            {
                return false;
            }
            _conn.Close();
            return true;

        }  // end of CloseConnection method

        /// <summary>
        /// opens a new connection then starts transaction on that connection
        /// </summary>
        public bool BeginNewTransaction()
        {
            try
            {
                _conn = getNewConnection();
                _tran = _conn.BeginTransaction();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }

        }  // end of BeginNewTransaction method

        /// <summary>
        /// commits a transaction
        /// </summary>
        /// <param name="connectionID"></param>
        /// <returns>true if succed, else false</returns>
        public bool CommitTransaction()
        {
            if (_tran == null)
            {
                return false;
            }

            try
            {
                _tran.Commit();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                try
                {
                    _tran.Rollback();

                }
                catch
                {
                    Debug.WriteLine(e.Message);
                }

                return false;
            }
            finally
            {
                _conn.Close();
            }

        }  // end of CommitTransaction method

        /// <summary>
        /// rollback transaction
        /// </summary>
        /// <param name="connectionID"></param>
        /// <returns>true if succeds, else false</returns>
        public bool RollbackTransaction()
        {
            if (_tran == null)
            {
                return false;
            }

            try
            {
                _tran.Rollback();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
            finally
            {
                _conn.Close();
            }

        }  // end of RollbackTransaction

        public OleDbCommand GetCommand()
        {
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = _conn;
            cmd.Transaction = _tran;
            return cmd;
        }

        public bool CheckConnection()
        {
            try
            {
                if (_conn.State == System.Data.ConnectionState.Open)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }

        }
        public bool CommitTran()
        {
            if (_tran == null)
            {
                return false;
            }

            try
            {
                _tran.Commit();
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                try
                {
                    _tran.Rollback();

                }
                catch
                {
                    Debug.WriteLine(e.Message);
                }

                return false;
            }

        }
    }
}

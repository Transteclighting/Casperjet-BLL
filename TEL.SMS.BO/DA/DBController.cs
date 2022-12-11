using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Configuration;
using System.Diagnostics;

namespace TEL.SMS.BO.DA
{
    /// <summary>
    /// Summary description for DBController.
    /// </summary>

    public sealed class DBController
    {
        // following two statics are for singleton (not for this class context)
        private static volatile DBController instance = null;
        private static object syncRoot = new Object();
        private static OleDbConnection _conn;
        private static OleDbTransaction _tran;

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

        private OleDbConnection getNewConnection()
        {
            string connStr;
            connStr = ConfigurationManager.AppSettings["ConnectionString"];
            //Debug.Assert(connStr.Length != 0, "Connection string is zero length");
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



        private OleDbConnection getNewConnectionMDB()
        {
            string connStr;
            connStr = ConfigurationManager.AppSettings["ConnectionStringMDB"];
            //Debug.Assert(connStr.Length != 0, "Connection string is zero length");
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
        public bool OpenNewConnectionMDB()
        {
            try
            {

                OleDbConnection conn = getNewConnectionMDB();
                _conn = conn;
                return true;
            }
            catch (Exception e)
            {
                throw e;
                return false;
            }
        }

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
        /// opens a new connection then starts transaction on that connection
        /// </summary>
        public bool BeginNewTransactionMDB()
        {
            try
            {
                _conn = getNewConnectionMDB();
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

    }
}

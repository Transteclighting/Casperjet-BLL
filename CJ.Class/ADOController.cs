using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Collections;
using System.Diagnostics;
using System.IO;


enum CONN_TYPE
{
    CONNECTION,
    TRANSACTION,
    NO_CONNECTION
}

class CConnectionInfo
{
    public OleDbConnection m_Conn = null;
    public OleDbTransaction m_Tx = null;
    public int m_ID = 0;
    public CONN_TYPE m_ConnType = CONN_TYPE.NO_CONNECTION;
}

namespace CJ.Class
{
    /// <summary>
    /// Public Class ADOController
    /// </summary>
    public class ADOController
    {
        // following two statics are for singleton (not for this class context)
        private static volatile ADOController instance = null;
        private static object syncRoot = new Object();

        private int m_nConnID = 101;
        private Hashtable m_hashConn = new Hashtable();


        private ADOController()
        {

        }
        /// <summary>
        /// Public ADOController Instance
        /// </summary>
        public static ADOController Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new ADOController();
                        }
                    }
                }
                return instance;
            }
        }

        private OleDbConnection getNewConnection()
        {
            string connStr;
            connStr = ConfigurationSettings.AppSettings["ConnectionString"];
            Debug.Assert(connStr.Length != 0, "Connection string is zero length");
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
        /// <returns>return -1 if operation fails, else return a connection id</returns>
        public int OpenNewConnection()
        {
            try
            {

                OleDbConnection conn = getNewConnection();
                CConnectionInfo connInfo = new CConnectionInfo();
                connInfo.m_Conn = conn;
                connInfo.m_ConnType = CONN_TYPE.CONNECTION;
                connInfo.m_ID = m_nConnID++;
                m_hashConn.Add(connInfo.m_ID, connInfo);
                return connInfo.m_ID;
            }
            catch (Exception ex)
            {
                AppLogger.LogFatal("Could not open new database connection.", ex);
                return -1;
            }
        }


        /// <summary>
        /// close the connection (not a transaction )
        /// </summary>
        /// <param name="connectionID"></param>
        /// <returns>returns false if failes, else returns true</returns>
        public bool CloseConnection(int connectionID)
        {
            CConnectionInfo connInfo = (CConnectionInfo)this.m_hashConn[connectionID];
            if (connInfo == null)
            {
                AppLogger.LogWarning("Connection ID '" + connectionID + "' does not exist in connection pool.\nCould not close close connection.");
                return false;
            }
            string sErrorMsg = "Connection ID '" + connectionID + "' cannot be closed using CloseConnection method.\n" +
                               "Use CommitTransaction or RollbackTransaction method.";

            if (connInfo.m_ConnType != CONN_TYPE.CONNECTION)
            {
                AppLogger.LogWarning(sErrorMsg);
                return false;
            }

            connInfo.m_Conn.Close();
            return true;

        }  // end of CloseConnection method

        /// <summary>
        /// opens a new connection then starts transaction on that connection
        /// </summary>
        /// <returns>returns -1 if faiels, else returns transaction id</returns>
        public int BeginNewTransaction()
        {
            CConnectionInfo connInfo = new CConnectionInfo();
            try
            {
                connInfo.m_Conn = getNewConnection();
                connInfo.m_Tx = connInfo.m_Conn.BeginTransaction();
                connInfo.m_ID = this.m_nConnID++;
                connInfo.m_ConnType = CONN_TYPE.TRANSACTION;
                m_hashConn.Add(connInfo.m_ID, connInfo);
                return connInfo.m_ID;
            }
            catch (Exception ex)
            {
                AppLogger.LogFatal("Could not open new database transaction.", ex);
                return -1;
            }

        }  // end of BeginNewTransaction method

        /// <summary>
        /// commits a transaction
        /// </summary>
        /// <param name="connectionID"></param>
        /// <returns>true if succed, else false</returns>
        public bool CommitTransaction(int connectionID)
        {
            CConnectionInfo connInfo = (CConnectionInfo)this.m_hashConn[connectionID];

            if (connInfo == null)
            {
                AppLogger.LogWarning("Connection ID '" + connectionID + "' does not exist in connection pool.\nCould not close close connection.");
                return false;
            }
            string sErrorMsg = "Connection ID '" + connectionID + "' is not in transaction mode and cannot be commited using CommitTransaction method.\n" +
              "You may use CloseConnection method to close this connection";

            if (connInfo.m_ConnType != CONN_TYPE.TRANSACTION)
            {
                AppLogger.LogWarning(sErrorMsg);
                return false;
            }


            try
            {
                connInfo.m_Tx.Commit();
                return true;
            }
            catch (Exception ex)
            {
                AppLogger.LogFatal("Could not commit transaction: " + connectionID + ".", ex);
                try
                {
                    connInfo.m_Tx.Rollback();
                }
                catch (Exception exInner)
                {
                    AppLogger.LogFatal("Could not rollback transaction: " + connectionID + ".", exInner);
                }

                return false;
            }
            finally
            {
                connInfo.m_Conn.Close();
                this.m_hashConn.Remove(connectionID);
            }

        }  // end of CommitTransaction method

        /// <summary>
        /// rollback transaction
        /// </summary>
        /// <param name="connectionID"></param>
        /// <returns>true if succeds, else false</returns>
        public bool RollbackTransaction(int connectionID)
        {
            CConnectionInfo connInfo = (CConnectionInfo)this.m_hashConn[connectionID];
            if (connInfo == null)
            {
                AppLogger.LogWarning("Connection ID '" + connectionID + "' does not exist in connection pool.\nCould not close close connection.");
                return false;
            }
            string sErrorMsg = "Connection ID '" + connectionID + "' is not in transaction mode and cannot be rolledback using RollbackTransaction method.\n" +
              "You may use CloseConnection method to close this connection";

            if (connInfo.m_ConnType != CONN_TYPE.TRANSACTION)
            {
                AppLogger.LogWarning(sErrorMsg);
                return false;
            }



            try
            {
                connInfo.m_Tx.Rollback();
                return true;
            }
            catch (Exception ex)
            {
                AppLogger.LogFatal("Could not rollback transaction: " + connectionID + ".", ex);
                return false;
            }
            finally
            {
                connInfo.m_Conn.Close();
                this.m_hashConn.Remove(connectionID);
            }

        }  // end of RollbackTransaction


        /// <summary>
        /// in case of connection, it close the connection. in case of transaction it rollback
        /// transaction.  then it removes CConnectionInfo from hashtable
        /// </summary>
        /// <param name="connectionID">either a connection id, or a transaction id</param>
        private void invalidateConnectionID(int connectionID)
        {
            CConnectionInfo connInfo = (CConnectionInfo)this.m_hashConn[connectionID];
            if (connInfo == null)
            {
                return;
            }

            if (connInfo.m_ConnType == CONN_TYPE.CONNECTION)
            {
                connInfo.m_Conn.Close();
                return;
            }

            if (connInfo.m_ConnType == CONN_TYPE.TRANSACTION)
            {
                this.RollbackTransaction(connectionID);
            }  // end of if type transaction



        }   // end of InvalidateConnectionID


        /// <summary>
        /// see OleDbCommand.ExecuteNonQuery on MSDN fordetail
        /// </summary>
        /// <param name="cmdInsertUpdateDelete">oledbcommand</param>
        /// <param name="connectionID">database connection to use</param>
        /// <param name="bError">notfy the caller in case of any erro</param>
        /// <returns>number of rows affected by the query</returns>
        public int ExecuteNonQuery(OleDbCommand cmdInsertUpdateDelete, int connectionID, ref bool bError)
        {
            CConnectionInfo connInfo = (CConnectionInfo)this.m_hashConn[connectionID];
            if (connInfo == null)
            {
                AppLogger.LogWarning("Connection ID '" + connectionID + "' does not exist in connection pool.\nCould not execute ExecuteNonQuery method.");
                bError = true;
                return -1;
            }

            OleDbConnection conn = connInfo.m_Conn;
            OleDbTransaction tx = connInfo.m_Tx;

            cmdInsertUpdateDelete.Connection = conn;
            cmdInsertUpdateDelete.Transaction = tx;
            try
            {
                bError = false;
                return cmdInsertUpdateDelete.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                AppLogger.LogFatal("Error executing ExecuteNonQuery method.\n" + cmdInsertUpdateDelete.CommandText, ex);
                invalidateConnectionID(connectionID);
                bError = true;
                return -1;
            }
            finally
            {
                cmdInsertUpdateDelete.Transaction = null;
                //cmdInsertUpdateDelete.Connection = null;
            }

        }   // end of ExecuteNonQuery

        /// <summary>
        /// see OleDbCommand.ExecuteReader on MSDN for detail
        /// </summary>
        /// <param name="cmdSelect"></param>
        /// <param name="connectionID"></param>
        /// <param name="bError"></param>
        /// <returns></returns>
        public OleDbDataReader ExecuteReader(OleDbCommand cmdSelect, int connectionID, ref bool bError)
        {
            CConnectionInfo connInfo = (CConnectionInfo)this.m_hashConn[connectionID];
            if (connInfo == null)
            {
                AppLogger.LogWarning("Connection ID '" + connectionID + "' does not exist in connection pool.\nCould not execute ExecuteNonQuery method.");
                bError = true;
                return null;
            }

            OleDbConnection conn = connInfo.m_Conn;
            OleDbTransaction tx = connInfo.m_Tx;

            cmdSelect.Connection = conn;
            cmdSelect.Transaction = tx;

            try
            {
                bError = false;
                return cmdSelect.ExecuteReader();
            }
            catch (Exception ex)
            {
                AppLogger.LogFatal("Error executing ExecuteReader method.", ex);
                invalidateConnectionID(connectionID);
                bError = true;
                return null;
            }
            finally
            {
                cmdSelect.Transaction = null;
                cmdSelect.Connection = null;
            }
        }  // end of ExecuteReader method

        /// <summary>
        /// see OleDbCommand.ExecuteScalar on MSDN for detail
        /// </summary>
        /// <param name="cmdSelect"></param>
        /// <param name="connectionID"></param>
        /// <param name="bError"></param>
        /// <returns></returns>
        public object ExecuteScalar(OleDbCommand cmdSelect, int connectionID, ref bool bError)
        {
            CConnectionInfo connInfo = (CConnectionInfo)this.m_hashConn[connectionID];
            if (connInfo == null)
            {
                AppLogger.LogWarning("Connection ID '" + connectionID + "' does not exist in connection pool.\nCould not execute ExecuteScalar method.");
                bError = true;
                return null;
            }
            OleDbConnection conn = connInfo.m_Conn;
            OleDbTransaction tx = connInfo.m_Tx;

            cmdSelect.Connection = conn;
            cmdSelect.Transaction = tx;
            try
            {
                bError = false;
                return cmdSelect.ExecuteScalar();
            }
            catch (Exception ex)
            {
                AppLogger.LogFatal("Error executing ExecuteScalar method.", ex);
                invalidateConnectionID(connectionID);
                bError = true;
                return null;
            }
            finally
            {
                cmdSelect.Transaction = null;
                cmdSelect.Connection = null;
            }
        }  // end of ExecuteScalar method
        /// <summary>
        /// see OleDbCommand.Fill on MSDN for detail
        /// </summary>
        /// <param name="adapter"></param>
        /// <param name="dataSet"></param>
        /// <param name="connectionID"></param>
        /// <param name="bError"></param>
        /// <returns></returns>
        public int Fill(OleDbDataAdapter adapter, DataSet dataSet, int connectionID, ref bool bError)
        {
            CConnectionInfo connInfo = (CConnectionInfo)this.m_hashConn[connectionID];
            if (connInfo == null)
            {
                AppLogger.LogWarning("Connection ID '" + connectionID + "' does not exist in connection pool.\nCould not execute Fill method.");
                bError = true;
                return -1;
            }

            OleDbConnection conn = connInfo.m_Conn;
            OleDbTransaction tx = connInfo.m_Tx;

            setupDataAdapter(adapter, conn, tx);

            try
            {
                bError = false;
                return adapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                AppLogger.LogFatal("Error executing Fill(1) method." + adapter.SelectCommand.CommandText, ex);
                invalidateConnectionID(connectionID);
                bError = true;
                return -1;
            }
            finally
            {
                resetDataAdapter(adapter);
            }
        }  // end of Fill method

        /// <summary>
        /// see OleDbCommand.Fill on MSDN for detail
        /// </summary>
        /// <param name="adapter"></param>
        /// <param name="dataSet"></param>
        /// <param name="srcTable"></param>
        /// <param name="connectionID"></param>
        /// <param name="bError"></param>
        /// <returns></returns>
        public int Fill(OleDbDataAdapter adapter, DataSet dataSet, string srcTable, int connectionID, ref bool bError)
        {
            CConnectionInfo connInfo = (CConnectionInfo)this.m_hashConn[connectionID];
            if (connInfo == null)
            {
                AppLogger.LogWarning("Connection ID '" + connectionID + "' does not exist in connection pool.\nCould not execute Fill method.");
                bError = true;
                return -1;
            }

            OleDbConnection conn = connInfo.m_Conn;
            OleDbTransaction tx = connInfo.m_Tx;

            setupDataAdapter(adapter, conn, tx);

            try
            {
                bError = false;
                return adapter.Fill(dataSet, srcTable);
            }
            catch (Exception ex)
            {
                AppLogger.LogFatal("Error executing Fill(2) method." + adapter.SelectCommand.CommandText, ex);
                invalidateConnectionID(connectionID);
                bError = true;
                return -1;
            }
            finally
            {
                resetDataAdapter(adapter);
            }
        }  // end of Fill method

        /// <summary>
        /// see OleDbCommand.Update on MSDN for detail
        /// </summary>
        /// <param name="adapter"></param>
        /// <param name="dataSet"></param>
        /// <param name="connectionID"></param>
        /// <param name="bError"></param>
        /// <returns></returns>
        public int Update(OleDbDataAdapter adapter, DataSet dataSet, int connectionID, ref bool bError)
        {
            CConnectionInfo connInfo = (CConnectionInfo)this.m_hashConn[connectionID];
            if (connInfo == null)
            {
                AppLogger.LogWarning("Connection ID '" + connectionID + "' does not exist in connection pool.\nCould not execute Update method.");
                bError = true;
                return -1;
            }

            OleDbConnection conn = connInfo.m_Conn;
            OleDbTransaction tx = connInfo.m_Tx;

            setupDataAdapter(adapter, conn, tx);

            try
            {
                bError = false;
                return adapter.Update(dataSet);
            }
            catch (Exception ex)
            {
                AppLogger.LogFatal("Error executing Fill(update) method.", ex);
                invalidateConnectionID(connectionID);
                bError = true;
                return -1;
            }
            finally
            {
                resetDataAdapter(adapter);
            }

        }  // end of Update method

        /// <summary>
        /// see OleDbCommand.Update on MSDN for detail
        /// </summary>
        /// <param name="adapter"></param>
        /// <param name="dataSet"></param>
        /// <param name="srcTable"></param>
        /// <param name="connectionID"></param>
        /// <param name="bError"></param>
        /// <returns></returns>
        public int Update(OleDbDataAdapter adapter, DataSet dataSet, string srcTable, int connectionID, ref bool bError)
        {
            CConnectionInfo connInfo = (CConnectionInfo)this.m_hashConn[connectionID];
            if (connInfo == null)
            {
                AppLogger.LogWarning("Connection ID '" + connectionID + "' does not exist in connection pool.\nCould not execute Update method.");
                bError = true;
                return -1;
            }
            OleDbConnection conn = connInfo.m_Conn;
            OleDbTransaction tx = connInfo.m_Tx;

            setupDataAdapter(adapter, conn, tx);

            try
            {
                bError = false;
                return adapter.Update(dataSet, srcTable);

            }
            catch (Exception ex)
            {
                AppLogger.LogFatal("Error executing Fill(update) method.", ex);
                invalidateConnectionID(connectionID);
                bError = true;
                return -1;
            }
            finally
            {
                resetDataAdapter(adapter);
            }

        }  // end of Update method


        private void setupDataAdapter(OleDbDataAdapter adapter,
                                    OleDbConnection conn,
                                    OleDbTransaction tx)
        {
            if (adapter == null)
            {
                return;
            }

            if (adapter.SelectCommand != null)
            {
                adapter.SelectCommand.Connection = conn;
                adapter.SelectCommand.Transaction = tx;
            }

            if (adapter.InsertCommand != null)
            {
                adapter.InsertCommand.Connection = conn;
                adapter.InsertCommand.Transaction = tx;
            }

            if (adapter.UpdateCommand != null)
            {
                adapter.UpdateCommand.Connection = conn;
                adapter.UpdateCommand.Transaction = tx;
            }

            if (adapter.DeleteCommand != null)
            {
                adapter.DeleteCommand.Connection = conn;
                adapter.DeleteCommand.Transaction = tx;
            }
        }

        private void resetDataAdapter(OleDbDataAdapter adapter)
        {
            if (adapter == null)
            {
                return;
            }
            if (adapter.SelectCommand != null)
            {
                adapter.SelectCommand.Connection = null;
                adapter.SelectCommand.Transaction = null;
            }

            if (adapter.InsertCommand != null)
            {
                adapter.InsertCommand.Connection = null;
                adapter.InsertCommand.Transaction = null;
            }

            if (adapter.UpdateCommand != null)
            {
                adapter.UpdateCommand.Connection = null;
                adapter.UpdateCommand.Transaction = null;
            }

            if (adapter.DeleteCommand != null)
            {
                adapter.DeleteCommand.Connection = null;
                adapter.DeleteCommand.Transaction = null;
            }

        } // end of resetDataAdapter
    }
}

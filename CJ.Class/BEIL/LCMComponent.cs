// <summary>
// Company: Transcom Electronics Limited
// Author: Shavagata Saha
// Date: May 15, 2017
// Time : 11:34 AM
// Description: Class for LCMComponent.
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
    public class LCMComponentItem
    {
        private int _nID;
        private int _nComponentID;
        private string _sSerialNo;
        private string _sRemarks;
        private DateTime _dCreateDate;
        private int _nCreateUserID;
        private string _sComponentName;
        public string ComponentName
        {
            get { return _sComponentName; }
            set { _sComponentName = value.Trim(); }
        }

        private int _nDefectiveID;
        private int _nSymtom;
        public int Symtom
        {
            get { return _nSymtom; }
            set { _nSymtom = value; }
        }
        private int _nRootcause;
        public int Rootcause
        {
            get { return _nRootcause; }
            set { _nRootcause = value; }
        }

        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for ComponentID
        // </summary>
        public int ComponentID
        {
            get { return _nComponentID; }
            set { _nComponentID = value; }
        }

        // <summary>
        // Get set property for SerialNo
        // </summary>
        public string SerialNo
        {
            get { return _sSerialNo; }
            set { _sSerialNo = value.Trim(); }
        }

        // <summary>
        // Get set property for Remarks
        // </summary>
        public string Remarks
        {
            get { return _sRemarks; }
            set { _sRemarks = value.Trim(); }
        }

        private string _sQcRemarks;
        public string QcRemarks
        {
            get { return _sQcRemarks; }
            set { _sQcRemarks = value.Trim(); }
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

        private int _nStatus;
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

        private int _nQCStatus;
        public int QCStatus
        {
            get { return _nQCStatus; }
            set { _nQCStatus = value; }
        }

        public void Add()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "INSERT INTO t_LCMComponentItem (ID, ComponentID, SerialNo, Remarks, CreateDate, CreateUserID, Status) VALUES(?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("ComponentID", _nComponentID);
                cmd.Parameters.AddWithValue("SerialNo", _sSerialNo);
                if (_sRemarks != null)
                {
                    cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                }
                else
                {
                    cmd.Parameters.AddWithValue("Remarks", null);
                }
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void AddDefectiveComponent()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([DefectiveID]) FROM t_LCMDefectiveComponent";
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
                _nDefectiveID = nMaxID;

                sSql = "INSERT INTO t_LCMDefectiveComponent (DefectiveID, ID, ComponentID, SerialNo, CreateUserID, CreateDate, Status, Remarks, Symtom, Rootcause) VALUES(?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("DefectiveID", _nDefectiveID);
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("ComponentID", _nComponentID);
                cmd.Parameters.AddWithValue("SerialNo", _sSerialNo);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);
                cmd.Parameters.AddWithValue("Status", _nQCStatus);
                if (_sRemarks != null)
                {
                    cmd.Parameters.AddWithValue("Remarks", _sQcRemarks);
                }
                else
                {
                    cmd.Parameters.AddWithValue("Remarks", null);
                }

                cmd.Parameters.AddWithValue("Symtom", _nSymtom);
                cmd.Parameters.AddWithValue("Rootcause", _nRootcause);
              
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
                sSql = "UPDATE t_LCMComponentItem SET ComponentID = ?, SerialNo = ?, Remarks = ?, CreateDate = ?, CreateUserID = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ComponentID", _nComponentID);
                cmd.Parameters.AddWithValue("SerialNo", _sSerialNo);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);

                cmd.Parameters.AddWithValue("ID", _nID);

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
                sSql = "DELETE FROM t_LCMComponentItem WHERE [ID]=?";
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
        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_LCMComponentItem where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _nComponentID = (int)reader["ComponentID"];
                    _sSerialNo = (string)reader["SerialNo"];
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        _sRemarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        _sRemarks = "";
                    }
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nCreateUserID = (int)reader["CreateUserID"];
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

    public class LCMComponentItems : CollectionBase
    {
        public void Add(LCMComponentItem oLCMComponentItem)
        {
            InnerList.Add(oLCMComponentItem);
        }

        public void Refresh(int nID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_LCMComponentItem where ID =?";
                cmd.Parameters.AddWithValue("ID", nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    LCMComponentItem oItem = new LCMComponentItem();
                    oItem.ID = (int)reader["ID"];
                    oItem.ComponentID = (int)reader["ComponentID"];
                    oItem.SerialNo = (string)reader["SerialNo"];
                    if (reader["Remarks"] != DBNull.Value)
                    {
                        oItem.Remarks = (string)reader["Remarks"];
                    }
                    else
                    {
                        oItem.Remarks = "";
                    }
                    oItem.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oItem.CreateUserID = (int)reader["CreateUserID"];
                    nCount++;

                    InnerList.Add(oItem);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class LCMComponent : CollectionBase
    {
        public LCMComponentItem this[int i]
        {
            get { return (LCMComponentItem)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(LCMComponentItem oLCMComponentItem)
        {
            InnerList.Add(oLCMComponentItem);
        }
        private int _nID;
        private string _sChassisSerial;
        private string _sManualSerial;
        public string ManualSerial
        {
            get { return _sManualSerial; }
            set { _sManualSerial = value.Trim(); }
        }
        private DateTime _dCreateDate;
        private int _nCreateUserID;
        private DateTime _dUpdateDate;
        private int _nUpdateUserID;
        private string _sRemarks;
        private int _nStatus;
        private string _sCreateUserName;
        private string _sComponentName;
        private int _nTargetQty;
        public int TargetQty
        {
            get { return _nTargetQty; }
            set { _nTargetQty = value; }
        }
        public string ComponentName
        {
            get { return _sComponentName; }
            set { _sComponentName = value.Trim(); }
        }

        private int _nComponentID;
        public int ComponentID
        {
            get { return _nComponentID; }
            set { _nComponentID = value; }
        }
        private string _sDefectiveSerialNo;
        public string DefectiveSerialNo
        {
            get { return _sDefectiveSerialNo; }
            set { _sDefectiveSerialNo = value.Trim(); }
        }
        private string _sReplacedSerialNo;
        public string ReplacedSerialNo
        {
            get { return _sReplacedSerialNo; }
            set { _sReplacedSerialNo = value.Trim(); }
        }

        private int _nDefectID;
        public int DefectID
        {
            get { return _nDefectID; }
            set { _nDefectID = value; }
        }

        private string _sDefectName;
        public string DefectName
        {
            get { return _sDefectName; }
            set { _sDefectName = value.Trim(); }
        }
        private DateTime _dDefectDate;

        public DateTime DefectDate
        {
            get { return _dDefectDate; }
            set { _dDefectDate = value; }
        }

        private DateTime _dReplaceDate;
        public DateTime ReplaceDate
        {
            get { return _dReplaceDate; }
            set { _dReplaceDate = value; }
        }
        // <summary>
        // Get set property for ID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        // <summary>
        // Get set property for ChassisSerial
        // </summary>
        public string ChassisSerial
        {
            get { return _sChassisSerial; }
            set { _sChassisSerial = value.Trim(); }
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
        // Get set property for CreateUserName
        // </summary>
        public string CreateUserName
        {
            get { return _sCreateUserName; }
            set { _sCreateUserName = value.Trim(); }
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
        // Get set property for UpdateUserID
        // </summary>
        public int UpdateUserID
        {
            get { return _nUpdateUserID; }
            set { _nUpdateUserID = value; }
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
        // Get set property for Status
        // </summary>
        public int Status
        {
            get { return _nStatus; }
            set { _nStatus = value; }
        }

        private string _sSymtomName;
        public string SymtomName
        {
            get { return _sSymtomName; }
            set { _sSymtomName = value.Trim(); }
        }

        private int _nRootCause;
        public int RootCause
        {
            get { return _nRootCause; }
            set { _nRootCause = value; }
        }
        private string _sRootCauseName;
        public string RootCauseName
        {
            get { return _sRootCauseName; }
            set { _sRootCauseName = value.Trim(); }
        }
        private string _sStatusName;
        public string StatusName
        {
            get { return _sStatusName; }
            set { _sStatusName = value.Trim(); }
        }

        private int _nAGID;
        public int AGID
        {
            get { return _nAGID; }
            set { _nAGID = value; }
        }

        private string _sAGName;
        public string AGName
        {
            get { return _sAGName; }
            set { _sAGName = value.Trim(); }
        }

        private int _nBrandID;
        public int BrandID
        {
            get { return _nBrandID; }
            set { _nBrandID = value; }
        }

        private int _nProductID;
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_LCMComponent";
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
                sSql = "INSERT INTO t_LCMComponent (ID, ManualSerial, ChassisSerial, CreateDate, CreateUserID, UpdateDate, UpdateUserID, Remarks, Status, AGID,BrandID,ProductID) VALUES(?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("ManualSerial", _sManualSerial);
                cmd.Parameters.AddWithValue("ChassisSerial", _sChassisSerial);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", null);
                cmd.Parameters.AddWithValue("UpdateUserID", null);
                if (_sRemarks != null)
                {
                    cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                }
                else
                {
                    cmd.Parameters.AddWithValue("Remarks", null);
                }

                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("AGID", _nAGID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);

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
                sSql = "UPDATE t_LCMComponent SET ChassisSerial = ?, UpdateDate = ?, UpdateUserID = ?, Remarks = ?, Status = ?,AGID=?,BrandID=?,ProductID=? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ChassisSerial", _sChassisSerial);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("Remarks", _sRemarks);
                cmd.Parameters.AddWithValue("Status", _nStatus);
                cmd.Parameters.AddWithValue("AGID", _nAGID);
                cmd.Parameters.AddWithValue("BrandID", _nBrandID);
                cmd.Parameters.AddWithValue("ProductID", _nProductID);

                cmd.Parameters.AddWithValue("ID", _nID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void UpdateStatus()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_LCMComponent SET UpdateDate = ?, UpdateUserID = ?, Status = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _nUpdateUserID);
                cmd.Parameters.AddWithValue("Status", _nStatus);

                cmd.Parameters.AddWithValue("ID", _nID);

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
                sSql = "DELETE FROM t_LCMComponent WHERE [ID]=?";
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
        public void Refresh()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_LCMComponent where ID =?";
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _sChassisSerial = (string)reader["ChassisSerial"];
                    _dCreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    _nCreateUserID = (int)reader["CreateUserID"];
                    _dUpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    _nUpdateUserID = (int)reader["UpdateUserID"];
                    _sRemarks = (string)reader["Remarks"];
                    _nStatus = (int)reader["Status"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        //public int Refresh(string sSerial, int nStatus, int nType)
        public int Refresh(string sSerial, int nType)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            int nID = 0;
            try
            {
                if (nType == 1)
                {
                    cmd.CommandText = "SELECT * FROM t_LCMComponent where ChassisSerial ='" + sSerial + "'";// and Status=" + nStatus + "";
                }
                else
                {
                    cmd.CommandText = "SELECT * FROM t_LCMComponent where ManualSerial ='" + sSerial + "'";// and Status=" + nStatus + "";
                }

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    nID = (int)reader["ID"];
                    _nStatus = (int)reader["Status"];
                    nCount++;
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return nID;
        }
        public void GetComponent(string sChassisSerial)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "Select a.ID,ComponentID,  " +
                                "ComponentName=Case when ComponentID=1 then 'Chassis'   " +
                                "when ComponentID=2 then 'LED Bar'   " +
                                "when ComponentID=3 then 'Opencell'  " +
                                "when ComponentID=4 then 'T-Con'  " +
                                "else 'Others' end,SerialNo,a.CreateDate,a.CreateUserID,   " +
                                "a.Status,isnull(a.Remarks,'') Remarks   " +
                                "From t_LCMComponentItem a,t_LCMComponent b   " +
                                "where a.ID=b.ID and ChassisSerial='" + sChassisSerial + "'";


                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    LCMComponentItem oItem = new LCMComponentItem();

                    oItem.ID = int.Parse(reader["ID"].ToString());
                    oItem.ComponentID = int.Parse(reader["ComponentID"].ToString());
                    oItem.ComponentName = (reader["ComponentName"].ToString());
                    oItem.SerialNo = (reader["SerialNo"].ToString());
                    oItem.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oItem.CreateUserID = int.Parse(reader["CreateUserID"].ToString());
                    oItem.Status = int.Parse(reader["Status"].ToString());
                    oItem.Remarks = (reader["Remarks"].ToString());
                    InnerList.Add(oItem);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void AddLCMTarget()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ID]) FROM t_LCMProductionTarget";
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
                sSql = "INSERT INTO t_LCMProductionTarget (ID, AGID, TargetDate, TargetQty) VALUES(?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("AGID", _nAGID);
                cmd.Parameters.AddWithValue("TargetDate", _dCreateDate);
                cmd.Parameters.AddWithValue("TargetQty", _nTargetQty);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void EditLCMTarget()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_LCMProductionTarget SET AGID = ?, TargetDate = ?, TargetQty = ? WHERE ID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("AGID", _nAGID);
                cmd.Parameters.AddWithValue("TargetDate", _dCreateDate);
                cmd.Parameters.AddWithValue("TargetQty", _nTargetQty);

                cmd.Parameters.AddWithValue("ID", _nID);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetChassisSerial(string sManualSerial)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = "SELECT * FROM t_LCMComponent where ManualSerial = '" + sManualSerial + "'";
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nID = (int)reader["ID"];
                    _sChassisSerial = (string)reader["ChassisSerial"];
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
    public class LCMComponents : CollectionBase
    {
        public LCMComponent this[int i]
        {
            get { return (LCMComponent)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(LCMComponent oLCMComponent)
        {
            InnerList.Add(oLCMComponent);
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
        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "SELECT * FROM t_LCMComponent";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    LCMComponent oLCMComponent = new LCMComponent();
                    oLCMComponent.ID = (int)reader["ID"];
                    oLCMComponent.ChassisSerial = (string)reader["ChassisSerial"];
                    oLCMComponent.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oLCMComponent.CreateUserID = (int)reader["CreateUserID"];
                    oLCMComponent.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    oLCMComponent.UpdateUserID = (int)reader["UpdateUserID"];
                    oLCMComponent.Remarks = (string)reader["Remarks"];
                    oLCMComponent.Status = (int)reader["Status"];
                    InnerList.Add(oLCMComponent);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Refresh(DateTime dFromDate, DateTime dToDate, int nStatus, string sChassisSL, bool IsCheck, int nType, int nAGID)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";
            if (nType == (int)Dictionary.LCMStatus.Stage_1)
            {
                sSql = "Select ID,ChassisSerial,CreateDate,CreateUserID,UserName,AGID,PdtGroupName as AGName,  " +
                    "isnull(Remarks,'') Remarks,Status,BrandID,isnull(a.ProductID,0) ProductID From t_LCMComponent a,t_User b,t_ProductGroup c  " +
                    "where a.CreateUserID=b.UserID and a.AGID=c.PDTGroupID";
            }
            else if (nType == (int)Dictionary.LCMStatus.Stage_4)
            {
                sSql = "Select ID,ChassisSerial,CreateDate,CreateUserID,UserName,AGID,PdtGroupName as AGName,  " +
                       "isnull(Remarks,'') Remarks,Status,BrandID From t_LCMComponent a,t_User b,t_ProductGroup c  " +
                       "where a.CreateUserID=b.UserID and a.AGID=c.PDTGroupID and   " +
                       "ID In (Select ID From t_LCMComponentItem where Status=" + (int)Dictionary.YesOrNoStatus.NO + " group by ID)";
            }
            if (IsCheck == false)
            {
                sSql = sSql + " AND CreateDate between '" + dFromDate + "' and '" + dToDate + "' and CreateDate<'" + dToDate + "' ";
            }

            if (nStatus != -1)
            {
                sSql = sSql + " AND Status=" + nStatus + "";
            }
            if (sChassisSL != "")
            {
                sSql = sSql + " AND ChassisSerial like '%" + sChassisSL + "%'";
            }

            if (nAGID != -1)
            {
                sSql = sSql + " AND AGID=" + nAGID + "";
            }
            sSql = sSql + " Order by ID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    LCMComponent oLCMComponent = new LCMComponent();
                    oLCMComponent.ID = (int)reader["ID"];
                    oLCMComponent.ChassisSerial = (string)reader["ChassisSerial"];
                    oLCMComponent.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());
                    oLCMComponent.CreateUserID = (int)reader["CreateUserID"];
                    oLCMComponent.CreateUserName = (string)reader["UserName"];
                    oLCMComponent.Remarks = (string)reader["Remarks"];
                    oLCMComponent.Status = (int)reader["Status"];
                    oLCMComponent.AGID = (int)reader["AGID"];
                    oLCMComponent.AGName = (string)reader["AGName"]; 
                    oLCMComponent.BrandID = (int)reader["BrandID"];
                    if (nType != (int)Dictionary.LCMStatus.Stage_4)
                    {
                        oLCMComponent.ProductID = (int)reader["ProductID"];
                    }
                    
                    InnerList.Add(oLCMComponent);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void RefreshForReport(DateTime dFromDate, DateTime dToDate, bool IsCheck)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";


            sSql = "Select ComponentName=Case when a.ComponentID=1 then 'Chassis'  " +
                    "when a.ComponentID=2 then 'LED Bar'   " +
                    "when a.ComponentID=3 then 'Opencell'   " +
                    "when a.ComponentID=4 then 'TCon' else 'Other' end,  " +
                    "a.SerialNo as DefectiveSerialNo,b.CreateDate as DefectDate,  " +
                    "a.Status,StatusName=Case when a.Status=1 then 'Repaired'   " +
                    "when a.Status=2 then 'Replaced'   " +
                    "when a.Status=3 then 'NDF'  " +
                    "else 'Other' end,  " +
                    "ReplacedSerialNo=Case when a.Status=2 then b.SerialNo else '' end,a.CreateDate as ReplaceDate,  " +
                    "DefectName as Symtom,RootCause,RootCauseName=Case when RootCause=1 then 'Man'   " +
                    "when RootCause=2 then 'Machine'   " +
                    "when RootCause=3 then 'Materials'  " +
                    "when RootCause=4 then 'Environment'  " +
                    "else 'Other' end,pdtGroupName as AGName  " +
                    "From dbo.t_LCMDefectiveComponent a,t_LCMComponentItem b,  " +
                    "t_LCMComponent c,t_ProductGroup d,t_LCMDefectList e  " +
                    "where a.ID=b.ID and a.ComponentID=b.ComponentID   " +
                    "and a.ID=c.ID and c.AGID=d.PdtGroupID and a.Symtom=e.DefectID";


            if (IsCheck == false)
            {
                sSql = sSql + " AND c.CreateDate between '" + dFromDate + "' and '" + dToDate + "' and c.CreateDate<'" + dToDate + "' ";
            }
            sSql = sSql + " Order by a.ComponentID";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    LCMComponent oLCMComponent = new LCMComponent();

                    oLCMComponent.ComponentName = (string)reader["ComponentName"];
                    oLCMComponent.DefectiveSerialNo = (string)reader["DefectiveSerialNo"];
                    oLCMComponent.DefectDate = Convert.ToDateTime(reader["DefectDate"].ToString());
                    oLCMComponent.Status = (int)reader["Status"];
                    oLCMComponent.StatusName = Enum.GetName(typeof(Dictionary.LCMQCStatus), oLCMComponent.Status);
                    oLCMComponent.ReplacedSerialNo = (string)reader["ReplacedSerialNo"];
                    oLCMComponent.ReplaceDate = Convert.ToDateTime(reader["ReplaceDate"].ToString());
                    oLCMComponent.SymtomName = (string)reader["Symtom"];
                    oLCMComponent.RootCause = (int)reader["RootCause"];
                    oLCMComponent.RootCauseName = Enum.GetName(typeof(Dictionary.LCMRootcause), oLCMComponent.RootCause);
                    oLCMComponent.AGName = (string)reader["AGName"];
                    

                    InnerList.Add(oLCMComponent);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshDefect()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select * from dbo.t_LCMDefectList where IsActive=1";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    LCMComponent oLCMComponent = new LCMComponent();
                    oLCMComponent.DefectID = (int)reader["DefectID"];
                    oLCMComponent.DefectName = (string)reader["DefectName"];

                    InnerList.Add(oLCMComponent);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshLCMTarget(DateTime dFromDate, DateTime dToDate, bool IsCheck, int nAGID)
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();
            dToDate = dToDate.AddDays(1);

            string sSql = "";

            {
                sSql = "Select a.*,PdtGroupName as AGName From t_LCMProductionTarget a,t_ProductGroup b where a.AGID=b.PdtGroupID";
            }
            if (IsCheck == false)
            {
                sSql = sSql + " AND TargetDate between '" + dFromDate + "' and '" + dToDate + "' and TargetDate<'" + dToDate + "' ";
            }

            if (nAGID != -1)
            {
                sSql = sSql + " AND AGID=" + nAGID + "";
            }
            sSql = sSql + " Order by TargetDate Desc";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    LCMComponent oLCMComponent = new LCMComponent();
                    oLCMComponent.ID = (int)reader["ID"];
                    oLCMComponent.TargetQty = Convert.ToInt32(reader["TargetQty"].ToString());
                    oLCMComponent.AGID = (int)reader["AGID"];
                    oLCMComponent.AGName = (string)reader["AGName"];
                    oLCMComponent.CreateDate = Convert.ToDateTime(reader["TargetDate"].ToString());
                    
                    InnerList.Add(oLCMComponent);
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


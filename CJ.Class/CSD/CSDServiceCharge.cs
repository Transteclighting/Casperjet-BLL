// <summary>
// Company: Transcom Electronics Limited
// Author: MD.SAIDUJJAMAN SAJIB
// Date: Nov 29, 2016
// Time : 12:04 PM
// Description: Class for CSDServiceCharge.
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
    public class CSDServiceCharge
    {
        private int _nServiceChargeID;
        private string _sServiceChargeCode;
        private string _sServiceChargeName;
        private int _nProductTypeID;
        private double _OwnTechWalkIn;
        private double _OwnTechHomeCall;
        private double _OwnTechInstallation;
        private double _ThirdPartyWalkIn;
        private double _ThirdPartyHomeCall;
        private double _ThirdPartyInstallation;
        private int _nCreateUserID;
        private DateTime _dCreateDate;
        private int _sUpdateUserID;
        private DateTime _dUpdateDate;
        private string _sChargeType;
        private double _Amount;


        // <summary>
        // Get set property for ServiceChargeID
        // </summary>
        public int ServiceChargeID
        {
            get { return _nServiceChargeID; }
            set { _nServiceChargeID = value; }
        }

        // <summary>
        // Get set property for ServiceChargeCode
        // </summary>
        public string ServiceChargeCode
        {
            get { return _sServiceChargeCode; }
            set { _sServiceChargeCode = value.Trim(); }
        }

        // <summary>
        // Get set property for ServiceChargeName
        // </summary>
        public string ServiceChargeName
        {
            get { return _sServiceChargeName; }
            set { _sServiceChargeName = value.Trim(); }
        }

        public string ChargeType
        {
            get { return _sChargeType; }
            set { _sChargeType = value.Trim(); }
        }

        // <summary>
        // Get set property for ProductTypeID
        // </summary>
        public int ProductTypeID
        {
            get { return _nProductTypeID; }
            set { _nProductTypeID = value; }
        }

        // <summary>
        // Get set property for OwnTechWalkIn
        // </summary>
        public double OwnTechWalkIn
        {
            get { return _OwnTechWalkIn; }
            set { _OwnTechWalkIn = value; }
        }
        public double Amount
        {
            get { return _Amount; }
            set { _Amount = value; }
        }

        // <summary>
        // Get set property for OwnTechHomeCall
        // </summary>
        public double OwnTechHomeCall
        {
            get { return _OwnTechHomeCall; }
            set { _OwnTechHomeCall = value; }
        }

        // <summary>
        // Get set property for OwnTechInstallation
        // </summary>
        public double OwnTechInstallation
        {
            get { return _OwnTechInstallation; }
            set { _OwnTechInstallation = value; }
        }

        // <summary>
        // Get set property for ThirdPartyWalkIn
        // </summary>
        public double ThirdPartyWalkIn
        {
            get { return _ThirdPartyWalkIn; }
            set { _ThirdPartyWalkIn = value; }
        }

        // <summary>
        // Get set property for ThirdPartyHomeCall
        // </summary>
        public double ThirdPartyHomeCall
        {
            get { return _ThirdPartyHomeCall; }
            set { _ThirdPartyHomeCall = value; }
        }

        // <summary>
        // Get set property for ThirdPartyInstallation
        // </summary>
        public double ThirdPartyInstallation
        {
            get { return _ThirdPartyInstallation; }
            set { _ThirdPartyInstallation = value; }
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
            get { return _sUpdateUserID; }
            set { _sUpdateUserID = value; }
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
            int nMaxServiceChargeID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "SELECT MAX([ServiceChargeID]) FROM t_CSDServiceCharge";
                cmd.CommandText = sSql;
                object maxID = cmd.ExecuteScalar();
                if (maxID == DBNull.Value)
                {
                    nMaxServiceChargeID = 1;
                }
                else
                {
                    nMaxServiceChargeID = Convert.ToInt32(maxID) + 1;
                }
                _nServiceChargeID = nMaxServiceChargeID;
                sSql = "INSERT INTO t_CSDServiceCharge (ServiceChargeID, ServiceChargeCode, ServiceChargeName, ProductTypeID, OwnTechWalkIn, OwnTechHomeCall, OwnTechInstallation, ThirdPartyWalkIn, ThirdPartyHomeCall, ThirdPartyInstallation, CreateUserID, CreateDate) VALUES(?,?,?,?,?,?,?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ServiceChargeID", _nServiceChargeID);
                cmd.Parameters.AddWithValue("ServiceChargeCode", _sServiceChargeCode);
                cmd.Parameters.AddWithValue("ServiceChargeName", _sServiceChargeName);
                cmd.Parameters.AddWithValue("ProductTypeID", _nProductTypeID);
                cmd.Parameters.AddWithValue("OwnTechWalkIn", _OwnTechWalkIn);
                cmd.Parameters.AddWithValue("OwnTechHomeCall", _OwnTechHomeCall);
                cmd.Parameters.AddWithValue("OwnTechInstallation", _OwnTechInstallation);
                cmd.Parameters.AddWithValue("ThirdPartyWalkIn", _ThirdPartyWalkIn);
                cmd.Parameters.AddWithValue("ThirdPartyHomeCall", _ThirdPartyHomeCall);
                cmd.Parameters.AddWithValue("ThirdPartyInstallation", _ThirdPartyInstallation);
                cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                //cmd.Parameters.AddWithValue("UpdateUserID", _sUpdateUserID);
                //cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void EditCodeAndName()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                sSql = "UPDATE t_CSDServiceCharge SET ServiceChargeCode = ?, ServiceChargeName = ?,ProductTypeID =?, UpdateUserID = ?, UpdateDate = ? WHERE ServiceChargeID = ?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("ServiceChargeCode", _sServiceChargeCode);
                cmd.Parameters.AddWithValue("ServiceChargeName", _sServiceChargeName);
                cmd.Parameters.AddWithValue("ProductTypeID", _nProductTypeID);
                cmd.Parameters.AddWithValue("UpdateUserID", _sUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);

                cmd.Parameters.AddWithValue("ServiceChargeID", _nServiceChargeID);

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
                //sSql = "UPDATE t_CSDServiceCharge SET ServiceChargeCode = ?, ServiceChargeName = ?, ProductTypeID = ?, OwnTechWalkIn = ?, OwnTechHomeCall = ?, OwnTechInstallation = ?, ThirdPartyWalkIn = ?, ThirdPartyHomeCall = ?, ThirdPartyInstallation = ?, CreateUserID = ?, CreateDate = ?, UpdateUserID = ?, UpdateDate = ? WHERE ServiceChargeID = ?";
                sSql = "UPDATE t_CSDServiceCharge SET OwnTechWalkIn = ?, OwnTechHomeCall = ?, OwnTechInstallation = ?, ThirdPartyWalkIn = ?, ThirdPartyHomeCall = ?, ThirdPartyInstallation = ?,UpdateUserID = ?, UpdateDate = ? WHERE ServiceChargeID = ?";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                //cmd.Parameters.AddWithValue("ServiceChargeCode", _sServiceChargeCode);
                //cmd.Parameters.AddWithValue("ServiceChargeName", _sServiceChargeName);
                //cmd.Parameters.AddWithValue("ProductTypeID", _nProductTypeID);
                cmd.Parameters.AddWithValue("OwnTechWalkIn", _OwnTechWalkIn);
                cmd.Parameters.AddWithValue("OwnTechHomeCall", _OwnTechHomeCall);
                cmd.Parameters.AddWithValue("OwnTechInstallation", _OwnTechInstallation);
                cmd.Parameters.AddWithValue("ThirdPartyWalkIn", _ThirdPartyWalkIn);
                cmd.Parameters.AddWithValue("ThirdPartyHomeCall", _ThirdPartyHomeCall);
                cmd.Parameters.AddWithValue("ThirdPartyInstallation", _ThirdPartyInstallation);
                //cmd.Parameters.AddWithValue("CreateUserID", _nCreateUserID);
                //cmd.Parameters.AddWithValue("CreateDate", _dCreateDate);
                cmd.Parameters.AddWithValue("UpdateUserID", _sUpdateUserID);
                cmd.Parameters.AddWithValue("UpdateDate", _dUpdateDate);

                cmd.Parameters.AddWithValue("ServiceChargeID", _nServiceChargeID);

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
                sSql = "DELETE FROM t_CSDServiceChargeCustomer WHERE [ServiceChargeID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ServiceChargeID", _nServiceChargeID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();

                cmd = DBController.Instance.GetCommand();
                sSql = "DELETE FROM t_CSDServiceCharge WHERE [ServiceChargeID]=?";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ServiceChargeID", _nServiceChargeID);
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
                cmd.CommandText = "SELECT * FROM t_CSDServiceCharge where ServiceChargeID =?";
                cmd.Parameters.AddWithValue("ServiceChargeID", _nServiceChargeID);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    _nServiceChargeID = (int)reader["ServiceChargeID"];
                    _sServiceChargeCode = (string)reader["ServiceChargeCode"];
                    _sServiceChargeName = (string)reader["ServiceChargeName"];
                    _nProductTypeID = (int)reader["ProductTypeID"];
                    _OwnTechWalkIn = Convert.ToDouble(reader["OwnTechWalkIn"].ToString());
                    _OwnTechHomeCall = Convert.ToDouble(reader["OwnTechHomeCall"].ToString());
                    _OwnTechInstallation = Convert.ToDouble(reader["OwnTechInstallation"].ToString());
                    _ThirdPartyWalkIn = Convert.ToDouble(reader["ThirdPartyWalkIn"].ToString());
                    _ThirdPartyHomeCall = Convert.ToDouble(reader["ThirdPartyHomeCall"].ToString());
                    _ThirdPartyInstallation = Convert.ToDouble(reader["ThirdPartyInstallation"].ToString());
                    _nCreateUserID = (int)reader["CreateUserID"];
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
    }
    public class CSDServiceCharges : CollectionBase
    {
        public CSDServiceCharge this[int i]
        {
            get { return (CSDServiceCharge)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(CSDServiceCharge oCSDServiceCharge)
        {
            InnerList.Add(oCSDServiceCharge);
        }
        public int GetIndex(int nServiceChargeID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ServiceChargeID == nServiceChargeID)
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
            string sSql = "SELECT * FROM t_CSDServiceCharge Order By ServiceChargeName";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDServiceCharge oCSDServiceCharge = new CSDServiceCharge();
                    oCSDServiceCharge.ServiceChargeID = (int)reader["ServiceChargeID"];
                    oCSDServiceCharge.ServiceChargeCode = (string)reader["ServiceChargeCode"];
                    oCSDServiceCharge.ServiceChargeName = (string)reader["ServiceChargeName"];
                    if (reader["ProductTypeID"] != DBNull.Value)
                    {
                        oCSDServiceCharge.ProductTypeID = (int)reader["ProductTypeID"];
                    }
                    if(reader["OwnTechWalkIn"] != DBNull.Value)
                    {
                        oCSDServiceCharge.OwnTechWalkIn = Convert.ToDouble(reader["OwnTechWalkIn"].ToString());
                    }
                    if(reader["OwnTechHomeCall"] !=DBNull.Value)
                    {
                        oCSDServiceCharge.OwnTechHomeCall = Convert.ToDouble(reader["OwnTechHomeCall"].ToString());
                    }
                    if(reader["OwnTechInstallation"]!=DBNull.Value)
                    {
                        oCSDServiceCharge.OwnTechInstallation = Convert.ToDouble(reader["OwnTechInstallation"].ToString());
                    }
                    if(reader["ThirdPartyWalkIn"]!=DBNull.Value)
                    {
                        oCSDServiceCharge.ThirdPartyWalkIn = Convert.ToDouble(reader["ThirdPartyWalkIn"].ToString());
                    }
                    if(reader["ThirdPartyHomeCall"]!=DBNull.Value)
                    {
                        oCSDServiceCharge.ThirdPartyHomeCall = Convert.ToDouble(reader["ThirdPartyHomeCall"].ToString());
                    }
                    if (reader["ThirdPartyInstallation"] != DBNull.Value)
                    {
                        oCSDServiceCharge.ThirdPartyInstallation = Convert.ToDouble(reader["ThirdPartyInstallation"].ToString());
                    }
                   
                    
                    oCSDServiceCharge.CreateUserID = (int)reader["CreateUserID"];
                    oCSDServiceCharge.CreateDate = Convert.ToDateTime(reader["CreateDate"].ToString());

                    if(reader["UpdateUserID"]!=DBNull.Value)
                    {
                        oCSDServiceCharge.UpdateUserID = (int)reader["UpdateUserID"];
                    }
                    if (reader["UpdateDate"] != DBNull.Value)
                    {
                        oCSDServiceCharge.UpdateDate = Convert.ToDateTime(reader["UpdateDate"].ToString());
                    }    
                    
                    
                    InnerList.Add(oCSDServiceCharge);
                }
                reader.Close();
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void RefreshByServiceCharge(int nServiceChargeID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "Select a.ServiceChargeID,case when ChargeType=1 then 'Service_Charge' " +
                            "when ChargeType = 2 then 'Inspection_Charge' " +
                            "when ChargeType = 3 then 'Installation_Charge' " +
                            "when ChargeType = 4 then 'Re_Installation_Charge' " +
                            "when ChargeType = 5 then 'Dismantling_Charge' end as ChargeType,Amount " +
                            "from t_CSDServiceCharge a, t_CSDServiceChargeCustomer b " +
                            "where a.ServiceChargeID = b.ServiceChargeID and a.ServiceChargeID = "+nServiceChargeID+" " +
                            "and ChargeType in(1,2,3,4,5)";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CSDServiceCharge oCSDServiceCharge = new CSDServiceCharge();
                    oCSDServiceCharge.ServiceChargeID = (int)reader["ServiceChargeID"];
                    oCSDServiceCharge.ChargeType = (string)reader["ChargeType"];
                    if (reader["Amount"] != DBNull.Value)
                    {
                        oCSDServiceCharge.Amount = Convert.ToDouble(reader["Amount"].ToString());
                    }
                    else
                    {
                        oCSDServiceCharge.Amount =0;
                    }
                    InnerList.Add(oCSDServiceCharge);
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


// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: Dec 28, 2011
// Time :  03:00 PM
// Description: Class for Promotion.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.Promotion
{
    public class SPFreeGift
    {
        private int _nCPSID;
        private int _nGiftItemID;
        private int _nQty;
        private string _sGroupName;
        private double _MarkUp;
        private int _nPerInvQty;
        private string _sItemName;


        /// <summary>
        /// Get set property for CPSID
        /// </summary>
        public int CPSID
        {
            get { return _nCPSID; }
            set { _nCPSID = value; }
        }

        /// <summary>
        /// Get set property for GiftItemID
        /// </summary>
        public int GiftItemID
        {
            get { return _nGiftItemID; }
            set { _nGiftItemID = value; }
        }

        /// <summary>
        /// Get set property for Qty
        /// </summary>
        public int Qty
        {
            get { return _nQty; }
            set { _nQty = value; }
        }

        /// <summary>
        /// Get set property for GroupName
        /// </summary>
        public string GroupName
        {
            get { return _sGroupName; }
            set { _sGroupName = value.Trim(); }
        }

        /// <summary>
        /// Get set property for MarkUp
        /// </summary>
        public double MarkUp
        {
            get { return _MarkUp; }
            set { _MarkUp = value; }
        }

        /// <summary>
        /// Get set property for PerInvQty
        /// </summary>
        public int PerInvQty
        {
            get { return _nPerInvQty; }
            set { _nPerInvQty = value; }
        }
        public string ItemName
        {
            get { return _sItemName; }
            set { _sItemName = value.Trim(); }
        }

        public void Insert()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";

            try
            {
                sSql = "INSERT INTO t_SalesPromFreeGift VALUES(?,?,?,?,?,?)";
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CPSID", _nCPSID);
                cmd.Parameters.AddWithValue("GiftItemID", _nGiftItemID);
                cmd.Parameters.AddWithValue("Qty", _nQty);
                cmd.Parameters.AddWithValue("GroupName", _sGroupName);
                cmd.Parameters.AddWithValue("MarkUp", _MarkUp);
                cmd.Parameters.AddWithValue("PerInvQty", _nPerInvQty);

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
                sSql = "DELETE FROM t_SalesPromFreeGift WHERE CPSID=? ";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("CPSID", _nCPSID);

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
            string sSql = " select * from t_SalesPromGiftProduct where  GiftItemID=?";
            cmd.Parameters.AddWithValue("GiftItemID", _nGiftItemID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    _sItemName = reader["Name"].ToString();                  
                   
                }

                reader.Close();
               
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
    public class SPFreeGifts : CollectionBase
    {
        public SPFreeGift this[int i]
        {
            get { return (SPFreeGift)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(SPFreeGift oSPFreeGift)
        {
            InnerList.Add(oSPFreeGift);
        }
        public void Refresh(int nCPSID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = " select * from t_SalesPromFreeGift where  CPSID=?";
            cmd.Parameters.AddWithValue("CPSID", nCPSID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SPFreeGift oSPFreeGift = new SPFreeGift();

                    oSPFreeGift.GiftItemID = int.Parse(reader["GiftItemID"].ToString());
                    oSPFreeGift.Qty = int.Parse(reader["Qty"].ToString());
                    oSPFreeGift.GroupName = reader["GroupName"].ToString();
                    oSPFreeGift.MarkUp = Convert.ToDouble(reader["MarkUp"].ToString());
                    oSPFreeGift.PerInvQty = int.Parse(reader["PerInvQty"].ToString());
                    InnerList.Add(oSPFreeGift);
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

// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: July 4, 2013
// Time : 01:13 PM
// Description: Form for Inbox Item (TML)
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
    public class InboxItem
    {
        private int _nInboxItemID;
        private int _nProductID;
        private string _sInboxItemName;

        public int InboxItemID
        {
            get { return _nInboxItemID; }
            set { _nInboxItemID = value; }
        }
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }
        public string InboxItemName
        {
            get { return _sInboxItemName; }
            set { _sInboxItemName = value; }
        }

    }
    public class InboxItems : CollectionBase
    {
        public InboxItem this[int i]
        {
            get { return (InboxItem)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(InboxItem oInboxItem)
        {
            InnerList.Add(oInboxItem);
        }

        public void RefreshByProductID(int nProductID)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "Select * from t_InboxItem Where ProductID=? ";
            cmd.Parameters.AddWithValue("ProductID", nProductID);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    InboxItem oInboxItem = new InboxItem();

                    oInboxItem.InboxItemID = (int)reader["InboxItemID"];
                    oInboxItem.ProductID = (int)reader["ProductID"];
                    oInboxItem.InboxItemName = (string)reader["InboxItemName"];

                    InnerList.Add(oInboxItem);
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

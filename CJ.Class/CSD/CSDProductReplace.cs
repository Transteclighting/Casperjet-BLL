using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class
{
    public class CSDProductReplace
    {
        private int _nID;
        private string _sReasonName;
        private int _nType;
        private int _nIsActive;

        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }
        public string ReasonName
        {
            get { return _sReasonName; }
            set { _sReasonName = value; }
        }
        public int Type
        {
            get { return _nType; }
            set { _nType = value; }
        }
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
        }
    }

    public class CSDProductReplaces : CollectionBaseCustom
    {
        public void Add(CSDProductReplace oCSDProductReplace)
        {
            this.List.Add(oCSDProductReplace);
        }
        public CSDProductReplace this[int i]
        {
            get { return (CSDProductReplace)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void GetDataForReason(int nType)
        {
            CSDProductReplace oCSDProductReplace;
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT * FROM t_CSDProductReplaceReason Where Type= ?";
            cmd.Parameters.AddWithValue("Type", nType);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oCSDProductReplace = new CSDProductReplace();
                    oCSDProductReplace.ID = (int)reader["ID"];
                    oCSDProductReplace.ReasonName = (string)reader["ReasonName"];
                    InnerList.Add(oCSDProductReplace);
                }
                reader.Close();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}

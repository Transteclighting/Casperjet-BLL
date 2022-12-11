// <summary>
// Compamy: Transcom Electronics Limited
// Author: Shyam Sundar Biswas
// Date: July 03, 2011
// Time :  10:00 AM
// Description: Class for Data tree.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class
{
    public class DataTreeNode
    {
        private int _nDataID;
        private string _sDataName;
        private string _sDataType;
        private object _ParentID;
        private object _ParentDataType;
        private int _nDataLevel;
        private string _sEmail;

        public int DataID
        {
            get { return _nDataID; }
            set { _nDataID = value; }
        }
        public string DataName
        {
            get { return _sDataName; }
            set { _sDataName = value.Trim(); }
        }
        public string DataType
        {
            get { return _sDataType; }
            set { _sDataType = value.Trim(); }
        }
        public object ParentID
        {
            get { return _ParentID; }
            set { _ParentID = value; }
        }
        public object ParentDataType
        {
            get { return _ParentDataType; }
            set { _ParentDataType = value; }
        }
        public int DataLevel
        {
            get { return _nDataLevel; }
            set { _nDataLevel = value; }
        }
        public string Email
        {
            get { return _sEmail; }
            set { _sEmail = value; }
        }

    }
    public class DataTree : CollectionBase
    {
        public DataTreeNode this[int i]
        {
            get { return (DataTreeNode)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(DataTreeNode oDataTreeNode)
        {
            InnerList.Add(oDataTreeNode);
        }
        public void Refresh()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sCompany = "Company";
            string sChannel = "System Channel";

            string sSql = "SELECT * FROM v_DataTree where DataName not in('" + sCompany + "','" + sChannel + "') ";

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DataTreeNode oDataTreeNode = new DataTreeNode();

                    oDataTreeNode.DataID = int.Parse(reader["DataID"].ToString());
                    oDataTreeNode.DataName = (string)reader["DataName"].ToString();
                    oDataTreeNode.DataType = (string)reader["DataType"].ToString();
                    if (reader["ParentID"] == DBNull.Value)
                        oDataTreeNode.ParentID = null;
                    else
                        oDataTreeNode.ParentID = reader["ParentID"];
                    if (reader["ParentID"] == DBNull.Value)
                        oDataTreeNode.ParentDataType = null;
                    else
                        oDataTreeNode.ParentDataType = reader["ParentDataType"];

                    oDataTreeNode.DataLevel = int.Parse(reader["DataLevel"].ToString());
                    //if (reader["Email"] != DBNull.Value)
                    //{
                    //    oDataTreeNode.Email = (string)reader["Email"];
                    //}
                    //else
                    //{
                    //    oDataTreeNode.Email = "";
                    //}

                    InnerList.Add(oDataTreeNode);

                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void GetShowroomTree()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();


            string sSql = @"Select 100001 AS DataID,'National' as DataName,'National' as DataType, 
                            NULL as ParentID,NULL as ParentDataType,1 as DataLevel, null as Email
                            Union All
                            Select c.ParentID as DataID,isnull(d.ShortName, d.MarketGroupDesc) as DataName, 
                            'Area' as DataType,100001 as ParentID,'National' as ParentDataType,2 as DataLevel, null as Email
                            From t_Customer a,t_Showroom b, t_MarketGroup c,t_MarketGroup d
                            where a.CustomerID = b.CustomerID and a.MarketGroupID = c.MarketGroupID
                            and c.ParentID = d.MarketGroupID and IsPOSActive = 1
                            group by c.ParentID,d.MarketGroupDesc,d.ShortName
                            Union All
                            Select a.MarketGroupID as DataID,isnull(ShortName, MarketGroupDesc) as DataName, 
                            'Zone' as DataType,c.ParentID,'Area' as ParentDataType,3 as DataLevel, null as Email
                            From t_Customer a,t_Showroom b, t_MarketGroup c
                            where a.CustomerID = b.CustomerID and a.MarketGroupID = c.MarketGroupID
                            and IsPOSActive = 1 group by a.MarketGroupID,MarketGroupDesc,c.ParentID,ShortName
                            Union All
                            Select WarehouseID as DataID,ShowroomCode as DataName, 
                            'Outlet' as DataType,c.MarketGroupID,'Zone' as ParentDataType,4 as DataLevel, b.Email
                            From t_Customer a,t_Showroom b, t_MarketGroup c
                            where a.CustomerID = b.CustomerID and a.MarketGroupID = c.MarketGroupID
                            and IsPOSActive = 1";
            //try
            //{
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                GetData(cmd);
                //IDataReader reader = cmd.ExecuteReader();
                //while (reader.Read())
                //{
                //    DataTreeNode oDataTreeNode = new DataTreeNode();

                //    oDataTreeNode.DataID = int.Parse(reader["DataID"].ToString());
                //    oDataTreeNode.DataName = (string)reader["DataName"].ToString();
                //    oDataTreeNode.DataType = (string)reader["DataType"].ToString();
                //    if (reader["ParentID"] == DBNull.Value)
                //        oDataTreeNode.ParentID = null;
                //    else
                //        oDataTreeNode.ParentID = reader["ParentID"];
                //    if (reader["ParentID"] == DBNull.Value)
                //        oDataTreeNode.ParentDataType = null;
                //    else
                //        oDataTreeNode.ParentDataType = reader["ParentDataType"];

                //    oDataTreeNode.DataLevel = int.Parse(reader["DataLevel"].ToString());
                //    if (reader["Email"] != DBNull.Value)
                //        oDataTreeNode.Email = (string)reader["Email"];
                //    else
                //        oDataTreeNode.Email = "";


                //    InnerList.Add(oDataTreeNode);

                //}
                //reader.Close();
                //InnerList.TrimToSize();

            //}
            //catch (Exception ex)
            //{
            //    throw (ex);
            //}
        }

        public void GetBrandTree()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();


            string sSql = @"Select BrandID as DataID, BrandDesc as DataName, BrandDesc as DataType, NULL as ParentID, 
NULL as ParentDataType,1 as DataLevel, null as Email from t_Brand Where BrandLevel = 1 and IsActive = 1 order by BrandPos";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                GetData(cmd);
        }

        public void GetProductTree()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();


            string sSql = @"
Select PdtGroupID as DataID, PdtGroupName as DataName, 'PG' as DataType, NULL as ParentID, NULL as ParentDataType,1 as DataLevel, null as Email from t_ProductGroup Where PdtGroupType = 1 and IsActive =1 and PdtGroupID !=705
UNION ALL
Select PdtGroupID as DataID, PdtGroupName as DataName, 'MAG' as DataType, ParentID, 'PG' as ParentDataType,2 as DataLevel, null as Email from t_ProductGroup Where PdtGroupType = 2 and IsActive =1 and ParentID !=0
UNION ALL
Select PdtGroupID as DataID, PdtGroupName as DataName, 'ASG' as DataType, ParentID, 'MAG' as ParentDataType,3 as DataLevel, null as Email from t_ProductGroup Where PdtGroupType = 3 and IsActive =1 and ParentID !=0
UNION ALL
Select PdtGroupID as DataID, PdtGroupName as DataName, 'AG' as DataType, ParentID, 'ASG' as ParentDataType,4 as DataLevel, null as Email from t_ProductGroup Where PdtGroupType = 4 and IsActive =1 and ParentID !=0
";

            cmd.CommandText = sSql;
            cmd.CommandType = CommandType.Text;

            GetData(cmd);
        }

        private void GetData(OleDbCommand cmd)
        {
            try
            {

                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DataTreeNode oDataTreeNode = new DataTreeNode();

                    oDataTreeNode.DataID = int.Parse(reader["DataID"].ToString());
                    oDataTreeNode.DataName = (string)reader["DataName"].ToString();
                    oDataTreeNode.DataType = (string)reader["DataType"].ToString();
                    if (reader["ParentID"] == DBNull.Value)
                        oDataTreeNode.ParentID = null;
                    else
                        oDataTreeNode.ParentID = reader["ParentID"];
                    if (reader["ParentID"] == DBNull.Value)
                        oDataTreeNode.ParentDataType = null;
                    else
                        oDataTreeNode.ParentDataType = reader["ParentDataType"];

                    oDataTreeNode.DataLevel = int.Parse(reader["DataLevel"].ToString());
                    if (reader["Email"] != DBNull.Value)
                        oDataTreeNode.Email = (string)reader["Email"];
                    else
                        oDataTreeNode.Email = "";


                    InnerList.Add(oDataTreeNode);

                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void GetSalesTypeTree()
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();


            string sSql = @"Select 100001 as DataID,'All Sales Type' as DataName,'All Sales Type' as DataType,Null ParentID,NULL as ParentDataType,1 as DataLevel
                            Union All
                            Select 1 as DataID,'Retail' as DataName,'Sales Type' as DataType,100001 ParentID,'All Sales Type' as ParentDataType,2 as DataLevel
                            Union All
                            Select 2 as DataID,'B2C' as DataName,'Sales Type' as DataType,100001 ParentID,'All Sales Type' as ParentDataType,2 as DataLevel
                            Union All
                            Select 3 as DataID,'B2B' as DataName,'Sales Type' as DataType,100001 ParentID,'All Sales Type' as ParentDataType,2 as DataLevel
                            Union All
                            Select 4 as DataID,'HPA' as DataName,'Sales Type' as DataType,100001 ParentID,'All Sales Type' as ParentDataType,2 as DataLevel
                            Union All
                            Select 5 as DataID,'Dealer' as DataName,'Sales Type' as DataType,100001 ParentID,'All Sales Type' as ParentDataType,2 as DataLevel
                            Union All
                            Select 6 as DataID,'eStore' as DataName,'Sales Type' as DataType,100001 ParentID,'All Sales Type' as ParentDataType,2 as DataLevel
                            Union All
                            Select CustTypeID as DataID,CustTypeShortName+' ['+ChannelDescription+']' as DataName,
                            'Customer Type' as DataType,SalesType As ParentID,'Sales Type' as ParentDataType,3 as DataLevel 
                            From t_CustomerType a,t_Channel b 
                            where SalesType in (1,2,3,4,5,6) and a.IsActive=1
                            and a.ChannelID=b.ChannelID
                            Union All
                            Select -1 as DataID,'eStore' as DataName,'Customer Type' as DataType,6 ParentID,'Sales Type' as ParentDataType,3 as DataLevel";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    DataTreeNode oDataTreeNode = new DataTreeNode();

                    oDataTreeNode.DataID = int.Parse(reader["DataID"].ToString());
                    oDataTreeNode.DataName = (string)reader["DataName"].ToString();
                    oDataTreeNode.DataType = (string)reader["DataType"].ToString();
                    if (reader["ParentID"] == DBNull.Value)
                        oDataTreeNode.ParentID = null;
                    else
                        oDataTreeNode.ParentID = reader["ParentID"];
                    if (reader["ParentID"] == DBNull.Value)
                        oDataTreeNode.ParentDataType = null;
                    else
                        oDataTreeNode.ParentDataType = reader["ParentDataType"];

                    oDataTreeNode.DataLevel = int.Parse(reader["DataLevel"].ToString());

                    InnerList.Add(oDataTreeNode);

                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public DataTree getSubDataTree(object nParentID,object sParentDataType)
        {
            DataTree oSubDataTree = new DataTree();
            foreach (DataTreeNode oNode in this)
            {
                if (nParentID == null)
                {
                    if (oNode.ParentID == nParentID && oNode.ParentDataType == sParentDataType)
                        oSubDataTree.Add(oNode);
                }
                else
                {
                    if (nParentID != null && oNode.ParentID !=null)
                    {
                        if (Convert.ToInt32(nParentID) == Convert.ToInt32(oNode.ParentID) && sParentDataType.ToString() == oNode.ParentDataType.ToString())
                            oSubDataTree.Add(oNode);
                    }
                    
                }
 
            }
            return oSubDataTree;

        }

    }
}

// <summary>
// Company: Transcom Electronics Limited
// Author: Zahid Hasan
// Date: Sep 07, 2021
// Time : 03:38 PM
// Description: Class for WarehouseCurrentStock.
// Modify Person And Date:D:\Local\TEL\CasperJet\CJ.Class\Report\rptWarehouseCurrentStock.cs
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.Report
{
    public class rptWarehouseCurrentStock
    {
        private string _sWarehouseName;
        private int _nCurrentStock;
        // <summary>
        // Get set property for ProductID
        // </summary>
        public string WarehouseName
        {
            get { return _sWarehouseName; }
            set { _sWarehouseName = value; }
        }

        // <summary>
        // Get set property for WarehouseID
        // </summary>
        public int CurrentStock
        {
            get { return _nCurrentStock; }
            set { _nCurrentStock = value; }
        }
        //public void Refresh()
        //{
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    int nCount = 0;
        //    try
        //    {
        //        cmd.CommandText = "SELECT * FROM t_ProductStock where ProductID =?";
        //        cmd.CommandType = CommandType.Text;
        //        IDataReader reader = cmd.ExecuteReader();
        //        if (reader.Read())
        //        {
        //            _sWarehouseName = (string)reader["WarehouseName"];
        //            _sCurrentStock = (string)reader["CurrentStock"];
        //            nCount++;
        //        }
        //        reader.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw (ex);
        //    }
        //}
    }
    public class rptWarehouseCurrentStocks : CollectionBase
    {
        public rptWarehouseCurrentStock this[int i]
        {
            get { return (rptWarehouseCurrentStock)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(rptWarehouseCurrentStock oWarehouseCurrentStock)
        {
            InnerList.Add(oWarehouseCurrentStock);
        }
        public int GetIndex(string WarehouseName)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].WarehouseName == WarehouseName)
                {
                    return i;
                }
            }
            return -1;
        }
        public void Refresh(int product, int whParent, int? wh)
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = string.Format(@"Select WarehouseName, sum(CAST(CurrentStock AS int)) as CurrentStock 
                            from t_ProductStock a, v_WarehouseDetails b Where a.WarehouseID = b.WarehouseID  and CurrentStock>0
                            and a.ProductID = {0} and WarehouseParentID={1} ", product, whParent);
            if (wh != null)
            {
                sSql = sSql + string.Format(" and a.WarehouseID = {0}", wh);
            }
            sSql = sSql + string.Format(" Group by WarehouseName");
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    rptWarehouseCurrentStock oWarehouseCurrentStock = new rptWarehouseCurrentStock();
                    oWarehouseCurrentStock.WarehouseName = (string)reader["WarehouseName"];
                    oWarehouseCurrentStock.CurrentStock = (int)reader["CurrentStock"];
                    InnerList.Add(oWarehouseCurrentStock);
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


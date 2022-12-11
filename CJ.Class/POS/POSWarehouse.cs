// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Mar 19, 2014
// Time :  06:14 PM
// Description: Class for POS Warehouse.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;

using System.Collections;
using System.Data;
using System.Data.OleDb;

namespace CJ.Class.POS
{
    public class POSWarehouse
    {

        private int _nWarehouseID;
        private int _nIsActive;


        public int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
        }
        public int IsActive
        {
            get { return _nIsActive; }
            set { _nIsActive = value; }
        }

    }
    public class POSWarehouses : CollectionBase
    {
        public POSWarehouse this[int i]
        {
            get { return (POSWarehouse)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(POSWarehouse oPOSWarehouse)
        {
            InnerList.Add(oPOSWarehouse);
        }

        public void Refresh()
        {
            InnerList.Clear();

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "SELECT *  FROM t_POSWarehouse Where IsActive=? ";
            cmd.Parameters.AddWithValue("IsActive", (int)Dictionary.ActiveOrInActiveStatus.ACTIVE);

            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    POSWarehouse oPOSWarehouse = new POSWarehouse();

                    oPOSWarehouse.WarehouseID = (int)reader["WarehouseID"];
                    oPOSWarehouse.IsActive = (int)reader["IsActive"];

                    InnerList.Add(oPOSWarehouse);
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


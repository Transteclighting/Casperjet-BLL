using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.Library;


using CJ.Class.DMS;
using CJ.Class;

namespace CJ.Class.ANDROID
{
    public class DMS
    {
        //DateTime _dStartDay;
        //DateTime _dLastOperationDay;
        //DMSUser _oDMSUser;
        //int nUserID = 0;
        //int _nDistributorID;


        



        public void SetOperationStartDate(int _nDistributorID, DateTime _dStartDay)
        {

            {
                OleDbCommand cmd = DBController.Instance.GetCommand();
                try
                {
                    cmd.CommandText = "Update t_DMSUser set OperationDate = ?"
                                       + " where DistributorID=? ";

                    cmd.Parameters.AddWithValue("OperationDate", Convert.ToDateTime(_dStartDay));
                    cmd.Parameters.AddWithValue("DistributorID", _nDistributorID);

                    cmd.ExecuteNonQuery();
                    cmd.Dispose();

                }
                catch (Exception ex)
                {
                    throw (ex);
                }
            }


        }
        public DateTime SelectLastOperationDate(string  sUserID)
        {
            DateTime dLastOperationDate = default(DateTime);
            OleDbCommand cmd = DBController.Instance.GetCommand();
            try
            {
                cmd.CommandText = "select LastOperationDate from t_DMSUser where UserName like '%"+sUserID+"%'  ";
                cmd.CommandType = CommandType.Text;

                //cmd.Parameters.AddWithValue("OperationDate", Convert.ToDateTime(_dStartDay));
                cmd.Parameters.AddWithValue("UserName", sUserID);

                // cmd.ExecuteNonQuery();
                //  cmd.Dispose();
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    dLastOperationDate = (DateTime)reader["LastOperationDate"];



                }


                reader.Close();
                return dLastOperationDate;

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public DSProductStockDMS GetProductStockDMS(string sdistributorid)
        {
            DSProductStockDMS oDSProdStockDMS = new DSProductStockDMS();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            try
            {
                cmd.CommandText = " select areaname,territoryname,NSP,b.distributorid,customercode,customername,a.productcode,a.productname,b.currentstock " +
                            " from v_ProductDetails a inner join  t_DMSProductStock b  on b.productid=a.productid " +
                            " inner join v_customerdetails c on c.customerid=b.distributorid  WHERE distributorid='" + sdistributorid + "' " +
                          " order by productname ";
                            

                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                cmd.Parameters.AddWithValue("distributorid", sdistributorid);
             
                while (reader.Read())
                {
                    DSProductStockDMS.STOCKRow oProductStockRow = oDSProdStockDMS.STOCK.NewSTOCKRow();
                    oProductStockRow.ProductCode = reader["ProductCode"].ToString();
                    oProductStockRow.ProductName = reader["ProductName"].ToString();
                    oProductStockRow.NSP = reader["NSP"].ToString();
                    oProductStockRow.CurrentStock = reader["currentstock"].ToString();
               

                    oDSProdStockDMS.STOCK.AddSTOCKRow(oProductStockRow);
                }
                oDSProdStockDMS.AcceptChanges();

                reader.Close();
                return oDSProdStockDMS;
            }

            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}

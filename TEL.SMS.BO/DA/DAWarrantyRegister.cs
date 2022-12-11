using System;
using System.Collections.Generic;
using System.Text;
using TEL.SMS.BO.BE;
using TEL.SMS.BO.DA;
using System.Data.OleDb;
using System.Diagnostics;

namespace TEL.SMS.BO.DA
{
    public enum DataType
    {
        DataTypeAll = 3,
        DataTypeSMS = 0,
        DataTypeManual = 1,
        DataTypeShowRoomDetail = 4,
        DataTypeShowRoomSummary = 5,
    }
    public class DAWarrantyRegister
    {
        public void Insert(DSWarrantyRegister oDSWarrantyRegister)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            foreach (DSWarrantyRegister.WarrantyRegisterRow oWarrantyRegisterRow in oDSWarrantyRegister.WarrantyRegister)
            {
                cmd.CommandText = "INSERT INTO t_WarrantyRegister(WarrantyRegID,SerialNo,RegMode,CustomerName,CustomerAddress,"
                    + " TelephoneNo,MobileNo,Email, PurchaseDate,WarrantyCardNo,ProductID,SellerCode,SellerName,BillNo,Remarks,EntryDate,UserName)"
                    + " VALUES(?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?,?)";
                oWarrantyRegisterRow.WarrantyRegID = getNewID();
                cmd.Parameters.AddWithValue("WarrantyRegID", oWarrantyRegisterRow.WarrantyRegID);
                cmd.Parameters.AddWithValue("SerialNo", oWarrantyRegisterRow.SerialNo);
                cmd.Parameters.AddWithValue("RegMode", oWarrantyRegisterRow.RegMode);
                //cmd.Parameters.AddWithValue("CustomerCode", oWarrantyRegisterRow.CustomerCode);
                cmd.Parameters.AddWithValue("CustomerName", oWarrantyRegisterRow.CustomerName);
                cmd.Parameters.AddWithValue("CustomerAddress", oWarrantyRegisterRow.CustomerAddress);
                if (oWarrantyRegisterRow.IsTelephoneNoNull())
                {
                    cmd.Parameters.AddWithValue("TelephoneNo", System.DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("TelephoneNo", oWarrantyRegisterRow.TelephoneNo);
                }
                //cmd.Parameters.AddWithValue("TelephoneNo", oWarrantyRegisterRow.TelephoneNo);
                cmd.Parameters.AddWithValue("MobileNo", oWarrantyRegisterRow.MobileNo);
                cmd.Parameters.AddWithValue("Email", oWarrantyRegisterRow.Email);
                cmd.Parameters.AddWithValue("PurchaseDate", oWarrantyRegisterRow.PurchaseDate);
                cmd.Parameters.AddWithValue("WarrantyCardNo", oWarrantyRegisterRow.WarrantyCardNo); 
                cmd.Parameters.AddWithValue("ProductID", oWarrantyRegisterRow.ProductID);
                
                if (oWarrantyRegisterRow.IsSellerCodeNull())
                {
                    cmd.Parameters.AddWithValue("SellerCode", System.DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("SellerCode", oWarrantyRegisterRow.SellerCode);
                }
                cmd.Parameters.AddWithValue("SellerName", oWarrantyRegisterRow.SellerName);
                cmd.Parameters.AddWithValue("BillNo", oWarrantyRegisterRow.BillNo);
                cmd.Parameters.AddWithValue("Remarks", oWarrantyRegisterRow.Remarks);
                cmd.Parameters.AddWithValue("EntryDate", oWarrantyRegisterRow.EntryDate);
                cmd.Parameters.AddWithValue("UserName", oWarrantyRegisterRow.UserName);
                cmd.ExecuteNonQuery();
            }
        }

        private long getNewID()
        {
            long nNextID;
            Utility oUtil = new Utility();
            nNextID = oUtil.GenerateID("t_WarrantyRegister", "WarrantyRegID");
            return nNextID;
        }

        public void Update(DSWarrantyRegister oDSWarrantyRegister)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            foreach (DSWarrantyRegister.WarrantyRegisterRow oWarrantyRegisterRow in oDSWarrantyRegister.WarrantyRegister)
            {
                cmd.CommandText = "UPDATE t_WarrantyRegister"
                    + " SET RegMode=?,CustomerName=?,CustomerAddress=?,TelephoneNo=?,MobileNo=?,Email=?,"
                    + " WarrantyCardNo=?,  PurchaseDate=?,ProductID=?,SerialNo=?,SellerCode=?,SellerName=?,BillNo=?,Remarks=?,EntryDate=?,UserName=?"
                    + " WHERE WarrantyRegID=?";
                cmd.Parameters.AddWithValue("RegMode", oWarrantyRegisterRow.RegMode);
                //cmd.Parameters.AddWithValue("CustomerCode", oWarrantyRegisterRow.CustomerCode);
                cmd.Parameters.AddWithValue("CustomerName", oWarrantyRegisterRow.CustomerName);
                cmd.Parameters.AddWithValue("CustomerAddress", oWarrantyRegisterRow.CustomerAddress);
                cmd.Parameters.AddWithValue("TelephoneNo", oWarrantyRegisterRow.TelephoneNo);
                cmd.Parameters.AddWithValue("MobileNo", oWarrantyRegisterRow.MobileNo);
                cmd.Parameters.AddWithValue("Email", oWarrantyRegisterRow.Email);
                cmd.Parameters.AddWithValue("WarrantyCardNo", oWarrantyRegisterRow.WarrantyCardNo);
                //cmd.Parameters.AddWithValue("SalesPersonID", oWarrantyRegisterRow.SalesPersonID);    
                cmd.Parameters.AddWithValue("PurchaseDate", oWarrantyRegisterRow.PurchaseDate);
                cmd.Parameters.AddWithValue("ProductID", oWarrantyRegisterRow.ProductID);
                cmd.Parameters.AddWithValue("SerialNo", oWarrantyRegisterRow.SerialNo);
                if (oWarrantyRegisterRow.IsSellerCodeNull())
                {
                    cmd.Parameters.AddWithValue("SellerCode", System.DBNull.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("SellerCode", oWarrantyRegisterRow.SellerCode);
                }
                cmd.Parameters.AddWithValue("SellerName", oWarrantyRegisterRow.SellerName);
                cmd.Parameters.AddWithValue("BillNo", oWarrantyRegisterRow.BillNo);
                cmd.Parameters.AddWithValue("Remarks", oWarrantyRegisterRow.Remarks);
                cmd.Parameters.AddWithValue("EntryDate", oWarrantyRegisterRow.EntryDate);
                cmd.Parameters.AddWithValue("UserName", oWarrantyRegisterRow.UserName);
                cmd.Parameters.AddWithValue("WarrantyRegID", oWarrantyRegisterRow.WarrantyRegID);
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(DSWarrantyRegister oDSWarrantyRegister)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            foreach (DSWarrantyRegister.WarrantyRegisterRow oWarrantyRegisterRow in oDSWarrantyRegister.WarrantyRegister)
            {
                cmd.CommandText = "DELETE FROM t_WarrantyRegister WHERE WarrantyRegID=?";
                cmd.Parameters.AddWithValue("WarrantyRegID", oDSWarrantyRegister.WarrantyRegister[0].SerialNo);
                cmd.ExecuteNonQuery();
            }
        }       

        public void GetWarrantyRegister(DSWarrantyRegister oDSWarrantyRegister, string sWarrantyRegID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbDataAdapter adapter = new OleDbDataAdapter();

            cmd.CommandText = "SELECT * FROM t_WarrantyRegister WHERE WarrantyRegID=?";
            cmd.Parameters.AddWithValue("WarrantyRegID", sWarrantyRegID);

            adapter.SelectCommand = cmd;
            try
            {
                oDSWarrantyRegister.Clear();
                adapter.Fill(oDSWarrantyRegister, "WarrantyRegister");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message.ToString());
            }
        }

        public void GetAllWarrantyRegisters(DSWarrantyRegister oDSWarrantyRegister)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbDataAdapter adapter = new OleDbDataAdapter();

            cmd.CommandText = "SELECT * FROM t_WarrantyRegister";
            adapter.SelectCommand = cmd;
            try
            {
                oDSWarrantyRegister.Clear();
                adapter.Fill(oDSWarrantyRegister, "WarrantyRegister");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message.ToString());
            }
        }

        public void GetWarrantyRegisterBySearch(DSWarrantyRegister oDSWarrantyRegister,string sField, string sSearchString,WarrantyRegMode nRegMode)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbDataAdapter adapter = new OleDbDataAdapter();

            cmd.CommandText = "SELECT * FROM t_WarrantyRegister"
                + " WHERE (" + sField + " LIKE ?) AND RegMode=?";            
            
            cmd.Parameters.AddWithValue("SearchString", "%" + sSearchString + "%");
            cmd.Parameters.AddWithValue("RegMode", (Int64)nRegMode);
            adapter.SelectCommand = cmd;
            try
            {
                oDSWarrantyRegister.Clear();
                adapter.Fill(oDSWarrantyRegister, "WarrantyRegister");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message.ToString());                
            }
        }


        /// <summary>
        /// Add By Shyam Sundar Biswas
        /// </summary>
        /// 
        public void GetWarrantyRegistartions(DSWarrantyRegister oDSWarrantyRegister)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbDataAdapter adapter = new OleDbDataAdapter();

            cmd.CommandText = "SELECT * FROM t_WarrantyRegister";
            adapter.SelectCommand = cmd;
            try
            {
                oDSWarrantyRegister.Clear();
                adapter.Fill(oDSWarrantyRegister, "WarrantyRegister");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message.ToString());
            }
        }
        public void DeleteWarrantyRegister(string sWarrantyRegID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();          
            cmd.CommandText = "DELETE FROM t_WarrantyRegister WHERE WarrantyRegID=?";
            cmd.Parameters.AddWithValue("WarrantyRegID", sWarrantyRegID);
            cmd.ExecuteNonQuery();
            
        }
        /// <summary>
        /// end
        /// </summary>
       


        public void GetWarrantyRegisterByID(DSRptWarrantyAct oDSRptWarrantyAct, int WarrantyRegID)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbDataAdapter adapter = new OleDbDataAdapter();

            cmd.CommandText = "SELECT * FROM t_WarrantyRegister"
                + " WHERE  WarrantyRegID = ?";

            cmd.Parameters.AddWithValue("WarrantyRegID", WarrantyRegID);
            adapter.SelectCommand = cmd;
            try
            {
                oDSRptWarrantyAct.Clear();
                adapter.Fill(oDSRptWarrantyAct, "RptWarrantyAct");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message.ToString());
            }
        }
        public void GetWarrantyRegisterByRegMode(DSRptWarrantyAct oDSRptWarrantyAct, DateTime dFromDt, DateTime dToDt, int nRegType)
        {
            string sSQL = "";
            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbDataAdapter adapter = new OleDbDataAdapter();

            if (nRegType == (int)DataType.DataTypeAll)
            {
                sSQL = "SELECT * FROM t_WarrantyRegister"
                + " WHERE EntryDate >= ? AND EntryDate <= ? ";
                cmd.CommandText = sSQL;
                cmd.Parameters.AddWithValue("EntryDate", dFromDt);
                cmd.Parameters.AddWithValue("EntryDate", dToDt);
                //cmd.Parameters.AddWithValue("RegMode", (int)DataType.DataTypeAll);
            }
            else if (nRegType == (int)DataType.DataTypeSMS)
            {
                sSQL = "SELECT SerialNo as SerialNo, CustomerCode as CustomerCode, CustomerName as CustomerName, CustomerAddress as CustomerAddress, ProductID as ProductID, PurchaseDate as PurchaseDate, EntryDate as EntryDate, UserName as UserName FROM t_WarrantyRegister"
                + " WHERE EntryDate >= ? AND EntryDate <= ? AND RegMode = 0 ";
                //sSQL = "SELECT SLno as SerialNo,  FROM WarrantyRegister " +
                // " WHERE EntryDate >= '16-May-2007' AND EntryDate <= '31-May-2007' AND RegMode = 1 ";
                cmd.CommandText = sSQL;
                cmd.Parameters.AddWithValue("EntryDate", dFromDt);
                cmd.Parameters.AddWithValue("EntryDate", dToDt);
                //cmd.Parameters.AddWithValue("RegMode", (int)DataType.DataTypeSMS);
            }
            else if (nRegType == (int)DataType.DataTypeManual)
            {
                sSQL = "SELECT * FROM t_WarrantyRegister"
                + " WHERE EntryDate >= ? AND EntryDate <= ? AND RegMode = 1 ";
                cmd.CommandText = sSQL;
                cmd.Parameters.AddWithValue("EntryDate", dFromDt);
                cmd.Parameters.AddWithValue("EntryDate", dToDt);
                //cmd.Parameters.AddWithValue("RegMode", (int)DataType.DataTypeManual);
            }
            else if (nRegType == (int)DataType.DataTypeShowRoomDetail)
            {
                sSQL = "SELECT * FROM t_WarrantyRegister"
                + " WHERE PurchaseDate between ? and ? AND PurchaseDate < ? AND RegMode = 1 ";
                cmd.CommandText = sSQL;
                cmd.Parameters.AddWithValue("EntryDate", dFromDt);
                cmd.Parameters.AddWithValue("EntryDate", dToDt.AddDays(1));
                cmd.Parameters.AddWithValue("EntryDate", dToDt.AddDays(1));
                //cmd.Parameters.AddWithValue("RegMode", (int)DataType.DataTypeManual);
            }
            else if (nRegType == (int)DataType.DataTypeShowRoomSummary)
            {
                sSQL = "SELECT * FROM t_WarrantyRegister"
                + " WHERE PurchaseDate between ? and ? AND PurchaseDate < ? AND RegMode = 1 ";
                cmd.CommandText = sSQL;
                cmd.Parameters.AddWithValue("EntryDate", dFromDt);
                cmd.Parameters.AddWithValue("EntryDate", dToDt.AddDays(1));
                cmd.Parameters.AddWithValue("EntryDate", dToDt.AddDays(1));
                //cmd.Parameters.AddWithValue("RegMode", (int)DataType.DataTypeManual);
            }
            //cmd.CommandText = sSQL;
            //cmd.Parameters.AddWithValue("RequestDate", dFromDt);
            //cmd.Parameters.AddWithValue("RequestDate", dToDt);
            //cmd.Parameters.AddWithValue("RegMode", (int)DataType.DataTypeSMS);
            //cmd.Parameters.AddWithValue("WarrantyRegID", WarrantyRegID);
            adapter.SelectCommand = cmd;
            try
            {
                oDSRptWarrantyAct.Clear();
                adapter.Fill(oDSRptWarrantyAct, oDSRptWarrantyAct.RptWarrantyAct.TableName );                  
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message.ToString());
            }
            if (oDSRptWarrantyAct.RptWarrantyAct.Count > 0)
            {
                return;
            }
        }
        public void GetWarrantyRegister(DSWarrantyRegister oDSWarrantyRegister, string sSerialNo,WarrantyRegMode nRegMode)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbDataAdapter adapter = new OleDbDataAdapter();

            cmd.CommandText = "SELECT * FROM t_WarrantyRegister WHERE SerialNo=? AND RegMode=?";
            cmd.Parameters.AddWithValue("SerialNo", sSerialNo);
            cmd.Parameters.AddWithValue("RegMode", (long)nRegMode);
            adapter.SelectCommand = cmd;
            try
            {
                oDSWarrantyRegister.Clear();
                adapter.Fill(oDSWarrantyRegister, "WarrantyRegister");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message.ToString());
            }
        }
        public bool DoesWarrentyRegisterActive(DSWarrantyRegister oDSWarrantyRegister)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbDataAdapter adapter = new OleDbDataAdapter();

            cmd.CommandText = "SELECT * FROM t_WarrantyRegister WHERE SerialNo=?";
            cmd.Parameters.AddWithValue("SerialNo", oDSWarrantyRegister.WarrantyRegister[0].SerialNo);
            adapter.SelectCommand = cmd;
            try
            {
                oDSWarrantyRegister.Clear();
                adapter.Fill(oDSWarrantyRegister, "WarrantyRegister");
                if (oDSWarrantyRegister.WarrantyRegister.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message.ToString());
                return false;
            }
        }

        //public bool IsExist(string sSerialNo)
        //{
        //    OleDbCommand cmd = DBController.Instance.GetCommand();
        //    cmd.CommandText = "SELECT COUNT(*) FROM WarrantyRegister where SerialNo=?" ;
        //    cmd.Parameters.AddWithValue("SerialNo", sSerialNo);
        //    long nCount = Convert.ToInt64(cmd.ExecuteScalar());

        //    if (nCount==0)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}
    }
}

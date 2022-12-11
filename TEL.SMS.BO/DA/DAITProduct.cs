using System;
using System.Collections.Generic;
using System.Text;
using TEL.SMS.BO.BE;
using System.Data.OleDb;
using System.Diagnostics;


namespace TEL.SMS.BO.DA
{
    public class DAITProduct
    {
        public void Insert(ITProduct oITProduct)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();

            ITProduct.InvoiceRow oInvoice = oITProduct.Invoice[0];

            cmd.CommandText = "INSERT INTO Invoice(InvoiceID, InvoiceNo, InvoiceDate, SupplierID,ChalanNo,ChalanDate,GRDNo,GRDDate,Remarks)"
                + " VALUES(?,?,?,?,?,?,?,?,?)";
            oInvoice.InvoiceID = getNewInvoiceID();
            cmd.Parameters.AddWithValue("InvoiceID", oInvoice.InvoiceID);
            cmd.Parameters.AddWithValue("InvoiceNo", oInvoice.InvoiceNo);
            cmd.Parameters.AddWithValue("InvoiceDate", oInvoice.InvoiceDate);
            cmd.Parameters.AddWithValue("SupplierID", oInvoice.SupplierID);
            cmd.Parameters.AddWithValue("ChalanNo", oInvoice.ChalanNo);
            cmd.Parameters.AddWithValue("ChalanDate", oInvoice.ChalanDate);
            cmd.Parameters.AddWithValue("GRDNo", oInvoice.GRDNo);
            cmd.Parameters.AddWithValue("GRDDate", oInvoice.GRDDate);
            if (oInvoice.IsRemarksNull())
            {
                cmd.Parameters.AddWithValue("Remarks", null);
            }
            else
            {
                cmd.Parameters.AddWithValue("Remarks", oInvoice.Remarks);
            }
            cmd.ExecuteNonQuery();

            foreach (ITProduct.InvoiceItemRow oInvoiceItem in oITProduct.InvoiceItem)
            {
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO InvoiceItem(InvoiceID,ProductCode,ProductDescription,PartNo,Qty,UnitPrice)"
                    + " VALUES(?,?,?,?,?,?)";

                oInvoiceItem.InvoiceID = oInvoice.InvoiceID;
                cmd.Parameters.AddWithValue("InvoiceID", oInvoiceItem.InvoiceID);
                cmd.Parameters.AddWithValue("ProductCode", oInvoiceItem.ProductCode);
                cmd.Parameters.AddWithValue("ProductDescription", oInvoiceItem.ProductDescription);
                cmd.Parameters.AddWithValue("PartNo", oInvoiceItem.PartNo);
                cmd.Parameters.AddWithValue("Qty", oInvoiceItem.Qty);
                cmd.Parameters.AddWithValue("UnitPrice", oInvoiceItem.UnitPrice);
                cmd.ExecuteNonQuery();

            }

            foreach (ITProduct.InvoiceItemSerialNoRow oItemSerialNo in oITProduct.InvoiceItemSerialNo)
            {
                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();

                cmd.CommandText = "INSERT INTO InvoiceItemSerialNo(InvoiceID,ProductCode,SerialNo)"
                    + " VALUES(?,?,?)";

                oItemSerialNo.InvoiceID = oInvoice.InvoiceID;
                cmd.Parameters.AddWithValue("InvoiceID", oItemSerialNo.InvoiceID);
                cmd.Parameters.AddWithValue("ProductCode", oItemSerialNo.ProductCode);
                cmd.Parameters.AddWithValue("SerialNo", oItemSerialNo.SerialNo);
                cmd.ExecuteNonQuery();
            }

        }

        private long getNewInvoiceID()
        {
            long nNextID;
            Utility oUtil = new Utility();
            nNextID = oUtil.GenerateID("Invoice", "InvoiceID");
            return nNextID;
        }
        

        public void Delete(ITProduct oITProduct)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            long nInvoiceID= oITProduct.Invoice[0].InvoiceID; 
            cmd.CommandText = "DELETE FROM InvoiceItemSerialNo WHERE InvoiceID=?";
            cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            cmd = DBController.Instance.GetCommand();
            cmd.CommandText = "DELETE FROM InvoiceItem WHERE InvoiceID=?";
            cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            cmd = DBController.Instance.GetCommand();
            cmd.CommandText = "DELETE FROM Invoice WHERE InvoiceID=?";
            cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);
            cmd.ExecuteNonQuery();
        }

        public void GetInvoice(ITProduct oITProduct)
        {
            long nInvoiceID = oITProduct.Invoice[0].InvoiceID;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbDataAdapter adapter = new OleDbDataAdapter();


            adapter.SelectCommand = cmd;
            try
            {
                oITProduct.Clear();
                cmd.CommandText = "SELECT * FROM Invoice WHERE InvoiceID=?";
                cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);
                adapter.Fill(oITProduct, "Invoice");

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                adapter.SelectCommand = cmd;
                cmd.CommandText = "SELECT * FROM InvoiceItem WHERE InvoiceID=?";
                cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);
                adapter.Fill(oITProduct, "InvoiceItem");

                cmd.Dispose();
                cmd = DBController.Instance.GetCommand();
                adapter.SelectCommand = cmd;
                cmd.CommandText = "SELECT * FROM InvoiceItemSerialNo WHERE InvoiceID=?";
                cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);
                adapter.Fill(oITProduct, "InvoiceItemSerialNo");

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message.ToString());
            }
        }

        public void GetAllInvoices(ITProduct oITProduct)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbDataAdapter adapter = new OleDbDataAdapter();

            cmd.CommandText = "SELECT * FROM Invoice";
            adapter.SelectCommand = cmd;
            try
            {
                oITProduct.Clear();
                adapter.Fill(oITProduct, oITProduct.Invoice.TableName);
                 
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message.ToString());
            }
        }

        public void GetAllSuppliers(ITProduct oITProduct)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbDataAdapter adapter = new OleDbDataAdapter();

            cmd.CommandText = "SELECT * FROM ITSupplier";
            adapter.SelectCommand = cmd;
            try
            {
                oITProduct.Clear();
                adapter.Fill(oITProduct, oITProduct.ITSupplier.TableName);

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message.ToString());
            }
        }

        public void GetInvoiceItem(ITProduct oITProduct)
        {
            long nInvoiceID = oITProduct.Invoice[0].InvoiceID;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbDataAdapter adapter = new OleDbDataAdapter();

            cmd.CommandText = "SELECT * FROM InvoiceItem where InvoiceID=?";
            cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);
            adapter.SelectCommand = cmd;
            try
            {
                oITProduct.Clear();
                adapter.Fill(oITProduct, oITProduct.InvoiceItem.TableName);

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message.ToString());
            }

            cmd.Dispose();
            cmd = DBController.Instance.GetCommand();
            cmd.CommandText = "SELECT * FROM InvoiceItemSerialNo where InvoiceID=?";
            cmd.Parameters.AddWithValue("InvoiceID", nInvoiceID);
            adapter.SelectCommand = cmd;
            try
            {

                adapter.Fill(oITProduct, oITProduct.InvoiceItemSerialNo.TableName);

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message.ToString());
            }

        }
    }
}

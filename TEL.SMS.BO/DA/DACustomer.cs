/// <summary>
/// Compamy: Transcom Electronics Limited
/// Author: Md. Numery Zaber
/// Date: May 07, 2007
/// Time : 4:05 PM
/// Description: User for the customer
/// Modify Person And Date:
/// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using TEL.SMS.BO.BE;
using TEL.Common;
using System.Data.OleDb;
using System.Diagnostics;
using System.Configuration;
using System.Windows.Forms;

namespace TEL.SMS.BO.DA
{
    public class DACustomer
    {
        //private DSCustomer oDSCustomer;
        //private ProgressBar _opbrDataImport;
        //private Label _olblStatus;        

        public void GetAllCustomerFromMDB(DSCustomer oDSCustomer, string sSearchString, string sChannelInfo)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbDataAdapter adapter = new OleDbDataAdapter();  

            //_olblStatus.Text = "Getting Customer info from sales system.....";
            //_olblStatus.Refresh();
            //cmd.CommandText = "SELECT Customer.CustomerID, Customer.CustomerName, MainChannel.MainChannelDescription as ChannelName , Customer.Suspended "
            //               + " FROM (Customer INNER JOIN Channel ON Customer.ChannelID = Channel.ChannelID) INNER JOIN MainChannel ON  "
            //                + " Channel.MainChannelID = MainChannel.MainChannelID where Customer.Suspended=?  and MainChannel.MainChannelID=?  and (customer.CustomerName Like ?) ";

            cmd.CommandText = " select q1.CustomerID,q1.CustomerName,q1.IsActive as Suspended ,q3.ChannelDescription as ChannelName " +
                    "    from t_Customer q1,t_CustomerType q2,t_Channel q3 " +
                    " where q1.CustTypeID=q2.CustTypeID and q2.ChannelID=q3.ChannelID " +
                    " and  (q1.IsActive=?)  and (q1.CustomerID=?)   and (customer.CustomerName Like ?) ";

            adapter.SelectCommand = cmd;
            try
            {
                oDSCustomer.Clear();                
                cmd.Parameters.AddWithValue("Customer.Suspended", (short)Dictionary.ActiveOrInActiveStatus.ACTIVE);
                cmd.Parameters.AddWithValue("sChannelInfo", sChannelInfo);
                cmd.Parameters.AddWithValue("sSearchString", "%" + sSearchString + "%");
                adapter.Fill(oDSCustomer, "Customer");                  
            }
            catch (Exception e)
            {
                //_olblStatus.Text = e.Message.ToString();
                Debug.WriteLine(e.Message.ToString());
            }    

        }        

        public void GetCustomer(DSCustomer oDSCustomer , string sCustomerID)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbDataAdapter adapter = new OleDbDataAdapter();   
            //cmd.CommandText = 
            //cmd.CommandText = "SELECT Customer.CustomerID, Customer.CustomerName, MainChannel.MainChannelDescription as ChannelName , Customer.Suspended "
            //               + " FROM (Customer INNER JOIN Channel ON Customer.ChannelID = Channel.ChannelID) INNER JOIN MainChannel ON  "
            //                + " Channel.MainChannelID = MainChannel.MainChannelID where Customer.Suspended=? and Customer.CustomerID=? ";


            cmd.CommandText = " select q1.CustomerID,q1.CustomerName,q1.IsActive as Suspended ,q3.ChannelDescription as ChannelName " +
                                "    from t_Customer q1,t_CustomerType q2,t_Channel q3 " +
                                " where q1.CustTypeID=q2.CustTypeID and q2.ChannelID=q3.ChannelID " +
                                " and  (q1.IsActive=?)  and (q1.CustomerID=?) ";

            adapter.SelectCommand = cmd;
            cmd.Parameters.AddWithValue("suspended", (short)Dictionary.ActiveOrInActiveStatus.ACTIVE);
            cmd.Parameters.AddWithValue("CustomerID", sCustomerID);
            try
            {
                oDSCustomer.Clear(); 
                adapter.Fill(oDSCustomer, "Customer");
            }
            catch (Exception e)
            {
                //_olblStatus.Text = e.Message.ToString();
                Debug.WriteLine(e.Message.ToString());
            }           
        }
        
        public void GetAllChannel(DSChannel oDSChannel)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbDataAdapter adapter = new OleDbDataAdapter();   
            
            cmd.CommandText = "Select * from t_Channel";
            adapter.SelectCommand = cmd;
            try
            {
                oDSChannel.Clear();
                adapter.Fill(oDSChannel, "Channel");
            }
            catch (Exception e)
            {
                //_olblStatus.Text = e.Message.ToString();
                Debug.WriteLine(e.Message.ToString());
            }            
        }

    }
}

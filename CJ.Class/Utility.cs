using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Collections;
using System.Data.OleDb;
using System.Security.Principal;
using System.Management;
using System.Data;

using System.Resources;

using System.Windows.Forms;
using System.Drawing;
using CJ.Class;
using CJ.Class.Library;
using System.ComponentModel; //For CollectionHelper
using System.Reflection; //For CollectionHelper
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;

namespace CJ.Class
{
    public class Utility
    {
        //public static OleDbConnection _oConn;
        //public static OleDbTransaction _oTran;
        private static string _sDatabase;
        private static string _sServer;
        private static string _sDBUser;
        private static string _sDBPassword;
        private static string _sDBConnectionString;

        private static int _nUserId;
        private static int _nEmployeeID;
        private static string _sUsername;
        private static string _sUserFullname;
        private static bool _bIsDMS;
        private int _nSatusId;
        private string _sSatus;
        private string _sName;
        private static string _sPassword;
        private static int _nLocationID;
        /// <summary>
        /// testing 
        /// </summary>
        /// 
        public static string DBConnectionString
        {
            get { return _sDBConnectionString; }
            set { _sDBConnectionString = value; }
        }

        public static string Database
        {
            get { return _sDatabase; }
            set { _sDatabase = value; }
        }
        public static string Server
        {
            get { return _sServer; }
            set { _sServer = value; }
        }
        public static string DBUser
        {
            get { return _sDBUser; }
            set { _sDBUser = value; }
        }
        public static string DBPassword
        {
            get { return _sDBPassword; }
            set { _sDBPassword = value; }
        }


        private static string _sShowroomCode;
        public static string ShowroomCode
        {
            get { return _sShowroomCode; }
            set { _sShowroomCode = value; }
        }

        private static string _sCustomerCode;
        public static string CustomerCode
        {
            get { return _sCustomerCode; }
            set { _sCustomerCode = value; }
        }
        private static string _sCustomerName;
        public static string CustomerName
        {
            get { return _sCustomerName; }
            set { _sCustomerName = value; }
        }
        private static int _nWarehouseID;
        public static int WarehouseID
        {
            get { return _nWarehouseID; }
            set { _nWarehouseID = value; }
        }
        private static int _nCustomerTypeID;
        public static int CustomerTypeID
        {
            get { return _nCustomerTypeID; }
            set { _nCustomerTypeID = value; }
        }
        private static string _sWarehouseCode;
        public static string WarehouseCode
        {
            get { return _sWarehouseCode; }
            set { _sWarehouseCode = value; }
        }
        private static string _sShortcode;
        public static string Shortcode
        {
            get { return _sShortcode; }
            set { _sShortcode = value; }
        }

        private static string _sWarehouseName;
        public static string WarehouseName
        {
            get { return _sWarehouseName; }
            set { _sWarehouseName = value; }
        }
        private static string _sWarehouseAddress;
        public static string WarehouseAddress
        {
            get { return _sWarehouseAddress; }
            set { _sWarehouseAddress = value; }
        }
        private static int _nCustomerID;
        public static int CustomerID
        {
            get { return _nCustomerID; }
            set { _nCustomerID = value; }
        }
        private static int _nChannelID;
        public static int ChannelID
        {
            get { return _nChannelID; }
            set { _nChannelID = value; }
        }
        private static string _sWarehousePhoneNo;
        public static string WarehousePhoneNo
        {
            get { return _sWarehousePhoneNo; }
            set { _sWarehousePhoneNo = value; }
        }
        private static string _sWarehouseCellNo;
        public static string WarehouseCellNo
        {
            get { return _sWarehouseCellNo; }
            set { _sWarehouseCellNo = value; }
        }
        private static string _sWarehouseEmail;
        public static string WarehouseEmail
        {
            get { return _sWarehouseEmail; }
            set { _sWarehouseEmail = value; }
        }
        private static string _sHCMobileNo;
        public static string HCMobileNo
        {
            get { return _sHCMobileNo; }
            set { _sHCMobileNo = value; }
        }
        private static string _sHCPhoneNo;
        public static string HCPhoneNo
        {
            get { return _sHCPhoneNo; }
            set { _sHCPhoneNo = value; }
        }
        private static string _sHCEmail;
        public static string HCEmail
        {
            get { return _sHCEmail; }
            set { _sHCEmail = value; }
        }
        private static string _sVATRegistrationNo;
        public static string VATRegistrationNo
        {
            get { return _sVATRegistrationNo; }
            set { _sVATRegistrationNo = value; }
        }
        private static string _sCentralRegisteredPersonAddress;
        public static string CentralRegisteredPersonAddress
        {
            get { return _sCentralRegisteredPersonAddress; }
            set { _sCentralRegisteredPersonAddress = value; }
        }


        public static int LocationID
        {
            get { return _nLocationID; }
            set { _nLocationID = value; }
        }


        private static object _dSystemDate;
        public static object SystemDate
        {
            get { return _dSystemDate; }
            set { _dSystemDate = value; }
        }

        private static DateTime _dServerDatetime;
        public static DateTime ServerDatetime
        {
            get { return _dServerDatetime; }
            set { _dServerDatetime = value; }
        }

        private static int _nIsThermalPrintEnable;

        public static int IsThermalPrintEnable
        {
            get { return _nIsThermalPrintEnable; }
            set { _nIsThermalPrintEnable = value; }
        }

        private static int _nIsCheckServerDateTime;

        public static int IsCheckServerDateTime
        {
            get { return _nIsCheckServerDateTime; }
            set { _nIsCheckServerDateTime = value; }
        }

        


        public static int UserId
        {
            get { return _nUserId; }
            set { _nUserId = value; }
        }
        public static int EmployeeID
        {
            get { return _nEmployeeID; }
            set { _nEmployeeID = value; }
        }
        public int SatusId
        {
            get { return _nSatusId; }
            set { _nSatusId = value; }
        }
        public static string Username
        {
            get { return _sUsername; }
            set { _sUsername = value; }
        }
        private static string _sEmployeeDetail;
        public static string EmployeeDetail
        {
            get { return _sEmployeeDetail; }
            set { _sEmployeeDetail = value; }
        }
        public static string UserFullname
        {
            get { return _sUserFullname; }
            set { _sUserFullname = value; }
        }
        public static bool bIsDMS
        {
            get { return _bIsDMS; }
            set { _bIsDMS = value; }
        }
        public string Satus
        {
            get { return _sSatus; }
            set { _sSatus = value; }
        }
        public string Name
        {
            get { return _sName; }
            set { _sName = value; }
        }
        public static string Password
        {
            get { return _sPassword; }
            set { _sPassword = value; }
        }


        public static bool PingHost(string nameOrAddress)
        {
            bool pingable = false;
            Ping pinger = null;

            try
            {
                pinger = new Ping();
                PingReply reply = pinger.Send(nameOrAddress);
                pingable = reply.Status == IPStatus.Success;
            }
            catch (PingException ex)
            {
                // Discard PingExceptions and return false;
            }
            finally
            {
                if (pinger != null)
                {
                    pinger.Dispose();
                }
            }

            return pingable;
        }
        #region SQL Pagination by Zahid
        public static string ConvertToPaginationQuery(string query, int pageIndex, int pageSize)
        {
            var pagination = @"DECLARE @PageNumber AS INT DECLARE @RowsOfPage AS INT SET @PageNumber={0} SET @RowsOfPage={1} {2} OFFSET (@PageNumber-1)*@RowsOfPage ROWS FETCH NEXT @RowsOfPage ROWS ONLY";
            pagination = string.Format(pagination, pageIndex, pageSize, query);
            return pagination;
        }
        #endregion

        [DllImport("wininet.dll")]
        public extern static bool InternetGetConnectedState(out int Description, int ReservedValue);

        public static bool CheckInternetConnection()//Hakim
        {
            try
            {
                using (System.Net.WebClient client = new System.Net.WebClient())
                using (System.IO.Stream stream = client.OpenRead("http://www.google.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public static bool CheckTELWEBServer()//Hakim
        {
            try
            {
                using (System.Net.WebClient client = new System.Net.WebClient())
                using (System.IO.Stream stream = client.OpenRead("http://telmisdev.com"))
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
        public static string Terminal
        {
            get { return ConfigurationManager.AppSettings["Terminal"]; }

        }
        public static string CompanyName
        {
            get { return ConfigurationManager.AppSettings["CompanyName"]; }

        }
        public static string DMSCompanyInfo
        {
            get { return ConfigurationManager.AppSettings["DMSCompanyInfo"]; }

        }
        public static string CompanyInfo
        {
            get { return ConfigurationManager.AppSettings["CompanyInfo"]; }

        }
        public static string POSWarehouse
        {
            get { return ConfigurationManager.AppSettings["POSWarehouse"]; }

        }
        public static string InvoiceWarehouse
        {
            get { return ConfigurationManager.AppSettings["InvoiceWarehouse"]; }

        }

        public static int WarehouseParentID
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["WarehouseParentID"].ToString()); }

        }
        public static int StockTransferWHID
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["StockTransferWHID"].ToString()); }

        }

        public static int EPSWarehouse
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["EPSWarehouse"].ToString()); }

        }
        public static int WebStore
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["WebStore"].ToString()); }

        }
        public static string WebStoreCustomer
        {
            get { return ConfigurationManager.AppSettings["WebStoreCustomer"]; }

        }

        public static int JobLocation
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["JobLocationID"].ToString()); }

        }
        public static int DMSWarehouse
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["DMSWarehouseid"].ToString()); }

        }
        public static int DMSMakeOrderID
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["DMSMakeOrderID"].ToString()); }

        }
        public static string WebLinkType
        {
            get { return ConfigurationManager.AppSettings["WebLinkType"]; }

        }
        public static string DMSProProductID
        {
            get { return ConfigurationManager.AppSettings["DMSProProductID"]; }

        }
        public static string Module
        {
            get { return ConfigurationManager.AppSettings["Module"]; }

        }
        public static int CentralRetailWarehouse
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["CentralRetailWarehouse"].ToString()); }

        }

        public static int RequisitionDeliveryWarehouse
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["RequisitionDeliveryWarehouse"].ToString()); }

        }
        public static int CentralTMLWarehouse
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["CentralTMLWarehouse"].ToString()); }

        }
        public static int CentralTMLChannel
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["CentralTMLChannel"].ToString()); }

        }
        public static int CSDWarehouse
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["CSDWarehouse"].ToString()); }

        }
        public static int CustTypeID
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["CustTypeID"].ToString()); }

        }
        public static int CustomerType_TDHPA
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["CustomerType_TDHPA"].ToString()); }

        }
        public static int CustomerType_TDCorporate
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["CustomerType_TDCorporate"].ToString()); }

        }
        public static int B2B_Market_GroupID
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["B2B_Market_GroupID"].ToString()); }

        }
        public static int CustomerType_Electronics_Dealer
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["CustomerType_Electronics_Dealer"].ToString()); }

        }
        public static string GetWorkStationDetails()
        {
            string sKey;
            sKey = "WIN32_Processor";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("select SystemName from " + sKey);
            foreach (ManagementObject share in searcher.Get())
            {
                foreach (PropertyData PC in share.Properties)
                {
                    if (PC.Value != null && PC.Value.ToString() != "")
                    {
                        return PC.Value.ToString();
                    }
                }
            }
            return " ";
        }
        public static int HOID
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["HOID"].ToString()); }

        }
        public static int TDOID
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["TDOID"].ToString()); }

        }
        public static int PromotionParentWHID
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["PromotionParentWHID"].ToString()); }

        }
        public static int RetailChannelID
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["RetailChannelID"].ToString()); }

        }
        public static int TDCorporateChannelID
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["TDCorporateChannelID"].ToString()); }

        }
        public static int TDHPAChannelID
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["TDHPAChannelID"].ToString()); }

        }
        public static int DealerChannelID
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["DealerChannelID"].ToString()); }

        }
        public static int ClaimWHID
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["ClaimWHID"].ToString()); }

        }
        public static int ReengineeredWHID
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["ReengineeredWHID"].ToString()); }

        }
        public static int ReplaceWHID
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["ReplaceWHID"].ToString()); }

        }
        public static int TDEPSEzeeBuy
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["TDEPSEzeeBuy"].ToString()); }

        }
        public static int TDRetailChannelID
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["TDRetailChannelID"].ToString()); }

        }

        public static int SESChannel
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["SESChannel"].ToString()); }

        }
        public static int SMDPChannel
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["SMDPChannel"].ToString()); }

        }
        public static int SESWarehouse
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["SESWarehouse"].ToString()); }

        }
        public static int SMDPWarehouse
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["SMDPWarehouse"].ToString()); }

        }
        public static int CSD_WHID_from_TD_Return_Product
        {
            get { return Convert.ToInt32(ConfigurationManager.AppSettings["CSD_WHID_from_TD_Return_Product"].ToString()); }

        }
        public static bool IsVATApplicable
        {
            get { return Convert.ToBoolean(ConfigurationManager.AppSettings["IsVATApplicable"].ToString()); }

        }
        public static string AttendanceXAMPPServer
        {
            get { return ConfigurationManager.AppSettings["AttendanceXAMPPServer"]; }

        }
        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

        public static DSPermission UserPermission;

    }
    public class Utilities : CollectionBase
    {

        public Utility this[int i]
        {
            get { return (Utility)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public int GetIndexByID(int nSatusId)
        {
            int i = 0;
            foreach (Utility oUtility in this)
            {
                if (oUtility.SatusId == nSatusId)
                    return i;
                i++;
            }
            return -1;
        }


        public void Add(Utility oUtility)
        {
            InnerList.Add(oUtility);
        }

        public void GetStatus()
        {
            InnerList.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.PurchaseRequisitionStatus)))
            {
                Utility oUtility = new Utility();
                oUtility.SatusId = GetEnum;
                oUtility.Satus = Enum.GetName(typeof(Dictionary.PurchaseRequisitionStatus), GetEnum);
                InnerList.Add(oUtility);
            }
            InnerList.TrimToSize();

        }
        public void CommercialInvoiceStatus()
        {
            InnerList.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CommercialInvoiceStatus)))
            {
                Utility oUtility = new Utility();
                oUtility.SatusId = GetEnum;
                oUtility.Satus = Enum.GetName(typeof(Dictionary.CommercialInvoiceStatus), GetEnum);
                InnerList.Add(oUtility);
            }
            InnerList.TrimToSize();

        }
        public void GetOrderStatus()
        {
            InnerList.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.OrderStatus)))
            {
                Utility oUtility = new Utility();
                oUtility.SatusId = GetEnum;
                oUtility.Satus = Enum.GetName(typeof(Dictionary.OrderStatus), GetEnum);
                InnerList.Add(oUtility);
            }
            InnerList.TrimToSize();

        }
        public void GetInvoiceStatus()
        {
            InnerList.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.InvoiceStatus)))
            {
                Utility oUtility = new Utility();
                oUtility.SatusId = GetEnum;
                oUtility.Satus = Enum.GetName(typeof(Dictionary.InvoiceStatus), GetEnum);
                InnerList.Add(oUtility);
            }
            InnerList.TrimToSize();

        }

        public void GetOutletCatagory()
        {
            InnerList.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.OuletCatagory)))
            {
                Utility oUtility = new Utility();
                oUtility.SatusId = GetEnum;
                oUtility.Satus = Enum.GetName(typeof(Dictionary.OuletCatagory), GetEnum);
                InnerList.Add(oUtility);
            }
            InnerList.TrimToSize();

        }
        public void GetOutletSubCatagory()
        {
            InnerList.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.OuletSubCatagory)))
            {
                Utility oUtility = new Utility();
                oUtility.SatusId = GetEnum;
                oUtility.Satus = Enum.GetName(typeof(Dictionary.OuletSubCatagory), GetEnum);
                InnerList.Add(oUtility);
            }
            InnerList.TrimToSize();

        }
        public void GetDMSMarketType()
        {
            InnerList.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.DMSMarketType)))
            {
                Utility oUtility = new Utility();
                oUtility.SatusId = GetEnum;
                oUtility.Satus = Enum.GetName(typeof(Dictionary.DMSMarketType), GetEnum);
                InnerList.Add(oUtility);
            }
            InnerList.TrimToSize();

        }
        public void GetInoviceType()
        {
            Utility oUtility;
            InnerList.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.InvoiceType)))
            {
                oUtility = new Utility();
                oUtility.SatusId = GetEnum;
                oUtility.Satus = Enum.GetName(typeof(Dictionary.InvoiceType), GetEnum);
                InnerList.Add(oUtility);
            }
            oUtility = new Utility();
            oUtility.SatusId = -1;
            oUtility.Satus = "ALL";
            InnerList.Add(oUtility);
            InnerList.TrimToSize();

        }
        public void GetComplainCategoryBeforeSale()
        {
            InnerList.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ComplainCat_BeforeSale)))
            {
                Utility oUtility = new Utility();
                oUtility.SatusId = GetEnum;
                oUtility.Satus = Enum.GetName(typeof(Dictionary.ComplainCat_BeforeSale), GetEnum);
                InnerList.Add(oUtility);
            }
            InnerList.TrimToSize();

        }
        public void GetComplainCategoryAfterSale()
        {
            InnerList.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ComplainCat_AfterSale)))
            {
                Utility oUtility = new Utility();
                oUtility.SatusId = GetEnum;
                oUtility.Satus = Enum.GetName(typeof(Dictionary.ComplainCat_AfterSale), GetEnum);
                InnerList.Add(oUtility);
            }
            InnerList.TrimToSize();

        }
        public void GetComplainType()
        {
            InnerList.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ComplainType)))
            {
                Utility oUtility = new Utility();
                oUtility.SatusId = GetEnum;
                oUtility.Satus = Enum.GetName(typeof(Dictionary.ComplainType), GetEnum);
                InnerList.Add(oUtility);
            }
            InnerList.TrimToSize();

        }
        public void GetInquiryCategoryBeforeSale()
        {
            InnerList.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.InquiryCategoryBeforeSale)))
            {
                Utility oUtility = new Utility();
                oUtility.SatusId = GetEnum;
                oUtility.Satus = Enum.GetName(typeof(Dictionary.InquiryCategoryBeforeSale), GetEnum);
                InnerList.Add(oUtility);
            }
            InnerList.TrimToSize();

        }
        public void GetInquiryCategoryAfterSale()
        {
            InnerList.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.InquiryCategoryAfterSale)))
            {
                Utility oUtility = new Utility();
                oUtility.SatusId = GetEnum;
                oUtility.Satus = Enum.GetName(typeof(Dictionary.InquiryCategoryAfterSale), GetEnum);
                InnerList.Add(oUtility);
            }
            InnerList.TrimToSize();

        }
        public void GetInquiryResponse()
        {
            InnerList.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.InquiryResponse)))
            {
                Utility oUtility = new Utility();
                oUtility.SatusId = GetEnum;
                oUtility.Satus = Enum.GetName(typeof(Dictionary.InquiryResponse), GetEnum);
                InnerList.Add(oUtility);
            }
            InnerList.TrimToSize();

        }
        public void GetInquiryReferOutlet()
        {
            InnerList.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.InquiryReferChannel)))
            {
                Utility oUtility = new Utility();
                oUtility.SatusId = GetEnum;
                oUtility.Satus = Enum.GetName(typeof(Dictionary.InquiryReferChannel), GetEnum);
                InnerList.Add(oUtility);
            }
            InnerList.TrimToSize();

        }
        public void GetInquirySalesNoExecuted()
        {
            InnerList.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.InquirySalesNoExecuatedReason)))
            {
                Utility oUtility = new Utility();
                oUtility.SatusId = GetEnum;
                oUtility.Satus = Enum.GetName(typeof(Dictionary.InquirySalesNoExecuatedReason), GetEnum);
                InnerList.Add(oUtility);
            }
            InnerList.TrimToSize();

        }
        public void GetComplainStatus()
        {
            InnerList.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ComplainStatus)))
            {
                Utility oUtility = new Utility();
                oUtility.SatusId = GetEnum;
                oUtility.Satus = Enum.GetName(typeof(Dictionary.ComplainStatus), GetEnum);
                InnerList.Add(oUtility);
            }
            InnerList.TrimToSize();

        }
        public void GetReplaceStatus()
        {
            InnerList.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ReplaceStatusCriteria)))
            {
                Utility oUtility = new Utility();
                oUtility.SatusId = GetEnum;
                oUtility.Satus = Enum.GetName(typeof(Dictionary.ReplaceStatusCriteria), GetEnum);
                InnerList.Add(oUtility);
            }
            InnerList.TrimToSize();

        }
        public void GetPaidJobStatus()
        {
            InnerList.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ISPaidJobStatus)))
            {
                Utility oUtility = new Utility();
                oUtility.SatusId = GetEnum;
                oUtility.Satus = Enum.GetName(typeof(Dictionary.ISPaidJobStatus), GetEnum);
                InnerList.Add(oUtility);
            }
            InnerList.TrimToSize();
        }

        //public void GetReplacePapersLocation()
        //{
        //    InnerList.Clear();
        //    foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ReplacePapersLocation)))
        //    {
        //        Utility oUtility = new Utility();
        //        oUtility.SatusId = GetEnum;
        //        oUtility.Satus = Enum.GetName(typeof(Dictionary.ReplacePapersLocation), GetEnum);
        //        InnerList.Add(oUtility);
        //    }
        //    InnerList.TrimToSize();

        //}
        public void GetTransactionType()
        {
            Utility oUtility;
            InnerList.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.TransectionType)))
            {

                oUtility = new Utility();
                oUtility.SatusId = GetEnum;
                oUtility.Satus = Enum.GetName(typeof(Dictionary.TransectionType), GetEnum);
                InnerList.Add(oUtility);
            }
            oUtility = new Utility();
            oUtility.SatusId = -1;
            oUtility.Satus = "ALL";
            InnerList.Add(oUtility);
            InnerList.TrimToSize();


        }
        public void GetSupplyType()
        {
            Utility oUtility;
            InnerList.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SupplyType)))
            {

                oUtility = new Utility();
                oUtility.SatusId = GetEnum;
                oUtility.Satus = Enum.GetName(typeof(Dictionary.SupplyType), GetEnum);
                InnerList.Add(oUtility);
            }
            oUtility = new Utility();
            oUtility.SatusId = -1;
            oUtility.Satus = "ALL";
            InnerList.Add(oUtility);
            InnerList.TrimToSize();

        }
        public void GetDutyType()
        {
            Utility oUtility;
            InnerList.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.DutyType)))
            {
                oUtility = new Utility();
                oUtility.SatusId = GetEnum;
                oUtility.Satus = Enum.GetName(typeof(Dictionary.DutyType), GetEnum);
                InnerList.Add(oUtility);
            }
            InnerList.TrimToSize();

        }

        public void GetIsEMI()
        {
            InnerList.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.YesOrNoStatus)))
            {
                Utility oUtility = new Utility();
                oUtility.SatusId = GetEnum;
                oUtility.Satus = Enum.GetName(typeof(Dictionary.YesOrNoStatus), GetEnum);
                InnerList.Add(oUtility);
            }
            InnerList.TrimToSize();

        }

        public void GetLCMQCStatus()
        {
            InnerList.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.LCMQCStatus)))
            {
                Utility oUtility = new Utility();
                oUtility.SatusId = GetEnum;
                oUtility.Satus = Enum.GetName(typeof(Dictionary.LCMQCStatus), GetEnum);
                InnerList.Add(oUtility);
            }
            InnerList.TrimToSize();

        }

        public void GetRootcause()
        {
            InnerList.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.LCMRootcause)))
            {
                Utility oUtility = new Utility();
                oUtility.SatusId = GetEnum;
                oUtility.Satus = Enum.GetName(typeof(Dictionary.LCMRootcause), GetEnum);
                InnerList.Add(oUtility);
            }
            InnerList.TrimToSize();

        }

        public void GetCreditCardType()
        {
            InnerList.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CreditCardType)))
            {
                Utility oUtility = new Utility();
                oUtility.SatusId = GetEnum;
                oUtility.Satus = Enum.GetName(typeof(Dictionary.CreditCardType), GetEnum);
                InnerList.Add(oUtility);
            }
            InnerList.TrimToSize();

        }
        /// <summary>
        /// Shuvo Date-21-Aug-2015
        /// </summary>
        public void GetOverStkReasonBLL()
        {
            InnerList.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.OverStockReason)))
            {
                Utility oUtility = new Utility();
                oUtility.SatusId = GetEnum;
                oUtility.Satus = Enum.GetName(typeof(Dictionary.OverStockReason), GetEnum);
                InnerList.Add(oUtility);
            }
            InnerList.TrimToSize();

        }

        /// <summary>
        /// Shuvo Date-20-Mar-2015
        /// CSD Mark
        /// </summary>
        public void CSDMark()
        {
            InnerList.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CSDMark)))
            {
                Utility oUtility = new Utility();
                oUtility.SatusId = GetEnum;
                oUtility.Satus = Enum.GetName(typeof(Dictionary.CSDMark), GetEnum);
                InnerList.Add(oUtility);
            }
            InnerList.TrimToSize();

        }



        public void SalesLeadMark()
        {
            InnerList.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SalesLeadMark)))
            {
                Utility oUtility = new Utility();
                oUtility.SatusId = GetEnum;
                oUtility.Satus = Enum.GetName(typeof(Dictionary.SalesLeadMark), GetEnum);
                InnerList.Add(oUtility);
            }
            InnerList.TrimToSize();

        }

        public void GetCreditCardCategory()
        {
            InnerList.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.CreditCardCategory)))
            {
                Utility oUtility = new Utility();
                oUtility.SatusId = GetEnum;
                oUtility.Satus = Enum.GetName(typeof(Dictionary.CreditCardCategory), GetEnum);
                InnerList.Add(oUtility);
            }
            InnerList.TrimToSize();

        }


        public void GetItemCategory()
        {
            Utility oUtility;
            InnerList.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ItemCategory)))
            {
                oUtility = new Utility();
                oUtility.SatusId = GetEnum;
                oUtility.Satus = Enum.GetName(typeof(Dictionary.ItemCategory), GetEnum);
                InnerList.Add(oUtility);
            }
            InnerList.TrimToSize();

        }
        public void GetECOrderStatus()
        {
            InnerList.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ECOrderStatus)))
            {
                Utility oUtility = new Utility();
                oUtility.SatusId = GetEnum;
                oUtility.Satus = Enum.GetName(typeof(Dictionary.ECOrderStatus), GetEnum);
                InnerList.Add(oUtility);
            }
            InnerList.TrimToSize();

        }
        public void GetECOrderStatusForTD()
        {
            InnerList.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ECOrderStatus)))
            {
                Utility oUtility = new Utility();
                oUtility.SatusId = GetEnum;
                oUtility.Satus = Enum.GetName(typeof(Dictionary.ECOrderStatus), GetEnum);
                if (oUtility.SatusId == (int)Dictionary.ECOrderStatus.Confirm_Stock_Outlet || oUtility.SatusId == (int)Dictionary.ECOrderStatus.UnAvailable_Stock_Outlet ||
                     oUtility.SatusId == (int)Dictionary.ECOrderStatus.Stock_to_be_Available_Within_2WD || oUtility.SatusId == (int)Dictionary.ECOrderStatus.Stock_to_be_Available_later ||
                     oUtility.SatusId == (int)Dictionary.ECOrderStatus.Stock_No_Longer_Available || oUtility.SatusId == (int)Dictionary.ECOrderStatus.Order_Confirmation_from_Customer ||
                     oUtility.SatusId == (int)Dictionary.ECOrderStatus.Pick_Up_DD_Extended || oUtility.SatusId == (int)Dictionary.ECOrderStatus.Confirm_Payment ||
                     oUtility.SatusId == (int)Dictionary.ECOrderStatus.Product_Delivered)
                    InnerList.Add(oUtility);
            }
            InnerList.TrimToSize();

        }
        public void GetECPaymentMode()
        {
            InnerList.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ECOPaymentMode)))
            {
                Utility oUtility = new Utility();
                oUtility.SatusId = GetEnum;
                oUtility.Satus = Enum.GetName(typeof(Dictionary.ECOPaymentMode), GetEnum);
                InnerList.Add(oUtility);
            }
            InnerList.TrimToSize();

        }
        public void GetECDeliveryMode()
        {
            InnerList.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ECDeliveryMode)))
            {
                Utility oUtility = new Utility();
                oUtility.SatusId = GetEnum;
                oUtility.Satus = Enum.GetName(typeof(Dictionary.ECDeliveryMode), GetEnum);
                InnerList.Add(oUtility);
            }
            InnerList.TrimToSize();

        }
        public void GetECCategory()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            InnerList.Clear();
            string sSql = " select distinct PCategory from t_ECProduct ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Utility oUtility = new Utility();

                    oUtility.Satus = reader["PCategory"].ToString();

                    InnerList.Add(oUtility);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetECSubCategory()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            InnerList.Clear();
            string sSql = " select distinct PSubCategory from t_ECProduct ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Utility oUtility = new Utility();

                    oUtility.Satus = reader["PSubCategory"].ToString();

                    InnerList.Add(oUtility);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }
        public void GetECBrand()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            InnerList.Clear();
            string sSql = " select distinct PBrand from t_ECProduct ";
            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Utility oUtility = new Utility();

                    oUtility.Satus = reader["PBrand"].ToString();

                    InnerList.Add(oUtility);
                }

                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }

        /// <summary>
        /// Shuvo 
        /// Date-23-Aug-2016
        /// For Exchanged Offer Job Creation
        /// </summary>
        public void GetExchangedProductType()
        {
            InnerList.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ExchangeProduct)))
            {
                Utility oUtility = new Utility();
                oUtility.SatusId = GetEnum;
                oUtility.Satus = Enum.GetName(typeof(Dictionary.ExchangeProduct), GetEnum);
                InnerList.Add(oUtility);
            }
            InnerList.TrimToSize();

        }
        public void GetExchangedProductHaveRemort()
        {
            InnerList.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ExOHaveRemote)))
            {
                Utility oUtility = new Utility();
                oUtility.SatusId = GetEnum;
                oUtility.Satus = Enum.GetName(typeof(Dictionary.ExOHaveRemote), GetEnum);
                InnerList.Add(oUtility);
            }
            InnerList.TrimToSize();

        }
        public void GetExchangedProductCondition()
        {
            InnerList.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ExOProductCondition)))
            {
                Utility oUtility = new Utility();
                oUtility.SatusId = GetEnum;
                oUtility.Satus = Enum.GetName(typeof(Dictionary.ExOProductCondition), GetEnum);
                InnerList.Add(oUtility);
            }
            InnerList.TrimToSize();

        }
        public void GetAttendanceStatusOutlet()
        {
            InnerList.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.HRAttendanceStatusForOutlet)))
            {
                Utility oUtility = new Utility();
                oUtility.SatusId = GetEnum;
                oUtility.Satus = Enum.GetName(typeof(Dictionary.HRAttendanceStatusForOutlet), GetEnum);
                InnerList.Add(oUtility);
            }
            InnerList.TrimToSize();

        }

    }

    // <summary>
    // Author: Arif Khan
    // Date: May 7, 2014
    // Time :  12:00 PM
    // Description: Collection Helper to Convert Collection Object to DataTable.
    // Source: http://vault.lozanotek.com/archive/2007/05/09/Converting_Custom_Collections_To_and_From_DataTable.aspx
    // </summary>
    public class CollectionHelper
    {
        private CollectionHelper()
        {
        }

        public static DataTable ConvertTo<T>(IList<T> list)
        {
            DataTable table = CreateTable<T>();
            Type entityType = typeof(T);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

            foreach (T item in list)
            {
                DataRow row = table.NewRow();

                foreach (PropertyDescriptor prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item);
                }

                table.Rows.Add(row);
            }

            return table;
        }

        public static IList<T> ConvertTo<T>(IList<DataRow> rows)
        {
            IList<T> list = null;

            if (rows != null)
            {
                list = new List<T>();

                foreach (DataRow row in rows)
                {
                    T item = CreateItem<T>(row);
                    list.Add(item);
                }
            }

            return list;
        }

        public static IList<T> ConvertTo<T>(DataTable table)
        {
            if (table == null)
            {
                return null;
            }

            List<DataRow> rows = new List<DataRow>();

            foreach (DataRow row in table.Rows)
            {
                rows.Add(row);
            }

            return ConvertTo<T>(rows);
        }

        public static T CreateItem<T>(DataRow row)
        {
            T obj = default(T);
            if (row != null)
            {
                obj = Activator.CreateInstance<T>();

                foreach (DataColumn column in row.Table.Columns)
                {
                    PropertyInfo prop = obj.GetType().GetProperty(column.ColumnName);
                    try
                    {
                        object value = row[column.ColumnName];
                        prop.SetValue(obj, value, null);
                    }
                    catch
                    {
                        // You can log something here
                        throw;
                    }
                }
            }

            return obj;
        }

        public static DataTable CreateTable<T>()
        {
            Type entityType = typeof(T);
            DataTable table = new DataTable(entityType.Name);
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(entityType);

            foreach (PropertyDescriptor prop in properties)
            {
                table.Columns.Add(prop.Name, prop.PropertyType);
            }

            return table;
        }
    }
}

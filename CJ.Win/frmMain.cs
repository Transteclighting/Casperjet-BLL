/// <summary>
/// Compamy: Transcom Electronics Limited
/// Author: Shyam Sundar Biswas
/// Date: March 21, 2011
/// Time : 10:00 PM
/// Description: Main form.
/// Modify Person And Date:
/// </summary>


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Configuration;
using System.Diagnostics;
using System.Security.Principal;
using System.Resources;

using CJ.Class;
using CJ.Win.Security;
using CJ.Win.IT;
using CJ.Win.DMS;
using CJ.Win.POS;
using CJ.Win.EPS;
using CJ.Win.HR;
using CJ.Win.Inventory;
using CJ.Win.Admin;
using CJ.Win.Promotion;
using CJ.Win.CLP;
using CJ.Win.Warranty;
using CJ.Win.Distribution;
using CJ.Win.Process;
using CJ.Win.Duty;
using CJ.Win.Ecommerce;
using CJ.Win.Claim;
using CJ.Win.Basic;
using CJ.Win.ERP;
using CJ.Win.SupplyChain;
using CJ.Win.CSD;
using CJ.Win.CSD.Reception;
using CJ.Win.CSD.CallCenter;
using CJ.Win.CSD.Workshop;
using CJ.Win.CSD.Store;
using CJ.Win.Plan;
using CJ.Win.Accounts;
using CJ.Win.BEIL;
using CJ.Win.Retail;
using CJ.Win.Dealer;
using CJ.Win.CAC;
using CJ.Win.HR.Recruitment;
using CJ.Win.SMS;
using CJ.Win.CSD.Account;
using CJ.Win.Replace_Management;
using CJ.Win.BEIL.Tool_Management;
using CJ.Class.POS;
//using CJ.Win.BEIL.ToolManagement;

namespace CJ.Win
{
    public partial class frmMain : Form
    {
        private DSPermission _oDsPermission = new DSPermission();
        private DataRow[] _oChildRow;
        private string _sParentKey;
        private string _sXmlPath;
        Users oUsers = new Users();
        //Properties.Resources
        public frmMain()
        {
            InitializeComponent();
        }
        private bool VersionCheck(string sVersionNo)
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            int nCount = 0;
            if (sVersionNo != version)
            {
                nCount++;
            }
            if (nCount == 0)
                return false;
            else return true;

        }
        private void frmMain_Load(object sender, EventArgs e)
        {

            //if (!DBController.Instance.CheckConnection())
            //{
                DBController.Instance.OpenNewConnection();
            //}
            this.Text = Utility.CompanyName;
            //SystemInfo oSystemInfo = new SystemInfo();
            //oSystemInfo.RefreshHO();
            //DateTime dtLockedDate = oSystemInfo.CJVersionLaunchedDate.AddDays(6);

            //if (VersionCheck(oSystemInfo.CJVersionNo))
            //{
            //    if (dtLockedDate <= DateTime.Now.Date)
            //    {
            //        MessageBox.Show("Your system has locked!!!! \nPlease Contact with concern person Immediately", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        Application.Exit();
            //    }
            //}
            DisableMenu();
            try
            {
                AppLogger.LogInfo("Disable Menu");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            string version = fvi.FileVersion;
            this.Text = Utility.CompanyName + " [version: " + version + "]";
        }
        private void DisableMenu()
        {
            mnuLogIn.Enabled = true;
            mnuLogOut.Enabled = false;
            mnuChangePassword.Enabled = false;
            mnuManageUser.Enabled = false;
            SyncToolBar();
            tvwMainMenu.Nodes.Clear();
            WinLogInfor.Text = "";
            CasperLogInfo.Text = "";
            SystemTime.Text = "";
            CurrentDatabase.Text = "";
            CurrentSeverName.Text = "";
        }
        private void SyncToolBar()
        {
            tsbLogIn.Enabled = mnuLogIn.Enabled;
            tsbLogOut.Enabled = mnuLogOut.Enabled;
            tsbChangePassword.Enabled = mnuChangePassword.Enabled;
            tsbManageUser.Enabled = mnuManageUser.Enabled;
        }

        private void logIn(object sender, EventArgs e)
        {
            frmLogIn frmLogin = new frmLogIn();
            DialogResult oResult = frmLogin.ShowDialog();
            if (oResult == DialogResult.OK)
            {
                PopulateNodes(frmLogin.oUser.UserId);
                tvwMainMenu.CollapseAll();
                setOtherPermission(frmLogin.oUser.UserId);
            }
            else
            {
                return;
            }
            string sCurrentWinLogingName;


            sCurrentWinLogingName = WindowsIdentity.GetCurrent().Name;
            WinLogInfor.Text = sCurrentWinLogingName;

            CasperLogInfo.Text = frmLogin.oUser.UserFullName + "[" + frmLogin.oUser.Username + "]";
            SystemTime.Text = "Logon: " + DateTime.Today.ToString();
            //string[] sConn;
            //string[] sConnDB;
            //string[] sConnSV;
            //sConn = ConfigurationManager.AppSettings["ConnectionString"].Split(';');
            //sConnDB = sConn[1].Split('=');
            //CurrentDatabase.Text = "Current Database: " + sConnDB[1].ToString();
            //sConnSV = sConn[2].Split('=');
            //CurrentSeverName.Text = "Current Server: " + sConnSV[1].ToString();

            CurrentDatabase.Text = "Current Database: " + Utility.Database;
            CurrentSeverName.Text = "Current Server:" + Utility.Server;
        }
        private void manageUser(object sender, EventArgs e)
        {
            frmUsers oForm = new frmUsers();
            oForm.MdiParent = this;
            oForm.Show();
        }

        public void PopulateNodes(int nUserId)
        {
            GetMenu();
            foreach (DSPermission.PermissionRow oPermission in _oDsPermission.Permission)
            {
                TreeNode masternode = new TreeNode((string)oPermission["PermissionName"]);
                masternode.Tag = (string)oPermission["PermissionKey"];
                masternode.ImageIndex = 0;
                masternode.SelectedImageIndex = 1;

                if (oPermission.IsParentKeyNull())
                {
                    if (oUsers.checkPermissionFromDS((string)oPermission["PermissionKey"]))
                    //if (oUsers.checkPermission((string)oPermission["PermissionKey"], nUserId))
                    {
                        if (oPermission.IsAvailableApplicationNull() == false)
                        {
                            if ((oPermission.AvailableApplication == (short)Dictionary.ApplicationType.WINDOWS) || (oPermission.AvailableApplication == (short)Dictionary.ApplicationType.WEB_N_WINDOWS))
                            {
                                tvwMainMenu.Nodes.Add(masternode);
                                _sParentKey = "ParentKey= '" + (string)oPermission["PermissionKey"] + "'";
                                GetChildMenu(_sParentKey);
                                populateChild(masternode, _oChildRow, nUserId);


                            }
                        }
                    }
                }
            }

        }
        void GetMenu()
        {
            DSPermission oDSPermission;
            oDSPermission = new DSPermission();
            //_sXmlPath = ConfigurationManager.AppSettings["MenuTree"];

            //ResourceManager resourceManager = new ResourceManager("CJ.Win.Properties.Resources", GetType().Assembly);
            ResourceManager resourceManager = new ResourceManager("CJ.Win.Properties.Resources", this.GetType().Assembly);
            string sMenuTree = (string)resourceManager.GetObject("MenuTree");

            // convert string to stream
            byte[] byteArray = Encoding.ASCII.GetBytes(sMenuTree);
            System.IO.MemoryStream stream = new System.IO.MemoryStream(byteArray);
            try
            {

                //oDSPermission.ReadXml(_sXmlPath);

                oDSPermission.ReadXml(stream);
            }
            catch
            {
                MessageBox.Show("There is an Error in Permission Table.\n There could be a duplicate or Null  Permission Key");
            }

            //Tree node 
            DataRow[] oNodeRow = oDSPermission.Permission.Select("MenuType < '" + (short)Dictionary.MenuType.Buttton + "'");
            _oDsPermission.Clear();
            _oDsPermission.Merge(oNodeRow);
            _oDsPermission.AcceptChanges();

        }

        void GetChildMenu(string pKey)
        {
            DataTable oChildNodeRows = _oDsPermission.Tables["Permission"];
            _oChildRow = oChildNodeRows.Select(pKey);
        }

        private void populateChild(TreeNode masternode, DataRow[] ChildRows, int nUserId)
        {
            for (int i = 0; i < ChildRows.Length; i++)
            {
                TreeNode childNode = new TreeNode((string)ChildRows[i][1]);
                childNode.Tag = (string)ChildRows[i][0];
                if (oUsers.checkPermissionFromDS((string)ChildRows[i][0]))
                // if (oUsers.checkPermission((string)ChildRows[i][0], nUserId))
                {
                    if (ChildRows[i][5] != System.DBNull.Value)
                    {
                        if (((short)ChildRows[i][5] == (short)Dictionary.ApplicationType.WINDOWS) || ((short)ChildRows[i][5] == (short)Dictionary.ApplicationType.WEB_N_WINDOWS))
                        {
                            masternode.Nodes.Add(childNode);
                            _sParentKey = "ParentKey = '" + (string)ChildRows[i][0] + "'";
                            GetChildMenu(_sParentKey);
                            populateChild(childNode, _oChildRow, nUserId);

                            if (childNode.Nodes.Count == 0)
                            {
                                childNode.ImageIndex = 2;
                                childNode.SelectedImageIndex = 2;
                            }
                            else
                            {
                                childNode.ImageIndex = 0;
                                childNode.SelectedImageIndex = 1;
                            }
                        }
                    }
                }
            }
        }
        private void setOtherPermission(int nUserId)
        {
            //3 for non tree node permission
            DataRow[] oOtherMenuPermission = _oDsPermission.Permission.Select("MenuType >= '" + (short)Dictionary.MenuType.ToolStripOrMenu + "'");
            foreach (DataRow oRow in oOtherMenuPermission)
            {
                string sPermissionKey = oUsers.checkOtherPermission(oRow["PermissionKey"].ToString());
                if (sPermissionKey != null)
                {
                    if (tsbManageUser.Tag.ToString() == sPermissionKey)
                    {
                        tsbManageUser.Enabled = true;
                        mnuManageUser.Enabled = true;
                    }
                    if (tsbChangePassword.Tag.ToString() == sPermissionKey)
                    {
                        tsbChangePassword.Enabled = true;
                        mnuChangePassword.Enabled = true;
                    }
                    if (tsbLogOut.Tag.ToString() == sPermissionKey)
                    {
                        tsbLogOut.Enabled = true;
                        mnuLogOut.Enabled = true;
                    }
                }
            }
            mnuLogIn.Enabled = false;
            tsbLogIn.Enabled = false;
        }

        private void logOut(object sender, EventArgs e)
        {
            DisableMenu();
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void changePassword(object sender, EventArgs e)
        {
            frmChangePassword oForm = new frmChangePassword();
            oForm.MdiParent = this;
            oForm.Show();
        }
        private void ShowUI(string sKey)
        {
            this.CloseAllWindow();
            Form o = null;
            switch (sKey)
            {
                //==========================================================
                //Security M1
                //==========================================================

                case "M1.1":
                    o = new frmUsers();
                    break;
                case "M1.2":
                    o = new frmLogIn();
                    break;
                case "M1.3":
                    o = new frmChangePassword();
                    break;
                case "M1.4":
                    DisableMenu();
                    break;

                //==========================================================
                //Android User Authentication
                //==========================================================
                case "M1.70":
                    o = new frmUserRegistrations();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M1.71":
                    o = new frmUserOthers();
                    o.MdiParent = this;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                //==========================================================
                //Company M2.1
                //==========================================================
                case "M2.1.1":
                    o = new frmCompanys();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M2.2.1":
                    o = new frmSBUs();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M2.3.1":
                    o = new frmChannels();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;


                //M2.13.5
                //==========================================================
                // Product Information
                //==========================================================
                case "M2.4.1":
                    o = new frmBrands(Dictionary.BrandLevel.MasterBrand);
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                case "M2.4.2":
                    o = new frmBrands(Dictionary.BrandLevel.SubBrand);
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                case "M2.4.3":
                    o = new frmProductTypes();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                case "M2.4.4":
                    o = new frmProducts();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                case "M2.4.5":
                    o = new frmProductHierarchy();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                case "M2.4.6":
                    o = new frmProductPrices();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                //==============================================================
                /*******  Market Group *******/
                //==============================================================
                case "M2.5.1":
                    o = new frmMarketGroups((int)Dictionary.MarketGroupType.Area);
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M2.5.2":
                    o = new frmMarketGroups((int)Dictionary.MarketGroupType.Territory);
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                //==============================================================
                /*******  GeoLocation Group *******/
                //==============================================================
                case "M2.6.1":
                    o = new frmGeoLocations((int)Dictionary.GeoLocationType.District);
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M2.6.2":
                    o = new frmGeoLocations((int)Dictionary.GeoLocationType.Thana);
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;


                //==============================================================
                /*******  Warehouse *******/
                //==============================================================

                case "M2.7.1":
                    o = new frmWarehouseParents();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M2.7.2":
                    o = new frmWarehouses();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                //==============================================================
                /*******  Bank and Brances *******/
                //==============================================================

                case "M2.11.1":
                    o = new frmBanks();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M2.11.2":
                    o = new frmBankBranches();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                //==========================================================
                //Account M3.1
                //==========================================================

                case "M3.1":
                    o = new frmCustomerCreditLimits();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M3.2":
                    o = new frmCustomerCreditCollection((int)Dictionary.CustomerTranGroup.Collection);
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M3.3":
                    o = new frmCustomerTransactions();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M3.5":
                    o = new frmCustomerCreditCollection((int)Dictionary.CustomerTranGroup.Adjustment);
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    //o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M3.36.1":
                    o = new frmDutyTrans();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M3.36.2":
                    o = new frmOutletDutyTran();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M3.36.3":
                    o = new frmStockPositionVAT();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    //o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M3.20.1":
                    o = new frmProductMappings();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    //o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M3.20.2":
                    o = new frmCustomerMappings();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    //o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                case "M3.20.3":
                    o = new frmProcessERPInvoice();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    //o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M3.20.4":
                    o = new frmCustomerCreditApprovals();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M3.20.6":
                    o = new frmMapERPWareHouses();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M3.21":
                    o = new frmDCSCheckings();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                case "M3.31":
                    o = new frmSpecialDiscountLimits();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                

                case "M3.20.5":
                    o = new frmBankInterests();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M3.22":
                    o = new frmCustomerBulkTran();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    //o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M3.24":
                    o = new frmTPVATProducts();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M3.25":
                    o = new frmBankGuarantys();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M3.26":
                    o = new frmOutletExpensesDetail();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;


                case "M3.16":
                    o = new frmVATNoReset();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    //o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M3.27":
                    o = new frmCustomerBankGuarantees();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M3.28.1":
                    o = new frmEMITenures();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M3.28.2":
                    o = new frmEMIBankMappings();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M3.28.3":
                    o = new frmExtendedEMICharges();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M3.28.4":
                    o = new frmDiscountASGBrandEMIs();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M3.28.5":
                    o = new frmEMIManagements();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M3.29":
                    o = new frmSalesInvoiceDiscountTypes();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M3.30":
                    o = new frmCompanyLoans();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                    
                case "M3.32":
                    o = new frmPettyCashExpenses();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M3.33":
                    o = new frmPettyCashExpenseHeads();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M3.34":
                    o = new frmVeriableExpenseProvision();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M3.35":
                    o = new frmInvoiceWiseClaimSupportExeclUploader();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                //==========================================================
                //Inventory M4
                //==========================================================
                case "M4.2":
                    o = new frmGoodsReceives();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                case "M4.3":
                    o = new frmStockTransfers(1);
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M4.9":
                    o = new frmStockTransfers(2);
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M4.11":
                    o = new frmStockTransfers(3);
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M4.14":
                    o = new frmLiveDemos();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M4.15":
                    o = new frmDeliveryInvoices(1);
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                case "M4.16":
                    o = new frmCurrentStock();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                //==========================================================
                //Customer M2.8  M2.8.4
                //==========================================================

                case "M2.8.1":
                    o = new frmCustomerTypes();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;


                case "M2.8.2":
                    o = new frmCustomers();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M2.8.4":
                    o = new frmCustomerCreditLimits();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M2.8.5":
                    o = new frmCustomerVarifications();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M2.8.6":
                    o = new frmHOCustomerTemps();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;


                case "M2.13.5":
                    o = new frmSuppliers();
                    break;
                //==========================================================
                // Showroom
                //==========================================================
                case "M2.10.1":
                    o = new frmShowrooms();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                case "M2.10.2":
                    o = new frmOutletRents();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                case "M2.10.3":
                    o = new frmOutletSiteInfos();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                //case "M2.10.4":
                //    o = new frmOutletFeasibilitys();
                //    o.MdiParent = this;
                //    o.StartPosition = FormStartPosition.CenterScreen;
                //    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                //    o.Icon = o.MdiParent.Icon;
                //    o.WindowState = FormWindowState.Maximized;
                //    o.Show();
                //    return;
                case "M2.10.5":
                    o = new frmOutletFeasibilityTypes();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                case "M2.10.6":
                    o = new frmOutletInvestments();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                case "M2.10.7":
                    o = new frmOutletMarketInfos();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                case "M2.10.8":
                    o = new frmOutletMarketSizeAssessment();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    //o.WindowState = FormWindowState.Minimized;
                    o.Show();
                    return;

                //==========================================================
                // Supply Chain 11
                //==========================================================
                case "M11.1":
                    o = new frmPurchaseRequisitions();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M11.2":
                    o = new frmCommercialInvoices();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M11.3":
                    o = new frmLeads();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M11.4":
                    o = new frmLeadManagements();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M11.5":
                    o = new frmSCMSalsePlans();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M11.6":
                    o = new frmSCMPurchaseOrders();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M11.7":
                    o = new frmOrderAndLCs();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M11.8":
                    o = new frmSCMLCS();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M11.9":
                    o = new frmShipments();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M11.10":
                    o = new frmSCMShadowPrices();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M11.11":
                    o = new frmBEILProductBOMs();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                case "M11.12":
                    o = new frmUploaderforRMandPipeline();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                //==========================================================
                // Plan Budget Target
                //==========================================================
                case "M12.10":
                    o = new frmPlanBudgetTargets();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M12.11":
                    o = new frmCustomerTargets();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M12.12":
                    o = new frmPlanDealerMAGTargets();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                //case "M12.13":
                //    o = new frmHRPayrollOtherBenefitPaymentTypes();
                //    o.MdiParent = this;
                //    o.MaximizeBox = false;
                //    o.StartPosition = FormStartPosition.CenterScreen;
                //    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                //    o.Icon = o.MdiParent.Icon;
                //    o.WindowState = FormWindowState.Maximized;
                //    o.Show();
                //    return;

                case "M12.14":
                    o = new frmPlanExecutiveActivityTargetExeclUploader();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                //==========================================================
                // Process
                //==========================================================
                case "M13.1":
                    o = new frmSalesDataSync();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Show();
                    return;

                case "M13.6":
                    o = new frmClassBuilder();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Show();
                    return;

                case "M13.8":
                    o = new frmTransferFromCassiopia();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M13.9":
                    o = new frmTransferToCassiopeia();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M13.10":
                    o = new frmTransferIMEI();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                case "M13.11":
                    o = new frmDealerorderMonitoring();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M13.12":
                    o = new frmDataTransfer();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                case "M13.13":
                    o = new frmTDVATProcess();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                //==========================================================
                // Distribution
                //==========================================================
                case "M5.1":
                    o = new frmOrders(1);
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M5.2":
                    o = new frmOrders(2);
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M5.4":
                    o = new frmOrders(3);
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M5.14":
                    o = new frmDeliveryInvoices(1);
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                case "M5.9":
                    o = new frmDeliveryInvoices(2);
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                case "M5.15":
                    o = new frmOrdersFromCustomer();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;


                case "M5.17":
                    //o = new frmShipmentVehicles();
                    o = new frmLogDeliveryShipments();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M5.18":
                    o = new frmShipmentRoutes();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    //o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M5.19":
                    o = new frmShipmentCostParams();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    //o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M5.20":
                    o = new frmDutyVehicles();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M5.21":
                    o = new frmTDDeliveryShipmentsHO();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                case "M5.22":
                    o = new frmAutoIndents();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                //case "M5.23":
                //    o = new frmCACInvoiceWiseCapacitys();
                //    o.MdiParent = this;
                //    o.StartPosition = FormStartPosition.CenterScreen;
                //    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                //    o.Icon = o.MdiParent.Icon;
                //    o.WindowState = FormWindowState.Maximized;
                //    o.Show();
                //    return;

                //==========================================================
                //14. SMS system
                //==========================================================
                case "M14.1":
                    o = new TEL.SMS.UI.Win.frmPersons();
                    break;
                case "M14.2":
                    o = new TEL.SMS.UI.Win.frmSMSGroups();
                    break;
                case "M14.3":
                    o = new TEL.SMS.UI.Win.frmSMSMessageForGroup();
                    break;
                case "M14.4":
                    o = new TEL.SMS.UI.Win.frmSMSMessageForSingle();
                    break;
                case "M14.5":
                    o = new TEL.SMS.UI.Win.frmSMSMessageForMany();
                    break;
                case "M14.6":
                    o = new TEL.SMS.UI.Win.frmSMSMessages();
                    break;
                case "M14.7":
                    o = new TEL.SMS.UI.Win.frmSMSMessagesIn();
                    break;
                case "M14.8":
                    o = new TEL.SMS.UI.Win.frmRptSMSUsage();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                case "M14.9":
                    o = new TEL.SMS.UI.Win.frmRptMarketVisit();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                case "M14.10":
                    o = new TEL.SMS.UI.Win.frmCollectionsThroughSMS();
                    break;
                case "M14.11":
                    o = new TEL.SMS.UI.Win.frmSMSDailySalesCollection();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                case "M14.12":
                    o = new frmSMSIndenting();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Show();
                    return;
                case "M14.15":
                    o = new frmDailySMSGroup();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Show();
                    return;

                case "M14.16":
                    o = new frmSMSSingle();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    //o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Show();
                    return;

                //case "M14.13":
                //    o = new frmSmartSMSMessageForGroup();
                //    o.MdiParent = this;
                //    o.MaximizeBox = false;
                //    o.StartPosition = FormStartPosition.CenterScreen;
                //    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                //    o.Show();
                //    return;
                //case "M14.14":
                //    o = new frmSmartSMSForSingle();
                //    o.MdiParent = this;
                //    o.MaximizeBox = false;
                //    o.StartPosition = FormStartPosition.CenterScreen;
                //    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                //    o.Show();
                //    return;

                //==========================================================
                // Human Resource 16
                //==========================================================
                case "M16.1.1":
                    o = new frmDepartments();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;


                case "M16.1.10":
                    o = new frmHRSections();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M16.1.2":
                    o = new frmDesignations();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M16.1.3":
                    o = new frmJobGrades();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M16.1.4":
                    o = new frmJobLocations();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M16.1.5":
                    o = new frmShifts();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M16.1.6":
                    o = new frmAllowanceDeducts();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                case "M16.1.8":
                    o = new frmAllowanceDeductMappings();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                case "M16.1.9":
                    o = new frmHRLoanTypes();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;


                case "M16.2.1":
                    o = new HR.frmEmployees();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M16.3.1":
                    o = new frmHolidayCalendar();
                    o.MdiParent = this;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M16.3.2":
                    o = new frmEmployeeLeaves();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                case "M16.3.3":
                    o = new frmOutStationDutyList();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                case "M16.3.4":
                    o = new frmAttendDataDownload();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    //o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M16.3.5":
                    o = new frmAttendDatas();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M16.3.6":
                    o = new frmAttendInfos();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M16.3.7":
                    o = new frmAttendReports();
                    o.MdiParent = this;
                    //o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    //o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M16.3.8":
                    o = new frmSettings();
                    o.MdiParent = this;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                
                case "M16.3.9":
                    o = new frmHRAttendInfoView(0);
                    o.MdiParent = this;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                case "M16.3.11":
                    o = new frmAttendDataProcessLog();
                    o.MdiParent = this;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                //case "M16.3.10":
                //    o = new frmAttendReportWFH();
                //    o.MdiParent = this;
                //    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                //    o.Icon = o.MdiParent.Icon;
                //    o.Show();
                //    return;
                

                case "M16.3.12":
                    o = new frmHRAttendInfoView(1);
                    o.MdiParent = this;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;


                case "M16.3.13":
                    o = new frmHRAttendInfoView(2);
                    o.MdiParent = this;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;


                case "M16.4.1":
                    o = new frmAttendReportEmployeeWise();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M16.5.1":
                    o = new frmMedicalClaims();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M16.6":
                    o = new frmMAPProductGroups();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M16.7":
                    o = new frmAnnualLeavePlans();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M16.8":
                    o = new frmOverTimes();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M16.21":
                    o = new frmHROverTimeEmployees();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M16.9.1":
                    o = new frmLoanCalculator();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    //o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M16.9.2":
                    o = new frmLoans();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M16.9.3":
                    o = new frmLoanTypes();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M16.10.1":
                    o = new frmPayrollEmployeeSettings();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M16.10.2":
                    o = new frmPayrolls();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M16.10.3":
                    o = new frmHRPayrollAddDeducts();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M16.10.4":
                    o = new frmBlldistributionsets();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                 case "M16.10.5":
                    o = new frmBllEmployeeDistSets(); 
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;  
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M16.10.6":
                    o = new frmBEILDistributionSets();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M16.10.7":
                    o = new frmBEILEmployeeDistSets();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                //case "M16.11":
                //    o = new frmMobileNumbers();
                //    o.MdiParent = this;
                //    o.StartPosition = FormStartPosition.CenterScreen;
                //    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                //    o.Icon = o.MdiParent.Icon;
                //    o.WindowState = FormWindowState.Maximized;
                //    o.Show();
                //    return;

                case "M16.11.1":
                    o = new frmMobileNumbers();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M16.11.2":
                    o = new frmMobileBillDeductionApprovals();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M16.12":
                    o = new frmHRRelays();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M16.13":
                    o = new frmHRShiftMappings();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M16.14.1":
                    o = new frmHRProductionMachines();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M16.14.2":
                    o = new frmHRProductionMachineMappings();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M16.15.1":
                    o = new frmPositionManagement();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M16.15.2":
                    o = new frmHRPositionRoles();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M16.15.3":
                    o = new frmHRPositionRoleTypes();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M16.17":
                    o = new frmHRAssessments();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                case "M16.18":
                    o = new frmHRPayrollOtherBenefits();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                case "M16.19":
                    o = new frmHRPayrollOtherBenefitPaymentTypes();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show(); 
                    return;
                case "M16.20":  
                    o = new frmHRPayrollOtherBenefitPaymentTypeNames();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M16.22":
                    o = new frmHRUniformDistributions();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                case "M16.23":
                    o = new frmOutletCommissionEmployee();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                //case "M16.16.1":
                //    o = new frmHRCVs();
                //    o.MdiParent = this;
                //    o.StartPosition = FormStartPosition.CenterScreen;
                //    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                //    o.Icon = o.MdiParent.Icon;
                //    o.WindowState = FormWindowState.Maximized;
                //    o.Show();
                //    return;

                //==========================================================
                // 17 Dealer Management System 
                //==========================================================
                case "M17.1":
                    o = new frmDealerOutlets();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M17.2":
                    o = new frmDealerUsers();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M17.3":
                    o = new frmStockAdjustment();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M17.4":
                    o = new frmDealerExeclUploader();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                //=========================================================f=
                //28. Barcode 
                //==========================================================
                //case "M28.1":
                //    o = new frmBarcodeSystem();
                //    o.MdiParent = this;
                //    o.MaximizeBox = false;
                //    o.StartPosition = FormStartPosition.CenterScreen;
                //    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                //    o.WindowState = FormWindowState.Maximized;
                //    o.Icon = o.MdiParent.Icon;
                //    o.Show();
                //    return;
                case "M28.2":
                    o = new frmBarcodeManualy();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                case "M28.3":
                    o = new frmBarcodePrint();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                //==========================================================
                //29. Admin
                //==========================================================
                case "M29.1":
                    o = new frmVehicleUsers();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M29.2":
                    o = new frmVehicles();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M29.3":
                    o = new frmVehicleDrivers();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M29.4":
                    o = new frmFuelTypes();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M29.5":
                    o = new frmExpenseHeads();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                case "M29.6":
                    o = new frmVehicleOperations();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                case "M29.7":
                    o = new frmFixedAssetTypes(false);
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                case "M29.8":
                    o = new frmFixedAssets();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M29.9":
                    o = new frmOfficeItems();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M29.10":
                    o = new frmOfficeItemTrans();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M29.11":
                    o = new frmVehicleOperationsAdmin();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                //==========================================================
                //30. IT Equipment
                //==========================================================
                case "M30.1":
                    o = new frmEmails();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                case "M30.2":
                    o = new frmITRequisitions();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                case "M30.3":
                    o = new frmITEquipmentFeature();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Show();
                    return;
                case "M30.4":
                    o = new frmITEquipmentModels();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                case "M30.5":
                    o = new frmITEquipments();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                case "M30.6":
                    o = new frmITEquipmentHistory();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;

                    o.Show();
                    return;

                case "M30.8.1":
                    o = new frmProjects();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;


                case "M30.8.2":
                    o = new frmProjectDetails();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;


                case "M30.9":
                    o = new frmScheduler();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                //==========================================================
                //DMS
                //==========================================================

                case "M31.1":
                    o = new frmDMSUsers();
                    break;
                case "M31.2":
                    o = new frmStockIn();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                case "M31.3":
                    o = new frmReordering();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M31.17":
                    o = new frmDMSOutlets();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                case "M31.18":
                    o = new frmDMSRoutes();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                case "M31.19":
                    o = new frmTargetIn();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                case "M31.20":
                    o = new frmDMSDSRs();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M31.21":
                    o = new frmSaledateCorrections();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M31.22":
                    o = new frmDMSDSRSalary();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M31.23":
                    o = new frmDMSDSRs();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M31.24":
                    o = new frmDMSDSRRoute();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                case "M31.25":
                    o = new frmSalesIn();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                //case "M31.26":
                //    o = new frmDMSSalaryProcess();
                //    o.MdiParent = this;
                //    o.MaximizeBox = false;
                //    o.StartPosition = FormStartPosition.CenterScreen;
                //    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                //    o.WindowState = FormWindowState.Maximized;
                //    o.Icon = o.MdiParent.Icon;
                //    o.Show();
                //    return;

                //case "M31.27":
                //    o = new frmstrikeRate();
                //    o.MdiParent = this;
                //    o.MaximizeBox = false;
                //    o.StartPosition = FormStartPosition.CenterScreen;
                //    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                //    o.WindowState = FormWindowState.Maximized;
                //    o.Icon = o.MdiParent.Icon;
                //    o.Show();
                //    return;

                //==========================================================
                //EPS
                //==========================================================

                case "M32.1":
                    o = new frmEMICalculation();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M32.2":
                    o = new frmEPSOrders(1);
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M32.3":
                    o = new frmEPSOrders(2);
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M32.4":
                    o = new frmEPSAdjustment(1);
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                case "M32.5":
                    o = new frmEPSCollection(1);
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                case "M32.6":
                    o = new frmEPSAdjustment(2);
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                case "M32.7":
                    o = new frmEPSAdjustment(3);
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                case "M32.8":
                    o = new frmEPSCustomers();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M32.9":
                    o = new frmCompanyWiseReportView();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.MinimizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    //o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                case "M32.10":
                    o = new frmEPSCollection(4);
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                case "M32.11":
                    o = new frmEPSTD();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    //o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                //==========================================================
                //Sales Promotion
                //==========================================================
                case "M26.1":
                    o = new frmConsumerPromotions(1);
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M26.15":
                    o = new frmPromoTPs();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M26.2":
                    o = new frmSalesPromotions(1);
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M26.4":
                    o = new frmSalesPromotions(2);
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M26.5":
                    o = new frmPromotionTypes();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M26.6":
                    o = new frmSalesPromotions(3);
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M26.7":
                    o = new frmBankDiscounts();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M26.8":
                    o = new frmB2BDiscounts();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M26.10":
                    o = new frmConsumerPromotionDiscountContributors();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M26.16":
                    o = new frmMAGBrandWiseDiscounts();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                //case "M26.17":
                //    o = new frmSpecialDiscountApprovals();
                //    o.MdiParent = this;
                //    o.StartPosition = FormStartPosition.CenterScreen;
                //    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                //    o.Icon = o.MdiParent.Icon;
                //    o.WindowState = FormWindowState.Maximized;
                //    o.Show();
                //    return;

                case "M26.18":
                    o = new frmConsumerPromotions(2);
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                case "M26.19":
                    o = new frmSPDiscountScratchCards();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M26.20":
                    o = new frmPromotionCalculator();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                case "M26.21":
                    o = new frmExchangeOffers();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                case "M26.22":
                    o = new frmPromoWarranty();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                case "M26.24":
                    o = new frmPromoTPSecondarys();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                //==========================================================
                //Customer Loyalty
                //==========================================================

                case "M7.5.1":
                    o = new frmCLPEligibilities();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                case "M7.5.2":
                    o = new frmCLPPointList();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;



                //==========================================================
                //Retail
                //==========================================================

                case "M7.1":
                    o = new frmTDOutlets();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M7.6.1":
                    o = new frmStockCasperCassiopeia();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M7.8.1":
                    o = new frmGiftVoucherEntry();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    //o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M7.8.2":
                    o = new frmGiftVoucherTransfer(0);
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    //o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M7.8.3":
                    o = new frmGiftVoucherTransfer(1);
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    //o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M7.11":
                    o = new frmProductPortfolios();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;


                case "M7.12":
                    o = new frmOutletCommissionCalculation();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M7.13":
                    o = new frmOutletDisplayPositions();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M7.16":
                    o = new frmOutletDisplayPositionExeclUploader();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;


                //==========================================================
                //20. Product Price Info
                //==========================================================
                case "M20.16.6":
                    o = new frmProductPriceList();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;



                //==========================================================
                //Customer Service
                //==========================================================

                case "M34.1":
                    o = new frmJobStatus();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                case "M34.2":
                    o = new frmComplains();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                case "M34.3":
                    o = new frmInquirys();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.4":
                    o = new frmReplaces();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                case "M34.5":
                    o = new frmSpareLoans();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.6":
                    o = new frmInvSer();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.7":
                    o = new frmPaidJobForInterServices();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.8":
                    o = new frmTechnicalSupervisors();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.9":
                    o = new frmSMSMessages();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.10":
                    o = new frmVehicleSchedules();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.11":
                    o = new frmISVPartsRequisitions();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                //case "M34.12":
                //    o = new frmCSDCustomerQueries();
                //    o.MdiParent = this;
                //    o.MaximizeBox = false;
                //    o.StartPosition = FormStartPosition.CenterScreen;
                //    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                //    o.WindowState = FormWindowState.Maximized;
                //    o.Icon = o.MdiParent.Icon;
                //    o.Show();
                //    return;

                //case "M7.9.1":
                //    o = new frmECOrders();
                //    o.MdiParent = this;
                //    o.MaximizeBox = false;
                //    o.StartPosition = FormStartPosition.CenterScreen;
                //    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                //    o.WindowState = FormWindowState.Maximized;
                //    o.Icon = o.MdiParent.Icon;
                //    o.Show();
                //    return;

                case "M7.9.1":
                    o = new frmEcommerceOrders();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                case "M7.14":
                    o = new frmECSalesLeads(0);
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                case "M7.9.4":
                    o = new frmECommerceLeadAssigns();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                case "M7.9.5":
                    o = new frmLeadInvoices();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                case "M7.9.6":
                    o = new frmLeadInvoiceChallans();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;


                case "M7.9.7":
                    o = new frmIPDCFilesTrackings();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M7.9.8":
                    o = new frmProductFeatures();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.13.1":
                    o = new frmSPMainCats();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.13.2":
                    o = new frmSPSubCats();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.13.3":
                    o = new frmSpareParts();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.13.4":
                    o = new frmSPLocations();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.13.5":
                    o = new frmWorkshopLocations();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.13.6":
                    o = new frmWorkshops();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.13.7":
                    o = new frmTechnicians();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.13.8":
                    o = new frmPartsSuppliers();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.13.9":
                    o = new frmStores();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.13.10":
                    o = new frmInterServices();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;


                case "M34.13.11":
                    o = new frmParentStores();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.13.12":
                    o = new frmChildStores();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.13.13":
                    o = new frmSPTranTypes();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.13.14":
                    o = new frmCSDProductGroups();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.13.15":
                    o = new frmCSDSMSHelpLines();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.13.16":
                    o = new frmServiceCharges();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.13.17":
                    o = new frmCSDProductTypes();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.13.18":
                    o = new frmProductCheckLists();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.13.19":
                    o = new frmProductFaults();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.13.20":
                    o = new frmCSDTechnicianTransportations();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;


                case "M34.14.1":
                    o = new frmSparePartsReceives();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.14.2":
                    o = new frmPartsIssueToJobs();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.14.3":
                    o = new frmPartsIssueToJob(2);
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    //o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.14.4":
                    o = new frmPartsIssueToJob(3);
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    //o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.14.5":
                    o = new frmSparePartCashSales();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.14.6":
                    o = new frmSparePartsStockAdjustments();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.14.7":
                    o = new frmSparePartStock();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    //o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.14.8":
                    o = new frmSparePartsTransfers();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    //o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.14.9":
                    o = new frmSPStockLedger(1);
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    //o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                case "M34.14.10":
                    o = new frmSPStockLedger(2)
                    {
                        MdiParent = this,
                        MaximizeBox = false,
                        StartPosition = FormStartPosition.CenterScreen,
                        FormBorderStyle = FormBorderStyle.FixedDialog
                    };
                    //o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.27":
                    o = new frmSPStockLedger(3)
                    {
                        MdiParent = this,
                        MaximizeBox = false,
                        StartPosition = FormStartPosition.CenterScreen,
                        FormBorderStyle = FormBorderStyle.FixedDialog
                    };
                    //o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.14.11":
                    o = new frmSPIssuetoInternalPartys((int)Dictionary.SparePartTranStatus.Create);
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.14.12":
                    o = new frmSPIssuetoInternalPartys((int)Dictionary.SparePartTranStatus.Approved);
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.14.13":
                    o = new frmSPReturnToSuplieres();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.14.14":
                    o = new frmCSDMaterialConsumerReportDetail();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    //o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.14.15":
                    o = new FrmSparePartsOrders
                    {
                        MdiParent = this,
                        MaximizeBox = false,
                        StartPosition = FormStartPosition.CenterScreen,
                        FormBorderStyle = FormBorderStyle.FixedDialog,
                        WindowState = FormWindowState.Maximized
                     };

                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                //Reception
                case "M34.17.1":
                    o = new frmJobs();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.17.2":
                    o = new frmProductMovements((int)Dictionary.ProductMovementStatus.Send_to_Workshop);
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.17.3":
                    o = new frmProductMovements((int)Dictionary.ProductMovementStatus.Receive_at_Front);
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.17.4":
                    //o = new frmProductDeliveryToCustomer();
                    o = new frmAssignJobs(4); //4=For Delivery
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.17.6":
                    o = new frmViewPendingBill();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.17.7":
                    //5= For Convert Job
                    o = new frmAssignJobs(5);
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.17.8":
                    o = new frmCSDJobBillSends((int)Dictionary.CSDJobBillStatus.Received);
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.17.9":
                    o = new frmBackupSet();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.17.10":
                    //o = new frmCSDCustomerQueries();
                    o = new frmInvoiceCalls();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.17.11":
                    //o = new frmCSDCustomerQueries();
                    o = new frmAdvancePayments();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                //Call Center
                case "M34.18.1":
                    o = new frmCallCenter();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                //Workshop

                case "M34.19.1":
                    o = new frmProductMovements((int)Dictionary.ProductMovementStatus.Send_to_Front);
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.19.2":
                    o = new frmProductMovements((int)Dictionary.ProductMovementStatus.Receive_at_Workshop);
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.19.3":
                    o = new frmAssignJob(1);//1=Assing Walkin Job
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    //o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.19.4":
                    o = new frmAssignJobs(2);//2=Update Job
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.19.5":
                    o = new frmAssignJob(3);//3=For Reassign Technician
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    //o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.19.6":
                    o = new frmBackupSet();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.19.7":
                    o = new frmTechnicianWiseJobs();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    //o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.19.8":
                    o = new frmCSDJobBillSends((int)Dictionary.CSDJobBillStatus.Send);
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.19.9":
                    o = new frmTechnicianBlocks();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                case "M34.19.10":
                    o = new frmTechnicianWiseFeedBack();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                    
                case "M34.13.100":
                    o = new frmPH();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.13.101":
                    o = new frmCsdServiceCharges();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.13.102":
                    o = new frmExtendedWarrantyItems();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.20":
                    o = new frmCustomerSatisfactions();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.21.5":
                    o = new frmExchangeOfferVenderParnets();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.21.1":
                    o = new frmExchangeOfferVenders();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                case "M34.21.2":
                    o = new frmExchangeOfferVenderDeposits();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                case "M34.21.3":
                    o = new frmExchangeOfferJobs();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                case "M34.21.4":
                    o = new frmExchangeOfferMoneyReceiptTransfers();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                case "M34.22":
                    o = new frmCSDSMSHistory();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                case "M34.23":
                    o = new frmDailySalesCollection();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    //o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.24.1":
                    o = new frmStatusUpdatesForcely(2);
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    //o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.24.2":
                    o = new frmStatusUpdatesForcely(1);
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    //o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M34.25.1":
                    o = new frmTPBills();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                //case "M34.26":
                //    o = new frmCSDJobSummeryDateWiseReport();
                //    o.MdiParent = this;
                //    o.MaximizeBox = false;
                //    o.StartPosition = FormStartPosition.CenterScreen;
                //    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                //    //o.WindowState = FormWindowState.Maximized;
                //    o.Icon = o.MdiParent.Icon;
                //    o.Show();
                //    return;
                //==========================================================
                //Warranty
                //==========================================================

                case "M15.5":
                    o = new frmWarrantyCategoryList();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                case "M15.6":
                    o = new frmWarrantyParameter();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                case "M15.7":
                    o = new frmWarrantyClaimDistributions();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                //==========================================================
                // Replace Claim 
                //==========================================================
                case "M25.3":
                    o = new frmReplacementClaims();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M25.1":
                    o = new frmClaimReceive();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    //o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M25.4":
                    o = new frmReplaceClaimStockTran();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                case "M25.5":
                    o = new frmDeliveryInvoices(3);
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                case "M25.6":
                    o = new frmReplaceDeliveryClaims();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                case "M25.7":
                    o = new frmReplacementMonitoring();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                case "M25.8":
                    o = new frmClaimMonitorings();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                //==========================================================
                // POS
                //==========================================================
                case "M36.1":
                    o = new frmStockRequisitions((int)Dictionary.StockRequisitionUIControl.Stock_Requisition_Create);
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M36.2":
                    o = new frmStockRequisitions((int)Dictionary.StockRequisitionUIControl.Stock_Requisition_Authorization);
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M36.3":
                    o = new frmStockRequisitions((int)Dictionary.StockRequisitionUIControl.ISGM_Authorization_at_HO);
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M36.4":
                    o = new frmStockRequisitions((int)Dictionary.StockRequisitionUIControl.Return_To_HO_Authorization);
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M36.5":
                    o = new frmStockRequisitions((int)Dictionary.StockRequisitionUIControl.Product_Transfer_to_Outlet);
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M36.6":
                    o = new frmStockRequisitions((int)Dictionary.StockRequisitionUIControl.Return_To_HO_Receive);
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M36.7":
                    o = new frmPaymentModes();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M36.8":
                    o = new frmDiscountReasons();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M36.9":
                    o = new frmPrint();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M36.10":
                    o = new frmUnsoldDefectiveProductsHO(2);
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M36.11":
                    o = new frmDCSView();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;


                case "M36.12":
                    o = new frmReverseApprovals();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M36.13":
                    o = new frmCPXMLs();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                case "M36.14":
                    o = new frmDMSSalesOrders((int)Dictionary.SalesType.Dealer);
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                case "M36.15":
                    o = new frmDMSSalesOrders((int)Dictionary.SalesType.B2B);
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                //==========================================================
                // BEIL
                //==========================================================
                case "M42.1":
                    o = new frmProductionLots();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                case "M42.2":
                    o = new frmProductionLotDetail();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                case "M42.3":
                    o = new frmProductionLotDeliverys();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                case "M42.4":
                    o = new frmProductComponents();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                //case "M42.7":
                //    o = new frmProductComponentACIndoors();
                //    o.MdiParent = this;
                //    o.MaximizeBox = false;
                //    o.StartPosition = FormStartPosition.CenterScreen;
                //    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                //    o.WindowState = FormWindowState.Maximized;
                //    o.Icon = o.MdiParent.Icon;
                //    o.Show();
                //    return;

                case "M42.7":
                    o = new frmProductComponentUniversals((int)Dictionary.ProductionType.SKD, (int)Dictionary.IsIndoorItem.Yes);
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M42.9":
                    o = new frmProductComponentUniversals((int)Dictionary.ProductionType.CBU, (int)Dictionary.IsIndoorItem.No);
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M42.10":
                    o = new frmProductComponentUniversals((int)Dictionary.ProductionType.SKD, (int)Dictionary.IsIndoorItem.No);
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M42.8":
                    o = new frmSalesOrderFactorys();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M42.5.1":
                    o = new frmBEILGRDs();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M42.5.2":
                    o = new frmBEILMaterialRequisitions();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M42.6.5":
                    o = new frmLCMTargets();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M42.6.1":
                    o = new frmLCMComponents((int)Dictionary.LCMStatus.Stage_1);
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M42.6.2":
                    o = new frmLCMStage2();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    //o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M42.6.3":
                    o = new frmLCMStage3((int)Dictionary.LCMStatus.Stage_3);
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    //o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M42.6.4":
                    o = new frmLCMComponents((int)Dictionary.LCMStatus.Stage_4);
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M42.11.1":
                    o = new frmGoodsReceiveForTools(1);
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M42.11.2":
                    o = new frmGoodsReceiveForTools(2);
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M42.11.3":
                    o = new CJ.Win.BEIL.ToolManagement.frmToolTypes();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M42.11.4":
                    o = new CJ.Win.BEIL.ToolManagement.frmTools();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M42.11.5":
                    o = new CJ.Win.BEIL.ToolManagement.frmToolStockLedger();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    //o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                //==========================================================
                // CAC
                //==========================================================
                case "M44.1.1":
                    o = new frmCACProducts(1);///CAC Product Entry
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                case "M44.1.2":
                    o = new frmCACProducts(2);///CAC Product Price Entry
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                case "M44.1.3":
                    o = new frmCACQuotations();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                case "M44.3.1":
                    o = new frmCACProjects();
                    o.MdiParent = this;
                    //o.MaximizeBox = false;
                    o.WindowState = FormWindowState.Maximized;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                case "M44.3.2":
                    o = new frmCACProjectTasks();
                    o.MdiParent = this;
                    //o.MaximizeBox = false;
                    o.WindowState = FormWindowState.Maximized;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;
                case "M44.2.1":
                    o = new frmCACProducStockTrans((int)Dictionary.TransectionSide.CREDIT);///CAC GOODS_RECEIVE
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                case "M44.2.2":
                    o = new frmCACProducStockTrans((int)Dictionary.TransectionSide.DEBIT);///CAC Product Price Entry
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M44.2.3":
                    o = new frmCACStockLedgerReport(1);
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M44.2.4":
                    o = new frmCACStockLedgerReport(2);
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M44.4":
                    o = new frmECSalesLeads(1);///HVAC Lead
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;
                case "M44.5":
                    o = new frmCACSMSSales();
                    o.MdiParent = this;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.WindowState = FormWindowState.Maximized;
                    o.Show();
                    return;

                case "M8.12":
                    o = new frmCACInvoiceWiseCapacitys();
                    o.MdiParent = this;
                    //o.MaximizeBox = false;
                    o.WindowState = FormWindowState.Maximized;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                //==========================================================
                // CRM
                //==========================================================
                case "M45.1":
                    o = new frmPotentialCustomerFollowups();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;



                //==========================================================
                // Desktop Report
                //==========================================================
                case "M20.13.2":
                    o = new CJ.Win.Inventory.frmStockLedger();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    //o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                case "M20.13.19":
                    o = new CJ.Win.Inventory.frmWarehouseCurrentStock();
                    o.MdiParent = this;
                    o.MaximizeBox = false;
                    o.StartPosition = FormStartPosition.CenterScreen;
                    o.FormBorderStyle = FormBorderStyle.FixedDialog;
                    //o.WindowState = FormWindowState.Maximized;
                    o.Icon = o.MdiParent.Icon;
                    o.Show();
                    return;

                default:
                    MessageBox.Show("This service is not available in Desktop Application.\nPlease login Web Application and try to find out.", "Service Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }

            if (o != null)
            {
                o.MdiParent = this;
                o.Icon = o.MdiParent.Icon;
                o.WindowState = FormWindowState.Maximized;
                o.Show();
            }
        }
        private void CloseAllWindow()
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tvwMainMenu_DoubleClick(object sender, EventArgs e)
        {
            if (tvwMainMenu.SelectedNode == null)
                return;
            if (tvwMainMenu.SelectedNode.Nodes.Count == 0)
            {
                ShowUI((string)tvwMainMenu.SelectedNode.Tag);
            }
        }

        private void tvwMainMenu_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                if (tvwMainMenu.SelectedNode == null)
                    return;

                if (tvwMainMenu.SelectedNode.Nodes.Count == 0)
                {
                    ShowUI((string)tvwMainMenu.SelectedNode.Tag);
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout oForm = new frmAbout();
            oForm.Show();
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void indexToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
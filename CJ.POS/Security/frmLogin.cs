/// <summary>
/// Compamy: Transcom Electronics Limited
/// Author: Shyam Sundar Biswas
/// Date: March 21, 2011
/// Time : 10:00 PM
/// Description: User Login form.
/// Modify Person And Date:
/// </summary>


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.POS.TELWEBSERVER;
using CJ.Class;
using CJ.Class.Library;

namespace CJ.POS.Security
{
    public partial class frmLogin : Form
    {
        DSUser oDSUser;
        public bool _bflag = false;
        
        CJ.Class.Library.TELReg oReg;
        CJ.Class.User oUser;

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                oReg = new CJ.Class.Library.TELReg("Software\\Transcom Electronics Limited\\" + Application.ProductName, "LoginID");
                this.txtUsername.Text = oReg.KeyValue;
                this.txtPassword.Focus();
            }
            catch
            {
                this.txtUsername.Focus();
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if ((txtUsername.Text.Trim().Length == 0) || (txtPassword.Text.Trim().Length == 0))
            {
                MessageBox.Show("User information incomplete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
                LoginForLocal(txtUsername.Text, txtPassword.Text);
                //LoginForServer(txtUsername.Text, txtPassword.Text);
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void LoginForServer(string sUsername, string sPassword)
        {
            oDSUser = new DSUser();
            Service oSerivce;
            oSerivce = new Service();

            DSUser.UserRow oUserRow = oDSUser.User.NewUserRow();

            oUserRow.UserName = txtUsername.Text;
            oUserRow.Password = txtPassword.Text.Trim();

            oDSUser.User.AddUserRow(oUserRow);
            oDSUser.AcceptChanges();

            try
            {
                oDSUser = oSerivce.PosAuthenticate(oDSUser);
            }
            catch
            {
                MessageBox.Show("Please Cheak Internet Cannection", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            
            int IsPass = int.Parse(oDSUser.User[0].IsTrue.ToString());

            if (IsPass==1)
            {
                this.DialogResult = DialogResult.OK;
                oReg.KeyValue = oUserRow.UserName;              

                CJ.Class.Utility.UserId = int.Parse(oDSUser.User[0].UserID.ToString());
                CJ.Class.Utility.Username = oDSUser.User[0].UserName.ToString();
                CJ.Class.Utility.EmployeeID = int.Parse(oDSUser.User[0].EmployeeID.ToString());
                          
                try
                {
                    oReg.DeleteSetting();
                }
                catch (Exception ex)
                {                  
                    oReg.SaveSetting();
                }
                this.Close();
            }
            else
            {               
                MessageBox.Show("Your UserName or Password incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void LoginForLocal(string sUsername, string sPassword)
        {
            oUser = new CJ.Class.User();

            CJ.Class.DBController.Instance.OpenNewConnection();

            if (oUser.authenticatePOS(sUsername) != false)
            {
                CJ.Class.PDSAHash mph = new CJ.Class.PDSAHash(CJ.Class.PDSAHash.PDSAHashType.MD5);

                string sHashValue = mph.CreateHash(sPassword, oUser.Salt);
                if (oUser.UserPassword.CompareTo(sHashValue) != 0)
                {              
                    MessageBox.Show("Your Password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    int Desc;
                    if (Utility.InternetGetConnectedState(out Desc, 0))
                    {
                        try
                        {
                            Service oSerivce = new Service();
                            CJ.Class.Utility.ServerDatetime = oSerivce.GetServerDatetime();
                        }
                        catch
                        {
                            MessageBox.Show("Unable to read Server Date Time", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please Check Internet Connection", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    this.DialogResult = DialogResult.OK;
                    oReg.KeyValue = oUser.Username;
                    if (oUser.EmployeeCode != "")
                    {
                        CJ.Class.Utility.EmployeeDetail = oUser.EmployeeName + " [" + oUser.EmployeeCode + "]";
                    }
                    else
                    {
                        CJ.Class.Utility.EmployeeDetail = oUser.UserFullName;
                    }


                    CJ.Class.POS.SystemInfo oInfo = new CJ.Class.POS.SystemInfo();
                    oInfo.Refresh();

                    CJ.Class.Utility.WarehouseID = oInfo.WarehouseID;
                    CJ.Class.Utility.WarehouseName = oInfo.WarehouseName;
                    CJ.Class.Utility.WarehouseAddress = oInfo.WarehouseAddress;
                    CJ.Class.Utility.SystemDate = oInfo.OperationDate;
                    CJ.Class.Utility.UserId = oUser.UserId;
                    CJ.Class.Utility.EmployeeID = oUser.EmployeeID;
                    CJ.Class.Utility.Username = oUser.Username;
                    CJ.Class.Utility.UserFullname = oUser.UserFullName;
                    CJ.Class.Utility.Password = sPassword;
                    CJ.Class.Utility.IsThermalPrintEnable = oInfo.IsThermalPrintEnable;


                    try
                    {
                        Service oSerivces = new Service();
                        CJ.Class.Utility.IsCheckServerDateTime = oSerivces.GetIsCheckServerDateTime(oInfo.WarehouseID);
                    }
                    catch
                    {
                        CJ.Class.Utility.IsCheckServerDateTime = (int)Dictionary.YesOrNoStatus.YES;
                    }

                    _bflag = true;
                    try
                    {
                        oReg.DeleteSetting();
                    }
                    catch (Exception ex)
                    {                  
                        oReg.SaveSetting();
                    }
                    this.Close();
                }
            }
            else
            {             
                MessageBox.Show("Your UserName is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
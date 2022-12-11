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




namespace CJ.POS.RT.Security
{
    public partial class frmLogin : Form
    {
        public bool _bflag = false;
        
        CJ.Class.Library.TELReg oReg;
        CJ.Class.User oUser;
        CJ.Class.POS.SystemInfo oSystemInfo = new Class.POS.SystemInfo();

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
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
        }
        public void LoginForLocal(string sUsername, string sPassword)
        {
            oUser = new CJ.Class.User();

            CJ.Class.DBController.Instance.OpenNewConnection();

            if (oUser.authenticatePOSRT(sUsername) != false)
            {
                CJ.Class.PDSAHash mph = new CJ.Class.PDSAHash(CJ.Class.PDSAHash.PDSAHashType.MD5);

                string sHashValue = mph.CreateHash(sPassword, oUser.Salt);
                if (oUser.UserPassword.CompareTo(sHashValue) != 0)
                {
                    MessageBox.Show("User Name or Password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (!oSystemInfo.CheckEligibilityforPOSOperation(sUsername))
                {
                    MessageBox.Show("You are not authorized to operate the CJ.POS", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    this.DialogResult = DialogResult.OK;
                    


                    oReg.KeyValue = oUser.Username;
                    CJ.Class.Utility.UserId = oUser.UserId;
                    CJ.Class.Utility.EmployeeID = oUser.EmployeeID;
                    CJ.Class.Utility.Username = oUser.Username;
                    CJ.Class.Utility.UserFullname = oUser.UserFullName;
                    CJ.Class.Utility.Password = sPassword;
                    if (oUser.EmployeeCode != "")
                    {
                        CJ.Class.Utility.EmployeeDetail = oUser.EmployeeName + " [" + oUser.EmployeeCode + "]";
                    }
                    else
                    {
                        CJ.Class.Utility.EmployeeDetail = oUser.UserFullName;
                    }
                    oSystemInfo = new CJ.Class.POS.SystemInfo();
                    oSystemInfo.RefreshPOSRT();

                    CJ.Class.Utility.ShowroomCode = oSystemInfo.ShowroomCode;
                    CJ.Class.Utility.CustomerCode = oSystemInfo.CustomerCode;
                    CJ.Class.Utility.CustomerName = oSystemInfo.CustomerName;
                    CJ.Class.Utility.WarehouseID = oSystemInfo.WarehouseID;
                    CJ.Class.Utility.CustomerTypeID = oSystemInfo.CustTypeID;
                    CJ.Class.Utility.Shortcode = oSystemInfo.Shortcode;
                    CJ.Class.Utility.WarehouseCode = oSystemInfo.WarehouseCode;
                    CJ.Class.Utility.WarehouseName = oSystemInfo.WarehouseName;
                    CJ.Class.Utility.WarehouseAddress = oSystemInfo.WarehouseAddress;
                    CJ.Class.Utility.CustomerID = oSystemInfo.CustomerID;
                    CJ.Class.Utility.ChannelID = oSystemInfo.ChannelID;
                    CJ.Class.Utility.WarehousePhoneNo = oSystemInfo.WarehousePhoneNo;
                    CJ.Class.Utility.WarehouseCellNo = oSystemInfo.WarehouseCellNo;
                    CJ.Class.Utility.WarehouseEmail = oSystemInfo.WarehouseEmail;
                    CJ.Class.Utility.HCMobileNo = oSystemInfo.HCMobileNo;
                    CJ.Class.Utility.HCPhoneNo = oSystemInfo.HCPhoneNo;
                    CJ.Class.Utility.HCEmail = oSystemInfo.HCEmail;
                    CJ.Class.Utility.CentralRegisteredPersonAddress = oSystemInfo.CentralRegisteredPersonAddress;
                    CJ.Class.Utility.VATRegistrationNo = oSystemInfo.VATRegistrationNo;
                    CJ.Class.Utility.LocationID = oSystemInfo.LocationID;


                    _bflag = true;
                    try
                    {
                        oReg.DeleteSetting();
                    }
                    catch (Exception ex)
                    {
                        oReg.SaveSetting();
                    }
                    this.Hide();
                    frmMain oForm = new frmMain();
                    oForm.ShowDialog();
                }
            }
            else
            {             
                MessageBox.Show("User Name or Password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
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
using CJ.Class;
using CJ.Class.Library;
using System.Configuration;

namespace CJ.Win.Security
{
    public partial class frmLogIn : Form
    {
        public User oUser;   
        TELReg oReg;        

        public frmLogIn()
        {
            InitializeComponent();
        }
        private void frmLogIn_Load(object sender, EventArgs e)
        {
            try
            {
                oReg = new TELReg("Software\\Transcom Electronics Limited\\" + Application.ProductName, "LoginID");
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
            Login(txtUsername.Text,txtPassword.Text);
        }       

        private void btnCancle_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
        public void Login(string sUsername,string sPassword)
        {
            oUser= new User();
           
            DBController.Instance.OpenNewConnection();

            if (oUser.authenticate(sUsername) != false)
            {          
               PDSAHash mph = new PDSAHash(PDSAHash.PDSAHashType.MD5);
                  
                string sHashValue = mph.CreateHash(sPassword, oUser.Salt);
                if (oUser.UserPassword.CompareTo(sHashValue) != 0)
                {
                    AppLogger.LogWarning("Unsuccessfull Login User name");
                    MessageBox.Show("Your Password is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Users _oUsers = new Users();
                    Utility.UserPermission = _oUsers.UserPermission(oUser.UserId);

                    this.DialogResult = DialogResult.OK;
                    oReg.KeyValue = oUser.Username;
                    Utility.UserId = oUser.UserId;
                    Utility.EmployeeID = oUser.EmployeeID;
                    Utility.Username = oUser.Username;
                    Utility.UserFullname = oUser.UserFullName;


                    string[] sConn;
                    string[] sConnDB;
                    string[] sConnSV;
                    string[] sDbUser;
                    string[] sDbPassword;
                    sConn = ConfigurationManager.AppSettings["ConnectionString"].Split(';');
                    sConnDB = sConn[1].Split('=');
                    Utility.Database = sConnDB[1].ToString();
                    sConnSV = sConn[2].Split('=');
                    Utility.Server = sConnSV[1].ToString();
                    sDbUser = sConn[3].Split('=');
                    Utility.DBUser = sDbUser[1].ToString();
                    sDbPassword = sConn[4].Split('=');
                    Utility.DBPassword = sDbPassword[1].ToString();
                    Utility.DBConnectionString = "Database=" + Utility.Database + ";Server=" + Utility.Server + ";User=" + Utility.DBUser + ";Password=" + Utility.DBPassword + "";


                    AppLogger.LogInfo("Success fully Login User name =" + oUser.Username);
                    try
                    {
                        oReg.DeleteSetting();
                    }
                    catch (Exception ex) 
                    {
                        AppLogger.LogError("Can find the previous LogInID", ex);
                        oReg.SaveSetting();
                    }
                    this.Close();
                }                
            }
            else
            {
                AppLogger.LogWarning("Unsuccessfull Login User name");
                MessageBox.Show("Your UserName is incorrect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
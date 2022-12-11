// <summary>
// Compamy: Transcom Electronics Limited
// Author: Arifur Rahman Khan
// Date: May 25, 2011
// Time : 2:00 PM
// Description: Control for the search of Product
// Modify Person And Date:
// </summary>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using System.Data.OleDb;
//using TEL.BE ;
//using TEL.BO;

namespace CJ.Win
{
    /// <summary>
    /// Public Class For Employee Control
    /// </summary>
    public partial class ctlEmployee : System.Windows.Forms.UserControl
    {
        private Employee _oEmployee;
        /// <summary>
        /// Public Class Change Selection
        /// </summary>
        public event System.EventHandler ChangeSelection;
        /// <summary>
        /// Public Class Change Focus
        /// </summary>
        public event KeyPressEventHandler ChangeFocus;
        
        
        /// <summary>
        /// Initialize Component(Constructor)
        /// </summary>
        public ctlEmployee()
        {
            InitializeComponent();
        }
        /// <summary>
        /// this property is use for the Selected Employee
        /// </summary>
        public Employee SelectedEmployee
        {
            get
            {
                //if (_oEmployee == null)
                //{
                //    _oEmployee = new Employee();
                //}
                return _oEmployee;
            }
        }
      
        private void ctlEmployee_Resize(object sender, EventArgs e)
        {
            if (this.Width <= 180)
            {
                this.Left = this.Left;
                this.Width = 180;
            }

            txtCode.Width = 100;
            txtCode.Height = 25;
            txtCode.Top = 0;
            txtCode.Left = 0;

            btnPicker.Top = 0;
            btnPicker.Left = txtCode.Width + 2;
            
            if (this.Height <= 25)
            {
                this.Height = 25;
                txtDescription.Top = 0;
                txtDescription.Left = txtCode.Width + btnPicker.Width + 4;
                txtDescription.Width = this.Width - btnPicker.Width - txtCode.Width - 10;
            }
            else if (this.Height >25)
            {
                this.Height = 50;
                txtDescription.Top = 25;
                txtDescription.Left = 0;                
                txtDescription.Width = this.Width;                
            }

        }

        private void btnPicker_Click(object sender, EventArgs e)
        {
            DBController.Instance.OpenNewConnection();
            _oEmployee = new Employee();
            frmEmployees frmEmployees = new frmEmployees();
            frmEmployees.ShowDialog(_oEmployee);
            if (_oEmployee.EmployeeCode!= null)
            {
                txtCode.Text = _oEmployee.EmployeeCode.ToString();
            }
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            _oEmployee = new Employee();

            txtCode.ForeColor = System.Drawing.Color.Red;
            txtDescription.Text = "";

            if (txtCode.Text.Length >= 4 && txtCode.Text.Length <= 25)
            {
                Company com = new Company();
                if (Utility.CompanyInfo == "BLL")
                {
                    RefreshforBLLTAB_ByCode(Convert.ToInt32(txtCode.Text));
                }

                else
                {

                    _oEmployee.EmployeeCode = txtCode.Text;
                    DBController.Instance.OpenNewConnection();
                    _oEmployee.RefreshByCode();



                    if (_oEmployee.EmployeeName == null)
                    {
                        _oEmployee = null;
                        AppLogger.LogFatal("There is no data in the Employee.");
                        return;
                    }
                    else
                    {
                        txtDescription.Text = _oEmployee.EmployeeName.ToString();
                        txtCode.SelectionStart = 0;
                        txtCode.SelectionLength = txtCode.Text.Length;
                        txtCode.ForeColor = System.Drawing.Color.Empty;
                    }
                    //DBController.Instance.CloseConnection();

                }
            }
            if (ChangeSelection != null)
                ChangeSelection(this, e);             
        }


        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {            
            if (ChangeFocus != null)
            {
                ChangeFocus(sender, e);
            }
        }

        public void RefreshforBLLTAB_ByCode(int code)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            int nCount = 0;
            try
            {
                cmd.CommandText = @"Select Code as EmployeeCode, Name
                From(
                Select CustomerCode as Code, CustomerName As Name from v_CustomerDetails
                 union all
                Select DSRCode as Code, DSRname as Name from t_DMSDSRDetails
                union all
                Select CONVERT(varchar, EmployeeCode) as Code, EmployeeName as Name
                from[LINKSERVERTEL].telsysdb.dbo.t_employee
                where CompanyID = 82943  and DepartmentID in (82973, 82969, 82980, 82984, 82992, 83044, 83045)
                ) as Final where  Code =?";
                cmd.Parameters.AddWithValue("Code", code);
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
               
                    txtDescription.Text = (string)reader["Name"];
                    nCount++;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
    }
}

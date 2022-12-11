// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Dec 05, 2012
// Time : 06:23 PM
// Description: Control for the search of EPS Customer
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
using CJ.Win.Control;


namespace CJ.Win
{
    /// <summary>
    /// Public Class For Job Control
    /// </summary>
    public partial class ctlEPSCustomer : System.Windows.Forms.UserControl
    {
        private EPSCustomer _oEPSCustomer;
        
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
        public ctlEPSCustomer()
        {
            InitializeComponent();
        }
        /// <summary>
        /// this property is use for the Selected Job
        /// </summary>
        public EPSCustomer SelectedEPSCustomer
        {
            get
            {
                //if (_oEmployee == null)
                //{
                //    _oEmployee = new Employee();
                //}
                return _oEPSCustomer;
            }
        }

        private void ctlEPSCustomer_Resize(object sender, EventArgs e)
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
            else if (this.Height > 25)
            {
                this.Height = 50;
                txtDescription.Top = 25;
                txtDescription.Left = 0;
                txtDescription.Width = this.Width;
            }

        }

        private void btnPicker_Click(object sender, EventArgs e)
        {

            _oEPSCustomer = new EPSCustomer();

            frmEPSCustomerSearch frmEPSCustomerSearch = new frmEPSCustomerSearch();
            frmEPSCustomerSearch.ShowDialog(_oEPSCustomer);

            if (_oEPSCustomer.EPSCustomerCode != null)
            {
                txtCode.Text = _oEPSCustomer.EPSCustomerCode;
            }
        }
        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            _oEPSCustomer = new EPSCustomer();

            txtCode.ForeColor = System.Drawing.Color.Red;
            txtDescription.Text = "";

            if (txtCode.Text.Length >= 1 && txtCode.Text.Length <= 25)
            {
                _oEPSCustomer.EPSCustomerCode = txtCode.Text;
                _oEPSCustomer.RefreshByEPSCustomerCode();

                if (_oEPSCustomer.EmployeeName == null)
                {
                    _oEPSCustomer = null;
                    AppLogger.LogFatal("There is no data.");
                    return;
                }
                else
                {
                    txtDescription.Text = _oEPSCustomer.EmployeeName.ToString();
                    txtCode.SelectionStart = 0;
                    txtCode.SelectionLength = txtCode.Text.Length;
                    txtCode.ForeColor = System.Drawing.Color.Empty;
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
    }
}




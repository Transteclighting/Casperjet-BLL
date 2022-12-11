using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.Control
{
    public partial class ctlCustomer : System.Windows.Forms.UserControl
    {
        private Customer _oCustomer;
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
        /// 
        public ctlCustomer()
        {
            InitializeComponent();
        }

        public Customer SelectedCustomer
        {
            get
            {
                //if (_oEmployee == null)
                //{
                //    _oEmployee = new Employee();
                //}
                return _oCustomer;
            }
        }

        private void btnPicker_Click(object sender, EventArgs e)
        {
            _oCustomer = new Customer();
            frmCustomerSearch oObj = new frmCustomerSearch("-1");
            oObj.ShowDialog(_oCustomer);
            if (_oCustomer.CustomerCode != null)
            {
                if (_oCustomer.IsActive == (int)Dictionary.IsActive.Active)
                {
                    txtCode.Text = _oCustomer.CustomerCode.ToString();
                }
                else
                {
                    MessageBox.Show("Please select active customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCode.Text = "";
                    txtCode.Focus();
                    return;
                }
            }
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            _oCustomer = new Customer();

            txtCode.ForeColor = System.Drawing.Color.Red;
            txtDescription.Text = "";

            if (txtCode.Text.Length >= 1 && txtCode.Text.Length <= 25)
            {
                _oCustomer.CustomerCode = txtCode.Text;
                _oCustomer.RefreshByCode();

                if (_oCustomer.CustomerName == null)
                {
                    _oCustomer = null;
                    AppLogger.LogFatal("There is no data in the Employee.");
                    return;
                }
                else if (_oCustomer.IsActive == (int)Dictionary.IsActive.InActive)
                {
                    MessageBox.Show("Please select active customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCode.Text = "";
                    txtCode.Focus();
                    return;
                }
                else
                {
                    txtDescription.Text = _oCustomer.CustomerName.ToString();
                    txtCode.SelectionStart = 0;
                    txtCode.SelectionLength = txtCode.Text.Length;
                    txtCode.ForeColor = System.Drawing.Color.Empty;
                }
            }
            if (ChangeSelection != null)
                ChangeSelection(this, e);  
        }  

        private void ctlCustomer_Resize(object sender, EventArgs e)
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

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ChangeFocus != null)
            {
                ChangeFocus(sender, e);
            }
        }
    }
}

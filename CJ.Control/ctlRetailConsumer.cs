using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using CJ.Class.POS;
using CJ.Class;

namespace CJ.Control
{
    public partial class ctlRetailConsumer : UserControl
    {
        private RetailConsumer oRetailConsumer;
        /// <summary>
        /// Public Class Change Selection
        /// </summary>
        public event System.EventHandler ChangeSelection;
        /// <summary>
        /// Public Class Change Focus
        /// </summary>
        public event KeyPressEventHandler ChangeFocus;


        public ctlRetailConsumer()
        {
            InitializeComponent();
        }

        public RetailConsumer SelectedCustomer
        {
            get
            {
                //if (_oEmployee == null)
                //{
                //    _oEmployee = new Employee();
                //}
                return oRetailConsumer;
            }
        }
        private void btnPicker_Click(object sender, EventArgs e)
        {
            oRetailConsumer = new  RetailConsumer();
            frmReatilConsumerSearch oObj = new frmReatilConsumerSearch(-1, (int)Dictionary.Terminal.Branch_Office, -1);
            oObj.ShowDialog(oRetailConsumer);
            if (oRetailConsumer.ConsumerCode != null)
            {
                txtCode.Text = oRetailConsumer.ConsumerCode.ToString();
            }
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            oRetailConsumer = new  RetailConsumer();

            txtCode.ForeColor = System.Drawing.Color.Red;
            txtDescription.Text = "";

            if (txtCode.Text.Length >= 1 && txtCode.Text.Length <= 25)
            {
                oRetailConsumer.ConsumerCode = txtCode.Text;
                oRetailConsumer.RefreshByCode();

                if (oRetailConsumer.ConsumerName == null)
                {
                    oRetailConsumer = null;
                    AppLogger.LogFatal("There is no data in the Employee.");
                    return;
                }
                else
                {
                    txtDescription.Text = oRetailConsumer.ConsumerName.ToString();
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

        private void ctlRetailConsumer_Resize(object sender, EventArgs e)
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
    }
}

// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Saidujjaman Sajib
// Date: Jan 17, 2016
// Time : 1:00 PM
// Description: Control for the search of Technician
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
using CJ.Class.CSD;
using CJ.Win.Control;


namespace CJ.Win
{
    /// <summary>
    /// Public Class For Job Control
    /// </summary>
    public partial class ctlCSDTechnician : System.Windows.Forms.UserControl
    {
        //private ReplaceJobFromCassandra _oReplaceJobFromCassandra;
        private CSDTechnician _oCSDTechnician;

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
        public ctlCSDTechnician()
        {
            InitializeComponent();
        }
        /// <summary>
        /// this property is use for the Selected Job
        /// </summary>
        public CSDTechnician SelectedTechnician
        {
            get
            {
                return _oCSDTechnician;
            }
        }

        private void ctlJobAll_Resize(object sender, EventArgs e)
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
            _oCSDTechnician = new CSDTechnician();

            frmCSDTechnician ofrmCSDTechnician = new frmCSDTechnician();
            ofrmCSDTechnician.ShowDialog();
            _oCSDTechnician = ofrmCSDTechnician._oCSDTechnician;

            if (ofrmCSDTechnician._oCSDTechnician != null)
            {
                txtCode.Text = _oCSDTechnician.Code;
            }
        }

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            _oCSDTechnician = new CSDTechnician();

            txtCode.ForeColor = System.Drawing.Color.Red;
            txtDescription.Text = "";

            if (txtCode.Text.Trim().Length >= 1 && txtCode.Text.Trim().Length <= 25)
            {
                _oCSDTechnician.Code = txtCode.Text;
                _oCSDTechnician.GetTechnicianByCode();
                _oCSDTechnician.Code = txtCode.Text;
                if (_oCSDTechnician.Name == null)
                {
                    _oCSDTechnician = null;
                    AppLogger.LogFatal("There is no data.");
                    return;
                }
                else
                {
                    txtDescription.Text = _oCSDTechnician.Name.ToString();
                    //txtAddress.Text = _oReplaceJobFromCassandra.FirstAddress.ToString();
                    //txtContactNo.Text = _oReplaceJobFromCassandra.Mobile.ToString();
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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using CJ.Class;


namespace CJ.Control
{
    public partial class ctlClaims : UserControl
    {
        ReplaceClaim oReplaceClaim;
        /// <summary>
        /// Public Class Change Selection
        /// </summary>
        public event System.EventHandler ChangeSelection;
        /// <summary>
        /// Public Class Change Focus
        /// </summary>
        public event KeyPressEventHandler ChangeFocus;

        public ctlClaims()
        {
            InitializeComponent();
        }
        public ReplaceClaim SelectedClaim
        {
            get
            {               
                return oReplaceClaim;
            }
        }
        private void btnPicker_Click(object sender, EventArgs e)
        {
            oReplaceClaim = new  ReplaceClaim();
            frmClaims oObj = new frmClaims();
            oObj.ShowDialog(oReplaceClaim);
            if (oObj._oReplaceClaim.ReplaceClaimNo != null)
            {        
                txtCode.Text = oObj._oReplaceClaim.ReplaceClaimNo;
            } 
          
        }

        private void ctlClaims_Resize(object sender, EventArgs e)
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
              
            }
            else if (this.Height > 25)
            {
                this.Height = 50;
              
            }
        }
        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            oReplaceClaim = new ReplaceClaim();

            txtCode.ForeColor = System.Drawing.Color.Red;
            lbText.Text = "";

            if (txtCode.Text.Length >= 1 && txtCode.Text.Length <= 25)
            {
                oReplaceClaim.ReplaceClaimNo = txtCode.Text;
                oReplaceClaim.RefreshByClaimNo();

                if (oReplaceClaim.ReplaceClaimID == 0)
                {
                    oReplaceClaim = null;
                    AppLogger.LogFatal("There is no data in the Employee.");
                    return;
                }
                else
                {
                    lbText.Text = "Found";                
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

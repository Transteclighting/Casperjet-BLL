
// <summary>
// Compamy: Transcom Electronics Limited
// Author: Md. Abdul Hakim
// Date: Mar 28, 2012
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
using CJ.Class.CSD;
using CJ.Win.Control;


namespace CJ.Win
{
    /// <summary>
    /// Public Class For Job Control
    /// </summary>
    public partial class ctlCSDJob : System.Windows.Forms.UserControl
    {
        //private ReplaceJobFromCassandra _oReplaceJobFromCassandra;
        private CSDJob _oCSDJob;

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
        public ctlCSDJob()
        {
            //DBController.Instance.OpenNewConnection();
            InitializeComponent();
        }
        /// <summary>
        /// this property is use for the Selected Job
        /// </summary>
        public CSDJob SelectedJob
        {            
            get
            {
                return _oCSDJob;
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
            _oCSDJob = new CSDJob();
            frmCSDJobSearchNew ofrmCSDJobSearchNew = new frmCSDJobSearchNew();
            ofrmCSDJobSearchNew.ShowDialog();
            _oCSDJob = ofrmCSDJobSearchNew._oCSDJob;

            if (ofrmCSDJobSearchNew._oCSDJob != null)
            {
                txtCode.Text = _oCSDJob.JobNo;
            }

           
        }
        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            DBController.Instance.OpenNewConnection();
            txtCode.ForeColor = System.Drawing.Color.Red;
            txtDescription.Text = "";

            if (txtCode.Text.Length >= 7 && txtCode.Text.Length <= 25)
            {
                _oCSDJob = new CSDJob();
                _oCSDJob.JobNo = txtCode.Text;
                //_oReplaceJobFromCassandra.FirstAddress = txtAddress.Text;
                //_oReplaceJobFromCassandra.Mobile = txtContactNo.Text;
                _oCSDJob.GetJobByJobNo(txtCode.Text);

                if (_oCSDJob.CustomerName == null)
                {
                    _oCSDJob = null;
                    AppLogger.LogFatal("There is no data.");
                    return;
                }
                else
                {            
                    if (_oCSDJob.AccessoryID != 0)
                    {
                        ProductAccessory _oProductAccessory = new ProductAccessory();
                        _oProductAccessory.AccessoriesID = _oCSDJob.AccessoryID;
                        _oProductAccessory.RefreshByID();
                        txtDescription.Text = _oProductAccessory.Name + " [" + _oCSDJob.ProductCode + "-" + _oCSDJob.ProductName + "]";
                    }
                    else
                    {
                        txtDescription.Text = _oCSDJob.ProductCode+"-"+_oCSDJob.ProductName;
                    }


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

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }

    }
}

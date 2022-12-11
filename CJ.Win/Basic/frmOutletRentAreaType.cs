using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CJ.Class.BasicData;
using CJ.Class;

namespace CJ.Win.Basic
{
    public partial class frmOutletRentAreaType : Form
    {
        public bool _Istrue = false;
        OutletRentAreaType _oOutletRentAreaType;
        public frmOutletRentAreaType()
        {
            InitializeComponent();
        }

        private void frmOutletRentAreaType_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool UIValidation()
        {
            #region ValidInput
            if (txtAreaType.Text.Trim() == "")
            {
                MessageBox.Show("Please Enter Area Type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAreaType.Focus();
                return false;
            }
            #endregion

            return true;

        }
        private void Save()
        {
            if (this.Tag == null)
            {
                _oOutletRentAreaType = new OutletRentAreaType();
                _oOutletRentAreaType.AreaType= txtAreaType.Text;
                _oOutletRentAreaType.CreateUser = Utility.UserId;
                _oOutletRentAreaType.CreateDate = DateTime.Now;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    _oOutletRentAreaType.Add();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Add . Area Type : " + txtAreaType.Text, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            //else
            //{
            //    //_oOutletRentAreaType= new OutletRentAreaType();
            //    OutletRentAreaType _oOutletRentAreaType = (OutletRentAreaType)this.Tag;
            //    _oOutletRentAreaType.PaymentTypeName = txtPaymentType.Text;
            //    _oOutletRentAreaType.CreateDate = DateTime.Now;
            //    _oOutletRentAreaType.CreateUserID = Utility.UserId;
            //    _oOutletRentAreaType.PaymentType = (int)Dictionary.HRPayrollOtherBenifitPaymentType.PaymentType;


            //    try
            //    {
            //        DBController.Instance.BeginNewTransaction();
            //        _oOutletRentAreaType.Edit();
            //        DBController.Instance.CommitTransaction();
            //        MessageBox.Show("You Have Successfully Add . Payment Type  : " + txtPaymentType.Text, "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //    }
            //    catch (Exception ex)
            //    {
            //        DBController.Instance.RollbackTransaction();
            //        MessageBox.Show(ex.Message, "Error!!!");
            //    }
            //}

        }
        private void btnSave_Click(object sender, EventArgs e) 
        {
            if (UIValidation())
            {
                Save();
                _Istrue = true;
                this.Close();
            }
        }
    }
}

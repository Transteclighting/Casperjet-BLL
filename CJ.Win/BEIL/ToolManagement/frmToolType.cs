using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.BEIL.ToolManagement
{
    public partial class frmToolType : Form
    {
        ToolType oToolType;
        private ToolType _oToolType;
        string _ncurrentForm;
        public bool _bActionSave = false;
        private string checkDuplicateValue;
        int _nStatus = 0;
        int _ToolTypeID = 0;
        public frmToolType(int nStatus, string currentForm)
        {
            _ncurrentForm = currentForm;
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                Save();

                _bActionSave = true;
                this.Close();
            }
        }

        public void ShowDialog(ToolType oToolType)
        {
            this.Tag = oToolType;
            _ToolTypeID = oToolType.ToolTypeID;
            txtToolType.Text = oToolType.ToolTypeName;

            if (oToolType.IsActive == 0)
            {
                chkIsActive.Checked = false;
            }
            else
            {
                chkIsActive.Checked = true;
            }

            this.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmToolType_Load(object sender, EventArgs e)
        {
            chkIsActive.Checked = true;
        }

        private bool UIValidation()
        {
            if (txtToolType.Text.Trim() == "")
            {
                MessageBox.Show("Please input tool type name", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtToolType.Focus();
                return false;
            }


            ToolType oToolType = new ToolType();
            //oToolType.ToolTypeName = txtToolType.Text.ToString();

            checkDuplicateValue = oToolType.CheckDuplicateData(txtToolType.Text.ToString());

            if (checkDuplicateValue == "Yes" && this.Tag == null)
            {
                MessageBox.Show("Tool Type already exists", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtToolType.Focus();
                return false;
            }


            return true;
        }


        private void Save()
        {
            if (this.Tag == null)
            {

                ToolType oToolType = new ToolType();

                oToolType.ToolTypeName = txtToolType.Text;
                oToolType.CreateDate = DateTime.Now.Date;
                oToolType.CreateUserID = Utility.UserId;
                if (chkIsActive.Checked == true)
                {
                    oToolType.IsActive = 1;
                }
                else
                {
                    oToolType.IsActive = 0;
                }


                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oToolType.Add();

                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Your data has been saved successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
            else
            {
                ToolType oToolType = (ToolType)this.Tag;
                oToolType.ToolTypeID = _ToolTypeID;

                oToolType.UpdateDate = DateTime.Now.Date;
                oToolType.UpdateUserID = Utility.UserId;

                oToolType.ToolTypeName = txtToolType.Text;

                if (chkIsActive.Checked == true)
                {
                    oToolType.IsActive = 1;
                }
                else
                {
                    oToolType.IsActive = 0;
                }
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oToolType.Edit();

                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Your data has been updated successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }



    }
}

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
    public partial class frmTool : Form
    {
        Tool oTool;
        private Tool _oTool;
        private ToolTypes _oToolTypes;
        string _ncurrentForm;
        public bool _bActionSave = false;
        private string checkDuplicateValue;
        int _nStatus = 0;
        int _ToolID = 0;


        public frmTool(int nStatus, string currentForm)
        {
            _ncurrentForm = currentForm;
            InitializeComponent();
        }

        public void ShowDialog(Tool oTool)
        {
            this.Tag = oTool;
            _ToolID = oTool.ToolID;
            txtToolCode.Text = oTool.ToolCode;
            txtToolName.Text = oTool.ToolName;
            LoadCombo();
            cmbToolType.SelectedIndex = _oToolTypes.GetIndex(oTool.ToolTypeID) + 1;

            this.ShowDialog();
        }


        private void LoadCombo()
        {
            _oToolTypes = new ToolTypes();

            DBController.Instance.OpenNewConnection();

            _oToolTypes.GetToolType();
            cmbToolType.Items.Add("-- Select --");
            foreach (ToolType oToolType in _oToolTypes)
            {
                cmbToolType.Items.Add(oToolType.ToolTypeName);
            }
            cmbToolType.SelectedIndex = 0;
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private bool UIValidation()
        {

            if (cmbToolType.SelectedIndex == 0)
            {
                MessageBox.Show("Please select a tool type", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbToolType.Focus();
                return false;
            }


            if (txtToolCode.Text.Trim() == "")
            {
                MessageBox.Show("Please input tool code", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtToolCode.Focus();
                return false;
            }


            if (txtToolCode.Text.Trim() == "")
            {
                MessageBox.Show("Please input tool name", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtToolCode.Focus();
                return false;
            }


            Tool oTool = new Tool();

            checkDuplicateValue = oTool.CheckDuplicateData(txtToolCode.Text.ToString(), txtToolName.Text.ToString());

            if (checkDuplicateValue == "Yes" && this.Tag == null)
            {
                MessageBox.Show("Tool already exists", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtToolCode.Focus();
                return false;
            }

            return true;
        }

        private void Save()
        {
            if (this.Tag == null)
            {

                Tool oTool = new Tool();

                oTool.ToolCode = txtToolCode.Text;
                oTool.ToolName = txtToolName.Text;
                oTool.CreateDate = DateTime.Now.Date;
                oTool.CreateUserID = Utility.UserId;
                oTool.ToolTypeID = _oToolTypes[cmbToolType.SelectedIndex - 1].ToolTypeID;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oTool.Add();

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
                Tool oTool = (Tool)this.Tag;
                oTool.ToolID = _ToolID;

                oTool.UpdateDate = DateTime.Now.Date;
                oTool.UpdateUserID = Utility.UserId;

                oTool.ToolCode = txtToolCode.Text;
                oTool.ToolName = txtToolName.Text;
                oTool.ToolTypeID = _oToolTypes[cmbToolType.SelectedIndex - 1].ToolTypeID;

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oTool.Edit();

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

        private void frmTool_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                LoadCombo();
            }
        }
    }
}

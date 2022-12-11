using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.CSD;

namespace CJ.Win
{
    public partial class frmEditComments : Form
    {
        CSDProductReplaces _oCSDProductReplaces;
        CSDProductReplace _oCSDProductReplace;
        Replace _oReplace;
        int nReplaceID = 0;
        public frmEditComments()
        {
            InitializeComponent();
            LoadCombo();
            ctlProduct1.Visible = false;
            lblProduct.Visible = false;
        }

        public void ShowDialog(Replace oReplace)
        {
            this.Tag = oReplace;
            nReplaceID = 0;
            lblJobID.Text = oReplace.ReplaceJobFromCassandra.JobNo;
            lblJobTitle.Text = oReplace.ReplaceJobFromCassandra.CustomerName;
            nReplaceID = oReplace.ReplaceID;

            this.ShowDialog();
        }
        private void LoadCombo()
        {
            _oCSDProductReplaces = new CSDProductReplaces();
            _oCSDProductReplaces.GetDataForReason((int)Dictionary.ReplaceReasonType.Technical_Supervisor);
            cmbReason.Items.Clear();
            foreach (CSDProductReplace oCSDProductReplace in _oCSDProductReplaces)
            {
                cmbReason.Items.Add(oCSDProductReplace.ReasonName);
            }
            cmbReason.SelectedIndex = 0;

            /******** Load Technical Manager***************/

            _oCSDProductReplaces.GetDataForReason((int)Dictionary.ReplaceReasonType.Technical_Manager);
            cmbTecMgrReason.Items.Clear();
            foreach (CSDProductReplace oCSDProductReplace in _oCSDProductReplaces)
            {
                cmbTecMgrReason.Items.Add(oCSDProductReplace.ReasonName);
            }
            cmbTecMgrReason.Items.Insert(0, "Select");
            cmbTecMgrReason.SelectedIndex = 0;
            
            /******** Load Customer Service Manager***************/
            _oCSDProductReplaces.GetDataForReason((int)Dictionary.ReplaceReasonType.Customer_Service_Manager);
            cmbMgrReason.Items.Clear();
            foreach (CSDProductReplace oCSDProductReplace in _oCSDProductReplaces)
            {
                cmbMgrReason.Items.Add(oCSDProductReplace.ReasonName);
            }
            cmbMgrReason.Items.Insert(0, "Select");
            cmbMgrReason.SelectedIndex = 0;
            

            /******** Load Head Of Service***************/
            _oCSDProductReplaces.GetDataForReason((int)Dictionary.ReplaceReasonType.Head_of_Service);
            cmbHeadReason.Items.Clear();
            foreach (CSDProductReplace oCSDProductReplace in _oCSDProductReplaces)
            {
                cmbHeadReason.Items.Add(oCSDProductReplace.ReasonName);
            }
            cmbHeadReason.Items.Insert(0, "Select");
            cmbHeadReason.SelectedIndex = 0;
            
        }

        private void chkCrossReplacement_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCrossReplacement.Checked == true)
            {
                ctlProduct1.Visible = true;
                lblProduct.Visible = true;
            }
            else
            {
                ctlProduct1.Visible = false;
                lblProduct.Visible = false;
            }
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            _oReplace = new Replace();

            _oReplace.ReplaceID = nReplaceID;

            _oReplace.SupReasonID = Convert.ToInt32(cmbReason.SelectedIndex);
            _oReplace.SupComments= txtComment.Text;
            _oReplace.SupDate = Convert.ToDateTime(dtCommentDate.Text);

            _oReplace.TmReasonID = Convert.ToInt32(cmbTecMgrReason.SelectedIndex);
            _oReplace.TmComments = txtTecMgrComment.Text;
            _oReplace.TmDate = Convert.ToDateTime(dtTecMgrCommentDate.Text);

            _oReplace.CusReasonID = Convert.ToInt32(cmbMgrReason.SelectedIndex);
            _oReplace.CusComments = txtMgrComment.Text;
            _oReplace.CusDate = Convert.ToDateTime(dtMgrCommentDate.Text);

            _oReplace.HsReasonID = Convert.ToInt32(cmbHeadReason.SelectedIndex);
            _oReplace.HsComments = txtHeadComment.Text;
            _oReplace.HsDate = Convert.ToDateTime(dtHeadCommentDate.Text);

            if (ctlProduct1.SelectedSerarchProduct != null)
                _oReplace.IssueProductID = ctlProduct1.SelectedSerarchProduct.ProductID;
            else _oReplace.IssueProductID = 0;

            DBController.Instance.BeginNewTransaction();

            _oCSDProductReplaces = new CSDProductReplaces();
            _oCSDProductReplaces.GetDataForReason((int)Dictionary.ReplaceReasonType.Technical_Supervisor);
            _oReplace.SupReasonID = _oCSDProductReplaces[cmbReason.SelectedIndex].ID;
                                                                   
            _oCSDProductReplaces = new CSDProductReplaces();
            _oCSDProductReplaces.GetDataForReason((int)Dictionary.ReplaceReasonType.Technical_Manager);
            _oReplace.TmReasonID = _oCSDProductReplaces[cmbTecMgrReason.SelectedIndex].ID;

            _oCSDProductReplaces = new CSDProductReplaces();
            _oCSDProductReplaces.GetDataForReason((int)Dictionary.ReplaceReasonType.Customer_Service_Manager);
            _oReplace.CusReasonID = _oCSDProductReplaces[cmbMgrReason.SelectedIndex].ID;

            _oCSDProductReplaces = new CSDProductReplaces();
            _oCSDProductReplaces.GetDataForReason((int)Dictionary.ReplaceReasonType.Head_of_Service);
            _oReplace.HsReasonID = _oCSDProductReplaces[cmbHeadReason.SelectedIndex].ID;

            DBController.Instance.CommitTransaction();
            
            try
            {
                if (cmbTecMgrReason.Text == "Select" || cmbMgrReason.Text == "Select" || cmbHeadReason.Text == "Select")
                {
                    MessageBox.Show("Select atleast one reason from each combo");
                }
                else
                {
                    DBController.Instance.BeginNewTransaction();
                    _oReplace.UpdateComments();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Date Updated Successfully");
                }
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                throw (ex);
                MessageBox.Show(ex + "Unknown Error. Communicate with vendor");
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
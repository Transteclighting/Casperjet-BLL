using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.CSD;
using CJ.Class;
using CJ.Class.Report;
using CJ.Win.Security;
using CJ.Win.Control;

namespace CJ.Win
{
    public partial class frmPaidJobForInterService : Form
    {
        ProductFaultFromCassandras _oProductFaultFromCassandras;
        public PaidJobForInterServiceHistory oPaidJobForInterServiceHistory;


        public frmPaidJobForInterService()
        {
            InitializeComponent();
        }
        private void LoadCombos()
        {
           
            //District
            _oProductFaultFromCassandras = new ProductFaultFromCassandras();

            _oProductFaultFromCassandras.Refresh();
          
            foreach (ProductFaultFromCassandra oProductFaultFromCassandra in _oProductFaultFromCassandras)
            {
                cmbFault.Items.Add(oProductFaultFromCassandra.Description);
            }
            if (_oProductFaultFromCassandras.Count > 0)
                cmbFault.SelectedIndex = _oProductFaultFromCassandras.Count -10;
           
        }

        private void frmPaidJobforInterService_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
                LoadCombos();
        }


        public void ShowDialog(PaidJobForInterService oPaidJobForInterService)
        {
            this.Tag = oPaidJobForInterService;
            LoadCombos();
            txtCustomerName.Text=oPaidJobForInterService.CustomerName;
            txtContactNo.Text = oPaidJobForInterService.ContactNo.ToString();
            txtAddress.Text=oPaidJobForInterService.Address;
            txtLocation.Text = oPaidJobForInterService.Location.ToString();
            ctlProduct1.txtCode.Text = oPaidJobForInterService.Product.ProductCode;
            cmbFault.SelectedIndex = _oProductFaultFromCassandras.GetIndex(oPaidJobForInterService.ProductFaultFromCassandra.DescriptionID);
            dtExprectedDate.Value = Convert.ToDateTime(oPaidJobForInterService.ExpectedServiceDate.ToString());
            ctlChannelCSD1.txtCode.Text = oPaidJobForInterService.ChannelFromCassandra.Code;
            txtRemarks.Text = oPaidJobForInterService.ReceiveRemarks.ToString();
            

            this.ShowDialog();
        }


        private bool validateUIInput()
        {
            #region Input Information Validation


            if (ctlChannelCSD1.SelectedChannelFromCassandra == null || ctlChannelCSD1.txtCode.Text == "")
            {
                MessageBox.Show("Please Select Source", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlChannelCSD1.Focus();
                return false;
            }
            if (ctlProduct1.SelectedSerarchProduct == null || ctlProduct1.txtCode.Text == "")
            {
                MessageBox.Show("Please Select a Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlProduct1.Focus();
                return false;
            }
            if (txtCustomerName.Text == "")
            {
                MessageBox.Show("Please Enter Customer Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerName.Focus();
                return false;
            }
            if (txtContactNo.Text == "")
            {
                MessageBox.Show("Please Enter Contact No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtContactNo.Focus();
                return false;
            }
            if (txtAddress.Text == "")
            {
                MessageBox.Show("Please Enter Customer Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAddress.Focus();
                return false;
            }


            #endregion

            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                this.Close();
            }
        }
        private void Save()
        {
            if (this.Tag == null)
            {
                PaidJobForInterService oPaidJobForInterService = new PaidJobForInterService();
                oPaidJobForInterService.CustomerName = txtCustomerName.Text;
                oPaidJobForInterService.SourceID = ctlChannelCSD1.SelectedChannelFromCassandra.ChannelID;
                oPaidJobForInterService.ProductID = ctlProduct1.SelectedSerarchProduct.ProductID;
                oPaidJobForInterService.ContactNo = txtContactNo.Text;
                oPaidJobForInterService.FaultID = _oProductFaultFromCassandras[cmbFault.SelectedIndex].DescriptionID;
                oPaidJobForInterService.Address = txtAddress.Text;
                oPaidJobForInterService.Location = txtLocation.Text;
                oPaidJobForInterService.ReceiveRemarks = txtRemarks.Text;
                oPaidJobForInterService.ExpectedServiceDate = dtExprectedDate.Value;
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oPaidJobForInterService.Add();
                    {
                        oPaidJobForInterServiceHistory = new PaidJobForInterServiceHistory();
                        
                        oPaidJobForInterServiceHistory.PaidJobID =oPaidJobForInterService.PaidJobID;
                        oPaidJobForInterServiceHistory.Remarks = oPaidJobForInterService.ReceiveRemarks;
                        oPaidJobForInterServiceHistory.Status = (int)Dictionary.ISPaidJobStatus.Receive;
                        oPaidJobForInterServiceHistory.AddPaidJobHistory();
                    }
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Refresh();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                PaidJobForInterService oPaidJobForInterService = (PaidJobForInterService)this.Tag;
                {
                    oPaidJobForInterService.CustomerName = txtCustomerName.Text;
                    oPaidJobForInterService.SourceID = ctlChannelCSD1.SelectedChannelFromCassandra.ChannelID;
                    oPaidJobForInterService.ProductID = ctlProduct1.SelectedSerarchProduct.ProductID;
                    oPaidJobForInterService.ContactNo = txtContactNo.Text;
                    oPaidJobForInterService.FaultID = _oProductFaultFromCassandras[cmbFault.SelectedIndex].DescriptionID;
                    oPaidJobForInterService.Address = txtAddress.Text;
                    oPaidJobForInterService.Location = txtLocation.Text;
                    oPaidJobForInterService.ReceiveRemarks = txtRemarks.Text;
                    oPaidJobForInterService.ExpectedServiceDate = dtExprectedDate.Value;

                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        oPaidJobForInterService.Edit();
                        {
                            oPaidJobForInterServiceHistory = new PaidJobForInterServiceHistory();

                            oPaidJobForInterServiceHistory.PaidJobID = oPaidJobForInterService.PaidJobID;
                            oPaidJobForInterServiceHistory.Remarks = oPaidJobForInterService.ReceiveRemarks;
                            oPaidJobForInterServiceHistory.Status = (int)Dictionary.ISPaidJobStatus.Receive;
                            oPaidJobForInterServiceHistory.UpdateHistoryRemarks();
                        }
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Update Successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //Refresh();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                }

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       

    }
}


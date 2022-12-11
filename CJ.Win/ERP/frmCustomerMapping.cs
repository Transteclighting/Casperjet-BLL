using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Win.Control;
//using CJ.Class.ERP;
using CJ.Class;

namespace CJ.Win
{
    public partial class frmCustomerMapping : Form
    {
        public frmCustomerMapping()
        {
            InitializeComponent();
        }
        public void ShowDialog(CustomerMapping oCustomerMapping)
        {
            this.Tag = oCustomerMapping;
            ctlCustomer1.txtCode.Text = oCustomerMapping.CustomerCode.ToString();
            txtERPCode.Text = oCustomerMapping.CustomerERPCode.ToString();
            this.ShowDialog();
        }
        public void ShowDialogNonMap(CustomerMapping oCustomerMappingNonMap)
        {
            this.Tag = oCustomerMappingNonMap;
            ctlCustomer1.txtCode.Text = oCustomerMappingNonMap.CustomerCode.ToString();
            //txtERPCode.Text = oCustomerMapping.CustomerERPCode.ToString();
            //txtCustomerCategory.Text = oCustomerMapping.CustomerCategory.ToString();
            
            this.MaximizeBox = true;
            this.ShowDialog();
        }
        private bool validateUIInput()
        {
            #region Input Information Validation

            if (ctlCustomer1.SelectedCustomer == null || ctlCustomer1.txtCode.Text=="")
            {
                MessageBox.Show("Please Select a Customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlCustomer1.Focus();
                return false;
            }

            //if (ctlJob1.SelectedReplaceJobFromCassandra == null)
            if (ctlCustomer1.txtDescription.Text == "")
            {
                MessageBox.Show("Please enter a Valid Customer Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlCustomer1.Focus();
                return false;
            }
            if (txtERPCode.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Customer ERP Number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtERPCode.Focus();
                return false;
            }


            #endregion

            return true;
        }
        private void Save()
        {
            if (this.Tag == null)
            {
                CustomerMapping oCustomerMapping = new CustomerMapping();
                oCustomerMapping.CustomerCode = ctlCustomer1.SelectedCustomer.CustomerCode;
                oCustomerMapping.CustomerERPCode = txtERPCode.Text.Trim();
                

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    if (oCustomerMapping.CheckCustomerCode())
                    {
                        if (oCustomerMapping.CheckCustomerERPCode())
                        {
                            oCustomerMapping.Add();
                            DBController.Instance.CommitTransaction();
                            MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            DBController.Instance.CommitTransaction();
                            MessageBox.Show("Duplicate ERP Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else
                    {
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Duplicate Customer Code", "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }


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
               
                if (this.MaximizeBox==false)
                {

                    CustomerMapping oCustomerMapping = (CustomerMapping)this.Tag;

                    {
                        oCustomerMapping.CustomerCode = ctlCustomer1.SelectedCustomer.CustomerCode;
                        oCustomerMapping.CustomerERPCode = txtERPCode.Text.Trim();

                        try
                        {
                            DBController.Instance.BeginNewTransaction();

                            oCustomerMapping.Edit();

                            DBController.Instance.CommitTransaction();
                            MessageBox.Show("Edited Successfully", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //Refresh();
                        }
                        catch (Exception ex)
                        {
                            DBController.Instance.RollbackTransaction();
                            MessageBox.Show(ex.Message, "Error!!!");
                        }

                    }
                }
                else
                {
                    CustomerMapping oCustomerMapping = new CustomerMapping();

                    {
                        oCustomerMapping.CustomerCode = ctlCustomer1.SelectedCustomer.CustomerCode;
                        oCustomerMapping.CustomerERPCode = txtERPCode.Text.Trim();

                        try
                        {
                            DBController.Instance.BeginNewTransaction();
                            if (oCustomerMapping.CheckCustomerCode())
                            {
                                if (oCustomerMapping.CheckCustomerERPCode())
                                {
                                    oCustomerMapping.Add();
                                    DBController.Instance.CommitTransaction();
                                    MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    DBController.Instance.CommitTransaction();
                                    MessageBox.Show("Duplicate ERP Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }

                            }
                            else
                            {
                                DBController.Instance.CommitTransaction();
                                MessageBox.Show("Duplicate Customer Code", "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            }


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
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
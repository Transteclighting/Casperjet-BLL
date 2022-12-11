using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;


namespace CJ.Win.CSD
{
    public partial class frmExchangeOfferVender : Form
    {
        ExchangeOfferVender oExchangeOfferVender;
        int nVenderID = 0;
        string sCode = "";
        ExchangeOfferVenderParents _oExchangeOfferVenderParents;

        public frmExchangeOfferVender()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void ShowDialog(ExchangeOfferVender oExchangeOfferVender)
        {
            DBController.Instance.OpenNewConnection();
            this.Tag = oExchangeOfferVender;
            LoadCombos();
            nVenderID = oExchangeOfferVender.VenderID;
            sCode = oExchangeOfferVender.Code;            
            txtVenderName.Text = oExchangeOfferVender.Name;
            int nParentVenderIndex = 0;
            nParentVenderIndex = _oExchangeOfferVenderParents.GetIndex(oExchangeOfferVender.ParentVenderID);
            cmbParentVender.SelectedIndex = nParentVenderIndex + 1;
            Customer oCustomer = new Customer();
            oCustomer.RefreshByID(oExchangeOfferVender.ParentCustomerID);
            if (oCustomer.CustomerCode != null)
            {
                ctlCustomer.txtCode.Text = oCustomer.CustomerCode;
            }
            else
            {
                ctlCustomer.txtCode.Text = "";
            }
            txtRemarks.Text = oExchangeOfferVender.Remarks;
            if (oExchangeOfferVender.IsActive == (int)Dictionary.YesNAStatus.Yes)
            {
                chkIsActive.Checked = true;
            }
            else
            {
                chkIsActive.Checked = false;
            }
            this.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }
        public void LoadCombos()
        {
            DBController.Instance.OpenNewConnection();
            /************Vender****************/
            _oExchangeOfferVenderParents = new ExchangeOfferVenderParents();
            _oExchangeOfferVenderParents.RefreshforCombo();
            cmbParentVender.Items.Clear();
            cmbParentVender.Items.Add("--Select Vender Name--");
            foreach (ExchangeOfferVenderParent oExchangeOfferVenderParent in _oExchangeOfferVenderParents)
            {
                cmbParentVender.Items.Add('[' + oExchangeOfferVenderParent.ParentVenderCode + ']' + oExchangeOfferVenderParent.ParentVenderName);
            }
            cmbParentVender.SelectedIndex = 0;

        }

        private bool IsValidUI()
        {
            if (txtVenderName.Text == "")
            {
                MessageBox.Show("Please Enter Vender Name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVenderName.Focus();
                return false;
            }
            if (cmbParentVender.SelectedIndex == 0)
            {
                MessageBox.Show("Please Select Perent Vender Name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbParentVender.Focus();
                return false;
            }
            if (ctlCustomer.txtCode.Text.Trim() == "")
            {
                MessageBox.Show("Please Select Perent Customer Name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlCustomer.Focus();
                return false;
            }
            if (ctlCustomer.txtDescription.Text.Trim() == "")
            {
                MessageBox.Show("Please Select Perent Customer Name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlCustomer.Focus();
                return false;
            }
            if (ctlCustomer.SelectedCustomer == null)
            {
                MessageBox.Show("Please Select Perent Customer Name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlCustomer.Focus();
                return false;
            }

            return true;
        }
        private void Save()
        {
            if (IsValidUI())
            {
                if (this.Tag == null)
                {
                    oExchangeOfferVender = new ExchangeOfferVender();
                    oExchangeOfferVender.Name = txtVenderName.Text;
                    oExchangeOfferVender.ParentVenderID = _oExchangeOfferVenderParents[cmbParentVender.SelectedIndex - 1].ParentVenderID;
                    oExchangeOfferVender.ParentCustomerID = ctlCustomer.SelectedCustomer.CustomerID;
                    oExchangeOfferVender.Balance = 0;
                    if (chkIsActive.Checked == true)
                    {
                        oExchangeOfferVender.IsActive = (int)Dictionary.YesNAStatus.Yes;
                    }
                    else
                    {
                        oExchangeOfferVender.IsActive = (int)Dictionary.YesNAStatus.NA;
                    }
                    oExchangeOfferVender.Remarks = txtRemarks.Text;
                    oExchangeOfferVender.CreateUserID = Utility.UserId;
                    oExchangeOfferVender.CreateDate = DateTime.Now.Date;


                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        oExchangeOfferVender.Insert();
                        
                        if (ctlCustomer.SelectedCustomer != null)
                        {
                            Showroom oShowroom = new Showroom();
                            oShowroom.GetShowroomByCustomerID(oExchangeOfferVender.ParentCustomerID);
                            if (ctlCustomer.SelectedCustomer.CustomerID == oShowroom.CustomerID) ;
                            {
                                DataTran oDataTran = new DataTran();
                                oDataTran.TableName = "t_ExchangeOfferVender";
                                oDataTran.DataID = Convert.ToInt32(oExchangeOfferVender.VenderID);
                                oDataTran.WarehouseID = oShowroom.WarehouseID;
                                oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                                oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                                oDataTran.BatchNo = 0;

                                if (oDataTran.CheckData() == false)
                                {
                                    oDataTran.AddForTDPOS();
                                }

                            }

                        }

                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Save Successfully. Vender Code: " + oExchangeOfferVender.Code, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                }


                else
                {
                    oExchangeOfferVender = new ExchangeOfferVender();
                    oExchangeOfferVender.VenderID = nVenderID;
                    oExchangeOfferVender.Name = txtVenderName.Text;
                    oExchangeOfferVender.ParentVenderID = _oExchangeOfferVenderParents[cmbParentVender.SelectedIndex - 1].ParentVenderID;
                    oExchangeOfferVender.ParentCustomerID = ctlCustomer.SelectedCustomer.CustomerID;
                    if (chkIsActive.Checked == true)
                    {
                        oExchangeOfferVender.IsActive = (int)Dictionary.YesNAStatus.Yes;
                    }
                    else
                    {
                        oExchangeOfferVender.IsActive = (int)Dictionary.YesNAStatus.NA;
                    }
                    oExchangeOfferVender.Remarks = txtRemarks.Text;
                    oExchangeOfferVender.UpdateUserID = Utility.UserId;
                    oExchangeOfferVender.UpdateDate = DateTime.Now.Date;

                    try
                    {

                        DBController.Instance.BeginNewTransaction();
                        oExchangeOfferVender.Update();
                        if (ctlCustomer.SelectedCustomer != null)
                        {
                            Showroom oShowroom = new Showroom();
                            oShowroom.GetShowroomByCustomerID(oExchangeOfferVender.ParentCustomerID);
                            if (ctlCustomer.SelectedCustomer.CustomerID == oShowroom.CustomerID) ;
                            {
                                DataTran oDataTran = new DataTran();
                                oDataTran.TableName = "t_ExchangeOfferVender";
                                oDataTran.DataID = Convert.ToInt32(oExchangeOfferVender.VenderID);
                                oDataTran.WarehouseID = oShowroom.WarehouseID;
                                oDataTran.TransferType = (int)Dictionary.DataTransferType.Edit;
                                oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                                oDataTran.BatchNo = 0;

                                if (oDataTran.CheckData() == false)
                                {
                                    oDataTran.AddForTDPOS();
                                }

                            }

                        }
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Save Successfully. Vender Code: " + sCode, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                }
            }
        }

        private void frmExchangeOfferVender_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Add Exchange Offer Child Vender";
                LoadCombos();
            }
            else
            {
                this.Text = "Add Exchange Offer Child Vender";
            }

        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using TEL.SMS.BO;
using TEL.SMS.BO.BE;
using TEL.SMS.BO.DA;
using TEL.SMS.Reports;
using TEL.BO;
using TEL.Common;

namespace TEL.SMS.UI.Win
{
    public partial class frmWarrantyReg : Form
    {
        DSShowroom _oDSShowroom = new DSShowroom();
        string _sXmlPath;
        string sWarrantyRegisterID;
        public frmWarrantyReg()
        {
            InitializeComponent();           
        }

        private void frmWarrantyReg_Load(object sender, EventArgs e)
        {
            //Check whether add new or modify
            if (this.Tag == null)
            {
                this.Text = "Add Warranty";
            }
            else
            {
                this.Text = "Modify Warranty";
            }
            EnableSalesPointControl();
        }

        public void ShowDialog(DSWarrantyRegister oDSWarrantyRegister, string sWarrantyRegID)
        {
            TEL.SMS.BO.DA.DAWarrantyRegister oDAWarrantyRegister = new DAWarrantyRegister();
            oDAWarrantyRegister.GetWarrantyRegister(oDSWarrantyRegister, sWarrantyRegID);

            this.Tag = oDSWarrantyRegister;
            sWarrantyRegisterID = sWarrantyRegID;
            this.txtSerialNo.Text = oDSWarrantyRegister.WarrantyRegister[0].SerialNo;
            this.txtCustomerName.Text = oDSWarrantyRegister.WarrantyRegister[0].CustomerName;
            this.txtCustomerAddress.Text = oDSWarrantyRegister.WarrantyRegister[0].CustomerAddress;
            this.txtTelephoneNo.Text = oDSWarrantyRegister.WarrantyRegister[0].TelephoneNo;
            this.txtMobileNo.Text = oDSWarrantyRegister.WarrantyRegister[0].MobileNo;
            this.txtEmail.Text = oDSWarrantyRegister.WarrantyRegister[0].Email;
            if (oDSWarrantyRegister.WarrantyRegister[0].IsSalesPersonIDNull()==false )   
            //this.txtSalesPersonID.Text = oDSWarrantyRegister.WarrantyRegister[0].SalesPersonID.ToString();     
            this.dtpPurchaseDate.Value = oDSWarrantyRegister.WarrantyRegister[0].PurchaseDate;

            if (oDSWarrantyRegister.WarrantyRegister[0].IsWarrantyCardNoNull() == false)
            this.txtBarcodeCode.Text = oDSWarrantyRegister.WarrantyRegister[0].WarrantyCardNo.ToString();

            this.ctlProductSearch1.txtCode.Text  = oDSWarrantyRegister.WarrantyRegister[0].ProductID.ToString();
            if (oDSWarrantyRegister.WarrantyRegister[0].IsSellerCodeNull())
            {
                rbtOutlet.Checked = true;
                this.txtOutlet.Text = oDSWarrantyRegister.WarrantyRegister[0].SellerName.ToString();
            }
            else
            {
                rbtDealer.Checked = true;
                this.ctlCustomer1.txtCode.Text = oDSWarrantyRegister.WarrantyRegister[0].SellerCode.ToString();
            }
            this.txtBillNo.Text = oDSWarrantyRegister.WarrantyRegister[0].BillNo;
            this.txtRemarks.Text = oDSWarrantyRegister.WarrantyRegister[0].Remarks;
            this.ShowDialog();

        }

        private bool ValidateUI()
        {
            if (txtSerialNo.TextLength <= 0)
            {
                MessageBox.Show("Serial no. must be there in a warranty. Please enter serial no.", "Activate warranty",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                txtSerialNo.Focus();
                return false;
            }
            //if (txtSalesPersonID.TextLength <= 0)
            //{
            //    MessageBox.Show(" Sales Person ID. must be there in a warranty. Please enter serial no.", "Activate warranty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtSerialNo.Focus();
            //    return false;
            //}

            if (txtCustomerName.TextLength <= 0)
            {
                MessageBox.Show("Customer name must be there in a warranty. Please enter customer name.", "Activate warranty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerName.Focus();
                return false;
            }

            if (txtCustomerAddress.TextLength <= 0)
            {
                MessageBox.Show("Customer address must be there in a warranty. Please enter customer address.", "Activate warranty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerAddress.Focus();
                return false;
            }

            if (ctlProductSearch1.SelectedDSProduct.ProductList.Count == 0)
            {
                MessageBox.Show("Product must be there in a warranty. Please select correct product code.", "Activate warranty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlProductSearch1.Focus();
                return false;
            }

            if (ctlCustomer1.SelectedDSCustomer.CustomerList.Count == 0 && rbtDealer.Checked)
            {
                MessageBox.Show("Showroom/Dealer name must be there in a warranty. Please enter Showroom/Dealer name.", "Activate warranty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlCustomer1.Focus();
                return false;
            }

            if (txtOutlet.TextLength <= 0 && rbtOutlet.Checked)
            {
                MessageBox.Show("Outlet name must be there in a warranty. Please enter Outlet name.", "Activate warranty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtOutlet.Focus();
                return false;
            }

            //if (txtBillNo.TextLength <= 0)
            //{
            //    MessageBox.Show("Invoice/Challan no. must be there in a warranty. Please enter Invoice/Challan no.", "Activate warranty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    txtBillNo.Focus();
            //    return false;
            //}
            if (txtBarcodeCode.TextLength <= 0)
            {
                MessageBox.Show("Barcode Card No. must be there in a warranty. Please enter Barcode Card No.", "Activate warranty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerName.Focus();
                return false;
            }
            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool Check = false;
            DSWarrantyRegister oDSWarrantyRegister = new DSWarrantyRegister();
            DSSystemDate oDSSystemDate;
            //UI Validation
            if (!ValidateUI()) { return; }

            DAWarrantyRegister oDAWarrantyRegister = new DAWarrantyRegister();

            DBController.Instance.OpenNewConnection();
            oDAWarrantyRegister.GetWarrantyRegister(oDSWarrantyRegister, this.txtSerialNo.Text,WarrantyRegMode.SMS);
            bool bSerialNoExist = !(oDSWarrantyRegister.WarrantyRegister.Count == 0);
            DBController.Instance.CloseConnection();

            if (bSerialNoExist && this.Tag == null)
            {
                DialogResult oResult=MessageBox.Show("This serial no. is already exist. Do you want to continue with this serial no.?", "Confirm replace existing warranty", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (oResult == DialogResult.No)
                {
                    return;
                }
                else
                {
                    this.Tag = oDSWarrantyRegister;
                }
            }

            //Check whether add new or modify
            oDSSystemDate = BOUtility.GetCurrentDate();
            if (this.Tag == null)
            {
                //Add new WarrantyRegister
                
                //DSRptWarrantyAct oDSRptWarrantyAct;
                DSWarrantyRegister.WarrantyRegisterRow oSWarrantyRegister = oDSWarrantyRegister.WarrantyRegister.NewWarrantyRegisterRow();
                oSWarrantyRegister.SerialNo = this.txtSerialNo.Text;
                oDSWarrantyRegister.WarrantyRegister.AddWarrantyRegisterRow(oSWarrantyRegister);
                oDSWarrantyRegister.AcceptChanges();

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    Check= oDAWarrantyRegister.DoesWarrentyRegisterActive(oDSWarrantyRegister);
                    if (Check == false)
                    {

                        DSWarrantyRegister.WarrantyRegisterRow oWarrantyRegister = oDSWarrantyRegister.WarrantyRegister.NewWarrantyRegisterRow();
                        oWarrantyRegister.SerialNo = this.txtSerialNo.Text;
                        oWarrantyRegister.RegMode = (long)WarrantyRegMode.Final;
                        //oWarrantyRegister.SalesPersonID = this.txtSalesPersonID.Text;
                        //oWarrantyRegister.CustomerCode = this.txtBarcodeCode.Text;
                        oWarrantyRegister.CustomerName = this.txtCustomerName.Text;
                        oWarrantyRegister.CustomerAddress = this.txtCustomerAddress.Text;
                        oWarrantyRegister.TelephoneNo = this.txtTelephoneNo.Text;
                        oWarrantyRegister.MobileNo = this.txtMobileNo.Text;
                        oWarrantyRegister.Email = this.txtEmail.Text;
                        oWarrantyRegister.PurchaseDate = this.dtpPurchaseDate.Value;
                        oWarrantyRegister.WarrantyCardNo = Convert.ToInt64(this.txtBarcodeCode.Text);
                        oWarrantyRegister.ProductID = Convert.ToInt64(this.ctlProductSearch1.SelectedDSProduct.ProductList[0].ProductCode);
                        if (rbtDealer.Checked)
                        {
                            oWarrantyRegister.SellerCode = this.ctlCustomer1.SelectedDSCustomer.CustomerList[0].CustomerCode.ToString();
                            oWarrantyRegister.SellerName = this.ctlCustomer1.SelectedDSCustomer.CustomerList[0].CustomerName.ToString();
                        }
                        else
                        {
                            oWarrantyRegister.SellerName = this.txtOutlet.Text;
                        }
                        oWarrantyRegister.BillNo = this.txtBillNo.Text;
                        oWarrantyRegister.Remarks = this.txtRemarks.Text;
                        oWarrantyRegister.EntryDate = oDSSystemDate.SystemDate[0].CurrentDate;   
                        oWarrantyRegister.UserName = Utility.GetUserName();
                        oDSWarrantyRegister.WarrantyRegister.AddWarrantyRegisterRow(oWarrantyRegister);
                        oDSWarrantyRegister.AcceptChanges();
                        oDAWarrantyRegister.Insert(oDSWarrantyRegister);
                    }                    
                    DBController.Instance.CommitTransaction();
                    if (Check == false)
                    {
                        MessageBox.Show("Data has been saved successfully", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Serial number is duplicate", "Duplicate SerialNo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    //oDSRptWarrantyAct = new DSRptWarrantyAct();
                    //oDAWarrantyRegister.GetWarrantyRegisterByID(oDSRptWarrantyAct, Convert.ToInt32(oDSWarrantyRegister.WarrantyRegister[0].WarrantyRegID.ToString()));
                    //frmReportViewer oReportViewer = new frmReportViewer();
                    //rptWarrantyActivation oRptWarrantyAct = new rptWarrantyActivation();
                    //oRptWarrantyAct.SetDataSource(oDSRptWarrantyAct);
                    //oReportViewer.WarrantyActReportRefersh(oRptWarrantyAct);
                    //oReportViewer.ReportRefersh(oRptWarrantyAct);
                    //oReportViewer.Show();
                    //if (oDSWarrantyRegister.HasErrors)
                    //{
                    //    setError(oDSWarrantyRegister.WarrantyRegister);
                    //}
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
            else
            {
                //Modify WarrantyRegister
                oDSWarrantyRegister = (DSWarrantyRegister)this.Tag;
                oDSWarrantyRegister.WarrantyRegister[0].WarrantyRegID = Convert.ToInt64( sWarrantyRegisterID);
                oDSWarrantyRegister.WarrantyRegister[0].SerialNo= this.txtSerialNo.Text ;
                oDSWarrantyRegister.WarrantyRegister[0].RegMode = (long)WarrantyRegMode.Final;                 
                oDSWarrantyRegister.WarrantyRegister[0].CustomerName = this.txtCustomerName.Text;
                oDSWarrantyRegister.WarrantyRegister[0].CustomerAddress = this.txtCustomerAddress.Text;
                oDSWarrantyRegister.WarrantyRegister[0].TelephoneNo = this.txtTelephoneNo.Text;
                oDSWarrantyRegister.WarrantyRegister[0].MobileNo = this.txtMobileNo.Text;
                oDSWarrantyRegister.WarrantyRegister[0].Email = this.txtEmail.Text;
                //oDSWarrantyRegister.WarrantyRegister[0].SalesPersonID = this.txtSalesPersonID.Text;
                oDSWarrantyRegister.WarrantyRegister[0].PurchaseDate = this.dtpPurchaseDate.Value;
                oDSWarrantyRegister.WarrantyRegister[0].WarrantyCardNo = Convert.ToInt64(this.txtBarcodeCode.Text);
                oDSWarrantyRegister.WarrantyRegister[0].ProductID = Convert.ToInt64(this.ctlProductSearch1.SelectedDSProduct.ProductList[0].ProductCode);
                if (rbtDealer.Checked)
                {
                    oDSWarrantyRegister.WarrantyRegister[0].SellerCode = this.ctlCustomer1.SelectedDSCustomer.CustomerList[0].CustomerCode.ToString();
                    oDSWarrantyRegister.WarrantyRegister[0].SellerName = this.ctlCustomer1.SelectedDSCustomer.CustomerList[0].CustomerName.ToString();
                }
                else
                {
                    oDSWarrantyRegister.WarrantyRegister[0].SetSellerCodeNull();
                    oDSWarrantyRegister.WarrantyRegister[0].SellerName = this.txtOutlet.Text;
                }
                oDSWarrantyRegister.WarrantyRegister[0].BillNo = this.txtBillNo.Text;
                oDSWarrantyRegister.WarrantyRegister[0].Remarks = this.txtRemarks.Text;
                oDSWarrantyRegister.WarrantyRegister[0].AcceptChanges();

                MessageBoxButtons w = MessageBoxButtons.OKCancel;
                MessageBoxButtons n;
                n = (MessageBoxButtons)MessageBox.Show("Do You Want To Update This Data ?", "Update Message", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

                if (w == n)
                {
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        oDAWarrantyRegister.Update(oDSWarrantyRegister);
                        DBController.Instance.CommitTransaction();
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show("Please Check", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw (ex);
                    }
                    finally
                    {
                        MessageBox.Show("Data has been Updated successfully", "Data Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            if (Check == false)
            {                
                this.ClearAll();
            }
            else
            {
                txtSerialNo.Focus(); 
            }
        }

        private void EnableSalesPointControl()
        {
            if (rbtDealer.Checked)
            {
                ctlCustomer1.Enabled = true;
                txtOutlet.Enabled = false;
            }
            else if (rbtOutlet.Checked)
            {
                ctlCustomer1.txtCode.Text= "";
                ctlCustomer1.Enabled = false;
                txtOutlet.Enabled = true; 
            }

        }

        private void rbtDealer_CheckedChanged(object sender, EventArgs e)
        {
            EnableSalesPointControl();
        }

        private void rbtOutlet_CheckedChanged(object sender, EventArgs e)
        {
            EnableSalesPointControl();
        }

        private void txtSerialNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                txtCustomerName.Focus();
        }

        

        //private void txtCustomerCode_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)Keys.Return)
        //        txtCustomerName.Focus();
        //}

        private void txtCustomerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                txtCustomerAddress.Focus(); 
        }

        private void txtCustomerAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                txtTelephoneNo.Focus(); 
        }

        private void txtTelephoneNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                txtMobileNo.Focus(); 
        }

        private void txtMobileNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                txtEmail.Focus();             
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                dtpPurchaseDate.Focus();                         
        }

        private void dtpPurchaseDate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                txtBarcodeCode.Focus(); 
        }
        private void txtBarcodeCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                ctlProductSearch1.txtCode.Focus();
        }

        private void ctlProduct1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                ctlCustomer1.txtCode.Focus();
        }

        private void ctlCustomer1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtBillNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                txtRemarks.Focus();
        }

        private void txtRemarks_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                btnSave.Focus();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void ClearAll()
        {
            txtSerialNo.Text = "";
            //txtSalesPersonID.Text = "";
            txtBarcodeCode.Text = "";
            txtCustomerName.Text = "";
            txtCustomerAddress.Text = "";
            txtTelephoneNo.Text = "";
            txtMobileNo.Text = "";
            txtEmail.Text = "";
            ctlProductSearch1.txtCode.Text = "";
            //ctlProduct1.SelectedDSProduct.Product[0].ProductID =   
            ctlCustomer1.txtCode.Text = "";
            txtOutlet.Text = "";
            txtBillNo.Text = "";
            txtRemarks.Text = "";
            txtSerialNo.Focus(); 
        }
    }
}
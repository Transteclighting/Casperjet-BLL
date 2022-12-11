using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Admin;
using CJ.Report;
using CJ.Class.POS;

namespace CJ.Win.Basic
{
    public partial class frmCustomerCreditLimit : Form
    {
        Customers oCustomers;
        Customer oCustomer;
        CustomerCreditLimit oCustomerCreditLimit;
        CustomerCreditLimits oCustomerCreditLimits;
      
        
        public frmCustomerCreditLimit()
        {
            InitializeComponent();
        }

        public void ShowDialog(CustomerCreditLimit oCustomerCreditLimit)
        {
            this.Tag = oCustomerCreditLimit;

            //txtCustCode.Text = oCustomerCreditLimit.CustomerCode;
            //txtCustName.Text = oCustomerCreditLimit.CustomerName;
            txtMinCredit.Text = oCustomerCreditLimit.MinCreditLimit.ToString();
            txtMaxCredLimit.Text = oCustomerCreditLimit.MaxCreditLimit.ToString();                       

            if (oCustomerCreditLimit.LimitExpiryDate != null)
            {
                dateTimePicExpiryDate.Value = Convert.ToDateTime(oCustomerCreditLimit.LimitExpiryDate);

            }
            else dateTimePicExpiryDate.Value = DateTime.Today.Date;
            oCustomer = new Customer();
            oCustomer.CustomerID = oCustomerCreditLimit.CustomerID;
            oCustomer.refresh();
            ctlCustomer1.txtCode.Text = oCustomer.CustomerCode;

            this.ShowDialog();
        }


        private void frmCustomerCreditLimit_Load(object sender, EventArgs e)
        {           
            if (this.Tag == null) this.Text = "Add New Creditlimit";
            else this.Text = "Edit Creditlimit";
            DataLoadControlCustomer();

        }

        private void DataLoadControlCustomer()
        {

            CustomerCreditLimits oCustomerCreditLimits = new CustomerCreditLimits();
            {
                lvwCreLimitCusttomer.Items.Clear();               
                DBController.Instance.OpenNewConnection();

                if (ctlCustomer1.SelectedCustomer == null || ctlCustomer1.txtCode.Text == "")
                {
                    MessageBox.Show(" No Customer Selected ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ctlCustomer1.Focus();
                    
                }

                else oCustomerCreditLimits.RefreshAll(ctlCustomer1.SelectedCustomer.CustomerID);

                this.Text = " Customer Credit Limit " + "[" + oCustomerCreditLimits.Count + "]";
                foreach (CustomerCreditLimit oCustomerCreditLimit in oCustomerCreditLimits)
                {
                    ListViewItem oItem = lvwCreLimitCusttomer.Items.Add(oCustomerCreditLimit.CreditlimitID.ToString());
                    oItem.SubItems.Add(oCustomerCreditLimit.CreatedDate.ToString("dd-MMM-yyyy"));
                    oItem.SubItems.Add(oCustomerCreditLimit.LimitExpiryDate.ToString("dd-MMM-yyyy"));
                    oItem.SubItems.Add(oCustomerCreditLimit.MinCreditLimit.ToString("#,##,##,##"));
                    oItem.SubItems.Add(oCustomerCreditLimit.MaxCreditLimit.ToString("#,##,##,##"));                    
                    //oItem.SubItems.Add(oCustomerCreditLimit.Currentbalance.ToString());

                    oItem.Tag = oCustomerCreditLimit;

                }
            }
        }

        private bool validateUIInput()
        {
            #region Input Information Validation


            if (ctlCustomer1.SelectedCustomer.CustomerCode == "")
            {
                MessageBox.Show("Please enter Customer Code ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //ctlCustomer1.SelectedCustomer
                return false;
            }


            if (txtMinCredit.Text.Trim() == "")
            {
                MessageBox.Show(" Please enter Minimum Limit", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMinCredit.Focus();
                return false;
            }
            else
            {
                try
                {
                    double temp = Convert.ToDouble(txtMinCredit.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("Please enter Currect Value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMinCredit.Focus();
                    return false;
                }
            }

            if (txtMaxCredLimit.Text.Trim() == "")
            {
                MessageBox.Show("Please enter Max Credit Limit", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaxCredLimit.Focus();
                return false;
            }
            else
            {
                try
                {
                    double temp = Convert.ToDouble(txtMaxCredLimit.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("Please enter Currect Value", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaxCredLimit.Focus();
                    return false;
                }

            }

            if (dtPickerEffDate.Value < DateTime.Today.Date)
            {
                MessageBox.Show("Effective Date Must be greater or Equal then Today   ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtPickerEffDate.Focus();
                return false;
            }

            //DBController.Instance.OpenNewConnection();
            //oCustomerCreditLimit = new CustomerCreditLimit();
            //oCustomerCreditLimit.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
            //oCustomerCreditLimit.MaxExpiryDay();
            //DBController.Instance.CloseConnection();

            //if (dateTimePicExpiryDate.Value <= oCustomerCreditLimit.MaxExpiryDate & dateTimePicExpiryDate.Value <= oCustomerCreditLimit.MaxExpiryDate)
            //{
            //    MessageBox.Show(" Limit alredy given in this Duration ! Pls. give another input  ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    dateTimePicExpiryDate.Focus();
            //    return false;
            //}


            if (dateTimePicExpiryDate.Value < DateTime.Today.Date)
            {
                MessageBox.Show("Expiry Date Must be greater or Equal then Today ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dateTimePicExpiryDate.Focus();
                return false;
            }


            #endregion
            return true;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {


        }

        private void btnShow_Click(object sender, EventArgs e)
        {
                   
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void button2_Click(object sender, EventArgs e)
        {

             
        }

        private void LoadData()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                //btnClear_Click(sender, e);
               // this.Close();
                DataLoadControlCustomer();

            }
        }

        private void Save()
        {
            string sCustomerCode;

            //if (this.Tag == null)
            //{
                oCustomerCreditLimit = new CustomerCreditLimit();
                
                //oCustomerCreditLimit.CustomerCode = txtCustCode.Text;
                //oCustomerCreditLimit.RefreshByCode();
                //oCustomerCreditLimit.CustomerID = oCustomerCreditLimit.CustomerID;
                oCustomerCreditLimit.CustomerID = ctlCustomer1.SelectedCustomer.CustomerID;
                oCustomerCreditLimit.MinCreditLimit =Convert.ToDouble(txtMinCredit.Text);
                oCustomerCreditLimit.MaxCreditLimit =Convert.ToDouble(txtMaxCredLimit.Text);
                oCustomerCreditLimit.CreatedDate = dtPickerEffDate.Value; 
                oCustomerCreditLimit.LimitExpiryDate = dateTimePicExpiryDate.Value;     
                
                oCustomerCreditLimit.UserID = Utility.UserId;


            try
            {
                DBController.Instance.BeginNewTransaction();
                oCustomerCreditLimit.InvoiceStatus(dtPickerEffDate.Value.Date);

                if (oCustomerCreditLimit.InvCount > 0)
                {
                    MessageBox.Show(" Invoice Exist for this customer ! Pls. assign Limit from Next Day  : " + oCustomerCreditLimit.CustomerName, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    //if (oCustomerCreditLimit.LimitExpiryDate <= oCustomerCreditLimit.MaxExpiryDate & oCustomerCreditLimit.CreatedDate <= oCustomerCreditLimit.MaxExpiryDate)
                    //{
                    //    MessageBox.Show(" Limit alredy given in this Duration ! Pls. give another input  ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);                                                  
                    //}
                    // else
                    //{

                    CustomerCreditLimits oCustomerCreditLimits = new CustomerCreditLimits();
                    oCustomerCreditLimits.GetUpdateableData(ctlCustomer1.SelectedCustomer.CustomerID,dtPickerEffDate.Value);
                    Showroom oShowroom = new Showroom();
                    int WHDID = oShowroom.GetWarehouseIDByCustomer(ctlCustomer1.SelectedCustomer.CustomerID);

                    foreach (CustomerCreditLimit oCreditLimit in oCustomerCreditLimits)
                    {
                        
                        if (WHDID != 0)
                        {
                            DataTran oDataTranAll = new DataTran();
                            oDataTranAll.TableName = "t_CustomerCreditLimit";
                            oDataTranAll.DataID = Convert.ToInt32(oCreditLimit.CreditlimitID);
                            oDataTranAll.WarehouseID = WHDID;
                            oDataTranAll.TransferType = (int)Dictionary.DataTransferType.Add;
                            oDataTranAll.IsDownload = (int)Dictionary.IsDownload.No;
                            oDataTranAll.BatchNo = 0;

                            if (oDataTranAll.CheckDataByWHID() == false)
                            {
                                oDataTranAll.AddForTDPOS();
                            }
                        }

                        #region Insert Customer Credit Limit Data for Super Outlet
                        Customer oCustomerCreditLimitUpdate = new Customer();
                        oCustomerCreditLimitUpdate.CustomerBalanceDataCreation(ctlCustomer1.SelectedCustomer.CustomerID, WHDID, "t_CustomerCreditLimit", Convert.ToInt32(oCreditLimit.CreditlimitID));
                        #endregion


                    }



                    oCustomerCreditLimit.Update();
                    oCustomerCreditLimit.Add();


                    #region Insert Customer Credit Limit Data for Super Outlet
                    Customer oCustomerCreditLimitUpdate1 = new Customer();
                    oCustomerCreditLimitUpdate1.CustomerBalanceDataCreation(ctlCustomer1.SelectedCustomer.CustomerID, WHDID, "t_CustomerCreditLimit", Convert.ToInt32(oCustomerCreditLimit.CreditlimitID));
                    #endregion


                    if (WHDID != 0)
                    {

                        DataTran oDataTran = new DataTran();
                        oDataTran.TableName = "t_CustomerCreditLimit";
                        oDataTran.DataID = Convert.ToInt32(oCustomerCreditLimit.CreditlimitID);
                        oDataTran.WarehouseID = WHDID;
                        oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                        oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                        oDataTran.BatchNo = 0;

                        if (oDataTran.CheckDataByWHID() == false)
                        {
                            oDataTran.AddForTDPOS();
                        }

                    }

                    DBController.Instance.CommitTran();
                    MessageBox.Show("You Have Successfully Save The Transaction : " + oCustomerCreditLimit.CustomerName, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //}
                }


            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }               

            //}            

        }

       


        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {            
            Customers oCustomers = new Customers();
            
           // txtCustName.Text = "";

            DBController.Instance.OpenNewConnection();
           // oCustomer.refresh(txtCustCode.Text,"");

            //txtCustName.Text= oCustomer.CustomerName;                                 

         }

        private void btnGateData_Click(object sender, EventArgs e)
        {
            DataLoadControlCustomer();

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

            if (lvwCreLimitCusttomer.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Limit to Delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CustomerCreditLimit oCustomerCreditLimit = (CustomerCreditLimit)lvwCreLimitCusttomer.SelectedItems[0].Tag;

            DialogResult oResult = MessageBox.Show("Are you sure to delete Customer Credit Limit : " + oCustomerCreditLimit.CustomerName + " ? ", "Confirm Ticket Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oCustomerCreditLimit.MaxCrLimit();
                    if (oCustomerCreditLimit.MaxCrLimitID != oCustomerCreditLimit.CreditlimitID)
                    {
                        MessageBox.Show("Please Select Topmost Row to Delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        oCustomerCreditLimit.CheckInvoice();
                      if (oCustomerCreditLimit.InvCount > 0)
                      {
                          MessageBox.Show(" Invocie Exist for this customer ! Limit Can not Delete   : " + oCustomerCreditLimit.CustomerName, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                      }
                      else
                      {
                          oCustomerCreditLimit.Delete();
                          DBController.Instance.CommitTransaction();
                          DataLoadControlCustomer();
                      }
                    }
                    //DataLoadControlCustomer();                   
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        

       
    }
}
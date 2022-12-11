using System;
using System.Windows.Forms;
using CJ.Class;
using System.Text.RegularExpressions;
using CJ.Class.POS;
using CJ.Win.Control;
using CJ.Class.Web.UI.Class;

namespace CJ.POS
{
    public partial class frmConsumer : Form
    {
        public event System.EventHandler ChangeSelection;
        public event KeyPressEventHandler ChangeFocus;

        Customer _oCustomer;
        RetailConsumer oRetailConsumer;
        public bool IsSuccessfull = false;
        int nConsumerID = 0;
        int _nSalestype = 0;
        public string sConsumerCode = "";
        public bool _IsTrue = false;
        int _nCustomerID = 0;
        string sCustomerCode = "";
        public frmConsumer(int nSalestype, int nCustomerID)
        {
            InitializeComponent();
            _nSalestype = nSalestype;
            _nCustomerID = nCustomerID;

            if (nCustomerID != 0)
            {
                Customer oCustomer = new Customer();
                oCustomer.RefreshByID(_nCustomerID);
                sCustomerCode = oCustomer.CustomerCode;
            }
            else
            {
                SystemInfo oInfo = new SystemInfo();
                oInfo.Refresh();
                sCustomerCode = oInfo.CustomerCode;
            }
            LoadCombo();
            if (nSalestype != 0)
            {
                cmbSalesType.SelectedIndex = nSalestype - 1;
                txtCtlCustCode.Text = sCustomerCode;
                cmbSalesType.Enabled = false;
                txtCtlCustCode.Enabled = false;
                btnCtlCustPicker.Enabled = false;
            }
            else
            {
                cmbSalesType.Enabled = true;
                txtCtlCustCode.Enabled = true;
                btnCtlCustPicker.Enabled = true;
            }

        }
        public void ShowDialog(RetailConsumer oRetailConsumer)
        {
            this.Tag = oRetailConsumer;
            nConsumerID = 0;
            nConsumerID = oRetailConsumer.ConsumerID;
            txtCustomerName.Text = oRetailConsumer.ConsumerName;
            txtConsumerCode.Text = oRetailConsumer.ConsumerCode;
            txtCustomerAddress.Text = oRetailConsumer.Address;
            txtEmail.Text = oRetailConsumer.Email;
            txtNationalID.Text = oRetailConsumer.NationalID;
            txtCell.Text = oRetailConsumer.CellNo;
            txtTelePhone.Text = oRetailConsumer.PhoneNo;
            txtVatRegNo.Text = oRetailConsumer.VatRegNo;
            if (oRetailConsumer.DateofBirth != null)
            {
                dtDateofBirth.Checked = true;
                dtDateofBirth.Value = Convert.ToDateTime(oRetailConsumer.DateofBirth);
            }
            txtShortName.Text = oRetailConsumer.ShortName;
            txtFatherName.Text = oRetailConsumer.FatherName;
            txtMotherName.Text = oRetailConsumer.MotherName;
            txtSpouseName.Text = oRetailConsumer.SpouseName;
            txtPAddress.Text = oRetailConsumer.PermanentAddress;
            txtNationality.Text = oRetailConsumer.Nationality;
            txtpassportNo.Text = oRetailConsumer.PassportNo;

            this.ShowDialog();
        }

        public void LoadCombo()
        {
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.SalesType)))
            {
                cmbSalesType.Items.Add(Enum.GetName(typeof(Dictionary.SalesType), GetEnum));
            }
            cmbSalesType.SelectedIndex = 0;
        }

        private void frmConsumer_Load(object sender, EventArgs e)
        {

        }
        public bool ValidateUIInput()
        {
            if (cmbSalesType.SelectedIndex + 1 != (int)Dictionary.SalesType.Dealer && cmbSalesType.SelectedIndex + 1 != (int)Dictionary.SalesType.B2B)
            {
                if (txtCustomerName.Text == "")
                {
                    MessageBox.Show("Please enter a consumer name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCustomerName.Focus();
                    return false;
                }
                if (txtCustomerAddress.Text == "")
                {
                    MessageBox.Show("Please enter a comsumer address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCustomerAddress.Focus();
                    return false;
                }
                if (txtCell.Text == "")
                {
                    MessageBox.Show("Please enter a consumer cell no", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCell.Focus();
                    return false;
                }
                else
                {
                    if (txtCell.Text.Trim().Length != 11)
                    {
                        MessageBox.Show("Please enter a valid cell no", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCell.Focus();
                        return false;
                    }
                    Regex rgCell = new Regex("[0-9]");
                    if (rgCell.IsMatch(txtCell.Text))
                    {
                        if (this.Tag == null)
                        {
                            RetailConsumer oConsumer = new RetailConsumer();
                            if (oConsumer.GetConsumerByMobileNoSalesType(txtCell.Text, cmbSalesType.SelectedIndex + 1))
                            {
                                MessageBox.Show("This mobile number already register", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }

                    }
                    else
                    {
                        MessageBox.Show("Please Input Valid Cell no ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                }
                if (txtEmail.Text != "")
                {
                    Regex emailregex = new Regex("(?<user>[^@]+)@(?<host>.+)");
                    Match m = emailregex.Match(txtEmail.Text);
                    if (!m.Success)
                    {
                        MessageBox.Show("Please enter a Valid Email Address", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtEmail.Focus();
                        return false;
                    }
                }
            }

            if (cmbSalesType.SelectedIndex+1==(int)Dictionary.SalesType.Dealer|| cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.B2B)
            {

                if (txtCtlCustName.Text != "")
                {
                    if (this.Tag == null)
                    {
                        RetailConsumer oConsumer = new RetailConsumer();
                        if (oConsumer.GetConsumerByCustomerID(_oCustomer.CustomerID))
                        {
                            MessageBox.Show("This customer already registered", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                }

            }


            return true;
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            if (ValidateUIInput())
            {
                if (this.Tag != null)
                {

                    SystemInfo oSystemInfo = new SystemInfo();
                    oSystemInfo.Refresh();
                    oRetailConsumer = new RetailConsumer();

                    if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.B2B || cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.Dealer)
                    {
                        CustomerDetail oCustomerDetail = new CustomerDetail();
                        oCustomerDetail.CustomerID = _oCustomer.CustomerID;
                        oCustomerDetail.RefreshForSalesOrder();
                        oRetailConsumer.ConsumerName = oCustomerDetail.CustomerName;
                        oRetailConsumer.CustomerID = oCustomerDetail.CustomerID; ;
                        oRetailConsumer.SecondaryConsumer = "";
                        oRetailConsumer.SecondaryMobileNo = "";
                        oRetailConsumer.ParentCustomerID = oSystemInfo.CustomerID;
                        oRetailConsumer.Address = oCustomerDetail.CustomerAddress;
                        oRetailConsumer.CellNo = oCustomerDetail.CustomerPhoneNo;
                        oRetailConsumer.PhoneNo = "";
                        oRetailConsumer.Email = "";
                        oRetailConsumer.EmployeeCode = "";
                        oRetailConsumer.NationalID = "";
                        oRetailConsumer.DateofBirth = null;
                        oRetailConsumer.VatRegNo = oCustomerDetail.TaxNumber;
                        oRetailConsumer.DeliveryAddress = oCustomerDetail.CustomerAddress;
                        oRetailConsumer.SalesType = cmbSalesType.SelectedIndex + 1;
                        oRetailConsumer.WarehouseID = oSystemInfo.WarehouseID;
                        oRetailConsumer.DateofBirth = null;


                    }
                    else
                    {

                        oRetailConsumer.ConsumerName = txtCustomerName.Text;
                        oRetailConsumer.Address = txtCustomerAddress.Text;
                        oRetailConsumer.Email = txtEmail.Text;
                        oRetailConsumer.NationalID = txtNationalID.Text;
                        oRetailConsumer.CellNo = txtCell.Text;
                        oRetailConsumer.PhoneNo = txtTelePhone.Text;
                        oRetailConsumer.VatRegNo = txtVatRegNo.Text;
                        if (dtDateofBirth.Checked == true)
                        {
                            oRetailConsumer.DateofBirth = dtDateofBirth.Value.Date;
                        }
                        else oRetailConsumer.DateofBirth = null;
                        oRetailConsumer.ShortName = txtShortName.Text;
                        oRetailConsumer.FatherName = txtFatherName.Text;
                        oRetailConsumer.MotherName = txtMotherName.Text;
                        oRetailConsumer.SpouseName = txtSpouseName.Text;
                        oRetailConsumer.PermanentAddress = txtPAddress.Text;
                        oRetailConsumer.Nationality = txtNationality.Text;
                        oRetailConsumer.PassportNo = txtpassportNo.Text;
                        oRetailConsumer.IsCLP = 1;
                        oRetailConsumer.IsRegister = 1;
                        oRetailConsumer.SalesType = cmbSalesType.SelectedIndex + 1;

                        if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.Retail || cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.eStore)
                        {
                            oRetailConsumer.CustomerID = _oCustomer.CustomerID;
                            oRetailConsumer.ParentCustomerID = _oCustomer.CustomerID;
                        }
                        else
                        {
                            oRetailConsumer.CustomerID = _oCustomer.CustomerID;
                            oRetailConsumer.ParentCustomerID = oSystemInfo.CustomerID;
                        }
                    }

                    try
                    {

                        oRetailConsumer.ConsumerID = nConsumerID;
                        oRetailConsumer.Edit();
                        DataTran oDataTran = new DataTran();
                        oDataTran.TableName = "t_RetailConsumer";
                        oDataTran.DataID = Convert.ToInt32(nConsumerID);
                        oDataTran.WarehouseID = oSystemInfo.WarehouseID;
                        oDataTran.TransferType = (int)Dictionary.DataTransferType.Edit;
                        oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                        oDataTran.BatchNo = 0;

                        if (oDataTran.CheckData() == false)
                        {
                            oDataTran.AddForTDPOS();
                        }
                        _IsTrue = true;
                        MessageBox.Show("Successfull Update Consumer.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        IsSuccessfull = true;
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
                    SystemInfo oSystemInfo = new SystemInfo();
                    oSystemInfo.Refresh();
                    oRetailConsumer = new RetailConsumer();

                    if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.B2B || cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.Dealer)
                    {
                        CustomerDetail oCustomerDetail = new CustomerDetail();
                        oCustomerDetail.CustomerID = _oCustomer.CustomerID;
                        oCustomerDetail.RefreshForSalesOrder();
                        oRetailConsumer.ConsumerName = oCustomerDetail.CustomerName;
                        oRetailConsumer.CustomerID = oCustomerDetail.CustomerID; ;
                        oRetailConsumer.SecondaryConsumer = "";
                        oRetailConsumer.SecondaryMobileNo = "";
                        oRetailConsumer.ParentCustomerID = oSystemInfo.CustomerID;
                        oRetailConsumer.Address = oCustomerDetail.CustomerAddress;
                        oRetailConsumer.CellNo = oCustomerDetail.CustomerPhoneNo;
                        oRetailConsumer.PhoneNo = "";
                        oRetailConsumer.Email = "";
                        oRetailConsumer.EmployeeCode = "";
                        oRetailConsumer.NationalID = "";
                        oRetailConsumer.DateofBirth = null;
                        oRetailConsumer.VatRegNo = oCustomerDetail.TaxNumber;
                        oRetailConsumer.DeliveryAddress = oCustomerDetail.CustomerAddress;
                        oRetailConsumer.SalesType = cmbSalesType.SelectedIndex + 1;
                        oRetailConsumer.WarehouseID = oSystemInfo.WarehouseID;
                        oRetailConsumer.DateofBirth = null;


                    }
                    else
                    {

                        oRetailConsumer.ConsumerName = txtCustomerName.Text;
                        oRetailConsumer.Address = txtCustomerAddress.Text;
                        oRetailConsumer.Email = txtEmail.Text;
                        oRetailConsumer.NationalID = txtNationalID.Text;
                        oRetailConsumer.CellNo = txtCell.Text;
                        oRetailConsumer.PhoneNo = txtTelePhone.Text;
                        oRetailConsumer.VatRegNo = txtVatRegNo.Text;
                        if (dtDateofBirth.Checked == true)
                        {
                            oRetailConsumer.DateofBirth = dtDateofBirth.Value.Date;
                        }
                        else oRetailConsumer.DateofBirth = null;
                        oRetailConsumer.ShortName = txtShortName.Text;
                        oRetailConsumer.FatherName = txtFatherName.Text;
                        oRetailConsumer.MotherName = txtMotherName.Text;
                        oRetailConsumer.SpouseName = txtSpouseName.Text;
                        oRetailConsumer.PermanentAddress = txtPAddress.Text;
                        oRetailConsumer.Nationality = txtNationality.Text;
                        oRetailConsumer.PassportNo = txtpassportNo.Text;
                        oRetailConsumer.IsCLP = 1;
                        oRetailConsumer.IsRegister = 1;
                        oRetailConsumer.SalesType = cmbSalesType.SelectedIndex + 1;

                        if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.Retail || cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.eStore)
                        {
                            oRetailConsumer.CustomerID = _oCustomer.CustomerID;
                            oRetailConsumer.ParentCustomerID = _oCustomer.CustomerID;
                        }
                        else
                        {
                            oRetailConsumer.CustomerID = _oCustomer.CustomerID;
                            oRetailConsumer.ParentCustomerID = oSystemInfo.CustomerID;
                        }
                    }

                    try
                    {
                        oRetailConsumer.AddNewRetailConsumer();
                        sConsumerCode = oRetailConsumer.ConsumerCode;
                        _IsTrue = true;
                        MessageBox.Show("Successfull add new Consumer. Consumer Code:" + oRetailConsumer.ConsumerCode + "", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        IsSuccessfull = true;
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

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cmbSalesType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.Dealer || cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.B2B)
            {
               

                txtConsumerCode.Enabled = false;
                txtCustomerName.Enabled = false;
                txtCustomerAddress.Enabled = false;
                dtDateofBirth.Enabled = false;
                txtCell.Enabled = false;
                txtVatRegNo.Enabled = false;
                txtNationalID.Enabled = false;
                txtTelePhone.Enabled = false;
                txtShortName.Enabled = false;
                txtFatherName.Enabled = false;
                txtMotherName.Enabled = false;
                txtSpouseName.Enabled = false;
                txtPAddress.Enabled = false;
                txtNationality.Enabled = false;
                txtpassportNo.Enabled = false;


                MessageBox.Show("You cannot Add or Edit Dealer/B2B");
                cmbSalesType.SelectedIndex = 0;
                return;

                if (_nCustomerID == 0)
                {


                    txtCtlCustCode.Enabled = true;
                    btnCtlCustPicker.Enabled = true;
                    txtCtlCustCode.Text = "";
                    txtConsumerCode.Text = "";
                }
                else
                {
                    txtCtlCustCode.Text = sCustomerCode;
                }


            }
            else if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.B2C || cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.HPA)
            {
                //txtConsumerCode.Enabled = true;
                txtCustomerName.Enabled = true;
                txtCustomerAddress.Enabled = true;
                dtDateofBirth.Enabled = true;
                txtCell.Enabled = true;
                txtVatRegNo.Enabled = true;
                txtNationalID.Enabled = true;
                txtTelePhone.Enabled = true;
                txtShortName.Enabled = true;
                txtFatherName.Enabled = true;
                txtMotherName.Enabled = true;
                txtSpouseName.Enabled = true;
                txtPAddress.Enabled = true;
                txtNationality.Enabled = true;
                txtpassportNo.Enabled = true;
                if (_nCustomerID == 0)
                {
                    txtCtlCustCode.Enabled = true;
                    btnCtlCustPicker.Enabled = true;
                    txtCtlCustCode.Text = "";
                    txtConsumerCode.Text = "";
                }
                else
                {

                    txtCtlCustCode.Text = sCustomerCode;
                }


            }
            else
            {
                //txtConsumerCode.Enabled = true;
                txtCustomerName.Enabled = true;
                txtCustomerAddress.Enabled = true;
                dtDateofBirth.Enabled = true;
                txtCell.Enabled = true;
                txtVatRegNo.Enabled = true;
                txtNationalID.Enabled = true;
                txtTelePhone.Enabled = true;
                txtShortName.Enabled = true;
                txtFatherName.Enabled = true;
                txtMotherName.Enabled = true;
                txtSpouseName.Enabled = true;
                txtPAddress.Enabled = true;
                txtNationality.Enabled = true;
                txtpassportNo.Enabled = true;

                txtCtlCustCode.Enabled = false;
                btnCtlCustPicker.Enabled = false;
                txtCtlCustCode.Text = sCustomerCode;
                
            }
        }

        private void txtCtlCustCode_TextChanged(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            _oCustomer = new Customer();

            txtCtlCustCode.ForeColor = System.Drawing.Color.Red;
            txtCtlCustName.Text = "";

            if (txtCtlCustCode.Text.Length >= 1 && txtCtlCustCode.Text.Length <= 25)
            {
                _oCustomer.CustomerCode = txtCtlCustCode.Text;
                _oCustomer.RefreshByCode();

                if (_oCustomer.CustomerName == null)
                {
                    _oCustomer = null;
                    AppLogger.LogFatal("There is no data in the customer.");
                    return;
                }
                else if (_oCustomer.IsActive == (int)Dictionary.IsActive.InActive)
                {
                    MessageBox.Show("Please select active customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCtlCustCode.Text = "";
                    txtCtlCustCode.Focus();
                    return;
                }
                else
                {
                   // _nCustomerID = _oCustomer.CustomerID;
                    txtCtlCustName.Text = _oCustomer.CustomerName.ToString();
                    txtCtlCustCode.SelectionStart = 0;
                    txtCtlCustCode.SelectionLength = txtCtlCustCode.Text.Length;
                    txtCtlCustCode.ForeColor = System.Drawing.Color.Empty;
                    if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.Dealer || cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.B2B)
                    {
                        txtCustomerAddress.Text = _oCustomer.CustomerAddress;
                    }
                }

                if (txtCtlCustName.Text != "")
                {
                    if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.Dealer)
                    {
                        if (_oCustomer.IsCustomerAccount == (int)Dictionary.YesOrNoStatus.NO)
                        {
                            MessageBox.Show("There is no customer account. Please contact MIS department", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtCtlCustCode.Text = "";
                            txtCtlCustCode.Focus();
                            return;
                        }
                    }
                }
            }
            if (ChangeSelection != null)
                ChangeSelection(this, e);
        }

        private void btnCtlCustPicker_Click(object sender, EventArgs e)
        {
            CustomerTypies oCustomerTypes = new CustomerTypies();
            _oCustomer = new Customer();
            frmCustomerSearch oObj = new frmCustomerSearch(oCustomerTypes.GetCustTypeSalesTypeWise(cmbSalesType.SelectedIndex + 1));
            oObj.ShowDialog(_oCustomer);
            if (_oCustomer.CustomerCode != null)
            {
                if (cmbSalesType.SelectedIndex + 1 == (int)Dictionary.SalesType.Dealer)
                {
                    if (_oCustomer.IsCustomerAccount == (int)Dictionary.YesOrNoStatus.NO)
                    {
                        MessageBox.Show("There is no customer account. Please contact MIS department", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtCtlCustCode.Text = "";
                        txtCtlCustCode.Focus();
                        return;
                    }
                }
                if (_oCustomer.IsActive == (int)Dictionary.IsActive.Active)
                {
                    txtCtlCustCode.Text = _oCustomer.CustomerCode.ToString();
                }
                else
                {
                    MessageBox.Show("Please select active customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCtlCustCode.Text = "";
                    txtCtlCustCode.Focus();
                    return;
                }
            }
        }
    }
}
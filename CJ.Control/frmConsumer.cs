using System;
using System.Windows.Forms;
using CJ.Class;
using System.Text.RegularExpressions;
using CJ.Class.POS;

namespace CJ.Control
{
    public partial class frmConsumer : Form
    {
        RetailConsumer oRetailConsumer;
        public bool IsSuccessfull = false;
        int nConsumerID = 0;
        int _nSalestype = 0;
        public string sConsumerCode = "";
        public bool _IsTrue = false;
        int _nCustomerID = 0;
        int _nWarehouseID = 0;
        int _nParentnCustomerID = 0;
        public frmConsumer(int nSalestype, int nCustomerID,int nWarehouseID,int nParentnCustomerID)
        {
            InitializeComponent();
            _nSalestype = nSalestype;
            _nCustomerID = nCustomerID;
            _nWarehouseID = nWarehouseID;
            _nParentnCustomerID = nParentnCustomerID;

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

        private void frmConsumer_Load(object sender, EventArgs e)
        {

        }
        public bool ValidateUIInput()
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
            return true;
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            if (ValidateUIInput())
            {
                if (this.Tag != null)
                {
                    oRetailConsumer = new RetailConsumer();

                    oRetailConsumer.ConsumerID = nConsumerID;
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
                    oRetailConsumer.WarehouseID = _nWarehouseID;
                    try
                    {
                        oRetailConsumer.EditRT();
                        DataTran oDataTran = new DataTran();
                        oDataTran.TableName = "t_RetailConsumer";
                        oDataTran.DataID = Convert.ToInt32(nConsumerID);
                        oDataTran.WarehouseID = _nWarehouseID;
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
                    oRetailConsumer = new RetailConsumer();
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
                    oRetailConsumer.SalesType = _nSalestype;
                    oRetailConsumer.CustomerID = _nCustomerID;
                    oRetailConsumer.ParentCustomerID = _nParentnCustomerID;
                    oRetailConsumer.WarehouseID = _nWarehouseID;
                    try
                    {
                        oRetailConsumer.AddNewRetailConsumerRT();
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
    }
}
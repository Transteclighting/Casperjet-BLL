using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using TEL.SMS.BO.BE;
using TEL.SMS.BO.DA;

namespace TEL.SMS.UI.Win
{
    public partial class frmITInvoice : Form
    {
        private ITProduct _oITProduct;
        private ITProduct _oDSSupplier;
        public frmITInvoice()
        {
            InitializeComponent();
        }

        public void ShowDialog(ITProduct oDSITProduct)        
        {
            DAITProduct oDAITProduct = new DAITProduct();
            oDAITProduct.GetInvoice(oDSITProduct);

            this.Tag = oDSITProduct;
            this.txtInvoiceNo.Text = oDSITProduct.Invoice[0].InvoiceNo;
            this.dtpInvoiceDate.Value = oDSITProduct.Invoice[0].InvoiceDate;
            this.cboSupplier.SelectedValue = oDSITProduct.Invoice[0].SupplierID;
            this.txtChalanNo.Text = oDSITProduct.Invoice[0].ChalanNo;
            this.dtpChalanDate.Value = oDSITProduct.Invoice[0].ChalanDate;
            this.txtGRDNo.Text = oDSITProduct.Invoice[0].GRDNo;
            this.dtpGRDDate.Value = oDSITProduct.Invoice[0].GRDDate;
            if (!oDSITProduct.Invoice[0].IsRemarksNull())
            {
                this.txtRemarks.Text = oDSITProduct.Invoice[0].Remarks;
            }
            
            //this.btnCancel.Visible = false;
            this.btnSave.Visible = false;
            this.addToolStripMenuItem.Visible = false;
            this.removeToolStripMenuItem.Visible = false;


            oDAITProduct.GetInvoiceItem(oDSITProduct);

            string sSerialNos = "";
            foreach (ITProduct.InvoiceItemRow oDSInvoiceItemRow in oDSITProduct.InvoiceItem)
            {
                ListViewItem oItem = lvwInvoiceItem.Items.Add(oDSInvoiceItemRow.ProductCode.ToString());
                oItem.SubItems.Add(oDSInvoiceItemRow.ProductDescription.ToString ());
                oItem.SubItems.Add(oDSInvoiceItemRow.PartNo.ToString());
                oItem.SubItems.Add(oDSInvoiceItemRow.Qty.ToString());
                oItem.SubItems.Add(oDSInvoiceItemRow.UnitPrice.ToString());
                sSerialNos = getSerialNos(oDSITProduct, oDSInvoiceItemRow.ProductCode);
                oItem.SubItems.Add(sSerialNos);                
            }           
            this.ShowDialog();
        }

        private string getSerialNos(ITProduct oDSITProduct,long nProductCode)
        {
            string sSerialNos = "";
            DataRow[] oDataRows= oDSITProduct.InvoiceItemSerialNo.Select("ProductCode=" + nProductCode);
            int First = 0;
            foreach(DataRow oRow in oDataRows)
            {
                if (First == 0)
                {
                    sSerialNos = sSerialNos + oRow[2].ToString() ;
                    First = First + 1;
                }
                else
                {
                    sSerialNos = sSerialNos + ","  + oRow[2].ToString() ;
                }
            }
            return sSerialNos;
        }

        private void frmITInvoice_Load(object sender, EventArgs e)
        {
            _oITProduct = new ITProduct();
            refreshCombo();
        }

        private void refreshCombo()
        {
            //Get All the mobiles.
            _oDSSupplier = new ITProduct();
            DAITProduct oDAITProduct = new DAITProduct();
            try
            {
                DBController.Instance.OpenNewConnection();
                oDAITProduct.GetAllSuppliers(_oDSSupplier);
                DBController.Instance.CloseConnection();
            }
            catch (Exception e)
            {
                MessageBox.Show("Server not found. Please check the network cable or call system admin.", "Server connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
                        
            //foreach (ITProduct.ITSupplierRow oSupplier in _oDSSupplier.ITSupplier)
            //{
            //    cboSupplier.Items.Add(oSupplier.Name);
            //}

            //
            
            //foreach (ITProduct.ITSupplierRow in ITProduct.ITSupplier)
            ////foreach (ITProduct.ITSupplierRow oSupplier in _oDSSupplier.ITSupplier)
            ////{
            ////    cboSupplier.Items.Add(_oDSSupplier.ITSupplier);
            ////}

            //Select first item in the list.
            ////if(cboSupplier.Items.Count >0)
            ////{
            ////    cboSupplier.SelectedIndex = " ";
            ////}
            //

            //Clear and Populate list.
            cboSupplier.Items.Clear();
            //foreach(ITProduct )
            
            ////cboSupplier.DisplayMember = "Name";
            ////cboSupplier.ValueMember = "SupplierID";
            ////cboSupplier.DataSource = _oDSSupplier.ITSupplier;
            

            //cboSupplier.DataSource = _oDSSupplier.InvoiceItem;
            ////cboSupplier.ValueMember = "Supplier";
            ////cboShowroom.ValueMember  = _oDSShowroom.Showroom.Columns["SRID"].ToString();
            ////cboSupplier.DisplayMember = _oDSSupplier.InvoiceItem.Columns["Supplier"].ToString(); 
        }


        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmITInvoiceItem oForm = new frmITInvoiceItem();
            oForm.ShowDialog(_oITProduct);
            refreshList();
        }

        private void refreshList()
        {
            //Get All the mobiles.
            ITProduct oITProduct = _oITProduct;
            DAITProduct oDAITProduct = new DAITProduct();

            //Clear and Populate list.
            lvwInvoiceItem.Items.Clear();
            string sSerialNos = "";            
            foreach (ITProduct.InvoiceItemRow oInvoiceItemRow in oITProduct.InvoiceItem)
            {
                ListViewItem oItem = lvwInvoiceItem.Items.Add(oInvoiceItemRow.ProductCode.ToString());
                oItem.SubItems.Add(oInvoiceItemRow.ProductDescription);
                oItem.SubItems.Add(oInvoiceItemRow.PartNo);
                oItem.SubItems.Add(oInvoiceItemRow.Qty.ToString());
                oItem.SubItems.Add(oInvoiceItemRow.UnitPrice.ToString());
                sSerialNos = getSerialNos(oITProduct, oInvoiceItemRow.ProductCode);
                oItem.SubItems.Add(sSerialNos);
                oItem.Tag = oInvoiceItemRow;
            }

        }

        private bool ValidateUI()
        {

            if (this.txtInvoiceNo.Text == "")
            {
                DialogResult o = MessageBox.Show("Please Insert Invoice no.", "IT Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtInvoiceNo.Focus();
                return false;
            }
            if (this.txtChalanNo.Text == "")
            {
                DialogResult o = MessageBox.Show("Please Insert Chalan no.", "IT Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtChalanNo.Focus();
                return false;
            }
            if (this.txtGRDNo.Text == "")
            {
                DialogResult o = MessageBox.Show("Please Insert GRD no.", "IT Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.txtGRDNo.Focus();
                return false;
            }

            if (this.cboSupplier.SelectedIndex == -1)
            {
                DialogResult o = MessageBox.Show("Please Select suppplier", "IT Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cboSupplier.Focus();
                return false;
            }
            if (this.lvwInvoiceItem.Items.Count == 0)
            {
                DialogResult o = MessageBox.Show("Please Insert Product", "IT Product", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.lvwInvoiceItem.Focus();
                return false;
            }
            


            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateUI()) return;  

            //Check whether add new or modify
            if (this.Tag == null)
            {
                //Add new Person

                ITProduct.InvoiceRow oInvoice = _oITProduct.Invoice.NewInvoiceRow();
                oInvoice.InvoiceNo = this.txtInvoiceNo.Text;
                oInvoice.InvoiceDate = this.dtpInvoiceDate.Value;
                oInvoice.ChalanNo = this.txtChalanNo.Text;
                oInvoice.ChalanDate = this.dtpInvoiceDate.Value;
                oInvoice.GRDNo = this.txtGRDNo.Text;
                oInvoice.GRDDate = this.dtpGRDDate.Value;
                oInvoice.SupplierID = _oDSSupplier.ITSupplier[cboSupplier.SelectedIndex].SupplierID;

                _oITProduct.Invoice.AddInvoiceRow(oInvoice);
                _oITProduct.AcceptChanges();

                DAITProduct oDAITProduct = new DAITProduct();
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oDAITProduct.Insert(_oITProduct);
                    DBController.Instance.CommitTransaction();
                    //if (oDSPerson.HasErrors)
                    //{
                    //    setError(oDSPerson.Person);
                    //}
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
            //else
            //{
            //    //Modify Person
            //    DSPerson oDSPerson = (DSPerson)this.Tag;
            //    oDSPerson.Person[0].PersonCode = this.txtPersonCode.Text;
            //    oDSPerson.Person[0].PersonName = this.txtPersonName.Text;
            //    oDSPerson.Person[0].MobileNo = this.txtMobileNo.Text;
            //    oDSPerson.AcceptChanges();

            //    DAPerson oDAPerson = new DAPerson();
            //    DBController.Instance.BeginNewTransaction();
            //    oDAPerson.Update(oDSPerson);
            //    DBController.Instance.CommitTransaction();
            //}
            this.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cboSupplierGenerate(object sender, EventArgs e)
        {
            cboSupplier.DisplayMember = "Name";
            cboSupplier.ValueMember = "SupplierID";
            cboSupplier.DataSource = _oDSSupplier.ITSupplier;
        }
              
    }
}
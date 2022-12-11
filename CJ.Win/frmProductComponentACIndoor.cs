using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Report;

namespace CJ.Win
{
    public partial class frmProductComponentACIndoor : Form
    {
        public bool _IsLoadData = false;
        public frmProductComponentACIndoor()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void ShowDialog(ProductComponent oProductComponent)
        {
            this.Tag = oProductComponent;

            ctlProduct1.txtCode.Text = oProductComponent.ProductCode;
            txtProductSerial.Text = oProductComponent.ProductSerial;
            txtPCBSerial.Text = oProductComponent.PCBSerial;
            txtBarcodeSerial.Text = oProductComponent.BarcodeSerial;
            this.ShowDialog();
        }
        private bool validateUIInput()
        {

            if (ctlProduct1.txtDescription.Text == "")
            {
                MessageBox.Show("Please enter Product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (txtProductSerial.Text == "")
            {
                MessageBox.Show("Please enter Product Serial", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductSerial.Focus();
                return false;
            }
            if (txtPCBSerial.Text == "")
            {
                MessageBox.Show("Please enter PCB Serial", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPCBSerial.Focus();
                return false;
            }
            if (txtBarcodeSerial.Text == "")
            {
                MessageBox.Show("Please enter Barcode Serial", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBarcodeSerial.Focus();
                return false;
            }


            return true;
        }
        private void Save()
        {
            if (this.Tag == null)
            {
                ProductComponent oProductComponent = new ProductComponent();
                oProductComponent.ProductID = ctlProduct1.SelectedSerarchProduct.ProductID;
                oProductComponent.ProductSerial = txtProductSerial.Text;
                oProductComponent.PCBSerial = txtPCBSerial.Text;
                oProductComponent.BarcodeSerial = txtBarcodeSerial.Text;
                oProductComponent.IsIndoorItem = (int)Dictionary.YesOrNoStatus.YES;
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oProductComponent.AddACIndoor();
                    _IsLoadData = true;
                    PrintChecklist(ctlProduct1.txtDescription.Text,txtBarcodeSerial.Text,txtProductSerial.Text,txtPCBSerial.Text);
                    DBController.Instance.CommitTran();
                    MessageBox.Show("Save Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
            else
            {
                ProductComponent oProductComponent = (ProductComponent)this.Tag;

                {
                    oProductComponent.ProductID = ctlProduct1.SelectedSerarchProduct.ProductID;
                    oProductComponent.ProductSerial = txtProductSerial.Text;
                    oProductComponent.PCBSerial = txtPCBSerial.Text;
                    oProductComponent.BarcodeSerial = txtBarcodeSerial.Text;
                    oProductComponent.IsIndoorItem = (int)Dictionary.YesOrNoStatus.YES;
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        oProductComponent.EditACIndoor();
                        _IsLoadData = true;
                        PrintChecklist(ctlProduct1.txtDescription.Text, txtBarcodeSerial.Text, txtProductSerial.Text, txtPCBSerial.Text);

                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Data Update Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }

                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                ctlProduct1.txtCode.Text = "";
                txtProductSerial.Text = "";
                txtBarcodeSerial.Text = "";
                txtPCBSerial.Text = "";
            }
        }

        public void PrintChecklist(string sProduct, string sBarcode, string sProductSerial, string sPCBSerial)
        {

            CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptProductComponentACIndoor));
            doc.SetParameterValue("Product", sProduct);
            doc.SetParameterValue("Barcode", sBarcode);
            doc.SetParameterValue("ProductSerial", sProductSerial);
            doc.SetParameterValue("PCBSerial", sPCBSerial);
            doc.PrintToPrinter(1, true, 1, 1);
        }

        private void txtProductSerial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBarcodeSerial.Focus();
            }
        }

        private void txtBarcodeSerial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPCBSerial.Focus();
            }
        }
    }
}
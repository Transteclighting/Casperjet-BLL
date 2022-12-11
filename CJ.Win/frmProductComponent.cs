using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.CSD;
using CJ.Class;
using CJ.Report;

namespace CJ.Win
{
    public partial class frmProductComponent : Form
    {
        int nREF = 22;
        int nFRZ = 811;
        int nFPTV = 791;
        int nHTV = 792;

        int nLCAC = 0;
        int nRAC = 25;
        int nCAC = 804;
 

        string sType = "TV";

        public frmProductComponent()
        {
            InitializeComponent();
        }

        public void ShowDialog(ProductComponent oProductComponent)
        {
            this.Tag = oProductComponent;

            ctlProduct1.txtCode.Text = oProductComponent.ProductCode;
            ctlProduct1.txtDescription.Text = oProductComponent.ProductName;
            txtProductSerial.Text = oProductComponent.ProductSerial;
            txtPSUSerial.Text = oProductComponent.PSUSerial;
            txtBarcodeSerial.Text = oProductComponent.BarcodeSerial;
            ProductDetail oProductDetail = new ProductDetail();

            oProductDetail.Refresh(oProductComponent.ProductID);

            if (oProductDetail.MAGID == nREF || oProductDetail.MAGID == nFRZ)
            {
                sType = "REF";
            }
            else if (oProductDetail.MAGID == nFPTV || oProductDetail.MAGID == nHTV)
            {
                sType = "TV";
            }
            else if (oProductDetail.MAGID == nRAC || oProductDetail.MAGID == nLCAC || oProductDetail.MAGID == nCAC)
            {
                sType = "AC";
            }

            if (sType == "REF")
            {
                lblSSBSerial.Text = "CB Serial";
                lblPanelSL.Text = "Compressor SL";
                txtPanelSerial.Text = oProductComponent.CompressorSerial;
                txtSSBSerial.Text = oProductComponent.CBSerial;

            }
            else if (sType == "AC")
            {
                lblSSBSerial.Text = "CB Serial";
                lblPanelSL.Text = "Compressor SL";
                txtPanelSerial.Text = oProductComponent.CompressorSerial;
                txtSSBSerial.Text = oProductComponent.CBSerial;

            }
            else
            {
                lblSSBSerial.Text = "SSB Serial";
                lblPanelSL.Text = "Panel Serial";
                txtPanelSerial.Text = oProductComponent.PanelSerial;
                txtSSBSerial.Text = oProductComponent.SSBSerial;
            }
            lblSSBSerial.Refresh();
            lblPanelSL.Refresh();
            this.ShowDialog();
        }

        private bool validateUIInput()
        {
            #region Input Information Validation 


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
            if (txtPanelSerial.Text == "")
            {
                MessageBox.Show("Please enter Panel Serial", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPanelSerial.Focus();
                return false;
            }
            if (txtSSBSerial.Text == "")
            {
                MessageBox.Show("Please enter SSB Serial", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSSBSerial.Focus();
                return false;
            }
            if (txtPSUSerial.Text == "")
            {
                MessageBox.Show("Please enter PSU Serial", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPSUSerial.Focus();
                return false;
            }
            if (txtBarcodeSerial.Text == "")
            {
                MessageBox.Show("Please enter Barcode Serial", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBarcodeSerial.Focus();
                return false;
            }

            #endregion

            return true;
        }

        private void Save()
        {
            if (this.Tag == null)
            {

                ProductComponent oProductComponent = new ProductComponent();

                oProductComponent.ProductID =ctlProduct1.SelectedSerarchProduct.ProductID;
                oProductComponent.ProductSerial = txtProductSerial.Text;
                oProductComponent.PanelSerial = txtPanelSerial.Text;
                if (sType == "REF")
                {
                    oProductComponent.CBSerial = txtSSBSerial.Text;
                    oProductComponent.SSBSerial = "";
                    oProductComponent.CompressorSerial = txtPanelSerial.Text;
                    oProductComponent.PanelSerial = "";
                }
                else if (sType == "AC")
                {
                    oProductComponent.CBSerial = txtSSBSerial.Text;
                    oProductComponent.SSBSerial = "";
                    oProductComponent.CompressorSerial = txtPanelSerial.Text;
                    oProductComponent.PanelSerial = "";
                }
                else
                {
                    oProductComponent.SSBSerial = txtSSBSerial.Text;
                    oProductComponent.CBSerial = "";
                    oProductComponent.PanelSerial = txtPanelSerial.Text;
                    oProductComponent.CompressorSerial = "";
                }
                oProductComponent.PSUSerial = txtPSUSerial.Text;
                oProductComponent.BarcodeSerial = txtBarcodeSerial.Text;

                ProductDetail oProductDetail = new ProductDetail();
                oProductDetail.Refresh(oProductComponent.ProductID);
                if (oProductDetail.MAGID == nRAC || oProductDetail.MAGID == nLCAC || oProductDetail.MAGID == nCAC)
                {
                    sType = "AC";
                }
                oProductComponent.IsIndoorItem = (int)Dictionary.YesOrNoStatus.NO;
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oProductComponent.Add();
                    PrintChecklist(oProductComponent.ProductComponentID, sType);
                    DBController.Instance.CommitTran();
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
                ProductComponent oProductComponent = (ProductComponent)this.Tag;
                   
                {
                    oProductComponent.ProductID = ctlProduct1.SelectedSerarchProduct.ProductID;
                    oProductComponent.ProductSerial = txtProductSerial.Text;
                    oProductComponent.PanelSerial = txtPanelSerial.Text;
                    if (sType == "REF")
                    {
                        oProductComponent.CBSerial = txtSSBSerial.Text;
                        oProductComponent.SSBSerial = "";
                        oProductComponent.CompressorSerial = txtPanelSerial.Text;
                        oProductComponent.PanelSerial = "";
                    }
                    else if (sType == "AC")
                    {
                        oProductComponent.CBSerial = txtSSBSerial.Text;
                        oProductComponent.SSBSerial = "";
                        oProductComponent.CompressorSerial = txtPanelSerial.Text;
                        oProductComponent.PanelSerial = "";
                    }
                    else
                    {
                        oProductComponent.SSBSerial = txtSSBSerial.Text;
                        oProductComponent.CBSerial = "";
                        oProductComponent.PanelSerial = txtPanelSerial.Text;
                        oProductComponent.CompressorSerial = "";
                    }
                    oProductComponent.PSUSerial = txtPSUSerial.Text;
                    oProductComponent.BarcodeSerial = txtBarcodeSerial.Text;
                    ProductDetail oProductDetail = new ProductDetail();
                    oProductDetail.Refresh(oProductComponent.ProductID);
                    if (oProductDetail.MAGID == nRAC || oProductDetail.MAGID == nLCAC || oProductDetail.MAGID == nCAC)
                    {
                        sType = "AC";
                    }
                    oProductComponent.IsIndoorItem = (int)Dictionary.YesOrNoStatus.NO;

                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        oProductComponent.Edit();
                        PrintChecklist(oProductComponent.ProductComponentID, sType);
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Data Update Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ctlProduct1.txtCode.Focus();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                if (this.Tag != null)
                {
                    this.Close();
                }
                else
                {
                    Clear();
                }

            }

        }
        private void Clear()
        {
            ctlProduct1.txtCode.Text = "";
            ctlProduct1.txtDescription.Text = "";
            txtProductSerial.Text = "";
            txtBarcodeSerial.Text = "";
            txtPanelSerial.Text = "";
            txtPSUSerial.Text = "";
            txtSSBSerial.Text = "";
        
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void PrintChecklist(int nProductComponentID, string sType)
        {
            ProductComponent oProductComponent = new ProductComponent();

            oProductComponent.RefreshByID(nProductComponentID);

            if (sType == "TV")
            {
                CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptProductComponent));

                doc.SetParameterValue("Product", oProductComponent.ProductName);
                doc.SetParameterValue("Barcode", oProductComponent.BarcodeSerial);
                doc.SetParameterValue("Serial", oProductComponent.ProductSerial);
                doc.SetParameterValue("Panel", oProductComponent.PanelSerial);
                doc.SetParameterValue("PSU", oProductComponent.PSUSerial);
                doc.SetParameterValue("SSB", oProductComponent.SSBSerial);

                doc.PrintToPrinter(1, true, 1, 1);
            }
            else if (sType == "AC")
            {
                CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptProductComponentAC));

                doc.SetParameterValue("Product", oProductComponent.ProductName);
                doc.SetParameterValue("Barcode", oProductComponent.BarcodeSerial);
                doc.SetParameterValue("Serial", oProductComponent.ProductSerial);
                doc.SetParameterValue("Compressor", oProductComponent.CompressorSerial);
                doc.SetParameterValue("Panel", oProductComponent.PanelSerial);
                doc.SetParameterValue("PSU", oProductComponent.PSUSerial);
                doc.SetParameterValue("SSB", oProductComponent.SSBSerial);

                doc.PrintToPrinter(1, true, 1, 1);
            }
            else
            {
                CrystalDecisions.CrystalReports.Engine.ReportClass doc = ReportFactory.GetReport(typeof(rptProductComponentRef));

                doc.SetParameterValue("Product", oProductComponent.ProductName);
                doc.SetParameterValue("Barcode", oProductComponent.BarcodeSerial);
                doc.SetParameterValue("Serial", oProductComponent.ProductSerial);
                doc.SetParameterValue("Compressor", oProductComponent.CompressorSerial);
                doc.SetParameterValue("PSU", oProductComponent.PSUSerial);
                doc.SetParameterValue("CB", oProductComponent.CBSerial);

                doc.PrintToPrinter(1, true, 1, 1);
            }

        }

        private void ctlProduct1_Leave(object sender, EventArgs e)
        {
            if (ctlProduct1.txtDescription.Text != "")
            {
                ProductDetail oProductDetail = new ProductDetail();

                oProductDetail.Refresh(ctlProduct1.SelectedSerarchProduct.ProductID);

                if (oProductDetail.MAGID == nREF || oProductDetail.MAGID == nFRZ)
                {
                    sType = "REF";
                }
                else if (oProductDetail.MAGID == nFPTV || oProductDetail.MAGID == nHTV)
                {
                    sType = "TV";
                }
                else
                {
                    sType = "AC";
                }


                if (sType == "REF")
                {
                    lblSSBSerial.Text = "CB Serial";
                    lblPanelSL.Text = "Compressor SL";
                }
                else if (sType == "AC")
                {
                    lblSSBSerial.Text = "CB Serial";
                    lblPanelSL.Text = "Compressor SL";
                }
                else
                {
                    lblSSBSerial.Text = "SSB Serial";
                    lblPanelSL.Text = "Panel Serial";
                }
                lblSSBSerial.TextAlign = ContentAlignment.MiddleRight;
                lblPanelSL.TextAlign = ContentAlignment.MiddleRight;
                lblSSBSerial.Refresh();
                lblPanelSL.Refresh();
            }
        }

        private void txtProductSerial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPanelSerial.Focus();
            }
        }

        private void txtPanelSerial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtSSBSerial.Focus();
            }
        }

        private void txtSSBSerial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPSUSerial.Focus();
            }
        }

        private void txtPSUSerial_KeyDown(object sender, KeyEventArgs e)
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
                btnSave.Focus();
            }
        }

        private void frmProductComponent_Load(object sender, EventArgs e)
        {

        }
    }
}
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
using CJ.Class.Library;
using CJ.Win.BEIL;

namespace CJ.Win
{
    public partial class frmProductComponents : Form
    {
        Brands _oBrands;
        TELReg oReg;

        int nREF = 22;
        int nFRZ = 811;
        int nFPTV = 791;
        int nHTV = 792;

        int nLCAC = 0;
        int nRAC = 25;
        int nCAC = 804;
 

        string sType = "TV";
        private ProductGroups _oPG;
        private ProductGroups _oMAG;
        private ProductGroups _oASG;
        private ProductGroups _oAG;

        public frmProductComponents()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DataLoadControl()
        {

            ProductComponents oProductComponents = new ProductComponents();
            lvwProductComponent.Items.Clear();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }


            bool IsCheck = false;
            if (All.Checked == true)
            {
                IsCheck = true;
            }
            else
            {
                IsCheck = false;
            }
            int nBrand = 0;
            if (cmbBrand.SelectedIndex == 0)
            {
                nBrand = -1;
            }
            else
            {
                nBrand = _oBrands[cmbBrand.SelectedIndex - 1].BrandID;
            }

            int nAG = 0;
            if (cboAG.SelectedIndex == 0)
            {
                nAG = -1;
            }
            else
            {
                nAG = _oAG[cboAG.SelectedIndex - 1].PdtGroupID;
            }

            int nASG = 0;
            if (cboASG.SelectedIndex == 0)
            {
                nASG = -1;
            }
            else
            {
                nASG = _oASG[cboASG.SelectedIndex - 1].PdtGroupID;
            }

            int nMAG = 0;
            if (cboMAG.SelectedIndex == 0)
            {
                nMAG = -1;
            }
            else
            {
                nMAG = _oMAG[cboMAG.SelectedIndex - 1].PdtGroupID;
            }

            int nPG = 0;
            if (cboPG.SelectedIndex == 0)
            {
                nPG = -1;
            }
            else
            {
                nPG = _oPG[cboPG.SelectedIndex - 1].PdtGroupID;
            }


            oProductComponents.Refresh(dtFromDate.Value.Date, dtToDate.Value.Date, txtBarcode.Text, IsCheck, txtPanelSL.Text, txtProductSL.Text, txtPSUSL.Text, txtSSBSL.Text, nBrand, txtCBSerial.Text, txtCompressorSL.Text, nAG, nASG, nMAG, nPG, txtProductCode.Text.Trim(), txtProductName.Text.Trim(), txtinvoiceNo.Text.Trim());

            this.Text = "Total " + "[" + oProductComponents.Count + "]";
            foreach (ProductComponent oProductComponent in oProductComponents)
            {
                ListViewItem oItem = lvwProductComponent.Items.Add(oProductComponent.ProductComponentID.ToString());
                oItem.SubItems.Add(oProductComponent.CreateDate.ToString("dd-MMM-yyyy H:mm:ss zzz"));
                oItem.SubItems.Add(oProductComponent.ProductCode.ToString());
                oItem.SubItems.Add(oProductComponent.ProductName.ToString());
                oItem.SubItems.Add(oProductComponent.AGName.ToString());
                oItem.SubItems.Add(oProductComponent.ASGName.ToString());
                oItem.SubItems.Add(oProductComponent.MAGName.ToString());
                oItem.SubItems.Add(oProductComponent.PGName.ToString());
                oItem.SubItems.Add(oProductComponent.BrandDesc.ToString());
                oItem.SubItems.Add(oProductComponent.ProductSerial.ToString());
                oItem.SubItems.Add(oProductComponent.PanelSerial.ToString());
                oItem.SubItems.Add(oProductComponent.SSBSerial.ToString());
                oItem.SubItems.Add(oProductComponent.CBSerial.ToString());
                oItem.SubItems.Add(oProductComponent.CompressorSerial.ToString());
                oItem.SubItems.Add(oProductComponent.PSUSerial.ToString());
                oItem.SubItems.Add(oProductComponent.BarcodeSerial.ToString());
                oItem.SubItems.Add(oProductComponent.InvoiceNo.ToString());
                if (oProductComponent.InvoiceDate != null)
                {
                    oItem.SubItems.Add(Convert.ToDateTime(oProductComponent.InvoiceDate).ToString("dd-MMM-yyyy"));
                }
                else
                {
                    oItem.SubItems.Add("");
                }

                oItem.Tag = oProductComponent;
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            frmProductComponent oForm = new frmProductComponent();
            oForm.ShowDialog();
            DataLoadControl();
        
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwProductComponent.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ProductComponent oProductComponent = (ProductComponent)lvwProductComponent.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete ID: " + oProductComponent.ProductComponentID + " ? ", "Confirm Ticket Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oProductComponent.Delete();
                    DBController.Instance.CommitTransaction();
                    DataLoadControl();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
        }

        private void frmProductComponents_Load(object sender, EventArgs e)
        {
            oReg = new TELReg("Software\\Transcom Electronics Limited\\" + Application.ProductName, "BrandID");
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            LoadCombo();
            DataLoadControl();
        }
        private void All_CheckedChanged(object sender, EventArgs e)
        {
            if (All.Checked == true)
            {
                dtFromDate.Enabled = false;
                dtToDate.Enabled = false;
            }
            else
            {
                dtFromDate.Enabled = true;
                dtToDate.Enabled = true;
            }

        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwProductComponent.SelectedItems.Count != 0)
            {

                ProductComponent oProductComponent = (ProductComponent)lvwProductComponent.SelectedItems[0].Tag;

                frmProductComponent oForm = new frmProductComponent();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.Text = "Edit Product Component";
                oForm.ShowDialog(oProductComponent);
                DataLoadControl();

            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }

        }

        private void lvwProductComponent_DoubleClick(object sender, EventArgs e)
        {
            if (lvwProductComponent.SelectedItems.Count != 0)
            {

                ProductComponent oProductComponent = (ProductComponent)lvwProductComponent.SelectedItems[0].Tag;

                frmProductComponent oForm = new frmProductComponent();
                oForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                oForm.MaximizeBox = false;
                oForm.Text = "Edit Product Component";
                oForm.ShowDialog(oProductComponent);
                DataLoadControl();

            }
            else
            {
                MessageBox.Show("Please Select a Row.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (lvwProductComponent.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row to print.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProductComponent oProductComponent = (ProductComponent)lvwProductComponent.SelectedItems[0].Tag;
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
            else
            {
                sType = "AC";
            }

            if (sType == "REF")
            {
                rptProductComponentRef oReport = new rptProductComponentRef();
                oReport.SetParameterValue("CB", oProductComponent.CBSerial);
                oReport.SetParameterValue("Product", oProductComponent.ProductName);
                oReport.SetParameterValue("Barcode", oProductComponent.BarcodeSerial);
                oReport.SetParameterValue("Serial", oProductComponent.ProductSerial);
                oReport.SetParameterValue("Compressor", oProductComponent.CompressorSerial);
                oReport.SetParameterValue("PSU", oProductComponent.PSUSerial);
                frmPrintPreview oForm = new frmPrintPreview();
                oForm.ShowDialog(oReport);
            }
            else if (sType == "AC")
            {
                rptProductComponentAC doc = new rptProductComponentAC();

                doc.SetParameterValue("Product", oProductComponent.ProductName);
                doc.SetParameterValue("Barcode", oProductComponent.BarcodeSerial);
                doc.SetParameterValue("Serial", oProductComponent.ProductSerial);
                doc.SetParameterValue("Compressor", oProductComponent.CompressorSerial);
                doc.SetParameterValue("Panel", oProductComponent.PanelSerial);
                doc.SetParameterValue("PSU", oProductComponent.PSUSerial);
                doc.SetParameterValue("SSB", oProductComponent.SSBSerial);
                frmPrintPreview oForm = new frmPrintPreview();
                oForm.ShowDialog(doc);
            }
            else
            {
                rptProductComponent oReport = new rptProductComponent();
                oReport.SetParameterValue("SSB", oProductComponent.SSBSerial);
                oReport.SetParameterValue("Product", oProductComponent.ProductName);
                oReport.SetParameterValue("Barcode", oProductComponent.BarcodeSerial);
                oReport.SetParameterValue("Serial", oProductComponent.ProductSerial);
                oReport.SetParameterValue("Panel", oProductComponent.PanelSerial);
                oReport.SetParameterValue("PSU", oProductComponent.PSUSerial);
                frmPrintPreview oForm = new frmPrintPreview();
                oForm.ShowDialog(oReport);
            }



        }

        private void LoadCombo()
        {
            _oBrands = new Brands();
            _oBrands.GetAllBrand(Dictionary.BrandLevel.MasterBrand);
            cmbBrand.Items.Clear();
            cmbBrand.Items.Add("<All>");
            foreach (Brand oBrand in _oBrands)
            {
                cmbBrand.Items.Add(oBrand.BrandDesc);
            }
            cmbBrand.SelectedIndex = 0;


            //PG
            _oPG = new ProductGroups();
            _oPG.GETPG();
            cboPG.Items.Clear();
            cboPG.Items.Add("<All>");
            foreach (ProductGroup oProductGroup in _oPG)
            {
                cboPG.Items.Add(oProductGroup.PdtGroupName);
            }
            cboPG.SelectedIndex = 0;

            //MAG
            _oMAG = new ProductGroups();
            _oMAG.GETMAG();
            cboMAG.Items.Clear();
            cboMAG.Items.Add("<All>");
            foreach (ProductGroup oProductGroup in _oMAG)
            {
                cboMAG.Items.Add(oProductGroup.PdtGroupName);
            }
            cboMAG.SelectedIndex = 0;

            //ASG
            _oASG = new ProductGroups();
            _oASG.GETASG();
            cboASG.Items.Clear();
            cboASG.Items.Add("<All>");
            foreach (ProductGroup oProductGroup in _oASG)
            {
                cboASG.Items.Add(oProductGroup.PdtGroupName);
            }
            cboASG.SelectedIndex = 0;

            //AG
            _oAG = new ProductGroups();
            _oAG.GETAG();
            cboAG.Items.Clear();
            cboAG.Items.Add("<All>");
            foreach (ProductGroup oProductGroup in _oAG)
            {
                cboAG.Items.Add(oProductGroup.PdtGroupName);
            }
            cboAG.SelectedIndex = 0;
        }

        private void txtProductCode_TextChanged(object sender, EventArgs e)
        {
            //DataLoadControl();
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            //DataLoadControl();
        }

        private void txtProductSL_TextChanged(object sender, EventArgs e)
        {
            //DataLoadControl();
        }

        private void txtCompressorSL_TextChanged(object sender, EventArgs e)
        {
            //DataLoadControl();
        }

        private void txtSSBSL_TextChanged(object sender, EventArgs e)
        {
            //DataLoadControl();

        }

        private void txtPanelSL_TextChanged(object sender, EventArgs e)
        {
            //DataLoadControl();
        }

        private void txtPSUSL_TextChanged(object sender, EventArgs e)
        {
            //DataLoadControl();
        }

        private void txtCBSerial_TextChanged(object sender, EventArgs e)
        {
            //DataLoadControl();
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            //DataLoadControl();
        }

        private void btnSerialUniversal_Click(object sender, EventArgs e)
        {

        }

        private void btnHeaderPrint_Click(object sender, EventArgs e)
        {
            if (lvwProductComponent.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row to print.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProductComponent oProductComponent = (ProductComponent)lvwProductComponent.SelectedItems[0].Tag;
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
            else
            {
                sType = "AC";
            }

            if (sType == "REF")
            {
                rptProductComponentRefHeader oReport = new rptProductComponentRefHeader();
                oReport.SetParameterValue("CB", oProductComponent.CBSerial);
                oReport.SetParameterValue("Product", oProductComponent.ProductName);
                oReport.SetParameterValue("Barcode", oProductComponent.BarcodeSerial);
                oReport.SetParameterValue("Serial", oProductComponent.ProductSerial);
                oReport.SetParameterValue("Compressor", oProductComponent.CompressorSerial);
                oReport.SetParameterValue("PSU", oProductComponent.PSUSerial);
                frmPrintPreview oForm = new frmPrintPreview();
                oForm.ShowDialog(oReport);
            }
            else if (sType == "AC")
            {
                rptProductComponentACHeader doc = new rptProductComponentACHeader();

                doc.SetParameterValue("Product", oProductComponent.ProductName);
                doc.SetParameterValue("Barcode", oProductComponent.BarcodeSerial);
                doc.SetParameterValue("Serial", oProductComponent.ProductSerial);
                doc.SetParameterValue("Compressor", oProductComponent.CompressorSerial);
                doc.SetParameterValue("Panel", oProductComponent.PanelSerial);
                doc.SetParameterValue("PSU", oProductComponent.PSUSerial);
                doc.SetParameterValue("SSB", oProductComponent.SSBSerial);
                frmPrintPreview oForm = new frmPrintPreview();
                oForm.ShowDialog(doc);
            }
            else
            {
                rptProductComponentHeader oReport = new rptProductComponentHeader();
                oReport.SetParameterValue("SSB", oProductComponent.SSBSerial);
                oReport.SetParameterValue("Product", oProductComponent.ProductName);
                oReport.SetParameterValue("Barcode", oProductComponent.BarcodeSerial);
                oReport.SetParameterValue("Serial", oProductComponent.ProductSerial);
                oReport.SetParameterValue("Panel", oProductComponent.PanelSerial);
                oReport.SetParameterValue("PSU", oProductComponent.PSUSerial);
                frmPrintPreview oForm = new frmPrintPreview();
                oForm.ShowDialog(oReport);
            }
        }
    }
}
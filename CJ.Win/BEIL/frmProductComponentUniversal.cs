using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CJ.Class;
using CJ.Report;

namespace CJ.Win.BEIL
{
    public partial class frmProductComponentUniversal : Form
    {
        public bool _IsTrue = false;
        int _SetID = 0;
        int _nType = 0;
        DateTime _dtCreateDate;
        int nCreateUserID = 0;
        int _ProductionType = 0;
        int _IsIndoorItem = 0;
        int _nLocationID = 0;
        ProductComponents _oProductComponents = new ProductComponents();
        public frmProductComponentUniversal(int nType,int nProductionType,int nIsIndoorItem)
        {
            InitializeComponent();
            _nType = nType;
            _ProductionType = nProductionType;
            _IsIndoorItem = nIsIndoorItem;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            this.Close();
        }
        public void ShowDialog(ProductComponent oProductComponent)
        {
            _nLocationID = oProductComponent.LocationID;

            _SetID = oProductComponent.SetID;
            ctlProduct1.txtCode.Text = oProductComponent.ProductCode;
            _dtCreateDate = oProductComponent.CreateDate;
            nCreateUserID = oProductComponent.CreateUserID;
            this.ShowDialog();
        }
        private bool validateUIInput()
        {

            if (ctlProduct1.txtDescription.Text == "")
            {
                MessageBox.Show("Please select a product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ctlProduct1.txtCode.Focus();
                return false;
            }
            //foreach (DataGridViewRow oItemRow in dgvComponent.Rows)
            //{
            //    if (oItemRow.Index < dgvComponent.Rows.Count)
            //    {

            //        if (oItemRow.Cells[0].Value == null)
            //        {
            //            MessageBox.Show("Please input valid component name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return false;
            //        }
            //        if (oItemRow.Cells[0].Value.ToString().Trim() == "")
            //        {
            //            MessageBox.Show("Please input valid component name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return false;
            //        }
            //        if (oItemRow.Cells[1].Value == null)
            //        {
            //            MessageBox.Show("Please input valid Component Serial#", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return false;
            //        }
            //        if (oItemRow.Cells[1].Value.ToString().Trim() == "")
            //        {
            //            MessageBox.Show("Please input valid Component Serial#", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            return false;
            //        }

            //    }
            //}
            return true;
        }
        private bool Validate()
        {
            int nCount = dgvComponent.Rows.Count;
            foreach (DataGridViewRow oItemRow in dgvComponent.Rows)
            {
                if (oItemRow.Index < dgvComponent.Rows.Count)
                {
                    if (oItemRow.Cells[1].Value != null)
                    {
                        if (oItemRow.Cells[1].Value.ToString().Trim() != "")
                        {
                            nCount--;
                        }
                    }

                }
            }
            if (nCount == 0)
                return true;
            else return false;
        }

        private bool SelectionValidate()
        {
            int nCount = 0;
            foreach (DataGridViewRow oItemRow in dgvComponent.Rows)
            {
                if (oItemRow.Index < dgvComponent.Rows.Count)
                {
                    if (oItemRow.Cells[1].Value != null)
                    {
                        if (oItemRow.Cells[1].Value.ToString().Trim() != "")
                        {
                            nCount++;
                        }
                    }

                }
            }
            if (nCount == 0)
                return true;
            else return false;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                try
                {
                    ProductComponent oProductComponent = new ProductComponent();
                    int nSetID = 0;
                    if (_nType == 1)
                    {
                        nSetID = oProductComponent.GetUniversalMAXID();
                    }
                    else
                    {
                        nSetID = _SetID;
                        oProductComponent.DeleteProductComponent(nSetID);
                    }

                    DBController.Instance.BeginNewTransaction();
                    foreach (DataGridViewRow oItemRow in dgvComponent.Rows)
                    {
                        if (oItemRow.Index < dgvComponent.Rows.Count)
                        {
                            ProductComponent oComponent = new ProductComponent();
                            oComponent.SetID = nSetID;
                            oComponent.ComponentID = int.Parse(oItemRow.Cells[2].Value.ToString());
                            oComponent.ProductID = ctlProduct1.SelectedSerarchProduct.ProductID;
                            oComponent.BarcodeSerial = oItemRow.Cells[1].Value.ToString();
                            if (_nType == 1)
                            {
                                oComponent.CreateDate = DateTime.Now;
                                oComponent.CreateUserID = Utility.UserId;
                            }
                            else
                            {
                                oComponent.CreateDate = _dtCreateDate;
                                oComponent.CreateUserID = nCreateUserID;
                            }
                            oComponent.IsIndoorItem = _IsIndoorItem;
                            oComponent.ProductionType = _ProductionType;
                            oComponent.AddComponentSerialUniversal(_nType, 1);

                        }
                    }
                   

                    if (_ProductionType == 1)
                    {
                        
                    }
                    else
                    {
                        PrintHeaderChecklist(nSetID);
                    }

                    DBController.Instance.CommitTransaction();
                    //MessageBox.Show("Successfully Add Component Serial", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ctlProduct1.txtCode.Text = "";
                    _IsTrue = true;

                    lblMessage.Visible = true;
                    lblMessage.Text = "Successfully Add Component Serial";
                    if (_nType == 2)
                    {
                        this.Close();
                    }
                    ctlProduct1.txtCode.Focus();

                   
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }


            }
        }

        string sType = "";
        int nREF = 22;
        int nFRZ = 811;
        int nFPTV = 791;
        int nHTV = 792;
        //private void PrintChecklist(int nSetID)
        //{
        //    if (_IsIndoorItem == 1)
        //    {
        //        rptProductComponentACIndoorNew doc = new rptProductComponentACIndoorNew();
              
        //        _oProductComponents.RefreshComponent(ctlProduct1.txtCode.Text, nSetID, _ProductionType, _IsIndoorItem);
        //        doc.SetDataSource(_oProductComponents);
        //        doc.SetParameterValue("Product", ctlProduct1.txtDescription.Text);

        //        frmPrintPreview oForm = new frmPrintPreview();
        //        oForm.ShowDialog(doc);
        //    }
        //    else
        //    {
        //        ProductDetail oProductDetail = new ProductDetail();
        //        oProductDetail.Refresh(ctlProduct1.SelectedSerarchProduct.ProductID);
        //        if (oProductDetail.MAGID == nREF || oProductDetail.MAGID == nFRZ)
        //        {
        //            sType = "REF";
        //        }
        //        else if (oProductDetail.MAGID == nFPTV || oProductDetail.MAGID == nHTV)
        //        {
        //            sType = "TV";
        //        }
        //        else
        //        {
        //            sType = "AC";
        //        }

        //        if (sType == "REF")
        //        {
        //            rptProductComponentRefNew doc = new rptProductComponentRefNew();

        //            _oProductComponents.RefreshComponent(ctlProduct1.txtCode.Text, nSetID, _ProductionType, _IsIndoorItem);
        //            doc.SetDataSource(_oProductComponents);
        //            doc.SetParameterValue("Product", ctlProduct1.txtDescription.Text);

        //            frmPrintPreview oForm = new frmPrintPreview();
        //            oForm.ShowDialog(doc);
        //        }
        //        else if (sType == "AC")
        //        {
        //            rptProductComponentACNew doc = new rptProductComponentACNew();

        //            _oProductComponents.RefreshComponent(ctlProduct1.txtCode.Text, nSetID, _ProductionType, _IsIndoorItem);
        //            doc.SetDataSource(_oProductComponents);
        //            doc.SetParameterValue("Product", ctlProduct1.txtDescription.Text);

        //            frmPrintPreview oForm = new frmPrintPreview();
        //            oForm.ShowDialog(doc);
        //        }
        //        else
        //        {
        //            rptProductComponentNew doc = new rptProductComponentNew();

        //            _oProductComponents.RefreshComponent(ctlProduct1.txtCode.Text, nSetID, _ProductionType, _IsIndoorItem);
        //            doc.SetDataSource(_oProductComponents);
        //            doc.SetParameterValue("Product", ctlProduct1.txtDescription.Text);

        //            frmPrintPreview oForm = new frmPrintPreview();
        //            oForm.ShowDialog(doc);
        //        }
        //    }
        //}


        private void PrintHeaderChecklist(int nSetID)
        {
            if (_IsIndoorItem == 1)
            {
                rptProductComponentACIndoorNew doc = new rptProductComponentACIndoorNew();
                //rptProductComponentACIndoorNewHeader doc = new rptProductComponentACIndoorNewHeader();

                _oProductComponents.RefreshComponent(ctlProduct1.txtCode.Text, nSetID, _ProductionType, _IsIndoorItem, 1);
                doc.SetDataSource(_oProductComponents);
                doc.SetParameterValue("Product", ctlProduct1.txtDescription.Text);

                doc.PrintToPrinter(1, true, 1, 1);
                //frmPrintPreview oForm = new frmPrintPreview();
                //oForm.ShowDialog(doc);
            }
            else
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
                    //rptProductComponentRefNewHeader doc = new rptProductComponentRefNewHeader();
                    rptProductComponentRefNew doc = new rptProductComponentRefNew();

                    _oProductComponents.RefreshComponent(ctlProduct1.txtCode.Text, nSetID, _ProductionType, _IsIndoorItem, 1);
                    doc.SetDataSource(_oProductComponents);
                    doc.SetParameterValue("Product", ctlProduct1.txtDescription.Text);

                    doc.PrintToPrinter(1, true, 1, 1);
                    //frmPrintPreview oForm = new frmPrintPreview();
                    //oForm.ShowDialog(doc);
                }
                else if (sType == "AC")
                {
                    //rptProductComponentACNewHeader doc = new rptProductComponentACNewHeader();
                    rptProductComponentACNew doc = new rptProductComponentACNew();

                    _oProductComponents.RefreshComponent(ctlProduct1.txtCode.Text, nSetID, _ProductionType, _IsIndoorItem, 1);
                    doc.SetDataSource(_oProductComponents);
                    doc.SetParameterValue("Product", ctlProduct1.txtDescription.Text);
                    doc.PrintToPrinter(1, true, 1, 1);
                    //frmPrintPreview oForm = new frmPrintPreview();
                    //oForm.ShowDialog(doc);
                }
                else
                {
                    //rptProductComponentNewHeader doc = new rptProductComponentNewHeader();
                    rptProductComponentNew doc = new rptProductComponentNew();

                    _oProductComponents.RefreshComponent(ctlProduct1.txtCode.Text, nSetID, _ProductionType, _IsIndoorItem, 1);
                    doc.SetDataSource(_oProductComponents);
                    doc.SetParameterValue("Product", ctlProduct1.txtDescription.Text);

                    doc.PrintToPrinter(1, true, 1, 1);

                    //frmPrintPreview oForm = new frmPrintPreview();
                    //oForm.ShowDialog(doc);
                }
            }
        }


        private void ctlProduct1_ChangeSelection(object sender, EventArgs e)
        {
            dgvComponent.Rows.Clear();
            if (ctlProduct1.txtDescription.Text != "")
            {
                lblMessage.Visible = false;
                dgvComponent.Focus();
                ProductComponents oComponents = new ProductComponents();
                if (_nType == 1)
                {
                    if (ctlProduct1.txtDescription.Text != "")
                    {
                        oComponents.RefreshComponent(ctlProduct1.txtCode.Text, -1, _ProductionType, _IsIndoorItem, 1);
                    }
                }
                else
                {
                    oComponents.RefreshComponent(ctlProduct1.txtCode.Text, _SetID, _ProductionType, _IsIndoorItem, _nLocationID);
                }
                dgvComponent.Rows.Clear();
                foreach (ProductComponent oProductComponent in oComponents)
                {
                    DataGridViewRow oRow = new DataGridViewRow();
                    oRow.CreateCells(dgvComponent);
                    oRow.Cells[0].Value = oProductComponent.ComponentName.ToString();
                    oRow.Cells[1].Value = oProductComponent.ProductSerial.ToString();
                    oRow.Cells[2].Value = oProductComponent.ComponentID.ToString();
                    dgvComponent.Rows.Add(oRow);

                }
                if (oComponents.Count > 0)
                {
                    DataGridViewCell cell = dgvComponent.Rows[0].Cells[1];
                    dgvComponent.CurrentCell = cell;
                    dgvComponent.BeginEdit(true);
                }

            }
        }
        
        private void dgvComponent_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (_nType == 1)
            {
                if (Validate())
                {
                    btnSave_Click(null, null);
                }
            }
        }

        private void dgvComponent_KeyUp(object sender, KeyEventArgs e)
        {
            if (_nType == 1)
            {
                if (SelectionValidate())
                {
                    DataGridViewCell cell = dgvComponent.Rows[0].Cells[1];
                    dgvComponent.CurrentCell = cell;
                    dgvComponent.BeginEdit(true);
                }
                if (Validate())
                {
                    btnSave_Click(null, null);
                }
            }
        }

        //private void dgvComponent_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        //{
        //    if (e.Control is DataGridViewTextBoxEditingControl)
        //    {
        //        DataGridViewTextBoxEditingControl tb = e.Control as DataGridViewTextBoxEditingControl;
        //        tb.KeyDown -= dgvComponent_KeyDown;
        //        tb.KeyDown += dgvComponent_KeyDown;
        //    }
        //}
        

        //then in your keydown event handler, execute your code
        //private void dgvComponent_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyData == Keys.Enter)
        //    {
        //        SendKeys.Send("{TAB}{TAB}");
        //    }
        //}
    }
}

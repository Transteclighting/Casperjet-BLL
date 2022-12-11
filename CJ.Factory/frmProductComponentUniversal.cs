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
using CJ.Class.POS;

namespace CJ.Factory
{
    public partial class frmProductComponentUniversal : Form
    {
        public event System.EventHandler ChangeSelection;
        public event KeyPressEventHandler ChangeFocus;
        SerarchProduct oSerarchProductOld;

        SerarchProduct oSerarchProduct;
        public bool _IsTrue = false;
        int _SetID = 0;
        int _LocationID = 0;
        int _nType = 0;
        DateTime _dtCreateDate;
        int nCreateUserID = 0;
        int _ProductionType = 0;
        int _IsIndoorItem = 0;
        int _IsFGSerial = 0;
        int nCount1 = 0;
        ProductComponents _oProductComponents = new ProductComponents();
        public frmProductComponentUniversal(int nType,int nProductionType,int nIsIndoorItem)
        {
            InitializeComponent();
            _nType = nType;
            _ProductionType = nProductionType;
            _IsIndoorItem = nIsIndoorItem;

            if(nProductionType == 3)
            {
                _IsFGSerial = 2;
                _ProductionType = 2;
                btnSave.Enabled = false;                
                txtSerialNo.Focus();
                
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            this.Close();
        }
        public void ShowDialog(ProductComponent oProductComponent)
        {

            _SetID = oProductComponent.SetID;
            _LocationID = oProductComponent.LocationID;
            _IsIndoorItem = oProductComponent.IsIndoorItem;
            txtCode.Text = oProductComponent.ProductCode;
            _dtCreateDate = oProductComponent.CreateDate;
            nCreateUserID = oProductComponent.CreateUserID;
            this.ShowDialog();
        }

        public void ShowDialog(int nProductionType)
        {
            txtCode.Visible = false;
            btnPicker.Visible = false;
            txtName.Visible = false;
            label1.Visible = false;
            txtSerialNo.Visible = true;
            label3.Visible = true;
            _nType = 2;
            _IsIndoorItem = 0;
            _ProductionType = 2;
            _IsFGSerial = 1;
            //_SetID = oProductComponent.SetID;
            //_LocationID = oProductComponent.LocationID;
            //txtCode.Text = oProductComponent.ProductCode;
            //_dtCreateDate = oProductComponent.CreateDate;
            //nCreateUserID = oProductComponent.CreateUserID;
            this.ShowDialog();
        }

        private bool validateUIInput()
        {
            if (_IsFGSerial == 0)
            {
                if (txtName.Text == "")
                {
                    MessageBox.Show("Please select a product", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCode.Focus();
                    return false;
                }
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

            //    }
            //}
            return true;
        }
        private bool Validate()
        {
            int nCount = 0;
            if (_ProductionType != 1)
            {
                nCount = dgvComponent.Rows.Count-1;
            }
            else
            {
                nCount = dgvComponent.Rows.Count;
            }
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
            if (nCount > 0)
                return false;
            else return true;
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
            if (dgvComponent.Rows.Count == 0)
            {
                return;
            }

            if (validateUIInput())
            {
                try
                {
                    if (!DBController.Instance.CheckConnection())
                    {
                        DBController.Instance.OpenNewConnection();
                    }

                    ProductComponent oProductComponent = new ProductComponent();
                    int nSetID = 0;

                    DBController.Instance.BeginNewTransaction();

                    if (_nType == 1)
                    {
                        nSetID = oProductComponent.GetUniversalMAXID();
                    }
                    else
                    {
                        nSetID = _SetID;
                        oProductComponent.DeleteProductComponent(nSetID);
                    }
                    

                    foreach (DataGridViewRow oItemRow in dgvComponent.Rows)
                    {
                        if (oItemRow.Index < dgvComponent.Rows.Count)
                        {
                            ProductComponent oComponent = new ProductComponent();
                            oComponent.SetID = nSetID;
                            oComponent.ComponentID = int.Parse(oItemRow.Cells[2].Value.ToString());
                            //oComponent.ProductID = ctlProduct1.SelectedSerarchProduct.ProductID;
                            oComponent.ProductID = oSerarchProduct.ProductID;
                            try
                            {
                                oComponent.BarcodeSerial = oItemRow.Cells[1].Value.ToString();
                            }
                            catch
                            {
                                oComponent.BarcodeSerial = "";
                            }
                            if (_nType == 1)
                            {
                                oComponent.CreateDate = DateTime.Now;
                                oComponent.CreateUserID = Utility.UserId;
                            }
                            else
                            {
                                oComponent.CreateDate = Convert.ToDateTime(oItemRow.Cells[3].Value);//_dtCreateDate;
                                oComponent.CreateUserID = nCreateUserID;
                            }
                            oComponent.IsIndoorItem = _IsIndoorItem;
                            oComponent.ProductionType = _ProductionType;

                            oComponent.Status = 1;
                            oComponent.Remarks = "";

                            oComponent.AddComponentSerialUniversal(_nType, 86);//Utility.LocationID);
                            
                            //if (_IsFGSerial == 0 && _nType==1)
                            //{
                            //    oComponent.AddComponentSerialUniversal(_nType, 86);//Utility.LocationID);
                            //}
                            //else if(_nType == 2 && oComponent.ComponentID!=7)
                            //{
                            //    oComponent.AddComponentSerialUniversal(_nType, 86);//Utility.LocationID);
                            //}

                            if (_IsFGSerial == 1 && int.Parse(oItemRow.Cells[2].Value.ToString())==7)
                            {
                                oComponent.CreateDate = DateTime.Now;
                                oComponent.CreateUserID = Utility.UserId;
                                oComponent.LocationID = 86;//_LocationID;
                                oComponent.UpdateFGSerial(_IsFGSerial);
                            }
                            if (_IsFGSerial == 2 && int.Parse(oItemRow.Cells[2].Value.ToString()) == 7)
                            {
                                oComponent.CreateDate = _dtCreateDate;
                                oComponent.CreateUserID = nCreateUserID;
                                oComponent.LocationID = 86;//Utility.LocationID);
                                oComponent.UpdateFGSerial(_IsFGSerial);
                            }
                        }
                    }
                   

                    if (_ProductionType == 1)
                    {
                        
                    }
                    else if(_IsFGSerial==0)
                    {
                        PrintHeaderChecklist(nSetID);
                    }

                    DataTran oDataTran = new DataTran();
                    oDataTran.TableName = "t_ProductComponentSerialUniversal";
                    oDataTran.DataID = nSetID;
                    oDataTran.WarehouseID = 86;//Utility.LocationID;
                    oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                    oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                    oDataTran.BatchNo = 0;
                    if (oDataTran.CheckDataByLocationID() == false)
                    {
                        oDataTran.AddForFactory();
                    }


                    DBController.Instance.CommitTransaction();
                    txtCode.Text = "";
                    _IsTrue = true;
                    lblMessage.Visible = true;
                    lblMessage.Text = "Successfully Add Component Serial";
                    if (_nType == 2 && _IsFGSerial==0)
                    {
                        this.Close();
                    }

                    if (txtCode.Visible == true)
                    {
                        txtCode.Focus();
                    }
                    else
                    {
                        txtSerialNo.Text = "";
                        txtSerialNo.Focus();
                    }

                   
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
              
        //        _oProductComponents.RefreshComponent(txtCode.Text, nSetID, _ProductionType, _IsIndoorItem);
        //        doc.SetDataSource(_oProductComponents);
        //        doc.SetParameterValue("Product", txtName.Text);

        //        frmPrintPreview oForm = new frmPrintPreview();
        //        oForm.ShowDialog(doc);
        //    }
        //    else
        //    {
        //        ProductDetail oProductDetail = new ProductDetail();
        //        //oProductDetail.Refresh(ctlProduct1.SelectedSerarchProduct.ProductID);
        //        oProductDetail.Refresh(oSerarchProduct.ProductID);
                
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

        //            _oProductComponents.RefreshComponent(txtCode.Text, nSetID, _ProductionType, _IsIndoorItem);
        //            doc.SetDataSource(_oProductComponents);
        //            doc.SetParameterValue("Product", txtName.Text);

        //            frmPrintPreview oForm = new frmPrintPreview();
        //            oForm.ShowDialog(doc);
        //        }
        //        else if (sType == "AC")
        //        {
        //            rptProductComponentACNew doc = new rptProductComponentACNew();

        //            _oProductComponents.RefreshComponent(txtCode.Text, nSetID, _ProductionType, _IsIndoorItem);
        //            doc.SetDataSource(_oProductComponents);
        //            doc.SetParameterValue("Product", txtName.Text);

        //            frmPrintPreview oForm = new frmPrintPreview();
        //            oForm.ShowDialog(doc);
        //        }
        //        else
        //        {
        //            rptProductComponentNew doc = new rptProductComponentNew();

        //            _oProductComponents.RefreshComponent(txtCode.Text, nSetID, _ProductionType, _IsIndoorItem);
        //            doc.SetDataSource(_oProductComponents);
        //            doc.SetParameterValue("Product", txtName.Text);

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

                _oProductComponents.RefreshComponentFactoryPrint(txtCode.Text, nSetID, _ProductionType, _IsIndoorItem, 86);//Utility.LocationID);
                doc.SetDataSource(_oProductComponents);
                doc.SetParameterValue("Product", txtName.Text);

                doc.PrintToPrinter(1, true, 1, 1);
                //frmPrintPreview oForm = new frmPrintPreview();
                //oForm.ShowDialog(doc);
            }
            else
            {
                ProductDetail oProductDetail = new ProductDetail();
                oProductDetail.RefreshForFactory(oSerarchProduct.ProductID);
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

                    _oProductComponents.RefreshComponentFactoryPrint(txtCode.Text, nSetID, _ProductionType, _IsIndoorItem, 86);//Utility.LocationID);
                    doc.SetDataSource(_oProductComponents);
                    doc.SetParameterValue("Product", txtName.Text);

                    doc.PrintToPrinter(1, true, 1, 1);
                    //frmPrintPreview oForm = new frmPrintPreview();
                    //oForm.ShowDialog(doc);
                }
                else if (sType == "AC")
                {
                    //rptProductComponentACNewHeader doc = new rptProductComponentACNewHeader();
                    rptProductComponentACNew doc = new rptProductComponentACNew();

                    _oProductComponents.RefreshComponentFactoryPrint(txtCode.Text, nSetID, _ProductionType, _IsIndoorItem, 86);//Utility.LocationID);
                    doc.SetDataSource(_oProductComponents);
                    doc.SetParameterValue("Product", txtName.Text);
                    doc.PrintToPrinter(1, true, 1, 1);
                    //frmPrintPreview oForm = new frmPrintPreview();
                    //oForm.ShowDialog(doc);
                }
                else
                {
                    //rptProductComponentNewHeader doc = new rptProductComponentNewHeader();
                    rptProductComponentNew doc = new rptProductComponentNew();

                    _oProductComponents.RefreshComponentFactoryPrint(txtCode.Text, nSetID, _ProductionType, _IsIndoorItem, 86);//Utility.LocationID);
                    doc.SetDataSource(_oProductComponents);
                    doc.SetParameterValue("Product", txtName.Text);

                    doc.PrintToPrinter(1, true, 1, 1);

                    //frmPrintPreview oForm = new frmPrintPreview();
                    //oForm.ShowDialog(doc);
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

        private void txtCode_TextChanged(object sender, EventArgs e)
        {
            oSerarchProduct = new SerarchProduct();

            txtCode.ForeColor = System.Drawing.Color.Red;
            txtName.Text = "";
            if (txtCode.Text.Trim() == "")
            {
                return;
            }

            if (txtCode.Text.Length >= 1 && txtCode.Text.Length <= 25)
            {
                oSerarchProduct.ProductCode = txtCode.Text;

                DBController.Instance.OpenNewConnection();
                oSerarchProduct.RefreshByProductCodeFactory();

                if (oSerarchProduct.ProductName == null)
                {
                    oSerarchProduct = null;
                    AppLogger.LogFatal("There is no data.");
                    return;
                }
                else
                {
                    txtName.Text = oSerarchProduct.ProductName.ToString();
                    txtCode.SelectionStart = 0;
                    txtCode.SelectionLength = txtCode.Text.Length;
                    txtCode.ForeColor = System.Drawing.Color.Empty;
                }
            }
            if (ChangeSelection != null)
                ChangeSelection(this, e);
        }

        private void btnPicker_Click(object sender, EventArgs e)
        {
            oSerarchProductOld = new SerarchProduct();
            oSerarchProductOld = oSerarchProduct;

            oSerarchProduct = new SerarchProduct();
            CJ.Factory.frmProductSearch frmProductSearch = new CJ.Factory.frmProductSearch();
            frmProductSearch.ShowDialog(oSerarchProduct);

            if (oSerarchProduct.ProductCode != null)
            {
                string sCode = oSerarchProduct.ProductCode;
                txtCode.Text = "";
                txtCode.Text = sCode.ToString();
            }
            else
            {
                oSerarchProduct = oSerarchProductOld;
            }
        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (ChangeFocus != null)
            {
                ChangeFocus(sender, e);
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            int nCount = 0;
            nCount1 = 0;
            dgvComponent.Rows.Clear();

            if (txtName.Text.Trim() == "")
            {
                return;
            }

            if (txtName.Text != "")
            {
                lblMessage.Visible = false;
                dgvComponent.Focus();

                ProductComponents oComponents = new ProductComponents();
                if (_nType == 1)
                {
                    if (txtName.Text != "")
                    {
                        oComponents.RefreshComponentFactory(txtCode.Text, -1, _ProductionType, _IsIndoorItem, 86);//Utility.LocationID);
                    }
                }
                else
                {
                    oComponents.RefreshComponentFactory(txtCode.Text, _SetID, _ProductionType, _IsIndoorItem, 86);//_LocationID);
                }
                dgvComponent.Rows.Clear();

                DataGridViewRow oRow;
                if (_IsFGSerial == 0)
                {
                    foreach (ProductComponent oProductComponent in oComponents)
                    {
                        if (oProductComponent.ComponentID == 7)
                        {
                            oRow = new DataGridViewRow();
                            oRow.CreateCells(dgvComponent);
                            oRow.Cells[0].Value = oProductComponent.ComponentName.ToString();
                            oRow.Cells[1].Value = oProductComponent.ProductSerial.ToString();
                            oRow.Cells[2].Value = oProductComponent.ComponentID.ToString();
                            oRow.Cells[3].Value = oProductComponent.CreateDate.ToString();
                            dgvComponent.Rows.Add(oRow);

                            //oRow.Cells[1].ReadOnly = true;
                            //oRow.Cells[1].Style.BackColor = Color.Gray;

                            oRow.Visible = false;
                        }
                        else
                        {
                            oRow = new DataGridViewRow();
                            oRow.CreateCells(dgvComponent);
                            oRow.Cells[0].Value = oProductComponent.ComponentName.ToString();
                            oRow.Cells[1].Value = oProductComponent.ProductSerial.ToString();
                            oRow.Cells[2].Value = oProductComponent.ComponentID.ToString();
                            oRow.Cells[3].Value = oProductComponent.CreateDate.ToString();
                            dgvComponent.Rows.Add(oRow);
                        }

                    }
                }
                else
                {
                    foreach (ProductComponent oProductComponent in oComponents)
                    {
                        if (oProductComponent.ComponentID == 7)
                        {
                            oRow = new DataGridViewRow();
                            oRow.CreateCells(dgvComponent);
                            oRow.Cells[0].Value = oProductComponent.ComponentName.ToString();
                            oRow.Cells[1].Value = oProductComponent.ProductSerial.ToString();
                            oRow.Cells[2].Value = oProductComponent.ComponentID.ToString();
                            oRow.Cells[3].Value = oProductComponent.CreateDate.ToString();
                            dgvComponent.Rows.Add(oRow);
                            
                            oRow.Cells[1].ReadOnly = false;
                            oRow.Cells[1].Style.BackColor = Color.White;
                            nCount1 = nCount;

                            if(oRow.Cells[1].Value.ToString()=="")
                            {
                                btnSave.Enabled = false;
                            }

                        }
                        else
                        {
                            oRow = new DataGridViewRow();
                            oRow.CreateCells(dgvComponent);
                            oRow.Cells[0].Value = oProductComponent.ComponentName.ToString();
                            oRow.Cells[1].Value = oProductComponent.ProductSerial.ToString();
                            oRow.Cells[2].Value = oProductComponent.ComponentID.ToString();
                            oRow.Cells[3].Value = oProductComponent.CreateDate.ToString();
                            dgvComponent.Rows.Add(oRow);


                            oRow.Cells[1].ReadOnly = true;
                            oRow.Cells[1].Style.BackColor = Color.Gray;
                        }

                        nCount++;
                    }
                }

                if (oComponents.Count > 0)
                {
                    DataGridViewCell cell = dgvComponent.Rows[0].Cells[1];
                    dgvComponent.CurrentCell = cell;
                    dgvComponent.BeginEdit(true);
                }

                if (nCount1 > 0 && _IsFGSerial > 0)
                {
                    dgvComponent.CurrentCell = dgvComponent.Rows[nCount1].Cells[1];
                    dgvComponent.BeginEdit(true);

                    if (_IsFGSerial == 2 && dgvComponent.Rows[nCount1].Cells[1].Value.ToString() != "")
                    {
                        btnSave.Enabled = true;
                    }
                    else if (_IsFGSerial == 1 && dgvComponent.Rows[nCount1].Cells[1].Value.ToString() == "")
                    {
                        btnSave.Enabled = true;
                    }
                }
            }

        }

      

        private void frmProductComponentUniversal_Load(object sender, EventArgs e)
        {
            
        }

       

        private void txtSerialNo_TextChanged(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            if(txtSerialNo.Text.Trim()=="")
            {
                return;
            }

            dgvComponent.Rows.Clear();
            int nID;
            //lblMessage.Visible = false;
            //dgvComponent.Focus();
            ProductComponents oComponents = new ProductComponents();
            nID = oComponents.RefreshForProductComponentUniversal(txtSerialNo.Text.Trim());
            if (nID == 0)
            {

            }
            else
            {
                oComponents.GetProductComponentUniversalFactory(DateTime.Today, DateTime.Today, -1, -1, -1, -1, -1, -1, txtSerialNo.Text.Trim(), "", true, -1, 2,-1,-1);


                int nDefID = 0;
                ProductComponent oComponent = new ProductComponent();
                nDefID = oComponent.GetDefectiveSetID(oComponents[0].SetID);
                if (nDefID != 0)
                {
                    MessageBox.Show("Defective Declared, Please Repair First", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _SetID = oComponents[0].SetID;
                _LocationID = oComponents[0].LocationID;
                _IsIndoorItem = oComponents[0].IsIndoorItem;
                _dtCreateDate = oComponents[0].CreateDate;
                nCreateUserID = oComponents[0].CreateUserID;
                txtCode.Text = oComponents[0].ProductCode;
            }
        }

        private void dgvComponent_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string sFGSerial = "";
            try
            {
                sFGSerial = dgvComponent.Rows[nCount1].Cells[1].Value.ToString();
            }
            catch
            {
                sFGSerial = "";
            }
            if(sFGSerial != "" && _nType == 2 && _IsFGSerial == 1)
            {
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

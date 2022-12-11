using CJ.Class;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CJ.Win.Promotion
{
    public partial class frmPromoWarrantyAdd : Form
    {
        string sProductID = "";
        int frmType;
        int warrantyId;
        PromoWarranty oPromoWarranty;
        public frmPromoWarrantyAdd()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
        public frmPromoWarrantyAdd(int type, int warrantyId)
        {
            InitializeComponent();
            this.CenterToScreen();
            frmType = type;
            LoadUIData(warrantyId);
            switch (frmType)
            {
                case (int)Dictionary.PromoWarrantyFormType.Approved:
                    //Do
                    btnSave.Text = "Approve";
                    break; 
                case (int)Dictionary.PromoWarrantyFormType.Inactive:
                    //Do
                    btnSave.Text = "Inactive";
                    break;
                case (int)Dictionary.PromoWarrantyFormType.Edit:
                    btnSave.Text = "Edit";
                    //Do
                    break;
                default:
                    // Do nothing
                    break;
            }
        }
        private void SelectProducts_Click(object sender, EventArgs e)
        {
            
            frmSearchProduct oForm = new frmSearchProduct(2);
            oForm.ShowDialog();
            //var item = oForm._oProductDetails;
            if (oForm._oProductDetails != null)
            {
                foreach (ProductDetail item in oForm._oProductDetails)
                {
                    addProductToList(item);
                }
            }
            else if (oForm._oProductDetail != null)
            {
                addProductToList(oForm._oProductDetail);
            }
        }
        private void addProductToList(ProductDetail item)
        {
            int nRowIndex = 0;
            if (item != null)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvProducts);
                oRow.Cells[0].Value = item.ProductCode;
                oRow.Cells[2].Value = item.ProductName;
                oRow.Cells[3].Value = item.ProductID;
                if (item.ProductCode != null)
                {
                    nRowIndex = dgvProducts.Rows.Add(oRow);
                    if (checkDuplicateLineItem(dgvProducts.Rows[nRowIndex].Cells[0].Value.ToString()) > 1)
                    {
                        oRow.Cells[2].Value = "";
                        MessageBox.Show("Duplicate Product Code.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dgvProducts.Rows.RemoveAt(nRowIndex);
                        return;
                    }
                    else
                    {
                        dgvProducts.Rows[nRowIndex].Cells[0].ReadOnly = true;                        
                    }
                }
            }
        }
        private void frmPromoWarrantyAdd_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            switch (frmType)
            {
                case (int)Dictionary.PromoWarrantyFormType.Approved:

                    DialogResult dialogResult = MessageBox.Show("Are you Sure?", "Approve Promo Warranty", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        // Set cursor as hourglass
                        Cursor.Current = Cursors.WaitCursor;
                        DBController.Instance.BeginNewTransaction();
                        //approve the data
                        oPromoWarranty = GetUIData(oPromoWarranty, (int)Dictionary.PromoWarrantyFormType.Approved);
                        oPromoWarranty.Status = (int)Dictionary.PromoWarrantyStatus.Approved;
                        oPromoWarranty.Edit();
                        //sync data to WareHouse
                        //oExhangeOffers.GetTPWarehouse();

                        Class.Promotion.SPWarehouses oShowrooms = new Class.Promotion.SPWarehouses();
                        oShowrooms.GetWarehouse();
                        foreach (Class.Promotion.SPWarehouse oShowroom in oShowrooms)
                        {
                            CJ.Class.POS.DataTran oDataTran = new CJ.Class.POS.DataTran();
                            oDataTran.TableName = "t_PromoWarranty";
                            oDataTran.DataID = oPromoWarranty.WarrantyId;
                            oDataTran.WarehouseID = oShowroom.WarehouseID;
                            oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                            oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                            oDataTran.BatchNo = 0;
                            if (oDataTran.CheckDataByWHID() == false)
                            {
                                oDataTran.AddForTDPOS();
                            }
                        }

                        DBController.Instance.CommitTransaction();
                        // Set cursor as default arrowf
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("You have successfully approved the Promo Warranty", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        //do something else

                    }

                    break;
                case (int)Dictionary.PromoWarrantyFormType.Inactive:

                    DialogResult dialogInactive = MessageBox.Show("Are you Sure?", "inactivate promo Warranty", MessageBoxButtons.YesNo);
                    if (dialogInactive == DialogResult.Yes)
                    {
                        // Set cursor as hourglass
                        Cursor.Current = Cursors.WaitCursor;
                        DBController.Instance.BeginNewTransaction();
                        //approve the data
                        oPromoWarranty = GetUIData(oPromoWarranty, (int)Dictionary.PromoWarrantyFormType.Inactive);
                        oPromoWarranty.IsActive = false;
                        oPromoWarranty.Edit();
                        Class.Promotion.SPWarehouses oShowrooms = new Class.Promotion.SPWarehouses();
                        oShowrooms.GetWarehouse();
                        foreach (Class.Promotion.SPWarehouse oShowroom in oShowrooms)
                        {
                            CJ.Class.POS.DataTran oDataTran = new CJ.Class.POS.DataTran();
                            oDataTran.TableName = "t_PromoWarranty";
                            oDataTran.DataID = oPromoWarranty.WarrantyId;
                            oDataTran.WarehouseID = oShowroom.WarehouseID;
                            oDataTran.TransferType = (int)Dictionary.DataTransferType.Edit;
                            oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                            oDataTran.BatchNo = 0;
                            if (oDataTran.CheckDataByWHID() == false)
                            {
                                oDataTran.AddForTDPOS();
                            }
                        }
                        DBController.Instance.CommitTransaction();
                        // Set cursor as default arrow
                        Cursor.Current = Cursors.Default;
                        this.Close();
                    }
                    else if (dialogInactive == DialogResult.No)
                    {
                        //do something else
                    }
                    break;
                case (int)Dictionary.PromoWarrantyFormType.Edit:
                    //Do
                    if (UIValidation())
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        oPromoWarranty = GetUIData(oPromoWarranty,(int)Dictionary.PromoWarrantyFormType.Edit);
                        oPromoWarranty.Edit();
                        Cursor.Current = Cursors.Default;
                        this.Close();
                        MessageBox.Show("successfully Updated.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
                default:
                    if (UIValidation())
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        oPromoWarranty = new PromoWarranty();
                        oPromoWarranty = GetUIData(oPromoWarranty,0);
                        oPromoWarranty.Add();
                        Cursor.Current = Cursors.Default;
                        this.Close();
                        MessageBox.Show("successfully saved.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    break;
            }
        }
        public bool UIValidation()
        {
            if (string.IsNullOrWhiteSpace(tDescription.Text))
            {
                MessageBox.Show("Please enter Description!", "Validation error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tDescription.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtExchangeWarranty.Text))
            {
                MessageBox.Show("Please enter Exchange Warranty!", "Validation error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtExchangeWarranty.Focus();
                return false;
            }
            if (dateTimefrom.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Effect from Date can not be less then today", "Validation error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimefrom.Focus();
                return false;
            }
            if (dateTimeTo.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Effect to date can not be less then today", "Validation error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateTimeTo.Focus();
                return false;
            }
            if (dgvProducts.Rows.Count <= 1 || dgvProducts.Rows == null)
            {
                MessageBox.Show("Please select a product!", "Validation error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgvProducts.Focus();
                return false;
            }
            return true;
        }
        public PromoWarranty GetUIData(PromoWarranty oPromoWarranty, int type)
        {
            //oPromoWarranty.WarrantyId = "";
            oPromoWarranty.Description = tDescription.Text;
            oPromoWarranty.ExtendedWarranty = txtExchangeWarranty.Text;
            oPromoWarranty.FromDate = dateTimefrom.Value.Date;
            oPromoWarranty.ToDate = dateTimeTo.Value.Date;
            if (type ==0)
            {
                oPromoWarranty.Status = (int)Dictionary.PromoWarrantyStatus.Create;
                oPromoWarranty.IsActive = true;
            }
            oPromoWarranty.CreateUserId = Utility.UserId;
            oPromoWarranty.CreateDate = DateTime.Now;
            oPromoWarranty.UpdateDate = DateTime.Now;
            oPromoWarranty.ApproveDate = DateTime.Now;
            foreach (DataGridViewRow item in dgvProducts.Rows)
            {
                PromoWarrantyDetail detail = new PromoWarrantyDetail();
                if (item.Cells[3].Value !=null)
                {
                    detail.ProductId = Convert.ToInt32(item.Cells[3].Value);
                    detail.WarrantyId = oPromoWarranty.WarrantyId;
                    oPromoWarranty.Add(detail);
                }
                

            }
            return oPromoWarranty;
        }

        public void LoadUIData(int warrantyId)
        {
            oPromoWarranty = new PromoWarranty();
            oPromoWarranty.WarrantyId = warrantyId;
            oPromoWarranty.Refresh();
            tDescription.Text = oPromoWarranty.Description;
            txtExchangeWarranty.Text = oPromoWarranty.ExtendedWarranty;
            dateTimefrom.Value = oPromoWarranty.FromDate;
            dateTimeTo.Value = oPromoWarranty.ToDate;
            oPromoWarranty.GetDetails(warrantyId);
            //var tempPromoWarranty = new PromoWarranty();
            //tempPromoWarranty = oPromoWarranty;
            List<PromoWarrantyDetail> detailList = new List<PromoWarrantyDetail>();
            foreach (PromoWarrantyDetail detail in oPromoWarranty)
            {
                ProductDetail product = new ProductDetail();
                product.ProductID = detail.ProductId;
                product.Refresh();
                //tempPromoWarranty.remove(detail);
                addProductToList(product);
                detailList.Add(detail);
            }
            foreach (PromoWarrantyDetail item in detailList)
            {
                oPromoWarranty.remove(item);
            }
            
        }

        private void dgvProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int nRowIndex = 0;
            if (e.ColumnIndex == 1)
            {
                frmSearchProduct oForm = new frmSearchProduct(1);
                oForm.ShowDialog();
                if (oForm._oProductDetail != null)
                {
                    addProductToList(oForm._oProductDetail);
                }

            }
        }
        private int checkDuplicateLineItem(string ItemCode)
        {
            int ItemCounter = 0;
            foreach (DataGridViewRow oItemRow in dgvProducts.Rows)
            {
                if (oItemRow.Index < dgvProducts.Rows.Count - 1)
                {
                    if (oItemRow.Cells[0].Value == null)
                    {
                        continue;
                    }
                    if (oItemRow.Cells[0].Value.ToString().Trim() == ItemCode)
                    {
                        ItemCounter++;
                    }
                }
            }
            return ItemCounter;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

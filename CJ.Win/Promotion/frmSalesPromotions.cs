using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Class.Promotion;
using CJ.Report.POS;
using CJ.Report;
using CJ.Class.POS;

namespace CJ.Win.Promotion
{
    public partial class frmSalesPromotions : Form
    {
        SPromotions oSPromotions;
        ProductDetail _oProductDetail;
        int _nUIControl = 0;
        public frmSalesPromotions(int nUIControl)
        {
            InitializeComponent();
            _nUIControl = nUIControl;
        }
        private void frmSalesPromotions_Load(object sender, EventArgs e)
        {
            LoadData();
            if (_nUIControl == 1)
            {
                btnCentral.Visible = false;
                btnAdd.Visible = true;
                btnCorporate.Visible = false;
                btnEditCentral.Visible = false;
            }
            else if (_nUIControl == 2)
            {
                btnCentral.Visible = false;
                btnAdd.Visible = false;
                btnCorporate.Visible = true;
                btnEdit.Visible = false;
                btnEditCentral.Visible = false;
            }
            else 
            {
                btnCentral.Visible = true;
                btnAdd.Visible = false;
                btnCorporate.Visible = false;
                btnEdit.Visible = false;
                btDelete.Visible = false;
                btnEditCentral.Visible = true;
            }
        }
        public void LoadData()
        {
            DBController.Instance.OpenNewConnection();
            oSPromotions = new SPromotions();
            oSPromotions.Refresh(dtFromDate.Value.Date, dtToDate.Value.Date);

            lvwPromotionList.Items.Clear();

            foreach (SPromotion oSPromotion in oSPromotions)
            {
                ListViewItem lstItem = lvwPromotionList.Items.Add(oSPromotion.SalesPromotionNo.ToString());
                lstItem.SubItems.Add(oSPromotion.SalesPromotionName);
                lstItem.SubItems.Add((Convert.ToDateTime(oSPromotion.FromDate)).ToString("dd-MMM-yyyy"));
                lstItem.SubItems.Add((Convert.ToDateTime(oSPromotion.ToDate)).ToString("dd-MMM-yyyy"));
                if (oSPromotion.IsActive == (int)Dictionary.YesOrNoStatus.YES)
                {
                    lstItem.SubItems.Add("Active");
                }
                else
                {
                    lstItem.SubItems.Add("In Active");
                }

                lstItem.Tag = oSPromotion;
            }

        }
        private void btnGo_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmSalesPromotion ofrmSalesPromotion = new frmSalesPromotion();
            ofrmSalesPromotion.ShowDialog();
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwPromotionList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SPromotion oSPromotion = (SPromotion)lvwPromotionList.SelectedItems[0].Tag;

            frmSalesPromoModify oForm = new frmSalesPromoModify();
            oForm.ShowDialog(oSPromotion);
            LoadData();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (lvwPromotionList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SPromotion oSPromotion = (SPromotion)lvwPromotionList.SelectedItems[0].Tag;

            DataTran oDataTran = new DataTran();
            oDataTran.TableName = "t_SalesPromo";
            oDataTran.DataID = oSPromotion.SalesPromotionID;
            oDataTran.IsDownload = (int)Dictionary.IsDownload.Yes;
            if (oDataTran.CheckData())
            {
                MessageBox.Show("Promotion already downloaded by Branch \nYou couldn't delete", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult oResult = MessageBox.Show("Are you sure you want to delete The Promotion: " + oSPromotion.SalesPromotionNo + " ? ", "Confirm Ticket Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (oResult == DialogResult.Yes)
            {
                oSPromotion.RefreshSlab();

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oSPromotion.Delete();
                    DBController.Instance.CommitTransaction();
                    MessageBox.Show("You Have Successfully Delete The Promotion", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }
        }

        private void btPrint_Click(object sender, EventArgs e)
        {
            if (lvwPromotionList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string sPromotionProduct = "";
            string sChannel = "";
            string sWarehouse="";
            string sRatio = "";
            string sFreeProduct = "";
            string sSlabs = "";

            SPromotion oSPromotion = (SPromotion)lvwPromotionList.SelectedItems[0].Tag;
            oSPromotion.RefreshSlab();

            try
            {
                rptSalesPromotion  doc;
                doc = new rptSalesPromotion();

                doc.SetParameterValue("PromotionNo", oSPromotion.SalesPromotionNo);
                doc.SetParameterValue("Description", oSPromotion.SalesPromotionName);
                doc.SetParameterValue("StartDate", oSPromotion.FromDate);
                doc.SetParameterValue("EndDate", oSPromotion.ToDate);

                foreach (SPProduct oSPProduct in oSPromotion.SPProducts)
                {
                    _oProductDetail = new ProductDetail();
                    _oProductDetail.ProductID = oSPProduct.ProductID;
                    _oProductDetail.Refresh();

                    if (sPromotionProduct == "")
                    {
                        sPromotionProduct = "[" + _oProductDetail.ProductCode + "]" + _oProductDetail.ProductName;
                    }
                    else sPromotionProduct = sPromotionProduct + "," + "[" + _oProductDetail.ProductCode + "]" + _oProductDetail.ProductName;
                }
                doc.SetParameterValue("PromotionProduct", sPromotionProduct);
             
                foreach (SPChannel oSPChannel in oSPromotion.SPChannels)
                {
                    Channel _oChannel = new Channel();
                    _oChannel.ChannelID = oSPChannel.ChannelID;
                    _oChannel.Refresh();
                    if (sChannel == "")
                        sChannel = _oChannel.ChannelDescription;
                    else sChannel = sChannel + "," + _oChannel.ChannelDescription;

                }
                doc.SetParameterValue("Channel", sChannel);

                foreach (SPWarehouse oSPWarehouse in oSPromotion.SPWarehouses)
                {
                    Warehouse _oWarehouse = new Warehouse();
                    _oWarehouse.WarehouseID = oSPWarehouse.WarehouseID;
                    _oWarehouse.Reresh();

                    if (sWarehouse == "")
                        sWarehouse = _oWarehouse.WarehouseName;
                    else sWarehouse = sWarehouse + "," + _oWarehouse.WarehouseName;
                }

                doc.SetParameterValue("Outlets", sWarehouse);

                foreach (SalesPromotionSlab oSalesPromotionSlab in oSPromotion)
                {
                    if (sSlabs == "")
                    {
                        sSlabs = "Slab No: " + oSalesPromotionSlab.SlabNo + "\n";                    

                        sRatio = "";
                        sFreeProduct = "";

                        foreach (SPSlabRatio oSPSlabRatio in oSalesPromotionSlab.SPSlabAllRatio)
                        {
                            if (sRatio == "")
                            {
                                sRatio = oSPSlabRatio.Qty.ToString();
                            }
                            else
                            {
                                sRatio = sRatio + ":" + oSPSlabRatio.Qty.ToString();
                            }
                        }
                        if (oSalesPromotionSlab.DiscountType == (int)Dictionary.SalesPromSlabDiscountType.None)
                        {
                            sSlabs = sSlabs + "--- " + "Slab Ratio: " + "Not Set" + "\n";
                        }
                        else if (oSalesPromotionSlab.DiscountType == (int)Dictionary.SalesPromSlabDiscountType.FlatAmount)
                        {
                            sSlabs = sSlabs + "--- " + "Slab Ratio: " + Dictionary.SalesPromSlabDiscountType.FlatAmount + "\n";
                        }
                        else
                        {
                            sSlabs = sSlabs + "--- " + "Slab Ratio: " + Dictionary.SalesPromSlabDiscountType.Parcent + "\n";
                        }

                        if (oSalesPromotionSlab.SPDiscountSlab.DiscountAmount > 0)
                            sSlabs = sSlabs + "--- " + "Discount : " + oSalesPromotionSlab.SPDiscountSlab.DiscountAmount.ToString() + "%" + "\n";

                        if (oSalesPromotionSlab.SPFlatSlab.FlatAmount != 0)
                            sSlabs = sSlabs + "--- " + "Flat Discount: " + oSalesPromotionSlab.SPFlatSlab.FlatAmount.ToString() + "\n";
                        if (oSalesPromotionSlab.SPFreeProducts.Count > 0)
                        {
                            foreach (SPFreeProduct oSPFreeProduct in oSalesPromotionSlab.SPFreeProducts)
                            {
                                _oProductDetail = new ProductDetail();
                                _oProductDetail.ProductID = oSPFreeProduct.ProductID;
                                _oProductDetail.Refresh();
                                if (sFreeProduct == "")
                                    sFreeProduct = "[" + _oProductDetail.ProductCode + "]" + _oProductDetail.ProductName;
                                else sFreeProduct = sFreeProduct + "," + "[" + _oProductDetail.ProductCode + "]" + _oProductDetail.ProductName;

                            }
                            sSlabs = sSlabs + "--- " + "Free Product: " + sFreeProduct + "\n";
                        }

                    }
                    else
                    {
                        sSlabs = sSlabs + "\n\n";
                        sSlabs = "Slab No: " + oSalesPromotionSlab.SlabNo + "\n";

                        sRatio = "";
                        sFreeProduct = "";

                        foreach (SPSlabRatio oSPSlabRatio in oSalesPromotionSlab.SPSlabAllRatio)
                        {
                            if (sRatio == "")
                            {
                                sRatio = oSPSlabRatio.Qty.ToString();
                            }
                            else
                            {
                                sRatio = sRatio + ":" + oSPSlabRatio.Qty.ToString();
                            }
                        }
                        if (oSalesPromotionSlab.DiscountType == (int)Dictionary.SalesPromSlabDiscountType.None)
                        {
                            sSlabs = sSlabs + "--- " + "Slab Ratio: " + "Not Set" + "\n";
                        }
                        else if (oSalesPromotionSlab.DiscountType == (int)Dictionary.SalesPromSlabDiscountType.FlatAmount)
                        {
                            sSlabs = sSlabs + "--- " + "Slab Ratio: " + Dictionary.SalesPromSlabDiscountType.FlatAmount + "\n";
                        }
                        else
                        {
                            sSlabs = sSlabs + "--- " + "Slab Ratio: " + Dictionary.SalesPromSlabDiscountType.Parcent + "\n";
                        }

                        if (oSalesPromotionSlab.SPDiscountSlab.DiscountAmount > 0)
                            sSlabs = sSlabs + "--- " + "Discount : " + oSalesPromotionSlab.SPDiscountSlab.DiscountAmount.ToString() + "%" + "\n";

                        if (oSalesPromotionSlab.SPFlatSlab.FlatAmount != 0)
                            sSlabs = sSlabs + "--- " + "Flat Discount: " + oSalesPromotionSlab.SPFlatSlab.FlatAmount.ToString() + "\n";
                        if (oSalesPromotionSlab.SPFreeProducts.Count > 0)
                        {
                            foreach (SPFreeProduct oSPFreeProduct in oSalesPromotionSlab.SPFreeProducts)
                            {
                                _oProductDetail = new ProductDetail();
                                _oProductDetail.ProductID = oSPFreeProduct.ProductID;
                                _oProductDetail.Refresh();
                                if (sFreeProduct == "")
                                    sFreeProduct = "[" + _oProductDetail.ProductCode + "]" + _oProductDetail.ProductName;
                                else sFreeProduct = sFreeProduct + "," + "[" + _oProductDetail.ProductCode + "]" + _oProductDetail.ProductName;

                            }
                            sSlabs = sSlabs + "--- " + "Free Product: " + sFreeProduct + "\n";
                        }
                    }
                }
                doc.SetParameterValue("Slabs", sSlabs);

                frmPrintPreview frmView;
                frmView = new frmPrintPreview();
                frmView.ShowDialog(doc);
            }
            catch (Exception ex)
            {              
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }

        private void btnCorporate_Click(object sender, EventArgs e)
        {
            frmSalesPromo oform = new frmSalesPromo();
            oform.ShowDialog();
            LoadData();
        }

        private void btnCentral_Click(object sender, EventArgs e)
        {
            frmSalesPromotionCentral oform = new frmSalesPromotionCentral();
            oform.ShowDialog();
            LoadData();
        }

        private void btnEditCentral_Click(object sender, EventArgs e)
        {
            if (lvwPromotionList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SPromotion oSPromotion = (SPromotion)lvwPromotionList.SelectedItems[0].Tag;

            frmSalesPromotionCentral oForm = new frmSalesPromotionCentral();
            oForm.ShowDialog(oSPromotion);
            LoadData();
        }

    }
}
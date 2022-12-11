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
using CJ.Class.Admin;
using CJ.Class.Promotion;

namespace CJ.Win.Promotion
{
    public partial class frmEditPromotion : Form
    {
        public bool _bActionSave = false;

        SPromotion oSPromotion;
        ConsumerPromotion oConsumerPromotion;
        ProductDetail _oProductDetail;
        ProductGroup _oProductGroup;
        Brand _oBrand;
        ConsumerPromotionProductFors _oConsumerPromotionProductFors;
        public frmEditPromotion()
        {
            InitializeComponent();
        }

        public void ShowDialog(ConsumerPromotion oConsumerPromotion)
        {
            this.Tag = oConsumerPromotion;
            txtPromoNo.Text = oConsumerPromotion.ConsumerPromoNo.ToString();
            txtPromoName.Text = oConsumerPromotion.ConsumerPromoName.ToString();
            dtFromDate.Value = oConsumerPromotion.FromDate;
            dtToDate.Value = oConsumerPromotion.ToDate;
            if (oConsumerPromotion.IsActive == (int)Dictionary.YesOrNoStatus.YES)
            {
                chkIsActive.Checked = true;
            }
            else
            {
                chkIsActive.Checked = false;
            }

            txtPromoNo.Enabled = false;
            dtFromDate.Enabled = false;
            if (oConsumerPromotion.PromotionTypeName == "CP")
            {
                EditLineItems(oConsumerPromotion.ConsumerPromoID);
                dgvLineItems.Visible = true;
                dgvLineItems1.Visible = false;
            }
            else
            {
                EditLineItems1(oConsumerPromotion.ConsumerPromoID);
                dgvLineItems1.Visible = true;
                dgvLineItems.Visible = false;
            }

            this.ShowDialog();
        }

        int _nCount = 0;

        private void EditLineItems(int nConsumerPromoID)
        {
            ConsumerPromotionProductFors oConsumerPromotionProductFors = new ConsumerPromotionProductFors();
            oConsumerPromotionProductFors.Refresh(nConsumerPromoID, "t_PromoCP");

            foreach (ConsumerPromotionProductFor oLineItem in oConsumerPromotionProductFors)
            {
                _oProductDetail = new ProductDetail();
                _oProductDetail.ProductID = oLineItem.ProductID;
                _oProductDetail.Refresh();

                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLineItems);

                //oRow.Cells[0].Value = i + 1;
                oRow.Cells[0].Value = _oProductDetail.ProductCode;
                oRow.Cells[2].Value = _oProductDetail.ProductName;
                oRow.Cells[3].Value = oLineItem.ProductID;
                oRow.Cells[4].Value = oLineItem.TGTQty;
                oRow.Cells[5].Value = oLineItem.TargetValue;
                oRow.Cells[6].Value = oLineItem.PromoCostVal;
                oRow.Cells[7].Value = oLineItem.NetSalesVal;
                oRow.Cells[8].Value = oLineItem.RegularSalesQty;
                oRow.Cells[9].Value = oLineItem.DiscountRatio;
                oRow.Cells[10].Value = oLineItem.GroupTypeID;


                dgvLineItems.Rows.Add(oRow);

            }
        }

        private void EditLineItems1(int nConsumerPromoID)
        {
            ConsumerPromotionProductFors oConsumerPromotionProductFors = new ConsumerPromotionProductFors();
            oConsumerPromotionProductFors.Refresh(nConsumerPromoID, "t_PromoTP");

            foreach (ConsumerPromotionProductFor oLineItem in oConsumerPromotionProductFors)
            {
                _oProductGroup = new ProductGroup();
                _oProductGroup.PdtGroupID = oLineItem.ProductGroupID;
                _oProductGroup.Refresh();

                _oBrand = new Brand();
                _oBrand.BrandID = oLineItem.BrandID;
                _oBrand.Refresh();

                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvLineItems1);

                oRow.Cells[0].Value = _oProductGroup.PdtGroupName;
                oRow.Cells[1].Value = _oBrand.BrandDesc;
                oRow.Cells[2].Value = oLineItem.TGTQty;
                oRow.Cells[3].Value = oLineItem.TargetValue;
                oRow.Cells[4].Value = oLineItem.PromoCostVal;
                oRow.Cells[5].Value = oLineItem.NetSalesVal;
                oRow.Cells[6].Value = oLineItem.RegularSalesQty;
                oRow.Cells[7].Value = oLineItem.ProductGroupID;
                oRow.Cells[8].Value = oLineItem.BrandID;
                oRow.Cells[9].Value = (int)Dictionary.ConsumerPromotionProductGroupType.MAG;
                oRow.Cells[10].Value = oLineItem.ApplicableProductID;
                oRow.Cells[11].Value = oLineItem.IsApplicableOnAllSKU;//(int)Dictionary.YesOrNoStatus.YES;
               
                
                dgvLineItems1.Rows.Add(oRow);

            }
        }



        private void frmEditPromotion_Load(object sender, EventArgs e)
        {

        }

        private bool validateUIInput()
        {
            #region Input Information Validation

            if (txtPromoName.Text == "")
            {
                MessageBox.Show("Please enter promo name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPromoName.Focus();
                return false;
            }
            if (dtToDate.Value.Date < DateTime.Today.Date)
            {
                MessageBox.Show("Can't update backward date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtFromDate.Focus();
                return false;
            }

           #endregion

            return true;
        }


        private void Save()
        {
            ConsumerPromotion oConsumerPromotion = (ConsumerPromotion)this.Tag;

            oConsumerPromotion.ConsumerPromoName = txtPromoName.Text;

            oConsumerPromotion.FromDate = dtFromDate.Value.Date;
            oConsumerPromotion.ToDate = dtToDate.Value.Date;

            if (chkIsActive.Checked)
            {
                oConsumerPromotion.IsActive = (int)Dictionary.YesOrNoStatus.YES;
            }
            else
            {
                oConsumerPromotion.IsActive = (int)Dictionary.YesOrNoStatus.NO;
            }

            oConsumerPromotion.CreateUserID = Utility.UserId;
            oConsumerPromotion.CreateDate = DateTime.Now.Date;
            oConsumerPromotion.UpdateUserID = Utility.UserId;
            oConsumerPromotion.UpdateDate = DateTime.Now.Date;

            try
            {
                DBController.Instance.BeginNewTransaction();
                string sTableName = "";
                if (oConsumerPromotion.PromotionTypeName == "CP")
                {
                    oConsumerPromotion.UpdatePromoCP();
                    sTableName = "t_PromoCP";



                    foreach (DataGridViewRow oItemRow in dgvLineItems.Rows)
                    {
                        if (oItemRow.Index < dgvLineItems.Rows.Count)
                        {
                            ConsumerPromotionProductFor oConsumerPromotionProductFor = new ConsumerPromotionProductFor();
                            oConsumerPromotionProductFor.ConsumerPromoID = oConsumerPromotion.ConsumerPromoID;
                            oConsumerPromotionProductFor.GroupTypeID = int.Parse(oItemRow.Cells[10].Value.ToString());

                            oConsumerPromotionProductFor.ProductID = int.Parse(oItemRow.Cells[3].Value.ToString());

                            try
                            {
                                oConsumerPromotionProductFor.TGTQty = int.Parse(oItemRow.Cells[4].Value.ToString());
                            }
                            catch
                            {
                                oConsumerPromotionProductFor.TGTQty = 0;
                            }


                            /////////////////////////////////////
                            try
                            {
                                oConsumerPromotionProductFor.TargetValue = Convert.ToDouble(oItemRow.Cells[5].Value.ToString());
                            }
                            catch
                            {
                                oConsumerPromotionProductFor.TargetValue = 0;
                            }

                            try
                            {
                                oConsumerPromotionProductFor.PromoCostVal = Convert.ToDouble(oItemRow.Cells[6].Value.ToString());
                            }
                            catch
                            {
                                oConsumerPromotionProductFor.PromoCostVal = 0;
                            }
                            try
                            {
                                oConsumerPromotionProductFor.NetSalesVal = Convert.ToDouble(oItemRow.Cells[7].Value.ToString());
                            }
                            catch
                            {
                                oConsumerPromotionProductFor.NetSalesVal = 0;
                            }
                            /////////////////////////////////////////////

                            try
                            {
                                oConsumerPromotionProductFor.RegularSalesQty = int.Parse(oItemRow.Cells[8].Value.ToString());
                            }
                            catch
                            {
                                oConsumerPromotionProductFor.RegularSalesQty = 0;
                            }
                            try
                            {
                                oConsumerPromotionProductFor.DiscountRatio = Convert.ToDouble(oItemRow.Cells[9].Value.ToString());
                            }
                            catch
                            {
                                oConsumerPromotionProductFor.DiscountRatio = 0;
                            }

                            if (oConsumerPromotion.PromotionTypeName == "CP")
                            {
                                oConsumerPromotionProductFor.UpdateCP();
                            }
                            else
                            {
                                oConsumerPromotionProductFor.UpdateTP();
                            }
                        }
                    }
                }

                else
                {
                    oConsumerPromotion.UpdatePromoTP();
                    sTableName = "t_PromoTP";
                    

                    foreach (DataGridViewRow oItemRow in dgvLineItems1.Rows)
                    {
                        if (oItemRow.Index < dgvLineItems1.Rows.Count)
                        {
                            ConsumerPromotionProductFor oConsumerPromotionProductFor = new ConsumerPromotionProductFor();
                            oConsumerPromotionProductFor.ConsumerPromoID = oConsumerPromotion.ConsumerPromoID;
                            oConsumerPromotionProductFor.GroupTypeID = int.Parse(oItemRow.Cells[9].Value.ToString());

                            oConsumerPromotionProductFor.ProductGroupID = int.Parse(oItemRow.Cells[7].Value.ToString());
                            oConsumerPromotionProductFor.BrandID = int.Parse(oItemRow.Cells[8].Value.ToString());

                            try
                            {
                                oConsumerPromotionProductFor.TGTQty = int.Parse(oItemRow.Cells[2].Value.ToString());
                            }
                            catch
                            {
                                oConsumerPromotionProductFor.TGTQty = 0;
                            }


                            /////////////////////////////////////
                            try
                            {
                                oConsumerPromotionProductFor.TargetValue = Convert.ToDouble(oItemRow.Cells[3].Value.ToString());
                            }
                            catch
                            {
                                oConsumerPromotionProductFor.TargetValue = 0;
                            }

                            try
                            {
                                oConsumerPromotionProductFor.PromoCostVal = Convert.ToDouble(oItemRow.Cells[4].Value.ToString());
                            }
                            catch
                            {
                                oConsumerPromotionProductFor.PromoCostVal = 0;
                            }
                            try
                            {
                                oConsumerPromotionProductFor.NetSalesVal = Convert.ToDouble(oItemRow.Cells[5].Value.ToString());
                            }
                            catch
                            {
                                oConsumerPromotionProductFor.NetSalesVal = 0;
                            }
                            /////////////////////////////////////////////

                            try
                            {
                                oConsumerPromotionProductFor.RegularSalesQty = int.Parse(oItemRow.Cells[6].Value.ToString());
                            }
                            catch
                            {
                                oConsumerPromotionProductFor.RegularSalesQty = 0;
                            }
                           

                            if (oConsumerPromotion.PromotionTypeName == "CP")
                            {
                                oConsumerPromotionProductFor.UpdateCP();
                            }
                            else
                            {
                                oConsumerPromotionProductFor.UpdateTP();
                            }
                        }
                    }
                }


                

                SPWarehouses oShowrooms = new SPWarehouses();
                if (oConsumerPromotion.PromotionTypeName == "CP")
                {
                    oShowrooms.GetPromoWarehouse(oConsumerPromotion.ConsumerPromoID);
                }
                else if (oConsumerPromotion.PromotionTypeName == "TP")
                {
                    oShowrooms.GetTPWarehouse(oConsumerPromotion.ConsumerPromoID);
                }
                foreach (SPWarehouse oShowroom in oShowrooms)
                {
                    CJ.Class.POS.DataTran oDataTran = new CJ.Class.POS.DataTran();
                    oDataTran.TableName = sTableName.ToString();
                    oDataTran.DataID = Convert.ToInt32(oConsumerPromotion.ConsumerPromoID);
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
                MessageBox.Show("You have successfully update the transaction: " + oConsumerPromotion.ConsumerPromoID, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                Save();
                _bActionSave = true;
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

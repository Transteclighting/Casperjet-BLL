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
using CJ.Class.POS;
using CJ.Class.Promotion;
using CJ.Class.DataTransfer;

namespace CJ.POS.RT
{
    public partial class frmImportXML : Form
    {
        public frmImportXML()
        {
            InitializeComponent();
            btnSave.Enabled = false;
        }
        DataTransfer oDataTransfer;
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            bool IsSelected = false;

            openFileDialogData.FileName = "";
            openFileDialogData.Multiselect = false;
            openFileDialogData.Filter = "";

            openFileDialogData.Filter = "XML Files (*.xml)|*.xml";
            openFileDialogData.FilterIndex = 0;
            openFileDialogData.DefaultExt = "xml";

            if (openFileDialogData.ShowDialog() == DialogResult.OK)
            {
                txtXLFilePath.Text = openFileDialogData.FileName.ToString();
                Text = openFileDialogData.DefaultExt.ToString();
                IsSelected = true;
            }
            if (IsSelected)
            {
                btnSave.Enabled = true;
            }
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            // string filePath = "D:\\XML\\CP.xml";
            this.Cursor = Cursors.WaitCursor;
            string sTableName = "";
            int nWarehouseId = 0;
            string sFildName = "";
            string sDescription = "";
            string sType = "";
            string filePath = txtXLFilePath.Text;
            DSPromotion oDSCP = new DSPromotion();
            DSPlanMAGWeekTargetQty oDSMAGT = new DSPlanMAGWeekTargetQty();
            DSPlanExecutiveWeekTarget oDSLeadT = new DSPlanExecutiveWeekTarget();

            try
            {
                if (rdoCP.Checked == true)
                {
                    oDSCP.ReadXml(filePath);
                }
                else if (rdoMAGWeekTarget.Checked == true)
                {
                    oDSMAGT.ReadXml(filePath);
                }
                else if (rdoLeadTarget.Checked == true)
                {
                    oDSLeadT.ReadXml(filePath);
                }
                else if (rdoBankDiscount.Checked == true)
                {
                    oDSCP.ReadXml(filePath);
                }
            }
            catch
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show("Please select right file", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            try
            {
                #region GET Header
                if (rdoMAGWeekTarget.Checked == true)
                {
                    foreach (DSPlanMAGWeekTargetQty.SPHeaderRow oRow in oDSMAGT.SPHeader)
                    {
                        sTableName = oRow.TableName;
                        nWarehouseId = oRow.WarehouseID;
                        sFildName = oRow.FileName;
                        sDescription = oRow.Description;
                        sType = oRow.Type;
                    }
                }
                else if (rdoLeadTarget.Checked == true)
                {
                    foreach (DSPlanExecutiveWeekTarget.SPHeaderRow oRow in oDSLeadT.SPHeader)
                    {
                        sTableName = oRow.TableName;
                        nWarehouseId = oRow.WarehouseID;
                        sFildName = oRow.FileName;
                        sDescription = oRow.Description;
                        sType = oRow.Type;
                    }
                }
                else if(rdoCP.Checked == true)
                {
                    foreach (DSPromotion.SPHeaderRow oRow in oDSCP.SPHeader)
                    {
                        sTableName = oRow.TableName;
                        nWarehouseId = oRow.WarehouseID;
                        sFildName = oRow.FileName;
                        sDescription = oRow.Description;
                        sType = oRow.Type;
                    }

                }
                else if (rdoBankDiscount.Checked == true)
                {
                    foreach (DSPromotion.SPHeaderRow oRow in oDSCP.SPHeader)
                    {
                        sTableName = oRow.TableName;
                        nWarehouseId = oRow.WarehouseID;
                        sFildName = oRow.FileName;
                        sDescription = oRow.Description;
                        sType = oRow.Type;
                    }

                }
                #endregion

                if (!DBController.Instance.CheckConnection())
                {
                    DBController.Instance.OpenNewConnection();
                }
                SystemInfo oSystemInfo = new SystemInfo();
                oSystemInfo.Refresh();

                if (oSystemInfo.WarehouseID != nWarehouseId)
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Invalid file!! Please select correct file.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                //if (rdoCP.Checked == true)
                //{
                //    if (sType != "CP" || sType != "TP")
                //    {
                //        this.Cursor = Cursors.Default;
                //        MessageBox.Show("Please select CP/TP file", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        return;
                //    }
                //}
                //else if (rdoMAGWeekTarget.Checked == true)
                //{
                //    if (sType != "MAGWT")
                //    {
                //        this.Cursor = Cursors.Default;
                //        MessageBox.Show("Please select MAG Target file", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        return;
                //    }
                //}
                //else if (rdoLeadTarget.Checked == true)
                //{
                //    if (sType != "LeadT")
                //    {
                //        this.Cursor = Cursors.Default;
                //        MessageBox.Show("Please select Lead Target file", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //        return;
                //    }
                //}


                PromoXML oXML = new PromoXML();
                if (oXML.CheckFileNameforPOS(sFildName))
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("This file already uploaded!!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                DBController.Instance.BeginNewTransaction();

                oDataTransfer = new DataTransfer();
                if (sType == "MAGWT")
                {
                    oDataTransfer.InsertPlanMAGWeekTargetQtyNew(oDSMAGT);
                }
                else if (sType == "LeadT")
                {
                    oDataTransfer.InsertPlanExecutiveLeadTargetNew(oDSLeadT);
                }
                else if (sType == "BankD")
                {
                    oDataTransfer.InsertPromoDiscountAllData(oDSCP,"t_PromoDiscountBank", nWarehouseId);
                }
                else 
                {
                    oDataTransfer.InsertSalesPromotionNew(oDSCP, sTableName, nWarehouseId);
                }

                oXML.Type = sType;
                oXML.FileName = sFildName;
                oXML.Description = sDescription;
                oXML.CreateUserId = Utility.UserId;
                oXML.CreateDate = Convert.ToDateTime(oSystemInfo.OperationDate);

                oXML.AddforPOS();
                DBController.Instance.CommitTran();
                this.Cursor = Cursors.Default;
                MessageBox.Show("CP Inserted Successfully...", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                this.Cursor = Cursors.Default;
                MessageBox.Show("Error!! Inserting Promotions:" + ex + "", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw (ex);
            }
            this.Cursor = Cursors.Default;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

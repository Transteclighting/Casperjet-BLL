using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;

namespace CJ.Win.Accounts
{
    public partial class frmPettyCashExpenseHead : Form
    {
        public bool IsTrue = false;
        int nExpenseHeadID = 0;
        public frmPettyCashExpenseHead()
        {
            InitializeComponent();
        }
        public void ShowDialog(PettyCashExpenseHead oPettyCashExpenseHead)
        {

            this.Tag = oPettyCashExpenseHead;
            DBController.Instance.OpenNewConnection();

            nExpenseHeadID = oPettyCashExpenseHead.ExpenseHeadID;
            txtDescription.Text= oPettyCashExpenseHead.Description;

            if (oPettyCashExpenseHead.IsActive == (int)Dictionary.YesOrNoStatus.YES)
            {
                chkIsActive.Checked = true;
            }
            else
            {
                chkIsActive.Checked = false;
            }

            this.ShowDialog();
        }
        private void frmPettyCashExpenseHead_Load(object sender, EventArgs e)
        {

        }
        private bool UIValidation()
        {           
            if (txtDescription.Text.Trim() == "")
            {
                MessageBox.Show("Please put description", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Focus();
                return false;
            }            
            return true;

        }
        private void Save()
        {
            if (this.Tag == null)
            {
                PettyCashExpenseHead oPettyCashExpenseHead = new PettyCashExpenseHead();
                oPettyCashExpenseHead.Description = txtDescription.Text;
                oPettyCashExpenseHead.CreateDate = DateTime.Now;
                oPettyCashExpenseHead.CreateUserID = Utility.UserId;
                if (chkIsActive.Checked == true)
                {
                    oPettyCashExpenseHead.IsActive = (int)Dictionary.YesOrNoStatus.YES;

                }
                else
                {
                    oPettyCashExpenseHead.IsActive = (int)Dictionary.YesOrNoStatus.NO;
                }

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oPettyCashExpenseHead.Add();

                    Showrooms oShowrooms = new Showrooms();
                    oShowrooms.Refresh();
                    foreach (Showroom oShowroom in oShowrooms)
                    {
                        DataTran oDataTran = new DataTran();
                        oDataTran.TableName = "t_PettyCashExpenseHead";
                        oDataTran.DataID = Convert.ToInt32(oPettyCashExpenseHead.ExpenseHeadID);
                        oDataTran.WarehouseID = oShowroom.WarehouseID;
                        oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                        oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                        oDataTran.BatchNo = 0;
                        if (oDataTran.CheckDataByWHID() == false)
                        {
                            oDataTran.AddForTDPOS();
                        }
                    }


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
                PettyCashExpenseHead oPettyCashExpenseHead = (PettyCashExpenseHead)this.Tag;
                oPettyCashExpenseHead.Description = txtDescription.Text;
                oPettyCashExpenseHead.UpdateDate = DateTime.Now;
                oPettyCashExpenseHead.UpdateUserID = Utility.UserId;
                if (chkIsActive.Checked == true)
                {
                    oPettyCashExpenseHead.IsActive = (int)Dictionary.YesOrNoStatus.YES;

                }
                else
                {
                    oPettyCashExpenseHead.IsActive = (int)Dictionary.YesOrNoStatus.NO;
                }

                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oPettyCashExpenseHead.EditExpenseHead();
                    Showrooms oShowrooms = new Showrooms();
                    oShowrooms.Refresh();
                    foreach (Showroom oShowroom in oShowrooms)
                    {
                        DataTran oDataTran = new DataTran();
                        oDataTran.TableName = "t_PettyCashExpenseHead";
                        oDataTran.DataID = Convert.ToInt32(oPettyCashExpenseHead.ExpenseHeadID);
                        oDataTran.WarehouseID = oShowroom.WarehouseID;
                        oDataTran.TransferType = (int)Dictionary.DataTransferType.Add;
                        oDataTran.IsDownload = (int)Dictionary.IsDownload.No;
                        oDataTran.BatchNo = 0;
                        if (oDataTran.CheckDataByWHID() == false)
                        {
                            oDataTran.AddForTDPOS();
                        }
                    }

                    DBController.Instance.CommitTran();
                    MessageBox.Show("Edit Successfully", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                Save();
                IsTrue = true;
                this.Close();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

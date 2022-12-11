
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.POS;  
using CJ.Class.Promotion;


namespace CJ.Win.Promotion
{
    public partial class frmExcludeDMSPromotion : Form
    {

        ConsumerPromotion _oConsumerPromotion;
        ConsumerPromotions _oConsumerPromotions;
        public frmExcludeDMSPromotion()
        {
            InitializeComponent();
        }

        public void ShowDialog(ConsumerPromotion oConsumerPromotion)
        {

            this.Tag = oConsumerPromotion;
            txtConsumerPromotion.Text = oConsumerPromotion.ConsumerPromoNo;

            txtConsumerPromotion.Enabled = false;
            rdoExclude.Checked = false;
            rdoExclude.Enabled = false;
            rdoInclude.Checked = true;
            this.ShowDialog();
        }
        
        public bool UIValidation()
        {
            if (txtConsumerPromotion.Text.Trim()=="")
            {
                MessageBox.Show("Please Enter Consumer Promotion Name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConsumerPromotion.Focus();
                return false;
            }
            
            return true;
        }
        private void btSave_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                if (this.Tag != null)
                {

                    ConsumerPromotion oConsumerPromotion = (ConsumerPromotion)this.Tag;
                    _oConsumerPromotion = new ConsumerPromotion();
                    _oConsumerPromotion.ConsumerPromoID = oConsumerPromotion.ConsumerPromoID;
                    _oConsumerPromotion.TableName = oConsumerPromotion.TableName;
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        if (rdoExclude.Checked == true)
                        {
                            _oConsumerPromotion.AddNotApplicableToDms();
                        }
                        else
                        {
                            _oConsumerPromotion.DeleteNotApplicableToDms();
                        }
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Update Successfully ", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }
                }
                else
                {
                    _oConsumerPromotion = new ConsumerPromotion();
                    _oConsumerPromotion.RefreshCPNo(txtConsumerPromotion.Text.Trim());
               
                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        
                        if (rdoExclude.Checked == true)
                        {
                            _oConsumerPromotion.AddNotApplicableToDms();
                        }
                        else
                        {
                            _oConsumerPromotion.DeleteNotApplicableToDms();
                        }

                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("Save Successfully ", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();

                    }
                    catch (Exception ex)
                    {
                        DBController.Instance.RollbackTransaction();
                        MessageBox.Show(ex.Message, "Error!!!");
                    }

                }
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmExcludeDMSPromotion_Load(object sender, EventArgs e)
        {
            if (this.Tag != null)
            {
                this.Text = "Include CP to DMS";
            }
            else
            {
                this.Text = "Exclude/Include CP from DMS";
            }
        }
    }
}
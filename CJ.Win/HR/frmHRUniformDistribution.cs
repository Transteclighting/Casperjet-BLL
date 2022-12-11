using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.HR;
using CJ.Class.BasicData;

namespace CJ.Win.HR
{
    public partial class frmHRUniformDistribution : Form
    {
        HRUniformDistribution oHRUniformDistribution;
        Showrooms oShowrooms;
        string SCode = "";
        public bool IsTrue = false;
        public frmHRUniformDistribution()
        {
            InitializeComponent();
        }
        public void ShowDialog(HRUniformDistribution oHRUniformDistribution)
        {
            DBController.Instance.OpenNewConnection();
            this.Tag = oHRUniformDistribution;
            LoadCombo();
            SCode = oHRUniformDistribution.Code;
            txtUniform.Text = oHRUniformDistribution.Uniform.ToString();
            txtTShirt.Text = oHRUniformDistribution.TShirt.ToString();
            txtVCard.Text = oHRUniformDistribution.VisitingCard.ToString();
            txtNameTag.Text = oHRUniformDistribution.NameTag.ToString();
            dtDate.Value = oHRUniformDistribution.EntryDate;
            //cmbBrand.SelectedIndex = oBrands.GetIndex(oHRUniformDistribution.BrandID) + 1;
            cmbOutlet.Text = oHRUniformDistribution.Showroom;
            txtSimCard.Text = oHRUniformDistribution.SimCard.ToString();

            this.ShowDialog();
        }
        private void frmHRUniformDistribution_Load(object sender, EventArgs e)
        {
            if (this.Tag == null || this.Tag == " ")
            {
                LoadCombo();
            }
        }
        private void LoadCombo()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            oShowrooms = new Showrooms();
            oShowrooms.Refresh();
            cmbOutlet.Items.Clear();
            cmbOutlet.Items.Add("-- All--");
            foreach (Showroom oShowroom in oShowrooms)
            {
                cmbOutlet.Items.Add(oShowroom.ShowroomCode);
            }
            cmbOutlet.SelectedIndex = 0;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private bool validation()
        {
            //if (ctlCustomer1.txtCode.Text.Trim() == "")
            //{
            //    MessageBox.Show("Please Input Customer name", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    ctlCustomer1.txtCode.Focus();
            //    return false;
            //}
            if (cmbOutlet.Text.Trim() == "-- All--")
            {
                MessageBox.Show("Please Input Showroom Code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbOutlet.Focus();
                return false;
            }
            

            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validation())
            {
                Save();
            }
        }
        private void Save()
        {
            HRUniformDistribution oHRUniformDistribution;
            if (this.Tag == null)
            {
                oHRUniformDistribution = new HRUniformDistribution();
                oHRUniformDistribution.Uniform = Convert.ToInt32(txtUniform.Text);
                oHRUniformDistribution.TShirt = Convert.ToInt32(txtTShirt.Text);
                oHRUniformDistribution.VisitingCard = Convert.ToInt32(txtVCard.Text);
                oHRUniformDistribution.NameTag = Convert.ToInt32(txtNameTag.Text);
                oHRUniformDistribution.SimCard = Convert.ToInt32(txtSimCard.Text);
                oHRUniformDistribution.EntryDate = dtDate.Value;
                //oHRUniformDistribution.BrandID = oBrands[cmbBrand.SelectedIndex].BrandID;
                oHRUniformDistribution.Showroom = cmbOutlet.Text;
                oHRUniformDistribution.CreateBy = Utility.UserId;
                oHRUniformDistribution.CreateDate = DateTime.Now;
                oHRUniformDistribution.Status = (int)Dictionary.HRUniformDistributionStatus.Create;

                DBController.Instance.BeginNewTransaction();
                oHRUniformDistribution.Add();
                DBController.Instance.CommitTransaction();
                MessageBox.Show("Successfully Add HRUniform Distribution. HRUniform Distribution Code # " + oHRUniformDistribution.Code, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                //oHRUniformDistribution = new HRUniformDistribution();
                oHRUniformDistribution = (HRUniformDistribution)this.Tag;
                oHRUniformDistribution.Uniform = Convert.ToInt32(txtUniform.Text);
                oHRUniformDistribution.TShirt = Convert.ToInt32(txtTShirt.Text);
                oHRUniformDistribution.VisitingCard = Convert.ToInt32(txtVCard.Text);
                oHRUniformDistribution.NameTag = Convert.ToInt32(txtNameTag.Text);
                oHRUniformDistribution.SimCard = Convert.ToInt32(txtSimCard.Text);
                oHRUniformDistribution.EntryDate = dtDate.Value;
                oHRUniformDistribution.Showroom = cmbOutlet.Text;

                DBController.Instance.BeginNewTransaction();
                oHRUniformDistribution.EditByHR();
                DBController.Instance.CommitTransaction();
                MessageBox.Show("Successfully Edit HRUniform Distribution. HRUniform Distribution Code # " + SCode, "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }

        }
    }
}

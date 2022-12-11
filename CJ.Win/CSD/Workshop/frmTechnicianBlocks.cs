using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;

namespace CJ.Win.CSD.Workshop
{
    public partial class frmTechnicianBlocks : Form
    {
        private CSDTechnicianBlocks _oCSDTechnicianBlocks;
        private CSDTechnicianBlock _oCSDTechnicianBlock;
        public frmTechnicianBlocks()
        {
            InitializeComponent();
        }

        private void frmTechnicianBlocks_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            _oCSDTechnicianBlocks = new CSDTechnicianBlocks();

            lvwCSDTechnicianBlock.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oCSDTechnicianBlocks.RefreshByTechnicianBlock(dtFromDate.Value.Date,  txtName.Text);
            this.Text = "Serviceable Product/Item Groups (including Charges)" + "[" + _oCSDTechnicianBlocks.Count + "]";

            foreach (CSDTechnicianBlock oCSDTechnicianBlock in _oCSDTechnicianBlocks)
            {
                ListViewItem oItem = lvwCSDTechnicianBlock.Items.Add(oCSDTechnicianBlock.Code);
                oItem.SubItems.Add(oCSDTechnicianBlock.Name);
                oItem.SubItems.Add(oCSDTechnicianBlock.FromDate.ToString("ddd: dd-MMM-yyyy"));
                oItem.SubItems.Add(oCSDTechnicianBlock.ToDate.ToString("ddd: dd-MMM-yyyy"));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.TechnicianBlockStatus), oCSDTechnicianBlock.Status));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), oCSDTechnicianBlock.IsFullTime));
                if (oCSDTechnicianBlock.IsFullTime == (int)Dictionary.YesOrNoStatus.NO)
                {
                    oItem.SubItems.Add(Convert.ToDateTime(oCSDTechnicianBlock.FromTime).ToShortTimeString());
                }
                else
                {
                    oItem.SubItems.Add(" ");
                }
                if (oCSDTechnicianBlock.IsFullTime == (int)Dictionary.YesOrNoStatus.NO)
                {
                    oItem.SubItems.Add(Convert.ToDateTime(oCSDTechnicianBlock.ToTime).ToShortTimeString());
                }
                else
                {
                    oItem.SubItems.Add(" ");
                }
                oItem.SubItems.Add(oCSDTechnicianBlock.CreateDate.ToString("dd-MMM-yyyy hh:mm tt"));
                oItem.SubItems.Add(oCSDTechnicianBlock.UserName);
                oItem.SubItems.Add(oCSDTechnicianBlock.ApprovedDate.ToString("dd-MMM-yyyy hh:mm tt"));
                oItem.SubItems.Add(oCSDTechnicianBlock.ApprovedBy);
                oItem.SubItems.Add(oCSDTechnicianBlock.Remarks);

                oItem.Tag = oCSDTechnicianBlock;
            }
            setListViewRowColour();
        }
        private void setListViewRowColour()
        {
            if (lvwCSDTechnicianBlock.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwCSDTechnicianBlock.Items)
                {
                    if (oItem.SubItems[4].Text == "Approved")
                    {
                        oItem.BackColor = Color.White;
                    }
                    else if (oItem.SubItems[4].Text == "Create")
                    {
                        oItem.BackColor = Color.Crimson;
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmTechnicianBlock ofrmTechnicianBlock = new frmTechnicianBlock();
            ofrmTechnicianBlock.ShowDialog();
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwCSDTechnicianBlock.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CSDTechnicianBlock oCSDTechnicianBlock = (CSDTechnicianBlock)lvwCSDTechnicianBlock.SelectedItems[0].Tag;
            if (oCSDTechnicianBlock.Status == ((int)Dictionary.TechnicianBlockStatus.Create))
            {
                frmTechnicianBlock ofrmTechnicianBlock = new frmTechnicianBlock();
                ofrmTechnicianBlock.ShowDialog(oCSDTechnicianBlock);
                LoadData();
            }
            else
            {
                MessageBox.Show("Approved Status Can't Be Edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvwCSDTechnicianBlock.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CSDTechnicianBlock oCSDTechnicianBlock = (CSDTechnicianBlock)lvwCSDTechnicianBlock.SelectedItems[0].Tag;

            if (oCSDTechnicianBlock.Status == ((int)Dictionary.TechnicianBlockStatus.Create))
            {
                LoadData();
            }
            else
            {
                MessageBox.Show("Approved Status Can't Be Delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete : " + oCSDTechnicianBlock.ID+ " ? ", "Confirm To Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oCSDTechnicianBlock.Delete();
                    DBController.Instance.CommitTransaction();
                    LoadData();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnApproved_Click(object sender, EventArgs e)
        {

            if (lvwCSDTechnicianBlock.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row to Approved.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CSDTechnicianBlock oCSDTechnicianBlock = (CSDTechnicianBlock)lvwCSDTechnicianBlock.SelectedItems[0].Tag;
            if (oCSDTechnicianBlock.Status == ((int)Dictionary.TechnicianBlockStatus.Create))
            {
                LoadData();
            }
            else
            {
                MessageBox.Show("Approved Status Can't Be Approved.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DialogResult oResult = MessageBox.Show("Are you sure you want to Approved : " + oCSDTechnicianBlock.ID + " ? ", "Confirm To Approved", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oCSDTechnicianBlock.UpdateTech();
                    DBController.Instance.CommitTransaction();
                    LoadData();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
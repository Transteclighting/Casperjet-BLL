using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class.CLP;
using CJ.Class;

namespace CJ.Win.CLP
{
    public partial class frmCLPPoint : Form
    {
        CLPPoint oCLPPoint;

        public frmCLPPoint()
        {
            InitializeComponent();
        }
        public void ShowDialog(CLPPoint oCLPPoint)
        {
            this.Tag = oCLPPoint;

            txtDescription.Text = oCLPPoint.Description;
            dtEffectDate.Value = oCLPPoint.EffectDate;

            foreach (CLPPointSlab oCLPPointSlab in oCLPPoint)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvPointSlab);
                oRow.Cells[0].Value = oCLPPointSlab.SlabAmount;
                oRow.Cells[1].Value = oCLPPointSlab.Point;
                dgvPointSlab.Rows.Add(oRow);
            }
            this.ShowDialog();
        }
        private void frmCLPPoint_Load(object sender, EventArgs e)
        {
            if (this.Tag == null)
            {
                this.Text = "Setup New Point";
            }
            else this.Text = "Edit Setup Point";
        }
        private bool validateUIInput()
        {
            if (txtDescription.Text == "")
            {
                MessageBox.Show("Please enter Description.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Focus();
                return false;
            }
            if (dgvPointSlab.Rows.Count == 1)
            {
                MessageBox.Show("Please Input Slab Info. ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            if (validateUIInput())
            {
                if (this.Tag == null)
                {
                    oCLPPoint = new CLPPoint();

                    oCLPPoint.Description = txtDescription.Text;
                    oCLPPoint.EffectDate = dtEffectDate.Value.Date;
                    oCLPPoint.CreatedDate = DateTime.Today.Date;
                    oCLPPoint.CreatedBy = Utility.UserId;
                    
                    // Slab Info
                    foreach (DataGridViewRow oItemRow in dgvPointSlab.Rows)
                    {
                        if (oItemRow.Index < dgvPointSlab.Rows.Count - 1)
                        {
                            CLPPointSlab oCLPPointSlab = new CLPPointSlab();

                            oCLPPointSlab.SlabAmount = Convert.ToDouble(oItemRow.Cells[0].Value.ToString().Trim());
                            oCLPPointSlab.Point = int.Parse(oItemRow.Cells[1].Value.ToString().Trim());

                            oCLPPoint.Add(oCLPPointSlab);
                        }
                    }

                    try
                    {
                        DBController.Instance.BeginNewTransaction();
                        oCLPPoint.Insert();
                        DBController.Instance.CommitTransaction();
                        MessageBox.Show("You Have Successfully Save Data", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

    }
}
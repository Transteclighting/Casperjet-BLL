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
    public partial class frmCLPPointList : Form
    {
        CLPPointList oCLPPointList;

        public frmCLPPointList()
        {
            InitializeComponent();
        }

        private void frmCLPPointList_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        public void LoadData()
        {
            DBController.Instance.OpenNewConnection();
            oCLPPointList = new CLPPointList();
            oCLPPointList.Refresh();

            lvwPointList.Items.Clear();

            foreach (CLPPoint oCLPPoint in oCLPPointList)
            {
                ListViewItem lstItem = lvwPointList.Items.Add((Convert.ToDateTime(oCLPPoint.EffectDate)).ToString("dd-MMM-yyyy"));
                lstItem.SubItems.Add(oCLPPoint.Description.ToString());
                lstItem.SubItems.Add((Convert.ToDateTime(oCLPPoint.CreatedDate)).ToString("dd-MMM-yyyy"));

                lstItem.Tag = oCLPPoint;
            }
            this.Text = "Point List " + "[" + oCLPPointList.Count + "]";

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCLPPoint ofrmCLPPoint = new frmCLPPoint();
            ofrmCLPPoint.ShowDialog();
            LoadData();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwPointList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Point to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CLPPoint oCLPPoint = (CLPPoint)lvwPointList.SelectedItems[0].Tag;
            frmCLPPoint ofrmCLPPoint = new frmCLPPoint();
            ofrmCLPPoint.ShowDialog(oCLPPoint);
            LoadData();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (lvwPointList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CLPPoint oCLPPoint = (CLPPoint)lvwPointList.SelectedItems[0].Tag;

            try
            {
                CLPPointSlab oCLPPointSlab = new CLPPointSlab();
                DBController.Instance.BeginNewTransaction();
                oCLPPointSlab.PointID = oCLPPoint.PointID;
                oCLPPointSlab.Delete();
                oCLPPoint.Delete();
                DBController.Instance.CommitTransaction();
                MessageBox.Show("You Have Successfully Delete Data", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();

            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }
    }
}
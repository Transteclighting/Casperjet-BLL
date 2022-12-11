using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;

namespace CJ.Win
{
    public partial class frmCSDProductTypes : Form
    {
        CSDProductTypes _oCSDProductTypes;
        public frmCSDProductTypes()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmCSDProductType oform = new frmCSDProductType();
            oform.ShowDialog();
            DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {            
            if (lvwProductType.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select A Row To Edit", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CSDProductType oCSDProductType = (CSDProductType)lvwProductType.SelectedItems[0].Tag;
            frmCSDProductType oform = new frmCSDProductType();
            oform.ShowDialog(oCSDProductType);
            DataLoadControl();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCSDProductTypes_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void DataLoadControl()
        {
            DBController.Instance.OpenNewConnection();
            _oCSDProductTypes = new CSDProductTypes();            
            DBController.Instance.OpenNewConnection();
            _oCSDProductTypes.Getdata();
            this.Text = "CSD Product Type | Total: " + "[" + _oCSDProductTypes.Count + "]";
            lvwProductType.Items.Clear();
            foreach (CSDProductType oCSDProductType in _oCSDProductTypes)
            {
                ListViewItem oItem = lvwProductType.Items.Add(oCSDProductType.ProductTypeName.ToString());
                oItem.SubItems.Add(oCSDProductType.Prefix.ToString());
                oItem.SubItems.Add(oCSDProductType.WorkshopTypeName.ToString());                
                oItem.Tag = oCSDProductType;
            }

        }
    }
}
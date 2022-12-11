using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

//using CJ.Class.CSD;
using CJ.Class;
using CJ.Report;

namespace CJ.Win.CSD
{
    public partial class frmCSDSMSHelpLines : Form
    {
        private ListView lvwCSDSMSHelpLines; 
        private ColumnHeader colName;
        private ColumnHeader colHelpline;
        private ColumnHeader colServiceTime;
        private Button btnCSDSMSHelpLineUpdate;
        private Button btnClose;
        private CSDSMSHelplines _oCSDSMSHelplines;

        public frmCSDSMSHelpLines()
        {
            InitializeComponent();
        }


        private void DataLoadControl()
        {
            _oCSDSMSHelplines = new CSDSMSHelplines();
            lvwCSDSMSHelpLines.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oCSDSMSHelplines.Refresh();
            //this.Text = "CSDSMSHelpline " + "[" + _oCSDSMSHelplines.Count + "]";
            foreach (CSDSMSHelpline oCSDSMSHelpline in _oCSDSMSHelplines)
            {
                ListViewItem oItem = lvwCSDSMSHelpLines.Items.Add(oCSDSMSHelpline.Name);
                oItem.SubItems.Add(oCSDSMSHelpline.Helpline);
                oItem.SubItems.Add(oCSDSMSHelpline.ServiceTime);
                oItem.Tag = oCSDSMSHelpline;
            }
            
        }


        private void frmCSDSMSHelpLines_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void btnCSDSMSHelpLineUpdate_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void Update()
        {
            if (lvwCSDSMSHelpLines.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a DCS Helpline.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CSDSMSHelpline oCSDSMSHelpline = (CSDSMSHelpline)lvwCSDSMSHelpLines.SelectedItems[0].Tag;
            frmCSDHelpLine oForm = new frmCSDHelpLine();
            oForm.ShowDialog(oCSDSMSHelpline);
            DataLoadControl();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvwCSDSMSHelpLines_DoubleClick(object sender, EventArgs e)
        {
            Update();
        }




        

    }
}
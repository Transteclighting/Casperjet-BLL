using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using TEL.SMS.BO;
using TEL.SMS.BO.BE;
using TEL.SMS.BO.DA;

namespace TEL.SMS.UI.Win
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            //frmIssues ofrmIssues = new frmIssues();
            //ofrmIssues.MdiParent = this;
            //ofrmIssues.Show();
            //ofrmIssues.WindowState = FormWindowState.Maximized;
            this.Tag = Utility.GetUserName();
            toolStripStatusLabelUser.Text =(string)this.Tag;
            toolStripStatusLabelUserGroup.Text = ConfigurationManager.AppSettings["UserGroup"];
            
            //Menu Permission
            PersonsToolStripMenuItem.Visible =(ConfigurationManager.AppSettings["mnuPersons"]=="true");
            sMSGroupsToolStripMenuItem.Visible = (ConfigurationManager.AppSettings["mnuSMSGroups"] == "true");
            requestForGroupSMSToolStripMenuItem.Visible = (ConfigurationManager.AppSettings["mnuSMSMessageGroup"] == "true");
            requestForIndividualSMSToolStripMenuItem.Visible = (ConfigurationManager.AppSettings["mnuSMSMessageIndividual"] == "true");
            listOfMessagesToolStripMenuItem.Visible = (ConfigurationManager.AppSettings["mnuSMSMessages"] == "true");
            adminToolStripMenuItem.Visible = (ConfigurationManager.AppSettings["mnuAdmin"] == "true");
            warrantyToolStripMenuItem.Visible = (ConfigurationManager.AppSettings["mnuWarranty"] == "true");
            iTProductToolStripMenuItem.Visible = (ConfigurationManager.AppSettings["mnuiTProduct"] == "true");
            reportToolStripMenuItem.Visible = (ConfigurationManager.AppSettings["mnuReport"] == "true");
        }

        private void PersonsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPersons ofrmPersons = new frmPersons();
            ofrmPersons.MdiParent = this;
            ofrmPersons.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmAbout oForm = new frmAbout();
            //oForm.Show();
        }

        private void sMSGroupsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSMSGroups ofrmSMSGroups = new frmSMSGroups();
            ofrmSMSGroups.MdiParent = this;
            ofrmSMSGroups.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void requestForGroupSMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSMSMessageForGroup oForm = new frmSMSMessageForGroup();
            oForm.MdiParent = this;
            oForm.Show();
        }

        private void requestForIndividualSMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSMSMessageForSingle oForm = new frmSMSMessageForSingle();
            oForm.MdiParent = this;
            oForm.Show();
        }

        private void listOfMessagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSMSMessages oForm = new frmSMSMessages();
            oForm.MdiParent = this;
            oForm.Show();
        }

        private void updateProductInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDataImport oForm = new frmDataImport();
            oForm.ShowDialog();
        }

        private void receivingMessagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSMSMessagesIn frmSmsMessageIn = new frmSMSMessagesIn();
            frmSmsMessageIn.MdiParent = this;
            frmSmsMessageIn.Show();  
        }

        //private void requestForManyMessageToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    frmSMSMessageForMany oForm = new frmSMSMessageForMany();
        //    oForm.MdiParent = this;
        //    oForm.Show();
        //}

        private void warrantyActivationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWarrantyReg oForm = new frmWarrantyReg();
            oForm.MdiParent = this;
            oForm.Show();
        }

        private void warrantyRegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmWarrantyRegs oForm = new frmWarrantyRegs();
            oForm.MdiParent = this;
            oForm.Show();
        }

        private void showroomStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptShowroomStock oForm = new frmRptShowroomStock();
            //frmProducts oForm = new frmProducts();
            oForm.MdiParent = this;
            oForm.Show();
        }

        private void stockReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void sMSUsageReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptSMSUsage oForm = new frmRptSMSUsage();
            oForm.MdiParent = this;
            oForm.Show();

        }

        private void warrantyRegisterReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptWarrantyReg oFrom = new frmRptWarrantyReg();
            oFrom.MdiParent = this;
            oFrom.Show();
        }

        private void mnuMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void requestForManySMSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSMSMessageForMany oForm = new frmSMSMessageForMany();
            oForm.MdiParent = this;
            oForm.Show();

        }

        private void invoicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmITInvoices oForm = new frmITInvoices();
            oForm.MdiParent = this;
            oForm.Show();
        }

        private void aLLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRptMarketVisit oForm = new frmRptMarketVisit();
            //frmProducts oForm = new frmProducts();
            oForm.MdiParent = this;
            oForm.Show();
        }

        private void iTProductToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
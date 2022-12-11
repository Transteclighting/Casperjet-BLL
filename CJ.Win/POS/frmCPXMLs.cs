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
using System.Data.OleDb;
using System.Net.Mail;

namespace CJ.Win.POS
{
    public partial class frmCPXMLs : Form
    {
        PromoXMLs _oPromoXMLs;
        bool IsCheck = false;
        public frmCPXMLs()
        {
            InitializeComponent();
        }
        
        private void btnCreate_Click(object sender, EventArgs e)
        {
            frmCPXML oform = new frmCPXML();
            oform.ShowDialog();
            DataLoadControl();
        }

        private void btGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void frmCPXMLs_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void DataLoadControl()
        {
            _oPromoXMLs = new PromoXMLs();
            lvwItemList.Items.Clear();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            if (chkAll.Checked == true)
            {
                IsCheck = true;
            }
            else
            {
                IsCheck = false;
            }


            _oPromoXMLs.Refresh(dtFromDate.Value.Date, dtToDate.Value.Date, txtOutlet.Text.Trim(), txtFileName.Text.Trim(), IsCheck);
            this.Text = "Total  " + "[" + _oPromoXMLs.Count + "]";

            foreach (PromoXML oPromoXML in _oPromoXMLs)
            {
                ListViewItem oItem = lvwItemList.Items.Add(oPromoXML.Id.ToString());
                oItem.SubItems.Add(oPromoXML.CreateDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oPromoXML.Outlet);
                oItem.SubItems.Add(oPromoXML.Type);
                oItem.SubItems.Add(oPromoXML.FileName);
                oItem.SubItems.Add(oPromoXML.Description);
                oItem.SubItems.Add(oPromoXML.UserFullName);
                if (oPromoXML.MailResendUserName != null)
                {
                    oItem.SubItems.Add(oPromoXML.MailResendDate.ToString("dd-MMM-yyyy hh:mm:ss"));
                }
                else
                {
                    oItem.SubItems.Add("");
                }
                oItem.SubItems.Add(oPromoXML.MailResendUserName);

                oItem.Tag = oPromoXML;
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnResend_Click(object sender, EventArgs e)
        {
            if (lvwItemList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row to send mail.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            PromoXML oPromoXML = (PromoXML)lvwItemList.SelectedItems[0].Tag;

            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            this.Cursor = Cursors.WaitCursor;
            oPromoXML.GetEmailAddress(oPromoXML.WarehouseID);
            string sPath = @"\\10.168.14.43\d$\XML\";
            string sSubject = "";
            if (oPromoXML.Type == "MAGWT")
            {
                sPath = sPath + @"MAGWT\";
                sSubject = "MAG Wise Week Target";
            }
            else if (oPromoXML.Type == "LeadT")
            {
                sPath = sPath + @"LeadT\";
                sSubject = "Executive Wise Target";
            }
            else if (oPromoXML.Type == "CP")
            {
                sPath = sPath + @"CP\";
                sSubject = "Consumer Promotion";
            }
            else if (oPromoXML.Type == "TP")
            {
                sPath = sPath + @"TP\";
                sSubject = "Trade Promotion";
            }

            try
            {
                oPromoXML.Email = "abdul.hakim@tel.transcombd.com";// comment
                EmailSend(oPromoXML.Email, sPath, oPromoXML.FileName, sSubject);
                oPromoXML.MailResendBy = Utility.UserId;
                oPromoXML.MailResendDate = DateTime.Now;
                DBController.Instance.BeginNewTransaction();
                oPromoXML.UpdateMailResend();
                DBController.Instance.CommitTran();
                MessageBox.Show("Email resend successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Cursor = Cursors.Default;
                DataLoadControl();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                this.Cursor = Cursors.Default;
                MessageBox.Show("Error!!"+ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void EmailSend(string sToEmail, string filePath, string FileName, string sSubject)
        {

            MailMessage oMessage = new MailMessage();

            oMessage.Subject = sSubject;

            oMessage.Body = "Dear BM,\r\n\n"
                + "Please see the attachment for " + sSubject
                + "\nFile Name: " + FileName + " ";

            //oMessage.BodyEncoding = Encoding.GetEncoding("Windows-1254"); // Turkish Character Encoding

            MailAddress oAddress = new MailAddress("mis@tel.transcombd.com", "XML Maker");
            oMessage.From = oAddress;

            //oMessage.To.Add(new MailAddress("saidujjaman.sajib@bll.transcombd.com"));
            //oMessage.To.Add(new MailAddress("shavagata.saha@tel.transcombd.com"));
            oMessage.To.Add(new MailAddress(sToEmail));
            //oMessage.To.Add(new MailAddress("hakim.rajshahi@gmail.com"));
            //foreach (string s in files)
            //{
            //    oMessage.Attachments.Add(new Attachment(s));
            //}
            oMessage.Attachments.Add(new Attachment(filePath + FileName));
            SmtpClient Smtp = new SmtpClient();

            Smtp.Host = "mail.transcombd.com"; // for example gmail smtp server
                                               //Smtp.Host = "smtp.gmail.com"; // for example gmail smtp server
                                               //    Smtp.EnableSsl = true;
            Smtp.Send(oMessage);

        }
    }
}

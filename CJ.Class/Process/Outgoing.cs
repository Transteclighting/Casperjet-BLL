using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net.Mail;
using CJ.Class.CSD;
using CJ.Class;
using CJ.Class.Warranty;
using System.IO;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;


namespace CJ.Class.Process
{
    public class Outgoing
    {
        SMSMaker _oSMSMaker;
        bool IsSend = false;
        public bool SendTDSalesSMS(string sMobileNo, string sInvoiceNumber, string sEmail, int _nIsEmailVarified)
        {
            _oSMSMaker = new SMSMaker();
            string sText = "";
            if (_nIsEmailVarified == 1)
            {
                sText = "Thank you for buying from Transcom Digital. e-invoice/e-warranty will be sent to " + sEmail + ". Visit https://transcomdigital.com/ or dial 16212 for offers";
            }
            else
            { 
                sText = "Thank you for buying from Transcom Digital: " + sInvoiceNumber + ". Please visit https://transcomdigital.com/ or dial 16212 for offer & updates";
            }
            
            IsSend = _oSMSMaker.IntegrateWithAPI(1, sMobileNo, sText);
            return IsSend;
        }

        public bool SendTDSalesEmail(string sConsumerName, int nInvoiceID, string sInvoiceNo, string sInvoiceDate, string sToEmail, int _nIsEmailVarified)
        {
            if (_nIsEmailVarified == 0)
            {
                return false;
            }
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            WarrantyCategory oWarrantyCategory = new WarrantyCategory();
            oWarrantyCategory.Refresh(Convert.ToInt32(nInvoiceID));

            int nData = oWarrantyCategory.Count + 1;
            string[] files = new String[nData];
            int nCount = 0;
            files[nCount] = @"D:\ExportedInvoice\" + sInvoiceNo + ".pdf";
            foreach (WarrantyParameter oWC in oWarrantyCategory)
            {
                nCount++;
                string[] _WarrantyNo = System.IO.Directory.GetFiles(@"D:\ExportedInvoice", "" + oWC.WarrantyCardNo + ".pdf");
                files[nCount] = _WarrantyNo[0];
            }
            try
            {
                if (TDSalesEmail(sConsumerName, sInvoiceNo, sInvoiceDate, sToEmail, files))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            /* Delete File
            string[] Allfiles = new string[oWarrantyCategory.Count];
            Allfiles = System.IO.Directory.GetFiles(@"D:\ExportedInvoice", "*.pdf");
            foreach (string file in Allfiles)
            {
                System.IO.File.Delete(file);
            }
            */
        }

        public bool TDSalesEmail(string sCustomerName, string sInvoiceNo, string sInvoiceDate, string sToEmail, string[] files)
        {
            string path = System.Windows.Forms.Application.StartupPath + "\\res\\";
            //string exePath = System.Windows.Forms.Application.ExecutablePath;
            //string pathx = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location);

            MailMessage oMessage = new MailMessage();
 
            oMessage.Subject = "Transcom Digital (noreply)";

            string sMailbody = EmailTemplete(sCustomerName, sInvoiceNo, sInvoiceDate);

            AlternateView AlternateView_Html = AlternateView.CreateAlternateViewFromString(sMailbody, System.Text.Encoding.UTF8, System.Net.Mime.MediaTypeNames.Text.Html);

            LinkedResource _logo = new LinkedResource(path + "image001.jpeg", System.Net.Mime.MediaTypeNames.Image.Jpeg);
            _logo.ContentId = "Logo";
            _logo.ContentType.MediaType = "image/png";
            _logo.TransferEncoding = TransferEncoding.Base64;
            _logo.ContentType.Name = _logo.ContentId;
            _logo.ContentLink = new Uri("cid:" + _logo.ContentId);
            AlternateView_Html.LinkedResources.Add(_logo);

            LinkedResource _img2 = new LinkedResource(path + "image002.png", System.Net.Mime.MediaTypeNames.Image.Jpeg);
            _img2.ContentId = "Img2";
            _img2.ContentType.MediaType = "image/png";
            _img2.TransferEncoding = TransferEncoding.Base64;
            _img2.ContentType.Name = _img2.ContentId;
            _img2.ContentLink = new Uri("cid:" + _img2.ContentId);
            AlternateView_Html.LinkedResources.Add(_img2);

            LinkedResource _img3 = new LinkedResource(path + "image003.png", System.Net.Mime.MediaTypeNames.Image.Jpeg);
            _img3.ContentId = "Img3";
            _img3.ContentType.MediaType = "image/png";
            _img3.TransferEncoding = TransferEncoding.Base64;
            _img3.ContentType.Name = _img3.ContentId;
            _img3.ContentLink = new Uri("cid:" + _img3.ContentId);
            AlternateView_Html.LinkedResources.Add(_img3);

            LinkedResource _img_fb = new LinkedResource(path + "fb_final.jpg", System.Net.Mime.MediaTypeNames.Image.Jpeg);
            _img_fb.ContentId = "fb";
            _img_fb.ContentType.MediaType = "image/png";
            _img_fb.TransferEncoding = TransferEncoding.Base64;
            _img_fb.ContentType.Name = _img_fb.ContentId;
            _img_fb.ContentLink = new Uri("cid:" + _img_fb.ContentId);
            AlternateView_Html.LinkedResources.Add(_img_fb);

            LinkedResource _img_insta = new LinkedResource(path + "insta_final.jpg", System.Net.Mime.MediaTypeNames.Image.Jpeg);
            _img_insta.ContentId = "insta";
            _img_insta.ContentType.MediaType = "image/png";
            _img_insta.TransferEncoding = TransferEncoding.Base64;
            _img_insta.ContentType.Name = _img_insta.ContentId;
            _img_insta.ContentLink = new Uri("cid:" + _img_insta.ContentId);
            AlternateView_Html.LinkedResources.Add(_img_insta);

            LinkedResource _img_youtube = new LinkedResource(path + "youtube_final.jpg", System.Net.Mime.MediaTypeNames.Image.Jpeg);
            _img_youtube.ContentId = "youtube";
            _img_youtube.ContentType.MediaType = "image/png";
            _img_youtube.TransferEncoding = TransferEncoding.Base64;
            _img_youtube.ContentType.Name = _img_youtube.ContentId;
            _img_youtube.ContentLink = new Uri("cid:" + _img_youtube.ContentId);
            AlternateView_Html.LinkedResources.Add(_img_youtube);

            LinkedResource _img_email = new LinkedResource(path + "email_final.jpg", System.Net.Mime.MediaTypeNames.Image.Jpeg);
            _img_email.ContentId = "email";
            _img_email.ContentType.MediaType = "image/png";
            _img_email.TransferEncoding = TransferEncoding.Base64;
            _img_email.ContentType.Name = _img_email.ContentId;
            _img_email.ContentLink = new Uri("cid:" + _img_email.ContentId);
            AlternateView_Html.LinkedResources.Add(_img_email);

            LinkedResource _img_call = new LinkedResource(path + "call_final.jpg", System.Net.Mime.MediaTypeNames.Image.Jpeg);
            _img_call.ContentId = "call";
            _img_call.ContentType.MediaType = "image/png";
            _img_call.TransferEncoding = TransferEncoding.Base64;
            _img_call.ContentType.Name = _img_call.ContentId;
            _img_call.ContentLink = new Uri("cid:" + _img_call.ContentId);
            AlternateView_Html.LinkedResources.Add(_img_call);

            LinkedResource _img6 = new LinkedResource(path + "image006.jpg", System.Net.Mime.MediaTypeNames.Image.Jpeg);
            _img6.ContentId = "Img6";
            _img6.ContentType.MediaType = "image/png";
            _img6.TransferEncoding = TransferEncoding.Base64;
            _img6.ContentType.Name = _img6.ContentId;
            _img6.ContentLink = new Uri("cid:" + _img6.ContentId);
            AlternateView_Html.LinkedResources.Add(_img6);

            LinkedResource _img7 = new LinkedResource(path + "image007.jpg", System.Net.Mime.MediaTypeNames.Image.Jpeg);
            _img7.ContentId = "Img7";
            _img7.ContentType.MediaType = "image/png";
            _img7.TransferEncoding = TransferEncoding.Base64;
            _img7.ContentType.Name = _img7.ContentId;
            _img7.ContentLink = new Uri("cid:" + _img7.ContentId);
            AlternateView_Html.LinkedResources.Add(_img7);

            oMessage.AlternateViews.Add(AlternateView_Html);


            oMessage.IsBodyHtml = true;

            MailAddress oAddress = new MailAddress("invoice@transcomdigital.com", "Transcom Digital (noreply)");
            oMessage.From = oAddress;
            oMessage.To.Add(new MailAddress(sToEmail));
            //oMessage.To.Add(new MailAddress("hakim.rajshahi@gmail.com"));
            //oMessage.To.Add(new MailAddress("shavagata.saha@tel.transcombd.com"));
            foreach (string s in files)
            {
                oMessage.Attachments.Add(new Attachment(s));
            }

            SmtpClient Smtp = new SmtpClient();

            Smtp.Host = "mail.transcombd.com";
            Smtp.Credentials = new System.Net.NetworkCredential("invoice@transcomdigital.com", "Digital.invoicE");
            Smtp.Port = 25;
            Smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            //Smtp.Host = "smtp.gmail.com";
            //Smtp.Host = "smtp.googlemail.com";
            
            //Smtp.Port = 587;
            //Smtp.EnableSsl = true;
            //Smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            //Smtp.UseDefaultCredentials = false;
            //Smtp.Credentials = new System.Net.NetworkCredential("bll.misit@gmail.com", "bll.misit9925");



            try
            {
                Smtp.Send(oMessage);

                ///NEW CODE FOR DELETE FILE 
                oMessage.Attachments.Dispose();
                return true;
            }
            catch (Exception x)
            {

                ///NEW CODE FOR DELETE FILE 
                oMessage.Attachments.Dispose();
                throw (x);
                return false;
            }


        }

        public void CreateInvoicePath()
        {
            string sPath = @"D:\ExportedInvoice";
            if (!Directory.Exists(sPath))
                Directory.CreateDirectory(sPath);
        }

        private string EmailTemplete(string _sCustomerName, string _sInvoiceNo, string _sInvoiceDate)
        {
            string _sEmailTemplete = "";
            _sEmailTemplete = @"<html>
	    <head>
		<meta http-equiv=Content-Type content='text/html; charset=windows-1252'>
		<meta name=Generator content='Microsoft Word 15 (filtered)'>
		<style>
			<!--
		/* Font Definitions */
		@font-face
		{font-family:'Cambria Math';
		panose-1:2 4 5 3 5 4 6 3 2 4;}
		@font-face
		{font-family:Calibri;
		panose-1:2 15 5 2 2 2 4 3 2 4;}
		@font-face
		{font-family:'Franklin Gothic Book';
		panose-1:2 11 5 3 2 1 2 2 2 4;}
		@font-face
		{font-family:Tahoma;
		panose-1:2 11 6 4 3 5 4 4 2 4;}
		@font-face
		{font-family:Telenor;}
		/* Style Definitions */
		p.MsoNormal, li.MsoNormal, div.MsoNormal
		{margin:0in;
		margin-bottom:.0001pt;
		font-size:11.0pt;
		font-family:'Calibri',sans-serif;}
		a:link, span.MsoHyperlink
		{color:#5F5F5F;
		text-decoration:underline;}
		a:visited, span.MsoHyperlinkFollowed
		{color:#969696;
		text-decoration:underline;}
		p.MsoAcetate, li.MsoAcetate, div.MsoAcetate
		{mso-style-link:'Balloon Text Char';
		margin:0in;
		margin-bottom:.0001pt;
		font-size:8.0pt;
		font-family:'Tahoma',sans-serif;}
		p.MsoListParagraph, li.MsoListParagraph, div.MsoListParagraph
		{margin-top:0in;
		margin-right:0in;
		margin-bottom:0in;
		margin-left:.5in;
		margin-bottom:.0001pt;
		font-size:11.0pt;
		font-family:'Calibri',sans-serif;}
		p.MsoListParagraphCxSpFirst, li.MsoListParagraphCxSpFirst, div.MsoListParagraphCxSpFirst
		{margin-top:0in;
		margin-right:0in;
		margin-bottom:0in;
		margin-left:.5in;
		margin-bottom:.0001pt;
		font-size:11.0pt;
		font-family:'Calibri',sans-serif;}
		p.MsoListParagraphCxSpMiddle, li.MsoListParagraphCxSpMiddle, div.MsoListParagraphCxSpMiddle
		{margin-top:0in;
		margin-right:0in;
		margin-bottom:0in;
		margin-left:.5in;
		margin-bottom:.0001pt;
		font-size:11.0pt;
		font-family:'Calibri',sans-serif;}
		p.MsoListParagraphCxSpLast, li.MsoListParagraphCxSpLast, div.MsoListParagraphCxSpLast
		{margin-top:0in;
		margin-right:0in;
		margin-bottom:0in;
		margin-left:.5in;
		margin-bottom:.0001pt;
		font-size:11.0pt;
		font-family:'Calibri',sans-serif;}
		span.BalloonTextChar
		{mso-style-name:'Balloon Text Char';
		mso-style-link:'Balloon Text';
		font-family:'Tahoma',sans-serif;}
		.MsoChpDefault
		{font-family:'Franklin Gothic Book',sans-serif;}
		.MsoPapDefault
		{margin-bottom:10.0pt;
		line-height:115%;}
		@page WordSection1
		{size:8.5in 11.0in;
		margin:1.0in 1.0in 1.0in 1.0in;}
		div.WordSection1
		{page:WordSection1;}
		-->
		</style>
	</head>
	<body lang=EN-US link='#5F5F5F' vlink='#969696'>
		<div align='center' style='margin-top:52px;'>
			<div class=WordSection1 style='width:628px;'>
				<p class=MsoNormal style='text-align:justify'>
					<span style='position:relative;z-index:251671552'>
						<span style='left:480px;top:-3px;width:156px;height:31px'>
                            <div align='right'>
							    <img width=156 height=31 src='cid:Logo' alt=td>
                            </div>
                        </span>     
					</span>
				</p>
				<p class=MsoNormal style='margin-left:5.0in'>
					<span style='font-size:7.0pt; font-family:Telenor;'>Sadar Road, Mohakhali, Dhaka-1206, Bangladesh</span>
				</p>

				<p class=MsoNormal style='text-align:justify'>
					<span style='font-size:12.0pt; font-family:'Franklin Gothic Book',sans-serif'>Dear _sCustomerName;</span>
				</p>
				<p class=MsoNormal style='text-align:justify'>
					<span style='font-size:12.0pt;font-family:'Franklin Gothic Book',sans-serif'>Thank you for buying from 

						<b>TRANSCOM DIGITAL.</b> Reference to the invoice number 

						<b>_sInvoiceNo</b>, invoice date: <b>_sInvoiceDate</b>, please find your 

						<b>e-invoice/ e-warranty</b> with the attached file for your archive. 

					</span>
				</p>
				<p class=MsoNormal style='text-align:justify'>
					<span style='font-size:12.0pt; font-family:'Franklin Gothic Book',sans-serif'>&nbsp;</span>
				</p>
				<p class=MsoNormal style='text-align:justify'>
					<span style='font-size:12.0pt; font-family:'Franklin Gothic Book',sans-serif'>
						We really appreciate your patronage to Transcom Digital and would love to 
						hear about your experience of our product and service.
					</span>
				</p>
				<p class=MsoNormal align=center style='text-align:center'>
					<span style='position:relative;z-index:251661312;left:-2px;top:6px;width:632px; height:22px'>
						<img width=632 height=16 src='cid:Img2'>
					</span>
					<span style='font-size:0.0pt;font-family:'Franklin Gothic Book',sans-serif'>&nbsp;</span>
				</p>
				<br clear=ALL>
				<p class=MsoNormal align=center style='text-align:center'>
					<b>
						<span style='font-size:16.0pt;font-family:'Franklin Gothic Book',sans-serif'>
							More amazing offers on the latest electronics are
						</span>
					</b>
				</p>
				<p class=MsoNormal align=center style='text-align:center'>
					<b>
						<span style='font-size:28.0pt;font-family:'Franklin Gothic Book',sans-serif; color:red'>Waiting For You!</span>
					</b>
				</p>
				<p class=MsoNormal align=center style='text-align:center'>
					<a href='https://transcomdigital.com/'>
						<b>
							<span style='font-size:28.0pt; font-family:'Franklin Gothic Book',sans-serif;color:#C00000;text-decoration: none'>
								<img border=0 width=402 height=57 id='Picture 3' src='cid:Img3'>
							</span>
						</b>
					</a>
				</p>
				<br>
				<div style='width: 100%;'>
						<div style='width: 100%;'>
							<table>							
								<tr>
									<td>
										<table>
											<tr><td colspan='5'><div style='font-family:Calibri,sans-serif; font-size: 12.0pt;font-weight: bold;padding-bottom:11px;'>You can also find us @</div></td></tr>
											<tr>
												<td>
												<a href ='https://www.facebook.com/transcomdigital/?ref=bookmarks' alt='Facebook' target='_blank'>
													<img width=40 height=40 src='cid:fb'>
												</a><td>&nbsp;</td>
												</td>
												<td>
												<a href ='https://www.instagram.com/transcom_digital/' alt='Instagram' target='_blank'>
													<img border=0 width=40 height=40 id='Picture 3' src='cid:insta'>
												</a><td>&nbsp;</td>
												</td>
												<td>
												<a href ='https://www.youtube.com/channel/UCr0kthj-dHfnUfm5IyC6w-Q' alt='Youtube' target='_blank'>
													<img border=0 width=40 height=40 id='Picture 3' src='cid:youtube'>
												</a>
												</td>
											</tr>
										</table>
									</td>
									<td>
										<img src='cid:Img6'>
									</td>
									<td>
										<table>
											<tr><td colspan='4'><div style='font-family:Calibri,sans-serif; font-size: 14.0pt;font-weight: bold;padding-bottom:11px;'>Contact Us</div></td></tr>
											<tr><td colspan='4'><div style='font-family:Calibri,sans-serif; font-size: 12.0pt;font-weight: bold;padding-bottom:11px;'>For any service related query:</div></td></tr>
											<tr>
												<td>
													<a href ='homecare@transcombd.com' alt='Facebook' target='_blank'>
														<img width=25 height=20 src='cid:email'>
														  homecare@transcombd.com
													</a>
												</td>
											</tr>
											<tr>
												<td>
													<a href ='javascript:;' alt='Instagram' target='_blank'>
														<img border=0 width=20 height=20 id='Picture 3' src='cid:call'>
													</a>or call us : <b>16212</b>
												</td>
											</tr>
											<tr><td colspan='4'><div style='font-family:Calibri,sans-serif; font-size: 12.0pt;font-weight: bold;padding-bottom:11px;'>For any order related query:</div></td></tr>
											<tr>
												<td>
													<a href ='estore@transcomdigtal.com' alt='Facebook' target='_blank'>
														<img width=25 height=20 src='cid:email'>
														estore@transcomdigtal.com
													</a>
												</td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</div>


				</div>
				<br><br>

				<br clear=ALL>
				<p class=MsoNormal>
					<b>
						<span style='font-size:28.0pt;font-family:'Franklin Gothic Book',sans-serif; color:#C00000'>­</span>
					</b>
					<b>
						<span style='font-size:28.0pt;font-family:'Franklin Gothic Book',sans-serif; color:#C00000'>
							<img border=0 width=624 height=67 id='Picture 4' src='cid:Img7'>
						</span>
					</b>
				</p>
			</div>
		</div>	
	</body>
</html>";
           
            _sEmailTemplete = _sEmailTemplete.Replace("_sCustomerName", _sCustomerName);
            _sEmailTemplete = _sEmailTemplete.Replace("_sInvoiceNo", _sInvoiceNo);
            _sEmailTemplete = _sEmailTemplete.Replace("_sInvoiceDate", _sInvoiceDate);
            
            return _sEmailTemplete;
        }
    }
}

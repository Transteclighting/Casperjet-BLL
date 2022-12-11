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

using CJ.Class;
using CJ.Class.Promotion;
using CJ.Class.Web.UI.Class;
using CJ.Class.Library;
using CJ.Class.Promotion;
using CJ.Class.POS;

using CJ.Class.DataTransfer;
using System.Data.OleDb;
using System.Net.Mail;

namespace CJ.Win.POS
{
    public partial class frmCPXML : Form
    {
        public frmCPXML()
        {
            InitializeComponent();
        }

        private int _nCallCountUp = 0;
        private int _nCallCountDn = 0;
        private bool _bSuspended;
        PromoXML _oPromoXML;
        DataTree oDataTree;
        DataTree _oDataTree;
        DSPromotion oDSOutlet = new DSPromotion();
    
        private void frmCPXML_Load(object sender, EventArgs e)
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            GetOutlet();
            addTreeNodes(null);
            //AddSalesTypeTreeNodes(null);
        }

        public void GetOutlet()
        {
            _oDataTree = new DataTree();
            _oDataTree.GetShowroomTree();
        }

        private void addTreeNodes(TreeNode oParentNode)
        {
            object oParentID = null;
            object oParentDataType = null;
            oDataTree = new DataTree();
            //oUsers = new Users();

            if (oParentNode == null)
                oDataTree = _oDataTree.getSubDataTree(oParentID, oParentDataType);
            else
            {
                oDataTree = _oDataTree.getSubDataTree(((DataTreeNode)oParentNode.Tag).DataID, ((DataTreeNode)oParentNode.Tag).DataType);
            }

            foreach (DataTreeNode oDataTreeNode in oDataTree)
            {
                TreeNode oNode = new TreeNode();
                oNode.Text = oDataTreeNode.DataName;
                oNode.Tag = oDataTreeNode;

                //oNode.Checked = oUsers.checkdataPermission(oDataTreeNode.DataID, oDataTreeNode.DataType, _nUserID);

                if (oParentNode == null)
                {
                    tvwShowroom.Nodes.Add(oNode);
                }
                else
                {
                    oParentNode.Nodes.Add(oNode);
                }

                addTreeNodes(oNode);
            }

        }

        private void addCheckedNode(TreeNodeCollection oNodes)
        {

            foreach (TreeNode oNode in oNodes)
            {
                if (oNode.Checked == true)
                {
                    if (((DataTreeNode)oNode.Tag).DataType == "Outlet")
                    {
                        DSPromotion.PromoWarehouseRow oPromoWarehouseRow = oDSOutlet.PromoWarehouse.NewPromoWarehouseRow();
                        oPromoWarehouseRow.WarehouseID = ((DataTreeNode)oNode.Tag).DataID;
                        oPromoWarehouseRow.OutletCode = ((DataTreeNode)oNode.Tag).DataName;
                        oPromoWarehouseRow.Email = ((DataTreeNode)oNode.Tag).Email;
                        oDSOutlet.PromoWarehouse.AddPromoWarehouseRow(oPromoWarehouseRow);
                        oDSOutlet.AcceptChanges();

                    }
                    addCheckedNode(oNode.Nodes);
                }
            }
        }

        private void tvwShowroom_AfterCheck(object sender, TreeViewEventArgs e)
        {
            int i;
            //If suspended
            if (_bSuspended)
                return;

            //Check/UnCheck child
            if (_nCallCountUp == 0)
            {
                for (i = 0; i <= e.Node.Nodes.Count - 1; i++)
                {
                    _nCallCountDn++;
                    e.Node.Nodes[i].Checked = e.Node.Checked;
                    _nCallCountDn--;
                }
            }

            bool bAnyChecked = false;
            //Check/UnCheck Parent
            if (_nCallCountDn == 0)
            {
                if (e.Node.Parent != null)
                {
                    foreach (TreeNode iNode in e.Node.Parent.Nodes)
                    {
                        if (iNode.Checked == true)
                        {
                            bAnyChecked = true;
                            break;
                        }
                    }

                    _nCallCountUp++;
                    e.Node.Parent.Checked = bAnyChecked;
                    _nCallCountUp--;

                }
            }
        }

        private void Save()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            this.Cursor = Cursors.WaitCursor;
            addCheckedNode(tvwShowroom.Nodes);
            int nCount = 0;
            string sPath = @"\\10.168.14.43\d$\XML\";
            string sEmail = "saidujjaman.sajib@bll.transcombd.com; shavagata.saha@tel.transcombd.com; hakim.rajshahi@gmail.com";
            string sFileName = "";
            DSPromotion oDSPromotion;
            DataTransfer oDataTransfer;
            DSPromotion oDSPromoHeader;
            _oPromoXML = new PromoXML();
            int nFildId = 0;
            string sType = "";
            string sStatus = "";
            foreach (DSPromotion.PromoWarehouseRow oRow in oDSOutlet.PromoWarehouse)
            {
                
                int x = oRow.WarehouseID;
                string y = oRow.OutletCode;
                sEmail = oRow.Email; // uncomment
                //sEmail = "shavagata.saha@tel.transcombd.com";// comment
                oDataTransfer = new DataTransfer();
                string sMessage = "";
                string sSubject = "";
                string[] arr = new string[2];
                arr[0] = "t_PromoCP";
                arr[1] = "t_PromoTP";
                try
                {
                    if (rdoCP.Checked == true)
                    {
                        foreach (string s in arr)
                        {
                            oDSPromotion = new DSPromotion();
                            //oDSPromotion = GetSalesPromotionNew(oDSPromotion, oRow.WarehouseID, s);
                            oDSPromotion = oDataTransfer.GetSalesPromotionNew(oDSPromotion, oRow.WarehouseID, s);
                            if (oDSPromotion.Promo.Count > 0)
                            {
                                

                                if (s == "t_PromoCP")
                                {
                                    sType = "CP";
                                    nFildId = 0;
                                    nFildId = _oPromoXML.GetFileId(sType, oRow.WarehouseID);
                                    sFileName = "" + oRow.OutletCode + "-" + sType + "-" + (nFildId + 1).ToString("00000") + ".xml";
                                    sMessage = "Promo CP:" + oDSPromotion.Promo.Count.ToString();
                                    sPath = @"\\10.168.14.43\d$\XML\CP\";
                                    sSubject = "Consumer Promotion";
                                    nCount++;
                                }
                                else
                                {
                                    sType = "TP";
                                    nFildId = 0;
                                    nFildId = _oPromoXML.GetFileId(sType, oRow.WarehouseID);
                                    sFileName = "" + oRow.OutletCode + "-" + sType + "-" + (nFildId + 1).ToString("00000") + ".xml";
                                    sMessage = "\nPromo TP:" + oDSPromotion.Promo.Count.ToString();
                                    sPath = @"\\10.168.14.43\d$\XML\TP\";
                                    sSubject = "Trade Promotion";
                                    nCount++;
                                }

                                if (!DBController.Instance.CheckConnection())
                                {
                                    DBController.Instance.OpenNewConnection();
                                }

                                oDSPromoHeader = new DSPromotion();
                                DSPromotion.SPHeaderRow oHeaderRow = oDSPromoHeader.SPHeader.NewSPHeaderRow();
                                oHeaderRow.FileName = sFileName;
                                oHeaderRow.Description = txtDescription.Text.Trim();
                                oHeaderRow.WarehouseID = oRow.WarehouseID;
                                oHeaderRow.Type = sType;
                                oHeaderRow.TableName = s;
                                oHeaderRow.CreateUserId = Utility.UserId;
                                oHeaderRow.CreateDate = DateTime.Now;
                                oDSPromoHeader.SPHeader.AddSPHeaderRow(oHeaderRow);
                                oDSPromoHeader.AcceptChanges();

                                oDSPromotion.Merge(oDSPromoHeader);
                                oDSPromotion.AcceptChanges();

                                oDSPromotion.WriteXml(sPath + sFileName);

                                oDataTransfer.UpdatePromotionTransferInfoNew(oDSPromotion, oRow.WarehouseID, s, sFileName);

                                if (!DBController.Instance.CheckConnection())
                                {
                                    DBController.Instance.OpenNewConnection();
                                }
                                DBController.Instance.BeginNewTransaction();
                                AddXMLMaker(oRow.WarehouseID, sType, nFildId, sFileName);
                                DBController.Instance.CommitTran();
                                EmailSend(sEmail, sPath, sFileName, sSubject);

                            }
                        }

                    }
                    else if (rdoMAGWeekTarget.Checked == true)
                    {

                        DSPlanMAGWeekTargetQty oDSPlanMAGWeekTargetQty = new DSPlanMAGWeekTargetQty();
                        oDataTransfer = new DataTransfer();
                        oDSPlanMAGWeekTargetQty = oDataTransfer.GetPlanMAGWeekTargetQty(oDSPlanMAGWeekTargetQty, oRow.WarehouseID);
                        if (oDSPlanMAGWeekTargetQty.PlanMAGWeekTargetQty.Count > 0)
                        {
                            nCount++;
                            sPath = sPath + @"MAGWT\";
                            sType = "MAGWT";
                            sSubject = "MAG Wise Week Target";
                            if (!DBController.Instance.CheckConnection())
                            {
                                DBController.Instance.OpenNewConnection();
                            }

                            nFildId = 0;
                            nFildId = _oPromoXML.GetFileId(sType, oRow.WarehouseID);
                            sFileName = "" + oRow.OutletCode + "-" + sType + "-" + (nFildId + 1).ToString("00000") + ".xml";

                            DSPlanMAGWeekTargetQty.SPHeaderRow oHeaderRow = oDSPlanMAGWeekTargetQty.SPHeader.NewSPHeaderRow();
                            oHeaderRow.FileName = sFileName;
                            oHeaderRow.Description = txtDescription.Text.Trim();
                            oHeaderRow.WarehouseID = oRow.WarehouseID;
                            oHeaderRow.Type = sType;
                            oHeaderRow.TableName = "t_PlanMAGWeekTargetQty";
                            oHeaderRow.CreateUserId = Utility.UserId;
                            oHeaderRow.CreateDate = DateTime.Now;
                            oDSPlanMAGWeekTargetQty.SPHeader.AddSPHeaderRow(oHeaderRow);
                            oDSPlanMAGWeekTargetQty.AcceptChanges();


                            oDSPlanMAGWeekTargetQty.WriteXml(sPath + sFileName);
                            oDataTransfer.UpdatePlanMAGWeekTargetInfo(oDSPlanMAGWeekTargetQty, oRow.WarehouseID, sFileName);
                            if (!DBController.Instance.CheckConnection())
                            {
                                DBController.Instance.OpenNewConnection();
                            }
                            DBController.Instance.BeginNewTransaction();
                            AddXMLMaker(oRow.WarehouseID, sType, nFildId, sFileName);
                            DBController.Instance.CommitTran();
                            EmailSend(sEmail, sPath, sFileName, sSubject);
                        }
                    }
                    else if (rdoLeadTarget.Checked == true)
                    {

                        DSPlanExecutiveWeekTarget oDSPlanExecutiveLeadTarget = new DSPlanExecutiveWeekTarget();
                        oDataTransfer = new DataTransfer();
                        oDSPlanExecutiveLeadTarget = oDataTransfer.GetPlanExecutiveLeadTarget(oDSPlanExecutiveLeadTarget, oRow.WarehouseID);
                        if (oDSPlanExecutiveLeadTarget.PlanExecutiveWeekTarget.Count > 0)
                        {
                            nCount++;
                            sPath = sPath + @"LeadT\";
                            sType = "LeadT";
                            sSubject = "Executive Wise Target";
                            if (!DBController.Instance.CheckConnection())
                            {
                                DBController.Instance.OpenNewConnection();
                            }

                            nFildId = 0;
                            nFildId = _oPromoXML.GetFileId(sType, oRow.WarehouseID);
                            sFileName = "" + oRow.OutletCode + "-" + sType + "-" + (nFildId + 1).ToString("00000") + ".xml";


                            DSPlanExecutiveWeekTarget.SPHeaderRow oHeaderRow = oDSPlanExecutiveLeadTarget.SPHeader.NewSPHeaderRow();
                            oHeaderRow.FileName = sFileName;
                            oHeaderRow.Description = txtDescription.Text.Trim();
                            oHeaderRow.WarehouseID = oRow.WarehouseID;
                            oHeaderRow.Type = sType;
                            oHeaderRow.TableName = "t_PlanExecutiveLeadTarget";
                            oHeaderRow.CreateUserId = Utility.UserId;
                            oHeaderRow.CreateDate = DateTime.Now;
                            oDSPlanExecutiveLeadTarget.SPHeader.AddSPHeaderRow(oHeaderRow);
                            oDSPlanExecutiveLeadTarget.AcceptChanges();

                            oDSPlanExecutiveLeadTarget.WriteXml(sPath + sFileName);
                            oDataTransfer.UpdatePlanExecutiveLeadTargetInfo(oDSPlanExecutiveLeadTarget, oRow.WarehouseID, sFileName);
                            if (!DBController.Instance.CheckConnection())
                            {
                                DBController.Instance.OpenNewConnection();
                            }
                            DBController.Instance.BeginNewTransaction();
                            AddXMLMaker(oRow.WarehouseID, sType, nFildId, sFileName);
                            DBController.Instance.CommitTran();
                            EmailSend(sEmail, sPath, sFileName, sSubject);
                        }
                    }
                    else if (rdoBankDiscount.Checked == true)
                    {
                        oDSPromotion = new DSPromotion();
                        oDSPromotion = oDataTransfer.GetPromoDiscountAllData(oDSPromotion, oRow.WarehouseID, "t_PromoDiscountBank");
                        if (oDSPromotion.PromoDiscount.Count > 0)
                        {


                            //sType = "CP";
                            //nFildId = 0;
                            //nFildId = _oPromoXML.GetFileId(sType, oRow.WarehouseID);
                            //sFileName = "" + oRow.OutletCode + "-" + sType + "-" + (nFildId + 1).ToString("00000") + ".xml";
                            //sMessage = "Promo CP:" + oDSPromotion.Promo.Count.ToString();
                            //sPath = @"\\10.168.14.43\d$\XML\CP\";
                            //sSubject = "Consumer Promotion";
                            //nCount++;

                            nCount++;
                            sPath = sPath + @"BankD\";
                            sType = "BankD";
                            sSubject = "Bank Discount";
                            if (!DBController.Instance.CheckConnection())
                            {
                                DBController.Instance.OpenNewConnection();
                            }

                            nFildId = 0;
                            nFildId = _oPromoXML.GetFileId(sType, oRow.WarehouseID);
                            sFileName = "" + oRow.OutletCode + "-" + sType + "-" + (nFildId + 1).ToString("00000") + ".xml";


                            if (!DBController.Instance.CheckConnection())
                            {
                                DBController.Instance.OpenNewConnection();
                            }

                            oDSPromoHeader = new DSPromotion();
                            DSPromotion.SPHeaderRow oHeaderRow = oDSPromoHeader.SPHeader.NewSPHeaderRow();
                            oHeaderRow.FileName = sFileName;
                            oHeaderRow.Description = txtDescription.Text.Trim();
                            oHeaderRow.WarehouseID = oRow.WarehouseID;
                            oHeaderRow.Type = sType;
                            oHeaderRow.TableName = "t_PromoDiscountBank";
                            oHeaderRow.CreateUserId = Utility.UserId;
                            oHeaderRow.CreateDate = DateTime.Now;
                            oDSPromoHeader.SPHeader.AddSPHeaderRow(oHeaderRow);
                            oDSPromoHeader.AcceptChanges();

                            oDSPromotion.Merge(oDSPromoHeader);
                            oDSPromotion.AcceptChanges();

                            oDSPromotion.WriteXml(sPath + sFileName);

                            oDataTransfer.UpdatePromoDiscountAllData(oDSPromotion, oRow.WarehouseID, "t_PromoDiscountBank");


                            if (!DBController.Instance.CheckConnection())
                            {
                                DBController.Instance.OpenNewConnection();
                            }
                            DBController.Instance.BeginNewTransaction();
                            AddXMLMaker(oRow.WarehouseID, sType, nFildId, sFileName);
                            DBController.Instance.CommitTran();
                            EmailSend(sEmail, sPath, sFileName, sSubject);

                            //DSPromotion oDSPromotionNew = new DSPromotion();
                            //oDataTransfer = new DataTransfer();
                            //oDSPromotionNew = oDataTransfer.GetPromotion(oDSPromotionNew, oRow.WarehouseID);
                            //if (oDSPromotionNew.PromoDiscount.Count > 0)
                            //{
                            //    nCount++;
                            //    sPath = sPath + @"BankD\";
                            //    sType = "BankD";
                            //    sSubject = "Bank Discount";
                            //    if (!DBController.Instance.CheckConnection())
                            //    {
                            //        DBController.Instance.OpenNewConnection();
                            //    }

                            //    nFildId = 0;
                            //    nFildId = _oPromoXML.GetFileId(sType, oRow.WarehouseID);
                            //    sFileName = "" + oRow.OutletCode + "-" + sType + "-" + (nFildId + 1).ToString("00000") + ".xml";


                            //    DSPromotion.SPHeaderRow oPromoDiscountRow = oDSPromotionNew.PromoDiscount.NewPromoDiscountRow();
                            //    //oPromoDiscountRow.FileName = sFileName;
                            //    //oPromoDiscountRow.Description = txtDescription.Text.Trim();
                            //    //oPromoDiscountRow.WarehouseID = oRow.WarehouseID;
                            //    //oPromoDiscountRow.Type = sType;
                            //    //oPromoDiscountRow.TableName = "t_PlanExecutiveLeadTarget";
                            //    //oPromoDiscountRow.CreateUserId = Utility.UserId;
                            //    oPromoDiscountRow.CreateDate = DateTime.Now;
                            //    oDSPromotionNew.PromoDiscount.AddPromoDiscountRow(oPromoDiscountRow);
                            //    oDSPromotionNew.AcceptChanges();

                            //    oDSPromotionNew.WriteXml(sPath + sFileName);
                            //    //oDataTransfer.UpdatePlanExecutiveLeadTargetInfo(oDSPromotionNew, oRow.WarehouseID, sFileName);
                            //    if (!DBController.Instance.CheckConnection())
                            //    {
                            //        DBController.Instance.OpenNewConnection();
                            //    }
                            //    DBController.Instance.BeginNewTransaction();
                            //    AddXMLMaker(oRow.WarehouseID, sType, nFildId, sFileName);
                            //    DBController.Instance.CommitTran();
                            //    EmailSend(sEmail, sPath, sFileName, sSubject);
                        }
                    }

                }
                catch (Exception ex)
                {
                    throw (ex);
                    MessageBox.Show("Please try again" + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Cursor = Cursors.Default;
                    return;
                }

            }
            if (nCount > 0)
            {
                MessageBox.Show("Successfully Create " + nCount.ToString() + " outlet(s) XML", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No file created!!", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Cursor = Cursors.Default;
        }

        private void AddXMLMaker(int nWarehouseID, string sType, int nFildId, string sFileName)
        {
            _oPromoXML = new PromoXML();
            _oPromoXML.WarehouseID = nWarehouseID;
            _oPromoXML.Type = sType;
            _oPromoXML.Description = txtDescription.Text.Trim();
            _oPromoXML.FileId = nFildId + 1;
            _oPromoXML.FileName = sFileName;
            _oPromoXML.CreateUserId = Utility.UserId;
            _oPromoXML.CreateDate = DateTime.Now;

            _oPromoXML.Add();
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (UIValidation())
            {
                this.Cursor = Cursors.WaitCursor;
                Save();
                this.Cursor = Cursors.Default;
                this.Close();
            }
        }

        private bool UIValidation()
        {
            if (txtDescription.Text.Trim() == "")
            {
                MessageBox.Show("Please input description", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

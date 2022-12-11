/// <summary>
/// Compamy: Transcom Electronics Limited
/// Author: Md. Jasim Uddin
/// Date: March 21, 2007
/// Time : 6:09 PM
/// Description: Web Utility
/// Modify Person And Date:
/// </summary>
using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CJ.Class.POS;
using CJ.Class;



/// <summary>
/// Summary description for UIUtility
/// </summary>
/// 

//public class UIUtility
//{

//    public UIUtility()
//    {
//        //
//        // TODO: Add constructor logic here
//        //
//    }
//    public static string GetConfirmationMsg(string sActionTaken,
//                                            string sEntity,
//                                            string[] sSuccessCode,
//                                            string[] sFailedCode,
//                                            string sBackLink)
//    {
//        /*

//        <p>&nbsp;</p>
//        <p align="center"><font face="Verdana" size="2">Following customers have been deleted successful:</font></p>
//        <ol>
//          <li><p align="center"><font face="Verdana" size="2">123</font></li>
//          <li>
//          <p align="center"><font face="Verdana" size="2">345</font></li>
//          <li>
//          <p align="center"><font face="Verdana" size="2">678</font></li>
//        </ol>
//        <p align="center"><font face="Verdana" size="2" color="#FF0000">Following customers have NOT been deleted successfully:</font></p>
//        <ol>
//          <li><p align="center"><font face="Verdana" size="2" color="#FF0000">123</font></li>
//          <li>
//          <p align="center"><font face="Verdana" size="2" color="#FF0000">345</font></li>
//          <li>
//          <p align="center"><font face="Verdana" size="2" color="#FF0000">678</font></li>
//        </ol>
//        <p align="center"><font face="Verdana" size="2"><a href="index.htm">Back</a></font></p>
//        <p>&nbsp;</p>


//        */
//        string sOutput = String.Empty;
//        string sTmp = String.Empty;
//        string sSuccessMsg = "<p align=\"center\"><font face=\"Verdana\" size=\"2\">Msg:</font></p>";
//        string sSuccessListItem = "<li><p align=\"center\"><font face=\"Verdana\" size=\"2\">Code</font></li>";
//        string sFailedMsg = "<p align=\"center\"><font face=\"Verdana\" size=\"2\" color=\"#FF0000\">Msg:</font></p>";
//        string sFailedListItem = "<li><p align=\"center\"><font face=\"Verdana\" size=\"2\" color=\"#FF0000\">Code</font></li>";
//        string sBack = "<p align=\"center\"><font face=\"Verdana\" size=\"2\"><a href=\"LinkPage\">Back</a></font></p>";
//        if (sSuccessCode != null && sSuccessCode.Length > 0)
//        {
//            if (sSuccessCode.Length > 1)
//            {
//                sTmp = "Following " + sEntity + "s have been " + sActionTaken + " successfully";
//            }
//            else
//            {
//                sTmp = "Following " + sEntity + " has been " + sActionTaken + " successfully";
//            }

//            sSuccessMsg = sSuccessMsg.Replace("Msg", sTmp);
//            sSuccessMsg += "<ol>";

//            foreach (string sItem in sSuccessCode)
//            {
//                sTmp = sSuccessListItem.Replace("Code", sItem);
//                sSuccessMsg += sTmp;
//            }
//            sSuccessMsg += "</ol>";
//            sOutput += sSuccessMsg;
//        }

//        // now create the failed msg
//        if (sFailedCode != null && sFailedCode.Length > 0)
//        {
//            if (sFailedCode.Length > 1)
//            {
//                sTmp = "Following " + sEntity + "s have NOT been " + sActionTaken + " successfully";
//            }
//            else
//            {
//                sTmp = "Following " + sEntity + " has NOT been " + sActionTaken + " successfully";
//            }

//            sFailedMsg = sFailedMsg.Replace("Msg", sTmp);
//            sFailedMsg += "<ol>";

//            foreach (string sItem in sFailedCode)
//            {
//                sTmp = sFailedListItem.Replace("Code", sItem);
//                sFailedMsg += sTmp;
//            }
//            sFailedMsg += "</ol>";
//            sOutput += sFailedMsg;
//        }


//        if (sBackLink != null && sBackLink.Length > 0)
//        {
//            //        string sCommand = "javascript:history.back()";

//            sTmp = sBack.Replace("LinkPage", sBackLink);
//            sOutput += sTmp;
//        }

//        return sOutput;

//    }

//    Dictionary

//    //public static string GetConfirmationMsg(string sActionTaken,
//    //                                         string sEntity,
//    //                                         DSDataString sSuccessCode,
//    //                                         DSDataString sFailedCode,
//    //                                         string sBackLink)
//    //{
//    //    string[] sArrSuccessCode = null;
//    //    if (sSuccessCode != null && sSuccessCode.DataString.Count > 0)
//    //    {
//    //        sArrSuccessCode = new string[sSuccessCode.DataString.Count];
//    //        for (int i = 0; i < sSuccessCode.DataString.Count; i++)
//    //        {
//    //            sArrSuccessCode[i] = sSuccessCode.DataString[i].StringValue;

//    //        }
//    //    }
//    //    string[] sArrFailedCode = null;
//    //    if (sFailedCode != null && sFailedCode.DataString.Count > 0)
//    //    {
//    //        sArrFailedCode = new string[sFailedCode.DataString.Count];
//    //        for (int i = 0; i < sFailedCode.DataString.Count; i++)
//    //        {
//    //            sArrFailedCode[i] = sFailedCode.DataString[i].StringValue;
//    //        }
//    //    }
//    //    return GetConfirmationMsg(sActionTaken, sEntity, sArrSuccessCode, sArrFailedCode, sBackLink);

//    //}
//    public static DSProduct getProductList()
//    {
//        DSAction oDSAction = new DSAction();
//        DataSet oDSRequest = new DataSet();
//        DataSet oDSResponse = new DataSet();

//        oDSAction.Action.AddActionRow(ActionID.ACTION_PRODUCT_GET_LIST.ToString());
//        oDSAction.AcceptChanges();

//        oDSRequest.Merge(oDSAction);
//        oDSRequest.AcceptChanges();
//        BOProduct oBOProduct = new BOProduct();
//        oDSResponse = oBOProduct.Execute(oDSRequest);
//        DSError oDSErr = new DSError();
//        oDSErr.Merge(oDSResponse.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();
//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        DSProduct oDSProduct = new DSProduct();

//        oDSProduct.Merge(oDSResponse.Tables[oDSProduct.Product.TableName], false, MissingSchemaAction.Error);
//        oDSProduct.AcceptChanges();

//        return oDSProduct;
//    } //End of getProductList Method     
//    public static DSCustomerList getCustomerList()
//    {
//        DSAction oDSAction = new DSAction();
//        DataSet oDSRequest = new DataSet();
//        DataSet oDSResponse = new DataSet();

//        oDSAction.Action.AddActionRow(ActionID.ACTION_CUSTOMER_All_GET.ToString());
//        oDSAction.AcceptChanges();

//        oDSRequest.Merge(oDSAction);
//        oDSRequest.AcceptChanges();
//        BOCustomer oBOCustomer = new BOCustomer();
//        oDSResponse = oBOCustomer.Execute(oDSRequest);
//        DSError oDSErr = new DSError();
//        oDSErr.Merge(oDSResponse.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();
//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        DSCustomerList oDSCustomerLst = new DSCustomerList();
//        oDSCustomerLst.Merge(oDSResponse.Tables[oDSCustomerLst.CustomerList.TableName], false, MissingSchemaAction.Error);
//        oDSCustomerLst.AcceptChanges();

//        return oDSCustomerLst;
//    } //End of getCustomerList Method 
//    public static DSCustomerList getCustomerByCode(string sCustomerCode)
//    {
//        DSAction oDSAction;
//        DataSet oDSRequest;
//        DataSet oDSResponse;
//        DSCustomerList oDSCustomerList;

//        oDSAction = new DSAction();
//        oDSAction.Action.AddActionRow(ActionID.ACTION_CUSTOMER_GET_BY_CODE.ToString());
//        oDSAction.AcceptChanges();

//        oDSCustomerList = new DSCustomerList();
//        DSCustomerList.CustomerListRow oRow = oDSCustomerList.CustomerList.NewCustomerListRow();
//        oRow.CustomerCode = sCustomerCode;
//        oDSCustomerList.CustomerList.AddCustomerListRow(oRow);
//        oDSCustomerList.AcceptChanges();

//        oDSRequest = new DataSet();
//        oDSRequest.Merge(oDSAction);
//        oDSRequest.Merge(oDSCustomerList);
//        oDSRequest.AcceptChanges();
//        BOCustomer oBOCustomer = new BOCustomer();
//        oDSResponse = oBOCustomer.Execute(oDSRequest);
//        DSError oDSErr = new DSError();
//        oDSErr.Merge(oDSResponse.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();
//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        oDSCustomerList.Clear();
//        oDSCustomerList.Merge(oDSResponse.Tables[oDSCustomerList.CustomerList.TableName], false, MissingSchemaAction.Error);
//        oDSCustomerList.AcceptChanges();

//        return oDSCustomerList;
//    }


//    public static DSWareHouse getWarehouseList()
//    {
//        DSAction oDSAction = new DSAction();
//        DataSet oDSRequest = new DataSet();
//        DataSet oDSResponse = new DataSet();

//        oDSAction.Action.AddActionRow(ActionID.Action_WareHouse_All_GET.ToString());
//        oDSAction.AcceptChanges();

//        oDSRequest.Merge(oDSAction);
//        oDSRequest.AcceptChanges();
//        BOWareHouse oBOWareHouse = new BOWareHouse();
//        oDSResponse = oBOWareHouse.Execute(oDSRequest);
//        DSError oDSErr = new DSError();
//        oDSErr.Merge(oDSResponse.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();
//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        DSWareHouse oDSWareHouse = new DSWareHouse();

//        oDSWareHouse.Merge(oDSResponse.Tables[oDSWareHouse.WareHouse.TableName], false, MissingSchemaAction.Error);
//        oDSWareHouse.AcceptChanges();

//        return oDSWareHouse;
//    } //End of getWarehouseList Method
//    public static DSWareHouseParent getWarehouseParentList()
//    {
//        DSAction oDSAction = new DSAction();
//        DataSet oDSRequest = new DataSet();
//        DataSet oDSResponse = new DataSet();

//        oDSAction.Action.AddActionRow(ActionID.Action_ParentWareHouse_All_GET.ToString());
//        oDSAction.AcceptChanges();

//        oDSRequest.Merge(oDSAction);
//        oDSRequest.AcceptChanges();
//        BOWareHouseParent oBOWarehouseParent = new BOWareHouseParent();
//        oDSResponse = oBOWarehouseParent.Execute(oDSRequest);
//        DSError oDSErr = new DSError();
//        oDSErr.Merge(oDSResponse.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();
//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        DSWareHouseParent oDSWarehouseParent;
//        oDSWarehouseParent = new DSWareHouseParent();
//        oDSWarehouseParent.Merge(oDSResponse.Tables[oDSWarehouseParent.WareHouseParent.TableName], false, MissingSchemaAction.Error);
//        oDSWarehouseParent.AcceptChanges();

//        return oDSWarehouseParent;
//    } //End of getWarehouseParentList Method
//    public static bool isProductIdExists(long ProductID, DSProductStockTranItems oDSProductTranItem)
//    {
//        foreach (DSProductStockTranItems.ProductStockTranItemRow oRow in oDSProductTranItem.ProductStockTranItem)
//        {
//            if (ProductID == oRow.ProductID)
//            {
//                oRow.Delete();
//                return true;

//            }
//        }
//        return false;
//    }


//    public static DSSupplier getSupplierList()
//    {
//        DSAction oDSAction = new DSAction();
//        oDSAction.Action.AddActionRow(ActionID.ACTION_SUPPLIER_GET_ALL.ToString());
//        oDSAction.AcceptChanges();

//        DataSet oDSRequest = new DataSet();
//        oDSRequest.Merge(oDSAction, false);
//        oDSRequest.AcceptChanges();

//        BOSupplier oBOSupplier = new BOSupplier();
//        DataSet oDSResponse = oBOSupplier.Execute(oDSRequest);

//        DSError oDSError = new DSError();
//        DSSupplier oDSSupplier = new DSSupplier();


//        if (oDSError.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSError.GetXml());
//            return null;
//        }

//        oDSSupplier.Merge(oDSResponse.Tables[oDSSupplier.Supplier.TableName], false, MissingSchemaAction.Error);
//        oDSSupplier.AcceptChanges();

//        return oDSSupplier;
//    }
//    // End of getSupplierList



//    public static DSProductGroup getProductGroup()
//    {
//        DSProductGroup oDSPdtGroup = new DSProductGroup();
//        DSProductGroup.ProductGroupRow oDSPdtGroupRow = oDSPdtGroup.ProductGroup.NewProductGroupRow();
//        oDSPdtGroupRow.PdtGroupType = (short)Dictionary.ProductGroupType.ProductGroup;
//        oDSPdtGroup.ProductGroup.AddProductGroupRow(oDSPdtGroupRow);
//        oDSPdtGroup.AcceptChanges();

//        DSAction oDSAction = new DSAction();
//        oDSAction.Action.AddActionRow(ActionID.ACTION_PG_GET_TID.ToString());
//        oDSAction.AcceptChanges();

//        DataSet oDSRequest = new DataSet();
//        oDSRequest.Merge(oDSPdtGroup);
//        oDSRequest.Merge(oDSAction);
//        oDSRequest.AcceptChanges();

//        BOProductGroup oBOPdtGroup = new BOProductGroup();
//        DataSet responseDS = oBOPdtGroup.Execute(oDSRequest);

//        DSError oDSErr = new DSError();
//        oDSErr.Merge(responseDS.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();

//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        oDSPdtGroup.Clear();
//        oDSPdtGroup.Merge(responseDS.Tables[oDSPdtGroup.ProductGroup.TableName], false, MissingSchemaAction.Error);
//        oDSPdtGroup.AcceptChanges();
//        return oDSPdtGroup;
//    }//End of getProductGroup
//    public static DSProductGroup getMAG()
//    {
//        DSProductGroup oDSPdtGroup = new DSProductGroup();
//        DSProductGroup.ProductGroupRow oDSPdtGroupRow = oDSPdtGroup.ProductGroup.NewProductGroupRow();
//        oDSPdtGroupRow.PdtGroupType = (short)Dictionary.ProductGroupType.MAG;
//        oDSPdtGroup.ProductGroup.AddProductGroupRow(oDSPdtGroupRow);
//        oDSPdtGroup.AcceptChanges();

//        DSAction oDSAction = new DSAction();
//        oDSAction.Action.AddActionRow(ActionID.ACTION_PG_GET_TID.ToString());
//        oDSAction.AcceptChanges();

//        DataSet oDSRequest = new DataSet();
//        oDSRequest.Merge(oDSPdtGroup);
//        oDSRequest.Merge(oDSAction);
//        oDSRequest.AcceptChanges();

//        BOProductGroup oBOPdtGroup = new BOProductGroup();
//        DataSet responseDS = oBOPdtGroup.Execute(oDSRequest);

//        DSError oDSErr = new DSError();
//        oDSErr.Merge(responseDS.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();

//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        oDSPdtGroup.Clear();
//        oDSPdtGroup.Merge(responseDS.Tables[oDSPdtGroup.ProductGroup.TableName], false, MissingSchemaAction.Error);
//        oDSPdtGroup.AcceptChanges();
//        return oDSPdtGroup;
//    }//End of getMAG Method
//    public static DSProductGroup getASG()
//    {
//        DSProductGroup oDSPdtGroup = new DSProductGroup();
//        DSProductGroup.ProductGroupRow oDSPdtGroupRow = oDSPdtGroup.ProductGroup.NewProductGroupRow();
//        oDSPdtGroupRow.PdtGroupType = (short)Dictionary.ProductGroupType.ASG;
//        oDSPdtGroup.ProductGroup.AddProductGroupRow(oDSPdtGroupRow);
//        oDSPdtGroup.AcceptChanges();

//        DSAction oDSAction = new DSAction();
//        oDSAction.Action.AddActionRow(ActionID.ACTION_PG_GET_TID.ToString());
//        oDSAction.AcceptChanges();

//        DataSet oDSRequest = new DataSet();
//        oDSRequest.Merge(oDSPdtGroup);
//        oDSRequest.Merge(oDSAction);
//        oDSRequest.AcceptChanges();

//        BOProductGroup oBOPdtGroup = new BOProductGroup();
//        DataSet responseDS = oBOPdtGroup.Execute(oDSRequest);

//        DSError oDSErr = new DSError();
//        oDSErr.Merge(responseDS.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();

//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        oDSPdtGroup.Clear();
//        oDSPdtGroup.Merge(responseDS.Tables[oDSPdtGroup.ProductGroup.TableName], false, MissingSchemaAction.Error);
//        oDSPdtGroup.AcceptChanges();
//        return oDSPdtGroup;
//    }//End of getASG Method
//    public static DSProductGroup getAG()
//    {
//        DSProductGroup oDSPdtGroup = new DSProductGroup();
//        DSProductGroup.ProductGroupRow oDSPdtGroupRow = oDSPdtGroup.ProductGroup.NewProductGroupRow();
//        oDSPdtGroupRow.PdtGroupType = (short)Dictionary.ProductGroupType.AG;
//        oDSPdtGroup.ProductGroup.AddProductGroupRow(oDSPdtGroupRow);
//        oDSPdtGroup.AcceptChanges();

//        DSAction oDSAction = new DSAction();
//        oDSAction.Action.AddActionRow(ActionID.ACTION_PG_GET_TID.ToString());
//        oDSAction.AcceptChanges();

//        DataSet oDSRequest = new DataSet();
//        oDSRequest.Merge(oDSPdtGroup);
//        oDSRequest.Merge(oDSAction);
//        oDSRequest.AcceptChanges();

//        BOProductGroup oBOPdtGroup = new BOProductGroup();
//        DataSet responseDS = oBOPdtGroup.Execute(oDSRequest);

//        DSError oDSErr = new DSError();
//        oDSErr.Merge(responseDS.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();

//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        oDSPdtGroup.Clear();
//        oDSPdtGroup.Merge(responseDS.Tables[oDSPdtGroup.ProductGroup.TableName], false, MissingSchemaAction.Error);
//        oDSPdtGroup.AcceptChanges();
//        return oDSPdtGroup;
//    }//End of getAG Method
//    public static DSProductList getProductHeirarchyDetails(short nGroupType)
//    {
//        DSDataInteger oDSDataInteger;
//        DSProductList oDSProductList;

//        oDSDataInteger = new DSDataInteger();
//        oDSDataInteger.DataInteger.AddDataIntegerRow(Convert.ToInt64(nGroupType));
//        oDSDataInteger.AcceptChanges();

//        DSAction oDSAction = new DSAction();
//        oDSAction.Action.AddActionRow(ActionID.ACTION_GET_PRODUCT_HIERARCHY_DETAILS.ToString());
//        oDSAction.AcceptChanges();

//        DataSet oDSRequest = new DataSet();
//        oDSRequest.Merge(oDSDataInteger);
//        oDSRequest.Merge(oDSAction);
//        oDSRequest.AcceptChanges();

//        BOProductGroup oBOPdtGroup = new BOProductGroup();
//        DataSet responseDS = oBOPdtGroup.Execute(oDSRequest);

//        DSError oDSErr = new DSError();
//        oDSErr.Merge(responseDS.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();

//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        oDSProductList = new DSProductList();
//        oDSProductList.Merge(responseDS.Tables[oDSProductList.ProductList.TableName], false, MissingSchemaAction.Error);
//        oDSProductList.AcceptChanges();
//        return oDSProductList;
//    }
//    public static DSHSCode getHSCode()
//    {
//        DSHSCode oDSHSCode;
//        DSAction oDSAction;
//        DataSet oDSRequest;
//        DataSet oDSResponse;
//        DSError oDSErr;

//        BOHSCode oBOHSCode;

//        oDSAction = new DSAction();
//        oDSAction.Action.AddActionRow(ActionID.ACTION_HSCODE_GET_ALL.ToString());
//        oDSAction.AcceptChanges();

//        oDSRequest = new DataSet();

//        oDSRequest.Merge(oDSAction);
//        oDSRequest.AcceptChanges();


//        BOProductGroup oBOPdtGroup = new BOProductGroup();
//        oBOHSCode = new BOHSCode();

//        oDSResponse = oBOHSCode.Execute(oDSRequest);

//        oDSErr = new DSError();
//        oDSErr.Merge(oDSResponse.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();

//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }

//        oDSHSCode = new DSHSCode();
//        oDSHSCode.Merge(oDSResponse.Tables[oDSHSCode.HSCode.TableName], false, MissingSchemaAction.Error);
//        oDSHSCode.AcceptChanges();
//        return oDSHSCode;
//    }//End of getMAG Method

//    public static DSSupplier getSuplierList()
//    {
//        DSAction oDSAction;
//        DataSet oDSRequest;
//        DataSet oDSResponse;
//        DSError oDSError;
//        DSSupplier oDSSupplier;

//        oDSAction = new DSAction();
//        oDSAction.Action.AddActionRow(ActionID.ACTION_SUPPLIER_GET_ALL.ToString());
//        oDSAction.AcceptChanges();

//        oDSRequest = new DataSet();
//        oDSRequest.Merge(oDSAction);
//        oDSRequest.AcceptChanges();

//        BOSupplier oBOSupplier;
//        oBOSupplier = new BOSupplier();
//        oDSResponse = oBOSupplier.Execute(oDSRequest);

//        oDSError = new DSError();
//        oDSError.Merge(oDSResponse.Tables[oDSError.Error.TableName], false, MissingSchemaAction.Error);
//        oDSError.AcceptChanges();
//        if (oDSError.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSError.GetXml());
//            return null;
//        }
//        oDSSupplier = new DSSupplier();
//        oDSSupplier.Merge(oDSResponse.Tables[oDSSupplier.Supplier.TableName], false, MissingSchemaAction.Error);
//        oDSSupplier.AcceptChanges();

//        return oDSSupplier;
//    }
//    public static DSProductTargetGroup getProductTagetGroup()
//    {
//        DSAction oDSAction;
//        DataSet oDSRequest;
//        DataSet oDSResponse;
//        DSError oDSError;
//        DSProductTargetGroup oDSProductTargetGroup;

//        oDSAction = new DSAction();
//        oDSAction.Action.AddActionRow(ActionID.ACTION_PRODUCTTARGETGROUP_GET_LIST.ToString());
//        oDSAction.AcceptChanges();

//        oDSRequest = new DataSet();
//        oDSRequest.Merge(oDSAction);
//        oDSRequest.AcceptChanges();

//        BOProductTargetGroup oBOProductTargetGroup;
//        oBOProductTargetGroup = new BOProductTargetGroup();
//        oDSResponse = oBOProductTargetGroup.Execute(oDSRequest);

//        oDSError = new DSError();
//        oDSError.Merge(oDSResponse.Tables[oDSError.Error.TableName], false, MissingSchemaAction.Error);
//        oDSError.AcceptChanges();
//        if (oDSError.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSError.GetXml());
//            return null;
//        }
//        oDSProductTargetGroup = new DSProductTargetGroup();
//        oDSProductTargetGroup.Merge(oDSResponse.Tables[oDSProductTargetGroup.ProductTargetGroup.TableName], false, MissingSchemaAction.Error);
//        oDSProductTargetGroup.AcceptChanges();

//        return oDSProductTargetGroup;
//    }
//    public static DSProductTargetGroupSubType getProductTagetGroupSubType()
//    {
//        DSAction oDSAction;
//        DataSet oDSRequest;
//        DataSet oDSResponse;
//        DSError oDSError;
//        DSProductTargetGroupSubType oDSProductTargetGroupSubType;

//        oDSAction = new DSAction();
//        oDSAction.Action.AddActionRow(ActionID.ACTION_PRODUCTTARGETGROUPSUBTYPE_GET_LIST.ToString());
//        oDSAction.AcceptChanges();

//        oDSRequest = new DataSet();
//        oDSRequest.Merge(oDSAction);
//        oDSRequest.AcceptChanges();

//        BOProductTargetGroup oBOProductTargetGroup;
//        oBOProductTargetGroup = new BOProductTargetGroup();
//        oDSResponse = oBOProductTargetGroup.Execute(oDSRequest);

//        oDSError = new DSError();
//        oDSError.Merge(oDSResponse.Tables[oDSError.Error.TableName], false, MissingSchemaAction.Error);
//        oDSError.AcceptChanges();
//        if (oDSError.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSError.GetXml());
//            return null;
//        }
//        oDSProductTargetGroupSubType = new DSProductTargetGroupSubType();
//        oDSProductTargetGroupSubType.Merge(oDSResponse.Tables[oDSProductTargetGroupSubType.ProductTargetGroupSubType.TableName], false, MissingSchemaAction.Error);
//        oDSProductTargetGroupSubType.AcceptChanges();

//        return oDSProductTargetGroupSubType;
//    }
//    public static DSProductTargetGroupType getProductTagetGroupType()
//    {
//        DSAction oDSAction;
//        DataSet oDSRequest;
//        DataSet oDSResponse;
//        DSError oDSError;
//        DSProductTargetGroupType oDSProductTargetGroupType;

//        oDSAction = new DSAction();
//        oDSAction.Action.AddActionRow(ActionID.ACTION_PRODUCTTARGETGROUPTYPE_GET_LIST.ToString());
//        oDSAction.AcceptChanges();

//        oDSRequest = new DataSet();
//        oDSRequest.Merge(oDSAction);
//        oDSRequest.AcceptChanges();

//        BOProductTargetGroup oBOProductTargetGroup;
//        oBOProductTargetGroup = new BOProductTargetGroup();
//        oDSResponse = oBOProductTargetGroup.Execute(oDSRequest);

//        oDSError = new DSError();
//        oDSError.Merge(oDSResponse.Tables[oDSError.Error.TableName], false, MissingSchemaAction.Error);
//        oDSError.AcceptChanges();
//        if (oDSError.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSError.GetXml());
//            return null;
//        }
//        oDSProductTargetGroupType = new DSProductTargetGroupType();
//        oDSProductTargetGroupType.Merge(oDSResponse.Tables[oDSProductTargetGroupType.ProductTargetGroupType.TableName], false, MissingSchemaAction.Error);
//        oDSProductTargetGroupType.AcceptChanges();

//        return oDSProductTargetGroupType;
//    }
//    public static DSChannel getChannelList()
//    {
//        DSAction oDSAction = new DSAction();
//        DataSet oDSRequest = new DataSet();
//        DataSet oDSResponse = new DataSet();

//        oDSAction.Action.AddActionRow(ActionID.ACTION_CHANNEL_All_GET.ToString());
//        oDSAction.AcceptChanges();

//        oDSRequest.Merge(oDSAction);
//        oDSRequest.AcceptChanges();
//        BOChannel oBOChannel = new BOChannel();
//        oDSResponse = oBOChannel.Execute(oDSRequest);
//        DSError oDSErr = new DSError();
//        oDSErr.Merge(oDSResponse.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();
//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        DSChannel oDSChannel = new DSChannel();

//        oDSChannel.Merge(oDSResponse.Tables[oDSChannel.Channel.TableName], false, MissingSchemaAction.Error);
//        oDSChannel.AcceptChanges();

//        return oDSChannel;
//    } //End of getChannelList Method 
//    public static DSCustomerType getCustomerTypeListforChannel(DSCustomerType oDSCustomerType)
//    {
//        //DSCustomerType oDSCustomerType = new DSCustomerType();

//        DSAction oDSAction = new DSAction();
//        oDSAction.Action.AddActionRow(ActionID.ACTION_CUSTOMERTYPE_GET_BY_CHANNELID.ToString());
//        oDSAction.AcceptChanges();

//        DataSet oDSRequest = new DataSet();
//        DataSet oDSResponse = new DataSet();
//        oDSRequest.Merge(oDSAction);
//        oDSRequest.Merge(oDSCustomerType);
//        oDSRequest.AcceptChanges();

//        BOCustomerType oBOCustomerType = new BOCustomerType();
//        oDSResponse = oBOCustomerType.Execute(oDSRequest);

//        DSError oDSErr = new DSError();
//        oDSErr.Merge(oDSResponse.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();

//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        else
//        {
//            oDSCustomerType.Clear();
//            oDSCustomerType.Merge(oDSResponse.Tables[oDSCustomerType.CustomerType.TableName], false, MissingSchemaAction.Error);
//            oDSCustomerType.AcceptChanges();
//            return oDSCustomerType;
//        }
//    }//End of getCustomerTypeListforChannel Method 
//    public static DSCustomerType getCustomerTypeList()
//    {
//        DSCustomerType oDSCustomerType = new DSCustomerType();

//        DSAction oDSAction = new DSAction();
//        oDSAction.Action.AddActionRow(ActionID.ACTION_CUSTOMERTYPE_All_GET.ToString());
//        oDSAction.AcceptChanges();

//        DataSet oDSRequest = new DataSet();
//        DataSet oDSResponse = new DataSet();
//        oDSRequest.Merge(oDSAction);
//        oDSRequest.AcceptChanges();

//        BOCustomerType oBOCustomerType = new BOCustomerType();
//        oDSResponse = oBOCustomerType.Execute(oDSRequest);

//        DSError oDSErr = new DSError();
//        oDSErr.Merge(oDSResponse.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();

//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        else
//        {
//            oDSCustomerType.Clear();
//            oDSCustomerType.Merge(oDSResponse.Tables[oDSCustomerType.CustomerType.TableName], false, MissingSchemaAction.Error);
//            oDSCustomerType.AcceptChanges();
//            return oDSCustomerType;
//        }
//    } //End of getCustomerTypeList Method 
//    public static DSBrand getBrandList()
//    {
//        DSAction oDSAction = new DSAction();
//        DataSet oDSRequest = new DataSet();
//        DataSet oDSResponse = new DataSet();

//        oDSAction.Action.AddActionRow(ActionID.ACTION_BRAND_GET_LIST.ToString());
//        oDSAction.AcceptChanges();

//        oDSRequest.Merge(oDSAction);
//        oDSRequest.AcceptChanges();
//        BOBrand oBOBrand = new BOBrand();
//        oDSResponse = oBOBrand.Execute(oDSRequest);
//        DSError oDSErr = new DSError();
//        oDSErr.Merge(oDSResponse.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();
//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        DSBrand oDSBrand = new DSBrand();

//        oDSBrand.Merge(oDSResponse.Tables[oDSBrand.Brand.TableName], false, MissingSchemaAction.Error);
//        oDSBrand.AcceptChanges();

//        return oDSBrand;
//    } //End of getBrandList Method 
//    public static DSBrand getSubBrandList()
//    {
//        DSAction oDSAction = new DSAction();
//        DataSet oDSRequest = new DataSet();
//        DataSet oDSResponse = new DataSet();

//        oDSAction.Action.AddActionRow(ActionID.ACTION_SUB_BRAND_GET_LIST.ToString());
//        oDSAction.AcceptChanges();

//        oDSRequest.Merge(oDSAction);
//        oDSRequest.AcceptChanges();
//        BOBrand oBOBrand = new BOBrand();
//        oDSResponse = oBOBrand.Execute(oDSRequest);
//        DSError oDSErr = new DSError();
//        oDSErr.Merge(oDSResponse.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();
//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        DSBrand oDSBrand = new DSBrand();

//        oDSBrand.Merge(oDSResponse.Tables[oDSBrand.Brand.TableName], false, MissingSchemaAction.Error);
//        oDSBrand.AcceptChanges();

//        return oDSBrand;
//    } //End of getBrandList Method 
//    public static DSProductStockTranType getProductStockTranType()
//    {
//        DSAction oDSAction = new DSAction();
//        DataSet oDSRequest = new DataSet();
//        DataSet oDSResponse = new DataSet();
//        DSProductStockTranType oDSProductStockTranType;
//        oDSAction.Action.AddActionRow(ActionID.ACTION_PRODUCTSTOCKTRANTYPE_ALL_GET.ToString());
//        oDSAction.AcceptChanges();

//        oDSRequest.Merge(oDSAction);
//        oDSRequest.AcceptChanges();
//        BOProductStockTranType oBOProductStockTranType = new BOProductStockTranType();
//        oDSResponse = oBOProductStockTranType.Execute(oDSRequest);
//        DSError oDSErr = new DSError();
//        oDSErr.Merge(oDSResponse.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();
//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        oDSProductStockTranType = new DSProductStockTranType();
//        oDSProductStockTranType.Merge(oDSResponse.Tables[oDSProductStockTranType.ProductStockTranType.TableName], false, MissingSchemaAction.Error);
//        oDSProductStockTranType.AcceptChanges();

//        return oDSProductStockTranType;
//    } //End of getProductStockTranType Method         
//    /// <summary>
//    /// All System and User Defined Stock Transaction Data Type
//    /// </summary>
//    /// <returns></returns>
//    public static DSProductStockTranType getProductStockTranTypeList()
//    {
//        DSAction oDSAction = new DSAction();
//        DataSet oDSRequest = new DataSet();
//        DataSet oDSResponse = new DataSet();
//        DSProductStockTranType oDSProductStockTranType;
//        oDSAction.Action.AddActionRow(ActionID.ACTION_PRODUCTSTOCKTRANTYPE_LIST_GET.ToString());
//        oDSAction.AcceptChanges();

//        oDSRequest.Merge(oDSAction);
//        oDSRequest.AcceptChanges();
//        BOProductStockTranType oBOProductStockTranType = new BOProductStockTranType();
//        oDSResponse = oBOProductStockTranType.Execute(oDSRequest);
//        DSError oDSErr = new DSError();
//        oDSErr.Merge(oDSResponse.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();
//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        oDSProductStockTranType = new DSProductStockTranType();
//        oDSProductStockTranType.Merge(oDSResponse.Tables[oDSProductStockTranType.ProductStockTranType.TableName], false, MissingSchemaAction.Error);
//        oDSProductStockTranType.AcceptChanges();

//        return oDSProductStockTranType;
//    } //End of getProductStockTranType Method         
//    public static DSProductList getDetailProductList()
//    {
//        DSAction oDSAction = new DSAction();
//        DataSet oDSRequest = new DataSet();
//        DataSet oDSResponse = new DataSet();
//        DSProductList oDSProductList;
//        oDSAction.Action.AddActionRow(ActionID.ACTION_Q_PRODUCT_LIST_WITH_CURRENT_PRICE.ToString());
//        oDSAction.AcceptChanges();

//        oDSRequest.Merge(oDSAction);
//        oDSRequest.AcceptChanges();
//        BOProduct oBOProduct = new BOProduct();
//        oDSResponse = oBOProduct.Execute(oDSRequest);
//        DSError oDSErr = new DSError();
//        oDSErr.Merge(oDSResponse.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();
//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        oDSProductList = new DSProductList();

//        oDSProductList.Merge(oDSResponse.Tables[oDSProductList.ProductList.TableName], false, MissingSchemaAction.Error);
//        oDSProductList.AcceptChanges();

//        return oDSProductList;
//    } //End of getProductList Method         
//    public static DSProductList getProductDetailByCode(DSProductList oDSProductList)
//    {
//        DSAction oDSAction = new DSAction();
//        DataSet oDSRequest = new DataSet();
//        DataSet oDSResponse = new DataSet();
//        oDSAction.Action.AddActionRow(ActionID.ACTION_Q_PRODUCT_BY_CODE.ToString());
//        oDSAction.AcceptChanges();

//        oDSRequest.Merge(oDSAction);
//        oDSRequest.Merge(oDSProductList);
//        oDSRequest.AcceptChanges();
//        BOProduct oBOProduct = new BOProduct();
//        oDSResponse = oBOProduct.Execute(oDSRequest);
//        DSError oDSErr = new DSError();
//        oDSErr.Merge(oDSResponse.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();
//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        oDSProductList.Clear();
//        oDSProductList.Merge(oDSResponse.Tables[oDSProductList.ProductList.TableName], false, MissingSchemaAction.Error);
//        oDSProductList.AcceptChanges();

//        return oDSProductList;
//    } //End of getProductList Method         
//    public static DSProductList getProductPriceDetailByCode(DSProductList oDSProductList)
//    {
//        DSAction oDSAction = new DSAction();
//        DataSet oDSRequest = new DataSet();
//        DataSet oDSResponse = new DataSet();
//        oDSAction.Action.AddActionRow(ActionID.ACTION_Q_PRODUCT_LIST_WITH_PRICE_BY_CODE.ToString());
//        oDSAction.AcceptChanges();

//        oDSRequest.Merge(oDSAction);
//        oDSRequest.Merge(oDSProductList);
//        oDSRequest.AcceptChanges();
//        BOProduct oBOProduct = new BOProduct();
//        oDSResponse = oBOProduct.Execute(oDSRequest);
//        DSError oDSErr = new DSError();
//        oDSErr.Merge(oDSResponse.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();
//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        oDSProductList.Clear();
//        oDSProductList.Merge(oDSResponse.Tables[oDSProductList.ProductList.TableName], false, MissingSchemaAction.Error);
//        oDSProductList.AcceptChanges();

//        return oDSProductList;
//    } //End of getProductList Method         
//    public static DSProductList getProductPriceDetail()
//    {
//        DSAction oDSAction;
//        DataSet oDSRequest;
//        DataSet oDSResponse;
//        DSError oDSErr;
//        DSProductList oDSProductList;

//        oDSAction = new DSAction();
//        oDSAction.Action.AddActionRow(ActionID.ACTION_Q_PRODUCT_LIST_WITH_PRICE.ToString());
//        oDSAction.AcceptChanges();

//        oDSRequest = new DataSet();
//        oDSRequest.Merge(oDSAction);
//        oDSRequest.AcceptChanges();
//        BOProduct oBOProduct;
//        oBOProduct = new BOProduct();
//        oDSResponse = oBOProduct.Execute(oDSRequest);

//        oDSErr = new DSError();
//        oDSErr.Merge(oDSResponse.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();
//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        oDSProductList = new DSProductList();
//        oDSProductList.Merge(oDSResponse.Tables[oDSProductList.ProductList.TableName], false, MissingSchemaAction.Error);
//        oDSProductList.AcceptChanges();
//        return oDSProductList;
//    } //End of getProductList Method         
//    public static DSProductList getProductDetailWithCurrentPrice()
//    {
//        DSAction oDSAction;
//        DataSet oDSRequest;
//        DataSet oDSResponse;
//        DSError oDSErr;
//        DSProductList oDSProductList;

//        oDSAction = new DSAction();
//        oDSAction.Action.AddActionRow(ActionID.ACTION_Q_PRODUCT_LIST_WITH_CURRENT_PRICE.ToString());
//        oDSAction.AcceptChanges();

//        oDSRequest = new DataSet();
//        oDSRequest.Merge(oDSAction);
//        oDSRequest.AcceptChanges();
//        BOProduct oBOProduct;
//        oBOProduct = new BOProduct();
//        oDSResponse = oBOProduct.Execute(oDSRequest);

//        oDSErr = new DSError();
//        oDSErr.Merge(oDSResponse.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();
//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        oDSProductList = new DSProductList();
//        oDSProductList.Merge(oDSResponse.Tables[oDSProductList.ProductList.TableName], false, MissingSchemaAction.Error);
//        oDSProductList.AcceptChanges();
//        return oDSProductList;
//    } //End of getProductList Method         
//    public static DSProductProvissionChannelWise getProductProvissionList()
//    {
//        DSAction oDSAction;
//        DataSet oDSRequest;
//        DataSet oDSResponse;
//        DSError oDSErr;
//        DSProductProvissionChannelWise oDSProductProvission;

//        oDSAction = new DSAction();
//        oDSAction.Action.AddActionRow(ActionID.ACTION_PRODUCT_PROVISSISON_GET_LIST.ToString());
//        oDSAction.AcceptChanges();

//        oDSRequest = new DataSet();
//        oDSRequest.Merge(oDSAction);
//        oDSRequest.AcceptChanges();
//        BOProductProvissionChannelWise oBOProductProvission;
//        oBOProductProvission = new BOProductProvissionChannelWise();
//        oDSResponse = oBOProductProvission.Execute(oDSRequest);

//        oDSErr = new DSError();
//        oDSErr.Merge(oDSResponse.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();
//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        oDSProductProvission = new DSProductProvissionChannelWise();
//        oDSProductProvission.Merge(oDSResponse.Tables[oDSProductProvission.ProductProvissionChannelWise.TableName], false, MissingSchemaAction.Error);
//        oDSProductProvission.AcceptChanges();
//        return oDSProductProvission;
//    } //End of getProductProvissionList Method  
//    public static DSChannelAndProductStockPlaning getProductPlaningList()
//    {
//        DSAction oDSAction;
//        DataSet oDSRequest;
//        DataSet oDSResponse;
//        DSError oDSErr;
//        DSChannelAndProductStockPlaning oDSProductPlaning;

//        oDSAction = new DSAction();
//        oDSAction.Action.AddActionRow(ActionID.ACTION_PRODUCT_STOCK_PLANING_GET_LIST.ToString());
//        oDSAction.AcceptChanges();

//        oDSRequest = new DataSet();
//        oDSRequest.Merge(oDSAction);
//        oDSRequest.AcceptChanges();
//        BOChannelAndProductStockPlaning oBOProductPlaning;
//        oBOProductPlaning = new BOChannelAndProductStockPlaning();
//        oDSResponse = oBOProductPlaning.Execute(oDSRequest);

//        oDSErr = new DSError();
//        oDSErr.Merge(oDSResponse.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();
//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        oDSProductPlaning = new DSChannelAndProductStockPlaning();
//        oDSProductPlaning.Merge(oDSResponse.Tables[oDSProductPlaning.SBUAndProductStockPlaning.TableName], false, MissingSchemaAction.Error);
//        oDSProductPlaning.AcceptChanges();
//        return oDSProductPlaning;
//    } //End of getProductPlaningList Method  
//    public static DSMarketGroup getNewAreaList()
//    {
//        DSMarketGroup oDSMarketGroup = new DSMarketGroup();
//        DSMarketGroupType oDSMarketGroupType = new DSMarketGroupType();
//        oDSMarketGroupType.Clear();
//        string Str_MarketGroup = ConfigurationManager.AppSettings["MarketGroupType"];
//        oDSMarketGroupType.ReadXml(Str_MarketGroup);

//        foreach (DSMarketGroupType.MarketGroupTypeRow oDSMarketGroupTypeRow in oDSMarketGroupType.MarketGroupType)
//        {
//            if (oDSMarketGroupTypeRow.MarketTypeID == (int)Dictionary.MarketGroupType.Area)
//            {
//                DSMarketGroup.MarketGroupRow oDSMarketGroupRow = oDSMarketGroup.MarketGroup.NewMarketGroupRow();
//                oDSMarketGroupRow.MarketGroupType = oDSMarketGroupTypeRow.MarketTypeID;
//                oDSMarketGroup.MarketGroup.AddMarketGroupRow(oDSMarketGroupRow);
//                oDSMarketGroup.AcceptChanges();
//                break;
//            }
//        }
//        DSAction oDSAction = new DSAction();
//        oDSAction.Action.AddActionRow(ActionID.Action_MarketGroup_All_GET.ToString());
//        oDSAction.AcceptChanges();

//        DataSet oDSRequest = new DataSet();
//        DataSet oDSResponse = new DataSet();
//        oDSRequest.Merge(oDSMarketGroup, false);
//        oDSRequest.Merge(oDSAction, false);
//        oDSRequest.AcceptChanges();
//        //DataSet oDSResponse = new DataSet();
//        BOMarketGroup oBOMarketGroup = new BOMarketGroup();
//        oDSResponse = oBOMarketGroup.Execute(oDSRequest);

//        DSError oDSErr = new DSError();
//        oDSErr.Merge(oDSResponse.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();

//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        else
//        {
//            oDSMarketGroup.Clear();
//            oDSMarketGroup.Merge(oDSResponse.Tables[oDSMarketGroup.MarketGroup.TableName], false, MissingSchemaAction.Error);
//            oDSMarketGroup.AcceptChanges();
//            return oDSMarketGroup;
//        }
//    } //End of get New AreaList Method 
//    public static DSMarketGroup getNewTerritoryListForArea(DSMarketGroup oDSMarketGroup)
//    {
//        //DSMarketGroup oDSMarketGroup = new DSMarketGroup();
//        DSMarketGroupType oDSMarketGroupType = new DSMarketGroupType();
//        //oDSMarketGroupType.Clear();
//        //string Str_MarketGroup = ConfigurationManager.AppSettings["MarketGroupType"];
//        //oDSMarketGroupType.ReadXml(Str_MarketGroup);

//        //foreach (DSMarketGroupType.MarketGroupTypeRow oDSMarketGroupTypeRow in oDSMarketGroupType.MarketGroupType)
//        //{
//        //    if (oDSMarketGroupTypeRow.MarketTypeID == (int)Dictionary.MarketGroupType.Territory)
//        //    {
//        //        DSMarketGroup.MarketGroupRow oDSMarketGroupRow = oDSMarketGroup.MarketGroup.NewMarketGroupRow();
//        //        oDSMarketGroupRow.MarketGroupType = oDSMarketGroupTypeRow.MarketTypeID;
//        //        oDSMarketGroup.MarketGroup.AddMarketGroupRow(oDSMarketGroupRow);
//        //        oDSMarketGroup.AcceptChanges();
//        //        break;
//        //    }
//        //}
//        DSAction oDSAction = new DSAction();
//        oDSAction.Action.AddActionRow(ActionID.ACTION_MARKETGROUP_GET_ALL_FOR_PARTICULAR_PARENTID.ToString());
//        oDSAction.AcceptChanges();

//        DataSet oDSRequest = new DataSet();
//        DataSet oDSResponse = new DataSet();
//        oDSRequest.Merge(oDSMarketGroup, false);
//        oDSRequest.Merge(oDSAction, false);
//        oDSRequest.AcceptChanges();
//        //DataSet oDSResponse = new DataSet();
//        BOMarketGroup oBOMarketGroup = new BOMarketGroup();
//        oDSResponse = oBOMarketGroup.Execute(oDSRequest);

//        DSError oDSErr = new DSError();
//        oDSErr.Merge(oDSResponse.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();

//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        else
//        {
//            oDSMarketGroup.Clear();
//            oDSMarketGroup.Merge(oDSResponse.Tables[oDSMarketGroup.MarketGroup.TableName], false, MissingSchemaAction.Error);
//            oDSMarketGroup.AcceptChanges();
//            return oDSMarketGroup;
//        }
//    } //End of get New TerritoryList for Area Method 
//    public static DSMarketGroup getNewTerritoryList()
//    {
//        DSMarketGroup oDSMarketGroup = new DSMarketGroup();
//        DSMarketGroupType oDSMarketGroupType = new DSMarketGroupType();
//        oDSMarketGroupType.Clear();
//        string Str_MarketGroup = ConfigurationManager.AppSettings["MarketGroupType"];
//        oDSMarketGroupType.ReadXml(Str_MarketGroup);

//        foreach (DSMarketGroupType.MarketGroupTypeRow oDSMarketGroupTypeRow in oDSMarketGroupType.MarketGroupType)
//        {
//            if (oDSMarketGroupTypeRow.MarketTypeID == (int)Dictionary.MarketGroupType.Territory)
//            {
//                DSMarketGroup.MarketGroupRow oDSMarketGroupRow = oDSMarketGroup.MarketGroup.NewMarketGroupRow();
//                oDSMarketGroupRow.MarketGroupType = oDSMarketGroupTypeRow.MarketTypeID;
//                oDSMarketGroup.MarketGroup.AddMarketGroupRow(oDSMarketGroupRow);
//                oDSMarketGroup.AcceptChanges();
//                break;
//            }
//        }
//        DSAction oDSAction = new DSAction();
//        oDSAction.Action.AddActionRow(ActionID.Action_MarketGroup_All_GET.ToString());
//        oDSAction.AcceptChanges();

//        DataSet oDSRequest = new DataSet();
//        DataSet oDSResponse = new DataSet();
//        oDSRequest.Merge(oDSMarketGroup, false);
//        oDSRequest.Merge(oDSAction, false);
//        oDSRequest.AcceptChanges();
//        //DataSet oDSResponse = new DataSet();
//        BOMarketGroup oBOMarketGroup = new BOMarketGroup();
//        oDSResponse = oBOMarketGroup.Execute(oDSRequest);

//        DSError oDSErr = new DSError();
//        oDSErr.Merge(oDSResponse.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();

//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        else
//        {
//            oDSMarketGroup.Clear();
//            oDSMarketGroup.Merge(oDSResponse.Tables[oDSMarketGroup.MarketGroup.TableName], false, MissingSchemaAction.Error);
//            oDSMarketGroup.AcceptChanges();
//            return oDSMarketGroup;
//        }
//    } //End of get New TerritoryList Method 
//    public static DSGeoLocation getDistrictList()
//    {
//        DSGeoLocation oDSGeolocation = new DSGeoLocation();
//        DSGeoLocationType oDSGeolocationType = new DSGeoLocationType();
//        oDSGeolocationType.Clear();
//        string Str_GeoLocation = ConfigurationManager.AppSettings["GeoLocationType"];
//        oDSGeolocationType.ReadXml(Str_GeoLocation);


//        foreach (DSGeoLocationType.GeoLocationTypeRow oDSGeoLocationRow in oDSGeolocationType.GeoLocationType)
//        {
//            if (oDSGeoLocationRow.GeoLocationTypeID == (int)Dictionary.GeoLocationType.District)
//            {
//                DSGeoLocation.GeoLocationRow oGeoLocationRow = oDSGeolocation.GeoLocation.NewGeoLocationRow();
//                oGeoLocationRow.GeoLocationTypeID = oDSGeoLocationRow.GeoLocationTypeID;
//                oDSGeolocation.GeoLocation.AddGeoLocationRow(oGeoLocationRow);
//                oDSGeolocation.AcceptChanges();
//                break;
//            }
//        }
//        DSAction oDSAction = new DSAction();
//        oDSAction.Action.AddActionRow(ActionID.Action_GeoLocation_All_GET.ToString());
//        oDSAction.AcceptChanges();

//        DataSet oDSRequest = new DataSet();
//        DataSet oDSResponse = new DataSet();
//        oDSRequest.Merge(oDSGeolocation, false);
//        oDSRequest.Merge(oDSAction, false);
//        oDSRequest.AcceptChanges();
//        //DataSet oDSResponse = new DataSet();            
//        BOGeoLocation oBOGeolocation = new BOGeoLocation();
//        oDSResponse = oBOGeolocation.Execute(oDSRequest);

//        DSError oDSErr = new DSError();
//        oDSErr.Merge(oDSResponse.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();

//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        else
//        {
//            oDSGeolocation.Clear();
//            oDSGeolocation.Merge(oDSResponse.Tables[oDSGeolocation.GeoLocation.TableName], false, MissingSchemaAction.Error);
//            oDSGeolocation.AcceptChanges();
//            return oDSGeolocation;
//        }
//    } //End of get New DistrictList Method 
//    public static DSGeoLocation getThanaListForDistrict(DSGeoLocation oDSGeolocation)
//    {
//        // DSGeoLocation oDSGeolocation = new DSGeoLocation();
//        DSGeoLocationType oDSGeolocationType = new DSGeoLocationType();
//        //oDSGeolocationType.Clear();
//        //string Str_GeoLocation = ConfigurationManager.AppSettings["GeoLocationType"];
//        //oDSGeolocationType.ReadXml(Str_GeoLocation);

//        //foreach (DSGeoLocationType.GeoLocationTypeRow oDSGeoLocationRow in oDSGeolocationType.GeoLocationType)
//        //{
//        //    if (oDSGeoLocationRow.GeoLocationTypeID == (int)Dictionary.GeoLocationType.Thana)
//        //    {
//        //        DSGeoLocation.GeoLocationRow oGeoLocationRow = oDSGeolocation.GeoLocation.NewGeoLocationRow();
//        //        oGeoLocationRow.GeoLocationTypeID = oDSGeoLocationRow.GeoLocationTypeID;
//        //        oDSGeolocation.GeoLocation.AddGeoLocationRow(oGeoLocationRow);
//        //        oDSGeolocation.AcceptChanges();
//        //        break;
//        //    }
//        //}
//        DSAction oDSAction = new DSAction();
//        oDSAction.Action.AddActionRow(ActionID.ACTION_GEOLOCATION_GET_ALL_FOR_PARTICULAR_PARENTID.ToString());
//        oDSAction.AcceptChanges();

//        DataSet oDSRequest = new DataSet();
//        DataSet oDSResponse = new DataSet();
//        oDSRequest.Merge(oDSGeolocation, false);
//        oDSRequest.Merge(oDSAction, false);
//        oDSRequest.AcceptChanges();
//        //DataSet oDSResponse = new DataSet();            
//        BOGeoLocation oBOGeolocation = new BOGeoLocation();
//        oDSResponse = oBOGeolocation.Execute(oDSRequest);

//        DSError oDSErr = new DSError();
//        oDSErr.Merge(oDSResponse.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();

//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        else
//        {
//            oDSGeolocation.Clear();
//            oDSGeolocation.Merge(oDSResponse.Tables[oDSGeolocation.GeoLocation.TableName], false, MissingSchemaAction.Error);
//            oDSGeolocation.AcceptChanges();
//            return oDSGeolocation;
//        }
//    }//End of get New ThanaList for a District Method 
//    public static DSGeoLocation getThanaList()
//    {
//        DSGeoLocation oDSGeolocation = new DSGeoLocation();
//        DSGeoLocationType oDSGeolocationType = new DSGeoLocationType();
//        oDSGeolocationType.Clear();
//        string Str_GeoLocation = ConfigurationManager.AppSettings["GeoLocationType"];
//        oDSGeolocationType.ReadXml(Str_GeoLocation);

//        foreach (DSGeoLocationType.GeoLocationTypeRow oDSGeoLocationRow in oDSGeolocationType.GeoLocationType)
//        {
//            if (oDSGeoLocationRow.GeoLocationTypeID == (int)Dictionary.GeoLocationType.Thana)
//            {
//                DSGeoLocation.GeoLocationRow oGeoLocationRow = oDSGeolocation.GeoLocation.NewGeoLocationRow();
//                oGeoLocationRow.GeoLocationTypeID = oDSGeoLocationRow.GeoLocationTypeID;
//                oDSGeolocation.GeoLocation.AddGeoLocationRow(oGeoLocationRow);
//                oDSGeolocation.AcceptChanges();
//                break;
//            }
//        }
//        DSAction oDSAction = new DSAction();
//        oDSAction.Action.AddActionRow(ActionID.Action_GeoLocation_All_GET.ToString());
//        oDSAction.AcceptChanges();

//        DataSet oDSRequest = new DataSet();
//        DataSet oDSResponse = new DataSet();
//        oDSRequest.Merge(oDSGeolocation, false);
//        oDSRequest.Merge(oDSAction, false);
//        oDSRequest.AcceptChanges();
//        //DataSet oDSResponse = new DataSet();            
//        BOGeoLocation oBOGeolocation = new BOGeoLocation();
//        oDSResponse = oBOGeolocation.Execute(oDSRequest);

//        DSError oDSErr = new DSError();
//        oDSErr.Merge(oDSResponse.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();

//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        else
//        {
//            oDSGeolocation.Clear();
//            oDSGeolocation.Merge(oDSResponse.Tables[oDSGeolocation.GeoLocation.TableName], false, MissingSchemaAction.Error);
//            oDSGeolocation.AcceptChanges();
//            return oDSGeolocation;
//        }
//    } //End of get New ThanaList Method 

//    public static DSUser getUserList()
//    {
//        DSAction oDSAction = new DSAction();
//        DataSet oDSRequest = new DataSet();
//        DataSet oDSResponse = new DataSet();

//        oDSAction.Action.AddActionRow(ActionID.ACTION_Q_ALL_USER.ToString());
//        oDSAction.AcceptChanges();

//        oDSRequest.Merge(oDSAction);
//        oDSRequest.AcceptChanges();
//        BOUser oBOUser = new BOUser();
//        oDSResponse = oBOUser.Execute(oDSRequest);
//        DSError oDSErr = new DSError();
//        oDSErr.Merge(oDSResponse.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();
//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        DSUser oDSUser = new DSUser();

//        oDSUser.Merge(oDSResponse.Tables[oDSUser.User.TableName], false, MissingSchemaAction.Error);
//        oDSUser.AcceptChanges();

//        return oDSUser;
//    } //End of getUserList Method 
//    public static DSCustomerCreditUser getCustomerCreditUserList()
//    {
//        DSAction oDSAction = new DSAction();
//        DataSet oDSRequest = new DataSet();
//        DataSet oDSResponse = new DataSet();

//        oDSAction.Action.AddActionRow(ActionID.ACTION_CUSTOMER_CREDIT_USER_All_GET.ToString());
//        oDSAction.AcceptChanges();

//        oDSRequest.Merge(oDSAction);
//        oDSRequest.AcceptChanges();
//        BOCustomerCreditUser oBOCustomerCreditUser = new BOCustomerCreditUser();
//        oDSResponse = oBOCustomerCreditUser.Execute(oDSRequest);
//        DSError oDSErr = new DSError();
//        oDSErr.Merge(oDSResponse.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();
//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        DSCustomerCreditUser oDSCustomerCreditUser = new DSCustomerCreditUser();

//        oDSCustomerCreditUser.Merge(oDSResponse.Tables[oDSCustomerCreditUser.CustomerCreditUser.TableName], false, MissingSchemaAction.Error);
//        oDSCustomerCreditUser.AcceptChanges();

//        return oDSCustomerCreditUser;
//    } //End of getCustomerCreditUserList Method 
//    public static DSCustomerTranType getCustomerTranType(DSCustomerTranType oDSCustomerTranType)
//    {
//        DSAction oDSAction = new DSAction();
//        BOCustomerTranType oBOCustomerTranType = new BOCustomerTranType();
//        DataSet oDSRequest = new DataSet();
//        DataSet oDSResponse = new DataSet();
//        DSError oDSErr = new DSError();

//        oDSAction.Action.AddActionRow(ActionID.ACTION_CUSTOMERTRANTYPE_GET.ToString());
//        oDSRequest.Clear();
//        oDSRequest.Merge(oDSAction, false);
//        oDSRequest.Merge(oDSCustomerTranType, false);
//        oDSRequest.AcceptChanges();
//        oDSResponse = oBOCustomerTranType.Execute(oDSRequest);
//        oDSErr.Clear();
//        oDSErr.Merge(oDSResponse.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();
//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        oDSCustomerTranType.Clear();
//        oDSCustomerTranType.Merge(oDSResponse.Tables[oDSCustomerTranType.CustomerTranType.TableName], false, MissingSchemaAction.Error);
//        oDSCustomerTranType.AcceptChanges();
//        return oDSCustomerTranType;
//    }//End of getCustomerTranType Method 
//    public static DSBank getBankList()
//    {
//        DataSet oDSRequest = new DataSet();
//        DataSet oDSResponse = new DataSet();
//        DSAction oDSAction = new DSAction();
//        DSError oDSError = new DSError();

//        BOBank oBOBank = new BOBank();
//        DSBank oDSBank = new DSBank();

//        oDSAction.Action.AddActionRow(ActionID.ACTION_BANK_GET_LIST.ToString());
//        oDSAction.AcceptChanges();
//        oDSRequest.Merge(oDSAction, false);
//        oDSRequest.AcceptChanges();

//        oDSResponse = oBOBank.Execute(oDSRequest);
//        oDSBank.Clear();
//        oDSError.Clear();
//        oDSError.Merge(oDSResponse.Tables[oDSError.Error.TableName], false, MissingSchemaAction.Error);
//        oDSError.AcceptChanges();

//        if (oDSError.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSError.GetXml());
//            return null;
//        }
//        else
//        {
//            oDSBank.Merge(oDSResponse.Tables[oDSBank.Bank.TableName], false, MissingSchemaAction.Error);
//            oDSBank.AcceptChanges();

//            return oDSBank;
//        }
//    }//End of getBankList Method 
//    public static DSBankBranch getBankBranchListforBank(DSBankBranch oDSBankBranch)
//    {
//        DataSet oDSRequest = new DataSet();
//        DataSet oDSResponse = new DataSet();
//        DSAction oDSAction = new DSAction();
//        DSError oDSError = new DSError();
//        //DSBankBranch oDSBankBranch = new DSBankBranch();

//        //BOBank oBOBank = new BOBank();
//        BOBankBranch oBOBankBranch = new BOBankBranch();

//        oDSAction.Action.AddActionRow(ActionID.ACTION_BANKBRANCH_GET_FOR_BANK.ToString());
//        oDSAction.AcceptChanges();

//        oDSRequest.Merge(oDSAction, false);
//        oDSRequest.Merge(oDSBankBranch, false);
//        oDSRequest.AcceptChanges();

//        oDSResponse = oBOBankBranch.Execute(oDSRequest);
//        oDSBankBranch.Clear();
//        oDSError.Clear();
//        oDSError.Merge(oDSResponse.Tables[oDSError.Error.TableName], false, MissingSchemaAction.Error);
//        oDSError.AcceptChanges();

//        if (oDSError.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSError.GetXml());
//            return null;
//        }
//        else
//        {
//            oDSBankBranch.Merge(oDSResponse.Tables[oDSBankBranch.BankBranch.TableName], false, MissingSchemaAction.Error);
//            oDSBankBranch.AcceptChanges();
//            return oDSBankBranch;
//        }
//    }//End of getBankBranchList Method 
//    public static DSCustomerTranType getAllTransactionType()
//    {
//        AppLogger.LogInfo("Find All Transection Type");
//        DataSet oDSRequest = new DataSet();
//        DataSet oDSResponse = new DataSet();
//        DSAction oDSAction = new DSAction();
//        DSError oDSError = new DSError();


//        BOCustomerTranType oBOCustomerTranType = new BOCustomerTranType();
//        DSCustomerTranType oDSCustomerTranType = new DSCustomerTranType();

//        oDSAction.Action.AddActionRow(ActionID.ACTION_CUSTOMERTRANTYPE_All_GET.ToString());
//        oDSAction.AcceptChanges();
//        oDSRequest.Merge(oDSAction, false);
//        oDSRequest.AcceptChanges();

//        oDSResponse = oBOCustomerTranType.Execute(oDSRequest);
//        oDSCustomerTranType.Clear();
//        oDSError.Clear();
//        oDSError.Merge(oDSResponse.Tables[oDSError.Error.TableName], false, MissingSchemaAction.Error);
//        oDSError.AcceptChanges();

//        if (oDSError.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSError.GetXml());
//            return null;
//        }
//        else
//        {
//            oDSCustomerTranType.Merge(oDSResponse.Tables[oDSCustomerTranType.CustomerTranType.TableName], false, MissingSchemaAction.Error);
//            oDSCustomerTranType.AcceptChanges();
//            return oDSCustomerTranType;
//        }
//    }//End of getAllCustomerTranType Method
//    public static DSCustomerTypeWisePriceSetting getCustomerTypeWisePriceSettingList()
//    {
//        DSAction oDSAction;
//        DataSet oDSRequest;
//        DataSet oDSResponse;
//        DSError oDSErr;
//        DSCustomerTypeWisePriceSetting oDSCustomerTypeWisePriceSetting;

//        oDSAction = new DSAction();
//        oDSAction.Action.AddActionRow(ActionID.ACTION_CUSTOMERTYPE_WISE_PRICE_SETTING_GET_LIST.ToString());
//        oDSAction.AcceptChanges();

//        oDSRequest = new DataSet();
//        oDSResponse = new DataSet();
//        oDSRequest.Merge(oDSAction);
//        oDSRequest.AcceptChanges();
//        BOCustomerTypeWisePriceSetting oBOCustomerTypeWisePriceSetting;
//        oBOCustomerTypeWisePriceSetting = new BOCustomerTypeWisePriceSetting();
//        oDSResponse = oBOCustomerTypeWisePriceSetting.Execute(oDSRequest);

//        oDSErr = new DSError();
//        oDSErr.Merge(oDSResponse.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();
//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        oDSCustomerTypeWisePriceSetting = new DSCustomerTypeWisePriceSetting();
//        oDSCustomerTypeWisePriceSetting.Merge(oDSResponse.Tables[oDSCustomerTypeWisePriceSetting.CustomerTypeWisePriceSetting.TableName], false, MissingSchemaAction.Error);
//        oDSCustomerTypeWisePriceSetting.AcceptChanges();
//        return oDSCustomerTypeWisePriceSetting;
//    } //End of getCustomerTypeWisePriceSettingList Method  

//    public static DSEmployee getEmployeeList()
//    {
//        DSAction oDSAction = new DSAction();
//        DataSet oDSRequest = new DataSet();
//        DataSet oDSResponse = new DataSet();

//        oDSAction.Action.AddActionRow(ActionID.ACTION_GET_EMPLOYEE_LIST.ToString());
//        oDSAction.AcceptChanges();

//        oDSRequest.Merge(oDSAction);
//        oDSRequest.AcceptChanges();
//        BOEmployee oBOEmployee = new BOEmployee();
//        oDSResponse = oBOEmployee.Execute(oDSRequest);
//        DSError oDSErr = new DSError();
//        oDSErr.Merge(oDSResponse.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();
//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        DSEmployee oDSEmployee = new DSEmployee();
//        oDSEmployee.Merge(oDSResponse.Tables[oDSEmployee.Employees.TableName], false, MissingSchemaAction.Error);
//        oDSEmployee.AcceptChanges();

//        return oDSEmployee;
//    } //End of getEmployeeList Method 
//    public static DSCompany getCompanyList()
//    {
//        DSAction oDSAction = new DSAction();
//        DataSet oDSRequest = new DataSet();
//        DataSet oDSResponse = new DataSet();

//        oDSAction.Action.AddActionRow(ActionID.ACTION_GET_COMPANY_LIST.ToString());
//        oDSAction.AcceptChanges();

//        oDSRequest.Merge(oDSAction);
//        oDSRequest.AcceptChanges();
//        BOCompany oBOCompany = new BOCompany();
//        oDSResponse = oBOCompany.Execute(oDSRequest);
//        DSError oDSErr = new DSError();
//        oDSErr.Merge(oDSResponse.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();
//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        DSCompany oDSCompany = new DSCompany();
//        oDSCompany.Merge(oDSResponse.Tables[oDSCompany.Company.TableName], false, MissingSchemaAction.Error);
//        oDSCompany.AcceptChanges();

//        return oDSCompany;
//    } //End of getCompanyList Method
//    public static DSSBU getSBUList()
//    {
//        DSAction oDSAction = new DSAction();
//        DataSet oDSRequest = new DataSet();
//        DataSet oDSResponse = new DataSet();

//        oDSAction.Action.AddActionRow(ActionID.ACTION_SBU_LIST.ToString());
//        oDSAction.AcceptChanges();

//        oDSRequest.Merge(oDSAction);
//        oDSRequest.AcceptChanges();
//        BOSbu oBOSbu = new BOSbu();
//        oDSResponse = oBOSbu.Execute(oDSRequest);
//        DSError oDSErr = new DSError();
//        oDSErr.Merge(oDSResponse.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();
//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        DSSBU oDSSbu = new DSSBU();
//        oDSSbu.Merge(oDSResponse.Tables[oDSSbu.SBU.TableName], false, MissingSchemaAction.Error);
//        oDSSbu.AcceptChanges();

//        return oDSSbu;
//    } //End of getSbuList Method
//    public static DSDesignation getDesignationList()
//    {
//        DSAction oDSAction = new DSAction();
//        DataSet oDSRequest = new DataSet();
//        DataSet oDSResponse = new DataSet();

//        oDSAction.Action.AddActionRow(ActionID.ACTION_DESIGNATION_GET.ToString());
//        oDSAction.AcceptChanges();

//        oDSRequest.Merge(oDSAction);
//        oDSRequest.AcceptChanges();
//        BODesignation oBODesignation = new BODesignation();
//        oDSResponse = oBODesignation.Execute(oDSRequest);
//        DSError oDSErr = new DSError();
//        oDSErr.Merge(oDSResponse.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();
//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        DSDesignation oDSDesignation = new DSDesignation();
//        oDSDesignation.Merge(oDSResponse.Tables[oDSDesignation.Designations.TableName], false, MissingSchemaAction.Error);
//        oDSDesignation.AcceptChanges();

//        return oDSDesignation;
//    } //End of getDesignationList Method
//    public static DSDepartment getDepartmentList()
//    {
//        DSAction oDSAction = new DSAction();
//        DataSet oDSRequest = new DataSet();
//        DataSet oDSResponse = new DataSet();

//        oDSAction.Action.AddActionRow(ActionID.ACTION_DEPARTMENT_GET.ToString());
//        oDSAction.AcceptChanges();

//        oDSRequest.Merge(oDSAction);
//        oDSRequest.AcceptChanges();
//        BODepartment oBODepartment = new BODepartment();
//        oDSResponse = oBODepartment.Execute(oDSRequest);
//        DSError oDSErr = new DSError();
//        oDSErr.Merge(oDSResponse.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();
//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        DSDepartment oDSDepartment = new DSDepartment();
//        oDSDepartment.Merge(oDSResponse.Tables[oDSDepartment.Department.TableName], false, MissingSchemaAction.Error);
//        oDSDepartment.AcceptChanges();

//        return oDSDepartment;
//    } //End of getDepartmentList Method
//    public static DSLocation getLocationList()
//    {
//        DSAction oDSAction = new DSAction();
//        DataSet oDSRequest = new DataSet();
//        DataSet oDSResponse = new DataSet();

//        oDSAction.Action.AddActionRow(ActionID.ACTION_LOCATION_GET.ToString());
//        oDSAction.AcceptChanges();

//        oDSRequest.Merge(oDSAction);
//        oDSRequest.AcceptChanges();
//        BOLocation oBOLocation = new BOLocation();
//        oDSResponse = oBOLocation.Execute(oDSRequest);
//        DSError oDSErr = new DSError();
//        oDSErr.Merge(oDSResponse.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();
//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        DSLocation oDSLocation = new DSLocation();
//        oDSLocation.Merge(oDSResponse.Tables[oDSLocation.Location.TableName], false, MissingSchemaAction.Error);
//        oDSLocation.AcceptChanges();

//        return oDSLocation;
//    } //End of getLocationList Method
//    public static DSGrade getGradeList()
//    {
//        DSAction oDSAction = new DSAction();
//        DataSet oDSRequest = new DataSet();
//        DataSet oDSResponse = new DataSet();

//        oDSAction.Action.AddActionRow(ActionID.ACTION_GRADE_GET.ToString());
//        oDSAction.AcceptChanges();

//        oDSRequest.Merge(oDSAction);
//        oDSRequest.AcceptChanges();
//        BOGrade oBOGrade = new BOGrade();
//        oDSResponse = oBOGrade.Execute(oDSRequest);
//        DSError oDSErr = new DSError();
//        oDSErr.Merge(oDSResponse.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();
//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        DSGrade oDSGrade = new DSGrade();
//        oDSGrade.Merge(oDSResponse.Tables[oDSGrade.Grade.TableName], false, MissingSchemaAction.Error);
//        oDSGrade.AcceptChanges();

//        return oDSGrade;
//    } //End of getGradeList Method

//    public static DSProductGroup getOldProductGroupList()
//    {
//        DSAction oDSAction = new DSAction();
//        DataSet oDSRequest = new DataSet();
//        DataSet oDSResponse = new DataSet();

//        oDSAction.Action.AddActionRow(ActionID.ACTION_GET_OLD_PRODUCT_GROUP_LIST.ToString());
//        oDSAction.AcceptChanges();

//        oDSRequest.Merge(oDSAction);
//        oDSRequest.AcceptChanges();
//        BOProductGroup oBOProductGroup = new BOProductGroup();
//        oDSResponse = oBOProductGroup.Execute(oDSRequest);
//        DSError oDSErr = new DSError();
//        oDSErr.Merge(oDSResponse.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();
//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        DSProductGroup oDSProductGroup = new DSProductGroup();
//        oDSProductGroup.Merge(oDSResponse.Tables[oDSProductGroup.ProductGroup.TableName], false, MissingSchemaAction.Error);
//        oDSProductGroup.AcceptChanges();

//        return oDSProductGroup;

//    } //End of getProductGroupList Method 
//    public static DSProductGroup getOldArticleGroupList()
//    {
//        DSAction oDSAction = new DSAction();
//        DataSet oDSRequest = new DataSet();
//        DataSet oDSResponse = new DataSet();

//        oDSAction.Action.AddActionRow(ActionID.ACTION_GET_OLD_ARTICLE_GROUP_LIST.ToString());
//        oDSAction.AcceptChanges();

//        oDSRequest.Merge(oDSAction);
//        oDSRequest.AcceptChanges();
//        BOProductGroup oBOProductGroup = new BOProductGroup();
//        oDSResponse = oBOProductGroup.Execute(oDSRequest);
//        DSError oDSErr = new DSError();
//        oDSErr.Merge(oDSResponse.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();
//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        DSProductGroup oDSProductGroup = new DSProductGroup();
//        oDSProductGroup.Merge(oDSResponse.Tables[oDSProductGroup.ProductGroup.TableName], false, MissingSchemaAction.Error);
//        oDSProductGroup.AcceptChanges();

//        return oDSProductGroup;

//    } //End of getArticleGroupList Method 
//    public static DSProductGroup getOldArticleSubGroupList()
//    {
//        DSAction oDSAction = new DSAction();
//        DataSet oDSRequest = new DataSet();
//        DataSet oDSResponse = new DataSet();

//        oDSAction.Action.AddActionRow(ActionID.ACTION_GET_OLD_ARTICLE_SUB_GROUP_LIST.ToString());
//        oDSAction.AcceptChanges();

//        oDSRequest.Merge(oDSAction);
//        oDSRequest.AcceptChanges();
//        BOProductGroup oBOProductGroup = new BOProductGroup();
//        oDSResponse = oBOProductGroup.Execute(oDSRequest);
//        DSError oDSErr = new DSError();
//        oDSErr.Merge(oDSResponse.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();
//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        DSProductGroup oDSProductGroup = new DSProductGroup();
//        oDSProductGroup.Merge(oDSResponse.Tables[oDSProductGroup.ProductGroup.TableName], false, MissingSchemaAction.Error);
//        oDSProductGroup.AcceptChanges();

//        return oDSProductGroup;

//    } //End of getArticleSubGroupList Method 
//    public static DSProductGroup getOldMainArticleGroupList()
//    {
//        DSAction oDSAction = new DSAction();
//        DataSet oDSRequest = new DataSet();
//        DataSet oDSResponse = new DataSet();

//        oDSAction.Action.AddActionRow(ActionID.ACTION_GET_OLD_MAIN_ARTICLE_GROUP_LIST.ToString());
//        oDSAction.AcceptChanges();

//        oDSRequest.Merge(oDSAction);
//        oDSRequest.AcceptChanges();
//        BOProductGroup oBOProductGroup = new BOProductGroup();
//        oDSResponse = oBOProductGroup.Execute(oDSRequest);
//        DSError oDSErr = new DSError();
//        oDSErr.Merge(oDSResponse.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();
//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        DSProductGroup oDSProductGroup = new DSProductGroup();
//        oDSProductGroup.Merge(oDSResponse.Tables[oDSProductGroup.ProductGroup.TableName], false, MissingSchemaAction.Error);
//        oDSProductGroup.AcceptChanges();

//        return oDSProductGroup;

//    } //End of getMainArticleGroupList Method 
//    public static DSMarketGroup getAreaList()
//    {
//        DSAction oDSAction = new DSAction();
//        DataSet oDSRequest = new DataSet();
//        DataSet oDSResponse = new DataSet();

//        oDSAction.Action.AddActionRow(ActionID.Action_Get_Old_Area_list.ToString());
//        oDSAction.AcceptChanges();

//        oDSRequest.Merge(oDSAction);
//        oDSRequest.AcceptChanges();
//        BOMarketGroup oBOMarketGroup = new BOMarketGroup();
//        oDSResponse = oBOMarketGroup.Execute(oDSRequest);
//        DSError oDSErr = new DSError();
//        oDSErr.Merge(oDSResponse.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();
//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        DSMarketGroup oDSMarketGroup = new DSMarketGroup();

//        oDSMarketGroup.Merge(oDSResponse.Tables[oDSMarketGroup.MarketGroup.TableName], false, MissingSchemaAction.Error);
//        oDSMarketGroup.AcceptChanges();

//        return oDSMarketGroup;


//    } //End of getAreaList Method 
//    public static DSMarketGroup getTerritoryList()
//    {
//        DSAction oDSAction = new DSAction();
//        DataSet oDSRequest = new DataSet();
//        DataSet oDSResponse = new DataSet();

//        oDSAction.Action.AddActionRow(ActionID.Action_Get_Old_Territory_List.ToString());
//        oDSAction.AcceptChanges();

//        oDSRequest.Merge(oDSAction);
//        oDSRequest.AcceptChanges();
//        BOMarketGroup oBOMarketGroup = new BOMarketGroup();
//        oDSResponse = oBOMarketGroup.Execute(oDSRequest);
//        DSError oDSErr = new DSError();
//        oDSErr.Merge(oDSResponse.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();
//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        DSMarketGroup oDSMarketGroup = new DSMarketGroup();

//        oDSMarketGroup.Merge(oDSResponse.Tables[oDSMarketGroup.MarketGroup.TableName], false, MissingSchemaAction.Error);
//        oDSMarketGroup.AcceptChanges();

//        return oDSMarketGroup;


//    } //End of getTerritoryList Method 
//    public static DSChannel getOldChannelList()
//    {
//        DSAction oDSAction = new DSAction();
//        DataSet oDSRequest = new DataSet();
//        DataSet oDSResponse = new DataSet();

//        oDSAction.Action.AddActionRow(ActionID.ACTION_GET_OLD_CHANNEL.ToString());
//        oDSAction.AcceptChanges();

//        oDSRequest.Merge(oDSAction);
//        oDSRequest.AcceptChanges();
//        BOChannel oBOChannel = new BOChannel();
//        oDSResponse = oBOChannel.Execute(oDSRequest);
//        DSError oDSErr = new DSError();
//        oDSErr.Merge(oDSResponse.Tables[oDSErr.Error.TableName], false, MissingSchemaAction.Error);
//        oDSErr.AcceptChanges();
//        if (oDSErr.Error.Count > 0)
//        {
//            AppLogger.LogError(oDSErr.GetXml());
//            return null;
//        }
//        DSChannel oDSChannel = new DSChannel();

//        oDSChannel.Merge(oDSResponse.Tables[oDSChannel.Channel.TableName], false, MissingSchemaAction.Error);
//        oDSAction.AcceptChanges();

//        return oDSChannel;

//    } //End of getTerritoryList Method
//    public static DataSet getInovoiceStatus()
//    {
//        DataSet oInvoiceStatus;
//        oInvoiceStatus = new DataSet();

//        DataTable table = new DataTable("OrderStatus");
//        DataColumn idColumn = new DataColumn("id",
//            Type.GetType("System.Int32"), "");
//        DataColumn itemColumn = new DataColumn("Status",
//            Type.GetType("System.String"), "");

//        oInvoiceStatus.Tables.Add(table);
//        table.Columns.Add(idColumn);
//        table.Columns.Add(itemColumn);
//        oInvoiceStatus.AcceptChanges();
//        DataRow oRow;
//        foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.InvoiceStatus)))
//        {
//            oRow = table.NewRow();
//            oRow[0] = GetEnum;
//            oRow[1] = Enum.GetName(typeof(Dictionary.InvoiceStatus), GetEnum);
//            oInvoiceStatus.Tables[0].Rows.Add(oRow);
//        }
//        oRow = table.NewRow();
//        oRow[1] = "<All>";
//        oInvoiceStatus.Tables[0].Rows.Add(oRow);
//        oInvoiceStatus.AcceptChanges();
//        return oInvoiceStatus;
//    }
//}




public class UIUtility
{
    public UIUtility()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public static string GetConfirmationMsg(string sActionTaken,
                                            string sEntity,
                                            string[] sSuccessCode,
                                            string[] sFailedCode,
                                            string sBackLink,
                                            int i)
    {
        /*

        <p>&nbsp;</p>
        <p align="center"><font face="Verdana" size="2">Following customers have been deleted successful:</font></p>
        <ol>
          <li><p align="center"><font face="Verdana" size="2">123</font></li>
          <li>
          <p align="center"><font face="Verdana" size="2">345</font></li>
          <li>
          <p align="center"><font face="Verdana" size="2">678</font></li>
        </ol>
        <p align="center"><font face="Verdana" size="2" color="#FF0000">Following customers have NOT been deleted successfully:</font></p>
        <ol>
          <li><p align="center"><font face="Verdana" size="2" color="#FF0000">123</font></li>
          <li>
          <p align="center"><font face="Verdana" size="2" color="#FF0000">345</font></li>
          <li>
          <p align="center"><font face="Verdana" size="2" color="#FF0000">678</font></li>
        </ol>
        <p align="center"><font face="Verdana" size="2"><a href="index.htm">Back</a></font></p>
        <p>&nbsp;</p>


        */
        string sOutput = String.Empty;
        string sTmp = String.Empty;
        string sSuccessMsg = "<p align=\"center\"><font face=\"Verdana\" size=\"2\">Msg:</font></p>";
        string sSuccessListItem = "<li><p align=\"center\"><font face=\"Verdana\" size=\"2\">Code</font></li>";
        string sFailedMsg = "<p align=\"center\"><font face=\"Verdana\" size=\"2\" color=\"#FF0000\">Msg:</font></p>";
        string sFailedListItem = "<li><p align=\"center\"><font face=\"Verdana\" size=\"2\" color=\"#FF0000\">Code</font></li>";
        string sBack = "<p align=\"center\"><font face=\"Verdana\" size=\"2\"><a href=\"LinkPage\">Back</a></font></p>";
        if (sSuccessCode != null && sSuccessCode.Length > 0)
        {
            if (sSuccessCode.Length > 1)
            {
                sTmp = sEntity + "s have been " + sActionTaken + " successfully";
            }
            else
            {
                sTmp = sEntity + " has been " + sActionTaken + " successfully";
            }

            sSuccessMsg = sSuccessMsg.Replace("Msg", sTmp);
            if (i != 0)
            {
                sSuccessMsg += "<ol>";

                foreach (string sItem in sSuccessCode)
                {
                    sTmp = sSuccessListItem.Replace("Code", sItem);
                    sSuccessMsg += sTmp;
                }
                sSuccessMsg += "</ol>";
            }
            sOutput += sSuccessMsg;

        }

        // now create the failed msg
        if (sFailedCode != null && sFailedCode.Length > 0)
        {
            if (sFailedCode.Length > 1)
            {
                sTmp = sEntity + "s have NOT been " + sActionTaken + " successfully";
            }
            else
            {
                sTmp = sEntity + " has NOT been " + sActionTaken + " successfully";
            }

            sFailedMsg = sFailedMsg.Replace("Msg", sTmp);
            sFailedMsg += "<ol>";

            if (i != 0)
            {
                foreach (string sItem in sFailedCode)
                {
                    sTmp = sFailedListItem.Replace("Code", sItem);
                    sFailedMsg += sTmp;
                }
                sFailedMsg += "</ol>";
                sOutput += sFailedMsg;
            }
        }


        if (sBackLink != null && sBackLink.Length > 0)
        {
            //        string sCommand = "javascript:history.back()";

            sTmp = sBack.Replace("LinkPage", sBackLink);
            sOutput += sTmp;
        }

        return sOutput;

    }

}

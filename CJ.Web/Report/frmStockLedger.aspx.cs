using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using CJ.Class;
using CJ.Class.Report;
using CJ.Report;
using CJ.Class.Web.UI.Class;


public partial class Report_frmStockLedger : System.Web.UI.Page
{

    private DateTime _dStartingDate;
    private DateTime _dEndingDate;
    RptStockLedgerDetails _oRptStockLedgerDetails;

    protected void Page_Load(object sender, EventArgs e)
    {
        DBController.Instance.OpenNewConnection();
        if (!IsPostBack)
        {
            cmbStDay.Text = DateTime.Today.Day.ToString();
            cmbStMonth.Text = DateTime.Today.Month.ToString();
            cmbStYear.Text = DateTime.Today.Year.ToString();

            cmbEndDay.Text = DateTime.Today.Day.ToString();
            cmbEndMonth.Text = DateTime.Today.Month.ToString();
            cmbEndYear.Text = DateTime.Today.Year.ToString();

            LoadAllCombo();
        }

        DBController.Instance.CloseConnection();
    }

    public void LoadAllCombo()
    {
        //DBController.Instance.OpenNewConnection();
        //User oUser = (User)Session["User"];
        //Channels oChannels = new Channels();
        //oChannels.GetChannel(oUser.UserId);

        //if (oChannels.Count > 0)
        //{
        //    Session.Add("Channel", oChannels);
        //    cmbChannel.DataTextField = "ChannelDescription";
        //    cmbChannel.DataValueField = "ChannelID";
        //    cmbChannel.DataSource = oChannels;
        //    cmbChannel.DataBind();
        //    cmbChannel.SelectedIndex = oChannels.Count - 1;
        //}

        //else
        //{
        //    Channel oChannel = new Channel();
        //    oChannel.ChannelID = 0;
        //    oChannel.ChannelDescription = "No Permission";
        //    oChannels.Add(oChannel);

        //    cmbChannel.DataTextField = "ChannelDescription";
        //    cmbChannel.DataValueField = "ChannelID";
        //    cmbChannel.DataSource = oChannels;
        //    cmbChannel.DataBind();
        //}


        getChannel();
    }

    private void getChannel()
    {
        //DSChannel oDSChannel = UIUtility.getChannelList();
        //if (oDSChannel != null)
        //{
        //    foreach (DSChannel.ChannelRow oChannelRow in oDSChannel.Channel)
        //    {
        //        oChannelRow.ChannelDescription = oChannelRow.ChannelDescription + " [" + oChannelRow.ChannelCode + "]";
        //    }
        //    oDSChannel.AcceptChanges();
        //    oDSChannel.Channel.AddChannelRow(0, "<Select a Channel>", "", "", 1, 0, "", "");
        //    oDSChannel.AcceptChanges();


        //    cmbChannel.DataValueField = oDSChannel.Channel.ChannelIDColumn.ColumnName;
        //    cmbChannel.DataTextField = oDSChannel.Channel.ChannelDescriptionColumn.ColumnName;
        //    cmbChannel.DataSource = oDSChannel.Channel;
        //    cmbChannel.DataBind();
        //    cmbChannel.SelectedValue = "0";
        //}

    }
    //private void getWarehouse()
    //{
    //    DSWareHouse oDSWareHouse = UIUtility.getWarehouseList();
    //    lblErrChannel.Visible = false;
    //    //oDSWareHouse.WareHouse[0].ChannelID
    //    if (oDSWareHouse != null)
    //    {
    //        DataRow[] oSeletedRow = oDSWareHouse.WareHouse.Select("ChannelID = '" + Convert.ToInt64(cmbChannel.SelectedValue.ToString()) + "'");
    //        DSWareHouse oDSSelectedWareHouse;
    //        oDSSelectedWareHouse = new DSWareHouse();
    //        oDSSelectedWareHouse.Merge(oSeletedRow);
    //        oDSSelectedWareHouse.AcceptChanges();

    //        if (oDSSelectedWareHouse != null)
    //        {
    //            foreach (DSWareHouse.WareHouseRow oWarehouseRow in oDSSelectedWareHouse.WareHouse)
    //            {
    //                oWarehouseRow.WarehouseName = oWarehouseRow.WarehouseName + " [" + oWarehouseRow.WarehouseCode + "]";
    //            }
    //            oDSSelectedWareHouse.AcceptChanges();

    //            oDSSelectedWareHouse.WareHouse.AddWareHouseRow(0, "", "<Select a Warehouse>", 0, "", 0, "", 1, "", "");
    //            oDSSelectedWareHouse.AcceptChanges();

    //            cmbWarehouse.DataValueField = oDSSelectedWareHouse.WareHouse.WarehouseIDColumn.ColumnName;
    //            cmbWarehouse.DataTextField = oDSSelectedWareHouse.WareHouse.WarehouseNameColumn.ColumnName;
    //            cmbWarehouse.DataSource = oDSSelectedWareHouse.WareHouse;
    //            cmbWarehouse.DataBind();
    //            cmbWarehouse.SelectedValue = "0";
    //        }
    //        else
    //        {
    //            lblErrChannel.Visible = true;
    //            lblErrChannel.Text = "Please Choose a Channel";
    //        }

    //    }

    //}
    protected void btnShowReport_Click(object sender, EventArgs e)
    {

    }
    protected void txtProductCode_TextChanged(object sender, EventArgs e)
    {

    }
}

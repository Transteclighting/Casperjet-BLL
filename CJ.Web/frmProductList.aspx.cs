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

public partial class frmProductList : System.Web.UI.Page
{
  
    public ProductDetail _oProductDetail;
    private ProductGroups _oPG;
    private ProductGroups _oMAG;
    private ProductGroups _oASG;
    private ProductGroups _oAG;
    private Brands _oBrand;

    protected void Page_Load(object sender, EventArgs e)
    {
         DBController.Instance.OpenNewConnection();
         if (!IsPostBack)
         {
             LoadCombos();
         }    
    }
    private void LoadCombos()
    {
        //PG
        _oPG = new ProductGroups();
        _oPG.GETPG();
        cmbPG.Items.Clear();
        foreach (ProductGroup oProductGroup in _oPG)
        {
            Session.Add("PG", _oPG);
            cmbPG.DataTextField = "PdtGroupName";
            cmbPG.DataValueField = "PdtGroupId";
            cmbPG.DataSource = _oPG;
            cmbPG.DataBind();
            cmbPG.SelectedIndex = _oPG.Count - 1;
           
        }      

        //MAG
        _oMAG = new ProductGroups();
        _oMAG.GETMAG();
        cmbMAG.Items.Clear();
        foreach (ProductGroup oProductGroup in _oMAG)
        {
            Session.Add("MAG", _oMAG);
            cmbMAG.DataTextField = "PdtGroupName";
            cmbMAG.DataValueField = "PdtGroupId";
            cmbMAG.DataSource = _oMAG;
            cmbMAG.DataBind();
            cmbMAG.SelectedIndex = _oMAG.Count - 1;
        }    
        //ASG
        _oASG = new ProductGroups();
        _oASG.GETASG();
        cmbASG.Items.Clear();
        foreach (ProductGroup oProductGroup in _oASG)
        {
            Session.Add("ASG", _oASG);
            cmbASG.DataTextField = "PdtGroupName";
            cmbASG.DataValueField = "PdtGroupId";
            cmbASG.DataSource = _oASG;
            cmbASG.DataBind();
            cmbASG.SelectedIndex = _oASG.Count - 1;
        }    

        //AG
        _oAG = new ProductGroups();
        _oAG.GETAG();
        cmbAG.Items.Clear();
        foreach (ProductGroup oProductGroup in _oAG)
        {
            Session.Add("AG", _oAG);
            cmbAG.DataTextField = "PdtGroupName";
            cmbAG.DataValueField = "PdtGroupId";
            cmbAG.DataSource = _oAG;
            cmbAG.DataBind();
            cmbAG.SelectedIndex = _oAG.Count - 1;
        }
     
        //Brand
        _oBrand = new Brands();
        _oBrand.GetBrand();
        cmbBarnd.Items.Clear();
        foreach (Brand oBrand in _oBrand)
        {
            Session.Add("Brand", _oBrand);
            cmbBarnd.DataTextField = "BrandDesc";
            cmbBarnd.DataValueField = "BrandID";
            cmbBarnd.DataSource = _oBrand;
            cmbBarnd.DataBind();
            cmbBarnd.SelectedIndex = _oBrand.Count - 1;        
        }  
              
    }

    private void refreshListBySearch()
    {
        _oPG = (ProductGroups)Session["PG"];
        _oMAG = (ProductGroups)Session["MAG"];
        _oASG = (ProductGroups)Session["ASG"];
        _oAG = (ProductGroups)Session["AG"];
        _oBrand = (Brands)Session["Brand"]; 

        ProductDetails oProductDetails = new ProductDetails();
        DBController.Instance.OpenNewConnection();

        oProductDetails.RefreshBySearch(_oPG[cmbPG.SelectedIndex].PdtGroupID, _oMAG[cmbMAG.SelectedIndex].PdtGroupID, _oASG[cmbASG.SelectedIndex].PdtGroupID, _oAG[cmbAG.SelectedIndex].PdtGroupID, _oBrand[cmbBarnd.SelectedIndex].BrandID,-1,Dictionary.GeneralStatus.All, txtProductCode.Text, txtProductName.Text, 1);

        dvwProducts.DataSource = oProductDetails;
        dvwProducts.DataBind();
        Table1.Rows[0].Cells[0].InnerText = "Products " + "[" + oProductDetails.Count + "]";

    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        refreshListBySearch();
    }
}
   
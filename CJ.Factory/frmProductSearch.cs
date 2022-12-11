using System;
using System.Windows.Forms;
using CJ.Class;




namespace CJ.Factory
{
    public partial class frmProductSearch : Form
    {

        private SerarchProduct oSerarchProduct;
        private ProductGroups _oPG;
        private ProductGroups _oMAG;
        private ProductGroups _oASG;
        private ProductGroups _oAG;
        private Brands _oBrands;

        public frmProductSearch()
        {
            InitializeComponent();
        }

        private void LoadCombos()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }


            _oBrands = new Brands();
            _oBrands.GetAllBrandFactory();
            cboBrand.Items.Clear();
            cboBrand.Items.Add("<All>");
            foreach (Brand oBrand in _oBrands)
            {
                cboBrand.Items.Add(oBrand.BrandDesc);
            }
            cboBrand.SelectedIndex = 0;

            //PG
            _oPG = new ProductGroups();
            _oPG.GEProductGroupFactory("PGName", "PGID");
            cboPG.Items.Clear();
            cboPG.Items.Add("<All>");
            foreach (ProductGroup oProductGroup in _oPG)
            {
                cboPG.Items.Add(oProductGroup.PdtGroupName);
            }
            cboPG.SelectedIndex = 0;

            //MAG
            _oMAG = new ProductGroups();
            _oMAG.GEProductGroupFactory("MAGName", "MAGID");
            cboMAG.Items.Clear();
            cboMAG.Items.Add("<All>");
            foreach (ProductGroup oProductGroup in _oMAG)
            {
                cboMAG.Items.Add(oProductGroup.PdtGroupName);
            }
            cboMAG.SelectedIndex = 0;

            //ASG
            _oASG = new ProductGroups();
            _oASG.GEProductGroupFactory("ASGName", "ASGID");
            cboASG.Items.Clear();
            cboASG.Items.Add("<All>");
            foreach (ProductGroup oProductGroup in _oASG)
            {
                cboASG.Items.Add(oProductGroup.PdtGroupName);
            }
            cboASG.SelectedIndex = 0;

            //AG
            _oAG = new ProductGroups();
            _oAG.GEProductGroupFactory("AGName", "AGID");
            cboAG.Items.Clear();
            cboAG.Items.Add("<All>");
            foreach (ProductGroup oProductGroup in _oAG)
            {
                cboAG.Items.Add(oProductGroup.PdtGroupName);
            }
            cboAG.SelectedIndex = 0;
            DBController.Instance.CloseConnection();
        }

        private void frmProductSearch_Load(object sender, EventArgs e)
        {
            LoadCombos();

        }

        private void DataLoadControl()
        {
            int nPGID = 0;
            int nMAGID = 0;
            int nASGID = 0;
            int nAGID = 0;
            int nBrandID = 0;

            SerarchProducts oSerarchProducts = new SerarchProducts();
            if (cboPG.SelectedIndex != 0)
            {
                nPGID = _oPG[cboPG.SelectedIndex - 1].PdtGroupID;
            }
            else
            {
                nPGID = -1;
            }
            if (cboMAG.SelectedIndex != 0)
            {
                nMAGID = _oMAG[cboMAG.SelectedIndex - 1].PdtGroupID;
            }
            else
            {
                nMAGID = -1;
            }
            if (cboASG.SelectedIndex != 0)
            {
                nASGID = _oASG[cboASG.SelectedIndex - 1].PdtGroupID;
            }
            else
            {
                nASGID = -1;
            }
            if (cboAG.SelectedIndex != 0)
            {
                nAGID = _oAG[cboAG.SelectedIndex - 1].PdtGroupID;
            }
            else
            {
                nAGID = -1;
            }
            if (cboBrand.SelectedIndex != 0)
            {
              nBrandID = _oBrands[cboBrand.SelectedIndex - 1].BrandID;
            }
            else
            {
                nBrandID = -1;
            }
            lvwProduct.Items.Clear();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }

            oSerarchProducts.RefreshFactory(nPGID,nMAGID,nASGID,nAGID,nBrandID, txtProductCode.Text, txtProductName.Text);
            
            this.Text = "Total Product = " + "[" + oSerarchProducts.Count + "]";
            foreach (SerarchProduct oSerarchProduct in oSerarchProducts)
            {
                ListViewItem oItem = lvwProduct.Items.Add(oSerarchProduct.ProductCode.ToString());
                oItem.SubItems.Add(oSerarchProduct.ProductName);
                oItem.SubItems.Add(oSerarchProduct.MAGName);
                oItem.SubItems.Add(oSerarchProduct.BrandDesc);
                oItem.Tag = oSerarchProduct;
            }
           
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtProductCode.Text = "";
            txtProductName.Text = "";
            DataLoadControl();
        }

        private void lvwProductSearch_DoubleClick(object sender, EventArgs e)
        {

            SerarchProduct _oSerarchProduct = (SerarchProduct)lvwProduct.SelectedItems[0].Tag;
            oSerarchProduct.ProductCode = _oSerarchProduct.ProductCode;
            oSerarchProduct.ProductName = _oSerarchProduct.ProductName;
            this.Close();
        }

        private void lvwProductSearch_KeyPress(object sender, KeyPressEventArgs e)
        {

            SerarchProduct _oSerarchProduct = (SerarchProduct)lvwProduct.SelectedItems[0].Tag;

            oSerarchProduct.ProductCode = _oSerarchProduct.ProductCode;
            oSerarchProduct.ProductName = _oSerarchProduct.ProductName;
            this.Close();
        }

        public bool ShowDialog(SerarchProduct _oSerarchProduct)
        {
            oSerarchProduct = _oSerarchProduct;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.ShowDialog();
            return true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

    }

}
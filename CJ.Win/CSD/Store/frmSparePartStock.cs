using System;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.HR;
using CJ.Report;
using CJ.Report.CSD;

//namespace CJ.Win.CSD.Store
namespace CJ.Win
{
    public partial class frmSparePartStock : Form
    {
        Stores _oParentStores;
        Stores _oChildStores;
        SPGroups _oSPGroups;
        SparePartss _oSparePartss;
        SpareParts _oSpareParts;
        SparePartLocations _oSparePartLocations;
        public frmSparePartStock()
        {
            InitializeComponent();
        }

        private void frmSparePartStock_Load(object sender, EventArgs e)
        {
            LoadCombo();
        }
        private void LoadCombo()
        {
            DBController.Instance.OpenNewConnection();
            _oParentStores = new Stores();
            _oParentStores.RefreshParentStore();
            cmbParentStore.Items.Add("<All>");
            foreach (Store oStore in _oParentStores)
            {
                //ComboboxItem item = new ComboboxItem();
                //item.Text = oStore.StoreName;
                //item.Value = oStore.StoreID.ToString();
                //cmbParentStore.Items.Add(item);  
                cmbParentStore.Items.Add(oStore.StoreName);   
            }
            cmbParentStore.SelectedIndex = 0;

            //cmbChildStore.Items.Add("<All>");
            //cmbChildStore.SelectedIndex = 0;

            _oSPGroups = new SPGroups();
            _oSPGroups.RefreshAll();
            cmbSpareCategory.Items.Add("<All>");
            foreach (SPGroup oSPGroup in _oSPGroups)
            {
                //ComboboxItem item = new ComboboxItem();
                //item.Text = oSPGroup.Name;
                //item.Value = oSPGroup.SPGroupID.ToString();
                //cmbSpareCategory.Items.Add(item);

                cmbSpareCategory.Items.Add(oSPGroup.Name);
            }
            cmbSpareCategory.SelectedIndex = 0;

            _oSparePartLocations = new SparePartLocations();
            _oSparePartLocations.RefreshForCombo();

            cmbSpareLocation.Items.Add("<All>");
            foreach (SparePartLocation oSparePartLocation in _oSparePartLocations)
            {

                cmbSpareLocation.Items.Add(oSparePartLocation.LocationName);
            }
            cmbSpareLocation.SelectedIndex = 0;



        }

        private void cmbParentStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            int nParentStoreID = 0;
            if (cmbParentStore.SelectedIndex != 0)
            {
                nParentStoreID = _oParentStores[cmbParentStore.SelectedIndex-1].StoreID;
            }
            else
            {
                cmbChildStore.Items.Clear();
                cmbChildStore.Items.Add("<All>");
                cmbChildStore.SelectedIndex = 0;
                return;
            }            

            cmbChildStore.Items.Clear();
            _oChildStores = new Stores();
            _oChildStores.GetLocationByParent(nParentStoreID);
            cmbChildStore.Items.Add("<All>");
            foreach (Store oStore in _oChildStores)
            {
                //ComboboxItem item = new ComboboxItem();
                //item.Text = oStore.StoreName;
                //item.Value = oStore.StoreID.ToString();
                //cmbChildStore.Items.Add(item);

                cmbChildStore.Items.Add(oStore.StoreName);
            }
            cmbChildStore.SelectedIndex = 0;
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (txtSpareCode.Text.Trim() != string.Empty)
            {
                _oSpareParts = new SpareParts();
                _oSpareParts.Code = txtSpareCode.Text.Trim();
                _oSpareParts.RefreshByCode();
                if (_oSpareParts.Flag)
                {
                    Preview();
                }
                else
                {
                    MessageBox.Show("Please Enter Valid Spare Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                Preview();
            }
   


        }
        private void Preview()
        {
            this.Cursor = Cursors.WaitCursor;
            int nChildStoreID = 0;
            int nParentStoreID = 0;
            if (cmbChildStore.SelectedIndex != 0)
            {
                nChildStoreID = _oChildStores[cmbChildStore.SelectedIndex-1].StoreID;
            }
            else if (cmbParentStore.SelectedIndex != 0)
            {
                nParentStoreID = _oParentStores[cmbParentStore.SelectedIndex-1].StoreID;
            }
            this.Cursor = Cursors.WaitCursor;

            int nSpareCategory = 0;
            if (cmbSpareCategory.SelectedIndex != 0)
            { 
                nSpareCategory = _oSPGroups[cmbSpareCategory.SelectedIndex-1].SPGroupID;
            }
            int nSPLocation = 0;
            if (cmbSpareLocation.SelectedIndex != 0)
            {
                nSPLocation = _oSparePartLocations[cmbSpareLocation.SelectedIndex - 1].SPLocationID;
            }

            var doc = new rptSaprePartsStock();
            _oSparePartss = new SparePartss();
            _oSparePartss.RefreshForStock(nChildStoreID, nParentStoreID, nSpareCategory, nSPLocation,txtSpareCode.Text.Trim(), txtSpareName.Text.Trim());
            doc.SetDataSource(_oSparePartss);

            doc.SetParameterValue("ParentStore", cmbParentStore.Text);
            doc.SetParameterValue("ChildStore", cmbChildStore.Text);
            doc.SetParameterValue("SpareCategory", cmbSpareCategory.Text);
            doc.SetParameterValue("LocationName", cmbSpareLocation.Text);

            doc.SetParameterValue("SpareCode", txtSpareCode.Text);
            doc.SetParameterValue("SpareName", txtSpareName.Text);
            doc.SetParameterValue("PrintUser", Utility.Username);
            try
            {
                var aJobLocation = new JobLocation
                {
                    JobLocationID = Utility.JobLocation
                };
                aJobLocation.Refresh();
                doc.SetParameterValue("ServiceCenterName", aJobLocation.JobLocationName);
                doc.SetParameterValue("ServiceCenterAddress", aJobLocation.Description);
            }
            catch
            {
                doc.SetParameterValue("ServiceCenterName", "Customer Service Department");
                doc.SetParameterValue("ServiceCenterAddress", "House:22, Road:4, Block:F, Banani, Dhaka-1213");
            }


            var frmView = new frmPrintPreview();
            frmView.ShowDialog(doc);
            this.Cursor = Cursors.Default;
            
        }
    }
}
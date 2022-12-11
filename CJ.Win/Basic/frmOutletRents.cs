using System;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.BasicData;

namespace CJ.Win.Basic
{
    public partial class frmOutletRents : Form
    {
        bool IsCheck = false;
        OutletRents _oOutletRents;
        Showrooms _oShowrooms;
        public frmOutletRents()
        {
            InitializeComponent();
        }
        
        private void frmOutletRents_Load(object sender, EventArgs e)
        {
            //LoadData();
            LoadCombo();
        }
        private void LoadCombo()
        {
            cmbShowroom.Items.Add("<All>");
            _oShowrooms = new Showrooms();
            //_oShowrooms.Refresh();
            //foreach (Showroom oShowroom in _oShowrooms)
            //{
            //    cmbShowroom.Items.Add(oShowroom.ShowroomCode);
            //}
            //cmbShowroom.SelectedIndex = 0;
            _oShowrooms = new Showrooms();
            //_oShowrooms.GetShowroomByJobLocation();
            foreach (Showroom oShowroom in _oShowrooms)
            {
                cmbShowroom.Items.Add(oShowroom.ShowroomName);
            }
            cmbShowroom.SelectedIndex = 0;

            cmbType.Items.Add("<All>");
            _oOutletRents = new OutletRents();
            _oOutletRents.RefreshByAreaType();
            foreach (OutletRent oOutletRent in _oOutletRents)
            {
                cmbType.Items.Add(oOutletRent.AreaType);
            }
            cmbType.SelectedIndex = 0;

                cmbIsActive.Items.Add("<All>");
            
                foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.YesOrNoStatus)))
                {
                cmbIsActive.Items.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), GetEnum));
                }
            cmbIsActive.SelectedIndex = 0;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmOutletRent oForm = new frmOutletRent();
            oForm.ShowDialog();
            if (oForm._Istrue == true)
                LoadData();
        }

        public void LoadData()
        {

            lvwOutletRent.Items.Clear();
            DBController.Instance.OpenNewConnection();
            _oOutletRents = new OutletRents();

            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            int nIsActive = 0;
            if (cmbIsActive.SelectedIndex == 0)
            {
                nIsActive = -1;
            }
            else
            {
                nIsActive = cmbIsActive.SelectedIndex -1;
            }
            _oOutletRents.Refresh(dtFromdate.Value.Date, dtTodate.Value.Date,cmbShowroom.Text,cmbType.Text,nIsActive,IsCheck);

            foreach (OutletRent _oOutletRent in _oOutletRents)
            {
                ListViewItem oItem = lvwOutletRent.Items.Add(_oOutletRent.ShowroomCode.ToString());  
                oItem.SubItems.Add(_oOutletRent.AreaType);
                oItem.SubItems.Add(_oOutletRent.AgreementStartDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(_oOutletRent.AgreemntTenureEndDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(_oOutletRent.AgreementTenure.ToString());
                oItem.SubItems.Add(_oOutletRent.NextRenualDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(_oOutletRent.TotalRent.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), _oOutletRent.IsActive));               
                
                oItem.Tag = _oOutletRent;

            }
            this.Text = "Total" + "[" + _oOutletRents.Count + "]";
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwOutletRent.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            OutletRent oOutletRent = (OutletRent)lvwOutletRent.SelectedItems[0].Tag;
            frmOutletRent oForm = new frmOutletRent();
            oForm.ShowDialog(oOutletRent);
            if (oForm._Istrue == true) ;
            LoadData();
        }

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAll.Checked == true)
            {
                dtFromdate.Enabled = false;
                dtTodate.Enabled = false;
                IsCheck = true;
            }
            else
            {
                dtFromdate.Enabled = true;
                dtTodate.Enabled = true;
                IsCheck = false;
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}

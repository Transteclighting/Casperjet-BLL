using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.Accounts;


namespace CJ.Win.Accounts
{
    public partial class frmSalesInvoiceDiscountTypes : Form
    {

        private SalesInvoiceDiscountTypes _oSalesInvoiceDiscountTypes;
        private SalesInvoiceDiscountType _oSalesInvoiceDiscountType;
        private int nArrayLen = 0;
        private string[] sChannelArr = null;
    
        public frmSalesInvoiceDiscountTypes()
        {
            InitializeComponent();
        }

        private void LoadData()
        {

            _oSalesInvoiceDiscountTypes = new SalesInvoiceDiscountTypes();
            lvwSalesInvoiceDiscountType.Items.Clear();
            DBController.Instance.OpenNewConnection();

            string discountTypeName = txtDiscountTypeName.Text.Trim();

            int nType = 0;

            if (cmbTypes.SelectedIndex == 0)
            {
                nType = -1;
            }
            else
            {
                nType = (int)Enum.Parse(typeof(Dictionary.DiscountChargeType), cmbTypes.SelectedItem.ToString());
            }

            int nIsActive = 0;
            if (cmbIsActive.SelectedIndex == 0)
            {
                nIsActive = -1;
            }
            else
            {
                nIsActive = cmbIsActive.SelectedIndex - 1;
            }

            
            _oSalesInvoiceDiscountTypes.RefreshSalesInvoiceDiscountType(discountTypeName, nType, nIsActive);



            foreach (SalesInvoiceDiscountType oSalesInvoiceDiscountType in _oSalesInvoiceDiscountTypes)
            {
                ListViewItem oItem = lvwSalesInvoiceDiscountType.Items.Add(oSalesInvoiceDiscountType.DiscountTypeName.ToString());
                string sChannel = "";
                char[] splitchar = { ',' };
                sChannelArr = oSalesInvoiceDiscountType.SalesType.Split(splitchar);
                nArrayLen = sChannelArr.Length;
                
                for (int i = 0; i < nArrayLen; i++)
                {
                    if (sChannel == "")
                    {
                        sChannel = Enum.GetName(typeof(Dictionary.SalesType), Convert.ToInt32(sChannelArr[i]));
                    }
                    else
                    {
                        sChannel = sChannel + "," + Enum.GetName(typeof(Dictionary.SalesType), Convert.ToInt32(sChannelArr[i]));
                    }
                }
                oItem.SubItems.Add(sChannel.ToString());
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.DiscountChargeType), oSalesInvoiceDiscountType.Type));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.IsActive), oSalesInvoiceDiscountType.IsActive));
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), oSalesInvoiceDiscountType.IsSystem));
                oItem.SubItems.Add(oSalesInvoiceDiscountType.CreateDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oSalesInvoiceDiscountType.CreateUserName.ToString());

                oItem.Tag = oSalesInvoiceDiscountType;
            }
            setListViewRowColour();
        }

        private void LoadCombos()
        {
            cmbIsActive.Items.Clear();
            cmbIsActive.Items.Add("All");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.YesOrNoStatus)))
            {
                cmbIsActive.Items.Add(Enum.GetName(typeof(Dictionary.YesOrNoStatus), GetEnum));
            }
            cmbIsActive.SelectedIndex = 0;

            cmbTypes.Items.Clear();
            cmbTypes.Items.Add("All");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.DiscountChargeType)))
            {
                if (GetEnum == (int)Dictionary.DiscountChargeType.Discount || GetEnum == (int)Dictionary.DiscountChargeType.Charge)
                {
                    cmbTypes.Items.Add(Enum.GetName(typeof(Dictionary.DiscountChargeType), GetEnum));
                }
            }

            cmbTypes.SelectedIndex = 0;

        }


        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }
        private void setListViewRowColour()
        {
            if (lvwSalesInvoiceDiscountType.Items.Count > 0)
            {
                foreach (ListViewItem oItem in lvwSalesInvoiceDiscountType.Items)
                {
                    if (oItem.SubItems[4].Text == Dictionary.YesOrNoStatus.NO.ToString())
                    {
                        oItem.BackColor = Color.DarkGray;
                    }
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSIDTAdd_Click(object sender, EventArgs e)
        {
            frmSalesInvoiceDiscountType oForm = new frmSalesInvoiceDiscountType();
            oForm.ShowDialog();
            if(oForm._bFalg)
            {
                LoadData();
            }
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwSalesInvoiceDiscountType.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           
            SalesInvoiceDiscountType oSalesInvoiceDiscountType = (SalesInvoiceDiscountType)lvwSalesInvoiceDiscountType.SelectedItems[0].Tag;

            if (oSalesInvoiceDiscountType.IsSystem == 0)
            {
                frmSalesInvoiceDiscountType ofrmSalesInvoiceDiscountType = new frmSalesInvoiceDiscountType();
                ofrmSalesInvoiceDiscountType.ShowDialog(oSalesInvoiceDiscountType);
                LoadData();
            }

            else {
                MessageBox.Show("This data is not editable", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void double_Click(object sender, EventArgs e)
        {
            if (lvwSalesInvoiceDiscountType.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Row to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SalesInvoiceDiscountType oSalesInvoiceDiscountType = (SalesInvoiceDiscountType)lvwSalesInvoiceDiscountType.SelectedItems[0].Tag;

            if (oSalesInvoiceDiscountType.IsSystem == 0)
            {
                frmSalesInvoiceDiscountType ofrmSalesInvoiceDiscountType = new frmSalesInvoiceDiscountType();
                ofrmSalesInvoiceDiscountType.ShowDialog(oSalesInvoiceDiscountType);
                LoadData();
            }

            else
            {
                MessageBox.Show("This data is not editable");
            }
        }

        private void frmSalesInvoiceDiscountTypes_Load(object sender, EventArgs e)
        {
            LoadCombos();
            LoadData();
        }
    }
}

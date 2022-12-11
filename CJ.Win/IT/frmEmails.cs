using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Report;

namespace CJ.Win
{
    public partial class frmEmails : Form
    {
        Companys _oCompanys;
        public frmEmails()
        {
            InitializeComponent();
        }
        private void frmEmails_Load(object sender, EventArgs e)
        {
            LoadCombos();            
        }
        private void LoadCombos()
        {
            DBController.Instance.OpenNewConnection();
            //Company
            _oCompanys = new Companys();
            _oCompanys.GetCompany();
            cmbCompany.Items.Clear();
            cmbCompany.Items.Add("<All>");
            foreach (Company oCompany in _oCompanys)
            {
                cmbCompany.Items.Add(oCompany.CompanyName);
            }
            cmbCompany.SelectedIndex = 0;
            //Email Type
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.EmailType)))
            {
                cboType.Items.Add(Enum.GetName(typeof(Dictionary.EmailType), GetEnum));
            }
            cboType.SelectedIndex = (int)Dictionary.EmailType.Individual;

            //Email Status
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.EmailStatus)))
            {
                cboStatus.Items.Add(Enum.GetName(typeof(Dictionary.EmailStatus), GetEnum));
            }
            cboStatus.SelectedIndex = (int)Dictionary.EmailStatus.Created;
        }
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void DataLoadControl()
        {
            // Create an instance of a ListView column sorter and assign it 
            // to the ListView control.
            lvwColumnSorter = new ListViewColumnSorter();
            this.lvwEmails.ListViewItemSorter = lvwColumnSorter;
            int nCompanyID = 0;
            if (cmbCompany.SelectedIndex > 0) nCompanyID = _oCompanys[cmbCompany.SelectedIndex - 1].CompanyID;

            Emails oEmails = new Emails();
            lvwEmails.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oEmails.Refresh(txtName.Text,(Dictionary.EmailType)cboType.SelectedIndex,(Dictionary.EmailStatus)cboStatus.SelectedIndex,nCompanyID);
            this.Text = "Email " + "[" + oEmails.Count + "]";
            foreach (Email oEmail in oEmails)
            {
                ListViewItem oItem = lvwEmails.Items.Add(oEmail.EmailAddress);
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.EmailType),oEmail.Type));
                if (oEmail.Employee != null)
                {
                    //oEmail.Employee.ReadDB = true;
                    oItem.SubItems.Add(oEmail.Employee.EmployeeName + " [" + oEmail.Employee.EmployeeCode + "]");
                    //oItem.SubItems.Add(oEmail.Employee.Company.CompanyCode + ">" + oEmail.Employee.Company.CompanyName);
                    //oItem.SubItems.Add(oEmail.Employee.Company.CompanyCode  + ">" + oEmail.Employee.Department.DepartmentName);                  
                    oItem.SubItems.Add(oEmail.Employee.Company.CompanyName);
                    oItem.SubItems.Add(oEmail.Employee.Department.DepartmentName);
                }
                else 
                { 
                    oItem.SubItems.Add("");
                    oItem.SubItems.Add("");
                }
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.EmailStatus),oEmail.Status));               
                oItem.SubItems.Add(oEmail.Quota.ToString());
                oItem.SubItems.Add(oEmail.WebAccess.ToString());
                oItem.SubItems.Add(oEmail.CreateDate.ToString("dd-MMM-yyyy"));
                oItem.Tag = oEmail;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmEmail oForm = new frmEmail();
            oForm.ShowDialog();
            DataLoadControl();
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwEmails.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Email to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Email oEmail = (Email)lvwEmails.SelectedItems[0].Tag;
            frmEmail oForm = new frmEmail();
            oForm.ShowDialog(oEmail);
            DataLoadControl();
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            //Emails oEmails = new Emails();
            //oEmails.Refresh();
            //rptEmails oReport = new rptEmails();
            //oReport.SetDataSource(oEmails);
            //frmPrintPreview oFrom = new frmPrintPreview();

            //oFrom.ShowDialog(oReport);
        }
        private void btndelete_Click(object sender, EventArgs e)
        {
            if (lvwEmails.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Email to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Email oEmail = (Email)lvwEmails.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete Email: " + oEmail.EmailAddress  + " ? ", "Confirm Ticket Delete" , MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oEmail.Delete();
                    DBController.Instance.CommitTransaction();
                    DataLoadControl();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show(ex.Message, "Error!!!");
                }

                
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void lvwEmails_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending)
                {
                    lvwColumnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    lvwColumnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            // Perform the sort with these new sort options.
            this.lvwEmails.Sort();
        }
        private void cmbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataLoadControl();
        }
    }




    /// <summary>
    /// This class is an implementation of the 'IComparer' interface.
    /// </summary>
    public class ListViewColumnSorter : IComparer
    {
        /// <summary>
        /// Specifies the column to be sorted
        /// </summary>
        private int ColumnToSort;
        /// <summary>
        /// Specifies the order in which to sort (i.e. 'Ascending').
        /// </summary>
        private SortOrder OrderOfSort;
        /// <summary>
        /// Case insensitive comparer object
        /// </summary>
        private CaseInsensitiveComparer ObjectCompare;

        /// <summary>
        /// Class constructor.  Initializes various elements
        /// </summary>
        public ListViewColumnSorter()
        {
            // Initialize the column to '0'
            ColumnToSort = 0;

            // Initialize the sort order to 'none'
            OrderOfSort = SortOrder.None;

            // Initialize the CaseInsensitiveComparer object
            ObjectCompare = new CaseInsensitiveComparer();
        }

        /// <summary>
        /// This method is inherited from the IComparer interface.  It compares the two objects passed using a case insensitive comparison.
        /// </summary>
        /// <param name="x">First object to be compared</param>
        /// <param name="y">Second object to be compared</param>
        /// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
        public int Compare(object x, object y)
        {
            int compareResult;
            ListViewItem listviewX, listviewY;

            // Cast the objects to be compared to ListViewItem objects
            listviewX = (ListViewItem)x;
            listviewY = (ListViewItem)y;

            // Compare the two items
            compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);

            // Calculate correct return value based on object comparison
            if (OrderOfSort == SortOrder.Ascending)
            {
                // Ascending sort is selected, return normal result of compare operation
                return compareResult;
            }
            else if (OrderOfSort == SortOrder.Descending)
            {
                // Descending sort is selected, return negative result of compare operation
                return (-compareResult);
            }
            else
            {
                // Return '0' to indicate they are equal
                return 0;
            }
        }

        /// <summary>
        /// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
        /// </summary>
        public int SortColumn
        {
            set
            {
                ColumnToSort = value;
            }
            get
            {
                return ColumnToSort;
            }
        }

        /// <summary>
        /// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
        /// </summary>
        public SortOrder Order
        {
            set
            {
                OrderOfSort = value;
            }
            get
            {
                return OrderOfSort;
            }
        }

    }
}
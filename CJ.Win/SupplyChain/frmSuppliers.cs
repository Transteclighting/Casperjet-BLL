using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;
using CJ.Report;
using System.Collections;

namespace CJ.Win
{
    public partial class frmSuppliers : Form
    {
        private ListViewColumnSorter lvwColumnSorter;
        public frmSuppliers()
        {
            InitializeComponent();
            lvwColumnSorter = new ListViewColumnSorter();
            this.lvwSuppliers.ListViewItemSorter = lvwColumnSorter;
        }

        private void frmSuppliers_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void DataLoadControl()
        {
            Suppliers oSuppliers = new Suppliers();
            lvwSuppliers.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oSuppliers.Refresh();
            this.Text = "Supplier " + "[" + oSuppliers.Count + "]";
            foreach (Supplier oSupplier in oSuppliers)
            {
                ListViewItem oItem = lvwSuppliers.Items.Add(oSupplier.SupplierCode);
                oItem.SubItems.Add(oSupplier.SupplierName);
                oItem.SubItems.Add(oSupplier.Address);
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.SupplierType), oSupplier.Type));
                oItem.Tag = oSupplier;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmSupplier oForm = new frmSupplier();      
            oForm.ShowDialog();
            DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwSuppliers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Supplier to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Supplier oSupplier = (Supplier)lvwSuppliers.SelectedItems[0].Tag;
            frmSupplier oForm = new frmSupplier();
            oForm.ShowDialog(oSupplier);
            DataLoadControl();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //Suppliers oSuppliers = new Suppliers();
            //oSuppliers.Refresh();
            //rptSuppliers oReport = new rptSuppliers();
            //oReport.SetDataSource(oSuppliers);
            //frmPrintPreview oFrom = new frmPrintPreview();

            //oFrom.ShowDialog(oReport);
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (lvwSuppliers.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Supplier to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Supplier oSupplier = (Supplier)lvwSuppliers.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete Supplier: " + oSupplier.SupplierCode  + " ? ", "Confirm Ticket Delete" , MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oSupplier.Delete();
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

        public class LstViewColumnSorter : IComparer
        {

        private int ColumnToSort;
        private SortOrder OrderOfSort;
        private CaseInsensitiveComparer ObjectCompare;
        public LstViewColumnSorter()
        {
            ColumnToSort = 0;
            OrderOfSort = SortOrder.None;
            ObjectCompare = new CaseInsensitiveComparer();
        }
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

        private void lvwSuppliers_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == lvwColumnSorter.SortColumn)
            {
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
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;
            }

            this.lvwSuppliers.Sort();
        }
    }
}
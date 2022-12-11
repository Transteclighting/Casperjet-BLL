using System;
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
    public partial class frmDepartments : Form
    {
        private Departments _oDepartments;
        HRDivisions oHRDivisions;
        public frmDepartments()
        {
            InitializeComponent();
        }

        private void LoadCombos()
        {

            //Division
            oHRDivisions = new HRDivisions();
            oHRDivisions.Refresh();
            cmbDivision.Items.Clear();
            cmbDivision.Items.Add("<ALL>");
            foreach (HRDivision oHRDivision in oHRDivisions)
            {
                cmbDivision.Items.Add(oHRDivision.DivisionName);
            }
            cmbDivision.SelectedIndex = 0;

        }

        private void frmDepartments_Load(object sender, EventArgs e)
        {
            LoadCombos();
            DataLoadControl();
        }

        private void DataLoadControl()
        {
            _oDepartments = new Departments();
            lvwDepartments.Items.Clear();
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            int nDivisionID = 0;
            if (cmbDivision.SelectedIndex > 0) nDivisionID = oHRDivisions[cmbDivision.SelectedIndex - 1].DivisionID;


            _oDepartments.GetDepartmentHO(txtCode.Text.Trim(), txtName.Text.Trim(), nDivisionID);
            this.Text = "Department " + "[" + _oDepartments.Count + "]";
            foreach (Department oDepartment in _oDepartments)
            {
                ListViewItem oItem = lvwDepartments.Items.Add(oDepartment.DepartmentCode);
                oItem.SubItems.Add(oDepartment.DepartmentName);
                oItem.SubItems.Add(oDepartment.DivisionName);
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.IsActive), oDepartment.Active));
                oItem.Tag = oDepartment;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmDepartment oForm = new frmDepartment();
            oForm.ShowDialog();
            if (oForm._IsTrue == true)
                DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwDepartments.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Department to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Department oDepartment = (Department)lvwDepartments.SelectedItems[0].Tag;
            frmDepartment oForm = new frmDepartment();
            oForm.ShowDialog(oDepartment);
            if (oForm._IsTrue == true)
                DataLoadControl();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            //DataSet oDS=_oDepartments.ToDataSet();
            //oDS.WriteXml("C:\\dept.xml");
            //DataRow[] oDR= oDS.Tables[0].Select("DepartmentCode='MIS'");

            //DataSet oDS1 = new DataSet();
            //oDS1.Merge(oDR);
            //oDS1.AcceptChanges();

            //_oDepartments.FromDataSet(oDS1);

            //this.Text = "Department " + "[" + _oDepartments.Count + "]";
            //lvwDepartments.Items.Clear();
            //foreach (Department oDepartment in _oDepartments)
            //{
            //    ListViewItem oItem = lvwDepartments.Items.Add(oDepartment.DepartmentCode);
            //    oItem.SubItems.Add(oDepartment.DepartmentName);
            //    oItem.Tag = oDepartment;
            //}

            ////Departments oDepartments = new Departments();
            ////oDepartments.Refresh();
            ////rptDepartments oReport = new rptDepartments();
            ////oReport.SetDataSource(oDepartments);
            ////frmPrintPreview oFrom = new frmPrintPreview();

            ////oFrom.ShowDialog(oReport);
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            if (lvwDepartments.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select a Department to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Department oDepartment = (Department)lvwDepartments.SelectedItems[0].Tag;
            DialogResult oResult = MessageBox.Show("Are you sure you want to delete Department: " + oDepartment.DepartmentCode  + " ? ", "Confirm Ticket Delete" , MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (oResult == DialogResult.Yes)
            {
                try
                {
                    DBController.Instance.BeginNewTransaction();
                    oDepartment.Delete();
                    DBController.Instance.CommitTransaction();
                    DataLoadControl();
                }
                catch (Exception ex)
                {
                    DBController.Instance.RollbackTransaction();
                    MessageBox.Show("This department is already tagged with employee information", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                }

                
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }
    }
}
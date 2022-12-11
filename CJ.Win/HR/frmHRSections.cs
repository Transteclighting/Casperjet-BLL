using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CJ.Class;

namespace CJ.Win.HR
{
    public partial class frmHRSections : Form
    {
        Departments _oDepartments;
        public frmHRSections()
        {
            InitializeComponent();
        }

        private void LoadCombos()
        {
            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            //IS Active
            cmbIsActive.Items.Clear();
            cmbIsActive.Items.Add("<ALL>");
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.IsActive)))
            {
                cmbIsActive.Items.Add(Enum.GetName(typeof(Dictionary.IsActive), GetEnum));
            }
            cmbIsActive.SelectedIndex = 0;

            //Department
            _oDepartments = new Departments();
            _oDepartments.GetAllDepartment();
            cmbDepartmentName.Items.Clear();
            cmbDepartmentName.Items.Add("<ALL>");
            foreach (Department oDepartment in _oDepartments)
            {
                cmbDepartmentName.Items.Add(oDepartment.DepartmentName);
            }
            cmbDepartmentName.SelectedIndex = 0;


        }
        private void DataLoadControl()
        {
            Employees oSections = new Employees();
            lvwSections.Items.Clear();
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
                nIsActive = cmbIsActive.SelectedIndex - 1;
            }
            int nDepartmentID = 0;
            if (cmbDepartmentName.SelectedIndex == 0)
            {
                nDepartmentID = -1;
            }
            else
            {
                nDepartmentID = _oDepartments[cmbDepartmentName.SelectedIndex - 1].DepartmentID;
            }

            oSections.GetSectionData(txtName.Text, nIsActive, nDepartmentID);
            this.Text = "Designation " + "[" + oSections.Count + "]";
            foreach (Employee oSection in oSections)
            {
                ListViewItem oItem = lvwSections.Items.Add(oSection.SectionName);
                oItem.SubItems.Add(oSection.DepartmentName);
                oItem.SubItems.Add(Enum.GetName(typeof(Dictionary.IsActive), oSection.IsActive));

                oItem.Tag = oSection;
            }
        }

        private void btnGetData_Click(object sender, EventArgs e)
        {
            DataLoadControl();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmHRSection oForm = new frmHRSection();
            oForm.ShowDialog();
            if (oForm._IsTrue == true)
                DataLoadControl();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lvwSections.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please Select an Designation to update.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Employee oSection = (Employee)lvwSections.SelectedItems[0].Tag;
            frmHRSection oForm = new frmHRSection();
            oForm.ShowDialog(oSection);
            if (oForm._IsTrue == true)
                DataLoadControl();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void frmHRSections_Load(object sender, EventArgs e)
        {
            LoadCombos();
        }
    }
}

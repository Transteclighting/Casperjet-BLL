using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;

namespace CJ.POS
{
    public partial class frmEmployeeList : Form
    {
        public frmEmployeeList()
        {
            InitializeComponent();
        }

        private void frmEmployeeList_Load(object sender, EventArgs e)
        {
            DataLoadControl();
        }
        private void DataLoadControl()
        {
            Employees oEmployees = new Employees();
            lvwEmployees.Items.Clear();
            DBController.Instance.OpenNewConnection();
            oEmployees.GetShowroomSalesPerson();

            this.Text = "Outlet Employees  " + "[" + oEmployees.Count + "]";

            foreach (Employee oEmployee in oEmployees)
            {
                ListViewItem oItem = lvwEmployees.Items.Add(oEmployee.EmployeeCode);
                oItem.SubItems.Add(oEmployee.EmployeeName);             
                oItem.SubItems.Add(oEmployee.DesignationName);            
                oItem.Tag = oEmployee;
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
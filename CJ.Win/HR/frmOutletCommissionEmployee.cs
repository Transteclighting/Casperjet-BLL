using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CJ.Class.HR;
using CJ.Class;
using CJ.Win.Control;

namespace CJ.Win.HR
{
    public partial class frmOutletCommissionEmployee : Form
    {
        string sBusinessType = "";
        DateTime firstDay;
        DateTime lastDay;
        Employee _oEmployee = new Employee();
        //Showrooms _oShowrooms = new Showrooms();
        JobLocations _oJobLocations = new JobLocations();

        OutletCommissionEmployees _oOutletCommissionEmployees = new OutletCommissionEmployees();
        DataTable _dt = new DataTable();
        int nLocationID = 0;
        int nEmployeeID = 0;
        int _nOutlet = -1;
        string sEmployee = "";
        //DateTime _dCompareDate;


        public frmOutletCommissionEmployee()
        {
            InitializeComponent();

            dtMonth.Value = DateTime.Today.Date;
        }

        private void frmOutletCommissionEmployee_Load(object sender, EventArgs e)
        {
            if(!DBController.Instance.OpenNewConnection())
            {
                DBController.Instance.OpenNewConnection();
            }


            _oJobLocations = new JobLocations();
            _oJobLocations.RefreshShowroomJoblocations();
            cmbOutlet.Items.Add("-- Select --");
            foreach (JobLocation oJobLocation in _oJobLocations)
            {
                cmbOutlet.Items.Add(oJobLocation.JobLocationName);
            }
            cmbOutlet.SelectedIndex = 0;


            ////Outlet
            txtJobLocationName.Items.Clear();
            foreach (JobLocation oJobLocation in _oJobLocations)
            {
                txtJobLocationName.Items.Add(oJobLocation.JobLocationName);
            }

            ////Outlet Employee Type
            txtEmployeeType.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.OutletEmployeeType)))
            {
                txtEmployeeType.Items.Add(Enum.GetName(typeof(Dictionary.OutletEmployeeType), GetEnum));
            }


            

            //_dCompareDate = Convert.ToDateTime(dtMonth.Value);
            LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                DBController.Instance.BeginNewTransaction();
                for (int i = 0; i < dgvOutletCommissionEmployeeList.Rows.Count; i++)
                {
                    OutletCommissionEmployee oOutletCommissionEmployee = new OutletCommissionEmployee();
                    DataGridViewComboBoxCell cc = (DataGridViewComboBoxCell)dgvOutletCommissionEmployeeList.Rows[i].Cells[4];

                    if (Convert.ToInt32(dgvOutletCommissionEmployeeList.Rows[i].Cells[13].Value) == 0)
                    {
                        oOutletCommissionEmployee.OutletEmployeeID = Convert.ToInt32(dgvOutletCommissionEmployeeList.Rows[i].Cells[12].Value);
                        oOutletCommissionEmployee.LocationID = _oJobLocations[cc.Items.IndexOf(cc.Value)].JobLocationID;
                        oOutletCommissionEmployee.ProductCategoryID = (int)Enum.Parse(typeof(Dictionary.ProductCategory), dgvOutletCommissionEmployeeList.Rows[i].Cells[6].Value.ToString());
                        oOutletCommissionEmployee.OutletEmployeeType = (int)Enum.Parse(typeof(Dictionary.OutletEmployeeType), dgvOutletCommissionEmployeeList.Rows[i].Cells[5].Value.ToString());
                        oOutletCommissionEmployee.TotalWorkingDay = Convert.ToInt32(dgvOutletCommissionEmployeeList.Rows[i].Cells[11].Value);
                        oOutletCommissionEmployee.WorkingToDate = Convert.ToDateTime(dgvOutletCommissionEmployeeList.Rows[i].Cells[10].Value);
                        oOutletCommissionEmployee.WorkingFromDate = Convert.ToDateTime(dgvOutletCommissionEmployeeList.Rows[i].Cells[9].Value);
                        oOutletCommissionEmployee.TYear = Convert.ToInt32(dgvOutletCommissionEmployeeList.Rows[i].Cells[8].Value);
                        oOutletCommissionEmployee.TMonth = Convert.ToInt32(dgvOutletCommissionEmployeeList.Rows[i].Cells[7].Value);
                        oOutletCommissionEmployee.Add();
                    }
                    else
                    {
                        oOutletCommissionEmployee.ID = Convert.ToInt32(dgvOutletCommissionEmployeeList.Rows[i].Cells[13].Value);
                        oOutletCommissionEmployee.LocationID = _oJobLocations[cc.Items.IndexOf(cc.Value)].JobLocationID;
                        oOutletCommissionEmployee.ProductCategoryID = (int)Enum.Parse(typeof(Dictionary.ProductCategory), dgvOutletCommissionEmployeeList.Rows[i].Cells[6].Value.ToString());
                        oOutletCommissionEmployee.OutletEmployeeType = (int)Enum.Parse(typeof(Dictionary.OutletEmployeeType), dgvOutletCommissionEmployeeList.Rows[i].Cells[5].Value.ToString());
                        oOutletCommissionEmployee.WorkingFromDate = Convert.ToDateTime(dgvOutletCommissionEmployeeList.Rows[i].Cells[9].Value);
                        oOutletCommissionEmployee.WorkingToDate = Convert.ToDateTime(dgvOutletCommissionEmployeeList.Rows[i].Cells[10].Value);
                        oOutletCommissionEmployee.TotalWorkingDay = Convert.ToInt32(dgvOutletCommissionEmployeeList.Rows[i].Cells[11].Value);
                        
                        oOutletCommissionEmployee.Edit(dtMonth.Value.Month, dtMonth.Value.Year);
                        
                    }
                }

                for (int i = 0; i < _Delete.Rows.Count; i++)
                {
                    OutletCommissionEmployee oOutletCommissionEmployee = new OutletCommissionEmployee();
                    oOutletCommissionEmployee.ID = Convert.ToInt32(_Delete.Rows[i]["Column13"]);
                    oOutletCommissionEmployee.Delete();
                }

                DBController.Instance.CommitTransaction();
                MessageBox.Show("You have successfully Saved", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
            }
            catch (Exception ex)
            {
                DBController.Instance.RollbackTransaction();
                MessageBox.Show(ex.Message, "Error!!!");
            }
        }

        private void LoadData()
        {
            _dt = new DataTable();
            _Delete = new DataTable();

            ////Outlet Product Category 
            txtProductCategory.Items.Clear();
            foreach (int GetEnum in Enum.GetValues(typeof(Dictionary.ProductCategory)))
            {
                txtProductCategory.Items.Add(Enum.GetName(typeof(Dictionary.ProductCategory), GetEnum));
            }

            for (int i = 0; i < dgvOutletCommissionEmployeeList.Columns.Count; i++)
            {
                _dt.Columns.Add("column" + i.ToString());
                _Delete.Columns.Add("column" + i.ToString());
            }


            firstDay = new DateTime(dtMonth.Value.Year, dtMonth.Value.Month, 1);
            lastDay = new DateTime(dtMonth.Value.Year, dtMonth.Value.Month, DateTime.DaysInMonth(dtMonth.Value.Year, dtMonth.Value.Month));

            dgvOutletCommissionEmployeeList.Rows.Clear();


            try
            {
                nLocationID = _oJobLocations[cmbOutlet.SelectedIndex - 1].JobLocationID;
            }
            catch
            {
                nLocationID = 0;
            }

            try
            {
                nEmployeeID = ctlEmployee2.SelectedEmployee.EmployeeID;
            }
            catch
            {
                nEmployeeID = 0;
            }

            DBController.Instance.OpenNewConnection();
            OutletCommissionEmployees oOutletCommissionEmployees = new OutletCommissionEmployees();
            oOutletCommissionEmployees.Refresh(dtMonth.Value.Month, dtMonth.Value.Year, nLocationID, nEmployeeID, firstDay, lastDay);
            DBController.Instance.CloseConnection();
            

            foreach (OutletCommissionEmployee oOutletCommissionEmployee in oOutletCommissionEmployees)
            {
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvOutletCommissionEmployeeList);
                oRow.Cells[0].Value = oOutletCommissionEmployee.EmployeeCode.ToString();
                oRow.Cells[1].Value = oOutletCommissionEmployee.EmployeeName.ToString();
                oRow.Cells[2].Value = oOutletCommissionEmployee.DesignationName.ToString();
                oRow.Cells[3].Value = oOutletCommissionEmployee.DepartmentName.ToString();
                //oRow.Cells[4].Value = oOutletCommissionEmployee.JobLocationName.ToString();
                oRow.Cells[4].Value = oOutletCommissionEmployee.JobLocationName;
                //oRow.Cells[5].Value = oOutletCommissionEmployee.EmployeeType.ToString();
                oRow.Cells[5].Value = Enum.GetName(typeof(Dictionary.OutletEmployeeType), oOutletCommissionEmployee.OutletEmployeeType);
                //oRow.Cells[6].Value = oOutletCommissionEmployee.ProductCategory.ToString();
                oRow.Cells[6].Value = Enum.GetName(typeof(Dictionary.ProductCategory), oOutletCommissionEmployee.ProductCategoryID);


                oRow.Cells[7].Value = oOutletCommissionEmployee.TMonth.ToString();
                oRow.Cells[8].Value = oOutletCommissionEmployee.TYear.ToString();
                oRow.Cells[9].Value = oOutletCommissionEmployee.WorkingFromDate;
                oRow.Cells[10].Value = oOutletCommissionEmployee.WorkingToDate;
                oRow.Cells[11].Value = oOutletCommissionEmployee.TotalWorkingDay.ToString();
                oRow.Cells[12].Value = oOutletCommissionEmployee.OutletEmployeeID.ToString();
                oRow.Cells[13].Value = oOutletCommissionEmployee.ID.ToString();
                dgvOutletCommissionEmployeeList.Rows.Add(oRow);

            }


            if (_dt.Rows.Count > 0)
            {
                
               
            }
            else
            {
                foreach (DataGridViewRow row in dgvOutletCommissionEmployeeList.Rows)
                {
                    DataRow dr = _dt.NewRow();
                    for (int j = 0; j < dgvOutletCommissionEmployeeList.Columns.Count; j++)
                    {
                        dr["column" + j.ToString()] = row.Cells[j].Value;
                    }

                    _dt.Rows.Add(dr);
                }
            }



           
        }

        private void dtMonth_ValueChanged(object sender, EventArgs e)
        {
            LoadData();
        }

       
        private void btnGet_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (ctlEmployee2.SelectedEmployee.EmployeeCode.Trim() != null)
                {
                    btnSave.Enabled = false;
                    sEmployee = ctlEmployee2.SelectedEmployee.EmployeeCode.Trim();
                }
            }
            catch
            {
                btnSave.Enabled = true;
                sEmployee = "";
                if (cmbOutlet.SelectedIndex == 0)
                {

                    btnSave.Enabled = true;
                }
                else
                {
                    btnSave.Enabled = false;
                }
            }
            
           

            LoadData1();
            
        }

        private void dgvOutletCommissionEmployeeList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1) return;
            if (e.ColumnIndex==9|| e.ColumnIndex == 10)
            {
                dgvOutletCommissionEmployeeList.Rows[e.RowIndex].Cells[11].Value = (Convert.ToDateTime(dgvOutletCommissionEmployeeList.Rows[e.RowIndex].Cells[10].Value) - Convert.ToDateTime(dgvOutletCommissionEmployeeList.Rows[e.RowIndex].Cells[9].Value)).TotalDays+1;
            }
            if(e.ColumnIndex==4)
            {
                //dgvOutletCommissionEmployeeList.Rows[e.RowIndex].Cells[14].Value=_oJobLocations[txtJobLocationName.]
            }
        }

        private void dgvOutletCommissionEmployeeList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        int _nAddRow=0;
        private void btnAddToList_Click(object sender, EventArgs e)
        {
            try
            {
                DBController.Instance.OpenNewConnection();
                OutletCommissionEmployee oOutletCommissionEmployee = new OutletCommissionEmployee();
                oOutletCommissionEmployee.OutletEmployeeID = ctlEmployee1.SelectedEmployee.EmployeeID;
                oOutletCommissionEmployee.Refresh();
                DBController.Instance.CloseConnection();
                
                DataGridViewRow oRow = new DataGridViewRow();
                oRow.CreateCells(dgvOutletCommissionEmployeeList);
                oRow.Cells[0].Value = oOutletCommissionEmployee.EmployeeCode.ToString();
                oRow.Cells[1].Value = oOutletCommissionEmployee.EmployeeName.ToString();
                oRow.Cells[2].Value = oOutletCommissionEmployee.DesignationName.ToString();
                oRow.Cells[3].Value = oOutletCommissionEmployee.DepartmentName.ToString();
                oRow.Cells[4].Value = oOutletCommissionEmployee.JobLocationName.ToString();
                oRow.Cells[5].Value = Enum.GetName(typeof(Dictionary.OutletEmployeeType), oOutletCommissionEmployee.OutletEmployeeType);//oOutletCommissionEmployee.EmployeeType.ToString();
                oRow.Cells[6].Value = Enum.GetName(typeof(Dictionary.ProductCategory), oOutletCommissionEmployee.ProductCategoryID);// oOutletCommissionEmployee.ProductCategory.ToString();
                oRow.Cells[7].Value = dtMonth.Value.Month;
                oRow.Cells[8].Value = dtMonth.Value.Year;
                oRow.Cells[9].Value = firstDay;
                oRow.Cells[10].Value = lastDay;
                oRow.Cells[11].Value = Convert.ToInt32((lastDay - firstDay).TotalDays) + 1;
                oRow.Cells[12].Value = oOutletCommissionEmployee.OutletEmployeeID.ToString();
                oRow.Cells[13].Value = 0;
                dgvOutletCommissionEmployeeList.Rows.Add(oRow);


                //DataTable dtnew = new DataTable();
                //for (int i = 0; i < dgvOutletCommissionEmployeeList.Columns.Count; i++)
                //{
                //    dtnew.Columns.Add("column" + i.ToString());
                //}
                //DataRow dr = dtnew.NewRow();
                //for (int j = 0; j < dgvOutletCommissionEmployeeList.Columns.Count; j++)
                //{
                //    dr["column" + j.ToString()] = oRow.Cells[j].Value;
                //}

                //dtnew.Rows.Add(dr);                

                //_dt.Merge(dtnew);

                //_nOutlet = cmbOutlet.SelectedIndex;

                dgvOutletCommissionEmployeeList.Rows[dgvOutletCommissionEmployeeList.Rows.Count-1].Selected = true;
                _nAddRow = 1;
            }
            catch
            {
                MessageBox.Show("Please select a valid employee");
            }
        }

        private void cmbOutlet_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                nLocationID = _oJobLocations[cmbOutlet.SelectedIndex - 1].JobLocationID;
            }
            catch
            {
                nLocationID = 0;
            }
        }

        //private void dgvOutletCommissionEmployeeList_DataError(object sender, DataGridViewDataErrorEventArgs e)
        //{
        //    e.Cancel = true;
        //}

        private void LoadData1()
        {
            DataTable dtOutletCommissionEmployeeList = new DataTable();
            dtOutletCommissionEmployeeList = _dt;
           
            if (_nAddRow == 1)
            {
                DataTable dtnew = new DataTable();
                for (int i = 0; i < dgvOutletCommissionEmployeeList.Columns.Count; i++)
                {
                    dtnew.Columns.Add("column" + i.ToString());
                }
                DataRow dr = dtnew.NewRow();
                for (int j = 0; j < dgvOutletCommissionEmployeeList.Columns.Count; j++)
                {
                    dr["column" + j.ToString()] = dgvOutletCommissionEmployeeList.Rows[dgvOutletCommissionEmployeeList.Rows.Count-1].Cells[j].Value;
                }

                dtnew.Rows.Add(dr);

                _dt.Merge(dtnew);

            }

            if (sEmployee=="" && _nOutlet != -1)
            {
                    DataTable dtnew = new DataTable();
                    for (int i = 0; i < dgvOutletCommissionEmployeeList.Columns.Count; i++)
                    {
                        dtnew.Columns.Add("column" + i.ToString());
                    }

                    foreach (DataGridViewRow row in dgvOutletCommissionEmployeeList.Rows)
                    {
                        if (_nAddRow == 1 && row.Index< dgvOutletCommissionEmployeeList.Rows.Count-1)
                        {
                            DataRow dr = dtnew.NewRow();
                            for (int j = 0; j < dgvOutletCommissionEmployeeList.Columns.Count; j++)
                            {
                                dr["column" + j.ToString()] = row.Cells[j].Value;
                            }

                            dtnew.Rows.Add(dr);
                        }

                        if(_nAddRow != 1)
                        {
                            DataRow dr = dtnew.NewRow();
                            for (int j = 0; j < dgvOutletCommissionEmployeeList.Columns.Count; j++)
                            {
                                dr["column" + j.ToString()] = row.Cells[j].Value;
                            }

                            dtnew.Rows.Add(dr);
                        }
                    }

                    _dt.Merge(dtnew);
              
            }

            if (sEmployee!= "" &&  _nOutlet != -1)
            {
                    DataTable dtnew = new DataTable();
                    for (int i = 0; i < dgvOutletCommissionEmployeeList.Columns.Count; i++)
                    {
                        dtnew.Columns.Add("column" + i.ToString());
                    }

                    foreach (DataGridViewRow row in dgvOutletCommissionEmployeeList.Rows)
                    {
                        if (_nAddRow == 1 && row.Index < dgvOutletCommissionEmployeeList.Rows.Count - 1)
                        {
                            DataRow dr = dtnew.NewRow();
                            for (int j = 0; j < dgvOutletCommissionEmployeeList.Columns.Count; j++)
                            {
                                dr["column" + j.ToString()] = row.Cells[j].Value;
                            }

                            dtnew.Rows.Add(dr);
                        }

                        if (_nAddRow != 1)
                        {
                            DataRow dr = dtnew.NewRow();
                            for (int j = 0; j < dgvOutletCommissionEmployeeList.Columns.Count; j++)
                            {
                                dr["column" + j.ToString()] = row.Cells[j].Value;
                            }

                            dtnew.Rows.Add(dr);
                        }
                }

                 _dt.Merge(dtnew);
                
            }

            _dt.DefaultView.Sort = "Column4";

            _nAddRow = 0;
            dgvOutletCommissionEmployeeList.Rows.Clear();

                if (cmbOutlet.SelectedIndex > 0 || sEmployee!="")
                {
                    if (sEmployee!="" && cmbOutlet.SelectedIndex > 0)
                    {
                        _nOutlet = cmbOutlet.SelectedIndex;
                        _dt.DefaultView.RowFilter = string.Format("Convert([Column0], 'System.String') = '{0}'", sEmployee);
                    }
                    else if (cmbOutlet.SelectedIndex > 0)
                    {
                        _nOutlet = cmbOutlet.SelectedIndex;
                        _dt.DefaultView.RowFilter = string.Format("Convert([Column4], 'System.String') = '{0}'", cmbOutlet.Text);
                    }
                    else if (sEmployee != "" && cmbOutlet.SelectedIndex == 0 )
                    {
                        _dt.DefaultView.RowFilter = string.Format("Convert([Column0], 'System.String') = '{0}'", sEmployee);
                    }
                   

                    foreach (DataRowView dr in _dt.DefaultView)
                    {
                        DataGridViewRow oRow = new DataGridViewRow();
                        oRow.CreateCells(dgvOutletCommissionEmployeeList);
                        oRow.Cells[0].Value = dr[0].ToString();
                        oRow.Cells[1].Value = dr[1].ToString();
                        oRow.Cells[2].Value = dr[2].ToString();
                        oRow.Cells[3].Value = dr[3].ToString();
                        oRow.Cells[4].Value = dr[4].ToString();
                        oRow.Cells[5].Value = dr[5].ToString();
                        oRow.Cells[6].Value = dr[6].ToString();
                        oRow.Cells[7].Value = dr[7].ToString();
                        oRow.Cells[8].Value = dr[8].ToString();
                        oRow.Cells[9].Value = Convert.ToDateTime(dr[9]);
                        oRow.Cells[10].Value = Convert.ToDateTime(dr[10]);
                        oRow.Cells[11].Value = dr[11].ToString();
                        oRow.Cells[12].Value = dr[12].ToString();
                        oRow.Cells[13].Value = dr[13].ToString();
                        dgvOutletCommissionEmployeeList.Rows.Add(oRow);
                    }


                    for (int j = 0; j < dgvOutletCommissionEmployeeList.Rows.Count; j++)
                    {
                        for (int i = dtOutletCommissionEmployeeList.Rows.Count - 1; i >= 0; i--)
                        {
                            DataRow dr = dtOutletCommissionEmployeeList.Rows[i];
                            try
                            {
                                if (dr["Column0"] == dgvOutletCommissionEmployeeList.Rows[j].Cells[0].Value && dr["Column4"] == dgvOutletCommissionEmployeeList.Rows[j].Cells[4].Value && dr["Column5"] == dgvOutletCommissionEmployeeList.Rows[j].Cells[5].Value && dr["Column6"] == dgvOutletCommissionEmployeeList.Rows[j].Cells[6].Value)//_dt.Rows[j].Field<string>(3))
                                {
                                    dr.Delete();
                                }
                            }
                            catch
                            {
                                break;
                            }
                        }
                    }
                    dtOutletCommissionEmployeeList.AcceptChanges();

                    _dt = dtOutletCommissionEmployeeList;
                }
                else
                {
                    foreach (DataRow dr in _dt.Rows)
                    {
                        DataGridViewRow oRow = new DataGridViewRow();
                        oRow.CreateCells(dgvOutletCommissionEmployeeList);
                        oRow.Cells[0].Value = dr[0].ToString();
                        oRow.Cells[1].Value = dr[1].ToString();
                        oRow.Cells[2].Value = dr[2].ToString();
                        oRow.Cells[3].Value = dr[3].ToString();
                        oRow.Cells[4].Value = dr[4].ToString();
                        oRow.Cells[5].Value = dr[5].ToString();
                        oRow.Cells[6].Value = dr[6].ToString();
                        oRow.Cells[7].Value = dr[7].ToString();
                        oRow.Cells[8].Value = dr[8].ToString();
                        oRow.Cells[9].Value = Convert.ToDateTime(dr[9]);
                        oRow.Cells[10].Value = Convert.ToDateTime(dr[10]);
                        oRow.Cells[11].Value = dr[11].ToString();
                        oRow.Cells[12].Value = dr[12].ToString();
                        oRow.Cells[13].Value = dr[13].ToString();
                        dgvOutletCommissionEmployeeList.Rows.Add(oRow);
                    }

                    _nOutlet = -1;
                }

                if (_nOutlet == -1 && sEmployee != "")
                {
                    DataTable dtnew = new DataTable();
                    for (int i = 0; i < dgvOutletCommissionEmployeeList.Columns.Count; i++)
                    {
                        dtnew.Columns.Add("column" + i.ToString());
                    }

                    foreach (DataGridViewRow row in dgvOutletCommissionEmployeeList.Rows)
                    {
                        DataRow dr = dtnew.NewRow();
                        for (int j = 0; j < dgvOutletCommissionEmployeeList.Columns.Count; j++)
                        {
                            dr["column" + j.ToString()] = row.Cells[j].Value;
                        }

                        dtnew.Rows.Add(dr);
                    }

                    _dt.Merge(dtnew);
                }
        }

        DataTable _Delete;
        private void dgvOutletCommissionEmployeeList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Delete)
            {
                //dgvOutletCommissionEmployeeList.Rows.RemoveAt(0);
                for (int i = _dt.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dr = _dt.Rows[i];
                   
                    if (dr["Column0"] == dgvOutletCommissionEmployeeList.Rows[dgvOutletCommissionEmployeeList.CurrentCell.RowIndex].Cells[0].Value && dr["Column4"] == dgvOutletCommissionEmployeeList.Rows[dgvOutletCommissionEmployeeList.CurrentCell.RowIndex].Cells[4].Value && dr["Column5"] == dgvOutletCommissionEmployeeList.Rows[dgvOutletCommissionEmployeeList.CurrentCell.RowIndex].Cells[5].Value && dr["Column6"] == dgvOutletCommissionEmployeeList.Rows[dgvOutletCommissionEmployeeList.CurrentCell.RowIndex].Cells[6].Value)//_dt.Rows[j].Field<string>(3))
                    {
                        DataRow drDel = _Delete.NewRow();
                        for (int j = 0; j < _dt.Columns.Count; j++)
                        {
                            drDel["column" + j.ToString()] = dr[j];
                        }

                        _Delete.Rows.Add(drDel);


                        dr.Delete();
                    }

                }
                _dt.AcceptChanges();
            }
        }
    }
}

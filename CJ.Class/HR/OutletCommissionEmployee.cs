using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.HR
{
    public class OutletCommissionEmployee
    {
        private int _nID;
        private int _nOutletEmployeeID;
        private int _nLocationID;
        private int _nProductCategoryID;
        private int _nOutletEmployeeType;
        private int _nTMonth;
        private int _nTYear;
        private DateTime _dWorkingFromDate;
        private DateTime _dWorkingToDate;
        private int _nTotalWorkingDay;
        private int _nCreateUserID;
        private DateTime _dCreateDate;

        private string _EmployeeCode;
        private string _EmployeeName;
        private string _DesignationName;
        private string _DepartmentName;
        private string _JobLocationName;
        private string _EmployeeType;
        private string _ProductCategory;

        public string EmployeeCode
        {
            get { return _EmployeeCode; }
            set { _EmployeeCode = value; }
        }
        public string EmployeeName
        {
            get { return _EmployeeName; }
            set { _EmployeeName = value; }
        }
        public string DesignationName
        {
            get { return _DesignationName; }
            set { _DesignationName = value; }
        }
        public string DepartmentName
        {
            get { return _DepartmentName; }
            set { _DepartmentName = value; }

        }
        public string JobLocationName
        {
            get { return _JobLocationName; }
            set { _JobLocationName = value; }
        }
        public string EmployeeType
        {
            get { return _EmployeeType; }
            set { _EmployeeType = value; }
        }

        public string ProductCategory
        {
            get { return _ProductCategory; }
            set { _ProductCategory = value; }
        }


        // <summary>
        // Get set property for EMITenureID
        // </summary>
        public int ID
        {
            get { return _nID; }
            set { _nID = value; }
        }

        public int OutletEmployeeID
        {
            get { return _nOutletEmployeeID; }
            set { _nOutletEmployeeID = value; }
        }

        public int LocationID
        {
            get { return _nLocationID; }
            set { _nLocationID = value; }
        }

        public int ProductCategoryID
        {
            get { return _nProductCategoryID; }
            set { _nProductCategoryID = value; }
        }

        public int OutletEmployeeType
        {
            get { return _nOutletEmployeeType; }
            set { _nOutletEmployeeType = value; }
        }
        public int TMonth
        {
            get { return _nTMonth; }
            set { _nTMonth = value; }
        }

        public int TYear
        {
            get { return _nTYear; }
            set { _nTYear = value; }
        }

        public DateTime WorkingFromDate
        {
            get { return _dWorkingFromDate; }
            set { _dWorkingFromDate = value; }
        }

        // <summary>
        // Get set property for ApproveUserID
        // </summary>
        public DateTime WorkingToDate
        {
            get { return _dWorkingToDate; }
            set { _dWorkingToDate = value; }
        }
        // <summary>
        // Get set property for Tenure
        // </summary>
        public int TotalWorkingDay
        {
            get { return _nTotalWorkingDay; }
            set { _nTotalWorkingDay = value; }
        }

        // <summary>
        // Get set property for Status
        // </summary>
        public int CreateUserID
        {
            get { return _nCreateUserID; }
            set { _nCreateUserID = value; }
        }

       

        // <summary>
        // Get set property for CreateDate
        // </summary>
        public DateTime CreateDate
        {
            get { return _dCreateDate; }
            set { _dCreateDate = value; }
        }

       

        public void Add()
        {
            int nMaxID = 0;
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                
                //sSql = "SELECT MAX([ID]) FROM t_OutletCommissionEmployeeList";
                
                //cmd.CommandText = sSql;
                //object maxID = cmd.ExecuteScalar();
                //if (maxID == DBNull.Value)
                //{
                //    nMaxID = 1;
                //}
                //else
                //{
                //    nMaxID = Convert.ToInt32(maxID) + 1;
                //}
                //_nID = nMaxID;
               
                sSql = "INSERT INTO t_OutletCommissionEmployeeList ( OutletEmployeeID, LocationID, ProductCategoryID, OutletEmployeeType, TMonth,TYear,WorkingFromDate,WorkingToDate,TotalWorkingDay,CreateUserID,CreateDate) VALUES(?,?,?,?,?,?,?,?,?,?,?)";
                
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                //cmd.Parameters.AddWithValue("ID", _nID);
                cmd.Parameters.AddWithValue("OutletEmployeeID", _nOutletEmployeeID);
                cmd.Parameters.AddWithValue("LocationID", _nLocationID);
                cmd.Parameters.AddWithValue("ProductCategoryID", _nProductCategoryID);
                cmd.Parameters.AddWithValue("OutletEmployeeType", _nOutletEmployeeType);
                cmd.Parameters.AddWithValue("TMonth", _nTMonth);
                cmd.Parameters.AddWithValue("TYear", _nTYear);
                cmd.Parameters.AddWithValue("WorkingFromDate", _dWorkingFromDate);
                cmd.Parameters.AddWithValue("WorkingToDate", _dWorkingToDate);
                cmd.Parameters.AddWithValue("TotalWorkingDay", _nTotalWorkingDay);
                cmd.Parameters.AddWithValue("CreateUserID", Utility.UserId);
                cmd.Parameters.AddWithValue("CreateDate", DateTime.Now);

                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


        public void Edit(int nMonth, int nYear)
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {

                sSql = "UPDATE t_OutletCommissionEmployeeList SET LocationID=?,ProductCategoryID=?,OutletEmployeeType=?, WorkingFromDate = ?, WorkingToDate=?,TotalWorkingDay=? WHERE ID = ? and TMonth=" + nMonth + " and TYear=" + nYear + "";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.AddWithValue("LocationID", _nLocationID);
                cmd.Parameters.AddWithValue("ProductCategoryID", _nProductCategoryID);
                cmd.Parameters.AddWithValue("OutletEmployeeType", _nOutletEmployeeType);
                cmd.Parameters.AddWithValue("WorkingFromDate", _dWorkingFromDate);
                cmd.Parameters.AddWithValue("WorkingToDate", _dWorkingToDate);
                cmd.Parameters.AddWithValue("TotalWorkingDay", _nTotalWorkingDay);
                cmd.Parameters.AddWithValue("ID", _nID);


                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        public void Delete()
        {
            OleDbCommand cmd = DBController.Instance.GetCommand();
            string sSql = "";
            try
            {
                
                sSql = "delete from t_OutletCommissionEmployeeList WHERE ID = ?";
                
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("ID", _nID);
                cmd.ExecuteNonQuery();
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public void Refresh()
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSql = "";
           
            sSql = String.Format(@"Select EmployeeID,EmployeeCode,EmployeeName,DesignationName,DepartmentName,a.LocationID,JobLocationName,ProductCategoryID,ProductCategory,c.OutletEmployeeType,EmployeeType
                                 From v_EmployeeDetails a
                                Inner Join t_Showroom b
                                on a.LocationID=b.LocationID 
                                Left Outer Join 
                                (
                                Select OutletEmployeeID,OutletEmployeeType,a.ProductCategoryID,case when OutletEmployeeType=1 then 'Manager'
                                when OutletEmployeeType=2 then 'Executive'
                                when OutletEmployeeType=3 then 'ShopAssistant' 
                                when OutletEmployeeType=4 then 'SPC'
                                when OutletEmployeeType=5 then 'HPC'
                                else 'Other' end as EmployeeType,isnull(b.ProductCategory,'NA') ProductCategory From t_OutletEmployee a
                                left outer join (Select distinct ProductCategory,ProductCategoryID From t_OutletCommissionProductGroup) b
                                on a.ProductCategoryID=b.ProductCategoryID ) c
                                on a.EmployeeID=c.OutletEmployeeID
                                Where EmployeeID={0}", _nOutletEmployeeID);


            try
            {
                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                                
                    if (reader.Read())
                    {
                        _EmployeeCode = reader["EmployeeCode"].ToString();
                        _EmployeeName = reader["EmployeeName"].ToString();
                        _DesignationName = reader["DesignationName"].ToString();
                        _DepartmentName = reader["DepartmentName"].ToString();
                        _JobLocationName = reader["JobLocationName"].ToString();
                        _EmployeeType = reader["EmployeeType"].ToString();
                        _ProductCategory = reader["ProductCategory"].ToString();

                        _nOutletEmployeeID = (int)reader["EmployeeID"];
                        _nLocationID = (int)reader["LocationID"];
                        _nProductCategoryID = (int)reader["ProductCategoryID"];
                        _nOutletEmployeeType = (int)reader["OutletEmployeeType"];
                        

                    reader.Close();
                }
                
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }


    }
    public class OutletCommissionEmployees : CollectionBase
    {
        public OutletCommissionEmployee this[int i]
        {
            get { return (OutletCommissionEmployee)InnerList[i]; }
            set { InnerList[i] = value; }
        }
        public void Add(OutletCommissionEmployee oOutletCommissionEmployee)
        {
            InnerList.Add(oOutletCommissionEmployee);
        }
        public int GetIndex(int nID)
        {
            int i;
            for (i = 0; i < this.Count; i++)
            {
                if (this[i].ID == nID)
                {
                    return i;
                }
            }
            return -1;
        }

        public void Refresh(int nMonth, int nYear, int nLocationID, int nEmployeeID,DateTime firstDay, DateTime lastDay)
        {

            OleDbCommand cmd = DBController.Instance.GetCommand();
            OleDbCommand cmd1 = DBController.Instance.GetCommand();

            string sSql = "";
            string sSql1 = "";

            sSql = String.Format(@"select ID, EmployeeCode, EmployeeName, DepartmentName, DesignationName,JobLocationName,(case when OutletEmployeeType=1 then 'Manager'
                                when OutletEmployeeType=2 then 'Executive'
                                when OutletEmployeeType=3 then 'ShopAssistant' 
                                when OutletEmployeeType=4 then 'SPC'
                                when OutletEmployeeType=5 then 'HPC'
                                else 'Other' end) [EmployeeType],(case when ProductCategoryID=1 then 'Electronics'
                                when ProductCategoryID=2 then 'Appliances'
                                when ProductCategoryID=3 then 'Mobile' 
                                else 'Other' end) [ProductCategory],TMonth,TYear,WorkingFromDate,WorkingToDate,TotalWorkingDay,OutletEmployeeType,ProductCategoryID,JobLocationID [LocationID],OutletEmployeeID from t_OutletCommissionEmployeeList A, t_Employee B, t_JobLocation C,t_Designation D, t_Department E  WHERE  A.OutletEmployeeID=B.EmployeeID and A.LocationID=C.JobLocationID and B.DesignationID=D.DesignationID and B.DepartmentID=E.DepartmentID  and TMonth=" + nMonth + " and TYear=" + nYear + "");
            sSql1 = String.Format(@"Select EmployeeID,EmployeeCode,EmployeeName,DesignationName,DepartmentName,a.LocationID,JobLocationName,ProductCategoryID,ProductCategory,c.OutletEmployeeType,EmployeeType,
                                month(GETDATE()) as Tmonth,year(GETDATE()) Tyear,DATEADD(month, DATEDIFF(month, 0, getdate()), 0) as WorkingFromDate,
                                DATEADD(d, -1, DATEADD(m, DATEDIFF(m, 0, getdate()) + 1, 0)) as WorkingToDate,0 as TotalWorkingDay From v_EmployeeDetails a
                                Inner Join t_Showroom b
                                on a.LocationID=b.LocationID 
                                Left Outer Join 
                                (
                                Select OutletEmployeeID,OutletEmployeeType,a.ProductCategoryID,case when OutletEmployeeType=1 then 'Manager'
                                when OutletEmployeeType=2 then 'Executive'
                                when OutletEmployeeType=3 then 'ShopAssistant' 
                                when OutletEmployeeType=4 then 'SPC'
                                when OutletEmployeeType=5 then 'HPC'
                                else 'Other' end as EmployeeType,isnull(b.ProductCategory,'NA') ProductCategory From t_OutletEmployee a
                                left outer join (Select distinct ProductCategory,ProductCategoryID From t_OutletCommissionProductGroup) b
                                on a.ProductCategoryID=b.ProductCategoryID ) c
                                on a.EmployeeID=c.OutletEmployeeID
                                Where  EMPStatus in (1,2)  and b.ShowroomCode<>'ETD' and b.LocationID<>1 order by JobLocationName,OutletEmployeeType,ProductCategoryID ");
           

            try
            {
                if(nLocationID!=0)
                {
                    sSql = sSql + " and A.LocationID=" + nLocationID + "";
                    sSql1 = sSql1 + " and a.LocationID=" + nLocationID + "";
                }

                if (nEmployeeID != 0)
                {
                    sSql = sSql + " and A.OutletEmployeeID=" + nEmployeeID + "";
                    sSql1 = sSql1 + " and a.EmployeeID=" + nEmployeeID + "";
                }

                sSql = sSql + " order by JobLocationName,OutletEmployeeType,ProductCategoryID";

                cmd.CommandText = sSql;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();

                cmd1.CommandText = sSql1;
                cmd1.CommandType = CommandType.Text;
                IDataReader reader1 = cmd1.ExecuteReader();
                int nCount = 0;
               if(nCount==0)
               { 
                    while (reader.Read())
                    {
                        OutletCommissionEmployee oOutletCommissionEmployee = new OutletCommissionEmployee();
                        oOutletCommissionEmployee.ID = (int)reader["ID"];
                        oOutletCommissionEmployee.EmployeeCode = reader["EmployeeCode"].ToString();
                        oOutletCommissionEmployee.EmployeeName = reader["EmployeeName"].ToString();
                        oOutletCommissionEmployee.DesignationName = reader["DesignationName"].ToString();
                        oOutletCommissionEmployee.DepartmentName = reader["DepartmentName"].ToString();
                        oOutletCommissionEmployee.JobLocationName = reader["JobLocationName"].ToString();
                        oOutletCommissionEmployee.EmployeeType = reader["EmployeeType"].ToString();
                        oOutletCommissionEmployee.ProductCategory = reader["ProductCategory"].ToString();

                        oOutletCommissionEmployee.OutletEmployeeID = (int)reader["OutletEmployeeID"];
                        oOutletCommissionEmployee.LocationID = (int)reader["LocationID"];
                        oOutletCommissionEmployee.ProductCategoryID = (int)reader["ProductCategoryID"];
                        oOutletCommissionEmployee.OutletEmployeeType = (int)reader["OutletEmployeeType"];
                        oOutletCommissionEmployee.TMonth = (int)reader["TMonth"];
                        oOutletCommissionEmployee.TYear = (int)reader["TYear"];
                        oOutletCommissionEmployee.WorkingFromDate = (DateTime)reader["WorkingFromDate"];
                        oOutletCommissionEmployee.WorkingToDate = (DateTime)reader["WorkingToDate"];
                        oOutletCommissionEmployee.TotalWorkingDay = Convert.ToInt32((oOutletCommissionEmployee.WorkingToDate - oOutletCommissionEmployee.WorkingFromDate).TotalDays) + 1;
                        //oOutletCommissionEmployee.CreateUserID = (int)reader["CreateUserID"];
                        //oOutletCommissionEmployee.CreateDate = (DateTime)reader["CreateDate"];
                        InnerList.Add(oOutletCommissionEmployee);
                        nCount = nCount + 1;
                    }

                    reader.Close();
                }
               
                if(nCount==0)
                {
                    while (reader1.Read())
                    {
                        OutletCommissionEmployee oOutletCommissionEmployee = new OutletCommissionEmployee();
                        oOutletCommissionEmployee.ID = 0;
                        oOutletCommissionEmployee.EmployeeCode = reader1["EmployeeCode"].ToString();
                        oOutletCommissionEmployee.EmployeeName = reader1["EmployeeName"].ToString();
                        oOutletCommissionEmployee.DesignationName = reader1["DesignationName"].ToString();
                        oOutletCommissionEmployee.DepartmentName = reader1["DepartmentName"].ToString();
                        oOutletCommissionEmployee.JobLocationName = reader1["JobLocationName"].ToString();
                        oOutletCommissionEmployee.EmployeeType = reader1["EmployeeType"].ToString();
                        oOutletCommissionEmployee.ProductCategory = reader1["ProductCategory"].ToString();

                        oOutletCommissionEmployee.OutletEmployeeID = (int)reader1["EmployeeID"];
                        oOutletCommissionEmployee.LocationID = (int)reader1["LocationID"];
                        oOutletCommissionEmployee.ProductCategoryID = (int)reader1["ProductCategoryID"];
                        oOutletCommissionEmployee.OutletEmployeeType = (int)reader1["OutletEmployeeType"];
                        oOutletCommissionEmployee.TMonth = nMonth;//(int)reader1["TMonth"];
                        oOutletCommissionEmployee.TYear = nYear;//(int)reader1["TYear"];
                        oOutletCommissionEmployee.WorkingFromDate = firstDay;//(DateTime)reader1["WorkingFromDate"];
                        oOutletCommissionEmployee.WorkingToDate = lastDay;//(DateTime)reader1["WorkingToDate"];
                        oOutletCommissionEmployee.TotalWorkingDay = Convert.ToInt32((oOutletCommissionEmployee.WorkingToDate - oOutletCommissionEmployee.WorkingFromDate).TotalDays) +1;
                        //oOutletCommissionEmployee.CreateUserID = (int)reader["CreateUserID"];
                        //oOutletCommissionEmployee.CreateDate = (DateTime)reader["CreateDate"];
                        InnerList.Add(oOutletCommissionEmployee);
                    }
                    reader1.Close();
                }
                InnerList.TrimToSize();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        
    }
}

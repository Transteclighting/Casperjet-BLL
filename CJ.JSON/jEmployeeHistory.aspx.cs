using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Data.OleDb;
using System.Web;

using Newtonsoft.Json;
using System.Collections.Generic;
using CJ.Class;
using CJ.Class.Library;

public partial class jEmployeeHistory : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            HttpContext c = HttpContext.Current;

            string sUser = c.Request.Form["UserName"].Trim();
            string sType = c.Request.Form["Type"].Trim();

            string sEmployeeCode = "";
            if (c.Request.Form["EmployeeCode"] != null)
            {
                sEmployeeCode = c.Request.Form["EmployeeCode"].Trim();
            }

            string sEmployeeName = "";
            if (c.Request.Form["EmployeeName"] != null)
            {
                sEmployeeName = c.Request.Form["EmployeeName"].Trim();
            }

            string sCompanyCode = "";
            if (c.Request.Form["CompanyCode"] != null)
            {
                sCompanyCode = c.Request.Form["CompanyCode"].Trim();
            }

            string sDepartmentName = "";
            if (c.Request.Form["DepartmentName"] != null)
            {
                sDepartmentName = c.Request.Form["DepartmentName"].Trim();
            }

            string sEquivalentGradeName = "";
            if (c.Request.Form["EquivalentGradeName"] != null)
            {
                sEquivalentGradeName = c.Request.Form["EquivalentGradeName"].Trim();
            }

            string sEMPStatus = "";
            if (c.Request.Form["EMPStatus"] != null)
            {
                sEMPStatus = c.Request.Form["EMPStatus"].Trim();
            }

            string _bIsCheckFactory = "";
            if (c.Request.Form["IsCheckFactory"] != null)
            {
                _bIsCheckFactory = c.Request.Form["IsCheckFactory"].Trim();
            }

            string sIsFactoryEmployee = "";
            if (c.Request.Form["IsFactoryEmployee"] != null)
            {
                sIsFactoryEmployee = c.Request.Form["IsFactoryEmployee"].Trim();
            }

            string _bIsCheckLoS = "";
            if (c.Request.Form["IsCheckLoS"] != null)
            {
                _bIsCheckLoS = c.Request.Form["IsCheckLoS"].Trim();
            }

            string sCondition = "";
            if (c.Request.Form["Condition"] != null)
            {
                sCondition = c.Request.Form["Condition"].Trim();
            }

            string sFromMonth = "";
            if (c.Request.Form["FromMonth"] != null)
            {
                sFromMonth = c.Request.Form["FromMonth"].Trim();
            }

            string sToMonth = "";
            if (c.Request.Form["ToMonth"] != null)
            {
                sToMonth = c.Request.Form["ToMonth"].Trim();
            }

            string sYear = "";
            if (c.Request.Form["Year"] != null)
            {
                sYear = c.Request.Form["Year"].Trim();
            }

            string sEmployeeId = "";
            if (c.Request.Form["EmployeeID"] != null)
            {
                sEmployeeId = c.Request.Form["EmployeeID"].Trim();
            }


            //string sEmployeeId = "";
            //string sUser = "hakim";
            //string sType = "Employee";
            //string sEmployeeCode = "";
            //string sEmployeeName = "";
            //string sCompanyCode = "TEL";

            //string sDepartmentName = "All";
            //string sEquivalentGradeName = "All";
            //string sEMPStatus = "Running";

            //string _bIsCheckFactory = "true";
            //string sIsFactoryEmployee = "Yes";

            //string _bIsCheckLoS = "false";
            //string sCondition = ">";
            //string sFromMonth = "100";
            //string sToMonth = "";
            //string sYear = "";



            Datas _oDatas = new Datas();
            string sOutput = "";
            Data oData = new Data();

            if (!DBController.Instance.CheckConnection())
            {
                DBController.Instance.OpenNewConnection();
            }
            

            if (sType == "Employee")
            {
                string sEmployeeStatus = "";
                if (sEMPStatus == "Running")
                {
                    sEmployeeStatus = (int)Dictionary.HREmployeeStatus.Contractual + "," + (int)Dictionary.HREmployeeStatus.Confirmed;
                }
                else
                {
                    sEmployeeStatus = Convert.ToString((int)Enum.Parse(typeof(Dictionary.HREmployeeStatus), sEMPStatus));
                    //string stringValue = Enum.GetName(typeof(EnumDisplayStatus), dbValue);
                }

                sOutput = JsonConvert.SerializeObject(_oDatas.GetEmployee(sEmployeeCode, sEmployeeName, sCompanyCode, sDepartmentName, sEquivalentGradeName, sEmployeeStatus, _bIsCheckFactory, sIsFactoryEmployee, _bIsCheckLoS, sCondition, sFromMonth, sToMonth), Formatting.Indented);
                Response.Write(sOutput.ToString());
                oData.InsertReportLog(sUser);
            }
            else if (sType == "EmployeeSalary")
            {
                sOutput = JsonConvert.SerializeObject(_oDatas.GetEmployeeSalary(sEmployeeId, Convert.ToInt32(sYear)), Formatting.Indented);
                Response.Write(sOutput.ToString());
                oData.InsertReportLog2(sUser);
            }

            DBController.Instance.CloseConnection();
        }
    }

    public class Data
    {
        public string EmployeeID;
        public string EmployeeCode;
        public string EmployeeName;
        public string DateOfBirth;
        public string JoiningDate;
        public string DepartmentID;
        public string DepartmentName;
        public string DesignationID;
        public string DesignationName;
        public string CompanyID;
        public string CompanyCode;
        public string JobGradeName;
        public string EquivalentGradeName;
        public string EmployeeStatusName;
        public string BasicSalary;
        public string TakehomeSalary;
        public string Year;
        public string Month;
        public string Day;
        public string TotalMonth;
        public string SeparationDate;
        public string LOS;
        public string Factory;

        public string Value;

        public string MonthName;
        public string GrossSalary;
        public string Deduction;
        public string NetSalary;
        public string Age;
        public string EmployeePhoto;


        public void InsertReportLog(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10053";
            string sReportName = "Employee Detail";
            string connStr;
            connStr = ConfigurationManager.AppSettings["jConnectionString"];
            oReportLog.AddForAndroid(connStr, sReportCode, sReportName, sUser);
        }
        public void InsertReportLog2(string sUser)
        {
            ReportLog oReportLog = new ReportLog();
            string sReportCode = "A10054";
            string sReportName = "Employee Salary";
            string connStr;
            connStr = ConfigurationManager.AppSettings["jConnectionString"];
            oReportLog.AddForAndroid(connStr, sReportCode, sReportName, sUser);
        }
    }
    public class Datas : CollectionBase
    {

        public Data this[int i]
        {
            get { return (Data)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(Data oData)
        {
            InnerList.Add(oData);
        }
        TELLib _oTELLib;
        private string ExcludeDecimal(string sAmount)
        {
            string sResult = "";
            sResult = sAmount.Remove(sAmount.Length - 3);
            return sResult;
        }
        public List<Data> GetEmployee(string sEmployeeCode, string sEmployeeName, string sCompanyCode, string sDepartmentName,
            string sEquivalentGradeName, string sEMPStatus, string _bIsCheckFactory, string sIsFactoryEmployee,
            string _bIsCheckLoS, string sCondition, string sFromMonth, string sToMonth)
        {
            _oTELLib = new TELLib();
            List<Data> eList = new List<Data>();
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            int nYear = DateTime.Now.Date.Year;


            string sSQL = " Select EmployeeID, EmployeeCode, EmployeeName, DateOfBirth, JoiningDate, " +
                           " DepartmentID, DepartmentName, DesignationID, DesignationName, CompanyID, CompanyCode,  " +
                           " JobGradeName, EquivalentGradeName,EMPStatus, EmployeeStatusName,BasicSalary,TakehomeSalary, Year, Month, Day, TotalMonth, SeparationDate, EmployeePhoto, " +
                           " (CONVERT(varchar(10), AYear)+'Y, '+ CONVERT(varchar(10), AMonth)+'M, '+CONVERT(varchar(10), ADay)+'D')Age, " +
                           " (CONVERT(varchar(10), Year) + 'Y, ' + CONVERT(varchar(10), Month) + 'M, ' + CONVERT(varchar(10), Day) + 'D')LOS, " +
                           " CASE when IsFactoryEmployee = 1 then 'Yes' else 'No' end as Factory from " +
                           " ( " +
                           " Select EmployeeID, EmployeeCode, EmployeeName, DateOfBirth, JoiningDate, IsFactoryEmployee, " +
                           " DepartmentID, DepartmentName, DesignationID, DesignationName, CompanyID, CompanyCode, " +
                           " JobGradeName, EquivalentGradeName, EMPStatus, EmployeeStatusName, BasicSalary, TakehomeSalary, SeparationDate, EmployeePhoto, " +

                           " DATEDIFF(year, DATEADD(day, -1, DateOfBirth), GETDATE()) - (CASE WHEN DATEADD(year, DATEDIFF(year, DATEADD(day, -1, DateOfBirth), GETDATE()), DATEADD(day, -1, DateOfBirth)) > GETDATE() THEN 1 ELSE 0 END) as AYear, " +
                           " MONTH(GETDATE() - DATEADD(year, DATEDIFF(year, DATEADD(day, -1, DateOfBirth), GETDATE()), DATEADD(day, -1, DateOfBirth))) - 1 as AMonth,  " +
                           " DAY(GETDATE() - DATEADD(year, DATEDIFF(year, DATEADD(day, -1, DateOfBirth), GETDATE()), DATEADD(day, -1, DateOfBirth))) - 1 as ADay,  " +

                           " DATEDIFF(year, DATEADD(day, -1, JoiningDate), EndOfService) - (CASE WHEN DATEADD(year, DATEDIFF(year, DATEADD(day, -1, JoiningDate), EndOfService), DATEADD(day, -1, JoiningDate)) > EndOfService THEN 1 ELSE 0 END) as Year, " +
                           " MONTH(EndOfService - DATEADD(year, DATEDIFF(year, DATEADD(day, -1, JoiningDate), EndOfService), DATEADD(day, -1, JoiningDate))) - 1 as Month, " +
                           " DAY(EndOfService - DATEADD(year, DATEDIFF(year, DATEADD(day, -1, JoiningDate), EndOfService), DATEADD(day, -1, JoiningDate))) - 1 as Day, " +
                           " CAST(DATEDIFF(M, DATEADD(day, -1, JoiningDate), EndOfService) AS varchar) as TotalMonth " +
                           " from " +
                           " ( " +
                           " Select a.EmployeeID, EmployeeCode, EmployeeName, DateOfBirth, JoiningDate, IsFactoryEmployee,EmployeePhoto, " +
                           " DepartmentID, DepartmentName, DesignationID, DesignationName, a.CompanyID, CompanyCode, " +
                           " JobGradeName, EquivalentGradeName, EmployeeStatusName,IsNull(c.BasicSalary, 0) as BasicSalary, " +
                           " (IsNull(b.Gross, 0) - IsNull(d.Deduct, 0)) as TakehomeSalary, a.EMPStatus, a.SeparationDate, CASE When a.EMPStatus IN(1, 2) then GETDATE() else ISNULL(a.SeparationDate, GETDATE()) end as EndOfService " +
                           " from v_EmployeeDetails a " +
                           " Left Outer JOIN " +
                           " (Select EmployeeID, CompanyID, Sum(Amount) as Gross from t_HRPayrollEmployeeAllowance " +
                           " Where EffectiveYear = " + nYear + " and AllowanceID Not IN(14, 16) Group by EmployeeID, CompanyID)b " +
                           " ON a.EmployeeID = b.EmployeeID and a.CompanyID = b.CompanyID " +
                           " Left Outer JOIN " +
                           " (Select EmployeeID, CompanyID, Sum(Amount) as BasicSalary from t_HRPayrollEmployeeAllowance " +
                           " Where EffectiveYear = " + nYear + " and AllowanceID IN(8, 9) Group by EmployeeID, CompanyID)c " +
                           " ON a.EmployeeID = c.EmployeeID and a.CompanyID = c.CompanyID " +
                           " Left Outer JOIN " +
                           " (Select EmployeeID, CompanyID, Sum(Amount) as Deduct from t_HRPayrollEmployeeAllowance " +
                           " Where EffectiveYear = "+ nYear + " and AllowanceID IN(17, 26) Group by EmployeeID, CompanyID)d " +
                           " ON a.EmployeeID = d.EmployeeID and a.CompanyID = d.CompanyID " +
                           " )x " +
                           " )final Where 1 = 1 ";

            if (sEmployeeCode != "")
            {
                sSQL += " and EmployeeCode = '" + sEmployeeCode + "'";
            }
            if (sEmployeeName != "")
            {
                sSQL += " and EmployeeName Like '%" + sEmployeeName + "%'";
            }
            if (sCompanyCode != "")
            {
                sSQL += " and CompanyCode = '" + sCompanyCode + "'";
            }
            if (sDepartmentName != "All")
            {
                sSQL += " and DepartmentName = '" + sDepartmentName + "'";
            }
            if (sEquivalentGradeName != "All")
            {
                sSQL += " and EquivalentGradeName = '" + sEquivalentGradeName + "'";
            }
            if (sEMPStatus != "")
            {
                sSQL += " and EMPStatus IN (" + sEMPStatus + ")";
            }
            if (_bIsCheckFactory == "true")
            {
                if (sIsFactoryEmployee == "Yes")
                {
                    sSQL += " and IsFactoryEmployee = 1";
                }
                else if (sIsFactoryEmployee == "No")
                {
                    sSQL += " and IsFactoryEmployee = 0";
                }

            }
            if (_bIsCheckLoS == "true")
            {
                if (sCondition != "btn")
                {
                    sSQL += " and TotalMonth " + sCondition + " " + sFromMonth + " ";
                }
                else
                {
                    sSQL += " and TotalMonth between " + sFromMonth + " and " + sToMonth + " ";
                }
            }

            sSQL += " order by EmployeeCode ";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Data oData = new Data();

                    oData.Value = "Success";

                    oData.EmployeeID = reader["EmployeeID"].ToString();
                    oData.EmployeeCode = reader["EmployeeCode"].ToString();
                    oData.EmployeeName = reader["EmployeeName"].ToString();
                    oData.DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]).ToString("dd-MMM-yyyy");
                    oData.JoiningDate = Convert.ToDateTime(reader["JoiningDate"]).ToString("dd-MMM-yyyy");
                    oData.DepartmentName = reader["DepartmentName"].ToString();
                    oData.DesignationName = reader["DesignationName"].ToString();
                    oData.CompanyCode = reader["CompanyCode"].ToString();
                    oData.JobGradeName = reader["JobGradeName"].ToString();
                    oData.EquivalentGradeName = reader["EquivalentGradeName"].ToString();
                    oData.EmployeeStatusName = reader["EmployeeStatusName"].ToString();
                    oData.BasicSalary = ExcludeDecimal(_oTELLib.TakaFormat(Convert.ToDouble(reader["BasicSalary"])));
                    oData.TakehomeSalary = ExcludeDecimal(_oTELLib.TakaFormat(Convert.ToDouble(reader["TakehomeSalary"])));
                    oData.Year = reader["Year"].ToString();
                    oData.Month = reader["Month"].ToString();
                    oData.Day = reader["Day"].ToString();
                    oData.TotalMonth = reader["TotalMonth"].ToString();
                    int nEmpStatus = Convert.ToInt32(reader["EMPStatus"]);
                    oData.Factory = reader["Factory"].ToString();

                    oData.Age = reader["Age"].ToString();
                    if (reader["EmployeePhoto"] != DBNull.Value)
                    {
                        oData.EmployeePhoto = reader["EmployeePhoto"].ToString();
                    }
                    else
                    {
                        oData.EmployeePhoto = "";
                    }

                    if (reader["SeparationDate"] != DBNull.Value)
                    {
                        oData.SeparationDate = Convert.ToDateTime(reader["SeparationDate"]).ToString("dd-MMM-yyyy");
                    }
                    else
                    {
                        if (nEmpStatus == (int)Dictionary.HREmployeeStatus.Contractual || nEmpStatus == (int)Dictionary.HREmployeeStatus.Confirmed)
                        {
                            oData.SeparationDate = "N/A";
                        }
                        else
                        {
                            oData.SeparationDate = "Blank";
                        }
                    }
                    oData.LOS = reader["LOS"].ToString();

                    eList.Add(oData);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return eList;
        }

        public List<Data> GetEmployeeSalary(string sEmployeeId, int nYear)
        {
            _oTELLib = new TELLib();
            List<Data> eList = new List<Data>();
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();

            string sSQL = " Select a.TYear, a.TMonth, " +
                           " SUBSTRING('Jan Feb Mar Apr May Jun Jul Aug Sep Oct Nov Dec ', (a.TMonth * 4) - 3, 3) as MonthName, " +
                           "  b.BasicSalary, a.GrossSalary, a.Deduction, (a.GrossSalary - a.Deduction) as NetSalary from " +
                           " ( " +
                           " Select a.TYear, a.TMonth, " +
                           " Sum(CASE when c.GroupID != 2 then b.EditedAmount else 0 end) as GrossSalary, " +
                           " Sum(CASE when c.GroupID = 2 then b.EditedAmount else 0 end) as Deduction from t_HRPayroll a, t_HRPayrollItem b, t_HRAllowanceDeduction c " +
                           " where a.PayrollID = b.PayrollID and c.ID = b.ItemID and b.EmployeeId = '" + sEmployeeId + "' and a.TYear = " + nYear + " " +
                           " group by  a.TYear, a.TMonth " +
                           " )a, " +
                           " (select TYear, TMonth, sum(EditedAmount) as BasicSalary from t_HRPayrollItem b, t_HRPayroll a where a.PayrollID = b.PayrollID " +
                           " and b.EmployeeId = '" + sEmployeeId + "' and a.TYear = " + nYear + " and b.ItemID IN (8, 9) group by TYear, TMonth)b " +
                           " where a.TYear = b.TYear and a.TMonth = b.TMonth Order by a.TMonth";

            try
            {
                cmd.CommandText = sSQL;
                cmd.CommandType = CommandType.Text;
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    Data oData = new Data();

                    oData.Value = "Success";

                    oData.MonthName = reader["MonthName"].ToString();
                    oData.BasicSalary = ExcludeDecimal(_oTELLib.TakaFormat(Convert.ToDouble(reader["BasicSalary"])));
                    oData.GrossSalary = ExcludeDecimal(_oTELLib.TakaFormat(Convert.ToDouble(reader["GrossSalary"])));
                    oData.Deduction = ExcludeDecimal(_oTELLib.TakaFormat(Convert.ToDouble(reader["Deduction"])));
                    oData.NetSalary = ExcludeDecimal(_oTELLib.TakaFormat(Convert.ToDouble(reader["NetSalary"])));

                    eList.Add(oData);
                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }
            return eList;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Text;

namespace CJ.Class.HR
{
   public class LoanSchedule
    {
        //public int EmployeeID { get; set; }
        public string LoanNo { get; set; }
        public double BalancePrincipal { get; set; }
        public string IsEarlyClose { get; set; }
        public string IsDue { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string DepartmentName { get; set; }
        public string LoanTypeName { get; set; }
        public Double PrincipalPayable { get; set; }
        public Double InterestPayable { get; set; }
        public Double TotalPayable { get; set; }
    }
}

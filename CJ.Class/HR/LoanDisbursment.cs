using System;
using System.Collections.Generic;
using System.Text;

namespace CJ.Class.HR
{
   public class LoanDisbursment
    {
        public string LoanNo { get; set; }
        public double AllocatedAmount { get; set; }
        public DateTime DisbursDate { get; set; }
        public double DownPayment { get; set; }
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string DepartmentName { get; set; }
        public int NoOfInstallment { get; set; }
        public double InterestRate { get; set; }
        public string LoanTypeName { get; set; }
        //public double TotalPayable { get; set; }
    }
}

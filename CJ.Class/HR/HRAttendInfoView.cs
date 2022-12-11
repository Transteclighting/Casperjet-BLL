using System;
using System.Collections.Generic;
using System.Text;

namespace CJ.Class.HR
{
    public class HRAttendInfoView
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }
        public DateTime PunchDate { get; set; }
        public int Status { get; set; }
        public string StatusName { get; set; }
    }
}



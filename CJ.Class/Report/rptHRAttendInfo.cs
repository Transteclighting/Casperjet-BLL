// <summary>
// Compamy: Transcom Electronics Limited
// Author: Arif Khan
// Date: June 13, 2011
// Time :  11:31 AM
// Description: Class for Attendance Data.
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;


namespace CJ.Class.Report
{
    public class rptHRAttendInfo
    {
        public int _nEmployeeID;
        public string _sEmployeeCode;
        public string _sEmployeeName;
        public string _sCompany;
        public string _sDepartment;
        public string _sDesignation;
        public DateTime _dPunchDate;
        public object _dTimeIn;
        public object _dTimeOut;
        public object _dLate;
        public int _nPunchCount;
        public string _sStatus;
        public string _sRemarks;
        public object _nTotalHour;
        public object _dDate;
        public object _dLessExtraTime;

    }

    public class rptHRAttendInfos : CollectionBase
    {
        public rptHRAttendInfo this[int i]
        {
            get { return (rptHRAttendInfo)InnerList[i]; }
            set { InnerList[i] = value; }
        }

        public void Add(rptHRAttendInfo oAttendInfo)
        {
            InnerList.Add(oAttendInfo);
        }



    }

}

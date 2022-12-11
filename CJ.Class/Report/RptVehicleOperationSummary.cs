// <summary>
// Compamy: Transcom Electronics Limited
// Author: Dipak kumar Chakraborty
// Date: Feb 14, 2012
// Time :  10:00 AM
// Description: Class for Vehicle Operation Summary
// Modify Person And Date:
// </summary>
using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class.Report;

namespace CJ.Class.Report
{
   public class RptVehicleOperationSummary
    {
        
        private int _nCompanyID;
        private string _sCompanyName;
        private int _nDepartmentID;
        private string _sDepartmentName;        
        private int _nVehicleID;
        private string _sVehicleCode;        
        private string _sBU;
        private string _sDriverName;        
        private string _sRegistrationNo;        
        private int _nTripC;
        private int _nTripS;
        private int _nTripU;
        private double _nKMRun;        
        private double _nChAmount3;
        private double _nCrAmount3;
        private double _nChAmount4;
        private double _nCrAmount4;
       private double _nChAmount5;
       private double _nCrAmount5;
       private double _nChAmount6;
       private double _nCrAmount6;
       private double _nChAmount8;
       private double _nCrAmount8;
       private double _nChAmount9;
       private double _nCrAmount9;
       private double _nChQty11;
       private double _nChAmount11;
       private double _nCrQty11;
       private double _nCrAmount11;
       private double _nChQty12;
       private double _nChAmount12;
       private double _nCrQty12;
       private double _nCrAmount12;
       private double _nChQty13;
       private double _nChAmount13;
       private double _nCrQty13;
       private double _nCrAmount13;
       private double _nChQty14;
       private double _nChAmount14;
       private double _nCrQty14;
       private double _nCrAmount14;


        
        public int CompanyID
        {
            get { return _nCompanyID; }
            set { _nCompanyID = value; }

        }

        public string CompanyName
        {
            get { return _sCompanyName; }
            set { _sCompanyName = value; }

        }
        public int DepartmentID
        {
            get { return _nDepartmentID; }
            set { _nDepartmentID = value; }

        }

        public string DepartmentName
        {
            get { return _sDepartmentName; }
            set { _sDepartmentName = value; }

        }
        
        public int VehicleID
        {
            get { return _nVehicleID; }
            set { _nVehicleID = value; }

        }
        public string VehicleCode
        {
            get { return _sVehicleCode; }
            set { _sVehicleCode = value; }

        }       
       
        public string BU
        {
            get { return _sBU; }
            set { _sBU = value; }

        }

       public string DriverName
       {
           get { return _sDriverName; }
           set { _sDriverName = value; }

       }
       
       public string RegistrationNo
       {
           get { return _sRegistrationNo; }
           set { _sRegistrationNo = value; }
       }

        public double KMRun
        {
            get { return _nKMRun; }
            set { _nKMRun = value; }
        }
            
        
        public int TripC
        {
            get { return _nTripC; }
            set { _nTripC = value; }

        }
        public int TripS
        {
            get { return _nTripS; }
            set { _nTripS = value; }

        }
        public int TripU
        {
            get { return _nTripU; }
            set { _nTripU = value; }
        }
       
       public double ChAmount3
       {
           get { return _nChAmount3 ; }
           set { _nChAmount3 = value; }
       }
       public double CrAmount3
       {
           get { return _nCrAmount3; }
           set { _nCrAmount3 = value; }
       }
       
       public double ChAmount4
       {
           get { return _nChAmount4; }
           set { _nChAmount4 = value; }
       }
       public double CrAmount4
       {
           get { return _nCrAmount4; }
           set { _nCrAmount4 = value; }
       }
       public double ChAmount5
       {
           get { return _nChAmount5; }
           set { _nChAmount5 = value; }
       }
       public double CrAmount5
       {
           get { return _nCrAmount5; }
           set { _nCrAmount5 = value; }
       }

       public double ChAmount6
       {
           get { return _nChAmount6; }
           set { _nChAmount6 = value; }
       }
       public double CrAmount6
       {
           get { return _nCrAmount6; }
           set { _nCrAmount6 = value; }
       }

       public double ChAmount8
       {
           get { return _nChAmount8; }
           set { _nChAmount8 = value; }
       }
       public double CrAmount8
       {
           get { return _nCrAmount8; }
           set { _nCrAmount8 = value; }
       }

       public double ChAmount9
       {
           get { return _nChAmount9; }
           set { _nChAmount9 = value; }
       }
       public double CrAmount9
       {
           get { return _nCrAmount9; }
           set { _nCrAmount9 = value; }
       }

       public double ChQty11
       {
           get { return _nChQty11; }
           set { _nChQty11 = value; }
       }
       public double ChAmount11
       {
           get { return _nChAmount11; }
           set { _nChAmount11 = value; }
       }
       public double CrQty11
       {
           get { return _nCrQty11; }
           set { _nCrQty11 = value; }
       }
       public double CrAmount11
       {
           get { return _nCrAmount11; }
           set { _nCrAmount11 = value; }
       }


       public double ChQty12
       {
           get { return _nChQty12; }
           set { _nChQty12 = value; }
       }
       public double ChAmount12
       {
           get { return _nChAmount12; }
           set { _nChAmount12 = value; }
       }
       public double CrQty12
       {
           get { return _nCrQty12; }
           set { _nCrQty12 = value; }
       }
       public double CrAmount12
       {
           get { return _nCrAmount12; }
           set { _nCrAmount12 = value; }
       }


       public double ChQty13
       {
           get { return _nChQty13; }
           set { _nChQty13 = value; }
       }
       public double ChAmount13
       {
           get { return _nChAmount13; }
           set { _nChAmount13 = value; }
       }
       public double CrQty13
       {
           get { return _nCrQty13; }
           set { _nCrQty13 = value; }
       }
       public double CrAmount13
       {
           get { return _nCrAmount13; }
           set { _nCrAmount13 = value; }
       }

       public double ChQty14
       {
           get { return _nChQty14; }
           set { _nChQty14 = value; }
       }
       public double ChAmount14
       {
           get { return _nChAmount14; }
           set { _nChAmount14 = value; }
       }
       public double CrQty14
       {
           get { return _nCrQty14; }
           set { _nCrQty14 = value; }
       }
       public double CrAmount14
       {
           get { return _nCrAmount14; }
           set { _nCrAmount14 = value; }
       }


    }

    public class RptVehicleOperationSummaryDetails : CollectionBaseCustom
    {
        public void Add(RptVehicleOperationSummary oRptVehicleOperationSummary)
        {
            this.List.Add(oRptVehicleOperationSummary);
        }
        public RptVehicleOperationSummary this[Int32 Index]
        {
            get
            {
                return (RptVehicleOperationSummary)this.List[Index];
            }
            set
            {
                if (!(value.GetType().Equals(typeof(RptVehicleOperationSummary))))
                {
                    throw new Exception(" Type can't be converted");
                }
                this.List[Index] = value;
            }
        }

        public void VehicleOperationSummary(DateTime dYFromDate, DateTime dYToDate, int nDepartmentID, string sVehicleCode )
        {
            InnerList.Clear();
            OleDbCommand cmd = DBController.Instance.GetCommand();
            StringBuilder sQueryStringMaster;
            sQueryStringMaster = new StringBuilder();

            sQueryStringMaster.Append("   select vo.CompanyID, vo.CompanyName, vo.DepartmentID, vo.DepartmentName, vo.VehicleID, vo.BU, vo.DriverName, vo.VehicleCode, vo.RegistrationNo, sum(vo.Tripc) as Tripc, sum(vo.TripS)as TripS, sum(vo.TripU) as TripU, sum(vo.KMRun) as KMRun, ");
            sQueryStringMaster.Append("   sum(vo.ChAmount3) as ChAmount3, sum(vo.CrAmount3) as CrAmount3, sum(vo.ChAmount4) as ChAmount4, sum(vo.CrAmount4) as CrAmount4, sum(vo.ChAmount5) as ChAmount5, sum(vo.CrAmount5) as CrAmount5, sum(vo.ChAmount6) as ChAmount6, sum(vo.CrAmount6) as CrAmount6, sum(vo.ChAmount8) as ChAmount8, sum(vo.CrAmount8) as CrAmount8, ");
            sQueryStringMaster.Append("   sum(vo.ChAmount9) as  ChAmount9, sum(vo.CrAmount9) as CrAmount9, sum(vo.ChQty11) as ChQty11, sum(vo.ChAmount11)as ChAmount11, sum(vo.CrQty11) as CrQty11, sum(vo.CrAmount11) as CrAmount11, sum( vo.ChQty12) as ChQty12, sum(vo.ChAmount12) as  ChAmount12, sum(vo.CrQty12) as CrQty12,sum(vo.CrAmount12) as  CrAmount12, sum(vo.ChQty13) as ChQty13, sum(vo.ChAmount13) as ChAmount13, ");
            sQueryStringMaster.Append("   sum(vo.CrQty13) as CrQty13, sum(vo.CrAmount13) as CrAmount13, sum(vo.ChQty14) as ChQty14, sum(vo.ChAmount14) as ChAmount14, sum(vo.CrQty14)as CrQty14, sum(vo.CrAmount14) as CrAmount14  ");
            sQueryStringMaster.Append(" from  ");
            sQueryStringMaster.Append("   (  ");

            sQueryStringMaster.Append("  select OP.VehicleOperationID, OP.CompanyID, OP.CompanyName, OP.DepartmentID, OP.DepartmentName, OP.VehicleID, OP.BU, OP.DriverName, OP.VehicleCode, OP.RegistrationNo,  OP.Tripc, OP.TripS, OP.TripU, OP.KMRun,  ");
            sQueryStringMaster.Append("  isnull( ExpAll.ChAmount3,0)ChAmount3 ,isnull( ExpAll.CrAmount3, 0) CrAmount3 , isnull (ExpAll.ChAmount4, 0) ChAmount4 , isnull (ExpAll.CrAmount4, 0) CrAmount4, isnull( ExpAll.ChAmount5, 0)ChAmount5 , isnull (ExpAll.CrAmount5, 0) CrAmount5 , isnull(ExpAll.ChAmount6, 0)ChAmount6 , isnull (ExpAll.CrAmount6, 0) CrAmount6 , isnull (ExpAll.ChAmount8, 0)ChAmount8 ,isnull( ExpAll.CrAmount8, 0) CrAmount8,  ");
            sQueryStringMaster.Append("  isnull( ExpAll.ChAmount9,0)ChAmount9 , isnull (ExpAll.CrAmount9, 0)CrAmount9 , isnull (ExpAll.ChQty11, 0)ChQty11 , isnull (ExpAll.ChAmount11, 0)ChAmount11, ");
            sQueryStringMaster.Append("   isnull (ExpAll.CrQty11, 0) CrQty11, isnull (ExpAll.CrAmount11, 0)CrAmount11 , isnull (ExpAll.ChQty12, 0)ChQty12 , isnull (ExpAll.ChAmount12, 0)ChAmount12 ,isnull( ExpAll.CrQty12, 0)CrQty12 , isnull (ExpAll.CrAmount12, 0)CrAmount12 , isnull (ExpAll.ChQty13, 0) ChQty13 , isnull (ExpAll.ChAmount13,0) ChAmount13 , isnull (ExpAll.CrQty13,0) CrQty13 , isnull (ExpAll.CrAmount13,0) CrAmount13 , isnull (ExpAll.ChQty14, 0) ChQty14 , isnull (ExpAll.ChAmount14, 0) ChAmount14, isnull (ExpAll.CrQty14, 0) CrQty14,  ");
            sQueryStringMaster.Append("   isnull (ExpAll.CrAmount14, 0) CrAmount14 ");


            sQueryStringMaster.Append("   from ");
            sQueryStringMaster.Append("   (  ");

            sQueryStringMaster.Append("   select a.VehicleOperationID,c.CompanyID,c.CompanyName, d.DepartmentID,d.DepartmentName, a.VehicleID,b.BU,b.DriverName, b.VehicleCode, b.RegistrationNo, a.TranDate, sum(a.Tripc)as Tripc, sum(a.tripS)as TripS, sum(a.TripU)as TripU, sum(a.KMRun)as KMRun ");
            sQueryStringMaster.Append("   from t_vehicleOperation a, t_Vehicle b, t_Company c, t_Department d ");
            sQueryStringMaster.Append("   where a.VehicleID=b.VehicleID and b.CompanyID=c.CompanyID and b.DepartmentID=d.DepartmentID and Trandate between ? and ? and Trandate < ?  ");
            sQueryStringMaster.Append("   group by a.VehicleOperationID,c.CompanyID,c.CompanyName, d.DepartmentID, d.DepartmentName,  a.VehicleID, b.BU, b.DriverName,  b.VehicleCode,  b.RegistrationNo, a.TranDate ");

            sQueryStringMaster.Append("   )as OP  ");
            sQueryStringMaster.Append("   Left outer Join ");
            sQueryStringMaster.Append("  ( ");

            sQueryStringMaster.Append("   select isnull(q8.vehicleOperationid, Exp14.vehicleOperationid) vehicleOperationid, isnull(q8.ChAmount3,0) ChAmount3, ");
            sQueryStringMaster.Append("   isnull(q8.CrAmount3,0) CrAmount3, isnull(q8.ChAmount4,0) ChAmount4, isnull(q8.CrAmount4,0) CrAmount4, isnull(q8.ChAmount5,0) ChAmount5, ");
            sQueryStringMaster.Append("   isnull(q8.CrAmount5,0) CrAmount5,  isnull(q8.ChAmount6,0) ChAmount6, isnull(q8.CrAmount6,0) CrAmount6, isnull(q8.ChAmount8,0) ChAmount8, ");
            sQueryStringMaster.Append("   isnull(q8.CrAmount8,0) CrAmount8, isnull(q8.ChAmount9,0) ChAmount9,isnull(q8.CrAmount9,0) CrAmount9, isnull(q8.ChQty11,0) ChQty11, isnull(q8.ChAmount11,0) ChAmount11, ");
            sQueryStringMaster.Append("   isnull(q8.CrQty11,0) CrQty11, isnull(q8.CrAmount11,0) CrAmount11, isnull(q8.ChQty12,0) ChQty12, isnull(q8.ChAmount12,0) ChAmount12, isnull(q8.CrQty12,0) CrQty12, isnull(q8.CrAmount12,0) CrAmount12, ");
            sQueryStringMaster.Append("   isnull(q8.ChQty13,0) ChQty13, isnull(q8.ChAmount13,0) ChAmount13, isnull(q8.CrQty13,0) CrQty13, isnull(q8.CrAmount13,0) CrAmount13,isnull(Exp14.ChQty14,0) ChQty14, isnull(Exp14.ChAmount14,0) ChAmount14, isnull(Exp14.CrQty14,0) CrQty14, isnull(Exp14.CrAmount14,0) CrAmount14 ");

            sQueryStringMaster.Append("   from  ");
            sQueryStringMaster.Append("   ( ");

            sQueryStringMaster.Append("   select isnull(q7.vehicleOperationid, Exp13.vehicleOperationid) vehicleOperationid, isnull(q7.ChAmount3,0) ChAmount3, ");
            sQueryStringMaster.Append("   isnull(q7.CrAmount3,0) CrAmount3, isnull(q7.ChAmount4,0) ChAmount4, isnull(q7.CrAmount4,0) CrAmount4, isnull(q7.ChAmount5,0) ChAmount5, ");
            sQueryStringMaster.Append("   isnull(q7.CrAmount5,0) CrAmount5,  isnull(q7.ChAmount6,0) ChAmount6, isnull(q7.CrAmount6,0) CrAmount6, isnull(q7.ChAmount8,0) ChAmount8, ");
            sQueryStringMaster.Append("   isnull(q7.CrAmount8,0) CrAmount8, isnull(q7.ChAmount9,0) ChAmount9,isnull(q7.CrAmount9,0) CrAmount9, isnull(q7.ChQty11,0) ChQty11, isnull(q7.ChAmount11,0) ChAmount11, ");
            sQueryStringMaster.Append("   isnull(q7.CrQty11,0) CrQty11, isnull(q7.CrAmount11,0) CrAmount11, isnull(q7.ChQty12,0) ChQty12, isnull(q7.ChAmount12,0) ChAmount12, isnull(q7.CrQty12,0) CrQty12, isnull(q7.CrAmount12,0) CrAmount12, ");
            sQueryStringMaster.Append("  isnull(Exp13.ChQty13,0) ChQty13, isnull(Exp13.ChAmount13,0) ChAmount13, isnull(Exp13.CrQty13,0) CrQty13, isnull(Exp13.CrAmount13,0) CrAmount13 ");


            sQueryStringMaster.Append("  from  ");
            sQueryStringMaster.Append("   ( ");

            sQueryStringMaster.Append("   select isnull(q6.vehicleOperationid, Exp12.vehicleOperationid) vehicleOperationid, isnull(q6.ChAmount3,0) ChAmount3, ");
            sQueryStringMaster.Append("   isnull(q6.CrAmount3,0) CrAmount3, isnull(q6.ChAmount4,0) ChAmount4, isnull(q6.CrAmount4,0) CrAmount4, isnull(q6.ChAmount5,0) ChAmount5, ");
            sQueryStringMaster.Append("   isnull(q6.CrAmount5,0) CrAmount5,  isnull(q6.ChAmount6,0) ChAmount6, isnull(q6.CrAmount6,0) CrAmount6, isnull(q6.ChAmount8,0) ChAmount8, ");
            sQueryStringMaster.Append("   isnull(q6.CrAmount8,0) CrAmount8, isnull(q6.ChAmount9,0) ChAmount9,isnull(q6.CrAmount9,0) CrAmount9, isnull(q6.ChQty11,0) ChQty11, isnull(q6.ChAmount11,0) ChAmount11, ");
            sQueryStringMaster.Append("   isnull(q6.CrQty11,0) CrQty11, isnull(q6.CrAmount11,0) CrAmount11, isnull(Exp12.ChQty12,0) ChQty12, isnull(Exp12.ChAmount12,0) ChAmount12, isnull(Exp12.CrQty12,0) CrQty12, isnull(Exp12.CrAmount12,0) CrAmount12 ");

            sQueryStringMaster.Append("   from ");
            sQueryStringMaster.Append("   ( ");

            sQueryStringMaster.Append("   select isnull(q5.vehicleOperationid, Exp11.vehicleOperationid) vehicleOperationid, isnull(q5.ChAmount3,0) ChAmount3, ");
            sQueryStringMaster.Append("   isnull(q5.CrAmount3,0) CrAmount3, isnull(q5.ChAmount4,0) ChAmount4, isnull(q5.CrAmount4,0) CrAmount4, isnull(q5.ChAmount5,0) ChAmount5, ");
            sQueryStringMaster.Append("   isnull(q5.CrAmount5,0) CrAmount5,  isnull(q5.ChAmount6,0) ChAmount6, isnull(q5.CrAmount6,0) CrAmount6, isnull(q5.ChAmount8,0) ChAmount8, ");
            sQueryStringMaster.Append("   isnull(q5.CrAmount8,0) CrAmount8, isnull(q5.ChAmount9,0) ChAmount9,isnull(q5.CrAmount9,0) CrAmount9, isnull(Exp11.ChQty11,0) ChQty11, isnull(Exp11.ChAmount11,0) ChAmount11, ");
            sQueryStringMaster.Append("   isnull(Exp11.CrQty11,0) CrQty11, isnull(Exp11.CrAmount11,0) CrAmount11 ");
            sQueryStringMaster.Append("   from ");
            sQueryStringMaster.Append("   ( ");

            sQueryStringMaster.Append("   select isnull(q4.vehicleOperationid, Exp9.vehicleOperationid) vehicleOperationid, isnull(q4.ChAmount3,0) ChAmount3, ");
            sQueryStringMaster.Append("   isnull(q4.CrAmount3,0) CrAmount3, isnull(q4.ChAmount4,0) ChAmount4, isnull(q4.CrAmount4,0) CrAmount4, isnull(q4.ChAmount5,0) ChAmount5, ");
            sQueryStringMaster.Append("   isnull(q4.CrAmount5,0) CrAmount5,  isnull(q4.ChAmount6,0) ChAmount6, isnull(q4.CrAmount6,0) CrAmount6, isnull(q4.ChAmount8,0) ChAmount8, ");
            sQueryStringMaster.Append("   isnull(q4.CrAmount8,0) CrAmount8, isnull(Exp9.ChAmount9,0) ChAmount9,isnull(Exp9.CrAmount9,0) CrAmount9 ");
            sQueryStringMaster.Append("   from  ");
            sQueryStringMaster.Append("   ( ");

            sQueryStringMaster.Append("   select isnull(q3.vehicleOperationid, Exp8.vehicleOperationid) vehicleOperationid, isnull(q3.ChAmount3,0) ChAmount3, ");
            sQueryStringMaster.Append("   isnull(q3.CrAmount3,0) CrAmount3, isnull(q3.ChAmount4,0) ChAmount4, isnull(q3.CrAmount4,0) CrAmount4, isnull(q3.ChAmount5,0) ChAmount5, ");
            sQueryStringMaster.Append("   isnull(q3.CrAmount5,0) CrAmount5,  isnull(q3.ChAmount6,0) ChAmount6, isnull(q3.CrAmount6,0) CrAmount6, isnull(Exp8.ChAmount8,0) ChAmount8, ");
            sQueryStringMaster.Append("   isnull(Exp8.CrAmount8,0) CrAmount8 ");
            sQueryStringMaster.Append("   from ");
            sQueryStringMaster.Append("   ( ");

            sQueryStringMaster.Append("   select isnull(q2.vehicleOperationid,Exp6.vehicleOperationid) vehicleOperationid, isnull(q2.ChAmount3,0) ChAmount3, ");
            sQueryStringMaster.Append("   isnull(q2.CrAmount3,0) CrAmount3, isnull(q2.ChAmount4,0) ChAmount4, isnull(q2.CrAmount4,0) CrAmount4, isnull(q2.ChAmount5,0) ChAmount5, ");
            sQueryStringMaster.Append("   isnull(q2.CrAmount5,0) CrAmount5,  isnull(Exp6.ChAmount6,0) ChAmount6, isnull(Exp6.CrAmount6,0) CrAmount6  ");

            sQueryStringMaster.Append("   from  ");
            sQueryStringMaster.Append("   ( ");

            sQueryStringMaster.Append("   select isnull(q1.vehicleOperationid,Exp5.vehicleOperationid) vehicleOperationid, isnull(q1.ChQty3,0) ChQty3,isnull(q1.ChAmount3,0) ChAmount3, ");
            sQueryStringMaster.Append("   isnull(q1.CrQty3,0) CrQty3,isnull(q1.CrAmount3,0) CrAmount3,isnull(q1.ChQty4,0) ChQty4,isnull(q1.ChAmount4,0) ChAmount4, ");
            sQueryStringMaster.Append("   isnull(q1.CrQty4,0) CrQty4,isnull(q1.CrAmount4,0) CrAmount4, isnull(Exp5.ChQty5,0) ChQty5,isnull(Exp5.ChAmount5,0) ChAmount5, ");
            sQueryStringMaster.Append("   isnull(Exp5.CrQty5,0) CrQty5,isnull(Exp5.CrAmount5,0) CrAmount5 ");

            sQueryStringMaster.Append("  from ");
            sQueryStringMaster.Append("   ( ");

            sQueryStringMaster.Append("   select isnull(exp3.vehicleOperationid,exp4.vehicleOperationid) vehicleOperationid,isnull(ChQty3,0) ChQty3,isnull(ChAmount3,0) ChAmount3, ");
            sQueryStringMaster.Append("   isnull(CrQty3,0) CrQty3,isnull(CrAmount3,0) CrAmount3,isnull(ChQty4,0) ChQty4,isnull(ChAmount4,0) ChAmount4, ");
            sQueryStringMaster.Append("   isnull(CrQty4,0) CrQty4,isnull(CrAmount4,0) CrAmount4 ");
            sQueryStringMaster.Append("   from ");
            sQueryStringMaster.Append("   ( ");
            sQueryStringMaster.Append("   select isnull(a.vehicleOperationid,b.vehicleOperationid) vehicleOperationid,isnull(ChQty3,0) ChQty3,isnull(ChAmount3,0) ChAmount3, ");
            sQueryStringMaster.Append("   isnull(CrQty3,0) CrQty3,isnull(CrAmount3,0) CrAmount3 ");
            sQueryStringMaster.Append("   from ");
            sQueryStringMaster.Append("   ( ");
            sQueryStringMaster.Append("   select vehicleOperationid, ");
            sQueryStringMaster.Append("   sum(case ExpenseHeadID when 3 then Qty else 0 end) as ChQty3, ");
            sQueryStringMaster.Append("   sum(case ExpenseHeadID when 3 then amount else 0 end) as ChAmount3 ");
            sQueryStringMaster.Append("   from t_VehicleExpenseDetails ");
            sQueryStringMaster.Append("   where paymenttype=1 ");
            sQueryStringMaster.Append("   group by vehicleOperationid ");
            sQueryStringMaster.Append("   ) a ");
            sQueryStringMaster.Append("   full outer join ");
            sQueryStringMaster.Append("   ( ");
            sQueryStringMaster.Append("   select vehicleOperationid, ");
            sQueryStringMaster.Append("   sum(case ExpenseHeadID when 3 then Qty else 0 end) as CrQty3, ");
            sQueryStringMaster.Append("   sum(case ExpenseHeadID when 3 then amount else 0 end) as CrAmount3 ");
            sQueryStringMaster.Append("   from t_VehicleExpenseDetails  ");
            sQueryStringMaster.Append("   where paymenttype=2 ");
            sQueryStringMaster.Append("   group by vehicleOperationid ");
            sQueryStringMaster.Append("   ) b ");
            sQueryStringMaster.Append("   on ");
            sQueryStringMaster.Append("   a.vehicleOperationid=b.vehicleOperationid ");
            sQueryStringMaster.Append("   ) exp3 ");

            sQueryStringMaster.Append("   full outer join ");
            sQueryStringMaster.Append("   ( ");
            sQueryStringMaster.Append("   select isnull(a.vehicleOperationid,b.vehicleOperationid) vehicleOperationid,isnull(ChQty4,0) ChQty4,isnull(ChAmount4,0) ChAmount4, ");
            sQueryStringMaster.Append("   isnull(CrQty4,0) CrQty4,isnull(CrAmount4,0) CrAmount4 ");
            sQueryStringMaster.Append("   from ");
            sQueryStringMaster.Append("   ( ");
            sQueryStringMaster.Append("   select vehicleOperationid, ");
            sQueryStringMaster.Append("   sum(case ExpenseHeadID when 4 then Qty else 0 end) as ChQty4, ");
            sQueryStringMaster.Append("   sum(case ExpenseHeadID when 4 then amount else 0 end) as ChAmount4 ");
            sQueryStringMaster.Append("   from t_VehicleExpenseDetails  ");
            sQueryStringMaster.Append("   where paymenttype=1 ");
            sQueryStringMaster.Append("   group by vehicleOperationid ");
            sQueryStringMaster.Append("   ) a ");
            sQueryStringMaster.Append("   full outer join ");
            sQueryStringMaster.Append("   ( ");
            sQueryStringMaster.Append("   select vehicleOperationid, ");
            sQueryStringMaster.Append("   sum(case ExpenseHeadID when 4 then Qty else 0 end) as CrQty4, ");
            sQueryStringMaster.Append("   sum(case ExpenseHeadID when 4 then amount else 0 end) as CrAmount4 ");
            sQueryStringMaster.Append("   from t_VehicleExpenseDetails ");
            sQueryStringMaster.Append("   where paymenttype=2 ");
            sQueryStringMaster.Append("   group by vehicleOperationid ");
            sQueryStringMaster.Append("   ) b ");
            sQueryStringMaster.Append("   on ");
            sQueryStringMaster.Append("   a.vehicleOperationid=b.vehicleOperationid ");
            sQueryStringMaster.Append("   ) exp4 ");
            sQueryStringMaster.Append("   on ");
            sQueryStringMaster.Append("   exp3.vehicleOperationid=exp4.vehicleOperationid  ");

            sQueryStringMaster.Append("   ) q1 ");

            sQueryStringMaster.Append("   full outer join  ");
            sQueryStringMaster.Append("   ( ");

            sQueryStringMaster.Append("   select isnull(a.vehicleOperationid,b.vehicleOperationid) vehicleOperationid, isnull(ChQty5,0) ChQty5,isnull(ChAmount5,0) ChAmount5, ");
            sQueryStringMaster.Append("   isnull(CrQty5,0) CrQty5,isnull(CrAmount5,0) CrAmount5 ");
            sQueryStringMaster.Append("   from ");
            sQueryStringMaster.Append("   ( ");
            sQueryStringMaster.Append("   select vehicleOperationid, ");
            sQueryStringMaster.Append("   sum(case ExpenseHeadID when 5 then Qty else 0 end) as ChQty5, ");
            sQueryStringMaster.Append("   sum(case ExpenseHeadID when 5 then amount else 0 end) as ChAmount5 ");
            sQueryStringMaster.Append("   from t_VehicleExpenseDetails ");
            sQueryStringMaster.Append("   where paymenttype=1 ");
            sQueryStringMaster.Append("   group by vehicleOperationid ");
            sQueryStringMaster.Append("   ) a ");
            sQueryStringMaster.Append("   full outer join  ");
            sQueryStringMaster.Append("   ( ");
            sQueryStringMaster.Append("   select vehicleOperationid, ");
            sQueryStringMaster.Append("   sum(case ExpenseHeadID when 5 then Qty else 0 end) as CrQty5, ");
            sQueryStringMaster.Append("   sum(case ExpenseHeadID when 5 then amount else 0 end) as CrAmount5 ");
            sQueryStringMaster.Append("   from t_VehicleExpenseDetails  ");
            sQueryStringMaster.Append("   where paymenttype=2 ");
            sQueryStringMaster.Append("   group by vehicleOperationid ");
            sQueryStringMaster.Append("   ) b ");
            sQueryStringMaster.Append("   on a.vehicleOperationid=b.vehicleOperationid ");

            sQueryStringMaster.Append("   )as Exp5 on q1.vehicleOperationid=Exp5.vehicleOperationid ");

            sQueryStringMaster.Append("   ) as q2 ");

            sQueryStringMaster.Append("   full outer join  ");

            sQueryStringMaster.Append("   ( ");
            sQueryStringMaster.Append("   select isnull(a.vehicleOperationid,b.vehicleOperationid) vehicleOperationid,isnull(ChQty6,0) ChQty6,isnull(ChAmount6,0) ChAmount6, ");
            sQueryStringMaster.Append("   isnull(CrQty6,0) CrQty6,isnull(CrAmount6,0) CrAmount6 ");
            sQueryStringMaster.Append("   from ");
            sQueryStringMaster.Append("   ( ");
            sQueryStringMaster.Append("   select vehicleOperationid, ");
            sQueryStringMaster.Append("   sum(case ExpenseHeadID when 6 then Qty else 0 end) as ChQty6, ");
            sQueryStringMaster.Append("   sum(case ExpenseHeadID when 6 then amount else 0 end) as ChAmount6 ");
            sQueryStringMaster.Append("   from t_VehicleExpenseDetails  ");
            sQueryStringMaster.Append("   where paymenttype=1 ");
            sQueryStringMaster.Append("   group by vehicleOperationid ");
            sQueryStringMaster.Append("   ) a ");
            sQueryStringMaster.Append("   full outer join ");
            sQueryStringMaster.Append("   ( ");
            sQueryStringMaster.Append("   select vehicleOperationid, ");
            sQueryStringMaster.Append("   sum(case ExpenseHeadID when 6 then Qty else 0 end) as CrQty6, ");
            sQueryStringMaster.Append("   sum(case ExpenseHeadID when 6 then amount else 0 end) as CrAmount6 ");
            sQueryStringMaster.Append("   from t_VehicleExpenseDetails ");
            sQueryStringMaster.Append("   where paymenttype=2 ");
            sQueryStringMaster.Append("   group by vehicleOperationid ");
            sQueryStringMaster.Append("   ) b ");
            sQueryStringMaster.Append("   on a.vehicleOperationid=b.vehicleOperationid ");

            sQueryStringMaster.Append("   )as Exp6 on q2.vehicleOperationid=Exp6.vehicleOperationid ");

            sQueryStringMaster.Append("   ) as q3 ");

            sQueryStringMaster.Append("   Full outer join ");

            sQueryStringMaster.Append("   ( ");
            sQueryStringMaster.Append("   select isnull(a.vehicleOperationid,b.vehicleOperationid) vehicleOperationid, isnull(ChQty8,0) ChQty8,isnull(ChAmount8,0) ChAmount8, ");
            sQueryStringMaster.Append("   isnull(CrQty8,0) CrQty8,isnull(CrAmount8,0) CrAmount8 ");
            sQueryStringMaster.Append("   from ");
            sQueryStringMaster.Append("   ( ");
            sQueryStringMaster.Append("   select vehicleOperationid, ");
            sQueryStringMaster.Append("   sum(case ExpenseHeadID when 8 then Qty else 0 end) as ChQty8, ");
            sQueryStringMaster.Append("   sum(case ExpenseHeadID when 8 then amount else 0 end) as ChAmount8 ");
            sQueryStringMaster.Append("   from t_VehicleExpenseDetails  ");
            sQueryStringMaster.Append("   where paymenttype=1 ");
            sQueryStringMaster.Append("   group by vehicleOperationid ");
            sQueryStringMaster.Append("   ) a ");
            sQueryStringMaster.Append("   full outer join ");
            sQueryStringMaster.Append("   ( ");
            sQueryStringMaster.Append("   select vehicleOperationid, ");
            sQueryStringMaster.Append("   sum(case ExpenseHeadID when 8 then Qty else 0 end) as CrQty8, ");
            sQueryStringMaster.Append("   sum(case ExpenseHeadID when 8 then amount else 0 end) as CrAmount8 ");
            sQueryStringMaster.Append("   from t_VehicleExpenseDetails  ");
            sQueryStringMaster.Append("   where paymenttype=2 ");
            sQueryStringMaster.Append("   group by vehicleOperationid ");
            sQueryStringMaster.Append("   ) b ");
            sQueryStringMaster.Append("   on a.vehicleOperationid=b.vehicleOperationid ");

            sQueryStringMaster.Append("   )as Exp8 on q3.vehicleOperationid=Exp8.vehicleOperationid ");

            sQueryStringMaster.Append("   )as q4 ");

            sQueryStringMaster.Append("   Full outer join ");

            sQueryStringMaster.Append("   ( ");

            sQueryStringMaster.Append("   select isnull(a.vehicleOperationid,b.vehicleOperationid) vehicleOperationid, isnull(ChAmount9,0) ChAmount9,isnull(CrAmount9,0) CrAmount9 ");
            sQueryStringMaster.Append("   from ");
            sQueryStringMaster.Append("   ( ");
            sQueryStringMaster.Append("   select vehicleOperationid, ");
            sQueryStringMaster.Append("   sum(case ExpenseHeadID when 9 then Qty else 0 end) as ChQty9, ");
            sQueryStringMaster.Append("   sum(case ExpenseHeadID when 9 then amount else 0 end) as ChAmount9 ");
            sQueryStringMaster.Append("   from t_VehicleExpenseDetails ");
            sQueryStringMaster.Append("   where paymenttype=1 ");
            sQueryStringMaster.Append("   group by vehicleOperationid ");
            sQueryStringMaster.Append("   ) a ");
            sQueryStringMaster.Append("   full outer join ");
            sQueryStringMaster.Append("   ( ");
            sQueryStringMaster.Append("   select vehicleOperationid, ");
            sQueryStringMaster.Append("   sum(case ExpenseHeadID when 9 then Qty else 0 end) as CrQty9, ");
            sQueryStringMaster.Append("   sum(case ExpenseHeadID when 9 then amount else 0 end) as CrAmount9 ");
            sQueryStringMaster.Append("   from t_VehicleExpenseDetails  ");
            sQueryStringMaster.Append("   where paymenttype=2 ");
            sQueryStringMaster.Append("   group by vehicleOperationid ");
            sQueryStringMaster.Append("   ) b ");
            sQueryStringMaster.Append("   on a.vehicleOperationid=b.vehicleOperationid ");

            sQueryStringMaster.Append("   ) as Exp9 on q4.vehicleOperationid=Exp9.vehicleOperationid ");

            sQueryStringMaster.Append("   ) as q5 ");

            sQueryStringMaster.Append("   Full outer join ");

            sQueryStringMaster.Append("   ( ");
            sQueryStringMaster.Append("   select isnull(a.vehicleOperationid,b.vehicleOperationid) vehicleOperationid, isnull(ChQty11,0) ChQty11, isnull(ChAmount11,0) ChAmount11, isnull(CrQty11,0) CrQty11, isnull(CrAmount11,0) CrAmount11 ");
            sQueryStringMaster.Append("   from ");
            sQueryStringMaster.Append("   ( ");
            sQueryStringMaster.Append("   select vehicleOperationid, ");
            sQueryStringMaster.Append("   sum(case ExpenseHeadID when 11 then Qty else 0 end) as ChQty11, ");
            sQueryStringMaster.Append("   sum(case ExpenseHeadID when 11 then amount else 0 end) as ChAmount11 ");
            sQueryStringMaster.Append("   from t_VehicleExpenseDetails ");
            sQueryStringMaster.Append("   where paymenttype=1 ");
            sQueryStringMaster.Append("   group by vehicleOperationid ");
            sQueryStringMaster.Append("   ) a ");
            sQueryStringMaster.Append("   full outer join ");
            sQueryStringMaster.Append("   ( ");
            sQueryStringMaster.Append("   select vehicleOperationid, ");
            sQueryStringMaster.Append("   sum(case ExpenseHeadID when 11 then Qty else 0 end) as CrQty11, ");
            sQueryStringMaster.Append("   sum(case ExpenseHeadID when 11 then amount else 0 end) as CrAmount11 ");
            sQueryStringMaster.Append("   from t_VehicleExpenseDetails ");
            sQueryStringMaster.Append("   where paymenttype=2 ");
            sQueryStringMaster.Append("   group by vehicleOperationid ");
            sQueryStringMaster.Append("   ) b ");
            sQueryStringMaster.Append("   on a.vehicleOperationid=b.vehicleOperationid ");
            sQueryStringMaster.Append("   )as Exp11 on q5.vehicleOperationid=Exp11.vehicleOperationid ");

            sQueryStringMaster.Append("   ) as q6 ");

            sQueryStringMaster.Append("   Full Outer Join ");

            sQueryStringMaster.Append("   ( ");
            sQueryStringMaster.Append("   select isnull(a.vehicleOperationid,b.vehicleOperationid) vehicleOperationid, isnull(ChQty12,0) ChQty12, isnull(ChAmount12,0) ChAmount12, isnull(CrQty12,0) CrQty12, isnull(CrAmount12,0) CrAmount12 ");
            sQueryStringMaster.Append("   from ");
            sQueryStringMaster.Append("   ( ");
            sQueryStringMaster.Append("   select vehicleOperationid, ");
            sQueryStringMaster.Append("   sum(case ExpenseHeadID when 12 then Qty else 0 end) as ChQty12, ");
            sQueryStringMaster.Append("   sum(case ExpenseHeadID when 12 then amount else 0 end) as ChAmount12 ");
            sQueryStringMaster.Append("   from t_VehicleExpenseDetails  ");
            sQueryStringMaster.Append("    where paymenttype=1 ");
            sQueryStringMaster.Append("   group by vehicleOperationid ");
            sQueryStringMaster.Append("   ) a ");
            sQueryStringMaster.Append("   full outer join ");
            sQueryStringMaster.Append("   ( ");
            sQueryStringMaster.Append("   select vehicleOperationid, ");
            sQueryStringMaster.Append("   sum(case ExpenseHeadID when 12 then Qty else 0 end) as CrQty12, ");
            sQueryStringMaster.Append("   sum(case ExpenseHeadID when 12 then amount else 0 end) as CrAmount12 ");
            sQueryStringMaster.Append("   from t_VehicleExpenseDetails  ");
            sQueryStringMaster.Append("   where paymenttype=2 ");
            sQueryStringMaster.Append("   group by vehicleOperationid ");
            sQueryStringMaster.Append("   ) b ");
            sQueryStringMaster.Append("   on a.vehicleOperationid=b.vehicleOperationid ");
            sQueryStringMaster.Append("    )as Exp12 on q6.vehicleOperationid=Exp12.vehicleOperationid ");

            sQueryStringMaster.Append("  ) as q7 ");

            sQueryStringMaster.Append("   Full outer join ");

            sQueryStringMaster.Append("   ( ");

            sQueryStringMaster.Append("   select isnull(a.vehicleOperationid,b.vehicleOperationid) vehicleOperationid, isnull(ChQty13,0) ChQty13, isnull(ChAmount13,0) ChAmount13, isnull(CrQty13,0) CrQty13, isnull(CrAmount13,0) CrAmount13 ");
            sQueryStringMaster.Append("   from ");
            sQueryStringMaster.Append("   ( ");
            sQueryStringMaster.Append("   select vehicleOperationid, ");
            sQueryStringMaster.Append("   sum(case ExpenseHeadID when 13 then Qty else 0 end) as ChQty13, ");
            sQueryStringMaster.Append("   sum(case ExpenseHeadID when 13 then amount else 0 end) as ChAmount13 ");
            sQueryStringMaster.Append("   from t_VehicleExpenseDetails ");
            sQueryStringMaster.Append("   where paymenttype=1 ");
            sQueryStringMaster.Append("   group by vehicleOperationid ");
            sQueryStringMaster.Append("   ) a ");
            sQueryStringMaster.Append("   full outer join ");
            sQueryStringMaster.Append("  ( ");
            sQueryStringMaster.Append("   select vehicleOperationid, ");
            sQueryStringMaster.Append("   sum(case ExpenseHeadID when 13 then Qty else 0 end) as CrQty13, ");
            sQueryStringMaster.Append("   sum(case ExpenseHeadID when 13 then amount else 0 end) as CrAmount13 ");
            sQueryStringMaster.Append("   from t_VehicleExpenseDetails  ");
            sQueryStringMaster.Append("   where paymenttype=2 ");
            sQueryStringMaster.Append("   group by vehicleOperationid ");
            sQueryStringMaster.Append("   ) b ");
            sQueryStringMaster.Append("   on a.vehicleOperationid=b.vehicleOperationid ");
            sQueryStringMaster.Append("   )as Exp13 on q7.vehicleOperationid=Exp13.vehicleOperationid ");

            sQueryStringMaster.Append("   )as q8 ");

            sQueryStringMaster.Append("   Full outer join ");

            sQueryStringMaster.Append("   ( ");
            sQueryStringMaster.Append("   select isnull(a.vehicleOperationid,b.vehicleOperationid) vehicleOperationid, isnull(ChQty14,0) ChQty14, isnull(ChAmount14,0) ChAmount14, isnull(CrQty14,0) CrQty14, isnull(CrAmount14,0) CrAmount14 ");
            sQueryStringMaster.Append("   from ");
            sQueryStringMaster.Append("   ( ");
            sQueryStringMaster.Append("   select vehicleOperationid, ");
            sQueryStringMaster.Append("   sum(case ExpenseHeadID when 14 then Qty else 0 end) as ChQty14, ");
            sQueryStringMaster.Append("   sum(case ExpenseHeadID when 14 then amount else 0 end) as ChAmount14 ");
            sQueryStringMaster.Append("   from t_VehicleExpenseDetails  ");
            sQueryStringMaster.Append("   where paymenttype=1 ");
            sQueryStringMaster.Append("   group by vehicleOperationid ");
            sQueryStringMaster.Append("   ) a ");
            sQueryStringMaster.Append("   full outer join ");
            sQueryStringMaster.Append("   ( ");
            sQueryStringMaster.Append("   select vehicleOperationid, ");
            sQueryStringMaster.Append("   sum(case ExpenseHeadID when 14 then Qty else 0 end) as CrQty14, ");
            sQueryStringMaster.Append("   sum(case ExpenseHeadID when 14 then amount else 0 end) as CrAmount14 ");
            sQueryStringMaster.Append("   from t_VehicleExpenseDetails  ");
            sQueryStringMaster.Append("   where paymenttype=2 ");
            sQueryStringMaster.Append("   group by vehicleOperationid ");
            sQueryStringMaster.Append("   ) b ");
            sQueryStringMaster.Append("   on a.vehicleOperationid= b.vehicleOperationid ");
            sQueryStringMaster.Append("  )as Exp14 on q8.vehicleOperationid= Exp14.vehicleOperationid ");

            sQueryStringMaster.Append("   )as ExpAll on OP.vehicleOperationid= ExpAll.vehicleOperationid ");

            sQueryStringMaster.Append("   )as vo  ");
            sQueryStringMaster.Append("   where vo.DepartmentID= ?  ");

            if (sVehicleCode != "") 
            {
                sQueryStringMaster.Append("   and VehicleCode= ?");

            }

            sQueryStringMaster.Append("   group by vo.CompanyID, vo.CompanyName, vo.DepartmentID, vo.DepartmentName, vo.VehicleID, vo.BU, vo.DriverName, vo.VehicleCode, vo.RegistrationNo ");



            OleDbCommand oCmd = DBController.Instance.GetCommand();
            oCmd.CommandTimeout = 0;
            oCmd.CommandText = sQueryStringMaster.ToString();

            oCmd.Parameters.AddWithValue("TranDate", dYFromDate.Date);
            oCmd.Parameters.AddWithValue("TranDate", dYToDate.Date);
            oCmd.Parameters.AddWithValue("TranDate", dYToDate.Date);

            if (nDepartmentID > 0)
            {
                oCmd.Parameters.AddWithValue("DepartmentID", nDepartmentID);
            }

            if (sVehicleCode != "")
            {
                oCmd.Parameters.AddWithValue("VehicleCode", sVehicleCode.ToString());
            }
            GetVehicleOperationSummary(oCmd);

        }

        public void GetVehicleOperationSummary(OleDbCommand cmd)
        {
            try
            {
                IDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    RptVehicleOperationSummary oItem = new RptVehicleOperationSummary();
                                       

                    if (reader["CompanyID"] != DBNull.Value)
                        oItem.CompanyID = (int)reader["CompanyID"];
                    else oItem.CompanyID = 0;

                    if (reader["CompanyName"] != DBNull.Value)
                        oItem.CompanyName = (string)reader["CompanyName"];
                    else oItem.CompanyName = "";

                    if (reader["DepartmentID"] != DBNull.Value)
                        oItem.DepartmentID = (int)reader["DepartmentID"];
                    else oItem.DepartmentID = 0;

                    if (reader["DepartmentName"] != DBNull.Value)
                        oItem.DepartmentName = (string)reader["DepartmentName"];
                    else oItem.DepartmentName = "";

                    if (reader["VehicleID"] != DBNull.Value)
                        oItem.VehicleID = (int)reader["VehicleID"];
                    else oItem.VehicleID = 0;

                    if (reader["VehicleCode"] != DBNull.Value)
                        oItem.VehicleCode = (string)reader["VehicleCode"];
                    else oItem.VehicleCode = "";

                    if (reader["BU"] != DBNull.Value)
                        oItem.BU = (string)reader["BU"];
                    else oItem.BU = "";

                    if (reader["DriverName"] != DBNull.Value)
                        oItem.DriverName = (string)reader["DriverName"];
                    else oItem.DriverName = "";
                    

                    if (reader["RegistrationNo"] != DBNull.Value)
                        oItem.RegistrationNo = (string)reader["RegistrationNo"];
                    else oItem.RegistrationNo = "";                
                                     
                    
                    if (reader["TripC"] != DBNull.Value)
                        oItem.TripC = (int)reader["TripC"];
                    else oItem.TripC = 0;

                    if (reader["TripS"] != DBNull.Value)
                        oItem.TripS = (int)reader["TripS"];
                    else oItem.TripS = 0;

                    if (reader["TripU"] != DBNull.Value)
                        oItem.TripU = (int)reader["TripU"];
                    else oItem.TripU = 0;

                    if (reader["KMRun"] != DBNull.Value)
                        oItem.KMRun = Convert.ToDouble(reader["KMRun"]);
                    else oItem.KMRun = 0;

                    if (reader["ChAmount3"] != DBNull.Value)
                        oItem.ChAmount3 = Convert.ToDouble(reader["ChAmount3"]);
                    else oItem.ChAmount3 = 0;

                    if (reader["CrAmount3"] != DBNull.Value)
                        oItem.CrAmount3 = Convert.ToDouble(reader["CrAmount3"]);
                    else oItem.CrAmount3 = 0;

                    if (reader["ChAmount4"] != DBNull.Value)
                        oItem.ChAmount4 = Convert.ToDouble(reader["ChAmount4"]);
                    else oItem.ChAmount4 = 0;

                    if (reader["CrAmount4"] != DBNull.Value)
                        oItem.CrAmount4 = Convert.ToDouble(reader["CrAmount4"]);
                    else oItem.CrAmount4 = -1; 

                    if (reader["ChAmount5"] != DBNull.Value)
                        oItem.ChAmount5 = Convert.ToDouble(reader["ChAmount5"]);
                    else oItem.ChAmount5 = 0;

                    if (reader["CrAmount5"] != DBNull.Value)
                        oItem.CrAmount5 = Convert.ToDouble(reader["CrAmount5"]);
                    else oItem.CrAmount5 = 0;


                    if (reader["ChAmount6"] != DBNull.Value)
                        oItem.ChAmount6 = Convert.ToDouble(reader["ChAmount6"]);
                    else oItem.ChAmount6 = -1;

                    if (reader["CrAmount6"] != DBNull.Value)
                        oItem.CrAmount6 = Convert.ToDouble(reader["CrAmount6"]);
                    else oItem.CrAmount6 = 0;


                    if (reader["ChAmount8"] != DBNull.Value)
                        oItem.ChAmount8 = Convert.ToDouble(reader["ChAmount8"]);
                    else oItem.ChAmount8 = 0;

                    if (reader["CrAmount8"] != DBNull.Value)
                        oItem.CrAmount8 = Convert.ToDouble(reader["CrAmount8"]);
                    else oItem.CrAmount8 = 0;

                    if (reader["ChAmount9"] != DBNull.Value)
                        oItem.ChAmount9 = Convert.ToDouble(reader["ChAmount9"]);
                    else oItem.ChAmount9 = 0; 

                    if (reader["CrAmount9"] != DBNull.Value)
                        oItem.CrAmount9 = Convert.ToDouble(reader["CrAmount9"]);
                    else oItem.CrAmount9 = 0;


                    if (reader["ChQty11"] != DBNull.Value)
                        oItem.ChQty11 = Convert.ToDouble(reader["ChQty11"]);
                    else oItem.ChQty11 = 0;

                    if (reader["ChAmount11"] != DBNull.Value)
                        oItem.ChAmount11 = Convert.ToDouble(reader["ChAmount11"]);
                    else oItem.ChAmount11 = 0;

                    if (reader["CrQty11"] != DBNull.Value)
                        oItem.CrQty11 = Convert.ToDouble(reader["CrQty11"]);
                    else oItem.CrQty11 = 0;

                    if (reader["CrAmount11"] != DBNull.Value)
                        oItem.CrAmount11 = Convert.ToDouble(reader["CrAmount11"]);
                    else oItem.CrAmount9 = 0;

                    if (reader["ChQty12"] != DBNull.Value)
                        oItem.ChQty12 = Convert.ToDouble(reader["ChQty12"]);
                    else oItem.ChQty12 = 0;

                    if (reader["ChAmount12"] != DBNull.Value)
                        oItem.ChAmount12 = Convert.ToDouble(reader["ChAmount12"]);
                    else oItem.ChAmount12 = -1;

                    if (reader["CrQty12"] != DBNull.Value)
                        oItem.CrQty12 = Convert.ToDouble(reader["CrQty12"]);
                    else oItem.CrQty12 = 0;

                    if (reader["CrAmount12"] != DBNull.Value)
                        oItem.CrAmount12 = Convert.ToDouble(reader["CrAmount12"]);
                    else oItem.CrAmount12 = 0;

                    if (reader["ChQty13"] != DBNull.Value)
                        oItem.ChQty13 = Convert.ToDouble(reader["ChQty13"]);
                    else oItem.ChQty13 = 0;

                    if (reader["ChAmount13"] != DBNull.Value)
                        oItem.ChAmount13 = Convert.ToDouble(reader["ChAmount13"]);
                    else oItem.ChAmount13 = 0;

                    if (reader["CrQty13"] != DBNull.Value)
                        oItem.CrQty13 = Convert.ToDouble(reader["CrQty13"]);
                    else oItem.CrQty13 = 0;

                    if (reader["CrAmount13"] != DBNull.Value)
                        oItem.CrAmount13 = Convert.ToDouble(reader["CrAmount13"]);
                    else oItem.CrAmount13 = 0;

                    if (reader["ChQty14"] != DBNull.Value)
                        oItem.ChQty14 = Convert.ToDouble(reader["ChQty14"]);
                    else oItem.ChQty14 = 0;

                    if (reader["ChAmount14"] != DBNull.Value)
                        oItem.ChAmount14 = Convert.ToDouble(reader["ChAmount14"]);
                    else oItem.ChAmount14 = 0;

                    if (reader["CrQty14"] != DBNull.Value)
                        oItem.CrQty14 = Convert.ToDouble(reader["CrQty14"]);
                    else oItem.CrQty14 = 0;

                    if (reader["CrAmount14"] != DBNull.Value)
                        oItem.CrAmount14 = Convert.ToDouble(reader["CrAmount14"]);
                    else oItem.CrAmount14 = 0;

                    InnerList.Add(oItem);


                }
                reader.Close();
                InnerList.TrimToSize();

            }
            catch (Exception ex)
            {
                throw (ex);
            }

        }



    }
}

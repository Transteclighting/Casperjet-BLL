// <summary>
// Compamy: Transcom Electronics Limited
// Author: Dipak k. Chakraborty
// Date: Mar 06, 2012
// Time" : 10:30 AM
// Description: Replacement Analysis Report SKU and Fault Wise [71]
// Modify Person And Date:
// </summary>

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Data.OleDb;
using CJ.Class;

namespace CJ.Class.Report
{
    public class RptReplacementReportSKUFaultWise
    {
        private int _nPGID;
        private string _sPGCode;
        private string _sPGName;
        private int _nMAGID;
        private string _sMAGCode;
        private string _sMAGName;
        private int _nASGID;
        private string _sASGCode;
        private string _sASGName;
        private int _nAGID;
        private string _sAGCode;
        private string _sAGName;
        private int _nBrandID;
        private string _sBrandCode;
        private string _sBrandDesc;
        private int _nProductID;
        private string _sProductCode;
        private string _sProductName;
        private double _PinMissing;
        private double _BadSolder;
        private double _Oxidized;
        private double _LooseCap;
        private double _ShortLife;
        private double _CoilBroke;
        private double _OtherBrand;
        private double _OKLamp;
        private double _LifeOver;
        private double _BrokenLamp;
        private double _NoCarton;
        private double _BadCircuit;
        private double _LooseTube;
        private double _RustyLamp;
        private double _BadTube;
        private double _TempLamp;
        private double _Dead;
        private double _ExpireWarranty;
        private double _GoodCondition;
        private double _MTDQty;


        public int PGID
        {
            get { return _nPGID; }
            set { _nPGID = value; }
        }
        public string PGCode
        {
            get { return _sPGCode; }
            set { _sPGCode = value; }
        }
        public string PGName
        {
            get { return _sPGName; }
            set { _sPGName = value; }
        }
        public int MAGID
        {
            get { return _nMAGID; }
            set { _nMAGID = value; }
        }
        public string MAGCode
        {
            get { return _sMAGCode; }
            set { _sMAGCode = value; }
        }
        public string MAGName
        {
            get { return _sMAGName; }
            set { _sMAGName = value; }
        }
        public int ASGID
        {
            get { return _nASGID; }
            set { _nASGID = value; }
        }
        public string ASGCode
        {
            get { return _sASGCode; }
            set { _sASGCode = value; }
        }
        public string ASGName
        {
            get { return _sASGName; }
            set { _sASGName = value; }
        }
        public int AGID
        {
            get { return _nAGID; }
            set { _nMAGID = value; }
        }
        public string AGCode
        {
            get { return _sAGCode; }
            set { _sAGCode = value; }
        }
        public string AGName
        {
            get { return _sAGName; }
            set { _sAGName = value; }
        }
        public int BrandID
        {
            get { return _nBrandID; }
            set { _nBrandID = value; }
        }
        public string BrandCode
        {
            get { return _sBrandCode; }
            set { _sBrandCode = value; }
        }
        public string BrandDesc
        {
            get { return _sBrandDesc; }
            set { _sBrandDesc = value; }
        }
        public int ProductID
        {
            get { return _nProductID; }
            set { _nProductID = value; }
        }
        public string ProductCode
        {
            get { return _sProductCode; }
            set { _sProductCode = value; }
        }
        public string ProductName
        {
            get { return _sProductName; }
            set { _sProductName = value; }
        }
        public double PinMissing
        {
            get { return _PinMissing; }
            set { _PinMissing = value; }
        }
        public double BadSolder
        {
            get { return _BadSolder; }
            set { _BadSolder = value; }
        }
        public double Oxidized
        {
            get { return _Oxidized; }
            set { _Oxidized = value; }
        }
        public double LooseCap
        {
            get { return _LooseCap; }
            set { _LooseCap = value; }
        }
        public double ShortLife
        {
            get { return _ShortLife; }
            set { _ShortLife = value; }
        }
        public double CoilBroke
        {
            get { return _CoilBroke; }
            set { _CoilBroke = value; }
        }
        public double OtherBrand
        {
            get { return _OtherBrand; }
            set { _OtherBrand = value; }
        }
        public double OKLamp
        {
            get { return _OKLamp; }
            set { _OKLamp = value; }
        }
        public double LifeOver
        {
            get { return _LifeOver; }
            set { _LifeOver = value; }
        }
        public double BrokenLamp
        {
            get { return _BrokenLamp; }
            set { _BrokenLamp = value; }
        }
        public double NoCarton
        {
            get { return _NoCarton; }
            set { _NoCarton = value; }
        }
        public double BadCircuit
        {
            get { return _BadCircuit; }
            set { _BadCircuit = value; }
        }
        public double LooseTube
        {
            get { return _LooseTube; }
            set { _LooseTube = value; }
        }
        public double RustyLamp
        {
            get { return _RustyLamp; }
            set { _RustyLamp = value; }
        }
        public double BadTube
        {
            get { return _BadTube; }
            set { _BadTube = value; }
        }
        public double TempLamp
        {
            get { return _TempLamp; }
            set { _TempLamp = value; }
        }
        public double Dead
        {
            get { return _Dead; }
            set { _Dead = value; }
        }
        public double ExpireWarranty
        {
            get { return _ExpireWarranty; }
            set { _ExpireWarranty = value; }
        }
        public double GoodCondition
        {
            get { return _GoodCondition; }
            set { _GoodCondition = value; }
        }
        public double MTDQty
        {
            get { return _MTDQty; }
            set { _MTDQty = value; }
        }

    }
}

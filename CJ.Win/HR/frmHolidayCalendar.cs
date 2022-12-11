using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using CJ.Class;

namespace CJ.Win
{
    public partial class frmHolidayCalendar : Form
    {
        private Companys _oCompanys;
        private int _nSelectedCompanyID;
        private Holidays _oHolidays; 
        private int _nMonth;
        private int _nYear;
        private DateTime _dMonthDate;
        private int _nFirstDay;
        private string _sReason;
        public frmHolidayCalendar()
        {
            InitializeComponent();
        }

        private void frmHolidayCalendar_Load(object sender, EventArgs e)
        {
            

            _oHolidays = new Holidays();
            _nMonth = DateTime.Today.Month;
            _nYear = DateTime.Today.Year;
            LoadCombos();
            
            btnMonth.Text = DateTime.Today.ToString("MMMM yyyy");
            //RefreshCalendar();

        }

        private void LoadCombos()
        {

            //Company
            _oCompanys = new Companys();
            _oCompanys.Refresh();
            cboCompany.Items.Clear();
            foreach (Company oCompany in _oCompanys)
            {
                cboCompany.Items.Add(oCompany.CompanyName);
            }
            cboCompany.SelectedIndex = 0;
        }

        private void cboCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            _nSelectedCompanyID = _oCompanys[cboCompany.SelectedIndex].CompanyID;
            _oHolidays.Refresh(_nSelectedCompanyID, _nMonth, _nYear); 
            RefreshCalendar();
        }

        private void RefreshCalendar()
        {
            Button oButton;

            _dMonthDate = new DateTime(_nYear, _nMonth, 1);
            int nDayCount= _dMonthDate.AddMonths(1).AddDays(-1).Day; 
            _nFirstDay=(int)_dMonthDate.DayOfWeek; 
            for (int i = 0; i < 42; i++)
            {
                if (i >= _nFirstDay && i < _nFirstDay + nDayCount)
                {
                    int x = i - _nFirstDay + 1;
                    oButton = (Button)this.Controls["btnDay" + i];
                    oButton.Text = x.ToString();
                    int nIndex = _oHolidays.GetIndex(_nSelectedCompanyID, _dMonthDate.AddDays(i - _nFirstDay));
                    if (nIndex >= 0)
                    { oButton.ForeColor = Color.Red; }
                    else
                    { oButton.ForeColor = Color.Black; }
                }
                else 
                {
                    this.Controls["btnDay" + i].Text = "";
                    
                }
                //Added by Hakim
                if (this.Controls["btnDay" + i].Text == "")
                {
                    this.Controls["btnDay" + i].Enabled = false;
                }
                else
                {
                    this.Controls["btnDay" + i].Enabled = true;
                }
            }
            RefreshList();
        }

        private void RefreshList()
        {
            lvwHolidays.Items.Clear();
            //DBController.Instance.OpenNewConnection();
            //oDesignations.Refresh();
            this.Text = "Holiday " + "[" + _oHolidays.Count + "]";
            foreach (Holiday oHoliday in _oHolidays)
            {
                ListViewItem oItem = lvwHolidays.Items.Add(oHoliday.HolidayDate.ToString("dd-MMM-yyyy"));
                oItem.SubItems.Add(oHoliday.Reason);
                oItem.Tag = oHoliday;
            }
        }

        private void IncrMonth()
        {
            if (_nMonth == 12)
            {
                _nMonth = 1;
                _nYear=_nYear+1;
            }
            else
            {
                _nMonth = _nMonth + 1;
            }
            btnMonth.Text = new DateTime(_nYear,_nMonth,1).ToString("MMMM yyyy");
        }

        private void DecrMonth()
        {
            if (_nMonth == 1)
            {
                _nMonth = 12;
                _nYear = _nYear - 1;
            }
            else
            {
                _nMonth = _nMonth - 1;
            }
            btnMonth.Text = new DateTime(_nYear, _nMonth, 1).ToString("MMMM yyyy");
        }

        private void btnMonthBack_Click(object sender, EventArgs e)
        {
            DecrMonth();
            _oHolidays.Refresh(_nSelectedCompanyID, _nMonth, _nYear); 
            RefreshCalendar();
        }

        private void btnMonthFront_Click(object sender, EventArgs e)
        {
            IncrMonth();
            _oHolidays.Refresh(_nSelectedCompanyID, _nMonth, _nYear); 
            RefreshCalendar();
        }

        private void btnWeek_Click(object sender, EventArgs e)
        {
            Button oWeekButton = (Button)sender; 
            Button oButton;
            //int nCount = 0;
            _sReason = "Weekly Holiday";
            int nIndex =Convert.ToInt32(oWeekButton.Tag);
            for (int i = nIndex; i < 42; i = i + 7)
            {
                oButton=(Button)this.Controls["btnDay" + i];
                if (oButton.Text != "")
                {
                    if (oButton.ForeColor == Color.Red)
                    {
                        ResetHoliday(_dMonthDate.AddDays(i - _nFirstDay));
                        oButton.ForeColor = Color.Black;
                    }
                    else
                    {
                        SetHoliday(_dMonthDate.AddDays( i - _nFirstDay));
                        oButton.ForeColor = Color.Red;
                    }
                }
            }
            _oHolidays.Refresh(_nSelectedCompanyID, _nMonth, _nYear);
            RefreshList();
         
        }

        private void SetHoliday(DateTime dDate)
        {
            Holiday oHoliday = new Holiday();
            oHoliday.HolidayDate = dDate;
            oHoliday.CompanyID = _nSelectedCompanyID;
            oHoliday.Reason = _sReason;
            oHoliday.Delete();
            oHoliday.Add();
        }

        private void ResetHoliday(DateTime dDate)
        {
            Holiday oHoliday = new Holiday();
            oHoliday.HolidayDate = dDate;
            oHoliday.CompanyID = _nSelectedCompanyID;
            oHoliday.Delete();

        }

        private void btnDay_Click(object sender, EventArgs e)
        {
            Button oButton = (Button)sender;

            int nIndex = Convert.ToInt32(oButton.Tag);
            if (oButton.Text != "")
            {
                if (oButton.ForeColor == Color.Red)
                {
                    DialogResult oResult = MessageBox.Show("Are you sure you want to delete Holiday? ", "Confirm Ticket Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (oResult == DialogResult.Yes)
                    {
                        ResetHoliday(_dMonthDate.AddDays(nIndex - _nFirstDay));
                        oButton.ForeColor = Color.Black;
                    }
                }
                else
                {
                    if (Utility.InputBox("Holiday", "Reason:", ref _sReason) == DialogResult.OK)
                    {
                        SetHoliday(_dMonthDate.AddDays(nIndex - _nFirstDay));
                        oButton.ForeColor = Color.Red;
                    }
                }
            }
            _oHolidays.Refresh(_nSelectedCompanyID, _nMonth, _nYear); 
            RefreshList();
        }



    }
}
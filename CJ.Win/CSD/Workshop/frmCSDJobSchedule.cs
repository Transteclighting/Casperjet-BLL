using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CJ.Class;
using CJ.Class.CSD;

namespace CJ.Win.CSD.Workshop
{
    public partial class frmCSDJobSchedule : Form
    {
        public CSDJobScheduleHistory _oCSDJobScheduleHistory;

        public frmCSDJobSchedule()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save();
            this.Close();
        }
        private void Save()
        {
            _oCSDJobScheduleHistory = new CSDJobScheduleHistory();
            _oCSDJobScheduleHistory.VisitingDate = dtVisitingDate.Value.Date;
            _oCSDJobScheduleHistory.VisitingTimeFrom = dtVisitingTimeFrom.Value.TimeOfDay;
            _oCSDJobScheduleHistory.VisitingTimeTo = dtVisitingTimeTo.Value.TimeOfDay;            
        }
         
    }
}
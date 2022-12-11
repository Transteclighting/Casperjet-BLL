using System;
using System.Collections.Generic;
using System.Text;

namespace CJ.Class.CSD
{
    public class CSDJobSummaryDateWise
    {
        public string Type { get; set; }
        public string JobStatus { get; set; } 
        public DateTime CreateDate { get; set; } 
        public int TotalJob { get; set; }
    }
}

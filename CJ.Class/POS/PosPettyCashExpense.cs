using System;
using System.Collections.Generic;
using System.Text;

namespace CJ.Class.POS
{
   public class PosPettyCashExpense
    {
        public string Description { get; set; }
        //public DateTime TranDate { get; set; }
        public string voucherNo { get; set; }
        public string Purpose { get; set; }
        public double Amount { get; set; }
        public double ApprovedAmount { get; set; }
    }
}

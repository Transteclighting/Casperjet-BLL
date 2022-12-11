using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CJ.API.Models.ViewModel
{
    public class EmiViewModel
    {
        public int BankID { get; set; }
        public string BankName { get; set; }
        public int Duration { get; set; }
        public string OptionName { get; set; }
        public int IsExtended { get; set; }
        public double InterestRate { get; set; }
        public double? ActulInterestRate { get; set; }
    }

}
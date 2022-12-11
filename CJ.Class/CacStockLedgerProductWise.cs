using System;
using System.Collections.Generic;
using System.Text;

namespace CJ.Class
{
    public class CacStockLedgerProductWise
    {
        public int ProductID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string TranNo { get; set; }
        public object TranDate { get; set; }
        public object TranTypeID { get; set; }
        public int GRDQty { get; set; }
        public int IssueQty { get; set; }
        public int Balance { get; set; }
    }
}

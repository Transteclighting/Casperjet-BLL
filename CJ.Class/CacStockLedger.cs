using System;
using System.Collections.Generic;
using System.Text;

namespace CJ.Class
{
   public class CacStockLedger
    {
        public string CACProductCode { get; set; }
        public string CACProductName { get; set; }
        public int OpeningStock { get; set; }
        public int GRDQty { get; set; }
        public int IssueQty { get; set; }
        public int ClosingStock { get; set; }
    }
}

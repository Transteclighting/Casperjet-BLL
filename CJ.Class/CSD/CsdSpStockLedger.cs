using System;


namespace CJ.Class.CSD
{
    public class CsdSpStockLedger
    {
        public string TranNo { get; set; }
        public DateTime TranDate { get; set; }
        public string TranType { get; set; }
        public int StockIn { get; set; }
        public int StockOut { get; set; }
        public double Balance { get; set; }
    }
}

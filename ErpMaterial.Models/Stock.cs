using System;
using System.Collections.Generic;

namespace ErpMaterial.Models
{
    public partial class Stock
    {
        public int StockId { get; set; }
        public string MaterialGroup { get; set; }
        public string MaterialCode { get; set; }
        public string MaterialDesc { get; set; }
        public string MaterialCount { get; set; }
        public double? Amount { get; set; }
        public string UnitOfMeasurement { get; set; }
        public string StockNum { get; set; }
        public DateTime? StorageTime { get; set; }
        public string WarehousePosition { get; set; }
        public string BookKeeper { get; set; }
    }
}

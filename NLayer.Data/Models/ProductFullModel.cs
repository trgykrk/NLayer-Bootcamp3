using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Data.Models
{
    public class ProductFullModel
    {
        public string StockCode { get; set; }
        public string StockName { get; set; }
        public string CategoryName { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }
        public int? Widht { get; set; }
        public int? Height { get; set; }
    }
}

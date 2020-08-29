using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dieimes.Ilegra.Domain
{
    public class Sale
    {
        public Sale(string id, string saleId, SaleItem saleItem, string salesManName)
        {
            Id = id;
            SaleId = saleId;
            SaleItem = saleItem;
            SalesManName = salesManName;
        }

        public string Id { get; set; }
        public string SaleId { get; set; }
        public SaleItem SaleItem { get; set; }
        public string SalesManName { get; set; }
    }
}

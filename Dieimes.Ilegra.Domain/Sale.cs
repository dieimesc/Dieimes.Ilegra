using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dieimes.Ilegra.Domain
{
    public class Sale
    {
        private List<SaleItem> _saleItems;

        public Sale()
        {
        }

        public Sale(string id, string saleId,  string salesManName)
        {
            Id = id;
            SaleId = saleId;          
            SalesManName = salesManName;
            _saleItems = new List<SaleItem>();
        }
        public void AddSaleItem(SaleItem saleItem)
        {
            _saleItems.Add(saleItem);
        }
        public decimal Total
        {
            get
            {
                return _saleItems.Sum(p => p.Price);
            }
        }

        public string Id { get; set; }
        public string SaleId { get; set; }
        public List<SaleItem> SaleItems { get { return _saleItems; } }
        public string SalesManName { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dieimes.Ilegra.Domain
{
    public class Sale
    {
        public string Id { get; set; }
        public string SaleId { get; set; }
        public List<SaleItem> SaleItems { get; set; }
        public SalesMan SalesManName { get; set; }
    }
}

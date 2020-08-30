using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dieimes.Ilegra.Domain
{
    public class OutFile
    {
        List<Custommer> _custommers;
        List<SalesMan> _salesMen;
        List<Sale> _sales;
        public OutFile()
        {
            _custommers = new List<Custommer>();
            _salesMen = new List<SalesMan>();
            _sales = new List<Sale>();
        }
       
        public void AddSalesMan(SalesMan salesMan)
        {
            _salesMen.Add(salesMan);
        }
        public void AddCustommer(Custommer custommer)
        {
            _custommers.Add(custommer);
        }
        public void AddSales(Sale sale)
        {
            _sales.Add(sale);
        }
        public long CustommersCount()
        {
            return _custommers.Count();
        }
        public long SalesManCount()
        {
            return _salesMen.Count();
        }
        public Sale GetExpansiveSale()
        {
            return _sales.Find(v => v.Total == _sales.Max(prop => prop.Total));
        }
        public string GetWorstSalesManName()
        {
            var salesBySalesMan = _sales.GroupBy(p => p.SalesManName)
                .Select(gp => new { SalesName = gp.Key, Total = gp.Select(p => p.Total).ToList()[0] }).ToList();


            return salesBySalesMan.OrderBy(o => o.Total).ToList().First().SalesName;
            
            
        }

    }
}

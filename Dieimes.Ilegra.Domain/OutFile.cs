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
        public void AddSalers(Sale sale)
        {
            _sales.Add(sale);
        }
        public long CustommersCount()
        {
            return _custommers.Count();
        }
        public long SalesCount()
        {
            return _salesMen.Count();
        }
        public Sale GetExpansiveSale()
        {
            return _sales.Find( p => p.SaleItem.Price == _sales.Max(prop => prop.SaleItem.Price));
        }
        public SalesMan GetWorstSalesMan()
        {
           
           Dictionary<SalesMan, decimal> _salesByMan = new Dictionary<SalesMan, decimal>();
           foreach(SalesMan _saleMan in _salesMen)
           {
               _salesByMan.Add(_saleMan, _sales.Sum(p => p.SaleItem.Price));
           }                     

            return
              _salesByMan.First(p => p.Value == _salesByMan.Min(p => p.Value)).Key;

        }

    }
}

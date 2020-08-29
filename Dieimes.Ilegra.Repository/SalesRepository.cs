using Dieimes.Ilegra.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dieimes.Ilegra.Repository
{
    class SalesRepository
    {
        FileInfo _fileInfo;
        public SalesRepository(FileInfo fileInfo)
        {
            _fileInfo = fileInfo;
        }
        public List<Sale> GetSales()
        {

        }
    }
}

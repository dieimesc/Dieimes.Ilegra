using Dieimes.Ilegra.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dieimes.Ilegra.Repository
{
    public class SalesManRepository
    {
        FileInfo _fileInfo;
        public SalesManRepository(FileInfo fileInfo)
        {
            _fileInfo = fileInfo;
        }
        public List<SalesMan> GetSalesMen()
        {

        }
    }
}

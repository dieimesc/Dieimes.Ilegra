using Dieimes.Ilegra.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dieimes.Ilegra.Repository
{
    public class CustommersRepository
    {
        FileInfo _fileInfo;
        public CustommersRepository(FileInfo fileInfo)
        {
            _fileInfo = fileInfo
        }
        public List<Custommer> GetCustommers()
        {

        }

    }
}

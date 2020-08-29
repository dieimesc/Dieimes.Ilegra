using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dieimes.Ilegra.Domain
{
    public class Custommer
    {
        public Custommer(string id, string cnpj, string name, string bussines, string area)
        {
            Id = id;
            Cnpj = cnpj;
            Name = name;
            Bussines = bussines;
            Area = area;
        }

        public string  Id { get; set; }
        public string Cnpj { get; set; }
        public string Name { get; set; }
        public string Bussines { get; set; }
        public string Area { get; set; }


    }
}

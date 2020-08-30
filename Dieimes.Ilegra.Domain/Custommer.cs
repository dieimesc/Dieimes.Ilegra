using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dieimes.Ilegra.Domain
{
    public class Custommer
    {
        public Custommer()
        {
        }

        public Custommer(string id, string cnpj, string name, string bussinesArea)
        {
            Id = id;
            Cnpj = cnpj;
            Name = name;
            BussinesArea = bussinesArea;
            
        }

        public string  Id { get; set; }
        public string Cnpj { get; set; }
        public string Name { get; set; }
        public string BussinesArea { get; set; }
       


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dieimes.Ilegra.Domain
{
    public class SalesMan
    {
        public SalesMan()
        {
        }

        public SalesMan(string id, string cpf, string name, decimal salary)
        {
            Id = id;
            Cpf = cpf;
            Name = name;
            Salary = salary;
        }

        public string Id { get; set; }
        public string Cpf { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }

    }
}

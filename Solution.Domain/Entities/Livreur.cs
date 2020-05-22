using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public class Livreur
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Salary { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string Disponibilité { get; set; }
        public double Distance { get; set; }
        public string Affectation { get; set; }

    }
}

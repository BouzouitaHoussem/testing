using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public class Reclamation
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public int Telephone { get; set; }
        public string Type { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
    }
}

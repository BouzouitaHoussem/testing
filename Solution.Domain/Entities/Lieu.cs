using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Domain.Entities
{
    public class Livraison
    {
        public string pays { get; set; }
        public string lieu { get; set; }
        public decimal cout { get; set; }
    }
    public class Livraisons
    {
        public List<Livraison> pays_public { get; set; }
        public Livraisons()
        {
            pays_public = new List<Livraison>();
            Livraison lieu = new Livraison();
            lieu.pays = "Tunisie";
            lieu.lieu = "Tunis";
            lieu.cout = 7;
            pays_public.Add(lieu);

            lieu = new Livraison();
            lieu.pays = "Tunisie";
            lieu.lieu = "Ben Arous";
            lieu.cout = 8;
            pays_public.Add(lieu);

            lieu = new Livraison();
            lieu.pays = "Tunisie";
            lieu.lieu = "Manouba";
            lieu.cout = 8;
            pays_public.Add(lieu);

            lieu = new Livraison();
            lieu.pays = "Tunisie";
            lieu.lieu = "Ariana";
            lieu.cout = 8;
            pays_public.Add(lieu);

            lieu = new Livraison();
            lieu.pays = "Tunisie";
            lieu.lieu = "Nabeul";
            lieu.cout = 9;
            pays_public.Add(lieu);

            lieu = new Livraison();
            lieu.pays = "Tunisie";
            lieu.lieu = "Sousse";
            lieu.cout = 10;
            pays_public.Add(lieu);

            lieu = new Livraison();
            lieu.pays = "Tunisie";
            lieu.lieu = "Mahdia";
            lieu.cout = 10;
            pays_public.Add(lieu);

            lieu = new Livraison();
            lieu.pays = "Tunisie";
            lieu.lieu = "Mounastir";
            lieu.cout = 10;
            pays_public.Add(lieu);

            lieu = new Livraison();
            lieu.pays = "Tunisie";
            lieu.lieu = "Sfax";
            lieu.cout = 11;
            pays_public.Add(lieu);
        }
    }
}

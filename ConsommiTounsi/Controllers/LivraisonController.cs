using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Solution.Domain.Entities;

namespace ConsommiTounsi.Controllers
{
    public class LivraisonController : Controller
    {
        // GET: Livraison
        public ActionResult Index()
        {
            Livraisons l = new Livraisons();
            return View(l.pays_public);
        }

        [HttpPost]
        public decimal CalculeCout(string pays, string lieu, string transport, decimal poid)
        {
            Livraisons l = new Livraisons();
            decimal tarif = l.pays_public.Where(p => p.pays == pays && p.lieu == lieu).Select(p => p.cout).SingleOrDefault();
            decimal transp = 0;
            if (transport == "voiture") transp = 5;
            else if (transport == "avion") transp = 20;
            else if (transport == "bateau") transp = 15;

            decimal CoutTotal = 0;
            CoutTotal = transp + tarif + (poid * 2);

            //Source data returned as JSON  
            return CoutTotal;
        }
    }
}
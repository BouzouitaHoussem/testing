using ConsommiTounsi.Models;
using IronRuby.Runtime;
using Solution.Domain.Entities;
using Solution.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ConsommiTounsi.Controllers
{
    public class LivreurController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        ILivreurService Service;
        public LivreurController()
        {
            Service = new LivreurService();
        }
        // GET: Livreur
        public ActionResult Index()
        {
            return View(Service.GetMany());
        }

        // GET: Livreur/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Livreur/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Livreur/Create
        [HttpPost]
        public ActionResult Create(Livreur livreur)
        {
            
            Service.Add(livreur);
            Service.Commit();
            return RedirectToAction("Index");
        }

        // GET: Livreur/Edit/5
        
        public ActionResult Edit(int id)
        {
            return View(Service.GetById(id));
        }

        // GET: Livreur/Stat/5
        public ActionResult Stat(int id)
        {
            return View(Service.GetById(id));
        }

        [HttpPost]
        public JsonResult NewChart()
        {
            List<object> iData = new List<object>();
            //Creating sample data  
            DataTable dt = new DataTable();
            dt.Columns.Add("Date", System.Type.GetType("System.DateTime"));
            dt.Columns.Add("Livraison", System.Type.GetType("System.Int32"));

            DataRow dr = dt.NewRow();
            dr["Date"] = "2020-03-23";
            dr["Livraison"] = 30;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Date"] = "2020-03-24";
            dr["Livraison"] = 35;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Date"] = "2020-03-25";
            dr["Livraison"] = 25;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Date"] = "2020-03-26";
            dr["Livraison"] = 20;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Date"] = "2020-03-27";
            dr["Livraison"] = 40;
            dt.Rows.Add(dr);
            dr = dt.NewRow();

            dr["Date"] = "2020-03-28";
            dr["Livraison"] = 10;
            dt.Rows.Add(dr);

            dr = dt.NewRow();
            dr["Date"] = "2020-03-29";
            dr["Livraison"] = 0;
            dt.Rows.Add(dr);

            //Looping and extracting each DataColumn to List<Object>  
            foreach (DataColumn dc in dt.Columns)
            {
                List<object> x = new List<object>();
                x = (from DataRow drr in dt.Rows select drr[dc.ColumnName]).ToList();
                iData.Add(x);
            }
            //Source data returned as JSON  
            return Json(iData, JsonRequestBehavior.AllowGet);
        }
        // GET: Livreur/Edit1/5

        public ActionResult Edit1(int id)
        {
            return View(Service.GetById(id));
        }

        // POST: Livreur/Edit/5

        // POST: Livreurs/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        public ActionResult Edit(int id,Livreur liv)
        {
            try
            {
                Livreur l = Service.GetById(id);
                l.LastName = liv.LastName;
                l.FirstName = liv.FirstName;
                Service.Update(l);
                Service.Commit();
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        // POST: Livreur/Edit1/5

        // POST: Livreurs/Edit1/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public ActionResult Edit1(int id, Livreur liv)
        {
            try
            {
                Livreur l = Service.GetById(id);
                l.Disponibilité = liv.Disponibilité;
                l.Distance = liv.Distance;
                l.Affectation = liv.Affectation;
                Service.Update(l);
                Service.Commit();
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Livreur/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(Service.GetById(id));
        }

        // POST: Livreur/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Livreur livreur)
        {
            try
            {
                //Service.Delete(client);
                //Service.Commit();
                //Service.Dispose();
                Livreur c = Service.GetById(id);
                Service.Delete(c);
                Service.Commit();

                //Service.Delete(Service.Get(x=>x.ClientId.Equals(c)));
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
    }
}

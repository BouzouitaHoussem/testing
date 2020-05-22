using Solution.Domain.Entities;
using Solution.Service;
using Solution.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Solution.Web.Controllers
{
    public class FilmController : Controller
    {
        IFilmService Service;
        public FilmController()
        {
            Service = new FilmService();
        }
        // GET: Film
        public ActionResult Index()
        {
            List<FilmVM> Films = new List<FilmVM>();
            foreach (Film f in Service.GetMany())
            {
                Films.Add(new FilmVM {
                    Id = f.Id,
                    Description = f.Description,
                    Genre = f.Genre,
                    ImageUrl = f.ImageUrl,
                    OutDate = f.OutDate,
                    Title = f.Title,
                });
                
            }
            return View(Films);
        }

        // GET: Film/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Film/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Film/Create
        [HttpPost]
        public ActionResult Create(FilmVM FilmVM)
        {
            Film f = new Film() { 
            Id=FilmVM.Id,
            Description=FilmVM.Description,
            Genre=FilmVM.Genre,
            ImageUrl=FilmVM.ImageUrl,
            OutDate=FilmVM.OutDate,
            Title=FilmVM.Title,
            
            };
            Service.Add(f);
            Service.Commit();
            return (RedirectToAction("Index"));

            
        }

        // GET: Film/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Film/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Film/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Film/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
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

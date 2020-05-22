using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ConsommiTounsi.Models;
using Solution.Data;
using Solution.Domain.Entities;
using Solution.Service;

namespace ConsommiTounsi.Controllers
{
    public class ReclamationssController : ApiController
    {
        IReclamationService MyService = null;
        private ReclamationService es = new ReclamationService();
        List<Reclamation> Reclamations = new List<Reclamation>();
        public ReclamationssController()
        {
            MyService = new ReclamationService();
            Index();
            Reclamations = Index().ToList();
        }
        public List<Reclamation> Index()
        {
            List<Reclamation> mandates = es.GetMany().ToList();
            List<Reclamation> mandatesXml = new List<Reclamation>();
            foreach (Reclamation i in mandates)
            {
                mandatesXml.Add(new Reclamation
                {
                    Id = i.Id,

                    Nom = i.Nom,
                    Prenom = i.Prenom,
                    Telephone = i.Telephone,
                    Type = i.Type,
                    Email = i.Email,

                });
            }
            return mandatesXml;
        }
        // GET api/Reclamationss
        [HttpGet]
        public IEnumerable<Reclamation> Get()
        {
            return Reclamations;
        }
        // GET api/<controller>/5
        public Reclamation Get(int id)
        {
            Reclamation ev = MyService.GetById(id);
            return ev;
        }
        // POST: api/EventWebApi
        [Route("api/EventPost")]
        public IHttpActionResult PostNewFeed(Reclamation postt)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");
            using (var ctx = new MyContext())
            {
                ctx.Reclamations.Add(new Reclamation()
                {
                    Id = postt.Id,

                    Nom = postt.Nom,

                    Prenom = postt.Prenom,
                    Telephone = postt.Telephone,
                    Type = postt.Type,
                    Email = postt.Email,

                });
                ctx.SaveChanges();
            }
            return Ok();
        }
        // PUT: api/EventWebApi/5
        public IHttpActionResult Put(Reclamation student)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");
            using (var ctx = new MyContext())
            {
                var existingStudent = ctx.Reclamations.Where(s => s.Id == student.Id)
                                                        .FirstOrDefault<Reclamation>();
                if (existingStudent != null)
                {
                    existingStudent.Nom = student.Nom;
                    existingStudent.Prenom = student.Prenom;
                    existingStudent.Telephone = student.Telephone;
                    existingStudent.Type = student.Type;
                    existingStudent.Email = student.Email;
                    ctx.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }
            return Ok();
        }
        // DELETE: api/EventWebApi/5
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid student id");
            using (var ctx = new MyContext())
            {
                var student = ctx.Reclamations
                    .Where(s => s.Id == id)
                    .FirstOrDefault();
                ctx.Entry(student).State = System.Data.Entity.EntityState.Deleted;
                ctx.SaveChanges();
            }
            return Ok();
        }
    }
}
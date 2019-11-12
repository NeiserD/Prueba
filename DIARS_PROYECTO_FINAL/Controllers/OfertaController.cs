using DIARS_PROYECTO_FINAL.BD;
using DIARS_PROYECTO_FINAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DIARS_PROYECTO_FINAL.Controllers
{
    public class OfertaController : Controller
    {
        StoreContext context = new StoreContext();
        public ActionResult Index()
        {
            var oferta = context.ofertas.ToList();
            return View(oferta);
        }

        // GET: Oferta/Create
        public ActionResult Crear()
        {
            return View(new Oferta());
        }

        // POST: Oferta/Create
        [HttpPost]
        public ActionResult Crear(Oferta oferta)
        {
            try
            {
                context.ofertas.Add(oferta);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(oferta);
            }
        }

        // GET: Oferta/Edit/5
        public ActionResult Editar(int ID)
        {

            var oferta = context.ofertas.Where(o=>o.id== ID).First();

            return View(oferta);
        }

        // POST: Oferta/Edit/5
        [HttpPost]
        public ActionResult Editar(Oferta oferta)
        {
            try
            {
                context.Entry(oferta).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Oferta/Delete/5
        public ActionResult Eliminar(int ID)
        {
            Oferta oferta = context.ofertas.Where(x=>x.id== ID).First();
            context.ofertas.Remove(oferta);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        
    }
}

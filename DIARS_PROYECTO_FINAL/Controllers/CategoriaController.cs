using DIARS_PROYECTO_FINAL.BD;
using DIARS_PROYECTO_FINAL.Models;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace DIARS_PROYECTO_FINAL.Controllers
{
    public class CategoriaController : Controller
    {

        public StoreContext context = new StoreContext();

        public ViewResult Index()
        {
            var categorias = context.Categorias.ToList();
            return View(categorias);
        }


        // GET: Categoría/Create
        public ViewResult Crear()
        {
            return View(new Categoria());
        }

        // POST: Categoría/Create
        [HttpPost]
        public ActionResult Crear(Categoria categoria)
        {
            try
            {
                context.Categorias.Add(categoria);
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View(categoria);
            }
        }

        [HttpGet]
        public ViewResult Editar(int ID)
        {
            var categoria = context.Categorias.Where(x => x.id == ID).First();
            return View(categoria);
        }

        // POST: Categoría/Edit/5
        [HttpPost]
        public ActionResult Editar(Categoria categoria)
        {
            try
            {
                context.Entry(categoria).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(categoria);
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int ID)
        {
            Categoria categoria = context.Categorias.Where(x => x.id == ID).First();
            context.Categorias.Remove(categoria);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

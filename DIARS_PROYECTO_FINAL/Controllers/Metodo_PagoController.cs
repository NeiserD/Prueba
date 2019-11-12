﻿using DIARS_PROYECTO_FINAL.BD;
using DIARS_PROYECTO_FINAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DIARS_PROYECTO_FINAL.Controllers
{
    public class Metodo_PagoController : Controller
    {
        StoreContext context = new StoreContext();

        public ActionResult Index()
        {
            var pagos = context.metodoPagos.ToList();
            return View(pagos);
        }



        // GET: Metodo_Pago/Create
        public ActionResult Crear()
        {
            return View(new MetodoPago());
        }

        // POST: Metodo_Pago/Create
        [HttpPost]
        public ActionResult Crear(MetodoPago metodoPago)
        {
            try
            {
                context.metodoPagos.Add(metodoPago);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(metodoPago);
            }
        }

        [HttpGet]
        public ActionResult Editar(int ID)
        {
            var metodoPag = context.metodoPagos.Where(x=>x.id==ID).First();
            
            return View(metodoPag);
        }

        // POST: Metodo_Pago/Edit/5
        [HttpPost]
        public ActionResult Editar(MetodoPago metodoPago)
        {
            try
            {
                context.Entry(metodoPago).State = EntityState.Modified;
                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        [HttpGet]
        public ActionResult Eliminar(int ID)
        {
            MetodoPago metodoPago = context.metodoPagos.Where(x=>x.id==ID).First();
            context.metodoPagos.Remove(metodoPago);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

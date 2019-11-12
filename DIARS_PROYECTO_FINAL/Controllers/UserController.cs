using DIARS_PROYECTO_FINAL.BD;
using DIARS_PROYECTO_FINAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DIARS_PROYECTO_FINAL.Controllers
{
    public class UserController : Controller
    {

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario objUser)
        {
            validar(objUser);
            if (ModelState.IsValid)
            {
                using (StoreContext db = new StoreContext())
                {
                    var obj = db.Usuarios.Where(a => a.username.Equals(objUser.username) && a.password.Equals(objUser.password)).FirstOrDefault();
                    if (obj != null)
                    {
                        Session["Id"] = obj.Id.ToString();
                        Session["username"] = obj.username.ToString();
                        return RedirectToAction("UserDashBoard");
                    }
                }

            }
            validarambos(objUser);
            return View(objUser);
        }

        public ActionResult UserDashBoard()
        {
            if (Session["Id"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult Salir()
        {
            Session.Abandon();
            Response.Cookies.Add(new HttpCookie("ASP.NET_SessionId", ""));
            return RedirectToAction("", "Home");
            //ModelState.AddModelError("", "Sesión Cerrada");
        }

        public void validar(Usuario objUser)
        {
            if (objUser.username == null || objUser.username == " ")
            {
                ModelState.AddModelError("username", "Ingrese su nombre de usuario");
            }

            if (objUser.password == null || objUser.password == " ")
            {
                ModelState.AddModelError("password", "Ingrese su contraseña");
            }
        }
        public void validarambos(Usuario objUser)
        {
            if (objUser.username != null && objUser.username != "" || objUser.password != null && objUser.password != "")
            {
                ModelState.AddModelError("invalid", "Usuario y/o Contraseña incorrecta");
            }
        }
    }
}

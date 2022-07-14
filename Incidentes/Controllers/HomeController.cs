using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

using Incidentes.Models;
using Incidentes.Logic;

namespace Incidentes.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Manager()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Validador()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Restringido()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session["Asesor"] = null;
            return RedirectToAction("Index", "Acceso");
        }

        [HttpPost]
        public ActionResult ConsultarClienteManager(string idCliente)
        {
            Asesor asesor = (Asesor)Session["Asesor"];
            Cliente obj = new LO_Cliente().ConsultaClienteManager(idCliente);
            return Json(new { cliente = obj}, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ConsultarClienteValidador(string idCliente)
        {
            Asesor asesor = (Asesor)Session["Asesor"];
            Cliente obj = new LO_Cliente().ConsultaClienteValidador(idCliente);
            return Json(new { cliente = obj }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ConsultarClienteRestringido(string idCliente)
        {
            Asesor asesor = (Asesor)Session["Asesor"];
            Cliente obj = new LO_Cliente().ConsultaClienteRestringido(idCliente);
            return Json(new { cliente = obj }, JsonRequestBehavior.AllowGet);
        }
    }
}
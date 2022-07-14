using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Incidentes.Models;
using Incidentes.Logic;
using System.Web.Security;

namespace Incidentes.Controllers
{
    public class AccesoController : Controller
    {
        // GET: Acceso
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string usuario, string auth)
        {
            Asesor obj = new LO_Asesor().ConsultaAsesor(usuario,auth);
            if(obj.usuario != null)
            {
                FormsAuthentication.SetAuthCookie(obj.auth, false);
                Session["Asesor"] = obj;
                if (obj.perfil == "Manager")
                {
                    return RedirectToAction("Manager", "Home");

                }else if(obj.perfil == "Validador")
                {
                    return RedirectToAction("Validador", "Home");
                }
                else if (obj.perfil == "Restringido")
                {
                    return RedirectToAction("Restringido", "Home");
                }

            }
            Console.WriteLine(obj);
            return View();
        } 
    }
}
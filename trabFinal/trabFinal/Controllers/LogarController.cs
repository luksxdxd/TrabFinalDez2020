using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using trabFinal.Context;

namespace trabFinal.Controllers
{
    public class LogarController : Controller
    {
        private Contexto db = new Contexto();
        // GET: Logar
        public ActionResult Index(string erro)
        {
            if (erro != null)
            {
                TempData["error"] = erro;
            }

            return View();
        }

        [HttpPost]
        public ActionResult Verificar(Models.LoginModel userModel)
        {
            Models.LoginModel Consultar = (Models.LoginModel)db.logins.FirstOrDefault(u => u.Email == userModel.Email);
            String erro = "Usuário ou senha inválidos";
            if (Consultar == null)
            {
                return RedirectToAction(nameof(Index), new { @erro = erro });
            }

            if (BCrypt.Net.BCrypt.Verify(userModel.Senha, Consultar.Senha))
            {
                Session["Nome"] = Consultar.Username;
                Session["Nivel"] = Consultar.Nivel.ToLower();
                Session.Timeout = 1800;
                return RedirectToAction("Index", "Login");
            }

            return RedirectToAction(nameof(Index), new { @erro = erro });

        }
    }
}
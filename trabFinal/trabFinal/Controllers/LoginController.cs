using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using trabFinal.Context;
using trabFinal.Models;
using System.Data.Entity;

namespace trabFinal.Controllers
{
    public class LoginController : Controller
    {

        private Contexto db = new Contexto();
        // GET: Login
        public ActionResult Index()
        {
            if (Session["Nome"] == null)
            {
                return RedirectToAction("Index", "Logar");
            }

            return View(db.logins.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LoginModel user)
        {
            if (ModelState.IsValid)
            {
                user.Senha = BCrypt.Net.BCrypt.HashPassword(user.Senha);

                db.logins.Add(user);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(user);
        }

        public ActionResult details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginModel loginModel = db.logins.Find(id);
            if (loginModel == null)
            {
                return HttpNotFound();
            }
            return View(loginModel);
        }

        public ActionResult edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginModel userModel = db.logins.Find(id);
            if (userModel == null)
            {
                return HttpNotFound();
            }

            return View(userModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult edit(LoginModel userModel)
        {
            LoginModel user = db.logins.Find(userModel.Id);
            userModel.Senha = user.Senha;
            db.Entry(user).State = EntityState.Detached;

            db.Entry(userModel).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginModel userModel = db.logins.Find(id);
            if (userModel == null)
            {
                return HttpNotFound();
            }

            return View(userModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            LoginModel userModel = db.logins.Find(id);
            db.logins.Remove(userModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Logar");
        }

    }
}


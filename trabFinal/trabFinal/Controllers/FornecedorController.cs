using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using trabFinal.Context;
using trabFinal.Models;

namespace trabFinal.Controllers
{
    public class FornecedorController : Controller
    {
        private Contexto db = new Contexto();

        // GET: Fornecedor
        public ActionResult Index()
        {
            
            //if (Session["Nome"] == null)
            //{
            //    return RedirectToAction("Index", "Logar");
            //}
            return View(db.fornecedores.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FornecedorModel fornecedorModels)
        {
            if (ModelState.IsValid)
            {
                db.fornecedores.Add(fornecedorModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fornecedorModels);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FornecedorModel fornecedorModel = db.fornecedores.Find(id);
            if (fornecedorModel == null)
            {
                return HttpNotFound();
            }
            return View(fornecedorModel);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FornecedorModel fornecedorModel = db.fornecedores.Find(id);
            if (fornecedorModel == null)
            {
                return HttpNotFound();
            }
            return View(fornecedorModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FornecedorModel fornecedorModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fornecedorModel).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fornecedorModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FornecedorModel fornecedorModel = db.fornecedores.Find(id);
            if (fornecedorModel == null)
            {
                return HttpNotFound();
            }
            return View(fornecedorModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            FornecedorModel fornecedors = db.fornecedores.Find(id);
            db.fornecedores.Remove(fornecedors);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
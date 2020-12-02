using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using trabFinal.Context;
using System.Data.Entity;
using trabFinal.Models;
using System.Net;

namespace trabFinal.Controllers
{
    public class ProdutoController : Controller
    {
        private Contexto db = new Contexto();
        // GET: Produto
        public ActionResult Index()
        {
            if (Session["Nome"] == null)
            {
                return RedirectToAction("Index", "Logar");
            }
            var products = db.produtos.Include(c => c.fornEmpre).ToList();
            return View(products);
        }

        public ActionResult Create()
        {
            ViewBag.FornecedorId = new SelectList(db.fornecedores, "Id", "Empresa");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoModel produtoModels)
        {
            if (ModelState.IsValid)
            {
                db.produtos.Add(produtoModels);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.FornecedorId = new SelectList(db.produtos, "Id", "Empresa");
            return View(produtoModels);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            ProdutoModel produto = db.produtos.Include(c => c.fornEmpre).First(a => a.Id == id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        public ActionResult Edit(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoModel produto = db.produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.FornecedorId = new SelectList(db.produtos, "Id", "Empresa", produto.FornecedorId);
            return View(produto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoModel produtoModel)
        {

            if (ModelState.IsValid)
            {
                db.Entry(produtoModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FornecedorId = new SelectList(db.produtos, "Id", "Empresa", produtoModel.FornecedorId);
            return View(produtoModel);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoModel produto = db.produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.FornecedorId = new SelectList(db.produtos, "Id", "Empresa", produto.FornecedorId);
            return View(produto);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProdutoModel produtoModel = db.produtos.Find(id);
            db.produtos.Remove(produtoModel);
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
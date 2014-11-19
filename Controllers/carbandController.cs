using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication5.Models;

namespace MvcApplication5.Controllers
{
    public class carbandController : Controller
    {
        private carbandDBContext db = new carbandDBContext();

        //
        // GET: /carband/

        public ActionResult Index()
        {
            return View(db.carbands.ToList());
        }

        //
        // GET: /carband/Details/5

        public ActionResult Details(int id = 0)
        {
            carband carband = db.carbands.Find(id);
            if (carband == null)
            {
                return HttpNotFound();
            }
            return View(carband);
        }

        //
        // GET: /carband/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /carband/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(carband carband)
        {
            if (ModelState.IsValid)
            {
                db.carbands.Add(carband);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carband);
        }

        //
        // GET: /carband/Edit/5

        public ActionResult Edit(int id = 0)
        {
            carband carband = db.carbands.Find(id);
            if (carband == null)
            {
                return HttpNotFound();
            }
            return View(carband);
        }

        //
        // POST: /carband/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(carband carband)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carband).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carband);
        }

        //
        // GET: /carband/Delete/5

        public ActionResult Delete(int id = 0)
        {
            carband carband = db.carbands.Find(id);
            if (carband == null)
            {
                return HttpNotFound();
            }
            return View(carband);
        }

        //
        // POST: /carband/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            carband carband = db.carbands.Find(id);
            db.carbands.Remove(carband);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
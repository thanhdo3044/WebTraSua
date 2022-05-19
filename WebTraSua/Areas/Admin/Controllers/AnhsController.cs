using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebTraSua.Models;

namespace WebTraSua.Areas.Admin.Controllers
{
    public class AnhsController : Controller
    {
        private MyDBTraSuaContext db = new MyDBTraSuaContext();

        // GET: Admin/Anhs
        public ActionResult Index()
        {
            return View(db.Anhs.ToList());
        }

        // GET: Admin/Anhs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anh anh = db.Anhs.Find(id);
            if (anh == null)
            {
                return HttpNotFound();
            }
            return View(anh);
        }

        // GET: Admin/Anhs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Anhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaA,DuongDan,ThoiGianA")] Anh anh)
        {
            if (ModelState.IsValid)
            {
                db.Anhs.Add(anh);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(anh);
        }

        // GET: Admin/Anhs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anh anh = db.Anhs.Find(id);
            if (anh == null)
            {
                return HttpNotFound();
            }
            return View(anh);
        }

        // POST: Admin/Anhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaA,DuongDan,ThoiGianA")] Anh anh)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anh).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(anh);
        }

        // GET: Admin/Anhs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Anh anh = db.Anhs.Find(id);
            if (anh == null)
            {
                return HttpNotFound();
            }
            return View(anh);
        }

        // POST: Admin/Anhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Anh anh = db.Anhs.Find(id);
            db.Anhs.Remove(anh);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

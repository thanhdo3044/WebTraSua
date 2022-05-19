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
    public class TinTucsController : Controller
    {
        private MyDBTraSuaContext db = new MyDBTraSuaContext();

        // GET: Admin/TinTucs
        public ActionResult Index()
        {
            var tinTucs = db.TinTucs.Include(t => t.Anh);
            return View(tinTucs.ToList());
        }

        // GET: Admin/TinTucs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TinTuc tinTuc = db.TinTucs.Find(id);
            if (tinTuc == null)
            {
                return HttpNotFound();
            }
            return View(tinTuc);
        }

        // GET: Admin/TinTucs/Create
        public ActionResult Create()
        {
            ViewBag.MaA = new SelectList(db.Anhs, "MaA", "DuongDan");
            return View();
        }

        // POST: Admin/TinTucs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaTT,MaA,NoiDungTT,ThoiGianTT,TieuDeTT,MotaTT")] TinTuc tinTuc)
        {
            if (ModelState.IsValid)
            {
                db.TinTucs.Add(tinTuc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaA = new SelectList(db.Anhs, "MaA", "DuongDan", tinTuc.MaA);
            return View(tinTuc);
        }

        // GET: Admin/TinTucs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TinTuc tinTuc = db.TinTucs.Find(id);
            if (tinTuc == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaA = new SelectList(db.Anhs, "MaA", "DuongDan", tinTuc.MaA);
            return View(tinTuc);
        }

        // POST: Admin/TinTucs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaTT,MaA,NoiDungTT,ThoiGianTT,TieuDeTT,MotaTT")] TinTuc tinTuc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tinTuc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaA = new SelectList(db.Anhs, "MaA", "DuongDan", tinTuc.MaA);
            return View(tinTuc);
        }

        // GET: Admin/TinTucs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TinTuc tinTuc = db.TinTucs.Find(id);
            if (tinTuc == null)
            {
                return HttpNotFound();
            }
            return View(tinTuc);
        }

        // POST: Admin/TinTucs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TinTuc tinTuc = db.TinTucs.Find(id);
            db.TinTucs.Remove(tinTuc);
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

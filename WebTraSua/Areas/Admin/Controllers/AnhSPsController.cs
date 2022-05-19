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
    public class AnhSPsController : Controller
    {
        private MyDBTraSuaContext db = new MyDBTraSuaContext();

        // GET: Admin/AnhSPs
        public ActionResult Index()
        {
            var anhSPs = db.AnhSPs.Include(a => a.Anh).Include(a => a.SanPham);
            return View(anhSPs.ToList());
        }

        // GET: Admin/AnhSPs/Details/5
        public ActionResult Details(string maSP, string maA)
        {
            if (maSP == null || maA == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnhSP anhSP = db.AnhSPs.Find(maSP,maA);
            if (anhSP == null)
            {
                return HttpNotFound();
            }
            return View(anhSP);
        }

        // GET: Admin/AnhSPs/Create
        public ActionResult Create()
        {
            ViewBag.MaA = new SelectList(db.Anhs, "MaA", "DuongDan");
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "MaDM");
            return View();
        }

        // POST: Admin/AnhSPs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSP,MaA,TenASP")] AnhSP anhSP)
        {
            if (ModelState.IsValid)
            {
                db.AnhSPs.Add(anhSP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaA = new SelectList(db.Anhs, "MaA", "DuongDan", anhSP.MaA);
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "MaDM", anhSP.MaSP);
            return View(anhSP);
        }

        // GET: Admin/AnhSPs/Edit/5
        public ActionResult Edit(string maSP, string maA)
        {
            if (maSP == null || maA == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnhSP anhSP = db.AnhSPs.Find(maSP, maA);
            if (anhSP == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaA = new SelectList(db.Anhs, "MaA", "DuongDan", anhSP.MaA);
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "MaDM", anhSP.MaSP);
            return View(anhSP);
        }

        // POST: Admin/AnhSPs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSP,MaA,TenASP")] AnhSP anhSP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(anhSP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaA = new SelectList(db.Anhs, "MaA", "DuongDan", anhSP.MaA);
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "MaDM", anhSP.MaSP);
            return View(anhSP);
        }

        // GET: Admin/AnhSPs/Delete/5
        public ActionResult Delete(string maSP, string maA)
        {
            if (maSP == null || maA == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnhSP anhSP = db.AnhSPs.Find(maSP, maA);
            if (anhSP == null)
            {
                return HttpNotFound();
            }
            return View(anhSP);
        }

        // POST: Admin/AnhSPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            AnhSP anhSP = db.AnhSPs.Find(id);
            db.AnhSPs.Remove(anhSP);
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

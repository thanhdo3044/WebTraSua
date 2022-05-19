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
    public class NguyenLieuxController : Controller
    {
        private MyDBTraSuaContext db = new MyDBTraSuaContext();

        // GET: Admin/NguyenLieux
        public ActionResult Index()
        {
            var nguyenLieux = db.NguyenLieux.Include(n => n.Anh).Include(n => n.NguoiDung);
            return View(nguyenLieux.ToList());
        }

        // GET: Admin/NguyenLieux/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguyenLieu nguyenLieu = db.NguyenLieux.Find(id);
            if (nguyenLieu == null)
            {
                return HttpNotFound();
            }
            return View(nguyenLieu);
        }

        // GET: Admin/NguyenLieux/Create
        public ActionResult Create()
        {
            ViewBag.MaA = new SelectList(db.Anhs, "MaA", "DuongDan");
            ViewBag.MaND = new SelectList(db.NguoiDungs, "MaND", "HoTenND");
            return View();
        }

        // POST: Admin/NguyenLieux/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaNL,MaA,MaND,TenNL,SoLuong,ChatLuong,GiaMua")] NguyenLieu nguyenLieu)
        {
            if (ModelState.IsValid)
            {
                db.NguyenLieux.Add(nguyenLieu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaA = new SelectList(db.Anhs, "MaA", "DuongDan", nguyenLieu.MaA);
            ViewBag.MaND = new SelectList(db.NguoiDungs, "MaND", "HoTenND", nguyenLieu.MaND);
            return View(nguyenLieu);
        }

        // GET: Admin/NguyenLieux/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguyenLieu nguyenLieu = db.NguyenLieux.Find(id);
            if (nguyenLieu == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaA = new SelectList(db.Anhs, "MaA", "DuongDan", nguyenLieu.MaA);
            ViewBag.MaND = new SelectList(db.NguoiDungs, "MaND", "HoTenND", nguyenLieu.MaND);
            return View(nguyenLieu);
        }

        // POST: Admin/NguyenLieux/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaNL,MaA,MaND,TenNL,SoLuong,ChatLuong,GiaMua")] NguyenLieu nguyenLieu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nguyenLieu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaA = new SelectList(db.Anhs, "MaA", "DuongDan", nguyenLieu.MaA);
            ViewBag.MaND = new SelectList(db.NguoiDungs, "MaND", "HoTenND", nguyenLieu.MaND);
            return View(nguyenLieu);
        }

        // GET: Admin/NguyenLieux/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NguyenLieu nguyenLieu = db.NguyenLieux.Find(id);
            if (nguyenLieu == null)
            {
                return HttpNotFound();
            }
            return View(nguyenLieu);
        }

        // POST: Admin/NguyenLieux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            NguyenLieu nguyenLieu = db.NguyenLieux.Find(id);
            db.NguyenLieux.Remove(nguyenLieu);
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

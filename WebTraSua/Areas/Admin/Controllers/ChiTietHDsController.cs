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
    public class ChiTietHDsController : Controller
    {
        private MyDBTraSuaContext db = new MyDBTraSuaContext();

        // GET: Admin/ChiTietHDs
        public ActionResult Index()
        {
            var chiTietHDs = db.ChiTietHDs.Include(c => c.HoaDon).Include(c => c.SanPham);
            return View(chiTietHDs.ToList());
        }

        // GET: Admin/ChiTietHDs/Details/5
        public ActionResult Details(string maHD, string maSP)
        {
            if (maHD == null || maSP == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietHD chiTietHD = db.ChiTietHDs.Find(maSP,maHD);
            if (chiTietHD == null)
            {
                return HttpNotFound();
            }
            return View(chiTietHD);
        }

        // GET: Admin/ChiTietHDs/Create
        public ActionResult Create()
        {
            ViewBag.MaHD = new SelectList(db.HoaDons, "MaHD", "MaND");
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "MaDM");
            return View();
        }

        // POST: Admin/ChiTietHDs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSP,MaHD,SoLuong")] ChiTietHD chiTietHD)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietHDs.Add(chiTietHD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaHD = new SelectList(db.HoaDons, "MaHD", "MaND", chiTietHD.MaHD);
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "MaDM", chiTietHD.MaSP);
            return View(chiTietHD);
        }

        // GET: Admin/ChiTietHDs/Edit/5
        public ActionResult Edit(string maHD, string maSP)
        {
            if (maHD == null || maSP == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietHD chiTietHD = db.ChiTietHDs.Find(maSP, maHD);
            if (chiTietHD == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaHD = new SelectList(db.HoaDons, "MaHD", "MaND", chiTietHD.MaHD);
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "MaDM", chiTietHD.MaSP);
            return View(chiTietHD);
        }

        // POST: Admin/ChiTietHDs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSP,MaHD,SoLuong")] ChiTietHD chiTietHD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietHD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaHD = new SelectList(db.HoaDons, "MaHD", "MaND", chiTietHD.MaHD);
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "MaDM", chiTietHD.MaSP);
            return View(chiTietHD);
        }

        // GET: Admin/ChiTietHDs/Delete/5
        public ActionResult Delete(string maHD, string maSP)
        {
            if (maHD == null || maSP == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietHD chiTietHD = db.ChiTietHDs.Find(maSP, maHD);
            if (chiTietHD == null)
            {
                return HttpNotFound();
            }
            return View(chiTietHD);
        }

        // POST: Admin/ChiTietHDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ChiTietHD chiTietHD = db.ChiTietHDs.Find(id);
            db.ChiTietHDs.Remove(chiTietHD);
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

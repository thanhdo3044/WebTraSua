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
    public class BinhLuansController : Controller
    {
        private MyDBTraSuaContext db = new MyDBTraSuaContext();

        // GET: Admin/BinhLuans
        public ActionResult Index()
        {
            var binhLuans = db.BinhLuans.Include(b => b.NguoiDung).Include(b => b.SanPham);
            return View(binhLuans.ToList());
        }

        // GET: Admin/BinhLuans/Details/5
        public ActionResult Details(string maSP, string maND)
        {
            if (maSP == null || maND == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BinhLuan binhLuan = db.BinhLuans.Find(maSP, maND);
            if (binhLuan == null)
            {
                return HttpNotFound();
            }
            return View(binhLuan);
        }

        // GET: Admin/BinhLuans/Create
        public ActionResult Create()
        {
            ViewBag.MaND = new SelectList(db.NguoiDungs, "MaND", "HoTenND");
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "MaDM");
            return View();
        }

        // POST: Admin/BinhLuans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSP,MaND,NoiDungBL,TrangThaiBL")] BinhLuan binhLuan)
        {
            if (ModelState.IsValid)
            {
                db.BinhLuans.Add(binhLuan);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaND = new SelectList(db.NguoiDungs, "MaND", "HoTenND", binhLuan.MaND);
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "MaDM", binhLuan.MaSP);
            return View(binhLuan);
        }

        // GET: Admin/BinhLuans/Edit/5
        public ActionResult Edit(string maSP, string maND)
        {
            if (maSP == null || maND == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BinhLuan binhLuan = db.BinhLuans.Find(maSP, maND);
            if (binhLuan == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaND = new SelectList(db.NguoiDungs, "MaND", "HoTenND", binhLuan.MaND);
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "MaDM", binhLuan.MaSP);
            return View(binhLuan);
        }

        // POST: Admin/BinhLuans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSP,MaND,NoiDungBL,TrangThaiBL")] BinhLuan binhLuan)
        {
            if (ModelState.IsValid)
            {
                db.Entry(binhLuan).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaND = new SelectList(db.NguoiDungs, "MaND", "HoTenND", binhLuan.MaND);
            ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "MaDM", binhLuan.MaSP);
            return View(binhLuan);
        }

        // GET: Admin/BinhLuans/Delete/5
        public ActionResult Delete(string maSP, string maND)
        {
            //Console.Out.WriteLine("log " + id);
            
            if (maSP == null || maND == null)
            {
                //System.Diagnostics.Debug.WriteLine("log " + id);
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BinhLuan binhLuan = db.BinhLuans.Find(maSP, maND);
            if (binhLuan == null)
            {
                return HttpNotFound();
            }
            return View(binhLuan);
        }

        // POST: Admin/BinhLuans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string maSP, string maND)
        {
            BinhLuan binhLuan = db.BinhLuans.Find(maSP, maND);
            db.BinhLuans.Remove(binhLuan);
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

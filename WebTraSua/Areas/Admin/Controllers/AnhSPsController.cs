using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
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
			var anhSPs = db.AnhSPs.ToList();
			return View(anhSPs);
		}

		// GET: Admin/AnhSPs/Details/5
		public ActionResult Details(int id)
		{
			if (id == 0)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			AnhSP anhSP = (from item in db.AnhSPs where item.id == id select item).DefaultIfEmpty().First();
			if (anhSP == null)
			{
				return HttpNotFound();
			}
			return View(anhSP);
		}

		// GET: Admin/AnhSPs/Create
		public ActionResult Create()
		{
			ViewBag.MaA = new SelectList(db.Anhs, "MaA", "MaA");
			ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "MaSP");
			return View();
		}

		// POST: Admin/AnhSPs/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(AnhSP anhSP, HttpPostedFileBase fileImage)
		{
			if (fileImage != null && fileImage.ContentLength > 0)
			{
				string FileName = Path.GetFileName(fileImage.FileName);
				string path = Path.Combine(Server.MapPath("~/Imgage/"), FileName);
				if (System.IO.File.Exists(path))
				{
					System.IO.File.Delete(path);
					fileImage.SaveAs(path);
				}
				else
				{
					fileImage.SaveAs(path);
				}
				path = path.Substring(72, path.Length - 72);
				anhSP.urlimg = path;

			}

			if (ModelState.IsValid)
			{
				db.AnhSPs.Add(anhSP);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			ViewBag.MaA = new SelectList(db.Anhs, "MaA", "MaA");
			ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "MaSP");
			return View(anhSP);
		}

		// GET: Admin/AnhSPs/Edit/5
		public ActionResult Edit(int id)
		{
			if (id == 0)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			AnhSP anhSP = (from item in db.AnhSPs where item.id == id select item).FirstOrDefault();
			if (anhSP == null)
			{
				return HttpNotFound();
			}
			ViewBag.MaA = new SelectList(db.Anhs, "MaA", "MaA", anhSP.Anh.MaA);
			ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "MaSP", anhSP.SanPham.MaSP);
			return View(anhSP);
		}

		// POST: Admin/AnhSPs/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(AnhSP anhSP, HttpPostedFileBase fileImage)
		{
			if (fileImage != null && fileImage.ContentLength > 0)
			{
				string FileName = Path.GetFileName(fileImage.FileName);
				string path = Path.Combine(Server.MapPath("/Imgage/"), FileName);
				anhSP.urlimg = path;

			}
			if (ModelState.IsValid)
			{
				db.Entry(anhSP).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.MaA = new SelectList(db.Anhs, "MaA", "MaA", anhSP.Anh.MaA);
			ViewBag.MaSP = new SelectList(db.SanPhams, "MaSP", "MaSP", anhSP.SanPham.MaSP);
			return View(anhSP);
		}

		// GET: Admin/AnhSPs/Delete/5
		public ActionResult Delete(int id)
		{
			if (id == 0)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			AnhSP anhSP = (from item in db.AnhSPs where item.id == id select item).DefaultIfEmpty().First();
			if (anhSP == null)
			{
				return HttpNotFound();
			}
			return View(anhSP);
		}

		// POST: Admin/AnhSPs/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			AnhSP anhSP = (from item in db.AnhSPs where item.id == id select item).DefaultIfEmpty().First();
			db.AnhSPs.Remove(anhSP);
			db.SaveChanges();
			return RedirectToAction("Index");
		}
	}
}

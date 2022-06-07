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



	public class DanhMucsController : Controller
	{
		private MyDBTraSuaContext db = new MyDBTraSuaContext();
		public List<DanhMuc> getlist(string sP = "D")
		{
			List<DanhMuc> ds = null;
			switch (sP)
			{
				case "Y":
					{
						ds = db.DanhMucs.Where(m => m.TenDM.Length != 0).ToList();
						break;
					}
				case "N":
					{
						ds = db.DanhMucs.Where(m => m.TenDM.Length == 0).ToList();
						break;
					}
				default:
					{
						ds = db.DanhMucs.ToList();
						break;
					}
			}
			return ds;
		}
		//ma tin danh muc
		public DanhMuc getRow(string id = null)
		{
			if (id == null)
				return null;
			else
				return db.DanhMucs.Where(m => m.MaDM == id).FirstOrDefault();
		}



		// GET: Admin/DanhMucs
		public ActionResult Index()
		{
			return View(getlist("D"));
		}

		// GET: Admin/DanhMucs/Details/5
		public ActionResult Details(string id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			DanhMuc danhMuc = getRow(id);
			if (danhMuc == null)
			{
				return HttpNotFound();
			}
			return View(danhMuc);
		}

		// GET: Admin/DanhMucs/Create
		public ActionResult Create()
		{
			//tao danh sach chon nua trang thai cua danh muc
			List<string> ListTrangThai = new List<string>() { "Tốt", "Trung Bình", "Khá", "Kém" };
			ViewBag.listTrangThaiDM = new SelectList(ListTrangThai, "TrangThaiSP");
			return View();
		}

		// POST: Admin/DanhMucs/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(DanhMuc danhMuc)
		{
			if (ModelState.IsValid)
			{
				if (danhMuc.MotaDM == null)
				{
					danhMuc.MotaDM = "Null";
					danhMuc.NgayTao = DateTime.Now;
				}
				else
				{
					danhMuc.NgayTao = DateTime.Now;
				}
				db.DanhMucs.Add(danhMuc);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			List<string> ListTrangThai = new List<string>() { "Tốt", "Trung Bình", "Khá", "Kém" };
			ViewBag.listTrangThaiDM = new SelectList(ListTrangThai, "TrangThaiSP");
			return View(danhMuc);
		}

		// GET: Admin/DanhMucs/Edit/5
		public ActionResult Edit(string id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			DanhMuc danhMuc = getRow(id);
			if (danhMuc == null)
			{
				return HttpNotFound();
			}
			List<string> ListTrangThai = new List<string>() { "Tốt", "Trung Bình", "Khá", "Kém" };
			ViewBag.listTrangThaiDM = new SelectList(ListTrangThai, "TrangThaiSP");
			return View(danhMuc);
		}

		// POST: Admin/DanhMucs/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(DanhMuc danhMuc)
		{
			if (ModelState.IsValid)
			{
				danhMuc.NgayTao = DateTime.Now;
				db.Entry(danhMuc).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			List<string> ListTrangThai = new List<string>() { "Tốt", "Trung Bình", "Khá", "Kém" };
			ViewBag.listTrangThaiDM = new SelectList(ListTrangThai, "TrangThaiSP");
			return View(danhMuc);
		}

		// GET: Admin/DanhMucs/Delete/5
		public ActionResult Delete(string id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			DanhMuc danhMuc = (from item in db.DanhMucs where item.MaDM == id select item).FirstOrDefault();
			if (danhMuc == null)
			{
				return HttpNotFound();
			}
			return View(danhMuc);
		}

		// POST: Admin/DanhMucs/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(string id)
		{

			DanhMuc danhMuc = (from item in db.DanhMucs where item.MaDM == id select item).FirstOrDefault();
			db.DanhMucs.Remove(danhMuc);
			db.SaveChanges();
			return RedirectToAction("Index");
			
		}
	}
}

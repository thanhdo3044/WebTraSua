using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebTraSua.Models;
using WebTraSua.DAO;
using WebTraSua.Library;

namespace WebTraSua.Areas.Admin.Controllers
{
	public class SanPhamsController : Controller
	{
		private MyDBTraSuaContext db = new MyDBTraSuaContext();

		SanPhamDAO sanPhamDAO = new SanPhamDAO();
		// GET: Admin/SanPhams
		public ActionResult Index()
		{
			return View(sanPhamDAO.getlist("Yes"));
		}

		// GET: Admin/SanPhams/Details/5
		public ActionResult Details(string id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			SanPham sanPham = sanPhamDAO.getRow(id);
			if (sanPham == null)
			{
				return HttpNotFound();
			}
			return View(sanPham);
		}

		// GET: Admin/SanPhams/Create
		public ActionResult Create()
		{
			ViewBag.MaDM = new SelectList(db.DanhMucs, "MaDM", "MaDM");
			List<string> ListTrangThai = new List<string>() { "Tốt", "Trung Bình", "Khá", "Yếu" };
			ViewBag.listTrangThaiSP = new SelectList(ListTrangThai, "TrangThaiSP");
			return View();
		}

		// POST: Admin/SanPhams/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(SanPham sanPham)
		{
			if (ModelState.IsValid)
			{
				//Xử lý thêm thông tin
				if (sanPham.MotaSP == null)
				{
					sanPham.MotaSP = "khong co";
					sanPham.NgayNhap = DateTime.Now;
					sanPham.ChiTietSP = XString.Str_Slug(sanPham.MaDM) + "_" +
										XString.Str_Slug(sanPham.MaSP) + "_" +
										XString.Str_Slug(sanPham.TenSP) + "_" +
										sanPham.GiaBanSP + "_" +
										XString.Str_Slug(sanPham.MotaSP) + "_" +
										sanPham.NgayNhap;
				}
				else
				{
					sanPham.NgayNhap = DateTime.Now;
					sanPham.ChiTietSP = XString.Str_Slug(sanPham.MaDM) + "_" +
										XString.Str_Slug(sanPham.MaSP) + "_" +
										XString.Str_Slug(sanPham.TenSP) + "_" +
										sanPham.GiaBanSP + "_" +
										XString.Str_Slug(sanPham.MotaSP) + "_" +
										sanPham.NgayNhap;
				}
				db.SanPhams.Add(sanPham);
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.MaDM = new SelectList(db.DanhMucs, "MaDM", "MaDM");
			List<string> ListTrangThai = new List<string>() { "Tốt", "Trung Bình", "Khá", "Yếu" };
			ViewBag.listTrangThaiSP = new SelectList(ListTrangThai, "TrangThaiSP");
			return View(sanPham);
		}

		// GET: Admin/SanPhams/Edit/5
		public ActionResult Edit(string id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			SanPham sanPham = sanPhamDAO.getRow(id);
			if (sanPham == null)
			{
				return HttpNotFound();
			}
			ViewBag.MaDM = new SelectList(db.DanhMucs, "MaDM", "TenDM");
			ViewBag.MaDM = new SelectList(db.DanhMucs, "MaDM", "MaDM");
			List<string> ListTrangThai = new List<string>() { "Tốt", "Trung Bình", "Khá", "Yếu" };
			ViewBag.listTrangThaiSP = new SelectList(ListTrangThai, "TrangThaiSP");
			return View(sanPham);
		}

		// POST: Admin/SanPhams/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to, for 
		// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(SanPham sanPham)
		{
			if (ModelState.IsValid)
			{
				db.Entry(sanPham).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.MaDM = new SelectList(db.DanhMucs, "MaDM", "MaDM");
			List<string> ListTrangThai = new List<string>() { "Tốt", "Trung Bình", "Khá", "Yếu" };
			ViewBag.listTrangThaiSP = new SelectList(ListTrangThai, "TrangThaiSP");
			return View(sanPham);
		}

		// GET: Admin/SanPhams/Delete/5
		public ActionResult Delete(string id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			SanPham sanPham = db.SanPhams.Find(id);
			if (sanPham == null)
			{
				return HttpNotFound();
			}
			return View(sanPham);
		}

		// POST: Admin/SanPhams/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(string id)
		{
			SanPham sanPham = db.SanPhams.Find(id);
			db.SanPhams.Remove(sanPham);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

	}
}

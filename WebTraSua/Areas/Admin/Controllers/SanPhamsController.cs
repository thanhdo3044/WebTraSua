using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebTraSua.Models;
using WebTraSua.Library;
using System.Globalization;
using WebTraSua.VewModels;


namespace WebTraSua.Areas.Admin.Controllers
{
	public class SanPhamsController : Controller
	{
		private MyDBTraSuaContext db = new MyDBTraSuaContext();


		public List<SanPhamVew> getlist()
		{

			List<SanPhamVew> ds = new List<SanPhamVew>();
			var ht = (from aSP in db.AnhSPs
					join maSP in db.SanPhams
					on aSP.MaSP equals maSP.MaSP
					select new
					{
						MaSP = maSP.MaSP,
						MaDM = maSP.MaDM,
						MaA = aSP.MaA,
						urlASP = aSP.urlimg,
						TenSP = maSP.TenSP,
						Mota = maSP.MotaSP,
						Gia = maSP.GiaBanSP,
						TrangThai = maSP.TrangThaiSP,
						NgayNhap = maSP.NgayNhap
					}).ToList();
			foreach(var item in ht)
			{
				SanPhamVew spv = new SanPhamVew();
				spv.MaSP = item.MaSP;
				spv.MaDM = item.MaDM;
				spv.MaA = item.MaA;
				spv.urlASP = item.urlASP;
				spv.TenSP = item.TenSP;
				spv.MotaSP = item.Mota;
				spv.GiaBanSP = item.Gia;
				spv.TrangThaiSP = item.TrangThai;
				spv.NgayNhap = item.NgayNhap;
				ds.Add(spv);
			}

			return ds;
		}
		//ma tin sp
		public SanPham getRow(string id = null)
		{
			if (id == null)
				return null;
			else
				return db.SanPhams.Where(m => m.MaSP == id).FirstOrDefault();
		}
		

		// GET: Admin/SanPhams
		public ActionResult Index()
		{
			var sanPham = db.SanPhams.ToList();
			return View(sanPham);
		}

		// GET: Admin/SanPhams/Details/5
		public ActionResult Details(string id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			SanPham sanPham = getRow(id);
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
				// NGAY THANG
				if (sanPham.NgayNhap == null)
				{
					sanPham.NgayNhap = DateTime.Now;
				}
				//Xử lý thêm thông tin
				if (sanPham.MotaSP == null)
				{
					sanPham.MotaSP = "Null";
					sanPham.ChiTietSP = XString.Str_Slug(sanPham.MaDM) + "_" +
										XString.Str_Slug(sanPham.MaSP) + "_" +
										XString.Str_Slug(sanPham.TenSP) + "_" +
										sanPham.GiaBanSP + "_" +
										XString.Str_Slug(sanPham.MotaSP) + "_" +
										sanPham.NgayNhap;
				}
				else
				{
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
			List<string> ListTrangThai = new List<string>() { "Tốt", "Trung Bình", "Khá", "Kém" };
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
			SanPham sanPham = getRow(id);
			if (sanPham == null)
			{
				return HttpNotFound();
			}
			ViewBag.MaDM = new SelectList(db.DanhMucs, "MaDM", "TenDM");
			ViewBag.MaDM = new SelectList(db.DanhMucs, "MaDM", "MaDM");
			List<string> ListTrangThai = new List<string>() { "Tốt", "Trung Bình", "Khá", "Kém" };
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

				//Xử lý thêm thông tin
				if (sanPham.MotaSP == null)
				{
					sanPham.MotaSP = "Null";
					sanPham.ChiTietSP = XString.Str_Slug(sanPham.MaDM) + "_" +
										XString.Str_Slug(sanPham.MaSP) + "_" +
										XString.Str_Slug(sanPham.TenSP) + "_" +
										sanPham.GiaBanSP + "_" +
										XString.Str_Slug(sanPham.MotaSP) + "_" +
										sanPham.NgayNhap;
				}
				else
				{
					sanPham.ChiTietSP = XString.Str_Slug(sanPham.MaDM) + "_" +
										XString.Str_Slug(sanPham.MaSP) + "_" +
										XString.Str_Slug(sanPham.TenSP) + "_" +
										sanPham.GiaBanSP + "_" +
										XString.Str_Slug(sanPham.MotaSP) + "_" +
										sanPham.NgayNhap;
				}

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
			SanPham sanPham = db.SanPhams.Select(m => m).Where(m => m.MaSP == id).FirstOrDefault();
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
			SanPham sanPham = (from item in db.SanPhams where item.MaSP == id select item).FirstOrDefault();
			db.SanPhams.Remove(sanPham);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		public ActionResult AnhSP(string id)
		{
			var anhSP = db.AnhSPs.Where(m => m.MaSP == id).ToList();
			return View(anhSP);
		}

	}
}
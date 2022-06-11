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
using WebTraSua.Areas.Admin;

namespace WebTraSua.Controllers
{
    public class HomeController : Controller
    {
        MyDBTraSuaContext db = new MyDBTraSuaContext();
        // GET: Home
        public ActionResult TrangChu()
        {
            return View();
        }
		public ActionResult SanPham()
        {
            return View();
        }
        public ActionResult GioiThieu()
        {
            return View();
        }
        public ActionResult TinTuc()
        {
            return View();
        }
        public ActionResult LienHe()
        {
            return View();
        }
        public ActionResult MuaHang()
        {
            return View();
        }
    }
}
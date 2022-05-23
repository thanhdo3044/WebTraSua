using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebTraSua.Models;

namespace WebTraSua.DAO
{
	public class SanPhamDAO
	{
		private MyDBTraSuaContext db = new MyDBTraSuaContext();
		//danhs san pham
		public List<SanPham> getlist(string sP ="Yes")
		{
			List<SanPham> ds = null;
			switch (sP)
			{
				case "Index":
					{
						ds = db.SanPhams.Where(m => m.TenSP.Length != 0).ToList();
						break;
					}
				case "Trash":
					{
						ds = db.SanPhams.Where(m => m.TenSP.Length == 0).ToList();
						break;
					}
				default:
					{
						ds = db.SanPhams.ToList();
						break;
					}
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
		
	}
}
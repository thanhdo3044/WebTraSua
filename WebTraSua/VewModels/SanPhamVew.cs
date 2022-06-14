using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebTraSua.Models;

namespace WebTraSua.VewModels
{
	public class SanPhamVew
	{
		public string MaA { set; get; }
		public string urlASP { set; get; }
		public string MaSP { get; set; }
		public string MaDM { get; set; }
		public string TenSP { get; set; }
		public string MotaSP { get; set; }
		public int? GiaBanSP { get; set; }
		public string ChiTietSP { get; set; }
		public string TrangThaiSP { get; set; }
		public DateTime? NgayNhap { get; set; }
	}
}
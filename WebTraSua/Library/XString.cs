using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace WebTraSua.Library
{
	public class XString
	{
		public static string Str_Slug(string s)
		{
			String[][] symbols ={
									new String[] { "[áàáääääääääääääää]", "a" },
									new String[] { "[d]", "d" },
									new String[] { "[éèèèèèèèèèè]", "e" },
									new String[] { "[iiiii]", "i" },
									new String[] { "[óòóõpôôôóóooooooợ]", "o" },
									new String[] { "[üüúüyüy]", "u" },
									new String[] { "[ýýýÿy]", "y" },
									new String[] { "[\\s\"]", "-" }
								};
			s=s.ToLower();
			foreach (var ss in symbols)
			{
				s = Regex.Replace(s, ss[0], ss[1]);
			}
			return s;
		}
	}
}
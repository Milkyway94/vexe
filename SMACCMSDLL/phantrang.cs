using SMAC;
using System;

public class phantrang
{
	public string pagelink(int tongsotrang, int pagecurrent, string pagelinkfull)
	{
		if (pagelinkfull.Contains("&page="))
		{
			string[] separator = new string[]
			{
				"&"
			};
			string[] array = pagelinkfull.Split(separator, StringSplitOptions.RemoveEmptyEntries);
			pagelinkfull = "";
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string text = array2[i];
				if (!text.Contains("page="))
				{
					pagelinkfull = pagelinkfull + text + "&";
				}
			}
			if (pagelinkfull != "")
			{
				pagelinkfull = pagelinkfull.Substring(0, pagelinkfull.Length - 1);
			}
		}
		string text2 = "<ul class=\"pagination\">";
		if (pagecurrent <= 1)
		{
			text2 += "<li class=\"first_end\"><a title=\"Trang đầu\">«</a></li><li class=\"first2_end\"><a title=\"Trang trước\">‹</a></li>";
		}
		else
		{
			string text3 = text2;
			text2 = string.Concat(new string[]
			{
				text3,
				"<li class=\"first\"><a title=\"Trang đầu\" href=\"",
				pagelinkfull,
				"\">«</a></li><li class=\"first2\"><a title=\"Trang trước\" href=\"",
				pagelinkfull,
				"&page=",
				(pagecurrent - 1).ToString(),
				"\">‹</a></li>"
			});
		}
		if (tongsotrang <= 5)
		{
			for (int j = 1; j <= tongsotrang; j++)
			{
				if (j == pagecurrent)
				{
					text2 = text2 + "<li class=\"act\"><a>" + j.ToString() + "</a></li>";
				}
				else
				{
					string text3 = text2;
					text2 = string.Concat(new string[]
					{
						text3,
						"<li><a href=\"",
						pagelinkfull,
						"&page=",
						j.ToString(),
						"\">",
						j.ToString(),
						"</a></li>"
					});
				}
			}
		}
		else if (pagecurrent < tongsotrang - 2)
		{
			int num = pagecurrent - 2;
			if (num < 1)
			{
			}
			for (int j = 1; j <= pagecurrent + 2; j++)
			{
				if (j == pagecurrent)
				{
					text2 = text2 + "<li class=\"act\"><a>" + j.ToString() + "</a></li>";
				}
				else
				{
					string text3 = text2;
					text2 = string.Concat(new string[]
					{
						text3,
						"<li><a href=\"",
						pagelinkfull,
						"&page=",
						j.ToString(),
						"\">",
						j.ToString(),
						"</a></li>"
					});
				}
			}
		}
		else
		{
			for (int j = tongsotrang - 5; j <= tongsotrang; j++)
			{
				if (j == pagecurrent)
				{
					text2 = text2 + "<li class=\"act\"><a>" + j.ToString() + "</a></li>";
				}
				else
				{
					string text3 = text2;
					text2 = string.Concat(new string[]
					{
						text3,
						"<li><a href=\"",
						pagelinkfull,
						"&page=",
						j.ToString(),
						"\">",
						j.ToString(),
						"</a></li>"
					});
				}
			}
		}
		if (pagecurrent == tongsotrang)
		{
			text2 += "<li class=\"end_end\"><a title=\"Trang sau\">›</a></li><li class=\"end2_end\"><a title=\"Trang cuối\">»</a></li>";
		}
		else
		{
			string text3 = text2;
			text2 = string.Concat(new string[]
			{
				text3,
				"<li class=\"end\"><a title=\"Trang sau\" href=\"",
				pagelinkfull,
				"&page=",
				(pagecurrent + 1).ToString(),
				"\">›</a></li><li class=\"end2\"><a title=\"Trang cuối\" href=\"",
				pagelinkfull,
				"&page=",
				tongsotrang.ToString(),
				"\">»</a></li>"
			});
		}
		return text2 + "</ul>";
	}

	public string pagelinkNews0(int tongsotrang, int pagecurrent, string pagelinkfull)
	{
		if (pagelinkfull.Contains("&page="))
		{
			string[] separator = new string[]
			{
				"&"
			};
			string[] array = pagelinkfull.Split(separator, StringSplitOptions.RemoveEmptyEntries);
			pagelinkfull = "";
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string text = array2[i];
				if (!text.Contains("page="))
				{
					pagelinkfull = pagelinkfull + text + "&";
				}
			}
			if (pagelinkfull != "")
			{
				pagelinkfull = pagelinkfull.Substring(0, pagelinkfull.Length - 1);
			}
		}
		if (pagelinkfull.Contains("?page="))
		{
			string[] separator = new string[]
			{
				"?"
			};
			string[] array = pagelinkfull.Split(separator, StringSplitOptions.RemoveEmptyEntries);
			pagelinkfull = "";
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string text = array2[i];
				if (!text.Contains("page="))
				{
					pagelinkfull = pagelinkfull + text + "?";
				}
			}
			if (pagelinkfull != "")
			{
				pagelinkfull = pagelinkfull.Substring(0, pagelinkfull.Length - 1);
			}
		}
		string str = pagelinkfull.Contains("?") ? "&page=" : "?page=";
		pagelinkfull += str;
		string text2 = "<ul class=\"phantrang0 clearfix\">";
		string text3 = CMSfunc._Title("First");
		string text4 = CMSfunc._Title("Preview");
		string text5 = CMSfunc._Title("Next");
		string text6 = CMSfunc._Title("Last");
		if (pagecurrent <= 1)
		{
			string text7 = text2;
			text2 = string.Concat(new string[]
			{
				text7,
				"<li class=\"first_end\"><a title=\"",
				text3,
				"\">",
				text3,
				"</a></li><li class=\"first2_end\"><a title=\"",
				text4,
				"\">‹</a></li>"
			});
		}
		else
		{
			string text7 = text2;
			text2 = string.Concat(new string[]
			{
				text7,
				"<li class=\"first\"><a title=\"",
				text3,
				"\" href=\"",
				pagelinkfull,
				"\">",
				text3,
				"</a></li><li class=\"first2\"><a title=\"",
				text4,
				"\" href=\"",
				pagelinkfull,
				(pagecurrent - 1).ToString(),
				"\">‹</a></li>"
			});
		}
		if (tongsotrang <= 5)
		{
			for (int j = 1; j <= tongsotrang; j++)
			{
				if (j == pagecurrent)
				{
					text2 = text2 + "<li class=\"act\"><a>" + j.ToString() + "</a></li>";
				}
				else
				{
					string text7 = text2;
					text2 = string.Concat(new string[]
					{
						text7,
						"<li><a href=\"",
						pagelinkfull,
						j.ToString(),
						"\">",
						j.ToString(),
						"</a></li>"
					});
				}
			}
		}
		else if (pagecurrent < tongsotrang - 2)
		{
			int num = pagecurrent - 2;
			if (num < 1)
			{
				num = 1;
			}
			for (int j = num; j <= pagecurrent + 2; j++)
			{
				if (j == pagecurrent)
				{
					text2 = text2 + "<li class=\"act\"><a>" + j.ToString() + "</a></li>";
				}
				else
				{
					string text7 = text2;
					text2 = string.Concat(new string[]
					{
						text7,
						"<li><a href=\"",
						pagelinkfull,
						j.ToString(),
						"\">",
						j.ToString(),
						"</a></li>"
					});
				}
			}
		}
		else
		{
			for (int j = tongsotrang - 5; j <= tongsotrang; j++)
			{
				if (j == pagecurrent)
				{
					text2 = text2 + "<li class=\"act\"><a>" + j.ToString() + "</a></li>";
				}
				else
				{
					string text7 = text2;
					text2 = string.Concat(new string[]
					{
						text7,
						"<li><a href=\"",
						pagelinkfull,
						j.ToString(),
						"\">",
						j.ToString(),
						"</a></li>"
					});
				}
			}
		}
		if (pagecurrent == tongsotrang)
		{
			string text7 = text2;
			text2 = string.Concat(new string[]
			{
				text7,
				"<li class=\"end_end\"><a title=\"",
				text5,
				"\">›</a></li><li class=\"end2_end\"><a title=\"",
				text6,
				"\">",
				text6,
				"</a></li>"
			});
		}
		else
		{
			string text7 = text2;
			text2 = string.Concat(new string[]
			{
				text7,
				"<li class=\"end\"><a title=\"",
				text5,
				"\" href=\"",
				pagelinkfull,
				(pagecurrent + 1).ToString(),
				"\">›</a></li><li class=\"end2\"><a title=\"",
				text6,
				"\" href=\"",
				pagelinkfull,
				tongsotrang.ToString(),
				"\">",
				text6,
				"</a></li>"
			});
		}
		return text2 + "</ul>";
	}

	public string pagelinkNews(int tongsotrang, int pagecurrent, string pagelinkfull)
	{
		if (pagelinkfull.Contains("/page/"))
		{
			pagelinkfull = pagelinkfull.Substring(0, pagelinkfull.LastIndexOf("page/"));
		}
		string text = "<ul class=\"pagination\">";
		string text2 = CMSfunc._Title("First");
		string text3 = CMSfunc._Title("Preview");
		string text4 = CMSfunc._Title("Next");
		string text5 = CMSfunc._Title("Last");
		if (pagecurrent <= 1)
		{
			string text6 = text;
			text = string.Concat(new string[]
			{
				text6,
				"<li><a title=\"",
				text2,
				"\">",
				text2,
				"</a></li><li class=\"first2_end\"><a title=\"",
				text3,
				"\">‹</a></li>"
			});
		}
		else
		{
			string text6 = text;
			text = string.Concat(new string[]
			{
				text6,
				"<li><a title=\"",
				text2,
				"\" href=\"",
				pagelinkfull,
				"\">",
				text2,
				"</a></li><li class=\"first2\"><a title=\"",
				text3,
				"\" href=\"",
				pagelinkfull,
				"page/",
				(pagecurrent - 1).ToString(),
				"/\">‹</a></li>"
			});
		}
		if (tongsotrang <= 5)
		{
			for (int i = 1; i <= tongsotrang; i++)
			{
				string text7 = (i == 1) ? pagelinkfull : string.Concat(new object[]
				{
					pagelinkfull,
					"page/",
					i,
					"/"
				});
				if (i == pagecurrent)
				{
					object obj = text;
					text = string.Concat(new object[]
					{
						obj,
						"<li><a>",
						i,
						"</a></li>"
					});
				}
				else
				{
					object obj = text;
					text = string.Concat(new object[]
					{
						obj,
						"<li><a href=\"",
						text7,
						"\">",
						i,
						"</a></li>"
					});
				}
			}
		}
		else if (pagecurrent < tongsotrang - 2)
		{
			int num = pagecurrent - 2;
			if (num < 1)
			{
				num = 1;
			}
			for (int i = num; i <= pagecurrent + 2; i++)
			{
				string text7 = (i == 1) ? pagelinkfull : string.Concat(new object[]
				{
					pagelinkfull,
					"page/",
					i,
					"/"
				});
				if (i == pagecurrent)
				{
					text = text + "<li><a>" + i.ToString() + "</a></li>";
				}
				else
				{
					object obj = text;
					text = string.Concat(new object[]
					{
						obj,
						"<li><a href=\"",
						text7,
						"\">",
						i,
						"</a></li>"
					});
				}
			}
		}
		else
		{
			for (int i = tongsotrang - 5; i <= tongsotrang; i++)
			{
				string text7 = (i == 1) ? pagelinkfull : string.Concat(new object[]
				{
					pagelinkfull,
					"page/",
					i,
					"/"
				});
				if (i == pagecurrent)
				{
					text = text + "<li><a>" + i.ToString() + "</a></li>";
				}
				else
				{
					string text6 = text;
					text = string.Concat(new string[]
					{
						text6,
						"<li><a href=\"",
						text7,
						"\">",
						i.ToString(),
						"</a></li>"
					});
				}
			}
		}
		if (pagecurrent == tongsotrang)
		{
			string text6 = text;
			text = string.Concat(new string[]
			{
				text6,
				"<li><a title=\"",
				text4,
				"\">›</a></li><li><a title=\"",
				text5,
				"\">",
				text5,
				"</a></li>"
			});
		}
		else
		{
			string text6 = text;
			text = string.Concat(new string[]
			{
				text6,
				"<li><a title=\"",
				text4,
				"\" href=\"",
				pagelinkfull,
				"page/",
				(pagecurrent + 1).ToString(),
				"/\">›</a></li><li class=\"end2\"><a title=\"",
				text5,
				"\" href=\"",
				pagelinkfull,
				"page/",
				tongsotrang.ToString(),
				"/\">",
				text5,
				"</a></li>"
			});
		}
		return text + "</ul>";
	}
}

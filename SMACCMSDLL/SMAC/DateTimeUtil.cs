using System;

namespace SMAC
{
	public class DateTimeUtil
	{
		public enum DateInterval
		{
			Year,
			Month,
			Weekday,
			Day,
			Hour,
			Minute,
			Second
		}

		public enum DayType
		{
			Short = 1,
			Normal,
			Long
		}

		public static long DateDiff(DateTimeUtil.DateInterval interval, DateTime date1, DateTime date2)
		{
			TimeSpan timeSpan = date2 - date1;
			long result;
			switch (interval)
			{
			case DateTimeUtil.DateInterval.Year:
				result = (long)(date2.Year - date1.Year);
				break;
			case DateTimeUtil.DateInterval.Month:
				result = (long)(date2.Month - date1.Month + 12 * (date2.Year - date1.Year));
				break;
			case DateTimeUtil.DateInterval.Weekday:
				result = DateTimeUtil.Fix(timeSpan.TotalDays) / 7L;
				break;
			case DateTimeUtil.DateInterval.Day:
				result = DateTimeUtil.Fix(timeSpan.TotalDays);
				break;
			case DateTimeUtil.DateInterval.Hour:
				result = DateTimeUtil.Fix(timeSpan.TotalHours);
				break;
			case DateTimeUtil.DateInterval.Minute:
				result = DateTimeUtil.Fix(timeSpan.TotalMinutes);
				break;
			default:
				result = DateTimeUtil.Fix(timeSpan.TotalSeconds);
				break;
			}
			return result;
		}

		private static long Fix(double Number)
		{
			long result;
			if (Number >= 0.0)
			{
				result = (long)Math.Floor(Number);
			}
			else
			{
				result = (long)Math.Ceiling(Number);
			}
			return result;
		}

		public static string ConvertToVietDate(DateTime time, DateTimeUtil.DayType Type)
		{
			string text = string.Empty;
			text += time.Day.ToString("00");
			text = text + "/" + time.Month.ToString("00");
			if (Type != DateTimeUtil.DayType.Short)
			{
				text = text + "/" + time.Year.ToString("0000");
			}
			if (Type == DateTimeUtil.DayType.Long)
			{
				text = text + ", " + time.Hour.ToString("00");
				text = text + ":" + time.Minute.ToString("00");
			}
			return text;
		}

		public static string DateFormat(string strFormat, DateTime dt)
		{
			return string.Format(strFormat, dt.Day, dt.Month, dt.Year);
		}

		public static string ConvertToUSDate(DateTime time, DateTimeUtil.DayType Type)
		{
			string text = string.Empty;
			text += time.Month.ToString("00");
			text = text + "/" + time.Day.ToString("00");
			if (Type != DateTimeUtil.DayType.Short)
			{
				text = text + "/" + time.Year.ToString("0000");
			}
			if (Type == DateTimeUtil.DayType.Long)
			{
				text = text + ", " + time.Hour.ToString("00");
				text = text + ":" + time.Minute.ToString("00");
			}
			return text;
		}

		public static string GetCurrentVietDateDetail()
		{
			string text = "";
			DateTime now = DateTime.Now;
			switch (now.DayOfWeek)
			{
			case DayOfWeek.Sunday:
				text = "Chủ nhật";
				break;
			case DayOfWeek.Monday:
				text = "Thứ hai";
				break;
			case DayOfWeek.Tuesday:
				text = "Thứ ba";
				break;
			case DayOfWeek.Wednesday:
				text = "Thứ tư";
				break;
			case DayOfWeek.Thursday:
				text = "Thứ năm";
				break;
			case DayOfWeek.Friday:
				text = "Thứ sáu";
				break;
			case DayOfWeek.Saturday:
				text = "Thứ bẩy";
				break;
			}
			string text2 = text;
			return string.Concat(new string[]
			{
				text2,
				", ",
				now.Day.ToString(),
				"/",
				now.Month.ToString(),
				"/",
				now.Year.ToString()
			});
		}

		public static string GetDayOfWeek()
		{
			string result = "";
			switch (DateTime.Now.DayOfWeek)
			{
			case DayOfWeek.Sunday:
				result = "Chủ nhật";
				break;
			case DayOfWeek.Monday:
				result = "Thứ hai";
				break;
			case DayOfWeek.Tuesday:
				result = "Thứ ba";
				break;
			case DayOfWeek.Wednesday:
				result = "Thứ tư";
				break;
			case DayOfWeek.Thursday:
				result = "Thứ năm";
				break;
			case DayOfWeek.Friday:
				result = "Thứ sáu";
				break;
			case DayOfWeek.Saturday:
				result = "Thứ bảy";
				break;
			}
			return result;
		}

		public static string GetDayOfWeekEn()
		{
			string result = "";
			switch (DateTime.Now.DayOfWeek)
			{
			case DayOfWeek.Sunday:
				result = "Sunday";
				break;
			case DayOfWeek.Monday:
				result = "Monday";
				break;
			case DayOfWeek.Tuesday:
				result = "Tuesday";
				break;
			case DayOfWeek.Wednesday:
				result = "Wednesday";
				break;
			case DayOfWeek.Thursday:
				result = "Thursday";
				break;
			case DayOfWeek.Friday:
				result = "Friday";
				break;
			case DayOfWeek.Saturday:
				result = "Saturday";
				break;
			}
			return result;
		}
	}
}

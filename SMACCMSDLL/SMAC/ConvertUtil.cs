using System;
using System.Text.RegularExpressions;

namespace SMAC
{
	public class ConvertUtil
	{
		public static string Nullcheck(object var1, string var2)
		{
			string result;
			if (var1 == null)
			{
				result = var2;
			}
			else if (var1.ToString().Trim() == "")
			{
				result = var2;
			}
			else
			{
				result = var1.ToString().Trim();
			}
			return result;
		}

		public static string CutString(string str, int sLength)
		{
			string result;
			if (str.Length >= sLength)
			{
				for (int i = sLength - 6; i < sLength; i++)
				{
					if (str[i].ToString().EndsWith(" "))
					{
						str = str.Substring(0, i) + "...";
						break;
					}
				}
				result = str;
			}
			else
			{
				result = str;
			}
			return result;
		}

		public static string ConvertLargeNumber(string number)
		{
			string result;
			if (number.Length >= 3)
			{
				int num = number.Length % 3;
				string text = "";
				if (num == 0)
				{
					for (int i = 0; i <= number.Length - 1; i++)
					{
						text += number[i];
						if ((i + 1) % 3 == 0 && i != 0 && i < number.Length - 1)
						{
							text += ".";
						}
					}
				}
				if (num == 1)
				{
					for (int j = 0; j < num; j++)
					{
						text += number[j];
					}
					text += ".";
					for (int i = num; i <= number.Length - 1; i++)
					{
						text += number[i];
						if (i % 3 == 0 && i < number.Length - 1)
						{
							text += ".";
						}
					}
				}
				if (num == 2)
				{
					for (int j = 0; j < num; j++)
					{
						text += number[j];
					}
					text += ".";
					for (int i = num; i <= number.Length - 1; i++)
					{
						text += number[i];
						if ((i - 1) % 3 == 0 && i < number.Length - 1)
						{
							text += ".";
						}
					}
				}
				result = text;
			}
			else
			{
				result = number;
			}
			return result;
		}

		public static int ReplaceInt(string input)
		{
			int result;
			if (input == null || input.Length == 0)
			{
				result = 0;
			}
			else
			{
				string text = Regex.Replace(input, "[AĂÂBCDĐEÊGHIKLMNOÔƠPQRSTUƯVXYFJW]", string.Empty);
				text = Regex.Replace(text, "[aăâbcdđeêghiklmnoôơpqrstuưvxyfjw]", string.Empty);
				text = Regex.Replace(text, "[`~!@#$%^&*()_+=|/{}'?<>,.:;@” ]", string.Empty);
				text = text.Replace("-", string.Empty).Replace("[", string.Empty).Replace("]", string.Empty);
				if (text == null || text.Length == 0)
				{
					result = 0;
				}
				else
				{
					result = Convert.ToInt32(text);
				}
			}
			return result;
		}
	}
}

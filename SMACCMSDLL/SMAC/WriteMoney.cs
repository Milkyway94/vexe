using System;

namespace SMAC
{
	public class WriteMoney
	{
		public string Read(string number)
		{
			WriteMoney writeMoney = new WriteMoney();
			string result = "";
			int length = number.Length;
			if (length == 4)
			{
				if (number.Substring(1, 3) == "000")
				{
					result = this.Read1(number[0]) + " nghìn đồng";
				}
				else
				{
					string number2 = number.Substring(1, 3);
					result = this.Read1(number[0]) + " nghìn " + this.Read3(number2) + " đồng";
				}
			}
			if (length == 5)
			{
				string number3 = number.Substring(0, 2);
				if (number.Substring(2, 3) == "000")
				{
					result = this.Read2(number3) + " nghìn đồng";
				}
				else
				{
					string number4 = number.Substring(2, 3);
					result = this.Read2(number3) + " nghìn " + this.Read3(number4) + " đồng";
				}
			}
			if (length == 6)
			{
				string number3 = number.Substring(0, 3);
				if (number.Substring(1, 5) == "00000")
				{
					result = this.Read3(number3) + " nghìn đồng";
				}
				else
				{
					string number4 = number.Substring(3, 3);
					result = this.Read3(number3) + " nghìn " + this.Read3(number4) + " đồng";
				}
			}
			if (length == 7)
			{
				if (number.Substring(1, 6) == "000000")
				{
					result = this.Read1(number[0]) + " triệu đồng";
				}
				else
				{
					string number3 = number.Substring(1, 3);
					string number4 = number.Substring(4, 3);
					result = string.Concat(new string[]
					{
						this.Read1(number[0]),
						" triệu ",
						this.Read3(number3),
						" nghìn ",
						this.Read3(number4),
						" đồng"
					});
				}
			}
			if (length == 8)
			{
				string number3 = number.Substring(0, 2);
				if (number.Substring(1, 7) == "0000000")
				{
					result = this.Read2(number3) + " triệu đồng";
				}
				else
				{
					string number4 = number.Substring(2, 3);
					string number5 = number.Substring(5, 3);
					result = string.Concat(new string[]
					{
						this.Read2(number3),
						" triệu ",
						this.Read3(number4),
						" nghìn ",
						this.Read3(number5),
						" đồng"
					});
				}
			}
			if (length == 9)
			{
				string number3 = number.Substring(0, 3);
				if (number.Substring(1, 7) == "0000000")
				{
					result = this.Read3(number3) + " triệu đồng";
				}
				else
				{
					string number4 = number.Substring(3, 3);
					string number5 = number.Substring(6, 3);
					result = string.Concat(new string[]
					{
						this.Read3(number3),
						" triệu ",
						this.Read3(number4),
						" nghìn ",
						this.Read3(number5),
						" đồng"
					});
				}
			}
			if (length == 10)
			{
				if (number.Substring(1, 7) == "000000000")
				{
					result = this.Read1(number[0]) + " tỷ";
				}
				else
				{
					string number3 = number.Substring(1, 3);
					string number4 = number.Substring(4, 3);
					string number5 = number.Substring(7, 3);
					result = string.Concat(new string[]
					{
						this.Read1(number[0]),
						" tỷ ",
						this.Read3(number3),
						" triệu ",
						this.Read3(number4),
						" nghìn ",
						this.Read3(number5),
						" đồng"
					});
				}
			}
			return result;
		}

		public string Read1(char number)
		{
			string result = "";
			switch (number)
			{
			case '0':
				result = "không";
				break;
			case '1':
				result = "một";
				break;
			case '2':
				result = "hai";
				break;
			case '3':
				result = "ba";
				break;
			case '4':
				result = "bốn";
				break;
			case '5':
				result = "năm";
				break;
			case '6':
				result = "sáu";
				break;
			case '7':
				result = "bảy";
				break;
			case '8':
				result = "tám";
				break;
			case '9':
				result = "chín";
				break;
			}
			return result;
		}

		public string Read2(string number)
		{
			string result;
			if (number[0] == '1' & number[1] == '0')
			{
				result = "mười";
			}
			else if (number[0] != '0' & number[0] != '1' & number[1] == '0')
			{
				result = this.Read1(number[0]) + " mươi";
			}
			else if (number[0] == '1' & number[1] != '0')
			{
				result = "mười " + this.Read1(number[1]);
			}
			else
			{
				result = this.Read1(number[0]) + " " + this.Read1(number[1]);
			}
			return result;
		}

		public string Read3(string number)
		{
			string number2 = number.Substring(1, 2);
			string result;
			if (number[1] != '0' & number[2] != '0')
			{
				result = this.Read1(number[0]) + " trăm " + this.Read2(number.Substring(1, 2));
			}
			else if (number.Substring(0, 3) == "000")
			{
				result = " ";
			}
			else if (number.Substring(1, 2) == "00")
			{
				result = this.Read1(number[0]) + " trăm ";
			}
			else if (number[1] == '0' & number[2] != '0')
			{
				result = this.Read1(number[0]) + " trăm lẻ " + this.Read1(number[2]);
			}
			else
			{
				result = this.Read1(number[0]) + " trăm " + this.Read2(number2);
			}
			return result;
		}
	}
}

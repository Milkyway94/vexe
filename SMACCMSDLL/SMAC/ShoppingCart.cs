using System;
using System.Collections;

namespace SMAC
{
	public class ShoppingCart
	{
		private Hashtable cartItems = new Hashtable();

		public void AddItem(string itemID, string itemName, string itemImage, double itemPrice, int itemQty)
		{
			string[] value = new string[]
			{
				itemID,
				itemName,
				itemImage,
				itemPrice.ToString(),
				itemQty.ToString()
			};
			if (this.cartItems.ContainsKey(itemID))
			{
				string[] array = (string[])this.cartItems[itemID];
				int num = Convert.ToInt32(array[4]);
				itemQty += num;
				array[4] = itemQty.ToString();
			}
			else
			{
				this.cartItems.Add(itemID, value);
			}
		}

		public void updateQuantity(string itemID, string itemQty)
		{
			string[] array = (string[])this.cartItems[itemID];
			array[4] = itemQty;
		}

		public void updateQuantity(string[] itemID, string[] itemQty)
		{
			for (int i = 0; i < itemID.Length; i++)
			{
				string itemID2 = itemID[i];
				string itemQty2 = itemQty[i];
				this.updateQuantity(itemID2, itemQty2);
			}
		}

		public void Clear()
		{
			this.cartItems.Clear();
		}

		public void Remove(string itemID)
		{
			if (this.cartItems.ContainsKey(itemID))
			{
				this.cartItems.Remove(itemID);
			}
		}

		public IDictionaryEnumerator getEnumerator()
		{
			return this.cartItems.GetEnumerator();
		}

		public double GetTotalPrice()
		{
			double num = 0.0;
			IDictionaryEnumerator enumerator = this.cartItems.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string[] array = (string[])enumerator.Value;
				num += (double)Convert.ToInt32(array[4]) * Convert.ToDouble(array[3]);
			}
			return num;
		}

		public double GetTotalQty()
		{
			double num = 0.0;
			IDictionaryEnumerator enumerator = this.cartItems.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string[] array = (string[])enumerator.Value;
				num += (double)Convert.ToInt32(array[4]);
			}
			return num;
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
	}
}

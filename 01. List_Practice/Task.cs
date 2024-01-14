using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01._List_Practice
{
	public class Task
	{
		public static void Main(string[] args)
		{
			Inventory inven = new Inventory();
			Item item = new Item();

			while (true)
			{
				Console.Write("1.아이템 줍기 2.아이템 버리기");
				ConsoleKeyInfo key = Console.ReadKey();
				Console.WriteLine();
				if (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.NumPad1)
					inven.GetItem(item);
				if(key.Key == ConsoleKey.D2 || key.Key == ConsoleKey.NumPad2)
					inven.ThrowItem(item);
			}
		}
		public class Inventory
		{
			public List<Item> items;

			public Inventory()
			{
				items = new List<Item>();
			}

			public void GetItem(Item item)
			{
				Console.WriteLine("추가할 아이템 이름을 입력하세요!");
				Console.Write(">");
				string temp = Console.ReadLine();
				item.name = temp;
				Console.WriteLine($"{item.name}을 획득했습니다. 오예!");
				items.Add(item);
				PrintItem(item);
			}

			public void ThrowItem(Item item)
			{
				Console.WriteLine("버릴 아이템 이름을 입력하세요!");
				Console.Write(">");
				string temp = Console.ReadLine();
				item.name = temp;
				Console.WriteLine($"{item.name}을 버립니다. 휙~");
				items.Remove(item);
				PrintItem(item);
			}

			public void PrintItem(Item item)
			{
				Console.WriteLine("==아이템 전체 목록==");
				foreach (Item i in items) { }
					Console.WriteLine(item.name);
			}
		}

		public class Item
		{
			public string name;
		}
	}
}

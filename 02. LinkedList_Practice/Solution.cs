using System.Reflection.Metadata.Ecma335;
using System.Security.Authentication;

namespace _02._LinkedList_Practice_Solution
{
	internal class Solution
	{
		static void Main(string[] args)
		{
			/*
			// 문제 1
			LinkedList<int> linkedList = new LinkedList<int>();

			while (true)
			{
				Console.Write("입력 : ");
				string text = Console.ReadLine();

				bool success = int.TryParse(text, out int value);

				if (!success)
				{
					Console.WriteLine("숫자를 입력해주세요");
					continue;
				}
				if (value < 0)
				{
					linkedList.AddFirst(value);
				}
				else if (value > 0)
				{
					linkedList.AddLast(value);
				}
				else
				{
					break;
				}

				foreach(int item in  linkedList)
				{
					Console.Write($"{item} ");
				}
				Console.WriteLine();
			}*/

			// 문제 2

			LinkedList<int> linkedList = new LinkedList<int>();
			int n = 7;
			int k = 3;

			for (int i = 0; i < n; i++)
			{
				linkedList.AddLast(i);
			}

			while (linkedList.Count > 0)
			{
				for (int i = 1; i <= k; i++)
				{
					LinkedListNode<int> node = linkedList.First;
					if (i == k)
					{
						// 빠지기
						linkedList.Remove(node);
						// linkedList.RemoveFirst(); 위와 동일
						Console.Write($"{node.Value} ");
					}
					else
					{
						// 뒤로 돌아가기
						linkedList.Remove(node);
						linkedList.AddLast(node);
					}
				}
			}
		}
	}
}

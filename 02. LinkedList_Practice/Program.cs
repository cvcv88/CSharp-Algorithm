using System.Collections.Generic;

namespace _02._LinkedList_Practice
{
	public class Program
	{
		static void Main1(string[] args)
		{
			LinkedList<int> linkedList = new LinkedList<int>();
			while (true)
			{
				// 문제 1 ~ 3
				// 1. 사용자의 입력으로(마이너스도 허용)
				// 2. 음수는 앞에 추가하고, 양수는 뒤에 추가
				// 3. 입력 받을 때마다 처음부터 끝까지 출력 진행
				// InsertNumber(linkedList); 문제 1 ~ 3

				// 문제 4
				// 요세푸스 순열 문제
				Josephus(linkedList);
			}
		}
		static public void InsertNumber(LinkedList<int> linkedList)
		{

			Console.WriteLine("숫자를 입력하시오 : ");
			int num = int.Parse(Console.ReadLine());

			if (num > 0)
			{
				linkedList.AddLast(num);
			}
			else
			{
				linkedList.AddFirst(num);
			}

			Console.Write("전체 리스트 출력 : ");
			foreach (int i in linkedList)
			{
				Console.Write($"{i} ");
			}
			Console.WriteLine();
		}

		static public void Josephus(LinkedList<int> linkedList)
		{
			/*Console.Write("사람이 몇 명 있나요? : ");
			int n = int.Parse(Console.ReadLine());
			Console.Write("정수 값을 입력해주세요. : ");
			int k = int.Parse(Console.ReadLine());*/


			/*// 실패한거
			for (int i = 1; i <= n; i++)
			{
				linkedList.AddLast(i);
			}
			int count = linkedList.Count;

			for (int i = 1; i <= ; i++)
			{
				if(i % 3 == 0)
				{
					int num = linkedList.First();
					Console.Write($"{i} ");
					linkedList.RemoveFirst();
				}
				else
				{
					int num = linkedList.First();
					linkedList.RemoveFirst();
					linkedList.AddLast(num);
				}
			}

			foreach (int i in linkedList)
			{
				Console.Write($"{i + 1} ");
			}
			Console.WriteLine();*/

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
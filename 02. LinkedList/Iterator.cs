using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._LinkedList
{
	public class Iterator
	{
		/*******************************************************************
         * 반복기 (Iterator)
         * 
         * 자료구조에 저장되어 있는 요소들을 순차적으로 접근하기 위한 객체
         * C# 대부분의 자료구조는 반복기를 포함
         * 이를 통해 자료구조종류와 내부구조에 무관하게 순회가능
         * 
         * 처음부터 끝까지(처음부터 끝이 있는 자료들) 순회하고 싶을 때 사용하는 것
         * IEnumerable<> - foreach
         * C#의 모든 자료구조에는 IEnumerable이 붙어있다.
         * 
         * 강의 다시 듣고 정리하기 조느라 못적음 너무졸림
         *******************************************************************/

		// <반복기 사용>
		// 반복기 객체를 자료구조에서 생성하여 순차적으로 확인하며 순회
		// IEnumerable : 자료구조의 반복기 생성 인터페이스
		// IEnumerator : 자료구조의 반복기 객체 인터페이스

		static void Main()
		{
			List<int> list = new List<int>();
			LinkedList<int> linkedList = new LinkedList<int>();

			for (int i = 0; i < 10; i++) // 0 ~ 9
			{
				list.Add(i);
				linkedList.AddLast(i);
			}

			for (int i = 0; i < list.Count; i++)
			{
				Console.Write($"{list[i]} ");
			}

			/*for(int i = 0; i < linkedList.Count; i++) // 잘못된 방법
			{
				// Console.Write($"{linkedList[i]"); // error!
			}*/
			Console.WriteLine();

			for (LinkedListNode<int> node = linkedList.First; node != null; node = node.Next)
			{ // 끝이 아닐때까지 반복, 노드의 다음 노드 가르키기 / 노드의 value로 출력하기
				Console.Write($"{node.Value} ");
			}

			// 여기서 문제 : 우리가 모르는 구조에는 어떻게 설정할지 고민이다!
			// 처음부터 끝까지 반복하고 싶다! -> 반복기 사용하면 된다.
			// 구조를 몰라도 반복기를 사용하면 순회가능하다

			foreach (int element in list)
			{
				Console.Write(element);
			}
			foreach (int element in linkedList)
			{
				Console.Write(element);
			}

			/*Book book = new Book();
			foreach (string value in book) // IEnumerable 없이는 안됨
			{

			}*/

			Average(list);
			Average(linkedList);
			Average(Func());

		}

		/*public class Book : IEnumerable<string>
		{
			public string[] text;
		}*/

		public static IEnumerable<int> Func()
		{
			yield return 0;
			yield return 1;
			yield return 2;
			yield return 3;
			yield return 4;

		}

		public static float Average(IEnumerable<int> container)
		{
			float average = 0;
			int count = 0;
			foreach (int element in container)
			{
				average += element;
				count++;
			}
			return average / count;
		}

	}
}
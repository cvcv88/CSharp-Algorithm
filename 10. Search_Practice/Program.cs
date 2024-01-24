using System;

namespace _10._Search_Practice
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// 순차탐색
			int[] array = { 1, 3, 5, 7, 9, 8, 6, 4, 2, 0 };

			int indexOf = Array.IndexOf(array, 2);
			int result = Searching.SequentialSearch(array, 2);
			Console.WriteLine($"순차탐색 결과 위치 : {indexOf}");
			Console.WriteLine($"구현한 결과 위치 : {result}");
			Console.WriteLine();
		}
	}
}

